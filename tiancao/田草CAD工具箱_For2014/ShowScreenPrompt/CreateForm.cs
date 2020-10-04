using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014.ShowScreenPrompt
{
	public partial class CreateForm : Form
	{
		[DebuggerNonUserCode]
		static CreateForm()
		{
			Class39.k1QjQlczC5Jf5();
			CreateForm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = CreateForm.list_0;
			checked
			{
				lock (obj)
				{
					if (CreateForm.list_0.Count == CreateForm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = CreateForm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = CreateForm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									CreateForm.list_0[num] = CreateForm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						CreateForm.list_0.RemoveRange(num, CreateForm.list_0.Count - num);
						CreateForm.list_0.Capacity = CreateForm.list_0.Count;
					}
					CreateForm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		public CreateForm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			CreateForm.smethod_0(this);
			this.ShowInTaskbar = false;
			this.FormBorderStyle = FormBorderStyle.None;
			this.BackColor = Color.Plum;
			this.TransparencyKey = Color.Plum;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;
			this.Paint += this.CreateForm_Paint;
		}

		private void CreateForm_Paint(object sender, PaintEventArgs e)
		{
			Font font = new Font("宋体", Conversions.ToSingle(this.FontSize));
			SizeF sizeF = e.Graphics.MeasureString(this.PromptString, font);
			checked
			{
				int num = (int)Math.Round(Math.Truncate((double)sizeF.Width));
				int num2 = (int)Math.Round(Math.Truncate((double)sizeF.Height));
				Rectangle r = new Rectangle((this.Width - num) / 2, (this.Height - num2) / 2, (int)Math.Round(Math.Truncate(unchecked((double)num * 1.2))), num2);
				e.Graphics.DrawString(this.PromptString, font, this.FontBrush, r);
			}
		}

		private static List<WeakReference> list_0;

		public string PromptString;

		public string FontSize;

		public Brush FontBrush;
	}
}
