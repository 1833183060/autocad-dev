using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcSet_frm : Form
	{
		[DebuggerNonUserCode]
		static TcSet_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcSet_frm.list_0 = new List<WeakReference>();
		}

		public TcSet_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcSet_frm_Load;
			TcSet_frm.smethod_0(this);
			this.document_0 = Application.DocumentManager.MdiActiveDocument;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcSet_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcSet_frm.list_0.Count == TcSet_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcSet_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcSet_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcSet_frm.list_0[num] = TcSet_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcSet_frm.list_0.RemoveRange(num, TcSet_frm.list_0.Count - num);
						TcSet_frm.list_0.Capacity = TcSet_frm.list_0.Count;
					}
					TcSet_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				EventHandler value2 = new EventHandler(this.CheckBox1_Click);
				if (this._CheckBox1 != null)
				{
					this._CheckBox1.Click -= value2;
				}
				this._CheckBox1 = value;
				if (this._CheckBox1 != null)
				{
					this._CheckBox1.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.CheckBox2_Click);
				if (this._CheckBox2 != null)
				{
					this._CheckBox2.Click -= value2;
				}
				this._CheckBox2 = value;
				if (this._CheckBox2 != null)
				{
					this._CheckBox2.Click += value2;
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
				EventHandler value2 = new EventHandler(this.CheckBox3_Click);
				if (this._CheckBox3 != null)
				{
					this._CheckBox3.Click -= value2;
				}
				this._CheckBox3 = value;
				if (this._CheckBox3 != null)
				{
					this._CheckBox3.Click += value2;
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
				EventHandler value2 = new EventHandler(this.jipAtgRsh);
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
				EventHandler value2 = new EventHandler(this.CheckBox4_Click);
				if (this._CheckBox4 != null)
				{
					this._CheckBox4.Click -= value2;
				}
				this._CheckBox4 = value;
				if (this._CheckBox4 != null)
				{
					this._CheckBox4.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.CheckBox5_Click);
				if (this._CheckBox5 != null)
				{
					this._CheckBox5.Click -= value2;
				}
				this._CheckBox5 = value;
				if (this._CheckBox5 != null)
				{
					this._CheckBox5.Click += value2;
				}
			}
		}

		private void OK_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void method_0(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcSet_frm_Load(object sender, EventArgs e)
		{
			if (Operators.CompareString(Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_CreateMenu", "_CreateMenu", ""), "ON", false) == 0)
			{
				this.CheckBox1.Checked = true;
			}
			else
			{
				this.CheckBox1.Checked = false;
			}
			if (Operators.CompareString(Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", ""), "ON", false) == 0)
			{
				this.CheckBox2.Checked = true;
			}
			else
			{
				this.CheckBox2.Checked = false;
			}
			string left = Interaction.GetSetting("配筋精灵", "配筋精灵", "DoubleClick", "");
			if (Operators.CompareString(left, "", false) == 0 | Operators.CompareString(left, "True", false) == 0)
			{
				this.CheckBox3.Checked = true;
			}
			else
			{
				this.CheckBox3.Checked = false;
			}
			left = Conversions.ToString(Application.GetSystemVariable("FONTALT"));
			if (Operators.CompareString(left, "txt.shx", false) == 0)
			{
				this.CheckBox4.Checked = true;
			}
			else
			{
				this.CheckBox4.Checked = false;
			}
			left = Conversions.ToString(Application.GetSystemVariable("PROXYNOTICE"));
			if (Operators.CompareString(left, "0", false) == 0)
			{
				this.CheckBox5.Checked = true;
			}
			else
			{
				this.CheckBox5.Checked = false;
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			CAD.Cmd("TcCopyFonts");
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			CAD.Cmd("TcAddPGP");
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			CAD.Cmd("ChangeToolPalettePath");
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			CAD.Cmd("ChangeDesignCenterPath");
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			CAD.Cmd("TcCopyPat");
		}

		private void jipAtgRsh(object sender, EventArgs e)
		{
			CAD.Cmd("TcShowAs");
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void CheckBox2_Click(object sender, EventArgs e)
		{
			if (this.CheckBox2.Checked)
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", "ON");
				Interaction.MsgBox("自动保存历史记录关闭,重启CAD后生效.", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", "OFF");
				Interaction.MsgBox("自动保存历史记录打开,重启CAD后生效.", MsgBoxStyle.OkOnly, null);
			}
		}

		private void CheckBox3_Click(object sender, EventArgs e)
		{
			if (this.CheckBox3.Checked)
			{
				Interaction.SaveSetting("配筋精灵", "配筋精灵", "DoubleClick", "True");
				Interaction.MsgBox("配筋精灵打开,重启CAD后生效.", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				Interaction.SaveSetting("配筋精灵", "配筋精灵", "DoubleClick", "False");
				Interaction.MsgBox("配筋精灵关闭,重启CAD后生效.", MsgBoxStyle.OkOnly, null);
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void CheckBox1_Click(object sender, EventArgs e)
		{
			if (this.CheckBox1.Checked)
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_CreateMenu", "_CreateMenu", "ON");
			}
			else
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_CreateMenu", "_CreateMenu", "OFF");
			}
			Interaction.MsgBox("是否显示菜单,重启CAD后生效.", MsgBoxStyle.OkOnly, null);
		}

		private void CheckBox4_Click(object sender, EventArgs e)
		{
			if (this.CheckBox1.Checked)
			{
				Application.SetSystemVariable("FONTALT", "simplex.shx");
			}
			else
			{
				Application.SetSystemVariable("FONTALT", "txt.shx");
			}
			Interaction.MsgBox("自动去除教育版打印戳记,重启CAD后生效.", MsgBoxStyle.OkOnly, null);
		}

		private void CheckBox5_Click(object sender, EventArgs e)
		{
			if (this.CheckBox5.Checked)
			{
				Application.SetSystemVariable("PROXYNOTICE", 0);
			}
			else
			{
				Application.SetSystemVariable("PROXYNOTICE", 1);
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		[AccessedThroughProperty("CheckBox2")]
		private CheckBox _CheckBox2;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("CheckBox3")]
		private CheckBox _CheckBox3;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("CheckBox4")]
		private CheckBox _CheckBox4;

		[AccessedThroughProperty("CheckBox5")]
		private CheckBox _CheckBox5;

		private Document document_0;
	}
}
