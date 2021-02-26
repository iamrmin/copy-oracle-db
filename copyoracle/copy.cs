using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace copyoracle
{

    class copy
    {
        public static string duname;
        public static string dpwd;

        public static string suname;
        public static string spwd;
        
        public string sconstr
        {
            get
            {
                return "Data Source=student;User ID=" + suname + "; password =" + spwd + ";Unicode=True";
            }
        }

        public string dconstr
        {
            get
            {
                return "Data Source=student;User ID=" + duname + "; password =" + dpwd + ";Unicode=True";
            }
        }

    }
}
