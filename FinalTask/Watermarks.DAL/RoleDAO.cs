using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.DAL.Interfaces;

namespace Watermarks.DAL
{
    public class RoleDAO : IRoleDAO
    {
        private string path = @"Data Source=DESKTOP-L60T6QJ\SQLEXPRESS;Initial Catalog=watermark-project;Integrated Security=True";


        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {            
            foreach(var u in usernames)
            {
                foreach(var r in roleNames)
                {
                    using (var connection = new SqlConnection(path))
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = "AddUserToRole";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@User_name",
                            Value = u,
                            SqlDbType = System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input
                        });
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@Role_name",
                            Value = r,
                            SqlDbType = System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input
                        });
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void CreateRole(string roleName)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "CreateRole";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = roleName,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteRole";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = roleName,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllRoles()
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetAllRoles";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> p = new List<string>();
                while (reader.Read())
                {
                    p.Add(reader["Role_name"].ToString());
                }
                reader.Close();
                return p.ToArray();
            }

        }

        public string[] GetRolesForUser(string username)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetRolesForUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@user_name",
                    Value = username,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> p = new List<string>();
                while (reader.Read())
                {
                    p.Add(reader["Role_Name"].ToString());
                }
                reader.Close();
                return p.ToArray();
            }
        }
        
        public string[] GetUsersInRole(string roleName)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetUsersInRole";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@role_name",
                    Value = roleName,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> p = new List<string>();
                while (reader.Read())
                {
                    p.Add(reader["user_login"].ToString());
                }
                reader.Close();
                return p.ToArray();
            }
        }

        public bool IsUserInRole(string username, string roleName)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "IsUserInRole";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@user_name",
                    Value = username,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@role_name",
                    Value = roleName,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                var returnValue = command.Parameters.Add("@Return", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                connection.Open();
                command.ExecuteNonQuery();
                if ((int)returnValue.Value == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var u in usernames)
            {
                foreach(var r in roleNames)
                {
                    using (var connection = new SqlConnection(path))
                    {
                        var command = connection.CreateCommand();
                        command.CommandText = "RemoveUserFromRole";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@User_name",
                            Value = u,
                            SqlDbType = System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input
                        });
                        command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@Role_name",
                            Value = r,
                            SqlDbType = System.Data.SqlDbType.NVarChar,
                            Direction = System.Data.ParameterDirection.Input
                        });
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public bool RoleExists(string roleName)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "RoleExists";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = roleName,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                var returnValue = command.Parameters.Add("@Return", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                connection.Open();
                command.ExecuteNonQuery();
                var sotredProcResult = (int)returnValue.Value;
                if (sotredProcResult == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
