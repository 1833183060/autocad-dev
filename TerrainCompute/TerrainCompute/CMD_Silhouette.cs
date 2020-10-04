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

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class CMD_Silhouette
	{
		static CMD_Silhouette()
		{
			CMD_Silhouette.string_0 = "W";
			CMD_Silhouette.string_1 = "0.001";
		}

		public CMD_Silhouette()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_Silhouette));
			//base..ctor();
		}

		[CommandMethod("TCPlugin", "ng:FACES:SILHOUETTE", 0)]
		public void GenerateRegionCommand()
		{
			ProgressMeter progressMeter = new ProgressMeter();
			Database arg_0B_0 = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			this.messageFilter_0 = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(this.messageFilter_0);
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectFaces(false);
				CMD_Silhouette.string_0 = CommandLineQuerries.SpecifyReferencePlane(CMD_Silhouette.string_0);
				CoordinateSystem coordinateSystem = CoordinateSystem.Global();
				if (CMD_Silhouette.string_0 == "U")
				{
					coordinateSystem = Conversions.GetUCS();
				}
				if (CMD_Silhouette.string_0 == "3P")
				{
					coordinateSystem = CommandLineQuerries.Specify3PSystem();
				}
				coordinateSystem.Orthonormalize();
				bool flag = false;
				while (!flag)
				{
					CMD_Silhouette.string_1 = CommandLineQuerries.SpecifyString("Minimum projected edge length", CMD_Silhouette.string_1, false);
					if (Convert.ToDouble(CMD_Silhouette.string_1) >= 0.0001 && Convert.ToDouble(CMD_Silhouette.string_1) <= 1.0)
					{
						flag = true;
					}
					else
					{
						editor.WriteMessage("\nValue must be between 0.0001 and 1.");
					}
				}
				this.method_0(objectId_, ref progressMeter, coordinateSystem);
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private void method_0(ObjectId[] objectId_0, ref ProgressMeter progressMeter_0, CoordinateSystem coordinateSystem_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<Region> list = new List<Region>();
			double epsilon = Convert.ToDouble(CMD_Silhouette.string_1);
			DBManager.SetEpsilon();
			List<Triangle> list2 = Conversions.ToCeometricAcDbTriangleList(objectId_0);
			if (!Conversions.IsWCS(coordinateSystem_0))
			{
				Triangle.TransformCoordinates(list2, CoordinateSystem.Global(), coordinateSystem_0);
			}
			list2.Sort(new Triangle.CompareMinX());
			int num = 0;
			double num2 = -1.7976931348623157E+308;
			double num3 = -1.7976931348623157E+308;
			double num4 = 1.7976931348623157E+308;
			double num5 = 1.7976931348623157E+308;
			for (int i = list2.Count - 1; i >= 0; i--)
			{
                if (list2[i].NormalVector.IsOrthogonalTo(new ngeometry.VectorGeometry.Vector3d(0.0, 0.0, 1.0)))
				{
					list2.RemoveAt(i);
					num++;
				}
				else
				{
					Global.SuspendEpsilon(0.0, 0.0);
					list2[i].Vertex1.Z = 0.0;
					list2[i].Vertex2.Z = 0.0;
					list2[i].Vertex3.Z = 0.0;
					Global.ResumeEpsilon();
					double minimumX = list2[i].MinimumX;
					if (minimumX < num4)
					{
						num4 = minimumX;
					}
					double maximumX = list2[i].MaximumX;
					if (maximumX > num2)
					{
						num2 = maximumX;
					}
					double minimumY = list2[i].MinimumY;
					if (minimumY < num5)
					{
						num5 = minimumY;
					}
					double maximumY = list2[i].MaximumY;
					if (maximumY > num3)
					{
						num3 = maximumY;
					}
				}
			}
            ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(0.5 * (num4 + num2), 0.5 * (num5 + num3), 0.0);
			double num6 = 0.5 * Math.Max(Math.Abs(num2 - num4), Math.Abs(num3 - num5));
			double num7 = Math.Ceiling(100000.0 / num6);
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j] = list2[j].Move(-1.0 * vector3d);
			}
			SubDMeshHandler subDMeshHandler = new SubDMeshHandler(list2);
			subDMeshHandler.BuildDataStructure(false);
			int k = 2147483647;
			while (k > 0)
			{
				this.messageFilter_0.CheckMessageFilter();
				k = subDMeshHandler.Heal(epsilon);
				num += k;
			}
			editor.WriteMessage("\nDegenerate projections healed: " + num);
            Autodesk.AutoCAD.Geometry.Matrix3d matrix3d = Autodesk.AutoCAD.Geometry.Matrix3d.Scaling(num7, new Point3d(0.0, 0.0, 0.0));
            Autodesk.AutoCAD.Geometry.Matrix3d matrix3d2 = Autodesk.AutoCAD.Geometry.Matrix3d.Scaling(1.0 / num7, new Point3d(0.0, 0.0, 0.0));
            Autodesk.AutoCAD.Geometry.Matrix3d matrix3d3 = Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(new Autodesk.AutoCAD.Geometry.Vector3d(vector3d.X, vector3d.Y, 0.0));
			progressMeter_0 = new ProgressMeter();
			progressMeter_0.SetLimit(subDMeshHandler.FaceVertexIndex1.Count);
			progressMeter_0.Start("Generating projections");
			int num8 = 0;
			for (int l = 0; l < subDMeshHandler.FaceVertexIndex1.Count; l++)
			{
				try
				{
					progressMeter_0.MeterProgress();
					this.messageFilter_0.CheckMessageFilter((long)l, 1000);
				}
                catch (System.Exception ex)
				{
					for (int m = 0; m < list.Count; m++)
					{
						list[m].Dispose();
					}
					progressMeter_0.Stop();
					throw;
				}
				Region region = this.method_2(subDMeshHandler, l);
				if (region == null)
				{
					num8++;
				}
				else
				{
					region.TransformBy(matrix3d);
					list.Add(region);
				}
			}
			editor.WriteMessage("\nNumber of failed projections: " + num8.ToString());
			progressMeter_0.Stop();
			progressMeter_0 = new ProgressMeter();
			int limit = (int)Math.Ceiling(Math.Log((double)list.Count) / Math.Log(2.0));
			progressMeter_0.SetLimit(limit);
			progressMeter_0.Start("Computing silhouette");
			if (list.Count > 1)
			{
				this.method_1(ref list, ref progressMeter_0);
			}
			list[0].TransformBy(matrix3d2);
			list[0].TransformBy(matrix3d3);
			CoordinateTransformator coordinateTransformator = new CoordinateTransformator(coordinateSystem_0, CoordinateSystem.Global());
			if (!coordinateTransformator.bool_0)
			{
				list[0].TransformBy(coordinateTransformator.ToAcadTransformation());
			}
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
				blockTableRecord.AppendEntity(list[0]);
				transaction.AddNewlyCreatedDBObject(list[0], true);
				transaction.Commit();
			}
			progressMeter_0.Stop();
		}

		private void method_1(ref List<Region> list_0, ref ProgressMeter progressMeter_0)
		{
			if (list_0.Count == 1)
			{
				return;
			}
			if (progressMeter_0 != null)
			{
				progressMeter_0.MeterProgress();
			}
			List<Region> list = new List<Region>();
			int num = 0;
			bool flag = false;
			while (!flag)
			{
				try
				{
					this.messageFilter_0.CheckMessageFilter((long)num, 1000);
				}
                catch (System.Exception ex)
				{
					for (int i = 0; i < list_0.Count; i++)
					{
						list_0[i].Dispose();
					}
					for (int j = 0; j < list.Count; j++)
					{
						list[j].Dispose();
					}
					throw;
				}
				try
				{
					list_0[num].BooleanOperation(0, list_0[num + 1]);
					list.Add(list_0[num]);
					goto IL_E1;
				}
                catch (System.Exception ex)
				{
					goto IL_E1;
				}
				IL_AF:
				if (num == list_0.Count - 1)
				{
					list.Add(list_0[list_0.Count - 1]);
				}
				this.method_1(ref list, ref progressMeter_0);
				flag = true;
				continue;
				IL_E1:
				num += 2;
				if (num >= list_0.Count - 1)
				{
					goto IL_AF;
				}
			}
		}

		private Region method_2(SubDMeshHandler subDMeshHandler_0, int int_0)
		{
			Region result;
			try
			{
				using (DBObjectCollection dBObjectCollection = new DBObjectCollection())
				{
					using (Face face = new Face(new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].Y, 0.0), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].Y, 0.0), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].Y, 0.0), false, false, false, false))
					{
						dBObjectCollection.Add(face);
						Region region = Region.CreateFromCurves(dBObjectCollection)[0] as Region;
						result = region;
					}
				}
			}
            catch (System.Exception ex)
			{
				for (double num = 0.001; num <= 1000.0; num *= 10.0)
				{
					try
					{
						using (DBObjectCollection dBObjectCollection2 = new DBObjectCollection())
						{
							using (Face face2 = new Face(new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].Y, 0.0), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].Y, 0.0), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].Y, 0.0), false, false, false, false))
							{
                                Autodesk.AutoCAD.Geometry.Matrix3d matrix3d = Autodesk.AutoCAD.Geometry.Matrix3d.Scaling(num, new Point3d(0.0, 0.0, 0.0));
                                Autodesk.AutoCAD.Geometry.Matrix3d matrix3d2 = Autodesk.AutoCAD.Geometry.Matrix3d.Scaling(1.0 / num, new Point3d(0.0, 0.0, 0.0));
								face2.TransformBy(matrix3d);
								dBObjectCollection2.Add(face2);
								Region region2 = Region.CreateFromCurves(dBObjectCollection2)[0] as Region;
								region2.TransformBy(matrix3d2);
								result = region2;
								return result;
							}
						}
					}
                    catch (System.Exception ex11)
					{
					}
				}
				result = null;
			}
			return result;
		}

		private MessageFilter messageFilter_0;

		private static string string_0;

		private static string string_1;
	}
}
