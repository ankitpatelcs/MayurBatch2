using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericsss
{
    class MyClass<type1,type2>
    {
        type1 id;
        type2 name;

        public MyClass(type1 i, type2 n)
        {
            id = i;
            name = n;
        }
        
        public void display()
        {
            Console.WriteLine("Value1: "+id);
            Console.WriteLine("Value2: "+name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int id;

            Console.WriteLine("Enter ID: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();

            MyClass<int, string> m1 = new MyClass<int, string>(id,name);
            m1.display();

            MyClass<string,DateTime> m2 = new MyClass<string,DateTime>("Mayur",DateTime.Now);
            m2.display();

            Console.Read();
        }
    }
}
