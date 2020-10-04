using System;
using System.ComponentModel;
using System.IO;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{	
	public class CommandLineQuerries
	{
		static CommandLineQuerries()
		{
			CommandLineQuerries.SelectedInsertOnLayer = "C";
			CommandLineQuerries.SelectedLayerName = "0";
			CommandLineQuerries.SelectedInsertAsBlock = "N";
			CommandLineQuerries.SelectedBlockName = SymbolUtilityServices.BlockModelSpaceName;
			CommandLineQuerries.IsNewBlock = false;
		}

		public CommandLineQuerries()
		{
          
		}

		public static ObjectId BlockSelectionDialog()
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			CommandLineQuerries.SelectedInsertAsBlock = CommandLineQuerries.KeywordYesNo("Insert as block", CommandLineQuerries.SelectedInsertAsBlock, false, false);
			CommandLineQuerries.IsNewBlock = false;
			if (CommandLineQuerries.SelectedInsertAsBlock == "Y")
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
                    BlockTableRecord arg_7C_0 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					bool flag = true;
					while (flag)
					{
						CommandLineQuerries.SelectedBlockName = CommandLineQuerries.SpecifyBlockName(CommandLineQuerries.SelectedBlockName);
						if (!blockTable.Has(CommandLineQuerries.SelectedBlockName))
						{
							break;
						}
						if (CommandLineQuerries.SelectedBlockName == SymbolUtilityServices.BlockModelSpaceName)
						{
							return SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
						}
						editor.WriteMessage(Environment.NewLine + "A block with this name already exists.");
					}
				}
				return DBManager.CreateBlock(CommandLineQuerries.SelectedBlockName, ref CommandLineQuerries.IsNewBlock);
			}
			CommandLineQuerries.SelectedBlockName = SymbolUtilityServices.BlockModelSpaceName;
			return SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
		}

		public static ObjectId[] GetObjectIDs(CommandLineQuerries.EntityType type)
		{
			return CommandLineQuerries.GetObjectIDs(type, "", false);
		}

		public static ObjectId[] GetObjectIDs(CommandLineQuerries.EntityType type, string message, bool singleOnly)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[0];
			switch (type)
			{
			case CommandLineQuerries.EntityType.ARC:
				array = new TypedValue[]
				{
					new TypedValue(0, "ARC")
				};
				if (message.Trim() == "")
				{
					message = "Select arcs";
				}
				break;
			case CommandLineQuerries.EntityType.POINT:
				array = new TypedValue[]
				{
					new TypedValue(0, "POINT")
				};
				if (message.Trim() == "")
				{
					message = "Select points";
				}
				break;
			case CommandLineQuerries.EntityType.LINE:
				array = new TypedValue[]
				{
					new TypedValue(0, "LINE")
				};
				if (message.Trim() == "")
				{
					message = "Select lines";
				}
				break;
			case CommandLineQuerries.EntityType.TEXT:
				array = new TypedValue[]
				{
					new TypedValue(0, "TEXT")
				};
				if (message.Trim() == "")
				{
					message = "Select texts";
				}
				break;
			case CommandLineQuerries.EntityType.CIRCLE:
				array = new TypedValue[]
				{
					new TypedValue(0, "CIRCLE")
				};
				if (message.Trim() == "")
				{
					message = "Select circles";
				}
				break;
			case CommandLineQuerries.EntityType.ELLIPSE:
				array = new TypedValue[]
				{
					new TypedValue(0, "ELLIPSE")
				};
				if (message.Trim() == "")
				{
					message = "Select ellipses";
				}
				break;
			case CommandLineQuerries.EntityType.FACE:
				array = new TypedValue[]
				{
					new TypedValue(0, "3DFACE")
				};
				if (message.Trim() == "")
				{
					message = "Select faces";
				}
				break;
			case CommandLineQuerries.EntityType.SPLINE:
				array = new TypedValue[]
				{
					new TypedValue(0, "SPLINE")
				};
				if (message.Trim() == "")
				{
					message = "Select splines";
				}
				break;
			case CommandLineQuerries.EntityType.PLINES:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "LWPOLYLINE"),
					new TypedValue(0, "POLYLINE2D"),
					new TypedValue(0, "POLYLINE3D"),
					new TypedValue(0, "POLYLINE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select polylines";
				}
				break;
			case CommandLineQuerries.EntityType.PLINE2D:
				array = new TypedValue[]
				{
					new TypedValue(0, "POLYLINE2D")
				};
				if (message.Trim() == "")
				{
					message = "Select 2d polylines";
				}
				break;
			case CommandLineQuerries.EntityType.PLINES2D:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "LWPOLYLINE"),
					new TypedValue(0, "POLYLINE2D"),
					new TypedValue(0, "POLYLINE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select 2d polylines";
				}
				break;
			case CommandLineQuerries.EntityType.PLINES3D:
				array = new TypedValue[]
				{
					new TypedValue(0, "POLYLINE3D")
				};
				if (message.Trim() == "")
				{
					message = "Select 3d polylines";
				}
				break;
			case CommandLineQuerries.EntityType.SOLID3D:
				array = new TypedValue[]
				{
					new TypedValue(0, "3DSOLID")
				};
				if (message.Trim() == "")
				{
					message = "Select 3d solids";
				}
				break;
			case CommandLineQuerries.EntityType.XML:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "POINT"),
					new TypedValue(0, "LINE"),
					new TypedValue(0, "3DFACE"),
					new TypedValue(0, "LWPOLYLINE"),
					new TypedValue(0, "POLYLINE2D"),
					new TypedValue(0, "POLYLINE3D"),
					new TypedValue(0, "POLYLINE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select objects";
				}
				break;
			case CommandLineQuerries.EntityType.ALL:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "ARC"),
					new TypedValue(0, "POINT"),
					new TypedValue(0, "LINE"),
					new TypedValue(0, "CIRCLE"),
					new TypedValue(0, "TEXT"),
					new TypedValue(0, "ELLIPSE"),
					new TypedValue(0, "SPLINE"),
					new TypedValue(0, "3DFACE"),
					new TypedValue(0, "LWPOLYLINE"),
					new TypedValue(0, "POLYLINE2D"),
					new TypedValue(0, "POLYLINE3D"),
					new TypedValue(0, "POLYLINE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select objects";
				}
				break;
			case CommandLineQuerries.EntityType.ArcLineTextCircleEllipseFaceSplinePline:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "ARC"),
					new TypedValue(0, "LINE"),
					new TypedValue(0, "CIRCLE"),
					new TypedValue(0, "TEXT"),
					new TypedValue(0, "ELLIPSE"),
					new TypedValue(0, "SPLINE"),
					new TypedValue(0, "3DFACE"),
					new TypedValue(0, "LWPOLYLINE"),
					new TypedValue(0, "POLYLINE2D"),
					new TypedValue(0, "POLYLINE3D"),
					new TypedValue(0, "POLYLINE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select objects";
				}
				break;
			case CommandLineQuerries.EntityType.ArcTextCircleEllipseFaceSpline:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "ARC"),
					new TypedValue(0, "CIRCLE"),
					new TypedValue(0, "TEXT"),
					new TypedValue(0, "ELLIPSE"),
					new TypedValue(0, "SPLINE"),
					new TypedValue(0, "3DFACE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select objects";
				}
				break;
			case CommandLineQuerries.EntityType.ArcCircleEllipse:
				array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(0, "ARC"),
					new TypedValue(0, "CIRCLE"),
					new TypedValue(0, "ELLIPSE"),
					new TypedValue(-4, "or>")
				};
				if (message.Trim() == "")
				{
					message = "Select objects";
				}
				break;
			}
			PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
			promptSelectionOptions.MessageForAdding=(message);
			if (singleOnly)
			{
				promptSelectionOptions.SingleOnly=(true);
			}
			promptSelectionOptions.AllowDuplicates=(false);
			PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, new SelectionFilter(array));
            if (selection.Status == (PromptStatus) (- 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (selection.Status != (PromptStatus)5100)
			{
				return null;
			}
			return selection.Value.GetObjectIds();
		}

		public static string InsertOnLayer_Current_Face_Elevation_Index(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Insert on layer");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Current");
			promptKeywordOptions.Keywords.Add("F", "F", "by Face");
			promptKeywordOptions.Keywords.Add("E", "E", "by Elevation");
			promptKeywordOptions.Keywords.Add("I", "I", "by Index");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string InsertOnLayer_Current_Face_Line(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Insert on layer");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Current");
			promptKeywordOptions.Keywords.Add("F", "F", "by Face");
			promptKeywordOptions.Keywords.Add("L", "L", "by Line");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string InsertOnLayer_Current_Face_Point(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Insert on layer");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Current");
			promptKeywordOptions.Keywords.Add("F", "F", "by Face");
			promptKeywordOptions.Keywords.Add("P", "P", "by Point");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string InsertOnLayer_Current_Line(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Insert on layer");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Current");
			promptKeywordOptions.Keywords.Add("L", "L", "by Line");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string InsertOnLayer_Current_Name(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Insert on layer");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Current");
			promptKeywordOptions.Keywords.Add("N", "N", "specify Name");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string InsertOnLayer_Current_Name_STL(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Insert on layer");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Current");
			promptKeywordOptions.Keywords.Add("N", "N", "specify Name");
			promptKeywordOptions.Keywords.Add("S", "S", "by STL");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string KeepIfMultiple(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Point to keep");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("H", "H", "Highest");
			promptKeywordOptions.Keywords.Add("L", "L", "Lowest");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string KeywordYesNo(string prompt, string defaultValue, bool allowArbitraryInput, bool allowNone)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + prompt);
			promptKeywordOptions.AllowNone=(allowNone);
			promptKeywordOptions.AllowArbitraryInput=(allowArbitraryInput);
			promptKeywordOptions.Keywords.Add("Y", "Y", "Yes");
			promptKeywordOptions.Keywords.Add("N", "N", "No");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static ObjectId LayerSelectionDialog()
		{
			CommandLineQuerries.SelectedInsertOnLayer = CommandLineQuerries.InsertOnLayer_Current_Name(CommandLineQuerries.SelectedInsertOnLayer);
			if (CommandLineQuerries.SelectedInsertOnLayer == "N")
			{
				CommandLineQuerries.SelectedLayerName = CommandLineQuerries.SpecifyLayerName(CommandLineQuerries.SelectedLayerName);
				bool flag = false;
				return DBManager.CreateLayer(CommandLineQuerries.SelectedLayerName, 7, false, ref flag);
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId clayer;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(workingDatabase.Clayer, (OpenMode)0);
				CommandLineQuerries.SelectedLayerName = layerTableRecord.Name;
				clayer = workingDatabase.Clayer;
			}
			return clayer;
		}

		public static void OnCancelled()
		{
            throw new System.Exception("Command cancelled by user.");
		}

		public static void OnNotOK()
		{
            throw new System.Exception("Command aborted due to bad prompt result.");
		}

		public static ObjectId[] SelectFaces(bool singleOnly)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.FACE, "Select faces", singleOnly);
			if (objectIDs == null)
			{
				throw new ArgumentException("No faces selected.");
			}
			editor.WriteMessage(Environment.NewLine + objectIDs.Length + " faces selected.");
			return objectIDs;
		}

		public static ObjectId[] SelectLines(bool singleOnly)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.LINE, "Select lines", singleOnly);
			if (objectIDs == null)
			{
				throw new ArgumentException("No lines selected.");
			}
			editor.WriteMessage(Environment.NewLine + objectIDs.Length + " lines selected.");
			return objectIDs;
		}

		public static ObjectId[] SelectPoints(bool singleOnly)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.POINT, "Select points", singleOnly);
			if (objectIDs == null)
			{
				throw new ArgumentException("No points selected.");
			}
			editor.WriteMessage(Environment.NewLine + objectIDs.Length + " points selected.");
			return objectIDs;
		}

		public static ObjectId[] SelectPolylines(bool singleOnly)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.PLINES, "Select polylines", singleOnly);
			if (objectIDs == null)
			{
				throw new ArgumentException("No polylines selected.");
			}
			editor.WriteMessage(Environment.NewLine + objectIDs.Length + " polylines selected.");
			return objectIDs;
		}

		private static string smethod_0(PromptStringOptions promptStringOptions_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptResult @string = editor.GetString(promptStringOptions_0);
            if (@string.Status == (PromptStatus)( - 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (@string.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return @string.StringResult;
		}

		private static string smethod_1(PromptKeywordOptions promptKeywordOptions_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptResult keywords = editor.GetKeywords(promptKeywordOptions_0);
            if (keywords.Status == ((PromptStatus)(-5002)))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (keywords.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return keywords.StringResult.ToUpper().Trim();
		}

		private static int smethod_2(PromptIntegerOptions promptIntegerOptions_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptIntegerResult integer = editor.GetInteger(promptIntegerOptions_0);
            if (integer.Status == (PromptStatus)( - 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (integer.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return integer.Value;
		}

		private static double smethod_3(PromptDoubleOptions promptDoubleOptions_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptDoubleResult @double = editor.GetDouble(promptDoubleOptions_0);
            if (@double.Status == (PromptStatus) (- 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (@double.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return @double.Value;
		}

		public static ObjectId[] smethod_4(bool singleOnly)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.XML, "Select objects", singleOnly);
			if (objectIDs == null)
			{
				throw new ArgumentException("No entities selected.");
			}
			editor.WriteMessage(Environment.NewLine + objectIDs.Length + " entities selected.");
			return objectIDs;
		}

		public static CoordinateSystem Specify2PDirection()
		{
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Point3d basePoint = CommandLineQuerries.SpecifyPoint("Specify first point");
			Point3d point3d = CommandLineQuerries.SpecifyPointWithBasepoint("Specify second point", basePoint);
			Point point = new Point(basePoint.X, basePoint.Y, basePoint.Z);
			Point point2 = new Point(point3d.X, point3d.Y, point3d.Z);
			CoordinateSystem uCS = Conversions.GetUCS();
			CoordinateSystem newCS = CoordinateSystem.Global();
			if (!Conversions.IsWCS(uCS))
			{
				point = point.TransformCoordinates(uCS, newCS);
				point2 = point2.TransformCoordinates(uCS, newCS);
			}
            ngeometry.VectorGeometry.Vector3d normalVector = new ngeometry.VectorGeometry.Vector3d(point2 - point);
            ngeometry.VectorGeometry.Plane plane = new ngeometry.VectorGeometry.Plane(point, normalVector);
			CoordinateSystem coordinateSystem = new CoordinateSystem(plane);
			coordinateSystem.Orthonormalize();
			return coordinateSystem;
		}

		public static CoordinateSystem Specify3PSystem()
		{
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Point3d basePoint = CommandLineQuerries.SpecifyPoint("Specify origin point of plane");
			Point3d point3d = CommandLineQuerries.SpecifyPointWithBasepoint("Specify point on positive x-axis", basePoint);
			Point3d point3d2 = CommandLineQuerries.SpecifyPointWithBasepoint("Specify third point on plane", basePoint);
			Point point = new Point(basePoint.X, basePoint.Y, basePoint.Z);
			Point point2 = new Point(point3d.X, point3d.Y, point3d.Z);
			Point point3 = new Point(point3d2.X, point3d2.Y, point3d2.Z);
            ngeometry.VectorGeometry.Vector3d vector3d = new ngeometry.VectorGeometry.Vector3d(point2 - point);
            ngeometry.VectorGeometry.Vector3d a = new ngeometry.VectorGeometry.Vector3d(point3 - point);
			if (!vector3d.IsIndependentTo(a))
			{
                throw new System.Exception("Points are collinear or coincident.");
			}
			CoordinateSystem uCS = Conversions.GetUCS();
			CoordinateSystem newCS = CoordinateSystem.Global();
			if (!Conversions.IsWCS(uCS))
			{
				point = point.TransformCoordinates(uCS, newCS);
				point2 = point2.TransformCoordinates(uCS, newCS);
				point3 = point3.TransformCoordinates(uCS, newCS);
			}
            ngeometry.VectorGeometry.Plane plane = new ngeometry.VectorGeometry.Plane(point, point2, point3);
			CoordinateSystem coordinateSystem = new CoordinateSystem(plane);
			coordinateSystem.Orthonormalize();
			return coordinateSystem;
		}

		public static string SpecifyBlockName(string defaultValue)
		{
			string text = defaultValue;
			bool flag = false;
			while (!flag)
			{
				PromptStringOptions promptStringOptions = new PromptStringOptions(Environment.NewLine + "Specify block name");
				promptStringOptions.AllowSpaces=(true);
				promptStringOptions.DefaultValue=(defaultValue);
				text = CommandLineQuerries.smethod_0(promptStringOptions);
				if (text == SymbolUtilityServices.BlockModelSpaceName)
				{
					return text;
				}
				flag = DBManager.ValidateName(text);
			}
			return text;
		}

		public static int SpecifyColumnWidth(int defaultValue)
		{
			PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions(Environment.NewLine + "Specify column width or");
			promptIntegerOptions.UpperLimit=(256);
			promptIntegerOptions.AllowArbitraryInput=(false);
			promptIntegerOptions.AllowNegative=(false);
			promptIntegerOptions.AllowNone=(false);
			promptIntegerOptions.AllowZero=(false);
			promptIntegerOptions.Keywords.Add("F", "F", "Fit");
			promptIntegerOptions.DefaultValue=(defaultValue);
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptIntegerResult integer = editor.GetInteger(promptIntegerOptions);
            if (integer.Status == (PromptStatus) (- 5005))
			{
				return 0;
			}
            if (integer.Status == (PromptStatus) (- 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (integer.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return integer.Value;
		}

		public static int SpecifyDecimalDigits(int defaultValue)
		{
			PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions(Environment.NewLine + "Specify number of decimal digits or");
			promptIntegerOptions.UpperLimit=(16);
			promptIntegerOptions.AllowArbitraryInput=(false);
			promptIntegerOptions.AllowNegative=(false);
			promptIntegerOptions.AllowNone=(false);
			promptIntegerOptions.AllowZero=(true);
			promptIntegerOptions.Keywords.Add("F", "F", "Float");
			promptIntegerOptions.DefaultValue=(defaultValue);
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptIntegerResult integer = editor.GetInteger(promptIntegerOptions);
            if (integer.Status == (PromptStatus) (- 5005))
			{
				return -1;
			}
            if (integer.Status == (PromptStatus)( - 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (integer.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return integer.Value;
		}

		public static string SpecifyDelimiter(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify delimiter");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.Keywords.Add("C", "C", "Comma");
			promptKeywordOptions.Keywords.Add("S", "S", "Semicolon");
			promptKeywordOptions.Keywords.Add("B", "B", "Blank");
			promptKeywordOptions.Keywords.Add("T", "T", "Tabstop");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static double SpecifyDouble(string prompt, double defaultValue, bool allowArbitraryInput, bool allowNegative, bool allowNone, bool allowZero)
		{
			PromptDoubleOptions promptDoubleOptions = new PromptDoubleOptions(Environment.NewLine + prompt);
			promptDoubleOptions.AllowArbitraryInput=(allowArbitraryInput);
			promptDoubleOptions.AllowNegative=(allowNegative);
			promptDoubleOptions.AllowNone=(allowNone);
			promptDoubleOptions.AllowZero=(allowZero);
			promptDoubleOptions.DefaultValue=(defaultValue);
			return CommandLineQuerries.smethod_3(promptDoubleOptions);
		}

		public static string SpecifyEntitiesBySelectionOrByLayer(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify entities by");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("S", "S", "Selection");
			promptKeywordOptions.Keywords.Add("L", "L", "Layer");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyEntityType(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify entity type");
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.Keywords.Add("L", "L", "Lines");
			promptKeywordOptions.Keywords.Add("T", "T", "Texts");
			promptKeywordOptions.Keywords.Add("C", "C", "Circles");
			promptKeywordOptions.Keywords.Add("E", "E", "Ellipses");
			promptKeywordOptions.Keywords.Add("A", "A", "Arcs");
			promptKeywordOptions.Keywords.Add("S", "S", "Splines");
			promptKeywordOptions.Keywords.Add("F", "F", "3dFaces");
			promptKeywordOptions.Keywords.Add("P", "P", "Polylines");
			promptKeywordOptions.Keywords.Add("ALL", "ALL", "ALL");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyFileName(string defaultValue)
		{
			PromptStringOptions promptStringOptions = new PromptStringOptions(Environment.NewLine + "Specify file name");
			promptStringOptions.AllowSpaces=(true);
			promptStringOptions.DefaultValue=(defaultValue);
			return CommandLineQuerries.smethod_0(promptStringOptions);
		}

		public static void SpecifyFileNameForRead(ref string defaultName, string defaultExtension)
		{
			string text = "";
			if (defaultExtension == "*")
			{
				text = "All files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "XYZ")
			{
				text = "Point coordinate files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "3DF")
			{
				text = "Face format files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "XML")
			{
				text = "XML files (*.";
			}
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            int num = Convert.ToInt32(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("FILEDIA"));
			bool flag = true;
			if (num == 0)
			{
				flag = false;
			}
			bool flag2 = false;
			while (!flag2)
			{
				if (flag)
				{
					PromptOpenFileOptions promptOpenFileOptions = new PromptOpenFileOptions("Select file");
					promptOpenFileOptions.AllowUrls=(false);
					try
					{
						promptOpenFileOptions.InitialDirectory=(new FileInfo(defaultName).DirectoryName);
						goto IL_134;
					}
					catch
					{
						promptOpenFileOptions.InitialDirectory=(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
						goto IL_134;
					}
					goto IL_DD;
					IL_E2:
					PromptResult fileNameForOpen;
                    if (fileNameForOpen.Status != (PromptStatus)5100)
					{
						CommandLineQuerries.OnNotOK();
					}
					defaultName = fileNameForOpen.StringResult;
					goto IL_109;
					IL_DD:
					CommandLineQuerries.OnCancelled();
					goto IL_E2;
					IL_134:
					promptOpenFileOptions.DialogCaption=("Select file");
					promptOpenFileOptions.Filter=(string.Concat(new string[]
					{
						text,
						defaultExtension,
						")|*.",
						defaultExtension,
						"| All files (*.*)|*.*"
					}));
					promptOpenFileOptions.InitialFileName=(new FileInfo(defaultName).Name);
					fileNameForOpen = editor.GetFileNameForOpen(promptOpenFileOptions);
					if (fileNameForOpen.Status ==(PromptStatus) (-5002))
					{
						goto IL_DD;
					}
					goto IL_E2;
				}
				else
				{
					defaultName = CommandLineQuerries.SpecifyFileName(defaultName);
				}
				IL_109:
				if (!File.Exists(defaultName))
				{
					editor.WriteMessage(Environment.NewLine + "File does not exist.");
				}
				else
				{
					flag2 = true;
				}
			}
		}

		public static void SpecifyFileNameForWrite(ref string defaultName, ref string overwriteIfExists, string defaultExtension)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			string str = "";
			if (defaultExtension == "*")
			{
				str = "All files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "XYZ")
			{
				str = "Point coordinate files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "3DF")
			{
				str = "Face format files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "XML")
			{
				str = "XML files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "DWG")
			{
				str = "DWG files (*.";
			}
			if (defaultExtension.ToUpper().Trim() == "DXF")
			{
				str = "DXF files (*.";
			}
            int num = Convert.ToInt32(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("FILEDIA"));
			bool flag = true;
			if (num == 0)
			{
				flag = false;
			}
			bool flag2 = false;
			while (!flag2)
			{
				if (flag)
				{
					PromptSaveFileOptions promptSaveFileOptions = new PromptSaveFileOptions("Save As");
					promptSaveFileOptions.AllowUrls=(false);
					try
					{
						promptSaveFileOptions.InitialDirectory=(new FileInfo(defaultName).DirectoryName);
						goto IL_1BB;
					}
					catch
					{
						promptSaveFileOptions.InitialDirectory=(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
						goto IL_1BB;
					}
					goto IL_11D;
					IL_122:
					PromptResult fileNameForSave;
                    if (fileNameForSave.Status != (PromptStatus)5100)
					{
						CommandLineQuerries.OnNotOK();
					}
					defaultName = fileNameForSave.StringResult;
					flag2 = true;
					continue;
					IL_11D:
					CommandLineQuerries.OnCancelled();
					goto IL_122;
					IL_1BB:
					promptSaveFileOptions.DialogCaption=("Save As");
					promptSaveFileOptions.Filter=(str + defaultExtension + ")|*." + defaultExtension);
					promptSaveFileOptions.InitialFileName=(new FileInfo(defaultName).Name);
					fileNameForSave = editor.GetFileNameForSave(promptSaveFileOptions);
                    if (fileNameForSave.Status == (PromptStatus) (- 5002))
					{
						goto IL_11D;
					}
					goto IL_122;
				}
				else
				{
					defaultName = CommandLineQuerries.SpecifyFileName(defaultName);
					FileInfo fileInfo = new FileInfo(defaultName);
					DirectoryInfo directory = fileInfo.Directory;
					if (!directory.Exists)
					{
						editor.WriteMessage(Environment.NewLine + "Directory does not exist.");
					}
					else if (File.Exists(defaultName))
					{
						overwriteIfExists = CommandLineQuerries.KeywordYesNo("File already exists. Overwrite", overwriteIfExists, false, false);
						if (overwriteIfExists == "Y")
						{
							flag2 = true;
						}
					}
					else
					{
						flag2 = true;
					}
				}
			}
		}

		public static int SpecifyInteger(string prompt, int defaultValue, int lowerLimit, int upperLimit, bool allowNegative, bool allowZero)
		{
			PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions(Environment.NewLine + prompt);
			promptIntegerOptions.DefaultValue=(defaultValue);
			promptIntegerOptions.LowerLimit=(lowerLimit);
			promptIntegerOptions.UpperLimit=(upperLimit);
			promptIntegerOptions.AllowNegative=(allowNegative);
			promptIntegerOptions.AllowZero=(allowZero);
			promptIntegerOptions.AllowArbitraryInput=(false);
			promptIntegerOptions.AllowNone=(false);
			return CommandLineQuerries.smethod_2(promptIntegerOptions);
		}

		public static string SpecifyLayerName(string defaultValue)
		{
			string text = defaultValue;
			bool flag = false;
			while (!flag)
			{
				PromptStringOptions promptStringOptions = new PromptStringOptions(Environment.NewLine + "Specify layer name");
				promptStringOptions.AllowSpaces=(true);
				promptStringOptions.DefaultValue=(defaultValue);
				text = CommandLineQuerries.smethod_0(promptStringOptions);
				flag = DBManager.ValidateName(text);
			}
			return text;
		}

		public static string SpecifyOperator(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify operator");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add(">", ">", ">");
			promptKeywordOptions.Keywords.Add("<", "<", "<");
			promptKeywordOptions.Keywords.Add("<=", "<=", "<=");
			promptKeywordOptions.Keywords.Add(">=", ">=", ">=");
			promptKeywordOptions.Keywords.Add("=", "=", "=");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyOutfileType(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify outfile type");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("DWG", "DWG", "DWG");
			promptKeywordOptions.Keywords.Add("DXF", "DXF", "DXF");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyOutputType(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify output entity type");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("A", "A", "All");
			promptKeywordOptions.Keywords.Add("T", "T", "Triangles only");
			promptKeywordOptions.Keywords.Add("Q", "Q", "Quads only");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static Point3d SpecifyPoint(string prompt)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointOptions promptPointOptions = new PromptPointOptions(Environment.NewLine + prompt);
			promptPointOptions.AllowNone=(false);
			promptPointOptions.AllowArbitraryInput=(false);
			PromptPointResult point = editor.GetPoint(promptPointOptions);
            if (point.Status == (PromptStatus) (- 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (point.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return point.Value;
		}

		public static string SpecifyPointGenerationMethod(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify point generation method");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.Keywords.Add("R", "R", "Raster");
			promptKeywordOptions.Keywords.Add("S", "S", "entity Selection");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static PromptPointResult SpecifyPointOrKeepBothSides()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointOptions promptPointOptions = new PromptPointOptions(Environment.NewLine + "Specify point on side to keep or");
			promptPointOptions.AllowNone=(false);
			promptPointOptions.UseDashedLine=(false);
			promptPointOptions.UseBasePoint=(false);
			promptPointOptions.AllowArbitraryInput=(false);
			promptPointOptions.Keywords.Add("B", "B", "keep Both sides");
			promptPointOptions.Keywords.Default=("B");
			promptPointOptions.AppendKeywordsToMessage=(true);
			return editor.GetPoint(promptPointOptions);
		}

		public static Point3d SpecifyPointWithBasepoint(string prompt, Point3d basePoint)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointOptions promptPointOptions = new PromptPointOptions(Environment.NewLine + prompt);
			promptPointOptions.UseDashedLine=(true);
			promptPointOptions.BasePoint=(basePoint);
			promptPointOptions.UseBasePoint=(true);
			promptPointOptions.AllowNone=(false);
			promptPointOptions.AllowArbitraryInput=(false);
			PromptPointResult corner = editor.GetCorner(promptPointOptions);
			promptPointOptions.UseDashedLine=(false);
			promptPointOptions.UseBasePoint=(false);
            if (corner.Status == (PromptStatus)( - 5002))
			{
				CommandLineQuerries.OnCancelled();
			}
            if (corner.Status != (PromptStatus)5100)
			{
				CommandLineQuerries.OnNotOK();
			}
			return corner.Value;
		}

		public static string SpecifyPrefixString(string defaultValue)
		{
			string text = defaultValue;
			bool flag = false;
			while (!flag)
			{
				PromptStringOptions promptStringOptions = new PromptStringOptions(Environment.NewLine + "Specify prefix string");
				promptStringOptions.AllowSpaces=(true);
				promptStringOptions.DefaultValue=(defaultValue);
				text = CommandLineQuerries.smethod_0(promptStringOptions);
				flag = DBManager.ValidateName(text);
			}
			return text;
		}

		public static string SpecifyProjectionDirection(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify projection direction");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("X", "X", "X");
			promptKeywordOptions.Keywords.Add("Y", "Y", "Y");
			promptKeywordOptions.Keywords.Add("Z", "Z", "Z");
			promptKeywordOptions.Keywords.Add("U", "U", "Ucs");
			promptKeywordOptions.Keywords.Add("2P", "2P", "2Points");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyRasterBySelectionOrByLayer(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify points by");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("S", "S", "Selection");
			promptKeywordOptions.Keywords.Add("L", "L", "Layer");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyReferencePlane(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify reference plane");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.Keywords.Add("W", "W", "Wcs");
			promptKeywordOptions.Keywords.Add("U", "U", "Ucs");
			promptKeywordOptions.Keywords.Add("3P", "3P", "3Point");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifySTLType(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify STL type");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("B", "B", "Binary");
			promptKeywordOptions.Keywords.Add("A", "A", "Ascii");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static string SpecifyString(string message, string defaultValue, bool allowSpaces)
		{
			PromptStringOptions promptStringOptions = new PromptStringOptions(Environment.NewLine + message);
			promptStringOptions.AllowSpaces=(allowSpaces);
			promptStringOptions.DefaultValue=(defaultValue);
			return CommandLineQuerries.smethod_0(promptStringOptions);
		}

		public static string SpecifyTargetProperty(string defaultValue)
		{
			PromptKeywordOptions promptKeywordOptions = new PromptKeywordOptions(Environment.NewLine + "Specify target property");
			promptKeywordOptions.AllowNone=(false);
			promptKeywordOptions.AllowArbitraryInput=(false);
			promptKeywordOptions.Keywords.Add("AR", "AR", "ARea");
			promptKeywordOptions.Keywords.Add("CZ", "CZ", "Center Z");
			promptKeywordOptions.Keywords.Add("AN", "AN", "minimum ANgle");
			promptKeywordOptions.Keywords.Add("MINZ", "MINZ", "MINimumZ");
			promptKeywordOptions.Keywords.Add("MAXZ", "MAXZ", "MAXimumZ");
			promptKeywordOptions.Keywords.Default=(defaultValue);
			return CommandLineQuerries.smethod_1(promptKeywordOptions);
		}

		public static bool IsNewBlock;

		public static string SelectedBlockName;

		public static string SelectedInsertAsBlock;

		public static string SelectedInsertOnLayer;

		public static string SelectedLayerName;

		public enum EntityType
		{
			ARC,
			POINT,
			LINE,
			TEXT,
			CIRCLE,
			ELLIPSE,
			FACE,
			SPLINE,
			PLINES,
			PLINE2D,
			PLINES2D,
			PLINES3D,
			SOLID3D,
			XML,
			ALL,
			ArcLineTextCircleEllipseFaceSplinePline,
			ArcTextCircleEllipseFaceSpline,
			ArcCircleEllipse,
            Region
		}
	}
}
