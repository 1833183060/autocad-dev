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
	public class 钢筋桁架PM : DrawJig
	{
		public 钢筋桁架PM()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[5];
		}

		[CommandMethod("TcGJHJ_PM")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcGJHJ_PM()
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
					goto IL_25A;
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
					goto IL_25A;
					IL_8B:
					num2 = 11;
					CAD.CreateLayer("钢筋桁架", 14, "continuous", -1, false, true);
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
				goto IL_25A;
				IL_183:
				goto IL_265;
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
				IL_234:
				goto IL_265;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_188;
			}
			IL_25A:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_265:
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
				short num = 100;
				double angle = line.Angle;
				Point3d startPoint = line.StartPoint;
				Point3d endPoint = line.EndPoint;
				Point3d pointAngle = CAD.GetPointAngle(line.StartPoint, (double)this.long_0 / 2.0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle2 = CAD.GetPointAngle(line.EndPoint, (double)this.long_0 / 2.0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle3 = CAD.GetPointAngle(line.StartPoint, (double)this.long_0 / 2.0, line.Angle * 180.0 / 3.1415926535897931 - 90.0);
				Point3d pointAngle4 = CAD.GetPointAngle(line.EndPoint, (double)this.long_0 / 2.0, line.Angle * 180.0 / 3.1415926535897931 - 90.0);
				Polyline polyline = new Polyline();
				Polyline polyline2 = new Polyline();
				Polyline polyline3 = new Polyline();
				Polyline polyline4 = new Polyline();
				Polyline polyline5 = new Polyline();
				Polyline polyline6 = polyline;
				int num2 = 0;
				Point2d point2d;
				point2d..ctor(line.StartPoint.X, line.StartPoint.Y);
				polyline6.AddVertexAt(num2, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline7 = polyline;
				int num3 = 1;
				point2d..ctor(line.EndPoint.X, line.EndPoint.Y);
				polyline7.AddVertexAt(num3, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline8 = polyline2;
				int num4 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y);
				polyline8.AddVertexAt(num4, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline9 = polyline2;
				int num5 = 1;
				point2d..ctor(pointAngle2.X, pointAngle2.Y);
				polyline9.AddVertexAt(num5, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline10 = polyline3;
				int num6 = 0;
				point2d..ctor(pointAngle3.X, pointAngle3.Y);
				polyline10.AddVertexAt(num6, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline11 = polyline3;
				int num7 = 1;
				point2d..ctor(pointAngle4.X, pointAngle4.Y);
				polyline11.AddVertexAt(num7, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline12 = polyline4;
				int num8 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y);
				polyline12.AddVertexAt(num8, point2d, 0.0, 0.0, 0.0);
				Polyline polyline13 = polyline5;
				int num9 = 0;
				point2d..ctor(pointAngle3.X, pointAngle3.Y);
				polyline13.AddVertexAt(num9, point2d, 0.0, 0.0, 0.0);
				double length = line.Length;
				double num10 = length % (double)100f;
				checked
				{
					long num11 = (long)Math.Round(length) / 100L;
					long num12 = 1L;
					long num13 = num11;
					long num14 = num12;
					for (;;)
					{
						long num15 = num14;
						long num16 = num13;
						if (num15 > num16)
						{
							break;
						}
						short num17 = (short)(num14 % 2L);
						if (num17 == 1)
						{
							Polyline polyline14 = polyline4;
							int num18 = (int)num14;
							unchecked
							{
								point2d..ctor(startPoint.X + Math.Cos(line.Angle) * (double)num14 * (double)num, startPoint.Y + Math.Sin(line.Angle) * (double)num14 * (double)num);
								polyline14.AddVertexAt(num18, point2d, 0.0, 0.0, 0.0);
								Polyline polyline15 = polyline5;
								int num19 = checked((int)num14);
								point2d..ctor(startPoint.X + Math.Cos(line.Angle) * (double)num14 * 100.0, startPoint.Y + Math.Sin(line.Angle) * (double)num14 * (double)num);
								polyline15.AddVertexAt(num19, point2d, 0.0, 0.0, 0.0);
							}
						}
						else if (num17 == 0)
						{
							Polyline polyline16 = polyline4;
							int num20 = (int)num14;
							unchecked
							{
								point2d..ctor(pointAngle.X + Math.Cos(line.Angle) * (double)num14 * (double)num, pointAngle.Y + Math.Sin(line.Angle) * (double)num14 * (double)num);
								polyline16.AddVertexAt(num20, point2d, 0.0, 0.0, 0.0);
								Polyline polyline17 = polyline5;
								int num21 = checked((int)num14);
								point2d..ctor(pointAngle3.X + Math.Cos(line.Angle) * (double)num14 * (double)num, pointAngle3.Y + Math.Sin(line.Angle) * (double)num14 * (double)num);
								polyline17.AddVertexAt(num21, point2d, 0.0, 0.0, 0.0);
							}
						}
						num14 += 1L;
					}
					if (num10 > 0.0)
					{
						Point2d point2dAt = polyline4.GetPoint2dAt((int)num11);
						Point2d point2dAt2 = polyline5.GetPoint2dAt((int)num11);
						short num22 = (short)((num11 + 1L) % 2L);
						double num23 = Math.Atan((double)this.long_0 / 2.0 / (double)num);
						double num24 = num10 / Math.Cos(num23);
						if (num22 == 1)
						{
							Polyline polyline18 = polyline4;
							int num25 = (int)(num11 + 1L);
							unchecked
							{
								point2d..ctor(point2dAt.X + num24 * Math.Cos(line.Angle - num23), point2dAt.Y + num24 * Math.Sin(line.Angle - num23));
								polyline18.AddVertexAt(num25, point2d, 0.0, 0.0, 0.0);
								Polyline polyline19 = polyline5;
								int num26 = checked((int)(num11 + 1L));
								point2d..ctor(point2dAt2.X + num24 * Math.Cos(line.Angle + num23), point2dAt2.Y + num24 * Math.Sin(line.Angle + num23));
								polyline19.AddVertexAt(num26, point2d, 0.0, 0.0, 0.0);
							}
						}
						else if (num22 == 0)
						{
							Polyline polyline20 = polyline4;
							int num27 = (int)(num11 + 1L);
							unchecked
							{
								point2d..ctor(point2dAt.X + num24 * Math.Cos(line.Angle + num23), point2dAt.Y + num24 * Math.Sin(line.Angle + num23));
								polyline20.AddVertexAt(num27, point2d, 0.0, 0.0, 0.0);
								Polyline polyline21 = polyline5;
								int num28 = checked((int)(num11 + 1L));
								point2d..ctor(point2dAt2.X + num24 * Math.Cos(line.Angle - num23), point2dAt2.Y + num24 * Math.Sin(line.Angle - num23));
								polyline21.AddVertexAt(num28, point2d, 0.0, 0.0, 0.0);
							}
						}
					}
					polyline.Layer = "钢筋桁架";
					polyline2.Layer = "钢筋桁架";
					polyline3.Layer = "钢筋桁架";
					polyline4.Layer = "钢筋桁架";
					polyline5.Layer = "钢筋桁架";
					this.entity_0[0] = polyline;
					this.entity_0[1] = polyline2;
					this.entity_0[2] = polyline3;
					this.entity_0[3] = polyline4;
					this.entity_0[4] = polyline5;
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
