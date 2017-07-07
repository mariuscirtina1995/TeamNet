using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.V1
{
    public interface IDatabase
    {
        void Insert(Dosar entity);
        void Update(Dosar entity);
        void Delete(int id);
        Dosar Get(int id);
        IList<Dosar> GetAll();
    }
}
