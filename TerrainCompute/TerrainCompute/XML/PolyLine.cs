using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	
	[Serializable]
	public class PolyLine : Properties
	{
		public PolyLine()
		{
			
			this.Vertices = new List<Vertex>();
		}

		public PolyLine(List<Vertex> vertices)
		{
			
			this.Vertices = new List<Vertex>();
			
			this.Vertices = vertices;
		}

		public void SetProperties(string layerName, short colorIndex)
		{
			this.LayerName = layerName;
			this.ColorIndex = colorIndex;
		}

		public List<Vertex> Vertices;
	}
}
