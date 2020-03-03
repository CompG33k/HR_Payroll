using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Payroll_Library
{
    public class DBHelper
    {
        static readonly string dbConnection = "";
        public static string DBConnection { get { return dbConnection; } }

        public static bool CreateTable(string name)
        {

            return true;
        }
        public static bool CreateDatabase(string name)
        {
            return true;
        }
        public static bool InsertRow(string name)
        {
           // HRDemoDBEntities hrd = new HRDemoDBEntities();
        //    hrd.Benefits.Add(new Employee()))
            return true;
        }
        public static bool RemoveRow(string name)
        {
            return true;
        }
    }
}
