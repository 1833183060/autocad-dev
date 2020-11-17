using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace AcadUtil
{
    public class MySelection
    {
        public static ObjectId[] SelectAll(SelectionFilter filter)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            TypedValue[] array = new TypedValue[0];

            
            PromptSelectionResult selection = editor.SelectAll( filter);
            if (selection.Status == (PromptStatus.Cancel))
            {
                return null;
            }
            if (selection.Status != (PromptStatus.OK))
            {
                return null;
            }

            return selection.Value.GetObjectIds();
        }

        public static ObjectId[] getObjects(string msg)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            TypedValue[] array = new TypedValue[0];
            
            PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
            promptSelectionOptions.MessageForAdding =msg;
            promptSelectionOptions.AllowSubSelections = true;
            promptSelectionOptions.AllowDuplicates = (false);
            PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, new SelectionFilter(array));
            if (selection.Status == (PromptStatus)(-5002))
            {
                return null;
            }
            if (selection.Status != (PromptStatus)5100)
            {
                return null;
            }
            
            return selection.Value.GetObjectIds();
        }

        public static SelectionSet getss(string msg)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            TypedValue[] array = new TypedValue[0];

            PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
            promptSelectionOptions.MessageForAdding = msg;
            promptSelectionOptions.AllowSubSelections = true;
            promptSelectionOptions.AllowDuplicates = (false);
            PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, new SelectionFilter(array));
            if (selection.Status == PromptStatus.Cancel)
            {
                //return null;
            }
            if (selection.Status != PromptStatus.OK)
            {
                //return null;
            }

            return selection.Value;
        }

        public static SelectionSet getss()
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            TypedValue[] array = new TypedValue[0];

            PromptSelectionOptions promptSelectionOptions = new PromptSelectionOptions();
            promptSelectionOptions.MessageForAdding = "";
            promptSelectionOptions.AllowSubSelections = true;
            promptSelectionOptions.AllowDuplicates = (false);
            
            PromptSelectionResult selection = editor.GetSelection(promptSelectionOptions, new SelectionFilter(array));
            if (selection.Status == (PromptStatus)(-5002))
            {
                return null;
            }
            if (selection.Status != (PromptStatus)5100)
            {
                return null;
            }

            return selection.Value;
        }

        public static ObjectId getEntity(string msg,Type type=null)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptEntityOptions opt = new PromptEntityOptions(msg);
            
            opt.SetRejectMessage("选择的不是"+type.Name);
            opt.AddAllowedClass(type, true);
            PromptEntityResult result=ed.GetEntity(opt);
            if (result.Status == PromptStatus.OK)
            {
                return result.ObjectId;
            }
            return ObjectId.Null;
        }
        public static ObjectId getEntity(string msg,List<Type> typelist = null)
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptEntityOptions opt = new PromptEntityOptions(msg);

            string rejectMsg= "选择的不是:";
            opt.SetRejectMessage(rejectMsg);
            foreach (Type type in typelist)
            {
                opt.AddAllowedClass(type, true);
                rejectMsg += type.Name + "/";
            }
            
            PromptEntityResult result = ed.GetEntity(opt);
            if (result.Status == PromptStatus.OK)
            {
                return result.ObjectId;
            }
            return ObjectId.Null;
        }
    }
}
