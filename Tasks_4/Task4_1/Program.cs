using System;

namespace Task4_1
{

    class Program
    {
        public delegate bool Compare<T>(T first, T second);

        static bool CompareInt(int q, int w)
        {
            if (q > w)
            {
                return true;
            }
            return false;
        }
        public static bool CompareString(string s, string t)
        {
            if (s == null)
            {
                return false;
            }
            if (t == null)
            {
                return true;
            }

            if (s.Length < t.Length)
            {
                return false;
            }

            if (s.Length > t.Length)
            {
                return true;
            }

            if (s.CompareTo(t) > 0)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            CustomSortDemo();
            
        } 
        
        static void CustomSortDemo()
        {
            string[] t = { "123", "df", "", "df1", "a", "412", "ACAS", "aasdjasndasdfasdf", "abd", "1", "412" };

            CustomSort(t, CompareString);
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write(t[i] + " ");
            }
        }

        private static void swap<T>(ref T fr, ref T sc)
        {
            T temp = fr;
            fr = sc;
            sc = temp;
        }
        public static void CustomSort<T>(T[] arr, Compare<T> cmp)
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
        }
    }
}
