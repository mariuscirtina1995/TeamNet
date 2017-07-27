using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePatterns.ObjectPool
{
    public class FarfuriiObjectPool : IFarfuriiObjectPool
    {
        private List<Farfurie> available;
        private List<Farfurie> used;
        private IFarfurieFactory farfurieFactory;

        public FarfuriiObjectPool(int maxSize, IFarfurieFactory farfurieFactory)
        {
            available = new List<Farfurie>(maxSize);
            used = new List<Farfurie>(maxSize);
            this.farfurieFactory = farfurieFactory;

            AddMoreObjects(maxSize);
        }

        private void AddMoreObjects(int numberOfObjects)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                var farfurie = farfurieFactory.Create();
                available.Add(farfurie);
            }
        }

        public Farfurie Create()
        {
            if(0 == available.Count)
            {
                //AddMoreObjects(10);
                throw new Exception();
            }

            var farfurie = available[0];

            available.RemoveAt(0);

            used.Add(farfurie);

            return farfurie;
        }

        public void Release(Farfurie current)
        {
            if (!used.Contains(current))
                throw new Exception();

            used.Remove(current);

            available.Add(current);
        }
    }
}
