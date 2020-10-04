using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ngeometry.VectorGeometry
{
	//[LicenseProvider(typeof(Class46))]
	public class Scene
	{
		public Scene()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Scene));
			this.double_0 = 1.0;
			this.int_0 = 2;
			this.int_1 = 1;
			this.double_2 = -1.0;
			this.vector3d_0 = new Vector3d(0.0, 0.0, 1.0);
			this.list_0 = new List<Point>();
			this.list_1 = new List<Edge>();
			this.list_2 = new List<Plane>();
			this.list_3 = new List<Triangle>();
			this.list_4 = new List<Circle>();
			this.list_5 = new List<Ellipse>();
			this.list_6 = new List<Arc>();
			this.list_7 = new List<Scene.Text>();
			//base..ctor();
			if (this.double_2 < 0.0)
			{
				Size primaryMonitorSize = SystemInformation.PrimaryMonitorSize;
				this.double_2 = (double)primaryMonitorSize.Width / (double)primaryMonitorSize.Height / 0.7;
			}
		}

		public void Add(Scene scene)
		{
			this.list_0.AddRange(scene.list_0);
			this.list_1.AddRange(scene.list_1);
			this.list_2.AddRange(scene.list_2);
			this.list_3.AddRange(scene.list_3);
			this.list_4.AddRange(scene.list_4);
			this.list_5.AddRange(scene.list_5);
			this.list_7.AddRange(scene.list_7);
		}

		public void AddRange(PointSet points, CADData cadData)
		{
			for (int i = 0; i < points.Count; i++)
			{
				points[i].CADData = cadData;
				this.list_0.Add(points[i]);
			}
		}

		public void AddRange(List<Point> points, CADData cadData)
		{
			for (int i = 0; i < points.Count; i++)
			{
				points[i].CADData = cadData;
				this.list_0.Add(points[i]);
			}
		}

		public void AddRange(List<Edge> edges, CADData cadData)
		{
			for (int i = 0; i < edges.Count; i++)
			{
				edges[i].CADData = cadData;
				this.list_1.Add(edges[i]);
			}
		}

		public void AddRange(List<Plane> planes, CADData cadData)
		{
			for (int i = 0; i < planes.Count; i++)
			{
				planes[i].CADData = cadData;
				this.list_2.Add(planes[i]);
			}
		}

		public void AddRange(List<Triangle> triangles, CADData cadData)
		{
			for (int i = 0; i < triangles.Count; i++)
			{
				triangles[i].CADData = cadData;
				this.list_3.Add(triangles[i]);
			}
		}

		public void AddRange(List<Circle> circles, CADData cadData)
		{
			for (int i = 0; i < circles.Count; i++)
			{
				circles[i].CADData = cadData;
				this.list_4.Add(circles[i]);
			}
		}

		public void AddRange(List<Ellipse> ellipses, CADData cadData)
		{
			for (int i = 0; i < ellipses.Count; i++)
			{
				ellipses[i].CADData = cadData;
				this.list_5.Add(ellipses[i]);
			}
		}

		public void AddRange(List<Arc> arcs, CADData cadData)
		{
			for (int i = 0; i < arcs.Count; i++)
			{
				arcs[i].CADData = cadData;
				this.list_6.Add(arcs[i]);
			}
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}

		public double[] ExtentsXY()
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				pointSet.Add(this.list_0[i]);
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				pointSet.Add(this.list_1[j].StartPoint);
				pointSet.Add(this.list_1[j].EndPoint);
			}
			for (int k = 0; k < this.list_2.Count; k++)
			{
				Plane plane = this.list_2[k];
				Vector3d directionVector = plane.DirectionVector1;
				directionVector.Norm = plane.CADData.double_0 / 2.0;
				Vector3d directionVector2 = plane.DirectionVector2;
				directionVector2.Norm = plane.CADData.double_0 / 2.0;
				pointSet.Add(plane.Point + new Point(directionVector + directionVector2));
				pointSet.Add(plane.Point + new Point(directionVector - directionVector2));
				pointSet.Add(plane.Point - new Point(directionVector + directionVector2));
				pointSet.Add(plane.Point - new Point(directionVector - directionVector2));
			}
			for (int l = 0; l < this.list_3.Count; l++)
			{
				pointSet.Add(this.list_3[l].Vertex1);
				pointSet.Add(this.list_3[l].Vertex2);
				pointSet.Add(this.list_3[l].Vertex3);
			}
			for (int m = 0; m < this.list_4.Count; m++)
			{
				double[] array = this.list_4[m].ToEllipse().ExtentsXY();
				pointSet.Add(new Point(array[0], array[2], 0.0));
				pointSet.Add(new Point(array[1], array[2], 0.0));
				pointSet.Add(new Point(array[1], array[3], 0.0));
				pointSet.Add(new Point(array[0], array[3], 0.0));
			}
			for (int n = 0; n < this.list_5.Count; n++)
			{
				double[] array2 = this.list_5[n].ExtentsXY();
				pointSet.Add(new Point(array2[0], array2[2], 0.0));
				pointSet.Add(new Point(array2[1], array2[2], 0.0));
				pointSet.Add(new Point(array2[1], array2[3], 0.0));
				pointSet.Add(new Point(array2[0], array2[3], 0.0));
			}
			for (int num = 0; num < this.list_6.Count; num++)
			{
				double[] array3 = this.list_6[num].ExtentsXY();
				pointSet.Add(new Point(array3[0], array3[2], 0.0));
				pointSet.Add(new Point(array3[1], array3[2], 0.0));
				pointSet.Add(new Point(array3[1], array3[3], 0.0));
				pointSet.Add(new Point(array3[0], array3[3], 0.0));
			}
			for (int num2 = 0; num2 < this.list_7.Count; num2++)
			{
				pointSet.Add(this.list_7[num2].InsertionPoint);
			}
			return pointSet.ExtentsXY();
		}

		~Scene()
		{
			this.method_0(false);
		}

		public List<Layer> GetLayers()
		{
			List<Layer> list = new List<Layer>();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				list.Add(this.list_0[i].CADData.Layer);
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				list.Add(this.list_1[j].CADData.Layer);
			}
			for (int k = 0; k < this.list_2.Count; k++)
			{
				list.Add(this.list_2[k].CADData.Layer);
			}
			for (int l = 0; l < this.list_3.Count; l++)
			{
				list.Add(this.list_3[l].CADData.Layer);
			}
			for (int m = 0; m < this.list_4.Count; m++)
			{
				list.Add(this.list_4[m].CADData.Layer);
			}
			for (int n = 0; n < this.list_5.Count; n++)
			{
				list.Add(this.list_5[n].CADData.Layer);
			}
			for (int num = 0; num < this.list_6.Count; num++)
			{
				list.Add(this.list_6[num].CADData.Layer);
			}
			for (int num2 = 0; num2 < this.list_7.Count; num2++)
			{
				list.Add(this.list_7[num2].Layer);
			}
			list.Sort();
			for (int num3 = list.Count - 2; num3 >= 0; num3--)
			{
				if (list[num3 + 1].Name == list[num3].Name)
				{
					if (list[num3 + 1].ColorIndex != list[num3].ColorIndex || list[num3 + 1].LineType != list[num3].LineType)
					{
						throw new InvalidOperationException("Different layer properties have been assigned to one layer!");
					}
					list.RemoveAt(num3 + 1);
				}
			}
			return list;
		}

		private void method_0(bool bool_2)
		{
			if (this.bool_1)
			{
				return;
			}
			if (bool_2)
			{
				this.list_0 = null;
				this.list_1 = null;
				this.list_2 = null;
				this.list_3 = null;
				this.list_4 = null;
				this.list_5 = null;
			}
			this.list_3 = null;
			this.list_1 = null;
			this.bool_1 = true;
		}

		private StringBuilder method_1()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("SECTION");
			stringBuilder.AppendLine("2");
			stringBuilder.AppendLine("HEADER");
			stringBuilder.AppendLine("9");
			stringBuilder.AppendLine("$ACADVER");
			stringBuilder.AppendLine("1");
			stringBuilder.AppendLine("AC1009");
			stringBuilder.AppendLine("  9");
			stringBuilder.AppendLine("$CELTYPE");
			stringBuilder.AppendLine("  6");
			stringBuilder.AppendLine("YLAYER");
			stringBuilder.AppendLine(" 9");
			stringBuilder.AppendLine("$PDMODE");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine(this.int_0.ToString());
			stringBuilder.AppendLine("  9");
			stringBuilder.AppendLine("$PDSIZE");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine(this.double_1.ToString());
			stringBuilder.AppendLine("  9");
			stringBuilder.AppendLine("$LTSCALE");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine(this.double_0.ToString());
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("ENDSEC");
			return stringBuilder;
		}

		private StringBuilder method_10(Arc arc_0)
		{
			if (arc_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (arc_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			Point point = arc_0.Center;
			Vector3d normalVector = arc_0.NormalVector;
			CoordinateSystem actualCS = CoordinateSystem.Global();
			Vector3d vector3d = new Vector3d();
			Vector3d e = new Vector3d();
			if (Math.Abs(normalVector.X) <= 0.0 & Math.Abs(normalVector.Y) <= 0.0)
			{
				vector3d = Vector3d.Cross(new Vector3d(0.0, 1.0, 0.0), normalVector);
			}
			else
			{
				vector3d = Vector3d.Cross(new Vector3d(0.0, 0.0, 1.0), normalVector);
			}
			vector3d = vector3d.Normalize();
			e = Vector3d.Cross(normalVector, vector3d).Normalize();
			CoordinateSystem coordinateSystem = new CoordinateSystem(new Point(0.0, 0.0, 0.0), vector3d, e, normalVector.Normalize());
			coordinateSystem.Orthonormalize();
			point = point.TransformCoordinates(actualCS, coordinateSystem);
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("ARC");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbArc");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(arc_0.CADData.Layer.Name);
			if (arc_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(arc_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(point.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(point.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(point.Z.ToString());
			stringBuilder.AppendLine("40");
			stringBuilder.AppendLine(arc_0.Radius().ToString());
			stringBuilder.AppendLine("50");
			stringBuilder.AppendLine((arc_0.method_2() * 180.0 / 3.1415926535897931).ToString());
			stringBuilder.AppendLine("51");
			stringBuilder.AppendLine((arc_0.method_3() * 180.0 / 3.1415926535897931).ToString());
			stringBuilder.AppendLine("210");
			stringBuilder.AppendLine(arc_0.NormalVector.X.ToString());
			stringBuilder.AppendLine("220");
			stringBuilder.AppendLine(arc_0.NormalVector.Y.ToString());
			stringBuilder.AppendLine("230");
			stringBuilder.AppendLine(arc_0.NormalVector.Z.ToString());
			if (this.bool_0)
			{
				stringBuilder.Append(this.method_14(arc_0.Center, arc_0.NormalVector, arc_0.CADData.Layer, arc_0.CADData.ColorIndex).ToString());
			}
			return stringBuilder;
		}

		private StringBuilder method_11(Triangle triangle_0)
		{
			if (triangle_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (triangle_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("3DFACE");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbFace");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(triangle_0.CADData.Layer.Name);
			if (triangle_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(triangle_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(triangle_0.Vertex1.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(triangle_0.Vertex1.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(triangle_0.Vertex1.Z.ToString());
			stringBuilder.AppendLine("11");
			stringBuilder.AppendLine(triangle_0.Vertex2.X.ToString());
			stringBuilder.AppendLine("21");
			stringBuilder.AppendLine(triangle_0.Vertex2.Y.ToString());
			stringBuilder.AppendLine("31");
			stringBuilder.AppendLine(triangle_0.Vertex2.Z.ToString());
			stringBuilder.AppendLine("12");
			stringBuilder.AppendLine(triangle_0.Vertex3.X.ToString());
			stringBuilder.AppendLine("22");
			stringBuilder.AppendLine(triangle_0.Vertex3.Y.ToString());
			stringBuilder.AppendLine("32");
			stringBuilder.AppendLine(triangle_0.Vertex3.Z.ToString());
			stringBuilder.AppendLine("13");
			stringBuilder.AppendLine(triangle_0.Vertex3.X.ToString());
			stringBuilder.AppendLine("23");
			stringBuilder.AppendLine(triangle_0.Vertex3.Y.ToString());
			stringBuilder.AppendLine("33");
			stringBuilder.AppendLine(triangle_0.Vertex3.Z.ToString());
			if (this.bool_0)
			{
				stringBuilder.Append(this.method_14(triangle_0.Center, triangle_0.NormalVector, triangle_0.CADData.Layer, triangle_0.CADData.ColorIndex).ToString());
			}
			return stringBuilder;
		}

		private StringBuilder method_12(Plane plane_0)
		{
			if (plane_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (plane_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			Vector3d directionVector = plane_0.DirectionVector1;
			directionVector.Norm = plane_0.CADData.double_0 / 2.0;
			Vector3d directionVector2 = plane_0.DirectionVector2;
			directionVector2.Norm = plane_0.CADData.double_0 / 2.0;
			Point point = plane_0.Point + new Point(directionVector + directionVector2);
			Point point2 = plane_0.Point + new Point(directionVector - directionVector2);
			Point point3 = plane_0.Point - new Point(directionVector + directionVector2);
			Point point4 = plane_0.Point - new Point(directionVector - directionVector2);
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("3DFACE");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbFace");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(plane_0.CADData.Layer.Name);
			if (plane_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(plane_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(point.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(point.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(point.Z.ToString());
			stringBuilder.AppendLine("11");
			stringBuilder.AppendLine(point2.X.ToString());
			stringBuilder.AppendLine("21");
			stringBuilder.AppendLine(point2.Y.ToString());
			stringBuilder.AppendLine("31");
			stringBuilder.AppendLine(point2.Z.ToString());
			stringBuilder.AppendLine("12");
			stringBuilder.AppendLine(point3.X.ToString());
			stringBuilder.AppendLine("22");
			stringBuilder.AppendLine(point3.Y.ToString());
			stringBuilder.AppendLine("32");
			stringBuilder.AppendLine(point3.Z.ToString());
			stringBuilder.AppendLine("13");
			stringBuilder.AppendLine(point4.X.ToString());
			stringBuilder.AppendLine("23");
			stringBuilder.AppendLine(point4.Y.ToString());
			stringBuilder.AppendLine("33");
			stringBuilder.AppendLine(point4.Z.ToString());
			if (this.bool_0)
			{
				stringBuilder.Append(this.method_14(plane_0.Point, plane_0.NormalVector, plane_0.CADData.Layer, plane_0.CADData.ColorIndex).ToString());
				stringBuilder.Append(this.method_14(plane_0.Point, plane_0.DirectionVector1, plane_0.CADData.Layer, plane_0.CADData.ColorIndex).ToString());
				stringBuilder.Append(this.method_14(plane_0.Point, plane_0.DirectionVector2, plane_0.CADData.Layer, plane_0.CADData.ColorIndex).ToString());
			}
			return stringBuilder;
		}

		private StringBuilder method_13(Layer layer_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("LAYER");
			stringBuilder.AppendLine("5");
			stringBuilder.AppendLine("3001");
			stringBuilder.AppendLine("2");
			stringBuilder.AppendLine(layer_0.Name);
			stringBuilder.AppendLine("70");
			if (layer_0.IsFrozen)
			{
				stringBuilder.AppendLine("1");
			}
			else
			{
				stringBuilder.AppendLine("0");
			}
			stringBuilder.AppendLine("62");
			stringBuilder.AppendLine(layer_0.ColorIndex.ToString());
			stringBuilder.AppendLine("6");
			stringBuilder.AppendLine(layer_0.LineType.ToString());
			return stringBuilder;
		}

		private StringBuilder method_14(Point point_0, Vector3d vector3d_1, Layer layer_0, short short_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Edge edge = new Edge(point_0, point_0 + vector3d_1.ToPoint());
			Edge edge2 = new Edge(point_0, point_0 + vector3d_1.ToPoint());
			edge2 = edge2.Scale(edge2.EndPoint, 0.1);
			Matrix3d rotationMatrix = Matrix3d.RotationArbitraryAxis(edge2.method_9().RandomOrthonormal(), 0.78539816339744828);
			edge2 = edge2.Rotate(edge2.EndPoint, rotationMatrix);
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("LINE");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbLine");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(layer_0.Name);
			if (short_0 != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(short_0.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(edge.StartPoint.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(edge.StartPoint.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(edge.StartPoint.Z.ToString());
			stringBuilder.AppendLine("11");
			stringBuilder.AppendLine(edge.EndPoint.X.ToString());
			stringBuilder.AppendLine("21");
			stringBuilder.AppendLine(edge.EndPoint.Y.ToString());
			stringBuilder.AppendLine("31");
			stringBuilder.AppendLine(edge.EndPoint.Z.ToString());
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("LINE");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbLine");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(layer_0.Name);
			if (short_0 != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(short_0.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(edge2.StartPoint.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(edge2.StartPoint.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(edge2.StartPoint.Z.ToString());
			stringBuilder.AppendLine("11");
			stringBuilder.AppendLine(edge2.EndPoint.X.ToString());
			stringBuilder.AppendLine("21");
			stringBuilder.AppendLine(edge2.EndPoint.Y.ToString());
			stringBuilder.AppendLine("31");
			stringBuilder.AppendLine(edge2.EndPoint.Z.ToString());
			return stringBuilder;
		}

		private StringBuilder method_15(Scene.Text text_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			if (text_0.Backwards)
			{
				num += 2;
			}
			if (text_0.UpsideDown)
			{
				num += 4;
			}
			int num2 = 0;
			if (text_0.HorizontalAlignment == Scene.Text.HorizontalJustification.Left)
			{
				num2 = 0;
			}
			if (text_0.HorizontalAlignment == Scene.Text.HorizontalJustification.Center)
			{
				num2 = 1;
			}
			if (text_0.HorizontalAlignment == Scene.Text.HorizontalJustification.Right)
			{
				num2 = 2;
			}
			int num3 = 0;
			if (text_0.VerticalAlignment == Scene.Text.VerticalJustification.Default)
			{
				num3 = 0;
			}
			if (text_0.VerticalAlignment == Scene.Text.VerticalJustification.Baseline)
			{
				num3 = 0;
			}
			if (text_0.VerticalAlignment == Scene.Text.VerticalJustification.Bottom)
			{
				num3 = 1;
			}
			if (text_0.VerticalAlignment == Scene.Text.VerticalJustification.Middle)
			{
				num3 = 2;
			}
			if (text_0.VerticalAlignment == Scene.Text.VerticalJustification.Top)
			{
				num3 = 3;
			}
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("TEXT");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbText");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(text_0.Layer.Name);
			if ((short)text_0.Color != text_0.Layer.ColorIndex)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(text_0.Color.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(text_0.InsertionPoint.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(text_0.InsertionPoint.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(text_0.InsertionPoint.Z.ToString());
			stringBuilder.AppendLine("40");
			stringBuilder.AppendLine(text_0.Height.ToString());
			stringBuilder.AppendLine("1");
			stringBuilder.AppendLine(text_0.Value);
			stringBuilder.AppendLine("50");
			stringBuilder.AppendLine(text_0.Rotation.ToString());
			stringBuilder.AppendLine("71");
			stringBuilder.AppendLine(num.ToString());
			stringBuilder.AppendLine("72");
			stringBuilder.AppendLine(num2.ToString());
			stringBuilder.AppendLine("210");
			stringBuilder.AppendLine(this.vector3d_0.X.ToString());
			stringBuilder.AppendLine("220");
			stringBuilder.AppendLine(this.vector3d_0.Y.ToString());
			stringBuilder.AppendLine("230");
			stringBuilder.AppendLine(this.vector3d_0.Z.ToString());
			stringBuilder.AppendLine("73");
			stringBuilder.AppendLine(num3.ToString());
			return stringBuilder;
		}

		private CoordinateSystem method_16(Vector3d vector3d_1)
		{
			Vector3d vector3d = vector3d_1.Normalize();
			Vector3d a = new Vector3d(0.0, 1.0, 0.0);
			Vector3d a2 = new Vector3d(0.0, 0.0, 1.0);
			Vector3d vector3d2;
			if (Math.Abs(vector3d.X) < 0.015625 && Math.Abs(vector3d.Y) < 0.015625)
			{
				vector3d2 = Vector3d.Cross(a, vector3d).Normalize();
			}
			else
			{
				vector3d2 = Vector3d.Cross(a2, vector3d).Normalize();
			}
			Vector3d value = Vector3d.Cross(vector3d, vector3d2).Normalize();
			CoordinateSystem coordinateSystem = new CoordinateSystem();
			coordinateSystem.Origin = new Point(0.0, 0.0, 0.0);
			coordinateSystem.BasisVector[0] = vector3d2;
			coordinateSystem.BasisVector[1] = value;
			coordinateSystem.BasisVector[2] = vector3d;
			return coordinateSystem;
		}

		private StringBuilder method_2(List<Layer> layers)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("SECTION");
			stringBuilder.AppendLine("2");
			stringBuilder.AppendLine("TABLES");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("TABLE");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("LTYPE");
			stringBuilder.AppendLine("5");
			stringBuilder.AppendLine("2001");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbLinetypeTableRecord");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("     4");
			stringBuilder.Append(this.method_3().ToString());
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("ENDTAB");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("TABLE");
			stringBuilder.AppendLine(" 2");
			stringBuilder.AppendLine("LAYER");
			stringBuilder.AppendLine("5");
			stringBuilder.AppendLine("2002");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbLayerTableRecord");
			stringBuilder.AppendLine("70");
			stringBuilder.AppendLine(layers.Count.ToString());
			foreach (Layer current in layers)
			{
				stringBuilder.Append(this.method_13(current).ToString());
			}
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("ENDTAB");
			stringBuilder.Append(this.method_4().ToString());
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("ENDTAB");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("ENDSEC");
			return stringBuilder;
		}

		private StringBuilder method_3()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("LTYPE");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("CONTINUOUS");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("     0");
			stringBuilder.AppendLine("  3");
			stringBuilder.AppendLine("Solid line");
			stringBuilder.AppendLine(" 72");
			stringBuilder.AppendLine("    65");
			stringBuilder.AppendLine(" 73");
			stringBuilder.AppendLine("     0");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("LTYPE");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("CENTER");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("     0");
			stringBuilder.AppendLine("  3");
			stringBuilder.AppendLine("____ _ ____ _ ____ _ ____ _ ____ _ ____ _ ____ ");
			stringBuilder.AppendLine(" 72");
			stringBuilder.AppendLine("    65");
			stringBuilder.AppendLine(" 73");
			stringBuilder.AppendLine("     4");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine("2.0");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("1.25");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("-0.25");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("0.25");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("-0.25");
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("LTYPE");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("DASHDOT");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("     0");
			stringBuilder.AppendLine("  3");
			stringBuilder.AppendLine("__ . __ . __ . __ . __ . __ . __ . __ . __ . __");
			stringBuilder.AppendLine(" 72");
			stringBuilder.AppendLine("    65");
			stringBuilder.AppendLine(" 73");
			stringBuilder.AppendLine("     4");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine("1.0");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("0.5");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("-0.25");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("-0.25");
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("LTYPE");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("HIDDEN");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("     0");
			stringBuilder.AppendLine("  3");
			stringBuilder.AppendLine("__ __ __ __ __ __ __ __ __ __ __ __ __ __ __ __");
			stringBuilder.AppendLine(" 72");
			stringBuilder.AppendLine("    65");
			stringBuilder.AppendLine(" 73");
			stringBuilder.AppendLine("     2");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine("0.375");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("0.25");
			stringBuilder.AppendLine(" 49");
			stringBuilder.AppendLine("-0.125");
			return stringBuilder;
		}

		private StringBuilder method_4()
		{
			StringBuilder stringBuilder = new StringBuilder();
			double[] array = this.ExtentsXY();
			double x = 0.5 * (array[0] + array[1]);
			double y = 0.5 * (array[2] + array[3]);
			double scaleFactor = 1.05;
			double x2 = new Point(array[0], array[2], 0.0).Scale(new Point(x, y, 0.0), scaleFactor).X;
			double x3 = new Point(array[1], array[2], 0.0).Scale(new Point(x, y, 0.0), scaleFactor).X;
			double y2 = new Point(array[0], array[2], 0.0).Scale(new Point(x, y, 0.0), scaleFactor).Y;
			double y3 = new Point(array[0], array[3], 0.0).Scale(new Point(x, y, 0.0), scaleFactor).Y;
			array[0] = x2;
			array[1] = x3;
			array[2] = y2;
			array[3] = y3;
			double num = array[1] - array[0];
			double num2 = array[3] - array[2];
			double num3 = num2;
			if (num > this.double_2 * num2)
			{
				num3 = num / this.double_2;
			}
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("TABLE");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("VPORT");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine("VPORT");
			stringBuilder.AppendLine("  2");
			stringBuilder.AppendLine("*ACTIVE");
			stringBuilder.AppendLine(" 70");
			stringBuilder.AppendLine("  0");
			stringBuilder.AppendLine(" 10");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 20");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 11");
			stringBuilder.AppendLine("1.0");
			stringBuilder.AppendLine(" 21");
			stringBuilder.AppendLine("1.0");
			stringBuilder.AppendLine(" 12");
			stringBuilder.AppendLine(x.ToString());
			stringBuilder.AppendLine(" 22");
			stringBuilder.AppendLine(y.ToString());
			stringBuilder.AppendLine(" 13");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 23");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 14");
			stringBuilder.AppendLine("1.0");
			stringBuilder.AppendLine(" 24");
			stringBuilder.AppendLine("1.0");
			stringBuilder.AppendLine(" 15");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 25");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 16");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 26");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 36");
			stringBuilder.AppendLine("1.0");
			stringBuilder.AppendLine(" 17");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 27");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 37");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 40");
			stringBuilder.AppendLine(num3.ToString());
			stringBuilder.AppendLine(" 41");
			stringBuilder.AppendLine(this.double_2.ToString());
			stringBuilder.AppendLine(" 42");
			stringBuilder.AppendLine("50.0");
			stringBuilder.AppendLine(" 43");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 44");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 50");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 51");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine(" 71");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine(" 72");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine(" 73");
			stringBuilder.AppendLine("1");
			stringBuilder.AppendLine(" 74");
			stringBuilder.AppendLine(this.int_1.ToString());
			stringBuilder.AppendLine(" 75");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine(" 76");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine(" 77");
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine(" 78");
			stringBuilder.AppendLine("0");
			return stringBuilder;
		}

		private StringBuilder method_5()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("SECTION");
			stringBuilder.AppendLine("2");
			stringBuilder.AppendLine("ENTITIES");
			for (int i = 0; i < this.list_0.Count; i++)
			{
				if (this.list_0[i] != null)
				{
					stringBuilder.Append(this.method_6(this.list_0[i]).ToString());
				}
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				if (this.list_1[j] != null)
				{
					stringBuilder.Append(this.method_7(this.list_1[j]).ToString());
				}
			}
			for (int k = 0; k < this.list_4.Count; k++)
			{
				if (this.list_4[k] != null)
				{
					stringBuilder.Append(this.method_8(this.list_4[k]).ToString());
				}
			}
			for (int l = 0; l < this.list_5.Count; l++)
			{
				if (this.list_5[l] != null)
				{
					stringBuilder.Append(this.method_9(this.list_5[l]).ToString());
				}
			}
			for (int m = 0; m < this.list_6.Count; m++)
			{
				if (this.list_6[m] != null)
				{
					stringBuilder.Append(this.method_10(this.list_6[m]).ToString());
				}
			}
			for (int n = 0; n < this.list_3.Count; n++)
			{
				if (this.list_3[n] != null)
				{
					stringBuilder.Append(this.method_11(this.list_3[n]).ToString());
				}
			}
			for (int num = 0; num < this.list_2.Count; num++)
			{
				if (this.list_2[num] != null)
				{
					stringBuilder.Append(this.method_12(this.list_2[num]).ToString());
				}
			}
			for (int num2 = 0; num2 < this.list_7.Count; num2++)
			{
				if (this.list_7[num2] != null)
				{
					stringBuilder.Append(this.method_15(this.list_7[num2]).ToString());
				}
			}
			return stringBuilder;
		}

		private StringBuilder method_6(Point point_0)
		{
			if (point_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (point_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("POINT");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbPoint");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(point_0.CADData.Layer.Name);
			if (point_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(point_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(point_0.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(point_0.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(point_0.Z.ToString());
			stringBuilder.AppendLine("210");
			stringBuilder.AppendLine(this.vector3d_0.X.ToString());
			stringBuilder.AppendLine("220");
			stringBuilder.AppendLine(this.vector3d_0.Y.ToString());
			stringBuilder.AppendLine("230");
			stringBuilder.AppendLine(this.vector3d_0.Z.ToString());
			return stringBuilder;
		}

		private StringBuilder method_7(Edge edge_0)
		{
			if (edge_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (edge_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("LINE");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbLine");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(edge_0.CADData.Layer.Name);
			if (edge_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(edge_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(edge_0.StartPoint.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(edge_0.StartPoint.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(edge_0.StartPoint.Z.ToString());
			stringBuilder.AppendLine("11");
			stringBuilder.AppendLine(edge_0.EndPoint.X.ToString());
			stringBuilder.AppendLine("21");
			stringBuilder.AppendLine(edge_0.EndPoint.Y.ToString());
			stringBuilder.AppendLine("31");
			stringBuilder.AppendLine(edge_0.EndPoint.Z.ToString());
			if (this.bool_0)
			{
				stringBuilder.Append(this.method_14(edge_0.StartPoint, edge_0.method_9(), edge_0.CADData.Layer, edge_0.CADData.ColorIndex).ToString());
			}
			return stringBuilder;
		}

		private StringBuilder method_8(Circle circle_0)
		{
			if (circle_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (circle_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			Point point = circle_0.Center;
			Vector3d normalVector = circle_0.NormalVector;
			CoordinateSystem actualCS = CoordinateSystem.Global();
			Vector3d vector3d = new Vector3d();
			Vector3d e = new Vector3d();
			if (Math.Abs(normalVector.X) <= 0.0 & Math.Abs(normalVector.Y) <= 0.0)
			{
				vector3d = Vector3d.Cross(new Vector3d(0.0, 1.0, 0.0), normalVector);
			}
			else
			{
				vector3d = Vector3d.Cross(new Vector3d(0.0, 0.0, 1.0), normalVector);
			}
			vector3d = vector3d.Normalize();
			e = Vector3d.Cross(normalVector, vector3d).Normalize();
			CoordinateSystem coordinateSystem = new CoordinateSystem(new Point(0.0, 0.0, 0.0), vector3d, e, normalVector.Normalize());
			coordinateSystem.Orthonormalize();
			point = point.TransformCoordinates(actualCS, coordinateSystem);
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("CIRCLE");
			stringBuilder.AppendLine("100");
			stringBuilder.AppendLine("AcDbCircle");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(circle_0.CADData.Layer.Name);
			if (circle_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(circle_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine(point.X.ToString());
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine(point.Y.ToString());
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine(point.Z.ToString());
			stringBuilder.AppendLine("40");
			stringBuilder.AppendLine(circle_0.Radius.ToString());
			stringBuilder.AppendLine("210");
			stringBuilder.AppendLine(circle_0.NormalVector.X.ToString());
			stringBuilder.AppendLine("220");
			stringBuilder.AppendLine(circle_0.NormalVector.Y.ToString());
			stringBuilder.AppendLine("230");
			stringBuilder.AppendLine(circle_0.NormalVector.Z.ToString());
			if (this.bool_0)
			{
				stringBuilder.Append(this.method_14(circle_0.Center, circle_0.NormalVector, circle_0.CADData.Layer, circle_0.CADData.ColorIndex).ToString());
			}
			return stringBuilder;
		}

		private StringBuilder method_9(Ellipse ellipse_0)
		{
			if (ellipse_0.CADData == null)
			{
				throw new InvalidOperationException("CAD data not set.");
			}
			if (ellipse_0.CADData.Layer == null)
			{
				throw new InvalidOperationException("Layer data not set.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			double num = 128.0;
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("POLYLINE");
			stringBuilder.AppendLine("8");
			stringBuilder.AppendLine(ellipse_0.CADData.Layer.Name);
			if (ellipse_0.CADData.ColorIndex != 256)
			{
				stringBuilder.AppendLine("62");
				stringBuilder.AppendLine(ellipse_0.CADData.ColorIndex.ToString());
			}
			stringBuilder.AppendLine("66");
			stringBuilder.AppendLine("1");
			stringBuilder.AppendLine("10");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine("20");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine("30");
			stringBuilder.AppendLine("0.0");
			stringBuilder.AppendLine("70");
			stringBuilder.AppendLine("8");
			int num2 = 0;
			while ((double)num2 <= num)
			{
				stringBuilder.AppendLine("0");
				stringBuilder.AppendLine("VERTEX");
				stringBuilder.AppendLine("8");
				stringBuilder.AppendLine(ellipse_0.CADData.Layer.Name);
				double norm = ellipse_0.SemimajorAxisVector.Norm;
				double norm2 = ellipse_0.SemiminorAxisVector.Norm;
				double tetha = 6.2831853071795862 * (double)num2 / num + (norm2 / (2.0 * norm) - 0.5) * Math.Sin(12.566370614359172 * (double)num2 / num);
				Point pointAtParameter = ellipse_0.GetPointAtParameter(tetha);
				stringBuilder.AppendLine("10");
				stringBuilder.AppendLine(pointAtParameter.X.ToString());
				stringBuilder.AppendLine("20");
				stringBuilder.AppendLine(pointAtParameter.Y.ToString());
				stringBuilder.AppendLine("30");
				stringBuilder.AppendLine(pointAtParameter.Z.ToString());
				stringBuilder.AppendLine("70");
				stringBuilder.AppendLine(" 32");
				num2++;
			}
			stringBuilder.AppendLine("0");
			stringBuilder.AppendLine("SEQEND");
			if (this.bool_0)
			{
				stringBuilder.Append(this.method_14(ellipse_0.Center, ellipse_0.SemimajorAxisVector, ellipse_0.CADData.Layer, ellipse_0.CADData.ColorIndex).ToString());
				stringBuilder.Append(this.method_14(ellipse_0.Center, ellipse_0.SemiminorAxisVector, ellipse_0.CADData.Layer, ellipse_0.CADData.ColorIndex).ToString());
				stringBuilder.Append(this.method_14(ellipse_0.Center, ellipse_0.NormalVector, ellipse_0.CADData.Layer, ellipse_0.CADData.ColorIndex).ToString());
			}
			return stringBuilder;
		}

		public void Move(Vector3d displacementVector)
		{
			for (int i = 0; i < this.list_0.Count; i++)
			{
				this.list_0[i] = this.list_0[i].Move(displacementVector);
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				this.list_1[j] = this.list_1[j].Move(displacementVector);
			}
			for (int k = 0; k < this.list_2.Count; k++)
			{
				this.list_2[k] = this.list_2[k].Move(displacementVector);
			}
			for (int l = 0; l < this.list_3.Count; l++)
			{
				this.list_3[l] = this.list_3[l].Move(displacementVector);
			}
			for (int m = 0; m < this.list_4.Count; m++)
			{
				this.list_4[m] = this.list_4[m].Move(displacementVector);
			}
			for (int n = 0; n < this.list_5.Count; n++)
			{
				this.list_5[n] = this.list_5[n].Move(displacementVector);
			}
			for (int num = 0; num < this.list_6.Count; num++)
			{
				this.list_6[num] = this.list_6[num].Move(displacementVector);
			}
			for (int num2 = 0; num2 < this.list_7.Count; num2++)
			{
				this.list_7[num2].Move(displacementVector);
			}
		}

		public void SetPlaneEdgeLength(double edgeLength)
		{
			for (int i = 0; i < this.list_2.Count; i++)
			{
				this.list_2[i].CADData.double_0 = edgeLength;
			}
		}

		public void WriteDxf(string fileName)
		{
			List<Layer> layers = this.GetLayers();
			using (StreamWriter streamWriter = new StreamWriter(fileName))
			{
				streamWriter.Write(this.method_1());
				streamWriter.Write(this.method_2(layers).ToString());
				streamWriter.Write(this.method_5());
				streamWriter.WriteLine("0");
				streamWriter.WriteLine("ENDSEC");
				streamWriter.WriteLine("0");
				streamWriter.WriteLine("EOF");
				streamWriter.Flush();
				streamWriter.Close();
			}
		}

		public List<Arc> Arcs
		{
			get
			{
				return this.list_6;
			}
			set
			{
				this.list_6 = value;
			}
		}

		public double AspectRatio
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
					Size primaryMonitorSize = SystemInformation.PrimaryMonitorSize;
					this.double_2 = (double)primaryMonitorSize.Width / (double)primaryMonitorSize.Height / 0.7;
				}
			}
		}

		public List<Circle> Circles
		{
			get
			{
				return this.list_4;
			}
			set
			{
				this.list_4 = value;
			}
		}

		public bool DrawVectors
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

		public List<Edge> Edges
		{
			get
			{
				return this.list_1;
			}
			set
			{
				this.list_1 = value;
			}
		}

		public List<Ellipse> Ellipses
		{
			get
			{
				return this.list_5;
			}
			set
			{
				this.list_5 = value;
			}
		}

		public double LineTypeScale
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				if (this.double_0 <= 0.0)
				{
					throw new ArgumentOutOfRangeException("Line type scale must be greater than 0");
				}
			}
		}

		public Vector3d NormalVector
		{
			get
			{
				return this.vector3d_0;
			}
			set
			{
				this.vector3d_0 = value;
			}
		}

		public int NumberOfEntities
		{
			get
			{
				int num = 0 + this.list_0.Count;
				num += this.list_1.Count;
				num += this.list_2.Count;
				num += this.list_3.Count;
				num += this.list_4.Count;
				num += this.list_5.Count;
				num += this.list_6.Count;
				return num + this.list_7.Count;
			}
		}

		public List<Plane> Planes
		{
			get
			{
				return this.list_2;
			}
			set
			{
				this.list_2 = value;
			}
		}

		public int PointDisplayMode
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if (this.int_0 != 0 && this.int_0 != 1 && this.int_0 != 2 && this.int_0 != 3 && this.int_0 != 4 && this.int_0 != 32 && this.int_0 != 33 && this.int_0 != 34 && this.int_0 != 35 && this.int_0 != 36 && this.int_0 != 64 && this.int_0 != 65 && this.int_0 != 66 && this.int_0 != 67 && this.int_0 != 68)
				{
					throw new ArgumentOutOfRangeException("The point display mode must be 0, 1, 2, 3, 4, 32, 33, 34, 35, 36, 64, 65, 66, 67 or 68");
				}
			}
		}

		public List<Point> Points
		{
			get
			{
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
			}
		}

		public double PointSize
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

		public List<Scene.Text> Texts
		{
			get
			{
				return this.list_7;
			}
			set
			{
				this.list_7 = value;
			}
		}

		public List<Triangle> Triangles
		{
			get
			{
				return this.list_3;
			}
			set
			{
				this.list_3 = value;
			}
		}

		public int UCSIcon
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				if (this.int_1 < 0 || this.int_1 > 3)
				{
					throw new ArgumentOutOfRangeException("ucsicon system variable must be 0, 1, 2 or 3.");
				}
			}
		}

		private bool bool_0;

		private bool bool_1;

		private double double_0;

		private double double_1;

		private double double_2;

		private int int_0;

		private int int_1;

		private List<Point> list_0;

		private List<Edge> list_1;

		private List<Plane> list_2;

		private List<Triangle> list_3;

		private List<Circle> list_4;

		private List<Ellipse> list_5;

		private List<Arc> list_6;

		private List<Scene.Text> list_7;

		private Vector3d vector3d_0;

		//[LicenseProvider(typeof(Class46))]
		public class Text
		{
			public Text(string text, Layer layer)
			{
                //System.ComponentModel.LicenseManager.Validate(typeof(Scene.Text));
				this.point_0 = new Point(0.0, 0.0, 0.0);
				this.double_0 = 0.2;
				//base..ctor();
				this.string_0 = text;
				this.layer_0 = layer;
			}

			public Text(string text, Layer layer, byte color)
			{
                //System.ComponentModel.LicenseManager.Validate(typeof(Scene.Text));
				this.point_0 = new Point(0.0, 0.0, 0.0);
				this.double_0 = 0.2;
				//base..ctor();
				this.string_0 = text;
				this.layer_0 = layer;
				this.byte_0 = color;
			}

			public void Move(Vector3d displacementVector)
			{
				this.point_0 = this.point_0.Move(displacementVector);
			}

			public bool Backwards
			{
				get
				{
					return this.bool_1;
				}
				set
				{
					this.bool_1 = value;
				}
			}

			public byte Color
			{
				get
				{
					return this.byte_0;
				}
				set
				{
					this.byte_0 = value;
					if (value < 1 | value > 255)
					{
						throw new ArgumentException("Invalid color index: " + value + ". Color index must be between 1 and 255");
					}
				}
			}

			public double Height
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

			public Scene.Text.HorizontalJustification HorizontalAlignment
			{
				get
				{
					return this.horizontalJustification_0;
				}
				set
				{
					this.horizontalJustification_0 = value;
				}
			}

			public Point InsertionPoint
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

			public Layer Layer
			{
				get
				{
					return this.layer_0;
				}
				set
				{
					this.layer_0 = value;
				}
			}

			public double Rotation
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

			public bool UpsideDown
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

			public string Value
			{
				get
				{
					return this.string_0;
				}
				set
				{
					this.string_0 = value;
				}
			}

			public Scene.Text.VerticalJustification VerticalAlignment
			{
				get
				{
					return this.verticalJustification_0;
				}
				set
				{
					this.verticalJustification_0 = value;
				}
			}

			private bool bool_0;

			private bool bool_1;

			private byte byte_0;

			private double double_0;

			private double double_1;

			private Scene.Text.HorizontalJustification horizontalJustification_0;

			private Layer layer_0;

			private Point point_0;

			private string string_0;

			private Scene.Text.VerticalJustification verticalJustification_0;

			////[LicenseProvider(typeof(Class46))]
			public enum HorizontalJustification
			{
				Default,
				Left,
				Center,
				Right
			}

			////[LicenseProvider(typeof(Class46))]
			public enum VerticalJustification
			{
				Default,
				Baseline,
				Bottom,
				Middle,
				Top
			}
		}
	}
}
