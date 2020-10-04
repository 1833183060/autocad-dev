using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Autodesk.AutoCAD.AcInfoCenterConn;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.Internal.InfoCenter;
using Autodesk.Private.InfoCenter;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 初始化设置 : IExtensionApplication
	{
		static 初始化设置()
		{
			Class39.k1QjQlczC5Jf5();
			初始化设置.button_0 = new Button();
			初始化设置.bool_0 = false;
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public 初始化设置()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.string_0 = Class33.Class31_0.Info.DirectoryPath;
			this.string_1 = "";
			this.IconPath = "C:\\Program Files (x86)\\盈建科建筑结构设计软件ForRevit2016\\Trans\\Images\\ico\\001.ico";
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void Initialize()
		{
			try
			{
				string setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_IsFirstTime", "_IsFirstTime", "");
				if (Operators.CompareString(setting, "False", false) != 0)
				{
					TcSet_frm tcSet_frm = new TcSet_frm();
					Application.ShowModelessDialog(tcSet_frm);
					Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_IsFirstTime", "_IsFirstTime", "False");
				}
				setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_FileHistory", "_FileHistory", "");
				if (Operators.CompareString(setting, "ON", false) == 0)
				{
					this.AddDocumentCreateStartedEvent();
				}
				PaletteSet paletteSet = null;
				if (paletteSet == null)
				{
					TcCMD2_Frm tcCMD2_Frm = new TcCMD2_Frm();
					paletteSet = new PaletteSet("田草CAD工具箱命令面板_TcCMD2");
					paletteSet.Add("田草CAD工具箱命令面板_TcCMD2", tcCMD2_Frm);
					PaletteSet paletteSet2 = paletteSet;
					Size size = new Size(110, 500);
					paletteSet2.MinimumSize = size;
					PaletteSet paletteSet3 = paletteSet;
					size = new Size(110, 500);
					paletteSet3.Size = size;
				}
				paletteSet.Visible = true;
				this.method_2();
				this.jipAtgRsh();
				this.string_1 = CAD.GetCADVerY();
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				mdiActiveDocument.Editor.WriteMessage("\r\n************************************************************");
				mdiActiveDocument.Editor.WriteMessage("\r\n田草CAD工具箱ForAutoCAD" + this.string_1 + "加载成功。");
				mdiActiveDocument.Editor.WriteMessage("\r\n插件的安装使用说明和帮助文件请访问:田草博客(www.Tiancao.net)");
				mdiActiveDocument.Editor.WriteMessage("\r\n版权所有(C) 田草博客(www.Tiancao.net) 2007~" + Conversions.ToString(DateAndTime.Now.Year));
				mdiActiveDocument.Editor.WriteMessage("\r\n************************************************************");
				this.infoCenterBalloon();
				this.QQTZ_Sub();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		public void Terminate()
		{
		}

		public void infoCenterBalloon()
		{
			InfoCenterManager infoCenterManager = new InfoCenterManager();
			ResultItem resultItem = new ResultItem();
			resultItem.Category = "田草CAD工具箱";
			resultItem.Title = "\r\nForAutoCAD" + CAD.GetCADVerY() + "加载成功。";
			resultItem.Uri = new Uri("http://tiancao.net/ID1881.htm");
			resultItem.IsFavorite = true;
			resultItem.IsNew = true;
			resultItem.Timestamp = DateAndTime.Now;
			resultItem.Type = 3;
			infoCenterManager.PaletteManager.ShowBalloon(resultItem);
		}

		public void infoCenterBalloon1()
		{
			InfoCenterManager infoCenterManager = new InfoCenterManager();
			PaletteMgr paletteManager = infoCenterManager.PaletteManager;
			paletteManager.ShowBalloon("田草CAD工具箱", "田草CAD工具箱", "田草CAD工具箱ForAutoCAD" + CAD.GetCADVerY(), "欢迎访问田草博客!", "http://tiancao.net/ID1881.htm", new BalloonFunctionClickedEventHandler(this.method_1));
		}

		[CommandMethod("气球通知")]
		public void QQTZ_Sub()
		{
			try
			{
				this.trayItem_0 = new TrayItem();
				this.trayItem_0.ToolTipText = "田草CAD工具箱";
				this.trayItem_0.Icon = new Icon(this.string_0 + "\\Icon16.ico");
				Application.StatusBar.TrayItems.Add(this.trayItem_0);
				TrayItemBubbleWindow trayItemBubbleWindow = new TrayItemBubbleWindow();
				trayItemBubbleWindow.Title = "田草CAD工具箱";
				trayItemBubbleWindow.HyperText = "www.tiancao.net";
				trayItemBubbleWindow.HyperLink = "http://tiancao.net/ID1881.htm";
				trayItemBubbleWindow.Text = "欢迎访问田草博客（www.tiancao.net)";
				trayItemBubbleWindow.Text2 = "微信公众号搜索\"ByCAD\",你的关注是软件成长的动力。";
				trayItemBubbleWindow.IconType = 1;
				this.trayItem_0.ShowBubbleWindow(trayItemBubbleWindow);
				Application.StatusBar.Update();
				trayItemBubbleWindow.Closed += new TrayItemBubbleWindowClosedEventHandler(this.method_0);
			}
			catch (Exception ex)
			{
			}
		}

		public void QQTZ_Sub(string AppName, string Title, string Hlink, string HText, string msg1, string msg2)
		{
			try
			{
				this.trayItem_0 = new TrayItem();
				this.trayItem_0.ToolTipText = AppName;
				this.trayItem_0.Icon = new Icon(this.string_0 + "\\Icon16.ico");
				Application.StatusBar.TrayItems.Add(this.trayItem_0);
				TrayItemBubbleWindow trayItemBubbleWindow = new TrayItemBubbleWindow();
				trayItemBubbleWindow.Title = Title;
				trayItemBubbleWindow.HyperText = HText;
				trayItemBubbleWindow.HyperLink = Hlink;
				trayItemBubbleWindow.Text = msg1;
				trayItemBubbleWindow.Text2 = msg2;
				trayItemBubbleWindow.IconType = 1;
				this.trayItem_0.ShowBubbleWindow(trayItemBubbleWindow);
				Application.StatusBar.Update();
				trayItemBubbleWindow.Closed += new TrayItemBubbleWindowClosedEventHandler(this.method_0);
			}
			catch (Exception ex)
			{
			}
		}

		private void method_0(object sender, TrayItemBubbleWindowClosedEventArgs e)
		{
			try
			{
				Application.StatusBar.TrayItems.Remove(this.trayItem_0);
				Application.StatusBar.Update();
			}
			catch (Exception ex)
			{
			}
		}

		private void method_1(object sender, BalloonFunctionClickedEventArgs e)
		{
			Process.Start("http://tiancao.net/ID1881.htm");
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void method_2()
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
				long hInst = 0L;
				string text = Class33.Class31_0.Info.DirectoryPath + "\\Icon16.ico";
				WinAPI.LoadImageA_1(hInst, ref text, 1L, 32L, 32L, 16L);
				IL_5A:
				num2 = 3;
				Application.MainWindow.Text = "田草CAD工具箱ForAutoCAD" + this.string_1;
				IL_76:
				num2 = 4;
				new Icon(Class33.Class31_0.Info.DirectoryPath + "\\Icon16.ico");
				IL_97:
				num2 = 5;
				Application.MainWindow.WindowState = 2;
				IL_A4:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_C9;
				}
				IL_B5:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_C9:
				goto IL_141;
				IL_CB:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_FD:
				goto IL_136;
				IL_FF:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_CB;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_114:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_FF;
			}
			IL_136:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_141:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcTest")]
		public void test()
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
				Type.GetTypeFromProgID("AutoCAD.Application.19");
				IL_16:
				num2 = 3;
				Thread.Sleep(2000);
				IL_22:
				num2 = 4;
				string text = "This is my version of AutoCAD";
				IL_2A:
				num2 = 5;
				WinAPI.SetWindowTextA((long)Application.MainWindow.Handle, ref text);
				IL_43:
				goto IL_A8;
				IL_45:
				goto IL_B2;
				IL_47:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_5E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_86;
				IL_5E:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_86:
				goto IL_B2;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_47;
			}
			IL_A8:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_B2:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("sab")]
		public void ShowMe()
		{
			if (初始化设置.button_0 == null)
			{
				初始化设置.button_0 = new Button();
			}
			Control control = 初始化设置.button_0;
			Point location = new Point(31, 29);
			control.Location = location;
			初始化设置.button_0.Name = "BT1";
			Control control2 = 初始化设置.button_0;
			Size size = new Size(87, 35);
			control2.Size = size;
			初始化设置.button_0.TabIndex = 0;
			初始化设置.button_0.Text = "BT1";
			初始化设置.button_0.UseVisualStyleBackColor = true;
			初始化设置.button_0.Click += new EventHandler(初始化设置.smethod_0);
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			IntPtr handle = Application.MainWindow.Handle;
			object left = WinAPI.FindWindowEx((int)handle, 0, "MDIClient", "");
			object right = WinAPI.FindWindowEx((int)handle, 1, "AdImpApplicationFrame", "");
			Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(left, " "), right), MsgBoxStyle.OkOnly, null);
		}

		private void method_3(ref int int_5)
		{
			int window = WinAPI.GetWindow(int_5, 5);
			if (window != 0)
			{
				window = WinAPI.GetWindow(window, 0);
				if (window != 0)
				{
					while (window != 0)
					{
						string text = new string('\0', 255);
						WinAPI.GetClassNameA(window, ref text, 250);
						text = Strings.Left(text, checked(Strings.InStr(text, new string('\0', 1), CompareMethod.Binary) - 1));
						string text2 = Conversions.ToString(window) + "--" + text;
						int windowTextLength = WinAPI.GetWindowTextLength(window);
						text = new string('\0', 255);
						WinAPI.GetWindowTextA(window, ref text, 250);
						text = Strings.Left(text, windowTextLength);
						text2 = text2 + "--" + text;
						Interaction.MsgBox(text2, MsgBoxStyle.OkOnly, null);
						this.method_3(ref window);
						window = WinAPI.GetWindow(window, 2);
					}
				}
			}
		}

		private void method_4(ref int int_5)
		{
			string text = new string('\0', 255);
			WinAPI.GetClassNameA(int_5, ref text, 250);
			text = Strings.Left(text, checked(Strings.InStr(text, new string('\0', 1), CompareMethod.Binary) - 1));
			string text2 = Conversions.ToString(int_5);
			text2 = text2 + "--" + text;
			int windowTextLength = WinAPI.GetWindowTextLength(int_5);
			text = new string('\0', 255);
			WinAPI.GetWindowTextA(int_5, ref text, 250);
			text = Strings.Left(text, windowTextLength);
			text2 = text2 + "--" + text;
			Interaction.MsgBox(text2, MsgBoxStyle.OkOnly, null);
			this.method_3(ref int_5);
		}

		public bool ADA_EnumWindowsProc(int hWnd, int lParam)
		{
			if (WinAPI.IsWindowVisible(hWnd))
			{
				int num = checked(WinAPI.GetWindowTextLength(hWnd) + 1);
				StringBuilder stringBuilder = new StringBuilder(num);
				WinAPI.GetWindowText(hWnd, stringBuilder, num);
				string prompt = stringBuilder.ToString();
				Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
			}
			return true;
		}

		private static void smethod_0(object object_0, object object_1)
		{
			Interaction.MsgBox("CD", MsgBoxStyle.OkOnly, null);
		}

		[CommandMethod("TcAddTrayButton")]
		public void TcAddTrayButton()
		{
			Pane pane = new Pane();
			pane.Enabled = true;
			pane.Visible = true;
			pane.Style = 8;
			pane.Text = "增加按钮";
			pane.ToolTipText = "这是新增加的按钮.";
			if (!初始化设置.bool_0)
			{
				pane.MouseDown += new StatusBarMouseDownEventHandler(this.method_5);
				Application.StatusBar.Panes.Add(pane);
				Application.StatusBar.Update();
				初始化设置.bool_0 = true;
			}
		}

		private static void smethod_1(Pane pane_0, object object_0)
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Pane pane = (Pane)pane_0;
			if (pane.Style == 2)
			{
				pane.Style = 8;
				editor.WriteMessage("{0}<activated>", new object[]
				{
					Environment.NewLine
				});
				Utils.PostCommandPrompt();
			}
			else
			{
				pane.Style = 2;
				editor.WriteMessage("{0}<de-activated>", new object[]
				{
					Environment.NewLine
				});
				Utils.PostCommandPrompt();
			}
			Application.StatusBar.Update();
		}

		private void method_5(object sender, StatusBarMouseDownEventArgs e)
		{
			ContextMenu contextMenu = new ContextMenu();
			contextMenu.Name = "my menu";
			contextMenu.MenuItems.Add(new MenuItem("item", delegate(object sender, EventArgs e)
			{
				初始化设置.smethod_2(RuntimeHelpers.GetObjectValue(sender), (StatusBarMouseDownEventArgs)e);
			}));
			contextMenu.MenuItems.Add(new MenuItem("item2", delegate(object sender, EventArgs e)
			{
				初始化设置.smethod_2(RuntimeHelpers.GetObjectValue(sender), (StatusBarMouseDownEventArgs)e);
			}));
			MenuItem menuItem = new MenuItem("item3");
			MenuItem menuItem2 = new MenuItem("subItem", new EventHandler(this.method_6));
			menuItem2.Select += this.method_6;
			menuItem.MenuItems.Add(menuItem2);
			contextMenu.MenuItems.Add(menuItem);
			Pane pane = (Pane)sender2;
			StatusBarItem statusBarItem = pane;
			ContextMenu contextMenu2 = contextMenu;
			Point point = new Point(e2.X, e2.Y);
			statusBarItem.DisplayContextMenu(contextMenu2, point);
		}

		private void method_6(object sender, EventArgs e)
		{
			Interaction.MsgBox(" MenuItem1_Click", MsgBoxStyle.OkOnly, null);
		}

		private static void smethod_2(object object_0, object object_1)
		{
			Interaction.MsgBox("SubItemButton", MsgBoxStyle.OkOnly, null);
		}

		[CommandMethod("TcTrayItemsAdd")]
		public void TcTrayItemsAdd()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			TrayItem trayItem = new TrayItem();
			trayItem.ToolTipText = "My tray item tooltip";
			trayItem.Visible = true;
			trayItem.Icon = new Icon(this.IconPath);
			Application.StatusBar.TrayItems.Add(trayItem);
			Application.UpdateScreen();
		}

		private void jipAtgRsh()
		{
			object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(objectValue, null, "Display", new object[0], null, null, null), null, "DisplayScrollBars", new object[]
			{
				false
			}, null, null, false, true);
		}

		[CommandMethod("AutoLoad_田草CAD工具箱")]
		public void AutoLoad()
		{
			string text = Assembly.GetExecutingAssembly().GetName().CodeBase;
			if (Strings.StrComp(Strings.LCase(Strings.Left(text, 8)), "file:///", CompareMethod.Binary) == 0)
			{
				text = Strings.Mid(text, 9);
			}
			string text2 = "TC_田草CAD工具箱";
			string cadregPath = CAD.GetCADRegPath();
			RegistryKey localMachine = Registry.LocalMachine;
			string text3 = cadregPath;
			RegistryKey registryKey = localMachine.OpenSubKey(text3, true);
			if (registryKey != null)
			{
				registryKey.CreateSubKey(text2);
				RegistryKey registryKey2 = localMachine.OpenSubKey(text3 + text2, true);
				registryKey2.SetValue("loader", text);
				registryKey2.SetValue("LoadCtrls", 2);
				registryKey2.SetValue("MANAGED", 1);
				registryKey2.SetValue("DESCRIPTION", text2);
			}
			if (Information.Err().Number <= 0)
			{
			}
		}

		[CommandMethod("UnLoad_田草CAD工具箱")]
		public void UnLoad()
		{
			int num2;
			int num4;
			object obj2;
			try
			{
				IL_01:
				int num = 1;
				string subkey = "TC_田草CAD工具箱";
				IL_09:
				num = 2;
				string text = CAD.GetCADRegPath();
				IL_11:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_1A:
				num = 4;
				object localMachine = Registry.LocalMachine;
				IL_23:
				num = 5;
				object instance = localMachine;
				Type type = null;
				string memberName = "OpenSubKey";
				object[] array = new object[]
				{
					text,
					true
				};
				object[] arguments = array;
				string[] argumentNames = null;
				Type[] typeArguments = null;
				bool[] array2 = new bool[]
				{
					true,
					false
				};
				object obj = NewLateBinding.LateGet(instance, type, memberName, arguments, argumentNames, typeArguments, array2);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				RegistryKey registryKey = (RegistryKey)obj;
				IL_90:
				num = 6;
				if (registryKey == null)
				{
					goto IL_A4;
				}
				IL_9B:
				num = 7;
				registryKey.DeleteSubKeyTree(subkey);
				IL_A4:
				goto IL_123;
				IL_A6:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_DA:
				goto IL_118;
				IL_DC:
				num4 = num;
				if (num2 <= -2)
				{
					goto IL_A6;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_F4:;
			}
			catch when (endfilter(obj2 is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_DC;
			}
			IL_118:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_123:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("AddCOMEndCommand")]
		public void AddCOMEndCommand()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.CommandEnded += new CommandEventHandler(this.EndCommad);
		}

		[CommandMethod("DelCOMEndCommand")]
		public void DelCOMEndCommand()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.CommandEnded -= new CommandEventHandler(this.EndCommad);
		}

		public void EndCommad(object sender, CommandEventArgs e)
		{
		}

		[CommandMethod("AddCOMEventFileHistory")]
		public void AddDocumentCreateStartedEvent()
		{
			Application.DocumentManager.DocumentCreateStarted += new DocumentCollectionEventHandler(this.method_7);
		}

		[CommandMethod("RemoveCOMEventFileHistory")]
		public void RemoveDocumentCreateStartedEvent()
		{
			Application.DocumentManager.DocumentCreateStarted -= new DocumentCollectionEventHandler(this.method_7);
		}

		private void method_7(object sender, DocumentCollectionEventArgs e)
		{
			e.Document.BeginDwgOpen += new DrawingOpenEventHandler(this.Document_BeginDwgOpen);
		}

		public void Document_BeginDwgOpen(object sender, DrawingOpenEventArgs e)
		{
			int num;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string fileName = e.FileName;
				IL_13:
				num2 = 3;
				ArrayList arrayList = new ArrayList();
				IL_1B:
				num2 = 4;
				NF.ReadTxtFile(this.string_0 + "\\Data\\FileHistory.txt", ref arrayList);
				IL_35:
				num2 = 5;
				short num3 = checked((short)arrayList.Count);
				IL_3F:
				num2 = 6;
				IEnumerator enumerator = arrayList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
					IL_5D:
					num2 = 7;
					if (!NF.FileExist(Conversions.ToString(objectValue)))
					{
						IL_70:
						num2 = 8;
						arrayList.Remove(RuntimeHelpers.GetObjectValue(objectValue));
					}
					IL_7F:
					num2 = 10;
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_9D:
				num2 = 11;
				NF.ClearArrayList(ref arrayList);
				IL_A8:
				num2 = 12;
				if (arrayList.Contains(fileName))
				{
					goto IL_C4;
				}
				IL_B8:
				num2 = 13;
				arrayList.Add(fileName);
				IL_C4:
				num2 = 15;
				NF.SaveTxtFile(this.string_0 + "\\Data\\FileHistory.txt", arrayList);
				IL_DE:
				num2 = 16;
				if (Information.Err().Number <= 0)
				{
					goto IL_FD;
				}
				IL_F0:
				num2 = 17;
				Information.Err().Clear();
				IL_FD:
				goto IL_1A4;
				IL_102:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_15E:
				goto IL_199;
				IL_160:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_102;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_176:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_160;
			}
			IL_199:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1A4:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void method_8(object sender, PreTranslateMessageEventArgs e)
		{
			object left = e.Message.wParam.ToInt64();
			if (e.Message.message == 516 && Operators.ConditionalCompareObjectNotEqual(left, 6, false) && Operators.ConditionalCompareObjectNotEqual(left, 4, false))
			{
				e.Handled = true;
			}
			if (e.Message.message == 517 && Operators.ConditionalCompareObjectNotEqual(left, 4, false))
			{
				Application.PreTranslateMessage -= new PreTranslateMessageEventHandler(this.method_8);
				e.Handled = true;
			}
		}

		[CommandMethod("TcEntFunction")]
		public void TcEntFunction()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			Database database = mdiActiveDocument.Database;
			Transaction transaction = database.TransactionManager.StartTransaction();
			PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\n选择一个对象: ");
			PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
			if (entity.Status == 5100)
			{
				ArrayList arrayList = new ArrayList();
				using (transaction)
				{
					try
					{
						DBObject @object = entity.ObjectId.GetObject(0);
						foreach (MemberInfo memberInfo in @object.GetType().GetMembers())
						{
							arrayList.Add(memberInfo.Name.ToString());
						}
						transaction.Commit();
					}
					catch (Exception ex)
					{
						throw;
					}
				}
				NF.SaveTxtFile("C:\\\\temp.txt", arrayList);
			}
		}

		[CommandMethod("TcMenu")]
		public void CreateMenu3()
		{
			int num;
			int num15;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Interaction.MsgBox("本命令只需要执行一次即可，菜单加至AutoCAD会保存在配置文件中。", MsgBoxStyle.OkOnly, null);
				IL_18:
				num2 = 3;
				CustomizationSection customizationSection = new CustomizationSection(Conversions.ToString(Operators.AddObject(Application.GetSystemVariable("MENUNAME"), ".cuix")));
				IL_39:
				num2 = 4;
				if (!customizationSection.MenuGroup.MacroGroups.Contains("ByCAD工具箱_工具条命令"))
				{
					goto IL_68;
				}
				IL_52:
				num2 = 5;
				MacroGroup macroGroup = customizationSection.MenuGroup.FindMacroGroup("ByCAD工具箱_工具条命令");
				goto IL_7E;
				IL_68:
				num2 = 7;
				IL_6A:
				num2 = 8;
				macroGroup = new MacroGroup("ByCAD工具箱_工具条命令", customizationSection.MenuGroup);
				IL_7E:
				num2 = 10;
				if (NF.FileExist(this.string_0 + "\\menu.txt"))
				{
					goto IL_A0;
				}
				IL_9B:
				goto IL_4DD;
				IL_A0:
				num2 = 13;
				ArrayList arrayList = new ArrayList();
				IL_AA:
				num2 = 14;
				NF.ReadTxtFile(this.string_0 + "\\menu.txt", ref arrayList);
				IL_C5:
				num2 = 15;
				checked
				{
					short num3 = (short)arrayList.Count;
					IL_D2:
					num2 = 16;
					string[] array = null;
					IL_D7:
					num2 = 17;
					Toolbar[] array2 = null;
					IL_DD:
					num2 = 18;
					ToolbarButton[] array3 = null;
					IL_E3:
					num2 = 19;
					short num4 = 0;
					short num5 = num3 - 1;
					short num6 = num4;
					for (;;)
					{
						short num7 = num6;
						short num8 = num5;
						if (num7 > num8)
						{
							break;
						}
						IL_FD:
						num2 = 20;
						string text = arrayList[(int)num6].ToString();
						IL_110:
						num2 = 21;
						string s = text;
						string text2 = ",";
						NF.Str2Arr(s, ref array, ref text2);
						IL_125:
						num2 = 22;
						short num9 = (short)NF.InStr_N(text, ",");
						IL_137:
						num2 = 23;
						if (num9 == 0)
						{
							IL_141:
							num2 = 24;
							array2 = new Toolbar[(int)Math.Round(Conversion.Val(array[0])) + 1];
						}
						else
						{
							IL_160:
							num2 = 28;
							if (num9 == 1)
							{
								IL_16D:
								num2 = 29;
								short num10;
								if (customizationSection.MenuGroup.Toolbars.IsNameFree(array[0]))
								{
									IL_185:
									num2 = 30;
									array2[(int)num10] = new Toolbar(array[0], customizationSection.MenuGroup);
									IL_19B:
									num2 = 31;
									array2[(int)num10].ElementID = "ID_" + array[0];
									IL_1B5:
									num2 = 32;
									array2[(int)num10].ToolbarOrient = 4;
									IL_1C3:
									num2 = 33;
									array2[(int)num10].ToolbarVisible = 1;
								}
								else
								{
									IL_1D3:
									num2 = 35;
									IL_1D6:
									num2 = 36;
									array2[(int)num10] = customizationSection.MenuGroup.Toolbars.FindToolbarWithName(array[0]);
									IL_1F1:
									num2 = 37;
									array2[(int)num10].ToolbarItems.Clear();
								}
								IL_203:
								num2 = 39;
								num10 += 1;
							}
							else
							{
								IL_212:
								num2 = 41;
								if (num9 == 2)
								{
									IL_21C:
									num2 = 42;
									array3 = new ToolbarButton[(int)Math.Round(Conversion.Val(array[0])) + 1];
								}
								else
								{
									IL_23B:
									num2 = 46;
									if (num9 == 5)
									{
										IL_248:
										num2 = 47;
										short num11;
										num11 += 1;
										IL_252:
										num2 = 48;
										string text3 = this.string_0 + "\\images\\small\\" + array[3] + ".bmp";
										IL_26F:
										num2 = 49;
										MenuMacro menuMacro = macroGroup.CreateMenuMacro(array[0], array[2] + " ", array[1], array[3], 0, text3, text3, array[4]);
										IL_299:
										num2 = 50;
										short num12;
										array3[(int)num12] = new ToolbarButton(array2[Conversions.ToInteger(array[4])], -1);
										IL_2B2:
										num2 = 51;
										array3[(int)num12].Name = array[0];
										IL_2C2:
										num2 = 52;
										array3[(int)num12].MacroID = menuMacro.ElementID;
										IL_2D6:
										num2 = 53;
										num12 += 1;
									}
									else
									{
										IL_2E2:
										num2 = 55;
										if (num9 == 4)
										{
											IL_2EC:
											num2 = 56;
											short num13;
											num13 += 1;
											IL_2F6:
											num2 = 57;
											ToolbarFlyout toolbarFlyout = new ToolbarFlyout(array2[Conversions.ToInteger(array[4])], -1);
											IL_30C:
											num2 = 58;
											toolbarFlyout.ToolbarReference = array2[(int)num13].Name;
										}
									}
								}
							}
						}
						IL_331:
						num2 = 60;
						array = null;
						IL_322:
						num2 = 61;
						unchecked
						{
							num6 += 1;
						}
					}
					IL_338:
					num2 = 62;
					customizationSection.SetIsModified();
					IL_341:
					num2 = 63;
					customizationSection.Save(true);
					IL_34C:
					num2 = 64;
					Application.ReloadAllMenus();
					IL_354:
					IL_359:
					goto IL_4DD;
					IL_35E:;
				}
				int num14 = num15 + 1;
				num15 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num14);
				IL_47A:
				goto IL_4D2;
				IL_47C:
				num2 = 66;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				goto IL_359;
				IL_496:
				num15 = num2;
				if (num <= -2)
				{
					goto IL_35E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4AF:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num15 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_496;
			}
			IL_4D2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_4DD:
			if (num15 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcPath")]
		public void TcPath()
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
				Process.Start(this.string_0);
				IL_17:
				goto IL_77;
				IL_19:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_33:
				goto IL_6C;
				IL_35:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_19;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_35;
			}
			IL_6C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_77:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcAutoSavePath")]
		public void TcAutoSavePath()
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
				Conversions.ToString(Application.GetSystemVariable(""));
				IL_1B:
				num2 = 3;
				Process.Start(this.string_0);
				IL_29:
				goto IL_8D;
				IL_2B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_49:
				goto IL_82;
				IL_4B:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_2B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_60:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
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

		[CommandMethod("SetSB")]
		public static void SetSnapBase()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			Interaction.MsgBox(Application.GetSystemVariable("USERS1").ToString(), MsgBoxStyle.OkOnly, null);
			object systemVariable = Application.GetSystemVariable("SNAPBASE");
			Point2d point2d2;
			Point2d point2d = (systemVariable != null) ? ((Point2d)systemVariable) : point2d2;
			editor.WriteMessage("SNAPBASE: X={0} Y={1}", new object[]
			{
				point2d.X,
				point2d.Y
			});
			Point2d point2d3;
			point2d3..ctor(2.0, 2.0);
			Application.SetSystemVariable("SNAPBASE", point2d3);
			editor.WriteMessage("SNAPBASE: X={0} Y={1} ", new object[]
			{
				point2d.X,
				point2d.Y
			});
		}

		[CommandMethod("BBO")]
		public void testBlockBound()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			BlockReference blockReference = null;
			mdiActiveDocument.TransactionManager.EnableGraphicsFlush(true);
			try
			{
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\nSelect block: ");
				promptEntityOptions.SetRejectMessage("Only a block instance !");
				promptEntityOptions.AddAllowedClass(typeof(BlockReference), false);
				PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
				if (entity.Status == 5100)
				{
					ObjectId objectId = entity.ObjectId;
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						Entity entity2 = (Entity)transaction.GetObject(objectId, 0);
						if (entity2 != null)
						{
							BlockReference blockReference2 = entity2 as BlockReference;
							if (blockReference2 != null)
							{
								blockReference = (blockReference2.Clone() as BlockReference);
								blockReference.Rotation = 0.0;
								blockReference.TransformBy(editor.CurrentUserCoordinateSystem);
								transaction.TransactionManager.QueueForGraphicsFlush();
								Extents3d extents3d = blockReference.GeometryExtentsBestFit(editor.CurrentUserCoordinateSystem);
								extents3d.TransformBy(editor.CurrentUserCoordinateSystem);
								Polyline polyline = new Polyline(4);
								Point3d point3d = extents3d.MinPoint.TransformBy(editor.CurrentUserCoordinateSystem);
								Point3d point3d2 = extents3d.MaxPoint;
								Point3d point3d3 = point3d2.TransformBy(editor.CurrentUserCoordinateSystem);
								point3d2..ctor(point3d3.X, point3d.Y, point3d.Z);
								Point3d point3d4 = point3d2;
								Point3d point3d5 = point3d4.TransformBy(editor.CurrentUserCoordinateSystem);
								point3d4..ctor(point3d.X, point3d3.Y, point3d.Z);
								point3d2 = point3d4;
								Point3d point3d6 = point3d2.TransformBy(editor.CurrentUserCoordinateSystem);
								Polyline polyline2 = polyline;
								int num = 0;
								Point2d point2d;
								point2d..ctor(point3d.X, point3d.Y);
								polyline2.AddVertexAt(num, point2d, 0.0, 0.0, 0.0);
								Polyline polyline3 = polyline;
								int num2 = 1;
								point2d..ctor(point3d5.X, point3d5.Y);
								polyline3.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
								Polyline polyline4 = polyline;
								int num3 = 2;
								point2d..ctor(point3d3.X, point3d3.Y);
								polyline4.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
								Polyline polyline5 = polyline;
								int num4 = 3;
								point2d..ctor(point3d6.X, point3d6.Y);
								polyline5.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
								polyline.Closed = true;
								polyline.ColorIndex = 121;
								polyline.TransformBy(editor.CurrentUserCoordinateSystem);
								Matrix3d matrix3d = Matrix3d.Rotation(blockReference2.Rotation, blockReference2.Normal.GetNormal(), blockReference2.Position);
								polyline.TransformBy(matrix3d);
								BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(database.CurrentSpaceId, 1);
								blockTableRecord.AppendEntity(polyline);
								transaction.AddNewlyCreatedDBObject(polyline, true);
								transaction.TransactionManager.QueueForGraphicsFlush();
								mdiActiveDocument.TransactionManager.FlushGraphics();
								transaction.Commit();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				editor.WriteMessage("\nError: {0}\n{1}", new object[]
				{
					ex.Message,
					ex.StackTrace
				});
			}
			finally
			{
				if (!blockReference.IsDisposed)
				{
					blockReference.Dispose();
				}
			}
		}

		[CommandMethod("TcPGP1")]
		public void TcPGP1()
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
				object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
				IL_17:
				num2 = 3;
				object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Files", new object[0], null, null, null));
				IL_36:
				num2 = 4;
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "SupportPath", new object[0], null, null, null));
				IL_55:
				num2 = 5;
				string[] array = null;
				IL_5A:
				num2 = 6;
				string s = text;
				string text2 = ";";
				NF.Str2Arr(s, ref array, ref text2);
				IL_6E:
				num2 = 7;
				short num3 = 0;
				short num4 = checked((short)Information.UBound(array, 1));
				short num5 = num3;
				string text3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					IL_84:
					num2 = 8;
					text3 = array[(int)num5] + "/acad.pgp";
					IL_96:
					num2 = 9;
					if (NF.FileExist(text3))
					{
						goto IL_D8;
					}
					IL_A2:
					num2 = 14;
					num5 += 1;
				}
				IL_AC:
				num2 = 15;
				if (Information.Err().Number <= 0)
				{
					goto IL_D3;
				}
				IL_BE:
				num2 = 16;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_D3:
				goto IL_193;
				IL_D8:
				num2 = 10;
				Process.Start(text3);
				IL_E3:
				num2 = 11;
				Class36.smethod_60("修改后保存，可使用命令reinit初始化新修改的PGP文件");
				IL_F1:
				goto IL_193;
				IL_F6:
				goto IL_19E;
				IL_FB:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_113;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_16D;
				IL_113:
				int num9 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_16D:
				goto IL_19E;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_FB;
			}
			IL_193:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_19E:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcPGP")]
		public void TcPGP()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
				IL_16:
				num2 = 3;
				object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Files", new object[0], null, null, null));
				IL_33:
				num2 = 4;
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "SupportPath", new object[0], null, null, null));
				IL_51:
				num2 = 5;
				string[] array = null;
				IL_56:
				num2 = 6;
				string s = text;
				string text2 = ";";
				NF.Str2Arr(s, ref array, ref text2);
				IL_6A:
				num2 = 7;
				short num3 = 0;
				short num4 = checked((short)Information.UBound(array, 1));
				short num5 = num3;
				string text3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						goto IL_E9;
					}
					IL_84:
					num2 = 8;
					text3 = array[(int)num5] + "/acad.pgp";
					IL_97:
					num2 = 9;
					if (NF.FileExist(text3))
					{
						break;
					}
					IL_A3:
					num2 = 16;
					num5 += 1;
				}
				IL_AF:
				num2 = 10;
				TcPGP_Frm tcPGP_Frm = new TcPGP_Frm();
				IL_B9:
				num2 = 11;
				tcPGP_Frm.Label1.Text = text3;
				IL_CA:
				num2 = 12;
				Application.ShowModalDialog(tcPGP_Frm);
				IL_D5:
				num2 = 13;
				Application.SetSystemVariable("RE-INIT", 16);
				IL_E9:
				num2 = 17;
				if (Information.Err().Number <= 0)
				{
					goto IL_110;
				}
				IL_FB:
				num2 = 18;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_110:
				goto IL_1BB;
				IL_115:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_175:
				goto IL_1B0;
				IL_177:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_115;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_18D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_177;
			}
			IL_1B0:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1BB:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcAddPGP")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void AddPGP()
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox("如果你使用探索者结构，请修改TcPGP文件后再添加简化命令。", MsgBoxStyle.OkCancel, null);
			if (msgBoxResult != MsgBoxResult.Ok)
			{
				Process.Start("Http://www.tiancao.net/");
			}
			object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
			object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Files", new object[0], null, null, null));
			string text = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "SupportPath", new object[0], null, null, null));
			string[] array = null;
			string s = text;
			string text2 = ";";
			NF.Str2Arr(s, ref array, ref text2);
			short num = 0;
			short num2 = checked((short)Information.UBound(array, 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				string text3 = array[(int)num3] + "\\acad.pgp";
				checked
				{
					if (NF.FileExist(text3))
					{
						string text4 = File.ReadAllText(text3, Encoding.GetEncoding(936));
						string path = Class33.Class31_0.Info.DirectoryPath + "\\TcPGP.txt";
						string text5 = File.ReadAllText(path, Encoding.GetEncoding(936));
						text4 = text4.Replace("C,         *CIRCLE", "C,         *COPY\r\nCI,         *CIRCLE");
						text4 = text4.Replace("C,\t\t*CIRCLE", "C,         *COPY\r\nCI,         *CIRCLE");
						short num6 = (short)text4.IndexOf(";;田草CAD工具箱");
						if (num6 <= 0)
						{
							string contents = text4 + "\r\n" + text5;
							File.WriteAllText(text3, contents, Encoding.GetEncoding(936));
						}
						else
						{
							int num7 = text4.IndexOf(";;田草CAD工具箱Start");
							int num8 = text4.IndexOf(";;田草CAD工具箱End");
							string oldValue = text4.Substring(num7, num8 - num7 + 13);
							text4 = text4.Replace(oldValue, text5);
							File.WriteAllText(text3, text4, Encoding.GetEncoding(936));
						}
						Application.SetSystemVariable("RE-INIT", 16);
					}
				}
				num3 += 1;
			}
			if (Information.Err().Number > 0)
			{
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			}
			else
			{
				Class36.smethod_60("田草CAD工具箱简化命令 添加更新完毕!");
			}
		}

		[CommandMethod("TcCopyPGP")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void method_9()
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
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				IL_1C:
				num2 = 3;
				string source = directoryPath + "/support/acad.pgp";
				IL_2C:
				num2 = 4;
				object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
				IL_3A:
				num2 = 5;
				object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Files", new object[0], null, null, null));
				IL_59:
				num2 = 6;
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "SupportPath", new object[0], null, null, null));
				IL_78:
				num2 = 7;
				string[] array = null;
				IL_7C:
				num2 = 8;
				string s = text;
				string text2 = ";";
				NF.Str2Arr(s, ref array, ref text2);
				IL_90:
				num2 = 9;
				short num3 = 0;
				short num4 = checked((short)Information.UBound(array, 1));
				short num5 = num3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						goto IL_EE;
					}
					IL_A8:
					num2 = 10;
					string str_File = array[(int)num5] + "/acad.pgp";
					IL_BA:
					num2 = 11;
					if (NF.FileExist(str_File))
					{
						break;
					}
					IL_C6:
					num2 = 16;
					num5 += 1;
				}
				IL_D0:
				num2 = 12;
				string str = array[(int)num5];
				IL_D8:
				num2 = 13;
				Microsoft.VisualBasic.FileSystem.FileCopy(source, str + "/acad.pgp");
				IL_EE:
				num2 = 17;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_FD:
				num2 = 18;
				mdiActiveDocument.SendStringToExecute("(command \"re-init\" 16) ", true, false, false);
				IL_10F:
				num2 = 19;
				if (Information.Err().Number <= 0)
				{
					goto IL_136;
				}
				IL_121:
				num2 = 20;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_136:
				goto IL_1EB;
				IL_13B:
				goto IL_1F6;
				IL_140:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_158;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_1C5;
				IL_158:
				int num9 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_1C5:
				goto IL_1F6;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_140;
			}
			IL_1EB:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_1F6:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcChangeToolPalettePath")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void ChangeToolPalettePath()
		{
			string text = Class33.Class31_0.Info.DirectoryPath + "\\Toolpalette\\Palettes";
			ArrayList floderFilesList = NF.GetFLoderFilesList(text);
			try
			{
				try
				{
					foreach (object obj in floderFilesList)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						text = Conversions.ToString(Operators.ConcatenateObject(this.string_0 + "\\Toolpalette\\Palettes\\", objectValue));
						if (File.Exists(text))
						{
							string text2 = File.ReadAllText(text);
							int num = text2.IndexOf("<SourceFile>");
							int num2 = text2.IndexOf("</SourceFile>");
							if (num > 0)
							{
								string fileName = checked(text2.Substring(num + 12, num2 - num - 12));
								string filePath = NF.GetFilePath(fileName);
								string contents = Strings.Replace(text2, filePath, this.string_0 + "\\DWG", 1, -1, CompareMethod.Binary);
								File.WriteAllText(text, contents);
								Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(objectValue, "\r\n"), "\r\n"), "原路径:"), "\r\n"), filePath), "\r\n"), "替换为:"), "\r\n"), this.string_0), "\\DWG"), "\r\n"), "替换成功!"), MsgBoxStyle.OkOnly, null);
							}
						}
					}
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
			catch (Exception ex)
			{
				Interaction.MsgBox("修改失败!", MsgBoxStyle.OkOnly, null);
			}
			string name = this.GetActiveProfileRegPath() + "\\General\\";
			string value = this.string_0 + "\\ToolPalette";
			RegistryKey currentUser = Class33.Class32_0.Registry.CurrentUser;
			RegistryKey registryKey = currentUser.OpenSubKey(name, true);
			if (registryKey != null)
			{
				registryKey.SetValue("ToolPalettePath", value);
			}
			Interaction.MsgBox("工具选项板安装成功，重启AutoCAD，按Ctrl+3快捷键看看效果吧.", MsgBoxStyle.OkOnly, null);
		}

		public string GetActiveProfileRegPath()
		{
			object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
			string str = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, null, "Profiles", new object[0], null, null, null), null, "ActiveProfile", new object[0], null, null, null));
			string cad = Application.Version.ToString().Substring(0, 4);
			string autoCAD_RegistryPath = NF.GetAutoCAD_RegistryPath(cad);
			return autoCAD_RegistryPath + "Profiles\\" + str;
		}

		[CommandMethod("TcChangeDesignCenterPath")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void ChangeDesignCenterPath()
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
				string name = "Software\\Autodesk\\AutoCAD\\R18.0\\ACAD-8001:804\\AutodeskApps\\AcadDC\\History\\DesignCenter\\Last State";
				IL_12:
				num2 = 3;
				string value = Class33.Class31_0.Info.DirectoryPath + "\\DWG";
				IL_2F:
				num2 = 4;
				RegistryKey currentUser = Class33.Class32_0.Registry.CurrentUser;
				IL_41:
				num2 = 5;
				IL_43:
				num2 = 6;
				RegistryKey registryKey = currentUser.OpenSubKey(name, true);
				IL_50:
				num2 = 7;
				if (registryKey == null)
				{
					goto IL_8D;
				}
				IL_5C:
				num2 = 8;
				registryKey.SetValue("Set as Home", value);
				IL_6C:
				num2 = 9;
				registryKey.SetValue("Selected Item", value);
				IL_7D:
				num2 = 10;
				Interaction.MsgBox("设置成功，你可以按下Ctrl+2看看效果.", MsgBoxStyle.OkOnly, null);
				IL_8D:
				goto IL_114;
				IL_92:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_D0:
				goto IL_109;
				IL_D2:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_92;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_E7:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_D2;
			}
			IL_109:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_114:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcCalc")]
		public void TcCalc()
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
			Interaction.Shell(folderPath + "\\calc.exe", AppWinStyle.NormalFocus, false, -1);
		}

		[CommandMethod("TcDKKF")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcDKKF()
		{
			string directoryPath = Class33.Class31_0.Info.DirectoryPath;
			Interaction.Shell(directoryPath + "\\地库抗浮.exe", AppWinStyle.NormalFocus, false, -1);
		}

		[CommandMethod("TcTXM")]
		public void TcTXM()
		{
			Code128_Cls code128_Cls = new Code128_Cls();
			string defaultResponse = NF.Time2String();
			string yuanMa = Interaction.InputBox("输入二维码字符串:", "ByCAD工具箱-绘制条形码", defaultResponse, -1, -1);
			Point3d point = CAD.GetPoint("选择插入点: ");
			code128_Cls.method_0(point, yuanMa, "Code128B", 40L, 100.0, "H");
		}

		[CommandMethod("TcEWM")]
		public void TcEWM()
		{
			QRCode_Frm qrcode_Frm = new QRCode_Frm();
			Application.ShowModelessDialog(qrcode_Frm);
		}

		[CommandMethod("TcShaDu")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcShaDu()
		{
			string text = Class33.Class31_0.Info.DirectoryPath + "\\AutoCAD病毒专杀.exe";
			if (NF.FileExist(text))
			{
				Interaction.MsgBox("AutoCAD病毒专杀启动后宜关闭AutoCAD，待病毒清除后再启动AutoCAD。", MsgBoxStyle.OkOnly, null);
				Interaction.Shell(text, AppWinStyle.NormalFocus, false, -1);
			}
			else
			{
				short num = checked((short)Interaction.MsgBox("未找到AutoCAD病毒专杀工具，请访问http://www.tiancao.net/下载最新版本。", MsgBoxStyle.OkCancel, null));
				if (num == 1)
				{
					Interaction.Shell("rundll32 url.dll FileProtocolHandler http://www.tiancao.net/", AppWinStyle.MinimizedFocus, false, -1);
				}
			}
		}

		[CommandMethod("TcJiaoYu")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcJiaoYu()
		{
			string text = Class33.Class31_0.Info.DirectoryPath + "\\自动去除教育版戳记\\SetupV3.exe";
			if (NF.FileExist(text))
			{
				Interaction.Shell(text, AppWinStyle.NormalFocus, false, -1);
			}
			else
			{
				short num = checked((short)Interaction.MsgBox("未找到自动去除教育版戳记工具，请访问http://www.tiancao.net/下载最新版本。", MsgBoxStyle.OkCancel, null));
				if (num == 1)
				{
					Interaction.Shell("rundll32 url.dll FileProtocolHandler http://www.tiancao.net/", AppWinStyle.MinimizedFocus, false, -1);
				}
			}
		}

		[CommandMethod("TcJiaoYu1")]
		public void TcJiaoYu1()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				object left = Class36.smethod_5();
				IL_11:
				num2 = 3;
				OpenFileDialog openFileDialog = new OpenFileDialog("打开带有教育版戳记的DWG文件", "", "DWG", "", 4096);
				IL_32:
				num2 = 4;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					goto IL_47;
				}
				IL_42:
				goto IL_28E;
				IL_47:
				num2 = 7;
				string[] filenames = openFileDialog.GetFilenames();
				IL_51:
				num2 = 8;
				short num3 = 0;
				short num4 = checked((short)Information.UBound(filenames, 1));
				short num5 = num3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 <= num7)
					{
						IL_6E:
						num2 = 9;
						Interaction.MsgBox(filenames[(int)num5].ToString(), MsgBoxStyle.OkOnly, null);
						IL_83:
						num2 = 10;
						string filePath = NF.GetFilePath(filenames[(int)num5]);
						IL_92:
						num2 = 11;
						string text = NF.GetFileName(filenames[(int)num5]);
						IL_A1:
						num2 = 12;
						text = Strings.Replace(text, ".dwg", "_no.dwg", 1, -1, CompareMethod.Binary);
						IL_BA:
						num2 = 13;
						string text2 = filePath + "\\" + text;
						IL_CD:
						num2 = 14;
						Interaction.MsgBox(text2, MsgBoxStyle.OkOnly, null);
						IL_DA:
						num2 = 15;
						Database database = new Database(false, true);
						IL_E6:
						num2 = 16;
						database.ReadDwgFile(filenames[(int)num5], FileShare.ReadWrite, true, "");
						IL_FC:
						num2 = 17;
						using (Transaction transaction = database.TransactionManager.StartTransaction())
						{
							database.DxfOut(Conversions.ToString(Operators.ConcatenateObject(left, "\\temp.dxf")), 0, 31);
							transaction.Dispose();
							goto IL_195;
						}
						IL_142:
						num2 = 20;
						Document document = DocumentCollectionExtension.Open(Application.DocumentManager, Conversions.ToString(Operators.ConcatenateObject(left, "\\temp.dxf")), false);
						IL_162:
						num2 = 21;
						document.Database.SaveAs(text2, 31);
						IL_175:
						num2 = 22;
						DocumentCollectionExtension.Open(Application.DocumentManager, text2, false);
						IL_186:
						num2 = 23;
						num5 += 1;
						continue;
						IL_195:
						num2 = 19;
						database = null;
						goto IL_142;
					}
					break;
				}
				IL_19D:
				num2 = 24;
				if (Information.Err().Number <= 0)
				{
					goto IL_1C4;
				}
				IL_1AF:
				num2 = 25;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1C4:
				goto IL_28E;
				IL_1C9:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_245:
				goto IL_283;
				IL_247:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_1C9;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_260:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_247;
			}
			IL_283:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_28E:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcJiaoYu2")]
		public void TcJiaoYu2()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Class36.smethod_5();
				IL_27:
				num2 = 5;
				OpenFileDialog openFileDialog = new OpenFileDialog("打开带有教育版戳记的DWG文件", "", "DWG", "", 4096);
				IL_49:
				num2 = 6;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					goto IL_5F;
				}
				IL_5A:
				goto IL_2F6;
				IL_5F:
				num2 = 9;
				string[] filenames = openFileDialog.GetFilenames();
				IL_6B:
				num2 = 10;
				short num3 = 0;
				short num4 = checked((short)Information.UBound(filenames, 1));
				short num5 = num3;
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 <= num7)
					{
						IL_89:
						num2 = 11;
						Interaction.MsgBox(filenames[(int)num5].ToString(), MsgBoxStyle.OkOnly, null);
						IL_9E:
						num2 = 12;
						string filePath = NF.GetFilePath(filenames[(int)num5]);
						IL_AD:
						num2 = 13;
						string text = NF.GetFileName(filenames[(int)num5]);
						IL_BC:
						num2 = 14;
						text = Strings.Replace(text, ".dwg", "_no.dwg", 1, -1, CompareMethod.Binary);
						IL_D5:
						num2 = 15;
						string prompt = filePath + "\\" + text;
						IL_E8:
						num2 = 16;
						Interaction.MsgBox(prompt, MsgBoxStyle.OkOnly, null);
						IL_F5:
						num2 = 17;
						Database database2 = new Database(false, true);
						IL_101:
						num2 = 18;
						database2.ReadDwgFile(filenames[(int)num5], FileShare.Read, true, "");
						IL_117:
						num2 = 19;
						ObjectIdCollection objectIdCollection = new ObjectIdCollection();
						IL_121:
						num2 = 20;
						TransactionManager transactionManager = database2.TransactionManager;
						IL_12D:
						num2 = 21;
						using (Transaction transaction = transactionManager.StartTransaction())
						{
							BlockTable blockTable = (BlockTable)transactionManager.GetObject(database2.BlockTableId, 0, false);
							SymbolTableEnumerator enumerator = blockTable.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId objectId = enumerator.Current;
								BlockTableRecord blockTableRecord = (BlockTableRecord)transactionManager.GetObject(objectId, 0, false);
								if (blockTableRecord.IsLayout)
								{
									objectIdCollection.Add(objectId);
									blockTableRecord.Dispose();
								}
							}
							if (enumerator != null)
							{
								enumerator.Dispose();
							}
							blockTable.Dispose();
							transaction.Dispose();
							goto IL_1F1;
						}
						IL_1CC:
						num2 = 24;
						IdMapping idMapping;
						database2.WblockCloneObjects(objectIdCollection, database.BlockTableId, idMapping, 2, false);
						IL_1E2:
						num2 = 25;
						num5 += 1;
						continue;
						IL_1F1:
						num2 = 23;
						idMapping = new IdMapping();
						goto IL_1CC;
					}
					break;
				}
				IL_1FD:
				num2 = 26;
				if (Information.Err().Number <= 0)
				{
					goto IL_224;
				}
				IL_20F:
				num2 = 27;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_224:
				goto IL_2F6;
				IL_229:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_2AD:
				goto IL_2EB;
				IL_2AF:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_229;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2C8:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2AF;
			}
			IL_2EB:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2F6:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcGetAllSystemVar")]
		public void TcGetAllSystemVar()
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
				ArrayList arrayList = new ArrayList();
				IL_11:
				num2 = 3;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ACADLSPASDOC")));
				IL_29:
				num2 = 4;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ACADPREFIX")));
				IL_41:
				num2 = 5;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ACADVER")));
				IL_59:
				num2 = 6;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ACISOUTVER")));
				IL_71:
				num2 = 7;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("AFLAGS")));
				IL_89:
				num2 = 8;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ANGBASE")));
				IL_A1:
				num2 = 9;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ANGDIR")));
				IL_BA:
				num2 = 10;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("APBOX")));
				IL_D3:
				num2 = 11;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("APERTURE")));
				IL_EC:
				num2 = 12;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("AREA")));
				IL_105:
				num2 = 13;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ATTDIA")));
				IL_11E:
				num2 = 14;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ATTMODE")));
				IL_137:
				num2 = 15;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ATTREQ")));
				IL_150:
				num2 = 16;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("AUDITCTL")));
				IL_169:
				num2 = 17;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("AUNITS")));
				IL_182:
				num2 = 18;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("AUPREC")));
				IL_19B:
				num2 = 19;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("AUTOSNAP")));
				IL_1B4:
				num2 = 20;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("BACKZ")));
				IL_1CD:
				num2 = 21;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("BINDTYPE")));
				IL_1E6:
				num2 = 22;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("BLIPMODE")));
				IL_1FF:
				num2 = 23;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CDATE")));
				IL_218:
				num2 = 24;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CECOLOR")));
				IL_231:
				num2 = 25;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CELTSCALE")));
				IL_24A:
				num2 = 26;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CELTYPE")));
				IL_263:
				num2 = 27;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CELWEIGHT")));
				IL_27C:
				num2 = 28;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CHAMFERA")));
				IL_295:
				num2 = 29;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CHAMFERB")));
				IL_2AE:
				num2 = 30;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CHAMFERC")));
				IL_2C7:
				num2 = 31;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CHAMFERD")));
				IL_2E0:
				num2 = 32;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CHAMMODE")));
				IL_2F9:
				num2 = 33;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CIRCLERAD")));
				IL_312:
				num2 = 34;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CLAYER")));
				IL_32B:
				num2 = 35;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMDACTIVE")));
				IL_344:
				num2 = 36;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMDDIA")));
				IL_35D:
				num2 = 37;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMDECHO")));
				IL_376:
				num2 = 38;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMDNAMES")));
				IL_38F:
				num2 = 39;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMLJUST")));
				IL_3A8:
				num2 = 40;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMLSCALE")));
				IL_3C1:
				num2 = 41;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CMLSTYLE")));
				IL_3DA:
				num2 = 42;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("COMPASS")));
				IL_3F3:
				num2 = 43;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("COORDS")));
				IL_40C:
				num2 = 44;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CPLOTSTYLE")));
				IL_425:
				num2 = 45;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CPROFILE")));
				IL_43E:
				num2 = 46;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CTAB")));
				IL_457:
				num2 = 47;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CURSORSIZE")));
				IL_470:
				num2 = 48;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("CVPORT")));
				IL_489:
				num2 = 49;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DATE")));
				IL_4A2:
				num2 = 50;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DBMOD")));
				IL_4BB:
				num2 = 51;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DCTCUST")));
				IL_4D4:
				num2 = 52;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DCTMAIN")));
				IL_4ED:
				num2 = 53;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DEFLPLSTYLE")));
				IL_506:
				num2 = 54;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DEFPLSTYLE")));
				IL_51F:
				num2 = 55;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DELOBJ")));
				IL_538:
				num2 = 56;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DEMANDLOAD")));
				IL_551:
				num2 = 57;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIASTAT")));
				IL_56A:
				num2 = 58;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMADEC")));
				IL_583:
				num2 = 59;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALT")));
				IL_59C:
				num2 = 60;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTD")));
				IL_5B5:
				num2 = 61;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTF")));
				IL_5CE:
				num2 = 62;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTRND")));
				IL_5E7:
				num2 = 63;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTTD")));
				IL_600:
				num2 = 64;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTTZ")));
				IL_619:
				num2 = 65;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTU")));
				IL_632:
				num2 = 66;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMALTZ")));
				IL_64B:
				num2 = 67;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMAPOST")));
				IL_664:
				num2 = 68;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMASO")));
				IL_67D:
				num2 = 69;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMASSOC")));
				IL_696:
				num2 = 70;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMASZ")));
				IL_6AF:
				num2 = 71;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMATFIT")));
				IL_6C8:
				num2 = 72;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMAUNIT")));
				IL_6E1:
				num2 = 73;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMAZIN")));
				IL_6FA:
				num2 = 74;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMBLK")));
				IL_713:
				num2 = 75;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMBLK1")));
				IL_72C:
				num2 = 76;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMBLK2")));
				IL_745:
				num2 = 77;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMCEN")));
				IL_75E:
				num2 = 78;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMCLRD")));
				IL_777:
				num2 = 79;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMCLRE")));
				IL_790:
				num2 = 80;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMCLRT")));
				IL_7A9:
				num2 = 81;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMDEC")));
				IL_7C2:
				num2 = 82;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMDLE")));
				IL_7DB:
				num2 = 83;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMDLI")));
				IL_7F4:
				num2 = 84;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMDSEP")));
				IL_80D:
				num2 = 85;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMEXE")));
				IL_826:
				num2 = 86;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMEXO")));
				IL_83F:
				num2 = 87;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMFIT")));
				IL_858:
				num2 = 88;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMFRAC")));
				IL_871:
				num2 = 89;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMGAP")));
				IL_88A:
				num2 = 90;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMJUST")));
				IL_8A3:
				num2 = 91;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMLDRBLK")));
				IL_8BC:
				num2 = 92;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMLFAC")));
				IL_8D5:
				num2 = 93;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMLIM")));
				IL_8EE:
				num2 = 94;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMLUNIT")));
				IL_907:
				num2 = 95;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMLWD")));
				IL_920:
				num2 = 96;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMLWE")));
				IL_939:
				num2 = 97;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMPOST")));
				IL_952:
				num2 = 98;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMRND")));
				IL_96B:
				num2 = 99;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSAH")));
				IL_984:
				num2 = 100;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSCALE")));
				IL_99D:
				num2 = 101;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSD1")));
				IL_9B6:
				num2 = 102;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSD2")));
				IL_9CF:
				num2 = 103;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSE1")));
				IL_9E8:
				num2 = 104;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSE2")));
				IL_A01:
				num2 = 105;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSHO")));
				IL_A1A:
				num2 = 106;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSOXD")));
				IL_A33:
				num2 = 107;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMSTYLE")));
				IL_A4C:
				num2 = 108;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTAD")));
				IL_A65:
				num2 = 109;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTDEC")));
				IL_A7E:
				num2 = 110;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTFAC")));
				IL_A97:
				num2 = 111;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTIH")));
				IL_AB0:
				num2 = 112;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTIX")));
				IL_AC9:
				num2 = 113;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTM")));
				IL_AE2:
				num2 = 114;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTMOVE")));
				IL_AFB:
				num2 = 115;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTOFL")));
				IL_B14:
				num2 = 116;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTOH")));
				IL_B2D:
				num2 = 117;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTOL")));
				IL_B46:
				num2 = 118;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTOLJ")));
				IL_B5F:
				num2 = 119;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTP")));
				IL_B78:
				num2 = 120;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTSZ")));
				IL_B91:
				num2 = 121;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTVP")));
				IL_BAA:
				num2 = 122;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTXSTY")));
				IL_BC3:
				num2 = 123;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTXT")));
				IL_BDC:
				num2 = 124;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMTZIN")));
				IL_BF5:
				num2 = 125;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMUNIT")));
				IL_C0E:
				num2 = 126;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMUPT")));
				IL_C27:
				num2 = 127;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DIMZIN")));
				IL_C40:
				num2 = 128;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DISPSILH")));
				IL_C5C:
				num2 = 129;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DISTANCE")));
				IL_C78:
				num2 = 130;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DONUTID")));
				IL_C94:
				num2 = 131;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DONUTOD")));
				IL_CB0:
				num2 = 132;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DRAGMODE")));
				IL_CCC:
				num2 = 133;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DRAGP1")));
				IL_CE8:
				num2 = 134;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DRAGP2")));
				IL_D04:
				num2 = 135;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DWGCHECK")));
				IL_D20:
				num2 = 136;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DWGCODEPAGE")));
				IL_D3C:
				num2 = 137;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DWGNAME")));
				IL_D58:
				num2 = 138;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DWGPREFIX")));
				IL_D74:
				num2 = 139;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("DWGTITLED")));
				IL_D90:
				num2 = 140;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("EDGEMODE")));
				IL_DAC:
				num2 = 141;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ELEVATION")));
				IL_DC8:
				num2 = 142;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("EXPERT")));
				IL_DE4:
				num2 = 143;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("EXPLMODE")));
				IL_E00:
				num2 = 144;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("EXTMAX")));
				IL_E1C:
				num2 = 145;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("EXTMIN")));
				IL_E38:
				num2 = 146;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("EXTNAMES")));
				IL_E54:
				num2 = 147;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FACETRATIO")));
				IL_E70:
				num2 = 148;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FACETRES")));
				IL_E8C:
				num2 = 149;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FILEDIA")));
				IL_EA8:
				num2 = 150;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FILLETRAD")));
				IL_EC4:
				num2 = 151;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FILLMODE")));
				IL_EE0:
				num2 = 152;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FONTALT")));
				IL_EFC:
				num2 = 153;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FONTMAP")));
				IL_F18:
				num2 = 154;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FRONTZ")));
				IL_F34:
				num2 = 155;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("FULLOPEN")));
				IL_F50:
				num2 = 156;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIDMODE")));
				IL_F6C:
				num2 = 157;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIDUNIT")));
				IL_F88:
				num2 = 158;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIPBLOCK")));
				IL_FA4:
				num2 = 159;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIPCOLOR")));
				IL_FC0:
				num2 = 160;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIPHOT")));
				IL_FDC:
				num2 = 161;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIPS")));
				IL_FF8:
				num2 = 162;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("GRIPSIZE")));
				IL_1014:
				num2 = 163;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HALOGAP")));
				IL_1030:
				num2 = 164;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HANDLES")));
				IL_104C:
				num2 = 165;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HIDEPRECISION")));
				IL_1068:
				num2 = 166;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HIDETEXT")));
				IL_1084:
				num2 = 167;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HIGHLIGHT")));
				IL_10A0:
				num2 = 168;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HPANG")));
				IL_10BC:
				num2 = 169;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HPBOUND")));
				IL_10D8:
				num2 = 170;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HPDOUBLE")));
				IL_10F4:
				num2 = 171;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HPNAME")));
				IL_1110:
				num2 = 172;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HPSCALE")));
				IL_112C:
				num2 = 173;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HPSPACE")));
				IL_1148:
				num2 = 174;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("HYPERLINKBASE")));
				IL_1164:
				num2 = 175;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("IMAGEHLT")));
				IL_1180:
				num2 = 176;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INDEXCTL")));
				IL_119C:
				num2 = 177;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INETLOCATION")));
				IL_11B8:
				num2 = 178;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INSBASE")));
				IL_11D4:
				num2 = 179;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INSNAME")));
				IL_11F0:
				num2 = 180;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INSUNITS")));
				IL_120C:
				num2 = 181;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INSUNITSDEFSOURCE")));
				IL_1228:
				num2 = 182;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("INSUNITSDEFTARGET")));
				IL_1244:
				num2 = 183;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ISAVEBAK")));
				IL_1260:
				num2 = 184;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ISAVEPERCENT")));
				IL_127C:
				num2 = 185;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ISOLINES")));
				IL_1298:
				num2 = 186;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LASTANGLE")));
				IL_12B4:
				num2 = 187;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LASTPOINT")));
				IL_12D0:
				num2 = 188;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LASTPROMPT")));
				IL_12EC:
				num2 = 189;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LAYOUTREGENCTL")));
				IL_1308:
				num2 = 190;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LENSLENGTH")));
				IL_1324:
				num2 = 191;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LIMCHECK")));
				IL_1340:
				num2 = 192;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LIMMAX")));
				IL_135C:
				num2 = 193;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LIMMIN")));
				IL_1378:
				num2 = 194;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LISPINIT")));
				IL_1394:
				num2 = 195;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LOCALE")));
				IL_13B0:
				num2 = 196;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LOGFILEMODE")));
				IL_13CC:
				num2 = 197;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LOGFILENAME")));
				IL_13E8:
				num2 = 198;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LOGFILEPATH")));
				IL_1404:
				num2 = 199;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LOGINNAME")));
				IL_1420:
				num2 = 200;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LTSCALE")));
				IL_143C:
				num2 = 201;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LUNITS")));
				IL_1458:
				num2 = 202;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LUPREC")));
				IL_1474:
				num2 = 203;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LWDEFAULT")));
				IL_1490:
				num2 = 204;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LWDISPLAY")));
				IL_14AC:
				num2 = 205;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("LWUNITS")));
				IL_14C8:
				num2 = 206;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MAXACTVP")));
				IL_14E4:
				num2 = 207;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MAXSORT")));
				IL_1500:
				num2 = 208;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MBUTTONPAN")));
				IL_151C:
				num2 = 209;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MEASUREINIT")));
				IL_1538:
				num2 = 210;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MEASUREMENT")));
				IL_1554:
				num2 = 211;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MENUCTL")));
				IL_1570:
				num2 = 212;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MENUECHO")));
				IL_158C:
				num2 = 213;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MENUNAME")));
				IL_15A8:
				num2 = 214;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MIRRTEXT")));
				IL_15C4:
				num2 = 215;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MODEMACRO")));
				IL_15E0:
				num2 = 216;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("MTEXTED")));
				IL_15FC:
				num2 = 217;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("NOMUTT")));
				IL_1618:
				num2 = 218;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OBSCUREDCOLOR")));
				IL_1634:
				num2 = 219;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OBSCUREDLTYPE")));
				IL_1650:
				num2 = 220;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OFFSETDIST")));
				IL_166C:
				num2 = 221;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OFFSETGAPTYPE")));
				IL_1688:
				num2 = 222;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OLEHIDE")));
				IL_16A4:
				num2 = 223;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OLEQUALITY")));
				IL_16C0:
				num2 = 224;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OLESTARTUP")));
				IL_16DC:
				num2 = 225;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ORTHOMODE")));
				IL_16F8:
				num2 = 226;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OSMODE")));
				IL_1714:
				num2 = 227;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("OSNAPCOORD")));
				IL_1730:
				num2 = 228;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PAPERUPDATE")));
				IL_174C:
				num2 = 229;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PDMODE")));
				IL_1768:
				num2 = 230;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PDSIZE")));
				IL_1784:
				num2 = 231;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PELLIPSE")));
				IL_17A0:
				num2 = 232;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PERIMETER")));
				IL_17BC:
				num2 = 233;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PFACEVMAX")));
				IL_17D8:
				num2 = 234;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PICKADD")));
				IL_17F4:
				num2 = 235;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PICKAUTO")));
				IL_1810:
				num2 = 236;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PICKBOX")));
				IL_182C:
				num2 = 237;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PICKDRAG")));
				IL_1848:
				num2 = 238;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PICKFIRST")));
				IL_1864:
				num2 = 239;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PICKSTYLE")));
				IL_1880:
				num2 = 240;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLATFORM")));
				IL_189C:
				num2 = 241;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLINEGEN")));
				IL_18B8:
				num2 = 242;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLINETYPE")));
				IL_18D4:
				num2 = 243;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLINEWID")));
				IL_18F0:
				num2 = 244;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLOTID")));
				IL_190C:
				num2 = 245;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLOTROTMODE")));
				IL_1928:
				num2 = 246;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLOTTER")));
				IL_1944:
				num2 = 247;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PLQUIET")));
				IL_1960:
				num2 = 248;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("POLARADDANG")));
				IL_197C:
				num2 = 249;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("POLARANG")));
				IL_1998:
				num2 = 250;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("POLARDIST")));
				IL_19B4:
				num2 = 251;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("POLARMODE")));
				IL_19D0:
				num2 = 252;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("POLYSIDES")));
				IL_19EC:
				num2 = 253;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("POPUPS")));
				IL_1A08:
				num2 = 254;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PRODUCT")));
				IL_1A24:
				num2 = 255;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROGRAM")));
				IL_1A40:
				num2 = 256;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROJECTNAME")));
				IL_1A5C:
				num2 = 257;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROJMODE")));
				IL_1A78:
				num2 = 258;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROXYGRAPHICS")));
				IL_1A94:
				num2 = 259;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROXYNOTICE")));
				IL_1AB0:
				num2 = 260;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROXYSHOW")));
				IL_1ACC:
				num2 = 261;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PROXYWEBSEARCH")));
				IL_1AE8:
				num2 = 262;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PSLTSCALE")));
				IL_1B04:
				num2 = 263;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PSPROLOG")));
				IL_1B20:
				num2 = 264;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PSQUALITY")));
				IL_1B3C:
				num2 = 265;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PSTYLEMODE")));
				IL_1B58:
				num2 = 266;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PSTYLEPOLICY")));
				IL_1B74:
				num2 = 267;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PSVPSCALE")));
				IL_1B90:
				num2 = 268;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("PUCSBASE")));
				IL_1BAC:
				num2 = 269;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("QTEXTMODE")));
				IL_1BC8:
				num2 = 270;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("RASTERPREVIEW")));
				IL_1BE4:
				num2 = 271;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("REFEDITNAME")));
				IL_1C00:
				num2 = 272;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("REGENMODE")));
				IL_1C1C:
				num2 = 273;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("RE-INIT")));
				IL_1C38:
				num2 = 274;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("REMEMBERFOLDERS")));
				IL_1C54:
				num2 = 275;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("RTDISPLAY")));
				IL_1C70:
				num2 = 276;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SAVEFILE")));
				IL_1C8C:
				num2 = 277;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SAVEFILEPATH")));
				IL_1CA8:
				num2 = 278;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SAVENAME")));
				IL_1CC4:
				num2 = 279;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SAVETIME")));
				IL_1CE0:
				num2 = 280;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SCREENBOXES")));
				IL_1CFC:
				num2 = 281;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SCREENMODE")));
				IL_1D18:
				num2 = 282;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SCREENSIZE")));
				IL_1D34:
				num2 = 283;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SDI")));
				IL_1D50:
				num2 = 284;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SHADEDGE")));
				IL_1D6C:
				num2 = 285;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SHADEDIF")));
				IL_1D88:
				num2 = 286;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SHORTCUTMENU")));
				IL_1DA4:
				num2 = 287;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SHPNAME")));
				IL_1DC0:
				num2 = 288;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SKETCHINC")));
				IL_1DDC:
				num2 = 289;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SKPOLY")));
				IL_1DF8:
				num2 = 290;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPANG")));
				IL_1E14:
				num2 = 291;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPBASE")));
				IL_1E30:
				num2 = 292;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPISOPAIR")));
				IL_1E4C:
				num2 = 293;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPMODE")));
				IL_1E68:
				num2 = 294;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPSTYL")));
				IL_1E84:
				num2 = 295;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPTYPE")));
				IL_1EA0:
				num2 = 296;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SNAPUNIT")));
				IL_1EBC:
				num2 = 297;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SOLIDCHECK")));
				IL_1ED8:
				num2 = 298;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SORTENTS")));
				IL_1EF4:
				num2 = 299;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SPLFRAME")));
				IL_1F10:
				num2 = 300;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SPLINESEGS")));
				IL_1F2C:
				num2 = 301;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SPLINETYPE")));
				IL_1F48:
				num2 = 302;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("STARTUPTODAY")));
				IL_1F64:
				num2 = 303;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SURFTAB1")));
				IL_1F80:
				num2 = 304;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SURFTAB2")));
				IL_1F9C:
				num2 = 305;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SURFTYPE")));
				IL_1FB8:
				num2 = 306;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SURFU")));
				IL_1FD4:
				num2 = 307;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SURFV")));
				IL_1FF0:
				num2 = 308;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("SYSCODEPAGE")));
				IL_200C:
				num2 = 309;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TABMODE")));
				IL_2028:
				num2 = 310;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TARGET")));
				IL_2044:
				num2 = 311;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TDCREATE")));
				IL_2060:
				num2 = 312;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TDINDWG")));
				IL_207C:
				num2 = 313;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TDUCREATE")));
				IL_2098:
				num2 = 314;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TDUPDATE")));
				IL_20B4:
				num2 = 315;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TDUSRTIMER")));
				IL_20D0:
				num2 = 316;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TDUUPDATE")));
				IL_20EC:
				num2 = 317;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TEMPPREFIX")));
				IL_2108:
				num2 = 318;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TEXTEVAL")));
				IL_2124:
				num2 = 319;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TEXTFILL")));
				IL_2140:
				num2 = 320;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TEXTQLTY")));
				IL_215C:
				num2 = 321;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TEXTSIZE")));
				IL_2178:
				num2 = 322;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TEXTSTYLE")));
				IL_2194:
				num2 = 323;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("THICKNESS")));
				IL_21B0:
				num2 = 324;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TILEMODE")));
				IL_21CC:
				num2 = 325;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TOOLTIPS")));
				IL_21E8:
				num2 = 326;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TRACEWID")));
				IL_2204:
				num2 = 327;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TRACKPATH")));
				IL_2220:
				num2 = 328;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TREEDEPTH")));
				IL_223C:
				num2 = 329;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TREEMAX")));
				IL_2258:
				num2 = 330;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TRIMMODE")));
				IL_2274:
				num2 = 331;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TSPACEFAC")));
				IL_2290:
				num2 = 332;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TSPACETYPE")));
				IL_22AC:
				num2 = 333;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TSTACKALIGN")));
				IL_22C8:
				num2 = 334;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("TSTACKSIZE")));
				IL_22E4:
				num2 = 335;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSAXISANG")));
				IL_2300:
				num2 = 336;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSBASE")));
				IL_231C:
				num2 = 337;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSFOLLOW")));
				IL_2338:
				num2 = 338;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSICON")));
				IL_2354:
				num2 = 339;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSNAME")));
				IL_2370:
				num2 = 340;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSORG")));
				IL_238C:
				num2 = 341;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSORTHO")));
				IL_23A8:
				num2 = 342;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSVIEW")));
				IL_23C4:
				num2 = 343;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSVP")));
				IL_23E0:
				num2 = 344;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSXDIR")));
				IL_23FC:
				num2 = 345;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UCSYDIR")));
				IL_2418:
				num2 = 346;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UNDOCTL")));
				IL_2434:
				num2 = 347;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UNDOMARKS")));
				IL_2450:
				num2 = 348;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("UNITMODE")));
				IL_246C:
				num2 = 349;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("USERI1~USERI5")));
				IL_2488:
				num2 = 350;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("USERR1~USERR5")));
				IL_24A4:
				num2 = 351;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("USERS1~USERS5")));
				IL_24C0:
				num2 = 352;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VIEWCTR")));
				IL_24DC:
				num2 = 353;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VIEWDIR")));
				IL_24F8:
				num2 = 354;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VIEWMODE")));
				IL_2514:
				num2 = 355;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VIEWSIZE")));
				IL_2530:
				num2 = 356;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VIEWTWIST")));
				IL_254C:
				num2 = 357;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VISRETAIN")));
				IL_2568:
				num2 = 358;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VSMAX")));
				IL_2584:
				num2 = 359;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("VSMIN")));
				IL_25A0:
				num2 = 360;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WHIPARC")));
				IL_25BC:
				num2 = 361;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WHIPTHREAD")));
				IL_25D8:
				num2 = 362;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WMFBKGND")));
				IL_25F4:
				num2 = 363;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WMFFOREGND")));
				IL_2610:
				num2 = 364;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WORLDUCS")));
				IL_262C:
				num2 = 365;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WORLDVIEW")));
				IL_2648:
				num2 = 366;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("WRITESTAT")));
				IL_2664:
				num2 = 367;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("XCLIPFRAME")));
				IL_2680:
				num2 = 368;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("XEDIT")));
				IL_269C:
				num2 = 369;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("XFADECTL")));
				IL_26B8:
				num2 = 370;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("XLOADCTL")));
				IL_26D4:
				num2 = 371;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("XLOADPATH")));
				IL_26F0:
				num2 = 372;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("XREFCTL")));
				IL_270C:
				num2 = 373;
				arrayList.Add(RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("ZOOMFACTOR")));
				IL_2728:
				num2 = 374;
				ArrayList arrayList2 = new ArrayList();
				IL_2734:
				num2 = 375;
				arrayList2.Add("ACADLSPASDOC");
				IL_2746:
				num2 = 376;
				arrayList2.Add("ACADPREFIX");
				IL_2758:
				num2 = 377;
				arrayList2.Add("ACADVER");
				IL_276A:
				num2 = 378;
				arrayList2.Add("ACISOUTVER");
				IL_277C:
				num2 = 379;
				arrayList2.Add("AFLAGS");
				IL_278E:
				num2 = 380;
				arrayList2.Add("ANGBASE");
				IL_27A0:
				num2 = 381;
				arrayList2.Add("ANGDIR");
				IL_27B2:
				num2 = 382;
				arrayList2.Add("APBOX");
				IL_27C4:
				num2 = 383;
				arrayList2.Add("APERTURE");
				IL_27D6:
				num2 = 384;
				arrayList2.Add("AREA");
				IL_27E8:
				num2 = 385;
				arrayList2.Add("ATTDIA");
				IL_27FA:
				num2 = 386;
				arrayList2.Add("ATTMODE");
				IL_280C:
				num2 = 387;
				arrayList2.Add("ATTREQ");
				IL_281E:
				num2 = 388;
				arrayList2.Add("AUDITCTL");
				IL_2830:
				num2 = 389;
				arrayList2.Add("AUNITS");
				IL_2842:
				num2 = 390;
				arrayList2.Add("AUPREC");
				IL_2854:
				num2 = 391;
				arrayList2.Add("AUTOSNAP");
				IL_2866:
				num2 = 392;
				arrayList2.Add("BACKZ");
				IL_2878:
				num2 = 393;
				arrayList2.Add("BINDTYPE");
				IL_288A:
				num2 = 394;
				arrayList2.Add("BLIPMODE");
				IL_289C:
				num2 = 395;
				arrayList2.Add("CDATE");
				IL_28AE:
				num2 = 396;
				arrayList2.Add("CECOLOR");
				IL_28C0:
				num2 = 397;
				arrayList2.Add("CELTSCALE");
				IL_28D2:
				num2 = 398;
				arrayList2.Add("CELTYPE");
				IL_28E4:
				num2 = 399;
				arrayList2.Add("CELWEIGHT");
				IL_28F6:
				num2 = 400;
				arrayList2.Add("CHAMFERA");
				IL_2908:
				num2 = 401;
				arrayList2.Add("CHAMFERB");
				IL_291A:
				num2 = 402;
				arrayList2.Add("CHAMFERC");
				IL_292C:
				num2 = 403;
				arrayList2.Add("CHAMFERD");
				IL_293E:
				num2 = 404;
				arrayList2.Add("CHAMMODE");
				IL_2950:
				num2 = 405;
				arrayList2.Add("CIRCLERAD");
				IL_2962:
				num2 = 406;
				arrayList2.Add("CLAYER");
				IL_2974:
				num2 = 407;
				arrayList2.Add("CMDACTIVE");
				IL_2986:
				num2 = 408;
				arrayList2.Add("CMDDIA");
				IL_2998:
				num2 = 409;
				arrayList2.Add("CMDECHO");
				IL_29AA:
				num2 = 410;
				arrayList2.Add("CMDNAMES");
				IL_29BC:
				num2 = 411;
				arrayList2.Add("CMLJUST");
				IL_29CE:
				num2 = 412;
				arrayList2.Add("CMLSCALE");
				IL_29E0:
				num2 = 413;
				arrayList2.Add("CMLSTYLE");
				IL_29F2:
				num2 = 414;
				arrayList2.Add("COMPASS");
				IL_2A04:
				num2 = 415;
				arrayList2.Add("COORDS");
				IL_2A16:
				num2 = 416;
				arrayList2.Add("CPLOTSTYLE");
				IL_2A28:
				num2 = 417;
				arrayList2.Add("CPROFILE");
				IL_2A3A:
				num2 = 418;
				arrayList2.Add("CTAB");
				IL_2A4C:
				num2 = 419;
				arrayList2.Add("CURSORSIZE");
				IL_2A5E:
				num2 = 420;
				arrayList2.Add("CVPORT");
				IL_2A70:
				num2 = 421;
				arrayList2.Add("DATE");
				IL_2A82:
				num2 = 422;
				arrayList2.Add("DBMOD");
				IL_2A94:
				num2 = 423;
				arrayList2.Add("DCTCUST");
				IL_2AA6:
				num2 = 424;
				arrayList2.Add("DCTMAIN");
				IL_2AB8:
				num2 = 425;
				arrayList2.Add("DEFLPLSTYLE");
				IL_2ACA:
				num2 = 426;
				arrayList2.Add("DEFPLSTYLE");
				IL_2ADC:
				num2 = 427;
				arrayList2.Add("DELOBJ");
				IL_2AEE:
				num2 = 428;
				arrayList2.Add("DEMANDLOAD");
				IL_2B00:
				num2 = 429;
				arrayList2.Add("DIASTAT");
				IL_2B12:
				num2 = 430;
				arrayList2.Add("DIMADEC");
				IL_2B24:
				num2 = 431;
				arrayList2.Add("DIMALT");
				IL_2B36:
				num2 = 432;
				arrayList2.Add("DIMALTD");
				IL_2B48:
				num2 = 433;
				arrayList2.Add("DIMALTF");
				IL_2B5A:
				num2 = 434;
				arrayList2.Add("DIMALTRND");
				IL_2B6C:
				num2 = 435;
				arrayList2.Add("DIMALTTD");
				IL_2B7E:
				num2 = 436;
				arrayList2.Add("DIMALTTZ");
				IL_2B90:
				num2 = 437;
				arrayList2.Add("DIMALTU");
				IL_2BA2:
				num2 = 438;
				arrayList2.Add("DIMALTZ");
				IL_2BB4:
				num2 = 439;
				arrayList2.Add("DIMAPOST");
				IL_2BC6:
				num2 = 440;
				arrayList2.Add("DIMASO");
				IL_2BD8:
				num2 = 441;
				arrayList2.Add("DIMASSOC");
				IL_2BEA:
				num2 = 442;
				arrayList2.Add("DIMASZ");
				IL_2BFC:
				num2 = 443;
				arrayList2.Add("DIMATFIT");
				IL_2C0E:
				num2 = 444;
				arrayList2.Add("DIMAUNIT");
				IL_2C20:
				num2 = 445;
				arrayList2.Add("DIMAZIN");
				IL_2C32:
				num2 = 446;
				arrayList2.Add("DIMBLK");
				IL_2C44:
				num2 = 447;
				arrayList2.Add("DIMBLK1");
				IL_2C56:
				num2 = 448;
				arrayList2.Add("DIMBLK2");
				IL_2C68:
				num2 = 449;
				arrayList2.Add("DIMCEN");
				IL_2C7A:
				num2 = 450;
				arrayList2.Add("DIMCLRD");
				IL_2C8C:
				num2 = 451;
				arrayList2.Add("DIMCLRE");
				IL_2C9E:
				num2 = 452;
				arrayList2.Add("DIMCLRT");
				IL_2CB0:
				num2 = 453;
				arrayList2.Add("DIMDEC");
				IL_2CC2:
				num2 = 454;
				arrayList2.Add("DIMDLE");
				IL_2CD4:
				num2 = 455;
				arrayList2.Add("DIMDLI");
				IL_2CE6:
				num2 = 456;
				arrayList2.Add("DIMDSEP");
				IL_2CF8:
				num2 = 457;
				arrayList2.Add("DIMEXE");
				IL_2D0A:
				num2 = 458;
				arrayList2.Add("DIMEXO");
				IL_2D1C:
				num2 = 459;
				arrayList2.Add("DIMFIT");
				IL_2D2E:
				num2 = 460;
				arrayList2.Add("DIMFRAC");
				IL_2D40:
				num2 = 461;
				arrayList2.Add("DIMGAP");
				IL_2D52:
				num2 = 462;
				arrayList2.Add("DIMJUST");
				IL_2D64:
				num2 = 463;
				arrayList2.Add("DIMLDRBLK");
				IL_2D76:
				num2 = 464;
				arrayList2.Add("DIMLFAC");
				IL_2D88:
				num2 = 465;
				arrayList2.Add("DIMLIM");
				IL_2D9A:
				num2 = 466;
				arrayList2.Add("DIMLUNIT");
				IL_2DAC:
				num2 = 467;
				arrayList2.Add("DIMLWD");
				IL_2DBE:
				num2 = 468;
				arrayList2.Add("DIMLWE");
				IL_2DD0:
				num2 = 469;
				arrayList2.Add("DIMPOST");
				IL_2DE2:
				num2 = 470;
				arrayList2.Add("DIMRND");
				IL_2DF4:
				num2 = 471;
				arrayList2.Add("DIMSAH");
				IL_2E06:
				num2 = 472;
				arrayList2.Add("DIMSCALE");
				IL_2E18:
				num2 = 473;
				arrayList2.Add("DIMSD1");
				IL_2E2A:
				num2 = 474;
				arrayList2.Add("DIMSD2");
				IL_2E3C:
				num2 = 475;
				arrayList2.Add("DIMSE1");
				IL_2E4E:
				num2 = 476;
				arrayList2.Add("DIMSE2");
				IL_2E60:
				num2 = 477;
				arrayList2.Add("DIMSHO");
				IL_2E72:
				num2 = 478;
				arrayList2.Add("DIMSOXD");
				IL_2E84:
				num2 = 479;
				arrayList2.Add("DIMSTYLE");
				IL_2E96:
				num2 = 480;
				arrayList2.Add("DIMTAD");
				IL_2EA8:
				num2 = 481;
				arrayList2.Add("DIMTDEC");
				IL_2EBA:
				num2 = 482;
				arrayList2.Add("DIMTFAC");
				IL_2ECC:
				num2 = 483;
				arrayList2.Add("DIMTIH");
				IL_2EDE:
				num2 = 484;
				arrayList2.Add("DIMTIX");
				IL_2EF0:
				num2 = 485;
				arrayList2.Add("DIMTM");
				IL_2F02:
				num2 = 486;
				arrayList2.Add("DIMTMOVE");
				IL_2F14:
				num2 = 487;
				arrayList2.Add("DIMTOFL");
				IL_2F26:
				num2 = 488;
				arrayList2.Add("DIMTOH");
				IL_2F38:
				num2 = 489;
				arrayList2.Add("DIMTOL");
				IL_2F4A:
				num2 = 490;
				arrayList2.Add("DIMTOLJ");
				IL_2F5C:
				num2 = 491;
				arrayList2.Add("DIMTP");
				IL_2F6E:
				num2 = 492;
				arrayList2.Add("DIMTSZ");
				IL_2F80:
				num2 = 493;
				arrayList2.Add("DIMTVP");
				IL_2F92:
				num2 = 494;
				arrayList2.Add("DIMTXSTY");
				IL_2FA4:
				num2 = 495;
				arrayList2.Add("DIMTXT");
				IL_2FB6:
				num2 = 496;
				arrayList2.Add("DIMTZIN");
				IL_2FC8:
				num2 = 497;
				arrayList2.Add("DIMUNIT");
				IL_2FDA:
				num2 = 498;
				arrayList2.Add("DIMUPT");
				IL_2FEC:
				num2 = 499;
				arrayList2.Add("DIMZIN");
				IL_2FFE:
				num2 = 500;
				arrayList2.Add("DISPSILH");
				IL_3010:
				num2 = 501;
				arrayList2.Add("DISTANCE");
				IL_3022:
				num2 = 502;
				arrayList2.Add("DONUTID");
				IL_3034:
				num2 = 503;
				arrayList2.Add("DONUTOD");
				IL_3046:
				num2 = 504;
				arrayList2.Add("DRAGMODE");
				IL_3058:
				num2 = 505;
				arrayList2.Add("DRAGP1");
				IL_306A:
				num2 = 506;
				arrayList2.Add("DRAGP2");
				IL_307C:
				num2 = 507;
				arrayList2.Add("DWGCHECK");
				IL_308E:
				num2 = 508;
				arrayList2.Add("DWGCODEPAGE");
				IL_30A0:
				num2 = 509;
				arrayList2.Add("DWGNAME");
				IL_30B2:
				num2 = 510;
				arrayList2.Add("DWGPREFIX");
				IL_30C4:
				num2 = 511;
				arrayList2.Add("DWGTITLED");
				IL_30D6:
				num2 = 512;
				arrayList2.Add("EDGEMODE");
				IL_30E8:
				num2 = 513;
				arrayList2.Add("ELEVATION");
				IL_30FA:
				num2 = 514;
				arrayList2.Add("EXPERT");
				IL_310C:
				num2 = 515;
				arrayList2.Add("EXPLMODE");
				IL_311E:
				num2 = 516;
				arrayList2.Add("EXTMAX");
				IL_3130:
				num2 = 517;
				arrayList2.Add("EXTMIN");
				IL_3142:
				num2 = 518;
				arrayList2.Add("EXTNAMES");
				IL_3154:
				num2 = 519;
				arrayList2.Add("FACETRATIO");
				IL_3166:
				num2 = 520;
				arrayList2.Add("FACETRES");
				IL_3178:
				num2 = 521;
				arrayList2.Add("FILEDIA");
				IL_318A:
				num2 = 522;
				arrayList2.Add("FILLETRAD");
				IL_319C:
				num2 = 523;
				arrayList2.Add("FILLMODE");
				IL_31AE:
				num2 = 524;
				arrayList2.Add("FONTALT");
				IL_31C0:
				num2 = 525;
				arrayList2.Add("FONTMAP");
				IL_31D2:
				num2 = 526;
				arrayList2.Add("FRONTZ");
				IL_31E4:
				num2 = 527;
				arrayList2.Add("FULLOPEN");
				IL_31F6:
				num2 = 528;
				arrayList2.Add("GRIDMODE");
				IL_3208:
				num2 = 529;
				arrayList2.Add("GRIDUNIT");
				IL_321A:
				num2 = 530;
				arrayList2.Add("GRIPBLOCK");
				IL_322C:
				num2 = 531;
				arrayList2.Add("GRIPCOLOR");
				IL_323E:
				num2 = 532;
				arrayList2.Add("GRIPHOT");
				IL_3250:
				num2 = 533;
				arrayList2.Add("GRIPS");
				IL_3262:
				num2 = 534;
				arrayList2.Add("GRIPSIZE");
				IL_3274:
				num2 = 535;
				arrayList2.Add("HALOGAP");
				IL_3286:
				num2 = 536;
				arrayList2.Add("HANDLES");
				IL_3298:
				num2 = 537;
				arrayList2.Add("HIDEPRECISION");
				IL_32AA:
				num2 = 538;
				arrayList2.Add("HIDETEXT");
				IL_32BC:
				num2 = 539;
				arrayList2.Add("HIGHLIGHT");
				IL_32CE:
				num2 = 540;
				arrayList2.Add("HPANG");
				IL_32E0:
				num2 = 541;
				arrayList2.Add("HPBOUND");
				IL_32F2:
				num2 = 542;
				arrayList2.Add("HPDOUBLE");
				IL_3304:
				num2 = 543;
				arrayList2.Add("HPNAME");
				IL_3316:
				num2 = 544;
				arrayList2.Add("HPSCALE");
				IL_3328:
				num2 = 545;
				arrayList2.Add("HPSPACE");
				IL_333A:
				num2 = 546;
				arrayList2.Add("HYPERLINKBASE");
				IL_334C:
				num2 = 547;
				arrayList2.Add("IMAGEHLT");
				IL_335E:
				num2 = 548;
				arrayList2.Add("INDEXCTL");
				IL_3370:
				num2 = 549;
				arrayList2.Add("INETLOCATION");
				IL_3382:
				num2 = 550;
				arrayList2.Add("INSBASE");
				IL_3394:
				num2 = 551;
				arrayList2.Add("INSNAME");
				IL_33A6:
				num2 = 552;
				arrayList2.Add("INSUNITS");
				IL_33B8:
				num2 = 553;
				arrayList2.Add("INSUNITSDEFSOURCE");
				IL_33CA:
				num2 = 554;
				arrayList2.Add("INSUNITSDEFTARGET");
				IL_33DC:
				num2 = 555;
				arrayList2.Add("ISAVEBAK");
				IL_33EE:
				num2 = 556;
				arrayList2.Add("ISAVEPERCENT");
				IL_3400:
				num2 = 557;
				arrayList2.Add("ISOLINES");
				IL_3412:
				num2 = 558;
				arrayList2.Add("LASTANGLE");
				IL_3424:
				num2 = 559;
				arrayList2.Add("LASTPOINT");
				IL_3436:
				num2 = 560;
				arrayList2.Add("LASTPROMPT");
				IL_3448:
				num2 = 561;
				arrayList2.Add("LAYOUTREGENCTL");
				IL_345A:
				num2 = 562;
				arrayList2.Add("LENSLENGTH");
				IL_346C:
				num2 = 563;
				arrayList2.Add("LIMCHECK");
				IL_347E:
				num2 = 564;
				arrayList2.Add("LIMMAX");
				IL_3490:
				num2 = 565;
				arrayList2.Add("LIMMIN");
				IL_34A2:
				num2 = 566;
				arrayList2.Add("LISPINIT");
				IL_34B4:
				num2 = 567;
				arrayList2.Add("LOCALE");
				IL_34C6:
				num2 = 568;
				arrayList2.Add("LOGFILEMODE");
				IL_34D8:
				num2 = 569;
				arrayList2.Add("LOGFILENAME");
				IL_34EA:
				num2 = 570;
				arrayList2.Add("LOGFILEPATH");
				IL_34FC:
				num2 = 571;
				arrayList2.Add("LOGINNAME");
				IL_350E:
				num2 = 572;
				arrayList2.Add("LTSCALE");
				IL_3520:
				num2 = 573;
				arrayList2.Add("LUNITS");
				IL_3532:
				num2 = 574;
				arrayList2.Add("LUPREC");
				IL_3544:
				num2 = 575;
				arrayList2.Add("LWDEFAULT");
				IL_3556:
				num2 = 576;
				arrayList2.Add("LWDISPLAY");
				IL_3568:
				num2 = 577;
				arrayList2.Add("LWUNITS");
				IL_357A:
				num2 = 578;
				arrayList2.Add("MAXACTVP");
				IL_358C:
				num2 = 579;
				arrayList2.Add("MAXSORT");
				IL_359E:
				num2 = 580;
				arrayList2.Add("MBUTTONPAN");
				IL_35B0:
				num2 = 581;
				arrayList2.Add("MEASUREINIT");
				IL_35C2:
				num2 = 582;
				arrayList2.Add("MEASUREMENT");
				IL_35D4:
				num2 = 583;
				arrayList2.Add("MENUCTL");
				IL_35E6:
				num2 = 584;
				arrayList2.Add("MENUECHO");
				IL_35F8:
				num2 = 585;
				arrayList2.Add("MENUNAME");
				IL_360A:
				num2 = 586;
				arrayList2.Add("MIRRTEXT");
				IL_361C:
				num2 = 587;
				arrayList2.Add("MODEMACRO");
				IL_362E:
				num2 = 588;
				arrayList2.Add("MTEXTED");
				IL_3640:
				num2 = 589;
				arrayList2.Add("NOMUTT");
				IL_3652:
				num2 = 590;
				arrayList2.Add("OBSCUREDCOLOR");
				IL_3664:
				num2 = 591;
				arrayList2.Add("OBSCUREDLTYPE");
				IL_3676:
				num2 = 592;
				arrayList2.Add("OFFSETDIST");
				IL_3688:
				num2 = 593;
				arrayList2.Add("OFFSETGAPTYPE");
				IL_369A:
				num2 = 594;
				arrayList2.Add("OLEHIDE");
				IL_36AC:
				num2 = 595;
				arrayList2.Add("OLEQUALITY");
				IL_36BE:
				num2 = 596;
				arrayList2.Add("OLESTARTUP");
				IL_36D0:
				num2 = 597;
				arrayList2.Add("ORTHOMODE");
				IL_36E2:
				num2 = 598;
				arrayList2.Add("OSMODE");
				IL_36F4:
				num2 = 599;
				arrayList2.Add("OSNAPCOORD");
				IL_3706:
				num2 = 600;
				arrayList2.Add("PAPERUPDATE");
				IL_3718:
				num2 = 601;
				arrayList2.Add("PDMODE");
				IL_372A:
				num2 = 602;
				arrayList2.Add("PDSIZE");
				IL_373C:
				num2 = 603;
				arrayList2.Add("PELLIPSE");
				IL_374E:
				num2 = 604;
				arrayList2.Add("PERIMETER");
				IL_3760:
				num2 = 605;
				arrayList2.Add("PFACEVMAX");
				IL_3772:
				num2 = 606;
				arrayList2.Add("PICKADD");
				IL_3784:
				num2 = 607;
				arrayList2.Add("PICKAUTO");
				IL_3796:
				num2 = 608;
				arrayList2.Add("PICKBOX");
				IL_37A8:
				num2 = 609;
				arrayList2.Add("PICKDRAG");
				IL_37BA:
				num2 = 610;
				arrayList2.Add("PICKFIRST");
				IL_37CC:
				num2 = 611;
				arrayList2.Add("PICKSTYLE");
				IL_37DE:
				num2 = 612;
				arrayList2.Add("PLATFORM");
				IL_37F0:
				num2 = 613;
				arrayList2.Add("PLINEGEN");
				IL_3802:
				num2 = 614;
				arrayList2.Add("PLINETYPE");
				IL_3814:
				num2 = 615;
				arrayList2.Add("PLINEWID");
				IL_3826:
				num2 = 616;
				arrayList2.Add("PLOTID");
				IL_3838:
				num2 = 617;
				arrayList2.Add("PLOTROTMODE");
				IL_384A:
				num2 = 618;
				arrayList2.Add("PLOTTER");
				IL_385C:
				num2 = 619;
				arrayList2.Add("PLQUIET");
				IL_386E:
				num2 = 620;
				arrayList2.Add("POLARADDANG");
				IL_3880:
				num2 = 621;
				arrayList2.Add("POLARANG");
				IL_3892:
				num2 = 622;
				arrayList2.Add("POLARDIST");
				IL_38A4:
				num2 = 623;
				arrayList2.Add("POLARMODE");
				IL_38B6:
				num2 = 624;
				arrayList2.Add("POLYSIDES");
				IL_38C8:
				num2 = 625;
				arrayList2.Add("POPUPS");
				IL_38DA:
				num2 = 626;
				arrayList2.Add("PRODUCT");
				IL_38EC:
				num2 = 627;
				arrayList2.Add("PROGRAM");
				IL_38FE:
				num2 = 628;
				arrayList2.Add("PROJECTNAME");
				IL_3910:
				num2 = 629;
				arrayList2.Add("PROJMODE");
				IL_3922:
				num2 = 630;
				arrayList2.Add("PROXYGRAPHICS");
				IL_3934:
				num2 = 631;
				arrayList2.Add("PROXYNOTICE");
				IL_3946:
				num2 = 632;
				arrayList2.Add("PROXYSHOW");
				IL_3958:
				num2 = 633;
				arrayList2.Add("PROXYWEBSEARCH");
				IL_396A:
				num2 = 634;
				arrayList2.Add("PSLTSCALE");
				IL_397C:
				num2 = 635;
				arrayList2.Add("PSPROLOG");
				IL_398E:
				num2 = 636;
				arrayList2.Add("PSQUALITY");
				IL_39A0:
				num2 = 637;
				arrayList2.Add("PSTYLEMODE");
				IL_39B2:
				num2 = 638;
				arrayList2.Add("PSTYLEPOLICY");
				IL_39C4:
				num2 = 639;
				arrayList2.Add("PSVPSCALE");
				IL_39D6:
				num2 = 640;
				arrayList2.Add("PUCSBASE");
				IL_39E8:
				num2 = 641;
				arrayList2.Add("QTEXTMODE");
				IL_39FA:
				num2 = 642;
				arrayList2.Add("RASTERPREVIEW");
				IL_3A0C:
				num2 = 643;
				arrayList2.Add("REFEDITNAME");
				IL_3A1E:
				num2 = 644;
				arrayList2.Add("REGENMODE");
				IL_3A30:
				num2 = 645;
				arrayList2.Add("RE-INIT");
				IL_3A42:
				num2 = 646;
				arrayList2.Add("REMEMBERFOLDERS");
				IL_3A54:
				num2 = 647;
				arrayList2.Add("RTDISPLAY");
				IL_3A66:
				num2 = 648;
				arrayList2.Add("SAVEFILE");
				IL_3A78:
				num2 = 649;
				arrayList2.Add("SAVEFILEPATH");
				IL_3A8A:
				num2 = 650;
				arrayList2.Add("SAVENAME");
				IL_3A9C:
				num2 = 651;
				arrayList2.Add("SAVETIME");
				IL_3AAE:
				num2 = 652;
				arrayList2.Add("SCREENBOXES");
				IL_3AC0:
				num2 = 653;
				arrayList2.Add("SCREENMODE");
				IL_3AD2:
				num2 = 654;
				arrayList2.Add("SCREENSIZE");
				IL_3AE4:
				num2 = 655;
				arrayList2.Add("SDI");
				IL_3AF6:
				num2 = 656;
				arrayList2.Add("SHADEDGE");
				IL_3B08:
				num2 = 657;
				arrayList2.Add("SHADEDIF");
				IL_3B1A:
				num2 = 658;
				arrayList2.Add("SHORTCUTMENU");
				IL_3B2C:
				num2 = 659;
				arrayList2.Add("SHPNAME");
				IL_3B3E:
				num2 = 660;
				arrayList2.Add("SKETCHINC");
				IL_3B50:
				num2 = 661;
				arrayList2.Add("SKPOLY");
				IL_3B62:
				num2 = 662;
				arrayList2.Add("SNAPANG");
				IL_3B74:
				num2 = 663;
				arrayList2.Add("SNAPBASE");
				IL_3B86:
				num2 = 664;
				arrayList2.Add("SNAPISOPAIR");
				IL_3B98:
				num2 = 665;
				arrayList2.Add("SNAPMODE");
				IL_3BAA:
				num2 = 666;
				arrayList2.Add("SNAPSTYL");
				IL_3BBC:
				num2 = 667;
				arrayList2.Add("SNAPTYPE");
				IL_3BCE:
				num2 = 668;
				arrayList2.Add("SNAPUNIT");
				IL_3BE0:
				num2 = 669;
				arrayList2.Add("SOLIDCHECK");
				IL_3BF2:
				num2 = 670;
				arrayList2.Add("SORTENTS");
				IL_3C04:
				num2 = 671;
				arrayList2.Add("SPLFRAME");
				IL_3C16:
				num2 = 672;
				arrayList2.Add("SPLINESEGS");
				IL_3C28:
				num2 = 673;
				arrayList2.Add("SPLINETYPE");
				IL_3C3A:
				num2 = 674;
				arrayList2.Add("STARTUPTODAY");
				IL_3C4C:
				num2 = 675;
				arrayList2.Add("SURFTAB1");
				IL_3C5E:
				num2 = 676;
				arrayList2.Add("SURFTAB2");
				IL_3C70:
				num2 = 677;
				arrayList2.Add("SURFTYPE");
				IL_3C82:
				num2 = 678;
				arrayList2.Add("SURFU");
				IL_3C94:
				num2 = 679;
				arrayList2.Add("SURFV");
				IL_3CA6:
				num2 = 680;
				arrayList2.Add("SYSCODEPAGE");
				IL_3CB8:
				num2 = 681;
				arrayList2.Add("TABMODE");
				IL_3CCA:
				num2 = 682;
				arrayList2.Add("TARGET");
				IL_3CDC:
				num2 = 683;
				arrayList2.Add("TDCREATE");
				IL_3CEE:
				num2 = 684;
				arrayList2.Add("TDINDWG");
				IL_3D00:
				num2 = 685;
				arrayList2.Add("TDUCREATE");
				IL_3D12:
				num2 = 686;
				arrayList2.Add("TDUPDATE");
				IL_3D24:
				num2 = 687;
				arrayList2.Add("TDUSRTIMER");
				IL_3D36:
				num2 = 688;
				arrayList2.Add("TDUUPDATE");
				IL_3D48:
				num2 = 689;
				arrayList2.Add("TEMPPREFIX");
				IL_3D5A:
				num2 = 690;
				arrayList2.Add("TEXTEVAL");
				IL_3D6C:
				num2 = 691;
				arrayList2.Add("TEXTFILL");
				IL_3D7E:
				num2 = 692;
				arrayList2.Add("TEXTQLTY");
				IL_3D90:
				num2 = 693;
				arrayList2.Add("TEXTSIZE");
				IL_3DA2:
				num2 = 694;
				arrayList2.Add("TEXTSTYLE");
				IL_3DB4:
				num2 = 695;
				arrayList2.Add("THICKNESS");
				IL_3DC6:
				num2 = 696;
				arrayList2.Add("TILEMODE");
				IL_3DD8:
				num2 = 697;
				arrayList2.Add("TOOLTIPS");
				IL_3DEA:
				num2 = 698;
				arrayList2.Add("TRACEWID");
				IL_3DFC:
				num2 = 699;
				arrayList2.Add("TRACKPATH");
				IL_3E0E:
				num2 = 700;
				arrayList2.Add("TREEDEPTH");
				IL_3E20:
				num2 = 701;
				arrayList2.Add("TREEMAX");
				IL_3E32:
				num2 = 702;
				arrayList2.Add("TRIMMODE");
				IL_3E44:
				num2 = 703;
				arrayList2.Add("TSPACEFAC");
				IL_3E56:
				num2 = 704;
				arrayList2.Add("TSPACETYPE");
				IL_3E68:
				num2 = 705;
				arrayList2.Add("TSTACKALIGN");
				IL_3E7A:
				num2 = 706;
				arrayList2.Add("TSTACKSIZE");
				IL_3E8C:
				num2 = 707;
				arrayList2.Add("UCSAXISANG");
				IL_3E9E:
				num2 = 708;
				arrayList2.Add("UCSBASE");
				IL_3EB0:
				num2 = 709;
				arrayList2.Add("UCSFOLLOW");
				IL_3EC2:
				num2 = 710;
				arrayList2.Add("UCSICON");
				IL_3ED4:
				num2 = 711;
				arrayList2.Add("UCSNAME");
				IL_3EE6:
				num2 = 712;
				arrayList2.Add("UCSORG");
				IL_3EF8:
				num2 = 713;
				arrayList2.Add("UCSORTHO");
				IL_3F0A:
				num2 = 714;
				arrayList2.Add("UCSVIEW");
				IL_3F1C:
				num2 = 715;
				arrayList2.Add("UCSVP");
				IL_3F2E:
				num2 = 716;
				arrayList2.Add("UCSXDIR");
				IL_3F40:
				num2 = 717;
				arrayList2.Add("UCSYDIR");
				IL_3F52:
				num2 = 718;
				arrayList2.Add("UNDOCTL");
				IL_3F64:
				num2 = 719;
				arrayList2.Add("UNDOMARKS");
				IL_3F76:
				num2 = 720;
				arrayList2.Add("UNITMODE");
				IL_3F88:
				num2 = 721;
				arrayList2.Add("USERI1~USERI5");
				IL_3F9A:
				num2 = 722;
				arrayList2.Add("USERR1~USERR5");
				IL_3FAC:
				num2 = 723;
				arrayList2.Add("USERS1~USERS5");
				IL_3FBE:
				num2 = 724;
				arrayList2.Add("VIEWCTR");
				IL_3FD0:
				num2 = 725;
				arrayList2.Add("VIEWDIR");
				IL_3FE2:
				num2 = 726;
				arrayList2.Add("VIEWMODE");
				IL_3FF4:
				num2 = 727;
				arrayList2.Add("VIEWSIZE");
				IL_4006:
				num2 = 728;
				arrayList2.Add("VIEWTWIST");
				IL_4018:
				num2 = 729;
				arrayList2.Add("VISRETAIN");
				IL_402A:
				num2 = 730;
				arrayList2.Add("VSMAX");
				IL_403C:
				num2 = 731;
				arrayList2.Add("VSMIN");
				IL_404E:
				num2 = 732;
				arrayList2.Add("WHIPARC");
				IL_4060:
				num2 = 733;
				arrayList2.Add("WHIPTHREAD");
				IL_4072:
				num2 = 734;
				arrayList2.Add("WMFBKGND");
				IL_4084:
				num2 = 735;
				arrayList2.Add("WMFFOREGND");
				IL_4096:
				num2 = 736;
				arrayList2.Add("WORLDUCS");
				IL_40A8:
				num2 = 737;
				arrayList2.Add("WORLDVIEW");
				IL_40BA:
				num2 = 738;
				arrayList2.Add("WRITESTAT");
				IL_40CC:
				num2 = 739;
				arrayList2.Add("XCLIPFRAME");
				IL_40DE:
				num2 = 740;
				arrayList2.Add("XEDIT");
				IL_40F0:
				num2 = 741;
				arrayList2.Add("XFADECTL");
				IL_4102:
				num2 = 742;
				arrayList2.Add("XLOADCTL");
				IL_4114:
				num2 = 743;
				arrayList2.Add("XLOADPATH");
				IL_4126:
				num2 = 744;
				arrayList2.Add("XREFCTL");
				IL_4138:
				num2 = 745;
				arrayList2.Add("ZOOMFACTOR");
				IL_414A:
				num2 = 746;
				StreamWriter streamWriter = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileWriter(this.string_0 + "\\GetAllSystemVar.txt", false);
				IL_4168:
				num2 = 747;
				long num3 = 0L;
				long num4 = (long)(checked(arrayList.Count - 1));
				long num5 = num3;
				checked
				{
					for (;;)
					{
						long num6 = num5;
						long num7 = num4;
						if (num6 > num7)
						{
							break;
						}
						IL_4186:
						num2 = 748;
						streamWriter.WriteLine(Operators.ConcatenateObject(Operators.ConcatenateObject(arrayList2[(int)num5], "             "), arrayList[(int)num5].ToString()));
						IL_41B9:
						num2 = 749;
						num5 += 1L;
					}
					IL_41D7:
					num2 = 750;
					streamWriter.Close();
					IL_41E4:
					num2 = 751;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_41FC:
					goto IL_4E1C;
					IL_4201:
					goto IL_4E27;
					IL_4206:
					num8 = num2;
					if (num <= -2)
					{
						goto IL_4221;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_4DF6;
					IL_4221:;
				}
				int num9 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_4DF6:
				goto IL_4E27;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4206;
			}
			IL_4E1C:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_4E27:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void _Lambda$__2(object sender, EventArgs e)
		{
			初始化设置.smethod_2(RuntimeHelpers.GetObjectValue(sender), (StatusBarMouseDownEventArgs)e);
		}

		[DebuggerStepThrough]
		[CompilerGenerated]
		private static void _Lambda$__3(object sender, EventArgs e)
		{
			初始化设置.smethod_2(RuntimeHelpers.GetObjectValue(sender), (StatusBarMouseDownEventArgs)e);
		}

		private string string_0;

		private string string_1;

		private TrayItem trayItem_0;

		private static Button button_0;

		private static bool bool_0;

		public string IconPath;

		private const int int_0 = 4;

		private const int int_1 = 517;

		private const int int_2 = 514;

		private const int int_3 = 513;

		private const int int_4 = 516;
	}
}
