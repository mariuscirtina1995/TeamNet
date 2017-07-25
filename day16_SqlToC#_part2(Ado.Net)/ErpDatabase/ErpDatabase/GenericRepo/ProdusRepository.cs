using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ErpDatabase.GenericRepo
{
    public class ProdusRepository : AbstractRepository<Produs>
    {
        SqlConnection connection;
        string deleteSql = @"delete Produs where ProdusId = @id";
        string updateSql = @"update Produs set Nume = @Nume, CategorieId = @categorieId, Pret = @pret where ProdusId = @id";
        string insertSql = @"insert into Produs(Nume, CategorieId, Pret) values (@Nume, @categorieId, @pret); select IDENT_CURRENT('Produs')";
        string getOneSql = @"select ProdusId, Nume, CategorieId, Pret from Produs where ProdusId = @id ";
        string getAllSql = @"select ProdusId, Nume, CategorieId, Pret from Produs ";

        public ProdusRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override void AddInsertParameters(Produs entity, SqlCommand command)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@categorieId", entity.CategorieId);
            command.Parameters.AddWithValue(@"@pret", entity.Pret);
        }

        protected override void AddUpdateParameters(Produs entity, SqlCommand command)
        {
            command.Parameters.AddWithValue(@"@id", entity.Id);
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
            command.Parameters.AddWithValue(@"@categorieId", entity.CategorieId);
            command.Parameters.AddWithValue(@"@pret", entity.Pret);
        }

        protected override string GetALLTextSql()
        {
            return getAllSql;
        }

        protected override string GetDeleteTextSql()
        {
            return deleteSql;
        }

        protected override string GetInsertTextSql()
        {
            return insertSql;
        }

        protected override string GetOneTextSql()
        {
            return getOneSql;
        }

        protected override string GetUpdateTextSql()
        {
            return updateSql;
        }

        protected override Produs ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Produs();

            entity.Id = Convert.ToInt32(reader["ProdusId"]);
            entity.Nume = Convert.ToString(reader["Nume"]);
            entity.CategorieId = Convert.ToInt32(reader["CategorieId"]);
            entity.Pret = Convert.ToInt32(reader["Pret"]);

            return entity;
        }
    }
}
