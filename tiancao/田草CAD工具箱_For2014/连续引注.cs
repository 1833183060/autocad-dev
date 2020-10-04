using System;
using System.Diagnostics;
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
	public class 连续引注 : DrawJig
	{
		[DebuggerNonUserCode]
		public 连续引注()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcLXYZ")]
		public void TcLXYZ()
		{
			int num;
			int num14;
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
				bool flag = false;
				IL_48:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_55:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 8;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_72:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						short num4;
						short num5;
						checked
						{
							this.short_0 = (short)(value.Count - 1);
							this.point3d_2 = new Point3d[(int)(this.short_0 + 1)];
							this.entity_0 = new Entity[(int)(this.short_0 + 2 + 1)];
							short num3 = 0;
							num4 = this.short_0;
							num5 = num3;
						}
						for (;;)
						{
							short num6 = num5;
							short num7 = num4;
							if (num6 > num7)
							{
								break;
							}
							Entity e = (Entity)transaction.GetObject(value[(int)num5].ObjectId, 0);
							Point3d entCenter = CAD.GetEntCenter(e);
							this.point3d_2[(int)num5] = entCenter;
							num5 += 1;
						}
						transaction.Commit();
						PromptResult promptResult = editor.Drag(this);
						if (promptResult.Status == 5100)
						{
							short num8 = checked((short)(this.entity_0.Length - 1));
							if (num8 == 0)
							{
								CAD.AddEnt(this.entity_0[0]);
							}
							else
							{
								ObjectId[] array;
								short num10;
								short num11;
								checked
								{
									array = new ObjectId[(int)(num8 + 1)];
									short num9 = 0;
									num10 = (short)(this.entity_0.Length - 1);
									num11 = num9;
								}
								for (;;)
								{
									short num12 = num11;
									short num7 = num10;
									if (num12 > num7)
									{
										break;
									}
									array[(int)num11] = CAD.AddEnt(this.entity_0[(int)num11]).ObjectId;
									num11 += 1;
								}
								if (flag)
								{
									Class36.smethod_55(array);
								}
							}
						}
					}
				}
				IL_1EF:
				goto IL_26F;
				IL_1F1:
				int num13 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num13);
				IL_229:
				goto IL_264;
				IL_22B:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_1F1;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_241:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_22B;
			}
			IL_264:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_26F:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
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
				double num = value.X;
				double num2 = value.X;
				double x = this.point3d_2[0].X;
				int num3 = 0;
				int num4 = (int)this.short_0;
				int num5 = num3;
				Point3d point3d;
				for (;;)
				{
					int num6 = num5;
					int num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					double num8 = this.point3d_2[num5].X - this.point3d_2[0].X;
					if (num2 >= value.X + num8)
					{
						num2 = value.X + num8;
					}
					if (num <= value.X + num8)
					{
						num = value.X + num8;
					}
					if (x > this.point3d_2[num5].X)
					{
						x = this.point3d_2[num5].X;
					}
					point3d..ctor(value.X + num8, value.Y, 0.0);
					Line line = new Line(this.point3d_2[num5], point3d);
					line.Layer = "Y_引线";
					this.entity_0[num5] = line;
					checked
					{
						num5++;
					}
				}
				Point3d point3d2;
				Point3d pointAngle;
				if (x < value.X)
				{
					point3d..ctor(num + 1500.0 * this.double_0, value.Y, 0.0);
					point3d2..ctor(num2, value.Y, 0.0);
					pointAngle..ctor(num + 100.0, value.Y, 0.0);
					pointAngle = CAD.GetPointAngle(pointAngle, 50.0 * this.double_0, 90.0);
				}
				else
				{
					point3d..ctor(num2 - 1500.0 * this.double_0, value.Y, 0.0);
					point3d2..ctor(num, value.Y, 0.0);
					pointAngle = CAD.GetPointAngle(point3d, 50.0 * this.double_0, 90.0);
				}
				Line line2 = new Line(point3d2, point3d);
				line2.Layer = "Y_引线";
				DBText dbtext = new DBText();
				dbtext.Height = 300.0 * this.double_0;
				dbtext.WidthFactor = 0.7;
				dbtext.TextString = "2%%13212";
				dbtext.Position = pointAngle;
				dbtext.Layer = "Y_引注";
				checked
				{
					this.entity_0[(int)(this.short_0 + 1)] = dbtext;
					this.entity_0[(int)(this.short_0 + 2)] = line2;
					this.point3d_1 = value;
					result = 0;
				}
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

		private DBText dbtext_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;

		private short short_0;

		private Point3d[] point3d_2;
	}
}
