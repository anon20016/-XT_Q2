using System;

namespace Task_1._7
{
    class Program
    {
        private static void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
            
        }   
        static void QSort(int[] a, int l, int r)
        {
            if (l + 1 == r)
            {
                if (a[l] > a[r])
                {
                    swap(ref a[l], ref a[r]);
                    return;
                }
            }
            if (l >= r)
            {
                return;
            }
            int middle = a[l + (r - l) / 2];
            int i = l, j = r;
            while (i <= j)
            {
                while (a[j] > middle)
                {
                    j--;
                }
                while (a[i] < middle)
                {
                    i++;
                }
                if (i <= j)
                {
                    swap(ref a[i], ref a[j]);
                    i++;
                    j--;
                }
            }
            QSort(a, l, j);
            QSort(a, i, r);
        }

        static void WriteArray(int[] arr, string description)
        {
            Console.WriteLine(description);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = 10 + rnd.Next(20);
            Console.WriteLine("Size of array: " + n);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(1000);                
            }
            WriteArray(arr, "Genereted array:");
            QSort(arr, 0, n - 1);
            WriteArray(arr, "Sorted array:"); 
            Console.WriteLine("\nMin value: {0}\nMax value: {1}", arr[0], arr[n - 1]);
        }
    }
}
