using System;
using System.Collections.Generic;
using System.ComponentModel;
using TerrainComputeC;

//[LicenseProvider(typeof(Class46))]
internal class Class4 : IComparer<IdPoint>
{
	public Class4()
	{
		//System.ComponentModel.LicenseManager.Validate(typeof(Class4));
		//base..ctor();
	}

	int IComparer<IdPoint>.Compare(IdPoint x, IdPoint y)
	{
		if (x.Point.Z != y.Point.Z)
		{
			return x.Point.Z.CompareTo(y.Point.Z);
		}
		if (x.Point.X != y.Point.X)
		{
			return x.Point.X.CompareTo(y.Point.X);
		}
		return x.Point.Y.CompareTo(y.Point.Y);
	}
}
