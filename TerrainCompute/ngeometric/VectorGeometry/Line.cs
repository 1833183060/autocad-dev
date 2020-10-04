using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class Line
	{
		public Line()
		{           
		}

		public Line(Point point, Vector3d directionVector)
		{            
			this.point_0 = point;
			this.vector3d_0 = directionVector;
			if (this.vector3d_0.Norm <= 4.94065645841247E-324)
			{
				throw new ArgumentException("Invalid line direction vector: vector has zero norm.");
			}
		}

		public Line(Point point1, Point point2)
		{            
			this.point_0 = point1;
			this.vector3d_0 = new Vector3d(point2 - point1);
			if (this.vector3d_0.Norm <= 4.94065645841247E-324)
			{
				throw new ArgumentException("Invalid line direction vector: vector has zero norm.");
			}
		}

		public double Angle(Line line)
		{
			if (!this.Intersects3d(line))
			{
				throw new ArgumentException("Can not compute intersection angle: lines do not intersect.");
			}
			return Vector3d.Angle(this.DirectionVector, line.DirectionVector);
		}

		public double Angle(Plane plane)
		{
			return Vector3d.Angle(this.DirectionVector, plane.NormalVector) - 1.5707963267948966;
		}

		public Line Bisector(Line line)
		{
			Point point = this.method_3(line);
			if (point == null)
			{
				throw new ArgumentException("Can not compute bisecting line: lines do not intersect!");
			}
			return new Line(point, Vector3d.Bisector(this.DirectionVector, line.DirectionVector));
		}

		public bool Contains(Point point)
		{
			Vector3d vector3d = new Vector3d(point - this.point_0);
			Vector3d vector3d2 = this.vector3d_0.Normalize();
			return Global.AlmostEquals(vector3d.Y * vector3d2.Z, vector3d.Z * vector3d2.Y) & Global.AlmostEquals(vector3d.Z * vector3d2.X, vector3d.X * vector3d2.Z) & Global.AlmostEquals(vector3d.X * vector3d2.Y, vector3d.Y * vector3d2.X);
		}

		public bool Contains(Edge edge)
		{
			return this.Contains(edge.StartPoint) & this.Contains(edge.EndPoint);
		}

		public Line DeepCopy()
		{
			return new Line
			{
				point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z),
				vector3d_0 = new Vector3d(this.vector3d_0.X, this.vector3d_0.Y, this.vector3d_0.Z)
			};
		}

		public double DistanceTo(Point point)
		{
			return point.DistanceTo(this);
		}

		public double DistanceTo(Line line)
		{
			Vector3d vector3d = this.DirectionVector.Normalize();
			Vector3d vector3d2 = line.DirectionVector.Normalize();
			Vector3d vector3d3 = Vector3d.Cross(vector3d, vector3d2);
			if (vector3d3.X * vector3d3.X + vector3d3.Y * vector3d3.Y + vector3d3.Z * vector3d3.Z < Global.AbsoluteEpsilon)
			{
				return this.Point.DistanceTo(line);
			}
			double num = Vector3d.Triple(new Vector3d(line.Point - this.Point), vector3d, vector3d2);
			return Math.Abs(num / vector3d3.Norm);
		}

		public double DistanceTo(Edge edge)
		{
			if (edge.Length < 4.94065645841247E-324)
			{
				return edge.StartPoint.DistanceTo(this);
			}
			if (this.IsParallelTo(edge))
			{
				return edge.StartPoint.DistanceTo(this);
			}
			return this.PseudoPerpendicularOn(edge).Length;
		}

		public override bool Equals(object obj)
		{
			return this == (Line)obj;
		}

		public override int GetHashCode()
		{
			return this.point_0.GetHashCode() ^ this.vector3d_0.ToPoint().GetHashCode();
		}

		public bool Intersects2d(Triangle triangle)
		{
			PointSet pointSet = this.method_0(triangle);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects2d(Circle circle)
		{
			PointSet pointSet = this.method_1(circle);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects2d(Ellipse ellipse)
		{
			PointSet pointSet = this.method_2(ellipse);
			return pointSet != null && pointSet.Count != 0;
		}

		public bool Intersects3d(Edge edge)
		{
			return this.method_4(edge) != null;
		}

		public bool Intersects3d(Line line)
		{
			return !this.IsSkewTo(line) && !this.IsParallelTo(line);
		}

		public bool Intersects3d(Plane plane)
		{
			return this.getInterSecttion(plane) != null;
		}

		public bool Intersects3d(Triangle triangle)
		{
			return this.method_6(triangle) != null;
		}

		public bool Intersects3d(Circle circle)
		{
			return this.method_7(circle) != null;
		}

		public bool Intersects3d(Ellipse ellipse)
		{
			return this.method_8(ellipse) != null;
		}

		public Point IntersectXY(Line l)
		{
			double x = this.point_0.X;
			double y = this.point_0.Y;
			double num = x + this.vector3d_0.X;
			double num2 = y + this.vector3d_0.Y;
			double x2 = l.point_0.X;
			double y2 = l.point_0.Y;
			double num3 = x2 + l.vector3d_0.X;
			double num4 = y2 + l.vector3d_0.Y;
			double num5 = num3 - x2;
			double num6 = y - y2;
			double num7 = num4 - y2;
			double num8 = x - x2;
			double num9 = num - x;
			double num10 = num2 - y;
			double num11 = num7 * num9 - num5 * num10;
			if (Math.Abs(num11) < Global.AbsoluteEpsilon)
			{
				return null;
			}
			double num12 = num5 * num6 - num7 * num8;
			double num13 = num12 / num11;
			double x3 = x + num13 * num9;
			double y3 = y + num13 * num10;
			return new Point(x3, y3, 0.0);
		}

		public Point IntersectXYDecimal(Line l)
		{
			decimal num = (decimal)this.point_0.X;
			decimal num2 = (decimal)this.point_0.Y;
			decimal d = num + (decimal)this.vector3d_0.X;
			decimal d2 = num2 + (decimal)this.vector3d_0.Y;
			decimal num3 = (decimal)l.point_0.X;
			decimal num4 = (decimal)l.point_0.Y;
			decimal d3 = num3 + (decimal)l.vector3d_0.X;
			decimal d4 = num4 + (decimal)l.vector3d_0.Y;
			decimal d5 = d3 - num3;
			decimal d6 = num2 - num4;
			decimal d7 = d4 - num4;
			decimal d8 = num - num3;
			decimal num5 = d - num;
			decimal num6 = d2 - num2;
			decimal num7 = d7 * num5 - d5 * num6;
			if (Math.Abs(num7) < 0.000000000001m)
			{
				return null;
			}
			decimal d9 = d5 * d6 - d7 * d8;
			decimal d10 = d9 / num7;
			decimal d11 = num5 * d6 - num6 * d8;
			//d11 / num7;
			decimal value = num + d10 * num5;
			decimal value2 = num2 + d10 * num6;
			return new Point((double)value, (double)value2, 0.0);
		}

		public Line Invert()
		{
			return new Line
			{
				point_0 = new Point(this.point_0.X + this.vector3d_0.X, this.point_0.Y + this.vector3d_0.Y, this.point_0.Z + this.vector3d_0.Z),
				vector3d_0 = new Vector3d(-this.vector3d_0.X, -this.vector3d_0.Y, -this.vector3d_0.Z)
			};
		}

		public Line InvertDirectionVector()
		{
			return new Line
			{
				point_0 = new Point(this.point_0.X, this.point_0.Y, this.point_0.Z),
				vector3d_0 = new Vector3d(-this.vector3d_0.X, -this.vector3d_0.Y, -this.vector3d_0.Z)
			};
		}

		public bool IsCollinearTo(Point point)
		{
			return this.Contains(point);
		}

		public bool IsCollinearTo(Edge edge)
		{
			return this.Contains(edge);
		}

		public bool IsCollinearTo(Line line)
		{
			return this == line;
		}

		public bool IsCoplanarTo(Edge edge)
		{
			if (!this.Contains(edge.EndPoint))
			{
				Plane plane = new Plane(this.point_0, this.point_0 + this.vector3d_0.ToPoint(), edge.EndPoint);
				return plane.Contains(edge.StartPoint);
			}
			if (!this.Contains(edge.StartPoint))
			{
				Plane plane2 = new Plane(this.point_0, this.point_0 + this.vector3d_0.ToPoint(), edge.StartPoint);
				return plane2.Contains(edge.EndPoint);
			}
			return this.Contains(edge);
		}

		public bool IsCoplanarTo(Line line)
		{
			if (!this.Contains(line.Point))
			{
				Plane plane = new Plane(this.point_0, this.point_0 + this.vector3d_0.ToPoint(), line.Point);
				return plane.Contains(line.Point + line.DirectionVector.ToPoint());
			}
			if (!this.Contains(line.Point + line.DirectionVector.ToPoint()))
			{
				Plane plane2 = new Plane(this.point_0, this.point_0 + this.vector3d_0.ToPoint(), line.Point + line.DirectionVector.ToPoint());
				return plane2.Contains(line.Point);
			}
			return this == line;
		}

		public bool IsCoplanarTo(Plane plane)
		{
			return plane.Contains(this);
		}

		public bool IsCoplanarTo(Triangle triangle)
		{
			return Plane.smethod_0(triangle.Vertex1, triangle.NormalVector, this.point_0) && triangle.NormalVector.IsOrthogonalTo(this.vector3d_0);
		}

		public bool IsCoplanarTo(Circle circle)
		{
			return Plane.smethod_0(circle.Center, circle.NormalVector, this.point_0) && circle.NormalVector.IsOrthogonalTo(this.vector3d_0);
		}

		public bool IsCoplanarTo(Ellipse ellipse)
		{
			return Plane.smethod_0(ellipse.Center, ellipse.NormalVector, this.point_0) && ellipse.NormalVector.IsOrthogonalTo(this.vector3d_0);
		}

		public bool IsOrthogonalTo(Plane plane)
		{
			return this.vector3d_0.IsParallelTo(plane.NormalVector);
		}

		public bool IsParallelTo(Edge edge)
		{
			return this.vector3d_0.IsParallelTo(edge.ToLine().DirectionVector);
		}

		public bool IsParallelTo(Line line)
		{
			return this.vector3d_0.IsParallelTo(line.DirectionVector);
		}

		public bool IsParallelTo(Plane plane)
		{
			return this.vector3d_0.IsOrthogonalTo(plane.NormalVector);
		}

		public bool IsParallelTo(Triangle triangle)
		{
			return this.vector3d_0.IsOrthogonalTo(triangle.NormalVector);
		}

		public bool IsParallelTo(Circle circle)
		{
			return this.vector3d_0.IsOrthogonalTo(circle.NormalVector);
		}

		public bool IsParallelTo(Ellipse ellipse)
		{
			return this.vector3d_0.IsOrthogonalTo(ellipse.NormalVector);
		}

		public bool IsSkewTo(Line line)
		{
			Vector3d vector3d = new Vector3d(line.Point - this.point_0);
			if (vector3d.Norm < Global.AbsoluteEpsilon)
			{
				return false;
			}
			Vector3d vector3d2 = vector3d.Normalize();
			Vector3d vector3d3 = this.DirectionVector.Normalize();
			Vector3d vector3d4 = line.DirectionVector.Normalize();
			double a = vector3d2.X * vector3d3.Y * vector3d4.Z + vector3d2.Y * vector3d3.Z * vector3d4.X + vector3d2.Z * vector3d3.X * vector3d4.Y;
			double b = vector3d2.Z * vector3d3.Y * vector3d4.X + vector3d2.Y * vector3d3.X * vector3d4.Z + vector3d2.X * vector3d3.Z * vector3d4.Y;
			return !Global.AlmostEquals(a, b);
		}

		public bool IsTangentTo(Circle circle)
		{
			return circle.IsTangentTo(this);
		}

		public PointSet method_0(Triangle triangle)
		{
			if (!this.IsCoplanarTo(triangle))
			{
				return null;
			}
			PointSet pointSet = new PointSet();
			foreach (Edge current in triangle.Edges)
			{
				Plane plane = new Plane(current.StartPoint, current.method_9(), triangle.NormalVector);
				Point point = this.getInterSecttion(plane);
				if (!(point == null) && current.CollinearContains(point))
				{
					pointSet.Add(point);
				}
			}
			pointSet.RemoveMultiplePoints3d();
			return pointSet;
		}

		public PointSet method_1(Circle circle)
		{
			if (!this.IsCoplanarTo(circle))
			{
				return null;
			}
			PointSet pointSet = new PointSet();
			Vector3d vector3d = this.point_0.method_2();
			Vector3d left = vector3d + this.DirectionVector;
			Vector3d vector3d2 = circle.Center.method_2();
			Vector3d vector3d3 = left - vector3d;
			Vector3d right = vector3d - vector3d2;
			Edge edge = circle.Center.PerpendicularOn(this);
			if (Global.AlmostEquals(edge.Length, circle.Radius))
			{
				pointSet.Add(edge.EndPoint);
				return pointSet;
			}
			double num = vector3d3 * vector3d3;
			double num2 = 2.0 * (vector3d3 * right);
			double num3 = vector3d * vector3d - 2.0 * (vector3d * vector3d2) + vector3d2 * vector3d2 - circle.Radius * circle.Radius;
			double num4 = num2 * num2 - 4.0 * num * num3;
			if (Global.AlmostEquals(num2 * num2, 4.0 * num * num3))
			{
				num4 = 0.0;
			}
			if (Math.Abs(num4) < Global.AbsoluteEpsilon)
			{
				double scalar = -num2 / (2.0 * num);
				Point point = new Point(vector3d + scalar * vector3d3);
				pointSet.Add(point);
				return pointSet;
			}
			if (num4 > Global.AbsoluteEpsilon)
			{
				double scalar2 = (-num2 + Math.Sqrt(num4)) / (2.0 * num);
				double scalar3 = (-num2 - Math.Sqrt(num4)) / (2.0 * num);
				Point point2 = new Point(vector3d + scalar2 * vector3d3);
				Point point3 = new Point(vector3d + scalar3 * vector3d3);
				pointSet.Add(point2);
				if (point2 != point3)
				{
					pointSet.Add(point3);
				}
				return pointSet;
			}
			return pointSet;
		}

		public PointSet method_2(Ellipse ellipse)
		{
			if (!ellipse.IsCoplanarTo(this))
			{
				return null;
			}
			Plane plane = new Plane(this.point_0, this.vector3d_0.Normalize(), ellipse.NormalVector.Normalize());
			Edge edge = ellipse.method_5(plane);
			PointSet pointSet = new PointSet();
			if (edge == null)
			{
				return pointSet;
			}
			if (edge.StartPoint == edge.EndPoint)
			{
				pointSet.Add(edge.StartPoint);
			}
			else
			{
				pointSet.Add(edge.StartPoint);
				pointSet.Add(edge.EndPoint);
			}
			return pointSet;
		}

		public Point method_3(Line line)
		{
			if (!this.Intersects3d(line))
			{
				return null;
			}
			Vector3d vector3d = Vector3d.Cross(this.vector3d_0, line.vector3d_0);
			Vector3d vector3d2 = new Vector3d(line.point_0 - this.point_0);
			double num;
			if (Math.Abs(vector3d.Z) > Math.Abs(vector3d.X) && Math.Abs(vector3d.Z) > Math.Abs(vector3d.Y))
			{
				num = (vector3d2.X * line.vector3d_0.Y - vector3d2.Y * line.vector3d_0.X) / vector3d.Z;
			}
			else if (Math.Abs(vector3d.X) > Math.Abs(vector3d.Y))
			{
				num = (vector3d2.Y * line.vector3d_0.Z - vector3d2.Z * line.vector3d_0.Y) / vector3d.X;
			}
			else
			{
				num = (vector3d2.Z * line.vector3d_0.X - vector3d2.X * line.vector3d_0.Z) / vector3d.Y;
			}
			double x = this.point_0.X + num * this.vector3d_0.X;
			double y = this.point_0.Y + num * this.vector3d_0.Y;
			double z = this.point_0.Z + num * this.vector3d_0.Z;
			return new Point(x, y, z);
		}

		public Point method_4(Edge edge)
		{
			Point point = this.method_3(edge.ToLine());
			if (point == null)
			{
				return null;
			}
			if (edge.CollinearContains(point))
			{
				return point;
			}
			return null;
		}

		public Point getInterSecttion(Plane plane)
		{
			double num = this.point_0.X - plane.Point.X;
			double num2 = this.point_0.Y - plane.Point.Y;
			double num3 = this.point_0.Z - plane.Point.Z;
			double x = plane.NormalVector.X;
			double y = plane.NormalVector.Y;
			double z = plane.NormalVector.Z;
			double num4 = x * num + y * num2 + z * num3;
			double num5 = x * this.vector3d_0.X + y * this.vector3d_0.Y + z * this.vector3d_0.Z;
			if (this.vector3d_0.IsOrthogonalTo(new Vector3d(x, y, z)))
			{
				return null;
			}
			if (Math.Abs(num5) < 4.94065645841247E-324)
			{
				return null;
			}
			double num6 = num4 / num5;
			double x2 = this.point_0.X - num6 * this.vector3d_0.X;
			double y2 = this.point_0.Y - num6 * this.vector3d_0.Y;
			double z2 = this.point_0.Z - num6 * this.vector3d_0.Z;
			return new Point(x2, y2, z2);
		}

		public Point method_6(Triangle triangle)
		{
			Point point = this.getInterSecttion(triangle.GetPlane());
			if (point == null)
			{
				return null;
			}
			if (triangle.method_11(point))
			{
				return point;
			}
			return null;
		}

		public Point method_7(Circle circle)
		{
			Point point = this.getInterSecttion(circle.GetPlane());
			if (point == null)
			{
				return null;
			}
			if (circle.method_10(point))
			{
				return point;
			}
			return null;
		}

		public Point method_8(Ellipse ellipse)
		{
			Point point = this.getInterSecttion(ellipse.GetPlane());
			if (point == null)
			{
				return null;
			}
			if (ellipse.method_9(point))
			{
				return point;
			}
			return null;
		}

		private Point method_9(Line line_0)
		{
			if (this.IsParallelTo(line_0))
			{
				throw new ArgumentException("Can not compute base point of perpendicular: lines are parallel.");
			}
			Vector3d a = this.vector3d_0.Normalize();
			Vector3d vector3d = -1.0 * line_0.vector3d_0.Normalize();
			Vector3d b = new Vector3d(line_0.point_0 - this.point_0);
			Vector3d c = Vector3d.Cross(a, vector3d).Normalize();
			double num = Vector3d.Triple(a, vector3d, c);
			double num2 = Vector3d.Triple(a, b, c);
			if (Math.Abs(num) <= 4.94065645841247E-324)
			{
				return this.method_3(line_0);
			}
			double scalar = num2 / num;
			return line_0.point_0 - scalar * vector3d.ToPoint();
		}

		public Line Move(Vector3d displacementVector)
		{
			return new Line
			{
				point_0 = this.point_0 + displacementVector.ToPoint(),
				vector3d_0 = this.vector3d_0.DeepCopy()
			};
		}

		public Line Move(Point startPoint, Point endPoint)
		{
			Vector3d displacementVector = new Vector3d(endPoint - startPoint);
			return this.Move(displacementVector);
		}

		public static bool operator ==(Line left, Line right)
		{
            if ((object)left == (object)right)
			{
				return true;
			}
            if ((object)left != null && (object)right != null)
			{
				bool flag = left.Contains(right.Point);
				bool flag2 = left.vector3d_0.IsParallelTo(right.vector3d_0);
				return flag & flag2;
			}
			return false;
		}

		public static bool operator !=(Line left, Line right)
		{
			return !(left == right);
		}

		public Edge PerpendicularOn(Line line)
		{
			if (this.IsParallelTo(line))
			{
				throw new ArgumentException("Can not compute perpendicular: lines are parallel.");
			}
			return new Edge(line.method_9(this), this.method_9(line));
		}

		public Line ProjectParallelOn(Plane plane, Vector3d viewDirection)
		{
			if (viewDirection.IsOrthogonalTo(plane.NormalVector))
			{
				throw new ArgumentException("Projection error: view direction is parallel to projection plane!");
			}
			if (viewDirection.IsParallelTo(this.vector3d_0))
			{
				throw new ArgumentException("Projection error: view direction and line are collinear!");
			}
			Point point = this.point_0.ProjectParallelOn(plane, viewDirection);
			Point point2 = (this.point_0 + this.vector3d_0.ToPoint()).ProjectParallelOn(plane, viewDirection);
			Line line = new Line(point, point2);
			line.DirectionVector = line.DirectionVector.Normalize();
			return line;
		}

		public Edge PseudoPerpendicularOn(Edge edge)
		{
			if (edge.Length < 4.94065645841247E-324)
			{
				return edge.StartPoint.PerpendicularOn(this);
			}
			Line line = edge.ToLine();
			if (this.IsParallelTo(line))
			{
				throw new ArgumentException("Can not compute perpendicular: line and edge are parallel.");
			}
			Edge edge2 = this.PerpendicularOn(line);
			if (edge.CollinearContains(edge2.EndPoint))
			{
				return edge2;
			}
			Edge edge3 = edge.StartPoint.PerpendicularOn(this);
			Edge edge4 = edge.EndPoint.PerpendicularOn(this);
			if (edge4.Length >= edge3.Length)
			{
				return edge3;
			}
			return edge4;
		}

		public static Line RandomLine()
		{
			return new Line
			{
				point_0 = Point.RandomPoint(),
				vector3d_0 = Vector3d.RandomVector()
			};
		}

		public Line RandomOrthogonalLine()
		{
			return new Line(this.point_0.DeepCopy(), this.vector3d_0.RandomOrthonormal());
		}

		public Point RandomPointOnLine()
		{
			Vector3d vector3d = RandomGenerator.NextDouble_mr_mr() * this.DirectionVector.Normalize();
			return this.point_0 + vector3d.ToPoint();
		}

		public Line ReflectIn(Point point)
		{
			return new Line(this.point_0.ReflectIn(point), new Vector3d(-1.0 * this.vector3d_0.X, -1.0 * this.vector3d_0.Y, -1.0 * this.vector3d_0.Z));
		}

		public Line ReflectIn(Line line)
		{
			Vector3d vector = this.vector3d_0.ProjectParallelOn(line.vector3d_0);
			Vector3d directionVector = 2.0 * vector - this.vector3d_0;
			return new Line(this.point_0.ReflectIn(line), directionVector);
		}

		public Line ReflectIn(Plane plane)
		{
			Point point = this.point_0 + this.vector3d_0.ToPoint();
			return new Line(this.point_0.ReflectIn(plane), point.ReflectIn(plane));
		}

		public Line Rotate(Matrix3d rotationMatrix)
		{
			return new Line
			{
				point_0 = rotationMatrix * this.point_0,
				vector3d_0 = rotationMatrix * this.vector3d_0
			};
		}

		public Line Rotate(Point center, Matrix3d rotationMatrix)
		{
			return new Line
			{
				point_0 = rotationMatrix * (this.point_0 - center) + center,
				vector3d_0 = rotationMatrix * this.vector3d_0
			};
		}

		public Line Scale(Point center, double scaleFactor)
		{
			Line line = new Line();
			line.point_0 = this.point_0.Scale(center, scaleFactor);
			line.vector3d_0 = scaleFactor * this.vector3d_0;
			if (line.vector3d_0.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentNullException("The scale factor is too small: the direction vector of the scaled line has zero length.");
			}
			return line;
		}

		public Line Scale(Point center, double scaleX, double scaleY, double scaleZ)
		{
			Line line = new Line();
			line.point_0 = this.point_0.Scale(center, scaleX, scaleY, scaleZ);
			line.vector3d_0 = new Vector3d(scaleX * this.vector3d_0.X, scaleY * this.vector3d_0.Y, scaleZ * this.vector3d_0.Z);
			if (line.vector3d_0.Norm < 4.94065645841247E-324)
			{
				throw new ArgumentNullException("The scale factors are too small: the direction vector of the scaled line has zero length.");
			}
			return line;
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Line ",
				this.GetHashCode().ToString(),
				":",
				Environment.NewLine,
				"  Parametric form:",
				Environment.NewLine,
				"    ",
				this.Point.ToString(),
				Environment.NewLine,
				"    + r * ",
				this.DirectionVector.ToString()
			});
		}

		public Line TransformCoordinates(CoordinateSystem actualCoordinateSystem, CoordinateSystem newCoordinateSystem)
		{
			Point point = this.Point.TransformCoordinates(actualCoordinateSystem, newCoordinateSystem);
			Point point2 = this.point_0 + this.vector3d_0.ToPoint();
			point2 = point2.TransformCoordinates(actualCoordinateSystem, newCoordinateSystem);
			return new Line(point, point2);
		}

		public static void TransformCoordinates(List<Line> lines, CoordinateSystem actualCS, CoordinateSystem newCS)
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
			for (int i = 0; i < lines.Count; i++)
			{
				Point point = lines[i].point_0;
				Vector3d vector3d = lines[i].vector3d_0;
				double x = point.X;
				double y = point.Y;
				double z = point.Z;
				double x2 = vector3d.X;
				double y2 = vector3d.Y;
				double z2 = vector3d.Z;
				point.X = matrix3d2.a00 * x + matrix3d2.a01 * y + matrix3d2.a02 * z + num4;
				point.Y = matrix3d2.a10 * x + matrix3d2.a11 * y + matrix3d2.a12 * z + num5;
				point.Z = matrix3d2.a20 * x + matrix3d2.a21 * y + matrix3d2.a22 * z + num6;
				vector3d.X = matrix3d2.a00 * x2 + matrix3d2.a01 * y2 + matrix3d2.a02 * z2;
				vector3d.Y = matrix3d2.a10 * x2 + matrix3d2.a11 * y2 + matrix3d2.a12 * z2;
				vector3d.Z = matrix3d2.a20 * x2 + matrix3d2.a21 * y2 + matrix3d2.a22 * z2;
			}
		}

		public static Line X_axis()
		{
			return new Line
			{
				point_0 = new Point(0.0, 0.0, 0.0),
				vector3d_0 = new Vector3d(1.0, 0.0, 0.0)
			};
		}

		public static Line Y_axis()
		{
			return new Line
			{
				point_0 = new Point(0.0, 0.0, 0.0),
				vector3d_0 = new Vector3d(0.0, 1.0, 0.0)
			};
		}

		public static Line Z_axis()
		{
			return new Line
			{
				point_0 = new Point(0.0, 0.0, 0.0),
				vector3d_0 = new Vector3d(0.0, 0.0, 1.0)
			};
		}

		public CADData CADData
		{
			get
			{
				return this.caddata_0;
			}
			set
			{
				this.caddata_0 = value;
			}
		}

		public Vector3d DirectionVector
		{
			get
			{
				return this.vector3d_0;
			}
			set
			{
				this.vector3d_0 = value;
				if (this.vector3d_0.Norm <= 4.94065645841247E-324)
				{
					throw new ArgumentException("Invalid line direction vector: vector has zero norm.");
				}
			}
		}

		public Point Point
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

		private CADData caddata_0;

		private Point point_0;

		private Vector3d vector3d_0;
	}
}
