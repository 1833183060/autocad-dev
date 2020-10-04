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
    public class Interpolation
    {
        public static PointSet interpolation(PointSet ps, ObjectId[] ids)
        {
            List<LineSegment3d> ll = MyDBUtility.getLines(ids);
            PLDictionary2 plDic = new PLDictionary2();
            plDic.Add(ll);
            return interpolation(ps, plDic);
        }
        public static PointSet interpolation(PointSet ps, PLDictionary2 plDic)
        {
            PointSet result = new PointSet();
            List<LineSegment3d> ll;
            for (int i = 0; i < ps.Count; i++)
            {
                Point3d p = new Point3d(ps[i].X, ps[i].Y, ps[i].Z);
                bool b = plDic.TryGetValue(p, out ll);
                if (!b) continue;
                PointSet tps = interp(p, ll);
                if (tps != null) result.Add(tps);
            }
            return result;

        }

        public static PointSet interpolation(PPDictionary ppd)
        {//插值所有三角形            
            PointSet result = new PointSet();
            foreach (KeyValuePair<Point, List<Point>> kv in ppd)
            {
                PointSet tps = interp(MyConvert.toPoint3d(kv.Key),MyConvert.toPoint3dList (kv.Value));
                if (tps != null) result.Add(tps);
            }
            
            return result;
        }

        public static PointSet interpolation_partial(PPDictionary ppd)
        {
            PointSet result = new PointSet();
            int count = ppd.index.Count ;
            List<InterpolatedPoint> lip = new List<InterpolatedPoint>();
            for (int i = 0; i < count; i++)
            {
                KeyValuePair<Point, List<Point>> kv = ppd.index[i];
                List<InterpolatedPoint> tps = interp2(MyConvert.toPoint3d(kv.Key), MyConvert.toPoint3dList(kv.Value));
                if (tps != null) lip.AddRange(tps);
            }
            lip.Sort(new InterpolatedPointComparer());
            count = lip.Count/5;
            for (int i = 0; i < count; i++)
            {
                result.Add(lip[i].point);
            }
                return result;

        }
        public static PointSet __interp(Point3d p, List<LineSegment3d> ll)
        {
            if (ll.Count < 3) return null;
            PointSet ps = new PointSet();
            List<Point3d> pl = new List<Point3d>();
            Point3d ortherP;
            for (int i = 0; i < ll.Count; i++)
            {
                if (p == ll[0].EndPoint)
                {
                    ortherP = ll[0].StartPoint;
                }
                else
                {
                    ortherP = ll[i].EndPoint;
                }
                Point3d tp = new Point3d(p.X + (ortherP.X - p.X) / 3, p.Y + (ortherP.Y - p.Y) / 3, p.Z + (ortherP.Z - p.Z) / 3);
                pl.Add(tp);
            }
            Point3d p1 = pl[0], p2 = pl[1], p3 = pl[2];
            Autodesk.AutoCAD.Geometry.Plane plane1 = new Autodesk.AutoCAD.Geometry.Plane(p1, p2, p3);
            Autodesk.AutoCAD.Geometry.Matrix3d prjMat1 = Autodesk.AutoCAD.Geometry.Matrix3d.Projection(plane1, plane1.Normal);


            Point3d prjP = p.TransformBy(prjMat1);
            Autodesk.AutoCAD.Geometry.Vector3d direction = new Autodesk.AutoCAD.Geometry.Vector3d(p.X - prjP.X, p.Y - prjP.Y, p.Z - prjP.Z);
            for (int i = 0; i < pl.Count; i++)
            {
                //double d = p.DistanceTo(prjP);
                ;
                Point3d tp = pl[i].TransformBy(Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(direction * 2 / 3));
                ps.Add(new Point(tp.X, tp.Y, tp.Z));
            }

            return ps;
        }
        public static PointSet interp(Point3d p, List<LineSegment3d> ll)
        {
            if (ll.Count < 3) return null;
            PointSet ps = new PointSet();
            List<Point3d> pl = new List<Point3d>();
            Point3d ortherP;
            for (int i = 0; i < ll.Count; i++)
            {
                if (p == ll[0].EndPoint)
                {
                    ortherP = ll[0].StartPoint;
                }
                else
                {
                    ortherP = ll[i].EndPoint;
                }

                pl.Add(ortherP);
            }
            
            return interp(p,pl);
        }
        public static PointSet interp(Point3d p, List<Point3d> _pl)
        {
            if (_pl.Count < 3) return null;
            PointSet ps = new PointSet();
            List<Point3d> pl = new List<Point3d>();
            Point3d ortherP;
            for (int i = 0; i < 3; i++)
            {                
                ortherP = _pl[i];
                
                Point3d tp = new Point3d(p.X + (ortherP.X - p.X) / 3, p.Y + (ortherP.Y - p.Y) / 3, p.Z + (ortherP.Z - p.Z) / 3);
                pl.Add(tp);
            }
            //pl.Sort(new My.Point3dComparer());
            Point3d p1 = pl[0], p2 = pl[1], p3 = pl[2];
            Autodesk.AutoCAD.Geometry.Plane plane1 = new Autodesk.AutoCAD.Geometry.Plane(p1, p2, p3);
            Autodesk.AutoCAD.Geometry.Matrix3d prjMat1 = Autodesk.AutoCAD.Geometry.Matrix3d.Projection(plane1, plane1.Normal);

            Point3d prjP = p.TransformBy(prjMat1);
            Autodesk.AutoCAD.Geometry.Vector3d direction = new Autodesk.AutoCAD.Geometry.Vector3d(p.X - prjP.X, p.Y - prjP.Y, p.Z - prjP.Z);
            for (int i = 0; i < 3; i++)
            {
                //double d = p.DistanceTo(prjP);
                ;
                Point3d tp = pl[i].TransformBy(Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(direction * 2 / 3));
                ps.Add(new Point(tp.X, tp.Y, tp.Z));
            }

            return ps;
        }

        public static List<InterpolatedPoint> interp2(Point3d p, List<Point3d> _pl)
        {
            if (_pl.Count < 3) return null;
            int count = _pl.Count;
            List<InterpolatedPoint> ps = new List<InterpolatedPoint>();
            List<Point3d> pl = new List<Point3d>();
            Point3d ortherP;
            for (int i = 0; i < count; i++)
            {
                for (int j = i+1; j < count; j++)
                {
                    for (int k = j+1; k < count; k++)
                    {
                        ps.AddRange(interp(p, _pl[i], _pl[j], _pl[k]));
                    }
                }
            }          

            return ps;
        }

        public static List<InterpolatedPoint> interp(Point3d p, Point3d p1, Point3d p2, Point3d p3)
        {
            List<InterpolatedPoint> ps = new List<InterpolatedPoint>();
            
            p1 = new Point3d(p.X + (p1.X - p.X) / 4, p.Y + (p1.Y - p.Y) / 4, p.Z + (p1.Z - p.Z) / 4);
           
            p2 = new Point3d(p.X + (p2.X - p.X) / 4, p.Y + (p2.Y - p.Y) / 4, p.Z + (p2.Z - p.Z) / 4);
            
            p3= new Point3d(p.X + (p3.X - p.X) /4, p.Y + (p3.Y - p.Y) / 4, p.Z + (p3.Z - p.Z) / 4);            
           
            //pl.Sort(new My.Point3dComparer());
            //Point3d p1 = pl[0], p2 = pl[1], p3 = pl[2];
            Autodesk.AutoCAD.Geometry.Plane plane1 = new Autodesk.AutoCAD.Geometry.Plane(p1, p2, p3);
            Autodesk.AutoCAD.Geometry.Matrix3d prjMat1 = Autodesk.AutoCAD.Geometry.Matrix3d.Projection(plane1, plane1.Normal);

            Point3d prjP = p.TransformBy(prjMat1);
            Autodesk.AutoCAD.Geometry.Vector3d direction = new Autodesk.AutoCAD.Geometry.Vector3d(p.X - prjP.X, p.Y - prjP.Y, p.Z - prjP.Z);
            
                Point3d tp = p1.TransformBy(Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(direction * 1 / 3));
                ps.Add(new InterpolatedPoint(direction.Length, new Point(tp.X, tp.Y, tp.Z)));
                tp=p2.TransformBy(Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(direction * 1 / 3));
                ps.Add(new InterpolatedPoint(direction.Length , new Point(tp.X, tp.Y, tp.Z)));
                tp = p3.TransformBy(Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(direction * 1 / 3));
                ps.Add(new InterpolatedPoint(direction.Length , new Point(tp.X, tp.Y, tp.Z)));            

            return ps;
        }
        public static List<Point3d> maxZPoint(List<Point3d> pl)
        {
            return null;
            if (pl == null) return null;
            if (pl.Count <= 3) return pl;
            List<Point3d> r = new List<Point3d>();
            return r;
        }
    }
}
