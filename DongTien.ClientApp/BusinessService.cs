﻿using DongTien.Common.Models;
using DongTien.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DongTien.ClientApp.Controller;

namespace DongTien.ClientApp
{
    public class BusinessService
    {
        public void CopyFile(FileSystemEventArgs e)
        {
            List<ItemPath> paths = ClientConfiguration.GetListMapPath();
            string dir = e.FullPath.Substring(0, e.FullPath.LastIndexOf("\\"));
            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
                FileController.CopyFile(item.Source, item.Destination);
        }

        public void Rename(RenamedEventArgs e)
        {
            List<ItemPath> paths = ClientConfiguration.GetListMapPath();
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string oldName = Utility.GetFilenameFromPath(e.OldFullPath);
                string newName = Utility.GetFilenameFromPath(e.FullPath);

                string oldPath = item.Destination + "\\" + oldName;
                string newPath = item.Destination + "\\" + newName;

                FileController.Rename(oldPath, newPath);
            }
        }

        public void Delete(FileSystemEventArgs e)
        {
            List<ItemPath> paths = ClientConfiguration.GetListMapPath();
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string filePath = item.Destination + "\\" + fileName;
                FileController.Delete(filePath);
            }
        }

        public void SaveCertificate(string ipServer, string username, string password, EventHandler e)
        {
            Utility.ExecuteCommand(@"/c net use \\"+ ipServer + " /user:" + username + " " + password, e);
        }

        public void SubscribeWatcher(List<FileSystemWatcher> watchers, FileSystemEventHandler changedE, FileSystemEventHandler DeleteE, RenamedEventHandler RenameE)
        {
            List<ItemPath> paths = ClientConfiguration.GetListMapPath();

            foreach (ItemPath item in paths)
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.IncludeSubdirectories = true;
                watcher.Path = item.Source;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                             | NotifyFilters.FileName | NotifyFilters.DirectoryName; ;
                watcher.Filter = "*.*";
                watcher.Changed += new FileSystemEventHandler(changedE);
                watcher.Deleted += new FileSystemEventHandler(DeleteE);
                watcher.Renamed += new RenamedEventHandler(RenameE);
                watcher.EnableRaisingEvents = true;

                watchers.Add(watcher);
            }

        }

        public void UnSubscribeWatcher(List<FileSystemWatcher> watchers, Action<object, FileSystemEventArgs> watcher_Changed, Action<object, FileSystemEventArgs> watcher_Deleted, Action<object, RenamedEventArgs> watcher_Renamed)
        {
            foreach(FileSystemWatcher watcher in watchers)
            {
                watcher.EnableRaisingEvents = false;
            }
        }
    }
}
