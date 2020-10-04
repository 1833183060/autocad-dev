using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class11
{
	internal Class11()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class11));
		//base..ctor();
	}

	internal Class11 method_0()
	{
		return new Class11
		{
			double_0 = this.double_0,
			double_1 = this.double_1,
			double_2 = this.double_2,
			double_3 = this.double_3,
			double_4 = this.double_4,
			double_5 = this.double_5,
			double_6 = this.double_6,
			double_7 = this.double_7,
			double_8 = this.double_8,
			double_9 = this.double_9,
			double_10 = this.double_10,
			double_11 = this.double_11,
			double_12 = this.double_12,
			double_13 = this.double_13,
			double_14 = this.double_14,
			double_15 = this.double_15
		};
	}

	internal void method_1(int int_0, double double_16, double double_17, double double_18, double double_19)
	{
		if (int_0 == 0)
		{
			this.double_0 = double_16;
			this.double_1 = double_17;
			this.double_2 = double_18;
			this.double_3 = double_19;
			return;
		}
		if (int_0 == 1)
		{
			this.double_4 = double_16;
			this.double_5 = double_17;
			this.double_6 = double_18;
			this.double_7 = double_19;
			return;
		}
		if (int_0 == 2)
		{
			this.double_8 = double_16;
			this.double_9 = double_17;
			this.double_10 = double_18;
			this.double_11 = double_19;
			return;
		}
		if (int_0 == 3)
		{
			this.double_12 = double_16;
			this.double_13 = double_17;
			this.double_14 = double_18;
			this.double_15 = double_19;
			return;
		}
		throw new IndexOutOfRangeException("Row index " + int_0 + " is not feasible. Must be 0, 1, 2, or 3");
	}

	internal void method_2(int int_0, double double_16, double double_17, double double_18, double double_19)
	{
		if (int_0 == 0)
		{
			this.double_0 = double_16;
			this.double_4 = double_17;
			this.double_8 = double_18;
			this.double_12 = double_19;
			return;
		}
		if (int_0 == 1)
		{
			this.double_1 = double_16;
			this.double_5 = double_17;
			this.double_9 = double_18;
			this.double_13 = double_19;
			return;
		}
		if (int_0 == 2)
		{
			this.double_2 = double_16;
			this.double_6 = double_17;
			this.double_10 = double_18;
			this.double_14 = double_19;
			return;
		}
		if (int_0 == 3)
		{
			this.double_3 = double_16;
			this.double_7 = double_17;
			this.double_11 = double_18;
			this.double_15 = double_19;
			return;
		}
		throw new IndexOutOfRangeException("Column index " + int_0 + " is not feasible. Must be 0, 1, 2, or 3");
	}

	internal double method_3()
	{
		Matrix3d matrix3d = new Matrix3d();
		matrix3d.a00 = this.double_5;
		matrix3d.a01 = this.double_6;
		matrix3d.a02 = this.double_7;
		matrix3d.a10 = this.double_9;
		matrix3d.a11 = this.double_10;
		matrix3d.a12 = this.double_11;
		matrix3d.a20 = this.double_13;
		matrix3d.a21 = this.double_14;
		matrix3d.a22 = this.double_15;
		double num = this.double_0 * matrix3d.Determinant;
		matrix3d.a00 = this.double_1;
		matrix3d.a01 = this.double_2;
		matrix3d.a02 = this.double_3;
		double num2 = this.double_4 * matrix3d.Determinant;
		matrix3d.a10 = this.double_5;
		matrix3d.a11 = this.double_6;
		matrix3d.a12 = this.double_7;
		double num3 = this.double_8 * matrix3d.Determinant;
		matrix3d.a20 = this.double_9;
		matrix3d.a21 = this.double_10;
		matrix3d.a22 = this.double_11;
		double num4 = this.double_12 * matrix3d.Determinant;
		return num - num2 + num3 - num4;
	}

	internal static double[] smethod_0(Class11 class11_0, double[] double_16)
	{
		Class11 @class = class11_0.method_0();
		double num = @class.method_3();
		if (Math.Abs(num) < 4.94065645841247E-324)
		{
			throw new ArithmeticException("Can not solve [4x4]-system: system has zero determinant!");
		}
		double num2 = 1.0 / num;
		@class.method_2(0, double_16[0], double_16[1], double_16[2], double_16[3]);
		double num3 = @class.method_3();
		@class = class11_0.method_0();
		@class.method_2(1, double_16[0], double_16[1], double_16[2], double_16[3]);
		double num4 = @class.method_3();
		@class = class11_0.method_0();
		@class.method_2(2, double_16[0], double_16[1], double_16[2], double_16[3]);
		double num5 = @class.method_3();
		@class = class11_0.method_0();
		@class.method_2(3, double_16[0], double_16[1], double_16[2], double_16[3]);
		double num6 = @class.method_3();
		return new double[]
		{
			num2 * num3,
			num2 * num4,
			num2 * num5,
			num2 * num6
		};
	}

	internal static CoordinateSystem smethod_1(Point point_0, Point point_1, Point point_2, Point point_3, Point point_4, Point point_5, Point point_6, Point point_7)
	{
		CoordinateSystem coordinateSystem = new CoordinateSystem();
		Class11 @class = new Class11();
		@class.method_1(0, point_0.X, point_0.Y, point_0.Z, 1.0);
		@class.method_1(1, point_1.X, point_1.Y, point_1.Z, 1.0);
		@class.method_1(2, point_2.X, point_2.Y, point_2.Z, 1.0);
		@class.method_1(3, point_3.X, point_3.Y, point_3.Z, 1.0);
		if (Math.Abs(@class.method_3()) < 4.94065645841247E-324)
		{
			throw new ArithmeticException("Can not compute transformation: points are coplanar!");
		}
		double[] double_ = new double[]
		{
			point_4.X,
			point_5.X,
			point_6.X,
			point_7.X
		};
		double[] double_2 = new double[]
		{
			point_4.Y,
			point_5.Y,
			point_6.Y,
			point_7.Y
		};
		double[] double_3 = new double[]
		{
			point_4.Z,
			point_5.Z,
			point_6.Z,
			point_7.Z
		};
		double[] array = Class11.smethod_0(@class, double_);
		double[] array2 = Class11.smethod_0(@class, double_2);
		double[] array3 = Class11.smethod_0(@class, double_3);
		Matrix3d matrix3d = new Matrix3d();
		matrix3d.SetRow(0, new Vector3d(array[0], array[1], array[2]));
		matrix3d.SetRow(1, new Vector3d(array2[0], array2[1], array2[2]));
		matrix3d.SetRow(2, new Vector3d(array3[0], array3[1], array3[2]));
		coordinateSystem.BasisVectorMatrix = matrix3d;
		coordinateSystem.Origin = new Point(array[3], array2[3], array3[3]);
		return coordinateSystem;
	}

	internal double double_0;

	internal double double_1;

	internal double double_10;

	internal double double_11;

	internal double double_12;

	internal double double_13;

	internal double double_14;

	internal double double_15;

	internal double double_2;

	internal double double_3;

	internal double double_4;

	internal double double_5;

	internal double double_6;

	internal double double_7;

	internal double double_8;

	internal double double_9;
}
