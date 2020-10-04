using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ns0
{
	internal partial class rFohpatkdxsVcxLfJKhM7 : Form
	{
		public rFohpatkdxsVcxLfJKhM7()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		public Color Gradient_Begin
		{
			get
			{
				return this.panel1.method_0();
			}
			set
			{
				this.panel1.method_1(value);
			}
		}

		public Color Gradient_End
		{
			get
			{
				return this.panel1.method_11();
			}
			set
			{
				this.panel1.method_12(value);
			}
		}

		public string MessageBoxCaption
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
				this.label1.Text = value;
			}
		}

		public Color MessageBoxGradientBegin
		{
			get
			{
				return this.panel1.method_0();
			}
			set
			{
				this.panel1.method_1(value);
			}
		}

		public Color MessageBoxGradientEnd
		{
			get
			{
				return this.panel1.method_11();
			}
			set
			{
				this.panel1.method_12(value);
			}
		}

		public string MessageBoxText
		{
			get
			{
				return this.label2.Text;
			}
			set
			{
				this.label2.Text = value;
			}
		}

		public string Snag_Caption
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
				this.label1.Text = value;
			}
		}

		public string Snag_Text
		{
			get
			{
				return this.label2.Text;
			}
			set
			{
				this.label2.Text = value;
			}
		}

		internal class Class51 : Panel
		{
			public Class51()
			{
				base.SetStyle(ControlStyles.ResizeRedraw, true);
				base.SetStyle(ControlStyles.DoubleBuffer, true);
				base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				base.SetStyle(ControlStyles.UserPaint, true);
				base.SetStyle(ControlStyles.ContainerControl, true);
				this.color_0 = SystemColors.ActiveCaption;
				this.color_1 = SystemColors.Control;
				this.bool_0 = true;
				this.bool_1 = true;
				this.bool_2 = false;
				this.bool_4 = false;
				this.bool_3 = true;
			}

			public Color method_0()
			{
				return this.color_0;
			}

			public void method_1(Color color_2)
			{
				this.color_0 = color_2;
				base.Invalidate();
			}

			public void method_10(bool bool_5)
			{
				this.bool_1 = bool_5;
				base.Invalidate();
			}

			public Color method_11()
			{
				return this.color_1;
			}

			public void method_12(Color color_2)
			{
				this.color_1 = color_2;
				base.Invalidate();
			}

			public bool method_2()
			{
				return this.bool_4;
			}

			public void method_3(bool bool_5)
			{
				this.bool_4 = bool_5;
				base.Invalidate();
			}

			public bool method_4()
			{
				return this.bool_0;
			}

			public void method_5(bool bool_5)
			{
				this.bool_0 = bool_5;
				base.Invalidate();
			}

			public bool method_6()
			{
				return this.bool_2;
			}

			public bool method_7()
			{
				return this.bool_3;
			}

			public void method_8(bool bool_5)
			{
				this.bool_3 = bool_5;
				base.Invalidate();
			}

			public bool method_9()
			{
				return this.bool_1;
			}

			public void NdudXono0(bool bool_5)
			{
				this.bool_2 = bool_5;
				base.Invalidate();
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				Color color = this.color_0;
				Color color2 = this.color_1;
				LinearGradientMode linearGradientMode;
				if (this.bool_0)
				{
					linearGradientMode = LinearGradientMode.Horizontal;
				}
				else
				{
					linearGradientMode = LinearGradientMode.Vertical;
				}
				if (!this.bool_1)
				{
					color = this.color_1;
					color2 = this.color_0;
				}
				if (this.bool_2)
				{
					if (this.bool_3)
					{
						linearGradientMode = LinearGradientMode.ForwardDiagonal;
					}
					else
					{
						linearGradientMode = LinearGradientMode.BackwardDiagonal;
					}
				}
				if (base.Width > 0 && base.Height > 0)
				{
					Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
					LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color, color2, linearGradientMode);
					if (!this.bool_4)
					{
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
					else
					{
						linearGradientBrush.SetSigmaBellShape(0.7f);
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
					new SolidBrush(this.ForeColor);
				}
			}

			private bool bool_0;

			private bool bool_1;

			private bool bool_2;

			private bool bool_3;

			private bool bool_4;

			private Color color_0;

			private Color color_1;
		}
	}
}
