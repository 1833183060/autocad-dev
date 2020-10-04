using System;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class Matrix3d : IDisposable
	{
		public Matrix3d()
		{
            
		}

		public Matrix3d(double value)
		{
           
			this.double_0 = value;
			this.double_1 = 0.0;
			this.double_2 = 0.0;
			this.double_3 = 0.0;
			this.double_4 = value;
			this.double_5 = 0.0;
			this.double_6 = 0.0;
			this.double_7 = 0.0;
			this.double_8 = value;
		}

		public Matrix3d(Vector3d column1, Vector3d column2, Vector3d column3)
		{
            
			this.double_0 = column1.X;
			this.double_1 = column2.X;
			this.double_2 = column3.X;
			this.double_3 = column1.Y;
			this.double_4 = column2.Y;
			this.double_5 = column3.Y;
			this.double_6 = column1.Z;
			this.double_7 = column2.Z;
			this.double_8 = column3.Z;
		}

		public Matrix3d(double a00, double a01, double a02, double a10, double a11, double a12, double a20, double a21, double a22)
		{
            
			this.double_0 = a00;
			this.double_1 = a01;
			this.double_2 = a02;
			this.double_3 = a10;
			this.double_4 = a11;
			this.double_5 = a12;
			this.double_6 = a20;
			this.double_7 = a21;
			this.double_8 = a22;
		}

		public static Matrix3d CrossProductMatrix3d(Vector3d a)
		{
			return new Matrix3d
			{
				double_0 = 0.0,
				double_1 = -a.Z,
				double_2 = a.Y,
				double_3 = a.Z,
				double_4 = 0.0,
				double_5 = -a.X,
				double_6 = -a.Y,
				double_7 = a.X,
				double_8 = 0.0
			};
		}

		public Matrix3d DeepCopy()
		{
			return new Matrix3d
			{
				double_0 = this.double_0,
				double_1 = this.double_1,
				double_2 = this.double_2,
				double_3 = this.double_3,
				double_4 = this.double_4,
				double_5 = this.double_5,
				double_6 = this.double_6,
				double_7 = this.double_7,
				double_8 = this.double_8
			};
		}

		public static Matrix3d DiagonalMatrix3d(Vector3d diagonal)
		{
			return new Matrix3d
			{
				double_0 = diagonal.X,
				double_1 = 0.0,
				double_2 = 0.0,
				double_3 = 0.0,
				double_4 = diagonal.Y,
				double_5 = 0.0,
				double_6 = 0.0,
				double_7 = 0.0,
				double_8 = diagonal.Z
			};
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		public override bool Equals(object obj)
		{
			return this == (Matrix3d)obj;
		}

		~Matrix3d()
		{
			this.method_0(false);
		}

		public Vector3d GetColumn(int column)
		{
			if (column == 0)
			{
				return new Vector3d(this.double_0, this.double_3, this.double_6);
			}
			if (column == 1)
			{
				return new Vector3d(this.double_1, this.double_4, this.double_7);
			}
			if (column == 2)
			{
				return new Vector3d(this.double_2, this.double_5, this.double_8);
			}
			throw new IndexOutOfRangeException("Column index out of range.");
		}

		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		public Vector3d GetRow(int row)
		{
			if (row == 0)
			{
				return new Vector3d(this.double_0, this.double_1, this.double_2);
			}
			if (row == 1)
			{
				return new Vector3d(this.double_3, this.double_4, this.double_5);
			}
			if (row == 2)
			{
				return new Vector3d(this.double_6, this.double_7, this.double_8);
			}
			throw new IndexOutOfRangeException("Row index out of range.");
		}

		public static Matrix3d IdentityMatrix3d()
		{
			return new Matrix3d(1.0);
		}

		public Matrix3d Invert()
		{
			Matrix3d matrix3d = new Matrix3d();
			matrix3d.double_0 = this.double_4 * this.double_8 - this.double_5 * this.double_7;
			matrix3d.double_3 = this.double_5 * this.double_6 - this.double_3 * this.double_8;
			matrix3d.double_6 = this.double_3 * this.double_7 - this.double_4 * this.double_6;
			double num = this.double_0 * matrix3d.double_0 + this.double_1 * matrix3d.double_3 + this.double_2 * matrix3d.double_6;
			if (Math.Abs(num) < 4.94065645841247E-324)
			{
				throw new ArithmeticException("Matrix is not invertible!");
			}
			double num2 = 1.0 / num;
			matrix3d.double_0 = num2 * matrix3d.double_0;
			matrix3d.double_3 = num2 * matrix3d.double_3;
			matrix3d.double_6 = num2 * matrix3d.double_6;
			matrix3d.double_1 = num2 * (this.double_2 * this.double_7 - this.double_1 * this.double_8);
			matrix3d.double_2 = num2 * (this.double_1 * this.double_5 - this.double_2 * this.double_4);
			matrix3d.double_4 = num2 * (this.double_0 * this.double_8 - this.double_2 * this.double_6);
			matrix3d.double_5 = num2 * (this.double_2 * this.double_3 - this.double_0 * this.double_5);
			matrix3d.double_7 = num2 * (this.double_1 * this.double_6 - this.double_0 * this.double_7);
			matrix3d.double_8 = num2 * (this.double_0 * this.double_4 - this.double_1 * this.double_3);
			return matrix3d;
		}

		private void method_0(bool bool_1)
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
		}

		private double method_1()
		{
			double num = Math.Abs(this.double_0);
			if (Math.Abs(this.double_1) > num)
			{
				num = Math.Abs(this.double_1);
			}
			if (Math.Abs(this.double_2) > num)
			{
				num = Math.Abs(this.double_2);
			}
			if (Math.Abs(this.double_3) > num)
			{
				num = Math.Abs(this.double_3);
			}
			if (Math.Abs(this.double_4) > num)
			{
				num = Math.Abs(this.double_4);
			}
			if (Math.Abs(this.double_5) > num)
			{
				num = Math.Abs(this.double_5);
			}
			if (Math.Abs(this.double_6) > num)
			{
				num = Math.Abs(this.double_6);
			}
			if (Math.Abs(this.double_7) > num)
			{
				num = Math.Abs(this.double_7);
			}
			if (Math.Abs(this.double_8) > num)
			{
				num = Math.Abs(this.double_8);
			}
			return num;
		}

		public Matrix3d Normalize()
		{
			Matrix3d matrix3d = new Matrix3d();
			Vector3d column = this.GetColumn(0);
			Vector3d column2 = this.GetColumn(1);
			Vector3d column3 = this.GetColumn(2);
			double norm = column.Norm;
			double norm2 = column2.Norm;
			double norm3 = column3.Norm;
			if (norm < 4.94065645841247E-324 | norm2 < 4.94065645841247E-324 | norm3 < 4.94065645841247E-324)
			{
				throw new ArithmeticException("Matrix is not normalizable!");
			}
			matrix3d.SetColumn(0, 1.0 / norm * column);
			matrix3d.SetColumn(1, 1.0 / norm2 * column2);
			matrix3d.SetColumn(2, 1.0 / norm3 * column3);
			return matrix3d;
		}

		public static Matrix3d operator +(Matrix3d A, Matrix3d B)
		{
			return Matrix3d.smethod_0(A, B);
		}

		public static bool operator ==(Matrix3d left, Matrix3d right)
		{
            return (object)left == (object)right || ((object)left != null && (object)right != null && Global.AlmostEquals(left.double_0, right.double_0) && Global.AlmostEquals(left.double_1, right.double_1) && Global.AlmostEquals(left.double_2, right.double_2) && Global.AlmostEquals(left.double_3, right.double_3) && Global.AlmostEquals(left.double_4, right.double_4) && Global.AlmostEquals(left.double_5, right.double_5) && Global.AlmostEquals(left.double_6, right.double_6) && Global.AlmostEquals(left.double_7, right.double_7) && Global.AlmostEquals(left.double_8, right.double_8));
		}

		public static bool operator !=(Matrix3d left, Matrix3d right)
		{
			return !(left == right);
		}

		public static Matrix3d operator *(Matrix3d A, double factor)
		{
			return Matrix3d.smethod_2(A, factor);
		}

		public static Matrix3d operator *(double factor, Matrix3d A)
		{
			return Matrix3d.smethod_2(A, factor);
		}

		public static Matrix3d operator *(Matrix3d A, Matrix3d B)
		{
			return Matrix3d.smethod_3(A, B);
		}

		public static Vector3d operator *(Matrix3d A, Vector3d b)
		{
			double x = A.double_0 * b.X + A.double_1 * b.Y + A.double_2 * b.Z;
			double y = A.double_3 * b.X + A.double_4 * b.Y + A.double_5 * b.Z;
			double z = A.double_6 * b.X + A.double_7 * b.Y + A.double_8 * b.Z;
			return new Vector3d(x, y, z);
		}

		public static Point operator *(Matrix3d A, Point b)
		{
			double x = A.double_0 * b.X + A.double_1 * b.Y + A.double_2 * b.Z;
			double y = A.double_3 * b.X + A.double_4 * b.Y + A.double_5 * b.Z;
			double z = A.double_6 * b.X + A.double_7 * b.Y + A.double_8 * b.Z;
			return new Point(x, y, z);
		}

		public static Matrix3d operator -(Matrix3d A, Matrix3d B)
		{
			return Matrix3d.smethod_1(A, B);
		}

		public static Matrix3d operator -(Matrix3d A)
		{
			return Matrix3d.smethod_2(A, -1.0);
		}

		public Matrix3d Orthonormalize()
		{
			Vector3d column = this.GetColumn(0);
			Vector3d vector3d = this.GetColumn(1) - Vector3d.Dot(this.GetColumn(1), column) / (column * column) * column;
			Vector3d vector3d2 = this.GetColumn(2) - Vector3d.Dot(this.GetColumn(2), column) / (column * column) * column - Vector3d.Dot(this.GetColumn(2), vector3d) / (vector3d * vector3d) * vector3d;
			Matrix3d matrix3d = new Matrix3d();
			matrix3d.SetColumn(0, 1.0 / column.Norm * column);
			matrix3d.SetColumn(1, 1.0 / vector3d.Norm * vector3d);
			matrix3d.SetColumn(2, 1.0 / vector3d2.Norm * vector3d2);
			return matrix3d;
		}

		public static Matrix3d RandomMatrix3d()
		{
			return new Matrix3d
			{
				double_0 = RandomGenerator.NextDouble_mr_mr(),
				double_1 = RandomGenerator.NextDouble_mr_mr(),
				double_2 = RandomGenerator.NextDouble_mr_mr(),
				double_3 = RandomGenerator.NextDouble_mr_mr(),
				double_4 = RandomGenerator.NextDouble_mr_mr(),
				double_5 = RandomGenerator.NextDouble_mr_mr(),
				double_6 = RandomGenerator.NextDouble_mr_mr(),
				double_7 = RandomGenerator.NextDouble_mr_mr(),
				double_8 = RandomGenerator.NextDouble_mr_mr()
			};
		}

		public static Matrix3d RotationArbitraryAxis(Vector3d axis, double radian)
		{
			Vector3d vector3d = axis.Normalize();
			double num = Math.Cos(radian);
			double double_ = Math.Sin(radian);
			Matrix3d matrix3d_ = new Matrix3d(num);
			Matrix3d matrix3d_2 = Matrix3d.smethod_2(Vector3d.TensorProduct(vector3d, vector3d), 1.0 - num);
			Matrix3d matrix3d_3 = Matrix3d.smethod_2(Matrix3d.CrossProductMatrix3d(vector3d), double_);
			return Matrix3d.smethod_0(Matrix3d.smethod_0(matrix3d_, matrix3d_2), matrix3d_3);
		}

		public static Matrix3d RotationEuler(double phi, double theta, double psi)
		{
			return Matrix3d.smethod_3(Matrix3d.smethod_3(Matrix3d.RotationZAxis(psi), Matrix3d.RotationXAxis(theta)), Matrix3d.RotationZAxis(phi));
		}

		public static Matrix3d RotationTaitBryan(double roll, double pitch, double yaw)
		{
			return Matrix3d.smethod_3(Matrix3d.smethod_3(Matrix3d.RotationXAxis(roll), Matrix3d.RotationYAxis(pitch)), Matrix3d.RotationZAxis(yaw));
		}

		public static Matrix3d RotationXAxis(double radian)
		{
			Matrix3d matrix3d = new Matrix3d();
			double num = Math.Sin(radian);
			double num2 = Math.Cos(radian);
			matrix3d.double_0 = 1.0;
			matrix3d.double_1 = 0.0;
			matrix3d.double_2 = 0.0;
			matrix3d.double_3 = 0.0;
			matrix3d.double_4 = num2;
			matrix3d.double_5 = -num;
			matrix3d.double_6 = 0.0;
			matrix3d.double_7 = num;
			matrix3d.double_8 = num2;
			return matrix3d;
		}

		public static Matrix3d RotationYAxis(double radian)
		{
			Matrix3d matrix3d = new Matrix3d();
			double num = Math.Sin(radian);
			double num2 = Math.Cos(radian);
			matrix3d.double_0 = num2;
			matrix3d.double_1 = 0.0;
			matrix3d.double_2 = num;
			matrix3d.double_3 = 0.0;
			matrix3d.double_4 = 1.0;
			matrix3d.double_5 = 0.0;
			matrix3d.double_6 = -num;
			matrix3d.double_7 = 0.0;
			matrix3d.double_8 = num2;
			return matrix3d;
		}

		public static Matrix3d RotationZAxis(double radian)
		{
			Matrix3d matrix3d = new Matrix3d();
			double num = Math.Sin(radian);
			double num2 = Math.Cos(radian);
			matrix3d.double_0 = num2;
			matrix3d.double_1 = -num;
			matrix3d.double_2 = 0.0;
			matrix3d.double_3 = num;
			matrix3d.double_4 = num2;
			matrix3d.double_5 = 0.0;
			matrix3d.double_6 = 0.0;
			matrix3d.double_7 = 0.0;
			matrix3d.double_8 = 1.0;
			return matrix3d;
		}

		public void SetColumn(int column, Vector3d columnVector)
		{
			if (column == 0)
			{
				this.double_0 = columnVector.X;
				this.double_3 = columnVector.Y;
				this.double_6 = columnVector.Z;
				return;
			}
			if (column == 1)
			{
				this.double_1 = columnVector.X;
				this.double_4 = columnVector.Y;
				this.double_7 = columnVector.Z;
				return;
			}
			if (column == 2)
			{
				this.double_2 = columnVector.X;
				this.double_5 = columnVector.Y;
				this.double_8 = columnVector.Z;
				return;
			}
			throw new IndexOutOfRangeException("Column index out of range.");
		}

		public void SetRow(int row, Vector3d rowVector)
		{
			if (row == 0)
			{
				this.double_0 = rowVector.X;
				this.double_1 = rowVector.Y;
				this.double_2 = rowVector.Z;
				return;
			}
			if (row == 1)
			{
				this.double_3 = rowVector.X;
				this.double_4 = rowVector.Y;
				this.double_5 = rowVector.Z;
				return;
			}
			if (row == 2)
			{
				this.double_6 = rowVector.X;
				this.double_7 = rowVector.Y;
				this.double_8 = rowVector.Z;
				return;
			}
			throw new IndexOutOfRangeException("Row index out of range.");
		}

		private static Matrix3d smethod_0(Matrix3d matrix3d_0, Matrix3d matrix3d_1)
		{
			return new Matrix3d
			{
				double_0 = matrix3d_0.double_0 + matrix3d_1.double_0,
				double_1 = matrix3d_0.double_1 + matrix3d_1.double_1,
				double_2 = matrix3d_0.double_2 + matrix3d_1.double_2,
				double_3 = matrix3d_0.double_3 + matrix3d_1.double_3,
				double_4 = matrix3d_0.double_4 + matrix3d_1.double_4,
				double_5 = matrix3d_0.double_5 + matrix3d_1.double_5,
				double_6 = matrix3d_0.double_6 + matrix3d_1.double_6,
				double_7 = matrix3d_0.double_7 + matrix3d_1.double_7,
				double_8 = matrix3d_0.double_8 + matrix3d_1.double_8
			};
		}

		private static Matrix3d smethod_1(Matrix3d matrix3d_0, Matrix3d matrix3d_1)
		{
			return new Matrix3d
			{
				double_0 = matrix3d_0.double_0 - matrix3d_1.double_0,
				double_1 = matrix3d_0.double_1 - matrix3d_1.double_1,
				double_2 = matrix3d_0.double_2 - matrix3d_1.double_2,
				double_3 = matrix3d_0.double_3 - matrix3d_1.double_3,
				double_4 = matrix3d_0.double_4 - matrix3d_1.double_4,
				double_5 = matrix3d_0.double_5 - matrix3d_1.double_5,
				double_6 = matrix3d_0.double_6 - matrix3d_1.double_6,
				double_7 = matrix3d_0.double_7 - matrix3d_1.double_7,
				double_8 = matrix3d_0.double_8 - matrix3d_1.double_8
			};
		}

		private static Matrix3d smethod_2(Matrix3d matrix3d_0, double double_9)
		{
			return new Matrix3d
			{
				double_0 = matrix3d_0.double_0 * double_9,
				double_1 = matrix3d_0.double_1 * double_9,
				double_2 = matrix3d_0.double_2 * double_9,
				double_3 = matrix3d_0.double_3 * double_9,
				double_4 = matrix3d_0.double_4 * double_9,
				double_5 = matrix3d_0.double_5 * double_9,
				double_6 = matrix3d_0.double_6 * double_9,
				double_7 = matrix3d_0.double_7 * double_9,
				double_8 = matrix3d_0.double_8 * double_9
			};
		}

		private static Matrix3d smethod_3(Matrix3d matrix3d_0, Matrix3d matrix3d_1)
		{
			return new Matrix3d
			{
				double_0 = matrix3d_0.double_0 * matrix3d_1.double_0 + matrix3d_0.double_1 * matrix3d_1.double_3 + matrix3d_0.double_2 * matrix3d_1.double_6,
				double_1 = matrix3d_0.double_0 * matrix3d_1.double_1 + matrix3d_0.double_1 * matrix3d_1.double_4 + matrix3d_0.double_2 * matrix3d_1.double_7,
				double_2 = matrix3d_0.double_0 * matrix3d_1.double_2 + matrix3d_0.double_1 * matrix3d_1.double_5 + matrix3d_0.double_2 * matrix3d_1.double_8,
				double_3 = matrix3d_0.double_3 * matrix3d_1.double_0 + matrix3d_0.double_4 * matrix3d_1.double_3 + matrix3d_0.double_5 * matrix3d_1.double_6,
				double_4 = matrix3d_0.double_3 * matrix3d_1.double_1 + matrix3d_0.double_4 * matrix3d_1.double_4 + matrix3d_0.double_5 * matrix3d_1.double_7,
				double_5 = matrix3d_0.double_3 * matrix3d_1.double_2 + matrix3d_0.double_4 * matrix3d_1.double_5 + matrix3d_0.double_5 * matrix3d_1.double_8,
				double_6 = matrix3d_0.double_6 * matrix3d_1.double_0 + matrix3d_0.double_7 * matrix3d_1.double_3 + matrix3d_0.double_8 * matrix3d_1.double_6,
				double_7 = matrix3d_0.double_6 * matrix3d_1.double_1 + matrix3d_0.double_7 * matrix3d_1.double_4 + matrix3d_0.double_8 * matrix3d_1.double_7,
				double_8 = matrix3d_0.double_6 * matrix3d_1.double_2 + matrix3d_0.double_7 * matrix3d_1.double_5 + matrix3d_0.double_8 * matrix3d_1.double_8
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
				")",
				Environment.NewLine,
				"(",
				this.double_3.ToString(Global.StringNumberFormat),
				", ",
				this.double_4.ToString(Global.StringNumberFormat),
				", ",
				this.double_5.ToString(Global.StringNumberFormat),
				")",
				Environment.NewLine,
				"(",
				this.double_6.ToString(Global.StringNumberFormat),
				", ",
				this.double_7.ToString(Global.StringNumberFormat),
				", ",
				this.double_8.ToString(Global.StringNumberFormat),
				")"
			});
		}

		public Matrix3d Transpose()
		{
			return new Matrix3d
			{
				double_0 = this.double_0,
				double_3 = this.double_1,
				double_6 = this.double_2,
				double_1 = this.double_3,
				double_4 = this.double_4,
				double_7 = this.double_5,
				double_2 = this.double_6,
				double_5 = this.double_7,
				double_8 = this.double_8
			};
		}

		public double a00
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

		public double a01
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

		public double a02
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

		public double a10
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
			}
		}

		public double a11
		{
			get
			{
				return this.double_4;
			}
			set
			{
				this.double_4 = value;
			}
		}

		public double a12
		{
			get
			{
				return this.double_5;
			}
			set
			{
				this.double_5 = value;
			}
		}

		public double a20
		{
			get
			{
				return this.double_6;
			}
			set
			{
				this.double_6 = value;
			}
		}

		public double a21
		{
			get
			{
				return this.double_7;
			}
			set
			{
				this.double_7 = value;
			}
		}

		public double a22
		{
			get
			{
				return this.double_8;
			}
			set
			{
				this.double_8 = value;
			}
		}

		public double Determinant
		{
			get
			{
				double num = this.double_4 * this.double_8 - this.double_5 * this.double_7;
				double num2 = this.double_5 * this.double_6 - this.double_3 * this.double_8;
				double num3 = this.double_3 * this.double_7 - this.double_4 * this.double_6;
				return this.double_0 * num + this.double_1 * num2 + this.double_2 * num3;
			}
		}

		public double FrobeniusNorm
		{
			get
			{
				double num = 0.0;
				num += this.double_0 * this.double_0;
				num += this.double_1 * this.double_1;
				num += this.double_2 * this.double_2;
				num += this.double_3 * this.double_3;
				num += this.double_4 * this.double_4;
				num += this.double_5 * this.double_5;
				num += this.double_6 * this.double_6;
				num += this.double_7 * this.double_7;
				num += this.double_8 * this.double_8;
				return Math.Sqrt(num);
			}
		}

		public double InfinityNorm
		{
			get
			{
				double val = Math.Abs(this.double_0) + Math.Abs(this.double_1) + Math.Abs(this.double_2);
				double val2 = Math.Abs(this.double_3) + Math.Abs(this.double_4) + Math.Abs(this.double_5);
				double val3 = Math.Abs(this.double_6) + Math.Abs(this.double_7) + Math.Abs(this.double_8);
				return Math.Max(val, Math.Max(val2, val3));
			}
		}

		public bool IsOrthogonal
		{
			get
			{
				Vector3d column = this.GetColumn(0);
				Vector3d column2 = this.GetColumn(1);
				Vector3d column3 = this.GetColumn(2);
				return Math.Abs(Vector3d.Dot(column, column2)) <= Global.AbsoluteEpsilon && Math.Abs(Vector3d.Dot(column, column3)) <= Global.AbsoluteEpsilon && Math.Abs(Vector3d.Dot(column2, column3)) <= Global.AbsoluteEpsilon;
			}
		}

		public bool IsOrthonormal
		{
			get
			{
				Vector3d column = this.GetColumn(0);
				Vector3d column2 = this.GetColumn(1);
				Vector3d column3 = this.GetColumn(2);
				return Math.Abs(Vector3d.Dot(column, column2)) <= Global.AbsoluteEpsilon && Math.Abs(Vector3d.Dot(column, column3)) <= Global.AbsoluteEpsilon && Math.Abs(Vector3d.Dot(column2, column3)) <= Global.AbsoluteEpsilon && Global.AlmostEquals(column.Norm, 1.0) && Global.AlmostEquals(column2.Norm, 1.0) && Global.AlmostEquals(column3.Norm, 1.0);
			}
		}

		public bool IsRotationMatrix
		{
			get
			{
				return Global.AlmostEquals(this.Determinant, 1.0);
			}
		}

		public bool IsSymmetric
		{
			get
			{
				return Global.AlmostEquals(this.double_3, this.double_1) && Global.AlmostEquals(this.double_6, this.double_2) && Global.AlmostEquals(this.double_5, this.double_7);
			}
		}

		public bool IsSymmetricPositiveDefinite
		{
			get
			{
				return this.IsSymmetric && this.double_0 > 0.0 && this.double_0 * this.a11 - this.a10 * this.a01 > 0.0 && this.Determinant > 0.0;
			}
		}

		public double Norm1
		{
			get
			{
				double val = Math.Abs(this.double_0) + Math.Abs(this.double_3) + Math.Abs(this.double_6);
				double val2 = Math.Abs(this.double_1) + Math.Abs(this.double_4) + Math.Abs(this.double_7);
				double val3 = Math.Abs(this.double_2) + Math.Abs(this.double_5) + Math.Abs(this.double_8);
				return Math.Max(val, Math.Max(val2, val3));
			}
		}

		public double[] SymmetricEigenvalues
		{
			get
			{
				if (!this.IsSymmetric)
				{
					throw new InvalidOperationException("Can not compute eigenvalues: matrix is not symmetric.");
				}
				double num = 1E-12;
				double num2 = 1.0;
				double num3 = (double)1f;
				double num4 = num3 * this.a00;
				double num5 = num3 * this.a01;
				double num6 = num3 * this.a02;
				double num7 = num3 * this.a11;
				double num8 = num3 * this.a12;
				double num9 = num3 * this.a22;
				int num10 = 0;
				while (num10 < 32 && (Math.Abs(num5) >= num || Math.Abs(num6) >= num || Math.Abs(num8) >= num))
				{
					if (num5 != 0.0)
					{
						double num11 = (num7 - num4) * 0.5 / num5;
						double num12 = num11 * num11;
						int num13 = (num11 < 0.0) ? -1 : 1;
						double num14 = (double)num13 * (Math.Sqrt(num12 + 1.0) - Math.Abs(num11));
						double num15 = 1.0 / Math.Sqrt(num14 * num14 + 1.0);
						double num16 = num15 * num14;
						num4 -= num14 * num5;
						num7 += num14 * num5;
						num5 = 0.0;
						double num17 = num15 * num6 - num16 * num8;
						num8 = num16 * num6 + num15 * num8;
						num6 = num17;
					}
					if (num6 != 0.0)
					{
						double num18 = (num9 - num4) * 0.5 / num6;
						double num19 = num18 * num18;
						int num20 = (num18 < 0.0) ? -1 : 1;
						double num21 = (double)num20 * (Math.Sqrt(num19 + 1.0) - Math.Abs(num18));
						double num22 = 1.0 / Math.Sqrt(num21 * num21 + 1.0);
						double num23 = num22 * num21;
						num4 -= num21 * num6;
						num9 += num21 * num6;
						num6 = 0.0;
						double num24 = num22 * num5 - num23 * num8;
						num8 = num23 * num5 + num22 * num8;
						num5 = num24;
					}
					if (num8 != 0.0)
					{
						double num25 = (num9 - num7) * 0.5 / num8;
						double num26 = num25 * num25;
						int num27 = (num25 < 0.0) ? -1 : 1;
						double num28 = (double)num27 * (Math.Sqrt(num26 + 1.0) - Math.Abs(num25));
						double num29 = 1.0 / Math.Sqrt(num28 * num28 + 1.0);
						double num30 = num29 * num28;
						num7 -= num28 * num8;
						num9 += num28 * num8;
						num8 = 0.0;
						double num31 = num29 * num5 - num30 * num6;
						num6 = num30 * num5 + num29 * num6;
						num5 = num31;
					}
					num10++;
				}
				return new double[]
				{
					num2 * num4,
					num2 * num7,
					num2 * num9
				};
			}
		}

		public Matrix3d SymmetricEigenvectors
		{
			get
			{
				if (!this.IsSymmetric)
				{
					throw new InvalidOperationException("Can not compute eigenvectors: matrix is not symmetric.");
				}
				double num = 1E-12;
				double num2 = (double)1f;
				double num3 = num2 * this.a00;
				double num4 = num2 * this.a01;
				double num5 = num2 * this.a02;
				double num6 = num2 * this.a11;
				double num7 = num2 * this.a12;
				double num8 = num2 * this.a22;
				double num9 = 1.0;
				double num10 = 0.0;
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = 1.0;
				double num14 = 0.0;
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 1.0;
				int num18 = 0;
				while (num18 < 32 && (Math.Abs(num4) >= num || Math.Abs(num5) >= num || Math.Abs(num7) >= num))
				{
					if (num4 != 0.0)
					{
						double num19 = 0.5 * (num6 - num3) / num4;
						double num20 = num19 * num19;
						int num21 = (num19 < 0.0) ? -1 : 1;
						double num22 = (double)num21 * (Math.Sqrt(num20 + 1.0) - Math.Abs(num19));
						double num23 = 1.0 / Math.Sqrt(num22 * num22 + 1.0);
						double num24 = num23 * num22;
						num3 -= num22 * num4;
						num6 += num22 * num4;
						num4 = 0.0;
						double num25 = num23 * num5 - num24 * num7;
						num7 = num24 * num5 + num23 * num7;
						num5 = num25;
						num25 = num23 * num9 - num24 * num10;
						num10 = num24 * num9 + num23 * num10;
						num9 = num25;
						num25 = num23 * num12 - num24 * num13;
						num13 = num24 * num12 + num23 * num13;
						num12 = num25;
						num25 = num23 * num15 - num24 * num16;
						num16 = num24 * num15 + num23 * num16;
						num15 = num25;
					}
					if (num5 != 0.0)
					{
						double num26 = 0.5 * (num8 - num3) / num5;
						double num27 = num26 * num26;
						int num28 = (num26 < 0.0) ? -1 : 1;
						double num29 = (double)num28 * (Math.Sqrt(num27 + 1.0) - Math.Abs(num26));
						double num30 = 1.0 / Math.Sqrt(num29 * num29 + 1.0);
						double num31 = num30 * num29;
						num3 -= num29 * num5;
						num8 += num29 * num5;
						num5 = 0.0;
						double num32 = num30 * num4 - num31 * num7;
						num7 = num31 * num4 + num30 * num7;
						num4 = num32;
						num32 = num30 * num9 - num31 * num11;
						num11 = num31 * num9 + num30 * num11;
						num9 = num32;
						num32 = num30 * num12 - num31 * num14;
						num14 = num31 * num12 + num30 * num14;
						num12 = num32;
						num32 = num30 * num15 - num31 * num17;
						num17 = num31 * num15 + num30 * num17;
						num15 = num32;
					}
					if (num7 != 0.0)
					{
						double num33 = 0.5 * (num8 - num6) / num7;
						double num34 = num33 * num33;
						int num35 = (num33 < 0.0) ? -1 : 1;
						double num36 = (double)num35 * (Math.Sqrt(num34 + 1.0) - Math.Abs(num33));
						double num37 = 1.0 / Math.Sqrt(num36 * num36 + 1.0);
						double num38 = num37 * num36;
						num6 -= num36 * num7;
						num8 += num36 * num7;
						num7 = 0.0;
						double num39 = num37 * num4 - num38 * num5;
						num5 = num38 * num4 + num37 * num5;
						num4 = num39;
						num39 = num37 * num10 - num38 * num11;
						num11 = num38 * num10 + num37 * num11;
						num10 = num39;
						num39 = num37 * num13 - num38 * num14;
						num14 = num38 * num13 + num37 * num14;
						num13 = num39;
						num39 = num37 * num16 - num38 * num17;
						num17 = num38 * num16 + num37 * num17;
						num16 = num39;
					}
					num18++;
				}
				return new Matrix3d(num9, num10, num11, num12, num13, num14, num15, num16, num17);
			}
		}

		public double Trace
		{
			get
			{
				return this.double_0 + this.double_4 + this.double_8;
			}
		}

		private bool bool_0;

		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		private double double_4;

		private double double_5;

		private double double_6;

		private double double_7;

		private double double_8;
	}
}
