using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace Voronoi
{
	//[LicenseProvider(typeof(Class46))]
	public class VoronoiGraph
	{
		public VoronoiGraph()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(VoronoiGraph));
			this.pointSet_0 = new PointSet();
			//base..ctor();
		}

		public VoronoiGraph(PointSet points)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(VoronoiGraph));
			this.pointSet_0 = new PointSet();
			//base..ctor();
			this.pointSet_0 = points;
		}

		public void ComputeDiagram()
		{
			if (this.pointSet_0.Count < 3)
			{
				throw new InvalidOperationException("Can not compute voronoi graph for less than three points.");
			}
			this.list_0 = new List<VoronoiCell>();
			this.delaunayTriangulation2d_0 = new DelaunayTriangulation2d();
			this.delaunayTriangulation2d_0.TriangulationPoints = this.pointSet_0;
			this.delaunayTriangulation2d_0.Triangulate();
			for (int i = 0; i < this.pointSet_0.Count; i++)
			{
				Point point_ = this.pointSet_0[i];
				List<DelaunayTriangulation2d.Class15> list = this.delaunayTriangulation2d_0.method_9(point_);
				VoronoiCell voronoiCell = new VoronoiCell();
				for (int j = 0; j < list.Count; j++)
				{
					voronoiCell.Vertices.Add(list[j].method_12().method_16());
				}
				if (!voronoiCell.IsConvex())
				{
                    throw new System.Exception("Non-convex voronoi cell found.");
				}
				this.list_0.Add(voronoiCell);
			}
			this.list_0.Sort();
		}

		public PointSet Points
		{
			get
			{
				return this.pointSet_0;
			}
			set
			{
				this.pointSet_0 = value;
			}
		}

		public List<VoronoiCell> VoronoiCells
		{
			get
			{
				return this.list_0;
			}
		}

		private DelaunayTriangulation2d delaunayTriangulation2d_0;

		private List<VoronoiCell> list_0;

		private PointSet pointSet_0;
	}
}
