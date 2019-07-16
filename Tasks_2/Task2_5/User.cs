using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_5
{
    public class User
    {
        protected int age;
        protected string surname;
        protected string name;
        protected string patronymic;
        protected DateTime birthday;

        public User(string surname, string name, string patronymic, DateTime birthday, int age)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
            Age = age;
        }

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (value < DateTime.Today && value > DateTime.Today.AddYears(-120))
                {
                    birthday = value;
                }
                else
                {
                    throw new ArgumentException("Not correctly entered birthday date");
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Age must be >= 0");
                }
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Surname required");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]))
                    {
                        throw new ArgumentException("Not correctly entered surname");
                    }
                }
                surname = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name required");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]))
                    {
                        throw new ArgumentException("Not correctly entered name");
                    }
                }
                name = value;
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Patronymic required");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]))
                    {
                        throw new ArgumentException("Not correctly entered patronymic");
                    }
                }
                patronymic = value;
            }
        }

        public override string ToString()
        {
            return $"{name} {surname} {patronymic} Birtday = {birthday.ToString("dd.MM.yyyy")} Age = {age}";
        }
       
    }
}
