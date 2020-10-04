using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	
	public class BoundingRectangle
	{
		public BoundingRectangle()
		{
			
		}

		public BoundingRectangle(double length, double width, Point center, double rotationAngle)
		{
            
			this.double_0 = length;
			this.double_1 = width;
			this.point_0 = center;
			this.double_2 = rotationAngle;
		}

		public double Area()
		{
			return this.double_0 * this.double_1;
		}

		public List<Edge> GetEdges()
		{
			List<Edge> list = new List<Edge>();
			PointSet vertices = this.GetVertices();
			list.Add(new Edge(vertices[0], vertices[1]));
			list.Add(new Edge(vertices[1], vertices[2]));
			list.Add(new Edge(vertices[2], vertices[3]));
			list.Add(new Edge(vertices[3], vertices[0]));
			return list;
		}

		public PointSet GetVertices()
		{
			PointSet pointSet = new PointSet();
			pointSet.Add(new Point(-0.5 * this.double_0, -0.5 * this.double_1, 0.0));
			pointSet.Add(new Point(0.5 * this.double_0, -0.5 * this.double_1, 0.0));
			pointSet.Add(new Point(0.5 * this.double_0, 0.5 * this.double_1, 0.0));
			pointSet.Add(new Point(-0.5 * this.double_0, 0.5 * this.double_1, 0.0));
			CoordinateSystem actualCS = this.method_0();
			pointSet.TransformCoordinates(actualCS, CoordinateSystem.Global());
			return pointSet;
		}

		private CoordinateSystem method_0()
		{
			return new CoordinateSystem
			{
				Origin = this.point_0,
				BasisVectorMatrix = Matrix3d.RotationZAxis(this.double_2)
			};
		}

		public double Perimeter()
		{
			return 2.0 * (this.double_0 + this.double_1);
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

		public double Length
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

		public double RotationAngle
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

		public double Width
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

		private double double_0;

		private double double_1;

		private double double_2;

		private Point point_0;
	}
}
