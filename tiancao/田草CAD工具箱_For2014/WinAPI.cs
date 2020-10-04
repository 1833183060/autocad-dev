using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[StandardModule]
	public sealed class WinAPI
	{
		static WinAPI()
		{
			Class39.k1QjQlczC5Jf5();
			WinAPI.BM_SETSTATE = 243;
			WinAPI.WM_LBUTTONDOWN = 513;
			WinAPI.WM_LBUTTONUP = 514;
		}

		public static int LoadImageA(int hInst, string lpsz, int un1, int n1, int n2, int un2)
		{
			return 0;
		}

		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "LoadImageA", ExactSpelling = true, SetLastError = true)]
		public static extern long LoadImageA_1(long hInst, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpsz, long dwImageType, long dwDesiredWidth, long dwDesiredHeight, long dwFlags);

		[DllImport("User32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SendMessageA(IntPtr hwnd, int wMsg, int wParam, long lParam);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern long SetWindowTextA(long hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetKeyboardLayout(IntPtr dwLayout);

		[DllImport("imm32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr ImmIsIME(IntPtr hkl);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetAsyncKeyState(long vKey);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int EnumChildWindows(int hwnd, WinAPI.EnumWindowsProc callbackFunc, int lParam);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int GetWindowText(int hwnd, StringBuilder buff, int maxCount);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int GetLastActivePopup(int hwnd);

		[DllImport("User32.dll", CharSet = CharSet.Unicode)]
		public static extern int SendMessage(int hwnd, int Msg, int wParam, int lParam);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int SetWindowLongA(int hwnd, int nIndex, int dwNewLong);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindowLongA(int hwnd, int nIndex);

		[DllImport("User32.dll")]
		public static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

		[DllImport("User32.dll")]
		public static extern int EnumWindows(WinAPI.EnumWindowsProc ewp, int lParam);

		[DllImport("User32.dll")]
		public static extern bool IsWindowVisible(int hWnd);

		[DllImport("User32.dll")]
		public static extern int GetWindowTextLength(int hWnd);

		[DllImport("User32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("User32.dll")]
		public static extern IntPtr FindWindowEx(int hwnd1, int hwnd2, string lpsz1, string lpsz2);

		[DllImport("User32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowTextLength(HandleRef hWnd);

		[DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool EnumWindows(WinAPI.EnumThreadWindowsCallback callback, IntPtr extraData);

		[DllImport("User32.dll", ExactSpelling = true)]
		public static extern bool EnumChildWindows(HandleRef hwndParent, WinAPI.EnumChildrenCallback lpEnumFunc, HandleRef lParam);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindowTextA(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString, int cch);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int IsWindow(int hwnd);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetClassNameA(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, int nMaxCount);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindow(int hwnd, int wCmd);

		public const int WM_SETICON = 128;

		public const int IMAGW_ICON = 1;

		public const int LR_LOADFROMFILE = 16;

		public const int WM_SYSCOMMAND = 274;

		public const long SC_MAXIMIZE = 61488L;

		public const long SC_MINIMIZE = 61472L;

		public const int WM_CLOSE = 16;

		public const int SW_HIDE = 0;

		public const int SW_SHOWNORMAL = 1;

		public const int SW_SHOWMAXIMIZED = 3;

		public const int SW_SHOW = 5;

		public const int KEYEVENTF_KEYUP = 2;

		public static int BM_SETSTATE;

		public static int WM_LBUTTONDOWN;

		public static int WM_LBUTTONUP;

		public const int GWL_STYLE = -16;

		public const int WS_CAPTION = 12582912;

		public const short GW_CHILD = 5;

		public const short GW_HWNDFIRST = 0;

		public const short GW_HWNDNEXT = 2;

		public delegate bool EnumWindowsProc(int hWnd, int lParam);

		public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

		public delegate bool EnumChildrenCallback(IntPtr hwnd, IntPtr lParam);
	}
}
