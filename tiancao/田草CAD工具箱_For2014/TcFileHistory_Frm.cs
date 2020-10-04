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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcFileHistory_Frm : Form
	{
		[DebuggerNonUserCode]
		static TcFileHistory_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcFileHistory_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcFileHistory_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcFileHistory_Frm_Load;
			TcFileHistory_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcFileHistory_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcFileHistory_Frm.list_0.Count == TcFileHistory_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcFileHistory_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcFileHistory_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcFileHistory_Frm.list_0[num] = TcFileHistory_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcFileHistory_Frm.list_0.RemoveRange(num, TcFileHistory_Frm.list_0.Count - num);
						TcFileHistory_Frm.list_0.Capacity = TcFileHistory_Frm.list_0.Count;
					}
					TcFileHistory_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual SplitContainer SplitContainer1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._SplitContainer1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitContainer1 = value;
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
				EventHandler value2 = new EventHandler(this.method_1);
				KeyEventHandler value3 = new KeyEventHandler(this.method_0);
				if (this._TextBox1 != null)
				{
					this._TextBox1.TextChanged -= value2;
					this._TextBox1.KeyDown -= value3;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.TextChanged += value2;
					this._TextBox1.KeyDown += value3;
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

		internal virtual ListView ListView1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListView1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler value2 = new MouseEventHandler(this.method_4);
				EventHandler value3 = new EventHandler(this.method_3);
				ColumnClickEventHandler value4 = new ColumnClickEventHandler(this.method_2);
				if (this._ListView1 != null)
				{
					this._ListView1.MouseUp -= value2;
					this._ListView1.DoubleClick -= value3;
					this._ListView1.ColumnClick -= value4;
				}
				this._ListView1 = value;
				if (this._ListView1 != null)
				{
					this._ListView1.MouseUp += value2;
					this._ListView1.DoubleClick += value3;
					this._ListView1.ColumnClick += value4;
				}
			}
		}

		internal virtual ColumnHeader ColumnHeader1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.columnHeader_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.columnHeader_0 = value;
			}
		}

		internal virtual ColumnHeader ColumnHeader2
		{
			[DebuggerNonUserCode]
			get
			{
				return this.columnHeader_1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.columnHeader_1 = value;
			}
		}

		internal virtual ColumnHeader ColumnHeader3
		{
			[DebuggerNonUserCode]
			get
			{
				return this.columnHeader_2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.columnHeader_2 = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcFileHistory_Frm_Load(object sender, EventArgs e)
		{
			try
			{
				string setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", "");
				if (Operators.CompareString(setting, "ON", false) == 0)
				{
					string text = Class33.Class31_0.Info.DirectoryPath + "/Data/FileHistory.txt";
					if (NF.FileExist(text))
					{
						this.arrayList_0 = new ArrayList();
						NF.ReadTxtFile(text, ref this.arrayList_0);
						short num = checked((short)(this.arrayList_0.Count - 1));
						for (short num2 = num; num2 >= 0; num2 += -1)
						{
							if (NF.FileExist(Conversions.ToString(this.arrayList_0[(int)num2])))
							{
								FileInfo fileInfo = new FileInfo(Conversions.ToString(this.arrayList_0[(int)num2]));
								ListViewItem listViewItem = new ListViewItem();
								listViewItem.Text = fileInfo.Name;
								double num3 = (double)fileInfo.Length / 1024.0;
								DateTime lastWriteTime = fileInfo.LastWriteTime;
								listViewItem.SubItems.AddRange(new string[]
								{
									lastWriteTime.ToString(),
									fileInfo.FullName
								});
								this.ListView1.Items.Add(listViewItem);
							}
						}
					}
					else
					{
						NF.CreateTxtFile(text);
					}
				}
				else
				{
					short num4 = checked((short)Interaction.MsgBox("是否开启无限自动保存历史记录功能?", MsgBoxStyle.YesNo, "无限自动保存历史记录"));
					if (num4 == 6)
					{
						Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", "ON");
					}
					else if (num4 == 7)
					{
						Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", "OFF");
					}
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("FileHistory_Frm_Load:" + ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		private void method_0(object sender, KeyEventArgs e)
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
				if (e.KeyCode != Keys.Return)
				{
					goto IL_63;
				}
				IL_17:
				num2 = 3;
				this.Hide();
				IL_1F:
				num2 = 4;
				string text = this.TextBox1.Text;
				IL_2D:
				num2 = 5;
				DocumentCollectionExtension.Open(Application.DocumentManager, text, false);
				IL_3C:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_57;
				}
				IL_4D:
				num2 = 7;
				this.Show();
				goto IL_63;
				IL_57:
				num2 = 9;
				IL_5A:
				num2 = 10;
				this.Close();
				IL_63:
				goto IL_EA;
				IL_68:
				goto IL_F4;
				IL_6D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_84;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_C8;
				IL_84:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_C8:
				goto IL_F4;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_6D;
			}
			IL_EA:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_F4:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.DefaultExt = "DWG";
			openFileDialog.Multiselect = true;
			openFileDialog.Title = "选择DWG文件";
			openFileDialog.Filter = "AutoCAD文件(*.Dwg)|*.DWG|DXF文件(*.DXF)|*.DXF";
			openFileDialog.DefaultExt = "*.dwg";
			openFileDialog.InitialDirectory = this.TextBox1.Text;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] fileNames = openFileDialog.FileNames;
				short num = 0;
				short num2 = checked((short)Information.UBound(fileNames, 1));
				short num3 = num;
				for (;;)
				{
					short num4 = num3;
					short num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					DocumentCollectionExtension.Open(Application.DocumentManager, fileNames[(int)num3], false);
					num3 += 1;
				}
				this.Close();
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			string value = this.TextBox1.Text.ToUpper();
			this.ListView1.Items.Clear();
			try
			{
				foreach (object value2 in this.arrayList_0)
				{
					string text = Conversions.ToString(value2);
					string text2 = text.ToUpper();
					if (text2.Contains(value))
					{
						FileInfo fileInfo = new FileInfo(text);
						ListViewItem listViewItem = new ListViewItem();
						listViewItem.Text = fileInfo.Name;
						double num = (double)fileInfo.Length / 1024.0;
						DateTime lastWriteTime = fileInfo.LastWriteTime;
						listViewItem.SubItems.AddRange(new string[]
						{
							lastWriteTime.ToString(),
							fileInfo.FullName
						});
						this.ListView1.Items.Add(listViewItem);
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

		public static void OpenFile(string F)
		{
			DocumentCollection documentManager = Application.DocumentManager;
			Document document = DocumentCollectionExtension.Open(Application.DocumentManager, F, false);
			Database database = document.Database;
			documentManager.MdiActiveDocument = document;
		}

		private void method_2(object sender, ColumnClickEventArgs e)
		{
			ColumnHeader columnHeader = (ColumnHeader)NewLateBinding.LateGet(sender, null, "Columns", new object[]
			{
				e.Column
			}, null, null, null);
			SortOrder sortOrder;
			if (this.columnHeader_3 == null)
			{
				sortOrder = SortOrder.Ascending;
			}
			else
			{
				if (columnHeader.Equals(this.columnHeader_3))
				{
					if (this.columnHeader_3.Text.EndsWith("  ▲"))
					{
						sortOrder = SortOrder.Descending;
					}
					else
					{
						sortOrder = SortOrder.Ascending;
					}
				}
				else
				{
					sortOrder = SortOrder.Ascending;
				}
				this.columnHeader_3.Text = this.columnHeader_3.Text.Substring(0, checked(this.columnHeader_3.Text.Length - 3));
			}
			this.columnHeader_3 = columnHeader;
			if (sortOrder == SortOrder.Ascending)
			{
				ColumnHeader columnHeader2 = this.columnHeader_3;
				columnHeader2.Text += "  ▲";
			}
			else
			{
				ColumnHeader columnHeader2 = this.columnHeader_3;
				columnHeader2.Text += "  ▼";
			}
			NewLateBinding.LateSet(sender, null, "ListViewItemSorter", new object[]
			{
				new clsListviewSorter(e.Column, sortOrder)
			}, null, null);
			NewLateBinding.LateCall(sender, null, "Sort", new object[0], null, null, null, true);
		}

		private void method_3(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				ListView.SelectedListViewItemCollection selectedItems = this.ListView1.SelectedItems;
				IL_20:
				num2 = 4;
				IEnumerator enumerator = selectedItems.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ListViewItem listViewItem = (ListViewItem)enumerator.Current;
					IL_41:
					num2 = 5;
					string text = listViewItem.SubItems[2].Text;
					IL_55:
					num2 = 6;
					DocumentCollectionExtension.Open(Application.DocumentManager, text, false);
					IL_64:
					num2 = 7;
					if (Information.Err().Number > 0)
					{
						IL_75:
						num2 = 8;
						this.Show();
					}
					else
					{
						IL_7F:
						num2 = 10;
						IL_82:
						num2 = 11;
						this.Close();
					}
					IL_8B:
					num2 = 13;
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_AB:
				goto IL_13E;
				IL_B0:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_F8:
				goto IL_133;
				IL_FA:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_B0;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_110:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_FA;
			}
			IL_133:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_13E:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_4(object sender, MouseEventArgs e)
		{
			this.ListView1.MultiSelect = false;
			if (e.Button == MouseButtons.Right)
			{
				ListView.SelectedListViewItemCollection selectedItems = this.ListView1.SelectedItems;
				try
				{
					foreach (object obj in selectedItems)
					{
						ListViewItem listViewItem = (ListViewItem)obj;
						string text = listViewItem.SubItems[2].Text;
						text = text.Replace("/", "\\");
						text = text.Substring(0, Strings.InStrRev(text, "\\", -1, CompareMethod.Binary));
						this.TextBox1.Text = text;
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
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("SplitContainer1")]
		private SplitContainer _SplitContainer1;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("ListView1")]
		private ListView _ListView1;

		[AccessedThroughProperty("ColumnHeader1")]
		private ColumnHeader columnHeader_0;

		[AccessedThroughProperty("ColumnHeader2")]
		private ColumnHeader columnHeader_1;

		[AccessedThroughProperty("ColumnHeader3")]
		private ColumnHeader columnHeader_2;

		private ArrayList arrayList_0;

		private ColumnHeader columnHeader_3;
	}
}
