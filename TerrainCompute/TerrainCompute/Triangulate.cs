using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	public class Triangulate
	{
		public Triangulate()
		{            
			this.database_0 = HostApplicationServices.WorkingDatabase;
            this.editor_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			this.progressMeter_0 = new ProgressMeter();
			this.pane_0 = new Pane();
		}

		[CommandMethod("TCPlugin", "ng:DT",CommandFlags.Modal)]
		public void UserInterface()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			this.messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(this.messageFilter);
			try
			{				
				PointSet pointSet = new PointSet();
				ObjectId[] objectIDs = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.POINT, "Select triangulation points", false);
				if (objectIDs != null)
				{
					string text = " triangulation point";
					if (objectIDs.Length > 1)
					{
						text += "s";
					}
					editor.WriteMessage(objectIDs.Length + text + " selected.");
					pointSet.Add2(Conversions.ToCeometricPointSet2(objectIDs));
				}
				else
				{
					editor.WriteMessage("No triangulation points selected.\n");
				}
				List<Constraint> list = new List<Constraint>();
				ObjectId[] objectIDs2 = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.LINE, "Select constraints (lines)", false);
				if (objectIDs2 != null)
				{
					string text2 = " constraint";
					if (objectIDs2.Length > 1)
					{
						text2 += "s";
					}
					editor.WriteMessage(objectIDs2.Length + text2 + " selected.");
					List<Edge> list2 = Conversions.ToCeometricEdgeList(objectIDs2);
					for (int i = 0; i < list2.Count; i++)
					{
						list.Add(new Constraint(list2[i], Constraint.ConstraintType.Constraint));
					}
				}
				else
				{
					editor.WriteMessage("No constraints selected.\n");
				}
				if (pointSet.Count == 0 && list.Count == 0)
				{
					throw new ArgumentException("No triangulation points nor constraints.");
				}
				List<Constraint> bo = new List<Constraint>();
				int plCount = 0;
				ObjectId[] objectIDs3 = CommandLineQuerries.GetObjectIDs(CommandLineQuerries.EntityType.PLINES, "Select boundaries (polylines)", false);
				if (objectIDs3 != null)
				{
					string text3 = " boundary";
					if (objectIDs3.Length > 1)
					{
						text3 += "s";
					}
					editor.WriteMessage(objectIDs3.Length + text3 + " selected.");
					plCount = this.getPolylineCount(objectIDs3);
					List<Edge> list4 = Conversions.ToCeometricEdgeList(objectIDs3);
					for (int j = 0; j < list4.Count; j++)
					{
						bo.Add(new Constraint(list4[j], Constraint.ConstraintType.Boundary));
					}
				}
				else
				{
					editor.WriteMessage("No boundaries selected.\n");
				}
				if (list.Count > 0)
				{
					Triangulate.int_0 = CommandLineQuerries.SpecifyInteger("Maximum feasible constraint violations", Triangulate.int_0, 0, 2147483647, false, true);
				}
				editor.WriteMessage("\nInitial triangulation:");
				editor.WriteMessage("\n----------------------");
				editor.WriteMessage("\nInitial triangulation points  : " + pointSet.Count);
				editor.WriteMessage("\nInitial constraints           : " + list.Count);
				editor.WriteMessage("\nNumber of boundary regions    : " + plCount);
				editor.WriteMessage("\nInitial boundary segments     : " + bo.Count);
				editor.WriteMessage("\n");
				this.TriangulateInternal(pointSet, list, bo,null);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
			finally
			{
				try
				{
					this.progressMeter_0.Stop();
				}
                catch (System.Exception ex)
				{
                    Console.WriteLine("feef");
				}
				try
				{
					this.pane_0.Text=("");
					this.pane_0.Visible=(false);
                    Autodesk.AutoCAD.ApplicationServices.Application.StatusBar.Update();
                    Autodesk.AutoCAD.ApplicationServices.Application.StatusBar.Panes.Remove(this.pane_0);
				}
                catch (System.Exception ex)
				{
                    Console.WriteLine("efefe");
				}
				System.Windows.Forms.Application.DoEvents();
			}
		}

        public List<Triangle> TriangulateInternal(PointSet pointSet_0, List<Constraint> constraints, List<Constraint> boundaries,string layerName)
		{
            //这个filter使的命令可以在执行过程中被取消
            if (this.messageFilter == null)
            {
                this.messageFilter = new MessageFilter();
                System.Windows.Forms.Application.AddMessageFilter(this.messageFilter);
            }
            
			Constraint.UnreferenceEdges(constraints);
			Constraint.UnreferenceEdges(boundaries);
			Conversions.WcsToUcs(pointSet_0);
			Conversions.WcsToUcs(Constraint.GetEdges(constraints));
			Conversions.WcsToUcs(Constraint.GetEdges(boundaries));
			DBManager.SetEpsilon();
			KernelTimeGauge kernelTimeGauge = new KernelTimeGauge();
			kernelTimeGauge.Start();
			Triangulate.conformingDelaunayTriangulation2d_0 = new ConformingDelaunayTriangulation2d();
			Triangulate.conformingDelaunayTriangulation2d_0.PointInsertionHandler += new PointInsertionEventHandler(this.vmethod_0);
			Triangulate.conformingDelaunayTriangulation2d_0.IterationStepHandler += new IterationStepEventHandler(this.vmethod_1);
			Triangulate.conformingDelaunayTriangulation2d_0.TriangulationPoints = pointSet_0;
			Triangulate.conformingDelaunayTriangulation2d_0.Constraints = constraints;
			Triangulate.conformingDelaunayTriangulation2d_0.Boundaries = boundaries;
			Triangulate.conformingDelaunayTriangulation2d_0.MaximumFeasibleEdgeViolations = Triangulate.int_0;
			Triangulate.conformingDelaunayTriangulation2d_0.Triangulate();
			List<Triangle> triangles = Triangulate.conformingDelaunayTriangulation2d_0.GetTriangles();
			kernelTimeGauge.Stop();
			this.progressMeter_0.Stop();
			this.editor_0.WriteMessage("\nTriangulation results");
			this.editor_0.WriteMessage("\n---------------------");
			this.editor_0.WriteMessage("\nInvalid triangulation points  : " + Triangulate.conformingDelaunayTriangulation2d_0.BadPoints.Count);
			this.editor_0.WriteMessage("\nInvalid constraints/boundaries: " + Triangulate.conformingDelaunayTriangulation2d_0.BadConstraints.Count);
			this.editor_0.WriteMessage("\nDegenerate triangles          : " + Triangulate.conformingDelaunayTriangulation2d_0.BadTriangles.Count);
			this.editor_0.WriteMessage("\nSteiner points added          : " + Triangulate.conformingDelaunayTriangulation2d_0.NumberOfSteinerPoints);
			this.editor_0.WriteMessage("\nIterations for conformity     : " + Triangulate.conformingDelaunayTriangulation2d_0.NumberOfIterations);
			this.editor_0.WriteMessage("\nTotal triangulation points    : " + Triangulate.conformingDelaunayTriangulation2d_0.TriangulationPoints.Count.ToString());
			this.editor_0.WriteMessage("\nTotal triangles created       : " + triangles.Count.ToString());
			this.editor_0.WriteMessage("\nTotal time elapsed\n: " + kernelTimeGauge.DurationInMilliSeconds.ToString() + " ms\n\n");
			Conversions.UcsToWcs(Triangulate.conformingDelaunayTriangulation2d_0.TriangulationPoints);
			My.MyDBUtility.WriteListInDatabase<Triangle>(triangles, null, DBManager.EntityPropertiesAssignment.ByDialog, ObjectId.Null, ObjectId.Null,layerName);
            return triangles;
		}

		private int getPolylineCount(ObjectId[] objectId_0)
		{
			int num = 0;
			if (objectId_0 != null)
			{
				using (Transaction transaction = this.database_0.TransactionManager.StartTransaction())
				{
					for (int i = 0; i < objectId_0.Length; i++)
					{
                        DBObject @object = transaction.GetObject(objectId_0[i], (OpenMode)0);
						Polyline2d polyline2d = @object as Polyline2d;
						Polyline polyline = @object as Polyline;
						Polyline3d polyline3d = @object as Polyline3d;
						if (polyline2d != null)
						{
							if (!polyline2d.Closed)
							{
								throw new ArgumentException("At least one boundary polyline is not closed.\n");
							}
							double num2 = 0.0;
							List<Edge> list = Conversions.ToCeometricEdgeList(polyline2d);
							for (int j = 0; j < list.Count; j++)
							{
								num2 += list[j].Length;
							}
							double distanceAtParameter = polyline2d.GetDistanceAtParameter(polyline2d.EndParam);
							if (!Global.AlmostEquals(num2, distanceAtParameter))
							{
                                throw new System.Exception("At least one boundary polyline contains curved segments. Decurve the polyline first.\n");
							}
							num++;
						}
						else if (polyline != null)
						{
							if (!polyline.Closed)
							{
								throw new ArgumentException("At least one boundary polyline is not closed.\n");
							}
							if (!polyline.IsOnlyLines)
							{
                                throw new System.Exception("At least one boundary polyline contains curved segments. Decurve the polyline first.\n");
							}
							num++;
						}
						else
						{
							if (!(polyline3d != null))
							{
								throw new ArgumentException("Invalid polyline object: " + @object.Handle.ToString() + "\nObject type: " + @object.GetType().ToString());
							}
							if (!polyline3d.Closed)
							{
								throw new ArgumentException("At least one boundary polyline is not closed.\n");
							}
							double num3 = 0.0;
							List<Edge> list2 = Conversions.ToCeometricEdgeList(polyline3d);
							for (int k = 0; k < list2.Count; k++)
							{
								num3 += list2[k].Length;
							}
							double distanceAtParameter2 = polyline3d.GetDistanceAtParameter(polyline3d.EndParam);
							if (!Global.AlmostEquals(num3, distanceAtParameter2))
							{
                                throw new System.Exception("At least one boundary polyline contains curved segments. Decurve the polyline first.\n");
							}
							num++;
						}
					}
				}
			}
			return num;
		}

		internal virtual void vmethod_0(object sender, DelaunayTriangulation2d.PointInsertionEventArg e)
		{
			if (e.IsInitialTriangulationPoint)
			{
				if (e.Index == 0)
				{
					this.progressMeter_0 = new ProgressMeter();
					this.progressMeter_0.SetLimit(e.MaxIndex);
					this.progressMeter_0.Start("Triangulating...");
				}
				this.messageFilter.CheckMessageFilter((long)e.Index, 10000);
				this.progressMeter_0.MeterProgress();
				return;
			}
			this.progressMeter_0.Stop();
		}

		internal virtual void vmethod_1(object sender, ConformingDelaunayTriangulation2d.IterationStepEventArgs e)
		{
			if (e.CurrentIterationStep == 1)
			{
				this.pane_0.Style=(PaneStyles)(4);
				this.pane_0.Visible=(true);
                Autodesk.AutoCAD.ApplicationServices.Application.StatusBar.Panes.Add(this.pane_0);
			}
			/*this.pane_0.Text=(string.Concat(new string[]
			{
				"ITERATION PROCESS: current iteration: ",
				e.CurrentIterationStep.ToString().PadLeft(5),
				"  (edge violations: ",
				e.NumberOfPointsInserted.ToString().PadLeft(5),
				") "
			}));*/
			this.messageFilter.CheckMessageFilter();
			Autodesk.AutoCAD.ApplicationServices.Application.StatusBar.Update();
		}

		private static ConformingDelaunayTriangulation2d conformingDelaunayTriangulation2d_0;

		private Database database_0;

		private Editor editor_0;

		private static int int_0;

		private MessageFilter messageFilter;

		private Pane pane_0;

		private ProgressMeter progressMeter_0;
	}
}
