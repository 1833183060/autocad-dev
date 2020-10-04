using System;
using System.Collections;
using System.Diagnostics;
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
	public class 梁柱拉筋
	{
		[DebuggerNonUserCode]
		public 梁柱拉筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcZhuGuJin")]
		public void TcZhuGuJin()
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
				Point3d point3d_;
				Point3d point3d_2;
				this.GetGuJinPoint(ref point3d_, ref point3d_2);
				IL_16:
				num2 = 3;
				if (Class36.double_0 != 0.0)
				{
					goto IL_3A;
				}
				IL_2A:
				num2 = 4;
				Class36.double_0 = 4.0;
				IL_3A:
				num2 = 6;
				Class36.smethod_10(point3d_, point3d_2, Class36.double_0);
				IL_4A:
				goto IL_BA;
				IL_4C:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_76:
				goto IL_AF;
				IL_78:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_4C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_8D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_78;
			}
			IL_AF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_BA:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZGJ_PKPM")]
		public void TcZGJ_PKPM()
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
				Point3d point3d_;
				Point3d point3d_2;
				this.GetGuJinPoint(ref point3d_, ref point3d_2);
				IL_16:
				num2 = 3;
				Class36.smethod_11(point3d_, point3d_2, Class36.double_0 / 2.0);
				IL_30:
				goto IL_94;
				IL_32:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_50:
				goto IL_89;
				IL_52:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_32;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_67:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_52;
			}
			IL_89:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_94:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZGJ_YJK")]
		public void TcZGJ_YJK()
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
				Point3d point3d_;
				Point3d point3d_2;
				this.GetGuJinPoint(ref point3d_, ref point3d_2);
				IL_16:
				num2 = 3;
				Class36.smethod_12(point3d_, point3d_2, Class36.double_0);
				IL_25:
				goto IL_86;
				IL_27:
				goto IL_91;
				IL_29:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_41;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_63;
				IL_41:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_63:
				goto IL_91;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_29;
			}
			IL_86:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_91:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public object GetGuJinPoint(ref Point3d P1, ref Point3d P2)
		{
			int num;
			object obj2;
			int num8;
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
						Entity e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						Point3d entCenter = CAD.GetEntCenter(e);
						double num3 = entCenter.X;
						double num4 = entCenter.Y;
						double num5 = entCenter.X;
						double num6 = entCenter.Y;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							e = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							entCenter = CAD.GetEntCenter(e);
							num3 = Math.Min(entCenter.X, num3);
							num4 = Math.Min(entCenter.Y, num4);
							num5 = Math.Max(entCenter.X, num5);
							num6 = Math.Max(entCenter.Y, num6);
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						P1..ctor(num3, num4, 0.0);
						P2..ctor(num5, num6, 0.0);
					}
					transaction.Commit();
				}
				IL_1AC:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_1D1;
				}
				IL_1BD:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1D1:
				num2 = 9;
				obj2 = true;
				IL_1E1:
				goto IL_261;
				IL_1E3:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_21B:
				goto IL_256;
				IL_21D:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_1E3;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_233:;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_21D;
			}
			IL_256:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_261:
			object result = obj2;
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		[CommandMethod("TcLiangZhuLaJin")]
		public void TcLiangZhuLaJin()
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
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						Entity e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						Entity e2 = (Entity)transaction.GetObject(value[checked(value.Count - 1)].ObjectId, 0);
						Point3d point3d = CAD.GetEntCenter(e);
						Point3d point3d2 = CAD.GetEntCenter(e2);
						if (point3d.X > point3d2.X)
						{
							Point3d point3d3 = point3d;
							point3d = point3d2;
							point3d2 = point3d3;
						}
						else if (point3d.X == point3d2.X & point3d.Y > point3d2.Y)
						{
							Point3d point3d4 = point3d;
							point3d = point3d2;
							point3d2 = point3d4;
						}
						if (Class36.double_0 == 0.0)
						{
							Class36.double_0 = 5.0;
						}
						Class36.smethod_8(point3d, point3d2, Class36.double_0);
					}
					transaction.Commit();
				}
				IL_177:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_19C;
				}
				IL_188:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_19C:
				goto IL_218;
				IL_19E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1D2:
				goto IL_20D;
				IL_1D4:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_19E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1EA:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D4;
			}
			IL_20D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_218:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZLJ_PKPM")]
		public void TcZLJ_PKPM()
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
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						Entity e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						Entity e2 = (Entity)transaction.GetObject(value[checked(value.Count - 1)].ObjectId, 0);
						Point3d point3d = CAD.GetEntCenter(e);
						Point3d point3d2 = CAD.GetEntCenter(e2);
						if (point3d.X > point3d2.X)
						{
							Point3d point3d3 = point3d;
							point3d = point3d2;
							point3d2 = point3d3;
						}
						else if (point3d.X == point3d2.X & point3d.Y > point3d2.Y)
						{
							Point3d point3d4 = point3d;
							point3d = point3d2;
							point3d2 = point3d4;
						}
						if (Class36.double_0 == 0.0)
						{
							Class36.double_0 = 2.0;
						}
						this.DrawLaJinPKPM(point3d, point3d2, Class36.double_0 / 2.0);
					}
					transaction.Commit();
				}
				IL_182:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_1A7;
				}
				IL_193:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1A7:
				goto IL_223;
				IL_1A9:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1DD:
				goto IL_218;
				IL_1DF:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1A9;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1F5:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1DF;
			}
			IL_218:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_223:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZLJ_YJK")]
		public void TcZLJ_YJK()
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
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						Entity e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						Entity e2 = (Entity)transaction.GetObject(value[checked(value.Count - 1)].ObjectId, 0);
						Point3d entCenter = CAD.GetEntCenter(e);
						Point3d entCenter2 = CAD.GetEntCenter(e2);
						if (Class36.double_0 == 0.0)
						{
							Class36.double_0 = 2.0;
						}
						this.DrawLaJinYJK(entCenter, entCenter2, Class36.double_0);
					}
					transaction.Commit();
				}
				IL_129:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_14E;
				}
				IL_13A:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_14E:
				goto IL_1CA;
				IL_150:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_184:
				goto IL_1BF;
				IL_186:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_150;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19C:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_186;
			}
			IL_1BF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1CA:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public Polyline DrawLaJinPKPM(Point3d Pa, Point3d Pb, double BILI)
		{
			int num = checked((int)Math.Round(unchecked(25.0 * BILI)));
			if (Pa.X > Pb.X)
			{
				Point3d point3d = Pa;
				Pa = Pb;
				Pb = point3d;
			}
			else if (Pa.X == Pb.X & Pa.Y > Pb.Y)
			{
				Point3d point3d2 = Pa;
				Pa = Pb;
				Pb = point3d2;
			}
			double num2 = CAD.P2P_Angle(Pa, Pb);
			Point3d pointAngle = CAD.GetPointAngle(Pa, 40.0 * BILI, num2 * 180.0 / 3.1415926535897931 + 90.0);
			Point3d pointAngle2 = CAD.GetPointAngle(Pb, 40.0 * BILI, num2 * 180.0 / 3.1415926535897931 + 90.0);
			Point3d pointAngle3 = CAD.GetPointAngle(Pa, 40.0 * BILI, num2 * 180.0 / 3.1415926535897931 - 135.0);
			Point3d pointAngle4 = CAD.GetPointAngle(Pb, 40.0 * BILI, num2 * 180.0 / 3.1415926535897931 - 45.0);
			Point3d pointAngle5 = CAD.GetPointAngle(Pa, 155.0 * BILI, num2 * 180.0 / 3.1415926535897931 + 300.0);
			Point3d pointAngle6 = CAD.GetPointAngle(Pb, 155.0 * BILI, num2 * 180.0 / 3.1415926535897931 - 120.0);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			double num3 = Math.Tan(Math.Atan(1.0) * 4.0 / 18.0 * 13.5 / 4.0);
			Polyline polyline2 = polyline;
			int num4 = 0;
			Point2d point2d;
			point2d..ctor(pointAngle5.get_Coordinate(0), pointAngle5.get_Coordinate(1));
			polyline2.AddVertexAt(num4, point2d, 0.0, (double)num, (double)num);
			Polyline polyline3 = polyline;
			int num5 = 1;
			point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
			polyline3.AddVertexAt(num5, point2d, -num3, (double)num, (double)num);
			Polyline polyline4 = polyline;
			int num6 = 2;
			point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
			polyline4.AddVertexAt(num6, point2d, 0.0, (double)num, (double)num);
			Polyline polyline5 = polyline;
			int num7 = 3;
			point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
			polyline5.AddVertexAt(num7, point2d, -num3, (double)num, (double)num);
			Polyline polyline6 = polyline;
			int num8 = 4;
			point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
			polyline6.AddVertexAt(num8, point2d, 0.0, (double)num, (double)num);
			Polyline polyline7 = polyline;
			int num9 = 5;
			point2d..ctor(pointAngle6.get_Coordinate(0), pointAngle6.get_Coordinate(1));
			polyline7.AddVertexAt(num9, point2d, 0.0, (double)num, (double)num);
			CAD.CreateLayer("柱平法箍筋", 24, "continuous", -1, false, true);
			polyline.Layer = "柱平法箍筋";
			CAD.AddEnt(polyline);
			return polyline;
		}

		public Polyline DrawLaJinYJK(Point3d Pa, Point3d Pb, double BILI)
		{
			int num = 50;
			double num2 = 1.0;
			if (BILI == 5.0)
			{
				num = 50;
				num2 = 1.0;
			}
			else if (BILI == 4.0)
			{
				num = 40;
				num2 = 0.8;
			}
			else if (BILI == 3.333)
			{
				num = 33;
				num2 = 0.6667;
			}
			else if (BILI == 2.5)
			{
				num = 25;
				num2 = 0.575;
			}
			else if (BILI == 2.0)
			{
				num = 25;
				num2 = 0.575;
			}
			if (Pa.X > Pb.X)
			{
				Point3d point3d = Pa;
				Pa = Pb;
				Pb = point3d;
			}
			else if (Pa.X == Pb.X & Pa.Y > Pb.Y)
			{
				Point3d point3d2 = Pa;
				Pa = Pb;
				Pb = point3d2;
			}
			double num3 = Pa.GetVectorTo(Pb).AngleOnPlane(new Plane());
			Point3d pointAR_Radian = CAD.GetPointAR_Radian(Pa, num3 + 2.1111502632123411, 116.62 * num2);
			Point3d pointAR_Radian2 = CAD.GetPointAR_Radian(Pa, num3 + 2.6012387171723486, 116.62 * num2);
			Point3d pointAR_Radian3 = CAD.GetPointAR_Radian(Pa, num3 + 3.3899530061485863, 103.17 * num2);
			Point3d pointAR_Radian4 = CAD.GetPointAR_Radian(Pa, num3 + 3.8098792241784216, 112.49 * num2);
			Point3d pointAR_Radian5 = CAD.GetPointAR_Radian(pointAR_Radian4, num3 - 0.78539816339744828, 250.0 * num2);
			Point3d pointAR_Radian6 = CAD.GetPointAR_Radian(Pb, num3 + 1.0304423903774522, 116.62 * num2);
			Point3d pointAR_Radian7 = CAD.GetPointAR_Radian(Pb, num3 + 0.54035393641744445, 116.62 * num2);
			Point3d pointAR_Radian8 = CAD.GetPointAR_Radian(Pb, num3 - 0.2483603525587931, 103.17 * num2);
			Point3d pointAR_Radian9 = CAD.GetPointAR_Radian(Pb, num3 - 0.66828657058862873, 112.49 * num2);
			Point3d pointAR_Radian10 = CAD.GetPointAR_Radian(pointAR_Radian9, num3 - 2.3561944901923448, 250.0 * num2);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			double num4 = Math.Tan(0.39269908169872414);
			double num5 = Math.Tan(0.1308996938995747);
			Polyline polyline2 = polyline;
			int num6 = 0;
			Point2d point2d;
			point2d..ctor(pointAR_Radian5.get_Coordinate(0), pointAR_Radian5.get_Coordinate(1));
			polyline2.AddVertexAt(num6, point2d, 0.0, (double)num, (double)num);
			Polyline polyline3 = polyline;
			int num7 = 1;
			point2d..ctor(pointAR_Radian4.get_Coordinate(0), pointAR_Radian4.get_Coordinate(1));
			polyline3.AddVertexAt(num7, point2d, -num5, (double)num, (double)num);
			Polyline polyline4 = polyline;
			int num8 = 2;
			point2d..ctor(pointAR_Radian3.get_Coordinate(0), pointAR_Radian3.get_Coordinate(1));
			polyline4.AddVertexAt(num8, point2d, 0.0, (double)num, (double)num);
			Polyline polyline5 = polyline;
			int num9 = 3;
			point2d..ctor(pointAR_Radian2.get_Coordinate(0), pointAR_Radian2.get_Coordinate(1));
			polyline5.AddVertexAt(num9, point2d, -num4, (double)num, (double)num);
			Polyline polyline6 = polyline;
			int num10 = 4;
			point2d..ctor(pointAR_Radian.get_Coordinate(0), pointAR_Radian.get_Coordinate(1));
			polyline6.AddVertexAt(num10, point2d, 0.0, (double)num, (double)num);
			Polyline polyline7 = polyline;
			int num11 = 5;
			point2d..ctor(pointAR_Radian6.get_Coordinate(0), pointAR_Radian6.get_Coordinate(1));
			polyline7.AddVertexAt(num11, point2d, -num4, (double)num, (double)num);
			Polyline polyline8 = polyline;
			int num12 = 6;
			point2d..ctor(pointAR_Radian7.get_Coordinate(0), pointAR_Radian7.get_Coordinate(1));
			polyline8.AddVertexAt(num12, point2d, 0.0, (double)num, (double)num);
			Polyline polyline9 = polyline;
			int num13 = 7;
			point2d..ctor(pointAR_Radian8.get_Coordinate(0), pointAR_Radian8.get_Coordinate(1));
			polyline9.AddVertexAt(num13, point2d, -num5, (double)num, (double)num);
			Polyline polyline10 = polyline;
			int num14 = 8;
			point2d..ctor(pointAR_Radian9.get_Coordinate(0), pointAR_Radian9.get_Coordinate(1));
			polyline10.AddVertexAt(num14, point2d, 0.0, (double)num, (double)num);
			Polyline polyline11 = polyline;
			int num15 = 9;
			point2d..ctor(pointAR_Radian10.get_Coordinate(0), pointAR_Radian10.get_Coordinate(1));
			polyline11.AddVertexAt(num15, point2d, 0.0, (double)num, (double)num);
			CAD.CreateLayer("柱箍筋", 1, "continuous", -1, false, true);
			polyline.Layer = "柱箍筋";
			CAD.AddEnt(polyline);
			return polyline;
		}

		public Point3d GetPointRotateByPoint(Point3d Po, Point3d P, double A)
		{
			double num = P.DistanceTo(Po);
			double num2 = P.GetVectorTo(Po).AngleOnPlane(new Plane());
			double num3 = Po.X + Math.Cos(A + num2 + 3.1415926535897931) * num;
			double num4 = Po.Y + Math.Sin(A + num2 + 3.1415926535897931) * num;
			Point3d result;
			result..ctor(num3, num4, Po.Z);
			return result;
		}
	}
}
