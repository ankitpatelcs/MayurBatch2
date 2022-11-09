using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegatess
{
    public delegate void FirstDelegate();
    class MyClass
    {
        public void display()
        {
            Console.WriteLine("Calling display");
        }
        public void show()
        {
            Console.WriteLine("Calling show");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            FirstDelegate del = new FirstDelegate(m.display);
            //multicasting
            del += new FirstDelegate(m.show);
            del();

            del -= new FirstDelegate(m.display);
            del();
            Console.Read();
        }
    }
}
