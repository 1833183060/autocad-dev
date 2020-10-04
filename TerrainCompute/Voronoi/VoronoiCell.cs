using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace Voronoi
{
	
	public class VoronoiCell : IComparable<VoronoiCell>
	{
		public VoronoiCell()
		{
			
			this.list_0 = new List<Point>();
			
		}

		public VoronoiCell(Point center, List<Point> vertices)
		{
			
			this.list_0 = new List<Point>();
			
			this.point_0 = center;
			this.list_0 = vertices;
		}

		public int CompareTo(VoronoiCell vc)
		{
			if (this.point_0.X != vc.point_0.X)
			{
				return this.point_0.X.CompareTo(vc.point_0.X);
			}
			if (this.point_0.Y != vc.point_0.Y)
			{
				return this.point_0.Y.CompareTo(vc.point_0.Y);
			}
			return this.point_0.Z.CompareTo(vc.point_0.Z);
		}

		public List<Edge> GetEdges()
		{
			if (this.list_0.Count < 3)
			{
				throw new InvalidOperationException("Voronoi cell contains less than three vertices.");
			}
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < this.list_0.Count - 1; i++)
			{
				Edge item = new Edge(this.list_0[i], this.list_0[i + 1]);
				list.Add(item);
			}
			list.Add(new Edge(this.list_0[this.list_0.Count - 1], this.list_0[0]));
			return list;
		}

		public bool IsConvex()
		{
			int count = this.list_0.Count;
			if (count < 3)
			{
				throw new InvalidOperationException("Voronoi cell contains less than three vertices.");
			}
			for (int i = 0; i < this.Vertices.Count - 2; i++)
			{
				if (this.method_0(this.list_0[i], this.list_0[i + 1], this.list_0[i + 2]))
				{
					return false;
				}
			}
			return !this.method_0(this.list_0[count - 2], this.list_0[count - 1], this.list_0[0]) && !this.method_0(this.list_0[count - 1], this.list_0[0], this.list_0[1]);
		}

		private bool method_0(Point point_1, Point point_2, Point point_3)
		{
			return Predicate.Orient2d_exact(point_1, point_2, point_3) >= 0.0;
		}

		public Point Center
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
			}
		}

		public bool IsConstrained
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public bool IsOpen
		{
			get
			{
				return this.bool_1;
			}
		}

		public List<Point> Vertices
		{
			get
			{
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
			}
		}

		private bool bool_0;

		private bool bool_1;

		private List<Point> list_0;

		private Point point_0;
	}
}
