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
	public class 绘制梁箍筋和纵筋 : DrawJig
	{
		public 绘制梁箍筋和纵筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[5];
		}

		[CommandMethod("TcGuJin2")]
		public void TcGuJin2()
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
				goto IL_21E;
				IL_3E:
				num2 = 7;
				CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
				IL_55:
				num2 = 8;
				bool flag = false;
				IL_5A:
				num2 = 9;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_63:
				num2 = 10;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_77:
				num2 = 11;
				PromptResult promptResult = editor.Drag(this);
				IL_83:
				num2 = 12;
				if (promptResult.Status != 5100)
				{
					goto IL_143;
				}
				IL_98:
				num2 = 13;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_A7:
					num2 = 14;
					editor.WriteMessage(num3.ToString());
					IL_B8:
					num2 = 15;
					if (num3 != 0)
					{
						goto IL_D4;
					}
					IL_C1:
					num2 = 16;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_143;
					IL_D4:
					num2 = 18;
					IL_D7:
					num2 = 19;
					array = new ObjectId[(int)(num3 + 1)];
					IL_E4:
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
					IL_F9:
					num2 = 21;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_11D:
					num2 = 22;
					num6 += 1;
				}
				IL_131:
				num2 = 23;
				if (!flag)
				{
					goto IL_143;
				}
				IL_138:
				num2 = 24;
				Class36.smethod_55(array);
				IL_143:
				goto IL_21E;
				IL_148:
				goto IL_213;
				IL_14D:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_168;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_1ED;
				IL_168:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_1ED:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_14D;
			}
			IL_213:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21E:
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
				UseBasePoint = false
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				Point3d p = this.point3d_0;
				Point3d point3d = value;
				Point3d point3d2;
				point3d2..ctor(Math.Min(p.get_Coordinate(0), point3d.get_Coordinate(0)), Math.Min(p.get_Coordinate(1), point3d.get_Coordinate(1)), 0.0);
				Point3d point3d3;
				point3d3..ctor(Math.Max(p.get_Coordinate(0), point3d.get_Coordinate(0)), Math.Max(p.get_Coordinate(1), point3d.get_Coordinate(1)), 0.0);
				p = point3d3;
				point3d = point3d2;
				Point3d pointAngle = CAD.GetPointAngle(p, 120.0 * this.double_0, 270.0);
				Point3d pointAngle2 = CAD.GetPointAngle(pointAngle, 200.0 * this.double_0, 225.0);
				Point3d point3d4;
				point3d4..ctor(point3d.get_Coordinate(0), p.get_Coordinate(1), 0.0);
				Point3d point3d5;
				point3d5..ctor(p.get_Coordinate(0), point3d.get_Coordinate(1), 0.0);
				Point3d pointAngle3 = CAD.GetPointAngle(p, 120.0 * this.double_0, 180.0);
				Point3d pointAngle4 = CAD.GetPointAngle(pointAngle3, 200.0 * this.double_0, 225.0);
				Polyline polyline = new Polyline();
				polyline.SetDatabaseDefaults();
				Polyline polyline2 = polyline;
				int num = 0;
				Point2d point2d;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline2.AddVertexAt(num, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline3 = polyline;
				int num2 = 1;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline3.AddVertexAt(num2, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline4 = polyline;
				int num3 = 2;
				point2d..ctor(p.get_Coordinate(0), p.get_Coordinate(1));
				polyline4.AddVertexAt(num3, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline5 = polyline;
				int num4 = 3;
				point2d..ctor(point3d4.get_Coordinate(0), point3d4.get_Coordinate(1));
				polyline5.AddVertexAt(num4, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline6 = polyline;
				int num5 = 4;
				point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
				polyline6.AddVertexAt(num5, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline7 = polyline;
				int num6 = 5;
				point2d..ctor(point3d5.get_Coordinate(0), point3d5.get_Coordinate(1));
				polyline7.AddVertexAt(num6, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline8 = polyline;
				int num7 = 6;
				point2d..ctor(p.get_Coordinate(0), p.get_Coordinate(1));
				polyline8.AddVertexAt(num7, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline9 = polyline;
				int num8 = 7;
				point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
				polyline9.AddVertexAt(num8, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline10 = polyline;
				int num9 = 8;
				point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
				polyline10.AddVertexAt(num9, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				polyline.Layer = "钢筋";
				this.entity_0[0] = polyline;
				pointAngle = CAD.GetPointAngle(point3d2, 120.0 * this.double_0, 225.0);
				pointAngle2 = CAD.GetPointAngle(point3d3, 120.0 * this.double_0, 45.0);
				pointAngle = CAD.GetPointAngle(point3d2, 120.0 * this.double_0, 45.0);
				double num10 = Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
				Polyline polyline11 = new Polyline();
				Polyline polyline12 = polyline11;
				int num11 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline12.AddVertexAt(num11, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline13 = polyline11;
				int num12 = 1;
				point2d..ctor(pointAngle.X, pointAngle.Y - 20.0 * this.double_0);
				polyline13.AddVertexAt(num12, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline14 = polyline11;
				int num13 = 2;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline14.AddVertexAt(num13, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				polyline11.Layer = "钢筋";
				this.entity_0[1] = polyline11;
				pointAngle = CAD.GetPointAngle(point3d3, 120.0 * this.double_0, 225.0);
				polyline11 = new Polyline();
				Polyline polyline15 = polyline11;
				int num14 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline15.AddVertexAt(num14, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline16 = polyline11;
				int num15 = 1;
				point2d..ctor(pointAngle.X, pointAngle.Y - 20.0 * this.double_0);
				polyline16.AddVertexAt(num15, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline17 = polyline11;
				int num16 = 2;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline17.AddVertexAt(num16, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				polyline11.Layer = "钢筋";
				this.entity_0[2] = polyline11;
				pointAngle2..ctor(point3d2.get_Coordinate(0), point3d3.get_Coordinate(1), 0.0);
				pointAngle = CAD.GetPointAngle(pointAngle2, 120.0 * this.double_0, 315.0);
				polyline11 = new Polyline();
				Polyline polyline18 = polyline11;
				int num17 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline18.AddVertexAt(num17, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline19 = polyline11;
				int num18 = 1;
				point2d..ctor(pointAngle.X, pointAngle.Y - 20.0 * this.double_0);
				polyline19.AddVertexAt(num18, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline20 = polyline11;
				int num19 = 2;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline20.AddVertexAt(num19, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				polyline11.Layer = "钢筋";
				this.entity_0[3] = polyline11;
				pointAngle2..ctor(point3d3.get_Coordinate(0), point3d2.get_Coordinate(1), 0.0);
				pointAngle = CAD.GetPointAngle(pointAngle2, 120.0 * this.double_0, 135.0);
				polyline11 = new Polyline();
				Polyline polyline21 = polyline11;
				int num20 = 0;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline21.AddVertexAt(num20, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline22 = polyline11;
				int num21 = 1;
				point2d..ctor(pointAngle.X, pointAngle.Y - 20.0 * this.double_0);
				polyline22.AddVertexAt(num21, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				Polyline polyline23 = polyline11;
				int num22 = 2;
				point2d..ctor(pointAngle.X, pointAngle.Y + 20.0 * this.double_0);
				polyline23.AddVertexAt(num22, point2d, num10, 40.0 * this.double_0, 40.0 * this.double_0);
				polyline11.Layer = "钢筋";
				this.entity_0[4] = polyline11;
				this.point3d_1 = value;
				result = 0;
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

		private Entity entity_1;

		private Entity entity_2;

		private Entity entity_3;

		private Entity entity_4;

		private double double_0;
	}
}
