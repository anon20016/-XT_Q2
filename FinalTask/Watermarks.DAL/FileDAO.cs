using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entities;
using Watermarks.DAL.Interfaces;


namespace Watermarks.DAL
{
    public class FileDAO : IFileDAO
    {
        private string path = @"Data Source=31.31.196.149;Integrated Security=False;Database=u0869762_marks;User ID=u0869762_anon;Password=Qwerty1u!;Connect Timeout=15;Encrypt=False;Packet Size=4096";


        public int Add(WFile file)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddWFile";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@name",
                    Value = file.Name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@path",
                    Value = file.Path,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@owner",
                    Value = file.Owner,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ext",
                    Value = file.Extention,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@protected",
                    Value = file.Protected,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@visible",
                    Value = file.Visible,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@add_date",
                    Value = DateTime.Now,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@change_date",
                    Value = DateTime.Now,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    Direction = System.Data.ParameterDirection.Input
                });
                string tags = "";
                foreach(var item in file.Tags)
                {
                    tags += item + " ";
                }
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@tags",
                    Value = tags,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
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

        public void ChangeFilePath(int Id, string newpath)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "ChangeFilePath";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@new_path",
                    Value = newpath,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });              

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ChangeFileProtection(int Id, string protection)
        {
            
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "ChangeFileProtection";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Protection",
                    Value = protection,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFileById(int Id)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DeleteFileById";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });
                

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public WFile FindFileById(int id)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "FindFileById";
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
                        return new WFile(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public WFile FindFileByPath(string path)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "FindFileByPath";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@path",
                    Value = path,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var temp = reader.Read();
                    if (temp)
                    {
                        return new WFile(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public WFile[] GetAllFilesForUser(string username)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetAllFilesForUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@username",
                    Value = username,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<WFile> a = new List<WFile>();
                while (reader.Read())
                {
                    a.Add(new WFile(reader));
                }            
                reader.Close();
                return a.ToArray();
            }
        }

        public WFile[] GetVisibleFilesForUser(string username)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetVisibleFilesForUser";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@username",
                    Value = path,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<WFile> a = new List<WFile>();
                while (reader.Read())
                {
                    a.Add(new WFile(reader));
                }
                reader.Close();
                return a.ToArray();
            }
        }

        public void RenameFileByID(int Id, string name)
        {
            using (var connection = new SqlConnection(path))
            {
                var command = connection.CreateCommand();
                command.CommandText = "RenameFileByID";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id,
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@name ",
                    Value = name,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Direction = System.Data.ParameterDirection.Input
                });


                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
