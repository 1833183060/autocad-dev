using System;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.HULL
{
	//[LicenseProvider(typeof(Class46))]
	public class CMD_MinimumEnclosingCircle
	{
		static CMD_MinimumEnclosingCircle()
		{
			CMD_MinimumEnclosingCircle.string_0 = "Z";
		}

		public CMD_MinimumEnclosingCircle()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(CMD_MinimumEnclosingCircle));
			//base..ctor();
		}

		public static void ComputeMinEnclosingCircle(ObjectId[] idArray, CoordinateSystem actualCS)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter value = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(value);
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					progressMeter.SetLimit(idArray.Length);
					if ((double)idArray.Length > 10000.0)
					{
						progressMeter.Start("Computing min. enclosing circle...");
					}
					CoordinateTransformator coordinateTransformator = new CoordinateTransformator(CoordinateSystem.Global(), actualCS);
					CoordinateTransformator inverseTransformation = coordinateTransformator.GetInverseTransformation();
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					ObjectId layerId = DBManager.CurrentLayerId();
					DBManager.CurrentLayerName();
					PointSet pointSet = new PointSet();
					for (int i = 0; i < idArray.Length; i++)
					{
						progressMeter.MeterProgress();
                        DBPoint dBPoint = (DBPoint)transaction.GetObject(idArray[i], (OpenMode)0, true);
						Point point = new Point(dBPoint.Position.X, dBPoint.Position.Y, dBPoint.Position.Z);
						coordinateTransformator.Transform(point);
						pointSet.Add(point);
					}
					ConvexHull2d convexHull2d = new ConvexHull2d();
					convexHull2d.InitialPoints = pointSet;
					convexHull2d.ComputeHull();
					PointSet vertices = convexHull2d.Vertices;
					double z = vertices[0].Z;
					for (int j = 0; j < vertices.Count; j++)
					{
						vertices[j].Z = z;
					}
					SmallestEnclosingCircle smallestEnclosingCircle = new SmallestEnclosingCircle(vertices);
					ngeometry.VectorGeometry.Circle circle = smallestEnclosingCircle.ComputeCircle();
					Point center = circle.Center;
					Point point2 = circle.NormalVector.ToPoint();
					inverseTransformation.Transform(center);
					inverseTransformation.Transform(point2);
                    Autodesk.AutoCAD.DatabaseServices.Circle circle2 = new Autodesk.AutoCAD.DatabaseServices.Circle(new Autodesk.AutoCAD.Geometry.Point3d(center.X, center.Y, center.Z), new Autodesk.AutoCAD.Geometry.Vector3d(point2.X, point2.Y, point2.Z), circle.Radius);
					circle2.LayerId=(layerId);
					blockTableRecord.AppendEntity(circle2);
					transaction.AddNewlyCreatedDBObject(circle2, true);
					editor.WriteMessage("\nMinimum enclosing circle properties:");
					editor.WriteMessage("\n------------------------------------");
					editor.WriteMessage("\nRadius          : " + circle.Radius.ToString(DBManager.GetFormatFromLUPREC()));
					editor.WriteMessage("\nArea            : " + circle.Area.ToString(DBManager.GetFormatFromLUPREC()));
					editor.WriteMessage("\nPerimeter length: " + circle.Circumference.ToString(DBManager.GetFormatFromLUPREC()));
					transaction.Commit();
				}
				progressMeter.Stop();
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		[CommandMethod("TCPlugin", "ng:HULL:MINCIRCLE", 0)]
		public void MinEnclosingCircleCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] idArray = CommandLineQuerries.SelectPoints(false);
				CMD_MinimumEnclosingCircle.string_0 = CommandLineQuerries.SpecifyProjectionDirection(CMD_MinimumEnclosingCircle.string_0);
				ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
				string a;
				if ((a = CMD_MinimumEnclosingCircle.string_0.ToUpper()) != null)
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
										goto IL_150;
									}
									vector3d = CommandLineQuerries.Specify2PDirection().BasisVector[2];
									vector3d = vector3d.Normalize();
								}
								else
								{
									vector3d = Conversions.GetUCS().BasisVector[2].Normalize();
								}
							}
							else
							{
                                vector3d = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
							}
						}
						else
						{
                            vector3d = new ngeometry.VectorGeometry.Vector3d(0.0, 1.0, 0.0);
						}
					}
					else
					{
                        vector3d = new ngeometry.VectorGeometry.Vector3d(1.0, 0.0, 0.0);
					}
					Point point = new Point(0.0, 0.0, 0.0);
                    ngeometry.VectorGeometry.Plane plane = new ngeometry.VectorGeometry.Plane(point, vector3d);
					CoordinateSystem actualCS = new CoordinateSystem(plane);
					CMD_MinimumEnclosingCircle.ComputeMinEnclosingCircle(idArray, actualCS);
					return;
				}
				IL_150:
				throw new System.Exception("Invalid option keyword.");
			}
			catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private static string string_0;
	}
}
