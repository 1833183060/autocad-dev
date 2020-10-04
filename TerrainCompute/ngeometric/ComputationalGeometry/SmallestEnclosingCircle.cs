using System;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class SmallestEnclosingCircle
	{
		public SmallestEnclosingCircle()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(SmallestEnclosingCircle));
			this.vector3d_0 = new Vector3d(0.0, 0.0, 1.0);
			//base..ctor();
		}

		public SmallestEnclosingCircle(PointSet pointSet)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(SmallestEnclosingCircle));
			this.vector3d_0 = new Vector3d(0.0, 0.0, 1.0);
			//base..ctor();
			this.pointSet_0 = pointSet;
		}

		public Circle ComputeCircle()
		{
			this.pointSet_0.RandomPermute();
			double x = this.pointSet_0[0].X;
			double y = this.pointSet_0[0].Y;
			double x2 = this.pointSet_0[1].X;
			double y2 = this.pointSet_0[1].Y;
			double num = 0.5 * (x + x2);
			double num2 = 0.5 * (y + y2);
			double num3 = x - x2;
			double num4 = y - y2;
			double num5 = 0.25 * (num3 * num3 + num4 * num4);
			Circle circle = new Circle(new Point(num, num2, 0.0), Math.Sqrt(num5), this.vector3d_0);
			for (int i = 2; i < this.pointSet_0.Count; i++)
			{
				Point point = this.pointSet_0[i];
				num3 = point.X - num;
				num4 = point.Y - num2;
				if (num3 * num3 + num4 * num4 > num5)
				{
					circle = this.method_0(i, point);
					num = circle.Center.X;
					num2 = circle.Center.Y;
					num5 = circle.Radius * circle.Radius;
				}
			}
			return circle;
		}

		private Circle method_0(int int_0, Point point_0)
		{
			double x = this.pointSet_0[0].X;
			double y = this.pointSet_0[0].Y;
			double x2 = point_0.X;
			double y2 = point_0.Y;
			double num = 0.5 * (x + x2);
			double num2 = 0.5 * (y + y2);
			double num3 = x - x2;
			double num4 = y - y2;
			double num5 = 0.25 * (num3 * num3 + num4 * num4);
			Circle circle = new Circle(new Point(num, num2, 0.0), Math.Sqrt(num5), this.vector3d_0);
			for (int i = 1; i < int_0; i++)
			{
				Point point = this.pointSet_0[i];
				num3 = point.X - num;
				num4 = point.Y - num2;
				if (num3 * num3 + num4 * num4 > num5)
				{
					circle = this.method_1(i, point, point_0);
					num = circle.Center.X;
					num2 = circle.Center.Y;
					num5 = circle.Radius * circle.Radius;
				}
			}
			return circle;
		}

		private Circle method_1(int int_0, Point point_0, Point point_1)
		{
			double x = point_0.X;
			double y = point_0.Y;
			double x2 = point_1.X;
			double y2 = point_1.Y;
			double num = 0.5 * (x + x2);
			double num2 = 0.5 * (y + y2);
			double num3 = x - x2;
			double num4 = y - y2;
			double num5 = 0.25 * (num3 * num3 + num4 * num4);
			Circle circle = new Circle(new Point(num, num2, 0.0), Math.Sqrt(num5), this.vector3d_0);
			for (int i = 0; i < int_0; i++)
			{
				Point point = this.pointSet_0[i];
				num3 = point.X - num;
				num4 = point.Y - num2;
				if (num3 * num3 + num4 * num4 > num5)
				{
					circle = new Circle(new Point(x, y, 0.0), new Point(x2, y2, 0.0), new Point(point.X, point.Y, 0.0));
					num = circle.Center.X;
					num2 = circle.Center.Y;
					num5 = circle.Radius * circle.Radius;
				}
			}
			return circle;
		}

		public PointSet InitialPoints
		{
			get
			{
				return this.pointSet_0;
			}
			set
			{
				this.pointSet_0 = value;
			}
		}

		private PointSet pointSet_0;

		private Vector3d vector3d_0;
	}
}
