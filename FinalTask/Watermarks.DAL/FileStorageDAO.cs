using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.DAL.Interfaces;

namespace Watermarks.DAL
{
    public class FileStorageDAO : IFileStorageDAO
    {
        private readonly string path = @"C:\Users\anon2\OneDrive\Documents\-XT_Q2\FinalTask\Watermarks.WebPL\User_Files\";

        public string AddFile(byte[] data, string filename)
        {
            filename = path + filename;
            if (File.Exists(filename))
            {
                return null;
            }
            else
            {
                File.WriteAllBytes(filename, data);
                return filename;
            }            
        }
        public void DeleteFile(string filename)
        {
            filename = path + filename;
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            
        }
    }
}
