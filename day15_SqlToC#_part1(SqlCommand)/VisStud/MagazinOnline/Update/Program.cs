using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
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
                var clientId = 2;
                var prenume = "Robert22";
                SqlCommand new_command = new SqlCommand();

                new_command.CommandText = "update Client set Prenume = @prenume where ClientId = @id";

                new_command.Parameters.AddWithValue("@prenume", prenume);
                new_command.Parameters.AddWithValue("@id", clientId);

                new_command.Connection = new_connection;        //set the connection for the command
                new_connection.Open(); //deschide conecsiunea la BD

                var result = new_command.ExecuteNonQuery();
                Console.WriteLine(string.Format("Rows Affected: {0}", result));

            }
            Console.ReadLine();
        }
    }
}
