﻿using DongTien.Common;
using DongTien.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Timers;
using System.Windows.Forms;

using Timer = System.Timers.Timer;

namespace DongTien.ServerApp
{
    public partial class ServerForm : Form
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BusinessService service;
        private List<FileSystemSafeWatcher> watchers;

        protected BackgroundWorker wk { get; set; }

        protected bool IsSync = false;

        private Timer timer { get; set; }

        public ServerForm()
        {
            InitializeComponent();
            ConfigServerForm();
            LoadConfigApp();
            SetEvents();
            InitSyncFileProcess();
        }


        private void ConfigServerForm()
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

            this.rbtn_sync.CheckedChanged += OnChangeSyncRadioStatus;
        }

        private void OnChangeSyncRadioStatus(object sender, EventArgs e)
        {
            bool status = rbtn_sync.Checked;
            if (!status)
            {
                btn_sync.Enabled = false;
            }
            else
            {
                btn_sync.Enabled = true;
            }
        }

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

        private void SetTimerAsync()
        {
            timer = new Timer();
            timer.Interval = int.Parse(ConfigurationManager.AppSettings[Constants.TimeAsync]);
            timer.Enabled = true;
            timer.AutoReset = true;

            timer.Elapsed += OnTimedEvent;
            timer.Stop();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            log.Info("Run Sync Files Schedule !");
            Console.WriteLine("Call !!");
            if (wk.IsBusy)
            {
                wk.CancelAsync();
                btn_sync.Text = Constants.LABEL_STOP_SYNC;
                timer.Stop();
            }
            else
            {
                btn_sync.Text = Constants.LABEL_STOP_SYNC;
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
                    btn_sync.Text = Constants.LABEL_STOP_SYNC;
                }
                else
                {
                    btn_sync.Text = Constants.LABEL_START_SYNC;
                    wk.CancelAsync();
                    timer.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

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
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void LoadConfigApp()
        {
            rbtn_sync.Checked = false;
            rbtn_not_sync.Checked = true;
            btn_sync.Enabled = false;

            ServerConfiguaration.LoadMapPathFromXML(gridViewPath);

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            onChangeStatusRunning(true);
            service.SubscribeWatcher(watchers, watcher_Changed, watcher_Deleted, watcher_Renamed);
        }

        private void onChangeStatusRunning(bool isRunning)
        {
            btn_start.Visible = !isRunning;
            btn_stop.Visible = isRunning;
            gridViewPath.Enabled = !isRunning;
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
            Show();
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

        private void btn_save_config_Click(object sender, EventArgs e)
        {
            bool isSync = rbtn_sync.Checked;

            ServerConfiguaration.SaveConfigApp(isSync);
            ServerConfiguaration.SaveMapPathToXML(gridViewPath);
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
            //label4.Text = "Chờ đồng bộ";
        }

        /// <summary>
        /// Event start worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wk_DoWork(object sender, DoWorkEventArgs e)
        {

            List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_SERVER_FILENAME);
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

        private void btn_sync_Click(object sender, EventArgs e)
        {
            IsSync = !IsSync;

            if (IsSync)
            {
                timer.Start();
                btn_sync.Text = Constants.LABEL_STOP_SYNC;
            }
            else
            {
                timer.Stop();
                btn_sync.Text = Constants.LABEL_START_SYNC;
            }

            if (wk.IsBusy)
            {
                wk.CancelAsync();
                timer.Stop();
            }
            else
            {
                RunSyncFile();
            }
        }


    }
}
