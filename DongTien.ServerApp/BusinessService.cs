﻿using DongTien.Common;
using DongTien.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DongTien.ServerApp
{
    class BusinessService
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
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_SERVER_FILENAME);
            string dir = e.FullPath.Substring(0, e.FullPath.LastIndexOf("\\"));

            ItemPath item = paths.Find(i => i.Source == dir);

            if (item != null)
            {
                string filename = e.FullPath.Substring(e.FullPath.LastIndexOf("\\") + 1);

                string sourceFile = item.Source + "\\" + filename;
                string desFile = item.Destination + "\\" + filename;

                DTProcess dTProcess = new DTProcess();
                dTProcess.SourceDir = sourceFile;
                dTProcess.DesDir = desFile;
                dTProcess.Type = TypeProcess.COPY;
                dTProcess.ClientProcess = false;
                dTProcess.log = log;

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
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_SERVER_FILENAME);
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
                dTProcess.SourceDir = oldPath;
                dTProcess.DesDir = newPath;
                dTProcess.Type = TypeProcess.RENAME;
                dTProcess.ClientProcess = false;
                dTProcess.log = log;

                if (!fileProcessor.CheckExistProcess(dTProcess))
                {
                    fileProcessor.EnqueueProcess(dTProcess);
                    log.Info("File: " + oldPath);
                }

            }
            else
            {
                log.Error("Do not exist path in map: " + e.FullPath);
            }
        }

        public void Delete(FileSystemEventArgs e)
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_SERVER_FILENAME);
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string filePath = item.Destination + "\\" + fileName;
                DTProcess dTProcess = new DTProcess();
                dTProcess.SourceDir = filePath;
                dTProcess.Type = TypeProcess.DELETE;
                dTProcess.ClientProcess = false;
                dTProcess.log = log;

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

        public void SubscribeWatcher(List<FileSystemSafeWatcher> watchers, FileSystemEventHandler changedE, FileSystemEventHandler DeleteE, RenamedEventHandler RenameE)
        {
            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_SERVER_FILENAME);

            foreach (ItemPath item in paths)
            {
                if(!Directory.Exists(item.Source) || !Directory.Exists(item.Destination))
                {
                    if (!Directory.Exists(item.Source))
                    {
                        log.Error("Not exist: " + item.Source);
                    }

                    if (!Directory.Exists(item.Destination))
                    {
                        log.Error("Not exist: " + item.Destination);
                    }
                    continue;
                }

                FileSystemSafeWatcher watcher = new FileSystemSafeWatcher();
                watcher.IncludeSubdirectories = true;
                watcher.Path = item.Source;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                             | NotifyFilters.FileName | NotifyFilters.DirectoryName; ;

                watcher.Filter = "*.*";
                watcher.Created += changedE;
                watcher.Deleted += DeleteE;
                watcher.Renamed += RenameE;
                watcher.EnableRaisingEvents = true;

                watchers.Add(watcher);
            }

        }

        public void UnSubscribeWatcher(List<FileSystemSafeWatcher> watchers, Action<object, FileSystemEventArgs> watcher_Changed, Action<object, FileSystemEventArgs> watcher_Deleted, Action<object, RenamedEventArgs> watcher_Renamed)
        {
            foreach (FileSystemSafeWatcher watcher in watchers)
            {
                watcher.EnableRaisingEvents = false;
            }
            log.Info("Unsubscribe success: " + watchers.Count + " path.");
        }

        public void CloseQueueFile()
        {
            fileProcessor.Dispose();
            log.Info("Queue File has end.");
        }

        public void CopyAll(string sourceDir, string desDirs)
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
                        string desFile = desDirs + "\\" + filename;

                        DTProcess dTProcess = new DTProcess();
                        dTProcess.SourceDir = sourceFile;
                        dTProcess.DesDir = desFile;
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
