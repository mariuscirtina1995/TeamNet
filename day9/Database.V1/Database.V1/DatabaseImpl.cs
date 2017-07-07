using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.V1
{
    public class DatabaseImpl : IDatabase
    {
        public Dictionary<int, Dosar> Database = new Dictionary<int, Dosar>(); 

        public void Delete(int id)
        {
            Database.Remove(id);
        }

        public Dosar Get(int id)
        {
            if (Database.ContainsKey(id))
                return Database[id];
            else
                return null;
        }

        public void Insert(Dosar entity)
        {
            Database.Add(entity.Id, entity);
        }

        public void Update(Dosar entity)
        {
            Database[entity.Id] = entity;
        }
    }
}
