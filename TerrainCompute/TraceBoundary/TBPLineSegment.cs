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
using TerrainComputeC.My;
namespace TerrainComputeC.TraceBoundary
{
    public class TBPLineSegment
    {
        #region 属性 字段
        public Polyline3d acPline;
        public Dictionary<TBPoint, TBPoint> nextPointDic;
        public TBPoint StartPoint
        {
            get
            {
                return startPoint;
            }
            
        }
        TBPoint startPoint;
        public TBPoint EndPoint
        {
            get { return endPoint; }
            
        }
        TBPoint endPoint;
        public int hadProcessed = 0;
        public double StartAngle
        {
            get
            {
                if (startAngle == -1)
                {                    
                    Point3d sp=acPline.StartPoint;
                    Point3d ep=acPline.GetPointAtParameter(1);
                    Vector3d v1= new Vector3d(ep.X - sp.X, ep.Y - sp.Y, ep.Z - sp.Z);
                    //startAngle=v1.GetAngleTo(new Vector3d(1, 0, 0), new Vector3d(0, 0, 1));
                    startAngle=AngleUtil.CWAngle(new Vector3d(1, 0, 0), v1);
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
                    Point3d sp =this.acPline.EndPoint;
                    Point3d ep =acPline.GetPointAtParameter(acPline.EndParam-1);
                    Vector3d v1 = new Vector3d(ep.X - sp.X, ep.Y - sp.Y, ep.Z - sp.Z);
                    //endAngle = v1.GetAngleTo(new Vector3d(1, 0, 0), new Vector3d(0, 0, 1));
                    endAngle = AngleUtil.CWAngle(new Vector3d(1, 0, 0), v1);
                }
                return endAngle;
            }
        }
        double endAngle = -1;
        public bool IsClosed
        {
            get
            {
                if (isClosed != null) return isClosed.Value;
                if (acPline.Closed)
                {
                    isClosed = true;
                    return true;
                }
                if(Math.Abs(acPline.StartPoint.X-acPline.EndPoint.X)<1e-10&&
                    Math.Abs(acPline.StartPoint.Y-acPline.EndPoint.Y)<1e-10&&
                    Math.Abs(acPline.StartPoint.Z - acPline.EndPoint.Z) < 1e-10)
                {
                    isClosed = true;
                    return true;
                }
                isClosed = false;
                return false;
            }
        }
        bool? isClosed = null;
        #endregion
        public double scanAngle(TBPoint startp)
        {//闭合情况下，没有计算末尾到开始的角度
            if (startp == this.StartPoint)
            {
                return this.scanAngle();
            }
            else if (startp == this.EndPoint)
            {
                TBPLineSegment reverse = this.newReverse();
                return reverse.scanAngle();
            }
            else
            {
                throw new System.Exception("TBPLineSegment 69");
            }
        }
        public double scanAngle()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            double r = 0;
            //using (Transaction trans = acCurDb.TransactionManager.StartTransaction())
            //{
                //Polyline3d pl = trans.GetObject(acPline.ObjectId, OpenMode.ForRead) as Polyline3d;
                for (int i = 0; i < acPline.EndParam - 1; i++)
                {
                    r += AngleUtil.scanAngle(acPline.GetPointAtParameter(i), acPline.GetPointAtParameter(i + 1), acPline.GetPointAtParameter(i + 2));
                }
            //}
            return r;
        }

        public double scanAngle(TBPLineSegment second)
        {//不能处理this和second收尾相连的情况
            Point3d p1, p2, p3;
            TBPLineSegment s1 = null;
            TBPLineSegment s2 = null;
            if (this.StartPoint == second.StartPoint)
            {
                s1 = this.newReverse();
                s2 = second;
            }
            else if (this.StartPoint == second.EndPoint)
            {
                s1 = this.newReverse();
                s2 = second.newReverse();

            }
            else if (this.EndPoint == second.StartPoint)
            {
                s1 = this;
                s2 = second;
            }
            else if (this.EndPoint == second.EndPoint)
            {
                s1 = this;
                s2 = second.newReverse();
            }
            p1 = s1.acPline.GetPointAtParameter(this.acPline.EndParam - 1);
            p2 = this.EndPoint.acPoint;
            p3 = s2.acPline.GetPointAtParameter(1);
            return AngleUtil.scanAngle(p1, p2, p3);
        }

        public double scanAngle(TBPLineSegment second,TBPoint interPoint)
        {
            Point3d p1, p2, p3;
            TBPLineSegment s1 = null;
            TBPLineSegment s2 = null;
            if ((interPoint==this.StartPoint)&&(this.StartPoint == second.StartPoint))
            {
                s1 = this.newReverse();
                s2 = second;
            }
            else if ((interPoint==this.StartPoint)&&(this.StartPoint == second.EndPoint))
            {
                s1 = this.newReverse();
                s2 = second.newReverse();

            }
            else if ((interPoint==this.EndPoint)&&(this.EndPoint == second.StartPoint))
            {
                s1 = this;
                s2 = second;
            }
            else if ((interPoint==this.EndPoint)&&(this.EndPoint == second.EndPoint))
            {
                s1 = this;
                s2 = second.newReverse();
            }
            p1 = s1.acPline.GetPointAtParameter(this.acPline.EndParam - 1);
            p2 = s1.EndPoint.acPoint;
            p3 = s2.acPline.GetPointAtParameter(1);
            return AngleUtil.scanAngle(p1, p2, p3);
        }

