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
    public partial class Input : Form
    {
        Common com = new Common();
        public static int major_item_id = 0;
        public static int medium_item_id = 0;
        public static string item_name = "";

        public Input()
        {
            InitializeComponent();
        }

        private void Item_Select_Button_Click(object sender, EventArgs e)
        {
            MajorItemSelect MajorItemSelectForm = new MajorItemSelect();
            MajorItemSelectForm.ShowDialog();
            Item_TB.Text = item_name;
            this.PerformLayout();
            MajorItemSelectForm.Dispose();
        }

        private void Save_Btn_Click(object sender, EventArgs e)
        {
            saveContent();
        }

        private void Spending_button_Click(object sender, EventArgs e)
        {
            paymentStatus((int)Common.Amount_Status_List.SPENDING);
            itemTextClear();
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            paymentStatus((int)Common.Amount_Status_List.INCOME);
            itemTextClear();
        }

        private void paymentStatus(int status)
        {
            Common.payment_status = status;
        }

        private void itemTextClear()
        {
            this.Item_TB.Text = "";
        }

        private void saveContent()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "INSERT INTO [dbo].[MoneyDetail] VALUES (@user_id, @major_item_id, @medium_item_id, @detail, @date, @amounts, @share)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                int i = getUserId();
                cmd.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int));
                cmd.Parameters["@user_id"].Value = getUserId();
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


                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private int getUserId()
        {
            return Common.display_status;
        }

        private int getMajorItemId()
        {
            return Input.major_item_id;
        }

        private int getMediumItemId()
        {
            return Input.medium_item_id;
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
            else if(Shared_CB.Checked == false)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
