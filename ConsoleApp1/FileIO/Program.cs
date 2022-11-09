using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    class MyClass
    {
        public void WriteData(string filename)
        {
            StreamWriter sw = File.CreateText(filename);
            Console.Write("Enter data: ");
            sw.WriteLine(Console.ReadLine());
            Console.WriteLine("File written Successfully.");
            sw.Close();
        }
        public void Readdata(string filename)
        {
            StreamReader sr = File.OpenText(filename);
            Console.WriteLine("File Content: "+sr.ReadToEnd());
            Console.WriteLine("Read Successful");
            sr.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass fio = new MyClass();
            string file = @"C:\Ankit Patel\Mayur.txt";
            fio.WriteData(file);
            fio.Readdata(file);

            Console.Read();
        }
    }
}
