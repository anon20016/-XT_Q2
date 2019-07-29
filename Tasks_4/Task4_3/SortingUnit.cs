using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task4_3
{
    class SortingUnit
    {
        public event Action<string> Succsess;
        public delegate bool Compare<T>(T first, T second);

        private void swap<T>(ref T fr, ref T sc)
        {
            T temp = fr;
            fr = sc;
            sc = temp;
        }
        public void CustomSort<T>(T[] arr, Compare<T> cmp)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (cmp(arr[i], arr[i + 1]))
                    {
                        swap(ref arr[i], ref arr[i + 1]);
                        flag = true;
                    }
                }
            }
            Succsess.Invoke("Sorting done");
        }
    }
}
