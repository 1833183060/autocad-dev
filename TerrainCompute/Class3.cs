using System;
using System.Collections.Generic;
using System.ComponentModel;
using TerrainComputeC;

//[LicenseProvider(typeof(Class46))]
internal class Class3 : IComparer<IdPoint>
{
	public Class3()
	{
		//System.ComponentModel.LicenseManager.Validate(typeof(Class3));
		//base..ctor();
	}

	int IComparer<IdPoint>.Compare(IdPoint x, IdPoint y)
	{
		if (x.Point.Y != y.Point.Y)
		{
			return x.Point.Y.CompareTo(y.Point.Y);
		}
		if (x.Point.X != y.Point.X)
		{
			return x.Point.X.CompareTo(y.Point.X);
		}
		return x.Point.Z.CompareTo(y.Point.Z);
	}
}
