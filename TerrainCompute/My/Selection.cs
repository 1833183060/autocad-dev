using System;
using System.ComponentModel;
using System.IO;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.My
{
    public class Selection
    {
        public static ObjectId[] getFaceIds(string layerName)
        {
            return GetObjectIDs(CommandLineQuerries.EntityType.FACE, layerName);
        }

        public static ObjectId[] GetObjectIDs(string dxfName, string layerName)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            if (layerName == null || layerName == "")
            {
                layerName = "*";
            }
            TypedValue[] array = new TypedValue[0];
            
            array = new TypedValue[]
			{
				new TypedValue(-4, "<or"),
				new TypedValue(-4, "<and"),
                    
				new TypedValue((int)DxfCode.LayerName, layerName),
				new TypedValue((int)DxfCode.Start, dxfName),
				new TypedValue(-4, "and>"),
				new TypedValue(-4, "or>")
			};
                    
            PromptSelectionResult selection = editor.SelectAll(new SelectionFilter(array));
            if (selection.Status == (PromptStatus.Cancel))
            {
                CommandLineQuerries.OnCancelled();
            }
            if (selection.Status != PromptStatus.OK)
            {
                return null;
            }
            return selection.Value.GetObjectIds();
        }

        public static ObjectId[] GetObjectIDs(CommandLineQuerries.EntityType type,string layerName)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            if (layerName == null || layerName == "")
            {
                layerName = "*";
            }
            TypedValue[] array = new TypedValue[0];
            switch (type)
            {
                case CommandLineQuerries.EntityType.Region:
                    array = new TypedValue[]
				    {
					    new TypedValue(-4, "<or"),
					    new TypedValue(-4, "<and"),
                    
					    new TypedValue((int)DxfCode.LayerName, layerName),
					    new TypedValue((int)DxfCode.Start, "REGION"),
					    new TypedValue(-4, "and>"),
					    new TypedValue(-4, "or>")
				    }; 
                    break;
                case CommandLineQuerries.EntityType.FACE:
                    array = new TypedValue[]
				    {
					    new TypedValue(-4, "<or"),
					    new TypedValue(-4, "<and"),
                    
					    new TypedValue((int)DxfCode.LayerName, layerName),
					    new TypedValue(0, "3DFACE"),
					    new TypedValue(-4, "and>"),
					    new TypedValue(-4, "or>")
				    };                   
               
                break;
                case CommandLineQuerries.EntityType.PLINES:
                array = new TypedValue[]
				{
					new TypedValue(-4, "<or"),
					new TypedValue(-4, "<and"),
                    
					new TypedValue((int)DxfCode.LayerName, layerName),
					new TypedValue(-4, "<or"),
					new TypedValue(0, "POLYLINE2D"),
                    new TypedValue(0, "POLYLINE3D"),
                    new TypedValue(0, "POLYLINE"),
                    new TypedValue(-4, "or>"),
					new TypedValue(-4, "and>"),
					new TypedValue(-4, "or>")
				};  
                break;
            }
            
            PromptSelectionResult selection = editor.SelectAll( new SelectionFilter(array));
            if (selection.Status == (PromptStatus.Cancel))
            {
                CommandLineQuerries.OnCancelled();
            }
            if (selection.Status != PromptStatus.OK)
            {
                return null;
            }
            return selection.Value.GetObjectIds();
        }

        public static ObjectId[] getBoundarys()
        {
            return GetObjectIDs(CommandLineQuerries.EntityType.PLINES, UserCmd.boundaryLayerName);
        }
        public static ObjectId[] getContours(string layerName)
        {
            return GetObjectIDs(CommandLineQuerries.EntityType.PLINES, layerName);
        }
    }
}
