using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;

namespace AcadUtil
{
    public class MyGroup
    {
        private static ObjectId erasingGroupId = ObjectId.Null;
        public static void CreateGroup(string groupName,ObjectIdCollection ids)
        {
            //Document doc =Application.DocumentManager.MdiActiveDocument;
            Database db = HostApplicationServices.WorkingDatabase;
            //Editor ed = doc.Editor;

            Transaction tr =db.TransactionManager.StartTransaction();

          using(tr)
          {
            // Get the group dictionary from the drawing
            DBDictionary gd =(DBDictionary)tr.GetObject(db.GroupDictionaryId,OpenMode.ForRead);
            // Check the group name, to see whether it's

            // A variable for the group's name
            string grpName = "";            
            try
            {
                // Validate the provided symbol table name
                SymbolUtilityServices.ValidateSymbolName(groupName,false);

                // Only set the block name if it isn't in use
                if (gd.Contains(groupName))
                { 
                    //ed.WriteMessage("\nA group with this name already exists.");

                    throw new System.Exception("A group with this name already exists.");
                }else{
                    grpName =groupName;
                }
            }
            catch
            {
                // An exception has been thrown, indicating the
                // name is invalid

                //ed.WriteMessage("\nInvalid group name.");
            }

            // Create our new group...

            Group grp = new Group("Test group", true);
            // Add the new group to the dictionary
            gd.UpgradeOpen();
            
            ObjectId grpId = gd.SetAt(grpName, grp);

            tr.AddNewlyCreatedDBObject(grp, true);
            grp.InsertAt(0, ids);
            // Commit the transaction
            tr.Commit();
            // Report what we've done
            //ed.WriteMessage("\nCreated group named \"{0}\" containing  entities.",grpName);
          }

        }
        private static void Group_ObjectClosed(object sender, ObjectClosedEventArgs e)
        {
            if (erasingGroupId == ObjectId.Null) return;
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {

                Group g = trans.GetObject(erasingGroupId, OpenMode.ForWrite)as Group;
                erasingGroupId = ObjectId.Null;
                g.Erase();
                trans.Commit();
            }
            
        }
        /// <summary>
        /// 删除组内对象,并将组id记录到待删除变量
        /// 参考：https://www.cnblogs.com/swtool/p/3810009.html
        /// </summary>
        /// <param name="stropt"></param>

        public static void deleteGroupAndObjs(StringOption stropt)
        {
            if (erasingGroupId != ObjectId.Null) return;
            //定义数据库
            Database db = HostApplicationServices.WorkingDatabase;
            //获取当前文件
            //Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //获取当前命令行对象
            //Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                #region 删除组
                //定义组字典
                DBDictionary groupDict = (DBDictionary)db.GroupDictionaryId.GetObject(OpenMode.ForRead);
                //在组字典中搜索满足条件的组对象
                foreach (DictionaryEntry ide in groupDict)
                {
                    //获取组对象
                    Group partGroup = trans.GetObject((ObjectId)ide.Value, OpenMode.ForRead) as Group;
                    
                    //
                    if (stropt.Match(partGroup.Name))
                    {
                        erasingGroupId = partGroup.ObjectId;
                        partGroup.ObjectClosed += Group_ObjectClosed;
                        //先删除组中的对象再删除组，直接删除组的话只是将组打散而已
                        foreach (ObjectId id in partGroup.GetAllEntityIds())
                        {
                            try
                            {
                                Entity ent = (Entity)id.GetObject(OpenMode.ForWrite);
                                ent.Erase();
                                ent.Dispose();
                            }
                            catch(System.Exception ex) {
                                throw new System.Exception("128");
                            }
                        }
                        
                        break;
                        //partGroup.UpgradeOpen();
                        //partGroup.Erase(true);
                        //partGroup.DowngradeOpen();
                    }
                }
                #endregion 删除组
                trans.Commit();
            }
        }
  }

}
   
