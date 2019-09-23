using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entities;

namespace mysqlDAL
{
    class UserStorage_SQLDAO : IStorable<User>
    {
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Add(User note)
        {
            using (var connection = new SqlConnection(Path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@nameU",
                    Value = note.Name,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@dobU",
                    Value = note.DateOfBirth,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pic",
                    Value = note.Base64img,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@passwordU",
                    Value = note.Password,
                    Direction = System.Data.ParameterDirection.Input
                });
                var id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Direction = System.Data.ParameterDirection.Output
                };

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool Exists(User note)
        {
            throw new NotImplementedException();
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        public int Find(User note)
        {
            using (var connection = new SqlConnection(Path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "FindUserByLogin";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@login",
                    Value = note.Name,
                    Direction = System.Data.ParameterDirection.Input
                });                
                var id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Direction = System.Data.ParameterDirection.Output
                };

                connection.Open();
                command.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public bool Remove(User note)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, User note)
        {
            throw new NotImplementedException();
        }
    }
}
