using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.DAL.Interfaces
{
    public interface IFileDAO
    {
        int Add(WFile file);
        void DeleteFileById(int id);
        WFile FindFileById(int id);
        WFile FindFileByPath(string path);
        void RenameFileByID(int Id, string name);
        void ChangeFilePath(int Id, string newpath);

        WFile[] GetAllFilesForUser(string username);
        WFile[] GetVisibleFilesForUser(string username);

    }
}
