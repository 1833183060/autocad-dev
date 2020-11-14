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
using Autodesk.AutoCAD.Geometry;

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

        /// <summary>
        /// 获取autocad模型空间窗口大小
        /// 参考 https://adndevblog.typepad.com/autocad/2012/04/getting-the-extents-of-autocad-model-window.html
        /// </summary>
        [CommandMethod("ScreenExtents")]
        public void ScreenExtents()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            Database db = doc.Database;

            Editor ed = doc.Editor;
            Point2d screenSize = (Point2d)Application.GetSystemVariable("SCREENSIZE");
            System.Drawing.Point upperLeft = new System.Drawing.Point(0, 0);
            System.Drawing.Point lowerRight = new System.Drawing.Point((int)screenSize.X,(int)screenSize.Y);
            Point3d upperLeftWorld = ed.PointToWorld(upperLeft, 0);

            Point3d lowerRightWorld = ed.PointToWorld(lowerRight, 0);
            using (Transaction Tx = db.TransactionManager.StartTransaction())
            {
                //Draws a line to visualize result...

                Line line = new Line(upperLeftWorld, lowerRightWorld);

                BlockTableRecord btr = Tx.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                btr.AppendEntity(line);

                Tx.AddNewlyCreatedDBObject(line, true);
                Tx.Commit();
            }
        }
    }
}
