using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcPGP_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcPGP_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcPGP_Frm.list_0 = new List<WeakReference>();
		}

		public TcPGP_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcPGP_Frm_Load;
			TcPGP_Frm.smethod_0(this);
			this.short_0 = 0;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcPGP_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcPGP_Frm.list_0.Count == TcPGP_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcPGP_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcPGP_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcPGP_Frm.list_0[num] = TcPGP_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcPGP_Frm.list_0.RemoveRange(num, TcPGP_Frm.list_0.Count - num);
						TcPGP_Frm.list_0.Capacity = TcPGP_Frm.list_0.Count;
					}
					TcPGP_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				DataGridViewCellPaintingEventHandler value2 = new DataGridViewCellPaintingEventHandler(this.DataGridView1_CellPainting);
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.CellPainting -= value2;
				}
				this._DataGridView1 = value;
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.CellPainting += value2;
				}
			}
		}

		internal virtual DataGridViewTextBoxColumn 全称
		{
			[DebuggerNonUserCode]
			get
			{
				return this._全称;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._全称 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn 简称
		{
			[DebuggerNonUserCode]
			get
			{
				return this._简称;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._简称 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn 说明
		{
			[DebuggerNonUserCode]
			get
			{
				return this.jipAtgRsh;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.jipAtgRsh = value;
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

		private void TcPGP_Frm_Load(object sender, EventArgs e)
		{
			this.string_0 = this.Label1.Text;
			this.arrayList_0 = NF.ReadTxtFileCode936(this.string_0);
			bool flag = false;
			short num = 0;
			short num2 = checked((short)(this.arrayList_0.Count - 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				string text = Conversions.ToString(this.arrayList_0[(int)num3]);
				checked
				{
					if (text.Length > 0 && Operators.CompareString(text.Substring(0, 1), ";", false) != 0 && num3 != 0 && NF.InStr_N(text, ",") == 1)
					{
						short num6 = (short)Strings.InStr(text, ",", CompareMethod.Binary);
						short startIndex = (short)Strings.InStr(text, "*", CompareMethod.Binary);
						string text2 = Conversions.ToString(this.arrayList_0[(int)(num3 - 1)]);
						if (text2.Length > 3)
						{
							if (Operators.CompareString(text2.Substring(0, 2), ";;", false) == 0)
							{
								text2 = text2.Substring(2);
							}
							else
							{
								text2 = "";
							}
						}
						if (!flag)
						{
							this.short_0 = num3 - 1;
							flag = true;
						}
						string[] values = new string[]
						{
							text.Substring(0, (int)(num6 - 1)),
							text.Substring((int)startIndex),
							text2
						};
						this.DataGridView1.Rows.Add(values);
					}
				}
				num3 += 1;
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ArrayList arrayList = new ArrayList();
			short num = 0;
			short num2 = this.short_0;
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				arrayList.Add(RuntimeHelpers.GetObjectValue(this.arrayList_0[(int)num3]));
				num3 += 1;
			}
			short num6 = 1;
			short num7 = checked((short)(this.DataGridView1.RowCount - 2));
			short num8 = num6;
			for (;;)
			{
				short num9 = num8;
				short num5 = num7;
				if (num9 > num5)
				{
					break;
				}
				Debug.Print(this.DataGridView1.Rows[(int)num8].Cells[0].Value.ToString());
				string str = this.DataGridView1.Rows[(int)num8].Cells[0].Value.ToString();
				string str2 = this.DataGridView1.Rows[(int)num8].Cells[1].Value.ToString();
				string text = this.DataGridView1.Rows[(int)num8].Cells[2].Value.ToString();
				if (Operators.CompareString(text, "", false) != 0)
				{
					arrayList.Add(";;" + text);
					arrayList.Add(str + ",\t\t*" + str2);
				}
				else
				{
					arrayList.Add(str + ",\t\t*" + str2);
				}
				num8 += 1;
			}
			NF.SaveTxtFile(this.string_0, arrayList);
		}

		private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.ColumnIndex < 0 & e.RowIndex >= 0)
			{
				e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
				Rectangle cellBounds = e.CellBounds;
				cellBounds.Inflate(-2, -2);
				TextRenderer.DrawText(e.Graphics, (checked(e.RowIndex + 1)).ToString(), e.CellStyle.Font, cellBounds, e.CellStyle.ForeColor, TextFormatFlags.Right);
				e.Handled = true;
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("DataGridView1")]
		private DataGridView _DataGridView1;

		[AccessedThroughProperty("全称")]
		private DataGridViewTextBoxColumn _全称;

		[AccessedThroughProperty("简称")]
		private DataGridViewTextBoxColumn _简称;

		[AccessedThroughProperty("说明")]
		private DataGridViewTextBoxColumn jipAtgRsh;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		private string string_0;

		private ArrayList arrayList_0;

		private short short_0;
	}
}
