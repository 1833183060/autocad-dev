using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
//using ngeometry.VectorGeometry;
using TerrainComputeC.BASE;
using TerrainComputeC.XML;

namespace TerrainComputeC.My
{
    public class CoordinateView
    {
        MyDB2 mydb;
        public CoordinateView(MyDB2 db)
        {
            mydb = db;
        }
        public void draw()
        {
            ObjectId layerId = LayerUtil.CreateLayer("coordinate", 0, false);
            Extents3d bounds = MyDBUtility.getExtents(mydb.getAllLine());

            double zlen = 0;
            double minz = -10;
            if (mydb.TEDicList.Count > 0)
            {
                TEDictionary ted = mydb.TEDicList[0];
                zlen = ted.maxMaxZ - ted.minMaxZ;
                zlen += 10;
                minz = ted.minMaxZ - 5;
            }
            

            Point3d ori = bounds.MinPoint.Add(new Vector3d(-10, -10,0));
            ori = ori.Add(new Vector3d(0, 0, (minz - ori.Z)));
            double xlen = bounds.MaxPoint.X - bounds.MinPoint.X+20;
            double ylen = bounds.MaxPoint.Y - bounds.MinPoint.Y+20;
            MyDBUtility.line(ori, new Point3d(ori.X+xlen, ori.Y,ori.Z),layerId);
            MyDBUtility.line(ori, new Point3d(ori.X, ori.Y + ylen,ori.Z),layerId);
            Point3d zstart = ori.Add(new Vector3d(0, ylen, 0));
            Point3d zend = zstart.Add(new Vector3d(0, 0, zlen));
            MyDBUtility.line(zstart, zend, layerId);
            int xcount =(int) xlen / 10;
            int ycount = (int)ylen / 10;
            int zcount = (int)zlen / 5;
            for (int i = 0; i < xcount; i++)
            {
                Point3d s=ori.Add(new Vector3d(i*10,0,0)) ;
                Point3d e=s.Add(new Vector3d(0, -5, 0));
                MyDBUtility.line(s, e,layerId);
                MyDBUtility.text(e,((int)s.X).ToString(),-Math.PI/2,layerId);
            }
            for (int i = 0; i < ycount; i++)
            {
                Point3d s = ori.Add(new Vector3d(0, i*10, 0));
                Point3d e=s.Add(new Vector3d(-5, 0, 0));
                MyDBUtility.line(s, e,layerId);
                MyDBUtility.text(e.Add(new Vector3d(-5,0,0)), ((int)s.Y).ToString(), 0,layerId);
            }

            for (int i = 0; i < zcount; i++)
            {
                Point3d s = ori.Add(new Vector3d(0,ylen, i*5));
                Point3d e = s.Add(new Vector3d(0,5, 0));
                MyDBUtility.line(s, e, layerId);
                MyDBUtility.text(e.Add(new Vector3d(0, 10, 0)), ((int)s.Z).ToString(), 0, layerId);
            }
        }
    }
}
