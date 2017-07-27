using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ShapeDecorator<T> 
        where T : IShape
    {
        public string Description { get; set; }
        public T Shape { get; set; }

    }
}
