using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MoneyManagementSystem
{
    public partial class ChangeMediumItem : Form
    {
        private Button[] buttons;
        Common com = new Common();

        public ChangeMediumItem()
        {
            InitializeComponent();
        }

        private void ChangeMediumItem_Load(object sender, EventArgs e)
        {
            int button_max = 100;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT * FROM MediumItem WHERE MajorItemId = @major_item_id";
                SqlCommand cmd = new SqlCommand(sqlstr, con); ;
                cmd.Parameters.Add(new SqlParameter("@major_item_id", ChangeData.major_item_id));

                SqlDataReader sdr = cmd.ExecuteReader();

                //ボタンコントロール配列の作成
                this.buttons = new Button[button_max];
                int row_cnt = 0;

                while (sdr.Read() == true)
                {
                    string medium_item_name = (string)sdr["ItemName"];

                    //ボタンコントロールのインスタンス作成
                    this.buttons[row_cnt] = new Button();

                    //プロパティ設定
                    this.buttons[row_cnt].Name = "btn" + row_cnt.ToString();
                    //テキスト名はmajorアイテムの名前にする
                    this.buttons[row_cnt].Text = medium_item_name;
                    this.buttons[row_cnt].Top = row_cnt * 50;
                    this.buttons[row_cnt].Size = new Size(this.Size.Width - 35, 50);
                    this.buttons[row_cnt].Padding = new Padding(0);
                    this.buttons[row_cnt].Margin = new Padding(0);

                    this.buttons[row_cnt].Click += new System.EventHandler(btnclick);

                    //コントロールをフォームに追加
                    this.Controls.Add(this.buttons[row_cnt]);

                    row_cnt++;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnclick(object sender, System.EventArgs e)
        {
            // major項目名をここで取得
            Button btn = (Button)sender;
            string item_name = btn.Text;
            ChangeData.item_name = item_name;
            int item_id = 0;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT ItemId FROM MediumItem WHERE ItemName = @item_name";
                SqlCommand cmd = new SqlCommand(sqlstr, con); ;
                cmd.Parameters.Add(new SqlParameter("@item_name", item_name));

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows == true)
                {
                    sdr.Read();
                    item_id = (int)sdr["ItemId"];
                }

                else
                {
                    MessageBox.Show("選択された中項目が存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            ChangeData.medium_item_id = item_id;

            this.Close();
        }
    }
}
