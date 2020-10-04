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

namespace TerrainComputeC.HULL
{
	
	public class CMD_PABoundingBox
	{
		public CMD_PABoundingBox()
		{
            
		}

		public void ComputePrincipalAxisBoundingBox(ObjectId[] idArray)
		{
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			DBManager.SetEpsilon();
			this.progressMeter_0 = new ProgressMeter();
			this.messageFilter_0 = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(this.messageFilter_0);
			this.int_0 = 0;
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					this.progressMeter_0.SetLimit(3 * idArray.Length);
					if ((double)idArray.Length > 10000.0)
					{
						this.progressMeter_0.Start("Computing bounding box...");
					}
					BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)1);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],  (OpenMode)1);
					ObjectId layerId = DBManager.CurrentLayerId();
					DBManager.CurrentLayerName();
					PointSet pointSet = new PointSet();
					for (int i = 0; i < idArray.Length; i++)
					{
						DBPoint dBPoint = (DBPoint)transaction.GetObject(idArray[i],  (OpenMode)0, true);
						Point point = new Point(dBPoint.Position.X, dBPoint.Position.Y, dBPoint.Position.Z);
						pointSet.Add(point);
						this.vmethod_0(null, null);
					}
					ConvexHull3d convexHull3d = new ConvexHull3d();
					convexHull3d.PointInsertionHandler += new HullPointInsertionEventHandler(this.vmethod_0);
					convexHull3d.InitialPoints = pointSet;
					convexHull3d.ComputeHull();
					BoundingBox boundingBox = convexHull3d.PrincipalAxesBoundingBox();
					List<Triangle> surface = boundingBox.GetSurface();
					for (int j = 0; j < surface.Count; j++)
					{
						Point vertex = surface[j].Vertex1;
						Point vertex2 = surface[j].Vertex2;
						Point vertex3 = surface[j].Vertex3;
						Point3d point3d=new Point3d(vertex.X, vertex.Y, vertex.Z);
						Point3d point3d2=new Point3d(vertex2.X, vertex2.Y, vertex2.Z);
						Point3d point3d3=new Point3d(vertex3.X, vertex3.Y, vertex3.Z);
						Face face = new Face(point3d, point3d2, point3d3, true, true, true, true);
						face.LayerId=(layerId);
						blockTableRecord.AppendEntity(face);
						transaction.AddNewlyCreatedDBObject(face, true);
					}
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
					transaction.Commit();
				}
				this.progressMeter_0.Stop();
			}
            catch (System.Exception ex)
			{
				this.progressMeter_0.Stop();
				throw;
			}
		}

		[CommandMethod("TCPlugin", "ng:HULL:PABB", 0)]
		public void Hull3dCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] idArray = CommandLineQuerries.SelectPoints(false);
				this.ComputePrincipalAxisBoundingBox(idArray);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		internal virtual void vmethod_0(object sender, EventArgs e)
		{
			this.messageFilter_0.CheckMessageFilter((long)this.int_0, 1000);
			this.progressMeter_0.MeterProgress();
			this.int_0++;
		}

		private int int_0;

		private MessageFilter messageFilter_0;

		private ProgressMeter progressMeter_0;
	}
}
