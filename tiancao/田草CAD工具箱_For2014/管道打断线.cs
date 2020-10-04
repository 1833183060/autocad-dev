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
	public class 管道打断线 : DrawJig
	{
		public 管道打断线()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[3];
		}

		[CommandMethod("TcGDDDX")]
		public void TcGDDDX()
		{
			this.point3d_0 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_0 == point3d))
			{
				ObjectId[] array = new ObjectId[3];
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptResult promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					array[0] = CAD.AddEnt(this.entity_0[0]).ObjectId;
					array[1] = CAD.AddEnt(this.entity_0[1]).ObjectId;
					array[2] = CAD.AddEnt(this.entity_0[2]).ObjectId;
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
				Point3d point3d = Class36.smethod_46(this.point3d_0, value);
				Point3d point3d2 = Class36.smethod_46(this.point3d_0, point3d);
				Point3d point3d3 = Class36.smethod_46(value, point3d);
				double num = value.GetVectorTo(this.point3d_0).AngleOnPlane(new Plane());
				double num2 = 0.6 * this.point3d_0.DistanceTo(value);
				double num3 = Math.Atan(1.0) * 4.0;
				Point3d point3d4;
				point3d4..ctor(point3d2.get_Coordinate(0) + Math.Cos(num + num3 / 2.0) * num2, point3d2.get_Coordinate(1) + Math.Sin(num + num3 / 2.0) * num2, point3d2.get_Coordinate(2));
				double num4 = point3d4.GetVectorTo(point3d).AngleOnPlane(new Plane());
				double num5 = point3d4.GetVectorTo(this.point3d_0).AngleOnPlane(new Plane());
				object value2 = point3d4.DistanceTo(point3d);
				this.entity_0[0] = new Arc(point3d4, Conversions.ToDouble(value2), num4, num5);
				point3d4..ctor(point3d3.get_Coordinate(0) + Math.Cos(num + num3 / 2.0) * num2, point3d3.get_Coordinate(1) + Math.Sin(num + num3 / 2.0) * num2, point3d3.get_Coordinate(2));
				num4 = point3d4.GetVectorTo(value).AngleOnPlane(new Plane());
				num5 = point3d4.GetVectorTo(point3d).AngleOnPlane(new Plane());
				this.entity_0[1] = new Arc(point3d4, Conversions.ToDouble(value2), num4, num5);
				point3d4..ctor(point3d3.get_Coordinate(0) + Math.Cos(num - num3 / 2.0) * num2, point3d3.get_Coordinate(1) + Math.Sin(num - num3 / 2.0) * num2, point3d3.get_Coordinate(2));
				num4 = point3d4.GetVectorTo(point3d).AngleOnPlane(new Plane());
				num5 = point3d4.GetVectorTo(value).AngleOnPlane(new Plane());
				this.entity_0[2] = new Arc(point3d4, Conversions.ToDouble(value2), num4, num5);
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
			return true;
		}

		private Entity[] entity_0;

		private Point3d point3d_0;

		private Point3d point3d_1;
	}
}
