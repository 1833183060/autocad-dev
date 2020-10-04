using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class Ellipse
	{
		public Ellipse()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Ellipse));
			//base..ctor();
		}

		internal Ellipse(Circle circle)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Ellipse));
			//base..ctor();
			this.point_0 = circle.Center;
			Vector3d vector3d = new Vector3d(circle.RandomPointOnCircle() - circle.Center);
			Vector3d vector3d2 = Vector3d.Cross(circle.NormalVector.Normalize(), vector3d);
			vector3d.Norm = circle.Radius;
			vector3d2.Norm = circle.Radius;
			if (vector3d.Norm >= vector3d2.Norm)
			{
				this.vector3d_0 = vector3d;
				this.vector3d_1 = vector3d2;
			}
			else
			{
				this.vector3d_0 = vector3d2;
				this.vector3d_1 = vector3d;
			}
			if (Vector3d.Dot(this.NormalVector, circle.NormalVector) < 0.0)
			{
				this.vector3d_1 = -1.0 * this.vector3d_1;
			}
		}

		public Ellipse(Point center, Vector3d semimajorAxis, Vector3d semiminorAxis)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Ellipse));
			//base..ctor();
			this.point_0 = center;
			this.vector3d_0 = semimajorAxis;
			this.vector3d_1 = semiminorAxis;
			if (this.vector3d_0.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Zero length semimajor axis vector not allowed for ellipse!");
			}
			if (this.vector3d_1.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Zero length semiminor axis vector not allowed for ellipse!");
			}
			if (this.vector3d_0.Norm < this.vector3d_1.Norm)
			{
				this.vector3d_0 = semiminorAxis;
				this.vector3d_1 = semimajorAxis;
			}
			if (!this.vector3d_0.IsOrthogonalTo(this.vector3d_1))
			{
				throw new ArgumentException("Ellipse axes are not orthogonal! ");
			}
		}

		public Ellipse(Point center, Edge majorAxis, Vector3d normalVector, double eccentricity)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Ellipse));
			//base..ctor();
			this.point_0 = center;
			this.vector3d_0 = new Vector3d(majorAxis.EndPoint - majorAxis.MidPoint);
			Vector3d vector = Vector3d.Cross(this.vector3d_0, normalVector).Normalize();
			this.vector3d_1 = this.vector3d_0.Norm * Math.Sqrt(1.0 - eccentricity * eccentricity) * vector;
			if (this.vector3d_0.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Zero length semimajor axis vector not allowed for ellipse!");
			}
			if (this.vector3d_1.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentException("Zero length semiminor axis vector not allowed for ellipse!");
			}
		}

		public static Ellipse ConstructFromConjugateDiameters(Point M, Point P, Point Q)
		{
			Ellipse result;
			try
			{
				if (P.DistanceTo(M) > Q.DistanceTo(M))
				{
					Point point = P.DeepCopy();
					P = Q.DeepCopy();
					Q = point.DeepCopy();
				}
				Vector3d vector3d = new Vector3d(Q - M);
				Vector3d vector3d2 = new Vector3d(P - M);
				if (vector3d2.IsOrthogonalTo(vector3d))
				{
					result = new Ellipse(M, vector3d, vector3d2);
				}
				else
				{
					Plane plane = new Plane(M, P, Q);
					plane.Normalize();
					Matrix3d rotationMatrix = Matrix3d.RotationArbitraryAxis(plane.NormalVector, 1.5707963267948966);
					Point point2 = P.Rotate(M, rotationMatrix);
					if (Vector3d.Angle(vector3d, new Vector3d(point2 - M)) > 1.5707963267948966)
					{
						point2 = -1.0 * (point2 - M) + M;
					}
					Point midPoint = new Edge(point2, Q).MidPoint;
					Circle circle = new Circle(midPoint, M.DistanceTo(midPoint), plane.NormalVector);
					Plane plane2 = new Plane(midPoint, new Vector3d(point2 - midPoint), plane.NormalVector);
					plane2.Normalize();
					Edge edge = plane2.method_5(circle);
					double num = Q.DistanceTo(edge.StartPoint);
					double num2 = Q.DistanceTo(edge.EndPoint);
					if (num < num2)
					{
						num = num2;
						num2 = Q.DistanceTo(edge.StartPoint);
					}
					Vector3d vector3d3 = new Vector3d(edge.EndPoint - M);
					Vector3d vector3d4 = new Vector3d(edge.StartPoint - M);
					if (vector3d4.Norm > vector3d3.Norm)
					{
						vector3d3 = new Vector3d(edge.StartPoint - M);
						vector3d4 = new Vector3d(edge.EndPoint - M);
					}
					vector3d3.Norm = num;
					vector3d4.Norm = num2;
					Ellipse ellipse = new Ellipse();
					ellipse.point_0 = M;
					if (vector3d3.Norm >= vector3d4.Norm)
					{
						ellipse.vector3d_0 = vector3d3;
						ellipse.vector3d_1 = vector3d4;
					}
					else
					{
						ellipse.vector3d_0 = vector3d4;
						ellipse.vector3d_1 = vector3d3;
					}
					result = ellipse;
				}
			}
            catch (System.Exception ex)
			{
				throw new ArithmeticException("Rytz construction failed due to numerical problems:\n" + ex.Message);
			}
			return result;
		}

		public bool Contains(Point point)
		{
			if (!point.IsCoplanarTo(this))
			{
				return false;
			}
			Point pointAtParameter = this.GetPointAtParameter(this.GetParameterAtPoint(point));
			double num = pointAtParameter.DistanceTo(this.point_0);
			double num2 = point.DistanceTo(this.point_0);
			return Global.AlmostEquals(num, num2) || num2 - num < Global.AbsoluteEpsilon;
		}

		public bool Contains(Edge edge)
		{
			return this.Contains(edge.StartPoint) && this.Contains(edge.EndPoint);
		}

		public bool Contains(Triangle triangle)
		{
			return this.Contains(triangle.Vertex1) && this.Contains(triangle.Vertex2) && this.Contains(triangle.Vertex3);
		}

		public bool Contains(Circle circle)
		{
			return this.IsCoplanarTo(circle) && this.Contains(circle.Center) && circle.Radius - circle.Center.DistanceToPerimeter(this) < Global.AbsoluteEpsilon;
		}

		public bool ContainsOnCircumference(Point point)
		{
			if (!point.IsCoplanarTo(this))
			{
				return false;
			}
			PointSet focalPoints = this.FocalPoints;
			Point point2 = focalPoints[0];
			Point point3 = focalPoints[1];
			double num = point2.DistanceTo(point);
			double num2 = point3.DistanceTo(point);
			double b = 2.0 * this.SemimajorAxisVector.Norm;
			return Global.AlmostEquals(num + num2, b);
		}

		public Ellipse DeepCopy()
		{
			return new Ellipse
			{
				point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z),
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z),
				vector3d_1 = new Vector3d(this.vector3d_1.X, this.vector3d_1.Y, this.vector3d_1.Z)
			};
		}

		public override bool Equals(object obj)
		{
			return this == (Ellipse)obj;
		}

		public double[] ExtentsXY()
		{
			double num = Math.Sqrt(1.0 / (this.vector3d_0.X * this.vector3d_0.X / (this.vector3d_1.X * this.vector3d_1.X) + 1.0));
			if (num > 1.0)
			{
				num = 1.0;
			}
			double num2 = Math.Sqrt(1.0 / (this.vector3d_0.Y * this.vector3d_0.Y / (this.vector3d_1.Y * this.vector3d_1.Y) + 1.0));
			if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			double num3 = Math.Asin(num);
			double num4 = Math.Asin(num2);
			double num5 = 3.1415926535897931;
			double x = this.GetPointAtParameter(num3).X;
			double x2 = this.GetPointAtParameter(-num3).X;
			double x3 = this.GetPointAtParameter(num3 + num5).X;
			double x4 = this.GetPointAtParameter(-num3 - num5).X;
			double y = this.GetPointAtParameter(num4).Y;
			double y2 = this.GetPointAtParameter(-num4).Y;
			double y3 = this.GetPointAtParameter(num4 + num5).Y;
			double y4 = this.GetPointAtParameter(-num4 - num5).Y;
			return new double[]
			{
				Math.Min(x, Math.Min(x2, Math.Min(x3, x4))),
				Math.Max(x, Math.Max(x2, Math.Max(x3, x4))),
				Math.Min(y, Math.Min(y2, Math.Min(y3, y4))),
				Math.Max(y, Math.Max(y2, Math.Max(y3, y4)))
			};
		}

		public override int GetHashCode()
		{
			return this.point_0.GetHashCode() ^ this.vector3d_0.ToPoint().GetHashCode() ^ this.vector3d_1.ToPoint().GetHashCode();
		}

		public double GetParameterAtPoint(Point point)
		{
			Vector3d vector3d = new Vector3d(point - this.point_0);
			if (vector3d.Norm < 4.94065645841247E-324)
			{
				return 0.0;
			}
			double num = Vector3d.Angle(this.vector3d_0, vector3d);
			double d = Vector3d.Angle(this.vector3d_1, vector3d);
			double num2 = Math.Cos(num);
			double num3 = Math.Cos(d);
			if (Global.AlmostEquals(num3, 1.0))
			{
				return 1.5707963267948966;
			}
			if (Global.AlmostEquals(num3, -1.0))
			{
				return 4.71238898038469;
			}
			double num4 = Math.Atan(this.vector3d_0.Norm / this.vector3d_1.Norm * Math.Tan(num));
			if (num2 >= 0.0 && num3 >= 0.0)
			{
				return num4;
			}
			if (num2 <= 0.0 && num3 >= 0.0)
			{
				return 3.1415926535897931 + num4;
			}
			if (num2 <= 0.0 && num3 <= 0.0)
			{
				return 3.1415926535897931 - num4;
			}
			return 6.2831853071795862 - num4;
		}

		public Plane GetPlane()
		{
			return new Plane(this);
		}

		public Point GetPointAtParameter(double tetha)
		{
			double scalar = Math.Cos(tetha);
			double scalar2 = Math.Sin(tetha);
			return this.point_0 + new Point(scalar * this.vector3d_0 + scalar2 * this.vector3d_1);
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
			return triangle.Intersects2d(this);
		}

		public bool Intersects3d(Edge edge)
		{
			return this.method_3(edge) != null;
		}

		public bool Intersects3d(Line line)
		{
			return this.method_4(line) != null;
		}

		public bool Intersects3d(Plane plane)
		{
			return this.method_5(plane) != null;
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
			return circle.IsCoplanarTo(this);
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
			return circle.IsParallelTo(this);
		}

		public bool IsParallelTo(Ellipse ellipse)
		{
			return this.NormalVector.IsParallelTo(ellipse.NormalVector);
		}

		public PointSet method_0(Edge edge)
		{
			return edge.method_2(this);
		}

		public PointSet method_1(Line line)
		{
			return line.method_2(this);
		}

		public PointSet method_2(Triangle triangle)
		{
			return triangle.method_4(this);
		}

		public Point method_3(Edge edge)
		{
			return edge.method_8(this);
		}

		public Point method_4(Line line)
		{
			return line.method_8(this);
		}

		public Edge method_5(Plane plane)
		{
			return plane.method_6(this);
		}

		public Edge method_6(Triangle triangle)
		{
			return triangle.method_10(this);
		}

		public Edge method_7(Circle circle)
		{
			return circle.method_9(this);
		}

		public Edge method_8(Ellipse ellipse)
		{
			Edge edge = this.GetPlane().method_6(ellipse);
			Edge edge2 = ellipse.GetPlane().method_6(this);
			if (edge == null | edge2 == null)
			{
				return null;
			}
			return edge.CollinearOverlap(edge2);
		}

		internal bool method_9(Point point_1)
		{
			Point pointAtParameter = this.GetPointAtParameter(this.GetParameterAtPoint(point_1));
			double num = pointAtParameter.DistanceTo(this.point_0);
			double num2 = point_1.DistanceTo(this.point_0);
			return Global.AlmostEquals(num, num2) || num2 - num < Global.AbsoluteEpsilon;
		}

		public Ellipse Move(Vector3d displacementVector)
		{
			return new Ellipse
			{
				point_0 = this.point_0 + displacementVector.ToPoint(),
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z),
				vector3d_1 = new Vector3d(this.vector3d_1.X, this.vector3d_1.Y, this.vector3d_1.Z)
			};
		}

		public Ellipse Move(Point startPoint, Point endPoint)
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
			double norm = this.vector3d_0.Norm;
			double norm2 = this.vector3d_1.Norm;
			Vector3d vector3d = new Vector3d(point - this.point_0);
			Vector3d vector3d2 = vector3d.ProjectParallelOn(this.vector3d_0);
			Vector3d vector3d3 = vector3d.ProjectParallelOn(this.vector3d_1);
			double num = (double)Math.Sign(Vector3d.Dot(vector3d2, this.vector3d_0)) * vector3d2.Norm;
			double num2 = (double)Math.Sign(Vector3d.Dot(vector3d3, this.vector3d_1)) * vector3d3.Norm;
			double scalar = norm2 / norm * num;
			double scalar2 = norm / norm2 * num2;
			return scalar * this.vector3d_0.Normalize() + scalar2 * this.vector3d_1.Normalize();
		}

		public static bool operator ==(Ellipse left, Ellipse right)
		{
            if ((object)left == (object)right)
			{
				return true;
			}
            if ((object)left == null || (object)right == null)
			{
				return false;
			}
			if (left.point_0 != right.point_0)
			{
				return false;
			}
			if (left.IsCircular & right.IsCircular)
			{
				return Global.AlmostEquals(left.vector3d_0.Norm, right.vector3d_0.Norm) | Global.AlmostEquals(left.vector3d_0.Norm, right.vector3d_1.Norm) | Global.AlmostEquals(left.vector3d_1.Norm, right.vector3d_0.Norm) | Global.AlmostEquals(left.vector3d_1.Norm, right.vector3d_1.Norm);
			}
			return (left.vector3d_0.IsParallelTo(right.vector3d_0) & Global.AlmostEquals(left.vector3d_0.Norm, right.vector3d_0.Norm)) && (left.vector3d_1.IsParallelTo(right.vector3d_1) & Global.AlmostEquals(left.vector3d_1.Norm, right.vector3d_1.Norm));
		}

		public static bool operator !=(Ellipse left, Ellipse right)
		{
			return !(left == right);
		}

		public Ellipse ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			if (viewDirection.IsOrthogonalTo(plane.NormalVector))
			{
				throw new ArgumentException("View direction parallel to projection plane!");
			}
			if (viewDirection.IsOrthogonalTo(this.NormalVector))
			{
				throw new ArgumentException("View direction parallel to circle!");
			}
			Point point = this.point_0 + this.SemimajorAxisVector.ToPoint();
			Point point2 = this.Center + this.SemiminorAxisVector.ToPoint();
			Point p = point.ProjectParallelOn(plane, viewDirection);
			Point q = point2.ProjectParallelOn(plane, viewDirection);
			Point m = this.Center.ProjectParallelOn(plane, viewDirection);
			return Ellipse.ConstructFromConjugateDiameters(m, p, q);
		}

		public static Ellipse RandomEllipse()
		{
			Ellipse ellipse = new Ellipse();
			ellipse.point_0 = Point.RandomPoint();
			Vector3d vector3d = Vector3d.RandomVector();
			Vector3d vector3d2 = vector3d.RandomOrthonormal();
			double norm = RandomGenerator.NextDouble_0_mr();
			double norm2 = RandomGenerator.NextDouble_0_mr();
			vector3d.Norm = norm;
			vector3d2.Norm = norm2;
			if (vector3d.Norm > vector3d2.Norm)
			{
				ellipse.vector3d_0 = vector3d;
				ellipse.vector3d_1 = vector3d2;
			}
			else
			{
				ellipse.vector3d_0 = vector3d2;
				ellipse.vector3d_1 = vector3d;
			}
			return ellipse;
		}

		public Point RandomPointInEllipse()
		{
			double scalar = RandomGenerator.NextDouble_1_1();
			double tetha = RandomGenerator.NextDouble_0_2Pi();
			Point pointAtParameter = this.GetPointAtParameter(tetha);
			Vector3d vector3d = scalar * new Vector3d(pointAtParameter - this.point_0);
			return this.point_0 + vector3d.ToPoint();
		}

		public Point RandomPointOnEllipse()
		{
			double tetha = RandomGenerator.NextDouble_0_2Pi();
			return this.GetPointAtParameter(tetha);
		}

		public Ellipse ReflectIn(Point point)
		{
			return new Ellipse
			{
				point_0 = this.point_0.ReflectIn(point),
				vector3d_0 = -1.0 * this.vector3d_0,
				vector3d_1 = -1.0 * this.vector3d_1
			};
		}

		public Ellipse ReflectIn(Line line)
		{
			Point point = new Point(this.point_0.X + this.vector3d_0.X, this.point_0.Y + this.vector3d_0.Y, this.point_0.Z + this.vector3d_0.Z);
			Point point2 = new Point(this.point_0.X + this.vector3d_1.X, this.point_0.Y + this.vector3d_1.Y, this.point_0.Z + this.vector3d_1.Z);
			Point right = this.point_0.ReflectIn(line);
			Point left = point.ReflectIn(line);
			Point left2 = point2.ReflectIn(line);
			Vector3d vector3d = new Vector3d(left - right);
			Vector3d vector3d2 = new Vector3d(left2 - right);
			Ellipse ellipse = new Ellipse();
			ellipse.point_0 = right;
			if (vector3d.Norm >= vector3d2.Norm)
			{
				ellipse.vector3d_0 = vector3d;
				ellipse.vector3d_1 = vector3d2;
			}
			else
			{
				ellipse.vector3d_0 = vector3d2;
				ellipse.vector3d_1 = vector3d;
			}
			return ellipse;
		}

		public Ellipse ReflectIn(Plane plane)
		{
			Point point = new Point(this.point_0.X + this.vector3d_0.X, this.point_0.Y + this.vector3d_0.Y, this.point_0.Z + this.vector3d_0.Z);
			Point point2 = new Point(this.point_0.X + this.vector3d_1.X, this.point_0.Y + this.vector3d_1.Y, this.point_0.Z + this.vector3d_1.Z);
			Point right = this.point_0.ReflectIn(plane);
			Point left = point.ReflectIn(plane);
			Point left2 = point2.ReflectIn(plane);
			Vector3d vector3d = new Vector3d(left - right);
			Vector3d vector3d2 = new Vector3d(left2 - right);
			Ellipse ellipse = new Ellipse();
			ellipse.point_0 = right;
			if (vector3d.Norm >= vector3d2.Norm)
			{
				ellipse.vector3d_0 = vector3d;
				ellipse.vector3d_1 = vector3d2;
			}
			else
			{
				ellipse.vector3d_0 = vector3d2;
				ellipse.vector3d_1 = vector3d;
			}
			return ellipse;
		}

		public Ellipse Rotate(Matrix3d rotationMatrix)
		{
			return new Ellipse
			{
				point_0 = rotationMatrix * this.point_0,
				vector3d_0 = rotationMatrix * this.vector3d_0,
				vector3d_1 = rotationMatrix * this.vector3d_1
			};
		}

		public Ellipse Rotate(Point center, Matrix3d rotationMatrix)
		{
			return new Ellipse
			{
				point_0 = this.point_0.Rotate(center, rotationMatrix),
				vector3d_0 = rotationMatrix * this.vector3d_0,
				vector3d_1 = rotationMatrix * this.vector3d_1
			};
		}

		public Ellipse Scale(Point center, double scaleFactor)
		{
			Ellipse ellipse = new Ellipse();
			ellipse.point_0 = this.point_0.Scale(center, scaleFactor);
			ellipse.vector3d_0 = scaleFactor * this.vector3d_0;
			ellipse.vector3d_1 = scaleFactor * this.vector3d_1;
			if (ellipse.vector3d_0.Norm < 4.94065645841247E-324 | ellipse.vector3d_1.Norm < 4.94065645841247E-324)
			{
				throw new ArithmeticException("Scale factor is too small: an axis of the ellipse has zero length.");
			}
			return ellipse;
		}

		public Ellipse Scale(Point center, double scaleX, double scaleY, double scaleZ)
		{
			Ellipse ellipse = this.DeepCopy();
			Point m = this.point_0.Scale(center, scaleX, scaleY, scaleZ);
			Edge edge = ellipse.MajorAxis.Scale(center, scaleX, scaleY, scaleZ);
			Edge edge2 = ellipse.MinorAxis.Scale(center, scaleX, scaleY, scaleZ);
			if (edge.Length < Global.AbsoluteEpsilon | edge2.Length < Global.AbsoluteEpsilon)
			{
				throw new ArithmeticException("Can not construct ellipse: scale factor is too small!");
			}
			if (edge.IsCollinearTo(edge2))
			{
				throw new ArithmeticException("Can not construct ellipse: scale factor is too small!");
			}
			return Ellipse.ConstructFromConjugateDiameters(m, edge.EndPoint, edge2.EndPoint);
		}

		public Vector3d TangentVector2d(Point point)
		{
			if (!this.ContainsOnCircumference(point))
			{
				return null;
			}
			double norm = this.vector3d_0.Norm;
			double norm2 = this.vector3d_1.Norm;
			Vector3d vector3d = new Vector3d(point - this.point_0);
			Vector3d vector3d2 = vector3d.ProjectParallelOn(this.vector3d_0);
			Vector3d vector3d3 = vector3d.ProjectParallelOn(this.vector3d_1);
			double num = (double)Math.Sign(Vector3d.Dot(vector3d2, this.vector3d_0)) * vector3d2.Norm;
			double num2 = (double)Math.Sign(Vector3d.Dot(vector3d3, this.vector3d_1)) * vector3d3.Norm;
			double scalar = -norm / norm2 * num2;
			double scalar2 = norm2 / norm * num;
			return scalar * this.vector3d_0.Normalize() + scalar2 * this.vector3d_1.Normalize();
		}

		public Circle ToCircle()
		{
			if (!this.IsCircular)
			{
				throw new ArgumentException("Can not convert non-circular ellipse into a circle.");
			}
			double radius = 0.5 * (this.vector3d_0.Norm + this.vector3d_1.Norm);
			return new Circle(this.point_0, radius, this.NormalVector);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Ellipse ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  Center        : ",
				this.Center.ToString(),
				Environment.NewLine,
				"  Semimajor axis: ",
				this.SemimajorAxisVector.ToString(),
				Environment.NewLine,
				"  Semiminor axis: ",
				this.SemiminorAxisVector.ToString(),
				Environment.NewLine,
				"  Width         : ",
				this.Width.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Height        : ",
				this.Height.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Normal vector : ",
				this.NormalVector.ToString(),
				Environment.NewLine,
				"  Area          : ",
				this.Area.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Circumference : ",
				this.Circumference.ToString(Global.StringNumberFormat)
			});
		}

		public Ellipse TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Point point = this.Center;
			Point point2 = point + this.vector3d_0.ToPoint();
			Point point3 = point + this.vector3d_1.ToPoint();
			point = point.TransformCoordinates(actualCS, newCS);
			point2 = point2.TransformCoordinates(actualCS, newCS);
			point3 = point3.TransformCoordinates(actualCS, newCS);
			return Ellipse.ConstructFromConjugateDiameters(point, point2, point3);
		}

		public static List<Ellipse> TransformCoordinates(List<Ellipse> ellipses, CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d basisVectorMatrix2 = newCS.BasisVectorMatrix;
			Point b = actualCS.Origin - newCS.Origin;
			Matrix3d a = basisVectorMatrix2.Invert() * basisVectorMatrix;
			Point right = basisVectorMatrix2.Invert() * b;
			List<Ellipse> list = new List<Ellipse>(ellipses.Count);
			for (int i = 0; i < ellipses.Count; i++)
			{
				Point point = ellipses[i].point_0;
				Point point2 = point + ellipses[i].vector3d_0.ToPoint();
				Point point3 = point + ellipses[i].vector3d_1.ToPoint();
				point = a * point + right;
				point2 = a * point2 + right;
				point3 = a * point3 + right;
				list.Add(Ellipse.ConstructFromConjugateDiameters(point, point2, point3));
			}
			return list;
		}

		public double Area
		{
			get
			{
				return 3.1415926535897931 * this.vector3d_0.Norm * this.vector3d_1.Norm;
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
				double arg_06_0 = this.NumericalEccentricity;
				double norm = this.vector3d_0.Norm;
				double norm2 = this.vector3d_1.Norm;
				double num = (norm - norm2) / (norm + norm2);
				double num2 = 1.0 + 3.0 * num * num / (10.0 + Math.Sqrt(4.0 - 3.0 * num * num));
				return 3.1415926535897931 * (norm + norm2) * num2;
			}
		}

		public PointSet FocalPoints
		{
			get
			{
				PointSet pointSet = new PointSet();
				double numericalEccentricity = this.NumericalEccentricity;
				pointSet.Add(this.point_0 + numericalEccentricity * this.vector3d_0.ToPoint());
				pointSet.Add(this.point_0 - numericalEccentricity * this.vector3d_0.ToPoint());
				return pointSet;
			}
		}

		public double Height
		{
			get
			{
				return this.MinorAxis.Length;
			}
			set
			{
				this.vector3d_1.Norm = value / 2.0;
				if (value > this.Width)
				{
					throw new ArgumentException("Ellipse width is smaller than ellipse height.");
				}
				if (value <= 0.0)
				{
					throw new ArgumentException("Ellipse height must be grater than zero.");
				}
			}
		}

		public bool IsCircular
		{
			get
			{
				return Global.AlmostEquals(this.vector3d_0.Norm, this.vector3d_1.Norm);
			}
		}

		public Edge MajorAxis
		{
			get
			{
				Point startPoint = this.point_0 - this.vector3d_0.ToPoint();
				Point endPoint = this.point_0 + this.vector3d_0.ToPoint();
				return new Edge(startPoint, endPoint);
			}
		}

		public Edge MinorAxis
		{
			get
			{
				Point startPoint = this.point_0 - this.vector3d_1.ToPoint();
				Point endPoint = this.point_0 + this.vector3d_1.ToPoint();
				return new Edge(startPoint, endPoint);
			}
		}

		public Vector3d NormalVector
		{
			get
			{
				return Vector3d.Cross(this.vector3d_0, this.vector3d_1).Normalize();
			}
		}

		public double NumericalEccentricity
		{
			get
			{
				double num = this.vector3d_0.method_0();
				double num2 = this.vector3d_1.method_0();
				return Math.Sqrt(Math.Abs(num - num2) / num);
			}
		}

		public Vector3d SemimajorAxisVector
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
					throw new ArgumentException("Zero length semimajor axis vector not allowed for ellipse!");
				}
				if (this.vector3d_0.Norm < this.vector3d_1.Norm)
				{
					throw new ArgumentException("Semimajor axis length smaller than semiminor axis length!");
				}
				if (!this.vector3d_0.IsOrthogonalTo(this.vector3d_1))
				{
					throw new ArgumentException("Ellipse axes are not orthogonal!");
				}
			}
		}

		public Vector3d SemiminorAxisVector
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
					throw new ArgumentException("Zero length semiminor axis vector not allowed for ellipse!");
				}
				if (this.vector3d_0.Norm < this.vector3d_1.Norm)
				{
					throw new ArgumentException("Semimajor axis length smaller than semiminor axis length!");
				}
				if (!this.vector3d_0.IsOrthogonalTo(this.vector3d_1))
				{
					throw new ArgumentException("Ellipse axes are not orthogonal! ");
				}
			}
		}

		public double Width
		{
			get
			{
				return this.MajorAxis.Length;
			}
			set
			{
				this.vector3d_0.Norm = value / 2.0;
				if (value < this.Height)
				{
					throw new ArgumentException("Ellipse width is smaller than ellipse height.");
				}
				if (value <= 0.0)
				{
					throw new ArgumentException("Ellipse width must be grater than zero.");
				}
			}
		}

		private CADData caddata_0;

		private Point point_0;

		private Vector3d vector3d_0;

		private Vector3d vector3d_1;
	}
}
