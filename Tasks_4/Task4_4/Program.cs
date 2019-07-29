using System;

namespace Task4_4
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 6, 3, 1 };
            Console.WriteLine($"Sum of array: {arr.Sum()}");
        }

        public static int Sum(this int[] param)
        {
            int sum = 0;
            for (int i = 0; i < param.Length; i++)
            {
                sum += param[i];
            }
            return sum;
        }
    }
}
