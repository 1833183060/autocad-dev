using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class CompareStartpoint : IComparer<Edge>
	{
		public CompareStartpoint()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CompareStartpoint));
			//base..ctor();
		}

		int IComparer<Edge>.Compare(Edge left, Edge right)
		{
			return left.StartPoint.CompareTo(right.StartPoint);
		}
	}
}
