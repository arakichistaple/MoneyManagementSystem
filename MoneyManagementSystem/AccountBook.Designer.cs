namespace MoneyManagementSystem
{
    partial class AccountBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountBook));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SummaryYear_Btn = new System.Windows.Forms.Button();
            this.Input_Btn = new System.Windows.Forms.Button();
            this.Summary_Btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Income_Button = new System.Windows.Forms.Button();
            this.Spending_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SavedRatio_LB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalIncludeInvestCost_LB = new System.Windows.Forms.Label();
            this.InvestCost_LB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotaLB = new System.Windows.Forms.Label();
            this.TotalCost_LB = new System.Windows.Forms.Label();
            this.SpendingCost_LB = new System.Windows.Forms.Label();
            this.Spending_LB = new System.Windows.Forms.Label();
            this.IncomeCost_LB = new System.Windows.Forms.Label();
            this.Header_Income_LB = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.yearMonth_TB = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.prevMonthBtn = new System.Windows.Forms.Button();
            this.nextMonthBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMiki = new System.Windows.Forms.Button();
            this.btnKei = new System.Windows.Forms.Button();
            this.btnCoop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.SummaryYear_Btn);
            this.panel1.Controls.Add(this.Input_Btn);
            this.panel1.Controls.Add(this.Summary_Btn);
            this.panel1.Location = new System.Drawing.Point(56, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 41);
            this.panel1.TabIndex = 1;
            // 
            // SummaryYear_Btn
            // 
            this.SummaryYear_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SummaryYear_Btn.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SummaryYear_Btn.Location = new System.Drawing.Point(229, 3);
            this.SummaryYear_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.SummaryYear_Btn.Name = "SummaryYear_Btn";
            this.SummaryYear_Btn.Size = new System.Drawing.Size(110, 34);
            this.SummaryYear_Btn.TabIndex = 5;
            this.SummaryYear_Btn.Text = "年間集計";
            this.SummaryYear_Btn.UseVisualStyleBackColor = false;
            this.SummaryYear_Btn.Click += new System.EventHandler(this.SummaryYear_Btn_Click);
            // 
            // Input_Btn
            // 
            this.Input_Btn.BackColor = System.Drawing.Color.SpringGreen;
            this.Input_Btn.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Input_Btn.Location = new System.Drawing.Point(2, 2);
            this.Input_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Input_Btn.Name = "Input_Btn";
            this.Input_Btn.Size = new System.Drawing.Size(109, 36);
            this.Input_Btn.TabIndex = 2;
            this.Input_Btn.Text = "入力";
            this.Input_Btn.UseVisualStyleBackColor = false;
            this.Input_Btn.Click += new System.EventHandler(this.Input_Btn_Click);
            // 
            // Summary_Btn
            // 
            this.Summary_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Summary_Btn.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Summary_Btn.Location = new System.Drawing.Point(115, 3);
            this.Summary_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Summary_Btn.Name = "Summary_Btn";
            this.Summary_Btn.Size = new System.Drawing.Size(110, 34);
            this.Summary_Btn.TabIndex = 4;
            this.Summary_Btn.Text = "月間集計";
            this.Summary_Btn.UseVisualStyleBackColor = false;
            this.Summary_Btn.Click += new System.EventHandler(this.Summary_Btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column2,
            this.Column1,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(518, 90);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(937, 888);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // Income_Button
            // 
            this.Income_Button.AutoSize = true;
            this.Income_Button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Income_Button.Location = new System.Drawing.Point(238, 90);
            this.Income_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Income_Button.Name = "Income_Button";
            this.Income_Button.Size = new System.Drawing.Size(57, 29);
            this.Income_Button.TabIndex = 3;
            this.Income_Button.Text = "収入";
            this.Income_Button.UseVisualStyleBackColor = true;
            this.Income_Button.Click += new System.EventHandler(this.Income_Button_Click);
            // 
            // Spending_Button
            // 
            this.Spending_Button.AutoSize = true;
            this.Spending_Button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Spending_Button.Location = new System.Drawing.Point(156, 90);
            this.Spending_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Spending_Button.Name = "Spending_Button";
            this.Spending_Button.Size = new System.Drawing.Size(57, 29);
            this.Spending_Button.TabIndex = 4;
            this.Spending_Button.Text = "支出";
            this.Spending_Button.UseVisualStyleBackColor = true;
            this.Spending_Button.Click += new System.EventHandler(this.Spending_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.SavedRatio_LB);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TotalIncludeInvestCost_LB);
            this.panel2.Controls.Add(this.InvestCost_LB);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.TotaLB);
            this.panel2.Controls.Add(this.TotalCost_LB);
            this.panel2.Controls.Add(this.SpendingCost_LB);
            this.panel2.Controls.Add(this.Spending_LB);
            this.panel2.Controls.Add(this.IncomeCost_LB);
            this.panel2.Controls.Add(this.Header_Income_LB);
            this.panel2.Location = new System.Drawing.Point(56, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 92);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "貯蓄率";
            // 
            // SavedRatio_LB
            // 
            this.SavedRatio_LB.Location = new System.Drawing.Point(249, 46);
            this.SavedRatio_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavedRatio_LB.Name = "SavedRatio_LB";
            this.SavedRatio_LB.Size = new System.Drawing.Size(90, 12);
            this.SavedRatio_LB.TabIndex = 12;
            this.SavedRatio_LB.Text = "0.00%";
            this.SavedRatio_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "収支(投資含む)";
            // 
            // TotalIncludeInvestCost_LB
            // 
            this.TotalIncludeInvestCost_LB.Location = new System.Drawing.Point(249, 24);
            this.TotalIncludeInvestCost_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalIncludeInvestCost_LB.Name = "TotalIncludeInvestCost_LB";
            this.TotalIncludeInvestCost_LB.Size = new System.Drawing.Size(90, 12);
            this.TotalIncludeInvestCost_LB.TabIndex = 10;
            this.TotalIncludeInvestCost_LB.Text = "\\0";
            this.TotalIncludeInvestCost_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InvestCost_LB
            // 
            this.InvestCost_LB.Location = new System.Drawing.Point(49, 46);
            this.InvestCost_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InvestCost_LB.Name = "InvestCost_LB";
            this.InvestCost_LB.Size = new System.Drawing.Size(90, 12);
            this.InvestCost_LB.TabIndex = 9;
            this.InvestCost_LB.Text = "\\0";
            this.InvestCost_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "投資額";
            // 
            // TotaLB
            // 
            this.TotaLB.AutoSize = true;
            this.TotaLB.Location = new System.Drawing.Point(162, 4);
            this.TotaLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotaLB.Name = "TotaLB";
            this.TotaLB.Size = new System.Drawing.Size(41, 12);
            this.TotaLB.TabIndex = 7;
            this.TotaLB.Text = "純収支";
            // 
            // TotalCost_LB
            // 
            this.TotalCost_LB.Location = new System.Drawing.Point(249, 4);
            this.TotalCost_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalCost_LB.Name = "TotalCost_LB";
            this.TotalCost_LB.Size = new System.Drawing.Size(90, 12);
            this.TotalCost_LB.TabIndex = 6;
            this.TotalCost_LB.Text = "\\0";
            this.TotalCost_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SpendingCost_LB
            // 
            this.SpendingCost_LB.Location = new System.Drawing.Point(49, 26);
            this.SpendingCost_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SpendingCost_LB.Name = "SpendingCost_LB";
            this.SpendingCost_LB.Size = new System.Drawing.Size(90, 12);
            this.SpendingCost_LB.TabIndex = 4;
            this.SpendingCost_LB.Text = "\\0";
            this.SpendingCost_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Spending_LB
            // 
            this.Spending_LB.AutoSize = true;
            this.Spending_LB.Location = new System.Drawing.Point(9, 26);
            this.Spending_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Spending_LB.Name = "Spending_LB";
            this.Spending_LB.Size = new System.Drawing.Size(29, 12);
            this.Spending_LB.TabIndex = 3;
            this.Spending_LB.Text = "支出";
            // 
            // IncomeCost_LB
            // 
            this.IncomeCost_LB.Location = new System.Drawing.Point(49, 4);
            this.IncomeCost_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IncomeCost_LB.Name = "IncomeCost_LB";
            this.IncomeCost_LB.Size = new System.Drawing.Size(90, 12);
            this.IncomeCost_LB.TabIndex = 1;
            this.IncomeCost_LB.Text = "\\0";
            this.IncomeCost_LB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Header_Income_LB
            // 
            this.Header_Income_LB.AutoSize = true;
            this.Header_Income_LB.Location = new System.Drawing.Point(9, 4);
            this.Header_Income_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Header_Income_LB.Name = "Header_Income_LB";
            this.Header_Income_LB.Size = new System.Drawing.Size(29, 12);
            this.Header_Income_LB.TabIndex = 0;
            this.Header_Income_LB.Text = "収入";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(518, 66);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "全体";
            // 
            // yearMonth_TB
            // 
            this.yearMonth_TB.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.yearMonth_TB.Location = new System.Drawing.Point(833, 13);
            this.yearMonth_TB.Margin = new System.Windows.Forms.Padding(2);
            this.yearMonth_TB.Name = "yearMonth_TB";
            this.yearMonth_TB.Size = new System.Drawing.Size(139, 31);
            this.yearMonth_TB.TabIndex = 7;
            this.yearMonth_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(11, 335);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(503, 323);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevMonthBtn.Image")));
            this.prevMonthBtn.Location = new System.Drawing.Point(792, 12);
            this.prevMonthBtn.Margin = new System.Windows.Forms.Padding(2);
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.Size = new System.Drawing.Size(37, 30);
            this.prevMonthBtn.TabIndex = 8;
            this.prevMonthBtn.UseVisualStyleBackColor = true;
            this.prevMonthBtn.Click += new System.EventHandler(this.prevMonthBtn_Click);
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.Image = global::MoneyManagementSystem.Properties.Resources.RightArrow_mini_;
            this.nextMonthBtn.Location = new System.Drawing.Point(976, 12);
            this.nextMonthBtn.Margin = new System.Windows.Forms.Padding(2);
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.Size = new System.Drawing.Size(36, 30);
            this.nextMonthBtn.TabIndex = 0;
            this.nextMonthBtn.Click += new System.EventHandler(this.nextMonthBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.contextToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // contextToolStripMenuItem
            // 
            this.contextToolStripMenuItem.Name = "contextToolStripMenuItem";
            this.contextToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.contextToolStripMenuItem.Text = "Delete";
            this.contextToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnMiki
            // 
            this.btnMiki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnMiki.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMiki.Location = new System.Drawing.Point(976, 61);
            this.btnMiki.Margin = new System.Windows.Forms.Padding(2);
            this.btnMiki.Name = "btnMiki";
            this.btnMiki.Size = new System.Drawing.Size(71, 25);
            this.btnMiki.TabIndex = 11;
            this.btnMiki.Text = "美紀";
            this.btnMiki.UseVisualStyleBackColor = false;
            this.btnMiki.Visible = false;
            this.btnMiki.Click += new System.EventHandler(this.btnMiki_Click);
            // 
            // btnKei
            // 
            this.btnKei.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKei.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnKei.Location = new System.Drawing.Point(862, 62);
            this.btnKei.Margin = new System.Windows.Forms.Padding(2);
            this.btnKei.Name = "btnKei";
            this.btnKei.Size = new System.Drawing.Size(71, 25);
            this.btnKei.TabIndex = 12;
            this.btnKei.Text = "彗佑";
            this.btnKei.UseVisualStyleBackColor = false;
            this.btnKei.Visible = false;
            this.btnKei.Click += new System.EventHandler(this.btnKei_Click);
            // 
            // btnCoop
            // 
            this.btnCoop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCoop.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCoop.Location = new System.Drawing.Point(758, 62);
            this.btnCoop.Margin = new System.Windows.Forms.Padding(2);
            this.btnCoop.Name = "btnCoop";
            this.btnCoop.Size = new System.Drawing.Size(71, 25);
            this.btnCoop.TabIndex = 13;
            this.btnCoop.Text = "全て";
            this.btnCoop.UseVisualStyleBackColor = false;
            this.btnCoop.Visible = false;
            this.btnCoop.Click += new System.EventHandler(this.btnCoop_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cyan;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(518, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 34);
            this.button1.TabIndex = 14;
            this.button1.Text = "エクセル出力";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column3.FillWeight = 10.6599F;
            this.Column3.HeaderText = "ID";
            this.Column3.MinimumWidth = 2;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 22;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.FillWeight = 104.9756F;
            this.Column5.HeaderText = "日付";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 54;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,0";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.FillWeight = 69.63157F;
            this.Column6.HeaderText = "金額";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 54;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 49.73844F;
            this.Column7.HeaderText = "生活支出";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 96.48959F;
            this.Column2.HeaderText = "大項目";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 91.92103F;
            this.Column1.HeaderText = "中項目";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 194.4074F;
            this.Column4.HeaderText = "内容";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // AccountBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MoneyManagementSystem.Properties.Resources.bg_bu_l;
            this.ClientSize = new System.Drawing.Size(1466, 989);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCoop);
            this.Controls.Add(this.btnKei);
            this.Controls.Add(this.btnMiki);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.prevMonthBtn);
            this.Controls.Add(this.nextMonthBtn);
            this.Controls.Add(this.yearMonth_TB);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Spending_Button);
            this.Controls.Add(this.Income_Button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AccountBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountBook";
            this.Load += new System.EventHandler(this.AccountBook_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Income_Button;
        private System.Windows.Forms.Button Spending_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TotaLB;
        private System.Windows.Forms.Label TotalCost_LB;
        private System.Windows.Forms.Label SpendingCost_LB;
        private System.Windows.Forms.Label Spending_LB;
        private System.Windows.Forms.Label IncomeCost_LB;
        private System.Windows.Forms.Label Header_Income_LB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox yearMonth_TB;
        private System.Windows.Forms.Button nextMonthBtn;
        private System.Windows.Forms.Button prevMonthBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Input_Btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button Summary_Btn;
        private System.Windows.Forms.Button btnMiki;
        private System.Windows.Forms.Button btnKei;
        private System.Windows.Forms.Button btnCoop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SummaryYear_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TotalIncludeInvestCost_LB;
        private System.Windows.Forms.Label InvestCost_LB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SavedRatio_LB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}