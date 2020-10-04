using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;

namespace 田草CAD工具箱_For2014
{
	public class 图库
	{
		[DebuggerNonUserCode]
		public 图库()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcJZTK")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void JZTK()
		{
			string text = Class33.Class31_0.Info.DirectoryPath + "\\DWG\\建筑图库.dwg";
			DocumentCollection documentManager = Application.DocumentManager;
			Document mdiActiveDocument = DocumentCollectionExtension.Open(Application.DocumentManager, text, false);
			documentManager.MdiActiveDocument = mdiActiveDocument;
		}

		[CommandMethod("TcJGTK")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void JGTK()
		{
			string text = Class33.Class31_0.Info.DirectoryPath + "\\DWG\\结构图库.dwg";
			DocumentCollection documentManager = Application.DocumentManager;
			Document mdiActiveDocument = DocumentCollectionExtension.Open(Application.DocumentManager, text, false);
			documentManager.MdiActiveDocument = mdiActiveDocument;
		}

		[CommandMethod("TK")]
		public void TK()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			mdiActiveDocument.SendStringToExecute("ToolPalettes ", true, false, false);
		}

		[CommandMethod("TKFind")]
		public void TKFind()
		{
			TKFind_Frm tkfind_Frm = new TKFind_Frm();
			Application.ShowModelessDialog(tkfind_Frm);
		}
	}
}
