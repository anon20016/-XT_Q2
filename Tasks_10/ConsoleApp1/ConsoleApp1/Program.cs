using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double e, s, a;
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите шаг: ");
            double h = double.Parse(Console.ReadLine());
            e = 0.000001;
            for (int i = 1; i <= 5; i++)
            {
                a = 18 * x;
                s = a;
                n = 1;

                while (Math.Abs(a) >= e)
                {
                    a = -(x * x) / (2 * n * (2 * n + 1));
                    s += a;
                    n++;
                }               

                x += h;
                Console.Write("x = {0} \t n= {1} \t s= {2} \n", x, n, s);
            }
        }
    }
}
