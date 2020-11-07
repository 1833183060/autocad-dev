using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

using Autodesk.AutoCAD.Colors;
namespace AcadUtil
{
    public class MyColor
    {
        public static Color RandomColor(int seedR,int seedG,int seedB)
        {
            Random randomr = new Random(seedR);
            int r = randomr.Next(0, 256);
            Random randomg = new Random(seedG);
            int g = randomg.Next(0, 256);
            Random randomb = new Random(seedB);
            int b = randomb.Next(0, 256);
            return Color.FromRgb((byte)r, (byte)g, (byte)b);
        }
    
    }
}
