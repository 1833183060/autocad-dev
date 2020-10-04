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
	public partial class Reg_frm : Form
	{
		[DebuggerNonUserCode]
		static Reg_frm()
		{
			Class39.k1QjQlczC5Jf5();
			Reg_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public Reg_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.Reg_frm_Load;
			Reg_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = Reg_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (Reg_frm.list_0.Count == Reg_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = Reg_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = Reg_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									Reg_frm.list_0[num] = Reg_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						Reg_frm.list_0.RemoveRange(num, Reg_frm.list_0.Count - num);
						Reg_frm.list_0.Capacity = Reg_frm.list_0.Count;
					}
					Reg_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
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
				MouseEventHandler value2 = new MouseEventHandler(this.TextBox1_MouseDoubleClick);
				if (this._TextBox1 != null)
				{
					this._TextBox1.MouseDoubleClick -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.MouseDoubleClick += value2;
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

		internal virtual Label Label25
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label25;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Label25_Click);
				if (this._Label25 != null)
				{
					this._Label25.Click -= value2;
				}
				this._Label25 = value;
				if (this._Label25 != null)
				{
					this._Label25.Click += value2;
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

		private void OK_Button_Click(object sender, EventArgs e)
		{
			Process.Start("Http://www.tiancao.net/softreg.htm");
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Clipboard.SetText(this.TextBox1.Text);
			Interaction.MsgBox("电脑身份证已经复制到剪切板！", MsgBoxStyle.OkOnly, null);
		}

		private void Label25_Click(object sender, EventArgs e)
		{
			Process.Start("Http://www.tiancao.net");
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			Process.Start("Http://www.tiancao.net/softabout.htm");
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Reg_frm_Load(object sender, EventArgs e)
		{
			string text = "";
			string productName = Class33.Class31_0.Info.ProductName;
			text = text + "你的电脑还没有对" + productName + "进行注册！\r\n";
			text += "复制电脑身份证编码,点击申请注册，按照提示进行付费并注册。\r\n";
			text += "注册后你将会在第一时间收到软件升级或更新等信息。\r\n";
			text += "注册后能得到更多更好的服务。\r\n";
			this.Label2.Text = text;
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		[AccessedThroughProperty("Cancel_Button")]
		private Button _Cancel_Button;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label25")]
		private Label _Label25;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;
	}
}
