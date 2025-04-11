using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MoneyManagementSystem
{
    public partial class StartMenu : Form
    {
        Common com = new Common();
        int gif_file_count;
        string gif_folder = @".\..\..\Resources\gifs";

        private Bitmap _image = null;
        private string[] gif_path;
        private int seed = Environment.TickCount;

        public StartMenu()
        {
            InitializeComponent();
            backupDatabase();

            getGifList();
            Random rnd = new Random(seed++);

            // 画像ファイルをロードする
            _image = new Bitmap(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, gif_path[rnd.Next(0, gif_path.Length-1)]) );
            // pictureBox1の背景画像としてセット
            pictureBox1.BackgroundImage = _image;

            // 描画(Paint)イベントハンドラを追加
            pictureBox1.Paint += pictureBox1_Paint;
            // アニメーション開始
            ImageAnimator.Animate(_image, new EventHandler(Image_FrameChanged));
        }

        private void getGifList()
        {
            gif_file_count = System.IO.Directory.GetFiles(gif_folder, "*", System.IO.SearchOption.AllDirectories).Length;
            gif_path = new string[gif_file_count];

            gif_path = System.IO.Directory.GetFiles(gif_folder, "*", System.IO.SearchOption.AllDirectories);

        }

        private void Image_FrameChanged(object o, EventArgs e)
        {
            // Paintイベントハンドラを呼び出す
            pictureBox1.Invalidate();
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // イベントハンドラ：ピクチャボックスの描画
            ImageAnimator.UpdateFrames(_image);
        }

        private void Keisuke_Button_Click(object sender, EventArgs e)
        {
            AccountBook keisuke_accont_book = new AccountBook();
            Common.display_status = (int)Common.Display_Status_LIST.DISP_KEISUKE;
            this.Hide();
            keisuke_accont_book.ShowDialog();
            this.Show();
        }

        private void Miki_Button_Click(object sender, EventArgs e)
        {
            AccountBook miki_account_book = new AccountBook();
            Common.display_status = (int)Common.Display_Status_LIST.DISP_MIKI;
            this.Hide();
            miki_account_book.ShowDialog();
            this.Show();
        }

        private void PayOff_Button_Click(object sender, EventArgs e)
        {
            PayOff pay_off_form = new PayOff();
            this.Hide();
            pay_off_form.ShowDialog();
            this.Show();
        }

        private void backupDatabase()
        {
            //バックアップしたいファイルのファイルパスを設定
            string copyfilepath = com.database_path;
            //バックアップしたいファイル名を取得
            string filename = System.IO.Path.GetFileName(copyfilepath);
            //日付を取得
            string d = DateTime.Now.ToString("yyyyMMdd_HHmm");
            //日付のディレクトリの作成
            string backup_directory = string.Format(@"E:\Tools\DatabaseBackup\MoneyManagementSystem\{0}", d);
            //日付を先頭にしてバックアップファイルのパスを作る
            string backupfilepath = string.Format(@"E:\Tools\DatabaseBackup\MoneyManagementSystem\{0}\{1}", d, filename);

            //本日のディレクトリが未作成なら
            if (Directory.Exists(backup_directory) == false)
            {
                Directory.CreateDirectory(backup_directory);
            }

            //本日のバックアップファイルが作成済みなら削除
            if (System.IO.File.Exists(backupfilepath))
                System.IO.File.Delete(backupfilepath);
            //ファイルをコピーしてバックアップ
            System.IO.File.Copy(copyfilepath, backupfilepath);
        }

        private void loopanimation()
        {
            while(true)
            {
                this.SuspendLayout();
                this.ResumeLayout();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loopanimation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = "新しいファイル.csv";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = @"E:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            //sfd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
            sfd.Filter = "EXCELファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 1;
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(sfd.FileName);

                string filename = sfd.FileName;

                /*
                string[] words = new string[] { "りんご", "apple", "みかん", "orange", "バナナ", "banana", "もも", "peach" };
                try
                {
                    // ファイルを開く
                    StreamWriter file = new StreamWriter(filename, false, Encoding.UTF8);

                    for (int i = 0; i < words.Length; i += 2)
                    {
                        file.WriteLine(string.Format("{0},{1}", words[i], words[i + 1]));
                    }
                    file.Close();
                    Console.WriteLine(filename + "に書き込みました。");
                }*/
                try
                {
                    SqlConnection con = new SqlConnection(com.CON_STR);
                    con.Open();

                    string sqlstr = "";
                    sqlstr = sqlstr + "SELECT Date, Amounts, ISNULL(Detail, '') AS Detail, UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName ";
                    sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                    sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                    sqlstr = sqlstr + "WHERE MJR.PaymentId = 1";
                    SqlCommand cmd = new SqlCommand(sqlstr, con);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    // ファイルを開く
                    StreamWriter file = new StreamWriter(filename, false, Encoding.UTF8);
                    file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", "日付", "金額", "内訳", "使用者", "大項目", "中項目"));

                    while (sdr.Read() == true)
                    {
                        string user = (string)sdr["UserName"];
                        string major_name = (string)sdr["MjrItemName"];
                        string medium_name = (string)sdr["MdmItemName"];
                        string detail = (string)sdr["Detail"];
                        DateTime date = (DateTime)sdr["Date"];
                        int amount = (int)sdr["Amounts"];


                        detail = detail.Replace(",", "・");
                        file.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", date.ToString("yyyy/MM/dd"), amount, detail, user, major_name, medium_name));
                    }
                    con.Close();
                    file.Close();
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // 例外検出時にエラーメッセージを表示
                }

            }
        }
    }
}
