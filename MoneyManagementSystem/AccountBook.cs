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
    public partial class AccountBook : Form
    {
        Common com = new Common();

        

        public int display_status { get; set; }
        public int payment_status { get; set; }

        public AccountBook()
        {
            InitializeComponent();
            payment_status = (int)Common.Amount_Status_List.INCOME;
        }

        private void KeisukeAccountBook_Load(object sender, EventArgs e)
        {
            initPaymentFigure();
        }

        private void initPaymentFigure()
        {
            try
            {
                SqlConnection con = new SqlConnection(com.CON_STR);
                con.Open();

                string sqlstr = "";
                sqlstr = sqlstr + "SELECT UserName, MJR.ItemName AS MjrItemName, ISNULL(MDM.ItemName, '') AS MdmItemName, ISNULL(Detail, '') AS Detail, Date, Amounts, Share ";
                sqlstr = sqlstr + "FROM (([dbo].[MoneyDetail] AS MD INNER JOIN [dbo].[User] AS U ON MD.UserId = U.UserId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MajorItem] AS MJR ON MD.MajorItemId = MJR.ItemId) ";
                sqlstr = sqlstr + "LEFT JOIN [dbo].[MediumItem] AS MDM ON MD.MediumItemId = MDM.ItemId ";
                sqlstr = sqlstr + "WHERE MD.UserId = @user";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                cmd.Parameters.Add(new SqlParameter("@user", display_status));

                SqlDataReader sdr = cmd.ExecuteReader();

                int row_cnt = 1;
                while (sdr.Read() == true)
                {
                    string user = (string)sdr["UserName"];
                    string major_name = (string)sdr["MjrItemName"];
                    string medium_name = (string)sdr["MdmItemName"];
                    string detail = (string)sdr["Detail"];
                    DateTime date = (DateTime)sdr["Date"];
                    int amount = (int)sdr["Amounts"];
                    bool share = (bool)sdr["Share"];

                    addData(row_cnt, user, major_name, medium_name, detail, date, amount, share);
                    //string user = (string)sdr["model"];

                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(int row_num, string user_name, string major_name, string medium_name, string detail, DateTime date, int amount, bool share)
        {
            dataGridView1.Rows.Add(user_name, major_name, medium_name, detail, date, amount, share);
        }

        private void Spending_Button_Click(object sender, EventArgs e)
        {
            payment_status =(int)Common.Amount_Status_List.SPENDING;
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            payment_status = (int)Common.Amount_Status_List.INCOME;
        }
    }
}
