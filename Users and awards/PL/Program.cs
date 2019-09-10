using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Entities;

namespace PL
{
    public delegate void MessageWrite(string message);

    class Program
    {
        public static IUserLogic userManagerLogic = new UserLogic();
        public static IAwardAssotiateLogic awardManagerLogic = new AwardLogic();

        static void Main(string[] args)
        {
            userManagerLogic.LoadData();
            awardManagerLogic.LoadData();

            SelectOption();


        }

        public static void SelectOption()
        {
            Console.WriteLine("Select option: ");
            Console.WriteLine("0) Show Users and Awards");
            Console.WriteLine("1) Add User");
            Console.WriteLine("2) Remove User");
            Console.WriteLine("3) Show all users");
            Console.WriteLine("4) Show all awards");
            Console.WriteLine("5) Add Award");
            Console.WriteLine("6) Remove Award");
            Console.WriteLine("7) Give Award to user");
            Console.WriteLine("8) Remove Award from user");
            Console.WriteLine("9) Close app");
            var input = Console.ReadLine();
            int option = 0;
            while (true)
            {
                if (int.TryParse(input, out option) && option >= 0 && option < 10)
                {
                    string[] inpt;
                    switch (option)
                    {
                        case 0:
                            var tempA = awardManagerLogic.GetAllAssotiations();
                            var tempU = userManagerLogic.GetAll();
                            foreach (var item in tempU)
                            {
                                Console.Write($"{item.Name} {item.DateOfBirth}");
                                var r = from i in tempA where (i.firstID == item.Id) select i.secondID;
                                if (r.Count() > 0)
                                {
                                    Console.Write(" Awards: ");
                                    foreach (var item1 in r)
                                    {
                                        Console.Write(awardManagerLogic.Find(item1).Name + " ");
                                    }
                                }
                                Console.WriteLine();
                            }

                            break;
                        case 1:
                            inpt = ReadInfo("Name: ", "Date of Birth (dd.mm.yyyy): ");
                            try
                            {
                                if (!userManagerLogic.AddUser(inpt[0], inpt[1])){
                                    Console.WriteLine("This user already exists");
                                }                               
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            inpt = ReadInfo("Name: ", "Date of Birth (dd.mm.yyyy): ");
                            try
                            {
                                if (!userManagerLogic.RemoveUser(inpt[0], inpt[1])){
                                    Console.WriteLine("No such user");
                                }
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 3:
                            WriteAllUsers(userManagerLogic.GetAll());
                            break;
                        case 4:
                            WriteAllUsers(awardManagerLogic.GetAll());
                            break;
                        case 5:
                            inpt = ReadInfo("Name: ", "Discription: ");
                            try
                            {
                                awardManagerLogic.AddAward(inpt[0], inpt[1]);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 6:
                            inpt = ReadInfo("Name: ");
                            try
                            {
                                awardManagerLogic.RemoveAward(inpt[0]);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 7:
                            inpt = ReadInfo("User Id: ", "Award Id: ");
                            try
                            {
                                if (!awardManagerLogic.Associate(Convert.ToInt32(inpt[0]), Convert.ToInt32(inpt[1])))
                                {
                                    Console.WriteLine("Already graded");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 8:
                            inpt = ReadInfo("User Id: ", "Award Id: ");
                            try
                            {
                                if (!awardManagerLogic.deAssociate(Convert.ToInt32(inpt[0]), Convert.ToInt32(inpt[1])))
                                {
                                    Console.WriteLine("User dont have this award");
                                }                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 9:
                            userManagerLogic.SaveData();
                            awardManagerLogic.SaveData();
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

        private static string[] ReadInfo(params string[] args)
        {
            string[] res = new string[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(args[i]);
                res[i] = Console.ReadLine();
            }
            return res;
        }

        public static void WriteAllUsers<T>(ICollection<T> ts)
        {
            foreach (var item in ts)
            {
                Console.WriteLine(item.ToString());
            }
        }

    } 
}
