using System;

namespace Task_1._12
{
    class Program
    {
        static string solution12(string fr, string sc)
        {
            int[] chars = new int[1500];
            for (int i = 0; i < sc.Length; i++)
            {
                Console.WriteLine(sc[i]);
                chars[sc[i] - char.MinValue] = 1;
            }
            string res = "";
            for (int i = 0; i < fr.Length; i++)
            {
                if (chars[fr[i]] == 1)
                {
                    res += fr[i];
                }
                res += fr[i];
            }
            return res;
        }

        static void Main(string[] args)
        {
            string fr_str, sc_str;
            Console.Write("Enter first string: ");
            fr_str = Console.ReadLine();
            Console.Write("Enter second string: ");
            sc_str = Console.ReadLine();
            Console.Write("Resulting string: " + solution12(fr_str, sc_str));
        }
    }
}
