using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ID","205");
            dic.Add("Name","Mayur");
            dic.Add("Salary","25000.5");
            dic.Add("Gender","M");

            foreach (var item in dic)
            {
                Console.WriteLine(item.Key+" : "+item.Value);
            }
            Console.Read();
        }
    }
}
