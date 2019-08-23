using System;
using System.Text.RegularExpressions;

namespace Task7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text");
            string s = Console.ReadLine();
            Regex regex = new Regex(@"[a-zA-Z0-9](-|\w|_|\.){0,}[a-zA-Z0-9]@[a-z]([a-zA-Z0-9]){0,}[a-z]\.([a-z]){2,6}");

            foreach (var item in regex.Matches(s))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
