using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public partial class TcQuRa_frm : Form
	{
		[DebuggerNonUserCode]
		static TcQuRa_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcQuRa_frm.list_0 = new List<WeakReference>();
		}

		public TcQuRa_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcQuRa_frm_Load;
			TcQuRa_frm.smethod_0(this);
			this.objectId_0 = ObjectId.Null;
			this.double_0 = 100.0;
			this.bool_0 = true;
			this.double_6 = 0.0;
			this.string_0 = "NORMAL";
			this.double_7 = 0.0;
			this.double_8 = 0.8;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcQuRa_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcQuRa_frm.list_0.Count == TcQuRa_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcQuRa_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcQuRa_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcQuRa_frm.list_0[num] = TcQuRa_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcQuRa_frm.list_0.RemoveRange(num, TcQuRa_frm.list_0.Count - num);
						TcQuRa_frm.list_0.Capacity = TcQuRa_frm.list_0.Count;
					}
					TcQuRa_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				EventHandler value2 = new EventHandler(this.TextBox1_Click);
				if (this._TextBox1 != null)
				{
					this._TextBox1.Click -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.Click += value2;
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

		internal virtual NumericUpDown NumericUpDown1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._NumericUpDown1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.NumericUpDown1_ValueChanged);
				if (this._NumericUpDown1 != null)
				{
					this._NumericUpDown1.ValueChanged -= value2;
				}
				this._NumericUpDown1 = value;
				if (this._NumericUpDown1 != null)
				{
					this._NumericUpDown1.ValueChanged += value2;
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
				this._Label2 = value;
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

		internal virtual NumericUpDown NumericUpDown2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._NumericUpDown2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.jipAtgRsh);
				if (this._NumericUpDown2 != null)
				{
					this._NumericUpDown2.ValueChanged -= value2;
				}
				this._NumericUpDown2 = value;
				if (this._NumericUpDown2 != null)
				{
					this._NumericUpDown2.ValueChanged += value2;
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

		internal virtual DataGridView DataGridView1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DataGridViewCellEventHandler value2 = new DataGridViewCellEventHandler(this.DataGridView1_CellValueChanged);
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.CellValueChanged -= value2;
				}
				this._DataGridView1 = value;
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.CellValueChanged += value2;
				}
			}
		}

		internal virtual DataGridViewTextBoxColumn Column1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column1 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column2 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column7 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column3 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column4 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column5 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column6 = value;
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
				this._TextBox3 = value;
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
				EventHandler value2 = new EventHandler(this.method_3);
				EventHandler value3 = new EventHandler(this.method_2);
				if (this._TextBox7 != null)
				{
					this._TextBox7.TextChanged -= value2;
					this._TextBox7.LostFocus -= value3;
				}
				this._TextBox7 = value;
				if (this._TextBox7 != null)
				{
					this._TextBox7.TextChanged += value2;
					this._TextBox7.LostFocus += value3;
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
				this._TextBox9 = value;
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
				EventHandler value2 = new EventHandler(this.TextBox2_TextChanged);
				if (this._TextBox2 != null)
				{
					this._TextBox2.TextChanged -= value2;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.TextChanged += value2;
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

		internal virtual RadioButton RadioButton3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton3 = value;
			}
		}

		internal virtual RadioButton RadioButton4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.RadioButton4_CheckedChanged);
				if (this._RadioButton4 != null)
				{
					this._RadioButton4.CheckedChanged -= value2;
				}
				this._RadioButton4 = value;
				if (this._RadioButton4 != null)
				{
					this._RadioButton4.CheckedChanged += value2;
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
				this.textBox_0 = value;
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
				this.textBox_1 = value;
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
				this._Button5 = value;
			}
		}

		internal virtual Button Button9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button9 = value;
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

		internal virtual Label Label17
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label17;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label17 = value;
			}
		}

		internal virtual Label Label18
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label18;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label18 = value;
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
				EventHandler value2 = new EventHandler(this.method_5);
				EventHandler value3 = new EventHandler(this.method_4);
				if (this.textBox_2 != null)
				{
					this.textBox_2.TextChanged -= value2;
					this.textBox_2.LostFocus -= value3;
				}
				this.textBox_2 = value;
				if (this.textBox_2 != null)
				{
					this.textBox_2.TextChanged += value2;
					this.textBox_2.LostFocus += value3;
				}
			}
		}

		internal virtual Label Label19
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label19;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label19 = value;
			}
		}

		internal virtual Label Label20
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label20;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label20 = value;
			}
		}

		internal virtual Button Button11
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button11_Click);
				if (this._Button11 != null)
				{
					this._Button11.Click -= value2;
				}
				this._Button11 = value;
				if (this._Button11 != null)
				{
					this._Button11.Click += value2;
				}
			}
		}

		internal virtual Label Label21
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label21;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label21 = value;
			}
		}

		internal virtual PictureBox PictureBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._PictureBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._PictureBox1 = value;
			}
		}

		internal virtual Button Button12
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button12_Click);
				if (this._Button12 != null)
				{
					this._Button12.Click -= value2;
				}
				this._Button12 = value;
				if (this._Button12 != null)
				{
					this._Button12.Click += value2;
				}
			}
		}

		internal virtual Button Button13
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button13;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button13_Click);
				if (this._Button13 != null)
				{
					this._Button13.Click -= value2;
				}
				this._Button13 = value;
				if (this._Button13 != null)
				{
					this._Button13.Click += value2;
				}
			}
		}

		internal virtual PrintDialog PrintDialog1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.printDialog_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.printDialog_0 = value;
			}
		}

		internal virtual Label Label22
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label22;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label22 = value;
			}
		}

		[DllImport("gdi32.dll")]
		public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

		[DllImport("User32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr hwd);

		[DllImport("User32.dll")]
		public static extern int ReleaseDC(IntPtr hwd, IntPtr dc);

		[DllImport("User32.dll")]
		public static extern bool GetWindowRect(IntPtr hWnd, ref TcQuRa_frm.RECT lpRect);

		private void TextBox1_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_3F:
				num2 = 5;
				this.TextBox1.Text = Conversions.ToString(this.GetDist("在勘察剖面图上测量1m的距离:", 100.0));
				IL_65:
				num2 = 6;
				this.double_0 = Conversions.ToDouble(this.TextBox1.Text);
				IL_7D:
				num2 = 7;
				documentLock.Dispose();
				IL_85:
				num2 = 8;
				this.Show();
				IL_8D:
				goto IL_FE;
				IL_8F:
				goto IL_108;
				IL_91:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_A8;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_DC;
				IL_A8:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_DC:
				goto IL_108;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_91;
			}
			IL_FE:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_108:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public double GetDist(string Prompt = "在勘察剖面图上测量1m的距离:", double DefaultLen = 100.0)
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			PromptDistanceOptions promptDistanceOptions = new PromptDistanceOptions("\n" + Prompt);
			promptDistanceOptions.UseDefaultValue = true;
			promptDistanceOptions.DefaultValue = DefaultLen;
			PromptDoubleResult distance = mdiActiveDocument.Editor.GetDistance(promptDistanceOptions);
			double result;
			if (distance.Status == 5100)
			{
				result = distance.Value;
			}
			else
			{
				result = DefaultLen;
			}
			return result;
		}

		private void Button2_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_40:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4D:
				num2 = 6;
				PromptPointOptions promptPointOptions = new PromptPointOptions("设置0.000点:");
				IL_5A:
				num2 = 7;
				PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
				IL_6A:
				num2 = 8;
				if (point.Status != 5100)
				{
					goto IL_AF;
				}
				IL_7C:
				num2 = 9;
				this.Button2.Text = Conversions.ToString(point.Value.Y);
				IL_9F:
				num2 = 10;
				this.point3d_0 = point.Value;
				IL_AF:
				num2 = 12;
				documentLock.Dispose();
				IL_B9:
				num2 = 13;
				this.Show();
				IL_C2:
				goto IL_154;
				IL_C7:
				goto IL_15F;
				IL_CC:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_E4;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_12E;
				IL_E4:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_12E:
				goto IL_15F;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_CC;
			}
			IL_154:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_15F:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			int num;
			int num8;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.Hide();
				IL_11:
				num2 = 3;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_40:
				num2 = 5;
				Polyline polyline = new Polyline();
				IL_48:
				num2 = 6;
				this.long_0 = Convert.ToInt64(this.NumericUpDown1.Value);
				IL_60:
				num2 = 7;
				this.long_1 = Convert.ToInt64(this.NumericUpDown2.Value);
				IL_78:
				num2 = 8;
				double num3 = (double)this.long_1 / 1000.0 * this.double_0;
				IL_93:
				num2 = 9;
				double num4 = (double)this.long_0 * this.double_0;
				IL_A6:
				num2 = 10;
				if (this.long_0 < 1L)
				{
					goto IL_1CF;
				}
				IL_C2:
				num2 = 11;
				if (this.long_1 < 200L)
				{
					goto IL_1BA;
				}
				IL_DE:
				num2 = 12;
				Polyline polyline2 = polyline;
				int num5 = 0;
				Point2d point2d;
				point2d..ctor(0.0, 0.0);
				polyline2.AddVertexAt(num5, point2d, 0.0, num3, num3);
				IL_10E:
				num2 = 13;
				Polyline polyline3 = polyline;
				int num6 = 1;
				point2d..ctor(0.0, -num4);
				polyline3.AddVertexAt(num6, point2d, 0.0, num3, num3);
				IL_138:
				num2 = 14;
				polyline.ColorIndex = 1;
				IL_142:
				num2 = 15;
				JigEnt jigEnt = new JigEnt();
				IL_14C:
				num2 = 16;
				JigEnt jigEnt2 = jigEnt;
				ObjectId objectId = CAD.AddEnt(polyline).ObjectId;
				Point3d basePoint;
				basePoint..ctor(0.0, 0.0, 0.0);
				this.objectId_0 = jigEnt2.JigEnt(objectId, basePoint);
				IL_18B:
				num2 = 17;
				this.Button6.Enabled = true;
				IL_19A:
				num2 = 18;
				this.Button7.Enabled = true;
				IL_1A9:
				num2 = 19;
				this.Button11.Enabled = true;
				goto IL_1E2;
				IL_1BA:
				num2 = 21;
				IL_1BD:
				num2 = 22;
				Interaction.MsgBox("桩径不能太小!", MsgBoxStyle.OkOnly, null);
				goto IL_1E2;
				IL_1CF:
				num2 = 25;
				IL_1D2:
				num2 = 26;
				Interaction.MsgBox("桩长不能太小!", MsgBoxStyle.OkOnly, null);
				IL_1E2:
				num2 = 28;
				this.string_0 = "ABNORMAL";
				IL_1F0:
				num2 = 29;
				this.GetQuRa_Abnormal();
				IL_1F9:
				num2 = 30;
				documentLock.Dispose();
				IL_203:
				num2 = 31;
				this.Show();
				IL_20C:
				goto IL_2EA;
				IL_211:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_2A1:
				goto IL_2DF;
				IL_2A3:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_211;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2BC:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2A3;
			}
			IL_2DF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2EA:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public void GetQuRa_Abnormal()
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Editor editor = mdiActiveDocument.Editor;
				Database database = mdiActiveDocument.Database;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				this.point3dCollection_0 = new Point3dCollection();
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					Polyline polyline = (Polyline)transaction.GetObject(this.objectId_0, 1);
					if (polyline != null)
					{
						Point3d startPoint = polyline.StartPoint;
						this.point3dCollection_0.Add(startPoint);
						this.gntrwnIqfF = (startPoint.Y - this.point3d_0.Y) / this.double_0;
						this.TextBox7.Text = Strings.Format(this.gntrwnIqfF, "0.000");
						short num = -1;
						short num2 = 0;
						short num3 = checked(this.short_0 - 1);
						short num4 = num2;
						for (;;)
						{
							short num5 = num4;
							short num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							if (this.polyline_0[(int)num4].GetClosestPointTo(startPoint, true).Y <= startPoint.Y)
							{
								goto IL_109;
							}
							num4 += 1;
						}
						goto IL_10D;
						IL_109:
						num = num4;
						IL_10D:
						if (num == -1)
						{
							num = this.short_0;
						}
						editor.WriteMessage("\r\n桩顶进入" + Conversions.ToString((int)num) + "层土");
						short num7 = -1;
						bool flag = false;
						short num8 = -1;
						bool flag2 = false;
						short num9 = 0;
						short num10 = checked(this.short_0 - 1);
						short num11 = num9;
						for (;;)
						{
							short num12 = num11;
							short num6 = num10;
							if (num12 > num6)
							{
								break;
							}
							Point3dCollection point3dCollection = new Point3dCollection();
							this.polyline_0[(int)num11].IntersectWith(polyline, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
							checked
							{
								if (point3dCollection.Count == 1)
								{
									if (!flag)
									{
										if (startPoint.DistanceTo(point3dCollection[0]) == 0.0)
										{
											num7 = num11 + 1;
										}
										else
										{
											num7 = num11;
											this.point3dCollection_0.Add(point3dCollection[0]);
										}
										flag = true;
									}
									else
									{
										this.point3dCollection_0.Add(point3dCollection[0]);
									}
								}
								else if (point3dCollection.Count == 0 && flag)
								{
									if (!flag2)
									{
										num8 = num11;
										flag2 = true;
									}
								}
								else if (num11 == this.short_0 - 1 & !flag & !flag2)
								{
									num7 = num;
									num8 = num;
								}
							}
							num11 += 1;
						}
						this.point3dCollection_0.Add(CAD.GetPointXY(startPoint, 0.0, (double)(checked(0L - this.long_0)) * this.double_0));
						editor.WriteMessage("\r\n" + Conversions.ToString(this.point3dCollection_0.Count));
						if (num7 == -1)
						{
							num7 = 0;
						}
						editor.WriteMessage("\r\n桩顶进入" + Conversions.ToString((int)num7) + "层土");
						if (num8 == -1)
						{
							num8 = this.short_0;
						}
						editor.WriteMessage("\r\n桩底进入" + Conversions.ToString((int)num8) + "层土");
						short num27;
						short num28;
						checked
						{
							this.NnGraoarmy = new double[(int)(this.short_0 + 1)];
							if (num7 >= 1)
							{
								short num13 = 0;
								short num14 = num7 - 1;
								short num15 = num13;
								unchecked
								{
									for (;;)
									{
										short num16 = num15;
										short num6 = num14;
										if (num16 > num6)
										{
											break;
										}
										this.NnGraoarmy[(int)num15] = 0.0;
										num15 += 1;
									}
								}
							}
							else
							{
								this.NnGraoarmy[0] = 0.0;
							}
							short num17 = 0;
							short num18 = (short)(this.point3dCollection_0.Count - 2);
							short num19 = num17;
							for (;;)
							{
								short num20 = num19;
								short num6 = num18;
								if (num20 > num6)
								{
									break;
								}
								double num21 = this.point3dCollection_0[(int)num19].DistanceTo(this.point3dCollection_0[(int)(num19 + 1)]);
								unchecked
								{
									this.NnGraoarmy[(int)(num7 + num19)] = num21 / this.double_0;
									num19 += 1;
								}
							}
							if (num8 <= this.short_0 - 2 & num8 != -1)
							{
								short num22 = num8 + 1;
								short num23 = this.short_0 - 1;
								short num24 = num22;
								unchecked
								{
									for (;;)
									{
										short num25 = num24;
										short num6 = num23;
										if (num25 > num6)
										{
											break;
										}
										this.NnGraoarmy[(int)num24] = 0.0;
										num24 += 1;
									}
								}
							}
							short num26 = 1;
							num27 = this.short_0;
							num28 = num26;
						}
						for (;;)
						{
							short num29 = num28;
							short num6 = num27;
							if (num29 > num6)
							{
								break;
							}
							this.DataGridView1.Rows[(int)(checked(num28 - 1))].Cells[2].Value = Strings.Format(this.NnGraoarmy[(int)num28], "0.00");
							editor.WriteMessage("\r\n" + Conversions.ToString((int)num28) + "  " + Conversions.ToString(this.NnGraoarmy[(int)num28]));
							num28 += 1;
						}
					}
					transaction.Commit();
				}
				documentLock.Dispose();
				this.GetQuRa();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void Button6_Click(object sender, EventArgs e)
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
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_37:
				num2 = 4;
				Class36.smethod_64(this.objectId_0);
				IL_45:
				num2 = 5;
				documentLock.Dispose();
				IL_4D:
				num2 = 6;
				this.Button1.Enabled = true;
				IL_5B:
				num2 = 7;
				this.Button7.Enabled = false;
				IL_69:
				num2 = 8;
				this.Button11.Enabled = false;
				IL_77:
				goto IL_EF;
				IL_79:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_AB:
				goto IL_E4;
				IL_AD:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_79;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_C2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_AD;
			}
			IL_E4:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_EF:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_0(object sender, PointMonitorEventArgs e)
		{
			if (!(this.objectId_0 == ObjectId.Null))
			{
				try
				{
					Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
					Editor editor = mdiActiveDocument.Editor;
					Database database = mdiActiveDocument.Database;
					DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
					this.point3dCollection_0 = new Point3dCollection();
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						Polyline polyline = (Polyline)transaction.GetObject(this.objectId_0, 1);
						if (polyline != null)
						{
							Point3d computedPoint = e.Context.ComputedPoint;
							if (!polyline.StartPoint.IsEqualTo(computedPoint))
							{
								Polyline polyline2 = polyline;
								int num = 0;
								Point2d point2d;
								point2d..ctor(computedPoint.X, computedPoint.Y);
								polyline2.SetPointAt(num, point2d);
								Polyline polyline3 = polyline;
								int num2 = 1;
								point2d..ctor(computedPoint.X, computedPoint.Y - (double)this.long_0 * this.double_0);
								polyline3.SetPointAt(num2, point2d);
							}
						}
						transaction.Commit();
					}
					documentLock.Dispose();
					this.string_0 = "ABNORMAL";
					this.GetQuRa_Abnormal();
				}
				catch (Exception ex)
				{
					throw;
				}
			}
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			this.string_0 = "ABNORMAL";
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			Database database = mdiActiveDocument.Database;
			try
			{
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\r\n选择桩:");
				promptEntityOptions.SetRejectMessage("只能PL线绘制的桩:");
				promptEntityOptions.AddAllowedClass(typeof(Polyline), true);
				object entity = editor.GetEntity(promptEntityOptions);
				if (!Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(entity, null, "Status", new object[0], null, null, null), 5100, false))
				{
					editor.PointMonitor += new PointMonitorEventHandler(this.method_0);
					object obj = new PromptPointOptions("\r\n移动至:");
					object instance = editor;
					Type type = null;
					string memberName = "GetPoint";
					object[] array = new object[]
					{
						RuntimeHelpers.GetObjectValue(obj)
					};
					object[] arguments = array;
					string[] argumentNames = null;
					Type[] typeArguments = null;
					bool[] array2 = new bool[]
					{
						true
					};
					object obj2 = NewLateBinding.LateGet(instance, type, memberName, arguments, argumentNames, typeArguments, array2);
					if (array2[0])
					{
						obj = RuntimeHelpers.GetObjectValue(array[0]);
					}
					PromptPointResult promptPointResult = (PromptPointResult)obj2;
					if (promptPointResult.Status == 5100)
					{
						editor.PointMonitor -= new PointMonitorEventHandler(this.method_0);
					}
				}
			}
			catch (Exception ex)
			{
				editor.WriteMessage("\r\n" + ex.Message);
			}
			finally
			{
				editor.PointMonitor -= new PointMonitorEventHandler(this.method_0);
			}
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			int num;
			int num22;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.string_0 = "";
				IL_16:
				num2 = 3;
				this.DataGridView1.Rows.Clear();
				IL_28:
				num2 = 4;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_44:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_51:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_5A:
				num2 = 7;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_6D:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						short num14;
						short num15;
						checked
						{
							this.short_0 = (short)value.Count;
							this.polyline_0 = new Polyline[(int)(this.short_0 - 1 + 1)];
							this.NnGraoarmy = new double[(int)(this.short_0 + 1)];
							foreach (ObjectId objectId in value.GetObjectIds())
							{
								short num3;
								this.polyline_0[(int)num3] = (Polyline)transaction.GetObject(objectId, 1);
								num3 += 1;
							}
							short num4 = 0;
							short num5 = this.short_0 - 1;
							short num6 = num4;
							for (;;)
							{
								short num7 = num6;
								short num8 = num5;
								if (num7 > num8)
								{
									break;
								}
								Point3d startPoint = this.polyline_0[(int)num6].StartPoint;
								short num9 = 0;
								short num10 = this.short_0 - 1;
								short num11 = num9;
								unchecked
								{
									for (;;)
									{
										short num12 = num11;
										num8 = num10;
										if (num12 > num8)
										{
											break;
										}
										if (this.polyline_0[(int)num11].StartPoint.Y < startPoint.Y)
										{
											Polyline polyline = this.polyline_0[(int)num11];
											this.polyline_0[(int)num11] = this.polyline_0[(int)num6];
											this.polyline_0[(int)num6] = polyline;
										}
										num11 += 1;
									}
									num6 += 1;
								}
							}
							short num13 = 0;
							num14 = this.short_0 - 1;
							num15 = num13;
						}
						for (;;)
						{
							short num16 = num15;
							short num8 = num14;
							if (num16 > num8)
							{
								break;
							}
							this.polyline_0[(int)num15].ColorIndex = (int)num15;
							num15 += 1;
						}
						transaction.Commit();
					}
				}
				IL_245:
				num2 = 10;
				documentLock.Dispose();
				IL_24F:
				num2 = 11;
				short num17 = 1;
				short num18 = this.short_0;
				short num19 = num17;
				for (;;)
				{
					short num20 = num19;
					short num8 = num18;
					if (num20 > num8)
					{
						break;
					}
					IL_25F:
					num2 = 12;
					string[] values = new string[]
					{
						Conversions.ToString((int)num19),
						"粘土",
						"0",
						"50",
						"5000",
						"1",
						"0.7"
					};
					IL_2AF:
					num2 = 13;
					this.DataGridView1.Rows.Add(values);
					IL_2C5:
					num2 = 14;
					num19 += 1;
				}
				IL_2D9:
				num2 = 15;
				this.DataGridView1.Columns[0].ReadOnly = true;
				IL_2F3:
				num2 = 16;
				this.DataGridView1.Columns[2].ReadOnly = true;
				IL_30D:
				num2 = 17;
				if (Information.Err().Number <= 0)
				{
					goto IL_336;
				}
				IL_31F:
				num2 = 18;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_366;
				IL_336:
				num2 = 20;
				IL_339:
				num2 = 21;
				this.Button1.Enabled = true;
				IL_348:
				num2 = 22;
				this.Button6.Enabled = true;
				IL_357:
				num2 = 23;
				this.Button7.Enabled = true;
				IL_366:
				goto IL_425;
				IL_36B:
				int num21 = num22 + 1;
				num22 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num21);
				IL_3DF:
				goto IL_41A;
				IL_3E1:
				num22 = num2;
				if (num <= -2)
				{
					goto IL_36B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_3F7:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num22 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_3E1;
			}
			IL_41A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_425:
			if (num22 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButton2.Checked)
			{
				this.Label3.Text = "桩径(mm)";
			}
			else
			{
				this.Label3.Text = "边长(mm)";
			}
			this.method_1();
		}

		private void jipAtgRsh(object sender, EventArgs e)
		{
			this.long_2 = Convert.ToInt64(this.NumericUpDown2.Value);
			this.long_1 = this.long_2;
			this.method_1();
		}

		private void TextBox2_TextChanged(object sender, EventArgs e)
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
				this.long_3 = checked((long)Math.Round(Conversion.Val(this.TextBox2.Text)));
				IL_27:
				num2 = 3;
				this.method_1();
				IL_2F:
				goto IL_8C;
				IL_31:
				goto IL_96;
				IL_33:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_4A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_6A;
				IL_4A:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_6A:
				goto IL_96;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_33;
			}
			IL_8C:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_96:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public void method_1()
		{
			if (this.RadioButton2.Checked)
			{
				this.double_1 = 0.78539816339744828 * (double)this.long_2 * (double)this.long_2 / 1000.0 / 1000.0;
				this.double_4 = 3.1415926535897931 * (double)this.long_2 / 1000.0;
			}
			else
			{
				checked
				{
					this.double_1 = (double)(this.long_2 * this.long_2) / 1000.0 / 1000.0;
					this.double_4 = (double)(4L * this.long_2) / 1000.0;
				}
			}
			this.double_3 = 0.78539816339744828 * (double)this.long_3 * (double)this.long_3 / 1000.0 / 1000.0;
			this.double_2 = this.double_1 - this.double_3;
			this.TextBox3.Text = Strings.Format(this.double_4, "0.0000");
			this.TextBox4.Text = Strings.Format(this.double_1, "0.0000");
			this.TextBox5.Text = Strings.Format(this.double_3, "0.0000");
			this.GetQuRa();
		}

		public void GetQuRa()
		{
			this.Label22.Text = "";
			checked
			{
				if (Operators.CompareString(this.string_0, "NORMAL", false) == 0)
				{
					short num = (short)(this.DataGridView1.Rows.Count - 1);
					if (num >= 1)
					{
						this.long_0 = 0L;
						double num2 = this.gntrwnIqfF;
						double num3 = 0.0;
						short num4 = 0;
						short num5 = num - 1;
						short num6 = num4;
						unchecked
						{
							for (;;)
							{
								short num7 = num6;
								short num8 = num5;
								if (num7 > num8)
								{
									break;
								}
								double num9 = Conversion.Val(this.DataGridView1.Rows[(int)num6].Cells[2].Value.ToString());
								double num10 = Conversion.Val(this.DataGridView1.Rows[(int)num6].Cells[3].Value.ToString());
								double num11;
								if (this.bool_0)
								{
									num11 = Conversion.Val(this.DataGridView1.Rows[(int)num6].Cells[5].Value.ToString());
								}
								else
								{
									num11 = Conversion.Val(this.DataGridView1.Rows[(int)num6].Cells[6].Value.ToString());
								}
								num3 += num9 * this.double_4 * num10 * num11;
								this.long_0 = checked((long)Math.Round(unchecked((double)this.long_0 + num9)));
								num2 -= num9;
								num6 += 1;
							}
						}
						double num12 = Conversion.Val(this.DataGridView1.Rows[(int)(num - 1)].Cells[4].Value.ToString());
						double num13 = Conversion.Val(this.DataGridView1.Rows[(int)(num - 1)].Cells[2].Value.ToString());
						unchecked
						{
							if (num13 / ((double)this.long_2 / 1000.0) >= 5.0)
							{
								this.double_8 = 0.8;
							}
							else
							{
								this.double_8 = 0.16 * num13 / ((double)this.long_2 / 1000.0);
							}
							if (this.bool_0)
							{
								this.double_7 = (this.double_1 + this.double_3 * this.double_8) * num12;
								if (this.double_3 != 0.0)
								{
									this.Label22.Text = "塞土效应系数: " + Strings.Format(this.double_8, "0.00");
								}
							}
							else
							{
								this.double_7 = (this.double_1 - this.double_3) * 25.0 * (double)this.long_0;
								this.Label22.Text = "桩身自重(KN): " + Strings.Format(this.double_7, "0.00");
							}
						}
						this.long_4 = (long)Math.Round(unchecked(num3 + this.double_7));
						this.long_5 = (long)Math.Round((double)this.long_4 / 2.0);
						this.TextBox_0.Text = Conversions.ToString(this.long_4);
						this.TextBox_1.Text = Conversions.ToString(this.long_5);
						this.NumericUpDown1.Value = new decimal(this.long_0);
						this.TextBox6.Text = Strings.Format(Math.Abs(unchecked(this.double_6 - num2)), "0.000");
						this.TextBox8.Text = Strings.Format(num2, "0.000");
						this.TextBox9.Text = Conversions.ToString((int)num);
					}
				}
				else if (Operators.CompareString(this.string_0, "ABNORMAL", false) == 0)
				{
					short num14 = (short)(this.DataGridView1.Rows.Count - 1);
					if (num14 >= 1)
					{
						this.long_0 = Convert.ToInt64(this.NumericUpDown1.Value);
						double num15 = this.gntrwnIqfF;
						double num16 = 0.0;
						short num17 = 0;
						short num18 = num14 - 1;
						short num19 = num17;
						unchecked
						{
							for (;;)
							{
								short num20 = num19;
								short num8 = num18;
								if (num20 > num8)
								{
									break;
								}
								double num21 = Conversion.Val(this.DataGridView1.Rows[(int)num19].Cells[2].Value.ToString());
								double num22 = Conversion.Val(this.DataGridView1.Rows[(int)num19].Cells[3].Value.ToString());
								double num23;
								if (this.bool_0)
								{
									num23 = Conversion.Val(this.DataGridView1.Rows[(int)num19].Cells[5].Value.ToString());
								}
								else
								{
									num23 = Conversion.Val(this.DataGridView1.Rows[(int)num19].Cells[6].Value.ToString());
								}
								num16 += num21 * this.double_4 * num22 * num23;
								num19 += 1;
							}
							for (short num24 = checked(num14 - 1); num24 >= 0; num24 += -1)
							{
								double num25 = Conversion.Val(this.DataGridView1.Rows[(int)num24].Cells[2].Value.ToString());
								if (num25 > 0.0)
								{
									double num26 = Conversion.Val(this.DataGridView1.Rows[(int)num24].Cells[4].Value.ToString());
									IL_594:
									if (num25 / ((double)this.long_2 / 1000.0) >= 5.0)
									{
										this.double_8 = 0.8;
									}
									else
									{
										this.double_8 = 0.16 * num25 / ((double)this.long_2 / 1000.0);
									}
									if (this.bool_0)
									{
										this.double_7 = (this.double_1 + this.double_3 * this.double_8) * num26;
										if (this.double_3 != 0.0)
										{
											this.Label22.Text = "塞土效应系数: " + Strings.Format(this.double_8, "0.00");
										}
									}
									else
									{
										this.double_7 = (this.double_1 - this.double_3) * 25.0 * (double)this.long_0;
										this.Label22.Text = "桩身自重(KN): " + Strings.Format(this.double_7, "0.00");
									}
									checked
									{
										this.long_4 = (long)Math.Round(unchecked(num16 + this.double_7));
										this.long_5 = (long)Math.Round((double)this.long_4 / 2.0);
										this.TextBox_0.Text = Conversions.ToString(this.long_4);
										this.TextBox_1.Text = Conversions.ToString(this.long_5);
									}
									this.TextBox6.Text = Strings.Format(Math.Abs(this.double_6 - num15), "0.000");
									this.TextBox8.Text = Strings.Format(num15, "0.000");
									this.TextBox9.Text = Conversions.ToString((int)num14);
									return;
								}
							}
							goto IL_594;
						}
					}
				}
			}
		}

		private void Button4_Click(object sender, EventArgs e)
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
				short num3 = checked((short)this.DataGridView1.RowCount);
				IL_19:
				num2 = 3;
				string[] values = null;
				IL_1E:
				num2 = 4;
				if (num3 != 1)
				{
					goto IL_72;
				}
				IL_27:
				num2 = 5;
				values = new string[]
				{
					Conversions.ToString((int)num3),
					"粘土",
					"2",
					"50",
					"5000",
					"1",
					"0.7"
				};
				goto IL_1F7;
				IL_72:
				num2 = 7;
				IL_74:
				num2 = 8;
				string text = Conversions.ToString(Conversion.Val(this.DataGridView1.Rows[(int)(checked(num3 - 2))].Cells[0].Value.ToString()) + 1.0);
				IL_B4:
				num2 = 9;
				checked
				{
					string text2 = this.DataGridView1.Rows[(int)(num3 - 2)].Cells[1].Value.ToString();
					IL_E2:
					num2 = 10;
					string text3 = this.DataGridView1.Rows[(int)(num3 - 2)].Cells[2].Value.ToString();
					IL_110:
					num2 = 11;
					string text4 = this.DataGridView1.Rows[(int)(num3 - 2)].Cells[3].Value.ToString();
					IL_13E:
					num2 = 12;
					string text5 = this.DataGridView1.Rows[(int)(num3 - 2)].Cells[4].Value.ToString();
					IL_16C:
					num2 = 13;
					string text6 = this.DataGridView1.Rows[(int)(num3 - 2)].Cells[5].Value.ToString();
					IL_19A:
					num2 = 14;
					string text7 = this.DataGridView1.Rows[(int)(num3 - 2)].Cells[6].Value.ToString();
					IL_1C8:
					num2 = 15;
					values = new string[]
					{
						text,
						text2,
						text3,
						text4,
						text5,
						text6,
						text7
					};
					IL_1F7:
					num2 = 17;
					this.DataGridView1.Rows.Add(values);
					IL_20D:
					num2 = 18;
					this.GetQuRa();
					IL_216:
					num2 = 19;
					if (Information.Err().Number <= 0)
					{
						goto IL_23D;
					}
					IL_228:
					num2 = 20;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_23D:
					goto IL_2F2;
					IL_242:
					goto IL_2FD;
					IL_247:
					num4 = num2;
					if (num <= -2)
					{
						goto IL_25F;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_2CC;
					IL_25F:;
				}
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_2CC:
				goto IL_2FD;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_247;
			}
			IL_2F2:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_2FD:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (object obj in this.DataGridView1.SelectedRows)
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
					if (!dataGridViewRow.IsNewRow)
					{
						this.DataGridView1.Rows.Remove(dataGridViewRow);
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
			this.GetQuRa();
		}

		private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			this.GetQuRa();
		}

		private void RadioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButton4.Checked)
			{
				this.bool_0 = false;
			}
			else
			{
				this.bool_0 = true;
			}
			this.GetQuRa();
		}

		private void method_2(object sender, EventArgs e)
		{
			this.TextBox7.Text = Strings.Format(this.gntrwnIqfF, "0.000");
		}

		private void method_3(object sender, EventArgs e)
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
				if (Operators.CompareString(this.string_0, "NORMAL", false) != 0)
				{
					goto IL_41;
				}
				IL_21:
				num2 = 3;
				this.gntrwnIqfF = Conversions.ToDouble(this.TextBox7.Text);
				IL_39:
				num2 = 4;
				this.GetQuRa();
				IL_41:
				goto IL_A6;
				IL_43:
				goto IL_B0;
				IL_45:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_5C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_84;
				IL_5C:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_84:
				goto IL_B0;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_45;
			}
			IL_A6:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_B0:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			if (this.Width == 728)
			{
				this.Width = 508;
			}
			else
			{
				this.Width = 728;
			}
		}

		private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			int num;
			int num7;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				if (Operators.CompareString(this.string_0, "NORMAL", false) != 0)
				{
					goto IL_176;
				}
				IL_24:
				num2 = 3;
				long num3 = Convert.ToInt64(this.NumericUpDown1.Value);
				IL_38:
				num2 = 4;
				if (num3 <= this.long_0)
				{
					goto IL_C0;
				}
				IL_46:
				num2 = 5;
				int rowCount = this.DataGridView1.RowCount;
				IL_54:
				num2 = 6;
				checked
				{
					double num4 = Conversion.Val(RuntimeHelpers.GetObjectValue(this.DataGridView1.Rows[rowCount - 2].Cells[2].Value));
					IL_84:
					num2 = 7;
					this.DataGridView1.Rows[rowCount - 2].Cells[2].Value = unchecked(num4 + (double)num3 - (double)this.long_0);
					goto IL_16D;
					IL_C0:
					num2 = 9;
					IL_C3:
					num2 = 10;
					int rowCount2 = this.DataGridView1.RowCount;
					IL_D3:
					num2 = 11;
					double num5 = Conversion.Val(RuntimeHelpers.GetObjectValue(this.DataGridView1.Rows[rowCount2 - 2].Cells[2].Value));
					IL_106:
					num2 = 12;
					double num6 = unchecked(num5 - (double)(checked(this.long_0 - num3)));
					IL_118:
					num2 = 13;
					if (num6 >= 0.0)
					{
						goto IL_13C;
					}
					IL_12A:
					num2 = 14;
					Interaction.MsgBox("土层中出现负桩长，请调整土层。", MsgBoxStyle.OkOnly, null);
					goto IL_16D;
					IL_13C:
					num2 = 16;
					IL_13F:
					num2 = 17;
					this.DataGridView1.Rows[rowCount2 - 2].Cells[2].Value = num6;
					IL_16D:
					num2 = 20;
					this.GetQuRa();
					IL_176:
					goto IL_22B;
					IL_17B:
					goto IL_236;
					IL_180:
					num7 = num2;
					if (num <= -2)
					{
						goto IL_198;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_205;
					IL_198:;
				}
				int num8 = num7 + 1;
				num7 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_205:
				goto IL_236;
			}
			catch when (endfilter(obj is Exception & num != 0 & num7 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_180;
			}
			IL_22B:
			if (num7 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_236:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void method_4(object sender, EventArgs e)
		{
			this.TextBox_2.Text = Strings.Format(this.double_6, "0.000");
		}

		private void method_5(object sender, EventArgs e)
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
				this.double_6 = Conversions.ToDouble(this.TextBox_2.Text);
				IL_21:
				goto IL_7A;
				IL_23:
				goto IL_84;
				IL_25:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_3C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_58;
				IL_3C:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_58:
				goto IL_84;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_25;
			}
			IL_7A:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_84:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void TcQuRa_frm_Load(object sender, EventArgs e)
		{
			this.Button1.Enabled = false;
			this.Button6.Enabled = false;
			this.Button7.Enabled = false;
		}

		private void Button12_Click(object sender, EventArgs e)
		{
			string text = "";
			text += "<html>";
			text += "<head>";
			text += "<title>单桩竖向竖向承载力计算书</title>";
			text += "<script type=\"text/javascript\">";
			text += "function printpage()";
			text += "{";
			text += " window.print()";
			text += "}";
			text += "</script>";
			text += "<style type=\"text/css\" media=\"print\">";
			text += ".NotPrint{ display: none; }";
			text += "</style>";
			text += "</head>";
			text += "<body style=\"text-align:center;\">";
			text += "<input type=\"button\" class=\"NotPrint\" value=\"打印\" onclick=\"printpage()\" />";
			text += "<div style=\"margin:auto;width:600px;top:20px;left:20px;right:20px;bottom:20px;padding-top:20px;padding-bottom:20px;padding-left:20px;padding-right:20px;border:1px solid #000000;\">";
			text += "<pre>";
			text += "<p style=\"font-size:20px;text-align:center;font-weight:bold;\">";
			text = Conversions.ToString(Operators.ConcatenateObject(text + "单桩竖向竖向承载力计算书", Interaction.IIf(this.bool_0, "(抗压)", "(抗拔)")));
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;\">";
			text += "一、截面参数";
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
			text = Conversions.ToString(Operators.ConcatenateObject(text + "类型: ", Interaction.IIf(this.RadioButton1.Checked, "方桩", "圆桩")));
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
			text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(text, Interaction.IIf(this.RadioButton1.Checked, "边长(mm) ", "桩径(mm) ")), this.NumericUpDown2.Text), '\t'), '\t'), Interaction.IIf(Operators.CompareString(this.TextBox2.Text, "0", false) == 0, "", "内径(mm) " + this.TextBox2.Text)));
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
			text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(text + "面积Ap(m²) " + this.TextBox4.Text + "\t", Interaction.IIf(Conversion.Val(this.TextBox5.Text) == 0.0, "", "面积Ap1(m²) " + this.TextBox5.Text)), '\t'), "周长u(m) "), this.TextBox3.Text));
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;\">";
			text += "二、竖向参数";
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
			text = string.Concat(new string[]
			{
				text,
				"桩长(m) ",
				this.NumericUpDown1.Text,
				"\t\t入土(m) ",
				this.TextBox6.Text,
				"\t\t进入持力层(m) ",
				this.TextBox9.Text
			});
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
			text = string.Concat(new string[]
			{
				text,
				"场地标高 ",
				this.TextBox_2.Text,
				"\t桩顶标高 ",
				this.TextBox7.Text,
				"\t\t桩底标高 ",
				this.TextBox8.Text
			});
			text += "</p>";
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;\">";
			text += "三、土层参数";
			text += "</p>";
			string text2 = "土层";
			string text3 = "名称";
			string text4 = "厚度";
			string text5 = "侧阻";
			string text6 = "端阻";
			string text7 = "液化折减";
			string text8 = "抗拔系数";
			text += "<p style=\"font-size:12px;text-align:left;font-weight:normal;text-indent:3em;\">";
			text = string.Concat(new string[]
			{
				text,
				text2,
				"\t",
				text3,
				"\t\t",
				text4,
				"\t",
				text5,
				"\t",
				text6,
				"\t",
				text7,
				"\t",
				text8,
				"\t"
			});
			text += "</p>";
			short num = checked((short)(this.DataGridView1.Rows.Count - 1));
			if (num >= 1)
			{
				short num2 = 0;
				short num3 = checked(num - 1);
				short num4 = num2;
				for (;;)
				{
					short num5 = num4;
					short num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					text2 = this.DataGridView1.Rows[(int)num4].Cells[0].Value.ToString();
					text3 = this.DataGridView1.Rows[(int)num4].Cells[1].Value.ToString();
					text4 = this.DataGridView1.Rows[(int)num4].Cells[2].Value.ToString();
					text5 = this.DataGridView1.Rows[(int)num4].Cells[3].Value.ToString();
					text6 = this.DataGridView1.Rows[(int)num4].Cells[4].Value.ToString();
					text7 = this.DataGridView1.Rows[(int)num4].Cells[5].Value.ToString();
					text8 = this.DataGridView1.Rows[(int)num4].Cells[5].Value.ToString();
					text += "<p style=\"font-size:12px;text-align:left;font-weight:normal;text-indent:3em;\">";
					if (text3.Length > 4)
					{
						text = string.Concat(new string[]
						{
							text,
							text2,
							"\t",
							text3,
							"\t",
							text4,
							"\t",
							text5,
							"\t",
							text6,
							"\t",
							text7,
							"\t",
							text8,
							"\t"
						});
					}
					else
					{
						text = string.Concat(new string[]
						{
							text,
							text2,
							"\t",
							text3,
							"\t\t",
							text4,
							"\t",
							text5,
							"\t",
							text6,
							"\t",
							text7,
							"\t",
							text8,
							"\t"
						});
					}
					text += "</p>";
					num4 += 1;
				}
			}
			text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;\">";
			text += "四、承载力计算";
			text += "</p>";
			if (this.bool_0)
			{
				if (this.double_3 != 0.0)
				{
					text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
					text = text + "塞土效应系数:" + Strings.Format(this.double_8, "0.00");
					text += "</p>";
				}
				text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
				text = text + "单桩竖向抗压承载力标准值(Qu):" + this.TextBox_0.Text + "KN";
				text += "</p>";
				text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
				text = text + "单桩竖向抗压承载力特征值(Ra):" + this.TextBox_1.Text + "KN";
				text += "</p>";
			}
			else
			{
				text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
				text = text + "桩身自重(KN):" + Strings.Format(this.double_7, "0.00") + "KN";
				text += "</p>";
				text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
				text = text + "单桩竖向抗拔承载力标准值(Qu):" + this.TextBox_0.Text + "KN";
				text += "</p>";
				text += "<p style=\"font-size:15px;text-align:left;font-weight:normal;text-indent:2em;\">";
				text = text + "单桩竖向抗拔承载力特征值(Ra):" + this.TextBox_1.Text + "KN";
				text += "</p>";
			}
			text += "</pre>";
			text += "</div>";
			text += "</body>";
			text += "</html>";
			string text9 = "c:\\\\temp.htm";
			NF.SaveTxtFile(text9, text);
			Process.Start(text9);
		}

		private void Button13_Click(object sender, EventArgs e)
		{
			this.Width = 508;
			this.method_6();
			DialogResult dialogResult = this.PrintDialog1.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				PrintDocument printDocument = new PrintDocument();
				printDocument.PrinterSettings = this.PrintDialog1.PrinterSettings;
				printDocument.DocumentName = "单桩竖向承载力计算";
				printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 630, 891);
				printDocument.PrintPage += this.method_7;
				printDocument.Print();
			}
		}

		private void method_6()
		{
			Graphics graphics = this.CreateGraphics();
			Size size = this.Size;
			this.bitmap_0 = new Bitmap(size.Width, size.Height, graphics);
			Graphics graphics2 = Graphics.FromImage(this.bitmap_0);
			IntPtr hdc = graphics.GetHdc();
			IntPtr hdc2 = graphics2.GetHdc();
			TcQuRa_frm.BitBlt(hdc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, hdc, 0, 0, 13369376);
			graphics.ReleaseHdc(hdc);
			graphics2.ReleaseHdc(hdc2);
		}

		private void method_7(object sender, PrintPageEventArgs e)
		{
			e.PageSettings.PaperSize = new PaperSize("A4", 630, 891);
			long num = (long)this.bitmap_0.Width;
			long num2 = (long)this.bitmap_0.Height;
			long num3 = (long)e.PageBounds.Width;
			long num4 = (long)e.PageBounds.Height;
			checked
			{
				long num5 = (long)Math.Round((double)(num3 - num) / 2.0);
				e.Graphics.DrawImage(this.bitmap_0, (float)num5, 20f);
				Font font = new Font("宋体", 8f, FontStyle.Regular);
				long num6 = 20L + num2 + 5L;
				PointF point = new PointF((float)num5, (float)num6);
				e.Graphics.DrawString("本程序由田草博客出品的单桩竖向承载力计算工具自动生成。", font, Brushes.Blue, point);
				font = new Font("宋体", 8f, FontStyle.Underline);
				num6 += 20L;
				point = new PointF((float)num5, (float)num6);
				e.Graphics.DrawString("http://tiancao.net/blogview.asp?logID=1998", font, Brushes.Blue, point);
			}
		}

		private void Button11_Click(object sender, EventArgs e)
		{
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("NumericUpDown1")]
		private NumericUpDown _NumericUpDown1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("NumericUpDown2")]
		private NumericUpDown _NumericUpDown2;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		[AccessedThroughProperty("Button8")]
		private Button _Button8;

		[AccessedThroughProperty("DataGridView1")]
		private DataGridView _DataGridView1;

		[AccessedThroughProperty("Column1")]
		private DataGridViewTextBoxColumn _Column1;

		[AccessedThroughProperty("Column2")]
		private DataGridViewTextBoxColumn _Column2;

		[AccessedThroughProperty("Column7")]
		private DataGridViewTextBoxColumn _Column7;

		[AccessedThroughProperty("Column3")]
		private DataGridViewTextBoxColumn _Column3;

		[AccessedThroughProperty("Column4")]
		private DataGridViewTextBoxColumn _Column4;

		[AccessedThroughProperty("Column5")]
		private DataGridViewTextBoxColumn _Column5;

		[AccessedThroughProperty("Column6")]
		private DataGridViewTextBoxColumn _Column6;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		[AccessedThroughProperty("GroupBox3")]
		private GroupBox _GroupBox3;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("TextBox7")]
		private TextBox _TextBox7;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("TextBox8")]
		private TextBox _TextBox8;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("TextBox9")]
		private TextBox _TextBox9;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("RadioButton3")]
		private RadioButton _RadioButton3;

		[AccessedThroughProperty("RadioButton4")]
		private RadioButton _RadioButton4;

		[AccessedThroughProperty("TextBox10")]
		private TextBox textBox_0;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("TextBox11")]
		private TextBox textBox_1;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button9")]
		private Button _Button9;

		[AccessedThroughProperty("Button10")]
		private Button _Button10;

		[AccessedThroughProperty("Label16")]
		private Label _Label16;

		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		[AccessedThroughProperty("Label17")]
		private Label _Label17;

		[AccessedThroughProperty("Label18")]
		private Label _Label18;

		[AccessedThroughProperty("TextBox12")]
		private TextBox textBox_2;

		[AccessedThroughProperty("Label19")]
		private Label _Label19;

		[AccessedThroughProperty("Label20")]
		private Label _Label20;

		[AccessedThroughProperty("Button11")]
		private Button _Button11;

		[AccessedThroughProperty("Label21")]
		private Label _Label21;

		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		[AccessedThroughProperty("Button12")]
		private Button _Button12;

		[AccessedThroughProperty("Button13")]
		private Button _Button13;

		[AccessedThroughProperty("PrintDialog1")]
		private PrintDialog printDialog_0;

		[AccessedThroughProperty("Label22")]
		private Label _Label22;

		private Bitmap bitmap_0;

		private ObjectId objectId_0;

		private long long_0;

		private long long_1;

		private double double_0;

		private Point3d point3d_0;

		private Polyline[] polyline_0;

		private short short_0;

		private Point3dCollection point3dCollection_0;

		private double[] NnGraoarmy;

		private double double_1;

		private double double_2;

		private double double_3;

		private double double_4;

		private long long_2;

		private long long_3;

		private bool bool_0;

		private long long_4;

		private long long_5;

		private double double_5;

		private double gntrwnIqfF;

		private double double_6;

		private string string_0;

		private double double_7;

		private double double_8;

		[Serializable]
		public struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}
	}
}
