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
                else
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
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }
    }

    public enum TypeProcess
    {
        COPY, RENAME, DELETE
    }
}
