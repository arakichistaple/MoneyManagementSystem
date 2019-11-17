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
    public partial class StartMenu : Form
    {
        Common com = new Common();

        public StartMenu()
        {
            InitializeComponent();
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
    }
}
