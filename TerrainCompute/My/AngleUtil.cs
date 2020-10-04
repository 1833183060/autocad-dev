using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Geometry;
namespace TerrainComputeC.My
{
    public class AngleUtil
    {
        public static double scanAngle(Point3d p1, Point3d p2, Point3d p3)
        {
            return scanAngle(new Point2d(p1.X, p1.Y), new Point2d(p2.X, p2.Y), new Point2d(p3.X, p3.Y));
        }
        public static double scanAngle(Point2d p1, Point2d p2, Point2d p3)
        {
            Vector3d v = new Vector3d(p2.X - p1.X, p2.Y - p1.Y,0);
            Vector3d v2 = new Vector3d(p3.X - p2.X, p3.Y - p2.Y,0);
            double angle = scanAngle(v, v2);
            if (angle == 0)
            {
                //三点共线，扫描角可以为0
                //throw new System.Exception("扫描角为0");
            }
            
            return angle;
        }
        public static double scanAngle(Vector3d v1, Vector3d v2)
        {
            double a = v1.GetAngleTo(v2);
            Vector3d v3 = v1.CrossProduct(v2);
            if (v3.Z > 0) return a;
            else if (v3.Z < 0) return -1 * a;
            else return a;
        }
        public static double CWAngle(Vector3d v1,Vector3d v2)
        {//v1 沿顺时针到v2扫过的角度
            double angle = scanAngle(v1, v2);
            if (angle < 0)
            {
                angle = angle + 2 * Math.PI;
            }
            return angle;
        }
    }
}
