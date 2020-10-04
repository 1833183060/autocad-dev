using System;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class JM
	{
		[DebuggerNonUserCode]
		public JM()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcLJM")]
		public void TcLJM()
		{
			LJM_Frm ljm_Frm = new LJM_Frm();
			ljm_Frm.ShowDialog();
			checked
			{
				if (ljm_Frm.DialogResult == DialogResult.OK)
				{
					string text = ljm_Frm.TextBox1.Text;
					text = text.Replace("\\", "/");
					text = text.Replace(" ", "/");
					text = text.Replace(",", "/");
					text = text.Replace("，", "/");
					text = text.Replace("、", "/");
					int num = Strings.InStr(text, "/", CompareMethod.Binary);
					long num2 = (long)Math.Round(unchecked(Conversion.Val(text.Substring(0, checked(num - 1))) * 5.0));
					long num3 = (long)Math.Round(unchecked(Conversion.Val(text.Substring(num, checked(text.Length - num))) * 5.0));
					Point3d point = CAD.GetPoint("选择插入点: ");
					Point3d point3d;
					if (!(point == point3d))
					{
						Point3d pointXY = CAD.GetPointXY(point, (double)num2 / 2.0, (double)num3 / 2.0);
						Point3d pointXY2 = CAD.GetPointXY(point, (double)(0L - num2) / 2.0, (double)num3 / 2.0);
						Point3d pointXY3 = CAD.GetPointXY(point, (double)(0L - num2) / 2.0, (double)(0L - num3) / 2.0);
						Point3d pointXY4 = CAD.GetPointXY(point, (double)num2 / 2.0, (double)(0L - num3) / 2.0);
						Point3d pointAngle = CAD.GetPointAngle(pointXY, 250.0, -135.0);
						Point3d point3d2 = CAD.GetPointAngle(pointXY2, 250.0, -45.0);
						Point3d pointAngle2 = CAD.GetPointAngle(pointXY3, 250.0, 45.0);
						Point3d pointAngle3 = CAD.GetPointAngle(pointXY4, 250.0, 135.0);
						Point3d pointXY5 = CAD.GetPointXY(point, (double)(0L - num2) / 2.0, (double)(0L - num3) / 2.0);
						CAD.AddPlinePxy(pointXY5, (double)num2, (double)num3, 0.0, "");
						text = JG.ReplaceGJ(ljm_Frm.TextBox2.Text);
						num = NF.InStr_N(text, "/");
						Point3d[] array;
						Point3d[] array2;
						if (num == 1)
						{
							short num4 = (short)Strings.InStr(text, "/", CompareMethod.Binary);
							short num5 = (short)Math.Round(Conversion.Val(text.Substring((int)(num4 - 9), 1)));
							short num6 = (short)Math.Round(Conversion.Val(text.Substring((int)num4, 1)));
							array = new Point3d[(int)(unchecked(num5 + num6) - 1 + 1)];
							array2 = new Point3d[(int)(num5 - 3 + 1)];
							array[0] = point3d2;
							Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
							array[(int)(unchecked(num5 + num6) - 1)] = pointAngle;
							Class36.smethod_16(array[(int)(unchecked(num5 + num6) - 1)], 50.0, "墙柱纵筋");
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num5 - 2 + 1));
							short num7 = 1;
							short num8 = num5 - 2;
							num4 = num7;
							for (;;)
							{
								short num9 = num4;
								short num10 = num8;
								if (num9 > num10)
								{
									break;
								}
								array[(int)num4] = CAD.GetPointXY(array[0], (double)(num * (int)num4), 0.0);
								Class36.smethod_16(array[(int)num4], 50.0, "墙柱纵筋");
								array2[(int)(num4 - 1)] = array[(int)num4];
								unchecked
								{
									num4 += 1;
								}
							}
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num6 - 1));
							short num11 = num5;
							short num12 = unchecked(num5 + num6) - 1;
							num4 = num11;
							for (;;)
							{
								short num13 = num4;
								short num10 = num12;
								if (num13 > num10)
								{
									break;
								}
								array[(int)num4] = CAD.GetPointXY(array[0], (double)(num * (int)(unchecked(num4 - num5))), -150.0);
								Class36.smethod_16(array[(int)num4], 50.0, "墙柱纵筋");
								unchecked
								{
									num4 += 1;
								}
							}
							Class36.smethod_83(array, 500L, text, 1, 100.0);
						}
						else if (num == 2)
						{
							short num14 = (short)Strings.InStr(text, "/", CompareMethod.Binary);
							short num15 = (short)Math.Round(Conversion.Val(text.Substring((int)(num14 - 9), 1)));
							short num16 = (short)Math.Round(Conversion.Val(text.Substring((int)num14, 1)));
							short num17 = (short)Math.Round(Conversion.Val(text.Substring((int)(num14 + 9), 1)));
							array = new Point3d[(int)(unchecked(num15 + num16 + num17) - 1 + 1)];
							array2 = new Point3d[(int)(num15 - 3 + 1)];
							array[0] = point3d2;
							Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
							array[(int)(unchecked(num15 + num16 + num17) - 1)] = pointAngle;
							Class36.smethod_16(array[(int)(unchecked(num15 + num16 + num17) - 1)], 50.0, "墙柱纵筋");
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num15 - 2 + 1));
							short num18 = 1;
							short num19 = num15 - 2;
							num14 = num18;
							for (;;)
							{
								short num20 = num14;
								short num10 = num19;
								if (num20 > num10)
								{
									break;
								}
								array[(int)num14] = CAD.GetPointXY(array[0], (double)(num * (int)num14), 0.0);
								Class36.smethod_16(array[(int)num14], 50.0, "墙柱纵筋");
								array2[(int)(num14 - 1)] = array[(int)num14];
								unchecked
								{
									num14 += 1;
								}
							}
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num16 - 1));
							short num21 = num15;
							short num22 = unchecked(num15 + num16) - 1;
							num14 = num21;
							for (;;)
							{
								short num23 = num14;
								short num10 = num22;
								if (num23 > num10)
								{
									break;
								}
								array[(int)num14] = CAD.GetPointXY(array[0], (double)(num * (int)(unchecked(num14 - num15))), -150.0);
								Class36.smethod_16(array[(int)num14], 50.0, "墙柱纵筋");
								unchecked
								{
									num14 += 1;
								}
							}
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num17 - 1));
							short num24 = unchecked(num15 + num16);
							short num25 = unchecked(num15 + num16 + num17) - 1;
							num14 = num24;
							for (;;)
							{
								short num26 = num14;
								short num10 = num25;
								if (num26 > num10)
								{
									break;
								}
								array[(int)num14] = CAD.GetPointXY(array[0], (double)(num * (int)(unchecked(num14 - num15 - num16))), -300.0);
								Class36.smethod_16(array[(int)num14], 50.0, "墙柱纵筋");
								unchecked
								{
									num14 += 1;
								}
							}
							Class36.smethod_83(array, 500L, text, 1, 100.0);
						}
						else
						{
							short num27 = (short)Strings.InStr(text, "+", CompareMethod.Binary);
							short num28;
							if (num27 > 0)
							{
								num28 = (short)Math.Round(unchecked(Conversion.Val(text.Substring((int)(checked(num27 - 9)), 1)) + Conversion.Val(text.Substring((int)num27, 1))));
							}
							else
							{
								num28 = (short)Math.Round(Conversion.Val(text.Substring(0, 1)));
							}
							array = new Point3d[(int)(num28 - 1 + 1)];
							array2 = new Point3d[(int)(num28 - 3 + 1)];
							array[0] = point3d2;
							Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
							array[(int)(num28 - 1)] = pointAngle;
							Class36.smethod_16(array[(int)(num28 - 1)], 50.0, "墙柱纵筋");
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num28 - 2 + 1));
							short num29 = 1;
							short num30 = num28 - 2;
							num27 = num29;
							for (;;)
							{
								short num31 = num27;
								short num10 = num30;
								if (num31 > num10)
								{
									break;
								}
								array[(int)num27] = CAD.GetPointXY(array[0], (double)(num * (int)num27), 0.0);
								Class36.smethod_16(array[(int)num27], 50.0, "墙柱纵筋");
								array2[(int)(num27 - 1)] = array[(int)num27];
								unchecked
								{
									num27 += 1;
								}
							}
							Class36.smethod_83(array, 500L, text, 1, 100.0);
						}
						text = JG.ReplaceGJ(ljm_Frm.TextBox3.Text);
						num = NF.InStr_N(text, "/");
						if (num == 1)
						{
							short num32 = (short)Strings.InStr(text, "/", CompareMethod.Binary);
							short num33 = (short)Math.Round(Conversion.Val(text.Substring((int)(num32 - 9), 1)));
							short num34 = (short)Math.Round(Conversion.Val(text.Substring((int)num32, 1)));
							array = new Point3d[(int)(unchecked(num34 + num33) - 1 + 1)];
							array[0] = pointAngle2;
							Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
							array[(int)(unchecked(num34 + num33) - 1)] = pointAngle3;
							Class36.smethod_16(array[(int)(unchecked(num34 + num33) - 1)], 50.0, "墙柱纵筋");
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num34 - 2 + 1));
							short num35 = 1;
							short num36 = num34 - 2;
							num32 = num35;
							for (;;)
							{
								short num37 = num32;
								short num10 = num36;
								if (num37 > num10)
								{
									break;
								}
								array[(int)num32] = CAD.GetPointXY(array[0], (double)(num * (int)num32), 0.0);
								Class36.smethod_16(array[(int)num32], 50.0, "墙柱纵筋");
								unchecked
								{
									num32 += 1;
								}
							}
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num33 - 1));
							short num38 = num34;
							short num39 = unchecked(num34 + num33) - 1;
							num32 = num38;
							for (;;)
							{
								short num40 = num32;
								short num10 = num39;
								if (num40 > num10)
								{
									break;
								}
								array[(int)num32] = CAD.GetPointXY(array[0], (double)(num * (int)(unchecked(num32 - num34))), 150.0);
								Class36.smethod_16(array[(int)num32], 50.0, "墙柱纵筋");
								unchecked
								{
									num32 += 1;
								}
							}
							Class36.smethod_83(array, 500L, text, 4, 100.0);
						}
						else if (num == 2)
						{
							short num41 = (short)Strings.InStr(text, "/", CompareMethod.Binary);
							short num42 = (short)Math.Round(Conversion.Val(text.Substring((int)(num41 - 9), 1)));
							short num43 = (short)Math.Round(Conversion.Val(text.Substring((int)num41, 1)));
							short num44 = (short)Math.Round(Conversion.Val(text.Substring((int)(num41 + 9), 1)));
							array = new Point3d[(int)(unchecked(num44 + num43 + num42) - 1 + 1)];
							array[0] = pointAngle2;
							Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
							array[(int)(unchecked(num44 + num43 + num42) - 1)] = pointAngle3;
							Class36.smethod_16(array[(int)(unchecked(num44 + num43 + num42) - 1)], 50.0, "墙柱纵筋");
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num44 - 2 + 1));
							short num45 = 1;
							short num46 = num44 - 2;
							num41 = num45;
							for (;;)
							{
								short num47 = num41;
								short num10 = num46;
								if (num47 > num10)
								{
									break;
								}
								array[(int)num41] = CAD.GetPointXY(array[0], (double)(num * (int)num41), 0.0);
								Class36.smethod_16(array[(int)num41], 50.0, "墙柱纵筋");
								unchecked
								{
									num41 += 1;
								}
							}
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num43 - 1));
							short num48 = num44;
							short num49 = unchecked(num44 + num43) - 1;
							num41 = num48;
							for (;;)
							{
								short num50 = num41;
								short num10 = num49;
								if (num50 > num10)
								{
									break;
								}
								array[(int)num41] = CAD.GetPointXY(array[0], (double)(num * (int)(unchecked(num41 - num44))), 150.0);
								Class36.smethod_16(array[(int)num41], 50.0, "墙柱纵筋");
								unchecked
								{
									num41 += 1;
								}
							}
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num42 - 1));
							short num51 = unchecked(num44 + num43);
							short num52 = unchecked(num44 + num43 + num42) - 1;
							num41 = num51;
							for (;;)
							{
								short num53 = num41;
								short num10 = num52;
								if (num53 > num10)
								{
									break;
								}
								array[(int)num41] = CAD.GetPointXY(array[0], (double)(num * (int)(unchecked(num41 - num44 - num43))), 300.0);
								Class36.smethod_16(array[(int)num41], 50.0, "墙柱纵筋");
								unchecked
								{
									num41 += 1;
								}
							}
							Class36.smethod_83(array, 500L, text, 4, 100.0);
						}
						else
						{
							short num54 = (short)Strings.InStr(text, "+", CompareMethod.Binary);
							short num55;
							if (num54 > 0)
							{
								num55 = (short)Math.Round(unchecked(Conversion.Val(text.Substring((int)(checked(num54 - 9)), 1)) + Conversion.Val(text.Substring((int)num54, 1))));
							}
							else
							{
								num55 = (short)Math.Round(Conversion.Val(text.Substring(0, 1)));
							}
							array = new Point3d[(int)(num55 - 1 + 1)];
							array[0] = pointAngle2;
							Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
							array[(int)(num55 - 1)] = pointAngle3;
							Class36.smethod_16(array[(int)(num55 - 1)], 50.0, "墙柱纵筋");
							num = (int)Math.Round((double)(num2 - 354L) / (double)(num55 - 2 + 1));
							short num56 = 1;
							short num57 = num55 - 2;
							num54 = num56;
							for (;;)
							{
								short num58 = num54;
								short num10 = num57;
								if (num58 > num10)
								{
									break;
								}
								array[(int)num54] = CAD.GetPointXY(array[0], (double)(num * (int)num54), 0.0);
								Class36.smethod_16(array[(int)num54], 50.0, "墙柱纵筋");
								unchecked
								{
									num54 += 1;
								}
							}
							Class36.smethod_83(array, 500L, text, 4, 100.0);
						}
						object obj = CAD.CreateTextStyle("Tc_尺寸标注", "txt.shx", "hztxt.Shx", 0.7);
						string dimStyleName = "Tc_Dim100";
						object obj2 = obj;
						ObjectId objectId;
						ObjectId dimID = CAD.CreateDimStyle(dimStyleName, (obj2 != null) ? ((ObjectId)obj2) : objectId, 100, 1.0, false, -1.0);
						unchecked
						{
							pointXY5 = CAD.GetPointXY(point, (double)(checked(0L - num2)) / 2.0 - 500.0, 0.0);
							CAD.AddLineDim(pointXY2, pointXY3, pointXY5, 0.2, dimID, -1.0);
							pointXY5 = CAD.GetPointXY(point, 0.0, (double)(checked(0L - num3)) / 2.0 - 1000.0);
							CAD.AddLineDim(pointXY3, pointXY4, pointXY5, 0.2, dimID, -1.0);
							string string_;
							if (Conversions.ToDouble(ljm_Frm.TextBox7.Text) == 0.0)
							{
								string_ = "%%p0.000";
							}
							else
							{
								string_ = ljm_Frm.TextBox7.Text;
							}
							if (Operators.CompareString(ljm_Frm.Button1.Text, "顶部标高", false) == 0)
							{
								pointXY5 = CAD.GetPointXY(point, (double)(checked(0L - num2)) / 2.0 - 650.0, (double)num3 / 2.0);
								Class36.smethod_81(pointXY5, 2, 1.0);
								pointXY5 = CAD.GetPointXY(pointXY5, -300.0, 350.0);
								Class36.smethod_57(string_, pointXY5, 300.0, 2, 0, "STANDARD", 0.0);
							}
							else
							{
								pointXY5 = CAD.GetPointXY(point, (double)(checked(0L - num2)) / 2.0 - 650.0, (double)(checked(0L - num3)) / 2.0);
								Class36.smethod_81(pointXY5, 3, 1.0);
								pointXY5 = CAD.GetPointXY(pointXY5, -300.0, -350.0);
								Class36.smethod_57(string_, pointXY5, 300.0, 2, 3, "STANDARD", 0.0);
							}
						}
						if (Operators.CompareString(ljm_Frm.TextBox5.Text, "", false) != 0)
						{
							text = JG.ReplaceGJ(ljm_Frm.TextBox5.Text);
							num = (int)Math.Round(Conversion.Val(text.Substring(0, 1)));
							if (num % 2 == 0)
							{
								num = (int)Math.Round((double)num / 2.0);
								text = Conversions.ToString(2) + text.Substring(1, text.Length - 1);
								short num59 = 0;
								short num60 = (short)(num - 1);
								short num61 = num59;
								unchecked
								{
									for (;;)
									{
										short num62 = num61;
										short num10 = num60;
										if (num62 > num10)
										{
											break;
										}
										array = new Point3d[3];
										array[0] = CAD.GetPointXY(pointAngle2, 0.0, checked((double)(num3 - 354L) / (double)(num + 1)) * (double)(checked(num61 + 1)));
										Class36.smethod_16(array[0], 50.0, "墙柱纵筋");
										array[2] = CAD.GetPointXY(pointAngle3, 0.0, checked((double)(num3 - 354L) / (double)(num + 1)) * (double)(checked(num61 + 1)));
										Class36.smethod_16(array[2], 50.0, "墙柱纵筋");
										Class36.smethod_7(array[0], array[2]);
										array[1] = Class36.smethod_46(array[0], array[2]);
										array[1] = CAD.GetPointXY(array[1], 0.0, 74.0);
										Class36.smethod_83(array, 300L, text, 1, 100.0);
										num61 += 1;
									}
								}
							}
						}
						else
						{
							num = 2;
						}
						pointAngle = CAD.GetPointAngle(pointXY2, 100.0, -45.0);
						point3d2 = CAD.GetPointAngle(pointXY4, 100.0, 135.0);
						Class36.smethod_9(pointAngle, point3d2);
						array = new Point3d[]
						{
							CAD.GetPointXY(point3d2, 0.0, (double)(num3 - 354L) / unchecked((double)num / 2.0 + 1.0) / 2.0)
						};
						text = JG.ReplaceGJ(ljm_Frm.TextBox4.Text);
						Class36.smethod_83(array, 0L, text, 1, 100.0);
						num = Strings.InStr(text, "(", CompareMethod.Binary);
						if (num != 0)
						{
							short num63 = Conversions.ToShort(text.Substring(num, 1));
							if (num63 == 3)
							{
								Class36.smethod_7(array2[0], CAD.GetPointXY(array2[0], 0.0, (double)(0L - num3 + 354L)));
							}
							else if (num63 == 4)
							{
								pointAngle = CAD.GetPointAngle(array2[0], 150.0, 135.0);
								point3d2 = CAD.GetPointXY(array2[0], unchecked(array2[1].X - array2[0].X), (double)(0L - num3 + 354L));
								point3d2 = CAD.GetPointAngle(point3d2, 150.0, -45.0);
								Class36.smethod_9(pointAngle, point3d2);
							}
						}
						pointXY5 = CAD.GetPointXY(point, -400.0, unchecked((double)(checked(0L - num3)) / 2.0 - 2500.0));
						Class36.smethod_6(pointXY5, "L1", 100.0, "1:20");
					}
				}
			}
		}

		[CommandMethod("TcZJM")]
		public void TcZJM()
		{
			TcZJM_Frm tcZJM_Frm = new TcZJM_Frm();
			tcZJM_Frm.ShowDialog();
			checked
			{
				if (tcZJM_Frm.DialogResult == DialogResult.OK)
				{
					CAD.CreateLayer("柱截面", 2, "continuous", -1, false, true);
					CAD.CreateLayer("柱截面文字", 4, "continuous", -1, false, true);
					string text = tcZJM_Frm.ComboBox1.Text;
					double num;
					if (Operators.CompareString(text, "1:20", false) == 0)
					{
						num = 5.0;
					}
					else if (Operators.CompareString(text, "1:25", false) == 0)
					{
						num = 4.0;
					}
					else if (Operators.CompareString(text, "1:30", false) == 0)
					{
						num = 3.3333333333333335;
					}
					else if (Operators.CompareString(text, "1:40", false) == 0)
					{
						num = 2.5;
					}
					else if (Operators.CompareString(text, "1:50", false) == 0)
					{
						num = 2.0;
					}
					if (tcZJM_Frm.RadioButton1.Checked)
					{
						string text2 = tcZJM_Frm.TextBox1.Text;
						string text3 = tcZJM_Frm.TextBox2.Text.ToUpper();
						string text4 = tcZJM_Frm.TextBox3.Text;
						string text5 = tcZJM_Frm.TextBox4.Text;
						string text6 = tcZJM_Frm.TextBox5.Text;
						string text7 = tcZJM_Frm.TextBox6.Text;
						object instance = text3.Split(new char[]
						{
							'X'
						});
						long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(instance, new object[]
						{
							0
						}, null));
						long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(instance, new object[]
						{
							1
						}, null));
						long num4 = (long)Math.Round(unchecked((double)num2 * num));
						long num5 = (long)Math.Round(unchecked((double)num3 * num));
						Point3d point = CAD.GetPoint("选择插入点: ");
						Point3d point3d;
						if (!(point == point3d))
						{
							Point3d pointXY = CAD.GetPointXY(point, (double)num4 / 2.0, (double)num5 / 2.0);
							Point3d pointXY2 = CAD.GetPointXY(point, (double)(0L - num4) / 2.0, (double)num5 / 2.0);
							Point3d pointXY3 = CAD.GetPointXY(point, (double)(0L - num4) / 2.0, (double)(0L - num5) / 2.0);
							Point3d pointXY4 = CAD.GetPointXY(point, (double)num4 / 2.0, (double)(0L - num5) / 2.0);
							ObjectId id = CAD.AddPlinePxy(pointXY3, (double)num4, (double)num5, 0.0, "").ObjectId;
							CAD.ChangeLayer(id, "柱截面");
							double num6 = 185.0;
							Point3d pointXY5 = CAD.GetPointXY(pointXY, (double)-185f, (double)-185f);
							Point3d pointXY6 = CAD.GetPointXY(pointXY2, num6, (double)-185f);
							Point3d pointXY7 = CAD.GetPointXY(pointXY3, num6, num6);
							Point3d pointXY8 = CAD.GetPointXY(pointXY4, (double)-185f, num6);
							num6 = 50.0;
							Class36.smethod_16(pointXY5, num6, "墙柱纵筋");
							Class36.smethod_16(pointXY6, num6, "墙柱纵筋");
							Class36.smethod_16(pointXY7, num6, "墙柱纵筋");
							Class36.smethod_16(pointXY8, num6, "墙柱纵筋");
							Class36.smethod_10(pointXY7, pointXY5, 5.0);
							Point3d[] array = null;
							Point3d[] array2 = null;
							short num8;
							if (Operators.CompareString(text6, "", false) != 0 & Operators.CompareString(text6, "0", false) != 0)
							{
								short num7 = (short)Strings.InStr(text6, "+", CompareMethod.Binary);
								if (num7 > 0)
								{
									num8 = (short)Math.Round(unchecked(Conversion.Val(text6.Substring(0, 1)) + Conversion.Val(text6.Substring((int)num7, 1))));
								}
								else
								{
									num8 = (short)Math.Round(Conversion.Val(text6.Substring(0, 1)));
								}
								array = new Point3d[(int)(num8 - 1 + 1)];
								array2 = new Point3d[(int)(num8 - 1 + 1)];
								long num9 = (long)Math.Round((double)(num4 - 370L) / (double)(num8 + 1));
								int num10 = 0;
								int num11 = (int)(num8 - 1);
								int num12 = num10;
								for (;;)
								{
									int num13 = num12;
									int num14 = num11;
									if (num13 > num14)
									{
										break;
									}
									array[num12] = CAD.GetPointXY(pointXY6, (double)(num9 * unchecked((long)(checked(num12 + 1)))), 0.0);
									Class36.smethod_16(array[num12], 50.0, "墙柱纵筋");
									array2[num12] = CAD.GetPointXY(pointXY7, (double)(num9 * unchecked((long)(checked(num12 + 1)))), 0.0);
									Class36.smethod_16(array2[num12], 50.0, "墙柱纵筋");
									num12++;
								}
							}
							Point3d[] array3 = null;
							Point3d[] array4 = null;
							int num16;
							if (Operators.CompareString(text7, "", false) != 0 & Operators.CompareString(text7, "0", false) != 0)
							{
								short num15 = (short)Strings.InStr(text7, "+", CompareMethod.Binary);
								if (num15 > 0)
								{
									num16 = (int)Math.Round(unchecked(Conversion.Val(text7.Substring(0, 1)) + Conversion.Val(text7.Substring((int)num15, 1))));
								}
								else
								{
									num16 = (int)Math.Round(Conversion.Val(text7.Substring(0, 1)));
								}
								array3 = new Point3d[num16 - 1 + 1];
								array4 = new Point3d[num16 - 1 + 1];
								long num17 = (long)Math.Round((double)(num5 - 370L) / (double)(num16 + 1));
								int num18 = 0;
								int num19 = num16 - 1;
								int num20 = num18;
								for (;;)
								{
									int num21 = num20;
									int num14 = num19;
									if (num21 > num14)
									{
										break;
									}
									array3[num20] = CAD.GetPointXY(pointXY6, 0.0, (double)((0L - num17) * unchecked((long)(checked(num20 + 1)))));
									Class36.smethod_16(array3[num20], 50.0, "墙柱纵筋");
									array4[num20] = CAD.GetPointXY(pointXY5, 0.0, (double)((0L - num17) * unchecked((long)(checked(num20 + 1)))));
									Class36.smethod_16(array4[num20], 50.0, "墙柱纵筋");
									num20++;
								}
							}
							string[] array_ = new string[]
							{
								text2,
								text3,
								text4.Replace("D", "%%132"),
								text5.Replace("D", "%%132")
							};
							Point3d pointXY9 = CAD.GetPointXY(pointXY, -100.0, 2000.0);
							ObjectId[] array5 = Class36.smethod_20(pointXY9, array_, 300.0, 1.4, "");
							foreach (ObjectId id in array5)
							{
								CAD.ChangeLayer(id, "柱截面文字");
							}
							id = CAD.AddLine(CAD.GetPointXY(pointXY, -200.0, 0.0), CAD.GetPointXY(pointXY, -200.0, 1900.0), "0").ObjectId;
							CAD.ChangeLayer(id, "柱截面文字");
							unchecked
							{
								if (Operators.CompareString(text6, "", false) != 0 & Operators.CompareString(text6, "0", false) != 0)
								{
									pointXY9..ctor((pointXY.X + pointXY2.X) / 2.0, pointXY.Y + 150.0, 0.0);
									id = Class36.smethod_57(text6.Replace("D", "%%132"), pointXY9, 300.0, 1, 0, "STANDARD", 0.0);
									CAD.ChangeLayer(id, "柱截面文字");
								}
								if (Operators.CompareString(text7, "", false) != 0 & Operators.CompareString(text7, "0", false) != 0)
								{
									pointXY9..ctor(pointXY2.X - 150.0, (pointXY2.Y + pointXY3.Y) / 2.0, 0.0);
									id = Class36.smethod_57(text7.Replace("D", "%%132"), pointXY9, 300.0, 1, 0, "STANDARD", 1.5707963267948966);
									CAD.ChangeLayer(id, "柱截面文字");
								}
								object obj = CAD.CreateTextStyle("Tc_尺寸标注", "txt.shx", "hztxt.Shx", 0.7);
								string dimStyleName = "Tc_Dim100";
								object obj2 = obj;
								ObjectId objectId;
								ObjectId dimID = CAD.CreateDimStyle(dimStyleName, (obj2 != null) ? ((ObjectId)obj2) : objectId, 100, 1.0, false, -1.0);
								pointXY9 = CAD.GetPointXY(pointXY, 600.0, 0.0);
								CAD.AddLineDim(pointXY, pointXY4, pointXY9, 1.0 / num, dimID, -1.0);
								pointXY9 = CAD.GetPointXY(pointXY3, 0.0, -600.0);
								CAD.AddLineDim(pointXY3, pointXY4, pointXY9, 1.0 / num, dimID, -1.0);
								if (num2 > 300L)
								{
									if (num8 == 1)
									{
										Class36.smethod_8(array[0], array2[0], 5.0);
									}
									else if (num8 == 2)
									{
										Class36.smethod_10(array[0], array2[1], 5.0);
									}
									else if (num8 == 3)
									{
										Class36.smethod_10(array[0], array2[2], 5.0);
										Class36.smethod_8(array[1], array2[1], 5.0);
									}
									else if (num8 == 4)
									{
										Class36.smethod_10(array[0], array2[1], 5.0);
										Class36.smethod_10(array[2], array2[3], 5.0);
									}
									else if (num8 == 5)
									{
										Class36.smethod_10(array[1], array2[3], 5.0);
										Class36.smethod_8(array[2], array2[2], 5.0);
									}
									else if (num8 == 6)
									{
										Class36.smethod_10(array[1], array2[2], 5.0);
										Class36.smethod_10(array[3], array2[4], 5.0);
									}
									else if (num8 >= 7)
									{
										Class36.smethod_10(array[1], array2[2], 5.0);
										Class36.smethod_10(array[4], array2[5], 5.0);
									}
								}
								if (num3 > 300L)
								{
									if (num16 == 1)
									{
										Class36.smethod_8(array3[0], array4[0], 5.0);
									}
									else if (num16 == 2)
									{
										Class36.smethod_10(array3[0], array4[1], 5.0);
									}
									else if (num16 == 3)
									{
										Class36.smethod_10(array3[0], array4[2], 5.0);
										Class36.smethod_8(array3[1], array4[1], 5.0);
									}
									else if (num16 == 4)
									{
										Class36.smethod_10(array3[0], array4[1], 5.0);
										Class36.smethod_10(array3[2], array4[3], 5.0);
									}
									else if (num16 == 5)
									{
										Class36.smethod_10(array3[1], array4[3], 5.0);
										Class36.smethod_8(array3[2], array4[2], 5.0);
									}
									else if (num16 == 6)
									{
										Class36.smethod_10(array3[1], array4[2], 5.0);
										Class36.smethod_10(array3[3], array4[4], 5.0);
									}
									else if (num16 >= 7)
									{
										Class36.smethod_10(array3[1], array4[2], 5.0);
										Class36.smethod_10(array3[4], array4[5], 5.0);
									}
								}
								pointXY9 = CAD.GetPointXY(point, -400.0, (double)(checked(0L - num5)) / 2.0 - 2500.0);
								Class36.smethod_6(pointXY9, text2, 100.0, tcZJM_Frm.ComboBox1.Text);
							}
						}
					}
					else
					{
						string text8 = tcZJM_Frm.TextBox1.Text;
						string text9 = tcZJM_Frm.TextBox2.Text.ToUpper();
						string text10 = tcZJM_Frm.TextBox3.Text;
						string text11 = tcZJM_Frm.TextBox4.Text;
						long num22 = (long)Math.Round(Conversion.Val(text9));
						long num23 = (long)Math.Round((double)num22 / 2.0);
						object obj3 = Strings.InStr(text10, "D", CompareMethod.Binary);
						int num24 = (int)Math.Round(Conversion.Val(text10.Substring(0, Conversions.ToInteger(Operators.SubtractObject(obj3, 1)))));
						Point3d point2 = CAD.GetPoint("选择插入点: ");
						Point3d point3d;
						if (!(point2 == point3d))
						{
							ObjectId id2 = CAD.AddCircle(point2, unchecked((double)num23 * num), "").ObjectId;
							CAD.ChangeLayer(id2, "柱截面");
							CAD.CreateLayer("箍筋", 1, "continuous", -1, false, true);
							CAD.CreateLayer("柱截面文字", 4, "continuous", -1, false, true);
							long num25 = (long)Math.Round(unchecked((double)num23 * num - 85.0));
							Point3d point3d2 = CAD.GetPointXY(point2, 0.0, (double)num25);
							Polyline polyline = new Polyline();
							obj3 = Math.Tan(0.78539816339744828);
							polyline.AddVertexAt(0, Class36.smethod_38(point3d2), Conversions.ToDouble(obj3), (double)45f, (double)45f);
							point3d2 = CAD.GetPointXY(point3d2, 0.0, (double)(-2L * num25));
							polyline.AddVertexAt(1, Class36.smethod_38(point3d2), Conversions.ToDouble(obj3), (double)45f, (double)45f);
							point3d2 = CAD.GetPointXY(point3d2, 0.0, (double)(2L * num25));
							obj3 = Math.Tan(0.52359877559829882);
							polyline.AddVertexAt(2, Class36.smethod_38(point3d2), Conversions.ToDouble(obj3), (double)45f, (double)45f);
							point3d2 = CAD.GetPointAngle(point3d2, 185.0, 247.5);
							polyline.AddVertexAt(3, Class36.smethod_38(point3d2), 0.0, (double)45f, (double)45f);
							point3d2 = CAD.GetPointAngle(point3d2, 100.0, -45.0);
							polyline.AddVertexAt(4, Class36.smethod_38(point3d2), 0.0, (double)45f, (double)45f);
							id2 = CAD.AddEnt(polyline).ObjectId;
							CAD.ChangeLayer(id2, "箍筋");
							int num26 = 0;
							int num27 = num24 - 1;
							int num28 = num26;
							for (;;)
							{
								int num29 = num28;
								int num14 = num27;
								if (num29 > num14)
								{
									break;
								}
								point3d2 = unchecked(CAD.GetPointAngle(point2, (double)num23 * num - 185.0, 360.0 / (double)num24 * (double)num28 + 90.0));
								Class36.smethod_16(point3d2, 50.0, "墙柱纵筋");
								num28++;
							}
							ObjectId style = Class36.smethod_78("Dim100", 100, 1.0, false);
							unchecked
							{
								Point3d pointXY10 = CAD.GetPointXY(point2, (double)(checked(0L - num23)) * num, (double)(checked(0L - num23)) * num);
								Point3d pointXY11 = CAD.GetPointXY(point2, (double)num23 * num, (double)(checked(0L - num23)) * num);
								point3d2 = CAD.GetPointXY(point2, 0.0, (double)(checked(0L - num23 - 200L)) * num);
								id2 = ModelSpace.AddDimAligned1(pointXY10, pointXY11, point3d2, Conversions.ToString(num22), style);
								pointXY10 = CAD.GetPointXY(point2, (double)(checked(0L - num23)) * num, (double)num23 * num);
								pointXY11 = CAD.GetPointXY(point2, (double)(checked(0L - num23)) * num, (double)(checked(0L - num23)) * num);
								point3d2 = CAD.GetPointXY(point2, (double)(checked(0L - num23 - 200L)) * num, 0.0);
								id2 = ModelSpace.AddDimAligned1(pointXY10, pointXY11, point3d2, Conversions.ToString(num22), style);
								string[] array_2 = new string[]
								{
									text8,
									text9,
									text10.Replace("D", "%%132"),
									text11.Replace("D", "%%132")
								};
								point3d2 = CAD.GetPointXY(point2, (double)num23 * num + 100.0, 1800.0 + (double)num23 * num);
								ObjectId[] array7 = Class36.smethod_20(point3d2, array_2, 300.0, 1.4, "");
								foreach (ObjectId id2 in array7)
								{
									CAD.ChangeLayer(id2, "柱截面文字");
								}
								id2 = CAD.AddLine(CAD.GetPointXY(point2, (double)num23 * num * 0.714, (double)num23 * num * 0.714), CAD.GetPointXY(point2, ((double)num23 * num + 500.0) * 0.714, ((double)num23 * num + 500.0) * 0.714), "0").ObjectId;
								CAD.ChangeLayer(id2, "柱截面文字");
								point3d2 = CAD.GetPointXY(point2, -80.0 * num, (double)(checked(0L - num23 - 500L)) * num);
								Class36.smethod_6(point3d2, text8, 100.0, "1:20");
							}
						}
					}
				}
			}
		}
	}
}
