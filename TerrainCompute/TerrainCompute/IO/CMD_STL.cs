using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.IO
{
	//[LicenseProvider(typeof(Class46))]
	public class CMD_STL
	{
		static CMD_STL()
		{
			CMD_STL.string_0 = "S";
			CMD_STL.string_1 = "B";
			CMD_STL.string_2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entities.stl");
			CMD_STL.string_3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "entities.stl");
			CMD_STL.string_4 = "N";
		}

		public CMD_STL()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(CMD_STL));
			//base..ctor();
		}

		private void method_0(string string_5)
		{
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			ProgressMeter progressMeter = new ProgressMeter();
			ASCIISTL aSCIISTL = new ASCIISTL();
			aSCIISTL.Read(string_5);
			editor.WriteMessage("\nSTL solid name                : " + aSCIISTL.SolidName);
			editor.WriteMessage("\nNumber of triangles read      : " + aSCIISTL.NumberOfTrianglesRead.ToString());
			editor.WriteMessage("\nNumber of degenerate triangles: " + aSCIISTL.NumberOfDegenerateTriangles.ToString());
			editor.WriteMessage("\nHas negative coordinates      : " + aSCIISTL.HasNegativeCoordinates.ToString());
			editor.WriteMessage("\nInconsistent facet normals    : " + aSCIISTL.HasInconsitentNormals.ToString());
			editor.WriteMessage("\n");
			ObjectId layerId = DBManager.CurrentLayerId();
			bool flag = false;
			string a;
			if ((a = CMD_STL.string_0) != null)
			{
				if (!(a == "S"))
				{
					if (!(a == "N"))
					{
						if (a == "C")
						{
							layerId = DBManager.CurrentLayerId();
						}
					}
					else
					{
						string text = "0";
						text = CommandLineQuerries.SpecifyLayerName(text);
						layerId = DBManager.CreateLayer(text, 7, false, ref flag);
					}
				}
				else
				{
					if (aSCIISTL.SolidName.Trim() == "")
					{
						aSCIISTL.SolidName = "Unnamed_solid";
					}
					if (!DBManager.ValidateName(aSCIISTL.SolidName))
					{
						return;
					}
					layerId = DBManager.CreateLayer(aSCIISTL.SolidName, 256, false, ref flag);
					editor.WriteMessage("Solid inserted on layer " + aSCIISTL.SolidName);
				}
			}
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)1);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],  (OpenMode)1);
				progressMeter.SetLimit(aSCIISTL.NumberOfTrianglesRead);
				progressMeter.Start("Writing database");
				for (int i = 0; i < aSCIISTL.Triangles.Count; i++)
				{
					try
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)i, 1000);
					}
                    catch (System.Exception ex)
					{
						progressMeter.Stop();
						throw;
					}
					Point3d point3d=new Point3d(aSCIISTL.Triangles[i].Vertex1.X, aSCIISTL.Triangles[i].Vertex1.Y, aSCIISTL.Triangles[i].Vertex1.Z);
					Point3d point3d2=new Point3d(aSCIISTL.Triangles[i].Vertex2.X, aSCIISTL.Triangles[i].Vertex2.Y, aSCIISTL.Triangles[i].Vertex2.Z);
					Point3d point3d3=new Point3d(aSCIISTL.Triangles[i].Vertex3.X, aSCIISTL.Triangles[i].Vertex3.Y, aSCIISTL.Triangles[i].Vertex3.Z);
					Face face = new Face(point3d, point3d2, point3d3, true, true, true, true);
					face.LayerId=(layerId);
					blockTableRecord.AppendEntity(face);
					transaction.AddNewlyCreatedDBObject(face, true);
				}
				transaction.Commit();
				progressMeter.Stop();
			}
		}

		private void method_1(string string_5)
		{
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			ProgressMeter progressMeter = new ProgressMeter();
			BinarySTL binarySTL = new BinarySTL();
			binarySTL.Read(string_5);
			editor.WriteMessage("\nNumber of triangles read      : " + binarySTL.NumberOfTrianglesRead.ToString());
			editor.WriteMessage("\nNumber of degenerate triangles: " + binarySTL.NumberOfDegenerateTriangles.ToString());
			editor.WriteMessage("\nHas negative coordinates      : " + binarySTL.HasNegativeCoordinates.ToString());
			editor.WriteMessage("\nInconsistent facet normals    : " + binarySTL.HasInconsitentNormals.ToString());
			editor.WriteMessage("\nFile contains colors          : " + binarySTL.ContainsColorDefinitions.ToString());
			editor.WriteMessage("\n");
			ObjectId layerId = DBManager.CurrentLayerId();
			bool flag = false;
			string a;
			if ((a = CMD_STL.string_0) != null)
			{
				if (!(a == "N"))
				{
					if (a == "C")
					{
						layerId = DBManager.CurrentLayerId();
					}
				}
				else
				{
					string text = "0";
					text = CommandLineQuerries.SpecifyLayerName(text);
					layerId = DBManager.CreateLayer(text, 7, false, ref flag);
				}
			}
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId,  (OpenMode)1);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace],  (OpenMode)1);
				progressMeter.SetLimit(binarySTL.NumberOfTrianglesRead);
				progressMeter.Start("Writing database");
				for (int i = 0; i < binarySTL.Triangles.Count; i++)
				{
					try
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)i, 1000);
					}
                    catch (System.Exception ex)
					{
						progressMeter.Stop();
						throw;
					}
					Point3d point3d=new Point3d(binarySTL.Triangles[i].Vertex1.X, binarySTL.Triangles[i].Vertex1.Y, binarySTL.Triangles[i].Vertex1.Z);
					Point3d point3d2=new Point3d(binarySTL.Triangles[i].Vertex2.X, binarySTL.Triangles[i].Vertex2.Y, binarySTL.Triangles[i].Vertex2.Z);
					Point3d point3d3=new Point3d(binarySTL.Triangles[i].Vertex3.X, binarySTL.Triangles[i].Vertex3.Y, binarySTL.Triangles[i].Vertex3.Z);
					Face face = new Face(point3d, point3d2, point3d3, true, true, true, true);
					if (binarySTL.ContainsColorDefinitions)
					{
						face.Color=(Color.FromRgb(binarySTL.Colors[i].R, binarySTL.Colors[i].G, binarySTL.Colors[i].B));
					}
					face.LayerId=(layerId);
					blockTableRecord.AppendEntity(face);
					transaction.AddNewlyCreatedDBObject(face, true);
				}
				transaction.Commit();
				progressMeter.Stop();
			}
		}

		private string method_2(string string_5)
		{
			string result = "B";
			using (StreamReader streamReader = new StreamReader(string_5))
			{
				if (streamReader.ReadLine().ToUpper().Trim().StartsWith("SOLID"))
				{
					result = "A";
				}
			}
			return result;
		}

		[CommandMethod("TCPlugin", "ng:IO:STLOUT", 0)]
		public void STLASCIIOutCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				//LicenseManager.CheckValid("FULL");
				CommandLineQuerries.SpecifyFileNameForWrite(ref CMD_STL.string_2, ref CMD_STL.string_4, "stl");
				CMD_STL.string_1 = CommandLineQuerries.SpecifySTLType(CMD_STL.string_1);
				ObjectId[] array = CommandLineQuerries.SelectFaces(false);
				Global.SuspendEpsilon(0.0, 0.0);
				List<Triangle> list = Conversions.ToCeometricAcDbTriangleList(array);
				Global.ResumeEpsilon();
				string a;
				if ((a = CMD_STL.string_1) != null)
				{
					if (!(a == "A"))
					{
						if (a == "B")
						{
							BinarySTL binarySTL = new BinarySTL();
							binarySTL.Triangles = list;
							for (int i = 0; i < list.Count; i++)
							{
								BinarySTL.STLColor sTLColor = new BinarySTL.STLColor();
								sTLColor.R = (byte)Math.Floor((double)list[i].AcDbFace.Color.Red / 8.0);
								sTLColor.G = (byte)Math.Floor((double)list[i].AcDbFace.Color.Green / 8.0);
								sTLColor.B = (byte)Math.Floor((double)list[i].AcDbFace.Color.Blue / 8.0);
								sTLColor.IsValid = true;
								sTLColor._cDef = binarySTL.ColorDefinition;
								binarySTL.Colors.Add(sTLColor);
							}
							binarySTL.Write(CMD_STL.string_2);
							editor.WriteMessage("\nNumber of triangles written   : " + binarySTL.NumberOfTrianglesWritten.ToString());
							editor.WriteMessage("\nNumber of degenerate triangles: " + binarySTL.NumberOfDegenerateTriangles.ToString());
							editor.WriteMessage("\nHas negative coordinates      : " + binarySTL.HasNegativeCoordinates.ToString());
							editor.WriteMessage("\nSTL file in binary format written to " + CMD_STL.string_2);
						}
					}
					else
					{
						string layerNameOfEntity = DBManager.GetLayerNameOfEntity(array[0]);
						string solidName = CommandLineQuerries.SpecifyString("Specify STL solid name", layerNameOfEntity, true);
						ASCIISTL aSCIISTL = new ASCIISTL();
						aSCIISTL.Triangles = list;
						aSCIISTL.SolidName = solidName;
						aSCIISTL.Write(CMD_STL.string_2);
						editor.WriteMessage("\nNumber of triangles written   : " + aSCIISTL.NumberOfTrianglesWritten.ToString());
						editor.WriteMessage("\nNumber of degenerate triangles: " + aSCIISTL.NumberOfDegenerateTriangles.ToString());
						editor.WriteMessage("\nHas negative coordinates      : " + aSCIISTL.HasNegativeCoordinates.ToString());
						editor.WriteMessage("\nSTL file in ASCII format written to " + CMD_STL.string_2);
					}
				}
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		[CommandMethod("TCPlugin", "ng:IO:STLIN", 0)]
		public void STLInCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database arg_15_0 = HostApplicationServices.WorkingDatabase;
			try
			{
				//LicenseManager.CheckValid("FULL");
				CommandLineQuerries.SpecifyFileNameForRead(ref CMD_STL.string_3, "stl");
				string a = this.method_2(CMD_STL.string_3);
				if (a == "A")
				{
					editor.WriteMessage("\nASCII STL format file identified.");
					CMD_STL.string_0 = CommandLineQuerries.InsertOnLayer_Current_Name_STL(CMD_STL.string_0);
					this.method_0(CMD_STL.string_3);
				}
				else if (a == "B")
				{
					editor.WriteMessage("\nBinary STL format file identified.");
					if (CMD_STL.string_0 == "S")
					{
						CMD_STL.string_0 = "C";
					}
					CMD_STL.string_0 = CommandLineQuerries.InsertOnLayer_Current_Name(CMD_STL.string_0);
					this.method_1(CMD_STL.string_3);
				}
				DBManager.ZoomExtents();
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private static string string_0;

		private static string string_1;

		private static string string_2;

		private static string string_3;

		private static string string_4;
	}
}
