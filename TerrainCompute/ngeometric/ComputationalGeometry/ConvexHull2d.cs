using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class ConvexHull2d
	{
		public ConvexHull2d()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(ConvexHull2d));
			//base..ctor();
		}

		public void ComputeHull()
		{
			if (this.pointSet_0 == null)
			{
				throw new InvalidOperationException("Can not compute convex hull: no point set defined.");
			}
			if (this.pointSet_0.Count < 3)
			{
				throw new IndexOutOfRangeException("Can not compute 2d convex hull for less than three points.");
			}
			if (!Class20.bool_0)
			{
				Class20.smethod_0();
			}
			this.pointSet_0.Sort(PointSet.SortOrder.XYZ);
			List<Point> list = new List<Point>();
			list.Add(this.pointSet_0[0]);
			list.Add(this.pointSet_0[1]);
			for (int i = 2; i < this.pointSet_0.Count; i++)
			{
				list.Add(this.pointSet_0[i]);
				int num = list.Count;
				while (num > 2 && this.method_1(list[num - 3], list[num - 2], list[num - 1]))
				{
					list.RemoveAt(num - 2);
					num--;
				}
			}
			List<Point> list2 = new List<Point>();
			list2.Add(this.pointSet_0[this.pointSet_0.Count - 1]);
			list2.Add(this.pointSet_0[this.pointSet_0.Count - 2]);
			for (int j = this.pointSet_0.Count - 3; j >= 0; j--)
			{
				list2.Add(this.pointSet_0[j]);
				int num2 = list2.Count;
				while (num2 > 2 && this.method_1(list2[num2 - 3], list2[num2 - 2], list2[num2 - 1]))
				{
					list2.RemoveAt(num2 - 2);
					num2--;
				}
			}
			list2.RemoveAt(0);
			list2.RemoveAt(list2.Count - 1);
			this.pointSet_1 = new PointSet();
			for (int k = 0; k < list.Count; k++)
			{
				this.pointSet_1.Add(list[k]);
			}
			for (int l = 0; l < list2.Count; l++)
			{
				this.pointSet_1.Add(list2[l]);
			}
			this.method_2();
		}

		public bool Contains(Point point)
		{
			if (this.pointSet_1 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			if (this.pointSet_1.Count == 2 && this.pointSet_1[0] == this.pointSet_1[1])
			{
				return point == this.pointSet_1[0];
			}
			for (int i = 0; i < this.pointSet_1.Count - 1; i++)
			{
				if (Predicate.Orient2d_exact(this.pointSet_1[i], this.pointSet_1[i + 1], point) > 0.0)
				{
					return false;
				}
			}
			return Predicate.Orient2d_exact(this.pointSet_1[this.pointSet_1.Count - 1], this.pointSet_1[0], point) <= 0.0;
		}

		public bool ContainsOncircumference(Point point, bool useExactArithmetic)
		{
			for (int i = 0; i < this.pointSet_1.Count; i++)
			{
				int num = i + 1;
				if (num == this.pointSet_1.Count)
				{
					num = 0;
				}
				Point point2 = this.pointSet_1[i];
				Point point3 = this.pointSet_1[num];
				if (Math.Min(point2.X, point3.X) <= point.X && Math.Max(point2.X, point3.X) >= point.X && Math.Min(point2.Y, point3.Y) <= point.Y && Math.Max(point2.Y, point3.Y) >= point.Y)
				{
					if (useExactArithmetic)
					{
						if (Global.AlmostEquals(Predicate.Orient2d(point2, point3, point), 0.0))
						{
							return true;
						}
					}
					else if (Predicate.Orient2d_exact(point2, point3, point) == 0.0)
					{
						return true;
					}
				}
			}
			return false;
		}

		public Edge Diameter()
		{
			Class22 @class = new Class22(this);
			return @class.method_4();
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		~ConvexHull2d()
		{
			this.method_0(false);
		}

		public BoundingRectangle FitsInto(BoundingRectangle container)
		{
			Class22 @class = new Class22(this);
			return @class.method_7(container);
		}

		public Edge MaximumWidth()
		{
			Class22 @class = new Class22(this);
			return @class.method_5();
		}

		private void method_0(bool bool_1)
		{
			if (this.bool_0)
			{
				return;
			}
			if (bool_1)
			{
				this.pointSet_0 = null;
				this.pointSet_1.Dispose();
			}
			this.bool_0 = true;
		}

		private bool method_1(Point point_0, Point point_1, Point point_2)
		{
			return Predicate.Orient2d_exact(point_0, point_1, point_2) >= 0.0;
		}

		private void method_2()
		{
			if (this.pointSet_1.Count < 3)
			{
				this.double_0 = 0.0;
			}
			Point center = this.pointSet_1.Center;
			this.list_0 = new List<Edge>();
			Class24 @class;
			for (int i = 0; i < this.pointSet_1.Count - 1; i++)
			{
				this.list_0.Add(new Edge(this.pointSet_1[i], this.pointSet_1[i + 1]));
				@class = new Class24(this.pointSet_1[i], this.pointSet_1[i + 1], center);
				this.double_0 += @class.method_11();
			}
			this.list_0.Add(new Edge(this.pointSet_1[this.pointSet_1.Count - 1], this.pointSet_1[0]));
			@class = new Class24(this.pointSet_1[this.pointSet_1.Count - 1], this.pointSet_1[0], center);
			this.double_0 += @class.method_11();
		}

		public BoundingRectangle MinimumAreaEnclosingRectangle()
		{
			Class22 @class = new Class22(this);
			return @class.method_2();
		}

		public BoundingRectangle MinimumPerimeterEnclosingRectangle()
		{
			Class22 @class = new Class22(this);
			return @class.method_3();
		}

		public Edge MinimumWidth()
		{
			Class22 @class = new Class22(this);
			return @class.method_6();
		}

		public double AreaXY
		{
			get
			{
				if (this.pointSet_1 == null)
				{
					throw new InvalidOperationException("The hull has not been computed yet.");
				}
				return this.double_0;
			}
		}

		public List<Edge> Edges
		{
			get
			{
				if (this.pointSet_1 == null)
				{
					throw new InvalidOperationException("The hull has not been computed yet.");
				}
				return this.list_0;
			}
		}

		public PointSet InitialPoints
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

		public double PerimeterLength
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < this.pointSet_1.Count - 1; i++)
				{
					num += this.pointSet_1[i].DistanceTo(this.pointSet_1[i + 1]);
				}
				return num + this.pointSet_1[this.pointSet_1.Count - 1].DistanceTo(this.pointSet_1[0]);
			}
		}

		public PointSet Vertices
		{
			get
			{
				if (this.pointSet_1 == null)
				{
					throw new InvalidOperationException("The hull has not been computed yet.");
				}
				return this.pointSet_1;
			}
		}

		private bool bool_0;

		private double double_0;

		private List<Edge> list_0;

		private PointSet pointSet_0;

		private PointSet pointSet_1;
	}
}
