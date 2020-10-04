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
    public class PPDictionary2 : List<KeyValuePair<Point, List<Point>>>
    {
        
        public void Distinct()
        {
            List<KeyValuePair<Point, List<Point>>> t = new List<KeyValuePair<Point, List<Point>>>();
           
            for (int i = 0; i < Count;i++ )
            {
                var kv = this[i];
                t.Add(new KeyValuePair<Point,List<Point>>(kv.Key, kv.Value.Distinct(new ComparePoint()).ToList()));
            }
            this.Clear();
            this.AddRange(t);
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
        public List<Point> Find(Point p)
        {
            for (int i = 0; i < Count; i++)
            {
                KeyValuePair<Point, List<Point>> kv = this[i];
                if (kv.Key == p) return kv.Value;
            }
            return null;
        }
        public void Add(Point p, Point l)
        {
            List<Point> llist = this.Find(p);
            if (llist!=null)
            {
                //llist = this[p];
            }
            
            if (llist != null)
            {
                llist.Add(l);
            }
            else
            {
                llist = new List<Point>();
                llist.Add(l);
                base.Add(new KeyValuePair<Point,List<Point>>(p, llist));
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
}
