using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
using TerrainComputeC.BASE;

namespace TerrainComputeC
{
	
	public class CMD_Development
	{
		static CMD_Development()
		{
			CMD_Development.string_0 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "polyline_development.dwg");
			CMD_Development.string_1 = "N";
			CMD_Development.string_2 = "N";
			CMD_Development.string_3 = "N";
			CMD_Development.double_0 = 0.0;
			CMD_Development.double_1 = 0.0;
			CMD_Development.double_2 = 1.0;
			CMD_Development.double_3 = 1.0;
			CMD_Development.string_4 = "DWG";
			CMD_Development.string_5 = "N";
		}

		public CMD_Development()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_Development));
			//base..ctor();
		}

		public List<Point> Derivative(List<Point> graph)
		{
			List<Point> list = new List<Point>();
			for (int i = 0; i < graph.Count - 1; i++)
			{
				double num = graph[i + 1].X - graph[i].X;
				double num2 = graph[i + 1].Y - graph[i].Y;
				if (num >= 1E-09)
				{
					double num3 = num2 / num;
					list.Add(new Point(graph[i].X, CMD_Development.double_3 * num3, 0.0));
					list.Add(new Point(graph[i + 1].X, CMD_Development.double_3 * num3, 0.0));
				}
			}
			return list;
		}

		[CommandMethod("TCPlugin", "ng:LINES:DEVELOP", 0)]
		public void DevelopmentCommand()
		{
			Database arg_05_0 = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("Select polyline");
				promptEntityOptions.SetRejectMessage("\nNo polyline selected");
				promptEntityOptions.AddAllowedClass(typeof(Polyline3d), true);
				promptEntityOptions.AddAllowedClass(typeof(Polyline2d), true);
				promptEntityOptions.AddAllowedClass(typeof(Polyline), true);
				promptEntityOptions.AllowNone=(false);
				PromptEntityResult entity = editor.GetEntity(promptEntityOptions);
                if (entity.Status == (PromptStatus) (- 5002))
				{
					CommandLineQuerries.OnCancelled();
				}
                if (entity.Status != (PromptStatus)5100)
				{
					CommandLineQuerries.OnNotOK();
				}
				CMD_Development.string_2 = CommandLineQuerries.KeywordYesNo("Reverse polyline", CMD_Development.string_2, false, false);
				CMD_Development.string_3 = CommandLineQuerries.KeywordYesNo("Specify range", CMD_Development.string_3, false, false);
				if (CMD_Development.string_3 == "Y")
				{
					CMD_Development.double_0 = CommandLineQuerries.SpecifyDouble("Specify start arc length", CMD_Development.double_0, false, false, false, true);
					CMD_Development.double_1 = CommandLineQuerries.SpecifyDouble("Specify end arc length", CMD_Development.double_1, false, false, false, true);
				}
				CMD_Development.double_2 = CommandLineQuerries.SpecifyDouble("Specify z-scaling", CMD_Development.double_2, false, false, false, false);
				CMD_Development.string_5 = CommandLineQuerries.KeywordYesNo("Include first derivative (slope)", CMD_Development.string_5, false, false);
				if (CMD_Development.string_5 == "Y")
				{
					CMD_Development.double_3 = CommandLineQuerries.SpecifyDouble("Specify z-scaling for derivative", CMD_Development.double_3, false, false, false, false);
				}
				CMD_Development.string_4 = CommandLineQuerries.SpecifyOutfileType(CMD_Development.string_4);
				CommandLineQuerries.SpecifyFileNameForWrite(ref CMD_Development.string_0, ref CMD_Development.string_1, CMD_Development.string_4);
				bool reverse = CMD_Development.string_2 == "Y";
				double startBGL = 0.0;
				double endBGL = 1.7976931348623157E+308;
				if (CMD_Development.string_3 == "Y")
				{
					startBGL = CMD_Development.double_0;
					endBGL = CMD_Development.double_1;
				}
				List<Point> list = this.DevelopPolyline(entity.ObjectId, reverse, startBGL, endBGL);
				List<Point> points = new List<Point>();
				if (CMD_Development.string_5 == "Y")
				{
					points = this.Derivative(list);
				}
				CMD_Development.Result result = new CMD_Development.Result(list, startBGL);
				editor.WriteMessage("\n" + result.ToString());
				Database database = new Database(true, true);
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
                    BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, (OpenMode)1);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					bool flag = false;
					ObjectId layerId = DBManager.CreateLayer("profile", 7, false, ref flag, database);
					Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(list);
					Polyline3d polyline3d = new Polyline3d(0, point3dCollection, false);
					point3dCollection.Dispose();
					polyline3d.LayerId=(layerId);
					blockTableRecord.AppendEntity(polyline3d);
					transaction.AddNewlyCreatedDBObject(polyline3d, true);
					if (CMD_Development.string_5 == "Y")
					{
						bool flag2 = false;
						ObjectId layerId2 = DBManager.CreateLayer("slope", 4, false, ref flag2, database);
						Point3dCollection point3dCollection2 = Conversions.ToPoint3dCollection(points);
						Polyline3d polyline3d2 = new Polyline3d(0, point3dCollection2, false);
						point3dCollection2.Dispose();
						polyline3d2.LayerId=(layerId2);
						blockTableRecord.AppendEntity(polyline3d2);
						transaction.AddNewlyCreatedDBObject(polyline3d2, true);
					}
					transaction.Commit();
					polyline3d.Dispose();
				}
				DBManager.SaveDrawing(database, CMD_Development.string_0, CMD_Development.string_4, (DwgVersion)29);
			}
			catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		public List<Point> DevelopPolyline(ObjectId plineID, bool reverse, double startBGL, double endBGL)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			PointSet pointSet = new PointSet();
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                DBObject @object = transaction.GetObject(plineID, (OpenMode)0, true);
				pointSet = PointGeneration.SubdividePolyline(@object, transaction, 0.0);
			}
			if (reverse)
			{
				pointSet.Reverse();
			}
			PointSet pointSet2 = new PointSet();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			for (int i = 0; i < pointSet.Count - 1; i++)
			{
				double num4 = pointSet[i].DistanceTo(pointSet[i + 1]);
				double num5 = pointSet[i].DistanceXY(pointSet[i + 1]);
				if (startBGL >= num && startBGL < num + num4)
				{
					ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(pointSet[i + 1] - pointSet[i]);
					vector3d.Norm = Math.Abs(startBGL - num);
					pointSet2.Add(pointSet[i] + vector3d.ToPoint());
					num3 = num2 + pointSet[i].DistanceXY(pointSet[i] + vector3d.ToPoint());
				}
				if (num > startBGL && num < endBGL)
				{
					pointSet2.Add(pointSet[i]);
				}
				if (endBGL > num && endBGL <= num + num4)
				{
					ngeometry.VectorGeometry.Vector3d vector3d2 = new ngeometry.VectorGeometry.Vector3d(pointSet[i + 1] - pointSet[i]);
					vector3d2.Norm = Math.Abs(endBGL - num);
					pointSet2.Add(pointSet[i] + vector3d2.ToPoint());
				}
				num += num4;
				num2 += num5;
			}
			if (endBGL > num)
			{
				pointSet2.Add(pointSet[pointSet.Count - 1]);
			}
			PointSet pointSet3 = new PointSet();
			double num6 = num3;
			for (int j = 0; j < pointSet2.Count; j++)
			{
				pointSet3.Add(new Point(num6, CMD_Development.double_2 * pointSet2[j].Z, 0.0));
				if (j == pointSet2.Count - 1)
				{
					break;
				}
				num6 += pointSet2[j].DistanceXY(pointSet2[j + 1]);
			}
			return pointSet3.ToList();
		}

		private static double double_0;

		private static double double_1;

		private static double double_2;

		private static double double_3;

		private static string string_0;

		private static string string_1;

		private static string string_2;

		private static string string_3;

		private static string string_4;

		private static string string_5;

		//[LicenseProvider(typeof(Class46))]
		public class Result
		{
			public Result(List<Point> vertices, double startBGL)
			{
                //System.ComponentModel.LicenseManager.Validate(typeof(CMD_Development.Result));
				this.StartGRL = double.NaN;
				this.EndGRL = double.NaN;
				this.double_0 = double.NaN;
				this.StartBGL = double.NaN;
				this.EndBGL = double.NaN;
				this.double_1 = double.NaN;
				this.MaximumSlope = -1.7976931348623157E+308;
				this.MaximumSlopeGRL = double.NaN;
				this.MinimumSlope = 1.7976931348623157E+308;
				this.MinimumSlopeGRL = double.NaN;
				this.MaximumElevation = -1.7976931348623157E+308;
				this.MinimumElevation = 1.7976931348623157E+308;
				this.DeltaElevation = double.NaN;
				//base..ctor();
				this.NumberOfVertices = vertices.Count;
				this.StartGRL = vertices[0].X;
				this.EndGRL = vertices[vertices.Count - 1].X;
				this.StartBGL = startBGL;
				this.EndBGL = this.StartBGL;
				for (int i = 0; i < vertices.Count; i++)
				{
					if (vertices[i].Y < this.MinimumElevation)
					{
						this.MinimumElevation = vertices[i].Y;
					}
					if (vertices[i].Y > this.MaximumElevation)
					{
						this.MaximumElevation = vertices[i].Y;
					}
					if (i == vertices.Count - 1)
					{
						break;
					}
					this.EndBGL += vertices[i].DistanceTo(vertices[i + 1]);
					double num = vertices[i + 1].X - vertices[i].X;
					if (num >= 1E-09)
					{
						double num2 = vertices[i + 1].Y - vertices[i].Y;
						double num3 = num2 / num;
						if (num3 > this.MaximumSlope)
						{
							this.MaximumSlope = num3;
							this.MaximumSlopeGRL = vertices[i].X;
						}
						if (num3 < this.MinimumSlope)
						{
							this.MinimumSlope = num3;
							this.MinimumSlopeGRL = vertices[i].X;
						}
					}
				}
				this.MinimumSlope *= 100.0;
				this.MaximumSlope *= 100.0;
				this.double_0 = this.EndGRL - this.StartGRL;
				this.double_1 = this.EndBGL - this.StartBGL;
				this.DeltaElevation = this.MaximumElevation - this.MinimumElevation;
			}

			public override string ToString()
			{
				string formatFromLUPREC = DBManager.GetFormatFromLUPREC();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Number of vertices : " + this.NumberOfVertices.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Start arc length   : " + this.StartBGL.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("End arc length     : " + this.EndBGL.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Delta arc length   : " + this.double_1.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Start ground length: " + this.StartGRL.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("End ground length  : " + this.EndGRL.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Delta ground length: " + this.double_0.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Minimum slope [%]  : " + this.MinimumSlope.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("   at ground length: " + this.MinimumSlopeGRL.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Maximum slope [%]  : " + this.MaximumSlope.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("   at ground length: " + this.MaximumSlopeGRL.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Minimum elevation  : " + this.MinimumElevation.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Maximum elevation  : " + this.MaximumElevation.ToString(formatFromLUPREC));
				stringBuilder.AppendLine("Delta elevation    : " + this.DeltaElevation.ToString(formatFromLUPREC));
				return stringBuilder.ToString();
			}

			public double DeltaElevation;

			public double double_0;

			public double double_1;

			public double EndBGL;

			public double EndGRL;

			public double MaximumElevation;

			public double MaximumSlope;

			public double MaximumSlopeGRL;

			public double MinimumElevation;

			public double MinimumSlope;

			public double MinimumSlopeGRL;

			public int NumberOfVertices;

			public double StartBGL;

			public double StartGRL;
		}
	}
}
