using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using Watermarks.DAL.Interfaces;

namespace Watermarks.DAL
{
    public class AuthDAO : IAuthDAO
    {
        private string path = @"Data Source=DESKTOP-L60T6QJ\SQLEXPRESS;Initial Catalog=watermark-project;Integrated Security=True";

        public bool CanLogin(string login, string password_hash)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "CheckPassword";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = login,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Pass",
                    Value = password_hash,
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

        public bool CanRegister(string login)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "CanRegister";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = login,
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
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void Register(string login, string password_hash, string email)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "RegisterUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pass_hash",
                    Value = password_hash,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@email",
                    Value = email,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@class",
                    Value = 3,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Register_date",
                    Value = DateTime.Now,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
