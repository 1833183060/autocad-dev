using System;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 钢筋桁架PM1 : DrawJig
	{
		public 钢筋桁架PM1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[3];
		}

		[CommandMethod("TcGJHJ_PM1")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcGJHJ_PM1()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				bool flag;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					this.long_0 = (long)Math.Round(Conversion.Val(Interaction.InputBox(" 输入钢筋桁架的宽度:", Class33.Class31_0.Info.ProductName, "100", -1, -1)));
					IL_3C:
					num2 = 3;
					if (this.long_0 != 0L)
					{
						goto IL_56;
					}
					IL_51:
					goto IL_265;
					IL_56:
					num2 = 6;
					this.double_0 = CAD.GetScale();
					IL_63:
					num2 = 7;
					this.point3d_0 = CAD.GetPoint("选择插入点: ");
					IL_75:
					num2 = 8;
					Point3d point3d;
					if (!(this.point3d_0 == point3d))
					{
						goto IL_8B;
					}
					IL_86:
					goto IL_265;
					IL_8B:
					num2 = 11;
					CAD.CreateLayer("钢筋桁架_PM", 14, "continuous", -1, false, true);
					IL_A3:
					num2 = 12;
					flag = false;
					IL_A9:
					num2 = 13;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					IL_B2:
					num2 = 14;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					IL_C6:
					num2 = 15;
					PromptResult promptResult = editor.Drag(this);
					IL_D2:
					num2 = 16;
					if (promptResult.Status != 5100)
					{
						goto IL_17E;
					}
					IL_E7:
					num2 = 17;
					short num3 = (short)(this.entity_0.Length - 1);
					IL_F7:
					num2 = 18;
					if (num3 != 0)
					{
						goto IL_114;
					}
					IL_101:
					num2 = 19;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_17E;
					IL_114:
					num2 = 21;
					IL_117:
					num2 = 22;
					array = new ObjectId[(int)(num3 + 1)];
					IL_125:
					num2 = 23;
					short num4 = 0;
					num5 = (short)(this.entity_0.Length - 1);
					num6 = num4;
				}
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_139:
					num2 = 24;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_15B:
					num2 = 25;
					num6 += 1;
				}
				IL_16C:
				num2 = 26;
				if (!flag)
				{
					goto IL_17E;
				}
				IL_173:
				num2 = 27;
				Class36.smethod_55(array);
				IL_17E:
				goto IL_265;
				IL_183:
				goto IL_25A;
				IL_188:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_1A3;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_234;
				IL_1A3:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_234:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_188;
			}
			IL_25A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_265:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
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
				double angle = line.Angle;
				double length = line.Length;
				short num = 0;
				double num2 = 100.0;
				this.long_0 = checked((long)Math.Round((double)this.long_0 / 2.0));
				Point3d startPoint = line.StartPoint;
				Point3d endPoint = line.EndPoint;
				Point3d point3d = CAD.GetPointXY(line.StartPoint, 0.0, (double)this.long_0);
				Point3d point3d2 = CAD.GetPointXY(line.EndPoint, 0.0, (double)this.long_0);
				double num3 = 0.1 * (double)this.long_0;
				double num4 = Math.Atan(num2 / ((double)this.long_0 - 2.0 * num3));
				double num5 = (double)this.long_0 / Math.Sin(num4);
				double num6 = num5 / 2.0;
				double num7 = Math.Acos(num3 / num6);
				double num8 = num4 + num7 - 1.5707963267948966;
				double num9 = 2.0 * (3.1415926535897931 - num4 - num7);
				double num10 = Math.Tan(num9 / 4.0);
				double num11 = Math.Tan(num9 / 2.0 / 4.0);
				Point2dCollection point2dCollection = new Point2dCollection();
				Point2dCollection point2dCollection2 = point2dCollection;
				Point2d point2d;
				point2d..ctor(point3d.X, point3d.Y);
				point2dCollection2.Add(point2d);
				Point2dCollection point2dCollection7;
				checked
				{
					long num12 = (long)Math.Round(line.Length) / (long)Math.Round(num2);
					long num13 = 0L;
					long num14 = num12;
					long num15 = num13;
					for (;;)
					{
						long num16 = num15;
						long num17 = num14;
						if (num16 > num17)
						{
							break;
						}
						short num18 = (short)(num15 % 2L);
						unchecked
						{
							if (num18 == 0)
							{
								Point3d p;
								p..ctor(startPoint.X + (double)num15 * num2, point3d.Y - num3, 0.0);
								Point3d pointAngle = CAD.GetPointAngle(p, num3, num8 * 180.0 / 3.1415926535897931);
								Point3d p2;
								p2..ctor(startPoint.X + (double)num15 * num2 + num2, startPoint.Y + num3, 0.0);
								Point3d pointAngle2 = CAD.GetPointAngle(p2, num3, num8 * 180.0 / 3.1415926535897931 + 180.0);
								Point2dCollection point2dCollection3 = point2dCollection;
								point2d..ctor(pointAngle.X, pointAngle.Y);
								point2dCollection3.Add(point2d);
								Point2dCollection point2dCollection4 = point2dCollection;
								point2d..ctor(pointAngle2.X, pointAngle2.Y);
								point2dCollection4.Add(point2d);
							}
							else if (num18 == 1)
							{
								Point3d p3;
								p3..ctor(startPoint.X + (double)num15 * num2, startPoint.Y + num3, 0.0);
								Point3d pointAngle3 = CAD.GetPointAngle(p3, num3, -num8 * 180.0 / 3.1415926535897931);
								Point3d p4;
								p4..ctor(startPoint.X + (double)num15 * num2 + num2, point3d.Y - num3, 0.0);
								Point3d pointAngle4 = CAD.GetPointAngle(p4, num3, 180.0 - num8 * 180.0 / 3.1415926535897931);
								Point2dCollection point2dCollection5 = point2dCollection;
								point2d..ctor(pointAngle3.X, pointAngle3.Y);
								point2dCollection5.Add(point2d);
								Point2dCollection point2dCollection6 = point2dCollection;
								point2d..ctor(pointAngle4.X, pointAngle4.Y);
								point2dCollection6.Add(point2d);
							}
						}
						num15 += 1L;
					}
					point2dCollection7 = new Point2dCollection();
					double x = startPoint.X;
					double y = startPoint.Y;
				}
				Point2d point2d3;
				foreach (Point2d point2d2 in point2dCollection)
				{
					point2d..ctor(startPoint.X, startPoint.Y);
					point2d3 = point2d;
					Vector2d vector2d = point2d3.GetVectorTo(point2d2).RotateBy(angle);
					Point2dCollection point2dCollection8 = point2dCollection7;
					point2d3..ctor(startPoint.X + vector2d.X, startPoint.Y + vector2d.Y);
					point2dCollection8.Add(point2d3);
				}
				point3d = CAD.GetPointAngle(line.StartPoint, (double)this.long_0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				point3d2 = CAD.GetPointAngle(line.EndPoint, (double)this.long_0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Polyline polyline = new Polyline();
				Polyline polyline2 = new Polyline();
				Polyline polyline3 = new Polyline();
				Polyline polyline4 = polyline;
				int num19 = 0;
				point2d3..ctor(line.StartPoint.X, line.StartPoint.Y);
				polyline4.AddVertexAt(num19, point2d3, 0.0, (double)num, (double)num);
				Polyline polyline5 = polyline;
				int num20 = 1;
				point2d3..ctor(line.EndPoint.X, line.EndPoint.Y);
				polyline5.AddVertexAt(num20, point2d3, 0.0, (double)num, (double)num);
				Polyline polyline6 = polyline2;
				int num21 = 0;
				point2d3..ctor(point3d.X, point3d.Y);
				polyline6.AddVertexAt(num21, point2d3, 0.0, (double)num, (double)num);
				Polyline polyline7 = polyline2;
				int num22 = 1;
				point2d3..ctor(point3d2.X, point3d2.Y);
				polyline7.AddVertexAt(num22, point2d3, 0.0, (double)num, (double)num);
				polyline3.AddVertexAt(0, point2dCollection7[0], -num11, 0.0, 0.0);
				long num23 = 1L;
				long num24 = (long)(checked(point2dCollection7.Count - 2));
				long num25 = num23;
				checked
				{
					for (;;)
					{
						long num26 = num25;
						long num17 = num24;
						if (num26 > num17)
						{
							break;
						}
						long num27 = num25 % 4L;
						if (num27 <= 3L && num27 >= 0L)
						{
							switch (unchecked((int)num27))
							{
							case 0:
								polyline3.AddVertexAt((int)num25, point2dCollection7[(int)num25], unchecked(-num10), 0.0, 0.0);
								break;
							case 1:
								polyline3.AddVertexAt((int)num25, point2dCollection7[(int)num25], 0.0, 0.0, 0.0);
								break;
							case 2:
								polyline3.AddVertexAt((int)num25, point2dCollection7[(int)num25], num10, 0.0, 0.0);
								break;
							case 3:
								polyline3.AddVertexAt((int)num25, point2dCollection7[(int)num25], 0.0, 0.0, 0.0);
								break;
							}
						}
						num25 += 1L;
					}
					polyline.Layer = "钢筋桁架_PM";
					polyline2.Layer = "钢筋桁架_PM";
					polyline3.Layer = "钢筋桁架_PM";
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

		private long long_0;

		private double double_0;
	}
}
