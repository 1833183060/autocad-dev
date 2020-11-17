//用拷贝Database
//参考：https://adndevblog.typepad.com/autocad/2012/04/how-to-make-a-copy-of-the-autocad-database.html
//qq群：720924083
//2020-11-17
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
namespace AcadDemo
{
    public class CopyDatabase
    {
        [CommandMethod("CopyDatabase")]

        static public void CopyDatabase()
        {

            Document doc =

                Application.DocumentManager.MdiActiveDocument;

            Database db = doc.Database;

            Database newDb = null;

            using (newDb = db.Wblock())
            {

                //use the newDb.

            }

        }
    }
}
