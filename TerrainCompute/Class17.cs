using System;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class17
{
	internal Class17()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class17));
		//base..ctor();
	}

	internal Class17(Point point_1, Vector3d vector3d_1)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class17));
		//base..ctor();
		this.point_0 = point_1;
		this.vector3d_0 = vector3d_1;
	}

	internal Point method_0()
	{
		return this.point_0;
	}

	internal void method_1(Point point_1)
	{
		this.point_0 = point_1;
	}

	internal Vector3d method_2()
	{
		return this.vector3d_0;
	}

	internal void method_3(Vector3d vector3d_1)
	{
		this.vector3d_0 = vector3d_1;
	}

	internal Point method_4(Edge edge_0)
	{
		double x = this.point_0.X;
		double y = this.point_0.Y;
		double num = x + 1000.0 * this.vector3d_0.X;
		double num2 = num + 1000.0 * this.vector3d_0.Y;
		double x2 = edge_0.StartPoint.X;
		double y2 = edge_0.StartPoint.Y;
		double x3 = edge_0.EndPoint.X;
		double y3 = edge_0.EndPoint.Y;
		double num3 = x3 - x2;
		double num4 = y - y2;
		double num5 = y3 - y2;
		double num6 = x - x2;
		double num7 = num - x;
		double num8 = num2 - y;
		double num9 = num5 * num7 - num3 * num8;
		if (Math.Abs(num9) < 4.94065645841247E-324)
		{
			return null;
		}
		double num10 = num3 * num4 - num5 * num6;
		double num11 = num10 / num9;
		if (num11 < 0.0)
		{
			return null;
		}
		double num12 = num7 * num4 - num8 * num6;
		double num13 = num12 / num9;
		if (num13 >= 0.0 && num13 <= 1.0)
		{
			double x4 = x + num11 * num7;
			double y4 = y + num11 * num8;
			return new Point(x4, y4, 0.0);
		}
		return null;
	}

	internal bool method_5(Edge edge_0, ref bool bool_0)
	{
		bool_0 = false;
		double x = this.point_0.X;
		double y = this.point_0.Y;
		double num = x + this.vector3d_0.X;
		double num2 = num + this.vector3d_0.Y;
		double x2 = edge_0.StartPoint.X;
		double y2 = edge_0.StartPoint.Y;
		double x3 = edge_0.EndPoint.X;
		double y3 = edge_0.EndPoint.Y;
		int num3 = Math.Sign(Predicate.Orient2d_exact(new Point(x, y, 0.0), new Point(num, num2, 0.0), new Point(x2, y2, 0.0)));
		if (num3 == 0)
		{
			bool_0 = true;
		}
		int num4 = Math.Sign(Predicate.Orient2d_exact(new Point(x, y, 0.0), new Point(num, num2, 0.0), new Point(x3, y3, 0.0)));
		if (num4 == 0)
		{
			bool_0 = true;
		}
		if (num3 == num4)
		{
			return false;
		}
		double num5 = x3 - x2;
		double num6 = y - y2;
		double num7 = y3 - y2;
		double num8 = x - x2;
		double num9 = num - x;
		double num10 = num2 - y;
		double num11 = num7 * num9 - num5 * num10;
		if (Math.Abs(num11) < 4.94065645841247E-324)
		{
			return false;
		}
		double num12 = num5 * num6 - num7 * num8;
		double num13 = num12 / num11;
		return num13 >= 0.0;
	}

	internal bool method_6(Edge edge_0, ref bool bool_0)
	{
		bool_0 = false;
		double x = this.point_0.X;
		double y = this.point_0.Y;
		double x2 = edge_0.StartPoint.X;
		double y2 = edge_0.StartPoint.Y;
		double x3 = edge_0.EndPoint.X;
		double y3 = edge_0.EndPoint.Y;
		if (Math.Abs(y2 - y) < 1E-09 || Math.Abs(y3 - y) < 1E-09)
		{
			bool_0 = true;
		}
		if (y2 > y && y3 > y)
		{
			return false;
		}
		if (y2 < y && y3 < y)
		{
			return false;
		}
		if (x2 > x && x3 > x)
		{
			return false;
		}
		if (x2 < x && x3 < x)
		{
			return true;
		}
		double num = x3 - x2;
		double num2 = y3 - y2;
		if (Math.Abs(num2) < 1E-09)
		{
			bool_0 = true;
			return true;
		}
		double num3 = x - x2 - num / num2 * (y - y2);
		if (num3 < 1E-09)
		{
			bool_0 = true;
		}
		return num3 > 0.0;
	}

	internal static Class17 smethod_0(Point point_1)
	{
		Vector3d vector3d = Vector3d.RandomVector();
		vector3d.Z = 0.0;
		vector3d.Normalize();
		return new Class17(new Point(point_1.X, point_1.Y, 0.0), vector3d);
	}

	private Point point_0;

	private Vector3d vector3d_0;
}
