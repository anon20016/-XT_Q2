using System;

namespace Task_1._10
{
    class Program
    {
        static long solution10(int[,] arr, int first_dimension, int second_dimension)
        {
            long res = 0;
            for (int i = 0; i < first_dimension; i++)
            {
                for (int j = i % 2; j < second_dimension; j += 2)
                {
                    res += arr[i, j];
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter dementions of array: ");
            string[] input = Console.ReadLine().Split();
            int n, m;
            if (input.Length == 2 && Int32.TryParse(input[0], out n) &&
                Int32.TryParse(input[1], out m) && n > 0 && m > 0)
            {
                int[,] arr = new int[n, m];
                Console.WriteLine("\nEnter the array like matrix {0} x {1}: ", n, m);
                for (int i = 0; i < n; i++)
                {
                    input = Console.ReadLine().Split();
                    if (input.Length == m)
                    {
                        for (int j =0; j < m; j++) { 
                            if (!Int32.TryParse(input[i], out arr[i, j]))
                            {
                                Console.WriteLine("Input error!");
                                return;
                            }                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input error!");
                        return;
                    }
                }

                Console.WriteLine(solution10(arr, n, m));
            }
            else
            {
                Console.WriteLine("Input error!");                
            }
        }
    }
}
