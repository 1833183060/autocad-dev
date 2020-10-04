using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class BiaoGao_Frm : Form
	{
		[DebuggerNonUserCode]
		static BiaoGao_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			BiaoGao_Frm.list_0 = new List<WeakReference>();
		}

		public BiaoGao_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			BiaoGao_Frm.smethod_0(this);
			this.short_0 = 1;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = BiaoGao_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (BiaoGao_Frm.list_0.Count == BiaoGao_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = BiaoGao_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = BiaoGao_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									BiaoGao_Frm.list_0[num] = BiaoGao_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						BiaoGao_Frm.list_0.RemoveRange(num, BiaoGao_Frm.list_0.Count - num);
						BiaoGao_Frm.list_0.Capacity = BiaoGao_Frm.list_0.Count;
					}
					BiaoGao_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual RadioButton RadioButton1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton1 = value;
			}
		}

		internal virtual RadioButton RadioButton2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton2 = value;
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
				EventHandler value2 = new EventHandler(this.Label1_Click);
				if (this._Label1 != null)
				{
					this._Label1.Click -= value2;
				}
				this._Label1 = value;
				if (this._Label1 != null)
				{
					this._Label1.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label2_Click);
				if (this._Label2 != null)
				{
					this._Label2.Click -= value2;
				}
				this._Label2 = value;
				if (this._Label2 != null)
				{
					this._Label2.Click += value2;
				}
			}
		}

		internal virtual Label Label3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Label3_Click);
				if (this._Label3 != null)
				{
					this._Label3.Click -= value2;
				}
				this._Label3 = value;
				if (this._Label3 != null)
				{
					this._Label3.Click += value2;
				}
			}
		}

		internal virtual Label Label4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Label4_Click);
				if (this._Label4 != null)
				{
					this._Label4.Click -= value2;
				}
				this._Label4 = value;
				if (this._Label4 != null)
				{
					this._Label4.Click += value2;
				}
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			int num2;
			int num11;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_1D:
				num = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_30:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_39:
				num = 4;
				double scale = CAD.GetScale();
				IL_42:
				num = 5;
				if (!this.RadioButton1.Checked)
				{
					goto IL_433;
				}
				IL_54:
				num = 6;
				string text = this.TextBox1.Text;
				IL_63:
				num = 7;
				text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
				IL_7B:
				num = 8;
				string[] array = new string[1];
				IL_85:
				num = 9;
				string s = text;
				string text2 = "&";
				NF.Str2Arr(s, ref array, ref text2);
				IL_9A:
				num = 10;
				ObjectId[] array2;
				Point3d point3d;
				short num5;
				short num6;
				checked
				{
					short num3 = (short)Information.UBound(array, 1);
					IL_A8:
					num = 11;
					array2 = new ObjectId[(int)(num3 + 1 + 1)];
					IL_B8:
					num = 12;
					point3d..ctor(0.0, 0.0, 0.0);
					IL_DD:
					num = 13;
					array2[0] = Class36.smethod_81(point3d, (int)this.short_0, scale).ObjectId;
					IL_101:
					num = 14;
					short num4 = 0;
					num5 = num3;
					num6 = num4;
				}
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_118:
					num = 15;
					if (Operators.CompareString(array[(int)num6], "0.00", false) == 0 | Operators.CompareString(array[(int)num6], "0.000", false) == 0)
					{
						IL_144:
						num = 16;
						array[(int)num6] = "%%p0.000";
					}
					IL_151:
					num = 18;
					if (num6 >= 1)
					{
						IL_15E:
						num = 19;
						array[(int)num6] = "(" + array[(int)num6] + ")";
					}
					IL_17A:
					num = 21;
					if (this.short_0 == 1)
					{
						IL_18B:
						num = 22;
						Point3d pointXY = CAD.GetPointXY(point3d, 300.0 * scale, 300.0 * scale);
						IL_1AF:
						num = 23;
						array2[(int)(checked(num6 + 1))] = Class36.smethod_57(array[(int)num6], CAD.GetPointXY(pointXY, 800.0 * scale, (double)(checked(400 * num6 + 100)) * scale), 300.0 * scale, 2, 0, "STANDARD", 0.0);
					}
					else
					{
						IL_20F:
						num = 25;
						if (this.short_0 == 2)
						{
							IL_220:
							num = 26;
							Point3d pointXY = CAD.GetPointXY(point3d, -300.0 * scale, 300.0 * scale);
							IL_244:
							num = 27;
							array2[(int)(checked(num6 + 1))] = Class36.smethod_57(array[(int)num6], CAD.GetPointXY(pointXY, -800.0 * scale, (double)(checked(400 * num6 + 100)) * scale), 300.0 * scale, 0, 0, "STANDARD", 0.0);
						}
						else
						{
							IL_2A4:
							num = 29;
							if (this.short_0 == 3)
							{
								IL_2B5:
								num = 30;
								Point3d pointXY = CAD.GetPointXY(point3d, -300.0 * scale, -300.0 * scale);
								IL_2D9:
								num = 31;
								array2[(int)(checked(num6 + 1))] = Class36.smethod_57(array[(int)num6], CAD.GetPointXY(pointXY, -800.0 * scale, (double)(checked(0 - (400 * num6 + 100 + 300))) * scale), 300.0 * scale, 0, 0, "STANDARD", 0.0);
							}
							else
							{
								IL_341:
								num = 33;
								if (this.short_0 == 4)
								{
									IL_352:
									num = 34;
									Point3d pointXY = CAD.GetPointXY(point3d, 300.0 * scale, -300.0 * scale);
									IL_376:
									num = 35;
									array2[(int)(checked(num6 + 1))] = Class36.smethod_57(array[(int)num6], CAD.GetPointXY(pointXY, 800.0 * scale, (double)(checked(0 - (400 * num6 + 100 + 300))) * scale), 300.0 * scale, 2, 0, "STANDARD", 0.0);
								}
							}
						}
					}
					IL_3D9:
					num = 37;
					num6 += 1;
				}
				IL_3E8:
				num = 38;
				JigEntIDs jigEntIDs = new JigEntIDs();
				IL_3F2:
				num = 39;
				JigEntIDs jigEntIDs2 = jigEntIDs;
				ObjectId[] entIDs = array2;
				Point3d basePoint;
				basePoint..ctor(0.0, 0.0, 0.0);
				jigEntIDs2.method_0(entIDs, basePoint);
				IL_423:
				num = 40;
				Class36.smethod_55(array2);
				goto IL_77A;
				IL_433:
				num = 42;
				IL_436:
				num = 43;
				string text3 = this.TextBox1.Text;
				IL_446:
				num = 44;
				double num9 = Conversion.Val(text3);
				IL_452:
				num = 45;
				ObjectId[] array3 = new ObjectId[2];
				IL_45C:
				num = 46;
				Point3d point = CAD.GetPoint("选择插入点: ");
				IL_46B:
				num = 47;
				Point3d point3d2;
				if (!(point != point3d2))
				{
					goto IL_7B0;
				}
				IL_47C:
				num = 48;
				bool flag = true;
				for (;;)
				{
					IL_75E:
					num = 53;
					bool flag2;
					Point3d point3d_;
					if (flag2)
					{
						IL_743:
						num = 54;
						flag = (Class36.smethod_29(point3d_, ref point, "选择下一点: ") != 0);
					}
					else
					{
						IL_487:
						num = 56;
						if (!flag2)
						{
							IL_491:
							num = 57;
							point3d_ = point;
						}
					}
					IL_498:
					num = 59;
					if (!flag)
					{
						break;
					}
					IL_4A2:
					num = 60;
					array3[0] = Class36.smethod_81(point, (int)this.short_0, scale).ObjectId;
					IL_4C5:
					num = 61;
					num9 += (point.Y - point3d_.Y) / 1000.0;
					IL_4E6:
					num = 62;
					string string_;
					if (num9 == 0.0)
					{
						IL_4F8:
						num = 63;
						string_ = "%%p0.000";
					}
					else
					{
						IL_503:
						num = 65;
						IL_506:
						num = 66;
						string_ = string.Format("{0:0.000}", num9);
					}
					IL_51B:
					num = 68;
					if (this.short_0 == 1)
					{
						IL_529:
						num = 69;
						Point3d pointXY2 = CAD.GetPointXY(point, 300.0 * scale, 300.0 * scale);
						IL_54C:
						num = 70;
						array3[1] = Class36.smethod_57(string_, CAD.GetPointXY(pointXY2, 800.0 * scale, 100.0 * scale), 300.0 * scale, 2, 0, "STANDARD", 0.0);
					}
					else
					{
						IL_5A0:
						num = 72;
						if (this.short_0 == 2)
						{
							IL_5AE:
							num = 73;
							Point3d pointXY2 = CAD.GetPointXY(point, -300.0 * scale, 300.0 * scale);
							IL_5D1:
							num = 74;
							array3[1] = Class36.smethod_57(string_, CAD.GetPointXY(pointXY2, -800.0 * scale, 100.0 * scale), 300.0 * scale, 0, 0, "STANDARD", 0.0);
						}
						else
						{
							IL_625:
							num = 76;
							if (this.short_0 == 3)
							{
								IL_633:
								num = 77;
								Point3d pointXY2 = CAD.GetPointXY(point, -300.0 * scale, -300.0 * scale);
								IL_656:
								num = 78;
								array3[1] = Class36.smethod_57(string_, CAD.GetPointXY(pointXY2, -800.0 * scale, -400.0 * scale), 300.0 * scale, 0, 0, "STANDARD", 0.0);
							}
							else
							{
								IL_6AA:
								num = 80;
								if (this.short_0 == 4)
								{
									IL_6B8:
									num = 81;
									Point3d pointXY2 = CAD.GetPointXY(point, 300.0 * scale, -300.0 * scale);
									IL_6DB:
									num = 82;
									array3[1] = Class36.smethod_57(string_, CAD.GetPointXY(pointXY2, 800.0 * scale, -400.0 * scale), 300.0 * scale, 2, 0, "STANDARD", 0.0);
								}
							}
						}
					}
					IL_72A:
					num = 84;
					Class36.smethod_55(array3);
					IL_734:
					num = 85;
					point3d_ = point;
					IL_73B:
					num = 86;
					flag2 = true;
				}
				IL_76A:
				num = 89;
				IL_76D:
				num = 90;
				Information.Err().Clear();
				goto IL_77A;
				IL_7B0:
				num = 50;
				IL_7B3:
				goto IL_99C;
				IL_77A:
				num = 94;
				if (Information.Err().Number <= 0)
				{
					goto IL_7A1;
				}
				IL_78C:
				num = 95;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_7A1:
				num = 97;
				documentLock.Dispose();
				IL_7AB:
				goto IL_99C;
				IL_7B8:
				int num10 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_950:
				goto IL_991;
				IL_952:
				num11 = num;
				if (num2 <= -2)
				{
					goto IL_7B8;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_96D:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_952;
			}
			IL_991:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_99C:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Label3_Click(object sender, EventArgs e)
		{
			this.short_0 = 3;
			this.Label3.BackColor = Color.Red;
			this.Label1.BackColor = SystemColors.Control;
			this.Label2.BackColor = SystemColors.Control;
			this.Label4.BackColor = SystemColors.Control;
		}

		private void Label1_Click(object sender, EventArgs e)
		{
			this.short_0 = 1;
			this.Label1.BackColor = Color.Red;
			this.Label2.BackColor = SystemColors.Control;
			this.Label3.BackColor = SystemColors.Control;
			this.Label4.BackColor = SystemColors.Control;
		}

		private void Label4_Click(object sender, EventArgs e)
		{
			this.short_0 = 4;
			this.Label4.BackColor = Color.Red;
			this.Label3.BackColor = SystemColors.Control;
			this.Label2.BackColor = SystemColors.Control;
			this.Label1.BackColor = SystemColors.Control;
		}

		private void Label2_Click(object sender, EventArgs e)
		{
			this.short_0 = 2;
			this.Label2.BackColor = Color.Red;
			this.Label3.BackColor = SystemColors.Control;
			this.Label4.BackColor = SystemColors.Control;
			this.Label1.BackColor = SystemColors.Control;
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		private short short_0;
	}
}
