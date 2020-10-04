using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ModifyCmd
    {
        [CommandMethod("TCPlugin", "ng:scale", CommandFlags.Modal)]
        public void scale()
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            this.messageFilter_0 = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(this.messageFilter_0);
            try
            {
                
                PointSet pointSet = new PointSet();
                ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.POINT, "选择点：", false);
                if (objectIDs != null)
                {
                Database workingDatabase = HostApplicationServices.WorkingDatabase;
                
                using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
                {
                    for (int i = 0; i < objectIDs.Length; i++)
                    {
                        DBPoint dbPoint = (DBPoint)transaction.GetObject(objectIDs[i], OpenMode.ForWrite, true);

                        dbPoint.Position = new Autodesk.AutoCAD.Geometry.Point3d(dbPoint.Position.X, dbPoint.Position.Y, dbPoint.Position.Z * 5);
                    }
                    transaction.Commit();
                }
                
                    string text = " triangulation point";
                    if (objectIDs.Length > 1)
                    {
                        text += "s";
                    }
                    editor.WriteMessage(objectIDs.Length + text + " selected.");
                    
                }
                else
                {
                    editor.WriteMessage("没有选择到点.\n");
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        [CommandMethod("TCPlugin","ng:movetext",CommandFlags.Modal)]
        public void moveText2interCmd()
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            this.messageFilter_0 = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(this.messageFilter_0);
            try
            {

                PointSet pointSet = new PointSet();
                ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.TEXT, "选择点：", false);
                if (objectIDs != null)
                {
                    Database workingDatabase = HostApplicationServices.WorkingDatabase;

                    using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
                    {
                        for (int i = 0; i < objectIDs.Length; i++)
                        {
                            DBText text = (DBText)transaction.GetObject(objectIDs[i], OpenMode.ForWrite, true);

                            Point3d newP= moveText2inter(text.Position);
                            text.Position = newP;
                            editor.WriteMessage(""+newP.X+newP.Y);
                        }
                        
                        transaction.Commit();
                    }

                    
                    if (objectIDs.Length > 1)
                    {
                        
                    }
                    

                }
                else
                {
                    editor.WriteMessage("没有选择到点.\n");
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        public Point3d moveText2inter(Point3d pt)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Point3d snapPoint=editor.Snap("int", pt);
            return snapPoint;
        }

        private MessageFilter messageFilter_0;
    }
}