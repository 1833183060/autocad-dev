using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
using System.Collections.Generic;
namespace TerrainComputeC.BASE
{
	//[LicenseProvider(typeof(Class46))]
	public class PointGeneration
	{
		static PointGeneration()
		{
			PointGeneration.string_0 = "ALL";
			PointGeneration.double_0 = 0.0;
		}

		public PointGeneration()
		{
			
		}

		[CommandMethod("TCPlugin", "ng:POINTS:GENERATE", 0)]
		public void GeneratePoints()
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				
				PointSet pointSet = this.method_0();
				DBManager.WriteListInDatabase<Point>(pointSet.ToList(), null, DBManager.EntityPropertiesAssignment.ByDialog, ObjectId.Null, ObjectId.Null);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		internal PointSet method_0()
		{
			Editor arg_0F_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database arg_15_0 = HostApplicationServices.WorkingDatabase;
			PointGeneration.string_0 = CommandLineQuerries.SpecifyEntityType(PointGeneration.string_0);
			string key;
			if ((key = PointGeneration.string_0) != null)
			{
				if (PrivateImplementationDetails40B.method0x60001441 == null)
				{
					PrivateImplementationDetails40B.method0x60001441 = new Dictionary<string, int>(10)
					{
						{
							"A",
							0
						},
						{
							"ALL",
							1
						},
						{
							"C",
							2
						},
						{
							"E",
							3
						},
						{
							"F",
							4
						},
						{
							"L",
							5
						},
						{
							"P",
							6
						},
						{
							"S",
							7
						},
						{
							"T",
							8
						},
						{
							"SO",
							9
						}
					};
				}
				int num;
				if (PrivateImplementationDetails40B.method0x60001441.TryGetValue(key, out num))
				{
					ObjectId[] objectIDs;
					switch (num)
					{
					case 0:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.ARC);
						break;
					case 1:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.ArcLineTextCircleEllipseFaceSplinePline);
						break;
					case 2:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.CIRCLE);
						break;
					case 3:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.ELLIPSE);
						break;
					case 4:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.FACE);
						break;
					case 5:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.LINE);
						break;
					case 6:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.PLINES);
						break;
					case 7:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.SPLINE);
						break;
					case 8:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.TEXT);
						break;
					case 9:
						objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.SOLID3D);
						break;
					default:
						goto IL_1B1;
					}
					if (objectIDs == null)
					{
						return null;
					}
					if (!(PointGeneration.string_0 == "T") && !(PointGeneration.string_0 == "F"))
					{
						PointGeneration.double_0 = CommandLineQuerries.SpecifyDouble("Enter maximum subdivision distance or 0 for no subdivision", PointGeneration.double_0, false, false, false, true);
						return this.method_1(objectIDs, PointGeneration.double_0);
					}
					return this.method_1(objectIDs, 0.0);
				}
			}
			IL_1B1:
			throw new ArgumentException("Invalid option keyword.");
		}

		private PointSet method_1(ObjectId[] objectId_0, double double_1)
		{
			if (objectId_0 == null)
			{
				return null;
			}
			Editor arg_14_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			PointSet pointSet = new PointSet();
			PointSet pointSet2 = new PointSet();
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(objectId_0.Length);
			progressMeter.Start("Computing points on entities");
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					for (int i = 0; i < objectId_0.Length; i++)
					{
						progressMeter.MeterProgress();
						if (i % 10000 == 0)
						{
							System.Windows.Forms.Application.DoEvents();
						}
                        Entity entity = (Entity)objectId_0[i].GetObject((OpenMode)0);
						string text = entity.ToString();
						if (text.ToUpper().Contains("POLYLINE"))
						{
							text = "PLINE";
						}
						string key;
						switch (key = text)
						{
						case "Autodesk.AutoCAD.DatabaseServices.Line":
						{
                            Autodesk.AutoCAD.DatabaseServices.Line dbl = (Autodesk.AutoCAD.DatabaseServices.Line)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = PointGeneration.SubdivideLine(dbl, double_1);
							break;
						}
						case "Autodesk.AutoCAD.DatabaseServices.DBText":
						{
                            DBText dbtext_ = (DBText)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = this.method_2(dbtext_);
							break;
						}
						case "Autodesk.AutoCAD.DatabaseServices.Circle":
						{
                            Autodesk.AutoCAD.DatabaseServices.Circle circle_ = (Autodesk.AutoCAD.DatabaseServices.Circle)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = this.method_3(circle_, double_1);
							break;
						}
						case "Autodesk.AutoCAD.DatabaseServices.Ellipse":
						{
                            Autodesk.AutoCAD.DatabaseServices.Ellipse ellipse_ = (Autodesk.AutoCAD.DatabaseServices.Ellipse)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = this.method_4(ellipse_, double_1);
							break;
						}
						case "Autodesk.AutoCAD.DatabaseServices.Arc":
						{
                            Autodesk.AutoCAD.DatabaseServices.Arc arc_ = (Autodesk.AutoCAD.DatabaseServices.Arc)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = this.method_5(arc_, double_1);
							break;
						}
						case "Autodesk.AutoCAD.DatabaseServices.Spline":
						{
                            Spline spline_ = (Spline)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = this.method_6(spline_, double_1);
							break;
						}
						case "Autodesk.AutoCAD.DatabaseServices.Face":
						{
                            Face face_ = (Face)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
							pointSet2 = this.method_7(face_);
							break;
						}
						case "PLINE":
						{
                            DBObject @object = transaction.GetObject(objectId_0[i], (OpenMode)0);
							pointSet2 = PointGeneration.SubdividePolyline(@object, transaction, double_1);
							break;
						}
						}
						if (pointSet2 != null)
						{
							pointSet.Add(pointSet2);
						}
					}
				}
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
			progressMeter.Stop();
			if (pointSet.Count == 0)
			{
				return null;
			}
			pointSet.RemoveMultiplePoints3d();
			return pointSet;
		}

		private PointSet method_2(DBText dbtext_0)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				double x = dbtext_0.Position.X;
				double y = dbtext_0.Position.Y;
				double z = Convert.ToDouble(dbtext_0.TextString);
				pointSet.Add(new Point(x, y, z));
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not extract height information from text: '" + dbtext_0.TextString + "'\n");
				result = null;
			}
			return result;
		}

        private PointSet method_3(Autodesk.AutoCAD.DatabaseServices.Circle circle_0, double double_1)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				ngeometry.VectorGeometry.Circle circle = Conversions.ToCeometricCircle(circle_0);
				if (double_1 > 0.0 && double_1 < circle.Circumference)
				{
					int num = Math.Max((int)Math.Ceiling(circle.Circumference / double_1), 4);
					double num2 = 6.2831853071795862 / (double)num;
					Point point = Conversions.ToCeometricPoint(circle_0.StartPoint);
					for (int i = 0; i < num; i++)
					{
						ngeometry.VectorGeometry.Matrix3d rotationMatrix = ngeometry.VectorGeometry.Matrix3d.RotationArbitraryAxis(circle.NormalVector, (double)i * num2);
						pointSet.Add(point.Rotate(circle.Center, rotationMatrix));
					}
				}
				else
				{
					pointSet.Add(circle.Center);
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide circle (handle: " + circle_0.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

        private PointSet method_4(Autodesk.AutoCAD.DatabaseServices.Ellipse ellipse_0, double double_1)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				double arg_0D_0 = ellipse_0.StartParam;
				double endParam = ellipse_0.EndParam;
				double distanceAtParameter = ellipse_0.GetDistanceAtParameter(endParam);
				if (double_1 > 0.0 && double_1 < distanceAtParameter)
				{
					int num = (int)Math.Max(Math.Ceiling(distanceAtParameter / double_1), 4.0);
					double num2 = distanceAtParameter / (double)num;
					if (!ellipse_0.Closed)
					{
						num++;
					}
					for (int i = 0; i < num; i++)
					{
						pointSet.Add(Conversions.ToCeometricPoint(ellipse_0.GetPointAtDist((double)i * num2)));
					}
				}
				else if (ellipse_0.Closed)
				{
					pointSet.Add(Conversions.ToCeometricPoint(ellipse_0.Center));
				}
				else
				{
					pointSet.Add(Conversions.ToCeometricPoint(ellipse_0.StartPoint));
					pointSet.Add(Conversions.ToCeometricPoint(ellipse_0.EndPoint));
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide ellipse (handle: " + ellipse_0.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

        private PointSet method_5(Autodesk.AutoCAD.DatabaseServices.Arc arc_0, double double_1)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				double arg_0D_0 = arc_0.StartParam;
				double endParam = arc_0.EndParam;
				double distanceAtParameter = arc_0.GetDistanceAtParameter(endParam);
				if (double_1 > 0.0 && double_1 < distanceAtParameter)
				{
					int num = (int)Math.Max(Math.Ceiling(distanceAtParameter / double_1), 4.0);
					double num2 = distanceAtParameter / (double)num;
					if (!arc_0.Closed)
					{
						num++;
					}
					for (int i = 0; i < num; i++)
					{
						pointSet.Add(Conversions.ToCeometricPoint(arc_0.GetPointAtDist((double)i * num2)));
					}
				}
				else if (arc_0.Closed)
				{
					pointSet.Add(Conversions.ToCeometricPoint(arc_0.Center));
				}
				else
				{
					pointSet.Add(Conversions.ToCeometricPoint(arc_0.StartPoint));
					pointSet.Add(Conversions.ToCeometricPoint(arc_0.EndPoint));
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide arc (handle: " + arc_0.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

		private PointSet method_6(Spline spline_0, double double_1)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				double arg_0D_0 = spline_0.StartParam;
				double endParam = spline_0.EndParam;
				double distanceAtParameter = spline_0.GetDistanceAtParameter(endParam);
				if (double_1 > 0.0 && double_1 < distanceAtParameter)
				{
					int num = (int)Math.Max(Math.Ceiling(distanceAtParameter / double_1), 1.0);
					double num2 = distanceAtParameter / (double)num;
					if (!spline_0.Closed)
					{
						num++;
					}
					for (int i = 0; i < num; i++)
					{
						pointSet.Add(Conversions.ToCeometricPoint(spline_0.GetPointAtDist((double)i * num2)));
					}
				}
				else if (spline_0.Closed)
				{
					pointSet.Add(Conversions.ToCeometricPoint(spline_0.StartPoint));
				}
				else
				{
					pointSet.Add(Conversions.ToCeometricPoint(spline_0.StartPoint));
					pointSet.Add(Conversions.ToCeometricPoint(spline_0.EndPoint));
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide spline (handle: " + spline_0.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

		private PointSet method_7(Face face_0)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				Point point = Conversions.ToCeometricPoint(face_0.GetVertexAt(0));
				Point point2 = Conversions.ToCeometricPoint(face_0.GetVertexAt(1));
				Point point3 = Conversions.ToCeometricPoint(face_0.GetVertexAt(2));
				Point point4 = Conversions.ToCeometricPoint(face_0.GetVertexAt(3));
				pointSet.Add(point);
				if (point2 != point)
				{
					pointSet.Add(point2);
				}
				if (point3 != point && point3 != point2)
				{
					pointSet.Add(point3);
				}
				if (point4 != point && point4 != point2 && point4 != point3)
				{
					pointSet.Add(point4);
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide face (handle: " + face_0.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

        public static PointSet SubdivideLine(Autodesk.AutoCAD.DatabaseServices.Line dbl, double d)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
                ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(dbl.StartPoint.X, dbl.StartPoint.Y, dbl.StartPoint.Z);
                ngeometry.VectorGeometry.Point point2 = new ngeometry.VectorGeometry.Point(dbl.EndPoint.X, dbl.EndPoint.Y, dbl.EndPoint.Z);
				double num = point.DistanceTo(point2);
				int num2 = Math.Max((int)Math.Ceiling(num / d), 1);
                ngeometry.VectorGeometry.Vector3d vector = point2.method_2() - point.method_2();
				for (int i = 0; i <= num2; i++)
				{
					double scalar = (double)i / (double)num2;
					pointSet.Add(new Point(point.method_2() + scalar * vector));
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
				Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide line (handle: " + dbl.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

		public static PointSet SubdivideLWPolyline(Polyline lwp, double d)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				int numberOfVertices = lwp.NumberOfVertices;
				if (d <= 0.0)
				{
					for (int i = 0; i < numberOfVertices; i++)
					{
						Point3d point3dAt = lwp.GetPoint3dAt(i);
						Point point = new Point(point3dAt.X, point3dAt.Y, point3dAt.Z);
						if (pointSet.Count > 1)
						{
							if (pointSet[pointSet.Count - 1] != point)
							{
								pointSet.Add(point);
							}
						}
						else
						{
							pointSet.Add(point);
						}
					}
				}
				else
				{
					List<Point> list = new List<Point>();
					for (int j = 0; j < numberOfVertices; j++)
					{
						Point3d point3dAt2 = lwp.GetPoint3dAt(j);
						list.Add(new Point(point3dAt2.X, point3dAt2.Y, point3dAt2.Z));
					}
					if (lwp.Closed)
					{
						list.Add(list[0]);
					}
					for (int k = 0; k < list.Count - 1; k++)
					{
						Point point2 = list[k];
						Point point3 = list[k + 1];
						ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(point3 - point2);
						double num = point2.DistanceTo(point3);
						int num2 = (int)Math.Max(Math.Ceiling(num / d), 1.0);
						double norm = num / (double)num2;
						vector3d.Norm = norm;
						for (int l = 0; l < num2; l++)
						{
							pointSet.Add(point2 + (double)l * vector3d.ToPoint());
						}
					}
					if (!lwp.Closed)
					{
						pointSet.Add(list[list.Count - 1]);
					}
				}
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide polyline (handle: " + lwp.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

		public static PointSet SubdividePolyline(DBObject obj, Transaction trans, double d)
		{
			Polyline polyline = obj as Polyline;
			if (polyline != null)
			{
				return PointGeneration.SubdivideLWPolyline(polyline, d);
			}
			Polyline2d polyline2d = obj as Polyline2d;
			if (polyline2d != null)
			{
				return PointGeneration.SubdividePolyline2d(polyline2d, trans, d);
			}
			Polyline3d polyline3d = obj as Polyline3d;
			if (!(polyline3d != null))
			{
				throw new ArgumentException("Invalid polyline object: " + obj.Handle.ToString() + "\nObject type: " + obj.GetType().ToString());
			}
			return PointGeneration.SubdividePolyline3d(polyline3d, trans, d);
		}

        public static PointSet SubdividePolyline2d(Autodesk.AutoCAD.DatabaseServices.Polyline2d p2d, Transaction trans, double d)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				if (d <= 0.0)
				{
					//using (System.Collections.IEnumerator enumerator = p2d.GetEnumerator())
                    {
                        System.Collections.IEnumerator enumerator = p2d.GetEnumerator() ;
						while (enumerator.MoveNext())
						{
							ObjectId objectId = (ObjectId)enumerator.Current;
                            Vertex2d vertex2d = (Vertex2d)trans.GetObject(objectId, (OpenMode)0);
							Point point = new Point(vertex2d.Position.X, vertex2d.Position.Y, p2d.Elevation);
							if (pointSet.Count > 1)
							{
								if (pointSet[pointSet.Count - 1] != point)
								{
									pointSet.Add(point);
								}
							}
							else
							{
								pointSet.Add(point);
							}
						}
						goto IL_21D;
					}
				}
				List<Point> list = new List<Point>();
				foreach (ObjectId objectId2 in p2d)
				{
                    Vertex2d vertex2d2 = (Vertex2d)trans.GetObject(objectId2, (OpenMode)0);
					list.Add(new Point(vertex2d2.Position.X, vertex2d2.Position.Y, p2d.Elevation));
				}
				if (p2d.Closed)
				{
					list.Add(list[0]);
				}
				for (int i = 0; i < list.Count - 1; i++)
				{
					Point point2 = list[i];
					Point point3 = list[i + 1];
					ngeometry .VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(point3 - point2);
					double num = point2.DistanceTo(point3);
					double num2 = (double)((int)Math.Max(Math.Ceiling(num / d), 1.0));
					double norm = num / num2;
					vector3d.Norm = norm;
					int num3 = 0;
					while ((double)num3 < num2)
					{
						pointSet.Add(point2 + (double)num3 * vector3d.ToPoint());
						num3++;
					}
				}
				if (!p2d.Closed)
				{
					pointSet.Add(list[list.Count - 1]);
				}
				IL_21D:
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide polyline2d (handle: " + p2d.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

		public static PointSet SubdividePolyline3d(Polyline3d p3d, Transaction trans, double d)
		{
			PointSet result;
			try
			{
				PointSet pointSet = new PointSet();
				if (d <= 0.0)
				{
					//using (IEnumerator enumerator = p3d.GetEnumerator())
                    {
                        IEnumerator enumerator = p3d.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId objectId = (ObjectId)enumerator.Current;
                            PolylineVertex3d polylineVertex3d = (PolylineVertex3d)trans.GetObject(objectId, (OpenMode)0);
							Point point = new Point(polylineVertex3d.Position.X, polylineVertex3d.Position.Y, polylineVertex3d.Position.Z);
							if (pointSet.Count > 1)
							{
								if (pointSet[pointSet.Count - 1] != point)
								{
									pointSet.Add(point);
								}
							}
							else
							{
								pointSet.Add(point);
							}
						}
						goto IL_233;
					}
				}
				List<Point> list = new List<Point>();
				foreach (ObjectId objectId2 in p3d)
				{
                    PolylineVertex3d polylineVertex3d2 = (PolylineVertex3d)trans.GetObject(objectId2, (OpenMode)0);
					list.Add(new Point(polylineVertex3d2.Position.X, polylineVertex3d2.Position.Y, polylineVertex3d2.Position.Z));
				}
				if (p3d.Closed)
				{
					list.Add(list[0]);
				}
				for (int i = 0; i < list.Count - 1; i++)
				{
					Point point2 = list[i];
					Point point3 = list[i + 1];
					ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(point3 - point2);
					double num = point2.DistanceTo(point3);
					double num2 = (double)((int)Math.Max(Math.Ceiling(num / d), 1.0));
					double norm = num / num2;
					vector3d.Norm = norm;
					int num3 = 0;
					while ((double)num3 < num2)
					{
						pointSet.Add(point2 + (double)num3 * vector3d.ToPoint());
						num3++;
					}
				}
				if (!p3d.Closed)
				{
					pointSet.Add(list[list.Count - 1]);
				}
				IL_233:
				result = pointSet;
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("Can not subdivide polyline3d (handle: " + p3d.Handle.ToString() + ")\n");
				result = null;
			}
			return result;
		}

		private static double double_0;

		private static string string_0;
	}
}
