using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MyList
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void onLoginClicked()
        {
            string name = txtName.Text.Trim();
            string pass = txtPass.Text.Trim();
            if (name.Length == 0 || pass.Length == 0)
            {
                MessageBox.Show("用户名和密码不能为空!");
                return;
            }
            //string url = "http://10.9.37.100:8099/agile/login?username=" + name + "&password=" + pass;
            string url = "http://10.9.37.21:8099/agile/login?username=" + name + "&password=" + pass;
        
            System.Net.HttpWebRequest req =
(System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            req.Method = "GET";
            //req.TransferEncoding = "utf-8";
            HttpWebResponse myResponse = null;
            try
            {
                myResponse = req.GetResponse() as HttpWebResponse;
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string res = sr.ReadToEnd();
                //MessageBox.Show("aaa:" + res);
                LoginReturn r = JsonConvert.DeserializeObject<LoginReturn>(res);
                if (r.status == 200)
                {
                    //MessageBox.Show(r.msg);
                    User.sName = name;
                    User.sPass = pass;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //MessageBox.Show(r.msg); 
                    MessageBox.Show(res);
                    //MessageBox.Show(r.status.ToString());

                }

                //return res;
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void onLoginClicked(object sender, EventArgs e)
        {
            onLoginClicked();
        }
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
onLoginClicked();
            }
            
        }
    }
}
