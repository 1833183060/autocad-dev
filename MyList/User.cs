using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
//using CsharpHttpHelper;
namespace MyList
{
    public class User
    {
        public  string userLoginId { get; set; }
        public  string password { get; set; }
        public static string sName { get; set; }
        public static string sPass { get; set; }
        public User(){
            userLoginId = sName;
            password = sPass;
        }
        [CommandMethod("login")]
        public void _login()
        {
            User.login();
        }
        public static bool login()
        {
            Login loginFrm = new Login();
            DialogResult r= loginFrm.ShowDialog();
            
            loginFrm.Dispose();
            return r == DialogResult.OK;
        }
        [CommandMethod("login2")]
        public static void login2()
        {
            
        }
        private void pageload()
        {

        }
        /*protected void Page_Load(object sender, EventArgs e)
        {
            //创建Httphelper对象
            HttpHelper http = new HttpHelper();
            //创建Httphelper参数对象
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项    
                Method = "post",//URL     可选项 默认为Get   
                ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                Postdata = "a=123&c=456&d=789",//Post要发送的数据
            };
            //请求的返回值对象
            HttpResult result = http.GetHtml(item);
            //获取请请求的Html
            string html = result.Html;
            //获取请求的Cookie
            string cookie = result.Cookie;
        }
        protected void Page_Load2(object sender, EventArgs e)
        {
            //创建Httphelper对象
            HttpHelper http = new HttpHelper();
            //创建Httphelper参数对象
            HttpItem item = new HttpItem()
            {
                URL = "http://www.sufeinet.com",//URL     必需项    
                Method = "get",//URL     可选项 默认为Get   
                ContentType = "text/html",//返回类型    可选项有默认值   
                //ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值   
            };
            //请求的返回值对象
            HttpResult result = http.GetHtml(item);
            //获取请请求的Html
            string html = result.Html;
            //获取请求的Cookie
            string cookie = result.Cookie;
        }*/
    }
}
