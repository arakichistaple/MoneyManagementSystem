using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyManagementSystem
{
    public partial class Summary : Form
    {

        Common com = new Common();
        int display_status = 0;
        int row_max = 100;
        DateTime _LookingDate;

        public struct DoughnutData
        {
            public string[] item;
            public int[] item_total_cost;
        }

        private enum Display_Status_LIST
        {
            Major = 1,
            Medium = 2
        }

        private struct TotalAmountDatas
        {
            public int[] item_id;
            public string[] item_name;
            public int[] item_total_cost;
        }

        public Summary()
        {
            InitializeComponent();
            setDisplayStatus((int)Display_Status_LIST.Medium);
            SetLookingDate(AccountBook.LookingDate);
            UpdateAllInfo();
        }

        void UpdateAllInfo()
        {
            setPrevMonthlySpending();
            setCurrentMonthlySpending();
            setMonthlyResultSpending();
            updateForm();
            updateDoughnutGraph();
            setButtonColor();
        }

        private void SetLookingDate(DateTime date)
        {
            _LookingDate = date;
            yearMonth_TB.Text = Common.GetYearMonthStr(_LookingDate);
            

        }

        private void setButtonColor()
        {
            this.SuspendLayout();
            if (display_status == (int)Display_Status_LIST.Major)
            {
                MajorItem_Btn.BackColor = Color.LightSeaGreen;
                MediumItem_Btn.BackColor = Color.DarkGray;
            }
            else if (display_status == (int)Display_Status_LIST.Medium)
            {
                MajorItem_Btn.BackColor = Color.DarkGray;
                MediumItem_Btn.BackColor = Color.LightSeaGreen;
            }
            this.ResumeLayout();
        }

        private void setDisplayStatus(int status)
        {
            display_status = status;
        }

        private void MajorItem_Btn_Click(object sender, EventArgs e)
        {
            setDisplayStatus((int)Display_Status_LIST.Major);
            UpdateAllInfo();
        }

        private void MediumItem_Btn_Click(object sender, EventArgs e)
        {
            setDisplayStatus((int)Display_Status_LIST.Medium);
            UpdateAllInfo();
        }

        private void setPrevMonthlySpending()
        {
            int prev_monthly_spending_result = 0;

            prev_monthly_spending_result = getMonthlySpendingTotal(_LookingDate.AddMonths(-1));

            PrevMonthlySpending_LB.Text = prev_monthly_spending_result.ToString();
        }

        private void setCurrentMonthlySpending()
        {
            int monthly_spending_result = 0;

            monthly_spending_result = getMonthlySpendingTotal(_LookingDate);

            CurrentMonthlySpending_LB.Text = monthly_spending_result.ToString();
        }

        private int getMonthlySpendingTotal(DateTime date)
        {
            int monthly_spending_total = 0;
            DateTime nowYearMonth = date;

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

                sqlstr = sqlstr + "SELECT MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
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

        private void setMonthlyResultSpending()
        {
            int prev_monthly_spending_total = int.Parse(PrevMonthlySpending_LB.Text);
            int current_monthly_spending_total = int.Parse(CurrentMonthlySpending_LB.Text);
            int result = prev_monthly_spending_total - current_monthly_spending_total;

            if (result > 0)
            {
                TotalSpending_LB.ForeColor = Color.LimeGreen;
                TotalSpending_LB.Text = result.ToString();
            }
            else if (result < 0)
            {
                TotalSpending_LB.ForeColor = Color.Crimson;
                TotalSpending_LB.Text = "▲ " + Math.Abs(result).ToString();
            }
            else
            {
                TotalSpending_LB.ForeColor = Color.Black;
                TotalSpending_LB.Text = result.ToString();
            }
        }

        private void updateForm()
        {
            this.SuspendLayout();
            updateSummaryGrid();
        }

        private void updateSummaryGrid()
        {
            clearSummaryGrid();
            setSummaryGrid();
        }
        private void clearSummaryGrid()
        {
            SummaryGrid.Rows.Clear();
        }

        private void setSummaryGrid()
        {
            DateTime nowDate = _LookingDate.Date;  // get only year, month, date
            int item_cnt = 0;
            bool matched = false;

            TotalAmountDatas datas = new TotalAmountDatas()
            {
                item_id = new int[row_max],
                item_name = new string[row_max],
                item_total_cost = new int[row_max]
            };

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                /*
                sqlstr = sqlstr + "SELECT MD.Id AS MdId, MD.MajorItemId AS MjrItemId, MD.MediumItemId AS MdmItemId, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, Amounts ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user AND MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                */
                sqlstr = sqlstr + "SELECT MD.Id AS MdId, MD.MajorItemId AS MjrItemId, MD.MediumItemId AS MdmItemId, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, Amounts ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.payment_status));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", Common.BeginOfMonth(nowDate)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", Common.EndOfMonth(nowDate)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    int id = (int)sdr["MdId"];
                    int major_id = (int)sdr["MjrItemId"];
                    int medium_id = (int)sdr["MdmItemId"];
                    string major_name = (string)sdr["MjrItemName"];
                    string medium_name = (string)sdr["MdmItemName"];
                    int amount = (int)sdr["Amounts"];

                    // itemの集計
                    
                    matched = false;

                    if (display_status == (int)Display_Status_LIST.Major)
                    {
                        for (int i = 0; i < item_cnt; i++)
                        {
                            if (datas.item_id[i] == major_id)
                            {
                                datas.item_total_cost[i] += amount;
                                matched = true;
                            }
                        }

                        if (matched == false)
                        {
                            datas.item_id[item_cnt] = major_id;
                            datas.item_name[item_cnt] = major_name;
                            datas.item_total_cost[item_cnt] = amount;
                            item_cnt++;
                        }
                    }
                    else if (display_status == (int)Display_Status_LIST.Medium)
                    {
                        for (int i = 0; i < item_cnt; i++)
                        {
                            if (datas.item_id[i] == medium_id)
                            {
                                datas.item_total_cost[i] += amount;
                                matched = true;
                            }
                        }

                        if (matched == false)
                        {
                            datas.item_id[item_cnt] = medium_id;
                            datas.item_name[item_cnt] = medium_name;
                            datas.item_total_cost[item_cnt] = amount;
                            item_cnt++;
                        }

                    }


                }
                con.Close();

                addDatas(item_cnt, datas.item_name, datas.item_total_cost);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDatas(int cnt, string[] name, int[] total_cost)
        {
            sortDatas(cnt, ref name, ref total_cost);

            int rank = 1;
            for (int i = 0; i < cnt; i++)
            {
                SummaryGrid.Rows.Add(rank, name[i], total_cost[i]);
                rank++;
            }
        }

        private void sortDatas(int cnt, ref string[] name, ref int[] total_cost)
        {
            // 処理回数を保持する変数です。
            int iterationNum = 0;

            // バブルソートで配列の中身を昇順で並べ替えます。
            for (int i = 0; i < cnt + 1; i++)
            {


                // 要素の比較を行います。最後の要素は外側のループが終了するごとに確定します。
                for (int j = 1; j < cnt - i; j++)
                {
                    // 処理回数の値を増やします。
                    iterationNum++;

                    // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                    if (total_cost[j] > total_cost[j - 1])
                    {

                        // 配列の要素の交換を行います。
                        int temp = total_cost[j];
                        total_cost[j] = total_cost[j - 1];
                        total_cost[j - 1] = temp;

                        string str_temp = name[j];
                        name[j] = name[j - 1];
                        name[j - 1] = str_temp;
                    }
                }

            }

        }

        private void nextMonthBtn_Click(object sender, EventArgs e)
        {

            SetLookingDate(getNowYearMonth().AddMonths(1));
            UpdateAllInfo();
        }

        private void prevMonthBtn_Click(object sender, EventArgs e)
        {
            SetLookingDate(getNowYearMonth().AddMonths(-1));
            UpdateAllInfo();
        }

        private DateTime getNowYearMonth()
        {
            string format = "yyyy年MM月";
            string now_year_month_string = yearMonth_TB.Text;

            return DateTime.ParseExact(now_year_month_string, format, null);
        }

        private void updateDoughnutGraph()
        {
            DoughnutData datas = new DoughnutData()
            {
                item = new string[SummaryGrid.Rows.Count],
                item_total_cost = new int[SummaryGrid.Rows.Count]
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

            //  SummaryGridの一行ずつに対して
            for (int i = 0; i < SummaryGrid.Rows.Count; i++)
            {
                // 既存の項目なら加算、ないなら新規追加
                for (int j = 0; j < item_cnt; j++)
                {
                    // アイテムリストにあれば合計値を加算
                    // if(item[j] == SummaryGrid[i]の名前と一致
                    if (SummaryGrid.Rows[i].Cells[1].Value.ToString() == item[j])
                    {
                        item_total_cost[j] += (int)SummaryGrid.Rows[i].Cells[2].Value;
                        matched = true;
                    }
                }

                // アイテムリストになければ新規アイテムに追加と加算
                if (matched == false)
                {
                    item[item_cnt] = SummaryGrid.Rows[i].Cells[1].Value.ToString();
                    item_total_cost[item_cnt] = (int)SummaryGrid.Rows[i].Cells[2].Value;
                    item_cnt++;
                }

                matched = false;
            }
        }
    }
}
