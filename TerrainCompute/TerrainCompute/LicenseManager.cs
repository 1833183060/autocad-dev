using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace MyCompute
{
	//[LicenseProvider(typeof(Class46))]
	public class LicenseManager
	{
		static LicenseManager()
		{
			LicenseManager.IsInitialized = false;
			LicenseManager.LicenseFile = "";
			LicenseManager.IsTrialLicense = false;
			LicenseManager.IsLicensed = false;
			LicenseManager.Description = "";
			LicenseManager.HardwareID = "";
			LicenseManager.string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ComputationalCAD.license");
		}

		public LicenseManager()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(LicenseManager));
			//base..ctor();
		}

		public static void CheckValid(string license)
		{
			if (!LicenseManager.IsInitialized)
			{
				LicenseManager.Initialize();
				//LicenseManager.CheckValid(license);
				return;
			}
			if (LicenseManager.IsLicensed)
			{
				return;
			}
			MessageBox.Show(string.Concat(new string[]
			{
				"Your current license does not allow to execute this command.",
				Environment.NewLine,
				"Your current license status is: ",
				LicenseManager.Description,
				Environment.NewLine,
				"Visit www.computational-cad.com for support or to purchase a license."
			}), "ComputationalCAD license manager");
            throw new System.Exception("Your license options do not allow to execute this command.");
		}

		[CommandMethod("MyCompute", "ng:LICENSE:INFO", 0)]
		public void Info()
		{
            Document arg_0A_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			editor.WriteMessage("\nLicense file           : " + LicenseManager.LicenseFile);
			editor.WriteMessage("\nLicensed               : " + LicenseManager.IsLicensed.ToString());
			editor.WriteMessage("\nEvaluation_Lock_Enabled: " + LicenseManager.IsTrialLicense.ToString());
			editor.WriteMessage("\nTrial days             : " + Class50.smethod_22().ToString());
			editor.WriteMessage("\nCurrent day            : " + Class50.smethod_24().ToString());
			editor.WriteMessage("\nDescription            : " + LicenseManager.Description);
		}

		public static void Initialize()
		{
            Document arg_0A_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				LicenseManager.IsInitialized = false;
				try
				{
					LicenseManager.LicenseFile = Reg.GetComputationalCADRegistryValue("LICENSEFILE");
					if (File.Exists(LicenseManager.LicenseFile))
					{
						Class50.smethod_5(LicenseManager.LicenseFile);
					}
				}
				catch
				{
					LicenseManager.LicenseFile = "";
				}
				LicenseManager.IsLicensed = Class50.smethod_6();
				LicenseManager.IsTrialLicense = Class50.smethod_12();
				LicenseManager.HardwareID = Class50.smethod_40(true, true, true, false);
				if (LicenseManager.IsLicensed)
				{
					try
					{
						LicenseManager.Description = Class50.smethod_38().GetByIndex(0).ToString();
						goto IL_D2;
					}
					catch
					{
						LicenseManager.Description = "FULL";
						goto IL_D2;
					}
				}
				int num = Class50.smethod_22();
				int num2 = Class50.smethod_24();
				if (num > num2 && num > 0)
				{
					LicenseManager.Description = "Trial";
					LicenseManager.IsLicensed = true;
				}
				else
				{
					LicenseManager.Description = "Expired";
				}
				IL_D2:
				LicenseManager.IsInitialized = true;
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.ToString());
			}
		}

		[CommandMethod("MyCompute", "ng:LICENSE:INSTALL", 0)]
		public void InstallLicenseCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				CommandLineQuerries.SpecifyFileNameForRead(ref LicenseManager.string_0, "license");
				if (!File.Exists(LicenseManager.string_0))
				{
					editor.WriteMessage("\n" + LicenseManager.string_0 + " does not exist.");
				}
				else
				{
					Reg.SetComputationalCADRegistryValue("LICENSEFILE", LicenseManager.string_0);
					LicenseManager.Initialize();
				}
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		public static string Description;

		public static string HardwareID;

		public static bool IsInitialized;

		public static bool IsLicensed;

		public static bool IsTrialLicense;

		public static string LicenseFile;

		private static string string_0;
	}
}
