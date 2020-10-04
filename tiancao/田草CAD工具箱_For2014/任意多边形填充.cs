using System;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 任意多边形填充
	{
		[DebuggerNonUserCode]
		public 任意多边形填充()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("任意多边形填充")]
		public void 任意多边形填充()
		{
			int num;
			int num10;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d[] array = new Point3d[2];
				IL_12:
				num2 = 3;
				Class36.smethod_32(ref array[0], ref array[1], "选择插入点:");
				IL_2D:
				num2 = 4;
				short num3 = 1;
				IL_31:
				num2 = 5;
				Polyline polyline = new Polyline();
				for (;;)
				{
					IL_124:
					num2 = 6;
					short num4;
					Polyline polyline2;
					short num6;
					checked
					{
						num3 += 1;
						IL_3F:
						num2 = 7;
						array = (Point3d[])Utils.CopyArray((Array)array, new Point3d[(int)(num3 + 1)]);
						IL_5A:
						num2 = 10;
						num4 = Class36.smethod_29(array[(int)(num3 - 1)], ref array[(int)num3], "选择下一点: ");
						IL_7E:
						num2 = 11;
						if (num4 == 0)
						{
							break;
						}
						IL_8B:
						num2 = 14;
						IL_8E:
						num2 = 15;
						polyline2 = new Polyline();
						IL_98:
						num2 = 16;
						short num5 = 0;
						num6 = (short)Information.UBound(array, 1);
						num4 = num5;
					}
					for (;;)
					{
						short num7 = num4;
						short num8 = num6;
						if (num7 > num8)
						{
							break;
						}
						IL_AA:
						num2 = 17;
						polyline2.AddVertexAt((int)num4, Class36.smethod_38(array[(int)num4]), 0.0, 0.0, 0.0);
						IL_E3:
						num2 = 18;
						num4 += 1;
					}
					IL_F7:
					num2 = 19;
					polyline2.Closed = true;
					IL_102:
					num2 = 20;
					CAD.AddEnt(polyline2);
					IL_10D:
					num2 = 21;
					Class36.smethod_64(polyline.ObjectId);
					IL_11D:
					num2 = 22;
					polyline = polyline2;
				}
				IL_130:
				num2 = 25;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_13F:
				num2 = 26;
				Database database = mdiActiveDocument.Database;
				IL_14B:
				num2 = 27;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					ObjectIdCollection objectIdCollection = new ObjectIdCollection();
					objectIdCollection.Add(polyline.ObjectId);
					Hatch hatch = new Hatch();
					blockTableRecord.AppendEntity(hatch);
					transaction.AddNewlyCreatedDBObject(hatch, true);
					hatch.SetDatabaseDefaults();
					hatch.PatternScale = 500.0;
					hatch.SetHatchPattern(1, "grass");
					hatch.Associative = true;
					hatch.AppendLoop(16, objectIdCollection);
					hatch.EvaluateHatch(true);
					transaction.Commit();
				}
				IL_218:
				num2 = 29;
				Class36.smethod_64(polyline.ObjectId);
				IL_228:
				num2 = 30;
				if (Information.Err().Number <= 0)
				{
					goto IL_24F;
				}
				IL_23A:
				num2 = 31;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_24F:
				goto IL_331;
				IL_254:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_2E8:
				goto IL_326;
				IL_2EA:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_254;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_303:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2EA;
			}
			IL_326:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_331:
			if (num10 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcRecHatch")]
		public void TcRecHatch()
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
				Polyline polyline = new Polyline();
				IL_11:
				num2 = 3;
				Point3d point3d_;
				Point3d point3d_2;
				Class36.smethod_33(ref point3d_, ref point3d_2);
				IL_1D:
				num2 = 4;
				polyline = Class36.smethod_17(point3d_, point3d_2);
				IL_28:
				num2 = 5;
				string text = Conversions.ToString(Application.GetSystemVariable("CPROFILE"));
				IL_3B:
				num2 = 6;
				if (Operators.CompareString(text.ToUpper().Substring(0, 4), "TSSD", false) != 0)
				{
					goto IL_66;
				}
				IL_5B:
				num2 = 7;
				string text2 = "AN31C";
				goto IL_A0;
				IL_66:
				num2 = 9;
				if (Operators.CompareString(text.ToUpper().Substring(0, 4), "TARC", false) != 0)
				{
					goto IL_93;
				}
				IL_87:
				num2 = 10;
				text2 = "钢筋混凝土";
				goto IL_A0;
				IL_93:
				num2 = 12;
				IL_96:
				num2 = 13;
				text2 = "ARMORED";
				IL_A0:
				num2 = 15;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_AF:
				num2 = 16;
				Database database = mdiActiveDocument.Database;
				IL_BB:
				num2 = 17;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					ObjectIdCollection objectIdCollection = new ObjectIdCollection();
					objectIdCollection.Add(polyline.ObjectId);
					Hatch hatch = new Hatch();
					blockTableRecord.AppendEntity(hatch);
					transaction.AddNewlyCreatedDBObject(hatch, true);
					hatch.SetDatabaseDefaults();
					hatch.PatternScale = 25.0;
					hatch.SetHatchPattern(1, text2);
					hatch.Associative = true;
					hatch.AppendLoop(16, objectIdCollection);
					hatch.EvaluateHatch(true);
					transaction.Commit();
				}
				IL_184:
				num2 = 19;
				Class36.smethod_64(polyline.ObjectId);
				IL_193:
				num2 = 20;
				if (Information.Err().Number <= 0)
				{
					goto IL_1BA;
				}
				IL_1A5:
				num2 = 21;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1BA:
				goto IL_271;
				IL_1BF:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_22B:
				goto IL_266;
				IL_22D:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1BF;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_243:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_22D;
			}
			IL_266:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_271:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("AddHatch")]
		public void AddHatch()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				Circle circle = new Circle();
				circle.SetDatabaseDefaults();
				Circle circle2 = circle;
				Point3d center;
				center..ctor(3.0, 3.0, 0.0);
				circle2.Center = center;
				circle.Radius = 10000.0;
				blockTableRecord.AppendEntity(circle);
				transaction.AddNewlyCreatedDBObject(circle, true);
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				objectIdCollection.Add(circle.ObjectId);
				Hatch hatch = new Hatch();
				blockTableRecord.AppendEntity(hatch);
				transaction.AddNewlyCreatedDBObject(hatch, true);
				hatch.SetDatabaseDefaults();
				hatch.SetHatchPattern(1, "ANSI31");
				hatch.Associative = true;
				hatch.AppendLoop(16, objectIdCollection);
				hatch.EvaluateHatch(true);
				transaction.Commit();
			}
		}
	}
}
