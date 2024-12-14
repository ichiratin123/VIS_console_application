using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DataBaseSingleTon
    {
        private static DataBaseSingleTon _instance;
        private string connectionString;
        private DataBaseSingleTon()
        {
            connectionString = @"Data Source=dbsys.cs.vsb.cz\STUDENT;Initial Catalog=HUY0018;Persist Security Info=True;User ID=HUY0018;Password=pWvM6F87R06L58Lz;Encrypt=True;TrustServerCertificate=True";
        }
        public static DataBaseSingleTon getInstance() {
            if (_instance == null)
            {
                _instance = new DataBaseSingleTon();
            }
            return _instance;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
