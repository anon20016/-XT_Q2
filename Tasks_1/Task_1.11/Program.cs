using System;

namespace Task_1._11
{
    class Program
    {
        static double EverageLength(string s)
        {
            int sumLength = 0;
            int temp = 0;
            int count = 0;
            foreach(var c in (s + " "))
            {
                if (char.IsLetter(c))
                {
                    temp++;
                }
                else
                {
                    if (temp > 0)
                    {
                        count++;
                        sumLength += temp;
                        temp = 0;
                    }                    
                }
            }
            return (double)sumLength / count;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string input = Console.ReadLine();
            Console.Write("Everage string length: {0}", EverageLength(input));
        }
    }
}
