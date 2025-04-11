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
            yearMonth_TB.Text = Common.GetYearMonthStr(DateTime.Now);
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
                sqlstr = sqlstr + "SELECT MD.Id, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND MD.Share = CONVERT(bit, 'true') AND MD.PayOff = CONVERT(bit, 'false') AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", personId));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    int id = (int)sdr["Id"];
                    string user = (string)sdr["UserName"];
                    string major_name = (string)sdr["MjrItemName"];
                    string medium_name = (string)sdr["MdmItemName"];
                    string detail = (string)sdr["Detail"];
                    DateTime date = (DateTime)sdr["Date"];
                    int amount = (int)sdr["Amounts"] / 2;
                    bool share = (bool)sdr["Share"];
                    bool pay_off = (bool)sdr["PayOff"];


                    addData(id, personId, medium_name, detail, date, amount, pay_off);

                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(int id, int personId, string item_name, string detail, DateTime date, int amount, bool pay_off)
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
                    dataGridView1.Rows.Add(id, item_name, detail, date.ToString("yyyy年MM月dd日"), amount, pay_off_str);
                    break;
                case 2:
                    dataGridView2.Rows.Add(id, item_name, detail, date.ToString("yyyy年MM月dd日"), amount, pay_off_str);
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
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND MD.Share = CONVERT(bit, 'true') AND MD.PayOff = CONVERT(bit, 'false') AND ";
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


                    total_cost += amount / 2;
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

        private void PayOff_Btn_Click(object sender, EventArgs e)
        {
            InputPerson1ItemsToPerson2();
            updatePerson1ItemsAmountToHalf();
            InputPerson2ItemsToPerson1();
            updatePerson2ItemsAmountToHalf();
            updatePayOffToTrue();
            updateForm();

        }

        private void InputPerson1ItemsToPerson2()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "INSERT INTO [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "VALUES(@user_id, @major_item_id, @medium_item_id, @detail, @date, @amounts, @share, @pay_off) ";
                SqlCommand cmd = new SqlCommand(sqlstr, con);

                cmd.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@major_item_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@medium_item_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@detail", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                cmd.Parameters.Add(new SqlParameter("@amounts", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@share", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@pay_off", SqlDbType.Bit));

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int major_item_id = 0;
                    int medium_item_id = 0;

                    getPerson1MajorAndMediumItemId(i, 1, ref major_item_id, ref medium_item_id);
                    cmd.Parameters["@user_id"].Value = Common.Display_Status_LIST.DISP_MIKI;
                    cmd.Parameters["@major_item_id"].Value = major_item_id;
                    cmd.Parameters["@medium_item_id"].Value = medium_item_id;
                    cmd.Parameters["@detail"].Value = (string)dataGridView1.Rows[i].Cells[2].Value;
                    cmd.Parameters["@date"].Value = getPerson1DataGridDate(i,3);
                    cmd.Parameters["@amounts"].Value = (int)dataGridView1.Rows[i].Cells[4].Value;
                    cmd.Parameters["@share"].Value = true;
                    cmd.Parameters["@pay_off"].Value = true;
                    cmd.ExecuteNonQuery();
                }

                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getPerson1MajorAndMediumItemId(int row, int cell, ref int major_id, ref int medium_id)
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT ItemId, MajorItemId ";
                sqlstr = sqlstr + "From [dbo].[MediumItem] ";
                sqlstr = sqlstr + "Where ItemName = @item_name";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@item_name", (string)dataGridView1.Rows[row].Cells[cell].Value));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    major_id = (int)sdr["MajorItemId"];
                    medium_id = (int)sdr["ItemId"];
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime getPerson1DataGridDate(int row, int cell)
        {
            string date = (string)dataGridView1.Rows[row].Cells[cell].Value;
            string format = "yyyy年MM月dd日";

            return DateTime.ParseExact(date, format, null);
        }

        private void updatePerson1ItemsAmountToHalf()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "UPDATE [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "SET Amounts = @amount ";
                sqlstr = sqlstr + "WHERE Id = @id";

                for (int i = 0; i < (int)dataGridView1.Rows.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(sqlstr, con);
                    cmd.Parameters.Add(new SqlParameter("@id", dataGridView1.Rows[i].Cells[0].Value));
                    cmd.Parameters.Add(new SqlParameter("@amount", (int)dataGridView1.Rows[i].Cells[4].Value));

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InputPerson2ItemsToPerson1()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "INSERT INTO [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "VALUES(@user_id, @major_item_id, @medium_item_id, @detail, @date, @amounts, @share, @pay_off) ";
                SqlCommand cmd = new SqlCommand(sqlstr, con);

                cmd.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@major_item_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@medium_item_id", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@detail", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                cmd.Parameters.Add(new SqlParameter("@amounts", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@share", SqlDbType.Bit));
                cmd.Parameters.Add(new SqlParameter("@pay_off", SqlDbType.Bit));

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    int major_item_id = 0;
                    int medium_item_id = 0;

                    getPerson2MajorAndMediumItemId(i, 1, ref major_item_id, ref medium_item_id);

                    cmd.Parameters["@user_id"].Value = Common.Display_Status_LIST.DISP_KEISUKE;
                    cmd.Parameters["@major_item_id"].Value = major_item_id;
                    cmd.Parameters["@medium_item_id"].Value = medium_item_id;
                    cmd.Parameters["@detail"].Value = (string)dataGridView2.Rows[i].Cells[2].Value;
                    cmd.Parameters["@date"].Value = getPerson2DataGridDate(i, 3);
                    cmd.Parameters["@amounts"].Value = (int)dataGridView2.Rows[i].Cells[4].Value;
                    cmd.Parameters["@share"].Value = true;
                    cmd.Parameters["@pay_off"].Value = true;
                    cmd.ExecuteNonQuery();
                }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getPerson2MajorAndMediumItemId(int row, int cell, ref int major_id, ref int medium_id)
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT ItemId, MajorItemId ";
                sqlstr = sqlstr + "From [dbo].[MediumItem] ";
                sqlstr = sqlstr + "Where ItemName = @item_name";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@item_name", (string)dataGridView2.Rows[row].Cells[cell].Value));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    major_id = (int)sdr["MajorItemId"];
                    medium_id = (int)sdr["ItemId"];
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime getPerson2DataGridDate(int row, int cell)
        {
            string date = (string)dataGridView2.Rows[row].Cells[cell].Value;
            string format = "yyyy年MM月dd日";

            return DateTime.ParseExact(date, format, null);
        }

        private void updatePerson2ItemsAmountToHalf()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "UPDATE [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "SET Amounts = @amount ";
                sqlstr = sqlstr + "WHERE Id = @id";

                for (int i = 0; i < (int)dataGridView2.Rows.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(sqlstr, con);
                    cmd.Parameters.Add(new SqlParameter("@id", dataGridView2.Rows[i].Cells[0].Value));
                    cmd.Parameters.Add(new SqlParameter("@amount", (int)dataGridView2.Rows[i].Cells[4].Value));

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updatePayOffToTrue()
        {
            DateTime nowYearMonth = getNowYearMonth();

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "UPDATE [dbo].[MoneyDetail] ";
                sqlstr = sqlstr + "SET PayOff = CONVERT(bit, 'true') ";
                sqlstr = sqlstr + "WHERE [dbo].[MoneyDetail].Share = CONVERT(bit, 'true') AND ";
                sqlstr = sqlstr + "( [dbo].[MoneyDetail].Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
