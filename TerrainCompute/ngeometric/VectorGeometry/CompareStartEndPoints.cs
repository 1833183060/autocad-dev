using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class CompareStartEndPoints : IComparer<Edge>
	{
		public CompareStartEndPoints()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CompareStartEndPoints));
			//base..ctor();
		}

		int IComparer<Edge>.Compare(Edge left, Edge right)
		{
			left.SwapSort();
			right.SwapSort();
			if (left.StartPoint.X != right.StartPoint.X)
			{
				return left.StartPoint.X.CompareTo(right.StartPoint.X);
			}
			if (left.StartPoint.Y != right.StartPoint.Y)
			{
				return left.StartPoint.Y.CompareTo(right.StartPoint.Y);
			}
			if (left.StartPoint.Z != right.StartPoint.Z)
			{
				return left.StartPoint.Z.CompareTo(right.StartPoint.Z);
			}
			if (left.EndPoint.X != right.EndPoint.X)
			{
				return left.EndPoint.X.CompareTo(right.EndPoint.X);
			}
			if (left.EndPoint.Y != right.EndPoint.Y)
			{
				return left.EndPoint.Y.CompareTo(right.EndPoint.Y);
			}
			return left.EndPoint.Z.CompareTo(right.EndPoint.Z);
		}
	}
}
