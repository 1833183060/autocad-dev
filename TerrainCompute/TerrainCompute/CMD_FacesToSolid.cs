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
	public class CMD_FacesToSolid
	{
		static CMD_FacesToSolid()
		{
			CMD_FacesToSolid.string_0 = "Y";
			CMD_FacesToSolid.double_0 = -1.0;
			CMD_FacesToSolid.string_1 = "W";
			CMD_FacesToSolid.string_2 = "0.01";
		}

		public CMD_FacesToSolid()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_FacesToSolid));
			//base..ctor();
		}

		[CommandMethod("TCPlugin", "ng:FACES:TOSOLID", 0)]
		public void GenerateSolidCommand()
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
				CMD_FacesToSolid.string_1 = CommandLineQuerries.SpecifyReferencePlane(CMD_FacesToSolid.string_1);
				CoordinateSystem coordinateSystem = CoordinateSystem.Global();
				if (CMD_FacesToSolid.string_1 == "U")
				{
					coordinateSystem = Conversions.GetUCS();
				}
				if (CMD_FacesToSolid.string_1 == "3P")
				{
					coordinateSystem = CommandLineQuerries.Specify3PSystem();
				}
				coordinateSystem.Orthonormalize();
				CMD_FacesToSolid.double_0 = CommandLineQuerries.SpecifyDouble("Extrusion height in actual Z", CMD_FacesToSolid.double_0, false, true, false, false);
				bool flag = false;
				while (!flag)
				{
					CMD_FacesToSolid.string_2 = CommandLineQuerries.SpecifyString("Minimum projected edge length", CMD_FacesToSolid.string_2, false);
					if (Convert.ToDouble(CMD_FacesToSolid.string_2) >= 0.0001 && Convert.ToDouble(CMD_FacesToSolid.string_2) <= 1.0)
					{
						flag = true;
					}
					else
					{
						editor.WriteMessage("\nValue must be between 0.0001 and 1.");
					}
				}
				CMD_FacesToSolid.string_0 = CommandLineQuerries.KeywordYesNo("Union solids", CMD_FacesToSolid.string_0, false, false).ToUpper().Trim();
				this.method_0(objectId_, progressMeter, coordinateSystem);
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private void method_0(ObjectId[] objectId_0, ProgressMeter progressMeter_0, CoordinateSystem coordinateSystem_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<Solid3d> list = new List<Solid3d>();
			double epsilon = Convert.ToDouble(CMD_FacesToSolid.string_2);
			bool flag = true;
			if (CMD_FacesToSolid.string_0 == "N")
			{
				flag = false;
			}
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
				k = subDMeshHandler.HealXY(epsilon);
				num += k;
			}
			editor.WriteMessage("\nDegenerate projections healed: " + num);
			Autodesk.AutoCAD.Geometry.Matrix3d matrix3d = Autodesk.AutoCAD.Geometry.Matrix3d.Scaling(num7, new Point3d(0.0, 0.0, 0.0));
			Autodesk.AutoCAD.Geometry.Matrix3d matrix3d2 = Autodesk.AutoCAD.Geometry.Matrix3d.Scaling(1.0 / num7, new Point3d(0.0, 0.0, 0.0));
			Autodesk.AutoCAD.Geometry.Matrix3d matrix3d3 = Autodesk.AutoCAD.Geometry.Matrix3d.Displacement(new Autodesk.AutoCAD.Geometry.Vector3d(vector3d.X, vector3d.Y, 0.0));
			progressMeter_0 = new ProgressMeter();
			progressMeter_0.SetLimit(objectId_0.Length);
			progressMeter_0.Start("Extruding objects");
			int num8 = 0;
			int num9 = 0;
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
				try
				{
					Face face = new Face(new Point3d(subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex1[l]].X, subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex1[l]].Y, subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex1[l]].Z), new Point3d(subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex2[l]].X, subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex2[l]].Y, subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex2[l]].Z), new Point3d(subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex3[l]].X, subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex3[l]].Y, subDMeshHandler.Vertices[subDMeshHandler.FaceVertexIndex3[l]].Z), false, false, false, false);
					double z = face.GetVertexAt(0).Z;
					double z2 = face.GetVertexAt(1).Z;
					double z3 = face.GetVertexAt(2).Z;
					short num10;
					if (CMD_FacesToSolid.double_0 < 0.0)
					{
						if (z <= z2 && z <= z3)
						{
							num10 = 0;
						}
						else if (z2 <= z && z2 <= z3)
						{
							num10 = 1;
						}
						else
						{
							num10 = 2;
						}
					}
					else if (z >= z2 && z >= z3)
					{
						num10 = 0;
					}
					else if (z2 >= z && z2 >= z3)
					{
						num10 = 1;
					}
					else
					{
						num10 = 2;
					}
					Point3d vertexAt = face.GetVertexAt(num10);
					Point3d point3d=new Point3d(vertexAt.X, vertexAt.Y, vertexAt.Z + CMD_FacesToSolid.double_0);
					//point3d..ctor(vertexAt.X, vertexAt.Y, vertexAt.Z + CMD_FacesToSolid.double_0);
					Autodesk.AutoCAD.DatabaseServices.Line line = new Autodesk.AutoCAD.DatabaseServices.Line(vertexAt, point3d);
					Region region = this.method_2(subDMeshHandler, l);
					if (region == null)
					{
						num8++;
					}
					else
					{
						region.TransformBy(matrix3d);
						line.TransformBy(matrix3d);
						try
						{
							Solid3d solid3d = new Solid3d();
							solid3d.ExtrudeAlongPath(region, line, 0.0);
							solid3d.SetPropertiesFrom(face);
							list.Add(solid3d);
						}
                        catch (System.Exception ex)
						{
							num9++;
						}
						line.Dispose();
						region.Dispose();
					}
				}
                catch (System.Exception ex)
				{
				}
			}
			editor.WriteMessage("\nNumber of failed projections: " + num8.ToString());
			editor.WriteMessage("\nNumber of failed extrusions : " + num8.ToString());
			progressMeter_0.Stop();
			if (flag && list.Count > 1)
			{
				progressMeter_0 = new ProgressMeter();
				int limit = (int)Math.Ceiling(Math.Log((double)list.Count) / Math.Log(2.0));
				progressMeter_0.SetLimit(limit);
				progressMeter_0.Start("Building solid");
				this.method_1(ref list, ref progressMeter_0);
			}
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)1);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],  (OpenMode)1);
				for (int n = 0; n < list.Count; n++)
				{
					list[n].TransformBy(matrix3d2);
					list[n].TransformBy(matrix3d3);
					CoordinateTransformator coordinateTransformator = new CoordinateTransformator(coordinateSystem_0, CoordinateSystem.Global());
					if (!coordinateTransformator.bool_0)
					{
						list[n].TransformBy(coordinateTransformator.ToAcadTransformation());
					}
					blockTableRecord.AppendEntity(list[n]);
					transaction.AddNewlyCreatedDBObject(list[n], true);
				}
				transaction.Commit();
			}
			progressMeter_0.Stop();
		}

		private void method_1(ref List<Solid3d> list_0, ref ProgressMeter progressMeter_0)
		{
			if (list_0.Count == 1)
			{
				return;
			}
			if (progressMeter_0 != null)
			{
				progressMeter_0.MeterProgress();
			}
			List<Solid3d> list = new List<Solid3d>();
			int num = 0;
			bool flag = true;
			while (flag)
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
				flag = false;
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
					using (Face face = new Face(new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].Y, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].Z), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].Y, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].Z), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].Y, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].Z), false, false, false, false))
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
							using (Face face2 = new Face(new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].Y, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex1[int_0]].Z), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].Y, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex2[int_0]].Z), new Point3d(subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].X, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].Y, subDMeshHandler_0.Vertices[subDMeshHandler_0.FaceVertexIndex3[int_0]].Z), false, false, false, false))
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
                    catch (System.Exception ex111)
					{
					}
				}
				result = null;
			}
			return result;
		}

		private static double double_0;

		private MessageFilter messageFilter_0;

		private static string string_0;

		private static string string_1;

		private static string string_2;
	}
}
