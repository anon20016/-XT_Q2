using System;
using System.Collections.Generic;
using System.Linq;
using Watermarks.DAL.Interfaces;
using System.Data.SqlClient;
using Entities;



namespace Watermarks.DAL
{
    public class UserDAO : IUserDAO
    {
        private string path = @"Data Source=31.31.196.149;Integrated Security=False;Database=u0869762_marks;User ID=u0869762_anon;Password=Qwerty1u!;Connect Timeout=15;Encrypt=False;Packet Size=4096";

        public int Add(User user)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@login",
                    Value = user.Login,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pass_hash",
                    Value = user.Password,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@class",
                    Value = user.UserClass,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });               
                var id = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output
                };  
                command.Parameters.Add(id);

                connection.Open();
                command.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                command.ExecuteNonQuery();                
            }
        }

        public void EditUser(User user)
        {     
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "EditUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = user.Login,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@password",
                    Value = user.Password,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@email",
                    Value = user.Email,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@First_name",
                    Value = user.First_Name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@second_name",
                    Value = user.Second_Name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                command.ExecuteNonQuery();                
            }
        }

        public void EdituserAvatar(string login, string file_path)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "EdituserAvatar";
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
                    ParameterName = "@new_avatar",
                    Value = file_path,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public User FindById(int id) 
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "FindById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var temp = reader.Read();
                    if (temp)
                    {
                        return new User((int)reader["Id"], reader["user_login"].ToString(), reader["user_password_hash"].ToString(), (int)reader["user_class"], reader["image_id"].ToString(), reader["first_name"].ToString(), reader["second_name"].ToString(), reader["registration_date"].ToString(), reader["email"].ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public User FindByLogin(string login)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "FindByLogin";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = login,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Direction = System.Data.ParameterDirection.Input
                }); 

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var temp = reader.Read();
                    if (temp)
                    {
                        return new User(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetAll";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<User> a = new List<User>();
                while (reader.Read())
                {
                    a.Add(new User((int)reader["Id"], reader["user_login"].ToString(), reader["user_password_hash"].ToString(), (int)reader["user_class"]));
                }
                reader.Close();
                return a;
            }
        }
    }
}
