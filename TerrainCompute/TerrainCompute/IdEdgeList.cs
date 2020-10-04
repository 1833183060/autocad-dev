using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class IdEdgeList : SortedDictionary<Edge, IdEdge>
	{
		public IdEdgeList()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(IdEdgeList));
			//base..ctor(new CompareStartEndPoints());
		}

		public new void Add(Edge keyEdge, IdEdge valueEdge)
		{
			if (base.ContainsKey(keyEdge))
			{
				this.FailedAdds++;
				return;
			}
			base.Add(keyEdge, valueEdge);
		}

		public int FailedAdds;
	}
}
