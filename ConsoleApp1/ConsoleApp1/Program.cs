using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        internal int empid;
        internal string name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            e.empid = 90;
        }
    }
}
