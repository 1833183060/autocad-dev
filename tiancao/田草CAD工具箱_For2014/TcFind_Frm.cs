using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcFind_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcFind_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcFind_Frm.list_0 = new List<WeakReference>();
		}

		public TcFind_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.FormClosing += this.TcFind_Frm_FormClosing;
			base.Load += this.TcFind_Frm_Load;
			TcFind_Frm.smethod_0(this);
			this.document_0 = Application.DocumentManager.MdiActiveDocument;
			this.database_0 = this.document_0.Database;
			this.editor_0 = this.document_0.Editor;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcFind_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcFind_Frm.list_0.Count == TcFind_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcFind_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcFind_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcFind_Frm.list_0[num] = TcFind_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcFind_Frm.list_0.RemoveRange(num, TcFind_Frm.list_0.Count - num);
						TcFind_Frm.list_0.Capacity = TcFind_Frm.list_0.Count;
					}
					TcFind_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				EventHandler value2 = new EventHandler(this.RadioButton1_CheckedChanged);
				if (this._RadioButton1 != null)
				{
					this._RadioButton1.CheckedChanged -= value2;
				}
				this._RadioButton1 = value;
				if (this._RadioButton1 != null)
				{
					this._RadioButton1.CheckedChanged += value2;
				}
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
				EventHandler value2 = new EventHandler(this.RadioButton2_Click);
				if (this._RadioButton2 != null)
				{
					this._RadioButton2.Click -= value2;
				}
				this._RadioButton2 = value;
				if (this._RadioButton2 != null)
				{
					this._RadioButton2.Click += value2;
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
				EventHandler value2 = new EventHandler(this.TextBox1_TextChanged);
				if (this._TextBox1 != null)
				{
					this._TextBox1.TextChanged -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.TextChanged += value2;
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
				this._TextBox2 = value;
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
				EventHandler value2 = new EventHandler(this.jipAtgRsh);
				if (this._Label4 != null)
				{
					this._Label4.Click -= value2;
				}
				this._Label4 = value;
				if (this._Label4 != null)
				{
					this._Label4.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label5_Click);
				if (this._Label5 != null)
				{
					this._Label5.Click -= value2;
				}
				this._Label5 = value;
				if (this._Label5 != null)
				{
					this._Label5.Click += value2;
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
				EventHandler value2 = new EventHandler(this.Label6_Click);
				if (this._Label6 != null)
				{
					this._Label6.Click -= value2;
				}
				this._Label6 = value;
				if (this._Label6 != null)
				{
					this._Label6.Click += value2;
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
				EventHandler value2 = new EventHandler(this.Label7_Click);
				if (this._Label7 != null)
				{
					this._Label7.Click -= value2;
				}
				this._Label7 = value;
				if (this._Label7 != null)
				{
					this._Label7.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label8_Click);
				if (this._Label8 != null)
				{
					this._Label8.Click -= value2;
				}
				this._Label8 = value;
				if (this._Label8 != null)
				{
					this._Label8.Click += value2;
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
				EventHandler value2 = new EventHandler(this.Label9_Click);
				if (this._Label9 != null)
				{
					this._Label9.Click -= value2;
				}
				this._Label9 = value;
				if (this._Label9 != null)
				{
					this._Label9.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label10_Click);
				if (this._Label10 != null)
				{
					this._Label10.Click -= value2;
				}
				this._Label10 = value;
				if (this._Label10 != null)
				{
					this._Label10.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label11_Click);
				if (this._Label11 != null)
				{
					this._Label11.Click -= value2;
				}
				this._Label11 = value;
				if (this._Label11 != null)
				{
					this._Label11.Click += value2;
				}
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
				this._CheckBox1 = value;
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
				EventHandler value2 = new EventHandler(this.Label12_Click);
				if (this._Label12 != null)
				{
					this._Label12.Click -= value2;
				}
				this._Label12 = value;
				if (this._Label12 != null)
				{
					this._Label12.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label13_Click);
				if (this._Label13 != null)
				{
					this._Label13.Click -= value2;
				}
				this._Label13 = value;
				if (this._Label13 != null)
				{
					this._Label13.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label14_Click);
				if (this._Label14 != null)
				{
					this._Label14.Click -= value2;
				}
				this._Label14 = value;
				if (this._Label14 != null)
				{
					this._Label14.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Label15_Click);
				if (this._Label15 != null)
				{
					this._Label15.Click -= value2;
				}
				this._Label15 = value;
				if (this._Label15 != null)
				{
					this._Label15.Click += value2;
				}
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

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcFind_Frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			int num;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_FindFrm", "Text_1", this.TextBox1.Text);
				IL_34:
				num2 = 3;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_FindFrm", "Text_2", this.TextBox2.Text);
				IL_5F:
				num2 = 4;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_71:
				num2 = 5;
				Class36.smethod_64(this.entity_0.ObjectId);
				IL_84:
				num2 = 6;
				documentLock.Dispose();
				IL_8C:
				goto IL_FC;
				IL_8E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_B8:
				goto IL_F1;
				IL_BA:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_8E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_CF:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_BA;
			}
			IL_F1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_FC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcFind_Frm_Load(object sender, EventArgs e)
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
				TypedValue[] array = new TypedValue[1];
				IL_12:
				num2 = 3;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "TEXT");
				array2.SetValue(typedValue, 0);
				IL_2F:
				num2 = 4;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_39:
				num2 = 5;
				PromptSelectionResult promptSelectionResult = this.document_0.Editor.SelectAll(selectionFilter);
				IL_4F:
				num2 = 6;
				if (promptSelectionResult.Status != 5100)
				{
					goto IL_D0;
				}
				IL_61:
				num2 = 7;
				this.selectionSet_0 = promptSelectionResult.Value;
				IL_70:
				num2 = 8;
				this.long_0 = (long)this.selectionSet_0.Count;
				IL_84:
				num2 = 9;
				if (this.long_0 != 0L)
				{
					goto IL_AA;
				}
				IL_9A:
				num2 = 10;
				Class36.smethod_60("文档中没有任何文字对象");
				goto IL_D0;
				IL_AA:
				num2 = 12;
				IL_AD:
				num2 = 13;
				Class36.smethod_60("文档中总共有" + this.long_0.ToString() + "个文字对象");
				IL_D0:
				num2 = 16;
				this.Focus();
				IL_DA:
				num2 = 17;
				this.TextBox1.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_FindFrm", "Text_1", "");
				IL_10B:
				num2 = 18;
				this.TextBox2.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_FindFrm", "Text_2", "");
				IL_13C:
				goto IL_1DE;
				IL_141:
				goto IL_1E8;
				IL_146:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_15D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_1B9;
				IL_15D:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_1B9:
				goto IL_1E8;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_146;
			}
			IL_1DE:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_1E8:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button1_Click(object sender, EventArgs e)
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
				this.document_0.SendStringToExecute("\u0003\u0003", false, false, false);
				IL_1E:
				num2 = 3;
				if (Operators.CompareString(this.TextBox1.Text, "", false) != 0)
				{
					goto IL_4E;
				}
				IL_3B:
				num2 = 4;
				this.TextBox1.Focus();
				IL_49:
				goto IL_6EB;
				IL_4E:
				num2 = 7;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_60:
				num2 = 8;
				long num3 = (long)this.int_0;
				string textString;
				long num7;
				Point3d maxPoint;
				Point3d minPoint;
				Polyline polyline;
				Polyline polyline2;
				int num8;
				checked
				{
					long num4 = this.long_0 - 1L;
					this.long_1 = num3;
					DBText dbtext;
					for (;;)
					{
						long num5 = this.long_1;
						long num6 = num4;
						if (num5 <= num6)
						{
							IL_90:
							num2 = 9;
							using (Transaction transaction = this.database_0.TransactionManager.StartTransaction())
							{
								dbtext = (DBText)transaction.GetObject(this.selectionSet_0[(int)this.long_1].ObjectId, 1);
								textString = dbtext.TextString;
								goto IL_118;
							}
							IL_E8:
							num2 = 12;
							if (num7 <= 0L)
							{
								IL_FA:
								num2 = 44;
								this.long_1 += 1L;
								continue;
							}
							break;
							IL_118:
							num2 = 11;
							num7 = unchecked((long)Strings.InStr(textString, this.TextBox1.Text, CompareMethod.Binary));
							goto IL_E8;
						}
						goto IL_4F2;
					}
					IL_133:
					num2 = 13;
					maxPoint = dbtext.GeometricExtents.MaxPoint;
					IL_148:
					num2 = 14;
					minPoint = dbtext.GeometricExtents.MinPoint;
					IL_15D:
					num2 = 15;
					Class36.smethod_64(this.entity_0.ObjectId);
					IL_171:
					num2 = 16;
					polyline = new Polyline();
					IL_17B:
					num2 = 17;
					polyline.SetDatabaseDefaults();
					IL_185:
					num2 = 18;
					polyline2 = polyline;
					num8 = 0;
				}
				Point2d point2d;
				point2d..ctor(minPoint.X - 100.0, minPoint.Y - 100.0);
				polyline2.AddVertexAt(num8, point2d, 0.0, 20.0, 20.0);
				IL_1D6:
				num2 = 19;
				Polyline polyline3 = polyline;
				int num9 = 1;
				point2d..ctor(minPoint.X - 100.0, maxPoint.Y + 100.0);
				polyline3.AddVertexAt(num9, point2d, 0.0, 20.0, 20.0);
				IL_227:
				num2 = 20;
				Polyline polyline4 = polyline;
				int num10 = 2;
				point2d..ctor(maxPoint.X + 100.0, maxPoint.Y + 100.0);
				polyline4.AddVertexAt(num10, point2d, 0.0, 20.0, 20.0);
				IL_278:
				num2 = 21;
				Polyline polyline5 = polyline;
				int num11 = 3;
				point2d..ctor(maxPoint.X + 100.0, minPoint.Y - 100.0);
				polyline5.AddVertexAt(num11, point2d, 0.0, 20.0, 20.0);
				IL_2C9:
				num2 = 22;
				polyline.Closed = true;
				IL_2D4:
				num2 = 23;
				polyline.ColorIndex = 10;
				IL_2E0:
				num2 = 24;
				this.entity_0 = CAD.AddEnt(polyline);
				IL_2F0:
				num2 = 25;
				object systemVariable = Application.GetSystemVariable("TARGET");
				Point3d point3d2;
				Point3d point3d = (systemVariable != null) ? ((Point3d)systemVariable) : point3d2;
				IL_311:
				num2 = 26;
				maxPoint..ctor(maxPoint.X - point3d.X, maxPoint.Y - point3d.Y, maxPoint.Z - point3d.Z);
				IL_348:
				num2 = 27;
				minPoint..ctor(minPoint.X - point3d.X, minPoint.Y - point3d.Y, minPoint.Z - point3d.Z);
				IL_37F:
				num2 = 28;
				long val;
				long val2;
				ViewTableRecord currentView;
				AbstractViewTableRecord abstractViewTableRecord;
				checked
				{
					val = (long)Math.Round(unchecked(maxPoint.get_Coordinate(1) - minPoint.get_Coordinate(1)));
					IL_39B:
					num2 = 29;
					val2 = (long)Math.Round(unchecked(maxPoint.get_Coordinate(0) - minPoint.get_Coordinate(0)));
					IL_3B7:
					num2 = 30;
					currentView = this.editor_0.GetCurrentView();
					IL_3C7:
					num2 = 31;
					abstractViewTableRecord = currentView;
				}
				point2d..ctor((maxPoint.get_Coordinate(0) + minPoint.get_Coordinate(0)) / 2.0, (minPoint.get_Coordinate(1) + maxPoint.get_Coordinate(1)) / 2.0);
				abstractViewTableRecord.CenterPoint = point2d;
				IL_410:
				num2 = 32;
				object left = Math.Max(val2, val);
				IL_423:
				num2 = 33;
				currentView.Height = Conversions.ToDouble(Operators.MultiplyObject(left, 2));
				IL_43F:
				num2 = 34;
				currentView.Width = Conversions.ToDouble(Operators.MultiplyObject(left, 2));
				IL_45B:
				num2 = 35;
				this.editor_0.SetCurrentView(currentView);
				IL_46B:
				num2 = 36;
				Class36.smethod_60(Conversion.Str(num7));
				IL_480:
				num2 = 37;
				this.TextBox3.Text = textString;
				IL_490:
				num2 = 38;
				checked
				{
					this.TextBox3.SelectionStart = (int)(num7 - 1L);
					IL_4AB:
					num2 = 39;
					this.TextBox3.SelectionLength = Strings.Len(this.TextBox1.Text);
					IL_4C9:
					num2 = 40;
					this.TextBox3.Focus();
					IL_4D8:
					num2 = 41;
					this.int_0 = (int)(this.long_1 + 1L);
					IL_4F2:
					num2 = 45;
					if (!(this.long_0 == 0L | this.long_1 >= this.long_0 - 1L))
					{
						goto IL_57D;
					}
					IL_524:
					num2 = 46;
					this.Button1.Enabled = false;
					IL_533:
					num2 = 47;
					this.TextBox3.Text = "查无内容。";
					IL_546:
					num2 = 48;
					this.Button1.Enabled = false;
					IL_555:
					num2 = 49;
					this.Button2.Enabled = false;
					IL_564:
					num2 = 50;
					this.Button3.Enabled = false;
					IL_573:
					num2 = 51;
					this.int_0 = 0;
					IL_57D:
					num2 = 53;
					documentLock.Dispose();
					IL_586:
					num2 = 54;
					if (Information.Err().Number <= 0)
					{
						goto IL_5AD;
					}
					IL_598:
					num2 = 55;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_5AD:
					goto IL_6EB;
					IL_5B2:;
				}
				int num12 = num13 + 1;
				num13 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num12);
				IL_6A2:
				goto IL_6E0;
				IL_6A4:
				num13 = num2;
				if (num <= -2)
				{
					goto IL_5B2;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_6BD:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num13 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_6A4;
			}
			IL_6E0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_6EB:
			if (num13 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("\u0003\u0003", false, false, false);
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				DBText dbtext = (DBText)transaction.GetObject(this.selectionSet_0[checked((int)this.long_1)].ObjectId, 1);
				dbtext.TextString = dbtext.TextString.Replace(this.TextBox1.Text, this.TextBox2.Text);
				transaction.Commit();
			}
			database.Regenmode = true;
			documentLock.Dispose();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("\u0003\u0003", false, false, false);
			Database database = mdiActiveDocument.Database;
			long value = 0L;
			this.ListBox1.Items.Clear();
			if (this.CheckBox1.Checked)
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					try
					{
						foreach (ObjectId objectId in blockTable)
						{
							BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(objectId, 1);
							try
							{
								foreach (ObjectId objectId2 in blockTableRecord2)
								{
									if (Operators.CompareString(Class36.amIrsvPmtO(objectId2), "DBText", false) == 0)
									{
										DBText dbtext = (DBText)transaction.GetObject(objectId2, 1);
										string textString = dbtext.TextString;
										string text = textString.Replace(this.TextBox1.Text, this.TextBox2.Text);
										if (Operators.CompareString(textString, text, false) != 0)
										{
											dbtext.TextString = text;
											Interlocked.Increment(ref value);
											this.ListBox1.Items.Add(string.Concat(new string[]
											{
												Conversions.ToString(value),
												"    ",
												textString,
												"   ",
												text
											}));
										}
									}
								}
							}
							finally
							{
								BlockTableRecordEnumerator enumerator2;
								if (enumerator2 != null)
								{
									enumerator2.Dispose();
								}
							}
						}
					}
					finally
					{
						SymbolTableEnumerator enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					transaction.Commit();
					goto IL_339;
				}
			}
			checked
			{
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					long num = 0L;
					long num2 = this.long_0 - 1L;
					this.long_1 = num;
					for (;;)
					{
						long num3 = this.long_1;
						long num4 = num2;
						if (num3 > num4)
						{
							break;
						}
						DBText dbtext2 = (DBText)transaction2.GetObject(this.selectionSet_0[(int)this.long_1].ObjectId, 1);
						string textString2 = dbtext2.TextString;
						string text2 = textString2.Replace(this.TextBox1.Text, this.TextBox2.Text);
						if (Operators.CompareString(textString2, text2, false) != 0)
						{
							dbtext2.TextString = text2;
							Interlocked.Increment(ref value);
							this.ListBox1.Items.Add(string.Concat(new string[]
							{
								Conversions.ToString(value),
								"    ",
								textString2,
								"   ",
								text2
							}));
						}
						this.long_1 += 1L;
					}
					transaction2.Commit();
				}
				IL_339:
				database.Regenmode = true;
				documentLock.Dispose();
				this.Label3.Text = Conversions.ToString(value) + "个替换完毕";
				this.Button3.Enabled = false;
				this.Button2.Enabled = false;
			}
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.Button1.Enabled = true;
			this.Button2.Enabled = true;
			this.Button3.Enabled = true;
			this.Label3.Text = "";
			this.int_0 = 0;
		}

		private void RadioButton2_Click(object sender, EventArgs e)
		{
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "TEXT");
			array2.SetValue(typedValue, 0);
			SelectionFilter selectionFilter = new SelectionFilter(array);
			this.RadioButton2.Checked = true;
			this.Hide();
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			PromptSelectionResult selection = this.document_0.Editor.GetSelection(selectionFilter);
			if (selection.Status == 5100)
			{
				this.selectionSet_0 = selection.Value;
				this.long_0 = (long)this.selectionSet_0.Count;
				if (this.long_0 == 0L)
				{
					Class36.smethod_60("没有选择任何文字对象\r\n");
				}
				else
				{
					Class36.smethod_60("当前选择集体" + this.long_0.ToString() + "个文字对象\r\n");
				}
				this.Show();
			}
			this.Button1.Enabled = true;
			this.Button2.Enabled = true;
			this.Button3.Enabled = true;
			this.Label3.Text = "";
		}

		private void RadioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.Button1.Enabled = true;
			this.Button2.Enabled = true;
			this.Button3.Enabled = true;
			this.Label3.Text = "";
		}

		private void jipAtgRsh(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%130";
		}

		private void Label5_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%131";
		}

		private void Label6_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%132";
		}

		private void Label7_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%133";
		}

		private void Label11_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%130";
		}

		private void Label10_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%131";
		}

		private void Label9_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%132";
		}

		private void Label8_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "";
			this.TextBox2.Text = "%%133";
		}

		private void Label12_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "\u0082";
			this.TextBox2.Text = "%%130";
		}

		private void Label13_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "\u0083";
			this.TextBox2.Text = "%%131";
		}

		private void Label14_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "\u0084";
			this.TextBox2.Text = "%%132";
		}

		private void Label15_Click(object sender, EventArgs e)
		{
			this.TextBox1.Text = "\u0085";
			this.TextBox2.Text = "%%133";
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		private int int_0;

		private long long_0;

		private long long_1;

		private Entity entity_0;

		private SelectionSet selectionSet_0;

		private Document document_0;

		private Database database_0;

		private Editor editor_0;
	}
}
