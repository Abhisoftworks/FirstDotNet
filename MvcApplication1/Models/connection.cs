using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class connection
    {
        public static SqlConnection getDetailConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["Details"].ConnectionString; // Read the connection string from the
            SqlConnection con = new SqlConnection(connString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
    }
}