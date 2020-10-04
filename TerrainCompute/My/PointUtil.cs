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
    public class PointUtil
    {
        /*public Point3d maxZPoint(List<Point3d> pl)
        {
            return null;
        }*/
        public static bool equal2(Point3d p1,Point3d p2){
             bool r = (Math.Abs(p1.X - p2.X) < 1e-10) && (Math.Abs(p1.Y - p2.Y)<1e-10);
            return r;
        }
    }
}
