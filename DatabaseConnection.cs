using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultuEspai
{
    public class DatabaseConnection
    { 
        // Cadena de connexió
        private string connectionString = "Server=localhost; Database=espaiCultural; User Id=anna; Password=anna;";


        // Connexió SQL
        private SqlConnection connection;

        // Constructor: inicialitza la connexió
        public DatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
        }

        // Mètode per obtenir la connexió
        public SqlConnection GetConnection()
        {
            return connection;
        }

        // Mètode per obrir la connexió
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Mètode per tancar la connexió
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Mètode per executar una consulta SQL que retorna dades (SELECT)
        public SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }

        // Mètode per executar una comanda SQL que no retorna dades (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }
    }
}
