﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FolderLogger
{
    class Restore
    {
        public event LogWrite Change;

        /// <summary>
        /// (time, path)
        /// </summary>
        private Dictionary<string, string> backups;
        public string Path { get; set; }

        /// <summary>
        /// Creates new Restore module for file
        /// </summary>
        /// <param name="path">file path</param>
        public Restore(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Error in path: {Path}");
            }
            Path = path;

            string folder = Environment.CurrentDirectory + "\\data\\" + Math.Abs(Path.GetHashCode());
            if (!Directory.Exists(folder))
            {
                throw new FileNotFoundException($"No information about {Path}");
            }

            backups = new Dictionary<string, string>();
            
            foreach (var item in Directory.GetFiles(folder))
            {
                string p = item.Remove(0, item.LastIndexOf("\\") + 2).Replace('_', ':');
                backups.Add(p.Remove(p.LastIndexOf('.')), item);
            }
        }

        /// <summary>
        /// Returns all backups for this Restore module
        /// </summary>
        /// <returns></returns>
        public string[] GetAllBackups_Date()
        {
            return new List<string>(backups.Keys).ToArray();
        }

        /// <summary>
        /// Making backup for selected datetime
        /// </summary>
        /// <param name="s">date + tile</param>
        public void Backup(string s)
        {            
            byte[] buffer = null;
            using (FileStream fs = new FileStream(backups[s], FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            } 
            File.WriteAllBytes(Path, buffer);    

            Change?.Invoke($"File restored to datetime {s}");
        }
    }
}
