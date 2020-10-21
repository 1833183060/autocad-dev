using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using Newtonsoft.Json;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
namespace MyList
{
    public class PostInfo
    {
        private IAttrRef attrRef;
        public PostInfo()
        {
            if (User.sName == null || User.sPass == null)
            {
                bool r=User.login();
                if (r)
                {

                }
            }
            user = new User();
            //drawing = new Drawing();
            bomList = new List<Bom>();
        }
        public User user { get; set; }
        public Drawing drawing { get; set; }
        public List<Bom> bomList { get; set; }
        public void writeBlockName(string n)
        {
            if (n == "PC_TITLE_BLOCK" || n == "MIRACLETKAA2" || n == "MIRACLETKAA3" || n == "MIRACLETKAA4" || n.StartsWith("MIRACLETK"))
            {
                attrRef = drawing = new Drawing();
            }
            else if (n == "PC_MXB_BLOCK"||n=="mxb1"||n=="mxb2"||n.StartsWith("mxb"))
            {
                Bom b=new Bom();
                attrRef = b;
                bomList.Add(b);
            }
            else
            {
                attrRef = null;
            }
        }
        public void writeAttrRef(string tag, string val)
        {
            if (attrRef == null) return;
            attrRef.write(tag, val);
        }
        public void endWrite()
        {
            if (drawing == null)
            {
                System.Windows.Forms.MessageBox.Show("图块名称不符合要求");
            }
            Document curDoc = Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed = curDoc.Editor;
            if (User.sName == null || User.sPass == null)
            {
                ed.WriteMessage("\ny用户名或密码为空");
                return;
            }
            try
            {
                string docName = Drawing.getDocName();
                if (docName == null)
                {
                    System.Windows.Forms.MessageBox.Show("文件名不能为空");
                    return;
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage("ex85:" + ex.Message + ex.StackTrace);
            }
            try
            {
                ed.WriteMessage("drawing:" + drawing.ToString());
                ed.WriteMessage("drawing.path:" + drawing.path);
                bool r = MyNet.ftpUpLoadFile(drawing.path, Drawing.getFullPath());
                if (r)
                {
                    string str = JsonConvert.SerializeObject(this, Formatting.None);
                    ed.WriteMessage("\nstr:" + str);
                    MyNet.postData(str);
                }
            }
            catch (System.Exception ex2)
            {
                ed.WriteMessage("\nex92:" + ex2.Message);
            }
        }
    }
}
