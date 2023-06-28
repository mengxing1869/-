using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WinFormsApp3
{
    internal class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=DESKTOP-F7RG910;Initial Catalog=仪器仪表;Integrated Security=True";
            sc = new SqlConnection(str);
            sc.Open();
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close();
        }
    }
}
