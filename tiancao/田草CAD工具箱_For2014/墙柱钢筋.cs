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
	public class 墙柱钢筋
	{
		[DebuggerNonUserCode]
		public 墙柱钢筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcQLJ")]
		public void TcQLJ()
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
						if (value.Count == 1)
						{
							goto IL_285;
						}
						Entity e = null;
						Entity e2 = null;
						if (value.Count > 2)
						{
							e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
							e2 = (Entity)transaction.GetObject(value[checked(value.Count - 1)].ObjectId, 0);
						}
						else if (value.Count == 2)
						{
							e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
							e2 = (Entity)transaction.GetObject(value[1].ObjectId, 0);
						}
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
							Class36.double_0 = 4.0;
						}
						Class36.smethod_13(point3d, point3d2, Class36.double_0 / 2.0);
					}
					transaction.Commit();
				}
				IL_1E4:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_209;
				}
				IL_1F5:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_209:
				goto IL_285;
				IL_20B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_23F:
				goto IL_27A;
				IL_241:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_20B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_257:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_241;
			}
			IL_27A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_285:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQLJ_YJK")]
		public void TcQLJ_YJK()
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
						if (value.Count == 1)
						{
							goto IL_27B;
						}
						Entity e = null;
						Entity e2 = null;
						if (value.Count > 2)
						{
							e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
							e2 = (Entity)transaction.GetObject(value[checked(value.Count - 1)].ObjectId, 0);
						}
						else if (value.Count == 2)
						{
							e = (Entity)transaction.GetObject(value[0].ObjectId, 0);
							e2 = (Entity)transaction.GetObject(value[1].ObjectId, 0);
						}
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
							Class36.double_0 = 4.0;
						}
						Class36.smethod_91(point3d, point3d2, Class36.double_0);
					}
					transaction.Commit();
				}
				IL_1DA:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_1FF;
				}
				IL_1EB:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1FF:
				goto IL_27B;
				IL_201:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_235:
				goto IL_270;
				IL_237:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_201;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_24D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_237;
			}
			IL_270:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_27B:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQGJ_YJK_X")]
		public void TcQGJ_YJK_X()
		{
			int num;
			int num8;
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
						Point3d point3d_;
						point3d_..ctor(num3, num4, 0.0);
						Point3d point3d_2;
						point3d_2..ctor(num5, num6, 0.0);
						Class36.smethod_89(point3d_, point3d_2, Class36.double_0);
					}
					transaction.Commit();
				}
				IL_1BD:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_1E2;
				}
				IL_1CE:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1E2:
				goto IL_25E;
				IL_1E4:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_218:
				goto IL_253;
				IL_21A:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_1E4;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_230:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_21A;
			}
			IL_253:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_25E:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQGJ_YJK_D")]
		public void TcQGJ_YJK_D()
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
				Class36.smethod_31(ref point3d_, ref point3d_2, "不在同一直线上的两点:");
				IL_1A:
				num2 = 3;
				Class36.smethod_90(point3d_, point3d_2, Class36.double_0);
				IL_29:
				goto IL_91;
				IL_2B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_4B:
				goto IL_86;
				IL_4D:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_2B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_63:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4D;
			}
			IL_86:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_91:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQGJ_X")]
		public void TcQGJ_X()
		{
			int num;
			int num8;
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
						Point3d point3d_;
						point3d_..ctor(num3, num4, 0.0);
						Point3d point3d_2;
						point3d_2..ctor(num5, num6, 0.0);
						Class36.smethod_14(point3d_, point3d_2, Class36.double_0 / 2.0);
					}
					transaction.Commit();
				}
				IL_1C7:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_1EC;
				}
				IL_1D8:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1EC:
				goto IL_268;
				IL_1EE:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_222:
				goto IL_25D;
				IL_224:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_1EE;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_23A:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_224;
			}
			IL_25D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_268:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQGJ_D")]
		public void TcQGJ_D()
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
				Class36.smethod_31(ref point3d_, ref point3d_2, "不在同一直线上的两点:");
				IL_1A:
				num2 = 3;
				Class36.smethod_15(point3d_, point3d_2, Class36.double_0 / 2.0);
				IL_33:
				goto IL_9B;
				IL_35:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_55:
				goto IL_90;
				IL_57:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_35;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_6D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_57;
			}
			IL_90:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_9B:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
