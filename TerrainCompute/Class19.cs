using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class19
{
	public Class19()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class19));
		//base..ctor();
		Class20.smethod_0();
	}

	internal static double smethod_0(Point point_0, Point point_1, Point point_2, double double_0)
	{
		double[] array = new double[5];
		double[] array2 = new double[9];
		double[] array3 = new double[13];
		double[] array4 = new double[17];
		double[] array5 = new double[5];
		double num = point_0.X - point_2.X;
		double num2 = point_1.X - point_2.X;
		double num3 = point_0.Y - point_2.Y;
		double num4 = point_1.Y - point_2.Y;
		double num5 = num * num4;
		double num6 = Class20.double_1 * num;
		double num7 = num6 - num;
		double num8 = num6 - num7;
		double num9 = num - num8;
		num6 = Class20.double_1 * num4;
		num7 = num6 - num4;
		double num10 = num6 - num7;
		double num11 = num4 - num10;
		double num12 = num5 - num8 * num10;
		double num13 = num12 - num9 * num10;
		double num14 = num13 - num8 * num11;
		double num15 = num9 * num11 - num14;
		double num16 = num3 * num2;
		num6 = Class20.double_1 * num3;
		num7 = num6 - num3;
		num8 = num6 - num7;
		num9 = num3 - num8;
		num6 = Class20.double_1 * num2;
		num7 = num6 - num2;
		num10 = num6 - num7;
		num11 = num2 - num10;
		num12 = num16 - num8 * num10;
		num13 = num12 - num9 * num10;
		num14 = num13 - num8 * num11;
		double num17 = num9 * num11 - num14;
		double num18 = num15 - num17;
		double num19 = num15 - num18;
		double num20 = num18 + num19;
		double num21 = num19 - num17;
		double num22 = num15 - num20;
		array[0] = num22 + num21;
		double num23 = num5 + num18;
		num19 = num23 - num5;
		num20 = num23 - num19;
		num21 = num18 - num19;
		num22 = num5 - num20;
		double num24 = num22 + num21;
		num18 = num24 - num16;
		num19 = num24 - num18;
		num20 = num18 + num19;
		num21 = num19 - num16;
		num22 = num24 - num20;
		array[1] = num22 + num21;
		double num25 = num23 + num18;
		num19 = num25 - num23;
		num20 = num25 - num19;
		num21 = num18 - num19;
		num22 = num23 - num20;
		array[2] = num22 + num21;
		array[3] = num25;
		double num26 = Class19.smethod_1(4, array);
		double num27 = Class20.double_3 * double_0;
		if (num26 >= num27 || -num26 >= num27)
		{
			return num26;
		}
		num19 = point_0.X - num;
		num20 = num + num19;
		num21 = num19 - point_2.X;
		num22 = point_0.X - num20;
		double num28 = num22 + num21;
		num19 = point_1.X - num2;
		num20 = num2 + num19;
		num21 = num19 - point_2.X;
		num22 = point_1.X - num20;
		double num29 = num22 + num21;
		num19 = point_0.Y - num3;
		num20 = num3 + num19;
		num21 = num19 - point_2.Y;
		num22 = point_0.Y - num20;
		double num30 = num22 + num21;
		num19 = point_1.Y - num4;
		num20 = num4 + num19;
		num21 = num19 - point_2.Y;
		num22 = point_1.Y - num20;
		double num31 = num22 + num21;
		if (num28 == 0.0 && num30 == 0.0 && num29 == 0.0 && num31 == 0.0)
		{
			return num26;
		}
		num27 = Class20.double_4 * double_0 + Class20.double_0 * ((num26 >= 0.0) ? num26 : (-num26));
		num26 += num * num31 + num4 * num28 - (num3 * num29 + num2 * num30);
		if (num26 < num27 && -num26 < num27)
		{
			double num32 = num28 * num4;
			num6 = Class20.double_1 * num28;
			num7 = num6 - num28;
			num8 = num6 - num7;
			num9 = num28 - num8;
			num6 = Class20.double_1 * num4;
			num7 = num6 - num4;
			num10 = num6 - num7;
			num11 = num4 - num10;
			num12 = num32 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			double num33 = num9 * num11 - num14;
			double num34 = num30 * num2;
			num6 = Class20.double_1 * num30;
			num7 = num6 - num30;
			num8 = num6 - num7;
			num9 = num30 - num8;
			num6 = Class20.double_1 * num2;
			num7 = num6 - num2;
			num10 = num6 - num7;
			num11 = num2 - num10;
			num12 = num34 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			double num35 = num9 * num11 - num14;
			num18 = num33 - num35;
			num19 = num33 - num18;
			num20 = num18 + num19;
			num21 = num19 - num35;
			num22 = num33 - num20;
			array5[0] = num22 + num21;
			num23 = num32 + num18;
			num19 = num23 - num32;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num32 - num20;
			num24 = num22 + num21;
			num18 = num24 - num34;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num34;
			num22 = num24 - num20;
			array5[1] = num22 + num21;
			double num36 = num23 + num18;
			num19 = num36 - num23;
			num20 = num36 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array5[2] = num22 + num21;
			array5[3] = num36;
			int int_ = Class19.smethod_2(4, array, 4, array5, array2);
			num32 = num * num31;
			num6 = Class20.double_1 * num;
			num7 = num6 - num;
			num8 = num6 - num7;
			num9 = num - num8;
			num6 = Class20.double_1 * num31;
			num7 = num6 - num31;
			num10 = num6 - num7;
			num11 = num31 - num10;
			num12 = num32 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num33 = num9 * num11 - num14;
			num34 = num3 * num29;
			num6 = Class20.double_1 * num3;
			num7 = num6 - num3;
			num8 = num6 - num7;
			num9 = num3 - num8;
			num6 = Class20.double_1 * num29;
			num7 = num6 - num29;
			num10 = num6 - num7;
			num11 = num29 - num10;
			num12 = num34 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num35 = num9 * num11 - num14;
			num18 = num33 - num35;
			num19 = num33 - num18;
			num20 = num18 + num19;
			num21 = num19 - num35;
			num22 = num33 - num20;
			array5[0] = num22 + num21;
			num23 = num32 + num18;
			num19 = num23 - num32;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num32 - num20;
			num24 = num22 + num21;
			num18 = num24 - num34;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num34;
			num22 = num24 - num20;
			array5[1] = num22 + num21;
			num36 = num23 + num18;
			num19 = num36 - num23;
			num20 = num36 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array5[2] = num22 + num21;
			array5[3] = num36;
			int int_2 = Class19.smethod_2(int_, array2, 4, array5, array3);
			num32 = num28 * num31;
			num6 = Class20.double_1 * num28;
			num7 = num6 - num28;
			num8 = num6 - num7;
			num9 = num28 - num8;
			num6 = Class20.double_1 * num31;
			num7 = num6 - num31;
			num10 = num6 - num7;
			num11 = num31 - num10;
			num12 = num32 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num33 = num9 * num11 - num14;
			num34 = num30 * num29;
			num6 = Class20.double_1 * num30;
			num7 = num6 - num30;
			num8 = num6 - num7;
			num9 = num30 - num8;
			num6 = Class20.double_1 * num29;
			num7 = num6 - num29;
			num10 = num6 - num7;
			num11 = num29 - num10;
			num12 = num34 - num8 * num10;
			num13 = num12 - num9 * num10;
			num14 = num13 - num8 * num11;
			num35 = num9 * num11 - num14;
			num18 = num33 - num35;
			num19 = num33 - num18;
			num20 = num18 + num19;
			num21 = num19 - num35;
			num22 = num33 - num20;
			array5[0] = num22 + num21;
			num23 = num32 + num18;
			num19 = num23 - num32;
			num20 = num23 - num19;
			num21 = num18 - num19;
			num22 = num32 - num20;
			num24 = num22 + num21;
			num18 = num24 - num34;
			num19 = num24 - num18;
			num20 = num18 + num19;
			num21 = num19 - num34;
			num22 = num24 - num20;
			array5[1] = num22 + num21;
			num36 = num23 + num18;
			num19 = num36 - num23;
			num20 = num36 - num19;
			num21 = num18 - num19;
			num22 = num23 - num20;
			array5[2] = num22 + num21;
			array5[3] = num36;
			int num37 = Class19.smethod_2(int_2, array3, 4, array5, array4);
			return array4[num37 - 1];
		}
		return num26;
	}

	private static double smethod_1(int int_0, double[] double_0)
	{
		double num = double_0[0];
		for (int i = 1; i < int_0; i++)
		{
			num += double_0[i];
		}
		return num;
	}

	private static int smethod_2(int int_0, double[] double_0, int int_1, double[] double_1, double[] double_2)
	{
		int i = 0;
		int j = 0;
		int num = 0;
		double num2 = double_0[0];
		double num3 = double_1[0];
		double num4;
		if (num3 > num2 == num3 > -num2)
		{
			num4 = num2;
			num2 = double_0[++i];
		}
		else
		{
			num4 = num3;
			num3 = double_1[++j];
		}
		if (i < int_0 && j < int_1)
		{
			double num5;
			double num7;
			if (num3 > num2 == num3 > -num2)
			{
				num5 = num2 + num4;
				double num6 = num5 - num2;
				num7 = num4 - num6;
				num2 = double_0[++i];
			}
			else
			{
				num5 = num3 + num4;
				double num6 = num5 - num3;
				num7 = num4 - num6;
				num3 = double_1[++j];
			}
			num4 = num5;
			if (num7 != 0.0)
			{
				double_2[num++] = num7;
			}
			while (i < int_0 && j < int_1)
			{
				if (num3 > num2 == num3 > -num2)
				{
					num5 = num4 + num2;
					double num6 = num5 - num4;
					double num8 = num5 - num6;
					double num9 = num2 - num6;
					double num10 = num4 - num8;
					num7 = num10 + num9;
					num2 = double_0[++i];
				}
				else
				{
					num5 = num4 + num3;
					double num6 = num5 - num4;
					double num8 = num5 - num6;
					double num9 = num3 - num6;
					double num10 = num4 - num8;
					num7 = num10 + num9;
					num3 = double_1[++j];
				}
				num4 = num5;
				if (num7 != 0.0)
				{
					double_2[num++] = num7;
				}
			}
		}
		while (i < int_0)
		{
			double num5 = num4 + num2;
			double num6 = num5 - num4;
			double num8 = num5 - num6;
			double num9 = num2 - num6;
			double num10 = num4 - num8;
			double num7 = num10 + num9;
			num2 = double_0[++i];
			num4 = num5;
			if (num7 != 0.0)
			{
				double_2[num++] = num7;
			}
		}
		while (j < int_1)
		{
			double num5 = num4 + num3;
			double num6 = num5 - num4;
			double num8 = num5 - num6;
			double num9 = num3 - num6;
			double num10 = num4 - num8;
			double num7 = num10 + num9;
			num3 = double_1[++j];
			num4 = num5;
			if (num7 != 0.0)
			{
				double_2[num++] = num7;
			}
		}
		if (num4 != 0.0 || num == 0)
		{
			double_2[num++] = num4;
		}
		return num;
	}

	internal static double smethod_3(Point point_0, Point point_1, Point point_2, Point point_3)
	{
		double[] array = new double[5];
		double[] array2 = new double[5];
		double[] array3 = new double[5];
		double[] array4 = new double[5];
		double[] array5 = new double[5];
		double[] array6 = new double[5];
		double[] array7 = new double[9];
		double[] array8 = new double[13];
		double[] array9 = new double[13];
		double[] array10 = new double[13];
		double[] array11 = new double[13];
		double[] array12 = new double[25];
		double[] array13 = new double[25];
		double[] array14 = new double[25];
		double[] array15 = new double[25];
		double[] array16 = new double[49];
		double[] array17 = new double[49];
		double[] array18 = new double[97];
		double num = point_0.X * point_1.Y;
		double num2 = Class20.double_1 * point_0.X;
		double num3 = num2 - point_0.X;
		double num4 = num2 - num3;
		double num5 = point_0.X - num4;
		num2 = Class20.double_1 * point_1.Y;
		num3 = num2 - point_1.Y;
		double num6 = num2 - num3;
		double num7 = point_1.Y - num6;
		double num8 = num - num4 * num6;
		double num9 = num8 - num5 * num6;
		double num10 = num9 - num4 * num7;
		double num11 = num5 * num7 - num10;
		double num12 = point_1.X * point_0.Y;
		num2 = Class20.double_1 * point_1.X;
		num3 = num2 - point_1.X;
		num4 = num2 - num3;
		num5 = point_1.X - num4;
		num2 = Class20.double_1 * point_0.Y;
		num3 = num2 - point_0.Y;
		num6 = num2 - num3;
		num7 = point_0.Y - num6;
		num8 = num12 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num13 = num5 * num7 - num10;
		double num14 = num11 - num13;
		double num15 = num11 - num14;
		double num16 = num14 + num15;
		double num17 = num15 - num13;
		double num18 = num11 - num16;
		array[0] = num18 + num17;
		double num19 = num + num14;
		num15 = num19 - num;
		num16 = num19 - num15;
		num17 = num14 - num15;
		num18 = num - num16;
		double num20 = num18 + num17;
		num14 = num20 - num12;
		num15 = num20 - num14;
		num16 = num14 + num15;
		num17 = num15 - num12;
		num18 = num20 - num16;
		array[1] = num18 + num17;
		array[3] = num19 + num14;
		num15 = array[3] - num19;
		num16 = array[3] - num15;
		num17 = num14 - num15;
		num18 = num19 - num16;
		array[2] = num18 + num17;
		double num21 = point_1.X * point_2.Y;
		num2 = Class20.double_1 * point_1.X;
		num3 = num2 - point_1.X;
		num4 = num2 - num3;
		num5 = point_1.X - num4;
		num2 = Class20.double_1 * point_2.Y;
		num3 = num2 - point_2.Y;
		num6 = num2 - num3;
		num7 = point_2.Y - num6;
		num8 = num21 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num22 = num5 * num7 - num10;
		double num23 = point_2.X * point_1.Y;
		num2 = Class20.double_1 * point_2.X;
		num3 = num2 - point_2.X;
		num4 = num2 - num3;
		num5 = point_2.X - num4;
		num2 = Class20.double_1 * point_1.Y;
		num3 = num2 - point_1.Y;
		num6 = num2 - num3;
		num7 = point_1.Y - num6;
		num8 = num23 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num24 = num5 * num7 - num10;
		num14 = num22 - num24;
		num15 = num22 - num14;
		num16 = num14 + num15;
		num17 = num15 - num24;
		num18 = num22 - num16;
		array2[0] = num18 + num17;
		num19 = num21 + num14;
		num15 = num19 - num21;
		num16 = num19 - num15;
		num17 = num14 - num15;
		num18 = num21 - num16;
		num20 = num18 + num17;
		num14 = num20 - num23;
		num15 = num20 - num14;
		num16 = num14 + num15;
		num17 = num15 - num23;
		num18 = num20 - num16;
		array2[1] = num18 + num17;
		array2[3] = num19 + num14;
		num15 = array2[3] - num19;
		num16 = array2[3] - num15;
		num17 = num14 - num15;
		num18 = num19 - num16;
		array2[2] = num18 + num17;
		double num25 = point_2.X * point_3.Y;
		num2 = Class20.double_1 * point_2.X;
		num3 = num2 - point_2.X;
		num4 = num2 - num3;
		num5 = point_2.X - num4;
		num2 = Class20.double_1 * point_3.Y;
		num3 = num2 - point_3.Y;
		num6 = num2 - num3;
		num7 = point_3.Y - num6;
		num8 = num25 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num26 = num5 * num7 - num10;
		double num27 = point_3.X * point_2.Y;
		num2 = Class20.double_1 * point_3.X;
		num3 = num2 - point_3.X;
		num4 = num2 - num3;
		num5 = point_3.X - num4;
		num2 = Class20.double_1 * point_2.Y;
		num3 = num2 - point_2.Y;
		num6 = num2 - num3;
		num7 = point_2.Y - num6;
		num8 = num27 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num28 = num5 * num7 - num10;
		num14 = num26 - num28;
		num15 = num26 - num14;
		num16 = num14 + num15;
		num17 = num15 - num28;
		num18 = num26 - num16;
		array3[0] = num18 + num17;
		num19 = num25 + num14;
		num15 = num19 - num25;
		num16 = num19 - num15;
		num17 = num14 - num15;
		num18 = num25 - num16;
		num20 = num18 + num17;
		num14 = num20 - num27;
		num15 = num20 - num14;
		num16 = num14 + num15;
		num17 = num15 - num27;
		num18 = num20 - num16;
		array3[1] = num18 + num17;
		array3[3] = num19 + num14;
		num15 = array3[3] - num19;
		num16 = array3[3] - num15;
		num17 = num14 - num15;
		num18 = num19 - num16;
		array3[2] = num18 + num17;
		double num29 = point_3.X * point_0.Y;
		num2 = Class20.double_1 * point_3.X;
		num3 = num2 - point_3.X;
		num4 = num2 - num3;
		num5 = point_3.X - num4;
		num2 = Class20.double_1 * point_0.Y;
		num3 = num2 - point_0.Y;
		num6 = num2 - num3;
		num7 = point_0.Y - num6;
		num8 = num29 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num30 = num5 * num7 - num10;
		double num31 = point_0.X * point_3.Y;
		num2 = Class20.double_1 * point_0.X;
		num3 = num2 - point_0.X;
		num4 = num2 - num3;
		num5 = point_0.X - num4;
		num2 = Class20.double_1 * point_3.Y;
		num3 = num2 - point_3.Y;
		num6 = num2 - num3;
		num7 = point_3.Y - num6;
		num8 = num31 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num32 = num5 * num7 - num10;
		num14 = num30 - num32;
		num15 = num30 - num14;
		num16 = num14 + num15;
		num17 = num15 - num32;
		num18 = num30 - num16;
		array4[0] = num18 + num17;
		num19 = num29 + num14;
		num15 = num19 - num29;
		num16 = num19 - num15;
		num17 = num14 - num15;
		num18 = num29 - num16;
		num20 = num18 + num17;
		num14 = num20 - num31;
		num15 = num20 - num14;
		num16 = num14 + num15;
		num17 = num15 - num31;
		num18 = num20 - num16;
		array4[1] = num18 + num17;
		array4[3] = num19 + num14;
		num15 = array4[3] - num19;
		num16 = array4[3] - num15;
		num17 = num14 - num15;
		num18 = num19 - num16;
		array4[2] = num18 + num17;
		double num33 = point_0.X * point_2.Y;
		num2 = Class20.double_1 * point_0.X;
		num3 = num2 - point_0.X;
		num4 = num2 - num3;
		num5 = point_0.X - num4;
		num2 = Class20.double_1 * point_2.Y;
		num3 = num2 - point_2.Y;
		num6 = num2 - num3;
		num7 = point_2.Y - num6;
		num8 = num33 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num34 = num5 * num7 - num10;
		double num35 = point_2.X * point_0.Y;
		num2 = Class20.double_1 * point_2.X;
		num3 = num2 - point_2.X;
		num4 = num2 - num3;
		num5 = point_2.X - num4;
		num2 = Class20.double_1 * point_0.Y;
		num3 = num2 - point_0.Y;
		num6 = num2 - num3;
		num7 = point_0.Y - num6;
		num8 = num35 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num36 = num5 * num7 - num10;
		num14 = num34 - num36;
		num15 = num34 - num14;
		num16 = num14 + num15;
		num17 = num15 - num36;
		num18 = num34 - num16;
		array5[0] = num18 + num17;
		num19 = num33 + num14;
		num15 = num19 - num33;
		num16 = num19 - num15;
		num17 = num14 - num15;
		num18 = num33 - num16;
		num20 = num18 + num17;
		num14 = num20 - num35;
		num15 = num20 - num14;
		num16 = num14 + num15;
		num17 = num15 - num35;
		num18 = num20 - num16;
		array5[1] = num18 + num17;
		array5[3] = num19 + num14;
		num15 = array5[3] - num19;
		num16 = array5[3] - num15;
		num17 = num14 - num15;
		num18 = num19 - num16;
		array5[2] = num18 + num17;
		double num37 = point_1.X * point_3.Y;
		num2 = Class20.double_1 * point_1.X;
		num3 = num2 - point_1.X;
		num4 = num2 - num3;
		num5 = point_1.X - num4;
		num2 = Class20.double_1 * point_3.Y;
		num3 = num2 - point_3.Y;
		num6 = num2 - num3;
		num7 = point_3.Y - num6;
		num8 = num37 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num38 = num5 * num7 - num10;
		double num39 = point_3.X * point_1.Y;
		num2 = Class20.double_1 * point_3.X;
		num3 = num2 - point_3.X;
		num4 = num2 - num3;
		num5 = point_3.X - num4;
		num2 = Class20.double_1 * point_1.Y;
		num3 = num2 - point_1.Y;
		num6 = num2 - num3;
		num7 = point_1.Y - num6;
		num8 = num39 - num4 * num6;
		num9 = num8 - num5 * num6;
		num10 = num9 - num4 * num7;
		double num40 = num5 * num7 - num10;
		num14 = num38 - num40;
		num15 = num38 - num14;
		num16 = num14 + num15;
		num17 = num15 - num40;
		num18 = num38 - num16;
		array6[0] = num18 + num17;
		num19 = num37 + num14;
		num15 = num19 - num37;
		num16 = num19 - num15;
		num17 = num14 - num15;
		num18 = num37 - num16;
		num20 = num18 + num17;
		num14 = num20 - num39;
		num15 = num20 - num14;
		num16 = num14 + num15;
		num17 = num15 - num39;
		num18 = num20 - num16;
		array6[1] = num18 + num17;
		array6[3] = num19 + num14;
		num15 = array6[3] - num19;
		num16 = array6[3] - num15;
		num17 = num14 - num15;
		num18 = num19 - num16;
		array6[2] = num18 + num17;
		int int_ = Class19.smethod_2(4, array3, 4, array4, array7);
		int int_2 = Class19.smethod_2(int_, array7, 4, array5, array10);
		int_ = Class19.smethod_2(4, array4, 4, array, array7);
		int int_3 = Class19.smethod_2(int_, array7, 4, array6, array11);
		for (int i = 0; i < 4; i++)
		{
			array6[i] = -array6[i];
			array5[i] = -array5[i];
		}
		int_ = Class19.smethod_2(4, array, 4, array2, array7);
		int int_4 = Class19.smethod_2(int_, array7, 4, array5, array8);
		int_ = Class19.smethod_2(4, array2, 4, array3, array7);
		int int_5 = Class19.smethod_2(int_, array7, 4, array6, array9);
		int int_6 = Class19.smethod_4(int_5, array9, point_0.Z, array12);
		int int_7 = Class19.smethod_4(int_2, array10, -point_1.Z, array13);
		int int_8 = Class19.smethod_4(int_3, array11, point_2.Z, array14);
		int int_9 = Class19.smethod_4(int_4, array8, -point_3.Z, array15);
		int int_10 = Class19.smethod_2(int_6, array12, int_7, array13, array16);
		int int_11 = Class19.smethod_2(int_8, array14, int_9, array15, array17);
		int num41 = Class19.smethod_2(int_10, array16, int_11, array17, array18);
		return array18[num41 - 1];
	}

	private static int smethod_4(int int_0, double[] double_0, double double_1, double[] double_2)
	{
		double num = Class20.double_1 * double_1;
		double num2 = num - double_1;
		double num3 = num - num2;
		double num4 = double_1 - num3;
		double num5 = double_0[0] * double_1;
		num = Class20.double_1 * double_0[0];
		num2 = num - double_0[0];
		double num6 = num - num2;
		double num7 = double_0[0] - num6;
		double num8 = num5 - num6 * num3;
		double num9 = num8 - num7 * num3;
		double num10 = num9 - num6 * num4;
		double num11 = num7 * num4 - num10;
		int num12 = 0;
		if (num11 != 0.0)
		{
			double_2[num12++] = num11;
		}
		for (int i = 1; i < int_0; i++)
		{
			double num13 = double_0[i];
			double num14 = num13 * double_1;
			num = Class20.double_1 * num13;
			num2 = num - num13;
			num6 = num - num2;
			num7 = num13 - num6;
			num8 = num14 - num6 * num3;
			num9 = num8 - num7 * num3;
			num10 = num9 - num6 * num4;
			double num15 = num7 * num4 - num10;
			double num16 = num5 + num15;
			double num17 = num16 - num5;
			double num18 = num16 - num17;
			double num19 = num15 - num17;
			double num20 = num5 - num18;
			num11 = num20 + num19;
			if (num11 != 0.0)
			{
				double_2[num12++] = num11;
			}
			num5 = num14 + num16;
			num17 = num5 - num14;
			num11 = num16 - num17;
			if (num11 != 0.0)
			{
				double_2[num12++] = num11;
			}
		}
		if (num5 != 0.0 || num12 == 0)
		{
			double_2[num12++] = num5;
		}
		return num12;
	}
}
