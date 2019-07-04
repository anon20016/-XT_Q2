using System;

namespace Task_1._5
{
    class Program
    {
        static long solution5(int N)
        {
            long ans = 0;
            for (int i = 3; i < N; i += 3)
            {
                ans += i;
            }
            for (int i = 5; i < N; i += 5)
            {
                if (i % 3 != 0)
                    ans += i;
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Console.Write(solution5(1000));
        }
    }
}
