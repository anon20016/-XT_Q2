using System;

namespace problem0._1
{
    class Program
    {
        static bool is_prime(int n)
        {
            for (int i = 2; i * i <= n; ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter positive integer N > 1: ");
            string input = Console.ReadLine();
            int n;
            if (Int32.TryParse(input, out n) && n > 1)
            {
                if (is_prime(n))
                {
                    Console.WriteLine("Number " + n.ToString() + " is prime");
                }
                else
                {
                    Console.WriteLine("Number " + n.ToString() + " is not prime");
                }
            }
            else
            {
                Console.WriteLine("Input error!");
            }
        }
    }
}
