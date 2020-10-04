using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 钢筋转换
	{
		[DebuggerNonUserCode]
		public 钢筋转换()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcBanJin90_Top")]
		public void TcBanJin90_Top()
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
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "Line");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Line line = (Line)transaction.GetObject(objectId, 1);
							Point3d startPoint = line.StartPoint;
							Point3d endPoint = line.EndPoint;
							if (startPoint.GetVectorTo(endPoint).AngleOnPlane(new Plane()) > 0.78539816339744828)
							{
								Class36.smethod_37(startPoint, endPoint);
							}
							else
							{
								Class36.smethod_37(startPoint, endPoint);
							}
						}
					}
					transaction.Commit();
				}
				IL_12C:
				goto IL_198;
				IL_12E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_152:
				goto IL_18D;
				IL_154:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_12E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_16A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_154;
			}
			IL_18D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_198:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public short TcBanJin90_Top(Point3d PT1, Point3d PT2)
		{
			double num = CAD.P2P_Angle(PT1, PT2);
			Point3d pointAngle = CAD.GetPointAngle(PT1, 200.0, num * 180.0 / 3.1415926535897931 + 90.0);
			Point3d pointAngle2 = CAD.GetPointAngle(PT2, 200.0, num * 180.0 / 3.1415926535897931 + 90.0);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			Polyline polyline2 = polyline;
			int num2 = 0;
			Point2d point2d;
			point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
			polyline2.AddVertexAt(num2, point2d, 0.0, 45.0, 45.0);
			Polyline polyline3 = polyline;
			int num3 = 1;
			point2d..ctor(PT1.get_Coordinate(0), PT1.get_Coordinate(1));
			polyline3.AddVertexAt(num3, point2d, 0.0, 45.0, 45.0);
			Polyline polyline4 = polyline;
			int num4 = 2;
			point2d..ctor(PT2.get_Coordinate(0), PT2.get_Coordinate(1));
			polyline4.AddVertexAt(num4, point2d, 0.0, 45.0, 45.0);
			Polyline polyline5 = polyline;
			int num5 = 3;
			point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
			polyline5.AddVertexAt(num5, point2d, 0.0, 45.0, 45.0);
			CAD.CreateLayer("负筋", 1, "continuous", -1, false, true);
			polyline.Layer = "负筋";
			CAD.AddEnt(polyline);
			return 0;
		}

		[CommandMethod("TcBanJinQuGou")]
		public void TcBanJinQuGou()
		{
			int num;
			int num6;
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
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Polyline polyline = (Polyline)transaction.GetObject(objectId, 1);
							Point3d point3dAt = polyline.GetPoint3dAt(1);
							Point3d point3dAt2 = polyline.GetPoint3dAt(2);
							Polyline polyline2 = new Polyline();
							polyline2.SetDatabaseDefaults();
							Polyline polyline3 = polyline2;
							int num3 = 0;
							Point2d point2d;
							point2d..ctor(point3dAt.get_Coordinate(0), point3dAt.get_Coordinate(1));
							polyline3.AddVertexAt(num3, point2d, 0.0, 45.0, 45.0);
							Polyline polyline4 = polyline2;
							int num4 = 1;
							point2d..ctor(point3dAt2.get_Coordinate(0), point3dAt2.get_Coordinate(1));
							polyline4.AddVertexAt(num4, point2d, 0.0, 45.0, 45.0);
							polyline2.Layer = polyline.Layer;
							CAD.AddEnt(polyline2);
							polyline.Erase();
						}
					}
					transaction.Commit();
				}
				IL_19D:
				goto IL_209;
				IL_19F:
				int num5 = num6 + 1;
				num6 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_1C3:
				goto IL_1FE;
				IL_1C5:
				num6 = num2;
				if (num <= -2)
				{
					goto IL_19F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1DB:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num6 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1C5;
			}
			IL_1FE:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_209:
			if (num6 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcBanJinGouYanChang")]
		public void TcBanJinGouYanChang()
		{
			int num;
			int num6;
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
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Polyline polyline = (Polyline)transaction.GetObject(objectId, 1);
							Point3d point3dAt = polyline.GetPoint3dAt(1);
							Point3d point3dAt2 = polyline.GetPoint3dAt(2);
							Polyline polyline2 = new Polyline();
							polyline2.SetDatabaseDefaults();
							Polyline polyline3 = polyline2;
							int num3 = 0;
							Point2d point2d;
							point2d..ctor(point3dAt.get_Coordinate(0), point3dAt.get_Coordinate(1));
							polyline3.AddVertexAt(num3, point2d, 0.0, 45.0, 45.0);
							Polyline polyline4 = polyline2;
							int num4 = 1;
							point2d..ctor(point3dAt2.get_Coordinate(0), point3dAt2.get_Coordinate(1));
							polyline4.AddVertexAt(num4, point2d, 0.0, 45.0, 45.0);
							polyline2.Layer = polyline.Layer;
							CAD.AddEnt(polyline2);
							polyline.Erase();
						}
					}
					transaction.Commit();
				}
				IL_19D:
				goto IL_209;
				IL_19F:
				int num5 = num6 + 1;
				num6 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_1C3:
				goto IL_1FE;
				IL_1C5:
				num6 = num2;
				if (num <= -2)
				{
					goto IL_19F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1DB:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num6 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1C5;
			}
			IL_1FE:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_209:
			if (num6 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcCJBJ")]
		public void TcCJBJ()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "HATCH");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Entity entity = (Entity)transaction.GetObject(objectId, 1);
						mdiActiveDocument.SendStringToExecute("-hatchedit (handent \"" + entity.Handle.ToString() + "\")  B P Y ", false, false, false);
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcBeamLine")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcBeamLine()
		{
			int num;
			int num6;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				CAD.CreateLayer("梁虚线", 4, "continuous", -1, false, true);
				IL_1F:
				num2 = 3;
				long num3 = Conversions.ToLong(Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "TcBeamLine", "W", Conversions.ToString(200)));
				IL_4F:
				num2 = 4;
				long num4 = Conversions.ToLong(Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "TcBeamLine", "P", Conversions.ToString(0)));
				IL_7B:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_89:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_94:
				num2 = 7;
				PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions("\r\n梁截面宽度:");
				IL_A2:
				num2 = 8;
				promptIntegerOptions.DefaultValue = checked((int)num3);
				IL_AD:
				num2 = 9;
				promptIntegerOptions.AllowNone = false;
				IL_B8:
				num2 = 10;
				PromptIntegerResult integer = mdiActiveDocument.Editor.GetInteger(promptIntegerOptions);
				IL_CB:
				num2 = 11;
				if (integer.Status != 5100)
				{
					goto IL_EC;
				}
				IL_DE:
				num2 = 12;
				num3 = (long)integer.Value;
				goto IL_FC;
				IL_EC:
				num2 = 14;
				IL_EF:
				num2 = 15;
				num3 = 200L;
				IL_FC:
				num2 = 17;
				PromptIntegerOptions promptIntegerOptions2 = new PromptIntegerOptions("\r\n梁截面偏心:");
				IL_10B:
				num2 = 18;
				promptIntegerOptions2.DefaultValue = checked((int)num4);
				IL_117:
				num2 = 19;
				promptIntegerOptions2.AllowNone = false;
				IL_122:
				num2 = 20;
				PromptIntegerResult integer2 = mdiActiveDocument.Editor.GetInteger(promptIntegerOptions2);
				IL_135:
				num2 = 21;
				if (integer.Status != 5100)
				{
					goto IL_156;
				}
				IL_148:
				num2 = 22;
				num4 = (long)integer2.Value;
				goto IL_166;
				IL_156:
				num2 = 24;
				IL_159:
				num2 = 25;
				num4 = 0L;
				IL_166:
				num2 = 27;
				mdiActiveDocument.Editor.WriteMessage("梁宽:" + Conversions.ToString(num3) + "     偏心:" + Conversions.ToString(num4));
				IL_190:
				num2 = 28;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "TcBeamLine", "W", num3.ToString());
				IL_1B8:
				num2 = 29;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "TcBeamLine", "P", num4.ToString());
				IL_1E0:
				num2 = 30;
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
						Polyline polyline = (Polyline)transaction.GetObject(value[0].ObjectId, 0);
						Polyline polyline2 = (Polyline)transaction.GetObject(value[1].ObjectId, 0);
						Point3d minPoint = polyline.GeometricExtents.MinPoint;
						Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
						Point3d minPoint2 = polyline2.GeometricExtents.MinPoint;
						Point3d maxPoint2 = polyline2.GeometricExtents.MaxPoint;
						Point3d point3d;
						point3d..ctor((minPoint.X + maxPoint.X) / 2.0, (minPoint.Y + maxPoint.Y) / 2.0, (minPoint.Z + maxPoint.Z) / 2.0);
						Point3d point3d2;
						point3d2..ctor((minPoint2.X + maxPoint2.X) / 2.0, (minPoint2.Y + maxPoint2.Y) / 2.0, (minPoint2.Z + maxPoint2.Z) / 2.0);
						Line line = new Line(point3d, point3d2);
						DBObjectCollection offsetCurves = line.GetOffsetCurves((double)num3 / 2.0 + (double)num4);
						DBObjectCollection offsetCurves2 = line.GetOffsetCurves(-((double)num3 / 2.0 - (double)num4));
						Line line2 = (Line)offsetCurves[0];
						Line line3 = (Line)offsetCurves2[0];
						Point3dCollection point3dCollection = new Point3dCollection();
						polyline.IntersectWith(line2, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
						if (point3dCollection.Count == 0)
						{
							goto IL_626;
						}
						Point3d point3d3 = point3dCollection[0];
						point3dCollection.Clear();
						polyline2.IntersectWith(line2, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
						if (point3dCollection.Count == 0)
						{
							goto IL_626;
						}
						Point3d point3d4 = point3dCollection[0];
						CAD.AddEnt(new Line(point3d3, point3d4)
						{
							Layer = "梁虚线"
						});
						point3dCollection.Clear();
						polyline.IntersectWith(line3, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
						if (point3dCollection.Count == 0)
						{
							goto IL_626;
						}
						Point3d point3d5 = point3dCollection[0];
						point3dCollection.Clear();
						polyline2.IntersectWith(line3, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
						if (point3dCollection.Count == 0)
						{
							goto IL_626;
						}
						Point3d point3d6 = point3dCollection[0];
						CAD.AddEnt(new Line(point3d5, point3d6)
						{
							Layer = "梁虚线"
						});
					}
					transaction.Commit();
				}
				IL_515:
				num2 = 32;
				if (Information.Err().Number <= 0)
				{
					goto IL_53C;
				}
				IL_527:
				num2 = 33;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_53C:
				goto IL_626;
				IL_541:
				int num5 = num6 + 1;
				num6 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_5DD:
				goto IL_61B;
				IL_5DF:
				num6 = num2;
				if (num <= -2)
				{
					goto IL_541;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_5F8:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num6 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_5DF;
			}
			IL_61B:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_626:
			if (num6 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcBeamLineSet")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcBeamLineSet()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions("\r\n梁截面宽度:");
			promptIntegerOptions.UpperLimit = 2000;
			promptIntegerOptions.LowerLimit = 100;
			promptIntegerOptions.AllowNone = true;
			PromptIntegerResult integer = mdiActiveDocument.Editor.GetInteger(promptIntegerOptions);
			if (integer.Status == 5100)
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "TcBeamLine", "W", integer.Value.ToString());
			}
			promptIntegerOptions = new PromptIntegerOptions("\r\n梁偏心（右上为正）:");
			promptIntegerOptions.UpperLimit = 1000;
			promptIntegerOptions.LowerLimit = -1000;
			promptIntegerOptions.AllowNone = true;
			PromptIntegerResult integer2 = mdiActiveDocument.Editor.GetInteger(promptIntegerOptions);
			if (integer2.Status == 5100)
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "TcBeamLine", "P", integer2.Value.ToString());
			}
		}

		[CommandMethod("TcDPL2SPL")]
		public void method_0()
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
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							if (entity is Polyline)
							{
								this.DPL2SPL((Polyline)entity);
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_10B:
				goto IL_177;
				IL_10D:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_131:
				goto IL_16C;
				IL_133:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_10D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_149:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_133;
			}
			IL_16C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_177:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public Polyline DPL2SPL(Polyline PL, double W)
		{
			int num;
			Polyline polyline4;
			int num20;
			object obj5;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point2dCollection point2dCollection = new Point2dCollection();
				IL_11:
				num2 = 3;
				short num3 = 0;
				short num4 = checked((short)(PL.NumberOfVertices - 1));
				short num5 = num3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					IL_22:
					num2 = 4;
					point2dCollection.Add(PL.GetPoint2dAt((int)num5));
					IL_33:
					num2 = 5;
					num5 += 1;
				}
				IL_45:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_53:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_5E:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Class36.smethod_85(PL.ObjectId, W / 2.0);
					object obj = Utils.EntLast();
					object obj2 = obj;
					ObjectId objectId;
					Polyline polyline = (Polyline)Class36.smethod_65((obj2 != null) ? ((ObjectId)obj2) : objectId);
					Class36.smethod_85(PL.ObjectId, -W / 2.0);
					object obj3 = Utils.EntLast();
					object obj4 = obj3;
					Polyline polyline2 = (Polyline)Class36.smethod_65((obj4 != null) ? ((ObjectId)obj4) : objectId);
					short num8;
					short num9;
					Polyline polyline3;
					short num11;
					short num12;
					checked
					{
						num8 = (short)(polyline.NumberOfVertices - 1);
						num9 = (short)(polyline2.NumberOfVertices - 1);
						polyline3 = new Polyline();
						short num10 = 0;
						num11 = num8;
						num12 = num10;
					}
					for (;;)
					{
						short num13 = num12;
						short num7 = num11;
						if (num13 > num7)
						{
							break;
						}
						polyline3.AddVertexAt((int)num12, polyline.GetPoint2dAt((int)num12), 0.0, 0.0, 0.0);
						num12 += 1;
					}
					short num14 = 0;
					short num15 = checked((short)(polyline2.NumberOfVertices - 1));
					short num16 = num14;
					for (;;)
					{
						short num17 = num16;
						short num7 = num15;
						if (num17 > num7)
						{
							break;
						}
						short num18 = checked((short)polyline.NumberOfVertices);
						if (num16 == 0)
						{
							polyline3.AddVertexAt((int)(checked(num8 + 1 + num16)), polyline2.GetPoint2dAt((int)(num9 - num16)), polyline2.GetBulgeAt((int)(num9 - num16)), 0.0, 0.0);
						}
						else if (num16 == num9)
						{
							polyline3.AddVertexAt((int)(checked(num8 + 1 + num16)), polyline2.GetPoint2dAt((int)(num9 - num16)), polyline2.GetBulgeAt((int)(num9 - num16)), 0.0, 0.0);
						}
						else
						{
							polyline3.AddVertexAt((int)(checked(num8 + 1 + num16)), polyline2.GetPoint2dAt((int)(num9 - num16)), -polyline2.GetBulgeAt((int)(checked(unchecked(num9 - num16) - 1))), 0.0, 0.0);
						}
						num16 += 1;
					}
					polyline3.Closed = true;
					polyline3.Layer = polyline.Layer;
					Class36.smethod_64(PL.ObjectId);
					Class36.smethod_64(polyline.ObjectId);
					Class36.smethod_64(polyline2.ObjectId);
					CAD.AddEnt(polyline3);
					transaction.Commit();
					polyline4 = polyline3;
					goto IL_36D;
				}
				IL_2B7:
				num2 = 10;
				if (Information.Err().Number <= 0)
				{
					goto IL_2DE;
				}
				IL_2C9:
				num2 = 11;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_2DE:
				goto IL_36D;
				IL_2E3:
				int num19 = num20 + 1;
				num20 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num19);
				IL_327:
				goto IL_362;
				IL_329:
				num20 = num2;
				if (num <= -2)
				{
					goto IL_2E3;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_33F:;
			}
			catch when (endfilter(obj5 is Exception & num != 0 & num20 == 0))
			{
				Exception ex = (Exception)obj6;
				goto IL_329;
			}
			IL_362:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_36D:
			Polyline result = polyline4;
			if (num20 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public Polyline DPL2SPL(Polyline PL)
		{
			int num;
			Polyline polyline4;
			int num20;
			object obj5;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point2dCollection point2dCollection = new Point2dCollection();
				IL_11:
				num2 = 3;
				short num3 = 0;
				short num4 = checked((short)(PL.NumberOfVertices - 1));
				short num5 = num3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					IL_22:
					num2 = 4;
					point2dCollection.Add(PL.GetPoint2dAt((int)num5));
					IL_33:
					num2 = 5;
					num5 += 1;
				}
				IL_45:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_53:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_5E:
				num2 = 8;
				double startWidthAt = PL.GetStartWidthAt(0);
				IL_69:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Class36.smethod_85(PL.ObjectId, startWidthAt / 2.0);
					object obj = Utils.EntLast();
					object obj2 = obj;
					ObjectId objectId;
					Polyline polyline = (Polyline)Class36.smethod_65((obj2 != null) ? ((ObjectId)obj2) : objectId);
					Class36.smethod_85(PL.ObjectId, -startWidthAt / 2.0);
					object obj3 = Utils.EntLast();
					object obj4 = obj3;
					Polyline polyline2 = (Polyline)Class36.smethod_65((obj4 != null) ? ((ObjectId)obj4) : objectId);
					short num8;
					short num9;
					Polyline polyline3;
					short num11;
					short num12;
					checked
					{
						num8 = (short)(polyline.NumberOfVertices - 1);
						num9 = (short)(polyline2.NumberOfVertices - 1);
						polyline3 = new Polyline();
						short num10 = 0;
						num11 = num8;
						num12 = num10;
					}
					for (;;)
					{
						short num13 = num12;
						short num7 = num11;
						if (num13 > num7)
						{
							break;
						}
						polyline3.AddVertexAt((int)num12, polyline.GetPoint2dAt((int)num12), 0.0, 0.0, 0.0);
						num12 += 1;
					}
					short num14 = 0;
					short num15 = checked((short)(polyline2.NumberOfVertices - 1));
					short num16 = num14;
					for (;;)
					{
						short num17 = num16;
						short num7 = num15;
						if (num17 > num7)
						{
							break;
						}
						short num18 = checked((short)polyline.NumberOfVertices);
						if (num16 == 0)
						{
							polyline3.AddVertexAt((int)(checked(num8 + 1 + num16)), polyline2.GetPoint2dAt((int)(num9 - num16)), polyline2.GetBulgeAt((int)(num9 - num16)), 0.0, 0.0);
						}
						else if (num16 == num9)
						{
							polyline3.AddVertexAt((int)(checked(num8 + 1 + num16)), polyline2.GetPoint2dAt((int)(num9 - num16)), polyline2.GetBulgeAt((int)(num9 - num16)), 0.0, 0.0);
						}
						else
						{
							polyline3.AddVertexAt((int)(checked(num8 + 1 + num16)), polyline2.GetPoint2dAt((int)(num9 - num16)), -polyline2.GetBulgeAt((int)(checked(unchecked(num9 - num16) - 1))), 0.0, 0.0);
						}
						num16 += 1;
					}
					polyline3.Closed = true;
					polyline3.Layer = polyline.Layer;
					Class36.smethod_64(PL.ObjectId);
					Class36.smethod_64(polyline.ObjectId);
					Class36.smethod_64(polyline2.ObjectId);
					CAD.AddEnt(polyline3);
					transaction.Commit();
					polyline4 = polyline3;
					goto IL_37F;
				}
				IL_2C5:
				num2 = 11;
				if (Information.Err().Number <= 0)
				{
					goto IL_2EC;
				}
				IL_2D7:
				num2 = 12;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_2EC:
				goto IL_37F;
				IL_2F1:
				int num19 = num20 + 1;
				num20 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num19);
				IL_339:
				goto IL_374;
				IL_33B:
				num20 = num2;
				if (num <= -2)
				{
					goto IL_2F1;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_351:;
			}
			catch when (endfilter(obj5 is Exception & num != 0 & num20 == 0))
			{
				Exception ex = (Exception)obj6;
				goto IL_33B;
			}
			IL_374:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_37F:
			Polyline result = polyline4;
			if (num20 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		[CommandMethod("TcEntType")]
		public void TcEntType()
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
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\r\n选择CAD对象:");
				IL_2D:
				num2 = 5;
				PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity(promptEntityOptions);
				IL_3E:
				num2 = 6;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Entity entity2 = (Entity)transaction.GetObject(entity.ObjectId, 0);
					string fullName = entity2.GetType().FullName;
					string prompt = fullName.Substring(Strings.InStrRev(fullName, ".", -1, CompareMethod.Binary));
					Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
					Interaction.MsgBox(entity2.GetType().Name, MsgBoxStyle.OkOnly, null);
					transaction.Commit();
				}
				IL_C1:
				goto IL_135;
				IL_C3:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_EF:
				goto IL_12A;
				IL_F1:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_C3;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_107:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_F1;
			}
			IL_12A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_135:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcMB")]
		public void TcMirrorBeam()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line,Text");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
				promptSelectionOptions.MessageForAdding = "梁平法标注:";
				Line3d line3d = new Line3d();
				PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Entity entity = (Entity)transaction.GetObject(objectId, 1);
						if (Operators.CompareString(entity.GetType().Name, "Line", false) == 0)
						{
							Line line = (Line)entity;
							Point3d startPoint = line.StartPoint;
							Point3d endPoint = line.EndPoint;
							CAD.AddPoint(startPoint);
							line3d = new Line3d(line.EndPoint, line.StartPoint);
						}
					}
					foreach (ObjectId objectId2 in value.GetObjectIds())
					{
						Entity entity2 = (Entity)transaction.GetObject(objectId2, 1);
						Entity entity3 = (Entity)entity2.Clone();
						entity3.TransformBy(Matrix3d.Mirroring(line3d));
						Point3d minPoint = entity3.GeometricExtents.MinPoint;
						Point3d maxPoint = entity3.GeometricExtents.MaxPoint;
						Point3d point3d;
						point3d..ctor((minPoint.X + maxPoint.X) / 2.0, minPoint.Y, 0.0);
						Point3d point3d2;
						point3d2..ctor((minPoint.X + maxPoint.X) / 2.0, maxPoint.Y, 0.0);
						Line3d line3d2 = new Line3d(point3d, point3d2);
						Entity entity4 = (Entity)entity3.Clone();
						entity4.TransformBy(Matrix3d.Mirroring(line3d2));
						CAD.AddEnt(entity4);
						entity2.Erase();
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcMB1")]
		public void TcMirrorBeam1()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line,Text");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
				promptSelectionOptions.MessageForAdding = "梁平法标注:";
				Line3d line3d = new Line3d();
				PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Entity entity = (Entity)transaction.GetObject(objectId, 1);
						if (Operators.CompareString(entity.GetType().Name, "Line", false) == 0)
						{
							Line line = (Line)entity;
							Point3d startPoint = line.StartPoint;
							Point3d endPoint = line.EndPoint;
							Point3d pointAngle = CAD.GetPointAngle(startPoint, 100.0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
							CAD.AddPoint(startPoint);
							line3d = new Line3d(line.StartPoint, pointAngle);
						}
					}
					foreach (ObjectId objectId2 in value.GetObjectIds())
					{
						Entity entity2 = (Entity)transaction.GetObject(objectId2, 1);
						Entity entity3 = (Entity)entity2.Clone();
						entity3.TransformBy(Matrix3d.Mirroring(line3d));
						Point3d minPoint = entity3.GeometricExtents.MinPoint;
						Point3d maxPoint = entity3.GeometricExtents.MaxPoint;
						Point3d point3d;
						point3d..ctor(minPoint.X, (minPoint.Y + maxPoint.Y) / 2.0, 0.0);
						Point3d point3d2;
						point3d2..ctor(maxPoint.X, (minPoint.Y + maxPoint.Y) / 2.0, 0.0);
						Line3d line3d2 = new Line3d(point3d, point3d2);
						Entity entity4 = (Entity)entity3.Clone();
						entity4.TransformBy(Matrix3d.Mirroring(line3d2));
						CAD.AddEnt(entity4);
						entity2.Erase();
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcMB3")]
		public void TcMirrorBeam3()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line,Text");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = editor.GetSelection(new PromptSelectionOptions
				{
					MessageForAdding = "梁平法标注:"
				}, selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Entity entity = (Entity)transaction.GetObject(objectId, 1);
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcZXJD")]
		public void TcZXJD()
		{
			Point3dCollection point3dCollection = new Point3dCollection();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[2];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line");
				array2.SetValue(typedValue, 0);
				Array array3 = array;
				typedValue..ctor(8, "Dote,轴线");
				array3.SetValue(typedValue, 1);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Line line = (Line)transaction.GetObject(selectedObject.ObjectId, 0);
							try
							{
								foreach (object obj2 in value)
								{
									SelectedObject selectedObject2 = (SelectedObject)obj2;
									Line line2 = (Line)transaction.GetObject(selectedObject2.ObjectId, 0);
									Point3dCollection point3dCollection2 = new Point3dCollection();
									line.IntersectWith(line2, 0, new Plane(), point3dCollection2, IntPtr.Zero, IntPtr.Zero);
									if (point3dCollection2.Count >= 1)
									{
										point3dCollection.Add(point3dCollection2[0]);
									}
								}
							}
							finally
							{
								IEnumerator enumerator2;
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcZCCBZ")]
		public void TcZCCBZ()
		{
			Point3dCollection point3dCollection = new Point3dCollection();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[2];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line,LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				Array array3 = array;
				typedValue..ctor(8, "Dote,轴线,砼柱,柱边线,柱轮廓,柱");
				array3.SetValue(typedValue, 1);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					DBObjectCollection dbobjectCollection = new DBObjectCollection();
					DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							if (entity is Polyline)
							{
								dbobjectCollection.Add(entity);
							}
							else
							{
								dbobjectCollection2.Add(entity);
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					try
					{
						foreach (object obj2 in dbobjectCollection2)
						{
							Entity entity2 = (Entity)obj2;
							Line line = (Line)transaction.GetObject(entity2.ObjectId, 0);
							try
							{
								foreach (object obj3 in dbobjectCollection2)
								{
									Entity entity3 = (Entity)obj3;
									Line line2 = (Line)transaction.GetObject(entity3.ObjectId, 0);
									Point3dCollection point3dCollection2 = new Point3dCollection();
									line.IntersectWith(line2, 0, new Plane(), point3dCollection2, IntPtr.Zero, IntPtr.Zero);
									if (point3dCollection2.Count >= 1)
									{
										CAD.AddPoint(point3dCollection2[0]);
										point3dCollection.Add(point3dCollection2[0]);
									}
								}
							}
							finally
							{
								IEnumerator enumerator3;
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					try
					{
						foreach (object obj4 in dbobjectCollection)
						{
							Polyline pl = (Polyline)obj4;
							try
							{
								foreach (object obj5 in point3dCollection)
								{
									Point3d point3d;
									Point3d p = (obj5 != null) ? ((Point3d)obj5) : point3d;
									if (this.isPinPL(p, pl) == 1)
									{
										this.method_1(p, pl);
										break;
									}
								}
							}
							finally
							{
								IEnumerator enumerator5;
								if (enumerator5 is IDisposable)
								{
									(enumerator5 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator4;
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcZCCBZ1")]
		public void TcZCCBZ1()
		{
			Point3dCollection point3dCollection = new Point3dCollection();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[2];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line,LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				Array array3 = array;
				typedValue..ctor(8, "Dote,轴线,砼柱,柱边线,柱轮廓,柱");
				array3.SetValue(typedValue, 1);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					DBObjectCollection dbobjectCollection = new DBObjectCollection();
					DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							if (entity is Polyline)
							{
								dbobjectCollection.Add(entity);
							}
							else
							{
								dbobjectCollection2.Add(entity);
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					try
					{
						foreach (object obj2 in dbobjectCollection2)
						{
							Entity entity2 = (Entity)obj2;
							Line line = (Line)transaction.GetObject(entity2.ObjectId, 0);
							try
							{
								foreach (object obj3 in dbobjectCollection2)
								{
									Entity entity3 = (Entity)obj3;
									Line line2 = (Line)transaction.GetObject(entity3.ObjectId, 0);
									Point3dCollection point3dCollection2 = new Point3dCollection();
									line.IntersectWith(line2, 0, new Plane(), point3dCollection2, IntPtr.Zero, IntPtr.Zero);
									if (point3dCollection2.Count >= 1)
									{
										CAD.AddPoint(point3dCollection2[0]);
										point3dCollection.Add(point3dCollection2[0]);
									}
								}
							}
							finally
							{
								IEnumerator enumerator3;
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					try
					{
						foreach (object obj4 in dbobjectCollection)
						{
							Polyline pl = (Polyline)obj4;
							try
							{
								foreach (object obj5 in point3dCollection)
								{
									Point3d point3d;
									Point3d p = (obj5 != null) ? ((Point3d)obj5) : point3d;
									if (this.isPinPL(p, pl) >= 0)
									{
										this.method_2(p, pl);
										break;
									}
								}
							}
							finally
							{
								IEnumerator enumerator5;
								if (enumerator5 is IDisposable)
								{
									(enumerator5 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator4;
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcQCCBZ")]
		public void TcQCCBZ()
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
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\n选择墙身轮廓线:");
					PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity(promptEntityOptions);
					Entity entity2 = (Entity)transaction.GetObject(entity.ObjectId, 0);
					Point3d pickedPoint = entity.PickedPoint;
					if (Operators.CompareString(entity2.GetType().Name, "Polyline", false) != 0)
					{
						goto IL_AE4;
					}
					Polyline polyline = (Polyline)entity2;
					polyline.Highlight();
					Point3d point = CAD.GetPoint("选择轴线交叉点");
					Point3d point3d;
					if (point == point3d)
					{
						goto IL_AE4;
					}
					ObjectId objectId_ = CAD.CreateTextStyle("TC_Dim", "tssdeng.shx", "tssdchn.shx", 0.7);
					ObjectId dimID = Class36.smethod_79("Dim100", 100, 1.0, objectId_, false);
					Point3d minPoint = polyline.GeometricExtents.MinPoint;
					Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
					Point3d point3d2;
					point3d2..ctor(minPoint.X, minPoint.Y, 0.0);
					Point3d point3d3;
					point3d3..ctor(minPoint.X, point.Y, 0.0);
					Point3d point3d4;
					point3d4..ctor(minPoint.X, maxPoint.Y, 0.0);
					Point3d point3d5;
					point3d5..ctor(point.X, maxPoint.Y, 0.0);
					Point3d point3d6;
					point3d6..ctor(maxPoint.X, maxPoint.Y, 0.0);
					Point3d point3d7;
					point3d7..ctor(maxPoint.X, point.Y, 0.0);
					Point3d point3d8;
					point3d8..ctor(maxPoint.X, minPoint.Y, 0.0);
					Point3d point3d9;
					point3d9..ctor(point.X, minPoint.Y, 0.0);
					if (pickedPoint.X <= (minPoint.X + maxPoint.X) / 2.0 & pickedPoint.Y <= (minPoint.Y + maxPoint.Y) / 2.0)
					{
						Point3d alginP;
						if (Math.Abs(point3d2.DistanceTo(point3d3) - 100.0) > 10.0)
						{
							Point3d startP = point3d2;
							Point3d endP = point3d3;
							alginP..ctor(point3d2.X - 550.0, point3d2.Y, 0.0);
							CAD.AddLineDim(startP, endP, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d3.DistanceTo(point3d4) - 100.0) > 10.0)
						{
							Point3d startP2 = point3d3;
							Point3d endP2 = point3d4;
							alginP..ctor(point3d2.X - 550.0, point3d2.Y, 0.0);
							CAD.AddLineDim(startP2, endP2, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d2.DistanceTo(point3d9) - 100.0) > 10.0)
						{
							Point3d startP3 = point3d2;
							Point3d endP3 = point3d9;
							alginP..ctor(point3d2.X, point3d2.Y - 550.0, 0.0);
							CAD.AddLineDim(startP3, endP3, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d9.DistanceTo(point3d8) - 100.0) > 10.0)
						{
							Point3d startP4 = point3d9;
							Point3d endP4 = point3d8;
							alginP..ctor(point3d2.X, point3d2.Y - 550.0, 0.0);
							CAD.AddLineDim(startP4, endP4, alginP, 1.0, dimID, -1.0);
						}
					}
					else if (pickedPoint.X <= (minPoint.X + maxPoint.X) / 2.0 & pickedPoint.Y >= (minPoint.Y + maxPoint.Y) / 2.0)
					{
						Point3d alginP;
						if (Math.Abs(point3d2.DistanceTo(point3d3) - 100.0) > 10.0)
						{
							Point3d startP5 = point3d2;
							Point3d endP5 = point3d3;
							alginP..ctor(point3d4.X - 550.0, point3d4.Y, 0.0);
							CAD.AddLineDim(startP5, endP5, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d3.DistanceTo(point3d4) - 100.0) > 10.0)
						{
							Point3d startP6 = point3d3;
							Point3d endP6 = point3d4;
							alginP..ctor(point3d4.X - 550.0, point3d4.Y, 0.0);
							CAD.AddLineDim(startP6, endP6, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d4.DistanceTo(point3d5) - 100.0) > 10.0)
						{
							Point3d startP7 = point3d4;
							Point3d endP7 = point3d5;
							alginP..ctor(point3d4.X, point3d4.Y + 550.0, 0.0);
							CAD.AddLineDim(startP7, endP7, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d5.DistanceTo(point3d6) - 100.0) > 10.0)
						{
							Point3d startP8 = point3d5;
							Point3d endP8 = point3d6;
							alginP..ctor(point3d4.X, point3d4.Y + 550.0, 0.0);
							CAD.AddLineDim(startP8, endP8, alginP, 1.0, dimID, -1.0);
						}
					}
					else if (pickedPoint.X > (minPoint.X + maxPoint.X) / 2.0 & pickedPoint.Y > (minPoint.Y + maxPoint.Y) / 2.0)
					{
						Point3d alginP;
						if (Math.Abs(point3d4.DistanceTo(point3d5) - 100.0) > 10.0)
						{
							Point3d startP9 = point3d4;
							Point3d endP9 = point3d5;
							alginP..ctor(point3d6.X, point3d6.Y + 550.0, 0.0);
							CAD.AddLineDim(startP9, endP9, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d5.DistanceTo(point3d6) - 100.0) > 10.0)
						{
							Point3d startP10 = point3d5;
							Point3d endP10 = point3d6;
							alginP..ctor(point3d6.X, point3d6.Y + 550.0, 0.0);
							CAD.AddLineDim(startP10, endP10, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d8.DistanceTo(point3d7) - 100.0) > 10.0)
						{
							Point3d startP11 = point3d8;
							Point3d endP11 = point3d7;
							alginP..ctor(point3d6.X + 550.0, point3d6.Y, 0.0);
							CAD.AddLineDim(startP11, endP11, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d7.DistanceTo(point3d6) - 100.0) > 10.0)
						{
							Point3d startP12 = point3d7;
							Point3d endP12 = point3d6;
							alginP..ctor(point3d6.X + 550.0, point3d6.Y, 0.0);
							CAD.AddLineDim(startP12, endP12, alginP, 1.0, dimID, -1.0);
						}
					}
					else if (pickedPoint.X > (minPoint.X + maxPoint.X) / 2.0 & pickedPoint.Y < (minPoint.Y + maxPoint.Y) / 2.0)
					{
						Point3d alginP;
						if (Math.Abs(point3d8.DistanceTo(point3d7) - 100.0) > 10.0)
						{
							Point3d startP13 = point3d8;
							Point3d endP13 = point3d7;
							alginP..ctor(point3d8.X + 550.0, point3d8.Y, 0.0);
							CAD.AddLineDim(startP13, endP13, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d7.DistanceTo(point3d6) - 100.0) > 10.0)
						{
							Point3d startP14 = point3d7;
							Point3d endP14 = point3d6;
							alginP..ctor(point3d8.X + 550.0, point3d8.Y, 0.0);
							CAD.AddLineDim(startP14, endP14, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d2.DistanceTo(point3d9) - 100.0) > 10.0)
						{
							Point3d startP15 = point3d2;
							Point3d endP15 = point3d9;
							alginP..ctor(point3d8.X, point3d8.Y - 550.0, 0.0);
							CAD.AddLineDim(startP15, endP15, alginP, 1.0, dimID, -1.0);
						}
						if (Math.Abs(point3d9.DistanceTo(point3d8) - 100.0) > 10.0)
						{
							Point3d startP16 = point3d9;
							Point3d endP16 = point3d8;
							alginP..ctor(point3d8.X, point3d8.Y - 550.0, 0.0);
							CAD.AddLineDim(startP16, endP16, alginP, 1.0, dimID, -1.0);
						}
					}
					polyline.Unhighlight();
					transaction.Commit();
				}
				IL_A43:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_A68;
				}
				IL_A54:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_A68:
				goto IL_AE4;
				IL_A6A:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_A9E:
				goto IL_AD9;
				IL_AA0:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_A6A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_AB6:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_AA0;
			}
			IL_AD9:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_AE4:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQCCBZ1")]
		public void TcQCCBZ1()
		{
			Point3dCollection point3dCollection = new Point3dCollection();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[2];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line,LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				Array array3 = array;
				typedValue..ctor(8, "Dote,轴线,砼墙,墙边线,墙轮廓,墙");
				array3.SetValue(typedValue, 1);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					DBObjectCollection dbobjectCollection = new DBObjectCollection();
					DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							if (entity is Polyline)
							{
								dbobjectCollection.Add(entity);
							}
							else
							{
								dbobjectCollection2.Add(entity);
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					try
					{
						foreach (object obj2 in dbobjectCollection2)
						{
							Entity entity2 = (Entity)obj2;
							Line line = (Line)transaction.GetObject(entity2.ObjectId, 0);
							try
							{
								foreach (object obj3 in dbobjectCollection2)
								{
									Entity entity3 = (Entity)obj3;
									Line line2 = (Line)transaction.GetObject(entity3.ObjectId, 0);
									Point3dCollection point3dCollection2 = new Point3dCollection();
									line.IntersectWith(line2, 0, new Plane(), point3dCollection2, IntPtr.Zero, IntPtr.Zero);
									if (point3dCollection2.Count >= 1)
									{
										CAD.AddPoint(point3dCollection2[0]);
										point3dCollection.Add(point3dCollection2[0]);
									}
								}
							}
							finally
							{
								IEnumerator enumerator3;
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					try
					{
						foreach (object obj4 in dbobjectCollection)
						{
							Polyline pl = (Polyline)obj4;
							try
							{
								foreach (object obj5 in point3dCollection)
								{
									Point3d point3d;
									Point3d p = (obj5 != null) ? ((Point3d)obj5) : point3d;
									if (this.isPinPL(p, pl) == 1)
									{
										this.method_3(p, pl);
										break;
									}
								}
							}
							finally
							{
								IEnumerator enumerator5;
								if (enumerator5 is IDisposable)
								{
									(enumerator5 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator4;
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcPinPL")]
		public void TcPinPL()
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Polyline pl = null;
				IL_24:
				num2 = 5;
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
						pl = (Polyline)transaction.GetObject(value[0].ObjectId, 1);
					}
				}
				IL_B8:
				num2 = 7;
				Point3d point = CAD.GetPoint("选择轴线交叉点");
				IL_C6:
				num2 = 8;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_D8;
				}
				IL_D3:
				goto IL_21B;
				IL_D8:
				num2 = 11;
				short num3 = this.isPinPL(point, pl);
				IL_E7:
				num2 = 12;
				if (num3 != 1)
				{
					goto IL_103;
				}
				IL_F1:
				num2 = 13;
				Interaction.MsgBox("点在PL内", MsgBoxStyle.OkOnly, null);
				goto IL_139;
				IL_103:
				num2 = 15;
				if (num3 != -1)
				{
					goto IL_11F;
				}
				IL_10D:
				num2 = 16;
				Interaction.MsgBox("点不不不在PL内", MsgBoxStyle.OkOnly, null);
				goto IL_139;
				IL_11F:
				num2 = 18;
				if (num3 != 0)
				{
					goto IL_139;
				}
				IL_129:
				num2 = 19;
				Interaction.MsgBox("点在PL上", MsgBoxStyle.OkOnly, null);
				IL_139:
				num2 = 21;
				if (Information.Err().Number <= 0)
				{
					goto IL_160;
				}
				IL_14B:
				num2 = 22;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_160:
				goto IL_21B;
				IL_165:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_1D5:
				goto IL_210;
				IL_1D7:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_165;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1ED:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D7;
			}
			IL_210:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21B:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public bool method_1(Point3d P, Polyline PL)
		{
			Point3d minPoint = PL.GeometricExtents.MinPoint;
			Point3d maxPoint = PL.GeometricExtents.MaxPoint;
			Point3d point3d = minPoint;
			Point3d point3d2;
			point3d2..ctor(minPoint.X, P.Y, 0.0);
			Point3d point3d3;
			point3d3..ctor(minPoint.X, maxPoint.Y, 0.0);
			Point3d point3d4;
			point3d4..ctor(P.X, minPoint.Y, 0.0);
			Point3d point3d5;
			point3d5..ctor(maxPoint.X, minPoint.Y, 0.0);
			ObjectId objectId_ = CAD.CreateTextStyle("TC_Dim", "tssdeng.shx", "tssdchn.shx", 0.7);
			ObjectId dimID = Class36.smethod_79("Dim100", 100, 1.0, objectId_, false);
			Point3d startP = point3d;
			Point3d endP = point3d2;
			Point3d alginP;
			alginP..ctor(point3d.X - 550.0, point3d.Y, 0.0);
			CAD.AddLineDim(startP, endP, alginP, 1.0, dimID, -1.0);
			Point3d startP2 = point3d2;
			Point3d endP2 = point3d3;
			alginP..ctor(point3d.X - 550.0, point3d.Y, 0.0);
			CAD.AddLineDim(startP2, endP2, alginP, 1.0, dimID, -1.0);
			Point3d startP3 = point3d;
			Point3d endP3 = point3d4;
			alginP..ctor(point3d.X, point3d.Y - 550.0, 0.0);
			CAD.AddLineDim(startP3, endP3, alginP, 1.0, dimID, -1.0);
			Point3d startP4 = point3d4;
			Point3d endP4 = point3d5;
			alginP..ctor(point3d.X, point3d.Y - 550.0, 0.0);
			CAD.AddLineDim(startP4, endP4, alginP, 1.0, dimID, -1.0);
			return false;
		}

		public bool method_2(Point3d P, Polyline PL)
		{
			Point3d minPoint = PL.GeometricExtents.MinPoint;
			Point3d maxPoint = PL.GeometricExtents.MaxPoint;
			Point3d point3d = minPoint;
			Point3d point3d2;
			point3d2..ctor(minPoint.X, P.Y, 0.0);
			Point3d point3d3;
			point3d3..ctor(minPoint.X, maxPoint.Y, 0.0);
			Point3d point3d4;
			point3d4..ctor(P.X, minPoint.Y, 0.0);
			Point3d point3d5;
			point3d5..ctor(maxPoint.X, minPoint.Y, 0.0);
			Point3dCollection point3dCollection = new Point3dCollection();
			point3dCollection.Add(point3d);
			point3dCollection.Add(point3d2);
			point3dCollection.Add(point3d3);
			Point3d pointXY = CAD.GetPointXY(point3d, -1000.0, 0.0);
			this.AddTZBZ(point3dCollection, pointXY);
			Point3dCollection point3dCollection2 = new Point3dCollection();
			point3dCollection2.Add(point3d);
			point3dCollection2.Add(point3d4);
			point3dCollection2.Add(point3d5);
			Point3d pointXY2 = CAD.GetPointXY(point3d, 0.0, -1000.0);
			this.AddTZBZ(point3dCollection2, pointXY2);
			return false;
		}

		public bool method_3(Point3d P, Polyline PL)
		{
			Point3d minPoint = PL.GeometricExtents.MinPoint;
			Point3d maxPoint = PL.GeometricExtents.MaxPoint;
			Point3d point3d = minPoint;
			Point3d point3d2;
			point3d2..ctor(minPoint.X, P.Y, 0.0);
			Point3d point3d3;
			point3d3..ctor(minPoint.X, maxPoint.Y, 0.0);
			Point3d point3d4 = minPoint;
			Point3d point3d5;
			point3d5..ctor(P.X, minPoint.Y, 0.0);
			Point3d point3d6;
			point3d6..ctor(maxPoint.X, minPoint.Y, 0.0);
			ObjectId objectId_ = CAD.CreateTextStyle("TC_Dim", "tssdeng.shx", "tssdchn.shx", 0.7);
			ObjectId dimID = Class36.smethod_79("Dim100", 100, 1.0, objectId_, false);
			Point3d alginP;
			if (Math.Abs(point3d.DistanceTo(point3d2) - 100.0) > 10.0)
			{
				Point3d startP = point3d;
				Point3d endP = point3d2;
				alginP..ctor(point3d.X - 550.0, point3d.Y, 0.0);
				CAD.AddLineDim(startP, endP, alginP, 1.0, dimID, -1.0);
			}
			if (Math.Abs(point3d2.DistanceTo(point3d3) - 100.0) > 10.0)
			{
				Point3d startP2 = point3d2;
				Point3d endP2 = point3d3;
				alginP..ctor(point3d.X - 550.0, point3d.Y, 0.0);
				CAD.AddLineDim(startP2, endP2, alginP, 1.0, dimID, -1.0);
			}
			if (Math.Abs(point3d4.DistanceTo(point3d5) - 100.0) > 10.0)
			{
				Point3d startP3 = point3d4;
				Point3d endP3 = point3d5;
				alginP..ctor(point3d4.X, point3d4.Y - 550.0, 0.0);
				CAD.AddLineDim(startP3, endP3, alginP, 1.0, dimID, -1.0);
			}
			if (Math.Abs(point3d5.DistanceTo(point3d6) - 100.0) > 10.0)
			{
				Point3d startP4 = point3d5;
				Point3d endP4 = point3d6;
				alginP..ctor(point3d4.X, point3d4.Y - 550.0, 0.0);
				CAD.AddLineDim(startP4, endP4, alginP, 1.0, dimID, -1.0);
			}
			bool result;
			return result;
		}

		public short isPinPL(Point3d P, Polyline PL)
		{
			double num = 0.0;
			short result;
			try
			{
				PL.GetDistAtPoint(P);
				result = 0;
			}
			catch (Exception ex)
			{
				int num2 = 0;
				checked
				{
					int num3 = PL.NumberOfVertices - 1;
					int num4 = num2;
					for (;;)
					{
						int num5 = num4;
						int num6 = num3;
						if (num5 > num6)
						{
							break;
						}
						Point3d point3dAt = PL.GetPoint3dAt(num4);
						Point3d point3dAt2;
						if (num4 == PL.NumberOfVertices - 1)
						{
							point3dAt2 = PL.GetPoint3dAt(0);
						}
						else
						{
							point3dAt2 = PL.GetPoint3dAt(num4 + 1);
						}
						Vector3d vectorTo = P.GetVectorTo(point3dAt);
						Vector3d vectorTo2 = P.GetVectorTo(point3dAt2);
						double angleTo = vectorTo.GetAngleTo(vectorTo2);
						unchecked
						{
							num += angleTo;
						}
						num4++;
					}
				}
				if (num - 6.2831853071795862 < -0.0001)
				{
					result = -1;
				}
				else if (num - 6.2831853071795862 > -0.0001 & num - 6.2831853071795862 < 0.0001)
				{
					result = 0;
				}
				else
				{
					result = 1;
				}
			}
			return result;
		}

		[CommandMethod("TcTZBZ")]
		public void TcTZBZ()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			mdiActiveDocument.SendStringToExecute("_TDIMMP 0,0,0 0,500,0 200,500,0 0,1000,0 0,1500,0 0,2000,0  ", false, false, false);
		}

		public bool AddTZBZ(Point3dCollection P3dc, Point3d DuiQiP)
		{
			string text = "";
			Point3d point3d = P3dc[0];
			Point3d point3d2 = P3dc[1];
			text = string.Concat(new string[]
			{
				text,
				Conversions.ToString(point3d.X),
				",",
				Conversions.ToString(point3d.Y),
				",",
				Conversions.ToString(point3d.Z),
				" "
			});
			text = string.Concat(new string[]
			{
				text,
				Conversions.ToString(point3d2.X),
				",",
				Conversions.ToString(point3d2.Y),
				",",
				Conversions.ToString(point3d2.Z),
				" "
			});
			text = string.Concat(new string[]
			{
				text,
				Conversions.ToString(DuiQiP.X),
				",",
				Conversions.ToString(DuiQiP.Y),
				",",
				Conversions.ToString(DuiQiP.Z),
				" "
			});
			int num = 2;
			checked
			{
				int num2 = P3dc.Count - 1;
				int num3 = num;
				for (;;)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					Point3d point3d3 = P3dc[num3];
					text = string.Concat(new string[]
					{
						text,
						Conversions.ToString(point3d3.X),
						",",
						Conversions.ToString(point3d3.Y),
						",",
						Conversions.ToString(point3d3.Z),
						" "
					});
					num3++;
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				mdiActiveDocument.SendStringToExecute("_TDIMMP " + text + " ", false, false, false);
				bool result;
				return result;
			}
		}

		[CommandMethod("TcBZBR1")]
		public void TcBZBR1()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Dimension");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					DBObjectCollection dbobjectCollection = new DBObjectCollection();
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
							dbobjectCollection.Add(entity);
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					this.Dim_PaiXu(ref dbobjectCollection);
					long num = 0L;
					try
					{
						foreach (object obj2 in dbobjectCollection)
						{
							Entity entity2 = (Entity)obj2;
							Dimension dimension = (Dimension)entity2;
							double dimtxt = dimension.Dimtxt;
							double dimscale = dimension.Dimscale;
							string text = dimension.DimensionText;
							if (Operators.CompareString(text, "", false) == 0)
							{
								text = Strings.Format(dimension.Measurement, "0");
							}
							DBText dbtext = new DBText();
							dbtext.TextString = text;
							dbtext.Height = dimtxt * dimscale;
							dbtext.TextStyleId = dimension.TextStyleId;
							DBText dbtext2 = dbtext;
							Point3d maxPoint;
							maxPoint..ctor(0.0, 0.0, 0.0);
							dbtext2.Position = maxPoint;
							maxPoint = dbtext.GeometricExtents.MaxPoint;
							double num2 = maxPoint.X - dbtext.GeometricExtents.MinPoint.X;
							Point3dCollection point3dCollection = new Point3dCollection();
							dimension.GetStretchPoints(point3dCollection);
							Point3d point3d = point3dCollection[2];
							Point3d point3d2 = point3dCollection[3];
							double num3 = point3d.DistanceTo(point3d2);
							Point3d point3d3;
							point3d3..ctor((point3d.X + point3d2.X) / 2.0, (point3d.Y + point3d2.Y) / 2.0, (point3d.Z + point3d2.Z) / 2.0);
							double num4 = point3dCollection[2].GetVectorTo(point3dCollection[3]).AngleOnPlane(new Plane());
							if (num2 > num3 * 0.9)
							{
								if (num == 0L)
								{
									Point3d pointRadian = CAD.GetPointRadian(dimension.TextPosition, (num3 + num2) * 1.1 / 2.0, num4 + 3.1415926535897931);
									dimension.TextPosition = pointRadian;
								}
								else if (num % 2L == 1L & num != (long)(checked(dbobjectCollection.Count - 1)))
								{
									double num5 = point3d3.DistanceTo(dimension.TextPosition);
									Point3d pointRadian2 = CAD.GetPointRadian(dimension.TextPosition, 2.0 * num5, num4 - 1.5707963267948966);
									dimension.TextPosition = pointRadian2;
								}
								else if (num % 2L == 0L & num != (long)(checked(dbobjectCollection.Count - 1)))
								{
									double l = point3d3.DistanceTo(dimension.TextPosition);
									Point3d pointRadian3 = CAD.GetPointRadian(dimension.TextPosition, l, num4 + 1.5707963267948966);
									dimension.TextPosition = pointRadian3;
								}
								else if (num == (long)(checked(dbobjectCollection.Count - 1)))
								{
									Point3d pointRadian4 = CAD.GetPointRadian(dimension.TextPosition, (num3 + num2) * 1.1 / 2.0, num4);
									dimension.TextPosition = pointRadian4;
								}
							}
							checked
							{
								num += 1L;
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
			}
			if (Information.Err().Number > 0)
			{
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			}
		}

		[CommandMethod("TcBZBR")]
		public void TcBZBR()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Dimension");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						objectIdCollection.Add(objectId);
					}
					ObjectIdCollection objectIdCollection2 = new ObjectIdCollection();
					try
					{
						foreach (object obj in objectIdCollection)
						{
							ObjectId objectId2;
							Class36.objectId_0 = ((obj != null) ? ((ObjectId)obj) : objectId2);
							Entity entity = (Entity)transaction.GetObject(Class36.objectId_0, 1);
							DBObjectCollection dbobjectCollection = new DBObjectCollection();
							this.GetFuJinDim((Dimension)entity, entity.Layer, 1.0, ref dbobjectCollection);
							this.Dim_PaiXu(ref dbobjectCollection);
							long num = 0L;
							try
							{
								foreach (object obj2 in dbobjectCollection)
								{
									Entity entity2 = (Entity)obj2;
									if (!objectIdCollection2.Contains(entity2.ObjectId))
									{
										objectIdCollection2.Add(entity2.ObjectId);
										Dimension dimension = (Dimension)entity2;
										double dimtxt = dimension.Dimtxt;
										double dimscale = dimension.Dimscale;
										string text = dimension.DimensionText;
										if (Operators.CompareString(text, "", false) == 0)
										{
											text = Strings.Format(dimension.Measurement, "0");
										}
										DBText dbtext = new DBText();
										dbtext.TextString = text;
										dbtext.Height = dimtxt * dimscale;
										dbtext.TextStyleId = dimension.TextStyleId;
										DBText dbtext2 = dbtext;
										Point3d maxPoint;
										maxPoint..ctor(0.0, 0.0, 0.0);
										dbtext2.Position = maxPoint;
										maxPoint = dbtext.GeometricExtents.MaxPoint;
										double num2 = maxPoint.X - dbtext.GeometricExtents.MinPoint.X;
										Point3dCollection point3dCollection = new Point3dCollection();
										dimension.GetStretchPoints(point3dCollection);
										Point3d point3d = point3dCollection[2];
										Point3d point3d2 = point3dCollection[3];
										double num3 = point3d.DistanceTo(point3d2);
										Point3d point3d3;
										point3d3..ctor((point3d.X + point3d2.X) / 2.0, (point3d.Y + point3d2.Y) / 2.0, (point3d.Z + point3d2.Z) / 2.0);
										double num4 = point3dCollection[2].GetVectorTo(point3dCollection[3]).AngleOnPlane(new Plane());
										if (num2 > num3)
										{
											if (num == 0L)
											{
												Point3d pointRadian = CAD.GetPointRadian(dimension.TextPosition, (num3 + num2) * 1.1 / 2.0, num4 + 3.1415926535897931);
												dimension.TextPosition = pointRadian;
											}
											else if (num % 2L == 1L & num != (long)(checked(dbobjectCollection.Count - 1)))
											{
												double num5 = point3d3.DistanceTo(dimension.TextPosition);
												Point3d pointRadian2 = CAD.GetPointRadian(dimension.TextPosition, 2.0 * num5, num4 - 1.5707963267948966);
												dimension.TextPosition = pointRadian2;
											}
											else if (num % 2L == 0L & num != (long)(checked(dbobjectCollection.Count - 1)))
											{
												double l = point3d3.DistanceTo(dimension.TextPosition);
												Point3d pointRadian3 = CAD.GetPointRadian(dimension.TextPosition, l, num4 + 1.5707963267948966);
												dimension.TextPosition = pointRadian3;
											}
											else if (num == (long)(checked(dbobjectCollection.Count - 1)))
											{
												Point3d pointRadian4 = CAD.GetPointRadian(dimension.TextPosition, (num3 + num2) * 1.1 / 2.0, num4);
												dimension.TextPosition = pointRadian4;
											}
										}
										checked
										{
											num += 1L;
										}
									}
								}
							}
							finally
							{
								IEnumerator enumerator2;
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
			}
			if (Information.Err().Number > 0)
			{
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			}
		}

		public string method_4(Point3d Pa1, Point3d Pa2, Point3d Pb1, Point3d Pb2)
		{
			Line line = new Line(Pa1, Pa2);
			Line line2 = new Line(Pb1, Pb2);
			double num = Math.Tan(line.Angle);
			double num2 = Math.Tan(line2.Angle);
			string result;
			if (Math.Abs(num - num2) < 0.0001)
			{
				Line line3 = new Line();
				if (line.StartPoint.DistanceTo(line2.StartPoint) > 0.0)
				{
					line3 = new Line(line.StartPoint, line2.StartPoint);
				}
				else
				{
					line3 = new Line(line.StartPoint, line2.EndPoint);
				}
				double num3 = Math.Tan(line3.Angle);
				if (Math.Abs(num) > 10000.0 & Math.Abs(num2) > 10000.0 & Math.Abs(num3) > 10000.0)
				{
					result = "-";
				}
				else if (Math.Abs(num - num3) < 0.0001)
				{
					result = "-";
				}
				else
				{
					result = "=";
				}
			}
			else if (num != num2 & num * num2 + 1.0 < 0.01)
			{
				result = "+";
			}
			else if (Math.Abs(num) < 0.0001 & num2 > 10000.0)
			{
				result = "+";
			}
			else if (Math.Abs(num2) < 0.0001 & num > 10000.0)
			{
				result = "+";
			}
			else
			{
				result = "x";
			}
			return result;
		}

		public bool GetFuJinDim(Dimension Ent, string LayerName, double Dist, ref DBObjectCollection DBC)
		{
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "Dimension");
			array2.SetValue(typedValue, 0);
			if (Operators.CompareString(LayerName, "", false) != 0)
			{
				array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[2]);
				Array array3 = array;
				typedValue..ctor(8, LayerName);
				array3.SetValue(typedValue, 1);
			}
			Point3d maxPoint = Ent.GeometricExtents.MaxPoint;
			Point3d minPoint = Ent.GeometricExtents.MinPoint;
			Point3dCollection point3dCollection = new Point3dCollection();
			Point3dCollection point3dCollection2 = point3dCollection;
			Point3d point3d;
			point3d..ctor(minPoint.X - Dist, minPoint.Y - Dist, 0.0);
			point3dCollection2.Add(point3d);
			Point3dCollection point3dCollection3 = point3dCollection;
			point3d..ctor(minPoint.X - Dist, maxPoint.Y + Dist, 0.0);
			point3dCollection3.Add(point3d);
			Point3dCollection point3dCollection4 = point3dCollection;
			point3d..ctor(maxPoint.X + Dist, maxPoint.Y + Dist, 0.0);
			point3dCollection4.Add(point3d);
			Point3dCollection point3dCollection5 = point3dCollection;
			point3d..ctor(maxPoint.X + Dist, minPoint.Y - Dist, 0.0);
			point3dCollection5.Add(point3d);
			Point3dCollection point3dCollection6 = new Point3dCollection();
			Ent.GetStretchPoints(point3dCollection6);
			Point3d pa = point3dCollection6[2];
			Point3d pa2 = point3dCollection6[3];
			point3d = point3dCollection6[2];
			point3d.GetVectorTo(point3dCollection6[3]).AngleOnPlane(new Plane());
			DBObjectCollection dbobjectCollection = CAD.CrossingPolygon(point3dCollection, array);
			if (dbobjectCollection.Count >= 1)
			{
				try
				{
					foreach (object obj in dbobjectCollection)
					{
						Dimension dimension = (Dimension)obj;
						if (!DBC.Contains(dimension))
						{
							Point3dCollection point3dCollection7 = new Point3dCollection();
							dimension.GetStretchPoints(point3dCollection7);
							Point3d pb = point3dCollection7[2];
							Point3d pb2 = point3dCollection7[3];
							point3d = point3dCollection7[2];
							point3d.GetVectorTo(point3dCollection7[3]).AngleOnPlane(new Plane());
							string left = this.method_4(pa, pa2, pb, pb2);
							if (Operators.CompareString(left, "-", false) == 0)
							{
								DBC.Add(dimension);
								this.GetFuJinDim(dimension, LayerName, Dist, ref DBC);
							}
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			bool result;
			return result;
		}

		public double GetDimA(Dimension D)
		{
			Point3dCollection point3dCollection = new Point3dCollection();
			D.GetStretchPoints(point3dCollection);
			Point3d point3d = point3dCollection[2];
			Point3d point3d2 = point3dCollection[3];
			return point3dCollection[2].GetVectorTo(point3dCollection[3]).AngleOnPlane(new Plane());
		}

		public bool Dim_PaiXu(ref DBObjectCollection DimC)
		{
			double num = 0.0;
			long num2 = 0L;
			long num3 = (long)(checked(DimC.Count - 1));
			long num4 = num2;
			Dimension dimension3;
			double dimA;
			checked
			{
				for (;;)
				{
					long num5 = num4;
					long num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					Dimension dimension = (Dimension)DimC[(int)num4];
					Point3d textPosition = dimension.TextPosition;
					long num7 = 0L;
					long num8 = unchecked((long)(checked(DimC.Count - 1)));
					long num9 = num7;
					for (;;)
					{
						long num10 = num9;
						num6 = num8;
						if (num10 > num6)
						{
							break;
						}
						Dimension dimension2 = (Dimension)DimC[(int)num9];
						Point3d textPosition2 = dimension2.TextPosition;
						num = Math.Max(num, textPosition.DistanceTo(textPosition2));
						num9 += 1L;
					}
					num4 += 1L;
				}
				dimension3 = (Dimension)DimC[0];
				dimA = this.GetDimA(dimension3);
			}
			Point3d pointAR_Radian = CAD.GetPointAR_Radian(dimension3.TextPosition, dimA + 3.1415926535897931, 2.0 * num);
			long num11 = 0L;
			long num12 = (long)(checked(DimC.Count - 1));
			long num13 = num11;
			checked
			{
				for (;;)
				{
					long num14 = num13;
					long num6 = num12;
					if (num14 > num6)
					{
						break;
					}
					Dimension dimension4 = (Dimension)DimC[(int)num13];
					double num15 = dimension4.TextPosition.DistanceTo(pointAR_Radian);
					long num16 = 0L;
					long num17 = unchecked((long)(checked(DimC.Count - 1)));
					long num18 = num16;
					for (;;)
					{
						long num19 = num18;
						num6 = num17;
						if (num19 > num6)
						{
							break;
						}
						Dimension dimension5 = (Dimension)DimC[(int)num18];
						double num20 = dimension5.TextPosition.DistanceTo(pointAR_Radian);
						if (num20 > num15)
						{
							DBObject dbobject = DimC[(int)num18];
							DimC[(int)num18] = DimC[(int)num13];
							DimC[(int)num13] = dbobject;
						}
						num18 += 1L;
					}
					num13 += 1L;
				}
				bool result;
				return result;
			}
		}

		[CommandMethod("TcQZCCBZ1")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void method_5()
		{
			int num;
			int num19;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "Tc_QZCCBZ", "BiLi", "4");
				IL_2F:
				num2 = 3;
				string text = Interaction.InputBox("输入PL线放大比例", Class33.Class31_0.Info.ProductName, Conversions.ToString(Conversion.Val(setting)), -1, -1);
				IL_58:
				num2 = 4;
				if (Operators.CompareString(text, "", false) != 0)
				{
					goto IL_70;
				}
				IL_6B:
				goto IL_4B6;
				IL_70:
				num2 = 7;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "Tc_QZCCBZ", "BiLi", Conversions.ToString(Conversion.Val(text)));
				IL_9B:
				num2 = 8;
				Conversion.Val(text);
				IL_A4:
				num2 = 9;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_B3:
				num2 = 10;
				Database database = mdiActiveDocument.Database;
				IL_BF:
				num2 = 11;
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
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Entity entity = (Entity)transaction.GetObject(objectId, 1);
							Polyline polyline = (Polyline)entity;
							double[] array3 = new double[2];
							double[] array4 = new double[2];
							array3[0] = polyline.GeometricExtents.MinPoint.X;
							array3[1] = polyline.GeometricExtents.MaxPoint.X;
							array4[0] = polyline.GeometricExtents.MinPoint.Y;
							double[] array5 = array4;
							int num3 = 1;
							Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
							array5[num3] = maxPoint.Y;
							short num4 = checked((short)(polyline.NumberOfVertices - 1));
							short num5 = 0;
							short num6 = num4;
							short num7 = num5;
							for (;;)
							{
								short num8 = num7;
								short num9 = num6;
								if (num8 > num9)
								{
									break;
								}
								Point3d point3dAt = polyline.GetPoint3dAt((int)num7);
								this.AddX(ref array3, point3dAt.X);
								this.AddX(ref array4, point3dAt.Y);
								num7 += 1;
							}
							Array.Sort<double>(array3);
							Array.Sort<double>(array4);
							ObjectId objectId_ = CAD.CreateTextStyle("TC_Dim", "tssdeng.shx", "tssdchn.shx", 0.7);
							ObjectId dimID = Class36.smethod_79("Dim100", 100, 1.0, objectId_, false);
							short num10 = 0;
							Point3d point3d;
							Point3d point3d2;
							short num15;
							short num16;
							checked
							{
								short num11 = (short)(array3.Length - 2);
								short num12 = num10;
								for (;;)
								{
									short num13 = num12;
									short num9 = num11;
									if (num13 > num9)
									{
										break;
									}
									maxPoint..ctor(array3[(int)num12], array4[0], 0.0);
									Point3d startP = maxPoint;
									point3d..ctor(array3[(int)(num12 + 1)], array4[0], 0.0);
									Point3d endP = point3d;
									unchecked
									{
										point3d2..ctor(array3[(int)num12], array4[0] - 550.0, 0.0);
										CAD.AddLineDim(startP, endP, point3d2, 1.0 / Conversions.ToDouble(text), dimID, -1.0);
										num12 += 1;
									}
								}
								short num14 = 0;
								num15 = (short)(array4.Length - 2);
								num16 = num14;
							}
							for (;;)
							{
								short num17 = num16;
								short num9 = num15;
								if (num17 > num9)
								{
									break;
								}
								point3d2..ctor(array3[0], array4[(int)num16], 0.0);
								Point3d startP2 = point3d2;
								point3d..ctor(array3[0], array4[(int)(checked(num16 + 1))], 0.0);
								Point3d endP2 = point3d;
								maxPoint..ctor(array3[0] - 550.0, array4[(int)num16], 0.0);
								CAD.AddLineDim(startP2, endP2, maxPoint, 1.0 / Conversions.ToDouble(text), dimID, -1.0);
								num16 += 1;
							}
						}
						transaction.Commit();
					}
				}
				IL_3F4:
				num2 = 13;
				if (Information.Err().Number <= 0)
				{
					goto IL_41B;
				}
				IL_406:
				num2 = 14;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_41B:
				goto IL_4B6;
				IL_420:
				int num18 = num19 + 1;
				num19 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num18);
				IL_470:
				goto IL_4AB;
				IL_472:
				num19 = num2;
				if (num <= -2)
				{
					goto IL_420;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_488:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num19 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_472;
			}
			IL_4AB:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_4B6:
			if (num19 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQZCCBZ")]
		public void TcQZCCBZ()
		{
			int num;
			int num19;
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
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				string text = Conversions.ToString(Application.GetSystemVariable("USERS5"));
				IL_32:
				num2 = 5;
				if (Operators.CompareString(text, "", false) != 0)
				{
					goto IL_4F;
				}
				IL_46:
				num2 = 6;
				text = "2";
				IL_4F:
				num2 = 8;
				PromptDoubleOptions promptDoubleOptions = new PromptDoubleOptions("\n输入PL线放大比例");
				IL_5D:
				num2 = 9;
				promptDoubleOptions.AllowNone = true;
				IL_68:
				num2 = 10;
				promptDoubleOptions.AllowZero = false;
				IL_73:
				num2 = 11;
				promptDoubleOptions.DefaultValue = Conversion.Val(text);
				IL_84:
				num2 = 12;
				PromptDoubleResult @double = mdiActiveDocument.Editor.GetDouble(promptDoubleOptions);
				IL_96:
				num2 = 13;
				if (@double.Status != 5100)
				{
					goto IL_C9;
				}
				IL_A9:
				num2 = 14;
				double value = @double.Value;
				IL_B5:
				num2 = 15;
				Application.SetSystemVariable("USERS5", value);
				IL_C9:
				num2 = 17;
				if (value != 0.0)
				{
					goto IL_E0;
				}
				IL_DB:
				goto IL_504;
				IL_E0:
				num2 = 20;
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
						SelectionSet value2 = selection.Value;
						Polyline polyline = (Polyline)transaction.GetObject(value2[0].ObjectId, 1);
						double[] array3 = new double[2];
						double[] array4 = new double[2];
						array3[0] = polyline.GeometricExtents.MinPoint.X;
						array3[1] = polyline.GeometricExtents.MaxPoint.X;
						array4[0] = polyline.GeometricExtents.MinPoint.Y;
						double[] array5 = array4;
						int num3 = 1;
						Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
						array5[num3] = maxPoint.Y;
						foreach (ObjectId objectId in value2.GetObjectIds())
						{
							polyline = (Polyline)transaction.GetObject(objectId, 1);
							short num4 = checked((short)(polyline.NumberOfVertices - 1));
							short num5 = 0;
							short num6 = num4;
							short num7 = num5;
							for (;;)
							{
								short num8 = num7;
								short num9 = num6;
								if (num8 > num9)
								{
									break;
								}
								Point3d point3dAt = polyline.GetPoint3dAt((int)num7);
								this.AddX(ref array3, point3dAt.X);
								this.AddX(ref array4, point3dAt.Y);
								num7 += 1;
							}
							Array.Sort<double>(array3);
							Array.Sort<double>(array4);
						}
						ObjectId objectId_ = CAD.CreateTextStyle("TC_Dim", "tssdeng.shx", "tssdchn.shx", 0.7);
						ObjectId dimID = Class36.smethod_79("Dim100", 100, 1.0, objectId_, false);
						short num10 = 0;
						Point3d point3d;
						Point3d point3d2;
						short num15;
						short num16;
						checked
						{
							short num11 = (short)(array3.Length - 2);
							short num12 = num10;
							for (;;)
							{
								short num13 = num12;
								short num9 = num11;
								if (num13 > num9)
								{
									break;
								}
								maxPoint..ctor(array3[(int)num12], array4[0], 0.0);
								Point3d startP = maxPoint;
								point3d..ctor(array3[(int)(num12 + 1)], array4[0], 0.0);
								Point3d endP = point3d;
								unchecked
								{
									point3d2..ctor(array3[(int)num12], array4[0] - 550.0, 0.0);
									CAD.AddLineDim(startP, endP, point3d2, 1.0 / value, dimID, -1.0);
									num12 += 1;
								}
							}
							short num14 = 0;
							num15 = (short)(array4.Length - 2);
							num16 = num14;
						}
						for (;;)
						{
							short num17 = num16;
							short num9 = num15;
							if (num17 > num9)
							{
								break;
							}
							point3d2..ctor(array3[0], array4[(int)num16], 0.0);
							Point3d startP2 = point3d2;
							point3d..ctor(array3[0], array4[(int)(checked(num16 + 1))], 0.0);
							Point3d endP2 = point3d;
							maxPoint..ctor(array3[0] - 550.0, array4[(int)num16], 0.0);
							CAD.AddLineDim(startP2, endP2, maxPoint, 1.0 / value, dimID, -1.0);
							num16 += 1;
						}
						transaction.Commit();
					}
				}
				IL_41E:
				num2 = 22;
				if (Information.Err().Number <= 0)
				{
					goto IL_445;
				}
				IL_430:
				num2 = 23;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_445:
				goto IL_504;
				IL_44A:
				int num18 = num19 + 1;
				num19 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num18);
				IL_4BE:
				goto IL_4F9;
				IL_4C0:
				num19 = num2;
				if (num <= -2)
				{
					goto IL_44A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4D6:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num19 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4C0;
			}
			IL_4F9:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_504:
			if (num19 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQZCCBZ2")]
		public void method_6()
		{
			int num;
			int num20;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double num3 = 550.0;
				IL_15:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_22:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_2C:
				num2 = 5;
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
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							Entity entity = (Entity)transaction.GetObject(objectId, 1);
							Polyline polyline = (Polyline)entity;
							double[] array3 = new double[2];
							double[] array4 = new double[2];
							array3[0] = polyline.GeometricExtents.MinPoint.X;
							array3[1] = polyline.GeometricExtents.MaxPoint.X;
							array4[0] = polyline.GeometricExtents.MinPoint.Y;
							double[] array5 = array4;
							int num4 = 1;
							Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
							array5[num4] = maxPoint.Y;
							short num5 = checked((short)(polyline.NumberOfVertices - 1));
							short num6 = 0;
							short num7 = num5;
							short num8 = num6;
							for (;;)
							{
								short num9 = num8;
								short num10 = num7;
								if (num9 > num10)
								{
									break;
								}
								Point3d point3dAt = polyline.GetPoint3dAt((int)num8);
								this.AddX(ref array3, point3dAt.X);
								this.AddX(ref array4, point3dAt.Y);
								num8 += 1;
							}
							Array.Sort<double>(array3);
							Array.Sort<double>(array4);
							Point3dCollection point3dCollection = new Point3dCollection();
							Point3dCollection point3dCollection2 = new Point3dCollection();
							short num11 = 0;
							short num12 = checked((short)(array3.Length - 2));
							short num13 = num11;
							for (;;)
							{
								short num14 = num13;
								short num10 = num12;
								if (num14 > num10)
								{
									break;
								}
								Point3dCollection point3dCollection3 = point3dCollection;
								maxPoint..ctor(array3[(int)num13], array4[0], 0.0);
								point3dCollection3.Add(maxPoint);
								Point3dCollection point3dCollection4 = point3dCollection;
								maxPoint..ctor(array3[(int)(checked(num13 + 1))], array4[0], 0.0);
								point3dCollection4.Add(maxPoint);
								num13 += 1;
							}
							Point3d duiQiP;
							duiQiP..ctor(array3[0], array4[0] - num3, 0.0);
							short num15 = 0;
							short num16 = checked((short)(array4.Length - 2));
							short num17 = num15;
							for (;;)
							{
								short num18 = num17;
								short num10 = num16;
								if (num18 > num10)
								{
									break;
								}
								Point3dCollection point3dCollection5 = point3dCollection2;
								maxPoint..ctor(array3[0], array4[(int)num17], 0.0);
								point3dCollection5.Add(maxPoint);
								Point3dCollection point3dCollection6 = point3dCollection2;
								maxPoint..ctor(array3[0], array4[(int)(checked(num17 + 1))], 0.0);
								point3dCollection6.Add(maxPoint);
								num17 += 1;
							}
							Point3d duiQiP2;
							duiQiP2..ctor(array3[0] - num3, array4[0], 0.0);
							this.AddTZBZ(point3dCollection, duiQiP);
							this.AddTZBZ(point3dCollection2, duiQiP2);
						}
						transaction.Commit();
					}
				}
				IL_306:
				num2 = 7;
				if (Information.Err().Number <= 0)
				{
					goto IL_32B;
				}
				IL_317:
				num2 = 8;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_32B:
				goto IL_3AB;
				IL_32D:
				int num19 = num20 + 1;
				num20 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num19);
				IL_365:
				goto IL_3A0;
				IL_367:
				num20 = num2;
				if (num <= -2)
				{
					goto IL_32D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_37D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num20 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_367;
			}
			IL_3A0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3AB:
			if (num20 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public double AddX(ref double[] xx, double x)
		{
			int num;
			int num8;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				short num2;
				short num4;
				short num5;
				checked
				{
					num2 = (short)xx.Length;
					short num3 = 0;
					num4 = num2 - 1;
					num5 = num3;
				}
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					if (Conversion.Int(x) == Conversion.Int(xx[(int)num5]))
					{
						goto IL_59;
					}
					num5 += 1;
				}
				IL_37:
				xx = (double[])Utils.CopyArray((Array)xx, new double[(int)(checked(num2 + 1))]);
				xx[(int)num2] = x;
				IL_59:
				goto IL_9E;
				IL_5B:
				num8 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_70:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_5B;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_9E:
			double num9;
			double result = num9;
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		[CommandMethod("TcExplode")]
		public void TcExplode()
		{
			int num;
			int num4;
			object obj3;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3C:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "INSERT");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_65:
				num2 = 8;
				PromptSelectionResult selection = editor.GetSelection(selectionFilter);
				IL_72:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_7E:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						Transaction transaction2 = transaction;
						object obj2 = NewLateBinding.LateGet(objectValue, null, "ObjectId", new object[0], null, null, null);
						ObjectId objectId;
						BlockReference blockReference = (BlockReference)transaction2.GetObject((obj2 != null) ? ((ObjectId)obj2) : objectId, 1);
						blockReference.ExplodeToOwnerSpace();
						blockReference.Erase();
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_12B:
				num2 = 12;
				if (Information.Err().Number <= 0)
				{
				}
				IL_13D:
				goto IL_1D0;
				IL_142:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_18A:
				goto IL_1C5;
				IL_18C:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_142;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1A2:;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_18C;
			}
			IL_1C5:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1D0:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcExplodeAtt")]
		public void TcExplodeAtt()
		{
			int num;
			int num5;
			object obj4;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3C:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "INSERT,ATTDEF");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_65:
				num2 = 8;
				PromptSelectionResult selection = editor.GetSelection(selectionFilter);
				IL_72:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_7E:
				num2 = 10;
				checked
				{
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							object objectValue = RuntimeHelpers.GetObjectValue(obj);
							Transaction transaction2 = transaction;
							object obj2 = NewLateBinding.LateGet(objectValue, null, "ObjectId", new object[0], null, null, null);
							ObjectId objectId;
							Entity entity = (Entity)transaction2.GetObject((obj2 != null) ? ((ObjectId)obj2) : objectId, 1);
							if (Operators.CompareString(entity.GetRXClass().DxfName, "INSERT", false) == 0)
							{
								BlockReference blockReference = (BlockReference)entity;
								AttributeCollection attributeCollection = blockReference.AttributeCollection;
								if (attributeCollection.Count == 1)
								{
									blockReference.ExplodeToOwnerSpace();
									blockReference.Erase();
								}
								else
								{
									DBObjectCollection dbobjectCollection = new DBObjectCollection();
									blockReference.Explode(dbobjectCollection);
									long num3 = 0L;
									IEnumerator enumerator2 = dbobjectCollection.GetEnumerator();
									while (enumerator2.MoveNext())
									{
										object obj3 = enumerator2.Current;
										DBObject dbobject = (DBObject)obj3;
										Entity entity2 = (Entity)dbobject;
										if (Operators.CompareString(entity2.GetRXClass().DxfName, "ATTDEF", false) == 0)
										{
											DBText dbtext = new DBText();
											AttributeReference attributeReference = (AttributeReference)transaction.GetObject(attributeCollection[(int)num3], 1, false);
											dbtext.TextString = attributeReference.TextString;
											dbtext.WidthFactor = attributeReference.WidthFactor;
											dbtext.Height = attributeReference.Height;
											dbtext.TextStyleId = attributeReference.TextStyleId;
											dbtext.LayerId = attributeReference.LayerId;
											dbtext.LinetypeId = attributeReference.LinetypeId;
											dbtext.Position = attributeReference.Position;
											CAD.AddEnt(dbtext);
											num3 += 1L;
										}
										else
										{
											CAD.AddEnt(entity2);
										}
									}
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
									blockReference.Erase();
								}
							}
							else
							{
								DBText dbtext2 = new DBText();
								AttributeDefinition attributeDefinition = (AttributeDefinition)entity;
								dbtext2.TextString = attributeDefinition.TextString;
								dbtext2.WidthFactor = attributeDefinition.WidthFactor;
								dbtext2.Height = attributeDefinition.Height;
								dbtext2.TextStyleId = attributeDefinition.TextStyleId;
								dbtext2.LayerId = attributeDefinition.LayerId;
								dbtext2.LinetypeId = attributeDefinition.LinetypeId;
								dbtext2.Position = attributeDefinition.Position;
								CAD.AddEnt(dbtext2);
								entity.Erase();
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						transaction.Commit();
					}
					IL_329:
					num2 = 12;
					if (Information.Err().Number <= 0)
					{
					}
					IL_33B:
					goto IL_3CE;
					IL_340:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_388:
				goto IL_3C3;
				IL_38A:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_340;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_3A0:;
			}
			catch when (endfilter(obj4 is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj5;
				goto IL_38A;
			}
			IL_3C3:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3CE:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcExplodeAll")]
		public void ExplodeAllBlock()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "INSERT,ATTDEF");
			array2.SetValue(typedValue, 0);
			SelectionFilter selectionFilter = new SelectionFilter(array);
			PromptSelectionResult promptSelectionResult = editor.SelectAll(selectionFilter);
			SelectionSet value = promptSelectionResult.Value;
			checked
			{
				if (value != null)
				{
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						try
						{
							foreach (object obj in value)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(obj);
								Transaction transaction2 = transaction;
								object obj2 = NewLateBinding.LateGet(objectValue, null, "ObjectId", new object[0], null, null, null);
								ObjectId objectId;
								Entity entity = (Entity)transaction2.GetObject((obj2 != null) ? ((ObjectId)obj2) : objectId, 1);
								if (Operators.CompareString(entity.GetRXClass().DxfName, "INSERT", false) != 0)
								{
									goto IL_272;
								}
								Transaction transaction3 = transaction;
								object obj3 = NewLateBinding.LateGet(objectValue, null, "ObjectId", new object[0], null, null, null);
								BlockReference blockReference = (BlockReference)transaction3.GetObject((obj3 != null) ? ((ObjectId)obj3) : objectId, 1);
								AttributeCollection attributeCollection = blockReference.AttributeCollection;
								if (attributeCollection.Count != 0)
								{
									DBObjectCollection dbobjectCollection = new DBObjectCollection();
									blockReference.Explode(dbobjectCollection);
									long num = 0L;
									try
									{
										foreach (object obj4 in dbobjectCollection)
										{
											DBObject dbobject = (DBObject)obj4;
											Entity entity2 = (Entity)dbobject;
											if (Operators.CompareString(entity2.GetRXClass().DxfName, "ATTDEF", false) == 0)
											{
												DBText dbtext = new DBText();
												AttributeReference attributeReference = (AttributeReference)transaction.GetObject(attributeCollection[(int)num], 1);
												dbtext.TextString = attributeReference.TextString;
												dbtext.WidthFactor = attributeReference.WidthFactor;
												dbtext.Height = attributeReference.Height;
												dbtext.TextStyleId = attributeReference.TextStyleId;
												dbtext.LayerId = attributeReference.LayerId;
												dbtext.LinetypeId = attributeReference.LinetypeId;
												dbtext.Position = attributeReference.Position;
												CAD.AddEnt(dbtext);
												num += 1L;
											}
											else
											{
												CAD.AddEnt(entity2);
											}
										}
										goto IL_2EC;
									}
									finally
									{
										IEnumerator enumerator2;
										if (enumerator2 is IDisposable)
										{
											(enumerator2 as IDisposable).Dispose();
										}
									}
									goto IL_272;
								}
								blockReference.ExplodeToOwnerSpace();
								IL_2EC:
								entity.Erase();
								continue;
								IL_272:
								DBText dbtext2 = new DBText();
								AttributeDefinition attributeDefinition = (AttributeDefinition)entity;
								dbtext2.TextString = attributeDefinition.TextString;
								dbtext2.WidthFactor = attributeDefinition.WidthFactor;
								dbtext2.Height = attributeDefinition.Height;
								dbtext2.TextStyleId = attributeDefinition.TextStyleId;
								dbtext2.LayerId = attributeDefinition.LayerId;
								dbtext2.LinetypeId = attributeDefinition.LinetypeId;
								dbtext2.Position = attributeDefinition.Position;
								CAD.AddEnt(dbtext2);
								goto IL_2EC;
							}
						}
						finally
						{
							IEnumerator enumerator;
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						transaction.Commit();
					}
					this.ExplodeAllBlock();
				}
			}
		}

		[CommandMethod("TcQLZXX")]
		public void TcQLZXX()
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_17:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_21:
				num2 = 4;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_34:
				num2 = 5;
				TypedValue[] array = new TypedValue[2];
				IL_3D:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "line");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				Array array3 = array;
				typedValue..ctor(8, "梁虚线,砼梁");
				array3.SetValue(typedValue, 1);
				IL_77:
				num2 = 8;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_81:
				num2 = 9;
				PromptSelectionResult selection = editor.GetSelection(selectionFilter);
				IL_8F:
				num2 = 10;
				SelectionSet value = selection.Value;
				IL_9B:
				num2 = 11;
				ObjectId[] objectIds = value.GetObjectIds();
				IL_A7:
				num2 = 12;
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				IL_B1:
				num2 = 13;
				long num3 = 0L;
				long num4 = (long)objectIds.GetUpperBound(0);
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
						IL_CC:
						num2 = 14;
						objectIdCollection.Add(objectIds[(int)num5]);
						IL_E6:
						num2 = 15;
						num5 += 1L;
					}
					IL_101:
					num2 = 16;
					this.QLZXX(ref objectIdCollection);
					IL_10C:
					num2 = 17;
					if (Information.Err().Number <= 0)
					{
						goto IL_133;
					}
					IL_11E:
					num2 = 18;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_133:
					goto IL_1D9;
					IL_138:
					goto IL_1E3;
					IL_13D:
					num8 = num2;
					if (num <= -2)
					{
						goto IL_154;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_1B4;
					IL_154:;
				}
				int num9 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1B4:
				goto IL_1E3;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_13D;
			}
			IL_1D9:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_1E3:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public void QLZXX(ref ObjectIdCollection IDC)
		{
			CAD.CreateLayer("墙梁中心线", 1, "continuous", -1, false, true);
			long num = 800L;
			if (IDC.Count > 1)
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Line line = (Line)transaction.GetObject(IDC[0], 0);
					Point3d entCenter = CAD.GetEntCenter(line);
					short num2 = checked((short)Math.Round(Math.Round(unchecked(line.Angle * 180.0) / 3.1415926535897931)));
					double num3 = double.MaxValue;
					ObjectId objectId = line.ObjectId;
					ObjectId objectId2 = default(ObjectId);
					Point3d point3d = default(Point3d);
					Point3d point3d2 = default(Point3d);
					Line line2 = null;
					long num4 = 1L;
					long num5 = (long)(checked(IDC.Count - 1));
					long num6 = num4;
					checked
					{
						for (;;)
						{
							long num7 = num6;
							long num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							Line line3 = (Line)transaction.GetObject(IDC[(int)num6], 0);
							short num9 = (short)Math.Round(Math.Round(unchecked(line3.Angle * 180.0) / 3.1415926535897931));
							if (num9 == num2 | Math.Abs(unchecked(num9 - num2)) == 180)
							{
								Point3d entCenter2 = CAD.GetEntCenter(line3);
								double num10 = entCenter.DistanceTo(entCenter2);
								if (num10 < num3)
								{
									num3 = num10;
									objectId2 = line3.ObjectId;
									point3d = entCenter2;
									line2 = line3;
								}
							}
							num6 += 1L;
						}
					}
					Point3d point3d3;
					if (point3d != point3d3)
					{
						if (num3 <= (double)num)
						{
							IDC.Remove(objectId);
							IDC.Remove(objectId2);
							Point3d point3d4;
							Point3d point3d5;
							if (line.StartPoint.X < line.EndPoint.X)
							{
								point3d4 = line.StartPoint;
								point3d5 = line.EndPoint;
							}
							else if (line.StartPoint.X == line.EndPoint.X)
							{
								point3d4 = line.GeometricExtents.MinPoint;
								point3d5 = line.GeometricExtents.MaxPoint;
							}
							else
							{
								point3d4 = line.EndPoint;
								point3d5 = line.StartPoint;
							}
							Point3d startPoint = line2.StartPoint;
							double x = startPoint.X;
							Point3d endPoint = line2.EndPoint;
							Point3d point3d6;
							Point3d point3d7;
							if (x < endPoint.X)
							{
								point3d6 = line2.StartPoint;
								point3d7 = line2.EndPoint;
							}
							else
							{
								startPoint = line2.StartPoint;
								double x2 = startPoint.X;
								endPoint = line2.EndPoint;
								if (x2 == endPoint.X)
								{
									point3d6 = line2.GeometricExtents.MinPoint;
									point3d7 = line2.GeometricExtents.MaxPoint;
								}
								else
								{
									point3d6 = line2.EndPoint;
									point3d7 = line2.StartPoint;
								}
							}
							startPoint..ctor((point3d4.X + point3d6.X) / 2.0, (point3d4.Y + point3d6.Y) / 2.0, (point3d4.Z + point3d6.Z) / 2.0);
							Point3d p = startPoint;
							endPoint..ctor((point3d5.X + point3d7.X) / 2.0, (point3d5.Y + point3d7.Y) / 2.0, (point3d5.Z + point3d7.Z) / 2.0);
							ObjectId objectId3 = CAD.AddLine(p, endPoint, "0").ObjectId;
							CAD.ChangeLayer(objectId3, "墙梁中心线");
						}
						else
						{
							IDC.Remove(objectId);
						}
					}
					else
					{
						IDC.Remove(objectId);
					}
					transaction.Commit();
				}
				this.QLZXX(ref IDC);
			}
		}

		public double Point2LineDistance(Point3d P, Line L)
		{
			double[] array = (double[])NF.P2LineP(P.ToArray(), L.StartPoint.ToArray(), L.EndPoint.ToArray());
			Point3d p;
			p..ctor(array[0], array[1], array[2]);
			CAD.AddPoint(p);
			Interaction.MsgBox(string.Concat(new string[]
			{
				Conversions.ToString(p.X),
				" ",
				Conversions.ToString(p.Y),
				"  ",
				Conversions.ToString(p.Z),
				"\r\n",
				Conversions.ToString(P.X),
				" ",
				Conversions.ToString(P.Y),
				"  ",
				Conversions.ToString(P.Z)
			}), MsgBoxStyle.OkOnly, null);
			return p.DistanceTo(P);
		}

		public Point3d Point2LineCuiZu(Point3d P, Line L)
		{
			double[] array = (double[])NF.P2LineP(L.StartPoint.ToArray(), L.EndPoint.ToArray(), P.ToArray());
			Point3d result;
			result..ctor(array[0], array[1], array[2]);
			return result;
		}

		[CommandMethod("TcJoinLine")]
		public void TcJoinLine()
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_17:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_21:
				num2 = 4;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_34:
				num2 = 5;
				TypedValue[] array = new TypedValue[2];
				IL_3D:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "line");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				Array array3 = array;
				typedValue..ctor(8, "墙梁中心线,0");
				array3.SetValue(typedValue, 1);
				IL_77:
				num2 = 8;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_81:
				num2 = 9;
				PromptSelectionResult selection = editor.GetSelection(selectionFilter);
				IL_8F:
				num2 = 10;
				SelectionSet value = selection.Value;
				IL_9B:
				num2 = 11;
				ObjectId[] objectIds = value.GetObjectIds();
				IL_A7:
				num2 = 12;
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				IL_B0:
				num2 = 13;
				long num3 = 0L;
				long num4 = (long)objectIds.GetUpperBound(0);
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
						IL_CB:
						num2 = 14;
						objectIdCollection.Add(objectIds[(int)num5]);
						IL_E4:
						num2 = 15;
						num5 += 1L;
					}
					IL_FF:
					num2 = 16;
					this.JoinLine(ref objectIdCollection);
					IL_10A:
					num2 = 17;
					if (Information.Err().Number <= 0)
					{
						goto IL_131;
					}
					IL_11C:
					num2 = 18;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_131:
					goto IL_1DB;
					IL_136:
					goto IL_1E6;
					IL_13B:
					num8 = num2;
					if (num <= -2)
					{
						goto IL_153;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_1B5;
					IL_153:;
				}
				int num9 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1B5:
				goto IL_1E6;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_13B;
			}
			IL_1DB:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_1E6:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public void JoinLine(ref ObjectIdCollection IDC)
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
				double num3 = 800.0;
				IL_15:
				num2 = 3;
				if (IDC.Count <= 1)
				{
					goto IL_31B;
				}
				IL_26:
				num2 = 4;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_33:
				num2 = 5;
				Database database = mdiActiveDocument.Database;
				IL_3D:
				num2 = 6;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num4 = 0L;
					long num5 = (long)(checked(IDC.Count - 2));
					long num6 = num4;
					checked
					{
						for (;;)
						{
							long num7 = num6;
							long num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							Line line = (Line)transaction.GetObject(IDC[(int)num6], 1);
							long num9 = 1L;
							long num10 = unchecked((long)(checked(IDC.Count - 1)));
							long num11 = num9;
							for (;;)
							{
								long num12 = num11;
								num8 = num10;
								if (num12 > num8)
								{
									break;
								}
								Line line2 = (Line)transaction.GetObject(IDC[(int)num11], 1);
								long num13 = this.method_7(line, line2);
								unchecked
								{
									if (num13 == 10L | num13 == 2L)
									{
										Point3dCollection point3dCollection = new Point3dCollection();
										line.IntersectWith(line2, 3, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
										if (point3dCollection.Count >= 1)
										{
											Point3d point3d = point3dCollection[0];
											double num14 = point3d.DistanceTo(line2.StartPoint);
											double num15 = point3d.DistanceTo(line2.EndPoint);
											if (num14 + num15 > line2.Length)
											{
												if (num14 <= num3 & num14 > 0.0)
												{
													line2.StartPoint = point3d;
												}
												if (num15 <= num3 & num15 > 0.0)
												{
													line2.EndPoint = point3d;
												}
											}
											num14 = point3d.DistanceTo(line.StartPoint);
											num15 = point3d.DistanceTo(line.EndPoint);
											if (num14 + num15 > line.Length)
											{
												if (num14 <= num3 & num14 > 0.0)
												{
													line.StartPoint = point3d;
												}
												if (num15 <= num3 & num15 > 0.0)
												{
													line.EndPoint = point3d;
												}
											}
										}
									}
									else if (num13 == 1L)
									{
										if (line.StartPoint.DistanceTo(line2.StartPoint) < num3)
										{
											line.StartPoint = line2.StartPoint;
										}
										if (line.StartPoint.DistanceTo(line2.EndPoint) < num3)
										{
											line.StartPoint = line2.EndPoint;
										}
										if (line.EndPoint.DistanceTo(line2.StartPoint) < num3)
										{
											line.EndPoint = line2.StartPoint;
										}
										if (line.EndPoint.DistanceTo(line2.EndPoint) < num3)
										{
											line.EndPoint = line2.EndPoint;
										}
									}
								}
								num11 += 1L;
							}
							num6 += 1L;
						}
						transaction.Commit();
					}
				}
				IL_31B:
				goto IL_397;
				IL_31D:
				int num16 = num17 + 1;
				num17 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num16);
				IL_351:
				goto IL_38C;
				IL_353:
				num17 = num2;
				if (num <= -2)
				{
					goto IL_31D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_369:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num17 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_353;
			}
			IL_38C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_397:
			if (num17 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public void JoinLine1(ref ObjectIdCollection IDC)
		{
			int num;
			int num11;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				CAD.CreateLayer("墙梁中心线", 1, "continuous", -1, false, true);
				IL_1F:
				num2 = 3;
				double num3 = 800.0;
				IL_2B:
				num2 = 4;
				if (IDC.Count <= 1)
				{
					goto IL_374;
				}
				IL_3C:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_49:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_53:
				num2 = 7;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Line line = (Line)transaction.GetObject(IDC[0], 1);
					long num4 = 1L;
					long num5 = (long)(checked(IDC.Count - 1));
					long num6 = num4;
					checked
					{
						Line line2;
						Line line3;
						for (;;)
						{
							long num7 = num6;
							long num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							line2 = (Line)transaction.GetObject(IDC[(int)num6], 1);
							long num9 = this.method_7(line, line2);
							if (num9 == 1L)
							{
								line3 = new Line();
								line3.Layer = line.Layer;
								if (line.StartPoint.DistanceTo(line2.StartPoint) <= num3)
								{
									goto IL_198;
								}
								if (line.StartPoint.DistanceTo(line2.EndPoint) <= num3)
								{
									goto IL_206;
								}
								if (line.EndPoint.DistanceTo(line2.EndPoint) <= num3)
								{
									goto IL_274;
								}
								if (line.EndPoint.DistanceTo(line2.StartPoint) <= num3)
								{
									goto IL_2DF;
								}
								IDC.Remove(line2.ObjectId);
							}
							num6 += 1L;
						}
						goto IL_348;
						IL_198:
						line3 = new Line(line.EndPoint, line2.EndPoint);
						CAD.AddEnt(line3);
						IDC.Add(line3.ObjectId);
						IDC.Remove(line.ObjectId);
						IDC.Remove(line2.ObjectId);
						Class36.smethod_64(line.ObjectId);
						Class36.smethod_64(line2.ObjectId);
						transaction.Commit();
						goto IL_348;
						IL_206:
						line3 = new Line(line.EndPoint, line2.StartPoint);
						CAD.AddEnt(line3);
						IDC.Add(line3.ObjectId);
						IDC.Remove(line.ObjectId);
						IDC.Remove(line2.ObjectId);
						Class36.smethod_64(line.ObjectId);
						Class36.smethod_64(line2.ObjectId);
						transaction.Commit();
						goto IL_348;
						IL_274:
						line3 = new Line(line.StartPoint, line2.StartPoint);
						CAD.AddEnt(line3);
						IDC.Add(line3.ObjectId);
						IDC.Remove(line.ObjectId);
						IDC.Remove(line2.ObjectId);
						Class36.smethod_64(line.ObjectId);
						Class36.smethod_64(line2.ObjectId);
						transaction.Commit();
						goto IL_348;
						IL_2DF:
						line3 = new Line(line.StartPoint, line2.EndPoint);
						CAD.AddEnt(line3);
						IDC.Add(line3.ObjectId);
						IDC.Remove(line.ObjectId);
						IDC.Remove(line2.ObjectId);
						Class36.smethod_64(line.ObjectId);
						Class36.smethod_64(line2.ObjectId);
						transaction.Commit();
						IL_348:
						IDC.Remove(line.ObjectId);
					}
				}
				IL_36A:
				num2 = 9;
				this.JoinLine(ref IDC);
				IL_374:
				goto IL_3FB;
				IL_379:
				int num10 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_3B5:
				goto IL_3F0;
				IL_3B7:
				num11 = num2;
				if (num <= -2)
				{
					goto IL_379;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_3CD:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_3B7;
			}
			IL_3F0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3FB:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public static bool 直线方程一般式_3D(Point3d P1, Point3d P2, ref double A, ref double B, ref double C)
		{
			A = P2.Y - P1.Y;
			B = P1.X - P2.X;
			C = P2.X * P1.Y - P1.X * P2.Y;
			return false;
		}

		[CommandMethod("Tc2Line")]
		public void Tc2Line()
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3C:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "line");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_65:
				num2 = 8;
				PromptSelectionResult selection = editor.GetSelection(selectionFilter);
				IL_72:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_7E:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Line line = (Line)transaction.GetObject(value[0].ObjectId, 0);
					Line line2 = (Line)transaction.GetObject(value[1].ObjectId, 0);
					Class36.smethod_60("L1A: " + Conversions.ToString(line.Angle));
					Class36.smethod_60("L2A: " + Conversions.ToString(line2.Angle));
					double num3 = Math.Tan(line.Angle);
					double num4 = Math.Tan(line2.Angle);
					Class36.smethod_60("L1斜率: " + Conversions.ToString(num3));
					Class36.smethod_60("L2斜率: " + Conversions.ToString(num4));
					Class36.smethod_60("L1-L2斜率: " + Conversions.ToString(Math.Abs(num3 - num4)));
					if (Math.Abs(num3 - num4) < 0.0001)
					{
						Line line3 = new Line();
						if (line.StartPoint.DistanceTo(line2.StartPoint) > 0.0)
						{
							line3 = new Line(line.StartPoint, line2.StartPoint);
						}
						else
						{
							line3 = new Line(line.StartPoint, line2.EndPoint);
						}
						double num5 = Math.Tan(line3.Angle);
						Class36.smethod_60("L3斜率: " + Conversions.ToString(num5));
						if (Math.Abs(num3 - num5) < 0.0001)
						{
							Interaction.MsgBox("两条直线重合 ", MsgBoxStyle.OkOnly, null);
						}
						else
						{
							Interaction.MsgBox("两条直线平行 ", MsgBoxStyle.OkOnly, null);
						}
					}
					else if (Math.Abs(num3) > 10000.0 & Math.Abs(num4) > 10000.0)
					{
						Line line4 = new Line();
						if (line.StartPoint.DistanceTo(line2.StartPoint) > 0.0)
						{
							line4 = new Line(line.StartPoint, line2.StartPoint);
						}
						else
						{
							line4 = new Line(line.StartPoint, line2.EndPoint);
						}
						double num6 = Math.Tan(line4.Angle);
						if (Math.Abs(num3 - num6) < 0.0001)
						{
							Interaction.MsgBox("两条直线重合 ", MsgBoxStyle.OkOnly, null);
						}
						else
						{
							Interaction.MsgBox("两条直线平行 ", MsgBoxStyle.OkOnly, null);
						}
					}
					else if (num3 != num4 & num3 * num4 + 1.0 < 0.0001)
					{
						Interaction.MsgBox("两条直线垂直", MsgBoxStyle.OkOnly, null);
					}
					else if (Math.Abs(num3) < 0.0001 & num4 > 10000.0)
					{
						Interaction.MsgBox("两条直线垂直", MsgBoxStyle.OkOnly, null);
					}
					else if (Math.Abs(num4) < 0.0001 & num3 > 10000.0)
					{
						Interaction.MsgBox("两条直线垂直", MsgBoxStyle.OkOnly, null);
					}
					else
					{
						Interaction.MsgBox("两条直线相交", MsgBoxStyle.OkOnly, null);
					}
					transaction.Commit();
				}
				IL_3C1:
				num2 = 12;
				if (Information.Err().Number <= 0)
				{
					goto IL_3E8;
				}
				IL_3D3:
				num2 = 13;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_3E8:
				goto IL_47F;
				IL_3ED:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_439:
				goto IL_474;
				IL_43B:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_3ED;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_451:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_43B;
			}
			IL_474:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_47F:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public long method_7(Line L1, Line L2)
		{
			int num;
			long num6;
			int num8;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double num3 = Math.Tan(L1.Angle);
				IL_17:
				num2 = 3;
				double num4 = Math.Tan(L2.Angle);
				IL_25:
				num2 = 4;
				if (Math.Abs(num3 - num4) >= 0.0001)
				{
					goto IL_EF;
				}
				IL_3F:
				num2 = 5;
				Line line = new Line();
				IL_48:
				num2 = 6;
				if (L1.StartPoint.DistanceTo(L2.StartPoint) <= 0.0)
				{
					goto IL_83;
				}
				IL_6C:
				num2 = 7;
				line = new Line(L1.StartPoint, L2.StartPoint);
				goto IL_9C;
				IL_83:
				num2 = 9;
				IL_86:
				num2 = 10;
				line = new Line(L1.StartPoint, L2.EndPoint);
				IL_9C:
				num2 = 12;
				double num5 = Math.Tan(line.Angle);
				IL_AD:
				num2 = 13;
				if (Math.Abs(num3 - num5) >= 0.0001)
				{
					goto IL_D9;
				}
				IL_C6:
				num2 = 14;
				num6 = 1L;
				goto IL_3A3;
				IL_D9:
				num2 = 16;
				IL_DC:
				num2 = 17;
				num6 = 11L;
				goto IL_3A3;
				IL_EF:
				num2 = 20;
				if (!(Math.Abs(num3) > 10000.0 & Math.Abs(num4) > 10000.0))
				{
					goto IL_1CB;
				}
				IL_11A:
				num2 = 21;
				Line line2 = new Line();
				IL_124:
				num2 = 22;
				if (L1.StartPoint.DistanceTo(L2.StartPoint) <= 0.0)
				{
					goto IL_161;
				}
				IL_149:
				num2 = 23;
				line2 = new Line(L1.StartPoint, L2.StartPoint);
				goto IL_17A;
				IL_161:
				num2 = 25;
				IL_164:
				num2 = 26;
				line2 = new Line(L1.StartPoint, L2.EndPoint);
				IL_17A:
				num2 = 28;
				double value = Math.Tan(line2.Angle);
				IL_18B:
				num2 = 29;
				if (Math.Abs(value) <= 10000.0)
				{
					goto IL_1B5;
				}
				IL_1A2:
				num2 = 30;
				num6 = 1L;
				goto IL_3A3;
				IL_1B5:
				num2 = 32;
				IL_1B8:
				num2 = 33;
				num6 = 11L;
				goto IL_3A3;
				IL_1CB:
				num2 = 36;
				if (!(num3 != num4 & num3 * num4 + 1.0 < 0.0001))
				{
					goto IL_203;
				}
				IL_1F0:
				num2 = 37;
				num6 = 10L;
				goto IL_3A3;
				IL_203:
				num2 = 39;
				if (!(Math.Abs(num3) < 0.0001 & num4 > 10000.0))
				{
					goto IL_239;
				}
				IL_226:
				num2 = 40;
				num6 = 10L;
				goto IL_3A3;
				IL_239:
				num2 = 42;
				if (!(Math.Abs(num4) < 0.0001 & num3 > 10000.0))
				{
					goto IL_26F;
				}
				IL_25C:
				num2 = 43;
				num6 = 10L;
				goto IL_3A3;
				IL_26F:
				num2 = 45;
				IL_272:
				num2 = 46;
				num6 = 2L;
				IL_285:
				goto IL_3A3;
				IL_28A:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_35A:
				goto IL_398;
				IL_35C:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_28A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_375:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_35C;
			}
			IL_398:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3A3:
			long result = num6;
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		[CommandMethod("TcPLDaDuan")]
		public void method_8()
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
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3C:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_65:
				num2 = 8;
				PromptSelectionResult selection = editor.GetSelection(selectionFilter);
				IL_72:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_7E:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Polyline pl = (Polyline)transaction.GetObject(value[0].ObjectId, 1);
					Polyline polyline = (Polyline)transaction.GetObject(value[1].ObjectId, 1);
					ArrayList arrayList = new ArrayList();
					this.method_9(pl, polyline, ref arrayList);
					Class36.smethod_64(polyline.ObjectId);
					transaction.Commit();
				}
				IL_102:
				num2 = 12;
				if (Information.Err().Number <= 0)
				{
					goto IL_129;
				}
				IL_114:
				num2 = 13;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_129:
				goto IL_1C0;
				IL_12E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_17A:
				goto IL_1B5;
				IL_17C:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_12E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_192:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_17C;
			}
			IL_1B5:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1C0:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public object method_9(Curve PL1, Curve PL2, ref ArrayList STR)
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
				Point3dCollection point3dCollection = new Point3dCollection();
				IL_11:
				num2 = 3;
				PL1.IntersectWith(PL2, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
				IL_2B:
				num2 = 4;
				if (!point3dCollection.Contains(PL2.StartPoint))
				{
					goto IL_49;
				}
				IL_3B:
				num2 = 5;
				point3dCollection.Remove(PL2.StartPoint);
				IL_49:
				num2 = 7;
				if (!point3dCollection.Contains(PL2.EndPoint))
				{
					goto IL_67;
				}
				IL_59:
				num2 = 8;
				point3dCollection.Remove(PL2.EndPoint);
				IL_67:
				num2 = 10;
				if (point3dCollection.Count < 1)
				{
					goto IL_20E;
				}
				IL_7B:
				num2 = 11;
				DBObjectCollection dbobjectCollection = PL2.GetSplitCurves(point3dCollection);
				IL_87:
				num2 = 12;
				IEnumerator enumerator = dbobjectCollection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Curve curve = (Curve)enumerator.Current;
					IL_AD:
					num2 = 13;
					point3dCollection = new Point3dCollection();
					IL_B6:
					num2 = 14;
					dbobjectCollection = new DBObjectCollection();
					IL_C0:
					num2 = 15;
					PL1.IntersectWith(curve, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
					IL_DC:
					num2 = 16;
					if (point3dCollection.Contains(PL2.StartPoint))
					{
						IL_ED:
						num2 = 17;
						point3dCollection.Remove(PL2.StartPoint);
					}
					IL_FC:
					num2 = 19;
					if (point3dCollection.Contains(PL2.EndPoint))
					{
						IL_10D:
						num2 = 20;
						point3dCollection.Remove(PL2.EndPoint);
					}
					IL_11C:
					num2 = 22;
					if (point3dCollection.Count >= 1)
					{
						IL_130:
						num2 = 23;
						dbobjectCollection = curve.GetSplitCurves(point3dCollection);
						IL_13D:
						num2 = 24;
						if (dbobjectCollection.Count >= 2)
						{
							IL_14F:
							num2 = 25;
							this.method_9(PL1, curve, ref STR);
						}
						else
						{
							IL_162:
							num2 = 27;
							IL_165:
							num2 = 28;
							string text = curve.StartPoint.ToString() + curve.EndPoint.ToString() + curve.Area.ToString() + curve.GetDistAtPoint(curve.EndPoint).ToString();
							IL_1C2:
							num2 = 29;
							if (!STR.Contains(text))
							{
								IL_1D3:
								num2 = 30;
								STR.Add(text);
								IL_1E0:
								num2 = 31;
								CAD.AddEnt(curve);
							}
						}
					}
					IL_1EB:
					num2 = 35;
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_20E:
				num2 = 37;
				if (Information.Err().Number <= 0)
				{
					goto IL_235;
				}
				IL_220:
				num2 = 38;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_235:
				goto IL_331;
				IL_23A:
				goto IL_33D;
				IL_23F:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_259;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_30C;
				IL_259:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_30C:
				goto IL_33D;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_23F;
			}
			IL_331:
			object obj3;
			object result = obj3;
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
			IL_33D:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcBoundary")]
		public void TcBoundary()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptSelectionResult selection = editor.GetSelection();
			SelectionSet value = selection.Value;
			new ArrayList();
			Point3d point3d = default(Point3d);
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			new ObjectIdCollection();
			checked
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					ObjectId[] objectIds = value.GetObjectIds();
					for (int i = 0; i < objectIds.Length; i++)
					{
						Class36.objectId_0 = objectIds[i];
						Entity entity = (Entity)transaction.GetObject(Class36.objectId_0, 1);
						Point3d minPoint = entity.GeometricExtents.MinPoint;
						Point3d maxPoint = entity.GeometricExtents.MaxPoint;
						Point3d p;
						p..ctor(minPoint.X, maxPoint.Y, minPoint.Z);
						Point3d p2;
						p2..ctor(maxPoint.X, minPoint.Y, minPoint.Z);
						Point3dCollection point3dCollection = new Point3dCollection();
						entity.GetStretchPoints(point3dCollection);
						DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
						double dist = 50.0;
						Point3d point3d2;
						try
						{
							foreach (object obj in point3dCollection)
							{
								Point3d p3 = (obj != null) ? ((Point3d)obj) : point3d2;
								dbobjectCollection2 = this.PointBoundary(p3, dist);
								try
								{
									foreach (object obj2 in dbobjectCollection2)
									{
										DBObject dbobject = (DBObject)obj2;
										dbobjectCollection.Add(dbobject);
									}
								}
								finally
								{
									IEnumerator enumerator2;
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
							}
						}
						finally
						{
							IEnumerator enumerator;
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						IntegerCollection integerCollection = new IntegerCollection();
						IntegerCollection integerCollection2 = new IntegerCollection();
						entity.GetGripPoints(point3dCollection, integerCollection, integerCollection2);
						try
						{
							foreach (object obj3 in point3dCollection)
							{
								Point3d p4 = (obj3 != null) ? ((Point3d)obj3) : point3d2;
								dbobjectCollection2 = this.PointBoundary(p4, dist);
								try
								{
									foreach (object obj4 in dbobjectCollection2)
									{
										DBObject dbobject2 = (DBObject)obj4;
										dbobjectCollection.Add(dbobject2);
									}
								}
								finally
								{
									IEnumerator enumerator4;
									if (enumerator4 is IDisposable)
									{
										(enumerator4 as IDisposable).Dispose();
									}
								}
							}
						}
						finally
						{
							IEnumerator enumerator3;
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						dbobjectCollection2 = this.PointBoundary(minPoint, dist);
						try
						{
							foreach (object obj5 in dbobjectCollection2)
							{
								DBObject dbobject3 = (DBObject)obj5;
								dbobjectCollection.Add(dbobject3);
							}
						}
						finally
						{
							IEnumerator enumerator5;
							if (enumerator5 is IDisposable)
							{
								(enumerator5 as IDisposable).Dispose();
							}
						}
						dbobjectCollection2 = this.PointBoundary(maxPoint, dist);
						try
						{
							foreach (object obj6 in dbobjectCollection2)
							{
								DBObject dbobject4 = (DBObject)obj6;
								dbobjectCollection.Add(dbobject4);
							}
						}
						finally
						{
							IEnumerator enumerator6;
							if (enumerator6 is IDisposable)
							{
								(enumerator6 as IDisposable).Dispose();
							}
						}
						dbobjectCollection2 = this.PointBoundary(p, dist);
						try
						{
							foreach (object obj7 in dbobjectCollection2)
							{
								DBObject dbobject5 = (DBObject)obj7;
								dbobjectCollection.Add(dbobject5);
							}
						}
						finally
						{
							IEnumerator enumerator7;
							if (enumerator7 is IDisposable)
							{
								(enumerator7 as IDisposable).Dispose();
							}
						}
						dbobjectCollection2 = this.PointBoundary(p2, dist);
						try
						{
							foreach (object obj8 in dbobjectCollection2)
							{
								DBObject dbobject6 = (DBObject)obj8;
								dbobjectCollection.Add(dbobject6);
							}
						}
						finally
						{
							IEnumerator enumerator8;
							if (enumerator8 is IDisposable)
							{
								(enumerator8 as IDisposable).Dispose();
							}
						}
					}
					Entity entity2 = (Entity)dbobjectCollection[0];
					Polyline object_ = entity2 as Polyline;
					Region region = Class36.smethod_53(object_);
					try
					{
						foreach (object obj9 in dbobjectCollection)
						{
							Entity entity3 = (Entity)obj9;
							Polyline object_2 = entity3 as Polyline;
							Region region2 = Class36.smethod_53(object_2);
							region.BooleanOperation(0, region2);
						}
					}
					finally
					{
						IEnumerator enumerator9;
						if (enumerator9 is IDisposable)
						{
							(enumerator9 as IDisposable).Dispose();
						}
					}
					region.Highlight();
					transaction.Commit();
				}
				if (Information.Err().Number > 0)
				{
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				}
			}
		}

		[CommandMethod("TcBoundary2")]
		public void TcBoundary2()
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\n选择一个参照快: ");
				IL_40:
				num2 = 6;
				promptEntityOptions.SetRejectMessage("仅可选择一个参照快 !");
				IL_4E:
				num2 = 7;
				promptEntityOptions.AddAllowedClass(typeof(BlockReference), false);
				IL_63:
				num2 = 8;
				PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
				IL_70:
				num2 = 9;
				if (entity.Status == 5100)
				{
					goto IL_8B;
				}
				IL_86:
				goto IL_328;
				IL_8B:
				num2 = 12;
				ObjectId objectId = entity.ObjectId;
				IL_97:
				num2 = 13;
				Point3d p2;
				Polyline polyline;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Entity entity2 = (Entity)transaction.GetObject(objectId, 0);
					if (entity2 == null)
					{
						goto IL_328;
					}
					BlockReference blockReference = entity2 as BlockReference;
					if (blockReference == null)
					{
						goto IL_328;
					}
					Point3d p = blockReference.GeometricExtents.MaxPoint;
					p2 = blockReference.GeometricExtents.MinPoint;
					p2 = CAD.GetPointXY(p2, -100.0, -100.0);
					p = CAD.GetPointXY(p, 100.0, 100.0);
					polyline = CAD.AddPlinePxy(p2, p.X - p2.X, p.Y - p2.Y, 0.0, "");
					transaction.Commit();
				}
				IL_183:
				num2 = 15;
				Point3d pointXY = CAD.GetPointXY(p2, 50.0, 50.0);
				IL_1A1:
				num2 = 16;
				DBObjectCollection dbobjectCollection = editor.TraceBoundary(pointXY, true);
				IL_1B0:
				num2 = 17;
				if (dbobjectCollection.Count < 2)
				{
					goto IL_223;
				}
				IL_1C2:
				num2 = 18;
				long num3 = 0L;
				long num4 = (long)(checked(dbobjectCollection.Count - 1));
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
						IL_1DE:
						num2 = 19;
						Entity entity3 = (Entity)dbobjectCollection[(int)num5];
						IL_1F2:
						num2 = 20;
						entity3.ColorIndex = 1;
						IL_1FD:
						num2 = 21;
						CAD.AddEnt(entity3);
						IL_208:
						num2 = 22;
						num5 += 1L;
					}
					IL_223:
					num2 = 24;
					Class36.smethod_64(polyline.ObjectId);
					IL_233:
					num2 = 25;
					if (Information.Err().Number <= 0)
					{
						goto IL_25A;
					}
					IL_245:
					num2 = 26;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_25A:
					goto IL_328;
					IL_25F:;
				}
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_2DF:
				goto IL_31D;
				IL_2E1:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_25F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2FA:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2E1;
			}
			IL_31D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_328:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcBoundary1")]
		public void TcBoundary1()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptSelectionResult selection = editor.GetSelection();
			SelectionSet value = selection.Value;
			new ArrayList();
			Point3d point3d = default(Point3d);
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			new ObjectIdCollection();
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				try
				{
					foreach (object obj in value)
					{
						SelectedObject selectedObject = (SelectedObject)obj;
						DBObject @object = transaction.GetObject(selectedObject.ObjectId, 1);
						dbobjectCollection.Add(@object);
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				transaction.Commit();
			}
			DBObjectCollection dbobjectCollection2 = Region.CreateFromCurves(dbobjectCollection);
			Region region = new Region();
			int num = 0;
			checked
			{
				int num2 = dbobjectCollection2.Count - 1;
				int num3 = num;
				for (;;)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					region.BooleanOperation(0, (Region)dbobjectCollection2[num3]);
					num3++;
				}
				CAD.AddEnt(region);
				if (Information.Err().Number > 0)
				{
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				}
			}
		}

		public DBObjectCollection PointBoundary(Point3d P, double Dist)
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			Point3d pointXY = CAD.GetPointXY(P, Dist, Dist);
			DBObjectCollection dbobjectCollection2 = editor.TraceBoundary(pointXY, false);
			try
			{
				foreach (object obj in dbobjectCollection2)
				{
					DBObject dbobject = (DBObject)obj;
					Entity entity = dbobject as Entity;
					if (entity != null)
					{
						entity.ColorIndex = 1;
						dbobjectCollection.Add(entity);
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			Point3d pointXY2 = CAD.GetPointXY(P, Dist, -Dist);
			DBObjectCollection dbobjectCollection3 = editor.TraceBoundary(pointXY2, false);
			try
			{
				foreach (object obj2 in dbobjectCollection3)
				{
					DBObject dbobject2 = (DBObject)obj2;
					Entity entity2 = dbobject2 as Entity;
					if (entity2 != null)
					{
						entity2.ColorIndex = 1;
						dbobjectCollection.Add(entity2);
					}
				}
			}
			finally
			{
				IEnumerator enumerator2;
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			Point3d pointXY3 = CAD.GetPointXY(P, -Dist, -Dist);
			DBObjectCollection dbobjectCollection4 = editor.TraceBoundary(pointXY3, false);
			try
			{
				foreach (object obj3 in dbobjectCollection4)
				{
					DBObject dbobject3 = (DBObject)obj3;
					Entity entity3 = dbobject3 as Entity;
					if (entity3 != null)
					{
						entity3.ColorIndex = 1;
						dbobjectCollection.Add(entity3);
					}
				}
			}
			finally
			{
				IEnumerator enumerator3;
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			Point3d pointXY4 = CAD.GetPointXY(P, -Dist, Dist);
			DBObjectCollection dbobjectCollection5 = editor.TraceBoundary(pointXY4, false);
			try
			{
				foreach (object obj4 in dbobjectCollection5)
				{
					DBObject dbobject4 = (DBObject)obj4;
					Entity entity4 = dbobject4 as Entity;
					if (entity4 != null)
					{
						entity4.ColorIndex = 1;
						dbobjectCollection.Add(entity4);
					}
				}
			}
			finally
			{
				IEnumerator enumerator4;
				if (enumerator4 is IDisposable)
				{
					(enumerator4 as IDisposable).Dispose();
				}
			}
			return dbobjectCollection;
		}

		[CommandMethod("BoundaryTest")]
		public static void BoundaryTest()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			PromptPointResult point = editor.GetPoint(new PromptPointOptions("Select point ")
			{
				AllowNone = false
			});
			if (point.Status == 5100)
			{
				DBObjectCollection dbobjectCollection = editor.TraceBoundary(point.Value, true);
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					ObjectId blockModelSpaceId = SymbolUtilityServices.GetBlockModelSpaceId(database);
					BlockTableRecord blockTableRecord = transaction.GetObject(blockModelSpaceId, 1) as BlockTableRecord;
					try
					{
						foreach (object obj in dbobjectCollection)
						{
							DBObject dbobject = (DBObject)obj;
							Entity entity = dbobject as Entity;
							if (entity != null)
							{
								entity.ColorIndex = 1;
								blockTableRecord.AppendEntity(entity);
								transaction.AddNewlyCreatedDBObject(entity, true);
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
			}
		}

		[CommandMethod("TcBJJZ_X")]
		public void TcBJJZ_X()
		{
			int num;
			int num4;
			object obj3;
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,TEXT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				if (selection.Status != 5100)
				{
					goto IL_197;
				}
				IL_78:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_84:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					Point3d entCenter;
					double rotation;
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
						if (entity is Polyline)
						{
							entCenter = CAD.GetEntCenter(entity);
						}
						else if (entity is DBText)
						{
							DBText dbtext = (DBText)entity;
							rotation = dbtext.Rotation;
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					IEnumerator enumerator2 = value.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						SelectedObject selectedObject2 = (SelectedObject)obj2;
						Entity ent = (Entity)transaction.GetObject(selectedObject2.ObjectId, 1);
						CAD.EntRotate(ent, entCenter, -rotation);
					}
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_197:
				num2 = 13;
				if (Information.Err().Number <= 0)
				{
					goto IL_1BE;
				}
				IL_1A9:
				num2 = 14;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1BE:
				goto IL_255;
				IL_1C3:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_20F:
				goto IL_24A;
				IL_211:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1C3;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_227:;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_211;
			}
			IL_24A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_255:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcBJJZ_Y")]
		public void TcBJJZ_Y()
		{
			int num;
			int num4;
			object obj3;
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,TEXT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				if (selection.Status != 5100)
				{
					goto IL_1C4;
				}
				IL_78:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_84:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					Point3d entCenter;
					double rotation;
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
						if (entity is Polyline)
						{
							entCenter = CAD.GetEntCenter(entity);
						}
						else if (entity is DBText)
						{
							DBText dbtext = (DBText)entity;
							rotation = dbtext.Rotation;
							Class36.smethod_60(Conversions.ToString(rotation * 180.0 / 3.1415926535897931));
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					IEnumerator enumerator2 = value.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						SelectedObject selectedObject2 = (SelectedObject)obj2;
						Entity ent = (Entity)transaction.GetObject(selectedObject2.ObjectId, 1);
						CAD.EntRotate(ent, entCenter, 1.5707963267948966 - rotation);
					}
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_1C4:
				num2 = 13;
				if (Information.Err().Number <= 0)
				{
					goto IL_1EB;
				}
				IL_1D6:
				num2 = 14;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1EB:
				goto IL_282;
				IL_1F0:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_23C:
				goto IL_277;
				IL_23E:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1F0;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_254:;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_23E;
			}
			IL_277:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_282:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("Tc2Wipeout")]
		public void method_10()
		{
			int num;
			int num14;
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,CIRCLE,ELLIPSE");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				if (selection.Status != 5100)
				{
					goto IL_26B;
				}
				IL_78:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_84:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
						if (entity is Polyline)
						{
							Polyline polyline = (Polyline)entity;
							polyline.Closed = true;
							long num3 = (long)(checked(polyline.NumberOfVertices - 1));
							Point3dCollection point3dCollection = new Point3dCollection();
							long num4 = 0L;
							long num5 = num3;
							long num6 = num4;
							checked
							{
								for (;;)
								{
									long num7 = num6;
									long num8 = num5;
									if (num7 > num8)
									{
										break;
									}
									Point3d point3dAt = polyline.GetPoint3dAt((int)num6);
									Point3d point3dAt2;
									if (num6 == num3)
									{
										point3dAt2 = polyline.GetPoint3dAt(0);
									}
									else
									{
										point3dAt2 = polyline.GetPoint3dAt((int)(num6 + 1L));
									}
									double num9 = point3dAt.DistanceTo(point3dAt2);
									double distAtPoint = polyline.GetDistAtPoint(point3dAt);
									double distAtPoint2 = polyline.GetDistAtPoint(point3dAt2);
									unchecked
									{
										double num10 = Math.Abs(distAtPoint - distAtPoint2);
										if (num10 > num9)
										{
											point3dCollection.Add(point3dAt);
											double num11 = num10 / 20.0;
											short num12 = 1;
											do
											{
												if (distAtPoint + num11 * (double)num12 <= polyline.Length)
												{
													Point3d pointAtDist = polyline.GetPointAtDist(distAtPoint + num11 * (double)num12);
													point3dCollection.Add(pointAtDist);
												}
												num12 += 1;
											}
											while (num12 <= 19);
										}
										else
										{
											point3dCollection.Add(point3dAt);
										}
									}
									num6 += 1L;
								}
								Class36.smethod_51(point3dCollection, polyline.Layer);
							}
						}
						else if (entity is Circle || !(entity is Ellipse))
						{
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_26B:
				num2 = 13;
				if (Information.Err().Number <= 0)
				{
					goto IL_292;
				}
				IL_27D:
				num2 = 14;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_292:
				goto IL_329;
				IL_297:
				int num13 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num13);
				IL_2E3:
				goto IL_31E;
				IL_2E5:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_297;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2FB:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2E5;
			}
			IL_31E:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_329:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcDJBJ")]
		public void TcDJBJ()
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "POINT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				Point2dCollection point2dCollection = new Point2dCollection();
				IL_6C:
				num2 = 9;
				Point2d point2d;
				point2d..ctor(double.MaxValue, double.MaxValue);
				IL_88:
				num2 = 10;
				if (selection.Status != 5100)
				{
					goto IL_199;
				}
				IL_9E:
				num2 = 11;
				SelectionSet value = selection.Value;
				IL_AA:
				num2 = 12;
				Point3d position;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
						DBPoint dbpoint = (DBPoint)entity;
						double x = dbpoint.Position.X;
						position = dbpoint.Position;
						Point2d point2d2;
						point2d2..ctor(x, position.Y);
						if (!point2dCollection.Contains(point2d2))
						{
							point2dCollection.Add(point2d2);
						}
						if (point2d.X > point2d2.X && point2d.Y > point2d2.Y)
						{
							point2d = point2d2;
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				IL_199:
				num2 = 15;
				position..ctor(point2d.X, point2d.Y, 0.0);
				Class36.smethod_23(position, "min", 0.1, 0, "");
				IL_1D6:
				num2 = 16;
				if (point2dCollection.Count <= 0)
				{
					goto IL_31E;
				}
				IL_1E8:
				num2 = 17;
				Point3dCollection point3dCollection = new Point3dCollection();
				IL_1F2:
				num2 = 18;
				Point3dCollection point3dCollection2 = point3dCollection;
				position..ctor(point2d.X, point2d.Y, 0.0);
				point3dCollection2.Add(position);
				IL_21D:
				num2 = 19;
				long num3 = 0L;
				IL_22B:
				num2 = 20;
				IL_22E:
				num2 = 21;
				Point2d point2d3 = point2d;
				IL_235:
				num2 = 22;
				checked
				{
					for (;;)
					{
						IL_2E4:
						num2 = 24;
						Point2d point2d4 = this.BaJiaoDian(point2d3, 1.0, ref point2dCollection);
						IL_23D:
						num2 = 25;
						position..ctor(point2d4.X, point2d4.Y, 0.0);
						Class36.smethod_23(position, Conversions.ToString(num3), 0.1, 0, "");
						IL_27C:
						num2 = 26;
						if (point2d4.GetDistanceTo(point2d3) <= 0.5)
						{
							break;
						}
						IL_295:
						num2 = 27;
						Point3dCollection point3dCollection3 = point3dCollection;
						position..ctor(point2d4.X, point2d4.Y, 0.0);
						point3dCollection3.Add(position);
						IL_2C0:
						num2 = 28;
						num3 += 1L;
						IL_2D1:
						num2 = 29;
						point2dCollection.Remove(point2d3);
						IL_2DD:
						num2 = 30;
						point2d3 = point2d4;
					}
					IL_301:
					num2 = 32;
					IL_304:
					num2 = 36;
					Class36.smethod_50(point3dCollection, 0.0, "0", false);
					IL_31E:
					goto IL_414;
					IL_323:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_3CB:
				goto IL_409;
				IL_3CD:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_323;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_3E6:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_3CD;
			}
			IL_409:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_414:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcDJQZ")]
		public void TcDJQZ()
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "POINT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				DBObjectCollection dbobjectCollection = new DBObjectCollection();
				IL_6C:
				num2 = 9;
				Point2dCollection point2dCollection = new Point2dCollection();
				IL_76:
				num2 = 10;
				if (selection.Status != 5100)
				{
					goto IL_161;
				}
				IL_8C:
				num2 = 11;
				SelectionSet value = selection.Value;
				IL_98:
				num2 = 12;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
						DBPoint dbpoint = (DBPoint)entity;
						Point2d point2d;
						point2d..ctor(dbpoint.Position.X, dbpoint.Position.Y);
						if (!point2dCollection.Contains(point2d))
						{
							dbobjectCollection.Add(entity);
							point2dCollection.Add(point2d);
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				IL_161:
				num2 = 15;
				long num3 = 0L;
				long num4 = (long)(checked(dbobjectCollection.Count - 1));
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
						IL_185:
						num2 = 16;
						Entity entity2 = (Entity)dbobjectCollection[(int)num5];
						IL_199:
						num2 = 17;
						Point2d p = point2dCollection[(int)num5];
						IL_1A8:
						num2 = 18;
						if (this.IsCenterPoint(p, 1.0, ref point2dCollection))
						{
							IL_1C0:
							num2 = 19;
							Class36.smethod_64(entity2.ObjectId);
						}
						IL_1D0:
						num2 = 21;
						num5 += 1L;
					}
					IL_1E3:
					goto IL_296;
					IL_1E8:;
				}
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_250:
				goto IL_28B;
				IL_252:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_1E8;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_268:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_252;
			}
			IL_28B:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_296:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcTuBao")]
		public void TcTuBao()
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "POINT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				Point3dCollection point3dCollection = new Point3dCollection();
				IL_6C:
				num2 = 9;
				if (selection.Status != 5100)
				{
					goto IL_160;
				}
				IL_82:
				num2 = 10;
				SelectionSet value = selection.Value;
				IL_8E:
				num2 = 11;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
						DBPoint dbpoint = (DBPoint)entity;
						Point3d point3d;
						point3d..ctor(dbpoint.Position.X, dbpoint.Position.Y, dbpoint.Position.Z);
						if (!point3dCollection.Contains(point3d))
						{
							point3dCollection.Add(point3d);
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				IL_160:
				num2 = 14;
				Class37 @class = new Class37(point3dCollection);
				IL_16C:
				num2 = 15;
				@class.method_0();
				IL_176:
				goto IL_211;
				IL_17B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1CB:
				goto IL_206;
				IL_1CD:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_17B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1E3:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_1CD;
			}
			IL_206:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_211:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public bool IsCenterPoint(Point2d P, double R, ref Point2dCollection Pc)
		{
			Point2d point2d;
			point2d..ctor(P.X + R, P.Y);
			Point2d point2d2;
			point2d2..ctor(P.X + R, P.Y + R);
			Point2d point2d3;
			point2d3..ctor(P.X, P.Y + R);
			Point2d point2d4;
			point2d4..ctor(P.X - R, P.Y + R);
			Point2d point2d5;
			point2d5..ctor(P.X - R, P.Y);
			Point2d point2d6;
			point2d6..ctor(P.X - R, P.Y - R);
			Point2d point2d7;
			point2d7..ctor(P.X, P.Y - R);
			Point2d point2d8;
			point2d8..ctor(P.X + R, P.Y - R);
			return Pc.Contains(point2d) && Pc.Contains(point2d2) && Pc.Contains(point2d3) && Pc.Contains(point2d4) && Pc.Contains(point2d5) && Pc.Contains(point2d6) && Pc.Contains(point2d7) && Pc.Contains(point2d8);
		}

		public Point2d BaJiaoDian(Point2d P, double R, ref Point2dCollection Pc)
		{
			Point2d point2d;
			point2d..ctor(P.X + R, P.Y);
			Point2d result;
			if (Pc.Contains(point2d))
			{
				result = point2d;
			}
			else
			{
				Point2d point2d2;
				point2d2..ctor(P.X + R, P.Y + R);
				if (Pc.Contains(point2d2))
				{
					result = point2d2;
				}
				else
				{
					Point2d point2d3;
					point2d3..ctor(P.X, P.Y + R);
					if (Pc.Contains(point2d3))
					{
						result = point2d3;
					}
					else
					{
						Point2d point2d4;
						point2d4..ctor(P.X - R, P.Y + R);
						if (Pc.Contains(point2d4))
						{
							result = point2d4;
						}
						else
						{
							Point2d point2d5;
							point2d5..ctor(P.X - R, P.Y);
							if (Pc.Contains(point2d5))
							{
								result = point2d5;
							}
							else
							{
								Point2d point2d6;
								point2d6..ctor(P.X - R, P.Y - R);
								if (Pc.Contains(point2d6))
								{
									result = point2d6;
								}
								else
								{
									Point2d point2d7;
									point2d7..ctor(P.X, P.Y - R);
									if (Pc.Contains(point2d7))
									{
										result = point2d7;
									}
									else
									{
										Point2d point2d8;
										point2d8..ctor(P.X + R, P.Y - R);
										if (Pc.Contains(point2d8))
										{
											result = point2d8;
										}
										else
										{
											result = P;
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		public Point2d BaJiaoDian1(Point2d P, double R, ref Point2dCollection Pc, ref long Last)
		{
			Point2d result;
			if (Last == 0L)
			{
				Point2d point2d;
				point2d..ctor(P.X + R, P.Y);
				if (Pc.Contains(point2d))
				{
					Last = 1L;
					result = point2d;
				}
				else
				{
					Point2d point2d2;
					point2d2..ctor(P.X + R, P.Y + R);
					if (Pc.Contains(point2d2))
					{
						Last = 2L;
						result = point2d2;
					}
					else
					{
						Point2d point2d3;
						point2d3..ctor(P.X, P.Y + R);
						if (Pc.Contains(point2d3))
						{
							Last = 3L;
							result = point2d3;
						}
						else
						{
							Point2d point2d4;
							point2d4..ctor(P.X - R, P.Y + R);
							if (Pc.Contains(point2d4))
							{
								Last = 4L;
								result = point2d4;
							}
							else
							{
								Point2d point2d5;
								point2d5..ctor(P.X - R, P.Y);
								if (Pc.Contains(point2d5))
								{
									Last = 5L;
									result = point2d5;
								}
								else
								{
									Point2d point2d6;
									point2d6..ctor(P.X - R, P.Y - R);
									if (Pc.Contains(point2d6))
									{
										Last = 6L;
										result = point2d6;
									}
									else
									{
										Point2d point2d7;
										point2d7..ctor(P.X, P.Y - R);
										if (Pc.Contains(point2d7))
										{
											Last = 7L;
											result = point2d7;
										}
										else
										{
											Point2d point2d8;
											point2d8..ctor(P.X + R, P.Y - R);
											if (Pc.Contains(point2d8))
											{
												Last = 8L;
												result = point2d8;
											}
											else
											{
												result = P;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 1L)
			{
				Point2d point2d9;
				point2d9..ctor(P.X + R, P.Y + R);
				if (Pc.Contains(point2d9))
				{
					Last = 2L;
					result = point2d9;
				}
				else
				{
					Point2d point2d10;
					point2d10..ctor(P.X, P.Y + R);
					if (Pc.Contains(point2d10))
					{
						Last = 3L;
						result = point2d10;
					}
					else
					{
						Point2d point2d11;
						point2d11..ctor(P.X - R, P.Y + R);
						if (Pc.Contains(point2d11))
						{
							Last = 4L;
							result = point2d11;
						}
						else
						{
							Point2d point2d12;
							point2d12..ctor(P.X - R, P.Y);
							if (Pc.Contains(point2d12))
							{
								Last = 5L;
								result = point2d12;
							}
							else
							{
								Point2d point2d13;
								point2d13..ctor(P.X - R, P.Y - R);
								if (Pc.Contains(point2d13))
								{
									Last = 6L;
									result = point2d13;
								}
								else
								{
									Point2d point2d14;
									point2d14..ctor(P.X, P.Y - R);
									if (Pc.Contains(point2d14))
									{
										Last = 7L;
										result = point2d14;
									}
									else
									{
										Point2d point2d15;
										point2d15..ctor(P.X + R, P.Y - R);
										if (Pc.Contains(point2d15))
										{
											Last = 8L;
											result = point2d15;
										}
										else
										{
											Point2d point2d16;
											point2d16..ctor(P.X + R, P.Y);
											if (Pc.Contains(point2d16))
											{
												Last = 1L;
												result = point2d16;
											}
											else
											{
												result = P;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 2L)
			{
				Point2d point2d17;
				point2d17..ctor(P.X, P.Y + R);
				if (Pc.Contains(point2d17))
				{
					Last = 3L;
					result = point2d17;
				}
				else
				{
					Point2d point2d18;
					point2d18..ctor(P.X - R, P.Y + R);
					if (Pc.Contains(point2d18))
					{
						Last = 4L;
						result = point2d18;
					}
					else
					{
						Point2d point2d19;
						point2d19..ctor(P.X - R, P.Y);
						if (Pc.Contains(point2d19))
						{
							Last = 5L;
							result = point2d19;
						}
						else
						{
							Point2d point2d20;
							point2d20..ctor(P.X - R, P.Y - R);
							if (Pc.Contains(point2d20))
							{
								Last = 6L;
								result = point2d20;
							}
							else
							{
								Point2d point2d21;
								point2d21..ctor(P.X, P.Y - R);
								if (Pc.Contains(point2d21))
								{
									Last = 7L;
									result = point2d21;
								}
								else
								{
									Point2d point2d22;
									point2d22..ctor(P.X + R, P.Y - R);
									if (Pc.Contains(point2d22))
									{
										Last = 8L;
										result = point2d22;
									}
									else
									{
										Point2d point2d23;
										point2d23..ctor(P.X + R, P.Y);
										if (Pc.Contains(point2d23))
										{
											Last = 1L;
											result = point2d23;
										}
										else
										{
											Point2d point2d24;
											point2d24..ctor(P.X + R, P.Y + R);
											if (Pc.Contains(point2d24))
											{
												Last = 2L;
												result = point2d24;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 3L)
			{
				Point2d point2d25;
				point2d25..ctor(P.X - R, P.Y + R);
				if (Pc.Contains(point2d25))
				{
					Last = 4L;
					result = point2d25;
				}
				else
				{
					Point2d point2d26;
					point2d26..ctor(P.X - R, P.Y);
					if (Pc.Contains(point2d26))
					{
						Last = 5L;
						result = point2d26;
					}
					else
					{
						Point2d point2d27;
						point2d27..ctor(P.X - R, P.Y - R);
						if (Pc.Contains(point2d27))
						{
							Last = 6L;
							result = point2d27;
						}
						else
						{
							Point2d point2d28;
							point2d28..ctor(P.X, P.Y - R);
							if (Pc.Contains(point2d28))
							{
								Last = 7L;
								result = point2d28;
							}
							else
							{
								Point2d point2d29;
								point2d29..ctor(P.X + R, P.Y - R);
								if (Pc.Contains(point2d29))
								{
									Last = 8L;
									result = point2d29;
								}
								else
								{
									Point2d point2d30;
									point2d30..ctor(P.X + R, P.Y);
									if (Pc.Contains(point2d30))
									{
										Last = 1L;
										result = point2d30;
									}
									else
									{
										Point2d point2d31;
										point2d31..ctor(P.X + R, P.Y + R);
										if (Pc.Contains(point2d31))
										{
											Last = 2L;
											result = point2d31;
										}
										else
										{
											Point2d point2d32;
											point2d32..ctor(P.X, P.Y + R);
											if (Pc.Contains(point2d32))
											{
												Last = 3L;
												result = point2d32;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 4L)
			{
				Point2d point2d33;
				point2d33..ctor(P.X - R, P.Y);
				if (Pc.Contains(point2d33))
				{
					Last = 5L;
					result = point2d33;
				}
				else
				{
					Point2d point2d34;
					point2d34..ctor(P.X - R, P.Y - R);
					if (Pc.Contains(point2d34))
					{
						Last = 6L;
						result = point2d34;
					}
					else
					{
						Point2d point2d35;
						point2d35..ctor(P.X, P.Y - R);
						if (Pc.Contains(point2d35))
						{
							Last = 7L;
							result = point2d35;
						}
						else
						{
							Point2d point2d36;
							point2d36..ctor(P.X + R, P.Y - R);
							if (Pc.Contains(point2d36))
							{
								Last = 8L;
								result = point2d36;
							}
							else
							{
								Point2d point2d37;
								point2d37..ctor(P.X + R, P.Y);
								if (Pc.Contains(point2d37))
								{
									Last = 1L;
									result = point2d37;
								}
								else
								{
									Point2d point2d38;
									point2d38..ctor(P.X + R, P.Y + R);
									if (Pc.Contains(point2d38))
									{
										Last = 2L;
										result = point2d38;
									}
									else
									{
										Point2d point2d39;
										point2d39..ctor(P.X, P.Y + R);
										if (Pc.Contains(point2d39))
										{
											Last = 3L;
											result = point2d39;
										}
										else
										{
											Point2d point2d40;
											point2d40..ctor(P.X - R, P.Y + R);
											if (Pc.Contains(point2d40))
											{
												Last = 4L;
												result = point2d40;
											}
											else
											{
												result = P;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 5L)
			{
				Point2d point2d41;
				point2d41..ctor(P.X - R, P.Y - R);
				if (Pc.Contains(point2d41))
				{
					Last = 6L;
					result = point2d41;
				}
				else
				{
					Point2d point2d42;
					point2d42..ctor(P.X, P.Y - R);
					if (Pc.Contains(point2d42))
					{
						Last = 7L;
						result = point2d42;
					}
					else
					{
						Point2d point2d43;
						point2d43..ctor(P.X + R, P.Y - R);
						if (Pc.Contains(point2d43))
						{
							Last = 8L;
							result = point2d43;
						}
						else
						{
							Point2d point2d44;
							point2d44..ctor(P.X + R, P.Y);
							if (Pc.Contains(point2d44))
							{
								Last = 1L;
								result = point2d44;
							}
							else
							{
								Point2d point2d45;
								point2d45..ctor(P.X + R, P.Y + R);
								if (Pc.Contains(point2d45))
								{
									Last = 2L;
									result = point2d45;
								}
								else
								{
									Point2d point2d46;
									point2d46..ctor(P.X, P.Y + R);
									if (Pc.Contains(point2d46))
									{
										Last = 3L;
										result = point2d46;
									}
									else
									{
										Point2d point2d47;
										point2d47..ctor(P.X - R, P.Y + R);
										if (Pc.Contains(point2d47))
										{
											Last = 4L;
											result = point2d47;
										}
										else
										{
											Point2d point2d48;
											point2d48..ctor(P.X - R, P.Y);
											if (Pc.Contains(point2d48))
											{
												Last = 5L;
												result = point2d48;
											}
											else
											{
												result = P;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 6L)
			{
				Point2d point2d49;
				point2d49..ctor(P.X, P.Y - R);
				if (Pc.Contains(point2d49))
				{
					Last = 7L;
					result = point2d49;
				}
				else
				{
					Point2d point2d50;
					point2d50..ctor(P.X + R, P.Y - R);
					if (Pc.Contains(point2d50))
					{
						Last = 8L;
						result = point2d50;
					}
					else
					{
						Point2d point2d51;
						point2d51..ctor(P.X + R, P.Y);
						if (Pc.Contains(point2d51))
						{
							Last = 1L;
							result = point2d51;
						}
						else
						{
							Point2d point2d52;
							point2d52..ctor(P.X + R, P.Y + R);
							if (Pc.Contains(point2d52))
							{
								Last = 2L;
								result = point2d52;
							}
							else
							{
								Point2d point2d53;
								point2d53..ctor(P.X, P.Y + R);
								if (Pc.Contains(point2d53))
								{
									Last = 3L;
									result = point2d53;
								}
								else
								{
									Point2d point2d54;
									point2d54..ctor(P.X - R, P.Y + R);
									if (Pc.Contains(point2d54))
									{
										Last = 4L;
										result = point2d54;
									}
									else
									{
										Point2d point2d55;
										point2d55..ctor(P.X - R, P.Y);
										if (Pc.Contains(point2d55))
										{
											Last = 5L;
											result = point2d55;
										}
										else
										{
											Point2d point2d56;
											point2d56..ctor(P.X - R, P.Y - R);
											if (Pc.Contains(point2d56))
											{
												Last = 6L;
												result = point2d56;
											}
											else
											{
												result = P;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 7L)
			{
				Point2d point2d57;
				point2d57..ctor(P.X + R, P.Y - R);
				if (Pc.Contains(point2d57))
				{
					Last = 8L;
					result = point2d57;
				}
				else
				{
					Point2d point2d58;
					point2d58..ctor(P.X + R, P.Y);
					if (Pc.Contains(point2d58))
					{
						Last = 1L;
						result = point2d58;
					}
					else
					{
						Point2d point2d59;
						point2d59..ctor(P.X + R, P.Y + R);
						if (Pc.Contains(point2d59))
						{
							Last = 2L;
							result = point2d59;
						}
						else
						{
							Point2d point2d60;
							point2d60..ctor(P.X, P.Y + R);
							if (Pc.Contains(point2d60))
							{
								Last = 3L;
								result = point2d60;
							}
							else
							{
								Point2d point2d61;
								point2d61..ctor(P.X - R, P.Y + R);
								if (Pc.Contains(point2d61))
								{
									Last = 4L;
									result = point2d61;
								}
								else
								{
									Point2d point2d62;
									point2d62..ctor(P.X - R, P.Y);
									if (Pc.Contains(point2d62))
									{
										Last = 5L;
										result = point2d62;
									}
									else
									{
										Point2d point2d63;
										point2d63..ctor(P.X - R, P.Y - R);
										if (Pc.Contains(point2d63))
										{
											Last = 6L;
											result = point2d63;
										}
										else
										{
											Point2d point2d64;
											point2d64..ctor(P.X, P.Y - R);
											if (Pc.Contains(point2d64))
											{
												Last = 7L;
												result = point2d64;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if (Last == 8L)
			{
				Point2d point2d65;
				point2d65..ctor(P.X + R, P.Y);
				if (Pc.Contains(point2d65))
				{
					Last = 1L;
					result = point2d65;
				}
				else
				{
					Point2d point2d66;
					point2d66..ctor(P.X + R, P.Y + R);
					if (Pc.Contains(point2d66))
					{
						Last = 2L;
						result = point2d66;
					}
					else
					{
						Point2d point2d67;
						point2d67..ctor(P.X, P.Y + R);
						if (Pc.Contains(point2d67))
						{
							Last = 3L;
							result = point2d67;
						}
						else
						{
							Point2d point2d68;
							point2d68..ctor(P.X - R, P.Y + R);
							if (Pc.Contains(point2d68))
							{
								Last = 4L;
								result = point2d68;
							}
							else
							{
								Point2d point2d69;
								point2d69..ctor(P.X - R, P.Y);
								if (Pc.Contains(point2d69))
								{
									Last = 5L;
									result = point2d69;
								}
								else
								{
									Point2d point2d70;
									point2d70..ctor(P.X - R, P.Y - R);
									if (Pc.Contains(point2d70))
									{
										Last = 6L;
										result = point2d70;
									}
									else
									{
										Point2d point2d71;
										point2d71..ctor(P.X, P.Y - R);
										if (Pc.Contains(point2d71))
										{
											Last = 7L;
											result = point2d71;
										}
										else
										{
											Point2d point2d72;
											point2d72..ctor(P.X + R, P.Y - R);
											if (Pc.Contains(point2d72))
											{
												Last = 8L;
												result = point2d72;
											}
											else
											{
												result = P;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
	}
}
