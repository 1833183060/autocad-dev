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
	public class 拉筋 : DrawJig
	{
		public 拉筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
		}

		[CommandMethod("TcLaJin")]
		public void TcLaJin()
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
				goto IL_1F9;
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
				IL_84:
				num2 = 12;
				if (promptResult.Status != 5100)
				{
					goto IL_134;
				}
				IL_9A:
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
						goto IL_C7;
					}
					IL_B4:
					num2 = 15;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_134;
					IL_C7:
					num2 = 17;
					IL_CA:
					num2 = 18;
					array = new ObjectId[(int)(num3 + 1)];
					IL_D7:
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
					IL_EC:
					num2 = 20;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_10F:
					num2 = 21;
					num6 += 1;
				}
				IL_123:
				num2 = 22;
				if (!flag)
				{
					goto IL_134;
				}
				IL_12A:
				num2 = 23;
				Class36.smethod_55(array);
				IL_134:
				goto IL_1F9;
				IL_139:
				goto IL_203;
				IL_13E:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_155;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_1D4;
				IL_155:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_1D4:
				goto IL_203;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_13E;
			}
			IL_1F9:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_203:
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
				Point3d point3d = this.point3d_0;
				Point3d point3d2 = value;
				if (point3d.X > point3d2.X)
				{
					Point3d point3d3 = point3d;
					point3d = point3d2;
					point3d2 = point3d3;
				}
				else if (point3d.X == point3d2.X & point3d.Y > point3d2.Y)
				{
					Point3d point3d4 = point3d;
					point3d = point3d2;
					point3d2 = point3d4;
				}
				double num = CAD.P2P_Angle(point3d, point3d2);
				point3d = CAD.GetPointAngle(point3d, 80.0 * this.double_0, num * 180.0 / 3.1415926535897931 + 90.0);
				point3d2 = CAD.GetPointAngle(point3d2, 80.0 * this.double_0, num * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle = CAD.GetPointAngle(point3d, 148.0 * this.double_0, num * 180.0 / 3.1415926535897931 - 102.0);
				Point3d pointAngle2 = CAD.GetPointAngle(point3d2, 148.0 * this.double_0, num * 180.0 / 3.1415926535897931 - 68.0);
				Point3d pointAngle3 = CAD.GetPointAngle(point3d, 257.0 * this.double_0, num * 180.0 / 3.1415926535897931 - 68.0);
				Point3d pointAngle4 = CAD.GetPointAngle(point3d2, 257.0 * this.double_0, num * 180.0 / 3.1415926535897931 - 102.0);
				Polyline polyline = new Polyline();
				polyline.SetDatabaseDefaults();
				double num2 = Math.Tan(Math.Atan(1.0) * 4.0 * 135.0 / 180.0 / 4.0);
				Polyline polyline2 = polyline;
				int num3 = 0;
				Point2d point2d;
				point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
				polyline2.AddVertexAt(num3, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline3 = polyline;
				int num4 = 1;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline3.AddVertexAt(num4, point2d, -num2, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline4 = polyline;
				int num5 = 2;
				point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
				polyline4.AddVertexAt(num5, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline5 = polyline;
				int num6 = 3;
				point2d..ctor(point3d2.get_Coordinate(0), point3d2.get_Coordinate(1));
				polyline5.AddVertexAt(num6, point2d, -num2, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline6 = polyline;
				int num7 = 4;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline6.AddVertexAt(num7, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline7 = polyline;
				int num8 = 5;
				point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
				polyline7.AddVertexAt(num8, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				polyline.Layer = "钢筋";
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
