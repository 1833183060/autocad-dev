using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	[Serializable]
	public class EllipticalCone
	{
		public EllipticalCone()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(EllipticalCone));
			//base..ctor();
			this.ellipse_0 = new Ellipse();
			this.ellipse_1 = new Ellipse();
		}

		public EllipticalCone(Ellipse bottomEllipse, Ellipse topEllipse)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(EllipticalCone));
			//base..ctor();
			this.ellipse_0 = bottomEllipse;
			this.ellipse_1 = topEllipse;
		}

		public EllipticalCone(Ellipse bottomEllipse, double height)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(EllipticalCone));
			//base..ctor();
			this.ellipse_0 = bottomEllipse;
			Vector3d vector3d = this.ellipse_0.NormalVector.DeepCopy();
			vector3d.Norm = height;
			this.ellipse_1 = this.ellipse_0.Move(vector3d);
		}

		public EllipticalCone(Ellipse bottomEllipse, Edge path)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(EllipticalCone));
			//base..ctor();
			this.ellipse_0 = bottomEllipse;
			this.ellipse_1 = this.ellipse_0.Move(path.StartPoint, path.EndPoint);
		}

		public double Area(int numberOfFaces)
		{
			double result;
			try
			{
				List<Triangle> surface = this.GetSurface(numberOfFaces);
				double num = 0.0;
				for (int i = 0; i < surface.Count; i++)
				{
					num += surface[i].Area;
				}
				result = num;
			}
            catch (System.Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public EllipticalCone DeepCopy()
		{
			return new EllipticalCone
			{
				ellipse_0 = this.ellipse_0.DeepCopy(),
				ellipse_1 = this.ellipse_1.DeepCopy(),
				bool_0 = this.bool_0
			};
		}

		public List<Triangle> GetSurface(int numberOfFaces)
		{
			if (this.ellipse_0 == null | this.ellipse_1 == null)
			{
				throw new InvalidOperationException("Bottom or top ellipse is null!");
			}
			if ((double)numberOfFaces / 2.0 != Math.Ceiling((double)numberOfFaces / 2.0))
			{
				throw new ArgumentException("Number of faces on surface is odd. Must be even!");
			}
			if (numberOfFaces < 6)
			{
				throw new ArgumentException("Number of faces on surface must be at least 12!");
			}
			Ellipse ellipse = this.ellipse_0.DeepCopy();
			Ellipse ellipse2 = this.ellipse_1.DeepCopy();
			if (Vector3d.Dot(ellipse.NormalVector, ellipse2.NormalVector) < 0.0)
			{
				ellipse.SemiminorAxisVector = -1.0 * ellipse.SemiminorAxisVector;
			}
			Point pointAtParameter = ellipse2.GetPointAtParameter(0.0);
			Point endPoint = pointAtParameter.PerpendicularOnPerimeter(ellipse).EndPoint;
			int int_ = (int)((double)numberOfFaces / 2.0);
			if (this.bool_0)
			{
				int_ = (int)((double)numberOfFaces / 4.0) + 1;
			}
			PointSet pointSet = this.method_0(ellipse2, pointAtParameter, int_);
			PointSet pointSet2 = this.method_0(ellipse, endPoint, int_);
			List<Triangle> list = new List<Triangle>();
			Triangle item;
			Triangle item2;
			for (int i = 0; i < pointSet.Count - 1; i++)
			{
				item = new Triangle(pointSet[i], pointSet2[i], pointSet[i + 1]);
				item2 = new Triangle(pointSet[i + 1], pointSet2[i], pointSet2[i + 1]);
				list.Add(item);
				list.Add(item2);
			}
			item = new Triangle(pointSet[pointSet.Count - 1], pointSet2[pointSet.Count - 1], pointSet2[0]);
			item2 = new Triangle(pointSet[pointSet.Count - 1], pointSet2[0], pointSet[0]);
			list.Add(item);
			list.Add(item2);
			if (this.bool_0)
			{
				for (int j = 0; j < pointSet.Count - 2; j++)
				{
					item = new Triangle(pointSet[0], pointSet[j + 1], pointSet[j + 2]);
					item2 = new Triangle(pointSet2[0], pointSet2[j + 1], pointSet2[j + 2]);
					list.Add(item);
					list.Add(item2);
				}
			}
			return list;
		}

		private PointSet method_0(Ellipse ellipse_2, Point point_0, int int_0)
		{
			PointSet pointSet = new PointSet();
			double parameterAtPoint = ellipse_2.GetParameterAtPoint(point_0);
			double num = 6.2831853071795862 / (double)int_0;
			for (int i = 0; i < int_0; i++)
			{
				double num2 = parameterAtPoint + (double)i * num;
				if (num2 > 6.2831853071795862)
				{
					num2 -= 6.2831853071795862;
				}
				Point pointAtParameter = ellipse_2.GetPointAtParameter(num2);
				pointSet.Add(pointAtParameter);
			}
			return pointSet;
		}

		public Ellipse BottomEllipse
		{
			get
			{
				return this.ellipse_0;
			}
			set
			{
				this.ellipse_0 = value;
			}
		}

		public bool HasCover
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public Ellipse TopEllipse
		{
			get
			{
				return this.ellipse_1;
			}
			set
			{
				this.ellipse_1 = value;
			}
		}

		private bool bool_0;

		private Ellipse ellipse_0;

		private Ellipse ellipse_1;
	}
}
