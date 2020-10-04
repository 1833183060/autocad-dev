using System;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class Vector3d
	{
		public Vector3d()
		{            
		}

		public Vector3d(Point point)
		{            
			this.x = point.X;
			this.y = point.Y;
			this.z = point.Z;
		}

		public Vector3d(double X, double Y, double Z)
		{           
			this.x = X;
			this.y = Y;
			this.z = Z;
		}

		public static double Angle(Vector3d a, Vector3d b)
		{
			Vector3d vector3d = a.Normalize();
			Vector3d vector3d2 = b.Normalize();
			double num = vector3d.x * vector3d2.x + vector3d.y * vector3d2.y + vector3d.z * vector3d2.z;
			if (num > 1.0)
			{
				num = 1.0;
			}
			if (num < -1.0)
			{
				num = -1.0;
			}
			return Math.Acos(num);
		}

		public static double AngleCosine(Vector3d a, Vector3d b)
		{
			Vector3d vector3d = a.Normalize();
			Vector3d vector3d2 = b.Normalize();
			double num = vector3d.x * vector3d2.x + vector3d.y * vector3d2.y + vector3d.z * vector3d2.z;
			if (num > 1.0)
			{
				num = 1.0;
			}
			if (num < -1.0)
			{
				num = -1.0;
			}
			return num;
		}

		public static Vector3d Bisector(Vector3d a, Vector3d b)
		{
			return a.Normalize() + b.Normalize();
		}

		public static Vector3d Cross(Vector3d a, Vector3d b)
		{
			return new Vector3d(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
		}

		public Vector3d DeepCopy()
		{
			return new Vector3d(this.x, this.y, this.z);
		}

		public static double Dot(Vector3d a, Vector3d b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		public override bool Equals(object obj)
		{
			return this == (Vector3d)obj;
		}

		public override int GetHashCode()
		{
			int hashCode = this.x.GetHashCode();
			int hashCode2 = this.y.GetHashCode();
			int hashCode3 = this.z.GetHashCode();
			return hashCode ^ hashCode2 ^ hashCode3;
		}

		public bool IsIndependentTo(Vector3d a)
		{
			return !this.IsParallelTo(a);
		}

		public bool IsOrthogonalTo(Vector3d a)
		{
			double num = a.x * a.x + a.y * a.y + a.z * a.z;
			if (num < 4.94065645841247E-324)
			{
				return false;
			}
			double num2 = this.x * this.x + this.y * this.y + this.z * this.z;
			return num2 >= 4.94065645841247E-324 && Vector3d.smethod_1(this, a);
		}

		public bool IsParallelTo(Vector3d a)
		{
			double num = Vector3d.Dot(this, this);
			double value = Vector3d.Dot(this, a);
			double num2 = Vector3d.Dot(a, a);
			return Global.AlmostEquals(Math.Abs(value), Math.Sqrt(num * num2));
		}

		internal double method_0()
		{
			return this.x * this.x + this.y * this.y + this.z * this.z;
		}

		public Vector3d Normalize()
		{
			double norm = this.Norm;
			if (norm < 4.94065645841247E-324)
			{
				throw new ArithmeticException("Can not normalize zero length vector");
			}
			double num = 1.0 / norm;
			return new Vector3d(num * this.x, num * this.y, num * this.z);
		}

		public static Vector3d operator +(Vector3d left, Vector3d right)
		{
			return new Vector3d
			{
				x = left.x + right.x,
				y = left.y + right.y,
				z = left.z + right.z
			};
		}

		public static bool operator ==(Vector3d left, Vector3d right)
		{
            return (object)left == (object)right || ((object)left != null && (object)right != null && Global.AlmostEquals(left.x, right.x) && Global.AlmostEquals(left.y, right.y) && Global.AlmostEquals(left.z, right.z));
		}

		public static bool operator !=(Vector3d left, Vector3d right)
		{
			return !(left == right);
		}

		public static Vector3d operator *(double scalar, Vector3d vector)
		{
			return new Vector3d
			{
				x = vector.x * scalar,
				y = vector.y * scalar,
				z = vector.z * scalar
			};
		}

		public static Vector3d operator *(Vector3d vector, double scalar)
		{
			return new Vector3d
			{
				x = vector.x * scalar,
				y = vector.y * scalar,
				z = vector.z * scalar
			};
		}

		public static double operator *(Vector3d left, Vector3d right)
		{
			return left.x * right.x + left.y * right.y + left.z * right.z;
		}

		public static Vector3d operator -(Vector3d left, Vector3d right)
		{
			return new Vector3d
			{
				x = left.x - right.x,
				y = left.y - right.y,
				z = left.z - right.z
			};
		}

		public static double OrientedAngle(Vector3d a, Vector3d b, Vector3d n)
		{
			double num = 6.2831853071795862;
			double num2 = Vector3d.Angle(a, b);
			if (Vector3d.Triple(n, a, b) < 0.0)
			{
				num2 = num - num2;
			}
			if (num2 > num)
			{
				num2 = 0.0;
			}
			return num2;
		}

		public Vector3d ProjectParallelOn(Vector3d a)
		{
			double num = this * a;
			double num2 = a * a;
			if (Math.Abs(num2) < 4.94065645841247E-324)
			{
				throw new ArithmeticException("Can not project onto a zero length vector");
			}
			double scalar = num / num2;
			return scalar * a;
		}

		public Vector3d ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			if (viewDirection.IsOrthogonalTo(plane.NormalVector))
			{
				throw new ArgumentException("Projection error: view direction is parallel to projection plane!");
			}
			Point left = this.ToPoint().ProjectParallelOn(plane, viewDirection);
			Point right = new Point(0.0, 0.0, 0.0).ProjectParallelOn(plane, viewDirection);
			return new Vector3d(left - right);
		}

		public Vector3d RandomOrthonormal()
		{
			Vector3d b = Vector3d.RandomVector();
			return Vector3d.Cross(this, b).Normalize();
		}

		public static Vector3d RandomVector()
		{
			return new Vector3d
			{
				x = RandomGenerator.NextDouble_mr_mr(),
				y = RandomGenerator.NextDouble_mr_mr(),
				z = RandomGenerator.NextDouble_mr_mr()
			}.Normalize();
		}

		public Vector3d Rotate(Matrix3d rotationMatrix)
		{
			return rotationMatrix * this;
		}

		internal static bool smethod_0(Vector3d vector3d_0, Vector3d vector3d_1)
		{
			return Global.AlmostEquals(vector3d_0.y * vector3d_1.z, vector3d_0.z * vector3d_1.y) & Global.AlmostEquals(vector3d_0.z * vector3d_1.x, vector3d_0.x * vector3d_1.z) & Global.AlmostEquals(vector3d_0.x * vector3d_1.y, vector3d_0.y * vector3d_1.x);
		}

		internal static bool smethod_1(Vector3d vector3d_0, Vector3d vector3d_1)
		{
			return Global.AlmostEquals(-vector3d_0.x * vector3d_1.x, vector3d_0.y * vector3d_1.y + vector3d_0.z * vector3d_1.z) | Global.AlmostEquals(-vector3d_0.y * vector3d_1.y, vector3d_0.x * vector3d_1.x + vector3d_0.z * vector3d_1.z) | Global.AlmostEquals(-vector3d_0.z * vector3d_1.z, vector3d_0.y * vector3d_1.y + vector3d_0.x * vector3d_1.x);
		}

		public static Matrix3d TensorProduct(Vector3d a, Vector3d b)
		{
			return new Matrix3d
			{
				a00 = a.x * b.x,
				a01 = a.x * b.y,
				a02 = a.x * b.z,
				a10 = a.y * b.x,
				a11 = a.y * b.y,
				a12 = a.y * b.z,
				a20 = a.z * b.x,
				a21 = a.z * b.y,
				a22 = a.z * b.z
			};
		}

		public double[] ToArray()
		{
			return new double[]
			{
				this.x,
				this.y,
				this.z
			};
		}

		public Point ToPoint()
		{
			return new Point(this.x, this.y, this.z);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"(",
				this.x.ToString(Global.StringNumberFormat),
				", ",
				this.y.ToString(Global.StringNumberFormat),
				", ",
				this.z.ToString(Global.StringNumberFormat),
				")"
			});
		}

		public Vector3d TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
		{
			Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			Matrix3d basisVectorMatrix2 = newCS.BasisVectorMatrix;
			return basisVectorMatrix2.Invert() * (basisVectorMatrix * this);
		}

		public static double Triple(Vector3d a, Vector3d b, Vector3d c)
		{
			return a.x * (b.y * c.z - b.z * c.y) + a.y * (b.z * c.x - b.x * c.z) + a.z * (b.x * c.y - b.y * c.x);
		}

		public double Norm
		{
			get
			{
				return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
			}
			set
			{
				double norm = this.Norm;
				if (norm < 4.94065645841247E-324)
				{
					return;
				}
				double num = value / norm;
				this.x = num * this.x;
				this.y = num * this.y;
				this.z = num * this.z;
			}
		}

		public double X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		public double Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		public double Z
		{
			get
			{
				return this.z;
			}
			set
			{
				this.z = value;
			}
		}

		private double x;

		private double y;

		private double z;
	}
}
