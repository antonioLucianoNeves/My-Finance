using MySql.Data.MySqlClient;
using System.Data;

namespace MyFinance.Util
{
    public class DAL
    {
        private static string server = "localhost";
        private static string database = "financeiro";
        private static string user = "root";
        private static string password = "";
        private static string conectionString = $"Server ={server }; Database={database}; Uid{ user}; Pwd ={password}";
        private MySqlConnection connection;

        public DAL() 
        { 
             connection = new MySqlConnection(conectionString);
             connection.Open();
        }

        //Executa SELECTs
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dataTable);
            return dataTable;
        }
        public void ExecutarComandosSQL (string sql) 
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();  
        }

    }
}
