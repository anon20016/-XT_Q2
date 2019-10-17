using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.BLL.Interfaces
{
    public interface IAuthLogic
    {
        void Register(string login, string password_hash);
        bool CanLogin(string login, string password_hash);
    }    
}

