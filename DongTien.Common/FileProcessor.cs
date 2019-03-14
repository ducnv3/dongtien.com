using DongTien.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DongTien.Common
{
    public class FileProcessor : IDisposable
    {
        private EventWaitHandle eventWaitHandle = new AutoResetEvent(false);
        private Thread worker;

        private readonly object locker = new object();

        private Queue<DTProcess> processQueue = new Queue<DTProcess>();

        public FileProcessor()
        {
            worker = new Thread(Work);
            worker.Start();
        }

        public bool CheckExistProcess(DTProcess Process)
        {
            return processQueue.Contains(Process, new DTProcessComparer());
        }

        public void EnqueueProcess(DTProcess Process)
        {
            if (processQueue.Contains(Process, new DTProcessComparer()))
                return;

            lock (locker)
                processQueue.Enqueue(Process);
            eventWaitHandle.Set();
        }

        private void Work()
        {
            while (true)
            {
                DTProcess currentProcess = null;
                lock (locker)
                    if (processQueue.Count > 0)
                    {
                        currentProcess = processQueue.Dequeue();
                        if (currentProcess == null) return;
                    }

                if (currentProcess != null)
                {
                    try
                    {
                        ProcessFile(currentProcess);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else
                {
                    eventWaitHandle.WaitOne();
                }
            }
        }

        private void ProcessFile(DTProcess Process)
        {
            try
            {
                Process.Execute();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region IDisposable Members

        public void Dispose()
        {
            // Signal the FileProcessor to exit
            EnqueueProcess(null);
            // Wait for the FileProcessor's thread to finish
            worker.Join();
            // Release any OS resources
            eventWaitHandle.Close();
        }
        #endregion
    }

    public class DTProcessComparer : IEqualityComparer<DTProcess>
    {
        public bool Equals(DTProcess x, DTProcess y)
        {
            if (x == null || y == null) return false;

            return x.Destination == y.Destination &&
                x.Source == y.Source
                && x.Type == y.Type ? true : false;
        }

        public int GetHashCode(DTProcess obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
