using System;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 绘制注释标记2 : DrawJig
	{
		public 绘制注释标记2()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
			this.short_0 = 1;
		}

		[CommandMethod("TcZhuShi2")]
		public void TcZhuShi2()
		{
			CAD.CreateLayer("注释", 1, "continuous", 30, false, false);
			Application.SetSystemVariable("LWDISPLAY", 1);
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Point3d point3d;
			Point3d point3d2;
			short num = (-((Class36.smethod_33(ref point3d, ref point3d2) > false) ? 1 : 0)) ? 1 : 0;
			if (num != 0)
			{
				this.double_0 = Math.Abs(point3d.X - point3d2.X);
				this.double_1 = Math.Abs(point3d.Y - point3d2.Y);
				this.point3d_0..ctor((point3d.X + point3d2.X) / 2.0, (point3d.Y + point3d2.Y) / 2.0, 0.0);
				PromptResult promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					CAD.AddEnt(this.entity_0[0]);
					this.dbtext_0 = new DBText();
					double num2 = this.double_0 / 8.0;
					this.dbtext_0.TextString = "请在这里输入内容";
					if (num2 > 0.7 * this.double_1)
					{
						this.dbtext_0.Height = 0.7 * this.double_1;
					}
					else
					{
						this.dbtext_0.Height = num2;
					}
					this.dbtext_0.SetDatabaseDefaults();
					this.dbtext_0.HorizontalMode = 1;
					this.dbtext_0.VerticalMode = 2;
					this.dbtext_0.AlignmentPoint = this.point3d_0;
					CAD.AddEnt(this.dbtext_0);
				}
			}
		}

		protected override SamplerStatus Sampler(JigPrompts prompts)
		{
			PromptPointResult promptPointResult = prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
			{
				Cursor = 2,
				BasePoint = CAD.GetPointAngle(this.point3d_0, this.double_1 / 2.0, (double)(checked(-90 * this.short_0))),
				UseBasePoint = true
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				this.short_0 = 1;
				if (value.Y > this.point3d_0.Y)
				{
					this.short_0 = -1;
				}
				Point2d point2d;
				point2d..ctor(value.X, value.Y);
				Point2d point2d2;
				point2d2..ctor(this.point3d_0.X - this.double_0 / 10.0, this.point3d_0.Y - (double)this.short_0 * this.double_1 / 2.0);
				Point2d point2d3;
				point2d3..ctor(this.point3d_0.X - this.double_0 / 2.0, this.point3d_0.Y - (double)this.short_0 * this.double_1 / 2.0);
				Point2d point2d4;
				point2d4..ctor(this.point3d_0.X - this.double_0 / 2.0, this.point3d_0.Y + (double)this.short_0 * this.double_1 / 2.0);
				Point2d point2d5;
				point2d5..ctor(this.point3d_0.X + this.double_0 / 2.0, this.point3d_0.Y + (double)this.short_0 * this.double_1 / 2.0);
				Point2d point2d6;
				point2d6..ctor(this.point3d_0.X + this.double_0 / 2.0, this.point3d_0.Y - (double)this.short_0 * this.double_1 / 2.0);
				Point2d point2d7;
				point2d7..ctor(this.point3d_0.X + this.double_0 / 10.0, this.point3d_0.Y - (double)this.short_0 * this.double_1 / 2.0);
				this.polyline_0 = new Polyline();
				this.polyline_0.AddVertexAt(0, point2d, 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(1, point2d2, 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(2, point2d3, 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(3, point2d4, 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(4, point2d5, 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(5, point2d6, 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(6, point2d7, 0.0, 0.0, 0.0);
				this.polyline_0.Closed = true;
				this.entity_0[0] = this.polyline_0;
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
			Draw.Geometry.Draw(this.entity_0[0]);
			return true;
		}

		private Entity[] entity_0;

		private Polyline polyline_0;

		private DBText dbtext_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;

		private double double_1;

		private short short_0;
	}
}
