using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Data.SqlClient;

namespace MoneyManagementSystem
{
    public partial class MajorItemSelect : Form
    {
        private Button[] buttons;
        Common com = new Common();
        public int payment_status = 0;


        public MajorItemSelect()
        {
            InitializeComponent();
        }


        private void MajorItemSelect_Load(object sender, EventArgs e)
        {
            int button_max = 100;
            payment_status = Common.payment_status;

            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT * FROM MajorItem WHERE PaymentId = @payment_status";
                SqlCommand cmd = new SqlCommand(sqlstr, con); ;
                cmd.Parameters.Add(new SqlParameter("@payment_status", payment_status));

                SqlDataReader sdr = cmd.ExecuteReader();

                //ボタンコントロール配列の作成
                this.buttons = new Button[button_max];
                int row_cnt = 0;

                while (sdr.Read() == true)
                {
                    string major_item_name = (string)sdr["ItemName"];

                    //ボタンコントロールのインスタンス作成
                    this.buttons[row_cnt] = new Button();

                    //プロパティ設定
                    this.buttons[row_cnt].Name = "btn" + row_cnt.ToString();
                    //テキスト名はmajorアイテムの名前にする
                    this.buttons[row_cnt].Text = major_item_name;
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
            int item_id = 0;

            
                try
                {
                    SqlConnection con = new SqlConnection(com.CON_STR);
                    con.Open();

                    string sqlstr = "";
                    sqlstr = sqlstr + "SELECT ItemId FROM MajorItem WHERE ItemName = @item_name";
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
                        MessageBox.Show("選択された大項目と関連する中項目が存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

            Input.major_item_id = item_id;

            if (Common.payment_status == (int)Common.Amount_Status_List.SPENDING)
            {
                MediumItemSelect MediumItemSelectForm = new MediumItemSelect();
                
                this.Hide();
                MediumItemSelectForm.ShowDialog();
            }
            else if(Common.payment_status == (int)Common.Amount_Status_List.INCOME || item_id == 29)
            {
                Input.medium_item_id = 0;
                Input.item_name = item_name;

            }
            else
            {
                MessageBox.Show("大項目選択中にエラーが発生しました。\n管理者に確認願います。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
