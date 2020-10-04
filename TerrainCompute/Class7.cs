using System;
using System.Collections;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class7 : IComparer
{
	public Class7()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class7));
		//base..ctor();
	}

	int IComparer.Compare(object x, object y)
	{
		Point point = (Point)x;
		Point point2 = (Point)y;
		if (point.Y != point2.Y)
		{
			return point.Y.CompareTo(point2.Y);
		}
		if (point.X != point2.X)
		{
			return point.X.CompareTo(point2.X);
		}
		return point.Z.CompareTo(point2.Z);
	}
}
