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
using System.Runtime.Serialization;
using System.Security.Permissions;
namespace TerrainComputeC.My
{
    [Serializable]
    public class MyTriangle
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        public MyTriangle(Point p1, Point p2, Point p3)
        {
            Point1 = p1; Point2 = p2; Point3 = p3;
        }
        public MyTriangle(Triangle t)
        {
            Point1 = t.Vertex1; Point2 = t.Vertex2; Point3 = t.Vertex3;
        }
    }
}
