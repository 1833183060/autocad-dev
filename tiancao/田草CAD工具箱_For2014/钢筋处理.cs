using System;
using System.Collections;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 钢筋处理
	{
		[DebuggerNonUserCode]
		public 钢筋处理()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcYuanJiao")]
		public void TcYuanJiao()
		{
			int num;
			int num34;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				ProjectData.ClearProjectError();
				num = -3;
				IL_11:
				int num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_1E:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_27:
				num2 = 5;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\n选择第一跟钢筋:");
					PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity(promptEntityOptions);
					Entity entity2 = (Entity)transaction.GetObject(entity.ObjectId, 1);
					if (Operators.CompareString(entity2.GetType().ToString(), "Autodesk.AutoCAD.DatabaseServices.Polyline", false) == 0)
					{
						Polyline polyline = (Polyline)entity2;
						double startWidthAt = polyline.GetStartWidthAt(0);
						string layer = polyline.Layer;
						Point2dCollection point2dCollection = new Point2dCollection();
						short num3;
						钢筋处理.Vertex[] array;
						short num5;
						short num6;
						checked
						{
							num3 = (short)(polyline.NumberOfVertices - 1);
							array = new 钢筋处理.Vertex[(int)(num3 + 1)];
							short num4 = 0;
							num5 = num3;
							num6 = num4;
						}
						for (;;)
						{
							short num7 = num6;
							short num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							point2dCollection.Add(polyline.GetPoint2dAt((int)num6));
							array[(int)num6].PT = polyline.GetPoint2dAt((int)num6);
							array[(int)num6].Bulge = polyline.GetBulgeAt((int)num6);
							array[(int)num6].StartWidth = polyline.GetStartWidthAt((int)num6);
							array[(int)num6].EndWidth = polyline.GetEndWidthAt((int)num6);
							num6 += 1;
						}
						short num9 = 1;
						short num10 = 1;
						Polyline polyline2;
						short num30;
						short num31;
						checked
						{
							short num11 = num3 - 1;
							short num12 = num10;
							for (;;)
							{
								short num13 = num12;
								short num8 = num11;
								if (num13 > num8)
								{
									break;
								}
								Point3d point3d;
								point3d..ctor(point2dCollection[(int)num12].X, point2dCollection[(int)num12].Y, 0.0);
								Point3d pt = point3d;
								Point3d point3d2;
								point3d2..ctor(point2dCollection[(int)(num12 - 1)].X, point2dCollection[(int)(num12 - 1)].Y, 0.0);
								double num14 = CAD.P2P_Angle(pt, point3d2);
								point3d2..ctor(point2dCollection[(int)num12].X, point2dCollection[(int)num12].Y, 0.0);
								Point3d pt2 = point3d2;
								point3d..ctor(point2dCollection[(int)(num12 + 1)].X, point2dCollection[(int)(num12 + 1)].Y, 0.0);
								double num15 = CAD.P2P_Angle(pt2, point3d);
								if (num14 != num15)
								{
									double bulge;
									unchecked
									{
										double num16 = point2dCollection[(int)num12].X - point2dCollection[(int)(checked(num12 - 1))].X;
										double num17 = point2dCollection[(int)num12].Y - point2dCollection[(int)(checked(num12 - 1))].Y;
										double num18 = point2dCollection[(int)(checked(num12 + 1))].X - point2dCollection[(int)num12].X;
										double num19 = point2dCollection[(int)(checked(num12 + 1))].Y - point2dCollection[(int)num12].Y;
										double num20 = num16 * num19 - num17 * num18;
										if (num20 < 0.0)
										{
											bulge = -Math.Tan(Math.Abs(num15 - num14) / 4.0);
										}
										else
										{
											bulge = Math.Tan(Math.Abs(num15 - num14) / 4.0);
										}
									}
									short num21 = (short)Information.UBound(array, 1);
									array = (钢筋处理.Vertex[])Utils.CopyArray((Array)array, new 钢筋处理.Vertex[(int)(num21 + 1 + 1)]);
									short num22 = num21 + 1;
									short num23 = unchecked(num12 + num9) + 1;
									short num24 = num22;
									for (;;)
									{
										short num25 = num24;
										num8 = num23;
										if (num25 < num8)
										{
											break;
										}
										array[(int)num24] = array[(int)(num24 - 1)];
										unchecked
										{
											num24 += -1;
										}
									}
									Curve curve = polyline;
									point3d2..ctor(point2dCollection[(int)num12].X, point2dCollection[(int)num12].Y, 0.0);
									double distAtPoint = curve.GetDistAtPoint(point3d2);
									double num26 = point2dCollection[(int)num12].GetDistanceTo(point2dCollection[(int)(num12 + 1)]);
									Point2d pt3 = point2dCollection[(int)num12];
									double distanceTo = pt3.GetDistanceTo(point2dCollection[(int)(num12 - 1)]);
									num26 = Math.Min(num26, distanceTo);
									num26 = Math.Min(num26, 70.0);
									unchecked
									{
										Point3d pointAtDist = polyline.GetPointAtDist(distAtPoint - num26);
										Point3d pointAtDist2 = polyline.GetPointAtDist(distAtPoint + num26);
										钢筋处理.Vertex[] array2 = array;
										int num27 = (int)(checked(unchecked(num12 + num9) - 1));
										pt3..ctor(pointAtDist.X, pointAtDist.Y);
										array2[num27] = this.SetVertex(pt3, bulge, startWidthAt, startWidthAt);
										钢筋处理.Vertex[] array3 = array;
										int num28 = (int)(num12 + num9);
										pt3..ctor(pointAtDist2.X, pointAtDist2.Y);
										array3[num28] = this.SetVertex(pt3, 0.0, startWidthAt, startWidthAt);
									}
									num9 += 1;
								}
								unchecked
								{
									num12 += 1;
								}
							}
							polyline2 = new Polyline();
							short num29 = 0;
							num30 = (short)(array.Length - 1);
							num31 = num29;
						}
						for (;;)
						{
							short num32 = num31;
							short num8 = num30;
							if (num32 > num8)
							{
								break;
							}
							polyline2.AddVertexAt((int)num31, array[(int)num31].PT, array[(int)num31].Bulge, array[(int)num31].StartWidth, array[(int)num31].EndWidth);
							num31 += 1;
						}
						CAD.AddEnt(polyline2);
						CAD.ChangeLayer(polyline2.ObjectId, layer);
						Class36.smethod_64(polyline.ObjectId);
					}
					transaction.Commit();
				}
				IL_5A4:
				num2 = 7;
				if (Information.Err().Number <= 0)
				{
					goto IL_5C9;
				}
				IL_5B5:
				num2 = 8;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_5C9:
				goto IL_649;
				IL_5CB:
				int num33 = num34 + 1;
				num34 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num33);
				IL_603:
				goto IL_63E;
				IL_605:
				num34 = num2;
				if (num <= -2)
				{
					goto IL_5CB;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_61B:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num34 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_605;
			}
			IL_63E:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_649:
			if (num34 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public 钢筋处理.Vertex SetVertex(Point2d PT, double Bulge, double StartWidth, double EndWidth)
		{
			钢筋处理.Vertex result;
			result.PT = PT;
			result.Bulge = Bulge;
			result.StartWidth = StartWidth;
			result.EndWidth = EndWidth;
			return result;
		}

		[CommandMethod("TcFJTC")]
		public void TcFJTC()
		{
			int num;
			int num8;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\n选择第一条负筋:");
					PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity(promptEntityOptions);
					Polyline polyline = (Polyline)transaction.GetObject(entity.ObjectId, 1);
					polyline.Highlight();
					promptEntityOptions = new PromptEntityOptions("\n选择第二条负筋:");
					entity = mdiActiveDocument.Editor.GetEntity(promptEntityOptions);
					Polyline polyline2 = (Polyline)transaction.GetObject(entity.ObjectId, 1);
					polyline2.Highlight();
					Point3d point3dAt = polyline.GetPoint3dAt(1);
					Point3d point3dAt2 = polyline.GetPoint3dAt(2);
					Point3d point3dAt3 = polyline2.GetPoint3dAt(1);
					Point3d point3dAt4 = polyline2.GetPoint3dAt(2);
					double num3 = point3dAt.DistanceTo(point3dAt3);
					double num4 = point3dAt.DistanceTo(point3dAt4);
					double num5 = point3dAt2.DistanceTo(point3dAt3);
					double num6 = point3dAt2.DistanceTo(point3dAt4);
					double max = this.GetMax(num3, num4, num5, num6);
					if (max == num3)
					{
						Point3d point3d_;
						Point3d point3d_2;
						if (Math.Abs(point3dAt.X - point3dAt3.X) < Math.Abs(point3dAt.Y - point3dAt3.Y))
						{
							point3d_..ctor(point3dAt.X, point3dAt.Y, 0.0);
							point3d_2..ctor(point3dAt.X, point3dAt3.Y, 0.0);
						}
						else
						{
							point3d_..ctor(point3dAt.X, point3dAt.Y, 0.0);
							point3d_2..ctor(point3dAt3.X, point3dAt.Y, 0.0);
						}
						Class36.smethod_37(point3d_, point3d_2);
					}
					else if (max == num4)
					{
						Point3d point3d_;
						Point3d point3d_2;
						if (Math.Abs(point3dAt.X - point3dAt4.X) < Math.Abs(point3dAt.Y - point3dAt4.Y))
						{
							point3d_..ctor(point3dAt.X, point3dAt.Y, 0.0);
							point3d_2..ctor(point3dAt.X, point3dAt4.Y, 0.0);
						}
						else
						{
							point3d_..ctor(point3dAt.X, point3dAt.Y, 0.0);
							point3d_2..ctor(point3dAt4.X, point3dAt.Y, 0.0);
						}
						Class36.smethod_37(point3d_, point3d_2);
					}
					else if (max == num5)
					{
						Point3d point3d_;
						Point3d point3d_2;
						if (Math.Abs(point3dAt2.X - point3dAt3.X) < Math.Abs(point3dAt2.Y - point3dAt3.Y))
						{
							point3d_..ctor(point3dAt2.X, point3dAt2.Y, 0.0);
							point3d_2..ctor(point3dAt2.X, point3dAt3.Y, 0.0);
						}
						else
						{
							point3d_..ctor(point3dAt2.X, point3dAt2.Y, 0.0);
							point3d_2..ctor(point3dAt3.X, point3dAt2.Y, 0.0);
						}
						Class36.smethod_37(point3d_, point3d_2);
					}
					else if (max == num6)
					{
						Point3d point3d_;
						Point3d point3d_2;
						if (Math.Abs(point3dAt2.X - point3dAt4.X) < Math.Abs(point3dAt2.Y - point3dAt4.Y))
						{
							point3d_..ctor(point3dAt2.X, point3dAt2.Y, 0.0);
							point3d_2..ctor(point3dAt2.X, point3dAt4.Y, 0.0);
						}
						else
						{
							point3d_..ctor(point3dAt2.X, point3dAt2.Y, 0.0);
							point3d_2..ctor(point3dAt4.X, point3dAt2.Y, 0.0);
						}
						Class36.smethod_37(point3d_, point3d_2);
					}
					polyline.Erase();
					polyline2.Erase();
					transaction.Commit();
				}
				IL_426:
				goto IL_492;
				IL_428:
				int num7 = num8 + 1;
				num8 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
				IL_44C:
				goto IL_487;
				IL_44E:
				num8 = num2;
				if (num <= -2)
				{
					goto IL_428;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_464:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num8 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_44E;
			}
			IL_487:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_492:
			if (num8 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public double GetMin(double D1, double D2, double D3, double D4)
		{
			double val = Math.Min(D1, D2);
			val = Math.Min(val, D3);
			return Math.Min(val, D4);
		}

		public double GetMax(double D1, double D2, double D3, double D4)
		{
			double val = Math.Max(D1, D2);
			val = Math.Max(val, D3);
			return Math.Max(val, D4);
		}

		[CommandMethod("TcBJJX1")]
		public void TcBJJX1()
		{
			int num;
			int num5;
			object obj4;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Application.SetSystemVariable("MIRRTEXT", 1);
				IL_1B:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_28:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_31:
				num2 = 5;
				string text = "FLOOR_UP_REIN,楼板负筋标注,楼板正筋钢筋,楼板负筋钢筋，FLOOR_DOWN_TEXT,楼板负筋文字,楼板正筋文字";
				IL_3A:
				num2 = 6;
				DBObjectCollection dbobjectCollection = new DBObjectCollection();
				IL_43:
				num2 = 7;
				DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
				IL_4C:
				num2 = 8;
				double radian;
				double height;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						Entity entity = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						Point3d point3d;
						Point3d point3d2;
						Class36.smethod_31(ref point3d, ref point3d2, "选择插入点:");
						Line3d line3d = new Line3d(point3d, point3d2);
						radian = line3d.Direction.AngleOnPlane(new Plane());
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity2 = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							if (entity2 is DBText & text.Contains(entity2.Layer))
							{
								DBText dbtext = (DBText)entity2;
								height = dbtext.Height;
								dbobjectCollection.Add(CAD.EntMirror(entity2, line3d, false));
							}
							else if (entity2 is Polyline & text.Contains(entity2.Layer))
							{
								dbobjectCollection2.Add(CAD.EntMirror(entity2, line3d, false));
							}
							else
							{
								CAD.EntMirror(entity2, line3d, false);
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_1BF:
				num2 = 10;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator2 = dbobjectCollection2.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						Polyline polyline = (Polyline)obj2;
						Polyline polyline2 = (Polyline)transaction2.GetObject(polyline.ObjectId, 1);
						Point3d pointAtDist = polyline2.GetPointAtDist(polyline2.Length / 2.0);
						Point3d pointRadian = CAD.GetPointRadian(pointAtDist, 100.0, radian);
						Point3d point3dAt = polyline2.GetPoint3dAt(1);
						Point3d point3dAt2 = polyline2.GetPoint3dAt(2);
						double num3 = point3dAt.GetVectorTo(point3dAt2).AngleOnPlane(new Plane());
						num3 = Math.Abs(num3 % 3.1415926535897931);
						Line3d l3d = new Line3d(pointAtDist, pointRadian);
						DBObjectCollection dbobjectCollection3 = new DBObjectCollection();
						CAD.GetFuJinDBText(polyline2, height, "", num3, ref dbobjectCollection3);
						IEnumerator enumerator3 = dbobjectCollection3.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							object obj3 = enumerator3.Current;
							DBText ent = (DBText)obj3;
							CAD.EntMirror(ent, l3d, true);
						}
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
						CAD.EntMirror(polyline2, l3d, true);
					}
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
					transaction2.Commit();
				}
				IL_329:
				num2 = 12;
				if (Information.Err().Number <= 0)
				{
					goto IL_350;
				}
				IL_33B:
				num2 = 13;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_350:
				goto IL_3E3;
				IL_355:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_39D:
				goto IL_3D8;
				IL_39F:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_355;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_3B5:;
			}
			catch when (endfilter(obj4 is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj5;
				goto IL_39F;
			}
			IL_3D8:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3E3:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcBJJX")]
		public void TcBJJX()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					Entity entity = (Entity)transaction.GetObject(value[0].ObjectId, 0);
					Point3d point3d;
					Point3d point3d2;
					Class36.smethod_31(ref point3d, ref point3d2, "选择插入点:");
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Entity entity2 = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
							if (Operators.CompareString(Class36.amIrsvPmtO(entity2.ObjectId), "DBText", false) == 0)
							{
								Point3d entCenter = CAD.GetEntCenter(entity2);
								Point3d targetPt = Class36.smethod_61(entCenter, point3d, point3d2);
								DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 0);
								double height = dbtext.Height;
								long num;
								checked
								{
									num = (long)Math.Round(Conversion.Int(unchecked(dbtext.Rotation * 360.0) / 3.1415926535897931 / 2.0));
									if (num > 270L)
									{
										num -= 360L;
									}
								}
								if (num >= 45L | num <= -45L)
								{
									if (Operators.CompareString(dbtext.Layer.ToString(), "楼板负筋标注", false) == 0)
									{
										targetPt..ctor(targetPt.X + height, targetPt.Y, targetPt.Z);
									}
									else if (Operators.CompareString(dbtext.Layer.ToString(), "楼板负筋文字", false) == 0)
									{
										targetPt..ctor(targetPt.X - 2.0 * height, targetPt.Y, targetPt.Z);
									}
									else if (Operators.CompareString(dbtext.Layer.ToString(), "楼板正筋文字", false) == 0)
									{
										targetPt..ctor(targetPt.X - 2.0 * height, targetPt.Y, targetPt.Z);
									}
								}
								CAD.EntCopy(entity2, entCenter, targetPt);
							}
							else if (Operators.CompareString(Class36.amIrsvPmtO(entity2.ObjectId), "Polyline", false) == 0 && entity2.Layer.Contains("筋"))
							{
								Point3d entCenter2 = CAD.GetEntCenter(entity2);
								Point3d targetPt2 = Class36.smethod_61(entCenter2, point3d, point3d2);
								CAD.EntCopy(entity2, entCenter2, targetPt2);
							}
							else
							{
								Line3d l3d = new Line3d(point3d, point3d2);
								CAD.EntMirror(entity2, l3d, false);
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcLBKD")]
		public void TcLBKD()
		{
			int num;
			int num11;
			object obj6;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				CAD.CreateLayer("楼板开洞", 7, "continuous", -1, false, true);
				IL_1F:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_2C:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				for (;;)
				{
					IL_7E6:
					num2 = 5;
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						Point3d point = CAD.GetPoint("在大板中间选择一点:");
						Point3d point3d;
						if (point == point3d)
						{
							break;
						}
						DBObjectCollection dbobjectCollection = new DBObjectCollection();
						DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
						double num3 = 500.0;
						this.GetFuJinPLAndLine1(point, "砼梁,砼柱", ref num3, ref dbobjectCollection, ref dbobjectCollection2);
						Point3d point3d2 = default(Point3d);
						Point3d point3d3 = default(Point3d);
						Point3d point3d4 = default(Point3d);
						Point3d point3d5 = default(Point3d);
						IEnumerator enumerator = dbobjectCollection2.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Entity entity = (Entity)obj;
							if (Operators.CompareString(entity.GetType().Name, "Line", false) != 0)
							{
								Point3d minPoint = entity.GeometricExtents.MinPoint;
								Point3d maxPoint = entity.GeometricExtents.MaxPoint;
								Point3d point3d6;
								point3d6..ctor((minPoint.X + maxPoint.X) / 2.0, (minPoint.Y + maxPoint.Y) / 2.0, (minPoint.Z + maxPoint.Z) / 2.0);
								double num4 = point.GetVectorTo(point3d6).AngleOnPlane(new Plane());
								num4 = num4 * 180.0 / 3.1415926535897931;
								if (0.0 < num4 & num4 < 90.0)
								{
									point3d2 = minPoint;
								}
								else if (90.0 < num4 & num4 < 180.0)
								{
									point3d3..ctor(maxPoint.X, minPoint.Y, maxPoint.Z);
								}
								else if (180.0 < num4 & num4 < 270.0)
								{
									point3d4 = maxPoint;
								}
								else if (270.0 < num4 & num4 < 360.0)
								{
									point3d5..ctor(minPoint.X, maxPoint.Y, maxPoint.Z);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						Line line = null;
						Line line2 = null;
						Line line3 = null;
						Line line4 = null;
						IEnumerator enumerator2 = dbobjectCollection.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							Entity entity2 = (Entity)obj2;
							Line line5 = (Line)entity2;
							if (point.X < line5.StartPoint.X && point.X < line5.EndPoint.X)
							{
								if (line2 == null)
								{
									line2 = line5;
								}
								else if (line5.StartPoint.X - point.X < line2.StartPoint.X - point.X)
								{
									line2 = line5;
								}
							}
						}
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
						IEnumerator enumerator3 = dbobjectCollection.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							object obj3 = enumerator3.Current;
							Entity entity3 = (Entity)obj3;
							Line line6 = (Line)entity3;
							if (point.X > line6.StartPoint.X && point.X > line6.EndPoint.X)
							{
								if (line == null)
								{
									line = line6;
								}
								else if (point.X - line6.StartPoint.X < point.X - line.StartPoint.X)
								{
									line = line6;
								}
							}
						}
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
						IEnumerator enumerator4 = dbobjectCollection.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							object obj4 = enumerator4.Current;
							Entity entity4 = (Entity)obj4;
							Line line7 = (Line)entity4;
							if (point.Y > line7.StartPoint.Y && point.Y > line7.EndPoint.Y)
							{
								if (line3 == null)
								{
									line3 = line7;
								}
								else if (point.Y - line7.StartPoint.Y < point.Y - line3.StartPoint.Y)
								{
									line3 = line7;
								}
							}
						}
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
						IEnumerator enumerator5 = dbobjectCollection.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							object obj5 = enumerator5.Current;
							Entity entity5 = (Entity)obj5;
							Line line8 = (Line)entity5;
							if (point.Y < line8.StartPoint.Y && point.Y < line8.EndPoint.Y)
							{
								if (line4 == null)
								{
									line4 = line8;
								}
								else if (line8.StartPoint.Y - point.Y < line4.StartPoint.Y - point.Y)
								{
									line4 = line8;
								}
							}
						}
						if (enumerator5 is IDisposable)
						{
							(enumerator5 as IDisposable).Dispose();
						}
						double num5 = Math.Min(line.Length, line2.Length);
						num5 = Math.Min(num5, line3.Length);
						num5 = Math.Min(num5, line4.Length);
						double a;
						double b;
						double c;
						钢筋处理.直线方程一般式_3D(line2.StartPoint, line2.EndPoint, ref a, ref b, ref c);
						line2.Linetype = "continuous";
						double num6;
						double b2;
						double num7;
						钢筋处理.直线方程一般式_3D(line.StartPoint, line.EndPoint, ref num6, ref b2, ref num7);
						double d = Math.Abs(1.5707963267948966 - Math.Abs(line.Angle));
						double c2 = num7 - num6 * num5 / 5.0 * Math.Cos(d);
						line.Linetype = "continuous";
						double a2;
						double b3;
						double c3;
						钢筋处理.直线方程一般式_3D(line3.StartPoint, line3.EndPoint, ref a2, ref b3, ref c3);
						line3.Linetype = "continuous";
						double a3;
						double num8;
						double num9;
						钢筋处理.直线方程一般式_3D(line4.StartPoint, line4.EndPoint, ref a3, ref num8, ref num9);
						double d2 = Math.Abs(3.1415926535897931 - Math.Abs(line4.Angle));
						double c4 = num9 - num8 * num5 / 5.0 * Math.Cos(d2);
						line4.Linetype = "continuous";
						Point3d p = 钢筋处理.直线与直线的交点_3D(a, b, c, a3, num8, num9);
						Point3d point3d7 = 钢筋处理.直线与直线的交点_3D(num6, b2, c2, a3, num8, c4);
						Point3d p2 = 钢筋处理.直线与直线的交点_3D(num6, b2, num7, a2, b3, c3);
						钢筋处理.直线与直线的交点_3D(a, b, c, a2, b3, c3);
						ObjectIdCollection objectIdCollection = new ObjectIdCollection();
						if (point3d4 != point3d)
						{
							objectIdCollection.Add(CAD.AddLine(point3d4, point3d7, "0").ObjectId);
						}
						else
						{
							objectIdCollection.Add(CAD.AddLine(p2, point3d7, "0").ObjectId);
						}
						if (point3d2 != point3d)
						{
							objectIdCollection.Add(CAD.AddLine(point3d7, point3d2, "0").ObjectId);
						}
						else
						{
							objectIdCollection.Add(CAD.AddLine(point3d7, p, "0").ObjectId);
						}
						CAD.ChangeLayer(objectIdCollection, "楼板开洞");
						transaction.Commit();
					}
				}
				IL_7FA:
				goto IL_872;
				IL_7FC:
				int num10 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_82C:
				goto IL_867;
				IL_82E:
				num11 = num2;
				if (num <= -2)
				{
					goto IL_7FC;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_844:;
			}
			catch when (endfilter(obj6 is Exception & num != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj7;
				goto IL_82E;
			}
			IL_867:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_872:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcDBJY")]
		public void TcDBJY()
		{
			int num;
			int num15;
			object obj6;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				CAD.CreateLayer("板加腋", 4, "DASH", -1, false, true);
				IL_1F:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_2C:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_35:
				num2 = 5;
				double num3 = 1000.0;
				IL_42:
				num2 = 6;
				double defaultValue = Conversions.ToDouble(Application.GetSystemVariable("USERR5"));
				IL_55:
				num2 = 7;
				PromptDistanceOptions promptDistanceOptions = new PromptDistanceOptions("\n板加腋宽度:");
				IL_63:
				num2 = 8;
				promptDistanceOptions.AllowNone = true;
				IL_6D:
				num2 = 9;
				promptDistanceOptions.AllowZero = false;
				IL_78:
				num2 = 10;
				promptDistanceOptions.DefaultValue = defaultValue;
				IL_84:
				num2 = 11;
				PromptDoubleResult distance = mdiActiveDocument.Editor.GetDistance(promptDistanceOptions);
				IL_96:
				num2 = 12;
				if (distance.Status == 5100)
				{
					goto IL_AC;
				}
				for (;;)
				{
					IL_895:
					num2 = 16;
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						Point3d point = CAD.GetPoint("在大板中间选择一点:");
						Point3d point3d;
						if (point == point3d)
						{
							goto IL_951;
						}
						DBObjectCollection dbobjectCollection = new DBObjectCollection();
						DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
						double num4 = 1000.0;
						this.GetFuJinPLAndLine(point, "砼梁,砼柱", ref num4, ref dbobjectCollection, ref dbobjectCollection2);
						IEnumerator enumerator = dbobjectCollection2.GetEnumerator();
						Point3d p;
						Point3d p2;
						Point3d p3;
						Point3d p4;
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Entity entity = (Entity)obj;
							if (Operators.CompareString(entity.GetType().Name, "Line", false) != 0)
							{
								Point3d minPoint = entity.GeometricExtents.MinPoint;
								Point3d maxPoint = entity.GeometricExtents.MaxPoint;
								Point3d point3d2;
								point3d2..ctor((minPoint.X + maxPoint.X) / 2.0, (minPoint.Y + maxPoint.Y) / 2.0, (minPoint.Z + maxPoint.Z) / 2.0);
								double num5 = point.GetVectorTo(point3d2).AngleOnPlane(new Plane());
								num5 = num5 * 180.0 / 3.1415926535897931;
								if (0.0 < num5 & num5 < 90.0)
								{
									p = minPoint;
								}
								else if (90.0 < num5 & num5 < 180.0)
								{
									p2..ctor(maxPoint.X, minPoint.Y, maxPoint.Z);
								}
								else if (180.0 < num5 & num5 < 270.0)
								{
									p3 = maxPoint;
								}
								else if (270.0 < num5 & num5 < 360.0)
								{
									p4..ctor(minPoint.X, maxPoint.Y, maxPoint.Z);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
						Line line = null;
						Line line2 = null;
						Line line3 = null;
						Line line4 = null;
						IEnumerator enumerator2 = dbobjectCollection.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							Entity entity2 = (Entity)obj2;
							Line line5 = (Line)entity2;
							if (point.X < line5.StartPoint.X && point.X < line5.EndPoint.X)
							{
								if (line2 == null)
								{
									line2 = line5;
								}
								else if (line5.StartPoint.X - point.X < line2.StartPoint.X - point.X)
								{
									line2 = line5;
								}
							}
						}
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
						double num6;
						double b;
						double num7;
						钢筋处理.直线方程一般式_3D(line2.StartPoint, line2.EndPoint, ref num6, ref b, ref num7);
						double d = Math.Abs(1.5707963267948966 - Math.Abs(line2.Angle));
						num7 -= num6 * num3 * Math.Cos(d);
						IEnumerator enumerator3 = dbobjectCollection.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							object obj3 = enumerator3.Current;
							Entity entity3 = (Entity)obj3;
							Line line6 = (Line)entity3;
							if (point.X > line6.StartPoint.X && point.X > line6.EndPoint.X)
							{
								if (line == null)
								{
									line = line6;
								}
								else if (point.X - line6.StartPoint.X < point.X - line.StartPoint.X)
								{
									line = line6;
								}
							}
						}
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
						double num8;
						double b2;
						double num9;
						钢筋处理.直线方程一般式_3D(line.StartPoint, line.EndPoint, ref num8, ref b2, ref num9);
						double d2 = Math.Abs(1.5707963267948966 - Math.Abs(line.Angle));
						num9 -= num8 * num3 * Math.Cos(d2);
						IEnumerator enumerator4 = dbobjectCollection.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							object obj4 = enumerator4.Current;
							Entity entity4 = (Entity)obj4;
							Line line7 = (Line)entity4;
							if (point.Y > line7.StartPoint.Y && point.Y > line7.EndPoint.Y)
							{
								if (line3 == null)
								{
									line3 = line7;
								}
								else if (point.Y - line7.StartPoint.Y < point.Y - line3.StartPoint.Y)
								{
									line3 = line7;
								}
							}
						}
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
						double a;
						double num10;
						double num11;
						钢筋处理.直线方程一般式_3D(line3.StartPoint, line3.EndPoint, ref a, ref num10, ref num11);
						double d3 = Math.Abs(3.1415926535897931 - Math.Abs(line3.Angle));
						num11 -= num10 * num3 * Math.Cos(d3);
						IEnumerator enumerator5 = dbobjectCollection.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							object obj5 = enumerator5.Current;
							Entity entity5 = (Entity)obj5;
							Line line8 = (Line)entity5;
							if (point.Y < line8.StartPoint.Y && point.Y < line8.EndPoint.Y)
							{
								if (line4 == null)
								{
									line4 = line8;
								}
								else if (line8.StartPoint.Y - point.Y < line4.StartPoint.Y - point.Y)
								{
									line4 = line8;
								}
							}
						}
						if (enumerator5 is IDisposable)
						{
							(enumerator5 as IDisposable).Dispose();
						}
						double a2;
						double num12;
						double num13;
						钢筋处理.直线方程一般式_3D(line4.StartPoint, line4.EndPoint, ref a2, ref num12, ref num13);
						double d4 = Math.Abs(3.1415926535897931 - Math.Abs(line4.Angle));
						num13 -= num12 * num3 * Math.Cos(d4);
						Point3d point3d3 = 钢筋处理.直线与直线的交点_3D(num6, b, num7, a2, num12, num13);
						Point3d point3d4 = 钢筋处理.直线与直线的交点_3D(num8, b2, num9, a2, num12, num13);
						Point3d point3d5 = 钢筋处理.直线与直线的交点_3D(num8, b2, num9, a, num10, num11);
						Point3d point3d6 = 钢筋处理.直线与直线的交点_3D(num6, b, num7, a, num10, num11);
						ObjectIdCollection objectIdCollection = new ObjectIdCollection();
						objectIdCollection.Add(CAD.AddLine(point3d3, p, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d4, p2, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d5, p3, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d6, p4, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d3, point3d4, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d4, point3d5, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d5, point3d6, "0").ObjectId);
						objectIdCollection.Add(CAD.AddLine(point3d6, point3d3, "0").ObjectId);
						CAD.ChangeLayer(objectIdCollection, "板加腋");
						transaction.Commit();
					}
				}
				IL_AC:
				num2 = 13;
				num3 = distance.Value;
				IL_B8:
				num2 = 14;
				Application.SetSystemVariable("USERR5", num3);
				goto IL_895;
				IL_8AA:
				goto IL_951;
				IL_8AF:
				int num14 = num15 + 1;
				num15 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num14);
				IL_90B:
				goto IL_946;
				IL_90D:
				num15 = num2;
				if (num <= -2)
				{
					goto IL_8AF;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_923:;
			}
			catch when (endfilter(obj6 is Exception & num != 0 & num15 == 0))
			{
				Exception ex = (Exception)obj7;
				goto IL_90D;
			}
			IL_946:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_951:
			if (num15 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public static Point3d 直线与直线的交点_3D(double A1, double B1, double C1, double A2, double B2, double C2)
		{
			Point3d result2;
			if (!(A1 == 0.0 & B1 == 0.0) && !(A2 == 0.0 & B2 == 0.0))
			{
				double num3;
				double num4;
				if (B1 * B2 != 0.0)
				{
					double num = -A1 / B1;
					double num2 = -A2 / B2;
					if (num == num2)
					{
						Point3d result;
						return result;
					}
					num3 = (B1 * C2 - B2 * C1) / (B2 * A1 - B1 * A2);
					num4 = (A1 * C2 - A2 * C1) / (A2 * B1 - A1 * B2);
				}
				else if (B1 == 0.0)
				{
					num3 = (B1 * C2 - B2 * C1) / (B2 * A1 - B1 * A2);
					num4 = (A1 * C2 - A2 * C1) / (A2 * B1 - A1 * B2);
				}
				else if (B2 == 0.0)
				{
					num3 = (B1 * C2 - B2 * C1) / (B2 * A1 - B1 * A2);
					num4 = (A1 * C2 - A2 * C1) / (A2 * B1 - A1 * B2);
				}
				else if (B1 == 0.0 & B2 == 0.0)
				{
					Point3d result;
					return result;
				}
				Point3d point3d;
				point3d..ctor(num3, num4, 0.0);
				result2 = point3d;
			}
			return result2;
		}

		public static bool 直线方程一般式_3D(Point3d P1, Point3d P2, ref double A, ref double B, ref double C)
		{
			A = P2.Y - P1.Y;
			B = P1.X - P2.X;
			C = P2.X * P1.Y - P1.X * P2.Y;
			return false;
		}

		public void GetFuJinPLAndLine(Point3d P, string LN, ref double Dist, ref DBObjectCollection Ls, ref DBObjectCollection Zs)
		{
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "LINE,LWPOLYLINE");
			array2.SetValue(typedValue, 0);
			if (Operators.CompareString(LN, "", false) != 0)
			{
				array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[2]);
				Array array3 = array;
				typedValue..ctor(8, LN);
				array3.SetValue(typedValue, 1);
			}
			Point3d point3d = P;
			Point3d point3d2 = P;
			Point3dCollection point3dCollection = new Point3dCollection();
			Point3dCollection point3dCollection2 = point3dCollection;
			Point3d point3d3;
			point3d3..ctor(point3d2.X - Dist, point3d2.Y - Dist, 0.0);
			point3dCollection2.Add(point3d3);
			Point3dCollection point3dCollection3 = point3dCollection;
			point3d3..ctor(point3d2.X - Dist, point3d.Y + Dist, 0.0);
			point3dCollection3.Add(point3d3);
			Point3dCollection point3dCollection4 = point3dCollection;
			point3d3..ctor(point3d.X + Dist, point3d.Y + Dist, 0.0);
			point3dCollection4.Add(point3d3);
			Point3dCollection point3dCollection5 = point3dCollection;
			point3d3..ctor(point3d.X + Dist, point3d2.Y - Dist, 0.0);
			point3dCollection5.Add(point3d3);
			DBObjectCollection dbobjectCollection = CAD.WindowPolygon(point3dCollection, array);
			if (dbobjectCollection.Count >= 1)
			{
				try
				{
					foreach (object obj in dbobjectCollection)
					{
						DBObject dbobject = (DBObject)obj;
						if (Operators.CompareString(dbobject.GetType().Name, "Line", false) == 0)
						{
							if (!Ls.Contains(dbobject))
							{
								Ls.Add(dbobject);
							}
						}
						else if (!Zs.Contains(dbobject))
						{
							Zs.Add(dbobject);
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				if (Zs.Count < 4)
				{
					Dist *= 1.2;
					this.GetFuJinPLAndLine(P, LN, ref Dist, ref Ls, ref Zs);
				}
			}
			else
			{
				Dist *= 1.2;
				this.GetFuJinPLAndLine(P, LN, ref Dist, ref Ls, ref Zs);
			}
		}

		public void GetFuJinPLAndLine1(Point3d P, string LN, ref double Dist, ref DBObjectCollection Ls, ref DBObjectCollection Zs)
		{
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "LINE,LWPOLYLINE");
			array2.SetValue(typedValue, 0);
			if (Operators.CompareString(LN, "", false) != 0)
			{
				array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[2]);
				Array array3 = array;
				typedValue..ctor(8, LN);
				array3.SetValue(typedValue, 1);
			}
			Point3d point3d = P;
			Point3d point3d2 = P;
			Point3dCollection point3dCollection = new Point3dCollection();
			Point3dCollection point3dCollection2 = point3dCollection;
			Point3d point3d3;
			point3d3..ctor(point3d2.X - Dist, point3d2.Y - Dist, 0.0);
			point3dCollection2.Add(point3d3);
			Point3dCollection point3dCollection3 = point3dCollection;
			point3d3..ctor(point3d2.X - Dist, point3d.Y + Dist, 0.0);
			point3dCollection3.Add(point3d3);
			Point3dCollection point3dCollection4 = point3dCollection;
			point3d3..ctor(point3d.X + Dist, point3d.Y + Dist, 0.0);
			point3dCollection4.Add(point3d3);
			Point3dCollection point3dCollection5 = point3dCollection;
			point3d3..ctor(point3d.X + Dist, point3d2.Y - Dist, 0.0);
			point3dCollection5.Add(point3d3);
			DBObjectCollection dbobjectCollection = CAD.WindowPolygon(point3dCollection, array);
			if (dbobjectCollection.Count >= 1)
			{
				try
				{
					foreach (object obj in dbobjectCollection)
					{
						DBObject dbobject = (DBObject)obj;
						if (Operators.CompareString(dbobject.GetType().Name, "Line", false) == 0)
						{
							if (!Ls.Contains(dbobject))
							{
								Ls.Add(dbobject);
							}
						}
						else if (!Zs.Contains(dbobject))
						{
							Zs.Add(dbobject);
						}
					}
				}
				finally
				{
					IEnumerator enumerator;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				if (Ls.Count < 8)
				{
					Dist *= 1.2;
					this.GetFuJinPLAndLine1(P, LN, ref Dist, ref Ls, ref Zs);
				}
			}
			else
			{
				Dist *= 1.2;
				this.GetFuJinPLAndLine1(P, LN, ref Dist, ref Ls, ref Zs);
			}
		}

		public struct Vertex
		{
			public short Index;

			public Point2d PT;

			public double Bulge;

			public double StartWidth;

			public double EndWidth;
		}
	}
}
