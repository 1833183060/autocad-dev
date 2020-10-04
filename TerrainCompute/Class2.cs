using System;
using System.Collections.Generic;
using System.ComponentModel;
using TerrainComputeC;

//[LicenseProvider(typeof(Class46))]
internal class Class2 : IComparer<IdPoint>
{
	public Class2()
	{
		//System.ComponentModel.LicenseManager.Validate(typeof(Class2));
		//base..ctor();
	}

	int IComparer<IdPoint>.Compare(IdPoint x, IdPoint y)
	{
		if (x.Point.X != y.Point.X)
		{
			return x.Point.X.CompareTo(y.Point.X);
		}
		if (x.Point.Y != y.Point.Y)
		{
			return x.Point.Y.CompareTo(y.Point.Y);
		}
		return x.Point.Z.CompareTo(y.Point.Z);
	}
}
