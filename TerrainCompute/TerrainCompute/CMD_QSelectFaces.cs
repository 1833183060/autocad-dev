using System;
using System.Collections.Generic;
using System.ComponentModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	
	public class CMD_QSelectFaces
	{
		static CMD_QSelectFaces()
		{
			CMD_QSelectFaces.string_0 = "AR";
			CMD_QSelectFaces.string_1 = ">";
		}

		public CMD_QSelectFaces()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_QSelectFaces));
			//base..ctor();
		}

		public void QSelectFacesCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			try
			{
				//LicenseManager.CheckValid("FULL");
				CMD_QSelectFaces.string_0 = CommandLineQuerries.SpecifyTargetProperty(CMD_QSelectFaces.string_0);
				CMD_QSelectFaces.string_1 = CommandLineQuerries.SpecifyOperator(CMD_QSelectFaces.string_1);
				double num = CommandLineQuerries.SpecifyDouble("Specify criterion", 0.0, false, true, false, true);
				List<Triangle> list = Conversions.ToCeometricAcDbTriangleList(DBManager.GetAllFaces());
				int num2 = 0;
				progressMeter.SetLimit(list.Count);
				progressMeter.Start("Selecting faces");
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                    BlockTableRecord arg_BE_0 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					List<ObjectId> list2 = new List<ObjectId>();
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						if (list[i].Area < num)
						{
                            Face face = (Face)transaction.GetObject(list[i].AcDbFace.ObjectId, (OpenMode)1);
							list2.Add(face.ObjectId);
							num2++;
						}
						progressMeter.MeterProgress();
					}
					transaction.Commit();
				}
				progressMeter.Stop();
				editor.WriteMessage("Number of faces selected: " + num2);
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private static string string_0;

		private static string string_1;
	}
}
