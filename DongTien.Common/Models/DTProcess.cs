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
                InitFtp();
                ftp.ChangeDir(DesDir);
                ftp.UploadDirectory(SourceDir, true);
                pairPath = ftp.pairPath;
                ftp.Close();
            }
            catch (Exception e)
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
                    Console.Write(DesDir);
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

        private void InitFtp()
        {
            List<string> config = ClientConfiguration.LoadConfigApp();

            string username = null;
            string password = null;
            string ipServer = null;
            string isSync = null;

            if (config.Count == 4)
            {
                username = config[0];
                password = config[1] == null ? "" : Utility.Decrypt(config[1], true);
                ipServer = config[2];
                isSync = config[3];
                try
                {
                    ftp = new FtpClient(ipServer, username, password, 5, 21);
                    ftp.Login();
                }
                catch (Exception e)
                {
                    log.Error("Không thể truy cập được đến server");
                }
            }

        }

    }

    public enum TypeProcess
    {
        COPY, RENAME, DELETE
    }
}
