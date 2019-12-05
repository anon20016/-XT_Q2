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

        private bool CanRegister(string login)
        {
            return _authDAO.CanRegister(login);
        }

        public void Register(string login, string password_hash, string email)
        {
            if (CanRegister(login))
            {
                _authDAO.Register(login, password_hash, email);
            }
            else
            {
                throw new ArgumentException("This user already exists");
            }
        }

        public void WideRegister(string login, string name, string password_hash, string email)
        {
            if (CanRegister(login))
            {
                string first_name = name;
                string sec_name = "";
                if (name.IndexOf(' ') != -1)               
                {
                    first_name = name.Substring(0, name.IndexOf(' '));
                    sec_name = name.Substring(name.IndexOf(' ') + 1);
                }
                _authDAO.WideRegister(login, first_name, sec_name, password_hash, email);
            }
            else
            {
                throw new ArgumentException("This user already exists");
            }
        }
    }
}
