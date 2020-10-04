using System;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 钢筋桁架LM2 : DrawJig
	{
		public 钢筋桁架LM2()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[3];
		}

		[CommandMethod("TcGJHJ_LM2")]
		public void TcGJHJ_LM2()
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.double_0 = CAD.GetScale();
				IL_16:
				num2 = 3;
				this.point3d_0 = CAD.GetPoint("选择插入点: ");
				IL_28:
				num2 = 4;
				Point3d point3d;
				if (!(this.point3d_0 == point3d))
				{
					goto IL_3E;
				}
				IL_39:
				goto IL_1A3;
				IL_3E:
				num2 = 7;
				CAD.CreateLayer("钢筋桁架_LM_YJ", 14, "continuous", -1, false, true);
				IL_55:
				num2 = 8;
				CAD.CreateLayer("钢筋桁架", 14, "continuous", -1, false, true);
				IL_6C:
				num2 = 9;
				IL_6F:
				num2 = 10;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_78:
				num2 = 11;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_8B:
				num2 = 12;
				PromptResult promptResult = editor.Drag(this);
				IL_97:
				num2 = 13;
				if (promptResult.Status != 5100)
				{
					goto IL_F2;
				}
				IL_AA:
				num2 = 14;
				Line line = new Line();
				IL_B3:
				num2 = 15;
				line.SetDatabaseDefaults();
				IL_BC:
				num2 = 16;
				line.StartPoint = this.point3d_0;
				IL_CB:
				num2 = 17;
				line.EndPoint = this.point3d_1;
				IL_DA:
				num2 = 18;
				line.Layer = "钢筋桁架_LM_YJ";
				IL_E8:
				num2 = 19;
				CAD.AddEnt(line);
				IL_F2:
				goto IL_1A3;
				IL_F7:
				goto IL_1AE;
				IL_FC:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_114;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_17D;
				IL_114:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_17D:
				goto IL_1AE;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_FC;
			}
			IL_1A3:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_1AE:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		protected override SamplerStatus Sampler(JigPrompts Prompts)
		{
			PromptPointResult promptPointResult = Prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
			{
				Cursor = 3,
				BasePoint = this.point3d_0,
				UseBasePoint = true
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				Line line = new Line();
				line.SetDatabaseDefaults();
				line.StartPoint = this.point3d_0;
				line.EndPoint = value;
				short num = 90;
				short num2 = 60;
				short num3 = 0;
				double angle = line.Angle;
				double num4 = Math.Atan(0.66666666666666663);
				double num5 = 2.0 * num4;
				double num6 = Math.Tan(num5 / 4.0);
				double num7 = Math.Tan(num4 / 4.0);
				double num8 = (double)9f / Math.Sin(num4) / Math.Cos(num4) - (double)9f / Math.Sin(num4);
				double length = line.Length;
				Point3d startPoint = line.StartPoint;
				Point3d endPoint = line.EndPoint;
				Point3d pointAngle = CAD.GetPointAngle(line.StartPoint, (double)60f - 2.0 * num8, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle2 = CAD.GetPointAngle(line.EndPoint, (double)60f - 2.0 * num8, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Point2dCollection point2dCollection = new Point2dCollection();
				double x = startPoint.X;
				double y = startPoint.Y;
				Point2dCollection point2dCollection2 = point2dCollection;
				Point2d point2d;
				point2d..ctor(x, y + (double)60f - 2.0 * num8);
				point2dCollection2.Add(point2d);
				Point2dCollection point2dCollection7;
				checked
				{
					long num9 = (long)Math.Round(length) / 90L;
					long num10 = 0L;
					long num11 = num9;
					long num12 = num10;
					for (;;)
					{
						long num13 = num12;
						long num14 = num11;
						if (num13 > num14)
						{
							break;
						}
						short num15 = (short)(num12 % 2L);
						unchecked
						{
							if (num15 == 0)
							{
								Point2dCollection point2dCollection3 = point2dCollection;
								point2d..ctor(x + (double)(checked(num12 * unchecked((long)num))) + 0.1 * (double)num, y + (double)num2 * 0.9 - num8);
								point2dCollection3.Add(point2d);
								Point2dCollection point2dCollection4 = point2dCollection;
								point2d..ctor(x + (double)(checked(num12 * unchecked((long)num))) + 0.9 * (double)num, y + (double)num2 * 0.1 - num8);
								point2dCollection4.Add(point2d);
							}
							else if (num15 == 1)
							{
								Point2dCollection point2dCollection5 = point2dCollection;
								point2d..ctor(x + (double)(checked(num12 * unchecked((long)num))) + 0.1 * (double)num, y + (double)num2 * 0.1 - num8);
								point2dCollection5.Add(point2d);
								Point2dCollection point2dCollection6 = point2dCollection;
								point2d..ctor(x + (double)(checked(num12 * unchecked((long)num))) + 0.9 * (double)num, y + (double)num2 * 0.9 - num8);
								point2dCollection6.Add(point2d);
							}
						}
						num12 += 1L;
					}
					point2dCollection7 = new Point2dCollection();
				}
				foreach (Point2d point2d2 in point2dCollection)
				{
					point2d..ctor(x, y);
					double distanceTo = point2d2.GetDistanceTo(point2d);
					point2d..ctor(x, y);
					double angle2 = point2d2.GetVectorTo(point2d).Angle;
					double num16 = x + Math.Cos(angle + angle2 + 3.1415926535897931) * distanceTo;
					double num17 = y + Math.Sin(angle + angle2 + 3.1415926535897931) * distanceTo;
					Point2dCollection point2dCollection8 = point2dCollection7;
					point2d..ctor(num16, num17);
					point2dCollection8.Add(point2d);
				}
				Polyline polyline = new Polyline();
				Polyline polyline2 = new Polyline();
				Polyline polyline3 = new Polyline();
				Polyline polyline4 = polyline;
				int num18 = 0;
				point2d..ctor(line.StartPoint.X, line.StartPoint.Y);
				polyline4.AddVertexAt(num18, point2d, 0.0, (double)num3, (double)num3);
				Polyline polyline5 = polyline;
				int num19 = 1;
				point2d..ctor(line.EndPoint.X, line.EndPoint.Y);
				polyline5.AddVertexAt(num19, point2d, 0.0, (double)num3, (double)num3);
				Polyline polyline6 = polyline2;
				int num20 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y);
				polyline6.AddVertexAt(num20, point2d, 0.0, (double)num3, (double)num3);
				Polyline polyline7 = polyline2;
				int num21 = 1;
				point2d..ctor(pointAngle2.X, pointAngle2.Y);
				polyline7.AddVertexAt(num21, point2d, 0.0, (double)num3, (double)num3);
				polyline3.AddVertexAt(0, point2dCollection7[0], -num7, 0.0, 0.0);
				long num22 = 1L;
				long num23 = (long)(checked(point2dCollection7.Count - 2));
				long num24 = num22;
				checked
				{
					for (;;)
					{
						long num25 = num24;
						long num14 = num23;
						if (num25 > num14)
						{
							break;
						}
						long num26 = num24 % 4L;
						if (num26 <= 3L && num26 >= 0L)
						{
							switch (unchecked((int)num26))
							{
							case 0:
								polyline3.AddVertexAt((int)num24, point2dCollection7[(int)num24], unchecked(-num6), 0.0, 0.0);
								break;
							case 1:
								polyline3.AddVertexAt((int)num24, point2dCollection7[(int)num24], 0.0, 0.0, 0.0);
								break;
							case 2:
								polyline3.AddVertexAt((int)num24, point2dCollection7[(int)num24], num6, 0.0, 0.0);
								break;
							case 3:
								polyline3.AddVertexAt((int)num24, point2dCollection7[(int)num24], 0.0, 0.0, 0.0);
								break;
							}
						}
						num24 += 1L;
					}
					polyline.Layer = "钢筋桁架";
					polyline2.Layer = "钢筋桁架";
					polyline3.Layer = "钢筋桁架";
					this.entity_0[0] = polyline;
					this.entity_0[1] = polyline2;
					this.entity_0[2] = polyline3;
					this.point3d_1 = value;
					result = 0;
				}
			}
			else
			{
				result = 1;
			}
			return result;
		}

		protected override bool WorldDraw(WorldDraw Draw)
		{
			foreach (Entity obj in this.entity_0)
			{
				Draw.Geometry.Draw((Drawable)obj);
			}
			return true;
		}

		private Entity[] entity_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;
	}
}
