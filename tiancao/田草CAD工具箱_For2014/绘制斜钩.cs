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
	public class 绘制斜钩 : DrawJig
	{
		public 绘制斜钩()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
		}

		[CommandMethod("TcXieGou")]
		public void XieGou()
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
				goto IL_1E0;
				IL_3E:
				num2 = 7;
				bool flag = false;
				IL_42:
				num2 = 8;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_4A:
				num2 = 9;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_5E:
				num2 = 10;
				PromptResult promptResult = editor.Drag(this);
				IL_6B:
				num2 = 11;
				if (promptResult.Status != 5100)
				{
					goto IL_11A;
				}
				IL_81:
				num2 = 12;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_91:
					num2 = 13;
					if (num3 != 0)
					{
						goto IL_AE;
					}
					IL_9B:
					num2 = 14;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_11A;
					IL_AE:
					num2 = 16;
					IL_B1:
					num2 = 17;
					array = new ObjectId[(int)(num3 + 1)];
					IL_BE:
					num2 = 18;
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
					IL_D3:
					num2 = 19;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_F6:
					num2 = 20;
					num6 += 1;
				}
				IL_10A:
				num2 = 21;
				if (!flag)
				{
					goto IL_11A;
				}
				IL_110:
				num2 = 22;
				Class36.smethod_55(array);
				IL_11A:
				goto IL_1E0;
				IL_11F:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_197:
				goto IL_1D5;
				IL_199:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_11F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1B2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_199;
			}
			IL_1D5:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1E0:
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
					Point3d pointAngle = CAD.GetPointAngle(p, 200.0 * this.double_0, num * 180.0 / 3.1415926535897931);
					Polyline polyline = new Polyline();
					polyline.SetDatabaseDefaults();
					Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
					Polyline polyline2 = polyline;
					int num2 = 0;
					Point2d point2d;
					point2d..ctor(p.get_Coordinate(0), p.get_Coordinate(1));
					polyline2.AddVertexAt(num2, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
					Polyline polyline3 = polyline;
					int num3 = 1;
					point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
					polyline3.AddVertexAt(num3, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
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
