using Entities;
using System;
using System.Collections.Generic;
using Watermarks.BLL.Interfaces;
using Watermarks.DAL.Interfaces;

namespace Watermarks.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDAO _userDAO;

        public UserLogic(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public int Add(User user)
        {
            return _userDAO.Add(user);
        }

        public void DeleteById(int id)
        {
            _userDAO.DeleteById(id);
        }

        public User FindById(int id)
        {
            return _userDAO.FindById(id);
        }

        public User FindByLogin(string login)
        {
            return _userDAO.FindByLogin(login);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDAO.GetAll();
        }
    }
}
