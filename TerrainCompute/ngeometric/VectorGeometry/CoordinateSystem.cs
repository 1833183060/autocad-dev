using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	
	[Serializable]
	public class CoordinateSystem
	{
		public CoordinateSystem()
		{
            
			this.point_0 = new Point(0.0, 0.0, 0.0);
			this.list_0 = new List<Vector3d>();
			this.list_0.Add(new Vector3d(1.0, 0.0, 0.0));
			this.list_0.Add(new Vector3d(0.0, 1.0, 0.0));
			this.list_0.Add(new Vector3d(0.0, 0.0, 1.0));
		}

		public CoordinateSystem(Plane plane)
		{
            
			this.point_0 = plane.Point;
			this.list_0 = new List<Vector3d>();
			this.list_0.Add(plane.DirectionVector1);
			this.list_0.Add(plane.DirectionVector2);
			this.list_0.Add(plane.NormalVector);
		}

		public CoordinateSystem(Point originPoint, Vector3d e1, Vector3d e2, Vector3d e3)
		{
            
			this.point_0 = originPoint;
			this.list_0 = new List<Vector3d>();
			this.list_0.Add(e1);
			this.list_0.Add(e2);
			this.list_0.Add(e3);
			if (Math.Abs(Vector3d.Triple(this.list_0[0].Normalize(), this.list_0[1].Normalize(), this.list_0[2].Normalize())) < ngeometry.VectorGeometry.Global.AbsoluteEpsilon)
			{
				throw new ArgumentException("Basis vectors are linearly dependent!");
			}
		}

		public CoordinateSystem(Point u1, Point u2, Point u3, Point u4, Point v1, Point v2, Point v3, Point v4)
		{
            
			try
			{
				CoordinateSystem coordinateSystem = Class11.smethod_1(u1, u2, u3, u4, v1, v2, v3, v4);
				this.list_0 = new List<Vector3d>();
				this.list_0.Add(new Vector3d());
				this.list_0.Add(new Vector3d());
				this.list_0.Add(new Vector3d());
				this.BasisVectorMatrix = coordinateSystem.BasisVectorMatrix;
				this.point_0 = coordinateSystem.Origin;
			}
            catch (System.Exception ex)
			{
				throw ex;
			}
		}

		public CoordinateSystem DeepCopy()
		{
			CoordinateSystem coordinateSystem = new CoordinateSystem();
			coordinateSystem.point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z);
			coordinateSystem.list_0[0] = new Vector3d(this.list_0[0].X, this.list_0[0].Y, this.list_0[0].Z);
			coordinateSystem.list_0[1] = new Vector3d(this.list_0[1].X, this.list_0[1].Y, this.list_0[1].Z);
			coordinateSystem.list_0[2] = new Vector3d(this.list_0[2].X, this.list_0[2].Y, this.list_0[2].Z);
			return coordinateSystem;
		}

		public override bool Equals(object obj)
		{
			return this == (CoordinateSystem)obj;
		}

		public override int GetHashCode()
		{
			int hashCode = this.point_0.ToString().GetHashCode();
			int hashCode2 = this.list_0[0].ToString().GetHashCode();
			int hashCode3 = this.list_0[1].ToString().GetHashCode();
			int hashCode4 = this.list_0[2].ToString().GetHashCode();
			return hashCode ^ hashCode2 ^ hashCode3 ^ hashCode4;
		}

		public Plane GetPlane()
		{
			return new Plane(this.point_0, this.list_0[0], this.list_0[1]);
		}

		public Plane GetPlaneNormalized()
		{
			Plane plane = new Plane(this.point_0, this.list_0[0], this.list_0[1]);
			plane.Normalize();
			return plane;
		}

		public static CoordinateSystem Global()
		{
			Point originPoint = new Point(0.0, 0.0, 0.0);
			Vector3d e = new Vector3d(1.0, 0.0, 0.0);
			Vector3d e2 = new Vector3d(0.0, 1.0, 0.0);
			Vector3d e3 = new Vector3d(0.0, 0.0, 1.0);
			return new CoordinateSystem(originPoint, e, e2, e3);
		}

		public static bool operator ==(CoordinateSystem left, CoordinateSystem right)
		{
            if((object)left == (object)right)return true;
            if ((object)left == null || (object)right == null) return false;
            if (left.point_0 != right.point_0)
            {
                return false;
            }
            if (left.list_0[0] != right.list_0[0])
            {
                return false;
            }
            if (left.list_0[1] != right.list_0[1])
            {
                return false;
            }
            if (left.list_0[2] != right.list_0[2])
            {
                return false;
            }
            return true;
           
		}

		public static bool operator !=(CoordinateSystem left, CoordinateSystem right)
		{
			return !(left == right);
		}

		public void Orthogonalize()
		{
			Vector3d vector3d = this.list_0[0];
			Vector3d vector3d2 = this.list_0[1] - Vector3d.Dot(this.list_0[1], vector3d) / (vector3d * vector3d) * vector3d;
			Vector3d value = this.list_0[2] - Vector3d.Dot(this.list_0[2], vector3d) / (vector3d * vector3d) * vector3d - Vector3d.Dot(this.list_0[2], vector3d2) / (vector3d2 * vector3d2) * vector3d2;
			this.list_0[0] = vector3d;
			this.list_0[1] = vector3d2;
			this.list_0[2] = value;
		}

		public void Orthonormalize()
		{
			this.Orthogonalize();
			this.list_0[0] = 1.0 / this.list_0[0].Norm * this.list_0[0];
			this.list_0[1] = 1.0 / this.list_0[1].Norm * this.list_0[1];
			this.list_0[2] = 1.0 / this.list_0[2].Norm * this.list_0[2];
		}

		public static CoordinateSystem RandomCoordinateSystem()
		{
			Point originPoint = Point.RandomPoint();
			Vector3d vector3d = Vector3d.RandomVector();
			Vector3d vector3d2 = vector3d.RandomOrthonormal();
			Vector3d e = Vector3d.Cross(vector3d, vector3d2).Normalize();
			return new CoordinateSystem(originPoint, vector3d, vector3d2, e);
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"Coordinate system ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  Origin             :",
				this.point_0.ToString(),
				Environment.NewLine,
				"  First basis vector :",
				this.list_0[0].ToString(),
				Environment.NewLine,
				"  Second basis vector:",
				this.list_0[1].ToString(),
				Environment.NewLine,
				"  Third basis vector :",
				this.list_0[2].ToString(),
				Environment.NewLine,
				"  Is orthogonal      : ",
				this.IsOrthogonal,
				Environment.NewLine,
				"  Is orthonormal     : ",
				this.IsOrthonormal
			});
		}

		public List<Vector3d> BasisVector
		{
			get
			{
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
				if (this.list_0.Count != 3)
				{
					throw new ArgumentException("A 3d basis can not have more than 3 basis vectors.");
				}
				if (Math.Abs(Vector3d.Triple(this.list_0[0], this.list_0[1], this.list_0[2])) < ngeometry.VectorGeometry.Global.AbsoluteEpsilon)
				{
					throw new ArgumentException("Basis vectors are linearly dependent!");
				}
			}
		}

		public Matrix3d BasisVectorMatrix
		{
			get
			{
				return new Matrix3d
				{
					a00 = this.list_0[0].X,
					a10 = this.list_0[0].Y,
					a20 = this.list_0[0].Z,
					a01 = this.list_0[1].X,
					a11 = this.list_0[1].Y,
					a21 = this.list_0[1].Z,
					a02 = this.list_0[2].X,
					a12 = this.list_0[2].Y,
					a22 = this.list_0[2].Z
				};
			}
			set
			{
				this.list_0[0] = value.GetColumn(0);
				this.list_0[1] = value.GetColumn(1);
				this.list_0[2] = value.GetColumn(2);
			}
		}

		public bool IsOrthogonal
		{
			get
			{
				return this.list_0[0].IsOrthogonalTo(this.list_0[1]) && this.list_0[0].IsOrthogonalTo(this.list_0[2]) && this.list_0[1].IsOrthogonalTo(this.list_0[2]);
			}
		}

		public bool IsOrthonormal
		{
			get
			{
				return this.IsOrthogonal && (Math.Abs(this.list_0[0].Norm - 1.0) < ngeometry.VectorGeometry.Global.AbsoluteEpsilon && Math.Abs(this.list_0[1].Norm - 1.0) < ngeometry.VectorGeometry.Global.AbsoluteEpsilon) && Math.Abs(this.list_0[2].Norm - 1.0) < ngeometry.VectorGeometry.Global.AbsoluteEpsilon;
			}
		}

		public Point Origin
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
		private List<Vector3d> list_0;
		private Point point_0;
	}
}
