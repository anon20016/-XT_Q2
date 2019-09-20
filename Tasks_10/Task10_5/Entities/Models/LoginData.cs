using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginData
    {
        public string Login { get; set; }
        public string Hash { get; set; }
        public int Id { get; set; }

        public LoginData(int id, string l, string h)
        {
            Login = l;
            Hash = h;
            Id = id;
        }

        public override bool Equals(object obj)
        {
            return Login == (obj as LoginData).Login && Hash == (obj as LoginData).Hash;
        }
    }
}
