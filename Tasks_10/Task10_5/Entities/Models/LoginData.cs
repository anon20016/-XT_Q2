using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginData
    {
        public LoginData(string l, string h)
        {
            Login = l;
            Hash = h;
        }

        public string Login { get; set; }
        public string Hash { get; set; }

        public override bool Equals(object obj)
        {
            return Login == (obj as LoginData).Login && Hash == (obj as LoginData).Hash;
        }
    }
}
