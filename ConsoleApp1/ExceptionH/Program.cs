using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionH
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a, b, c;
                a = 90;
                b = 0;
                //c = a / b;
                throw new OverflowException("overflow");
                Console.WriteLine("hkjahsjghfh");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Caught: {ex}");
            }
            finally
            {
                Console.Read();
            }           
        }
    }
}
