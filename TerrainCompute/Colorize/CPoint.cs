using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
namespace TerrainComputeC.Colorize
{
    public  class CPoint
    {
        public Point3d point;
        public CContour contour;
        public CBoundary Boundary
        {
            get
            {
                return boundary;
            }
            set
            {
                boundary = value;
                boundary.add(this);
            }
        }
        CBoundary boundary;
        public double elevation;
        public double param;
        public CPoint(Point3d p)
        {
            point = p;
        }
    }

    public class CPointComparer : IComparer<CPoint>
    {
        public int Compare(CPoint left, CPoint right)
        {

            if (left.param > right.param)
                return 1;
            else if (left.param == right.param)
                return 0;
            else
                return -1;
        }
    }

}
