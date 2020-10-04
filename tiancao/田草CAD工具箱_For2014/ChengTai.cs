using System;
using System.Diagnostics;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class ChengTai
	{
		[DebuggerNonUserCode]
		public ChengTai()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcChengTai3")]
		public void ChengTai3()
		{
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(point == point3d))
			{
				objectIdCollection.Add(CAD.AddPoint(point));
				long num = Conversions.ToLong(Interaction.InputBox("输入桩直径或边长", "三桩承台", "400", -1, -1));
				long num2 = Conversions.ToLong(Interaction.InputBox("输入桩中心距(mm)", "三桩承台", "1400", -1, -1));
				Point3d pointAngle = CAD.GetPointAngle(point, (double)num2 * Math.Sqrt(3.0) / 3.0, 90.0);
				objectIdCollection.Add(CAD.AddPoint(pointAngle));
				Point3d pointAngle2 = CAD.GetPointAngle(point, (double)num2 * Math.Sqrt(3.0) / 3.0, 210.0);
				objectIdCollection.Add(CAD.AddPoint(pointAngle2));
				Point3d pointAngle3 = CAD.GetPointAngle(point, (double)num2 * Math.Sqrt(3.0) / 3.0, -30.0);
				objectIdCollection.Add(CAD.AddPoint(pointAngle3));
				double r = 2.0 * Math.Sqrt(3.0) / 3.0 * (double)num;
				Point3d pointAngle4 = CAD.GetPointAngle(pointAngle, r, 60.0);
				Point3d pointAngle5 = CAD.GetPointAngle(pointAngle, r, 120.0);
				Point3d pointAngle6 = CAD.GetPointAngle(pointAngle2, r, 180.0);
				Point3d pointAngle7 = CAD.GetPointAngle(pointAngle2, r, 240.0);
				Point3d pointAngle8 = CAD.GetPointAngle(pointAngle3, r, 300.0);
				Point3d pointAngle9 = CAD.GetPointAngle(pointAngle3, r, 360.0);
				Polyline polyline = new Polyline();
				Polyline polyline2 = polyline;
				int num3 = 0;
				Point2d point2d;
				point2d..ctor(pointAngle4.X, pointAngle4.Y);
				polyline2.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
				Polyline polyline3 = polyline;
				int num4 = 1;
				point2d..ctor(pointAngle5.X, pointAngle5.Y);
				polyline3.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
				Polyline polyline4 = polyline;
				int num5 = 2;
				point2d..ctor(pointAngle6.X, pointAngle6.Y);
				polyline4.AddVertexAt(num5, point2d, 0.0, 0.0, 0.0);
				Polyline polyline5 = polyline;
				int num6 = 3;
				point2d..ctor(pointAngle7.X, pointAngle7.Y);
				polyline5.AddVertexAt(num6, point2d, 0.0, 0.0, 0.0);
				Polyline polyline6 = polyline;
				int num7 = 4;
				point2d..ctor(pointAngle8.X, pointAngle8.Y);
				polyline6.AddVertexAt(num7, point2d, 0.0, 0.0, 0.0);
				Polyline polyline7 = polyline;
				int num8 = 5;
				point2d..ctor(pointAngle9.X, pointAngle9.Y);
				polyline7.AddVertexAt(num8, point2d, 0.0, 0.0, 0.0);
				polyline.Closed = true;
				objectIdCollection.Add(CAD.AddEnt(polyline).ObjectId);
				Class36.smethod_18(objectIdCollection);
			}
		}
	}
}
