using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;
using TerrainComputeC.My;
using TerrainComputeC.BASE;
using TerrainComputeC.TraceBoundary;
namespace TerrainComputeC.Colorize
{	 
	public class ContourColorize2
	{
		static ContourColorize2()
		{
			ContourColorize2.int_0 = 6;
			ContourColorize2.string_0 = "AR";
			ContourColorize2.string_1 = "N";
			ContourColorize2.double_0 = 0.0;
			ContourColorize2.double_1 = 100.0;
		}
        public static string ccLayerNamePrefix = "二维填充";
        
        public List<CContour2> contours;
        public List<TBPLine> originalBoundarys;
        //public List<TBPLine> segmentedPLines;
        public ContourColorize2()
		{
            contours = new List<CContour2>();
            originalBoundarys = new List<TBPLine>();
            
		}
        public void reset()
        {
            //reset 
        }
        public bool hadColorized(MyDB2 mydb)
        {
            string dxfName=RXObject.GetClass(typeof(Region)).DxfName;            
            
            ObjectId[]ids=My.Selection.GetObjectIDs(dxfName,ccLayerNamePrefix+"_"+mydb.Resolution);
            return (ids!=null&&ids.Length > 0);
        }
        public void resetBoundarires()
        {            
            ObjectId[] boundaryIds = Selection.getBoundarys();
            this.originalBoundarys = new List<TBPLine>();
            Database db = HostApplicationServices.WorkingDatabase;
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                for (int n = 0; n < boundaryIds.Length; n++)
                {
                    Polyline3d pl = trans.GetObject(boundaryIds[n], OpenMode.ForRead) as Polyline3d;
                    if (pl == null) continue;
                    TBPLine cb = new TBPLine(pl);
                    originalBoundarys.Add(cb);
                }
            }
            
        }
        public void resetContours()
        {
            for (int i = 0; i < contours.Count; i++)
            {
                CContour2 con = contours[i];
                con.tbPLine.reset();
            }
        }
        public void clearContours()
        {
            this.contours = new List<CContour2>();
        }
        public void addContour(List<Polyline3d> plines,double elevation)
        {
            //if (this.contours.Count > 3) return;
            for(int i=0;i<plines.Count;i++){
                CContour2 cc = new CContour2();
                cc.elevation = elevation;
                Polyline3d pl = plines[i];
                cc.tbPLine = new TBPLine(pl);
                this.contours.Add(cc);
            }
            
        }

        public bool calcSegment()
        {
            TBPoint.allPoints.Clear();   
            resetBoundarires();
            resetContours();
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            if (this.contours.Count <= 0)
            {
                ed.WriteMessage("this.contours.Count <= 0");
                return false;
            }
            if (this.originalBoundarys.Count <= 0)
            {
                ed.WriteMessage("this.originalBoundarys.Count <= 0");
                return false;
            }
            for (int i = 0; i < this.contours.Count; i++)
            {
                try
                {
                    TBPLine contour = this.contours[i].tbPLine;
                    if (contour.isClosed) continue;
                    for (int j = 0; j < originalBoundarys.Count; j++)
                    {
                        TBPLine boundary = originalBoundarys[j];
                        contour.calcIntersection(boundary);

                    }
                    if (contour.intersectPoints.Count ==1)
                    {
                        if(PointUtil.equal2(contour.intersectPoints[0].acPoint,contour.acPline.StartPoint)){
                            contour.intersectPoints.Add(TBPoint.getNewTBPoint(contour.acPline.EndPoint));
                        }
                        else
                        {
                            contour.intersectPoints.Add(TBPoint.getNewTBPoint(contour.acPline.StartPoint));
                        }
                    }
                    contour.sortPoints();
                    contour.divide();
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage("125 i:"+i+","+ex.Message);
                }
                //ed.WriteMessage(" " + i);
            }
            for (int j = 0; j < originalBoundarys.Count; j++)
            {
                TBPLine b = originalBoundarys[j];
                b.sortPoints();
                b.divide();
            }
            for (int n = 0; n < TBPoint.allPoints.Count; n++)
            {
                TBPoint.allPoints[n].sort();
            }
            return true;
        }

