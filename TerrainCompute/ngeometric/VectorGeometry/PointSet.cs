using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class PointSet : CollectionBase
	{
		public PointSet()
		{           
		}

		public PointSet(List<Point> points)
		{           
			base.InnerList.AddRange(points);
		}

		public int Add(Point point)
		{
			return base.List.Add(point);
		}
        public int Add(Autodesk.AutoCAD.Geometry.Point3d point)
        {
            return base.List.Add(new Point(point.X,point.Y,point.Z));
        }

        public void Add(List<Autodesk.AutoCAD.Geometry.Point3d> pl)
        {
            for (int i = 0; i < pl.Count; i++)
            {
                this.Add(pl[i]);
            }
        }
        public void Add(List<Point> pl)
        {
            for (int i = 0; i < pl.Count; i++)
            {
                this.Add(pl[i]);
            }
        }

		public void Add(PointSet pointSet)
		{
			for (int i = 0; i < pointSet.Count; i++)
			{
				this.Add(pointSet[i]);
			}
		}
        public void Add2(PointSet2 pointSet)
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

		public PointSet DeepCopy()
		{
			PointSet pointSet = new PointSet();
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

		~PointSet()
		{
			this.method_0(false);
		}

		public PointSet GetRange(int index, int count)
		{
			PointSet pointSet = new PointSet();
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

		public void ReadFromFile(string fileName, char separator)
		{
			using (StreamReader streamReader = new StreamReader(fileName))
			{
				while (streamReader.Peek() >= 0)
				{
					string text = streamReader.ReadLine();
					if (!(text.StartsWith("C", true, null) | text == ""))
					{
						try
						{
							string[] array = text.Split(new char[]
							{
								separator
							});
							if (separator == ' ')
							{
								List<double> list = new List<double>();
								string[] array2 = array;
								for (int i = 0; i < array2.Length; i++)
								{
									string text2 = array2[i];
									if (PointSet.smethod_0(text2))
									{
										list.Add(Convert.ToDouble(text2));
										if (list.Count == 3)
										{
											Point point = new Point(list[0], list[1], list[2]);
											this.Add(point);
											break;
										}
									}
								}
							}
							else
							{
								Point point2 = new Point(Convert.ToDouble(array[0]), Convert.ToDouble(array[1]), Convert.ToDouble(array[2]));
								this.Add(point2);
							}
						}
                        catch (System.Exception ex)
						{
							throw new FormatException(string.Concat(new string[]
							{
								"Invalid point format in line:",
								Environment.NewLine,
								text,
								Environment.NewLine,
								ex.Message
							}));
						}
					}
				}
			}
		}

		public void Remove(Point point)
		{
			base.List.Remove(point);
		}

		public void RemoveMultiplePoints2d()
		{
			if (base.Count < 2)
			{
				return;
			}
			base.InnerList.Sort(new PointComparer1());
			PointSet pointSet = new PointSet();
			pointSet.Add(this[base.Count - 1]);
			for (int i = base.Count - 2; i >= 0; i--)
			{
				if (Math.Abs(this[i].X - this[i + 1].X) > Global.AbsoluteEpsilon || Math.Abs(this[i].Y - this[i + 1].Y) > Global.AbsoluteEpsilon)
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

		public void RemoveMultiplePoints3d()
		{
			if (base.Count < 2)
			{
				return;
			}
			base.InnerList.Sort(new PointComparer1());
			PointSet pointSet = new PointSet();
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

		public void Rotate(Matrix3d rotationMatrix)
		{
			for (int i = 0; i < base.Count; i++)
			{
				Point point = this[i];
				double x = point.X;
				double y = point.Y;
				double z = point.Z;
				point.X = rotationMatrix.a00 * x + rotationMatrix.a01 * y + rotationMatrix.a02 * z;
				point.Y = rotationMatrix.a10 * x + rotationMatrix.a11 * y + rotationMatrix.a12 * z;
				point.Z = rotationMatrix.a20 * x + rotationMatrix.a21 * y + rotationMatrix.a22 * z;
			}
		}

		public void Rotate(Point center, Matrix3d rotationMatrix)
		{
			for (int i = 0; i < base.Count; i++)
			{
				Point point = this[i];
				double num = point.X - center.X;
				double num2 = point.Y - center.Y;
				double num3 = point.Z - center.Z;
				double num4 = rotationMatrix.a00 * num + rotationMatrix.a01 * num2 + rotationMatrix.a02 * num3;
				double num5 = rotationMatrix.a10 * num + rotationMatrix.a11 * num2 + rotationMatrix.a12 * num3;
				double num6 = rotationMatrix.a20 * num + rotationMatrix.a21 * num2 + rotationMatrix.a22 * num3;
				point.X = num4 + center.X;
				point.Y = num5 + center.Y;
				point.Z = num6 + center.Z;
			}
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

		public void Sort(PointSet.SortOrder sortOrder)
		{
			switch (sortOrder)
			{
			case PointSet.SortOrder.XYZ:
				base.InnerList.Sort(new PointComparer1());
				return;
			case PointSet.SortOrder.XZY:
				base.InnerList.Sort(new Class6());
				return;
			case PointSet.SortOrder.YXZ:
				base.InnerList.Sort(new Class7());
				return;
			case PointSet.SortOrder.YZX:
				base.InnerList.Sort(new Class8());
				return;
			case PointSet.SortOrder.ZXY:
				base.InnerList.Sort(new Class9());
				return;
			case PointSet.SortOrder.ZYX:
				base.InnerList.Sort(new Class10());
				return;
			default:
				return;
			}
		}

		public void Swap(int index1, int index2)
		{
			Point value = this[index1].DeepCopy();
			Point value2 = this[index2].DeepCopy();
			base.InnerList[index2] = value;
			base.InnerList[index1] = value2;
		}

		public Point[] ToArray()
		{
			return (Point[])base.InnerList.ToArray(typeof(Point));
		}

		public List<Point> ToList()
		{
			Point[] collection = (Point[])base.InnerList.ToArray(typeof(Point));
			return new List<Point>(collection);
		}

		public static PointSet ToPointSet(List<Point> points)
		{
			PointSet pointSet = new PointSet();
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

		public void WriteToFile(string FileName, string separator)
		{
			using (StreamWriter streamWriter = new StreamWriter(FileName))
			{
				streamWriter.WriteLine(string.Concat(new object[]
				{
					"C ",
					FileName,
					" generated ",
					DateTime.Now
				}));
				foreach (Point point in this)
				{
					string text = point.X.ToString();
					string text2 = point.Y.ToString();
					string text3 = point.Z.ToString();
					string text4 = string.Concat(new string[]
					{
						text,
						separator,
						text2,
						separator,
						text3,
						separator
					});
					streamWriter.WriteLine(text4.TrimEnd(new char[0]));
				}
				streamWriter.Flush();
			}
		}

		public void WriteToFile(string FileName, string separator, string Format)
		{
			using (StreamWriter streamWriter = new StreamWriter(FileName))
			{
				streamWriter.WriteLine(string.Concat(new object[]
				{
					"C ",
					FileName,
					" generated ",
					DateTime.Now
				}));
				foreach (Point point in this)
				{
					string text = point.X.ToString(Format);
					string text2 = point.Y.ToString(Format);
					string text3 = point.Z.ToString(Format);
					string text4 = string.Concat(new string[]
					{
						text,
						separator,
						text2,
						separator,
						text3,
						separator
					});
					streamWriter.WriteLine(text4.TrimEnd(new char[0]));
				}
				streamWriter.Flush();
			}
		}

		public void WriteToFile(string FileName, string separator, string Format, int ColumnWidth)
		{
			using (StreamWriter streamWriter = new StreamWriter(FileName))
			{
				streamWriter.WriteLine(string.Concat(new object[]
				{
					"C ",
					FileName,
					" generated ",
					DateTime.Now
				}));
				foreach (Point point in this)
				{
					string text = point.X.ToString(Format).PadLeft(ColumnWidth);
					string text2 = point.Y.ToString(Format).PadLeft(ColumnWidth);
					string text3 = point.Z.ToString(Format).PadLeft(ColumnWidth);
					if (text.Length > ColumnWidth)
					{
						text = text.Remove(0).PadLeft(ColumnWidth, '*');
					}
					if (text2.Length > ColumnWidth)
					{
						text2 = text2.Remove(0).PadLeft(ColumnWidth, '*');
					}
					if (text3.Length > ColumnWidth)
					{
						text3 = text3.Remove(0).PadLeft(ColumnWidth, '*');
					}
					string text4 = string.Concat(new string[]
					{
						text,
						separator,
						text2,
						separator,
						text3,
						separator
					});
					streamWriter.WriteLine(text4.TrimEnd(new char[0]));
				}
				streamWriter.Flush();
			}
		}

		public void WriteToFile(string FileName, string separator, string Format, int ColumnWidth, out int numOutputConversionErrors)
		{
			numOutputConversionErrors = 0;
			using (StreamWriter streamWriter = new StreamWriter(FileName))
			{
				streamWriter.WriteLine(string.Concat(new object[]
				{
					"C ",
					FileName,
					" generated ",
					DateTime.Now
				}));
				foreach (Point point in this)
				{
					string text = point.X.ToString(Format).PadLeft(ColumnWidth);
					string text2 = point.Y.ToString(Format).PadLeft(ColumnWidth);
					string text3 = point.Z.ToString(Format).PadLeft(ColumnWidth);
					bool flag = false;
					if (text.Length > ColumnWidth)
					{
						text = text.Remove(0).PadLeft(ColumnWidth, '*');
						flag = true;
					}
					if (text2.Length > ColumnWidth)
					{
						text2 = text2.Remove(0).PadLeft(ColumnWidth, '*');
						flag = true;
					}
					if (text3.Length > ColumnWidth)
					{
						text3 = text3.Remove(0).PadLeft(ColumnWidth, '*');
						flag = true;
					}
					if (flag)
					{
						numOutputConversionErrors++;
					}
					string text4 = string.Concat(new string[]
					{
						text,
						separator,
						text2,
						separator,
						text3,
						separator
					});
					streamWriter.WriteLine(text4.TrimEnd(new char[0]));
				}
				streamWriter.Flush();
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

		public bool IsPlane
		{
			get
			{
				if (base.Count < 3)
				{
					return false;
				}
				Point point = this[0];
				Point point2 = null;
				Point point3 = null;
				int i = 1;
				while (i < base.Count)
				{
					if (!(this[i] != point))
					{
						i++;
					}
					else
					{
						point2 = this[i];
						IL_41_:
						if (point2 == null)
						{
							return false;
						}
						Line line = new Line(point, point2);
						int j = 1;
						while (j < base.Count)
						{
							if (this[j].IsCollinearTo(line))
							{
								j++;
							}
							else
							{
								point3 = this[j];
								IL_89_:
								Plane plane = new Plane(point, point2, point3);
								if (point3 == null)
								{
									return false;
								}
								for (int k = 0; k < base.Count; k++)
								{
									if (!plane.Contains(this[k]))
									{
										return false;
									}
								}
								return true;
							}
						}
                        goto IL_89;
                    IL_89:
                        Plane plane22 = new Plane(point, point2, point3);
                        if (point3 == null)
                        {
                            return false;
                        }
                        for (int k = 0; k < base.Count; k++)
                        {
                            if (!plane22.Contains(this[k]))
                            {
                                return false;
                            }
                        }
                        return true;
					}
				}
                goto IL_41;
            IL_41:
                {
                    if (point2 == null)
                    {
                        return false;
                    }
                    Line line = new Line(point, point2);
                    int j = 1;
                    while (j < base.Count)
                    {
                        if (this[j].IsCollinearTo(line))
                        {
                            j++;
                        }
                        else
                        {
                            point3 = this[j];
                        IL_89_:
                            Plane plane = new Plane(point, point2, point3);
                            if (point3 == null)
                            {
                                return false;
                            }
                            for (int k = 0; k < base.Count; k++)
                            {
                                if (!plane.Contains(this[k]))
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                    goto IL_891;
                IL_891:
                    Plane plane22 = new Plane(point, point2, point3);
                    if (point3 == null)
                    {
                        return false;
                    }
                    for (int k = 0; k < base.Count; k++)
                    {
                        if (!plane22.Contains(this[k]))
                        {
                            return false;
                        }
                    }
                    return true;
                }
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

		public Line LeastSquaresLine
		{
			get
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				foreach (Point point in this)
				{
					num += point.X * point.X;
					num2 += point.X;
					num3 += 1.0;
					num4 += point.X * point.Y;
					num5 += point.Y;
				}
				Matrix3d matrix3d = new Matrix3d();
				matrix3d.a00 = num;
				matrix3d.a01 = num2;
				matrix3d.a02 = 0.0;
				matrix3d.a10 = num2;
				matrix3d.a11 = num3;
				matrix3d.a12 = 0.0;
				matrix3d.a20 = 0.0;
				matrix3d.a21 = 0.0;
				matrix3d.a22 = 1.0;
				Vector3d b = new Vector3d(num4, num5, 1.0);
				Vector3d vector3d = Solver.SolveFull(matrix3d, b);
				Point point2 = new Point(0.0, vector3d.Y, 0.0);
				Vector3d directionVector = new Vector3d(1.0, vector3d.X, 0.0);
				return new Line(point2, directionVector);
			}
		}

		public Plane LeastSquaresPlane
		{
			get
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				foreach (Point point in this)
				{
					num += point.X * point.X;
					num2 += point.X * point.Y;
					num3 += point.X;
					num4 += point.Y * point.Y;
					num5 += point.Y;
					num6 += 1.0;
					num7 += point.X * point.Z;
					num8 += point.Y * point.Z;
					num9 += point.Z;
				}
				Matrix3d matrix3d = new Matrix3d();
				matrix3d.a00 = num;
				matrix3d.a01 = num2;
				matrix3d.a02 = num3;
				matrix3d.a10 = num2;
				matrix3d.a11 = num4;
				matrix3d.a12 = num5;
				matrix3d.a20 = num3;
				matrix3d.a21 = num5;
				matrix3d.a22 = num6;
				Vector3d b = new Vector3d(num7, num8, num9);
				Vector3d vector3d = Solver.SolveFull(matrix3d, b);
				return new Plane(vector3d.X, vector3d.Y, vector3d.Z);
			}
		}

		public Line OrthogonalLeastSquaresLine
		{
			get
			{
				Point center = this.Center;
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				foreach (Point point in this)
				{
					num -= (point.X - center.X) * (point.X - center.X);
					num2 -= (point.X - center.X) * (point.Y - center.Y);
					num3 -= (point.X - center.X) * (point.Z - center.Z);
					num4 -= (point.Y - center.Y) * (point.Y - center.Y);
					num5 -= (point.Y - center.Y) * (point.Z - center.Z);
					num6 -= (point.Z - center.Z) * (point.Z - center.Z);
				}
				Matrix3d matrix3d = new Matrix3d();
				matrix3d.a00 = num;
				matrix3d.a01 = num2;
				matrix3d.a02 = num3;
				matrix3d.a10 = num2;
				matrix3d.a11 = num4;
				matrix3d.a12 = num5;
				matrix3d.a20 = num3;
				matrix3d.a21 = num5;
				matrix3d.a22 = num6;
				double trace = matrix3d.Trace;
				matrix3d.a00 += trace;
				matrix3d.a11 += trace;
				matrix3d.a22 += trace;
				double[] symmetricEigenvalues = matrix3d.SymmetricEigenvalues;
				Matrix3d symmetricEigenvectors = matrix3d.SymmetricEigenvectors;
				if (symmetricEigenvalues[0] <= symmetricEigenvalues[1] & symmetricEigenvalues[0] <= symmetricEigenvalues[2])
				{
					return new Line(center, symmetricEigenvectors.GetColumn(0));
				}
				if (symmetricEigenvalues[1] <= symmetricEigenvalues[0] & symmetricEigenvalues[1] <= symmetricEigenvalues[2])
				{
					return new Line(center, symmetricEigenvectors.GetColumn(1));
				}
				return new Line(center, symmetricEigenvectors.GetColumn(2));
			}
		}

		public Plane OrthogonalLeastSquaresPlane
		{
			get
			{
				Point center = this.Center;
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				foreach (Point point in this)
				{
					num += (point.X - center.X) * (point.X - center.X);
					num2 += (point.X - center.X) * (point.Y - center.Y);
					num3 += (point.X - center.X) * (point.Z - center.Z);
					num4 += (point.Y - center.Y) * (point.Y - center.Y);
					num5 += (point.Y - center.Y) * (point.Z - center.Z);
					num6 += (point.Z - center.Z) * (point.Z - center.Z);
				}
				Matrix3d matrix3d = new Matrix3d();
				matrix3d.a00 = num;
				matrix3d.a01 = num2;
				matrix3d.a02 = num3;
				matrix3d.a10 = num2;
				matrix3d.a11 = num4;
				matrix3d.a12 = num5;
				matrix3d.a20 = num3;
				matrix3d.a21 = num5;
				matrix3d.a22 = num6;
				double[] symmetricEigenvalues = matrix3d.SymmetricEigenvalues;
				Matrix3d symmetricEigenvectors = matrix3d.SymmetricEigenvectors;
				if (symmetricEigenvalues[0] <= symmetricEigenvalues[1] & symmetricEigenvalues[0] <= symmetricEigenvalues[2])
				{
					return new Plane(center, symmetricEigenvectors.GetColumn(1), symmetricEigenvectors.GetColumn(2));
				}
				if (symmetricEigenvalues[1] <= symmetricEigenvalues[0] & symmetricEigenvalues[1] <= symmetricEigenvalues[2])
				{
					return new Plane(center, symmetricEigenvectors.GetColumn(0), symmetricEigenvectors.GetColumn(2));
				}
				return new Plane(center, symmetricEigenvectors.GetColumn(0), symmetricEigenvectors.GetColumn(1));
			}
		}

		private bool bool_0;

		////[LicenseProvider(typeof(Class46))]
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
