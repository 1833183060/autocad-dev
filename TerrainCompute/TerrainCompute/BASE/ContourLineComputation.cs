using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;
using TerrainComputeC.My;
using TerrainComputeC.Colorize;
namespace TerrainComputeC.BASE
{	
	public class ContourLineComputation
	{
		static ContourLineComputation()
		{
			ContourLineComputation.startElevation = 0.0;
			ContourLineComputation.endElevation = 0.0;
			ContourLineComputation.spacing = 1.0;
			ContourLineComputation.string_0 = "W";
			ContourLineComputation.whatCADData = "E";
			ContourLineComputation.prefix = "Contour_line_";
		}

        UserCmd cmd;
		public ContourLineComputation()
		{
            
		}       
        public void Contour(UserCmd cmd,string refrencePlan,double startElevation,double endElevation,double spacing,string whatCADData,string prefix)
        {
            this.cmd = cmd;
            MyDB2 mydb = cmd.mydb;
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                //ObjectId[] objectId_ = CommandLineQuerries.SelectFaces(false);
                ObjectId[] faceIDs = Selection.getFaceIds(mydb.getFaceLayerName());
                ContourLineComputation.string_0 = refrencePlan;
                CoordinateSystem coordinateSystem = CoordinateSystem.Global();
                if (ContourLineComputation.string_0 == "U")
                {
                    coordinateSystem = Conversions.GetUCS();
                }
                if (ContourLineComputation.string_0 == "3P")
                {
                    coordinateSystem = CommandLineQuerries.Specify3PSystem();
                }
                coordinateSystem.Orthonormalize();
                ContourLineComputation.startElevation = startElevation;
                ContourLineComputation.endElevation = Math.Max(ContourLineComputation.endElevation, ContourLineComputation.startElevation);
                bool flag = false;
                while (!flag)
                {
                    ContourLineComputation.endElevation = endElevation;
                    if (ContourLineComputation.startElevation > ContourLineComputation.endElevation)
                    {
                        editor.WriteMessage("\nStart elevation must be less or equal end elevation.");
                    }
                    else
                    {
                        flag = true;
                    }
                }
                ContourLineComputation.spacing = spacing;
                ContourLineComputation.whatCADData = whatCADData;//CommandLineQuerries.InsertOnLayer_Current_Face_Elevation_Index(ContourLineComputation.whichLayer);
                if (ContourLineComputation.whatCADData != "F" && ContourLineComputation.whatCADData != "C")
                {
                    ContourLineComputation.prefix = prefix;// CommandLineQuerries.SpecifyPrefixString(ContourLineComputation.prefix);
                }
                this.genContour2(faceIDs, coordinateSystem);
            }
            catch (System.Exception ex)
            {
                editor.WriteMessage("\n" + ex.Message + "\n");
            }
        }

