using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcXG_frm : Form
	{
		[DebuggerNonUserCode]
		static TcXG_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcXG_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcXG_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcXG_frm_Load;
			TcXG_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcXG_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcXG_frm.list_0.Count == TcXG_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcXG_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcXG_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcXG_frm.list_0[num] = TcXG_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcXG_frm.list_0.RemoveRange(num, TcXG_frm.list_0.Count - num);
						TcXG_frm.list_0.Capacity = TcXG_frm.list_0.Count;
					}
					TcXG_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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

		internal virtual TabPage TabPage4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage4 = value;
			}
		}

		internal virtual TabPage TabPage5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage5 = value;
			}
		}

		internal virtual TabPage TabPage6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage6 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn IdDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_0 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn TypeDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_1 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn HDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_2 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn BDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_3 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn DDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_4 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn TDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_5 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn RDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_6 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn R1DataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_7 = value;
			}
		}

		internal virtual DataGridViewTextBoxColumn AreaDataGridViewTextBoxColumn
		{
			[DebuggerNonUserCode]
			get
			{
				return this.dataGridViewTextBoxColumn_8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.dataGridViewTextBoxColumn_8 = value;
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
				DataGridViewCellEventHandler value2 = new DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.CellDoubleClick -= value2;
				}
				this._DataGridView1 = value;
				if (this._DataGridView1 != null)
				{
					this._DataGridView1.CellDoubleClick += value2;
				}
			}
		}

		internal virtual DataGridView DataGridView2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DataGridViewCellEventHandler value2 = new DataGridViewCellEventHandler(this.DataGridView2_CellDoubleClick);
				if (this._DataGridView2 != null)
				{
					this._DataGridView2.CellDoubleClick -= value2;
				}
				this._DataGridView2 = value;
				if (this._DataGridView2 != null)
				{
					this._DataGridView2.CellDoubleClick += value2;
				}
			}
		}

		internal virtual DataGridView DataGridView3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DataGridViewCellEventHandler value2 = new DataGridViewCellEventHandler(this.DataGridView3_CellDoubleClick);
				if (this._DataGridView3 != null)
				{
					this._DataGridView3.CellDoubleClick -= value2;
				}
				this._DataGridView3 = value;
				if (this._DataGridView3 != null)
				{
					this._DataGridView3.CellDoubleClick += value2;
				}
			}
		}

		internal virtual DataGridView DataGridView4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._DataGridView4 = value;
			}
		}

		internal virtual DataGridView DataGridView5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DataGridViewCellEventHandler value2 = new DataGridViewCellEventHandler(this.DataGridView5_CellDoubleClick);
				if (this._DataGridView5 != null)
				{
					this._DataGridView5.CellDoubleClick -= value2;
				}
				this._DataGridView5 = value;
				if (this._DataGridView5 != null)
				{
					this._DataGridView5.CellDoubleClick += value2;
				}
			}
		}

		internal virtual DataGridView DataGridView6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._DataGridView6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._DataGridView6 = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcXG_frm_Load(object sender, EventArgs e)
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			string file = directoryPath + "\\Data\\型钢.Data";
			StreamReader streamReader = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileReader(file, Encoding.Default);
			this.DataGridView1.RowHeadersVisible = false;
			this.DataGridView1.Dock = DockStyle.Fill;
			this.DataGridView1.Columns.Add("C1", "型号");
			this.DataGridView1.Columns[0].Width = 70;
			this.DataGridView1.Columns.Add("C2", "边长1");
			this.DataGridView1.Columns[1].Width = 70;
			this.DataGridView1.Columns.Add("C3", "边长2");
			this.DataGridView1.Columns[2].Width = 70;
			this.DataGridView1.Columns.Add("C4", "d");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView1.Columns.Add("C5", "t");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView1.Columns.Add("C6", "r");
			this.DataGridView1.Columns[4].Width = 50;
			this.DataGridView1.Columns.Add("C7", "r1");
			this.DataGridView1.Columns[5].Width = 50;
			this.DataGridView1.Columns.Add("C8", "面积");
			this.DataGridView1.Columns[6].Width = 50;
			this.DataGridView2.RowHeadersVisible = false;
			this.DataGridView2.Dock = DockStyle.Fill;
			this.DataGridView2.Columns.Add("C1", "型号");
			this.DataGridView1.Columns[0].Width = 70;
			this.DataGridView2.Columns.Add("C2", "边长1");
			this.DataGridView1.Columns[1].Width = 70;
			this.DataGridView2.Columns.Add("C3", "边长2");
			this.DataGridView1.Columns[2].Width = 70;
			this.DataGridView2.Columns.Add("C4", "d");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView2.Columns.Add("C5", "t");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView2.Columns.Add("C6", "r");
			this.DataGridView1.Columns[4].Width = 50;
			this.DataGridView2.Columns.Add("C7", "r1");
			this.DataGridView1.Columns[5].Width = 50;
			this.DataGridView2.Columns.Add("C8", "面积");
			this.DataGridView1.Columns[6].Width = 50;
			this.DataGridView3.RowHeadersVisible = false;
			this.DataGridView3.Dock = DockStyle.Fill;
			this.DataGridView3.Columns.Add("C1", "型号");
			this.DataGridView1.Columns[0].Width = 70;
			this.DataGridView3.Columns.Add("C2", "高");
			this.DataGridView1.Columns[1].Width = 70;
			this.DataGridView3.Columns.Add("C3", "宽");
			this.DataGridView1.Columns[2].Width = 70;
			this.DataGridView3.Columns.Add("C4", "d");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView3.Columns.Add("C5", "t");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView3.Columns.Add("C6", "r");
			this.DataGridView1.Columns[4].Width = 50;
			this.DataGridView3.Columns.Add("C7", "r1");
			this.DataGridView1.Columns[5].Width = 50;
			this.DataGridView3.Columns.Add("C8", "面积");
			this.DataGridView1.Columns[6].Width = 50;
			this.DataGridView4.RowHeadersVisible = false;
			this.DataGridView4.Dock = DockStyle.Fill;
			this.DataGridView4.Columns.Add("C1", "型号");
			this.DataGridView1.Columns[0].Width = 70;
			this.DataGridView4.Columns.Add("C2", "高");
			this.DataGridView1.Columns[1].Width = 70;
			this.DataGridView4.Columns.Add("C3", "宽");
			this.DataGridView1.Columns[2].Width = 70;
			this.DataGridView4.Columns.Add("C4", "d");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView4.Columns.Add("C5", "t");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView4.Columns.Add("C6", "r");
			this.DataGridView1.Columns[4].Width = 50;
			this.DataGridView4.Columns.Add("C7", "r1");
			this.DataGridView1.Columns[5].Width = 50;
			this.DataGridView4.Columns.Add("C8", "面积");
			this.DataGridView1.Columns[6].Width = 50;
			this.DataGridView5.RowHeadersVisible = false;
			this.DataGridView5.Dock = DockStyle.Fill;
			this.DataGridView5.Columns.Add("C1", "型号");
			this.DataGridView1.Columns[0].Width = 70;
			this.DataGridView5.Columns.Add("C2", "高");
			this.DataGridView1.Columns[1].Width = 70;
			this.DataGridView5.Columns.Add("C3", "宽");
			this.DataGridView1.Columns[2].Width = 70;
			this.DataGridView5.Columns.Add("C4", "d");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView5.Columns.Add("C5", "t");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView5.Columns.Add("C6", "r");
			this.DataGridView1.Columns[4].Width = 50;
			this.DataGridView5.Columns.Add("C7", "r1");
			this.DataGridView1.Columns[5].Width = 50;
			this.DataGridView5.Columns.Add("C8", "面积");
			this.DataGridView1.Columns[6].Width = 50;
			this.DataGridView6.RowHeadersVisible = false;
			this.DataGridView6.Dock = DockStyle.Fill;
			this.DataGridView6.Columns.Add("C1", "型号");
			this.DataGridView1.Columns[0].Width = 70;
			this.DataGridView6.Columns.Add("C2", "高");
			this.DataGridView1.Columns[1].Width = 70;
			this.DataGridView6.Columns.Add("C3", "宽");
			this.DataGridView1.Columns[2].Width = 70;
			this.DataGridView6.Columns.Add("C4", "d");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView6.Columns.Add("C5", "t");
			this.DataGridView1.Columns[3].Width = 50;
			this.DataGridView6.Columns.Add("C6", "r");
			this.DataGridView1.Columns[4].Width = 50;
			this.DataGridView6.Columns.Add("C7", "r1");
			this.DataGridView1.Columns[5].Width = 50;
			this.DataGridView5.Columns.Add("C8", "面积");
			this.DataGridView1.Columns[6].Width = 50;
			checked
			{
				while (!streamReader.EndOfStream)
				{
					string text = streamReader.ReadLine();
					string[] array = null;
					if (Operators.CompareString(text.Substring(0, 2), "id", false) != 0)
					{
						array = new string[1];
						string s = text;
						string text2 = "\t";
						NF.Str2Arr(s, ref array, ref text2);
						if (Operators.CompareString(array[1].Substring(0, 1), "∟", false) == 0)
						{
							short index = (short)this.DataGridView1.Rows.Add();
							short num = 1;
							short num2 = (short)Information.UBound(array, 1);
							short num3 = num;
							for (;;)
							{
								short num4 = num3;
								short num5 = num2;
								if (num4 > num5)
								{
									break;
								}
								this.DataGridView1.Rows[(int)index].Cells[(int)(num3 - 1)].Value = array[(int)num3];
								unchecked
								{
									num3 += 1;
								}
							}
						}
						else if (Operators.CompareString(array[1].Substring(0, 1), "L", false) == 0)
						{
							short index2 = (short)this.DataGridView2.Rows.Add();
							short num6 = 1;
							short num7 = (short)Information.UBound(array, 1);
							short num3 = num6;
							for (;;)
							{
								short num8 = num3;
								short num5 = num7;
								if (num8 > num5)
								{
									break;
								}
								this.DataGridView2.Rows[(int)index2].Cells[(int)(num3 - 1)].Value = array[(int)num3];
								unchecked
								{
									num3 += 1;
								}
							}
						}
						else if (Operators.CompareString(array[1].Substring(0, 1), "I", false) == 0)
						{
							short index3 = (short)this.DataGridView3.Rows.Add();
							short num9 = 1;
							short num10 = (short)Information.UBound(array, 1);
							short num3 = num9;
							for (;;)
							{
								short num11 = num3;
								short num5 = num10;
								if (num11 > num5)
								{
									break;
								}
								this.DataGridView3.Rows[(int)index3].Cells[(int)(num3 - 1)].Value = array[(int)num3];
								unchecked
								{
									num3 += 1;
								}
							}
						}
						else if (Operators.CompareString(array[1].Substring(0, 1), "C", false) == 0)
						{
							short index4 = (short)this.DataGridView5.Rows.Add();
							short num12 = 1;
							short num13 = (short)Information.UBound(array, 1);
							short num3 = num12;
							for (;;)
							{
								short num14 = num3;
								short num5 = num13;
								if (num14 > num5)
								{
									break;
								}
								this.DataGridView5.Rows[(int)index4].Cells[(int)(num3 - 1)].Value = array[(int)num3];
								unchecked
								{
									num3 += 1;
								}
							}
						}
					}
				}
			}
		}

		public Entity JG(double B, double H, double D, double R)
		{
			Point3d point3d;
			point3d..ctor(0.0, 0.0, 0.0);
			Point2d point2d;
			point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
			Point2d point2d2;
			point2d2..ctor(point3d.get_Coordinate(0) + B, point3d.get_Coordinate(1));
			Point2d point2d3;
			point2d3..ctor(point3d.get_Coordinate(0) + B - D, point3d.get_Coordinate(1) + D);
			Point2d point2d4;
			point2d4..ctor(point3d.get_Coordinate(0) + D + R, point3d.get_Coordinate(1) + D);
			Point2d point2d5;
			point2d5..ctor(point3d.get_Coordinate(0) + D, point3d.get_Coordinate(1) + D + R);
			Point2d point2d6;
			point2d6..ctor(point3d.get_Coordinate(0) + D, point3d.get_Coordinate(1) + H - D);
			Point2d point2d7;
			point2d7..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1) + H);
			Polyline polyline = new Polyline();
			polyline.AddVertexAt(0, point2d, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(1, point2d2, Math.Tan(0.39269908169872414), 0.0, 0.0);
			polyline.AddVertexAt(2, point2d3, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(3, point2d4, -Math.Tan(0.39269908169872414), 0.0, 0.0);
			polyline.AddVertexAt(4, point2d5, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(5, point2d6, Math.Tan(0.39269908169872414), 0.0, 0.0);
			polyline.AddVertexAt(6, point2d7, 0.0, 0.0, 0.0);
			polyline.Closed = true;
			CAD.AddEnt(polyline);
			return polyline;
		}

		public Entity CG(double B, double H, double D, double T, double R)
		{
			Point3d point3d;
			point3d..ctor(0.0, 0.0, 0.0);
			double num = T - (B - D) / 2.0 / 10.0;
			double num2 = num / Math.Tan(1.5707963267948966 - (1.5707963267948966 + Math.Atan(0.1)) / 2.0);
			double num3 = num2 * (1.0 - Math.Cos(Math.Atan(10.0)));
			double num4 = num2 * (double)Math.Sign(Math.Atan(10.0));
			double num5 = R / Math.Tan((1.5707963267948966 + Math.Atan(0.1)) / 2.0);
			Point2d point2d;
			point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
			Point2d point2d2;
			point2d2..ctor(point3d.get_Coordinate(0) + B, point3d.get_Coordinate(1));
			Point2d point2d3;
			point2d3..ctor(point3d.get_Coordinate(0) + B - num3, point3d.get_Coordinate(1) + num4);
			Point2d point2d4;
			point2d4..ctor(point2d3.X - (B - D - num3 - num5 * Math.Cos(Math.Atan(0.1))), point2d3.Y + (B - D - num3 - num5 * Math.Cos(Math.Atan(0.1))) / 10.0);
			Point2d point2d5;
			point2d5..ctor(point2d4.X - num5 * Math.Cos(Math.Atan(0.1)), point2d4.Y + num5 * Math.Sin(Math.Atan(0.1)) + num5);
			Point2d point2d6;
			point2d6..ctor(point2d5.X, point2d5.Y + (H - (point2d5.Y - point2d.Y) * 2.0));
			Point2d point2d7;
			point2d7..ctor(point2d4.X, point2d6.Y + num5 + num5 * Math.Sin(Math.Atan(0.1)));
			Point2d point2d8;
			point2d8..ctor(point3d.get_Coordinate(0) + B - num3, point3d.get_Coordinate(1) + H - num4);
			Point2d point2d9;
			point2d9..ctor(point3d.get_Coordinate(0) + B, point3d.get_Coordinate(1) + H);
			Point2d point2d10;
			point2d10..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1) + H);
			Polyline polyline = new Polyline();
			polyline.AddVertexAt(0, point2d, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(1, point2d2, Math.Tan((1.5707963267948966 - Math.Atan(0.1)) / 4.0), 0.0, 0.0);
			polyline.AddVertexAt(2, point2d3, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(3, point2d4, -Math.Tan((1.5707963267948966 - Math.Atan(0.1)) / 4.0), 0.0, 0.0);
			polyline.AddVertexAt(4, point2d5, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(5, point2d6, -Math.Tan((1.5707963267948966 - Math.Atan(0.1)) / 4.0), 0.0, 0.0);
			polyline.AddVertexAt(6, point2d7, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(7, point2d8, Math.Tan((1.5707963267948966 - Math.Atan(0.1)) / 4.0), 0.0, 0.0);
			polyline.AddVertexAt(8, point2d9, 0.0, 0.0, 0.0);
			polyline.AddVertexAt(9, point2d10, 0.0, 0.0, 0.0);
			polyline.Closed = true;
			CAD.AddEnt(polyline);
			return polyline;
		}

		public Entity GZG(double B, double H, double D, double T, double R)
		{
			Point3d point3d;
			point3d..ctor(0.0, 0.0, 0.0);
			double num = T - (B - D) / 4.0 / 6.0;
			double num2 = num / Math.Tan(1.5707963267948966 - (1.5707963267948966 + Math.Atan(0.16666666666666666)) / 2.0);
			double num3 = num2 * (1.0 - Math.Cos(Math.Atan(6.0)));
			double num4 = num2 * Math.Sin(Math.Atan(6.0));
			double num5 = R / Math.Tan((1.5707963267948966 + Math.Atan(0.16666666666666666)) / 2.0);
			double[] array = new double[32];
			array[0] = point3d.get_Coordinate(0);
			array[1] = point3d.get_Coordinate(1);
			array[2] = point3d.get_Coordinate(0) + B;
			array[3] = point3d.get_Coordinate(1);
			array[4] = point3d.get_Coordinate(0) + B - num3;
			array[5] = point3d.get_Coordinate(1) + num4;
			array[6] = array[4] - ((B - D) / 2.0 - num3 - num5 * Math.Cos(Math.Atan(0.16666666666666666)));
			array[7] = array[5] + ((B - D) / 2.0 - num3 - num5 * Math.Cos(Math.Atan(0.16666666666666666))) / 6.0;
			array[8] = array[6] - num5 * Math.Cos(Math.Atan(0.16666666666666666));
			array[9] = array[7] + num5 * Math.Sin(Math.Atan(0.16666666666666666)) + num5;
			array[10] = array[8];
			array[11] = array[9] + (H - (array[9] - array[1]) * 2.0);
			array[12] = array[6];
			array[13] = array[11] + num5 + num5 * Math.Sin(Math.Atan(0.16666666666666666));
			array[14] = point3d.get_Coordinate(0) + B - num3;
			array[15] = point3d.get_Coordinate(1) + H - num4;
			array[16] = point3d.get_Coordinate(0) + B;
			array[17] = point3d.get_Coordinate(1) + H;
			array[18] = point3d.get_Coordinate(0);
			array[19] = point3d.get_Coordinate(1) + H;
			array[20] = point3d.get_Coordinate(0) + num3;
			array[21] = point3d.get_Coordinate(1) + H - num4;
			array[22] = array[20] + (B - D) / 2.0 - num3 - num5 * Math.Cos(Math.Atan(0.16666666666666666));
			array[23] = array[13];
			array[24] = array[10] - D;
			array[25] = array[11];
			array[26] = array[8] - D;
			array[27] = array[9];
			array[28] = array[22];
			array[29] = array[7];
			array[30] = array[20];
			array[31] = array[5];
			Polyline polyline = new Polyline();
			double num6 = Math.Tan((1.5707963267948966 - Math.Atan(0.16666666666666666)) / 4.0);
			Polyline polyline2 = polyline;
			int num7 = 0;
			Point2d point2d;
			point2d..ctor(array[0], array[1]);
			polyline2.AddVertexAt(num7, point2d, 0.0, 0.0, 0.0);
			Polyline polyline3 = polyline;
			int num8 = 1;
			point2d..ctor(array[2], array[3]);
			polyline3.AddVertexAt(num8, point2d, num6, 0.0, 0.0);
			Polyline polyline4 = polyline;
			int num9 = 2;
			point2d..ctor(array[4], array[5]);
			polyline4.AddVertexAt(num9, point2d, 0.0, 0.0, 0.0);
			Polyline polyline5 = polyline;
			int num10 = 3;
			point2d..ctor(array[6], array[7]);
			polyline5.AddVertexAt(num10, point2d, -num6, 0.0, 0.0);
			Polyline polyline6 = polyline;
			int num11 = 4;
			point2d..ctor(array[8], array[9]);
			polyline6.AddVertexAt(num11, point2d, 0.0, 0.0, 0.0);
			Polyline polyline7 = polyline;
			int num12 = 5;
			point2d..ctor(array[10], array[11]);
			polyline7.AddVertexAt(num12, point2d, -num6, 0.0, 0.0);
			Polyline polyline8 = polyline;
			int num13 = 6;
			point2d..ctor(array[12], array[13]);
			polyline8.AddVertexAt(num13, point2d, 0.0, 0.0, 0.0);
			Polyline polyline9 = polyline;
			int num14 = 7;
			point2d..ctor(array[14], array[15]);
			polyline9.AddVertexAt(num14, point2d, num6, 0.0, 0.0);
			Polyline polyline10 = polyline;
			int num15 = 8;
			point2d..ctor(array[16], array[17]);
			polyline10.AddVertexAt(num15, point2d, 0.0, 0.0, 0.0);
			Polyline polyline11 = polyline;
			int num16 = 9;
			point2d..ctor(array[18], array[19]);
			polyline11.AddVertexAt(num16, point2d, num6, 0.0, 0.0);
			Polyline polyline12 = polyline;
			int num17 = 10;
			point2d..ctor(array[20], array[21]);
			polyline12.AddVertexAt(num17, point2d, 0.0, 0.0, 0.0);
			Polyline polyline13 = polyline;
			int num18 = 11;
			point2d..ctor(array[22], array[23]);
			polyline13.AddVertexAt(num18, point2d, -num6, 0.0, 0.0);
			Polyline polyline14 = polyline;
			int num19 = 12;
			point2d..ctor(array[24], array[25]);
			polyline14.AddVertexAt(num19, point2d, 0.0, 0.0, 0.0);
			Polyline polyline15 = polyline;
			int num20 = 13;
			point2d..ctor(array[26], array[27]);
			polyline15.AddVertexAt(num20, point2d, -num6, 0.0, 0.0);
			Polyline polyline16 = polyline;
			int num21 = 14;
			point2d..ctor(array[28], array[29]);
			polyline16.AddVertexAt(num21, point2d, 0.0, 0.0, 0.0);
			Polyline polyline17 = polyline;
			int num22 = 15;
			point2d..ctor(array[30], array[31]);
			polyline17.AddVertexAt(num22, point2d, num6, 0.0, 0.0);
			polyline.Closed = true;
			CAD.AddEnt(polyline);
			return polyline;
		}

		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			double b = Conversions.ToDouble(this.DataGridView1.Rows[e.RowIndex].Cells[1].Value);
			double h = Conversions.ToDouble(this.DataGridView1.Rows[e.RowIndex].Cells[2].Value);
			double d = Conversions.ToDouble(this.DataGridView1.Rows[e.RowIndex].Cells[3].Value);
			double r = Conversions.ToDouble(this.DataGridView1.Rows[e.RowIndex].Cells[4].Value);
			JigEntIDs jigEntIDs = new JigEntIDs();
			ObjectId[] array = new ObjectId[]
			{
				this.JG(b, h, d, r).ObjectId
			};
			JigEntIDs jigEntIDs2 = jigEntIDs;
			ObjectId[] entIDs = array;
			Point3d basePoint;
			basePoint..ctor(0.0, 0.0, 0.0);
			jigEntIDs2.method_0(entIDs, basePoint);
			documentLock.Dispose();
			this.Show();
		}

		private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			double h = Conversions.ToDouble(this.DataGridView2.Rows[e.RowIndex].Cells[1].Value);
			double b = Conversions.ToDouble(this.DataGridView2.Rows[e.RowIndex].Cells[2].Value);
			double d = Conversions.ToDouble(this.DataGridView2.Rows[e.RowIndex].Cells[3].Value);
			double r = Conversions.ToDouble(this.DataGridView2.Rows[e.RowIndex].Cells[4].Value);
			JigEntIDs jigEntIDs = new JigEntIDs();
			ObjectId[] array = new ObjectId[]
			{
				this.JG(b, h, d, r).ObjectId
			};
			JigEntIDs jigEntIDs2 = jigEntIDs;
			ObjectId[] entIDs = array;
			Point3d basePoint;
			basePoint..ctor(0.0, 0.0, 0.0);
			jigEntIDs2.method_0(entIDs, basePoint);
			documentLock.Dispose();
			this.Show();
		}

		private void DataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			double h = Conversions.ToDouble(this.DataGridView5.Rows[e.RowIndex].Cells[1].Value);
			double b = Conversions.ToDouble(this.DataGridView5.Rows[e.RowIndex].Cells[2].Value);
			double d = Conversions.ToDouble(this.DataGridView5.Rows[e.RowIndex].Cells[3].Value);
			double t = Conversions.ToDouble(this.DataGridView5.Rows[e.RowIndex].Cells[4].Value);
			double r = Conversions.ToDouble(this.DataGridView5.Rows[e.RowIndex].Cells[5].Value);
			JigEntIDs jigEntIDs = new JigEntIDs();
			ObjectId[] array = new ObjectId[]
			{
				this.CG(b, h, d, t, r).ObjectId
			};
			JigEntIDs jigEntIDs2 = jigEntIDs;
			ObjectId[] entIDs = array;
			Point3d basePoint;
			basePoint..ctor(0.0, 0.0, 0.0);
			jigEntIDs2.method_0(entIDs, basePoint);
			documentLock.Dispose();
			this.Show();
		}

		private void DataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			double h = Conversions.ToDouble(this.DataGridView3.Rows[e.RowIndex].Cells[1].Value);
			double b = Conversions.ToDouble(this.DataGridView3.Rows[e.RowIndex].Cells[2].Value);
			double d = Conversions.ToDouble(this.DataGridView3.Rows[e.RowIndex].Cells[3].Value);
			double t = Conversions.ToDouble(this.DataGridView3.Rows[e.RowIndex].Cells[4].Value);
			double r = Conversions.ToDouble(this.DataGridView3.Rows[e.RowIndex].Cells[5].Value);
			JigEntIDs jigEntIDs = new JigEntIDs();
			ObjectId[] array = new ObjectId[]
			{
				this.GZG(b, h, d, t, r).ObjectId
			};
			JigEntIDs jigEntIDs2 = jigEntIDs;
			ObjectId[] entIDs = array;
			Point3d basePoint;
			basePoint..ctor(0.0, 0.0, 0.0);
			jigEntIDs2.method_0(entIDs, basePoint);
			documentLock.Dispose();
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

		[AccessedThroughProperty("TabPage4")]
		private TabPage _TabPage4;

		[AccessedThroughProperty("TabPage5")]
		private TabPage _TabPage5;

		[AccessedThroughProperty("TabPage6")]
		private TabPage _TabPage6;

		[AccessedThroughProperty("IdDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		[AccessedThroughProperty("TypeDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		[AccessedThroughProperty("HDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		[AccessedThroughProperty("BDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		[AccessedThroughProperty("DDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		[AccessedThroughProperty("TDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		[AccessedThroughProperty("RDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		[AccessedThroughProperty("R1DataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		[AccessedThroughProperty("AreaDataGridViewTextBoxColumn")]
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		[AccessedThroughProperty("DataGridView1")]
		private DataGridView _DataGridView1;

		[AccessedThroughProperty("DataGridView2")]
		private DataGridView _DataGridView2;

		[AccessedThroughProperty("DataGridView3")]
		private DataGridView _DataGridView3;

		[AccessedThroughProperty("DataGridView4")]
		private DataGridView _DataGridView4;

		[AccessedThroughProperty("DataGridView5")]
		private DataGridView _DataGridView5;

		[AccessedThroughProperty("DataGridView6")]
		private DataGridView _DataGridView6;
	}
}
