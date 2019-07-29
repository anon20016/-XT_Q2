using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_6
{
    public class ISeekYou
    {        
        /// <summary>
        /// Counts number of positive numbers
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int Count(int[] arr)
        {
            int cnt = 0;
            foreach (var i in arr)
            {
                if (i > 0)
                {
                    cnt++;
                }
            }
            return cnt;
        }      

        /// <summary>
        /// Counts number of elements, that are ok with predicate func
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="predicate"></param>
        public static int Count(int[] arr, Predicate<int> predicate)
        {
            int cnt = 0;
            foreach (var i in arr)
            {
                if (predicate(i))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        /// <summary>
        /// Counts number of positive int with LINQ
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int CountLINQ(int[] arr)
        {
            return arr.Count(x => x > 0);            
        }

        /// <summary>
        /// Counts number of positive int with LINQ and predicate
        /// </summary>
        /// <param name="array"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int CountLINQ(int[] arr, Predicate<int> predicate)
        {
            return arr.Count(x => predicate(x));
        }



    }
}
