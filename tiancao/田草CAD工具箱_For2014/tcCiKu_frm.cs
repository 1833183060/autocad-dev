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
using Microsoft.VisualBasic.FileIO;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class tcCiKu_frm : Form
	{
		[DebuggerNonUserCode]
		static tcCiKu_frm()
		{
			Class39.k1QjQlczC5Jf5();
			tcCiKu_frm.list_0 = new List<WeakReference>();
		}

		public tcCiKu_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.tcCiKu_frm_Load;
			tcCiKu_frm.smethod_0(this);
			this.int_0 = 0;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = tcCiKu_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (tcCiKu_frm.list_0.Count == tcCiKu_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = tcCiKu_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = tcCiKu_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									tcCiKu_frm.list_0[num] = tcCiKu_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						tcCiKu_frm.list_0.RemoveRange(num, tcCiKu_frm.list_0.Count - num);
						tcCiKu_frm.list_0.Capacity = tcCiKu_frm.list_0.Count;
					}
					tcCiKu_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				TreeViewEventHandler value2 = new TreeViewEventHandler(this.method_1);
				NodeLabelEditEventHandler value3 = new NodeLabelEditEventHandler(this.method_0);
				if (this._TreeView1 != null)
				{
					this._TreeView1.AfterSelect -= value2;
					this._TreeView1.AfterLabelEdit -= value3;
				}
				this._TreeView1 = value;
				if (this._TreeView1 != null)
				{
					this._TreeView1.AfterSelect += value2;
					this._TreeView1.AfterLabelEdit += value3;
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

		internal virtual SplitContainer SplitContainer2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._SplitContainer2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitContainer2 = value;
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
				EventHandler value2 = new EventHandler(this.TextBox1_DoubleClick);
				if (this._TextBox1 != null)
				{
					this._TextBox1.DoubleClick -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.DoubleClick += value2;
				}
			}
		}

		internal virtual SplitContainer SplitContainer3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._SplitContainer3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitContainer3 = value;
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
				EventHandler value2 = new EventHandler(this.TextBox2_DoubleClick);
				if (this._TextBox2 != null)
				{
					this._TextBox2.DoubleClick -= value2;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.DoubleClick += value2;
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
				EventHandler value2 = new EventHandler(this.TextBox3_DoubleClick);
				if (this._TextBox3 != null)
				{
					this._TextBox3.DoubleClick -= value2;
				}
				this._TextBox3 = value;
				if (this._TextBox3 != null)
				{
					this._TextBox3.DoubleClick += value2;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void tcCiKu_frm_Load(object sender, EventArgs e)
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			string text = directoryPath + "\\施工做法.txt";
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
				string text = Interaction.InputBox("请输入你要添加的分类:", "田草CAD工具箱.Net版", "", -1, -1);
				IL_22:
				num2 = 3;
				string key = "A" + NF.Time2String() + "\\";
				IL_39:
				num2 = 4;
				if (Operators.CompareString(text, "", false) != 0)
				{
					goto IL_51;
				}
				IL_4C:
				goto IL_F0;
				IL_51:
				num2 = 7;
				this.TreeView1.Nodes.Add(key, text);
				IL_66:
				num2 = 8;
				this.Button4.Enabled = true;
				IL_74:
				goto IL_F0;
				IL_76:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_AA:
				goto IL_E5;
				IL_AC:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_76;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_C2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_AC;
			}
			IL_E5:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_F0:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_0(object sender, NodeLabelEditEventArgs e)
		{
			this.Button4.Enabled = true;
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button4_Click(object sender, EventArgs e)
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			string filePath = directoryPath + "\\施工做法.txt";
			this.SaveData(filePath);
			this.Button4.Enabled = false;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			short num = checked((short)Interaction.MsgBox("你是否确定要删除该条记录", MsgBoxStyle.OkCancel, "田草CAD工具箱.Net版---词库"));
			if (num == 1)
			{
				this.TreeView1.Nodes.Remove(this.TreeView1.SelectedNode);
				this.Button4.Enabled = true;
			}
		}

		private void Button3_Click(object sender, EventArgs e)
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
				string str = "";
				IL_12:
				num2 = 3;
				string str2 = "";
				IL_1A:
				num2 = 4;
				if (Operators.CompareString(this.TextBox2.Text, "", false) == 0)
				{
					goto IL_53;
				}
				IL_3A:
				num2 = 5;
				str = "!" + this.TextBox2.Text;
				IL_53:
				num2 = 7;
				if (Operators.CompareString(this.TextBox3.Text, "", false) == 0)
				{
					goto IL_8B;
				}
				IL_73:
				num2 = 8;
				str2 = "!!" + this.TextBox3.Text;
				IL_8B:
				num2 = 10;
				string text = this.TextBox1.Text + str + str2;
				IL_A2:
				num2 = 11;
				text = Strings.Replace(text, "\r\n", "'", 1, -1, CompareMethod.Binary);
				IL_B9:
				num2 = 12;
				if (Operators.CompareString(text, "", false) != 0)
				{
					goto IL_D2;
				}
				IL_CD:
				goto IL_244;
				IL_D2:
				num2 = 15;
				Interaction.MsgBox(text, MsgBoxStyle.OkOnly, null);
				IL_DE:
				num2 = 16;
				string name = this.TreeView1.SelectedNode.Name;
				IL_F3:
				num2 = 17;
				checked
				{
					int num3 = (int)this.inStr_n(name, "\\");
					IL_106:
					num2 = 18;
					string str3 = Conversions.ToString(Strings.Chr(64 + num3 + 1));
					IL_11C:
					num2 = 19;
					string key = name + str3 + NF.Time2String() + "\\";
					IL_134:
					num2 = 20;
					this.TreeView1.SelectedNode.Nodes.Add(key, text);
					IL_150:
					num2 = 21;
					this.Button4.Enabled = true;
					IL_15F:
					num2 = 22;
					if (Information.Err().Number == 0)
					{
						goto IL_189;
					}
					IL_174:
					num2 = 23;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_189:
					goto IL_244;
					IL_18E:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_1FE:
				goto IL_239;
				IL_200:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_18E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_216:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_200;
			}
			IL_239:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_244:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_1(object sender, TreeViewEventArgs e)
		{
			this.TextBox1.Clear();
			this.TextBox2.Clear();
			this.TextBox3.Clear();
			string text = this.TreeView1.SelectedNode.Text;
			int num = Strings.InStr(text, "!", CompareMethod.Binary);
			checked
			{
				if (num > 0)
				{
					string text2 = text.Substring(0, num - 1);
					string text3 = text.Substring(num);
					int num2 = Strings.InStr(text3, "!!", CompareMethod.Binary);
					string text4;
					if (num2 > 0)
					{
						text4 = text3.Substring(num2 + 1);
						text3 = text3.Substring(0, num2 - 1);
					}
					else
					{
						text4 = "";
					}
					text2 = Strings.Replace(text2, "'", "\r\n", 1, -1, CompareMethod.Binary);
					text3 = Strings.Replace(text3, "'", "\r\n", 1, -1, CompareMethod.Binary);
					text4 = Strings.Replace(text4, "'", "\r\n", 1, -1, CompareMethod.Binary);
					this.TextBox1.Text = text2;
					this.TextBox2.Text = text3;
					this.TextBox3.Text = text4;
				}
				else
				{
					this.TextBox1.Text = text;
				}
			}
		}

		private void TextBox1_DoubleClick(object sender, EventArgs e)
		{
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(point == point3d))
			{
				string[] array_ = new string[1];
				string text = this.TextBox1.Text;
				text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
				Class36.smethod_44(text, ref array_, "&");
				Class36.smethod_20(CAD.GetPointAngle(point, 100.0, 0.0), array_, 300.0, 1.2, "");
				documentLock.Dispose();
				this.Show();
			}
		}

		private void TextBox2_DoubleClick(object sender, EventArgs e)
		{
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(point == point3d))
			{
				string[] array_ = new string[1];
				string text = this.TextBox2.Text;
				text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
				Class36.smethod_44(text, ref array_, "&");
				Class36.smethod_20(CAD.GetPointAngle(point, 100.0, 0.0), array_, 300.0, 1.2, "");
				documentLock.Dispose();
				this.Show();
			}
		}

		private void TextBox3_DoubleClick(object sender, EventArgs e)
		{
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (!(point == point3d))
			{
				string[] array_ = new string[1];
				string text = this.TextBox3.Text;
				text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
				Class36.smethod_44(text, ref array_, "&");
				Class36.smethod_20(CAD.GetPointAngle(point, 100.0, 0.0), array_, 300.0, 1.2, "");
				documentLock.Dispose();
				this.Show();
			}
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			this.Hide();
			Point3d point = CAD.GetPoint("选择插入点: ");
			checked
			{
				Point3d point3d;
				if (!(point == point3d))
				{
					Point3d pointXY = CAD.GetPointXY(point, 50.0, -50.0);
					string text = this.TextBox1.Text;
					text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
					int num = (int)this.inStr_n(text, "&");
					string[] array_ = new string[1];
					Class36.smethod_44(text, ref array_, "&");
					Class36.smethod_20(CAD.GetPointAngle(pointXY, 100.0, 0.0), array_, 300.0, 1.2, "");
					pointXY = CAD.GetPointXY(point, 3550.0, -50.0);
					text = this.TextBox2.Text;
					text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
					num = (int)Math.Max(unchecked((long)num), this.inStr_n(text, "&"));
					array_ = new string[1];
					Class36.smethod_44(text, ref array_, "&");
					Class36.smethod_20(CAD.GetPointAngle(pointXY, 100.0, 0.0), array_, 300.0, 1.2, "");
					pointXY = CAD.GetPointXY(point, 13050.0, -50.0);
					text = this.TextBox3.Text;
					text = Strings.Replace(text, "\r\n", "&", 1, -1, CompareMethod.Binary);
					num = (int)Math.Max(unchecked((long)num), this.inStr_n(text, "&"));
					array_ = new string[1];
					Class36.smethod_44(text, ref array_, "&");
					Class36.smethod_20(CAD.GetPointAngle(pointXY, 100.0, 0.0), array_, 300.0, 1.2, "");
					if (num < 1)
					{
						num = 1;
					}
					num++;
					CAD.AddPlinePxy(point, 20000.0, (double)((0 - num) * 500), 0.0, "");
					pointXY = CAD.GetPointXY(point, 3500.0, 0.0);
					Point3d pointXY2 = CAD.GetPointXY(point, 3500.0, (double)((0 - num) * 500));
					CAD.AddLine(pointXY, pointXY2, "0");
					pointXY = CAD.GetPointXY(point, 13000.0, 0.0);
					pointXY2 = CAD.GetPointXY(point, 13000.0, (double)((0 - num) * 500));
					CAD.AddLine(pointXY, pointXY2, "0");
					documentLock.Dispose();
					this.Show();
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button6_Click(object sender, EventArgs e)
		{
			string str = "";
			string str2 = "";
			if (Operators.CompareString(this.TextBox2.Text, "", false) != 0)
			{
				str = "!" + this.TextBox2.Text;
			}
			if (Operators.CompareString(this.TextBox3.Text, "", false) != 0)
			{
				str2 = "!!" + this.TextBox3.Text;
			}
			string text = this.TextBox1.Text + str + str2;
			text = Strings.Replace(text, "\r\n", "'", 1, -1, CompareMethod.Binary);
			checked
			{
				if (Operators.CompareString(text, "", false) != 0)
				{
					Interaction.MsgBox(text, MsgBoxStyle.OkOnly, null);
					string name = this.TreeView1.SelectedNode.Name;
					int num = (int)this.inStr_n(name, "\\");
					string str3 = Conversions.ToString(Strings.Chr(64 + num + 1));
					name + str3 + NF.Time2String() + "\\";
					this.TreeView1.SelectedNode.Text = text;
					this.Button4.Enabled = true;
					string filePath = Class33.Class31_0.Info.DirectoryPath + "\\施工做法.txt";
					this.SaveData(filePath);
					if (Information.Err().Number != 0)
					{
						Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					}
				}
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("SplitContainer1")]
		private SplitContainer _SplitContainer1;

		[AccessedThroughProperty("TreeView1")]
		private TreeView _TreeView1;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("SplitContainer2")]
		private SplitContainer _SplitContainer2;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("SplitContainer3")]
		private SplitContainer _SplitContainer3;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		private int int_0;
	}
}
