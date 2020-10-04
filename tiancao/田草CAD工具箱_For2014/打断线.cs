using System;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 打断线 : DrawJig
	{
		[DebuggerNonUserCode]
		public 打断线()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDDX")]
		public void TcDDXX()
		{
			this.double_0 = CAD.GetScale();
			this.point3d_0 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_0 == point3d))
			{
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptResult promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					CAD.AddEnt(this.polyline_0);
				}
			}
		}

		protected override SamplerStatus Sampler(JigPrompts Prompts)
		{
			PromptPointResult promptPointResult = Prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定插入点:")
			{
				UserInputControls = 2,
				Cursor = 2,
				BasePoint = this.point3d_0,
				UseBasePoint = true
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				double num = this.point3d_0.DistanceTo(value) * 2.0;
				double num2 = this.point3d_0.GetVectorTo(value).AngleOnPlane(new Plane());
				Point3d p;
				p..ctor((this.point3d_0.X + value.X) / 2.0, (this.point3d_0.Y + value.Y) / 2.0, 0.0);
				double num3 = 3.1415926535897931;
				this.polyline_0 = new Polyline();
				if (num >= 1000.0 * this.double_0)
				{
					num = 1000.0 * this.double_0;
				}
				Point3d pointAngle = CAD.GetPointAngle(this.point3d_0, num / 10.0, num2 * 180.0 / num3 + 180.0);
				this.polyline_0.AddVertexAt(0, Class36.smethod_38(pointAngle), 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(1, Class36.smethod_38(this.point3d_0), 0.0, 0.0, 0.0);
				pointAngle = CAD.GetPointAngle(p, num / 15.0, num2 * 180.0 / num3 + 180.0);
				this.polyline_0.AddVertexAt(2, Class36.smethod_38(pointAngle), 0.0, 0.0, 0.0);
				pointAngle = CAD.GetPointAngle(p, num / 8.0, num2 * 180.0 / num3 - 105.0);
				this.polyline_0.AddVertexAt(3, Class36.smethod_38(pointAngle), 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(4, Class36.smethod_38(p), 0.0, 0.0, 0.0);
				pointAngle = CAD.GetPointAngle(p, num / 8.0, num2 * 180.0 / num3 + 75.0);
				this.polyline_0.AddVertexAt(5, Class36.smethod_38(pointAngle), 0.0, 0.0, 0.0);
				pointAngle = CAD.GetPointAngle(p, num / 15.0, num2 * 180.0 / num3);
				this.polyline_0.AddVertexAt(6, Class36.smethod_38(pointAngle), 0.0, 0.0, 0.0);
				this.polyline_0.AddVertexAt(7, Class36.smethod_38(value), 0.0, 0.0, 0.0);
				pointAngle = CAD.GetPointAngle(value, num / 10.0, num2 * 180.0 / num3);
				this.polyline_0.AddVertexAt(8, Class36.smethod_38(pointAngle), 0.0, 0.0, 0.0);
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
			Draw.Geometry.Draw(this.polyline_0);
			return true;
		}

		private Polyline polyline_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;
	}
}
