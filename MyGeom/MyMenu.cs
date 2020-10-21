using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
//using Autodesk.AutoCAD.Interop;

using Autodesk.AutoCAD.Customization;
using System.Collections.Specialized;
namespace MyList
{
   
    public class MyMenu
    {
        [CommandMethod("aa")]
        public void aa()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            string lispPath = "agilePluginCmds.lsp";
            string loadStr ="(load \""+InitClass.AssemblyDirectory+"\\"+ lispPath+"\") ";
            loadStr = loadStr.Replace("\\", "\\\\");
            doc.SendStringToExecute(loadStr, false, false, false);
            //ed.Document.AcadDocument
            
        }
        [CommandMethod("SMM")]
        public static void ShowMyMenu()
        {
            string menuName = "Agile";
            //获取CAD应用程序
            //AcadApplication app = (AcadApplication)Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication;
           // Autodesk.AutoCAD.Interop.AcadApplication app = (Autodesk.AutoCAD.Interop.AcadApplication)Activator.CreateInstance(System.Type.GetTypeFromProgID("AutoCAD.Application.18"));
            
            /*Autodesk.AutoCAD.Interop.AcadApplication app = (Autodesk.AutoCAD.Interop.AcadApplication)  Marshal.GetActiveObject("AutoCAD.Application.18");
            for (int i = 0; i < app.MenuGroups.Item(0).Menus.Count; i++)
            {
                if (app.MenuGroups.Item(0).Menus.Item(i).Name == menuName)  //判断菜单是否已存在，如果存在则不再创建
                    return;
            }

            AcadPopupMenu pmParnet = app.MenuGroups.Item(0).Menus.Add(menuName);  //添加根菜单
            */
            //多级
            /*AcadPopupMenu pm = pmParnet.AddSubMenu(pmParnet.Count + 1, "打开");
            AcadPopupMenuItem pmi0 = pm.AddMenuItem(pm.Count + 1, "文件  ", "OPEN1\n");  //第一个参数是在菜单项中的位置（第几项），第二个参数是显示的名称，第三个参数是点击之后执行的命令
            AcadPopupMenuItem pmi1 = pm.AddMenuItem(pm.Count + 1, "模版  ", "OPEN2\n");*/

            //单级
            /*AcadPopupMenuItem pmi2 = pmParnet.AddMenuItem(pmParnet.Count + 1, "登录", "login\n");
            AcadPopupMenuItem pmi3 = pmParnet.AddMenuItem(pmParnet.Count + 1, "上传", "getattr\n");

            //将创建的菜单加入到CAD的菜单中
            pmParnet.InsertInMenuBar(app.MenuBar.Count + 1);*/
        }
         [CommandMethod("mycui")]
        public static void cuiMenu()
        {
            string loadStr = "cuiload \"" + InitClass.AssemblyDirectory + "\\" + "agilePlugin.cuix\" ";
            //loadStr = loadStr.Replace("\\", "\\\\");
            object oldCmdEcho =Application.GetSystemVariable("CMDECHO");

            object oldFileDia =Application.GetSystemVariable("FILEDIA");

            Application.SetSystemVariable("CMDECHO", 0);

            Application.SetSystemVariable("FILEDIA", 0);
            InitClass.myCommand(loadStr);
            InitClass.myCommand("cmdecho "+oldCmdEcho.ToString()+" ");
            //Application.SetSystemVariable("CMDECHO", oldCmdEcho);
            InitClass.myCommand("FILEDIA " + oldFileDia.ToString() + " ");
            //Application.SetSystemVariable("FILEDIA", oldFileDia);
        }
        [CommandMethod("SMM2")]
        public static void cuiMenu2()
        {
            //自定义的组名
            string strMyGroupName = "AgileGroup";
            //保存的CUI文件名（从CAD2010开始，后缀改为了cuix）
            string strCuiFileName = "AgileMenu.cuix";

            //创建一个自定义组（这个组中将包含我们自定义的命令、菜单、工具栏、面板等）
            CustomizationSection myCSection = new CustomizationSection();
            myCSection.MenuGroupName = strMyGroupName;

            //创建自定义命令组
            MacroGroup mg = new MacroGroup("MyMethod", myCSection.MenuGroup);
            MenuMacro mm1 = new MenuMacro(mg, "login", "^C^Clogin", "id_login");
            MenuMacro mm2 = new MenuMacro(mg, "getattr", "^C^Cgetattr", "id_getattr");

            //声明菜单别名
            StringCollection scMyMenuAlias = new StringCollection();
            scMyMenuAlias.Add("POP1");
            //菜单项（将显示在项部菜单栏中）
            PopMenu pmParent = new PopMenu("Agile", scMyMenuAlias, "ID_Agile", myCSection.MenuGroup);

            //子项的菜单（多级）
            //PopMenu pm1 = new PopMenu("打开", new StringCollection(), "", myCSection.MenuGroup);
            //PopMenuRef pmr1 = new PopMenuRef(pm1, pmParent, -1);
            PopMenuItem pmi1 = new PopMenuItem(mm1, "登录", pmParent, -1);
            PopMenuItem pmi2 = new PopMenuItem(mm2, "上传", pmParent, -1);

            //子项的菜单（单级）
            //PopMenuItem pmi3 = new PopMenuItem(mm3, "保存(&S)", pmParent, -1);

            // 最后保存文件
            //myCSection.SaveAs(strCuiFileName);
            //Autodesk.AutoCAD.ApplicationServices.Application.LoadPartialMenu("");
            
        }
    }
}
