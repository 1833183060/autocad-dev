using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class 工具面板
	{
		[DebuggerNonUserCode]
		public 工具面板()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcShowPic")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcShowPic()
		{
			Interaction.Shell(Class33.Class31_0.Info.DirectoryPath + "\\showpic.exe", AppWinStyle.NormalFocus, false, -1);
		}

		[CommandMethod("TcCGB")]
		public void TcCGB()
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
				TcCGB_Frm tcCGB_Frm = new TcCGB_Frm();
				IL_11:
				num2 = 3;
				Application.ShowModelessDialog(tcCGB_Frm);
				IL_19:
				goto IL_76;
				IL_1B:
				goto IL_80;
				IL_1D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_34;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_54;
				IL_34:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_54:
				goto IL_80;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D;
			}
			IL_76:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_80:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcSet")]
		public void TcSet()
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
				TcSet_frm tcSet_frm = new TcSet_frm();
				IL_11:
				num2 = 3;
				Application.ShowModelessDialog(tcSet_frm);
				IL_19:
				goto IL_7D;
				IL_1B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_39:
				goto IL_72;
				IL_3B:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_50:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_3B;
			}
			IL_72:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_7D:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcJGZiLiao")]
		public void method_0()
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
				TcJG_ZiLiao_frm tcJG_ZiLiao_frm = new TcJG_ZiLiao_frm();
				IL_11:
				num2 = 3;
				Application.ShowModelessDialog(tcJG_ZiLiao_frm);
				IL_19:
				goto IL_76;
				IL_1B:
				goto IL_80;
				IL_1D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_34;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_54;
				IL_34:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_54:
				goto IL_80;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D;
			}
			IL_76:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_80:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcPC")]
		public void TcPC()
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
				TcPC_frm tcPC_frm = new TcPC_frm();
				IL_11:
				num2 = 3;
				Application.ShowModelessDialog(tcPC_frm);
				IL_19:
				goto IL_76;
				IL_1B:
				goto IL_80;
				IL_1D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_34;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_54;
				IL_34:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_54:
				goto IL_80;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D;
			}
			IL_76:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_80:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcTuku")]
		public void TcTuku()
		{
			WinAPI.keybd_event(17, 0, 0L, 0L);
			WinAPI.keybd_event(51, 0, 0L, 0L);
			WinAPI.keybd_event(51, 0, 2L, 0L);
			WinAPI.keybd_event(17, 0, 2L, 0L);
		}

		[CommandMethod("TcTiancaoNet")]
		public void TcTiancaoNet()
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
				Interaction.Shell("rundll32 url.dll FileProtocolHandler http://www.tiancao.net", AppWinStyle.MinimizedFocus, false, -1);
				IL_19:
				goto IL_79;
				IL_1B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_35:
				goto IL_6E;
				IL_37:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4C:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_37;
			}
			IL_6E:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_79:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcHelp")]
		public void TcHelp()
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
				Interaction.Shell("rundll32 url.dll FileProtocolHandler http://www.tiancao.net/ID1881.htm", AppWinStyle.MinimizedFocus, false, -1);
				IL_19:
				goto IL_79;
				IL_1B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_35:
				goto IL_6E;
				IL_37:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4C:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_37;
			}
			IL_6E:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_79:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcUpdate")]
		public void TcUpdate()
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
				Interaction.Shell("rundll32 url.dll FileProtocolHandler http://www.tiancao.net/ID1881.htm", AppWinStyle.MinimizedFocus, false, -1);
				IL_19:
				goto IL_72;
				IL_1B:
				goto IL_7C;
				IL_1D:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_34;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_50;
				IL_34:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_50:
				goto IL_7C;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D;
			}
			IL_72:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_7C:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcShowAbout")]
		public void TcShowAbout()
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
				TcAboutBox tcAboutBox = new TcAboutBox();
				IL_11:
				num2 = 3;
				Application.ShowModelessDialog(tcAboutBox);
				IL_19:
				goto IL_7D;
				IL_1B:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_39:
				goto IL_72;
				IL_3B:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_1B;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_50:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_3B;
			}
			IL_72:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_7D:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcCiKu")]
		public void CiKu()
		{
			tcCiKu_frm tcCiKu_frm = new tcCiKu_frm();
			Application.ShowModelessDialog(tcCiKu_frm);
		}

		[CommandMethod("TcYin")]
		public void Yin()
		{
			BlockYin blockYin = new BlockYin();
			Application.ShowModelessDialog(blockYin);
		}

		[CommandMethod("TcDJ")]
		public void DJ()
		{
			TcDJ_frm tcDJ_frm = new TcDJ_frm();
			Application.ShowModelessDialog(tcDJ_frm);
		}

		[CommandMethod("TcBMP")]
		public void TcBMP()
		{
			TcBmp2Dwg_frm tcBmp2Dwg_frm = new TcBmp2Dwg_frm();
			Application.ShowModelessDialog(tcBmp2Dwg_frm);
		}

		[CommandMethod("TcDwgOnLine")]
		public void TcDwgOnLine()
		{
			Application.ShowModelessDialog(new TcDwgOnLine_frm
			{
				URL = "http://www.tiancao.net/dwg/"
			});
		}

		[CommandMethod("TcJG")]
		public void JG()
		{
			PaletteSet paletteSet = null;
			if (paletteSet == null)
			{
				TcJG_Frm tcJG_Frm = new TcJG_Frm();
				paletteSet = new PaletteSet("田草结构_TcJG");
				tcJG_Frm.AutoScaleMode = AutoScaleMode.None;
				paletteSet.Add("田草结构_TcJG", tcJG_Frm);
				PaletteSet paletteSet2 = paletteSet;
				Size minimumSize = new Size(210, 500);
				paletteSet2.MinimumSize = minimumSize;
				Size size = new Size(210, 500);
				paletteSet.Size = size;
			}
			else
			{
				Interaction.MsgBox(paletteSet.Name, MsgBoxStyle.OkOnly, null);
			}
			paletteSet.Visible = true;
		}

		[CommandMethod("TcJoinDwg")]
		public void TcJoinDwg()
		{
			TcJoinDwg_Frm tcJoinDwg_Frm = new TcJoinDwg_Frm();
			Application.ShowModelessDialog(tcJoinDwg_Frm);
		}

		[CommandMethod("TcFind")]
		public void Find()
		{
			TcFind_Frm tcFind_Frm = new TcFind_Frm();
			Application.ShowModelessDialog(tcFind_Frm);
		}

		[CommandMethod("TcFilter")]
		public void TcFilter()
		{
			Filter_Frm filter_Frm = new Filter_Frm();
			Application.ShowModelessDialog(filter_Frm);
		}

		[CommandMethod("AddButton")]
		public void AddButton()
		{
			Pane pane = new Pane();
			pane.Enabled = true;
			pane.Text = "添加按钮实例";
			pane.ToolTipText = "添加按钮实例 ToolTipsText";
			pane.Visible = true;
			pane.Style = 8;
			pane.MouseDown += new StatusBarMouseDownEventHandler(this.StatusBarButton1_MouseDown);
			Application.StatusBar.Panes.Add(pane);
		}

		public void StatusBarButton1_MouseDown(object sender, StatusBarMouseDownEventArgs e)
		{
			Interaction.MsgBox("你按下了该按钮，你可在此添加你要执行的代码！", MsgBoxStyle.OkOnly, null);
		}

		[CommandMethod("AddOptionsTab")]
		public void AddOptionsTab()
		{
			Application.DisplayingOptionDialog += new TabbedDialogEventHandler(this.OptionsTab1);
		}

		public void OptionsTab1(object sender, TabbedDialogEventArgs e)
		{
		}

		public void OnButtonOK()
		{
			Interaction.MsgBox("这是你新添加的Tab", MsgBoxStyle.OkOnly, null);
		}

		[CommandMethod("TcCMD")]
		public void TcCMD()
		{
			PaletteSet paletteSet = null;
			if (paletteSet == null)
			{
				TcCMD_Frm tcCMD_Frm = new TcCMD_Frm();
				paletteSet = new PaletteSet("田草CAD工具箱命令面板_TcCMD");
				paletteSet.Add("田草CAD工具箱命令面板_TcCMD", tcCMD_Frm);
				PaletteSet paletteSet2 = paletteSet;
				Size minimumSize = new Size(126, 500);
				paletteSet2.MinimumSize = minimumSize;
				Size size = new Size(250, 500);
				paletteSet.Size = size;
			}
			paletteSet.Visible = true;
		}

		[CommandMethod("TcCMD2")]
		public void TcCMD2()
		{
			PaletteSet paletteSet = null;
			if (paletteSet == null)
			{
				TcCMD2_Frm tcCMD2_Frm = new TcCMD2_Frm();
				string text = "田草CAD工具箱命令面板_TcCMD2";
				Guid guid = new Guid("5C8FC28C-45ED-4796-BD40-28D235B6D7DB");
				paletteSet = new PaletteSet(text, guid);
				paletteSet.DockEnabled = 20480;
				paletteSet.Add("田草CAD工具箱命令面板_TcCMD2", tcCMD2_Frm);
			}
			paletteSet.Visible = true;
		}

		[CommandMethod("TcCMD_Open")]
		public void CMD_Open()
		{
			PaletteSet paletteSet = null;
			if (paletteSet != null)
			{
				paletteSet.Visible = true;
			}
		}

		[CommandMethod("TcCMDTM")]
		public void CMDMBTM()
		{
			PaletteSet paletteSet = null;
			if (paletteSet != null)
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions("\n透明度百分比:");
				PromptIntegerResult integer = mdiActiveDocument.Editor.GetInteger(promptIntegerOptions);
				paletteSet.Opacity = integer.Value;
			}
		}

		[CommandMethod("TcDvarFrm")]
		public void DvarFrm()
		{
			DVar_Frm dvar_Frm = new DVar_Frm();
			Application.ShowModelessDialog(dvar_Frm);
		}

		[CommandMethod("TcFileHistory")]
		public void TcFileHistory()
		{
			try
			{
				TcFileHistory_Frm tcFileHistory_Frm = new TcFileHistory_Frm();
				Application.ShowModelessDialog(tcFileHistory_Frm);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("TcFileHistory:" + ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		[CommandMethod("TcBJFJ")]
		public void TcBJFJ()
		{
			TcBJFJ_frm tcBJFJ_frm = new TcBJFJ_frm();
			Application.ShowModelessDialog(tcBJFJ_frm);
		}

		[CommandMethod("TcSoftDown")]
		public void Softdown()
		{
			Process.Start("Http://www.tiancao.net/soft/");
		}

		[CommandMethod("TcGuiFanOnline")]
		public void TcGuiFanOnline()
		{
			Process.Start("Http://www.tiancao.net/gb/");
		}

		[CommandMethod("TcBiaoGao")]
		public void BG()
		{
			BiaoGao_Frm biaoGao_Frm = new BiaoGao_Frm();
			Application.ShowModelessDialog(biaoGao_Frm);
		}

		[CommandMethod("TcJMTX")]
		public void JMTX()
		{
			JMTX_Frm jmtx_Frm = new JMTX_Frm();
			Application.ShowModelessDialog(jmtx_Frm);
		}

		[CommandMethod("TcXG")]
		public void XG()
		{
			TcXG_frm tcXG_frm = new TcXG_frm();
			Application.ShowModelessDialog(tcXG_frm);
		}

		[CommandMethod("TcGJB")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcGJ()
		{
			string pathName = Class33.Class31_0.Info.DirectoryPath + "\\钢筋表.exe";
			Interaction.Shell(pathName, AppWinStyle.NormalFocus, false, -1);
		}
	}
}
