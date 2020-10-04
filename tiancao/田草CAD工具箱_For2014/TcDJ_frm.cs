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
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcDJ_frm : Form
	{
		[DebuggerNonUserCode]
		static TcDJ_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcDJ_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcDJ_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.FormClosed += this.TcDJ_frm_FormClosed;
			base.Load += this.TcDJ_frm_Load;
			TcDJ_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcDJ_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcDJ_frm.list_0.Count == TcDJ_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcDJ_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcDJ_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcDJ_frm.list_0[num] = TcDJ_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcDJ_frm.list_0.RemoveRange(num, TcDJ_frm.list_0.Count - num);
						TcDJ_frm.list_0.Capacity = TcDJ_frm.list_0.Count;
					}
					TcDJ_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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

		internal virtual GroupBox GroupBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox2 = value;
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

		internal virtual GroupBox GroupBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox3 = value;
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

		internal virtual GroupBox GroupBox4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox4 = value;
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
				this._TextBox6 = value;
			}
		}

		internal virtual GroupBox GroupBox5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox5 = value;
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

		internal virtual GroupBox GroupBox6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox6 = value;
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
				this.textBox_1 = value;
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

		internal virtual ToolTip ToolTip1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.toolTip_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.toolTip_0 = value;
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

		private void method_0(object sender, EventArgs e)
		{
			Interaction.MsgBox("绘图需要在AutoCAD中运行插件！", MsgBoxStyle.OkOnly, null);
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.CheckBox1.Checked)
			{
				this.TextBox1.Text = Conversions.ToString(450);
			}
			else
			{
				this.TextBox1.Text = "450x450";
			}
		}

		private void TcDJ_frm_FormClosed(object sender, FormClosedEventArgs e)
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
				this.SaveData();
				IL_11:
				goto IL_6A;
				IL_13:
				goto IL_74;
				IL_15:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_2C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_48;
				IL_2C:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_48:
				goto IL_74;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_15;
			}
			IL_6A:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_74:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void TcDJ_frm_Load(object sender, EventArgs e)
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
				JG.AddDataToComboBox(this.ComboBox1, "GJ", "HRB335");
				IL_21:
				num2 = 3;
				JG.AddDataToComboBox(this.ComboBox2, "HNT", "C30");
				IL_39:
				num2 = 4;
				this.ReadData();
				IL_41:
				num2 = 5;
				this.ToolTip1.SetToolTip(this.TextBox_3, "修改埋深，你可能需要修改修正后的承载力！");
				IL_59:
				goto IL_BE;
				IL_5B:
				goto IL_C8;
				IL_5D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_74;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_9C;
				IL_74:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_9C:
				goto IL_C8;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_5D;
			}
			IL_BE:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_C8:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void ReadData()
		{
			int num;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				ArrayList arrayList = new ArrayList();
				IL_11:
				num2 = 3;
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				IL_24:
				num2 = 4;
				NF.ReadTxtFile(directoryPath + "\\DJ_Data.txt", ref arrayList);
				IL_3A:
				num2 = 5;
				if (!Operators.ConditionalCompareObjectEqual(arrayList[0], "False", false))
				{
					goto IL_60;
				}
				IL_50:
				num2 = 6;
				this.CheckBox1.Checked = false;
				goto IL_71;
				IL_60:
				num2 = 8;
				IL_62:
				num2 = 9;
				this.CheckBox1.Checked = true;
				IL_71:
				num2 = 11;
				short num3 = 1;
				IL_77:
				num2 = 12;
				IEnumerator enumerator = this.Controls.GetEnumerator();
				checked
				{
					while (enumerator.MoveNext())
					{
						Control control = (Control)enumerator.Current;
						IL_A1:
						num2 = 13;
						string left = control.Name.Substring(0, 3);
						IL_B4:
						num2 = 14;
						if (Operators.CompareString(left, "Gro", false) == 0)
						{
							IL_CC:
							num2 = 15;
							IEnumerator enumerator2 = control.Controls.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								Control control2 = (Control)enumerator2.Current;
								IL_F4:
								num2 = 16;
								left = control2.Name.Substring(0, 3);
								IL_107:
								num2 = 17;
								if (Operators.CompareString(left, "Tex", false) == 0 | Operators.CompareString(left, "Txt", false) == 0 | Operators.CompareString(left, "UpD", false) == 0 | Operators.CompareString(left, "Com", false) == 0)
								{
									IL_14F:
									num2 = 18;
									control2.Text = Conversions.ToString(arrayList[(int)num3]);
									IL_166:
									num2 = 19;
									num3 += 1;
								}
								IL_193:
								num2 = 21;
							}
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						IL_18B:
						num2 = 23;
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					IL_1B6:
					goto IL_271;
					IL_1BB:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_22B:
				goto IL_266;
				IL_22D:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_1BB;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_243:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_22D;
			}
			IL_266:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_271:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void SaveData()
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
				ArrayList arrayList = new ArrayList();
				IL_11:
				num2 = 3;
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				IL_24:
				num2 = 4;
				arrayList.Add(this.CheckBox1.Checked.ToString());
				IL_41:
				num2 = 5;
				IEnumerator enumerator = this.Controls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Control control = (Control)enumerator.Current;
					IL_67:
					num2 = 6;
					string left = control.Name.Substring(0, 3);
					IL_79:
					num2 = 7;
					if (Operators.CompareString(left, "Gro", false) == 0)
					{
						IL_90:
						num2 = 8;
						IEnumerator enumerator2 = control.Controls.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							Control control2 = (Control)enumerator2.Current;
							IL_B7:
							num2 = 9;
							left = control2.Name.Substring(0, 3);
							IL_CA:
							num2 = 10;
							if (Operators.CompareString(left, "Tex", false) == 0 | Operators.CompareString(left, "Txt", false) == 0 | Operators.CompareString(left, "UpD", false) == 0 | Operators.CompareString(left, "Com", false) == 0)
							{
								IL_112:
								num2 = 11;
								arrayList.Add(control2.Text);
							}
							IL_148:
							num2 = 13;
						}
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					IL_140:
					num2 = 15;
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_169:
				num2 = 16;
				NF.SaveTxtFile(directoryPath + "\\DJ_Data.txt", arrayList);
				IL_17F:
				goto IL_21E;
				IL_184:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1D8:
				goto IL_213;
				IL_1DA:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_184;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1F0:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1DA;
			}
			IL_213:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21E:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public string StrXStr(string Str, string SplitStr)
		{
			string str = "";
			string text = "";
			bool flag = false;
			short num = 0;
			short num2 = checked((short)(Str.Length - 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				string text2 = Str.Substring((int)num3, 1);
				if (Versioned.IsNumeric(text2) & !flag)
				{
					str += text2;
				}
				else if (Versioned.IsNumeric(text2) && flag)
				{
					text += text2;
				}
				else
				{
					flag = true;
				}
				num3 += 1;
			}
			return str + SplitStr + text;
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button2_Click(object sender, EventArgs e)
		{
			double num = 1.05;
			short num2 = Conversions.ToShort(this.TextBox_1.Text);
			long num3 = Conversions.ToLong(this.TextBox_0.Text);
			long num4 = Conversions.ToLong(this.TextBox_2.Text);
			double num5 = Conversion.Val(this.TextBox_3.Text);
			double hnt_QiangDuFc = JG.GetHNT_QiangDuFc(this.ComboBox2.Text);
			double num6 = (double)JG.GetFy(this.ComboBox1.Text);
			double num7 = Conversion.Val(this.TextBox_4.Text);
			string text = this.TextBox1.Text;
			text = this.StrXStr(text, "X");
			double num8;
			double num9;
			if (!this.CheckBox1.Checked)
			{
				num8 = Conversions.ToDouble(text.Split(new char[]
				{
					'X'
				})[0]);
				num9 = Conversions.ToDouble(text.Split(new char[]
				{
					'X'
				})[1]);
			}
			else
			{
				if (!this.CheckBox1.Checked)
				{
					Interaction.MsgBox("柱截面输入有误！", MsgBoxStyle.OkOnly, null);
					return;
				}
				num8 = Conversions.ToDouble(text.Split(new char[]
				{
					'X'
				})[0]);
				num9 = num8;
			}
			string str;
			ArrayList arrayList;
			double num10;
			double num11;
			double num12;
			double num13;
			double num15;
			double num16;
			double num17;
			double num18;
			double num19;
			double num20;
			double num22;
			double num23;
			for (;;)
			{
				str = "独立基础截面设计和配筋计算.txt";
				arrayList = new ArrayList();
				arrayList.Add("                            独立基础截面设计和配筋计算                                    ");
				arrayList.Add("\r\n");
				arrayList.Add("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
				arrayList.Add("一、 设计依据");
				arrayList.Add("\r");
				arrayList.Add("   《混凝土结构设计规范》GB 50010-2010");
				arrayList.Add("   《建筑地基基础设计规范》GB 50007-2011");
				arrayList.Add("\r");
				arrayList.Add("二 、已知条件");
				arrayList.Add("\r");
				arrayList.Add("   修正后地基承载力:   fa= " + Conversions.ToString((int)num2) + " Kpa");
				arrayList.Add(string.Concat(new string[]
				{
					"   荷载标准值:         Nk= ",
					Conversions.ToString(num4),
					" KN  弯矩: Mk= ",
					Conversions.ToString(num3),
					" KN*m"
				}));
				arrayList.Add("   基础埋深:           d=" + Conversions.ToString(num5) + "m");
				arrayList.Add(string.Concat(new string[]
				{
					"   混凝土强度:         fc= ",
					Conversions.ToString(hnt_QiangDuFc),
					" N/mm^2  (",
					this.ComboBox2.Text,
					")"
				}));
				arrayList.Add(string.Concat(new string[]
				{
					"   钢筋强度:           fy= ",
					Conversions.ToString(num6),
					" N/mm^2   (",
					this.ComboBox1.Text,
					")"
				}));
				arrayList.Add("   基础长宽比:         B/L= " + Conversions.ToString(num7));
				arrayList.Add("   柱子截面:           " + Conversions.ToString(num8) + "x" + Conversions.ToString(num9));
				if (num3 != 0L)
				{
					arrayList.Add("\r");
					arrayList.Add("   按不出现零应力区设计基础底面积");
				}
				arrayList.Add("\r");
				arrayList.Add("三 、设计过程");
				arrayList.Add("\r");
				if ((double)num2 - 20.0 * num5 == 0.0)
				{
					num10 = (double)num4 / 10.0 * num;
				}
				else
				{
					num10 = (double)num4 / ((double)num2 - 20.0 * num5) * num;
					if (num10 < 0.0)
					{
						break;
					}
				}
				num11 = Math.Ceiling(Math.Sqrt(num10 / num7) * 10.0) * 100.0;
				num12 = Math.Ceiling(Math.Sqrt(num10 / num7) * num7 * 10.0) * 100.0;
				num10 = num12 * num11 / 1000000.0;
				num = num10 / ((double)num4 / ((double)num2 - 20.0 * num5));
				this.TextBox7.Text = num12.ToString() + "x" + num11.ToString();
				arrayList.Add("   长宽比:             B/L= " + Conversions.ToString(num7));
				arrayList.Add("   基础底面调整系数:   " + this.D2S(num));
				arrayList.Add(string.Concat(new string[]
				{
					"   基础底面积:         A= Nk/(Fa-20*D)*",
					this.D2S(num),
					"= ",
					Conversions.ToString(num10),
					" m^2"
				}));
				arrayList.Add("   底面宽度(y):        L= Math.Sqrt(A/Bi) = " + Conversions.ToString(num11) + " mm");
				arrayList.Add("   底面长度(x):        B= L*Bi = " + Conversions.ToString(num12) + " mm");
				arrayList.Add("\r");
				num13 = (num12 - num8) / 2.0;
				double num14 = (num11 - num9) / 2.0;
				arrayList.Add("   柱截面长:           b= " + Conversions.ToString(num8) + " mm");
				arrayList.Add("   柱截面宽:           l= " + Conversions.ToString(num9) + " mm");
				arrayList.Add("   底板净悬挑长度（x)  BL= " + Conversions.ToString(num13) + " mm");
				arrayList.Add("   底板净悬挑长度（y)  LL= " + Conversions.ToString(num14) + " mm");
				checked
				{
					num15 = (double)Math.Max(((long)Math.Round(Math.Max(num13, num14) / 2.5) / 50L + 2L) * 50L, 300L);
					num16 = (double)((long)Math.Round(num15 / 3.0) / 50L * 50L);
					num17 = (double)Math.Max((long)Math.Round(num15 / 2.5) / 50L * 50L, 300L);
					arrayList.Add("   基础最长边:         Lmax= " + Conversions.ToString(Math.Max(num11, num12)) + " mm");
					arrayList.Add("   基础根部高度:       H=Math.Max(((Lmax/2/2.5)\\50)*50,300)= " + Conversions.ToString(num15) + " mm");
					arrayList.Add("   第一阶高度:         H1=Math.Max(((H/2.5)\\50)*50,300)= " + Conversions.ToString(num17) + " mm");
				}
				num17 = Math.Max(num15 - num16, 300.0);
				arrayList.Add("   第一阶高度:         H1=Math.Max(H-H2,300)= " + Conversions.ToString(num17) + " mm");
				num16 = Math.Max(num15 - num17, 0.0);
				arrayList.Add("   第二阶高度:         H2=H-H1=" + Conversions.ToString(num16) + " mm");
				this.TextBox2.Text = num17.ToString() + "+" + num16.ToString();
				arrayList.Add("\r");
				num18 = num11 * Math.Pow(num12, 2.0) / 6.0 / 1000000000.0;
				num19 = 20.0 * num5 * num10;
				num20 = 1.35 * num19;
				if (num3 != 0L)
				{
					long num21 = checked((long)Math.Round(Conversion.Int(unchecked((double)num3 / ((double)num4 + num19) * 1000.0))));
					string text2 = Conversions.ToString(Interaction.IIf((double)num21 > num12 / 6.0, ">", "<"));
					arrayList.Add(string.Concat(new string[]
					{
						"   偏心距:             e= ",
						Conversions.ToString(num21),
						"mm ",
						text2,
						" B/6=",
						Conversions.ToString(Conversion.Int(num12 / 6.0)),
						" mm"
					}));
					if ((double)num21 > Conversion.Int(num12 / 6.0))
					{
						num *= 1.05;
						continue;
					}
				}
				num22 = ((double)num4 + num19) / num10;
				num23 = ((double)num4 + num19) / num10 + (double)num3 / num18;
				if (num23 <= 1.2 * (double)num2)
				{
					goto IL_8DC;
				}
				num *= 1.05;
			}
			Interaction.MsgBox("基础埋深太大", MsgBoxStyle.OkOnly, null);
			return;
			IL_8DC:
			string text3 = Conversions.ToString(Interaction.IIf(num23 > 1.2 * (double)num2, ">", "<"));
			string text4 = Conversions.ToString(Interaction.IIf(num22 > (double)num2, ">", "<"));
			double num24 = ((double)num4 + num19) / num10 - (double)num3 / num18;
			arrayList.Add("   截面抵抗矩:         W=L*B^2/6=" + this.D2S(num18) + "m^3");
			arrayList.Add("   基础和土自重标准值: Gk=γG*D*A/10^6=" + this.D2S(num20) + "KN");
			arrayList.Add(string.Concat(new string[]
			{
				"   平均反力标准值:     Pk=(Nk+Gk)/A=",
				this.D2S(num22),
				"KN/m^2               ",
				text4,
				"fa=",
				Conversions.ToString((int)num2),
				"KN/m^2"
			}));
			if (num3 != 0L)
			{
				arrayList.Add(string.Concat(new string[]
				{
					"   最大反力标准值:     Pkmax=(Nk+Gk)/A+Mk/W=",
					this.D2S(num23),
					"KN/m^2        ",
					text3,
					"1.2fa=",
					Conversions.ToString(1.2 * (double)num2),
					"KN/m^2"
				}));
			}
			if (num3 != 0L)
			{
				arrayList.Add("   最小反力标准值:     Pkmin=(Nk+Gk)/A-Mk/W=" + this.D2S(num24) + "KN/m^2");
			}
			num12 /= 1000.0;
			num11 /= 1000.0;
			num8 /= 1000.0;
			num9 /= 1000.0;
			num13 /= 1000.0;
			double num25 = 1.35 * num23;
			double num26 = 1.35 * num24;
			double num27 = num26 + (num12 - num13) / num12 * (num25 - num26);
			arrayList.Add("\r");
			if (num3 != 0L)
			{
				arrayList.Add("   最大反力设计值:     Pmax=1.35Pkmax=" + this.D2S(num25) + "KN/m^2");
			}
			if (num3 != 0L)
			{
				arrayList.Add("   最大反力设计值:     Pmin=1.35Pkmin=" + this.D2S(num26) + "KN/m^2");
			}
			if (num3 != 0L)
			{
				arrayList.Add("   计算点反力设计值:   P=Pmin+(B-BL)/B*(Pmax-Pmin)=" + this.D2S(num27) + "KN/m^2");
			}
			double num28 = 0.083333333333333329 * Math.Pow(num13, 2.0) * ((2.0 * num11 + num9) * (num25 + num27 - 2.0 * num20 / num10) + (num25 - num27) * num11);
			double num29 = num28 * 1000000.0 / num11 / 0.9 / (num15 - 60.0) / num6;
			double num30 = 0.020833333333333332 * Math.Pow(num11 - num9, 2.0) * (2.0 * num12 + num8) * (num25 + num26 - 2.0 * num20 / num10);
			double num31 = num30 * 1000000.0 / num12 / 0.9 / (num15 - 60.0) / num6;
			double num32 = num15 * 1.5;
			arrayList.Add("   计算弯矩(x):        M1=1/12*BL^2*((2*L+xl)*(Pmax+P-2*G/A)+(Pmax-P)*L)=" + this.D2S(num28) + "KN*m");
			arrayList.Add("   计算配筋(x):        AsX=M1*10^6/L/0.9/(H-50)/Fy=" + this.D2S(num29) + "mm^2");
			arrayList.Add("   计算弯矩(y):        M2=1/48*(L-xl)^2*(2*B+xb)*(Pmax+Pmin-2*G/A)=" + this.D2S(num30) + "KN*m");
			arrayList.Add("   计算配筋(y):        AsY=M2*10^6/B/0.9/(H-50)/Fy=" + this.D2S(num31) + "mm^2");
			arrayList.Add("   构造配筋:           AsG=H*1.5=" + this.D2S(num32) + "mm^2");
			num29 = Math.Max(num29, num32);
			num31 = Math.Max(num31, num32);
			arrayList.Add("   AsX取值:            AsX= Math.Max(AsX, AsG)=" + this.D2S(num29) + "mm^2");
			arrayList.Add("   AsY取值:            AsY= Math.Max(AsY, AsG)=" + this.D2S(num31) + "mm^2");
			arrayList.Add("\r");
			arrayList.Add("四 、设计结果");
			arrayList.Add("\r");
			arrayList.Add("   基础底面:           " + (num12 * 1000.0).ToString() + "x" + (num11 * 1000.0).ToString());
			arrayList.Add("   基础高度:           " + num17.ToString() + "+" + num16.ToString());
			short num33 = 10;
			short num34;
			double num35;
			for (;;)
			{
				num34 = 200;
				do
				{
					num35 = 0.785 * Math.Pow((double)num33, 2.0) * 1000.0 / (double)num34;
					if (num35 > num29)
					{
						goto Block_13;
					}
					num35 = 0.0;
					num34 += -10;
				}
				while (num34 >= 100);
				IL_E65:
				if (num35 > 0.0)
				{
					break;
				}
				num33 += 2;
				if (num33 <= 22)
				{
					continue;
				}
				break;
				Block_13:
				this.TextBox3.Text = "D" + Conversions.ToString((int)num33) + "@" + Conversions.ToString((int)num34);
				goto IL_E65;
			}
			arrayList.Add(string.Concat(new string[]
			{
				"   实配钢筋(x):        D",
				Conversions.ToString((int)num33),
				"@",
				Conversions.ToString((int)num34),
				" (",
				this.D2S(num35),
				"mm^2)"
			}));
			num33 = 10;
			for (;;)
			{
				num34 = 200;
				do
				{
					num35 = 0.785 * Math.Pow((double)num33, 2.0) * 1000.0 / (double)num34;
					if (num35 > num31)
					{
						goto Block_15;
					}
					num35 = 0.0;
					num34 += -10;
				}
				while (num34 >= 100);
				IL_F64:
				if (num35 > 0.0)
				{
					break;
				}
				num33 += 2;
				if (num33 <= 22)
				{
					continue;
				}
				break;
				Block_15:
				this.TextBox4.Text = "D" + Conversions.ToString((int)num33) + "@" + Conversions.ToString((int)num34);
				goto IL_F64;
			}
			arrayList.Add(string.Concat(new string[]
			{
				"   实配钢筋(y):        D",
				Conversions.ToString((int)num33),
				"@",
				Conversions.ToString((int)num34),
				" (",
				this.D2S(num35),
				"mm^2)"
			}));
			arrayList.Add("\r");
			arrayList.Add("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
			arrayList.Add("   注：本计算过程由《田草CAD工具箱》自动生成");
			arrayList.Add("   网址:http://www.tiancao.net");
			arrayList.Add("                                                       " + Conversions.ToString(DateAndTime.Now));
			if (!Directory.Exists(Class33.Class31_0.Info.DirectoryPath + "\\temp\\"))
			{
				Directory.CreateDirectory(Class33.Class31_0.Info.DirectoryPath + "\\temp\\");
			}
			object obj = Class33.Class31_0.Info.DirectoryPath + "\\temp\\" + str;
			NF.SaveTxtFile(Conversions.ToString(obj), arrayList);
			object instance = null;
			Type typeFromHandle = typeof(Process);
			string memberName = "Start";
			object[] array = new object[]
			{
				RuntimeHelpers.GetObjectValue(obj)
			};
			object[] arguments = array;
			string[] argumentNames = null;
			Type[] typeArguments = null;
			bool[] array2 = new bool[]
			{
				true
			};
			NewLateBinding.LateCall(instance, typeFromHandle, memberName, arguments, argumentNames, typeArguments, array2, true);
			if (array2[0])
			{
				obj = RuntimeHelpers.GetObjectValue(array[0]);
			}
		}

		public string D2S(double D)
		{
			return string.Format("{0:0.00}", D);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button3_Click(object sender, EventArgs e)
		{
			short num = Conversions.ToShort(this.TextBox_1.Text);
			long num2 = Conversions.ToLong(this.TextBox_0.Text);
			long num3 = Conversions.ToLong(this.TextBox_2.Text);
			double num4 = Conversion.Val(this.TextBox_3.Text);
			double hnt_QiangDuFc = JG.GetHNT_QiangDuFc(this.ComboBox2.Text);
			double num5 = (double)JG.GetFy(this.ComboBox1.Text);
			double num6 = Conversions.ToDouble(this.TextBox7.Text.Split(new char[]
			{
				'x'
			})[0]);
			double num7 = Conversions.ToDouble(this.TextBox7.Text.Split(new char[]
			{
				'x'
			})[1]);
			double num8 = Conversions.ToDouble(this.TextBox2.Text.Split(new char[]
			{
				'+'
			})[0]);
			double num9 = Conversions.ToDouble(this.TextBox2.Text.Split(new char[]
			{
				'+'
			})[1]);
			string text = this.TextBox1.Text;
			text = this.StrXStr(text, "X");
			double num10;
			double num11;
			if (!this.CheckBox1.Checked)
			{
				num10 = Conversions.ToDouble(text.Split(new char[]
				{
					'X'
				})[0]);
				num11 = Conversions.ToDouble(text.Split(new char[]
				{
					'X'
				})[1]);
			}
			else
			{
				if (!this.CheckBox1.Checked)
				{
					Interaction.MsgBox("柱截面输入有误！", MsgBoxStyle.OkOnly, null);
					return;
				}
				num10 = Conversions.ToDouble(text.Split(new char[]
				{
					'X'
				})[0]);
				num11 = num10;
			}
			string str = "独立基础验算计算书.txt";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("                                  独立基础验算计算书                                      ");
			arrayList.Add("\r\n");
			arrayList.Add("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
			arrayList.Add("一、 设计依据");
			arrayList.Add("\r");
			arrayList.Add("   《混凝土结构设计规范》GB 50010-2010");
			arrayList.Add("   《建筑地基基础设计规范》GB 50007-2011");
			arrayList.Add("\r");
			arrayList.Add("二 、已知条件");
			arrayList.Add("\r");
			arrayList.Add("   修正后地基承载力:   fa= " + Conversions.ToString((int)num) + " Kpa");
			arrayList.Add(string.Concat(new string[]
			{
				"   荷载标准值:         Nk= ",
				Conversions.ToString(num3),
				" KN  弯矩: Mk= ",
				Conversions.ToString(num2),
				" KN*m"
			}));
			arrayList.Add("   基础埋深:           d= " + Conversions.ToString(num4) + "m");
			arrayList.Add(string.Concat(new string[]
			{
				"   混凝土强度:         fc= ",
				Conversions.ToString(hnt_QiangDuFc),
				" N/mm^2  (",
				this.ComboBox2.Text,
				")"
			}));
			arrayList.Add(string.Concat(new string[]
			{
				"   钢筋强度:           fy= ",
				Conversions.ToString(num5),
				" N/mm^2   (",
				this.ComboBox1.Text,
				")"
			}));
			arrayList.Add("   基础底面:           BxL= " + Conversions.ToString(num7) + "x" + Conversions.ToString(num6));
			arrayList.Add("   基础高度:           H1+H2= " + Conversions.ToString(num8) + "+" + Conversions.ToString(num9));
			arrayList.Add("   柱子截面:           " + Conversions.ToString(num10) + "x" + Conversions.ToString(num11));
			arrayList.Add("\r");
			arrayList.Add("三 、验算过程");
			arrayList.Add("\r");
			double num12 = num7 * num6 / 1000000.0;
			arrayList.Add("   基础底面积:         A=b*l= " + this.D2S(num12) + " m^2");
			double num13 = num8 + num9;
			arrayList.Add("   基础高度:           H=H1+H2= " + Conversions.ToString(num13) + " mm");
			double num14 = num6 * Math.Pow(num7, 2.0) / 6.0 / 1000000000.0;
			arrayList.Add("   截面抵抗矩:         W=L*B^2/6= " + this.D2S(num14) + " m^3");
			double num15 = (num7 - num10) / 2.0;
			double value = (num6 - num11) / 2.0;
			arrayList.Add("   底板净悬挑长度（x)  BL= " + Conversions.ToString(num15) + " mm");
			arrayList.Add("   底板净悬挑长度（y)  LL= " + Conversions.ToString(value) + " mm");
			arrayList.Add("\r");
			double num16 = 20.0 * num4 * num12;
			arrayList.Add("   基础和土自重标准值: Gk=γG*D*A/10^6=" + this.D2S(num16) + "KN");
			double num17 = 1.35 * num16;
			double num18 = ((double)num3 + num16) / num12;
			if (num18 > (double)num)
			{
				Interaction.MsgBox("平均反力标准值大于fa,不满足规范要求。", MsgBoxStyle.OkOnly, null);
				arrayList.Add(string.Concat(new string[]
				{
					"   平均反力标准值:     Pk=(Nk+Gk)/A= ",
					this.D2S(num18),
					" KN/m^2                  >fa= ",
					Conversions.ToString((int)num),
					" KN/m^2     ★不满足规范要求"
				}));
			}
			else
			{
				arrayList.Add(string.Concat(new string[]
				{
					"   平均反力标准值:     Pk=(Nk+Gk)/A= ",
					this.D2S(num18),
					" KN/m^2                   <fa= ",
					Conversions.ToString((int)num),
					" KN/m^2        满足"
				}));
			}
			arrayList.Add("\r");
			double num20;
			double num21;
			if (num2 != 0L)
			{
				long num19 = checked((long)Math.Round(Conversion.Int(unchecked((double)num2 / ((double)num3 + num16) * 1000.0))));
				if ((double)num19 >= Conversion.Int(num7 / 6.0))
				{
					arrayList.Add(string.Concat(new string[]
					{
						"   偏心距:             e=(Mk/(Nk+Gk)*1000= ",
						Conversions.ToString(num19),
						" mm > B/6= ",
						Conversions.ToString(Conversion.Int(num7 / 6.0)),
						" mm"
					}));
					double d = ((double)(checked(3L * num19)) / num7 - 0.5) * 100.0;
					arrayList.Add("   零应力区            3e/B-0.5= " + this.D2S(d) + " %");
					num20 = 2.0 * ((double)num3 + num16) / 3.0 / num6 / (num7 / 2.0 - (double)num19) * 1000000.0;
					num21 = 0.0;
					if (num20 > 1.2 * (double)num)
					{
						Interaction.MsgBox("最大反力标准值大于1.2fa,不满足规范要求。", MsgBoxStyle.OkOnly, null);
						arrayList.Add(string.Concat(new string[]
						{
							"   最大反力标准值:     Pkmax=2*(Nk+Gk)/3/L/(B/2 -e)= ",
							this.D2S(num20),
							" KN/m^2          >1.2fa= ",
							Conversions.ToString(1.2 * (double)num),
							" KN/m^2  ★不满足规范要求"
						}));
					}
					else
					{
						arrayList.Add(string.Concat(new string[]
						{
							"   最大反力标准值:     Pkmax=2*(Nk+Gk)/3/L/(B/2 -e)= ",
							this.D2S(num20),
							" KN/m^2          <1.2fa= ",
							Conversions.ToString(1.2 * (double)num),
							" KN/m^2     满足"
						}));
					}
					arrayList.Add("   最小反力标准值:     Pkmin= " + this.D2S(num21) + " KN/m^2");
				}
				else
				{
					arrayList.Add(string.Concat(new string[]
					{
						"   偏心距:             e=(Mk/(Nk+Gk)*1000= ",
						Conversions.ToString(num19),
						" mm < B/6= ",
						Conversions.ToString(Conversion.Int(num7 / 6.0)),
						" mm"
					}));
					num20 = ((double)num3 + num16) / num12 + (double)num2 / num14;
					num21 = ((double)num3 + num16) / num12 - (double)num2 / num14;
					if (num20 > 1.2 * (double)num)
					{
						Interaction.MsgBox("最大反力标准值大于1.2fa,不满足规范要求。", MsgBoxStyle.OkOnly, null);
						arrayList.Add(string.Concat(new string[]
						{
							"   最大反力标准值:     Pkmax=(Nk+Gk)/A+Mk/W= ",
							this.D2S(num20),
							" KN/m^2          >1.2fa= ",
							Conversions.ToString(1.2 * (double)num),
							" KN/m^2  ★不满足规范要求"
						}));
					}
					else
					{
						arrayList.Add(string.Concat(new string[]
						{
							"   最大反力标准值:     Pkmax=(Nk+Gk)/A+Mk/W= ",
							this.D2S(num20),
							" KN/m^2          <1.2fa= ",
							Conversions.ToString(1.2 * (double)num),
							" KN/m^2     满足"
						}));
					}
					arrayList.Add("   最小反力标准值:     Pkmin=(Nk+Gk)/A-Mk/W= " + this.D2S(num21) + " KN/m^2");
				}
			}
			arrayList.Add("\r");
			num7 /= 1000.0;
			num6 /= 1000.0;
			num11 /= 1000.0;
			num10 /= 1000.0;
			num15 /= 1000.0;
			double num22;
			double num23;
			double num24;
			if (num2 == 0L)
			{
				num22 = 1.35 * num18;
				num23 = num22;
				num24 = num22;
				arrayList.Add("   平均反力设计值:     P=1.35Pk= " + this.D2S(num22) + " KN/m^2");
			}
			else
			{
				num23 = 1.35 * num20;
				num24 = 1.35 * num21;
				num22 = num24 + (num7 - num15) / num7 * (num23 - num24);
				arrayList.Add("   最大反力设计值:     Pmax=1.35Pkmax= " + this.D2S(num23) + " KN/m^2");
				arrayList.Add("   最大反力设计值:     Pmin=1.35Pkmin= " + this.D2S(num24) + " KN/m^2");
				arrayList.Add("   计算点反力设计值:   P=Pmin+(B-BL)/B*(Pmax-Pmin)= " + this.D2S(num22) + " KN/m^2");
			}
			double num25 = 0.083333333333333329 * Math.Pow(num15, 2.0) * ((2.0 * num6 + num11) * (num23 + num22 - 2.0 * num17 / num12) + (num23 - num22) * num6);
			double num26 = num25 * 1000000.0 / num6 / 0.9 / (num13 - 60.0) / num5;
			double num27 = 0.020833333333333332 * Math.Pow(num6 - num11, 2.0) * (2.0 * num7 + num10) * (num23 + num24 - 2.0 * num17 / num12);
			double num28 = num27 * 1000000.0 / num7 / 0.9 / (num13 - 60.0) / num5;
			double num29 = num13 * 1.5;
			if (num2 == 0L)
			{
				arrayList.Add("   计算弯矩(x):        M1=1/6*BL^2*(2*L+xl)*(P-G/A)= " + this.D2S(num25) + " KN*m");
				arrayList.Add("   计算配筋(x):        AsX=M1*10^6/L/0.9/(H-60)/Fy= " + this.D2S(num26) + " mm^2");
				arrayList.Add("   计算弯矩(y):        M2=1/24*(L-xl)^2*(2*B+xb)*(P-G/A)= " + this.D2S(num27) + " KN*m");
				arrayList.Add("   计算配筋(y):        AsY=M2*10^6/B/0.9/(H-60)/Fy= " + this.D2S(num28) + " mm^2");
			}
			else
			{
				arrayList.Add("   计算弯矩(x):        M1=1/12*BL^2*((2*L+xl)*(Pmax+P-2*G/A)+(Pmax-P)*L)= " + this.D2S(num25) + " KN*m");
				arrayList.Add("   计算配筋(x):        AsX=M1*10^6/L/0.9/(H-60)/Fy= " + this.D2S(num26) + " mm^2");
				arrayList.Add("   计算弯矩(y):        M2=1/48*(L-xl)^2*(2*B+xb)*(Pmax+Pmin-2*G/A)= " + this.D2S(num27) + " KN*m");
				arrayList.Add("   计算配筋(y):        AsY=M2*10^6/B/0.9/(H-60)/Fy= " + this.D2S(num28) + " mm^2");
			}
			arrayList.Add("   构造配筋:           AsG=H*1.5= " + this.D2S(num29) + " mm^2");
			num26 = Math.Max(num26, num29);
			num28 = Math.Max(num28, num29);
			arrayList.Add("   AsX取值:            AsX= Math.Max(AsX, AsG)= " + this.D2S(num26) + " mm^2");
			arrayList.Add("   AsY取值:            AsY= Math.Max(AsY, AsG)= " + this.D2S(num28) + " mm^2");
			arrayList.Add("\r");
			string text2 = this.TextBox3.Text.Substring(1);
			string text3 = this.TextBox4.Text.Substring(1);
			double num30 = Conversion.Val(JG.GetSteels2(text2));
			double num31 = Conversion.Val(JG.GetSteels2(text3));
			if (num30 > num26)
			{
				arrayList.Add(string.Concat(new string[]
				{
					"   实配钢筋:           D",
					text2,
					"（",
					Conversions.ToString(num30),
					"mm^2)  配筋满足"
				}));
			}
			else
			{
				arrayList.Add(string.Concat(new string[]
				{
					"   实配钢筋:           D",
					text2,
					"（",
					Conversions.ToString(num30),
					"mm^2)  ★配筋不满足"
				}));
			}
			if (num31 > num28)
			{
				arrayList.Add(string.Concat(new string[]
				{
					"   实配钢筋:           D",
					text3,
					"（",
					Conversions.ToString(num31),
					"mm^2)  配筋满足"
				}));
			}
			else
			{
				arrayList.Add(string.Concat(new string[]
				{
					"   实配钢筋:           D",
					text3,
					"（",
					Conversions.ToString(num31),
					"mm^2)  ★配筋不满足"
				}));
			}
			arrayList.Add("\r");
			arrayList.Add("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
			arrayList.Add("   注：本计算过程由《田草CAD工具箱》自动生成");
			arrayList.Add("   网址:http://www.tiancao.net");
			arrayList.Add("                                                       " + Conversions.ToString(DateAndTime.Now));
			if (!Directory.Exists(Class33.Class31_0.Info.DirectoryPath + "\\temp\\"))
			{
				Directory.CreateDirectory(Class33.Class31_0.Info.DirectoryPath + "\\temp\\");
			}
			object obj = Class33.Class31_0.Info.DirectoryPath + "\\temp\\" + str;
			NF.SaveTxtFile(Conversions.ToString(obj), arrayList);
			object instance = null;
			Type typeFromHandle = typeof(Process);
			string memberName = "Start";
			object[] array = new object[]
			{
				RuntimeHelpers.GetObjectValue(obj)
			};
			object[] arguments = array;
			string[] argumentNames = null;
			Type[] typeArguments = null;
			bool[] array2 = new bool[]
			{
				true
			};
			NewLateBinding.LateCall(instance, typeFromHandle, memberName, arguments, argumentNames, typeArguments, array2, true);
			if (array2[0])
			{
				obj = RuntimeHelpers.GetObjectValue(array[0]);
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			int num;
			int num29;
			object obj3;
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
				this.Hide();
				IL_24:
				num2 = 4;
				double num3 = Conversions.ToDouble(this.TextBox8.Text);
				IL_38:
				num2 = 5;
				object obj = CAD.CreateTextStyle("Tc_尺寸标注", "txt.shx", "hztxt.Shx", 0.7);
				IL_5E:
				num2 = 6;
				string dimStyleName = "Tc_Dim" + Conversions.ToString(num3);
				object obj2 = obj;
				ObjectId dimID;
				ObjectId[] array;
				Point3d point;
				int num4;
				int num5;
				int num6;
				checked
				{
					ObjectId objectId;
					dimID = CAD.CreateDimStyle(dimStyleName, (obj2 != null) ? ((ObjectId)obj2) : objectId, (int)Math.Round(num3), 1.0, false, -1.0);
					IL_A7:
					num2 = 7;
					array = new ObjectId[105];
					IL_B2:
					num2 = 8;
					point = CAD.GetPoint("选择插入点: ");
					IL_C0:
					num2 = 9;
					Point3d point3d;
					if (!(point == point3d))
					{
						goto IL_D3;
					}
					IL_CE:
					goto IL_40C8;
					IL_D3:
					num2 = 12;
					string text = this.TextBox1.Text;
					IL_E2:
					num2 = 13;
					text = this.StrXStr(text, "X");
					IL_F2:
					num2 = 14;
					num4 = Conversions.ToInteger(text.Split(new char[]
					{
						'X'
					})[0]);
					IL_111:
					num2 = 15;
					num5 = Conversions.ToInteger(text.Split(new char[]
					{
						'X'
					})[1]);
					IL_130:
					num2 = 16;
					if (this.CheckBox1.Checked)
					{
						goto IL_297;
					}
					IL_146:
					num2 = 17;
					num6 = Strings.InStr(this.TextBox1.Text, "x", CompareMethod.Binary);
					IL_161:
					num2 = 18;
					num4 = Conversions.ToInteger(Strings.Mid(this.TextBox1.Text, 1, num6 - 1));
					IL_180:
					num2 = 19;
					num5 = Conversions.ToInteger(Strings.Mid(this.TextBox1.Text, num6 + 1));
					IL_19E:
					num2 = 20;
				}
				Point3d pointXY;
				pointXY..ctor(point.X - (double)num4 / 2.0, point.Y - (double)num5 / 2.0, 0.0);
				IL_1DB:
				num2 = 21;
				array[0] = CAD.AddPlinePxy(pointXY, (double)num4, (double)num5, 0.0, "").ObjectId;
				IL_20B:
				num2 = 22;
				pointXY..ctor(point.X - (double)num4 / 2.0 - 50.0, point.Y - (double)num5 / 2.0 - 50.0, 0.0);
				IL_25C:
				num2 = 23;
				array[1] = checked(CAD.AddPlinePxy(pointXY, (double)(num4 + 100), (double)(num5 + 100), 0.0, "")).ObjectId;
				goto IL_372;
				IL_297:
				num2 = 25;
				IL_29A:
				num2 = 26;
				int num7 = Conversions.ToInteger(this.TextBox1.Text);
				IL_2AF:
				num2 = 27;
				num4 = num7;
				IL_2B6:
				num2 = 28;
				num5 = num7;
				IL_2BD:
				num2 = 29;
				array[0] = CAD.AddCircle(point, (double)num7 / 2.0, "").ObjectId;
				IL_2EB:
				num2 = 30;
				pointXY..ctor(point.X - (double)num7 / 2.0 - 50.0, point.Y - (double)num7 / 2.0 - 50.0, 0.0);
				IL_33C:
				num2 = 31;
				int num8;
				int num9;
				checked
				{
					array[1] = CAD.AddPlinePxy(pointXY, (double)(num7 + 100), (double)(num7 + 100), 0.0, "").ObjectId;
					IL_372:
					num2 = 33;
					num6 = Strings.InStr(this.TextBox7.Text.ToUpper(), "X", CompareMethod.Binary);
					IL_392:
					num2 = 34;
					num8 = Conversions.ToInteger(Strings.Mid(this.TextBox7.Text, 1, num6 - 1));
					IL_3B1:
					num2 = 35;
					num9 = Conversions.ToInteger(Strings.Mid(this.TextBox7.Text, num6 + 1));
					IL_3CF:
					num2 = 36;
				}
				pointXY..ctor(point.X - (double)num8 / 2.0, point.Y - (double)num9 / 2.0, 0.0);
				IL_40C:
				num2 = 37;
				array[2] = CAD.AddPlinePxy(pointXY, (double)num8, (double)num9, 0.0, "").ObjectId;
				IL_43C:
				num2 = 38;
				Point3d point3d2;
				point3d2..ctor(point.X + (double)(checked(num4 + 100)) / 2.0, point.Y + (double)(checked(num5 + 100)) / 2.0, 0.0);
				IL_47F:
				num2 = 39;
				Point3d point3d3;
				point3d3..ctor(point.X + (double)num8 / 2.0, point.Y + (double)num9 / 2.0, 0.0);
				IL_4BC:
				num2 = 40;
				array[3] = CAD.AddLine(point3d2, point3d3, "0").ObjectId;
				IL_4DF:
				num2 = 41;
				point3d2..ctor(point.X + (double)(checked(num4 + 100)) / 2.0, point.Y - (double)(checked(num5 + 100)) / 2.0, 0.0);
				IL_522:
				num2 = 42;
				point3d3..ctor(point.X + (double)num8 / 2.0, point.Y - (double)num9 / 2.0, 0.0);
				IL_55F:
				num2 = 43;
				array[4] = CAD.AddLine(point3d2, point3d3, "0").ObjectId;
				IL_582:
				num2 = 44;
				point3d2..ctor(point.X - (double)(checked(num4 + 100)) / 2.0, point.Y - (double)(checked(num5 + 100)) / 2.0, 0.0);
				IL_5C5:
				num2 = 45;
				point3d3..ctor(point.X - (double)num8 / 2.0, point.Y - (double)num9 / 2.0, 0.0);
				IL_602:
				num2 = 46;
				Point3d pointAngle = CAD.GetPointAngle(point3d3, 450.0, Math.Atan((double)num9 / (double)num8) * 180.0 / 3.1415926535897931);
				IL_637:
				num2 = 47;
				array[5] = CAD.AddLine(point3d2, pointAngle, "0").ObjectId;
				IL_65A:
				num2 = 48;
				array[6] = Class36.smethod_67(point3d3, 450.0, 0.0, 1.5707963267948966).ObjectId;
				IL_691:
				num2 = 49;
				Point3d[] array2 = new Point3d[2];
				IL_69C:
				num2 = 52;
				double[] array3 = new double[4];
				IL_6A7:
				num2 = 53;
				array3[0] = Math.Sqrt(192500.0);
				IL_6BC:
				num2 = 54;
				array3[1] = Math.Sqrt(162500.0);
				IL_6D1:
				num2 = 55;
				array3[2] = Math.Sqrt(112500.0);
				IL_6E6:
				num2 = 56;
				array3[3] = Math.Sqrt(42500.0);
				IL_6FB:
				num2 = 57;
				if (num8 < 2500)
				{
					goto IL_71C;
				}
				IL_70C:
				num2 = 58;
				double num10 = 1.0;
				goto IL_72D;
				IL_71C:
				num2 = 60;
				IL_71F:
				num2 = 61;
				num10 = 0.0;
				IL_72D:
				num2 = 63;
				if (num9 < 2500)
				{
					goto IL_74E;
				}
				IL_73E:
				num2 = 64;
				double num11 = 1.0;
				goto IL_75F;
				IL_74E:
				num2 = 66;
				IL_751:
				num2 = 67;
				num11 = 0.0;
				IL_75F:
				num2 = 69;
				array2[0] = CAD.GetPointXY(point3d3, 100.0, 50.0);
				IL_788:
				num2 = 70;
				array2[1] = CAD.GetPointXY(point3d3, 100.0, array3[0]);
				IL_7AC:
				num2 = 71;
				array[7] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_7E4:
				num2 = 72;
				array2[0] = CAD.GetPointXY(point3d3, 200.0, 50.0 + num11 * 100.0);
				IL_81A:
				num2 = 73;
				array2[1] = CAD.GetPointXY(point3d3, 200.0, array3[1]);
				IL_83E:
				num2 = 74;
				array[8] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_876:
				num2 = 75;
				array2[0] = CAD.GetPointXY(point3d3, 300.0, 50.0);
				IL_89F:
				num2 = 76;
				array2[1] = CAD.GetPointXY(point3d3, 300.0, array3[2]);
				IL_8C3:
				num2 = 77;
				array[9] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_8FC:
				num2 = 78;
				array2[0] = CAD.GetPointXY(point3d3, 400.0, 50.0 + num11 * 100.0);
				IL_932:
				num2 = 79;
				array2[1] = CAD.GetPointXY(point3d3, 400.0, array3[3]);
				IL_956:
				num2 = 80;
				array[10] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_98F:
				num2 = 81;
				array2[0] = CAD.GetPointXY(point3d3, 50.0, 100.0);
				IL_9B8:
				num2 = 82;
				array2[1] = CAD.GetPointXY(point3d3, array3[0], 100.0);
				IL_9DC:
				num2 = 83;
				array[11] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_A15:
				num2 = 84;
				array2[0] = CAD.GetPointXY(point3d3, 50.0 + num10 * 100.0, 200.0);
				IL_A4B:
				num2 = 85;
				array2[1] = CAD.GetPointXY(point3d3, array3[1], 200.0);
				IL_A6F:
				num2 = 86;
				array[12] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_AA8:
				num2 = 87;
				array2[0] = CAD.GetPointXY(point3d3, 50.0, 300.0);
				IL_AD1:
				num2 = 88;
				array2[1] = CAD.GetPointXY(point3d3, array3[2], 300.0);
				IL_AF5:
				num2 = 89;
				array[13] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_B2E:
				num2 = 90;
				array2[0] = CAD.GetPointXY(point3d3, 50.0 + num10 * 100.0, 400.0);
				IL_B64:
				num2 = 91;
				array2[1] = CAD.GetPointXY(point3d3, array3[3], 400.0);
				IL_B88:
				num2 = 92;
				array[14] = CAD.AddPline(array2, 50.0 * (num3 / 100.0), false, "").ObjectId;
				IL_BC1:
				num2 = 93;
				CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
				IL_BD9:
				num2 = 94;
				int num12 = 7;
				checked
				{
					do
					{
						IL_BF0:
						num2 = 95;
						CAD.ChangeLayer(array[num12], "钢筋");
						IL_BE1:
						num2 = 96;
						num12++;
					}
					while (num12 <= 14);
					IL_C0E:
					num2 = 97;
				}
				point3d2..ctor(point.X - (double)(checked(num4 + 100)) / 2.0, point.Y + (double)(checked(num5 + 100)) / 2.0, 0.0);
				IL_C51:
				num2 = 98;
				point3d3..ctor(point.X - (double)num8 / 2.0, point.Y + (double)num9 / 2.0, 0.0);
				IL_C8E:
				num2 = 99;
				array[15] = CAD.AddLine(point3d2, point3d3, "0").ObjectId;
				IL_CB2:
				num2 = 100;
				pointXY..ctor(point.X - (double)num8 / 2.0 - 100.0, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_D03:
				num2 = 101;
				double num13;
				double num14;
				int num15;
				int num16;
				checked
				{
					array[16] = CAD.AddPlinePxy(pointXY, (double)(num8 + 200), (double)(num9 + 200), 0.0, "").ObjectId;
					IL_D40:
					num2 = 102;
					num13 = Conversion.Val(this.TextBox5.Text);
					IL_D55:
					num2 = 103;
					num14 = Conversion.Val(this.TextBox6.Text);
					IL_D6A:
					num2 = 104;
					num6 = Strings.InStr(this.TextBox2.Text, "+", CompareMethod.Binary);
					IL_D85:
					num2 = 105;
					num15 = Conversions.ToInteger(Strings.Mid(this.TextBox2.Text, 1, num6 - 1));
					IL_DA4:
					num2 = 106;
					num16 = Conversions.ToInteger(Strings.Mid(this.TextBox2.Text, num6 + 1));
					IL_DC2:
					num2 = 107;
				}
				point3d2..ctor(point.X + (double)num8 / 2.0 + 300.0 + num13, point.Y + num14, 0.0);
				IL_E01:
				num2 = 108;
				point3d3..ctor(point.X - (double)num8 / 2.0 - 300.0 + num13, point.Y + num14, 0.0);
				IL_E40:
				num2 = 109;
				Line line = CAD.AddLine(point3d2, point3d3, "0");
				IL_E53:
				num2 = 110;
				CAD.CreateLayer("Dote", 251, "dote", 13, false, true);
				IL_E6F:
				num2 = 111;
				CAD.ChangeLayer(line.ObjectId, "dote");
				IL_E84:
				num2 = 112;
				array[17] = line.ObjectId;
				IL_E9C:
				num2 = 113;
				point3d2..ctor(point.X + num13, point.Y + (double)num9 / 2.0 + 800.0 + (double)num15 + (double)num16 + 10.0 * num3 + num14, 0.0);
				IL_EF0:
				num2 = 114;
				point3d3..ctor(point.X + num13, point.Y - (double)num9 / 2.0 - 300.0 + num14, 0.0);
				IL_F2F:
				num2 = 115;
				Line line2 = CAD.AddLine(point3d2, point3d3, "0");
				IL_F42:
				num2 = 116;
				CAD.ChangeLayer(line2.ObjectId, "dote");
				IL_F57:
				num2 = 117;
				array[18] = line2.ObjectId;
				IL_F6F:
				num2 = 118;
				Class36.smethod_78("Dim" + Conversions.ToString(num3), checked((int)Math.Round(num3)), 1.0, false);
				IL_F9B:
				num2 = 119;
				array2 = new Point3d[9];
				IL_FA7:
				num2 = 122;
				array2[0]..ctor(point.X - (double)num8 / 2.0 - 100.0, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_FFE:
				num2 = 123;
				array2[1]..ctor(point.X - (double)num8 / 2.0, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_104B:
				num2 = 124;
				array2[2]..ctor(point.X + num13, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_108D:
				num2 = 125;
				array2[3]..ctor(point.X + (double)num8 / 2.0, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_10DA:
				num2 = 126;
				array2[4]..ctor(point.X + (double)num8 / 2.0 + 100.0, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_1131:
				num2 = 127;
				pointXY..ctor(point.X, point.Y - (double)num9 / 2.0 - 100.0 - 10.0 * num3, 0.0);
				IL_1177:
				num2 = 128;
				array[19] = CAD.AddLineDim(array2[1], array2[3], pointXY, 1.0, dimID, -1.0);
				IL_11C0:
				num2 = 129;
				pointXY..ctor(point.X, point.Y - (double)num9 / 2.0 - 100.0 - 5.0 * num3, 0.0);
				IL_1209:
				num2 = 130;
				array[20] = CAD.AddLineDim(array2[0], array2[1], pointXY, 1.0, dimID, -1.0);
				IL_1252:
				num2 = 131;
				array[21] = CAD.AddLineDim(array2[1], array2[2], pointXY, 1.0, dimID, -1.0);
				IL_129B:
				num2 = 132;
				array[22] = CAD.AddLineDim(array2[2], array2[3], pointXY, 1.0, dimID, -1.0);
				IL_12E4:
				num2 = 133;
				array[23] = CAD.AddLineDim(array2[3], array2[4], pointXY, 1.0, dimID, -1.0);
				IL_132D:
				num2 = 134;
				array2[0]..ctor(point.X - (double)(checked(num4 + 100)) / 2.0, point.Y - (double)num5 / 2.0 - 100.0, 0.0);
				IL_1380:
				num2 = 135;
				array2[1]..ctor(point.X - (double)num4 / 2.0, point.Y - (double)num5 / 2.0 - 100.0, 0.0);
				IL_13D0:
				num2 = 136;
				array2[2]..ctor(point.X + num13, point.Y - (double)num5 / 2.0 - 100.0, 0.0);
				IL_1415:
				num2 = 137;
				array2[3]..ctor(point.X + (double)num4 / 2.0, point.Y - (double)num5 / 2.0 - 100.0, 0.0);
				IL_1465:
				num2 = 138;
				array2[4]..ctor(point.X + (double)(checked(num4 + 100)) / 2.0, point.Y - (double)num5 / 2.0 - 100.0, 0.0);
				IL_14B8:
				num2 = 139;
				pointXY..ctor(point.X, point.Y - (double)num5 / 2.0 - 100.0 - 5.0 * num3, 0.0);
				IL_1501:
				num2 = 140;
				array[24] = CAD.AddLineDim(array2[0], array2[1], pointXY, 1.0, dimID, -1.0);
				IL_154A:
				num2 = 141;
				array[25] = CAD.AddLineDim(array2[1], array2[2], pointXY, 1.0, dimID, -1.0);
				IL_1593:
				num2 = 142;
				array[26] = CAD.AddLineDim(array2[2], array2[3], pointXY, 1.0, dimID, -1.0);
				IL_15DC:
				num2 = 143;
				array[27] = CAD.AddLineDim(array2[3], array2[4], pointXY, 1.0, dimID, -1.0);
				IL_1625:
				num2 = 144;
				array2[0]..ctor(point.X + (double)num8 / 2.0 + 100.0, point.Y - (double)num9 / 2.0 - 100.0, 0.0);
				IL_167F:
				num2 = 145;
				array2[1]..ctor(point.X + (double)num8 / 2.0 + 100.0, point.Y - (double)num9 / 2.0, 0.0);
				IL_16CF:
				num2 = 146;
				array2[2]..ctor(point.X + (double)num8 / 2.0 + 100.0, point.Y + num14, 0.0);
				IL_1714:
				num2 = 147;
				array2[3]..ctor(point.X + (double)num8 / 2.0 + 100.0, point.Y + (double)num9 / 2.0, 0.0);
				IL_1764:
				num2 = 148;
				array2[4]..ctor(point.X + (double)num8 / 2.0 + 100.0, point.Y + (double)num9 / 2.0 + 100.0, 0.0);
				IL_17BE:
				num2 = 149;
				pointXY..ctor(point.X + (double)num8 / 2.0 + 100.0 + 10.0 * num3, point.Y, 0.0);
				IL_1807:
				num2 = 150;
				CAD.AddLineDim(array2[1], array2[3], pointXY, 1.0, dimID, -1.0);
				IL_1843:
				num2 = 151;
				pointXY..ctor(point.X + (double)num8 / 2.0 + 100.0 + 5.0 * num3, point.Y, 0.0);
				IL_188C:
				num2 = 152;
				CAD.AddLineDim(array2[0], array2[1], pointXY, 1.0, dimID, -1.0);
				IL_18C8:
				num2 = 153;
				CAD.AddLineDim(array2[1], array2[2], pointXY, 1.0, dimID, -1.0);
				IL_1904:
				num2 = 154;
				CAD.AddLineDim(array2[2], array2[3], pointXY, 1.0, dimID, -1.0);
				IL_1940:
				num2 = 155;
				CAD.AddLineDim(array2[3], array2[4], pointXY, 1.0, dimID, -1.0);
				IL_197C:
				num2 = 156;
				array2[0]..ctor(point.X + (double)num4 / 2.0 + 100.0, point.Y - (double)(checked(num5 + 100)) / 2.0, 0.0);
				IL_19CF:
				num2 = 157;
				array2[1]..ctor(point.X + (double)num4 / 2.0 + 100.0, point.Y - (double)num5 / 2.0, 0.0);
				IL_1A1F:
				num2 = 158;
				array2[2]..ctor(point.X + (double)num4 / 2.0 + 100.0, point.Y + num14, 0.0);
				IL_1A64:
				num2 = 159;
				array2[3]..ctor(point.X + (double)num4 / 2.0 + 100.0, point.Y + (double)num5 / 2.0, 0.0);
				IL_1AB4:
				num2 = 160;
				array2[4]..ctor(point.X + (double)num4 / 2.0 + 100.0, point.Y + (double)(checked(num5 + 100)) / 2.0, 0.0);
				IL_1B07:
				num2 = 161;
				pointXY..ctor(point.X + (double)num4 / 2.0 + 100.0 + 5.0 * num3, point.Y, 0.0);
				IL_1B50:
				num2 = 162;
				CAD.AddLineDim(array2[0], array2[1], pointXY, 1.0, dimID, -1.0);
				IL_1B8C:
				num2 = 163;
				CAD.AddLineDim(array2[1], array2[2], pointXY, 1.0, dimID, -1.0);
				IL_1BC8:
				num2 = 164;
				CAD.AddLineDim(array2[2], array2[3], pointXY, 1.0, dimID, -1.0);
				IL_1C04:
				num2 = 165;
				CAD.AddLineDim(array2[3], array2[4], pointXY, 1.0, dimID, -1.0);
				IL_1C40:
				num2 = 166;
				Point3d point3d_;
				point3d_..ctor(point.X, point.Y - (double)num9 / 2.0 - 700.0, 0.0);
				IL_1C7C:
				num2 = 167;
				Class36.smethod_6(point3d_, "J-1", num3, "");
				IL_1C96:
				num2 = 168;
				point..ctor(point.X, point.Y + (double)num9 / 2.0 + 100.0 + 10.0 * num3, 0.0);
				IL_1CDF:
				num2 = 169;
				pointXY..ctor(point.X - (double)num8 / 2.0 - 100.0, point.Y, 0.0);
				IL_1D1B:
				num2 = 170;
				array[37] = CAD.AddPlinePxy(pointXY, (double)(checked(num8 + 200)), 100.0, 0.0, "").ObjectId;
				IL_1D5B:
				num2 = 171;
				array2 = new Point3d[10];
				IL_1D6A:
				num2 = 174;
				array2[0]..ctor(point.X - (double)num4 / 2.0, point.Y + 100.0 + (double)num15 + (double)num16 + 500.0, 0.0);
				IL_1DBE:
				num2 = 175;
				array2[1]..ctor(point.X - (double)num4 / 2.0, point.Y + 100.0 + (double)num15 + (double)num16, 0.0);
				IL_1E08:
				num2 = 176;
				array2[2]..ctor(point.X - (double)num4 / 2.0 - 50.0, point.Y + 100.0 + (double)num15 + (double)num16, 0.0);
				IL_1E5C:
				num2 = 177;
				array2[3]..ctor(point.X - (double)num8 / 2.0, point.Y + 100.0 + (double)num15, 0.0);
				IL_1EA2:
				num2 = 178;
				array2[4]..ctor(point.X - (double)num8 / 2.0, point.Y + 100.0, 0.0);
				IL_1EE4:
				num2 = 179;
				array2[5]..ctor(point.X + (double)num8 / 2.0, point.Y + 100.0, 0.0);
				IL_1F26:
				num2 = 180;
				array2[6]..ctor(point.X + (double)num8 / 2.0, point.Y + 100.0 + (double)num15, 0.0);
				IL_1F6C:
				num2 = 181;
				array2[7]..ctor(point.X + (double)num4 / 2.0 + 50.0, point.Y + 100.0 + (double)num15 + (double)num16, 0.0);
				IL_1FC0:
				num2 = 182;
				array2[8]..ctor(point.X + (double)num4 / 2.0, point.Y + 100.0 + (double)num15 + (double)num16, 0.0);
				IL_200A:
				num2 = 183;
				array2[9]..ctor(point.X + (double)num4 / 2.0, point.Y + 100.0 + (double)num15 + (double)num16 + 500.0, 0.0);
				IL_205F:
				num2 = 184;
				array[38] = CAD.AddPline(array2, 0.0, false, "").ObjectId;
				IL_208E:
				num2 = 185;
				array[39] = Class36.smethod_80(array2[0], array2[9], num3);
				IL_20C4:
				num2 = 186;
				array2[4]..ctor(array2[5].X + 100.0, array2[5].Y - 100.0, 0.0);
				IL_210E:
				num2 = 187;
				array2[5]..ctor(array2[5].X + 100.0, array2[5].Y, 0.0);
				IL_214E:
				num2 = 188;
				array2[6]..ctor(array2[5].X, array2[6].Y, 0.0);
				IL_2184:
				num2 = 189;
				array2[7]..ctor(array2[5].X, array2[7].Y, 0.0);
				IL_21BA:
				num2 = 190;
				pointXY..ctor(array2[5].X + 5.0 * num3, array2[5].Y, 0.0);
				IL_21F7:
				num2 = 191;
				CAD.AddLineDim(array2[4], array2[5], pointXY, 1.0, dimID, -1.0);
				IL_2233:
				num2 = 192;
				CAD.AddLineDim(array2[5], array2[6], pointXY, 1.0, dimID, -1.0);
				IL_226F:
				num2 = 193;
				if (num16 == 0)
				{
					goto IL_22BB;
				}
				IL_227F:
				num2 = 194;
				CAD.AddLineDim(array2[6], array2[7], pointXY, 1.0, dimID, -1.0);
				IL_22BB:
				num2 = 196;
				point3d2..ctor(point.X - (double)num8 / 2.0, point.Y + 100.0, 0.0);
				IL_22F7:
				num2 = 197;
				point3d3..ctor(point.X + (double)num8 / 2.0, point.Y + 100.0, 0.0);
				IL_2333:
				num2 = 198;
				array2 = new Point3d[2];
				IL_2341:
				num2 = 201;
				if (num8 < num9)
				{
					goto IL_23AC;
				}
				IL_2352:
				num2 = 202;
				array2[0] = CAD.GetPointXY(point3d2, 50.0, 30.0);
				IL_237E:
				num2 = 203;
				array2[1] = CAD.GetPointXY(point3d3, -50.0, 30.0);
				goto IL_240A;
				IL_23AC:
				num2 = 205;
				IL_23B2:
				num2 = 206;
				array2[0] = CAD.GetPointXY(point3d2, 50.0, 50.0);
				IL_23DE:
				num2 = 207;
				array2[1] = CAD.GetPointXY(point3d3, -50.0, 50.0);
				IL_240A:
				num2 = 209;
				array[43] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_2446:
				num2 = 210;
				string text2 = this.TextBox3.Text.ToUpper();
				IL_245E:
				num2 = 211;
				string text3 = this.TextBox4.Text.ToUpper();
				IL_2476:
				num2 = 212;
				text2 = Strings.Replace(text2, "A", "%%130", 1, -1, CompareMethod.Binary);
				IL_2492:
				num2 = 213;
				text2 = Strings.Replace(text2, "B", "%%131", 1, -1, CompareMethod.Binary);
				IL_24AE:
				num2 = 214;
				text2 = Strings.Replace(text2, "C", "%%132", 1, -1, CompareMethod.Binary);
				IL_24CA:
				num2 = 215;
				text2 = Strings.Replace(text2, "D", "%%133", 1, -1, CompareMethod.Binary);
				IL_24E6:
				num2 = 216;
				text3 = Strings.Replace(text3, "A", "%%130", 1, -1, CompareMethod.Binary);
				IL_2502:
				num2 = 217;
				text3 = Strings.Replace(text3, "B", "%%131", 1, -1, CompareMethod.Binary);
				IL_251E:
				num2 = 218;
				text3 = Strings.Replace(text3, "C", "%%132", 1, -1, CompareMethod.Binary);
				IL_253A:
				num2 = 219;
				text3 = Strings.Replace(text3, "D", "%%133", 1, -1, CompareMethod.Binary);
				IL_2556:
				num2 = 220;
				array2 = new Point3d[10];
				IL_2565:
				num2 = 223;
				if (num8 < num9)
				{
					goto IL_2751;
				}
				IL_2579:
				num2 = 224;
				array2[0] = CAD.GetPointXY(point3d2, 100.0, 50.0);
				IL_25A5:
				num2 = 225;
				array2[1] = CAD.GetPointXY(point3d2, 200.0, 50.0);
				IL_25D1:
				num2 = 226;
				array2[2] = CAD.GetPointXY(point3d2, 300.0, 50.0);
				IL_25FD:
				num2 = 227;
				array2[3] = CAD.GetPointXY(point3d2, 100.0, 120.0);
				IL_2629:
				num2 = 228;
				array2[4] = CAD.GetPointXY(point3d2, 200.0, 120.0);
				IL_2655:
				num2 = 229;
				array2[5] = CAD.GetPointXY(point3d2, 300.0, 120.0);
				IL_2681:
				num2 = 230;
				array2[6] = CAD.GetPointXY(point3d2, -200.0 - 12.0 * num3, 120.0);
				IL_26BA:
				num2 = 231;
				array2[7] = CAD.GetPointXY(point3d2, 150.0, 30.0);
				IL_26E6:
				num2 = 232;
				array2[8] = CAD.GetPointXY(point3d2, 150.0, -200.0);
				IL_2712:
				num2 = 233;
				array2[9] = CAD.GetPointXY(point3d2, -200.0 - 12.0 * num3, -200.0);
				goto IL_2962;
				IL_2751:
				num2 = 235;
				IL_2757:
				num2 = 236;
				array2[0] = CAD.GetPointXY(point3d2, 100.0, 30.0);
				IL_2783:
				num2 = 237;
				array2[1] = CAD.GetPointXY(point3d2, 200.0, 30.0);
				IL_27AF:
				num2 = 238;
				array2[2] = CAD.GetPointXY(point3d2, 300.0, 30.0);
				IL_27DB:
				num2 = 239;
				array2[3] = CAD.GetPointXY(point3d2, 100.0, -250.0);
				IL_2807:
				num2 = 240;
				array2[4] = CAD.GetPointXY(point3d2, 200.0, -250.0);
				IL_2833:
				num2 = 241;
				array2[5] = CAD.GetPointXY(point3d2, 300.0, -250.0);
				IL_285F:
				num2 = 242;
				array2[6] = CAD.GetPointXY(point3d2, -200.0 - 12.0 * num3, -250.0);
				IL_2898:
				num2 = 243;
				array2[7] = CAD.GetPointXY(point3d2, 150.0, 50.0);
				IL_28C4:
				num2 = 244;
				array2[8] = CAD.GetPointXY(point3d2, 150.0, 50.0 + 3.5 * num3);
				IL_28FD:
				num2 = 245;
				array2[9] = CAD.GetPointXY(point3d2, -200.0 - 12.0 * num3, 50.0 + 3.5 * num3);
				IL_2944:
				num2 = 246;
				string text4 = text3;
				IL_294E:
				num2 = 247;
				text3 = text2;
				IL_2958:
				num2 = 248;
				text2 = text4;
				IL_2962:
				num2 = 250;
				array[44] = Class36.smethod_16(array2[0], num3 / 2.0, "墙柱纵筋");
				IL_2999:
				num2 = 251;
				array[45] = Class36.smethod_16(array2[1], num3 / 2.0, "墙柱纵筋");
				IL_29D0:
				num2 = 252;
				array[46] = Class36.smethod_16(array2[2], num3 / 2.0, "墙柱纵筋");
				IL_2A07:
				num2 = 253;
				num12 = 43;
				checked
				{
					do
					{
						IL_2A25:
						num2 = 254;
						CAD.ChangeLayer(array[num12], "钢筋");
						IL_2A13:
						num2 = 255;
						num12++;
					}
					while (num12 <= 46);
					IL_2A46:
					num2 = 256;
					array[47] = CAD.AddLine(array2[0], array2[3], "0").ObjectId;
					IL_2A83:
					num2 = 257;
					array[48] = CAD.AddLine(array2[1], array2[4], "0").ObjectId;
					IL_2AC0:
					num2 = 258;
					array[49] = CAD.AddLine(array2[2], array2[5], "0").ObjectId;
					IL_2AFD:
					num2 = 259;
					array[50] = CAD.AddLine(array2[5], array2[6], "0").ObjectId;
					IL_2B3A:
					num2 = 260;
				}
				array[51] = Class36.smethod_23(CAD.GetPointXY(array2[6], 10.0, 10.0), text2, 300.0 * (num3 / 100.0), 0, "");
				IL_2B95:
				num2 = 261;
				array[52] = CAD.AddLine(array2[7], array2[8], "0").ObjectId;
				IL_2BD2:
				num2 = 262;
				array[53] = CAD.AddLine(array2[8], array2[9], "0").ObjectId;
				IL_2C10:
				num2 = 263;
				array[51] = Class36.smethod_23(CAD.GetPointXY(array2[9], 10.0, 10.0), text2, 300.0 * (num3 / 100.0), 0, "");
				IL_2C6C:
				num2 = 264;
				array2 = new Point3d[4];
				IL_2C7A:
				num2 = 267;
				Polyline polyline = new Polyline();
				IL_2C87:
				num2 = 268;
				if (num8 < num9)
				{
					goto IL_2CB9;
				}
				IL_2C98:
				num2 = 269;
				Polyline polyline2;
				int num17;
				checked
				{
					num6 = (int)Math.Round(unchecked(point3d2.Y + 75.0));
					goto IL_2CDE;
					IL_2CB9:
					num2 = 271;
					IL_2CBF:
					num2 = 272;
					num6 = (int)Math.Round(unchecked(point3d2.Y + 95.0));
					IL_2CDE:
					num2 = 274;
					polyline2 = polyline;
					num17 = 0;
				}
				Point2d point2d;
				point2d..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, point.Y + 100.0 + (double)num15 + (double)num16 + 500.0);
				polyline2.AddVertexAt(num17, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_2D65:
				num2 = 275;
				Polyline polyline3 = polyline;
				int num18 = 1;
				point2d..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 25)));
				polyline3.AddVertexAt(num18, point2d, -Math.Tan(Math.Atan(1.0) * 2.0 / 4.0), 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_2DEE:
				num2 = 276;
				Polyline polyline4 = polyline;
				int num19 = 2;
				point2d..ctor(point.X - (double)(checked(num4 - 80)) / 2.0 - 25.0, (double)num6);
				polyline4.AddVertexAt(num19, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_2E5F:
				num2 = 277;
				Polyline polyline5 = polyline;
				int num20 = 3;
				point2d..ctor(point.X - (double)(checked(num4 - 80)) / 2.0 - 200.0, (double)num6);
				polyline5.AddVertexAt(num20, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_2ED0:
				num2 = 278;
				array[55] = CAD.AddEnt(polyline).ObjectId;
				IL_2EF0:
				num2 = 279;
				polyline = new Polyline();
				IL_2EFD:
				num2 = 280;
				Polyline polyline6 = polyline;
				int num21 = 0;
				point2d..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, point.Y + 100.0 + (double)num15 + (double)num16 + 500.0);
				polyline6.AddVertexAt(num21, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_2F84:
				num2 = 281;
				Polyline polyline7 = polyline;
				int num22 = 1;
				point2d..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 25)));
				polyline7.AddVertexAt(num22, point2d, Math.Tan(Math.Atan(1.0) * 2.0 / 4.0), 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_300C:
				num2 = 282;
				Polyline polyline8 = polyline;
				int num23 = 2;
				point2d..ctor(point.X + (double)(checked(num4 - 80)) / 2.0 + 25.0, (double)num6);
				polyline8.AddVertexAt(num23, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_307D:
				num2 = 283;
				Polyline polyline9 = polyline;
				int num24 = 3;
				point2d..ctor(point.X + (double)(checked(num4 - 80)) / 2.0 + 200.0, (double)num6);
				polyline9.AddVertexAt(num24, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_30EE:
				num2 = 284;
				array[56] = CAD.AddEnt(polyline).ObjectId;
				IL_310E:
				num2 = 285;
				polyline = new Polyline();
				IL_311B:
				num2 = 286;
				Polyline polyline10 = polyline;
				int num25 = 0;
				point2d..ctor(point.X, point.Y + 100.0 + (double)num15 + (double)num16 + 500.0);
				polyline10.AddVertexAt(num25, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_3191:
				num2 = 287;
				Polyline polyline11 = polyline;
				int num26 = 1;
				point2d..ctor(point.X, (double)(checked(num6 + 25)));
				polyline11.AddVertexAt(num26, point2d, Math.Tan(Math.Atan(1.0) * 2.0 / 4.0), 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_3208:
				num2 = 288;
				Polyline polyline12 = polyline;
				int num27 = 2;
				point2d..ctor(point.X + 25.0, (double)num6);
				polyline12.AddVertexAt(num27, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_3268:
				num2 = 289;
				Polyline polyline13 = polyline;
				int num28 = 3;
				point2d..ctor(point.X + 200.0, (double)num6);
				polyline13.AddVertexAt(num28, point2d, 0.0, 50.0 / (100.0 / num3), 50.0 / (100.0 / num3));
				IL_32C8:
				num2 = 290;
				array[57] = CAD.AddEnt(polyline).ObjectId;
				IL_32E8:
				num2 = 291;
				array2 = new Point3d[2];
				IL_32F6:
				num2 = 294;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 50)), 0.0);
				IL_3330:
				num2 = 295;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 50)), 0.0);
				IL_336A:
				num2 = 296;
				array[58] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_33A6:
				num2 = 297;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 150)), 0.0);
				IL_33E3:
				num2 = 298;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 150)), 0.0);
				IL_3420:
				num2 = 299;
				array[59] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_345C:
				num2 = 300;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 250)), 0.0);
				IL_3499:
				num2 = 301;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 250)), 0.0);
				IL_34D6:
				num2 = 302;
				array[60] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_3512:
				num2 = 303;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 350)), 0.0);
				IL_354F:
				num2 = 304;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 350)), 0.0);
				IL_358C:
				num2 = 305;
				array[61] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_35C8:
				num2 = 306;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 450)), 0.0);
				IL_3605:
				num2 = 307;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 450)), 0.0);
				IL_3642:
				num2 = 308;
				array[62] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_367E:
				num2 = 309;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 550)), 0.0);
				IL_36BB:
				num2 = 310;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 550)), 0.0);
				IL_36F8:
				num2 = 311;
				array[63] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_3734:
				num2 = 312;
				array2[0]..ctor(point.X - (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 650)), 0.0);
				IL_3771:
				num2 = 313;
				array2[1]..ctor(point.X + (double)(checked(num4 - 80)) / 2.0, (double)(checked(num6 + 650)), 0.0);
				IL_37AE:
				num2 = 314;
				array[64] = CAD.AddPline(array2, 50.0 / (100.0 / num3), false, "").ObjectId;
				IL_37EA:
				num2 = 315;
				num12 = 55;
				checked
				{
					do
					{
						IL_3808:
						num2 = 316;
						CAD.ChangeLayer(array[num12], "钢筋");
						IL_37F6:
						num2 = 317;
						num12++;
					}
					while (num12 <= 64);
					IL_3829:
					num2 = 318;
				}
				pointXY = CAD.GetPointXY(point, (double)num8 / 2.0 + 100.0 + 200.0 * (num3 / 25.0), 100.0);
				IL_386F:
				num2 = 319;
				array[65] = Class36.smethod_81(pointXY, 1, num3 / 100.0).ObjectId;
				IL_389C:
				num2 = 320;
				pointXY = CAD.GetPointXY(pointXY, 200.0 * (num3 / 100.0), 200.0 * (num3 / 100.0) + 50.0);
				IL_38E1:
				num2 = 321;
				array[66] = Class36.smethod_23(pointXY, this.TextBox9.Text, 300.0 * (num3 / 100.0), 0, "");
				IL_3923:
				num2 = 322;
				array2 = new Point3d[3];
				IL_3931:
				num2 = 325;
				array2[0]..ctor(point.X + (double)num4 / 2.0 - 50.0, point.Y + 100.0 + (double)num15 + (double)num16 + 250.0, 0.0);
				IL_398F:
				num2 = 326;
				array2[1]..ctor(point.X + (double)num4 / 2.0 + 100.0, point.Y + 100.0 + (double)num15 + (double)num16 + 275.0, 0.0);
				IL_39ED:
				num2 = 327;
				array2[2]..ctor(point.X + (double)num4 / 2.0 + 100.0 + 1800.0 * (num3 / 100.0), point.Y + 100.0 + (double)num15 + (double)num16 + 250.0, 0.0);
				IL_3A62:
				num2 = 328;
				array[67] = CAD.AddLine(array2[0], array2[2], "0").ObjectId;
				IL_3A9F:
				num2 = 329;
				array[68] = Class36.smethod_23(array2[1], "柱纵筋和箍筋另详", 300.0 * (num3 / 100.0), 0, "");
				IL_3AE6:
				num2 = 330;
				documentLock.Dispose();
				IL_3AF3:
				num2 = 331;
				this.Close();
				IL_3AFF:
				num2 = 332;
				if (Information.Err().Number <= 0)
				{
					goto IL_3B2C;
				}
				IL_3B14:
				num2 = 333;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_3B2C:
				goto IL_40C8;
				IL_3B31:
				goto IL_40D3;
				IL_3B36:
				num29 = num2;
				if (num <= -2)
				{
					goto IL_3B51;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_40A2;
				IL_3B51:
				int num30 = num29 + 1;
				num29 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num30);
				IL_40A2:
				goto IL_40D3;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num29 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_3B36;
			}
			IL_40C8:
			if (num29 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_40D3:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("GroupBox2")]
		private GroupBox _GroupBox2;

		[AccessedThroughProperty("TextBox7")]
		private TextBox _TextBox7;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("GroupBox3")]
		private GroupBox _GroupBox3;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("GroupBox4")]
		private GroupBox _GroupBox4;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("Label5")]
		private Label _Label5;

		[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("GroupBox5")]
		private GroupBox _GroupBox5;

		[AccessedThroughProperty("TextBox8")]
		private TextBox _TextBox8;

		[AccessedThroughProperty("TextBox9")]
		private TextBox _TextBox9;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("Label7")]
		private Label _Label7;

		[AccessedThroughProperty("GroupBox6")]
		private GroupBox _GroupBox6;

		[AccessedThroughProperty("TextBox11")]
		private TextBox textBox_0;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("TextBox10")]
		private TextBox textBox_1;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("TextBox12")]
		private TextBox textBox_2;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("ComboBox2")]
		private ComboBox _ComboBox2;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("TextBox14")]
		private TextBox textBox_3;

		[AccessedThroughProperty("Label15")]
		private Label _Label15;

		[AccessedThroughProperty("ToolTip1")]
		private ToolTip toolTip_0;

		[AccessedThroughProperty("TextBox15")]
		private TextBox textBox_4;

		[AccessedThroughProperty("Label16")]
		private Label _Label16;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;
	}
}
