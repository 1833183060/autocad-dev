using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace TcDotNetBarcode
{
	[DesignerGenerated]
	public partial class Form1 : Form
	{
		public Form1()
		{
			base.Load += this.Form1_Load;
			this.dotNetBarcode_0 = new DotNetBarcode();
			this.InitializeComponent();
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

		internal virtual Panel Panel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel1 = value;
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
				if (this._Button1 != null)
				{
					this._Button1.Click -= this._Button1_Click;
				}
				this._Button1 = value;
				if (this._Button1 != null)
				{
					this._Button1.Click += this._Button1_Click;
				}
			}
		}

		internal virtual PictureBox PictureBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._PictureBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._PictureBox2 = value;
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
				if (this._Button2 != null)
				{
					this._Button2.Click -= this._Button2_Click;
				}
				this._Button2 = value;
				if (this._Button2 != null)
				{
					this._Button2.Click += this._Button2_Click;
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.dotNetBarcode_0.Type = DotNetBarcode.Types.QRCode;
			this.dotNetBarcode_0.PrintCheckDigitChar = true;
		}

		private void _Button1_Click(object sender, EventArgs e)
		{
			this.dotNetBarcode_0.WriteBar(this.TextBox1.Text, 0f, 0f, (float)this.Panel1.Size.Width, (float)this.Panel1.Size.Height, this.Panel1.CreateGraphics());
		}

		private void _Button2_Click(object sender, EventArgs e)
		{
			this.dotNetBarcode_0.WriteBar(this.TextBox1.Text, 0f, 0f, (float)this.Panel1.Size.Width, (float)this.Panel1.Size.Height, this.Panel1.CreateGraphics());
			string text = this.dotNetBarcode_0.QRCode_GetHeiBaiString(this.TextBox1.Text);
			Graphics graphics = this.PictureBox2.CreateGraphics();
			short num;
			short num2;
			short num3;
			checked
			{
				num = (short)Math.Round(Math.Sqrt((double)text.Length));
				num2 = 0;
				num3 = num - 1;
			}
			for (short num4 = num2; num4 <= num3; num4 += 1)
			{
				short num5 = 0;
				short num6 = checked(num - 1);
				for (short num7 = num5; num7 <= num6; num7 += 1)
				{
					string left = text.Substring((int)(num4 * num + num7), 1);
					checked
					{
						if (Operators.CompareString(left, "1", false) == 0)
						{
							graphics.FillRectangle(Brushes.Black, (int)(num4 * 2), (int)(num7 * 2), 2, 2);
						}
					}
				}
			}
		}

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("PictureBox2")]
		private PictureBox _PictureBox2;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		private DotNetBarcode dotNetBarcode_0;
	}
}
