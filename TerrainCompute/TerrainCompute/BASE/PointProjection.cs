using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.BASE
{
	
	public class PointProjection
	{
		static PointProjection()
		{
			PointProjection.string_0 = "S";
			PointProjection.string_1 = DBManager.CurrentLayerName();
			PointProjection.string_2 = "N";
			PointProjection.string_3 = "F";
			PointProjection.string_4 = "Z";
			PointProjection.string_5 = "H";
		}

		public PointProjection()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(PointProjection));
			//base..ctor();
		}

		internal void method_0(ObjectId[] objectId_0, ObjectId[] objectId_1, CoordinateSystem coordinateSystem_0)
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			int num = 0;
			int num2 = 0;
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					progressMeter.SetLimit(objectId_0.Length + objectId_1.Length);
					if ((double)objectId_0.Length > 10000.0 || (double)objectId_1.Length > 10000.0)
					{
						progressMeter.Start("Interpolating...");
					}
					DBManager.SetEpsilon();
					CoordinateTransformator coordinateTransformator = new CoordinateTransformator(CoordinateSystem.Global(), coordinateSystem_0);
					CoordinateTransformator inverseTransformation = coordinateTransformator.GetInverseTransformation();
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					ObjectId layerId = DBManager.CurrentLayerId();
					List<IdPoint> list = new List<IdPoint>();
					for (int i = 0; i < objectId_0.Length; i++)
					{
                        DBPoint dbPoint = (DBPoint)transaction.GetObject(objectId_0[i], (OpenMode)1, true);
						IdPoint idPoint = new IdPoint(dbPoint);
						idPoint.IsValid = false;
						coordinateTransformator.Transform(idPoint.Point);
						idPoint.Point.Z = double.NaN;
						list.Add(idPoint);
						progressMeter.MeterProgress();
					}
					list.Sort();
					List<Triangle> list2 = Conversions.ToCeometricAcDbTriangleList(objectId_1);
					for (int j = 0; j < list2.Count; j++)
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)j, 1000);
						Triangle triangle = list2[j];
						coordinateTransformator.Transform(triangle);
						double minimumX = triangle.MinimumX;
						double maximumX = triangle.MaximumX;
						double minimumY = triangle.MinimumY;
						double maximumY = triangle.MaximumY;
						int num3 = Math.Abs(list.BinarySearch(new IdPoint(new Point(minimumX, 0.0, 0.0), null)));
						int num4 = Math.Abs(list.BinarySearch(new IdPoint(new Point(maximumX, 0.0, 0.0), null)));
						num3 = Math.Max(num3 - 1, 0);
						num4 = Math.Min(num4 + 1, list.Count - 1);
						for (int k = num4; k >= num3; k--)
						{
							Point point = list[k].Point;
							if (point.X <= maximumX && point.X >= minimumX && point.Y <= maximumY && point.Y >= minimumY)
							{
								double num5 = Predicate.InTriangle2dExact(triangle.Vertex1, triangle.Vertex2, triangle.Vertex3, point);
								num5 = Predicate.Orientatation2dExact(triangle) * num5;
								if (num5 >= 0.0)
								{
									double num6 = PointProjection.smethod_0(triangle, point);
									if (double.IsNaN(num6))
									{
										num++;
									}
									else
									{
										double x = point.X;
										double y = point.Y;
										if (point.Z != double.NaN)
										{
											if (PointProjection.string_5 == "H")
											{
												if (num6 < point.Z)
												{
													goto IL_3FC;
												}
											}
											else if (num6 > point.Z)
											{
												goto IL_3FC;
											}
										}
										point.Z = num6;
										inverseTransformation.Transform(ref x, ref y, ref num6);
										DBPoint dBPoint = new DBPoint(new Point3d(x, y, num6));
										if (PointProjection.string_3 == "C")
										{
											dBPoint.LayerId=(layerId);
										}
										else if (PointProjection.string_3 == "F")
										{
											dBPoint.SetPropertiesFrom(triangle.AcDbFace);
										}
										else if (PointProjection.string_3 == "P")
										{
											dBPoint.SetPropertiesFrom(list[k].DBPoint);
										}
										list[k].IsValid = true;
										list[k].DBPoint2 = dBPoint;
										if (PointProjection.string_2 == "Y" & !list[k].DBPoint.IsErased)
										{
											list[k].DBPoint.Erase();
										}
									}
								}
							}
							IL_3FC:;
						}
					}
					for (int l = 0; l < list.Count; l++)
					{
						if (list[l].IsValid)
						{
							blockTableRecord.AppendEntity(list[l].DBPoint2);
							transaction.AddNewlyCreatedDBObject(list[l].DBPoint2, true);
							num2++;
						}
					}
					transaction.Commit();
					editor.WriteMessage("\nFailed interpolations : " + num);
					editor.WriteMessage("\nPoints outside surface: " + (objectId_0.Length - num2 - num).ToString());
					editor.WriteMessage("\nInterpolated points   : " + num2.ToString());
				}
				progressMeter.Stop();
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		[CommandMethod("TCPlugin", "ng:POINTS:PROJECT", 0)]
		public void ProjectPointsCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectFaces(true);
				PointProjection.string_0 = CommandLineQuerries.SpecifyRasterBySelectionOrByLayer(PointProjection.string_0);
				ObjectId[] array = null;
				if (PointProjection.string_0 == "S")
				{
					array = CommandLineQuerries.SelectPoints(true);
				}
				else if (PointProjection.string_0 == "L")
				{
					PointProjection.string_1 = CommandLineQuerries.SpecifyLayerName(PointProjection.string_1);
					if (!DBManager.ExistsLayer(PointProjection.string_1))
					{
						throw new ArgumentException("Layer does not exist.");
					}
					array = DBManager.GetPointsOnLayer(PointProjection.string_1);
					if (array == null)
					{
						throw new ArgumentException("No points selected.");
					}
					editor.WriteMessage(Environment.NewLine + array.Length + " points selected.");
				}
				PointProjection.string_4 = CommandLineQuerries.SpecifyProjectionDirection(PointProjection.string_4);
				ngeometry.VectorGeometry.Vector3d normalVector = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
				string a;
				if ((a = PointProjection.string_4.ToUpper()) != null)
				{
					if (!(a == "X"))
					{
						if (!(a == "Y"))
						{
							if (!(a == "Z"))
							{
								if (!(a == "U"))
								{
									if (!(a == "2P"))
									{
										goto IL_1E6;
									}
									normalVector = CommandLineQuerries.Specify2PDirection().BasisVector[2].Normalize();
								}
								else
								{
									normalVector = Conversions.GetUCS().BasisVector[2].Normalize();
								}
							}
							else
							{
								normalVector = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
							}
						}
						else
						{
							normalVector = new ngeometry.VectorGeometry.Vector3d(0.0, 1.0, 0.0);
						}
					}
					else
					{
						normalVector = new ngeometry.VectorGeometry.Vector3d(1.0, 0.0, 0.0);
					}
					Point point = new Point(0.0, 0.0, 0.0);
                    ngeometry.VectorGeometry.Plane plane = new ngeometry.VectorGeometry.Plane(point, normalVector);
					CoordinateSystem coordinateSystem_ = new CoordinateSystem(plane);
					PointProjection.string_3 = CommandLineQuerries.InsertOnLayer_Current_Face_Point(PointProjection.string_3);
					PointProjection.string_2 = CommandLineQuerries.KeywordYesNo("Delete original points", PointProjection.string_2, false, false);
					PointProjection.string_5 = CommandLineQuerries.KeepIfMultiple(PointProjection.string_5);
					this.method_0(array, objectId_, coordinateSystem_);
					return;
				}
				IL_1E6:
				throw new System.Exception("Invalid option keyword.");
			}
			catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message + "\n");
			}
		}

		internal static double smethod_0(Triangle triangle_0, Point point_0)
		{
			Point vertex = triangle_0.Vertex1;
			Point vertex2 = triangle_0.Vertex2;
			Point vertex3 = triangle_0.Vertex3;
			double num = vertex2.X - vertex.X;
			double num2 = vertex2.Y - vertex.Y;
			double num3 = vertex2.Z - vertex.Z;
			double num4 = vertex3.X - vertex.X;
			double num5 = vertex3.Y - vertex.Y;
			double num6 = vertex3.Z - vertex.Z;
			double num7 = point_0.X - vertex.X;
			double num8 = point_0.Y - vertex.Y;
			double num9 = num * num5 - num2 * num4;
			if (Math.Abs(num9) < 4.94065645841247E-324)
			{
				return double.NaN;
			}
			double num10 = num7 * (num3 * num5 - num2 * num6);
			double num11 = num8 * (num * num6 - num3 * num4);
			return (num10 + num11) / num9 + vertex.Z;
		}

		private static string string_0;

		private static string string_1;

		private static string string_2;

		private static string string_3;

		private static string string_4;

		private static string string_5;
	}
}
