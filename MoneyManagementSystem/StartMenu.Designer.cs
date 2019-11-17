namespace MoneyManagementSystem
{
    partial class StartMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Keisuke_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Miki_Button = new System.Windows.Forms.Button();
            this.PayOff_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Keisuke_Button
            // 
            this.Keisuke_Button.Font = new System.Drawing.Font("Segoe Script", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keisuke_Button.Location = new System.Drawing.Point(104, 163);
            this.Keisuke_Button.Name = "Keisuke_Button";
            this.Keisuke_Button.Size = new System.Drawing.Size(328, 301);
            this.Keisuke_Button.TabIndex = 0;
            this.Keisuke_Button.Text = "KEISUKE\'s\r\n";
            this.Keisuke_Button.UseVisualStyleBackColor = true;
            this.Keisuke_Button.Click += new System.EventHandler(this.Keisuke_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(854, 105);
            this.label1.TabIndex = 2;
            this.label1.Text = "MoneyManagementSystem";
            // 
            // Miki_Button
            // 
            this.Miki_Button.Font = new System.Drawing.Font("Segoe Script", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Miki_Button.Location = new System.Drawing.Point(544, 163);
            this.Miki_Button.Name = "Miki_Button";
            this.Miki_Button.Size = new System.Drawing.Size(328, 301);
            this.Miki_Button.TabIndex = 3;
            this.Miki_Button.Text = "MIKI\'s\r\n";
            this.Miki_Button.UseVisualStyleBackColor = true;
            this.Miki_Button.Click += new System.EventHandler(this.Miki_Button_Click);
            // 
            // PayOff_Button
            // 
            this.PayOff_Button.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PayOff_Button.Location = new System.Drawing.Point(104, 484);
            this.PayOff_Button.Name = "PayOff_Button";
            this.PayOff_Button.Size = new System.Drawing.Size(768, 94);
            this.PayOff_Button.TabIndex = 4;
            this.PayOff_Button.Text = "精算";
            this.PayOff_Button.UseVisualStyleBackColor = true;
            this.PayOff_Button.Click += new System.EventHandler(this.PayOff_Button_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 622);
            this.Controls.Add(this.PayOff_Button);
            this.Controls.Add(this.Miki_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Keisuke_Button);
            this.Name = "StartMenu";
            this.Text = "スタートメニュー";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Keisuke_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Miki_Button;
        private System.Windows.Forms.Button PayOff_Button;
    }
}

