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
	public class 负筋 : DrawJig
	{
		public 负筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
		}

		[CommandMethod("TcFuJin")]
		public void TcFuJin()
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
				goto IL_1FC;
				IL_3E:
				num2 = 7;
				CAD.CreateLayer("负筋", 14, "continuous", -1, false, true);
				IL_55:
				num2 = 8;
				bool flag = false;
				IL_59:
				num2 = 9;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_62:
				num2 = 10;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_76:
				num2 = 11;
				PromptResult promptResult = editor.Drag(this);
				IL_83:
				num2 = 12;
				if (promptResult.Status != 5100)
				{
					goto IL_132;
				}
				IL_99:
				num2 = 13;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_A8:
					num2 = 14;
					if (num3 != 0)
					{
						goto IL_C4;
					}
					IL_B1:
					num2 = 15;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_132;
					IL_C4:
					num2 = 17;
					IL_C7:
					num2 = 18;
					array = new ObjectId[(int)(num3 + 1)];
					IL_D4:
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
					IL_E9:
					num2 = 20;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_10D:
					num2 = 21;
					num6 += 1;
				}
				IL_121:
				num2 = 22;
				if (!flag)
				{
					goto IL_132;
				}
				IL_127:
				num2 = 23;
				Class36.smethod_55(array);
				IL_132:
				goto IL_1FC;
				IL_137:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1B3:
				goto IL_1F1;
				IL_1B5:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_137;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1CE:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1B5;
			}
			IL_1F1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1FC:
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
				Point3d point3d = this.point3d_0;
				Point3d point3d2 = value;
				double num = CAD.P2P_Angle(point3d, point3d2);
				Point3d pointAngle = CAD.GetPointAngle(point3d, 200.0 * this.double_0, num * 180.0 / 3.1415926535897931 - 90.0);
				Point3d pointAngle2 = CAD.GetPointAngle(point3d2, 200.0 * this.double_0, num * 180.0 / 3.1415926535897931 - 90.0);
				Polyline polyline = new Polyline();
				polyline.SetDatabaseDefaults();
				Polyline polyline2 = polyline;
				int num2 = 0;
				Point2d point2d;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline2.AddVertexAt(num2, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline3 = polyline;
				int num3 = 1;
				point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
				polyline3.AddVertexAt(num3, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline4 = polyline;
				int num4 = 2;
				point2d..ctor(point3d2.get_Coordinate(0), point3d2.get_Coordinate(1));
				polyline4.AddVertexAt(num4, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline5 = polyline;
				int num5 = 3;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline5.AddVertexAt(num5, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				polyline.Layer = "负筋";
				this.entity_0[0] = polyline;
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

		private double double_0;
	}
}
