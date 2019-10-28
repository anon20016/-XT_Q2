using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.BLL.Interfaces
{
    public interface IFileStorageLogic
    {
        string AddFile(byte[] data, string filename);
        void DeleteFile(string filename);
    }
}
