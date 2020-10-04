﻿using System;
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
	public class 单点引注Y : DrawJig
	{
		[DebuggerNonUserCode]
		public 单点引注Y()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDDYZ2")]
		public void TcDDYZ2()
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
				dbtext.Height = 300.0 * this.double_0;
				IL_66:
				num2 = 7;
				dbtext.Rotation = 1.5707963267948966;
				IL_78:
				num2 = 8;
				dbtext.WidthFactor = 0.7;
				IL_8A:
				num2 = 9;
				this.string_0 = Clipboard.GetText();
				IL_98:
				num2 = 10;
				if (Operators.CompareString(this.string_0, "", false) != 0)
				{
					goto IL_BF;
				}
				IL_B1:
				num2 = 11;
				this.string_0 = "%%1328@200";
				IL_BF:
				num2 = 13;
				if (this.string_0.Length <= 50)
				{
					goto IL_F4;
				}
				IL_D3:
				num2 = 14;
				this.string_0 = this.string_0.Substring(0, 40) + "……";
				IL_F4:
				num2 = 16;
				dbtext.TextString = this.string_0;
				IL_104:
				num2 = 17;
				this.double_1 = dbtext.GeometricExtents.MaxPoint.Y - dbtext.GeometricExtents.MinPoint.Y;
				IL_140:
				num2 = 18;
				bool flag = false;
				IL_146:
				num2 = 19;
				this.entity_0 = new Entity[3];
				IL_155:
				num2 = 22;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_164:
				num2 = 23;
				PromptPointOptions promptPointOptions = new PromptPointOptions("插入点:");
				IL_173:
				num2 = 24;
				PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
				IL_186:
				num2 = 25;
				if (point.Status != 5100)
				{
					goto IL_268;
				}
				IL_19C:
				num2 = 26;
				this.point3d_2 = point.Value;
				IL_1AC:
				num2 = 27;
				PromptResult promptResult = mdiActiveDocument.Editor.Drag(this);
				IL_1BE:
				num2 = 28;
				if (promptResult.Status != 5100)
				{
					goto IL_268;
				}
				IL_1D4:
				num2 = 29;
				ObjectId[] array;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)(this.entity_0.Length - 1);
					IL_1E4:
					num2 = 30;
					if (num3 != 0)
					{
						goto IL_201;
					}
					IL_1EE:
					num2 = 31;
					CAD.AddEnt(this.entity_0[0]);
					goto IL_268;
					IL_201:
					num2 = 33;
					IL_204:
					num2 = 34;
					array = new ObjectId[(int)(num3 + 1)];
					IL_211:
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
					IL_225:
					num2 = 36;
					array[(int)num6] = CAD.AddEnt(this.entity_0[(int)num6]).ObjectId;
					IL_246:
					num2 = 37;
					num6 += 1;
				}
				IL_257:
				num2 = 38;
				if (!flag)
				{
					goto IL_268;
				}
				IL_25E:
				num2 = 39;
				Class36.smethod_55(array);
				IL_268:
				goto IL_378;
				IL_26D:
				goto IL_383;
				IL_272:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_28D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_352;
				IL_28D:
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_352:
				goto IL_383;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_272;
			}
			IL_378:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_383:
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
				Line line = new Line(this.point3d_2, value);
				line.Layer = "Y_引线";
				this.entity_0[0] = line;
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
				Line line2 = new Line(value, point3d);
				line2.Layer = "Y_引线";
				DBText dbtext = new DBText();
				dbtext.Height = 300.0 * this.double_0;
				dbtext.Rotation = 1.5707963267948966;
				dbtext.TextString = this.string_0;
				dbtext.WidthFactor = 0.7;
				dbtext.Position = pointXY;
				dbtext.Layer = "Y_引注";
				this.entity_0[1] = dbtext;
				this.entity_0[2] = line2;
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

		private ObjectId method_0(Entity entity_1)
		{
			throw new NotImplementedException();
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
