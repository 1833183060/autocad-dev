using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcTM_frm : Form
	{
		[DebuggerNonUserCode]
		static TcTM_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcTM_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcTM_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcTM_frm.list_0.Count == TcTM_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcTM_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcTM_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcTM_frm.list_0[num] = TcTM_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcTM_frm.list_0.RemoveRange(num, TcTM_frm.list_0.Count - num);
						TcTM_frm.list_0.Capacity = TcTM_frm.list_0.Count;
					}
					TcTM_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				this._ComboBox1 = value;
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
				EventHandler value2 = new EventHandler(this.method_1);
				EventHandler value3 = new EventHandler(this.method_0);
				if (this._ComboBox2 != null)
				{
					this._ComboBox2.TextChanged -= value2;
					this._ComboBox2.SelectedIndexChanged -= value3;
				}
				this._ComboBox2 = value;
				if (this._ComboBox2 != null)
				{
					this._ComboBox2.TextChanged += value2;
					this._ComboBox2.SelectedIndexChanged += value3;
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

		private void OK_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcTM_frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_TM_Frm", "ComboBox2", this.ComboBox2.Text);
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_TM_Frm", "ComboBox1", this.ComboBox1.Text);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcTM_frm_Load(object sender, EventArgs e)
		{
			this.ComboBox1.Items.Add("1:200");
			this.ComboBox1.Items.Add("1:150");
			this.ComboBox1.Items.Add("1:125");
			this.ComboBox1.Items.Add("1:100");
			this.ComboBox1.Items.Add("1:75");
			this.ComboBox1.Items.Add("1:50");
			this.ComboBox1.Items.Add("1:25");
			this.ComboBox1.Items.Add("1:20");
			this.ComboBox1.Items.Add("1:10");
			this.ComboBox1.Items.Add("1:1");
			this.ComboBox2.Items.Add("基础平面布置图");
			this.ComboBox2.Items.Add("3.700标高结构平面图");
			this.ComboBox2.Items.Add("3.700标高现浇板配筋图");
			this.ComboBox2.Items.Add("3.700标高梁配筋图");
			this.ComboBox2.Items.Add("一层框架柱平面布置图");
			this.ComboBox2.Items.Add("楼梯结构详图");
			string setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_TM_Frm", "ComboBox2", "");
			if (Operators.CompareString(setting, "", false) != 0)
			{
				this.ComboBox2.Text = setting;
			}
			string setting2 = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_TM_Frm", "ComboBox1", "");
			if (Operators.CompareString(setting2, "", false) != 0)
			{
				this.ComboBox1.Text = setting2;
			}
			string text = Clipboard.GetText();
			if (Operators.CompareString(text, "", false) != 0)
			{
				this.ComboBox2.Text = text;
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			this.Label1.Text = this.ComboBox2.Text;
		}

		public TcTM_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.FormClosing += this.TcTM_frm_FormClosing;
			base.Load += this.TcTM_frm_Load;
			TcTM_frm.smethod_0(this);
			this.InitializeComponent();
		}

		protected override void Finalize()
		{
			base.Finalize();
		}

		private void method_1(object sender, EventArgs e)
		{
			this.Label1.Text = this.ComboBox2.Text;
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		[AccessedThroughProperty("Cancel_Button")]
		private Button _Cancel_Button;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("ComboBox2")]
		private ComboBox _ComboBox2;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;
	}
}
