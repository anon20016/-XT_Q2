using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_5
{
    class Employee : User
    {
        private int experience;
        private string position;

        public Employee(string surname, string name, string patronymic, int age, DateTime birthday, string position, int experience) : base(surname, name, patronymic, birthday, age)
        {
            Experience = experience;
            Position = position;
        }

        public int Experience
        {
            get => experience;
            set
            {
                if (value < 0 || value > age)
                {
                    throw new ArgumentException("Not correctly entered experience!");
                }
                experience = value;
            }
        }

        public string Position
        {
            get => position;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Position requared");
                }
                position = value;
            }
        }


        public override string ToString()
        {
            return base.ToString() + $" Position {position} Experence {experience}";
        }

    }
}
