using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MoneyManagementSystem
{
    public partial class ChangeData : Form
    {
        Common com = new Common();
        public static int id = 0;
        public static int major_item_id = 0;
        public static int medium_item_id = 0;
        public static string item_name = "";

        public ChangeData()
        {
            InitializeComponent();
            initDialog();
            SetCheckBoxVisibility(false);
        }

        /// <summary>
        /// チェックボックスの表示制御関数
        /// </summary>
        /// <param name="val"></param>
        private void SetCheckBoxVisibility(bool val)
        {
            Shared_CB.Visible = val;
            chkKei.Visible = val;
            chkMiki.Visible = val;
        }

        private void initDialog()
        {
            string detail = "";
            DateTime date = new DateTime();
            int amount = 0;
            bool share = false;
            int user_id = 0;
            bool living_expenses = false;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT * ";
                sqlstr = sqlstr + "FROM [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "WHERE  Id = @id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    major_item_id = (int)sdr["MajorItemId"];
                    medium_item_id = (int)sdr["MediumItemId"];
                    detail = (string)sdr["Detail"];
                    date = (DateTime)sdr["Date"];
                    amount = (int)sdr["Amounts"];
                    share = (bool)sdr["Share"];
                    user_id = (int)sdr["UserId"];
                    living_expenses = (bool)sdr["LivingExpenses"];
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Amount_TB.Text = amount.ToString();
            Item_TB.Text = getMediumItemName(medium_item_id);
            dateTimePicker1.Text = date.ToString("yyyy年MM月dd日");
            Detail_TB.Text = detail;
            Shared_CB.Checked = share;

            if(user_id == (int)Common.Display_Status_LIST.DISP_KEISUKE)
            {
                chkKei.Checked = true;
            }
            else if(user_id == (int)Common.Display_Status_LIST.DISP_MIKI)
            {
                chkMiki.Checked = true;
            }
            else
            {
                chkKei.Checked = false;
                chkMiki.Checked = false;
            }

            chkLivingExpenses.Checked = living_expenses;
        }

        private string getMediumItemName(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT * ";
                sqlstr = sqlstr + "FROM [dbo].[MediumItem] ";
                sqlstr = sqlstr + "WHERE  ItemId = @id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@id", id));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    item_name = (string)sdr["ItemName"];
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return item_name;
            
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            saveContent();
        }

        private void saveContent()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "UPDATE [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "SET MajorItemId = @major_item_id, MediumItemId = @medium_item_id, Detail = @detail, Date = @date, Amounts = @amounts, Share = @share, UserId = @user_id, LivingExpenses = @living_expenses ";
                sqlstr = sqlstr + "WHERE Id = @id ";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                
                cmd.Parameters.Add(new SqlParameter("@major_item_id", SqlDbType.Int));
                cmd.Parameters["@major_item_id"].Value = getMajorItemId();
                cmd.Parameters.Add(new SqlParameter("@medium_item_id", SqlDbType.Int));
                cmd.Parameters["@medium_item_id"].Value = getMediumItemId();
                cmd.Parameters.Add(new SqlParameter("@detail", SqlDbType.NVarChar));
                cmd.Parameters["@detail"].Value = Detail_TB.Text;
                cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                cmd.Parameters["@date"].Value = getInputDate();
                cmd.Parameters.Add(new SqlParameter("@amounts", SqlDbType.Int));
                cmd.Parameters["@amounts"].Value = getAmount();
                cmd.Parameters.Add(new SqlParameter("@share", SqlDbType.Bit));
                cmd.Parameters["@share"].Value = getShare();
                cmd.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int));
                cmd.Parameters["@user_id"].Value = getUserId();

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                cmd.Parameters["@id"].Value = id;

                cmd.Parameters.Add(new SqlParameter("@living_expenses", SqlDbType.Bit));
                cmd.Parameters["@living_expenses"].Value = getLivingExpenses();



                int result = cmd.ExecuteNonQuery();


                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private bool getLivingExpenses()
        {
            return chkLivingExpenses.Checked;
        }
        private void Item_Select_Button_Click(object sender, EventArgs e)
        {
            ChangeMajorItem ChangeMajorItemSelectForm = new ChangeMajorItem();
            ChangeMajorItemSelectForm.ShowDialog();
            Item_TB.Text = item_name;
            this.PerformLayout();
            ChangeMajorItemSelectForm.Dispose();
        }

        private int getMajorItemId()
        {
            return ChangeData.major_item_id;
        }

        private int getMediumItemId()
        {
            return ChangeData.medium_item_id;
        }

        private DateTime getInputDate()
        {
            string date = dateTimePicker1.Value.ToShortDateString();
            string format = "yyyy/MM/dd";

            return DateTime.ParseExact(date, format, null);
        }

        private int getAmount()
        {
            return int.Parse(Amount_TB.Text);
        }

        private bool getShare()
        {
            if (Shared_CB.Checked == true)
            {
                return true;
            }
            else if (Shared_CB.Checked == false)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        private void chkKei_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMiki.Checked)
            {
                chkMiki.Checked = false;
            }
        }

        private void chkMiki_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKei.Checked)
            {
                chkKei.Checked = false;
            }
        }

        private int getUserId()
        {
            if (chkKei.Checked)
            {
                return (int)Common.Display_Status_LIST.DISP_KEISUKE;
            }
            else if (chkMiki.Checked)
            {
                return (int)Common.Display_Status_LIST.DISP_MIKI;
            }
            else
            {
                return (int)Common.Display_Status_LIST.DISP_COOP;
            }
        }
    }
}
