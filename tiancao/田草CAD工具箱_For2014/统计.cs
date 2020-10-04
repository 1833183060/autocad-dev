using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
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
	public class 统计
	{
		[DebuggerNonUserCode]
		public 统计()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDXBH")]
		public void TcDXBH()
		{
			int num;
			int num13;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Point3d[] array = null;
				IL_0D:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_1A:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_24:
				num2 = 5;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_37:
				num2 = 6;
				PromptSelectionResult selection = editor.GetSelection();
				IL_42:
				num2 = 7;
				SelectionSet value = selection.Value;
				IL_4D:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num3 = 0L;
					long num4 = (long)(checked(value.Count - 1));
					long num5 = num3;
					checked
					{
						for (;;)
						{
							long num6 = num5;
							long num7 = num4;
							if (num6 > num7)
							{
								break;
							}
							Entity e = (Entity)transaction.GetObject(value[(int)num5].ObjectId, 0);
							array = (Point3d[])Utils.CopyArray((Array)array, new Point3d[(int)num5 + 1]);
							array[(int)num5] = CAD.GetEntCenter(e);
							num5 += 1L;
						}
						transaction.Commit();
					}
				}
				IL_F7:
				num2 = 10;
				Class36.smethod_47(ref array);
				IL_102:
				num2 = 11;
				long num8 = 0L;
				long num9 = (long)Information.UBound(array, 1);
				long num10 = num8;
				checked
				{
					for (;;)
					{
						long num11 = num10;
						long num7 = num9;
						if (num11 > num7)
						{
							break;
						}
						IL_11F:
						num2 = 12;
						DBText dbtext = new DBText();
						IL_129:
						num2 = 13;
						dbtext.TextString = Conversions.ToString(num10 + 1L);
						IL_144:
						num2 = 14;
						dbtext.Height = 350.0;
						IL_157:
						num2 = 15;
						dbtext.VerticalMode = 2;
						IL_162:
						num2 = 16;
						dbtext.HorizontalMode = 4;
						IL_16D:
						num2 = 17;
						dbtext.AlignmentPoint = array[(int)num10];
						IL_185:
						num2 = 18;
						CAD.AddEnt(dbtext);
						IL_190:
						num2 = 19;
						num10 += 1L;
					}
					IL_1AE:
					num2 = 20;
					if (Information.Err().Number == 0)
					{
						goto IL_1D8;
					}
					IL_1C3:
					num2 = 21;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_1D8:
					goto IL_28B;
					IL_1DD:;
				}
				int num12 = num13 + 1;
				num13 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num12);
				IL_245:
				goto IL_280;
				IL_247:
				num13 = num2;
				if (num <= -2)
				{
					goto IL_1DD;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_25D:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num13 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_247;
			}
			IL_280:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_28B:
			if (num13 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("面积标注")]
		public void 面积标注()
		{
			int num;
			int num9;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_31:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3B:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_59:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_64:
				num2 = 8;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_75:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_81:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num3 = 0L;
					long num4 = (long)(checked(value.Count - 1));
					long num5 = num3;
					checked
					{
						for (;;)
						{
							long num6 = num5;
							long num7 = num4;
							if (num6 > num7)
							{
								break;
							}
							Polyline polyline = (Polyline)transaction.GetObject(value[(int)num5].ObjectId, 0);
							Point3d entCenter = CAD.GetEntCenter(polyline);
							long value2 = (long)Math.Round(polyline.Area);
							CAD.AddEnt(new DBText
							{
								TextString = Conversions.ToString(value2),
								Height = 350.0,
								VerticalMode = 2,
								HorizontalMode = 4,
								AlignmentPoint = entCenter
							});
							num5 += 1L;
						}
						transaction.Commit();
					}
				}
				IL_15F:
				num2 = 12;
				if (Information.Err().Number == 0)
				{
					goto IL_189;
				}
				IL_174:
				num2 = 13;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_189:
				goto IL_21C;
				IL_18E:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_1D6:
				goto IL_211;
				IL_1D8:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_18E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1EE:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1D8;
			}
			IL_211:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_21C:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("体积标注")]
		public void 体积标注()
		{
			int num;
			int num9;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_31:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3B:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "3DSolid");
				array2.SetValue(typedValue, 0);
				IL_59:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_64:
				num2 = 8;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_75:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_81:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num3 = 0L;
					long num4 = (long)(checked(value.Count - 1));
					long num5 = num3;
					checked
					{
						for (;;)
						{
							long num6 = num5;
							long num7 = num4;
							if (num6 > num7)
							{
								break;
							}
							Solid3d solid3d = (Solid3d)transaction.GetObject(value[(int)num5].ObjectId, 0);
							Point3d entCenter = CAD.GetEntCenter(solid3d);
							long value2 = (long)Math.Round(solid3d.MassProperties.Volume);
							CAD.AddEnt(new DBText
							{
								TextString = Conversions.ToString(value2),
								Height = 350.0,
								VerticalMode = 2,
								HorizontalMode = 4,
								AlignmentPoint = entCenter
							});
							num5 += 1L;
						}
						transaction.Commit();
					}
				}
				IL_168:
				num2 = 12;
				if (Information.Err().Number == 0)
				{
					goto IL_192;
				}
				IL_17D:
				num2 = 13;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_192:
				goto IL_225;
				IL_197:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_1DF:
				goto IL_21A;
				IL_1E1:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_197;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1F7:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1E1;
			}
			IL_21A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_225:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZongJinTongJi")]
		public void TcZongJinTongJi()
		{
			int num;
			int num12;
			object obj2;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				TypedValue[] array = new TypedValue[7];
				IL_3C:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(-4, "<or");
				array2.SetValue(typedValue, 0);
				IL_5B:
				num2 = 7;
				Array array3 = array;
				typedValue..ctor(-4, "<and");
				array3.SetValue(typedValue, 1);
				IL_7A:
				num2 = 8;
				Array array4 = array;
				typedValue..ctor(0, "LWPOLYLINE");
				array4.SetValue(typedValue, 2);
				IL_98:
				num2 = 9;
				Array array5 = array;
				typedValue..ctor(8, "墙柱纵筋,柱纵筋");
				array5.SetValue(typedValue, 3);
				IL_B7:
				num2 = 10;
				Array array6 = array;
				typedValue..ctor(-4, "and>");
				array6.SetValue(typedValue, 4);
				IL_D7:
				num2 = 11;
				Array array7 = array;
				typedValue..ctor(0, "TEXT");
				array7.SetValue(typedValue, 5);
				IL_F6:
				num2 = 12;
				Array array8 = array;
				typedValue..ctor(-4, "or>");
				array8.SetValue(typedValue, 6);
				IL_116:
				num2 = 13;
				long num3 = 0L;
				IL_124:
				num2 = 14;
				long num4 = 1L;
				IL_132:
				num2 = 15;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_13E:
				num2 = 16;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_150:
				num2 = 17;
				if (selection.Status != 5100)
				{
					goto IL_629;
				}
				IL_166:
				num2 = 18;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = selection.Value;
					Point3dCollection point3dCollection = new Point3dCollection();
					Entity entity = (Entity)transaction.GetObject(value[0].ObjectId, 0);
					short num5 = 0;
					short num6 = checked((short)(value.Count - 1));
					short num7 = num5;
					for (;;)
					{
						short num8 = num7;
						short num9 = num6;
						if (num8 > num9)
						{
							break;
						}
						entity = (Entity)transaction.GetObject(value[(int)num7].ObjectId, 1);
						checked
						{
							if (Operators.CompareString(entity.GetType().Name, "DBText", false) == 0)
							{
								DBText dbtext = (DBText)entity;
								string text = dbtext.TextString;
								text = Strings.Replace(text, "", "%%130", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%131", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%132", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%133", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%130", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%131", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%132", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "", "%%133", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\u0082", "%%130", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\u0083", "%%131", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\u0084", "%%132", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\u0085", "%%133", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "%%139", "%%133", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+0082", "%%130", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+0083", "%%131", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+0084", "%%132", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+0085", "%%133", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E000", "%%130", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E001", "%%131", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E002", "%%132", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E003", "%%133", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E530", "%%130", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E531", "%%131", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E532", "%%132", 1, -1, CompareMethod.Binary);
								text = Strings.Replace(text, "\\U+E533", "%%133", 1, -1, CompareMethod.Binary);
								if (text.Contains("%%") & !text.Contains("@"))
								{
									num3 = (long)Math.Round(Conversion.Val(text.Split(new char[]
									{
										'%'
									})[0]));
								}
							}
							else
							{
								Point3d entCenter = CAD.GetEntCenter(entity);
								bool flag = false;
								long num10;
								if (num10 != 0L)
								{
									foreach (object obj in point3dCollection)
									{
										Point3d point3d2;
										Point3d point3d = (obj != null) ? ((Point3d)obj) : point3d2;
										if (entCenter.DistanceTo(point3d) <= (double)num10)
										{
											editor.WriteMessage("\r\n发现有纵筋重叠，清理" + Conversions.ToString(num4) + "处。");
											num4 += 1L;
											entity.Erase();
											flag = true;
											IL_54A:
											IEnumerator enumerator;
											if (enumerator is IDisposable)
											{
												(enumerator as IDisposable).Dispose();
											}
											if (!flag)
											{
												point3dCollection.Add(entCenter);
												goto IL_576;
											}
											goto IL_576;
										}
									}
									goto IL_54A;
								}
								num10 = (long)Math.Round(entity.GeometricExtents.MaxPoint.DistanceTo(entity.GeometricExtents.MinPoint));
								point3dCollection.Add(entCenter);
							}
							IL_576:;
						}
						num7 += 1;
					}
					if (num3 != 0L)
					{
						Interaction.MsgBox(string.Concat(new string[]
						{
							"墙柱纵筋: ",
							Conversions.ToString(point3dCollection.Count),
							" 根。\r\n实配纵筋: ",
							Conversions.ToString(num3),
							" 根。"
						}), MsgBoxStyle.OkOnly, null);
					}
					else
					{
						Interaction.MsgBox("墙柱纵筋: " + Conversions.ToString(point3dCollection.Count) + " 根。", MsgBoxStyle.OkOnly, null);
					}
					transaction.Commit();
				}
				IL_629:
				goto IL_6D8;
				IL_62E:
				int num11 = num12 + 1;
				num12 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num11);
				IL_692:
				goto IL_6CD;
				IL_694:
				num12 = num2;
				if (num <= -2)
				{
					goto IL_62E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_6AA:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num12 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_694;
			}
			IL_6CD:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_6D8:
			if (num12 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcYWSF")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcYWSF()
		{
			int num;
			int num11;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				double num3 = NF.CVal(Conversions.ToString(Application.GetSystemVariable("USERR5")));
				IL_20:
				num2 = 3;
				if (num3 == 0.0)
				{
					goto IL_5E;
				}
				IL_33:
				num2 = 4;
				double num4 = Conversions.ToDouble(Interaction.InputBox("输入缩放比例", Class33.Class31_0.Info.ProductName, Conversions.ToString(num3), -1, -1));
				goto IL_88;
				IL_5E:
				num2 = 6;
				IL_60:
				num2 = 7;
				num4 = Conversions.ToDouble(Interaction.InputBox("输入缩放比例", Class33.Class31_0.Info.ProductName, "", -1, -1));
				IL_88:
				num2 = 9;
				if (num4 == 0.0)
				{
					goto IL_AF;
				}
				IL_9C:
				num2 = 10;
				Application.SetSystemVariable("USERR5", num4);
				IL_AF:
				num2 = 12;
				Matrix3d matrix3d = default(Matrix3d);
				IL_BA:
				num2 = 13;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_C9:
				num2 = 14;
				Database database = mdiActiveDocument.Database;
				IL_D5:
				num2 = 15;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_E9:
				num2 = 16;
				PromptSelectionResult selection = editor.GetSelection();
				IL_F5:
				num2 = 17;
				SelectionSet value = selection.Value;
				IL_101:
				num2 = 18;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num5 = 0L;
					long num6 = (long)(checked(value.Count - 1));
					long num7 = num5;
					checked
					{
						for (;;)
						{
							long num8 = num7;
							long num9 = num6;
							if (num8 > num9)
							{
								break;
							}
							Entity entity = (Entity)transaction.GetObject(value[(int)num7].ObjectId, 1);
							Point3d entCenter = CAD.GetEntCenter(entity);
							matrix3d = Matrix3d.Scaling(num4, entCenter);
							entity.TransformBy(matrix3d);
							num7 += 1L;
						}
						transaction.Commit();
					}
				}
				IL_198:
				num2 = 20;
				if (Information.Err().Number == 0)
				{
					goto IL_1C2;
				}
				IL_1AD:
				num2 = 21;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_1C2:
				goto IL_275;
				IL_1C7:
				int num10 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_22F:
				goto IL_26A;
				IL_231:
				num11 = num2;
				if (num <= -2)
				{
					goto IL_1C7;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_247:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_231;
			}
			IL_26A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_275:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcZhuJuZhong")]
		public void TcZhuJuZhong()
		{
			int num;
			int num4;
			object obj2;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_32:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3C:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LINE,LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_5A:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_65:
				num2 = 8;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_76:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_82:
				num2 = 10;
				Polyline polyline = null;
				IL_88:
				num2 = 11;
				Line line = null;
				IL_8E:
				num2 = 12;
				Line line2 = null;
				IL_94:
				num2 = 13;
				bool flag = false;
				IL_9A:
				num2 = 14;
				if (selection.Status != 5100)
				{
					goto IL_252;
				}
				IL_B0:
				num2 = 15;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 1);
						if (entity is Polyline)
						{
							polyline = (Polyline)entity;
						}
						else if (entity is Line & !flag)
						{
							line = (Line)entity;
							flag = true;
						}
						else if (entity is Line && flag)
						{
							line2 = (Line)entity;
						}
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					if (polyline != null)
					{
						Point3dCollection point3dCollection = new Point3dCollection();
						line.IntersectWith(line2, 0, new Plane(), point3dCollection, IntPtr.Zero, IntPtr.Zero);
						if (point3dCollection.Count == 1)
						{
							Point3d point3d_ = point3dCollection[0];
							Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
							Point3d minPoint = polyline.GeometricExtents.MinPoint;
							Point3d point3d_2;
							point3d_2..ctor((minPoint.X + maxPoint.X) / 2.0, (minPoint.Y + maxPoint.Y) / 2.0, (minPoint.Z + maxPoint.Z) / 2.0);
							Class36.smethod_48(polyline, point3d_2, point3d_);
							editor.WriteMessage("\r\n移动成功!");
						}
					}
					transaction.Commit();
				}
				IL_252:
				num2 = 18;
				if (Information.Err().Number == 0)
				{
					goto IL_27C;
				}
				IL_267:
				num2 = 19;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_27C:
				goto IL_327;
				IL_281:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2E1:
				goto IL_31C;
				IL_2E3:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_281;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2F9:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2E3;
			}
			IL_31C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_327:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcReplaceByBlock")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcReplaceByBlock()
		{
			int num;
			int num9;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string text = Interaction.InputBox("输入参照块名称:", Class33.Class31_0.Info.ProductName, "", -1, -1);
				IL_2C:
				num2 = 3;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_39:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_43:
				num2 = 5;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_56:
				num2 = 6;
				PromptSelectionResult selection = editor.GetSelection();
				IL_61:
				num2 = 7;
				SelectionSet value = selection.Value;
				IL_6C:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					long num3 = 0L;
					long num4 = (long)(checked(value.Count - 1));
					long num5 = num3;
					checked
					{
						for (;;)
						{
							long num6 = num5;
							long num7 = num4;
							if (num6 > num7)
							{
								break;
							}
							Entity e = (Entity)transaction.GetObject(value[(int)num5].ObjectId, 1);
							Point3d entCenter = CAD.GetEntCenter(e);
							BlockReference blockReference = new BlockReference(entCenter, blockTable[text]);
							blockTableRecord.AppendEntity(blockReference);
							transaction.AddNewlyCreatedDBObject(blockReference, true);
							num5 += 1L;
						}
						transaction.Commit();
					}
				}
				IL_145:
				num2 = 10;
				if (Information.Err().Number == 0)
				{
					goto IL_16F;
				}
				IL_15A:
				num2 = 11;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_16F:
				goto IL_1FA;
				IL_174:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_1B4:
				goto IL_1EF;
				IL_1B6:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_174;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1CC:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1B6;
			}
			IL_1EF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1FA:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcTxtSum")]
		public void TcTxtSum()
		{
			int num;
			int num11;
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
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "TEXT");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						short num3 = checked((short)(value.Count - 1));
						short num4 = 0;
						short num5 = num3;
						short num6 = num4;
						double num9;
						for (;;)
						{
							short num7 = num6;
							short num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							DBText dbtext = (DBText)transaction.GetObject(value[(int)num6].ObjectId, 0);
							num9 += Conversion.Val(dbtext.TextString);
							num6 += 1;
						}
						mdiActiveDocument.Editor.WriteMessage("\r\n当前所选文本和为:" + num9.ToString());
						Point3d point = CAD.GetPoint("选择插入点: ");
						Point3d point3d;
						if (!(point != point3d))
						{
							goto IL_1D1;
						}
						CAD.AddEnt(new DBText
						{
							TextString = num9.ToString(),
							Position = point,
							Height = 1000.0
						});
					}
					transaction.Commit();
				}
				IL_165:
				goto IL_1D1;
				IL_167:
				int num10 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_18B:
				goto IL_1C6;
				IL_18D:
				num11 = num2;
				if (num <= -2)
				{
					goto IL_167;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1A3:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_18D;
			}
			IL_1C6:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1D1:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcCAD2Excel2")]
		public void TcCAD2Excel2()
		{
			int num;
			int num9;
			object obj3;
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
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "TEXT");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					DBObjectCollection dbobjectCollection = new DBObjectCollection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 0);
							dbobjectCollection.Add(dbtext);
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
					while (dbobjectCollection.Count >= 1)
					{
						DBText dbtext2 = (DBText)dbobjectCollection[0];
						double y = dbtext2.Position.Y;
						DBText dbtext3 = dbtext2;
						long num3 = 0L;
						long num4 = (long)(checked(dbobjectCollection.Count - 1));
						long num5 = num3;
						checked
						{
							for (;;)
							{
								long num6 = num5;
								long num7 = num4;
								if (num6 > num7)
								{
									break;
								}
								DBText dbtext4 = (DBText)dbobjectCollection[(int)num5];
								if (y < dbtext4.Position.Y)
								{
									y = dbtext4.Position.Y;
									dbtext3 = dbtext4;
								}
								num5 += 1L;
							}
							dbobjectCollection2.Add(dbtext3);
							dbobjectCollection.Remove(dbtext3);
						}
					}
					string text = "";
					IEnumerator enumerator2 = dbobjectCollection2.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						object obj2 = enumerator2.Current;
						DBText dbtext5 = (DBText)obj2;
						text = text + "\r\n" + dbtext5.TextString;
					}
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
					Clipboard.SetText(text);
					if (Information.Err().Number > 0)
					{
						Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					}
				}
				IL_240:
				goto IL_2AC;
				IL_242:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_266:
				goto IL_2A1;
				IL_268:
				num9 = num2;
				if (num <= -2)
				{
					goto IL_242;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_27E:;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_268;
			}
			IL_2A1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2AC:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcCAD2Excel")]
		public void method_0()
		{
			int num;
			int num26;
			object obj3;
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
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "TEXT");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					DBObjectCollection dbobjectCollection = new DBObjectCollection();
					long num3 = 100L;
					ArrayList arrayList = new ArrayList();
					ArrayList arrayList2 = new ArrayList();
					string[,] array3;
					string text2;
					short num18;
					short num19;
					checked
					{
						if (selection.Status == 5100)
						{
							SelectionSet value = selection.Value;
							IEnumerator enumerator = value.GetEnumerator();
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								SelectedObject selectedObject = (SelectedObject)obj;
								DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 0);
								long num4 = (long)Math.Round(unchecked(Math.Round(dbtext.Position.X / (double)num3) * (double)num3));
								if (!arrayList.Contains(num4))
								{
									arrayList.Add(num4);
								}
								long num5 = (long)Math.Round(unchecked(Math.Round(dbtext.Position.Y / (double)num3) * (double)num3));
								if (!arrayList2.Contains(num5))
								{
									arrayList2.Add(num5);
								}
								dbobjectCollection.Add(dbtext);
							}
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						arrayList.Sort();
						arrayList2.Sort();
						arrayList2.Reverse();
						array3 = new string[arrayList2.Count - 1 + 1, arrayList.Count - 1 + 1];
						short num6 = 0;
						short num7 = (short)(arrayList2.Count - 1);
						short num8 = num6;
						for (;;)
						{
							short num9 = num8;
							short num10 = num7;
							if (num9 > num10)
							{
								break;
							}
							long num11 = Conversions.ToLong(arrayList2[(int)num8]);
							short num12 = 0;
							short num13 = (short)(arrayList.Count - 1);
							short num14 = num12;
							unchecked
							{
								for (;;)
								{
									IL_2E2:
									short num15 = num14;
									num10 = num13;
									if (num15 > num10)
									{
										break;
									}
									long num16 = Conversions.ToLong(arrayList[(int)num14]);
									string text = "";
									foreach (object obj2 in dbobjectCollection)
									{
										DBText dbtext2 = (DBText)obj2;
										if (Math.Round(dbtext2.Position.X / (double)num3) * (double)num3 == (double)num16 & Math.Round(dbtext2.Position.Y / (double)num3) * (double)num3 == (double)num11)
										{
											text = dbtext2.TextString;
											IL_28C:
											IEnumerator enumerator2;
											if (enumerator2 is IDisposable)
											{
												(enumerator2 as IDisposable).Dispose();
											}
											if (Operators.CompareString(text, "", false) != 0)
											{
												array3[(int)num8, (int)num14] = text;
											}
											else
											{
												array3[(int)num8, (int)num14] = " ";
											}
											num14 += 1;
											goto IL_2E2;
										}
									}
									goto IL_28C;
								}
								num8 += 1;
							}
						}
						text2 = "";
						short num17 = 0;
						num18 = (short)(arrayList2.Count - 1);
						num19 = num17;
					}
					for (;;)
					{
						short num20 = num19;
						short num10 = num18;
						if (num20 > num10)
						{
							break;
						}
						short num21 = 0;
						short num22 = checked((short)(arrayList.Count - 1));
						short num23 = num21;
						for (;;)
						{
							short num24 = num23;
							num10 = num22;
							if (num24 > num10)
							{
								break;
							}
							if (Operators.CompareString(text2, "", false) == 0)
							{
								text2 = array3[(int)num19, (int)num23];
							}
							else if ((int)num23 == checked(arrayList.Count - 1))
							{
								text2 = text2 + Conversions.ToString(Convert.ToChar(9)) + array3[(int)num19, (int)num23] + "\r\n";
							}
							else if (num23 == 0)
							{
								text2 += array3[(int)num19, (int)num23];
							}
							else
							{
								text2 = text2 + Conversions.ToString(Convert.ToChar(9)) + array3[(int)num19, (int)num23];
							}
							num23 += 1;
						}
						num19 += 1;
					}
					Clipboard.SetText(text2);
					if (Information.Err().Number > 0)
					{
						Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					}
				}
				IL_42A:
				goto IL_496;
				IL_42C:
				int num25 = num26 + 1;
				num26 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num25);
				IL_450:
				goto IL_48B;
				IL_452:
				num26 = num2;
				if (num <= -2)
				{
					goto IL_42C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_468:;
			}
			catch when (endfilter(obj3 is Exception & num != 0 & num26 == 0))
			{
				Exception ex = (Exception)obj4;
				goto IL_452;
			}
			IL_48B:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_496:
			if (num26 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcExcel2cad")]
		public void method_1()
		{
			string text = Clipboard.GetText();
			if (Operators.CompareString(text, "", false) == 0)
			{
				Interaction.MsgBox("剪切板中无Excel表格数据!", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				string[] array = text.Split(new char[]
				{
					'\r'
				});
				string[] array2 = array[0].Split(new char[]
				{
					Convert.ToChar(9)
				});
				long num = (long)(checked(array.Length - 1));
				long num2 = (long)array2.Length;
				checked
				{
					string[,] array3 = new string[(int)(num - 1L) + 1, (int)(num2 - 1L) + 1];
					long num3 = 0L;
					long num4 = num - 1L;
					long num5 = num3;
					for (;;)
					{
						long num6 = num5;
						long num7 = num4;
						if (num6 > num7)
						{
							break;
						}
						long num8 = 0L;
						long num9 = num2 - 1L;
						long num10 = num8;
						for (;;)
						{
							long num11 = num10;
							num7 = num9;
							if (num11 > num7)
							{
								break;
							}
							array3[(int)num5, (int)num10] = array[(int)num5].Split(new char[]
							{
								Convert.ToChar(9)
							})[(int)num10].Trim();
							num10 += 1L;
						}
						num5 += 1L;
					}
					long num12 = 300L;
					Point3d point = CAD.GetPoint("选择插入点: ");
					long num13 = 0L;
					long num14 = 0L;
					long num15 = num2 - 1L;
					long num16 = num14;
					for (;;)
					{
						long num17 = num16;
						long num7 = num15;
						if (num17 > num7)
						{
							break;
						}
						int num18 = 0;
						string[] array4 = new string[(int)(num - 1L) + 1];
						long num19 = 0L;
						long num20 = num - 1L;
						long num21 = num19;
						for (;;)
						{
							long num22 = num21;
							num7 = num20;
							if (num22 > num7)
							{
								break;
							}
							num18 = Math.Max(num18, array3[(int)num21, (int)num16].Length);
							array4[(int)num21] = array3[(int)num21, (int)num16];
							num21 += 1L;
						}
						long num23 = unchecked((long)(checked(num18 + 2))) * num12;
						if (num16 != num2 - 1L)
						{
							Point3d point3d_;
							point3d_..ctor(unchecked(point.X + (double)num13), point.Y, point.Z);
							Class36.smethod_22(point3d_, array4, (double)num12, 1.5, num23, false, "");
						}
						else
						{
							Point3d point3d_;
							point3d_..ctor(unchecked(point.X + (double)num13), point.Y, point.Z);
							Class36.smethod_22(point3d_, array4, (double)num12, 1.5, num23, true, "");
						}
						num13 += num23;
						num16 += 1L;
					}
				}
			}
		}

		[CommandMethod("TcLineSum")]
		public void TcLineSum()
		{
			int num;
			int num11;
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
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "Line");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						short num3 = checked((short)(value.Count - 1));
						short num4 = 0;
						short num5 = num3;
						short num6 = num4;
						double num9;
						for (;;)
						{
							short num7 = num6;
							short num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							Line line = (Line)transaction.GetObject(value[(int)num6].ObjectId, 0);
							num9 += Conversion.Val(line.EndPoint.DistanceTo(line.StartPoint));
							num6 += 1;
						}
						mdiActiveDocument.Editor.WriteMessage("\r\n当前所选线段总长:" + num9.ToString());
						Point3d point = CAD.GetPoint("选择插入点: ");
						Point3d point3d;
						if (!(point != point3d))
						{
							goto IL_1E6;
						}
						CAD.AddEnt(new DBText
						{
							TextString = num9.ToString(),
							Position = point,
							Height = 1000.0
						});
					}
					transaction.Commit();
				}
				IL_17A:
				goto IL_1E6;
				IL_17C:
				int num10 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num10);
				IL_1A0:
				goto IL_1DB;
				IL_1A2:
				num11 = num2;
				if (num <= -2)
				{
					goto IL_17C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1B8:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_1A2;
			}
			IL_1DB:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1E6:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcGetA")]
		public void TcGetA()
		{
			int num;
			int num10;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_31:
				num2 = 5;
				TypedValue[] array = new TypedValue[1];
				IL_3B:
				num2 = 6;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,REGION");
				array2.SetValue(typedValue, 0);
				IL_59:
				num2 = 7;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_64:
				num2 = 8;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_75:
				num2 = 9;
				SelectionSet value = selection.Value;
				IL_81:
				num2 = 10;
				string text = "Tc_" + NF.Time2String2();
				IL_95:
				num2 = 11;
				CAD.CreateLayer(text, 0, "continuous", -1, false, true);
				IL_A9:
				num2 = 12;
				double num3 = 0.0;
				IL_B7:
				num2 = 13;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num4 = 0L;
					long num5 = (long)(checked(value.Count - 1));
					long num6 = num4;
					for (;;)
					{
						long num7 = num6;
						long num8 = num5;
						if (num7 > num8)
						{
							break;
						}
						Entity entity = (Entity)transaction.GetObject(value[checked((int)num6)].ObjectId, 0);
						Point3d entCenter = CAD.GetEntCenter(entity);
						double area;
						if (entity is Region)
						{
							Region region = (Region)entity;
							area = region.Area;
						}
						else if (entity is Polyline)
						{
							Polyline polyline = (Polyline)entity;
							area = polyline.Area;
						}
						CAD.AddEnt(new DBText
						{
							TextString = Strings.Format(area / 1000.0 / 1000.0, "0.00") + "m²",
							Height = CAD.GetScale() * 300.0,
							WidthFactor = 0.7,
							VerticalMode = 2,
							HorizontalMode = 4,
							AlignmentPoint = entCenter,
							Layer = text
						});
						num3 += area / 1000.0 / 1000.0;
						checked
						{
							num6 += 1L;
						}
					}
					transaction.Commit();
				}
				IL_226:
				num2 = 15;
				mdiActiveDocument.Editor.WriteMessage("\r\n总面积" + Strings.Format(num3, "0.00") + "m²");
				IL_254:
				num2 = 16;
				if (Information.Err().Number == 0)
				{
					goto IL_27E;
				}
				IL_269:
				num2 = 17;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_27E:
				goto IL_321;
				IL_283:
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_2DB:
				goto IL_316;
				IL_2DD:
				num10 = num2;
				if (num <= -2)
				{
					goto IL_283;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2F3:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2DD;
			}
			IL_316:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_321:
			if (num10 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcGetV")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void TcGetV()
		{
			int num;
			int num14;
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_31:
				num2 = 5;
				double num3 = Conversion.Val(Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "TcGetV", "TcGetV_Z", "60"));
				IL_5D:
				num2 = 6;
				PromptDistanceOptions promptDistanceOptions = new PromptDistanceOptions("\n板厚（mm)");
				IL_6B:
				num2 = 7;
				promptDistanceOptions.AllowNone = true;
				IL_75:
				num2 = 8;
				promptDistanceOptions.AllowZero = false;
				IL_7F:
				num2 = 9;
				promptDistanceOptions.DefaultValue = num3;
				IL_8B:
				num2 = 10;
				PromptDoubleResult distance = mdiActiveDocument.Editor.GetDistance(promptDistanceOptions);
				IL_9D:
				num2 = 11;
				if (distance.Status != 5100)
				{
					goto IL_E4;
				}
				IL_B0:
				num2 = 12;
				num3 = distance.Value;
				IL_BC:
				num2 = 13;
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "TcGetV", "TcGetV_H", num3.ToString());
				IL_E4:
				num2 = 15;
				TypedValue[] array = new TypedValue[1];
				IL_EF:
				num2 = 16;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "3DSolid,LWPOLYLINE,REGION");
				array2.SetValue(typedValue, 0);
				IL_10E:
				num2 = 17;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_11A:
				num2 = 18;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_12C:
				num2 = 19;
				SelectionSet value = selection.Value;
				IL_138:
				num2 = 20;
				double num4 = 0.0;
				IL_146:
				num2 = 21;
				string text = "Tc_" + NF.Time2String2();
				IL_15A:
				num2 = 22;
				CAD.CreateLayer(text, 0, "continuous", -1, false, true);
				IL_16E:
				num2 = 23;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					long num5 = 0L;
					long num6 = (long)(checked(value.Count - 1));
					long num7 = num5;
					for (;;)
					{
						long num8 = num7;
						long num9 = num6;
						if (num8 > num9)
						{
							break;
						}
						Entity entity = (Entity)transaction.GetObject(value[checked((int)num7)].ObjectId, 0);
						double num10;
						double num11;
						double num12;
						if (entity is Polyline)
						{
							Polyline polyline = (Polyline)entity;
							num10 = polyline.Area;
							num11 = 1.0;
							num12 = num3;
						}
						else if (entity is Region)
						{
							Region region = (Region)entity;
							num10 = region.Area;
							num11 = 1.0;
							num12 = num3;
						}
						else
						{
							num10 = 1.0;
							num12 = 1.0;
							Solid3d solid3d = (Solid3d)entity;
							num11 = solid3d.MassProperties.Volume;
						}
						Point3d entCenter = CAD.GetEntCenter(entity);
						CAD.AddEnt(new DBText
						{
							TextString = Strings.Format(num11 * num10 * num12 * 2.5 / 1000000000.0, "0.00") + "t",
							Height = CAD.GetScale() * 300.0,
							WidthFactor = 0.7,
							VerticalMode = 2,
							HorizontalMode = 4,
							AlignmentPoint = entCenter,
							Layer = text
						});
						num4 += num11 * num10 * num12 * 2.5 / 1000000000.0;
						checked
						{
							num7 += 1L;
						}
					}
					transaction.Commit();
				}
				IL_33A:
				num2 = 25;
				mdiActiveDocument.Editor.WriteMessage("\r\n总体积(重量)" + Strings.Format(num4, "0.00") + "t");
				IL_368:
				num2 = 26;
				if (Information.Err().Number == 0)
				{
					goto IL_392;
				}
				IL_37D:
				num2 = 27;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_392:
				goto IL_460;
				IL_397:
				int num13 = num14 + 1;
				num14 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num13);
				IL_417:
				goto IL_455;
				IL_419:
				num14 = num2;
				if (num <= -2)
				{
					goto IL_397;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_432:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_419;
			}
			IL_455:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_460:
			if (num14 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcDHBTJ1")]
		public void TcDHBTJ1()
		{
			int num;
			int num16;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				string[] array = new string[1];
				IL_12:
				num2 = 3;
				string[] array2 = new string[1];
				IL_1B:
				num2 = 4;
				string[] array3 = new string[1];
				IL_25:
				num2 = 5;
				string[] array4 = new string[1];
				IL_2F:
				num2 = 6;
				string[] array5 = new string[1];
				IL_39:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_47:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_52:
				num2 = 9;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_66:
				num2 = 10;
				long num3 = 0L;
				IL_74:
				num2 = 11;
				double num4 = 0.0;
				IL_82:
				num2 = 12;
				Point3d point;
				Point3d pointXY;
				Point3d pointXY2;
				long num10;
				checked
				{
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						TypedValue[] array6 = new TypedValue[1];
						Array array7 = array6;
						TypedValue typedValue;
						typedValue..ctor(0, "LWPOLYLINE");
						array7.SetValue(typedValue, 0);
						SelectionFilter selectionFilter = new SelectionFilter(array6);
						PromptSelectionResult selection = editor.GetSelection(selectionFilter);
						if (selection.Status != 5100)
						{
							goto IL_B61;
						}
						SelectionSet value = selection.Value;
						num3 = unchecked((long)value.Count);
						array = new string[(int)num3 + 1];
						array2 = new string[(int)num3 + 1];
						array3 = new string[(int)num3 + 1];
						array4 = new string[(int)num3 + 1];
						array5 = new string[(int)num3 + 1];
						array[0] = "序号";
						array2[0] = "编号";
						array3[0] = "面积";
						array4[0] = "质量";
						array5[0] = "其它";
						long num5 = 0L;
						long num6 = num3 - 1L;
						long num7 = num5;
						for (;;)
						{
							long num8 = num7;
							long num9 = num6;
							if (num8 > num9)
							{
								break;
							}
							Entity entity = (Entity)transaction.GetObject(value[(int)num7].ObjectId, 0);
							Point3d minPoint = entity.GeometricExtents.MinPoint;
							Point3d maxPoint = entity.GeometricExtents.MaxPoint;
							Polyline polyline = (Polyline)entity;
							array3[(int)(num7 + 1L)] = Strings.Format(polyline.Area / 1000.0 / 1000.0, "0.00");
							DBObjectCollection dbobjectCollection;
							unchecked
							{
								num4 += polyline.Area / 1000.0 / 1000.0;
								Point3dCollection point3dCollection = new Point3dCollection();
								Point3dCollection point3dCollection2 = point3dCollection;
								Point3d point3d;
								point3d..ctor(maxPoint.X, minPoint.Y, 0.0);
								point3dCollection2.Add(point3d);
								Point3dCollection point3dCollection3 = point3dCollection;
								point3d..ctor(maxPoint.X, maxPoint.Y, 0.0);
								point3dCollection3.Add(point3d);
								Point3dCollection point3dCollection4 = point3dCollection;
								point3d..ctor(minPoint.X, maxPoint.Y, 0.0);
								point3dCollection4.Add(point3d);
								Point3dCollection point3dCollection5 = point3dCollection;
								point3d..ctor(minPoint.X, minPoint.Y, 0.0);
								point3dCollection5.Add(point3d);
								Array array8 = array6;
								typedValue..ctor(0, "TEXT");
								array8.SetValue(typedValue, 0);
								dbobjectCollection = CAD.WindowPolygon(point3dCollection, array6);
							}
							if (dbobjectCollection.Count >= 1)
							{
								IEnumerator enumerator = dbobjectCollection.GetEnumerator();
								while (enumerator.MoveNext())
								{
									object obj = enumerator.Current;
									DBObject dbobject = (DBObject)obj;
									DBText dbtext = (DBText)transaction.GetObject(dbobject.ObjectId, 0);
									string text = dbtext.TextString.ToUpper();
									if (text.Contains("T"))
									{
										array4[(int)(num7 + 1L)] = text;
									}
									else if (text.Contains("M"))
									{
										array3[(int)(num7 + 1L)] = text;
									}
									else if (text.Contains("-"))
									{
										array2[(int)(num7 + 1L)] = text;
									}
									else
									{
										array5[(int)(num7 + 1L)] = text;
									}
								}
								if (enumerator is IDisposable)
								{
									(enumerator as IDisposable).Dispose();
								}
							}
							array[(int)(num7 + 1L)] = Conversions.ToString(num7 + 1L);
							num7 += 1L;
						}
					}
					IL_42B:
					num2 = 14;
					point = CAD.GetPoint("选择插入点: ");
					IL_43A:
					num2 = 15;
					pointXY = CAD.GetPointXY(point, -500.0, -75.0);
					IL_458:
					num2 = 16;
					pointXY2 = CAD.GetPointXY(point, 10000.0, -75.0);
					IL_476:
					num2 = 17;
					CAD.AddLine(pointXY, pointXY2, "0");
					IL_488:
					num2 = 18;
					num10 = num3 + 2L;
					IL_499:
					num2 = 19;
					long num11 = 0L;
					long num12 = num3 + 2L;
					long num13 = num11;
					for (;;)
					{
						long num14 = num13;
						long num9 = num12;
						if (num14 > num9)
						{
							break;
						}
						IL_4BA:
						num2 = 20;
						unchecked
						{
							Point3d pointXY3 = CAD.GetPointXY(point, -500.0, (double)(checked((0L - num13) * 300L)) * 1.5 - 75.0);
							IL_4FA:
							num2 = 21;
							Point3d pointXY4 = CAD.GetPointXY(point, 10000.0, (double)(checked((0L - num13) * 300L)) * 1.5 - 75.0);
							IL_53A:
							num2 = 22;
							CAD.AddLine(pointXY3, pointXY4, "0");
							IL_54C:
							num2 = 23;
						}
						num13 += 1L;
					}
					IL_56A:
					num2 = 24;
					pointXY = CAD.GetPointXY(point, -500.0, -75.0);
					IL_588:
					num2 = 25;
				}
				pointXY2 = CAD.GetPointXY(point, -500.0, (double)(checked((0L - num10) * 300L)) * 1.5 - 75.0);
				IL_5C8:
				num2 = 26;
				CAD.AddLine(pointXY, pointXY2, "0");
				IL_5DA:
				num2 = 27;
				pointXY = CAD.GetPointXY(point, 1500.0, -75.0);
				IL_5F8:
				num2 = 28;
				pointXY2 = CAD.GetPointXY(point, 1500.0, (double)(checked((0L - (num10 - 1L)) * 300L)) * 1.5 - 75.0);
				IL_642:
				num2 = 29;
				CAD.AddLine(pointXY, pointXY2, "0");
				IL_654:
				num2 = 30;
				pointXY = CAD.GetPointXY(point, 3500.0, -75.0);
				IL_672:
				num2 = 31;
				pointXY2 = CAD.GetPointXY(point, 3500.0, (double)(checked((0L - num10) * 300L)) * 1.5 - 75.0);
				IL_6B2:
				num2 = 32;
				CAD.AddLine(pointXY, pointXY2, "0");
				IL_6C4:
				num2 = 33;
				pointXY = CAD.GetPointXY(point, 5500.0, -75.0);
				IL_6E2:
				num2 = 34;
				pointXY2 = CAD.GetPointXY(point, 5500.0, (double)(checked((0L - num10) * 300L)) * 1.5 - 75.0);
				IL_722:
				num2 = 35;
				CAD.AddLine(pointXY, pointXY2, "0");
				IL_734:
				num2 = 36;
				pointXY = CAD.GetPointXY(point, 7500.0, -75.0);
				IL_752:
				num2 = 37;
				pointXY2 = CAD.GetPointXY(point, 7500.0, (double)(checked((0L - num10) * 300L)) * 1.5 - 75.0);
				IL_792:
				num2 = 38;
				CAD.AddLine(pointXY, pointXY2, "0");
				IL_7A4:
				num2 = 39;
				pointXY = CAD.GetPointXY(point, 10000.0, -75.0);
				IL_7C2:
				num2 = 40;
				pointXY2 = CAD.GetPointXY(point, 10000.0, (double)(checked((0L - num10) * 300L)) * 1.5 - 75.0);
				IL_802:
				num2 = 41;
				CAD.AddLine(pointXY, pointXY2, "0");
				IL_814:
				num2 = 42;
				Class36.smethod_20(point, array, 300.0, 1.5, "");
				IL_837:
				num2 = 43;
				Point3d pointXY5 = CAD.GetPointXY(point, 2000.0, 0.0);
				IL_855:
				num2 = 44;
				Class36.smethod_20(pointXY5, array2, 300.0, 1.5, "");
				IL_878:
				num2 = 45;
				pointXY5 = CAD.GetPointXY(point, 4000.0, 0.0);
				IL_896:
				num2 = 46;
				Class36.smethod_20(pointXY5, array3, 300.0, 1.5, "");
				IL_8BA:
				num2 = 47;
				pointXY5 = CAD.GetPointXY(point, 6000.0, 0.0);
				IL_8D8:
				num2 = 48;
				Class36.smethod_20(pointXY5, array4, 300.0, 1.5, "");
				IL_8FC:
				num2 = 49;
				pointXY5 = CAD.GetPointXY(point, 8000.0, 0.0);
				IL_91A:
				num2 = 50;
				Class36.smethod_20(pointXY5, array5, 300.0, 1.5, "");
				IL_93E:
				num2 = 51;
				pointXY5 = CAD.GetPointXY(point, 1000.0, (double)(checked((0L - num10) * 300L)) * 1.5);
				IL_974:
				num2 = 52;
				Class36.smethod_23(pointXY5, "合计", 300.0, 0, "");
				IL_993:
				num2 = 53;
				pointXY5 = CAD.GetPointXY(point, 4000.0, (double)(checked((0L - num10) * 300L)) * 1.5);
				IL_9C9:
				num2 = 54;
				Class36.smethod_23(pointXY5, Strings.Format(num4, "0.00"), 300.0, 0, "");
				IL_9F4:
				num2 = 55;
				if (Information.Err().Number <= 0)
				{
					goto IL_A1B;
				}
				IL_A06:
				num2 = 56;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_A1B:
				goto IL_B61;
				IL_A20:
				int num15 = num16 + 1;
				num16 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num15);
				IL_B18:
				goto IL_B56;
				IL_B1A:
				num16 = num2;
				if (num <= -2)
				{
					goto IL_A20;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_B33:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num16 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_B1A;
			}
			IL_B56:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_B61:
			if (num16 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcAllZ0")]
		public void TcAllZ0()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
				try
				{
					foreach (ObjectId objectId in blockTable)
					{
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(objectId, 1);
						try
						{
							foreach (ObjectId objectId2 in blockTableRecord)
							{
								Entity entity = (Entity)transaction.GetObject(objectId2, 1);
								if (entity is Line)
								{
									Line line = (Line)entity;
									Point3d point3d = line.StartPoint;
									Line line2 = line;
									Point3d point3d2;
									point3d2..ctor(point3d.X, point3d.Y, 0.0);
									line2.StartPoint = point3d2;
									point3d = line.EndPoint;
									Line line3 = line;
									point3d2..ctor(point3d.X, point3d.Y, 0.0);
									line3.EndPoint = point3d2;
								}
							}
						}
						finally
						{
							BlockTableRecordEnumerator enumerator2;
							if (enumerator2 != null)
							{
								enumerator2.Dispose();
							}
						}
					}
				}
				finally
				{
					SymbolTableEnumerator enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcLineZ0")]
		public void TcLineZ0()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Line line = (Line)transaction.GetObject(objectId, 1);
						Point3d point3d = line.StartPoint;
						Line line2 = line;
						Point3d point3d2;
						point3d2..ctor(point3d.X, point3d.Y, 0.0);
						line2.StartPoint = point3d2;
						point3d = line.EndPoint;
						Line line3 = line;
						point3d2..ctor(point3d.X, point3d.Y, 0.0);
						line3.EndPoint = point3d2;
					}
				}
				transaction.Commit();
			}
		}

		[CommandMethod("TcDXQC")]
		public void TcDXQC()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				SelectionSet value = selection.Value;
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				foreach (ObjectId objectId in value.GetObjectIds())
				{
					objectIdCollection.Add(objectId);
				}
				while (objectIdCollection.Count >= 1)
				{
					Entity entity = (Entity)transaction.GetObject(objectIdCollection[0], 1);
					Extents3d geometricExtents = entity.GeometricExtents;
					string right = entity.GetType().ToString();
					long num = (long)(checked(objectIdCollection.Count - 1));
					long num2 = 1L;
					long num3 = num;
					long num4 = num2;
					checked
					{
						for (;;)
						{
							long num5 = num4;
							long num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							Entity entity2 = (Entity)transaction.GetObject(objectIdCollection[(int)num4], 1);
							string left = entity2.GetType().ToString();
							if (Operators.CompareString(left, right, false) == 0)
							{
								Extents3d geometricExtents2 = entity2.GeometricExtents;
								if (geometricExtents.IsEqualTo(geometricExtents2))
								{
									entity2.Erase();
									objectIdCollection.Remove(entity2.Id);
								}
							}
							num4 += 1L;
						}
						objectIdCollection.Remove(entity.Id);
					}
				}
				transaction.Commit();
			}
		}

		private int method_2()
		{
			throw new NotImplementedException();
		}
	}
}
