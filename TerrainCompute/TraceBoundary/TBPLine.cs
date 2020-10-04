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

namespace TerrainComputeC.TraceBoundary
{
    public class TBPLine
    {
        #region 属性 字段
        public Polyline3d acPline;
        public List<TBPoint> intersectPoints;
        public bool isClosed
        {
            get
            {
                return acPline.Closed;
            }
        }
        public bool IsLooped
        {
            get
            {
                if (isLooped != null) return isLooped.Value;
                
                if (Math.Abs(acPline.StartPoint.X - acPline.EndPoint.X) < 1e-10 &&
                    Math.Abs(acPline.StartPoint.Y - acPline.EndPoint.Y) < 1e-10 &&
                    Math.Abs(acPline.StartPoint.Z - acPline.EndPoint.Z) < 1e-10)
                {
                    isLooped = true;
                    return true;
                }
                isLooped = false;
                return false;
            }
        }
        bool? isLooped = null;
        public double StartAngle
        {
            get
            {
                if (startAngle == -1)
                {
                    
                    Point3d sp=intersectPoints[0].acPoint;
                    Point3d ep=intersectPoints[1].acPoint;
                    Vector3d v1= new Vector3d(ep.X - sp.X, ep.Y - sp.Y, ep.Z - sp.Z);
                    startAngle=v1.GetAngleTo(new Vector3d(1, 0, 0), new Vector3d(0, 0, 1));
                }
                return startAngle;
            }
        }
        double startAngle=-1;

        public double EndAngle
        {
            get
            {
                if (endAngle == -1)
                {
                    Point3d sp = intersectPoints[intersectPoints.Count-1].acPoint;
                    Point3d ep = intersectPoints[intersectPoints.Count-1].acPoint;
                    Vector3d v1 = new Vector3d(ep.X - sp.X, ep.Y - sp.Y, ep.Z - sp.Z);
                    endAngle = v1.GetAngleTo(new Vector3d(1, 0, 0), new Vector3d(0, 0, 1));
                }
                return startAngle;
            }
        }
        double endAngle = -1;


        public List<TBPLineSegment> SegmentedPlines
        {
            get
            {
                return segmentedPlines;
            }
            set
            {
                segmentedPlines = value;
            }
        }
        List<TBPLineSegment> segmentedPlines;
        #endregion
        public TBPLine(Polyline3d pl)
        {
            acPline = pl;
            intersectPoints = new List<TBPoint>();
            SegmentedPlines = null;
        }
        public void reset()
        {
            intersectPoints = new List<TBPoint>();
            segmentedPlines = null;
            
            startAngle = -1;
            endAngle = -1;
        }
        public void addIntersectPoint(TBPoint p)
        {
            int i = intersectPoints.FindIndex(item =>
            {
                TBPoint p2=item as TBPoint;
                if((Math.Abs(p.acPoint.X-p2.acPoint.X)<1e-10)&&
                    (Math.Abs(p.acPoint.Y - p2.acPoint.Y) < 1e-10))
                {
                    
                    return true;
                }
                return false;
            });
            if (i < 0)
            {
                intersectPoints.Add(p);
                return;
            }
            
        }
        private void caclParams()
        {
            for (int i = 0; i < intersectPoints.Count; i++)
            {
                TBPoint p = intersectPoints[i];
                double param = this.acPline.GetParameterAtPoint(p.acPoint);
                if (param < 0)
                {
                    //throw new System.Exception("TBPLine 97");
                }
                if (Math.Abs(param) < 1e-10)
                {
                    param = 0;
                }
                
                p.TempParam = param;
            }
        }
        public void sortPoints()//排序是为了分割
        {
            this.caclParams();
            this.intersectPoints.Sort(new TBPointComparer());
        } 
        public void calcIntersection(TBPLine tbpline){
            Point3dCollection result = new Point3dCollection();
            acPline.IntersectWith(tbpline.acPline, Intersect.OnBothOperands, new Plane(new Point3d(0, 0, 0), new Vector3d(0, 0, 1)),result,(IntPtr)0,(IntPtr)0);
            for (int i = 0; i < result.Count; i++)
            {
                Point3d p=result[i];
                TBPoint tbp=TBPoint.getNewTBPoint(p);

                this.addIntersectPoint(tbp);
                tbpline.addIntersectPoint(tbp);
            }
        }

