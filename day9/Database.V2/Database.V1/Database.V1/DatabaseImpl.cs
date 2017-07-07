using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.V1
{
    public class DatabaseImpl : IDatabase
    {
        Dictionary<int, Dosar> storage = new Dictionary<int, Dosar>();
        List<Dosar> dosarList = new List<Dosar>();

        public void Delete(int id)
        {
            if (!HasKey(id))
                return;

            dosarList.Remove(storage[id]);
            storage.Remove(id);   
        }

        public Dosar Get(int id)
        {
            if (!HasKey(id))
                return null;

            return storage[id];
        }

        public IList<Dosar> GetAll()
        {
            return dosarList;
        }

        public void Insert(Dosar entity)
        {
            if (null == entity)
                throw new ArgumentNullException("entity");

            if (HasKey(entity.Id))
                throw new DuplicateEntityInDatabaseException(entity.Id);

            storage.Add(entity.Id, entity);
            dosarList.Add(entity);
        }

        public void Update(Dosar entity)
        {
            storage[entity.Id] = entity;
        }

        private bool HasKey(int id)
        {
            return storage.ContainsKey(id);
        }
    }
}
