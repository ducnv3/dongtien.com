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
        public String Source { get; set; }
        public String Destination { get; set; }

        public DTProcess()
        {
        }

        public void Execute()
        {
            try
            {
                if (Type == TypeProcess.COPY)
                {
                    if (!String.IsNullOrEmpty(Source) || !String.IsNullOrEmpty(Destination))
                    {
                        File.Copy(Source, Destination, true);
                        File.SetAttributes(Destination, FileAttributes.Normal);
                    }
                }
                else if (Type == TypeProcess.RENAME)
                {
                    if ((!String.IsNullOrEmpty(Source) || !String.IsNullOrEmpty(Destination))
                        && File.Exists(Source))
                    {
                        File.Move(Source, Destination);
                    }

                }
                else if (Type == TypeProcess.DELETE)
                {
                    if (!String.IsNullOrEmpty(Source))
                        File.Delete(Source);
                }
            }
            catch(Exception)
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
