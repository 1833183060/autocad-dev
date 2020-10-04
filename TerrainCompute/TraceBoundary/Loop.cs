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
    public class Loop
    {
        public List<LoopSeg> segments;
        public TBPoint startPoint;
        public double scanAngle;
        public List<Loop> innerLoops;
        public List<Loop> neighbourInnerLoops;
        public object userData;
        public Loop()
        {
            segments = new List<LoopSeg>();
        }

        public List<Point3d> toPoints()
        {
            if (segments == null || segments.Count <= 0) return null;
            List<Point3d> r = new List<Point3d>();
            TBPoint start=this.startPoint;
            LoopSeg previousSeg = segments[0];
            r.Add(start.acPoint);
            r.AddRange(previousSeg.getInnerPoints());
            LoopSeg nextSeg=previousSeg;
            for (int i = 1; i < segments.Count; i++)
            {
                nextSeg=segments[i];                
                
                r.Add(nextSeg.startPoint.acPoint);
                r.AddRange(nextSeg.getInnerPoints());
                previousSeg = nextSeg;
            }
            r.Add(nextSeg.endPoint.acPoint);
            return r;
        }

        public DBObjectCollection getOuterLoopObjs()
        {
            DBObjectCollection db = new DBObjectCollection();
            DBObjectCollection dbc = new DBObjectCollection();

            for (int k = 0; k < segments.Count; k++)
            {
                dbc.Add(segments[k].toPolyline3d());
            }            

            return dbc;
        }
        public List<DBObjectCollection> getInnerLoopObjsList()
        {
            if (neighbourInnerLoops == null) return null;
            List<DBObjectCollection> r = new List<DBObjectCollection>();
            
            for (int j = 0; j < neighbourInnerLoops.Count; j++)
            {
                DBObjectCollection dbc = new DBObjectCollection();
                LoopSeg.add2DBObjectCollection(dbc, neighbourInnerLoops[j].segments);
                r.Add(dbc);
            }

            return r;
        }
    }
}
