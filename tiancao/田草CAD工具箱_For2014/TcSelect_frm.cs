using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcSelect_frm : Form
	{
		[DebuggerNonUserCode]
		static TcSelect_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcSelect_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcSelect_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			TcSelect_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcSelect_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcSelect_frm.list_0.Count == TcSelect_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcSelect_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcSelect_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcSelect_frm.list_0[num] = TcSelect_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcSelect_frm.list_0.RemoveRange(num, TcSelect_frm.list_0.Count - num);
						TcSelect_frm.list_0.Capacity = TcSelect_frm.list_0.Count;
					}
					TcSelect_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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

		internal virtual CheckBox CheckBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CheckBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox3 = value;
			}
		}

		internal virtual CheckBox CheckBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CheckBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox2 = value;
			}
		}

		internal virtual CheckBox CheckBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CheckBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox1 = value;
			}
		}

		internal virtual CheckBox CheckBox4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CheckBox4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox4 = value;
			}
		}

		internal virtual CheckBox CheckBox5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CheckBox5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox5 = value;
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("CheckBox3")]
		private CheckBox _CheckBox3;

		[AccessedThroughProperty("CheckBox2")]
		private CheckBox _CheckBox2;

		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		[AccessedThroughProperty("CheckBox4")]
		private CheckBox _CheckBox4;

		[AccessedThroughProperty("CheckBox5")]
		private CheckBox _CheckBox5;
	}
}
