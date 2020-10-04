using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using TcFunctions;

internal class Class37
{
	public Class37(Point3dCollection point3dCollection_0)
	{
		Class39.k1QjQlczC5Jf5();
		base..ctor();
		this.object_0 = null;
		this.object_0 = point3dCollection_0;
	}

	public void method_0()
	{
		Point3d first = this.object_0[0];
		(from Point3d point in this.object_0
		orderby Class37.smethod_0(first, point)
		select point).ToArray<Point3d>();
		Class38 @class = new Class38(this.object_0);
		@class.method_0();
		Point3dCollection point3dCollection_ = @class.point3dCollection_1;
		List<Line> list = new List<Line>();
		list.Add(new Line(point3dCollection_[0], point3dCollection_[1]));
		int i = 0;
		checked
		{
			while (i < list.Count)
			{
				double num = -1.0;
				bool flag = false;
				int num2 = 0;
				int j = 0;
				while (j < this.object_0.Count)
				{
					if (Class37.smethod_1(this.object_0[j], list[i].StartPoint, list[i].EndPoint))
					{
						double num3 = Class37.smethod_2(this.object_0[j], list[i].StartPoint, list[i].EndPoint);
						if (num3 > num)
						{
							num = num3;
							num2 = j;
						}
						flag = true;
					}
					Math.Max(Interlocked.Increment(ref j), j - 1);
				}
				if (flag)
				{
					Line line = new Line();
					Line line2 = new Line();
					line.StartPoint = list[i].StartPoint;
					line.EndPoint = this.object_0[num2];
					bool flag2 = false;
					int k = 0;
					while (k < list.Count)
					{
						bool flag3 = (line.StartPoint == list[k].StartPoint && line.EndPoint == list[k].EndPoint) || (line.EndPoint == list[k].StartPoint && line.StartPoint == list[k].EndPoint);
						flag2 = (flag2 || flag3);
						Math.Max(Interlocked.Increment(ref k), k - 1);
					}
					if (!flag2)
					{
						list.Add(line);
					}
					line2.StartPoint = this.object_0[num2];
					line2.EndPoint = list[i].EndPoint;
					k = 0;
					while (k < list.Count)
					{
						bool flag4 = (line2.StartPoint == list[k].StartPoint && line2.EndPoint == list[k].EndPoint) || (line2.EndPoint == list[k].StartPoint && line2.StartPoint == list[k].EndPoint);
						flag2 = (flag2 || flag4);
						Math.Max(Interlocked.Increment(ref k), k - 1);
					}
					if (!flag2)
					{
						list.Add(line2);
					}
				}
				Math.Max(Interlocked.Increment(ref i), i - 1);
			}
			try
			{
				foreach (Line e in list)
				{
					CAD.AddEnt(e);
				}
			}
			finally
			{
				List<Line>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}
	}

	public static double smethod_0(Point3d point3d_0, Point3d point3d_1)
	{
		double num = point3d_0.X - point3d_1.X;
		double num2 = point3d_0.Y - point3d_1.Y;
		double num3 = point3d_0.X - point3d_1.Z;
		return num * num + num2 * num2 + num3 * num3;
	}

	public static bool smethod_1(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		double num = (point3d_2.X - point3d_1.X) * (point3d_0.Y - point3d_1.Y) - (point3d_0.X - point3d_1.X) * (point3d_2.Y - point3d_1.Y);
		return num > 0.0;
	}

	public static double smethod_2(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		double num = point3d_1.X - point3d_0.X;
		double num2 = point3d_1.Y - point3d_0.Y;
		double num3 = point3d_2.X - point3d_0.X;
		double num4 = point3d_2.Y - point3d_0.Y;
		double result;
		if (num * num3 + num2 * num4 == 0.0)
		{
			result = -1.0;
		}
		else
		{
			double num5 = Math.Acos((num * num3 + num2 * num4) / Math.Sqrt((num * num + num2 * num2) * (num3 * num3 + num4 * num4)));
			result = num5;
		}
		return result;
	}

	private object object_0;

	[CompilerGenerated]
	internal class _Closure$__1
	{
		[DebuggerNonUserCode]
		public _Closure$__1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[DebuggerNonUserCode]
		public _Closure$__1(Class37._Closure$__1 other)
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			if (other != null)
			{
				this.$VB$Local_first = other.$VB$Local_first;
			}
		}

		[CompilerGenerated]
		public double _Lambda$__1(Point3d point)
		{
			return Class37.smethod_0(this.$VB$Local_first, point);
		}

		public Point3d $VB$Local_first;
	}
}
