using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.BASE
{	
	public class PLine : List<Edge>
	{
		static PLine()
		{
			PLine.edgeVertexList = new EdgeVertexList();
			PLine.string_0 = "Y";
			PLine.string_1 = "Y";
			PLine.int_0 = 8;
			PLine.double_0 = 0.0;
			PLine.string_2 = "N";
		}

		public PLine()
		{
            
		}


		public static List<PLine> ConstructFromUnorderedSegments(List<Edge> unorderedEdges, int relevantDecimals, ref int numberOfPLines, ref int numberOfSegments, ref int zeroLength, bool writeDatabase, bool useProgressMeter, bool eliminateZeroLengthSegments)
		{
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			List<PLine> list = new List<PLine>();
			PLine.edgeVertexList = new EdgeVertexList();
			if (useProgressMeter)
			{
				ProgressMeter arg_44_0 = progressMeter;
				int arg_44_1 = unorderedEdges.Count;
				//int arg_43_0 = unorderedEdges.Count;
				arg_44_0.SetLimit(arg_44_1);
			}
			if (useProgressMeter)
			{
				progressMeter.Start("Processing lines");
			}
			List<PLine> result;
			try
			{
				//"0." + "".PadLeft(relevantDecimals, '0');
				for (int i = 0; i < unorderedEdges.Count; i++)
				{
					if (useProgressMeter && i % 100 == 0)
					{
						progressMeter.MeterProgress();
					}
					Edge edge = unorderedEdges[i];
					edge.Round(relevantDecimals);
					PLine.edgeVertexList.Add(edge);
				}
				for (int j = 0; j < unorderedEdges.Count; j++)
				{
					if (useProgressMeter)
					{
						progressMeter.MeterProgress();
					}
					messageFilter.CheckMessageFilter((long)j, 100);
					if (unorderedEdges[j].Status == Edge.EdgeStatus.NotDefined)
					{
						PLine pLine = new PLine();
						pLine.caddata = unorderedEdges[j].CADData;
						List<Edge> list2 = PLine.smethod_0(unorderedEdges[j],pLine);
						pLine.AddRange(list2);
						pLine.Add(unorderedEdges[j]);
						unorderedEdges[j].Status = Edge.EdgeStatus.NotDefined;
						List<Edge> list3 = PLine.smethod_1(unorderedEdges[j],pLine);
						pLine.AddRange(list3);
						double num = Math.Pow(10.0, (double)(-(double)relevantDecimals));
						int num2 = 0;
						if (pLine.Count == 1 && pLine[0].Length < num)
						{
							zeroLength++;
							num2++;
							if (eliminateZeroLengthSegments)
							{
								//goto IL_231;
                                continue;
							}
						}
						else
						{
							for (int k = pLine.Count - 2; k >= 0; k--)
							{
								if (pLine[k].Length < num)
								{
									if (eliminateZeroLengthSegments)
									{
										pLine[k + 1].StartPoint = pLine[k].StartPoint;
										pLine.RemoveAt(k);
									}
									zeroLength++;
									num2++;
								}
							}
						}
						if (pLine.Count != 0)
						{
                            List<PLine> pllist = PLine.splitSelfIntersectionPline(pLine);
                            for (int ii = 0; ii < pllist.Count; ii++)
                            {
                                list.Add(pllist[ii]);
                                if (writeDatabase)
                                {
                                    PLine.WriteInDatabase(pllist[ii]);
                                }
                            }
                                //list.Add(pLine);
							if (!eliminateZeroLengthSegments)
							{
								num2 = 0;
							}
							numberOfSegments += list2.Count + list3.Count - num2 + 1;
							numberOfPLines++;

							/*if (writeDatabase)
							{
								PLine.WriteInDatabase(pLine);
							}*/
						}
					}
					//IL_231:;
				}
				if (useProgressMeter)
				{
					progressMeter.Stop();
				}
				result = list;
			}
            catch (System.Exception ex)
			{
				if (useProgressMeter)
				{
					progressMeter.Stop();
				}
				throw;
			}
			return result;
		}

		public PointSet GetVertices()
		{
			PointSet pointSet = new PointSet();
			for (int i = 0; i < base.Count; i++)
			{
				pointSet.Add(base[i].StartPoint);
			}
			pointSet.Add(base[base.Count - 1].EndPoint);
			return pointSet;
		}

		[CommandMethod("TCPlugin", "ng:LINES:TOPLINE", 0)]
		public void LinesToPolylines()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database arg_15_0 = HostApplicationServices.WorkingDatabase;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] objectId_ = CommandLineQuerries.SelectLines(false);
				PLine.int_0 = CommandLineQuerries.SpecifyInteger("Specify number of relevant decimal digits", PLine.int_0, 0, 12, false, true);
				PLine.string_1 = CommandLineQuerries.KeywordYesNo("Eliminate zero length segments", PLine.string_1, false, false);
				PLine.string_0 = CommandLineQuerries.KeywordYesNo("Delete original lines", PLine.string_0, false, false);
				this.method_0(objectId_);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private void method_0(ObjectId[] objectId_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Global.SuspendEpsilon(0.0, 0.0);
			try
			{
				List<Edge> unorderedEdges = Conversions.ToCeometricCADDataEdgeList(objectId_0);
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				bool eliminateZeroLengthSegments = true;
				if (PLine.string_1.Trim().ToUpper() == "N")
				{
					eliminateZeroLengthSegments = false;
				}
				PLine.ConstructFromUnorderedSegments(unorderedEdges, PLine.int_0, ref num2, ref num, ref num3, true, true, eliminateZeroLengthSegments);
				if (PLine.string_0 == "Y")
				{
					DBManager.EraseObjects(objectId_0, 100000);
				}
				editor.WriteMessage("\nNumber of segments added      : " + num.ToString());
				editor.WriteMessage("\nNumber of zero-length segments: " + num3.ToString());
				editor.WriteMessage("\nNumber of polylines generated : " + num2.ToString());
				Global.ResumeEpsilon();
			}
            catch (System.Exception ex)
			{
				Global.ResumeEpsilon();
				editor.WriteMessage("\n" + ex.Message);
			}
		}

		private void method_1(ObjectId[] objectId_0, double double_1, ref int int_1, ref int int_2, ref int int_3)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
            Editor arg_15_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			progressMeter.SetLimit(objectId_0.Length);
			progressMeter.Start("Simplifying polylines");
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
                    BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                    BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
					for (int i = 0; i < objectId_0.Length; i++)
					{
						try
						{
							progressMeter.MeterProgress();
							messageFilter.CheckMessageFilter((long)i, 10);
                            DBObject @object = transaction.GetObject(objectId_0[i], (OpenMode)1);
							bool flag = false;
							Polyline polyline = @object as Polyline;
							if (polyline != null)
							{
								flag = polyline.Closed;
							}
							Polyline2d polyline2d = @object as Polyline2d;
							if (polyline2d != null)
							{
								flag = polyline2d.Closed;
							}
							Polyline3d polyline3d = @object as Polyline3d;
							if (polyline3d != null)
							{
								flag = polyline3d.Closed;
							}
							List<ngeometry.VectorGeometry.Point> p = PointGeneration.SubdividePolyline(@object, transaction, 0.0).ToList();
							int_1 += Conversions.GetNumberOfPoyllineVertices(@object);
							List<ngeometry.VectorGeometry.Point> list = this.method_2(p, double_1);
							int_2 += list.Count;
							Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(list);
							Polyline3d polyline3d2 = new Polyline3d(0, point3dCollection, flag);
							polyline3d2.SetPropertiesFrom((Entity)@object);
							if (PLine.string_2 == "N" & !@object.IsErased)
							{
								@object.Erase();
							}
							blockTableRecord.AppendEntity(polyline3d2);
							transaction.AddNewlyCreatedDBObject(polyline3d2, true);
						}
                        catch (System.Exception ex)
						{
							int_3++;
						}
					}
					transaction.Commit();
				}
				progressMeter.Stop();
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw ex;
			}
		}

		private List<ngeometry.VectorGeometry.Point> method_2(List<ngeometry.VectorGeometry.Point> p, double double_1)
		{
			if (p.Count < 3)
			{
				return p;
			}
			List<ngeometry.VectorGeometry.Point> list = new List<ngeometry.VectorGeometry.Point>();
			list.Add(p[0]);
			int i = 0;
			int num = 1;
			while (i < p.Count)
			{
				bool flag = true;
				IL_96:
				while (flag)
				{
					Edge edge = new Edge(p[i], p[i + num + 1]);
					int j = i + 1;
					while (j < i + num + 1)
					{
						if (p[j].DistanceTo(edge) <= double_1)
						{
							j++;
						}
						else
						{
							flag = false;
							i += num;
							num = 1;
							list.Add(p[i]);
							IL_80_:
							if (flag)
							{
								num++;
							}
							if (i + num == p.Count - 1)
							{
								list.Add(p[p.Count - 1]);
								return list;
							}
							goto IL_96;
						}
					}
					goto IL_80;
                IL_80:
                    {
                    
                        if (flag)
                        {
                            num++;
                        }
                        if (i + num == p.Count - 1)
                        {
                            list.Add(p[p.Count - 1]);
                            return list;
                        }
                        goto IL_96;
                    }
				}
			}
            throw new System.Exception("Unable to compute simplified polyline");
		}

		[CommandMethod("TCPlugin", "ng:LINES:SIMPLIFYPLINE", 0)]
		public void SimplifyPolylinesCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database arg_15_0 = HostApplicationServices.WorkingDatabase;
			try
			{
				//LicenseManager.CheckValid("FULL");
				ObjectId[] array = CommandLineQuerries.SelectPolylines(false);
				PLine.double_0 = CommandLineQuerries.SpecifyDouble("Specify epsilon range", PLine.double_0, false, false, false, true);
				PLine.string_2 = CommandLineQuerries.KeywordYesNo("Keep original polylines", PLine.string_2, false, false);
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				this.method_1(array, PLine.double_0, ref num, ref num2, ref num3);
				editor.WriteMessage(string.Concat(new string[]
				{
					"\nNumber of vertices before    : ",
					num.ToString(),
					"\nNumber of vertices after     : ",
					num2.ToString(),
					"\nNumber of polylines processed: ",
					array.Length.ToString(),
					"\nNumber of polylines failed   : ",
					num3.ToString()
				}));
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage(Environment.NewLine + ex.Message + Environment.NewLine);
			}
		}

		private static List<Edge> _smethod_0(Edge edge_0)
		{
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<Edge> list = new List<Edge>();
			Edge edge = edge_0;
			IL_C3:
			while (edge.Status == Edge.EdgeStatus.NotDefined)
			{
				edge.Status = Edge.EdgeStatus.Defined;
				List<Edge> list2 = PLine.edgeVertexList[edge.StartPoint];
				if (list2.Count != 0)
				{
					if (list2.Count != 1)
					{
						bool flag = false;
						int i = 0;
						while (i < list2.Count)
						{
							Edge edge2 = list2[i];
							if (edge2.Status != Edge.EdgeStatus.NotDefined || !(edge2 != edge) || !(edge2.CADData == edge.CADData))
							{
								i++;
							}
							else
							{
								if (edge.StartPoint == edge2.StartPoint)
								{
									edge2.SwapPoints();
								}
								list.Add(edge);
								edge = edge2;
								flag = true;
								IL_C0_:
								if (flag)
								{
									goto IL_C3;
								}
								list.Add(edge);
								goto IL_EC;
							}
						}
						goto IL_C0;
                    IL_C0:
                        {
                       
                            if (flag)
                            {
                                goto IL_C3;
                            }
                            list.Add(edge);
                            goto IL_EC;
                        }
					}
					list.Add(edge);
					IL_EC_:
					if (list.Count > 0)
					{
						list.RemoveAt(0);
					}
					list.Reverse();
					return list;
				}
                throw new System.Exception("No incident edges.");
			}
            goto IL_EC;
        IL_EC:
            {
           
                if (list.Count > 0)
                {
                    list.RemoveAt(0);
                }
                list.Reverse();
                return list;
            }
		}

        private static List<Edge> smethod_0(Edge edge_0,PLine pline)
        {//去掉原代码的goto等
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            List<Edge> list = new List<Edge>();
            Edge edge = edge_0;
        IL_C3:
            while (edge.Status == Edge.EdgeStatus.NotDefined)
            {
                edge.Status = Edge.EdgeStatus.Defined;
                List<Edge> list2 = PLine.edgeVertexList[edge.StartPoint];
                if (list2.Count > 2)
                {
                    pline.addSelfInterPoints(edge.StartPoint);
                }
                if (list2.Count != 0)
                {
                    if (list2.Count != 1)
                    {
                        bool flag = false;
                        int i = 0;
                        while (i < list2.Count)
                        {
                            Edge edge2 = list2[i];
                            if (edge2.Status != Edge.EdgeStatus.NotDefined || !(edge2 != edge) || !(edge2.CADData == edge.CADData))
                            {
                                i++;
                            }
                            else
                            {
                                if (edge.StartPoint == edge2.StartPoint)
                                {
                                    edge2.SwapPoints();
                                }
                                list.Add(edge);
                                edge = edge2;
                                flag = true;
                            IL_C0_:
                                if (flag)
                                {
                                    goto IL_C3;
                                }
                                list.Add(edge);
                                goto IL_EC;
                            }
                        }
                        goto IL_C0;
                    IL_C0:
                        {

                            if (flag)
                            {
                                goto IL_C3;
                            }
                            list.Add(edge);
                            goto IL_EC;
                        }
                    }
                    list.Add(edge);
                IL_EC_:
                    if (list.Count > 0)
                    {
                        list.RemoveAt(0);
                    }
                    list.Reverse();
                    return list;
                }
                throw new System.Exception("No incident edges.");
            }
            goto IL_EC;
        IL_EC:
            {

                if (list.Count > 0)
                {
                    list.RemoveAt(0);
                }
                list.Reverse();
                return list;
            }
        }

		private static List<Edge> smethod_1(Edge edge_0,PLine pline)
		{
            Editor arg_0F_0 = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<Edge> list = new List<Edge>();
			Edge edge = edge_0;
			IL_C3:
			while (edge.Status == Edge.EdgeStatus.NotDefined)
			{
				edge.Status = Edge.EdgeStatus.Defined;
				List<Edge> list2 = PLine.edgeVertexList[edge.EndPoint];
                if (list2.Count > 2)
                {
                    pline.addSelfInterPoints(edge.EndPoint);
                }
				if (list2.Count != 0)
				{
					if (list2.Count != 1)
                    {
                        bool flag = false;
                        int i = 0;
                        while (i < list2.Count)
                        {
                            Edge edge2 = list2[i];
                            if (edge2.Status != Edge.EdgeStatus.NotDefined || !(edge2 != edge) || !(edge2.CADData == edge.CADData))
                            {
                                i++;
                            }
                            else
                            {
                                if (edge.EndPoint == edge2.EndPoint)
                                {
                                    edge2.SwapPoints();
                                }
                                list.Add(edge);
                                edge = edge2;
                                flag = true;
                            IL_C0_:
                                if (flag)
                                {
                                    goto IL_C3;
                                }
                                list.Add(edge);
                                goto IL_EC;
                            }
                        }
                        goto IL_C0;
                    IL_C0:
                        {
                        
                            if (flag)
                            {
                                goto IL_C3;
                            }
                            list.Add(edge);
                            goto IL_EC;
                        }
                    }
					list.Add(edge);
					IL_EC_:
					if (list.Count > 0)
					{
						list.RemoveAt(0);
					}
					return list;
				}
                throw new System.Exception("No incident edges.");
			}
			goto IL_EC;
            IL_EC:
            {
            
                if (list.Count > 0)
                {
                    list.RemoveAt(0);
                }
                return list;
            }
		}

		public static void WriteInDatabase(PLine pline)
		{
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
                BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)0);
                BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
				List<ngeometry.VectorGeometry.Point> list = pline.GetVertices().ToList();
				if (pline.IsClosed)
				{
					list.RemoveAt(list.Count - 1);
				}
				Point3dCollection point3dCollection = Conversions.ToPoint3dCollection(list);
				Polyline3d polyline3d = new Polyline3d(0, point3dCollection, false);
				point3dCollection.Dispose();
				if (pline.IsClosed)
				{
					polyline3d.Closed=(true);
				}
				bool flag = false;
				polyline3d.LayerId=(DBManager.CreateLayer(pline.CADData.Layer.Name, 7, false, ref flag));
                Autodesk.AutoCAD.Colors.Color color = null;
				short colorIndex = pline.CADData.ColorIndex;
				if (pline.CADData.Color != System.Drawing.Color.Empty)
				{
					color =Autodesk.AutoCAD.Colors.Color.FromColor(pline.CADData.Color);
				}
				if (color == null)
				{
					polyline3d.ColorIndex=((int)colorIndex);
				}
				else
				{
					polyline3d.Color=(color);
				}
                
               
                
                //polyline3d.StartPoint.X
				blockTableRecord.AppendEntity(polyline3d);
				transaction.AddNewlyCreatedDBObject(polyline3d, true);
				transaction.Commit();
			}
		}

        public static List<PLine> splitSelfIntersectionPline(PLine pline)
        {
            List<PLine> r=new List<PLine>();
            PLine pl = new PLine();
            for (int i = 0; i < pline.Count; i++)
            {                
                pl.CADData = pline.CADData;
                Edge e = pline[i];
                pl.Add(e);
                int index = pline.findSelfInterPoint(e.EndPoint);
                if (index >= 0)
                {
                    r.Add(pl);
                    pl = new PLine();
                }
            }
            if (pl.Count > 0)
            {
                r.Add(pl);
            }
            return r;
        }
        public int findSelfInterPoint(ngeometry.VectorGeometry.Point p)
        {
            int index = selfIntersectionPoints.FindIndex(item =>
            {
                ngeometry.VectorGeometry.Point pp = item as ngeometry.VectorGeometry.Point;
                if (Math.Abs(pp.X - p.X) <= 1e-10 && Math.Abs(pp.Y - p.Y) <= 1e-10)
                {
                    return true;
                }
                return false;
            });
            return index;
        }
        public void addSelfInterPoints(ngeometry.VectorGeometry.Point p)
        {
            int index = findSelfInterPoint(p);
            if (index >= 0) return;
            selfIntersectionPoints.Add(p);
        }
        #region 属性和字段

        List<ngeometry.VectorGeometry.Point> selfIntersectionPoints=new List<ngeometry.VectorGeometry.Point>();
        public CADData CADData
		{
			get
			{
				return this.caddata;
			}
			set
			{
				this.caddata = value;
			}
		}

		public bool IsClosed
		{
			get
			{
				bool result = false;
				if (base[0].StartPoint == base[base.Count - 1].EndPoint)
				{
					result = true;
				}
				if (base.Count == 1)
				{
					result = false;
				}
				return result;
			}
		}

		private CADData caddata;

		private static double double_0;

		private static EdgeVertexList edgeVertexList;

		private static int int_0;

		private static string string_0;

		private static string string_1;

		private static string string_2;
        #endregion
    }
}
