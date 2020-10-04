using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TerrainComputeC.My
{
    public class Utility2d
    {
        public static Point3d? getPoint(string msg)
        {
            Point3d? r = null;
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            
            Editor ed = acDoc.Editor;
            PromptPointOptions ppo = new PromptPointOptions(msg);
            ppo.AllowNone = true;
            PromptPointResult ppr = null;
            while (true)
            {
                ppr = ed.GetPoint(ppo);
                if (ppr.Status == PromptStatus.Cancel)
                {
                    //ed.WriteMessage("\n命令被取消");
                    return null;
                }
                else if (ppr.Status == PromptStatus.OK)
                {
                    break;
                }
                else if (ppr.Status == PromptStatus.None)
                {
                    return null;
                }
            }
            r = ppr.Value;
            return r;
        }
        public static Point3d? getIntersectPoint2d(double y, Autodesk.AutoCAD.DatabaseServices.Line line)
        {
            Point3d? r = null;
            if ((y > line.StartPoint.Y && y > line.EndPoint.Y) || (y < line.StartPoint.Y && y < line.EndPoint.Y))
            {
                return null;
            }
            if (y == line.StartPoint.Y)
            {
                r = new Point3d(line.StartPoint.X, y,0);
            }
            else if (y == line.EndPoint.Y)
            {
                r = new Point3d(line.EndPoint.X, y,0);
            }
            else
            {
                double x=(y-line.StartPoint.Y)/(line.EndPoint.Y-line.StartPoint.Y)*(line.EndPoint.X-line.StartPoint.X)+line.StartPoint.X;
                r = new Point3d(x, y,0);
            }

            return r;
        }
        //ng:获得计算边界时所用的起点
        public static Point3d? getBoStartPoint(Point3d innerP, List<Autodesk.AutoCAD.DatabaseServices.Line> ll, PLDictionary plDic)
        {
            Autodesk.AutoCAD.DatabaseServices.Line resultL = new Autodesk.AutoCAD.DatabaseServices.Line();
            
            Point3d? resultP=null;
            if (ll == null) return null;

            double intersectPointX = innerP.X;
            for (int i = 0; i < ll.Count; i++)
            {
                Point3d? p = getIntersectPoint2d(innerP.Y, ll[i]);
                if (p == null) continue;
                if (resultP == null&&p.Value.X>innerP.X)
                {
                    intersectPointX = p.Value.X;
                    resultL = ll[i];
                    
                }
                else
                {
                    if (p.Value.X > innerP.X && p.Value.X < intersectPointX)
                    {
                        intersectPointX = p.Value.X;
                        resultL = ll[i];
                        
                    }
                }
            }
            if (resultL.StartPoint.X < resultL.EndPoint.X)
            {
                resultP = resultL.StartPoint;
            }
            else
            {
                resultP = resultL.EndPoint;
            }
            return resultP;
        }
        public static KeyValuePair<Point3d, Vector2d>? getLeftMost(Point3d innerP, List<Autodesk.AutoCAD.DatabaseServices.Line> ll, PLDictionary plDic)
        {            
            try
            {
                Point3d? startP = Utility2d.getBoStartPoint(innerP, ll, plDic);
                Vector2d? startV = plDic.getStartVector(startP);
                if (startV == null) return null;
                return new KeyValuePair<Point3d, Vector2d>(startP.Value, startV.Value);
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static List<Point3d> getOutterBo(ObjectId[] ids)
        {
            return null;
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;
            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                  OpenMode.ForRead) as BlockTable;
                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                     OpenMode.ForWrite) as BlockTableRecord;
                List<Autodesk.AutoCAD.DatabaseServices.Line> ll = new List<Autodesk.AutoCAD.DatabaseServices.Line>();
                DBObjectCollection acDBObjColl = new DBObjectCollection();
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i].ObjectClass != RXClass.GetClass(typeof(Autodesk.AutoCAD.DatabaseServices.Line))) continue;
                    Autodesk.AutoCAD.DatabaseServices.Line line = acTrans.GetObject(ids[i], OpenMode.ForRead) as Autodesk.AutoCAD.DatabaseServices.Line;

                    ll.Add(line);
                }
                ll = ll.Distinct(new My.CompareLine()).ToList();// as 

                acTrans.Commit();
            }
        }

        public static List<Point3d> getBo(DBObjectCollection dbCol)
        {
            if (dbCol == null) { return null; }
            List<Point3d> plist = new List<Point3d>();
            try
            {
                List<Autodesk.AutoCAD.DatabaseServices.Line> ll = new List<Autodesk.AutoCAD.DatabaseServices.Line>();
                PLDictionary plDic = new PLDictionary();
                for (int i = 0; i < dbCol.Count; i++)
                {
                    ll.Add(dbCol[i] as Autodesk.AutoCAD.DatabaseServices.Line);
                }
                ll = ll.Distinct(new My.CompareLine()).ToList();
                plDic.Add(ll);
                KeyValuePair<Point3d, Vector2d>? kvp = plDic.getLeftMost();
                if (kvp == null)
                {
                    return null;
                }
                Point3d startP = kvp.Value.Key;
                Point3d curP = kvp.Value.Key;
                Vector2d curV = kvp.Value.Value;
                
                plist.Add(curP);
                int maxLoopCount = plDic.Count;
                while (maxLoopCount-- > 0)
                {
                    Point3d? p = plDic.getMaxAnglePoint(curP, curV);
                    //ed.DrawVectors()
                    if (p == null) break;
                    if (p.Value == startP) break;
                    curV = new Vector2d(curP.X - p.Value.X, curP.Y - p.Value.Y);
                    curP = p.Value;

                    plist.Add(p.Value);

                }
                
            }
            catch (System.Exception ex)
            {

            }
            return plist;
        }

        
    }
}
