using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string AddFile(byte[] data, string filename)
        {
            return _filestorageDAO.AddFile(data, filename);
        }

        public void DeleteFile(string filename)
        {
            _filestorageDAO.DeleteFile(filename);
        }
    }
}
