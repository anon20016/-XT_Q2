using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.BLL.Interfaces
{
    public interface IFileStorageLogic
    {
        string AddFile(byte[] data, string filename, string user);
        void DeleteFile(string filename, string user);
        string FullFilePath(string user, string filename);
        void AddFolderForUser(string username);
    }
}
