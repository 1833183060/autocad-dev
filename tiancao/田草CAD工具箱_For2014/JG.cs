using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class JG
	{
		[DebuggerNonUserCode]
		public JG()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		public static short AddDataToComboBox(ComboBox C, string Type, string DefaultValue)
		{
			if (Operators.CompareString(Type, "HNT", false) == 0)
			{
				short num = 15;
				do
				{
					C.Items.Add("C" + Conversions.ToString((int)num));
					num += 5;
				}
				while (num <= 80);
			}
			else if (Operators.CompareString(Type, "GJ", false) == 0)
			{
				C.Items.Add("HPB300");
				C.Items.Add("HRB335");
				C.Items.Add("HRB400");
				C.Items.Add("HRB500");
			}
			C.Text = DefaultValue;
			short result;
			return result;
		}

		public static long GetFy(string S)
		{
			long result;
			if (Operators.CompareString(S, "HPB300", false) == 0)
			{
				result = 270L;
			}
			else if (Operators.CompareString(S, "HRB335", false) == 0)
			{
				result = 300L;
			}
			else if (Operators.CompareString(S, "HRB400", false) == 0)
			{
				result = 360L;
			}
			else if (Operators.CompareString(S, "HRB500", false) == 0)
			{
				result = 435L;
			}
			return result;
		}

		public static string ReplaceGJ(string S)
		{
			S = S.Replace("A", "%%130");
			S = S.Replace("B", "%%131");
			S = S.Replace("C", "%%132");
			S = S.Replace("D", "%%133");
			return S;
		}

		public static double GetHNT_QiangDuFc(string S)
		{
			double result;
			if (Operators.CompareString(S, "C15", false) == 0)
			{
				result = 7.2;
			}
			else if (Operators.CompareString(S, "C20", false) == 0)
			{
				result = 9.6;
			}
			else if (Operators.CompareString(S, "C25", false) == 0)
			{
				result = 11.9;
			}
			else if (Operators.CompareString(S, "C30", false) == 0)
			{
				result = 14.3;
			}
			else if (Operators.CompareString(S, "C35", false) == 0)
			{
				result = 16.7;
			}
			else if (Operators.CompareString(S, "C40", false) == 0)
			{
				result = 19.1;
			}
			else if (Operators.CompareString(S, "C45", false) == 0)
			{
				result = 21.1;
			}
			else if (Operators.CompareString(S, "C50", false) == 0)
			{
				result = 23.1;
			}
			else if (Operators.CompareString(S, "C55", false) == 0)
			{
				result = 25.3;
			}
			else if (Operators.CompareString(S, "C60", false) == 0)
			{
				result = 27.5;
			}
			else if (Operators.CompareString(S, "C65", false) == 0)
			{
				result = 29.7;
			}
			else if (Operators.CompareString(S, "C70", false) == 0)
			{
				result = 31.8;
			}
			else if (Operators.CompareString(S, "C75", false) == 0)
			{
				result = 33.8;
			}
			else if (Operators.CompareString(S, "C80", false) == 0)
			{
				result = 35.9;
			}
			return result;
		}

		public static double GetHNT_QiangDuFt(string S)
		{
			double result;
			if (Operators.CompareString(S, "C15", false) == 0)
			{
				result = 0.91;
			}
			else if (Operators.CompareString(S, "C20", false) == 0)
			{
				result = 1.1;
			}
			else if (Operators.CompareString(S, "C25", false) == 0)
			{
				result = 1.27;
			}
			else if (Operators.CompareString(S, "C30", false) == 0)
			{
				result = 1.43;
			}
			else if (Operators.CompareString(S, "C35", false) == 0)
			{
				result = 1.57;
			}
			else if (Operators.CompareString(S, "C40", false) == 0)
			{
				result = 1.71;
			}
			else if (Operators.CompareString(S, "C45", false) == 0)
			{
				result = 1.8;
			}
			else if (Operators.CompareString(S, "C50", false) == 0)
			{
				result = 1.89;
			}
			else if (Operators.CompareString(S, "C55", false) == 0)
			{
				result = 1.96;
			}
			else if (Operators.CompareString(S, "C60", false) == 0)
			{
				result = 2.04;
			}
			else if (Operators.CompareString(S, "C65", false) == 0)
			{
				result = 2.09;
			}
			else if (Operators.CompareString(S, "C70", false) == 0)
			{
				result = 2.14;
			}
			else if (Operators.CompareString(S, "C75", false) == 0)
			{
				result = 2.18;
			}
			else if (Operators.CompareString(S, "C80", false) == 0)
			{
				result = 2.22;
			}
			return result;
		}

		public static string GetAs_Function(string Txt)
		{
			Txt = Strings.Replace(Txt, "-", "@", 1, -1, CompareMethod.Binary);
			string expression = Txt.Substring(0, 1);
			if (!Versioned.IsNumeric(expression))
			{
				int num = Strings.InStr(Txt, " ", CompareMethod.Binary);
				if (num > 0)
				{
					Txt = Txt.Substring(num);
					Txt = Strings.Trim(Txt);
				}
			}
			checked
			{
				short num2 = (short)Strings.InStr(Txt, "@", CompareMethod.Binary);
				string result;
				if (num2 > 0)
				{
					result = JG.GetSteels2(Txt);
				}
				else
				{
					short num3 = (short)Strings.InStr(Txt, ";", CompareMethod.Binary);
					if (num3 > 0)
					{
						result = JG.Getsteels3(Txt).ToString();
					}
					else
					{
						string s = Txt;
						int num4 = 0;
						result = JG.GetSteels1(s, ref num4).ToString();
					}
				}
				return result;
			}
		}

		public static string GetSteels2(string S)
		{
			S = Strings.Replace(S, "%%130", "", 1, -1, CompareMethod.Binary);
			S = Strings.Replace(S, "%%131", "", 1, -1, CompareMethod.Binary);
			S = Strings.Replace(S, "%%132", "", 1, -1, CompareMethod.Binary);
			string result = "";
			int num = Strings.InStr(S, "@", CompareMethod.Binary);
			int num2 = Strings.InStr(S, "/", CompareMethod.Binary);
			int num3 = Strings.InStr(S, "(", CompareMethod.Binary);
			checked
			{
				if (num >= 0)
				{
					int num4 = (int)Math.Round(Conversion.Val(Strings.Left(S, num - 1)));
					if (num2 == 0)
					{
						int num5;
						int num6;
						if (num3 != 0)
						{
							num5 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num + 1, num3 - num - 1)));
							num6 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num3 + 1)));
						}
						else
						{
							num5 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num + 1)));
							num6 = 1;
						}
						result = Conversion.Str(Conversion.Int(unchecked(Math.Pow((double)num4, 2.0) * 3.14 / 4.0 * 1000.0 / (double)num5 * (double)num6)));
					}
					else
					{
						int num5 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num + 1, num2 - num - 1)));
						int num6;
						int num7;
						if (num3 != 0)
						{
							num6 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num2 + 1, num3 - num2 - 1)));
							num7 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num3 + 1)));
						}
						else
						{
							num6 = (int)Math.Round(Conversion.Val(Strings.Mid(S, num2 + 1, num2 + 1)));
							num7 = 1;
						}
						result = unchecked(Strings.Trim(Conversion.Str(Conversion.Int(Math.Pow((double)num4, 2.0) * 3.14 / 4.0 * 1000.0 / (double)num5 * (double)num7))) + "/" + Strings.Trim(Conversion.Str(Conversion.Int(Math.Pow((double)num4, 2.0) * 3.14 / 4.0 * 1000.0 / (double)num6 * (double)num7))));
					}
				}
				return result;
			}
		}

		public static long GetSteels1(string S, ref int N = 0)
		{
			long num = 0L;
			int num2 = Strings.InStr(S, " ", CompareMethod.Binary);
			checked
			{
				if (num2 > 0)
				{
					S = S.Substring(0, num2 - 1);
				}
				num2 = Strings.InStr(S, "(", CompareMethod.Binary);
				if (num2 > 0)
				{
					S = S.Substring(0, num2 - 2);
				}
				S = S.Replace("/", "+");
				int num3 = Strings.InStr(S, "+", CompareMethod.Binary);
				if (num3 == 0)
				{
					S = Strings.Replace(S, "G", "", 1, -1, CompareMethod.Binary);
					S = Strings.Replace(S, "N", "", 1, -1, CompareMethod.Binary);
					num2 = Strings.InStr(S, "%", CompareMethod.Binary);
					int num4 = (int)Math.Round(Conversion.Val(Strings.Left(S, num2 - 1)));
					num = (long)Math.Round(unchecked(Conversion.Int((double)num4 * Math.Pow(Conversion.Val(Strings.Mid(S, checked(num2 + 5), 2)), 2.0) * 3.14 / 4.0) + (double)num));
					if (N == 0)
					{
						N = num4;
					}
				}
				else
				{
					int num5;
					for (;;)
					{
						num2 = Strings.InStr(S, "%", CompareMethod.Binary);
						if (num2 == 0)
						{
							break;
						}
						int num4 = (int)Math.Round(Conversion.Val(Strings.Left(S, num2 - 1)));
						num = (long)Math.Round(unchecked(Conversion.Int((double)num4 * Math.Pow(Conversion.Val(Strings.Mid(S, checked(num2 + 5), 2)), 2.0) * 3.14 / 4.0) + (double)num));
						num5 += num4;
						S = Strings.Mid(S, num2 + 8);
					}
					if (N == 0)
					{
						N = num5;
					}
				}
				return num;
			}
		}

		public static string Getsteels3(string S)
		{
			checked
			{
				short num = (short)Strings.InStr(S, ";", CompareMethod.Binary);
				string result;
				if (num > 0)
				{
					string text = S.Substring(0, (int)(num - 1));
					string text2 = S.Substring((int)num);
					string s = text;
					int num2 = 0;
					text = Conversions.ToString(JG.GetSteels1(s, ref num2));
					string s2 = text2;
					num2 = 0;
					text2 = Conversions.ToString(JG.GetSteels1(s2, ref num2));
					result = text + " / " + text2;
				}
				else
				{
					int num2 = 0;
					result = Conversions.ToString(JG.GetSteels1(S, ref num2));
				}
				return result;
			}
		}

		public static string XuanJin(int MinD, int MaxD, long Area)
		{
			checked
			{
				long num = (long)Math.Round(unchecked(Math.Pow((double)MinD, 2.0) * 3.14) / 4.0);
				int num2 = (int)Math.Round(Conversion.Fix((double)Area / (double)num));
				int num3 = 100;
				string result = "";
				if (num2 < 2)
				{
					result = "2D" + Conversions.ToString(MinD);
				}
				else
				{
					for (int i = MinD; i <= MaxD; i++)
					{
						if (JG.isInArray(i))
						{
							int num4 = 0;
							int num5 = num2;
							int num6 = num4;
							for (;;)
							{
								int num7 = num6;
								int num8 = num5;
								if (num7 > num8)
								{
									break;
								}
								for (int j = MinD; j <= MaxD; j++)
								{
									int num9 = 0;
									int num10 = num2;
									int num11 = num9;
									for (;;)
									{
										int num12 = num11;
										num8 = num10;
										if (num12 > num8)
										{
											break;
										}
										if (JG.isInArray(j))
										{
											long num13 = (long)Math.Round(unchecked((double)num6 * Math.Pow((double)i, 2.0) * 3.14 / 4.0 + (double)num11 * Math.Pow((double)j, 2.0) * 3.14 / 4.0));
											int num14 = (int)Math.Round(unchecked((double)(checked(num13 - Area)) / (double)Area * 100.0));
											if (num14 < 5 & num14 > -5)
											{
												if (i == j)
												{
													result = string.Concat(new string[]
													{
														Conversions.ToString(num6 + num11),
														"D",
														Conversions.ToString(i),
														" / ",
														Conversions.ToString(num13),
														"(",
														Conversions.ToString(num14),
														"%)"
													});
												}
												else if (num6 == 0)
												{
													result = string.Concat(new string[]
													{
														Conversions.ToString(num11),
														"D",
														Conversions.ToString(j),
														" / ",
														Conversions.ToString(num13),
														"(",
														Conversions.ToString(num14),
														"%)"
													});
												}
												else if (num11 == 0)
												{
													result = string.Concat(new string[]
													{
														Conversions.ToString(num6),
														"D",
														Conversions.ToString(i),
														" / ",
														Conversions.ToString(num13),
														"(",
														Conversions.ToString(num14),
														"%)"
													});
												}
												else
												{
													result = string.Concat(new string[]
													{
														Conversions.ToString(num6),
														"D",
														Conversions.ToString(i),
														"+",
														Conversions.ToString(num11),
														"D",
														Conversions.ToString(j),
														" / ",
														Conversions.ToString(num13),
														"(",
														Conversions.ToString(num14),
														"%)"
													});
												}
											}
											if (num3 > Math.Abs(num14))
											{
												num3 = Math.Abs(num14);
												if (i == j)
												{
													result = Conversions.ToString(num6 + num11) + "D" + Conversions.ToString(i);
												}
												else
												{
													result = string.Concat(new string[]
													{
														Conversions.ToString(num6),
														"D",
														Conversions.ToString(i),
														"+",
														Conversions.ToString(num11),
														"D",
														Conversions.ToString(j)
													});
												}
											}
										}
										num11++;
									}
								}
								num6++;
							}
						}
					}
				}
				return result;
			}
		}

		public static string XuanJin2(int MinD, int MaxD, long Area, short Nmin)
		{
			checked
			{
				long num = (long)Math.Round(unchecked(Math.Pow((double)MinD, 2.0) * 3.14) / 4.0);
				int num2 = (int)Math.Round(Conversion.Fix((double)Area / (double)num));
				string text = "";
				if (num2 < 2)
				{
					text = "2D" + Conversions.ToString(MinD);
				}
				else
				{
					for (int i = MaxD; i >= MinD; i += -1)
					{
						if (JG.isInArray(i))
						{
							int num3 = num2;
							int num4 = (int)Nmin;
							for (;;)
							{
								int num5 = num4;
								int num6 = num3;
								if (num5 > num6)
								{
									break;
								}
								long num7 = (long)Math.Round(unchecked((double)num4 * Math.Pow((double)i, 2.0) * 3.14) / 4.0);
								int num8 = (int)Math.Round(unchecked((double)(checked(num7 - Area)) / (double)Area * 100.0));
								if (num8 < 10 & num8 > 0)
								{
									text = string.Concat(new string[]
									{
										text,
										Conversions.ToString(num4),
										"D",
										Conversions.ToString(i),
										"(",
										Conversions.ToString(num8),
										")/"
									});
								}
								num4++;
							}
						}
					}
				}
				return text;
			}
		}

		public static bool isInArray(int D)
		{
			bool result = false;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(6);
			arrayList.Add(8);
			arrayList.Add(10);
			arrayList.Add(12);
			arrayList.Add(14);
			arrayList.Add(16);
			arrayList.Add(18);
			arrayList.Add(20);
			arrayList.Add(22);
			arrayList.Add(25);
			arrayList.Add(28);
			arrayList.Add(32);
			arrayList.Add(36);
			arrayList.Add(40);
			int num = 0;
			checked
			{
				do
				{
					if (Operators.ConditionalCompareObjectEqual(arrayList[num], D, false))
					{
						result = true;
					}
					num++;
				}
				while (num <= 13);
				return result;
			}
		}
	}
}
