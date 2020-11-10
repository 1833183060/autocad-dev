//by 鸟哥 qq1833183060
//qq群 720924083
//2020-11-09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
namespace AcadDemo
{
    public class DimensionDemo
    {
        //https://adndevblog.typepad.com/autocad/2012/04/creating-a-3-point-angular-dimension-using-point3angulardimension-in-net.html
        [CommandMethod("netDimAngular")]
        public void netDimAngular()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            PromptEntityOptions peo = new PromptEntityOptions("\nSelect an Arc: ");

            peo.SetRejectMessage("\nMust be an Arc...");

            peo.AddAllowedClass(typeof(Arc), true);

            PromptEntityResult per = ed.GetEntity(peo);

            if (per.Status != PromptStatus.OK)
                return;

            using (Transaction Tx =db.TransactionManager.StartTransaction())
            {
                Arc arc = Tx.GetObject(per.ObjectId, OpenMode.ForRead) as Arc;

                BlockTable bt = Tx.GetObject(db.BlockTableId,OpenMode.ForRead) as BlockTable;

                BlockTableRecord btr = Tx.GetObject(bt[BlockTableRecord.ModelSpace],OpenMode.ForWrite) as BlockTableRecord;

                string dimStyle = "Standard";

                DimStyleTable dimStyleTable = Tx.GetObject(db.DimStyleTableId,OpenMode.ForRead) as DimStyleTable;

                if (dimStyleTable.Has(dimStyle))
                {
                    Point3d point3 =arc.StartPoint.Add(arc.EndPoint.GetAsVector()).MultiplyBy(0.5);

                    ObjectId dimStyleId = dimStyleTable[dimStyle];

                    Point3AngularDimension dim = new Point3AngularDimension(arc.Center,arc.StartPoint,arc.EndPoint,point3, "",dimStyleId);

                    btr.AppendEntity(dim);

                    Tx.AddNewlyCreatedDBObject(dim, true);
                    Tx.Commit();

                }
            }
        }

        
        
        /// <summary>
        /// 创建尺寸样式并置为当前
        /// 参考 https://adndevblog.typepad.com/autocad/2012/04/creating-a-new-dimension-style-and-make-it-as-current.html
        /// </summary>
        [CommandMethod("NewDimStyle")]
        public void NewDimStyle()
        {
            Database db =Application.DocumentManager.MdiActiveDocument.Database;

            using (Transaction trans =db.TransactionManager.StartTransaction())
            {
                DimStyleTable DimTabb =(DimStyleTable)trans.GetObject(db.DimStyleTableId,OpenMode.ForRead);

                ObjectId dimId = ObjectId.Null;

                if (!DimTabb.Has("Test"))
                {
                    DimTabb.UpgradeOpen();

                    DimStyleTableRecord newRecord =new DimStyleTableRecord();

                    newRecord.Name = "Test";

                    dimId = DimTabb.Add(newRecord);

                    trans.AddNewlyCreatedDBObject(newRecord, true);

                }

                else
                {
                    dimId = DimTabb["Test"];
                }

                DimStyleTableRecord DimTabbRecaord =(DimStyleTableRecord)trans.GetObject(dimId,OpenMode.ForRead);

                if (DimTabbRecaord.ObjectId != db.Dimstyle)
                {
                    db.Dimstyle = DimTabbRecaord.ObjectId;
                    db.SetDimstyleData(DimTabbRecaord);
                }
                trans.Commit();

            }
        }
    }
}
