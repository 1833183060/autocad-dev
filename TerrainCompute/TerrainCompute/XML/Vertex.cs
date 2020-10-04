using System;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	
	[Serializable]
	public class Vertex
	{
		public Vertex()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Vertex));
			//base..ctor();
		}

		public Vertex(double x, double y, double z)
		{
			
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public double X;

		public double Y;

		public double Z;
	}
}
