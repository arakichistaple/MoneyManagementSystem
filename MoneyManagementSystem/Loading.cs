using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyManagementSystem
{
    public partial class Loading : Form
    {
        int gif_file_count;
        string gif_folder = @".\..\..\Resources\gifs";

        private Bitmap _image = null;
        private string[] gif_path;
        private int seed = Environment.TickCount;
        Timer timer = new Timer();

        public Loading()
        {
            InitializeComponent();
            getGifList();
            Random rnd = new Random(seed++);

            // 画像ファイルをロードする
            _image = new Bitmap(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, gif_path[rnd.Next(0, gif_path.Length - 1)]));
            // pictureBox1の背景画像としてセット
            pictureBox1.BackgroundImage = _image;

            // 描画(Paint)イベントハンドラを追加
            pictureBox1.Paint += pictureBox1_Paint;
            // アニメーション開始
            ImageAnimator.Animate(_image, new EventHandler(Image_FrameChanged));


            timer.Tick += new EventHandler(OpenMainSystem);
            timer.Interval = 1000;
            timer.Enabled = true; // timer.Start()と同じ

        }

        public void OpenMainSystem(object sender, EventArgs e)
        {
            timer.Enabled = false; // timer.Start()と同じ
            AccountBook accont_book = new AccountBook();
            this.Hide();
            accont_book.ShowDialog();
            this.Close();
        }

        private void getGifList()
        {
            gif_file_count = System.IO.Directory.GetFiles(gif_folder, "*", System.IO.SearchOption.AllDirectories).Length;
            gif_path = new string[gif_file_count];

            gif_path = System.IO.Directory.GetFiles(gif_folder, "*", System.IO.SearchOption.AllDirectories);

        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // イベントハンドラ：ピクチャボックスの描画
            ImageAnimator.UpdateFrames(_image);
        }

        private void Image_FrameChanged(object o, EventArgs e)
        {
            // Paintイベントハンドラを呼び出す
            pictureBox1.Invalidate();
        }
    }
}
