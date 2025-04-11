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
            this.Miki_Button = new System.Windows.Forms.Button();
            this.PayOff_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Keisuke_Button
            // 
            this.Keisuke_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Keisuke_Button.Font = new System.Drawing.Font("Segoe Script", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keisuke_Button.Location = new System.Drawing.Point(12, 11);
            this.Keisuke_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Keisuke_Button.Name = "Keisuke_Button";
            this.Keisuke_Button.Size = new System.Drawing.Size(236, 56);
            this.Keisuke_Button.TabIndex = 0;
            this.Keisuke_Button.Text = "KEISUKE\'s\r\n";
            this.Keisuke_Button.UseVisualStyleBackColor = false;
            this.Keisuke_Button.Click += new System.EventHandler(this.Keisuke_Button_Click);
            // 
            // Miki_Button
            // 
            this.Miki_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Miki_Button.Font = new System.Drawing.Font("Segoe Script", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Miki_Button.Location = new System.Drawing.Point(252, 11);
            this.Miki_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Miki_Button.Name = "Miki_Button";
            this.Miki_Button.Size = new System.Drawing.Size(236, 58);
            this.Miki_Button.TabIndex = 3;
            this.Miki_Button.Text = "MIKI\'s\r\n";
            this.Miki_Button.UseVisualStyleBackColor = false;
            this.Miki_Button.Click += new System.EventHandler(this.Miki_Button_Click);
            // 
            // PayOff_Button
            // 
            this.PayOff_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PayOff_Button.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PayOff_Button.Location = new System.Drawing.Point(197, 261);
            this.PayOff_Button.Margin = new System.Windows.Forms.Padding(2);
            this.PayOff_Button.Name = "PayOff_Button";
            this.PayOff_Button.Size = new System.Drawing.Size(105, 52);
            this.PayOff_Button.TabIndex = 4;
            this.PayOff_Button.Text = "精算";
            this.PayOff_Button.UseVisualStyleBackColor = false;
            this.PayOff_Button.Click += new System.EventHandler(this.PayOff_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(540, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 346);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(524, 156);
            this.label2.TabIndex = 5;
            this.label2.Text = "デザインを大幅変更しましたー。\r\n新しい当月の集計機能を実装しています。\r\n内容はその月の消費ランキングを表示できます。\r\n大項目と中項目の切り替えはボタンクリッ" +
    "クでお願いします。\r\n円グラフはまた今度♪\r\n作ってたら12時まわっちゃてたよ　(ノД`)・゜・。ふぁ～～・・・ｚｚｚ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 52);
            this.button1.TabIndex = 9;
            this.button1.Text = "データエクスポート";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(987, 369);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PayOff_Button);
            this.Controls.Add(this.Miki_Button);
            this.Controls.Add(this.Keisuke_Button);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "スタートメニュー";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Keisuke_Button;
        private System.Windows.Forms.Button Miki_Button;
        private System.Windows.Forms.Button PayOff_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

