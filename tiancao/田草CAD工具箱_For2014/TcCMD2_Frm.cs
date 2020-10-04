using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public class TcCMD2_Frm : UserControl
	{
		[DebuggerNonUserCode]
		static TcCMD2_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcCMD2_Frm.list_0 = new List<WeakReference>();
		}

		public TcCMD2_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			
			base.Load += this.TcCMD2_Frm_Load;
			TcCMD2_Frm.smethod_0(this);
			this.arrayList_0 = new ArrayList();
			this.arrayList_1 = new ArrayList();
			this.arrayList_2 = new ArrayList();
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcCMD2_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcCMD2_Frm.list_0.Count == TcCMD2_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcCMD2_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcCMD2_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcCMD2_Frm.list_0[num] = TcCMD2_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcCMD2_Frm.list_0.RemoveRange(num, TcCMD2_Frm.list_0.Count - num);
						TcCMD2_Frm.list_0.Capacity = TcCMD2_Frm.list_0.Count;
					}
					TcCMD2_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
            this.components = new System.ComponentModel.Container();
            this._WebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer_0 = new System.Windows.Forms.Timer(this.components);
            this.timer_1 = new System.Windows.Forms.Timer(this.components);
            this._Panel4 = new System.Windows.Forms.Panel();
            this._Label11 = new System.Windows.Forms.Label();
            this._Label12 = new System.Windows.Forms.Label();
            this._Label13 = new System.Windows.Forms.Label();
            this._Panel3 = new System.Windows.Forms.Panel();
            this._Label8 = new System.Windows.Forms.Label();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._Panel2 = new System.Windows.Forms.Panel();
            this._Label5 = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label7 = new System.Windows.Forms.Label();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._Label1 = new System.Windows.Forms.Label();
            this._ComboBox1 = new System.Windows.Forms.ComboBox();
            this.timer_2 = new System.Windows.Forms.Timer(this.components);
            this._Label14 = new System.Windows.Forms.Label();
            this._Panel4.SuspendLayout();
            this._Panel3.SuspendLayout();
            this._Panel2.SuspendLayout();
            this._Panel1.SuspendLayout();
            this._TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _WebBrowser1
            // 
            this._WebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._WebBrowser1.IsWebBrowserContextMenuEnabled = false;
            this._WebBrowser1.Location = new System.Drawing.Point(0, 864);
            this._WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this._WebBrowser1.Name = "_WebBrowser1";
            this._WebBrowser1.ScrollBarsEnabled = false;
            this._WebBrowser1.Size = new System.Drawing.Size(448, 123);
            this._WebBrowser1.TabIndex = 0;
            // 
            // timer_0
            // 
            this.timer_0.Enabled = true;
            this.timer_0.Interval = 66666;
            // 
            // timer_1
            // 
            this.timer_1.Enabled = true;
            this.timer_1.Interval = 66666;
            // 
            // _Panel4
            // 
            this._Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Panel4.Controls.Add(this._Label11);
            this._Panel4.Controls.Add(this._Label12);
            this._Panel4.Controls.Add(this._Label13);
            this._Panel4.Location = new System.Drawing.Point(0, 839);
            this._Panel4.Name = "_Panel4";
            this._Panel4.Size = new System.Drawing.Size(448, 15);
            this._Panel4.TabIndex = 12;
            // 
            // _Label11
            // 
            this._Label11.AutoSize = true;
            this._Label11.Location = new System.Drawing.Point(101, 0);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(47, 12);
            this._Label11.TabIndex = 7;
            this._Label11.Text = "Label11";
            // 
            // _Label12
            // 
            this._Label12.AutoSize = true;
            this._Label12.Location = new System.Drawing.Point(50, 0);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(53, 12);
            this._Label12.TabIndex = 6;
            this._Label12.Text = "_Label12";
            // 
            // _Label13
            // 
            this._Label13.AutoSize = true;
            this._Label13.Location = new System.Drawing.Point(3, 0);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(53, 12);
            this._Label13.TabIndex = 5;
            this._Label13.Text = "_Label13";
            // 
            // _Panel3
            // 
            this._Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Panel3.Controls.Add(this._Label8);
            this._Panel3.Controls.Add(this._Label9);
            this._Panel3.Controls.Add(this._Label10);
            this._Panel3.Location = new System.Drawing.Point(0, 824);
            this._Panel3.Name = "_Panel3";
            this._Panel3.Size = new System.Drawing.Size(448, 15);
            this._Panel3.TabIndex = 11;
            // 
            // _Label8
            // 
            this._Label8.AutoSize = true;
            this._Label8.Location = new System.Drawing.Point(101, 0);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(41, 12);
            this._Label8.TabIndex = 7;
            this._Label8.Text = "Label8";
            // 
            // _Label9
            // 
            this._Label9.AutoSize = true;
            this._Label9.Location = new System.Drawing.Point(50, 0);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(41, 12);
            this._Label9.TabIndex = 6;
            this._Label9.Text = "Label9";
            // 
            // _Label10
            // 
            this._Label10.AutoSize = true;
            this._Label10.Location = new System.Drawing.Point(3, 0);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(53, 12);
            this._Label10.TabIndex = 5;
            this._Label10.Text = "_Label10";
            // 
            // _Panel2
            // 
            this._Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Panel2.Controls.Add(this._Label5);
            this._Panel2.Controls.Add(this._Label6);
            this._Panel2.Controls.Add(this._Label7);
            this._Panel2.Location = new System.Drawing.Point(0, 809);
            this._Panel2.Name = "_Panel2";
            this._Panel2.Size = new System.Drawing.Size(448, 15);
            this._Panel2.TabIndex = 10;
            // 
            // _Label5
            // 
            this._Label5.AutoSize = true;
            this._Label5.Location = new System.Drawing.Point(101, 0);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(47, 12);
            this._Label5.TabIndex = 7;
            this._Label5.Text = "_Label5";
            // 
            // _Label6
            // 
            this._Label6.AutoSize = true;
            this._Label6.Location = new System.Drawing.Point(50, 0);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(47, 12);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "_Label6";
            // 
            // _Label7
            // 
            this._Label7.AutoSize = true;
            this._Label7.Location = new System.Drawing.Point(3, 0);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(47, 12);
            this._Label7.TabIndex = 5;
            this._Label7.Text = "_Label7";
            // 
            // _Panel1
            // 
            this._Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Panel1.Controls.Add(this._Label3);
            this._Panel1.Controls.Add(this._Label2);
            this._Panel1.Controls.Add(this._Label4);
            this._Panel1.Location = new System.Drawing.Point(0, 794);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(448, 15);
            this._Panel1.TabIndex = 9;
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(101, 0);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(47, 12);
            this._Label3.TabIndex = 7;
            this._Label3.Text = "_Label3";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(50, 0);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(47, 12);
            this._Label2.TabIndex = 6;
            this._Label2.Text = "_Label2";
            // 
            // _Label4
            // 
            this._Label4.AutoSize = true;
            this._Label4.Location = new System.Drawing.Point(3, 0);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(47, 12);
            this._Label4.TabIndex = 5;
            this._Label4.Text = "_Label4";
            // 
            // _TableLayoutPanel1
            // 
            this._TableLayoutPanel1.ColumnCount = 2;
            this._TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.76923F));
            this._TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.23077F));
            this._TableLayoutPanel1.Controls.Add(this._Label1, 0, 0);
            this._TableLayoutPanel1.Controls.Add(this._ComboBox1, 1, 0);
            this._TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._TableLayoutPanel1.Location = new System.Drawing.Point(0, 990);
            this._TableLayoutPanel1.Name = "_TableLayoutPanel1";
            this._TableLayoutPanel1.RowCount = 1;
            this._TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._TableLayoutPanel1.Size = new System.Drawing.Size(451, 24);
            this._TableLayoutPanel1.TabIndex = 2;
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Label1.Location = new System.Drawing.Point(3, 0);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(177, 24);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "比例";
            this._Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ComboBox1
            // 
            this._ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ComboBox1.FormattingEnabled = true;
            this._ComboBox1.Location = new System.Drawing.Point(186, 3);
            this._ComboBox1.Name = "_ComboBox1";
            this._ComboBox1.Size = new System.Drawing.Size(262, 20);
            this._ComboBox1.TabIndex = 1;
            // 
            // timer_2
            // 
            this.timer_2.Interval = 20000;
            // 
            // _Label14
            // 
            this._Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label14.Location = new System.Drawing.Point(419, 865);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(25, 25);
            this._Label14.TabIndex = 13;
            this._Label14.Text = "×";
            this._Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TcCMD2_Frm
            // 
            this.Controls.Add(this._Label14);
            this.Controls.Add(this._TableLayoutPanel1);
            this.Controls.Add(this._Panel4);
            this.Controls.Add(this._WebBrowser1);
            this.Controls.Add(this._Panel3);
            this.Controls.Add(this._Panel2);
            this.Controls.Add(this._Panel1);
            this.Name = "TcCMD2_Frm";
            this.Size = new System.Drawing.Size(451, 1014);
            this._Panel4.ResumeLayout(false);
            this._Panel4.PerformLayout();
            this._Panel3.ResumeLayout(false);
            this._Panel3.PerformLayout();
            this._Panel2.ResumeLayout(false);
            this._Panel2.PerformLayout();
            this._Panel1.ResumeLayout(false);
            this._Panel1.PerformLayout();
            this._TableLayoutPanel1.ResumeLayout(false);
            this._TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		public  WebBrowser WebBrowser1
		{
			//[DebuggerNonUserCode]
			get
			{
				return this._WebBrowser1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.method_5);
				WebBrowserDocumentCompletedEventHandler value3 = new WebBrowserDocumentCompletedEventHandler(this.method_3);
				if (this._WebBrowser1 != null)
				{
					this._WebBrowser1.DocumentTitleChanged -= value2;
					this._WebBrowser1.DocumentCompleted -= value3;
				}
				this._WebBrowser1 = value;
				if (this._WebBrowser1 != null)
				{
					this._WebBrowser1.DocumentTitleChanged += value2;
					this._WebBrowser1.DocumentCompleted += value3;
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

		internal virtual Timer Timer2
		{
			[DebuggerNonUserCode]
			get
			{
				return this.timer_1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Timer2_Tick);
				if (this.timer_1 != null)
				{
					this.timer_1.Tick -= value2;
				}
				this.timer_1 = value;
				if (this.timer_1 != null)
				{
					this.timer_1.Tick += value2;
				}
			}
		}

		internal virtual TableLayoutPanel TableLayoutPanel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TableLayoutPanel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel1 = value;
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
				EventHandler value2 = new EventHandler(this.ComboBox1_SelectedIndexChanged);
				if (this._ComboBox1 != null)
				{
					this._ComboBox1.SelectedIndexChanged -= value2;
				}
				this._ComboBox1 = value;
				if (this._ComboBox1 != null)
				{
					this._ComboBox1.SelectedIndexChanged += value2;
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
				EventHandler value2 = new EventHandler(this.Label1_DoubleClick);
				if (this._Label1 != null)
				{
					this._Label1.DoubleClick -= value2;
				}
				this._Label1 = value;
				if (this._Label1 != null)
				{
					this._Label1.DoubleClick += value2;
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

		internal virtual Timer Timer3
		{
			[DebuggerNonUserCode]
			get
			{
				return this.timer_2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Timer3_Tick);
				if (this.timer_2 != null)
				{
					this.timer_2.Tick -= value2;
				}
				this.timer_2 = value;
				if (this.timer_2 != null)
				{
					this.timer_2.Tick += value2;
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

		internal virtual Panel Panel3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel3 = value;
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

		internal virtual Panel Panel4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Panel4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Panel4 = value;
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
				this._Label13 = value;
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

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcCMD2_Frm_Load(object sender, EventArgs e)
		{
			int num;
			int num14;
			object obj;
			try
			{
				
				ProjectData.ClearProjectError();
				num = -2;
				int num2 = 2;
				string str = Class33.Class31_0.Info.DirectoryPath + "\\";
				
				if (!NF.FileExist(str + "\\Cmd2.txt"))
				{
					if (num14 != 0)
			        {
				        ProjectData.ClearProjectError();
			        }
                    return;
				}
				ArrayList arrayList = new ArrayList();
				
				
				NF.ReadTxtFile(str + "\\Cmd2.txt", ref arrayList);
				
				this.string_0 = "A";
				
				num2 = 9;
				checked
				{
					this.short_0 = (short)arrayList.Count;
					
					this.groupButton_0 = new TcCMD2_Frm.GroupButton[(int)(this.short_0 - 1 + 1)];
					
					this.button_0 = new Button[(int)(this.short_0 - 1 + 1)];
					
					short num3 = 0;
					short num4 = this.short_0 - 1;
					short num5 = num3;
					for (;;)
					{
						short num6 = num5;
						short num7 = num4;
						if (num6 > num7)
						{
							break;
						}
						IL_CE:
						num2 = 17;
						string text = Conversions.ToString(arrayList[(int)num5]);
						IL_E1:
						num2 = 18;
						this.groupButton_0[(int)num5].Index = (int)num5;
						IL_F8:
						num2 = 19;
						if (Operators.CompareString(text.Substring(0, 1), ">", false) == 0)
						{
							IL_117:
							num2 = 20;
							this.short_2 += 1;
							IL_129:
							num2 = 21;
							this.groupButton_0[(int)num5].Key = Conversions.ToString(Strings.Chr((int)(64 + this.short_1))) + Conversions.ToString((int)this.short_2);
							IL_161:
							num2 = 22;
							string text2 = text.Replace(">", "");
							IL_177:
							num2 = 23;
							string text3 = text2.Split(new char[]
							{
								'\t'
							})[0];
							IL_195:
							num2 = 24;
							string cmd = text2.Split(new char[]
							{
								'\t'
							})[2];
							IL_1B3:
							num2 = 25;
							this.groupButton_0[(int)num5].Text = text3;
							IL_1CA:
							num2 = 26;
							this.groupButton_0[(int)num5].CMD = cmd;
						}
						else
						{
							IL_1E6:
							num2 = 28;
							if (Operators.CompareString(text.Substring(0, 1), ".", false) == 0)
							{
								IL_205:
								num2 = 29;
								this.short_1 += 1;
								IL_217:
								num2 = 30;
								this.short_2 = 0;
								IL_221:
								num2 = 31;
								this.groupButton_0[(int)num5].Key = Conversions.ToString(Strings.Chr((int)(64 + this.short_1)));
								IL_249:
								num2 = 32;
								this.groupButton_0[(int)num5].Text = text.Split(new char[]
								{
									'.'
								})[1];
								IL_277:
								num2 = 33;
								this.groupButton_0[(int)num5].CMD = "";
							}
						}
						IL_2C3:
						num2 = 35;
						this.arrayList_0.Add(this.groupButton_0[(int)num5].Key);
						IL_293:
						num2 = 36;
						this.arrayList_1.Add(this.groupButton_0[(int)num5].CMD);
						IL_2B4:
						num2 = 37;
						unchecked
						{
							num5 += 1;
						}
					}
					IL_2E6:
					num2 = 38;
					short num8 = 0;
					short num9 = this.short_0 - 1;
					short num10 = num8;
					for (;;)
					{
						short num11 = num10;
						short num7 = num9;
						if (num11 > num7)
						{
							break;
						}
						IL_300:
						num2 = 39;
						Button button = new Button();
						IL_30A:
						num2 = 40;
						button.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
						IL_316:
						num2 = 41;
						button.FlatStyle = FlatStyle.Popup;
						IL_321:
						num2 = 42;
						if (this.groupButton_0[(int)num10].Key.Length == 1)
						{
							IL_342:
							num2 = 43;
							button.Left = 0;
							IL_34D:
							num2 = 44;
							button.Width = this.Width;
							IL_35D:
							num2 = 45;
							if (Operators.CompareString(this.string_0, this.groupButton_0[(int)num10].Key.Substring(0, 1), false) == 0)
							{
								IL_389:
								num2 = 46;
								button.Text = "▼ " + this.groupButton_0[(int)num10].Text;
							}
							else
							{
								IL_3B3:
								num2 = 48;
								IL_3B6:
								num2 = 49;
								button.Text = "■ " + this.groupButton_0[(int)num10].Text;
							}
						}
						else
						{
							IL_3E0:
							num2 = 52;
							IL_3E3:
							num2 = 53;
							button.Left = 10;
							IL_3EF:
							num2 = 54;
							button.Width = this.Width;
							IL_3FF:
							num2 = 55;
							button.Text = "\u3000\u3000" + this.groupButton_0[(int)num10].Text;
							IL_424:
							num2 = 56;
							if (NF.FileExist(str + "\\images\\Cmd2\\" + this.groupButton_0[(int)num10].CMD + ".png"))
							{
								IL_450:
								num2 = 57;
								Image image = Image.FromFile(str + "\\images\\Cmd2\\" + this.groupButton_0[(int)num10].CMD + ".png");
								IL_47C:
								num2 = 58;
								Image image2 = new Bitmap(image);
								IL_488:
								num2 = 59;
								image.Dispose();
								IL_492:
								num2 = 60;
								button.Image = image2;
								IL_49E:
								num2 = 61;
								button.ImageAlign = ContentAlignment.MiddleLeft;
								IL_4AA:
								num2 = 62;
								button.BackColor = Color.Transparent;
							}
							IL_4B9:
							num2 = 64;
							if (Operators.CompareString(this.string_0, this.groupButton_0[(int)num10].Key.Substring(0, 1), false) == 0)
							{
								IL_4E5:
								num2 = 65;
								button.Visible = true;
								IL_4F0:
								num2 = 66;
								long num12;
								button.Top = (int)num12;
								IL_4FD:
								num2 = 67;
								num12 += 22L;
							}
							else
							{
								IL_513:
								num2 = 69;
								IL_516:
								num2 = 70;
								button.Visible = false;
							}
						}
						IL_5C6:
						num2 = 73;
						button.Height = 22;
						IL_526:
						num2 = 74;
						button.TextAlign = ContentAlignment.MiddleLeft;
						IL_532:
						num2 = 75;
						button.Name = "Btn_" + this.groupButton_0[(int)num10].Key;
						IL_557:
						num2 = 76;
						this.button_0[(int)num10] = button;
						IL_564:
						num2 = 77;
						this.Controls.Add(button);
						IL_574:
						num2 = 78;
						button.Click += this.method_0;
						IL_58B:
						num2 = 79;
						button.MouseLeave += this.method_2;
						IL_5A2:
						num2 = 80;
						button.MouseEnter += this.method_1;
						IL_5B9:
						num2 = 81;
						unchecked
						{
							num10 += 1;
						}
					}
					IL_5D7:
					num2 = 82;
					this.button_0[0].PerformClick();
					IL_5E7:
					num2 = 83;
					this.ComboBox1.Items.Add("1:1");
					IL_600:
					num2 = 84;
					this.ComboBox1.Items.Add("1:2");
					IL_619:
					num2 = 85;
					this.ComboBox1.Items.Add("1:5");
					IL_632:
					num2 = 86;
					this.ComboBox1.Items.Add("1:10");
					IL_64B:
					num2 = 87;
					this.ComboBox1.Items.Add("1:20");
					IL_664:
					num2 = 88;
					this.ComboBox1.Items.Add("1:25");
					IL_67D:
					num2 = 89;
					this.ComboBox1.Items.Add("1:30");
					IL_696:
					num2 = 90;
					this.ComboBox1.Items.Add("1:40");
					IL_6AF:
					num2 = 91;
					this.ComboBox1.Items.Add("1:50");
					IL_6C8:
					num2 = 92;
					this.ComboBox1.Items.Add("1:100");
					IL_6E1:
					num2 = 93;
					this.ComboBox1.Items.Add("1:150");
					IL_6FA:
					num2 = 94;
					this.ComboBox1.Items.Add("1:200");
					IL_713:
					num2 = 95;
					this.ComboBox1.Items.Add("1:250");
					IL_72C:
					num2 = 96;
					this.ComboBox1.Items.Add("1:500");
					IL_745:
					num2 = 97;
					this.ComboBox1.Text = "1:100";
					IL_758:
					num2 = 98;
					this.Timer1.Interval = 66000;
					IL_76B:
					num2 = 99;
					this.Timer2.Interval = 660000;
					IL_77E:
					num2 = 100;
					this.Timer3.Interval = 10000;
					IL_791:
					num2 = 101;
					if (!Class33.Class32_0.Network.Ping("baidu.com"))
					{
						goto IL_7D9;
					}
					IL_7AA:
					num2 = 102;
					this.Timer1.Enabled = true;
					IL_7B9:
					num2 = 103;
					this.Timer2.Enabled = true;
					IL_7C8:
					num2 = 104;
					this.Timer3.Enabled = true;
					goto IL_809;
					IL_7D9:
					num2 = 106;
					IL_7DC:
					num2 = 107;
					this.Timer1.Enabled = false;
					IL_7EB:
					num2 = 108;
					this.Timer2.Enabled = false;
					IL_7FA:
					num2 = 109;
					this.Timer3.Enabled = false;
					IL_809:
					num2 = 111;
					if (Information.Err().Number != 5)
					{
						goto IL_8FF;
					}
					IL_81E:
					num2 = 112;
					this.Timer1.Enabled = false;
					IL_82D:
					num2 = 113;
					this.Timer2.Enabled = false;
					IL_83C:
					num2 = 114;
					this.Timer3.Enabled = false;
					IL_84B:
					num2 = 115;
					this.Label2.Visible = false;
					IL_85A:
					num2 = 116;
					this.Label3.Visible = false;
					IL_869:
					num2 = 117;
					this.Label4.Visible = false;
					IL_878:
					num2 = 118;
					this.Label5.Visible = false;
					IL_887:
					num2 = 119;
					this.Label6.Visible = false;
					IL_896:
					num2 = 120;
					this._Label7.Visible = false;
					IL_8A5:
					num2 = 121;
					this.Label8.Visible = false;
					IL_8B4:
					num2 = 122;
					this.Label9.Visible = false;
					IL_8C3:
					num2 = 123;
					this.Label10.Visible = false;
					IL_8D2:
					num2 = 124;
					this.Label11.Visible = false;
					IL_8E1:
					num2 = 125;
					this.Label12.Visible = false;
					IL_8F0:
					num2 = 126;
					this.Label13.Visible = false;
					IL_8FF:
					num2 = 128;
					this.WebBrowser1.Visible = false;
					IL_911:
					num2 = 129;
					this.Label14.Visible = false;
					IL_923:
					num2 = 130;
					if (NF.FileExist(str + "\\stock.txt"))
					{
						goto IL_A2E;
					}
					IL_942:
					num2 = 131;
					this.Timer3.Enabled = false;
					IL_954:
					num2 = 132;
					this.Label2.Visible = false;
					IL_966:
					num2 = 133;
					this.Label3.Visible = false;
					IL_978:
					num2 = 134;
					this.Label4.Visible = false;
					IL_98A:
					num2 = 135;
					this.Label5.Visible = false;
					IL_99C:
					num2 = 136;
					this.Label6.Visible = false;
					IL_9AE:
					num2 = 137;
					this._Label7.Visible = false;
					IL_9C0:
					num2 = 138;
					this.Label8.Visible = false;
					IL_9D2:
					num2 = 139;
					this.Label9.Visible = false;
					IL_9E4:
					num2 = 140;
					this.Label10.Visible = false;
					IL_9F6:
					num2 = 141;
					this.Label11.Visible = false;
					IL_A08:
					num2 = 142;
					this.Label12.Visible = false;
					IL_A1A:
					num2 = 143;
					this.Label13.Visible = false;
					goto IL_A52;
					IL_A2E:
					num2 = 145;
					IL_A34:
					num2 = 146;
					NF.ReadTxtFile(str + "\\stock.txt", ref this.arrayList_2);
					IL_A52:
					num2 = 148;
					this.Label2.Text = "";
					IL_A68:
					num2 = 149;
					this.Label3.Text = "";
					IL_A7E:
					num2 = 150;
					this.Label4.Text = "";
					IL_A94:
					num2 = 151;
					this.Label5.Text = "";
					IL_AAA:
					num2 = 152;
					this.Label6.Text = "";
					IL_AC0:
					num2 = 153;
					this._Label7.Text = "";
					IL_AD6:
					num2 = 154;
					this.Label8.Text = "";
					IL_AEC:
					num2 = 155;
					this.Label9.Text = "";
					IL_B02:
					num2 = 156;
					this.Label10.Text = "";
					IL_B18:
					num2 = 157;
					this.Label11.Text = "";
					IL_B2E:
					num2 = 158;
					this.Label12.Text = "";
					IL_B44:
					num2 = 159;
					this.Label13.Text = "";
					IL_B5A:
					goto IL_E38;
					IL_B5F:;
				}
				int num13 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num13);
				IL_DEF:
				goto IL_E2D;
				IL_DF1:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_B5F;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_E0A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_DF1;
			}
			IL_E2D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_E38:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			CAD.IsNODoc();
			string name = ((Button)sender).Name;
			if (Operators.CompareString(this.string_0, name.Substring(4, 1), false) == 0)
			{
				this.string_0 = "";
			}
			else
			{
				this.string_0 = name.Substring(4, 1);
			}
			object obj = this.button_0[0].Top;
			if (name.Length > 5)
			{
				string value = name.Substring(4);
				string str = this.arrayList_1[this.arrayList_0.IndexOf(value)].ToString();
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				mdiActiveDocument.SendStringToExecute(str + " ", true, false, true);
			}
			else
			{
				short num = 0;
				short num2 = checked(this.short_0 - 1);
				short num3 = num;
				for (;;)
				{
					short num4 = num3;
					short num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string left = this.button_0[(int)num3].Name.Substring(4, 1);
					this.button_0[(int)num3].Height = 22;
					this.button_0[(int)num3].BringToFront();
					if (Operators.CompareString(left, this.string_0, false) == 0)
					{
						this.button_0[(int)num3].Visible = true;
						this.button_0[(int)num3].Text = this.button_0[(int)num3].Text.Replace("■", "▼");
						this.button_0[(int)num3].Top = Conversions.ToInteger(obj);
						obj = Operators.AddObject(obj, 22);
					}
					else if (this.button_0[(int)num3].Name.Length > 5)
					{
						this.button_0[(int)num3].Visible = false;
					}
					else
					{
						this.button_0[(int)num3].Text = this.button_0[(int)num3].Text.Replace("▼", "■");
						this.button_0[(int)num3].Top = Conversions.ToInteger(obj);
						obj = Operators.AddObject(obj, 22);
					}
					num3 += 1;
				}
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			((Button)sender).ForeColor = Color.Red;
		}

		private void method_2(object sender, EventArgs e)
		{
			((Button)sender).ForeColor = Color.Black;
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
				if (Operators.CompareString(this.ComboBox1.Text, "", false) == 0)
				{
					goto IL_7D;
				}
				IL_29:
				num2 = 3;
				short num3 = checked((short)Math.Round(Conversion.Val(this.ComboBox1.Text.Split(new char[]
				{
					':'
				})[1])));
				IL_56:
				num2 = 4;
				if (num3 == 0)
				{
					goto IL_7D;
				}
				IL_61:
				num2 = 5;
				Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString((int)num3));
				IL_7D:
				goto IL_EE;
				IL_7F:
				goto IL_F9;
				IL_81:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_99;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_CB;
				IL_99:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_CB:
				goto IL_F9;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_81;
			}
			IL_EE:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_F9:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (Class33.Class32_0.Network.Ping("sohu.com"))
			{
				this.WebBrowser1.AllowWebBrowserDrop = false;
				this.WebBrowser1.ScriptErrorsSuppressed = true;
				this.WebBrowser1.Navigate("http://www.tiancao.net/TcCADTools.htm");
			}
			else
			{
				this.Timer1.Enabled = false;
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Timer2_Tick(object sender, EventArgs e)
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
				if (!Class33.Class32_0.Network.Ping("baidu.com"))
				{
					goto IL_14D;
				}
				IL_24:
				num2 = 3;
				DateTime t = Conversions.ToDate(Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "打开DwgOnLineFrm", "打开DwgOnLineFrm", Conversions.ToString(new DateTime(630822816000000000L))));
				IL_5D:
				num2 = 4;
				if (!(DateTime.Compare(t, new DateTime(630822816000000000L)) == 0 | DateTime.Compare(t, DateAndTime.Now.Date) != 0))
				{
					goto IL_139;
				}
				IL_96:
				num2 = 5;
				TcDwgOnLine_frm tcDwgOnLine_frm = new TcDwgOnLine_frm();
				IL_9E:
				num2 = 6;
				tcDwgOnLine_frm.Timer1.Enabled = true;
				IL_AC:
				num2 = 7;
				tcDwgOnLine_frm.URL = "http://www.tiancao.net/fenbu.asp";
				IL_B9:
				num2 = 8;
				Form form = tcDwgOnLine_frm;
				Point location = new Point(-2500, 0);
				form.Location = new Point(-2500, 0);
				IL_D0:
				num2 = 9;
				tcDwgOnLine_frm.Size =new Size(2000, 2000);
				IL_EC:
				num2 = 10;
				Process.Start("http://www.tiancao.net/fenbu.asp");
				IL_FA:
				num2 = 11;
				tcDwgOnLine_frm.Show();
				IL_103:
				num2 = 12;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "打开DwgOnLineFrm", "打开DwgOnLineFrm", Conversions.ToString(DateAndTime.Now.Date));
				goto IL_15F;
				IL_139:
				num2 = 14;
				IL_13C:
				num2 = 15;
				this.Timer2.Enabled = false;
				goto IL_15F;
				IL_14D:
				num2 = 18;
				IL_150:
				num2 = 19;
				this.Timer2.Enabled = false;
				IL_15F:
				num2 = 21;
				if (Information.Err().Number <= 0)
				{
					goto IL_1A5;
				}
				IL_171:
				num2 = 22;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "打开DwgOnLineFrm", "打开DwgOnLineFrm", Conversions.ToString(DateAndTime.Now.Date));
				IL_1A5:
				goto IL_260;
				IL_1AA:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_21A:
				goto IL_255;
				IL_21C:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1AA;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_232:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_21C;
			}
			IL_255:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_260:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_3(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.WebBrowser1.Document.Window.Error += this.method_4;
		}

		private void method_4(object sender, HtmlElementErrorEventArgs e)
		{
			e.Handled = true;
		}

		private void method_5(object sender, EventArgs e)
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
				if (Operators.CompareString(this.WebBrowser1.DocumentTitle, "田草CAD工具箱", false) != 0)
				{
					goto IL_5D;
				}
				IL_26:
				num2 = 3;
				this.WebBrowser1.Visible = true;
				IL_34:
				num2 = 4;
				this.Label14.Visible = true;
				IL_42:
				num2 = 5;
				this.Timer1.Enabled = false;
				IL_50:
				num2 = 6;
				this.Timer1.Dispose();
				IL_5D:
				goto IL_CA;
				IL_5F:
				goto IL_D4;
				IL_61:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_78;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_A8;
				IL_78:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_A8:
				goto IL_D4;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_61;
			}
			IL_CA:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_D4:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		public TcCMD2_Frm.GP GetData(string DM)
		{
			string requestUriString = "http://hq.sinajs.cn/list=" + DM;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.Method = "GET";
			TcCMD2_Frm.GP result;
			try
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.Default);
				string text = streamReader.ReadToEnd();
				text = Strings.Replace(text, "\"", "", 1, -1, CompareMethod.Binary);
				text = text.Split(new char[]
				{
					'='
				})[1];
				string[] array = text.Split(new char[]
				{
					','
				});
				TcCMD2_Frm.GP gp;
				gp.D0 = array[0];
				gp.D1 = float.Parse(array[1]);
				gp.D2 = float.Parse(array[2]);
				gp.D3 = float.Parse(array[3]);
				gp.D4 = float.Parse(array[4]);
				gp.D5 = float.Parse(array[5]);
				gp.D6 = float.Parse(array[6]);
				gp.D7 = float.Parse(array[7]);
				gp.D8 = float.Parse(array[8]);
				result = gp;
			}
			catch (Exception ex)
			{
				this.Timer3.Enabled = false;
				TcCMD2_Frm.GP gp2;
				result = gp2;
			}
			return result;
		}

		private void Timer3_Tick(object sender, EventArgs e)
		{
			int num;
			int num8;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				TcCMD2_Frm.GP data = this.GetData(Conversions.ToString(this.arrayList_2[0]));
				IL_23:
				num2 = 3;
				double num3 = (double)((data.D3 - data.D2) / data.D2);
				IL_3F:
				num2 = 4;
				if (num3 <= 0.0)
				{
					goto IL_76;
				}
				IL_50:
				num2 = 5;
				this.Label2.ForeColor = Color.Red;
				IL_62:
				num2 = 6;
				this.Label3.ForeColor = Color.Red;
				goto IL_E7;
				IL_76:
				num2 = 8;
				if (num3 != 0.0)
				{
					goto IL_AF;
				}
				IL_87:
				num2 = 9;
				this.Label2.ForeColor = Color.Gray;
				IL_9A:
				num2 = 10;
				this.Label3.ForeColor = Color.Gray;
				goto IL_E7;
				IL_AF:
				num2 = 12;
				if (num3 >= 0.0)
				{
					goto IL_E7;
				}
				IL_C1:
				num2 = 13;
				this.Label2.ForeColor = Color.Green;
				IL_D4:
				num2 = 14;
				this.Label3.ForeColor = Color.Green;
				IL_E7:
				num2 = 16;
				this.Label4.Text = data.D0.Substring(0, 2);
				IL_103:
				num2 = 17;
				this.Label2.Text = Strings.Format(data.D1, "0.00");
				IL_127:
				num2 = 18;
				this.Label3.Text = Strings.Format(num3, "0.00%");
				IL_146:
				num2 = 19;
				TcCMD2_Frm.GP data2 = this.GetData(Conversions.ToString(this.arrayList_2[1]));
				IL_162:
				num2 = 20;
				double num4 = (double)((data2.D3 - data2.D2) / data2.D2);
				IL_17F:
				num2 = 21;
				if (num4 <= 0.0)
				{
					goto IL_1B9;
				}
				IL_191:
				num2 = 22;
				this.Label6.ForeColor = Color.Red;
				IL_1A4:
				num2 = 23;
				this.Label5.ForeColor = Color.Red;
				goto IL_22B;
				IL_1B9:
				num2 = 25;
				if (num4 != 0.0)
				{
					goto IL_1F3;
				}
				IL_1CB:
				num2 = 26;
				this.Label6.ForeColor = Color.Gray;
				IL_1DE:
				num2 = 27;
				this.Label5.ForeColor = Color.Gray;
				goto IL_22B;
				IL_1F3:
				num2 = 29;
				if (num4 >= 0.0)
				{
					goto IL_22B;
				}
				IL_205:
				num2 = 30;
				this.Label6.ForeColor = Color.Green;
				IL_218:
				num2 = 31;
				this.Label5.ForeColor = Color.Green;
				IL_22B:
				num2 = 33;
				this._Label7.Text = data2.D0.Substring(0, 2);
				IL_247:
				num2 = 34;
				this.Label6.Text = Strings.Format(data2.D1, "0.00");
				IL_26B:
				num2 = 35;
				this.Label5.Text = Strings.Format(num4, "0.00%");
				IL_28A:
				num2 = 36;
				TcCMD2_Frm.GP data3 = this.GetData(Conversions.ToString(this.arrayList_2[2]));
				IL_2A6:
				num2 = 37;
				double num5 = (double)((data3.D3 - data3.D2) / data3.D2);
				IL_2C3:
				num2 = 38;
				if (num5 <= 0.0)
				{
					goto IL_2FD;
				}
				IL_2D5:
				num2 = 39;
				this.Label9.ForeColor = Color.Red;
				IL_2E8:
				num2 = 40;
				this.Label8.ForeColor = Color.Red;
				goto IL_36F;
				IL_2FD:
				num2 = 42;
				if (num5 != 0.0)
				{
					goto IL_337;
				}
				IL_30F:
				num2 = 43;
				this.Label9.ForeColor = Color.Gray;
				IL_322:
				num2 = 44;
				this.Label8.ForeColor = Color.Gray;
				goto IL_36F;
				IL_337:
				num2 = 46;
				if (num5 >= 0.0)
				{
					goto IL_36F;
				}
				IL_349:
				num2 = 47;
				this.Label9.ForeColor = Color.Green;
				IL_35C:
				num2 = 48;
				this.Label8.ForeColor = Color.Green;
				IL_36F:
				num2 = 50;
				this.Label10.Text = data3.D0.Substring(0, 2);
				IL_38B:
				num2 = 51;
				this.Label9.Text = Strings.Format(data3.D1, "0.00");
				IL_3AF:
				num2 = 52;
				this.Label8.Text = Strings.Format(num5, "0.00%");
				IL_3CE:
				num2 = 53;
				TcCMD2_Frm.GP data4 = this.GetData(Conversions.ToString(this.arrayList_2[3]));
				IL_3E9:
				num2 = 54;
				double num6 = (double)((data4.D3 - data4.D1) / data4.D1);
				IL_406:
				num2 = 55;
				if (num6 <= 0.0)
				{
					goto IL_440;
				}
				IL_418:
				num2 = 56;
				this.Label12.ForeColor = Color.Red;
				IL_42B:
				num2 = 57;
				this.Label11.ForeColor = Color.Red;
				goto IL_4B2;
				IL_440:
				num2 = 59;
				if (num6 != 0.0)
				{
					goto IL_47A;
				}
				IL_452:
				num2 = 60;
				this.Label12.ForeColor = Color.Gray;
				IL_465:
				num2 = 61;
				this.Label11.ForeColor = Color.Gray;
				goto IL_4B2;
				IL_47A:
				num2 = 63;
				if (num6 >= 0.0)
				{
					goto IL_4B2;
				}
				IL_48C:
				num2 = 64;
				this.Label12.ForeColor = Color.Green;
				IL_49F:
				num2 = 65;
				this.Label11.ForeColor = Color.Green;
				IL_4B2:
				num2 = 67;
				this.Label13.Text = data4.D0.Substring(0, 2);
				IL_4CE:
				num2 = 68;
				this.Label12.Text = Strings.Format(data4.D3, "0.00");
				IL_4F2:
				num2 = 69;
				this.Label11.Text = Strings.Format(num6, "0.00%");
				IL_511:
				goto IL_687;
				IL_516:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_63E:
				goto IL_67C;
				IL_640:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_516;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_659:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_640;
			}
			IL_67C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_687:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Label1_DoubleClick(object sender, EventArgs e)
		{
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "打开DwgOnLineFrm", "打开DwgOnLineFrm", Conversions.ToString(new DateTime(630822816000000000L)));
			Interaction.MsgBox("ok", MsgBoxStyle.OkOnly, null);
		}

		private void Label14_Click(object sender, EventArgs e)
		{
			this.WebBrowser1.Visible = false;
			this.Label14.Visible = false;
			Process.Start("http://www.tiancao.net/TcCADTools.htm");
		}

		private static List<WeakReference> list_0;

		private IContainer icontainer_0;

		//[AccessedThroughProperty("WebBrowser1")]
		private WebBrowser _WebBrowser1;

		[AccessedThroughProperty("Timer1")]
		private Timer timer_0;

		//[AccessedThroughProperty("Timer2")]
		private Timer timer_1;

		//[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		//[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		//[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Label4")]
		private Label _Label4;

		//[AccessedThroughProperty("Timer3")]
		private Timer timer_2;

		//[AccessedThroughProperty("Label5")]
		private Label _Label5;

		//[AccessedThroughProperty("Label6")]
		private Label _Label6;

		[AccessedThroughProperty("_Label7")]
		private Label _Label7;

		[AccessedThroughProperty("Panel3")]
		private Panel _Panel3;

		[AccessedThroughProperty("Label8")]
		private Label _Label8;

		[AccessedThroughProperty("Label9")]
		private Label _Label9;

		[AccessedThroughProperty("Label10")]
		private Label _Label10;

		[AccessedThroughProperty("Panel4")]
		private Panel _Panel4;

		[AccessedThroughProperty("Label11")]
		private Label _Label11;

		[AccessedThroughProperty("Label12")]
		private Label _Label12;

		[AccessedThroughProperty("Label13")]
		private Label _Label13;

		[AccessedThroughProperty("Panel2")]
		private Panel _Panel2;

		[AccessedThroughProperty("Panel1")]
		private Panel _Panel1;

		[AccessedThroughProperty("Label14")]
		private Label _Label14;

		private TcCMD2_Frm.GroupButton[] groupButton_0;

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		private Button[] button_0;

		private short short_0;

		private short short_1;

		private short short_2;

		private string string_0;
        private IContainer components;

		private ArrayList arrayList_2;

		public struct GroupButton
		{
			public int Index;

			public string Key;

			public long Left;

			public long Top;

			public string Text;

			public string CMD;

			public bool Visible;
		}

		public struct GP
		{
			public string D0;

			public float D1;

			public float D2;

			public float D3;

			public float D4;

			public float D5;

			public float D6;

			public float D7;

			public float D8;
		}
	}
}
