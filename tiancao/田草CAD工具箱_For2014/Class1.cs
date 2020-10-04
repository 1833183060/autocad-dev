using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class Class1
	{
		public Class1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.int_0 = 300;
		}

		public bool EnumWindowsProc(int hwnd, int lParam)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			WinAPI.GetWindowText(hwnd, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString();
			bool result;
			if (text.Length == 0)
			{
				result = true;
			}
			else if (Operators.CompareString(text, "选项", false) == 0)
			{
				WinAPI.EnumChildWindows(hwnd, new WinAPI.EnumWindowsProc(this.EnumChildProc), 0);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		public bool EnumChildProc(int hwnd, int lParam)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			WinAPI.GetWindowText(hwnd, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString();
			bool result;
			if (text.Length == 0)
			{
				result = true;
			}
			else if (Operators.CompareString(text, "确定", false) == 0)
			{
				this.timer_0.Stop();
				this.timer_0 = null;
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		public void timer1_Tick(object sender, EventArgs e)
		{
			if (this.int_1 < 300)
			{
				WinAPI.EnumWindows(new WinAPI.EnumWindowsProc(this.EnumWindowsProc), 0);
			}
			else
			{
				this.timer_0.Stop();
			}
			checked
			{
				this.int_1++;
				Debug.Print(this.int_1.ToString());
			}
		}

		[CommandMethod("TcClose")]
		public void closeOptionsDialog()
		{
			this.int_1 = 0;
			if (this.timer_0 == null)
			{
				this.timer_0 = new Timer();
			}
			this.timer_0.Interval = this.int_0;
			this.timer_0.Tick += this.timer1_Tick;
			this.timer_0.Start();
		}

		private Timer timer_0;

		private int int_0;

		private int int_1;
	}
}
