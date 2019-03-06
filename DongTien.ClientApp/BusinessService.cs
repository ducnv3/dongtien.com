using DongTien.Common.Models;
using DongTien.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;

namespace DongTien.ClientApp
{
    public class BusinessService
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private FileProcessor fileProcessor;

        public BusinessService()
        {
            fileProcessor = new FileProcessor();
        }

        public void CopyFile(FileSystemEventArgs e)
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);
            string dir = e.FullPath.Substring(0, e.FullPath.LastIndexOf("\\"));
            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string filename = e.FullPath.Substring(e.FullPath.LastIndexOf("\\") + 1);

                string sourceFile = item.Source + "\\" + filename;
                string desFile = item.Destination + "\\" + filename;

                DTProcess dTProcess = new DTProcess();
                dTProcess.Source = sourceFile;
                dTProcess.Destination = desFile;
                dTProcess.Type = TypeProcess.COPY;

                //fileProcessor.EnqueueProcess(dTProcess);

                File.Copy(sourceFile, desFile, true);
                File.SetAttributes(desFile, FileAttributes.Normal);

            }
            log.Debug("Copy File");
        }

        public void Rename(RenamedEventArgs e)
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string oldName = Utility.GetFilenameFromPath(e.OldFullPath);
                string newName = Utility.GetFilenameFromPath(e.FullPath);

                string oldPath = item.Destination + "\\" + oldName;
                string newPath = item.Destination + "\\" + newName;

                DTProcess dTProcess = new DTProcess();
                dTProcess.Source = oldPath;
                dTProcess.Destination = newPath;
                dTProcess.Type = TypeProcess.RENAME;

                fileProcessor.EnqueueProcess(dTProcess);
            }
        }

        public void Delete(FileSystemEventArgs e)
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string filePath = item.Destination + "\\" + fileName;
                DTProcess dTProcess = new DTProcess();
                dTProcess.Source = filePath;
                dTProcess.Type = TypeProcess.DELETE;
                fileProcessor.EnqueueProcess(dTProcess);
            }
        }

        public void SaveCertificate(string ipServer, string username, string password, EventHandler e)
        {
            if (ConnectToServerStatus(ipServer))
            {
                Utility.ExecuteCommand(@"/c net use \\" + ipServer + " /user:" + username + " " + password, e);
                log.Info("Set Cert Success");
            }
            else
            {
                log.Error("Can't connect to Server");
            }
        }

        public void SubscribeWatcher(List<FileSystemSafeWatcher> watchers, FileSystemEventHandler changedE, FileSystemEventHandler DeleteE, RenamedEventHandler RenameE)
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);

            foreach (ItemPath item in paths)
            {
                FileSystemSafeWatcher watcher = new FileSystemSafeWatcher();
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

        public bool ConnectToServerStatus(string ipServer)
        {
            bool netOK = false;

            // Convert IP Server to ArrayByte
            string[] ips = ipServer.Split('.');
            byte[] addressIP = new byte[ips.Length];
            for (int i = 0; i < addressIP.Length; i++)
            {
                addressIP[i] = (byte)Int16.Parse(ips[i]);
            }

            //Test Ping
            using (Ping png = new Ping())
            {
                IPAddress addr = new IPAddress(addressIP);
                try
                {
                    netOK = (png.Send(addr, 1500, new byte[] { 0, 1, 2, 3 }).Status == IPStatus.Success);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    netOK = false;
                }
                return netOK;
            }
        }

        public void UnSubscribeWatcher(List<FileSystemSafeWatcher> watchers, Action<object, FileSystemEventArgs> watcher_Changed, Action<object, FileSystemEventArgs> watcher_Deleted, Action<object, RenamedEventArgs> watcher_Renamed)
        {
            foreach (FileSystemSafeWatcher watcher in watchers)
            {
                watcher.EnableRaisingEvents = false;
            }
            fileProcessor.Dispose();
        }
    }
}
