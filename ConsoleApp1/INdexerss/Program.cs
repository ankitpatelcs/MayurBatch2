using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INdexerss
{
    class MyClass
    {
        string[] names = new string[5];
        public string this[int index]
        {
            get 
            {
                return names[index];
            }
            set 
            {
                names[index] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();

            m[0] = "Mayur";
            m[1] = "--";
            m[2] = "--";
            m[3] = "Chavan";
            m[4] = "--";

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"value[{i}] : {m[i]}");
            }

            Console.Read();
        }
    }
}
