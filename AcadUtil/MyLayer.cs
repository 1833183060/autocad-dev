﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;

namespace AcadUtil
{
    public class MyLayer
    {
        public static void SetCLayer(string name,Autodesk.AutoCAD.Colors.Color color)
        {
            bool r=true;
            DBManager.CreateLayer(name, color,false,ref r);
            Application.SetSystemVariable("clayer", name);
        } 
    }
}
