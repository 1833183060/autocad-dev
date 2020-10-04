using System;
using System.Collections;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 打砖块
	{
		public 打砖块()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.timer_0 = new Timer();
			this.timer_1 = new Timer();
			this.point3d_5 = default(Point3d);
			this.double_3 = 4.71238898038469;
			this.bool_0 = false;
			this.double_4 = 1.0;
			this.document_0 = Application.DocumentManager.MdiActiveDocument;
			this.editor_0 = Application.DocumentManager.MdiActiveDocument.Editor;
			this.database_0 = this.document_0.Database;
		}

		[CommandMethod("TcDZK")]
		public void TcDZK()
		{
			CAD.CreateLayer("打砖块-墙", 1, "continuous", 30, false, false);
			CAD.CreateLayer("打砖块-砖2", 2, "continuous", 30, false, false);
			CAD.CreateLayer("打砖块-砖6", 6, "continuous", 30, false, false);
			CAD.CreateLayer("打砖块-球1", 3, "continuous", 30, false, false);
			CAD.CreateLayer("打砖块-球2", 4, "continuous", 30, false, false);
			CAD.CreateLayer("打砖块-球3", 5, "continuous", 30, false, false);
			CAD.CreateLayer("打砖块-球0", 8, "continuous", 30, false, false);
			this.document_0.LockDocument();
			this.double_0 = this.editor_0.GetCurrentView().Height;
			this.double_0 *= 0.9;
			this.double_1 = this.editor_0.GetCurrentView().Width;
			this.double_1 *= 0.9;
			this.point3d_0..ctor(this.editor_0.GetCurrentView().CenterPoint.X, this.editor_0.GetCurrentView().CenterPoint.Y, 0.0);
			this.point3d_1..ctor(this.point3d_0.X + this.double_1 / 2.0, this.point3d_0.Y + this.double_0 / 2.0, 0.0);
			this.point3d_2..ctor(this.point3d_0.X - this.double_1 / 2.0, this.point3d_0.Y + this.double_0 / 2.0, 0.0);
			this.point3d_3..ctor(this.point3d_0.X - this.double_1 / 2.0, this.point3d_0.Y - this.double_0 / 2.0, 0.0);
			this.point3d_4..ctor(this.point3d_0.X + this.double_1 / 2.0, this.point3d_0.Y - this.double_0 / 2.0, 0.0);
			this.jipAtgRsh = CAD.AddPlinePxy(this.point3d_3, this.double_1, this.double_0, 0.0, "");
			this.double_2 = this.double_1 / 80.0;
			double num = this.double_1 / 20.0;
			double num2 = num / 3.0;
			this.dbobjectCollection_0 = new DBObjectCollection();
			long num3 = 0L;
			Point3d pointXY;
			do
			{
				pointXY..ctor(this.point3d_2.X + (double)num3 * num, this.point3d_2.Y - num2, this.point3d_2.Z);
				this.dbobjectCollection_0.Add(CAD.AddPlinePxy(pointXY, num, num2, 0.0, "打砖块-砖2"));
				checked
				{
					num3 += 1L;
				}
			}
			while (num3 <= 19L);
			long num4 = 0L;
			do
			{
				pointXY..ctor(this.point3d_2.X + (double)num4 * num + num / 2.0, this.point3d_2.Y - 2.0 * num2, this.point3d_2.Z);
				this.dbobjectCollection_0.Add(CAD.AddPlinePxy(pointXY, num, num2, 0.0, "打砖块-砖6"));
				checked
				{
					num4 += 1L;
				}
			}
			while (num4 <= 18L);
			long num5 = 0L;
			do
			{
				pointXY..ctor(this.point3d_2.X + (double)num5 * num, this.point3d_2.Y - 3.0 * num2, this.point3d_2.Z);
				this.dbobjectCollection_0.Add(CAD.AddPlinePxy(pointXY, num, num2, 0.0, "打砖块-砖2"));
				checked
				{
					num5 += 1L;
				}
			}
			while (num5 <= 19L);
			long num6 = 0L;
			do
			{
				pointXY..ctor(this.point3d_2.X + (double)num6 * num + num / 2.0, this.point3d_2.Y - 4.0 * num2, this.point3d_2.Z);
				this.dbobjectCollection_0.Add(CAD.AddPlinePxy(pointXY, num, num2, 0.0, "打砖块-砖6"));
				checked
				{
					num6 += 1L;
				}
			}
			while (num6 <= 18L);
			long num7 = 0L;
			do
			{
				pointXY..ctor(this.point3d_2.X + (double)num7 * num, this.point3d_2.Y - 5.0 * num2, this.point3d_2.Z);
				this.dbobjectCollection_0.Add(CAD.AddPlinePxy(pointXY, num, num2, 0.0, "打砖块-砖2"));
				checked
				{
					num7 += 1L;
				}
			}
			while (num7 <= 19L);
			Point3d point3d;
			point3d..ctor(0.0, 0.0, 0.0);
			this.polyline_0 = CAD.AddPlinePxy(this.point3d_3, this.double_2 * 10.0, 2.0 * this.double_2, 0.0, "打砖块-墙");
			pointXY = CAD.GetPointXY(this.point3d_2, -this.double_2 * 1.1, -2.0 * this.double_2);
			CAD.AddCircle(pointXY, this.double_2, "打砖块-球0");
			this.circle_0 = CAD.AddCircle(pointXY, this.double_2, "打砖块-球1");
			this.objectId_0 = Class36.smethod_57("1", pointXY, this.double_2, 4, 2, "STANDARD", 0.0);
			pointXY = CAD.GetPointXY(this.point3d_2, -this.double_2 * 1.1, -4.0 * this.double_2);
			CAD.AddCircle(pointXY, this.double_2, "打砖块-球0");
			this.circle_1 = CAD.AddCircle(pointXY, this.double_2, "打砖块-球2");
			this.objectId_1 = Class36.smethod_57("2", pointXY, this.double_2, 4, 2, "STANDARD", 0.0);
			pointXY = CAD.GetPointXY(this.point3d_2, -this.double_2 * 1.1, -6.0 * this.double_2);
			CAD.AddCircle(pointXY, this.double_2, "打砖块-球0");
			this.circle_2 = CAD.AddCircle(pointXY, this.double_2, "打砖块-球3");
			this.objectId_2 = Class36.smethod_57("3", pointXY, this.double_2, 4, 2, "STANDARD", 0.0);
			pointXY = CAD.GetPointXY(this.point3d_2, this.double_2, 2.0 * this.double_2);
			this.objectId_3 = Class36.smethod_23(pointXY, "0", 1.5 * this.double_2, 0, "打砖块-墙");
			pointXY = CAD.GetPointXY(this.point3d_1, -3.0 * this.double_2, 2.0 * this.double_2);
			this.objectId_4 = Class36.smethod_23(pointXY, "0", 1.5 * this.double_2, 0, "打砖块-墙");
			Random random = new Random();
			this.double_3 = 0.52359877559829882 + 2.0943951023931953 * random.NextDouble();
			this.timer_0.Interval = 50;
			this.timer_1.Interval = 1;
			this.timer_0.Tick += this.timer1_Tick;
			this.timer_1.Tick += this.timer2_Tick;
			this.editor_0.PointMonitor += new PointMonitorEventHandler(this.GetMousePoint);
			this.timer_0.Start();
			this.timer_1.Start();
		}

		public void timer1_Tick(object sender, EventArgs e)
		{
			this.document_0.LockDocument();
			if (!this.bool_0)
			{
				CAD.EntMove(this.circle_0.Id, this.circle_0.Center, CAD.GetPointAR_Radian(this.point3d_0, this.double_3, this.double_4 * this.double_2));
				Class36.smethod_64(this.objectId_0);
				this.bool_0 = true;
			}
			else
			{
				CAD.EntMove(this.circle_0.Id, this.circle_0.Center, CAD.GetPointAR_Radian(this.circle_0.Center, this.double_3, this.double_4 * this.double_2));
				this.Zhuangji();
			}
			this.document_0.Editor.UpdateScreen();
		}

		public void timer2_Tick(object sender, EventArgs e)
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				checked
				{
					this.long_1 += 1L;
					IL_21:
					num2 = 3;
					打砖块.ChangeTextString(this.objectId_3, 打砖块.formatLongToTimeStr(this.long_1));
					IL_3A:
					num2 = 4;
					打砖块.ChangeTextString(this.objectId_4, this.long_2.ToString());
					IL_53:
					goto IL_BB;
					IL_55:;
				}
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_77:
				goto IL_B0;
				IL_79:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_55;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_8E:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_79;
			}
			IL_B0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_BB:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public static string formatLongToTimeStr(long HM)
		{
			int num = 0;
			int num2 = 0;
			checked
			{
				int num3 = (int)Math.Round((double)HM / 100.0);
				if (num3 > 60)
				{
					num2 = (int)Math.Round((double)num3 / 60.0);
					num3 %= 60;
				}
				if (num2 > 60)
				{
					num = (int)Math.Round((double)num2 / 60.0);
					num2 %= 60;
				}
				return string.Concat(new string[]
				{
					num.ToString(),
					":",
					num2.ToString(),
					":",
					num3.ToString()
				});
			}
		}

		public static int ChangeTextString(ObjectId ID, string Str)
		{
			int num;
			int num4;
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
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					Entity entity = (Entity)transaction.GetObject(ID, 1);
					DBText dbtext = (DBText)entity;
					dbtext.TextString = Str;
					transaction.Commit();
				}
				IL_57:
				goto IL_BF;
				IL_59:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_79:
				goto IL_B4;
				IL_7B:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_59;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_91:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_7B;
			}
			IL_B4:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_BF:
			int num5;
			int result = num5;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public void Zhuangji()
		{
			try
			{
				foreach (object obj in this.dbobjectCollection_0)
				{
					Polyline polyline = (Polyline)obj;
					this.point3dCollection_0 = new Point3dCollection();
					polyline.IntersectWith(this.circle_0, 0, new Plane(), this.point3dCollection_0, IntPtr.Zero, IntPtr.Zero);
					if (this.point3dCollection_0.Count > 0)
					{
						Class36.smethod_64(polyline.ObjectId);
						this.dbobjectCollection_0.Remove(polyline);
						checked
						{
							this.long_2 += 100L;
						}
						this.double_3 = 6.2831853071795862 - this.double_3;
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			this.point3dCollection_0 = new Point3dCollection();
			this.polyline_0.IntersectWith(this.circle_0, 0, new Plane(), this.point3dCollection_0, IntPtr.Zero, IntPtr.Zero);
			if (this.point3dCollection_0.Count > 0)
			{
				this.double_3 = 6.2831853071795862 - this.double_3;
			}
			Point3d pointXY = CAD.GetPointXY(this.circle_0.Center, 0.0, this.double_2);
			Point3d pointXY2 = CAD.GetPointXY(this.circle_0.Center, 0.0, -this.double_2);
			Point3d pointXY3 = CAD.GetPointXY(this.circle_0.Center, -this.double_2, 0.0);
			Point3d pointXY4 = CAD.GetPointXY(this.circle_0.Center, this.double_2, 0.0);
			if (pointXY.Y >= this.point3d_1.Y)
			{
				this.double_3 = 6.2831853071795862 - this.double_3;
			}
			checked
			{
				if (pointXY2.Y <= this.point3d_4.Y)
				{
					this.long_0 += 1L;
					if (this.long_0 == 1L)
					{
						Class36.smethod_64(this.objectId_1);
						Class36.smethod_64(this.circle_0.ObjectId);
						this.circle_0 = this.circle_1;
						CAD.EntMove(this.circle_0.Id, this.circle_0.Center, CAD.GetPointAR_Radian(this.point3d_0, this.double_3, this.double_2));
					}
					else
					{
						if (this.long_0 != 2L)
						{
							ObjectId id = Class36.smethod_57("Game Over", this.point3d_0, this.double_0 / 5.0, 4, 2, "STANDARD", 0.0);
							CAD.ChangeLayer(id, "打砖块-墙");
							this.editor_0.WriteMessage("\r\n停止");
							this.editor_0.PointMonitor -= new PointMonitorEventHandler(this.GetMousePoint);
							this.timer_0.Tick -= this.timer1_Tick;
							this.timer_1.Tick -= this.timer2_Tick;
							return;
						}
						Class36.smethod_64(this.objectId_2);
						Class36.smethod_64(this.circle_0.ObjectId);
						this.circle_0 = this.circle_2;
						CAD.EntMove(this.circle_0.Id, this.circle_0.Center, CAD.GetPointAR_Radian(this.point3d_0, this.double_3, this.double_2));
					}
				}
			}
			if (pointXY3.X <= this.point3d_2.X)
			{
				this.double_3 = 9.42477796076938 - this.double_3;
			}
			if (pointXY4.X >= this.point3d_1.X)
			{
				this.double_3 = 9.42477796076938 - this.double_3;
			}
		}

		public void GetMousePoint(object sender, PointMonitorEventArgs e)
		{
			try
			{
				this.point3d_5 = e.Context.RawPoint;
				Point3d point3d;
				if (this.point3d_5 != point3d)
				{
					Random random = new Random();
					this.double_4 = 1.0 + random.NextDouble();
					ObjectId objectId = this.polyline_0.ObjectId;
					Point3d minPoint = this.polyline_0.GeometricExtents.MinPoint;
					Point3d targetPt;
					targetPt..ctor(this.point3d_5.X, this.point3d_3.Y, 0.0);
					CAD.EntMove(objectId, minPoint, targetPt);
				}
			}
			catch (Exception ex)
			{
			}
		}

		private Point3dCollection point3dCollection_0;

		private Timer timer_0;

		private Timer timer_1;

		private double double_0;

		private double double_1;

		private Point3d point3d_0;

		private Point3d point3d_1;

		private Point3d point3d_2;

		private Point3d point3d_3;

		private Point3d point3d_4;

		private Polyline jipAtgRsh;

		private Polyline polyline_0;

		private Circle circle_0;

		private Circle circle_1;

		private Circle circle_2;

		private ObjectId objectId_0;

		private ObjectId objectId_1;

		private ObjectId objectId_2;

		private ObjectId objectId_3;

		private ObjectId objectId_4;

		private double double_2;

		private Point3d point3d_5;

		private double double_3;

		private bool bool_0;

		private long long_0;

		private long long_1;

		private long long_2;

		private double double_4;

		private object object_0;

		private DBObjectCollection dbobjectCollection_0;

		private Document document_0;

		private Editor editor_0;

		private Database database_0;
	}
}
