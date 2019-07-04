using System;

namespace Task_1._8
{
    class Program
    {
        static private void Write3DArray(int[,,] arr,
                                         int first_dimension,
                                         int second_dimension,
                                         int third_dimension)
        {
            for (int i = 0; i < first_dimension; i++)
            {
                for (int j = 0; j < second_dimension; j++)
                {
                    for (int q = 0; q < third_dimension; q++)
                    {
                        Console.WriteLine(arr[i, j, q]);
                    }
                }
            }
        }

        static private void solition8(int[,,] arr,
                                         int first_dimension,
                                         int second_dimension,
                                         int third_dimension)
        {
            for (int i = 0; i < first_dimension; i++)
            {
                for (int j = 0; j < second_dimension; j++)
                {
                    for (int q = 0; q < third_dimension; q++)
                    {
                        if (arr[i, j, q] > 0)
                        {
                            arr[i, j, q] = 0;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {            
            Random rnd = new Random();
            int n = 2 + rnd.Next(4), m = 5 + rnd.Next(4), l = 5 + rnd.Next(4);
            int[,,] arr = new int[n, m, l];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int q = 0; q < l; q++)
                    {
                        arr[i, j, q] = -100 + rnd.Next(200);
                    }
                }
            }
            Console.WriteLine("Generated array:");
            Write3DArray(arr, n, m, l);
            solition8(arr, n, m, l);
            Console.WriteLine("Result array:");
            Write3DArray(arr, n, m, l);

        }
    }
}
