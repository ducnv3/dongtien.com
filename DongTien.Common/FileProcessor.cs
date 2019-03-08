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

        private Queue<DTProcess> fileNamesQueue = new Queue<DTProcess>();

        public FileProcessor()
        {
            worker = new Thread(Work);
            worker.Start();
        }

        public void EnqueueProcess(DTProcess Process)
        {
            lock (locker)
                fileNamesQueue.Enqueue(Process);
            eventWaitHandle.Set();
        }

        private void Work()
        {
            while (true)
            {
                DTProcess currentProcess = null;
                lock (locker)
                    if (fileNamesQueue.Count > 0)
                    {
                        currentProcess = fileNamesQueue.Dequeue();
                        if (currentProcess == null) return;
                    }

                if (currentProcess != null)
                {
                    ProcessFile(currentProcess);
                }
                else
                {
                    eventWaitHandle.WaitOne();
                }
            }
        }

        private void ProcessFile(DTProcess Process)
        {
            Process.Execute();
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
}
