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
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CSharpGame; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            
            SqlConnection conn = new SqlConnection(connectionString);
            Game game1 = new Game("Tetris", "Mobile Game", "Simple Game", "Average");
            string insertString = String.Format("INSERT INTO Game(name,game,type_of_game,review) VALUES('{0}','{1}','{2}','{3}')", game1.Name, game1.Genre, game1.Type, game1.Review);
            
            try
            {
                conn.Open();
                SqlCommand insertCommand = new SqlCommand(insertString,conn);
                
                insertCommand.ExecuteReader();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Problem with connection" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            //SqlCommand selectCommand = new SqlCommand("SELECT * FROM game");
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
