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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountBook));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Back_Btn = new System.Windows.Forms.Button();
            this.Input_Btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Income_Button = new System.Windows.Forms.Button();
            this.Spending_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotaLB = new System.Windows.Forms.Label();
            this.TotalCost_LB = new System.Windows.Forms.Label();
            this.Equal_LB = new System.Windows.Forms.Label();
            this.SpendingCost_LB = new System.Windows.Forms.Label();
            this.Spending_LB = new System.Windows.Forms.Label();
            this.Minus_LB = new System.Windows.Forms.Label();
            this.IncomeCost_LB = new System.Windows.Forms.Label();
            this.Header_Income_LB = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.yearMonth_TB = new System.Windows.Forms.TextBox();
            this.nextMonthBtn = new System.Windows.Forms.Button();
            this.prevMonthBtn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.Back_Btn);
            this.panel1.Controls.Add(this.Input_Btn);
            this.panel1.Location = new System.Drawing.Point(12, 619);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1501, 140);
            this.panel1.TabIndex = 1;
            // 
            // Back_Btn
            // 
            this.Back_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Back_Btn.Font = new System.Drawing.Font("MS UI Gothic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Back_Btn.Location = new System.Drawing.Point(1340, 13);
            this.Back_Btn.Name = "Back_Btn";
            this.Back_Btn.Size = new System.Drawing.Size(158, 111);
            this.Back_Btn.TabIndex = 3;
            this.Back_Btn.Text = "ホームへ\r\n戻る";
            this.Back_Btn.UseVisualStyleBackColor = false;
            this.Back_Btn.Click += new System.EventHandler(this.Back_Btn_Click);
            // 
            // Input_Btn
            // 
            this.Input_Btn.BackColor = System.Drawing.Color.SpringGreen;
            this.Input_Btn.Font = new System.Drawing.Font("MS UI Gothic", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Input_Btn.Location = new System.Drawing.Point(14, 13);
            this.Input_Btn.Name = "Input_Btn";
            this.Input_Btn.Size = new System.Drawing.Size(1320, 111);
            this.Input_Btn.TabIndex = 2;
            this.Input_Btn.Text = "入力画面を表示";
            this.Input_Btn.UseVisualStyleBackColor = false;
            this.Input_Btn.Click += new System.EventHandler(this.Input_Btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(702, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(811, 404);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "項目";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "内容";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "日付";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "金額";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "共有";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "精算状況";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Income_Button
            // 
            this.Income_Button.AutoSize = true;
            this.Income_Button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Income_Button.Location = new System.Drawing.Point(362, 169);
            this.Income_Button.Name = "Income_Button";
            this.Income_Button.Size = new System.Drawing.Size(75, 34);
            this.Income_Button.TabIndex = 3;
            this.Income_Button.Text = "収入";
            this.Income_Button.UseVisualStyleBackColor = true;
            this.Income_Button.Click += new System.EventHandler(this.Income_Button_Click);
            // 
            // Spending_Button
            // 
            this.Spending_Button.AutoSize = true;
            this.Spending_Button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Spending_Button.Location = new System.Drawing.Point(253, 169);
            this.Spending_Button.Name = "Spending_Button";
            this.Spending_Button.Size = new System.Drawing.Size(75, 34);
            this.Spending_Button.TabIndex = 4;
            this.Spending_Button.Text = "支出";
            this.Spending_Button.UseVisualStyleBackColor = true;
            this.Spending_Button.Click += new System.EventHandler(this.Spending_Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.TotaLB);
            this.panel2.Controls.Add(this.TotalCost_LB);
            this.panel2.Controls.Add(this.Equal_LB);
            this.panel2.Controls.Add(this.SpendingCost_LB);
            this.panel2.Controls.Add(this.Spending_LB);
            this.panel2.Controls.Add(this.Minus_LB);
            this.panel2.Controls.Add(this.IncomeCost_LB);
            this.panel2.Controls.Add(this.Header_Income_LB);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1501, 69);
            this.panel2.TabIndex = 5;
            // 
            // TotaLB
            // 
            this.TotaLB.AutoSize = true;
            this.TotaLB.Location = new System.Drawing.Point(834, 6);
            this.TotaLB.Name = "TotaLB";
            this.TotaLB.Size = new System.Drawing.Size(37, 15);
            this.TotaLB.TabIndex = 7;
            this.TotaLB.Text = "収支";
            // 
            // TotalCost_LB
            // 
            this.TotalCost_LB.AutoSize = true;
            this.TotalCost_LB.Location = new System.Drawing.Point(834, 45);
            this.TotalCost_LB.Name = "TotalCost_LB";
            this.TotalCost_LB.Size = new System.Drawing.Size(23, 15);
            this.TotalCost_LB.TabIndex = 6;
            this.TotalCost_LB.Text = "\\0";
            // 
            // Equal_LB
            // 
            this.Equal_LB.AutoSize = true;
            this.Equal_LB.Location = new System.Drawing.Point(785, 45);
            this.Equal_LB.Name = "Equal_LB";
            this.Equal_LB.Size = new System.Drawing.Size(15, 15);
            this.Equal_LB.TabIndex = 5;
            this.Equal_LB.Text = "=";
            // 
            // SpendingCost_LB
            // 
            this.SpendingCost_LB.AutoSize = true;
            this.SpendingCost_LB.Location = new System.Drawing.Point(687, 45);
            this.SpendingCost_LB.Name = "SpendingCost_LB";
            this.SpendingCost_LB.Size = new System.Drawing.Size(23, 15);
            this.SpendingCost_LB.TabIndex = 4;
            this.SpendingCost_LB.Text = "\\0";
            // 
            // Spending_LB
            // 
            this.Spending_LB.AutoSize = true;
            this.Spending_LB.Location = new System.Drawing.Point(687, 6);
            this.Spending_LB.Name = "Spending_LB";
            this.Spending_LB.Size = new System.Drawing.Size(37, 15);
            this.Spending_LB.TabIndex = 3;
            this.Spending_LB.Text = "支出";
            // 
            // Minus_LB
            // 
            this.Minus_LB.AutoSize = true;
            this.Minus_LB.Location = new System.Drawing.Point(604, 45);
            this.Minus_LB.Name = "Minus_LB";
            this.Minus_LB.Size = new System.Drawing.Size(15, 15);
            this.Minus_LB.TabIndex = 2;
            this.Minus_LB.Text = "-";
            // 
            // IncomeCost_LB
            // 
            this.IncomeCost_LB.AutoSize = true;
            this.IncomeCost_LB.Location = new System.Drawing.Point(511, 45);
            this.IncomeCost_LB.Name = "IncomeCost_LB";
            this.IncomeCost_LB.Size = new System.Drawing.Size(23, 15);
            this.IncomeCost_LB.TabIndex = 1;
            this.IncomeCost_LB.Text = "\\0";
            // 
            // Header_Income_LB
            // 
            this.Header_Income_LB.AutoSize = true;
            this.Header_Income_LB.Location = new System.Drawing.Point(511, 6);
            this.Header_Income_LB.Name = "Header_Income_LB";
            this.Header_Income_LB.Size = new System.Drawing.Size(37, 15);
            this.Header_Income_LB.TabIndex = 0;
            this.Header_Income_LB.Text = "収入";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(702, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 23);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "全体";
            // 
            // yearMonth_TB
            // 
            this.yearMonth_TB.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.yearMonth_TB.Location = new System.Drawing.Point(526, 87);
            this.yearMonth_TB.Name = "yearMonth_TB";
            this.yearMonth_TB.Size = new System.Drawing.Size(184, 37);
            this.yearMonth_TB.TabIndex = 7;
            this.yearMonth_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.Image = global::MoneyManagementSystem.Properties.Resources.RightArrow_mini_;
            this.nextMonthBtn.Location = new System.Drawing.Point(716, 86);
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.Size = new System.Drawing.Size(48, 38);
            this.nextMonthBtn.TabIndex = 0;
            this.nextMonthBtn.Click += new System.EventHandler(this.nextMonthBtn_Click);
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevMonthBtn.Image")));
            this.prevMonthBtn.Location = new System.Drawing.Point(471, 86);
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.Size = new System.Drawing.Size(49, 38);
            this.prevMonthBtn.TabIndex = 8;
            this.prevMonthBtn.UseVisualStyleBackColor = true;
            this.prevMonthBtn.Click += new System.EventHandler(this.prevMonthBtn_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 209);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(684, 404);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // AccountBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 771);
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
            this.Name = "AccountBook";
            this.Text = "AccountBook";
            this.Load += new System.EventHandler(this.AccountBook_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
        private System.Windows.Forms.Label Equal_LB;
        private System.Windows.Forms.Label SpendingCost_LB;
        private System.Windows.Forms.Label Spending_LB;
        private System.Windows.Forms.Label Minus_LB;
        private System.Windows.Forms.Label IncomeCost_LB;
        private System.Windows.Forms.Label Header_Income_LB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox yearMonth_TB;
        private System.Windows.Forms.Button nextMonthBtn;
        private System.Windows.Forms.Button prevMonthBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Input_Btn;
        private System.Windows.Forms.Button Back_Btn;
    }
}