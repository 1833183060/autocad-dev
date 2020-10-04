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
namespace TerrainComputeC.My
{
    //存储点和以这个点为端点的直线
    [Serializable]
    public class PPDictionary : Dictionary<Point, List<Point>>
    {
        public List<KeyValuePair<Point, List<Point>>> index;
        public void Distinct()
        {
            List<Point> keys = new List<Point>();
            keys.AddRange(this.Keys);
            foreach (var v in keys)
            {
                this[v] = this[v].Distinct(new ComparePoint()).ToList();
                //this[v].Sort(new PPComparer(v));
            }
        }
        public void genIndex()
        {
            index = this.ToList();
            //this.Sort();
        }
        public void Sort()
        {
            //keys = keys.Distinct(new My.IndexClassComparer()).ToList();
            index.Sort(new KVComparer());
        }
        public void Add(List<MyTriangle> tl)
        {
            for (int i = 0; i < tl.Count; i++)
            {
                Add(tl[i]);
            }
        }
        public void Add(Point3d pk, Point3d pv)
        {
            Add(new Point(pk.X, pk.Y, pk.Z), new Point(pv.X, pv.Y, pv.Z));
        }
        public void Add(Point p, Point l)
        {
            List<Point> llist = null;
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
                llist = new List<Point>();
                llist.Add(l);
                base.Add(p, llist);
                //keys.Add(new IndexClass(p,llist));
            }
        }

        public void Add(MyTriangle t)
        {
            this.Add(t.Point1 ,t.Point2);
            this.Add(t.Point2,t.Point3);
            this.Add(t.Point3, t.Point1);
            this.Add(t.Point1, t.Point3);
            this.Add(t.Point2, t.Point1);
            this.Add(t.Point3, t.Point2);
        }
    }

    internal class IndexClass
    {
        internal Point key;
        internal List<Point> value;
        internal IndexClass(Point p, List<Point> l)
        {
            key = p;
            value = l;
        }
    }
    internal class CompareIndexClass : EqualityComparer<IndexClass>
    {
        public override bool Equals(IndexClass x, IndexClass y)
        {
            bool r = (x.key == y.key&&x.value==y.value);
            return r;

        }
        public override int GetHashCode(IndexClass obj)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }

    internal class IndexClassComparer : IComparer<IndexClass>
    {
        public int Compare(IndexClass left, IndexClass right)
        {
            return 0;
            double dis = 0;// left.DistanceTo(right);
            if (dis == 0) return 0;
            double r = (1) / dis;
            if (r > 0)
                return 1;
            else if (r == 0)
                return 0;
            else
                return -1;
        }
    }

    internal class KVComparer : IComparer<KeyValuePair<Point,List<Point>>>
    {
        public int Compare(KeyValuePair<Point, List<Point>> left, KeyValuePair<Point, List<Point>> right)
        {
            double r = zvalue(left) - zvalue(right);
            if (r > 0)
                return -1;
            else if (r == 0)
                return 0;
            else
                return 1;
        }
        private double zvalue(KeyValuePair<Point, List<Point>> kv)
        {
            //double r;
            double dis = kv.Key.DistanceTo(kv.Value[0]);
            if (dis == 0) return 0;
            double r=(kv.Key.Z-kv.Value[0].Z)/dis;
            return Math.Abs(r);
        }
    }

    public class PPComparer : IComparer<Point>
    {
        private Point basePoint;
        public PPComparer(Point p)
        {
            basePoint = p;
        }
        public int Compare(Point left, Point right)
        {
            double dis1 = left.DistanceTo(basePoint);
            if (dis1 == 0) return 1;
            double dis2 = right.DistanceTo(basePoint);
            if (dis2 == 0) return -1;
            double r1 = (left.Z - basePoint.Z) / dis1;
            double r2 = (right.Z - basePoint.Z) / dis2;
            r1 = Math.Abs(r1);
            r2 = Math.Abs(r2);
            if (r1 > r2)
                return -1;
            else if (r1 == r2)
                return 0;
            else
                return 1;
        }
    }

}
