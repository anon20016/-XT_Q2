using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.BLL.Interfaces
{
    public interface IFileLogic
    {
        int Add(WFile file);
        int Add(WFile file, string path);

        void DeleteFileById(int id);
        WFile FindFileById(int id);
        WFile FindFileByPath(string path);
        void RenameFileByID(int Id, string name);
        void ChangeFilePath(int Id, string newpath);

        WFile[] GetAllFilesForUser(string username);
        WFile[] GetVisibleFilesForUser(string username);
    }
}
