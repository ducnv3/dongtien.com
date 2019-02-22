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

namespace DongTien.ClientApp
{
    public partial class FormClient : Form
    {
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

            LoadConfigFromXML();
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

        private void LoadConfigFromXML()
        {
            try
            {
                var xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                int i = 0;
                string str = null;
                FileStream fs = new FileStream("AppConfig.xml", FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("ItemPath");

                List<ItemPath> lstPathItem = new List<ItemPath>();

                for (i = 0; i < xmlnode.Count; i++)
                {
                    ItemPath path = new ItemPath();
                    path.Source = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    path.Destination = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    lstPathItem.Add(path);

                    this.gridviewPath.Rows.Add(path.Source, path.Destination);
                }

                fs.Close();
            }
            catch (IOException e)
            {

            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {

        }

        public void FileWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Path = @"\\192.168.1.9\Shared\";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                         | NotifyFilters.FileName | NotifyFilters.DirectoryName; ;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += watcher_Deleted;
            watcher.Renamed += watcher_Renamed;
            watcher.EnableRaisingEvents = true;
        }

        public void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Rename: " + e.Name);
            Console.WriteLine("Rename: " + e.FullPath);
        }

        public void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Delete: " + e.FullPath);
        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed: " + e.Name);
            Console.WriteLine("Changed: " + e.FullPath);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}
