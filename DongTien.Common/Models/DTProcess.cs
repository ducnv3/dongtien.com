using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using log4net;

namespace DongTien.Common.Models
{
    public class DTProcess
    {
        public log4net.ILog log { get; set; }
        public TypeProcess Type { get; set; }
        public String SourceDir { get; set; }
        public String DesDir { get; set; }
        public FtpClient ftp { get; set; }
        public bool ClientProcess { get; set; }
        public Dictionary<string,string> pairPath = new Dictionary<string, string>();

        public DTProcess()
        {
            ClientProcess = true;
        }

        public void Execute()
        {
            try
            {
                if (ClientProcess)
                {
                    ClientProcessor();  
                }
                else
                {
                    ServerProcessor();
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }

        public void SyncFolderClientToServer()
        {
            try
            {
                // string rootLocal = SourceDir;// @"C:\Users\ducnv3\Desktop\testdongtien\boc chi phi";
                // string rootServer = DesDir;// "Phong thi cong\\boc chi phi";
                // Get all subdirectories
                string[] subdirectoryEntries = Directory.GetDirectories(SourceDir);

                // Loop through them to see if they have any other subdirectories
                foreach (string subdirectory in subdirectoryEntries)
                {
                    LoadSubDirs(subdirectory);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        

        private void LoadSubDirs(string dir)
        {        
            try
            {
                string pathOnServer = dir.Replace(SourceDir + "\\", string.Empty);
                ftp = new FtpClient();
                ftp.Login();
                ftp.ChangeDir(DesDir);
                // make the root dir if it doed not exist
                //if (ftp.GetFileList(pathOnServer).Length < 1){
                ftp.MakeDir(pathOnServer); // create folder on server
                //}
                ftp.ChangeDir(pathOnServer); // change dir when loop to new directory 
                foreach (string file in Directory.GetFiles(dir, "*.*"))
                {
                    ftp.Upload(file, true);
                }
                ftp.Close();
                pairPath.Add(dir, DesDir + "\\" + pathOnServer);
                // loop to sub-folder
                string[] subdirectoryEntries = Directory.GetDirectories(dir);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    LoadSubDirs(subdirectory);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void ClientProcessor()
        {
            if (Type == TypeProcess.COPY)
            {
                if (!String.IsNullOrEmpty(SourceDir) ||
                    !String.IsNullOrEmpty(DesDir))
                {
                    var dir = DesDir;
                    var filename = Utility.GetFilenameFromPath(SourceDir);

                    ftp.ChangeDir(dir); // path relative
                    ftp.Upload(SourceDir);
                    ftp.Close();
                }
            }
            else if (Type == TypeProcess.RENAME)
            {
                if ((!String.IsNullOrEmpty(SourceDir) ||
                    !String.IsNullOrEmpty(DesDir)))
                {
                    var dir = Utility.GetDirFromPath(DesDir);

                    var oldname = Utility.GetFilenameFromPath(SourceDir);
                    var newname = Utility.GetFilenameFromPath(DesDir);
                    var newpath = Utility.GetDirFromPath(SourceDir) + "\\" + newname;
                    ftp.ChangeDir(dir); // path relative
                    ftp.DeleteFile(oldname);
                    ftp.Upload(newpath);
                    ftp.Close();
                }

            }
            else if (Type == TypeProcess.DELETE)
            {
                if (!String.IsNullOrEmpty(SourceDir))
                {
                    var dir = Utility.GetDirFromPath(SourceDir);
                    var filename = Utility.GetFilenameFromPath(SourceDir);

                    ftp.ChangeDir(dir); // path relative
                    ftp.DeleteFile(filename);
                    ftp.Close();
                }
            }
        }

        private void ServerProcessor()
        {
            if (Type == TypeProcess.COPY)
            {
                if (!String.IsNullOrEmpty(SourceDir) ||
                    !String.IsNullOrEmpty(DesDir))
                {
                    File.Copy(SourceDir, DesDir, true);
                    File.SetAttributes(DesDir, FileAttributes.Normal);
                }
            }
            else if (Type == TypeProcess.RENAME)
            {
                if ((!String.IsNullOrEmpty(SourceDir) ||
                    !String.IsNullOrEmpty(DesDir)))
                {
                    File.Move(SourceDir, DesDir);
                }

            }
            else if (Type == TypeProcess.DELETE)
            {
                if (!String.IsNullOrEmpty(SourceDir))
                    File.Delete(SourceDir);
            }
        }
    }

    public enum TypeProcess
    {
        COPY, RENAME, DELETE
    }
}
