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
        public static int payment_status = 0;
        public static int display_status = 0;

        public static string person1 = "けいすけ";
        public static string person2 = "みき";

        public enum Amount_Status_List
        {
            SPENDING = 1,
            INCOME = 2
        }

        public enum Display_Status_LIST
        {
            DISP_KEISUKE = 1,
            DISP_MIKI = 2
        }

        public static string getTodaysYearMonth()
        {
            DateTime dt = DateTime.Now;

            string result = dt.ToString("yyyy年MM月");

            return result;
        }

        /// <summary>
        /// 該当年月の日数を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>DateTime</returns>
        public static int DaysInMonth(DateTime dt)
        {
            return DateTime.DaysInMonth(dt.Year, dt.Month);
        }

        /// <summary>
        /// 月初日を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>Datetime</returns>
        public static DateTime BeginOfMonth(DateTime dt)
        {
            return dt.AddDays((dt.Day - 1) * -1);
        }

        /// <summary>
        /// 月末日を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>DateTime</returns>
        public static DateTime EndOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DaysInMonth(dt));
        }
        


    }
}
