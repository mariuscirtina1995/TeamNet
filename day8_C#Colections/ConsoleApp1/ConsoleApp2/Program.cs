using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var squareDecorator = new SquareDecorator();
            var rectangleDecorator = new ShapeDecorator<Rectangle>();

            //SquareDecorator.Shape.Length = 2;
            //RectangleDecorator.Shape.Higth = 3;
            //RectangleDecorator.Shape.Width = 5;

            List<ShapeDecorator<IShape>> list = new List<ShapeDecorator<IShape>>();
            var squareDecorator = new ShapeDecorator<Square>();
            list.Add();
            foreach (var decorator in list)
                decorator.Shape.Area = 44;


        }
    }
    //Generic Class
    


}
