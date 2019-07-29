using System;

namespace Task4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, -5, 2, -4, -12, 3, -4, 41, 0 };

            Console.Write("Array: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Counting with void and Linq
            Console.WriteLine($"Number of positive integers: {ISeekYou.Count(arr)}");
            Console.WriteLine($"Number of positive integers: {ISeekYou.CountLINQ(arr)}");

            
            // lyambda
            Console.WriteLine($"Number of not positive integers: {ISeekYou.Count(arr, x => x < 0)}");
            // anonymus
            Console.WriteLine($"Number of two-digit integers: {ISeekYou.Count(arr, delegate (int item) {  return (Math.Abs(item) > 9 && Math.Abs(item) < 100);  })}");
            // Counting with lyambda and Linq + Predicate
            Console.WriteLine($"Number of zero integers: {ISeekYou.CountLINQ(arr, x => x == 0)}");
        }
    }
}
