using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.V2
{
    public class DatabaseImpl : IDatabase
    {

        public Dictionary<Type, Dictionary<int, object>> storageDictionary = new Dictionary<Type, Dictionary<int, object>>();
        public Dictionary<Type, List<object>> storageDictionaryList = new Dictionary<Type, List<object>>();

        //public SortedList<Type, List<Object>> listOfObjects = new SortedList<Type, List<object>>();

        public void Delete<T>(int id)
            where T : IEntity
        {
            if (!storageDictionary.ContainsKey(typeof(T)))
            {
                return;
            }

            var entityDictionary = storageDictionary[typeof(T)];

            if (!entityDictionary.ContainsKey(id))
                return;

            //list dictionary
            //var listEntity = listOfObjects[typeof(T)];
            //listEntity.Remove(entityDictionary[id]);

            var listEntity = storageDictionaryList[typeof(T)];
            listEntity.Remove(entityDictionary[id]);

            entityDictionary.Remove(id);
        }

        public T Get<T>(int id)
            where T : IEntity
        {
            if (!storageDictionary.ContainsKey(typeof(T)))
            {
                return default(T);
            }

            var entityDictionary = storageDictionary[typeof(T)];

            if (!entityDictionary.ContainsKey(id))
                return default(T);

            return (T)entityDictionary[id];
        }

        public IList<T> GetAll<T>()
            where T : IEntity
        {
            //var list = listOfObjects[typeof(T)];
            //return list.Cast<T>().ToList(); //cast all elements to T and create list.

            var list = storageDictionaryList[typeof(T)];
            return list.Cast<T>().ToList();
        }

        public void Insert<T>(T entity)
            where T : IEntity
        {
            if (entity == null)
                throw new ArgumentNullException();

            if (!storageDictionary.ContainsKey(typeof(T)))
            {
                storageDictionary[typeof(T)] = new Dictionary<int, object>();
            }

            var entityDictionary = storageDictionary[typeof(T)];

            if (entityDictionary.ContainsKey(entity.Id))
                throw new DuplicateEntityInDatabaseException("entity");

            entityDictionary.Add(entity.Id, entity);

            //list dictionary
            //if(!listOfObjects.ContainsKey(typeof(T)))
            //    listOfObjects[typeof(T)] = new List<object> ();

            //var listEntity = listOfObjects[typeof(T)];
            //listEntity.Add(entity);

            if (!storageDictionaryList.ContainsKey(typeof(T)))
                storageDictionaryList[typeof(T)] = new List<object>();

            var listEntity = storageDictionaryList[typeof(T)];
            listEntity.Add(entity);
        }

        public void Update<T>(T entity)
            where T : IEntity
        {
            if (!storageDictionary.ContainsKey(typeof(T)))
            {
                return;
            }

            var entityDictionary = storageDictionary[typeof(T)];

            if (!entityDictionary.ContainsKey(entity.Id))
                return;

            entityDictionary[entity.Id] = entity;
          
        }
    }
}
