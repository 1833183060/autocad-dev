using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
using TerrainComputeC.XML;

namespace TerrainComputeC.BASE
{
	//////[LicenseProvider(typeof(Class46))]
	public class IO2
	{
		static IO2()
		{
			IO2.string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entities.xml");
			IO2.string_1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entities.xml");
			IO2.string_2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "faces.3df");
			IO2.string_3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "faces.3df");
			IO2.string_4 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "points.xyz");
			IO2.string_5 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "points.xyz");
			IO2.string_6 = "S";
			IO2.string_7 = DBManager.CurrentLayerName();
			IO2.string_8 = "N";
			IO2.string_9 = "S";
			IO2.int_0 = 9;
			IO2.int_1 = 4;
		}

		public IO2()
		{
            ////System.ComponentModel.LicenseManager.Validate(typeof(IO2));
			//base..ctor();
		}

		public static string AutoDetermineDelimiter(string fileName, bool hasLayerFirst)
		{
			string text = "";
			int num = 0;
			using (StreamReader streamReader = new StreamReader(fileName))
			{
				while (streamReader.Peek() >= 0)
				{
					num++;
					text = streamReader.ReadLine();
					if (!text.StartsWith("C", true, null))
					{
						break;
					}
				}
			}
			int num2 = 0;
			int num3 = 1;
			int num4 = 2;
			if (hasLayerFirst)
			{
				num2++;
			}
			if (hasLayerFirst)
			{
				num3++;
			}
			if (hasLayerFirst)
			{
				num4++;
			}
			try
			{
				if (text.Contains("\t"))
				{
					string result = "\t";
					return result;
				}
				string[] array = text.Split(new char[]
				{
					','
				});
				if (array.Length >= num4)
				{
					double num5;
					bool flag = double.TryParse(array[num2], out num5);
					double num6;
					bool flag2 = double.TryParse(array[num3], out num6);
					if (flag && flag2)
					{
						string result = ",";
						return result;
					}
				}
				string[] array2 = text.Split(new char[]
				{
					';'
				});
				if (array2.Length >= num4)
				{
					double num7;
					bool flag3 = double.TryParse(array2[num2], out num7);
					double num8;
					bool flag4 = double.TryParse(array2[num3], out num8);
					if (flag3 && flag4)
					{
						string result = ";";
						return result;
					}
				}
				string[] array3 = text.Split(new char[]
				{
					' '
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length >= num4)
				{
					double num9;
					bool flag5 = double.TryParse(array3[num2], out num9);
					double num10;
					bool flag6 = double.TryParse(array3[num3], out num10);
					if (flag5 && flag6)
					{
						string result = " ";
						return result;
					}
				}
			}
            catch (System.Exception ex)
			{
                Console.Write("aaaaa");
			}
            throw new System.Exception(string.Concat(new object[]
			{
				"Invalid format at line ",
				num,
				":\n",
				text
			}));
		}

		[CommandMethod("TCPlugin", "ng:3DFIN", 0)]
		public void IN3DF()
		{
			try
			{
				////LicenseManager.CheckValid("FULL");
				CommandLineQuerries.SpecifyFileNameForRead(ref IO2.string_3, "3df");
				this.method_2();
			}
            catch (System.Exception ex)
			{
                Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		private void method_0()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			editor.WriteMessage("\nReading xml file " + IO2.string_1 + "...");
			EntityList entityList = Serializer.Deserialize(IO2.string_1);
			editor.WriteMessage("OK\n");
			editor.WriteMessage("\nEntities deserialized from XML:");
			editor.WriteMessage("\nNumber of points        : " + entityList.Points.Count);
			editor.WriteMessage("\nNumber of lines         : " + entityList.Lines.Count);
			editor.WriteMessage("\nNumber of polylines     : " + entityList.Polylines.Count);
			editor.WriteMessage("\nNumber of faces         : " + entityList.Faces.Count);
			editor.WriteMessage("\nTotal number of entities: " + entityList.Count);
			DBManager.WriteEntityListInDatabase(entityList);
			DBManager.ZoomExtents();
		}

		private void method_1(ObjectId[] objectId_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			EntityList entityList = new EntityList();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(objectId_0.Length);
			progressMeter.Start("Serializing XML entities");
			try
			{
				CoordinateTransformator2 coordinateTransformator = new CoordinateTransformator2(CoordinateSystem.Global(), Conversions.GetUCS());
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
                    LayerTable arg_83_0 = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
					for (int i = 0; i < objectId_0.Length; i++)
					{
						messageFilter.CheckMessageFilter((long)i, 10000);
						progressMeter.MeterProgress();
                        Entity entity = (Entity)transaction.GetObject(objectId_0[i], (OpenMode)0);
                        string name = ((LayerTableRecord)transaction.GetObject(entity.LayerId, (OpenMode)0)).Name;
                        Autodesk.AutoCAD.DatabaseServices.Face face = entity as Autodesk.AutoCAD.DatabaseServices.Face;
						if (face != null)
						{
							Point3d vertexAt = face.GetVertexAt(0);
							Point3d vertexAt2 = face.GetVertexAt(1);
							Point3d vertexAt3 = face.GetVertexAt(2);
							Point3d vertexAt4 = face.GetVertexAt(3);
                            global::TerrainComputeC.XML.Vertex v = new global::TerrainComputeC.XML.Vertex(vertexAt.X, vertexAt.Y, vertexAt.Z);
                            global::TerrainComputeC.XML.Vertex v2 = new global::TerrainComputeC.XML.Vertex(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
                            global::TerrainComputeC.XML.Vertex v3 = new global::TerrainComputeC.XML.Vertex(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
                            global::TerrainComputeC.XML.Vertex v4 = new global::TerrainComputeC.XML.Vertex(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
                            global::TerrainComputeC.XML.Face face2 = new global::TerrainComputeC.XML.Face(v, v2, v3, v4);
							face2.SetProperties(name, face.Color.ColorIndex);
							entityList.Faces.Add(face2);
							coordinateTransformator.Transform(face2);
							num4++;
						}
						else
						{
							DBPoint dBPoint = entity as DBPoint;
							if (dBPoint != null)
							{
                                global::TerrainComputeC.XML.Point point = new global::TerrainComputeC.XML.Point(dBPoint.Position.X, dBPoint.Position.Y, dBPoint.Position.Z);
								point.SetProperties(name, dBPoint.Color.ColorIndex);
								entityList.Points.Add(point);
								coordinateTransformator.Transform(point);
								num++;
							}
							else
							{
								Autodesk.AutoCAD.DatabaseServices.Line line = entity as Autodesk.AutoCAD.DatabaseServices.Line;
								if (line != null)
								{
									Point3d startPoint = line.StartPoint;
									Point3d endPoint = line.EndPoint;
                                    global::TerrainComputeC.XML.Vertex startVertex = new global::TerrainComputeC.XML.Vertex(startPoint.X, startPoint.Y, startPoint.Z);
                                    global::TerrainComputeC.XML.Vertex endVertex = new global::TerrainComputeC.XML.Vertex(endPoint.X, endPoint.Y, endPoint.Z);
                                    global::TerrainComputeC.XML.Line line2 = new global::TerrainComputeC.XML.Line(startVertex, endVertex);
									line2.SetProperties(name, line.Color.ColorIndex);
									entityList.Lines.Add(line2);
									coordinateTransformator.Transform(line2);
									num2++;
								}
								else
								{
									Polyline polyline = entity as Polyline;
									Polyline2d polyline2d = entity as Polyline2d;
									Polyline3d polyline3d = entity as Polyline3d;
									if (polyline != null || polyline2d != null || polyline3d != null)
									{
										short colorIndex = 256;
										if (polyline != null)
										{
											colorIndex = polyline.Color.ColorIndex;
										}
										if (polyline2d != null)
										{
											colorIndex = polyline2d.Color.ColorIndex;
										}
										if (polyline3d != null)
										{
											colorIndex = polyline3d.Color.ColorIndex;
										}
										PointSet pointSet = PointGeneration.SubdividePolyline(entity, transaction, 0.0);
                                        List<global::TerrainComputeC.XML.Vertex> list = new List<global::TerrainComputeC.XML.Vertex>();
										for (int j = 0; j < pointSet.Count; j++)
										{
                                            list.Add(new global::TerrainComputeC.XML.Vertex(pointSet[j].X, pointSet[j].Y, pointSet[j].Z));
										}
										PolyLine polyLine = new PolyLine(list);
										polyLine.SetProperties(name, colorIndex);
										entityList.Polylines.Add(polyLine);
										coordinateTransformator.Transform(polyLine);
										num3++;
									}
								}
							}
						}
					}
				}
				progressMeter.Stop();
				editor.WriteMessage("\nXML entity list created:");
				editor.WriteMessage("\nNumber of points        : " + entityList.Points.Count);
				editor.WriteMessage("\nNumber of lines         : " + entityList.Lines.Count);
				editor.WriteMessage("\nNumber of polylines     : " + entityList.Polylines.Count);
				editor.WriteMessage("\nNumber of faces         : " + entityList.Faces.Count);
				editor.WriteMessage("\nTotal number of entities: " + entityList.Count);
				editor.WriteMessage("\nWriting xml file " + IO2.string_0 + "...");
				Serializer.Serialize(IO2.string_0, entityList);
				editor.WriteMessage("OK\n");
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		private void method_2()
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			string value = IO2.AutoDetermineDelimiter(IO2.string_3, true);
			char c = Convert.ToChar(value);
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			int num = 0;
			using (StreamReader streamReader = new StreamReader(IO2.string_3))
			{
				while (streamReader.Peek() >= 0)
				{
					streamReader.ReadLine();
					num++;
				}
			}
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(num);
			progressMeter.Start("Reading 3df file");
			try
			{
				CoordinateTransformator2 coordinateTransformator = new CoordinateTransformator2(Conversions.GetUCS(), CoordinateSystem.Global());
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					LayerTable lt = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId,  (OpenMode)0);
					BlockTable arg_D1_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)0);
					ObjectId blockModelSpaceId = SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockModelSpaceId,  (OpenMode)1);
					int num2 = 1;
					int num3 = 0;
					using (StreamReader streamReader2 = new StreamReader(IO2.string_3))
					{
						while (streamReader2.Peek() >= 0)
						{
							string text = streamReader2.ReadLine();
							if (!text.StartsWith("C", true, null) && !(text == ""))
							{
								try
								{
									string[] array = text.Split(new char[]
									{
										c
									}, StringSplitOptions.RemoveEmptyEntries);
									string text2 = array[0].Trim();
									if (!DBManager.ValidateName(text2))
									{
                                        throw new System.Exception(string.Concat(new object[]
										{
											"Invalid layer name in line ",
											num2,
											":\n",
											text
										}));
									}
									if (text2 == "")
									{
										text2 = "0";
									}
									double num4 = Convert.ToDouble(array[1]);
									double num5 = Convert.ToDouble(array[2]);
									double num6 = Convert.ToDouble(array[3]);
									double num7 = Convert.ToDouble(array[4]);
									double num8 = Convert.ToDouble(array[5]);
									double num9 = Convert.ToDouble(array[6]);
									double num10 = Convert.ToDouble(array[7]);
									double num11 = Convert.ToDouble(array[8]);
									double num12 = Convert.ToDouble(array[9]);
									double num13 = Convert.ToDouble(array[10]);
									double num14 = Convert.ToDouble(array[11]);
									double num15 = Convert.ToDouble(array[12]);
									coordinateTransformator.Transform(ref num4, ref num5, ref num6);
									coordinateTransformator.Transform(ref num7, ref num8, ref num9);
									coordinateTransformator.Transform(ref num10, ref num11, ref num12);
									coordinateTransformator.Transform(ref num13, ref num14, ref num15);
									Point3d point3d=new Point3d(num4, num5, num6);
									//point3d..ctor(num4, num5, num6);
									Point3d point3d2=new Point3d(num7, num8, num9);
									//point3d2..ctor(num7, num8, num9);
									Point3d point3d3=new Point3d(num10, num11, num12);
									//point3d3..ctor(num10, num11, num12);
									Point3d point3d4=new Point3d(num13, num14, num15);
									//point3d4..ctor(num13, num14, num15);
									Entity entity = new Autodesk.AutoCAD.DatabaseServices.Face(point3d, point3d2, point3d3, point3d4, true, true, true, true);
									entity.LayerId=(DBManager.GetLayerId(text2, 7, lt));
									entity.ColorIndex=(256);
									blockTableRecord.AppendEntity(entity);
									transaction.AddNewlyCreatedDBObject(entity, true);
									num3++;
								}
                                catch (System.Exception ex)
								{
									if (text.Trim() == "")
									{
										text = "Empty line!";
									}
									throw new FormatException(string.Concat(new string[]
									{
										"Invalid format in line ",
										num2.ToString(),
										":",
										Environment.NewLine,
										text,
										Environment.NewLine
									}));
								}
							}
							num2++;
							progressMeter.MeterProgress();
							messageFilter.CheckMessageFilter((long)num2, 1000);
						}
					}
					transaction.Commit();
					progressMeter.Stop();
					editor.WriteMessage(string.Concat(new object[]
					{
						Environment.NewLine,
						num3,
						" faces read.",
						Environment.NewLine
					}));
				}
				DBManager.ZoomExtents();
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		private void method_3(ObjectId[] objectId_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(objectId_0.Length);
			progressMeter.Start("Writing 3df");
			try
			{
				CoordinateTransformator2 coordinateTransformator = new CoordinateTransformator2(CoordinateSystem.Global(), Conversions.GetUCS());
				int num = 0;
				int num2 = 0;
				string text = this.method_6();
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					using (StreamWriter streamWriter = new StreamWriter(IO2.string_2))
					{
						streamWriter.WriteLine(string.Concat(new object[]
						{
							"C ",
							IO2.string_2,
							" generated ",
							DateTime.Now
						}));
						if (text == ",")
						{
							streamWriter.WriteLine("C Format: Layer name, x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4");
						}
						if (text == ";")
						{
							streamWriter.WriteLine("C Format: Layer name; x1; y1; z1; x2; y2; z2; x3; y3; z3; x4; y4; z4");
						}
						if (text == " ")
						{
							streamWriter.WriteLine("C Format: Layer name  x1  y1  z1  x2  y2  z2  x3  y3  z3  x4  y4  z4");
						}
						for (int i = 0; i < objectId_0.Length; i++)
						{
                            Autodesk.AutoCAD.DatabaseServices.Face face = (Autodesk.AutoCAD.DatabaseServices.Face)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							Point3d vertexAt = face.GetVertexAt(0);
							Point3d vertexAt2 = face.GetVertexAt(1);
							Point3d vertexAt3 = face.GetVertexAt(2);
							Point3d vertexAt4 = face.GetVertexAt(3);
							ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(vertexAt.X, vertexAt.Y, vertexAt.Z);
							ngeometry.VectorGeometry.Point point2 = new ngeometry.VectorGeometry.Point(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
							ngeometry.VectorGeometry.Point point3 = new ngeometry.VectorGeometry.Point(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
							ngeometry.VectorGeometry.Point point4 = new ngeometry.VectorGeometry.Point(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
							coordinateTransformator.Transform(point);
							coordinateTransformator.Transform(point2);
							coordinateTransformator.Transform(point3);
							coordinateTransformator.Transform(point4);
							string text2 = face.Layer.PadLeft(IO2.int_0) + text;
							text2 += this.method_5(point, ref num);
							text2 += this.method_5(point2, ref num);
							text2 += this.method_5(point3, ref num);
							text2 += this.method_5(point4, ref num);
							streamWriter.WriteLine(text2.TrimEnd(new char[0]));
							progressMeter.MeterProgress();
							messageFilter.CheckMessageFilter((long)i, 10000);
							num2++;
						}
						streamWriter.Flush();
					}
				}
				progressMeter.Stop();
				if (num > 0)
				{
					editor.WriteMessage(string.Concat(new object[]
					{
						Environment.NewLine,
						num,
						" conversion errors occurred writing ",
						IO2.string_2,
						". Increase the column width and/or decrease the number of decimal digits."
					}));
					Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(string.Concat(new object[]
					{
						num,
						" conversion errors occurred writing ",
						IO2.string_2,
						".\nIncrease the column width and/or decrease the number of decimal digits."
					}));
				}
				FileInfo fileInfo = new FileInfo(IO2.string_2);
				editor.WriteMessage(Environment.NewLine + "Output file name            : " + fileInfo.FullName);
				editor.WriteMessage(Environment.NewLine + "Number of faces written     : " + num2.ToString());
				editor.WriteMessage(Environment.NewLine + "Coordinate conversion errors: " + num.ToString());
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		private void method_4()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			string value = IO2.AutoDetermineDelimiter(IO2.string_4, false);
			char c = Convert.ToChar(value);
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			int num = 0;
			using (StreamReader streamReader = new StreamReader(IO2.string_4))
			{
				while (streamReader.Peek() >= 0)
				{
					streamReader.ReadLine();
					num++;
				}
			}
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(num);
			progressMeter.Start("Reading XYZ");
			try
			{
				CoordinateTransformator2 coordinateTransformator = new CoordinateTransformator2(Conversions.GetUCS(), CoordinateSystem.Global());
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					ObjectId layerId = DBManager.CurrentLayerId();
                    BlockTable arg_C3_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
					ObjectId blockModelSpaceId = SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockModelSpaceId, (OpenMode)1);
					int num2 = 1;
					int num3 = 0;
					using (StreamReader streamReader2 = new StreamReader(IO2.string_4))
					{
						while (streamReader2.Peek() >= 0)
						{
							string text = streamReader2.ReadLine().Trim();
							if (!text.StartsWith("C", true, null))
							{
								try
								{
									string[] array = text.Split(new char[]
									{
										c
									}, StringSplitOptions.RemoveEmptyEntries);
									double num4 = Convert.ToDouble(array[0]);
									double num5 = Convert.ToDouble(array[1]);
									double num6 = 0.0;
									if (array.Length > 2)
									{
										num6 = Convert.ToDouble(array[2]);
									}
									coordinateTransformator.Transform(ref num4, ref num5, ref num6);
									Entity entity = new DBPoint(new Point3d(num4, num5, num6));
									entity.LayerId=(layerId);
									entity.ColorIndex=(256);
									blockTableRecord.AppendEntity(entity);
									transaction.AddNewlyCreatedDBObject(entity, true);
									num3++;
								}
                                catch (System.Exception ex)
								{
									if (text.Trim() == "")
									{
										text = "Empty line!";
									}
									throw new FormatException(string.Concat(new string[]
									{
										"Invalid point data format in line ",
										num2.ToString(),
										":",
										Environment.NewLine,
										text,
										Environment.NewLine
									}));
								}
							}
							num2++;
							progressMeter.MeterProgress();
							messageFilter.CheckMessageFilter((long)num2, 1000);
						}
					}
					transaction.Commit();
					progressMeter.Stop();
					editor.WriteMessage(string.Concat(new object[]
					{
						Environment.NewLine,
						num3,
						" points read",
						Environment.NewLine
					}));
				}
				DBManager.ZoomExtents();
			}
			catch(System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		private string method_5(ngeometry.VectorGeometry.Point point_0, ref int int_2)
		{
			string format = this.method_7(IO2.int_1);
			string text = this.method_6();
			string text2 = point_0.X.ToString(format);
			string text3 = point_0.Y.ToString(format);
			string text4 = point_0.Z.ToString(format);
			if (IO2.int_0 > 0)
			{
				text2 = text2.PadLeft(IO2.int_0);
				text3 = text3.PadLeft(IO2.int_0);
				text4 = text4.PadLeft(IO2.int_0);
				if (text2.Length > IO2.int_0)
				{
					text2 = text2.Remove(0).PadLeft(IO2.int_0, '*');
					int_2++;
				}
				if (text3.Length > IO2.int_0)
				{
					text3 = text3.Remove(0).PadLeft(IO2.int_0, '*');
					int_2++;
				}
				if (text4.Length > IO2.int_0)
				{
					text4 = text4.Remove(0).PadLeft(IO2.int_0, '*');
					int_2++;
				}
			}
			return string.Concat(new string[]
			{
				text2,
				text,
				text3,
				text,
				text4,
				text
			});
		}

		private string method_6()
		{
			string a;
			if ((a = IO2.string_9) != null)
			{
				if (a == "S")
				{
					return ";";
				}
				if (a == "C")
				{
					return ",";
				}
				if (a == "B")
				{
					return " ";
				}
				if (a == "T")
				{
					return "\t";
				}
			}
			throw new ArgumentException("Invalid delimiter.");
		}

		private string method_7(int int_2)
		{
			if (int_2 < 0)
			{
				return "";
			}
			return "0.".PadRight(int_2 + 2, '0');
		}

		[CommandMethod("TCPlugin", "ng:3DFOUT", 0)]
		public void OUT3DF()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] array = null;
			try
			{
				////LicenseManager.CheckValid("FULL");
				IO2.string_6 = CommandLineQuerries.SpecifyEntitiesBySelectionOrByLayer(IO2.string_6);
				if (IO2.string_6 == "S")
				{
					array = CommandLineQuerries.SelectFaces(true);
				}
				else if (IO2.string_6 == "L")
				{
					IO2.string_7 = CommandLineQuerries.SpecifyLayerName(IO2.string_7);
					if (!DBManager.ExistsLayer(IO2.string_7))
					{
						throw new ArgumentException("Layer does not exist.");
					}
					array = DBManager.GetFacesOnLayer(IO2.string_7);
					if (array == null)
					{
						throw new ArgumentException("No faces selected.");
					}
					editor.WriteMessage(Environment.NewLine + array.Length + " faces selected.");
				}
				CommandLineQuerries.SpecifyFileNameForWrite(ref IO2.string_2, ref IO2.string_8, "3df");
				IO2.string_9 = CommandLineQuerries.SpecifyDelimiter(IO2.string_9);
				IO2.int_0 = CommandLineQuerries.SpecifyColumnWidth(IO2.int_0);
				IO2.int_1 = CommandLineQuerries.SpecifyDecimalDigits(IO2.int_1);
				this.method_3(array);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		public void WriteXYZ(ObjectId[] pointIDs)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(pointIDs.Length);
			progressMeter.Start("Writing XYZ");
			try
			{
				CoordinateTransformator2 coordinateTransformator = new CoordinateTransformator2(CoordinateSystem.Global(), Conversions.GetUCS());
				int num = 0;
				int num2 = 0;
				string a = this.method_6();
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					using (StreamWriter streamWriter = new StreamWriter(IO2.string_5))
					{
						streamWriter.WriteLine(string.Concat(new object[]
						{
							"C ",
							IO2.string_5,
							" generated ",
							DateTime.Now
						}));
						if (a == ",")
						{
							streamWriter.WriteLine("C Format: x, y, z,");
						}
						if (a == ";")
						{
							streamWriter.WriteLine("C Format: x; y; z;");
						}
						if (a == " ")
						{
							streamWriter.WriteLine("C Format: x  y  z");
						}
						for (int i = 0; i < pointIDs.Length; i++)
						{
                            DBPoint dBPoint = (DBPoint)transaction.GetObject(pointIDs[i], (OpenMode)0, true);
							ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(dBPoint.Position.X, dBPoint.Position.Y, dBPoint.Position.Z);
							coordinateTransformator.Transform(point);
							string text = this.method_5(point, ref num);
							streamWriter.WriteLine(text.TrimEnd(new char[0]));
							progressMeter.MeterProgress();
							messageFilter.CheckMessageFilter((long)i, 10000);
							num2++;
						}
						streamWriter.Flush();
					}
				}
				progressMeter.Stop();
				if (num > 0)
				{
					editor.WriteMessage(string.Concat(new object[]
					{
						Environment.NewLine,
						num,
						" conversion errors occurred writing ",
						IO2.string_5,
						". Increase the column width and/or decrease the number of decimal digits."
					}));
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog(string.Concat(new object[]
					{
						num,
						" conversion errors occurred writing ",
						IO2.string_5,
						".\nIncrease the column width and/or decrease the number of decimal digits."
					}));
				}
				FileInfo fileInfo = new FileInfo(IO2.string_5);
				editor.WriteMessage(Environment.NewLine + "Output file name            : " + fileInfo.FullName);
				editor.WriteMessage(Environment.NewLine + "Number of points written    : " + num2.ToString());
				editor.WriteMessage(Environment.NewLine + "Coordinate conversion errors: " + num.ToString());
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		[CommandMethod("TCPlugin", "ng:XMLIN", 0)]
		public void XMLIN()
		{
			try
			{
				////LicenseManager.CheckValid("FULL");
				CommandLineQuerries.SpecifyFileNameForRead(ref IO2.string_1, "xml");
				this.method_0();
			}
            catch (System.Exception ex)
			{
                Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		[CommandMethod("TCPlugin", "ng:XMLOUT", 0)]
		public void XMLOUT()
		{
			try
			{
				////LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.smethod_4(true);
				CommandLineQuerries.SpecifyFileNameForWrite(ref IO2.string_0, ref IO2.string_8, "xml");
				this.method_1(objectId_);
			}
            catch (System.Exception ex)
			{
                Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		[CommandMethod("TCPlugin", "NG:XYZIN", 0)]
		public void XYZIN()
		{
			try
			{
				////LicenseManager.CheckValid("FULL");
				CommandLineQuerries.SpecifyFileNameForRead(ref IO2.string_4, "xyz");
				this.method_4();
			}
            catch (System.Exception ex)
			{
                Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		[CommandMethod("TCPlugin", "ng:XYZOUT", 0)]
		public void XYZOUT()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] array = null;
			try
			{
				////LicenseManager.CheckValid("FULL");
				IO2.string_6 = CommandLineQuerries.SpecifyEntitiesBySelectionOrByLayer(IO2.string_6);
				if (IO2.string_6 == "S")
				{
					array = CommandLineQuerries.SelectPoints(true);
				}
				else if (IO2.string_6 == "L")
				{
					IO2.string_7 = CommandLineQuerries.SpecifyLayerName(IO2.string_7);
					if (!DBManager.ExistsLayer(IO2.string_7))
					{
						throw new ArgumentException("Layer does not exist.");
					}
					array = DBManager.GetPointsOnLayer(IO2.string_7);
					if (array == null)
					{
						throw new ArgumentException("No points selected.");
					}
					editor.WriteMessage(Environment.NewLine + array.Length + " points selected.");
				}
				CommandLineQuerries.SpecifyFileNameForWrite(ref IO2.string_5, ref IO2.string_8, "xyz");
				IO2.string_9 = CommandLineQuerries.SpecifyDelimiter(IO2.string_9);
				IO2.int_0 = CommandLineQuerries.SpecifyColumnWidth(IO2.int_0);
				IO2.int_1 = CommandLineQuerries.SpecifyDecimalDigits(IO2.int_1);
				this.WriteXYZ(array);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		private static int int_0;

		private static int int_1;

		private static string string_0;

		private static string string_1;

		private static string string_2;

		private static string string_3;

		private static string string_4;

		private static string string_5;

		private static string string_6;

		private static string string_7;

		private static string string_8;

		private static string string_9;
	}
}
