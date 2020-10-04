using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class JMTX_Frm : Form
	{
		[DebuggerNonUserCode]
		static JMTX_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			JMTX_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public JMTX_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.JMTX_Frm_Load;
			JMTX_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = JMTX_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (JMTX_Frm.list_0.Count == JMTX_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = JMTX_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = JMTX_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									JMTX_Frm.list_0[num] = JMTX_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						JMTX_Frm.list_0.RemoveRange(num, JMTX_Frm.list_0.Count - num);
						JMTX_Frm.list_0.Capacity = JMTX_Frm.list_0.Count;
					}
					JMTX_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual Button Button1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button1_Click);
				if (this._Button1 != null)
				{
					this._Button1.Click -= value2;
				}
				this._Button1 = value;
				if (this._Button1 != null)
				{
					this._Button1.Click += value2;
				}
			}
		}

		internal virtual Label Label1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		internal virtual TextBox TextBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox1 = value;
			}
		}

		internal virtual TextBox TextBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox2 = value;
			}
		}

		internal virtual Label Label2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		internal virtual Button Button3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button3_Click);
				if (this._Button3 != null)
				{
					this._Button3.Click -= value2;
				}
				this._Button3 = value;
				if (this._Button3 != null)
				{
					this._Button3.Click += value2;
				}
			}
		}

		internal virtual Button Button4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button4_Click);
				if (this._Button4 != null)
				{
					this._Button4.Click -= value2;
				}
				this._Button4 = value;
				if (this._Button4 != null)
				{
					this._Button4.Click += value2;
				}
			}
		}

		internal virtual Button Button2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button2_Click);
				if (this._Button2 != null)
				{
					this._Button2.Click -= value2;
				}
				this._Button2 = value;
				if (this._Button2 != null)
				{
					this._Button2.Click += value2;
				}
			}
		}

		internal virtual Panel Panel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel1 = value;
			}
		}

		internal virtual Panel Panel2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel2 = value;
			}
		}

		public void JMTX()
		{
			int num2;
			int num3;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				this.Hide();
				IL_09:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_11:
				num = 3;
				Entity entity = Class36.smethod_72("选择一个面域:");
				IL_1E:
				num = 4;
				if (entity is Region)
				{
					goto IL_33;
				}
				IL_2E:
				goto IL_1D3;
				IL_33:
				num = 7;
				IL_35:
				num = 8;
				Region region = (Region)entity;
				IL_3F:
				num = 10;
				Point3d point3d;
				Vector3d vector3d;
				Vector3d vector3d2;
				RegionAreaProperties regionAreaProperties = region.AreaProperties(ref point3d, ref vector3d, ref vector3d2);
				IL_51:
				num = 11;
				Plane plane = new Plane(point3d, vector3d, vector3d2);
				IL_61:
				num = 12;
				Point3d position = plane.EvaluatePoint(regionAreaProperties.Centroid);
				IL_74:
				num = 13;
				DBPoint dbpoint = new DBPoint();
				IL_7E:
				num = 14;
				dbpoint.Position = position;
				IL_8A:
				num = 15;
				dbpoint.Color = Color.FromColorIndex(192, 0);
				IL_9F:
				num = 16;
				Point3d maxPoint = region.GeometricExtents.MaxPoint;
				IL_B4:
				num = 17;
				Point3d minPoint = region.GeometricExtents.MinPoint;
				IL_C9:
				num = 18;
				Math.Sqrt(Math.Pow(minPoint.get_Coordinate(0) - maxPoint.get_Coordinate(0), 2.0) + Math.Pow(minPoint.get_Coordinate(1) - maxPoint.get_Coordinate(1), 2.0) + Math.Pow(minPoint.get_Coordinate(2) - maxPoint.get_Coordinate(2), 2.0));
				IL_131:
				goto IL_1D3;
				IL_136:
				goto IL_1DD;
				IL_13B:
				num3 = num;
				if (num2 <= -2)
				{
					goto IL_152;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				goto IL_1AE;
				IL_152:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_1AE:
				goto IL_1DD;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_13B;
			}
			IL_1D3:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_1DD:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public object GetPointangle1(object ptBase, double angle, double length)
		{
			return new double[]
			{
				Conversions.ToDouble(Operators.AddObject(NewLateBinding.LateIndexGet(ptBase, new object[]
				{
					0
				}, null), length * Math.Cos(angle))),
				Conversions.ToDouble(Operators.AddObject(NewLateBinding.LateIndexGet(ptBase, new object[]
				{
					1
				}, null), length * Math.Sin(angle))),
				Conversions.ToDouble(NewLateBinding.LateIndexGet(ptBase, new object[]
				{
					2
				}, null))
			};
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Button3.Enabled = true;
		}

		private void JMTX_Frm_Load(object sender, EventArgs e)
		{
			this.Button3.Enabled = false;
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				this.Hide();
				IL_09:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_11:
				num = 3;
				Point3d point = CAD.GetPoint("点取空间一点:");
				IL_1E:
				num = 4;
				if (Math.Abs(point.get_Coordinate(1) - this.point3d_0.get_Coordinate(1)) != 0.0)
				{
					goto IL_9F;
				}
				IL_47:
				num = 5;
				double value = this.double_2 / Math.Abs(point.get_Coordinate(0) - this.point3d_0.get_Coordinate(0));
				IL_6C:
				num = 6;
				this.TextBox1.Text = this.TextBox1.Text + "抗  弯     Wx=无穷大    Wy=" + Conversions.ToString(value) + "\r\n";
				goto IL_1CE;
				IL_9F:
				num = 8;
				if (Math.Abs(point.get_Coordinate(0) - this.point3d_0.get_Coordinate(0)) != 0.0)
				{
					goto IL_122;
				}
				IL_C8:
				num = 9;
				double value2 = this.double_0 / Math.Abs(point.get_Coordinate(1) - this.point3d_0.get_Coordinate(1));
				IL_EE:
				num = 10;
				this.TextBox1.Text = this.TextBox1.Text + "抗  弯     Wx=" + Conversions.ToString(value2) + "    Wy=无穷大\r\n";
				goto IL_1CE;
				IL_122:
				num = 12;
				IL_125:
				num = 13;
				value2 = this.double_0 / Math.Abs(point.get_Coordinate(1) - this.point3d_0.get_Coordinate(1));
				IL_14B:
				num = 14;
				value = this.double_2 / Math.Abs(point.get_Coordinate(0) - this.point3d_0.get_Coordinate(0));
				IL_171:
				num = 15;
				this.TextBox1.Text = string.Concat(new string[]
				{
					this.TextBox1.Text,
					"抗  弯     Wx=",
					Conversions.ToString(value2),
					"    Wy=",
					Conversions.ToString(value),
					"\r\n"
				});
				IL_1CE:
				num = 17;
				if (Math.Abs(point.get_Coordinate(1) - 0.0) != 0.0)
				{
					goto IL_24C;
				}
				IL_1F5:
				num = 18;
				value = this.double_2 / Math.Abs(point.get_Coordinate(0) - 0.0);
				IL_218:
				num = 19;
				this.TextBox2.Text = this.TextBox2.Text + "抗  弯     Wx=无穷大    Wy=" + Conversions.ToString(value) + "\r\n";
				goto IL_370;
				IL_24C:
				num = 21;
				if (Math.Abs(point.get_Coordinate(0) - 0.0) != 0.0)
				{
					goto IL_2CA;
				}
				IL_273:
				num = 22;
				value2 = this.double_0 / Math.Abs(point.get_Coordinate(1) - 0.0);
				IL_296:
				num = 23;
				this.TextBox2.Text = this.TextBox2.Text + "抗  弯     Wx=" + Conversions.ToString(value2) + "    Wy=无穷大\r\n";
				goto IL_370;
				IL_2CA:
				num = 25;
				IL_2CD:
				num = 26;
				value2 = this.double_0 / Math.Abs(point.get_Coordinate(1) - 0.0);
				IL_2F0:
				num = 27;
				value = this.double_2 / Math.Abs(point.get_Coordinate(0) - 0.0);
				IL_313:
				num = 28;
				this.TextBox2.Text = string.Concat(new string[]
				{
					this.TextBox2.Text,
					"抗  弯     Wx=",
					Conversions.ToString(value2),
					"    Wy=",
					Conversions.ToString(value),
					"\r\n"
				});
				IL_370:
				num = 30;
				double num3 = Math.Sqrt(Math.Pow(point.get_Coordinate(0) - this.point3d_0.get_Coordinate(0), 2.0) + Math.Pow(point.get_Coordinate(1) - this.point3d_0.get_Coordinate(1), 2.0) + Math.Pow(point.get_Coordinate(2) - this.point3d_0.get_Coordinate(2), 2.0));
				IL_3E5:
				num = 31;
				if (num3 != 0.0)
				{
					goto IL_41C;
				}
				IL_3F7:
				num = 32;
				this.TextBox1.Text = this.TextBox1.Text + "抗  扭     Wp=无穷大\r\n";
				goto IL_45C;
				IL_41C:
				num = 34;
				IL_41F:
				num = 35;
				double value3 = this.double_4 / num3;
				IL_42D:
				num = 36;
				this.TextBox1.Text = this.TextBox1.Text + "抗  扭     Wp=" + Conversions.ToString(value3) + "\r\n";
				IL_45C:
				num = 38;
				num3 = Math.Sqrt(Math.Pow(point.get_Coordinate(0) - 0.0, 2.0) + Math.Pow(point.get_Coordinate(1) - 0.0, 2.0) + Math.Pow(point.get_Coordinate(2) - 0.0, 2.0));
				IL_4C8:
				num = 39;
				if (num3 != 0.0)
				{
					goto IL_4FF;
				}
				IL_4DA:
				num = 40;
				this.TextBox2.Text = this.TextBox2.Text + "抗  扭     Wp=无穷大\r\n";
				goto IL_53F;
				IL_4FF:
				num = 42;
				IL_502:
				num = 43;
				value3 = this.double_4 / num3;
				IL_510:
				num = 44;
				this.TextBox2.Text = this.TextBox2.Text + "抗  扭     Wp=" + Conversions.ToString(value3) + "\r\n";
				IL_53F:
				num = 46;
				this.Show();
				IL_548:
				goto IL_660;
				IL_54D:
				goto IL_66A;
				IL_552:
				num4 = num;
				if (num2 <= -2)
				{
					goto IL_56C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				goto IL_63B;
				IL_56C:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_63B:
				goto IL_66A;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_552;
			}
			IL_660:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_66A:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(point == point3d))
			{
				string[] array_ = new string[1];
				string text = this.TextBox1.Text;
				text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
				Class36.smethod_44(text, ref array_, "&");
				Class36.smethod_20(this.method_0(point, 100, 0), array_, 300.0, 1.2, "");
				documentLock.Dispose();
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(point == point3d))
			{
				string[] array_ = new string[1];
				string text = this.TextBox2.Text;
				text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
				Class36.smethod_44(text, ref array_, "&");
				Class36.smethod_20(this.method_0(point, 100, 0), array_, 300.0, 1.2, "");
				documentLock.Dispose();
			}
		}

		private Point3d method_0(Point3d point3d_1, int int_0, int int_1)
		{
			throw new NotImplementedException();
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		private double double_4;

		private double double_5;

		private Point3d point3d_0;
	}
}
