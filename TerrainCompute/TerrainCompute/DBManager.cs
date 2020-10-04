using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
using TerrainComputeC.BASE;
using TerrainComputeC.XML;

namespace TerrainComputeC
{	
	public class DBManager
	{
		static DBManager()
		{
			DBManager.selectedOnLayer = "C";
			DBManager.selectedLayerName = "0";
			DBManager.selectedAsBlock = "N";
			DBManager.selectedBlockName = "CCAD.DefaultBlock";
		}

		public DBManager()
		{
           
		}

		public static ObjectId CreateBlock(string name, ref bool isNewlyCreated)
		{
			if (!DBManager.ValidateName(name))
			{
				return ObjectId.Null;
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
				ObjectId objectId;
				if (!blockTable.Has(name))
				{
					BlockTableRecord blockTableRecord = new BlockTableRecord();
					blockTableRecord.Name=(name);
					blockTable.UpgradeOpen();
					objectId = blockTable.Add(blockTableRecord);
					transaction.AddNewlyCreatedDBObject(blockTableRecord, true);
					transaction.Commit();
					isNewlyCreated = true;
					ObjectId result = objectId;
					return result;
				}
				isNewlyCreated = false;
				objectId = blockTable[name];
				if (!objectId.IsErased)
				{
					ObjectId result = objectId;
					return result;
				}
				using (SymbolTableEnumerator enumerator = blockTable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (!current.IsErased)
						{
                            BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(current, (OpenMode)0, false);
							if (string.Compare(blockTableRecord2.Name, name, true) == 0)
							{
								ObjectId result = current;
								return result;
							}
						}
					}
				}
			}
			return ObjectId.Null;
		}

