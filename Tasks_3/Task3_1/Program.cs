using System;
using System.Collections.Generic;

namespace Task3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter N: ");
            string[] input = Console.ReadLine().Split();            
            if (input.Length == 1 && Int32.TryParse(input[0], out n) && n > 0)
            {
                solution3_1(n);
            }
            else
            {
                Console.WriteLine("Input error!");
            }
        }
        
        static void solution3_1(int n)
        {
            LinkedList<int> mass = new LinkedList<int>();
            for (int i = 1; i <= n; i++)
            {
                mass.AddLast(i);
            }
            var t = mass.First;
            while (mass.Count > 0)
            {
                Console.WriteLine("Next number: " + t.Value);
                var nx = t.Next;
                if (t == mass.Last)
                {
                    nx = mass.First;
                }
                mass.Remove(t);
                if (nx == mass.Last)
                {
                    t = mass.First;
                }
                else
                {
                    t = nx.Next;
                }                
            }            
        }
    }
}
