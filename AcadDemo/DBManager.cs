using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace AcadUtil
{
    public class DBManager
    {
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


        public static ObjectId CreateLayer(string name, short color, bool isFrozen, ref bool isNewlyCreated)
        {
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            return CreateLayer(name, color, isFrozen, ref isNewlyCreated, workingDatabase);
        }

        public static ObjectId CreateLayer(string name, short color, bool isFrozen, ref bool isNewlyCreated, Database db)
        {
            Color c = Autodesk.AutoCAD.Colors.Color.FromColorIndex((ColorMethod.ByAci), color);
            return CreateLayer(name, c, isFrozen, ref isNewlyCreated, db);
        }

        public static ObjectId CreateLayer(string name, Color color, bool isFrozen, ref bool isNewlyCreated, Database db)
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
                    layerTableRecord.Name = (name);
                    layerTableRecord.Color = color;
                    layerTableRecord.IsFrozen = (isFrozen);
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

        public static void EraseObjects(ObjectId[] idArray)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            
            try
            {
                using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
                {
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        Entity entity = (Entity)idArray[i].GetObject((OpenMode.ForWrite));
                        if (!entity.IsErased)
                        {
                            entity.Erase();
                        }                        
                    }
                    transaction.Commit();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
