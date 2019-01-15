using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MusicApp.Models;

namespace MusicApp.Database
{
    public class SqlDatabaseConnection
    {

        public MySqlConnection dbConnection { get; set; }

        

        public SqlDatabaseConnection() {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "MusicAppDb";

            string connectionString = builder.ToString();
            dbConnection = new MySqlConnection(connectionString);

            try
            {
                dbConnection.Open();
                Console.WriteLine("COnnectet");
            }catch(Exception e)
            {
                Console.WriteLine("Not COnnectet");
            }

            
        }

        public List<UserModel> testConnection()
        {
            List<UserModel> users = new List<UserModel>();

            String query = "SELECT * FROM user";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                int id = (int)reader["id"];
                String username = (String)reader["username"];
                String password = (String)reader["password"];
                users.Add(new UserModel(id,username,password));
            }

            return users;
        }
    }
}