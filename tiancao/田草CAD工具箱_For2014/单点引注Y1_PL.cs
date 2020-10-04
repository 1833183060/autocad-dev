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
	public class 单点引注Y1_PL : DrawJig
	{
		[DebuggerNonUserCode]
		public 单点引注Y1_PL()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDDYZ6")]
		public void TcDDYZ6()
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
				IL_20:
				num2 = 3;
				CAD.CreateLayer("Y_引线", 5, "continuous", 13, false, true);
				IL_37:
				num2 = 4;
				this.double_0 = CAD.GetScale();
				IL_44:
				num2 = 5;
				DBText dbtext = new DBText();
				IL_4D:
				num2 = 6;
				dbtext.Height = 300.0;
				IL_5F:
				num2 = 7;
				dbtext.WidthFactor = 0.7;
				IL_71:
				num2 = 8;
				this.string_0 = Clipboard.GetText();
				IL_7E:
				num2 = 9;
				if (Operators.CompareString(this.string_0, "", false) != 0)
				{
					goto IL_C4;
				}
				IL_97:
				num2 = 10;
				this.entity_0 = new Entity[3];
				IL_A6:
				num2 = 13;
				this.double_1 = 300.0 * this.double_0;
				goto IL_15E;
				IL_C4:
				num2 = 15;
				IL_C7:
				num2 = 16;
				this.entity_0 = new Entity[4];
				IL_D6:
				num2 = 19;
				if (this.string_0.Length <= 50)
				{
					goto IL_10B;
				}
				IL_EA:
				num2 = 20;
				this.string_0 = this.string_0.Substring(0, 40) + "……";
				IL_10B:
				num2 = 22;
				dbtext.TextString = this.string_0;
				IL_11B:
				num2 = 23;
				this.double_1 = (dbtext.GeometricExtents.MaxPoint.X - dbtext.GeometricExtents.MinPoint.X) * this.double_0;
				IL_15E:
				num2 = 25;
				bool flag = false;
				IL_164:
				num2 = 26;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_172:
				num2 = 27;
				PromptPointOptions promptPointOptions = new PromptPointOptions("插入点:");
				IL_180:
				num2 = 28;
				PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
				IL_191:
				num2 = 29;
				if (point.Status != 5100)
				{
					goto IL_27B;
				}
				IL_1A7:
				num2 = 30;
				this.point3d_2 = point.Value;
				IL_1B7:
				num2 = 31;
				PromptResult promptResult = mdiActiveDocument.Editor.Drag(this);
				IL_1C8:
				num2 = 32;
				if (promptResult.Status != 5100)
				{
					goto IL_27B;
				}
				IL_1DE:
				num2 = 33;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_1EE:
					num2 = 34;
					if (num3 != 0)
					{
						goto IL_20B;
					}
					IL_1F8:
					num2 = 35;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_27B;
					IL_20B:
					num2 = 37;
					IL_20E:
					num2 = 38;
					array = new ObjectId[(int)(num3 + 1)];
					IL_21C:
					num2 = 39;
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
					IL_231:
					num2 = 40;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_255:
					num2 = 41;
					num6 += 1;
				}
				IL_269:
				num2 = 42;
				if (!flag)
				{
					goto IL_27B;
				}
				IL_270:
				num2 = 43;
				Class36.smethod_55(array);
				IL_27B:
				goto IL_39B;
				IL_280:
				goto IL_3A6;
				IL_285:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_2A0;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_375;
				IL_2A0:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_375:
				goto IL_3A6;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_285;
			}
			IL_39B:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_3A6:
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
				Point3d p;
				Point3d pointXY;
				if (this.point3d_2.Y < value.Y)
				{
					p..ctor(value.X, value.Y + this.double_1 * 1.1, 0.0);
					pointXY = CAD.GetPointXY(value, -50.0 * this.double_0, 0.05 * this.double_1);
				}
				else
				{
					p..ctor(value.X, value.Y - this.double_1 * 1.1, 0.0);
					pointXY = CAD.GetPointXY(value, -50.0 * this.double_0, -1.05 * this.double_1);
				}
				double num = CAD.P2P_AngleV(value, this.point3d_2);
				if (num < 1.7453292519943295 & num > 1.3962634015954636)
				{
					p..ctor(this.point3d_2.X, value.Y + this.double_1 * 1.1, 0.0);
					pointXY..ctor(this.point3d_2.X, value.Y, 0.0);
					pointXY = CAD.GetPointXY(pointXY, -50.0 * this.double_0, 0.05 * this.double_1);
					Polyline polyline2 = polyline;
					int num2 = 0;
					Point2d point2d;
					point2d..ctor(this.point3d_2.X, this.point3d_2.Y);
					polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
					Polyline polyline3 = polyline;
					int num3 = 1;
					point2d..ctor(p.X, p.Y);
					polyline3.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
				}
				else if (num > 4.5378560551852569 & num < 4.8869219055841224)
				{
					p..ctor(this.point3d_2.X, value.Y - this.double_1 * 1.1, 0.0);
					pointXY..ctor(this.point3d_2.X, value.Y, 0.0);
					pointXY = CAD.GetPointXY(pointXY, -50.0 * this.double_0, -1.05 * this.double_1);
					Polyline polyline4 = polyline;
					int num4 = 0;
					Point2d point2d;
					point2d..ctor(this.point3d_2.X, this.point3d_2.Y);
					polyline4.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
					Polyline polyline5 = polyline;
					int num5 = 1;
					point2d..ctor(p.X, p.Y);
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
					point2d..ctor(p.X, p.Y);
					polyline8.AddVertexAt(num8, point2d, 0.0, 0.0, 0.0);
				}
				Point3d pointXY2;
				if (this.point3d_2.Y < value.Y)
				{
					pointXY2 = CAD.GetPointXY(p, 0.0, 300.0 * this.double_0);
				}
				else
				{
					pointXY2 = CAD.GetPointXY(p, 0.0, -300.0 * this.double_0);
				}
				DBText dbtext = new DBText();
				dbtext.HorizontalMode = 1;
				dbtext.VerticalMode = 2;
				dbtext.Height = 300.0 * this.double_0;
				dbtext.Rotation = 1.5707963267948966;
				dbtext.TextString = "1";
				dbtext.WidthFactor = 0.7;
				dbtext.AlignmentPoint = pointXY2;
				dbtext.Layer = "Y_引注";
				this.entity_0[1] = dbtext;
				Circle circle = new Circle();
				circle.Center = pointXY2;
				circle.Radius = 300.0 * this.double_0;
				circle.Layer = "Y_引线";
				this.entity_0[2] = circle;
				if (Operators.CompareString(this.string_0, "", false) != 0)
				{
					DBText dbtext2 = new DBText();
					dbtext2.Height = 300.0 * this.double_0;
					dbtext2.Rotation = 1.5707963267948966;
					dbtext2.TextString = this.string_0;
					dbtext2.WidthFactor = 0.7;
					dbtext2.Position = pointXY;
					dbtext2.Layer = "Y_引注";
					this.entity_0[3] = dbtext2;
				}
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
