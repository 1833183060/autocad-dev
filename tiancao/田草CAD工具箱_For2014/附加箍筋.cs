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
	public class 附加箍筋 : DrawJig
	{
		public 附加箍筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[6];
		}

		[CommandMethod("附加箍筋")]
		public void FuJiaGuJin()
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
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_17:
				num2 = 3;
				Point3d point3d;
				if (!(point == point3d))
				{
					goto IL_29;
				}
				IL_24:
				goto IL_1F7;
				IL_29:
				num2 = 6;
				bool flag = false;
				IL_2E:
				num2 = 7;
				IL_30:
				num2 = 8;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_38:
				num2 = 9;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_4C:
				num2 = 10;
				PromptResult promptResult = editor.Drag(this);
				IL_59:
				num2 = 11;
				ObjectId[] array = new ObjectId[6];
				IL_64:
				num2 = 12;
				if (promptResult.Status != 5100)
				{
					goto IL_10A;
				}
				IL_7A:
				num2 = 13;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_89:
					num2 = 14;
					if (num3 != 0)
					{
						goto IL_A5;
					}
					IL_92:
					num2 = 15;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_10A;
					IL_A5:
					num2 = 17;
					IL_A8:
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
					IL_BD:
					num2 = 19;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_E1:
					num2 = 20;
					num6 += 1;
				}
				IL_F5:
				num2 = 21;
				if (!flag)
				{
					goto IL_107;
				}
				IL_FC:
				num2 = 22;
				Class36.smethod_55(array);
				IL_107:
				num2 = 24;
				IL_10A:
				num2 = 27;
				JigEntIDs jigEntIDs = new JigEntIDs();
				IL_113:
				num2 = 28;
				jigEntIDs.method_0(array, this.point3d_1);
				IL_125:
				goto IL_1F7;
				IL_12A:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1AE:
				goto IL_1EC;
				IL_1B0:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_12A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1C9:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1B0;
			}
			IL_1EC:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1F7:
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
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				Point3d point3d = this.point3d_0;
				Point3d point3d2 = value;
				double num = CAD.P2P_Angle(point3d, point3d2) * 180.0 / 3.1415926535897931;
				Polyline polyline = new Polyline();
				Point3d pointAngle = CAD.GetPointAngle(point3d, 175.0, num + 90.0);
				Point3d pointAngle2 = CAD.GetPointAngle(point3d2, 175.0, num + 90.0);
				polyline.SetDatabaseDefaults();
				Polyline polyline2 = polyline;
				int num2 = 0;
				Point2d point2d;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline2.AddVertexAt(num2, point2d, 0.0, 45.0, 45.0);
				Polyline polyline3 = polyline;
				int num3 = 1;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline3.AddVertexAt(num3, point2d, 0.0, 45.0, 45.0);
				CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
				polyline.Layer = "钢筋";
				this.entity_0[0] = polyline;
				polyline = new Polyline();
				pointAngle = CAD.GetPointAngle(point3d, 250.0, num + 90.0);
				pointAngle2 = CAD.GetPointAngle(point3d2, 250.0, num + 90.0);
				polyline.SetDatabaseDefaults();
				Polyline polyline4 = polyline;
				int num4 = 0;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline4.AddVertexAt(num4, point2d, 0.0, 45.0, 45.0);
				Polyline polyline5 = polyline;
				int num5 = 1;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline5.AddVertexAt(num5, point2d, 0.0, 45.0, 45.0);
				polyline.Layer = "钢筋";
				this.entity_0[1] = polyline;
				polyline = new Polyline();
				pointAngle = CAD.GetPointAngle(point3d, 325.0, num + 90.0);
				pointAngle2 = CAD.GetPointAngle(point3d2, 325.0, num + 90.0);
				polyline.SetDatabaseDefaults();
				Polyline polyline6 = polyline;
				int num6 = 0;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline6.AddVertexAt(num6, point2d, 0.0, 45.0, 45.0);
				Polyline polyline7 = polyline;
				int num7 = 1;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline7.AddVertexAt(num7, point2d, 0.0, 45.0, 45.0);
				polyline.Layer = "钢筋";
				this.entity_0[2] = polyline;
				polyline = new Polyline();
				pointAngle = CAD.GetPointAngle(point3d, 175.0, num - 90.0);
				pointAngle2 = CAD.GetPointAngle(point3d2, 175.0, num - 90.0);
				polyline.SetDatabaseDefaults();
				Polyline polyline8 = polyline;
				int num8 = 0;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline8.AddVertexAt(num8, point2d, 0.0, 45.0, 45.0);
				Polyline polyline9 = polyline;
				int num9 = 1;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline9.AddVertexAt(num9, point2d, 0.0, 45.0, 45.0);
				polyline.Layer = "钢筋";
				this.entity_0[3] = polyline;
				polyline = new Polyline();
				pointAngle = CAD.GetPointAngle(point3d, 250.0, num - 90.0);
				pointAngle2 = CAD.GetPointAngle(point3d2, 250.0, num - 90.0);
				polyline.SetDatabaseDefaults();
				Polyline polyline10 = polyline;
				int num10 = 0;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline10.AddVertexAt(num10, point2d, 0.0, 45.0, 45.0);
				Polyline polyline11 = polyline;
				int num11 = 1;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline11.AddVertexAt(num11, point2d, 0.0, 45.0, 45.0);
				polyline.Layer = "钢筋";
				this.entity_0[4] = polyline;
				polyline = new Polyline();
				pointAngle = CAD.GetPointAngle(point3d, 325.0, num - 90.0);
				pointAngle2 = CAD.GetPointAngle(point3d2, 325.0, num - 90.0);
				polyline.SetDatabaseDefaults();
				Polyline polyline12 = polyline;
				int num12 = 0;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline12.AddVertexAt(num12, point2d, 0.0, 45.0, 45.0);
				Polyline polyline13 = polyline;
				int num13 = 1;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline13.AddVertexAt(num13, point2d, 0.0, 45.0, 45.0);
				polyline.Layer = "钢筋";
				this.entity_0[5] = polyline;
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
	}
}
