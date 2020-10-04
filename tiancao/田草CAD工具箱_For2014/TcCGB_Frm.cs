using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
	public partial class TcCGB_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcCGB_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcCGB_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcCGB_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcCGB_Frm_Load;
			TcCGB_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcCGB_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcCGB_Frm.list_0.Count == TcCGB_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcCGB_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcCGB_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcCGB_Frm.list_0[num] = TcCGB_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcCGB_Frm.list_0.RemoveRange(num, TcCGB_Frm.list_0.Count - num);
						TcCGB_Frm.list_0.Capacity = TcCGB_Frm.list_0.Count;
					}
					TcCGB_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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

		internal virtual DataGridView DataGridView1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.method_3);
				DataGridViewRowStateChangedEventHandler value3 = new DataGridViewRowStateChangedEventHandler(this.method_2);
				DataGridViewCellPaintingEventHandler value4 = new DataGridViewCellPaintingEventHandler(this.method_1);
				DataGridViewCellEventHandler value5 = new DataGridViewCellEventHandler(this.method_0);
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.DoubleClick -= value2;
					this._DataGridView1.RowStateChanged -= value3;
					this._DataGridView1.CellPainting -= value4;
					this._DataGridView1.CellEndEdit -= value5;
				}
				this._DataGridView1 = value;
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.DoubleClick += value2;
					this._DataGridView1.RowStateChanged += value3;
					this._DataGridView1.CellPainting += value4;
					this._DataGridView1.CellEndEdit += value5;
				}
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
				this._ComboBox2 = value;
			}
		}

		internal virtual ComboBox ComboBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ComboBox3 = value;
			}
		}

		internal virtual ComboBox ComboBox4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ComboBox4 = value;
			}
		}

		internal virtual ComboBox ComboBox5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ComboBox5 = value;
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
				EventHandler value2 = new EventHandler(this.CheckBox1_CheckedChanged);
				if (this._CheckBox1 != null)
				{
					this._CheckBox1.CheckedChanged -= value2;
				}
				this._CheckBox1 = value;
				if (this._CheckBox1 != null)
				{
					this._CheckBox1.CheckedChanged += value2;
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
				EventHandler value2 = new EventHandler(this.CheckBox2_CheckedChanged);
				if (this._CheckBox2 != null)
				{
					this._CheckBox2.CheckedChanged -= value2;
				}
				this._CheckBox2 = value;
				if (this._CheckBox2 != null)
				{
					this._CheckBox2.CheckedChanged += value2;
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

		internal virtual DataGridViewTextBoxColumn Column1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column1 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column2 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column3 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column4 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn Column5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Column5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Column5 = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void OK_Button_Click(object sender, EventArgs e)
		{
			if (this.DataGridView1.Rows.Count > 2)
			{
				ArrayList arrayList = new ArrayList();
				long num = 0L;
				long num2 = (long)(checked(this.DataGridView1.Rows.Count - 2));
				long num3 = num;
				checked
				{
					for (;;)
					{
						long num4 = num3;
						long num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						string value = string.Concat(new string[]
						{
							this.DataGridView1.Rows[(int)num3].Cells[0].Value.ToString(),
							";",
							this.DataGridView1.Rows[(int)num3].Cells[1].Value.ToString(),
							";",
							this.DataGridView1.Rows[(int)num3].Cells[2].Value.ToString(),
							";",
							this.DataGridView1.Rows[(int)num3].Cells[3].Value.ToString(),
							";",
							this.DataGridView1.Rows[(int)num3].Cells[4].Value.ToString(),
							";"
						});
						arrayList.Add(value);
						num3 += 1L;
					}
					string directoryPath = Class33.Class31_0.Info.DirectoryPath;
					NF.SaveTxtFile(Path.Combine(directoryPath, "Data\\CGB_Data.Data"), arrayList);
					this.DrawCengGaoBiao();
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void TcCGB_Frm_Load(object sender, EventArgs e)
		{
			short num = 1;
			do
			{
				this.ComboBox1.Items.Add(num);
				num += 1;
			}
			while (num <= 30);
			this.ComboBox1.Text = Conversions.ToString(1);
			short num2 = 2800;
			do
			{
				this.ComboBox2.Items.Add(num2);
				num2 += 100;
			}
			while (num2 <= 5400);
			this.ComboBox2.Text = Conversions.ToString(2900);
			this.ComboBox3.Text = "0.000";
			short num3 = 20;
			do
			{
				this.ComboBox4.Items.Add("C" + Conversions.ToString((int)num3));
				this.ComboBox5.Items.Add("C" + Conversions.ToString((int)num3));
				num3 += 5;
			}
			while (num3 <= 80);
			this.ComboBox4.Text = "C30";
			this.ComboBox5.Text = "C30";
			this.CheckBox1.Checked = false;
			this.DataGridView1.Columns[3].Visible = false;
			this.DataGridView1.Columns[4].Visible = false;
			this.ComboBox4.Enabled = false;
			this.ComboBox5.Enabled = false;
			this.Button2.Enabled = false;
			this.Button3.Enabled = false;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			short num = Conversions.ToShort(this.ComboBox1.Text);
			int num2 = Conversions.ToInteger(this.ComboBox2.Text);
			double num3 = Conversion.Val(this.ComboBox3.Text);
			string text = this.ComboBox4.Text;
			string text2 = this.ComboBox5.Text;
			if (num >= 1)
			{
				short num4 = 1;
				short num5 = num;
				short num6 = num4;
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					string text3 = Strings.Format(num3 + (double)(checked((int)(num6 - 1) * num2)) / 1000.0, "0.000");
					string[] values = new string[]
					{
						Conversions.ToString((int)num6),
						Conversions.ToString(num2),
						text3,
						text,
						text2
					};
					this.DataGridView1.Rows.Add(values);
					num6 += 1;
				}
				this.Button2.Enabled = true;
			}
		}

		private void method_0(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 2)
			{
				double num = Conversions.ToDouble(this.DataGridView1.Rows[e.RowIndex].Cells[2].Value);
				this.DataGridView1.Rows[e.RowIndex].Cells[2].Value = Strings.Format(num, "0.000");
				if (e.RowIndex != 0)
				{
					for (short num2 = checked((short)(e.RowIndex - 1)); num2 >= 0; num2 += -1)
					{
						short num3 = Conversions.ToShort(this.DataGridView1.Rows[(int)num2].Cells[1].Value);
						num -= (double)num3 / 1000.0;
					}
					this.DataGridView1.Rows[0].Cells[2].Value = Strings.Format(num, "0.000");
				}
				short num4 = 1;
				short num5 = checked((short)(this.DataGridView1.RowCount - 1));
				short num6 = num4;
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					short num9 = Conversions.ToShort(this.DataGridView1.Rows[(int)(checked(num6 - 1))].Cells[1].Value);
					num += (double)num9 / 1000.0;
					this.DataGridView1.Rows[(int)num6].Cells[e.ColumnIndex].Value = Strings.Format(num, "0.000");
					num6 += 1;
				}
			}
			else if (e.ColumnIndex == 1)
			{
				double num10 = Conversions.ToDouble(this.DataGridView1.Rows[0].Cells[2].Value);
				short num11 = 1;
				short num12 = checked((short)(this.DataGridView1.RowCount - 1));
				short num13 = num11;
				for (;;)
				{
					short num14 = num13;
					short num8 = num12;
					if (num14 > num8)
					{
						break;
					}
					short num15 = Conversions.ToShort(this.DataGridView1.Rows[(int)(checked(num13 - 1))].Cells[1].Value);
					num10 += (double)num15 / 1000.0;
					this.DataGridView1.Rows[(int)num13].Cells[2].Value = Strings.Format(num10, "0.000");
					num13 += 1;
				}
			}
		}

		private void method_1(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.ColumnIndex < 0 & e.RowIndex >= 0)
			{
				e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
				Rectangle cellBounds = e.CellBounds;
				cellBounds.Inflate(-2, -2);
				TextRenderer.DrawText(e.Graphics, (checked(e.RowIndex + 1)).ToString(), e.CellStyle.Font, cellBounds, e.CellStyle.ForeColor, TextFormatFlags.Default);
				e.Handled = true;
			}
		}

		public void DrawCengGaoBiao()
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			Point3d point3d = CAD.GetPoint("选择插入点: ");
			checked
			{
				Point3d point3d2;
				if (!(point3d == point3d2))
				{
					Class36.smethod_23(CAD.GetPointXY(point3d, 500.0, 150.0), "层号", 350.0, 0, "");
					Class36.smethod_23(CAD.GetPointXY(point3d, 1800.0, 150.0), "层高(m)", 350.0, 0, "");
					Class36.smethod_23(CAD.GetPointXY(point3d, 3300.0, 150.0), "标高(m)", 350.0, 0, "");
					if (this.CheckBox1.Checked)
					{
						Class36.smethod_23(CAD.GetPointXY(point3d, 4800.0, 150.0), "墙柱砼", 350.0, 0, "");
					}
					if (this.CheckBox1.Checked)
					{
						Class36.smethod_23(CAD.GetPointXY(point3d, 6300.0, 150.0), "梁板砼", 350.0, 0, "");
					}
					short num = (short)this.DataGridView1.Rows.Count;
					CAD.AddLine(CAD.GetPointXY(point3d, 1500.0, 0.0), CAD.GetPointXY(point3d, 1500.0, (double)((num + 1) * 600)), "0");
					CAD.AddLine(CAD.GetPointXY(point3d, 3000.0, 0.0), CAD.GetPointXY(point3d, 3000.0, (double)((num + 1) * 600)), "0");
					if (this.CheckBox1.Checked)
					{
						CAD.AddLine(CAD.GetPointXY(point3d, 4500.0, 0.0), CAD.GetPointXY(point3d, 4500.0, (double)((num + 1) * 600)), "0");
					}
					if (this.CheckBox1.Checked)
					{
						CAD.AddLine(CAD.GetPointXY(point3d, 6000.0, 0.0), CAD.GetPointXY(point3d, 6000.0, (double)((num + 1) * 600)), "0");
					}
					long num2 = 5000L;
					if (this.CheckBox1.Checked)
					{
						num2 = 7500L;
					}
					CAD.AddLine(CAD.GetPointXY(point3d, 0.0, (double)(num * 600)), CAD.GetPointXY(point3d, (double)num2, (double)(num * 600)), "0");
					CAD.AddLine(CAD.GetPointXY(point3d, 0.0, (double)((num - 1) * 600)), CAD.GetPointXY(point3d, (double)num2, (double)((num - 1) * 600)), "0");
					num -= 2;
					string[] array = new string[(int)(num + 1)];
					string[] array2 = new string[(int)(num + 1)];
					string[] array3 = new string[(int)(num + 1 + 1)];
					string[] array4 = new string[(int)(num + 1)];
					string[] array5 = new string[(int)(num + 1 + 1)];
					array5[0] = "-";
					short num3 = 0;
					short num4 = num;
					short num5 = num3;
					for (;;)
					{
						short num6 = num5;
						short num7 = num4;
						if (num6 > num7)
						{
							break;
						}
						CAD.AddLine(CAD.GetPointXY(point3d, 0.0, (double)(num5 * 600)), CAD.GetPointXY(point3d, (double)num2, (double)(num5 * 600)), "0");
						array[(int)num5] = Conversions.ToString(this.DataGridView1.Rows[(int)num5].Cells[0].Value);
						double num8 = Conversions.ToDouble(Operators.DivideObject(this.DataGridView1.Rows[(int)num5].Cells[1].Value, 1000));
						array2[(int)num5] = Strings.Format(num8, "0.000");
						if (Operators.ConditionalCompareObjectEqual(this.DataGridView1.Rows[(int)num5].Cells[2].Value, "0.000", false))
						{
							array3[(int)num5] = Conversions.ToString(this.DataGridView1.Rows[(int)num5].Cells[2].Value);
						}
						else
						{
							array3[(int)num5] = Conversions.ToString(this.DataGridView1.Rows[(int)num5].Cells[2].Value);
						}
						if (this.CheckBox1.Checked)
						{
							array4[(int)num5] = Conversions.ToString(this.DataGridView1.Rows[(int)num5].Cells[3].Value);
							if (!array4[(int)num5].ToUpper().Contains("C"))
							{
								array4[(int)num5] = "C" + array4[(int)num5].ToUpper();
							}
							else
							{
								array4[(int)num5] = array4[(int)num5].ToUpper();
							}
						}
						if (this.CheckBox1.Checked)
						{
							array5[(int)(num5 + 1)] = Conversions.ToString(this.DataGridView1.Rows[(int)num5].Cells[4].Value);
							if (!array5[(int)(num5 + 1)].ToUpper().Contains("C"))
							{
								array5[(int)(num5 + 1)] = "C" + array5[(int)(num5 + 1)].ToUpper();
							}
							else
							{
								array5[(int)(num5 + 1)] = array5[(int)(num5 + 1)].ToUpper();
							}
						}
						unchecked
						{
							num5 += 1;
						}
					}
					double num9 = Conversions.ToDouble(Operators.AddObject(this.DataGridView1.Rows[(int)num].Cells[2].Value, Operators.DivideObject(this.DataGridView1.Rows[(int)num].Cells[1].Value, 1000)));
					array3[(int)(num + 1)] = Strings.Format(num9, "0.000");
					Class36.smethod_21(CAD.GetPointXY(point3d, 1000.0, 150.0), array, 300.0, -2.0);
					Class36.smethod_20(CAD.GetPointXY(point3d, 1800.0, 150.0), array2, 300.0, -2.0, "");
					Class36.smethod_21(CAD.GetPointXY(point3d, 4200.0, 150.0), array3, 300.0, -2.0);
					if (this.CheckBox1.Checked)
					{
						Class36.smethod_20(CAD.GetPointXY(point3d, 4800.0, 150.0), array4, 300.0, -2.0, "");
					}
					if (this.CheckBox1.Checked)
					{
						Class36.smethod_20(CAD.GetPointXY(point3d, 6300.0, 150.0), array5, 300.0, -2.0, "");
					}
					if (this.CheckBox1.Checked)
					{
						num2 = 3750L;
					}
					else
					{
						num2 = 2500L;
					}
					point3d = CAD.GetPointXY(point3d, (double)num2, -1500.0);
					Class36.smethod_24(point3d, "结构层高表", 500.0, 0, "");
					point3d = CAD.GetPointXY(point3d, 0.0, -750.0);
					Class36.smethod_24(point3d, "注:标高均为楼面结构标高", 350.0, 0, "");
					Point3d[] array6 = new Point3d[]
					{
						CAD.GetPointXY(point3d, -1500.0, 600.0),
						CAD.GetPointXY(point3d, 1500.0, 600.0)
					};
					CAD.AddPline(array6, 75.0, false, "");
					CAD.AddLine(CAD.GetPointAngle(array6[0], 125.0, -90.0), CAD.GetPointAngle(array6[1], 125.0, -90.0), "0");
					documentLock.Dispose();
				}
			}
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.CheckBox1.Checked)
			{
				this.DataGridView1.Columns[3].Visible = false;
				this.DataGridView1.Columns[4].Visible = false;
				this.ComboBox4.Enabled = false;
				this.ComboBox5.Enabled = false;
			}
			else
			{
				this.DataGridView1.Columns[3].Visible = true;
				this.DataGridView1.Columns[4].Visible = true;
				this.ComboBox4.Enabled = true;
				this.ComboBox5.Enabled = true;
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			int num;
			int num3;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.DataGridView1.Rows.Clear();
				IL_1B:
				num2 = 3;
				this.Button2.Enabled = false;
				IL_29:
				goto IL_86;
				IL_2B:
				goto IL_90;
				IL_2D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_44;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_64;
				IL_44:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_64:
				goto IL_90;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2D;
			}
			IL_86:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_90:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void method_2(object sender, DataGridViewRowStateChangedEventArgs e)
		{
			if (this.DataGridView1.Rows.Count >= 1)
			{
				this.Button2.Enabled = true;
				this.Button3.Enabled = true;
			}
			else
			{
				this.Button2.Enabled = false;
				this.Button3.Enabled = false;
			}
		}

		private void method_3(object sender, EventArgs e)
		{
			int num;
			int num10;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				this.DataGridView1.Rows.RemoveAt(this.DataGridView1.CurrentRow.Index);
				IL_2B:
				num2 = 3;
				double num3 = Conversions.ToDouble(this.DataGridView1.Rows[0].Cells[2].Value);
				IL_54:
				num2 = 4;
				short num4 = 1;
				short num5 = checked((short)(this.DataGridView1.RowCount - 1));
				short num6 = num4;
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_6B:
					num2 = 5;
					short num9 = Conversions.ToShort(this.DataGridView1.Rows[(int)(checked(num6 - 1))].Cells[1].Value);
					IL_98:
					num2 = 6;
					num3 += (double)num9 / 1000.0;
					IL_AA:
					num2 = 7;
					this.DataGridView1.Rows[(int)num6].Cells[2].Value = Strings.Format(num3, "0.000");
					IL_DE:
					num2 = 8;
					num6 += 1;
				}
				IL_F4:
				goto IL_165;
				IL_F6:
				goto IL_16F;
				IL_F8:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_10F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_143;
				IL_10F:
				int num11 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num11);
				IL_143:
				goto IL_16F;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_F8;
			}
			IL_165:
			if (num10 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_16F:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				long num3 = Conversions.ToLong(this.DataGridView1.Rows[0].Cells[0].Value);
				IL_32:
				num2 = 3;
				checked
				{
					num3 -= 1L;
					IL_40:
					num2 = 4;
					if (num3 != 0L)
					{
						goto IL_5C;
					}
					IL_50:
					num2 = 5;
					num3 = -1L;
					IL_5C:
					num2 = 7;
					short num4 = 0;
					short num5 = (short)(this.DataGridView1.RowCount - 1);
					short num6 = num4;
					for (;;)
					{
						short num7 = num6;
						short num8 = num5;
						if (num7 > num8)
						{
							break;
						}
						IL_7B:
						num2 = 8;
						this.DataGridView1.Rows[(int)num6].Cells[0].Value = num3;
						IL_A5:
						num2 = 9;
						num3 += 1L;
						IL_B4:
						num2 = 10;
						if (num3 == 0L)
						{
							IL_C5:
							num2 = 11;
							num3 = 1L;
						}
						IL_D2:
						num2 = 13;
						unchecked
						{
							num6 += 1;
						}
					}
					IL_DE:
					goto IL_16C;
					IL_E3:
					goto IL_176;
					IL_E8:
					num9 = num2;
					if (num <= -2)
					{
						goto IL_FF;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_147;
					IL_FF:;
				}
				int num10 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_147:
				goto IL_176;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_E8;
			}
			IL_16C:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_176:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.CheckBox2.Checked)
			{
				this.DataGridView1.Rows.Clear();
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				ArrayList arrayList = new ArrayList();
				NF.ReadTxtFile(Path.Combine(directoryPath, "Data\\CGB_Data.Data"), ref arrayList);
				short num3;
				short num4;
				checked
				{
					short num = (short)arrayList.Count;
					short num2 = 0;
					num3 = num - 1;
					num4 = num2;
				}
				for (;;)
				{
					short num5 = num4;
					short num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					string[] values = (string[])NewLateBinding.LateGet(arrayList[(int)num4], null, "Split", new object[]
					{
						";"
					}, null, null, null);
					this.DataGridView1.Rows.Add(values);
					num4 += 1;
				}
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		[AccessedThroughProperty("OK_Button")]
		private Button _OK_Button;

		[AccessedThroughProperty("Cancel_Button")]
		private Button _Cancel_Button;

		[AccessedThroughProperty("DataGridView1")]
		private DataGridView _DataGridView1;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("ComboBox2")]
		private ComboBox _ComboBox2;

		[AccessedThroughProperty("ComboBox3")]
		private ComboBox _ComboBox3;

		[AccessedThroughProperty("ComboBox4")]
		private ComboBox _ComboBox4;

		[AccessedThroughProperty("ComboBox5")]
		private ComboBox _ComboBox5;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("CheckBox2")]
		private CheckBox _CheckBox2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Column1")]
		private DataGridViewTextBoxColumn _Column1;

		[AccessedThroughProperty("Column2")]
		private DataGridViewTextBoxColumn _Column2;

		[AccessedThroughProperty("Column3")]
		private DataGridViewTextBoxColumn _Column3;

		[AccessedThroughProperty("Column4")]
		private DataGridViewTextBoxColumn _Column4;

		[AccessedThroughProperty("Column5")]
		private DataGridViewTextBoxColumn _Column5;
	}
}
