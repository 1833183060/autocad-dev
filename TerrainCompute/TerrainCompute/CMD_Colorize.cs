using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{	
	public class CMD_Colorize
	{
		static CMD_Colorize()
		{
			CMD_Colorize.int_0 = 6;
			CMD_Colorize.string_0 = "AR";
			CMD_Colorize.string_1 = "N";
			CMD_Colorize.double_0 = 0.0;
			CMD_Colorize.double_1 = 100.0;
		}

		public CMD_Colorize()
		{            
		}

		[CommandMethod("TCPlugin", "ng:FACES:COLORIZE", 0)]
		public void ColorizeFacesCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			try
			{
				
				ObjectId[] faceIDs = CommandLineQuerries.SelectFaces(false);
				CMD_Colorize.string_0 = CommandLineQuerries.SpecifyTargetProperty(CMD_Colorize.string_0);
				CMD_Colorize.string_1 = CommandLineQuerries.KeywordYesNo("Reverse color order", CMD_Colorize.string_1, false, false);
				CMD_Colorize.int_0 = CommandLineQuerries.SpecifyInteger("Specify number of colors", CMD_Colorize.int_0, 2, 32768, false, false);
				CMD_Colorize.double_0 = CommandLineQuerries.SpecifyDouble("Specify lower cutoff percentage", CMD_Colorize.double_0, false, true, false, true);
				CMD_Colorize.double_1 = CommandLineQuerries.SpecifyDouble("Specify upper cutoff percentage", CMD_Colorize.double_1, false, false, false, false);
				Global.SuspendEpsilon(0.0, 0.0);
				List<Triangle> list = Conversions.ToCeometricAcDbTriangleList(faceIDs);
				Global.ResumeEpsilon();
				double num = 1.7976931348623157E+308;
				double num2 = -1.7976931348623157E+308;
				string formatFromLUPREC = DBManager.GetFormatFromLUPREC();
				string a;
				if ((a = CMD_Colorize.string_0) != null)
				{
					if (!(a == "AN"))
					{
						if (!(a == "AR"))
						{
							if (!(a == "CZ"))
							{
								if (!(a == "MINZ"))
								{
									if (!(a == "MAXZ"))
									{
										goto IL_714;
									}
									Triangle.Sort(list, Triangle.SortOrder.MaxZ);
									num = list[0].MaximumZ;
									num2 = list[list.Count - 1].MaximumZ;
									editor.WriteMessage("\nMinimum maximum Z: " + num.ToString(formatFromLUPREC));
									editor.WriteMessage("\nMaximum maximum Z: " + num2.ToString(formatFromLUPREC));
								}
								else
								{
									Triangle.Sort(list, Triangle.SortOrder.MinZ);
									num = list[0].MinimumZ;
									num2 = list[list.Count - 1].MinimumZ;
									editor.WriteMessage("\nMinimum minimum Z: " + num.ToString(formatFromLUPREC));
									editor.WriteMessage("\nMaximum minimum Z: " + num2.ToString(formatFromLUPREC));
								}
							}
							else
							{
								Triangle.Sort(list, Triangle.SortOrder.CenterZ);
								num = list[0].Center.Z;
								num2 = list[list.Count - 1].Center.Z;
								editor.WriteMessage("\nMinimum center Z: " + num.ToString(formatFromLUPREC));
								editor.WriteMessage("\nMaximum center Z: " + num2.ToString(formatFromLUPREC));
							}
						}
						else
						{
							Triangle.Sort(list, Triangle.SortOrder.Area);
							num = list[0].Area;
							num2 = list[list.Count - 1].Area;
							editor.WriteMessage("\nMinimum area: " + num.ToString(formatFromLUPREC));
							editor.WriteMessage("\nMaximum area: " + num2.ToString(formatFromLUPREC));
						}
					}
					else
					{
						Triangle.Sort(list, Triangle.SortOrder.MinimumAngle);
						num = list[0].MinimumAngle;
						num2 = list[list.Count - 1].MinimumAngle;
						editor.WriteMessage("\nMinimum minimum angle: " + (num * 180.0 / 3.1415926535897931).ToString(formatFromLUPREC) + " deg.");
						editor.WriteMessage("\nMaximum minimum angle: " + (num2 * 180.0 / 3.1415926535897931).ToString(formatFromLUPREC) + " deg.");
					}
					progressMeter.SetLimit(list.Count);
					progressMeter.Start("Colorizing property");
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
                        BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                        BlockTableRecord arg_3D7_0 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
						int i = 0;
						while (i < list.Count)
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
							string a2;
							if ((a2 = CMD_Colorize.string_0) != null)
							{
								double num3;
								if (!(a2 == "AN"))
								{
									if (!(a2 == "AR"))
									{
										if (!(a2 == "CZ"))
										{
											if (!(a2 == "MINZ"))
											{
												if (!(a2 == "MAXZ"))
												{
													goto IL_6F4;
												}
												num3 = list[i].MaximumZ;
											}
											else
											{
												num3 = list[i].MinimumZ;
											}
										}
										else
										{
											num3 = list[i].Center.Z;
										}
									}
									else
									{
										num3 = list[i].Area;
									}
								}
								else
								{
									num3 = list[i].MinimumAngle;
								}
								int num4 = CMD_Colorize.int_0 - 1;
								double num5 = Math.Abs((num3 - num) / (num2 - num));
								if (100.0 * num5 <= CMD_Colorize.double_0)
								{
									num5 = 0.0;
								}
								else if (100.0 * num5 >= CMD_Colorize.double_1)
								{
									num5 = 1.0;
								}
								else
								{
									num5 = num5 * 100.0 / (CMD_Colorize.double_1 - CMD_Colorize.double_0) - CMD_Colorize.double_0 / (CMD_Colorize.double_1 - CMD_Colorize.double_0);
								}
								num5 = Math.Round((double)num4 * num5, 0) / (double)num4;
								if (CMD_Colorize.string_1 == "Y")
								{
									num5 = 1.0 - num5;
								}
								double num6 = 0.2;
								byte b = 0;
								byte b2 = 0;
								byte b3 = 0;
								if (num5 < 0.2)
								{
									b3 = (byte)(255.0 * (num5 - 0.0 * num6) / num6);
									b2 = 255;
								}
								else if (num5 < 2.0 * num6)
								{
									b3 = 255;
									b2 = (byte)(255.0 - 255.0 * (num5 - 1.0 * num6) / num6);
								}
								else if (num5 < 3.0 * num6)
								{
									b = (byte)(255.0 * (num5 - 2.0 * num6) / num6);
									b3 = 255;
								}
								else if (num5 < 4.0 * num6)
								{
									b = 255;
									b3 = (byte)(255.0 - 255.0 * (num5 - 3.0 * num6) / num6);
								}
								else
								{
									b = 255;
									b2 = (byte)(255.0 * (num5 - 4.0 * num6) / num6);
								}
                                Face face = (Face)transaction.GetObject(list[i].AcDbFace.ObjectId, (OpenMode)1);
								face.Color=(Color.FromRgb(b, b3, b2));
								i++;
								continue;
							}
							IL_6F4:
                            throw new System.Exception("Invalid target property");
						}
						transaction.Commit();
						goto IL_71F;
					}
					goto IL_714;
					IL_71F:
					progressMeter.Stop();
					return;
				}
				IL_714:
                throw new System.Exception("Invalid target property");
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private static double double_0;

		private static double double_1;

		private static int int_0;

		private static string string_0;

		private static string string_1;
	}
}
