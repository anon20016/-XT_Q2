using System;
using BAL;
using System.Collections.Generic;

namespace PL
{
    public delegate void MessageWrite(string message);

    class Program
    {
        public static UserManager userManager = new UserManager();

        static void Main(string[] args)
        {
            userManager.LoadData();
            SelectOption();
        }

        public static void SelectOption()
        {
            Console.WriteLine("Select option: ");
            Console.WriteLine("1) Add User");
            Console.WriteLine("2) Remove User");
            Console.WriteLine("3) Show all users");
            Console.WriteLine("4) Close app");
            var input = Console.ReadLine();
            int option = 0;
            while (option != 4)
            {
                if (int.TryParse(input, out option) && option > 0 && option < 5)
                {
                    string name = "", dateofbirth = "";
                    switch (option)
                    {
                        case 1:
                            ReadUserInfo(ref name, ref dateofbirth);
                            try
                            {
                                userManager.AddUser(name, dateofbirth);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            ReadUserInfo(ref name, ref dateofbirth);
                            userManager.RemoveUser(name, dateofbirth);
                            break;
                        case 3:
                            WriteAllUsers(userManager.GetAllUsers());
                            break;
                        case 4:
                            userManager.SaveData();
                            Environment.Exit(0);
                            break;                             
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number, try again");
                }
                Console.Write("Select option: ");
                input = Console.ReadLine();
            }
        }
        public static void ReadUserInfo(ref string name, ref string dateofbirth)
        {
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Date of Birth (dd.mm.yyyy): ");
            dateofbirth = Console.ReadLine();
        }
        public static void WriteAllUsers<T>(ICollection<T> ts)
        {
            foreach (var item in ts)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void WriteMessage(string s)
        {
            Console.WriteLine(s);
        }
    }
}
