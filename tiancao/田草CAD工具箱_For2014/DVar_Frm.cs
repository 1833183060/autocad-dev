using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class DVar_Frm : Form
	{
		[DebuggerNonUserCode]
		static DVar_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			DVar_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public DVar_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			DVar_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = DVar_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (DVar_Frm.list_0.Count == DVar_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = DVar_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = DVar_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									DVar_Frm.list_0[num] = DVar_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						DVar_Frm.list_0.RemoveRange(num, DVar_Frm.list_0.Count - num);
						DVar_Frm.list_0.Capacity = DVar_Frm.list_0.Count;
					}
					DVar_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual TabControl TabControl1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabControl1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabControl1 = value;
			}
		}

		internal virtual TabPage TabPage1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage1 = value;
			}
		}

		internal virtual TabPage TabPage2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage2 = value;
			}
		}

		internal virtual TabPage TabPage3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage3 = value;
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
				MouseEventHandler value2 = new MouseEventHandler(this.TextBox2_MouseDoubleClick);
				if (this._TextBox2 != null)
				{
					this._TextBox2.MouseDoubleClick -= value2;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.MouseDoubleClick += value2;
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
				MouseEventHandler value2 = new MouseEventHandler(this.TextBox6_MouseDoubleClick);
				if (this._TextBox6 != null)
				{
					this._TextBox6.MouseDoubleClick -= value2;
				}
				this._TextBox6 = value;
				if (this._TextBox6 != null)
				{
					this._TextBox6.MouseDoubleClick += value2;
				}
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
				MouseEventHandler value2 = new MouseEventHandler(this.TextBox_1_MouseDoubleClick);
				if (this.textBox_1 != null)
				{
					this.textBox_1.MouseDoubleClick -= value2;
				}
				this.textBox_1 = value;
				if (this.textBox_1 != null)
				{
					this.textBox_1.MouseDoubleClick += value2;
				}
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
				this.textBox_2 = value;
			}
		}

		internal virtual TextBox TextBox_3
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_3 = value;
			}
		}

		internal virtual TextBox TextBox_4
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_4 = value;
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

		internal virtual TextBox TextBox_5
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.TextBox_5_MouseDoubleClick);
				if (this.textBox_5 != null)
				{
					this.textBox_5.MouseDoubleClick -= value2;
				}
				this.textBox_5 = value;
				if (this.textBox_5 != null)
				{
					this.textBox_5.MouseDoubleClick += value2;
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

		internal virtual TextBox TextBox_6
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_6 = value;
			}
		}

		internal virtual TextBox TextBox_7
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_7 = value;
			}
		}

		internal virtual TextBox TextBox_8
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_8 = value;
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

		internal virtual TextBox TextBox_9
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.textBox_9 = value;
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

		internal virtual TextBox TextBox_10
		{
			[DebuggerNonUserCode]
			get
			{
				return this.textBox_10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.TextBox_10_MouseDoubleClick);
				if (this.textBox_10 != null)
				{
					this.textBox_10.MouseDoubleClick -= value2;
				}
				this.textBox_10 = value;
				if (this.textBox_10 != null)
				{
					this.textBox_10.MouseDoubleClick += value2;
				}
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

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			this.point3d_0 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_0 == point3d))
			{
				this.Label1.Text = Conversions.ToString(this.point3d_0.X) + " / " + Conversions.ToString(this.point3d_0.Y);
				this.Show();
			}
		}

		private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Hide();
			double value = Class36.smethod_30("指定长度: ", 240.0);
			this.TextBox1.Text = Conversions.ToString(value);
			this.Show();
		}

		private void TextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Hide();
			double value = Class36.smethod_30("指定长度: ", 240.0);
			this.TextBox2.Text = Conversions.ToString(value);
			this.Show();
		}

		private void TextBox6_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Hide();
			double value = Class36.smethod_30("指定长度: ", 240.0);
			this.TextBox6.Text = Conversions.ToString(value);
			this.Show();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			checked
			{
				long num = (long)Math.Round(Conversion.Val(this.TextBox3.Text));
				long num2 = (long)Math.Round(Conversion.Val(this.TextBox4.Text));
				long num3 = (long)Math.Round(Conversion.Val(this.TextBox5.Text));
				string text = this.TextBox7.Text;
				string text2 = this.TextBox8.Text;
				double double_ = Conversion.Val(this.TextBox6.Text);
				double num4 = Conversion.Val(this.TextBox1.Text);
				double num5 = Conversion.Val(this.TextBox2.Text);
				long num6 = num;
				long num7 = num2;
				long num8 = num3;
				long num9 = num7;
				long num10 = num6;
				for (;;)
				{
					long num11 = num8 >> 63 ^ num10;
					long num12 = num8 >> 63 ^ num9;
					if (num11 > num12)
					{
						break;
					}
					Class36.smethod_57(text + Conversions.ToString(num10) + text2, this.point3d_0, double_, 0, 0, "STANDARD", 0.0);
					unchecked
					{
						this.point3d_0..ctor(this.point3d_0.X + num4, this.point3d_0.Y + num5, 0.0);
					}
					num10 += num8;
				}
				documentLock.Dispose();
				this.Close();
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			this.Hide();
			this.point3d_0 = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(this.point3d_0 == point3d))
			{
				this.Label18.Text = Conversions.ToString(this.point3d_0.X) + " / " + Conversions.ToString(this.point3d_0.Y);
				this.Show();
			}
		}

		private void TextBox_5_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Hide();
			double value = Class36.smethod_30("指定长度: ", 240.0);
			this.TextBox_5.Text = Conversions.ToString(value);
			this.Show();
		}

		private void TextBox_1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Hide();
			double value = Class36.smethod_30("指定长度: ", 240.0);
			this.TextBox_1.Text = Conversions.ToString(value);
			this.Show();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.Hide();
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			double num = Conversion.Val(this.TextBox_4.Text);
			double num2 = Conversion.Val(this.TextBox_3.Text);
			double num3 = Conversion.Val(this.TextBox_2.Text);
			string text = this.TextBox_0.Text;
			string text2 = this.TextBox9.Text;
			double double_ = Conversion.Val(this.TextBox_1.Text);
			double r = Conversion.Val(this.TextBox_5.Text);
			checked
			{
				long num4 = (long)Math.Round(Math.Abs(unchecked(num2 - num)) / num3);
				Interaction.MsgBox(num4, MsgBoxStyle.OkOnly, null);
				this.point3d_0 = CAD.GetPointAngle(this.point3d_0, r, 0.0);
				long num5 = 0L;
				long num6 = num4;
				long num7 = num5;
				for (;;)
				{
					long num8 = num7;
					long num9 = num6;
					if (num8 > num9)
					{
						break;
					}
					Class36.smethod_57(text + Conversion.Str(unchecked(num + (double)num7 * num3)) + text2, this.point3d_0, double_, 0, 0, "STANDARD", 0.0);
					this.point3d_0 = CAD.GetPointAngle(this.point3d_0, r, (double)num4);
					num7 += 1L;
				}
				documentLock.Dispose();
				this.Close();
			}
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			this.Hide();
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			string text;
			string text2;
			double double_;
			short num4;
			short num5;
			checked
			{
				short num = (short)Math.Round(Conversion.Val(this.TextBox_9.Text));
				text = this.TextBox_8.Text;
				text2 = this.TextBox_6.Text;
				double_ = Conversion.Val(this.TextBox_10.Text);
				short num2 = (short)Math.Round(Conversion.Val(this.TextBox_7.Text));
				if (Operators.CompareString(text2, "/N", false) == 0)
				{
					text2 = "/" + string.Format("{0:00}", num);
				}
				short num3 = num2;
				num4 = num;
				num5 = num3;
			}
			for (;;)
			{
				short num6 = num5;
				short num7 = num4;
				if (num6 > num7)
				{
					break;
				}
				Point3d point = CAD.GetPoint("选择插入点: ");
				Point3d point3d;
				if (point == point3d)
				{
					goto IL_126;
				}
				Class36.smethod_57(text + string.Format("{0:00}", num5) + text2, point, double_, 0, 0, "STANDARD", 0.0);
				num5 += 1;
			}
			documentLock.Dispose();
			this.Close();
			return;
			IL_126:
			documentLock.Dispose();
		}

		private void TextBox_10_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Hide();
			double value = Class36.smethod_30("指定长度: ", 240.0);
			this.TextBox_10.Text = Conversions.ToString(value);
			this.Show();
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TabControl1")]
		private TabControl _TabControl1;

		[AccessedThroughProperty("TabPage1")]
		private TabPage _TabPage1;

		[AccessedThroughProperty("TabPage2")]
		private TabPage _TabPage2;

		[AccessedThroughProperty("TabPage3")]
		private TabPage _TabPage3;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("TextBox8")]
		private TextBox _TextBox8;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("TextBox7")]
		private TextBox _TextBox7;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("TextBox9")]
		private TextBox _TextBox9;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("TextBox10")]
		private TextBox textBox_0;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("TextBox11")]
		private TextBox textBox_1;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("TextBox12")]
		private TextBox textBox_2;

		[AccessedThroughProperty("TextBox13")]
		private TextBox textBox_3;

		[AccessedThroughProperty("TextBox14")]
		private TextBox textBox_4;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		[AccessedThroughProperty("Label17")]
		private Label _Label17;

		[AccessedThroughProperty("TextBox16")]
		private TextBox textBox_5;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Label18")]
		private Label _Label18;

		[AccessedThroughProperty("TextBox18")]
		private TextBox textBox_6;

		[AccessedThroughProperty("TextBox17")]
		private TextBox textBox_7;

		[AccessedThroughProperty("TextBox15")]
		private TextBox textBox_8;

		[AccessedThroughProperty("Label16")]
		private Label _Label16;

		[AccessedThroughProperty("Label20")]
		private Label _Label20;

		[AccessedThroughProperty("Label19")]
		private Label _Label19;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("TextBox19")]
		private TextBox textBox_9;

		[AccessedThroughProperty("Label21")]
		private Label _Label21;

		[AccessedThroughProperty("TextBox20")]
		private TextBox textBox_10;

		[AccessedThroughProperty("Label22")]
		private Label _Label22;

		private Point3d point3d_0;
	}
}
