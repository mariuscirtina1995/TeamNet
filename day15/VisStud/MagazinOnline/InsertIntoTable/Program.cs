using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertIntoTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source = INTERN2017-12; 
                    Initial Catalog = MagazinOnline;Integrated Security=true";

            //for dispose
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                var CommandText = "";
                var nume = "New_Produs";
                var categorie = 2;
                var pret = 2200;

                new_connection.Open(); //deschide conecsiunea la BD


                //commnad1:
               
                SqlCommand command1 = new SqlCommand();

                command1.Parameters.AddWithValue("@nume", nume);
                command1.Parameters.AddWithValue("@categorie", categorie);
                command1.Parameters.AddWithValue("@pret", pret);
                CommandText = "select count(*) from Produs";

                command1.CommandText = CommandText;
                command1.Connection = new_connection;        //set the connection for the command
               
                var result = Convert.ToInt32(command1.ExecuteScalar());
                Console.WriteLine(string.Format("Command Result: {0}", result));

                //command2:

                SqlCommand command2 = new SqlCommand();
                command2.Parameters.AddWithValue("@nume", nume);
                command2.Parameters.AddWithValue("@categorie", categorie);
                command2.Parameters.AddWithValue("@pret", pret);

                CommandText = "insert into Produs(Nume, CategorieId, Pret) " +
                    "values(@nume, @categorie, @pret)";

                command2.CommandText = CommandText;
                command2.Connection = new_connection;        //set the connection for the command
             
                result = command2.ExecuteNonQuery();
                Console.WriteLine(string.Format("Command Result: {0}", result));

                //execute Command 1
                result = Convert.ToInt32(command1.ExecuteScalar());
                Console.WriteLine(string.Format("Command Result: {0}", result));

            }
            Console.ReadLine();
        }
    }
}
