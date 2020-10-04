using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class24
{
	internal Class24()
	{       
	}

	internal Class24(Point point_3, Point point_4, Point point_5)
	{        
		this.point_0 = point_3;
		this.point_1 = point_4;
		this.point_2 = point_5;
	}

	internal Point getPoint0()
	{
		return this.point_0;
	}

	internal void setPoint0(Point point_3)
	{
		this.point_0 = point_3;
	}

	internal double method_10()
	{
		double num = this.getPoint1().X - this.getPoint0().X;
		double num2 = this.getPoint1().Y - this.getPoint0().Y;
		double num3 = this.getPoint2().X - this.getPoint0().X;
		double num4 = this.getPoint2().Y - this.getPoint0().Y;
		double num5 = this.getPoint2().X - this.getPoint1().X;
		double num6 = this.getPoint2().Y - this.getPoint1().Y;
		double val = Math.Sqrt(num * num + num2 * num2);
		double val2 = Math.Sqrt(num3 * num3 + num4 * num4);
		double val3 = Math.Sqrt(num5 * num5 + num6 * num6);
		return Math.Max(val, Math.Max(val2, val3));
	}

	internal double method_11()
	{
		double num = this.getPoint1().X - this.getPoint0().X;
		double num2 = this.getPoint1().Y - this.getPoint0().Y;
		double num3 = this.getPoint2().X - this.getPoint0().X;
		double num4 = this.getPoint2().Y - this.getPoint0().Y;
		return 0.5 * Math.Abs(num * num4 - num2 * num3);
	}

	internal Edge method_12()
	{
		return new Edge(this.point_1, this.point_2);
	}

	internal Edge method_13()
	{
		return new Edge(this.point_2, this.point_0);
	}

	internal Edge method_14()
	{
		return new Edge(this.point_0, this.point_1);
	}

	internal Edge method_15(int int_0)
	{
		switch (int_0)
		{
		case 1:
			return this.method_12();
		case 2:
			return this.method_13();
		case 3:
			return this.method_14();
		default:
			throw new ArgumentException("Invalid edge index. Must be 1, 2 or 3.", "i");
		}
	}

	internal Point method_16()
	{
		double num = this.point_1.Y - this.point_2.Y;
		double num2 = this.point_2.Y - this.point_0.Y;
		double num3 = this.point_0.Y - this.point_1.Y;
		double num4 = this.point_1.X - this.point_2.X;
		double num5 = this.point_2.X - this.point_0.X;
		double num6 = this.point_0.X - this.point_1.X;
		double num7 = this.point_0.X * this.point_0.X + this.point_0.Y * this.point_0.Y;
		double num8 = this.point_1.X * this.point_1.X + this.point_1.Y * this.point_1.Y;
		double num9 = this.point_2.X * this.point_2.X + this.point_2.Y * this.point_2.Y;
		double num10 = this.point_0.X * num + this.point_1.X * num2 + this.point_2.X * num3;
		double num11 = num7 * num + num8 * num2 + num9 * num3;
		double num12 = num7 * num4 + num8 * num5 + num9 * num6;
		double num13 = 1.0 / num10;
		double x = 0.5 * num11 * num13;
		double y = -0.5 * num12 * num13;
		return new Point(x, y, 0.0);
	}

	internal bool method_17(Class24 class24_0)
	{
		return (this.getPoint0().X == class24_0.getPoint0().X && this.getPoint0().Y == class24_0.getPoint0().Y) || (this.getPoint0().X == class24_0.getPoint1().X && this.getPoint0().Y == class24_0.getPoint1().Y) || (this.getPoint0().X == class24_0.getPoint2().X && this.getPoint0().Y == class24_0.getPoint2().Y) || (this.getPoint1().X == class24_0.getPoint0().X && this.getPoint1().Y == class24_0.getPoint0().Y) || (this.getPoint1().X == class24_0.getPoint1().X && this.getPoint1().Y == class24_0.getPoint1().Y) || (this.getPoint1().X == class24_0.getPoint2().X && this.getPoint1().Y == class24_0.getPoint2().Y) || (this.getPoint2().X == class24_0.getPoint0().X && this.getPoint2().Y == class24_0.getPoint0().Y) || (this.getPoint2().X == class24_0.getPoint1().X && this.getPoint2().Y == class24_0.getPoint1().Y) || (this.getPoint2().X == class24_0.getPoint2().X && this.getPoint2().Y == class24_0.getPoint2().Y);
	}

	internal bool method_18(Point point_3)
	{
		return (this.getPoint0().X == point_3.X && this.getPoint0().Y == point_3.Y) || (this.getPoint1().X == point_3.X && this.getPoint1().Y == point_3.Y) || (this.getPoint2().X == point_3.X && this.getPoint2().Y == point_3.Y);
	}

	internal int method_19(Point point_3)
	{
		if (this.getPoint0().X == point_3.X && this.getPoint0().Y == point_3.Y)
		{
			return 1;
		}
		if (this.getPoint1().X == point_3.X && this.getPoint1().Y == point_3.Y)
		{
			return 2;
		}
		if (this.getPoint2().X == point_3.X && this.getPoint2().Y == point_3.Y)
		{
			return 3;
		}
		return 0;
	}

	internal Point getPoint1()
	{
		return this.point_1;
	}

	internal Triangle method_20()
	{
		return new Triangle(this.getPoint0(), this.getPoint1(), this.getPoint2());
	}

	internal void setPoint1(Point point_3)
	{
		this.point_1 = point_3;
	}

	internal Point getPoint2()
	{
		return this.point_2;
	}

	internal void setPoint2(Point point_3)
	{
		this.point_2 = point_3;
	}

	internal Point method_6()
	{
		double x = (this.getPoint0().X + this.getPoint1().X + this.getPoint2().X) / 3.0;
		double y = (this.getPoint0().Y + this.getPoint1().Y + this.getPoint2().Y) / 3.0;
		double z = (this.getPoint0().Z + this.getPoint1().Z + this.getPoint2().Z) / 3.0;
		return new Point(x, y, z);
	}

	internal double method_7()
	{
		double num = this.getPoint1().X - this.getPoint0().X;
		double num2 = this.getPoint1().Y - this.getPoint0().Y;
		double num3 = this.getPoint1().Z - this.getPoint0().Z;
		double num4 = this.getPoint2().X - this.getPoint0().X;
		double num5 = this.getPoint2().Y - this.getPoint0().Y;
		double num6 = this.getPoint2().Z - this.getPoint0().Z;
		double num7 = num2 * num6 - num3 * num5;
		double num8 = num3 * num4 - num * num6;
		double num9 = num * num5 - num2 * num4;
		return 0.5 * Math.Sqrt(num7 * num7 + num8 * num8 + num9 * num9);
	}

	internal Point method_8()
	{
		double x = (this.getPoint0().X + this.getPoint1().X + this.getPoint2().X) / 3.0;
		double y = (this.getPoint0().Y + this.getPoint1().Y + this.getPoint2().Y) / 3.0;
		return new Point(x, y, 0.0);
	}

	internal double method_9()
	{
		double num = this.getPoint1().X - this.getPoint0().X;
		double num2 = this.getPoint1().Y - this.getPoint0().Y;
		double num3 = this.getPoint2().X - this.getPoint0().X;
		double num4 = this.getPoint2().Y - this.getPoint0().Y;
		double num5 = this.getPoint2().X - this.getPoint1().X;
		double num6 = this.getPoint2().Y - this.getPoint1().Y;
		double value = num * num3 + num2 * num4;
		double value2 = num * num5 + num2 * num6;
		double value3 = num3 * num5 + num4 * num6;
		double num7 = num * num + num2 * num2;
		double num8 = num3 * num3 + num4 * num4;
		double num9 = num5 * num5 + num6 * num6;
		if (num7 < 4.94065645841247E-324 | num8 < 4.94065645841247E-324 | num9 < 4.94065645841247E-324)
		{
			return 0.0;
		}
		double val = Math.Acos(Math.Abs(value) / Math.Sqrt(num7 * num8));
		double val2 = Math.Acos(Math.Abs(value2) / Math.Sqrt(num7 * num9));
		double val3 = Math.Acos(Math.Abs(value3) / Math.Sqrt(num8 * num9));
		return Math.Min(val, Math.Min(val2, val3));
	}

	internal Point point_0;

	internal Point point_1;

	internal Point point_2;
}
