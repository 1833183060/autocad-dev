using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	public class DelaunayTriangulation2d
	{
		public DelaunayTriangulation2d()
		{			
			this.list_1 = new List<Point>();
			this.list_2 = new List<Triangle>();
		}

		public bool AddPointToCurrentTriangulation(Point vertexToInsert)
		{
			if (this.class15_0 == null | this.list_0 == null)
			{
				throw new InvalidOperationException("A valid triangulation does not exist. Compute the triangulation first!");
			}
			this.pointSet_0.Add(vertexToInsert);
			this.vmethod_0(vertexToInsert, new DelaunayTriangulation2d.PointInsertionEventArg(this.pointSet_0.Count, this.pointSet_0.Count, false));
			DelaunayTriangulation2d.Class15 @class = this.method_6(this.class15_0, vertexToInsert);
			if (@class.method_2())
			{
				this.list_1.Add(vertexToInsert);
				return false;
			}
			if (@class.method_12().method_18(vertexToInsert))
			{
				this.list_1.Add(vertexToInsert);
				return false;
			}
			if (Predicate.InTriangle2dExact(@class.method_12().getPoint0(), @class.method_12().getPoint1(), @class.method_12().getPoint2(), vertexToInsert) == 0.0)
			{
				DelaunayTriangulation2d.Class15 class2;
				if (Predicate.Orient2d_exact(@class.method_12().getPoint0(), @class.method_12().getPoint1(), vertexToInsert) == 0.0)
				{
					class2 = @class.method_10();
				}
				else if (Predicate.Orient2d_exact(@class.method_12().getPoint1(), @class.method_12().getPoint2(), vertexToInsert) == 0.0)
				{
					class2 = @class.method_6();
				}
				else
				{
					class2 = @class.method_8();
				}
				this.method_5(@class, class2);
				DelaunayTriangulation2d.Class15 class3 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint2(), @class.method_12().getPoint0(), vertexToInsert));
				DelaunayTriangulation2d.Class15 class4 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint1(), @class.method_12().getPoint2(), vertexToInsert));
				DelaunayTriangulation2d.Class15 class5 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_10().method_12().getPoint2(), @class.method_10().method_12().getPoint0(), vertexToInsert));
				DelaunayTriangulation2d.Class15 class6 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_10().method_12().getPoint1(), @class.method_10().method_12().getPoint2(), vertexToInsert));
				class3.method_7(class6);
				class3.method_9(class4);
				class3.method_11(@class.method_8());
				class4.method_7(class3);
				class4.method_9(class5);
				class4.method_11(@class.method_6());
				class5.method_7(class4);
				class5.method_9(class6);
				class5.method_11(class2.method_8());
				class6.method_7(class5);
				class6.method_9(class3);
				class6.method_11(class2.method_6());
				this.method_4(class3, @class.method_8());
				this.method_4(class4, @class.method_6());
				this.method_4(class5, class2.method_8());
				this.method_4(class6, class2.method_6());
				this.method_7(class3, @class);
				this.method_7(class4, @class);
				this.method_7(class5, class2);
				this.method_7(class6, class2);
				this.list_0.Add(class3);
				this.list_0.Add(class4);
				this.list_0.Add(class5);
				this.list_0.Add(class6);
				this.method_2(vertexToInsert, class3, class3.method_10());
				this.method_2(vertexToInsert, class4, class4.method_10());
				this.method_2(vertexToInsert, class5, class5.method_10());
				this.method_2(vertexToInsert, class6, class6.method_10());
			}
			else
			{
				DelaunayTriangulation2d.Class15 class7 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint0(), @class.method_12().getPoint1(), vertexToInsert));
				DelaunayTriangulation2d.Class15 class8 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint1(), @class.method_12().getPoint2(), vertexToInsert));
				DelaunayTriangulation2d.Class15 class9 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint2(), @class.method_12().getPoint0(), vertexToInsert));
				class7.method_7(class8);
				class7.method_9(class9);
				class7.method_11(@class.method_10());
				class8.method_7(class9);
				class8.method_9(class7);
				class8.method_11(@class.method_6());
				class9.method_7(class7);
				class9.method_9(class8);
				class9.method_11(@class.method_8());
				this.method_4(class7, @class.method_10());
				this.method_4(class8, @class.method_6());
				this.method_4(class9, @class.method_8());
				this.method_7(class7, @class);
				this.method_7(class8, @class);
				this.method_7(class9, @class);
				this.list_0.Add(class7);
				this.list_0.Add(class8);
				this.list_0.Add(class9);
				this.method_2(vertexToInsert, class7, class7.method_10());
				this.method_2(vertexToInsert, class8, class8.method_10());
				this.method_2(vertexToInsert, class9, class9.method_10());
			}
			return true;
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		~DelaunayTriangulation2d()
		{
			this.method_0(false);
		}

		public PointSet GenerateRaster(double xSpacing, double ySpacing)
		{
			PointSet pointSet = new PointSet();
			double[] xYExtents = this.GetXYExtents();
			double num = xYExtents[0];
			double num2 = xYExtents[1];
			double num3 = xYExtents[2];
			double num4 = xYExtents[3];
			int num5 = (int)Math.Ceiling((num3 - num) / xSpacing);
			int num6 = (int)Math.Ceiling((num4 - num2) / ySpacing);
			for (int i = 0; i <= num6; i++)
			{
				for (int j = 0; j <= num5; j++)
				{
					double x = num + (double)j * xSpacing;
					double y = num2 + (double)i * ySpacing;
					pointSet.Add(new Point(x, y, 0.0));
				}
			}
			return pointSet;
		}

		public List<Triangle> GetTriangles()
		{
			return this.GetTriangles(false);
		}

		public List<Triangle> GetTriangles(bool throwOnError)
		{
			if (this.class15_0 == null | this.list_0 == null)
			{
				throw new InvalidOperationException("A valid triangulation does not exist. Compute the triangulation first!");
			}
			this.list_2 = new List<Triangle>();
			List<Triangle> list = new List<Triangle>();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				if (this.list_0[i].method_0() && !this.list_0[i].method_12().method_17(this.class24_0))
				{
					Class24 @class = this.list_0[i].method_12();
					try
					{
						Triangle item = new Triangle(@class.getPoint0(), @class.getPoint1(), @class.getPoint2());
						list.Add(item);
					}
					catch(System.Exception ex)
					{
						double absoluteEpsilon = Global.AbsoluteEpsilon;
						double relativeEpsilon = Global.RelativeEpsilon;
						Global.AbsoluteEpsilon = -1.0;
						Global.RelativeEpsilon = -1.0;
						Triangle item2 = new Triangle(@class.getPoint0(), @class.getPoint1(), @class.getPoint2());
						this.list_2.Add(item2);
						Global.AbsoluteEpsilon = absoluteEpsilon;
						Global.RelativeEpsilon = relativeEpsilon;
						if (throwOnError)
						{
							throw new ArithmeticException("Can not convert near-degenerate triangle due to floating point accuracy.");
						}
					}
				}
			}
			return list;
		}

		public double[] GetXYExtents()
		{
			double num = 1.7976931348623157E+308;
			double num2 = 1.7976931348623157E+308;
			double num3 = -1.7976931348623157E+308;
			double num4 = -1.7976931348623157E+308;
			for (int i = 0; i < this.pointSet_0.Count; i++)
			{
				if (num > this.pointSet_0[i].X)
				{
					num = this.pointSet_0[i].X;
				}
				if (num2 > this.pointSet_0[i].Y)
				{
					num2 = this.pointSet_0[i].Y;
				}
				if (num3 < this.pointSet_0[i].X)
				{
					num3 = this.pointSet_0[i].X;
				}
				if (num4 < this.pointSet_0[i].Y)
				{
					num4 = this.pointSet_0[i].Y;
				}
			}
			return new double[]
			{
				num,
				num2,
				num3,
				num4
			};
		}

		public double GetZCoordinate(Point point)
		{
			DelaunayTriangulation2d.Class15 @class = this.method_6(this.class15_0, point);
			if (@class == null)
			{
				return double.NaN;
			}
			if (@class.method_2())
			{
				return double.NaN;
			}
			Point point2 = @class.method_12().getPoint0();
			Point left = @class.method_12().getPoint1();
			Point left2 = @class.method_12().getPoint2();
			Vector3d vector3d = new Vector3d(left - point2);
			Vector3d vector3d2 = new Vector3d(left2 - point2);
			Vector3d vector3d3 = new Vector3d(point - point2);
			double num = vector3d3.X * (vector3d.Y * vector3d2.Z - vector3d.Z * vector3d2.Y);
			double num2 = vector3d3.Y * (vector3d.Z * vector3d2.X - vector3d.X * vector3d2.Z);
			double num3 = vector3d.X * vector3d2.Y - vector3d.Y * vector3d2.X;
			if (Math.Abs(num3) < 4.94065645841247E-324)
			{
				return double.NaN;
			}
			return (-num - num2) / num3 + point2.Z;
		}

		private void method_0(bool bool_1)
		{
			if (this.bool_0)
			{
				return;
			}
			if (bool_1)
			{
				this.class15_0 = null;
				this.list_0 = null;
				this.list_1 = null;
				this.pointSet_0 = null;
			}
			this.bool_0 = true;
		}

		internal Class24 getBoundaryPoint(PointSet pointSet_1)
		{
			double num = pointSet_1[0].X;
			for (int i = 1; i < pointSet_1.Count; i++)
			{
				double num2 = Math.Abs(pointSet_1[i].X);
				double num3 = Math.Abs(pointSet_1[i].Y);
				if (num2 > num)
				{
					num = num2;
				}
				if (num3 > num)
				{
					num = num3;
				}
			}
			Point point_ = new Point(100.0 * num, 0.0, 0.0);
			Point point_2 = new Point(0.0, 100.0 * num, 0.0);
			Point point_3 = new Point(-100.0 * num, -100.0 * num, 0.0);
			return new Class24(point_, point_2, point_3);
		}

		internal bool method_10(Point point_0)
		{
			bool result;
			try
			{
				DelaunayTriangulation2d.Class15 @class = this.method_6(this.class15_0, point_0);
				if (@class.method_12().method_17(this.class24_0))
				{
					result = false;
				}
				else
				{
					result = true;
				}
			}
			catch(System.Exception ex)
			{
				result = false;
			}
			return result;
		}

		internal List<Triangle> method_11(PointSet pointSet_1)
		{
			if (pointSet_1.Count < 3)
			{
				throw new ArgumentException("Can not triangulate less than three vertices");
			}
			pointSet_1.RandomPermute();
			List<Class24> list = new List<Class24>();
			Class24 item = this.getBoundaryPoint(pointSet_1);
			list.Add(item);
			foreach (Point point in pointSet_1)
			{
				List<Edge> list2 = new List<Edge>();
				for (int i = list.Count - 1; i >= 0; i--)
				{
					Point p = list[i].getPoint0();
					Point p2 = list[i].getPoint1();
					Point p3 = list[i].getPoint2();
					if (Predicate.InCircleOrdered(p, p2, p3, point) > 0.0)
					{
						list2.Add(new Edge(list[i].getPoint0(), list[i].getPoint1()));
						list2.Add(new Edge(list[i].getPoint1(), list[i].getPoint2()));
						list2.Add(new Edge(list[i].getPoint2(), list[i].getPoint0()));
						list.RemoveAt(i);
					}
				}
				for (int j = list2.Count - 2; j >= 0; j--)
				{
					for (int k = list2.Count - 1; k >= j + 1; k--)
					{
						if (list2[j] == list2[k])
						{
							list2.RemoveAt(k);
							list2.RemoveAt(j);
							k--;
						}
					}
				}
				foreach (Edge current in list2)
				{
					list.Add(new Class24(current.StartPoint, current.EndPoint, point));
				}
			}
			for (int l = list.Count - 1; l >= 0; l--)
			{
				if (list[l].method_17(item))
				{
					list.RemoveAt(l);
				}
			}
			List<Triangle> list3 = new List<Triangle>();
			foreach (Class24 current2 in list)
			{
				list3.Add(new Triangle(current2.getPoint0(), current2.getPoint1(), current2.getPoint2()));
			}
			return list3;
		}

		private void method_2(Point point_0, DelaunayTriangulation2d.Class15 class15_1, DelaunayTriangulation2d.Class15 class15_2)
		{
			if (class15_2 == null)
			{
				return;
			}
			Point point = this.method_3(class15_1.method_12(), class15_2.method_12());
			if (Predicate.InCircleOrdered(class15_1.method_12().getPoint0(), class15_1.method_12().getPoint1(), class15_1.method_12().getPoint2(), point) > 0.0)
			{
				DelaunayTriangulation2d.Class15 @class = new DelaunayTriangulation2d.Class15(new Class24(class15_1.method_12().getPoint0(), point, point_0));
				DelaunayTriangulation2d.Class15 class2 = new DelaunayTriangulation2d.Class15(new Class24(point, class15_1.method_12().getPoint1(), point_0));
				@class.method_7(class2);
				@class.method_9(class15_1.method_8());
				class2.method_7(class15_1.method_6());
				class2.method_9(@class);
				if (class15_1.method_12().getPoint0().X == class15_2.method_12().getPoint0().X & class15_1.method_12().getPoint0().Y == class15_2.method_12().getPoint0().Y)
				{
					@class.method_11(class15_2.method_10());
					class2.method_11(class15_2.method_6());
				}
				else if (class15_1.method_12().getPoint0().X == class15_2.method_12().getPoint1().X & class15_1.method_12().getPoint0().Y == class15_2.method_12().getPoint1().Y)
				{
					@class.method_11(class15_2.method_6());
					class2.method_11(class15_2.method_8());
				}
				else
				{
					@class.method_11(class15_2.method_8());
					class2.method_11(class15_2.method_10());
				}
				this.method_4(@class, @class.method_8());
				this.method_4(@class, @class.method_10());
				this.method_4(class2, class2.method_6());
				this.method_4(class2, class2.method_10());
				this.method_8(@class, class15_1, class15_2);
				this.method_8(class2, class15_1, class15_2);
				this.list_0.Add(@class);
				this.list_0.Add(class2);
				this.method_2(point_0, @class, @class.method_10());
				this.method_2(point_0, class2, class2.method_10());
			}
		}

		private Point method_3(Class24 class24_1, Class24 class24_2)
		{
			if (!class24_1.method_18(class24_2.getPoint0()))
			{
				return class24_2.getPoint0();
			}
			if (!class24_1.method_18(class24_2.getPoint1()))
			{
				return class24_2.getPoint1();
			}
			return class24_2.getPoint2();
		}

		private void method_4(DelaunayTriangulation2d.Class15 class15_1, DelaunayTriangulation2d.Class15 class15_2)
		{
			if (class15_2 == null)
			{
				return;
			}
			if (!class15_1.method_12().method_18(class15_2.method_12().getPoint0()))
			{
				class15_2.method_7(class15_1);
				return;
			}
			if (!class15_1.method_12().method_18(class15_2.method_12().getPoint1()))
			{
				class15_2.method_9(class15_1);
				return;
			}
			class15_2.method_11(class15_1);
		}

		private void method_5(DelaunayTriangulation2d.Class15 class15_1, DelaunayTriangulation2d.Class15 class15_2)
		{
			if (!class15_2.method_12().method_18(class15_1.method_12().getPoint0()))
			{
				DelaunayTriangulation2d.Class15 @class = new DelaunayTriangulation2d.Class15();
				@class.method_7(class15_1.method_6());
				@class.method_9(class15_1.method_8());
				@class.method_11(class15_1.method_10());
				Class24 class2 = new Class24();
				class2.setPoint2(class15_1.method_12().getPoint0());
				class2.setPoint0(class15_1.method_12().getPoint1());
				class2.setPoint1(class15_1.method_12().getPoint2());
				class15_1.method_13(class2);
				class15_1.method_11(@class.method_6());
				class15_1.method_7(@class.method_8());
				class15_1.method_9(@class.method_10());
			}
			else if (!class15_2.method_12().method_18(class15_1.method_12().getPoint1()))
			{
				DelaunayTriangulation2d.Class15 class3 = new DelaunayTriangulation2d.Class15();
				class3.method_7(class15_1.method_6());
				class3.method_9(class15_1.method_8());
				class3.method_11(class15_1.method_10());
				Class24 class4 = new Class24();
				class4.setPoint1(class15_1.method_12().getPoint0());
				class4.setPoint2(class15_1.method_12().getPoint1());
				class4.setPoint0(class15_1.method_12().getPoint2());
				class15_1.method_13(class4);
				class15_1.method_9(class3.method_6());
				class15_1.method_11(class3.method_8());
				class15_1.method_7(class3.method_10());
			}
			if (!class15_1.method_12().method_18(class15_2.method_12().getPoint0()))
			{
				DelaunayTriangulation2d.Class15 class5 = new DelaunayTriangulation2d.Class15();
				class5.method_7(class15_2.method_6());
				class5.method_9(class15_2.method_8());
				class5.method_11(class15_2.method_10());
				Class24 class6 = new Class24();
				class6.setPoint2(class15_2.method_12().getPoint0());
				class6.setPoint0(class15_2.method_12().getPoint1());
				class6.setPoint1(class15_2.method_12().getPoint2());
				class15_2.method_13(class6);
				class15_2.method_11(class5.method_6());
				class15_2.method_7(class5.method_8());
				class15_2.method_9(class5.method_10());
				return;
			}
			if (!class15_1.method_12().method_18(class15_2.method_12().getPoint1()))
			{
				DelaunayTriangulation2d.Class15 class7 = new DelaunayTriangulation2d.Class15();
				class7.method_7(class15_2.method_6());
				class7.method_9(class15_2.method_8());
				class7.method_11(class15_2.method_10());
				Class24 class8 = new Class24();
				class8.setPoint1(class15_2.method_12().getPoint0());
				class8.setPoint2(class15_2.method_12().getPoint1());
				class8.setPoint0(class15_2.method_12().getPoint2());
				class15_2.method_13(class8);
				class15_2.method_9(class7.method_6());
				class15_2.method_11(class7.method_8());
				class15_2.method_7(class7.method_10());
			}
		}

		internal DelaunayTriangulation2d.Class15 method_6(DelaunayTriangulation2d.Class15 class15_1, Point point_0)
		{
			DelaunayTriangulation2d.Class15 @class = class15_1;
			while (!@class.method_0() & !@class.method_2())
			{
				List<DelaunayTriangulation2d.Class15> list = @class.method_4();
				int count = list.Count;
				bool flag = true;
				int num = 0;
				while (flag)
				{
					if (num >= count)
					{
						@class = new DelaunayTriangulation2d.Class15();
						@class.method_3(true);
						@class.method_1(false);
						flag = false;
					}
					else
					{
						DelaunayTriangulation2d.Class15 class2 = list[num];
						if (Predicate.InTriangle2dExact(class2.method_12().getPoint0(), class2.method_12().getPoint1(), class2.method_12().getPoint2(), point_0) >= 0.0)
						{
							@class = this.method_6(class2, point_0);
							flag = false;
						}
						num++;
					}
				}
			}
			return @class;
		}

		internal void method_7(DelaunayTriangulation2d.Class15 class15_1, DelaunayTriangulation2d.Class15 class15_2)
		{
			class15_2.method_1(false);
			class15_2.method_4().Add(class15_1);
			class15_2.method_7(null);
			class15_2.method_9(null);
			class15_2.method_11(null);
		}

		internal void method_8(DelaunayTriangulation2d.Class15 class15_1, DelaunayTriangulation2d.Class15 class15_2, DelaunayTriangulation2d.Class15 class15_3)
		{
			this.method_7(class15_1, class15_2);
			this.method_7(class15_1, class15_3);
		}

		internal List<DelaunayTriangulation2d.Class15> method_9(Point point_0)
		{
			List<DelaunayTriangulation2d.Class15> list = new List<DelaunayTriangulation2d.Class15>();
			DelaunayTriangulation2d.Class15 @class = this.method_6(this.class15_0, point_0);
			DelaunayTriangulation2d.Class15 class2 = @class;
			bool flag = true;
			while (flag)
			{
				switch (class2.method_12().method_19(point_0))
				{
				case 1:
					class2 = class2.method_10();
					break;
				case 2:
					class2 = class2.method_6();
					break;
				case 3:
					class2 = class2.method_8();
					break;
				default:
					throw new ArithmeticException("Can not find incident triangles at following vertex:\n" + point_0.ToString() + "\nThe vertex is not part of the current triangulation.");
				}
				list.Add(class2);
				if (@class == class2)
				{
					flag = false;
				}
			}
			return list;
		}

		public void RasterizeCurrentTriangulation(double xSpacing, double ySpacing)
		{
			if (this.class15_0 == null | this.list_0 == null)
			{
				throw new InvalidOperationException("A valid triangulation does not exist. Compute the triangulation first!");
			}
			PointSet pointSet = this.GenerateRaster(xSpacing, ySpacing);
			ConvexHull2d convexHull2d = new ConvexHull2d();
			convexHull2d.InitialPoints = this.pointSet_0;
			convexHull2d.ComputeHull();
			for (int i = pointSet.Count - 1; i >= 0; i--)
			{
				if (!convexHull2d.Contains(pointSet[i]))
				{
					pointSet.RemoveAt(i);
				}
			}
			this.RasterizeCurrentTriangulation(pointSet, 0.0);
			double num = 1.001 * Math.Sqrt(xSpacing * xSpacing + ySpacing * ySpacing);
			for (int j = 0; j < this.list_0.Count; j++)
			{
				if (this.list_0[j].method_0() && this.list_0[j].method_12().method_10() > num)
				{
					this.list_0[j].method_1(false);
				}
			}
		}

		public void RasterizeCurrentTriangulation(PointSet raster, double defaultZ)
		{
			if (this.class15_0 == null | this.list_0 == null)
			{
				throw new InvalidOperationException("A valid triangulation does not exist. Compute the triangulation first!");
			}
			ConvexHull2d convexHull2d = new ConvexHull2d();
			convexHull2d.InitialPoints = this.pointSet_0;
			convexHull2d.ComputeHull();
			for (int i = 0; i < raster.Count; i++)
			{
				double zCoordinate = this.GetZCoordinate(raster[i]);
				if (!double.IsNaN(zCoordinate))
				{
					raster[i].Z = zCoordinate;
				}
				else
				{
					raster[i].Z = defaultZ;
				}
				if (!convexHull2d.Contains(raster[i]))
				{
					raster[i].Z = defaultZ;
				}
			}
			this.pointSet_0 = raster;
			this.Triangulate();
		}

		public void Triangulate()
		{
			if (this.pointSet_0 == null)
			{
				throw new InvalidOperationException("No point set to triangulate.");
			}
			if (this.pointSet_0.Count < 3)
			{
				throw new IndexOutOfRangeException("Can not triangulate less than three vertices");
			}
			this.class15_0 = null;
			this.list_0 = new List<DelaunayTriangulation2d.Class15>();
			this.list_1 = new List<Point>();
			this.pointSet_0.RandomPermute();
			if (!Class20.bool_0)
			{
				Class20.smethod_0();
			}
			this.class24_0 = this.getBoundaryPoint(this.pointSet_0);
			this.class15_0 = new DelaunayTriangulation2d.Class15(this.class24_0);
			for (int i = 0; i < this.pointSet_0.Count; i++)
			{
				this.vmethod_0(this.pointSet_0[i], new DelaunayTriangulation2d.PointInsertionEventArg(i, this.pointSet_0.Count, true));
				Point point = this.pointSet_0[i];
				DelaunayTriangulation2d.Class15 @class = this.method_6(this.class15_0, point);
				if (@class.method_2())
				{
					this.list_1.Add(point);
				}
				else if (Predicate.InTriangle2dExact(@class.method_12().getPoint0(), @class.method_12().getPoint1(), @class.method_12().getPoint2(), point) == 0.0)
				{
					DelaunayTriangulation2d.Class15 class2;
					if (Predicate.Orient2d_exact(@class.method_12().getPoint0(), @class.method_12().getPoint1(), point) == 0.0)
					{
						class2 = @class.method_10();
					}
					else if (Predicate.Orient2d_exact(@class.method_12().getPoint1(), @class.method_12().getPoint2(), point) == 0.0)
					{
						class2 = @class.method_6();
					}
					else
					{
						class2 = @class.method_8();
					}
					this.method_5(@class, class2);
					DelaunayTriangulation2d.Class15 class3 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint2(), @class.method_12().getPoint0(), point));
					DelaunayTriangulation2d.Class15 class4 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint1(), @class.method_12().getPoint2(), point));
					DelaunayTriangulation2d.Class15 class5 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_10().method_12().getPoint2(), @class.method_10().method_12().getPoint0(), point));
					DelaunayTriangulation2d.Class15 class6 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_10().method_12().getPoint1(), @class.method_10().method_12().getPoint2(), point));
					class3.method_7(class6);
					class3.method_9(class4);
					class3.method_11(@class.method_8());
					class4.method_7(class3);
					class4.method_9(class5);
					class4.method_11(@class.method_6());
					class5.method_7(class4);
					class5.method_9(class6);
					class5.method_11(class2.method_8());
					class6.method_7(class5);
					class6.method_9(class3);
					class6.method_11(class2.method_6());
					this.method_4(class3, @class.method_8());
					this.method_4(class4, @class.method_6());
					this.method_4(class5, class2.method_8());
					this.method_4(class6, class2.method_6());
					this.method_7(class3, @class);
					this.method_7(class4, @class);
					this.method_7(class5, class2);
					this.method_7(class6, class2);
					this.list_0.Add(class3);
					this.list_0.Add(class4);
					this.list_0.Add(class5);
					this.list_0.Add(class6);
					this.method_2(point, class3, class3.method_10());
					this.method_2(point, class4, class4.method_10());
					this.method_2(point, class5, class5.method_10());
					this.method_2(point, class6, class6.method_10());
				}
				else
				{
					DelaunayTriangulation2d.Class15 class7 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint0(), @class.method_12().getPoint1(), point));
					DelaunayTriangulation2d.Class15 class8 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint1(), @class.method_12().getPoint2(), point));
					DelaunayTriangulation2d.Class15 class9 = new DelaunayTriangulation2d.Class15(new Class24(@class.method_12().getPoint2(), @class.method_12().getPoint0(), point));
					class7.method_7(class8);
					class7.method_9(class9);
					class7.method_11(@class.method_10());
					class8.method_7(class9);
					class8.method_9(class7);
					class8.method_11(@class.method_6());
					class9.method_7(class7);
					class9.method_9(class8);
					class9.method_11(@class.method_8());
					this.method_4(class7, @class.method_10());
					this.method_4(class8, @class.method_6());
					this.method_4(class9, @class.method_8());
					this.method_7(class7, @class);
					this.method_7(class8, @class);
					this.method_7(class9, @class);
					this.list_0.Add(class7);
					this.list_0.Add(class8);
					this.list_0.Add(class9);
					this.method_2(point, class7, class7.method_10());
					this.method_2(point, class8, class8.method_10());
					this.method_2(point, class9, class9.method_10());
				}
			}
		}

		internal virtual void vmethod_0(object sender, DelaunayTriangulation2d.PointInsertionEventArg e)
		{
			PointInsertionEventHandler pointInsertionEventHandler = this.pointInsertionEventHandler_0;
			if (pointInsertionEventHandler != null)
			{
				pointInsertionEventHandler(sender, e);
			}
		}

		public double Area
		{
			get
			{
				if (this.class15_0 == null | this.list_0 == null)
				{
					throw new InvalidOperationException("A valid triangulation does not exist. Compute the triangulation first!");
				}
				double num = 0.0;
				for (int i = 0; i < this.list_0.Count; i++)
				{
					if (this.list_0[i].method_0() && !this.list_0[i].method_12().method_17(this.class24_0))
					{
						num += this.list_0[i].method_12().method_7();
					}
				}
				return num;
			}
		}

		public List<Point> BadPoints
		{
			get
			{
				return this.list_1;
			}
		}

		public List<Triangle> BadTriangles
		{
			get
			{
				return this.list_2;
			}
		}

		public int NumberOfTriangles
		{
			get
			{
				if (this.class15_0 == null | this.list_0 == null)
				{
					throw new InvalidOperationException("A valid triangulation does not exist. Compute the triangulation first!");
				}
				int num = 0;
				for (int i = 0; i < this.list_0.Count; i++)
				{
					if (this.list_0[i].method_0() && !this.list_0[i].method_12().method_17(this.class24_0))
					{
						num++;
					}
				}
				return num;
			}
		}

		public PointSet TriangulationPoints
		{
			get
			{
				return this.pointSet_0;
			}
			set
			{
				this.pointSet_0 = value;
			}
		}

		public event PointInsertionEventHandler PointInsertionHandler
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.pointInsertionEventHandler_0 = (PointInsertionEventHandler)Delegate.Combine(this.pointInsertionEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.pointInsertionEventHandler_0 = (PointInsertionEventHandler)Delegate.Remove(this.pointInsertionEventHandler_0, value);
			}
		}

		private bool bool_0;

		internal DelaunayTriangulation2d.Class15 class15_0;

		internal Class24 class24_0;

		internal List<DelaunayTriangulation2d.Class15> list_0;

		private List<Point> list_1;

		private List<Triangle> list_2;

		private PointInsertionEventHandler pointInsertionEventHandler_0;

		private PointSet pointSet_0;
		internal class Class15
		{
			internal Class15()
			{
				this.bool_0 = true;
				this.list_0 = new List<DelaunayTriangulation2d.Class15>();
			}

			internal Class15(Class24 class24_1)
			{
				this.bool_0 = true;
				this.list_0 = new List<DelaunayTriangulation2d.Class15>();
				this.class24_0 = class24_1;
			}

			internal bool method_0()
			{
				return this.bool_0;
			}

			internal void method_1(bool bool_2)
			{
				this.bool_0 = bool_2;
			}

			internal DelaunayTriangulation2d.Class15 method_10()
			{
				return this.class15_2;
			}

			internal void method_11(DelaunayTriangulation2d.Class15 class15_3)
			{
				this.class15_2 = class15_3;
			}

			internal Class24 method_12()
			{
				return this.class24_0;
			}

			internal void method_13(Class24 class24_1)
			{
				this.class24_0 = class24_1;
			}

			internal bool method_2()
			{
				return this.bool_1;
			}

			internal void method_3(bool bool_2)
			{
				this.bool_1 = bool_2;
			}

			internal List<DelaunayTriangulation2d.Class15> method_4()
			{
				return this.list_0;
			}

			internal void method_5(List<DelaunayTriangulation2d.Class15> value)
			{
				this.list_0 = value;
				this.bool_0 = false;
			}

			internal DelaunayTriangulation2d.Class15 method_6()
			{
				return this.class15_0;
			}

			internal void method_7(DelaunayTriangulation2d.Class15 class15_3)
			{
				this.class15_0 = class15_3;
			}

			internal DelaunayTriangulation2d.Class15 method_8()
			{
				return this.class15_1;
			}

			internal void method_9(DelaunayTriangulation2d.Class15 class15_3)
			{
				this.class15_1 = class15_3;
			}

			private bool bool_0;

			private bool bool_1;

			private DelaunayTriangulation2d.Class15 class15_0;

			private DelaunayTriangulation2d.Class15 class15_1;

			private DelaunayTriangulation2d.Class15 class15_2;

			private Class24 class24_0;

			private List<DelaunayTriangulation2d.Class15> list_0;
		}
		public class PointInsertionEventArg : EventArgs
		{
			public PointInsertionEventArg(int index, int maxIndex, bool isInitialTriangulationPoint)
			{
				this.int_0 = index;
				this.int_1 = maxIndex;
				this.bool_0 = isInitialTriangulationPoint;
			}

			public int Index
			{
				get
				{
					return this.int_0;
				}
			}

			public bool IsInitialTriangulationPoint
			{
				get
				{
					return this.bool_0;
				}
			}

			public int MaxIndex
			{
				get
				{
					return this.int_1;
				}
			}

			private bool bool_0;

			private int int_0;

			private int int_1;
		}
	}
}
