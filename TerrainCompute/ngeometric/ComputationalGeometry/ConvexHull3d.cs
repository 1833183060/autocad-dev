using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class ConvexHull3d
	{
		public ConvexHull3d()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(ConvexHull3d));
			this.list_1 = new List<Class25>();
			//base..ctor();
		}

		public double Area()
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			double num = 0.0;
			for (int i = 0; i < this.list_0.Count; i++)
			{
				num += this.list_0[i].Area;
			}
			return num;
		}

		public Point CenterOfMass()
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			new Matrix3d();
			double[] array = new double[4];
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Vector3d vector3d = this.list_0[i].Vertex1.method_2();
				Vector3d vector3d2 = this.list_0[i].Vertex2.method_2();
				Vector3d vector3d3 = this.list_0[i].Vertex3.method_2();
				Vector3d vector3d4 = Vector3d.Cross(vector3d2 - vector3d, vector3d3 - vector3d);
				Vector3d vector3d5 = new Vector3d();
				Vector3d vector3d6 = new Vector3d();
				Vector3d vector3d7 = vector3d + vector3d2;
				Vector3d left = new Vector3d(vector3d.X * vector3d.X, vector3d.Y * vector3d.Y, vector3d.Z * vector3d.Z);
				Vector3d vector3d8 = left + new Vector3d(vector3d2.X * vector3d7.X, vector3d2.Y * vector3d7.Y, vector3d2.Z * vector3d7.Z);
				vector3d5.X = vector3d7.X + vector3d3.X;
				vector3d5.Y = vector3d7.Y + vector3d3.Y;
				vector3d5.Z = vector3d7.Z + vector3d3.Z;
				vector3d6.X = vector3d8.X + vector3d3.X * vector3d5.X;
				vector3d6.Y = vector3d8.Y + vector3d3.Y * vector3d5.Y;
				vector3d6.Z = vector3d8.Z + vector3d3.Z * vector3d5.Z;
				array[0] += vector3d4.X * vector3d5.X;
				array[1] += vector3d4.X * vector3d6.X;
				array[2] += vector3d4.Y * vector3d6.Y;
				array[3] += vector3d4.Z * vector3d6.Z;
			}
			double num = 0.041666666666666664;
			array[0] /= 6.0;
			array[1] *= num;
			array[2] *= num;
			array[3] *= num;
			return new Point(array[1], array[2], array[3]) * (1.0 / array[0]);
		}

		public void ComputeHull()
		{
			if (this.pointSet_0 == null)
			{
				throw new InvalidOperationException("Can not compute convex hull: no point set defined.");
			}
			if (this.pointSet_0.Count < 4)
			{
				throw new ArgumentException("Can not compute 3d convex hull for less than four points.");
			}
			if (!Class20.bool_0)
			{
				Class20.smethod_0();
			}
			Class21 @class = new Class21(this);
			this.method_1(@class.method_2().GetRange(0, @class.method_2().Count - 4), ref @class);
			this.list_0 = new List<Triangle>();
			for (int i = 0; i < @class.method_0().Count; i++)
			{
				try
				{
					if (@class.method_0()[i].method_0())
					{
						this.list_0.Add(@class.method_0()[i].method_16());
					}
				}
                catch (System.Exception ex)
				{
					this.int_0++;
				}
			}
			this.pointSet_1 = new PointSet();
			for (int j = 0; j < @class.method_2().Count; j++)
			{
				if (@class.method_2()[j].method_4())
				{
					this.pointSet_1.Add(@class.method_2()[j].method_0());
				}
			}
		}

		public bool Contains(Point point)
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			for (int i = 0; i < this.list_0.Count; i++)
			{
				double num = Predicate.Orient3d(this.list_0[i].Vertex1, this.list_0[i].Vertex2, this.list_0[i].Vertex3, point);
				if (num < 0.0)
				{
					return false;
				}
			}
			return true;
		}

		public bool ContainsExact(Point point)
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			for (int i = 0; i < this.list_0.Count; i++)
			{
				double num = Predicate.Orient3d_exact(this.list_0[i].Vertex1, this.list_0[i].Vertex2, this.list_0[i].Vertex3, point);
				if (num < 0.0)
				{
					return false;
				}
			}
			return true;
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		~ConvexHull3d()
		{
			this.method_0(false);
		}

		public Matrix3d InertiaTensor()
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			Matrix3d matrix3d = new Matrix3d();
			double[] array = new double[10];
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Vector3d vector3d = this.list_0[i].Vertex1.method_2();
				Vector3d vector3d2 = this.list_0[i].Vertex2.method_2();
				Vector3d vector3d3 = this.list_0[i].Vertex3.method_2();
				Vector3d vector3d4 = Vector3d.Cross(vector3d2 - vector3d, vector3d3 - vector3d);
				Vector3d vector3d5 = new Vector3d();
				Vector3d vector3d6 = new Vector3d();
				Vector3d vector3d7 = new Vector3d();
				Vector3d vector3d8 = new Vector3d();
				Vector3d vector3d9 = new Vector3d();
				Vector3d vector3d10 = new Vector3d();
				Vector3d vector3d11 = vector3d + vector3d2;
				Vector3d vector3d12 = new Vector3d(vector3d.X * vector3d.X, vector3d.Y * vector3d.Y, vector3d.Z * vector3d.Z);
				Vector3d vector3d13 = vector3d12 + new Vector3d(vector3d2.X * vector3d11.X, vector3d2.Y * vector3d11.Y, vector3d2.Z * vector3d11.Z);
				vector3d5.X = vector3d11.X + vector3d3.X;
				vector3d5.Y = vector3d11.Y + vector3d3.Y;
				vector3d5.Z = vector3d11.Z + vector3d3.Z;
				vector3d6.X = vector3d13.X + vector3d3.X * vector3d5.X;
				vector3d6.Y = vector3d13.Y + vector3d3.Y * vector3d5.Y;
				vector3d6.Z = vector3d13.Z + vector3d3.Z * vector3d5.Z;
				vector3d7.X = vector3d.X * vector3d12.X + vector3d2.X * vector3d13.X + vector3d3.X * vector3d6.X;
				vector3d7.Y = vector3d.Y * vector3d12.Y + vector3d2.Y * vector3d13.Y + vector3d3.Y * vector3d6.Y;
				vector3d7.Z = vector3d.Z * vector3d12.Z + vector3d2.Z * vector3d13.Z + vector3d3.Z * vector3d6.Z;
				vector3d8.X = vector3d6.X + vector3d.X * (vector3d5.X + vector3d.X);
				vector3d8.Y = vector3d6.Y + vector3d.Y * (vector3d5.Y + vector3d.Y);
				vector3d8.Z = vector3d6.Z + vector3d.Z * (vector3d5.Z + vector3d.Z);
				vector3d9.X = vector3d6.X + vector3d2.X * (vector3d5.X + vector3d2.X);
				vector3d9.Y = vector3d6.Y + vector3d2.Y * (vector3d5.Y + vector3d2.Y);
				vector3d9.Z = vector3d6.Z + vector3d2.Z * (vector3d5.Z + vector3d2.Z);
				vector3d10.X = vector3d6.X + vector3d3.X * (vector3d5.X + vector3d3.X);
				vector3d10.Y = vector3d6.Y + vector3d3.Y * (vector3d5.Y + vector3d3.Y);
				vector3d10.Z = vector3d6.Z + vector3d3.Z * (vector3d5.Z + vector3d3.Z);
				array[0] += vector3d4.X * vector3d5.X;
				array[1] += vector3d4.X * vector3d6.X;
				array[2] += vector3d4.Y * vector3d6.Y;
				array[3] += vector3d4.Z * vector3d6.Z;
				array[4] += vector3d4.X * vector3d7.X;
				array[5] += vector3d4.Y * vector3d7.Y;
				array[6] += vector3d4.Z * vector3d7.Z;
				array[7] += vector3d4.X * (vector3d.Y * vector3d8.X + vector3d2.Y * vector3d9.X + vector3d3.Y * vector3d10.X);
				array[8] += vector3d4.Y * (vector3d.Z * vector3d8.Y + vector3d2.Z * vector3d9.Y + vector3d3.Z * vector3d10.Y);
				array[9] += vector3d4.Z * (vector3d.X * vector3d8.Z + vector3d2.X * vector3d9.Z + vector3d3.X * vector3d10.Z);
			}
			double num = 0.041666666666666664;
			double num2 = 0.016666666666666666;
			double num3 = 0.0083333333333333332;
			array[0] /= 6.0;
			array[1] *= num;
			array[2] *= num;
			array[3] *= num;
			array[4] *= num2;
			array[5] *= num2;
			array[6] *= num2;
			array[7] *= num3;
			array[8] *= num3;
			array[9] *= num3;
			double num4 = array[0];
			Point point = new Point(array[1], array[2], array[3]) * (1.0 / num4);
			matrix3d.a00 = array[5] + array[6];
			matrix3d.a01 = -array[7];
			matrix3d.a02 = -array[9];
			matrix3d.a10 = matrix3d.a01;
			matrix3d.a11 = array[4] + array[6];
			matrix3d.a12 = -array[8];
			matrix3d.a20 = matrix3d.a02;
			matrix3d.a21 = matrix3d.a12;
			matrix3d.a22 = array[4] + array[5];
			matrix3d.a00 -= num4 * (point.Y * point.Y + point.Z * point.Z);
			matrix3d.a01 += num4 * point.X * point.Y;
			matrix3d.a02 += num4 * point.Z * point.X;
			matrix3d.a10 = matrix3d.a01;
			matrix3d.a11 -= num4 * (point.Z * point.Z + point.X * point.X);
			matrix3d.a12 += num4 * point.Y * point.Z;
			matrix3d.a20 = matrix3d.a02;
			matrix3d.a21 = matrix3d.a12;
			matrix3d.a22 -= num4 * (point.X * point.X + point.Y * point.Y);
			return matrix3d;
		}

		public Matrix3d InertiaTensor(Point referencePoint)
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			Matrix3d matrix3d = new Matrix3d();
			double[] array = new double[10];
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Vector3d vector3d = this.list_0[i].Vertex1.method_2();
				Vector3d vector3d2 = this.list_0[i].Vertex2.method_2();
				Vector3d vector3d3 = this.list_0[i].Vertex3.method_2();
				Vector3d vector3d4 = Vector3d.Cross(vector3d2 - vector3d, vector3d3 - vector3d);
				Vector3d vector3d5 = new Vector3d();
				Vector3d vector3d6 = new Vector3d();
				Vector3d vector3d7 = new Vector3d();
				Vector3d vector3d8 = new Vector3d();
				Vector3d vector3d9 = new Vector3d();
				Vector3d vector3d10 = new Vector3d();
				Vector3d vector3d11 = vector3d + vector3d2;
				Vector3d vector3d12 = new Vector3d(vector3d.X * vector3d.X, vector3d.Y * vector3d.Y, vector3d.Z * vector3d.Z);
				Vector3d vector3d13 = vector3d12 + new Vector3d(vector3d2.X * vector3d11.X, vector3d2.Y * vector3d11.Y, vector3d2.Z * vector3d11.Z);
				vector3d5.X = vector3d11.X + vector3d3.X;
				vector3d5.Y = vector3d11.Y + vector3d3.Y;
				vector3d5.Z = vector3d11.Z + vector3d3.Z;
				vector3d6.X = vector3d13.X + vector3d3.X * vector3d5.X;
				vector3d6.Y = vector3d13.Y + vector3d3.Y * vector3d5.Y;
				vector3d6.Z = vector3d13.Z + vector3d3.Z * vector3d5.Z;
				vector3d7.X = vector3d.X * vector3d12.X + vector3d2.X * vector3d13.X + vector3d3.X * vector3d6.X;
				vector3d7.Y = vector3d.Y * vector3d12.Y + vector3d2.Y * vector3d13.Y + vector3d3.Y * vector3d6.Y;
				vector3d7.Z = vector3d.Z * vector3d12.Z + vector3d2.Z * vector3d13.Z + vector3d3.Z * vector3d6.Z;
				vector3d8.X = vector3d6.X + vector3d.X * (vector3d5.X + vector3d.X);
				vector3d8.Y = vector3d6.Y + vector3d.Y * (vector3d5.Y + vector3d.Y);
				vector3d8.Z = vector3d6.Z + vector3d.Z * (vector3d5.Z + vector3d.Z);
				vector3d9.X = vector3d6.X + vector3d2.X * (vector3d5.X + vector3d2.X);
				vector3d9.Y = vector3d6.Y + vector3d2.Y * (vector3d5.Y + vector3d2.Y);
				vector3d9.Z = vector3d6.Z + vector3d2.Z * (vector3d5.Z + vector3d2.Z);
				vector3d10.X = vector3d6.X + vector3d3.X * (vector3d5.X + vector3d3.X);
				vector3d10.Y = vector3d6.Y + vector3d3.Y * (vector3d5.Y + vector3d3.Y);
				vector3d10.Z = vector3d6.Z + vector3d3.Z * (vector3d5.Z + vector3d3.Z);
				array[0] += vector3d4.X * vector3d5.X;
				array[1] += vector3d4.X * vector3d6.X;
				array[2] += vector3d4.Y * vector3d6.Y;
				array[3] += vector3d4.Z * vector3d6.Z;
				array[4] += vector3d4.X * vector3d7.X;
				array[5] += vector3d4.Y * vector3d7.Y;
				array[6] += vector3d4.Z * vector3d7.Z;
				array[7] += vector3d4.X * (vector3d.Y * vector3d8.X + vector3d2.Y * vector3d9.X + vector3d3.Y * vector3d10.X);
				array[8] += vector3d4.Y * (vector3d.Z * vector3d8.Y + vector3d2.Z * vector3d9.Y + vector3d3.Z * vector3d10.Y);
				array[9] += vector3d4.Z * (vector3d.X * vector3d8.Z + vector3d2.X * vector3d9.Z + vector3d3.X * vector3d10.Z);
			}
			double num = 0.016666666666666666;
			double num2 = 0.0083333333333333332;
			array[0] /= 6.0;
			array[4] *= num;
			array[5] *= num;
			array[6] *= num;
			array[7] *= num2;
			array[8] *= num2;
			array[9] *= num2;
			double num3 = array[0];
			matrix3d.a00 = array[5] + array[6];
			matrix3d.a01 = -array[7];
			matrix3d.a02 = -array[9];
			matrix3d.a10 = matrix3d.a01;
			matrix3d.a11 = array[4] + array[6];
			matrix3d.a12 = -array[8];
			matrix3d.a20 = matrix3d.a02;
			matrix3d.a21 = matrix3d.a12;
			matrix3d.a22 = array[4] + array[5];
			matrix3d.a00 -= num3 * (referencePoint.Y * referencePoint.Y + referencePoint.Z * referencePoint.Z);
			matrix3d.a01 += num3 * referencePoint.X * referencePoint.Y;
			matrix3d.a02 += num3 * referencePoint.Z * referencePoint.X;
			matrix3d.a10 = matrix3d.a01;
			matrix3d.a11 -= num3 * (referencePoint.Z * referencePoint.Z + referencePoint.X * referencePoint.X);
			matrix3d.a12 += num3 * referencePoint.Y * referencePoint.Z;
			matrix3d.a20 = matrix3d.a02;
			matrix3d.a21 = matrix3d.a12;
			matrix3d.a22 -= num3 * (referencePoint.X * referencePoint.X + referencePoint.Y * referencePoint.Y);
			return matrix3d;
		}

		private void method_0(bool bool_1)
		{
			if (this.bool_0)
			{
				return;
			}
			if (bool_1)
			{
				this.pointSet_0 = null;
				this.list_0 = null;
				this.pointSet_1 = null;
			}
			this.bool_0 = true;
		}

		private void method_1(List<Class25> vertexList, ref Class21 class21_0)
		{
			for (int i = vertexList.Count - 1; i >= 0; i--)
			{
				this.vmethod_0(null, null);
				Class25 @class = vertexList[i];
				try
				{
					if (@class.method_2().Count != 0)
					{
						List<Class23> list = class21_0.method_7(@class);
						if (list != null)
						{
							if (list.Count < 3)
							{
								this.list_1.Add(@class);
							}
							else
							{
								List<Class13> list2 = new List<Class13>();
								for (int j = 0; j < list.Count; j++)
								{
									Class13 class2 = new Class13(list[j].method_0(), list[j].method_2(), @class);
									list2.Add(class2);
									Class13 class3 = list[j].method_4()[0];
									Class13 class4 = list[j].method_4()[1];
									for (int k = 0; k < class3.method_10().Count; k++)
									{
										Class25 class5 = class3.method_10()[k];
										if (!(class5 == @class) && !class4.method_15(class5) && class2.method_15(class5))
										{
											class2.method_10().Add(class5);
											class5.method_2().Add(class2);
										}
									}
									for (int l = 0; l < class4.method_10().Count; l++)
									{
										Class25 class6 = class4.method_10()[l];
										if (!(class6 == @class) && class2.method_15(class6))
										{
											class2.method_10().Add(class6);
											class6.method_2().Add(class2);
										}
									}
									class2.method_8()[2] = class4;
									if (class4.method_6() == list[j].method_0() && class4.method_4() == list[j].method_2())
									{
										class4.method_8()[0] = class2;
									}
									if (class4.method_2() == list[j].method_0() && class4.method_6() == list[j].method_2())
									{
										class4.method_8()[1] = class2;
									}
									if (class4.method_4() == list[j].method_0() && class4.method_2() == list[j].method_2())
									{
										class4.method_8()[2] = class2;
									}
								}
								list2[0].method_8()[0] = list2[1];
								list2[0].method_8()[1] = list2[list2.Count - 1];
								for (int m = 1; m < list2.Count - 1; m++)
								{
									list2[m].method_8()[0] = list2[m + 1];
									list2[m].method_8()[1] = list2[m - 1];
								}
								list2[list2.Count - 1].method_8()[0] = list2[0];
								list2[list2.Count - 1].method_8()[1] = list2[list2.Count - 2];
								for (int n = 0; n < @class.method_2().Count; n++)
								{
									@class.method_2()[n].method_1(false);
								}
								class21_0.method_0().AddRange(list2);
							}
						}
					}
				}
                catch (System.Exception ex)
				{
					this.list_1.Add(@class);
				}
			}
		}

		private BoundingBox method_2()
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			BoundingBox result = new BoundingBox();
			CoordinateSystem.Global();
			CoordinateSystem coordinateSystem = CoordinateSystem.Global();
			PointSet pointSet = this.pointSet_1.DeepCopy();
			double num = 1.7976931348623157E+308;
			for (int i = 0; i < this.list_0.Count; i++)
			{
				CoordinateSystem coordinateSystem2 = new CoordinateSystem(this.list_0[i].GetPlane());
				coordinateSystem2.Orthonormalize();
				pointSet.TransformCoordinates(coordinateSystem, coordinateSystem2);
				double[] array = BoundingBox.smethod_0(pointSet);
				if ((array[1] - array[0]) * (array[3] - array[2]) * (array[5] - array[4]) < num)
				{
					num = (array[1] - array[0]) * (array[3] - array[2]) * (array[5] - array[4]);
					double x = 0.5 * (array[0] + array[1]);
					double y = 0.5 * (array[2] + array[3]);
					double z = 0.5 * (array[4] + array[5]);
					CoordinateSystem coordinateSystem3 = coordinateSystem2.DeepCopy();
					coordinateSystem3.Origin = new Point(x, y, z).TransformCoordinates(coordinateSystem2, coordinateSystem);
					result = new BoundingBox(array[1] - array[0], array[3] - array[2], array[5] - array[4], coordinateSystem3);
				}
				pointSet.TransformCoordinates(coordinateSystem2, coordinateSystem);
			}
			return result;
		}

		public BoundingBox PrincipalAxesBoundingBox()
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			PointSet pointSet = this.pointSet_1.DeepCopy();
			CoordinateSystem coordinateSystem = new CoordinateSystem();
			coordinateSystem.Origin = new Point(0.0, 0.0, 0.0);
			coordinateSystem.BasisVectorMatrix = this.InertiaTensor().SymmetricEigenvectors;
			pointSet.TransformCoordinates(CoordinateSystem.Global(), coordinateSystem);
			double[] array = BoundingBox.smethod_0(pointSet);
			double x = 0.5 * (array[0] + array[1]);
			double y = 0.5 * (array[2] + array[3]);
			double z = 0.5 * (array[4] + array[5]);
			Point origin = new Point(x, y, z).TransformCoordinates(coordinateSystem, CoordinateSystem.Global());
			coordinateSystem.Origin = origin;
			return new BoundingBox(array[1] - array[0], array[3] - array[2], array[5] - array[4], coordinateSystem);
		}

		internal virtual void vmethod_0(object sender, EventArgs e)
		{
			HullPointInsertionEventHandler hullPointInsertionEventHandler = this.hullPointInsertionEventHandler_0;
			if (hullPointInsertionEventHandler != null)
			{
				hullPointInsertionEventHandler(sender, e);
			}
		}

		public double Volume()
		{
			if (this.list_0 == null)
			{
				throw new InvalidOperationException("The hull has not been computed yet.");
			}
			double num = 0.0;
			for (int i = 0; i < this.list_0.Count; i++)
			{
				double num2 = this.list_0[i].Vertex2.Y - this.list_0[i].Vertex1.Y;
				double num3 = this.list_0[i].Vertex2.Z - this.list_0[i].Vertex1.Z;
				double num4 = this.list_0[i].Vertex3.Y - this.list_0[i].Vertex1.Y;
				double num5 = this.list_0[i].Vertex3.Z - this.list_0[i].Vertex1.Z;
				double num6 = num2 * num5 - num3 * num4;
				double num7 = this.list_0[i].Vertex1.X + this.list_0[i].Vertex2.X + this.list_0[i].Vertex3.X;
				num += num6 * num7;
			}
			return num / 6.0;
		}

		public List<Point> BadPoints
		{
			get
			{
				List<Point> list = new List<Point>();
				for (int i = 0; i < this.list_1.Count; i++)
				{
					list.Add(this.list_1[i].method_0());
				}
				return list;
			}
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
				this.pointSet_1 = null;
				this.list_0 = null;
			}
		}

		public int NumberOfDegenerateTriangles
		{
			get
			{
				return this.int_0;
			}
		}

		public List<Triangle> Triangles
		{
			get
			{
				if (this.list_0 == null)
				{
					throw new InvalidOperationException("The hull has not been computed yet.");
				}
				return this.list_0;
			}
		}

		public PointSet Vertices
		{
			get
			{
				if (this.pointSet_1 == null)
				{
					throw new InvalidOperationException("The hull has not been computed yet.");
				}
				return this.pointSet_1;
			}
		}

		public event HullPointInsertionEventHandler PointInsertionHandler
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.hullPointInsertionEventHandler_0 = (HullPointInsertionEventHandler)Delegate.Combine(this.hullPointInsertionEventHandler_0, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.hullPointInsertionEventHandler_0 = (HullPointInsertionEventHandler)Delegate.Remove(this.hullPointInsertionEventHandler_0, value);
			}
		}

		private bool bool_0;

		private HullPointInsertionEventHandler hullPointInsertionEventHandler_0;

		private int int_0;

		private List<Triangle> list_0;

		private List<Class25> list_1;

		private PointSet pointSet_0;

		private PointSet pointSet_1;
	}
}
