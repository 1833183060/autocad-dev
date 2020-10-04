//using MiniBlinkPinvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.Runtime.InteropServices;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
[assembly: ExtensionApplication(typeof(TerrainComputeC.My.InitClass))]

namespace TerrainComputeC.My
{     
    public class InitClass:IExtensionApplication
    {
        
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

            
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            
        }
        public void Initialize()
        {
            Document doc=Application.DocumentManager.MdiActiveDocument;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("\nTerrainCompute 正在初始化...");
            try
            {                
                string lispPath = "agilePluginCmds.lsp";
                string loadStr = "(load \"" + InitClass.AssemblyDirectory + "\\" + lispPath + "\") ";
                loadStr = loadStr.Replace("\\", "\\\\");
                ed.WriteMessage(loadStr);
                //ed.WriteMessage(acedPostCommand12==null);
                //myCommand(loadStr);                
                //ProcessBackground();
                //BlinkBrowserPInvoke.ResourceAssemblys.Add("MiniBlinkPinvokeDemo", System.Reflection.Assembly.GetExecutingAssembly());
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage("\n" + ex.Message);
            }
            
        }

        public static void myCommand(string cmd)
        {
            int r = -1;
            try
            {
                //acedPostCommand(cmd);
                r = 0;
            }
            catch (System.Exception ex)
            {

            }
            try
            {
                if (r != 0)
                {
                    //acedPostCommand12(cmd);
                }
            }
            catch (System.Exception ex)
            {

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
