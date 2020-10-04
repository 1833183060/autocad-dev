using System;
using System.Collections.Generic;
using System.ComponentModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class CMD_ReconstructSurface
	{
		static CMD_ReconstructSurface()
		{
			CMD_ReconstructSurface.string_0 = "L";
			CMD_ReconstructSurface.string_1 = "A";
			CMD_ReconstructSurface.int_0 = 6;
		}

		public CMD_ReconstructSurface()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_ReconstructSurface));
			//base..ctor();
		}

		[CommandMethod("TCPlugin", "ng:LINES:TOFACES", 0)]
		public void DevelopmentCommand()
		{
			Database arg_05_0 = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectLines(false);
				CMD_ReconstructSurface.string_0 = CommandLineQuerries.InsertOnLayer_Current_Line(CMD_ReconstructSurface.string_0);
				CMD_ReconstructSurface.string_1 = CommandLineQuerries.SpecifyOutputType(CMD_ReconstructSurface.string_1);
				CMD_ReconstructSurface.int_0 = CommandLineQuerries.SpecifyInteger("Specify number of relevant decimal digits", CMD_ReconstructSurface.int_0, 0, 12, false, true);
				this.Reconstruct(objectId_);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		private List<List<Edge>> method_0(List<Edge> edges)
		{
			List<List<Edge>> list = new List<List<Edge>>();
			int i = 0;
			IL_B0:
			while (i < edges.Count)
			{
				Edge edge = edges[i];
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
                    if (edge.AcDbLine.LayerId == list[j][0].AcDbLine.LayerId && edge.AcDbLine.Color == list[j][0].AcDbLine.Color)
					{
						list[j].Add(edge);
						flag = true;
						IL_92_:
						if (!flag)
						{
							list.Add(new List<Edge>
							{
								edge
							});
						}
						i++;
						goto IL_B0;
					}
				}
				goto IL_92;
            IL_92:
                {
                
                    if (!flag)
                    {
                        list.Add(new List<Edge>
							{
								edge
							});
                    }
                    i++;
                    goto IL_B0;
                }
			}
			return list;
		}

		public void Reconstruct(ObjectId[] objectId_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<Edge> list = Conversions.ToCeometricAcDbEdgeList(objectId_0);
			List<List<Edge>> list2 = new List<List<Edge>>();
			if (CMD_ReconstructSurface.string_0 == "L")
			{
				list2 = this.method_0(list);
			}
			else
			{
				list2.Add(list);
			}
			ProgressMeter progressMeter = new ProgressMeter();
			try
			{
				for (int i = 0; i < list2.Count; i++)
				{
					List<Edge> list3 = list2[i];
					SurfaceReconstruction surfaceReconstruction = new SurfaceReconstruction(list3);
					surfaceReconstruction.ReconstructSurface(progressMeter, CMD_ReconstructSurface.int_0);
					List<SurfaceReconstruction.Tri> tris = surfaceReconstruction.Tris;
					List<SurfaceReconstruction.Quad> quads = surfaceReconstruction.Quads;
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
                        BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
						string str = "0";
						if (CMD_ReconstructSurface.string_1 == "A" || CMD_ReconstructSurface.string_1 == "T")
						{
							for (int j = 0; j < tris.Count; j++)
							{
								Face acadFace = surfaceReconstruction.GetAcadFace(tris[j]);
								if (CMD_ReconstructSurface.string_0 == "L")
								{
                                    acadFace.SetPropertiesFrom(list3[0].AcDbLine);
								}
								blockTableRecord.AppendEntity(acadFace);
								transaction.AddNewlyCreatedDBObject(acadFace, true);
							}
						}
						if (CMD_ReconstructSurface.string_1 == "A" || CMD_ReconstructSurface.string_1 == "Q")
						{
							for (int k = 0; k < quads.Count; k++)
							{
								Face acadFace2 = surfaceReconstruction.GetAcadFace(quads[k]);
								if (CMD_ReconstructSurface.string_0 == "L")
								{
                                    acadFace2.SetPropertiesFrom(list3[0].AcDbLine);
								}
								blockTableRecord.AppendEntity(acadFace2);
								transaction.AddNewlyCreatedDBObject(acadFace2, true);
							}
						}
						if (tris.Count > 0)
						{
                            str = DBManager.GetLayerName(list3[0].AcDbLine.LayerId);
						}
						if (quads.Count > 0)
						{
                            str = DBManager.GetLayerName(list3[0].AcDbLine.LayerId);
						}
						if (CMD_ReconstructSurface.string_0 == "C")
						{
							str = DBManager.CurrentLayerName();
						}
						transaction.Commit();
						editor.WriteMessage("\n");
						editor.WriteMessage("\nLayer                             : " + str);
						editor.WriteMessage("\nNumber of edges                   : " + list3.Count);
						editor.WriteMessage("\nNumber of triangular faces created: " + tris.Count);
						editor.WriteMessage("\nNumber of quad faces created      : " + quads.Count);
					}
				}
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		private static int int_0;

		private static string string_0;

		private static string string_1;
	}
}
