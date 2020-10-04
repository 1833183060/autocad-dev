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
	public class 钢筋桁架LM : DrawJig
	{
		public 钢筋桁架LM()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[3];
		}

		[CommandMethod("TcGJHJ_LM")]
		public void TcGJHJ_LM()
		{
			int num;
			int num10;
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
					goto IL_253;
					IL_4C:
					num2 = 6;
					this.double_0 = CAD.GetScale();
					IL_59:
					num2 = 7;
					this.point3d_0 = CAD.GetPoint("选择插入点: ");
					IL_6B:
					num2 = 8;
					Point3d point3d;
					if (!(this.point3d_0 == point3d))
					{
						goto IL_80;
					}
					IL_7B:
					goto IL_253;
					IL_80:
					num2 = 11;
					CAD.CreateLayer("钢筋桁架", 14, "continuous", -1, false, true);
					IL_98:
					num2 = 12;
					flag = false;
					IL_9E:
					num2 = 13;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					IL_A7:
					num2 = 14;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					IL_BA:
					num2 = 15;
					PromptResult promptResult = editor.Drag(this);
					IL_C6:
					num2 = 16;
					if (promptResult.Status != 5100)
					{
						goto IL_179;
					}
					IL_DC:
					num2 = 17;
					short num3 = (short)(this.entity_0.Length - 1);
					IL_EC:
					num2 = 18;
					if (num3 != 0)
					{
						goto IL_109;
					}
					IL_F6:
					num2 = 19;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_179;
					IL_109:
					num2 = 21;
					IL_10C:
					num2 = 22;
					array = new ObjectId[(int)(num3 + 1)];
					IL_11A:
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
					IL_12F:
					num2 = 24;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_153:
					num2 = 25;
					num6 += 1;
				}
				IL_167:
				num2 = 26;
				if (!flag)
				{
					goto IL_179;
				}
				IL_16E:
				num2 = 27;
				Class36.smethod_55(array);
				IL_179:
				goto IL_253;
				IL_17E:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_20A:
				goto IL_248;
				IL_20C:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_17E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_225:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_20C;
			}
			IL_248:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_253:
			if (num10 != 0)
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
				Point3d startPoint = line.StartPoint;
				Point3d endPoint = line.EndPoint;
				Point3d pointAngle = CAD.GetPointAngle(line.StartPoint, (double)this.long_0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle2 = CAD.GetPointAngle(line.EndPoint, (double)this.long_0, line.Angle * 180.0 / 3.1415926535897931 + 90.0);
				Polyline polyline = new Polyline();
				Polyline polyline2 = new Polyline();
				Polyline polyline3 = new Polyline();
				Polyline polyline4 = polyline;
				int num = 0;
				Point2d point2d;
				point2d..ctor(line.StartPoint.X, line.StartPoint.Y);
				polyline4.AddVertexAt(num, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline5 = polyline;
				int num2 = 1;
				point2d..ctor(line.EndPoint.X, line.EndPoint.Y);
				polyline5.AddVertexAt(num2, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline6 = polyline2;
				int num3 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y);
				polyline6.AddVertexAt(num3, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline7 = polyline2;
				int num4 = 1;
				point2d..ctor(pointAngle2.X, pointAngle2.Y);
				polyline7.AddVertexAt(num4, point2d, 0.0, (double)0f, (double)0f);
				Polyline polyline8 = polyline3;
				int num5 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y);
				polyline8.AddVertexAt(num5, point2d, 0.0, 0.0, 0.0);
				long num6 = 200L;
				double length = line.Length;
				double num7 = length % (double)100f;
				checked
				{
					long num8 = (long)Math.Round(length) / (long)Math.Round((double)100f);
					long num9 = 1L;
					long num10 = num8;
					long num11 = num9;
					for (;;)
					{
						long num12 = num11;
						long num13 = num10;
						if (num12 > num13)
						{
							break;
						}
						short num14 = (short)(num11 % 2L);
						if (num14 == 1)
						{
							Polyline polyline9 = polyline3;
							int num15 = (int)num11;
							unchecked
							{
								point2d..ctor(startPoint.X + Math.Cos(line.Angle) * (double)num11 * (double)num6 / 2.0, startPoint.Y + Math.Sin(line.Angle) * (double)num11 * (double)num6 / 2.0);
								polyline9.AddVertexAt(num15, point2d, 0.0, 0.0, 0.0);
							}
						}
						else if (num14 == 0)
						{
							Polyline polyline10 = polyline3;
							int num16 = (int)num11;
							unchecked
							{
								point2d..ctor(pointAngle.X + Math.Cos(line.Angle) * (double)num11 * (double)num6 / 2.0, pointAngle.Y + Math.Sin(line.Angle) * (double)num11 * (double)num6 / 2.0);
								polyline10.AddVertexAt(num16, point2d, 0.0, 0.0, 0.0);
							}
						}
						num11 += 1L;
					}
					if (num7 > 0.0)
					{
						Point2d point2dAt = polyline3.GetPoint2dAt((int)num8);
						short num17 = (short)((num8 + 1L) % 2L);
						double num18 = Math.Atan((double)this.long_0 / ((double)num6 / 2.0));
						double num19 = num7 / Math.Cos(num18);
						if (num17 == 1)
						{
							Polyline polyline11 = polyline3;
							int num20 = (int)(num8 + 1L);
							unchecked
							{
								point2d..ctor(point2dAt.X + num19 * Math.Cos(line.Angle - num18), point2dAt.Y + num19 * Math.Sin(line.Angle - num18));
								polyline11.AddVertexAt(num20, point2d, 0.0, 0.0, 0.0);
							}
						}
						else if (num17 == 0)
						{
							Polyline polyline12 = polyline3;
							int num21 = (int)(num8 + 1L);
							unchecked
							{
								point2d..ctor(point2dAt.X + num19 * Math.Cos(line.Angle + num18), point2dAt.Y + num19 * Math.Sin(line.Angle + num18));
								polyline12.AddVertexAt(num21, point2d, 0.0, 0.0, 0.0);
							}
						}
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

		private long long_0;

		private double double_0;
	}
}
