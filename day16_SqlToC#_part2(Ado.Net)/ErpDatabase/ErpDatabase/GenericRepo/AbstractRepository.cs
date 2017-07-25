using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.GenericRepo
{
    public abstract class AbstractRepository<T> : IRepository<T>
        where T : IEntity, new()
    {

        //string connectionString;
        SqlConnection connection;


        protected abstract string GetInsertTextSql();
        protected abstract string GetUpdateTextSql();
        protected abstract string GetDeleteTextSql();
        protected abstract string GetOneTextSql();
        protected abstract string GetALLTextSql();

        protected abstract T ReaderToEntity(SqlDataReader reader);
        protected abstract void AddInsertParameters(T entity,  SqlCommand command);
        protected abstract void AddUpdateParameters(T entity, SqlCommand command);

        public AbstractRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        private SqlCommand CreateCommand(string sqlText, SqlConnection connection)
        {
            return new SqlCommand(sqlText, connection);
        }

        public void Delete(T entity)
        {

                using (var command = CreateCommand(GetDeleteTextSql(), connection))
                {
                    command.Parameters.AddWithValue(@"@id", entity.Id); //id param

                    command.ExecuteNonQuery();
                }
            
        }

        public IList<T> GetAll()
        {
            var list = new List<T>();

                using (var command = CreateCommand(GetALLTextSql(), connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(ReaderToEntity(reader));
                        }
                    }
                }

            return list;
        }

        public T GetById(int id)
        {
           
                using (var command = CreateCommand(GetOneTextSql(), connection))
                {
                    command.Parameters.AddWithValue(@"@id", id); //id param

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ReaderToEntity(reader);
                        }
                    }
                }
            
            return default(T);
        }

        public int Insert(T entity)
        {

            if (null == entity)
                throw new ArgumentNullException("entity");

                   
                using (var command = CreateCommand(GetInsertTextSql(), connection))
                {
                    AddInsertParameters(entity, command);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            
        }

        public void Update(T entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");

         
                using (var command = CreateCommand(GetUpdateTextSql(), connection))
                {
                    AddUpdateParameters(entity, command);

                    command.ExecuteNonQuery();
                }
            
        }

    }
}
