using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
using Utils.Geometry;
using TerrainComputeC.DataUtil;
//using ngeometry.ComputationalGeometry;
//using ngeometry.VectorGeometry;
namespace TerrainComputeC.TraceBoundary
{
    public class TraceBoundary
    {
        public static Loop getBoundary(TBPLineSegment startSeg,object userData)
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Loop resultLoop = new Loop();
            resultLoop.userData = userData;
            List<LoopSeg> loopSegs = resultLoop.segments;
            //result2 = new List<Point3d>();
            //result.Add(startSeg);
            double scanAngle = 0;
            TBPLineSegment previousSeg = startSeg;
            TBPoint startPoint;
            TBPoint nextp = startSeg.nextPoint(out startPoint);
            if (nextp == null) return null;
            scanAngle += startSeg.scanAngle(startPoint);
            //result2.Add(startPoint.acPoint);
            loopSegs.Add(new LoopSeg(startSeg, startPoint));
            resultLoop.startPoint = startPoint;
            while (nextp != null)
            {
                TBPLineSegment nextSeg = nextp.nextSegment(previousSeg);
                if (nextSeg == startSeg)
                {
                    throw new System.Exception("TraceBoundary 39");
                }
                scanAngle += nextSeg.scanAngle(nextp);
                scanAngle += previousSeg.scanAngle(nextSeg,nextp);
                loopSegs.Add(new LoopSeg(nextSeg, nextp));
                nextp = nextSeg.nextPoint(nextp);
                if (nextp == null)
                {
                    return null;
                    //throw new System.Exception("TraceBoundary 44");
                }
                previousSeg = nextSeg;
                if (nextp == startPoint)
                {
                    scanAngle += previousSeg.scanAngle(startSeg,startPoint);
                    break;
                }
            }
            resultLoop.scanAngle = scanAngle;
            if (resultLoop.segments.Count <= 1)
            {

            }
            if (scanAngle <= 0)
            {
                ed.WriteMessage("\nangle:"+scanAngle+"\n"+startSeg.toString());
            }
            return resultLoop;
        }
        public static Loop getMaxBoundary(TBPLineSegment startSeg,object userData)
        {
            Loop b = getBoundary(startSeg,userData);
            if (b != null && b.segments.Count == 1) return b;
            if (b != null && b.scanAngle < 0) return b;
            else
            {
                b = getBoundary(startSeg,userData);
                if (b != null && b.scanAngle < 0) { return b; }
            }
            return null;
        }
        public static Loop getMinBoundary(TBPLineSegment startSeg,object userData/*,out List<Point3d> result2*/){
            try
            {
                Loop b = getBoundary(startSeg, userData);
                if (b != null && b.segments.Count == 1)
                {

                    return b;
                }
                if (b != null && b.scanAngle > 0) return b;
                else
                {
                    b = getBoundary(startSeg, userData);
                    if (b != null && b.scanAngle > 0) { return b; }
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static Loop getClosedBoundary(TBPLine pl,object userData)
        {
            if (pl.acPline.Closed||pl.IsLooped)
            {
                Loop l = new Loop();
                TBPLineSegment tbpl=new TBPLineSegment(pl.acPline);
                LoopSeg ls=new LoopSeg(tbpl,LineDirection.positive);
                l.segments.Add(ls);
                l.startPoint = tbpl.StartPoint;
                l.userData = userData;
                return l;
            }
            return null;
        }
        public static bool _ifInside(Loop outerB, Loop innerB)
        {
            if (outerB == innerB) return false;
            List<Point3d> ps = outerB.toPoints();
            Utils.Geometry.Point2D[] pointArray = My.MyConvert.toPoint2DArray(ps);
            int if0 = Geometry2D.InsidePolygon(pointArray.Length, pointArray, My.MyConvert.toPoint2D(innerB.startPoint.acPoint));
            if (if0 == 0)
            {
                return true;
            }
            return false;
        }
        public static bool ifInside(Loop outerB, Loop innerB)
        {
            if (outerB == innerB) return false;

            List<Point3d> ps = outerB.toPoints();
            //Utils.Geometry.Point2D[] pointArray = My.MyConvert.toPoint2DArray(ps);
            
            //bool ifIn=My.MyGeom.InsidePolygon(ps, innerB.startPoint.acPoint);
            bool ifIn = My.MyGeom.cn_PnPoly(ps, innerB.startPoint.acPoint);
            return ifIn;
        }
        public static void calcAllInnerLoop(Loop outerB, List<Loop> goalBs)
        {            
            List<Loop> r = new List<Loop>();
            for (int i = 0; i < goalBs.Count; i++)
            {
                Loop inner = goalBs[i];
                
                bool inside = ifInside(outerB, inner);
                if (inside)
                {
                    r.Add(inner);
                }
            }
            outerB.innerLoops = r;
            return ;
        }

        public static void calcNeighbourInnerLoop(Loop outerB)
        {
            if (outerB.innerLoops == null) return;
            List<Loop> needRemoveList = new List<Loop>();
            for (int i = 0; i < outerB.innerLoops.Count; i++)
            {
                needRemoveList.AddRange(outerB.innerLoops[i].innerLoops);
            }
            outerB.neighbourInnerLoops = ListUtil<Loop>.getRemainedRange(outerB.innerLoops, needRemoveList);
        }
        
    }
}
