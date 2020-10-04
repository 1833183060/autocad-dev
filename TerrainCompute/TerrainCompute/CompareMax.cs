using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class CompareMax : IComparer<IdEdge>
	{
		public CompareMax()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CompareMax));
			//base..ctor();
		}

		int IComparer<IdEdge>.Compare(IdEdge left, IdEdge right)
		{
			if (left.MaxX != right.MaxX)
			{
				return left.MaxX.CompareTo(right.MaxX);
			}
			return left.MaxY.CompareTo(right.MaxY);
		}
	}
}
