﻿using DongTien.Common.Models;
using DongTien.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.ComponentModel;
using System.Configuration;

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
            log.Info("Init queue process.");
        }

        public bool ValidateMapPaths()
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);
            var config = ClientConfiguration.LoadConfigApp();
            string IpServer = config.Count == 4 ? config[2] : "";

            log.Error("IP Server = " + IpServer);
            foreach (var item in paths)
            {
                string ip = Utility.GetIpServerFromPath(item.Destination);
                log.Error("Ip map: " + ip);
                if (ip != IpServer) return false;
            }
            return true;
        }

        public void CopyFile(FileSystemEventArgs e, FtpClient ftp)
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
                dTProcess.ftp = ftp;
                if (!fileProcessor.CheckExistProcess(dTProcess))
                {
                    fileProcessor.EnqueueProcess(dTProcess);
                    log.Info("File: " + e.FullPath + " " + filename);
                }
            }
            else
            {
                log.Error("Do not exist path in map: " + e.FullPath);
            }

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

                if (!fileProcessor.CheckExistProcess(dTProcess))
                {
                    fileProcessor.EnqueueProcess(dTProcess);
                    log.Info("File: " + oldPath  +" to " + newPath);
                }

            }
            else
            {
                log.Error("Do not exist path in map: " + e.FullPath);
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

                if (!fileProcessor.CheckExistProcess(dTProcess))
                {
                    fileProcessor.EnqueueProcess(dTProcess);
                    log.Info("File : " + e.FullPath);
                }
            }
            else
            {
                log.Error("Do not exist path in map: " + e.FullPath);
            }
        }

        public void SaveCertificate(string ipServer, string username, string password, EventHandler e)
        {
            if (ConnectToServerStatus(ipServer))
            {
                Utility.ExecuteCommand(@"/c net use \\" + ipServer + " /user:" + username + " " + password, e);
                log.Info("Set cert success: " + ipServer);
            }
            else
            {
                log.Error("Can't ping to server :" + ipServer);
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
                watcher.Created += changedE;
                watcher.Changed += changedE;
                watcher.Deleted += DeleteE;
                watcher.Renamed += RenameE;
                watcher.EnableRaisingEvents = true;

                watchers.Add(watcher);
            }

            log.Info("Subscribe success: " + paths.Count + " path.");
        }

        public bool ConnectToServerStatus(string ipServer)
        {
            bool netOK = false;
            try
            {
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
            catch (Exception)
            {
                return false;
            }
        }

        public FtpClient ConnectToFTPServer(string ipServer, string user, string pwd, int timeout, int port)
        {
            var ftp = new FtpClient(ipServer,user,pwd, timeout, port);
            ftp.Login();
            return ftp;
        }

        public void UnSubscribeWatcher(List<FileSystemSafeWatcher> watchers, Action<object, FileSystemEventArgs> watcher_Changed, Action<object, FileSystemEventArgs> watcher_Deleted, Action<object, RenamedEventArgs> watcher_Renamed)
        {
            foreach (FileSystemSafeWatcher watcher in watchers)
            {
                watcher.EnableRaisingEvents = false;
            }
            log.Info("Unsubscribe success: " + watchers.Count + " path.");
        }

        public void InitQueueFile()
        {
            if (fileProcessor == null)
            {
                fileProcessor = new FileProcessor();
            }
        }

        public void CloseQueueFile()
        {
            fileProcessor.Dispose();
            log.Info("Queue File has end.");
        }

        public void CopyAll(string sourceDir, string desDir)
        {
            try
            {
                string[] fileList = Directory.GetFiles(sourceDir);

                foreach (string filePath in fileList)
                {
                    try
                    {
                        string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);

                        string sourceFile = sourceDir + "\\" + filename;
                        string desFile = desDir + "\\" + filename;

                        DTProcess dTProcess = new DTProcess();
                        dTProcess.Source = sourceFile;
                        dTProcess.Destination = desFile;
                        dTProcess.Type = TypeProcess.COPY;

                        if (!fileProcessor.CheckExistProcess(dTProcess))
                        {
                            fileProcessor.EnqueueProcess(dTProcess);
                            log.Info("File: " + sourceFile);
                        }
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
    }
}
