using System;
using System.ComponentModel;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;
using TerrainComputeC.XML;

namespace TerrainComputeC
{	
	public class CoordinateTransformator
	{
		public CoordinateTransformator(CoordinateSystem actualCS, CoordinateSystem newCS)
		{            
			if (actualCS == newCS)
			{
				this.bool_0 = true;
			}
			this.coordinateSystem_0 = actualCS;
			this.coordinateSystem_1 = newCS;
			ngeometry.VectorGeometry.Matrix3d basisVectorMatrix = actualCS.BasisVectorMatrix;
			ngeometry.VectorGeometry.Matrix3d matrix3d = newCS.BasisVectorMatrix.Invert();
			ngeometry.VectorGeometry.Matrix3d matrix3d2 = matrix3d * basisVectorMatrix;
			double num = actualCS.Origin.X - newCS.Origin.X;
			double num2 = actualCS.Origin.Y - newCS.Origin.Y;
			double num3 = actualCS.Origin.Z - newCS.Origin.Z;
			this.double_0 = matrix3d2.a00;
			this.double_1 = matrix3d2.a01;
			this.double_2 = matrix3d2.a02;
			this.double_3 = matrix3d2.a10;
			this.double_4 = matrix3d2.a11;
			this.double_5 = matrix3d2.a12;
			this.double_6 = matrix3d2.a20;
			this.double_7 = matrix3d2.a21;
			this.double_8 = matrix3d2.a22;
			this.double_9 = matrix3d.a00 * num + matrix3d.a01 * num2 + matrix3d.a02 * num3;
			this.double_10 = matrix3d.a10 * num + matrix3d.a11 * num2 + matrix3d.a12 * num3;
			this.double_11 = matrix3d.a20 * num + matrix3d.a21 * num2 + matrix3d.a22 * num3;
		}

		public CoordinateTransformator GetInverseTransformation()
		{
			return new CoordinateTransformator(this.coordinateSystem_1, this.coordinateSystem_0);
		}

        public Autodesk.AutoCAD.Geometry.Matrix3d ToAcadTransformation()
		{
            return new Autodesk.AutoCAD.Geometry.Matrix3d(new double[]
			{
				this.double_0,
				this.double_1,
				this.double_2,
				this.double_9,
				this.double_3,
				this.double_4,
				this.double_5,
				this.double_10,
				this.double_6,
				this.double_7,
				this.double_8,
				this.double_11,
				0.0,
				0.0,
				0.0,
				1.0
			});
		}

		public void Transform(ngeometry.VectorGeometry.Point p)
		{
			if (this.bool_0)
			{
				return;
			}
			double x = p.X;
			double y = p.Y;
			double z = p.Z;
			p.X = this.double_0 * x + this.double_1 * y + this.double_2 * z + this.double_9;
			p.Y = this.double_3 * x + this.double_4 * y + this.double_5 * z + this.double_10;
			p.Z = this.double_6 * x + this.double_7 * y + this.double_8 * z + this.double_11;
		}

		public void Transform(Edge e)
		{
			this.Transform(e.StartPoint);
			this.Transform(e.EndPoint);
		}

		public void Transform(Triangle t)
		{
			this.Transform(t.Vertex1);
			this.Transform(t.Vertex2);
			this.Transform(t.Vertex3);
		}

		public void Transform(Vertex vertex)
		{
			if (this.bool_0)
			{
				return;
			}
			double x = vertex.X;
			double y = vertex.Y;
			double z = vertex.Z;
			vertex.X = this.double_0 * x + this.double_1 * y + this.double_2 * z + this.double_9;
			vertex.Y = this.double_3 * x + this.double_4 * y + this.double_5 * z + this.double_10;
			vertex.Z = this.double_6 * x + this.double_7 * y + this.double_8 * z + this.double_11;
		}

        public void Transform(global::TerrainComputeC.XML.Point point)
		{
			if (this.bool_0)
			{
				return;
			}
			double x = point.X;
			double y = point.Y;
			double z = point.Z;
			point.X = this.double_0 * x + this.double_1 * y + this.double_2 * z + this.double_9;
			point.Y = this.double_3 * x + this.double_4 * y + this.double_5 * z + this.double_10;
			point.Z = this.double_6 * x + this.double_7 * y + this.double_8 * z + this.double_11;
		}

        public void Transform(global::TerrainComputeC.XML.Line line)
		{
			this.Transform(line.StartVertex);
			this.Transform(line.EndVertex);
		}

		public void Transform(Face face)
		{
			this.Transform(face.Vertex1);
			this.Transform(face.Vertex2);
			this.Transform(face.Vertex3);
		}

		public void Transform(PolyLine pline)
		{
			for (int i = 0; i < pline.Vertices.Count; i++)
			{
				this.Transform(pline.Vertices[i]);
			}
		}

		public void Transform(ref double x, ref double y, ref double z)
		{
			if (this.bool_0)
			{
				return;
			}
			double num = x;
			double num2 = y;
			double num3 = z;
			x = this.double_0 * num + this.double_1 * num2 + this.double_2 * num3 + this.double_9;
			y = this.double_3 * num + this.double_4 * num2 + this.double_5 * num3 + this.double_10;
			z = this.double_6 * num + this.double_7 * num2 + this.double_8 * num3 + this.double_11;
		}

		internal bool bool_0;

		private CoordinateSystem coordinateSystem_0;

		private CoordinateSystem coordinateSystem_1;

		internal readonly double double_0;

		internal readonly double double_1;

		internal readonly double double_10;

		internal readonly double double_11;

		internal readonly double double_2;

		internal readonly double double_3;

		internal readonly double double_4;

		internal readonly double double_5;

		internal readonly double double_6;

		internal readonly double double_7;

		internal readonly double double_8;

		internal readonly double double_9;
	}
}
