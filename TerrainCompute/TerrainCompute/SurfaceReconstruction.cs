using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class SurfaceReconstruction
	{
		public SurfaceReconstruction(List<Edge> edges)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(SurfaceReconstruction));
			this.Vertices = new List<Point>();
			this.Tris = new List<SurfaceReconstruction.Tri>();
			this.Quads = new List<SurfaceReconstruction.Quad>();
			//base..ctor();
			this.Edges = edges;
		}

		public Face GetAcadFace(SurfaceReconstruction.Tri tri)
		{
			Point3d point3d=new Point3d(this.Vertices[tri.Vertex1].X, this.Vertices[tri.Vertex1].Y, this.Vertices[tri.Vertex1].Z);
			Point3d point3d2=new Point3d(this.Vertices[tri.Vertex2].X, this.Vertices[tri.Vertex2].Y, this.Vertices[tri.Vertex2].Z);
			Point3d point3d3=new Point3d(this.Vertices[tri.Vertex3].X, this.Vertices[tri.Vertex3].Y, this.Vertices[tri.Vertex3].Z);
			return new Face(point3d, point3d2, point3d3, point3d3, true, true, true, true);
		}

		public Face GetAcadFace(SurfaceReconstruction.Quad quad)
		{
			Point3d point3d=new Point3d(this.Vertices[quad.Vertex1].X, this.Vertices[quad.Vertex1].Y, this.Vertices[quad.Vertex1].Z);
			Point3d point3d2=new Point3d(this.Vertices[quad.Vertex2].X, this.Vertices[quad.Vertex2].Y, this.Vertices[quad.Vertex2].Z);
			Point3d point3d3=new Point3d(this.Vertices[quad.Vertex3].X, this.Vertices[quad.Vertex3].Y, this.Vertices[quad.Vertex3].Z);
			Point3d point3d4=new Point3d(this.Vertices[quad.Vertex4].X, this.Vertices[quad.Vertex4].Y, this.Vertices[quad.Vertex4].Z);
			return new Face(point3d, point3d2, point3d3, point3d4, true, true, true, true);
		}

		public void ReconstructSurface(ProgressMeter pm, int relevantDecimals)
		{
			Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			PointSet pointSet = new PointSet();
			for (int i = 0; i < this.Edges.Count; i++)
			{
				messageFilter.CheckMessageFilter((long)i, 10000);
				this.Edges[i].StartPoint.Round(relevantDecimals);
				this.Edges[i].EndPoint.Round(relevantDecimals);
				pointSet.Add(this.Edges[i].StartPoint);
				pointSet.Add(this.Edges[i].EndPoint);
			}
			pointSet.RemoveMultiplePoints3d();
			pointSet.Sort();
			this.Vertices = pointSet.ToList();
			List<SurfaceReconstruction.IndexedEdge> list = new List<SurfaceReconstruction.IndexedEdge>();
			for (int j = 0; j < this.Edges.Count; j++)
			{
				messageFilter.CheckMessageFilter((long)j, 10000);
				int num = this.Vertices.BinarySearch(this.Edges[j].StartPoint);
				if (num < 0)
				{
					num = ~num;
					int num2 = Math.Max(0, num - 1);
					if (this.Edges[num].DistanceTo(this.Edges[j].StartPoint) > this.Edges[num2].DistanceTo(this.Edges[j].StartPoint))
					{
						num = num2;
					}
				}
				int num3 = this.Vertices.BinarySearch(this.Edges[j].EndPoint);
				if (num3 < 0)
				{
					num3 = ~num3;
					int num4 = Math.Max(0, num3 - 1);
					if (this.Edges[num3].DistanceTo(this.Edges[j].EndPoint) > this.Edges[num4].DistanceTo(this.Edges[j].EndPoint))
					{
						num3 = num4;
					}
				}
				list.Add(new SurfaceReconstruction.IndexedEdge(num, num3));
			}
			list = SurfaceReconstruction.IndexedEdge.RemoveDuplicates(list);
			list = SurfaceReconstruction.IndexedEdge.RemoveZeros(list);
			SurfaceReconstruction.DirectedCyclicGraph directedCyclicGraph = new SurfaceReconstruction.DirectedCyclicGraph();
			for (int k = 0; k < list.Count; k++)
			{
				directedCyclicGraph.Add(list[k]);
			}
			pm.SetLimit(directedCyclicGraph.Count);
			if (directedCyclicGraph.Count > 10000)
			{
				pm.Start("Scanning for faces");
			}
			int num5 = 0;
			foreach (int current in directedCyclicGraph.Keys)
			{
				messageFilter.CheckMessageFilter((long)num5, 1000);
				if (directedCyclicGraph.Count > 10000)
				{
					pm.MeterProgress();
				}
				num5++;
				SurfaceReconstruction.Node node = directedCyclicGraph[current];
				foreach (SurfaceReconstruction.Node current2 in node.Children)
				{
					foreach (SurfaceReconstruction.Node current3 in current2.Children)
					{
						if (current3.Number != node.Number)
						{
							bool flag = false;
							foreach (SurfaceReconstruction.Node current4 in current3.Children)
							{
								if (current4.Number != current2.Number && current4.Number == node.Number)
								{
									this.Tris.Add(new SurfaceReconstruction.Tri(node.Number, current2.Number, current3.Number));
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								foreach (SurfaceReconstruction.Node current5 in current3.Children)
								{
									if (current5.Number != current2.Number && !current5.Children.Contains(current2))
									{
										foreach (SurfaceReconstruction.Node current6 in current5.Children)
										{
											if (current6.Number != current3.Number && current6.Number == node.Number)
											{
												this.Quads.Add(new SurfaceReconstruction.Quad(node.Number, current2.Number, current3.Number, current5.Number));
												break;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			SurfaceReconstruction.Tri.RemoveDuplicates(ref this.Tris);
			SurfaceReconstruction.Quad.RemoveDuplicates(ref this.Quads);
			pm.Stop();
		}

		public List<Edge> Edges;

		public List<SurfaceReconstruction.Quad> Quads;

		public List<SurfaceReconstruction.Tri> Tris;

		public List<Point> Vertices;

		//[LicenseProvider(typeof(Class46))]
		public class DirectedCyclicGraph : SortedDictionary<int, SurfaceReconstruction.Node>
		{
			public DirectedCyclicGraph()
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(SurfaceReconstruction.DirectedCyclicGraph));
				//base..ctor();
			}

			public void Add(SurfaceReconstruction.IndexedEdge edge)
			{
				SurfaceReconstruction.Node node = new SurfaceReconstruction.Node(edge.StartPoint);
				if (base.ContainsKey(edge.StartPoint))
				{
					node = base[edge.StartPoint];
				}
				SurfaceReconstruction.Node node2 = new SurfaceReconstruction.Node(edge.EndPoint);
				if (base.ContainsKey(edge.EndPoint))
				{
					node2 = base[edge.EndPoint];
				}
				node.Children.Add(node2);
				node2.Children.Add(node);
				if (!base.ContainsKey(edge.StartPoint))
				{
					base.Add(edge.StartPoint, node);
				}
				if (!base.ContainsKey(edge.EndPoint))
				{
					base.Add(edge.EndPoint, node2);
				}
			}
		}

		//[LicenseProvider(typeof(Class46))]
		public class IndexedEdge : IComparable<SurfaceReconstruction.IndexedEdge>
		{
			public IndexedEdge(int startPoint, int endPoint)
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(SurfaceReconstruction.IndexedEdge));
				//base..ctor();
				this.StartPoint = startPoint;
				this.EndPoint = endPoint;
			}

			public int CompareTo(SurfaceReconstruction.IndexedEdge indexedEdge)
			{
				if (this.StartPoint != indexedEdge.StartPoint)
				{
					return this.StartPoint.CompareTo(indexedEdge.StartPoint);
				}
				return this.EndPoint.CompareTo(indexedEdge.EndPoint);
			}

			public override bool Equals(object obj)
			{
				return this == (SurfaceReconstruction.IndexedEdge)obj;
			}

			public override int GetHashCode()
			{
				int hashCode = this.StartPoint.GetHashCode();
				int hashCode2 = this.EndPoint.GetHashCode();
				return hashCode ^ hashCode2;
			}

			public static bool operator ==(SurfaceReconstruction.IndexedEdge left, SurfaceReconstruction.IndexedEdge right)
			{
                if ((object)left == (object)right)
				{
					return true;
				}
                if ((object)left == null || (object)right == null)
				{
					return false;
				}
				if (left.StartPoint == right.StartPoint)
				{
					return left.EndPoint == right.EndPoint;
				}
				return left.StartPoint == right.EndPoint && left.EndPoint == right.StartPoint;
			}

			public static bool operator !=(SurfaceReconstruction.IndexedEdge left, SurfaceReconstruction.IndexedEdge right)
			{
				return !(left == right);
			}

			public static List<SurfaceReconstruction.IndexedEdge> RemoveDuplicates(List<SurfaceReconstruction.IndexedEdge> indexedEdges)
			{
				indexedEdges.Sort();
				for (int i = indexedEdges.Count - 2; i >= 0; i--)
				{
					if (indexedEdges[i].StartPoint == indexedEdges[i + 1].StartPoint && indexedEdges[i].EndPoint == indexedEdges[i + 1].EndPoint)
					{
						indexedEdges.RemoveAt(i + 1);
					}
				}
				return indexedEdges;
			}

			public static List<SurfaceReconstruction.IndexedEdge> RemoveZeros(List<SurfaceReconstruction.IndexedEdge> indexedEdges)
			{
				indexedEdges.Sort();
				for (int i = indexedEdges.Count - 1; i >= 0; i--)
				{
					if (indexedEdges[i].StartPoint == indexedEdges[i].EndPoint)
					{
						indexedEdges.RemoveAt(i);
					}
				}
				return indexedEdges;
			}

			public void Swap()
			{
				int startPoint = this.StartPoint;
				this.StartPoint = this.EndPoint;
				this.EndPoint = startPoint;
			}

			public int EndPoint;

			public int StartPoint;
		}

		//[LicenseProvider(typeof(Class46))]
		public class Node
		{
			public Node(int number)
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(SurfaceReconstruction.Node));
				this.Children = new List<SurfaceReconstruction.Node>();
				//base..ctor();
				this.Number = number;
			}

			public List<SurfaceReconstruction.Node> Children;

			public int Number;
		}

		//[LicenseProvider(typeof(Class46))]
		public class Quad : IComparable<SurfaceReconstruction.Quad>
		{
			public Quad(int v1, int v2, int v3, int v4)
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(SurfaceReconstruction.Quad));
				this.SortedIndices = new List<int>();
				//base..ctor();
				this.SortedIndices.Add(v1);
				this.SortedIndices.Add(v2);
				this.SortedIndices.Add(v3);
				this.SortedIndices.Add(v4);
				this.SortedIndices.Sort();
				this.Vertex1 = v1;
				this.Vertex2 = v2;
				this.Vertex3 = v3;
				this.Vertex4 = v4;
			}

			public int CompareTo(SurfaceReconstruction.Quad quad)
			{
				if (this.SortedIndices[0] != quad.SortedIndices[0])
				{
					return this.SortedIndices[0].CompareTo(quad.SortedIndices[0]);
				}
				if (this.SortedIndices[1] != quad.SortedIndices[1])
				{
					return this.SortedIndices[1].CompareTo(quad.SortedIndices[1]);
				}
				if (this.SortedIndices[2] != quad.SortedIndices[2])
				{
					return this.SortedIndices[2].CompareTo(quad.SortedIndices[2]);
				}
				return this.SortedIndices[3].CompareTo(quad.SortedIndices[3]);
			}

			public static void RemoveDuplicates(ref List<SurfaceReconstruction.Quad> quads)
			{
				if (quads.Count <= 1)
				{
					return;
				}
				List<SurfaceReconstruction.Quad> list = new List<SurfaceReconstruction.Quad>();
				quads.Sort();
				for (int i = quads.Count - 2; i >= 0; i--)
				{
					if (quads[i].SortedIndices[0] != quads[i + 1].SortedIndices[0] || quads[i].SortedIndices[1] != quads[i + 1].SortedIndices[1] || quads[i].SortedIndices[2] != quads[i + 1].SortedIndices[2] || quads[i].SortedIndices[3] != quads[i + 1].SortedIndices[3])
					{
						list.Add(quads[i + 1]);
					}
				}
				list.Add(quads[0]);
				quads = list;
			}

			public List<int> SortedIndices;

			public int Vertex1;

			public int Vertex2;

			public int Vertex3;

			public int Vertex4;
		}

		//[LicenseProvider(typeof(Class46))]
		public class Tri : IComparable<SurfaceReconstruction.Tri>
		{
			public Tri(int v1, int v2, int v3)
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(SurfaceReconstruction.Tri));
				//base..ctor();
				List<int> list = new List<int>();
				list.Add(v1);
				list.Add(v2);
				list.Add(v3);
				list.Sort();
				this.Vertex1 = list[0];
				this.Vertex2 = list[1];
				this.Vertex3 = list[2];
			}

			public int CompareTo(SurfaceReconstruction.Tri tri)
			{
				if (this.Vertex1 != tri.Vertex1)
				{
					return this.Vertex1.CompareTo(tri.Vertex1);
				}
				if (this.Vertex2 != tri.Vertex2)
				{
					return this.Vertex2.CompareTo(tri.Vertex2);
				}
				return this.Vertex3.CompareTo(tri.Vertex3);
			}

			public static void RemoveDuplicates(ref List<SurfaceReconstruction.Tri> tris)
			{
				if (tris.Count <= 1)
				{
					return;
				}
				List<SurfaceReconstruction.Tri> list = new List<SurfaceReconstruction.Tri>();
				tris.Sort();
				for (int i = tris.Count - 2; i >= 0; i--)
				{
					if (tris[i].Vertex1 != tris[i + 1].Vertex1 || tris[i].Vertex2 != tris[i + 1].Vertex2 || tris[i].Vertex3 != tris[i + 1].Vertex3)
					{
						list.Add(tris[i + 1]);
					}
				}
				list.Add(tris[0]);
				tris = list;
			}

			public int Vertex1;

			public int Vertex2;

			public int Vertex3;
		}
	}
}
