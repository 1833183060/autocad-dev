using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014.ShowScreenPrompt
{
	public class PromptSetting
	{
		static PromptSetting()
		{
			Class39.k1QjQlczC5Jf5();
			PromptSetting.createForm_0 = null;
			PromptSetting.timer_0 = null;
			PromptSetting.int_1 = 0;
			PromptSetting.int_2 = 0;
		}

		[DebuggerNonUserCode]
		public PromptSetting()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern long ShowWindow(long long_0, long long_1);

		public static void Timer_Tick(object sender, EventArgs e)
		{
			checked
			{
				PromptSetting.int_1++;
				if (PromptSetting.int_1 >= PromptSetting.int_2)
				{
					PromptSetting.createForm_0.Close();
					PromptSetting.timer_0.Enabled = false;
				}
				if (!PromptSetting.createForm_0.Focused)
				{
					PromptSetting.createForm_0.Close();
					PromptSetting.timer_0.Enabled = false;
				}
			}
			PromptSetting.createForm_0.Opacity = (100.0 - (double)PromptSetting.int_1 * (100.0 / (double)PromptSetting.int_2)) / 100.0;
		}

		public static object Setting(string PromptString, short FontSize, Brush FontBrush, short ShowSecond)
		{
			PromptSetting.createForm_0 = new CreateForm();
			PromptSetting.createForm_0.PromptString = PromptString;
			PromptSetting.createForm_0.FontSize = Conversions.ToString((int)FontSize);
			PromptSetting.createForm_0.FontBrush = FontBrush;
			PromptSetting.int_2 = (int)ShowSecond;
			PromptSetting.int_1 = 0;
			PromptSetting.ShowWindow((long)PromptSetting.createForm_0.Handle, 4L);
			PromptSetting.timer_0 = new Timer();
			PromptSetting.timer_0.Interval = 1000;
			PromptSetting.timer_0.Enabled = true;
			PromptSetting.timer_0.Tick += PromptSetting.Timer_Tick;
			return true;
		}

		private const int int_0 = 4;

		private static CreateForm createForm_0;

		private static Timer timer_0;

		private static int int_1;

		private static int int_2;

		private static bool bool_0;
	}
}
