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
namespace TerrainComputeC.My
{
    public class LineTypeUtil
    {
        // 创建带文字的线型 ////// 返回线型ID 
        public static ObjectId CreateLineTypeWithText(string lineTypeName,string text) { 
            Document doc = Autodesk.AutoCAD.ApplicationServices. Application.DocumentManager.MdiActiveDocument; Database db = doc.Database; Editor ed = doc.Editor; 
            Transaction tr =db.TransactionManager.StartTransaction(); using (tr) { // 读出文字样式表 
                TextStyleTable tt = (TextStyleTable)tr.GetObject(db.TextStyleTableId, OpenMode.ForRead); 
                // 读出线型表 
                LinetypeTable lt = (LinetypeTable)tr.GetObject(db.LinetypeTableId, OpenMode.ForWrite); 
                if (lt.Has(lineTypeName)) {
                    return lt[lineTypeName]; 
                } 
                else { // 创建新的线型记录. 
                    LinetypeTableRecord ltr = new LinetypeTableRecord(); 
                    // ...设置线型记录特性 
                    ltr.Name = lineTypeName; 
                    ltr.AsciiDescription = lineTypeName+" Supply ---- "+text+" ---- "+text+" ---- "+text+" ----"; 
                    ltr.PatternLength = 1.1; 
                    ltr.NumDashes = 3; //分为三段 // 线段Dash #1 
                    ltr.SetDashLengthAt(0, 0.5); // 线段Dash #2 
                    ltr.SetDashLengthAt(1, -0.3); 
                    ltr.SetShapeStyleAt(1, tt["Standard"]);//文字样式设定 
                    ltr.SetShapeNumberAt(1, 0); //文字位置设定，用一二维向量控制 
                    ltr.SetShapeOffsetAt(1, new Vector2d(-0.1, -0.05)); ltr.SetShapeScaleAt(1, 0.1);//文字比例 
                    ltr.SetShapeIsUcsOrientedAt(1, false); ltr.SetShapeRotationAt(1, 0);//文字方向,0为顺直接方向 
                    ltr.SetTextAt(1, text);//文字内容 // 线段Dash #3 
                    ltr.SetDashLengthAt(2, -0.3); // 添加新的线型记录到线型表 
                    ObjectId ltId = lt.Add(ltr); 
                    tr.AddNewlyCreatedDBObject(ltr, true); 
                    tr.Commit(); 
                    return ltId;//返回线型记录ID 
                }
            }
        }
    }
}
