using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BAL;
using Entities;

namespace Task10_5.Models
{
    public class MyRoleProvider : RoleProvider
    {      
        public override bool IsUserInRole(string username, string roleName)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            return roleLogic.IsUserInRole(username, roleName);
        }        

        public override string[] GetRolesForUser(string username)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();

            return roleLogic.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            return roleLogic.GetUsersInRole(roleName);
        }
        
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            roleLogic.AddUsersToRoles(usernames, roleNames);
            roleLogic.SaveData();
        }

        public override void CreateRole(string roleName)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            roleLogic.CreateRole(roleName);
            roleLogic.SaveData();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            return roleLogic.DeleteRole(roleName, throwOnPopulatedRole);
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            return roleLogic.GetAllRoles();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            roleLogic.RemoveUsersFromRoles(usernames, roleNames);
            roleLogic.SaveData();
        }

        public override bool RoleExists(string roleName)
        {
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            return roleLogic.RoleExists(roleName);
        }
    }
}