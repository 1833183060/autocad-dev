using System;
using System.ComponentModel;
using Autodesk.AutoCAD.DatabaseServices;

namespace ceometric.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class Point2 : IComparable<Point2>
	{
		public Point2()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Point2));
			//base..ctor();
		}

		public Point2(Vector3d vector)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Point2));
			//base..ctor();
			this.double_0 = vector.X;
			this.double_1 = vector.Y;
			this.double_2 = vector.Z;
		}

		public Point2(double X, double Y, double Z)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Point2));
			//base..ctor();
			this.double_0 = X;
			this.double_1 = Y;
			this.double_2 = Z;
		}

		public int CompareTo(Point2 point)
		{
			if (this.X != point.X)
			{
				return this.X.CompareTo(point.X);
			}
			if (this.Y != point.Y)
			{
				return this.Y.CompareTo(point.Y);
			}
			return this.Z.CompareTo(point.Z);
		}

		public Point2 DeepCopy()
		{
			return new Point2(this.double_0, this.double_1, this.double_2);
		}

		public double DistanceTo(Point2 point)
		{
			double num = this.double_0 - point.double_0;
			double num2 = this.double_1 - point.double_1;
			double num3 = this.double_2 - point.double_2;
			return Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		}

		public double DistanceTo(Line line)
		{
			Vector3d b = new Vector3d(this - line.Point2);
			Vector3d a = line.DirectionVector.Normalize();
			Vector3d vector3d = Vector3d.Cross(a, b);
			double d = vector3d.X * vector3d.X + vector3d.Y * vector3d.Y + vector3d.Z * vector3d.Z;
			return Math.Sqrt(d);
		}

		public double DistanceTo(Edge edge)
		{
			return this.PseudoPerdendicularOn(edge).Length;
		}

		public double DistanceTo(Plane plane)
		{
			return Vector3d.Dot(plane.NCF_normal, this.method_2()) - plane.NCF_d;
		}

		public double DistanceToPerimeter(Circle circle)
		{
			return this.PerpendicularOnPerimeter(circle).Length;
		}

		public double DistanceToPerimeter(Ellipse ellipse)
		{
			return this.PerpendicularOnPerimeter(ellipse).Length;
		}

		public double DistanceXY(Point2 p)
		{
			double num = this.double_0 - p.double_0;
			double num2 = this.double_1 - p.double_1;
			return Math.Sqrt(num * num + num2 * num2);
		}

		public override bool Equals(object obj)
		{
			return this == (Point2)obj;
		}

		public override int GetHashCode()
		{
			int hashCode = this.double_0.ToString().GetHashCode();
			int hashCode2 = this.double_1.ToString().GetHashCode();
			int hashCode3 = this.double_2.ToString().GetHashCode();
			return hashCode ^ hashCode2 ^ hashCode3;
		}

		public bool IsCollinearTo(Edge edge)
		{
			return edge.Length < 4.94065645841247E-324 || edge.ToLine().Contains(this);
		}

		public bool IsCollinearTo(Line line)
		{
			return line.Contains(this);
		}

		public bool IsCoplanarTo(Plane plane)
		{
			return plane.Contains(this);
		}

		public bool IsCoplanarTo(Triangle triangle)
		{
			return Plane.smethod_0(triangle.Vertex1, triangle.NormalVector, this);
		}

		public bool IsCoplanarTo(Circle circle)
		{
			return Plane.smethod_0(circle.Center, circle.NormalVector, this);
		}

		public bool IsCoplanarTo(Ellipse ellipse)
		{
			return Plane.smethod_0(ellipse.Center, ellipse.NormalVector, this);
		}

		private Point2 method_0(Line line_0)
		{
			Vector3d vector3d = line_0.DirectionVector.Normalize();
			double scalar = Vector3d.Dot(new Vector3d(this - line_0.Point2), vector3d);
			return line_0.Point2 + scalar * vector3d.ToPoint();
		}

		private Point2 method_1(Plane plane_0)
		{
			Vector3d nCF_normal = plane_0.NCF_normal;
			double num = Vector3d.Dot(this.method_2(), nCF_normal);
			double scalar = plane_0.NCF_d - num;
			return this + scalar * nCF_normal.ToPoint();
		}

		public Vector3d method_2()
		{
			return new Vector3d(this.double_0, this.double_1, this.double_2);
		}

		internal double method_3(Point2 point_0)
		{
			double num = this.double_0 - point_0.double_0;
			double num2 = this.double_1 - point_0.double_1;
			double num3 = this.double_2 - point_0.double_2;
			return num * num + num2 * num2 + num3 * num3;
		}

		public Point2 Move(Vector3d displacementVector)
		{
			return this + displacementVector.ToPoint();
		}

		public Point2 Move(Point2 startPoint, Point2 endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public static Point2 operator +(Point2 left, Point2 right)
		{
			return new Point2
			{
				double_0 = left.double_0 + right.double_0,
				double_1 = left.double_1 + right.double_1,
				double_2 = left.double_2 + right.double_2
			};
		}

		public static bool operator ==(Point2 left, Point2 right)
		{
            return (object)left == (object)right || ((object)left != null && (object)right != null && Global.AlmostEquals(left.double_0, right.double_0) && Global.AlmostEquals(left.double_1, right.double_1) && Global.AlmostEquals(left.double_2, right.double_2));
		}

		public static bool operator !=(Point2 left, Point2 right)
		{
			return !(left == right);
		}

		public static Point2 operator *(double scalar, Point2 point)
		{
			return new Point2
			{
				double_0 = scalar * point.double_0,
				double_1 = scalar * point.double_1,
				double_2 = scalar * point.double_2
			};
		}

		public static Point2 operator *(Point2 point, double scalar)
		{
			return new Point2
			{
				double_0 = scalar * point.double_0,
				double_1 = scalar * point.double_1,
				double_2 = scalar * point.double_2
			};
		}

		public static Point2 operator -(Point2 left, Point2 right)
		{
			return new Point2
			{
				double_0 = left.double_0 - right.double_0,
				double_1 = left.double_1 - right.double_1,
				double_2 = left.double_2 - right.double_2
			};
		}

		public Edge PerpendicularOn(Line line)
		{
			Point2 endPoint = this.method_0(line);
			return new Edge(this, endPoint);
		}

		public Edge PerpendicularOn(Plane plane)
		{
			Point2 endPoint = this.method_1(plane);
			return new Edge(this, endPoint);
		}

		public Edge PerpendicularOnPerimeter(Circle circle)
		{
			return this.PerpendicularOnPerimeter(circle.ToEllipse());
		}

		public Edge PerpendicularOnPerimeter(Ellipse ellipse)
		{
			Class12.point_0 = new Point2(this.double_0, this.double_1, this.double_2);
			Class12.ellipse_0 = ellipse.DeepCopy();
			LineSearch.ObjectiveFunction function = new LineSearch.ObjectiveFunction(Class12.smethod_0);
			double parameterAtPoint = ellipse.GetParameterAtPoint(Class12.point_0);
			double tetha;
			if (parameterAtPoint <= 3.1415926535897931)
			{
				tetha = LineSearch.GoldenSection(0.001 * Global.AbsoluteEpsilon, 0.0, 3.1415926535897931, function);
			}
			else
			{
				tetha = LineSearch.GoldenSection(0.001 * Global.AbsoluteEpsilon, 3.1415926535897931, 6.2831853071795862, function);
			}
			return new Edge(this, ellipse.GetPointAtParameter(tetha));
		}

		public Point2 ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			Line line = new Line(this, viewDirection);
			Point2 point = line.method_5(plane);
			if (point == null)
			{
				throw new ArgumentException("View direction parallel to projection plane!");
			}
			return point;
		}

		public Edge PseudoPerdendicularOn(Edge edge)
		{
			if (edge.Length < 4.94065645841247E-324)
			{
				return new Edge(this, edge.MidPoint);
			}
			Point2 point = this.method_0(edge.ToLine());
			if (edge.CollinearContains(point))
			{
				return new Edge(this, point);
			}
			double num = this.DistanceTo(edge.StartPoint);
			double num2 = this.DistanceTo(edge.EndPoint);
			if (num < num2)
			{
				return new Edge(this, edge.StartPoint);
			}
			return new Edge(this, edge.EndPoint);
		}

		public static Point2 RandomPoint()
		{
			return new Point2
			{
				double_0 = RandomGenerator.NextDouble_mr_mr(),
				double_1 = RandomGenerator.NextDouble_mr_mr(),
				double_2 = RandomGenerator.NextDouble_mr_mr()
			};
		}

		public Point2 ReflectIn(Point2 point)
		{
			return 2.0 * point - this;
		}

		public Point2 ReflectIn(Line line)
		{
			return this.ReflectIn(this.method_0(line));
		}

		public Point2 ReflectIn(Plane plane)
		{
			return this.ReflectIn(this.method_1(plane));
		}

		public Point2 Rotate(Matrix3d rotationMatrix)
		{
			return rotationMatrix * this;
		}

		public Point2 Rotate(Point2 center, Matrix3d rotationMatrix)
		{
			double num = this.double_0 - center.double_0;
			double num2 = this.double_1 - center.double_1;
			double num3 = this.double_2 - center.double_2;
			double num4 = rotationMatrix.a00 * num + rotationMatrix.a01 * num2 + rotationMatrix.a02 * num3;
			double num5 = rotationMatrix.a10 * num + rotationMatrix.a11 * num2 + rotationMatrix.a12 * num3;
			double num6 = rotationMatrix.a20 * num + rotationMatrix.a21 * num2 + rotationMatrix.a22 * num3;
			return new Point2(num4 + center.double_0, num5 + center.double_1, num6 + center.double_2);
		}

		public void Round(int decimals)
		{
			this.double_0 = Math.Round(this.double_0, decimals);
			this.double_1 = Math.Round(this.double_1, decimals);
			this.double_2 = Math.Round(this.double_2, decimals);
		}

		public Point2 Scale(Point2 center, double scaleFactor)
		{
			Point2 point = this - center;
			return center + scaleFactor * point;
		}

		public Point2 Scale(Point2 center, double scaleX, double scaleY, double scaleZ)
		{
			Point2 point = this - center;
			return center + new Point2(scaleX * point.double_0, scaleY * point.double_1, scaleZ * point.double_2);
		}

		public double[] ToArray()
		{
			return new double[]
			{
				this.double_0,
				this.double_1,
				this.double_2
			};
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"(",
				this.double_0.ToString(Global.StringNumberFormat),
				", ",
				this.double_1.ToString(Global.StringNumberFormat),
				", ",
				this.double_2.ToString(Global.StringNumberFormat),
				")"
			});
		}

		public Point2 TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d matrix3d = newCS.BasisVectorMatrix.Invert();
			double num = actualCS.Origin.X - newCS.Origin.X;
			double num2 = actualCS.Origin.Y - newCS.Origin.Y;
			double num3 = actualCS.Origin.Z - newCS.Origin.Z;
			double num4 = basisVectorMatrix.a00 * this.double_0 + basisVectorMatrix.a01 * this.double_1 + basisVectorMatrix.a02 * this.double_2 + num;
			double num5 = basisVectorMatrix.a10 * this.double_0 + basisVectorMatrix.a11 * this.double_1 + basisVectorMatrix.a12 * this.double_2 + num2;
			double num6 = basisVectorMatrix.a20 * this.double_0 + basisVectorMatrix.a21 * this.double_1 + basisVectorMatrix.a22 * this.double_2 + num3;
			double x = matrix3d.a00 * num4 + matrix3d.a01 * num5 + matrix3d.a02 * num6;
			double y = matrix3d.a10 * num4 + matrix3d.a11 * num5 + matrix3d.a12 * num6;
			double z = matrix3d.a20 * num4 + matrix3d.a21 * num5 + matrix3d.a22 * num6;
			return new Point2(x, y, z);
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

		public double X
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
			}
		}

		public double Y
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
			}
		}

		public double Z
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
			}
		}

		public DBPoint acDbPoint;

		private CADData caddata_0;

		private double double_0;

		private double double_1;

		private double double_2;
	}
}
