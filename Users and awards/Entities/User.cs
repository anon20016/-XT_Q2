using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        static public int count = 0;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string DateOfBirth { get; private set; }
        public int Age { get; private set; }

        public User()
        {

        }
        public User(int id, string name, string dateofbirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateofbirth;
        }
        public User(string name, string dateofbirth)
        {
            Id = count++;
            Name = name;           
            DateOfBirth = dateofbirth;
        }
        public override string ToString()
        {
            return Id.ToString() +  " " + Name + " " + DateOfBirth;
        }
    }
}
