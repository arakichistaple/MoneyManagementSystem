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
    public partial class AccountBook : Form
    {
        Common com = new Common();

        public AccountBook()
        {
            InitializeComponent();
            Common.payment_status = (int)Common.Amount_Status_List.SPENDING;
        }

        private void AccountBook_Load(object sender, EventArgs e)
        {
            clearPaymentFigure();
            initPaymentFigure();
            setFormName(Common.display_status);
            yearMonth_TB.Text = getTodaysYearMonth();
        }

        private void clearPaymentFigure()
        {
            dataGridView1.Rows.Clear();
        }

        private void initPaymentFigure()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    string user = (string)sdr["UserName"];
                    string major_name = (string)sdr["MjrItemName"];
                    string medium_name = (string)sdr["MdmItemName"];
                    string detail = (string)sdr["Detail"];
                    DateTime date = (DateTime)sdr["Date"];
                    int amount = (int)sdr["Amounts"];
                    bool share = (bool)sdr["Share"];

                    addData(major_name, detail, date, amount, share);
                    //string user = (string)sdr["model"];

                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(string major_name, string detail, DateTime date, int amount, bool share)
        {
            dataGridView1.Rows.Add(major_name, detail, date.ToString("yyyy年MM月dd日"), amount, share);
        }

        private void Spending_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status =(int)Common.Amount_Status_List.SPENDING;
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status = (int)Common.Amount_Status_List.INCOME;
        }

        private void gridUpdate()
        {
            this.SuspendLayout();
            clearPaymentFigure();
            initPaymentFigure();
            this.ResumeLayout();
        }

        private void Input_Button_Click(object sender, EventArgs e)
        {
            Input input_form = new Input();
            this.Hide();
            input_form.ShowDialog();
            this.Show();
            gridUpdate();
        }

        private void setFormName(int user_id)
        {
            string name = "";
            string accountBookString = "の家計簿";
            
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT UserName ";
                sqlstr = sqlstr + "FROM [dbo].[User] ";
                sqlstr = sqlstr + "WHERE UserId = @user_id";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user_id", user_id));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    name = (string)sdr["UserName"];
                }
                con.Close();

                this.Text = name + accountBookString;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void home_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private  string getTodaysYearMonth()
        {
            DateTime dt = DateTime.Now;

            string result = dt.ToString("yyyy年MM月");

            return result;
        }

        private void prevMonthBtn_Click(object sender, EventArgs e)
        {
            setPrevMonthText();
        }

        private void setPrevMonthText()
        {
            DateTime now_year_month = getNowYearMonth();
            DateTime prev_year_month = now_year_month.AddMonths(-1);

            yearMonth_TB.Text = prev_year_month.ToString("yyyy年MM月");
        }

        private void nextMonthBtn_Click(object sender, EventArgs e)
        {
            setNextMonthText();
        }

        private void setNextMonthText()
        {
            DateTime now_year_month = getNowYearMonth();
            DateTime next_year_month = now_year_month.AddMonths(1);

            yearMonth_TB.Text = next_year_month.ToString("yyyy年MM月");
        }

        private DateTime getNowYearMonth()
        {
            string format = "yyyy年MM月";
            string now_year_month_string = yearMonth_TB.Text;

            return DateTime.ParseExact(now_year_month_string, format, null);
        }
    }
}