        public void calcClosedRegion(MyDB2 mydb, List<System.Drawing.Color> cl)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectId layerId = LayerUtil.CreateLayer(ccLayerNamePrefix+"_"+mydb.Resolution, 127, false);
            List<TBPoint> ps = new List<TBPoint>();
            List<Loop> boundarys = new List<Loop>();
            ed.WriteMessage("contours.count:"+contours.Count);
            for (int i = 0; i < contours.Count; i++)
            {
                CContour2 contour=contours[i];
                Loop closedBoundary = TraceBoundary.TraceBoundary.getClosedBoundary(contour.tbPLine,contour);
                if (closedBoundary != null)
                {
                    boundarys.Add(closedBoundary);
                    continue;
                }
                List<TBPLineSegment> segs=contour.tbPLine.SegmentedPlines;
                if (segs.Count <= 0)
                {
                    continue;
                }
                List<Point3d> boundaryPoints = new List<Point3d>();
                for (int j = 0; j < 2; j++)//两个方向都求边界，确保loop的elevation属于最小的contour的。
                {
                    Loop minBoundary =
                    TraceBoundary.TraceBoundary.getMinBoundary(segs[0],contour);
                    if (minBoundary == null)
                    {
                        //ed.WriteMessage("");
                        continue;
                    }
                    //minBoundary.userData = contour;
                    boundarys.Add(minBoundary);
                    List<LoopSeg> loopsegs = minBoundary.segments;
                    if (loopsegs == null) continue;
                }
            }
            /*for (int j = 0; j < originalBoundarys.Count; j++)
            {
                Loop minBoundary =
                TraceBoundary.TraceBoundary.getMinBoundary(originalBoundarys[j].segmentedPlines[0]);
                boundarys.Add(minBoundary);
            }*/
            for (int k = 0; k < boundarys.Count-1; k++)
            {
                
                try
                {
                    Loop boundary = boundarys[k];
                    TraceBoundary.TraceBoundary.calcAllInnerLoop(boundary, boundarys);
                    //TraceBoundary.TraceBoundary.calcAllInnerLoop(boundary, boundarys.GetRange(k+1,boundarys.Count-k-1));
                    //TraceBoundary.TraceBoundary.calcNeighbourInnerLoop(boundary);
                    //CContour2 contour = boundary.userData as CContour2;
                    //Color color = ColorizeBase.getColorIndex(mydb, contour.elevation);
                    //Region region = MyRegion.NewRegion(MyConvert.toDBObjects(boundary), color);
                }
                catch (System.Exception ex)
                {
                    ed.WriteMessage("\n192 k:"+k+"--" + ex.Message);
                }                
            }

            for (int kk = 0; kk < boundarys.Count; kk++)
            {
                DBObjectCollection outerLoopObjs=null;
                try
                {
                    Loop boundary = boundarys[kk];
                    //TraceBoundary.TraceBoundary.calcAllInnerLoop(boundary, boundarys);
                    TraceBoundary.TraceBoundary.calcNeighbourInnerLoop(boundary);
                    CContour2 contour = boundary.userData as CContour2;
                    Color color = ColorizeBase.getColorIndex(mydb, contour.elevation);
                    //Region region = MyRegion.NewRegion(MyConvert.toDBObjects(boundary), color);
                    outerLoopObjs=boundary.getOuterLoopObjs();
                    Region region = MyRegion.NewRegion(outerLoopObjs,boundary.getInnerLoopObjsList(), color,layerId);
                    outerLoopObjs = null;
                }
                catch (System.Exception ex2)
                {
                    ed.WriteMessage("\n210 kk:"+kk+"--" + ex2.Message);
                    if (outerLoopObjs != null)
                    {
                        ed.WriteMessage("\nobjs:\n");
                        for (int ee = 0; ee < outerLoopObjs.Count; ee++)
                        {
                            Polyline3d pl = outerLoopObjs[ee] as Polyline3d;
                            if (pl != null)
                            {
                                ed.WriteMessage(pl.StartPoint.X+","+pl.StartPoint.Y);
                                ed.WriteMessage("\n");
                                ed.WriteMessage(pl.EndPoint.X + "," + pl.EndPoint.Y);
                                ed.WriteMessage("\n");
                            }
                            
                        }
                    }
                    ed.WriteMessage("\n210 kk:" + kk + "--" + ex2.Message);
                }

            }
            //Region region = MyRegion.NewRegion(MyConvert.toDBObjects(segs));
            //region.Color = ColorizeBase.getColorIndex(mydb, contour.elevation);
        }

        public void drawColorCulumn(MyDB2 mydb, List<System.Drawing.Color> cl)
        {
            ObjectId[] bidArray = Selection.getBoundarys();
            Extents3d? ext = AcadUtil.getBound(bidArray);
            if (ext == null) return;
            Point3d leftBottom = new Point3d(ext.Value.MaxPoint.X + 10, ext.Value.MinPoint.Y, 0);
            for (int i = 0; i < cl.Count; i++)
            {
                //Rectangle3d rec=new Rectangle3d(new Point3d())
            }
        }
        List<object> calcInnerBoundary(List<object> outerB,double elevation)
        {
            return null;
        }
        public void colorize(MyDB2 mydb, List<System.Drawing.Color> cl)
		{            
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            if (hadColorized(mydb))
            {
                editor.WriteMessage("\n 已经填充过颜色，不能重复填充");
            }
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			try
			{
                bool ifContinue=calcSegment();
                if (!ifContinue) return;
                calcClosedRegion(mydb, cl);
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				editor.WriteMessage("\n" + ex.Message);
			}
		}
        /*
        static void genIntersection(MyDB2 mydb)
        {
            ObjectId[] boundary = Selection.getBoundarys();
            ObjectId[] contours = Selection.getContours(LayerUtil.contourLayerName(mydb.Resolution));
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction tran = db.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < contours.Length; i++)
                {
                    Polyline pl = tran.GetObject(contours[i], OpenMode.ForRead) as Polyline;
                    for (int j = 0; j < boundary.Length; j++)
                    {
                        Polyline b = tran.GetObject(boundary[i], OpenMode.ForRead) as Polyline;
                        double p=b.GetParameterAtPoint(pl.StartPoint);
                    }
                }
            }
        }*/
		private static double double_0;

		private static double double_1;

		private static int int_0;

		private static string string_0;

		private static string string_1;
	}
}
