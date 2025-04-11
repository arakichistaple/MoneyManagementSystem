namespace MoneyManagementSystem
{
    partial class Summary
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary));
            this.SummaryGrid = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotaLB = new System.Windows.Forms.Label();
            this.TotalSpending_LB = new System.Windows.Forms.Label();
            this.Equal_LB = new System.Windows.Forms.Label();
            this.CurrentMonthlySpending_LB = new System.Windows.Forms.Label();
            this.Spending_LB = new System.Windows.Forms.Label();
            this.Minus_LB = new System.Windows.Forms.Label();
            this.PrevMonthlySpending_LB = new System.Windows.Forms.Label();
            this.Header_Income_LB = new System.Windows.Forms.Label();
            this.MajorItem_Btn = new System.Windows.Forms.Button();
            this.MediumItem_Btn = new System.Windows.Forms.Button();
            this.prevMonthBtn = new System.Windows.Forms.Button();
            this.nextMonthBtn = new System.Windows.Forms.Button();
            this.yearMonth_TB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SummaryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SummaryGrid
            // 
            this.SummaryGrid.AllowUserToAddRows = false;
            this.SummaryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SummaryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SummaryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.SummaryGrid.Location = new System.Drawing.Point(575, 124);
            this.SummaryGrid.Name = "SummaryGrid";
            this.SummaryGrid.ReadOnly = true;
            this.SummaryGrid.RowTemplate.Height = 21;
            this.SummaryGrid.Size = new System.Drawing.Size(526, 446);
            this.SummaryGrid.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ランキング";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "項目";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "金額合計";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(11, 85);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(559, 485);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.TotaLB);
            this.panel2.Controls.Add(this.TotalSpending_LB);
            this.panel2.Controls.Add(this.Equal_LB);
            this.panel2.Controls.Add(this.CurrentMonthlySpending_LB);
            this.panel2.Controls.Add(this.Spending_LB);
            this.panel2.Controls.Add(this.Minus_LB);
            this.panel2.Controls.Add(this.PrevMonthlySpending_LB);
            this.panel2.Controls.Add(this.Header_Income_LB);
            this.panel2.Location = new System.Drawing.Point(575, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 55);
            this.panel2.TabIndex = 11;
            // 
            // TotaLB
            // 
            this.TotaLB.AutoSize = true;
            this.TotaLB.Location = new System.Drawing.Point(365, 5);
            this.TotaLB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotaLB.Name = "TotaLB";
            this.TotaLB.Size = new System.Drawing.Size(41, 12);
            this.TotaLB.TabIndex = 7;
            this.TotaLB.Text = "先月比";
            // 
            // TotalSpending_LB
            // 
            this.TotalSpending_LB.AutoSize = true;
            this.TotalSpending_LB.Location = new System.Drawing.Point(365, 36);
            this.TotalSpending_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalSpending_LB.Name = "TotalSpending_LB";
            this.TotalSpending_LB.Size = new System.Drawing.Size(17, 12);
            this.TotalSpending_LB.TabIndex = 6;
            this.TotalSpending_LB.Text = "\\0";
            // 
            // Equal_LB
            // 
            this.Equal_LB.AutoSize = true;
            this.Equal_LB.Location = new System.Drawing.Point(328, 36);
            this.Equal_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Equal_LB.Name = "Equal_LB";
            this.Equal_LB.Size = new System.Drawing.Size(11, 12);
            this.Equal_LB.TabIndex = 5;
            this.Equal_LB.Text = "=";
            // 
            // CurrentMonthlySpending_LB
            // 
            this.CurrentMonthlySpending_LB.AutoSize = true;
            this.CurrentMonthlySpending_LB.Location = new System.Drawing.Point(254, 36);
            this.CurrentMonthlySpending_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentMonthlySpending_LB.Name = "CurrentMonthlySpending_LB";
            this.CurrentMonthlySpending_LB.Size = new System.Drawing.Size(17, 12);
            this.CurrentMonthlySpending_LB.TabIndex = 4;
            this.CurrentMonthlySpending_LB.Text = "\\0";
            // 
            // Spending_LB
            // 
            this.Spending_LB.AutoSize = true;
            this.Spending_LB.Location = new System.Drawing.Point(254, 5);
            this.Spending_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Spending_LB.Name = "Spending_LB";
            this.Spending_LB.Size = new System.Drawing.Size(29, 12);
            this.Spending_LB.TabIndex = 3;
            this.Spending_LB.Text = "今月";
            // 
            // Minus_LB
            // 
            this.Minus_LB.AutoSize = true;
            this.Minus_LB.Location = new System.Drawing.Point(192, 36);
            this.Minus_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Minus_LB.Name = "Minus_LB";
            this.Minus_LB.Size = new System.Drawing.Size(11, 12);
            this.Minus_LB.TabIndex = 2;
            this.Minus_LB.Text = "-";
            // 
            // PrevMonthlySpending_LB
            // 
            this.PrevMonthlySpending_LB.AutoSize = true;
            this.PrevMonthlySpending_LB.Location = new System.Drawing.Point(122, 36);
            this.PrevMonthlySpending_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PrevMonthlySpending_LB.Name = "PrevMonthlySpending_LB";
            this.PrevMonthlySpending_LB.Size = new System.Drawing.Size(17, 12);
            this.PrevMonthlySpending_LB.TabIndex = 1;
            this.PrevMonthlySpending_LB.Text = "\\0";
            // 
            // Header_Income_LB
            // 
            this.Header_Income_LB.AutoSize = true;
            this.Header_Income_LB.Location = new System.Drawing.Point(122, 5);
            this.Header_Income_LB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Header_Income_LB.Name = "Header_Income_LB";
            this.Header_Income_LB.Size = new System.Drawing.Size(29, 12);
            this.Header_Income_LB.TabIndex = 0;
            this.Header_Income_LB.Text = "先月";
            // 
            // MajorItem_Btn
            // 
            this.MajorItem_Btn.BackColor = System.Drawing.SystemColors.Control;
            this.MajorItem_Btn.Font = new System.Drawing.Font("MS UI Gothic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MajorItem_Btn.Location = new System.Drawing.Point(575, 85);
            this.MajorItem_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.MajorItem_Btn.Name = "MajorItem_Btn";
            this.MajorItem_Btn.Size = new System.Drawing.Size(240, 34);
            this.MajorItem_Btn.TabIndex = 8;
            this.MajorItem_Btn.Text = "大項目集計";
            this.MajorItem_Btn.UseVisualStyleBackColor = false;
            this.MajorItem_Btn.Click += new System.EventHandler(this.MajorItem_Btn_Click);
            // 
            // MediumItem_Btn
            // 
            this.MediumItem_Btn.BackColor = System.Drawing.SystemColors.Control;
            this.MediumItem_Btn.Font = new System.Drawing.Font("MS UI Gothic", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MediumItem_Btn.Location = new System.Drawing.Point(853, 85);
            this.MediumItem_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.MediumItem_Btn.Name = "MediumItem_Btn";
            this.MediumItem_Btn.Size = new System.Drawing.Size(240, 34);
            this.MediumItem_Btn.TabIndex = 12;
            this.MediumItem_Btn.Text = "中項目集計";
            this.MediumItem_Btn.UseVisualStyleBackColor = false;
            this.MediumItem_Btn.Click += new System.EventHandler(this.MediumItem_Btn_Click);
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevMonthBtn.Image")));
            this.prevMonthBtn.Location = new System.Drawing.Point(150, 49);
            this.prevMonthBtn.Margin = new System.Windows.Forms.Padding(2);
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.Size = new System.Drawing.Size(37, 30);
            this.prevMonthBtn.TabIndex = 15;
            this.prevMonthBtn.UseVisualStyleBackColor = true;
            this.prevMonthBtn.Click += new System.EventHandler(this.prevMonthBtn_Click);
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.Image = global::MoneyManagementSystem.Properties.Resources.RightArrow_mini_;
            this.nextMonthBtn.Location = new System.Drawing.Point(334, 49);
            this.nextMonthBtn.Margin = new System.Windows.Forms.Padding(2);
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.Size = new System.Drawing.Size(36, 30);
            this.nextMonthBtn.TabIndex = 13;
            this.nextMonthBtn.Click += new System.EventHandler(this.nextMonthBtn_Click);
            // 
            // yearMonth_TB
            // 
            this.yearMonth_TB.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.yearMonth_TB.Location = new System.Drawing.Point(191, 50);
            this.yearMonth_TB.Margin = new System.Windows.Forms.Padding(2);
            this.yearMonth_TB.Name = "yearMonth_TB";
            this.yearMonth_TB.Size = new System.Drawing.Size(139, 31);
            this.yearMonth_TB.TabIndex = 14;
            this.yearMonth_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MoneyManagementSystem.Properties.Resources.bg_bu_r;
            this.ClientSize = new System.Drawing.Size(1113, 582);
            this.Controls.Add(this.prevMonthBtn);
            this.Controls.Add(this.nextMonthBtn);
            this.Controls.Add(this.yearMonth_TB);
            this.Controls.Add(this.MediumItem_Btn);
            this.Controls.Add(this.MajorItem_Btn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.SummaryGrid);
            this.Name = "Summary";
            this.Text = "Summary";
            ((System.ComponentModel.ISupportInitialize)(this.SummaryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SummaryGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TotaLB;
        private System.Windows.Forms.Label TotalSpending_LB;
        private System.Windows.Forms.Label Equal_LB;
        private System.Windows.Forms.Label CurrentMonthlySpending_LB;
        private System.Windows.Forms.Label Spending_LB;
        private System.Windows.Forms.Label Minus_LB;
        private System.Windows.Forms.Label PrevMonthlySpending_LB;
        private System.Windows.Forms.Label Header_Income_LB;
        private System.Windows.Forms.Button MajorItem_Btn;
        private System.Windows.Forms.Button MediumItem_Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button prevMonthBtn;
        private System.Windows.Forms.Button nextMonthBtn;
        private System.Windows.Forms.TextBox yearMonth_TB;
    }
}