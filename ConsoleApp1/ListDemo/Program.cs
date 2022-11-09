using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDemo
{
    class Employee
    {
        public int Empid { get; set; }
        public string name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> li = new List<Employee>();
            li.Add(new Employee { Empid=1, name="Mayur" });
            li.Add(new Employee { Empid=2, name="Mayur" });
            li.Add(new Employee { Empid=3, name="Mayur" });

            foreach (var item in li)
            {
                Console.WriteLine(item.Empid);
                Console.WriteLine(item.name);
            }

            Console.Read();
        }
    }
}
