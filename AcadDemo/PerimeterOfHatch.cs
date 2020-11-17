//参考：https://adndevblog.typepad.com/autocad/2012/04/perimeter-of-a-hatch-using-objectarx-and-autocad-net-api.html
//计算图案填充的周长
//qq群 720924083
//2020-11-14
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
    public class PerimeterOfHatch
    {      
        // Perimeter calculation of a hatch using AutoCAD.Net API

        [CommandMethod("HatchTest")]
        public void HatchTestMethod()
        {
            Document activeDoc= Application.DocumentManager.MdiActiveDocument;

            Editor ed = activeDoc.Editor;
            PromptEntityOptions peo= new PromptEntityOptions("Select a hatch : ");
            peo.SetRejectMessage("\nPlease select a hatch");

            peo.AddAllowedClass(typeof(Hatch), true);

            PromptEntityResult per = ed.GetEntity(peo);

            if (per.Status != PromptStatus.OK)
                return;

            HatchPerimeter(per.ObjectId);
        }

        void HatchPerimeter(ObjectId entId)
        {
            Document activeDoc = Application.DocumentManager.MdiActiveDocument;

            Database db = activeDoc.Database;

            Editor ed = activeDoc.Editor;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                Hatch hatch = tr.GetObject(entId, OpenMode.ForRead) as Hatch;

                int nLoops = hatch.NumberOfLoops;
                double totalExternalPerimeter = 0.0;
                double totalInternalPerimeter = 0.0;

                for (int i = 0; i < nLoops; i++)
                {
                    double loopLength = 0.0;

                    HatchLoopTypes hlt = hatch.LoopTypeAt(i);

                    HatchLoop hatchLoop = hatch.GetLoopAt(i);

                    if ((hatch.LoopTypeAt(i) & HatchLoopTypes.Polyline)== HatchLoopTypes.Polyline)
                    {
                        BulgeVertexCollection bulges= hatchLoop.Polyline;
                        int nVertices = bulges.Count;

                        Polyline testPoly = new Polyline(nVertices);

                        for (int vx = 0; vx < bulges.Count; vx++)
                        {
                            BulgeVertex bv = bulges[vx];

                            testPoly.AddVertexAt(vx,bv.Vertex,bv.Bulge,1.0,1.0);
                        }

                        LineSegment3d ls = new LineSegment3d();

                        CircularArc3d cs = new CircularArc3d();

                        double d = 0.0, p1 = 0.0, p2 = 1.0;

                        for (int ver = 0; ver < nVertices - 1; ver++)
                        {
                            d = testPoly.GetBulgeAt(ver);

                            if (d <= 1e-5)
                            {
                                ls = testPoly.GetLineSegmentAt(ver);

                                loopLength += ls.Length;

                            }

                            else
                            {

                                Point2d v1= new Point2d(bulges[ver].Vertex.X,bulges[ver].Vertex.Y);

                                Point2d v2= new Point2d(bulges[ver + 1].Vertex.X,bulges[ver + 1].Vertex.Y);

                                if (v1.IsEqualTo(v2) == false)
                                {

                                    cs = testPoly.GetArcSegmentAt(ver);

                                    p1 = cs.GetParameterOf(cs.StartPoint);

                                    p2 = cs.GetParameterOf(cs.EndPoint);

                                    loopLength +=cs.GetLength
                                        (p1,p2,Tolerance.Global.EqualPoint);

                                }
                            }
                        }
                    }

                    else
                    {
                        Curve2dCollection curves = hatchLoop.Curves;

                        if (curves != null)
                        {
                            foreach (Curve2d curve in curves)
                            {
                                if (hatchLoop.LoopType== HatchLoopTypes.External)
                                {
                                    totalExternalPerimeter +=curve.GetLength(0.0, 1.0);
                                }

                                else
                                {
                                    totalInternalPerimeter +=curve.GetLength(0.0, 1.0);

                                }
                            }
                        }
                    }

                    if (nLoops > 1 &&

                            ((hlt & HatchLoopTypes.External) != HatchLoopTypes.External))
                    {
                        totalInternalPerimeter += loopLength;
                    }
                    else
                    {
                        totalExternalPerimeter += loopLength;
                    }
                }
                ed.WriteMessage(string.Format("\nExternal Perimeter : {0}",totalExternalPerimeter));

                ed.WriteMessage(string.Format("\nInternal Perimeter : {0}",totalInternalPerimeter));

                tr.Commit();

            }

        }
    }
}
