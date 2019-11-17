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
            yearMonth_TB.Text = getTodaysYearMonth();
            updateForm();
        }

        private void updateForm()
        {
            this.SuspendLayout();
            gridUpdate();
            setFormName(Common.display_status);
            setMonthlyIncome();
            setMonthlySpending();
            setMonthlyTotal();
            this.ResumeLayout();
        }

        private void clearPaymentFigure()
        {
            dataGridView1.Rows.Clear();
        }

        private void updatePaymentFigure()
        {
            DateTime nowYearMonth = getNowYearMonth();

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.payment_status));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));

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
                    bool pay_off = (bool)sdr["PayOff"];

                    
                    addData(major_name, detail, date, amount, share, pay_off);
                    //string user = (string)sdr["model"];

                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(string major_name, string detail, DateTime date, int amount, bool share, bool pay_off)
        {
            string pay_off_str = "";
            if (share == true)
            {
                if (pay_off == true)
                {
                    pay_off_str = "済";
                }
                else
                {
                    pay_off_str = "未清算";
                }
            }
            else
            {
                pay_off_str = "対象外";
            }
            

            dataGridView1.Rows.Add(major_name, detail, date.ToString("yyyy年MM月dd日"), amount, share, pay_off_str);
        }

        private void Spending_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status =(int)Common.Amount_Status_List.SPENDING;
            gridUpdate();
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status = (int)Common.Amount_Status_List.INCOME;
            gridUpdate();
        }

        private void gridUpdate()
        {
            clearPaymentFigure();
            updatePaymentFigure();
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
            updateForm();
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
            updateForm();
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

        private void setMonthlyIncome()
        {
            int monthly_income_result = 0;

            monthly_income_result = getMonthlyIncomeTotal();

            IncomeCost_LB.Text = monthly_income_result.ToString();

        }

        private void setMonthlySpending()
        {
            int monthly_spending_result = 0;

            monthly_spending_result = getMonthlySpendingTotal();

            SpendingCost_LB.Text = monthly_spending_result.ToString();
        }

        private int getMonthlyIncomeTotal()
        {
            int monthly_income_total = 0;
            DateTime nowYearMonth = getNowYearMonth();

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.INCOME));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    int amount = (int)sdr["Amounts"];
                    monthly_income_total += amount;

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return monthly_income_total;
        }

        private int getMonthlySpendingTotal()
        {
            int monthly_spending_total = 0;
            DateTime nowYearMonth = getNowYearMonth();

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    int amount = (int)sdr["Amounts"];
                    monthly_spending_total += amount;

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return monthly_spending_total;
        }

        private void setMonthlyTotal()
        {
            int monthly_income_total = int.Parse(IncomeCost_LB.Text);
            int monthly_spending_total = int.Parse(SpendingCost_LB.Text);

            int monthly_total = monthly_income_total - monthly_spending_total;

            TotalCost_LB.Text = monthly_total.ToString();
        }
    }
}
