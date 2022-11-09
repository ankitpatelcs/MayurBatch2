using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace propertiess
{
    class MyClass
    {
        int id;
        public int EmpId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            m.EmpId = 90;

            Console.WriteLine(m.EmpId);

            Console.Read();
        }
    }
}
