//by 鸟哥 qq1833183060
//qq群 720924083
//2020-11-10
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
    public class RibbonDemo
    {
        //参考 https://adndevblog.typepad.com/autocad/2012/04/displaying-a-contextual-tab-upon-entity-selection-using-ribbon-runtime-api.html
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Use: Displays a contextual tab upon entity selection,
        //      using Ribbon runtime API.
        //
        // Author: Philippe Leefsma, April 2012
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        Autodesk.Windows.RibbonTab _ctxTab = null;
        [CommandMethod("CtxTabUponSelect")]
        public void CtxTabUponSelect()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            //Set up event for selection changed

            doc.ImpliedSelectionChanged +=new EventHandler(doc_ImpliedSelectionChanged);
        }

        void doc_ImpliedSelectionChanged(object sender, EventArgs e)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;

            PromptSelectionResult psr = doc.Editor.SelectImplied();
            //if no entities are selected, we hide our context tab

            if (psr.Value == null)
            {
                HideTab();
                return;
            }
            //In this example we only display the tab if only circles are

            // selected. You may want to change this condition of course.
            foreach (SelectedObject selObj in psr.Value)
            {
                if (selObj.ObjectId.ObjectClass.DxfName.ToLower()!= "circle")
                {
                    HideTab();
                    return;
                }
            }
            //We will use the Application.Idle event to safely display our tab
            if (_ctxTab == null || !_ctxTab.IsVisible)
            {
                Autodesk.AutoCAD.ApplicationServices.Application.Idle +=new EventHandler(OnIdle);
            }
        }

        void OnIdle(object sender, EventArgs e)
        {
            //Make sure ribbon manager is available

            if (Autodesk.Windows.ComponentManager.Ribbon != null)
            {
                //Create tab if it doesn't exist

                if (_ctxTab == null)
                    CreateCtxTab();

                //Otherwise make it visible

                if (!_ctxTab.IsVisible)
                {
                    Autodesk.Windows.RibbonControl ribbonCtrl =Autodesk.Windows.ComponentManager.Ribbon;

                    ribbonCtrl.ShowContextualTab(_ctxTab, false, true);

                    _ctxTab.IsActive = true;
                }

                if (!_ctxTab.IsActive)
                    _ctxTab.IsActive = true;
            }
        }

        //Tab creation method

        void CreateCtxTab()
        {
            Autodesk.Windows.RibbonControl ribbonCtrl =Autodesk.Windows.ComponentManager.Ribbon;

            _ctxTab = new Autodesk.Windows.RibbonTab();

            _ctxTab.Name = "MyTab";

            _ctxTab.Id = "MY_CTX_TAB_ID";

            _ctxTab.IsVisible = true;

            _ctxTab.Title = _ctxTab.Name;

            _ctxTab.IsContextualTab = true;
            ribbonCtrl.Tabs.Add(_ctxTab);

        }

        void HideTab()
        {
            Autodesk.AutoCAD.ApplicationServices.Application.Idle-= new EventHandler(OnIdle);
            
            if (_ctxTab != null)
            {
                Autodesk.Windows.RibbonControl ribbonCtrl=Autodesk.Windows.ComponentManager.Ribbon;

                ribbonCtrl.HideContextualTab(_ctxTab);

                _ctxTab.IsVisible = false;

                _ctxTab = null;

            }
        }
    }
}
