using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	
	[Serializable]
	public class Arc
	{
		public Arc()
		{
			
		}

		public Arc(Point startPoint, Point pointOnArc, Point endPoint)
		{			
			Circle circle = new Circle(startPoint, pointOnArc, endPoint);
			this.point_0 = circle.Center;
			this.point_1 = startPoint;
			this.vector3d_0 = circle.NormalVector;
			Vector3d a = new Vector3d(startPoint - this.point_0);
			Vector3d b = new Vector3d(endPoint - this.point_0);
			this.double_0 = Vector3d.OrientedAngle(a, b, this.vector3d_0);
		}

		public Arc(Point center, Point startPoint, Vector3d normalVector, double openingAngle)
		{
			
			this.point_0 = center;
			this.point_1 = startPoint;
			this.vector3d_0 = normalVector;
			this.double_0 = openingAngle;
			if (!new Vector3d(this.point_1 - this.point_0).IsOrthogonalTo(this.vector3d_0))
			{
				throw new ArgumentException("Error constructing arc: arc normal vector not orthogonal to arc start vector.");
			}
		}

		public Arc(Point center, Vector3d startVector, Vector3d endVector, Vector3d normalVector)
		{
			
			this.point_0 = center;
			this.point_1 = center + startVector.ToPoint();
			this.vector3d_0 = normalVector;
			double num = Vector3d.OrientedAngle(startVector, endVector, normalVector);
			this.double_0 = num;
			if (!Global.AlmostEquals(startVector.Norm, endVector.Norm))
			{
				throw new ArgumentException("Error constructing arc: start vector length not equal end vector length.");
			}
			if (!startVector.IsOrthogonalTo(normalVector) && !endVector.IsOrthogonalTo(normalVector))
			{
				throw new ArgumentException("Error constructing arc: Normal vector not orthogonal to start and end vector.");
			}
		}

		public double ArcLength()
		{
			return this.Radius() * this.double_0;
		}

		public double AreaOfSector()
		{
			double num = this.Radius();
			return 0.5 * num * num * this.double_0;
		}

		public double AreaOfSegment()
		{
			if (this.double_0 > 3.1415926535897931)
			{
				throw new InvalidOperationException("Arc segment area only defined for opening angles less than PI. (actual value: " + this.double_0 + ")");
			}
			double openingAngle = this.OpeningAngle;
			double num = this.Radius();
			return 0.5 * num * num * (openingAngle - Math.Sin(openingAngle));
		}

		public bool ContainsOnCircumference(Point point)
		{
			if (!this.ToCircle().ContainsOnCircumference(point))
			{
				return false;
			}
			Vector3d a = new Vector3d(this.point_1 - this.point_0);
			Vector3d b = new Vector3d(point - this.point_0);
			double num = Vector3d.OrientedAngle(a, b, this.vector3d_0);
			if (Global.AlmostEquals(num, 6.2831853071795862, 1E-08, 1E-08))
			{
				num = 0.0;
			}
			return num <= this.double_0 || Global.AlmostEquals(num, this.double_0, 1E-08, 1E-08);
		}

		public Arc DeepCopy()
		{
			return new Arc
			{
				point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z),
				point_1 = new Point(this.point_1.X, this.point_1.Y, this.point_1.Z),
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z),
				double_0 = this.double_0
			};
		}

		public Point EndPoint()
		{
			Matrix3d rotationMatrix = Matrix3d.RotationArbitraryAxis(this.vector3d_0, this.double_0);
			return this.point_1.Rotate(this.point_0, rotationMatrix);
		}

		public Vector3d EndVector()
		{
			return new Vector3d(this.EndPoint() - this.point_0);
		}

		public override bool Equals(object obj)
		{
			return this == (Arc)obj;
		}

		public double[] ExtentsXY()
		{
			double[] array = this.ToCircle().ToEllipse().ExtentsXY();
			Point startPoint = this.StartPoint;
			Point point = this.EndPoint();
			double val = Math.Min(startPoint.X, point.X);
			double val2 = Math.Max(startPoint.X, point.X);
			double val3 = Math.Min(startPoint.Y, point.Y);
			double val4 = Math.Max(startPoint.Y, point.Y);
			return new double[]
			{
				Math.Max(array[0], val),
				Math.Min(array[1], val2),
				Math.Max(array[2], val3),
				Math.Min(array[3], val4)
			};
		}

		public List<Edge> GenerateEdgesOnPerimeter(int n)
		{
			List<Edge> list = new List<Edge>();
			PointSet pointSet = this.GeneratePointsOnPerimeter(n + 1);
			for (int i = 0; i < pointSet.Count - 1; i++)
			{
				list.Add(new Edge(pointSet[i], pointSet[i + 1]));
			}
			return list;
		}

		public PointSet GeneratePointsOnPerimeter(int n)
		{
			if (n < 2)
			{
				throw new ArgumentException("Can not generate less than two points on perimeter of arc.");
			}
			PointSet pointSet = new PointSet();
			double num = this.double_0 / (double)(n - 1);
			for (int i = 0; i < n; i++)
			{
				Matrix3d rotationMatrix = Matrix3d.RotationArbitraryAxis(this.vector3d_0, (double)i * num);
				pointSet.Add(this.StartPoint.Rotate(this.point_0, rotationMatrix));
			}
			return pointSet;
		}

		public override int GetHashCode()
		{
			return this.point_0.GetHashCode() ^ this.point_1.GetHashCode() ^ this.vector3d_0.ToPoint().GetHashCode() ^ this.double_0.GetHashCode();
		}

		public Plane GetPlane()
		{
			return new Plane(this.point_0, this.vector3d_0);
		}

		public void Invert()
		{
			this.vector3d_0 = -1.0 * this.vector3d_0;
			this.double_0 = 6.2831853071795862 - this.double_0;
		}

		public PointSet method_0(Plane plane)
		{
			Edge edge = this.ToCircle().method_6(plane);
			if (edge == null)
			{
				return null;
			}
			PointSet pointSet = new PointSet();
			if (this.ContainsOnCircumference(edge.StartPoint))
			{
				pointSet.Add(edge.StartPoint);
			}
			if (edge.StartPoint == edge.EndPoint)
			{
				return pointSet;
			}
			if (this.ContainsOnCircumference(edge.EndPoint))
			{
				pointSet.Add(edge.EndPoint);
			}
			return pointSet;
		}

		internal CoordinateSystem method_1()
		{
			Vector3d vector3d = this.vector3d_0.Normalize();
			Vector3d a = new Vector3d(0.0, 1.0, 0.0);
			Vector3d a2 = new Vector3d(0.0, 0.0, 1.0);
			Vector3d vector3d2;
			if (Math.Abs(vector3d.X) < 0.015625 && Math.Abs(vector3d.Y) < 0.015625)
			{
				vector3d2 = Vector3d.Cross(a, vector3d).Normalize();
			}
			else
			{
				vector3d2 = Vector3d.Cross(a2, vector3d).Normalize();
			}
			Vector3d value = Vector3d.Cross(vector3d, vector3d2).Normalize();
			CoordinateSystem coordinateSystem = new CoordinateSystem();
			coordinateSystem.Origin = new Point(0.0, 0.0, 0.0);
			coordinateSystem.BasisVector[0] = vector3d2;
			coordinateSystem.BasisVector[1] = value;
			coordinateSystem.BasisVector[2] = vector3d;
			return coordinateSystem;
		}

		internal double method_2()
		{
			return Vector3d.OrientedAngle(this.method_1().BasisVector[0], this.StartVector(), this.vector3d_0);
		}

		internal double method_3()
		{
			return Vector3d.OrientedAngle(this.method_1().BasisVector[0], this.EndVector(), this.vector3d_0);
		}

		public Arc Move(Vector3d displacementVector)
		{
			return new Arc
			{
				point_0 = this.point_0 + displacementVector.ToPoint(),
				point_1 = this.point_1 + displacementVector.ToPoint(),
				vector3d_0 = this.vector3d_0.DeepCopy(),
				double_0 = this.double_0
			};
		}

		public Arc Move(Point startPoint, Point endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public static bool operator ==(Arc left, Arc right)
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
            if (left.point_1 != right.point_1)
            {
                return false;
            }
            if (left.vector3d_0 != right.vector3d_0)
            {
                return false;
            }
            if (!Global.AlmostEquals(left.double_0, right.double_0))
            {
                return false;
            }
            return true;
		}

		public static bool operator !=(Arc left, Arc right)
		{
			return !(left == right);
		}

		public double Radius()
		{
			return this.point_1.DistanceTo(this.point_0);
		}

		public static Arc RandomArc()
		{
			Arc arc = new Arc();
			arc.point_0 = Point.RandomPoint();
			arc.point_1 = Point.RandomPoint();
			arc.vector3d_0 = new Vector3d(arc.point_1 - arc.point_0).RandomOrthonormal();
			arc.double_0 = RandomGenerator.NextDouble_0_2Pi();
			return arc;
		}

		public Point RandomPointOnArc()
		{
			double radian = RandomGenerator.NextDouble(0.0, this.double_0);
			Matrix3d rotationMatrix = Matrix3d.RotationArbitraryAxis(this.vector3d_0, radian);
			return this.point_1.Rotate(this.point_0, rotationMatrix);
		}

		public Arc Rotate(Matrix3d rotationMatrix)
		{
			return new Arc
			{
				point_0 = rotationMatrix * this.point_0,
				point_1 = rotationMatrix * this.point_1,
				vector3d_0 = rotationMatrix * this.vector3d_0,
				double_0 = this.double_0
			};
		}

		public Arc Rotate(Point center, Matrix3d rotationMatrix)
		{
			return new Arc
			{
				point_0 = this.point_0.Rotate(center, rotationMatrix),
				point_1 = this.point_1.Rotate(center, rotationMatrix),
				vector3d_0 = rotationMatrix * this.vector3d_0,
				double_0 = this.double_0
			};
		}

		public Vector3d StartVector()
		{
			return new Vector3d(this.point_1 - this.point_0);
		}

		public Circle ToCircle()
		{
			return new Circle(this.point_0, this.Radius(), this.vector3d_0);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Arc ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  Center        : ",
				this.point_0.ToString(),
				Environment.NewLine,
				"  Radius        : ",
				this.Radius().ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Start vector  : ",
				new Vector3d(this.StartPoint - this.Center).ToString(),
				Environment.NewLine,
				"  End vector    : ",
				new Vector3d(this.EndPoint() - this.Center).ToString(),
				Environment.NewLine,
				"  Normal vector : ",
				this.vector3d_0.ToString(),
				Environment.NewLine,
				"  Start point   : ",
				this.StartPoint.ToString(),
				Environment.NewLine,
				"  End point     : ",
				this.EndPoint().ToString(),
				Environment.NewLine,
				"  Opening angle : ",
				this.double_0.ToString(Global.StringNumberFormat),
				Environment.NewLine,
				"  Arc length    : ",
				this.ArcLength().ToString()
			});
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
		}

		public Vector3d NormalVector
		{
			get
			{
				return this.vector3d_0;
			}
		}

		public double OpeningAngle
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				if (this.double_0 > 6.2831853071795862)
				{
					throw new ArgumentException("Arc opening angle was " + value + ". Must be less than 2.0*PI.");
				}
			}
		}

		public Point StartPoint
		{
			get
			{
				return this.point_1;
			}
		}

		private CADData caddata_0;

		private double double_0;

		private Point point_0;

		private Point point_1;

		private Vector3d vector3d_0;
	}
}
