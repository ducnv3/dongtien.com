using DongTien.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace DongTien.ServerApp
{
    public partial class ServerForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BusinessService service;
        private List<FileSystemWatcher> watchers;

        public ServerForm()
        {
            InitializeComponent();
            ConfigServerForm();
            LoadConfigApp();
            SetEvents();
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
            watchers = new List<FileSystemWatcher>();
        }


        private void SetEvents()
        {
            this.Resize += Form_Resize;
            this.Shown += Form1_Load;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            MessageDialogs.CloseForm(e);
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
            string isSync = ConfigurationManager.AppSettings[Constants.Sync];

            if (isSync.ToLower() == "true")
            {
                rbtn_sync.Checked = true;
                rbtn_not_sync.Checked = false;
            }
            else
            {
                rbtn_sync.Checked = false;
                rbtn_not_sync.Checked = true;
            }

            ServerConfiguaration.LoadMapPathFromXML(gridViewPath);
            ServerConfiguaration.LoadAllowPathFromXML(gridAllowPath);
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

        private void btn_save_allow_path_Click(object sender, EventArgs e)
        {
            ServerConfiguaration.SaveAllowPathToXML(gridAllowPath);
        }
    }
}
