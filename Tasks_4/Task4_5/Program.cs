using System;

namespace Task4_5
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter string to check: ");
            string s = Console.ReadLine();
            if (s.isPositiveInt())
            {
                Console.WriteLine("It is a positive integer!");
            }
            else
            {
                Console.WriteLine("It is not a positive integer!");
            }
        }
        public static bool isPositiveInt(this string s)
        {
            bool flag = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 && s[i] == '+')
                    continue;
                flag &= char.IsDigit(s[i]);
            }
            return flag;
        }
    }
}
