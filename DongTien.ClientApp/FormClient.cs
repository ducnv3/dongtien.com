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
using Timer = System.Timers.Timer;

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
        protected BackgroundWorker wk { get; set; }

        protected bool IsSync = false;

        private Timer timer { get; set; }

        /// <summary>
        /// this is form main
        /// </summary>
        public FormClient()
        {
            InitializeComponent();
            ConfigClientForm();
            LoadConfigApp();
            SetEvents();
            InitSyncFileProcess();
        }

        private void SetTimerAsync()
        {
            timer = new Timer();
            timer.Interval = int.Parse(ConfigurationManager.AppSettings[Constants.TimeAsync]);
            timer.Enabled = true;
            timer.AutoReset = true;

            timer.Elapsed += OnTimedEvent;
            timer.Stop();
        }

        private void OnTimedEvent(Object source,
            System.Timers.ElapsedEventArgs e)
        {
            log.Info("Auto Sync!");
            Console.WriteLine("Call Sync !");
            if (IsSync && !wk.IsBusy)
            {
                RunSyncFile();
                Console.WriteLine("Sync Success!");
            }

        }

        /// <summary>
        /// method start implement Async
        /// </summary>
        protected void InitSyncFileProcess()
        {
            try
            {
                wk = new BackgroundWorker();
                wk.DoWork += wk_DoWork;
                wk.RunWorkerCompleted += wk_RunWorkerCompleted;
                wk.ProgressChanged += wk_ProgressChanged;
                wk.WorkerReportsProgress = true;
                wk.WorkerSupportsCancellation = true;

                SetTimerAsync();
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
            //label4.Text = e.ProgressPercentage.ToString();
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

            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);

            int count = 0;

            foreach (var item in paths)
            {
                count++;
                wk.ReportProgress(count * 100 / paths.Count);

                if (wk.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                service.CopyAll(item.Source, item.Destination);

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

            if (result == DialogResult.Yes)
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
            List<string> config = ClientConfiguration.LoadConfigApp();

            string username = null;
            string password = null;
            string ipServer = null;
            string isSync = null;

            if(config.Count == 4)
            {
                username = config[0];
                password = config[1];
                ipServer = config[2];
                isSync = config[3];
            }

            Txt_Username.Text = username == null ? "" : username;
            Txt_Password.Text = password == null ? "" : Utility.Decrypt(password, true);
            Txt_IpServer.Text = ipServer == null ? "" : ipServer;
            isSync = isSync == null ? "false" : isSync;

            if (isSync.ToLower() == "true")
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
            int rs = saveConfigApp();
            if (rs == 1)
            {
                MessageDialogs.SaveSucess();
            }
            else
            {
                MessageDialogs.Error();
            }
        }

        private int saveConfigApp()
        {
            string username = Txt_Username.Text.Trim();
            string password = Utility.Encrypt(Txt_Password.Text, true);
            string ipServer = Txt_IpServer.Text.Trim();

            bool isSync = rbtn_sync.Checked;

            int r1 = ClientConfiguration.
                SaveConfigApp(username, password, ipServer, isSync);

            int r2 = ClientConfiguration.
                SaveMapPathToXML(gridviewPath);

            return r1 == 1 && r2 == 1 ? 1 : -1;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (service.ConnectToServerStatus(Txt_IpServer.Text.Trim()))
            {
                saveConfigApp();
                if (service.ValidateMapPaths())
                {
                    onChangeStatusRunning(true);
                    service.SubscribeWatcher(watchers, watcher_Changed,
                        watcher_Deleted, watcher_Renamed);
                }
                else
                {
                    MessageDialogs.ValidateMapFail();
                }
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
            IsSync = !IsSync;
            if (IsSync)
            {
                timer.Start();
            }

            if (wk.IsBusy)
            {
                wk.CancelAsync();
                btn_ASyncFiles.Text = Constants.LABEL_START_SYNC;
                timer.Stop();
            }
            else
            {
                RunSyncFile();
            }
        }

        private void RunSyncFile()
        {
            try
            {
                if (IsSync)
                {
                    wk.RunWorkerAsync();
                    btn_ASyncFiles.Text = Constants.LABEL_STOP_SYNC;
                }
                else
                {
                    btn_ASyncFiles.Text = Constants.LABEL_START_SYNC;
                    wk.CancelAsync();
                    timer.Close();
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
            if (wk != null)
                wk.CancelAsync();
            btn_ASyncFiles.Text = Constants.LABEL_START_SYNC;
        }
    }
}
