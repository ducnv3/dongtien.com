using DongTien.Common.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DongTien.Common
{
    public static class ClientConfiguration
    {
        public static void SaveConfigApp(string username, string password, bool isSync)
        {
            string _isSync = isSync == true ? "true" : "false";

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            config.AppSettings.Settings.Remove(Constants.Username);
            config.AppSettings.Settings.Add(Constants.Username, username);

            config.AppSettings.Settings.Remove(Constants.Password);
            config.AppSettings.Settings.Add(Constants.Password, password);

            config.AppSettings.Settings.Remove(Constants.Sync);
            config.AppSettings.Settings.Add(Constants.Sync, _isSync);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        public static void SaveMapPathToXML(DataGridView gridviewPath)
        {
            try
            {
                DataTable dt = new DataTable("ItemPath");
                for (int i = 0; i < gridviewPath.ColumnCount; i++)
                {
                    dt.Columns.Add(gridviewPath.Columns[i].Name, typeof(System.String));
                }

                int numOfCol = gridviewPath.Columns.Count;
                foreach (DataGridViewRow drow in gridviewPath.Rows)
                {
                    DataRow myrow = dt.NewRow();
                    for (int i = 0; i < numOfCol; i++)
                    {
                        myrow[i] = drow.Cells[i].Value;
                    }
                    dt.Rows.Add(myrow);
                }
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                dt.WriteXml(Constants.MAPPING_FILENAME);

                MessageDialogs.SaveSucess();
            }
            catch (Exception e)
            {
                MessageDialogs.Error();
            }
        }

        public static void LoadMapPathFromXML(DataGridView dataGridView)
        {
            try
            {
                List<ItemPath> paths = GetListMapPath();
                foreach(ItemPath path in paths)
                {
                    dataGridView.Rows.Add(path.Source, path.Destination);
                }
            }
            catch (IOException e)
            {
                //log.Error(e.Message);
            }
        }

        public static void SaveConfigApp(bool isSync)
        {
            throw new NotImplementedException();
        }

        public static List<ItemPath> GetListMapPath()
        {
            try
            {
                var xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                FileStream fs = new FileStream(Constants.MAPPING_FILENAME, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("ItemPath");

                List<ItemPath> paths = new List<ItemPath>();

                for (int i = 0; i < xmlnode.Count; i++)
                {
                    ItemPath item = new ItemPath();
                    string source = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    string destination = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    //dataGridView.Rows.Add(source, destination);
                    item.Source = source;
                    item.Destination = destination;
                    paths.Add(item);
                }

                fs.Close();

                return paths;
            }
            catch (IOException e)
            {
                //log.Error(e.Message);
                return new List<ItemPath>();
            }
        }
    }

    public static class ServerConfiguaration
    {
        public static void SaveConfigApp(bool isSync)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);

            string _isSync = isSync == true ? "true" : "false";

            config.AppSettings.Settings.Remove(Constants.Sync);
            config.AppSettings.Settings.Add(Constants.Sync, _isSync);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        public static void SaveMapPathToXML(DataGridView gridviewPath)
        {
            try
            {
                DataTable dt = new DataTable("ItemPath");
                for (int i = 0; i < gridviewPath.ColumnCount; i++)
                {
                    dt.Columns.Add(gridviewPath.Columns[i].Name, typeof(System.String));
                }

                int numOfCol = gridviewPath.Columns.Count;
                foreach (DataGridViewRow drow in gridviewPath.Rows)
                {
                    DataRow myrow = dt.NewRow();
                    for (int i = 0; i < numOfCol; i++)
                    {
                        myrow[i] = drow.Cells[i].Value;
                    }
                    dt.Rows.Add(myrow);
                }
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                dt.WriteXml(Constants.MAPPING_FILENAME);

                MessageDialogs.SaveSucess();
            }
            catch (Exception e)
            {
                MessageDialogs.Error();
            }
        }
    }
}
