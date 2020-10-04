using System;
using System.Collections;
using System.ComponentModel;
using ngeometry.VectorGeometry;

internal class PointComparer1 : IComparer
{
	public PointComparer1()
	{       
	}

	int IComparer.Compare(object x, object y)
	{
		Point point = (Point)x;
		Point point2 = (Point)y;
		if (point.X != point2.X)
		{
			return point.X.CompareTo(point2.X);
		}
		if (point.Y != point2.Y)
		{
			return point.Y.CompareTo(point2.Y);
		}
		return point.Z.CompareTo(point2.Z);
	}
}
