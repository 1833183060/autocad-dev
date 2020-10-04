using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public sealed partial class TcAboutBox : Form
	{
		[DebuggerNonUserCode]
		static TcAboutBox()
		{
			Class39.k1QjQlczC5Jf5();
			TcAboutBox.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcAboutBox()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TcAboutBox_Load;
			TcAboutBox.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcAboutBox.list_0;
			checked
			{
				lock (obj)
				{
					if (TcAboutBox.list_0.Count == TcAboutBox.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcAboutBox.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcAboutBox.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcAboutBox.list_0[num] = TcAboutBox.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcAboutBox.list_0.RemoveRange(num, TcAboutBox.list_0.Count - num);
						TcAboutBox.list_0.Capacity = TcAboutBox.list_0.Count;
					}
					TcAboutBox.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal TableLayoutPanel TableLayoutPanel
		{
			[DebuggerNonUserCode]
			get
			{
				return this.tableLayoutPanel_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.tableLayoutPanel_0 = value;
			}
		}

		internal PictureBox LogoPictureBox
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LogoPictureBox;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.LogoPictureBox_Click);
				if (this._LogoPictureBox != null)
				{
					this._LogoPictureBox.Click -= value2;
				}
				this._LogoPictureBox = value;
				if (this._LogoPictureBox != null)
				{
					this._LogoPictureBox.Click += value2;
				}
			}
		}

		internal TextBox TextBoxDescription
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBoxDescription;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBoxDescription = value;
			}
		}

		internal Button OKButton
		{
			[DebuggerNonUserCode]
			get
			{
				return this._OKButton;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.OKButton_Click);
				if (this._OKButton != null)
				{
					this._OKButton.Click -= value2;
				}
				this._OKButton = value;
				if (this._OKButton != null)
				{
					this._OKButton.Click += value2;
				}
			}
		}

		internal PictureBox PictureBox1
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

		internal GroupBox GroupBox1
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

		private Label LabelProductName
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LabelProductName;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelProductName = value;
			}
		}

		private Label LabelVersion
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LabelVersion;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelVersion = value;
			}
		}

		private Label LabelCompanyName
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LabelCompanyName;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelCompanyName = value;
			}
		}

		private Label LabelCopyright
		{
			[DebuggerNonUserCode]
			get
			{
				return this._LabelCopyright;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._LabelCopyright = value;
			}
		}

		private Label Label1
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

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public DateTime GetVersionDate()
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			string assemblyName = Class33.Class31_0.Info.AssemblyName;
			byte[] rawAssembly = File.ReadAllBytes(directoryPath + "/" + assemblyName + ".dll");
			string text = Assembly.Load(rawAssembly).GetName().Version.ToString();
			text = text.Split(new char[]
			{
				'.'
			})[2];
			return DateAndTime.DateAdd("d", (double)Conversions.ToLong(text), new DateTime(630822816000000000L));
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcAboutBox_Load(object sender, EventArgs e)
		{
			string arg;
			if (Operators.CompareString(Class33.Class31_0.Info.Title, "", false) != 0)
			{
				arg = Class33.Class31_0.Info.Title;
			}
			else
			{
				arg = Path.GetFileNameWithoutExtension(Class33.Class31_0.Info.AssemblyName);
			}
			this.Text = string.Format("关于 {0}", arg);
			this.LabelProductName.Text = Class33.Class31_0.Info.ProductName;
			this.LabelVersion.Text = string.Format("版本 {0}", Class33.Class31_0.Info.Version.ToString());
			this.LabelCopyright.Text = Class33.Class31_0.Info.Copyright;
			this.LabelCompanyName.Text = Class33.Class31_0.Info.CompanyName;
			this.Label1.Text = "发布时间 " + Conversions.ToString(this.GetVersionDate());
			this.TextBoxDescription.Text = "    1、本软件版权归田草博客(www.tiancao.net)作者所有。\r\n    2、其他任何单位、组织或个人可以自由传播、复制。\r\n    3、必须保存文件的完整性,禁止修改、重编译或反编译本文件。\r\n    4、本软件不包含任何帮助文件,如有任何疑问或建议请访问田草博客,或与本人联系：tiancao1001@126.com。\r\n    5、安装本软件前必须安装AutoCAD的相关版本，本软件为AutoCAD .Net二次开发的组件，须在该平台下使用。软件还需要Microsoft .NET Framework环境下使用。\r\n    6、在安装、使用或卸载过程中,田草博客及本人不承担任何相关或连带责任。";
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void LogoPictureBox_Click(object sender, EventArgs e)
		{
			Process.Start("Http://www.tiancao.net");
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TableLayoutPanel")]
		private TableLayoutPanel tableLayoutPanel_0;

		[AccessedThroughProperty("LogoPictureBox")]
		private PictureBox _LogoPictureBox;

		[AccessedThroughProperty("TextBoxDescription")]
		private TextBox _TextBoxDescription;

		[AccessedThroughProperty("OKButton")]
		private Button _OKButton;

		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("LabelProductName")]
		private Label _LabelProductName;

		[AccessedThroughProperty("LabelVersion")]
		private Label _LabelVersion;

		[AccessedThroughProperty("LabelCompanyName")]
		private Label _LabelCompanyName;

		[AccessedThroughProperty("LabelCopyright")]
		private Label _LabelCopyright;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;
	}
}
