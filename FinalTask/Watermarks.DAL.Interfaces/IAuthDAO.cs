using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.DAL.Interfaces
{
    public interface IAuthDAO
    {
        void Register(string login, string password_hash, string email);
        void WideRegister(string login, string first_name, string second_name, string password_hash, string email);

        bool CanLogin(string login, string password_hash);
        bool CanRegister(string login);
    }
}
