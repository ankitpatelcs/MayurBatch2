using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overridings
{
    class Person
    {
        virtual public void display()
        {
            Console.WriteLine("Calling from Person class");
        }
    }
    class Employee : Person
    {
        override public void display()
        {
            Console.WriteLine("Calling from Employee class");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            e.display();

            Console.Read();
        }
    }
}
