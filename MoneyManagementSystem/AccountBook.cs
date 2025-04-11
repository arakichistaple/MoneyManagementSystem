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
using System.IO;

namespace MoneyManagementSystem
{
    public partial class AccountBook : Form
    {
        Common com = new Common();

        public static DateTime LookingDate;

        public struct DoughnutData
        {
            public string[] item;
            public int[] item_total_cost;
        }

        public AccountBook()
        {
            InitializeComponent();
            Common.display_status = (int)Common.Display_Status_LIST.DISP_COOP;
            Common.payment_status = (int)Common.Amount_Status_List.SPENDING;
            //DataGridViewのContextMenuStripを設定する
            dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            setDispBtnColor();
        }

        private void AccountBook_Load(object sender, EventArgs e)
        {
            yearMonth_TB.Text = Common.GetYearMonthStr(DateTime.Now);
            setLookingDate(DateTime.Now);
            updateForm();
        }

        private void updateForm()
        {
            this.SuspendLayout();
            gridUpdate();
            setFormName(Common.display_status);
            setMonthlyIncome();
            setMonthlySpending();
            setMonthlyInvestment();
            setMonthlyTotal();
            setMonthlyIncludeInvestTotal();
            setMonthlySavedRatio();
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
                /*
                sqlstr = sqlstr + "SELECT MD.Id AS MdId, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                */

                SqlCommand cmd;
                if (Common.display_status == (int)Common.Display_Status_LIST.DISP_COOP)
                {
                    sqlstr = sqlstr + "SELECT MD.Id AS MdId, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff, LivingExpenses ";
                    sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                    sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                    sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month) ";
                    sqlstr = sqlstr + "ORDER BY Amounts DESC";
                    cmd = new SqlCommand(sqlstr, con);
                    //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                    cmd.Parameters.Add(new SqlParameter("@paymentId", Common.payment_status));
                    cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                    cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));
                }
                else
                {
                    sqlstr = sqlstr + "SELECT MD.Id AS MdId, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff, LivingExpenses ";
                    sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                    sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                    sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                    cmd = new SqlCommand(sqlstr, con);
                    cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                    cmd.Parameters.Add(new SqlParameter("@paymentId", Common.payment_status));
                    cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                    cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));
                }

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    int id = (int)sdr["MdId"];
                    string user = (string)sdr["UserName"];
                    string major_name = (string)sdr["MjrItemName"];
                    string medium_name = (string)sdr["MdmItemName"];
                    string detail = (string)sdr["Detail"];
                    DateTime date = (DateTime)sdr["Date"];
                    int amount = (int)sdr["Amounts"];
                    bool share = (bool)sdr["Share"];
                    bool pay_off = (bool)sdr["PayOff"];
                    bool living_expenses = (bool)sdr["LivingExpenses"];

                    /*
                    if (Common.payment_status == (int)Common.Amount_Status_List.INCOME)
                    {
                        addData(id, major_name, detail, date, amount, share, pay_off);
                    }
                    else if(Common.payment_status == (int)Common.Amount_Status_List.SPENDING)
                    {
                        addData(id, medium_name, detail, date, amount, share, pay_off);
                    }
                    */

                    addData(id, date, amount, GetLivingExpensesStr(living_expenses), major_name, medium_name, detail);

                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLivingExpensesStr(bool val)
        {
            if (val) return "基礎";
            else return "";
        }

        /*
        private void addData(int id, string item_name, string detail, DateTime date, int amount, bool share, bool pay_off)
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
            

            dataGridView1.Rows.Add(id, item_name, detail, date.ToString("yyyy年MM月dd日"), amount, share, pay_off_str);
        }
        */

        private void addData(int id, DateTime date, int amount, string living_expenses, string major_item_name, string medium_item_name, string detail)
        {
            dataGridView1.Rows.Add(id, date.ToString("yyyy年MM月dd日"), amount, living_expenses, major_item_name, medium_item_name, detail);
        }

        private void Spending_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status =(int)Common.Amount_Status_List.SPENDING;
            updateForm();
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status = (int)Common.Amount_Status_List.INCOME;
            updateForm();
        }

        private void gridUpdate()
        {
            clearPaymentFigure();
            updatePaymentFigure();
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

        private void prevMonthBtn_Click(object sender, EventArgs e)
        {
            setPrevMonthText();
            updateForm();
        }

        private void setPrevMonthText()
        {
            DateTime now_year_month = getNowYearMonth();
            DateTime prev_year_month = now_year_month.AddMonths(-1);

            setLookingDate(prev_year_month);
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

            setLookingDate(next_year_month);
            yearMonth_TB.Text = next_year_month.ToString("yyyy年MM月");
        }

        private void setLookingDate(DateTime date)
        {
            LookingDate = date;
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

        private void setMonthlyInvestment()
        {
            int monthly_invest_result = 0;

            monthly_invest_result = getMonthlyInvestTotal();

            InvestCost_LB.Text = monthly_invest_result.ToString();

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
                /*
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                */

                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
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
                /*
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                */

                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
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

        private int getMonthlyInvestTotal()
        {
            int monthly_invest_total = 0;
            DateTime nowYearMonth = getNowYearMonth();

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                /*
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                */

                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.ItemId = @itemId AND MDM.ItemId in (@itemId1, @itemId2, @itemId3, @itemId4, @itemId5) AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@itemId", Common.Major_Item_List.OTHERS));
                cmd.Parameters.Add(new SqlParameter("@itemId1", Common.Medium_Item_List.INVEST_DOMESTIC));
                cmd.Parameters.Add(new SqlParameter("@itemId2", Common.Medium_Item_List.INVEST_FOREIGN_ETF));
                cmd.Parameters.Add(new SqlParameter("@itemId3", Common.Medium_Item_List.NISA_KEISUKE));
                cmd.Parameters.Add(new SqlParameter("@itemId4", Common.Medium_Item_List.NISA_MIKI));
                cmd.Parameters.Add(new SqlParameter("@itemId5", Common.Medium_Item_List.JUNIOR_NISA));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowYearMonth)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowYearMonth)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    int amount = (int)sdr["Amounts"];
                    monthly_invest_total += amount;

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return monthly_invest_total;
        }

        private void setMonthlyTotal()
        {
            int monthly_income_total = int.Parse(IncomeCost_LB.Text);
            int monthly_spending_total = int.Parse(SpendingCost_LB.Text);

            int monthly_total = monthly_income_total - monthly_spending_total;

            if (monthly_total > 0)
            {
                TotalCost_LB.ForeColor = Color.ForestGreen;
                TotalCost_LB.Text = monthly_total.ToString();
            }
            else if(monthly_total < 0)
            {
                TotalCost_LB.ForeColor = Color.Crimson;
                TotalCost_LB.Text = "▲ " + Math.Abs(monthly_total).ToString();
            }
            else
            {
                TotalCost_LB.ForeColor = Color.Black;
                TotalCost_LB.Text = monthly_total.ToString();
            }
        }

        private void setMonthlyIncludeInvestTotal()
        {
            int monthly_income_total = int.Parse(IncomeCost_LB.Text);
            int monthly_spending_total = int.Parse(SpendingCost_LB.Text);
            int monthly_invest_total = int.Parse(InvestCost_LB.Text);

            int monthly_total = monthly_income_total - (monthly_spending_total - monthly_invest_total);

            if (monthly_total > 0)
            {
                TotalIncludeInvestCost_LB.ForeColor = Color.ForestGreen;
                TotalIncludeInvestCost_LB.Text = monthly_total.ToString();
            }
            else if (monthly_total < 0)
            {
                TotalIncludeInvestCost_LB.ForeColor = Color.Crimson;
                TotalIncludeInvestCost_LB.Text = "▲ " + Math.Abs(monthly_total).ToString();
            }
            else
            {
                TotalIncludeInvestCost_LB.ForeColor = Color.Black;
                TotalIncludeInvestCost_LB.Text = monthly_total.ToString();
            }
        }

        private void setMonthlySavedRatio()
        {
            int monthly_income_total = int.Parse(IncomeCost_LB.Text);
            int monthly_spending_total = int.Parse(SpendingCost_LB.Text) - int.Parse(InvestCost_LB.Text);
            int monthly_saved_total = monthly_income_total - monthly_spending_total;

            float saved_ratio;

            if (monthly_saved_total < 0) saved_ratio = 0.0f;
            else saved_ratio = ((float)monthly_saved_total / (float)monthly_income_total) * 100;

            if (saved_ratio > 0.0f)
            {
                SavedRatio_LB.ForeColor = Color.ForestGreen;
                SavedRatio_LB.Text = saved_ratio.ToString("F2") + "%";
            }
            else
            {
                SavedRatio_LB.ForeColor = Color.Crimson;
                SavedRatio_LB.Text = saved_ratio.ToString("F2") + "%";
            }
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
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == item[j])
                    {
                        item_total_cost[j] += (int)dataGridView1.Rows[i].Cells[2].Value;
                        matched = true;
                    }
                }

                // アイテムリストになければ新規アイテムに追加と加算
                if (matched == false)
                {
                    item[item_cnt] = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    item_total_cost[item_cnt] = (int)dataGridView1.Rows[i].Cells[2].Value;
                    item_cnt++;
                }

                matched = false;
            }
        }

        private void Input_Btn_Click(object sender, EventArgs e)
        {
            Input.displayPos = this.Location;
            Input input_form = new Input();
            

            input_form.ShowDialog();
            updateForm();

            if(!Input.is_closed)
            {
                Input_Btn_Click(sender, e);
            }
        }

        private void Back_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // ヘッダ以外のセルか？
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1[1, e.RowIndex];
                this.ResumeLayout();
                this.SuspendLayout();
                this.ResumeLayout();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void deleteData()
        {

            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

            DialogResult result = MessageBox.Show("ID：" + id + "を本当に削除しますか？\n※一度削除すると元に戻せません。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {


                try
                {
                    SqlConnection con = new SqlConnection(com.CON_STR);
                    con.Open();

                    string sqlstr = "";
                    sqlstr = sqlstr + "DELETE FROM [dbo].[MoneyDetail]";
                    sqlstr = sqlstr + "WHERE Id = @id ";
                    SqlCommand cmd = new SqlCommand(sqlstr, con);
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    cmd.ExecuteNonQuery();

                    con.Close();

                    gridUpdate();

                    MessageBox.Show("ID：" + id + "を削除しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                ;
            }


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeData.id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            ChangeData change_data_form = new ChangeData();
            
            change_data_form.ShowDialog();
            gridUpdate();
        }

        private void Summary_Btn_Click(object sender, EventArgs e)
        {
            Summary summary_form = new Summary();
            summary_form.ShowDialog();
        }

        private void btnCoop_Click(object sender, EventArgs e)
        {
            Common.display_status = (int)Common.Display_Status_LIST.DISP_COOP;
            updateForm();
            setDispBtnColor();
        }

        private void btnKei_Click(object sender, EventArgs e)
        {
            Common.display_status = (int)Common.Display_Status_LIST.DISP_KEISUKE;
            updateForm();
            setDispBtnColor();
            Common.display_status = (int)Common.Display_Status_LIST.DISP_COOP;

        }

        private void btnMiki_Click(object sender, EventArgs e)
        {
            Common.display_status = (int)Common.Display_Status_LIST.DISP_MIKI;
            updateForm();
            setDispBtnColor();
            Common.display_status = (int)Common.Display_Status_LIST.DISP_COOP;
        }

        private void setDispBtnColor()
        {
            this.SuspendLayout();
            btnCoop.BackColor = Color.DarkGray;
            btnKei.BackColor  = Color.DarkGray;
            btnMiki.BackColor = Color.DarkGray;

            if(Common.display_status == (int)Common.Display_Status_LIST.DISP_COOP)
            {
                btnCoop.BackColor = Color.LightSeaGreen;
            }
            else if(Common.display_status == (int)Common.Display_Status_LIST.DISP_KEISUKE)
            {
                btnKei.BackColor = Color.LightSeaGreen;
            }
            else if(Common.display_status == (int)Common.Display_Status_LIST.DISP_MIKI)
            {
                btnMiki.BackColor = Color.LightSeaGreen;
            }

            this.ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = "新しいファイル.csv";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = @"E:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            //sfd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            sfd.Filter = "EXCELファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 1;
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(sfd.FileName);

                string filename = sfd.FileName;

                try
                {
                    SqlConnection con = new SqlConnection(com.CON_STR);
                    con.Open();

                    string sqlstr = "";
                    sqlstr = sqlstr + "SELECT Date, Amounts, ISNULL(Detail, '') AS Detail, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName ";
                    sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                    sqlstr = sqlstr + "WHERE MJR.PaymentId = 1 AND Date >=  CONVERT(DATETIME, '2020/01/01')";
                    SqlCommand cmd = new SqlCommand(sqlstr, con);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    // ファイルを開く
                    StreamWriter file = new StreamWriter(filename, false, Encoding.UTF8);
                    file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", "日付", "金額", "内訳", "使用者", "大項目", "中項目"));

                    while (sdr.Read() == true)
                    {
                        string user = (string)sdr["UserName"];
                        string major_name = (string)sdr["MjrItemName"];
                        string medium_name = (string)sdr["MdmItemName"];
                        string detail = (string)sdr["Detail"];
                        DateTime date = (DateTime)sdr["Date"];
                        int amount = (int)sdr["Amounts"];


                        detail = detail.Replace(",", "・");
                        file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", date.ToString("yyyy/MM/dd"), amount, detail, user, major_name, medium_name));
                    }
                    con.Close();
                    file.Close();
                }

                /* 各年度の月ごとで集計
                SELECT DATEPART(YEAR, ttt.Date)  AS NENDO
     , DATEPART(MONTH, ttt.Date) AS TUKI
     , SUM(ttt.Amounts)
FROM  (SELECT Date,
              Amounts, 
              ISNULL(Detail, '') AS Detail,
              UserName,
              MJR.ItemName AS MjrItemName,
              ISNULL(MDM.ItemName, '') AS MdmItemName 
       FROM   (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) 
               LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) 
               LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId 
       WHERE   MJR.PaymentId = 1 
       AND     Date >=  CONVERT(DATETIME, '2020/01/01')) AS ttt
GROUP BY DATEPART(YEAR, ttt.Date)
       , DATEPART(MONTH, ttt.Date)
ORDER BY NENDO, TUKI
*/

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // 例外検出時にエラーメッセージを表示
                }
            }
        }

        private void SummaryYear_Btn_Click(object sender, EventArgs e)
        {
            SummaryYear summary_form = new SummaryYear();
            summary_form.ShowDialog();
        }
    }
}
