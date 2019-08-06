using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace FolderLogger
{
   
    class Watcher
    {
        public string Path { get; set; }
        private List<string> derictories;
        public event LogWrite Change;
        private List<FileSystemWatcher> fileSystemWatchers;

        /// <summary>
        /// Returns all subnfolders
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private void GetAllFiles(string path)
        {
            derictories.Add(path);
            foreach (var item in Directory.GetDirectories(path))
            {
                GetAllFiles(item);
            }
        }

        public Watcher(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new FileNotFoundException($"Error in path: {Path}");
            }
            derictories = new List<string>();
            fileSystemWatchers = new List<FileSystemWatcher>();
            
            Path = path;
        }

        public void Watch()
        {            
            GetAllFiles(Path);            
            Change?.Invoke($"Start watching at {Path}");
                   

            foreach (var item in derictories)
            {
                foreach (var file in Directory.GetFiles(item))
                {
                    if (file.EndsWith(".txt"))
                    {
                        SafeChange(file);
                    }
                }
                FileSystemWatcher watcher = new FileSystemWatcher
                {
                    Path = item,
                    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                    Filter = "*.txt"
                };
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);               
                watcher.EnableRaisingEvents = true;

                fileSystemWatchers.Add(watcher);
            }
        }

        public void Delete()
        {
            Change?.Invoke($"Stop watching at {Path}");
            Dispose();
        }

        public void Dispose()
        {
            foreach(var item in fileSystemWatchers)
            {
                item.Dispose();
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Change?.Invoke($"File: {e.FullPath} {e.ChangeType}");
            SafeChange(e.FullPath);
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            Change?.Invoke($"File: {e.FullPath} {e.ChangeType}");
            DeleteChange(e.FullPath);
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            Change?.Invoke($"File: {e.FullPath} {e.ChangeType}");
            SafeChange(e.FullPath);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            Change?.Invoke($"File: {e.OldFullPath} renamed to {e.FullPath}");
            DeleteChange(e.OldFullPath);
            SafeChange(e.FullPath);
        }

        private void SafeChange(string path)
        {
            string safeDir = Environment.CurrentDirectory + "\\data\\" + Math.Abs(path.GetHashCode());
            if (!Directory.Exists(safeDir)){
                Directory.CreateDirectory(safeDir);
            }

            byte[] buffer = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            File.WriteAllBytes($"{safeDir}\\c{DateTime.Now.ToString().Replace(':', '_')}.watcher", buffer);
           
        }

        private void DeleteChange(string path)
        {
            string safeDir = Environment.CurrentDirectory + "\\data\\" + Math.Abs(path.GetHashCode());
            if (!Directory.Exists(safeDir))
            {
                Directory.CreateDirectory(safeDir);
            }

            using (Stream source = File.OpenRead(path))
            {
                byte[] buffer = null;                
                File.WriteAllBytes($"{safeDir}\\d{DateTime.Now.ToString().Replace(':', '_')}.watcher", buffer);
            }
        }

    }
}
