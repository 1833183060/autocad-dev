﻿using System;
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
using TerrainComputeC.TraceBoundary;
namespace TerrainComputeC.Colorize
{
    public  class CContour2
    {
        public TBPLine tbPLine;
        
        public double elevation;
    }
}
