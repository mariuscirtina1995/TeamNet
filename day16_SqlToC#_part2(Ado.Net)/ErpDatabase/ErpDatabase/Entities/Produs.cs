using ErpDatabase.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Produs : IEntity
    {
        public int Id { get; set; }

        public string Nume { get; set; }

        public int CategorieId { get; set; }

        public int Pret { get; set; }

    }
}
