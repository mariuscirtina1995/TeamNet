using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Database
    {
        private static readonly Database instance = 
            new Database
            {
                Name = "My database"
            };

        public string Name { get; set; }

        private Database()
        {

        }

        public static Database Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
