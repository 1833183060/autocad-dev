using System;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class Face : Properties
	{
		public Face()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Face));
			//////base..ctor();
		}

		public Face(Vertex v1, Vertex v2, Vertex v3, Vertex v4)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Face));
			//////base..ctor();
			this.Vertex1 = v1;
			this.Vertex2 = v2;
			this.Vertex3 = v3;
			this.Vertex4 = v4;
		}

		public void SetProperties(string layerName, short colorIndex)
		{
			this.LayerName = layerName;
			this.ColorIndex = colorIndex;
		}

		public Vertex Vertex1;

		public Vertex Vertex2;

		public Vertex Vertex3;

		public Vertex Vertex4;
	}
}
