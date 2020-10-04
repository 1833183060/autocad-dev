using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TerrainComputeC.My
{
    public class MyHatch
    {
        public static Hatch NewHatch(ngeometry.VectorGeometry.Point seedP)
        {
            Point3d p = new Point3d(seedP.X, seedP.Y, seedP.Z);
            return NewHatch(p);
        }
        public static Hatch NewHatch(Point3d seedP)
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
#if acad2010
            DBObjectCollection objs = null;
#else
            DBObjectCollection objs= ed.TraceBoundary(seedP, true);
#endif
            if (objs == null || objs.Count <= 0) return null;
            ObjectIdCollection ids = new ObjectIdCollection();
            for (int i = 0; i < objs.Count; i++)
            {
                ids.Add(objs[i].ObjectId);//objectid为空，可能是因为没有加入数据库吧
            }
            
            return NewHatch(ids);
        }
        public static Hatch NewHatch(ObjectIdCollection ids)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                //-------------------------------
                // 获取模型空间
                //-------------------------------
                BlockTable blockTbl = tr.GetObject(
                    db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord modelSpace = tr.GetObject(
                    blockTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                
                //-------------------------------
                // 创建填充对象
                //-------------------------------
                Hatch hatch = new Hatch();
                modelSpace.AppendEntity(hatch);
                tr.AddNewlyCreatedDBObject(hatch, true);

                hatch.SetHatchPattern(HatchPatternType.PreDefined, "ANSI31");
                hatch.Associative = true;
                
                hatch.AppendLoop(HatchLoopTypes.Outermost, ids);
                hatch.EvaluateHatch(true);

                //
                tr.Commit();
                return hatch;
            }
        }
    }
}
