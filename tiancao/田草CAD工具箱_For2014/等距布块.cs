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
	public class 等距布块
	{
		[DebuggerNonUserCode]
		public 等距布块()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("选择图块")]
		public void 选择图块()
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
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("选择一个对象:");
				IL_40:
				num2 = 6;
				PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
				IL_4D:
				num2 = 7;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					object @object = transaction.GetObject(entity.ObjectId, 0);
					string fullName = @object.GetType().FullName;
					string left = fullName.Substring(Strings.InStrRev(fullName, ".", -1, CompareMethod.Binary));
					if (Operators.CompareString(left, "BlockReference", false) != 0)
					{
						editor.WriteMessage("\n请重新选择参照块。");
						goto IL_1C9;
					}
					BlockReference blockReference = (BlockReference)@object;
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.BlockTableRecord, 0);
					Application.SetSystemVariable("USERS1", blockTableRecord.Name);
					editor.WriteMessage("\n你选择的图块名称是:" + blockTableRecord.Name);
					transaction.Commit();
				}
				IL_118:
				num2 = 9;
				if (Information.Err().Number == 0)
				{
					goto IL_142;
				}
				IL_12D:
				num2 = 10;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_142:
				goto IL_1C9;
				IL_147:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_183:
				goto IL_1BE;
				IL_185:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_147;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19B:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_185;
			}
			IL_1BE:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1C9:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("等距布块")]
		public void 等距布块()
		{
			int num;
			int num31;
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
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("选择一个对象:");
				IL_40:
				num2 = 6;
				PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
				IL_4D:
				num2 = 7;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					object @object = transaction.GetObject(entity.ObjectId, 1);
					string fullName = @object.GetType().FullName;
					string left = fullName.Substring(Strings.InStrRev(fullName, ".", -1, CompareMethod.Binary));
					double num3 = Class36.smethod_30("指定长度(4000):", 4000.0);
					string text = Conversions.ToString(Application.GetSystemVariable("USERS1"));
					if (Operators.CompareString(text, "", false) != 0)
					{
						if (Operators.CompareString(left, "Line", false) == 0)
						{
							Line line = (Line)transaction.GetObject(entity.ObjectId, 1);
							double a = line.StartPoint.DistanceTo(line.EndPoint);
							short num6;
							short num7;
							checked
							{
								short num4 = (short)((long)Math.Round(a) / (long)Math.Round(num3));
								short num5 = 0;
								num6 = num4 - 1;
								num7 = num5;
							}
							for (;;)
							{
								short num8 = num7;
								short num9 = num6;
								if (num8 > num9)
								{
									break;
								}
								Point3d pointAtDist = line.GetPointAtDist(num3 * (double)(checked(num7 + 1)));
								CAD.AddPoint(pointAtDist);
								Class36.smethod_75(pointAtDist, text);
								num7 += 1;
							}
						}
						else if (Operators.CompareString(left, "Polyline", false) == 0)
						{
							Polyline polyline = (Polyline)transaction.GetObject(entity.ObjectId, 1);
							double distanceAtParameter = polyline.GetDistanceAtParameter(polyline.EndParam);
							short num12;
							short num13;
							checked
							{
								short num10 = (short)((long)Math.Round(distanceAtParameter) / (long)Math.Round(num3));
								short num11 = 0;
								num12 = num10 - 1;
								num13 = num11;
							}
							for (;;)
							{
								short num14 = num13;
								short num9 = num12;
								if (num14 > num9)
								{
									break;
								}
								Point3d pointAtDist2 = polyline.GetPointAtDist(num3 * (double)(checked(num13 + 1)));
								CAD.AddPoint(pointAtDist2);
								Class36.smethod_75(pointAtDist2, text);
								num13 += 1;
							}
						}
						else if (Operators.CompareString(left, "Arc", false) == 0)
						{
							Arc arc = (Arc)transaction.GetObject(entity.ObjectId, 1);
							double distanceAtParameter2 = arc.GetDistanceAtParameter(arc.EndParam);
							short num17;
							short num18;
							checked
							{
								short num15 = (short)((long)Math.Round(distanceAtParameter2) / (long)Math.Round(num3));
								short num16 = 0;
								num17 = num15 - 1;
								num18 = num16;
							}
							for (;;)
							{
								short num19 = num18;
								short num9 = num17;
								if (num19 > num9)
								{
									break;
								}
								Point3d pointAtDist3 = arc.GetPointAtDist(num3 * (double)(checked(num18 + 1)));
								CAD.AddPoint(pointAtDist3);
								Class36.smethod_75(pointAtDist3, text);
								num18 += 1;
							}
						}
						else if (Operators.CompareString(left, "Circle", false) == 0)
						{
							Circle circle = (Circle)transaction.GetObject(entity.ObjectId, 1);
							double distanceAtParameter3 = circle.GetDistanceAtParameter(circle.EndParam);
							short num22;
							short num23;
							checked
							{
								short num20 = (short)((long)Math.Round(distanceAtParameter3) / (long)Math.Round(num3));
								short num21 = 0;
								num22 = num20 - 1;
								num23 = num21;
							}
							for (;;)
							{
								short num24 = num23;
								short num9 = num22;
								if (num24 > num9)
								{
									break;
								}
								Point3d pointAtDist4 = circle.GetPointAtDist(num3 * (double)(checked(num23 + 1)));
								CAD.AddPoint(pointAtDist4);
								Class36.smethod_75(pointAtDist4, text);
								num23 += 1;
							}
						}
						else if (Operators.CompareString(left, "Spline", false) == 0)
						{
							Spline spline = (Spline)transaction.GetObject(entity.ObjectId, 1);
							double distanceAtParameter4 = spline.GetDistanceAtParameter(spline.EndParam);
							short num27;
							short num28;
							checked
							{
								short num25 = (short)((long)Math.Round(distanceAtParameter4) / (long)Math.Round(num3));
								short num26 = 0;
								num27 = num25 - 1;
								num28 = num26;
							}
							for (;;)
							{
								short num29 = num28;
								short num9 = num27;
								if (num29 > num9)
								{
									break;
								}
								Point3d pointAtDist5 = spline.GetPointAtDist(num3 * (double)(checked(num28 + 1)));
								CAD.AddPoint(pointAtDist5);
								Class36.smethod_75(pointAtDist5, text);
								num28 += 1;
							}
						}
					}
					transaction.Commit();
				}
				IL_3C7:
				num2 = 9;
				if (Information.Err().Number == 0)
				{
					goto IL_3F1;
				}
				IL_3DC:
				num2 = 10;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_3F1:
				goto IL_478;
				IL_3F6:
				int num30 = num31 + 1;
				num31 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num30);
				IL_432:
				goto IL_46D;
				IL_434:
				num31 = num2;
				if (num <= -2)
				{
					goto IL_3F6;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_44A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num31 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_434;
			}
			IL_46D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_478:
			if (num31 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
