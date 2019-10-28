using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Watermarks.BLL.Interfaces;
using Watermarks.DAL.Interfaces;

namespace Watermarks.BLL
{
    public class FileLogic : IFileLogic
    {
        private readonly IFileDAO _fileDAO;

        public FileLogic(IFileDAO fileDAO)
        {
            _fileDAO = fileDAO;
        }

        public int Add(WFile file)
        {
            return _fileDAO.Add(file);
        }
        public int Add(WFile file, string filepath)
        {
            file.Path = filepath;
            return _fileDAO.Add(file);
        }

        public void ChangeFilePath(int Id, string newpath)
        {
            if (_fileDAO.FindFileById(Id) != null && newpath.Length < 100)
            {
                _fileDAO.ChangeFilePath(Id, newpath);
            }
            else
            {
                throw new FormatException("Error in arguments");
            }
        }

        public void DeleteFileById(int Id)
        {
            if (_fileDAO.FindFileById(Id) != null)
            {
                _fileDAO.DeleteFileById(Id);
            }
            else
            {
                throw new FormatException("No such file");
            }
        }

        public WFile FindFileById(int id)
        {
            return _fileDAO.FindFileById(id);
        }

        public WFile FindFileByPath(string path)
        {
            if (path.Length < 100)
            {
                return _fileDAO.FindFileByPath(path);
            }
            else
            {
                throw new FormatException("Too long path");
            }
        }

        public WFile[] GetAllFilesForUser(string username)
        {
            return _fileDAO.GetAllFilesForUser(username);
        }

        public WFile[] GetVisibleFilesForUser(string username)
        {
            return _fileDAO.GetVisibleFilesForUser(username);
        }

        public void RenameFileByID(int Id, string name)
        {
            if (_fileDAO.FindFileById(Id) != null)
            {
                _fileDAO.RenameFileByID(Id, name);
            }
        }
    }
}
