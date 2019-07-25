using System;
using System.Collections.Generic;

namespace Task3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            Console.WriteLine("Enter string");
            s = Console.ReadLine();
            Solution3_2(s);
        }

        static void Solution3_2(string s)
        {
            string[] words = s.Split(new char[] { '.', ' '});
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var t in words)
            {
                if (dict.ContainsKey(t.ToLower()))
                {
                    dict[t.ToLower()]++;
                }
                else
                {
                    dict.Add(t.ToLower(), 1);
                }
            }                   
            foreach (var i in dict)
            {
                Console.WriteLine($"the number of words {i.Key} : {i.Value}");
            }
        }
    }
}
