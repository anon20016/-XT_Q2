using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        static public int count = 0;

        public int Id { get; private set; }
        public string Name { get; set; }
        public List<string> Users { get; set; }

        public Role(int id, string n)
        {
            Id = id;
            Name = n;
            Users = new List<string>();
        }
        public Role(int id, string n, List<string> l)
        {
            Id = id;
            Name = n;
            Users = l;
        }

        public override string ToString()
        {
            string res = Name + ": ";
            foreach(var i in Users)
            {
                res += i + " ";
            }
            return res;
        }
    }
}
