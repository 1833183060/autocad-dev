using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcAsv_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcAsv_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcAsv_Frm.list_0 = new List<WeakReference>();
		}

		public TcAsv_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.FormClosing += this.TcAsv_Frm_FormClosing;
			base.Load += this.TcAsv_Frm_Load;
			base.Shown += this.TcAsv_Frm_Shown;
			TcAsv_Frm.smethod_0(this);
			this.BiLi = 4.0;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcAsv_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcAsv_Frm.list_0.Count == TcAsv_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcAsv_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcAsv_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcAsv_Frm.list_0[num] = TcAsv_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcAsv_Frm.list_0.RemoveRange(num, TcAsv_Frm.list_0.Count - num);
						TcAsv_Frm.list_0.Capacity = TcAsv_Frm.list_0.Count;
					}
					TcAsv_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual Label Label5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label5 = value;
			}
		}

		internal virtual TextBox TextBox4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox4 = value;
			}
		}

		internal virtual Label Label6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label6 = value;
			}
		}

		internal virtual TextBox TextBox5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox5 = value;
			}
		}

		internal virtual Label Label7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label7 = value;
			}
		}

		internal virtual TextBox TextBox6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox6 = value;
			}
		}

		internal virtual Label Label8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label8 = value;
			}
		}

		internal virtual ComboBox ComboBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboBox2_TextChanged);
				if (this._ComboBox2 != null)
				{
					this._ComboBox2.TextChanged -= value2;
				}
				this._ComboBox2 = value;
				if (this._ComboBox2 != null)
				{
					this._ComboBox2.TextChanged += value2;
				}
			}
		}

		internal virtual Label Label9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label9 = value;
			}
		}

		internal virtual TextBox TextBox7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox7_TextChanged);
				if (this._TextBox7 != null)
				{
					this._TextBox7.TextChanged -= value2;
				}
				this._TextBox7 = value;
				if (this._TextBox7 != null)
				{
					this._TextBox7.TextChanged += value2;
				}
			}
		}

		internal virtual Label Label10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label10 = value;
			}
		}

		internal virtual TextBox TextBox8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox8 = value;
			}
		}

		internal virtual Label Label11
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label11 = value;
			}
		}

		internal virtual ComboBox ComboBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboBox3_SelectedIndexChanged);
				if (this._ComboBox3 != null)
				{
					this._ComboBox3.SelectedIndexChanged -= value2;
				}
				this._ComboBox3 = value;
				if (this._ComboBox3 != null)
				{
					this._ComboBox3.SelectedIndexChanged += value2;
				}
			}
		}

		internal virtual GroupBox GroupBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox1 = value;
			}
		}

		internal virtual GroupBox GroupBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox2 = value;
			}
		}

		internal virtual Label Label12
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label12 = value;
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

		internal virtual ComboBox ComboBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.method_0);
				EventHandler value3 = new EventHandler(this.method_1);
				if (this._ComboBox1 != null)
				{
					this._ComboBox1.SelectedIndexChanged -= value2;
					this._ComboBox1.TextChanged -= value3;
				}
				this._ComboBox1 = value;
				if (this._ComboBox1 != null)
				{
					this._ComboBox1.SelectedIndexChanged += value2;
					this._ComboBox1.TextChanged += value3;
				}
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

		internal virtual TextBox TextBox9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox9_TextChanged);
				if (this._TextBox9 != null)
				{
					this._TextBox9.TextChanged -= value2;
				}
				this._TextBox9 = value;
				if (this._TextBox9 != null)
				{
					this._TextBox9.TextChanged += value2;
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

		internal virtual Label Label13
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label13;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label13 = value;
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
				this._Label3 = value;
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
				this._Label4 = value;
			}
		}

		internal virtual ComboBox ComboBox4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboBox4_SelectedIndexChanged);
				if (this._ComboBox4 != null)
				{
					this._ComboBox4.SelectedIndexChanged -= value2;
				}
				this._ComboBox4 = value;
				if (this._ComboBox4 != null)
				{
					this._ComboBox4.SelectedIndexChanged += value2;
				}
			}
		}

		internal virtual TextBox TextBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox3_TextChanged);
				if (this._TextBox3 != null)
				{
					this._TextBox3.TextChanged -= value2;
				}
				this._TextBox3 = value;
				if (this._TextBox3 != null)
				{
					this._TextBox3.TextChanged += value2;
				}
			}
		}

		internal virtual ListBox ListBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ListBox1 = value;
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

		internal virtual TextBox TextBox_0
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox_0_TextChanged);
				if (this.textBox_0 != null)
				{
					this.textBox_0.TextChanged -= value2;
				}
				this.textBox_0 = value;
				if (this.textBox_0 != null)
				{
					this.textBox_0.TextChanged += value2;
				}
			}
		}

		internal virtual Label Label15
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label15;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label15 = value;
			}
		}

		internal virtual ComboBox ComboBox5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ComboBox5 = value;
			}
		}

		internal virtual Label Label14
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label14;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label14 = value;
			}
		}

		internal virtual GroupBox GroupBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox3 = value;
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
				EventHandler value2 = new EventHandler(this.RadioButton1_CheckedChanged);
				if (this._RadioButton1 != null)
				{
					this._RadioButton1.CheckedChanged -= value2;
				}
				this._RadioButton1 = value;
				if (this._RadioButton1 != null)
				{
					this._RadioButton1.CheckedChanged += value2;
				}
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
				EventHandler value2 = new EventHandler(this.RadioButton2_CheckedChanged);
				if (this._RadioButton2 != null)
				{
					this._RadioButton2.CheckedChanged -= value2;
				}
				this._RadioButton2 = value;
				if (this._RadioButton2 != null)
				{
					this._RadioButton2.CheckedChanged += value2;
				}
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

		internal virtual Button Button5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button5_Click);
				if (this._Button5 != null)
				{
					this._Button5.Click -= value2;
				}
				this._Button5 = value;
				if (this._Button5 != null)
				{
					this._Button5.Click += value2;
				}
			}
		}

		internal virtual Button Button6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button6_Click);
				if (this._Button6 != null)
				{
					this._Button6.Click -= value2;
				}
				this._Button6 = value;
				if (this._Button6 != null)
				{
					this._Button6.Click += value2;
				}
			}
		}

		internal virtual Label Label16
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label16;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label16 = value;
			}
		}

		internal virtual TextBox TextBox_1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox_1_TextChanged);
				if (this.textBox_1 != null)
				{
					this.textBox_1.TextChanged -= value2;
				}
				this.textBox_1 = value;
				if (this.textBox_1 != null)
				{
					this.textBox_1.TextChanged += value2;
				}
			}
		}

		internal virtual Button Button7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button7_Click);
				if (this._Button7 != null)
				{
					this._Button7.Click -= value2;
				}
				this._Button7 = value;
				if (this._Button7 != null)
				{
					this._Button7.Click += value2;
				}
			}
		}

		internal virtual TextBox TextBox_2
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_2 = value;
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

		internal virtual Button Button8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button8_Click);
				if (this._Button8 != null)
				{
					this._Button8.Click -= value2;
				}
				this._Button8 = value;
				if (this._Button8 != null)
				{
					this._Button8.Click += value2;
				}
			}
		}

		internal virtual Button Button9
		{
			[DebuggerNonUserCode]
			get
			{
				return this.amIrsvPmtO;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button9_Click);
				if (this.amIrsvPmtO != null)
				{
					this.amIrsvPmtO.Click -= value2;
				}
				this.amIrsvPmtO = value;
				if (this.amIrsvPmtO != null)
				{
					this.amIrsvPmtO.Click += value2;
				}
			}
		}

		internal virtual Button Button10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button10_Click);
				if (this._Button10 != null)
				{
					this._Button10.Click -= value2;
				}
				this._Button10 = value;
				if (this._Button10 != null)
				{
					this._Button10.Click += value2;
				}
			}
		}

		internal virtual TextBox TextBox_3
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox_3_TextChanged);
				if (this.textBox_3 != null)
				{
					this.textBox_3.TextChanged -= value2;
				}
				this.textBox_3 = value;
				if (this.textBox_3 != null)
				{
					this.textBox_3.TextChanged += value2;
				}
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			this.ZhiJing = checked((long)Math.Round(Conversion.Val(this.ComboBox1.Text)));
			this.Asv();
		}

		private void method_1(object sender, EventArgs e)
		{
			this.ZhiJing = checked((long)Math.Round(Conversion.Val(this.ComboBox1.Text)));
			this.Asv();
		}

		private void TcAsv_Frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.SaveData();
		}

		private void TcAsv_Frm_Load(object sender, EventArgs e)
		{
			int num;
			int num6;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.ComboBox5.Items.Add("一级(9度)");
				IL_21:
				num2 = 3;
				this.ComboBox5.Items.Add("一级(6、7、8度)");
				IL_39:
				num2 = 4;
				this.ComboBox5.Items.Add("二级、三级");
				IL_51:
				num2 = 5;
				this.ComboBox5.Text = "一级(9度)";
				IL_63:
				num2 = 6;
				short num3 = 35;
				do
				{
					IL_76:
					num2 = 7;
					this.ComboBox2.Items.Add("C" + num3.ToString());
					IL_6A:
					num2 = 8;
					num3 += 5;
				}
				while (num3 <= 80);
				IL_9C:
				num2 = 9;
				this.ComboBox3.Items.Add("HPB300");
				IL_B5:
				num2 = 10;
				this.ComboBox3.Items.Add("HRB335");
				IL_CE:
				num2 = 11;
				this.ComboBox3.Items.Add("HRB400");
				IL_E7:
				num2 = 12;
				this.ComboBox3.Items.Add("HRB500");
				IL_100:
				num2 = 13;
				this.ComboBox3.SelectedIndex = 2;
				IL_10F:
				num2 = 14;
				this.GouZaoAsv();
				IL_118:
				num2 = 15;
				this.ComboBox4.Items.Add("1:20");
				IL_131:
				num2 = 16;
				this.ComboBox4.Items.Add("1:25");
				IL_14A:
				num2 = 17;
				this.ComboBox4.Items.Add("1:30");
				IL_163:
				num2 = 18;
				this.ComboBox4.Items.Add("1:40");
				IL_17C:
				num2 = 19;
				this.ComboBox4.Items.Add("1:50");
				IL_195:
				num2 = 20;
				this.ComboBox4.Text = "1:25";
				IL_1A8:
				num2 = 21;
				this.TextBox_1.Text = "50";
				IL_1BB:
				num2 = 22;
				this.TextBox9.Text = "23";
				IL_1CE:
				num2 = 23;
				short num4 = 6;
				do
				{
					IL_1E2:
					num2 = 24;
					this.ComboBox1.Items.Add(num4);
					IL_1D5:
					num2 = 25;
					num4 += 2;
				}
				while (num4 <= 16);
				IL_1FE:
				num2 = 26;
				this.ComboBox1.Text = Conversions.ToString(8);
				IL_212:
				num2 = 27;
				this.TextBox3.Text = Conversions.ToString(100);
				IL_227:
				num2 = 28;
				this.TextBox_3.Text = Conversions.ToString(10);
				IL_23C:
				num2 = 29;
				this.ReadData();
				IL_245:
				goto IL_31B;
				IL_24A:
				int num5 = num6 + 1;
				num6 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_2D2:
				goto IL_310;
				IL_2D4:
				num6 = num2;
				if (num <= -2)
				{
					goto IL_24A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2ED:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num6 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2D4;
			}
			IL_310:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_31B:
			if (num6 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void ComboBox2_TextChanged(object sender, EventArgs e)
		{
			this.GouZaoAsv();
		}

		public void GouZaoAsv()
		{
			double num = Conversion.Val(this.TextBox7.Text);
			object obj = JG.GetHNT_QiangDuFc(this.ComboBox2.Text);
			long fy = JG.GetFy(this.ComboBox3.Text);
			if (Operators.ConditionalCompareObjectNotEqual(obj, 0, false))
			{
				double num2 = Conversions.ToDouble(Operators.MultiplyObject(Operators.DivideObject(Operators.MultiplyObject(num, obj), fy), 100));
				this.TextBox8.Text = string.Format("{0:0.0000}", num2);
			}
		}

		private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.GouZaoAsv();
		}

		private void TextBox7_TextChanged(object sender, EventArgs e)
		{
			this.GouZaoAsv();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			this.XuanZe_QZ_Collection();
			if (this.IsQiang)
			{
				this.FenXi_Q();
			}
			else
			{
				this.FenXi_Z();
			}
			this.Asv();
		}

		public void XuanZe_QZ_Collection()
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.ListBox1.Items.Clear();
				IL_1B:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_2E:
				num2 = 4;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_3C:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_45:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,TEXT");
				array2.SetValue(typedValue, 0);
				IL_62:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_6C:
				num2 = 8;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_7E:
				num2 = 9;
				if (selection.Status != 5100)
				{
					goto IL_A1;
				}
				IL_91:
				num2 = 10;
				this.QZ_Collection = selection.Value;
				IL_A1:
				num2 = 12;
				documentLock.Dispose();
				IL_AB:
				goto IL_132;
				IL_B0:
				goto IL_13C;
				IL_B5:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_CC;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_110;
				IL_CC:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_110:
				goto IL_13C;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_B5;
			}
			IL_132:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_13C:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public void FenXi_Q()
		{
			int num;
			int num29;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.GuJin = new DoubleCollection();
				IL_16:
				num2 = 3;
				int num3 = 1;
				IL_1A:
				num2 = 4;
				long num4 = Conversions.ToLong(this.TextBox_1.Text);
				IL_2D:
				num2 = 5;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_40:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4E:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_59:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					short num5 = 0;
					short num6 = checked((short)(this.QZ_Collection.Count - 1));
					short num7 = num5;
					for (;;)
					{
						short num8 = num7;
						short num9 = num6;
						if (num8 > num9)
						{
							break;
						}
						Entity entity = (Entity)transaction.GetObject(this.QZ_Collection[(int)num7].ObjectId, 0);
						checked
						{
							if (Operators.CompareString(entity.GetType().Name, "Polyline", false) == 0)
							{
								Polyline polyline = (Polyline)entity;
								string layer = polyline.Layer;
								polyline.GetStartWidthAt(0);
								if (this.LaJinN == 0L)
								{
									if (Operators.CompareString(layer, "墙柱大箍筋", false) == 0 | Operators.CompareString(layer, "墙柱箍筋", false) == 0)
									{
										long num10 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X));
										long num11 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y));
										long num12 = (long)Math.Round(Math.Max((double)(num10 + 2L * num4) / this.BiLi, (double)(num11 + 2L * num4) / this.BiLi));
										long num13 = (long)Math.Round(Math.Min((double)(num10 + 2L * num4) / this.BiLi, (double)(num11 + 2L * num4) / this.BiLi));
										this.GuJin.Add((double)num12);
										this.GuJin.Add((double)num12);
										if (num3 == 1)
										{
											this.GuJin.Add((double)num13);
											this.GuJin.Add((double)num13);
											num3 = 2;
										}
									}
									else if (Operators.CompareString(layer, "墙柱小箍筋", false) == 0)
									{
										long num14 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X));
										long num15 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y));
										num14 = (long)Math.Round((double)(num14 + 2L * num4) / this.BiLi);
										num15 = (long)Math.Round((double)(num15 + 2L * num4) / this.BiLi);
										num14 = Math.Min(num14, num15);
										this.GuJin.Add((double)num14);
										this.GuJin.Add((double)num14);
										this.ListBox1.Items.Add("边长:" + Conversions.ToString(num14));
										this.TextBox_2.Text = Conversions.ToString(num14);
									}
									else if (Operators.CompareString(layer, "墙柱拉筋", false) == 0)
									{
										long num16 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X));
										long num17 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y));
										num16 = (long)Math.Round((double)(num16 + 2L * num4) / this.BiLi);
										num17 = (long)Math.Round((double)(num17 + 2L * num4) / this.BiLi);
										num16 = Math.Max(num16, num17);
										this.ListBox1.Items.Add("边长:" + Conversions.ToString(num16));
										this.TextBox_2.Text = Conversions.ToString(num16);
										this.GuJin.Add((double)num16);
									}
									else if ((polyline.GetStartWidthAt(0) == 0.0 | Operators.CompareString(polyline.Layer, "墙柱轮廓", false) == 0) && polyline.Area > 200.0)
									{
										this.PL_Area = (long)Math.Round(Conversion.Int(polyline.Area / this.BiLi / this.BiLi));
										this.Acor = (long)Math.Round((double)this.PL_Offset(polyline.Id, unchecked((double)(checked(0L - this.C)) * this.BiLi)) / this.BiLi / this.BiLi);
										this.TextBox1.Text = Conversions.ToString(polyline.Area);
										this.TextBox2.Text = Conversions.ToString(this.PL_Area);
										this.TextBox4.Text = Conversions.ToString(this.Acor);
									}
								}
								else if (Operators.CompareString(layer, "墙柱大箍筋", false) == 0 | (Operators.CompareString(layer, "墙柱箍筋", false) == 0 & unchecked((long)polyline.NumberOfVertices) > this.LaJinN))
								{
									long num18 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X));
									long num19 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y));
									long num20 = (long)Math.Round(Math.Max((double)(num18 + 2L * num4) / this.BiLi, (double)(num19 + 2L * num4) / this.BiLi));
									long num21 = (long)Math.Round(Math.Min((double)(num18 + 2L * num4) / this.BiLi, (double)(num19 + 2L * num4) / this.BiLi));
									this.GuJin.Add((double)num20);
									this.GuJin.Add((double)num20);
									if (num3 == 1)
									{
										this.GuJin.Add((double)num21);
										this.GuJin.Add((double)num21);
										num3 = 2;
									}
								}
								else if (Operators.CompareString(layer, "墙柱小箍筋", false) == 0)
								{
									long num22 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X));
									long num23 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y));
									num22 = (long)Math.Round((double)(num22 + 2L * num4) / this.BiLi);
									num23 = (long)Math.Round((double)(num23 + 2L * num4) / this.BiLi);
									num22 = Math.Min(num22, num23);
									this.GuJin.Add((double)num22);
									this.GuJin.Add((double)num22);
									this.ListBox1.Items.Add("边长:" + Conversions.ToString(num22));
									this.TextBox_2.Text = Conversions.ToString(num22);
								}
								else if (Operators.CompareString(layer, "墙柱拉筋", false) == 0 | (Operators.CompareString(layer, "墙柱箍筋", false) == 0 & unchecked((long)polyline.NumberOfVertices) <= this.LaJinN))
								{
									long num24 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.X - polyline.GeometricExtents.MinPoint.X));
									long num25 = (long)Math.Round(unchecked(polyline.GeometricExtents.MaxPoint.Y - polyline.GeometricExtents.MinPoint.Y));
									num24 = (long)Math.Round((double)(num24 + 2L * num4) / this.BiLi);
									num25 = (long)Math.Round((double)(num25 + 2L * num4) / this.BiLi);
									num24 = Math.Max(num24, num25);
									this.ListBox1.Items.Add("边长:" + Conversions.ToString(num24));
									this.TextBox_2.Text = Conversions.ToString(num24);
									this.GuJin.Add((double)num24);
								}
								else if ((polyline.GetStartWidthAt(0) == 0.0 | Operators.CompareString(polyline.Layer, "墙柱轮廓", false) == 0) && polyline.Area > 200.0)
								{
									this.PL_Area = (long)Math.Round(Conversion.Int(polyline.Area / this.BiLi / this.BiLi));
									this.Acor = (long)Math.Round((double)this.PL_Offset(polyline.Id, unchecked((double)(checked(0L - this.C)) * this.BiLi)) / this.BiLi / this.BiLi);
									this.TextBox1.Text = Conversions.ToString(polyline.Area);
									this.TextBox2.Text = Conversions.ToString(this.PL_Area);
									this.TextBox4.Text = Conversions.ToString(this.Acor);
								}
							}
							else if (Operators.CompareString(entity.GetType().Name, "DBText", false) == 0)
							{
								DBText dbtext = (DBText)entity;
								if (dbtext.TextString.Contains("@"))
								{
									string text;
									if (dbtext.TextString.Contains("%%"))
									{
										text = dbtext.TextString.Substring(5);
									}
									else
									{
										text = dbtext.TextString.Substring(1);
									}
									long num26 = (long)Math.Round(Conversion.Val(text.Split(new char[]
									{
										'@'
									})[0]));
									long num27 = (long)Math.Round(Conversion.Val(text.Split(new char[]
									{
										'@'
									})[1]));
									if (num26 != 0L)
									{
										this.ZhiJing = num26;
									}
									this.ComboBox1.Text = Conversions.ToString(this.ZhiJing);
									if (num27 != 0L)
									{
										this.JianJu = num27;
									}
									this.TextBox3.Text = Conversions.ToString(this.JianJu);
								}
								else if (!(dbtext.TextString.Contains("%%") & !dbtext.TextString.Contains("@")))
								{
								}
							}
						}
						num7 += 1;
					}
				}
				IL_BB7:
				num2 = 10;
				documentLock.Dispose();
				IL_BC1:
				num2 = 11;
				if (Information.Err().Number <= 0)
				{
					goto IL_BE8;
				}
				IL_BD3:
				num2 = 12;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_BE8:
				goto IL_C7B;
				IL_BED:
				int num28 = num29 + 1;
				num29 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num28);
				IL_C35:
				goto IL_C70;
				IL_C37:
				num29 = num2;
				if (num <= -2)
				{
					goto IL_BED;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_C4D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num29 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_C37;
			}
			IL_C70:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_C7B:
			if (num29 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public void FenXi_Z()
		{
			int num;
			int num24;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.GuJin = new DoubleCollection();
				IL_16:
				num2 = 3;
				IL_18:
				num2 = 4;
				long num3 = Conversions.ToLong(this.TextBox_1.Text);
				IL_2B:
				num2 = 5;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_3D:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4B:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_56:
				num2 = 8;
				ArrayList arrayList = new ArrayList();
				IL_5F:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					short num4 = 0;
					short num5 = checked((short)(this.QZ_Collection.Count - 1));
					short num6 = num4;
					for (;;)
					{
						short num7 = num6;
						short num8 = num5;
						if (num7 > num8)
						{
							break;
						}
						Entity entity = (Entity)transaction.GetObject(this.QZ_Collection[(int)num6].ObjectId, 0);
						if (Operators.CompareString(entity.GetType().Name, "Polyline", false) == 0)
						{
							Polyline polyline = (Polyline)entity;
							arrayList.Add(polyline.Area);
						}
						num6 += 1;
					}
				}
				IL_104:
				num2 = 11;
				arrayList.Sort();
				IL_10E:
				num2 = 12;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					short num9 = 0;
					short num10 = checked((short)(this.QZ_Collection.Count - 1));
					short num11 = num9;
					for (;;)
					{
						short num12 = num11;
						short num8 = num10;
						if (num12 > num8)
						{
							break;
						}
						Entity entity2 = (Entity)transaction2.GetObject(this.QZ_Collection[(int)num11].ObjectId, 0);
						checked
						{
							if (Operators.CompareString(entity2.GetType().Name, "Polyline", false) == 0)
							{
								Polyline polyline2 = (Polyline)entity2;
								if ((long)Math.Round(polyline2.Area) == Conversions.ToLong(arrayList[arrayList.Count - 1]))
								{
									this.PL_Area = (long)Math.Round(Conversion.Int(polyline2.Area / this.BiLi / this.BiLi));
									this.Acor = (long)Math.Round((double)this.PL_Offset(polyline2.Id, unchecked((double)(checked(0L - this.C)) * this.BiLi)) / this.BiLi / this.BiLi);
									this.TextBox1.Text = Conversions.ToString(polyline2.Area);
									this.TextBox2.Text = Conversions.ToString(this.PL_Area);
									this.TextBox4.Text = Conversions.ToString(this.Acor);
								}
								else if ((long)Math.Round(polyline2.Area) == Conversions.ToLong(arrayList[arrayList.Count - 2]))
								{
									long num13 = (long)Math.Round(unchecked(polyline2.GeometricExtents.MaxPoint.X - polyline2.GeometricExtents.MinPoint.X));
									long num14 = (long)Math.Round(unchecked(polyline2.GeometricExtents.MaxPoint.Y - polyline2.GeometricExtents.MinPoint.Y));
									long num15 = (long)Math.Round((double)(num13 + 2L * num3) / this.BiLi);
									long num16 = (long)Math.Round((double)(num14 + 2L * num3) / this.BiLi);
									this.GuJin.Add((double)num15);
									this.GuJin.Add((double)num15);
									this.GuJin.Add((double)num16);
									this.GuJin.Add((double)num16);
								}
								else if (polyline2.Area > 10000.0)
								{
									if (polyline2.NumberOfVertices > 6)
									{
										long num17 = (long)Math.Round(unchecked(polyline2.GeometricExtents.MaxPoint.X - polyline2.GeometricExtents.MinPoint.X));
										long num18 = (long)Math.Round(unchecked(polyline2.GeometricExtents.MaxPoint.Y - polyline2.GeometricExtents.MinPoint.Y));
										num17 = (long)Math.Round((double)(num17 + 2L * num3) / this.BiLi);
										num18 = (long)Math.Round((double)(num18 + 2L * num3) / this.BiLi);
										this.GuJin.Add((double)Math.Max(num17, num18));
										this.GuJin.Add((double)Math.Max(num17, num18));
										this.TextBox_2.Text = Conversions.ToString(Math.Max(num17, num18));
									}
									else
									{
										long num19 = (long)Math.Round(unchecked(polyline2.GeometricExtents.MaxPoint.X - polyline2.GeometricExtents.MinPoint.X));
										long num20 = (long)Math.Round(unchecked(polyline2.GeometricExtents.MaxPoint.Y - polyline2.GeometricExtents.MinPoint.Y));
										num19 = (long)Math.Round((double)(num19 + 2L * num3) / this.BiLi);
										num20 = (long)Math.Round((double)(num20 + 2L * num3) / this.BiLi);
										this.GuJin.Add((double)Math.Max(num19, num20));
										this.TextBox_2.Text = Conversions.ToString(Math.Max(num19, num20));
									}
								}
							}
							else if (Operators.CompareString(entity2.GetType().Name, "DBText", false) == 0)
							{
								DBText dbtext = (DBText)entity2;
								if (dbtext.TextString.Contains("@"))
								{
									string text;
									if (dbtext.TextString.Contains("%%"))
									{
										text = dbtext.TextString.Substring(5);
									}
									else
									{
										text = dbtext.TextString.Substring(1);
									}
									long num21 = (long)Math.Round(Conversion.Val(text.Split(new char[]
									{
										'@'
									})[0]));
									long num22 = (long)Math.Round(Conversion.Val(text.Split(new char[]
									{
										'@'
									})[1]));
									if (num21 != 0L)
									{
										this.ZhiJing = num21;
									}
									this.ComboBox1.Text = Conversions.ToString(this.ZhiJing);
									if (num22 != 0L)
									{
										this.JianJu = num22;
									}
									this.TextBox3.Text = Conversions.ToString(this.JianJu);
								}
								else if (!(dbtext.TextString.Contains("%%") & !dbtext.TextString.Contains("@")))
								{
								}
							}
						}
						num11 += 1;
					}
				}
				IL_6EA:
				num2 = 14;
				documentLock.Dispose();
				IL_6F3:
				num2 = 15;
				if (Information.Err().Number <= 0)
				{
					goto IL_71A;
				}
				IL_705:
				num2 = 16;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_71A:
				goto IL_7BD;
				IL_71F:
				int num23 = num24 + 1;
				num24 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num23);
				IL_777:
				goto IL_7B2;
				IL_779:
				num24 = num2;
				if (num <= -2)
				{
					goto IL_71F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_78F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num24 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_779;
			}
			IL_7B2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_7BD:
			if (num24 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public void Asv()
		{
			int num;
			int num13;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.ListBox1.Items.Clear();
				IL_1B:
				num2 = 3;
				long num3 = 0L;
				IL_27:
				num2 = 4;
				this.ListBox1.Items.Add("箍筋:D" + Conversions.ToString(this.ZhiJing) + "@" + Conversions.ToString(this.JianJu));
				IL_5F:
				num2 = 5;
				this.ListBox1.Items.Add("计算箍筋肢数:" + Conversions.ToString(this.GuJin.Count));
				IL_8C:
				num2 = 6;
				short num4 = 0;
				short num5 = checked((short)(this.GuJin.Count - 1));
				short num6 = num4;
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_A3:
					num2 = 7;
					checked
					{
						long num9 = (long)Math.Round(unchecked(this.GuJin[(int)num6] - (double)(checked(2L * this.C)) + (double)this.ZhiJing));
						IL_D4:
						num2 = 8;
						this.ListBox1.Items.Add("截面:" + Conversions.ToString(this.GuJin[(int)num6]) + "箍筋:" + Conversions.ToString(num9));
						IL_10F:
						num2 = 9;
						num3 += num9;
						IL_117:
						num2 = 10;
					}
					num6 += 1;
				}
				IL_12E:
				num2 = 11;
				double num10 = Math.Pow((double)this.ZhiJing, 2.0) * 0.785;
				IL_151:
				num2 = 12;
				double num11 = num10 * (double)num3 / (double)this.Acor / (double)this.JianJu * 100.0;
				IL_174:
				num2 = 13;
				this.TextBox5.Text = Conversions.ToString(num3);
				IL_188:
				num2 = 14;
				this.TextBox6.Text = string.Format("{0:0.0000}", num11);
				IL_1A7:
				num2 = 15;
				if (num11 >= Conversion.Val(this.TextBox8.Text))
				{
					goto IL_1D5;
				}
				IL_1C0:
				num2 = 16;
				this.TextBox6.ForeColor = Color.Red;
				goto IL_1EB;
				IL_1D5:
				num2 = 18;
				IL_1D8:
				num2 = 19;
				this.TextBox6.ForeColor = Color.Black;
				IL_1EB:
				num2 = 21;
				if (Information.Err().Number <= 0)
				{
					goto IL_212;
				}
				IL_1FD:
				num2 = 22;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_212:
				goto IL_2CD;
				IL_217:
				int num12 = num13 + 1;
				num13 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num12);
				IL_287:
				goto IL_2C2;
				IL_289:
				num13 = num2;
				if (num <= -2)
				{
					goto IL_217;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_29F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num13 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_289;
			}
			IL_2C2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2CD:
			if (num13 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public long PL_Offset(ObjectId Id, double Dis)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			checked
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					Entity entity = (Entity)transaction.GetObject(Id, 1);
					if (entity is Curve)
					{
						Curve curve = (Curve)entity;
						double num = 0.0;
						double num2 = 0.0;
						try
						{
							DBObjectCollection offsetCurves = curve.GetOffsetCurves(Dis);
							int num3 = 0;
							int num4 = offsetCurves.Count - 1;
							int num5 = num3;
							for (;;)
							{
								int num6 = num5;
								int num7 = num4;
								if (num6 > num7)
								{
									break;
								}
								Polyline polyline = (Polyline)offsetCurves[num5];
								num = polyline.Area;
								num5++;
							}
							DBObjectCollection offsetCurves2 = curve.GetOffsetCurves(unchecked(-Dis));
							int num8 = 0;
							int num9 = offsetCurves2.Count - 1;
							int num10 = num8;
							for (;;)
							{
								int num11 = num10;
								int num7 = num9;
								if (num11 > num7)
								{
									break;
								}
								Polyline polyline2 = (Polyline)offsetCurves2[num10];
								num2 = polyline2.Area;
								num10++;
							}
							if (num != 0.0 & num2 != 0.0)
							{
								return (long)Math.Round(Math.Min(num, num2));
							}
							return (long)Math.Round(unchecked(num + num2));
						}
						catch (Exception ex)
						{
							editor.WriteMessage("无法偏移！");
							goto IL_14A;
						}
					}
					editor.WriteMessage("无法偏移！");
					IL_14A:;
				}
				long result;
				return result;
			}
		}

		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.JianJu = checked((long)Math.Round(Conversion.Val(this.TextBox3.Text)));
			this.Asv();
		}

		private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this.ComboBox4.Text;
			if (Operators.CompareString(text, "1:20", false) == 0)
			{
				this.BiLi = 5.0;
			}
			else if (Operators.CompareString(text, "1:25", false) == 0)
			{
				this.BiLi = 4.0;
			}
			else if (Operators.CompareString(text, "1:40", false) == 0)
			{
				this.BiLi = 2.5;
			}
			else if (Operators.CompareString(text, "1:50", false) == 0)
			{
				this.BiLi = 2.0;
			}
			else if (Operators.CompareString(text, "1:30", false) == 0)
			{
				this.BiLi = 3.3333;
			}
			else if (Operators.CompareString(text, "1:100", false) == 0)
			{
				this.BiLi = 1.0;
			}
			if (this.IsQiang)
			{
				this.FenXi_Q();
			}
			else
			{
				this.FenXi_Z();
			}
			this.Asv();
		}

		private void TextBox9_TextChanged(object sender, EventArgs e)
		{
			this.C = checked((long)Math.Round(Conversion.Val(this.TextBox9.Text)));
			if (this.IsQiang)
			{
				this.FenXi_Q();
			}
			else
			{
				this.FenXi_Z();
			}
			this.Asv();
		}

		private void TcAsv_Frm_Shown(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			CAD.CreateLayer("NotPrint", 252, "continuous", -1, false, false);
			string[] array_ = new string[]
			{
				"抗震等级:" + this.ComboBox5.Text,
				"轴压比:" + this.TextBox_0.Text,
				"配箍特征值:" + this.TextBox7.Text,
				string.Concat(new string[]
				{
					"混凝土强度等级:",
					this.ComboBox2.Text,
					"(fc=",
					Conversions.ToString(JG.GetHNT_QiangDuFc(this.ComboBox2.Text)),
					")"
				}),
				string.Concat(new string[]
				{
					"钢筋强度等级:",
					this.ComboBox3.Text,
					"(fyv=",
					Conversions.ToString(JG.GetFy(this.ComboBox3.Text)),
					")"
				}),
				"构造体积配箍率:" + this.TextBox8.Text,
				"------------------",
				"纵筋保护层" + this.TextBox9.Text,
				"箍筋:" + this.ComboBox1.Text + "@" + this.TextBox3.Text,
				"箍筋总长:" + this.TextBox5.Text,
				"核心区体积:" + this.TextBox4.Text,
				"实配体积配箍率:" + this.TextBox6.Text
			};
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (point != point3d)
			{
				Class36.smethod_20(point, array_, 150.0, 1.5, "NotPrint");
			}
			documentLock.Dispose();
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void ReadData()
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
				ArrayList arrayList = new ArrayList();
				IL_12:
				num2 = 3;
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				IL_25:
				num2 = 4;
				NF.ReadTxtFile(directoryPath + "\\Asv_Data.txt", ref arrayList);
				IL_3B:
				num2 = 5;
				IEnumerator enumerator = this.GroupBox1.Controls.GetEnumerator();
				checked
				{
					short num3;
					while (enumerator.MoveNext())
					{
						Control control = (Control)enumerator.Current;
						IL_69:
						num2 = 6;
						string left = control.Name.Substring(0, 3);
						IL_7B:
						num2 = 7;
						if (Operators.CompareString(left, "Tex", false) == 0 | Operators.CompareString(left, "Txt", false) == 0 | Operators.CompareString(left, "UpD", false) == 0 | Operators.CompareString(left, "Com", false) == 0)
						{
							IL_C2:
							num2 = 8;
							control.Text = Conversions.ToString(arrayList[(int)num3]);
							IL_D9:
							num2 = 9;
							num3 += 1;
						}
						IL_E3:
						num2 = 11;
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					IL_106:
					num2 = 12;
					IEnumerator enumerator2 = this.GroupBox2.Controls.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						Control control = (Control)enumerator2.Current;
						IL_132:
						num2 = 13;
						string left2 = control.Name.Substring(0, 3);
						IL_145:
						num2 = 14;
						if (Operators.CompareString(left2, "Tex", false) == 0 | Operators.CompareString(left2, "Txt", false) == 0 | Operators.CompareString(left2, "UpD", false) == 0 | Operators.CompareString(left2, "Com", false) == 0)
						{
							IL_18D:
							num2 = 15;
							control.Text = Conversions.ToString(arrayList[(int)num3]);
							IL_1A5:
							num2 = 16;
							num3 += 1;
						}
						IL_1AF:
						num2 = 18;
					}
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
					IL_1D0:
					num2 = 19;
					object left3 = arrayList[5];
					IL_1DC:
					num2 = 22;
					if (!Operators.ConditionalCompareObjectEqual(left3, "1:25", false))
					{
						goto IL_204;
					}
					IL_1ED:
					num2 = 23;
					this.BiLi = 4.0;
					goto IL_296;
					IL_204:
					num2 = 25;
					if (!Operators.ConditionalCompareObjectEqual(left3, "1:40", false))
					{
						goto IL_229;
					}
					IL_215:
					num2 = 26;
					this.BiLi = 2.5;
					goto IL_296;
					IL_229:
					num2 = 28;
					if (!Operators.ConditionalCompareObjectEqual(left3, "1:50", false))
					{
						goto IL_24E;
					}
					IL_23A:
					num2 = 29;
					this.BiLi = 2.0;
					goto IL_296;
					IL_24E:
					num2 = 31;
					if (!Operators.ConditionalCompareObjectEqual(left3, "1:30", false))
					{
						goto IL_273;
					}
					IL_25F:
					num2 = 32;
					this.BiLi = 3.3;
					goto IL_296;
					IL_273:
					num2 = 34;
					if (!Operators.ConditionalCompareObjectEqual(left3, "1:100", false))
					{
						goto IL_296;
					}
					IL_284:
					num2 = 35;
					this.BiLi = 1.0;
					IL_296:
					num2 = 37;
					if (!Operators.ConditionalCompareObjectEqual(arrayList[arrayList.Count - 1], "True", false))
					{
						goto IL_2D1;
					}
					IL_2B6:
					num2 = 38;
					this.RadioButton1.Checked = true;
					IL_2C5:
					num2 = 39;
					this.IsQiang = true;
					goto IL_2ED;
					IL_2D1:
					num2 = 41;
					IL_2D4:
					num2 = 42;
					this.RadioButton2.Checked = true;
					IL_2E3:
					num2 = 43;
					this.IsQiang = false;
					IL_2ED:
					goto IL_401;
					IL_2F2:
					goto IL_40C;
					IL_2F7:
					num4 = num2;
					if (num <= -2)
					{
						goto IL_312;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_3DB;
					IL_312:;
				}
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_3DB:
				goto IL_40C;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2F7;
			}
			IL_401:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_40C:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void SaveData()
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				ArrayList arrayList = new ArrayList();
				IL_11:
				num2 = 3;
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				IL_24:
				num2 = 4;
				IEnumerator enumerator = this.GroupBox1.Controls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Control control = (Control)enumerator.Current;
					IL_4E:
					num2 = 5;
					string left = control.Name.Substring(0, 3);
					IL_5F:
					num2 = 6;
					if (Operators.CompareString(left, "Tex", false) == 0 | Operators.CompareString(left, "Txt", false) == 0 | Operators.CompareString(left, "UpD", false) == 0 | Operators.CompareString(left, "Com", false) == 0)
					{
						IL_A6:
						num2 = 7;
						arrayList.Add(control.Text);
					}
					IL_B5:
					num2 = 9;
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_D8:
				num2 = 10;
				IEnumerator enumerator2 = this.GroupBox2.Controls.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Control control = (Control)enumerator2.Current;
					IL_103:
					num2 = 11;
					string left2 = control.Name.Substring(0, 3);
					IL_115:
					num2 = 12;
					if (Operators.CompareString(left2, "Tex", false) == 0 | Operators.CompareString(left2, "Txt", false) == 0 | Operators.CompareString(left2, "UpD", false) == 0 | Operators.CompareString(left2, "Com", false) == 0)
					{
						IL_15D:
						num2 = 13;
						arrayList.Add(control.Text);
					}
					IL_16D:
					num2 = 15;
				}
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
				IL_190:
				num2 = 16;
				arrayList.Add(this.RadioButton1.Checked.ToString());
				IL_1AE:
				num2 = 17;
				NF.SaveTxtFile(directoryPath + "\\Asv_Data.txt", arrayList);
				IL_1C4:
				goto IL_266;
				IL_1C9:
				goto IL_271;
				IL_1CE:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_1E6;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_240;
				IL_1E6:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_240:
				goto IL_271;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1CE;
			}
			IL_266:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_271:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void RadioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButton1.Checked)
			{
				this.IsQiang = true;
			}
			if (this.IsQiang)
			{
				this.FenXi_Q();
			}
			else
			{
				this.FenXi_Z();
			}
			this.Asv();
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButton2.Checked)
			{
				this.IsQiang = false;
			}
			if (this.IsQiang)
			{
				this.FenXi_Q();
			}
			else
			{
				this.FenXi_Z();
			}
			this.Asv();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			int num;
			int num4;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_37:
				num2 = 4;
				CAD.CreateLayer("墙柱大箍筋", 10, "continuous", -3, false, true);
				IL_4F:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_5C:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_66:
				num2 = 7;
				TypedValue[] array = new TypedValue[1];
				IL_70:
				num2 = 8;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_8E:
				num2 = 9;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_9A:
				num2 = 10;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_AC:
				num2 = 11;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = selection.Value;
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						CAD.ChangeLayer(selectedObject.ObjectId, "墙柱大箍筋");
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_130:
				num2 = 13;
				documentLock.Dispose();
				IL_139:
				goto IL_1CC;
				IL_13E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_186:
				goto IL_1C1;
				IL_188:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_13E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19E:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_188;
			}
			IL_1C1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1CC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			CAD.Cmd("TcQZGJ_Layer");
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			CAD.Cmd("TcQZLJ_Layer");
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_38:
				num2 = 4;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_45:
				num2 = 5;
				Database database = mdiActiveDocument.Database;
				IL_4E:
				num2 = 6;
				PromptDistanceOptions promptDistanceOptions = new PromptDistanceOptions("\n墙柱箍筋和墙柱截面间隙:");
				IL_5B:
				num2 = 7;
				promptDistanceOptions.UseDefaultValue = true;
				IL_64:
				num2 = 8;
				promptDistanceOptions.DefaultValue = 55.0;
				IL_75:
				num2 = 9;
				PromptDoubleResult distance = mdiActiveDocument.Editor.GetDistance(promptDistanceOptions);
				IL_86:
				num2 = 10;
				this.TextBox_1.Text = Conversions.ToString(checked((long)Math.Round(distance.Value)));
				IL_A6:
				num2 = 11;
				documentLock.Dispose();
				IL_B0:
				goto IL_137;
				IL_B5:
				goto IL_142;
				IL_BA:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_D2;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_114;
				IL_D2:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_114:
				goto IL_142;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_BA;
			}
			IL_137:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_142:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.TextBox_2.Text, "", false) != 0)
			{
				this.GuJin.Add(Conversions.ToDouble(this.TextBox_2.Text));
			}
			this.Asv();
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			int num;
			int num2;
			object obj;
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				if (Operators.CompareString(this.TextBox_2.Text, "", false) != 0)
				{
					this.GuJin.Remove(Conversions.ToDouble(this.TextBox_2.Text));
				}
				this.Asv();
				IL_47:
				goto IL_8A;
				IL_49:
				num2 = -1;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_5D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num2 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_49;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			IL_8A:
			if (num2 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void TextBox_1_TextChanged(object sender, EventArgs e)
		{
			if (this.IsQiang)
			{
				this.FenXi_Q();
			}
			else
			{
				this.FenXi_Z();
			}
			this.Asv();
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			int num;
			int num4;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_37:
				num2 = 4;
				CAD.CreateLayer("墙柱轮廓", 0, "continuous", -3, false, true);
				IL_4E:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_5B:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_65:
				num2 = 7;
				TypedValue[] array = new TypedValue[1];
				IL_6F:
				num2 = 8;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_8D:
				num2 = 9;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_99:
				num2 = 10;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_AB:
				num2 = 11;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = selection.Value;
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						CAD.ChangeLayer(selectedObject.ObjectId, "墙柱轮廓");
						Polyline polyline = (Polyline)transaction.GetObject(selectedObject.ObjectId, 1);
						polyline.ConstantWidth = 0.0;
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_155:
				num2 = 13;
				documentLock.Dispose();
				IL_15E:
				goto IL_1F1;
				IL_163:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1AB:
				goto IL_1E6;
				IL_1AD:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_163;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1C3:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_1AD;
			}
			IL_1E6:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1F1:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			CAD.CreateLayer("NotPrint", 252, "continuous", -1, false, false);
			string[] array = new string[]
			{
				null,
				null,
				null,
				"轴压比:" + this.TextBox_0.Text
			};
			array[2] = "特征值:" + this.TextBox7.Text;
			array[1] = "构造:" + this.TextBox8.Text + "%";
			array[0] = "实配:" + this.TextBox6.Text + "%";
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (point != point3d)
			{
				Class36.smethod_20(point, array, 150.0, -1.5, "NotPrint");
			}
			documentLock.Dispose();
		}

		private void TextBox_0_TextChanged(object sender, EventArgs e)
		{
			int num;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double num3 = Conversion.Val(this.TextBox_0.Text);
				IL_1C:
				num2 = 3;
				string text = this.ComboBox5.Text;
				IL_2A:
				num2 = 6;
				if (Operators.CompareString(text, "一级(9度)", false) != 0)
				{
					goto IL_91;
				}
				IL_3D:
				num2 = 7;
				if (num3 <= 0.2)
				{
					goto IL_6D;
				}
				IL_4D:
				num2 = 8;
				this.TextBox7.Text = Conversions.ToString(0.2);
				goto IL_15A;
				IL_6D:
				num2 = 10;
				IL_70:
				num2 = 11;
				this.TextBox7.Text = Conversions.ToString(0.12);
				goto IL_15A;
				IL_91:
				num2 = 14;
				if (Operators.CompareString(text, "一级(6、7、8度)", false) != 0)
				{
					goto IL_F8;
				}
				IL_A5:
				num2 = 15;
				if (num3 <= 0.3)
				{
					goto IL_D7;
				}
				IL_B6:
				num2 = 16;
				this.TextBox7.Text = Conversions.ToString(0.2);
				goto IL_15A;
				IL_D7:
				num2 = 18;
				IL_DA:
				num2 = 19;
				this.TextBox7.Text = Conversions.ToString(0.12);
				goto IL_15A;
				IL_F8:
				num2 = 22;
				if (Operators.CompareString(text, "二级、三级", false) != 0)
				{
					goto IL_15A;
				}
				IL_10C:
				num2 = 23;
				if (num3 <= 0.4)
				{
					goto IL_13B;
				}
				IL_11D:
				num2 = 24;
				this.TextBox7.Text = Conversions.ToString(0.2);
				goto IL_15A;
				IL_13B:
				num2 = 26;
				IL_13E:
				num2 = 27;
				this.TextBox7.Text = Conversions.ToString(0.12);
				IL_15A:
				goto IL_230;
				IL_15F:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_1E7:
				goto IL_225;
				IL_1E9:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_15F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_202:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1E9;
			}
			IL_225:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_230:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void TextBox_3_TextChanged(object sender, EventArgs e)
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
				this.LaJinN = checked((long)Math.Round(Conversion.Val(this.TextBox_3.Text)));
				IL_27:
				goto IL_87;
				IL_29:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_43:
				goto IL_7C;
				IL_45:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_29;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_5A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_45;
			}
			IL_7C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_87:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("ComboBox2")]
		private ComboBox _ComboBox2;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("TextBox7")]
		private TextBox _TextBox7;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("TextBox8")]
		private TextBox _TextBox8;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("ComboBox3")]
		private ComboBox _ComboBox3;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("TextBox9")]
		private TextBox _TextBox9;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("ComboBox4")]
		private ComboBox _ComboBox4;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("TextBox10")]
		private TextBox textBox_0;

		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		[AccessedThroughProperty("ComboBox5")]
		private ComboBox _ComboBox5;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("GroupBox3")]
		private GroupBox _GroupBox3;

		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Label16")]
		private Label _Label16;

		[AccessedThroughProperty("TextBox11")]
		private TextBox textBox_1;

		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		[AccessedThroughProperty("TextBox12")]
		private TextBox textBox_2;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button8")]
		private Button _Button8;

		[AccessedThroughProperty("Button9")]
		private Button amIrsvPmtO;

		[AccessedThroughProperty("Button10")]
		private Button _Button10;

		[AccessedThroughProperty("TextBox13")]
		private TextBox textBox_3;

		public SelectionSet QZ_Collection;

		public DoubleCollection GuJin;

		public long PL_Area;

		public long Acor;

		public double BiLi;

		public bool IsQiang;

		public long C;

		public long JianJu;

		public long ZhiJing;

		public long LaJinN;
	}
}
