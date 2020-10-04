using System;
using System.Diagnostics;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 吊筋
	{
		[DebuggerNonUserCode]
		public 吊筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("吊筋")]
		public void 吊筋()
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d point3d = CAD.GetPoint("选择插入点: ");
				IL_17:
				num2 = 3;
				Point3d point3d2;
				if (!(point3d == point3d2))
				{
					goto IL_29;
				}
				IL_24:
				goto IL_311;
				IL_29:
				num2 = 6;
				double num3 = Class36.smethod_34(ref point3d);
				IL_34:
				num2 = 7;
				num3 = num3 * 180.0 / 3.1415926535897931;
				IL_4E:
				num2 = 8;
				Polyline polyline = new Polyline();
				IL_56:
				num2 = 9;
				Point3d pointAngle = CAD.GetPointAngle(point3d, 75.0, num3 + 90.0);
				IL_76:
				num2 = 10;
				point3d = CAD.GetPointAngle(point3d, 75.0, num3 - 90.0);
				IL_97:
				num2 = 11;
				polyline.AddVertexAt(0, Class36.smethod_38(CAD.GetPointAngle(pointAngle, 350.0, num3)), 0.0, 45.0, 45.0);
				IL_D2:
				num2 = 12;
				polyline.AddVertexAt(1, Class36.smethod_38(CAD.GetPointAngle(pointAngle, 150.0, num3)), 0.0, 45.0, 45.0);
				IL_10D:
				num2 = 13;
				polyline.AddVertexAt(2, Class36.smethod_38(CAD.GetPointAngle(point3d, 100.0, num3)), 0.0, 45.0, 45.0);
				IL_149:
				num2 = 14;
				polyline.AddVertexAt(3, Class36.smethod_38(CAD.GetPointAngle(point3d, 100.0, num3 + 180.0)), 0.0, 45.0, 45.0);
				IL_18F:
				num2 = 15;
				polyline.AddVertexAt(4, Class36.smethod_38(CAD.GetPointAngle(pointAngle, 150.0, num3 + 180.0)), 0.0, 45.0, 45.0);
				IL_1D4:
				num2 = 16;
				polyline.AddVertexAt(5, Class36.smethod_38(CAD.GetPointAngle(pointAngle, 350.0, num3 + 180.0)), 0.0, 45.0, 45.0);
				IL_219:
				num2 = 17;
				polyline.ColorIndex = 10;
				IL_224:
				num2 = 18;
				CAD.AddEnt(polyline);
				IL_22E:
				num2 = 19;
				if (Information.Err().Number <= 0)
				{
					goto IL_255;
				}
				IL_240:
				num2 = 20;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_255:
				goto IL_311;
				IL_25A:
				goto IL_306;
				IL_25F:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_277;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_2E0;
				IL_277:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_2E0:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_25F;
			}
			IL_306:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_311:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
