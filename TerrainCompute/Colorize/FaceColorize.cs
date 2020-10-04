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
namespace TerrainComputeC
{	
	public class FaceColorize
	{
		static FaceColorize()
		{
			FaceColorize.int_0 = 6;
			FaceColorize.string_0 = "AR";
			FaceColorize.string_1 = "N";
			FaceColorize.double_0 = 0.0;
			FaceColorize.double_1 = 100.0;
		}

        public FaceColorize()
		{            
		}


        public static void Colorize(MyDB2 mydb, List<System.Drawing.Color> cl, FaceColorizeType type)
		{
            TEDictionary ted = mydb.TEDicList[mydb.Resolution];
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			try
			{
                ObjectId[] faceIDs = Selection.getFaceIds(mydb.getFaceLayerName());
                List<Triangle> triList = Conversions.ToCeometricAcDbTriangleList(faceIDs);
				Global.SuspendEpsilon(0.0, 0.0);
                //List<Triangle> triList = ted.TriangleList;
				Global.ResumeEpsilon();
				double num = 1.7976931348623157E+308;
				double num2 = -1.7976931348623157E+308;
				string formatFromLUPREC = DBManager.GetFormatFromLUPREC();
				string a;
                double range;
                if (type == FaceColorizeType.CenterZ)
                {
                    range = ted.maxCZ - ted.minCZ;
                }
                else if (type == FaceColorizeType.MaxZ)
                {
                    range = ted.maxMaxZ - ted.minMaxZ;
                }
                else
                {
                    throw new System.Exception("无效的颜色类型");
                }
                double sec = range / cl.Count;
				
					
					progressMeter.SetLimit(triList.Count);
					progressMeter.Start("Colorizing property");
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
                        BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                        BlockTableRecord arg_3D7_0 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
						int i = 0;
						while (i < triList.Count)
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
                            if (type == FaceColorizeType.CenterZ)
                            {
                                colorIndex=(int)Math.Floor((triList[i].Center.Z - ted.minCZ) / sec);
                            }
                            else if (type == FaceColorizeType.MaxZ)
                            {
                                colorIndex =(int)Math.Floor((Math.Max(Math.Max(triList[i].Vertex1.Z,triList[i].Vertex2.Z),triList[i].Vertex3.Z)-ted.minMaxZ)/ sec);
                            }
                            else
                            {
                                throw new System.Exception("无效的类型");
                            }
                            if (colorIndex >= cl.Count)
                            {
                                colorIndex = cl.Count - 1;
                            }	
                            Face face = (Face)transaction.GetObject(triList[i].AcDbFace.ObjectId, (OpenMode)1);
                            
                            face.Color =Autodesk.AutoCAD.Colors.Color.FromColor (cl[colorIndex]);
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

		private static double double_0;

		private static double double_1;

		private static int int_0;

		private static string string_0;

		private static string string_1;
	}
}
