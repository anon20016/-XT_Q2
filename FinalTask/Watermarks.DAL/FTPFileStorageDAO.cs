using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.DAL.Interfaces;
using FluentFTP;
using System.IO;
using System.Drawing;

namespace Watermarks.DAL
{
    public class FTPFileStorageDAO : IFileStorageDAO
    {
        private readonly string path = @"httpdocs\User_Files\";
        FtpClient ftpClient = new FtpClient("31.31.196.149", "u0869762", "Gx5H_Blq");

        public string AddFile(byte[] data, string filename, string user)
        {
            ftpClient.Connect();
            string p = path + user + @"\" + filename;
            ftpClient.Upload(data, p, FtpExists.Overwrite);
            ftpClient.Disconnect();
            return p;
        }

        public void AddFolderForUser(string username)
        {
            ftpClient.Connect();
            ftpClient.CreateDirectory(path + username);
            ftpClient.Disconnect();
        }

        public void ChangeDataOfFile(string user, string filename, byte[] newdata)
        {
            ftpClient.Connect();
            string p = path + user + @"\" + filename;
            ftpClient.Upload(newdata, p, FtpExists.Overwrite);
            ftpClient.Disconnect();
        }

        public void ChangeDataOfImage(string user, string filename, Bitmap newdata)
        {
            ftpClient.Connect();
            string p = path + user + @"\" + filename;
            using (var ms = new MemoryStream())
            {
                newdata.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ftpClient.Upload(ms.ToArray(), p, FtpExists.Overwrite);
            }
            ftpClient.Disconnect();
        }

        public void DeleteFile(string filename, string user)
        {
            ftpClient.Connect();
            string p = path + user + @"\" + filename;
            ftpClient.DeleteFile(p);
            ftpClient.Disconnect();
        }

        public void DownloadFile(string user, string localpath, string filename)
        {
            ftpClient.Connect();
            string p = path + user + @"\" + filename;
            ftpClient.DownloadFileAsync(p, localpath);
            ftpClient.Disconnect();
        }

        public string FullFilePath(string user, string filename)
        {
            string p = path + user + @"\" + filename;
            return p;
        }

        public byte[] GetFile(string user, string filename)
        {
            string p = path + user + @"\" + filename;
            ftpClient.Connect();
            using (var reader = ftpClient.OpenRead(p))
            {
                byte[] fileinfo = new byte[reader.Length];

                reader.Read(fileinfo, 0, (int)reader.Length);
                ftpClient.Disconnect();

                return fileinfo;
            }
        }

        public Stream GetFile(string user, string filename, string type)
        {
            string p = path + user + @"\" + filename;
            ftpClient.Connect();
            ftpClient.Disconnect();
            return null;
        }

        public System.Drawing.Bitmap GetImage(string user, string filename)
        {
            ftpClient.Connect();
            string p = path + user + @"\" + filename;
            var reader = ftpClient.OpenRead(p);
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(reader);
            reader.Close();
            ftpClient.Disconnect();
            return img;
        }

        public void RenameFileName(string user, string namename, string newfilename)
        {
            ftpClient.Connect();
            string p1 = path + user + @"\" + namename;
            string p2 = path + user + @"\" + newfilename;
            ftpClient.Rename(p1, p2);
            ftpClient.Disconnect();
        }
    }
}
