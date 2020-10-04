using System;
using System.ComponentModel;

internal class Class20
{
	static Class20()
	{
		Class20.bool_0 = false;
		Class20.double_0 = 1.0;
		Class20.double_1 = 1.0;
		Class20.double_2 = 1.0;
		Class20.double_3 = 1.0;
		Class20.double_4 = 1.0;
		Class20.double_5 = 1.0;
		Class20.double_6 = 1.0;
		Class20.double_7 = 1.0;
		Class20.double_8 = 1.0;
	}

	public Class20()
	{        
	}

	internal static void smethod_0()
	{
		Class20.double_1 = 1.0;
		double num = 0.5;
		double num2 = 1.0;
		bool flag = true;
		double num3 = 1.0;
		double num4;
		do
		{
			num4 = num2;
			num3 *= num;
			if (flag)
			{
				Class20.double_1 *= 2.0;
			}
			flag = !flag;
			num2 = 1.0 + num3;
			if (num2 == 1.0)
			{
				break;
			}
		}
		while (num2 != num4);
		Class20.double_1 += 1.0;
		Class20.double_0 = (3.0 + 8.0 * num3) * num3;
		Class20.double_2 = (3.0 + 16.0 * num3) * num3;
		Class20.double_3 = (2.0 + 12.0 * num3) * num3;
		Class20.double_4 = (9.0 + 64.0 * num3) * num3 * num3;
		Class20.double_5 = (10.0 + 96.0 * num3) * num3;
		Class20.double_6 = (7.0 + 56.0 * num3) * num3;
		Class20.double_7 = (3.0 + 28.0 * num3) * num3;
		Class20.double_8 = (26.0 + 288.0 * num3) * num3 * num3;
		Class20.bool_0 = true;
	}

	internal static bool bool_0;

	internal static double double_0;

	internal static double double_1;

	internal static double double_2;

	internal static double double_3;

	internal static double double_4;

	internal static double double_5;

	internal static double double_6;

	internal static double double_7;

	internal static double double_8;
}
