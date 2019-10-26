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
    public partial class Input : Form
    {
        Common com = new Common();
        public static string item_name = "";

        public Input()
        {
            InitializeComponent();
        }

        private void Item_Select_Button_Click(object sender, EventArgs e)
        {
            MajorItemSelect MajorItemSelectForm = new MajorItemSelect();
            MajorItemSelectForm.ShowDialog();
            Item_TB.Text = item_name;
            this.PerformLayout();
            MajorItemSelectForm.Dispose();
        }
    }
}
