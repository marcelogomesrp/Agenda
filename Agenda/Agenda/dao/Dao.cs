using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.dao
{
    public class Dao
    {
        String connectionString;

        public Dao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBAgenda"].ToString();
        }


        public void ExecuteNonQuery(String query, List<MySqlParameter> parameters)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Prepare();
                parameters.ForEach(p => command.Parameters.Add(p));
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public DataTable ExecuteReader(String query, List<MySqlParameter> parameters)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Prepare();
                if (parameters != null)
                {
                    parameters.ForEach(p => command.Parameters.Add(p));
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return dataTable;
        }

    }
}
