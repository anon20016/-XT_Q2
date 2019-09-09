using System;
using BAL;
using System.Collections.Generic;

namespace PL
{
    public delegate void MessageWrite(string message);

    class Program
    {
        public static UserLogic userManagerLogic = new UserLogic();
        public static AwardLogic awardManagerLogic = new AwardLogic();

        static void Main(string[] args)
        {
            userManagerLogic.LoadData();
            awardManagerLogic.LoadData();
            SelectOption();
        }

        public static void SelectOption()
        {
            Console.WriteLine("Select option: ");
            Console.WriteLine("1) Add User");
            Console.WriteLine("2) Remove User");
            Console.WriteLine("3) Show all users");
            Console.WriteLine("4) Show all awards");
            Console.WriteLine("5) Close app");
            var input = Console.ReadLine();
            int option = 0;
            while (option != 4)
            {
                if (int.TryParse(input, out option) && option > 0 && option < 6)
                {
                    string name = "", dateofbirth = "";
                    switch (option)
                    {
                        case 1:
                            ReadUserInfo(ref name, ref dateofbirth);
                            try
                            {
                                userManagerLogic.AddUser(name, dateofbirth);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            ReadUserInfo(ref name, ref dateofbirth);
                            try
                            {
                                userManagerLogic.RemoveUser(name, dateofbirth);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 3:
                            WriteAllUsers(userManagerLogic.GetAllUsers());
                            break;
                        case 4:
                            WriteAllUsers(awardManagerLogic.GetAll());
                            break;
                        case 5:
                            userManagerLogic.SaveData();
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
