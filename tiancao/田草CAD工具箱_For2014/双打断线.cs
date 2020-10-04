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
	public class 双打断线 : DrawJig
	{
		public 双打断线()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[7];
		}

		[CommandMethod("TcDDX2")]
		public void TcDDX2()
		{
			this.double_0 = CAD.GetScale();
			this.point3d_0 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_0 == point3d))
			{
				ObjectId[] array = new ObjectId[7];
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptResult promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					array[0] = CAD.AddEnt(this.entity_0[0]).ObjectId;
					array[1] = CAD.AddEnt(this.entity_0[1]).ObjectId;
					array[2] = CAD.AddEnt(this.entity_0[2]).ObjectId;
					array[3] = CAD.AddEnt(this.entity_0[3]).ObjectId;
					array[4] = CAD.AddEnt(this.entity_0[4]).ObjectId;
					array[5] = CAD.AddEnt(this.entity_0[5]).ObjectId;
					array[6] = CAD.AddEnt(this.entity_0[6]).ObjectId;
					Class36.smethod_55(array);
				}
			}
		}

		protected override SamplerStatus Sampler(JigPrompts Prompts)
		{
			PromptPointResult promptPointResult = Prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
			{
				Cursor = 6,
				BasePoint = this.point3d_0,
				UseBasePoint = true
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_1)
			{
				double num = this.point3d_0.DistanceTo(value) * 2.0;
				double num2 = this.point3d_0.GetVectorTo(value).AngleOnPlane(new Plane()) * 180.0 / 3.1415926;
				Point3d p = Class36.smethod_46(this.point3d_0, value);
				if (num >= 50.0 * this.double_0)
				{
					num = 50.0 * this.double_0;
				}
				this.entity_0[0] = new Line(CAD.GetPointAngle(this.point3d_0, 1.4142 * num, num2 + 135.0), CAD.GetPointAngle(p, 1.3485 * num, num2 + 132.1352));
				this.entity_0[1] = new Line(CAD.GetPointAngle(value, 1.4142 * num, num2 + 45.0), CAD.GetPointAngle(p, 1.6421 * num, num2 + 37.5152));
				this.entity_0[2] = new Line(CAD.GetPointAngle(this.point3d_0, 1.4142 * num, num2 - 135.0), CAD.GetPointAngle(p, 1.6421 * num, num2 - 142.4848));
				this.entity_0[3] = new Line(CAD.GetPointAngle(value, 1.4142 * num, num2 - 45.0), CAD.GetPointAngle(p, 1.3485 * num, num2 - 47.8648));
				this.entity_0[4] = new Line(CAD.GetPointAngle(p, 1.6421 * num, num2 - 142.4848), CAD.GetPointAngle(p, 2.8284 * num, num2 + 101.25));
				this.entity_0[5] = new Line(CAD.GetPointAngle(p, 2.8284 * num, num2 + 101.25), CAD.GetPointAngle(p, 2.8284 * num, num2 - 78.75));
				this.entity_0[6] = new Line(CAD.GetPointAngle(p, 2.8284 * num, num2 - 78.75), CAD.GetPointAngle(p, 1.6421 * num, num2 + 37.5152));
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
			Draw.Geometry.Draw(this.entity_0[1]);
			Draw.Geometry.Draw(this.entity_0[2]);
			Draw.Geometry.Draw(this.entity_0[3]);
			Draw.Geometry.Draw(this.entity_0[4]);
			Draw.Geometry.Draw(this.entity_0[5]);
			Draw.Geometry.Draw(this.entity_0[6]);
			return true;
		}

		private Entity[] entity_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;
	}
}
