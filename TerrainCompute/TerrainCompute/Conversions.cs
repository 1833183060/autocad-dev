using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;
using TerrainComputeC.BASE;
using TerrainComputeC.XML;

namespace TerrainComputeC
{	
	public class Conversions
	{
		public Conversions()
		{			
		}

		public static CoordinateSystem GetCeometricUcs()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Autodesk.AutoCAD.Geometry.Matrix3d currentUserCoordinateSystem = editor.CurrentUserCoordinateSystem;
			Point3d origin = currentUserCoordinateSystem.CoordinateSystem3d.Origin;
			Autodesk.AutoCAD.Geometry.Vector3d xaxis = currentUserCoordinateSystem.CoordinateSystem3d.Xaxis;
            Autodesk.AutoCAD.Geometry.Vector3d yaxis = currentUserCoordinateSystem.CoordinateSystem3d.Yaxis;
            Autodesk.AutoCAD.Geometry.Vector3d zaxis = currentUserCoordinateSystem.CoordinateSystem3d.Zaxis;
			ngeometry.VectorGeometry.Point originPoint = new ngeometry.VectorGeometry.Point(origin.X, origin.Y, origin.Z);
            ngeometry.VectorGeometry.Vector3d e = new ngeometry.VectorGeometry.Vector3d(xaxis.X, xaxis.Y, xaxis.Z);
            ngeometry.VectorGeometry.Vector3d e2 = new ngeometry.VectorGeometry.Vector3d(yaxis.X, yaxis.Y, yaxis.Z);
            ngeometry.VectorGeometry.Vector3d e3 = new ngeometry.VectorGeometry.Vector3d(zaxis.X, zaxis.Y, zaxis.Z);
			return new ngeometry.VectorGeometry.CoordinateSystem(originPoint, e, e2, e3);
		}

		public static void GetColors(Autodesk.AutoCAD.Colors.Color acColor, ref System.Drawing.Color color, ref short colorIndex)
		{
			color = System.Drawing.Color.Empty;
			colorIndex = 256;
			switch ((int)acColor.ColorMethod)
			{
			case 192:
                    color = System.Drawing.Color.Empty;
				colorIndex = 256;
				return;
			case 193:
                color = System.Drawing.Color.Empty;
				colorIndex = 0;
				return;
			case 194:
                color = System.Drawing.Color.FromArgb((int)acColor.ColorValue.A, (int)acColor.ColorValue.R, (int)acColor.ColorValue.G, (int)acColor.ColorValue.B);
				return;
			case 195:
                color = System.Drawing.Color.Empty;
				colorIndex = acColor.ColorIndex;
				return;
			case 196:
                color = System.Drawing.Color.Empty;
				colorIndex = 7;
				return;
			case 197:
                color = System.Drawing.Color.Empty;
				colorIndex = 7;
				return;
			case 198:
                color = System.Drawing.Color.Empty;
				colorIndex = 7;
				return;
			case 199:
                color = System.Drawing.Color.Empty;
				colorIndex = 7;
				return;
			case 200:
                color = System.Drawing.Color.Empty;
				colorIndex = 7;
				return;
			default:
				return;
			}
		}

