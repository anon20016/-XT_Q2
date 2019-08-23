using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text");
            string s = Console.ReadLine();
            Regex dd = new Regex(@"<((\d|[a-z]|[A-Z] |=|!|\?|\.|,|;|=|\x22){1,})>|<\/((\d|[a-z]|[A-Z] |=|!|\?|\.|,|;|=|\x22){1,})>");
            s = dd.Replace(s, "_");
            Console.WriteLine(s);

            Console.ReadLine();
        }
    }
}
