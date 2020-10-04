using System;
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
	public partial class BlockYin : Form
	{
		[DebuggerNonUserCode]
		static BlockYin()
		{
			Class39.k1QjQlczC5Jf5();
			BlockYin.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public BlockYin()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.BlockYin_Load;
			BlockYin.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = BlockYin.list_0;
			checked
			{
				lock (obj)
				{
					if (BlockYin.list_0.Count == BlockYin.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = BlockYin.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = BlockYin.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									BlockYin.list_0[num] = BlockYin.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						BlockYin.list_0.RemoveRange(num, BlockYin.list_0.Count - num);
						BlockYin.list_0.Capacity = BlockYin.list_0.Count;
					}
					BlockYin.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				this._ListView1 = value;
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

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void BlockYin_Load(object sender, EventArgs e)
		{
			checked
			{
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(Class33.Class31_0.Info.DirectoryPath + "\\blocks");
					FileInfo[] files = directoryInfo.GetFiles("*.dwg");
					int num = 0;
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
						this.ListView1.Items.Add(files[num3].Name);
						num3++;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("ListView1")]
		private ListView _ListView1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;
	}
}
