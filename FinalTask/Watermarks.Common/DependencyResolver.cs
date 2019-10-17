using System;
using System.Collections.Generic;
using System.Linq;
using Watermarks.DAL.Interfaces; 
using System.Threading.Tasks;
using Watermarks.DAL;
using Watermarks.BLL.Interfaces;
using Watermarks.BLL;

namespace Watermarks.Common
{
    public class DependencyResolver
    {
        private static readonly IUserDAO _userDAO;
        private static readonly IUserLogic _userLogic;

        private static readonly IAuthDAO _authDAO;
        private static readonly IAuthLogic _authLogic;

        private static readonly IRoleDAO _roleDAO;
        private static readonly IRoleLogic _roleLogic;

        public static IUserDAO UserDAO => _userDAO;
        public static IUserLogic UserLogic => _userLogic;
        public static IAuthDAO AuthDAO => _authDAO;
        public static IAuthLogic AuthLogic => _authLogic;

        public static IRoleDAO RoleDAO => _roleDAO;
        public static IRoleLogic RoleLogic => _roleLogic;

        static DependencyResolver() 
        {
            _userDAO = new UserDAO();
            _authDAO = new AuthDAO();
            _roleDAO = new RoleDAO();

            _userLogic = new UserLogic(_userDAO);
            _authLogic = new AuthLogic(_authDAO);
            _roleLogic = new RoleLogic(_roleDAO);
        }   
    }
}
