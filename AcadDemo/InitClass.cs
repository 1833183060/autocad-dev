
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.CodeDom;
using System.Runtime.InteropServices;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
[assembly: ExtensionApplication(typeof(AcadUtil.InitClass))]
namespace AcadUtil
{     
    public class InitClass:IExtensionApplication
    {
        #region 静态成员
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("acad.exe", EntryPoint = "acedCmd", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int acedCmd(IntPtr resbuf);
        //?acedPostCommand@@YAHPEB_W@Z
        //?acedPostCommand@@YAHPB_W@Z
        [DllImport("acad.exe", CharSet = CharSet.Auto,CallingConvention = CallingConvention.Cdecl,EntryPoint = "?acedPostCommand@@YAHPEB_W@Z")]
        extern static private int acedPostCommand(string strExpr);
        [DllImport("acad.exe", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl, EntryPoint = "?acedPostCommand@@YAHPB_W@Z")]
        extern static private int acedPostCommand12(string strExpr);

        static System.Windows.Forms.UserControl syncCtrl;
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        public static Assembly interopA;
        public static Assembly commonA;
        static InitClass()
        {
            ;
            syncCtrl = new System.Windows.Forms.UserControl();

            syncCtrl.CreateControl();

            string dllPath = InitClass.AssemblyDirectory;
            string pf=(string)Application.GetSystemVariable("platform");
            if (pf.IndexOf("x86") > 0)
            {
                dllPath += "\\x86";
            }
            else
            {
                dllPath += "\\x64";
            }
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage(dllPath);
            //commonA = Assembly.LoadFrom(dllPath+"\\Autodesk.AutoCAD.Interop.Common.dll");
             //interopA = Assembly.LoadFrom(dllPath + "\\Autodesk.AutoCAD.Interop.dll");
        }

#endregion

        private Document document;
        public void Initialize()
        {
            Document doc=Application.DocumentManager.MdiActiveDocument;
            this.document = doc;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\nAgile plugin正在初始化...");
            try
            {

                //Type t = InitClass.interopA.GetType("Autodesk.AutoCAD.Interop.AcadApplication");
//Autodesk.AutoCAD.Interop.AcadApplication acadApp = Autodesk.AutoCAD.ApplicationServices.Application.AcadApplication as Autodesk.AutoCAD.Interop.AcadApplication;
                //Autodesk.AutoCAD.Interop.AcadApplication acadApp = (Autodesk.AutoCAD.Interop.AcadApplication)Activator.CreateInstance(System.Type.GetTypeFromProgID("AutoCAD.Application.18")); ;
                //Autodesk.AutoCAD.Interop.AcadApplication app = (Autodesk.AutoCAD.Interop.AcadApplication)Marshal.GetActiveObject("AutoCAD.Application.18");
                //ed.WriteMessage(acadApp.ToString());
            //acadApp.MenuGroups
                //MyMenu.ShowMyMenu();
                //MyMenu.cuiMenu();
                //myCommand("mycui ");
                string lispPath = "agilePluginCmds.lsp";
                string loadStr = "(load \"" + InitClass.AssemblyDirectory + "\\" + lispPath + "\") ";
                loadStr = loadStr.Replace("\\", "\\\\");
                ed.WriteMessage(loadStr);
                //ed.WriteMessage(acedPostCommand12==null);
                myCommand(loadStr);
                ResultBuffer args = new ResultBuffer(
                    new TypedValue((int)LispDataType.Text, loadStr)/*,
                    new TypedValue((int)LispDataType.Text, "_arc"),
                    new TypedValue((int)LispDataType.Double, 2.0 / scale),
                    new TypedValue((int)LispDataType.Double, 6.0 / scale),
                    new TypedValue((int)LispDataType.Text, "_object"),
                    new TypedValue((int)LispDataType.ObjectId, id),
                    new TypedValue((int)LispDataType.Text, "_no")*/);
                //acedCmd(args.UnmanagedObject);
                //ProcessBackground();
                Initialize2();
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage("\n" + ex.Message);
            }
            
        }
        public void Initialize2()
        {
            if (true)
            {
                try
                {
                    BackgroundWorker backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += new DoWorkEventHandler(this.method_0);
                    backgroundWorker.RunWorkerAsync();
                }
                catch (System.Exception ex)
                {
                    Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
                    editor.WriteMessage("\nError: " + ex.ToString());
                }
            }
        }

        private void method_0(object sender, DoWorkEventArgs e)
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    
                    this.document.SendStringToExecute("ng:MENU:DELETE ", false, false, false);
                    this.document.SendStringToExecute("ng:MENU:CREATE ", false, false, false);
                    break;
                }
                catch (System.Exception ex)
                {
                    Thread.Sleep(500);
                }
            }
        }

        public static void myCommand(string cmd)
        {
            int r = -1;
            try
            {
                acedPostCommand(cmd);
                r = 0;
            }
            catch (System.Exception ex)
            {

            }
            try
            {
                if (r != 0)
                {
                    acedPostCommand12(cmd);
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        public static void myCommand2(string cmd)
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    Document document_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                    document_0.SendStringToExecute(cmd, false, false, false);
                    break;
                }
                catch (System.Exception ex)
                {
                    Thread.Sleep(500);
                }
            }
        }

        public void Terminate()
        {
            System.Diagnostics.Debug.WriteLine(
        "程序结束，你可以在里做一些程序的清理工作，如关闭AutoCAD文档");
        }

        void BackgroundProcess()
    {       

      if (syncCtrl.InvokeRequired)
        syncCtrl.Invoke(new FinishedProcessingDelegate(FinishedProcessing));

      else
        FinishedProcessing();
    } 

    delegate void FinishedProcessingDelegate();

    void FinishedProcessing()
    {
        myCommand("mycui ");
    }
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        BackgroundProcess();
    }

    public void ProcessBackground()
    {
        
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 5000;
                timer.AutoReset = false;
                timer.Enabled = true;
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);   
    }
    }
}
