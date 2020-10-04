using System;
using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;

namespace TlsCad.RunTime
{

    public class Commands
    {

        [CommandMethod("NetLoadX")]
        public void NetLoad()
        {
#if NET20
            OpenFileDialog dlg =
                new OpenFileDialog(
                    "选择.Net程序集",
                    "",
                    "dll",
                    "NetLoadX",
                     OpenFileDialog.OpenFileDialogFlags.AllowMultiple);

            var res = dlg.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var name in dlg.GetFilenames())
                {
                    Loader loader = new Loader();
                    loader.Add(name.Replace("\\", "/"));
                }
            }
#elif NET45
            Autodesk.AutoCAD.Windows.OpenFileDialog dlg =
                new Autodesk.AutoCAD.Windows.OpenFileDialog(
                    "选择.Net程序集",
                    "",
                    "dll",
                    "NetLoadX",
                     Autodesk.AutoCAD.Windows.OpenFileDialog.OpenFileDialogFlags.AllowMultiple);

            var res = dlg.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var name in dlg.GetFilenames())
                {
                    Loader loader = new Loader();
                    loader.Add(name.Replace("\\", "/"));
                }
            }
#endif
        }


    }

}
