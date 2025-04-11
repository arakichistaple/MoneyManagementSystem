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
    public partial class SummaryYear : Form
    {
        Common com = new Common();
        int _LookingYear;

        int _CurAnnualIncome;
        int _CurAnnualSpending;
        int _CurAnnualInvest;
        int _CurAnnualBaseSpend;

        int _PrevAnnualIncome;
        int _PrevAnnualSpending;

        int display_status = 0;
        int row_max = 100;

        private struct IncomeDatas
        {
            public int[] item_id;
            public string[] item_name;
            public int[] item_total_cost;
        }

        private struct SpendingDatas
        {
            public int[] item_id;
            public string[] item_name;
            public int[] item_total_cost;
        }

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

        public SummaryYear()
        {
            InitializeComponent();
        }

        private void SetDisplayStatus(int status)
        {
            display_status = status;
        }
        private void SummaryYear_Load(object sender, EventArgs e)
        {
            SetLookingYear(AccountBook.LookingDate.Year);
            UpdateAllInfo();
            ClearGridSelection();
        }

        /// <summary>
        /// グリッドの初期選択を初期化
        /// </summary>
        private void ClearGridSelection()
        {
            IncomeSummaryGrid.ClearSelection();
            SpendingSummaryGrid.ClearSelection();
            SpendingSubSummaryGrid.ClearSelection();
        }

        private void UpdateAllInfo()
        {
            SetDisplayStatus((int)Display_Status_LIST.Major);
            SetAnnualVals();
            SetAnnualBalance();
            SetYoYIncome();
            SetYoYSpending();
            SetIncomeGrid();
            SetIncomeDoughnutGraph();
            DetailGrid.Rows.Clear();
            SpendingSubSummaryGrid.Rows.Clear();
            SetSpendingGrid();
            SetSpendingDoughnutGraph();

            ClearGridSelection();
        }

        private void SetIncomeDoughnutGraph()
        {
            DoughnutData datas = new DoughnutData()
            {
                item = new string[IncomeSummaryGrid.Rows.Count],
                item_total_cost = new int[IncomeSummaryGrid.Rows.Count]
            };

            getEachItemTotalCost(ref IncomeSummaryGrid, ref datas.item, ref datas.item_total_cost);

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
        }

        private void SetSpendingDoughnutGraph()
        {
            DoughnutData datas = new DoughnutData()
            {
                item = new string[SpendingSummaryGrid.Rows.Count],
                item_total_cost = new int[SpendingSummaryGrid.Rows.Count]
            };

            getEachItemTotalCost(ref SpendingSummaryGrid, ref datas.item, ref datas.item_total_cost);

            // 初期化
            chart2.Series.Clear();
            chart2.Titles.Clear();

            // データの取得
            DataSet ds = GetData(datas);

            // Chartコントロールにデータソースを設定
            chart2.DataSource = ds;

            // Chartコントロールにタイトルを設定
            chart2.Titles.Add("項目別の割合");

            // グラフの種類,系列,軸の設定
            for (int i = 1; i < ds.Tables[0].Columns.Count; i++)
            {
                // 列名の取得
                string columnName = ds.Tables[0].Columns[i].ColumnName;

                // 系列の設定
                chart2.Series.Add(columnName);

                // グラフの種類
                chart2.Series[columnName].ChartType = SeriesChartType.Doughnut;

                // X軸
                chart2.Series[columnName].XValueMember = ds.Tables[0].Columns[0].ColumnName.ToString();
                chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                // Y軸
                chart2.Series[columnName].YValueMembers = columnName;
            }

            // X軸タイトル
            chart2.ChartAreas[0].AxisX.Title = "項目";

            chart2.DataBind();
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

        private void getEachItemTotalCost(ref DataGridView grid, ref string[] item, ref int[] item_total_cost)
        {
            int item_cnt = 0;
            bool matched = false;

            //  SummaryGridの一行ずつに対して
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                // 既存の項目なら加算、ないなら新規追加
                for (int j = 0; j < item_cnt; j++)
                {
                    // アイテムリストにあれば合計値を加算
                    // if(item[j] == SummaryGrid[i]の名前と一致
                    if (grid.Rows[i].Cells[2].Value.ToString() == item[j])
                    {
                        item_total_cost[j] += (int)grid.Rows[i].Cells[3].Value;
                        matched = true;
                    }
                }

                // アイテムリストになければ新規アイテムに追加と加算
                if (matched == false)
                {
                    item[item_cnt] = grid.Rows[i].Cells[2].Value.ToString();
                    item_total_cost[item_cnt] = (int)grid.Rows[i].Cells[3].Value;
                    item_cnt++;
                }

                matched = false;
            }
        }

        private void SetIncomeGrid()
        {
            IncomeSummaryGrid.Rows.Clear();
            int item_cnt = 0;
            bool matched = false;

            IncomeDatas datas = new IncomeDatas()
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

                sqlstr = sqlstr + "SELECT MD.Id AS MdId, MD.MajorItemId AS MjrItemId, MD.MediumItemId AS MdmItemId, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, Amounts ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.INCOME));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(_LookingYear, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(_LookingYear + 1, 1, 1).AddDays(-1)));

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

                addDatas(ref IncomeSummaryGrid, item_cnt, datas.item_id, datas.item_name, datas.item_total_cost);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetSpendingGrid()
        {
            SpendingSummaryGrid.Rows.Clear();
            int item_cnt = 0;
            bool matched = false;

            SpendingDatas datas = new SpendingDatas()
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

                sqlstr = sqlstr + "SELECT MD.Id AS MdId, MD.MajorItemId AS MjrItemId, MD.MediumItemId AS MdmItemId, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, Amounts ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(_LookingYear, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(_LookingYear + 1, 1, 1).AddDays(-1)));

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

                addDatas(ref SpendingSummaryGrid, item_cnt, datas.item_id, datas.item_name, datas.item_total_cost);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDatas(ref DataGridView grid, int cnt, int[] id, string[] name, int[] total_cost)
        {
            sortDatas(cnt, ref id, ref name, ref total_cost);

            int rank = 1;
            for (int i = 0; i < cnt; i++)
            {
                grid.Rows.Add(rank, id[i], name[i], total_cost[i]);
                rank++;
            }
        }

        private void sortDatas(int cnt, ref int[] id, ref string[] name, ref int[] total_cost)
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

                        int temp_id = id[j];
                        id[j] = id[j - 1];
                        id[j - 1] = temp_id;
                    }
                }

            }

        }

        /// <summary>
        /// 前年度（支出）設定
        /// </summary>
        private void SetYoYSpending()
        {
            label20.Text = _CurAnnualSpending.ToString();
            label17.Text = _PrevAnnualSpending.ToString();
            int val = _CurAnnualSpending - _PrevAnnualSpending;

            if (val < 0)
            {
                label24.ForeColor = Color.LimeGreen;
                label24.Text = val.ToString();
            }
            else if (val > 0)
            {
                label24.ForeColor = Color.Crimson;
                label24.Text = "▲ " + Math.Abs(val).ToString();
            }
            else
            {
                label24.ForeColor = Color.Black;
                label24.Text = val.ToString();
            }
        }

        /// <summary>
        /// 前年度（収入）設定
        /// </summary>
        private void SetYoYIncome()
        {
            label6.Text = _CurAnnualIncome.ToString();
            label23.Text = _PrevAnnualIncome.ToString();
            int val = _CurAnnualIncome - _PrevAnnualIncome;

            if (val > 0)
            {
                label15.ForeColor = Color.LimeGreen;
                label15.Text = val.ToString();
            }
            else if (val < 0)
            {
                label15.ForeColor = Color.Crimson;
                label15.Text = "▲ " + Math.Abs(val).ToString();
            }
            else
            {
                label15.ForeColor = Color.Black;
                label15.Text = val.ToString();
            }
        }

        /// <summary>
        /// 年間の各値を設定
        /// </summary>
        private void SetAnnualVals()
        {
            _CurAnnualIncome = GetAnnualIncome(_LookingYear);
            _CurAnnualSpending = GetAnnualSpending(_LookingYear);
            _CurAnnualInvest = GetAnnualInvest(_LookingYear);
            _CurAnnualBaseSpend = GetAnnualBaseSpend(_LookingYear);

            _PrevAnnualIncome = GetAnnualIncome(_LookingYear - 1);
            _PrevAnnualSpending = GetAnnualSpending(_LookingYear - 1);
        }

        /// <summary>
        /// 年間収支設定
        /// </summary>
        private void SetAnnualBalance()
        {
            //収入ラベル
            int income_val = _CurAnnualIncome;
            label28.Text = income_val.ToString();
            label8.Text = income_val.ToString(); ;
            label37.Text = income_val.ToString(); ;

            //支出ラベル
            int spending_val = _CurAnnualSpending;
            label27.Text = spending_val.ToString(); ;
            label11.Text = spending_val.ToString(); ;
            label36.Text = spending_val.ToString(); ;

            //純支出ラベル
            int spending_val2 = _CurAnnualSpending - _CurAnnualInvest;
            label50.Text = spending_val2.ToString();

            //投資額ラベル
            int invest_val = _CurAnnualInvest;
            label26.Text = invest_val.ToString(); ;
            label45.Text = invest_val.ToString(); ;

            //貯蓄率ラベル
            int saved_total = income_val - (spending_val - invest_val);
            float saved_ratio;
            if (saved_total < 0) saved_ratio = 0.0f;
            else saved_ratio = ((float)saved_total / (float)income_val) * 100;
            if (saved_ratio > 0.0f)
            {
                label31.ForeColor = Color.ForestGreen;
                label31.Text = saved_ratio.ToString("F2") + "%";
            }
            else
            {
                label31.ForeColor = Color.Crimson;
                label31.Text = saved_ratio.ToString("F2") + "%";
            }

            //基礎生活費
            int base_spend = _CurAnnualBaseSpend;
            label58.Text = base_spend.ToString();

            //今年度純収支
            int val = _CurAnnualIncome - _CurAnnualSpending;

            if (val > 0)
            {
                label22.ForeColor = Color.LimeGreen;
                label22.Text = val.ToString();
            }
            else if (val < 0)
            {
                label22.ForeColor = Color.Crimson;
                label22.Text = "▲ " + Math.Abs(val).ToString();
            }
            else
            {
                label22.ForeColor = Color.Black;
                label22.Text = val.ToString();
            }

            //今年度収支(投資含む)
            int val2 = _CurAnnualIncome - (_CurAnnualSpending - _CurAnnualInvest);
            if (val2 > 0)
            {
                label35.ForeColor = Color.LimeGreen;
                label35.Text = val2.ToString();
            }
            else if (val2 < 0)
            {
                label35.ForeColor = Color.Crimson;
                label35.Text = "▲ " + Math.Abs(val2).ToString();
            }
            else
            {
                label35.ForeColor = Color.Black;
                label35.Text = val2.ToString();
            }
        }

        /// <summary>
        /// 指定した年の年間収入を取得
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private int GetAnnualIncome(int year)
        {
            int val = 0;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";

                sqlstr = sqlstr + "SELECT MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.INCOME));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(year, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(year + 1, 1, 1).AddDays(-1)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    val += (int)sdr["Amounts"];

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return val;
        }

        /// <summary>
        /// 指定した年の年間支出を取得
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private int GetAnnualSpending(int year)
        {
            int val = 0;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";

                sqlstr = sqlstr + "SELECT MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(year,1,1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(year+1,1,1).AddDays(-1)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    val += (int)sdr["Amounts"];

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return val;
        }

        /// <summary>
        /// 指定した年の年間投資額を取得
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private int GetAnnualInvest(int year)
        {
            int val = 0;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";

                sqlstr = sqlstr + "SELECT MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
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
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(year, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(year + 1, 1, 1).AddDays(-1)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    val += (int)sdr["Amounts"];

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return val;
        }

        /// <summary>
        /// 指定した年の年間基礎生活費を取得
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        private int GetAnnualBaseSpend(int year)
        {
            int val = 0;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";

                sqlstr = sqlstr + "SELECT MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND MD.LivingExpenses = @living_expenses AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
                cmd.Parameters.Add(new SqlParameter("@living_expenses", true));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(year, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(year + 1, 1, 1).AddDays(-1)));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    val += (int)sdr["Amounts"];

                }
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return val;
        }

        /// <summary>
        /// 対象とする年を設定
        /// </summary>
        /// <param name="year"></param>
        private void SetLookingYear(int year)
        {
            _LookingYear = year;
            yearMonth_TB.Text = Common.GetYearStr(_LookingYear);
        }

        /// <summary>
        /// 前の年の情報を表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevYearBtn_Click(object sender, EventArgs e)
        {
            SetLookingYear(_LookingYear - 1);
            UpdateAllInfo();
        }

        /// <summary>
        /// 次の年の情報を表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextYearBtn_Click(object sender, EventArgs e)
        {
            SetLookingYear(_LookingYear + 1);
            UpdateAllInfo();
        }

        private void SpendingSummaryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダ以外のセルか？
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DetailGrid.Rows.Clear();
                SpendingSummaryGrid.Rows[e.RowIndex].Selected = true;
                SpendingSummaryGrid.CurrentCell = SpendingSummaryGrid[2, e.RowIndex];  //item_idを選択
                this.ResumeLayout();
                this.SuspendLayout();
                int id = (int)SpendingSummaryGrid.CurrentRow.Cells[1].Value;  //item_idを選択
                SetSpendingSubGrid(id);
                this.ResumeLayout();
            }
        }

        private void SetSpendingSubGrid(int item_id)
        {
            SpendingSubSummaryGrid.Rows.Clear();
            int item_cnt = 0;
            bool matched = false;

            SpendingDatas datas = new SpendingDatas()
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

                sqlstr = sqlstr + "SELECT MD.Id AS MdId, MD.MajorItemId AS MjrItemId, MD.MediumItemId AS MdmItemId, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, Amounts ";
                sqlstr = sqlstr + "FROM ([dbo].[MoneyDetail] AS MD ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "MJR.ItemId = @itemId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month)";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.Amount_Status_List.SPENDING));
                cmd.Parameters.Add(new SqlParameter("@itemId", item_id));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(_LookingYear, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(_LookingYear + 1, 1, 1).AddDays(-1)));

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
                con.Close();

                addDatas(ref SpendingSubSummaryGrid, item_cnt, datas.item_id, datas.item_name, datas.item_total_cost);
                SpendingSubSummaryGrid.ClearSelection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SpendingSubSummaryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダ以外のセルか？
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                SpendingSubSummaryGrid.Rows[e.RowIndex].Selected = true;
                SpendingSubSummaryGrid.CurrentCell = SpendingSubSummaryGrid[2, e.RowIndex];  //item_idを選択
                this.ResumeLayout();
                this.SuspendLayout();
                int major_id = (int)SpendingSummaryGrid.CurrentRow.Cells[1].Value;  
                int midium_id = (int)SpendingSubSummaryGrid.CurrentRow.Cells[1].Value;  //item_idを選択
                SetDetailGrid(major_id, midium_id);
                this.ResumeLayout();
            }
        }

        private void SetDetailGrid(int major_id, int midium_id)
        {
            DetailGrid.Rows.Clear();
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";

                SqlCommand cmd;
                sqlstr = sqlstr + "SELECT MD.Id AS MdId, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share, PayOff, LivingExpenses ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MJR.PaymentId = @paymentId AND ";
                sqlstr = sqlstr + "MJR.ItemId = @majorId AND ";
                sqlstr = sqlstr + "MDM.ItemId = @midiumId AND ";
                sqlstr = sqlstr + "( MD.Date BETWEEN @begin_of_month AND @end_of_month) ";
                sqlstr = sqlstr + "ORDER BY Amounts DESC";
                cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@paymentId", Common.payment_status));
                cmd.Parameters.Add(new SqlParameter("@majorId", major_id));
                cmd.Parameters.Add(new SqlParameter("@midiumId", midium_id));
                cmd.Parameters.Add(new SqlParameter("@begin_of_month", new DateTime(_LookingYear, 1, 1)));
                cmd.Parameters.Add(new SqlParameter("@end_of_month", new DateTime(_LookingYear + 1, 1, 1).AddDays(-1)));


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

                    addData(date, detail, amount);

                }
                con.Close();
                DetailGrid.ClearSelection();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(DateTime date, string detail, int amount)
        {
            DetailGrid.Rows.Add(date.ToString("yyyy年MM月dd日"), detail, amount);
        }
    }
}
