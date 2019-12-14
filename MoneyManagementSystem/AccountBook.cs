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
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyManagementSystem
{
    public partial class AccountBook : Form
    {
        Common com = new Common();

        public struct DoughnutData
        {
            public string[] item;
            public int[] item_total_cost;
        }

        public AccountBook()
        {
            InitializeComponent();
            Common.payment_status = (int)Common.Amount_Status_List.SPENDING;
        }

        private void AccountBook_Load(object sender, EventArgs e)
        {
            yearMonth_TB.Text = Common.getTodaysYearMonth();
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
            this.SuspendLayout();
            updateDoughnutGraph();
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

                    if (Common.payment_status == (int)Common.Amount_Status_List.INCOME)
                    {
                        addData(major_name, detail, date, amount, share, pay_off);
                    }
                    else if(Common.payment_status == (int)Common.Amount_Status_List.SPENDING)
                    {
                        addData(medium_name, detail, date, amount, share, pay_off);
                    }

                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(string item_name, string detail, DateTime date, int amount, bool share, bool pay_off)
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
            

            dataGridView1.Rows.Add(item_name, detail, date.ToString("yyyy年MM月dd日"), amount, share, pay_off_str);
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

        private void updateDoughnutGraph()
        {
            DoughnutData datas = new DoughnutData()
            {
                item = new string[dataGridView1.Rows.Count],
                item_total_cost = new int[dataGridView1.Rows.Count]
            };

            getEachItemTotalCost(ref datas.item, ref datas.item_total_cost);

            // 初期化
            chart1.Series.Clear();
            chart1.Titles.Clear();

            // データの取得
            DataSet ds = GetData(datas);

            // Chartコントロールにデータソースを設定
            chart1.DataSource = ds;

            // Chartコントロールにタイトルを設定
            chart1.Titles.Add("項目別の割合");

            // グラフの種類,系列,軸の設定
            for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
            {
                // 列名の取得
                string columnName = ds.Tables[0].Columns[i].ColumnName;

                // 系列の設定
                chart1.Series.Add(columnName);

                // グラフの種類
                chart1.Series[columnName].ChartType = SeriesChartType.Doughnut;

                // X軸
                chart1.Series[columnName].XValueMember = ds.Tables[0].Columns[0].ColumnName.ToString();
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                // Y軸
                chart1.Series[columnName].YValueMembers = columnName;
            }

            // X軸タイトル
            chart1.ChartAreas[0].AxisX.Title = "項目";

            chart1.DataBind();

            /*
            // フォームをロードするときの処理
            chart1.Series.Clear();  // ← 最初からSeriesが1つあるのでクリアします
            chart1.ChartAreas.Clear();

            // ChartにChartAreaを追加します
            string chart_area1 = "Area1";
            chart1.ChartAreas.Add(new ChartArea(chart_area1));
            // ChartにSeriesを追加します
            string legend1 = "Graph1";
            chart1.Series.Add(legend1);
            // グラフの種別を指定
            chart1.Series[legend1].ChartType = SeriesChartType.Pie; // 円グラフを指定してみます

            // 各項目の値を加算して合計(全体の大きさ)を算出します
            double total = (double)datas.item_total_cost.Sum();

            // データをシリーズにセットします
            for (int i = 0; i < datas.item_total_cost.Length; i++)
            {
                double rate = (datas.item_total_cost[i] / total) * 100.0;  // <-- ここで割合を算出します
                DataPoint dp = new DataPoint(rate, rate);
                chart1.Series[legend1].Points.Add(dp);
            }
            */
        }

        /// データの設定
        private DataSet GetData(DoughnutData datas)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dtRow;

            // 列の作成
            dt.Columns.Add("項目", Type.GetType("System.String"));
            dt.Columns.Add("項目別合計費", Type.GetType("System.Int32"));
            ds.Tables.Add(dt);

            for (int i = 0; i < datas.item.Length; i++)
            {
                // データの追加
                dtRow = ds.Tables[0].NewRow();
                dtRow[0] = datas.item[i];
                dtRow[1] = datas.item_total_cost[i];
                ds.Tables[0].Rows.Add(dtRow);

            }
            return ds;
        }

        private void getEachItemTotalCost(ref string[] item, ref int[] item_total_cost)
        {
            int item_cnt = 0;
            bool matched = false;

            //  datagridviewの一行ずつに対して
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // 既存の項目なら加算、ないなら新規追加
                for (int j = 0; j < item_cnt; j++)
                {
                    // アイテムリストにあれば合計値を加算
                    // if(item[j] == datagridview[i]の名前と一致
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == item[j])
                    {
                        item_total_cost[j] += (int)dataGridView1.Rows[i].Cells[3].Value;
                        matched = true;
                    }
                }

                // アイテムリストになければ新規アイテムに追加と加算
                if (matched == false)
                {
                    item[item_cnt] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    item_total_cost[item_cnt] = (int)dataGridView1.Rows[i].Cells[3].Value;
                    item_cnt++;
                }

                matched = false;
            }
        }
    }
}
