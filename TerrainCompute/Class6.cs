using System;
using System.Collections;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class6 : IComparer
{
	public Class6()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class6));
		//base..ctor();
	}

	int IComparer.Compare(object x, object y)
	{
		Point point = (Point)x;
		Point point2 = (Point)y;
		if (point.X != point2.X)
		{
			return point.X.CompareTo(point2.X);
		}
		if (point.Z != point2.Z)
		{
			return point.Z.CompareTo(point2.Z);
		}
		return point.Y.CompareTo(point2.Y);
	}
}
