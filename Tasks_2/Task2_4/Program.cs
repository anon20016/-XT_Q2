using System;

namespace Task2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch;
            MyString str1, str2;
            int idx;

            try
            {
                Console.WriteLine("Введите 1 строку");
                str1 = new MyString(Console.ReadLine());

                Console.WriteLine("Введите 2 строку");
                str2 = new MyString(Console.ReadLine().ToCharArray());
                
                MyString strConcat = str1 + str2;
                Console.WriteLine("конкатенация строк: {0}", strConcat.ToString());

                Console.Write("Введите символ первое вхождение, которого вы хотите найти: ");
                ch = Convert.ToChar(Console.ReadLine());
                Console.WriteLine(strConcat.IndexOf(ch));

                if (str1 > str2)
                {
                    Console.WriteLine("Первая строка больше");
                }
                else if (str1 < str2)
                {
                    Console.WriteLine("Вторая строка больше");
                }
                else if (str1 == str2)
                {
                    Console.WriteLine("Строки равны");
                }

                Console.WriteLine("Индекс элемента, который вы хотите найти: ");

                idx = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("a[{0}] = {1}", idx.ToString(), strConcat.Mystring[idx].ToString());               

                string convertStr = (string)str1;
                str1 = convertStr;

                char[] convertChars = (char[])str2;
                str2 = convertChars;
                Console.WriteLine("Convertation OK");
            }
            catch (FormatException error)
            {
                Console.WriteLine(error.Message);
            }
            catch (IndexOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
            }

            Console.ReadKey();
        }
    }
}
