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
    public class MyRegion
    {
        public static Region NewRegion(ngeometry.VectorGeometry.Point seedP)
        {
            Point3d p = new Point3d(seedP.X, seedP.Y, seedP.Z);
            return NewRegion(p);
        }
        public static Region NewRegion(Point3d seedP)
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
#if acad2010
            DBObjectCollection objs = null;
#else
            DBObjectCollection objs= ed.TraceBoundary(seedP, true);
#endif
            if (objs == null || objs.Count <= 0) {
                ed.WriteMessage("objs==null"+seedP.X+" "+seedP.Y);
                return null; 
            }
            
            return NewRegion(objs,Autodesk.AutoCAD.Colors.Color.FromRgb(255,0,0));
        }
        public static Region NewRegion(DBObjectCollection objs,Autodesk.AutoCAD.Colors.Color color)
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
                
                DBObjectCollection regions= Region.CreateFromCurves(objs);
                if(regions.Count<=0){
                    return null;
                }
                Region region = regions[0] as Region;
                region.Color = color;
                modelSpace.AppendEntity(region);
                tr.AddNewlyCreatedDBObject(region, true);               

                //
                tr.Commit();
                return region;
            }
        }

        public static Region NewRegion(DBObjectCollection outerLoopObjs, List<DBObjectCollection> innerLoops,Autodesk.AutoCAD.Colors.Color color,ObjectId layerId)
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

                DBObjectCollection regions = Region.CreateFromCurves(outerLoopObjs);
                if (regions.Count <= 0)
                {
                    return null;
                }
                Region region = regions[0] as Region;
                region.Color = color;
                if (layerId != ObjectId.Null)
                {
                    region.LayerId = layerId;
                }
                if (innerLoops != null)
                {
                    DBObjectCollection innerRegions;
                    for (int i = 0; i < innerLoops.Count; i++)
                    {
                        innerRegions = Region.CreateFromCurves(innerLoops[i]);
                        if (innerRegions.Count <= 0) continue;
                        Region r = innerRegions[0] as Region;
                        region.BooleanOperation(BooleanOperationType.BoolSubtract,r);
                    }
                }

                modelSpace.AppendEntity(region);
                tr.AddNewlyCreatedDBObject(region, true);

                //
                tr.Commit();
                return region;
            }
        }
    }
}
