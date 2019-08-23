using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text");
            string s = Console.ReadLine();
            Regex regex = new Regex(@"([0-3][0-9])-((0[1-9])|(1[0-2]))-([0-9][0-9][0-9][0-9])");
            if (regex.Matches(s).Count > 0)
            {
                Console.WriteLine($"There is data in text {s}");
            }
            else
            {
                Console.WriteLine($"There is no data in text {s}");
            }
        }
    }
}
