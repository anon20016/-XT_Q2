using System;

namespace Task_1._9
{
    class Program
    {
        static void WriteArray(int[] arr, string description)
        {
            Console.WriteLine(description);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static long solution9(int[] arr)
        {
            long res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    res += arr[i];
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = rnd.Next(10, 50);
            Console.WriteLine("Size of array: " + n);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(-100, +100);
            }
            WriteArray(arr, "Genereted array: ");
            Console.WriteLine("Sum o non-negative elements: " + solution9(arr));
        }
    }
}
