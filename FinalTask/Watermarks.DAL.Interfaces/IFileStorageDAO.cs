using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.DAL.Interfaces
{
    public interface IFileStorageDAO
    {
        string AddFile(byte[] data, string filename);
        void DeleteFile(string filename);
    }
}
