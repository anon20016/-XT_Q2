using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.DAL.Interfaces
{
    public interface IAuthDAO
    {
        void Register(string login, string password_hash);
        bool CanLogin(string login, string password_hash);
        bool CanRegister(string login);
    }
}
