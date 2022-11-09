using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace threading
{
    class MyClass
    {
        public void display()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\tThread: {Thread.CurrentThread.Name} : {i}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass m = new MyClass();
            Thread.CurrentThread.Name = "Parent";
            Thread t = new Thread(new ThreadStart(m.display));
            t.Name = "Child";
            t.Start();

            t.Join();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.Name} : {i}");
            }

            Console.Read();
        }
    }
}
