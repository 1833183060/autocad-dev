using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcBmp2Dwg_frm : Form
	{
		[DebuggerNonUserCode]
		static TcBmp2Dwg_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcBmp2Dwg_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcBmp2Dwg_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcBmp2Dwg_frm_Load;
			TcBmp2Dwg_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcBmp2Dwg_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcBmp2Dwg_frm.list_0.Count == TcBmp2Dwg_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcBmp2Dwg_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcBmp2Dwg_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcBmp2Dwg_frm.list_0[num] = TcBmp2Dwg_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcBmp2Dwg_frm.list_0.RemoveRange(num, TcBmp2Dwg_frm.list_0.Count - num);
						TcBmp2Dwg_frm.list_0.Capacity = TcBmp2Dwg_frm.list_0.Count;
					}
					TcBmp2Dwg_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				this._TextBox1 = value;
			}
		}

		internal virtual OpenFileDialog OpenFileDialog1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.openFileDialog_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.openFileDialog_0 = value;
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

		internal virtual Button Button6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button6_Click);
				if (this._Button6 != null)
				{
					this._Button6.Click -= value2;
				}
				this._Button6 = value;
				if (this._Button6 != null)
				{
					this._Button6.Click += value2;
				}
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

		internal virtual Button Button7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button7_Click);
				if (this._Button7 != null)
				{
					this._Button7.Click -= value2;
				}
				this._Button7 = value;
				if (this._Button7 != null)
				{
					this._Button7.Click += value2;
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

		internal virtual NumericUpDown NumericUpDown1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._NumericUpDown1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._NumericUpDown1 = value;
			}
		}

		internal virtual Button Button8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button8_Click);
				if (this._Button8 != null)
				{
					this._Button8.Click -= value2;
				}
				this._Button8 = value;
				if (this._Button8 != null)
				{
					this._Button8.Click += value2;
				}
			}
		}

		internal virtual Panel Panel2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel2 = value;
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

		internal virtual Button Button9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button9_Click);
				if (this._Button9 != null)
				{
					this._Button9.Click -= value2;
				}
				this._Button9 = value;
				if (this._Button9 != null)
				{
					this._Button9.Click += value2;
				}
			}
		}

		internal virtual Button Button10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button10_Click);
				if (this._Button10 != null)
				{
					this._Button10.Click -= value2;
				}
				this._Button10 = value;
				if (this._Button10 != null)
				{
					this._Button10.Click += value2;
				}
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			int num;
			int num13;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1C:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_2F:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_61;
				}
				IL_40:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_54:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_61;
				}
				IL_5C:
				goto IL_2BB;
				IL_61:
				num2 = 10;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_7A:
				num2 = 11;
				long num4 = 0L;
				long num5 = (long)bitmap.Width;
				long num6 = num4;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_9E:
					num2 = 12;
					long num9;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num6 * num9)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_DB:
					num2 = 13;
					long num10 = 0L;
					long num11 = (long)bitmap.Height;
					num9 = num10;
					checked
					{
						for (;;)
						{
							long num12 = num9;
							num8 = num11;
							if (num12 > num8)
							{
								break;
							}
							IL_FF:
							num2 = 14;
							Application.DoEvents();
							IL_107:
							num2 = 15;
							Color pixel = bitmap.GetPixel((int)num6, (int)num9);
							IL_118:
							num2 = 16;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0) < (double)this.short_0)
							{
								IL_15E:
								num2 = 17;
								Point3d p;
								p..ctor((double)num6, (double)(0L - num9), 0.0);
								IL_181:
								num2 = 18;
								CAD.AddPoint(p);
							}
							IL_1A4:
							num2 = 20;
							num9 += 1L;
						}
						IL_18E:
						num2 = 21;
						num6 += 1L;
					}
				}
				IL_1BA:
				num2 = 22;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_1CA:
				num2 = 23;
				this.Close();
				IL_1D3:
				num2 = 24;
				documentLock.Dispose();
				IL_1DD:
				num2 = 25;
				if (Information.Err().Number <= 0)
				{
				}
				IL_1EF:
				goto IL_2BB;
				IL_1F4:
				goto IL_2C6;
				IL_1F9:
				num13 = num2;
				if (num <= -2)
				{
					goto IL_214;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_295;
				IL_214:
				int num14 = num13 + 1;
				num13 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num14);
				IL_295:
				goto IL_2C6;
			}
			catch when (endfilter(obj is Exception & num != 0 & num13 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1F9;
			}
			IL_2BB:
			if (num13 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_2C6:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			openFileDialog.Title = "选择图像文件";
			openFileDialog.Filter = "图像文件(*.bmp;*.jpg;;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png|所有文件(*.*)|*.*";
			openFileDialog.DefaultExt = "*.bmp";
			openFileDialog.InitialDirectory = this.TextBox1.Text;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] fileNames = openFileDialog.FileNames;
				this.TextBox1.Text = fileNames[0];
				this.PictureBox1.Load(this.TextBox1.Text);
				this.Show();
			}
		}

		private void Button5_Click(object sender, EventArgs e)
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
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1C:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_2F:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_63;
				}
				IL_40:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_55:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_63;
				}
				IL_5E:
				goto IL_2BF;
				IL_63:
				num2 = 10;
				long num4 = 0L;
				long num5 = (long)bitmap.Width;
				long num6 = num4;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_7E:
					num2 = 11;
					long num9;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num6 * num9)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_BB:
					num2 = 12;
					long num10 = 0L;
					long num11 = (long)bitmap.Height;
					num9 = num10;
					checked
					{
						for (;;)
						{
							long num12 = num9;
							num8 = num11;
							if (num12 > num8)
							{
								break;
							}
							IL_D7:
							num2 = 13;
							Application.DoEvents();
							IL_DF:
							num2 = 14;
							Color pixel = bitmap.GetPixel((int)num6, (int)num9);
							IL_F0:
							num2 = 15;
							short num13 = (short)Math.Round(Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0));
							IL_133:
							num2 = 16;
							Point3d point3d;
							point3d..ctor((double)num6, (double)(0L - num9), 0.0);
							IL_156:
							num2 = 17;
							DBPoint dbpoint = new DBPoint(point3d);
							IL_162:
							num2 = 18;
							dbpoint.Color = Color.FromRgb((byte)num13, (byte)num13, (byte)num13);
							IL_17A:
							num2 = 19;
							CAD.AddEnt(dbpoint);
							IL_185:
							num2 = 20;
							num9 += 1L;
						}
						IL_1A3:
						num2 = 21;
						num6 += 1L;
					}
				}
				IL_1C0:
				num2 = 22;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_1D0:
				num2 = 23;
				this.Close();
				IL_1D9:
				num2 = 24;
				documentLock.Dispose();
				IL_1E3:
				num2 = 25;
				if (Information.Err().Number <= 0)
				{
				}
				IL_1F5:
				goto IL_2BF;
				IL_1FA:
				int num14 = num15 + 1;
				num15 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num14);
				IL_276:
				goto IL_2B4;
				IL_278:
				num15 = num2;
				if (num <= -2)
				{
					goto IL_1FA;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_291:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num15 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_278;
			}
			IL_2B4:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2BF:
			if (num15 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			int num;
			int num14;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1C:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_2F:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_63;
				}
				IL_40:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_55:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_63;
				}
				IL_5E:
				goto IL_362;
				IL_63:
				num2 = 10;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_7C:
				num2 = 11;
				long num4 = 0L;
				long num5 = (long)bitmap.Width;
				long num6 = num4;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_A0:
					num2 = 12;
					long num9;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num6 * num9)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_DC:
					num2 = 13;
					long num10 = 0L;
					IL_EA:
					num2 = 14;
					long num11 = 0L;
					long num12 = (long)bitmap.Height;
					num9 = num11;
					checked
					{
						for (;;)
						{
							long num13 = num9;
							num8 = num12;
							if (num13 > num8)
							{
								break;
							}
							IL_10C:
							num2 = 15;
							Application.DoEvents();
							IL_114:
							num2 = 16;
							Color pixel = bitmap.GetPixel((int)num6, (int)num9);
							IL_124:
							num2 = 17;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0) < (double)this.short_0)
							{
								IL_16A:
								num2 = 18;
								if (num10 == 0L)
								{
									IL_17F:
									num2 = 19;
									num10 = num9;
									IL_185:
									num2 = 20;
									Point3d p;
									p..ctor((double)num6, (double)(0L - num9), 0.0);
								}
							}
							else
							{
								IL_1A9:
								num2 = 23;
								IL_1AC:
								num2 = 24;
								if (num10 != 0L)
								{
									IL_1C1:
									num2 = 25;
									Point3d p2;
									p2..ctor((double)num6, (double)(0L - (num9 - 1L)), 0.0);
									IL_1ED:
									num2 = 26;
									Point3d p;
									CAD.AddLine(p, p2, "0");
									IL_1FF:
									num2 = 27;
									num10 = 0L;
								}
							}
							IL_225:
							num2 = 30;
							num9 += 1L;
						}
						IL_20F:
						num2 = 31;
						num6 += 1L;
					}
				}
				IL_239:
				num2 = 32;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_249:
				num2 = 33;
				this.Close();
				IL_252:
				num2 = 34;
				documentLock.Dispose();
				IL_25C:
				num2 = 35;
				if (Information.Err().Number <= 0)
				{
				}
				IL_26E:
				goto IL_362;
				IL_273:
				goto IL_36D;
				IL_278:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_293;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_33C;
				IL_293:
				int num15 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num15);
				IL_33C:
				goto IL_36D;
			}
			catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_278;
			}
			IL_362:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_36D:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Point3d[] array = null;
			this.Hide();
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			checked
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array2 = new TypedValue[1];
					Array array3 = array2;
					TypedValue typedValue;
					typedValue..ctor(0, "Point");
					array3.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array2);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						ObjectId[] objectIds = selection.Value.GetObjectIds();
						array = new Point3d[objectIds.Length - 1 + 1];
						short num = 0;
						foreach (ObjectId objectId in objectIds)
						{
							Entity entity = (Entity)transaction.GetObject(objectId, 1);
							array[(int)num] = entity.GeometricExtents.MinPoint;
							num += 1;
						}
						Interaction.MsgBox(array[objectIds.Length - 1].X, MsgBoxStyle.OkOnly, null);
					}
					transaction.Commit();
				}
				documentLock.Dispose();
				Class36.smethod_47(ref array);
				this.Show();
			}
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			int num;
			int num14;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1C:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_30:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_65;
				}
				IL_42:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_57:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_65;
				}
				IL_60:
				goto IL_368;
				IL_65:
				num2 = 10;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_7E:
				num2 = 11;
				long num4 = 0L;
				long num5 = (long)bitmap.Height;
				long num6 = num4;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_A3:
					num2 = 12;
					long num9;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num9 * num6)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_E1:
					num2 = 13;
					long num10 = 0L;
					IL_EF:
					num2 = 14;
					long num11 = 0L;
					long num12 = (long)bitmap.Width;
					num9 = num11;
					checked
					{
						for (;;)
						{
							long num13 = num9;
							num8 = num12;
							if (num13 > num8)
							{
								break;
							}
							IL_112:
							num2 = 15;
							Application.DoEvents();
							IL_11A:
							num2 = 16;
							Color pixel = bitmap.GetPixel((int)num9, (int)num6);
							IL_12B:
							num2 = 17;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0) < (double)this.short_0)
							{
								IL_171:
								num2 = 18;
								if (num10 == 0L)
								{
									IL_186:
									num2 = 19;
									num10 = num9;
									IL_18C:
									num2 = 20;
									Point3d p;
									p..ctor((double)num9, (double)(0L - num6), 0.0);
								}
							}
							else
							{
								IL_1B0:
								num2 = 23;
								IL_1B3:
								num2 = 24;
								if (num10 != 0L)
								{
									IL_1C8:
									num2 = 25;
									Point3d p2;
									p2..ctor((double)(num9 - 1L), (double)(0L - num6), 0.0);
									IL_1F4:
									num2 = 26;
									Point3d p;
									CAD.AddLine(p, p2, "0");
									IL_205:
									num2 = 27;
									num10 = 0L;
								}
							}
							IL_22B:
							num2 = 30;
							num9 += 1L;
						}
						IL_215:
						num2 = 31;
						num6 += 1L;
					}
				}
				IL_23F:
				num2 = 32;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_24F:
				num2 = 33;
				this.Close();
				IL_258:
				num2 = 34;
				documentLock.Dispose();
				IL_262:
				num2 = 35;
				if (Information.Err().Number <= 0)
				{
				}
				IL_274:
				goto IL_368;
				IL_279:
				goto IL_373;
				IL_27E:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_299;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_342;
				IL_299:
				int num15 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num15);
				IL_342:
				goto IL_373;
			}
			catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_27E;
			}
			IL_368:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_373:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			int num;
			int num22;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1C:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_30:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_65;
				}
				IL_42:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_57:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_65;
				}
				IL_60:
				goto IL_584;
				IL_65:
				num2 = 10;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_7E:
				num2 = 11;
				long num4 = 0L;
				long num5 = (long)bitmap.Height;
				long num6 = num4;
				long num9;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_A3:
					num2 = 12;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num9 * num6)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_E1:
					num2 = 13;
					long num10 = 0L;
					IL_EF:
					num2 = 14;
					long num11 = 0L;
					long num12 = (long)bitmap.Width;
					num9 = num11;
					checked
					{
						for (;;)
						{
							long num13 = num9;
							num8 = num12;
							if (num13 > num8)
							{
								break;
							}
							IL_112:
							num2 = 15;
							Application.DoEvents();
							IL_11A:
							num2 = 16;
							Color pixel = bitmap.GetPixel((int)num9, (int)num6);
							IL_12B:
							num2 = 17;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0) < (double)this.short_0)
							{
								IL_171:
								num2 = 18;
								if (num10 == 0L)
								{
									IL_186:
									num2 = 19;
									num10 = num6;
									IL_18D:
									num2 = 20;
									Point3d p;
									p..ctor((double)num9, (double)(0L - num6), 0.0);
								}
							}
							else
							{
								IL_1B4:
								num2 = 23;
								IL_1B7:
								num2 = 24;
								if (num10 != 0L)
								{
									IL_1CC:
									num2 = 25;
									Point3d p2;
									p2..ctor((double)(num9 - 1L), (double)(0L - num6), 0.0);
									IL_1F8:
									num2 = 26;
									Point3d p;
									CAD.AddPoint(p);
									IL_203:
									num2 = 27;
									CAD.AddPoint(p2);
									IL_20E:
									num2 = 28;
									num10 = 0L;
								}
							}
							IL_234:
							num2 = 31;
							num9 += 1L;
						}
						IL_21E:
						num2 = 32;
						num6 += 1L;
					}
				}
				IL_248:
				num2 = 33;
				long num14 = 0L;
				long num15 = (long)bitmap.Width;
				num9 = num14;
				for (;;)
				{
					long num16 = num9;
					long num8 = num15;
					if (num16 > num8)
					{
						break;
					}
					IL_26B:
					num2 = 34;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num9 * num6)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_2A9:
					num2 = 35;
					long num17 = 0L;
					IL_2B7:
					num2 = 36;
					long num18 = 0L;
					long num19 = (long)bitmap.Height;
					num6 = num18;
					checked
					{
						for (;;)
						{
							long num20 = num6;
							num8 = num19;
							if (num20 > num8)
							{
								break;
							}
							IL_2DC:
							num2 = 37;
							Application.DoEvents();
							IL_2E4:
							num2 = 38;
							Color pixel2 = bitmap.GetPixel((int)num9, (int)num6);
							IL_2F5:
							num2 = 39;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel2.R) + Conversion.Int((short)pixel2.G) + Conversion.Int((short)pixel2.B))) / 3.0) < (double)this.short_0)
							{
								IL_33B:
								num2 = 40;
								if (num17 == 0L)
								{
									IL_350:
									num2 = 41;
									num17 = num6;
									IL_357:
									num2 = 42;
									Point3d p3;
									p3..ctor((double)num9, (double)(0L - num6), 0.0);
								}
							}
							else
							{
								IL_37B:
								num2 = 45;
								IL_37E:
								num2 = 46;
								if (num17 != 0L)
								{
									IL_393:
									num2 = 47;
									Point3d p4;
									p4..ctor((double)num9, (double)(0L - (num6 - 1L)), 0.0);
									IL_3BF:
									num2 = 48;
									Point3d p3;
									CAD.AddPoint(p3);
									IL_3C9:
									num2 = 49;
									CAD.AddPoint(p4);
									IL_3D4:
									num2 = 50;
									num17 = 0L;
								}
							}
							IL_3F8:
							num2 = 53;
							num6 += 1L;
						}
						IL_3E4:
						num2 = 54;
						num9 += 1L;
					}
				}
				IL_40E:
				num2 = 55;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_41E:
				num2 = 56;
				documentLock.Dispose();
				IL_428:
				num2 = 57;
				if (Information.Err().Number <= 0)
				{
				}
				IL_43A:
				goto IL_584;
				IL_43F:
				int num21 = num22 + 1;
				num22 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num21);
				IL_53B:
				goto IL_579;
				IL_53D:
				num22 = num2;
				if (num <= -2)
				{
					goto IL_43F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_556:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num22 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_53D;
			}
			IL_579:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_584:
			if (num22 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			int num;
			int num16;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1C:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_30:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_65;
				}
				IL_42:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_57:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_65;
				}
				IL_60:
				goto IL_56F;
				IL_65:
				num2 = 10;
				Point3d[] array = new Point3d[1];
				IL_70:
				num2 = 11;
				Point3d[] array2 = new Point3d[1];
				IL_7A:
				num2 = 12;
				short num4 = 0;
				IL_80:
				num2 = 13;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_99:
				num2 = 14;
				long num5 = 0L;
				long num6 = (long)(checked(bitmap.Width - 1));
				long num7 = num5;
				for (;;)
				{
					long num8 = num7;
					long num9 = num6;
					if (num8 > num9)
					{
						break;
					}
					IL_C0:
					num2 = 15;
					long num10;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num7 * num10)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_FF:
					num2 = 16;
					long num11 = 0L;
					IL_10D:
					num2 = 17;
					Point3d point3d;
					if (Information.UBound(array2, 1) > 0)
					{
						IL_11C:
						num2 = 18;
						array2 = (Point3d[])Utils.CopyArray((Array)array2, new Point3d[checked(Information.UBound(array2, 1) + 1 + 1)]);
						IL_140:
						num2 = 21;
						array2[Information.UBound(array2, 1)] = point3d;
					}
					IL_157:
					num2 = 23;
					num4 = 0;
					IL_15D:
					num2 = 24;
					long num12 = 0L;
					long num13 = (long)(checked(bitmap.Height - 1));
					num10 = num12;
					checked
					{
						for (;;)
						{
							long num14 = num10;
							num9 = num13;
							if (num14 > num9)
							{
								break;
							}
							IL_184:
							num2 = 25;
							Application.DoEvents();
							IL_18C:
							num2 = 26;
							Color pixel = bitmap.GetPixel((int)num7, (int)num10);
							IL_19E:
							num2 = 27;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0) < (double)this.short_0)
							{
								IL_1E7:
								num2 = 28;
								if (num11 == 0L)
								{
									IL_1FC:
									num2 = 29;
									num11 = 1L;
									IL_20A:
									num2 = 30;
									Point3d point3d2;
									point3d2..ctor((double)num7, (double)(0L - num10), 0.0);
									IL_22D:
									num2 = 31;
									if (Information.UBound(array, 1) == 0)
									{
										IL_23D:
										num2 = 32;
										array[0] = point3d2;
										IL_24E:
										num2 = 33;
										array2[0] = point3d2;
										IL_25E:
										num2 = 34;
										array = (Point3d[])Utils.CopyArray((Array)array, new Point3d[2]);
										IL_27A:
										num2 = 37;
										array2 = (Point3d[])Utils.CopyArray((Array)array2, new Point3d[2]);
										IL_294:
										num2 = 40;
										array[1] = point3d2;
										IL_2A5:
										num2 = 41;
										array2[1] = point3d2;
									}
									else
									{
										IL_2B7:
										num2 = 43;
										IL_2BA:
										num2 = 44;
										if (num4 == 0)
										{
											IL_2C4:
											num2 = 45;
											array = (Point3d[])Utils.CopyArray((Array)array, new Point3d[Information.UBound(array, 1) + 1 + 1]);
											IL_2EB:
											num2 = 48;
											array[Information.UBound(array, 1)] = point3d2;
										}
									}
									IL_303:
									num2 = 51;
									num4 += 1;
								}
							}
							else
							{
								IL_30F:
								num2 = 54;
								IL_312:
								num2 = 55;
								if (num11 != 0L)
								{
									IL_327:
									num2 = 56;
									point3d..ctor((double)num7, (double)(0L - (num10 - 1L)), 0.0);
									IL_354:
									num2 = 57;
									num11 = 0L;
								}
							}
							IL_37A:
							num2 = 60;
							num10 += 1L;
						}
						IL_364:
						num2 = 61;
						num7 += 1L;
					}
				}
				IL_390:
				num2 = 62;
				CAD.AddPline(array, 0.0, false, "");
				IL_3AA:
				num2 = 63;
				CAD.AddPline(array2, 0.0, false, "");
				IL_3C3:
				num2 = 64;
				this.Close();
				IL_3CC:
				num2 = 65;
				documentLock.Dispose();
				IL_3D6:
				num2 = 66;
				if (Information.Err().Number <= 0)
				{
					goto IL_3FD;
				}
				IL_3E8:
				num2 = 67;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_3FD:
				goto IL_56F;
				IL_402:
				int num15 = num16 + 1;
				num16 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num15);
				IL_526:
				goto IL_564;
				IL_528:
				num16 = num2;
				if (num <= -2)
				{
					goto IL_402;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_541:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num16 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_528;
			}
			IL_564:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_56F:
			if (num16 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcBmp2Dwg_frm_Load(object sender, EventArgs e)
		{
			this.PictureBox1.Load(Class33.Class31_0.Info.DirectoryPath + "\\images\\logo.bmp");
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			int num;
			int num31;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1B:
				num2 = 3;
				Bitmap bitmap = (Bitmap)this.PictureBox1.Image;
				IL_2E:
				num2 = 4;
				if (bitmap.Width <= 1024)
				{
					goto IL_62;
				}
				IL_3F:
				num2 = 5;
				short num3 = checked((short)Interaction.MsgBox("图像尺寸过大，肯能会消耗过多的系统资源和降低电脑速度，是否继续？", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版"));
				IL_54:
				num2 = 6;
				if (num3 != 2)
				{
					goto IL_62;
				}
				IL_5D:
				goto IL_7BA;
				IL_62:
				num2 = 10;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_7B:
				num2 = 11;
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				IL_85:
				num2 = 12;
				long num4 = 0L;
				long num5 = (long)bitmap.Height;
				long num6 = num4;
				long num9;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_A9:
					num2 = 13;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num9 * num6)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_E6:
					num2 = 14;
					long num10 = 0L;
					IL_F4:
					num2 = 15;
					long num11 = 0L;
					long num12 = (long)bitmap.Width;
					num9 = num11;
					checked
					{
						for (;;)
						{
							long num13 = num9;
							num8 = num12;
							if (num13 > num8)
							{
								break;
							}
							IL_118:
							num2 = 16;
							Application.DoEvents();
							IL_120:
							num2 = 17;
							Color pixel = bitmap.GetPixel((int)num9, (int)num6);
							IL_131:
							num2 = 18;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel.R) + Conversion.Int((short)pixel.G) + Conversion.Int((short)pixel.B))) / 3.0) < (double)this.short_0)
							{
								IL_177:
								num2 = 19;
								if (num10 == 0L)
								{
									IL_18C:
									num2 = 20;
									num10 = num6;
									IL_193:
									num2 = 21;
									Point3d p;
									p..ctor((double)num9, (double)(0L - num6), 0.0);
								}
							}
							else
							{
								IL_1BB:
								num2 = 24;
								IL_1BE:
								num2 = 25;
								if (num10 != 0L)
								{
									IL_1D3:
									num2 = 26;
									Point3d p2;
									p2..ctor((double)(num9 - 1L), (double)(0L - num6), 0.0);
									IL_200:
									num2 = 27;
									Point3d p;
									objectIdCollection.Add(CAD.AddLine(p, p2, "0").ObjectId);
									IL_21E:
									num2 = 28;
									num10 = 0L;
								}
							}
							IL_244:
							num2 = 31;
							num9 += 1L;
						}
						IL_22E:
						num2 = 32;
						num6 += 1L;
					}
				}
				IL_25A:
				num2 = 33;
				long num14 = 0L;
				long num15 = (long)bitmap.Width;
				num9 = num14;
				for (;;)
				{
					long num16 = num9;
					long num8 = num15;
					if (num16 > num8)
					{
						break;
					}
					IL_27E:
					num2 = 34;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num9 * num6)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_2BB:
					num2 = 35;
					long num17 = 0L;
					IL_2C9:
					num2 = 36;
					long num18 = 0L;
					long num19 = (long)bitmap.Height;
					num6 = num18;
					checked
					{
						for (;;)
						{
							long num20 = num6;
							num8 = num19;
							if (num20 > num8)
							{
								break;
							}
							IL_2ED:
							num2 = 37;
							Application.DoEvents();
							IL_2F5:
							num2 = 38;
							Color pixel2 = bitmap.GetPixel((int)num9, (int)num6);
							IL_306:
							num2 = 39;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)pixel2.R) + Conversion.Int((short)pixel2.G) + Conversion.Int((short)pixel2.B))) / 3.0) < (double)this.short_0)
							{
								IL_34C:
								num2 = 40;
								if (num17 == 0L)
								{
									IL_361:
									num2 = 41;
									num17 = num6;
									IL_368:
									num2 = 42;
									Point3d p3;
									p3..ctor((double)num9, (double)(0L - num6), 0.0);
								}
							}
							else
							{
								IL_390:
								num2 = 45;
								IL_393:
								num2 = 46;
								if (num17 != 0L)
								{
									IL_3A8:
									num2 = 47;
									Point3d p4;
									p4..ctor((double)num9, (double)(0L - (num6 - 1L)), 0.0);
									IL_3D5:
									num2 = 48;
									Point3d p3;
									objectIdCollection.Add(CAD.AddLine(p3, p4, "0").ObjectId);
									IL_3F3:
									num2 = 49;
									num17 = 0L;
								}
							}
							IL_419:
							num2 = 52;
							num6 += 1L;
						}
						IL_403:
						num2 = 53;
						num9 += 1L;
					}
				}
				IL_42F:
				num2 = 54;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_43E:
				num2 = 55;
				Database database = mdiActiveDocument.Database;
				IL_44A:
				num2 = 56;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_45D:
				num2 = 57;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num21 = (long)(checked(objectIdCollection.Count - 1));
					long num22 = 0L;
					long num23 = (long)(checked(objectIdCollection.Count - 1));
					long num24 = num22;
					for (;;)
					{
						long num25 = num24;
						long num8 = num23;
						if (num25 > num8)
						{
							break;
						}
						long num26;
						this.Text = Conversions.ToString(Conversion.Int((double)(checked(num24 * num26)) / (double)num21 / (double)num21 * 100.0)) + "%";
						Line line = (Line)transaction.GetObject(objectIdCollection[checked((int)num24)], 1);
						long num27 = 0L;
						long num28 = (long)(checked(objectIdCollection.Count - 1));
						num26 = num27;
						checked
						{
							for (;;)
							{
								long num29 = num26;
								num8 = num28;
								if (num29 > num8)
								{
									break;
								}
								Application.DoEvents();
								if (num24 != num26)
								{
									Line line2 = (Line)transaction.GetObject(objectIdCollection[(int)num24], 1);
									if (line.Angle != line2.Angle)
									{
										Point3d closestPointTo = line.GetClosestPointTo(line2.EndPoint, false);
										if (closestPointTo != line.EndPoint & closestPointTo != line.StartPoint & closestPointTo != line2.StartPoint & closestPointTo != line2.EndPoint)
										{
											line2.Erase();
										}
										closestPointTo = line2.GetClosestPointTo(line.EndPoint, false);
										if (closestPointTo != line.EndPoint & closestPointTo != line.StartPoint & closestPointTo != line2.StartPoint & closestPointTo != line2.EndPoint)
										{
											line.Erase();
										}
									}
								}
								num26 += 1L;
							}
							num24 += 1L;
						}
					}
				}
				IL_635:
				num2 = 59;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_645:
				num2 = 60;
				documentLock.Dispose();
				IL_64E:
				num2 = 61;
				if (Information.Err().Number <= 0)
				{
				}
				IL_660:
				goto IL_7BA;
				IL_665:
				int num30 = num31 + 1;
				num31 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num30);
				IL_771:
				goto IL_7AF;
				IL_773:
				num31 = num2;
				if (num <= -2)
				{
					goto IL_665;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_78C:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num31 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_773;
			}
			IL_7AF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_7BA:
			if (num31 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			int num;
			int num14;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Bitmap bitmap = (Bitmap)Image.FromFile(this.TextBox1.Text);
				IL_22:
				num2 = 3;
				Bitmap bitmap2 = bitmap;
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				BitmapData bitmapData = bitmap2.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
				IL_4C:
				num2 = 4;
				this.short_0 = Convert.ToInt16(this.NumericUpDown1.Value);
				IL_64:
				num2 = 5;
				int num3 = Math.Abs(bitmapData.Stride);
				IL_74:
				num2 = 6;
				IntPtr scan = bitmapData.Scan0;
				IL_7E:
				num2 = 7;
				long num4 = 0L;
				long num5 = (long)(checked(bitmap.Width - 1));
				long num6 = num4;
				for (;;)
				{
					long num7 = num6;
					long num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_A4:
					num2 = 8;
					long num9;
					this.Text = Conversions.ToString(Conversion.Int((double)(checked(num6 * num9)) / (double)bitmap.Width / (double)bitmap.Height * 100.0)) + "%";
					IL_E2:
					num2 = 9;
					long num10 = 0L;
					long num11 = (long)(checked(bitmap.Height - 1));
					num9 = num10;
					checked
					{
						for (;;)
						{
							long num12 = num9;
							num8 = num11;
							if (num12 > num8)
							{
								break;
							}
							IL_109:
							num2 = 10;
							int ofs = (int)(num9 * unchecked((long)num3) + num6 * 4L);
							IL_122:
							num2 = 11;
							int argb = Marshal.ReadInt32(scan, ofs);
							IL_12F:
							num2 = 12;
							Color color = Color.FromArgb(argb);
							IL_13B:
							num2 = 13;
							if (Conversion.Int((double)(unchecked(Conversion.Int((short)color.R) + Conversion.Int((short)color.G) + Conversion.Int((short)color.B))) / 3.0) > (double)this.short_0)
							{
								IL_181:
								num2 = 14;
								Marshal.WriteInt32(scan, ofs, Color.White.ToArgb());
							}
							else
							{
								IL_19C:
								num2 = 16;
								IL_19F:
								num2 = 17;
								Marshal.WriteInt32(scan, ofs, Color.Black.ToArgb());
							}
							IL_1D0:
							num2 = 19;
							num9 += 1L;
						}
						IL_1BA:
						num2 = 20;
						num6 += 1L;
					}
				}
				IL_1E6:
				num2 = 21;
				bitmap.UnlockBits(bitmapData);
				IL_1F2:
				num2 = 22;
				this.PictureBox1.Image = bitmap;
				IL_202:
				num2 = 23;
				Interaction.MsgBox("绘图完成", MsgBoxStyle.OkOnly, null);
				IL_212:
				num2 = 24;
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				IL_21B:
				num2 = 25;
				saveFileDialog.Filter = "透明PNG(*.png)|*.png|透明BMP(*.bmp)|*.bmp";
				IL_229:
				num2 = 26;
				saveFileDialog.FilterIndex = 1;
				IL_233:
				num2 = 27;
				saveFileDialog.FileName = "未命名";
				IL_241:
				num2 = 28;
				saveFileDialog.RestoreDirectory = true;
				IL_24B:
				num2 = 29;
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					goto IL_2A8;
				}
				IL_259:
				num2 = 30;
				if (saveFileDialog.FilterIndex != 1)
				{
					goto IL_287;
				}
				IL_267:
				num2 = 31;
				this.PictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
				goto IL_2A8;
				IL_287:
				num2 = 33;
				IL_28A:
				num2 = 34;
				this.PictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Bmp);
				IL_2A8:
				num2 = 37;
				if (Information.Err().Number <= 0)
				{
					goto IL_2CF;
				}
				IL_2BA:
				num2 = 38;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_2CF:
				goto IL_3CD;
				IL_2D4:
				int num13 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num13);
				IL_384:
				goto IL_3C2;
				IL_386:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_2D4;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_39F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_386;
			}
			IL_3C2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3CD:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("OpenFileDialog1")]
		private OpenFileDialog openFileDialog_0;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("NumericUpDown1")]
		private NumericUpDown _NumericUpDown1;

		[AccessedThroughProperty("Button8")]
		private Button _Button8;

		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		[AccessedThroughProperty("Button9")]
		private Button _Button9;

		[AccessedThroughProperty("Button10")]
		private Button _Button10;

		private short short_0;

		public struct PointRGB
		{
			public long X;

			public long Y;

			public long C;
		}

		public struct PointXY
		{
			public long X;

			public long Y;
		}
	}
}
