using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class PointSet2 : CollectionBase
	{
		public PointSet2()
		{           
		}		

		public int Add(Point point)
		{
			return base.List.Add(point);
		}

		public void Add(PointSet2 pointSet)
		{
			for (int i = 0; i < pointSet.Count; i++)
			{
				this.Add(pointSet[i]);
			}
		}

		public bool Contains(Point point)
		{
			return base.List.Contains(point);
		}

		public PointSet2 DeepCopy()
		{
			PointSet2 pointSet = new PointSet2();
			for (int i = 0; i < base.Count; i++)
			{
				pointSet.Add(new Point(this[i].X, this[i].Y, this[i].Z));
			}
			return pointSet;
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		public double[] ExtentsXY()
		{
			double num = 1.7976931348623157E+308;
			double num2 = -1.7976931348623157E+308;
			double num3 = 1.7976931348623157E+308;
			double num4 = -1.7976931348623157E+308;
			for (int i = 0; i < base.Count; i++)
			{
				if (num > this[i].X)
				{
					num = this[i].X;
				}
				if (num2 < this[i].X)
				{
					num2 = this[i].X;
				}
				if (num3 > this[i].Y)
				{
					num3 = this[i].Y;
				}
				if (num4 < this[i].Y)
				{
					num4 = this[i].Y;
				}
			}
			return new double[]
			{
				num,
				num2,
				num3,
				num4
			};
		}

		~PointSet2()
		{
			this.method_0(false);
		}

		public PointSet2 GetRange(int index, int count)
		{
			PointSet2 pointSet = new PointSet2();
			pointSet.InnerList.AddRange(base.InnerList.GetRange(index, count));
			return pointSet;
		}

		public int IndexOf(Point point)
		{
			return base.List.IndexOf(point);
		}

		public void Insert(int index, Point point)
		{
			base.List.Insert(index, point);
		}

		private void method_0(bool bool_1)
		{
			if (this.bool_0)
			{
				return;
			}
			if (bool_1)
			{
				base.Clear();
			}
			this.bool_0 = true;
		}

		public void Move(Vector3d displacementVector)
		{
			for (int i = 0; i < base.Count; i++)
			{
				Point point = this[i];
				point.X += displacementVector.X;
				point.Y += displacementVector.Y;
				point.Z += displacementVector.Z;
			}
		}

		public void RandomPermute()
		{
			Random random = new Random();
			int num = base.Count - 1;
			for (int i = num; i >= 0; i--)
			{
				int index = Convert.ToInt32(random.NextDouble() * (double)num);
				Point value = this[i];
				this[i] = this[index];
				this[index] = value;
			}
		}
		public void RemoveMultiplePoints3d()
		{
			if (base.Count < 2)
			{
				return;
			}
			base.InnerList.Sort(new PointComparer1());
			PointSet2 pointSet = new PointSet2();
			pointSet.Add(this[base.Count - 1]);
			for (int i = base.Count - 2; i >= 0; i--)
			{
				if (!(this[i] == this[i + 1]))
				{
					pointSet.Add(this[i]);
				}
			}
			base.Clear();
			for (int j = 0; j < pointSet.Count; j++)
			{
				this.Add(pointSet[j]);
			}
			pointSet.Dispose();
		}

		public void Reverse()
		{
			base.InnerList.Reverse();
		}
        		
		
		private static bool smethod_0(object object_0)
		{
			double num;
			return double.TryParse(Convert.ToString(object_0), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out num);
		}

		public void Sort()
		{
			base.InnerList.Sort(new PointComparer1());
		}

		public void Sort(PointSet2.SortOrder sortOrder)
		{
			switch (sortOrder)
			{
			case PointSet2.SortOrder.XYZ:
				base.InnerList.Sort(new PointComparer1());
				return;
			case PointSet2.SortOrder.XZY:
				base.InnerList.Sort(new Class6());
				return;
			case PointSet2.SortOrder.YXZ:
				base.InnerList.Sort(new Class7());
				return;
			case PointSet2.SortOrder.YZX:
				base.InnerList.Sort(new Class8());
				return;
			case PointSet2.SortOrder.ZXY:
				base.InnerList.Sort(new Class9());
				return;
			case PointSet2.SortOrder.ZYX:
				base.InnerList.Sort(new Class10());
				return;
			default:
				return;
			}
		}		

		public List<Point> ToList()
		{
			Point[] collection = (Point[])base.InnerList.ToArray(typeof(Point));
			return new List<Point>(collection);
		}

		public static PointSet2 ToPointSet(List<Point> points)
		{
			PointSet2 pointSet = new PointSet2();
			for (int i = 0; i < points.Count; i++)
			{
				pointSet.Add(points[i]);
			}
			return pointSet;
		}

		public void TransformCoordinates(CoordinateSystem actualCS, CoordinateSystem newCS)
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
			for (int i = 0; i < base.Count; i++)
			{
				Point point = this[i];
				double x = point.X;
				double y = point.Y;
				double z = point.Z;
				point.X = matrix3d2.a00 * x + matrix3d2.a01 * y + matrix3d2.a02 * z + num4;
				point.Y = matrix3d2.a10 * x + matrix3d2.a11 * y + matrix3d2.a12 * z + num5;
				point.Z = matrix3d2.a20 * x + matrix3d2.a21 * y + matrix3d2.a22 * z + num6;
			}
		}
		
		public Point Center
		{
			get
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				for (int i = 0; i < base.Count; i++)
				{
					num += this[i].X;
					num2 += this[i].Y;
					num3 += this[i].Z;
				}
				return new Point
				{
					X = num / (double)base.Count,
					Y = num2 / (double)base.Count,
					Z = num3 / (double)base.Count
				};
			}
		}
		
		public Point this[int index]
		{
			get
			{
				return (Point)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}      	
		
		
		private bool bool_0;
		
		public enum SortOrder
		{
			XYZ,
			XZY,
			YXZ,
			YZX,
			ZXY,
			ZYX
		}
	}
}
