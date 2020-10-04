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
    public  class CBoundary
    {
        List<CPoint> pl;
        public Polyline3d pl3d;
        public CBoundary(Polyline3d pl)
        {
            pl = new Polyline3d();
            pl3d = pl;
        }
        public void sort()
        {
            pl.Sort(new CPointComparer());
        }
        public void add(CPoint p)
        {
            pl.Add(p);
        }

        public CPoint getGreaterCPoint(CPoint lessP)
        {
            int i=pl.FindIndex(item =>
            {
                CPoint seed = item as CPoint;
                if (seed == lessP)
                {
                    return true;
                }
                return false;
            });
            if (i < 0)
            {
                throw new System.Exception("CBoundary 45");
            }
            else if (i >= pl.Count)
            {
                throw new System.Exception("CBoundary 49");
            }
            int j = i + 1;
            if (j>=pl.Count )
            {
                return null;
            }
            else
            {
                if (pl[j].param > lessP.param)
                {
                    return pl[j];
                }
                
            }
            j = i - 1;
            if (j < 0)
            {
                return null;
            }
            else
            {
                if (pl[j].param > lessP.param)
                {
                    return pl[j];
                }
            }

            return null;
        }
    }
}
