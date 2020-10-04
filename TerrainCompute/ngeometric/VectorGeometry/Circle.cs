using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class Circle
	{
		public Circle()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Circle));
			//base..ctor();
			this.point_0 = new Point();
			this.vector3d_0 = new Vector3d();
		}

		public Circle(Point point1, Point point2, Point point3)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Circle));
			//base..ctor();
			Vector3d vector3d = new Vector3d(point2 - point1);
			Vector3d vector3d2 = new Vector3d(point3 - point2);
			Vector3d vector3d3 = new Vector3d(point1 - point3);
			this.vector3d_0 = Vector3d.Cross(vector3d, vector3d2);
			if (this.vector3d_0.method_0() < 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not construct circle: points are collinear.");
			}
			double num = vector3d.X * vector3d.X + vector3d.Y * vector3d.Y + vector3d.Z * vector3d.Z;
			double num2 = vector3d2.X * vector3d2.X + vector3d2.Y * vector3d2.Y + vector3d2.Z * vector3d2.Z;
			double num3 = vector3d3.X * vector3d3.X + vector3d3.Y * vector3d3.Y + vector3d3.Z * vector3d3.Z;
			double num4 = -2.0 * (this.vector3d_0.X * this.vector3d_0.X + this.vector3d_0.Y * this.vector3d_0.Y + this.vector3d_0.Z * this.vector3d_0.Z);
			double scalar = num2 * Vector3d.Dot(vector3d, vector3d3) / num4;
			double scalar2 = num3 * Vector3d.Dot(vector3d, vector3d2) / num4;
			double scalar3 = num * Vector3d.Dot(vector3d3, vector3d2) / num4;
			this.point_0 = scalar * point1 + scalar2 * point2 + scalar3 * point3;
			this.double_0 = new Vector3d(this.point_0 - point1).Norm;
			if (this.double_0 < 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not construct circle: radius results zero or negative.");
			}
		}

		public Circle(Point center, double radius, Vector3d normalVector)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Circle));
			//base..ctor();
			this.point_0 = center;
			this.double_0 = radius;
			this.vector3d_0 = normalVector;
			if (normalVector.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not construct circle: zero length normal vector.");
			}
			if (radius < 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not construct circle: radius zero or negative.");
			}
		}

		public bool Contains(Point point)
		{
			if (!point.IsCoplanarTo(this))
			{
				return false;
			}
			double num = point.DistanceTo(this.point_0);
			return Global.AlmostEquals(num, this.double_0) || num - this.Radius < Global.AbsoluteEpsilon;
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
			if (!this.IsCoplanarTo(circle))
			{
				return false;
			}
			double num = circle.point_0.DistanceTo(this.point_0);
			double num2 = num + circle.Radius;
			return Global.AlmostEquals(num2, this.double_0) || num2 - this.double_0 < Global.AbsoluteEpsilon;
		}

		public bool ContainsOnCircumference(Point point)
		{
			if (!point.IsCoplanarTo(this))
			{
				return false;
			}
			double a = point.DistanceTo(this.point_0);
			return Global.AlmostEquals(a, this.double_0);
		}

		public Circle DeepCopy()
		{
			return new Circle
			{
				point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z),
				double_0 = this.double_0,
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z)
			};
		}

		public override bool Equals(object obj)
		{
			return this == (Circle)obj;
		}

		public override int GetHashCode()
		{
			return this.point_0.GetHashCode() ^ this.double_0.GetHashCode() ^ this.NormalVector.GetHashCode();
		}

		public Plane GetPlane()
		{
			return new Plane(this);
		}

		public bool Intersects2d(Line line)
		{
			return line.Intersects2d(this);
		}

		public bool Intersects2d(Edge edge)
		{
			return edge.Intersects2d(this);
		}

		public bool Intersects2d(Triangle triangle)
		{
			return triangle.Intersects2d(this);
		}

		public bool Intersects2d(Circle circle)
		{
			PointSet pointSet = this.method_3(circle);
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
			return triangle.Intersects3d(this);
		}

		public bool Intersects3d(Circle circle)
		{
			return this.method_8(circle) != null;
		}

		public bool Intersects3d(Ellipse ellipse)
		{
			return this.method_9(ellipse) != null;
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
			return triangle.IsCoplanarTo(this);
		}

		public bool IsCoplanarTo(Circle circle)
		{
			return this.GetPlane() == circle.GetPlane();
		}

		public bool IsCoplanarTo(Ellipse ellipse)
		{
			return this.GetPlane() == ellipse.GetPlane();
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
			return triangle.IsParallelTo(this);
		}

		public bool IsParallelTo(Circle circle)
		{
			return circle.NormalVector.IsParallelTo(this.vector3d_0);
		}

		public bool IsParallelTo(Ellipse ellipse)
		{
			return ellipse.NormalVector.IsParallelTo(this.vector3d_0);
		}

		public bool IsTangentTo(Line line)
		{
			if (!line.IsCoplanarTo(this))
			{
				return false;
			}
			Point endPoint = this.point_0.PerpendicularOn(line).EndPoint;
			return this.ContainsOnCircumference(endPoint);
		}

		public PointSet method_0(Edge edge)
		{
			return edge.method_1(this);
		}

		public PointSet method_1(Line line)
		{
			return line.method_1(this);
		}

		internal bool method_10(Point point_1)
		{
			double num = point_1.DistanceTo(this.point_0);
			return num - this.Radius < Global.AbsoluteEpsilon;
		}

		public PointSet method_2(Triangle triangle)
		{
			return triangle.method_3(this);
		}

		public PointSet method_3(Circle circle)
		{
			if (!circle.IsCoplanarTo(this))
			{
				return null;
			}
			if (circle == this)
			{
				return null;
			}
			PointSet result = new PointSet();
			if (circle.point_0 == this.point_0)
			{
				return result;
			}
			Circle circle2;
			Circle circle3;
			if (this.double_0 > circle.double_0)
			{
				circle2 = this;
				circle3 = circle;
			}
			else
			{
				circle3 = this;
				circle2 = circle;
			}
			Vector3d vector3d = new Vector3d(circle3.point_0 - circle2.point_0);
			double norm = vector3d.Norm;
			double scalar = (circle2.double_0 * circle2.double_0 - circle3.double_0 * circle3.double_0 + norm * norm) / (2.0 * norm);
			Point point = circle2.point_0 + scalar * vector3d.Normalize().ToPoint();
			Line line = new Line(point, Vector3d.Cross(vector3d, this.vector3d_0));
			return this.method_1(line);
		}

		public Point method_4(Line line)
		{
			return line.method_7(this);
		}

		public Point method_5(Edge edge)
		{
			return edge.method_7(this);
		}

		public Edge method_6(Plane plane)
		{
			return plane.method_5(this);
		}

		public Edge method_7(Triangle triangle)
		{
			return triangle.method_9(this);
		}

		public Edge method_8(Circle circle)
		{
			Edge edge = this.GetPlane().method_5(circle);
			Edge edge2 = circle.GetPlane().method_5(this);
			if (edge == null | edge2 == null)
			{
				return null;
			}
			return edge.CollinearOverlap(edge2);
		}

		public Edge method_9(Ellipse ellipse)
		{
			Edge edge = this.GetPlane().method_6(ellipse);
			Edge edge2 = ellipse.GetPlane().method_5(this);
			if (edge == null | edge2 == null)
			{
				return null;
			}
			return edge.CollinearOverlap(edge2);
		}

		public Circle Move(Vector3d displacementVector)
		{
			return new Circle
			{
				point_0 = this.point_0 + displacementVector.ToPoint(),
				double_0 = this.double_0,
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z)
			};
		}

		public Circle Move(Point startPoint, Point endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public Vector3d NormalVector2d(Point point)
		{
			if (!this.ContainsOnCircumference(point))
			{
				return null;
			}
			return new Vector3d(point - this.point_0).Normalize();
		}

		public static bool operator ==(Circle left, Circle right)
		{
            if ((object)left == (object)right)
            {
                return true;
            }
            if ((object)left == null || (object)right == null)
            {
                return false;
            }
            if (!(left.point_0 == right.point_0) || !Global.AlmostEquals(left.Radius, right.Radius))
            {
                return false;
            }
            return left.NormalVector.IsParallelTo(right.NormalVector);
		}

		public static bool operator !=(Circle left, Circle right)
		{
			return !(left == right);
		}

		public Ellipse ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			return this.ToEllipse().ProjectParallelOn(plane, viewDirection);
		}

		public static Circle RandomCircle()
		{
			return new Circle
			{
				point_0 = Point.RandomPoint(),
				double_0 = RandomGenerator.NextDouble_0_mr(),
				vector3d_0 = Vector3d.RandomVector()
			};
		}

		public Point RandomPointInCircle()
		{
			Vector3d vector3d = this.vector3d_0.RandomOrthonormal();
			double scalar = this.double_0 * RandomGenerator.NextDouble_0_1();
			return this.point_0 + scalar * vector3d.ToPoint();
		}

		public Point RandomPointOnCircle()
		{
			Vector3d vector3d = this.vector3d_0.RandomOrthonormal();
			return this.point_0 + this.double_0 * vector3d.ToPoint();
		}

		public Circle ReflectIn(Point point)
		{
			return new Circle
			{
				point_0 = this.point_0.ReflectIn(point),
				double_0 = this.double_0,
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z)
			};
		}

		public Circle ReflectIn(Line line)
		{
			return new Circle
			{
				point_0 = this.point_0.ReflectIn(line),
				double_0 = this.double_0,
				vector3d_0 = 2.0 * this.vector3d_0.ProjectParallelOn(line.DirectionVector) - this.vector3d_0
			};
		}

		public Circle ReflectIn(Plane plane)
		{
			return new Circle
			{
				point_0 = this.point_0.ReflectIn(plane),
				double_0 = this.double_0,
				vector3d_0 = 2.0 * (this.vector3d_0.ProjectParallelOn(plane.DirectionVector1) + this.vector3d_0.ProjectParallelOn(plane.DirectionVector2)) - this.vector3d_0
			};
		}

		public Circle Rotate(Matrix3d rotationMatrix)
		{
			return new Circle
			{
				point_0 = rotationMatrix * this.point_0,
				vector3d_0 = rotationMatrix * this.vector3d_0,
				double_0 = this.double_0
			};
		}

		public Circle Rotate(Point center, Matrix3d rotationMatrix)
		{
			return new Circle
			{
				point_0 = this.point_0.Rotate(center, rotationMatrix),
				vector3d_0 = rotationMatrix * this.vector3d_0,
				double_0 = this.double_0
			};
		}

		public Circle Scale(Point center, double scaleFactor)
		{
			Circle circle = new Circle();
			circle.point_0 = this.point_0.Scale(center, scaleFactor);
			circle.double_0 = this.double_0 * scaleFactor;
			circle.vector3d_0 = scaleFactor * this.vector3d_0;
			if (this.double_0 < 4.94065645841247E-324)
			{
				throw new ArgumentException("Scale factor is too small: radius is zero.");
			}
			return circle;
		}

		public Ellipse Scale(Point center, double scaleX, double scaleY, double scaleZ)
		{
			Ellipse ellipse = this.ToEllipse();
			Point m = ellipse.Center.Scale(center, scaleX, scaleY, scaleZ);
			Edge edge = ellipse.MajorAxis.Scale(center, scaleX, scaleY, scaleZ);
			Edge edge2 = ellipse.MinorAxis.Scale(center, scaleX, scaleY, scaleZ);
			if (edge.Length < Global.AbsoluteEpsilon | edge2.Length < Global.AbsoluteEpsilon)
			{
				throw new ArgumentException("Can not construct ellipse: scale factor is too small!");
			}
			if (edge.IsCollinearTo(edge2))
			{
				throw new ArgumentException("Can not construct ellipse: scale factor is too small!");
			}
			return Ellipse.ConstructFromConjugateDiameters(m, edge.EndPoint, edge2.EndPoint);
		}

		public List<Line> TangentLines2d(Point point)
		{
			if (!point.IsCoplanarTo(this))
			{
				return null;
			}
			List<Line> list = new List<Line>();
			Vector3d vector3d = new Vector3d(point - this.point_0);
			double norm = vector3d.Norm;
			if (this.double_0 - norm > Global.AbsoluteEpsilon)
			{
				return list;
			}
			if (Global.AlmostEquals(norm, this.double_0))
			{
				Point point2 = this.point_0 + this.double_0 / norm * vector3d.ToPoint();
				Vector3d directionVector = Vector3d.Cross(vector3d, this.NormalVector);
				list.Add(new Line(point2, directionVector));
				return list;
			}
			double scalar = this.double_0 * this.double_0 / (norm * norm);
			Point point3 = this.point_0 + scalar * vector3d.ToPoint();
			Plane plane = new Plane(point3, vector3d);
			Edge edge = this.method_6(plane);
			list.Add(new Line(point, edge.StartPoint));
			list.Add(new Line(point, edge.EndPoint));
			return list;
		}

		public List<Line> TangentLines2d(Circle circle)
		{
			if (!circle.IsCoplanarTo(this))
			{
				return null;
			}
			List<Line> list = new List<Line>();
			if (this.Contains(circle))
			{
				return list;
			}
			if (circle.Contains(this))
			{
				return list;
			}
			Vector3d vector3d = new Vector3d(circle.point_0 - this.point_0);
			if (this.Intersects2d(circle))
			{
				if (Global.AlmostEquals(this.double_0, circle.double_0))
				{
					Vector3d b = new Vector3d(this.point_0 - circle.point_0);
					Vector3d vector3d2 = Vector3d.Cross(this.NormalVector, b);
					vector3d2.Norm = this.double_0;
					list.Add(new Line(this.point_0, circle.point_0).Move(vector3d2));
					list.Add(new Line(this.point_0, circle.point_0).Move(-1.0 * vector3d2));
					return list;
				}
				double scalar = this.double_0 / (this.double_0 - circle.double_0);
				Point point = this.point_0 + scalar * vector3d.ToPoint();
				return this.TangentLines2d(point);
			}
			else
			{
				if (Global.AlmostEquals(this.double_0, circle.double_0))
				{
					Vector3d b2 = new Vector3d(this.point_0 - circle.point_0);
					Vector3d vector3d3 = Vector3d.Cross(this.NormalVector, b2);
					vector3d3.Norm = this.double_0;
					list.Add(new Line(this.point_0, circle.point_0).Move(vector3d3));
					list.Add(new Line(this.point_0, circle.point_0).Move(-1.0 * vector3d3));
					double scalar2 = this.double_0 / (this.double_0 + circle.double_0);
					Point point2 = this.point_0 + scalar2 * vector3d.ToPoint();
					List<Line> list2 = this.TangentLines2d(point2);
					foreach (Line current in list2)
					{
						list.Add(current);
					}
					return list;
				}
				double scalar3 = this.double_0 / (this.double_0 - circle.double_0);
				double scalar4 = this.double_0 / (this.double_0 + circle.double_0);
				Point point3 = this.point_0 + scalar3 * vector3d.ToPoint();
				Point point4 = this.point_0 + scalar4 * vector3d.ToPoint();
				List<Line> list3 = this.TangentLines2d(point3);
				List<Line> list4 = this.TangentLines2d(point4);
				foreach (Line current2 in list3)
				{
					list.Add(current2);
				}
				foreach (Line current3 in list4)
				{
					list.Add(current3);
				}
				return list;
			}
		}

		public Vector3d TangentVector2d(Point point)
		{
			if (!this.ContainsOnCircumference(point))
			{
				return null;
			}
			Vector3d a = new Vector3d(point - this.point_0).Normalize();
			return Vector3d.Cross(a, this.vector3d_0).Normalize();
		}

		public Ellipse ToEllipse()
		{
			return new Ellipse(this);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Circle ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  center       : ",
				this.point_0.ToString(),
				Environment.NewLine,
				"  Normal vector: ",
				this.NormalVector.ToString(),
				Environment.NewLine,
				"  Radius       : ",
				this.Radius.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Area         : ",
				this.Area.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Circumference: ",
				this.Circumference.ToString(Global.StringNumberFormat)
			});
		}

		public Ellipse TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Ellipse ellipse = this.ToEllipse();
			Point point = new Point(ellipse.Center.X + ellipse.SemimajorAxisVector.X, ellipse.Center.Y + ellipse.SemimajorAxisVector.Y, ellipse.Center.Z + ellipse.SemimajorAxisVector.Z);
			Point point2 = new Point(ellipse.Center.X + ellipse.SemiminorAxisVector.X, ellipse.Center.Y + ellipse.SemiminorAxisVector.Y, ellipse.Center.Z + ellipse.SemiminorAxisVector.Z);
			ellipse.Center = ellipse.Center.TransformCoordinates(actualCS, newCS);
			point = point.TransformCoordinates(actualCS, newCS);
			point2 = point2.TransformCoordinates(actualCS, newCS);
			return Ellipse.ConstructFromConjugateDiameters(ellipse.Center, point, point2);
		}

		public static void TransformCoordinates(List<Circle> circles, CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			if (!(actualCS.IsOrthonormal & newCS.IsOrthonormal))
			{
				throw new ArgumentException("A coordinate transformation of a list of circles must be orthonormal!");
			}
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d matrix3d = newCS.BasisVectorMatrix.Invert();
			Matrix3d matrix3d2 = matrix3d * basisVectorMatrix;
			double num = actualCS.Origin.X - newCS.Origin.X;
			double num2 = actualCS.Origin.Y - newCS.Origin.Y;
			double num3 = actualCS.Origin.Z - newCS.Origin.Z;
			double num4 = matrix3d.a00 * num + matrix3d.a01 * num2 + matrix3d.a02 * num3;
			double num5 = matrix3d.a10 * num + matrix3d.a11 * num2 + matrix3d.a12 * num3;
			double num6 = matrix3d.a20 * num + matrix3d.a21 * num2 + matrix3d.a22 * num3;
			for (int i = 0; i < circles.Count; i++)
			{
				Point point = circles[i].point_0;
				Vector3d vector3d = circles[i].vector3d_0;
				double x = point.X;
				double y = point.Y;
				double z = point.Z;
				point.X = matrix3d2.a00 * x + matrix3d2.a01 * y + matrix3d2.a02 * z + num4;
				point.Y = matrix3d2.a10 * x + matrix3d2.a11 * y + matrix3d2.a12 * z + num5;
				point.Z = matrix3d2.a20 * x + matrix3d2.a21 * y + matrix3d2.a22 * z + num6;
				double x2 = vector3d.X;
				double y2 = vector3d.Y;
				double z2 = vector3d.Z;
				vector3d.X = matrix3d2.a00 * x2 + matrix3d2.a01 * y2 + matrix3d2.a02 * z2;
				vector3d.Y = matrix3d2.a10 * x2 + matrix3d2.a11 * y2 + matrix3d2.a12 * z2;
				vector3d.Z = matrix3d2.a20 * x2 + matrix3d2.a21 * y2 + matrix3d2.a22 * z2;
			}
		}

		public double Area
		{
			get
			{
				return this.double_0 * this.double_0 * 3.1415926535897931;
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
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
			}
		}

		public double Circumference
		{
			get
			{
				return 2.0 * this.double_0 * 3.1415926535897931;
			}
		}

		public double Diameter
		{
			get
			{
				return 2.0 * this.double_0;
			}
			set
			{
				this.double_0 = value / 2.0;
				if (this.double_0 < 4.94065645841247E-324)
				{
					throw new ArgumentException("Invalid circle definition: zero or negative diameter.");
				}
			}
		}

		public Vector3d NormalVector
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
					throw new ArgumentException("Invalid circle definition: zero length normal vector.");
				}
			}
		}

		public double Radius
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				if (this.double_0 < 4.94065645841247E-324)
				{
					throw new ArgumentException("Invalid circle definition: zero or negative radius.");
				}
			}
		}

		private CADData caddata_0;

		private double double_0;

		private Point point_0;

		private Vector3d vector3d_0;
	}
}
