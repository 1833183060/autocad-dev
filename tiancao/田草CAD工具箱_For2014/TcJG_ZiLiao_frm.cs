using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcJG_ZiLiao_frm : Form
	{
		[DebuggerNonUserCode]
		static TcJG_ZiLiao_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcJG_ZiLiao_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcJG_ZiLiao_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcJG_ZiLiao_frm_Load;
			TcJG_ZiLiao_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcJG_ZiLiao_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcJG_ZiLiao_frm.list_0.Count == TcJG_ZiLiao_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcJG_ZiLiao_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcJG_ZiLiao_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcJG_ZiLiao_frm.list_0[num] = TcJG_ZiLiao_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcJG_ZiLiao_frm.list_0.RemoveRange(num, TcJG_ZiLiao_frm.list_0.Count - num);
						TcJG_ZiLiao_frm.list_0.Capacity = TcJG_ZiLiao_frm.list_0.Count;
					}
					TcJG_ZiLiao_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
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
				EventHandler value2 = new EventHandler(this.PictureBox1_Click);
				if (this._PictureBox1 != null)
				{
					this._PictureBox1.Click -= value2;
				}
				this._PictureBox1 = value;
				if (this._PictureBox1 != null)
				{
					this._PictureBox1.Click += value2;
				}
			}
		}

		internal virtual SplitContainer SplitContainer1
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
				EventHandler value2 = new EventHandler(this.method_1);
				MouseEventHandler value3 = new MouseEventHandler(this.method_0);
				if (this._ListBox1 != null)
				{
					this._ListBox1.SelectedIndexChanged -= value2;
					this._ListBox1.MouseDoubleClick -= value3;
				}
				this._ListBox1 = value;
				if (this._ListBox1 != null)
				{
					this._ListBox1.SelectedIndexChanged += value2;
					this._ListBox1.MouseDoubleClick += value3;
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
				EventHandler value2 = new EventHandler(this.TextBox2_TextChanged);
				if (this._TextBox2 != null)
				{
					this._TextBox2.TextChanged -= value2;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.TextChanged += value2;
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

		internal virtual ListBox ListBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ListBox2 = value;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcJG_ZiLiao_frm_Load(object sender, EventArgs e)
		{
			this.ListBox2.Visible = false;
			DirectoryInfo directoryInfo = new DirectoryInfo(Class33.Class31_0.Info.DirectoryPath + "\\结构资料");
			FileInfo[] files = directoryInfo.GetFiles();
			this.arrayList_0 = new ArrayList();
			this.arrayList_1 = new ArrayList();
			int num = 0;
			checked
			{
				int num2 = files.Length - 1;
				int num3 = num;
				for (;;)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string text = files[num3].Name.ToLower();
					if (files[num3].ToString().EndsWith(".gif") | files[num3].ToString().EndsWith(".bmp") | files[num3].ToString().EndsWith(".jpg") | files[num3].ToString().EndsWith(".png"))
					{
						this.ListBox1.Items.Add(text);
						this.arrayList_0.Add(text);
						this.ListBox2.Items.Add(files[num3].FullName);
						this.arrayList_1.Add(files[num3].FullName);
					}
					num3++;
				}
			}
		}

		private void method_0(object sender, MouseEventArgs e)
		{
			Clipboard.SetDataObject(this.PictureBox1.Image);
		}

		private void method_1(object sender, EventArgs e)
		{
			short index = checked((short)this.ListBox1.SelectedIndex);
			string url = Conversions.ToString(this.ListBox2.Items[(int)index]);
			this.PictureBox1.Load(url);
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(this.PictureBox1.Image);
		}

		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
			string value = this.TextBox2.Text.ToUpper();
			if (Operators.CompareString(this.Text, "", false) != 0)
			{
				this.ListBox1.Items.Clear();
				this.ListBox2.Items.Clear();
				try
				{
					foreach (object value2 in this.arrayList_0)
					{
						string text = Conversions.ToString(value2);
						if (text.ToUpper().Contains(value))
						{
							long num = (long)this.arrayList_0.IndexOf(text);
							this.ListBox1.Items.Add(text);
							this.ListBox2.Items.Add(RuntimeHelpers.GetObjectValue(this.arrayList_1[checked((int)num)]));
						}
					}
					return;
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
			this.ListBox1.Items.Clear();
			this.ListBox2.Items.Clear();
			try
			{
				foreach (object value3 in this.arrayList_0)
				{
					string text2 = Conversions.ToString(value3);
					long num2 = (long)this.arrayList_0.IndexOf(text2);
					this.ListBox1.Items.Add(text2);
					this.ListBox2.Items.Add(RuntimeHelpers.GetObjectValue(this.arrayList_1[checked((int)num2)]));
				}
			}
			finally
			{
				IEnumerator enumerator2;
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		[AccessedThroughProperty("SplitContainer1")]
		private SplitContainer jipAtgRsh;

		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		[AccessedThroughProperty("ListBox2")]
		private ListBox _ListBox2;

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;
	}
}