		public static int GetNumberOfPoyllineVertices(DBObject obj)
		{
			Polyline polyline = obj as Polyline;
			if (polyline != null)
			{
				return polyline.NumberOfVertices;
			}
			Polyline2d polyline2d = obj as Polyline2d;
			if (polyline2d != null)
			{
				int num = 0;
				foreach (ObjectId arg_40_0 in polyline2d)
				{
					num++;
				}
				return num;
			}
			Polyline3d polyline3d = obj as Polyline3d;
			if (polyline3d != null)
			{
				int num2 = 0;
				//using (IEnumerator enumerator2 = polyline3d.GetEnumerator())
                {
                    IEnumerator enumerator2 = polyline3d.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ObjectId arg_91_0 = (ObjectId)enumerator2.Current;
						num2++;
					}
					return num2;
				}
			}
			throw new ArgumentException("Invalid polyline object: " + obj.Handle.ToString() + "\nObject type: " + obj.GetType().ToString());
		}

		public static CoordinateSystem GetUCS()
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Autodesk.AutoCAD.Geometry.Matrix3d currentUserCoordinateSystem = editor.CurrentUserCoordinateSystem;
			Point3d origin = currentUserCoordinateSystem.CoordinateSystem3d.Origin;
            Autodesk.AutoCAD.Geometry.Vector3d xaxis = currentUserCoordinateSystem.CoordinateSystem3d.Xaxis;
            Autodesk.AutoCAD.Geometry.Vector3d yaxis = currentUserCoordinateSystem.CoordinateSystem3d.Yaxis;
            Autodesk.AutoCAD.Geometry.Vector3d zaxis = currentUserCoordinateSystem.CoordinateSystem3d.Zaxis;
			ngeometry.VectorGeometry.Point originPoint = new ngeometry.VectorGeometry.Point(origin.X, origin.Y, origin.Z);
            ngeometry.VectorGeometry.Vector3d e = new ngeometry.VectorGeometry.Vector3d(xaxis.X, xaxis.Y, xaxis.Z);
            ngeometry.VectorGeometry.Vector3d e2 = new ngeometry.VectorGeometry.Vector3d(yaxis.X, yaxis.Y, yaxis.Z);
            ngeometry.VectorGeometry.Vector3d e3 = new ngeometry.VectorGeometry.Vector3d(zaxis.X, zaxis.Y, zaxis.Z);
			return new CoordinateSystem(originPoint, e, e2, e3);
		}

		public static bool IsWCS(CoordinateSystem ucs)
		{
			CoordinateSystem coordinateSystem = CoordinateSystem.Global();
			return !(coordinateSystem.Origin != ucs.Origin) && !(coordinateSystem.BasisVector[0] != ucs.BasisVector[0]) && !(coordinateSystem.BasisVector[1] != ucs.BasisVector[1]) && !(coordinateSystem.BasisVector[2] != ucs.BasisVector[2]);
		}

		internal static ObjectId[] smethod_0(ObjectId[] objectId_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<ObjectId> list = new List<ObjectId>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable arg_2A_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
				for (int i = objectId_0.Length - 1; i >= 0; i--)
				{
					Autodesk.AutoCAD.DatabaseServices.Face face = (Autodesk.AutoCAD.DatabaseServices.Face)transaction.GetObject(objectId_0[i], (OpenMode)1, true);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(face.BlockId, (OpenMode)1);
					Point3d vertexAt = face.GetVertexAt(0);
					Point3d vertexAt2 = face.GetVertexAt(1);
					Point3d vertexAt3 = face.GetVertexAt(2);
					Point3d vertexAt4 = face.GetVertexAt(3);
					ngeometry.VectorGeometry.Point left = new ngeometry.VectorGeometry.Point(vertexAt.X, vertexAt.Y, vertexAt.Z);
					ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
					ngeometry.VectorGeometry.Point point2 = new ngeometry.VectorGeometry.Point(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
					ngeometry.VectorGeometry.Point right = new ngeometry.VectorGeometry.Point(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
					if (left != point && left != point2 && left != right && point != point2 && point != right && point2 != right)
					{
                        Autodesk.AutoCAD.DatabaseServices.Face face2 = new Autodesk.AutoCAD.DatabaseServices.Face(vertexAt, vertexAt2, vertexAt4, true, true, true, true);
						face2.LayerId=(face.LayerId);
						blockTableRecord.AppendEntity(face2);
						transaction.AddNewlyCreatedDBObject(face2, true);
						list.Add(face2.ObjectId);
                        Autodesk.AutoCAD.DatabaseServices.Face face3 = new Autodesk.AutoCAD.DatabaseServices.Face(vertexAt2, vertexAt3, vertexAt4, true, true, true, true);
						face3.LayerId=(face.LayerId);
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
						list.Add(face.ObjectId);
					}
				}
				transaction.Commit();
			}
			return list.ToArray();
		}

		public static List<Edge> ToCeometricAcDbEdgeList(ObjectId[] lineIDs)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Edge> list = new List<Edge>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				string arg_1D_0 = SymbolUtilityServices.BlockModelSpaceName;
                LayerTable arg_30_0 = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
				for (int i = 0; i < lineIDs.Length; i++)
				{
                    Autodesk.AutoCAD.DatabaseServices.Line line = (Autodesk.AutoCAD.DatabaseServices.Line)transaction.GetObject(lineIDs[i], (OpenMode)0, true);
                    LayerTableRecord arg_66_0 = (LayerTableRecord)transaction.GetObject(line.LayerId, (OpenMode)0);
					Point3d startPoint = line.StartPoint;
					Point3d endPoint = line.EndPoint;
					ngeometry.VectorGeometry.Point startPoint2 = new ngeometry.VectorGeometry.Point(startPoint.X, startPoint.Y, startPoint.Z);
					ngeometry.VectorGeometry.Point endPoint2 = new ngeometry.VectorGeometry.Point(endPoint.X, endPoint.Y, endPoint.Z);
					list.Add(new Edge(startPoint2, endPoint2)
					{
                        AcDbLine = line
					});
				}
			}
			return list;
		}

		public static PointSet ToCeometricAcDbPointSet(ObjectId[] pointIDs)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			PointSet pointSet = new PointSet();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				for (int i = 0; i < pointIDs.Length; i++)
				{
                    DBPoint dBPoint = (DBPoint)transaction.GetObject(pointIDs[i], (OpenMode)0, true);
					double x = dBPoint.Position.X;
					double y = dBPoint.Position.Y;
					double z = dBPoint.Position.Z;
					pointSet.Add(new ngeometry.VectorGeometry.Point(x, y, z)
					{
						acDbPoint = dBPoint
					});
				}
			}
			return pointSet;
		}

		public static List<Triangle> ToCeometricAcDbTriangleList(ObjectId[] faceIDs)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Triangle> list = new List<Triangle>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				for (int i = 0; i < faceIDs.Length; i++)
				{
                    Autodesk.AutoCAD.DatabaseServices.Face face = (Autodesk.AutoCAD.DatabaseServices.Face)transaction.GetObject(faceIDs[i], (OpenMode)0, true);
					Point3d vertexAt = face.GetVertexAt(0);
					Point3d vertexAt2 = face.GetVertexAt(1);
					Point3d vertexAt3 = face.GetVertexAt(2);
					Point3d vertexAt4 = face.GetVertexAt(3);
					ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(vertexAt.X, vertexAt.Y, vertexAt.Z);
					ngeometry.VectorGeometry.Point point2 = new ngeometry.VectorGeometry.Point(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
					ngeometry.VectorGeometry.Point point3 = new ngeometry.VectorGeometry.Point(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
					ngeometry.VectorGeometry.Point point4 = new ngeometry.VectorGeometry.Point(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
					if (point != point2 && point != point3 && point != point4 && point2 != point3 && point2 != point4 && point3 != point4)
					{
						list.Add(new Triangle(point, point2, point4, false)
						{
							AcDbFace = face
						});
						list.Add(new Triangle(point2, point3, point4, false)
						{
							AcDbFace = face
						});
					}
					else
					{
						list.Add(new Triangle(point, point2, point3, false)
						{
							AcDbFace = face
						});
					}
				}
			}
			return list;
		}

		public static List<Edge> ToCeometricCADDataEdgeList(ObjectId[] lineIDs)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Edge> list = new List<Edge>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				string blockModelSpaceName = SymbolUtilityServices.BlockModelSpaceName;
                LayerTable arg_30_0 = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
				for (int i = 0; i < lineIDs.Length; i++)
				{
                    Autodesk.AutoCAD.DatabaseServices.Line line = (Autodesk.AutoCAD.DatabaseServices.Line)transaction.GetObject(lineIDs[i], (OpenMode)0, true);
                    LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(line.LayerId, (OpenMode)0);
                    Autodesk.AutoCAD.Colors.Color color = line.Color;
					if (color.IsByLayer)
					{
						color = layerTableRecord.Color;
					}
					System.Drawing.Color empty =System.Drawing.Color.Empty;
					short colorIndex = 256;
					Conversions.GetColors(color, ref empty, ref colorIndex);
					CADData cADData = new CADData();
					cADData.Layer.Name = layerTableRecord.Name;
					cADData.Color = empty;
					cADData.ColorIndex = colorIndex;
					cADData.BlockName = blockModelSpaceName;
					Point3d startPoint = line.StartPoint;
					Point3d endPoint = line.EndPoint;
					ngeometry.VectorGeometry.Point startPoint2 = new ngeometry.VectorGeometry.Point(startPoint.X, startPoint.Y, startPoint.Z);
					ngeometry.VectorGeometry.Point endPoint2 = new ngeometry.VectorGeometry.Point(endPoint.X, endPoint.Y, endPoint.Z);
					list.Add(new Edge(startPoint2, endPoint2)
					{
						CADData = cADData
					});
				}
			}
			return list;
		}

		public static PointSet ToCeometricCADDataPointList(ObjectId[] pointIDs)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			PointSet pointSet = new PointSet();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				string blockModelSpaceName = SymbolUtilityServices.BlockModelSpaceName;
                LayerTable arg_30_0 = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
				for (int i = 0; i < pointIDs.Length; i++)
				{
                    DBPoint dBPoint = (DBPoint)transaction.GetObject(pointIDs[i], (OpenMode)0, true);
                    LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(dBPoint.LayerId, (OpenMode)0);
                    Autodesk.AutoCAD.Colors.Color color = dBPoint.Color;
					if (color.IsByLayer)
					{
						color = layerTableRecord.Color;
					}
					System.Drawing.Color empty =System.Drawing.Color.Empty;
					short colorIndex = 256;
					Conversions.GetColors(color, ref empty, ref colorIndex);
					CADData cADData = new CADData();
					cADData.Layer.Name = layerTableRecord.Name;
					cADData.Color = empty;
					cADData.ColorIndex = colorIndex;
					cADData.BlockName = blockModelSpaceName;
					double x = dBPoint.Position.X;
					double y = dBPoint.Position.Y;
					double z = dBPoint.Position.Z;
					pointSet.Add(new ngeometry.VectorGeometry.Point(x, y, z)
					{
						CADData = cADData
					});
				}
			}
			return pointSet;
		}

		public static List<Triangle> ToCeometricCADDataTriangleList(ObjectId[] faceIDs)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Triangle> list = new List<Triangle>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				string blockModelSpaceName = SymbolUtilityServices.BlockModelSpaceName;
                LayerTable arg_30_0 = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
				for (int i = 0; i < faceIDs.Length; i++)
				{
                    Autodesk.AutoCAD.DatabaseServices.Face face = (Autodesk.AutoCAD.DatabaseServices.Face)transaction.GetObject(faceIDs[i], (OpenMode)0, true);
                    LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(face.LayerId, (OpenMode)0);
                    Autodesk.AutoCAD.Colors.Color color = face.Color;
					if (color.IsByLayer)
					{
						color = layerTableRecord.Color;
					}
					System.Drawing.Color empty =System.Drawing.Color.Empty;
					short colorIndex = 256;
					Conversions.GetColors(color, ref empty, ref colorIndex);
					CADData cADData = new CADData();
					cADData.Layer.Name = layerTableRecord.Name;
					cADData.Color = empty;
					cADData.ColorIndex = colorIndex;
					cADData.BlockName = blockModelSpaceName;
					Point3d vertexAt = face.GetVertexAt(0);
					Point3d vertexAt2 = face.GetVertexAt(1);
					Point3d vertexAt3 = face.GetVertexAt(2);
					Point3d vertexAt4 = face.GetVertexAt(3);
					ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(vertexAt.X, vertexAt.Y, vertexAt.Z);
					ngeometry.VectorGeometry.Point point2 = new ngeometry.VectorGeometry.Point(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
					ngeometry.VectorGeometry.Point point3 = new ngeometry.VectorGeometry.Point(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
					ngeometry.VectorGeometry.Point point4 = new ngeometry.VectorGeometry.Point(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
					if (point != point2 && point != point3 && point != point4 && point2 != point3 && point2 != point4 && point3 != point4)
					{
						list.Add(new Triangle(point, point2, point4, false)
						{
							CADData = cADData
						});
						list.Add(new Triangle(point2, point3, point4, false)
						{
							CADData = cADData
						});
					}
					else
					{
						list.Add(new Triangle(point, point2, point3, false)
						{
							CADData = cADData
						});
					}
				}
			}
			return list;
		}

		public static ngeometry.VectorGeometry.Circle ToCeometricCircle(Autodesk.AutoCAD.DatabaseServices.Circle circle/*ng:类型存疑*/)
		{
			ngeometry.VectorGeometry.Point center = new ngeometry.VectorGeometry.Point(circle.Center.X, circle.Center.Y, circle.Center.Z);
            ngeometry.VectorGeometry.Vector3d normalVector = new ngeometry.VectorGeometry.Vector3d(circle.Normal.X, circle.Normal.Y, circle.Normal.Z);
			return new ngeometry.VectorGeometry.Circle(center, circle.Radius, normalVector);
            
		}

		public static Edge ToCeometricEdge(Autodesk.AutoCAD.DatabaseServices.Line line)
		{
			ngeometry.VectorGeometry.Point startPoint = new ngeometry.VectorGeometry.Point(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z);
			ngeometry.VectorGeometry.Point endPoint = new ngeometry.VectorGeometry.Point(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z);
			return new Edge(startPoint, endPoint);
		}

		public static List<Edge> ToCeometricEdgeList(Polyline2d pline2d)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Edge> list = new List<Edge>();
			PointSet pointSet = new PointSet();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				foreach (ObjectId objectId in pline2d)
				{
                    Vertex2d vertex2d = (Vertex2d)transaction.GetObject(objectId, (OpenMode)0);
					pointSet.Add(new ngeometry.VectorGeometry.Point(vertex2d.Position.X, vertex2d.Position.Y, pline2d.Elevation));
				}
				if (pline2d.Closed)
				{
					pointSet.Add(pointSet[0]);
				}
			}
			for (int i = 0; i < pointSet.Count - 1; i++)
			{
				list.Add(new Edge(pointSet[i], pointSet[i + 1]));
			}
			return list;
		}

		public static List<Edge> ToCeometricEdgeList(Polyline3d pline3d)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Edge> list = new List<Edge>();
			PointSet pointSet = new PointSet();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				foreach (ObjectId objectId in pline3d)
				{
                    PolylineVertex3d polylineVertex3d = (PolylineVertex3d)transaction.GetObject(objectId, (OpenMode)0);
					pointSet.Add(new ngeometry.VectorGeometry.Point(polylineVertex3d.Position.X, polylineVertex3d.Position.Y, polylineVertex3d.Position.Z));
				}
				if (pline3d.Closed)
				{
					pointSet.Add(pointSet[0]);
				}
			}
			for (int i = 0; i < pointSet.Count - 1; i++)
			{
				list.Add(new Edge(pointSet[i], pointSet[i + 1]));
			}
			return list;
		}

		public static List<Edge> ToCeometricEdgeList(ObjectId[] idArray)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Edge> list = new List<Edge>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				for (int i = 0; i < idArray.Length; i++)
				{
                    DBObject @object = transaction.GetObject(idArray[i], (OpenMode)0);
					if (!(@object == null))
					{
						Autodesk.AutoCAD.DatabaseServices.Line line = @object as Autodesk.AutoCAD.DatabaseServices.Line;
						if (line != null)
						{
							ngeometry.VectorGeometry.Point startPoint = Conversions.ToCeometricPoint(line.StartPoint);
							ngeometry.VectorGeometry.Point endPoint = Conversions.ToCeometricPoint(line.EndPoint);
							list.Add(new Edge(startPoint, endPoint));
						}
						else
						{
							PointSet pointSet = null;
							Polyline polyline = @object as Polyline;
							if (polyline != null)
							{
								pointSet = PointGeneration.SubdivideLWPolyline(polyline, 0.0);
								if (polyline.Closed)
								{
									pointSet.Add(pointSet[0]);
								}
							}
							Polyline2d polyline2d = @object as Polyline2d;
							if (polyline2d != null)
							{
								pointSet = PointGeneration.SubdividePolyline2d(polyline2d, transaction, 0.0);
								if (polyline2d.Closed)
								{
									pointSet.Add(pointSet[0]);
								}
							}
							Polyline3d polyline3d = @object as Polyline3d;
							if (polyline3d != null)
							{
								pointSet = PointGeneration.SubdividePolyline3d(polyline3d, transaction, 0.0);
								if (polyline3d.Closed)
								{
									pointSet.Add(pointSet[0]);
								}
							}
							if (pointSet != null)
							{
								for (int j = 0; j < pointSet.Count - 1; j++)
								{
									list.Add(new Edge(pointSet[j], pointSet[j + 1]));
								}
							}
						}
					}
				}
			}
			return list;
		}

		public static ngeometry.VectorGeometry.Ellipse ToCeometricEllipse(Autodesk.AutoCAD.DatabaseServices.Ellipse dbe)
		{
			ngeometry.VectorGeometry.Point center = new ngeometry.VectorGeometry.Point(dbe.Center.X, dbe.Center.Y, dbe.Center.Z);
            ngeometry.VectorGeometry.Vector3d semimajorAxis = new ngeometry.VectorGeometry.Vector3d(dbe.MajorAxis.X, dbe.MajorAxis.Y, dbe.MajorAxis.Z);
            ngeometry.VectorGeometry.Vector3d semiminorAxis = new ngeometry.VectorGeometry.Vector3d(dbe.MinorAxis.X, dbe.MinorAxis.Y, dbe.MinorAxis.Z);
            return new ngeometry.VectorGeometry.Ellipse(center, semimajorAxis, semiminorAxis);
		}

		public static ngeometry.VectorGeometry.Point ToCeometricPoint(Point3d point3d)
		{
			return new ngeometry.VectorGeometry.Point(point3d.X, point3d.Y, point3d.Z);
		}

		public static ngeometry.VectorGeometry.Point ToCeometricPoint(DBPoint dbPoint)
		{
			return new ngeometry.VectorGeometry.Point(dbPoint.Position.X, dbPoint.Position.Y, dbPoint.Position.Z);
		}

		public static PointSet ToCeometricPointSet(ObjectId[] idArray)
		{
			if (idArray == null)
			{
				throw new ArgumentException("No entities selected.");
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			PointSet pointSet = new PointSet();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				for (int i = 0; i < idArray.Length; i++)
				{
                    DBPoint dbPoint = (DBPoint)transaction.GetObject(idArray[i], OpenMode.ForRead, true);
					pointSet.Add(Conversions.ToCeometricPoint(dbPoint));
				}
			}
			return pointSet;
		}
        public static PointSet2 ToCeometricPointSet2(ObjectId[] idArray)
        {
            if (idArray == null)
            {
                throw new ArgumentException("No entities selected.");
            }
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            PointSet2 pointSet = new PointSet2();
            using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < idArray.Length; i++)
                {
                    DBPoint dbPoint = (DBPoint)transaction.GetObject(idArray[i], OpenMode.ForRead, true);
                    pointSet.Add(Conversions.ToCeometricPoint(dbPoint));
                }
            }
            return pointSet;
        }

		public static List<Triangle> ToCeometricTriangleList(ObjectId[] idArray)
		{
			if (idArray == null)
			{
                throw new System.Exception("No faces selected.");
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<Triangle> list = new List<Triangle>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				for (int i = 0; i < idArray.Length; i++)
				{
                    Autodesk.AutoCAD.DatabaseServices.Face face = (Autodesk.AutoCAD.DatabaseServices.Face)transaction.GetObject(idArray[i], (OpenMode)0, true);
					Point3d vertexAt = face.GetVertexAt(0);
					Point3d vertexAt2 = face.GetVertexAt(1);
					Point3d vertexAt3 = face.GetVertexAt(2);
					Point3d vertexAt4 = face.GetVertexAt(3);
					ngeometry.VectorGeometry.Point point = new ngeometry.VectorGeometry.Point(vertexAt.X, vertexAt.Y, vertexAt.Z);
					ngeometry.VectorGeometry.Point point2 = new ngeometry.VectorGeometry.Point(vertexAt2.X, vertexAt2.Y, vertexAt2.Z);
					ngeometry.VectorGeometry.Point point3 = new ngeometry.VectorGeometry.Point(vertexAt3.X, vertexAt3.Y, vertexAt3.Z);
					ngeometry.VectorGeometry.Point point4 = new ngeometry.VectorGeometry.Point(vertexAt4.X, vertexAt4.Y, vertexAt4.Z);
					if (point != point2 && point != point3 && point != point4 && point2 != point3 && point2 != point4 && point3 != point4)
					{
						list.Add(new Triangle(point, point2, point4, false));
						list.Add(new Triangle(point2, point3, point4, false));
					}
					else
					{
						list.Add(new Triangle(point, point2, point3, false));
					}
				}
			}
			return list;
		}

		public static List<IdPoint> ToIdPoints(ObjectId[] idArray)
		{
			if (idArray == null)
			{
                throw new System.Exception("No points selected.");
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			List<IdPoint> list = new List<IdPoint>();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				for (int i = 0; i < idArray.Length; i++)
				{
                    DBPoint dbPoint = (DBPoint)transaction.GetObject(idArray[i], (OpenMode)0, true);
					list.Add(new IdPoint(dbPoint));
				}
			}
			return list;
		}

		public static Point3dCollection ToPoint3dCollection(List<ngeometry.VectorGeometry.Point> points)
		{
			Point3d[] array = new Point3d[points.Count];
			for (int i = 0; i < points.Count; i++)
			{
				array[i] = new Point3d(points[i].X, points[i].Y, points[i].Z);
                if (((int)array[i].X * 100) == 750 && ((int)array[i].Y * 100) == 10485)
                {

                }
			}
			return new Point3dCollection(array);
		}

		public static Point3dCollection ToPoint3dCollection(List<global::TerrainComputeC.XML.Vertex> points)
		{
			Point3d[] array = new Point3d[points.Count];
			for (int i = 0; i < points.Count; i++)
			{
				array[i] = new Point3d(points[i].X, points[i].Y, points[i].Z);
			}
			return new Point3dCollection(array);
		}

		public static void ToWCS(CoordinateSystem actualCS, PointSet ps)
		{
			if (Conversions.IsWCS(actualCS))
			{
				return;
			}
			ps.TransformCoordinates(actualCS, CoordinateSystem.Global());
		}

		public static void ToWCS(CoordinateSystem actualCS, List<Edge> edges)
		{
			if (Conversions.IsWCS(actualCS))
			{
				return;
			}
			Edge.TransformCoordinates(edges, actualCS, CoordinateSystem.Global());
		}

		public static void ToWCS(CoordinateSystem actualCS, List<Triangle> trs)
		{
			if (Conversions.IsWCS(actualCS))
			{
				return;
			}
			Triangle.TransformCoordinates(trs, actualCS, CoordinateSystem.Global());
		}

		public static void UcsToWcs(PointSet ps)
		{
			CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
			if (Conversions.IsWCS(ceometricUcs))
			{
				return;
			}
			ps.TransformCoordinates(ceometricUcs, CoordinateSystem.Global());
		}

		public static void UcsToWcs(List<Edge> edges)
		{
			CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
			if (Conversions.IsWCS(ceometricUcs))
			{
				return;
			}
			Edge.TransformCoordinates(edges, ceometricUcs, CoordinateSystem.Global());
		}

		public static void UcsToWcs(List<Triangle> trs)
		{
			CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
			if (Conversions.IsWCS(ceometricUcs))
			{
				return;
			}
			Triangle.TransformCoordinates(trs, ceometricUcs, CoordinateSystem.Global());
		}

		public static void WcsToUcs(PointSet ps)
		{
			CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
			if (Conversions.IsWCS(ceometricUcs))
			{
				return;
			}
			ps.TransformCoordinates(CoordinateSystem.Global(), ceometricUcs);
		}

		public static void WcsToUcs(List<Edge> edges)
		{
			CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
			if (Conversions.IsWCS(ceometricUcs))
			{
				return;
			}
			Edge.TransformCoordinates(edges, CoordinateSystem.Global(), ceometricUcs);
		}

		public static void WcsToUcs(List<Triangle> trs)
		{
			CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
			if (Conversions.IsWCS(ceometricUcs))
			{
				return;
			}
			Triangle.TransformCoordinates(trs, CoordinateSystem.Global(), ceometricUcs);
		}
	}
}
