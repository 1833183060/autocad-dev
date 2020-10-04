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
	public class 绘制注释标记1 : DrawJig
	{
		public 绘制注释标记1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[2];
			this.short_0 = 1;
			this.short_1 = 1;
		}

		[CommandMethod("TcZhuShi1")]
		public void TcZhuShi1()
		{
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
					CAD.AddEnt(this.entity_0[1]);
					this.dbtext_0 = new DBText();
					this.dbtext_0.Height = Math.Min(0.7 * Math.Min(this.double_0, this.double_1), Math.Max(this.double_0, this.double_1) / 8.0);
					this.dbtext_0.WidthFactor = 0.7;
					this.dbtext_0.TextString = "请在这里输入内容";
					if (this.double_0 < this.double_1)
					{
						this.dbtext_0.Rotation = 1.5707963267948966;
					}
					else
					{
						this.dbtext_0.Rotation = 0.0;
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
			JigPromptPointOptions jigPromptPointOptions = new JigPromptPointOptions("\r\n请指定下一点:");
			jigPromptPointOptions.Cursor = 2;
			if (this.double_0 > this.double_1)
			{
				jigPromptPointOptions.BasePoint = CAD.GetPointXY(this.point3d_0, 0.0, this.double_1 / 2.0 * (double)this.short_0);
			}
			else
			{
				jigPromptPointOptions.BasePoint = CAD.GetPointXY(this.point3d_0, this.double_0 / 2.0 * (double)this.short_1, 0.0);
			}
			jigPromptPointOptions.UseBasePoint = true;
			PromptPointResult promptPointResult = prompts.AcquirePoint(jigPromptPointOptions);
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				if (this.double_0 > this.double_1)
				{
					Vector3d vector3d;
					vector3d..ctor(this.double_0 / 2.0, 0.0, 0.0);
					if (value.Y > this.point3d_0.Y)
					{
						this.short_0 = 1;
						this.ellipse_0 = new Ellipse(this.point3d_0, Vector3d.ZAxis, vector3d, this.double_1 / this.double_0, 2.0943951023931953, 1.0471975511965976);
					}
					else
					{
						this.short_0 = -1;
						this.ellipse_0 = new Ellipse(this.point3d_0, Vector3d.ZAxis, vector3d, this.double_1 / this.double_0, 5.2359877559829888, 4.1887902047863905);
					}
				}
				else
				{
					Vector3d vector3d;
					vector3d..ctor(0.0, this.double_1 / 2.0, 0.0);
					if (value.X > this.point3d_0.X)
					{
						this.short_1 = 1;
						this.ellipse_0 = new Ellipse(this.point3d_0, Vector3d.ZAxis, vector3d, this.double_0 / this.double_1, 5.2359877559829888, 4.1887902047863905);
					}
					else
					{
						this.short_1 = -1;
						this.ellipse_0 = new Ellipse(this.point3d_0, Vector3d.ZAxis, vector3d, this.double_0 / this.double_1, 2.0943951023931953, 1.0471975511965976);
					}
				}
				Point3d startPoint = this.ellipse_0.StartPoint;
				Point3d endPoint = this.ellipse_0.EndPoint;
				this.polyline_0 = new Polyline();
				Polyline polyline = this.polyline_0;
				int num = 0;
				Point2d point2d;
				point2d..ctor(startPoint.X, startPoint.Y);
				polyline.AddVertexAt(num, point2d, 0.0, 0.0, 0.0);
				Polyline polyline2 = this.polyline_0;
				int num2 = 1;
				point2d..ctor(value.X, value.Y);
				polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
				Polyline polyline3 = this.polyline_0;
				int num3 = 2;
				point2d..ctor(endPoint.X, endPoint.Y);
				polyline3.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
				this.entity_0[0] = this.polyline_0;
				this.entity_0[1] = this.ellipse_0;
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

		private Ellipse ellipse_0;

		private Polyline polyline_0;

		private DBText dbtext_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;

		private double double_1;

		private short short_0;

		private short short_1;
	}
}
