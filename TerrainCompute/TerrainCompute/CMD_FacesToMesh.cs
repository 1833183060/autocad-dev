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
	
	public class CMD_FacesToMesh
	{
		static CMD_FacesToMesh()
		{
			CMD_FacesToMesh.string_0 = "Y";
		}

		public CMD_FacesToMesh()
		{
           
		}

		[CommandMethod("TCPlugin", "ng:FACES:TOMESH", 0)]
		public void GenerateSubDMeshCommand()
		{
			Database arg_05_0 = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				
				if (!Reg.Is2010OrHigher())
				{
                    Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("This method is supported only for version 2010 or higher.");
				}
				else
				{
					ObjectId[] array = CommandLineQuerries.SelectFaces(false);
                    string text = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("SMOOTHMESHMAXFACE").ToString().Trim();
					if (array.Length > Convert.ToInt32(text))
					{
						throw new InvalidOperationException(string.Concat(new object[]
						{
							"\nERROR: you have selected ",
							array.Length.ToString(),
							" faces while an allowable maximum of ",
							text,
							" is specified in the SMOOTHMESHMAXFACE system variable. Please set the SMOOTHMESHMAXFACE system variable at least to ",
							array.Length,
							" or select fewer faces."
						}));
					}
					CMD_FacesToMesh.string_0 = CommandLineQuerries.KeywordYesNo("Delete original faces", CMD_FacesToMesh.string_0, false, false);
					List<Triangle> triangles = Conversions.ToCeometricAcDbTriangleList(array);
					List<List<Triangle>> list = this.method_0(triangles);
					for (int i = 0; i < list.Count; i++)
					{
						SubDMeshHandler subDMeshHandler = new SubDMeshHandler(list[i]);
						SubDMeshHandler.MeshGenerationResult meshGenerationResult = subDMeshHandler.GenerateSubDMesh();
						editor.WriteMessage("\nMesh " + i.ToString().PadLeft(4) + ":\n" + meshGenerationResult.ToString());
					}
					if (CMD_FacesToMesh.string_0 == "Y")
					{
						DBManager.EraseObjects(array, 100000);
					}
				}
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private List<List<Triangle>> method_0(List<Triangle> triangles)
		{
			List<List<Triangle>> list = new List<List<Triangle>>();
			int i = 0;
			IL_B0:
			while (i < triangles.Count)
			{
				Triangle triangle = triangles[i];
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					if (triangle.AcDbFace.LayerId == list[j][0].AcDbFace.LayerId && triangle.AcDbFace.Color == list[j][0].AcDbFace.Color)
					{
						list[j].Add(triangle);
						flag = true;
						IL_92_:
						if (!flag)
						{
							list.Add(new List<Triangle>
							{
								triangle
							});
						}
						i++;
						goto IL_B0;
					}
				}
                goto IL_92;
            IL_92:
                {
                    if (!flag)
                    {
                        list.Add(new List<Triangle>
							{
								triangle
							});
                    }
                    i++;
                    goto IL_B0;
                }
			}
			return list;
		}

		private static string string_0;
	}
}
