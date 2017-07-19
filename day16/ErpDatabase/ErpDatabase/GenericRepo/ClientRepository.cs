using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ErpDatabase.GenericRepo
{
    public class ClientRepository : AbstractRepository<Client>
    {
 
        string deleteSql = @"delete Client where ClientId = @id";
        string updateSql = @"update Client set Nume = @Nume, Prenume = @Prenume, CNP = @CNP where ClientId = @id";
        string insertSql = @"insert into Client(Nume, Prenume, CNP) values (@Nume, @Prenume, @CNP); select IDENT_CURRENT('Client')";
        string getOneSql = @"select ClientID, Nume, Prenume, CNP from Client where ClientId = @id ";
        string getAllSql = @"select ClientID, Nume, Prenume, CNP from Client ";

        public ClientRepository(SqlConnection connection) : base(connection) {}

        protected override Client ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Client();

            entity.Id = Convert.ToInt32(reader["ClientId"]);
            entity.Nume = Convert.ToString(reader["Nume"]);
            entity.Prenume = Convert.ToString(reader["Prenume"]);
            entity.CNP = Convert.ToString(reader["CNP"]);

            return entity;
        }
        
        protected override void AddInsertParameters(Client entity, SqlCommand command)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@Prenume", entity.Prenume);
            command.Parameters.AddWithValue(@"@CNP", entity.CNP);

        }

        protected override void AddUpdateParameters(Client entity, SqlCommand command)
        {
            command.Parameters.AddWithValue(@"@id", entity.Id);
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@Prenume", entity.Prenume);
            command.Parameters.AddWithValue(@"@CNP", entity.CNP);

        }

        protected override string GetInsertTextSql()
        {
            return insertSql;
        }

        protected override string GetUpdateTextSql()
        {
            return updateSql;
        }

        protected override string GetDeleteTextSql()
        {
            return deleteSql;
        }

        protected override string GetOneTextSql()
        {
            return getOneSql;
        }

        protected override string GetALLTextSql()
        {
            return getAllSql;
        }
    }
}
