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
	public partial class TcTuKu_frm : Form
	{
		[DebuggerNonUserCode]
		static TcTuKu_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcTuKu_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcTuKu_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			TcTuKu_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcTuKu_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcTuKu_frm.list_0.Count == TcTuKu_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcTuKu_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcTuKu_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcTuKu_frm.list_0[num] = TcTuKu_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcTuKu_frm.list_0.RemoveRange(num, TcTuKu_frm.list_0.Count - num);
						TcTuKu_frm.list_0.Capacity = TcTuKu_frm.list_0.Count;
					}
					TcTuKu_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual TableLayoutPanel TableLayoutPanel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TableLayoutPanel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel1 = value;
			}
		}

		internal virtual Button OK_Button
		{
			[DebuggerNonUserCode]
			get
			{
				return this._OK_Button;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.OK_Button_Click);
				if (this._OK_Button != null)
				{
					this._OK_Button.Click -= value2;
				}
				this._OK_Button = value;
				if (this._OK_Button != null)
				{
					this._OK_Button.Click += value2;
				}
			}
		}

		internal virtual Button Cancel_Button
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Cancel_Button;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Cancel_Button_Click);
				if (this._Cancel_Button != null)
				{
					this._Cancel_Button.Click -= value2;
				}
				this._Cancel_Button = value;
				if (this._Cancel_Button != null)
				{
					this._Cancel_Button.Click += value2;
				}
			}
		}

		private void OK_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		[AccessedThroughProperty("Cancel_Button")]
		private Button _Cancel_Button;
	}
}
