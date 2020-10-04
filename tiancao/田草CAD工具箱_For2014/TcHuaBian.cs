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
	public class TcHuaBian : DrawJig
	{
		public TcHuaBian()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
			this.short_0 = 50;
		}

		[CommandMethod("TcHuaBian")]
		public void TcHuaBian()
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
				CAD.CreateLayer("注释", 1, "continuous", 30, false, false);
				IL_20:
				num2 = 3;
				double scale = CAD.GetScale();
				IL_29:
				num2 = 4;
				bool flag;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					this.short_0 = (short)Math.Round(unchecked(50.0 * scale));
					IL_43:
					num2 = 5;
					this.point3d_0 = CAD.GetPoint("选择插入点: ");
					IL_55:
					num2 = 6;
					Point3d point3d;
					if (!(this.point3d_0 == point3d))
					{
						goto IL_6B;
					}
					IL_66:
					goto IL_21A;
					IL_6B:
					num2 = 9;
					flag = false;
					IL_71:
					num2 = 10;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					IL_7A:
					num2 = 11;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					IL_8D:
					num2 = 12;
					PromptResult promptResult = editor.Drag(this);
					IL_98:
					num2 = 13;
					if (promptResult.Status != 5100)
					{
						goto IL_14A;
					}
					IL_AD:
					num2 = 14;
					short num3 = (short)(this.entity_0.Length - 1);
					IL_BD:
					num2 = 15;
					if (num3 != 0)
					{
						goto IL_DA;
					}
					IL_C7:
					num2 = 16;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_14A;
					IL_DA:
					num2 = 18;
					IL_DD:
					num2 = 19;
					array = new ObjectId[(int)(num3 + 1)];
					IL_EB:
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
					IL_100:
					num2 = 21;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_124:
					num2 = 22;
					num6 += 1;
				}
				IL_138:
				num2 = 23;
				if (!flag)
				{
					goto IL_14A;
				}
				IL_13F:
				num2 = 24;
				Class36.smethod_55(array);
				IL_14A:
				goto IL_21A;
				IL_14F:
				goto IL_225;
				IL_154:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_16F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_1F4;
				IL_16F:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_1F4:
				goto IL_225;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_154;
			}
			IL_21A:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_225:
			throw ProjectData.CreateProjectError(-2146828237);
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
					Math.Tan(0.78539816339744828);
					point3d = point3d4;
					point3d2 = point3d3;
					Point3d point3d5;
					point3d5..ctor(point3d2.X, point3d.Y, 0.0);
					Point3d point3d6;
					point3d6..ctor(point3d.X, point3d2.Y, 0.0);
					short num;
					Polyline polyline;
					checked
					{
						long val = (long)Math.Round(unchecked(point3d.X - point3d2.X));
						long val2 = (long)Math.Round(unchecked(point3d.Y - point3d2.Y));
						num = (short)(Math.Min(val, val2) / unchecked((long)this.short_0));
						polyline = new Polyline();
						polyline.SetDatabaseDefaults();
					}
					if (num > 10)
					{
						Polyline polyline2 = polyline;
						int num2 = 0;
						Point2d point2d;
						point2d..ctor(point3d.X, point3d.Y);
						polyline2.AddVertexAt(num2, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline3 = polyline;
						int num3 = 1;
						point2d..ctor(point3d.X, point3d.Y - (double)(checked(3 * this.short_0)));
						polyline3.AddVertexAt(num3, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline4 = polyline;
						int num4 = 2;
						point2d..ctor(point3d.X - (double)(checked(9 * this.short_0)), point3d.Y - (double)(checked(3 * this.short_0)));
						polyline4.AddVertexAt(num4, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline5 = polyline;
						int num5 = 3;
						point2d..ctor(point3d.X - (double)(checked(9 * this.short_0)), point3d.Y - (double)(checked(6 * this.short_0)));
						polyline5.AddVertexAt(num5, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline6 = polyline;
						int num6 = 4;
						point2d..ctor(point3d.X, point3d.Y - (double)(checked(6 * this.short_0)));
						polyline6.AddVertexAt(num6, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline7 = polyline;
						int num7 = 5;
						point2d..ctor(point3d6.X, point3d6.Y + (double)(checked(6 * this.short_0)));
						polyline7.AddVertexAt(num7, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline8 = polyline;
						int num8 = 6;
						point2d..ctor(point3d6.X - (double)(checked(9 * this.short_0)), point3d6.Y + (double)(checked(6 * this.short_0)));
						polyline8.AddVertexAt(num8, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline9 = polyline;
						int num9 = 7;
						point2d..ctor(point3d6.X - (double)(checked(9 * this.short_0)), point3d6.Y + (double)(checked(3 * this.short_0)));
						polyline9.AddVertexAt(num9, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline10 = polyline;
						int num10 = 8;
						point2d..ctor(point3d6.X, point3d6.Y + (double)(checked(3 * this.short_0)));
						polyline10.AddVertexAt(num10, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline11 = polyline;
						int num11 = 9;
						point2d..ctor(point3d6.X, point3d6.Y);
						polyline11.AddVertexAt(num11, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline12 = polyline;
						int num12 = 10;
						point2d..ctor(point3d6.X - (double)(checked(3 * this.short_0)), point3d6.Y);
						polyline12.AddVertexAt(num12, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline13 = polyline;
						int num13 = 11;
						point2d..ctor(point3d6.X - (double)(checked(3 * this.short_0)), point3d6.Y + (double)(checked(9 * this.short_0)));
						polyline13.AddVertexAt(num13, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline14 = polyline;
						int num14 = 12;
						point2d..ctor(point3d6.X - (double)(checked(6 * this.short_0)), point3d6.Y + (double)(checked(9 * this.short_0)));
						polyline14.AddVertexAt(num14, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline15 = polyline;
						int num15 = 13;
						point2d..ctor(point3d6.X - (double)(checked(6 * this.short_0)), point3d6.Y);
						polyline15.AddVertexAt(num15, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline16 = polyline;
						int num16 = 14;
						point2d..ctor(point3d2.X + (double)(checked(6 * this.short_0)), point3d2.Y);
						polyline16.AddVertexAt(num16, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline17 = polyline;
						int num17 = 15;
						point2d..ctor(point3d2.X + (double)(checked(6 * this.short_0)), point3d2.Y + (double)(checked(9 * this.short_0)));
						polyline17.AddVertexAt(num17, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline18 = polyline;
						int num18 = 16;
						point2d..ctor(point3d2.X + (double)(checked(3 * this.short_0)), point3d2.Y + (double)(checked(9 * this.short_0)));
						polyline18.AddVertexAt(num18, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline19 = polyline;
						int num19 = 17;
						point2d..ctor(point3d2.X + (double)(checked(3 * this.short_0)), point3d2.Y);
						polyline19.AddVertexAt(num19, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline20 = polyline;
						int num20 = 18;
						point2d..ctor(point3d2.X, point3d2.Y);
						polyline20.AddVertexAt(num20, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline21 = polyline;
						int num21 = 19;
						point2d..ctor(point3d2.X, point3d2.Y + (double)(checked(3 * this.short_0)));
						polyline21.AddVertexAt(num21, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline22 = polyline;
						int num22 = 20;
						point2d..ctor(point3d2.X + (double)(checked(9 * this.short_0)), point3d2.Y + (double)(checked(3 * this.short_0)));
						polyline22.AddVertexAt(num22, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline23 = polyline;
						int num23 = 21;
						point2d..ctor(point3d2.X + (double)(checked(9 * this.short_0)), point3d2.Y + (double)(checked(6 * this.short_0)));
						polyline23.AddVertexAt(num23, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline24 = polyline;
						int num24 = 22;
						point2d..ctor(point3d2.X, point3d2.Y + (double)(checked(6 * this.short_0)));
						polyline24.AddVertexAt(num24, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline25 = polyline;
						int num25 = 23;
						point2d..ctor(point3d2.X, point3d2.Y + (double)(checked(6 * this.short_0)));
						polyline25.AddVertexAt(num25, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline26 = polyline;
						int num26 = 24;
						point2d..ctor(point3d5.X, point3d5.Y - (double)(checked(6 * this.short_0)));
						polyline26.AddVertexAt(num26, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline27 = polyline;
						int num27 = 25;
						point2d..ctor(point3d5.X + (double)(checked(9 * this.short_0)), point3d5.Y - (double)(checked(6 * this.short_0)));
						polyline27.AddVertexAt(num27, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline28 = polyline;
						int num28 = 26;
						point2d..ctor(point3d5.X + (double)(checked(9 * this.short_0)), point3d5.Y - (double)(checked(3 * this.short_0)));
						polyline28.AddVertexAt(num28, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline29 = polyline;
						int num29 = 27;
						point2d..ctor(point3d5.X, point3d5.Y - (double)(checked(3 * this.short_0)));
						polyline29.AddVertexAt(num29, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline30 = polyline;
						int num30 = 28;
						point2d..ctor(point3d5.X, point3d5.Y);
						polyline30.AddVertexAt(num30, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline31 = polyline;
						int num31 = 29;
						point2d..ctor(point3d5.X + (double)(checked(3 * this.short_0)), point3d5.Y);
						polyline31.AddVertexAt(num31, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline32 = polyline;
						int num32 = 30;
						point2d..ctor(point3d5.X + (double)(checked(3 * this.short_0)), point3d5.Y - (double)(checked(9 * this.short_0)));
						polyline32.AddVertexAt(num32, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline33 = polyline;
						int num33 = 31;
						point2d..ctor(point3d5.X + (double)(checked(6 * this.short_0)), point3d5.Y - (double)(checked(9 * this.short_0)));
						polyline33.AddVertexAt(num33, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline34 = polyline;
						int num34 = 32;
						point2d..ctor(point3d5.X + (double)(checked(6 * this.short_0)), point3d5.Y);
						polyline34.AddVertexAt(num34, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline35 = polyline;
						int num35 = 33;
						point2d..ctor(point3d.X - (double)(checked(6 * this.short_0)), point3d.Y);
						polyline35.AddVertexAt(num35, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline36 = polyline;
						int num36 = 34;
						point2d..ctor(point3d.X - (double)(checked(6 * this.short_0)), point3d.Y - (double)(checked(9 * this.short_0)));
						polyline36.AddVertexAt(num36, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline37 = polyline;
						int num37 = 35;
						point2d..ctor(point3d.X - (double)(checked(3 * this.short_0)), point3d.Y - (double)(checked(9 * this.short_0)));
						polyline37.AddVertexAt(num37, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline38 = polyline;
						int num38 = 36;
						point2d..ctor(point3d.X - (double)(checked(3 * this.short_0)), point3d.Y);
						polyline38.AddVertexAt(num38, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						polyline.Closed = true;
					}
					else
					{
						Polyline polyline39 = polyline;
						int num39 = 0;
						Point2d point2d;
						point2d..ctor(point3d.X, point3d.Y);
						polyline39.AddVertexAt(num39, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline40 = polyline;
						int num40 = 1;
						point2d..ctor(point3d2.X, point3d.Y);
						polyline40.AddVertexAt(num40, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline41 = polyline;
						int num41 = 2;
						point2d..ctor(point3d2.X, point3d2.Y);
						polyline41.AddVertexAt(num41, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						Polyline polyline42 = polyline;
						int num42 = 3;
						point2d..ctor(point3d.X, point3d2.Y);
						polyline42.AddVertexAt(num42, point2d, 0.0, (double)this.short_0, (double)this.short_0);
						polyline.Closed = true;
					}
					polyline.Layer = "注释";
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
	}
}
