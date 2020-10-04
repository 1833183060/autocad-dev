using System;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class Point : Properties
	{
		public Point()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Point));
			////base..ctor();
		}

		public Point(double x, double y, double z)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Point));
			////base..ctor();
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public void SetProperties(string layerName, short colorIndex)
		{
			this.LayerName = layerName;
			this.ColorIndex = colorIndex;
		}

		public double X;

		public double Y;

		public double Z;
	}
}
