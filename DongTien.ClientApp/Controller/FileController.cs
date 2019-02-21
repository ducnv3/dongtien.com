using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Net;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using log4net;

namespace DongTien.ClientApp.Controller
{
    public class FileController
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FileController()
        {

        }

        public void CopyFile(String sourceDir, String desDir)
        {
            try
            {
                string[] fileList = Directory.GetFiles(sourceDir);

                foreach (string f in fileList)
                {
                    string fName = f.Substring(sourceDir.Length + 1);
                    File.Copy(Path.Combine(sourceDir, fName),
                        Path.Combine(desDir, fName), true);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                log.Error(dirNotFound.Message);
            }
        }

        public void Delete(String path)
        {
            File.Delete(path);
        }
    }
}
