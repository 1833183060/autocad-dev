using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class12
{
	public Class12()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class12));
		//base..ctor();
	}

	internal static double smethod_0(double double_0)
	{
		return Class12.point_0.DistanceTo(Class12.ellipse_0.GetPointAtParameter(double_0));
	}

	internal static Ellipse ellipse_0;

	internal static Point point_0;
}