		public static ObjectId CreateLayer(string name, short color, bool isFrozen, ref bool isNewlyCreated)
		{
			if (!DBManager.ValidateName(name))
			{
				return ObjectId.Null;
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                LayerTable layerTable = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0, true);
				ObjectId objectId;
				if (!layerTable.Has(name))
				{
					LayerTableRecord layerTableRecord = new LayerTableRecord();
					layerTableRecord.Name=(name);
                    layerTableRecord.Color = (Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci, color));
					layerTableRecord.IsFrozen=(isFrozen);
					layerTable.UpgradeOpen();
					objectId = layerTable.Add(layerTableRecord);
					transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
					transaction.Commit();
					isNewlyCreated = true;
					ObjectId result = objectId;
					return result;
				}
				isNewlyCreated = false;
				objectId = layerTable[name];
				if (!objectId.IsErased)
				{
					ObjectId result = objectId;
					return result;
				}
				using (SymbolTableEnumerator enumerator = layerTable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (!current.IsErased)
						{
                            LayerTableRecord layerTableRecord2 = (LayerTableRecord)transaction.GetObject(current, (OpenMode)0, false);
							if (string.Compare(layerTableRecord2.Name, name, true) == 0)
							{
								ObjectId result = current;
								return result;
							}
						}
					}
				}
			}
			return ObjectId.Null;
		}

		public static ObjectId CreateLayer(string name, short color, bool isFrozen, ref bool isNewlyCreated, Database db)
		{
			if (!DBManager.ValidateName(name))
			{
				return ObjectId.Null;
			}
			using (Transaction transaction = db.TransactionManager.StartTransaction())
			{
                LayerTable layerTable = (LayerTable)transaction.GetObject(db.LayerTableId, (OpenMode)0, true);
				ObjectId objectId;
				if (!layerTable.Has(name))
				{
					LayerTableRecord layerTableRecord = new LayerTableRecord();
					layerTableRecord.Name=(name);
                    layerTableRecord.Color=(Autodesk.AutoCAD.Colors.Color.FromColorIndex((ColorMethod)195, color));
					layerTableRecord.IsFrozen=(isFrozen);
					layerTable.UpgradeOpen();
					objectId = layerTable.Add(layerTableRecord);
					transaction.AddNewlyCreatedDBObject(layerTableRecord, true);
					transaction.Commit();
					isNewlyCreated = true;
					ObjectId result = objectId;
					return result;
				}
				isNewlyCreated = false;
				objectId = layerTable[name];
				if (!objectId.IsErased)
				{
					ObjectId result = objectId;
					return result;
				}
				using (SymbolTableEnumerator enumerator = layerTable.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (!current.IsErased)
						{
                            LayerTableRecord layerTableRecord2 = (LayerTableRecord)transaction.GetObject(current, (OpenMode)0, false);
							if (string.Compare(layerTableRecord2.Name, name, true) == 0)
							{
								ObjectId result = current;
								return result;
							}
						}
					}
				}
			}
			return ObjectId.Null;
		}

		public static Autodesk.AutoCAD.DatabaseServices.Line CreateLine(Point3d startPoint, Point3d endPoint, ObjectId layerId, ObjectId blockId)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Autodesk.AutoCAD.DatabaseServices.Line line;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable arg_24_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockId, (OpenMode)1);
				line = new Autodesk.AutoCAD.DatabaseServices.Line(startPoint, endPoint);
                if (layerId != ObjectId.Null)
                {
                    line.LayerId=(layerId);
                }
				
				blockTableRecord.AppendEntity(line);
				transaction.AddNewlyCreatedDBObject(line, true);
				transaction.Commit();
			}
			return line;
		}

		public static DBPoint CreatePoint(Point3d point3d, ObjectId layerID, ObjectId blockID)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			DBPoint dBPoint = new DBPoint(point3d);
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				if (layerID != ObjectId.Null)
				{
					dBPoint.LayerId=(layerID);
				}
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
				if (blockID == ObjectId.Null)
				{
					blockID = blockTable[BlockTableRecord.ModelSpace];
				}
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockID, (OpenMode)1);
				blockTableRecord.AppendEntity(dBPoint);
				transaction.AddNewlyCreatedDBObject(dBPoint, true);
				transaction.Commit();
			}
			return dBPoint;
		}

        public static Autodesk.AutoCAD.DatabaseServices.Face CreateTriangularFace(Point3d point1, Point3d point2, Point3d point3, ObjectId layerID, ObjectId blockID)
		{
            Autodesk.AutoCAD.DatabaseServices.Face face = new Autodesk.AutoCAD.DatabaseServices.Face(point1, point2, point3, true, true, true, true);
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				if (layerID != ObjectId.Null)
				{
					face.LayerId=(layerID);
				}
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
				if (blockID == ObjectId.Null)
				{
					blockID = blockTable[BlockTableRecord.ModelSpace];
				}
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockID, (OpenMode)1);
				blockTableRecord.AppendEntity(face);
				transaction.AddNewlyCreatedDBObject(face, true);
				transaction.Commit();
			}
			return face;
		}

		public static ObjectId CurrentLayerId()
		{
			return HostApplicationServices.WorkingDatabase.Clayer;
		}

		public static string CurrentLayerName()
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId clayer = workingDatabase.Clayer;
			string name;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(clayer, (OpenMode)0);
				name = layerTableRecord.Name;
			}
			return name;
		}

		public static void EraseObjects(ObjectId[] idArray, int minEntitiesForProgress)
		{
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			MessageFilter messageFilter = new MessageFilter();
			System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			bool flag = idArray.Length > minEntitiesForProgress;
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(idArray.Length);
			if (flag)
			{
				progressMeter.Start("Erasing entities");
			}
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					for (int i = 0; i < idArray.Length; i++)
					{
						Entity entity = (Entity)idArray[i].GetObject((OpenMode)1);
						if (!entity.IsErased)
						{
							entity.Erase();
						}
						if (flag)
						{
							progressMeter.MeterProgress();
						}
						messageFilter.CheckMessageFilter((long)i, 1000);
					}
					transaction.Commit();
				}
				progressMeter.Stop();
			}
			catch
			{
				progressMeter.Stop();
				throw;
			}
		}

		public static bool ExistsLayer(string name)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			bool result;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                LayerTable layerTable = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0, true);
				if (layerTable.Has(name))
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public static ObjectId[] GetAllFaces()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[]
			{
				new TypedValue(-4, "<and"),
				new TypedValue(0, "3DFACE"),
				new TypedValue(-4, "and>")
			};
			PromptSelectionResult promptSelectionResult = editor.SelectAll(new SelectionFilter(array));
            if (promptSelectionResult.Status == (PromptStatus)5100)
			{
				return promptSelectionResult.Value.GetObjectIds();
			}
			return null;
		}

		public static ObjectId[] GetEntitiesOnLayer(string layerName)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[]
			{
				new TypedValue(8, layerName)
			};
			PromptSelectionResult promptSelectionResult = editor.SelectAll(new SelectionFilter(array));
            if (promptSelectionResult.Status == (PromptStatus)5100)
			{
				return promptSelectionResult.Value.GetObjectIds();
			}
			return null;
		}

		public static ObjectId[] GetFacesOnLayer(string layerName)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[]
			{
				new TypedValue(-4, "<and"),
				new TypedValue(8, layerName),
				new TypedValue(0, "3DFACE"),
				new TypedValue(-4, "and>")
			};
			PromptSelectionResult promptSelectionResult = editor.SelectAll(new SelectionFilter(array));
            if (promptSelectionResult.Status == (PromptStatus)5100)
			{
				return promptSelectionResult.Value.GetObjectIds();
			}
			return null;
		}

		public static string GetFormatFromLUPREC()
		{
			int num = (int)Convert.ToInt16(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("LUPREC").ToString());
			string text = "0.".PadRight(num + 2, '0');
			Global.StringNumberFormat = text;
			return text;
		}

		public static ObjectId GetLayerId(string lName, short colorIndex, LayerTable lt)
		{
			bool flag = false;
			ObjectId result;
			if (!lt.Has(lName))
			{
				result = DBManager.CreateLayer(lName, colorIndex, false, ref flag);
			}
			else
			{
				result = lt[lName];
				if (result.IsErased)
				{
					result = DBManager.CreateLayer(lName, colorIndex, false, ref flag);
				}
			}
			return result;
		}

		public static string GetLayerName(ObjectId layerId)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			string name;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(layerId, (OpenMode)0);
				name = layerTableRecord.Name;
			}
			return name;
		}

		public static string GetLayerNameOfEntity(ObjectId entityId)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			string layerName;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                Entity entity = (Entity)transaction.GetObject(entityId, (OpenMode)0);
				layerName = DBManager.GetLayerName(entity.LayerId);
			}
			return layerName;
		}

		public Point3d GetPointFromObjectID(ObjectId id)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			DBPoint dBPoint = null;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                dBPoint = (DBPoint)transaction.GetObject(id, (OpenMode)0, true);
			}
			return new Point3d(dBPoint.Position.X, dBPoint.Position.Y, dBPoint.Position.Z);
		}

		public static ObjectId[] GetPointsOnLayer(string layerName)
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[]
			{
				new TypedValue(-4, "<and"),
				new TypedValue(8, layerName),
				new TypedValue(0, "POINT"),
				new TypedValue(-4, "and>")
			};
			PromptSelectionResult promptSelectionResult = editor.SelectAll(new SelectionFilter(array));
            if (promptSelectionResult.Status == (PromptStatus)5100)
			{
				return promptSelectionResult.Value.GetObjectIds();
			}
			return null;
		}

		public static ObjectId InsertBlock(Point3d insertionPoint, ObjectId layerId, ObjectId insertBlockId)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			BlockReference blockReference;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
				blockReference = new BlockReference(insertionPoint, insertBlockId);
				if (layerId != ObjectId.Null)
				{
					blockReference.LayerId=(layerId);
				}
				blockTableRecord.AppendEntity(blockReference);
				transaction.AddNewlyCreatedDBObject(blockReference, true);
				transaction.Commit();
			}
			return blockReference.ObjectId;
		}

		public static ObjectId ModelSpaceId()
		{
			return SymbolUtilityServices.GetBlockModelSpaceId(HostApplicationServices.WorkingDatabase);
		}

		public static string ModelSpaceName()
		{
			return SymbolUtilityServices.BlockModelSpaceName;
		}

		public static void SaveDrawing(Database db, string fileName, string fileType, DwgVersion version)
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			DocumentCollection documentManager =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
			foreach (Document document in documentManager)
			{
				if (document.Name == fileName)
				{
					editor.WriteMessage("\nDrawing " + fileName + " is currently in use.");
					Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Drawing " + fileName + " is currently in use.");
					return;
				}
			}
			try
			{
				if (fileType != null)
				{
					if (!(fileType == "DWG"))
					{
						if (!(fileType == "DXF"))
						{
							goto IL_C3;
						}
						db.DxfOut(fileName, 8, version);
					}
					else
					{
						db.SaveAs(fileName, version);
					}
					return;
				}
				IL_C3:
				throw new NotImplementedException("Only .dwg and .dxf format supported.");
			}
			catch (System.Exception ex)
			{
				editor.WriteMessage(string.Concat(new string[]
				{
					Environment.NewLine,
					"Can not save file ",
					fileName,
					": ",
					ex.Message,
					Environment.NewLine
				}));
				Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Can not save file " + fileName + ": " + ex.Message);
			}
		}

		public static int SetEpsilon()
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Point3d extmin = workingDatabase.Extmin;
			Point3d extmax = workingDatabase.Extmax;
			double num = Math.Max(Math.Abs(extmin.X), Math.Abs(extmax.X));
			double val = Math.Max(Math.Abs(extmin.Y), Math.Abs(extmax.Y));
			double num2 = Math.Max(num, val);
			double num3 = 0.0;
			if (num == 0.0)
			{
				num3 = 0.0;
			}
			else if (num2 < 1.0)
			{
				while (num2 < 1.0)
				{
					num2 *= 10.0;
					num3 -= 1.0;
				}
				num3 = Math.Min(num3 + 2.0, 0.0);
			}
			else
			{
				while (num2 > 1.0)
				{
					num2 *= 0.1;
					num3 += 1.0;
				}
				num3 = Math.Max(num3 - 2.0, 0.0);
			}
			double num4 = Math.Pow(10.0, num3);
			Global.AbsoluteEpsilon = 1E-12 * num4;
			Global.RelativeEpsilon = Global.AbsoluteEpsilon;
			return (int)(12.0 - Math.Abs(num3));
		}

		public static bool ValidateName(string name)
		{
			Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			bool result;
			try
			{
				SymbolUtilityServices.ValidateSymbolName(name, false);
				result = true;
			}
			catch
			{
				editor.WriteMessage("Name contains invalid symbols.\n");
				result = false;
			}
			return result;
		}

		public static void WriteEntityListInDatabase(EntityList entities)
		{
			if (entities != null && entities.Count != 0)
			{
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
				MessageFilter messageFilter = new MessageFilter();
				System.Windows.Forms.Application.AddMessageFilter(messageFilter);
				ProgressMeter progressMeter = new ProgressMeter();
				progressMeter.SetLimit(entities.Count);
				progressMeter.Start("Writing database");
				try
				{
					CoordinateTransformator coordinateTransformator = new CoordinateTransformator(Conversions.GetUCS(), CoordinateSystem.Global());
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
                        LayerTable lt = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
                        BlockTable arg_96_0 = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
						ObjectId blockModelSpaceId = SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockModelSpaceId, (OpenMode)1);
						for (int i = 0; i < entities.Points.Count; i++)
						{
                            global::TerrainComputeC.XML.Point point = entities.Points[i];
							coordinateTransformator.Transform(point);
							Entity entity = new DBPoint(new Point3d(point.X, point.Y, point.Z));
							entity.LayerId=(DBManager.GetLayerId(point.LayerName, point.ColorIndex, lt));
							entity.ColorIndex=((int)point.ColorIndex);
							blockTableRecord.AppendEntity(entity);
							transaction.AddNewlyCreatedDBObject(entity, true);
							messageFilter.CheckMessageFilter((long)i, 1000);
							progressMeter.MeterProgress();
						}
						for (int j = 0; j < entities.Lines.Count; j++)
						{
                            global::TerrainComputeC.XML.Line line = entities.Lines[j];
							coordinateTransformator.Transform(line);
							Entity entity2 = new Autodesk.AutoCAD.DatabaseServices.Line(new Point3d(line.StartVertex.X, line.StartVertex.Y, line.StartVertex.Z), new Point3d(line.EndVertex.X, line.EndVertex.Y, line.EndVertex.Z));
							entity2.LayerId=(DBManager.GetLayerId(line.LayerName, line.ColorIndex, lt));
							entity2.ColorIndex=((int)line.ColorIndex);
							blockTableRecord.AppendEntity(entity2);
							transaction.AddNewlyCreatedDBObject(entity2, true);
							messageFilter.CheckMessageFilter((long)j, 1000);
							progressMeter.MeterProgress();
						}
						for (int k = 0; k < entities.Polylines.Count; k++)
						{
							PolyLine polyLine = entities.Polylines[k];
							coordinateTransformator.Transform(polyLine);
							Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(polyLine.Vertices);
							Entity entity3 = new Polyline3d(0, point3dCollection, false);
							entity3.LayerId=(DBManager.GetLayerId(polyLine.LayerName, polyLine.ColorIndex, lt));
							entity3.ColorIndex=((int)polyLine.ColorIndex);
							blockTableRecord.AppendEntity(entity3);
							transaction.AddNewlyCreatedDBObject(entity3, true);
							messageFilter.CheckMessageFilter((long)k, 1000);
							progressMeter.MeterProgress();
						}
						for (int l = 0; l < entities.Faces.Count; l++)
						{
                            global::TerrainComputeC.XML.Face face = entities.Faces[l];
							coordinateTransformator.Transform(face);
							Point3d point3d=new Point3d(face.Vertex1.X, face.Vertex1.Y, face.Vertex1.Z);
							//point3d..ctor(face.Vertex1.X, face.Vertex1.Y, face.Vertex1.Z);
							Point3d point3d2=new Point3d(face.Vertex2.X, face.Vertex2.Y, face.Vertex2.Z);
							//point3d2..ctor(face.Vertex2.X, face.Vertex2.Y, face.Vertex2.Z);
							Point3d point3d3=new Point3d(face.Vertex3.X, face.Vertex3.Y, face.Vertex3.Z);
							//point3d3..ctor(face.Vertex3.X, face.Vertex3.Y, face.Vertex3.Z);
							Point3d point3d4=new Point3d(face.Vertex4.X, face.Vertex4.Y, face.Vertex4.Z);
							//point3d4..ctor(face.Vertex4.X, face.Vertex4.Y, face.Vertex4.Z);
							Entity entity4 = new Autodesk.AutoCAD.DatabaseServices.Face(point3d, point3d2, point3d3, point3d4, true, true, true, true);
							entity4.LayerId=(DBManager.GetLayerId(face.LayerName, face.ColorIndex, lt));
							entity4.ColorIndex=((int)face.ColorIndex);
							blockTableRecord.AppendEntity(entity4);
							transaction.AddNewlyCreatedDBObject(entity4, true);
							messageFilter.CheckMessageFilter((long)l, 1000);
							progressMeter.MeterProgress();
						}
						transaction.Commit();
					}
					progressMeter.Stop();
					editor.WriteMessage(Environment.NewLine + entities.Count.ToString() + " entities written to database.\n");
					return;
				}
				catch
				{
					progressMeter.Stop();
					throw;
				}
			}
			throw new System.Exception("No entities written in database.");
		}

		public static void WriteListInDatabase<T>(List<T> entities, CoordinateSystem acutalCS, DBManager.EntityPropertiesAssignment propertyAssignmentMethod, ObjectId layerID, ObjectId blockID)
		{
			if (entities != null && entities.Count != 0)
			{
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
				ProgressMeter progressMeter = new ProgressMeter();
				MessageFilter messageFilter = new MessageFilter();
				System.Windows.Forms.Application.AddMessageFilter(messageFilter);
				List<ngeometry.VectorGeometry.Point> list = new List<ngeometry.VectorGeometry.Point>();
				List<Edge> list2 = new List<Edge>();
				List<Triangle> list3 = new List<Triangle>();
				List<ObjectId> list4 = new List<ObjectId>();
				List<ObjectId> list5 = new List<ObjectId>();
				try
				{
					switch (propertyAssignmentMethod)
					{
					case DBManager.EntityPropertiesAssignment.const_0:
						layerID = SymbolUtilityServices.GetLayerZeroId(workingDatabase);
						blockID = SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
						break;
					case DBManager.EntityPropertiesAssignment.ByObjectID:
						if (layerID == ObjectId.Null)
						{
							throw new ArgumentException("No layer ID specified.");
						}
						if (blockID == ObjectId.Null)
						{
							throw new ArgumentException("No block ID specified.");
						}
						break;
					case DBManager.EntityPropertiesAssignment.ByDialog:
						layerID = CommandLineQuerries.LayerSelectionDialog();
						blockID = CommandLineQuerries.BlockSelectionDialog();
						break;
					default:
						throw new NotImplementedException("Layer and block assignment method not supported.");
					}
					DBManager.Enum1 @enum;
					if (typeof(T) == typeof(ngeometry.VectorGeometry.Point))
					{
						@enum = (DBManager.Enum1)0;
						list = (List<ngeometry.VectorGeometry.Point>)Convert.ChangeType(entities, typeof(List<ngeometry.VectorGeometry.Point>));
					}
					else if (typeof(T) == typeof(Edge))
					{
						@enum = (DBManager.Enum1)1;
						list2 = (List<Edge>)Convert.ChangeType(entities, typeof(List<Edge>));
					}
					else
					{
						if (typeof(T) != typeof(Triangle))
						{
							goto IL_6EB;
						}
						@enum = (DBManager.Enum1)2;
						list3 = (List<Triangle>)Convert.ChangeType(entities, typeof(List<Triangle>));
					}
					if (acutalCS != null)
					{
						switch (@enum)
						{
						case (DBManager.Enum1)0:
							Conversions.ToWCS(acutalCS, PointSet.ToPointSet(list));
							break;
						case (DBManager.Enum1)1:
							Conversions.ToWCS(acutalCS, list2);
							break;
						case (DBManager.Enum1)2:
							Conversions.ToWCS(acutalCS, list3);
							break;
						default:
							throw new NotImplementedException("Entity type transformation not supported: " + @enum.ToString());
						}
					}
					progressMeter.SetLimit(entities.Count);
					progressMeter.Start("Writing database");
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
                        LayerTable layerTable = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, (OpenMode)0);
                        BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockID, (OpenMode)1);
						for (int i = 0; i < entities.Count; i++)
						{
							Autodesk.AutoCAD.Colors.Color color = null;
							short colorIndex = 256;
							if (propertyAssignmentMethod == DBManager.EntityPropertiesAssignment.const_0)
							{
								CADData cADData = new CADData();
								switch (@enum)
								{
								case (DBManager.Enum1)0:
									cADData = list[i].CADData;
									break;
								case (DBManager.Enum1)1:
									cADData = list2[i].CADData;
									break;
								case (DBManager.Enum1)2:
									cADData = list3[i].CADData;
									break;
								default:
									throw new NotImplementedException("Entity type not supported: " + @enum.ToString());
								}
								if (cADData == null)
								{
									throw new InvalidOperationException("No CAD data available.");
								}
								if (cADData.Layer == null)
								{
									throw new InvalidOperationException("No CAD layer data available.");
								}
								string name = cADData.Layer.Name;
								if (!layerTable.Has(name))
								{
									bool flag = false;
									layerID = DBManager.CreateLayer(name, cADData.Layer.ColorIndex, cADData.Layer.IsFrozen, ref flag);
								}
								else
								{
									bool flag2 = false;
									layerID = layerTable[name];
									if (layerID.IsErased)
									{
										layerID = DBManager.CreateLayer(name, cADData.Layer.ColorIndex, cADData.Layer.IsFrozen, ref flag2);
									}
								}
								string blockName = cADData.BlockName;
								if (!blockTable.Has(blockName))
								{
									blockID = DBManager.CreateBlock(blockName, ref CommandLineQuerries.IsNewBlock);
									list4.Add(blockID);
									list5.Add(layerID);
								}
								else
								{
									blockID = blockTable[blockName];
									if (blockID.IsErased)
									{
										blockID = DBManager.CreateBlock(blockName, ref CommandLineQuerries.IsNewBlock);
									}
								}
								blockTableRecord = (BlockTableRecord)transaction.GetObject(blockID, (OpenMode)1);
								colorIndex = cADData.ColorIndex;
								if (cADData.Color !=System.Drawing.Color.Empty)
								{
									color =Autodesk.AutoCAD.Colors.Color.FromColor(cADData.Color);
								}
							}
							Entity entity = new Autodesk.AutoCAD.DatabaseServices.Line(new Point3d(0.0, 0.0, 0.0), new Point3d(0.0, 0.0, 0.0));
							switch (@enum)
							{
							case (DBManager.Enum1)0:
								entity = new DBPoint(new Point3d(list[i].X, list[i].Y, list[i].Z));
								break;
							case (DBManager.Enum1)1:
							{
								Edge edge = list2[i];
								Point3d point3d=new Point3d(edge.StartPoint.X, edge.StartPoint.Y, edge.StartPoint.Z);
								//point3d..ctor(edge.StartPoint.X, edge.StartPoint.Y, edge.StartPoint.Z);
								Point3d point3d2=new Point3d(edge.EndPoint.X, edge.EndPoint.Y, edge.EndPoint.Z);
								//point3d2..ctor(edge.EndPoint.X, edge.EndPoint.Y, edge.EndPoint.Z);
								entity = new Autodesk.AutoCAD.DatabaseServices.Line(point3d, point3d2);
								break;
							}
							case (DBManager.Enum1)2:
							{
								Point3d point3d3=new Point3d(list3[i].Vertex1.X, list3[i].Vertex1.Y, list3[i].Vertex1.Z);
								//point3d3..ctor(list3[i].Vertex1.X, list3[i].Vertex1.Y, list3[i].Vertex1.Z);
								Point3d point3d4=new Point3d(list3[i].Vertex2.X, list3[i].Vertex2.Y, list3[i].Vertex2.Z);
								//point3d4..ctor(list3[i].Vertex2.X, list3[i].Vertex2.Y, list3[i].Vertex2.Z);
								Point3d point3d5=new Point3d(list3[i].Vertex3.X, list3[i].Vertex3.Y, list3[i].Vertex3.Z);
								//point3d5..ctor(list3[i].Vertex3.X, list3[i].Vertex3.Y, list3[i].Vertex3.Z);
								entity = new Autodesk.AutoCAD.DatabaseServices.Face(point3d3, point3d4, point3d5, true, true, true, true);
								break;
							}
							default:
								throw new NotImplementedException("Entity type not supported: " + @enum.ToString());
							}
							entity.LayerId=(layerID);
							if (color == null)
							{
								entity.ColorIndex=((int)colorIndex);
							}
							else
							{
								entity.Color=(color);
							}
							blockTableRecord.AppendEntity(entity);
							transaction.AddNewlyCreatedDBObject(entity, true);
							progressMeter.MeterProgress();
							messageFilter.CheckMessageFilter((long)i, 10000);
						}
						if (propertyAssignmentMethod == DBManager.EntityPropertiesAssignment.const_0)
						{
							for (int j = 0; j < list4.Count; j++)
							{
								DBManager.InsertBlock(new Point3d(0.0, 0.0, 0.0), list5[j], list4[j]);
							}
						}
						else if (CommandLineQuerries.IsNewBlock)
						{
							DBManager.InsertBlock(new Point3d(0.0, 0.0, 0.0), layerID, blockID);
						}
						transaction.Commit();
						goto IL_70A;
					}
					goto IL_6EB;
					IL_70A:
					progressMeter.Stop();
					editor.WriteMessage(Environment.NewLine + entities.Count.ToString() + " entities written to database.");
					editor.WriteMessage("\n");
					editor.Regen();
					return;
					IL_6EB:
					throw new NotImplementedException("Generic list type not supported: " + typeof(T).ToString());
				}
				catch
				{
					progressMeter.Stop();
					throw;
				}
			}
			throw new System.Exception("No entities written in database.");
		}

		public static int WritePlinesInDataBase(List<Edge> unorderedEdges, CoordinateSystem userSystem, int relevantDecimals, bool eliminateZeroLength)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			Global.SuspendEpsilon(0.0, 0.0);
			if (userSystem != null)
			{
				Conversions.ToWCS(userSystem, unorderedEdges);
			}
			List<PLine> list = PLine.ConstructFromUnorderedSegments(unorderedEdges, relevantDecimals, ref num2, ref num, ref num3, false, false, eliminateZeroLength);
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
				for (int i = 0; i < list.Count; i++)
				{
					List<ngeometry.VectorGeometry.Point> points = list[i].GetVertices().ToList();
					Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(points);
					Polyline3d polyline3d = new Polyline3d(0, point3dCollection, false);
					bool flag = false;
					polyline3d.LayerId=(DBManager.CreateLayer(list[i].CADData.Layer.Name, 7, false, ref flag));
					if (list[i].CADData.Color !=System.Drawing.Color.Empty)
					{
						polyline3d.Color=(Autodesk.AutoCAD.Colors.Color.FromColor(list[i].CADData.Color));
					}
					else
					{
						polyline3d.ColorIndex=((int)list[i].CADData.ColorIndex);
					}
					blockTableRecord.AppendEntity(polyline3d);
					transaction.AddNewlyCreatedDBObject(polyline3d, true);
				}
				transaction.Commit();
			}
			Global.ResumeEpsilon();
			return list.Count;
		}

        public static List<PLine> WritePlinesInDataBase2(List<Edge> unorderedEdges, CoordinateSystem userSystem, int relevantDecimals, bool eliminateZeroLength, ObjectId layerId, System.Drawing.Color color,List<Polyline3d> pline3d)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            int num = 0;
            int num2 = 0;
            int num3 = 0; //pline3d = null;
            Global.SuspendEpsilon(0.0, 0.0);
            List<PLine> list = null;
            try
            {
                if (userSystem != null)
                {
                    Conversions.ToWCS(userSystem, unorderedEdges);
                }
                list=PLine.ConstructFromUnorderedSegments(unorderedEdges, relevantDecimals, ref num2, ref num, ref num3, false, false, eliminateZeroLength);
                using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
                {
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
                    for (int i = 0; i < list.Count; i++)
                    {
                        List<ngeometry.VectorGeometry.Point> points = list[i].GetVertices().ToList();
                        Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(points);
                        Polyline3d polyline3d = new Polyline3d(0, point3dCollection, false);
                        pline3d.Add( polyline3d);
                        bool flag = false;
                        polyline3d.LayerId = layerId;// (DBManager.CreateLayer(layerName, 7, false, ref flag));
                        
                        polyline3d.Color = Autodesk.AutoCAD.Colors.Color.FromColor(color);
                        if (((int)(polyline3d.StartPoint.Y * 100)) == 10485)
                        {

                        } if (((int)(polyline3d.EndPoint.Y * 100)) == 10485)
                        {

                        }
                        
                        blockTableRecord.AppendEntity(polyline3d);
                        transaction.AddNewlyCreatedDBObject(polyline3d, true);
                    }
                    transaction.Commit();
                }
            }
            catch (System.Exception ex)
            {

            }
            Global.ResumeEpsilon();
            
            return list;
        }

		public static void ZoomExtents()
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Point3d extmin = workingDatabase.Extmin;
			Point3d extmax = workingDatabase.Extmax;
			Point2d point2d=new Point2d(extmin.X, extmin.Y);
			//point2d..ctor(extmin.X, extmin.Y);
			Point2d point2d2=new Point2d(extmax.X, extmax.Y);
			//point2d2..ctor(extmax.X, extmax.Y);
			ViewTableRecord viewTableRecord = new ViewTableRecord();
			viewTableRecord.CenterPoint=(point2d + (point2d2 - point2d) / 2.0);
			viewTableRecord.Height=(point2d2.Y - point2d.Y);
			viewTableRecord.Width=(point2d2.X - point2d.X);
			editor.SetCurrentView(viewTableRecord);
		}

		public static void ZoomWindow(Point3d min, Point3d max)
		{
			Editor editor =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Point2d point2d=new Point2d(min.X, min.Y);
			//point2d..ctor(min.X, min.Y);
			Point2d point2d2=new Point2d(max.X, max.Y);
			//point2d2..ctor(max.X, max.Y);
			ViewTableRecord viewTableRecord = new ViewTableRecord();
			viewTableRecord.CenterPoint=(point2d + (point2d2 - point2d) / 2.0);
			viewTableRecord.Height=(point2d2.Y - point2d.Y);
			viewTableRecord.Width=(point2d2.X - point2d.X);
			editor.SetCurrentView(viewTableRecord);
		}

		public static string selectedAsBlock;

		public static string selectedBlockName;

		public static string selectedLayerName;

		public static string selectedOnLayer;

		public enum EntityPropertiesAssignment
		{
			const_0,
			ByObjectID,
			ByDialog
		}

		private enum Enum1
		{

		}
	}
}
