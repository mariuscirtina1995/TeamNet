using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.V2
{
    public interface IDatabase
    {
        void Insert<T>(T entity)
            where T : IEntity;
        void Update<T>(T entity)
            where T : IEntity;
        void Delete<T>(int id)
            where T : IEntity;
        T Get<T>(int id)
            where T : IEntity;
        IList<T> GetAll<T>()
            where T : IEntity;
    }
}
