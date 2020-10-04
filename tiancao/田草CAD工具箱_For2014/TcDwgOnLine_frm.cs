using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcDwgOnLine_frm : Form
	{
		[DebuggerNonUserCode]
		static TcDwgOnLine_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcDwgOnLine_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcDwgOnLine_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcDwgOnLine_frm_Load;
			TcDwgOnLine_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcDwgOnLine_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcDwgOnLine_frm.list_0.Count == TcDwgOnLine_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcDwgOnLine_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcDwgOnLine_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcDwgOnLine_frm.list_0[num] = TcDwgOnLine_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcDwgOnLine_frm.list_0.RemoveRange(num, TcDwgOnLine_frm.list_0.Count - num);
						TcDwgOnLine_frm.list_0.Capacity = TcDwgOnLine_frm.list_0.Count;
					}
					TcDwgOnLine_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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

		internal virtual WebBrowser WebBrowser1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._WebBrowser1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				WebBrowserDocumentCompletedEventHandler value2 = new WebBrowserDocumentCompletedEventHandler(this.jipAtgRsh);
				CancelEventHandler value3 = new CancelEventHandler(this.method_0);
				if (this._WebBrowser1 != null)
				{
					this._WebBrowser1.DocumentCompleted -= value2;
					this._WebBrowser1.NewWindow -= value3;
				}
				this._WebBrowser1 = value;
				if (this._WebBrowser1 != null)
				{
					this._WebBrowser1.DocumentCompleted += value2;
					this._WebBrowser1.NewWindow += value3;
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

		internal virtual WebBrowser WebBrowser2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._WebBrowser2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._WebBrowser2 = value;
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
				KeyEventHandler value2 = new KeyEventHandler(this.TextBox2_KeyDown);
				if (this._TextBox2 != null)
				{
					this._TextBox2.KeyDown -= value2;
				}
				this._TextBox2 = value;
				if (this._TextBox2 != null)
				{
					this._TextBox2.KeyDown += value2;
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

		internal virtual Timer Timer1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.timer_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Timer1_Tick);
				if (this.timer_0 != null)
				{
					this.timer_0.Tick -= value2;
				}
				this.timer_0 = value;
				if (this.timer_0 != null)
				{
					this.timer_0.Tick += value2;
				}
			}
		}

		[DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
		private static extern int UrlMkSetSessionOption(int int_1, string string_0, int int_2, int int_3);

		public static void ChangeUserAgent(string userAgent)
		{
			TcDwgOnLine_frm.UrlMkSetSessionOption(268435457, userAgent, userAgent.Length, 0);
		}

		private void TcDwgOnLine_frm_Load(object sender, EventArgs e)
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
				TcDwgOnLine_frm.ChangeUserAgent("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3947.100 Safari/537.36");
				IL_15:
				num2 = 3;
				this.WebBrowser1.Navigate(this.URL);
				IL_28:
				num2 = 4;
				this.TextBox2.Text = this.WebBrowser1.Document.Url.ToString();
				IL_4A:
				goto IL_B2;
				IL_4C:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_6E:
				goto IL_A7;
				IL_70:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_4C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_85:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_70;
			}
			IL_A7:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_B2:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.GoForward();
			this.TextBox2.Text = this.WebBrowser1.Document.Url.ToString();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.GoBack();
			this.TextBox2.Text = this.WebBrowser1.Document.Url.ToString();
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.Refresh();
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.Navigate(this.URL);
			this.TextBox2.Text = this.WebBrowser1.Document.Url.ToString();
		}

		private void method_0(object sender, CancelEventArgs e)
		{
			string urlString = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Document", new object[0], null, null, null), null, "ActiveElement", new object[0], null, null, null), null, "GetAttribute", new object[]
			{
				"href"
			}, null, null, null));
			this.WebBrowser1.Navigate(urlString);
			e.Cancel = true;
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.TextBox1.Text, "", false) != 0)
			{
			}
		}

		private void jipAtgRsh(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				this.WebBrowser1.Document.Window.Error += this.method_1;
				IL_25:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_2D:
				goto IL_8D;
				IL_2F:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_49:
				goto IL_82;
				IL_4B:
				num4 = num;
				if (num2 <= -2)
				{
					goto IL_2F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_60:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4B;
			}
			IL_82:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_8D:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_1(object sender, HtmlElementErrorEventArgs e)
		{
			e.Handled = true;
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.Navigate(this.TextBox2.Text);
		}

		private void TextBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.WebBrowser1.Navigate(this.TextBox2.Text);
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (this.WebBrowser1.IsBusy)
			{
				Application.DoEvents();
			}
			else if (this.WebBrowser1.Document.Links.Count > 0)
			{
				Random random = new Random();
				int index = random.Next(0, checked(this.WebBrowser1.Document.Links.Count - 1));
				HtmlElement htmlElement = this.WebBrowser1.Document.Links[index];
				string text = htmlElement.GetAttribute("HREF").ToUpper();
				if (text.Contains("TIANCAO.NET"))
				{
					htmlElement.InvokeMember("click");
				}
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		[AccessedThroughProperty("WebBrowser1")]
		private WebBrowser _WebBrowser1;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("WebBrowser2")]
		private WebBrowser _WebBrowser2;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Timer1")]
		private Timer timer_0;

		public string URL;

		public long N;

		private const int int_0 = 268435457;
	}
}
