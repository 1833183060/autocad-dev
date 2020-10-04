using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;
using TerrainComputeC;

namespace TerrainComputeC
{
    public class Modify
    {
        public static void Scale(PointSet pointSet,int i,double scale)
        {
            foreach (Point p in pointSet)
            {
                p.X *= scale;
            }
        }
    }
}
