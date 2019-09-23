using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface IRoleLogic
    {
        bool IsUserInRole(string username, string roleName);

        string[] GetRolesForUser(string username);

        string[] GetUsersInRole(string roleName);

        void AddUsersToRoles(string[] usernames, string[] roleNames);

        void CreateRole(string roleName);

        bool DeleteRole(string roleName, bool throwOnPopulatedRole);
        
        string[] GetAllRoles();

        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);

        bool RoleExists(string roleName);

        void SaveData();
        void LoadData();
    }
}
