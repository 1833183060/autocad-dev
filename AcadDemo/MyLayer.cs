//by 鸟哥 qq1833183060
//qq群 720924083
//2020-11-07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;

namespace AcadDemo
{
    public class MyLayer
    { 
        [CommandMethod("SetLayerCurrent")]
        public static void SetLayerCurrent()
        {//http://docs.autodesk.com/ACD/2010/ENU/AutoCAD%20.NET%20Developer%27s%20Guide/index.html?url=WS1a9193826455f5ff2566ffd511ff6f8c7ca-3d31.htm,topicNumber=d0e29116
          // Get the current document and database
          Document acDoc = Application.DocumentManager.MdiActiveDocument;
          Database acCurDb = acDoc.Database;
 
          // Start a transaction
          using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
          {
              // Open the Layer table for read
              LayerTable acLyrTbl;
              acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId,OpenMode.ForRead) as LayerTable;
 
              string sLayerName = "Center";
 
              if (acLyrTbl.Has(sLayerName) == true)
              {
                  // Set the layer Center current
                  acCurDb.Clayer = acLyrTbl[sLayerName]; 
                  // Save the changes
                  acTrans.Commit();
              } 
              // Dispose of the transaction
          }
        }

        public static void SetLayerCurrent2()
        {
            Application.SetSystemVariable("CLAYER", "Center");
        }
    
    }
}
