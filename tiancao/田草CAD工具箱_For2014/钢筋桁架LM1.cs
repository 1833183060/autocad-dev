using System;
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
	public class 钢筋桁架LM1 : DrawJig
	{
		public 钢筋桁架LM1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[3];
		}

		[CommandMethod("TcGJHJ_LM1")]
		public void TcGJHJ_LM1()
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
					this.long_0 = (long)Math.Round(Conversion.Val(Interaction.InputBox("输入钢筋桁架高度:", "田草CAD工具箱-绘制钢筋桁架", "100", -1, -1)));
					IL_32:
					num2 = 3;
					if (this.long_0 != 0L)
					{
						goto IL_4C;
					}
					IL_47:
					goto IL_24E;
					IL_4C:
					num2 = 6;
					this.point3d_0 = CAD.GetPoint("选择插入点: ");
					IL_5E:
					num2 = 7;
					Point3d point3d;
					if (!(this.point3d_0 == point3d))
					{
						goto IL_74;
					}
					IL_6F:
					goto IL_24E;
					IL_74:
					num2 = 10;
					CAD.CreateLayer("钢筋桁架_LM", 14, "continuous", -1, false, true);
					IL_8C:
					num2 = 11;
					flag = false;
					IL_91:
					num2 = 12;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					IL_9A:
					num2 = 13;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					IL_AD:
					num2 = 14;
					PromptResult promptResult = editor.Drag(this);
					IL_B9:
					num2 = 15;
					if (promptResult.Status != 5100)
					{
						goto IL_16B;
					}
					IL_CF:
					num2 = 16;
					short num3 = (short)(this.entity_0.Length - 1);
					IL_DF:
					num2 = 17;
					if (num3 != 0)
					{
						goto IL_FC;
					}
					IL_E9:
					num2 = 18;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_16B;
					IL_FC:
					num2 = 20;
					IL_FF:
					num2 = 21;
					array = new ObjectId[(int)(num3 + 1)];
					IL_10D:
					num2 = 22;
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
					IL_122:
					num2 = 23;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_146:
					num2 = 24;
					num6 += 1;
				}
				IL_15A:
				num2 = 25;
				if (!flag)
				{
					goto IL_16B;
				}
				IL_160:
				num2 = 26;
				Class36.smethod_55(array);
				IL_16B:
				goto IL_24E;
				IL_170:
				goto IL_243;
				IL_175:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_190;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_21D;
				IL_190:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_21D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_175;
			}
			IL_243:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_24E:
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
				Point3d startPoint = line.StartPoint;
				Point3d endPoint = line.EndPoint;
				Point3d point3d = CAD.GetPointXY(line.StartPoint, 0.0, (double)this.long_0);
				double num3 = 0.1 * (double)this.long_0;
				double num4 = Math.Atan(num2 / ((double)this.long_0 - 2.0 * num3));
				double num5 = num2 / Math.Sin(num4);
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
					long num12 = (long)Math.Round(length) / (long)Math.Round(num2);
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
								p2..ctor(startPoint.X + (double)num15 * num2 + 100.0, startPoint.Y + num3, 0.0);
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
								p4..ctor(startPoint.X + (double)num15 * num2 + 100.0, point3d.Y - num3, 0.0);
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
				Point3d pointAngle5 = CAD.GetPointAngle(line.EndPoint, (double)this.long_0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
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
				point2d3..ctor(pointAngle5.X, pointAngle5.Y);
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
					polyline.Layer = "钢筋桁架_LM";
					polyline2.Layer = "钢筋桁架_LM";
					polyline3.Layer = "钢筋桁架_LM";
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
	}
}
