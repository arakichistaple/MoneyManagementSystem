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

        public AccountBook()
        {
            InitializeComponent();
            Common.payment_status = (int)Common.Amount_Status_List.SPENDING;
        }

        private void AccountBook_Load(object sender, EventArgs e)
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
                cmd.Parameters.Add(new SqlParameter("@user", Common.display_status));

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read() == true)
                {
                    string user = (string)sdr["UserName"];
                    string major_name = (string)sdr["MjrItemName"];
                    string medium_name = (string)sdr["MdmItemName"];
                    string detail = (string)sdr["Detail"];
                    DateTime date = (DateTime)sdr["Date"];
                    int amount = (int)sdr["Amounts"];
                    bool share = (bool)sdr["Share"];

                    addData(major_name, detail, date, amount, share);
                    //string user = (string)sdr["model"];

                }
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addData(string major_name, string detail, DateTime date, int amount, bool share)
        {
            dataGridView1.Rows.Add(major_name, detail, date, amount, share);
        }

        private void Spending_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status =(int)Common.Amount_Status_List.SPENDING;
        }

        private void Income_Button_Click(object sender, EventArgs e)
        {
            Common.payment_status = (int)Common.Amount_Status_List.INCOME;
        }

        private void gridUpdate()
        {

        }

        private void Input_Button_Click(object sender, EventArgs e)
        {
            Input input_form = new Input();
            input_form.Show();
        }

        
    }
}
