using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace TestePratico.Infra.Util
{
    public class RepositorioBase
    {
        public  SqlConnection connection;
        //readonly string connectionString = ConfigurationManager.ConnectionStrings["TestePraticoBD"].ConnectionString;

        public RepositorioBase()
        {
            
            connection = new SqlConnection("Data Source=DESKTOP-IIEA0RP;Initial Catalog=TESTEPRATICO;Integrated Security=True");
            
        }
    }
}
