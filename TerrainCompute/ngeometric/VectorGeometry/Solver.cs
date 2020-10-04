using System;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class Solver
	{
		public Solver()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Solver));
			//base..ctor();
		}

		public static Vector3d SolveFull(Matrix3d A, Vector3d b)
		{
			Vector3d a = new Vector3d(A.a00, A.a10, A.a20);
			Vector3d a2 = new Vector3d(A.a01, A.a11, A.a21);
			Vector3d a3 = new Vector3d(A.a02, A.a12, A.a22);
			return Solver.SolveFull(a, a2, a3, b);
		}

		public static Vector3d SolveFull(Vector3d a1, Vector3d a2, Vector3d a3, Vector3d b)
		{
			double num = Vector3d.Triple(a1, a2, a3);
			if (Math.Abs(num) <= 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not solve linear system: zero determinant.");
			}
			double num2 = Vector3d.Triple(b, a2, a3);
			double num3 = Vector3d.Triple(a1, b, a3);
			double num4 = Vector3d.Triple(a1, a2, b);
			double num5 = 1.0 / num;
			return new Vector3d(num5 * num2, num5 * num3, num5 * num4);
		}

		public static double SolveX(Matrix3d A, Vector3d b)
		{
			Vector3d column = A.GetColumn(0);
			Vector3d column2 = A.GetColumn(1);
			Vector3d column3 = A.GetColumn(2);
			return Solver.SolveX(column, column2, column3, b);
		}

		public static double SolveX(Vector3d a1, Vector3d a2, Vector3d a3, Vector3d b)
		{
			double num = Vector3d.Triple(a1, a2, a3);
			double num2 = Vector3d.Triple(b, a2, a3);
			if (Math.Abs(num) <= 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not solve linear system: solver found zero determinant.");
			}
			return num2 / num;
		}

		public static double SolveY(Matrix3d A, Vector3d b)
		{
			Vector3d column = A.GetColumn(0);
			Vector3d column2 = A.GetColumn(1);
			Vector3d column3 = A.GetColumn(2);
			return Solver.SolveY(column, column2, column3, b);
		}

		public static double SolveY(Vector3d a1, Vector3d a2, Vector3d a3, Vector3d b)
		{
			double num = Vector3d.Triple(a1, a2, a3);
			double num2 = Vector3d.Triple(a1, b, a3);
			if (Math.Abs(num) <= 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not solve linear system: solver found zero determinant.");
			}
			return num2 / num;
		}

		public static double SolveZ(Matrix3d A, Vector3d b)
		{
			Vector3d column = A.GetColumn(0);
			Vector3d column2 = A.GetColumn(1);
			Vector3d column3 = A.GetColumn(2);
			return Solver.SolveZ(column, column2, column3, b);
		}

		public static double SolveZ(Vector3d a1, Vector3d a2, Vector3d a3, Vector3d b)
		{
			double num = Vector3d.Triple(a1, a2, a3);
			double num2 = Vector3d.Triple(a1, a2, b);
			if (Math.Abs(num) <= 4.94065645841247E-324)
			{
				throw new ArgumentException("Can not solve linear system: solver found zero determinant.");
			}
			return num2 / num;
		}
	}
}
