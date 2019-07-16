using System;

namespace Task2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string surname, name, patronymic;
            DateTime birthday;
            int age;
            User user;

            Console.WriteLine("Enter surname:");
            surname = Console.ReadLine();

            Console.WriteLine("Enter name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter patronymic:");
            patronymic = Console.ReadLine();

            Console.WriteLine("Enter birthday:");
            birthday = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter age:");
            age = int.Parse(Console.ReadLine());

            try
            {
                user = new User(surname, name, patronymic, birthday, age);
                Console.WriteLine("OK!\n" + user.ToString());
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Console.ReadLine();
                return;
            }
            Console.ReadLine();
        }
    }
}
