using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class Triangle
	{
		public Triangle()
		{            
			this.point_0 = new Point();
			this.point_1 = new Point();
			this.point_2 = new Point();
		}

		public Triangle(Point point1, Point point2, Point point3)
		{            
			this.point_0 = point1;
			this.point_1 = point2;
			this.point_2 = point3;
			Vector3d vector3d_ = new Vector3d(this.point_1 - this.point_0);
			Vector3d vector3d_2 = new Vector3d(this.point_2 - this.point_0);
			if (Vector3d.smethod_0(vector3d_, vector3d_2))
			{
				throw new ArgumentException("Can not construct triangle: vertices are collinear.");
			}
		}

		public Triangle(Point point1, Point point2, Point point3, bool checkDegenerate)
		{
           
			this.point_0 = point1;
			this.point_1 = point2;
			this.point_2 = point3;
			if (checkDegenerate)
			{
				Vector3d vector3d_ = new Vector3d(this.point_1 - this.point_0);
				Vector3d vector3d_2 = new Vector3d(this.point_2 - this.point_0);
				if (Vector3d.smethod_0(vector3d_, vector3d_2))
				{
					throw new ArgumentException("Can not construct triangle: vertices are collinear.");
				}
			}
		}

		public bool Contains(Point point)
		{
			if (!Plane.smethod_0(this.Vertex1, this.NormalVector, point))
			{
				return false;
			}
			Vector3d a = new Vector3d(this.point_2 - this.point_1);
			Vector3d vector3d = new Vector3d(this.point_0 - this.point_2);
			Vector3d a2 = new Vector3d(this.point_1 - this.point_0);
			Vector3d b = new Vector3d(point - this.point_1);
			Vector3d b2 = new Vector3d(point - this.point_2);
			Vector3d b3 = new Vector3d(point - this.point_0);
			double norm = Vector3d.Cross(a, vector3d).Norm;
			double norm2 = Vector3d.Cross(a, b).Norm;
			double norm3 = Vector3d.Cross(vector3d, b2).Norm;
			double norm4 = Vector3d.Cross(a2, b3).Norm;
			return Global.AlmostEquals(norm, norm2 + norm3 + norm4);
		}

		public bool Contains(Edge edge)
		{
			return this.Contains(edge.StartPoint) & this.Contains(edge.EndPoint);
		}

		public bool Contains(Triangle triangle)
		{
			return this.Contains(triangle.Vertex1) && this.Contains(triangle.Vertex2) && this.Contains(triangle.Vertex3);
		}

		public bool Contains(Circle circle)
		{
			if (!this.NormalVector.IsParallelTo(circle.NormalVector))
			{
				return false;
			}
			if (!this.Contains(circle.Center))
			{
				return false;
			}
			double num = circle.Center.DistanceTo(this.Edge1);
			if (circle.Radius - num > Global.AbsoluteEpsilon & !Global.AlmostEquals(circle.Radius, num))
			{
				return false;
			}
			double num2 = circle.Center.DistanceTo(this.Edge2);
			if (circle.Radius - num2 > Global.AbsoluteEpsilon & !Global.AlmostEquals(circle.Radius, num2))
			{
				return false;
			}
			double num3 = circle.Center.DistanceTo(this.Edge3);
			return !(circle.Radius - num3 > Global.AbsoluteEpsilon & !Global.AlmostEquals(circle.Radius, num3));
		}

		public bool Contains(Ellipse ellipse)
		{
			return this.IsCoplanarTo(ellipse) && this.Contains(ellipse.Center) && !new Plane(this.Vertex1, this.Vertex2, this.Vertex1 + this.NormalVector.ToPoint()).Intersects3d(ellipse) && !new Plane(this.Vertex1, this.Vertex3, this.Vertex1 + this.NormalVector.ToPoint()).Intersects3d(ellipse) && !new Plane(this.Vertex2, this.Vertex3, this.Vertex2 + this.NormalVector.ToPoint()).Intersects3d(ellipse);
		}

		public bool ContainsOnCircumference(Point point)
		{
			return this.Edge1.Contains(point) || this.Edge2.Contains(point) || this.Edge3.Contains(point);
		}

		public Triangle DeepCopy()
		{
			Triangle triangle = new Triangle();
			triangle.point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z);
			triangle.point_1 = new Point(this.point_1.X, this.point_1.Y, this.point_1.Z);
			triangle.point_2 = new Point(this.point_2.X, this.point_2.Y, this.point_2.Z);
			if (this.caddata_0 != null)
			{
				triangle.caddata_0 = this.caddata_0.DeepCopy();
			}
			return triangle;
		}

		public override bool Equals(object obj)
		{
			return this == (Triangle)obj;
		}

		public Point GetBarycentricCoordinatesOfPoint(Point point)
		{
			Matrix3d matrix3d = new Matrix3d();
			matrix3d.SetColumn(0, this.point_0.method_2());
			matrix3d.SetColumn(1, this.point_1.method_2());
			matrix3d.SetColumn(2, this.point_2.method_2());
			Vector3d b = point.method_2();
			return Solver.SolveFull(matrix3d, b).ToPoint();
		}

		public override int GetHashCode()
		{
			return this.point_0.GetHashCode() ^ this.point_1.GetHashCode() ^ this.point_2.GetHashCode();
		}

		public Plane GetPlane()
		{
			return new Plane(this);
		}

		public Point GetPointFromBarycentricCoordinates(double alpha, double beta, double gamma)
		{
			double num = alpha + beta + gamma;
			if (num < 4.94065645841247E-324)
			{
				throw new ArithmeticException("Invalid barycentric coordinates.");
			}
			return 1.0 / num * (alpha * this.point_0 + beta * this.point_1 + gamma * this.point_2);
		}

		public Point GetPointFromTrilinearCoordinates(double alpha, double beta, double gamma)
		{
			double length = this.Edge1.Length;
			double length2 = this.Edge2.Length;
			double length3 = this.Edge3.Length;
			Point pointFromBarycentricCoordinates;
			try
			{
				pointFromBarycentricCoordinates = this.GetPointFromBarycentricCoordinates(length * alpha, length2 * beta, length3 * gamma);
			}
			catch
			{
				throw new ArithmeticException("Invalid trilinear coordinates.");
			}
			return pointFromBarycentricCoordinates;
		}

		public bool HasEdge(Edge edge)
		{
			return this.Edge1 == edge || this.Edge2 == edge || this.Edge3 == edge;
		}

		public bool HasVertex(Point point)
		{
			return this.point_0 == point || this.point_1 == point || this.point_2 == point;
		}

		public bool Intersects2d(Edge edge)
		{
			return edge.Intersects2d(this);
		}

		public bool Intersects2d(Line line)
		{
			return line.Intersects2d(this);
		}

		public bool Intersects2d(Triangle triangle)
		{
			PointSet pointSet = this.method_2(triangle);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects2d(Circle circle)
		{
			PointSet pointSet = this.method_3(circle);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects2d(Ellipse ellipse)
		{
			PointSet pointSet = this.method_4(ellipse);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects3d(Edge edge)
		{
			return edge.Intersects3d(this);
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
			return this.method_8(triangle) != null;
		}

		public bool Intersects3d(Circle circle)
		{
			return this.method_9(circle) != null;
		}

		public bool Intersects3d(Ellipse ellipse)
		{
			return this.method_10(ellipse) != null;
		}

		public void InvertNormalVector()
		{
			double x = this.point_1.X;
			double y = this.point_1.Y;
			double z = this.point_1.Z;
			double x2 = this.point_2.X;
			double y2 = this.point_2.Y;
			double z2 = this.point_2.Z;
			this.point_1.X = x2;
			this.point_1.Y = y2;
			this.point_1.Z = z2;
			this.point_2.X = x;
			this.point_2.Y = y;
			this.point_2.Z = z;
		}

		public bool IsCoplanarTo(Point point)
		{
			return point.IsCoplanarTo(this);
		}

		public bool IsCoplanarTo(Edge edge)
		{
			return edge.IsCoplanarTo(this);
		}

		public bool IsCoplanarTo(Line line)
		{
			return line.IsCoplanarTo(this);
		}

		public bool IsCoplanarTo(Plane plane)
		{
			return plane.IsCoplanarTo(this);
		}

		public bool IsCoplanarTo(Triangle triangle)
		{
			Plane plane = this.GetPlane();
			return plane.Contains(triangle.Vertex1) && plane.Contains(triangle.Vertex2) && plane.Contains(triangle.Vertex3);
		}

		public bool IsCoplanarTo(Circle circle)
		{
			return Plane.smethod_0(this.Vertex1, this.NormalVector, circle.Center) && this.NormalVector.IsParallelTo(circle.NormalVector);
		}

		public bool IsCoplanarTo(Ellipse ellipse)
		{
			return Plane.smethod_0(this.Vertex1, this.NormalVector, ellipse.Center) && this.NormalVector.IsParallelTo(ellipse.NormalVector);
		}

		public bool IsParallelTo(Edge edge)
		{
			return edge.IsParallelTo(this);
		}

		public bool IsParallelTo(Line line)
		{
			return line.IsParallelTo(this);
		}

		public bool IsParallelTo(Plane plane)
		{
			return plane.IsParallelTo(this);
		}

		public bool IsParallelTo(Triangle triangle)
		{
			return triangle.NormalVector.IsParallelTo(this.NormalVector);
		}

		public bool IsParallelTo(Circle circle)
		{
			return circle.NormalVector.IsParallelTo(this.NormalVector);
		}

		public bool IsParallelTo(Ellipse ellipse)
		{
			return ellipse.NormalVector.IsParallelTo(this.NormalVector);
		}

		public bool IsSimilarTo(Triangle triangle)
		{
			double[] array = new double[]
			{
				new Vector3d(this.point_1 - this.point_0).Norm,
				new Vector3d(this.point_2 - this.point_0).Norm,
				new Vector3d(this.point_2 - this.point_1).Norm
			};
			double[] array2 = new double[]
			{
				new Vector3d(triangle.point_1 - triangle.point_0).Norm,
				new Vector3d(triangle.point_2 - triangle.point_0).Norm,
				new Vector3d(triangle.point_2 - triangle.point_1).Norm
			};
			Array.Sort<double>(array);
			Array.Sort<double>(array2);
			double b = array[0] / array2[0];
			return Global.AlmostEquals(array[1] / array2[1], b) && Global.AlmostEquals(array[2] / array2[2], b);
		}

		public PointSet method_0(Edge edge)
		{
			return edge.method_0(this);
		}

		public PointSet method_1(Line line)
		{
			return line.method_0(this);
		}

		public Edge method_10(Ellipse ellipse)
		{
			Edge edge = this.GetPlane().method_6(ellipse);
			Edge edge2 = ellipse.GetPlane().getInterSection(this);
			if (edge == null | edge2 == null)
			{
				return null;
			}
			return edge.CollinearOverlap(edge2);
		}

		internal bool method_11(Point point_3)
		{
			Vector3d a = new Vector3d(this.point_2 - this.point_1);
			Vector3d vector3d = new Vector3d(this.point_0 - this.point_2);
			Vector3d a2 = new Vector3d(this.point_1 - this.point_0);
			Vector3d b = new Vector3d(point_3 - this.point_1);
			Vector3d b2 = new Vector3d(point_3 - this.point_2);
			Vector3d b3 = new Vector3d(point_3 - this.point_0);
			double norm = Vector3d.Cross(a, vector3d).Norm;
			double norm2 = Vector3d.Cross(a, b).Norm;
			double norm3 = Vector3d.Cross(vector3d, b2).Norm;
			double norm4 = Vector3d.Cross(a2, b3).Norm;
			return Global.AlmostEquals(norm, norm2 + norm3 + norm4);
		}

		public PointSet method_2(Triangle triangle)
		{
			if (!triangle.IsCoplanarTo(this))
			{
				return null;
			}
			PointSet pointSet = new PointSet();
			foreach (Edge current in this.Edges)
			{
				PointSet pointSet2 = current.method_0(triangle);
				if (pointSet2 != null)
				{
					pointSet.Add(pointSet2);
				}
			}
			if (pointSet.Count < 2)
			{
				return pointSet;
			}
			pointSet.RemoveMultiplePoints3d();
			return pointSet;
		}

		public PointSet method_3(Circle circle)
		{
			if (!circle.IsCoplanarTo(this))
			{
				return null;
			}
			PointSet pointSet = new PointSet();
			foreach (Edge current in this.Edges)
			{
				PointSet pointSet2 = current.method_1(circle);
				if (pointSet2 != null)
				{
					pointSet.Add(pointSet2);
				}
			}
			if (pointSet.Count < 2)
			{
				return pointSet;
			}
			pointSet.RemoveMultiplePoints3d();
			return pointSet;
		}

		public PointSet method_4(Ellipse ellipse)
		{
			if (!this.IsCoplanarTo(ellipse))
			{
				return null;
			}
			PointSet pointSet = new PointSet();
			foreach (Edge current in this.Edges)
			{
				PointSet pointSet2 = ellipse.method_0(current);
				if (pointSet2 != null)
				{
					pointSet.Add(pointSet2);
				}
			}
			if (pointSet.Count < 2)
			{
				return pointSet;
			}
			pointSet.RemoveMultiplePoints3d();
			return pointSet;
		}

		public Point method_5(Edge edge)
		{
			return edge.method_6(this);
		}

		public Point method_6(Line line)
		{
			return line.method_6(this);
		}

		public Edge getInterSection(Plane plane)
		{
			return plane.getInterSection(this);
		}

		public Edge method_8(Triangle triangle)
		{
			Edge edge = this.GetPlane().getInterSection(triangle);
			Edge edge2 = triangle.GetPlane().getInterSection(this);
			if (edge == null | edge2 == null)
			{
				return null;
			}
			return edge.CollinearOverlap(edge2);
		}

		public Edge method_9(Circle circle)
		{
			Edge edge = this.GetPlane().method_5(circle);
			Edge edge2 = circle.GetPlane().getInterSection(this);
			if (edge == null | edge2 == null)
			{
				return null;
			}
			return edge.CollinearOverlap(edge2);
		}

		public Triangle Move(Vector3d displacementVector)
		{
			return new Triangle
			{
				point_0 = this.point_0 + displacementVector.ToPoint(),
				point_1 = this.point_1 + displacementVector.ToPoint(),
				point_2 = this.point_2 + displacementVector.ToPoint()
			};
		}

		public Triangle Move(Point startPoint, Point endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public Edge OppositeEdge(Point vertex)
		{
			if (vertex == this.point_0)
			{
				return new Edge(this.point_1, this.point_2);
			}
			if (vertex == this.point_1)
			{
				return new Edge(this.point_0, this.point_2);
			}
			if (vertex == this.point_2)
			{
				return new Edge(this.point_0, this.point_1);
			}
			return null;
		}

		public Point OppositeVertex(Edge edge)
		{
			if (edge.HasVertex(this.point_0) && edge.HasVertex(this.point_1))
			{
				return this.point_2;
			}
			if (edge.HasVertex(this.point_0) && edge.HasVertex(this.point_2))
			{
				return this.point_1;
			}
			if (edge.HasVertex(this.point_1) && edge.HasVertex(this.point_2))
			{
				return this.point_0;
			}
			return null;
		}

		public static bool operator ==(Triangle left, Triangle right)
		{
            return (object)left == (object)right || ((object)left != null && (object)right != null && (left.Vertex1 == right.Vertex1 | left.Vertex1 == right.Vertex2 | left.Vertex1 == right.Vertex3) && (left.Vertex2 == right.Vertex1 | left.Vertex2 == right.Vertex2 | left.Vertex2 == right.Vertex3) && (left.Vertex3 == right.Vertex1 | left.Vertex3 == right.Vertex2 | left.Vertex3 == right.Vertex3));
		}

		public static bool operator !=(Triangle left, Triangle right)
		{
			return !(left == right);
		}

		public Triangle ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			if (viewDirection.IsOrthogonalTo(plane.NormalVector))
			{
				throw new ArgumentException("Can not compute projection: view direction is parallel to projection plane!");
			}
			if (viewDirection.IsOrthogonalTo(this.NormalVector))
			{
				throw new ArgumentException("Can not compute projection: view direction is parallel to triangle plane!");
			}
			return new Triangle
			{
				point_0 = this.point_0.ProjectParallelOn(plane, viewDirection),
				point_1 = this.point_1.ProjectParallelOn(plane, viewDirection),
				point_2 = this.point_2.ProjectParallelOn(plane, viewDirection)
			};
		}

		public Point RandomPointInTriangle()
		{
			double num = RandomGenerator.NextDouble_0_1();
			double num2 = RandomGenerator.NextDouble_0_1();
			double num3 = RandomGenerator.NextDouble_0_1();
			double num4 = num + num2 + num3;
			num /= num4;
			num2 /= num4;
			num3 /= num4;
			return num * this.point_0 + num2 * this.point_1 + num3 * this.point_2;
		}

		public static Triangle RandomTriangle()
		{
			Point point = Point.RandomPoint();
			Point point2 = Point.RandomPoint();
			Point point3 = Point.RandomPoint();
			Edge edge = new Edge(point, point2);
			while (point3.IsCollinearTo(edge))
			{
				point3 = Point.RandomPoint();
			}
			return new Triangle(point, point2, point3);
		}

		public Triangle ReflectIn(Point point)
		{
			return new Triangle
			{
				point_0 = this.point_0.ReflectIn(point),
				point_1 = this.point_1.ReflectIn(point),
				point_2 = this.point_2.ReflectIn(point)
			};
		}

		public Triangle ReflectIn(Line line)
		{
			Point point = this.point_0.ReflectIn(line);
			Point point2 = this.point_1.ReflectIn(line);
			Point point3 = this.point_2.ReflectIn(line);
			return new Triangle(point, point2, point3);
		}

		public Triangle ReflectIn(Plane plane)
		{
			Point point = this.point_0.ReflectIn(plane);
			Point point2 = this.point_1.ReflectIn(plane);
			Point point3 = this.point_2.ReflectIn(plane);
			return new Triangle(point, point2, point3);
		}

		public Triangle Rotate(Matrix3d rotationMatrix)
		{
			return new Triangle
			{
				point_0 = rotationMatrix * this.point_0,
				point_1 = rotationMatrix * this.point_1,
				point_2 = rotationMatrix * this.point_2
			};
		}

		public Triangle Rotate(Point center, Matrix3d rotationMatrix)
		{
			return new Triangle
			{
				point_0 = this.point_0.Rotate(center, rotationMatrix),
				point_1 = this.point_1.Rotate(center, rotationMatrix),
				point_2 = this.point_2.Rotate(center, rotationMatrix)
			};
		}

		public void Round(int decimals)
		{
			this.point_0.Round(decimals);
			this.point_1.Round(decimals);
			this.point_2.Round(decimals);
		}

		public Triangle Scale(Point center, double scaleFactor)
		{
			Triangle triangle = new Triangle();
			triangle.point_0 = this.point_0.Scale(center, scaleFactor);
			triangle.point_1 = this.point_1.Scale(center, scaleFactor);
			triangle.point_2 = this.point_2.Scale(center, scaleFactor);
			Vector3d vector3d_ = new Vector3d(triangle.point_1 - triangle.point_0);
			Vector3d vector3d_2 = new Vector3d(triangle.point_2 - triangle.point_0);
			if (Vector3d.smethod_0(vector3d_, vector3d_2))
			{
				throw new ArgumentException("Scale factor is too small: vertices are collinear.");
			}
			return triangle;
		}

		public Triangle Scale(Point center, double scaleX, double scaleY, double scaleZ)
		{
			Triangle triangle = new Triangle();
			triangle.point_0 = this.point_0.Scale(center, scaleX, scaleY, scaleZ);
			triangle.point_1 = this.point_1.Scale(center, scaleX, scaleY, scaleZ);
			triangle.point_2 = this.point_2.Scale(center, scaleX, scaleY, scaleZ);
			Vector3d vector3d_ = new Vector3d(triangle.point_1 - triangle.point_0);
			Vector3d vector3d_2 = new Vector3d(triangle.point_2 - triangle.point_0);
			if (Vector3d.smethod_0(vector3d_, vector3d_2))
			{
				throw new ArgumentException("Scale factor is too small: vertices are collinear.");
			}
			return triangle;
		}

		public bool SharesEdgeWith(Triangle triangle)
		{
			int num = 0;
			if (this.point_0 == triangle.point_0 | this.point_0 == triangle.point_1 | this.point_0 == triangle.point_2)
			{
				num++;
			}
			if (this.point_1 == triangle.point_0 | this.point_1 == triangle.point_1 | this.point_1 == triangle.point_2)
			{
				num++;
			}
			if (this.point_2 == triangle.point_0 | this.point_2 == triangle.point_1 | this.point_2 == triangle.point_2)
			{
				num++;
			}
			return num == 2;
		}

		public bool SharesVertexWith(Triangle triangle)
		{
			return this.point_0 == triangle.point_0 || this.point_0 == triangle.point_1 || this.point_0 == triangle.point_2 || this.point_1 == triangle.point_0 || this.point_1 == triangle.point_1 || this.point_1 == triangle.point_2 || this.point_2 == triangle.point_0 || this.point_2 == triangle.point_1 || this.point_2 == triangle.point_2;
		}

		public List<Triangle> Slice(Plane slicingPlane, Triangle.SliceMethod slicingMethod)
		{
			return this.Slice(slicingPlane, slicingMethod, false);
		}

		public List<Triangle> Slice(Plane slicingPlane, Triangle.SliceMethod slicingMethod, bool keepCoplanar)
		{
			return this.Slice(slicingPlane, slicingMethod, false, true);
		}

		public List<Triangle> Slice(Plane slicingPlane, Triangle.SliceMethod slicingMethod, bool keepCoplanar, bool checkDegenerate)
		{
			List<Triangle> list = new List<Triangle>();
			Triangle triangle = this.DeepCopy();
			new Edge();
			double value = triangle.point_0.DistanceTo(slicingPlane);
			double value2 = triangle.point_1.DistanceTo(slicingPlane);
			double value3 = triangle.point_2.DistanceTo(slicingPlane);
			if (Math.Abs(value) < Global.AbsoluteEpsilon)
			{
				value = 0.0;
			}
			if (Math.Abs(value2) < Global.AbsoluteEpsilon)
			{
				value2 = 0.0;
			}
			if (Math.Abs(value3) < Global.AbsoluteEpsilon)
			{
				value3 = 0.0;
			}
			int num = Math.Sign(value);
			int num2 = Math.Sign(value2);
			int num3 = Math.Sign(value3);
			Point point = slicingPlane.Point + slicingPlane.NormalVector.ToPoint();
			int num4 = Math.Sign(point.DistanceTo(slicingPlane));
			if (num == 0 & num2 == 0 & num3 == 0)
			{
				if (keepCoplanar)
				{
					list.Add(triangle);
				}
			}
			else if (num == num2 & num == num3)
			{
				list.Add(triangle);
			}
			else if ((num != 0 ^ num2 != 0 ^ num3 != 0) & !(Math.Abs(num) == 1 & Math.Abs(num2) == 1 & Math.Abs(num3) == 1))
			{
				list.Add(triangle);
			}
			else if (num == 0 ^ num2 == 0 ^ num3 == 0)
			{
				if (num == 1 ^ num2 == 1 ^ num3 == 1)
				{
					if (num == 0)
					{
						Point point2 = triangle.Edge1.method_5(slicingPlane);
						Triangle item = new Triangle(triangle.point_0, triangle.point_1, point2, checkDegenerate);
						Triangle item2 = new Triangle(triangle.point_0, point2, triangle.point_2, checkDegenerate);
						list.Add(item);
						list.Add(item2);
					}
					else if (num2 == 0)
					{
						Point point3 = triangle.Edge2.method_5(slicingPlane);
						Triangle item3 = new Triangle(triangle.point_1, point3, triangle.point_0, checkDegenerate);
						Triangle item4 = new Triangle(triangle.point_1, triangle.point_2, point3, checkDegenerate);
						list.Add(item3);
						list.Add(item4);
					}
					else if (num3 == 0)
					{
						Point point4 = triangle.Edge3.method_5(slicingPlane);
						Triangle item5 = new Triangle(triangle.point_2, triangle.point_0, point4, checkDegenerate);
						Triangle item6 = new Triangle(triangle.point_2, point4, triangle.point_1, checkDegenerate);
						list.Add(item5);
						list.Add(item6);
					}
				}
				else
				{
					list.Add(triangle);
				}
			}
			else if (num != num2 & num != num3)
			{
				Point point5 = triangle.Edge2.method_5(slicingPlane);
				Point point6 = triangle.Edge3.method_5(slicingPlane);
				Triangle item7 = new Triangle(triangle.point_0, point6, point5, checkDegenerate);
				Triangle item8 = new Triangle(triangle.point_1, point5, point6, checkDegenerate);
				Triangle item9 = new Triangle(triangle.point_2, point5, triangle.point_1, checkDegenerate);
				list.Add(item7);
				list.Add(item8);
				list.Add(item9);
			}
			else if (num2 != num & num2 != num3)
			{
				Point point7 = triangle.Edge1.method_5(slicingPlane);
				Point point8 = triangle.Edge3.method_5(slicingPlane);
				Triangle item10 = new Triangle(triangle.point_1, point7, point8, checkDegenerate);
				Triangle item11 = new Triangle(triangle.point_0, point8, point7, checkDegenerate);
				Triangle item12 = new Triangle(triangle.point_2, triangle.point_0, point7, checkDegenerate);
				list.Add(item10);
				list.Add(item11);
				list.Add(item12);
			}
			else if (num3 != num & num3 != num2)
			{
				Point point9 = triangle.Edge1.method_5(slicingPlane);
				Point point10 = triangle.Edge2.method_5(slicingPlane);
				Triangle item13 = new Triangle(triangle.point_2, point10, point9, checkDegenerate);
				Triangle item14 = new Triangle(triangle.point_0, point9, point10, checkDegenerate);
				Triangle item15 = new Triangle(triangle.point_1, point9, triangle.point_0, checkDegenerate);
				list.Add(item13);
				list.Add(item15);
				list.Add(item14);
			}
			switch (slicingMethod)
			{
			case Triangle.SliceMethod.KeepAbove:
				for (int i = list.Count - 1; i >= 0; i--)
				{
					if (Math.Sign(list[i].Center.DistanceTo(slicingPlane)) != num4)
					{
						list.RemoveAt(i);
					}
				}
				break;
			case Triangle.SliceMethod.KeepBelow:
				for (int j = list.Count - 1; j >= 0; j--)
				{
					if (Math.Sign(list[j].Center.DistanceTo(slicingPlane)) == num4)
					{
						list.RemoveAt(j);
					}
				}
				break;
			}
			return list;
		}

		public static void Sort(List<Triangle> triangles, Triangle.SortOrder sortOrder)
		{
			switch (sortOrder)
			{
			case Triangle.SortOrder.MinX:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMinX();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.MaxX:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMaxX();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.MinY:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMinY();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.MaxY:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMaxY();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.MinZ:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMinZ();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.MaxZ:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMaxZ();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.Area:
			{
				IComparer<Triangle> comparer = new Triangle.CompareArea();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.CenterZ:
			{
				IComparer<Triangle> comparer = new Triangle.CompareCenterZ();
				triangles.Sort(comparer);
				return;
			}
			case Triangle.SortOrder.MinimumAngle:
			{
				IComparer<Triangle> comparer = new Triangle.CompareMinimumAngle();
				triangles.Sort(comparer);
				return;
			}
			default:
				throw new ArgumentException("Invalid comparer.");
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Triangle " + this.GetHashCode().ToString() + ":");
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Vertex 1     :");
			stringBuilder.Append(" " + this.point_0.ToString());
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Vertex 2     :");
			stringBuilder.Append(" " + this.point_1.ToString());
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Vertex 3     :");
			stringBuilder.Append(" " + this.point_2.ToString());
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Normal vector:");
			stringBuilder.Append(" " + this.NormalVector.ToString());
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Area         :");
			stringBuilder.Append(" " + this.Area.ToString(Global.StringNumberFormat));
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Circumference:");
			stringBuilder.Append(" " + this.Circumference.ToString(Global.StringNumberFormat));
			stringBuilder.Append(Environment.NewLine);
			stringBuilder.Append("  Center       :");
			stringBuilder.Append(" " + this.Center.ToString());
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}

		public Triangle TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Triangle triangle = new Triangle();
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d basisVectorMatrix2 = newCS.BasisVectorMatrix;
			Point b = actualCS.Origin - newCS.Origin;
			Matrix3d a = basisVectorMatrix2.Invert();
			Matrix3d a2 = a * basisVectorMatrix;
			Point right = a * b;
			triangle.point_0 = a2 * this.point_0 + right;
			triangle.point_1 = a2 * this.point_1 + right;
			triangle.point_2 = a2 * this.point_2 + right;
			return triangle;
		}

		public static void TransformCoordinates(List<Triangle> triangles, CoordinateSystem actualCS, CoordinateSystem newCS)
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
			for (int i = 0; i < triangles.Count; i++)
			{
				Point point = triangles[i].point_0;
				Point point2 = triangles[i].point_1;
				Point point3 = triangles[i].point_2;
				double x = point.X;
				double y = point.Y;
				double z = point.Z;
				point.X = matrix3d2.a00 * x + matrix3d2.a01 * y + matrix3d2.a02 * z + num4;
				point.Y = matrix3d2.a10 * x + matrix3d2.a11 * y + matrix3d2.a12 * z + num5;
				point.Z = matrix3d2.a20 * x + matrix3d2.a21 * y + matrix3d2.a22 * z + num6;
				double x2 = point2.X;
				double y2 = point2.Y;
				double z2 = point2.Z;
				point2.X = matrix3d2.a00 * x2 + matrix3d2.a01 * y2 + matrix3d2.a02 * z2 + num4;
				point2.Y = matrix3d2.a10 * x2 + matrix3d2.a11 * y2 + matrix3d2.a12 * z2 + num5;
				point2.Z = matrix3d2.a20 * x2 + matrix3d2.a21 * y2 + matrix3d2.a22 * z2 + num6;
				double x3 = point3.X;
				double y3 = point3.Y;
				double z3 = point3.Z;
				point3.X = matrix3d2.a00 * x3 + matrix3d2.a01 * y3 + matrix3d2.a02 * z3 + num4;
				point3.Y = matrix3d2.a10 * x3 + matrix3d2.a11 * y3 + matrix3d2.a12 * z3 + num5;
				point3.Z = matrix3d2.a20 * x3 + matrix3d2.a21 * y3 + matrix3d2.a22 * z3 + num6;
			}
		}

		public double Area
		{
			get
			{
				double num = this.point_1.X - this.point_0.X;
				double num2 = this.point_1.Y - this.point_0.Y;
				double num3 = this.point_1.Z - this.point_0.Z;
				double num4 = this.point_2.X - this.point_0.X;
				double num5 = this.point_2.Y - this.point_0.Y;
				double num6 = this.point_2.Z - this.point_0.Z;
				double num7 = num2 * num6 - num3 * num5;
				double num8 = num3 * num4 - num * num6;
				double num9 = num * num5 - num2 * num4;
				return 0.5 * Math.Sqrt(num7 * num7 + num8 * num8 + num9 * num9);
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

		public Point Center
		{
			get
			{
				Point point = new Point();
				double num = 0.33333333333333331;
				point.X = num * (this.point_0.X + this.point_1.X + this.point_2.X);
				point.Y = num * (this.point_0.Y + this.point_1.Y + this.point_2.Y);
				point.Z = num * (this.point_0.Z + this.point_1.Z + this.point_2.Z);
				return point;
			}
		}

		public Circle Circumcircle
		{
			get
			{
				double num = this.point_2.X - this.point_1.X;
				double num2 = this.point_2.Y - this.point_1.Y;
				double num3 = this.point_2.Z - this.point_1.Z;
				double num4 = this.point_2.X - this.point_0.X;
				double num5 = this.point_2.Y - this.point_0.Y;
				double num6 = this.point_2.Z - this.point_0.Z;
				double num7 = this.point_1.X - this.point_0.X;
				double num8 = this.point_1.Y - this.point_0.Y;
				double num9 = this.point_1.Z - this.point_0.Z;
				double num10 = num * num + num2 * num2 + num3 * num3;
				double num11 = num4 * num4 + num5 * num5 + num6 * num6;
				double num12 = num7 * num7 + num8 * num8 + num9 * num9;
				double area = this.Area;
				double alpha = num10 * (-num10 + num11 + num12);
				double beta = num11 * (num10 - num11 + num12);
				double gamma = num12 * (num10 + num11 - num12);
				Circle result;
				try
				{
					Point pointFromBarycentricCoordinates = this.GetPointFromBarycentricCoordinates(alpha, beta, gamma);
					double radius = Math.Sqrt(num10 * num11 * num12) / (4.0 * area);
					result = new Circle(pointFromBarycentricCoordinates, radius, this.NormalVector);
				}
				catch
				{
					throw new ArithmeticException("Can not compute circumcircle. Triangle is degenerate.");
				}
				return result;
			}
		}

		public double Circumference
		{
			get
			{
				Vector3d vector3d = new Vector3d(this.point_1 - this.point_0);
				Vector3d vector3d2 = new Vector3d(this.point_2 - this.point_0);
				Vector3d vector3d3 = new Vector3d(this.point_2 - this.point_1);
				return vector3d.Norm + vector3d2.Norm + vector3d3.Norm;
			}
		}

		public Triangle ContactTriangle
		{
			get
			{
				Circle incircle = this.Incircle;
				Point endPoint = incircle.Center.PerpendicularOn(this.Edge1.ToLine()).EndPoint;
				Point endPoint2 = incircle.Center.PerpendicularOn(this.Edge2.ToLine()).EndPoint;
				Point endPoint3 = incircle.Center.PerpendicularOn(this.Edge3.ToLine()).EndPoint;
				return new Triangle(endPoint, endPoint2, endPoint3);
			}
		}

		public Edge Edge1
		{
			get
			{
				return new Edge(this.point_1, this.point_2);
			}
		}

		public Edge Edge2
		{
			get
			{
				return new Edge(this.point_2, this.point_0);
			}
		}

		public Edge Edge3
		{
			get
			{
				return new Edge(this.point_0, this.point_1);
			}
		}

		public List<Edge> Edges
		{
			get
			{
				return new List<Edge>
				{
					this.Edge1,
					this.Edge2,
					this.Edge3
				};
			}
		}

		public Line EulerLine
		{
			get
			{
				if (this.IsEquilateral)
				{
					return null;
				}
				Line result;
				try
				{
					result = new Line(this.Center, this.Orthocenter);
				}
				catch
				{
					throw new ArithmeticException("Can not compute Euler line. Triangle is degenerate.");
				}
				return result;
			}
		}

		public List<Circle> Excircles
		{
			get
			{
				List<Circle> list = new List<Circle>();
				double length = this.Edge1.Length;
				double length2 = this.Edge2.Length;
				double length3 = this.Edge3.Length;
				double area = this.Area;
				Vector3d normalVector = this.NormalVector;
				try
				{
					Point pointFromBarycentricCoordinates = this.GetPointFromBarycentricCoordinates(-length, length2, length3);
					double radius = 2.0 * area / (-length + length2 + length3);
					Point pointFromBarycentricCoordinates2 = this.GetPointFromBarycentricCoordinates(length, -length2, length3);
					double radius2 = 2.0 * area / (length - length2 + length3);
					Point pointFromBarycentricCoordinates3 = this.GetPointFromBarycentricCoordinates(length, length2, -length3);
					double radius3 = 2.0 * area / (length + length2 - length3);
					list.Add(new Circle(pointFromBarycentricCoordinates, radius, normalVector));
					list.Add(new Circle(pointFromBarycentricCoordinates2, radius2, normalVector));
					list.Add(new Circle(pointFromBarycentricCoordinates3, radius3, normalVector));
				}
				catch
				{
					throw new ArithmeticException("Can not compute excircles. Triangle is degenerate.");
				}
				return list;
			}
		}

		public Circle Incircle
		{
			get
			{
				double length = this.Edge1.Length;
				double length2 = this.Edge2.Length;
				double length3 = this.Edge3.Length;
				double area = this.Area;
				Vector3d normalVector = this.NormalVector;
				Circle result;
				try
				{
					double radius = 2.0 * area / (length + length2 + length3);
					Point pointFromBarycentricCoordinates = this.GetPointFromBarycentricCoordinates(length, length2, length3);
					result = new Circle(pointFromBarycentricCoordinates, radius, normalVector);
				}
				catch
				{
					throw new ArithmeticException("Can not compute incircle. Triangle is degenerate.");
				}
				return result;
			}
		}

		public bool IsEquilateral
		{
			get
			{
				double length = this.Edge1.Length;
				double length2 = this.Edge2.Length;
				double length3 = this.Edge3.Length;
				return Global.AlmostEquals(length, length2) & Global.AlmostEquals(length, length3);
			}
		}

		public double MaximumAngle
		{
			get
			{
				double val = Vector3d.Angle(new Vector3d(this.point_1 - this.point_0), new Vector3d(this.point_2 - this.point_0));
				double val2 = Vector3d.Angle(new Vector3d(this.point_0 - this.point_1), new Vector3d(this.point_2 - this.point_1));
				double val3 = Vector3d.Angle(new Vector3d(this.point_0 - this.point_2), new Vector3d(this.point_1 - this.point_2));
				return Math.Max(val, Math.Max(val2, val3));
			}
		}

		public double MaximumX
		{
			get
			{
				return Math.Max(this.point_0.X, Math.Max(this.point_1.X, this.point_2.X));
			}
		}

		public double MaximumY
		{
			get
			{
				return Math.Max(this.point_0.Y, Math.Max(this.point_1.Y, this.point_2.Y));
			}
		}

		public double MaximumZ
		{
			get
			{
				return Math.Max(this.point_0.Z, Math.Max(this.point_1.Z, this.point_2.Z));
			}
		}

		public double MinimumAngle
		{
			get
			{
				double val = Vector3d.Angle(new Vector3d(this.point_1 - this.point_0), new Vector3d(this.point_2 - this.point_0));
				double val2 = Vector3d.Angle(new Vector3d(this.point_0 - this.point_1), new Vector3d(this.point_2 - this.point_1));
				double val3 = Vector3d.Angle(new Vector3d(this.point_0 - this.point_2), new Vector3d(this.point_1 - this.point_2));
				return Math.Min(val, Math.Min(val2, val3));
			}
		}

		public double MinimumX
		{
			get
			{
				return Math.Min(this.point_0.X, Math.Min(this.point_1.X, this.point_2.X));
			}
		}

		public double MinimumY
		{
			get
			{
				return Math.Min(this.point_0.Y, Math.Min(this.point_1.Y, this.point_2.Y));
			}
		}

		public double MinimumZ
		{
			get
			{
				return Math.Min(this.point_0.Z, Math.Min(this.point_1.Z, this.point_2.Z));
			}
		}

		public Circle NinePointCircle
		{
			get
			{
				Circle result;
				try
				{
					Point midPoint = new Edge(this.Orthocenter, this.Circumcircle.Center).MidPoint;
					double radius = 0.5 * this.Circumcircle.Radius;
					result = new Circle(midPoint, radius, this.NormalVector);
				}
				catch
				{
					throw new ArithmeticException("Can not compute nine-point-circle. Triangle is degenerate.");
				}
				return result;
			}
		}

		public Vector3d NormalVector
		{
			get
			{
				Vector3d a = new Vector3d(this.point_1 - this.point_0);
				Vector3d b = new Vector3d(this.point_2 - this.point_0);
				return Vector3d.Cross(a, b);
			}
		}

		public Point Orthocenter
		{
			get
			{
				double length = this.Edge1.Length;
				double length2 = this.Edge2.Length;
				double length3 = this.Edge3.Length;
				double arg_2A_0 = this.Area;
				double num = length * length + length2 * length2 - length3 * length3;
				double num2 = length * length - length2 * length2 + length3 * length3;
				double num3 = length * length - length2 * length2 + length3 * length3;
				double num4 = -length * length + length2 * length2 + length3 * length3;
				double alpha = num * num3;
				double beta = num * num4;
				double gamma = num2 * num4;
				Point pointFromBarycentricCoordinates;
				try
				{
					pointFromBarycentricCoordinates = this.GetPointFromBarycentricCoordinates(alpha, beta, gamma);
				}
				catch
				{
					throw new ArithmeticException("Can not compute orthocenter. Triangle is degenerate.");
				}
				return pointFromBarycentricCoordinates;
			}
		}

		public Point SymmedianPoint
		{
			get
			{
				double length = this.Edge1.Length;
				double length2 = this.Edge2.Length;
				double length3 = this.Edge3.Length;
				double alpha = length * length;
				double beta = length2 * length2;
				double gamma = length3 * length3;
				Point pointFromBarycentricCoordinates;
				try
				{
					pointFromBarycentricCoordinates = this.GetPointFromBarycentricCoordinates(alpha, beta, gamma);
				}
				catch
				{
					throw new ArithmeticException("Can not compute symmedian point. Triangle is degenerate.");
				}
				return pointFromBarycentricCoordinates;
			}
		}

		public Triangle TangentialTriangle
		{
			get
			{
				if (!this.Contains(this.Circumcircle.Center))
				{
					return null;
				}
				double length = this.Edge1.Length;
				double length2 = this.Edge2.Length;
				double length3 = this.Edge3.Length;
				Triangle result;
				try
				{
					Point pointFromTrilinearCoordinates = this.GetPointFromTrilinearCoordinates(-length, length2, length3);
					Point pointFromTrilinearCoordinates2 = this.GetPointFromTrilinearCoordinates(length, -length2, length3);
					Point pointFromTrilinearCoordinates3 = this.GetPointFromTrilinearCoordinates(length, length2, -length3);
					result = new Triangle(pointFromTrilinearCoordinates, pointFromTrilinearCoordinates2, pointFromTrilinearCoordinates3);
				}
				catch
				{
					throw new ArithmeticException("Can not compute tangential triangle. Triangle is degenerate.");
				}
				return result;
			}
		}

		public Point Vertex1
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				Vector3d vector3d_ = new Vector3d(this.point_1 - this.point_0);
				Vector3d vector3d_2 = new Vector3d(this.point_2 - this.point_0);
				if (Vector3d.smethod_0(vector3d_, vector3d_2))
				{
					throw new ArgumentException("Triangle vertices are collinear.");
				}
			}
		}

		public Point Vertex2
		{
			get
			{
				return this.point_1;
			}
			set
			{
				this.point_1 = value;
				Vector3d vector3d_ = new Vector3d(this.point_0 - this.point_1);
				Vector3d vector3d_2 = new Vector3d(this.point_2 - this.point_1);
				if (Vector3d.smethod_0(vector3d_, vector3d_2))
				{
					throw new ArgumentException("Triangle vertices are collinear.");
				}
			}
		}

		public Point Vertex3
		{
			get
			{
				return this.point_2;
			}
			set
			{
				this.point_2 = value;
				Vector3d vector3d_ = new Vector3d(this.point_0 - this.point_2);
				Vector3d vector3d_2 = new Vector3d(this.point_1 - this.point_2);
				if (Vector3d.smethod_0(vector3d_, vector3d_2))
				{
					throw new ArgumentException("Triangle vertices are collinear.");
				}
			}
		}

		public PointSet Vertices
		{
			get
			{
				return new PointSet
				{
					this.point_0,
					this.point_1,
					this.point_2
				};
			}
		}
        [NonSerialized]
		Face acDbFace;
        public Face AcDbFace
        {
            get {
                if (acDbFace == null)
                {
                    /*acDbFace = TerrainComputeC.My.MyDBUtility.getObject(faceHandle) as Face;*///handle 不用了
                }
                return acDbFace;
            }
            set
            {
                acDbFace = value;
            }
        }
        public Handle FaceHandle
        {
            get
            {
                return AcDbFace.Handle;
            }
            set
            {
                faceHandle = value;
            }
        }
        [NonSerialized]//handle暂时不用了，不用将face的信息存到mydb里
        Handle faceHandle;

		private CADData caddata_0;

		private Point point_0;

		private Point point_1;

		private Point point_2;
		public class CompareArea : IComparer<Triangle>
		{
			public CompareArea()
			{                
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.Area.CompareTo(right.Area);
			}
		}
        		
		public class CompareCenterZ : IComparer<Triangle>
		{
			public CompareCenterZ()
			{
                
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.Center.Z.CompareTo(right.Center.Z);
			}
		}		
		public class CompareMaxX : IComparer<Triangle>
		{
			public CompareMaxX()
			{                
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MaximumX.CompareTo(right.MaximumX);
			}
		}		
		public class CompareMaxY : IComparer<Triangle>
		{
			public CompareMaxY()
			{
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MaximumY.CompareTo(right.MaximumY);
			}
		}		
		public class CompareMaxZ : IComparer<Triangle>
		{
			public CompareMaxZ()
			{
                
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MaximumZ.CompareTo(right.MaximumZ);
			}
		}
        	
		public class CompareMinimumAngle : IComparer<Triangle>
		{
			public CompareMinimumAngle()
			{
               
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MinimumAngle.CompareTo(right.MinimumAngle);
			}
		}

		public class CompareMinX : IComparer<Triangle>
		{
			public CompareMinX()
			{
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MinimumX.CompareTo(right.MinimumX);
			}
		}

		public class CompareMinY : IComparer<Triangle>
		{
			public CompareMinY()
			{
                
			}

			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MinimumY.CompareTo(right.MinimumY);
			}
		}
		public class CompareMinZ : IComparer<Triangle>
		{
			public CompareMinZ()
			{
                
			}
			int IComparer<Triangle>.Compare(Triangle left, Triangle right)
			{
				return left.MinimumZ.CompareTo(right.MinimumZ);
			}
		}		
		public enum SliceMethod
		{
			KeepBoth = 1,
			KeepAbove,
			KeepBelow
		}		
		public enum SortOrder
		{
			MinX,
			MaxX,
			MinY,
			MaxY,
			MinZ,
			MaxZ,
			Area,
			CenterZ,
			MinimumAngle
		}
	}
}
