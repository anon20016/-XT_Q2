using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Award
    {
        public int Id { get; private set; }
        public string Name { get; private set; }       
        public string Discription { get; private set; }

        public Award(int id, string name, string discription)
        {
            Id = id;
            Name = name;
            Discription = discription;
        }
    }
}
