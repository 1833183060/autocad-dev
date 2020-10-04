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
namespace TerrainComputeC.My
{
    //存储点和以这个点为端点的直线
    public class PLDictionary2 : Dictionary<Point3d, List<LineSegment3d>>
    {
        public void Add(List<LineSegment3d> ll)
        {
            if (ll == null) return;
            for (int i = 0; i < ll.Count; i++)
            {
                Add(ll[i]);
            }
        }
        public void Add(Point3d p, LineSegment3d l)
        {
            List<LineSegment3d> llist = null;
            if (this.ContainsKey(p))
            {
                llist = this[p];
            }
            
            if (llist != null)
            {
                llist.Add(l);
            }
            else
            {
                llist = new List<LineSegment3d>();
                llist.Add(l);
                base.Add(p, llist);
            }
        }

        public void Add(LineSegment3d l)
        {
            this.Add(l.StartPoint, l);
            this.Add(l.EndPoint, l);
        }

        //获取最左端的起点和起始矢量
        public KeyValuePair<Point3d, Vector2d>? getLeftMost()
        {
            Point3d? startP = getStartPoint();
            Vector2d? startV= getStartVector(startP);
            if (startV == null) return null;
            return new KeyValuePair<Point3d, Vector2d>(startP.Value, startV.Value);

        }
        //获取起始矢量
        public Vector2d? getStartVector(Point3d? startP)
        {
            Vector2d? ret =null;
            /*double leftMost = 0; int i = 0;
            Point3d? leftMostPoint = null;
            KeyValuePair<Point3d, List<Line>> kp0 = new KeyValuePair<Point3d,List<Line>>();
            foreach(KeyValuePair<Point3d,List<Line>> kp in this){
                double x=kp.Key.X;
                if (i++ == 0||x < leftMost)
                {
                    leftMost = x;
                    leftMostPoint = kp.Key;
                    kp0=kp;
                    
                }
            }*/
            Point3d? leftMostPoint = startP;
            if (leftMostPoint != null)
            {                
                
                //List<Line> ll = kp0.Value as List<Line>;
                List<LineSegment3d> ll = this[leftMostPoint.Value];
                Vector2d? v=null;
                //Point3d? p=null;
                
                double minIncludedAngle = Math.PI+1;
                foreach (LineSegment3d l in ll)
                {
                    Point3d endPoint = l.EndPoint;
                    if (leftMostPoint == l.EndPoint)
                    {
                        endPoint = l.StartPoint;
                    }
                    //ng:找到和（0，-1）的夹角最小的矢量,v2一定位于1 4象限
                    Vector2d v2 = new Vector2d(endPoint.X - leftMostPoint.Value.X, endPoint.Y - leftMostPoint.Value.Y);
                    double includedAngle = v2.Angle - 3 * Math.PI / 2;
                    if (includedAngle < 0)
                    {
                        includedAngle += 2 * Math.PI;
                    }
                    if (includedAngle<minIncludedAngle)
                    {
                        minIncludedAngle = includedAngle;                        
                        v = v2;
                        
                    }
                }
                if (v!=null)
                {
                    ret =  v.Value;
                }
            }
            return ret;
        }

        //外部边界的起始点
        public Point3d? getStartPoint()
        {
            double leftMost = 0; int i = 0;
            Point3d? leftMostPoint = null;
            KeyValuePair<Point3d, List<LineSegment3d>> kp0 = new KeyValuePair<Point3d, List<LineSegment3d>>();
            foreach (KeyValuePair<Point3d, List<LineSegment3d>> kp in this)
            {
                double x = kp.Key.X;
                if (i++ == 0 || x < leftMost)
                {
                    leftMost = x;
                    leftMostPoint = kp.Key;
                    kp0 = kp;

                }
            }
            return leftMostPoint;
        }

        //内部边界的起始点
        
        //找到和过指定的点，同指定的vector逆时针夹角最大的那条直线的另一个顶点
        public Point3d? getMaxAnglePoint(Point3d p, Vector2d v)
        {
            Point3d? retp = null;
            List<LineSegment3d> ll = this[p];
            if (ll == null)
            {
                return null;
            }
            double maxAngle = 0;
            
            for (int i = 0; i < ll.Count; i++)
            {
                LineSegment3d templ = ll[i];
                Point3d end = templ.EndPoint;
                Vector2d tempv = new Vector2d(templ.StartPoint.X - end.X, templ.StartPoint.Y - end.Y);
                if (p == templ.StartPoint)
                {  
                    tempv=tempv.Negate();
                }
                else
                {
                    
                    end = templ.StartPoint;
                }
                double angle = tempv.Angle - v.Angle;
                if(angle<0){
                    angle+=Math.PI*2;
                }
                if (angle > maxAngle)
                {
                    maxAngle = angle;
                    retp = end;
                }
            }
            if (maxAngle < 0.05) return null;
            return retp;
        }
    }
}
