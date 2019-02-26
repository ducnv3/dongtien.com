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
using DongTien.ClientApp.Controller;
using System.Net;
using System.Diagnostics;

namespace DongTien.ClientApp
{
    public partial class FormClient : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private BusinessService service;
        private List<FileSystemWatcher> watchers;

        public FormClient()
        {
            InitializeComponent();
            ConfigClientForm();
            LoadConfigApp();
            SetEvents();
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
            watchers = new List<FileSystemWatcher>();
        }



        private void SetEvents()
        {
            this.Resize += Form_Resize;
            this.Shown += Form1_Load;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //MessageBox.Show("You are in the Form.Shown event.");
            string username = Txt_Username.Text.Trim();
            string password = Txt_Password.Text.Trim();
            string ipServer = ConfigurationManager.AppSettings[Constants.IpServer];

            service.SaveCertificate(ipServer, username, password, Process_Exited);
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
            string username = ConfigurationManager.AppSettings[Constants.Username];
            string password = ConfigurationManager.AppSettings[Constants.Password];
            string isSync = ConfigurationManager.AppSettings[Constants.Sync];

            Txt_Username.Text = username;
            Txt_Password.Text = password;

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
            string username = Txt_Username.Text.Trim();
            string password = Txt_Password.Text.Trim();
            bool isSync = rbtn_sync.Checked;

            ClientConfiguration.SaveConfigApp(username, password, isSync);
            ClientConfiguration.SaveMapPathToXML(gridviewPath);
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
    }
}
