using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacess
{
    interface IEmployee
    {
        void display();
        void show();
    }
    class MyClass : IEmployee
    {
        public void display()
        {
            Console.WriteLine("Calling from display");
        }
        public void show()
        {
            Console.WriteLine("Calling from show");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee employee = new MyClass();
            employee.display();
            employee.show();

            Console.Read();
        }
    }
}
