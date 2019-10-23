using System;
using System.Data.SqlClient;

namespace Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public int UserClass { get; set; }

        public string Image_path { get; set; }

        public string First_Name { get; set; }
        public string Second_Name { get; set; }

        public string Email { get; set; }

        private string Registration { get; set; }

        public User(int id, string login, string password, int uclass, string img_path, string first_name, string second_name, string reg, string em)
        {
            Id = id;
            Login = login;
            Password = password;
            UserClass = uclass;
            Image_path = img_path;
            First_Name = first_name;
            Second_Name = second_name;
            Registration = reg;
            Email = em;
        }
        public User(string login, string password, int uclass, string img_path, string first_name, string second_name, string reg)
        {
            Login = login;
            Password = password;
            UserClass = uclass;
            Image_path = img_path;
            First_Name = first_name;
            Second_Name = second_name;
            Registration = reg;
        }

        public User(string login, string password, int uclass)
        {
            Login = login;
            Password = password;
            UserClass = uclass;
        }
        public User(int id, string login, string password, int uclass)
        {
            Id = id;
            Login = login;
            Password = password;
            UserClass = uclass;
        }
        public User(SqlDataReader reader)
        {
            Id = (int)reader["Id"];
            Login = reader["user_login"].ToString();
            Password = reader["user_password_hash"].ToString();
            UserClass = (int)reader["user_class"];
            Image_path = reader["image_id"].ToString();
            First_Name = reader["first_name"].ToString();
            Second_Name = reader["second_name"].ToString();
            Registration = reader["registration_date"].ToString();
            Email = reader["email"].ToString();
        }
    }
}
