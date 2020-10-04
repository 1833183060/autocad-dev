using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.BoundaryRepresentation;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class Tesselation
	{
		public Tesselation()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Tesselation));
			//base..ctor();
		}

		[CommandMethod("EXP")]
		public static void ExplodeSolid()
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				TypedValue[] array = new TypedValue[]
				{
					new TypedValue(0, "3DSOLID")
				};
				PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
				promptSelectionOptions.MessageForAdding=("Select 3d solids");
				PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, new SelectionFilter(array));
                if (selection.Status == (PromptStatus)5100)
				{
					ObjectId[] objectIds = selection.Value.GetObjectIds();
					DBObjectCollection dBObjectCollection = new DBObjectCollection();
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
						for (int i = 0; i < objectIds.Length; i++)
						{
                            dBObjectCollection.Add(transaction.GetObject(objectIds[i], (OpenMode)0));
						}
					}
					DBObjectCollection dBObjectCollection2 = new DBObjectCollection();
					Tesselation.smethod_0(dBObjectCollection, ref dBObjectCollection2);
					editor.WriteMessage("\nElements: " + dBObjectCollection2.Count);
				}
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\nException during traversal: {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		[CommandMethod("TCPlugin", "ng:SOLIDS:LOAD", 0)]
		public void LoadCommand()
		{
			Database arg_05_0 = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.SOLID3D, "Select 3d solids", false);
				double num = this.method_1(objectIDs);
				PromptDoubleOptions promptDoubleOptions = new PromptDoubleOptions("Maximum node spacing");
				promptDoubleOptions.DefaultValue=(num / 100.0);
				double value = editor.GetDouble(promptDoubleOptions).Value;
				string text = CommandLineQuerries.KeywordYesNo("Show generated nodes", "N", false, false);
				PointSet pointSet = this.method_0(objectIDs, value);
				editor.WriteMessage("\n" + pointSet.Count + " points generated on solids.");
				ConvexHull3d convexHull3d = new ConvexHull3d();
				convexHull3d.InitialPoints = pointSet;
				convexHull3d.ComputeHull();
				BoundingBox boundingBox = convexHull3d.PrincipalAxesBoundingBox();
				List<Triangle> surface = boundingBox.GetSurface();
				if (text.Trim().ToUpper() == "Y")
				{
					DBManager.WriteListInDatabase<Point>(pointSet.ToList(), null, DBManager.EntityPropertiesAssignment.ByDialog, ObjectId.Null, ObjectId.Null);
				}
				DBManager.WriteListInDatabase<Triangle>(surface, null, DBManager.EntityPropertiesAssignment.ByDialog, ObjectId.Null, ObjectId.Null);
				editor.WriteMessage("\nPrincipal axes bounding box properties:");
				editor.WriteMessage("\n---------------------------------------");
				editor.WriteMessage("\nWidth              : " + boundingBox.Width.ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nLength             : " + boundingBox.Length.ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nHeight             : " + boundingBox.Height.ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nVolume             : " + boundingBox.Volume().ToString(DBManager.GetFormatFromLUPREC()));
				editor.WriteMessage("\nCenter             : " + boundingBox.CoordinateSystem.Origin.ToString());
				editor.WriteMessage("\nFirst basis vector : " + boundingBox.CoordinateSystem.BasisVector[0].ToString());
				editor.WriteMessage("\nSecond basis vector: " + boundingBox.CoordinateSystem.BasisVector[1].ToString());
				editor.WriteMessage("\nThird basis vector : " + boundingBox.CoordinateSystem.BasisVector[2].ToString());
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		internal PointSet method_0(ObjectId[] objectId_0, double double_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(objectId_0.Length);
			if (objectId_0.Length > 1)
			{
				progressMeter.Start("Generating points...");
			}
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			int num = 0;
			PointSet pointSet = new PointSet();
			PointSet result;
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					List<Entity> list = new List<Entity>();
					for (int i = 0; i < objectId_0.Length; i++)
					{
                        list.Add((Entity)transaction.GetObject(objectId_0[i], (OpenMode)0));
					}
					Mesh2dControl mesh2dControl = new Mesh2dControl();
					mesh2dControl.MaxNodeSpacing=(double_0);
					mesh2dControl.ElementShape=(0);
					for (int j = 0; j < objectId_0.Length; j++)
					{
						Brep brep = new Brep(list[j]);
						Mesh2dFilter mesh2dFilter = new Mesh2dFilter();
						mesh2dFilter.Insert(brep, mesh2dControl);
						Mesh2d mesh2d = new Mesh2d(mesh2dFilter);
						using (Mesh2dElement2dEnumerator enumerator = mesh2d.Element2ds.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
                                Element2d current = enumerator.Current;
								messageFilter.CheckMessageFilter((long)num, 100);
								num++;
								using (Element2dNodeEnumerator enumerator2 = current.Nodes.GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										Node current2 = enumerator2.Current;
										pointSet.Add(new Point(current2.Point.X, current2.Point.Y, current2.Point.Z));
										current2.Dispose();
									}
								}
								current.Dispose();
							}
						}
						progressMeter.MeterProgress();
					}
					pointSet.RemoveMultiplePoints3d();
				}
				progressMeter.Stop();
				result = pointSet;
			}
			catch
			{
				progressMeter.Stop();
				throw;
			}
			return result;
		}

		internal double method_1(ObjectId[] objectId_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			double num = 0.0;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable arg_2F_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0, false);
				for (int i = 0; i < objectId_0.Length; i++)
				{
                    Solid3d solid3d = transaction.GetObject(objectId_0[i], (OpenMode)0) as Solid3d;
					if (!(solid3d == null))
					{
						num = Math.Max(num, solid3d.GeometricExtents.MinPoint.GetVectorTo(solid3d.GeometricExtents.MaxPoint).Length);
					}
				}
			}
			return num;
		}

		internal static void smethod_0(DBObjectCollection dbobjectCollection_0, ref DBObjectCollection dbobjectCollection_1)
		{
			Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			foreach (DBObject dBObject in dbobjectCollection_0)
			{
				Entity entity = (Entity)dBObject;
				DBObjectCollection dBObjectCollection = new DBObjectCollection();
				try
				{
					entity.Explode(dBObjectCollection);
					Tesselation.smethod_0(dBObjectCollection, ref dbobjectCollection_1);
				}
				catch
				{
					dbobjectCollection_1.Add(dBObject);
				}
				finally
				{
					dBObject.Dispose();
				}
			}
		}

		[CommandMethod("TCPlugin", "ng:SOLIDS:TESSELATE", 0)]
		public void TesselateCommand()
		{
			Database arg_05_0 = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.SOLID3D, "Select 3d solids", false);
				double num = this.method_1(objectIDs);
				PromptDoubleOptions promptDoubleOptions = new PromptDoubleOptions("Maximum node spacing");
				promptDoubleOptions.DefaultValue=(num / 100.0);
				double value = editor.GetDouble(promptDoubleOptions).Value;
				PointSet pointSet = this.method_0(objectIDs, value);
				editor.WriteMessage("\n" + pointSet.Count + " points generated on solids.");
				DBManager.WriteListInDatabase<Point>(pointSet.ToList(), null, DBManager.EntityPropertiesAssignment.ByDialog, ObjectId.Null, ObjectId.Null);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}
	}
}
