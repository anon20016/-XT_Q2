using System;
using Watermarks.BLL.Interfaces;
using Watermarks.DAL.Interfaces;

namespace Watermarks.BLL
{
    public class FileStorageLogic : IFileStorageLogic
    {
        private readonly IFileStorageDAO _filestorageDAO;

        public FileStorageLogic(IFileStorageDAO filestorageDAO)
        {
            _filestorageDAO = filestorageDAO;
        }

        public string AddFile(byte[] data, string filename, string user)
        {
            return _filestorageDAO.AddFile(data, filename, user);
        }

        public void AddFolderForUser(string username)
        {
            _filestorageDAO.AddFolderForUser(username);
        }
        public string FullFilePath(string user, string filename)
        {
            return _filestorageDAO.FullFilePath(user, filename);
        }
        
        public void DeleteFile(string filename, string user)
        {
            _filestorageDAO.DeleteFile(filename, user);
        }
    }
}
