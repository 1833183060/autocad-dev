using System;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class RandomGenerator
	{
		public RandomGenerator()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(RandomGenerator));
			//base..ctor();
		}

		public static double NextDouble(double lowerBound, double upperBound)
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			double num = upperBound - lowerBound;
			double num2 = RandomGenerator.NextDouble_0_1() * num;
			return lowerBound + num2;
		}

		public static double NextDouble_0_1()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return RandomGenerator.random_0.NextDouble();
		}

		public static double NextDouble_0_2Pi()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return 2.0 * RandomGenerator.random_0.NextDouble() * 3.1415926535897931;
		}

		public static double NextDouble_0_mr()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return RandomGenerator.random_0.NextDouble() * Global.MaxRandom;
		}

		public static double NextDouble_0_Pi()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return RandomGenerator.random_0.NextDouble() * 3.1415926535897931;
		}

		public static double NextDouble_1_1()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return 2.0 * (RandomGenerator.random_0.NextDouble() - 0.5);
		}

		public static double NextDouble_2Pi_2Pi()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return RandomGenerator.NextDouble_1_1() * 2.0 * 3.1415926535897931;
		}

		public static double NextDouble_mr_mr()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return 2.0 * (RandomGenerator.random_0.NextDouble() - 0.5) * Global.MaxRandom;
		}

		public static double NextDouble_Pi_Pi()
		{
			if (!RandomGenerator.bool_0)
			{
				RandomGenerator.smethod_0();
			}
			return RandomGenerator.NextDouble_1_1() * 3.1415926535897931;
		}

		private static void smethod_0()
		{
			RandomGenerator.random_0 = new Random(DateTime.Now.Millisecond ^ DateTime.Now.Second);
			RandomGenerator.bool_0 = true;
		}

		private static bool bool_0;

		private static Random random_0;
	}
}
