//参考https://adndevblog.typepad.com/autocad/2012/04/using-transient-graphics.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.GraphicsInterface;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

class TransientGraphics
{
    DBObjectCollection _markers = null;

    [CommandMethod("Test")]
    public void TestMethod()
    {
        Document activeDoc = Application.DocumentManager.MdiActiveDocument;
        Database db = activeDoc.Database;
        Editor ed = activeDoc.Editor;

        PromptEntityOptions peo = new PromptEntityOptions("Select a polyline : ");

        peo.SetRejectMessage("Not a polyline");
        peo.AddAllowedClass(typeof(Autodesk.AutoCAD.DatabaseServices.Polyline), true);

        PromptEntityResult per = ed.GetEntity(peo);

        if (per.Status != PromptStatus.OK)
            return;

        ObjectId plOid = per.ObjectId;

        PromptPointResult ppr = ed.GetPoint(new PromptPointOptions("Select an internal point : "));

        if (ppr.Status != PromptStatus.OK)

            return;

        Point3d testPoint = ppr.Value;

        PromptAngleOptions pao

            = new PromptAngleOptions("Specify ray direction");

        pao.BasePoint = testPoint;

        pao.UseBasePoint = true;

        PromptDoubleResult rayAngle = ed.GetAngle(pao);

        if (rayAngle.Status != PromptStatus.OK)
            return;
        Point3d tempPoint = testPoint.Add(Vector3d.XAxis);

        tempPoint = tempPoint.RotateBy(rayAngle.Value, Vector3d.ZAxis, testPoint);

        Vector3d rayDir = tempPoint - testPoint;

        ClearTransientGraphics();
        _markers = new DBObjectCollection();
        using (Transaction tr = db.TransactionManager.StartTransaction())
        {
            Curve plcurve = tr.GetObject(plOid, OpenMode.ForRead) as Curve;

            for (int cnt = 0; cnt < 2; cnt++)
            {
                if (cnt == 1)
                    rayDir = rayDir.Negate();

                using (Ray ray = new Ray())
                {

                    ray.BasePoint = testPoint;

                    ray.UnitDir = rayDir;
                    Point3dCollection intersectionPts = new Point3dCollection();

                    plcurve.IntersectWith(ray, Intersect.OnBothOperands, intersectionPts, IntPtr.Zero, IntPtr.Zero);

                    foreach (Point3d pt in intersectionPts)
                    {
                        Circle marker = new Circle(pt, Vector3d.ZAxis, 0.2);
                        marker.Color = Color.FromRgb(0, 255, 0);
                        _markers.Add(marker);

                        IntegerCollection intCol = new IntegerCollection();

                        TransientManager tm = TransientManager.CurrentTransientManager;
                        tm.AddTransient(marker, TransientDrawingMode.Highlight, 128, intCol);

                        ed.WriteMessage("\n" + pt.ToString());
                    }
                }
            }

            tr.Commit();
        }

    }



    void ClearTransientGraphics()
    {

        TransientManager tm

                = TransientManager.CurrentTransientManager;

        IntegerCollection intCol = new IntegerCollection();

        if (_markers != null)
        {

            foreach (DBObject marker in _markers)
            {

                tm.EraseTransient(

                                    marker,

                                    intCol

                                 );

                marker.Dispose();

            }

        }

    }
}