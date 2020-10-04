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
using Utils.Geometry;
using TerrainComputeC.DataUtil;
namespace TerrainComputeC.My
{
    public class PolylineUtil
    {
        public static void getPointsBetween2Point(Polyline3d pl, double startParam, double endParam, Point3dCollection vertexes)
        {
            int n = 0;
            while (true)
            {
                double nextP;
                if (Math.Ceiling(startParam) - startParam < 1e-10)
                {
                    nextP = Math.Ceiling(startParam) + (++n);
                }
                else
                {
                    nextP = Math.Ceiling(startParam) + (n++);
                }

                if (nextP - endParam > 1e-10)
                {
                    break;
                }
                else if (Math.Abs(nextP - endParam) <= 1e-10)
                {
                    break;
                }
                               
                vertexes.Add(pl.GetPointAtParameter(nextP));
                
            }                            
            
        }
    }
}
