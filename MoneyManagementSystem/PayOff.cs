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
    public partial class PayOff : Form
    {
        Common com = new Common();

        public PayOff()
        {
            InitializeComponent();
        }

        private void PayOff_Load(object sender, EventArgs e)
        {
            yearMonth_TB.Text = Common.getTodaysYearMonth();
            setPerson1(Common.person1);
            setPerson2(Common.person2);
            updateForm();
        }

        private void updateForm()
        {
            this.SuspendLayout();
            clearPaymentFigure();
            gridUpdate((int)Common.Display_Status_LIST.DISP_KEISUKE);
            gridUpdate((int)Common.Display_Status_LIST.DISP_MIKI);
            setPersonTotal((int)Common.Display_Status_LIST.DISP_KEISUKE);
            setPersonTotal((int)Common.Display_Status_LIST.DISP_MIKI);
            setPayOffTotal();
            this.ResumeLayout();
        }

        private void setPerson1(string name)
        {
            Name1_LB.Text = name;
        }

        private void setPerson2(string name)
        {
            Name2_LB.Text = name;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridUpdate(int personId)
        {
            updatePaymentFigure(personId);
        }

        private void updatePaymentFigure(int personId)
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
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND MD.Share = CONVERT(bit, 'true') AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", personId));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
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


                    addData(personId, medium_name, detail, date, amount, pay_off);

                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(int personId, string item_name, string detail, DateTime date, int amount, bool pay_off)
        {
            string pay_off_str = "";

            if (pay_off == true)
            {
                pay_off_str = "済";
            }
            else
            {
                pay_off_str = "未清算";
            }

            switch(personId)
            {
                case 1:
                    dataGridView1.Rows.Add(item_name, detail, date.ToString("yyyy年MM月dd日"), amount, pay_off_str);
                    break;
                case 2:
                    dataGridView2.Rows.Add(item_name, detail, date.ToString("yyyy年MM月dd日"), amount, pay_off_str);
                    break;
                default:
                    MessageBox.Show("グリッドの更新に失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void clearPaymentFigure()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private DateTime getNowYearMonth()
        {
            string format = "yyyy年MM月";
            string now_year_month_string = yearMonth_TB.Text;

            return DateTime.ParseExact(now_year_month_string, format, null);
        }

        private void setPrevMonthText()
        {
            DateTime now_year_month = getNowYearMonth();
            DateTime prev_year_month = now_year_month.AddMonths(-1);

            yearMonth_TB.Text = prev_year_month.ToString("yyyy年MM月");
        }

        private void setNextMonthText()
        {
            DateTime now_year_month = getNowYearMonth();
            DateTime next_year_month = now_year_month.AddMonths(1);

            yearMonth_TB.Text = next_year_month.ToString("yyyy年MM月");
        }

        private void prevMonthBtn_Click(object sender, EventArgs e)
        {
            setPrevMonthText();
            updateForm();
        }

        private void nextMonthBtn_Click(object sender, EventArgs e)
        {
            setNextMonthText();
            updateForm();
        }

        private void setPersonTotal(int personId)
        {
            int total_cost = 0;

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
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND MD.Share = CONVERT(bit, 'true') AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", personId));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
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


                    total_cost += amount;
                    //string user = (string)sdr["model"];

                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(personId == (int)Common.Display_Status_LIST.DISP_KEISUKE)
            {
                setPerson1Total(total_cost);
            }
            else
            {
                setPerson2Total(total_cost);
            }
        }

        private void setPerson1Total(int total_cost)
        {
            Total1_LB.Text = total_cost.ToString();
        }

        private void setPerson2Total(int total_cost)
        {
            Total2_LB.Text = total_cost.ToString();
        }

        private void setPayOffTotal()
        {
            int person1_total = int.Parse(Total1_LB.Text);
            int person2_total = int.Parse(Total2_LB.Text);

            if(person1_total > person2_total)
            {
                Payer_LB.Text = Common.person2;
                PayerCost_LB.Text = (person1_total - person2_total).ToString();
            }
            else if(person1_total < person2_total)
            {
                Payer_LB.Text = Common.person1;
                PayerCost_LB.Text = (person2_total - person1_total).ToString();
            }
            else
            {
                Payer_LB.Text = "なし";
                PayerCost_LB.Text = "0";
            }
        }

    }
}
