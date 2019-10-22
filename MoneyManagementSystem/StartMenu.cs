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
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Keisuke_Button_Click(object sender, EventArgs e)
        {
            KeisukeAccountBook keisuke_accont_book = new KeisukeAccountBook();
            keisuke_accont_book.Show();
        }
    }
}
