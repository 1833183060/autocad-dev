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
    public class LoopSeg
    {
        public TBPLineSegment segment;
        LineDirection direction;
        public TBPoint startPoint
        {
            get
            {
                if (direction == LineDirection.positive)
                {
                    return segment.StartPoint;
                }
                else
                {
                    return segment.EndPoint;
                }
            }
        }
        public TBPoint endPoint
        {
            get
            {
                if (direction == LineDirection.positive)
                {
                    return segment.EndPoint;
                }
                else
                {
                    return segment.StartPoint;
                }
            }
        }
        public LoopSeg(TBPLineSegment seg,LineDirection dir)
        {
            segment = seg;
            direction = dir;
        }

        public LoopSeg(TBPLineSegment seg, TBPoint startP)
        {
            segment = seg;
            if (startP == seg.StartPoint)
            {
                direction = LineDirection.positive;
            }
            else if (startP == seg.EndPoint)
            {
                direction = LineDirection.negtive;
            }
            else
            {
                throw new System.Exception("BoundarySeg.cs 39");
            }
        }

        public List<Point3d> getInnerPoints()
        {
            List<Point3d> r=new List<Point3d>();
            if(segment==null||segment.acPline.EndParam<=1){
                return r;
            }
            
            for(int i=1;i<this.segment.acPline.EndParam;i++){
                r.Add(segment.acPline.GetPointAtParameter(i));
            }
            if (direction == LineDirection.negtive)
            {
                r.Reverse();
            }
            return r;
        }

        public Polyline3d toPolyline3d()
        {
            return this.segment.acPline;
        }
        public static List<Polyline3d> toPolyline3d(List<LoopSeg> loopSeg)
        {
            if (loopSeg == null) return null;
            List<Polyline3d> r = new List<Polyline3d>();
            for (int i = 0; i < loopSeg.Count; i++)
            {
                r.Add(loopSeg[i].toPolyline3d());
            }
            return r;
        }
        public static void add2DBObjectCollection(DBObjectCollection dbc, List<LoopSeg> segs)
        {
            if (segs == null) return;
            
            for (int i = 0; i < segs.Count; i++)
            {
                dbc.Add(segs[i].toPolyline3d());
            }
        }
    }

    public enum LineDirection
    {
        positive=0,
        negtive=1
    }
}
