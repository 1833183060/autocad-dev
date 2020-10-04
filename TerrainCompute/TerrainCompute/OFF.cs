using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class OFF
	{
		static OFF()
		{
			OFF.string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entities.off");
		}

		public OFF()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(OFF));
			//base..ctor();
		}

		public Face GetAcadFace(List<int> faceIndices, List<Point> points)
		{
			if (faceIndices.Count == 3)
			{
				Point point = points[faceIndices[0]];
				Point point2 = points[faceIndices[1]];
				Point point3 = points[faceIndices[2]];
				Point3d point3d=new Point3d(point.X, point.Y, point.Z);
				Point3d point3d2=new Point3d(point2.X, point2.Y, point2.Z);
				Point3d point3d3=new Point3d(point3.X, point3.Y, point3.Z);
				return new Face(point3d, point3d2, point3d3, point3d3, true, true, true, true);
			}
			if (faceIndices.Count == 4)
			{
				Point point4 = points[faceIndices[0]];
				Point point5 = points[faceIndices[1]];
				Point point6 = points[faceIndices[2]];
				Point point7 = points[faceIndices[3]];
				Point3d point3d4=new Point3d(point4.X, point4.Y, point4.Z);
				Point3d point3d5=new Point3d(point5.X, point5.Y, point5.Z);
				Point3d point3d6=new Point3d(point6.X, point6.Y, point6.Z);
				Point3d point3d7=new Point3d(point7.X, point7.Y, point7.Z);
				return new Face(point3d4, point3d5, point3d6, point3d7, true, true, true, true);
			}
			throw new NotImplementedException(string.Concat(new object[]
			{
				"A face with ",
				faceIndices.Count,
				" faces has been requested.",
				Environment.NewLine,
				"Only triangular and quad faces allowed."
			}));
		}

		[CommandMethod("TCPlugin", "ng:IO:OFFIN", 0)]
		public void ReadOFFCommand()
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				CommandLineQuerries.SpecifyFileNameForRead(ref OFF.string_0, "off");
				int num = 0;
				int num2 = 0;
				List<Point> list = new List<Point>();
				List<List<int>> list2 = new List<List<int>>();
				using (StreamReader streamReader = new StreamReader(OFF.string_0))
				{
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					while (streamReader.Peek() >= 0)
					{
						string text = streamReader.ReadLine();
						if (!text.StartsWith("#") && !(text.Trim() == ""))
						{
							string[] array = text.Split(new char[]
							{
								' '
							}, StringSplitOptions.RemoveEmptyEntries);
							if (num3 == 0)
							{
								if (text.Trim().ToUpper() != "OFF")
								{
                                    throw new System.Exception(".OFF file does not start with 'OFF'");
								}
							}
							else if (num3 == 1)
							{
								num4 = Convert.ToInt32(array[0]);
								num5 = Convert.ToInt32(array[1]);
							}
							else if (num3 < num4 + 2)
							{
								double x = Convert.ToDouble(array[0]);
								double y = Convert.ToDouble(array[1]);
								double z = Convert.ToDouble(array[2]);
								list.Add(new Point(x, y, z));
							}
							else if (num3 < num4 + num5 + 2)
							{
								int num6 = Convert.ToInt32(array[0]);
								List<int> list3 = new List<int>();
								for (int i = 0; i < num6; i++)
								{
									list3.Add(Convert.ToInt32(array[i + 1]));
								}
								list2.Add(list3);
							}
							num3++;
						}
					}
				}
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					for (int j = 0; j < list2.Count; j++)
					{
						try
						{
							Face acadFace = this.GetAcadFace(list2[j], list);
							blockTableRecord.AppendEntity(acadFace);
							transaction.AddNewlyCreatedDBObject(acadFace, true);
							num2++;
						}
                        catch (System.Exception ex)
						{
							num++;
						}
					}
					transaction.Commit();
				}
				editor.WriteMessage("\nNumber of triangles read      : " + num2.ToString());
				editor.WriteMessage("\nNumber of degenerate triangles: " + num.ToString());
				DBManager.ZoomExtents();
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private static string string_0;
	}
}
