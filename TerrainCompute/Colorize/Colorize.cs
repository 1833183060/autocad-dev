using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
using TerrainComputeC.My;
namespace TerrainComputeC.Colorize
{	
	public class ColorizeBase
	{
		static ColorizeBase()
		{
			
		}
        
        public ColorizeBase()
		{            
		}
        public static Color getColorIndex(MyDB2 mydb,double elevation){
            TEDictionary ted = mydb.TEDicList[mydb.Resolution];
            return getColorIndex(elevation, ted.maxMaxZ, ted.minMinZ, mydb.tcSetting.FaceColorList2.colorList);
        }
        public static Color getColorIndex(double elevation,double maxZ,double minZ,List<System.Drawing.Color> cl){
            double range=maxZ-minZ;
            double sec = range / cl.Count;	
            int colorIndex;
                            
            colorIndex=(int)Math.Floor((elevation- minZ) / sec);
                            
            if (colorIndex >= cl.Count)
            {
                colorIndex = cl.Count - 1;
            }
            return Autodesk.AutoCAD.Colors.Color.FromColor (cl[colorIndex]);
        }
        public static List<System.Drawing.Color> genColorList(int count)
        {
            List<System.Drawing.Color> r = new List<System.Drawing.Color>();
            int step = 255 * 4 / count;
            for (int i = 0; i < count; i++)
            {
                r.Add(getColor(step*i));
            }
            return r;
        }
        static System.Drawing.Color getColor(int num){
            System.Drawing.Color c = new System.Drawing.Color();
            int count = num / 255;
            int remainder = num % 255;
            switch (count)
            {
                case 0:
                    c = System.Drawing.Color.FromArgb(255, remainder, 0);
                    break;
                case 1:
                    c = System.Drawing.Color.FromArgb(255-remainder, 255, 0);
                    break;
                case 2:
                    c = System.Drawing.Color.FromArgb(0, 255, remainder);
                    break;
                case 3:
                    c = System.Drawing.Color.FromArgb(0, 255-remainder, 255);
                    break;
                case 4:
                    c = System.Drawing.Color.FromArgb(0, 0, 255);
                    break;
            }
            return c;
        }
	}
}
