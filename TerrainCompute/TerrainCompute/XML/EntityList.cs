using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TerrainComputeC.XML
{
	//[LicenseProvider(typeof(Class46))]
	public class EntityList
	{
		public EntityList()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(EntityList));
			this.Points = new List<Point>();
			this.Lines = new List<Line>();
			this.Polylines = new List<PolyLine>();
			this.Faces = new List<Face>();
			//base..ctor();
		}

		public int Count
		{
			get
			{
				return this.Points.Count + this.Lines.Count + this.Polylines.Count + this.Faces.Count;
			}
		}

		public List<Face> Faces;

		public List<Line> Lines;

		public List<Point> Points;

		public List<PolyLine> Polylines;
	}
}
