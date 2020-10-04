using System;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.BASE
{
	//[LicenseProvider(typeof(Class46))]
	public class PointBlurring
	{
		static PointBlurring()
		{
			PointBlurring.double_0 = 1E-09;
		}

		public PointBlurring()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(PointBlurring));
			//base..ctor();
		}

		[CommandMethod("TCPlugin", "ng:POINTS:BLUR", 0)]
		public void BlurPointsCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectPoints(false);
				double num = CommandLineQuerries.SpecifyDouble("Specify blur radius", PointBlurring.double_0, false, false, false, false);
				if (num != -1.0)
				{
					PointBlurring.double_0 = num;
					this.method_0(objectId_);
				}
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private void method_0(ObjectId[] objectId_0)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			try
			{
				progressMeter.SetLimit(objectId_0.Length + 1);
				if ((double)objectId_0.Length > 10000.0)
				{
					progressMeter.Start("Blurring points...");
				}
				CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
				CoordinateSystem actualCS = CoordinateSystem.Global();
				CoordinateTransformator coordinateTransformator = new CoordinateTransformator(actualCS, ceometricUcs);
				CoordinateTransformator inverseTransformation = coordinateTransformator.GetInverseTransformation();
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					for (int i = 0; i < objectId_0.Length; i++)
					{
						DBPoint dBPoint = (DBPoint)transaction.GetObject(objectId_0[i],  (OpenMode)1, true);
						Point point = Conversions.ToCeometricPoint(dBPoint);
						coordinateTransformator.Transform(point);
						point.X += RandomGenerator.NextDouble(-PointBlurring.double_0, PointBlurring.double_0);
						point.Y += RandomGenerator.NextDouble(-PointBlurring.double_0, PointBlurring.double_0);
						inverseTransformation.Transform(point);
						Point3d position=new Point3d(point.X, point.Y, point.Z);
						dBPoint.Position=(position);
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)i, 1000);
					}
					transaction.Commit();
					progressMeter.Stop();
					editor.WriteMessage(objectId_0.Length + " points blurred.");
				}
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}

		private static double double_0;
	}
}
