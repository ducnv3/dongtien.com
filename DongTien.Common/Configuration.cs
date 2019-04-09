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
using System.Xml.Linq;
using System.Xml.Schema;

namespace DongTien.Common
{
    public static class ClientConfiguration
    {
        public static int SaveConfigApp(string username, string password,
            string ipServer, bool isSync)
        {
            try
            {
                string filename = "ConfigApp.xml";

                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("configurations");
                xmlDoc.AppendChild(rootNode);

                XmlNode userNode = xmlDoc.CreateElement("Username");
                userNode.InnerText = username;
                rootNode.AppendChild(userNode);

                userNode = xmlDoc.CreateElement("Password");
                userNode.InnerText = password;
                rootNode.AppendChild(userNode);

                userNode = xmlDoc.CreateElement("IpServer");
                userNode.InnerText = ipServer;
                rootNode.AppendChild(userNode);

                userNode = xmlDoc.CreateElement("Sync");
                userNode.InnerText = isSync.ToString();
                rootNode.AppendChild(userNode);

                xmlDoc.Save(filename);

                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static List<String> LoadConfigApp()
        {
            string filename = "ConfigApp.xml";
            try
            {
                var data = new List<string>();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filename);

                XmlNodeList userNodes = xmlDoc.SelectNodes("//configurations//Username");
                data.Add(userNodes[0].InnerText);

                userNodes = xmlDoc.SelectNodes("//configurations//Password");
                data.Add(userNodes[0].InnerText);

                userNodes = xmlDoc.SelectNodes("//configurations//IpServer");
                data.Add(userNodes[0].InnerText);

                userNodes = xmlDoc.SelectNodes("//configurations//Sync");
                data.Add(userNodes[0].InnerText);

                return data;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public static int SaveMapPathToXML(DataGridView gridviewPath)
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
                dt.WriteXml(Constants.MAPPING_CLIENT_FILENAME);

                return 1;
            }
            catch (Exception)
            {
                MessageDialogs.Error();
                return -1;
            }
        }

        public static void LoadMapPathFromXML(DataGridView dataGridView)
        {
            try
            {
                List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_CLIENT_FILENAME);
                DataTable dt = new DataTable();
                dt.Columns.Add("col_source");
                dt.Columns.Add("col_destination");
                dt.Columns.Add("col_description");
                foreach (ItemPath path in paths)
                {
                    DataRow row = dt.NewRow();
                    row["col_source"] = path.Source;
                    row["col_destination"] = path.Destination;
                    row["col_description"] = path.Note;
                    // gridViewPath.Rows.Add(path.Source, path.Destination, path.Note);
                    dt.Rows.Add(row);
                }
                dataGridView.Columns[0].DataPropertyName = "col_source";
                dataGridView.Columns[1].DataPropertyName = "col_destination";
                dataGridView.Columns[2].DataPropertyName = "col_description";
                dataGridView.DataSource = dt;

            }
            catch (IOException e)
            {
                //log.Error(e.Message);
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

        // Save load map path
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
                dt.WriteXml(Constants.MAPPING_SERVER_FILENAME);

                MessageDialogs.SaveSucess();
            }
            catch (Exception e)
            {
                MessageDialogs.Error();
            }
        }
        public static void LoadMapPathFromXML(DataGridView gridViewPath)
        {
            try
            {
                List<ItemPath> paths = Utility.GetListMapPath(Constants.MAPPING_SERVER_FILENAME);
                foreach (ItemPath path in paths)
                {
                    gridViewPath.Rows.Add(path.Source, path.Destination, path.Note);
                }
            }
            catch (IOException e)
            {
                //log.Error(e.Message);
            }
        }

        // save load allow path
        public static void SaveAllowPathToXML(DataGridView gridviewPath)
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
                dt.WriteXml(Constants.ALLOW_PATHS);
                MessageDialogs.SaveSucess();
            }
            catch (Exception e)
            {
                MessageDialogs.Error();
            }
        }
        public static void LoadAllowPathFromXML(DataGridView gridViewPath)
        {
            try
            {
                List<ItemPath> paths = Utility.GetListAllowPath(Constants.ALLOW_PATHS);
                foreach (ItemPath path in paths)
                {
                    gridViewPath.Rows.Add(path.Source);
                }
            }
            catch (IOException e)
            {
                //log.Error(e.Message);
            }
        }

    }
}
