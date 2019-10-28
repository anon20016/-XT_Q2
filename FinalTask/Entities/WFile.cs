using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entities
{
    public class WFile
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        public string Path { get; set; }

        public string Owner { get; set; }
        public string Extention { get; set; }

        public int Visible { get; set; }

        public string Protected {get; set; }

        public string Add_Date { get; private set; }
        public string Change_Date { get; private set; }

        public string[] Tags { get; set; }

        public WFile()
        {

        }
        public WFile(SqlDataReader reader)
        {
            Id = (int)reader["Id"];
            Name = reader["wfile_name"].ToString();
            Path = reader["wfile_path"].ToString();
            Owner = reader["wfile_owner"].ToString();
            Extention = reader["wfile_extention"].ToString();
            Protected = reader["protected"].ToString();
            Visible = (int)reader["visible"];
            Add_Date = reader["add_date"].ToString();
            Change_Date = reader["change_date"].ToString();
            if (reader["tags"].ToString().Length == 0)
            {
                Tags = new string[0];
            }
            else
            {
                Tags = (reader["tags"].ToString()).Split().ToArray();
            }
        }

        public WFile(string filename, string ext, string owner)
        {
            Name = filename;
            Extention = ext;
            Path = filename;
            Owner = owner;
            Visible = 1;
            Protected = "false";
            Tags = new string[0];
        }
    }
}
