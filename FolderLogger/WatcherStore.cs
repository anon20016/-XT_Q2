using System.Collections.Generic;

namespace FolderLogger
{
    class WatcherStore
    {
        List<Watcher> watchers;
        public event LogWrite Change;

        public WatcherStore()
        {
            watchers = new List<Watcher>();
        }

        public int Count => watchers.Count;      
        

        /// <summary>
        /// Adds Watcher to store
        /// </summary>
        /// <param name="w"></param>
        public void Add(Watcher w)
        {
            if (Contains(w))
            {
                throw new System.Exception($"Already watching {w.Path}");
            }
            watchers.Add(w);
            w.Watch();
        }

        private bool Contains(Watcher w)
        {
            foreach(var item in watchers)
            {
                if (item.Path == w.Path)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes Watcher from store
        /// </summary>
        /// <param name="s"></param>
        public void Remove(string s)
        {
            foreach (var item in watchers)
            {
                if (item.Path == s)
                {
                    item.Delete();
                    watchers.Remove(item);
                    return;
                }
            }
        }
    }
}
