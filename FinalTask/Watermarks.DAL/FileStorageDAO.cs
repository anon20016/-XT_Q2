using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.DAL.Interfaces;
using System.Drawing;

namespace Watermarks.DAL
{
    public class FileStorageDAO : IFileStorageDAO
    {
        private readonly string path = @"httpdocs\User_Files";

        public string AddFile(byte[] data, string filename, string user)
        {
            filename = path + user + "\\" +  filename;
            if (File.Exists(filename))
            {                 
                filename = "1_" + filename;
                File.WriteAllBytes(filename, data);
                return filename;
            }
            else
            {
                File.WriteAllBytes(filename, data);
                return filename;
            }            
        }

        public void DeleteFile(string filename, string user)
        {
            filename = path + user + "\\" + filename;
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }            
        }

        public void AddFolderForUser(string username)
        {
            Directory.CreateDirectory(path + username);
        }

        public string FullFilePath(string user, string filename)
        {
            if (File.Exists(path + user + "\\" + filename))
            {
                return path + user + "\\" + filename;
            }
            else
            {
                return null;
            }
        }

        public void ChangeDataOfFile(string user, string filename, byte[] newdata)
        {
            filename = path + user + "\\" + filename;
            if (File.Exists(filename))
                if (filename.Substring(filename.LastIndexOf('.')) == ".png")
                {
                    using (var ms = new MemoryStream(newdata))
                    {
                        var bmp = new Bitmap(ms);
                        bmp.Save(filename);
                    }
                }
                else
                {
                    File.WriteAllBytes(filename, newdata);
                }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void RenameFileName(string user, string filename, string newfilename)
        {
            filename = path + user + "\\" + filename;
            newfilename = path + user + "\\" + newfilename;
            if (File.Exists(filename) && !File.Exists(newfilename))
            {
                File.Move(filename, newfilename);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
                
        public byte[] GetFile(string user, string filename)
        {
            filename = path + user + "\\" + filename;
            if (File.Exists(filename))
            {
                return File.ReadAllBytes(filename);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public Stream GetFile(string user, string filename, string type)
        {
            throw new NotImplementedException();
        }

        public Bitmap GetImage(string user, string filename)
        {
            throw new NotImplementedException();
        }

        public void ChangeDataOfImage(string user, string filename, Bitmap newdata)
        {
            throw new NotImplementedException();
        }

        public void DownloadFile(string user, string filename, string localpath)
        {
            throw new NotImplementedException();
        }
    }
}
