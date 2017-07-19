using ErpDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ErpDatabase.GenericRepo
{
    public class CategorieRepository : AbstractRepository<Categorie>
    {
        string deleteSql = @"delete Categorie where CategorieId = @id";
        string updateSql = @"update Categorie set Nume = @Nume where CategorieId = @id";
        string insertSql = @"insert into Categorie(Nume) values (@Nume); select IDENT_CURRENT('Categorie')";
        string getOneSql = @"select CategorieId, Nume from Categorie where CategorieId = @id ";
        string getAllSql = @"select CategorieId, Nume from Categorie ";

        public CategorieRepository(SqlConnection connection) : base(connection) {}

        protected override void AddInsertParameters(Categorie entity, SqlCommand command)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);
        }

        protected override void AddUpdateParameters(Categorie entity, SqlCommand command)
        {
            command.Parameters.AddWithValue(@"@Nume", entity.Nume);

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

        protected override Categorie ReaderToEntity(SqlDataReader reader)
        {
            var entity = new Categorie();

            entity.Id = Convert.ToInt32(reader["CategorieId"]);
            entity.Nume = Convert.ToString(reader["Nume"]);

            return entity;
        }
    }
}
