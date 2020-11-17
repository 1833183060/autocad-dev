using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;

namespace AcadUtil
{
    public class MyLayer
    {
        public static void SetCLayer(string name,Autodesk.AutoCAD.Colors.Color color)
        {
            bool r=true;
            DBManager.CreateLayer(name, color,false,ref r);
            Application.SetSystemVariable("clayer", name);
        }
        public static void DeleteAllObj(string layerName)
        {
            TypedValue[] tvs ={
                                new TypedValue((int)DxfCode.LayerName,layerName)
                            };
            SelectionFilter filter = new SelectionFilter(tvs);

            ObjectId[] ids=MySelection.SelectAll(filter);
            if (ids == null) return;
            using (Transaction trans = HostApplicationServices.WorkingDatabase.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < ids.Length; ++i)
                {
                    DBObject obj = trans.GetObject(ids[i],OpenMode.ForWrite);
                    obj.Erase();
                }
                trans.Commit();
            }
        }
    }
}
