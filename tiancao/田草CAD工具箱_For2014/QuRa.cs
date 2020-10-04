using System;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;

namespace 田草CAD工具箱_For2014
{
	public class QuRa
	{
		[DebuggerNonUserCode]
		public QuRa()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcQuRa")]
		public void JG()
		{
			TcQuRa_frm tcQuRa_frm = new TcQuRa_frm();
			Application.ShowModelessDialog(tcQuRa_frm);
		}
	}
}
