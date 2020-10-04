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
    public class TBPoint
    {
        #region 静态
        public static List<TBPoint> allPoints=new List<TBPoint>();
        #endregion
        public Point3d acPoint;
        public List<TBPLine> tbPlines;
        List<TBPLineSegment> SegmentedPLines
        {
            get { 
                return segmentedPLines; 
            }
            set
            {
                segmentedPLines = value;
            }
        }
        List<TBPLineSegment> segmentedPLines;
        public double TempParam
        {
            get { return tempParam; }
            set
            {
                tempParam = value;
                if (tempParam < 0)
                {
                    throw new System.Exception("TBPoint 33");
                }
            }
        }
        double tempParam;
        TBPoint(Point3d p)
        {
            acPoint = p;
            tbPlines = new List<TBPLine>();
            SegmentedPLines = new List<TBPLineSegment>();
            allPoints.Add(this);
        }
        public static TBPoint getNewTBPoint(Point3d p){
            for(int i=0;i<allPoints.Count;i++){
                Point3d oldPoint=allPoints[i].acPoint;
                if(Math.Abs(oldPoint.X-p.X)<1e-10&&Math.Abs(oldPoint.Y-p.Y)<1e-10&&Math.Abs(oldPoint.Z-p.Z)<1e-10){
                    return allPoints[i];
                }
            }
            return new TBPoint(p);
        }

        public void addSegment(TBPLineSegment seg)
        {
            segmentedPLines.Add(seg);
        }
        public void sort()
        {
            SegmentedPLines.Sort(new TBPLineSegmentComparer(this));
        }
        int getIndex(TBPLineSegment seed)
        {
            
            int r=this.SegmentedPLines.FindIndex(item =>
            {
                if (item == seed) return true;
                return false;
            });
            return r;
        }
        public TBPLineSegment nextSegment(TBPLineSegment seg)
        {
            int index = getIndex(seg);
            if (index < 0) throw new System.Exception("TBPoint 51.index<0");
            int previousIndex = -1;
            if (index == 0)
            {
                previousIndex = this.SegmentedPLines.Count - 1;
            }
            else
            {
                previousIndex = index - 1;
            }
            return this.SegmentedPLines[previousIndex];
        }

        public bool equalTo(TBPoint p2)
        {
            bool r = (Math.Abs(this.acPoint.X - p2.acPoint.X) < 1e-10) && (Math.Abs(this.acPoint.Y - p2.acPoint.Y)<1e-10);
            return r;
        }
        public string toString()
        {
            return "(" + acPoint.X + "," + acPoint.Y + ")";
        }
    }

    public class TBPointComparer : IComparer<TBPoint>
    {        
        public int Compare(TBPoint left, TBPoint right)
        {

            if (left.TempParam > right.TempParam)
                return 1;
            else if (Math.Abs(left.TempParam -right.TempParam)<1e-10)
                return 0;
            else
                return -1;
        }
    }

}
