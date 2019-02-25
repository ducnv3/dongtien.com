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
using DongTien.ClientApp.Models;
using DongTien.Common;
using DongTien.ClientApp.Controller;
using System.Net;
using System.Diagnostics;

namespace DongTien.ClientApp
{
    public partial class FormClient : Form
    {
        private string username = "";
        private string password = "";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FormClient()
        {
            InitializeComponent();
            ConfigClientForm();
            LoadConfigApp();
            SetEvents();
        }

        private void SetEvents()
        {
            this.Resize += Form_Resize;

            // set cert
            ExecuteCommand("/c net use * /delete /y");
            ExecuteCommand(@"/c net use \\192.168.1.9 /user:" + username + " " + password);
            ExecuteCommand("/c net use * /delete /y");

            FileWatcher();
        }

        private void ConfigClientForm()
        {
            // Fixed Size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // config notification 
            notifyIcon.BalloonTipText = "Ứng dụng đã được thu nhỏ !";
            notifyIcon.BalloonTipTitle = "Thông báo";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "Bạn có chắc chắn muốn thoát ứng dụng?";
            const string caption = "Xác nhận";

            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

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
            username = ConfigurationManager.AppSettings[Constants.Username];
            password = ConfigurationManager.AppSettings[Constants.Password];
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

            LoadMapPathFromXML();
        }

        private void btn_saveConfig_Click(object sender, EventArgs e)
        {
            SaveConfigApp();
        }

        private void SaveConfigApp()
        {
            string username = Txt_Username.Text.Trim();
            string password = Txt_Password.Text.Trim();
            bool isSync = rbtn_sync.Checked;

            string _isSync = isSync == true ? "true" : "false";


            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove(Constants.Username);
            config.AppSettings.Settings.Add(Constants.Username, username);

            config.AppSettings.Settings.Remove(Constants.Password);
            config.AppSettings.Settings.Add(Constants.Password, password);

            config.AppSettings.Settings.Remove(Constants.Sync);
            config.AppSettings.Settings.Add(Constants.Sync, _isSync);
            config.Save(ConfigurationSaveMode.Minimal);

            SaveMapPathToXML();
        }

        private void SaveMapPathToXML()
        {
            try
            {
                DataTable dt = new DataTable("ItemPath");
                for (int i = 0; i < gridviewPath.ColumnCount; i++)
                {
                    dt.Columns.Add(gridviewPath.Columns[i].Name, typeof(System.String));
                }

                int numOfCol = gridviewPath.Columns.Count;
                foreach (DataGridViewRow drow in this.gridviewPath.Rows)
                {
                    DataRow myrow = dt.NewRow();
                    for (int i = 0; i < numOfCol; i++)
                    {
                        myrow[i] = drow.Cells[i].Value;
                    }
                    dt.Rows.Add(myrow);
                }
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                dt.WriteXml("AppConfig.xml");

                MessageBox.Show("Lưu cấu hình thành công !");
            }
            catch (Exception e)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu cấu hình. Vui lòng thử lại!");
            }
        }

        private void LoadMapPathFromXML()
        {
            try
            {
                var xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                FileStream fs = new FileStream("AppConfig.xml", FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("ItemPath");

                for (int i = 0; i < xmlnode.Count; i++)
                {
                    string source = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    string destination = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    this.gridviewPath.Rows.Add(source, destination);
                }

                fs.Close();
            }
            catch (IOException e)
            {
                log.Error(e.Message);
            }
        }

        private List<ItemPath> GetListMapPath()
        {
            List<ItemPath> itemPaths = new List<ItemPath>();
            for (int rows = 0; rows < gridviewPath.Rows.Count - 1; rows++)
            {
                string source = gridviewPath.Rows[rows].Cells[0].Value.ToString();
                string destination = gridviewPath.Rows[rows].Cells[1].Value.ToString();

                ItemPath itemPath = new ItemPath();
                itemPath.Source = source;
                itemPath.Destination = destination;

                itemPaths.Add(itemPath);
            }
            return itemPaths;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {

        }

        public void FileWatcher()
        {
            List<ItemPath> paths = GetListMapPath();

            foreach (ItemPath item in paths)
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.IncludeSubdirectories = true;
                watcher.Path = item.Source;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                             | NotifyFilters.FileName | NotifyFilters.DirectoryName; ;
                watcher.Filter = "*.*";
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
                watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                watcher.EnableRaisingEvents = true;
            }

        }

        public void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            List<ItemPath> paths = GetListMapPath();
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string oldName = Utility.GetFilenameFromPath(e.OldFullPath);
                string newName = Utility.GetFilenameFromPath(e.FullPath);

                string oldPath = item.Destination + "\\" + oldName;
                string newPath = item.Destination + "\\" + newName;


                FileController.Rename(oldPath, newPath);
            }
        }

        public void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            List<ItemPath> paths = GetListMapPath();
            string dir = Utility.GetDirFromPath(e.FullPath);
            string fileName = Utility.GetFilenameFromPath(e.FullPath);

            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
            {
                string filePath = item.Destination + "\\" + fileName;
                FileController.Delete(filePath);
            }
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            List<ItemPath> paths = GetListMapPath();
            string dir = e.FullPath.Substring(0, e.FullPath.LastIndexOf("\\"));
            ItemPath item = paths.Find(i => i.Source == dir);
            if (item != null)
                FileController.CopyFile(item.Source, item.Destination);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        public void ExecuteCommand(String command)
        {
            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = command;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo = startInfo;
            p.Start();
            p.WaitForExit();
            p.Exited += p_Exited;
        }

        private void p_Exited(object sender, EventArgs e)
        {
            log.Error(e);
        }
    }
}
