using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_Library
{
    public class DbConnection
    {
        public static string cnnStr
        {
            get
            {
                return "Server=DEVELOOPER; Database=LOG_LIBRARY;uid=sa;pwd=;MultipleActiveResultSets=true";
            }
        }

        public static SqlConnection con
        {
            get
            {
                return new SqlConnection(cnnStr);
            }
        }

        public static SqlCommand GetCommand(string cmdText)
        {
            SqlCommand com = new SqlCommand(cmdText, con);
            return com;
        }
    }
}
