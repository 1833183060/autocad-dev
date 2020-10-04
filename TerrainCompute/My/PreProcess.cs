using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
namespace TerrainComputeC.My
{
    public class PreProcess
    {
        public static PointSet getPointFromText(ScaleProp scale)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            
            try
            {
                PointSet pointSet = new PointSet();

                TypedValue[] filter=null;
                filter = new TypedValue[]
				{
					new TypedValue(0, "TEXT")
				};
                
                PromptSelectionResult selection = editor.SelectAll(new SelectionFilter(filter));
                if (selection.Status == (PromptStatus)(-5002))
                {
                    CommandLineQuerries.OnCancelled();
                }
                if (selection.Status != (PromptStatus)5100)
                {
                    return null;
                }
                ObjectId[] objectIDs = selection.Value.GetObjectIds();

                
                if (objectIDs != null)
                {
                    Database workingDatabase = HostApplicationServices.WorkingDatabase;
                    
                    using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
                    {
                        for (int i = 0; i < objectIDs.Length; i++)
                        {
                            DBText dbText = (DBText)transaction.GetObject(objectIDs[i], OpenMode.ForRead, true);
                            string text = dbText.TextString;
                            double z=0;
                            double.TryParse(text,out z);
                            pointSet.Add(new ngeometry.VectorGeometry.Point(dbText.Position.X*scale.X, dbText.Position.Y*scale.Y, z*scale.Z));
                        }
                        transaction.Commit();
                    }

                }
                else
                {
                    editor.WriteMessage("没有选择到点.\n");
                }
                return pointSet;
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static ObjectId[] getAllLines()
        {
            ObjectId[] objectIDs = null;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            
            try
            {
                TypedValue[] filter = new TypedValue[]{
                
                new TypedValue(-4, "<or"),
                new TypedValue(0,"LINE"),
					new TypedValue(0, "LWPOLYLINE"),
					new TypedValue(0, "POLYLINE2D"),
					new TypedValue(0, "POLYLINE"),
					new TypedValue(-4, "or>")
            };
            
                
            PromptSelectionResult selection = editor.SelectAll(new SelectionFilter(filter));
            if (selection.Status == (PromptStatus.Cancel))
            {
                CommandLineQuerries.OnCancelled();
            }
            if (selection.Status != PromptStatus.OK)
            {
                return null;
            }
            objectIDs = selection.Value.GetObjectIds();
            //Region region= AddRegion(objectIDs);
            
            }
            catch (System.Exception ex)
            {

            }
            return objectIDs;
        }
        //将ids表示的线围成的区域做成面域，然后把这些面域合并
        public static  Region AddRegion(ObjectId[] ids)
        {
            Region ret = null;
            try
            {
                // Get the current document and database
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;
                // Start a transaction
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    // Open the Block table for read
                    BlockTable acBlkTbl;
                    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                      OpenMode.ForRead) as BlockTable;
                    // Open the Block table record Model space for write
                    BlockTableRecord acBlkTblRec;
                    acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                         OpenMode.ForWrite) as BlockTableRecord;
                    DBObjectCollection acDBObjColl = new DBObjectCollection();
                    for (int i = 0; i < ids.Length; i++)
                    {
                        DBObject ent = acTrans.GetObject(ids[i], OpenMode.ForRead);

                        // Adds the circle to an object array

                        acDBObjColl.Add(ent);
                        // Calculate the regions based on each closed loop

                    }
                    DBObjectCollection myRegionColl = new DBObjectCollection();
                    myRegionColl = Region.CreateFromCurves(acDBObjColl);
                    
                    for (int i = 0; i < acDBObjColl.Count; i++)
                    {
                        if (i == 0)
                        {
                            ret = myRegionColl[0] as Region;
                        }
                        else
                        {
                            ret.BooleanOperation(BooleanOperationType.BoolUnite, myRegionColl[i] as Region);
                        }
                    }

                    // Add the new object to the block table record and the transaction

                    //acBlkTblRec.AppendEntity(acRegion);
                    //acTrans.AddNewlyCreatedDBObject(acRegion, true);
                    // Save the new object to the database
                    acTrans.Commit();
                }
            }
            catch (System.Exception ex)
            {

            }
            return ret;
        }

        //从直线集合中计算外围边界，直线在相交处都是打断的。得出的边界用点列表表示
        public static List<Point3d> getOuterBoundaryFromLine(ObjectId[] ids,Point3d? innerP)
        {
            List<Point3d> ret = null;
            try
            {
                PLDictionary plDic=new PLDictionary();
                // Get the current document and database
                Document acDoc = Application.DocumentManager.MdiActiveDocument;
                Database acCurDb = acDoc.Database;
                Editor ed = acDoc.Editor;
                // Start a transaction
                using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                {
                    // Open the Block table for read
                    BlockTable acBlkTbl;
                    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                                      OpenMode.ForRead) as BlockTable;
                    // Open the Block table record Model space for write
                    BlockTableRecord acBlkTblRec;
                    acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                         OpenMode.ForWrite) as BlockTableRecord;
                    List<Autodesk.AutoCAD.DatabaseServices.Line> ll = new List<Autodesk.AutoCAD.DatabaseServices.Line>();
                    DBObjectCollection acDBObjColl = new DBObjectCollection();
                    for (int i = 0; i < ids.Length; i++)
                    {
                        if(ids[i].ObjectClass!=RXClass.GetClass(typeof(Autodesk.AutoCAD.DatabaseServices.Line)))continue;
                        Autodesk.AutoCAD.DatabaseServices.Line line = acTrans.GetObject(ids[i], OpenMode.ForRead) as Autodesk.AutoCAD.DatabaseServices.Line;

                        ll.Add(line);
                    }
                    ll=ll.Distinct(new My.CompareLine()).ToList();// as List<Autodesk.AutoCAD.DatabaseServices.Line>;
                    plDic.Add(ll);
                    KeyValuePair<Point3d, Vector2d>? kvp = null;
                    if (innerP == null)
                    {
                        kvp=plDic.getLeftMost();//外部边界起始
                    }
                    else
                    {
                        //内部边界起始
                        kvp = Utility2d.getLeftMost(innerP.Value, ll, plDic);
                    }
                    
                    if (kvp == null)
                    {
                        return null;
                    }
                    Point3d startP = kvp.Value.Key;
                    Point3d curP = kvp.Value.Key;
                    Vector2d curV = kvp.Value.Value;
                    List<Point3d> plist = new List<Point3d>();
                    plist.Add(curP);
                    int maxLoopCount = plDic.Count;
                    while (maxLoopCount-->0)
                    {
                        Point3d? p = plDic.getMaxAnglePoint(curP, curV);
                        //ed.DrawVectors()
                        if (p == null) break;
                        if (p.Value == startP) break;
                        curV = new Vector2d(curP.X - p.Value.X, curP.Y - p.Value.Y);
                        curP = p.Value;                     

                        plist.Add(p.Value);
                        
                    }
                    ret = plist;
                    
                    acTrans.Commit();
                }
            }
            catch (System.Exception ex)
            {

            }
            return ret;
        }
    }
}
