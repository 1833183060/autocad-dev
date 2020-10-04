using System;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class Line : Properties
	{
		public Line()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Line));
			////base..ctor();
		}

		public Line(Vertex startVertex, Vertex endVertex)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Line));
			////base..ctor();
			this.StartVertex = startVertex;
			this.EndVertex = endVertex;
		}

		public void SetProperties(string layerName, short colorIndex)
		{
			this.LayerName = layerName;
			this.ColorIndex = colorIndex;
		}

		public Vertex EndVertex;

		public Vertex StartVertex;
	}
}
