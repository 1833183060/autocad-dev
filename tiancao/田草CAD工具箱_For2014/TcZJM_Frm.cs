using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcZJM_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcZJM_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcZJM_Frm.list_0 = new List<WeakReference>();
		}

		public TcZJM_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.FormClosing += this.TcZJM_Frm_FormClosing;
			base.Load += this.TcZJM_Frm_Load;
			base.Paint += this.TcZJM_Frm_Paint;
			base.Shown += this.TcZJM_Frm_Shown;
			TcZJM_Frm.smethod_0(this);
			this.bool_0 = false;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcZJM_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcZJM_Frm.list_0.Count == TcZJM_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcZJM_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcZJM_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcZJM_Frm.list_0[num] = TcZJM_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcZJM_Frm.list_0.RemoveRange(num, TcZJM_Frm.list_0.Count - num);
						TcZJM_Frm.list_0.Capacity = TcZJM_Frm.list_0.Count;
					}
					TcZJM_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.TextBox1_KeyPress);
				if (this._TextBox1 != null)
				{
					this._TextBox1.KeyPress -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.KeyPress += value2;
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
				EventHandler value2 = new EventHandler(this.method_7);
				KeyPressEventHandler value3 = new KeyPressEventHandler(this.method_1);
				if (this._TextBox2 != null)
				{
					this._TextBox2.TextChanged -= value2;
					this._TextBox2.KeyPress -= value3;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.TextChanged += value2;
					this._TextBox2.KeyPress += value3;
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_2);
				EventHandler value3 = new EventHandler(this.method_8);
				if (this._TextBox3 != null)
				{
					this._TextBox3.KeyPress -= value2;
					this._TextBox3.TextChanged -= value3;
				}
				this._TextBox3 = value;
				if (this._TextBox3 != null)
				{
					this._TextBox3.KeyPress += value2;
					this._TextBox3.TextChanged += value3;
				}
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_3);
				EventHandler value3 = new EventHandler(this.method_9);
				if (this._TextBox4 != null)
				{
					this._TextBox4.KeyPress -= value2;
					this._TextBox4.TextChanged -= value3;
				}
				this._TextBox4 = value;
				if (this._TextBox4 != null)
				{
					this._TextBox4.KeyPress += value2;
					this._TextBox4.TextChanged += value3;
				}
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_4);
				EventHandler value3 = new EventHandler(this.method_10);
				if (this._TextBox5 != null)
				{
					this._TextBox5.KeyPress -= value2;
					this._TextBox5.TextChanged -= value3;
				}
				this._TextBox5 = value;
				if (this._TextBox5 != null)
				{
					this._TextBox5.KeyPress += value2;
					this._TextBox5.TextChanged += value3;
				}
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
				KeyPressEventHandler value2 = new KeyPressEventHandler(this.method_5);
				EventHandler value3 = new EventHandler(this.method_11);
				if (this._TextBox6 != null)
				{
					this._TextBox6.KeyPress -= value2;
					this._TextBox6.TextChanged -= value3;
				}
				this._TextBox6 = value;
				if (this._TextBox6 != null)
				{
					this._TextBox6.KeyPress += value2;
					this._TextBox6.TextChanged += value3;
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

		internal virtual RadioButton RadioButton1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton1 = value;
			}
		}

		internal virtual RadioButton RadioButton2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.RadioButton2_CheckedChanged);
				if (this._RadioButton2 != null)
				{
					this._RadioButton2.CheckedChanged -= value2;
				}
				this._RadioButton2 = value;
				if (this._RadioButton2 != null)
				{
					this._RadioButton2.CheckedChanged += value2;
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

		internal virtual PictureBox PictureBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._PictureBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._PictureBox1 = value;
			}
		}

		internal virtual ListBox ListBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ListBox1 = value;
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

		internal virtual Label Label12
		{
			[DebuggerNonUserCode]
			get
			{
				return this.ESHYUYFNO;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ESHYUYFNO = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcZJM_Frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			string productName = Class33.Class31_0.Info.ProductName;
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_0", this.RadioButton1.Checked.ToString());
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_1", this.TextBox1.Text);
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_2", this.TextBox2.Text);
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_3", this.TextBox3.Text);
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_4", this.TextBox4.Text);
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_5", this.TextBox5.Text);
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_6", this.TextBox6.Text);
			Interaction.SaveSetting(productName, "_ZJM_Frm", "ZJM_7", this.ComboBox1.Text);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcZJM_Frm_Load(object sender, EventArgs e)
		{
			this.bool_0 = false;
			this.ComboBox1.Items.Add("1:50");
			this.ComboBox1.Items.Add("1:40");
			this.ComboBox1.Items.Add("1:30");
			this.ComboBox1.Items.Add("1:25");
			this.ComboBox1.Items.Add("1:20");
			string productName = Class33.Class31_0.Info.ProductName;
			string setting = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_0", "");
			if (Operators.CompareString(setting.ToUpper(), "FALSE", false) != 0)
			{
				this.RadioButton1.Checked = true;
				this.RadioButton2.Checked = false;
			}
			else
			{
				this.RadioButton1.Checked = false;
				this.RadioButton2.Checked = true;
			}
			this.TextBox1.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_1", "KZ1");
			this.TextBox2.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_2", "400X400");
			this.TextBox3.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_3", "4D25");
			this.TextBox4.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_4", "D10@100/200");
			this.TextBox5.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_5", "2D20");
			this.TextBox6.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_6", "2D20");
			this.ComboBox1.Text = Interaction.GetSetting(productName, "_ZJM_Frm", "ZJM_7", "1:25");
		}

		private void method_0(Panel panel_0, string string_5)
		{
			Graphics graphics = panel_0.CreateGraphics();
			graphics.Clear(Color.DimGray);
			Font font = new Font("宋体", 9f);
			PointF point = new PointF((float)((double)panel_0.Height / 2.0), (float)((double)panel_0.Width / 2.0));
			SizeF sizeF = graphics.MeasureString(string_5, font);
			Matrix matrix = new Matrix();
			matrix.RotateAt(270f, point, MatrixOrder.Append);
			graphics.Transform = matrix;
			graphics.DrawString(string_5, font, new SolidBrush(Color.White), point.X - sizeF.Width, point.Y - sizeF.Height);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void RadioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.RadioButton2.Checked)
			{
				this.TextBox5.Enabled = false;
				this.TextBox6.Enabled = false;
			}
			else
			{
				this.TextBox5.Enabled = true;
				this.TextBox6.Enabled = true;
			}
		}

		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void method_1(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void method_2(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void method_3(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void method_4(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		private void method_5(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
		}

		public object PFZ(string JM, string JJ, string GJ, string XJ, string YJ)
		{
			string[] array = null;
			string[] array2 = null;
			int num = 0;
			string[] string_;
			checked
			{
				if (Operators.CompareString(JM, "", false) != 0)
				{
					array2 = (string[])Utils.CopyArray((Array)array2, new string[num + 1]);
					array2[num] = JM;
					num++;
				}
				if (Operators.CompareString(JJ, "", false) != 0)
				{
					array2 = (string[])Utils.CopyArray((Array)array2, new string[num + 1]);
					array2[num] = JJ;
					num++;
				}
				if (Operators.CompareString(GJ, "", false) != 0)
				{
					array2 = (string[])Utils.CopyArray((Array)array2, new string[num + 1]);
					array2[num] = GJ;
					num++;
				}
				if (Operators.CompareString(XJ, "", false) != 0)
				{
					array2 = (string[])Utils.CopyArray((Array)array2, new string[num + 1]);
					array2[num] = XJ;
					num++;
				}
				if (Operators.CompareString(YJ, "", false) != 0)
				{
					array2 = (string[])Utils.CopyArray((Array)array2, new string[num + 1]);
					array2[num] = YJ;
					num++;
				}
				this.ListBox1.Items.Clear();
				string_ = array2;
			}
			int num3;
			long num2 = (long)num3;
			int num5;
			long num4 = (long)num5;
			double num6;
			double num7;
			double num8;
			this.method_6(string_, ref num6, ref num7, ref num8, ref array, ref num2, ref num4);
			checked
			{
				num5 = (int)num4;
				num3 = (int)num2;
				if (num7 != 0.0)
				{
					this.Label8.Text = Conversions.ToString((long)Math.Round(num7 / 100.0));
				}
				if (num6 != 0.0)
				{
					this.Label10.Text = Strings.Format(num6 / 4.0 / 100.0, "0.0");
				}
				if (num8 != 0.0)
				{
					this.method_0(this.Panel1, Conversions.ToString((long)Math.Round(num8 / 100.0)));
				}
				return null;
			}
		}

		private short method_6(string[] string_5, ref double double_0, ref double double_1, ref double double_2, ref string[] string_6, ref long long_0, ref long long_1)
		{
			int num;
			int num15;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				IL_0B:
				num2 = 3;
				long num3 = (long)Information.UBound(string_5, 1);
				IL_17:
				num2 = 4;
				short num4 = 0;
				short num5 = checked((short)num3);
				short num6 = num4;
				int num11;
				long steels;
				long steels2;
				long steels3;
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_2E:
					num2 = 5;
					string text = string_5[(int)num6];
					IL_36:
					num2 = 6;
					checked
					{
						int num9 = Strings.InStr(Strings.UCase(text), "X", CompareMethod.Binary) + Strings.InStr(text, " ", CompareMethod.Binary);
						IL_5A:
						num2 = 7;
						string text2 = text.Substring(0, 1);
						IL_67:
						num2 = 8;
						if (Strings.Asc(Strings.UCase(text2)) <= 90 & Strings.Asc(Strings.UCase(text2)) >= 65)
						{
							IL_92:
							num2 = 9;
						}
						else
						{
							IL_9A:
							num2 = 11;
							IL_9D:
							num2 = 12;
							if (num9 > 0)
							{
								IL_A7:
								num2 = 13;
								long_0 = Conversions.ToLong(text.Substring(0, num9 - 1));
								IL_BE:
								num2 = 14;
								long_1 = Conversions.ToLong(text.Substring(num9));
							}
							IL_D2:
							num2 = 16;
							if (Versioned.IsNumeric(text2) & num9 == 0)
							{
								IL_E4:
								num2 = 17;
								int num10;
								if (num10 == 0)
								{
									IL_EE:
									num2 = 18;
									steels = this.GetSteels1(text, ref num11);
								}
								else
								{
									IL_FF:
									num2 = 20;
									if (num10 == 1)
									{
										IL_109:
										num2 = 21;
										string s = text;
										int num12 = 0;
										steels2 = this.GetSteels1(s, ref num12);
									}
									else
									{
										IL_11C:
										num2 = 23;
										if (num10 == 2)
										{
											IL_126:
											num2 = 24;
											string s2 = text;
											int num12 = 0;
											steels3 = this.GetSteels1(s2, ref num12);
										}
									}
								}
								IL_16A:
								num2 = 26;
								num10++;
							}
						}
						IL_13A:
						num2 = 29;
						if (text.Contains("@"))
						{
							IL_14B:
							num2 = 30;
							this.KoyaxhoKD = JG.GetGuJin(text);
						}
						IL_15B:
						num2 = 32;
					}
					num6 += 1;
				}
				IL_175:
				num2 = 33;
				if (!(long_0 == 0L | long_1 == 0L))
				{
					goto IL_19C;
				}
				IL_197:
				goto IL_844;
				IL_19C:
				num2 = 36;
				if (!(steels2 == 0L & steels3 == 0L))
				{
					goto IL_201;
				}
				IL_1BB:
				num2 = 37;
				double_0 = (double)steels / (double)num11 * 4.0;
				IL_1D1:
				num2 = 38;
				double_1 = (double)steels / (double)num11 * ((double)(checked(num11 - 4)) / 4.0 + 2.0);
				IL_1F7:
				num2 = 39;
				double_2 = double_1;
				goto IL_238;
				IL_201:
				num2 = 41;
				IL_204:
				num2 = 42;
				double_0 = (double)steels;
				IL_20C:
				num2 = 43;
				double_1 = (double)steels / 2.0 + (double)steels2;
				IL_221:
				num2 = 44;
				double_2 = (double)steels / 2.0 + (double)steels3;
				IL_238:
				num2 = 46;
				long num13 = checked(steels + 2L * steels2 + 2L * steels3);
				IL_258:
				num2 = 47;
				string_6 = new string[7];
				IL_264:
				num2 = 50;
				string_6[0] = "柱子截面------" + Conversions.ToString(long_0) + "x" + Conversions.ToString(long_1);
				IL_28B:
				num2 = 51;
				this.ListBox1.Items.Add(string_6[0]);
				IL_2A4:
				num2 = 52;
				string_6[1] = "全截面As------" + Conversions.ToString(num13);
				IL_2BD:
				num2 = 53;
				this.ListBox1.Items.Add(string_6[1]);
				IL_2D6:
				num2 = 54;
				string_6[2] = "全截面ρ------" + Strings.Format((double)num13 / (double)long_0 / (double)long_1 * 100.0, "0.0000") + "%";
				IL_313:
				num2 = 55;
				this.ListBox1.Items.Add(string_6[2]);
				IL_32C:
				num2 = 56;
				checked
				{
					string_6[3] = "角筋面积------" + Conversions.ToString((long)Math.Round(double_0 / 4.0)) + "x4=" + Conversions.ToString((long)Math.Round(double_0));
					IL_367:
					num2 = 57;
					this.ListBox1.Items.Add(string_6[3]);
					IL_380:
					num2 = 58;
					string_6[4] = "单侧As----X=" + Conversions.ToString((long)Math.Round(double_1)) + " / Y= " + Conversions.ToString((long)Math.Round(double_2));
					IL_3B2:
					num2 = 59;
					this.ListBox1.Items.Add(string_6[4]);
					IL_3CB:
					num2 = 60;
					string_6[5] = string.Concat(unchecked(new string[]
					{
						"单侧ρ----X=",
						Strings.Format(double_1 / (double)long_0 / (double)long_1 * 100.0, "0.0000"),
						"% / Y= ",
						Strings.Format(double_2 / (double)long_0 / (double)long_1 * 100.0, "0.0000"),
						"%"
					}));
					IL_450:
					num2 = 61;
					this.ListBox1.Items.Add(string_6[5]);
					IL_469:
					num2 = 62;
					if (this.KoyaxhoKD.AsvD == 0)
					{
						goto IL_4AD;
					}
					IL_47F:
					num2 = 63;
					this.ListBox1.Items.Add("箍筋直径------" + Conversions.ToString((int)this.KoyaxhoKD.AsvD));
					IL_4AD:
					num2 = 65;
					if (this.KoyaxhoKD.JianJu1 == 0L)
					{
						goto IL_4F9;
					}
					IL_4CB:
					num2 = 66;
					this.ListBox1.Items.Add("加密区间距----" + Conversions.ToString(this.KoyaxhoKD.JianJu1));
					IL_4F9:
					num2 = 68;
					if (this.KoyaxhoKD.JianJu2 == 0L)
					{
						goto IL_545;
					}
					IL_517:
					num2 = 69;
					this.ListBox1.Items.Add("非加密区间距--" + Conversions.ToString(this.KoyaxhoKD.JianJu2));
					IL_545:
					num2 = 71;
					if (this.KoyaxhoKD.Asv1 == 0L)
					{
						goto IL_591;
					}
					IL_563:
					num2 = 72;
					this.ListBox1.Items.Add("加密区间距----" + Conversions.ToString(this.KoyaxhoKD.Asv1));
					IL_591:
					num2 = 74;
					if (this.KoyaxhoKD.Asv2 == 0L)
					{
						goto IL_5DD;
					}
					IL_5AF:
					num2 = 75;
					this.ListBox1.Items.Add("非加密区间距--" + Conversions.ToString(this.KoyaxhoKD.Asv2));
					IL_5DD:
					num2 = 77;
					if (this.KoyaxhoKD.Asv2 != 0L)
					{
						goto IL_611;
					}
					IL_5F8:
					num2 = 78;
					this.KoyaxhoKD.Asv2 = this.KoyaxhoKD.Asv1;
					IL_611:
					num2 = 80;
					this.Label11.Text = "G" + Strings.Format((double)(this.KoyaxhoKD.Asv1 * 100L) / (double)this.KoyaxhoKD.JianJu1 / 1000.0, "0.0") + "-" + Strings.Format((double)(this.KoyaxhoKD.Asv2 * 100L) / (double)this.KoyaxhoKD.JianJu1 / 1000.0, "0.0");
					IL_6A6:
					goto IL_844;
					IL_6AB:;
				}
				int num14 = num15 + 1;
				num15 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num14);
				IL_7FD:
				goto IL_839;
				IL_7FF:
				num15 = num2;
				if (num <= -2)
				{
					goto IL_6AB;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_817:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num15 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_7FF;
			}
			IL_839:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_844:
			short num16;
			short result = num16;
			if (num15 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public long GetSteels1(string S, ref int N = 0)
		{
			long num = 0L;
			checked
			{
				long result;
				if (S.Contains("@"))
				{
					result = 0L;
				}
				else
				{
					int num2 = Strings.InStr(S, " ", CompareMethod.Binary);
					if (num2 > 0)
					{
						S = S.Substring(0, num2 - 1);
					}
					num2 = Strings.InStr(S, "(", CompareMethod.Binary);
					if (num2 > 0)
					{
						S = S.Substring(0, num2 - 2);
					}
					S = S.Replace("/", "+");
					int num3 = Strings.InStr(S, "+", CompareMethod.Binary);
					if (num3 == 0)
					{
						S = Strings.Replace(S, "G", "", 1, -1, CompareMethod.Binary);
						S = Strings.Replace(S, "N", "", 1, -1, CompareMethod.Binary);
						S = Strings.Replace(S, "A", "D", 1, -1, CompareMethod.Binary);
						S = Strings.Replace(S, "B", "D", 1, -1, CompareMethod.Binary);
						S = Strings.Replace(S, "C", "D", 1, -1, CompareMethod.Binary);
						num2 = Strings.InStr(S, "D", CompareMethod.Binary);
						int num4 = Conversions.ToInteger(S.Substring(0, num2 - 1));
						int num5 = Conversions.ToInteger(S.Substring(num2));
						num = (long)Math.Round(unchecked(Conversion.Int((double)num4 * Math.Pow((double)num5, 2.0) * 3.14 / 4.0) + (double)num));
						if (num4 != 0)
						{
							N = num4;
						}
					}
					else
					{
						int num7;
						for (;;)
						{
							num2 = Strings.InStr(S, "D", CompareMethod.Binary);
							num3 = Strings.InStr(S, "+", CompareMethod.Binary);
							this.ListBox1.Items.Add("s  " + S);
							this.ListBox1.Items.Add("Temp1  " + Conversions.ToString(num2));
							this.ListBox1.Items.Add("Temp2  " + Conversions.ToString(num3));
							if (num2 == 0)
							{
								break;
							}
							int num4 = Conversions.ToInteger(S.Substring(0, num2 - 1));
							int num6;
							if (num3 > 0)
							{
								num6 = Conversions.ToInteger(S.Substring(num2, num3 - num2));
							}
							else if (num3 == 0)
							{
								num6 = Conversions.ToInteger(S.Substring(num2));
							}
							this.ListBox1.Items.Add("I  " + Conversions.ToString(num4));
							this.ListBox1.Items.Add("D1  " + Conversions.ToString(num6));
							num = (long)Math.Round(unchecked(Conversion.Int((double)num4 * Math.Pow((double)num6, 2.0) * 3.14 / 4.0) + (double)num));
							this.ListBox1.Items.Add("A  " + Conversions.ToString(num));
							num7 += num4;
							if (num3 == 0)
							{
								break;
							}
							S = S.Substring(num3);
						}
						N = num7;
						this.ListBox1.Items.Add("m  " + Conversions.ToString(N));
					}
					result = num;
				}
				return result;
			}
		}

		private void method_7(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.string_0 = this.TextBox2.Text;
				this.PFZ(this.string_0, this.string_1, this.string_2, this.string_3, this.string_4);
			}
		}

		private void method_8(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.string_1 = this.TextBox3.Text;
				this.PFZ(this.string_0, this.string_1, this.string_2, this.string_3, this.string_4);
			}
		}

		private void method_9(object sender, EventArgs e)
		{
			if (this.bool_0 && this.TextBox4.Text.Contains("@"))
			{
				this.string_2 = this.TextBox4.Text;
				this.PFZ(this.string_0, this.string_1, this.string_2, this.string_3, this.string_4);
			}
		}

		private void method_10(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.string_3 = this.TextBox5.Text;
				this.PFZ(this.string_0, this.string_1, this.string_2, this.string_3, this.string_4);
			}
		}

		private void method_11(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.string_4 = this.TextBox6.Text;
				this.PFZ(this.string_0, this.string_1, this.string_2, this.string_3, this.string_4);
			}
		}

		private void TcZJM_Frm_Paint(object sender, PaintEventArgs e)
		{
		}

		private void TcZJM_Frm_Shown(object sender, EventArgs e)
		{
			this.string_0 = this.TextBox2.Text;
			this.string_1 = this.TextBox3.Text;
			this.string_2 = this.TextBox4.Text;
			this.string_3 = this.TextBox5.Text;
			this.string_4 = this.TextBox6.Text;
			this.PFZ(this.string_0, this.string_1, this.string_2, this.string_3, this.string_4);
			this.bool_0 = true;
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("Label12")]
		private Label ESHYUYFNO;

		private string string_0;

		private string string_1;

		private string string_2;

		private string string_3;

		private string string_4;

		private bool bool_0;

		private JG.GuJin KoyaxhoKD;
	}
}
