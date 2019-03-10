using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using System.IO;
using DongTien.Common.Models;
using DongTien.Common;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace DongTien.ClientApp
{
    public partial class FormClient : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Business Service
        /// </summary>
        private BusinessService service;
        private List<FileSystemSafeWatcher> watchers;
        private BackgroundWorker wk = null;

        /// <summary>
        /// this is form main
        /// </summary>
        public FormClient()
        {
            InitializeComponent();
            ConfigClientForm();
            LoadConfigApp();
            SetEvents();
            RunAsyncCopyFiles();
        }

        /// <summary>
        /// method start implement Async
        /// </summary>
        protected void RunAsyncCopyFiles()
        {
            try
            {
                wk = new BackgroundWorker();
                wk.DoWork += wk_DoWork;
                wk.RunWorkerCompleted += wk_RunWorkerCompleted;
                wk.ProgressChanged += wk_ProgressChanged;
                wk.WorkerReportsProgress = true;
                wk.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        /// <summary>
        /// Event change by worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label4.Text = e.ProgressPercentage.ToString();
        }

        /// <summary>
        /// Event worker is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label4.Text = "Chờ đồng bộ"; 
        }

        /// <summary>
        /// Event start worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wk_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (wk.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                wk.ReportProgress(i);
                System.Threading.Thread.Sleep(250);
            }
            e.Result = 42;
        }


        private void ConfigClientForm()
        {
            // Fixed Size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // config notification 
            notifyIcon.BalloonTipText = Constants.BalloonText;
            notifyIcon.BalloonTipTitle = Constants.BalloonTitle;

            onChangeStatusRunning(false);

            service = new BusinessService();
            watchers = new List<FileSystemSafeWatcher>();
        }



        private void SetEvents()
        {
            this.Resize += Form_Resize;
            this.Shown += Form1_Load;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string username = Txt_Username.Text.Trim();
            string password = Txt_Password.Text.Trim();
            string ipServer = Txt_IpServer.Text.Trim();

            service.SaveCertificate(ipServer, username, password, Process_Exited);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageDialogs.CloseForm(e);

            if(result == DialogResult.Yes)
            {
                service.CloseQueueFile();
            }

            e.Cancel = (result == DialogResult.No);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ShowInTaskbar = false;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void LoadConfigApp()
        {
            string username = ConfigurationManager.AppSettings[Constants.Username];
            string password = ConfigurationManager.AppSettings[Constants.Password];
            string ipServer = ConfigurationManager.AppSettings[Constants.IpServer];
            string isSync = ConfigurationManager.AppSettings[Constants.Sync];

            Txt_Username.Text = username;
            Txt_Password.Text = Utility.Decrypt(password,true);
            Txt_IpServer.Text = ipServer;

            if (string.Equals(isSync.ToLower(),"true"))
            {
                rbtn_sync.Checked = true;
                rbtn_notsync.Checked = false;
            }
            else
            {
                rbtn_sync.Checked = false;
                rbtn_notsync.Checked = true;
            }

            ClientConfiguration.LoadMapPathFromXML(gridviewPath);
        }

        private void btn_saveConfig_Click(object sender, EventArgs e)
        {
            string username = Txt_Username.Text.Trim();
            string password = Utility.Encrypt(Txt_Password.Text, true);
            string ipServer = Txt_IpServer.Text.Trim();

            bool isSync = rbtn_sync.Checked;

            ClientConfiguration.SaveConfigApp(username, password, ipServer, isSync);
            ClientConfiguration.SaveMapPathToXML(gridviewPath);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (service.ConnectToServerStatus(Txt_IpServer.Text.Trim()))
            {
                onChangeStatusRunning(true);
                service.SubscribeWatcher(watchers, watcher_Changed, watcher_Deleted, watcher_Renamed);
            }
            else
            {
                MessageDialogs.CannotConectToServer();
            }
        }

        private void onChangeStatusRunning(bool isRunning)
        {
            btn_start.Visible = !isRunning;
            btn_stop.Visible = isRunning;
            gridviewPath.Enabled = !isRunning;
        }

        public void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            service.Rename(e);
        }

        public void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            service.Delete(e);
        }

        public void watcher_Changed(object source, FileSystemEventArgs e)
        {
            service.CopyFile(e);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            log.Error(e);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            onChangeStatusRunning(false);
            service.UnSubscribeWatcher(watchers, watcher_Changed, watcher_Deleted, watcher_Renamed);
        }

        /// <summary>
        /// Async trigger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ASyncFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (wk.IsBusy)
                {
                    wk.CancelAsync();
                    btn_ASyncFiles.Text = Constants.LABEL_START_SYNC;
                }
                else
                {
                    wk.RunWorkerAsync();
                    btn_ASyncFiles.Text = Constants.LABEL_STOP_SYNC;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        private void rbtn_sync_CheckedChanged(object sender, EventArgs e)
        {
            btn_ASyncFiles.Enabled = true;
        }

        private void rbtn_notsync_CheckedChanged(object sender, EventArgs e)
        {
            btn_ASyncFiles.Enabled = false;
            wk.CancelAsync();
            btn_ASyncFiles.Text = Constants.LABEL_START_SYNC;
        }
    }
}
