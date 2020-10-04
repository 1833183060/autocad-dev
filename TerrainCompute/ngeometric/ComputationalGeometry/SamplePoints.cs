using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class SamplePoints
	{
		public SamplePoints()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(SamplePoints));
			//base..ctor();
		}

		public static PointSet Cube(double length, double width, double height)
		{
			PointSet pointSet = new PointSet();
			double num = length / 2.0;
			double num2 = width / 2.0;
			double num3 = height / 2.0;
			pointSet.Add(new Point(-num, -num2, -num3));
			pointSet.Add(new Point(num, -num2, -num3));
			pointSet.Add(new Point(-num, num2, -num3));
			pointSet.Add(new Point(num, num2, -num3));
			pointSet.Add(new Point(-num, -num2, num3));
			pointSet.Add(new Point(num, -num2, num3));
			pointSet.Add(new Point(-num, num2, num3));
			pointSet.Add(new Point(num, num2, num3));
			return pointSet;
		}

		public static PointSet RandomInCircle(int numberOfVertices, double radius)
		{
			PointSet pointSet = new PointSet();
			Circle circle = new Circle(new Point(0.0, 0.0, 0.0), radius, new Vector3d(0.0, 0.0, 1.0));
			for (int i = 0; i < numberOfVertices; i++)
			{
				pointSet.Add(circle.RandomPointInCircle());
			}
			return pointSet;
		}

		public static PointSet RandomInCube(int numberOfVertices, double length, double width, double height)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < numberOfVertices; i++)
			{
				double x = length * RandomGenerator.NextDouble_1_1() / 2.0;
				double y = width * RandomGenerator.NextDouble_1_1() / 2.0;
				double z = height * RandomGenerator.NextDouble_1_1() / 2.0;
				pointSet.Add(new Point(x, y, z));
			}
			return pointSet;
		}

		public static PointSet RandomInRectangle(int numberOfVertices, double length, double width)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < numberOfVertices; i++)
			{
				double x = length * RandomGenerator.NextDouble_1_1() / 2.0;
				double y = width * RandomGenerator.NextDouble_1_1() / 2.0;
				pointSet.Add(new Point(x, y, 0.0));
			}
			return pointSet;
		}

		public static PointSet RandomInSphere(int numberOfVertices, double radius)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < numberOfVertices; i++)
			{
				double num = radius * RandomGenerator.NextDouble_0_1();
				double num2 = RandomGenerator.NextDouble_0_Pi();
				double num3 = RandomGenerator.NextDouble_0_2Pi();
				double x = num * Math.Sin(num2) * Math.Cos(num3);
				double y = num * Math.Sin(num2) * Math.Sin(num3);
				double z = num * Math.Cos(num2);
				pointSet.Add(new Point(x, y, z));
			}
			return pointSet;
		}

		public static PointSet RandomOnCircle(int numberOfVertices, double radius)
		{
			PointSet pointSet = new PointSet();
			Circle circle = new Circle(new Point(0.0, 0.0, 0.0), radius, new Vector3d(0.0, 0.0, 1.0));
			for (int i = 0; i < numberOfVertices; i++)
			{
				pointSet.Add(circle.RandomPointOnCircle());
			}
			return pointSet;
		}

		public static PointSet RandomOnCube(int numberOfVertices, double length, double width, double height)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < numberOfVertices; i++)
			{
				double num = RandomGenerator.NextDouble_0_1();
				double x = length * RandomGenerator.NextDouble_1_1() / 2.0;
				double y = width * RandomGenerator.NextDouble_1_1() / 2.0;
				double z = height * RandomGenerator.NextDouble_1_1() / 2.0;
				if (num <= 0.16666666666666666)
				{
					pointSet.Add(new Point(x, -width / 2.0, z));
				}
				else if (num <= 0.33333333333333331)
				{
					pointSet.Add(new Point(x, width / 2.0, z));
				}
				else if (num <= 0.5)
				{
					pointSet.Add(new Point(length / 2.0, y, z));
				}
				else if (num <= 0.66666666666666663)
				{
					pointSet.Add(new Point(-length / 2.0, y, z));
				}
				else if (num <= 0.83333333333333337)
				{
					pointSet.Add(new Point(x, y, -height / 2.0));
				}
				else
				{
					pointSet.Add(new Point(x, y, height / 2.0));
				}
			}
			return pointSet;
		}

		public static PointSet RandomOnRectangle(int numberOfVertices, double length, double width)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < numberOfVertices; i++)
			{
				double num = RandomGenerator.NextDouble_0_1();
				double x = length * RandomGenerator.NextDouble_1_1() / 2.0;
				double y = width * RandomGenerator.NextDouble_1_1() / 2.0;
				double z = 0.0;
				if (num <= 0.25)
				{
					pointSet.Add(new Point(x, -width / 2.0, z));
				}
				else if (num <= 0.5)
				{
					pointSet.Add(new Point(x, width / 2.0, z));
				}
				else if (num <= 0.75)
				{
					pointSet.Add(new Point(-length / 2.0, y, z));
				}
				else
				{
					pointSet.Add(new Point(length / 2.0, y, z));
				}
			}
			return pointSet;
		}

		public static PointSet RandomOnSphere(int numberOfVertices, double radius)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < numberOfVertices; i++)
			{
				double num = RandomGenerator.NextDouble_0_Pi();
				double num2 = RandomGenerator.NextDouble_0_2Pi();
				double x = radius * Math.Sin(num) * Math.Cos(num2);
				double y = radius * Math.Sin(num) * Math.Sin(num2);
				double z = radius * Math.Cos(num);
				pointSet.Add(new Point(x, y, z));
			}
			return pointSet;
		}

		public static PointSet Rectangle(double length, double width)
		{
			PointSet pointSet = new PointSet();
			double num = length / 2.0;
			double num2 = width / 2.0;
			pointSet.Add(new Point(num, num2, 0.0));
			pointSet.Add(new Point(-num, -num2, 0.0));
			pointSet.Add(new Point(num, -num2, 0.0));
			pointSet.Add(new Point(-num, num2, 0.0));
			return pointSet;
		}

		public static PointSet SupershapeStarfish(int numberOfVertices)
		{
			Random random = new Random();
			PointSet pointSet = new PointSet();
			int num = Convert.ToInt32(Math.Sqrt((double)numberOfVertices));
			Convert.ToInt32(numberOfVertices / num);
			double num2 = 0.1;
			double y = 1.7;
			double y2 = 1.7;
			double num3 = 0.3;
			double y3 = 0.5;
			double y4 = 0.5;
			double num4 = 5.0;
			double num5 = 1.0;
			double num6 = 1.0;
			double num7 = 1.0;
			double num8 = 1.0;
			double num9 = 1.0;
			for (int i = 0; i < numberOfVertices; i++)
			{
				double num10 = 3.1415926535897931 * (random.NextDouble() - 0.5);
				double num11 = random.NextDouble();
				num10 = Math.Pow(num11, 1.5) * num10;
				if (num11 < 0.05)
				{
					num10 = 0.0;
				}
				double num12 = 6.2831853071795862 * (random.NextDouble() - 0.5);
				double num13 = Math.Pow(Math.Pow(Math.Abs(Math.Cos(num4 * num12 / 4.0) / num6), y) + Math.Pow(Math.Abs(Math.Sin(num4 * num12 / 4.0) / num8), y2), -1.0 / num2);
				double num14 = Math.Pow(Math.Pow(Math.Abs(Math.Cos(num5 * num10 / 4.0) / num7), y3) + Math.Pow(Math.Abs(Math.Sin(num5 * num10 / 4.0) / num9), y4), -1.0 / num3);
				double x = num13 * Math.Cos(num12) * num14 * Math.Cos(num10);
				double y5 = num13 * Math.Sin(num12) * num14 * Math.Cos(num10);
				double z = Math.Abs(num14 * Math.Sin(num10));
				Point point = new Point(x, y5, z);
				pointSet.Add(point);
			}
			return pointSet;
		}

		public static PointSet SupershapeTent(int numberOfVertices)
		{
			Random random = new Random();
			PointSet pointSet = new PointSet();
			int num = Convert.ToInt32(Math.Sqrt((double)numberOfVertices));
			Convert.ToInt32(numberOfVertices / num);
			double num2 = 1.5;
			double y = 1.5;
			double y2 = 1.5;
			double num3 = 1.5;
			double y3 = 1.5;
			double y4 = 1.5;
			double num4 = 6.0;
			double num5 = 3.0;
			double num6 = 1.0;
			double num7 = 1.0;
			double num8 = 1.0;
			double num9 = 1.0;
			for (int i = 0; i < numberOfVertices; i++)
			{
				double num10 = 3.1415926535897931 * (random.NextDouble() - 0.5);
				double num11 = random.NextDouble();
				num10 = Math.Pow(num11, 1.5) * num10;
				if (num11 < 0.05)
				{
					num10 = 0.0;
				}
				double num12 = 6.2831853071795862 * (random.NextDouble() - 0.5);
				double num13 = Math.Pow(Math.Pow(Math.Abs(Math.Cos(num4 * num12 / 4.0) / num6), y) + Math.Pow(Math.Abs(Math.Sin(num4 * num12 / 4.0) / num8), y2), -1.0 / num2);
				double num14 = Math.Pow(Math.Pow(Math.Abs(Math.Cos(num5 * num10 / 4.0) / num7), y3) + Math.Pow(Math.Abs(Math.Sin(num5 * num10 / 4.0) / num9), y4), -1.0 / num3);
				double x = num13 * Math.Cos(num12) * num14 * Math.Cos(num10);
				double y5 = num13 * Math.Sin(num12) * num14 * Math.Cos(num10);
				double z = Math.Abs(num14 * Math.Sin(num10));
				Point point = new Point(x, y5, z);
				pointSet.Add(point);
			}
			return pointSet;
		}

		public static PointSet TiledGrid(double deltaX, double deltaY, int elementsInX, int elementsInY)
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i <= elementsInX; i++)
			{
				for (int j = 0; j <= elementsInY; j++)
				{
					pointSet.Add(new Point((double)i * deltaX, (double)j * deltaY, 0.0));
				}
			}
			return pointSet;
		}
	}
}
