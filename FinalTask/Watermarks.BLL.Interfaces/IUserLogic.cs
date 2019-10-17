using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.BLL.Interfaces
{
    public interface IUserLogic
    {
        int Add(User user);
        void DeleteById(int id);
        User FindById(int id);
        User FindByLogin(string login);
        IEnumerable<User> GetAll();
    }
}
