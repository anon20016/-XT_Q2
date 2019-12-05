using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermarks.BLL.Interfaces
{
    public interface IFileManager
    {
        /// <summary>
        /// Addes data[] to user folder
        /// </summary>
        /// <param name="user"> Owner of file </param>
        /// <param name="data"> File data </param>
        /// <param name="filename"> Name of file </param>
        void Add(string user, byte[] data, string filename);
        void Delete(int id);

        void Rename(int id, string new_name);
        void Change(int id, byte[] newdata);
        void Change(int id, byte[] newdata, string newname);
        void ChangeImage(int id, Bitmap newdata);

        void SetProtection(int id, string protection);

        string GetPath(int id);

        byte[] GetFile(int id);

        Bitmap GetImage(int id);

        /// <summary>
        /// Downloads file
        /// </summary>
        /// <param name="id"> Id of file </param>
        /// <param name="localpath"> Destination path </param>
        void DownloadFile(int id, string localpath);
    }
}
