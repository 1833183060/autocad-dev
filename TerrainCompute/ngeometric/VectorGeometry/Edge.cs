using System;
using System.Collections.Generic;
using System.ComponentModel;
using Autodesk.AutoCAD.DatabaseServices;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class Edge : IComparable<Edge>
	{
		public Edge()
		{            
			this.Status = Edge.EdgeStatus.NotDefined;
			this.startPoint = new Point();
			this.endPoint = new Point();
		}

		public Edge(Point startPoint, Point endPoint)
		{           
			this.Status = Edge.EdgeStatus.NotDefined;
			this.startPoint = startPoint;
			this.endPoint = endPoint;
		}

		public bool CollinearContains(Point point)
		{
			double num = point.DistanceTo(this.startPoint);
			double num2 = point.DistanceTo(this.endPoint);
			double b = this.startPoint.DistanceTo(this.endPoint);
			return Global.AlmostEquals(num + num2, b);
		}

		public bool CollinearContainsXY(Point point)
		{
			double num = this.startPoint.X - this.endPoint.X;
			double num2 = this.startPoint.Y - this.endPoint.Y;
			double num3 = this.startPoint.X - point.X;
			double num4 = this.startPoint.Y - point.Y;
			double num5 = this.endPoint.X - point.X;
			double num6 = this.endPoint.Y - point.Y;
			double b = Math.Sqrt(num * num + num2 * num2);
			double num7 = Math.Sqrt(num3 * num3 + num4 * num4);
			double num8 = Math.Sqrt(num5 * num5 + num6 * num6);
			return Global.AlmostEquals(num7 + num8, b);
		}

		public Edge CollinearOverlap(Edge edge)
		{
			bool flag = this.CollinearContains(edge.startPoint);
			bool flag2 = this.CollinearContains(edge.endPoint);
			bool flag3 = edge.CollinearContains(this.startPoint);
			bool flag4 = edge.CollinearContains(this.endPoint);
			if (flag)
			{
				if (flag2)
				{
					return new Edge(edge.startPoint, edge.endPoint);
				}
				if (flag3)
				{
					return new Edge(edge.startPoint, this.startPoint);
				}
				if (flag4)
				{
					return new Edge(edge.startPoint, this.endPoint);
				}
			}
			else if (flag2)
			{
				if (flag3)
				{
					return new Edge(edge.endPoint, this.startPoint);
				}
				if (flag4)
				{
					return new Edge(edge.endPoint, this.endPoint);
				}
			}
			else if (flag3 && flag4)
			{
				return new Edge(this.startPoint, this.endPoint);
			}
			return null;
		}

		public Edge CollinearOverlapXY(Edge edge)
		{
			bool flag = this.CollinearContainsXY(edge.startPoint);
			bool flag2 = this.CollinearContainsXY(edge.endPoint);
			bool flag3 = edge.CollinearContainsXY(this.startPoint);
			bool flag4 = edge.CollinearContainsXY(this.endPoint);
			if (flag)
			{
				if (flag2)
				{
					return new Edge(edge.startPoint, edge.endPoint);
				}
				if (flag3)
				{
					return new Edge(edge.startPoint, this.startPoint);
				}
				if (flag4)
				{
					return new Edge(edge.startPoint, this.endPoint);
				}
			}
			else if (flag2)
			{
				if (flag3)
				{
					return new Edge(edge.endPoint, this.startPoint);
				}
				if (flag4)
				{
					return new Edge(edge.endPoint, this.endPoint);
				}
			}
			else if (flag3 && flag4)
			{
				return new Edge(this.startPoint, this.endPoint);
			}
			return null;
		}

		public int CompareTo(Edge edge)
		{
			return this.Length.CompareTo(edge.Length);
		}

		public bool Contains(Point point)
		{
			return !(point == null) && this.ToLine().Contains(point) && this.CollinearContains(point);
		}

		public bool Contains(Edge edge)
		{
			return this.Contains(edge.StartPoint) & this.Contains(edge.EndPoint);
		}

		public Edge DeepCopy()
		{
			return new Edge
			{
				startPoint = new Point(this.startPoint.X, this.startPoint.Y, this.startPoint.Z),
				endPoint = new Point(this.endPoint.X, this.endPoint.Y, this.endPoint.Z)
			};
		}

		public double DistanceTo(Point point)
		{
			return point.DistanceTo(this);
		}

		public double DistanceTo(Line line)
		{
			return line.DistanceTo(this);
		}

		public double DistanceTo(Edge edge)
		{
			return this.PseudoPerdendicularOn(edge).Length;
		}

		public double DistanceTo(Plane plane)
		{
			return plane.DistanceTo(this);
		}

		public override bool Equals(object obj)
		{
			return this == (Edge)obj;
		}

		public override int GetHashCode()
		{
			return this.startPoint.GetHashCode() ^ this.endPoint.GetHashCode();
		}

		public bool HasVertex(Point point)
		{
			return this.startPoint == point || this.endPoint == point;
		}

		public bool Intersects2d(Triangle triangle)
		{
			PointSet pointSet = this.method_0(triangle);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects2d(Circle circle)
		{
			PointSet pointSet = this.method_1(circle);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects2d(Ellipse ellipse)
		{
			PointSet pointSet = this.method_2(ellipse);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects3d(Edge edge)
		{
			return this.method_3(edge) != null;
		}

		public bool Intersects3d(Line line)
		{
			return line.Intersects3d(this);
		}

		public bool Intersects3d(Plane plane)
		{
			return plane.Intersects3d(this);
		}

		public bool Intersects3d(Triangle triangle)
		{
			return this.method_6(triangle) != null;
		}

		public bool Intersects3d(Circle circle)
		{
			return this.method_7(circle) != null;
		}

		public bool Intersects3d(Ellipse ellipse)
		{
			return this.method_8(ellipse) != null;
		}

		public Point IntersectXY(Edge e)
		{
			double x = this.startPoint.X;
			double y = this.startPoint.Y;
			double x2 = this.endPoint.X;
			double y2 = this.endPoint.Y;
			double x3 = e.startPoint.X;
			double y3 = e.startPoint.Y;
			double x4 = e.endPoint.X;
			double y4 = e.endPoint.Y;
			double num = x4 - x3;
			double num2 = y - y3;
			double num3 = y4 - y3;
			double num4 = x - x3;
			double num5 = x2 - x;
			double num6 = y2 - y;
			double num7 = num3 * num5 - num * num6;
			if (Math.Abs(num7) < Global.AbsoluteEpsilon)
			{
				return null;
			}
			double num8 = num * num2 - num3 * num4;
			double num9 = num8 / num7;
			if (num9 < 0.0 || num9 > 1.0)
			{
				return null;
			}
			double num10 = num5 * num2 - num6 * num4;
			double num11 = num10 / num7;
			if (num11 >= 0.0 && num11 <= 1.0)
			{
				double x5 = x + num9 * num5;
				double y5 = y + num9 * num6;
				return new Point(x5, y5, 0.0);
			}
			return null;
		}

		public bool IsCollinearTo(Point point)
		{
			return point.IsCollinearTo(this);
		}

		public bool IsCollinearTo(Edge edge)
		{
			return this.ToLine().Contains(edge) || edge.ToLine().Contains(this);
		}

		public bool IsCollinearTo(Line line)
		{
			return line.IsCollinearTo(this);
		}

		public bool IsCollinearXY(Edge edge)
		{
			double num = this.endPoint.X - this.startPoint.X;
			double num2 = this.endPoint.Y - this.startPoint.Y;
			double num3 = edge.endPoint.X - this.startPoint.X;
			double num4 = edge.endPoint.Y - this.startPoint.Y;
			double num5 = edge.endPoint.X - this.startPoint.X;
			double num6 = edge.endPoint.Y - this.startPoint.Y;
			double value = num * num4 - num3 * num2;
			if (Math.Abs(value) > 4.94065645841247E-324)
			{
				return false;
			}
			double value2 = num * num6 - num5 * num2;
			return Math.Abs(value2) <= 4.94065645841247E-324;
		}

		public bool IsCoplanarTo(Edge edge)
		{
			if (this.Length > 4.94065645841247E-324)
			{
				return this.ToLine().IsCoplanarTo(edge);
			}
			if (edge.Length > 4.94065645841247E-324)
			{
				return edge.ToLine().IsCoplanarTo(this);
			}
			return edge.ToLine().Contains(this);
		}

		public bool IsCoplanarTo(Line line)
		{
			return line.IsCoplanarTo(this);
		}

		public bool IsCoplanarTo(Plane plane)
		{
			return plane.Contains(this);
		}

		public bool IsCoplanarTo(Triangle triangle)
		{
			return Plane.smethod_0(triangle.Vertex1, triangle.NormalVector, this.StartPoint) && Plane.smethod_0(triangle.Vertex1, triangle.NormalVector, this.EndPoint);
		}

		public bool IsCoplanarTo(Circle circle)
		{
			return Plane.smethod_0(circle.Center, circle.NormalVector, this.StartPoint) && Plane.smethod_0(circle.Center, circle.NormalVector, this.EndPoint);
		}

		public bool IsCoplanarTo(Ellipse ellipse)
		{
			return Plane.smethod_0(ellipse.Center, ellipse.NormalVector, this.StartPoint) && Plane.smethod_0(ellipse.Center, ellipse.NormalVector, this.EndPoint);
		}

		public bool IsParallelTo(Edge edge)
		{
			return this.method_9().IsParallelTo(edge.method_9());
		}

		public bool IsParallelTo(Line line)
		{
			return this.method_9().IsParallelTo(line.DirectionVector);
		}

		public bool IsParallelTo(Plane plane)
		{
			return this.Length < 4.94065645841247E-324 || this.method_9().IsOrthogonalTo(plane.NormalVector);
		}

		public bool IsParallelTo(Triangle triangle)
		{
			return this.Length < 4.94065645841247E-324 || this.method_9().IsOrthogonalTo(triangle.NormalVector);
		}

		public bool IsParallelTo(Circle circle)
		{
			return this.Length < 4.94065645841247E-324 || this.method_9().IsOrthogonalTo(circle.NormalVector);
		}

		public bool IsParallelTo(Ellipse ellipse)
		{
			return this.Length < 4.94065645841247E-324 || this.method_9().IsOrthogonalTo(ellipse.NormalVector);
		}

		public PointSet method_0(Triangle triangle)
		{
			if (this.Length < 4.94065645841247E-324)
			{
				if (triangle.ContainsOnCircumference(this.StartPoint))
				{
					return new PointSet
					{
						this.startPoint,
						this.endPoint
					};
				}
				if (triangle.GetPlane().Contains(this.StartPoint))
				{
					return new PointSet();
				}
				return null;
			}
			else
			{
				PointSet pointSet = this.ToLine().method_0(triangle);
				if (pointSet == null)
				{
					return null;
				}
				for (int i = pointSet.Count - 1; i >= 0; i--)
				{
					if (!this.CollinearContains(pointSet[i]))
					{
						pointSet.RemoveAt(i);
					}
				}
				return pointSet;
			}
		}

		public PointSet method_1(Circle circle)
		{
			if (this.Length < 4.94065645841247E-324)
			{
				if (circle.ContainsOnCircumference(this.StartPoint))
				{
					return new PointSet
					{
						this.startPoint,
						this.endPoint
					};
				}
				if (circle.GetPlane().Contains(this.StartPoint))
				{
					return new PointSet();
				}
				return null;
			}
			else
			{
				PointSet pointSet = this.ToLine().method_1(circle);
				if (pointSet == null)
				{
					return null;
				}
				switch (pointSet.Count)
				{
				case 0:
					return pointSet;
				case 1:
					if (!this.CollinearContains(pointSet[0]))
					{
						pointSet.RemoveAt(0);
					}
					return pointSet;
				case 2:
					if (!this.CollinearContains(pointSet[1]))
					{
						pointSet.RemoveAt(1);
					}
					if (!this.CollinearContains(pointSet[0]))
					{
						pointSet.RemoveAt(0);
					}
					return pointSet;
				default:
					return null;
				}
			}
		}

		public PointSet method_2(Ellipse ellipse)
		{
			if (this.Length < 4.94065645841247E-324)
			{
				if (ellipse.ContainsOnCircumference(this.StartPoint))
				{
					return new PointSet
					{
						this.startPoint,
						this.endPoint
					};
				}
				if (ellipse.GetPlane().Contains(this.StartPoint))
				{
					return new PointSet();
				}
				return null;
			}
			else
			{
				PointSet pointSet = this.ToLine().method_2(ellipse);
				if (pointSet == null)
				{
					return null;
				}
				switch (pointSet.Count)
				{
				case 0:
					return pointSet;
				case 1:
					if (!this.CollinearContains(pointSet[0]))
					{
						pointSet.RemoveAt(0);
					}
					return pointSet;
				case 2:
					if (!this.CollinearContains(pointSet[1]))
					{
						pointSet.RemoveAt(1);
					}
					if (!this.CollinearContains(pointSet[0]))
					{
						pointSet.RemoveAt(0);
					}
					return pointSet;
				default:
					return null;
				}
			}
		}

		public Point method_3(Edge edge)
		{
			Point point = this.ToLine().method_3(edge.ToLine());
			if (point == null)
			{
				return null;
			}
			if (this.CollinearContains(point) & edge.CollinearContains(point))
			{
				return point;
			}
			return null;
		}

		public Point method_4(Line line)
		{
			return line.method_4(this);
		}

		public Point method_5(Plane plane)
		{
			return plane.getInterSection(this);
		}

		public Point method_6(Triangle triangle)
		{
			Point point = this.ToLine().method_6(triangle);
			if (point == null)
			{
				return null;
			}
			if (this.IsCoplanarTo(triangle))
			{
				return null;
			}
			if (this.CollinearContains(point))
			{
				return point;
			}
			return null;
		}

		public Point method_7(Circle circle)
		{
			Point point = this.ToLine().method_7(circle);
			if (point == null)
			{
				return null;
			}
			if (this.IsCoplanarTo(circle))
			{
				return null;
			}
			if (this.CollinearContains(point))
			{
				return point;
			}
			return null;
		}

		public Point method_8(Ellipse ellipse)
		{
			Point point = this.ToLine().method_8(ellipse);
			if (point == null)
			{
				return null;
			}
			if (this.IsCoplanarTo(ellipse))
			{
				return null;
			}
			if (this.CollinearContains(point))
			{
				return point;
			}
			return null;
		}

		public Vector3d method_9()
		{
			double x = this.endPoint.X - this.startPoint.X;
			double y = this.endPoint.Y - this.startPoint.Y;
			double z = this.endPoint.Z - this.startPoint.Z;
			return new Vector3d(x, y, z);
		}

		public Edge Move(Vector3d displacementVector)
		{
			return new Edge
			{
				startPoint = this.startPoint + displacementVector.ToPoint(),
				endPoint = this.endPoint + displacementVector.ToPoint()
			};
		}

		public Edge Move(Point startPoint, Point endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public static bool operator ==(Edge left, Edge right)
		{
            if ((object)left == (object)right)
            {
                return true;
            }
            if ((object)left == null || (object)right == null)
            {
                return false;
            }
            return (left.StartPoint != right.StartPoint ? false : left.EndPoint == right.EndPoint) | (left.StartPoint != right.EndPoint ? false : left.EndPoint == right.StartPoint);
		}

		public static bool operator !=(Edge left, Edge right)
		{
			return !(left == right);
		}

		public Edge Overlap(Edge edge)
		{
			if (!this.IsCollinearTo(edge))
			{
				return null;
			}
			return this.CollinearOverlap(edge);
		}

		public bool Overlaps(Edge edge)
		{
			return this.IsCollinearTo(edge) && (edge.CollinearContains(this.StartPoint) || edge.CollinearContains(this.EndPoint) || this.CollinearContains(edge.StartPoint) || this.CollinearContains(edge.EndPoint));
		}

		public Edge ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			if (viewDirection.IsOrthogonalTo(plane.NormalVector))
			{
				throw new ArgumentException("Projection error: view direction is parallel to projection plane!");
			}
			return new Edge
			{
				startPoint = this.startPoint.ProjectParallelOn(plane, viewDirection),
				endPoint = this.endPoint.ProjectParallelOn(plane, viewDirection)
			};
		}

		public Edge PseudoPerdendicularOn(Point point)
		{
			return point.PseudoPerdendicularOn(this);
		}

		public Edge PseudoPerdendicularOn(Edge edge)
		{
			if (this.Length < Global.AbsoluteEpsilon & edge.Length < Global.AbsoluteEpsilon)
			{
				return new Edge(this.MidPoint, edge.MidPoint);
			}
			if (this.Length < Global.AbsoluteEpsilon)
			{
				return this.MidPoint.PseudoPerdendicularOn(edge);
			}
			if (edge.Length < Global.AbsoluteEpsilon)
			{
				return edge.MidPoint.PseudoPerdendicularOn(this);
			}
			if (this.Intersects3d(edge))
			{
				Point point = this.method_3(edge);
				return new Edge(point, point);
			}
			List<Edge> list = new List<Edge>();
			Line line = this.ToLine();
			Line line2 = edge.ToLine();
			if (line.IsSkewTo(line2))
			{
				Edge edge2 = line.PerpendicularOn(line2);
				if (edge.CollinearContains(edge2.EndPoint) & this.CollinearContains(edge2.StartPoint))
				{
					list.Add(edge2);
				}
			}
			list.Add(edge.StartPoint.PseudoPerdendicularOn(this));
			list.Add(edge.EndPoint.PseudoPerdendicularOn(this));
			list.Add(this.StartPoint.PseudoPerdendicularOn(edge));
			list.Add(this.EndPoint.PseudoPerdendicularOn(edge));
			list.Sort();
			return list[0];
		}

		public static Edge RandomEdge()
		{
			Point startPoint = Point.RandomPoint();
			Point endPoint = Point.RandomPoint();
			return new Edge(startPoint, endPoint);
		}

		public static void RandomPermute(ref List<Edge> edges)
		{
			Random random = new Random();
			int num = edges.Count - 1;
			for (int i = num; i >= 0; i--)
			{
				int index = Convert.ToInt32(random.NextDouble() * (double)num);
				Edge value = edges[i];
				edges[i] = edges[index];
				edges[index] = value;
			}
		}

		public Point RandomPointOnEdge()
		{
			double num = RandomGenerator.NextDouble_0_1();
			double scalar = 1.0 - num;
			return num * this.startPoint + scalar * this.endPoint;
		}

		public Edge ReflectIn(Point point)
		{
			return new Edge
			{
				startPoint = this.startPoint.ReflectIn(point),
				endPoint = this.endPoint.ReflectIn(point)
			};
		}

		public Edge ReflectIn(Line line)
		{
			return new Edge
			{
				startPoint = this.startPoint.ReflectIn(line),
				endPoint = this.endPoint.ReflectIn(line)
			};
		}

		public Edge ReflectIn(Plane plane)
		{
			return new Edge
			{
				startPoint = this.startPoint.ReflectIn(plane),
				endPoint = this.endPoint.ReflectIn(plane)
			};
		}

		public Edge Rotate(Matrix3d rotationMatrix)
		{
			return new Edge
			{
				startPoint = rotationMatrix * this.startPoint,
				endPoint = rotationMatrix * this.endPoint
			};
		}

		public Edge Rotate(Point center, Matrix3d rotationMatrix)
		{
			return new Edge
			{
				startPoint = this.startPoint.Rotate(center, rotationMatrix),
				endPoint = this.endPoint.Rotate(center, rotationMatrix)
			};
		}

		public void Round(int decimals)
		{
			this.startPoint.Round(decimals);
			this.endPoint.Round(decimals);
		}

		public Edge Scale(Point center, double scaleFactor)
		{
			return new Edge
			{
				startPoint = this.startPoint.Scale(center, scaleFactor),
				endPoint = this.endPoint.Scale(center, scaleFactor)
			};
		}

		public Edge Scale(Point center, double scaleX, double scaleY, double scaleZ)
		{
			return new Edge
			{
				startPoint = this.startPoint.Scale(center, scaleX, scaleY, scaleZ),
				endPoint = this.endPoint.Scale(center, scaleX, scaleY, scaleZ)
			};
		}

		internal static bool smethod_0(Edge edge_0, Edge edge_1)
		{
			return !(edge_0 == null | edge_1 == null) && (edge_1.CollinearContains(edge_0.StartPoint) || edge_1.CollinearContains(edge_0.EndPoint) || edge_0.CollinearContains(edge_1.StartPoint) || edge_0.CollinearContains(edge_1.EndPoint));
		}

		public static void Sort(ref List<Edge> edges, Edge.SortOrder sortBy)
		{
			switch (sortBy)
			{
			case Edge.SortOrder.Startpoint:
				edges.Sort(new CompareStartpoint());
				return;
			case Edge.SortOrder.Endpoint:
				edges.Sort(new CompareEndpoint());
				return;
			case Edge.SortOrder.Length:
				edges.Sort();
				return;
			default:
				return;
			}
		}

		public void SwapPoints()
		{
			double x = this.startPoint.X;
			double y = this.startPoint.Y;
			double z = this.startPoint.Z;
			double x2 = this.endPoint.X;
			double y2 = this.endPoint.Y;
			double z2 = this.endPoint.Z;
			this.startPoint.X = x2;
			this.startPoint.Y = y2;
			this.startPoint.Z = z2;
			this.endPoint.X = x;
			this.endPoint.Y = y;
			this.endPoint.Z = z;
		}

		public void SwapSort()
		{
			if (this.startPoint.X < this.endPoint.X)
			{
				return;
			}
			if (this.startPoint.X > this.endPoint.X)
			{
				this.SwapPoints();
				return;
			}
			if (this.startPoint.Y < this.endPoint.Y)
			{
				return;
			}
			if (this.startPoint.Y > this.endPoint.Y)
			{
				this.SwapPoints();
				return;
			}
			if (this.startPoint.Z < this.endPoint.Z)
			{
				return;
			}
			if (this.startPoint.Z > this.endPoint.Z)
			{
				this.SwapPoints();
			}
		}

		public Line ToLine()
		{
			if (this.Length < 4.94065645841247E-324)
			{
				Line line = Line.RandomLine();
				line.Point = this.startPoint;
				return line;
			}
			return new Line(this.startPoint, this.endPoint);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Edge ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  Start point: ",
				this.StartPoint.ToString(),
				Environment.NewLine,
				"  End point  : ",
				this.EndPoint.ToString(),
				Environment.NewLine,
				"  Length     : ",
				this.Length.ToString(Global.StringNumberFormat)
			});
		}

		public Edge TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			return new Edge
			{
				startPoint = this.startPoint.TransformCoordinates(actualCS, newCS),
				endPoint = this.endPoint.TransformCoordinates(actualCS, newCS)
			};
		}

		public static void TransformCoordinates(List<Edge> edges, CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d matrix3d = newCS.BasisVectorMatrix.Invert();
			Matrix3d matrix3d2 = matrix3d * basisVectorMatrix;
			double num = actualCS.Origin.X - newCS.Origin.X;
			double num2 = actualCS.Origin.Y - newCS.Origin.Y;
			double num3 = actualCS.Origin.Z - newCS.Origin.Z;
			double num4 = matrix3d.a00 * num + matrix3d.a01 * num2 + matrix3d.a02 * num3;
			double num5 = matrix3d.a10 * num + matrix3d.a11 * num2 + matrix3d.a12 * num3;
			double num6 = matrix3d.a20 * num + matrix3d.a21 * num2 + matrix3d.a22 * num3;
			for (int i = 0; i < edges.Count; i++)
			{
				Point startPoint = edges[i].StartPoint;
				Point endPoint = edges[i].EndPoint;
				double x = startPoint.X;
				double y = startPoint.Y;
				double z = startPoint.Z;
				double x2 = endPoint.X;
				double y2 = endPoint.Y;
				double z2 = endPoint.Z;
				startPoint.X = matrix3d2.a00 * x + matrix3d2.a01 * y + matrix3d2.a02 * z + num4;
				startPoint.Y = matrix3d2.a10 * x + matrix3d2.a11 * y + matrix3d2.a12 * z + num5;
				startPoint.Z = matrix3d2.a20 * x + matrix3d2.a21 * y + matrix3d2.a22 * z + num6;
				endPoint.X = matrix3d2.a00 * x2 + matrix3d2.a01 * y2 + matrix3d2.a02 * z2 + num4;
				endPoint.Y = matrix3d2.a10 * x2 + matrix3d2.a11 * y2 + matrix3d2.a12 * z2 + num5;
				endPoint.Z = matrix3d2.a20 * x2 + matrix3d2.a21 * y2 + matrix3d2.a22 * z2 + num6;
			}
		}

		public CADData CADData
		{
			get
			{
				return this.caddata_0;
			}
			set
			{
				this.caddata_0 = value;
			}
		}

		public Point EndPoint
		{
			get
			{
				return this.endPoint;
			}
			set
			{
				this.endPoint = value;
			}
		}

		public double Length
		{
			get
			{
				return this.startPoint.DistanceTo(this.endPoint);
			}
		}

		public double LengthXY
		{
			get
			{
				return this.startPoint.DistanceXY(this.endPoint);
			}
		}

		public Point MidPoint
		{
			get
			{
				return 0.5 * (this.startPoint + this.endPoint);
			}
			set
			{
				Point midPoint = this.MidPoint;
				Point right = value - midPoint;
				this.startPoint += right;
				this.endPoint += right;
			}
		}

		public Point StartPoint
		{
			get
			{
				return this.startPoint;
			}
			set
			{
				this.startPoint = value;
			}
		}

        public Autodesk.AutoCAD.DatabaseServices.Line AcDbLine{
            get
            {
                if (acDbLine == null)
                {
                    acDbLine = TerrainComputeC.My.MyDBUtility.getObject(lineHandle) as Autodesk.AutoCAD.DatabaseServices.Line;
                }
                return acDbLine;
            }
            set
            {
                acDbLine = value;
                lineHandle = acDbLine.Handle;
            }
        }
        [NonSerialized]
        Autodesk.AutoCAD.DatabaseServices.Line acDbLine;
        
        Handle lineHandle;

		private CADData caddata_0;

		private Point startPoint;

		private Point endPoint;

		public Edge.EdgeStatus Status;
        		
		public enum EdgeStatus
		{
			Defined,
			NotDefined
		}
		
		public enum SortOrder
		{
			Startpoint,
			Endpoint,
			Length
		}
	}
}