        public void divide()
        {
            this.SegmentedPlines = new List<TBPLineSegment>();
            ObjectId layerId = My.LayerUtil.CreateLayer("segment", 255, false);
            try
            {
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;

                /*using (Transaction tran = acCurDb.TransactionManager.StartTransaction())
                {
                    BlockTable bt = tran.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord modelSpace = tran.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;*/
                    if (intersectPoints.Count <= 0)
                    {
                        return;
                    }
                    for (int i = 0; i < intersectPoints.Count - 1; i++)
                    {
                        TBPoint p1 = intersectPoints[i];
                        TBPoint p2 = intersectPoints[i + 1];
                        
                        Point3dCollection vertexes = new Point3dCollection();
                        //My.MyDBUtility.addPolyline3d(segmentedPl, layerId);
                        //ObjectId oid = modelSpace.AppendEntity(segmentedPl);
                        //tran.AddNewlyCreatedDBObject(segmentedPl, true);
                        vertexes.Add(p1.acPoint);
                        //segmentedPl.AppendVertex(vertex);
                        int n = 0;
                        int vertexCount = 1;
                        while (true)
                        {
                            double nextP;
                            if (Math.Ceiling(p1.TempParam) - p1.TempParam < 1e-10)
                            {
                                nextP = Math.Ceiling(p1.TempParam)+(++ n);
                            }else{
                                nextP= Math.Ceiling(p1.TempParam) + (n++);
                            }
                             
                            if (nextP - p2.TempParam > 1e-10)
                            {
                                break;
                            }
                            else if (Math.Abs(nextP - p2.TempParam) <= 1e-10)
                            {
                                break;
                            }
                            //segmentedPl.AppendVertex(new PolylineVertex3d(acPline.GetPointAtParameter(nextP)));
                            vertexes.Add(acPline.GetPointAtParameter(nextP));
                            vertexCount++;
                        }
                        //segmentedPl.AppendVertex(new PolylineVertex3d(p2.acPoint));
                        vertexes.Add(p2.acPoint);
                        vertexCount++;
                        
                        if (vertexCount >= 2)
                        {
                            Polyline3d segmentedPl = new Polyline3d(Poly3dType.SimplePoly,vertexes,false);
                            TBPLineSegment tbpline = new TBPLineSegment(segmentedPl,p1,p2);
                            //tbpline.StartPoint = p1;
                            //tbpline.EndPoint = p2;
                            this.SegmentedPlines.Add(tbpline);
                            //p1.SegmentedPLines.Add(tbpline);
                            //p2.SegmentedPLines.Add(tbpline);
                            p1.addSegment(tbpline);
                            p2.addSegment(tbpline);
                        }

                    }
                    if (this.isClosed||this.IsLooped)
                    {
                        
                        
                        TBPoint p1 = intersectPoints[intersectPoints.Count-1];
                            
                        Point3dCollection vertexes = new Point3dCollection();
                        vertexes.Add(p1.acPoint);
                            
                        My.PolylineUtil.getPointsBetween2Point(acPline, p1.TempParam, acPline.EndParam, vertexes);       
                        vertexes.Add(acPline.StartPoint);

                        TBPoint p2 = intersectPoints[0];
                        My.PolylineUtil.getPointsBetween2Point(acPline, 0,p2.TempParam, vertexes);
                        vertexes.Add(p2.acPoint);

                        if (vertexes.Count >= 2)
                        {
                            Polyline3d segmentedPl = new Polyline3d(Poly3dType.SimplePoly, vertexes, false);
                            TBPLineSegment tbpline = new TBPLineSegment(segmentedPl, p1, p2);
                            this.SegmentedPlines.Add(tbpline);
                            p1.addSegment(tbpline);
                            p2.addSegment(tbpline);
                        }

                        
                    }
                    
                    
                    //tran.Commit();
                //}
            }
            catch (System.Exception ex)
            {

            }
        }

        
    }

    public class TBPLineComparer : IComparer<TBPLine>
    {
        private TBPoint startPoint;
        public TBPLineComparer(TBPoint p)
        {
            startPoint = p;
        }
        public int Compare(TBPLine left, TBPLine right)
        {
            double leftAngle, rightAngle;
            if (startPoint == left.intersectPoints[0])
            {
                leftAngle = left.StartAngle;
            }
            else
            {
                leftAngle = left.EndAngle;
            }
            if (startPoint == right.intersectPoints[0])
            {
                rightAngle = right.StartAngle;
            }
            else
            {
                rightAngle = right.EndAngle;
            }
            if (leftAngle - rightAngle>1e-10)
                return 1;
            else if (rightAngle - leftAngle > 1e-10)
                return -1;
            else
                return 0;
        }
    }

}
