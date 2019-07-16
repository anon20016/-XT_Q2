using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string surname, name, patronymic, position;
            DateTime birthday;
            int age, experience;
            Employee emp;

            

            try
            {
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

                Console.WriteLine("Enter position:");
                position = Console.ReadLine();

                Console.WriteLine("Enter experience:");
                experience = int.Parse(Console.ReadLine());


                emp = new Employee(surname, name, patronymic, age, birthday, position, experience);
                Console.WriteLine(emp.ToString());
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
