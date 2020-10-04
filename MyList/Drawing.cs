using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
namespace MyList
{
    public class Drawing:IAttrRef
    {
        public string docNumber { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string material { get; set; }
        public string singleWeight { get; set; }
        public string path { get; set; }

        public Drawing()
        {
            //path = getFullPath();
            //path = "/iNode Management Center for Windows 7.3 (E0536).exe";
            path =  "/agileFile/" + getDocName();
        }
        public void write(string tag, string text)
        {
            switch (tag)
            {
                case "本级图纸名称":
                case "MINGCHENG":
                    name = text;
                    break;
                case "重量":
                case "ZHONGLIANG":
                    singleWeight = text;
                    break;
                case "材料":
                case "CAILIAO":
                    material = text;
                    break;
                case "图号":
                case "TUHAO":
                    docNumber = text;
                    break;
                
            }
        }
        public static string getFullPath()
        {
            Document curDoc = Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed = curDoc.Editor;
            string fullPath = "";
            //fullPath=db.Filename;
            fullPath = Application.GetSystemVariable("dwgprefix").ToString() + Application.GetSystemVariable("dwgname").ToString();
            ed.WriteMessage("\nfullPath:" + fullPath + "\n");
            return fullPath;
        }
        public static string getDocName()
        {

            object sys = null;
            try { 
            sys=Application.GetSystemVariable("dwgname");
            if(sys==null){
                return null;
            }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ex"+ex.Message);
            }
            return sys.ToString();
        }
    }
}

/*tag:本级图纸名称--value:循环泵支架
tag:共几张--value:1
tag:第几张--value:1
tag:重量--value:141
tag:材料--value:组合件
tag:图号--value:PMT1809-PT-1703
tag:日期--value:2018.11.26
tag:数量--value:1
tag:比例--value:1:10
tag:上级图纸名称--value:外部循环管路
tag:项目名称--value:田盛电泳线*/
