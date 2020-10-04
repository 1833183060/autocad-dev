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
using TerrainComputeC;

//[LicenseProvider(typeof(Class46))]
internal class Class1
{
	static Class1()
	{
		Class1.string_0 = "Z";
	}

	public Class1()
	{
		//System.ComponentModel.LicenseManager.Validate(typeof(Class1));
		//base..ctor();
	}

	[CommandMethod("TCPlugin", "ng:HULL:MINPERIMETER", 0)]
	public void method_0()
	{
        Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
		try
		{
			//TCPlugin.LicenseManager.CheckValid("FULL");
			ObjectId[] objectId_ = CommandLineQuerries.SelectPoints(false);
			Class1.string_0 = CommandLineQuerries.SpecifyProjectionDirection(Class1.string_0);
            ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0);
			string a;
			if ((a = Class1.string_0.ToUpper()) != null)
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
				CoordinateSystem coordinateSystem_ = new CoordinateSystem(plane);
				Class1.smethod_0(objectId_, coordinateSystem_);
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

	public static void smethod_0(ObjectId[] objectId_0, CoordinateSystem coordinateSystem_0)
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
				progressMeter.SetLimit(objectId_0.Length);
				if ((double)objectId_0.Length > 10000.0)
				{
					progressMeter.Start("Computing min. perimeter rectangle...");
				}
				CoordinateTransformator coordinateTransformator = new CoordinateTransformator(CoordinateSystem.Global(), coordinateSystem_0);
				CoordinateTransformator inverseTransformation = coordinateTransformator.GetInverseTransformation();
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
				ObjectId layerId = DBManager.CurrentLayerId();
				DBManager.CurrentLayerName();
				PointSet pointSet = new PointSet();
				for (int i = 0; i < objectId_0.Length; i++)
				{
					progressMeter.MeterProgress();
                    DBPoint dBPoint = (DBPoint)transaction.GetObject(objectId_0[i], (OpenMode)0, true);
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
				BoundingRectangle boundingRectangle = convexHull2d.MinimumPerimeterEnclosingRectangle();
				PointSet vertices2 = boundingRectangle.GetVertices();
				for (int k = 0; k < vertices2.Count; k++)
				{
					inverseTransformation.Transform(vertices2[k]);
				}
				Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(vertices2.ToList());
				Polyline3d polyline3d = new Polyline3d(0, point3dCollection, true);
				polyline3d.LayerId=(layerId);
				blockTableRecord.AppendEntity(polyline3d);
				transaction.AddNewlyCreatedDBObject(polyline3d, true);
				editor.WriteMessage("\nMinimum perimeter enclosing rectangle properties:");
				editor.WriteMessage("\n-------------------------------------------------");
				editor.WriteMessage("\nWidth           : " + boundingRectangle.Width.ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nHeight          : " + boundingRectangle.Length.ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nArea            : " + (boundingRectangle.Length * boundingRectangle.Width).ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nPerimeter length: " + (2.0 * boundingRectangle.Length + 2.0 * boundingRectangle.Width).ToString(DBManager.GetFormatFromLUPREC()));
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

	private static string string_0;
}
