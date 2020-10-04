using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.BASE
{
	//[LicenseProvider(typeof(Class46))]
	public class EntitySlicer
	{
		static EntitySlicer()
		{
			EntitySlicer.string_0 = "Y";
		}

		public EntitySlicer()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(EntitySlicer));
			////base..ctor();
		}

		private void method_0(ObjectId[] objectId_0,ngeometry.VectorGeometry.Plane plane_0, int int_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor arg_15_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			progressMeter.SetLimit(objectId_0.Length);
			progressMeter.Start("Slicing");
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				try
				{
					BlockTable arg_5A_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)0);
					for (int i = 0; i < objectId_0.Length; i++)
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)i, 1000);
						Autodesk.AutoCAD.DatabaseServices.Line line = (Autodesk.AutoCAD.DatabaseServices.Line)transaction.GetObject(objectId_0[i],  (OpenMode)0, true);
						Edge edge = Conversions.ToCeometricEdge(line);
						double value = edge.StartPoint.DistanceTo(plane_0);
						double value2 = edge.EndPoint.DistanceTo(plane_0);
						if (Math.Abs(value) < Global.AbsoluteEpsilon)
						{
							value = 0.0;
						}
						if (Math.Abs(value2) < Global.AbsoluteEpsilon)
						{
							value2 = 0.0;
						}
						int num = Math.Sign(value);
						int num2 = Math.Sign(value2);
						if (num == num2)
						{
							if (num != int_0 && int_0 != 0)
							{
								line.UpgradeOpen();
								if (!line.IsErased)
								{
									line.Erase();
								}
							}
						}
						else
						{
							Point point = plane_0.method_0(edge.ToLine());
							if (!(point == null))
							{
								line.UpgradeOpen();
								BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(line.BlockId, (OpenMode)1);
								Point3d point3d=new Point3d(edge.StartPoint.X, edge.StartPoint.Y, edge.StartPoint.Z);
								Point3d point3d2=new Point3d(point.X, point.Y, point.Z);
								Point3d point3d3=new Point3d(edge.EndPoint.X, edge.EndPoint.Y, edge.EndPoint.Z);
								if (int_0 == 0)
								{
									if (point3d != point3d2)
									{
										Autodesk.AutoCAD.DatabaseServices.Line line2 = new Autodesk.AutoCAD.DatabaseServices.Line(point3d, point3d2);
										line2.SetPropertiesFrom(line);
										blockTableRecord.AppendEntity(line2);
										transaction.AddNewlyCreatedDBObject(line2, true);
									}
									if (point3d2 != point3d3)
									{
										Autodesk.AutoCAD.DatabaseServices.Line line3 = new Autodesk.AutoCAD.DatabaseServices.Line(point3d2, point3d3);
										line3.SetPropertiesFrom(line);
										blockTableRecord.AppendEntity(line3);
										transaction.AddNewlyCreatedDBObject(line3, true);
									}
								}
								else if (Math.Sign(num) == int_0)
								{
									Autodesk.AutoCAD.DatabaseServices.Line line4 = new Autodesk.AutoCAD.DatabaseServices.Line(point3d, point3d2);
									line4.SetPropertiesFrom(line);
									blockTableRecord.AppendEntity(line4);
									transaction.AddNewlyCreatedDBObject(line4, true);
								}
								else if (Math.Sign(num2) == int_0)
								{
									Autodesk.AutoCAD.DatabaseServices.Line line5 = new Autodesk.AutoCAD.DatabaseServices.Line(point3d2, point3d3);
									line5.SetPropertiesFrom(line);
									blockTableRecord.AppendEntity(line5);
									transaction.AddNewlyCreatedDBObject(line5, true);
								}
								if (!line.IsErased)
								{
									line.Erase();
								}
							}
						}
					}
					transaction.Commit();
					progressMeter.Stop();
				}
				catch (System.Exception ex)
				{
					progressMeter.Stop();
					throw ex;
				}
			}
		}

		private void method_1(ObjectId[] objectId_0,ngeometry.VectorGeometry.Plane plane_0, int int_0, bool bool_0, ref int int_1, ref int int_2, ref int int_3)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor arg_15_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			DBManager.SetEpsilon();
			List<ObjectId> list = new List<ObjectId>();
			for (int i = 0; i < objectId_0.Length; i++)
			{
				list.Add(objectId_0[i]);
			}
			progressMeter.SetLimit(list.Count);
			progressMeter.Start("Slicing");
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable arg_90_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)0);
				for (int j = 0; j < list.Count; j++)
				{
					try
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)j, 1000);
					}
                    catch (System.Exception ex)
					{
						progressMeter.Stop();
						throw;
					}
					Face face = (Face)transaction.GetObject(list[j],  (OpenMode)0, true);
					try
					{
						Point3d vertexAt = face.GetVertexAt(0);
						Point3d vertexAt2 = face.GetVertexAt(1);
						Point3d vertexAt3 = face.GetVertexAt(2);
						Point3d vertexAt4 = face.GetVertexAt(3);
						Point point = new Point(vertexAt.X, vertexAt.Y, vertexAt.Z);
						Point point2 = new Point(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
						Point point3 = new Point(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
						Point point4 = new Point(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
						double value = point.DistanceTo(plane_0);
						double value2 = point2.DistanceTo(plane_0);
						double value3 = point3.DistanceTo(plane_0);
						double value4 = point4.DistanceTo(plane_0);
						if (Math.Abs(value) < Global.AbsoluteEpsilon)
						{
							value = 0.0;
						}
						if (Math.Abs(value2) < Global.AbsoluteEpsilon)
						{
							value2 = 0.0;
						}
						if (Math.Abs(value3) < Global.AbsoluteEpsilon)
						{
							value3 = 0.0;
						}
						if (Math.Abs(value4) < Global.AbsoluteEpsilon)
						{
							value4 = 0.0;
						}
						int num = Math.Sign(value);
						int num2 = Math.Sign(value2);
						int num3 = Math.Sign(value3);
						int num4 = Math.Sign(value4);
						if (num == num2 && num2 == num3 && num3 == num4)
						{
							if (num == 0 && bool_0)
							{
								int_3++;
							}
							else if (num != int_0 && int_0 != 0)
							{
								face.UpgradeOpen();
								if (!face.IsErased)
								{
									face.Erase();
								}
							}
							else
							{
								int_3++;
							}
						}
						else if (point != point2 && point != point3 && point != point4 && point2 != point3 && point2 != point4 && point3 != point4)
						{
							BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(face.BlockId, (OpenMode)1);
							face.UpgradeOpen();
							Face face2 = new Face(vertexAt, vertexAt2, vertexAt4, true, true, true, true);
							face2.SetPropertiesFrom(face);
							blockTableRecord.AppendEntity(face2);
							transaction.AddNewlyCreatedDBObject(face2, true);
							list.Add(face2.ObjectId);
							Face face3 = new Face(vertexAt2, vertexAt3, vertexAt4, true, true, true, true);
							face3.SetPropertiesFrom(face);
							blockTableRecord.AppendEntity(face3);
							transaction.AddNewlyCreatedDBObject(face3, true);
							list.Add(face3.ObjectId);
							if (!face.IsErased)
							{
								face.Erase();
							}
						}
						else
						{
							Triangle triangle = new Triangle();
							if (point != point2 && point != point3 && point2 != point3)
							{
								triangle = new Triangle(point, point2, point3);
							}
							else if (point != point2 && point != point4 && point2 != point4)
							{
								triangle = new Triangle(point, point2, point4);
							}
							else
							{
								if (!(point != point3) || !(point != point4) || !(point3 != point4))
								{
									throw new ArithmeticException("Failed to construct triangle from 3d face.");
								}
								triangle = new Triangle(point, point3, point4);
							}
							List<Triangle> list2 = new List<Triangle>();
							if (int_0 == 0)
							{
								list2 = triangle.Slice(plane_0, Triangle.SliceMethod.KeepBoth, bool_0);
							}
							else if (int_0 == 1)
							{
								list2 = triangle.Slice(plane_0, Triangle.SliceMethod.KeepAbove, bool_0);
							}
							else if (int_0 == -1)
							{
								list2 = triangle.Slice(plane_0, Triangle.SliceMethod.KeepBelow, bool_0);
							}
							BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(face.BlockId, (OpenMode)1);
							face.UpgradeOpen();
							for (int k = 0; k < list2.Count; k++)
							{
								Triangle triangle2 = list2[k];
								Point3d point3d=new Point3d(triangle2.Vertex1.X, triangle2.Vertex1.Y, triangle2.Vertex1.Z);
								Point3d point3d2=new Point3d(triangle2.Vertex2.X, triangle2.Vertex2.Y, triangle2.Vertex2.Z);
								Point3d point3d3=new Point3d(triangle2.Vertex3.X, triangle2.Vertex3.Y, triangle2.Vertex3.Z);
								Face face4 = new Face(point3d, point3d2, point3d3, true, true, true, true);
								face4.SetPropertiesFrom(face);
								blockTableRecord2.AppendEntity(face4);
								transaction.AddNewlyCreatedDBObject(face4, true);
								int_3++;
							}
							if (!face.IsErased)
							{
								face.Erase();
							}
							int_1++;
						}
					}
                    catch (System.Exception ex)
					{
						int_2++;
					}
					finally
					{
						face.Dispose();
					}
				}
				transaction.Commit();
			}
			progressMeter.Stop();
			Global.ResumeEpsilon();
		}

		[CommandMethod("TCPlugin", "ng:FACES:SLICE", 0)]
		public void SliceFacesCommand()
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectFaces(false);
				CoordinateSystem coordinateSystem = CommandLineQuerries.Specify3PSystem();
				ngeometry.VectorGeometry.Plane planeNormalized = coordinateSystem.GetPlaneNormalized();
				int num = 0;
				while (num == 0)
				{
					Point left = new Point();
					PromptPointResult promptPointResult = CommandLineQuerries.SpecifyPointOrKeepBothSides();
                    if (promptPointResult.Status == (PromptStatus)(-5005))
					{
						num = 0;
						IL_F3_:
						EntitySlicer.string_0 = CommandLineQuerries.KeywordYesNo("Keep coplanar faces", EntitySlicer.string_0, false, false);
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						bool bool_ = false;
						if (EntitySlicer.string_0.Trim().ToUpper() == "Y")
						{
							bool_ = true;
						}
						this.method_1(objectId_, planeNormalized, num, bool_, ref num2, ref num3, ref num4);
						editor.WriteMessage("\nFailed faces   : " + num3.ToString());
						editor.WriteMessage("\nFaces sliced   : " + num2.ToString());
						editor.WriteMessage("\nFaces remaining: " + num4.ToString());
						return;
					}
                    if (promptPointResult.Status == (PromptStatus)5100)
					{
						Point3d value = promptPointResult.Value;
						left = new Point(value.X, value.Y, value.Z);
						num = Math.Sign(ngeometry.VectorGeometry.Vector3d.Dot(planeNormalized.NormalVector, new ngeometry.VectorGeometry.Vector3d(left - planeNormalized.Point)));
						if (num == 0)
						{
							editor.WriteMessage("\nInvalid point: point is on slicing plane.");
						}
					}
                    else if (promptPointResult.Status == (PromptStatus)(-5002))
					{
						CommandLineQuerries.OnCancelled();
					}
                    else if (promptPointResult.Status != (PromptStatus)5100)
					{
						CommandLineQuerries.OnNotOK();
					}
				}
				goto IL_F3;
                IL_F3:
                {
                
                    EntitySlicer.string_0 = CommandLineQuerries.KeywordYesNo("Keep coplanar faces", EntitySlicer.string_0, false, false);
                    int num2 = 0;
                    int num3 = 0;
                    int num4 = 0;
                    bool bool_ = false;
                    if (EntitySlicer.string_0.Trim().ToUpper() == "Y")
                    {
                        bool_ = true;
                    }
                    this.method_1(objectId_, planeNormalized, num, bool_, ref num2, ref num3, ref num4);
                    editor.WriteMessage("\nFailed faces   : " + num3.ToString());
                    editor.WriteMessage("\nFaces sliced   : " + num2.ToString());
                    editor.WriteMessage("\nFaces remaining: " + num4.ToString());
                    return;
                }
			}
			catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message + "\n");
			}
		}

		[CommandMethod("TCPlugin", "ng:LINES:SLICE", 0)]
		public void SliceLineCommand()
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database arg_15_0 = HostApplicationServices.WorkingDatabase;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectLines(false);
				ngeometry.VectorGeometry.Plane planeNormalized = CommandLineQuerries.Specify3PSystem().GetPlaneNormalized();
				int num = 0;
				while (num == 0)
				{
					Point left = new Point();
					PromptPointResult promptPointResult = CommandLineQuerries.SpecifyPointOrKeepBothSides();
                    if (promptPointResult.Status == (PromptStatus) (- 5005))
					{
						num = 0;
						IL_F2_:
						this.method_0(objectId_, planeNormalized, num);
						return;
					}
                    if (promptPointResult.Status == (PromptStatus)5100)
					{
						Point3d value = promptPointResult.Value;
						left = new Point(value.X, value.Y, value.Z);
						num = Math.Sign(ngeometry.VectorGeometry.Vector3d.Dot(planeNormalized.NormalVector, new ngeometry.VectorGeometry.Vector3d(left - planeNormalized.Point)));
						if (num == 0)
						{
							editor.WriteMessage("\nInvalid point: point is on plane.");
						}
					}
                    else if (promptPointResult.Status == (PromptStatus) (- 5002))
					{
						CommandLineQuerries.OnCancelled();
					}
                    else if (promptPointResult.Status != (PromptStatus)5100)
					{
						CommandLineQuerries.OnNotOK();
					}
				}
                goto IL_F2;
            IL_F2:
                {
                
                    this.method_0(objectId_, planeNormalized, num);
                    return;
                }
			}
			catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		private static string string_0;
	}
}
