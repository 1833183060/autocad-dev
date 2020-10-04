using System;
using System.Diagnostics;
using System.Windows;
using Autodesk.AutoCAD.ApplicationServices;
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
	public class 单点引注Y_PL : DrawJig
	{
		[DebuggerNonUserCode]
		public 单点引注Y_PL()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDDYZ4")]
		public void TcDDYZ4()
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
				CAD.CreateLayer("Y_引注", 4, "continuous", -3, false, true);
				IL_21:
				num2 = 3;
				CAD.CreateLayer("Y_引线", 5, "continuous", 13, false, true);
				IL_39:
				num2 = 4;
				this.double_0 = CAD.GetScale();
				IL_47:
				num2 = 5;
				DBText dbtext = new DBText();
				IL_51:
				num2 = 6;
				dbtext.Height = 300.0 * this.double_0;
				IL_6B:
				num2 = 7;
				dbtext.Rotation = 1.5707963267948966;
				IL_7E:
				num2 = 8;
				dbtext.WidthFactor = 0.7;
				IL_91:
				num2 = 9;
				this.string_0 = Clipboard.GetText();
				IL_A0:
				num2 = 10;
				if (Operators.CompareString(this.string_0, "", false) != 0)
				{
					goto IL_C9;
				}
				IL_BA:
				num2 = 11;
				this.string_0 = "%%1328@200";
				IL_C9:
				num2 = 13;
				if (this.string_0.Length <= 50)
				{
					goto IL_100;
				}
				IL_DE:
				num2 = 14;
				this.string_0 = this.string_0.Substring(0, 40) + "……";
				IL_100:
				num2 = 16;
				dbtext.TextString = this.string_0;
				IL_111:
				num2 = 17;
				this.double_1 = dbtext.GeometricExtents.MaxPoint.Y - dbtext.GeometricExtents.MinPoint.Y;
				IL_14E:
				num2 = 18;
				bool flag = false;
				IL_155:
				num2 = 19;
				this.entity_0 = new Entity[2];
				IL_165:
				num2 = 22;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_175:
				num2 = 23;
				PromptPointOptions promptPointOptions = new PromptPointOptions("插入点:");
				IL_185:
				num2 = 24;
				PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
				IL_199:
				num2 = 25;
				if (point.Status != 5100)
				{
					goto IL_288;
				}
				IL_1B0:
				num2 = 26;
				this.point3d_2 = point.Value;
				IL_1C1:
				num2 = 27;
				PromptResult promptResult = mdiActiveDocument.Editor.Drag(this);
				IL_1D4:
				num2 = 28;
				if (promptResult.Status != 5100)
				{
					goto IL_288;
				}
				IL_1EB:
				num2 = 29;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_1FC:
					num2 = 30;
					if (num3 != 0)
					{
						goto IL_21B;
					}
					IL_207:
					num2 = 31;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_288;
					IL_21B:
					num2 = 33;
					IL_21F:
					num2 = 34;
					array = new ObjectId[(int)(num3 + 1)];
					IL_22E:
					num2 = 35;
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
					IL_242:
					num2 = 36;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_265:
					num2 = 37;
					num6 += 1;
				}
				IL_274:
				num2 = 38;
				if (!flag)
				{
					goto IL_288;
				}
				IL_27C:
				num2 = 39;
				Class36.smethod_55(array);
				IL_288:
				goto IL_399;
				IL_28D:
				goto IL_3A4;
				IL_292:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_2AE;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_373;
				IL_2AE:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_373:
				goto IL_3A4;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_292;
			}
			IL_399:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_3A4:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		protected override SamplerStatus Sampler(JigPrompts prompts)
		{
			PromptPointResult promptPointResult = prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
			{
				Cursor = 3,
				UseBasePoint = false
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				Polyline polyline = new Polyline();
				polyline.Layer = "Y_引线";
				this.entity_0[0] = polyline;
				Point3d point3d;
				Point3d pointXY;
				if (this.point3d_2.Y < value.Y)
				{
					point3d..ctor(value.X, value.Y + this.double_1 * 1.1, 0.0);
					pointXY = CAD.GetPointXY(value, -50.0 * this.double_0, 0.05 * this.double_1);
				}
				else
				{
					point3d..ctor(value.X, value.Y - this.double_1 * 1.1, 0.0);
					pointXY = CAD.GetPointXY(value, -50.0 * this.double_0, -1.05 * this.double_1);
				}
				double num = CAD.P2P_AngleV(value, this.point3d_2);
				if (num < 1.7453292519943295 & num > 1.3962634015954636)
				{
					point3d..ctor(this.point3d_2.X, value.Y + this.double_1 * 1.1, 0.0);
					pointXY..ctor(this.point3d_2.X, value.Y, 0.0);
					pointXY = CAD.GetPointXY(pointXY, -50.0 * this.double_0, 0.05 * this.double_1);
					Polyline polyline2 = polyline;
					int num2 = 0;
					Point2d point2d;
					point2d..ctor(this.point3d_2.X, this.point3d_2.Y);
					polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
					Polyline polyline3 = polyline;
					int num3 = 1;
					point2d..ctor(point3d.X, point3d.Y);
					polyline3.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
				}
				else if (num > 4.5378560551852569 & num < 4.8869219055841224)
				{
					point3d..ctor(this.point3d_2.X, value.Y - this.double_1 * 1.1, 0.0);
					pointXY..ctor(this.point3d_2.X, value.Y, 0.0);
					pointXY = CAD.GetPointXY(pointXY, -50.0 * this.double_0, -1.05 * this.double_1);
					Polyline polyline4 = polyline;
					int num4 = 0;
					Point2d point2d;
					point2d..ctor(this.point3d_2.X, this.point3d_2.Y);
					polyline4.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
					Polyline polyline5 = polyline;
					int num5 = 1;
					point2d..ctor(point3d.X, point3d.Y);
					polyline5.AddVertexAt(num5, point2d, 0.0, 0.0, 0.0);
				}
				else
				{
					Polyline polyline6 = polyline;
					int num6 = 0;
					Point2d point2d;
					point2d..ctor(this.point3d_2.X, this.point3d_2.Y);
					polyline6.AddVertexAt(num6, point2d, 0.0, 0.0, 0.0);
					Polyline polyline7 = polyline;
					int num7 = 1;
					point2d..ctor(value.X, value.Y);
					polyline7.AddVertexAt(num7, point2d, 0.0, 0.0, 0.0);
					Polyline polyline8 = polyline;
					int num8 = 2;
					point2d..ctor(point3d.X, point3d.Y);
					polyline8.AddVertexAt(num8, point2d, 0.0, 0.0, 0.0);
				}
				DBText dbtext = new DBText();
				dbtext.Height = 300.0 * this.double_0;
				dbtext.Rotation = 1.5707963267948966;
				dbtext.TextString = this.string_0;
				dbtext.WidthFactor = 0.7;
				dbtext.Position = pointXY;
				dbtext.Layer = "Y_引注";
				this.entity_0[1] = dbtext;
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

		private string string_0;

		private double double_1;

		private Point3d point3d_2;
	}
}
