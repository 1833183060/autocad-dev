using System;
using System.ComponentModel;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class IdEdge
	{
        public IdEdge(Autodesk.AutoCAD.DatabaseServices.Line line)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdEdge));
			this.MinX = double.NaN;
			this.MaxX = double.NaN;
			this.MinY = double.NaN;
			this.MaxY = double.NaN;
			//base..ctor();
			this.Line = line;
			Point3d startPoint = line.StartPoint;
			Point3d endPoint = line.EndPoint;
			this.Edge = new Edge(new Point(startPoint.X, startPoint.Y, startPoint.Z), new Point(endPoint.X, endPoint.Y, endPoint.Z));
			this.MinX = Math.Min(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MaxX = Math.Max(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MinY = Math.Min(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
			this.MaxY = Math.Max(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
		}

		public IdEdge(Edge edge)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdEdge));
			this.MinX = double.NaN;
			this.MaxX = double.NaN;
			this.MinY = double.NaN;
			this.MaxY = double.NaN;
			//base..ctor();
			this.Edge = edge;
			this.MinX = Math.Min(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MaxX = Math.Max(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MinY = Math.Min(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
			this.MaxY = Math.Max(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
		}

        public IdEdge(Autodesk.AutoCAD.DatabaseServices.Line line, Autodesk.AutoCAD.DatabaseServices.Face face)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdEdge));
			this.MinX = double.NaN;
			this.MaxX = double.NaN;
			this.MinY = double.NaN;
			this.MaxY = double.NaN;
			//base..ctor();
			this.Line = line;
			this.Face = face;
			Point3d startPoint = line.StartPoint;
			Point3d endPoint = line.EndPoint;
			this.Edge = new Edge(new Point(startPoint.X, startPoint.Y, startPoint.Z), new Point(endPoint.X, endPoint.Y, endPoint.Z));
			this.MinX = Math.Min(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MaxX = Math.Max(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MinY = Math.Min(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
			this.MaxY = Math.Max(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
		}

		public IdEdge(Edge edge, Face face)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdEdge));
			this.MinX = double.NaN;
			this.MaxX = double.NaN;
			this.MinY = double.NaN;
			this.MaxY = double.NaN;
			//base..ctor();
			this.Edge = edge;
			this.Face = face;
			this.MinX = Math.Min(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MaxX = Math.Max(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MinY = Math.Min(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
			this.MaxY = Math.Max(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
		}

		public void SetMinMaxXY()
		{
			this.MinX = Math.Min(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MaxX = Math.Max(this.Edge.StartPoint.X, this.Edge.EndPoint.X);
			this.MinY = Math.Min(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
			this.MaxY = Math.Max(this.Edge.StartPoint.Y, this.Edge.EndPoint.Y);
		}

		public Edge Edge;

        public Autodesk.AutoCAD.DatabaseServices.Face Face;

        public Autodesk.AutoCAD.DatabaseServices.Line Line;

		public double MaxX;

		public double MaxY;

		public double MinX;

		public double MinY;
	}
}
