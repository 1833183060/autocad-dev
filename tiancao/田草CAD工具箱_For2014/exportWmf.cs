using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class exportWmf
	{
		[DebuggerNonUserCode]
		public exportWmf()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcWmfout")]
		public void TcWmfout()
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_28:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_32:
				num2 = 5;
				BlockTableRecord blockTableRecord = new BlockTableRecord();
				IL_3B:
				num2 = 6;
				blockTableRecord.Name = "*U";
				IL_49:
				num2 = 7;
				BlockReference blockReference = null;
				IL_4E:
				num2 = 8;
				editor.WriteMessage("你可以使用wmfopts命令，预先设置wmf输出选项\r\n");
				IL_5B:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						Entity entity = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						Point3d minPoint = entity.GeometricExtents.MinPoint;
						blockTableRecord.Origin = minPoint;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity2 = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
							Entity entity3 = (Entity)entity2.Clone();
							blockTableRecord.AppendEntity(entity3);
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						blockTable.Add(blockTableRecord);
						transaction.AddNewlyCreatedDBObject(blockTableRecord, true);
						BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
						blockReference = new BlockReference(minPoint, blockTableRecord.ObjectId);
						blockTableRecord2.AppendEntity(blockReference);
						transaction.AddNewlyCreatedDBObject(blockReference, true);
						Point3d minPoint2 = blockReference.GeometricExtents.MinPoint;
						Point3d maxPoint = blockReference.GeometricExtents.MaxPoint;
						object systemVariable = Application.GetSystemVariable("TARGET");
						Point3d point3d2;
						Point3d point3d = (systemVariable != null) ? ((Point3d)systemVariable) : point3d2;
						maxPoint..ctor(maxPoint.X - point3d.X, maxPoint.Y - point3d.Y, maxPoint.Z - point3d.Z);
						minPoint2..ctor(minPoint2.X - point3d.X, minPoint2.Y - point3d.Y, minPoint2.Z - point3d.Z);
						checked
						{
							long num3 = (long)Math.Round(unchecked(maxPoint.get_Coordinate(1) - minPoint2.get_Coordinate(1)));
							long num4 = (long)Math.Round(unchecked(maxPoint.get_Coordinate(0) - minPoint2.get_Coordinate(0)));
						}
						double num5 = Math.Abs(minPoint2.get_Coordinate(0) - maxPoint.get_Coordinate(0));
						double num6 = Math.Abs(minPoint2.get_Coordinate(1) - maxPoint.get_Coordinate(1));
						double num7 = num5 / num6;
						num5 = 1000.0;
						num6 = num5 / num7;
						mdiActiveDocument.Window.WindowState = 0;
						Size deviceIndependentSize = new Size(num5, num6);
						mdiActiveDocument.Window.DeviceIndependentSize = deviceIndependentSize;
						exportWmf.SetView(minPoint2, maxPoint, 1.05);
					}
					transaction.Commit();
				}
				IL_314:
				num2 = 11;
				mdiActiveDocument.Editor.WriteMessage("WMF 自动输出到 \"c:\\\\temp.wmf\"\r\n");
				IL_327:
				num2 = 12;
				mdiActiveDocument.SendStringToExecute("(command \"wmfout\" \"c:\\\\temp.wmf\" (handent \"" + blockReference.Handle.ToString() + "\"))\r\n", false, false, false);
				IL_358:
				num2 = 13;
				Thread.Sleep(2000);
				IL_365:
				num2 = 14;
				if (Information.Err().Number == 0)
				{
					goto IL_391;
				}
				IL_37A:
				num2 = 15;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_3BD;
				IL_391:
				num2 = 17;
				IL_394:
				num2 = 18;
				MsgBoxResult msgBoxResult = Interaction.MsgBox("WMF  文件成功导出到  c:\\temp.wmf\r\n\r\n你是否需要打开此文件？", MsgBoxStyle.YesNo, null);
				IL_3A5:
				num2 = 19;
				if (msgBoxResult != MsgBoxResult.Yes)
				{
					goto IL_3BD;
				}
				IL_3AF:
				num2 = 20;
				Process.Start("c:\\temp.wmf");
				IL_3BD:
				goto IL_474;
				IL_3C2:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_42E:
				goto IL_469;
				IL_430:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_3C2;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_446:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_430;
			}
			IL_469:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_474:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public static void SetView(Point3d ptMin, Point3d ptMax, double scale)
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			ViewTableRecord currentView = editor.GetCurrentView();
			currentView.Height = Math.Abs(ptMax.Y - ptMin.Y) * scale;
			currentView.Width = Math.Abs(ptMax.X - ptMin.X) * scale;
			AbstractViewTableRecord abstractViewTableRecord = currentView;
			Point2d centerPoint;
			centerPoint..ctor((ptMax.X + ptMin.X) / 2.0, (ptMax.Y + ptMin.Y) / 2.0);
			abstractViewTableRecord.CenterPoint = centerPoint;
			editor.SetCurrentView(currentView);
			Application.UpdateScreen();
		}

		private static void smethod_0(Editor editor_0, Point3d point3d_0, Point3d point3d_1)
		{
			Point2d point2d;
			point2d..ctor(point3d_0.X, point3d_0.Y);
			Point2d point2d2;
			point2d2..ctor(point3d_1.X, point3d_1.Y);
			editor_0.SetCurrentView(new ViewTableRecord
			{
				CenterPoint = point2d + (point2d2 - point2d) / 2.0,
				Height = point2d2.Y - point2d.Y,
				Width = point2d2.X - point2d.X
			});
		}

		[CommandMethod("TcTZZX")]
		public void TcTZZX()
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
					LinetypeTable linetypeTable = (LinetypeTable)transaction.GetObject(database.LinetypeTableId, 0);
					if (!linetypeTable.Has("Dote"))
					{
						database.LoadLineTypeFile("Dote", "acad.lin");
					}
					transaction.Commit();
				}
				IL_7F:
				num2 = 6;
				CAD.CreateLayer("Dote", 0, "Dote", 9, false, true);
				IL_96:
				num2 = 7;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					LayerTable layerTable = (LayerTable)transaction2.GetObject(database.LayerTableId, 0);
					SymbolTableEnumerator enumerator = layerTable.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId objectId = enumerator.Current;
						LayerTableRecord layerTableRecord = (LayerTableRecord)transaction2.GetObject(objectId, 1);
						if (Operators.CompareString(layerTableRecord.Name.ToUpper(), "DOTE", false) == 0)
						{
							layerTableRecord.Color = Color.FromColorIndex(192, 252);
						}
						layerTableRecord.LineWeight = 9;
					}
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
					transaction2.Commit();
				}
				IL_14F:
				goto IL_1C7;
				IL_151:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_181:
				goto IL_1BC;
				IL_183:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_151;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_199:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_183;
			}
			IL_1BC:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1C7:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcReNameBlock")]
		public void TcReNameBlock()
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
				string defaultResponse = "Tc" + NF.Time2String2();
				IL_1B:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_28:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_32:
				num2 = 5;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_45:
				num2 = 6;
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("选择一个参照块:");
				IL_53:
				num2 = 7;
				PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
				IL_60:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					object @object = transaction.GetObject(entity.ObjectId, 0);
					if (!(@object is BlockReference))
					{
						editor.WriteMessage("\n请重新选择参照块。");
						goto IL_1EB;
					}
					BlockReference blockReference = (BlockReference)@object;
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.BlockTableRecord, 1);
					editor.WriteMessage("\n你选择的图块名称是:" + blockTableRecord.Name);
					string text = Interaction.InputBox("原来参照块名:" + blockTableRecord.Name + ",请输入新的块名:", "重命名参照块", defaultResponse, -1, -1);
					if (Operators.CompareString(text, "", false) != 0)
					{
						blockTableRecord.Name = text;
					}
					transaction.Commit();
				}
				IL_136:
				num2 = 10;
				if (Information.Err().Number == 0)
				{
					goto IL_160;
				}
				IL_14B:
				num2 = 11;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_160:
				goto IL_1EB;
				IL_165:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1A5:
				goto IL_1E0;
				IL_1A7:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_165;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1BD:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1A7;
			}
			IL_1E0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1EB:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("LineToSPline")]
		public void LineToSPline()
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
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
					SymbolTableEnumerator enumerator = blockTable.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId objectId = enumerator.Current;
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(objectId, 1);
						BlockTableRecordEnumerator enumerator2 = blockTableRecord.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ObjectId objectId2 = enumerator2.Current;
							Entity entity = (Entity)transaction.GetObject(objectId2, 1);
							if (entity is Line)
							{
								Line line = (Line)entity;
								Point3dCollection point3dCollection = new Point3dCollection();
								point3dCollection.Add(line.StartPoint);
								point3dCollection.Add(line.EndPoint);
								Spline e = new Spline(point3dCollection, 50, 0.1);
								CAD.AddEnt(e);
								line.Erase();
							}
						}
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
					transaction.Commit();
				}
				IL_13F:
				goto IL_1AB;
				IL_141:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_165:
				goto IL_1A0;
				IL_167:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_141;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_17D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_167;
			}
			IL_1A0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1AB:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("SPlineToLine")]
		public void SPlineToLine()
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
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
					SymbolTableEnumerator enumerator = blockTable.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId objectId = enumerator.Current;
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(objectId, 1);
						BlockTableRecordEnumerator enumerator2 = blockTableRecord.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ObjectId objectId2 = enumerator2.Current;
							Entity entity = (Entity)transaction.GetObject(objectId2, 1);
							if (entity is Spline)
							{
								Spline spline = (Spline)entity;
								Line e = new Line(spline.StartPoint, spline.EndPoint);
								CAD.AddEnt(e);
								spline.Erase();
							}
						}
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
					transaction.Commit();
				}
				IL_11B:
				goto IL_187;
				IL_11D:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_141:
				goto IL_17C;
				IL_143:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_11D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_159:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_143;
			}
			IL_17C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_187:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
