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
	public partial class LJM_Frm : Form
	{
		[DebuggerNonUserCode]
		static LJM_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			LJM_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public LJM_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Shown += this.LJM_Frm_Shown;
			base.Activated += this.LJM_Frm_Activated;
			base.FormClosed += this.LJM_Frm_FormClosed;
			LJM_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = LJM_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (LJM_Frm.list_0.Count == LJM_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = LJM_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = LJM_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									LJM_Frm.list_0[num] = LJM_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						LJM_Frm.list_0.RemoveRange(num, LJM_Frm.list_0.Count - num);
						LJM_Frm.list_0.Capacity = LJM_Frm.list_0.Count;
					}
					LJM_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.TextBox2_KeyPress);
				if (this._TextBox2 != null)
				{
					this._TextBox2.KeyPress -= value2;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.KeyPress += value2;
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.TextBox3_KeyPress);
				if (this._TextBox3 != null)
				{
					this._TextBox3.KeyPress -= value2;
				}
				this._TextBox3 = value;
				if (this._TextBox3 != null)
				{
					this._TextBox3.KeyPress += value2;
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
				this._TextBox7 = value;
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.TextBox5_KeyPress);
				if (this._TextBox5 != null)
				{
					this._TextBox5.KeyPress -= value2;
				}
				this._TextBox5 = value;
				if (this._TextBox5 != null)
				{
					this._TextBox5.KeyPress += value2;
				}
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.TextBox4_KeyPress);
				if (this._TextBox4 != null)
				{
					this._TextBox4.KeyPress -= value2;
				}
				this._TextBox4 = value;
				if (this._TextBox4 != null)
				{
					this._TextBox4.KeyPress += value2;
				}
			}
		}

		internal virtual ImageList ImageList1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.imageList_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.imageList_0 = value;
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

		private void Button1_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.Button1.Text, "顶部标高", false) == 0)
			{
				this.Button1.Text = "底部标高";
			}
			else
			{
				this.Button1.Text = "顶部标高";
			}
		}

		private void LJM_Frm_Activated(object sender, EventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void LJM_Frm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_1", this.TextBox1.Text);
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_2", this.TextBox2.Text);
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_3", this.TextBox3.Text);
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_4", this.TextBox4.Text);
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_5", this.TextBox5.Text);
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_7", this.TextBox7.Text);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void LJM_Frm_Shown(object sender, EventArgs e)
		{
			this.TextBox1.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_1", "250 500");
			this.TextBox2.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_2", "4C25/2C20");
			this.TextBox3.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_3", "3C20/4C25");
			this.TextBox4.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_4", "C8@100/200");
			this.TextBox5.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_5", "4C12");
			this.TextBox7.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_LJM_Frm", "LJM_7", "0.00");
		}

		private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		[AccessedThroughProperty("Cancel_Button")]
		private Button _Cancel_Button;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TextBox7")]
		private TextBox _TextBox7;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("ImageList1")]
		private ImageList imageList_0;

		private short short_0;
	}
}
