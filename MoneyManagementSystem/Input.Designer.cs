namespace MoneyManagementSystem
{
    partial class Input
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
            this.Amount_TB = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Detail_TB = new System.Windows.Forms.TextBox();
            this.Save_Btn = new System.Windows.Forms.Button();
            this.Spending_button = new System.Windows.Forms.Button();
            this.Income_Button = new System.Windows.Forms.Button();
            this.Item_TB = new System.Windows.Forms.TextBox();
            this.Item_Select_Button = new System.Windows.Forms.Button();
            this.Shared_CB = new System.Windows.Forms.CheckBox();
            this.chkKei = new System.Windows.Forms.CheckBox();
            this.chkMiki = new System.Windows.Forms.CheckBox();
            this.chkLivingExpenses = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Amount_TB
            // 
            this.Amount_TB.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Amount_TB.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Amount_TB.Location = new System.Drawing.Point(14, 54);
            this.Amount_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Amount_TB.Name = "Amount_TB";
            this.Amount_TB.Size = new System.Drawing.Size(321, 47);
            this.Amount_TB.TabIndex = 2;
            this.Amount_TB.Text = "0";
            this.Amount_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount_TB.Click += new System.EventHandler(this.Amount_TB_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePicker1.Location = new System.Drawing.Point(14, 186);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(321, 47);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // Detail_TB
            // 
            this.Detail_TB.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Detail_TB.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Detail_TB.Location = new System.Drawing.Point(14, 243);
            this.Detail_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Detail_TB.Name = "Detail_TB";
            this.Detail_TB.Size = new System.Drawing.Size(321, 34);
            this.Detail_TB.TabIndex = 5;
            this.Detail_TB.Text = "内容を入力";
            // 
            // Save_Btn
            // 
            this.Save_Btn.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Save_Btn.Location = new System.Drawing.Point(14, 329);
            this.Save_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(320, 39);
            this.Save_Btn.TabIndex = 9;
            this.Save_Btn.Text = "保存";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Spending_button
            // 
            this.Spending_button.Location = new System.Drawing.Point(14, 10);
            this.Spending_button.Margin = new System.Windows.Forms.Padding(2);
            this.Spending_button.Name = "Spending_button";
            this.Spending_button.Size = new System.Drawing.Size(155, 40);
            this.Spending_button.TabIndex = 0;
            this.Spending_button.Text = "支出";
            this.Spending_button.UseVisualStyleBackColor = true;
            this.Spending_button.Click += new System.EventHandler(this.Spending_button_Click);
            // 
            // Income_Button
            // 
            this.Income_Button.Location = new System.Drawing.Point(187, 10);
            this.Income_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Income_Button.Name = "Income_Button";
            this.Income_Button.Size = new System.Drawing.Size(147, 40);
            this.Income_Button.TabIndex = 1;
            this.Income_Button.Text = "収入";
            this.Income_Button.UseVisualStyleBackColor = true;
            this.Income_Button.Click += new System.EventHandler(this.Income_Button_Click);
            // 
            // Item_TB
            // 
            this.Item_TB.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Item_TB.Location = new System.Drawing.Point(14, 124);
            this.Item_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Item_TB.Name = "Item_TB";
            this.Item_TB.Size = new System.Drawing.Size(248, 47);
            this.Item_TB.TabIndex = 7;
            this.Item_TB.TabStop = false;
            // 
            // Item_Select_Button
            // 
            this.Item_Select_Button.Location = new System.Drawing.Point(265, 124);
            this.Item_Select_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Item_Select_Button.Name = "Item_Select_Button";
            this.Item_Select_Button.Size = new System.Drawing.Size(69, 46);
            this.Item_Select_Button.TabIndex = 3;
            this.Item_Select_Button.Text = "選択";
            this.Item_Select_Button.UseVisualStyleBackColor = true;
            this.Item_Select_Button.Click += new System.EventHandler(this.Item_Select_Button_Click);
            // 
            // Shared_CB
            // 
            this.Shared_CB.AutoSize = true;
            this.Shared_CB.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Shared_CB.Location = new System.Drawing.Point(14, 97);
            this.Shared_CB.Margin = new System.Windows.Forms.Padding(2);
            this.Shared_CB.Name = "Shared_CB";
            this.Shared_CB.Size = new System.Drawing.Size(228, 23);
            this.Shared_CB.TabIndex = 9;
            this.Shared_CB.Text = "二人分として換算する";
            this.Shared_CB.UseVisualStyleBackColor = true;
            this.Shared_CB.Visible = false;
            // 
            // chkKei
            // 
            this.chkKei.AutoSize = true;
            this.chkKei.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkKei.Location = new System.Drawing.Point(87, 292);
            this.chkKei.Margin = new System.Windows.Forms.Padding(2);
            this.chkKei.Name = "chkKei";
            this.chkKei.Size = new System.Drawing.Size(68, 23);
            this.chkKei.TabIndex = 6;
            this.chkKei.Text = "彗佑";
            this.chkKei.UseVisualStyleBackColor = true;
            this.chkKei.CheckedChanged += new System.EventHandler(this.chkKei_CheckedChanged);
            // 
            // chkMiki
            // 
            this.chkMiki.AutoSize = true;
            this.chkMiki.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkMiki.Location = new System.Drawing.Point(205, 292);
            this.chkMiki.Margin = new System.Windows.Forms.Padding(2);
            this.chkMiki.Name = "chkMiki";
            this.chkMiki.Size = new System.Drawing.Size(68, 23);
            this.chkMiki.TabIndex = 7;
            this.chkMiki.Text = "美紀";
            this.chkMiki.UseVisualStyleBackColor = true;
            this.chkMiki.CheckedChanged += new System.EventHandler(this.chkMiki_CheckedChanged);
            // 
            // chkLivingExpenses
            // 
            this.chkLivingExpenses.AutoSize = true;
            this.chkLivingExpenses.Checked = true;
            this.chkLivingExpenses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLivingExpenses.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkLivingExpenses.Location = new System.Drawing.Point(114, 292);
            this.chkLivingExpenses.Margin = new System.Windows.Forms.Padding(2);
            this.chkLivingExpenses.Name = "chkLivingExpenses";
            this.chkLivingExpenses.Size = new System.Drawing.Size(128, 23);
            this.chkLivingExpenses.TabIndex = 8;
            this.chkLivingExpenses.Text = "基礎生活費";
            this.chkLivingExpenses.UseVisualStyleBackColor = true;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 379);
            this.Controls.Add(this.chkLivingExpenses);
            this.Controls.Add(this.chkMiki);
            this.Controls.Add(this.chkKei);
            this.Controls.Add(this.Shared_CB);
            this.Controls.Add(this.Item_Select_Button);
            this.Controls.Add(this.Item_TB);
            this.Controls.Add(this.Income_Button);
            this.Controls.Add(this.Spending_button);
            this.Controls.Add(this.Save_Btn);
            this.Controls.Add(this.Detail_TB);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Amount_TB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Input";
            this.Text = "Input";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Input_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Amount_TB;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox Detail_TB;
        private System.Windows.Forms.Button Save_Btn;
        private System.Windows.Forms.Button Spending_button;
        private System.Windows.Forms.Button Income_Button;
        private System.Windows.Forms.TextBox Item_TB;
        private System.Windows.Forms.Button Item_Select_Button;
        private System.Windows.Forms.CheckBox Shared_CB;
        private System.Windows.Forms.CheckBox chkKei;
        private System.Windows.Forms.CheckBox chkMiki;
        private System.Windows.Forms.CheckBox chkLivingExpenses;
    }
}