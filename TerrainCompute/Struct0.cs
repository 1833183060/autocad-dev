using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

////[LicenseProvider(typeof(Class46))]
internal struct Struct0
{
	internal Struct0(Point point_4, Point point_5, Point point_6, Point point_7)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Struct0));
		this.point_0 = point_4;
		this.point_1 = point_5;
		this.point_2 = point_6;
		this.point_3 = point_7;
	}

	internal Point method_0()
	{
		return this.point_0;
	}

	internal void method_1(Point point_4)
	{
		this.point_0 = point_4;
	}

	internal Point method_2()
	{
		return this.point_1;
	}

	internal void method_3(Point point_4)
	{
		this.point_1 = point_4;
	}

	internal Point method_4()
	{
		return this.point_2;
	}

	internal void method_5(Point point_4)
	{
		this.point_2 = point_4;
	}

	internal Point method_6()
	{
		return this.point_3;
	}

	internal void method_7(Point point_4)
	{
		this.point_3 = point_4;
	}

	internal double method_8()
	{
		Vector3d a = new Vector3d(this.point_0 - this.point_3);
		Vector3d b = new Vector3d(this.point_1 - this.point_3);
		Vector3d c = new Vector3d(this.point_2 - this.point_3);
		return Math.Abs(Vector3d.Triple(a, b, c) / 6.0);
	}

	internal Point method_9()
	{
		double num = this.point_0.X + this.point_1.X + this.point_2.X + this.point_3.X;
		double num2 = this.point_0.Y + this.point_1.Y + this.point_2.Y + this.point_3.Y;
		double num3 = this.point_0.Z + this.point_1.Z + this.point_2.Z + this.point_3.Z;
		return new Point(0.25 * num, 0.25 * num2, 0.25 * num3);
	}

	internal Point point_0;

	internal Point point_1;

	internal Point point_2;

	internal Point point_3;
}
