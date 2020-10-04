using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.BASE
{
	//[LicenseProvider(typeof(Class46))]
	public class LineProjection
	{
		static LineProjection()
		{
			LineProjection.string_0 = "N";
			LineProjection.string_1 = "F";
			LineProjection.string_2 = "Z";
		}

		public LineProjection()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(LineProjection));
			//base..ctor();
		}

		private List<Edge> method_0(ObjectId[] objectId_0, ObjectId[] objectId_1, CoordinateSystem coordinateSystem_0, bool bool_0)
		{
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			IdEdgeList idEdgeList = new IdEdgeList();
			List<Edge> list = new List<Edge>();
			int num4 = DBManager.SetEpsilon();
			int num5 = (int)Convert.ToInt16(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("LUPREC").ToString());
			num4 = Math.Min(num5 + 2, num4);
			double num6 = Math.Max(Math.Pow(10.0, (double)(-(double)num4)), Global.AbsoluteEpsilon);
			CoordinateTransformator coordinateTransformator = new CoordinateTransformator(CoordinateSystem.Global(), coordinateSystem_0);
			CoordinateTransformator inverseTransformation = coordinateTransformator.GetInverseTransformation();
			List<Triangle> list2 = Conversions.ToCeometricAcDbTriangleList(objectId_1);
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)1);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],  (OpenMode)1);
				ObjectId layerId = DBManager.CurrentLayerId();
				DBManager.CurrentLayerName();
				List<IdEdge> list3 = new List<IdEdge>();
				double num7 = -1.7976931348623157E+308;
				for (int i = 0; i < objectId_0.Length; i++)
				{
					Autodesk.AutoCAD.DatabaseServices.Line line = (Autodesk.AutoCAD.DatabaseServices.Line)transaction.GetObject(objectId_0[i],  (OpenMode)1, true);
					IdEdge idEdge = new IdEdge(line);
					if (LineProjection.string_0 == "Y" & !idEdge.Line.IsErased)
					{
						idEdge.Line.Erase();
					}
					coordinateTransformator.Transform(idEdge.Edge);
					double num8 = idEdge.Edge.StartPoint.X - idEdge.Edge.EndPoint.X;
					double num9 = idEdge.Edge.StartPoint.Y - idEdge.Edge.EndPoint.Y;
					double num10 = Math.Sqrt(num8 * num8 + num9 * num9);
					if (Math.Abs(num8) > num7)
					{
						num7 = Math.Abs(num8);
					}
					if (num10 < Global.AbsoluteEpsilon)
					{
						num2++;
					}
					else
					{
						idEdge.SetMinMaxXY();
						list3.Add(idEdge);
					}
				}
				list3.Sort(new CompareMin());
				progressMeter.SetLimit(objectId_1.Length);
				if ((double)objectId_1.Length > 10000.0)
				{
					progressMeter.Start("Projecting lines...");
				}
				try
				{
					for (int j = 0; j < list2.Count; j++)
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)j, 1000);
						Triangle triangle = list2[j];
						coordinateTransformator.Transform(triangle);
						if (Math.Abs(triangle.NormalVector.Z) < Global.AbsoluteEpsilon)
						{
							num++;
						}
						else
						{
							double minimumX = triangle.MinimumX;
							double maximumX = triangle.MaximumX;
							double minimumY = triangle.MinimumY;
							double maximumY = triangle.MaximumY;
							IdEdge item = new IdEdge(new Edge(new Point(maximumX, minimumY, 0.0), new Point(maximumX + 1.0, minimumY, 0.0)));
							int num11 = list3.BinarySearch(item, new CompareMin());
							if (num11 < 0)
							{
								num11 = ~num11;
							}
							IdEdge item2 = new IdEdge(new Edge(new Point(minimumX - num7, maximumY, 0.0), new Point(minimumX - num7 + 1.0, maximumY, 0.0)));
							int num12 = list3.BinarySearch(item2, new CompareMin());
							if (num12 < 0)
							{
								num12 = ~num12;
							}
							try
							{
								for (int k = num12; k < num11; k++)
								{
									IdEdge idEdge2 = list3[k];
									if (idEdge2.MinX <= maximumX && idEdge2.MinY <= maximumY && idEdge2.MaxX >= minimumX && idEdge2.MaxY >= minimumY)
									{
										Edge edge = idEdge2.Edge;
										double num13 = Predicate.InTriangle2dArbitraryExact(triangle.Vertex1, triangle.Vertex2, triangle.Vertex3, edge.StartPoint);
										double num14 = Predicate.InTriangle2dArbitraryExact(triangle.Vertex1, triangle.Vertex2, triangle.Vertex3, edge.EndPoint);
										Edge edge2 = new Edge();
										if (!double.IsNaN(num14) && !double.IsNaN(num13))
										{
											if (num14 == 1.0 && num13 == 1.0)
											{
												edge2 = edge;
											}
											else if (num13 == 1.0 && num14 == 0.0)
											{
												edge2 = edge;
											}
											else if (num13 == 0.0 && num14 == 1.0)
											{
												edge2 = edge;
											}
											else if (num13 == 0.0 && num14 == 0.0)
											{
												edge2 = edge;
											}
											else if (num13 == -1.0 && num14 == 1.0)
											{
												edge2 = this.method_1(edge, triangle, edge.EndPoint);
											}
											else if (num13 == 1.0 && num14 == -1.0)
											{
												edge2 = this.method_1(edge, triangle, edge.StartPoint);
											}
											else if (num13 == 0.0 && num14 == -1.0)
											{
												edge2 = this.method_2(edge, triangle, edge.StartPoint);
											}
											else if (num13 == -1.0 && num14 == 0.0)
											{
												edge2 = this.method_2(edge, triangle, edge.EndPoint);
											}
											else if (num13 == -1.0 && num14 == -1.0)
											{
												edge2 = this.method_3(edge, triangle);
											}
											if (!(edge2 == null))
											{
												Edge edge3 = edge2.DeepCopy();
												edge3.StartPoint.Z = PointProjection.smethod_0(triangle, edge3.StartPoint);
												edge3.EndPoint.Z = PointProjection.smethod_0(triangle, edge3.EndPoint);
												if (edge3.Length >= num6)
												{
													Edge edge4 = edge3.DeepCopy();
													edge4.SwapSort();
													edge4.StartPoint.X = (double)((float)edge4.StartPoint.X);
													edge4.StartPoint.Y = (double)((float)edge4.StartPoint.Y);
													edge4.StartPoint.Z = (double)((float)edge4.StartPoint.Z);
													edge4.EndPoint.X = (double)((float)edge4.EndPoint.X);
													edge4.EndPoint.Y = (double)((float)edge4.EndPoint.Y);
													edge4.EndPoint.Z = (double)((float)edge4.EndPoint.Z);
													if (!idEdgeList.ContainsKey(edge4))
													{
														idEdgeList.Add(edge4, null);
														inverseTransformation.Transform(edge3);
														list.Add(edge3);
														if (bool_0)
														{
															Point3d point3d=new Point3d(edge3.StartPoint.X, edge3.StartPoint.Y, edge3.StartPoint.Z);
															//point3d..ctor(edge3.StartPoint.X, edge3.StartPoint.Y, edge3.StartPoint.Z);
															Point3d point3d2=new Point3d(edge3.EndPoint.X, edge3.EndPoint.Y, edge3.EndPoint.Z);
															//point3d2..ctor(edge3.EndPoint.X, edge3.EndPoint.Y, edge3.EndPoint.Z);
															Autodesk.AutoCAD.DatabaseServices.Line line2 = new Autodesk.AutoCAD.DatabaseServices.Line(point3d, point3d2);
															if (LineProjection.string_1 == "C")
															{
																LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(triangle.AcDbFace.LayerId, (OpenMode)0);
																Color color = triangle.AcDbFace.Color;
																if (color.IsByLayer)
																{
																	color = layerTableRecord.Color;
																}
																line2.SetPropertiesFrom(triangle.AcDbFace);
																line2.LayerId=(layerId);
																line2.Color=(color);
															}
															else if (LineProjection.string_1 == "F")
															{
																line2.SetPropertiesFrom(triangle.AcDbFace);
															}
															else if (LineProjection.string_1 == "L")
															{
																line2.SetPropertiesFrom(idEdge2.Line);
															}
															blockTableRecord.AppendEntity(line2);
															transaction.AddNewlyCreatedDBObject(line2, true);
														}
													}
												}
											}
										}
									}
								}
							}
                            catch (System.Exception ex)
							{
								editor.WriteMessage("\n" + ex.Message);
								num3++;
							}
						}
					}
				}
                catch (System.Exception ex)
				{
					progressMeter.Stop();
					throw;
				}
				transaction.Commit();
			}
			progressMeter.Stop();
			if (bool_0)
			{
				editor.WriteMessage("\nNumber of lines projected             : " + idEdgeList.Count);
				editor.WriteMessage("\nNumber of failed faces                : " + num3);
				editor.WriteMessage("\nFaces parallel to projection direction: " + num);
				editor.WriteMessage("\nLines parallel to projection direction: " + num2);
			}
			return list;
		}

		private Edge method_1(Edge edge_0, Triangle triangle_0, Point point_0)
		{
			List<Edge> edges = triangle_0.Edges;
			int i = 0;
			while (i < 3)
			{
				double num = Predicate.IntersectsExact(edge_0, edges[i]);
				if (num == 1.0)
				{
					Edge result;
					try
					{
						Point point = this.method_4(edge_0, edges[i]);
						if (point != null)
						{
							result = new Edge(point_0, point);
						}
						else
						{
							result = this.method_5(edge_0, edges[i]);
						}
					}
                    catch (System.Exception ex)
					{
						throw new ArithmeticException("Error in case A0: " + ex.Message);
					}
					return result;
				}
				if (num == 0.0)
				{
					if (Predicate.Orient2d_exact(edge_0.StartPoint, edge_0.EndPoint, edges[i].StartPoint) == 0.0)
					{
						return new Edge(point_0, edges[i].StartPoint);
					}
					if (Predicate.Orient2d_exact(edge_0.StartPoint, edge_0.EndPoint, edges[i].EndPoint) == 0.0)
					{
						return new Edge(point_0, edges[i].EndPoint);
					}
					throw new ArithmeticException("Exact arithmetic error in case A1.");
				}
				else
				{
					i++;
				}
			}
			throw new NotImplementedException("Unhandled intersection case in case A.");
		}

		private Edge method_2(Edge edge_0, Triangle triangle_0, Point point_0)
		{
			List<Edge> edges = triangle_0.Edges;
			List<Edge> list = new List<Edge>();
			List<Edge> list2 = new List<Edge>();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < 3; i++)
			{
				double num6 = Predicate.IntersectsExact(edge_0, edges[i]);
				if (num6 == -1.0)
				{
					num3++;
				}
				else if (num6 == 1.0)
				{
					list.Add(edges[i]);
				}
				else if (num6 == 0.0)
				{
					num4++;
				}
				else if (num6 == 2.0)
				{
					num5++;
				}
				else
				{
					if (!double.IsNaN(num6))
					{
						throw new NotImplementedException("Unexpected predicate return value in case B:  " + num6.ToString());
					}
					list2.Add(edges[i]);
				}
				num = list.Count;
				num2 = list2.Count;
			}
			bool flag = false;
			if (num3 == 1 && num4 == 1 && num == 1)
			{
				flag = true;
			}
			else if (num3 == 2 && num4 == 1)
			{
				flag = true;
			}
			else if (num3 == 1 && num5 == 2)
			{
				flag = true;
			}
			else if (num == 1 && num5 == 2)
			{
				flag = true;
			}
			else if (num2 == 1 && num3 == 1 && num5 == 1)
			{
				flag = true;
			}
			else if (num2 == 1 && num3 == 1 && num4 == 1)
			{
				flag = true;
			}
			else if (num2 == 1 && num4 == 1 && num5 == 1)
			{
				flag = true;
			}
			else if (num4 == 3)
			{
				flag = true;
			}
			if (!flag)
			{
				throw new NotImplementedException(string.Concat(new string[]
				{
					"Unexpected combination in case B:\nPredicate  -1: ",
					num3.ToString(),
					"\nPredicate   0: ",
					num4.ToString(),
					"\nPredicate   1: ",
					num.ToString(),
					"\nPredicate   2: ",
					num5.ToString(),
					"\nPredicate NaN: ",
					num2.ToString(),
					"\nAt triangle:\n",
					triangle_0.ToString()
				}));
			}
			if (list.Count == 1)
			{
				Edge result;
				try
				{
					Point point = this.method_4(edge_0, list[0]);
					if (point == null)
					{
						result = this.method_5(edge_0, list[0]);
					}
					else
					{
						result = new Edge(point_0, point);
					}
				}
				catch (System.Exception ex)
				{
					throw new ArithmeticException("Error in case B0: " + ex.Message);
				}
				return result;
			}
			if (list2.Count == 1 && num4 == 1)
			{
				return this.method_5(edge_0, list2[0]);
			}
			if (num4 == 3)
			{
				PointSet vertices = triangle_0.Vertices;
				for (int j = 0; j < 3; j++)
				{
					if (Predicate.Orient2d_exact(edge_0.StartPoint, edge_0.EndPoint, vertices[j]) == 0.0)
					{
						return new Edge(point_0, vertices[j]);
					}
				}
				throw new ArithmeticException("Exact arithmetic error in case B2");
			}
			return null;
		}

		private Edge method_3(Edge edge_0, Triangle triangle_0)
		{
			List<Edge> edges = triangle_0.Edges;
			List<Edge> list = new List<Edge>();
			List<Edge> list2 = new List<Edge>();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < 3; i++)
			{
				double num6 = Predicate.IntersectsExact(edge_0, edges[i]);
				if (num6 == -1.0)
				{
					num3++;
				}
				else if (num6 == 1.0)
				{
					list.Add(edges[i]);
				}
				else if (num6 == 0.0)
				{
					num4++;
				}
				else if (num6 == 2.0)
				{
					num5++;
				}
				else
				{
					if (!double.IsNaN(num6))
					{
						throw new NotImplementedException("Unexpected predicate return value in case C:  " + num6.ToString());
					}
					list2.Add(edges[i]);
				}
				num = list.Count;
				num2 = list2.Count;
			}
			bool flag = false;
			if (num3 == 1 && num == 2)
			{
				flag = true;
			}
			else if (num == 1 && num4 == 2)
			{
				flag = true;
			}
			else if (num3 == 1 && num4 == 2)
			{
				flag = true;
			}
			else if (num2 == 1 && num3 == 2)
			{
				flag = true;
			}
			else if (num2 == 1 && num4 == 2)
			{
				flag = true;
			}
			else if (num3 == 3)
			{
				flag = true;
			}
			if (!flag)
			{
				throw new NotImplementedException(string.Concat(new string[]
				{
					"Unexpected combination in case C:\nPredicate  -1: ",
					num3.ToString(),
					"\nPredicate   0: ",
					num4.ToString(),
					"\nPredicate   1: ",
					num.ToString(),
					"\nPredicate   2: ",
					num5.ToString(),
					"\nPredicate NaN: ",
					num2.ToString(),
					"\nAt triangle:\n",
					triangle_0.ToString()
				}));
			}
			if (list.Count == 2)
			{
				try
				{
					Point point = this.method_4(edge_0, list[0]);
					Edge result;
					if (point == null)
					{
						result = this.method_5(edge_0, list[0]);
						return result;
					}
					Point point2 = this.method_4(edge_0, list[1]);
					if (point2 == null)
					{
						result = this.method_5(edge_0, list[1]);
						return result;
					}
					result = new Edge(point, point2);
					return result;
				}
                catch (System.Exception ex)
				{
					throw new ArithmeticException("Error in case C0: " + ex.Message);
				}
			}
			if (num2 == 1 && num4 == 2)
			{
				return list2[0];
			}
			if (list.Count == 1)
			{
				Point point3;
				try
				{
					point3 = this.method_4(edge_0, list[0]);
					if (point3 == null)
					{
						Edge result = this.method_5(edge_0, list[0]);
						return result;
					}
				}
                catch (System.Exception ex)
				{
					throw new ArithmeticException("Degenerate edge in case C2");
				}
				PointSet vertices = triangle_0.Vertices;
				for (int j = 0; j < 3; j++)
				{
					if (Predicate.Orient2d_exact(edge_0.StartPoint, edge_0.EndPoint, vertices[j]) == 0.0)
					{
						return new Edge(point3, vertices[j]);
					}
				}
				throw new ArithmeticException("Exact arithmetic error in case C2");
			}
			return null;
		}

		private Point method_4(Edge edge_0, Edge edge_1)
		{
            ngeometry.VectorGeometry.Line line = edge_0.ToLine();
            ngeometry.VectorGeometry.Line line2 = edge_1.ToLine();
            ngeometry.VectorGeometry.Line line3 = line.Invert();
            ngeometry.VectorGeometry.Line l = line2.Invert();
			Point left = line.IntersectXY(line2);
			Point point = line.IntersectXY(l);
			Point point2 = line3.IntersectXY(line2);
			Point point3 = line3.IntersectXY(l);
			if (!(left == null) && !(point == null) && !(point2 == null) && !(point3 == null))
			{
				return 0.25 * (left + point + point2 + point3);
			}
			return null;
		}

		private Edge method_5(Edge edge_0, Edge edge_1)
		{
			List<Point> list = new List<Point>();
			double num = this.method_6(edge_0, edge_1.StartPoint);
			if (num >= 0.0)
			{
				list.Add(edge_1.StartPoint);
			}
			double num2 = this.method_6(edge_0, edge_1.EndPoint);
			if (num2 >= 0.0)
			{
				list.Add(edge_1.EndPoint);
			}
			if (list.Count == 2)
			{
				return new Edge(list[0], list[1]);
			}
			double num3 = this.method_6(edge_1, edge_0.StartPoint);
			if (num3 >= 0.0)
			{
				list.Add(edge_0.StartPoint);
			}
			if (list.Count == 2)
			{
				return new Edge(list[0], list[1]);
			}
			double num4 = this.method_6(edge_1, edge_0.EndPoint);
			if (num4 >= 0.0)
			{
				list.Add(edge_0.EndPoint);
			}
			if (list.Count == 2)
			{
				return new Edge(list[0], list[1]);
			}
			if (list.Count != 0)
			{
				throw new ArithmeticException("Failed to compute overlap.");
			}
			return null;
		}

		private double method_6(Edge edge_0, Point point_0)
		{
			Point startPoint = edge_0.StartPoint;
			Point endPoint = edge_0.EndPoint;
			double num = endPoint.X - startPoint.X;
			double num2 = endPoint.Y - startPoint.Y;
			Point pb = new Point(startPoint.X + num2, startPoint.Y - num, 0.0);
			Point pb2 = new Point(endPoint.X - num2, endPoint.Y + num, 0.0);
			double num3 = (double)Math.Sign(Predicate.Orient2d_exact(startPoint, pb, point_0));
			double num4 = (double)Math.Sign(Predicate.Orient2d_exact(endPoint, pb2, point_0));
			if (num3 == -1.0 && num4 == 1.0)
			{
				return -1.0;
			}
			if (num3 == 1.0 && num4 == -1.0)
			{
				return -1.0;
			}
			if (num3 == 1.0 && num4 == 1.0)
			{
				return 1.0;
			}
			if (num3 == 0.0 && num4 == 1.0)
			{
				return 0.0;
			}
			if (num3 == 1.0 && num4 == 0.0)
			{
				return 0.0;
			}
			if (num3 == 0.0 && num4 == 0.0)
			{
				return double.NaN;
			}
			throw new ArithmeticException("EA error at inside predicate.");
		}

		[CommandMethod("TCPlugin", "ng:LINES:PROJECT", 0)]
		public void ProjectLinesCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectFaces(false);
				ObjectId[] objectId_2 = CommandLineQuerries.SelectLines(false);
				LineProjection.string_2 = CommandLineQuerries.SpecifyProjectionDirection(LineProjection.string_2);
				//new Vector3d(0.0, 0.0, 1.0);
                ngeometry.VectorGeometry.Vector3d directionVector = new ngeometry.VectorGeometry.Vector3d(1.0, 0.0, 0.0);
                ngeometry.VectorGeometry.Vector3d directionVector2 = new ngeometry.VectorGeometry.Vector3d(0.0, 1.0, 0.0);
				string a;
				if ((a = LineProjection.string_2.ToUpper()) != null)
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
										goto IL_267;
									}
									CommandLineQuerries.Specify2PDirection().BasisVector[2].Normalize();
								}
								else
								{
									Conversions.GetUCS().BasisVector[2].Normalize();
								}
							}
							else
							{
                                directionVector = new ngeometry.VectorGeometry.Vector3d(1.0, 0.0, 0.0);
                                directionVector2 = new ngeometry.VectorGeometry.Vector3d(0.0, 1.0, 0.0);
								//new Vector3d(0.0, 0.0, 1.0);
							}
						}
						else
						{
                            directionVector = new ngeometry.VectorGeometry.Vector3d(1.0, 0.0, 0.0);
                            directionVector2 = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
							//new Vector3d(0.0, 1.0, 0.0);
						}
					}
					else
					{
                        directionVector = new ngeometry.VectorGeometry.Vector3d(0.0, 1.0, 0.0);
                        directionVector2 = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
						//new Vector3d(0.0, 0.0, 1.0);
					}
                    ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(0.0, 0.0, 0.0);
                    ngeometry.VectorGeometry.Plane plane = new ngeometry.VectorGeometry.Plane(point, directionVector, directionVector2);
					CoordinateSystem coordinateSystem_ = new CoordinateSystem(plane);
					LineProjection.string_1 = CommandLineQuerries.InsertOnLayer_Current_Face_Line(LineProjection.string_1);
					LineProjection.string_0 = CommandLineQuerries.KeywordYesNo("Delete original lines", LineProjection.string_0, false, false);
					this.method_0(objectId_2, objectId_, coordinateSystem_, true);
					return;
				}
				IL_267:
                throw new System.Exception("Invalid option keyword.");
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message + "\n");
			}
		}

		private static string string_0;

		private static string string_1;

		private static string string_2;
	}
}
