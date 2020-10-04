﻿using System;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 窗线 : DrawJig
	{
		public 窗线()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[4];
		}

		[CommandMethod("TcWindowLine")]
		public void WindowLine()
		{
			this.double_0 = Class36.smethod_30("指定窗棂宽度(默认240):", 240.0);
			this.point3d_0 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_0 == point3d))
			{
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptResult promptResult = editor.Drag(this);
				if (promptResult.Status == 5100)
				{
					CAD.AddEnt(this.entity_0[0]);
					CAD.AddEnt(this.entity_0[1]);
					CAD.AddEnt(this.entity_0[2]);
					CAD.AddEnt(this.entity_0[3]);
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
				double num = CAD.P2P_Angle(this.point3d_0, value);
				Point3d pointAngle = CAD.GetPointAngle(this.point3d_0, this.double_0 / 6.0, num * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle2 = CAD.GetPointAngle(value, this.double_0 / 6.0, num * 180.0 / 3.1415926535897931 + 90.0);
				this.entity_0[0] = new Line(pointAngle, pointAngle2);
				pointAngle = CAD.GetPointAngle(this.point3d_0, this.double_0 / 2.0, num * 180.0 / 3.1415926535897931 + 90.0);
				pointAngle2 = CAD.GetPointAngle(value, this.double_0 / 2.0, num * 180.0 / 3.1415926535897931 + 90.0);
				this.entity_0[1] = new Line(pointAngle, pointAngle2);
				pointAngle = CAD.GetPointAngle(this.point3d_0, this.double_0 / 2.0, num * 180.0 / 3.1415926535897931 - 90.0);
				pointAngle2 = CAD.GetPointAngle(value, this.double_0 / 2.0, num * 180.0 / 3.1415926535897931 - 90.0);
				this.entity_0[2] = new Line(pointAngle, pointAngle2);
				pointAngle = CAD.GetPointAngle(this.point3d_0, this.double_0 / 6.0, num * 180.0 / 3.1415926535897931 - 90.0);
				pointAngle2 = CAD.GetPointAngle(value, this.double_0 / 6.0, num * 180.0 / 3.1415926535897931 - 90.0);
				this.entity_0[3] = new Line(pointAngle, pointAngle2);
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
			return true;
		}

		private Entity[] entity_0;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private double double_0;
	}
}
