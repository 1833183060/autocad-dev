using System;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 注释
	{
		[DebuggerNonUserCode]
		public 注释()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDelZhuShiLayer")]
		public void 删除注释图层()
		{
			Class36.smethod_77("注释", "");
			Application.SetSystemVariable("LWDISPLAY", 0);
		}

		[CommandMethod("TcZhuShiLayer")]
		public void NotPrint()
		{
			CAD.CreateLayer("注释", 1, "continuous", 30, false, false);
			Application.SetSystemVariable("LWDISPLAY", 1);
		}
	}
}