		[CommandMethod("TCPlugin", "ng:FACES:CONTOUR", 0)]
		public void ContourCommand()
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				
				ObjectId[] objectId_ = CommandLineQuerries.SelectFaces(false);
				ContourLineComputation.string_0 = CommandLineQuerries.SpecifyReferencePlane(ContourLineComputation.string_0);
				CoordinateSystem coordinateSystem = CoordinateSystem.Global();
				if (ContourLineComputation.string_0 == "U")
				{
					coordinateSystem = Conversions.GetUCS();
				}
				if (ContourLineComputation.string_0 == "3P")
				{
					coordinateSystem = CommandLineQuerries.Specify3PSystem();
				}
				coordinateSystem.Orthonormalize();
				ContourLineComputation.startElevation = CommandLineQuerries.SpecifyDouble("Specify start elevation", ContourLineComputation.startElevation, false, true, false, true);
				ContourLineComputation.endElevation = Math.Max(ContourLineComputation.endElevation, ContourLineComputation.startElevation);
				bool flag = false;
				while (!flag)
				{
					ContourLineComputation.endElevation = CommandLineQuerries.SpecifyDouble("Specify end elevation", ContourLineComputation.endElevation, false, true, false, true);
					if (ContourLineComputation.startElevation > ContourLineComputation.endElevation)
					{
						editor.WriteMessage("\nStart elevation must be less or equal end elevation.");
					}
					else
					{
						flag = true;
					}
				}
				ContourLineComputation.spacing = CommandLineQuerries.SpecifyDouble("Specify spacing", ContourLineComputation.spacing, false, false, false, false);
				ContourLineComputation.whatCADData = CommandLineQuerries.InsertOnLayer_Current_Face_Elevation_Index(ContourLineComputation.whatCADData);
				if (ContourLineComputation.whatCADData != "F" && ContourLineComputation.whatCADData != "C")
				{
					ContourLineComputation.prefix = CommandLineQuerries.SpecifyPrefixString(ContourLineComputation.prefix);
				}
				this.genContour(objectId_, coordinateSystem);
			}
            catch (System.Exception ex)
			{
				editor.WriteMessage("\n" + ex.Message + "\n");
			}
		}

		internal void genContour(ObjectId[] objectId_0, CoordinateSystem coordinateSystem_0)
		{
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			CoordinateSystem coordinateSystem = CoordinateSystem.Global();
			try
			{
				if (objectId_0 == null)
				{
					throw new ArgumentException("No faces selected.");
				}
				int num = DBManager.SetEpsilon();
				int num2 = (int)Convert.ToInt16(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("LUPREC").ToString());
				num = Math.Min(num2 + 2, num);
				List<Triangle> list = Conversions.ToCeometricCADDataTriangleList(objectId_0);
				if (coordinateSystem_0 != coordinateSystem)
				{
					Triangle.TransformCoordinates(list, coordinateSystem, coordinateSystem_0);
				}
				else
				{
					coordinateSystem_0 = null;
				}
				int limit = (int)(Math.Abs(ContourLineComputation.endElevation - ContourLineComputation.startElevation) / ContourLineComputation.spacing);
				progressMeter.SetLimit(limit);
				progressMeter.Start("Computing contours");
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				double num8 = ContourLineComputation.startElevation;
				Plane plane = new Plane(new ngeometry.VectorGeometry.Point(0.0, 0.0, ContourLineComputation.startElevation), new Vector3d(0.0, 0.0, 1.0));
				while (num8 <= ContourLineComputation.endElevation)
				{
					progressMeter.MeterProgress();
					messageFilter.CheckMessageFilter();
					List<Edge> interEdgeList = this.getInterSection(list, plane, num3, ref num5, ref num4);
					num6 += DBManager.WritePlinesInDataBase(interEdgeList, coordinateSystem_0, num, false);
					if (interEdgeList.Count == 0)
					{
						editor.WriteMessage("\nNo contours at elevation : " + num8.ToString());
					}
					num7 += interEdgeList.Count;
					plane.Point.Z = num8;
					num8 += ContourLineComputation.spacing;
					num3++;
				}
				editor.WriteMessage("\nFailed intersections     : " + num5);
				editor.WriteMessage("\nDegenerate intersections : " + num4);
				editor.WriteMessage("\nTotal number of segments : " + num7);
				editor.WriteMessage("\nTotal number of polylines: " + num6);
				progressMeter.Stop();
			}
            catch (System.Exception ex)
			{
				progressMeter.Stop();
				throw;
			}
		}
        internal void genContour2(ObjectId[] objectId_0, CoordinateSystem coordinateSystem_0 )
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ProgressMeter progressMeter = new ProgressMeter();
            MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
            CoordinateSystem coordinateSystem = CoordinateSystem.Global();
            try
            {
                if (objectId_0 == null)
                {
                    throw new ArgumentException("No faces selected.");
                }
                string layerName=UserCmd.contourLNPrefix+cmd.mydb.Resolution;
                string assistLayerName = "contour_assist_" + cmd.mydb.Resolution;
                ObjectId layerId = LayerUtil.CreateLayer(layerName,127,true,false);
                ObjectId assistLayerId = LayerUtil.CreateLayer(assistLayerName,127,true,false);
                int num = DBManager.SetEpsilon();
                int num2 = (int)Convert.ToInt16(Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("LUPREC").ToString());
                num = Math.Min(num2 + 2, num);
                List<Triangle> list = Conversions.ToCeometricCADDataTriangleList(objectId_0);
                if (coordinateSystem_0 != coordinateSystem)
                {
                    Triangle.TransformCoordinates(list, coordinateSystem, coordinateSystem_0);
                }
                else
                {
                    coordinateSystem_0 = null;
                }
                int limit = (int)(Math.Abs(ContourLineComputation.endElevation - ContourLineComputation.startElevation) / ContourLineComputation.spacing);
                progressMeter.SetLimit(limit);
                progressMeter.Start("Computing contours");
                int num3 = 0;
                int num4 = 0;
                int num5 = 0;
                int num6 = 0;
                int num7 = 0;
                double maxZ=cmd.mydb.TEDicList[cmd.mydb.Resolution].maxMaxZ;
                double elevation = ContourLineComputation.startElevation;
                Plane plane = new Plane(new ngeometry.VectorGeometry.Point(0.0, 0.0, elevation), new Vector3d(0.0, 0.0, 1.0));
                cmd.mydb.assistContourDics[cmd.mydb.Resolution] = new AssistContourDic();
                while (elevation <= ContourLineComputation.endElevation)
                {
                    if (elevation >= maxZ) break;
                    progressMeter.MeterProgress();
                    messageFilter.CheckMessageFilter();
                    List<Edge> interEdgeList = this.getInterSection2(list, plane, num3, ref num5, ref num4);
                    if (interEdgeList.Count <= 0)
                    {
                        editor.WriteMessage("\nNo contours at elevation : " + elevation.ToString());
                        
                    }
                    else
                    {
                        Autodesk.AutoCAD.Geometry.Plane plane1 = new Autodesk.AutoCAD.Geometry.Plane(new Autodesk.AutoCAD.Geometry.Point3d(0,0,0),new Autodesk.AutoCAD.Geometry.Vector3d(0,0,1));
                        Autodesk.AutoCAD.Geometry.Matrix3d prjMat1 = Autodesk.AutoCAD.Geometry.Matrix3d.Projection(plane1, plane1.Normal);
                       TransformUtil.Transform(interEdgeList, prjMat1);
                       List<Polyline3d> pline3ds = new List<Polyline3d>();
                       List < PLine > pllist= DBManager.WritePlinesInDataBase2(interEdgeList, coordinateSystem_0, num, false, layerId, Color.White,pline3ds);
                       cmd.contColorize.addContour(pline3ds, elevation);
                       num6 += pllist.Count;
                    
                       double assistElevation = elevation + spacing / 2;
                        if (assistElevation >= maxZ)
                        {
                            assistElevation = elevation + (maxZ - elevation) / 2;
                        }
                        genAssistContour(list, plane, coordinateSystem_0, assistLayerId, assistElevation, num, num3);
                        num7 += interEdgeList.Count;
                    }
                    
                    elevation += ContourLineComputation.spacing;
                    plane.Point.Z = elevation;
                    num3++;
                }
                editor.WriteMessage("\nFailed intersections     : " + num5);
                editor.WriteMessage("\nDegenerate intersections : " + num4);
                editor.WriteMessage("\nTotal number of segments : " + num7);
                editor.WriteMessage("\nTotal number of polylines: " + num6);
                progressMeter.Stop();
            }
            catch (System.Exception ex)
            {
                progressMeter.Stop();
                throw;
            }
        }
        private List<Edge> genAssistContour(List<Triangle> list, Plane plane, CoordinateSystem userSystem, ObjectId layerId, double assistElevation, int relevantDecimals, int num3)
        {
            Editor editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            int num5 = 0; int num4 = 0;
            Plane assistPlane =plane.DeepCopy();
            assistPlane.Point.Z += assistElevation;
            
            List<Edge> unorderedEdges = this.getInterSection2(list, assistPlane, num3, ref num5, ref num4);
            if (unorderedEdges == null || unorderedEdges.Count <= 0)
            {
                return null;
            }
            Autodesk.AutoCAD.Geometry.Plane plane1 = new Autodesk.AutoCAD.Geometry.Plane(new Autodesk.AutoCAD.Geometry.Point3d(0, 0, 0), new Autodesk.AutoCAD.Geometry.Vector3d(0, 0, 1));
            Autodesk.AutoCAD.Geometry.Matrix3d prjMat1 = Autodesk.AutoCAD.Geometry.Matrix3d.Projection(plane1, plane1.Normal);
            TransformUtil.Transform(unorderedEdges, prjMat1);
            List<PLine> pllist=null;
            //pllist = DBManager.WritePlinesInDataBase2(unorderedEdges, userSystem, relevantDecimals, false, layerId, Color.White);
            
            int num = 0;
            int num2 = 0;
            int num33 = 0;
            Global.SuspendEpsilon(0.0, 0.0);
            try
            {
                if (userSystem != null)
                {
                    Conversions.ToWCS(userSystem, unorderedEdges);
                }
                //WritePlinesInDataBase2和ConstructFromUnorderedSegments只能调用一个
                if (pllist == null)
                {
                    pllist= PLine.ConstructFromUnorderedSegments(unorderedEdges, relevantDecimals, ref num2, ref num, ref num33, false, false, false);
                }
                 
                cmd.mydb.assistContourDics[cmd.mydb.Resolution].set(assistElevation + ContourLineComputation.spacing / 2, pllist);
                if (unorderedEdges.Count == 0)
                {
                    editor.WriteMessage("\nNo contours at elevation : " + assistElevation.ToString());
                }
            }
            catch (System.Exception ex)
            {
                editor.WriteMessage("genAssistContour error."+ex.Message);
            }
            Global.ResumeEpsilon();
            return unorderedEdges;
        }
		private List<Edge> getInterSection(List<Triangle> trs, Plane plane_0, int int_0, ref int int_1, ref int int_2)
		{
			List<Edge> list = new List<Edge>();
			string name = DBManager.CurrentLayerName();
			for (int i = 0; i < trs.Count; i++)
			{
				Triangle triangle = trs[i];
				double z = plane_0.Point.Z;
				if (triangle.MaximumZ > z && triangle.MinimumZ <= z)
				{
					Edge edge = null;
					try
					{
						edge = triangle.getInterSection(plane_0);
					}
                    catch (System.Exception ex)
					{
						int_1++;
						goto IL_1F7;
					}
					if (edge != null)
					{
						if (edge.Length >= Global.AbsoluteEpsilon)
						{
							if (ContourLineComputation.whatCADData == "E")
							{
								edge.CADData = trs[i].CADData.DeepCopy();
								edge.CADData.Layer.Name = ContourLineComputation.prefix + z.ToString();
								edge.CADData.BlockName = ContourLineComputation.prefix + z.ToString();
							}
							else if (ContourLineComputation.whatCADData == "I")
							{
								edge.CADData = trs[i].CADData.DeepCopy();
								edge.CADData.Layer.Name = ContourLineComputation.prefix + int_0.ToString();
								edge.CADData.BlockName = ContourLineComputation.prefix + int_0.ToString();
							}
							else if (ContourLineComputation.whatCADData == "F")
							{
								edge.CADData = trs[i].CADData;
							}
							else if (ContourLineComputation.whatCADData == "C")
							{
								edge.CADData = new CADData();
								edge.CADData.Layer.Name = name;
								edge.CADData.ColorIndex = 256;
								edge.CADData.Color = Color.Empty;
								edge.CADData.BlockName = "";
							}
							list.Add(edge);
						}
						else
						{
							int_2++;
						}
					}
					else
					{
						int_1++;
					}
				}
				IL_1F7:;
			}
			return list;
		}
        private List<Edge> getInterSection2(List<Triangle> trs, Plane plane_0, int int_0, ref int int_1, ref int int_2)
        {
            List<Edge> list = new List<Edge>();
            
            for (int i = 0; i < trs.Count; i++)
            {
                Triangle triangle = trs[i];
                double z = plane_0.Point.Z;
                if (triangle.MaximumZ > z && triangle.MinimumZ <= z)
                {
                    Edge edge = null;
                    try
                    {
                        edge = triangle.getInterSection(plane_0);
                    }
                    catch (System.Exception ex)
                    {
                        int_1++;
                        //goto IL_1F7;
                        continue;
                    }
                    if (edge != null)
                    {
                        if (edge.Length >= Global.AbsoluteEpsilon)
                        {
                            if (ContourLineComputation.whatCADData == "E")
                            {
                                edge.CADData = trs[i].CADData.DeepCopy();
                                edge.CADData.Layer.Name = ContourLineComputation.prefix;
                                edge.CADData.BlockName = ContourLineComputation.prefix + z.ToString();
                            }
                            
                            list.Add(edge);
                        }
                        else
                        {
                            int_2++;
                        }
                    }
                    else
                    {
                        int_1++;
                    }
                }
            IL_1F7: ;
            }
            return list;
        }

		private static double startElevation;

		private static double endElevation;

		private static double spacing;

		private static string string_0;

		private static string whatCADData;

		private static string prefix;
	}
}
