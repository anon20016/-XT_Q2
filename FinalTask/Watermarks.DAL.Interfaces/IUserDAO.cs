using System;
using System.Collections.Generic;
using Entities;

namespace Watermarks.DAL.Interfaces
{
    public interface IUserDAO
    {
        int Add(User user);
        void DeleteById(int id);
        User FindById(int id);
        User FindByLogin(string login);
        IEnumerable<User> GetAll();
    }
}
