using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class Logo_Frm : Form
	{
		[DebuggerNonUserCode]
		static Logo_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			Logo_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public Logo_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Shown += this.Logo_Frm_Shown;
			base.Load += this.Logo_Frm_Load;
			base.Click += this.Logo_Frm_Click;
			Logo_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = Logo_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (Logo_Frm.list_0.Count == Logo_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = Logo_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = Logo_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									Logo_Frm.list_0[num] = Logo_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						Logo_Frm.list_0.RemoveRange(num, Logo_Frm.list_0.Count - num);
						Logo_Frm.list_0.Capacity = Logo_Frm.list_0.Count;
					}
					Logo_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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

		private void Logo_Frm_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Logo_Frm_Load(object sender, EventArgs e)
		{
			this.Label1.Text = "";
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Logo_Frm_Shown(object sender, EventArgs e)
		{
			Bitmap bitmap = (Bitmap)Image.FromFile(Class33.Class31_0.Info.DirectoryPath + "\\logo.bmp");
			bitmap.MakeTransparent(bitmap.GetPixel(10, 10));
			this.BackgroundImage = bitmap;
			this.TransparencyKey = Color.DimGray;
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;
	}
}
