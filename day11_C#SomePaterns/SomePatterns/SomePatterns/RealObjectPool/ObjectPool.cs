using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.RealObjectPool
{
    public class ObjectPool<T> : IObjectPool<T>
        where T: new()
    {

        private List<T> available;
        private List<T> used;
        private IObjectFactory<T> objectFactory; 

        public ObjectPool(int maxSize, IObjectFactory<T> objectFactory)
        {
            available = new List<T>(maxSize);
            used = new List<T>(maxSize);
            this.objectFactory = objectFactory;

            AddMoreObjects(maxSize);
        }

        private void AddMoreObjects(int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var createdObj = objectFactory.Create(new T());
                available.Add(createdObj);
            }
        }

        public T Create()
        {
            if (0 == available.Count)
            {
                //AddMoreObjects(10);
                throw new Exception();
            }

            var obj = available[0];

            available.RemoveAt(0);

            used.Add(obj);

            return obj;
        }

        public void Release(T someObj)
        {
            if (!used.Contains(someObj))
                throw new Exception();

            used.Remove(someObj);

            available.Add(someObj);
        }


    }
}
