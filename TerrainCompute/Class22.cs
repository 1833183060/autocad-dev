using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class22
{
	internal Class22(ConvexHull2d convexHull2d_1)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class22));
		//base..ctor();
		this.convexHull2d_0 = convexHull2d_1;
	}

	internal ConvexHull2d method_0()
	{
		return this.convexHull2d_0;
	}

	internal void method_1(ConvexHull2d convexHull2d_1)
	{
		this.convexHull2d_0 = convexHull2d_1;
	}

	internal BoundingRectangle method_2()
	{
		this.method_8();
		int num = this.int_2;
		int num2 = this.int_3;
		int num3 = this.int_0;
		int num4 = this.int_1;
		double num5 = 0.0;
		double num6 = 1.7976931348623157E+308;
		BoundingRectangle result = new BoundingRectangle();
		Vector3d vector3d = new Vector3d(-1.0, 0.0, 0.0);
		Vector3d vector3d2 = new Vector3d(1.0, 0.0, 0.0);
		Vector3d vector3d3 = new Vector3d(0.0, 1.0, 0.0);
		Vector3d vector3d4 = new Vector3d(0.0, -1.0, 0.0);
		while (num5 < 3.1415926535897931)
		{
			Vector3d b = new Vector3d(this.pointSet_0[num + 1].X - this.pointSet_0[num].X, this.pointSet_0[num + 1].Y - this.pointSet_0[num].Y, 0.0);
			Vector3d b2 = new Vector3d(this.pointSet_0[num2 + 1].X - this.pointSet_0[num2].X, this.pointSet_0[num2 + 1].Y - this.pointSet_0[num2].Y, 0.0);
			Vector3d b3 = new Vector3d(this.pointSet_0[num3 + 1].X - this.pointSet_0[num3].X, this.pointSet_0[num3 + 1].Y - this.pointSet_0[num3].Y, 0.0);
			Vector3d b4 = new Vector3d(this.pointSet_0[num4 + 1].X - this.pointSet_0[num4].X, this.pointSet_0[num4 + 1].Y - this.pointSet_0[num4].Y, 0.0);
			double num7 = Vector3d.Angle(vector3d, b);
			double num8 = Vector3d.Angle(vector3d2, b2);
			double num9 = Vector3d.Angle(vector3d3, b3);
			double num10 = Vector3d.Angle(vector3d4, b4);
			double num11 = Math.Min(num7, Math.Min(num8, Math.Min(num9, num10)));
			vector3d = this.method_9(vector3d, num11);
			vector3d2 = this.method_9(vector3d2, num11);
			vector3d3 = this.method_9(vector3d3, num11);
			vector3d4 = this.method_9(vector3d4, num11);
			if (num7 == num11)
			{
				num++;
			}
			else if (num8 == num11)
			{
				num2++;
			}
			else if (num9 == num11)
			{
				num3++;
			}
			else
			{
				if (num10 != num11)
				{
					throw new ArithmeticException("Rotating caliper floating point arithmetic error.");
				}
				num4++;
			}
			num5 += num11;
			Line line = new Line(this.pointSet_0[num], vector3d);
			Line line2 = new Line(this.pointSet_0[num2], vector3d2);
			Line line3 = new Line(this.pointSet_0[num3], vector3d3);
			Line line4 = new Line(this.pointSet_0[num4], vector3d4);
			double num12 = line3.DistanceTo(this.pointSet_0[num4]);
			double num13 = line.DistanceTo(this.pointSet_0[num2]);
			double num14 = num13 * num12;
			if (num14 < num6)
			{
				num6 = num14;
				Point midPoint = new Edge(line.method_3(line3), line2.method_3(line4)).MidPoint;
				result = new BoundingRectangle(num12, num13, midPoint, -num5);
			}
		}
		return result;
	}

	internal BoundingRectangle method_3()
	{
		this.method_8();
		int num = this.int_2;
		int num2 = this.int_3;
		int num3 = this.int_0;
		int num4 = this.int_1;
		double num5 = 0.0;
		double num6 = 1.7976931348623157E+308;
		BoundingRectangle result = new BoundingRectangle();
		Vector3d vector3d = new Vector3d(-1.0, 0.0, 0.0);
		Vector3d vector3d2 = new Vector3d(1.0, 0.0, 0.0);
		Vector3d vector3d3 = new Vector3d(0.0, 1.0, 0.0);
		Vector3d vector3d4 = new Vector3d(0.0, -1.0, 0.0);
		while (num5 < 3.1415926535897931)
		{
			Vector3d b = new Vector3d(this.pointSet_0[num + 1].X - this.pointSet_0[num].X, this.pointSet_0[num + 1].Y - this.pointSet_0[num].Y, 0.0);
			Vector3d b2 = new Vector3d(this.pointSet_0[num2 + 1].X - this.pointSet_0[num2].X, this.pointSet_0[num2 + 1].Y - this.pointSet_0[num2].Y, 0.0);
			Vector3d b3 = new Vector3d(this.pointSet_0[num3 + 1].X - this.pointSet_0[num3].X, this.pointSet_0[num3 + 1].Y - this.pointSet_0[num3].Y, 0.0);
			Vector3d b4 = new Vector3d(this.pointSet_0[num4 + 1].X - this.pointSet_0[num4].X, this.pointSet_0[num4 + 1].Y - this.pointSet_0[num4].Y, 0.0);
			double num7 = Vector3d.Angle(vector3d, b);
			double num8 = Vector3d.Angle(vector3d2, b2);
			double num9 = Vector3d.Angle(vector3d3, b3);
			double num10 = Vector3d.Angle(vector3d4, b4);
			double num11 = Math.Min(num7, Math.Min(num8, Math.Min(num9, num10)));
			vector3d = this.method_9(vector3d, num11);
			vector3d2 = this.method_9(vector3d2, num11);
			vector3d3 = this.method_9(vector3d3, num11);
			vector3d4 = this.method_9(vector3d4, num11);
			if (num7 == num11)
			{
				num++;
			}
			else if (num8 == num11)
			{
				num2++;
			}
			else if (num9 == num11)
			{
				num3++;
			}
			else
			{
				if (num10 != num11)
				{
					throw new ArithmeticException("Rotating caliper floating point arithmetic error.");
				}
				num4++;
			}
			num5 += num11;
			Line line = new Line(this.pointSet_0[num], vector3d);
			Line line2 = new Line(this.pointSet_0[num2], vector3d2);
			Line line3 = new Line(this.pointSet_0[num3], vector3d3);
			Line line4 = new Line(this.pointSet_0[num4], vector3d4);
			double num12 = line3.DistanceTo(this.pointSet_0[num4]);
			double num13 = line.DistanceTo(this.pointSet_0[num2]);
			double num14 = 2.0 * (num13 + num12);
			if (num14 < num6)
			{
				num6 = num14;
				Point midPoint = new Edge(line.method_3(line3), line2.method_3(line4)).MidPoint;
				result = new BoundingRectangle(num12, num13, midPoint, -num5);
			}
		}
		return result;
	}

	internal Edge method_4()
	{
		this.method_8();
		int num = this.int_2;
		int num2 = this.int_3;
		Edge edge = new Edge(this.pointSet_0[num], this.pointSet_0[num2]);
		double num3 = 0.0;
		double length = edge.Length;
		Vector3d vector3d = new Vector3d(-1.0, 0.0, 0.0);
		Vector3d vector3d2 = new Vector3d(1.0, 0.0, 0.0);
		while (num3 < 3.1415926535897931)
		{
			Vector3d b = new Vector3d(this.pointSet_0[num + 1].X - this.pointSet_0[num].X, this.pointSet_0[num + 1].Y - this.pointSet_0[num].Y, 0.0);
			Vector3d b2 = new Vector3d(this.pointSet_0[num2 + 1].X - this.pointSet_0[num2].X, this.pointSet_0[num2 + 1].Y - this.pointSet_0[num2].Y, 0.0);
			double num4 = Vector3d.Angle(vector3d, b);
			double num5 = Vector3d.Angle(vector3d2, b2);
			double num6 = Math.Min(num4, num5);
			vector3d = this.method_9(vector3d, num6);
			vector3d2 = this.method_9(vector3d2, num6);
			if (num4 < num5)
			{
				num++;
			}
			else
			{
				num2++;
			}
			num3 += num6;
			List<Edge> list = new List<Edge>();
			list.Add(new Edge(this.pointSet_0[num], this.pointSet_0[num2]));
			list.Add(new Edge(this.pointSet_0[num + 1], this.pointSet_0[num2]));
			list.Add(new Edge(this.pointSet_0[num], this.pointSet_0[num2 + 1]));
			list.Add(new Edge(this.pointSet_0[num + 1], this.pointSet_0[num2 + 1]));
			list.Sort();
			if (list[3].Length > length)
			{
				edge = list[3];
				length = edge.Length;
			}
		}
		return edge;
	}

	internal Edge method_5()
	{
		this.method_8();
		Edge edge = new Edge();
		int num = this.int_2;
		int num2 = this.int_3;
		double num3 = 0.0;
		double num4 = -1.7976931348623157E+308;
		Vector3d vector3d = new Vector3d(-1.0, 0.0, 0.0);
		Vector3d vector3d2 = new Vector3d(1.0, 0.0, 0.0);
		while (num3 < 3.1415926535897931)
		{
			Vector3d b = new Vector3d(this.pointSet_0[num + 1].X - this.pointSet_0[num].X, this.pointSet_0[num + 1].Y - this.pointSet_0[num].Y, 0.0);
			Vector3d b2 = new Vector3d(this.pointSet_0[num2 + 1].X - this.pointSet_0[num2].X, this.pointSet_0[num2 + 1].Y - this.pointSet_0[num2].Y, 0.0);
			double num5 = Vector3d.Angle(vector3d, b);
			double num6 = Vector3d.Angle(vector3d2, b2);
			double num7 = Math.Min(num5, num6);
			vector3d = this.method_9(vector3d, num7);
			vector3d2 = this.method_9(vector3d2, num7);
			if (num5 < num6)
			{
				num++;
			}
			else
			{
				num2++;
			}
			num3 += num7;
			double num8 = new Line(this.pointSet_0[num], vector3d).DistanceTo(this.pointSet_0[num2]);
			if (num8 > num4)
			{
				edge = this.pointSet_0[num2].PerpendicularOn(new Line(this.pointSet_0[num], vector3d));
				num4 = edge.Length;
			}
		}
		return edge;
	}

	internal Edge method_6()
	{
		this.method_8();
		Edge edge = new Edge();
		int num = this.int_2;
		int num2 = this.int_3;
		double num3 = 0.0;
		double num4 = 1.7976931348623157E+308;
		Vector3d vector3d = new Vector3d(-1.0, 0.0, 0.0);
		Vector3d vector3d2 = new Vector3d(1.0, 0.0, 0.0);
		while (num3 < 3.1415926535897931)
		{
			Vector3d b = new Vector3d(this.pointSet_0[num + 1].X - this.pointSet_0[num].X, this.pointSet_0[num + 1].Y - this.pointSet_0[num].Y, 0.0);
			Vector3d b2 = new Vector3d(this.pointSet_0[num2 + 1].X - this.pointSet_0[num2].X, this.pointSet_0[num2 + 1].Y - this.pointSet_0[num2].Y, 0.0);
			double num5 = Vector3d.Angle(vector3d, b);
			double num6 = Vector3d.Angle(vector3d2, b2);
			double num7 = Math.Min(num5, num6);
			vector3d = this.method_9(vector3d, num7);
			vector3d2 = this.method_9(vector3d2, num7);
			if (num5 < num6)
			{
				num++;
			}
			else
			{
				num2++;
			}
			num3 += num7;
			double num8 = new Line(this.pointSet_0[num], vector3d).DistanceTo(this.pointSet_0[num2]);
			if (num8 < num4)
			{
				edge = this.pointSet_0[num2].PerpendicularOn(new Line(this.pointSet_0[num], vector3d));
				num4 = edge.Length;
			}
		}
		return edge;
	}

	internal BoundingRectangle method_7(BoundingRectangle boundingRectangle_0)
	{
		this.method_8();
		int num = this.int_2;
		int num2 = this.int_3;
		int num3 = this.int_0;
		int num4 = this.int_1;
		double num5 = 0.0;
		new BoundingRectangle();
		Vector3d vector3d = new Vector3d(-1.0, 0.0, 0.0);
		Vector3d vector3d2 = new Vector3d(1.0, 0.0, 0.0);
		Vector3d vector3d3 = new Vector3d(0.0, 1.0, 0.0);
		Vector3d vector3d4 = new Vector3d(0.0, -1.0, 0.0);
		while (num5 < 3.1415926535897931)
		{
			Vector3d b = new Vector3d(this.pointSet_0[num + 1].X - this.pointSet_0[num].X, this.pointSet_0[num + 1].Y - this.pointSet_0[num].Y, 0.0);
			Vector3d b2 = new Vector3d(this.pointSet_0[num2 + 1].X - this.pointSet_0[num2].X, this.pointSet_0[num2 + 1].Y - this.pointSet_0[num2].Y, 0.0);
			Vector3d b3 = new Vector3d(this.pointSet_0[num3 + 1].X - this.pointSet_0[num3].X, this.pointSet_0[num3 + 1].Y - this.pointSet_0[num3].Y, 0.0);
			Vector3d b4 = new Vector3d(this.pointSet_0[num4 + 1].X - this.pointSet_0[num4].X, this.pointSet_0[num4 + 1].Y - this.pointSet_0[num4].Y, 0.0);
			double num6 = Vector3d.Angle(vector3d, b);
			double num7 = Vector3d.Angle(vector3d2, b2);
			double num8 = Vector3d.Angle(vector3d3, b3);
			double num9 = Vector3d.Angle(vector3d4, b4);
			double num10 = Math.Min(num6, Math.Min(num7, Math.Min(num8, num9)));
			vector3d = this.method_9(vector3d, num10);
			vector3d2 = this.method_9(vector3d2, num10);
			vector3d3 = this.method_9(vector3d3, num10);
			vector3d4 = this.method_9(vector3d4, num10);
			if (num6 == num10)
			{
				num++;
			}
			else if (num7 == num10)
			{
				num2++;
			}
			else if (num8 == num10)
			{
				num3++;
			}
			else
			{
				if (num9 != num10)
				{
					throw new ArithmeticException("Rotating caliper floating point arithmetic error.");
				}
				num4++;
			}
			num5 += num10;
			Line line = new Line(this.pointSet_0[num], vector3d);
			Line line2 = new Line(this.pointSet_0[num2], vector3d2);
			Line line3 = new Line(this.pointSet_0[num3], vector3d3);
			Line line4 = new Line(this.pointSet_0[num4], vector3d4);
			double num11 = line3.DistanceTo(this.pointSet_0[num4]);
			double num12 = line.DistanceTo(this.pointSet_0[num2]);
			if (num11 < boundingRectangle_0.Length && num12 < boundingRectangle_0.Width)
			{
				Point midPoint = new Edge(line.method_3(line3), line2.method_3(line4)).MidPoint;
				return new BoundingRectangle(num11, num12, midPoint, -num5);
			}
		}
		return null;
	}

	private void method_8()
	{
		this.pointSet_0 = new PointSet();
		for (int i = 0; i < this.convexHull2d_0.Vertices.Count; i++)
		{
			this.pointSet_0.Add(new Point(this.convexHull2d_0.Vertices[i].X, this.convexHull2d_0.Vertices[i].Y, 0.0));
		}
		for (int j = 0; j < this.convexHull2d_0.Vertices.Count; j++)
		{
			this.pointSet_0.Add(new Point(this.convexHull2d_0.Vertices[j].X, this.convexHull2d_0.Vertices[j].Y, 0.0));
		}
		double num = 1.7976931348623157E+308;
		double num2 = -1.7976931348623157E+308;
		double num3 = 1.7976931348623157E+308;
		double num4 = -1.7976931348623157E+308;
		for (int k = 0; k < this.convexHull2d_0.Vertices.Count; k++)
		{
			if (num3 > this.convexHull2d_0.Vertices[k].Y)
			{
				num3 = this.convexHull2d_0.Vertices[k].Y;
				this.int_2 = k;
			}
			if (num4 < this.convexHull2d_0.Vertices[k].Y)
			{
				num4 = this.convexHull2d_0.Vertices[k].Y;
				this.int_3 = k;
			}
			if (num > this.convexHull2d_0.Vertices[k].X)
			{
				num = this.convexHull2d_0.Vertices[k].X;
				this.int_0 = k;
			}
			if (num2 < this.convexHull2d_0.Vertices[k].X)
			{
				num2 = this.convexHull2d_0.Vertices[k].X;
				this.int_1 = k;
			}
		}
	}

	private Vector3d method_9(Vector3d vector3d_0, double double_0)
	{
		double x = Math.Cos(double_0) * vector3d_0.X + Math.Sin(double_0) * vector3d_0.Y;
		double y = -Math.Sin(double_0) * vector3d_0.X + Math.Cos(double_0) * vector3d_0.Y;
		return new Vector3d(x, y, 0.0);
	}

	private ConvexHull2d convexHull2d_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private PointSet pointSet_0;
}
