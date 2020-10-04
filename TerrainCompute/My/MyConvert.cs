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
using ngeometry.VectorGeometry;
using TerrainComputeC.Colorize;
using TerrainComputeC.TraceBoundary;
using Utils.Geometry;
namespace TerrainComputeC.My
{
    public class MyConvert
    {
        public static List<Edge> ToEdgeList(List<Point3d> pl){
            if (pl == null) return null;
            List<Edge> el=new List<Edge>();
            for (int i = 0; i < pl.Count; i++)
            {
                if (i == pl.Count - 1)
                {
                    el.Add(new Edge(new Point(pl[i].X, pl[i].Y, pl[i].Z), new Point(pl[0].X, pl[0].Y, pl[0].Z)));
                }
                else
                {
                    el.Add(new Edge(new Point(pl[i].X, pl[i].Y, pl[i].Z), new Point(pl[i+1].X, pl[i+1].Y, pl[i+1].Z)));
                }
            }

            return el;
        }

        public static Point toPoint(Point3d p3d)
        {
            return new Point(p3d.X, p3d.Y, p3d.Z);
        }
        public static Point3d toPoint3d(Point p)
        {
            return new Point3d(p.X, p.Y, p.Z);
        }
        public static CPoint toCPoint(Point3d p3d)
        {
            return new CPoint(p3d);
        }
        public static CPoint toCPoint(Point p)
        {
            return new CPoint(toPoint3d(p));
        }
        public static List<Point> toPointList(List<Point3d> pl)
        {
            if (pl == null) return null;
            List<Point> r = new List<Point>();
            for (int i = 0; i < pl.Count; i++)
            {
                r.Add(toPoint(pl[i]));
            }
            return r;
        }

        public static List<Point3d> toPoint3dList(List<Point> pl)
        {
            if (pl == null) return null;
            List<Point3d> r = new List<Point3d>();
            for (int i = 0; i < pl.Count; i++)
            {
                r.Add(toPoint3d(pl[i]));
            }
            return r;
        }
        

        public static Autodesk.AutoCAD.Geometry.Vector3d toVector(Edge e)
        {
            return new Autodesk.AutoCAD.Geometry.Vector3d(e.StartPoint.X - e.EndPoint.X, e.StartPoint.Y - e.EndPoint.Y, e.StartPoint.Z - e.EndPoint.Z);
        }

        public static DBObjectCollection toDBObjects(Loop loop)
        {
            DBObjectCollection dbc = new DBObjectCollection();
            
            for(int k=0;k<loop.segments.Count;k++){
                dbc.Add(loop.segments[k].toPolyline3d());
            }
            for (int j = 0; j < loop.neighbourInnerLoops.Count; j++)
            {
                LoopSeg.add2DBObjectCollection(dbc,loop.neighbourInnerLoops[j].segments);
                //dbc.Add(loop.neighbourInnerLoops[j].segments
            }
            
            return dbc;
        }
        public static DBObjectCollection toDBObjects(List<TBPLineSegment> segs)
        {
            DBObjectCollection r = new DBObjectCollection();
            for (int i = 0; i < segs.Count; i++)
            {
                r.Add(toDBObject(segs[i]));
            }
            return r;
        }
        public static DBObject toDBObject(TBPLineSegment seg){
            return seg.acPline;
        }
        public static Point2D toPoint2D(Point3d p)
        {
            Point2D r=new Point2D();
            r.X = p.X; r.Y = p.Y;
            return r;
        }
        public static Point2D[] toPoint2DArray(List<Point3d> ps)
        {
            Point2D[] r = new Point2D[ps.Count];
            for (int i = 0; i < ps.Count; i++)
            {
                r[i] = new Point2D(ps[i].X,ps[i].Y);
            }
            return r;
        }
    }
}
