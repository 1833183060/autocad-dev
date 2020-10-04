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
using Autodesk.AutoCAD.Geometry;
namespace TerrainComputeC.My
{
    public class MyGeom
    {
        //Point inside a polyline came from the Solution 2 (2d) section of this website http://paulbourke.net/geometry/insidepoly/

        /// <summary>
        /// Check if the point is within the polyline
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static bool InsidePolygon(Polyline polygon, Point3d pt)
        {
            int n = polygon.NumberOfVertices;
            double angle = 0;
            Point pt1, pt2;

            for (int i = 0; i < n; i++)
            {
                pt1.X = polygon.GetPoint2dAt(i).X - pt.X;
                pt1.Y = polygon.GetPoint2dAt(i).Y - pt.Y;
                pt2.X = polygon.GetPoint2dAt((i + 1) % n).X - pt.X;
                pt2.Y = polygon.GetPoint2dAt((i + 1) % n).Y - pt.Y;
                angle += Angle2D(pt1.X, pt1.Y, pt2.X, pt2.Y);
            }

            if (Math.Abs(angle) < Math.PI)
                return false;
            else
                return true;
        }

        public static bool InsidePolygon(List<Point3d> points, Point3d pt)
        {
            Point3dCollection pc=new Point3dCollection(points.ToArray());
            Polyline3d p = new Polyline3d(Poly3dType.SimplePoly, pc, false);
            Polyline pline=new Polyline();
            
            for(int k=0;k<points.Count;k++){
                Point3d curP=points[k];
                pline.AddVertexAt(k,new Point2d(curP.X,curP.Y),0,0,0);
            }
            pline.Closed=true;
            if (IsPointOnPolyline(pline, pt))
            {
                return false;
            }
            int n = points.Count;
            double angle = 0;
            Point pt1, pt2;

            for (int i = 0; i < n; i++)
            {
                pt1.X = points[i].X - pt.X;
                pt1.Y = points[i].Y - pt.Y;
                pt2.X = points[(i + 1) % n].X - pt.X;
                pt2.Y = points[(i + 1) % n].Y - pt.Y;
                angle += Angle2D(pt1.X, pt1.Y, pt2.X, pt2.Y);
            }

            if (Math.Abs(angle) < Math.PI)
                return false;
            else
                return true;
        }
        
        //http://geomalgorithms.com/a03-_inclusion.html
        // cn_PnPoly(): crossing number test for a point in a polygon
        //      Input:   P = a point,
        //               V[] = vertex points of a polygon V[n+1] with V[n]=V[0]
        //      Return:  0 = outside, 1 = inside
        // This code is patterned after [Franklin, 2000]
        public static bool cn_PnPoly(List<Point3d> V,Point3d P)
        {
            int cn = 0;    // the  crossing number counter
            // loop through all edges of the polygon
            for (int i = 0; i < V.Count-1; i++)
            {    // edge from V[i]  to V[i+1]
                if (((V[i].Y <= P.Y) && (V[i + 1].Y > P.Y))     // an upward crossing
                 || ((V[i].Y > P.Y) && (V[i + 1].Y <= P.Y)))
                { // a downward crossing
                    // compute  the actual edge-ray intersect x-coordinate
                    double vt = (P.Y - V[i].Y) / (V[i + 1].Y- V[i].Y);
                    if (Math.Abs(P.X - (V[i].X + vt * (V[i + 1].X - V[i].X))) <= 1e-10)
                    {
                        return false;
                    }
                    if (P.X < V[i].X + vt * (V[i + 1].X- V[i].X)) // P.x < intersect
                        ++cn;   // a valid crossing of y=P.y right of P.x
                }
            }
            int r= (cn & 1);    // 0 if even (out), and 1 if  odd (in)
            if (r == 0) return false;
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Point structure to add InsidePolygon function
        /// </summary>
        public struct Point
        {
            public double X, Y;
        };

        /*
           
        */
        /// <summary>
        /// Return the angle between two vectors on a plane
        /// The angle is from vector 1 to vector 2, positive anticlockwise
        /// The result is between -pi -> pi
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double Angle2D(double x1, double y1, double x2, double y2)
        {
            double dtheta, theta1, theta2;

            theta1 = Math.Atan2(y1, x1);
            theta2 = Math.Atan2(y2, x2);
            dtheta = theta2 - theta1;
            while (dtheta > Math.PI)
                dtheta -= (Math.PI * 2);
            while (dtheta < -Math.PI)
                dtheta += (Math.PI * 2);
            return (dtheta);
        }

    private static bool IsPointOnPolyline(Polyline pl, Point3d pt)
    {
      bool isOn = false;

      for (int i = 0; i < pl.NumberOfVertices; i++)
      {
        Curve3d seg = null;

        SegmentType segType = pl.GetSegmentType(i);

        if (segType == SegmentType.Arc)
          seg = pl.GetArcSegmentAt(i);
        else if (segType == SegmentType.Line)
          seg = pl.GetLineSegmentAt(i);

        if (seg != null)
        {
          isOn = seg.IsOn(pt);

          if (isOn)
            break;
        }
      }
      return isOn;

    }

  }
    }

