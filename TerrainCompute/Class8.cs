using System;
using System.Collections;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class8 : IComparer
{
	public Class8()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class8));
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
		if (point.Z != point2.Z)
		{
			return point.Z.CompareTo(point2.Z);
		}
		return point.X.CompareTo(point2.X);
	}
}
