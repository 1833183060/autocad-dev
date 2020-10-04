using System;
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
	public class Rec
	{
		[DebuggerNonUserCode]
		public Rec()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcPLHatch")]
		public void method_0()
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
						Polyline polyline = (Polyline)transaction.GetObject(value[0].ObjectId, 1);
						string layer = polyline.Layer;
						polyline.Closed = true;
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							polyline = (Polyline)transaction.GetObject(objectId, 1);
							polyline.Closed = true;
							if (Operators.CompareString(layer, "砼墙", false) == 0 | Operators.CompareString(layer, "墙边线", false) == 0)
							{
								CAD.CreateLayer("墙填充", 104, "continuous", 13, false, true);
								Class36.smethod_76(polyline, "墙填充", "钢筋混凝土", 50.0);
							}
							else if (Operators.CompareString(layer, "墙柱轮廓(虚)", false) == 0)
							{
								CAD.CreateLayer("墙柱填充", 60, "Continuous", 13, false, true);
								Class36.smethod_76(polyline, "墙柱填充", "SOLID", 0.0);
							}
							else
							{
								Class36.smethod_76(polyline, layer, "SOLID", 0.0);
							}
						}
					}
					transaction.Commit();
				}
				IL_1CD:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_1F2;
				}
				IL_1DE:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1F2:
				goto IL_26E;
				IL_1F4:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_228:
				goto IL_263;
				IL_22A:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1F4;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_240:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_22A;
			}
			IL_263:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_26E:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcPLHatch1")]
		public void method_1()
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
				CAD.CreateLayer("墙柱填充", 104, "continuous", 13, false, true);
				IL_2E:
				num2 = 4;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_36:
				num2 = 5;
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
						Polyline polyline = (Polyline)transaction.GetObject(value[0].ObjectId, 1);
						polyline.Closed = true;
						foreach (ObjectId objectId in value.GetObjectIds())
						{
							polyline = (Polyline)transaction.GetObject(objectId, 1);
							polyline.Closed = true;
							if (Class36.smethod_76(polyline, "柱填充", "AN31C", 25.0) == null && Class36.smethod_76(polyline, "柱填充", "ARMORED", 25.0) == null)
							{
								Class36.smethod_76(polyline, "柱填充", "钢筋混凝土", 50.0);
							}
						}
					}
					transaction.Commit();
				}
				IL_18E:
				num2 = 7;
				if (Information.Err().Number <= 0)
				{
				}
				IL_19F:
				goto IL_21B;
				IL_1A1:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1D5:
				goto IL_210;
				IL_1D7:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1A1;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1ED:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D7;
			}
			IL_210:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21B:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcSOREC")]
		public void TcSOREC()
		{
			int num;
			int num2;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					Point3d point3d;
					Point3d point3d2;
					Class36.smethod_33(ref point3d, ref point3d2);
					Point3d point3d3;
					point3d3..ctor(point3d.get_Coordinate(0), point3d2.get_Coordinate(1), 0.0);
					Point3d point3d4;
					point3d4..ctor(point3d2.get_Coordinate(0), point3d.get_Coordinate(1), 0.0);
					Solid solid = new Solid(point3d, point3d4, point3d3, point3d2);
					solid.SetDatabaseDefaults();
					blockTableRecord.AppendEntity(solid);
					transaction.AddNewlyCreatedDBObject(solid, true);
					transaction.Commit();
				}
				goto IL_138;
				IL_E1:
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_138;
				IL_F5:
				num2 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_10A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num2 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_F5;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_138:
			if (num2 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcREC1")]
		public void TcREC1()
		{
			int num;
			int num8;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					PromptPointOptions promptPointOptions = new PromptPointOptions("");
					promptPointOptions.Message = "\n请选择其中一个角点: ";
					PromptPointResult promptPointResult = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
					Point3d point3d = promptPointResult.Value;
					PromptCornerOptions promptCornerOptions = new PromptCornerOptions("请选择一个对角点:", point3d);
					promptPointResult = mdiActiveDocument.Editor.GetCorner(promptCornerOptions);
					Point3d point3d2 = promptPointResult.Value;
					Point3d point3d3;
					point3d3..ctor(Math.Min(point3d.get_Coordinate(0), point3d2.get_Coordinate(0)), Math.Min(point3d.get_Coordinate(1), point3d2.get_Coordinate(1)), 0.0);
					Point3d point3d4;
					point3d4..ctor(Math.Max(point3d.get_Coordinate(0), point3d2.get_Coordinate(0)), Math.Max(point3d.get_Coordinate(1), point3d2.get_Coordinate(1)), 0.0);
					point3d = point3d3;
					point3d2 = point3d4;
					Point3d point3d5;
					point3d5..ctor(point3d.get_Coordinate(0), point3d2.get_Coordinate(1), 0.0);
					Point3d point3d6;
					point3d6..ctor(point3d2.get_Coordinate(0), point3d.get_Coordinate(1), 0.0);
					Polyline polyline = new Polyline();
					polyline.SetDatabaseDefaults();
					Polyline polyline2 = polyline;
					int num2 = 0;
					Point2d point2d;
					point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
					polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
					Polyline polyline3 = polyline;
					int num3 = 1;
					point2d..ctor(point3d5.get_Coordinate(0), point3d5.get_Coordinate(1));
					polyline3.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
					Polyline polyline4 = polyline;
					int num4 = 2;
					point2d..ctor(point3d2.get_Coordinate(0), point3d2.get_Coordinate(1));
					polyline4.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
					Polyline polyline5 = polyline;
					int num5 = 3;
					point2d..ctor(point3d6.get_Coordinate(0), point3d6.get_Coordinate(1));
					polyline5.AddVertexAt(num5, point2d, 0.0, 0.0, 0.0);
					polyline.Closed = true;
					blockTableRecord.AppendEntity(polyline);
					transaction.AddNewlyCreatedDBObject(polyline, true);
					point3d = polyline.GeometricExtents.MinPoint;
					point3d2 = polyline.GeometricExtents.MaxPoint;
					point3d5..ctor(point3d.get_Coordinate(0), point3d2.get_Coordinate(1), 0.0);
					double num6 = point3d.DistanceTo(point3d5);
					double num7 = point3d.DistanceTo(point3d6);
					Point3d pointAngle;
					if (num6 > num7)
					{
						pointAngle = CAD.GetPointAngle(point3d5, num7 / 5.0, -45.0);
					}
					else
					{
						pointAngle = CAD.GetPointAngle(point3d5, num6 / 5.0, -45.0);
					}
					Solid solid = new Solid(point3d, point3d5, pointAngle, point3d2);
					solid.SetDatabaseDefaults();
					blockTableRecord.AppendEntity(solid);
					transaction.AddNewlyCreatedDBObject(solid, true);
					transaction.Commit();
				}
				goto IL_3B9;
				IL_362:
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_3B9;
				IL_376:
				num8 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_38B:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_376;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3B9:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcREC2")]
		public void TcREC2()
		{
			int num;
			int num12;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					PromptPointOptions promptPointOptions = new PromptPointOptions("");
					promptPointOptions.Message = "\n请选择其中一个角点: ";
					PromptPointResult promptPointResult = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
					Point3d point3d = promptPointResult.Value;
					PromptCornerOptions promptCornerOptions = new PromptCornerOptions("请选择一个对角点:", point3d);
					promptPointResult = mdiActiveDocument.Editor.GetCorner(promptCornerOptions);
					Point3d point3d2 = promptPointResult.Value;
					Point3d point3d3;
					point3d3..ctor(Math.Min(point3d.get_Coordinate(0), point3d2.get_Coordinate(0)), Math.Min(point3d.get_Coordinate(1), point3d2.get_Coordinate(1)), 0.0);
					Point3d point3d4;
					point3d4..ctor(Math.Max(point3d.get_Coordinate(0), point3d2.get_Coordinate(0)), Math.Max(point3d.get_Coordinate(1), point3d2.get_Coordinate(1)), 0.0);
					point3d = point3d3;
					point3d2 = point3d4;
					Point3d point3d5;
					point3d5..ctor(point3d.get_Coordinate(0), point3d2.get_Coordinate(1), 0.0);
					Point3d point3d6;
					point3d6..ctor(point3d2.get_Coordinate(0), point3d.get_Coordinate(1), 0.0);
					Polyline polyline = new Polyline();
					polyline.SetDatabaseDefaults();
					Polyline polyline2 = polyline;
					int num2 = 0;
					Point2d point2d;
					point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
					polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
					Polyline polyline3 = polyline;
					int num3 = 1;
					point2d..ctor(point3d5.get_Coordinate(0), point3d5.get_Coordinate(1));
					polyline3.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
					Polyline polyline4 = polyline;
					int num4 = 2;
					point2d..ctor(point3d2.get_Coordinate(0), point3d2.get_Coordinate(1));
					polyline4.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
					Polyline polyline5 = polyline;
					int num5 = 3;
					point2d..ctor(point3d6.get_Coordinate(0), point3d6.get_Coordinate(1));
					polyline5.AddVertexAt(num5, point2d, 0.0, 0.0, 0.0);
					polyline.Closed = true;
					blockTableRecord.AppendEntity(polyline);
					transaction.AddNewlyCreatedDBObject(polyline, true);
					point3d = polyline.GeometricExtents.MinPoint;
					point3d2 = polyline.GeometricExtents.MaxPoint;
					point3d5..ctor(point3d.get_Coordinate(0), point3d2.get_Coordinate(1), 0.0);
					double num6 = point3d.DistanceTo(point3d5);
					double num7 = point3d.DistanceTo(point3d6);
					Point3d pointAngle;
					if (num6 > num7)
					{
						pointAngle = CAD.GetPointAngle(point3d5, num7 / 5.0, -45.0);
					}
					else
					{
						pointAngle = CAD.GetPointAngle(point3d5, num6 / 5.0, -45.0);
					}
					polyline = new Polyline();
					Polyline polyline6 = polyline;
					int num8 = 0;
					point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
					polyline6.AddVertexAt(num8, point2d, 0.0, 0.0, 0.0);
					Polyline polyline7 = polyline;
					int num9 = 1;
					point2d..ctor(point3d5.get_Coordinate(0), point3d5.get_Coordinate(1));
					polyline7.AddVertexAt(num9, point2d, 0.0, 0.0, 0.0);
					Polyline polyline8 = polyline;
					int num10 = 2;
					point2d..ctor(point3d2.get_Coordinate(0), point3d2.get_Coordinate(1));
					polyline8.AddVertexAt(num10, point2d, 0.0, 0.0, 0.0);
					Polyline polyline9 = polyline;
					int num11 = 3;
					point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
					polyline9.AddVertexAt(num11, point2d, 0.0, 0.0, 0.0);
					polyline.Closed = true;
					blockTableRecord.AppendEntity(polyline);
					transaction.AddNewlyCreatedDBObject(polyline, true);
					transaction.Commit();
				}
				goto IL_4A2;
				IL_44B:
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_4A2;
				IL_45F:
				num12 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_474:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num12 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_45F;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_4A2:
			if (num12 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcLTTL")]
		public void TcLTTL()
		{
			int num;
			int num10;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					PromptPointOptions promptPointOptions = new PromptPointOptions("");
					promptPointOptions.Message = "\n请选择其中一个角点: ";
					PromptPointResult promptPointResult = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
					if (promptPointResult.Status == 5100)
					{
						Point3d point3d = promptPointResult.Value;
						PromptCornerOptions promptCornerOptions = new PromptCornerOptions("请选择一个对角点:", point3d);
						promptPointResult = mdiActiveDocument.Editor.GetCorner(promptCornerOptions);
						if (promptPointResult.Status == 5100)
						{
							Point3d value = promptPointResult.Value;
							Point3d point3d2;
							point3d2..ctor(Math.Min(point3d.get_Coordinate(0), value.get_Coordinate(0)), Math.Min(point3d.get_Coordinate(1), value.get_Coordinate(1)), 0.0);
							Point3d point3d3;
							point3d3..ctor(Math.Max(point3d.get_Coordinate(0), value.get_Coordinate(0)), Math.Max(point3d.get_Coordinate(1), value.get_Coordinate(1)), 0.0);
							point3d = point3d2;
							Point3d point3d4 = point3d3;
							value..ctor(point3d.get_Coordinate(0), point3d4.get_Coordinate(1), 0.0);
							Point3d point3d5;
							point3d5..ctor(point3d4.get_Coordinate(0), point3d.get_Coordinate(1), 0.0);
							Polyline polyline = new Polyline();
							polyline.SetDatabaseDefaults();
							Polyline polyline2 = polyline;
							int num2 = 0;
							Point2d point2d;
							point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
							polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
							Polyline polyline3 = polyline;
							int num3 = 1;
							point2d..ctor(value.get_Coordinate(0), value.get_Coordinate(1));
							polyline3.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
							Polyline polyline4 = polyline;
							int num4 = 2;
							point2d..ctor(point3d4.get_Coordinate(0), point3d4.get_Coordinate(1));
							polyline4.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
							Polyline polyline5 = polyline;
							int num5 = 3;
							point2d..ctor(point3d5.get_Coordinate(0), point3d5.get_Coordinate(1));
							polyline5.AddVertexAt(num5, point2d, 0.0, 0.0, 0.0);
							Polyline polyline6 = polyline;
							int num6 = 4;
							point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
							polyline6.AddVertexAt(num6, point2d, 0.0, 0.0, 0.0);
							Polyline polyline7 = polyline;
							int num7 = 5;
							point2d..ctor(point3d4.get_Coordinate(0), point3d4.get_Coordinate(1));
							polyline7.AddVertexAt(num7, point2d, 0.0, 0.0, 0.0);
							Polyline polyline8 = polyline;
							int num8 = 6;
							point2d..ctor(value.get_Coordinate(0), value.get_Coordinate(1));
							polyline8.AddVertexAt(num8, point2d, 0.0, 0.0, 0.0);
							Polyline polyline9 = polyline;
							int num9 = 7;
							point2d..ctor(point3d5.get_Coordinate(0), point3d5.get_Coordinate(1));
							polyline9.AddVertexAt(num9, point2d, 0.0, 0.0, 0.0);
							polyline.Closed = true;
							blockTableRecord.AppendEntity(polyline);
							transaction.AddNewlyCreatedDBObject(polyline, true);
							transaction.Commit();
						}
					}
				}
				goto IL_410;
				IL_3B9:
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_410;
				IL_3CD:
				num10 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_3E2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_3CD;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_410:
			if (num10 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
