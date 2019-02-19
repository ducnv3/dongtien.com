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

namespace DongTien.ClientApp
{
    public partial class FormClient : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FormClient()
        {
            InitializeComponent();
            ConfigForm();
            LoadConfigApp();
        }

        private void ConfigForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void LoadConfigApp()
        {
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            string isSync = ConfigurationManager.AppSettings["Sync"];

            LoadConfigFromXML();
        }

        private void btn_saveConfig_Click(object sender, EventArgs e)
        {
            SaveConfigToXML();
        }

        private void SaveConfigToXML()
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
    }
}
