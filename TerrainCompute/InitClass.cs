
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
[assembly: ExtensionApplication(typeof(MyList.InitClass))]
namespace MyList
{
    public class InitClass:IExtensionApplication
    {

        public void Initialize()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("正在初始化...");
            Autodesk.AutoCAD.Interop.AcadApplication acadApp = Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication as Autodesk.AutoCAD.Interop.AcadApplication;
            //acadApp.MenuGroups
            //MyMenu.ShowMyMenu();
        }

        public void Terminate()
        {
            System.Diagnostics.Debug.WriteLine(
        "程序结束，你可以在里做一些程序的清理工作，如关闭AutoCAD文档");
        }
    }
}
