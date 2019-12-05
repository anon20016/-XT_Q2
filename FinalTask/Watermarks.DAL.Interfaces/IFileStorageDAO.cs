using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Watermarks.DAL.Interfaces
{
    public interface IFileStorageDAO
    {
        /// <summary>
        /// Addes file by data, filename(without extantion), owner of file)
        /// </summary>
        /// <param name="data">File data</param>
        /// <param name="filename">Name of file</param>
        /// <param name="user">Owner of a file</param>
        /// <returns>Full path of file storage</returns>
        string AddFile(byte[] data, string filename, string user);

        /// <summary>
        /// Deletes file by filename
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="user">Owner of a file</param>
        void DeleteFile(string filename, string user);

        /// <summary>
        /// Returns path of a file
        /// </summary>
        /// <param name="user">Owner of a file</param>
        /// <param name="filename"></param>
        /// <returns>Full path of a file</returns>
        string FullFilePath(string user, string filename);

        /// <summary>
        /// Changes file data in users folder by name
        /// </summary>
        /// <param name="user">Owner of file</param>
        /// <param name="filename"></param>
        /// <param name="newdata">New file data</param>
        void ChangeDataOfFile(string user, string filename, byte[] newdata);


        void ChangeDataOfImage(string user, string filename, Bitmap newdata);

        /// <summary>
        /// Change name of file by user and filename
        /// </summary>
        /// <param name="user">Owner of file</param>
        /// <param name="namename">Old file name</param>
        /// <param name="newfilename">New file name</param>
        void RenameFileName(string user, string namename, string newfilename);

        /// <summary>
        /// Addes folder for user files
        /// </summary>
        /// <param name="username"></param>
        void AddFolderForUser(string username);

        /// <summary>
        /// Returns file data
        /// </summary>
        /// <param name="user">Owner of file</param>
        /// <param name="filename"></param>
        /// <returns></returns>
        byte[] GetFile(string user, string filename);

        /// <summary>
        /// Returns stream for file
        /// </summary>
        /// <param name="user"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        System.IO.Stream GetFile(string user, string filename, string type);

        Bitmap GetImage(string user, string filename);
        
        void DownloadFile(string user, string filename, string localpath);
    }
}
