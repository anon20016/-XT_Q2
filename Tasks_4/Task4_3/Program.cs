using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 3, 3, 5, 1, 2, 3, 5, 2, 3, 32, 2, 31, 3, 1, 23, 123, 12, 3, 1, 23, 12, 3, 123 };
            int[] arr2 = { 8, 5, 4, 7, 1, 2, 6, 55, 8, 9, 93, 6, 4, 1, 56 };
            SortingUnit example = new SortingUnit();
            example.Succsess += Done;

            Thread thread1 = new Thread(() => example.CustomSort(arr1, (x, y) => x > y));
            Thread thread2 = new Thread(() => example.CustomSort(arr2, (x, y) => x > y));

            thread1.Start();
            thread2.Start();
        }
        private static void Done(string x)
        {
            Console.WriteLine(x);
        }
    }
}
