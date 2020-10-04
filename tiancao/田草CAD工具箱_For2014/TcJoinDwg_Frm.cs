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

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcJoinDwg_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcJoinDwg_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcJoinDwg_Frm.jipAtgRsh = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcJoinDwg_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcJoinDwg_Frm_Load;
			TcJoinDwg_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcJoinDwg_Frm.jipAtgRsh;
			checked
			{
				lock (obj)
				{
					if (TcJoinDwg_Frm.jipAtgRsh.Count == TcJoinDwg_Frm.jipAtgRsh.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcJoinDwg_Frm.jipAtgRsh.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcJoinDwg_Frm.jipAtgRsh[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcJoinDwg_Frm.jipAtgRsh[num] = TcJoinDwg_Frm.jipAtgRsh[num4];
								}
								num++;
							}
							num4++;
						}
						TcJoinDwg_Frm.jipAtgRsh.RemoveRange(num, TcJoinDwg_Frm.jipAtgRsh.Count - num);
						TcJoinDwg_Frm.jipAtgRsh.Capacity = TcJoinDwg_Frm.jipAtgRsh.Count;
					}
					TcJoinDwg_Frm.jipAtgRsh.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				EventHandler value2 = new EventHandler(this.method_2);
				DragEventHandler value3 = new DragEventHandler(this.method_4);
				DragEventHandler value4 = new DragEventHandler(this.method_3);
				if (this._ListBox1 != null)
				{
					this._ListBox1.DoubleClick -= value2;
					this._ListBox1.DragEnter -= value3;
					this._ListBox1.DragDrop -= value4;
				}
				this._ListBox1 = value;
				if (this._ListBox1 != null)
				{
					this._ListBox1.DoubleClick += value2;
					this._ListBox1.DragEnter += value3;
					this._ListBox1.DragDrop += value4;
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

		private void method_0(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void method_1(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void Button1_Click(object sender, EventArgs e)
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
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_1B:
				num2 = 3;
				new Database(false, true);
				IL_25:
				num2 = 4;
				Point3d point3d;
				point3d..ctor(0.0, 0.0, 0.0);
				IL_49:
				num2 = 5;
				double num3 = Conversions.ToDouble(this.TextBox2.Text);
				IL_5D:
				num2 = 6;
				short num4 = 0;
				short num5 = checked((short)(this.ListBox1.Items.Count - 1));
				short num6 = num4;
				for (;;)
				{
					short num7 = num6;
					short num8 = num5;
					if (num7 > num8)
					{
						break;
					}
					IL_78:
					num2 = 7;
					Application.DoEvents();
					IL_7F:
					num2 = 8;
					string text = Conversions.ToString(this.ListBox1.Items[(int)num6]);
					IL_99:
					num2 = 9;
					string string_ = text;
					Point3d point3d_;
					point3d_..ctor(point3d.X, point3d.Y + (double)num6 * num3, point3d.Z);
					Class36.smethod_87(string_, point3d_);
					IL_C8:
					num2 = 10;
					this.Label2.Text = "已经合并完成:" + text;
					IL_E2:
					num2 = 11;
					num6 += 1;
				}
				IL_F3:
				num2 = 12;
				documentLock.Dispose();
				IL_FC:
				num2 = 13;
				this.Label2.Text = "全部合并完成.";
				IL_10F:
				num2 = 14;
				if (Information.Err().Number <= 0)
				{
					goto IL_136;
				}
				IL_121:
				num2 = 15;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_136:
				goto IL_1D1;
				IL_13B:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_18B:
				goto IL_1C6;
				IL_18D:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_13B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1A3:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_18D;
			}
			IL_1C6:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1D1:
			if (num10 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button2_Click(object sender, EventArgs e)
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
				string setting = Interaction.GetSetting("TcJoinDwg", "TcJoinDwg_OPEN", "OPEN_PATH", "");
				IL_26:
				num2 = 3;
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				IL_2F:
				num2 = 4;
				folderBrowserDialog.Description = "TcJoinDwg";
				IL_3D:
				num2 = 5;
				folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
				IL_47:
				num2 = 6;
				this.TextBox1.Text = setting;
				IL_56:
				num2 = 7;
				if (Operators.CompareString(setting, "", false) != 0)
				{
					goto IL_84;
				}
				IL_6A:
				num2 = 8;
				folderBrowserDialog.SelectedPath = Class33.Class31_0.Info.DirectoryPath;
				goto IL_93;
				IL_84:
				num2 = 10;
				IL_87:
				num2 = 11;
				folderBrowserDialog.SelectedPath = setting;
				IL_93:
				num2 = 13;
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				IL_9E:
				num2 = 14;
				if (dialogResult != DialogResult.OK)
				{
					goto IL_178;
				}
				IL_AA:
				num2 = 15;
				this.ListBox1.Items.Clear();
				IL_BD:
				num2 = 16;
				this.TextBox1.Text = folderBrowserDialog.SelectedPath;
				IL_D2:
				num2 = 17;
				string text = this.TextBox1.Text;
				IL_E2:
				num2 = 18;
				string[] files = Directory.GetFiles(text);
				IL_EE:
				num2 = 19;
				string[] array = files;
				int i = 0;
				checked
				{
					while (i < array.Length)
					{
						string text2 = array[i];
						IL_FF:
						num2 = 20;
						FileInfo fileInfo = Class33.Class32_0.FileSystem.GetFileInfo(text2);
						IL_115:
						num2 = 21;
						if (Operators.CompareString(fileInfo.Extension.ToUpper(), ".DWG", false) == 0)
						{
							IL_134:
							num2 = 22;
							this.ListBox1.Items.Add(text2);
						}
						IL_14A:
						i++;
						IL_14E:
						num2 = 24;
					}
					IL_15A:
					num2 = 25;
					Interaction.SaveSetting("TcJoinDwg", "TcJoinDwg_OPEN", "OPEN_PATH", folderBrowserDialog.SelectedPath);
					IL_178:
					goto IL_242;
					IL_17D:;
				}
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1F9:
				goto IL_237;
				IL_1FB:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_17D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_214:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1FB;
			}
			IL_237:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_242:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_2(object sender, EventArgs e)
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
				int count = this.ListBox1.SelectedItems.Count;
				IL_1E:
				num2 = 3;
				int num3 = 0;
				checked
				{
					int num4 = count - 1;
					int num5 = num3;
					for (;;)
					{
						int num6 = num5;
						int num7 = num4;
						if (num6 > num7)
						{
							break;
						}
						IL_2A:
						num2 = 4;
						this.ListBox1.Items.Remove(RuntimeHelpers.GetObjectValue(this.ListBox1.SelectedItems[0]));
						IL_53:
						num2 = 5;
						num5++;
					}
					IL_60:
					goto IL_D1;
					IL_62:;
				}
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_8A:
				goto IL_C6;
				IL_8C:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_62;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_A3:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_8C;
			}
			IL_C6:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_D1:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_3(object sender, DragEventArgs e)
		{
			Array array = (Array)e.Data.GetData(DataFormats.FileDrop, true);
			try
			{
				foreach (object value in array)
				{
					string text = Conversions.ToString(value);
					if (File.Exists(text) && Operators.CompareString(text.Substring(checked(text.Length - 4), 4).ToUpper(), ".DWG", false) == 0 && !this.ListBox1.Items.Contains(text))
					{
						this.ListBox1.Items.Add(text);
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		private void method_4(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void TcJoinDwg_Frm_Load(object sender, EventArgs e)
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
				string setting = Interaction.GetSetting("TcJoinDwg", "TcJoinDwg_OPEN", "OPEN_PATH", "");
				IL_25:
				num2 = 3;
				this.TextBox1.Text = setting;
				IL_33:
				goto IL_97;
				IL_35:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_53:
				goto IL_8C;
				IL_55:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_35;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_6A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_55;
			}
			IL_8C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_97:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private static List<WeakReference> jipAtgRsh;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;
	}
}
