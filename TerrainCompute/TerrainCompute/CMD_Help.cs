using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class CMD_Help
	{
		public CMD_Help()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_Help));
			//base..ctor();
		}

		[DllImport("hhctrl.ocx", SetLastError = true)]
		public static extern IntPtr HtmlHelp(IntPtr hWndCaller, string helpFile, uint command, int data);

		[CommandMethod("TCPlugin", "ng:HELP", 0)]
		public void OpenHelp_Command()
		{
			try
			{
				string text = Reg.GetInstallationFolder() + "\\ComputationalCAD_Help.chm";
				IntPtr value = CMD_Help.HtmlHelp((IntPtr)0, text, 1u, 0);
				if (value == IntPtr.Zero)
				{
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("No help file available for TCPlugin at " + text);
				}
			}
            catch (System.Exception ex)
			{
                Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Could not determine TCPlugin installation path:" + Environment.NewLine + ex.Message);
			}
		}

		////[LicenseProvider(typeof(Class46))]
		private enum Enum0
		{

		}
	}
}
