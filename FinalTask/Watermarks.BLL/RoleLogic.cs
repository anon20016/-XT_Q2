using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.BLL.Interfaces;
using Watermarks.DAL.Interfaces;

namespace Watermarks.BLL
{
    public class RoleLogic : IRoleLogic
    {
        private IRoleDAO _roleDAO;

        public RoleLogic(IRoleDAO roleDAO)
        {
            _roleDAO = roleDAO;
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            _roleDAO.AddUsersToRoles(usernames, roleNames);
        }

        public void CreateRole(string roleName)
        {
            if (!RoleExists(roleName))
                _roleDAO.CreateRole(roleName);
            else
                throw new ArgumentException("This Role already exists!");
        }

        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (RoleExists(roleName))
                return _roleDAO.DeleteRole(roleName, true);
            else
                throw new ArgumentException("No such Role");
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllRoles()
        {
            return _roleDAO.GetAllRoles();
        }

        public string[] GetRolesForUser(string username)
        {
            return _roleDAO.GetRolesForUser(username);
        }

        public string[] GetUsersInRole(string roleName)
        {            
            return _roleDAO.GetUsersInRole(roleName);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return _roleDAO.IsUserInRole(username, roleName);
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            _roleDAO.RemoveUsersFromRoles(usernames, roleNames);
        }

        public bool RoleExists(string roleName)
        {
            return _roleDAO.RoleExists(roleName);
        }
    }
}
