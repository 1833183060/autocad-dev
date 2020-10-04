using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class21
{
	internal Class21(ConvexHull3d convexHull3d_0)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class21));
		//base..ctor();
		this.list_0 = new List<Class25>();
		this.list_1 = new List<Class13>();
		this.method_5(convexHull3d_0);
	}

	internal List<Class13> method_0()
	{
		return this.list_1;
	}

	internal void method_1(List<Class13> value)
	{
		this.list_1 = value;
	}

	internal List<Class25> method_2()
	{
		return this.list_0;
	}

	internal void method_3(List<Class25> value)
	{
		this.list_0 = value;
	}

	internal Point method_4()
	{
		PointSet pointSet = new PointSet();
		foreach (Class13 current in this.list_1)
		{
			Triangle triangle = current.method_16();
			pointSet.Add(triangle.Vertex1);
			pointSet.Add(triangle.Vertex2);
			pointSet.Add(triangle.Vertex3);
		}
		return pointSet.Center;
	}

	internal void method_5(ConvexHull3d convexHull3d_0)
	{
		PointSet initialPoints = convexHull3d_0.InitialPoints;
		if (initialPoints == null)
		{
			throw new InvalidOperationException("Can not compute convex hull: no point set defined.");
		}
		if (initialPoints.Count < 4)
		{
			throw new ArgumentException("Can not compute 3d convex hull for less than four points.");
		}
		if (!Class20.bool_0)
		{
			Class20.smethod_0();
		}
		PointSet pointSet = initialPoints.DeepCopy();
		pointSet.RandomPermute();
		Point center = pointSet.Center;
		int[] array = new int[4];
		array[0] = 0;
		Point point = pointSet[array[0]];
		array[1] = 1;
		Point point2 = pointSet[array[1]];
		while (Math.Abs(Predicate.Orient2d_exact(point, point2, center)) < 1E-07 | point2 == point)
		{
			array[1]++;
			if (array[1] > pointSet.Count - 1)
			{
				throw new ArithmeticException("Failed compute 3d convex hull: need at least four non-coplanar points.");
			}
			point2 = pointSet[array[1]];
		}
		array[2] = 1;
		Point point3 = pointSet[array[2]];
		while (Predicate.Orient3d_exact(point, point2, point3, center) < 1E-06 | point3 == point | point3 == point2)
		{
			array[2]++;
			if (array[2] > pointSet.Count - 1)
			{
				throw new ArithmeticException("Failed compute 3d convex hull: need at least four non-coplanar points.");
			}
			point3 = pointSet[array[2]];
		}
		array[3] = 1;
		Point point4 = pointSet[array[3]];
		while (Predicate.Orient3d_exact(point, point2, point3, point4) < 1E-06 | point4 == point | point4 == point2 | point4 == point3)
		{
			array[3]++;
			if (array[3] > pointSet.Count - 1)
			{
				throw new ArithmeticException("Failed compute 3d convex hull: need at least four non-coplanar points.");
			}
			point4 = pointSet[array[3]];
		}
		List<int> list = new List<int>();
		list.AddRange(array);
		list.Sort();
		pointSet.RemoveAt(list[3]);
		pointSet.RemoveAt(list[2]);
		pointSet.RemoveAt(list[1]);
		pointSet.RemoveAt(list[0]);
		Class25 @class = new Class25(point);
		Class25 class2 = new Class25(point2);
		Class25 class3 = new Class25(point3);
		Class25 class4 = new Class25(point4);
		@class.method_5(true);
		class2.method_5(true);
		class3.method_5(true);
		class4.method_5(true);
		this.list_1.Add(new Class13(@class, class2, class3));
		this.list_1.Add(new Class13(@class, class4, class2));
		this.list_1.Add(new Class13(@class, class3, class4));
		this.list_1.Add(new Class13(class3, class2, class4));
		this.list_1[0].method_8()[0] = this.list_1[3];
		this.list_1[0].method_8()[1] = this.list_1[2];
		this.list_1[0].method_8()[2] = this.list_1[1];
		this.list_1[1].method_8()[0] = this.list_1[3];
		this.list_1[1].method_8()[1] = this.list_1[0];
		this.list_1[1].method_8()[2] = this.list_1[2];
		this.list_1[2].method_8()[0] = this.list_1[3];
		this.list_1[2].method_8()[1] = this.list_1[1];
		this.list_1[2].method_8()[2] = this.list_1[0];
		this.list_1[3].method_8()[0] = this.list_1[1];
		this.list_1[3].method_8()[1] = this.list_1[2];
		this.list_1[3].method_8()[2] = this.list_1[0];
		for (int i = 0; i < pointSet.Count; i++)
		{
			this.list_0.Add(new Class25(pointSet[i]));
		}
		this.list_0.Add(@class);
		this.list_0.Add(class2);
		this.list_0.Add(class3);
		this.list_0.Add(class4);
		for (int j = 0; j < this.list_0.Count; j++)
		{
			convexHull3d_0.vmethod_0(null, null);
			for (int k = 0; k < this.list_1.Count; k++)
			{
				if (this.list_1[k].method_15(this.list_0[j]))
				{
					this.list_1[k].method_10().Add(this.list_0[j]);
					this.list_0[j].method_2().Add(this.list_1[k]);
				}
			}
		}
	}

	internal void method_6(Class25 class25_0)
	{
		for (int i = 0; i < class25_0.method_2().Count; i++)
		{
			for (int j = class25_0.method_2()[i].method_10().Count - 1; j >= 0; j--)
			{
				if (class25_0.method_2()[i].method_10()[j] != class25_0)
				{
					class25_0.method_2()[i].method_10()[j].method_2().Remove(class25_0.method_2()[i]);
				}
			}
		}
		for (int k = class25_0.method_2().Count - 1; k >= 0; k--)
		{
			this.list_1.Remove(class25_0.method_2()[k]);
		}
		this.list_0.Remove(class25_0);
	}

	internal List<Class23> method_7(Class25 class25_0)
	{
		List<Class23> list = new List<Class23>();
		for (int i = 0; i < class25_0.method_2().Count; i++)
		{
			if (class25_0.method_2()[i].method_0())
			{
				class25_0.method_2()[i].method_2().method_5(false);
				class25_0.method_2()[i].method_4().method_5(false);
				class25_0.method_2()[i].method_6().method_5(false);
				if (!class25_0.method_2()[i].method_8()[0].method_15(class25_0))
				{
					list.Add(class25_0.method_2()[i].method_12());
				}
				if (!class25_0.method_2()[i].method_8()[1].method_15(class25_0))
				{
					list.Add(class25_0.method_2()[i].method_13());
				}
				if (!class25_0.method_2()[i].method_8()[2].method_15(class25_0))
				{
					list.Add(class25_0.method_2()[i].method_14());
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		List<Class23> list2 = new List<Class23>();
		int count = list.Count;
		list2.Add(list[0]);
		list.RemoveAt(0);
		int j = 0;
		IL_19F:
		while (j < count - 1)
		{
			for (int k = list.Count - 1; k >= 0; k--)
			{
				if (list[k].method_0() == list2[list2.Count - 1].method_2())
				{
					list2.Add(list[k]);
					list.RemoveAt(k);
					IL_199_:
					j++;
					goto IL_19F;
				}
			}
			goto IL_199;
        IL_199: 
            j++;
            goto IL_19F;
		}
		for (int l = 0; l < list2.Count; l++)
		{
			list2[l].method_0().method_5(true);
			list2[l].method_2().method_5(true);
		}
		class25_0.method_5(true);
		return list2;
	}

	private Class13 method_8(Point point_0, Point point_1, Point point_2, Point point_3)
	{
		Class25 @class = new Class25(point_0);
		Class25 class2 = new Class25(point_1);
		Class25 class25_ = new Class25(point_2);
		if (Predicate.Orient3d(point_0, point_1, point_2, point_3) > 0.0)
		{
			return new Class13(@class, class2, class25_);
		}
		return new Class13(class2, @class, class25_);
	}

	private List<Class25> list_0;

	private List<Class13> list_1;
}
