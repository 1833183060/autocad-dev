using System;
using System.Diagnostics;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 拉临时测试桁架
	{
		[DebuggerNonUserCode]
		public 拉临时测试桁架()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("Tchjt")]
		public void Tchjt()
		{
			Point3d point3d;
			Point3d point3d2;
			Class36.smethod_31(ref point3d, ref point3d2, "选择插入点:");
			Line line = new Line(point3d, point3d2);
			short num = 5;
			double angle = line.Angle;
			double length = line.Length;
			Point3d startPoint = line.StartPoint;
			Point3d endPoint = line.EndPoint;
			checked
			{
				Point2d point2d;
				if (length > 200.0)
				{
					long num2 = (long)Math.Round(length) / 200L;
					double num3 = length % 100.0;
					num3 /= 2.0;
					long num4 = (long)Math.Round(length) / 100L;
					if (num4 % 2L == 0L)
					{
						Polyline[] array = new Polyline[(int)(num2 - 1L) + 1];
						Polyline[] array2 = new Polyline[(int)(num2 - 1L) + 1];
						long num5 = 0L;
						long num6 = num2 - 1L;
						long num7 = num5;
						for (;;)
						{
							long num8 = num7;
							long num9 = num6;
							if (num8 > num9)
							{
								break;
							}
							Point3d pointRotateByPoint;
							Point3d pointRotateByPoint2;
							Point3d pointRotateByPoint3;
							unchecked
							{
								Point3d p;
								p..ctor(startPoint.X + (double)(checked(200L * num7)) + 50.0 + num3, startPoint.Y + 25.0, startPoint.Z);
								Point3d p2;
								p2..ctor(startPoint.X + (double)(checked(200L * num7)) + 100.0 + num3, startPoint.Y + 0.0, startPoint.Z);
								Point3d p3;
								p3..ctor(startPoint.X + (double)(checked(200L * num7)) + 150.0 + num3, startPoint.Y + 25.0, startPoint.Z);
								pointRotateByPoint = CAD.GetPointRotateByPoint(startPoint, p, angle);
								pointRotateByPoint2 = CAD.GetPointRotateByPoint(startPoint, p2, angle);
								pointRotateByPoint3 = CAD.GetPointRotateByPoint(startPoint, p3, angle);
							}
							array[(int)num7] = new Polyline();
							Polyline polyline = array[(int)num7];
							int num10 = 0;
							point2d..ctor(pointRotateByPoint.X, pointRotateByPoint.Y);
							polyline.AddVertexAt(num10, point2d, 0.0, (double)num, (double)num);
							Polyline polyline2 = array[(int)num7];
							int num11 = 1;
							point2d..ctor(pointRotateByPoint2.X, pointRotateByPoint2.Y);
							polyline2.AddVertexAt(num11, point2d, 0.0, (double)num, (double)num);
							Polyline polyline3 = array[(int)num7];
							int num12 = 2;
							point2d..ctor(pointRotateByPoint3.X, pointRotateByPoint3.Y);
							polyline3.AddVertexAt(num12, point2d, 0.0, (double)num, (double)num);
							CAD.AddEnt(array[(int)num7]);
							array[(int)num7].Dispose();
							Point3d pointRotateByPoint4;
							Point3d pointRotateByPoint5;
							Point3d pointRotateByPoint6;
							unchecked
							{
								Point3d p4;
								p4..ctor(startPoint.X + (double)(checked(200L * num7)) + 50.0 + num3, startPoint.Y - 25.0, startPoint.Z);
								Point3d p5;
								p5..ctor(startPoint.X + (double)(checked(200L * num7)) + 100.0 + num3, startPoint.Y + 0.0, startPoint.Z);
								Point3d p6;
								p6..ctor(startPoint.X + (double)(checked(200L * num7)) + 150.0 + num3, startPoint.Y - 25.0, startPoint.Z);
								pointRotateByPoint4 = CAD.GetPointRotateByPoint(startPoint, p4, angle);
								pointRotateByPoint5 = CAD.GetPointRotateByPoint(startPoint, p5, angle);
								pointRotateByPoint6 = CAD.GetPointRotateByPoint(startPoint, p6, angle);
							}
							array2[(int)num7] = new Polyline();
							Polyline polyline4 = array2[(int)num7];
							int num13 = 0;
							point2d..ctor(pointRotateByPoint4.X, pointRotateByPoint4.Y);
							polyline4.AddVertexAt(num13, point2d, 0.0, (double)num, (double)num);
							Polyline polyline5 = array2[(int)num7];
							int num14 = 1;
							point2d..ctor(pointRotateByPoint5.X, pointRotateByPoint5.Y);
							polyline5.AddVertexAt(num14, point2d, 0.0, (double)num, (double)num);
							Polyline polyline6 = array2[(int)num7];
							int num15 = 2;
							point2d..ctor(pointRotateByPoint6.X, pointRotateByPoint6.Y);
							polyline6.AddVertexAt(num15, point2d, 0.0, (double)num, (double)num);
							CAD.AddEnt(array2[(int)num7]);
							array2[(int)num7].Dispose();
							num7 += 1L;
						}
					}
					else if (num4 % 2L != 0L)
					{
						Polyline[] array = new Polyline[(int)num2 + 1];
						Polyline[] array2 = new Polyline[(int)num2 + 1];
						long num16 = 0L;
						long num17 = num2;
						long num18 = num16;
						for (;;)
						{
							long num19 = num18;
							long num9 = num17;
							if (num19 > num9)
							{
								break;
							}
							Point3d pointRotateByPoint7;
							Point3d pointRotateByPoint8;
							Point3d pointRotateByPoint9;
							unchecked
							{
								Point3d p7;
								p7..ctor(startPoint.X + (double)(checked(200L * num18)) + num3, startPoint.Y + 25.0, startPoint.Z);
								Point3d p8;
								p8..ctor(startPoint.X + (double)(checked(200L * num18)) + 50.0 + num3, startPoint.Y + 0.0, startPoint.Z);
								Point3d p9;
								p9..ctor(startPoint.X + (double)(checked(200L * num18)) + 100.0 + num3, startPoint.Y + 25.0, startPoint.Z);
								pointRotateByPoint7 = CAD.GetPointRotateByPoint(startPoint, p7, angle);
								pointRotateByPoint8 = CAD.GetPointRotateByPoint(startPoint, p8, angle);
								pointRotateByPoint9 = CAD.GetPointRotateByPoint(startPoint, p9, angle);
							}
							array[(int)num18] = new Polyline();
							Polyline polyline7 = array[(int)num18];
							int num20 = 0;
							point2d..ctor(pointRotateByPoint7.X, pointRotateByPoint7.Y);
							polyline7.AddVertexAt(num20, point2d, 0.0, (double)num, (double)num);
							Polyline polyline8 = array[(int)num18];
							int num21 = 1;
							point2d..ctor(pointRotateByPoint8.X, pointRotateByPoint8.Y);
							polyline8.AddVertexAt(num21, point2d, 0.0, (double)num, (double)num);
							Polyline polyline9 = array[(int)num18];
							int num22 = 2;
							point2d..ctor(pointRotateByPoint9.X, pointRotateByPoint9.Y);
							polyline9.AddVertexAt(num22, point2d, 0.0, (double)num, (double)num);
							CAD.AddEnt(array[(int)num18]);
							array[(int)num18].Dispose();
							Point3d pointRotateByPoint10;
							Point3d pointRotateByPoint11;
							Point3d pointRotateByPoint12;
							unchecked
							{
								Point3d p10;
								p10..ctor(startPoint.X + (double)(checked(200L * num18)) + num3, startPoint.Y - 25.0, startPoint.Z);
								Point3d p11;
								p11..ctor(startPoint.X + (double)(checked(200L * num18)) + 50.0 + num3, startPoint.Y + 0.0, startPoint.Z);
								Point3d p12;
								p12..ctor(startPoint.X + (double)(checked(200L * num18)) + 100.0 + num3, startPoint.Y - 25.0, startPoint.Z);
								pointRotateByPoint10 = CAD.GetPointRotateByPoint(startPoint, p10, angle);
								pointRotateByPoint11 = CAD.GetPointRotateByPoint(startPoint, p11, angle);
								pointRotateByPoint12 = CAD.GetPointRotateByPoint(startPoint, p12, angle);
							}
							array2[(int)num18] = new Polyline();
							Polyline polyline10 = array2[(int)num18];
							int num23 = 0;
							point2d..ctor(pointRotateByPoint10.X, pointRotateByPoint10.Y);
							polyline10.AddVertexAt(num23, point2d, 0.0, (double)num, (double)num);
							Polyline polyline11 = array2[(int)num18];
							int num24 = 1;
							point2d..ctor(pointRotateByPoint11.X, pointRotateByPoint11.Y);
							polyline11.AddVertexAt(num24, point2d, 0.0, (double)num, (double)num);
							Polyline polyline12 = array2[(int)num18];
							int num25 = 2;
							point2d..ctor(pointRotateByPoint12.X, pointRotateByPoint12.Y);
							polyline12.AddVertexAt(num25, point2d, 0.0, (double)num, (double)num);
							CAD.AddEnt(array2[(int)num18]);
							array2[(int)num18].Dispose();
							num18 += 1L;
						}
					}
				}
				Polyline polyline13 = new Polyline();
				Polyline polyline14 = polyline13;
				int num26 = 0;
				point2d..ctor(line.StartPoint.X, line.StartPoint.Y);
				polyline14.AddVertexAt(num26, point2d, 0.0, (double)num, (double)num);
				Polyline polyline15 = polyline13;
				int num27 = 1;
				point2d..ctor(line.EndPoint.X, line.EndPoint.Y);
				polyline15.AddVertexAt(num27, point2d, 0.0, (double)num, (double)num);
				polyline13.Dispose();
			}
		}
	}
}
