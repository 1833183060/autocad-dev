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
	public class 绘制圆钩 : DrawJig
	{
		public 绘制圆钩()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
		}

		[CommandMethod("TcYuanGou")]
		public void YuanGou()
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
				this.double_0 = CAD.GetScale();
				IL_17:
				num2 = 3;
				this.point3d_0 = CAD.GetPoint("选择插入点: ");
				IL_2A:
				num2 = 4;
				Point3d point3d;
				if (!(this.point3d_0 == point3d))
				{
					goto IL_41;
				}
				IL_3C:
				goto IL_1FF;
				IL_41:
				num2 = 7;
				bool flag = false;
				IL_47:
				num2 = 8;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_50:
				num2 = 9;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_65:
				num2 = 10;
				Class36.smethod_60("按下shift建，可切换方向:");
				IL_74:
				num2 = 11;
				PromptResult promptResult = editor.Drag(this);
				IL_82:
				num2 = 12;
				if (promptResult.Status != 5100)
				{
					goto IL_138;
				}
				IL_99:
				num2 = 13;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_AA:
					num2 = 14;
					if (num3 != 0)
					{
						goto IL_C9;
					}
					IL_B5:
					num2 = 15;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_138;
					IL_C9:
					num2 = 17;
					IL_CD:
					num2 = 18;
					array = new ObjectId[(int)(num3 + 1)];
					IL_DC:
					num2 = 19;
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
					IL_F0:
					num2 = 20;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_113:
					num2 = 21;
					num6 += 1;
				}
				IL_124:
				num2 = 22;
				if (!flag)
				{
					goto IL_138;
				}
				IL_12C:
				num2 = 23;
				Class36.smethod_55(array);
				IL_138:
				goto IL_1FF;
				IL_13D:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1B7:
				goto IL_1F4;
				IL_1B9:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_13D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1D2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1B9;
			}
			IL_1F4:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1FF:
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
			SamplerStatus result;
			if (promptPointResult.Status != -5002)
			{
				Point3d value = promptPointResult.Value;
				if (value != this.point3d_1)
				{
					Point3d p = this.point3d_0;
					Point3d point3d = value;
					double num = p.GetVectorTo(point3d).AngleOnPlane(new Plane());
					short num2 = checked((short)Class36.GetKeyState(160L));
					Point3d pointAngle = CAD.GetPointAngle(p, 100.0 * this.double_0, num * 180.0 / 3.1415926535897931 + (double)-90f);
					Point3d pointAngle2 = CAD.GetPointAngle(pointAngle, 141.0 * this.double_0, num * 180.0 / 3.1415926535897931);
					Polyline polyline = new Polyline();
					polyline.SetDatabaseDefaults();
					double num3 = Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
					Polyline polyline2 = polyline;
					int num4 = 0;
					Point2d point2d;
					point2d..ctor(p.get_Coordinate(0), p.get_Coordinate(1));
					polyline2.AddVertexAt(num4, point2d, -num3, 45.0 * this.double_0, 45.0 * this.double_0);
					Polyline polyline3 = polyline;
					int num5 = 1;
					point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
					polyline3.AddVertexAt(num5, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
					Polyline polyline4 = polyline;
					int num6 = 2;
					point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
					polyline4.AddVertexAt(num6, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
					CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
					polyline.Layer = "钢筋";
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

		private double double_0;
	}
}
