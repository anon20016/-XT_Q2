using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Interfaces
{
    public interface IRoleStore : IStorable<Role> 
    {

        bool IsUserInRole(string username, string roleName);

        string[] GetUsersInRole(string roleName);

        void AddUsersToRoles(string[] usernames, string[] roleNames);

        string[] GetAllRoles();

        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);

        bool RoleExists(string roleName);

        string[] GetRolesForUser(string username);
    }
}
