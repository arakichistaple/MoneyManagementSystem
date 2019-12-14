namespace MoneyManagementSystem
{
    partial class PayOff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayOff));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name1_LB = new System.Windows.Forms.Label();
            this.Name2_LB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Total1_LB = new System.Windows.Forms.Label();
            this.Total2_LB = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PayOff_Btn = new System.Windows.Forms.Button();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Payer_LB = new System.Windows.Forms.Label();
            this.PayerCost_LB = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prevMonthBtn = new System.Windows.Forms.Button();
            this.nextMonthBtn = new System.Windows.Forms.Button();
            this.yearMonth_TB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(12, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(886, 251);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "項目";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "内容";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "日付";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "金額";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "精算状況";
            this.Column5.Name = "Column5";
            // 
            // Name1_LB
            // 
            this.Name1_LB.AutoSize = true;
            this.Name1_LB.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name1_LB.Location = new System.Drawing.Point(22, 50);
            this.Name1_LB.Name = "Name1_LB";
            this.Name1_LB.Size = new System.Drawing.Size(67, 24);
            this.Name1_LB.TabIndex = 2;
            this.Name1_LB.Text = "label1";
            // 
            // Name2_LB
            // 
            this.Name2_LB.AutoSize = true;
            this.Name2_LB.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name2_LB.Location = new System.Drawing.Point(22, 395);
            this.Name2_LB.Name = "Name2_LB";
            this.Name2_LB.Size = new System.Drawing.Size(67, 24);
            this.Name2_LB.TabIndex = 3;
            this.Name2_LB.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(669, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "合計";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(669, 690);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "合計";
            // 
            // Total1_LB
            // 
            this.Total1_LB.AutoSize = true;
            this.Total1_LB.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Total1_LB.Location = new System.Drawing.Point(831, 343);
            this.Total1_LB.Name = "Total1_LB";
            this.Total1_LB.Size = new System.Drawing.Size(67, 24);
            this.Total1_LB.TabIndex = 6;
            this.Total1_LB.Text = "label5";
            // 
            // Total2_LB
            // 
            this.Total2_LB.AutoSize = true;
            this.Total2_LB.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Total2_LB.Location = new System.Drawing.Point(831, 690);
            this.Total2_LB.Name = "Total2_LB";
            this.Total2_LB.Size = new System.Drawing.Size(67, 24);
            this.Total2_LB.TabIndex = 7;
            this.Total2_LB.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(955, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "支払者";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(1090, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "金額";
            // 
            // PayOff_Btn
            // 
            this.PayOff_Btn.Location = new System.Drawing.Point(1244, 137);
            this.PayOff_Btn.Name = "PayOff_Btn";
            this.PayOff_Btn.Size = new System.Drawing.Size(116, 39);
            this.PayOff_Btn.TabIndex = 10;
            this.PayOff_Btn.Text = "精算";
            this.PayOff_Btn.UseVisualStyleBackColor = true;
            this.PayOff_Btn.Click += new System.EventHandler(this.PayOff_Btn_Click);
            // 
            // Back_Button
            // 
            this.Back_Button.Location = new System.Drawing.Point(1359, 733);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(116, 39);
            this.Back_Button.TabIndex = 11;
            this.Back_Button.Text = "戻る";
            this.Back_Button.UseVisualStyleBackColor = true;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Payer_LB
            // 
            this.Payer_LB.AutoSize = true;
            this.Payer_LB.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Payer_LB.Location = new System.Drawing.Point(955, 142);
            this.Payer_LB.Name = "Payer_LB";
            this.Payer_LB.Size = new System.Drawing.Size(67, 24);
            this.Payer_LB.TabIndex = 12;
            this.Payer_LB.Text = "label8";
            // 
            // PayerCost_LB
            // 
            this.PayerCost_LB.AutoSize = true;
            this.PayerCost_LB.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PayerCost_LB.Location = new System.Drawing.Point(1090, 142);
            this.PayerCost_LB.Name = "PayerCost_LB";
            this.PayerCost_LB.Size = new System.Drawing.Size(67, 24);
            this.PayerCost_LB.TabIndex = 13;
            this.PayerCost_LB.Text = "label8";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column6});
            this.dataGridView2.Location = new System.Drawing.Point(12, 436);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(886, 251);
            this.dataGridView2.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "項目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "内容";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "日付";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "金額";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "精算状況";
            this.Column6.Name = "Column6";
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevMonthBtn.Image")));
            this.prevMonthBtn.Location = new System.Drawing.Point(564, 25);
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.Size = new System.Drawing.Size(49, 38);
            this.prevMonthBtn.TabIndex = 17;
            this.prevMonthBtn.UseVisualStyleBackColor = true;
            this.prevMonthBtn.Click += new System.EventHandler(this.prevMonthBtn_Click);
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.Image = global::MoneyManagementSystem.Properties.Resources.RightArrow_mini_;
            this.nextMonthBtn.Location = new System.Drawing.Point(809, 25);
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.Size = new System.Drawing.Size(48, 38);
            this.nextMonthBtn.TabIndex = 15;
            this.nextMonthBtn.Click += new System.EventHandler(this.nextMonthBtn_Click);
            // 
            // yearMonth_TB
            // 
            this.yearMonth_TB.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.yearMonth_TB.Location = new System.Drawing.Point(619, 26);
            this.yearMonth_TB.Name = "yearMonth_TB";
            this.yearMonth_TB.Size = new System.Drawing.Size(184, 37);
            this.yearMonth_TB.TabIndex = 16;
            this.yearMonth_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PayOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 784);
            this.Controls.Add(this.prevMonthBtn);
            this.Controls.Add(this.nextMonthBtn);
            this.Controls.Add(this.yearMonth_TB);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.PayerCost_LB);
            this.Controls.Add(this.Payer_LB);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.PayOff_Btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Total2_LB);
            this.Controls.Add(this.Total1_LB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Name2_LB);
            this.Controls.Add(this.Name1_LB);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PayOff";
            this.Text = "PayOff";
            this.Load += new System.EventHandler(this.PayOff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Name1_LB;
        private System.Windows.Forms.Label Name2_LB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Total1_LB;
        private System.Windows.Forms.Label Total2_LB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button PayOff_Btn;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Label Payer_LB;
        private System.Windows.Forms.Label PayerCost_LB;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button prevMonthBtn;
        private System.Windows.Forms.Button nextMonthBtn;
        private System.Windows.Forms.TextBox yearMonth_TB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}