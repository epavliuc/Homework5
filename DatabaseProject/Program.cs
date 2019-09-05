using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VisualStudio\\Homework5\\DatabaseProject\\CSharpGame.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);
            Game game1 = new Game("Space Invaders", "Mobile Game", "Simple Game", "Average");
            Game game2 = new Game("Testing", "Mobile Game", "Simple Game", "Average");

            //Insert.addValuetoDB(game2, conn);
            Delete.deleteValueDB("Space Invaders", conn);
        }

    }

    class Insert
    {
        public static void addValuetoDB(Game go,SqlConnection connection)
        {
            string insertString = String.Format("INSERT INTO Game(name,game,type_of_game,review) VALUES('{0}','{1}','{2}','{3}')", go.Name, go.Genre, go.Type, go.Review);
            try
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertString, connection);
                insertCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with connection" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    class Delete
    {
        public static void deleteValueDB(string game,SqlConnection connection)
        {
            string deleteString = String.Format("DELETE FROM Game WHERE name='{0}'", game);
            try
            {
                connection.Open();
                SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
                deleteCommand.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Problem with connection" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    

    class Game
    {
        string name = "";
        string genre = "";
        string type = "";
        string review = "";

        public Game(string name, string genre, string type, string review)
        {
            this.name = name;
            this.genre = genre;
            this.type = type;
            this.review = review;
        }

        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Type { get => type; set => type = value; }
        public string Review { get => review; set => review = value; }
    }
}
