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
using TerrainComputeC.BASE;
namespace TerrainComputeC.Colorize
{	 
	public class ContourColorize
	{
		static ContourColorize()
		{
			ContourColorize.int_0 = 6;
			ContourColorize.string_0 = "AR";
			ContourColorize.string_1 = "N";
			ContourColorize.double_0 = 0.0;
			ContourColorize.double_1 = 100.0;
		}

        public List<CContour> ccontours;
        public ContourColorize()
		{
            ccontours = new List<CContour>();
		}
        public void addContour(List<PLine> plines,double elevation)
        {
            for(int i=0;i<plines.Count;i++){
                CContour cc = new CContour();
                cc.elevation = elevation;
                PLine pl=plines[i];
                cc.isClosed = pl.IsClosed;
                cc.pline = pl;
                if (!cc.isClosed)
                {                    
                    cc.StartP =MyConvert.toCPoint( pl.GetVertices()[0]);
                    cc.StartP.elevation = elevation;
                    cc.endP = MyConvert.toCPoint(pl.GetVertices()[pl.GetVertices().Count-1]);
                    cc.endP.elevation = elevation;
                }
                ccontours.Add(cc);
            }
            
        }

        public void calcIntersection()
        {
            ObjectId[] boundary = Selection.getBoundarys();
            List<CBoundary> cbs = new List<CBoundary>();
            Database db = HostApplicationServices.WorkingDatabase;
            using(Transaction trans=db.TransactionManager.StartTransaction()){
                for (int n = 0; n < boundary.Length; n++)
                {
                    Polyline3d pl = trans.GetObject(boundary[n], OpenMode.ForRead) as Polyline3d;
                    if (pl == null) continue;
                    CBoundary cb = new CBoundary(pl);
                    
                }
                for (int i = 0; i < this.ccontours.Count; i++)
                {
                    CContour cc=this.ccontours[i];
                    if (cc.isClosed) continue;
                    for (int j = 0; j < cbs.Count; j++)
                    {
                        CBoundary cb = cbs[j];
                        Polyline3d pl = cb.pl3d;
                        double p = pl.GetParameterAtPoint(cc.StartP.point);
                        if (p >= 0)
                        {
                            cc.StartP.param = p;
                            cc.StartP.Boundary = cb;
                            
                        }
                        p = pl.GetParameterAtPoint(cc.endP.point);
                        if (p >= 0)
                        {
                            cc.endP.param = p;
                            cc.endP.Boundary = cb;
                        }
                    }
                }
            }
        }

        List<object> calcOuterBoundary(CContour ccontour)
        {
            if (ccontour.isClosed) return null;
            int loopCount = 0;
            List<object> resultBoundary = new List<object>();
            CPoint startp = ccontour.StartP;
            CBoundary cb = startp.Boundary;
            CContour ccontour2=ccontour;
            while (loopCount++>10)
            {
                
                CPoint greaterCPoint = cb.getGreaterCPoint(startp);
                if (greaterCPoint == null) return null;
                resultBoundary.Add(ccontour2);
                resultBoundary.Add(startp);
                resultBoundary.Add(greaterCPoint);
                if (greaterCPoint == ccontour.endP)
                {
                    return resultBoundary;
                }
                ccontour2 = greaterCPoint.contour;
                if (ccontour2.StartP == greaterCPoint)
                {
                    startp = ccontour2.endP;
                }
                else if (ccontour2.endP == greaterCPoint)
                {
                    startp = ccontour2.StartP;
                }
                else
                {
                    throw new System.Exception("ContourColorize 116");
                }
                
                cb = startp.Boundary;
            }
            return null;

        }

        List<object> calcInnerBoundary(List<object> outerB,double elevation)
        {
            return null;
        }
        public static void Colorize(MyDB2 mydb, List<System.Drawing.Color> cl)
		{
            TEDictionary ted = mydb.TEDicList[mydb.Resolution];
            AssistContourDic assistContourDic = mydb.assistContourDics[mydb.Resolution];
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			try
			{				
				double num = 1.7976931348623157E+308;
				double num2 = -1.7976931348623157E+308;
				string formatFromLUPREC = DBManager.GetFormatFromLUPREC();
				string a;
                double range=ted.maxMaxZ-ted.minCZ;
                
                double sec = range / cl.Count;				
					
					progressMeter.SetLimit(assistContourDic.elevations.Count);
					progressMeter.Start("Colorizing property");
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
                        BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                        BlockTableRecord arg_3D7_0 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
						int i = 0;
                        while (i < assistContourDic.elevations.Count)
						{
							try
							{
								progressMeter.MeterProgress();
								messageFilter.CheckMessageFilter((long)i, 1000);
							}
                            catch (System.Exception ex)
							{
								progressMeter.Stop();
								throw;
							}
                            int colorIndex;
                            double elevation = assistContourDic.elevations[i];
                            List<BASE.PLine> pls=assistContourDic.plines[i];
                            
                                colorIndex=(int)Math.Floor((elevation- ted.minCZ) / sec);
                            
                            if (colorIndex >= cl.Count)
                            {
                                colorIndex = cl.Count - 1;
                            }	
                            //Face face = (Face)transaction.GetObject(triList[i].AcDbFace.ObjectId, (OpenMode)1);
                            for(int j=0;j<pls.Count;j++){
                                PointSet ps= pls[j].GetVertices();
                                if(ps.Count<=2)continue;
                                Region h = MyRegion.NewRegion(ps[1]);
                                if (h != null)
                                {
                                    h.Color =Autodesk.AutoCAD.Colors.Color.FromColor (cl[colorIndex]);
                                }
                                
                            }                            
                            
							i++;
							continue;                            
						}
						transaction.Commit();
						
					}
					
					progressMeter.Stop();
					return;
				
				
                throw new System.Exception("Invalid target property");
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				editor.WriteMessage("\n" + ex.Message);
			}
		}

        static void genIntersection(MyDB2 mydb)
        {
            ObjectId[] boundary = Selection.getBoundarys();
            ObjectId[] contours = Selection.getContours(LayerUtil.contourLayerName(mydb.Resolution));
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction tran = db.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < contours.Length; i++)
                {
                    Polyline pl = tran.GetObject(contours[i], OpenMode.ForRead) as Polyline;
                    for (int j = 0; j < boundary.Length; j++)
                    {
                        Polyline b = tran.GetObject(boundary[i], OpenMode.ForRead) as Polyline;
                        double p=b.GetParameterAtPoint(pl.StartPoint);
                    }
                }
            }
        }
		private static double double_0;

		private static double double_1;

		private static int int_0;

		private static string string_0;

		private static string string_1;
	}
}
