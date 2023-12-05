using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Detail
    {
        SqlConnection con;

        public List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }

        //internal DataTable SaveCategoryDetail(string catdesc, int Active_flg, DateTime crdt, string crdtusr) for inserting data using datatable
        internal string save(string name, string id, DateTime date, string gender) 
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            string str = "";
            using (con = connection.getDetailConnection())
            {
                try
                {                   
                    using (cmd = new SqlCommand("insert into Details values ('" + id + "','"+name+"','"+gender+"','"+date+"')", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        str = cmd.ExecuteNonQuery().ToString();
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    SqlConnection.ClearAllPools();
                }
            }
            
            return str;
        }


    }
}