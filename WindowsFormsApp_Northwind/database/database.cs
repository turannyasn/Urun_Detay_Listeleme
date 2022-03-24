using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Northwind.database
{
     class database
    {
        public static string GetConnectionString
        {
            get { return "Server=ENTRYSRV;Database=NORTHWND;User Id=report;Password=Entry2018."; }
        }
    }
}
