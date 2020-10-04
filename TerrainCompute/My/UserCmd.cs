using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;
using TerrainComputeC.Colorize;

namespace TerrainComputeC.My
{
    public class UserCmd
    {
        #region 静态成员
        public static UserCmd CurCmd;
        public static string boundaryLayerName="boundary";
        public static string contourLNPrefix = "contour_";
        #endregion
        public MyDB2 mydb { get; set; }
        public CoordinateView coord;
        public ContourColorize2 contColorize;
        public UserCmd()
        {
            mydb = MyDB2.load();
            if (mydb == null) { 
                mydb = new MyDB2();
                //reset();
                resetLine();
            }
            else
            {
                resetLine();
            }
            UserCmd.CurCmd = this;
            coord = new CoordinateView(mydb);
            //this.contColorize = new ContourColorize2();
        }
        [CommandMethod("TerrainComputeC", "tc:main", CommandFlags.Interruptible)]
        public void main()
        {
            Form1 f=new Form1(this);
            Application.ShowModelessDialog(f);
        }
        [CommandMethod("TerrainComputeC", "tc:scale", CommandFlags.Modal)]
        public void setScale()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptDoubleResult r= ed.GetDouble("\nz方向缩放比例：");
            if(r.Status==PromptStatus.OK){
                mydb.tcSetting.Scale.Z =(double)r.Value;
            }
            
        }

