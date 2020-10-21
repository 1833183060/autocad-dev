using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace MyList
{	
	public class MenuLoader 
	{
		public MenuLoader()
		{
            
			this.string_1 = "";
			this.string_2 = "";
			this.string_3 = "";
            this.document_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
			
		}

		[CommandMethod("ng:MENU:CREATE")]
		public void CreateNewMenu()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				this.method_3();
                string menuFile="\"" + InitClass.AssemblyDirectory + "\\" + "agilePlugin.cuix\"";
				this.method_1(menuFile);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\nLoading CUI file failed: " + ex.Message);
			}
		}

		[CommandMethod("ng:MENU:DELETE")]
		public void DeleteExistingMenu()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				this.method_3();
				this.method_2("agile");
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\nUnloading CUI file failed.");
			}
			finally
			{
				if (File.Exists(this.string_2))
				{
					File.Delete(this.string_2);
					editor.WriteMessage("\nExisting file " + this.string_2 + " deleted.");
				}
			}
		}

		public void Initialize()
		{
			if (/*Reg.GetMenuLoaderState()*/true)
			{
				try
				{
					BackgroundWorker backgroundWorker = new BackgroundWorker();
					backgroundWorker.DoWork += new DoWorkEventHandler(this.method_0);
					backgroundWorker.RunWorkerAsync();
				}
                catch (System.Exception ex)
				{
                    Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
					editor.WriteMessage("\nError: " + ex.ToString());
				}
			}
		}

		private void method_0(object sender, DoWorkEventArgs e)
		{
			bool flag = true;
			while (flag)
			{
				try
				{
					this.document_0.SendStringToExecute("ng:MENU:DELETE ", false, false, false);
					this.document_0.SendStringToExecute("ng:MENU:CREATE ", false, false, false);
					break;
				}
                catch (System.Exception ex)
				{
					Thread.Sleep(500);
				}
			}
		}

		private void method_1(string menuFile)
		{
            Document mdiActiveDocument = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            object systemVariable = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("CMDECHO");
            object systemVariable2 = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("FILEDIA");
			mdiActiveDocument.SendStringToExecute("(setvar \"CMDECHO\" " + 0 + ")(princ) ", false, false, false);
			mdiActiveDocument.SendStringToExecute("(setvar \"FILEDIA\" " + 0 + ")(princ) ", false, false, false);
			mdiActiveDocument.SendStringToExecute("_.cuiload " + menuFile + " ", false, false, false);
			mdiActiveDocument.SendStringToExecute("(setvar \"FILEDIA\" " + systemVariable2.ToString() + ")(princ) ", false, false, false);
			mdiActiveDocument.SendStringToExecute("(setvar \"CMDECHO\" " + systemVariable.ToString() + ")(princ) ", false, false, false);
		}

		private void method_2(string string_4)
		{
            Document mdiActiveDocument = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            object systemVariable = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("CMDECHO");
            object systemVariable2 = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("FILEDIA");
			mdiActiveDocument.SendStringToExecute("(setvar \"CMDECHO\" " + 0 + ")(princ) ", false, false, false);
			mdiActiveDocument.SendStringToExecute("(setvar \"FILEDIA\" " + 0 + ")(princ) ", false, false, false);
			mdiActiveDocument.SendStringToExecute("_.cuiunload " + string_4 + " ", false, false, false);
			mdiActiveDocument.SendStringToExecute("(setvar \"FILEDIA\" " + systemVariable2.ToString() + ")(princ) ", false, false, false);
			mdiActiveDocument.SendStringToExecute("(setvar \"CMDECHO\" " + systemVariable.ToString() + ")(princ) ", false, false, false);
		}

		private void method_3()
		{
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			string text = ".cuix";
			
			
            this.string_1 = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("MENUNAME") + text;
			if (!File.Exists(this.string_1))
			{
				throw new FileNotFoundException("Main ACAD menu cui file not found: \n" + this.string_1);
			}
			FileInfo fileInfo = new FileInfo(this.string_1);
            this.string_2 = Path.Combine(fileInfo.DirectoryName, "agilePlugin" + text);
			string installationFolder = InitClass.AssemblyDirectory;
			this.string_3 = Path.Combine(installationFolder, "agilePlugin" + text);
		}

		private string method_4(string string_4)
		{
			return "\"" + string_4.Replace("\\", "/") + "\"";
		}

		public void Terminate()
		{
		}

		private Document document_0;

		private const string string_0 = "agile";

		private string string_1;

		private string string_2;

		private string string_3;
	}
}
