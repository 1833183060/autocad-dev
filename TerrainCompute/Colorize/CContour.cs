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
using TerrainComputeC.BASE;
namespace TerrainComputeC.Colorize
{
    public  class CContour
    {
        public PLine pline;
        public CPoint StartP
        {
            get
            {
                return startP;
            }
            set
            {
                startP = value;
                startP.contour = this;

            }
        }
        CPoint startP;
        public CPoint endP;
        public double elevation;
        public bool isClosed;
        public bool reversed;//正向或逆向
    }
}