        [CommandMethod("TerrainComputeC", "tc:ccount", CommandFlags.Modal)]
        public void setColorCount()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptIntegerResult r = ed.GetInteger("\n填充所用颜色数量：");
            if (r.Status == PromptStatus.OK)
            {
                mydb.tcSetting.ColorCount = r.Value;
            }

        }
        [CommandMethod("TerrainComputeC", "tc:space", CommandFlags.Modal)]
        public void setContourSpace()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptDoubleResult r = ed.GetDouble("\n等高线间隔：");
            if (r.Status == PromptStatus.OK)
            {
                mydb.tcSetting.ContourSpace = (double)r.Value;
            }

        }
      
        [CommandMethod("TerrainComputeC", "tc:rs", CommandFlags.Modal)]
        public void reset()
        {
            mydb.resetPoint();
            resetLine();
        }
        
        public void resetLine()
        {
            mydb.LineIds = PreProcess.getAllLines();
        }
        [CommandMethod("TerrainComputeC","tc:tri",CommandFlags.Modal)]
        public void tri()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                ObjectId boundaryLayerId = LayerUtil.CreateLayer(boundaryLayerName, 127, false);
                PointSet ps = mydb.getAllPoint();
                ObjectId[] ids = mydb.LineIds;
                ObjectId[] bidArray = Selection.getBoundarys();

                List<ObjectId> boundaryIds = null;
                if (bidArray == null || bidArray.Length <= 0)
                {
                    boundaryIds = new List<ObjectId>();
                }
                else
                {
                    boundaryIds = bidArray.ToList();
                }

                if (boundaryIds.Count <= 0)
                {
                    List<Point3d> pl = PreProcess.getOuterBoundaryFromLine(ids, null);
                    //List<ObjectId> plineIds = new List<ObjectId>();

                    ObjectId? plineId = MyDBUtility.addPolyline3d(pl, boundaryLayerId, true);

                    if (plineId != null) boundaryIds.Add(plineId.Value);
                    List<Edge> el = MyConvert.ToEdgeList(pl);
                    if (el == null)
                    {
                        ed.WriteMessage("\nel==null");
                    }

                    for (int i = 0; i < el.Count; i++)
                    {
                        //boundary.Add(new Constraint(el[i], Constraint.ConstraintType.Boundary));
                    }
                    List<Point3d> pl2 = this.getInnerBo(ids);
                    ObjectId? plineId2 = MyDBUtility.addPolyline3d(pl2, boundaryLayerId, true);
                    if (plineId2 != null) boundaryIds.Add(plineId2.Value);
                    List<Edge> el2 = MyConvert.ToEdgeList(pl);
                    if (el2 == null)
                    {
                        ed.WriteMessage("\nel2==null");
                    }
                    else
                    {
                        for (int i = 0; i < el2.Count; i++)
                        {
                            //boundary.Add(new Constraint(el2[i], Constraint.ConstraintType.Boundary));
                        }
                    }
                }
                else
                {

                }
                List<Constraint> boundary = new List<Constraint>();
                List<Edge> list4 = Conversions.ToCeometricEdgeList(boundaryIds.ToArray());
                for (int j = 0; j < list4.Count; j++)
                {
                    boundary.Add(new Constraint(list4[j], Constraint.ConstraintType.Boundary));
                }

                Triangulate tri = new Triangulate();
                //tri.TriangulateInternal(ps, new List<Constraint>(), new List<Constraint>());
                LayerUtil.setLayerProp(mydb.getFaceLayerName(), false);
                List<Triangle> tris = tri.TriangulateInternal(ps, new List<Constraint>(), boundary, mydb.getFaceLayerName());
                mydb.setTris(tris);
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage("UserCmd 144 "+ex.Message);
            }
        }

        [CommandMethod("TerrainComputeC","tc:inc",CommandFlags.Modal)]
        public void increasePoint()
        {
            LayerUtil.setLayerProp(mydb.getFaceLayerName(), true);
            mydb.increaseResolution();
            if (LayerUtil.hasName(mydb.getFaceLayerName()))
            {

            }
            else
            {
                tri();
            }
            
            LayerUtil.setLayerProp(mydb.getFaceLayerName(), false);
        }
        public void setResolution(int r)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            using (doc.LockDocument())
            {
if(r>mydb.Resolution){
                for (int i = mydb.Resolution; i < r; i++)
                {
                    this.increasePoint();                
                }
            }
            else if (r < mydb.Resolution)
            {
                for (int i = mydb.Resolution; i > r; i--)
                {
                    this.decreasePoint();
                }
            }
            }
            
            
        }
        [CommandMethod("TerrainComputeC", "tc:dec", CommandFlags.Modal)]
        public void decreasePoint()
        {
            LayerUtil.setLayerProp(mydb.getFaceLayerName(), true);
            mydb.decreaseResolution();
            LayerUtil.setLayerProp(mydb.getFaceLayerName(), false);
        }
        [CommandMethod("TerrainComputeC", "tc:fc", CommandFlags.Modal)]
        public void faceColorize()
        {
            FaceColorize.Colorize(mydb,mydb.tcSetting.FaceColorList2.colorList,mydb.tcSetting.FCType);
        }

        [CommandMethod("TerrainComputeC", "tc:cc2", CommandFlags.Modal)]
        public void contourColorize2()
        {            
            this.contColorize.colorize(mydb, mydb.tcSetting.FaceColorList2.colorList);
        }
        [CommandMethod("TerrainComputeC", "tc:cc", CommandFlags.Modal)]
        public void contourColorize()
        {
            ContourColorize.Colorize(mydb, mydb.tcSetting.FaceColorList2.colorList);
        }

        [CommandMethod("TerrainComputeC", "tc:co", CommandFlags.Modal)]
        public void drawCoord()
        {
            coord.draw();
        }

        [CommandMethod("TerrainComputeC", "tc:contour", CommandFlags.Modal)]
        public void contour()
        {
            this.contColorize = new ContourColorize2();
            TEDictionary ted = mydb.TEDicList[mydb.Resolution];
            //ted.maxCZ - ted.minCZ;
            //double start=ted.minMinZ-10;
            //double end = ted.maxMaxZ + 10;
            double start=-10 * mydb.tcSetting.Scale.Z;
            double end = 10 * mydb.tcSetting.Scale.Z;
            start = Math.Min(start, ted.minMinZ - 10);
            end = Math.Max(end, ted.maxMaxZ + 10);
            double space = mydb.tcSetting.ContourSpace;
            BASE.ContourLineComputation cont = new BASE.ContourLineComputation();
            cont.Contour(this, "W", start, end/*10 * mydb.tcSetting.Scale.Z*/, space, "E", "Contour_line_");
        }
        [CommandMethod("TerrainComputeC", "tc:tri2", CommandFlags.Modal)]
        public void tri2()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PointSet ps = PreProcess.getPointFromText(mydb.tcSetting.Scale);
            ObjectId[] ids = PreProcess.getAllLines();

            List<Constraint> boundary = new List<Constraint>();
            //int plCount = 0;
            ObjectId[] objectIDs3 = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.PLINES, "Select boundaries (polylines)", false);
            if (objectIDs3 != null)
            {
                string text3 = " boundary";
                if (objectIDs3.Length > 1)
                {
                    text3 += "s";
                }
                //editor.WriteMessage(objectIDs3.Length + text3 + " selected.");
                //plCount = this.getPolylineCount(objectIDs3);
                List<Edge> list4 = Conversions.ToCeometricEdgeList(objectIDs3);
                for (int j = 0; j < list4.Count; j++)
                {
                    boundary.Add(new Constraint(list4[j], Constraint.ConstraintType.Boundary));
                }
            }
            else
            {
                //editor.WriteMessage("No boundaries selected.\n");
            }


            Triangulate tri = new Triangulate();
            //tri.TriangulateInternal(ps, new List<Constraint>(), new List<Constraint>());
            tri.TriangulateInternal(ps, new List<Constraint>(), boundary,null);
        }
        public List<Point3d> getInnerBo(ObjectId[] ids)
        {           

            if (mydb.InnerBoPL == null||mydb.InnerBoPL.Count==0)
            {
                Point3d? p = getInnerBoPoint();
                if (p == null) return null;
                if (mydb.InnerBoPL == null)
                {
                    mydb.InnerBoPL = new List<Point>();
                }                
                mydb.InnerBoPL.Add(new Point(p.Value.X,p.Value.Y,p.Value.Z));
            }
            List<Point3d> lp = PreProcess.getOuterBoundaryFromLine(ids, MyConvert.toPoint3d(mydb.InnerBoPL[0]));

            return lp;
        }

        private Point3d? getInnerBoPoint()
        {
            Point3d? innerP = Utility2d.getPoint("\n请指定内边界内一点:");
            if (innerP == null) return null;
            return innerP;
        }


    }
}
