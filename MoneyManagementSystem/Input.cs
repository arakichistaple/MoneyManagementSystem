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
        public static bool is_closed = false;
        public static bool is_saved = false;
        public static Point displayPos;

        public Input()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(displayPos.X + 15, displayPos.Y + 70);
            InitializeComponent();
            setButtonColor();
            SetCheckBoxVisibility(false);
            Input.is_closed = false;
            Input.is_saved = false;
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

        private void setButtonColor()
        {
            this.SuspendLayout();
            if (Common.payment_status == (int)Common.Amount_Status_List.INCOME)
            {
                Income_Button.BackColor = Color.LightSeaGreen;
                Spending_button.BackColor = Color.DarkGray;
            }
            else if(Common.payment_status == ((int)Common.Amount_Status_List.SPENDING))
            {
                Income_Button.BackColor = Color.DarkGray;
                Spending_button.BackColor = Color.LightSeaGreen;
            }
            this.ResumeLayout();
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
            Input.is_saved = true;
            this.Close();
        }

        private void Spending_button_Click(object sender, EventArgs e)
        {
            paymentStatus((int)Common.Amount_Status_List.SPENDING);
            SetCheckBoxVisibility(false);
            itemTextClear();
            setButtonColor();
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            paymentStatus((int)Common.Amount_Status_List.INCOME);
            Shared_CB.Checked = false;
            itemTextClear();
            setButtonColor();
            SetCheckBoxVisibility(false);
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
                sqlstr = sqlstr + "INSERT INTO [dbo].[MoneyDetail] VALUES (@user_id, @major_item_id, @medium_item_id, @detail, @date, @amounts, @share, @pay_off, @living_expenses )";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
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

                cmd.Parameters.Add(new SqlParameter("@pay_off", SqlDbType.Bit));
                cmd.Parameters["@pay_off"].Value = false;

                cmd.Parameters.Add(new SqlParameter("@living_expenses", SqlDbType.Bit));
                cmd.Parameters["@living_expenses"].Value = getLivingExpenses();


                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool getLivingExpenses()
        {
            return chkLivingExpenses.Checked;
        }

        private int getUserId()
        {
            if(chkKei.Checked)
            {
                return (int)Common.Display_Status_LIST.DISP_KEISUKE;
            }
            else if(chkMiki.Checked)
            {
                return (int)Common.Display_Status_LIST.DISP_MIKI;
            }
            else
            {
                return (int)Common.Display_Status_LIST.DISP_COOP;
            }

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

        private void Input_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Input.is_saved) is_closed = false;
            else                is_closed = true;
        }

        private void chkKei_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMiki.Checked)
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

        private void Amount_TB_Click(object sender, EventArgs e)
        {
            Amount_TB.Text = "";
        }
    }
}
