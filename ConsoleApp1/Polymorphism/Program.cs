using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    //overloading
    class Shape
    {
        internal void Area(int r)
        {
            Console.WriteLine($"Area of Circle: {3.14 * r * r}");
        }
        internal void Area(int l,int b)
        {
            Console.WriteLine($"Area of Rectangle: {l*b}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Shape();
            s.Area(10);
            s.Area(5,10);

            Console.Read();
        }
    }
}
