using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;


using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace MyList
{
    public class MyNet
    {
        public static void postData(string paramData)
        {
            Document curDoc =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed = curDoc.Editor;
            try
            {
                ed.WriteMessage(paramData);
                string responseContent = "";
                //string postUrl = "http://10.9.37.100:8099/agile/save"; 
                string postUrl = "http://10.9.37.21:8099/agile/save";

                byte[] byteArray = Encoding.UTF8.GetBytes(paramData); //转化
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST"; 
                //webReq.TransferEncoding = "utf-8";
                //webReq.SendChunked = true;
                webReq.Headers.Add("charset", "utf-8");
                webReq.ContentType = "application/json";
                webReq.ContentLength = byteArray.Length;
                using (Stream reqStream = webReq.GetRequestStream())
                {
                    reqStream.Write(byteArray, 0, byteArray.Length);//写入参数
                    //reqStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)webReq.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseContent = sr.ReadToEnd().ToString();
                        LoginReturn r = JsonConvert.DeserializeObject<LoginReturn>(responseContent);
                        if (r.status == 200)
                        {
                            System.Diagnostics.Process.Start(r.msg);
                        }
                        else
                        {
                            MessageBox.Show(responseContent);
                        }
                        
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ex68:"+ex.Message);
            }
        }
        public static bool ftpUpLoadFile(string remoteFile, string localFile) {
             Document curDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Database db = curDoc.Database;
                Editor ed = curDoc.Editor;
                bool ret = false;
            try
            {
                
                FtpWebRequest ftpRequest = null;
                //string host = "ftp://10.9.37.100";
                string host = "ftp://10.9.37.21";
                bool BinaryMode = true;
                Stream ftpStream = null;
                int bufferSize = 8192;
                string en=System.Web.HttpUtility.UrlEncode(host + remoteFile, Encoding.UTF8);
                /* Create an FTP Request */
                //ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/agileFile/"+remoteFile );
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                //Uri u=new Uri()
                //ftpRequest.Credentials = new NetworkCredential("plmftp", "abc123@");
                ftpRequest.Credentials = new NetworkCredential("ftp", "Czz3906270@");
                /* When in doubt, use these options */
                ftpRequest.UseBinary = BinaryMode;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                //ftpRequest.
                //文件是否存在////////////////////
                /*ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();

                long fileSize = response.ContentLength;

                response.Close();
                MessageBox.Show(fileSize.ToString());
                */
                //objReqFtp = null;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFile,FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
                ed.WriteMessage("open file\n");
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                    ed.WriteMessage("read file\n");
                    ret = true;
                }                    
                catch (System.Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            catch (IOException ioex)
            {
                ed.WriteMessage(ioex.Message);
                MessageBox.Show(ioex.ToString()+" "+remoteFile);
            }
            catch (System.Exception ex) {
                MessageBox.Show(ex.ToString() + " " + remoteFile);
            }
            return ret;
        }
        public void put(string remoteFile, string localFile)
        {
            try
            {
                FtpWebRequest ftpRequest = null;
                string host = "";
                bool BinaryMode = true;
                Stream ftpStream = null;
                int bufferSize = 8192;
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                //ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = BinaryMode;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFile, FileMode.Open);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (System.Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            catch (System.Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }


    }
}
