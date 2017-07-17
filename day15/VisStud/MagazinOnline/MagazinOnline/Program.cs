using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source = INTERN2017-12; 
                    Initial Catalog = MagazinOnline;Integrated Security=true";

            var ClientList = new List<Client>();

            //for dispose
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                var clientId = 2;
                SqlCommand new_command = new SqlCommand();

                new_command.CommandText = "select * from Client";

                //new_command.CommandText = "select * from Client where " +
                //                    "ClientId = @id OR Nume = @nume";

                //new_command.CommandText = "select * from d" +
                //    "bo.F_GetComenziCuValoareMinima(@valoare)";

                new_command.Parameters.AddWithValue("@valoare", 2000);
                new_command.Parameters.AddWithValue("@id", clientId);
                new_command.Parameters.AddWithValue("@nume", "Iliescu");

                new_command.Connection = new_connection;        //set the connection for the command
                new_connection.Open(); //deschide conecsiunea la BD

               

                using (SqlDataReader result = new_command.ExecuteReader())
                {
                    
                    while(result.Read())
                    {
                        //Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}"
                        // , result[0], result[1], result[2], result[3], result[4], result[5]));

                        Client client = new Client();
                        client.ClientId = Convert.ToInt32(result[0]);
                        client.Nume = Convert.ToString(result[1]);
                        client.Prenume = Convert.ToString(result[2]);
                        client.CNP = Convert.ToString(result[3]);

                        ClientList.Add(client);

                    }

                }  

            }

            foreach(var client in ClientList)
                Console.WriteLine(string.Format("{0} {1} {2} {3}"
                       , client.ClientId, client.Nume, client.Prenume, client.CNP));

            Console.ReadLine();
        }
    }
}
