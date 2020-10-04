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
    public class TransformUtil
    {
        public static void Transform(List<Edge> el, Autodesk.AutoCAD.Geometry.Matrix3d matrix)
        {
            for (int i = 0; i < el.Count; i++)
            {
                Transform(el[i], matrix);
            }
        }
        public static void Transform(Edge e,Autodesk.AutoCAD.Geometry.Matrix3d matrix)
        {
            /*Point3d p1 = pl[0], p2 = pl[1], p3 = pl[2];
            Autodesk.AutoCAD.Geometry.Plane plane1 = new Autodesk.AutoCAD.Geometry.Plane(p1, p2, p3);
            Autodesk.AutoCAD.Geometry.Matrix3d prjMat1 = Autodesk.AutoCAD.Geometry.Matrix3d.Projection(plane1, plane1.Normal);*/

            Transform(e.StartPoint, matrix);
            Transform(e.EndPoint, matrix);
            //Point3d prjP = p.TransformBy(prjMat1);
        }
        public static void Transform(ngeometry.VectorGeometry.Point p, Autodesk.AutoCAD.Geometry.Matrix3d matrix)
        {
            Autodesk.AutoCAD.Geometry.Point3d p3d = new Point3d(p.X, p.Y, p.Z);
            Autodesk.AutoCAD.Geometry.Point3d r=p3d.TransformBy(matrix);
            p.X = r.X;
            p.Y = r.Y;
            p.Z = r.Z;
        }
    }
}
