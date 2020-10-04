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
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcPC_frm : Form
	{
		[DebuggerNonUserCode]
		static TcPC_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcPC_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcPC_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			TcPC_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcPC_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcPC_frm.list_0.Count == TcPC_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcPC_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcPC_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcPC_frm.list_0[num] = TcPC_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcPC_frm.list_0.RemoveRange(num, TcPC_frm.list_0.Count - num);
						TcPC_frm.list_0.Capacity = TcPC_frm.list_0.Count;
					}
					TcPC_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual Button Button_0
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_0_Click);
				if (this.button_0 != null)
				{
					this.button_0.Click -= value2;
				}
				this.button_0 = value;
				if (this.button_0 != null)
				{
					this.button_0.Click += value2;
				}
			}
		}

		internal virtual Button Button_1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_1_Click);
				if (this.button_1 != null)
				{
					this.button_1.Click -= value2;
				}
				this.button_1 = value;
				if (this.button_1 != null)
				{
					this.button_1.Click += value2;
				}
			}
		}

		internal virtual Button Button_2
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_2_Click);
				if (this.button_2 != null)
				{
					this.button_2.Click -= value2;
				}
				this.button_2 = value;
				if (this.button_2 != null)
				{
					this.button_2.Click += value2;
				}
			}
		}

		internal virtual Button Button_3
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_3_Click);
				if (this.button_3 != null)
				{
					this.button_3.Click -= value2;
				}
				this.button_3 = value;
				if (this.button_3 != null)
				{
					this.button_3.Click += value2;
				}
			}
		}

		internal virtual Button Button_4
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.jipAtgRsh);
				if (this.button_4 != null)
				{
					this.button_4.Click -= value2;
				}
				this.button_4 = value;
				if (this.button_4 != null)
				{
					this.button_4.Click += value2;
				}
			}
		}

		internal virtual Button Button_5
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.button_5 = value;
			}
		}

		internal virtual Button Button_6
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.button_6 = value;
			}
		}

		internal virtual Button Button_7
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_7_Click);
				if (this.button_7 != null)
				{
					this.button_7.Click -= value2;
				}
				this.button_7 = value;
				if (this.button_7 != null)
				{
					this.button_7.Click += value2;
				}
			}
		}

		internal virtual Button Button_8
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_8_Click);
				if (this.button_8 != null)
				{
					this.button_8.Click -= value2;
				}
				this.button_8 = value;
				if (this.button_8 != null)
				{
					this.button_8.Click += value2;
				}
			}
		}

		internal virtual Button Button_9
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_9_Click);
				if (this.button_9 != null)
				{
					this.button_9.Click -= value2;
				}
				this.button_9 = value;
				if (this.button_9 != null)
				{
					this.button_9.Click += value2;
				}
			}
		}

		internal virtual Button Button_10
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_10_Click);
				if (this.button_10 != null)
				{
					this.button_10.Click -= value2;
				}
				this.button_10 = value;
				if (this.button_10 != null)
				{
					this.button_10.Click += value2;
				}
			}
		}

		internal virtual Button Button_11
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_11_Click);
				if (this.button_11 != null)
				{
					this.button_11.Click -= value2;
				}
				this.button_11 = value;
				if (this.button_11 != null)
				{
					this.button_11.Click += value2;
				}
			}
		}

		internal virtual Button Button_12
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_12_Click);
				if (this.button_12 != null)
				{
					this.button_12.Click -= value2;
				}
				this.button_12 = value;
				if (this.button_12 != null)
				{
					this.button_12.Click += value2;
				}
			}
		}

		internal virtual Button Button99
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button99;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button99_Click);
				if (this._Button99 != null)
				{
					this._Button99.Click -= value2;
				}
				this._Button99 = value;
				if (this._Button99 != null)
				{
					this._Button99.Click += value2;
				}
			}
		}

		internal virtual Button Button98
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button98;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button98_Click);
				if (this._Button98 != null)
				{
					this._Button98.Click -= value2;
				}
				this._Button98 = value;
				if (this._Button98 != null)
				{
					this._Button98.Click += value2;
				}
			}
		}

		internal virtual Button Button30
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button30;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button30_Click);
				if (this._Button30 != null)
				{
					this._Button30.Click -= value2;
				}
				this._Button30 = value;
				if (this._Button30 != null)
				{
					this._Button30.Click += value2;
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
				EventHandler value2 = new EventHandler(this.Button9_Click);
				if (this._Button9 != null)
				{
					this._Button9.Click -= value2;
				}
				this._Button9 = value;
				if (this._Button9 != null)
				{
					this._Button9.Click += value2;
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

		private void Button30_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_PM");
		}

		private void Button98_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_LM");
		}

		private void Button99_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_DM");
		}

		private void Button_11_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_PM1");
		}

		private void Button_9_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_DM1");
		}

		private void Button_8_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_2D");
		}

		private void Button_7_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_3D");
		}

		private void Button_10_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_LM1");
		}

		private void jipAtgRsh(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_LM2");
		}

		private void Button_12_Click(object sender, EventArgs e)
		{
			this.Cmd("TcSSLB");
		}

		private void Button_3_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJHJ_LM3");
		}

		private void Button_2_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQBBZ");
		}

		private void Button_1_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQBTJ");
		}

		private void Button_0_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQBBZ1");
		}

		public void Cmd(string Cmd)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Document document = Application.DocumentManager.GetDocument(HostApplicationServices.WorkingDatabase);
			document.Editor.WriteMessage("\r\n命令:" + Cmd + "\r\n");
			document.SendStringToExecute(Cmd + " ", false, false, false);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Cmd("TcXZQT");
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDHBCF");
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDHBCF1");
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			this.Cmd("TcPLYH");
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDHBTJ");
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			this.Cmd("TcExcel2CAD");
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			this.Cmd("TcCAD2Excel");
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGetA");
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGetV");
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQBQH");
		}

		private void Button11_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDHB_CBH");
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Button134")]
		private Button button_0;

		[AccessedThroughProperty("Button133")]
		private Button button_1;

		[AccessedThroughProperty("Button132")]
		private Button button_2;

		[AccessedThroughProperty("Button109")]
		private Button button_3;

		[AccessedThroughProperty("Button108")]
		private Button button_4;

		[AccessedThroughProperty("Button107")]
		private Button button_5;

		[AccessedThroughProperty("Button106")]
		private Button button_6;

		[AccessedThroughProperty("Button105")]
		private Button button_7;

		[AccessedThroughProperty("Button104")]
		private Button button_8;

		[AccessedThroughProperty("Button100")]
		private Button button_9;

		[AccessedThroughProperty("Button101")]
		private Button button_10;

		[AccessedThroughProperty("Button102")]
		private Button button_11;

		[AccessedThroughProperty("Button103")]
		private Button button_12;

		[AccessedThroughProperty("Button99")]
		private Button _Button99;

		[AccessedThroughProperty("Button98")]
		private Button _Button98;

		[AccessedThroughProperty("Button30")]
		private Button _Button30;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		[AccessedThroughProperty("Button8")]
		private Button _Button8;

		[AccessedThroughProperty("Button9")]
		private Button _Button9;

		[AccessedThroughProperty("Button10")]
		private Button _Button10;

		[AccessedThroughProperty("Button11")]
		private Button _Button11;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;
	}
}
