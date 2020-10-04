using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.BASE
{
	
	public class EdgeVertexList : SortedDictionary<Point, List<Edge>>
	{
		public EdgeVertexList()
		{
           
		}

		public void Add(Edge edge)
		{
			if (base.ContainsKey(edge.StartPoint))
			{
				base[edge.StartPoint].Add(edge);
			}
			else
			{
				List<Edge> list = new List<Edge>();
				list.Add(edge);
				base.Add(edge.StartPoint.DeepCopy(), list);
			}
			if (base.ContainsKey(edge.EndPoint))
			{
				base[edge.EndPoint].Add(edge);
				return;
			}
			List<Edge> list2 = new List<Edge>();
			list2.Add(edge);
			base.Add(edge.EndPoint.DeepCopy(), list2);
		}
	}
}
