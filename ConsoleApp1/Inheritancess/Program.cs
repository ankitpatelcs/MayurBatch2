using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritancess
{
    class Person
    {
        string name;
        protected void GetPerson()
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
        }
        protected void ShowPerson()
        {
            Console.WriteLine($"Name: {name}");
        }
    }
    class Employee : Person
    {
        int empid;
        int salary;
        internal void GetEmployees()
        {
            GetPerson();
            Console.Write("Enter ID: ");
            empid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Salary: ");
            salary = Convert.ToInt32(Console.ReadLine());
        }
        internal void ShowEmployees()
        {
            ShowPerson();
            Console.WriteLine($"Employee ID: {empid}");
            Console.WriteLine($"Salary: {salary}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee[] e = new Employee[2];

            for (int i = 0; i < e.Length; i++)
            {
                e[i] = new Employee();
                e[i].GetEmployees();
            }
            Console.WriteLine("Employee Information: ");
            for (int i = 0; i < e.Length; i++)
            {
                Console.WriteLine("----------------------");
                e[i].ShowEmployees();
            }
            Console.Read();
        }
    }
}
