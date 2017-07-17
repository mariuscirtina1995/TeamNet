using ErpDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpDatabase.Entities;
using System.Data.SqlClient;

namespace ErpDatabase.RepositoriesImpl
{
    public class ClientRepository : IClientRepository
    {
        string connectionString;

        public ClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Delete(int id)
        {
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@id", id);

                var CommandText = "delete Client where " +
                    "ClientID = @id";

                command.CommandText = CommandText;

                new_connection.Open();

                command.Connection = new_connection;

                command.ExecuteNonQuery();
            }
        }

        public IList<Client> GetAll()
        {
            List<Client> Clientlist = new List<Client>();
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                var CommandText = "select * from Client";

                command.CommandText = CommandText;

                new_connection.Open();

                command.Connection = new_connection;

                using (SqlDataReader result = command.ExecuteReader())
                {

                    while (result.Read())
                    {
                        Client client = new Client();
                        client.ClientId = Convert.ToInt32(result[0]);
                        client.Nume = Convert.ToString(result[1]);
                        client.Prenume = Convert.ToString(result[2]);
                        client.CNP = Convert.ToString(result[3]);

                        Clientlist.Add(client);
                    }

                }
            }

            return Clientlist;
        }

        public Client GetById(int id)
        {
            Client client = new Client();
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                var CommandText = "select * from Client where ClientId = @id";

                command.CommandText = CommandText;
                command.Parameters.AddWithValue("@id", id);
                new_connection.Open();

                command.Connection = new_connection;

                using (SqlDataReader result = command.ExecuteReader())
                {

                    if (result.Read())
                    {

                        client.ClientId = Convert.ToInt32(result[0]);
                        client.Nume = Convert.ToString(result[1]);
                        client.Prenume = Convert.ToString(result[2]);
                        client.CNP = Convert.ToString(result[3]);

                    }
                    else
                        client = null;

                }
            }

            return client;
            
        }

        public int Insert(Client entity)
        {
            int result;
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@nume", entity.Nume);
                command.Parameters.AddWithValue("@prenume", entity.Prenume);
                command.Parameters.AddWithValue("@cnp", entity.CNP);

                var CommandText = "insert into Client(Nume, Prenume, CNP) " +
                    "values(@nume, @prenume, @cnp)";

                command.CommandText = CommandText;

                new_connection.Open();

                command.Connection = new_connection;        

                command.ExecuteNonQuery();

                CommandText = "select max(ClientID) from Client";

                command.CommandText = CommandText;
                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }

        public void Update(Client entity)
        {
            using (SqlConnection new_connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
      
                command.Parameters.AddWithValue("@id", entity.ClientId);
                command.Parameters.AddWithValue("@nume", entity.Nume);
                command.Parameters.AddWithValue("@prenume", entity.Prenume);
                command.Parameters.AddWithValue("@cnp", entity.CNP);

                var CommandText = "update Client " +
                    "set Nume = @nume, Prenume = @prenume, CNP = @cnp " +
                    "where ClientID = @id";

                command.CommandText = CommandText;

                new_connection.Open();

                command.Connection = new_connection;

                command.ExecuteNonQuery();

            }
        }


    }
}
