using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.BLL.Interfaces;
using Watermarks.DAL.Interfaces;
using System.Configuration;

namespace Watermarks.BLL
{
    public class FileManager : IFileManager
    {
        private readonly IFileDAO fileDAO;
        private readonly IFileStorageDAO filestoragedao;

        public FileManager(IFileDAO file, IFileStorageDAO storageDAO )
        {
            fileDAO = file;
            filestoragedao = storageDAO;
        }

        public void Add(string user, byte[] data, string filename)
        {
            string ext = filename.Substring(filename.LastIndexOf('.'));
            filename = filename.Substring(0, filename.LastIndexOf('.'));
            WFile wFile = new WFile(filename, ext, user);
            wFile.Path = filestoragedao.AddFile(data, filename + ext, user);
            wFile.Id = fileDAO.Add(wFile);
        }

        public void Change(int id, byte[] newdata)
        {
            var file = fileDAO.FindFileById(id);
            try
            {
                filestoragedao.ChangeDataOfFile(file.Owner, file.Name + file.Extention, newdata);
            }
            catch
            {

            }
        }

        public void Change(int id, byte[] newdata, string newname)
        {
            var file = fileDAO.FindFileById(id);
            try
            {
                filestoragedao.ChangeDataOfFile(file.Owner, file.Name + file.Extention, newdata);
                filestoragedao.RenameFileName(file.Owner, file.Name + file.Extention, newname);
            }
            catch
            {

            }
        }

        public void ChangeImage(int id, Bitmap newdata)
        {
            var file = fileDAO.FindFileById(id);
            filestoragedao.ChangeDataOfImage(file.Owner, file.Name + file.Extention, newdata);
        }        

        public void Delete(int id)
        {
            var file = fileDAO.FindFileById(id);
            filestoragedao.DeleteFile(file.Name + file.Extention, file.Owner);
            fileDAO.DeleteFileById(id);
        }

        public void DownloadFile(int id, string localpath)
        {
            var file = fileDAO.FindFileById(id);
            filestoragedao.DownloadFile(file.Name + file.Extention, file.Owner, localpath);
        }

        public byte[] GetFile(int id)
        {
            var file = fileDAO.FindFileById(id);
            return filestoragedao.GetFile(file.Owner, file.Name + file.Extention);
        }

        public System.IO.Stream GetFile(int id, int q)
        {
            var file = fileDAO.FindFileById(id);
            return filestoragedao.GetFile(file.Owner, file.Name + file.Extention, "read");
        }

        public Bitmap GetImage(int id)
        {
            var file = fileDAO.FindFileById(id);
            return filestoragedao.GetImage(file.Owner, file.Name + file.Extention);
        }

        public string GetPath(int id)
        {
            WFile file = fileDAO.FindFileById(id);
            return file.Path;
        }

        public void Rename(int id, string new_name)
        {
            var file = fileDAO.FindFileById(id);
            try
            {
                filestoragedao.RenameFileName(file.Owner, file.Name + file.Extention, new_name);
            }
            catch
            {

            }
        }

        public void SetProtection(int id, string protection)
        {
            var file = fileDAO.FindFileById(id);
            fileDAO.ChangeFileProtection(id, protection);
        }

    }
}
