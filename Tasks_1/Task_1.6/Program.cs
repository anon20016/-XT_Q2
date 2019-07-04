using System;

namespace Task_1._6
{
    class Program
    {
        static string[] formats = { "Bold", "Italic", "Underline" };

        private static string GetState(int x)
        {
            string res = "";
            for (int i = 1; i <= 4; i *= 2)
            {
                if ((x & i) != 0)
                {
                    res += formats[i / 2] + " ";
                }
            }           
            return res.Length == 0? "None" : res;
        }

        static void Main(string[] args)
        {
            int state = 0;
            Console.WriteLine("Параметры надписи: " + GetState(state));
            while (true)
            {
                Console.WriteLine("Введите \n\t1: bold\n\t2: italic\n\t3: underline\n");
                int temp;
                if (Int32.TryParse(Console.ReadLine(), out temp) && temp < 4 && temp > 0)
                {
                    state ^= (temp == 3 ? 4 : temp);
                    Console.WriteLine("Параметры надписи: " + GetState(state));
                }
                else
                {
                    Console.WriteLine("Invalid input, try again!");
                }
            }
        }
    }
}
