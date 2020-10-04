using System;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public abstract class Properties
	{
		protected Properties()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(Properties));
			this.LayerName = "";
			this.ColorIndex = 256;
			//////base..ctor();
		}

		public short ColorIndex;

		public string LayerName;
	}
}
