using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using Autodesk.AutoCAD.Geometry;
namespace TerrainComputeC.My
{
    public class AcadUtil
    {
        public static Extents3d? getBound(ObjectId[] idArray)
        {
            Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Extents3d? r = null;
            using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
            {
                for (int i = 0; i < idArray.Length; i++)
                {
                    DBObject @object = transaction.GetObject(idArray[i], (OpenMode)0);
                    if (!(@object == null))
                    {
                        Autodesk.AutoCAD.DatabaseServices.Line line = @object as Autodesk.AutoCAD.DatabaseServices.Line;
                        if (line != null)
                        {
                            
                        }
                        else
                        {
                            
                            Polyline polyline = @object as Polyline;
                            if (polyline != null)
                            {
                                
                                r=polyline.Bounds;
                            }
                            Polyline2d polyline2d = @object as Polyline2d;
                            if (polyline2d != null)
                            {
                                r = polyline2d.Bounds;
                            }
                            Polyline3d polyline3d = @object as Polyline3d;
                            if (polyline3d != null)
                            {
                                if (r != null)
                                {
                                    r.Value.AddExtents(polyline3d.Bounds.Value);
                                }
                                r = polyline3d.Bounds;
                            }
                            
                        }
                    }
                }
            }
            return r;
        }
    }
}
