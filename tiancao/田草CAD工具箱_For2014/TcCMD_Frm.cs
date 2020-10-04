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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public class TcCMD_Frm : UserControl
	{
		[DebuggerNonUserCode]
		static TcCMD_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcCMD_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcCMD_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcCMD_Frm.list_0.Count == TcCMD_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcCMD_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcCMD_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcCMD_Frm.list_0[num] = TcCMD_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcCMD_Frm.list_0.RemoveRange(num, TcCMD_Frm.list_0.Count - num);
						TcCMD_Frm.list_0.Capacity = TcCMD_Frm.list_0.Count;
					}
					TcCMD_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TcCMD_Frm));
			this.TreeView1 = new TreeView();
			this.HScrollBar_0 = new HScrollBar();
			this.Button6 = new Button();
			this.Splitter1 = new Splitter();
			this.Button5 = new Button();
			this.Button4 = new Button();
			this.Button3 = new Button();
			this.Button2 = new Button();
			this.Button1 = new Button();
			this.SuspendLayout();
			this.TreeView1.AllowDrop = true;
			this.TreeView1.Dock = DockStyle.Left;
			this.TreeView1.LabelEdit = true;
			Control treeView = this.TreeView1;
			Point location = new Point(0, 0);
			treeView.Location = location;
			Control treeView2 = this.TreeView1;
			Padding margin = new Padding(4);
			treeView2.Margin = margin;
			this.TreeView1.Name = "TreeView1";
			Control treeView3 = this.TreeView1;
			Size size = new Size(143, 341);
			treeView3.Size = size;
			this.TreeView1.TabIndex = 0;
			this.HScrollBar_0.Dock = DockStyle.Bottom;
			Control control = this.HScrollBar_0;
			location = new Point(143, 295);
			control.Location = location;
			this.HScrollBar_0.Minimum = 10;
			this.HScrollBar_0.Name = "HScrollBar1";
			Control control2 = this.HScrollBar_0;
			size = new Size(113, 16);
			control2.Size = size;
			this.HScrollBar_0.SmallChange = 5;
			this.HScrollBar_0.TabIndex = 9;
			this.HScrollBar_0.Value = 100;
			this.Button6.Dock = DockStyle.Top;
			this.Button6.Image = (Image)componentResourceManager.GetObject("Button6.Image");
			this.Button6.ImageAlign = ContentAlignment.MiddleLeft;
			Control button = this.Button6;
			location = new Point(143, 120);
			button.Location = location;
			Control button2 = this.Button6;
			margin = new Padding(4);
			button2.Margin = margin;
			Control button3 = this.Button6;
			size = new Size(133, 0);
			button3.MinimumSize = size;
			this.Button6.Name = "Button6";
			Control button4 = this.Button6;
			size = new Size(133, 30);
			button4.Size = size;
			this.Button6.TabIndex = 10;
			this.Button6.Text = "添加根目录";
			this.Button6.TextAlign = ContentAlignment.MiddleRight;
			this.Button6.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.Button6.UseVisualStyleBackColor = true;
			Control splitter = this.Splitter1;
			location = new Point(143, 150);
			splitter.Location = location;
			Control splitter2 = this.Splitter1;
			margin = new Padding(4);
			splitter2.Margin = margin;
			this.Splitter1.Name = "Splitter1";
			Control splitter3 = this.Splitter1;
			size = new Size(4, 145);
			splitter3.Size = size;
			this.Splitter1.TabIndex = 11;
			this.Splitter1.TabStop = false;
			this.Button5.Dock = DockStyle.Bottom;
			this.Button5.Image = (Image)componentResourceManager.GetObject("Button5.Image");
			this.Button5.ImageAlign = ContentAlignment.MiddleLeft;
			Control button5 = this.Button5;
			location = new Point(143, 311);
			button5.Location = location;
			Control button6 = this.Button5;
			margin = new Padding(4);
			button6.Margin = margin;
			Control button7 = this.Button5;
			size = new Size(133, 0);
			button7.MinimumSize = size;
			this.Button5.Name = "Button5";
			Control button8 = this.Button5;
			size = new Size(133, 30);
			button8.Size = size;
			this.Button5.TabIndex = 5;
			this.Button5.Text = "合并";
			this.Button5.TextAlign = ContentAlignment.MiddleRight;
			this.Button5.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.Button5.UseVisualStyleBackColor = true;
			this.Button4.Dock = DockStyle.Top;
			this.Button4.Image = (Image)componentResourceManager.GetObject("Button4.Image");
			this.Button4.ImageAlign = ContentAlignment.MiddleLeft;
			Control button9 = this.Button4;
			location = new Point(143, 90);
			button9.Location = location;
			Control button10 = this.Button4;
			margin = new Padding(4);
			button10.Margin = margin;
			Control button11 = this.Button4;
			size = new Size(133, 0);
			button11.MinimumSize = size;
			this.Button4.Name = "Button4";
			Control button12 = this.Button4;
			size = new Size(133, 30);
			button12.Size = size;
			this.Button4.TabIndex = 4;
			this.Button4.Text = "保存";
			this.Button4.TextAlign = ContentAlignment.MiddleRight;
			this.Button4.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.Button4.UseVisualStyleBackColor = true;
			this.Button3.Dock = DockStyle.Top;
			this.Button3.Image = (Image)componentResourceManager.GetObject("Button3.Image");
			this.Button3.ImageAlign = ContentAlignment.MiddleLeft;
			Control button13 = this.Button3;
			location = new Point(143, 60);
			button13.Location = location;
			Control button14 = this.Button3;
			margin = new Padding(4);
			button14.Margin = margin;
			Control button15 = this.Button3;
			size = new Size(133, 0);
			button15.MinimumSize = size;
			this.Button3.Name = "Button3";
			Control button16 = this.Button3;
			size = new Size(133, 30);
			button16.Size = size;
			this.Button3.TabIndex = 3;
			this.Button3.Text = "删除";
			this.Button3.TextAlign = ContentAlignment.MiddleLeft;
			this.Button3.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.Button3.UseVisualStyleBackColor = true;
			this.Button2.Dock = DockStyle.Top;
			this.Button2.Image = (Image)componentResourceManager.GetObject("Button2.Image");
			this.Button2.ImageAlign = ContentAlignment.MiddleLeft;
			Control button17 = this.Button2;
			location = new Point(143, 30);
			button17.Location = location;
			Control button18 = this.Button2;
			margin = new Padding(4);
			button18.Margin = margin;
			Control button19 = this.Button2;
			size = new Size(133, 0);
			button19.MinimumSize = size;
			this.Button2.Name = "Button2";
			Control button20 = this.Button2;
			size = new Size(133, 30);
			button20.Size = size;
			this.Button2.TabIndex = 2;
			this.Button2.Text = "添加";
			this.Button2.TextAlign = ContentAlignment.MiddleLeft;
			this.Button2.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.Button2.UseVisualStyleBackColor = true;
			this.Button1.Dock = DockStyle.Top;
			this.Button1.Image = (Image)componentResourceManager.GetObject("Button1.Image");
			this.Button1.ImageAlign = ContentAlignment.MiddleLeft;
			Control button21 = this.Button1;
			location = new Point(143, 0);
			button21.Location = location;
			Control button22 = this.Button1;
			margin = new Padding(4);
			button22.Margin = margin;
			Control button23 = this.Button1;
			size = new Size(133, 0);
			button23.MinimumSize = size;
			this.Button1.Name = "Button1";
			Control button24 = this.Button1;
			size = new Size(133, 30);
			button24.Size = size;
			this.Button1.TabIndex = 1;
			this.Button1.Text = "运行";
			this.Button1.TextAlign = ContentAlignment.MiddleLeft;
			this.Button1.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.Button1.UseVisualStyleBackColor = true;
			SizeF autoScaleDimensions = new SizeF(8f, 15f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.Splitter1);
			this.Controls.Add(this.Button6);
			this.Controls.Add(this.HScrollBar_0);
			this.Controls.Add(this.Button5);
			this.Controls.Add(this.Button4);
			this.Controls.Add(this.Button3);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.TreeView1);
			margin = new Padding(4);
			this.Margin = margin;
			this.Name = "TcCMD_Frm";
			size = new Size(256, 341);
			this.Size = size;
			this.ResumeLayout(false);
		}

		internal virtual TreeView TreeView1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TreeView1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				DragEventHandler value2 = new DragEventHandler(this.method_4);
				NodeLabelEditEventHandler value3 = new NodeLabelEditEventHandler(this.method_0);
				DragEventHandler value4 = new DragEventHandler(this.method_3);
				ItemDragEventHandler value5 = new ItemDragEventHandler(this.method_2);
				EventHandler value6 = new EventHandler(this.method_1);
				DragEventHandler value7 = new DragEventHandler(this.method_5);
				if (this._TreeView1 != null)
				{
					this._TreeView1.DragOver -= value2;
					this._TreeView1.AfterLabelEdit -= value3;
					this._TreeView1.DragEnter -= value4;
					this._TreeView1.ItemDrag -= value5;
					this._TreeView1.DoubleClick -= value6;
					this._TreeView1.DragDrop -= value7;
				}
				this._TreeView1 = value;
				if (this._TreeView1 != null)
				{
					this._TreeView1.DragOver += value2;
					this._TreeView1.AfterLabelEdit += value3;
					this._TreeView1.DragEnter += value4;
					this._TreeView1.ItemDrag += value5;
					this._TreeView1.DoubleClick += value6;
					this._TreeView1.DragDrop += value7;
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

		internal virtual HScrollBar HScrollBar_0
		{
			[DebuggerNonUserCode]
			get
			{
				return this.hscrollBar_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				ScrollEventHandler value2 = new ScrollEventHandler(this.HScrollBar_0_Scroll);
				if (this.hscrollBar_0 != null)
				{
					this.hscrollBar_0.Scroll -= value2;
				}
				this.hscrollBar_0 = value;
				if (this.hscrollBar_0 != null)
				{
					this.hscrollBar_0.Scroll += value2;
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
				EventHandler value2 = new EventHandler(this.jipAtgRsh);
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

		internal virtual Splitter Splitter1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Splitter1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Splitter1 = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcCMD_Frm_Load(object sender, EventArgs e)
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			string text = directoryPath + "\\cmd.txt";
			if (!Microsoft.VisualBasic.FileIO.FileSystem.FileExists(text))
			{
				this.TreeView1.Nodes.Add("结构", "结构");
				this.TreeView1.Nodes.Add("建筑", "建筑");
				this.TreeView1.Nodes.Add("文字", "文字");
				this.TreeView1.Nodes.Add("输出", "输出");
				this.TreeView1.Nodes.Add("图库", "图库");
				this.TreeView1.Nodes.Add("关于", "关于");
			}
			else
			{
				this.ReadData(text);
			}
			this.TreeView1.CollapseAll();
			this.Button4.Enabled = false;
		}

		public short ReadData(string FilePath)
		{
			StreamReader streamReader = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileReader(FilePath);
			checked
			{
				while (!streamReader.EndOfStream)
				{
					string text = streamReader.ReadLine();
					int num = Strings.InStr(text, "=", CompareMethod.Binary);
					if (num != 0)
					{
						string text2 = text.Substring(0, num - 1);
						string text3 = text.Substring(num);
						int num2 = (int)this.inStr_n(text2, "\\");
						string text4 = "";
						if (num2 == 1)
						{
							this.TreeView1.Nodes.Add(text2, text3.Substring(0, text3.Length - 1));
						}
						else
						{
							string text5 = text2;
							string text6 = text3;
							int num3 = 1;
							int num4 = num2;
							num = num3;
							for (;;)
							{
								int num5 = num;
								int num6 = num4;
								if (num5 > num6)
								{
									break;
								}
								TreeNodeCollection nodes = this.TreeView1.Nodes;
								string str = text5.Substring(0, Strings.InStr(text5, "\\", CompareMethod.Binary));
								string text7 = text6.Substring(0, Strings.InStr(text6, "\\", CompareMethod.Binary) - 1);
								text4 += str;
								if (num == num2)
								{
									string text8 = text4.Substring(0, text4.Length - 1);
									string key = text8.Substring(0, Strings.InStrRev(text8, "\\", -1, CompareMethod.Binary));
									this.GetNodeByeKey(nodes, key);
									this.TreeView1.SelectedNode.Nodes.Add(text4, text7);
								}
								text5 = text5.Substring(Strings.InStr(text5, "\\", CompareMethod.Binary), text5.Length - Strings.InStr(text5, "\\", CompareMethod.Binary));
								text6 = text6.Substring(Strings.InStr(text6, "\\", CompareMethod.Binary), text6.Length - Strings.InStr(text6, "\\", CompareMethod.Binary));
								num++;
							}
						}
					}
				}
				streamReader.Close();
				short result;
				return result;
			}
		}

		public short SaveData(string FilePath)
		{
			this.TreeView1.Update();
			StreamWriter streamWriter = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileWriter(FilePath, false);
			TreeNodeCollection nodes = this.TreeView1.Nodes;
			string[] array = new string[1];
			this.GetNode(nodes, ref array);
			long num = (long)Information.UBound(array, 1);
			long num2 = 0L;
			long num3 = num;
			long num4 = num2;
			checked
			{
				for (;;)
				{
					long num5 = num4;
					long num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					streamWriter.WriteLine(array[(int)num4]);
					num4 += 1L;
				}
				streamWriter.Close();
				short result;
				return result;
			}
		}

		public long inStr_n(string Str, string StrIn)
		{
			long num = 0L;
			long num2 = (long)(checked(Strings.Len(Str) - 1));
			long num3 = num;
			checked
			{
				long num6;
				for (;;)
				{
					long num4 = num3;
					long num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string left = Str.Substring((int)num3, 1);
					if (Operators.CompareString(left, StrIn, false) == 0)
					{
						num6 += 1L;
					}
					num3 += 1L;
				}
				return num6;
			}
		}

		public bool CheckKey(TreeNodeCollection TC, string Key)
		{
			bool result;
			try
			{
				foreach (object obj in TC)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (Operators.CompareString(treeNode.Name, Key, false) == 0)
					{
						result = true;
						this.CheckKey(treeNode.Nodes, Key);
						return result;
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
			result = false;
			return result;
		}

		public void GetNode(TreeNodeCollection TC, ref string[] DataString)
		{
			try
			{
				foreach (object obj in TC)
				{
					TreeNode treeNode = (TreeNode)obj;
					long num = (long)Information.UBound(DataString, 1);
					checked
					{
						DataString = (string[])Utils.CopyArray((Array)DataString, new string[(int)(num + 1L) + 1]);
						DataString[(int)(num + 1L)] = treeNode.Name + "=" + treeNode.FullPath + "\\";
						this.int_0++;
						this.GetNode(treeNode.Nodes, ref DataString);
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

		public void GetNodeByeKey(TreeNodeCollection TC, string Key)
		{
			try
			{
				foreach (object obj in TC)
				{
					TreeNode treeNode = (TreeNode)obj;
					if (Operators.CompareString(treeNode.Name, Key, false) == 0)
					{
						this.TreeView1.SelectedNode = treeNode;
						break;
					}
					this.GetNodeByeKey(treeNode.Nodes, Key);
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

		private void Button3_Click(object sender, EventArgs e)
		{
			short num = checked((short)Interaction.MsgBox("你是否确定要删除该条命令", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版---命令管理"));
			if (num == 1)
			{
				this.TreeView1.Nodes.Remove(this.TreeView1.SelectedNode);
				this.Button4.Enabled = true;
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			string text = Interaction.InputBox("请输入你要添加的内容:\n\n    不得包含\"\\\"、\"/\"和\"=\"等限制字符。\n命令添加说明:命令描述@命令代码", "田草CAD工具箱.Net版", "", -1, -1);
			checked
			{
				if (Operators.CompareString(text, "", false) != 0)
				{
					if (Strings.InStr(text, "@", CompareMethod.Binary) > 0 & Strings.InStr(text, "@", CompareMethod.Binary) < text.Length)
					{
						if (Operators.CompareString(text, "", false) != 0)
						{
							Interaction.MsgBox(text, MsgBoxStyle.OkOnly, null);
							string name = this.TreeView1.SelectedNode.Name;
							int num = (int)this.inStr_n(name, "\\");
							string str = Conversions.ToString(Strings.Chr(64 + num + 1));
							string key = name + str + NF.Time2String() + "\\";
							this.TreeView1.SelectedNode.Nodes.Add(key, text);
						}
						this.Button4.Enabled = true;
					}
					if (Information.Err().Number != 0)
					{
						Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button4_Click(object sender, EventArgs e)
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			string filePath = directoryPath + "\\cmd.txt";
			this.SaveData(filePath);
			this.Button4.Enabled = false;
		}

		private void method_0(object sender, NodeLabelEditEventArgs e)
		{
			this.Button4.Enabled = true;
		}

		private void method_1(object sender, EventArgs e)
		{
			this.Button1.PerformClick();
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			this.TreeView1.CollapseAll();
		}

		private void Button1_Click(object sender, EventArgs e)
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
				string text = this.TreeView1.SelectedNode.Text;
				IL_1C:
				num2 = 3;
				if (Strings.InStr(text, "@", CompareMethod.Binary) == 0)
				{
					goto IL_86;
				}
				IL_32:
				num2 = 4;
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_4E:
				num2 = 5;
				text = text.Substring(Strings.InStr(text, "@", CompareMethod.Binary)) + "\n";
				IL_6D:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_7A:
				num2 = 7;
				mdiActiveDocument.SendStringToExecute(text, true, false, true);
				IL_86:
				goto IL_102;
				IL_88:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_BC:
				goto IL_F7;
				IL_BE:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_88;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_D4:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_BE;
			}
			IL_F7:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_102:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void jipAtgRsh(object sender, EventArgs e)
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
				string text = Interaction.InputBox("请输入你要添加的分类:\n\n    不得包含\"\\\"、\"/\"和\"=\"等限制字符。\n命令添加说明:命令描述@命令代码", "田草CAD工具箱.Net版", "", -1, -1);
				IL_22:
				num2 = 3;
				string key = "A" + NF.Time2String() + "\\";
				IL_3A:
				num2 = 4;
				if (Operators.CompareString(text, "", false) != 0)
				{
					goto IL_52;
				}
				IL_4D:
				goto IL_E7;
				IL_52:
				num2 = 7;
				this.TreeView1.Nodes.Add(key, text);
				IL_68:
				num2 = 8;
				this.Button4.Enabled = true;
				IL_76:
				goto IL_E7;
				IL_78:
				goto IL_F1;
				IL_7A:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_91;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_C5;
				IL_91:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_C5:
				goto IL_F1;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_7A;
			}
			IL_E7:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_F1:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void HScrollBar_0_Scroll(object sender, ScrollEventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			string str = this.HScrollBar_0.Value.ToString();
			mdiActiveDocument.SendStringToExecute("cmdtm " + str + " ", true, false, true);
		}

		private void method_2(object sender, ItemDragEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.DoDragDrop(RuntimeHelpers.GetObjectValue(e.Item), DragDropEffects.Move);
				this.Button4.Enabled = true;
			}
			else if (e.Button != MouseButtons.Right)
			{
			}
		}

		private void method_3(object sender, DragEventArgs e)
		{
			e.Effect = e.AllowedEffect;
		}

		private void method_4(object sender, DragEventArgs e)
		{
			Control treeView = this.TreeView1;
			Point p = new Point(e.X, e.Y);
			Point pt = treeView.PointToClient(p);
			this.TreeView1.SelectedNode = this.TreeView1.GetNodeAt(pt);
		}

		private void method_5(object sender, DragEventArgs e)
		{
			Control treeView = this.TreeView1;
			Point p = new Point(e.X, e.Y);
			Point pt = treeView.PointToClient(p);
			TreeNode nodeAt = this.TreeView1.GetNodeAt(pt);
			TreeNode treeNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
			if (!treeNode.Equals(nodeAt) && !this.method_6(treeNode, nodeAt))
			{
				if (e.Effect == DragDropEffects.Move)
				{
					treeNode.Remove();
					nodeAt.Nodes.Add(treeNode);
				}
				else if (e.Effect == DragDropEffects.Copy)
				{
					nodeAt.Nodes.Add((TreeNode)treeNode.Clone());
				}
				nodeAt.Expand();
			}
		}

		private bool method_6(TreeNode treeNode_0, TreeNode treeNode_1)
		{
			return treeNode_1.Parent != null && (treeNode_1.Parent.Equals(treeNode_0) || this.method_6(treeNode_0, treeNode_1.Parent));
		}

		public TcCMD_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcCMD_Frm_Load;
			TcCMD_Frm.smethod_0(this);
			this.int_0 = 0;
			this.InitializeComponent();
		}

		protected override void Finalize()
		{
			base.Finalize();
		}

		private static List<WeakReference> list_0;

		private IContainer icontainer_0;

		[AccessedThroughProperty("TreeView1")]
		private TreeView _TreeView1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("HScrollBar1")]
		private HScrollBar hscrollBar_0;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Splitter1")]
		private Splitter _Splitter1;

		private int int_0;
	}
}
