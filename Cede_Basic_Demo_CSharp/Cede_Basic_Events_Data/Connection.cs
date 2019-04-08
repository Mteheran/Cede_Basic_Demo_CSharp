using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cede_Basic_Events_Data
{
    public class Connection
    {
        public SqlConnection sqlConnection { get; set; } = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Eventter;Data Source=LAPTOP-GVJH4TIO\SQLEXPRESS;");

        public DataTable GetData(string query)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);            

            sqlConnection.Close();

            return dataTable;
        }
    }
}
