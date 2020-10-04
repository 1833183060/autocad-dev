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
	public class 绘制屋面布置
	{
		[DebuggerNonUserCode]
		public 绘制屋面布置()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcWuMian")]
		public void TcWuMian()
		{
			int num;
			int num18;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				long[] array = null;
				IL_0D:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_1A:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_24:
				num2 = 5;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array2 = new TypedValue[1];
					Array array3 = array2;
					TypedValue typedValue;
					typedValue..ctor(0, "TEXT");
					array3.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array2);
					Class36.smethod_60("请按照顺序选择>");
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					short num3;
					double num9;
					Point3d[] array4;
					short num15;
					checked
					{
						short num6;
						if (selection.Status == 5100)
						{
							SelectionSet value = selection.Value;
							num3 = (short)(value.Count - 1);
							array = new long[(int)(num3 + 1)];
							short num4 = 0;
							short num5 = num3;
							num6 = num4;
							for (;;)
							{
								short num7 = num6;
								short num8 = num5;
								if (num7 > num8)
								{
									break;
								}
								DBText dbtext = (DBText)transaction.GetObject(value[(int)num6].ObjectId, 1);
								array[(int)num6] = (long)Math.Round(Conversion.Val(dbtext.TextString));
								unchecked
								{
									num6 += 1;
								}
							}
						}
						num9 = Class36.smethod_30("请输入跨度(默认6000):", 6000.0);
						array4 = new Point3d[(int)(num3 + 1)];
						array4[0] = CAD.GetPoint("选择插入点: ");
						Point3d point3d;
						if (array4[0] == point3d)
						{
							goto IL_5A1;
						}
						short num10 = 0;
						short num11 = (short)(Information.UBound(array, 1) - 1);
						num6 = num10;
						Point3d pointAngle;
						for (;;)
						{
							short num12 = num6;
							short num8 = num11;
							if (num12 > num8)
							{
								break;
							}
							pointAngle = CAD.GetPointAngle(array4[(int)num6], num9, 0.0);
							CAD.AddLine(array4[(int)num6], pointAngle, "0");
							array4[(int)(num6 + 1)] = CAD.GetPointAngle(array4[(int)num6], (double)array[(int)num6], 270.0);
							unchecked
							{
								num6 += 1;
							}
						}
						pointAngle = CAD.GetPointAngle(array4[(int)num6], num9, 0.0);
						CAD.AddLine(array4[(int)num6], pointAngle, "0");
						Point3d[] array5 = new Point3d[4];
						Point3d[] array6 = new Point3d[4];
						pointAngle = CAD.GetPointAngle(array4[0], num9, 0.0);
						array5[0] = CAD.GetPointAngle(array4[0], 200.0, 45.0);
						array5[1] = CAD.GetPointAngle(array4[0], 200.0, 315.0);
						array6[0] = CAD.GetPointAngle(pointAngle, 200.0, 135.0);
						array6[1] = CAD.GetPointAngle(pointAngle, 200.0, 225.0);
						pointAngle = CAD.GetPointAngle(array4[1], num9, 0.0);
						Point3d p = Class36.smethod_46(array4[1], pointAngle);
						array5[2] = CAD.GetPointAngle(p, 200.0, 135.0);
						array5[3] = CAD.GetPointAngle(p, 200.0, 225.0);
						array6[2] = CAD.GetPointAngle(p, 200.0, 45.0);
						array6[3] = CAD.GetPointAngle(p, 200.0, 315.0);
						Point3d pointAngle2 = CAD.GetPointAngle(p, 141.0, 90.0);
						Point3d pointAngle3 = CAD.GetPointAngle(p, (double)(array[0] + 141L), 270.0);
						CAD.AddPline(array5, 0.0, false, "");
						CAD.AddPline(array6, 0.0, false, "");
						CAD.AddLine(pointAngle2, pointAngle3, "0");
						short num13 = (short)Math.Round(unchecked((double)Information.UBound(array, 1) / 2.0 - 1.0));
						short num14 = 1;
						num15 = num13 - 1;
						num3 = num14;
					}
					for (;;)
					{
						short num16 = num3;
						short num8 = num15;
						if (num16 > num8)
						{
							break;
						}
						Point3d pointAngle = CAD.GetPointAngle(array4[(int)num3], num9 / 2.0 + Math.Pow(-1.0, (double)num3) * 70.0, 0.0);
						Point3d pointAngle4 = CAD.GetPointAngle(pointAngle, (double)array[(int)num3], 270.0);
						CAD.AddLine(pointAngle, pointAngle4, "0");
						num3 += 1;
					}
					transaction.Commit();
				}
				IL_4FC:
				num2 = 7;
				if (Information.Err().Number <= 0)
				{
					goto IL_521;
				}
				IL_50D:
				num2 = 8;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_521:
				goto IL_5A1;
				IL_523:
				int num17 = num18 + 1;
				num18 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num17);
				IL_55B:
				goto IL_596;
				IL_55D:
				num18 = num2;
				if (num <= -2)
				{
					goto IL_523;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_573:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num18 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_55D;
			}
			IL_596:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_5A1:
			if (num18 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
