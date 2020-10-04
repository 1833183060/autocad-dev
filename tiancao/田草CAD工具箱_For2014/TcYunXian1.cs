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
	public class TcYunXian1 : DrawJig
	{
		public TcYunXian1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
			this.short_0 = 50;
			this.long_0 = 1000L;
		}

		[CommandMethod("TcYunXian1")]
		public void TcYunXian1()
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
				double scale = CAD.GetScale();
				IL_12:
				num2 = 3;
				bool flag;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					this.short_0 = (short)Math.Round(unchecked(50.0 * scale));
					IL_2C:
					num2 = 4;
					this.long_0 = (long)Math.Round(unchecked(500.0 * scale));
					IL_46:
					num2 = 5;
					this.point3d_0 = CAD.GetPoint("选择插入点: ");
					IL_58:
					num2 = 6;
					Point3d point3d;
					if (!(this.point3d_0 == point3d))
					{
						goto IL_6E;
					}
					IL_69:
					goto IL_21A;
					IL_6E:
					num2 = 9;
					flag = false;
					IL_74:
					num2 = 10;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					IL_7D:
					num2 = 11;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					IL_90:
					num2 = 12;
					PromptResult promptResult = editor.Drag(this);
					IL_9C:
					num2 = 13;
					if (promptResult.Status != 5100)
					{
						goto IL_14C;
					}
					IL_B2:
					num2 = 14;
					short num3 = (short)(this.entity_0.Length - 1);
					IL_C2:
					num2 = 15;
					if (num3 != 0)
					{
						goto IL_DF;
					}
					IL_CC:
					num2 = 16;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_14C;
					IL_DF:
					num2 = 18;
					IL_E2:
					num2 = 19;
					array = new ObjectId[(int)(num3 + 1)];
					IL_EF:
					num2 = 20;
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
					IL_104:
					num2 = 21;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_127:
					num2 = 22;
					num6 += 1;
				}
				IL_13B:
				num2 = 23;
				if (!flag)
				{
					goto IL_14C;
				}
				IL_142:
				num2 = 24;
				Class36.smethod_55(array);
				IL_14C:
				goto IL_21A;
				IL_151:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1D1:
				goto IL_20F;
				IL_1D3:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_151;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1EC:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D3;
			}
			IL_20F:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21A:
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
				UseBasePoint = false
			});
			SamplerStatus result;
			if (promptPointResult.Status != -5002)
			{
				Point3d value = promptPointResult.Value;
				if (value != this.point3d_1)
				{
					Point3d point3d = this.point3d_0;
					Point3d point3d2 = value;
					Point3d point3d3;
					point3d3..ctor(Math.Min(point3d.get_Coordinate(0), point3d2.get_Coordinate(0)), Math.Min(point3d.get_Coordinate(1), point3d2.get_Coordinate(1)), 0.0);
					Point3d point3d4;
					point3d4..ctor(Math.Max(point3d.get_Coordinate(0), point3d2.get_Coordinate(0)), Math.Max(point3d.get_Coordinate(1), point3d2.get_Coordinate(1)), 0.0);
					double num = Math.Tan(0.78539816339744828);
					point3d = point3d4;
					point3d2 = point3d3;
					short num3;
					short num5;
					Polyline polyline;
					checked
					{
						long num2 = (long)Math.Round(unchecked(point3d.X - point3d2.X));
						num3 = (short)(num2 / this.long_0);
						long num4 = (long)Math.Round(unchecked(point3d.Y - point3d2.Y));
						num5 = (short)(num4 / this.long_0);
						polyline = new Polyline();
						polyline.SetDatabaseDefaults();
					}
					if (num3 > 1 | num5 > 1)
					{
						point3d2..ctor(point3d.X - (double)(checked(this.long_0 * unchecked((long)num3))), point3d.Y - (double)(checked(this.long_0 * unchecked((long)num5))), 0.0);
						Point3d point3d5;
						point3d5..ctor(point3d.X - (double)(checked(this.long_0 * unchecked((long)num3))), point3d.Y, 0.0);
						Point3d point3d6;
						point3d6..ctor(point3d.X, point3d.Y - (double)(checked(this.long_0 * unchecked((long)num5))), 0.0);
						short num6 = 0;
						short num7 = num3;
						short num8 = num6;
						Point2d point2d;
						for (;;)
						{
							short num9 = num8;
							short num10 = num7;
							if (num9 > num10)
							{
								break;
							}
							Polyline polyline2 = polyline;
							int num11 = (int)num8;
							point2d..ctor(point3d.X - (double)(checked(unchecked((long)num8) * this.long_0)), point3d.Y);
							polyline2.AddVertexAt(num11, point2d, num, 0.0, (double)this.short_0);
							num8 += 1;
						}
						short num12 = 1;
						short num13 = num5;
						short num14 = num12;
						for (;;)
						{
							short num15 = num14;
							short num10 = num13;
							if (num15 > num10)
							{
								break;
							}
							Polyline polyline3 = polyline;
							int num16 = (int)(num3 + num14);
							point2d..ctor(point3d5.X, point3d5.Y - (double)(checked(unchecked((long)num14) * this.long_0)));
							polyline3.AddVertexAt(num16, point2d, num, 0.0, (double)this.short_0);
							num14 += 1;
						}
						short num17 = 1;
						short num18 = num3;
						short num19 = num17;
						for (;;)
						{
							short num20 = num19;
							short num10 = num18;
							if (num20 > num10)
							{
								break;
							}
							Polyline polyline4 = polyline;
							int num21 = (int)(num3 + num5 + num19);
							point2d..ctor(point3d2.X + (double)(checked(unchecked((long)num19) * this.long_0)), point3d2.Y);
							polyline4.AddVertexAt(num21, point2d, num, 0.0, (double)this.short_0);
							num19 += 1;
						}
						short num22 = 1;
						short num23 = num5;
						short num24 = num22;
						for (;;)
						{
							short num25 = num24;
							short num10 = num23;
							if (num25 > num10)
							{
								break;
							}
							Polyline polyline5 = polyline;
							int num26 = (int)(num3 + num5 + num3 + num24);
							point2d..ctor(point3d6.X, point3d6.Y + (double)(checked(unchecked((long)num24) * this.long_0)));
							polyline5.AddVertexAt(num26, point2d, num, 0.0, (double)this.short_0);
							num24 += 1;
						}
					}
					else
					{
						Polyline polyline6 = polyline;
						int num27 = 0;
						Point2d point2d;
						point2d..ctor(point3d.X, point3d.Y);
						polyline6.AddVertexAt(num27, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline7 = polyline;
						int num28 = 1;
						point2d..ctor(point3d2.X, point3d.Y);
						polyline7.AddVertexAt(num28, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline8 = polyline;
						int num29 = 2;
						point2d..ctor(point3d2.X, point3d2.Y);
						polyline8.AddVertexAt(num29, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline9 = polyline;
						int num30 = 3;
						point2d..ctor(point3d.X, point3d2.Y);
						polyline9.AddVertexAt(num30, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						polyline.Closed = true;
					}
					this.entity_0[0] = polyline;
					this.point3d_1 = value;
					result = 0;
				}
				else
				{
					result = 1;
				}
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

		private short short_0;

		private long long_0;
	}
}
