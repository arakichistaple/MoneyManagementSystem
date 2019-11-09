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
            this.SuspendLayout();
            // 
            // Amount_TB
            // 
            this.Amount_TB.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Amount_TB.Location = new System.Drawing.Point(18, 68);
            this.Amount_TB.Name = "Amount_TB";
            this.Amount_TB.Size = new System.Drawing.Size(427, 57);
            this.Amount_TB.TabIndex = 0;
            this.Amount_TB.Text = "0";
            this.Amount_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 232);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(427, 57);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // Detail_TB
            // 
            this.Detail_TB.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Detail_TB.Location = new System.Drawing.Point(18, 304);
            this.Detail_TB.Name = "Detail_TB";
            this.Detail_TB.Size = new System.Drawing.Size(427, 41);
            this.Detail_TB.TabIndex = 3;
            this.Detail_TB.Text = "内容を入力";
            // 
            // Save_Btn
            // 
            this.Save_Btn.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Save_Btn.Location = new System.Drawing.Point(18, 411);
            this.Save_Btn.Name = "Save_Btn";
            this.Save_Btn.Size = new System.Drawing.Size(427, 49);
            this.Save_Btn.TabIndex = 4;
            this.Save_Btn.Text = "保存";
            this.Save_Btn.UseVisualStyleBackColor = true;
            this.Save_Btn.Click += new System.EventHandler(this.Save_Btn_Click);
            // 
            // Spending_button
            // 
            this.Spending_button.Location = new System.Drawing.Point(18, 12);
            this.Spending_button.Name = "Spending_button";
            this.Spending_button.Size = new System.Drawing.Size(207, 50);
            this.Spending_button.TabIndex = 5;
            this.Spending_button.Text = "支出";
            this.Spending_button.UseVisualStyleBackColor = true;
            this.Spending_button.Click += new System.EventHandler(this.Spending_button_Click);
            // 
            // Income_Button
            // 
            this.Income_Button.Location = new System.Drawing.Point(249, 12);
            this.Income_Button.Name = "Income_Button";
            this.Income_Button.Size = new System.Drawing.Size(196, 50);
            this.Income_Button.TabIndex = 6;
            this.Income_Button.Text = "収入";
            this.Income_Button.UseVisualStyleBackColor = true;
            this.Income_Button.Click += new System.EventHandler(this.Income_Button_Click);
            // 
            // Item_TB
            // 
            this.Item_TB.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Item_TB.Location = new System.Drawing.Point(18, 155);
            this.Item_TB.Name = "Item_TB";
            this.Item_TB.Size = new System.Drawing.Size(329, 57);
            this.Item_TB.TabIndex = 7;
            // 
            // Item_Select_Button
            // 
            this.Item_Select_Button.Location = new System.Drawing.Point(353, 155);
            this.Item_Select_Button.Name = "Item_Select_Button";
            this.Item_Select_Button.Size = new System.Drawing.Size(92, 57);
            this.Item_Select_Button.TabIndex = 8;
            this.Item_Select_Button.Text = "選択";
            this.Item_Select_Button.UseVisualStyleBackColor = true;
            this.Item_Select_Button.Click += new System.EventHandler(this.Item_Select_Button_Click);
            // 
            // Shared_CB
            // 
            this.Shared_CB.AutoSize = true;
            this.Shared_CB.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Shared_CB.Location = new System.Drawing.Point(18, 367);
            this.Shared_CB.Name = "Shared_CB";
            this.Shared_CB.Size = new System.Drawing.Size(272, 28);
            this.Shared_CB.TabIndex = 9;
            this.Shared_CB.Text = "二人分として換算する";
            this.Shared_CB.UseVisualStyleBackColor = true;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 474);
            this.Controls.Add(this.Shared_CB);
            this.Controls.Add(this.Item_Select_Button);
            this.Controls.Add(this.Item_TB);
            this.Controls.Add(this.Income_Button);
            this.Controls.Add(this.Spending_button);
            this.Controls.Add(this.Save_Btn);
            this.Controls.Add(this.Detail_TB);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Amount_TB);
            this.Name = "Input";
            this.Text = "Input";
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
    }
}