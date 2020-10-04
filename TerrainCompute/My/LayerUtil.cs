using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
namespace TerrainComputeC.My
{
    public class LayerUtil
    {
        public static string contourLayerName(int resolution)
        {
            return UserCmd.contourLNPrefix + resolution;
        }
        public static bool hasName(string name)
        {
            Database workingDatabase = HostApplicationServices.WorkingDatabase;

            using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
            {
                LayerTable ltbl = transaction.GetObject(workingDatabase.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (ltbl.Has(name)) return true;
                
            }
            return false;
        }
        public static void setLayerProp(string name,bool isHidden)
        {
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            
            using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
            {
                LayerTable ltbl = transaction.GetObject(workingDatabase.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (!ltbl.Has(name)) return;
                ObjectId lyrId = ltbl[name];
                LayerTableRecord ltr = (LayerTableRecord)transaction.GetObject(lyrId, OpenMode.ForWrite);
                if (ltr!=null)
                {
                    ltr.IsOff = isHidden;
                }
                transaction.Commit();
            }
            return;
        }

        public static ObjectId CreateLayer(string name, short color, bool isFrozen)
        {
            bool inc = true;
            return DBManager.CreateLayer(name,color,isFrozen,ref inc);
        }
        public static ObjectId CreateLayer(string name, short color, bool isOff, bool isFrozen)
        {
            bool nc=true;
            return CreateLayer(name, color, isOff, isFrozen, ref nc);
        }
        public static ObjectId CreateLayer(string name, short color, bool isOff,bool isFrozen, ref bool isNewlyCreated)
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
                    layerTableRecord.Name = (name);
                    layerTableRecord.Color = (Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci, color));
                    layerTableRecord.IsFrozen = (isFrozen);
                    layerTableRecord.IsOff = isOff;
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

    }
}
