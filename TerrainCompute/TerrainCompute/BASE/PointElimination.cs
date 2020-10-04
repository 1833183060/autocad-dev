using System;
using System.Collections.Generic;
using System.ComponentModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

namespace TerrainComputeC.BASE
{
	//[LicenseProvider(typeof(Class46))]
	public class PointElimination
	{
		static PointElimination()
		{
			PointElimination.double_0 = 1E-09;
			PointElimination.string_0 = "H";
		}

		public PointElimination()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(PointElimination));
			//base..ctor();
		}

		[CommandMethod("TCPlugin", "ng:POINTS:ELIM2D", 0)]
		public void EliminatePoints2dCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database arg_15_0 = HostApplicationServices.WorkingDatabase;
			new List<IdPoint>();
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] pointIDs = CommandLineQuerries.SelectPoints(false);
				PointElimination.double_0 = CommandLineQuerries.SpecifyDouble("Specify snap radius", PointElimination.double_0, false, false, false, true);
				PointElimination.string_0 = CommandLineQuerries.KeepIfMultiple(PointElimination.string_0);
				int num = 0;
				IdPoint.EraseDublicates2d(pointIDs, PointElimination.double_0, PointElimination.string_0, ref num);
				editor.WriteMessage("\nNumber of points erased: " + num);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private static double double_0;

		private static string string_0;
	}
}
