using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;
using TerrainComputeC.BASE;
using TerrainComputeC.XML;
namespace TerrainComputeC.My
{
    public class MyDBUtility
    {
        public enum EntityPropertiesAssignment
        {
            const_0,
            ByObjectID,
            ByDialog
        }
        private enum Enum1
        {

        }
        public static ObjectId? addPolyline(List<Point3d> plist,ObjectId layerId)
        {
            try
            {                
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;

                using (Transaction tran = acCurDb.TransactionManager.StartTransaction())
                    {
                        BlockTable bt = tran.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
                        BlockTableRecord modelSpace =tran.GetObject( bt[BlockTableRecord.ModelSpace],OpenMode.ForWrite) as BlockTableRecord;
                        Polyline2d b = new Polyline2d();
                        ObjectId oid= modelSpace.AppendEntity(b);
                        for (int i = 0; i < plist.Count; i++)
                        {
                            b.AppendVertex(new Vertex2d(plist[i], 0, 0, 0, 0));
                        }
                        b.Closed = true;
                        if (layerId != ObjectId.Null)
                        {
                            b.LayerId = layerId;
                        }
                        tran.AddNewlyCreatedDBObject(b,true);
                        tran.Commit();
                        return oid;
                    }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }


        public static ObjectId? addPolyline3d(List<Point3d> plist, ObjectId layerId,bool ifClosed=false)
        {
            try
            {
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;

                using (Transaction tran = acCurDb.TransactionManager.StartTransaction())
                {
                    BlockTable bt = tran.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord modelSpace = tran.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    Polyline3d b = new Polyline3d();
                    ObjectId oid = modelSpace.AppendEntity(b);
                    for (int i = 0; i < plist.Count; i++)
                    {
                        b.AppendVertex(new PolylineVertex3d(plist[i]));
                    }
                    b.Closed = ifClosed;
                    if (layerId != ObjectId.Null)
                    {
                        b.LayerId = layerId;
                    }
                    tran.AddNewlyCreatedDBObject(b, true);
                    tran.Commit();
                    return oid;
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static ObjectId? addPolyline3d(Polyline3d polyline, ObjectId layerId)
        {
            try
            {
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;

                using (Transaction tran = acCurDb.TransactionManager.StartTransaction())
                {
                    BlockTable bt = tran.GetObject(acCurDb.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord modelSpace = tran.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                    
                    ObjectId oid = modelSpace.AppendEntity(polyline);
                    
                    //b.Closed = true;
                    if (layerId != ObjectId.Null)
                    {
                        polyline.LayerId = layerId;
                    }
                    
                    tran.AddNewlyCreatedDBObject(polyline, true);
                    tran.Commit();
                    return oid;
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static List<LineSegment3d> getLines(ObjectId[] ids)
        {
            List<LineSegment3d> ll = new List<LineSegment3d>();
            try
            {
                PLDictionary plDic = new PLDictionary();
                // Get the current document and database
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;
                Editor ed = acDoc.Editor;
                // Start a transaction
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {                    
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if (ids[i].ObjectClass != RXClass.GetClass(typeof(Autodesk.AutoCAD.DatabaseServices.Line))) continue;
                        Autodesk.AutoCAD.DatabaseServices.Line line = acTrans.GetObject(ids[i], OpenMode.ForRead) as Autodesk.AutoCAD.DatabaseServices.Line;

                        ll.Add(new LineSegment3d(line.StartPoint, line.EndPoint));
                    }
                    ll = ll.Distinct(new My.CompareLineSegment3d()).ToList();// as 

                    acTrans.Commit();
                }
            }
            catch (System.Exception ex)
            {

            }
            return ll;
        }

        public static Autodesk.AutoCAD.DatabaseServices.DBObject getObject(Handle h){
            try
            {
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;
                Editor ed = acDoc.Editor;
                // Start a transaction
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    return acTrans.GetObject(acCurDb.GetObjectId(false, h, 0), OpenMode.ForRead, true);
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static Extents3d getExtents(ObjectId[] ids)
        {
            Extents3d r = new Extents3d();
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;
            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < ids.Length; i++)
                {                    
                    Autodesk.AutoCAD.DatabaseServices.DBObject obj = acTrans.GetObject(ids[i], OpenMode.ForRead);
                    Extents3d? ext= obj.Bounds;
                    if (ext != null)
                    {
                        r.AddExtents(ext.Value);
                    }                    
                }                
            }
            return r;
        }
        public static void WriteListInDatabase<T>(List<T> entities, CoordinateSystem acutalCS, DBManager.EntityPropertiesAssignment propertyAssignmentMethod, ObjectId layerID, ObjectId blockID,string layerName)
        {
            if (entities != null && entities.Count != 0)
            {
                Database workingDatabase = HostApplicationServices.WorkingDatabase;
                Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
                ProgressMeter progressMeter = new ProgressMeter();
                MessageFilter messageFilter = new MessageFilter();
                System.Windows.Forms.Application.AddMessageFilter(messageFilter);               
               
                List<Triangle> triList = new List<Triangle>();
               
                try
                {                  
                    blockID =SymbolUtilityServices.GetBlockModelSpaceId(workingDatabase);
                    if (layerName != null)
                    {
                        layerID = LayerUtil.CreateLayer(layerName, 127, false);
                    }
                    else
                    {
                        layerID = ObjectId.Null;
                    }
                   
                    if (typeof(T) != typeof(Triangle))
                    {
                        throw new NotImplementedException("Generic list type not supported: " + typeof(T).ToString());
                    }
                        
                    triList = (List<Triangle>)Convert.ChangeType(entities, typeof(List<Triangle>));
                    
                    if (acutalCS != null)
                    {                        
                        Conversions.ToWCS(acutalCS, triList);        
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
                            Point3d point3d3 = new Point3d(triList[i].Vertex1.X, triList[i].Vertex1.Y, triList[i].Vertex1.Z);
                                        
                            Point3d point3d4 = new Point3d(triList[i].Vertex2.X, triList[i].Vertex2.Y, triList[i].Vertex2.Z);
                                      
                            Point3d point3d5 = new Point3d(triList[i].Vertex3.X, triList[i].Vertex3.Y, triList[i].Vertex3.Z);
                                       
                            Entity entity = new Autodesk.AutoCAD.DatabaseServices.Face(point3d3, point3d4, point3d5, true, true, true, true);
                                        
                            if (layerID != ObjectId.Null)
                            {
                                entity.LayerId = (layerID);
                            }
                            
                            if (color == null)
                            {
                                entity.ColorIndex = ((int)colorIndex);
                            }
                            else
                            {
                                entity.Color = (color);
                            }
                            blockTableRecord.AppendEntity(entity);
                            transaction.AddNewlyCreatedDBObject(entity, true);
                            progressMeter.MeterProgress();
                            messageFilter.CheckMessageFilter((long)i, 10000);
                        }
                        
                        transaction.Commit();
                        
                    }
                    
                    progressMeter.Stop();
                    editor.WriteMessage(Environment.NewLine + entities.Count.ToString() + " entities written to database.");
                    editor.WriteMessage("\n");
                    editor.Regen();
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

        public static Autodesk.AutoCAD.DatabaseServices.Line line(Point3d startPoint, Point3d endPoint,ObjectId layerId)
        {
            return DBManager.CreateLine(startPoint, endPoint, layerId, HostApplicationServices.WorkingDatabase.CurrentSpaceId);
        }
        public static DBText text(Point3d pos, string text,double rotation,ObjectId layerId)
        {
            return CreateText(pos,text,rotation,layerId,ObjectId.Null);
        }

        public static DBText CreateText(Point3d pos, string text,double rotation,ObjectId layerID, ObjectId blockID)
        {
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            
            DBText dbText = new DBText();
            dbText.TextString = text;
            dbText.Position = pos;
            dbText.Rotation = rotation;
            using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
            {
                if (layerID != ObjectId.Null)
                {
                    dbText.LayerId = (layerID);
                }
                if (blockID == ObjectId.Null)
                {
                    blockID = workingDatabase.CurrentSpaceId;
                }
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
                
                BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockID, (OpenMode)1);
                blockTableRecord.AppendEntity(dbText);
                transaction.AddNewlyCreatedDBObject(dbText, true);
                transaction.Commit();
            }
            return dbText;
        }

    }
}
