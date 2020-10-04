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
	public class 绘制注释标记5 : DrawJig
	{
		public 绘制注释标记5()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
			this.bool_0 = true;
			this.short_0 = 0;
		}

		[CommandMethod("TcZhuShi5")]
		public void TcZhuShi5()
		{
			CAD.CreateLayer("注释", 1, "continuous", 30, false, false);
			Application.SetSystemVariable("LWDISPLAY", 1);
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			this.point3d_0 = CAD.GetPoint("箭头起始点:");
			Point3d point3d;
			if (this.point3d_0 != point3d)
			{
				PromptResult promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					this.point3d_0 = this.point3d_1;
					this.bool_0 = false;
				}
				promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					CAD.AddEnt(this.entity_0[0]);
					this.bool_0 = true;
				}
			}
		}

		protected override SamplerStatus Sampler(JigPrompts prompts)
		{
			int num;
			SamplerStatus samplerStatus;
			int num3;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				PromptPointResult promptPointResult = prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
				{
					Cursor = 2,
					BasePoint = this.point3d_0,
					UseBasePoint = true
				});
				Point3d value = promptPointResult.Value;
				if (value != this.point3d_1)
				{
					checked
					{
						if (this.bool_0)
						{
							this.double_0 = value.DistanceTo(this.point3d_0);
							this.short_0 = (short)Math.Round(this.double_0 / 6.0);
							this.double_2 = value.GetVectorTo(this.point3d_0).AngleOnPlane(new Plane());
							this.point2d_0..ctor(this.point3d_0.X, this.point3d_0.Y);
							this.jipAtgRsh..ctor(value.X, value.Y);
						}
						else
						{
							this.short_0 = (short)Math.Round(value.DistanceTo(this.point3d_0));
							if ((double)this.short_0 >= this.double_0)
							{
								this.short_0 = (short)Math.Round(this.double_0);
							}
							else if ((double)this.short_0 <= this.double_0 / 6.0)
							{
								this.short_0 = (short)Math.Round(this.double_0 / 6.0);
							}
						}
					}
					Point2d point2dAngle = CAD.GetPoint2dAngle(this.jipAtgRsh, (double)this.short_0 / 6.0, this.double_2 * 180.0 / 3.1415926535897931 - 90.0 + 45.0);
					Point2d point2dAngle2 = CAD.GetPoint2dAngle(this.jipAtgRsh, (double)this.short_0 / 3.0, this.double_2 * 180.0 / 3.1415926535897931 - 90.0 + 45.0);
					Point2d point2dAngle3 = CAD.GetPoint2dAngle(this.jipAtgRsh, (double)this.short_0 / 3.0, this.double_2 * 180.0 / 3.1415926535897931 + 180.0 + 45.0);
					Point2d point2dAngle4 = CAD.GetPoint2dAngle(this.jipAtgRsh, (double)this.short_0 / 3.0, this.double_2 * 180.0 / 3.1415926535897931 + 90.0 + 45.0);
					Point2d point2dAngle5 = CAD.GetPoint2dAngle(this.jipAtgRsh, (double)this.short_0 / 6.0, this.double_2 * 180.0 / 3.1415926535897931 + 90.0 + 45.0);
					this.polyline_0 = new Polyline();
					double num2 = Math.Tan(0.78539816339744828) / 4.0;
					this.polyline_0.AddVertexAt(0, this.point2d_0, num2, 0.0, 0.0);
					this.polyline_0.AddVertexAt(1, point2dAngle, 0.0, 0.0, 0.0);
					this.polyline_0.AddVertexAt(2, point2dAngle2, 0.0, 0.0, 0.0);
					this.polyline_0.AddVertexAt(3, point2dAngle3, 0.0, 0.0, 0.0);
					this.polyline_0.AddVertexAt(4, point2dAngle4, 0.0, 0.0, 0.0);
					this.polyline_0.AddVertexAt(5, point2dAngle5, -num2, 0.0, 0.0);
					this.polyline_0.Closed = true;
					this.polyline_0.Layer = "注释";
					this.entity_0[0] = this.polyline_0;
					this.point3d_1 = value;
					samplerStatus = 0;
					goto IL_470;
				}
				samplerStatus = 1;
				goto IL_470;
				IL_428:
				samplerStatus = 1;
				goto IL_470;
				IL_42D:
				num3 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_442:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_42D;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_470:
			SamplerStatus result = samplerStatus;
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
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

		private bool bool_0;

		private short short_0;

		private double double_0;

		private double double_1;

		private Point2d point2d_0;

		private Point2d jipAtgRsh;

		private double double_2;
	}
}
