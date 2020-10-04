using System;
using System.Diagnostics;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class ModelSpace
	{
		[DebuggerNonUserCode]
		public ModelSpace()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		public static ObjectId AddLine(Point3d startPt, Point3d endPt)
		{
			Line ent = new Line(startPt, endPt);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddCircle(Point3d cenPt, double radius)
		{
			Circle ent = new Circle(cenPt, Vector3d.ZAxis, radius);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddCircle(Point2d pt1, Point2d pt2, Point2d pt3)
		{
			Vector2d vectorTo = pt1.GetVectorTo(pt2);
			Vector2d vectorTo2 = pt1.GetVectorTo(pt3);
			ObjectId result;
			if (vectorTo.GetAngleTo(vectorTo2) == 0.0 | vectorTo.GetAngleTo(vectorTo2) == 3.1415926535897931)
			{
				ObjectId @null = ObjectId.Null;
				result = @null;
			}
			else
			{
				CircularArc2d circularArc2d = new CircularArc2d(pt1, pt2, pt3);
				Point3d point3d;
				point3d..ctor(circularArc2d.Center.X, circularArc2d.Center.Y, 0.0);
				double radius = circularArc2d.Radius;
				Circle ent = new Circle(point3d, Vector3d.ZAxis, radius);
				ObjectId objectId = ModelSpace.AddEnt(ent);
				result = objectId;
			}
			return result;
		}

		public static ObjectId AddArc(Point3d cenPt, double radius, double startAng, double endAng)
		{
			Arc ent = new Arc(cenPt, radius, startAng, endAng);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddEllipse(Point3d cenPt, Vector3d majorAxis, double radiusRatio)
		{
			Ellipse ent = new Ellipse(cenPt, Vector3d.ZAxis, majorAxis, radiusRatio, 0.0, 6.2831853071795862);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddSpline(Point3dCollection pts)
		{
			Spline ent = new Spline(pts, 4, 0.0);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddPline(Point3dCollection pts, double width)
		{
			checked
			{
				ObjectId result;
				try
				{
					int count = pts.Count;
					Polyline polyline = new Polyline(count);
					int num = 0;
					int num2 = count - 1;
					int num3 = num;
					for (;;)
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						Polyline polyline2 = polyline;
						int num6 = num3;
						Point2d point2d;
						point2d..ctor(pts[num3].X, pts[num3].Y);
						polyline2.AddVertexAt(num6, point2d, 0.0, width, width);
						num3++;
					}
					ObjectId objectId = ModelSpace.AddEnt(polyline);
					result = objectId;
				}
				catch (Exception ex)
				{
					ObjectId @null = ObjectId.Null;
					result = @null;
				}
				return result;
			}
		}

		public static ObjectId smethod_0(Point3dCollection pts)
		{
			ObjectId result;
			try
			{
				Polyline3d ent = new Polyline3d(0, pts, false);
				ObjectId objectId = ModelSpace.AddEnt(ent);
				result = objectId;
			}
			catch (Exception ex)
			{
				ObjectId @null = ObjectId.Null;
				result = @null;
			}
			return result;
		}

		public static ObjectId AddText(Point3d position, string textString, double height, double oblique)
		{
			ObjectId result;
			try
			{
				ObjectId objectId = ModelSpace.AddEnt(new DBText
				{
					Position = position,
					TextString = textString,
					Height = height,
					Oblique = oblique
				});
				result = objectId;
			}
			catch (Exception ex)
			{
				ObjectId @null = ObjectId.Null;
				result = @null;
			}
			return result;
		}

		public static ObjectId AddText(Point3d position, string textString, ObjectId style, double height, double oblique, double rotation)
		{
			ObjectId result;
			try
			{
				ObjectId objectId = ModelSpace.AddEnt(new DBText
				{
					Position = position,
					TextString = textString,
					TextStyleId = style,
					Height = height,
					Oblique = oblique,
					Rotation = rotation
				});
				result = objectId;
			}
			catch (Exception ex)
			{
				ObjectId @null = ObjectId.Null;
				result = @null;
			}
			return result;
		}

		public static ObjectId AddMtext(Point3d location, string textString, double height, double width)
		{
			ObjectId result;
			try
			{
				ObjectId objectId = ModelSpace.AddEnt(new MText
				{
					Location = location,
					Contents = textString,
					TextHeight = height,
					Width = width
				});
				result = objectId;
			}
			catch (Exception ex)
			{
				ObjectId @null = ObjectId.Null;
				result = @null;
			}
			return result;
		}

		public static ObjectId AddMtext(Point3d location, string textString, ObjectId style, AttachmentPoint attachmentPoint, double height, double width)
		{
			ObjectId result;
			try
			{
				ObjectId objectId = ModelSpace.AddEnt(new MText
				{
					Location = location,
					Contents = textString,
					TextStyleId = style,
					Attachment = attachmentPoint,
					TextHeight = height,
					Width = width
				});
				result = objectId;
			}
			catch (Exception ex)
			{
				ObjectId @null = ObjectId.Null;
				result = @null;
			}
			return result;
		}

		public static ObjectId AddHatch(ObjectIdCollection[] objIds, int patType, string patName, double patternAngle, double patternScale)
		{
			checked
			{
				ObjectId result;
				try
				{
					Hatch hatch = new Hatch();
					hatch.HatchObjectType = 0;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					ObjectId objectId;
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
						BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, 0);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
						objectId = blockTableRecord.AppendEntity(hatch);
						transaction.AddNewlyCreatedDBObject(hatch, true);
						hatch.PatternAngle = patternAngle;
						hatch.PatternScale = patternScale;
						hatch.SetHatchPattern(patType, patName);
						hatch.Associative = true;
						int num = 0;
						int num2 = objIds.Length - 1;
						int num3 = num;
						for (;;)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							hatch.InsertLoopAt(num3, 0, objIds[num3]);
							num3++;
						}
						transaction.Commit();
					}
					result = objectId;
				}
				catch (Exception ex)
				{
					ObjectId @null = ObjectId.Null;
					result = @null;
				}
				return result;
			}
		}

		public static ObjectId AddHatch(ObjectIdCollection[] objIds, int gradientType, Color hColor1, Color hColor2, string gradientName, double gradientAngle)
		{
			checked
			{
				ObjectId result;
				try
				{
					Hatch hatch = new Hatch();
					hatch.HatchObjectType = 1;
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					ObjectId objectId;
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
						BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, 0);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
						objectId = blockTableRecord.AppendEntity(hatch);
						transaction.AddNewlyCreatedDBObject(hatch, true);
						GradientColor gradientColor;
						gradientColor..ctor(hColor1, 0f);
						GradientColor gradientColor2;
						gradientColor2..ctor(hColor2, 1f);
						GradientColor[] gradientColors = new GradientColor[]
						{
							gradientColor,
							gradientColor2
						};
						hatch.SetGradientColors(gradientColors);
						hatch.SetGradient(gradientType, gradientName);
						hatch.GradientAngle = gradientAngle;
						hatch.Associative = true;
						int num = 0;
						int num2 = objIds.Length - 1;
						int num3 = num;
						for (;;)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							hatch.InsertLoopAt(num3, 0, objIds[num3]);
							num3++;
						}
						transaction.Commit();
					}
					result = objectId;
				}
				catch (Exception ex)
				{
					ObjectId @null = ObjectId.Null;
					result = @null;
				}
				return result;
			}
		}

		public static ObjectId AddDimRotated(double angle, Point3d pt1, Point3d pt2, Point3d ptText)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			Point2d point2d;
			point2d..ctor(pt1.X, pt1.Y);
			Point2d point2d2;
			point2d2..ctor(pt2.X, pt2.Y);
			Vector2d vector2d = point2d2 - point2d;
			string text = Math.Round(Math.Abs(vector2d.Length * Math.Cos(vector2d.Angle - angle)), workingDatabase.Dimdec).ToString();
			RotatedDimension ent = new RotatedDimension(angle, pt1, pt2, ptText, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimRotated(double Ang, Point3d pt1, Point3d pt2, Point3d ptText, string text, ObjectId style)
		{
			RotatedDimension ent = new RotatedDimension(Ang, pt1, pt2, ptText, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimRotated1(double Ang, Point3d Pt1, Point3d Pt2, Point3d PtText, string text, ObjectId style)
		{
			RotatedDimension ent = new RotatedDimension(Ang, Pt1, Pt2, PtText, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimAligned(Point3d pt1, Point3d pt2, Point3d ptText)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			string text = Math.Round(pt1.DistanceTo(pt2), workingDatabase.Dimdec).ToString();
			AlignedDimension ent = new AlignedDimension(pt1, pt2, ptText, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimAligned1(Point3d pt1, Point3d pt2, Point3d ptText, string text, ObjectId style)
		{
			AlignedDimension alignedDimension = new AlignedDimension();
			alignedDimension.SetDatabaseDefaults();
			alignedDimension.XLine1Point = pt1;
			alignedDimension.XLine2Point = pt2;
			alignedDimension.DimLinePoint = ptText;
			alignedDimension.Dimlfac = 1.0;
			alignedDimension.DimensionStyle = style;
			if (Operators.CompareString(text, "", false) != 0)
			{
				alignedDimension.DimensionText = text;
			}
			return ModelSpace.AddEnt(alignedDimension);
		}

		public static ObjectId AddDimRadial(Point3d cenPt, Point3d ptChord, double leaderLength)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			string text = "R" + Math.Round(cenPt.DistanceTo(ptChord), workingDatabase.Dimdec).ToString();
			RadialDimension ent = new RadialDimension(cenPt, ptChord, leaderLength, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimRadial(Point3d cenPt, Point3d ptChord, double leaderLength, string text, ObjectId style)
		{
			RadialDimension ent = new RadialDimension(cenPt, ptChord, leaderLength, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimDiametric(Point3d ptChord1, Point3d ptChord2, double leaderLength)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			string text = "%%c" + Math.Round(ptChord1.DistanceTo(ptChord2), workingDatabase.Dimdec).ToString();
			DiametricDimension ent = new DiametricDimension(ptChord1, ptChord2, leaderLength, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimDiametric(Point3d ptChord1, Point3d ptChord2, double leaderLength, string text, ObjectId style)
		{
			DiametricDimension ent = new DiametricDimension(ptChord1, ptChord2, leaderLength, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimLineAngular(Point3d line1StartPt, Point3d point3d_0, Point3d line2StartPt, Point3d point3d_1, Point3d arcPt)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			Vector3d vector3d = point3d_0 - line1StartPt;
			Vector3d vector3d2 = point3d_1 - line2StartPt;
			double value = vector3d.GetAngleTo(vector3d2) * 180.0 / 3.1415926535897931;
			string text = Math.Round(value, workingDatabase.Dimadec).ToString() + "%%d";
			LineAngularDimension2 ent = new LineAngularDimension2(line1StartPt, point3d_0, line2StartPt, point3d_1, arcPt, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimLineAngular(Point3d line1StartPt, Point3d point3d_0, Point3d line2StartPt, Point3d point3d_1, Point3d arcPt, string text, ObjectId style)
		{
			LineAngularDimension2 ent = new LineAngularDimension2(line1StartPt, point3d_0, line2StartPt, point3d_1, arcPt, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimLineAngular(Point3d cenPt, Point3d line1Pt, Point3d line2Pt, Point3d arcPt)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			Vector3d vector3d = line1Pt - cenPt;
			Vector3d vector3d2 = line2Pt - cenPt;
			double value = vector3d.GetAngleTo(vector3d2, vector3d) * 180.0 / 3.1415926535897931;
			string text = Math.Round(value, workingDatabase.Dimadec).ToString() + "%%d";
			Point3AngularDimension ent = new Point3AngularDimension(cenPt, line1Pt, line2Pt, arcPt, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimLineAngular(Point3d cenPt, Point3d line1Pt, Point3d line2Pt, Point3d arcPt, string text, ObjectId style)
		{
			Point3AngularDimension ent = new Point3AngularDimension(cenPt, line1Pt, line2Pt, arcPt, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimArc(Point3d cenPt, Point3d pt1, Point3d pt2, Point3d arcPt)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			Vector3d vectorTo = cenPt.GetVectorTo(pt1);
			Vector3d vectorTo2 = cenPt.GetVectorTo(pt2);
			double angleTo = vectorTo.GetAngleTo(vectorTo2);
			double num = cenPt.DistanceTo(pt1);
			double value = angleTo * num;
			string text = Conversions.ToString(Math.Round(value, workingDatabase.Dimdec));
			ArcDimension ent = new ArcDimension(cenPt, pt1, pt2, arcPt, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimArc(Point3d cenPt, Point3d pt1, Point3d pt2, Point3d arcPt, string text, ObjectId style)
		{
			ArcDimension ent = new ArcDimension(cenPt, pt1, pt2, arcPt, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimOrdinate(bool useXAxis, Point3d ordPt, Point3d pt)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			string text;
			if (useXAxis)
			{
				text = Math.Round(ordPt.X, workingDatabase.Dimdec).ToString();
			}
			else
			{
				text = Math.Round(ordPt.Y, workingDatabase.Dimdec).ToString();
			}
			OrdinateDimension ent = new OrdinateDimension(useXAxis, ordPt, pt, text, dimstyle);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectId AddDimOrdinate(bool useXAxis, Point3d ordPt, Point3d pt, string text, ObjectId style)
		{
			OrdinateDimension ent = new OrdinateDimension(useXAxis, ordPt, pt, text, style);
			return ModelSpace.AddEnt(ent);
		}

		public static ObjectIdCollection AddDimOrdinate(Point3d ordPt, Point3d ptX, Point3d ptY)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId dimstyle = workingDatabase.Dimstyle;
			string text = Math.Round(ordPt.X, workingDatabase.Dimdec).ToString();
			string text2 = Math.Round(ordPt.Y, workingDatabase.Dimdec).ToString();
			OrdinateDimension ent = new OrdinateDimension(true, ordPt, ptX, text, dimstyle);
			OrdinateDimension ent2 = new OrdinateDimension(false, ordPt, ptY, text2, dimstyle);
			ObjectId objectId = ModelSpace.AddEnt(ent);
			ObjectId objectId2 = ModelSpace.AddEnt(ent2);
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			objectIdCollection.Add(objectId);
			objectIdCollection.Add(objectId2);
			return objectIdCollection;
		}

		public static ObjectIdCollection AddDimOrdinate(Point3d ordPt, Point3d ptX, Point3d ptY, string textX, string textY, ObjectId style)
		{
			ObjectIdCollection result;
			try
			{
				OrdinateDimension ent = new OrdinateDimension(true, ordPt, ptX, textX, style);
				OrdinateDimension ent2 = new OrdinateDimension(false, ordPt, ptY, textY, style);
				ObjectId objectId = ModelSpace.AddEnt(ent);
				ObjectId objectId2 = ModelSpace.AddEnt(ent2);
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				objectIdCollection.Add(objectId);
				objectIdCollection.Add(objectId2);
				result = objectIdCollection;
			}
			catch (Exception ex)
			{
				ObjectId @null = ObjectId.Null;
				ObjectIdCollection objectIdCollection2 = new ObjectIdCollection();
				objectIdCollection2.Add(@null);
				result = objectIdCollection2;
			}
			return result;
		}

		public static ObjectId AddLeader(Point3dCollection pts, bool splBool)
		{
			Leader leader = new Leader();
			leader.IsSplined = splBool;
			int num = 0;
			checked
			{
				int num2 = pts.Count - 1;
				int num3 = num;
				for (;;)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					leader.AppendVertex(pts[num3]);
					leader.SetVertexAt(num3, pts[num3]);
					num3++;
				}
				return ModelSpace.AddEnt(leader);
			}
		}

		public static ObjectId AddTolerance(string codes, Point3d inPt, Vector3d norVec, Vector3d xVec)
		{
			FeatureControlFrame ent = new FeatureControlFrame(codes, inPt, norVec, xVec);
			return ModelSpace.AddEnt(ent);
		}

		public static double Rad2Ang(double angle)
		{
			return angle * 3.1415926535897931 / 180.0;
		}

		public static Point3d PolarPoint(Point3d basePt, double angle, double distance)
		{
			double[] array = new double[]
			{
				basePt.get_Coordinate(0) + distance * Math.Cos(angle),
				basePt.get_Coordinate(1) + distance * Math.Sin(angle),
				basePt.get_Coordinate(2)
			};
			Point3d result;
			result..ctor(array[0], array[1], array[2]);
			return result;
		}

		public static ObjectId AddEnt(Entity Ent)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId result;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				result = blockTableRecord.AppendEntity(Ent);
				transaction.AddNewlyCreatedDBObject(Ent, true);
				transaction.Commit();
			}
			return result;
		}
	}
}
