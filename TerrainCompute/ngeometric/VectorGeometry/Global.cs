using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ngeometry.VectorGeometry
{
	////[LicenseProvider(typeof(Class46))]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Global
	{
		static Global()
		{
			Global.absoluteEpsilon = 1E-09;
			Global.relativeEpsilon = 1E-09;
			Global.AbsoluteEpsilon = 1E-09;
			Global.RelativeEpsilon = 1E-09;
			Global.MaxRandom = 1.0;
			Global.StringNumberFormat = "0.0000";
		}

		public static bool AlmostEquals(double a, double b)
		{
			if (Math.Abs(a - b) <= Global.AbsoluteEpsilon)
			{
				return true;
			}
			if (Math.Abs(a) > Math.Abs(b))
			{
				double num = Math.Abs((a - b) / a);
				return num <= Global.RelativeEpsilon;
			}
			double num2 = Math.Abs((a - b) / b);
			return num2 <= Global.RelativeEpsilon;
		}

		public static bool AlmostEquals(double a, double b, double absoluteEpsilon, double relativeEpsilon)
		{
			if (Math.Abs(a - b) <= absoluteEpsilon)
			{
				return true;
			}
			if (Math.Abs(a) > Math.Abs(b))
			{
				double num = Math.Abs((a - b) / a);
				return num <= relativeEpsilon;
			}
			double num2 = Math.Abs((a - b) / b);
			return num2 <= relativeEpsilon;
		}

		public static void ResumeEpsilon()
		{
			Global.AbsoluteEpsilon = Global.absoluteEpsilon;
			Global.RelativeEpsilon = Global.relativeEpsilon;
		}

		public static void SuspendEpsilon(double superSetAbsoluteEpsilon, double superSetRelativeEpsilon)
		{
			Global.absoluteEpsilon = Global.AbsoluteEpsilon;
			Global.relativeEpsilon = Global.RelativeEpsilon;
			Global.AbsoluteEpsilon = superSetAbsoluteEpsilon;
			Global.RelativeEpsilon = superSetRelativeEpsilon;
		}

		private static double absoluteEpsilon;

		private static double relativeEpsilon;

		public static double AbsoluteEpsilon;

		public static double RelativeEpsilon;

		public static double MaxRandom;

		public static string StringNumberFormat;
	}
}
