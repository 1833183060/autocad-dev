using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 标注
	{
		[DebuggerNonUserCode]
		public 标注()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcJMXX")]
		public void TcJMXX()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_1E:
				num2 = 4;
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Polyline polyline = (Polyline)transaction.GetObject(objectId, 0);
							Point3d centroid = this.GetCentroid(polyline);
							Entity entity = CAD.AddLine(CAD.GetPointXY(centroid, 0.0, -150.0), CAD.GetPointXY(centroid, 0.0, 150.0), "0");
							entity.Layer = polyline.Layer;
							Entity entity2 = CAD.AddLine(CAD.GetPointXY(centroid, -150.0, 0.0), CAD.GetPointXY(centroid, 150.0, 0.0), "0");
							entity2.Layer = polyline.Layer;
						}
					}
					transaction.Commit();
				}
				IL_187:
				goto IL_1F3;
				IL_189:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1AD:
				goto IL_1E8;
				IL_1AF:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_189;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1C5:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1AF;
			}
			IL_1E8:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1F3:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcJMXX2")]
		public void TcJMXX2()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_1E:
				num2 = 4;
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Polyline polyline = (Polyline)transaction.GetObject(objectId, 0);
							Point3d centroid = this.GetCentroid(polyline);
							Entity entity = CAD.AddLine(CAD.GetPointXY(centroid, 0.0, -150.0), CAD.GetPointXY(centroid, 0.0, 150.0), "0");
							entity.Layer = polyline.Layer;
							Entity entity2 = CAD.AddLine(CAD.GetPointXY(centroid, -150.0, 0.0), CAD.GetPointXY(centroid, 150.0, 0.0), "0");
							entity2.Layer = polyline.Layer;
						}
					}
					transaction.Commit();
				}
				IL_187:
				goto IL_1F3;
				IL_189:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1AD:
				goto IL_1E8;
				IL_1AF:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_189;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1C5:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1AF;
			}
			IL_1E8:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1F3:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcJMXX1")]
		public void TcJMXX1()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_1E:
				num2 = 4;
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Polyline pl = (Polyline)transaction.GetObject(objectId, 0);
							Point3d centroid = this.GetCentroid(pl);
							CAD.AddPoint(centroid);
						}
					}
					transaction.Commit();
				}
				IL_EE:
				goto IL_15A;
				IL_F0:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_114:
				goto IL_14F;
				IL_116:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_F0;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_12C:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_116;
			}
			IL_14F:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_15A:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public Point3d GetCentroid(Polyline pl)
		{
			Point2d point2dAt = pl.GetPoint2dAt(0);
			Point2d point2d;
			point2d..ctor(0.0, 0.0);
			double num = 0.0;
			double bulgeAt = pl.GetBulgeAt(0);
			int num2;
			Vector2d vector2d;
			checked
			{
				num2 = pl.NumberOfVertices - 1;
				if (bulgeAt != 0.0)
				{
					double[] arcGeom = this.GetArcGeom(pl, bulgeAt, 0, 1);
					num = arcGeom[0];
					Point2d point2d2;
					point2d2..ctor(arcGeom[1], arcGeom[2]);
					point2d = point2d2 * arcGeom[0];
				}
				int i = 1;
				while (i < num2)
				{
					double num3 = this.TriangleAlgebricArea(point2dAt, pl.GetPoint2dAt(i), pl.GetPoint2dAt(i + 1));
					Point2d point2d3 = this.TriangleCentroid(point2dAt, pl.GetPoint2dAt(i), pl.GetPoint2dAt(i + 1));
					Point2d point2d4 = point2d;
					Point2d point2d2 = point2d3 * num3;
					point2d = point2d4 + point2d2.GetAsVector();
					unchecked
					{
						num += num3;
						bulgeAt = pl.GetBulgeAt(i);
						if (bulgeAt != 0.0)
						{
							double[] arcGeom2 = this.GetArcGeom(pl, bulgeAt, i, checked(i + 1));
							num += arcGeom2[0];
							Point2d point2d5 = point2d;
							vector2d..ctor(arcGeom2[1], arcGeom2[2]);
							point2d = point2d5 + vector2d * arcGeom2[0];
						}
					}
					Math.Max(Interlocked.Increment(ref i), i - 1);
				}
				bulgeAt = pl.GetBulgeAt(num2);
			}
			if (bulgeAt != 0.0)
			{
				double[] arcGeom3 = this.GetArcGeom(pl, bulgeAt, num2, 0);
				num += arcGeom3[0];
				Point2d point2d6 = point2d;
				vector2d..ctor(arcGeom3[1], arcGeom3[2]);
				point2d = point2d6 + vector2d * arcGeom3[0];
			}
			point2d = point2d.DivideBy(num);
			Point3d point3d;
			point3d..ctor(point2d.X, point2d.Y, pl.Elevation);
			return point3d.TransformBy(Matrix3d.PlaneToWorld(pl.Normal));
		}

		public double[] GetArcGeom(Polyline pl, double bulge, int index1, int index2)
		{
			CircularArc2d arcSegment2dAt = pl.GetArcSegment2dAt(index1);
			double radius = arcSegment2dAt.Radius;
			Point2d center = arcSegment2dAt.Center;
			double ang = 4.0 * Math.Atan(bulge);
			double num = this.ArcAlgebricArea(radius, ang);
			Point2d point2d = this.ArcCentroid(pl.GetPoint2dAt(index1), pl.GetPoint2dAt(index2), center, num);
			double[] array = null;
			array.SetValue(num, 0);
			array.SetValue(point2d.X, 1);
			array.SetValue(point2d.Y, 2);
			return array;
		}

		public Point2d TriangleCentroid(Point2d p0, Point2d p1, Point2d p2)
		{
			return (p0 + p1.GetAsVector() + p2.GetAsVector()) / 3.0;
		}

		public double TriangleAlgebricArea(Point2d p0, Point2d p1, Point2d p2)
		{
			return ((p1.X - p0.X) * (p2.Y - p0.Y) - (p2.X - p0.X) * (p1.Y - p0.Y)) / 2.0;
		}

		public Point2d ArcCentroid(Point2d start, Point2d end, Point2d cen, double tmpArea)
		{
			double distanceTo = start.GetDistanceTo(end);
			double num = this.AngleFromTo(start, end);
			return this.Polar2d(cen, num - 1.5707963267948966, distanceTo * distanceTo * distanceTo / (12.0 * tmpArea));
		}

		public double ArcAlgebricArea(double rad, double ang)
		{
			return rad * rad * (ang - Math.Sin(ang)) / 2.0;
		}

		public double AngleFromTo(Point2d p1, Point2d p2)
		{
			return (p2 - p1).Angle;
		}

		public Point2d Polar2d(Point2d org, double angle, double distance)
		{
			Point2d point2d;
			point2d..ctor(org.X + distance, org.Y);
			Point2d point2d2 = point2d;
			return point2d2.RotateBy(angle, org);
		}

		[CommandMethod("TcBanHou")]
		public void TcBanHou()
		{
			int num;
			int num4;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				short num2 = Conversions.ToShort(Interaction.InputBox("输入板厚，默认100mm", "ByCAD工具箱.Net版", Conversions.ToString(100), -1, -1));
				if (Operators.CompareString(num2.ToString(), "0", false) == 0)
				{
					goto IL_21F;
				}
				CAD.CreateLayer("板厚标注", 2, "continuous", -3, false, true);
				short num3;
				do
				{
					Point3d point3d;
					point3d..ctor(0.0, 0.0, 0.0);
					ObjectId[] array = new ObjectId[2];
					Point3d point3d2 = point3d;
					Vector3d vector3d;
					vector3d..ctor(0.0, 0.0, 80.0);
					Vector3d vector3d2 = vector3d;
					Vector3d vector3d3;
					vector3d3..ctor(400.0, 0.0, 0.0);
					Ellipse ellipse = new Ellipse(point3d2, vector3d2, vector3d3, 0.5, 0.0, 0.0);
					ellipse.SetDatabaseDefaults();
					ellipse.Layer = "板厚标注";
					array[0] = CAD.AddEnt(ellipse).ObjectId;
					DBText dbtext = new DBText();
					dbtext.SetDatabaseDefaults();
					dbtext.Position = point3d;
					dbtext.HorizontalMode = 1;
					dbtext.VerticalMode = 2;
					dbtext.AlignmentPoint = point3d;
					dbtext.Height = 250.0;
					dbtext.WidthFactor = 0.7;
					dbtext.TextString = num2.ToString();
					dbtext.Layer = "板厚标注";
					array[1] = CAD.AddEnt(dbtext).ObjectId;
					JigEntIDs jigEntIDs = new JigEntIDs();
					JigEntIDs jigEntIDs2 = jigEntIDs;
					ObjectId[] entIDs = array;
					Point3d basePoint;
					basePoint..ctor(0.0, 0.0, 0.0);
					num3 = jigEntIDs2.method_0(entIDs, basePoint);
				}
				while (num3 != -1);
				IL_1DC:
				goto IL_21F;
				IL_1DE:
				num4 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1F2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1DE;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21F:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZhuBiaoZhu")]
		public void TcZhuBiaoZhu()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				long num3 = 100L;
				IL_15:
				num2 = 3;
				Point3d[] array = new Point3d[4];
				IL_1E:
				num2 = 4;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_2C:
				num2 = 5;
				Database database = mdiActiveDocument.Database;
				IL_37:
				num2 = 6;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array2 = new TypedValue[1];
					Array array3 = array2;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array3.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array2);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						Polyline polyline = (Polyline)transaction.GetObject(value[0].ObjectId, 1);
						array[0] = polyline.GetPoint3dAt(0);
						array[1] = polyline.GetPoint3dAt(1);
						array[2] = polyline.GetPoint3dAt(2);
						array[3] = polyline.GetPoint3dAt(3);
						transaction.Commit();
					}
				}
				IL_124:
				num2 = 8;
				Point3d point = CAD.GetPoint("选择轴线交叉点:");
				IL_132:
				num2 = 9;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_145;
				}
				IL_140:
				goto IL_75C;
				IL_145:
				num2 = 12;
				Vector3d vectorTo = point.GetVectorTo(array[0]);
				IL_15D:
				num2 = 13;
				Vector3d vectorTo2 = point.GetVectorTo(array[1]);
				IL_175:
				num2 = 14;
				Vector3d vectorTo3 = point.GetVectorTo(array[2]);
				IL_18D:
				num2 = 15;
				Vector3d vectorTo4 = point.GetVectorTo(array[3]);
				IL_1A5:
				num2 = 16;
				Vector3d vector3d;
				vector3d..ctor(1.0, 0.0, 0.0);
				IL_1CA:
				num2 = 17;
				double[] array4 = new double[4];
				IL_1D5:
				num2 = 18;
				array4[0] = Class36.smethod_27(vectorTo) * 180.0 / 3.1415926535897931;
				IL_1F7:
				num2 = 19;
				array4[1] = Class36.smethod_27(vectorTo2) * 180.0 / 3.1415926535897931;
				IL_219:
				num2 = 20;
				array4[2] = Class36.smethod_27(vectorTo3) * 180.0 / 3.1415926535897931;
				IL_23B:
				num2 = 21;
				array4[3] = Class36.smethod_27(vectorTo4) * 180.0 / 3.1415926535897931;
				IL_25D:
				num2 = 22;
				short num4 = 0;
				do
				{
					IL_302:
					num2 = 23;
					short num5 = 0;
					do
					{
						IL_2DD:
						num2 = 24;
						if (array4[(int)num4] > array4[(int)num5])
						{
							IL_279:
							num2 = 25;
							Point3d point3d2 = array[(int)num4];
							IL_28B:
							num2 = 26;
							array[(int)num4] = array[(int)num5];
							IL_2A8:
							num2 = 27;
							array[(int)num5] = point3d2;
							IL_2BA:
							num2 = 28;
							double num6 = array4[(int)num4];
							IL_2C4:
							num2 = 29;
							array4[(int)num4] = array4[(int)num5];
							IL_2D1:
							num2 = 30;
							array4[(int)num5] = num6;
						}
						IL_268:
						num2 = 32;
						num5 += 1;
					}
					while (num5 <= 3);
					IL_2F3:
					num2 = 33;
					num4 += 1;
				}
				while (num4 <= 3);
				IL_30A:
				num2 = 34;
				ObjectId dimID = Class36.smethod_78("Dim80", 80, 1.0, false);
				IL_325:
				num2 = 35;
				object objectValue = RuntimeHelpers.GetObjectValue(NF.P2LineP(array[0].ToArray(), array[1].ToArray(), point.ToArray()));
				IL_353:
				num2 = 36;
				Point3d point3d3;
				point3d3..ctor(Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					0
				}, null)), Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					1
				}, null)), Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					2
				}, null)));
				IL_3C0:
				num2 = 37;
				double num7 = Class36.smethod_27(array[0].GetVectorTo(array[1])) * 180.0 / 3.1415926535897931;
				IL_3F6:
				num2 = 38;
				CAD.AddLineDim(array[0], point3d3, CAD.GetPointAngle(array[0], 600.0, num7 + 90.0), 100.0 / (double)num3, dimID, -1.0);
				IL_44A:
				num2 = 39;
				CAD.AddLineDim(point3d3, array[1], CAD.GetPointAngle(array[0], 600.0, num7 + 90.0), 100.0 / (double)num3, dimID, -1.0);
				IL_49E:
				num2 = 40;
				objectValue = RuntimeHelpers.GetObjectValue(NF.P2LineP(array[1].ToArray(), array[2].ToArray(), point.ToArray()));
				IL_4CC:
				num2 = 41;
				point3d3..ctor(Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					0
				}, null)), Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					1
				}, null)), Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					2
				}, null)));
				IL_539:
				num2 = 42;
				num7 = Class36.smethod_27(array[1].GetVectorTo(array[2])) * 180.0 / 3.1415926535897931;
				IL_56F:
				num2 = 43;
				CAD.AddLineDim(array[1], point3d3, CAD.GetPointAngle(array[1], 400.0, num7 + 90.0), 100.0 / (double)num3, dimID, -1.0);
				IL_5C3:
				num2 = 44;
				CAD.AddLineDim(point3d3, array[2], CAD.GetPointAngle(array[1], 400.0, num7 + 90.0), 100.0 / (double)num3, dimID, -1.0);
				IL_617:
				num2 = 45;
				if (Information.Err().Number <= 0)
				{
					goto IL_63E;
				}
				IL_629:
				num2 = 46;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_63E:
				goto IL_75C;
				IL_643:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_713:
				goto IL_751;
				IL_715:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_643;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_72E:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_715;
			}
			IL_751:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_75C:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcLTLX")]
		public void TcLTLX()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				PromptPointOptions promptPointOptions = new PromptPointOptions("");
				promptPointOptions.Message = "\n请选择楼梯间其中一个角点: ";
				PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
				if (point.Status == 5100)
				{
					Point3d value = point.Value;
					promptPointOptions.Message = "\n请选择楼梯间另一个对角点: ";
					promptPointOptions.UseBasePoint = true;
					promptPointOptions.BasePoint = value;
					PromptPointResult point2 = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
					if (point2.Status == 5100)
					{
						Point3d value2 = point2.Value;
						Point3d point3d;
						point3d..ctor(value.get_Coordinate(0), value2.get_Coordinate(1), 0.0);
						object obj = point3d;
						point3d..ctor(value2.get_Coordinate(0), value.get_Coordinate(1), 0.0);
						object obj2 = point3d;
						point3d..ctor((value.get_Coordinate(0) + value2.get_Coordinate(0)) / 2.0, (value.get_Coordinate(1) + value2.get_Coordinate(1)) / 2.0, 0.0);
						object obj3 = point3d;
						Line line = new Line(value, value2);
						object obj4 = obj;
						Point3d point3d3;
						Point3d point3d2 = (obj4 != null) ? ((Point3d)obj4) : point3d3;
						object obj5 = obj2;
						Line line2 = new Line(point3d2, (obj5 != null) ? ((Point3d)obj5) : point3d3);
						blockTableRecord.AppendEntity(line);
						blockTableRecord.AppendEntity(line2);
						transaction.AddNewlyCreatedDBObject(line, true);
						transaction.AddNewlyCreatedDBObject(line2, true);
						DBText dbtext = new DBText();
						dbtext.TextString = "楼梯结构另详";
						dbtext.Height = 400.0;
						dbtext.WidthFactor = 0.7;
						dbtext.SetDatabaseDefaults();
						dbtext.HorizontalMode = 1;
						dbtext.VerticalMode = 2;
						DBText dbtext2 = dbtext;
						object obj6 = obj3;
						dbtext2.AlignmentPoint = ((obj6 != null) ? ((Point3d)obj6) : point3d3);
						blockTableRecord.AppendEntity(dbtext);
						transaction.AddNewlyCreatedDBObject(dbtext, true);
						transaction.Commit();
					}
				}
			}
		}

		[CommandMethod("TcLTTD")]
		public void TcLTTD()
		{
			ObjectId[] array = new ObjectId[3];
			Point3d point3d;
			Point3d point3d2;
			Class36.smethod_31(ref point3d, ref point3d2, "选择插入点:");
			Line line = new Line(point3d, point3d2);
			CAD.AddEnt(line);
			array[0] = line.ObjectId;
			DBText dbtext = new DBText();
			dbtext.Height = 150.0;
			dbtext.TextString = "TB-1";
			dbtext.HorizontalMode = 1;
			DBText dbtext2 = dbtext;
			Point3d alignmentPoint;
			alignmentPoint..ctor((point3d.X + point3d2.X) / 2.0, (point3d.Y + point3d2.Y) / 2.0, 0.0);
			dbtext2.AlignmentPoint = alignmentPoint;
			dbtext.WidthFactor = 0.7;
			dbtext.Rotation = CAD.P2P_Angle(point3d, point3d2);
			CAD.AddEnt(dbtext);
			array[1] = dbtext.ObjectId;
			dbtext = new DBText();
			dbtext.Height = 150.0;
			dbtext.Rotation = CAD.P2P_Angle(point3d, point3d2);
			dbtext.TextString = "H=100mm";
			dbtext.HorizontalMode = 1;
			dbtext.VerticalMode = 3;
			DBText dbtext3 = dbtext;
			alignmentPoint..ctor((point3d.X + point3d2.X) / 2.0, (point3d.Y + point3d2.Y) / 2.0, 0.0);
			dbtext3.AlignmentPoint = alignmentPoint;
			dbtext.WidthFactor = 0.7;
			CAD.AddEnt(dbtext);
			array[2] = dbtext.ObjectId;
			Class36.smethod_55(array);
		}

		[CommandMethod("平面索引")]
		public void 平面索引()
		{
			ObjectId[] array = new ObjectId[9];
			Point3d center;
			Point3d point3d;
			Class36.smethod_31(ref center, ref point3d, "选择插入点:");
			array[0] = CAD.AddCircle(center, center.DistanceTo(point3d), "").ObjectId;
			Point3d point3d2;
			Class36.smethod_29(point3d, ref point3d2, "选择下一点: ");
			array[1] = CAD.AddLine(point3d, point3d2, "0").ObjectId;
			Point3d point3d3;
			Class36.smethod_29(point3d2, ref point3d3, "选择下一点: ");
			array[2] = CAD.AddLine(point3d2, point3d3, "0").ObjectId;
			Point3d pointAngle = CAD.GetPointAngle(point3d3, 400.0, 0.0);
			array[3] = CAD.AddCircle(pointAngle, 400.0, "").ObjectId;
			array[4] = CAD.AddLine(point3d3, CAD.GetPointAngle(point3d3, 800.0, 0.0), "0").ObjectId;
			array[5] = Class36.smethod_57("节点详图索引", CAD.GetPointAngle(point3d2, 30.0, 90.0), 300.0, 0, 0, "STANDARD", 0.0);
			array[6] = Class36.smethod_57("图集编号", CAD.GetPointAngle(point3d2, 300.0, -90.0), 300.0, 0, 0, "STANDARD", 0.0);
			array[7] = Class36.smethod_58("1", CAD.GetPointAngle(pointAngle, 200.0, 90.0), 300.0);
			array[8] = Class36.smethod_58("-", CAD.GetPointAngle(pointAngle, 100.0, -90.0), 300.0);
			Class36.smethod_55(array);
		}

		[CommandMethod("剖面索引")]
		public void 剖面索引()
		{
			ObjectId[] array = new ObjectId[10];
			Point3d point3d;
			Point3d point3d2;
			Class36.smethod_31(ref point3d, ref point3d2, "选择插入点:");
			array[0] = CAD.AddLine(point3d, point3d2, "0").ObjectId;
			Polyline polyline = new Polyline();
			polyline.AddVertexAt(0, Class36.smethod_38(CAD.GetPointAngle(point3d, 60.0, CAD.P2P_Angle(point3d, point3d2) * 180.0 / 3.1415926 + 90.0)), 0.0, 45.0, 45.0);
			polyline.AddVertexAt(1, Class36.smethod_38(CAD.GetPointAngle(point3d2, 60.0, CAD.P2P_Angle(point3d, point3d2) * 180.0 / 3.1415926 + 90.0)), 0.0, 45.0, 45.0);
			CAD.AddEnt(polyline);
			array[1] = polyline.ObjectId;
			Point3d point3d3;
			Class36.smethod_29(point3d2, ref point3d3, "选择下一点: ");
			array[2] = CAD.AddLine(point3d2, point3d3, "0").ObjectId;
			Point3d point3d4;
			Class36.smethod_29(point3d3, ref point3d4, "选择下一点: ");
			array[3] = CAD.AddLine(point3d3, point3d4, "0").ObjectId;
			Point3d pointAngle = CAD.GetPointAngle(point3d4, 400.0, 0.0);
			array[4] = CAD.AddCircle(pointAngle, 400.0, "").ObjectId;
			array[5] = CAD.AddLine(point3d4, CAD.GetPointAngle(point3d4, 800.0, 0.0), "0").ObjectId;
			array[6] = Class36.smethod_57("节点详图索引", CAD.GetPointAngle(point3d3, 30.0, 90.0), 300.0, 0, 0, "STANDARD", 0.0);
			array[7] = Class36.smethod_57("图集编号", CAD.GetPointAngle(point3d3, 300.0, -90.0), 300.0, 0, 0, "STANDARD", 0.0);
			array[8] = Class36.smethod_58("1", CAD.GetPointAngle(pointAngle, 200.0, 90.0), 350.0);
			array[9] = Class36.smethod_58("-", CAD.GetPointAngle(pointAngle, 100.0, -90.0), 350.0);
			Class36.smethod_55(array);
		}

		[CommandMethod("多行引注")]
		public void 多行引注()
		{
			Point3d p;
			Point3d pointAngle;
			Class36.smethod_31(ref p, ref pointAngle, "选择插入点:");
			ObjectId[] array = new ObjectId[]
			{
				CAD.AddLine(p, pointAngle, "0").ObjectId
			};
			Class36.smethod_60("Esc键中止");
			checked
			{
				for (;;)
				{
					Point3d point3d;
					short num = Class36.smethod_29(pointAngle, ref point3d, "选择下一点: ");
					if (num <= 0)
					{
						break;
					}
					short num2;
					num2 += 2;
					array = (ObjectId[])Utils.CopyArray((Array)array, new ObjectId[(int)(num2 + 1)]);
					pointAngle = CAD.GetPointAngle(pointAngle, 400.0, -90.0);
					array[(int)(num2 - 1)] = CAD.AddLine(pointAngle, CAD.GetPointAngle(pointAngle, 2000.0, 0.0), "0").ObjectId;
					array[(int)num2] = Class36.smethod_57("XXXXXXXXX", CAD.GetPointAngle(pointAngle, 50.0, 45.0), 300.0, 0, 0, "STANDARD", 0.0);
				}
				Class36.smethod_55(array);
			}
		}

		[CommandMethod("详图编号")]
		public void 详图编号()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string text = Interaction.InputBox("输入详图编号,比如1或1/3", "ByCAD工具箱.Net版本", "1", -1, -1);
				IL_23:
				num2 = 3;
				if (text.Length == 0)
				{
					goto IL_24B;
				}
				IL_37:
				num2 = 4;
				text = text.Replace("\\", "/");
				IL_4C:
				num2 = 5;
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_59:
				num2 = 6;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_6A;
				}
				IL_65:
				goto IL_356;
				IL_6A:
				num2 = 9;
				checked
				{
					short num3 = (short)Strings.InStr(text, "/", CompareMethod.Binary);
					IL_7D:
					num2 = 10;
					ObjectId[] array = new ObjectId[1];
					IL_87:
					num2 = 11;
					if (!(num3 > 0 & (int)num3 < text.Length))
					{
						goto IL_1D5;
					}
					IL_A0:
					num2 = 12;
					array = new ObjectId[4];
					IL_AA:
					num2 = 15;
					array[0] = CAD.AddCircle(point, 500.0, "").ObjectId;
					IL_D2:
					num2 = 16;
					array[1] = CAD.AddLine(CAD.GetPointAngle(point, 500.0, 180.0), CAD.GetPointAngle(point, 500.0, 0.0), "0").ObjectId;
					IL_120:
					num2 = 17;
					array[2] = Class36.smethod_57(text.Substring(0, (int)(num3 - 1)), CAD.GetPointAngle(point, 230.0, 90.0), 400.0, 1, 2, "COMPLEX", 0.0);
					IL_171:
					num2 = 18;
					array[3] = Class36.smethod_57(text.Substring((int)num3, text.Length - (int)num3), CAD.GetPointAngle(point, 200.0, -90.0), 400.0, 1, 2, "COMPLEX", 0.0);
					IL_1C9:
					num2 = 19;
					Class36.smethod_55(array);
					goto IL_24B;
					IL_1D5:
					num2 = 21;
					if (num3 != 0)
					{
						goto IL_24B;
					}
					IL_1DF:
					num2 = 22;
					array = new ObjectId[2];
					IL_1E9:
					num2 = 25;
					array[0] = CAD.AddCircle(point, 500.0, "").ObjectId;
					IL_211:
					num2 = 26;
					array[1] = Class36.smethod_57(text, point, 700.0, 1, 2, "COMPLEX", 0.0);
					IL_241:
					num2 = 27;
					Class36.smethod_55(array);
					IL_24B:
					num2 = 30;
					if (Information.Err().Number <= 0)
					{
						goto IL_272;
					}
					IL_25D:
					num2 = 31;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_272:
					goto IL_356;
					IL_277:
					goto IL_361;
					IL_27C:
					num4 = num2;
					if (num <= -2)
					{
						goto IL_297;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_330;
					IL_297:;
				}
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_330:
				goto IL_361;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_27C;
			}
			IL_356:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_361:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("详图编号1")]
		public void 详图编号1()
		{
			int num;
			int num17;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string text = Interaction.InputBox("输入详图编号,比如1或1/3", "ByCAD工具箱.Net版本", "1", -1, -1);
				IL_22:
				num2 = 3;
				if (text.Length == 0)
				{
					goto IL_3DA;
				}
				IL_35:
				num2 = 4;
				text = text.Replace("\\", "/");
				IL_48:
				num2 = 5;
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_56:
				num2 = 6;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_68;
				}
				IL_63:
				goto IL_51B;
				IL_68:
				num2 = 9;
				short num3 = checked((short)Strings.InStr(text, "/", CompareMethod.Binary));
				IL_7A:
				num2 = 10;
				ObjectId[] array = new ObjectId[1];
				IL_84:
				num2 = 11;
				if (!(num3 > 0 & (int)num3 < text.Length))
				{
					goto IL_29B;
				}
				IL_9C:
				num2 = 12;
				array = new ObjectId[4];
				IL_A6:
				num2 = 15;
				double num4 = Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
				IL_D2:
				num2 = 16;
				Polyline polyline = new Polyline();
				IL_DC:
				num2 = 17;
				double num5 = 500.0;
				IL_EA:
				num2 = 18;
				double num6 = 45.0;
				IL_F8:
				num2 = 19;
				Polyline polyline2 = polyline;
				int num7 = 0;
				Point2d point2d;
				point2d..ctor(point.X, point.Y + num5);
				polyline2.AddVertexAt(num7, point2d, num4, num6, num6);
				IL_123:
				num2 = 20;
				Polyline polyline3 = polyline;
				int num8 = 1;
				point2d..ctor(point.X, point.Y - num5);
				polyline3.AddVertexAt(num8, point2d, num4, num6, num6);
				IL_14E:
				num2 = 21;
				Polyline polyline4 = polyline;
				int num9 = 2;
				point2d..ctor(point.X, point.Y + num5);
				polyline4.AddVertexAt(num9, point2d, num4, num6, num6);
				IL_179:
				num2 = 22;
				array[0] = CAD.AddEnt(polyline).ObjectId;
				IL_194:
				num2 = 23;
				array[1] = CAD.AddLine(CAD.GetPointAngle(point, 500.0, 180.0), CAD.GetPointAngle(point, 500.0, 0.0), "0").ObjectId;
				IL_1E4:
				num2 = 24;
				checked
				{
					array[2] = Class36.smethod_57(text.Substring(0, (int)(num3 - 1)), CAD.GetPointAngle(point, 250.0, 90.0), 400.0, 1, 2, "COMPLEX", 0.0);
					IL_235:
					num2 = 25;
					array[3] = Class36.smethod_57(text.Substring((int)num3, text.Length - (int)num3), CAD.GetPointAngle(point, 220.0, -90.0), 400.0, 1, 2, "COMPLEX", 0.0);
					IL_28C:
					num2 = 26;
					Class36.smethod_55(array);
					goto IL_3DA;
					IL_29B:
					num2 = 28;
					if (num3 != 0)
					{
						goto IL_3DA;
					}
					IL_2A8:
					num2 = 29;
					array = new ObjectId[2];
					IL_2B2:
					num2 = 32;
				}
				double num10 = Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
				IL_2DE:
				num2 = 33;
				Polyline polyline5 = new Polyline();
				IL_2E8:
				num2 = 34;
				double num11 = 500.0;
				IL_2F6:
				num2 = 35;
				double num12 = 45.0;
				IL_304:
				num2 = 36;
				Polyline polyline6 = polyline5;
				int num13 = 0;
				point2d..ctor(point.X, point.Y + num11);
				polyline6.AddVertexAt(num13, point2d, num10, num12, num12);
				IL_32F:
				num2 = 37;
				Polyline polyline7 = polyline5;
				int num14 = 1;
				point2d..ctor(point.X, point.Y - num11);
				polyline7.AddVertexAt(num14, point2d, num10, num12, num12);
				IL_35A:
				num2 = 38;
				Polyline polyline8 = polyline5;
				int num15 = 2;
				point2d..ctor(point.X, point.Y + num11);
				polyline8.AddVertexAt(num15, point2d, num10, num12, num12);
				IL_385:
				num2 = 39;
				array[0] = CAD.AddEnt(polyline5).ObjectId;
				IL_3A0:
				num2 = 40;
				array[1] = Class36.smethod_57(text, point, 700.0, 1, 2, "COMPLEX", 0.0);
				IL_3D0:
				num2 = 41;
				Class36.smethod_55(array);
				IL_3DA:
				num2 = 44;
				if (Information.Err().Number <= 0)
				{
					goto IL_401;
				}
				IL_3EC:
				num2 = 45;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_401:
				goto IL_51B;
				IL_406:
				int num16 = num17 + 1;
				num17 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num16);
				IL_4D2:
				goto IL_510;
				IL_4D4:
				num17 = num2;
				if (num <= -2)
				{
					goto IL_406;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4ED:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num17 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4D4;
			}
			IL_510:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_51B:
			if (num17 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("轴线编号")]
		public void 轴线编号()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string text = Interaction.InputBox("输入轴线编号,比如1或1/3、A或1/A", "ByCAD工具箱.Net版本", "1", -1, -1);
				IL_23:
				num2 = 3;
				if (text.Length == 0)
				{
					goto IL_24B;
				}
				IL_37:
				num2 = 4;
				text = text.Replace("\\", "/");
				IL_4C:
				num2 = 5;
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_59:
				num2 = 6;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_6A;
				}
				IL_65:
				goto IL_361;
				IL_6A:
				num2 = 9;
				checked
				{
					short num3 = (short)Strings.InStr(text, "/", CompareMethod.Binary);
					IL_7D:
					num2 = 10;
					ObjectId[] array = new ObjectId[1];
					IL_87:
					num2 = 11;
					if (!(num3 > 0 & (int)num3 < text.Length))
					{
						goto IL_1D5;
					}
					IL_A0:
					num2 = 12;
					array = new ObjectId[4];
					IL_AA:
					num2 = 15;
					array[0] = CAD.AddCircle(point, 300.0, "").ObjectId;
					IL_D2:
					num2 = 16;
					array[1] = CAD.AddLine(CAD.GetPointAngle(point, 300.0, 180.0), CAD.GetPointAngle(point, 300.0, 0.0), "0").ObjectId;
					IL_120:
					num2 = 17;
					array[2] = Class36.smethod_57(text.Substring(0, (int)(num3 - 1)), CAD.GetPointAngle(point, 130.0, 90.0), 250.0, 1, 2, "COMPLEX", 0.0);
					IL_171:
					num2 = 18;
					array[3] = Class36.smethod_57(text.Substring((int)num3, text.Length - (int)num3), CAD.GetPointAngle(point, 130.0, -90.0), 250.0, 1, 2, "COMPLEX", 0.0);
					IL_1C9:
					num2 = 19;
					Class36.smethod_55(array);
					goto IL_24B;
					IL_1D5:
					num2 = 21;
					if (num3 != 0)
					{
						goto IL_24B;
					}
					IL_1DF:
					num2 = 22;
					array = new ObjectId[2];
					IL_1E9:
					num2 = 25;
					array[0] = CAD.AddCircle(point, 300.0, "").ObjectId;
					IL_211:
					num2 = 26;
					array[1] = Class36.smethod_57(text, point, 400.0, 1, 2, "COMPLEX", 0.0);
					IL_241:
					num2 = 27;
					Class36.smethod_55(array);
					IL_24B:
					num2 = 30;
					if (Information.Err().Number <= 0)
					{
						goto IL_272;
					}
					IL_25D:
					num2 = 31;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_272:
					goto IL_361;
					IL_277:
					goto IL_356;
					IL_27C:
					num4 = num2;
					if (num <= -2)
					{
						goto IL_297;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_330;
					IL_297:;
				}
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_330:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_27C;
			}
			IL_356:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_361:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcTuMing")]
		public void TcTuMing()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double scale = CAD.GetScale();
				IL_12:
				num2 = 3;
				Point3d[] array = new Point3d[2];
				IL_1C:
				num2 = 4;
				string[] array2 = Class36.smethod_84();
				IL_24:
				num2 = 5;
				string text = array2[0];
				IL_2A:
				num2 = 6;
				long num3 = checked((long)Math.Round(Conversion.Val(array2[2])));
				IL_3C:
				num2 = 7;
				if (Operators.CompareString(text, "", false) == 0)
				{
					goto IL_294;
				}
				IL_55:
				num2 = 8;
				array[0] = CAD.GetPoint("选择插入点: ");
				IL_6E:
				num2 = 9;
				Point3d point3d;
				if (!(array[0] == point3d))
				{
					goto IL_8C;
				}
				IL_87:
				goto IL_34D;
				IL_8C:
				num2 = 12;
				array[1] = CAD.GetPointAngle(array[0], (double)(checked(num3 * 8L)) * scale, 0.0);
				IL_C7:
				num2 = 13;
				ObjectId[] array3 = new ObjectId[4];
				IL_D2:
				num2 = 14;
				array3[0] = CAD.AddPline(array, 75.0 * scale, false, "").ObjectId;
				IL_100:
				num2 = 15;
				CAD.ChangeLayer(array3[0], "图名下划线");
				IL_11B:
				num2 = 16;
				array3[1] = CAD.AddLine(CAD.GetPointAngle(array[0], 125.0 * scale, -90.0), CAD.GetPointAngle(array[1], 125.0 * scale, -90.0), "0").ObjectId;
				IL_188:
				num2 = 17;
				CAD.ChangeLayer(array3[1], "图名下划线");
				IL_1A3:
				num2 = 18;
				array3[2] = Class36.smethod_57(text, CAD.GetPointXY(array[0], (double)(checked(num3 * 4L)) * scale, 180.0 * scale), 600.0 * scale, 1, 0, "黑体", 0.0);
				IL_203:
				num2 = 19;
				CAD.ChangeLayer(array3[2], "图名");
				IL_21E:
				num2 = 20;
				array3[3] = Class36.smethod_57(array2[1], CAD.GetPointAngle(array[1], 100.0 * scale, 0.0), 400.0 * scale, 0, 0, "黑体", 0.0);
				IL_279:
				num2 = 21;
				CAD.ChangeLayer(array3[3], "图名比例");
				IL_294:
				goto IL_34D;
				IL_299:
				goto IL_358;
				IL_29E:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_2B6;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_327;
				IL_2B6:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_327:
				goto IL_358;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_29E;
			}
			IL_34D:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_358:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcTuMing1")]
		public void TcTuMing1()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double scale = CAD.GetScale();
				IL_12:
				num2 = 3;
				Point3d[] array = new Point3d[2];
				IL_1B:
				num2 = 4;
				string[] array2 = Class36.smethod_84();
				IL_23:
				num2 = 5;
				string text = array2[0];
				IL_2A:
				num2 = 6;
				long num3 = checked((long)Math.Round(Conversion.Val(array2[2])));
				IL_3C:
				num2 = 7;
				CAD.CreateLayer("图名_OverRule", 0, "continuous", -1, false, true);
				IL_52:
				num2 = 8;
				CAD.CreateLayer("图名", 0, "continuous", -1, false, true);
				IL_68:
				num2 = 9;
				if (Operators.CompareString(text, "", false) == 0)
				{
					goto IL_1ED;
				}
				IL_83:
				num2 = 10;
				array[0] = CAD.GetPoint("选择插入点: ");
				IL_9C:
				num2 = 11;
				Point3d point3d;
				if (!(array[0] == point3d))
				{
					goto IL_B9;
				}
				IL_B4:
				goto IL_29E;
				IL_B9:
				num2 = 14;
				array[1] = CAD.GetPointAngle(array[0], (double)(checked(num3 * 8L)) * scale, 0.0);
				IL_F2:
				num2 = 15;
				ObjectId[] array3 = new ObjectId[2];
				IL_FD:
				num2 = 16;
				array3[0] = Class36.smethod_57(text, CAD.GetPointXY(array[0], (double)(checked(num3 * 4L)) * scale, 180.0 * scale), 600.0 * scale, 1, 0, "黑体", 0.0);
				IL_15D:
				num2 = 17;
				CAD.ChangeLayer(array3[0], "图名_OverRule");
				IL_178:
				num2 = 18;
				array3[1] = Class36.smethod_57(array2[1], CAD.GetPointAngle(array[1], 100.0 * scale, 0.0), 400.0 * scale, 0, 0, "黑体", 0.0);
				IL_1D2:
				num2 = 19;
				CAD.ChangeLayer(array3[1], "图名比例");
				IL_1ED:
				goto IL_29E;
				IL_1F2:
				goto IL_2A9;
				IL_1F7:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_20F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_278;
				IL_20F:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_278:
				goto IL_2A9;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1F7;
			}
			IL_29E:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_2A9:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcQuanZi")]
		public void TcQuanZi()
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				CAD.GetScale();
				IL_11:
				num2 = 3;
				string text = Interaction.InputBox("输入字符:", "ByCAD工具箱-带圈文字1", "1", -1, -1);
				IL_2A:
				num2 = 4;
				CAD.CreateLayer("圈字1_OverRule", 0, "continuous", -1, false, true);
				IL_40:
				num2 = 5;
				CAD.CreateTextStyle("COMPLEX", "COMPLEX.shx", "HZTXT.Shx", 0.7);
				IL_60:
				num2 = 6;
				if (Operators.CompareString(text, "", false) == 0)
				{
					goto IL_F0;
				}
				IL_76:
				num2 = 7;
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_84:
				num2 = 8;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_96;
				}
				IL_91:
				goto IL_191;
				IL_96:
				num2 = 11;
				ObjectId[] array = new ObjectId[2];
				IL_A0:
				num2 = 12;
				array[0] = Class36.smethod_57(text, point, 300.0 * CAD.GetScale(), 1, 2, "COMPLEX", 0.0);
				IL_D6:
				num2 = 13;
				CAD.ChangeLayer(array[0], "圈字1_OverRule");
				IL_F0:
				goto IL_191;
				IL_F5:
				goto IL_186;
				IL_FA:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_112;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_160;
				IL_112:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_160:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_FA;
			}
			IL_186:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_191:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQuanZi2")]
		public void TcQuanZi2()
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				CAD.GetScale();
				IL_11:
				num2 = 3;
				string text = Interaction.InputBox("输入字符:", "田草CAD工具箱-带圈文字2", "1", -1, -1);
				IL_2B:
				num2 = 4;
				CAD.CreateLayer("圈字2_OverRule", 0, "continuous", -1, false, true);
				IL_41:
				num2 = 5;
				CAD.CreateTextStyle("COMPLEX", "COMPLEX.shx", "HZTXT.Shx", 0.7);
				IL_61:
				num2 = 6;
				if (Operators.CompareString(text, "", false) == 0)
				{
					goto IL_F2;
				}
				IL_78:
				num2 = 7;
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_85:
				num2 = 8;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_95;
				}
				IL_90:
				goto IL_188;
				IL_95:
				num2 = 11;
				ObjectId[] array = new ObjectId[2];
				IL_A0:
				num2 = 12;
				array[0] = Class36.smethod_57(text, point, 600.0 * CAD.GetScale(), 1, 2, "COMPLEX", 0.0);
				IL_D7:
				num2 = 13;
				CAD.ChangeLayer(array[0], "圈字2_OverRule");
				IL_F2:
				goto IL_188;
				IL_F7:
				goto IL_193;
				IL_FC:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_114;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_162;
				IL_114:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_162:
				goto IL_193;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_FC;
			}
			IL_188:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_193:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcPL2S")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void method_0()
		{
			int num;
			int num5;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double num3 = Conversion.Val(Interaction.InputBox("输入拉伸高度", Class33.Class31_0.Info.ProductName, "100", -1, -1));
				IL_31:
				num2 = 3;
				if (num3 != 0.0)
				{
					goto IL_46;
				}
				IL_41:
				goto IL_244;
				IL_46:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_53:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_5D:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
							DBObjectCollection dbobjectCollection = new DBObjectCollection();
							dbobjectCollection.Add(entity);
							DBObjectCollection dbobjectCollection2 = Region.CreateFromCurves(dbobjectCollection);
							Region region = (Region)dbobjectCollection2[0];
							Solid3d solid3d = new Solid3d();
							solid3d.Extrude(region, num3, 0.0);
							CAD.AddEnt(solid3d);
							Class36.smethod_64(entity.ObjectId);
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						transaction.Commit();
					}
				}
				IL_18E:
				num2 = 10;
				if (Information.Err().Number <= 0)
				{
					goto IL_1B5;
				}
				IL_1A0:
				num2 = 11;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1B5:
				goto IL_244;
				IL_1BA:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_1FE:
				goto IL_239;
				IL_200:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_1BA;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_216:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_200;
			}
			IL_239:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_244:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcPLType")]
		public void TcPLType()
		{
			int num;
			int num9;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Polyline polyline = (Polyline)transaction.GetObject(selectedObject.ObjectId, 0);
							Point3d minPoint = polyline.GeometricExtents.MinPoint;
							Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
							Point3d point3d;
							point3d..ctor(minPoint.X, maxPoint.Y, minPoint.Z);
							Point3d point3d2;
							point3d2..ctor(maxPoint.X, minPoint.Y, minPoint.Z);
							Point3dCollection point3dCollection = new Point3dCollection();
							long num3 = 0L;
							long num4 = (long)(checked(polyline.NumberOfVertices - 1));
							long num5 = num3;
							checked
							{
								for (;;)
								{
									long num6 = num5;
									long num7 = num4;
									if (num6 > num7)
									{
										break;
									}
									point3dCollection.Add(polyline.GetPoint3dAt((int)num5));
									num5 += 1L;
								}
								bool flag = point3dCollection.Contains(minPoint);
								bool flag2 = point3dCollection.Contains(point3d);
								bool flag3 = point3dCollection.Contains(maxPoint);
								bool flag4 = point3dCollection.Contains(point3d2);
								if (((flag && flag2) & !flag3) && flag4)
								{
									Interaction.MsgBox("LA", MsgBoxStyle.OkOnly, null);
								}
								else if ((flag & !flag2) && flag3 && flag4)
								{
									Interaction.MsgBox("LB", MsgBoxStyle.OkOnly, null);
								}
								else if ((flag && flag2 && flag3) & !flag4)
								{
									Interaction.MsgBox("LC", MsgBoxStyle.OkOnly, null);
								}
								else if (!flag && flag2 && flag3 && flag4)
								{
									Interaction.MsgBox("LD", MsgBoxStyle.OkOnly, null);
								}
								else if ((flag & !flag2 & !flag3) && flag4)
								{
									Interaction.MsgBox("TA", MsgBoxStyle.OkOnly, null);
								}
								else if ((!flag && flag2 && flag3) & !flag4)
								{
									Interaction.MsgBox("TB", MsgBoxStyle.OkOnly, null);
								}
								else if ((flag && flag2) & !flag3 & !flag4)
								{
									Interaction.MsgBox("TC", MsgBoxStyle.OkOnly, null);
								}
								else if ((!flag & !flag2) && flag3 && flag4)
								{
									Interaction.MsgBox("TD", MsgBoxStyle.OkOnly, null);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						transaction.Commit();
					}
				}
				IL_2DA:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_2FF;
				}
				IL_2EB:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_2FF:
				goto IL_37B;
				IL_301:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_335:
				goto IL_370;
				IL_337:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_301;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_34D:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_337;
			}
			IL_370:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_37B:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcPLTuAo")]
		public void TcPLTuAo()
		{
			int num;
			int num4;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Polyline polyline = (Polyline)transaction.GetObject(selectedObject.ObjectId, 0);
							if (!this.DBX_TuAo(polyline))
							{
								Class36.smethod_23(polyline.StartPoint, "凹多边形", 300.0, 0, "");
							}
							else
							{
								Class36.smethod_23(polyline.StartPoint, "凸多边形", 300.0, 0, "");
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						transaction.Commit();
					}
				}
				IL_145:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_16A;
				}
				IL_156:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_16A:
				goto IL_1E6;
				IL_16C:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1A0:
				goto IL_1DB;
				IL_1A2:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_16C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1B8:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_1A2;
			}
			IL_1DB:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1E6:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public bool DBX_TuAo(Polyline PL)
		{
			checked
			{
				int num = PL.NumberOfVertices - 1;
				double num2 = 0.0;
				int num3 = 0;
				int num4 = num;
				int num5 = num3;
				for (;;)
				{
					int num6 = num5;
					int num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					Point3d point3dAt;
					if (num5 > 0)
					{
						point3dAt = PL.GetPoint3dAt(num5 - 1);
					}
					else
					{
						point3dAt = PL.GetPoint3dAt(num);
					}
					Point3d point3dAt2 = PL.GetPoint3dAt(num5);
					Point3d point3dAt3;
					if (num5 < num)
					{
						point3dAt3 = PL.GetPoint3dAt(num5 + 1);
					}
					else
					{
						point3dAt3 = PL.GetPoint3dAt(0);
					}
					Vector3d vectorTo = point3dAt.GetVectorTo(point3dAt2);
					Vector3d vectorTo2 = point3dAt2.GetVectorTo(point3dAt3);
					Vector3d vector3d = vectorTo.CrossProduct(vectorTo2);
					if (num2 == 0.0)
					{
						num2 = vector3d.Z;
					}
					if (unchecked(vector3d.Z * num2) < 0.0)
					{
						goto IL_BE;
					}
					num5++;
				}
				return true;
				IL_BE:
				return false;
			}
		}

		[CommandMethod("TcDay")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcDay()
		{
			CAD.CreateLayer("注释_锁定", 1, "continuous", 30, false, false);
			CAD.LockLayer("注释_锁定");
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			string setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_TcDay", "_TcDay", "打印出图");
			string text = Interaction.InputBox("请输入时间戳标记内容:", Class33.Class31_0.Info.ProductName, setting, -1, -1);
			if (Operators.CompareString(text, "", false) != 0)
			{
				Point3d point = CAD.GetPoint("选择插入点: ");
				string text2 = DateTime.Now.GetDateTimeFormats('s')[0].ToString();
				text2 = text2.Replace("T", " ");
				long num = (long)checked(Math.Max(text.Length * 1000, text2.Length * 1000));
				Point3d pointXY = CAD.GetPointXY(point, 0.0, -3000.0);
				ObjectId objectId = Class36.smethod_57(text2, pointXY, 1500.0, 1, 2, "黑体", 0.0);
				Point3d pointXY2 = CAD.GetPointXY(point, (double)(checked(0L - num)) * 0.4, 0.0);
				Point3d pointXY3 = CAD.GetPointXY(point, (double)num * 0.4, 0.0);
				ObjectId objectId2 = Class36.smethod_59(text, pointXY2, pointXY3, 3000.0, "黑体", 0.0);
				Point3d pointXY4 = CAD.GetPointXY(point, (double)(checked(0L - num)) / 2.0, (double)-5000f);
				ObjectId objectId3 = CAD.AddPlinePxy(pointXY4, (double)num, (double)10000f, 250.0, "").ObjectId;
				CAD.ChangeLayer(objectId, "注释_锁定");
				CAD.ChangeLayer(objectId2, "注释_锁定");
				CAD.ChangeLayer(objectId3, "注释_锁定");
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				objectIdCollection.Add(objectId);
				objectIdCollection.Add(objectId2);
				objectIdCollection.Add(objectId3);
				Class36.smethod_19(objectIdCollection);
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_TcDay", "_TcDay", text);
			}
		}

		[CommandMethod("对称轴")]
		public void 对称轴()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d pointAngle;
				Point3d pointAngle2;
				Class36.smethod_31(ref pointAngle, ref pointAngle2, "选择插入点:");
				IL_1A:
				num2 = 3;
				ObjectId[] array = new ObjectId[5];
				IL_23:
				num2 = 4;
				double num3 = CAD.P2P_Angle(pointAngle, pointAngle2);
				IL_30:
				num2 = 5;
				num3 = num3 * 180.0 / 3.1415926535897931;
				IL_4A:
				num2 = 6;
				array[0] = CAD.AddLine(CAD.GetPointAngle(pointAngle, 1000.0, num3 + 180.0), CAD.GetPointAngle(pointAngle2, 1000.0, num3), "0").ObjectId;
				IL_95:
				num2 = 7;
				Class36.smethod_71(array[0], "Dote", 0);
				IL_AF:
				num2 = 8;
				array[1] = CAD.AddLine(CAD.GetPointAngle(pointAngle, 500.0, num3 + 90.0), CAD.GetPointAngle(pointAngle, 500.0, num3 - 90.0), "0").ObjectId;
				IL_104:
				num2 = 9;
				pointAngle = CAD.GetPointAngle(pointAngle, 200.0, num3 + 180.0);
				IL_125:
				num2 = 10;
				array[2] = CAD.AddLine(CAD.GetPointAngle(pointAngle, 350.0, num3 + 90.0), CAD.GetPointAngle(pointAngle, 350.0, num3 - 90.0), "0").ObjectId;
				IL_17B:
				num2 = 11;
				array[3] = CAD.AddLine(CAD.GetPointAngle(pointAngle2, 500.0, num3 + 90.0), CAD.GetPointAngle(pointAngle2, 500.0, num3 - 90.0), "0").ObjectId;
				IL_1D1:
				num2 = 12;
				pointAngle2 = CAD.GetPointAngle(pointAngle2, 200.0, num3);
				IL_1E8:
				num2 = 13;
				array[4] = CAD.AddLine(CAD.GetPointAngle(pointAngle2, 350.0, num3 + 90.0), CAD.GetPointAngle(pointAngle2, 350.0, num3 - 90.0), "0").ObjectId;
				IL_23E:
				num2 = 14;
				Class36.smethod_55(array);
				IL_248:
				goto IL_2DA;
				IL_24D:
				goto IL_2E4;
				IL_252:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_269;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_2B5;
				IL_269:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_2B5:
				goto IL_2E4;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_252;
			}
			IL_2DA:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_2E4:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("剖面符号")]
		public void 剖面符号()
		{
			int num;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d point3d;
				Point3d point3d2;
				Class36.smethod_32(ref point3d, ref point3d2, "选择插入点:");
				IL_1A:
				num2 = 3;
				Point3d point3d_;
				Class36.smethod_29(point3d2, ref point3d_, "选择下一点: ");
				IL_2B:
				num2 = 4;
				int num3 = (int)Class36.smethod_70(point3d_, point3d, point3d2);
				IL_3A:
				num2 = 5;
				ObjectId[] array = new ObjectId[5];
				IL_43:
				num2 = 6;
				double num4 = point3d.GetVectorTo(point3d2).AngleOnPlane(new Plane());
				IL_5E:
				num2 = 7;
				num4 = num4 * 180.0 / 3.1415926535897931;
				IL_78:
				num2 = 8;
				array[0] = CAD.AddLine(point3d, point3d2, "0").ObjectId;
				IL_99:
				num2 = 9;
				Class36.smethod_71(array[0], "Dote", 0);
				IL_B4:
				num2 = 10;
				Point3d[] array2 = new Point3d[3];
				IL_BF:
				num2 = 11;
				array2[0] = CAD.GetPointAngle(point3d, 500.0, num4 + (double)(checked(num3 * 90)));
				IL_E8:
				num2 = 12;
				array2[1] = point3d;
				IL_FA:
				num2 = 13;
				array2[2] = CAD.GetPointAngle(point3d, 500.0, num4);
				IL_11C:
				num2 = 14;
				array[1] = CAD.AddPline(array2, 50.0, false, "").ObjectId;
				IL_146:
				num2 = 15;
				array2[0] = CAD.GetPointAngle(point3d2, 500.0, num4 + (double)(checked(num3 * 90)));
				IL_16F:
				num2 = 16;
				array2[1] = point3d2;
				IL_181:
				num2 = 17;
				array2[2] = CAD.GetPointAngle(point3d2, 500.0, num4 + 180.0);
				IL_1AD:
				num2 = 18;
				string string_ = Interaction.InputBox("输入编号:", "田草CAD工具箱.Net版", "1", -1, -1);
				IL_1C7:
				num2 = 19;
				array[2] = CAD.AddPline(array2, 50.0, false, "").ObjectId;
				IL_1F1:
				num2 = 20;
				array[3] = Class36.smethod_57(string_, CAD.GetPointAngle(point3d, 800.0, num4 + (double)(checked(num3 * 90))), 450.0, 1, 2, "COMPLEX", 0.0);
				IL_238:
				num2 = 21;
				array[4] = Class36.smethod_57(string_, CAD.GetPointAngle(point3d2, 800.0, num4 + (double)(checked(num3 * 90))), 450.0, 1, 2, "COMPLEX", 0.0);
				IL_27F:
				num2 = 22;
				Class36.smethod_55(array);
				IL_289:
				goto IL_342;
				IL_28E:
				goto IL_34D;
				IL_293:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_2AB;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_31C;
				IL_2AB:
				int num6 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num6);
				IL_31C:
				goto IL_34D;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_293;
			}
			IL_342:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_34D:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("断面符号")]
		public void 断面符号()
		{
			int num;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d point3d;
				Point3d point3d2;
				Class36.smethod_32(ref point3d, ref point3d2, "选择插入点:");
				IL_1A:
				num2 = 3;
				ObjectId[] array = new ObjectId[5];
				IL_23:
				num2 = 4;
				double num3 = Class36.smethod_26(point3d, point3d2);
				IL_30:
				num2 = 5;
				num3 = num3 * 180.0 / 3.1415926535897931;
				IL_4A:
				num2 = 6;
				array[0] = CAD.AddLine(point3d, point3d2, "0").ObjectId;
				IL_6B:
				num2 = 7;
				Class36.smethod_71(array[0], "Dote", 0);
				IL_85:
				num2 = 8;
				Point3d[] array2 = new Point3d[2];
				IL_8E:
				num2 = 9;
				array2[0] = point3d;
				IL_9F:
				num2 = 10;
				array2[1] = CAD.GetPointAngle(point3d, 500.0, num3 + 180.0);
				IL_CA:
				num2 = 11;
				array[1] = CAD.AddPline(array2, 50.0, false, "").ObjectId;
				IL_F3:
				num2 = 12;
				array2[0] = point3d2;
				IL_104:
				num2 = 13;
				array2[1] = CAD.GetPointAngle(point3d2, 500.0, num3);
				IL_125:
				num2 = 14;
				array[2] = CAD.AddPline(array2, 50.0, false, "").ObjectId;
				IL_14E:
				num2 = 15;
				string string_ = Interaction.InputBox("输入编号:", "田草CAD工具箱.Net版", "1", -1, -1);
				IL_169:
				num2 = 16;
				array[3] = Class36.smethod_57(string_, CAD.GetPointAngle(point3d, 350.0, num3 + 90.0), 450.0, 1, 2, "COMPLEX", 0.0);
				IL_1B4:
				num2 = 17;
				array[4] = Class36.smethod_57(string_, CAD.GetPointAngle(point3d2, 350.0, num3 + 90.0), 450.0, 1, 2, "COMPLEX", 0.0);
				IL_1FF:
				num2 = 18;
				Class36.smethod_55(array);
				IL_209:
				goto IL_2B0;
				IL_20E:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_26A:
				goto IL_2A5;
				IL_26C:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_20E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_282:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_26C;
			}
			IL_2A5:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2B0:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("设置坐标原点")]
		public void 设置坐标原点()
		{
			int num;
			int num8;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d p;
				Point3d point3d;
				Class36.smethod_32(ref p, ref point3d, "选择插入点:");
				IL_1A:
				num2 = 3;
				Application.SetSystemVariable("USERR1", p.X);
				IL_32:
				num2 = 4;
				Application.SetSystemVariable("USERR2", p.Y);
				IL_4A:
				num2 = 5;
				ObjectId[] array = new ObjectId[4];
				IL_54:
				num2 = 6;
				double num3 = p.GetVectorTo(point3d).AngleOnPlane(new Plane());
				IL_6E:
				num2 = 7;
				num3 = num3 * 180.0 / 3.1415926535897931;
				IL_88:
				num2 = 8;
				if (!((num3 >= 0.0 & num3 <= 90.0) | (num3 > 270.0 & num3 < 360.0)))
				{
					goto IL_ED;
				}
				IL_C9:
				num2 = 9;
				Point3d pointAngle = CAD.GetPointAngle(point3d, 2000.0, 0.0);
				IL_E5:
				num2 = 10;
				short num4 = 0;
				goto IL_136;
				IL_ED:
				num2 = 12;
				if (!(num3 > 90.0 & num3 <= 270.0))
				{
					goto IL_136;
				}
				IL_110:
				num2 = 13;
				pointAngle = CAD.GetPointAngle(point3d, 2000.0, 180.0);
				IL_12C:
				num2 = 14;
				num4 = -2000;
				IL_136:
				num2 = 16;
				array[0] = CAD.AddLine(p, point3d, "0").ObjectId;
				IL_158:
				num2 = 17;
				array[1] = CAD.AddLine(point3d, pointAngle, "0").ObjectId;
				IL_179:
				num2 = 18;
				ObjectId[] array2 = array;
				int num5 = 2;
				string string_ = string.Format("X={0:0.000}", 0);
				Point3d point3d_;
				point3d_..ctor(point3d.X + (double)num4, point3d.Y + 100.0, 0.0);
				array2[num5] = Class36.smethod_57(string_, point3d_, 300.0, 0, 0, "STANDARD", 0.0);
				IL_1E5:
				num2 = 19;
				ObjectId[] array3 = array;
				int num6 = 3;
				string string_2 = string.Format("Y={0:0.000}", 0);
				point3d_..ctor(point3d.X + (double)num4, point3d.Y - 350.0, 0.0);
				array3[num6] = Class36.smethod_57(string_2, point3d_, 300.0, 0, 0, "STANDARD", 0.0);
				IL_251:
				num2 = 20;
				Class36.smethod_55(array);
				IL_25C:
				goto IL_30B;
				IL_261:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_2C5:
				goto IL_300;
				IL_2C7:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_261;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2DD:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2C7;
			}
			IL_300:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_30B:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("坐标标注")]
		public void 坐标标注()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d p;
				Point3d point3d;
				Class36.smethod_32(ref p, ref point3d, "选择插入点:");
				IL_1A:
				num2 = 3;
				ObjectId[] array = new ObjectId[4];
				IL_24:
				num2 = 4;
				double num3 = p.GetVectorTo(point3d).AngleOnPlane(new Plane());
				IL_3F:
				num2 = 5;
				num3 = num3 * 180.0 / 3.1415926535897931;
				IL_59:
				num2 = 6;
				if (!((num3 >= 0.0 & num3 <= 90.0) | (num3 > 270.0 & num3 < 360.0)))
				{
					goto IL_BD;
				}
				IL_9A:
				num2 = 7;
				Point3d pointAngle = CAD.GetPointAngle(point3d, 2000.0, 0.0);
				IL_B7:
				num2 = 8;
				short num4 = 0;
				goto IL_107;
				IL_BD:
				num2 = 10;
				if (!(num3 > 90.0 & num3 <= 270.0))
				{
					goto IL_107;
				}
				IL_E0:
				num2 = 11;
				pointAngle = CAD.GetPointAngle(point3d, 2000.0, 180.0);
				IL_FE:
				num2 = 12;
				num4 = -2000;
				IL_107:
				num2 = 14;
				array[0] = CAD.AddLine(p, point3d, "0").ObjectId;
				IL_12A:
				num2 = 15;
				array[1] = CAD.AddLine(point3d, pointAngle, "0").ObjectId;
				IL_14D:
				num2 = 16;
				double num5 = Conversions.ToDouble(Application.GetSystemVariable("USERR1"));
				IL_161:
				num2 = 17;
				double num6 = Conversions.ToDouble(Application.GetSystemVariable("USERR2"));
				IL_175:
				num2 = 18;
				ObjectId[] array2 = array;
				int num7 = 2;
				string string_ = string.Format("X={0:0.000}", (p.X - num5) / 1000.0);
				Point3d point3d_;
				point3d_..ctor(point3d.X + (double)num4, point3d.Y + 100.0, 0.0);
				array2[num7] = Class36.smethod_57(string_, point3d_, 300.0, 0, 0, "STANDARD", 0.0);
				IL_1F3:
				num2 = 19;
				ObjectId[] array3 = array;
				int num8 = 3;
				string string_2 = string.Format("Y={0:0.000}", (p.Y - num6) / 1000.0);
				point3d_..ctor(point3d.X + (double)num4, point3d.Y - 350.0, 0.0);
				array3[num8] = Class36.smethod_57(string_2, point3d_, 300.0, 0, 0, "STANDARD", 0.0);
				IL_271:
				num2 = 20;
				Class36.smethod_55(array);
				IL_27C:
				goto IL_326;
				IL_281:
				goto IL_330;
				IL_286:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_29D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_301;
				IL_29D:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_301:
				goto IL_330;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_286;
			}
			IL_326:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_330:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("极坐标")]
		public void 极坐标()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				ObjectId[] array = new ObjectId[2];
				IL_13:
				num2 = 3;
				Point3d point3d;
				Point3d point3d2;
				Class36.smethod_31(ref point3d, ref point3d2, "选择插入点:");
				IL_24:
				num2 = 4;
				double value = point3d.GetVectorTo(point3d2).AngleOnPlane(new Plane());
				IL_3E:
				num2 = 5;
				double value2 = point3d.DistanceTo(point3d2);
				IL_4A:
				num2 = 6;
				Line line = new Line(point3d, point3d2);
				IL_55:
				num2 = 7;
				CAD.AddEnt(line);
				IL_5F:
				num2 = 8;
				array[0] = line.ObjectId;
				IL_75:
				num2 = 9;
				DBText dbtext = new DBText();
				IL_7F:
				num2 = 10;
				dbtext.Height = 150.0;
				IL_92:
				num2 = 11;
				dbtext.TextString = "A=" + Conversions.ToString(value) + " R=" + Conversions.ToString(value2);
				IL_B9:
				num2 = 12;
				dbtext.HorizontalMode = 1;
				IL_C4:
				num2 = 13;
				DBText dbtext2 = dbtext;
				Point3d alignmentPoint;
				alignmentPoint..ctor((point3d.X + point3d2.X) / 2.0, (point3d.Y + point3d2.Y) / 2.0, 0.0);
				dbtext2.AlignmentPoint = alignmentPoint;
				IL_112:
				num2 = 14;
				dbtext.WidthFactor = 0.7;
				IL_125:
				num2 = 15;
				dbtext.Rotation = CAD.P2P_Angle(point3d, point3d2);
				IL_136:
				num2 = 16;
				CAD.AddEnt(dbtext);
				IL_141:
				num2 = 17;
				array[1] = dbtext.ObjectId;
				IL_158:
				num2 = 18;
				Class36.smethod_55(array);
				IL_163:
				goto IL_20A;
				IL_168:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1C4:
				goto IL_1FF;
				IL_1C6:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_168;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1DC:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1C6;
			}
			IL_1FF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_20A:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcChongDie", 6)]
		public void TcChongDie()
		{
			int num;
			int num5;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Editor editor = mdiActiveDocument.Editor;
				IL_29:
				num2 = 5;
				PromptSelectionResult promptSelectionResult = editor.SelectImplied();
				IL_34:
				num2 = 6;
				if (promptSelectionResult.Status != -5001)
				{
					goto IL_53;
				}
				IL_46:
				num2 = 7;
				promptSelectionResult = editor.GetSelection();
				goto IL_62;
				IL_53:
				num2 = 9;
				IL_56:
				num2 = 10;
				promptSelectionResult = editor.GetSelection();
				IL_62:
				num2 = 12;
				CAD.CreateLayer("重叠碰撞检查", 1, "continuous", -1, false, true);
				IL_79:
				num2 = 13;
				ArrayList arrayList = new ArrayList();
				IL_83:
				num2 = 14;
				long num3 = 0L;
				IL_91:
				num2 = 15;
				checked
				{
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						SelectionSet value = promptSelectionResult.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							object instance = entity.GeometricExtents.MaxPoint;
							object instance2 = entity.GeometricExtents.MinPoint;
							Point2d point2d;
							point2d..ctor(Conversions.ToDouble(Operators.DivideObject(Operators.AddObject(NewLateBinding.LateGet(instance, null, "x", new object[0], null, null, null), NewLateBinding.LateGet(instance2, null, "x", new object[0], null, null, null)), 2)), Conversions.ToDouble(Operators.DivideObject(Operators.AddObject(NewLateBinding.LateGet(instance, null, "y", new object[0], null, null, null), NewLateBinding.LateGet(instance2, null, "y", new object[0], null, null, null)), 2)));
							string text = Conversions.ToString((long)Math.Round(point2d.X)) + Conversions.ToString((long)Math.Round(point2d.Y)) + entity.GetType().Name;
							if (arrayList.Contains(text))
							{
								Point3d point3d_;
								point3d_..ctor(point2d.X, point2d.Y, 0.0);
								Class36.smethod_23(point3d_, "X", 300.0, 0, "重叠碰撞检查");
								num3 += 1L;
							}
							else
							{
								arrayList.Add(text);
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						transaction.Commit();
					}
					IL_26B:
					num2 = 17;
					mdiActiveDocument.Editor.WriteMessage("\r\n检查到" + Conversions.ToString(num3) + "个重叠碰撞可能.");
					IL_28F:
					num2 = 18;
					if (Information.Err().Number <= 0)
					{
					}
					IL_2A1:
					goto IL_34C;
					IL_2A6:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_306:
				goto IL_341;
				IL_308:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_2A6;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_31E:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_308;
			}
			IL_341:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_34C:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
