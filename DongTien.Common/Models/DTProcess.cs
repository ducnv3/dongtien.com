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
        /*private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        */

        public TypeProcess Type { get; set; }
        public String SourceDir { get; set; }
        public String DesDir { get; set; }
        public FtpClient ftp { get; set; }
        public DTProcess()
        {
        }

        public void Execute()
        {
            try
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
            catch (Exception e)
            {
                throw;
            }
        }
    }

    public enum TypeProcess
    {
        COPY, RENAME, DELETE
    }
}
