using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class ConformingDelaunayTriangulation2d : DelaunayTriangulation2d
	{
		public ConformingDelaunayTriangulation2d()
		{
			
			this.constraints = new List<Constraint>();
			this.boundaries = new List<Constraint>();
			this.badConstraints = new List<Constraint>();
		}

		public new bool AddPointToCurrentTriangulation(Point vertexToInsert)
		{
			throw new NotImplementedException("Not implemented for conforming triangulation.");
		}

		public static int CountBoundaryRegions(List<Edge> boundaries)
		{
			if (boundaries.Count == 0)
			{
				return 0;
			}
			if (boundaries.Count < 3)
			{
				throw new InvalidOperationException("At least three boundary edges must be given.");
			}
			int num = 0;
			int num2 = 0;
			Point startPoint = boundaries[0].StartPoint;
			for (int i = 0; i < boundaries.Count; i++)
			{
				num2++;
				if (boundaries[i].EndPoint == startPoint)
				{
					if (num2 < 3)
					{
                        throw new System.Exception("A boundary region contains less than three edges.");
					}
					num++;
					if (boundaries.Count == i + 1)
					{
						return num;
					}
					startPoint = boundaries[i + 1].StartPoint;
					num2 = 0;
				}
			}
            throw new System.Exception("Boundaries do not form valid regions.");
		}

		public static double DistanceXY(Point p1, Point p2)
		{
			double num = p1.X - p2.X;
			double num2 = p1.Y - p2.Y;
			return Math.Sqrt(num * num + num2 * num2);
		}

		public new void GenerateRaster(double xSpacing, double ySpacing)
		{
			throw new NotImplementedException("Not implemented for conforming triangulation.");
		}

		public new List<Triangle> GetTriangles()
		{
			List<Triangle> triangles = base.GetTriangles();
			if (this.boundaries.Count == 0)
			{
				return triangles;
			}
			List<Triangle> list = new List<Triangle>();
			for (int i = 0; i < triangles.Count; i++)
			{
				if (this.IsValid(triangles[i].Center))
				{
					list.Add(triangles[i]);
				}
			}
			return list;
		}

		public new void GetXYExtents()
		{
			throw new NotImplementedException("Not implemented for conforming triangulation.");
		}

		public bool IsValid(Point p)
		{
			if (this.boundaries.Count == 0)
			{
				return true;
			}
			Class17 @class = new Class17(p, new Vector3d(-1.0, 0.0, 0.0));
			int num = 0;
			bool flag = false;
			for (int i = 0; i < this.boundaries.Count; i++)
			{
				Edge edge = this.boundaries[i].Edge;
				if (@class.method_6(edge, ref flag))
				{
					num++;
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				num = this.method_16(@class.method_0());
			}
			return num % 2 != 0;
		}

		private void method_12()
		{
			List<Class16> list = new List<Class16>();
			for (int i = 0; i < this.boundaries.Count; i++)
			{
				list.Add(new Class16(this.boundaries[i].Edge.StartPoint, (aabbcc)0));
				list.Add(new Class16(this.boundaries[i].Edge.EndPoint, (aabbcc)0));
			}
			List<Point> collection = new List<Point>();
			PointSet pointSet = Class16.getCleanedPoints(list, ref collection);
			base.BadPoints.AddRange(collection);
			for (int j = 0; j < pointSet.Count; j++)
			{
				if (!base.method_10(pointSet[j]))
				{
					pointSet[j].Z = base.GetZCoordinate(pointSet[j]);
					if (double.IsNaN(pointSet[j].Z))
					{
						throw new ArgumentException("Boundary point " + pointSet[j].ToString() + " does not lie within the triangulated surface.");
					}
				}
				else
				{
					pointSet[j].Z = base.GetZCoordinate(pointSet[j]);
				}
			}
			for (int k = 0; k < pointSet.Count; k++)
			{
				if (base.AddPointToCurrentTriangulation(pointSet[k]))
				{
					this.int_2++;
				}
			}
		}

		private int method_13(ref List<Constraint> list_6)
		{
			bool flag = true;
			int num = 2147483647;
			while (flag)
			{
				List<Class14> list = this.method_14(ref list_6);
				num = list.Count;
				if (num <= this.int_0)
				{
					flag = false;
					ConformingDelaunayTriangulation2d.IterationStepEventArgs e = new ConformingDelaunayTriangulation2d.IterationStepEventArgs(list.Count, this.int_1);
					this.vmethod_1(null, e);
				}
				else
				{
					this.int_1++;
					for (int i = 0; i < list.Count; i++)
					{
						if (!base.AddPointToCurrentTriangulation(list[i].point_0))
						{
							list_6.Remove(list[i].constraint_0);
							list_6.Remove(list[i].constraint_1);
							this.badConstraints.Add(list[i].constraint_0);
							this.badConstraints.Add(list[i].constraint_1);
						}
						else
						{
							this.int_2++;
						}
					}
					ConformingDelaunayTriangulation2d.IterationStepEventArgs e2 = new ConformingDelaunayTriangulation2d.IterationStepEventArgs(list.Count, this.int_1);
					this.vmethod_1(null, e2);
				}
			}
			return num;
		}

		private List<Class14> method_14(ref List<Constraint> list_6)
		{
			List<Class14> list = new List<Class14>();
			List<Constraint> list2 = new List<Constraint>();
			for (int i = 0; i < list_6.Count; i++)
			{
				try
				{
					bool flag = true;
					List<DelaunayTriangulation2d.Class15> list3 = base.method_9(list_6[i].Edge.StartPoint);
					if (list3.Count == 0)
					{
                        throw new System.Exception("The start point of a constraint / boundary edge is not part of the triangulation");
					}
					if (list3.Count < 3)
					{
                        throw new System.Exception("Incident node retrieval failed.");
					}
					for (int j = 0; j < list3.Count; j++)
					{
						if (list3[j].method_12().method_18(list_6[i].Edge.EndPoint))
						{
							flag = false;
						}
					}
					if (flag)
					{
						bool flag2 = false;
						Class14 @class = new Class14();
						@class.point_0 = this.method_15(list_6[i], list3, ref flag2);
						@class.constraint_0 = new Constraint(new Edge(list_6[i].Edge.StartPoint, @class.point_0), list_6[i].Type);
						@class.constraint_1 = new Constraint(new Edge(@class.point_0, list_6[i].Edge.EndPoint), list_6[i].Type);
						if (!flag2)
						{
							list.Add(@class);
						}
						list2.Add(@class.constraint_0);
						list2.Add(@class.constraint_1);
					}
					else
					{
						list2.Add(list_6[i]);
					}
				}
                catch (System.Exception ex)
				{
					this.badConstraints.Add(list_6[i]);
				}
			}
			list_6 = list2;
			return list;
		}

		private Point method_15(Constraint constraint_0, List<DelaunayTriangulation2d.Class15> nodes, ref bool bool_1)
		{
			bool_1 = false;
			Edge edge = constraint_0.Edge;
			Constraint.ConstraintType type = constraint_0.Type;
			int i = 0;
			while (i < nodes.Count)
			{
				Edge edge2 = nodes[i].method_12().method_15(nodes[i].method_12().method_19(edge.StartPoint));
				if (!ConformingDelaunayTriangulation2d.smethod_0(edge, edge2))
				{
					i++;
				}
				else
				{
					Point point;
					if (type == Constraint.ConstraintType.Boundary)
					{
						point = edge2.ToLine().getInterSecttion(new Plane(edge.StartPoint, edge.method_9(), new Vector3d(0.0, 0.0, 1.0)));
					}
					else
					{
						point = edge.ToLine().getInterSecttion(new Plane(edge2.StartPoint, edge2.method_9(), new Vector3d(0.0, 0.0, 1.0)));
					}
					if (point == null)
					{
						throw new ArithmeticException("Constraint/boundary intersection with triangle failed at following edge:\n" + constraint_0.ToString());
					}
					if (ConformingDelaunayTriangulation2d.DistanceXY(edge2.StartPoint, point) < Global.AbsoluteEpsilon)
					{
						bool_1 = true;
						edge2.StartPoint.Z = point.Z;
						return edge2.StartPoint;
					}
					if (ConformingDelaunayTriangulation2d.DistanceXY(edge2.EndPoint, point) < Global.AbsoluteEpsilon)
					{
						bool_1 = true;
						edge2.EndPoint.Z = point.Z;
						return edge2.EndPoint;
					}
					return point;
				}
			}
            throw new System.Exception("A degenerate triangle occurred along the following edge:\n" + constraint_0.ToString());
		}

		private int method_16(Point point_0)
		{
			bool flag = true;
			int num = 0;
			int num2 = 0;
			while (flag)
			{
				num2++;
				if (num2 > 10)
				{
					throw new ArithmeticException("Random ray intersection failed after 10 retries. Some boundaries can not be respected.");
				}
				num = 0;
				Class17 @class = Class17.smethod_0(point_0);
				for (int i = 0; i < this.boundaries.Count; i++)
				{
					Edge edge = this.boundaries[i].Edge;
					if (@class.method_5(edge, ref flag))
					{
						num++;
					}
					if (flag)
					{
						break;
					}
				}
				if (this.boundaries.Count <= 0)
				{
				}
			}
			return num;
		}

		public new void RasterizeCurrentTriangulation(PointSet raster, double defaultZ)
		{
			throw new NotImplementedException("Not implemented for conforming triangulation.");
		}

		public new void RasterizeCurrentTriangulation(double xSpacing, double ySpacing)
		{
			throw new NotImplementedException("Not implemented for conforming triangulation.");
		}

		private static bool smethod_0(Edge edge_0, Edge edge_1)
		{
			int num = Math.Sign(Predicate.Orient2d_exact(edge_0.StartPoint, edge_0.EndPoint, edge_1.StartPoint));
			double num2 = (double)Math.Sign(Predicate.Orient2d_exact(edge_0.StartPoint, edge_0.EndPoint, edge_1.EndPoint));
			if ((double)num == num2)
			{
				return false;
			}
			double num3 = (double)Math.Sign(Predicate.Orient2d_exact(edge_1.StartPoint, edge_1.EndPoint, edge_0.StartPoint));
			double num4 = (double)Math.Sign(Predicate.Orient2d_exact(edge_1.StartPoint, edge_1.EndPoint, edge_0.EndPoint));
			return num3 != num4;
		}

		public new void Triangulate()
		{
			this.int_1 = 0;
			this.int_2 = 0;
			this.badConstraints = new List<Constraint>();
			List<Class16> list = new List<Class16>();
			for (int i = 0; i < base.TriangulationPoints.Count; i++)
			{
				list.Add(new Class16(base.TriangulationPoints[i], (aabbcc)1));
			}
			for (int j = 0; j < this.constraints.Count; j++)
			{
				list.Add(new Class16(this.constraints[j].Edge.StartPoint, (aabbcc)2));
				list.Add(new Class16(this.constraints[j].Edge.EndPoint, (aabbcc)2));
			}
			if (list.Count < 3)
			{
				throw new ArgumentException("Can not triangulate less than three vertices.");
			}
			List<Point> collection = new List<Point>();
			base.TriangulationPoints = Class16.getCleanedPoints(list, ref collection);
			base.Triangulate();
			base.BadPoints.AddRange(collection);
			if (this.constraints.Count == 0 && this.boundaries.Count == 0)
			{
				return;
			}
			List<Constraint> list2 = new List<Constraint>();
			list2.AddRange(this.constraints);
			this.method_13(ref list2);
			this.int_0 = 0;
			if (this.boundaries.Count > 0)
			{
				this.method_12();
				list2.Clear();
				list2.AddRange(this.boundaries);
				this.method_13(ref list2);
			}
		}

		internal virtual void vmethod_1(object sender, ConformingDelaunayTriangulation2d.IterationStepEventArgs e)
		{
			IterationStepEventHandler iterationStepEventHandler = this.iterationStepEventHandler_0;
			if (iterationStepEventHandler != null)
			{
				iterationStepEventHandler(null, e);
			}
		}

		public List<Constraint> BadConstraints
		{
			get
			{
				return this.badConstraints;
			}
			set
			{
				this.badConstraints = value;
			}
		}

		public List<Constraint> Boundaries
		{
			get
			{
				return this.boundaries;
			}
			set
			{
				this.boundaries = value;
			}
		}

		public List<Constraint> Constraints
		{
			get
			{
				return this.constraints;
			}
			set
			{
				this.constraints = value;
			}
		}

		public int MaximumFeasibleEdgeViolations
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		public int NumberOfIterations
		{
			get
			{
				return this.int_1;
			}
		}

		public int NumberOfSteinerPoints
		{
			get
			{
				return this.int_2;
			}
		}

		public event IterationStepEventHandler IterationStepHandler
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.iterationStepEventHandler_0 = (IterationStepEventHandler)Delegate.Combine(this.iterationStepEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.iterationStepEventHandler_0 = (IterationStepEventHandler)Delegate.Remove(this.iterationStepEventHandler_0, value);
			}
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private IterationStepEventHandler iterationStepEventHandler_0;

		private List<Constraint> constraints;

		private List<Constraint> boundaries;

		private List<Constraint> badConstraints;

		//[LicenseProvider(typeof(Class46))]
		public class IterationStepEventArgs : EventArgs
		{
			public IterationStepEventArgs(int pointsInserted, int currentIterationStep)
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(ConformingDelaunayTriangulation2d.IterationStepEventArgs));
				//base..ctor();
				this.int_0 = pointsInserted;
				this.int_1 = currentIterationStep;
			}

			public int CurrentIterationStep
			{
				get
				{
					return this.int_1;
				}
			}

			public int NumberOfPointsInserted
			{
				get
				{
					return this.int_0;
				}
			}

			private int int_0;

			private int int_1;
		}
	}
}
