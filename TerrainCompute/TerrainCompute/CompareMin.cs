using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class CompareMin : IComparer<IdEdge>
	{
		public CompareMin()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CompareMin));
			//base..ctor();
		}

		int IComparer<IdEdge>.Compare(IdEdge left, IdEdge right)
		{
			if (left.MinX != right.MinX)
			{
				return left.MinX.CompareTo(right.MinX);
			}
			return left.MinY.CompareTo(right.MinY);
		}
	}
}
