using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class Plane
	{
		public Plane()
		{
            
		}

		internal Plane(Triangle triangle)
		{
          
			this.point_0 = triangle.Vertex1;
			this.vector3d_0 = new Vector3d(triangle.Vertex2 - triangle.Vertex1);
			this.vector3d_1 = new Vector3d(triangle.Vertex3 - triangle.Vertex1);
			this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
		}

		internal Plane(Circle circle)
		{
            
			this.point_0 = circle.Center;
			this.vector3d_2 = circle.NormalVector;
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
			this.vector3d_0 = this.vector3d_2.RandomOrthonormal();
			this.vector3d_1 = Vector3d.Cross(this.vector3d_2, this.vector3d_0).Normalize();
		}

		internal Plane(Ellipse ellipse)
		{
           
			this.point_0 = ellipse.Center;
			this.vector3d_0 = ellipse.SemimajorAxisVector.Normalize();
			this.vector3d_1 = ellipse.SemiminorAxisVector.Normalize();
			this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
		}

		public Plane(Point point, Vector3d normalVector)
		{
            
			this.point_0 = point;
			this.vector3d_2 = normalVector;
			if (this.vector3d_2.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Invalid plane definition: normal vector length is zero.");
			}
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
			this.vector3d_0 = this.vector3d_2.RandomOrthonormal();
			this.vector3d_1 = Vector3d.Cross(this.vector3d_2, this.vector3d_0).Normalize();
		}

		public Plane(Vector3d normalVector, double d)
		{
            
			this.vector3d_2 = normalVector;
			if (this.vector3d_2.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Invalid plane definition: normal vector length is zero.");
			}
			this.double_0 = d;
			this.vector3d_0 = this.vector3d_2.RandomOrthonormal();
			this.vector3d_1 = Vector3d.Cross(this.vector3d_2, this.vector3d_0);
			Point point = new Point();
			point.X = 0.0;
			point.Y = 0.0;
			point.Z = 0.0;
			if (this.vector3d_2.X != 0.0)
			{
				point.X = this.double_0 / this.vector3d_2.X;
			}
			else if (this.vector3d_2.Y != 0.0)
			{
				point.Y = this.double_0 / this.vector3d_2.Y;
			}
			else if (this.vector3d_2.Z != 0.0)
			{
				point.Z = this.double_0 / this.vector3d_2.Z;
			}
			this.point_0 = point - new Point(this.vector3d_0 - this.vector3d_1);
		}

		public Plane(Point point1, Point point2, Point point3)
		{
           
			this.point_0 = point1;
			this.vector3d_0 = new Vector3d(point2 - point1);
			this.vector3d_1 = new Vector3d(point3 - point1);
			if (this.vector3d_0.IsParallelTo(this.vector3d_1))
			{
				throw new ArgumentException("Invalid plane definition: collinear points!");
			}
			this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
		}

		public Plane(Point point, Vector3d directionVector1, Vector3d directionVector2)
		{
            
			this.point_0 = point;
			this.vector3d_0 = directionVector1;
			this.vector3d_1 = directionVector2;
			if (this.vector3d_0.IsParallelTo(this.vector3d_1))
			{
				throw new ArgumentException("Invalid plane definition: parallel direction vectors!");
			}
			this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
		}

		public Plane(double A, double B, double C)
		{
            
			Point right = new Point(0.0, 0.0, A * 0.0 + B * 0.0 + C);
			Point left = new Point(1.0, 0.0, A * 1.0 + B * 0.0 + C);
			Point left2 = new Point(0.0, 1.0, A * 0.0 + B * 1.0 + C);
			this.point_0 = right;
			this.vector3d_0 = new Vector3d(left - right);
			this.vector3d_1 = new Vector3d(left2 - right);
			if (this.vector3d_0.IsParallelTo(this.vector3d_1))
			{
				throw new ArgumentException("Invalid plane definition: parallel direction vectors!");
			}
			this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
			this.double_0 = this.point_0.X * this.vector3d_2.X + this.point_0.Y * this.vector3d_2.Y + this.point_0.Z * this.vector3d_2.Z;
		}

		public double Angle(Line line)
		{
			return line.Angle(this);
		}

		public double Angle(Plane plane)
		{
			return Vector3d.Angle(this.NormalVector, plane.NormalVector);
		}

		public Plane Bisector(Plane plane)
		{
			Line line = this.method_2(plane);
			if (!(line == null))
			{
				Point point = line.Point;
				return new Plane(point, Vector3d.Bisector(this.NormalVector, plane.NormalVector));
			}
			if (this == plane)
			{
				return this.DeepCopy();
			}
			throw new ArgumentException("Can not compute bisecting plane: planes do not intersect!");
		}

		public bool Contains(Point point)
		{
			if (point == null)
			{
				return false;
			}
			double a = this.vector3d_2.X * point.X + this.vector3d_2.Y * point.Y + this.vector3d_2.Z * point.Z;
			return Global.AlmostEquals(a, this.double_0);
		}

		public bool Contains(Edge edge)
		{
			return this.Contains(edge.StartPoint) & this.Contains(edge.EndPoint);
		}

		public bool Contains(Line line)
		{
			return this.Contains(line.Point) & this.Contains(line.Point + line.DirectionVector.Normalize().ToPoint());
		}

		public bool Contains(Triangle triangle)
		{
			return this.Contains(triangle.Vertex1) && this.Contains(triangle.Vertex2) && this.Contains(triangle.Vertex3);
		}

		public bool Contains(Circle circle)
		{
			return this.Contains(circle.Center) && this.vector3d_2.IsParallelTo(circle.NormalVector);
		}

		public bool Contains(Ellipse ellipse)
		{
			return this.Contains(ellipse.Center) && this.vector3d_2.IsParallelTo(ellipse.NormalVector);
		}

		public Plane DeepCopy()
		{
			return new Plane
			{
				point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z),
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z),
				vector3d_1 = new Vector3d(this.vector3d_1.X, this.vector3d_1.Y, this.vector3d_1.Z),
				vector3d_2 = new Vector3d(this.vector3d_2.X, this.vector3d_2.Y, this.vector3d_2.Z),
				double_0 = this.double_0
			};
		}

		public double DistanceTo(Point point)
		{
			return point.DistanceTo(this);
		}

		public double DistanceTo(Edge edge)
		{
			double num = edge.StartPoint.DistanceTo(this);
			double num2 = edge.EndPoint.DistanceTo(this);
			if (Math.Sign(num) != Math.Sign(num2))
			{
				return 0.0;
			}
			if (Math.Abs(num) < Math.Abs(num2))
			{
				return num;
			}
			return num2;
		}

		public double DistanceTo(Triangle triangle)
		{
			double num = triangle.Vertex1.DistanceTo(this);
			double num2 = triangle.Vertex2.DistanceTo(this);
			double num3 = triangle.Vertex3.DistanceTo(this);
			if (Math.Sign(num) != Math.Sign(num2))
			{
				return 0.0;
			}
			if (Math.Sign(num) != Math.Sign(num3))
			{
				return 0.0;
			}
			if (Math.Sign(num2) != Math.Sign(num3))
			{
				return 0.0;
			}
			if (Math.Abs(num) < Math.Abs(num2) && Math.Abs(num) < Math.Abs(num3))
			{
				return num;
			}
			if (Math.Abs(num2) < Math.Abs(num3))
			{
				return num2;
			}
			return num3;
		}

		public double DistanceTo(Circle circle)
		{
			Vector3d a = Vector3d.Cross(this.vector3d_2, circle.NormalVector);
			Vector3d vector3d = Vector3d.Cross(a, circle.NormalVector);
			vector3d.Norm = circle.Radius;
			Vector3d vector3d2 = -1.0 * vector3d;
			Point point = circle.Center + vector3d.ToPoint();
			Point point2 = circle.Center + vector3d2.ToPoint();
			double value = point.DistanceTo(this);
			double value2 = point2.DistanceTo(this);
			if (Math.Sign(value) != Math.Sign(value2))
			{
				return 0.0;
			}
			return Math.Min(Math.Abs(value), Math.Abs(value2));
		}

		public override bool Equals(object obj)
		{
			return this == (Plane)obj;
		}

		public override int GetHashCode()
		{
			return this.point_0.GetHashCode() ^ this.vector3d_2.ToPoint().GetHashCode();
		}

		public bool Intersects3d(Edge edge)
		{
			return this.getInterSection(edge) != null;
		}

		public bool Intersects3d(Line line)
		{
			return line.Intersects3d(this);
		}

		public bool Intersects3d(Plane plane)
		{
			return !this.IsParallelTo(plane);
		}

		public bool Intersects3d(Triangle triangle)
		{
			return this.getInterSection(triangle) != null;
		}

		public bool Intersects3d(Circle circle)
		{
			return this.method_5(circle) != null;
		}

		public bool Intersects3d(Ellipse ellipse)
		{
			return this.method_6(ellipse) != null;
		}

		public bool IsCoplanarTo(Point point)
		{
			return this.Contains(point);
		}

		public bool IsCoplanarTo(Edge edge)
		{
			return this.Contains(edge);
		}

		public bool IsCoplanarTo(Line line)
		{
			return this.Contains(line);
		}

		public bool IsCoplanarTo(Plane plane)
		{
			return this == plane;
		}

		public bool IsCoplanarTo(Triangle triangle)
		{
			return this.Contains(triangle);
		}

		public bool IsCoplanarTo(Circle circle)
		{
			return this.Contains(circle);
		}

		public bool IsCoplanarTo(Ellipse ellipse)
		{
			return this.Contains(ellipse);
		}

		public bool IsOrthogonalTo(Plane plane)
		{
			return this.NormalVector.IsOrthogonalTo(plane.NormalVector);
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
			return this.NormalVector.IsParallelTo(plane.NormalVector);
		}

		public bool IsParallelTo(Triangle triangle)
		{
			return this.NormalVector.IsParallelTo(triangle.NormalVector);
		}

		public bool IsParallelTo(Circle circle)
		{
			return this.NormalVector.IsParallelTo(circle.NormalVector);
		}

		public bool IsParallelTo(Ellipse ellipse)
		{
			return this.NormalVector.IsParallelTo(ellipse.NormalVector);
		}

		public Point method_0(Line line)
		{
			return line.getInterSecttion(this);
		}

		public Point getInterSection(Edge edge)
		{
			Point point = edge.ToLine().getInterSecttion(this);
			if (point == null)
			{
				return null;
			}
			if (this.IsCoplanarTo(edge))
			{
				return null;
			}
			if (edge.CollinearContains(point))
			{
				return point;
			}
			return null;
		}

		public Line method_2(Plane plane)
		{
			double num = Vector3d.Dot(this.vector3d_2, this.vector3d_2);
			double num2 = Vector3d.Dot(this.vector3d_2, plane.vector3d_2);
			double num3 = Vector3d.Dot(plane.vector3d_2, plane.vector3d_2);
			Vector3d directionVector = Vector3d.Cross(this.vector3d_2, plane.vector3d_2);
			double num4 = num * num3;
			double num5 = num2 * num2;
			if (Global.AlmostEquals(num4, num5))
			{
				return null;
			}
			double num6 = 1.0 / (num4 - num5);
			double num7 = (this.d * num3 - plane.d * num2) * num6;
			double num8 = (plane.d * num - this.d * num2) * num6;
			double x = num7 * this.vector3d_2.X + num8 * plane.vector3d_2.X;
			double y = num7 * this.vector3d_2.Y + num8 * plane.vector3d_2.Y;
			double z = num7 * this.vector3d_2.Z + num8 * plane.vector3d_2.Z;
			return new Line(new Point(x, y, z), directionVector);
		}

		public Point method_3(Plane plane1, Plane plane2)
		{
			double num = this.vector3d_2.Y * plane1.vector3d_2.Z - this.vector3d_2.Z * plane1.vector3d_2.Y;
			double num2 = this.vector3d_2.Z * plane1.vector3d_2.X - this.vector3d_2.X * plane1.vector3d_2.Z;
			double num3 = this.vector3d_2.X * plane1.vector3d_2.Y - this.vector3d_2.Y * plane1.vector3d_2.X;
			double num4 = plane1.vector3d_2.Y * plane2.vector3d_2.Z - plane1.vector3d_2.Z * plane2.vector3d_2.Y;
			double num5 = plane1.vector3d_2.Z * plane2.vector3d_2.X - plane1.vector3d_2.X * plane2.vector3d_2.Z;
			double num6 = plane1.vector3d_2.X * plane2.vector3d_2.Y - plane1.vector3d_2.Y * plane2.vector3d_2.X;
			double num7 = plane2.vector3d_2.Y * this.vector3d_2.Z - plane2.vector3d_2.Z * this.vector3d_2.Y;
			double num8 = plane2.vector3d_2.Z * this.vector3d_2.X - plane2.vector3d_2.X * this.vector3d_2.Z;
			double num9 = plane2.vector3d_2.X * this.vector3d_2.Y - plane2.vector3d_2.Y * this.vector3d_2.X;
			if (Vector3d.smethod_1(this.vector3d_2, new Vector3d(num4, num5, num6)))
			{
				return null;
			}
			double num10 = this.vector3d_2.X * num4 + this.vector3d_2.Y * num5 + this.vector3d_2.Z * num6;
			if (Math.Abs(num10) < 4.94065645841247E-324)
			{
				return null;
			}
			double num11 = 1.0 / num10;
			double num12 = this.d * num11;
			double num13 = plane1.d * num11;
			double num14 = plane2.d * num11;
			double x = num12 * num4 + num13 * num7 + num14 * num;
			double y = num12 * num5 + num13 * num8 + num14 * num2;
			double z = num12 * num6 + num13 * num9 + num14 * num3;
			return new Point(x, y, z);
		}

		public Edge getInterSection(Triangle triangle)
		{
			Point point = this.getInterSection(triangle.Edge1);
			Point point2 = this.getInterSection(triangle.Edge2);
			Point point3 = this.getInterSection(triangle.Edge3);
			if (point == null & point2 == null & point3 == null)
			{
				return null;
			}
			if (point != null & point2 == null & point3 == null)
			{
				return new Edge(point, point);
			}
			if (point == null & point2 != null & point3 == null)
			{
				return new Edge(point2, point2);
			}
			if (point == null & point2 == null & point3 != null)
			{
				return new Edge(point3, point3);
			}
			if (point != null & point2 != null & point3 == null)
			{
				return new Edge(point, point2);
			}
			if (point != null & point2 == null & point3 != null)
			{
				return new Edge(point, point3);
			}
			if (point == null & point2 != null & point3 != null)
			{
				return new Edge(point2, point3);
			}
			if (point == point3)
			{
				return new Edge(point2, point3);
			}
			return new Edge(point, point3);
		}

		public Edge method_5(Circle circle)
		{
			Line line = this.method_2(circle.GetPlane());
			if (line == null)
			{
				return null;
			}
			Edge edge = circle.Center.PerpendicularOn(line);
			double num = circle.Radius * circle.Radius;
			double num2 = edge.StartPoint.method_3(edge.EndPoint);
			double num3 = num - num2;
			if (Global.AlmostEquals(num, num2))
			{
				num3 = 0.0;
			}
			if (num3 < 0.0)
			{
				return null;
			}
			line.DirectionVector.Norm = Math.Sqrt(num3);
			Point startPoint = edge.EndPoint + line.DirectionVector.ToPoint();
			Point endPoint = edge.EndPoint - line.DirectionVector.ToPoint();
			return new Edge(startPoint, endPoint);
		}

		public Edge method_6(Ellipse ellipse)
		{
			Vector3d nCF_normal = this.NCF_normal;
			Vector3d semimajorAxisVector = ellipse.SemimajorAxisVector;
			Vector3d semiminorAxisVector = ellipse.SemiminorAxisVector;
			double num = nCF_normal * semimajorAxisVector;
			double num2 = nCF_normal * semiminorAxisVector;
			double num3 = this.NCF_d - nCF_normal * ellipse.Center.method_2();
			double num4 = num * num + num2 * num2;
			double num5 = num4 - num3 * num3;
			if (Global.AlmostEquals(num * num + num2 * num2, num3 * num3))
			{
				num5 = 0.0;
			}
			if (num5 < 0.0)
			{
				return null;
			}
			if (Global.AlmostEquals(Math.Abs(num), Math.Abs(num2)))
			{
				return null;
			}
			double num6 = 1.0 / num4;
			double scalar = (num2 * num3 - num * Math.Sqrt(num5)) * num6;
			double scalar2 = (num * num3 + num2 * Math.Sqrt(num5)) * num6;
			double scalar3 = (num2 * num3 + num * Math.Sqrt(num5)) * num6;
			double scalar4 = (num * num3 - num2 * Math.Sqrt(num5)) * num6;
			Point startPoint = ellipse.Center + new Point(scalar2 * semimajorAxisVector + scalar * semiminorAxisVector);
			Point endPoint = ellipse.Center + new Point(scalar4 * semimajorAxisVector + scalar3 * semiminorAxisVector);
			return new Edge(startPoint, endPoint);
		}

		public Plane Move(Vector3d displacementVector)
		{
			Plane plane = this.DeepCopy();
			plane.Point = this.point_0 + displacementVector.ToPoint();
			return plane;
		}

		public Plane Move(Point startPoint, Point endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public void Normalize()
		{
			this.Point = new Point(0.0, 0.0, 0.0).PerpendicularOn(this).EndPoint;
			this.vector3d_0 = this.vector3d_0.Normalize();
			Vector3d nCF_normal = this.NCF_normal;
			double nCF_d = this.NCF_d;
			this.vector3d_2 = nCF_normal;
			this.double_0 = nCF_d;
			this.vector3d_1 = Vector3d.Cross(this.vector3d_2, this.vector3d_0).Normalize();
		}

		public static bool operator ==(Plane left, Plane right)
		{
            if ((object)left == (object)right)
			{
				return true;
			}
            if ((object)left != null && (object)right != null)
			{
				bool flag = left.Contains(right.Point);
				bool flag2 = left.vector3d_2.IsParallelTo(right.vector3d_2);
				return flag & flag2;
			}
			return false;
		}

		public static bool operator !=(Plane left, Plane right)
		{
			return !(left == right);
		}

		public Plane RandomOrthogonalPlane()
		{
			Point point = this.RandomPointOnPlane();
			Vector3d normalVector = this.NormalVector.RandomOrthonormal();
			return new Plane(point, normalVector);
		}

		public static Plane RandomPlane()
		{
			Point point = Point.RandomPoint();
			Vector3d vector3d = Vector3d.RandomVector();
			if (vector3d.Norm < Global.AbsoluteEpsilon)
			{
				vector3d.Z = 1.0;
			}
			return new Plane(point, vector3d);
		}

		public Point RandomPointOnPlane()
		{
			return this.Point + new Point(RandomGenerator.NextDouble_mr_mr() * this.vector3d_0 + RandomGenerator.NextDouble_mr_mr() * this.vector3d_1);
		}

		public Plane ReflectIn(Point point)
		{
			Point point2 = this.point_0;
			Point point3 = this.point_0 + this.vector3d_0.ToPoint();
			Point point4 = this.point_0 + this.vector3d_1.ToPoint();
			return new Plane(point2.ReflectIn(point), point3.ReflectIn(point), point4.ReflectIn(point));
		}

		public Plane ReflectIn(Line line)
		{
			Point point = this.point_0;
			Point point2 = this.point_0 + this.vector3d_0.ToPoint();
			Point point3 = this.point_0 + this.vector3d_1.ToPoint();
			return new Plane(point.ReflectIn(line), point2.ReflectIn(line), point3.ReflectIn(line));
		}

		public Plane ReflectIn(Plane plane)
		{
			Point point = this.point_0;
			Point point2 = this.point_0 + this.vector3d_0.ToPoint();
			Point point3 = this.point_0 + this.vector3d_1.ToPoint();
			return new Plane(point.ReflectIn(plane), point2.ReflectIn(plane), point3.ReflectIn(plane));
		}

		public Plane Rotate(Matrix3d rotationMatrix)
		{
			Point point = rotationMatrix * this.point_0;
			Vector3d normalVector = rotationMatrix * this.vector3d_2;
			return new Plane(point, normalVector);
		}

		public Plane Rotate(Point center, Matrix3d rotationMatrix)
		{
			Point point = this.point_0.Rotate(center, rotationMatrix);
			Vector3d normalVector = rotationMatrix * this.vector3d_2;
			return new Plane(point, normalVector);
		}

		internal static bool smethod_0(Point point_1, Vector3d vector3d_3, Point point_2)
		{
			double b = point_1.X * vector3d_3.X + point_1.Y * vector3d_3.Y + point_1.Z * vector3d_3.Z;
			double a = vector3d_3.X * point_2.X + vector3d_3.Y * point_2.Y + vector3d_3.Z * point_2.Z;
			return Global.AlmostEquals(a, b);
		}

		public override string ToString()
		{
			Vector3d nCF_normal = this.NCF_normal;
			Vector3d analytic = this.Analytic;
			return string.Concat(new string[]
			{
				"Plane ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  Parametric form:",
				Environment.NewLine,
				"     ",
				this.Point.ToString(),
				Environment.NewLine,
				"     + r * ",
				this.DirectionVector1.ToString(),
				Environment.NewLine,
				"     + s * ",
				this.DirectionVector2.ToString(),
				Environment.NewLine,
				"  Coordinate form:",
				Environment.NewLine,
				"     ",
				this.NormalVector.X.ToString(Global.StringNumberFormat),
				" * x + ",
				Environment.NewLine,
				"     ",
				this.NormalVector.Y.ToString(Global.StringNumberFormat),
				" * y + ",
				Environment.NewLine,
				"     ",
				this.NormalVector.Z.ToString(Global.StringNumberFormat),
				" * z = ",
				this.d.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Normal coordinate form (NCF):",
				Environment.NewLine,
				"     ",
				nCF_normal.X.ToString(Global.StringNumberFormat),
				" * x + ",
				Environment.NewLine,
				"     ",
				nCF_normal.Y.ToString(Global.StringNumberFormat),
				" * y + ",
				Environment.NewLine,
				"     ",
				nCF_normal.Z.ToString(Global.StringNumberFormat),
				" * z = ",
				this.NCF_d.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Analytic form:",
				Environment.NewLine,
				"     z = ",
				analytic.X.ToString(Global.StringNumberFormat),
				" * x + ",
				Environment.NewLine,
				"         ",
				analytic.Y.ToString(Global.StringNumberFormat),
				" * y + ",
				analytic.Z.ToString(Global.StringNumberFormat)
			});
		}

		public Plane TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Point point = this.point_0.TransformCoordinates(actualCS, newCS);
			Vector3d normalVector = this.vector3d_2.TransformCoordinates(actualCS, newCS);
			return new Plane(point, normalVector);
		}

		public static void TransformCoordinates(List<Plane> planes, CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d basisVectorMatrix2 = newCS.BasisVectorMatrix;
			Point b = actualCS.Origin - newCS.Origin;
			Matrix3d a = basisVectorMatrix2.Invert();
			Matrix3d a2 = basisVectorMatrix2.Invert() * basisVectorMatrix;
			Point right = basisVectorMatrix2.Invert() * b;
			for (int i = 0; i < planes.Count; i++)
			{
				planes[i].Point = a2 * planes[i].point_0 + right;
				planes[i].NormalVector = a * (basisVectorMatrix * planes[i].vector3d_2);
			}
		}

		public static Plane XY()
		{
			Point point = new Point(0.0, 0.0, 0.0);
			Point point2 = new Point(1.0, 0.0, 0.0);
			Point point3 = new Point(0.0, 1.0, 0.0);
			return new Plane(point, point2, point3);
		}

		public static Plane XZ()
		{
			Point point = new Point(0.0, 0.0, 0.0);
			Point point2 = new Point(1.0, 0.0, 0.0);
			Point point3 = new Point(0.0, 0.0, 1.0);
			return new Plane(point, point2, point3);
		}

		public static Plane YZ()
		{
			Point point = new Point(0.0, 0.0, 0.0);
			Point point2 = new Point(0.0, 1.0, 0.0);
			Point point3 = new Point(0.0, 0.0, 1.0);
			return new Plane(point, point2, point3);
		}

		public Vector3d Analytic
		{
			get
			{
				if (Math.Abs(this.vector3d_2.Z) < 4.94065645841247E-324)
				{
					throw new InvalidOperationException("Analytic form not defined: the z-coordinate of the normal vector of the plane is 0");
				}
				return new Vector3d(-this.vector3d_2.X / this.vector3d_2.Z, -this.vector3d_2.Y / this.vector3d_2.Z, this.double_0 / this.vector3d_2.Z);
			}
			set
			{
				this.vector3d_2 = new Vector3d(-1.0 * value.X, -1.0 * value.Y, 1.0);
				this.double_0 = value.Z;
				this.vector3d_0 = this.vector3d_2.RandomOrthonormal();
				this.vector3d_1 = Vector3d.Cross(this.vector3d_2, this.vector3d_0);
				this.Point = new Point(0.0, 0.0, this.double_0);
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

		public double d
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				Point point = new Point(0.0, 0.0, 0.0);
				if (Math.Abs(this.vector3d_2.X) > Math.Abs(this.vector3d_2.Y) & Math.Abs(this.vector3d_2.X) > Math.Abs(this.vector3d_2.Z))
				{
					point.X = this.double_0 / this.vector3d_2.X;
				}
				else if (Math.Abs(this.vector3d_2.Y) > Math.Abs(this.vector3d_2.Z))
				{
					point.Y = this.double_0 / this.vector3d_2.Y;
				}
				else
				{
					point.Z = this.double_0 / this.vector3d_2.Z;
				}
				this.point_0 = point - new Point(this.vector3d_0 - this.vector3d_1);
			}
		}

		public Vector3d DirectionVector1
		{
			get
			{
				return this.vector3d_0;
			}
			set
			{
				this.vector3d_0 = value;
				if (this.vector3d_0.Norm < 4.94065645841247E-324)
				{
					throw new ArgumentException("Invalid plane definition: zero length first direction vector!");
				}
				if (this.vector3d_0.IsParallelTo(this.vector3d_1))
				{
					throw new ArgumentException("Invalid plane definition: parallel direction vectors!");
				}
				this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
				this.double_0 = Vector3d.Dot(this.point_0.method_2(), this.vector3d_2);
			}
		}

		public Vector3d DirectionVector2
		{
			get
			{
				return this.vector3d_1;
			}
			set
			{
				this.vector3d_1 = value;
				if (this.vector3d_1.Norm < 4.94065645841247E-324)
				{
					throw new ArgumentException("Invalid plane definition: zero length second direction vector!");
				}
				if (this.vector3d_1.IsParallelTo(this.vector3d_0))
				{
					throw new ArgumentException("Invalid plane definition: parallel direction vectors!");
				}
				this.vector3d_2 = Vector3d.Cross(this.vector3d_0, this.vector3d_1);
				this.double_0 = Vector3d.Dot(this.point_0.method_2(), this.vector3d_2);
			}
		}

		public double NCF_d
		{
			get
			{
				if (this.double_0 >= 0.0)
				{
					return this.double_0 / this.vector3d_2.Norm;
				}
				return -1.0 * this.double_0 / this.vector3d_2.Norm;
			}
		}

		public Vector3d NCF_normal
		{
			get
			{
				if (this.double_0 >= 0.0)
				{
					return this.vector3d_2.Normalize();
				}
				return -1.0 * this.vector3d_2.Normalize();
			}
		}

		public Vector3d NormalVector
		{
			get
			{
				return this.vector3d_2;
			}
			set
			{
				this.vector3d_2 = value;
				if (this.vector3d_2.Norm < 4.94065645841247E-324)
				{
					throw new ArgumentException("Invalid plane definition: normal vector length is zero.");
				}
				this.double_0 = Vector3d.Dot(this.point_0.method_2(), this.vector3d_2);
				this.vector3d_0 = this.vector3d_2.Normalize().RandomOrthonormal();
				this.vector3d_1 = Vector3d.Cross(this.vector3d_2, this.vector3d_0).Normalize();
			}
		}

		public Point Point
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				this.double_0 = Vector3d.Dot(this.point_0.method_2(), this.vector3d_2);
			}
		}

		private CADData caddata_0;

		private double double_0;

		private Point point_0;

		private Vector3d vector3d_0;

		private Vector3d vector3d_1;

		private Vector3d vector3d_2;
	}
}
