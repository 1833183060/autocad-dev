using System;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class18
{
	internal Class18(Class13 class13_0)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class18));
		//base..ctor();
		this.point_0 = class13_0.method_2().method_0();
		this.point_1 = class13_0.method_4().method_0();
		this.point_2 = class13_0.method_6().method_0();
		double x = this.point_0.X;
		double y = this.point_0.Y;
		double z = this.point_0.Z;
		double x2 = this.point_1.X;
		double y2 = this.point_1.Y;
		double z2 = this.point_1.Z;
		double x3 = this.point_2.X;
		double y3 = this.point_2.Y;
		double z3 = this.point_2.Z;
		this.double_0 = x * (y2 * z3 - z2 * y3) + x2 * (z * y3 - y * z3) + x3 * (y * z2 - z * y2);
		this.double_1 = y * (z3 - z2) + y2 * (z - z3) + y3 * (z2 - z);
		this.double_2 = x * (z2 - z3) + x2 * (z3 - z) + x3 * (z - z2);
		this.double_3 = x * (y3 - y2) + x2 * (y - y3) + x3 * (y2 - y);
	}

	internal bool method_0(Point point_3)
	{
		if (Class18.bool_0)
		{
			return Predicate.Orient3d_exact(this.point_0, this.point_1, this.point_2, point_3) < 0.0;
		}
		double num = this.double_0 + point_3.X * this.double_1 + point_3.Y * this.double_2 + point_3.Z * this.double_3;
		return num < 0.0;
	}

	internal static bool bool_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private Point point_0;

	private Point point_1;

	private Point point_2;
}
