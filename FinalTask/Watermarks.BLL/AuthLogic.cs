using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Watermarks.BLL.Interfaces;
using Watermarks.DAL.Interfaces;

namespace Watermarks.BLL
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IAuthDAO _authDAO;

        public AuthLogic(IAuthDAO authDAO)
        {
            _authDAO = authDAO;
        }

        public bool CanLogin(string login, string password_hash)
        {
            return _authDAO.CanLogin(login, password_hash);
        }

        public void Register(string login, string password_hash)
        {
            _authDAO.Register(login, password_hash);
        }
    }
}
