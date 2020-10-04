using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	
	public class BoundingBox
	{
		public BoundingBox()
		{
			
			this.coordinateSystem_0 = new CoordinateSystem();
		}

		public BoundingBox(double length, double width, double height, CoordinateSystem coordinateSystem)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(BoundingBox));
			//base..ctor();
			this.double_0 = length;
			this.double_1 = width;
			this.double_2 = height;
			this.coordinateSystem_0 = coordinateSystem;
			if (!this.coordinateSystem_0.IsOrthonormal)
			{
				throw new ArgumentException("The coordinate system is not orthonormal!");
			}
		}

		public double[] Extents()
		{
			List<double> list = new List<double>();
			list.Add(this.double_0);
			list.Add(this.double_1);
			list.Add(this.double_2);
			list.Sort();
			list.Reverse();
			return list.ToArray();
		}

		public bool FitsInto(BoundingBox boundingBox)
		{
			double[] array = this.Extents();
			double[] array2 = boundingBox.Extents();
			return array[0] <= array2[0] && array[1] <= array2[1] && array[2] <= array2[2];
		}

		public List<Triangle> GetSurface()
		{
			PointSet vertices = this.GetVertices();
			return new List<Triangle>
			{
				new Triangle(vertices[0], vertices[3], vertices[1]),
				new Triangle(vertices[1], vertices[3], vertices[2]),
				new Triangle(vertices[4], vertices[5], vertices[7]),
				new Triangle(vertices[5], vertices[6], vertices[7]),
				new Triangle(vertices[0], vertices[4], vertices[7]),
				new Triangle(vertices[0], vertices[7], vertices[3]),
				new Triangle(vertices[3], vertices[7], vertices[6]),
				new Triangle(vertices[3], vertices[6], vertices[2]),
				new Triangle(vertices[2], vertices[6], vertices[5]),
				new Triangle(vertices[2], vertices[5], vertices[1]),
				new Triangle(vertices[1], vertices[4], vertices[0]),
				new Triangle(vertices[1], vertices[5], vertices[4])
			};
		}

		public PointSet GetVertices()
		{
			PointSet pointSet = new PointSet();
			pointSet.Add(new Point(-0.5 * this.double_0, -0.5 * this.double_1, -0.5 * this.double_2));
			pointSet.Add(new Point(-0.5 * this.double_0, 0.5 * this.double_1, -0.5 * this.double_2));
			pointSet.Add(new Point(-0.5 * this.double_0, 0.5 * this.double_1, 0.5 * this.double_2));
			pointSet.Add(new Point(-0.5 * this.double_0, -0.5 * this.double_1, 0.5 * this.double_2));
			pointSet.Add(new Point(0.5 * this.double_0, -0.5 * this.double_1, -0.5 * this.double_2));
			pointSet.Add(new Point(0.5 * this.double_0, 0.5 * this.double_1, -0.5 * this.double_2));
			pointSet.Add(new Point(0.5 * this.double_0, 0.5 * this.double_1, 0.5 * this.double_2));
			pointSet.Add(new Point(0.5 * this.double_0, -0.5 * this.double_1, 0.5 * this.double_2));
			pointSet.TransformCoordinates(this.coordinateSystem_0, CoordinateSystem.Global());
			return pointSet;
		}

		internal static double[] smethod_0(PointSet pointSet_0)
		{
			double[] array = new double[]
			{
				1.7976931348623157E+308,
				-1.7976931348623157E+308,
				1.7976931348623157E+308,
				-1.7976931348623157E+308,
				1.7976931348623157E+308,
				-1.7976931348623157E+308
			};
			for (int i = 0; i < pointSet_0.Count; i++)
			{
				if (pointSet_0[i].X < array[0])
				{
					array[0] = pointSet_0[i].X;
				}
				if (pointSet_0[i].X > array[1])
				{
					array[1] = pointSet_0[i].X;
				}
				if (pointSet_0[i].Y < array[2])
				{
					array[2] = pointSet_0[i].Y;
				}
				if (pointSet_0[i].Y > array[3])
				{
					array[3] = pointSet_0[i].Y;
				}
				if (pointSet_0[i].Z < array[4])
				{
					array[4] = pointSet_0[i].Z;
				}
				if (pointSet_0[i].Z > array[5])
				{
					array[5] = pointSet_0[i].Z;
				}
			}
			return array;
		}

		public double Volume()
		{
			return this.double_2 * this.double_0 * this.double_1;
		}

		public CoordinateSystem CoordinateSystem
		{
			get
			{
				return this.coordinateSystem_0;
			}
			set
			{
				this.coordinateSystem_0 = value;
				if (!this.coordinateSystem_0.IsOrthonormal)
				{
					throw new ArgumentException("The coordinate system is not orthonormal!");
				}
			}
		}

		public double Height
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
				if (this.double_2 < 0.0)
				{
					throw new ArgumentException("The height of the bounding box must not be negative", "Height");
				}
			}
		}

		public double Length
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				if (this.double_0 < 0.0)
				{
					throw new ArgumentException("The length of the bounding box must not be negative", "Length");
				}
			}
		}

		public double Width
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
				if (this.double_1 < 0.0)
				{
					throw new ArgumentException("The width of the bounding box must not be negative", "Width");
				}
			}
		}

		private CoordinateSystem coordinateSystem_0;

		private double double_0;

		private double double_1;

		private double double_2;
	}
}
