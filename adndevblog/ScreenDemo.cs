//by 鸟哥 qq1833183060
//qq群 720924083
//2020-11-07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Windows;

namespace adndevblog
{
    public class ScreenDemo
    {
        //参考自https://adndevblog.typepad.com/autocad/2012/03/control-the-autocad-screensize-environment-variable-in-autocad-using-net.html
        //系统变量SCREENSIZE是只读的，此方法可用于修改SCREENSIZE的值
        [CommandMethod("ChangeScreenSize")]
        public static void changeScreenSize(){

            Document doc = Application.DocumentManager.MdiActiveDocument;

            Autodesk.AutoCAD.Windows.Window docWindow = doc.Window;

            System.Drawing.Size size = docWindow.GetSize();

            Editor ed = doc.Editor;

            ed.WriteMessage("\nDocument Size:\n" +size.ToString() + "\n");

            docWindow.WindowState = Window.State.Normal;

            docWindow.SetSize(new System.Drawing.Size(500, 500));
        }

    }
}
