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

        public const string SONG_DETAILS_TABLE = "song_details";
        public const string USER_TABLE = "user";
        public const string SONG_ASSIGNMENTS = "song_assignment";
        public const string SERVER_DB = "localhost";
        public const string USER_ID_DB = "root";
        public const string PASSWORD_DB = "";
        public const string DATABASE_NAME = "MusicAppDb";

        
        private static MySqlConnection getConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER_DB;
            builder.UserID = USER_ID_DB;
            builder.Password = PASSWORD_DB;
            builder.Database = DATABASE_NAME;

            string connectionString = builder.ToString();
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

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

        public static List<SongDetailsModel> getSongsDetails()
        {
            MySqlConnection dbConnection = getConnection();

            try
            {
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not COnnectet");
                return null;
            }


            String query = $"SELECT * FROM {SONG_DETAILS_TABLE}";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = cmd.ExecuteReader();



            List<SongDetailsModel> songs = new List<SongDetailsModel>();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                String title = (String)reader["title"];
                String author = (String)reader["author"];
                int orginalTempo = (int)reader["orginalTempo"];
                String songUrl = (String)reader["songUrl"];
                songs.Add(new SongDetailsModel() { Id = id, Title = title, Author = author, OrginalTempo = orginalTempo, SongUrl = songUrl});
            }

            dbConnection.Close();
            return songs;

        }

        public static List<UserModel> getStudents()
        {
            MySqlConnection dbConnection = getConnection();

            try
            {
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not COnnectet");
                return null;
            }


            String query = $"SELECT * FROM {USER_TABLE} WHERE role='student'";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = cmd.ExecuteReader();



            List<UserModel> users = new List<UserModel>();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                String firstName = (String)reader["firstName"];
                String lastName = (String)reader["lastName"];

                users.Add(new UserModel() { Id = id, FirstName = firstName, LastName = lastName });
            }

            dbConnection.Close();
            return users;

        }

        public static List<SongAssingnmentModel> getSongAssignments()
        {
            MySqlConnection dbConnection = getConnection();

            try
            {
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not COnnectet");
                return null;
            }


            String query = $"SELECT * FROM {SONG_ASSIGNMENTS}";
            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = cmd.ExecuteReader();



            List<SongAssingnmentModel> songAssignments = new List<SongAssingnmentModel>();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                int userId = (int)reader["userId"];
                int songDestailsId = (int)reader["songDetailsId"];
                int startTempo = (int)reader["startTempo"];
                int destinationTempo = (int)reader["destinationTempo"];


                songAssignments.Add(new SongAssingnmentModel() { Id = id, UserId = userId,  StartTempo = startTempo, DestinationTempo = destinationTempo, SongDetailsId = songDestailsId });
            }

            dbConnection.Close();
            return songAssignments;

        }
    }
}