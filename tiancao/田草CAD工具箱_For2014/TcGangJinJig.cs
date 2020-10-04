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
	public class TcGangJinJig : DrawJig
	{
		public TcGangJinJig()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
		}

		[CommandMethod("TcGangJin")]
		public void TcGangJin()
		{
			this.double_0 = CAD.GetScale();
			CAD.CreateLayer("钢筋", 14, "continuous", -1, false, true);
			this.point2dCollection_0 = new Point2dCollection();
			this.point3d_1 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_1 == point3d))
			{
				Point2dCollection point2dCollection = this.point2dCollection_0;
				Point2d point2d;
				point2d..ctor(this.point3d_1.X, this.point3d_1.Y);
				point2dCollection.Add(point2d);
				Polyline polyline = new Polyline();
				ObjectId objectId_ = default(ObjectId);
				for (;;)
				{
					short num = checked((short)(this.point2dCollection_0.Count - 1));
					if (num >= 1)
					{
						Class36.smethod_64(objectId_);
						polyline = new Polyline();
						polyline.SetDatabaseDefaults();
						short num2 = 0;
						short num3 = num;
						short num4 = num2;
						for (;;)
						{
							short num5 = num4;
							short num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							polyline.AddVertexAt((int)num4, this.point2dCollection_0[(int)num4], 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
							num4 += 1;
						}
						polyline.Layer = "钢筋";
						objectId_ = Class36.smethod_92(polyline);
					}
					short num7 = this.GangJin();
					if (num7 != 1)
					{
						break;
					}
					this.point3d_1 = this.point3d_2;
					Point2dCollection point2dCollection2 = this.point2dCollection_0;
					point2d..ctor(this.point3d_2.X, this.point3d_2.Y);
					point2dCollection2.Add(point2d);
				}
			}
		}

		public short GangJin()
		{
			int num;
			short num3;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_11:
				num2 = 3;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_23:
				num2 = 4;
				PromptResult promptResult = editor.Drag(this);
				IL_2D:
				num2 = 5;
				if (promptResult.Status != 5100)
				{
					goto IL_48;
				}
				IL_3E:
				num2 = 6;
				num3 = 1;
				goto IL_DC;
				IL_48:
				num2 = 8;
				IL_4A:
				num2 = 9;
				num3 = -1;
				IL_55:
				goto IL_DC;
				IL_5A:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_96:
				goto IL_D1;
				IL_98:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_5A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_AE:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_98;
			}
			IL_D1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_DC:
			short result = num3;
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		protected override SamplerStatus Sampler(JigPrompts Prompts)
		{
			PromptPointResult promptPointResult = Prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
			{
				UserInputControls = 2,
				Cursor = 3,
				BasePoint = this.point3d_1,
				UseBasePoint = true
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_2)
			{
				Polyline polyline = new Polyline();
				polyline.SetDatabaseDefaults();
				Polyline polyline2 = polyline;
				int num = 0;
				Point2d point2d;
				point2d..ctor(this.point3d_1.get_Coordinate(0), this.point3d_1.get_Coordinate(1));
				polyline2.AddVertexAt(num, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				Polyline polyline3 = polyline;
				int num2 = 1;
				point2d..ctor(value.get_Coordinate(0), value.get_Coordinate(1));
				polyline3.AddVertexAt(num2, point2d, 0.0, 45.0 * this.double_0, 45.0 * this.double_0);
				polyline.Layer = "钢筋";
				this.entity_0[0] = polyline;
				this.point3d_2 = value;
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

		private Point2dCollection point2dCollection_0;

		private Point3d point3d_1;

		private Point3d point3d_2;

		private double double_0;
	}
}
