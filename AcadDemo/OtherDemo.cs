//by 鸟哥 qq1833183060
//qq群 720924083
//2020-11-10
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
namespace AcadDemo
{
    public class OtherDemo
    {
        /// <summary>
        /// https://adndevblog.typepad.com/autocad/2012/04/converting-geometry-objects-to-database-entity.html
        /// </summary>
        [CommandMethod("ge2dbnet")]
        public void Ge2DbMethod()
        {
             EllipticalArc3d arc1 =new EllipticalArc3d(Point3d.Origin,Vector3d.XAxis,Vector3d.YAxis,2.0, 0.5); 

            GetCurveObjectId(arc1);
        } 

        static ObjectId GetCurveObjectId(Curve3d geCurve3d)
        {
            Document doc  = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            ObjectId oid = ObjectId.Null;
            try
            {
                Curve dbCurve = Curve.CreateFromGeCurve(geCurve3d);

                if (dbCurve != null)
                {
                    using (Transaction tr =db.TransactionManager.StartTransaction())
                    {
                        BlockTable bt = tr.GetObject(db.BlockTableId,OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr =tr.GetObject(db.CurrentSpaceId,OpenMode.ForWrite) as BlockTableRecord;
                        btr.AppendEntity(dbCurve);
                        tr.AddNewlyCreatedDBObject(dbCurve, true);
                        tr.Commit();
                     }
                 }
            }

            catch (System.Exception ex)
            {
                ed.WriteMessage(ex.Message);
            }
            return oid;
        }
    }
}
