using System;
using System.Collections.Generic;
using System.Text;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace MyList
{
    public class Class1
    {
        [CommandMethod("getAttr2")]
        public void getAttr2()
        {
            Document curDoc=Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed=curDoc.Editor;
            ed.WriteMessage("\ngetAttr2\n");
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
                if (bt.Has("PC_TITLE_BLOCK"))
                {
                    //BlockTableRecord btr=bt["PC_TITLE_BLOCK"]
                }
            }
            
        }
        /// <summary>
        /// 获取模型空间所有块参照的属性
        /// </summary>
        [CommandMethod("getAttr")]
        public void getReference()
        {
            Document curDoc=Application.DocumentManager.MdiActiveDocument;
                Database db = curDoc.Database;
                Editor ed=curDoc.Editor;
            try { 
                
                ed.WriteMessage("\ngetAttr\n");
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    PostInfo postInfo = new PostInfo();
                    BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    ObjectId btrecId = bt[BlockTableRecord.ModelSpace];
                    //ObjectId btrecId = SymbolUtilityServices.GetBlockModelSpaceId(db);
                    BlockTableRecord btrec = tr.GetObject(btrecId, OpenMode.ForRead) as BlockTableRecord;
                    RXClass refClass=RXClass.GetClass(typeof(BlockReference));
                    foreach (ObjectId id in btrec)
                    {
                        //ed.WriteMessage("\n" + id.ObjectClass.Name+"--"+id.ObjectClass.AppName + "\n");
                        if (id.ObjectClass == refClass)
                        {
                            //getAttributeDefInfo(id, ed);
                            BlockReference bref = tr.GetObject(id, OpenMode.ForRead) as BlockReference;
                        
                            ed.WriteMessage("\nblock name:" + bref.Name + "\n");
                            postInfo.writeBlockName(bref.Name);
                            foreach (ObjectId attrId in bref.AttributeCollection)
                            {
                                AttributeReference attrRef = tr.GetObject(attrId, OpenMode.ForRead) as AttributeReference;
                                ed.WriteMessage("\ntag:" + attrRef.Tag + "--value:" + attrRef.TextString + "\n");
                                postInfo.writeAttrRef(attrRef.Tag, attrRef.TextString);
                            }
                        }
                    }
                    postInfo.endWrite();
                    tr.Commit();

                }
            }
            catch (System.Exception ex) {
                ed.WriteMessage(ex.Message+ex.StackTrace);
            }
        }
        /// <summary>
        /// 获取指定块参照所在块的属性定义
        /// </summary>
        /// <param name="blkRefId"></param>
        /// <param name="ed"></param>
        public void getAttributeDefInfo(ObjectId blkRefId,Editor ed)
        {
            using (Transaction tr = blkRefId.Database.TransactionManager.StartTransaction())
            {

                BlockReference bref = tr.GetObject(blkRefId, OpenMode.ForRead) as BlockReference;
                BlockTableRecord blkDef = tr.GetObject(bref.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                foreach (ObjectId attrDefId in blkDef)
                {
                    AttributeDefinition attrDef = tr.GetObject(attrDefId, OpenMode.ForRead) as AttributeDefinition;
                    if (attrDef != null)
                    {
                        ed.WriteMessage("\ntag:" + attrDef.Tag + "--prompt:" + attrDef.Prompt + "\n");
                    }
                }
                tr.Commit();
            }
        }

        [CommandMethod("fullpath")]
        public string getFullPath()
        {
            Document curDoc = Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed = curDoc.Editor;
            string fullPath = "";
            //fullPath=db.Filename;
            fullPath =Application.GetSystemVariable("dwgprefix").ToString()+ Application.GetSystemVariable("dwgname").ToString();
            ed.WriteMessage("\n" + fullPath + "\n");
            return fullPath;
        }
    }
}
