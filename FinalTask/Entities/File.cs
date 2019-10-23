using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class File
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        public string Path { get; set; }    

        public string User { get; set; }

        public string Extention { get; set; }

        public string Add_Date { get; set; }
        public string Change_Date { get; set; }

        public string[] Tags { get; set; }
    }
}
