﻿namespace MoneyManagementSystem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Income_Button = new System.Windows.Forms.Button();
            this.Spending_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotaLB = new System.Windows.Forms.Label();
            this.TotalCost_LB = new System.Windows.Forms.Label();
            this.Equal_LB = new System.Windows.Forms.Label();
            this.SpendingCost = new System.Windows.Forms.Label();
            this.Spending_LB = new System.Windows.Forms.Label();
            this.Minus_LB = new System.Windows.Forms.Label();
            this.IncomeCost = new System.Windows.Forms.Label();
            this.Header_Income_LB = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.yearMonth_TB = new System.Windows.Forms.TextBox();
            this.nextMonthBtn = new System.Windows.Forms.Button();
            this.prevMonthBtn = new System.Windows.Forms.Button();
            this.Input_Button = new MoneyManagementSystem.CircularButton();
            this.home_Btn = new MoneyManagementSystem.CircularButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.Input_Button);
            this.panel1.Controls.Add(this.home_Btn);
            this.panel1.Location = new System.Drawing.Point(12, 619);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1501, 140);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(702, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(811, 404);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "項目";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "内容";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "日付";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "金額";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "共有";
            this.Column7.Name = "Column7";
            // 
            // Income_Button
            // 
            this.Income_Button.AutoSize = true;
            this.Income_Button.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Income_Button.Location = new System.Drawing.Point(360, 192);
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
            this.Spending_Button.Location = new System.Drawing.Point(251, 192);
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
            this.panel2.Controls.Add(this.SpendingCost);
            this.panel2.Controls.Add(this.Spending_LB);
            this.panel2.Controls.Add(this.Minus_LB);
            this.panel2.Controls.Add(this.IncomeCost);
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
            // SpendingCost
            // 
            this.SpendingCost.AutoSize = true;
            this.SpendingCost.Location = new System.Drawing.Point(687, 45);
            this.SpendingCost.Name = "SpendingCost";
            this.SpendingCost.Size = new System.Drawing.Size(23, 15);
            this.SpendingCost.TabIndex = 4;
            this.SpendingCost.Text = "\\0";
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
            // IncomeCost
            // 
            this.IncomeCost.AutoSize = true;
            this.IncomeCost.Location = new System.Drawing.Point(511, 45);
            this.IncomeCost.Name = "IncomeCost";
            this.IncomeCost.Size = new System.Drawing.Size(23, 15);
            this.IncomeCost.TabIndex = 1;
            this.IncomeCost.Text = "\\0";
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
            this.yearMonth_TB.Location = new System.Drawing.Point(251, 122);
            this.yearMonth_TB.Name = "yearMonth_TB";
            this.yearMonth_TB.Size = new System.Drawing.Size(184, 37);
            this.yearMonth_TB.TabIndex = 7;
            this.yearMonth_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.Image = global::MoneyManagementSystem.Properties.Resources.RightArrow_mini_;
            this.nextMonthBtn.Location = new System.Drawing.Point(441, 121);
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.Size = new System.Drawing.Size(48, 38);
            this.nextMonthBtn.TabIndex = 0;
            this.nextMonthBtn.Click += new System.EventHandler(this.nextMonthBtn_Click);
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevMonthBtn.Image")));
            this.prevMonthBtn.Location = new System.Drawing.Point(196, 121);
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.Size = new System.Drawing.Size(49, 38);
            this.prevMonthBtn.TabIndex = 8;
            this.prevMonthBtn.UseVisualStyleBackColor = true;
            this.prevMonthBtn.Click += new System.EventHandler(this.prevMonthBtn_Click);
            // 
            // Input_Button
            // 
            this.Input_Button.Location = new System.Drawing.Point(690, 26);
            this.Input_Button.Name = "Input_Button";
            this.Input_Button.Size = new System.Drawing.Size(90, 91);
            this.Input_Button.TabIndex = 1;
            this.Input_Button.Text = "入力";
            this.Input_Button.UseVisualStyleBackColor = true;
            this.Input_Button.Click += new System.EventHandler(this.Input_Button_Click);
            // 
            // home_Btn
            // 
            this.home_Btn.Location = new System.Drawing.Point(88, 26);
            this.home_Btn.Name = "home_Btn";
            this.home_Btn.Size = new System.Drawing.Size(90, 91);
            this.home_Btn.TabIndex = 0;
            this.home_Btn.Text = "Home";
            this.home_Btn.UseVisualStyleBackColor = true;
            this.home_Btn.Click += new System.EventHandler(this.home_Btn_Click);
            // 
            // AccountBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1525, 771);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularButton home_Btn;
        private System.Windows.Forms.Panel panel1;
        private CircularButton Input_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Income_Button;
        private System.Windows.Forms.Button Spending_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TotaLB;
        private System.Windows.Forms.Label TotalCost_LB;
        private System.Windows.Forms.Label Equal_LB;
        private System.Windows.Forms.Label SpendingCost;
        private System.Windows.Forms.Label Spending_LB;
        private System.Windows.Forms.Label Minus_LB;
        private System.Windows.Forms.Label IncomeCost;
        private System.Windows.Forms.Label Header_Income_LB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TextBox yearMonth_TB;
        private System.Windows.Forms.Button nextMonthBtn;
        private System.Windows.Forms.Button prevMonthBtn;
    }
}