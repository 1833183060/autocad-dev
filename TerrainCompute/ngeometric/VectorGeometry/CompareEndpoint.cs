using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	
	public class CompareEndpoint : IComparer<Edge>
	{
		public CompareEndpoint()
		{
            
		}

		int IComparer<Edge>.Compare(Edge left, Edge right)
		{
			return left.EndPoint.CompareTo(right.EndPoint);
		}
	}
}
