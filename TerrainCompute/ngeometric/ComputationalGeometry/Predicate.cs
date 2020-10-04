using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class Predicate
	{
		public Predicate()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Predicate));
			//base..ctor();
		}

		public static double InCircle2dExact(Point p1, Point p2, Point p3, Point point)
		{
			if (!Class20.bool_0)
			{
				Class20.smethod_0();
			}
			double num = p1.X - point.X;
			double num2 = p2.X - point.X;
			double num3 = p3.X - point.X;
			double num4 = p1.Y - point.Y;
			double num5 = p2.Y - point.Y;
			double num6 = p3.Y - point.Y;
			double num7 = num2 * num6;
			double num8 = num3 * num5;
			double num9 = num * num + num4 * num4;
			double num10 = num3 * num4;
			double num11 = num * num6;
			double num12 = num2 * num2 + num5 * num5;
			double num13 = num * num5;
			double num14 = num2 * num4;
			double num15 = num3 * num3 + num6 * num6;
			double num16 = num9 * (num7 - num8) + num12 * (num10 - num11) + num15 * (num13 - num14);
			double num17 = (Math.Abs(num7) + Math.Abs(num8)) * num9 + (Math.Abs(num10) + Math.Abs(num11)) * num12 + (Math.Abs(num13) + Math.Abs(num14)) * num15;
			double num18 = Class20.double_5 * num17;
			if (num16 <= num18 && -num16 <= num18)
			{
				return double.NaN;
			}
			return num16;
		}

		public static double InCircleArbitrary(Point p1, Point p2, Point p3, Point point)
		{
			double x = point.X;
			double y = point.Y;
			double x2 = p1.X;
			double y2 = p1.Y;
			double x3 = p2.X;
			double y3 = p2.Y;
			double x4 = p3.X;
			double y4 = p3.Y;
			double num4;
			double num5;
			if (Math.Abs(y3 - y2) < 4.94065645841247E-324)
			{
				double num = (x3 - x4) / (y4 - y3);
				double num2 = (x3 + x4) * 0.5;
				double num3 = (y3 + y4) * 0.5;
				num4 = (x3 + x2) * 0.5;
				num5 = num * (num4 - num2) + num3;
			}
			else if (Math.Abs(y4 - y3) < 4.94065645841247E-324)
			{
				double num6 = (x2 - x3) / (y3 - y2);
				double num7 = (x2 + x3) * 0.5;
				double num8 = (y2 + y3) * 0.5;
				num4 = (x4 + x3) * 0.5;
				num5 = num6 * (num4 - num7) + num8;
			}
			else
			{
				double num6 = (x2 - x3) / (y3 - y2);
				double num = (x3 - x4) / (y4 - y3);
				double num7 = (x2 + x3) * 0.5;
				double num2 = (x3 + x4) * 0.5;
				double num8 = (y2 + y3) * 0.5;
				double num3 = (y3 + y4) * 0.5;
				num4 = (num6 * num7 - num * num2 + num3 - num8) / (num6 - num);
				num5 = num6 * (num4 - num7) + num8;
			}
			double num9 = x3 - num4;
			double num10 = y3 - num5;
			double num11 = num9 * num9 + num10 * num10;
			num9 = x - num4;
			num10 = y - num5;
			double num12 = num9 * num9 + num10 * num10;
			return num11 - num12;
		}

		public static double InCircleOrdered(Point p1, Point p2, Point p3, Point point)
		{
			double num = p1.X - point.X;
			double num2 = p1.Y - point.Y;
			double num3 = p2.X - point.X;
			double num4 = p2.Y - point.Y;
			double num5 = p3.X - point.X;
			double num6 = p3.Y - point.Y;
			double num7 = num * num4 - num3 * num2;
			double num8 = num3 * num6 - num5 * num4;
			double num9 = num5 * num2 - num * num6;
			double num10 = num * num + num2 * num2;
			double num11 = num3 * num3 + num4 * num4;
			double num12 = num5 * num5 + num6 * num6;
			return num10 * num8 + num11 * num9 + num12 * num7;
		}

		public static double IntersectsExact(Edge e1, Edge e2)
		{
			Point startPoint = e1.StartPoint;
			Point endPoint = e1.EndPoint;
			Point startPoint2 = e2.StartPoint;
			Point endPoint2 = e2.EndPoint;
			double num = (double)Math.Sign(Predicate.Orient2d_exact(startPoint, endPoint, startPoint2));
			double num2 = (double)Math.Sign(Predicate.Orient2d_exact(startPoint, endPoint, endPoint2));
			double num3 = (double)Math.Sign(Predicate.Orient2d_exact(startPoint2, endPoint2, startPoint));
			double num4 = (double)Math.Sign(Predicate.Orient2d_exact(startPoint2, endPoint2, endPoint));
			int num5 = 0;
			if (num == 0.0)
			{
				num5++;
			}
			if (num2 == 0.0)
			{
				num5++;
			}
			if (num3 == 0.0)
			{
				num5++;
			}
			if (num4 == 0.0)
			{
				num5++;
			}
			switch (num5)
			{
			case 0:
				if (num != num2 && num3 != num4)
				{
					return 1.0;
				}
				return -1.0;
			case 1:
				if (num != num2)
				{
					if (num3 != num4)
					{
						return 0.0;
					}
				}
				return -1.0;
			case 2:
				return 2.0;
			case 4:
				return double.NaN;
			}
            throw new System.Exception("Exact arithmetic failure at edge intersection:\nEdge 1: " + e1.ToString() + "\nEdge 2: " + e2.ToString());
		}

		public static double InTriangle2dArbitraryExact(Point vertex1, Point vertex2, Point vertex3, Point point)
		{
			double num = (double)Math.Sign(Predicate.Orient2d_exact(vertex1, vertex2, point));
			double num2 = (double)Math.Sign(Predicate.Orient2d_exact(vertex2, vertex3, point));
			double num3 = (double)Math.Sign(Predicate.Orient2d_exact(vertex3, vertex1, point));
			if (num == num2 && num2 == num3 && num != 0.0)
			{
				return 1.0;
			}
			if (num == 0.0 && num2 == 0.0 && num3 == 0.0)
			{
				return double.NaN;
			}
			if (num == 0.0 && num2 == 0.0)
			{
				return 0.0;
			}
			if (num == 0.0 && num3 == 0.0)
			{
				return 0.0;
			}
			if (num2 == 0.0 && num3 == 0.0)
			{
				return 0.0;
			}
			if (num == 0.0 && num2 == num3)
			{
				return 0.0;
			}
			if (num2 == 0.0 && num == num3)
			{
				return 0.0;
			}
			if (num3 == 0.0 && num == num2)
			{
				return 0.0;
			}
			return -1.0;
		}

		public static double InTriangle2dExact(Point vertex1, Point vertex2, Point vertex3, Point point)
		{
			double num = Predicate.Orient2d_exact(vertex1, vertex2, point);
			if (num < 0.0)
			{
				return num;
			}
			double num2 = Predicate.Orient2d_exact(vertex2, vertex3, point);
			if (num2 < 0.0)
			{
				return num2;
			}
			double num3 = Predicate.Orient2d_exact(vertex3, vertex1, point);
			if (num3 < 0.0)
			{
				return num3;
			}
			return Math.Min(num, Math.Min(num2, num3));
		}

		public static double InTriangleArbitrary(Point vertex1, Point vertex2, Point vertex3, Point point)
		{
			double x = vertex1.X;
			double y = vertex1.Y;
			double x2 = vertex2.X;
			double y2 = vertex2.Y;
			double x3 = vertex3.X;
			double y3 = vertex3.Y;
			double x4 = point.X;
			double y4 = point.Y;
			double num = ((x2 - x) * (y4 - y) - (y2 - y) * (x4 - x)) * ((x2 - x) * (y3 - y) - (y2 - y) * (x3 - x));
			if (num <= 0.0)
			{
				return num;
			}
			double num2 = ((x3 - x) * (y4 - y) - (y3 - y) * (x4 - x)) * ((x3 - x) * (y2 - y) - (y3 - y) * (x2 - x));
			if (num2 <= 0.0)
			{
				return num2;
			}
			double num3 = ((x3 - x2) * (y4 - y2) - (y3 - y2) * (x4 - x2)) * ((x3 - x2) * (y - y2) - (y3 - y2) * (x - x2));
			if (num3 <= 0.0)
			{
				return num3;
			}
			return num + num2 + num3;
		}

		public static double Orient2d(Point pa, Point pb, Point point)
		{
			double num = pa.X - point.X;
			double num2 = pb.X - point.X;
			double num3 = pa.Y - point.Y;
			double num4 = pb.Y - point.Y;
			return num * num4 - num3 * num2;
		}

		public static double Orient2d_exact(Point pa, Point pb, Point point)
		{
			if (!Class20.bool_0)
			{
				Class20.smethod_0();
			}
			double num = (pa.X - point.X) * (pb.Y - point.Y);
			double num2 = (pa.Y - point.Y) * (pb.X - point.X);
			double num3 = num - num2;
			double num4;
			if (num > 0.0)
			{
				if (num2 <= 0.0)
				{
					return num3;
				}
				num4 = num + num2;
			}
			else
			{
				if (num >= 0.0)
				{
					return num3;
				}
				if (num2 >= 0.0)
				{
					return num3;
				}
				num4 = -num - num2;
			}
			double num5 = Class20.double_2 * num4;
			if (num3 < num5 && -num3 < num5)
			{
				return Class19.smethod_0(pa, pb, point, num4);
			}
			return num3;
		}

		public static double Orient3d(Point pa, Point pb, Point pc, Point point)
		{
			double num = pa.X - point.X;
			double num2 = pb.X - point.X;
			double num3 = pc.X - point.X;
			double num4 = pa.Y - point.Y;
			double num5 = pb.Y - point.Y;
			double num6 = pc.Y - point.Y;
			double num7 = pa.Z - point.Z;
			double num8 = pb.Z - point.Z;
			double num9 = pc.Z - point.Z;
			return num * (num5 * num9 - num8 * num6) + num2 * (num6 * num7 - num9 * num4) + num3 * (num4 * num8 - num7 * num5);
		}

		public static double Orient3d_exact(Point pa, Point pb, Point pc, Point point)
		{
			double num = pa.X - point.X;
			double num2 = pb.X - point.X;
			double num3 = pc.X - point.X;
			double num4 = pa.Y - point.Y;
			double num5 = pb.Y - point.Y;
			double num6 = pc.Y - point.Y;
			double num7 = pa.Z - point.Z;
			double num8 = pb.Z - point.Z;
			double num9 = pc.Z - point.Z;
			double num10 = num2 * num6;
			double num11 = num3 * num5;
			double num12 = num3 * num4;
			double num13 = num * num6;
			double num14 = num * num5;
			double num15 = num2 * num4;
			double num16 = num7 * (num10 - num11) + num8 * (num12 - num13) + num9 * (num14 - num15);
			double num17 = (Math.Abs(num10) + Math.Abs(num11)) * Math.Abs(num7) + (Math.Abs(num12) + Math.Abs(num13)) * Math.Abs(num8) + (Math.Abs(num14) + Math.Abs(num15)) * Math.Abs(num9);
			double num18 = Class20.double_6 * num17;
			if (num16 <= num18 && -num16 <= num18)
			{
				return Class19.smethod_3(pa, pb, pc, point);
			}
			return num16;
		}

		public static double Orientatation2dExact(Triangle triangle)
		{
			Point vertex = triangle.Vertex1;
			Point vertex2 = triangle.Vertex2;
			Point vertex3 = triangle.Vertex3;
			double num = Predicate.Orient2d_exact(vertex, vertex2, vertex3);
			if (num < 0.0)
			{
				return num;
			}
			double num2 = Predicate.Orient2d_exact(vertex2, vertex3, vertex);
			if (num2 < 0.0)
			{
				return num2;
			}
			double num3 = Predicate.Orient2d_exact(vertex3, vertex, vertex2);
			if (num3 < 0.0)
			{
				return num3;
			}
			return num;
		}
	}
}
