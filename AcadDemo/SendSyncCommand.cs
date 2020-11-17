//用acedCmd发送命令如何等待用户输入
//参考：https://adndevblog.typepad.com/autocad/2012/04/synchronously-send-and-wait-for-commands-in-autocad-using-c-net.html
//qq群：720924083
//2020-11-17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Windows;
namespace AcadDemo
{
    public class SendSyncCommand
    {
    // call the insert command and wait until the user has finished, by Fenton Webb, DevTech
    
        [DllImport("acad.exe", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl, EntryPoint = "acedCmd")]
        private static extern int acedCmd(System.IntPtr vlist);
     
        [CommandMethod("Test7")]
        public void Test7()
        {
            ResultBuffer rb = new ResultBuffer();
            // RTSTR = 5005
            rb.Add(new TypedValue(5005, "_.INSERT"));
            // start the insert command

            acedCmd(rb.UnmanagedObject);
            bool quit = false;
            // loop round while the insert command is active
            while (!quit)
            {
            // see what commands are active

                string cmdNames = (string)Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("CMDNAMES");

                // if the INSERT command is active

                if (cmdNames.ToUpper().IndexOf("INSERT") >= 0)
                {
                    // then send a PAUSE to the command line
                    rb = new ResultBuffer();
                    // RTSTR = 5005 - send a user pause to the command line

                    rb.Add(new TypedValue(5005, "\\"));

                    acedCmd(rb.UnmanagedObject);
                }
                else
                    // otherwise quit
                    quit = true;

                }
        }   
    }
}
