using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagementSystem
{
    class Common
    {
        public string CON_STR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aceca\Documents\Visual Studio 2015\Projects\MoneyManagementSystem\MoneyManagementSystem\AccountBookDB.mdf;Integrated Security=True";

        public enum Amount_Status_List
        {
            INCOME,
            SPENDING
        }
        public Amount_Status_List Amount_Status;

        public enum Display_Status_LIST
        {
            DISP_KEISUKE = 1,
            DISP_MIKI = 2
        }
    }
}
