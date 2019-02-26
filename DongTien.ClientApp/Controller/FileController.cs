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

        public static void CopyFile(String sourceDir, String desDir)
        {
            try
            {
                string[] fileList = Directory.GetFiles(sourceDir);
                foreach (string f in fileList)
                {
                    string fName = f.Substring(sourceDir.Length + 1);

                    string sourceFile = sourceDir + "\\" + fName;
                    string desFile = desDir + "\\" + fName;

                    File.Copy(sourceFile, desFile, true);
                    File.SetAttributes(desDir, FileAttributes.Normal);
                }
            }
            catch (DirectoryNotFoundException e1)
            {
                log.Error(e1.Message);
            }
            catch (IOException e2)
            {
                log.Error(e2.Message);

            }
        }

        public static void Delete(String path)
        {
            File.Delete(path);
        }

        public static void Rename(String oldPath, string newPath)
        {
            if (File.Exists(oldPath))
                File.Move(oldPath, newPath);
        }
    }
}