        public TBPLineSegment(Polyline3d pl,TBPoint s,TBPoint e)
        {
            acPline = pl;
            startPoint = s;
            endPoint = e;
            nextPointDic = new Dictionary<TBPoint, TBPoint>();
            nextPointDic.Add(startPoint, endPoint);
            nextPointDic.Add(endPoint, startPoint);
        }

        public TBPLineSegment(Polyline3d pl)
        {
            this.acPline = pl;
            startPoint = TBPoint.getNewTBPoint(pl.StartPoint);
            endPoint = TBPoint.getNewTBPoint(pl.EndPoint);
            
        }
        public TBPoint nextPoint(out TBPoint start)
        {
            TBPoint r=null;
            start = null;
            r=this.nextPointDic[startPoint];
            if (r!= null)
            {
                start = startPoint;
                this.nextPointDic[startPoint] = null;
            }
            else
            {
                r = this.nextPointDic[endPoint];
                if (r != null)
                {
                    start = endPoint;
                    this.nextPointDic[endPoint] = null;
                }
            }
            return r;
            if ((hadProcessed & 1)==0)
            {
                r = nextPoint(1,out start);
                if (r == null)
                {
                    r = nextPoint(2,out start);
                }
            }
            else if ((hadProcessed & 2)==0)
            {
                r = nextPoint(2,out start);
            }
            return r;
        }
        public TBPoint nextPoint(int i,out TBPoint start)
        {
            start = null;
            if (i != 1 && i != 2)
            {
                
                return null;
            }
            TBPoint p=null;
            hadProcessed |= i;
            if (i == 1)
            {
                
                p = this.EndPoint;
                start = this.StartPoint;
            }
            else if (i == 2)
            {
                p = this.StartPoint;
                start = this.EndPoint;
            }
           
            return p;
        }
        public TBPoint nextPoint(TBPoint previousPoint)
        {
            TBPoint r;
            nextPointDic.TryGetValue(previousPoint,out r);
            if (r != null)
            {
                this.nextPointDic[previousPoint] = null;
            }
            return r;
            if (previousPoint == this.StartPoint)
            {
                if ((hadProcessed & 1) == 1)
                {
                    return null;
                }
                return this.EndPoint;
            }
            else if (previousPoint == this.EndPoint)
            {
                if ((hadProcessed & 2) == 2)
                {
                    return null;
                }
                return this.StartPoint;
            }
            else
            {
                throw new System.Exception("TBPLineSegment 117");
            }
        }
        
        public TBPLineSegment newReverse()
        {
            
            Point3dCollection ps = new Point3dCollection();
            for (int i = (int)this.acPline.EndParam; i >=0; i--)
            {                
                ps.Add(this.acPline.GetPointAtParameter(i));
            }
            TBPLineSegment newSeg = new TBPLineSegment(new Polyline3d(Poly3dType.SimplePoly, ps, false),this.endPoint,this.startPoint);
            
            //newSeg.StartPoint = this.EndPoint;
            //newSeg.EndPoint = this.StartPoint;
            return newSeg;
        }

        public List<Point3d> getPoints(TBPoint startp)
        {
            
            TBPLineSegment seg = this;
            if (startp == this.StartPoint)
            {

            }
            else if (startp == this.EndPoint)
            {
                seg = this.newReverse();
            }
            else
            {
                return null;
            }
            return seg.getPoints();
        }
        public List<Point3d> getPoints()
        {
            List<Point3d> r = new List<Point3d>();
            for (int i = 0; i <= this.acPline.EndParam; i++)
            {
                r.Add(this.acPline.GetPointAtParameter(i));
            }
            return r;
        }

        public List<Point3d> getInnerPoints(TBPoint startp)
        {

            TBPLineSegment seg = this;
            if (startp == this.StartPoint)
            {

            }
            else if (startp == this.EndPoint)
            {
                seg = this.newReverse();
            }
            else
            {
                return null;
            }
            return seg.getInnerPoints();
        }
        public List<Point3d> getInnerPoints()
        {
            if (this.acPline.EndParam <= 1) return null;
            List<Point3d> r = new List<Point3d>();
            for (int i = 1; i < this.acPline.EndParam; i++)
            {
                r.Add(this.acPline.GetPointAtParameter(i));
            }
            return r;
        }
        public TBPoint getIntersectPoint(TBPLineSegment second)
        {
            if (this.StartPoint == second.StartPoint)
            {
                return this.StartPoint;
            }
            else if (this.StartPoint == second.EndPoint)
            {
                return this.StartPoint;
            }
            else if (this.EndPoint == second.StartPoint || this.EndPoint == second.EndPoint)
            {
                return this.EndPoint;
            }
            else
            {
                return null;
            }
        }

        public string toString()
        {
            return "start:" + startPoint.toString() + ",end:" + endPoint.toString();
        }
    }

    public class TBPLineSegmentComparer : IComparer<TBPLineSegment>
    {
        private TBPoint startPoint;
        public TBPLineSegmentComparer(TBPoint p)
        {
            startPoint = p;
        }
        public int Compare(TBPLineSegment left, TBPLineSegment right)
        {
            double leftAngle, rightAngle;
            if (startPoint == left.StartPoint)
            {
                leftAngle = left.StartAngle;
            }
            else
            {
                leftAngle = left.EndAngle;
            }
            if (startPoint == right.StartPoint)
            {
                rightAngle = right.StartAngle;
            }
            else
            {
                rightAngle = right.EndAngle;
            }
            if (leftAngle - rightAngle > 1e-10)
                return 1;
            else if (rightAngle - leftAngle > 1e-10)
                return -1;
            else
                return 0;
        }
    }

}
