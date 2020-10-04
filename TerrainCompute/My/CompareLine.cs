using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

using ngeometry.VectorGeometry;

namespace TerrainComputeC.My
{
    public class CompareLine : EqualityComparer<Autodesk.AutoCAD.DatabaseServices.Line>
    {
        public override bool Equals(Autodesk.AutoCAD.DatabaseServices.Line x, Autodesk.AutoCAD.DatabaseServices.Line y)
        {
            bool r = (x.StartPoint == y.StartPoint && x.EndPoint == y.EndPoint)||(x.StartPoint==y.EndPoint&&x.EndPoint==y.StartPoint);
            return r;

        }
        public override int GetHashCode(Autodesk.AutoCAD.DatabaseServices.Line obj)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    public class CompareLineSegment3d : EqualityComparer<LineSegment3d>
    {
        public override bool Equals(LineSegment3d x, LineSegment3d y)
        {
            bool r = (x.StartPoint == y.StartPoint && x.EndPoint == y.EndPoint) || (x.StartPoint == y.EndPoint && x.EndPoint == y.StartPoint);
            return r;

        }
        public override int GetHashCode(LineSegment3d obj)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    public class ComparePoint3d : EqualityComparer<Point3d>
    {
        public override bool Equals(Point3d x, Point3d y)
        {
            bool r = (x == y);
            return r;

        }
        public override int GetHashCode(Point3d obj)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    public class ComparePoint : EqualityComparer<Point>
    {
        public override bool Equals(Point x, Point y)
        {
            bool r = (x == y);
            return r;

        }
        public override int GetHashCode(Point obj)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    public class Point3dComparer : IComparer<Point3d>
    {
        public int Compare(Point3d left, Point3d right)
        {
            double dis = left.DistanceTo(right);
            if (dis == 0) return 0;
            double r = (left.Z - right.Z) / dis;            
            if (r > 0)
                return 1;
            else if (r==0)
                return 0;
            else
                return -1;
        }
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point left, Point right)
        {
            double dis = left.DistanceTo(right);
            if (dis == 0) return 0;
            double r = (left.Z - right.Z) / dis;
            if (r > 0)
                return 1;
            else if (r == 0)
                return 0;
            else
                return -1;
        }
    }

    public class InterpolatedPointComparer : IComparer<InterpolatedPoint>
    {
        public int Compare(InterpolatedPoint left, InterpolatedPoint right)
        {
            
            double r =left.movement-right.movement;
            if (r > 0)
                return -1;
            else if (r == 0)
                return 0;
            else
                return 1;
        }
    }



}
