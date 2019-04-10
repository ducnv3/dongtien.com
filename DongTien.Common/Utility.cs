using DongTien.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DongTien.Common
{
    public static class Utility
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            try
            {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            // Get the key from config file

            string key = Constants.StringKey;

            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);


                string key = Constants.StringKey;

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception e)
            {
                log.Error("Error - Decrypt", e);
                return string.Empty;
            }

        }

        public static String GetFilenameFromPath(string path)
        {
            return string.IsNullOrEmpty(path) ? string.Empty : path.Substring(path.LastIndexOf("\\") + 1) ;
        }

        public static String GetDirFromPath(string path)
        {
            return string.IsNullOrEmpty(path) ? string.Empty : path.Substring(0, path.LastIndexOf("\\"));
        }

        public static void ExecuteCommand(String command, EventHandler e)
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
            p.Exited += e;
        }


        public static List<ItemPath> GetListMapPath(string filename)
        {
            try
            {
                var xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("ItemPath");

                List<ItemPath> paths = new List<ItemPath>();

                for (int i = 0; i < xmlnode.Count; i++)
                {
                    ItemPath item = new ItemPath();
                    string source = xmlnode[i].ChildNodes.Item(0) == null ? string.Empty : xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    string destination = xmlnode[i].ChildNodes.Item(1) == null ? string.Empty : xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                    string description = xmlnode[i].ChildNodes.Item(2) == null ? string.Empty : xmlnode[i].ChildNodes.Item(2).InnerText.Trim();

                    item.Source = source;
                    item.Destination = destination;
                    item.Note = description;

                    paths.Add(item);
                }

                fs.Close();

                return paths;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                return new List<ItemPath>();
            }
        }


        public static List<ItemPath> GetListAllowPath(string filename)
        {
            try
            {
                var xmldoc = new XmlDataDocument();
                XmlNodeList xmlnode;
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("ItemPath");

                List<ItemPath> paths = new List<ItemPath>();

                for (int i = 0; i < xmlnode.Count; i++)
                {
                    ItemPath item = new ItemPath();
                    string source = xmlnode[i].ChildNodes.Item(0) == null ? string.Empty : xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    item.Source = source;
                    paths.Add(item);
                }

                fs.Close();

                return paths;
            }
            catch (IOException e)
            {
                log.Error(e.Message);
                return new List<ItemPath>();
            }
        }

        public static String GetIpServerFromPath(string path)
        {
            int index1 = path.IndexOf("\\\\");
            int index2 = path.IndexOf("\\",index1 + 2);
            if(index1 == 0 && index2 > index1)
            {
                string ip = path.Substring(index1 + 2, index2 - index1 - 2);
                return ip;
            }
            return "";
        }

        public static bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.Any(c => c > MaxAnsiCode);
        }

    }
}
