using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
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
	public class 结构分析
	{
		[DebuggerNonUserCode]
		public 结构分析()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcJianTuDuiBi")]
		public void TcJianTuDuiBi()
		{
			int num;
			int num5;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Polyline polyline = (Polyline)Class36.smethod_72("选择原配筋简图边框:");
				IL_1C:
				num2 = 3;
				Class36.smethod_73(polyline.ObjectId);
				IL_2A:
				num2 = 4;
				Polyline polyline2 = (Polyline)Class36.smethod_72("选择新配筋简图边框:");
				IL_3D:
				num2 = 5;
				Class36.smethod_73(polyline2.ObjectId);
				IL_4B:
				num2 = 6;
				Point3d minPoint = polyline.GeometricExtents.MinPoint;
				Vector3d vectorTo = minPoint.GetVectorTo(polyline2.GeometricExtents.MinPoint);
				IL_78:
				num2 = 7;
				Point3dCollection point3dCollection = new Point3dCollection();
				IL_81:
				num2 = 8;
				Point3d minPoint2 = polyline.GeometricExtents.MinPoint;
				IL_95:
				num2 = 9;
				Point3d maxPoint = polyline.GeometricExtents.MaxPoint;
				IL_AA:
				num2 = 10;
				point3dCollection.Add(minPoint2);
				IL_B7:
				num2 = 11;
				Point3dCollection point3dCollection2 = point3dCollection;
				minPoint..ctor(minPoint2.X, maxPoint.Y, minPoint2.Z);
				point3dCollection2.Add(minPoint);
				IL_E0:
				num2 = 12;
				point3dCollection.Add(maxPoint);
				IL_ED:
				num2 = 13;
				Point3dCollection point3dCollection3 = point3dCollection;
				minPoint..ctor(maxPoint.X, minPoint2.Y, minPoint2.Z);
				point3dCollection3.Add(minPoint);
				IL_116:
				num2 = 14;
				TypedValue[] array = new TypedValue[1];
				IL_120:
				num2 = 15;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "TEXT");
				array2.SetValue(typedValue, 0);
				IL_13D:
				num2 = 16;
				DBObjectCollection dbobjectCollection = 结构分析.WindowPolygon(point3dCollection, array);
				IL_14A:
				num2 = 17;
				IEnumerator enumerator = dbobjectCollection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DBText dbtext = (DBText)enumerator.Current;
					IL_170:
					num2 = 18;
					Application.DoEvents();
					IL_178:
					num2 = 19;
					TypedValue[] array3 = new TypedValue[2];
					IL_183:
					num2 = 20;
					Array array4 = array3;
					typedValue..ctor(0, "TEXT");
					array4.SetValue(typedValue, 0);
					IL_1A1:
					num2 = 21;
					Array array5 = array3;
					typedValue..ctor(8, dbtext.Layer);
					array5.SetValue(typedValue, 1);
					IL_1C1:
					num2 = 22;
					Point3d entCenter = CAD.GetEntCenter(dbtext);
					IL_1CD:
					num2 = 23;
					entCenter..ctor(entCenter.X + vectorTo.X, entCenter.Y + vectorTo.Y, entCenter.Z + vectorTo.Z);
					IL_204:
					num2 = 24;
					Point3dCollection point3dCollection4 = new Point3dCollection();
					IL_20E:
					num2 = 25;
					double num3 = dbtext.Height / 3.0;
					IL_224:
					num2 = 26;
					Point3dCollection point3dCollection5 = point3dCollection4;
					minPoint..ctor(entCenter.X - num3, entCenter.Y - num3, entCenter.Z);
					point3dCollection5.Add(minPoint);
					IL_253:
					num2 = 27;
					Point3dCollection point3dCollection6 = point3dCollection4;
					minPoint..ctor(entCenter.X - num3, entCenter.Y + num3, entCenter.Z);
					point3dCollection6.Add(minPoint);
					IL_282:
					num2 = 28;
					Point3dCollection point3dCollection7 = point3dCollection4;
					minPoint..ctor(entCenter.X + num3, entCenter.Y + num3, entCenter.Z);
					point3dCollection7.Add(minPoint);
					IL_2B1:
					num2 = 29;
					Point3dCollection point3dCollection8 = point3dCollection4;
					minPoint..ctor(entCenter.X + num3, entCenter.Y - num3, entCenter.Z);
					point3dCollection8.Add(minPoint);
					IL_2E0:
					num2 = 30;
					DBObjectCollection dbobjectCollection2 = 结构分析.CrossingPolygon(point3dCollection4, array3);
					IL_2EE:
					num2 = 31;
					ObjectId objectId = dbobjectCollection2[0].ObjectId;
					IL_300:
					num2 = 32;
					string textString = dbtext.TextString;
					IL_30C:
					num2 = 33;
					string txt = this.GetTxt(objectId);
					IL_319:
					num2 = 34;
					if (Operators.CompareString(textString, txt, false) == 0)
					{
						IL_32B:
						num2 = 35;
						Class36.smethod_64(objectId);
					}
					else
					{
						IL_338:
						num2 = 37;
						IL_33B:
						num2 = 38;
						bool flag = this.StrBiJiao(textString, txt);
						IL_34A:
						num2 = 39;
						if (!flag)
						{
							IL_354:
							num2 = 40;
							this.method_1(objectId);
						}
						else
						{
							IL_362:
							num2 = 42;
							IL_365:
							num2 = 43;
							this.method_0(objectId);
						}
					}
					IL_371:
					num2 = 46;
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				IL_394:
				num2 = 47;
				Class36.smethod_74(polyline.ObjectId);
				IL_3A3:
				num2 = 48;
				Class36.smethod_74(polyline2.ObjectId);
				IL_3B2:
				num2 = 49;
				Interaction.MsgBox("简图对比完毕!", MsgBoxStyle.OkOnly, null);
				IL_3C2:
				goto IL_4E8;
				IL_3C7:
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_49F:
				goto IL_4DD;
				IL_4A1:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_3C7;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_4BA:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_4A1;
			}
			IL_4DD:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_4E8:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public bool StrBiJiao(string S1, string S2)
		{
			short num = checked((short)S1.Split(new char[]
			{
				'-'
			}).Length);
			bool result;
			if (S1.Split(new char[]
			{
				'-'
			}).Length != (int)num)
			{
				result = true;
			}
			else if (num == 1)
			{
				result = (NF.CVal(S1) <= NF.CVal(S2));
			}
			else if (num == 2)
			{
				double num2 = 0.0;
				if (NF.CVal(S1.Split(new char[]
				{
					'-'
				})[0]) < NF.CVal(S2.Split(new char[]
				{
					'-'
				})[0]))
				{
					num2 += 1.0;
				}
				if (NF.CVal(S1.Split(new char[]
				{
					'-'
				})[1]) < NF.CVal(S2.Split(new char[]
				{
					'-'
				})[1]))
				{
					num2 += 1.0;
				}
				result = (num2 >= 1.0);
			}
			else if (num == 3)
			{
				double num3 = 0.0;
				if (NF.CVal(S1.Split(new char[]
				{
					'-'
				})[0]) < NF.CVal(S2.Split(new char[]
				{
					'-'
				})[0]))
				{
					num3 += 1.0;
				}
				if (NF.CVal(S1.Split(new char[]
				{
					'-'
				})[1]) < NF.CVal(S2.Split(new char[]
				{
					'-'
				})[1]))
				{
					num3 += 1.0;
				}
				if (NF.CVal(S1.Split(new char[]
				{
					'-'
				})[2]) < NF.CVal(S2.Split(new char[]
				{
					'-'
				})[2]))
				{
					num3 += 1.0;
				}
				result = (num3 >= 1.0);
			}
			return result;
		}

		public bool method_0(ObjectId ID)
		{
			int num;
			int num4;
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
					DBText dbtext = (DBText)transaction.GetObject(ID, 1);
					dbtext.ColorIndex = 1;
					transaction.Commit();
				}
				IL_61:
				goto IL_CD;
				IL_63:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_87:
				goto IL_C2;
				IL_89:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_63;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_9F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_89;
			}
			IL_C2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_CD:
			bool flag;
			bool result = flag;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public bool method_1(ObjectId ID)
		{
			int num;
			int num4;
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
					DBText dbtext = (DBText)transaction.GetObject(ID, 1);
					dbtext.ColorIndex = 3;
					transaction.Commit();
				}
				IL_61:
				goto IL_CD;
				IL_63:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_87:
				goto IL_C2;
				IL_89:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_63;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_9F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_89;
			}
			IL_C2:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_CD:
			bool flag;
			bool result = flag;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public string GetTxt(ObjectId ID)
		{
			int num;
			string textString;
			int num4;
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
					DBText dbtext = (DBText)transaction.GetObject(ID, 0);
					textString = dbtext.TextString;
				}
				IL_5B:
				goto IL_C7;
				IL_5D:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_81:
				goto IL_BC;
				IL_83:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_5D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_99:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_83;
			}
			IL_BC:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_C7:
			string result = textString;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public static DBObjectCollection CrossingPolygon(Point3dCollection PC, TypedValue[] TypedValue)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			SelectionFilter selectionFilter = new SelectionFilter(TypedValue);
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			PromptSelectionResult promptSelectionResult = editor.SelectCrossingPolygon(PC, selectionFilter);
			if (promptSelectionResult.Status == 5100)
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = promptSelectionResult.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Entity entity = transaction.GetObject(objectId, 1, true) as Entity;
						if (entity != null)
						{
							dbobjectCollection.Add(entity);
						}
					}
					transaction.Commit();
				}
			}
			return dbobjectCollection;
		}

		public static DBObjectCollection WindowPolygon(Point3dCollection PC, TypedValue[] TypedValue)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			SelectionFilter selectionFilter = new SelectionFilter(TypedValue);
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			PromptSelectionResult promptSelectionResult = editor.SelectWindowPolygon(PC, selectionFilter);
			if (promptSelectionResult.Status == 5100)
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = promptSelectionResult.Value;
					foreach (ObjectId objectId in value.GetObjectIds())
					{
						Entity entity = transaction.GetObject(objectId, 1, true) as Entity;
						if (entity != null)
						{
							dbobjectCollection.Add(entity);
						}
					}
					transaction.Commit();
				}
			}
			return dbobjectCollection;
		}

		[CommandMethod("TcAsv")]
		public void TcAsv()
		{
			TcAsv_Frm tcAsv_Frm = new TcAsv_Frm();
			Application.ShowModelessDialog(tcAsv_Frm);
		}

		[CommandMethod("TcZhuAsv")]
		public void TcZhuAsv()
		{
			int num;
			int num3;
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,TEXT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_52:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_63:
				num2 = 8;
				if (selection.Status != 5100)
				{
					goto IL_CD;
				}
				IL_75:
				num2 = 9;
				TcAsv_Frm tcAsv_Frm = new TcAsv_Frm();
				IL_7E:
				num2 = 10;
				Application.ShowModelessDialog(tcAsv_Frm);
				IL_87:
				num2 = 11;
				tcAsv_Frm.QZ_Collection = selection.Value;
				IL_97:
				num2 = 12;
				tcAsv_Frm.TextBox9.Text = Conversions.ToString(35);
				IL_AC:
				num2 = 13;
				tcAsv_Frm.RadioButton2.Checked = true;
				IL_BB:
				num2 = 14;
				tcAsv_Frm.FenXi_Z();
				IL_C4:
				num2 = 15;
				tcAsv_Frm.Asv();
				IL_CD:
				num2 = 17;
				if (Information.Err().Number <= 0)
				{
				}
				IL_DF:
				goto IL_185;
				IL_E4:
				goto IL_190;
				IL_E9:
				num3 = num2;
				if (num <= -2)
				{
					goto IL_101;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_15F;
				IL_101:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_15F:
				goto IL_190;
			}
			catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_E9;
			}
			IL_185:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_190:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		[CommandMethod("TcQiangAsv")]
		public void TcQiangAsv1()
		{
			int num;
			int num4;
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
				TypedValue[] array = new TypedValue[1];
				IL_29:
				num2 = 5;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE,TEXT");
				array2.SetValue(typedValue, 0);
				IL_47:
				num2 = 6;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_51:
				num2 = 7;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_61:
				num2 = 8;
				if (selection.Status != 5100)
				{
					goto IL_D2;
				}
				IL_73:
				num2 = 9;
				TcAsv_Frm tcAsv_Frm = new TcAsv_Frm();
				IL_7D:
				num2 = 10;
				Application.ShowModelessDialog(tcAsv_Frm);
				IL_87:
				num2 = 11;
				tcAsv_Frm.QZ_Collection = selection.Value;
				IL_98:
				num2 = 12;
				tcAsv_Frm.TextBox9.Text = Conversions.ToString(23);
				IL_AE:
				num2 = 13;
				tcAsv_Frm.RadioButton1.Checked = true;
				IL_BE:
				num2 = 14;
				tcAsv_Frm.FenXi_Q();
				IL_C8:
				num2 = 15;
				tcAsv_Frm.Asv();
				IL_D2:
				num2 = 17;
				if (Information.Err().Number <= 0)
				{
					goto IL_F9;
				}
				IL_E4:
				num2 = 18;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_F9:
				goto IL_1A4;
				IL_FE:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_15E:
				goto IL_199;
				IL_160:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_FE;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_176:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_160;
			}
			IL_199:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1A4:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcGJDY")]
		public void TcGJDY()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "LWPOLYLINE");
			array2.SetValue(typedValue, 0);
			SelectionFilter selectionFilter = new SelectionFilter(array);
			PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
			Point3d entCenter;
			if (selection.Status == 5100)
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = selection.Value;
					double num = double.MinValue;
					Polyline polyline = null;
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							Polyline polyline2 = (Polyline)transaction.GetObject(selectedObject.ObjectId, 1);
							if (!polyline2.Closed && polyline2.Area > num)
							{
								num = polyline2.Area;
								polyline = polyline2;
								entCenter = CAD.GetEntCenter(polyline2);
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
					dbobjectCollection.Add(polyline);
					try
					{
						foreach (object obj2 in value)
						{
							SelectedObject selectedObject2 = (SelectedObject)obj2;
							Polyline polyline3 = (Polyline)transaction.GetObject(selectedObject2.ObjectId, 1);
							if (polyline3.GetStartWidthAt(0) != 0.0 && polyline3.Area > 10000.0 && !polyline3.Closed)
							{
								Polyline polyline4 = (Polyline)polyline3.Clone();
								CAD.EntScale(polyline4, entCenter, 0.3);
								if (!dbobjectCollection.Contains(polyline3))
								{
									double num2 = polyline3.GeometricExtents.MinPoint.GetVectorTo(polyline3.GeometricExtents.MaxPoint).AngleOnPlane(new Plane());
									if (num2 > 0.78539816339744828)
									{
										CAD.EntMove(polyline4.ObjectId, entCenter, CAD.GetPointXY(entCenter, 50.0, 75.0));
									}
									else
									{
										CAD.EntMove(polyline4.ObjectId, entCenter, CAD.GetPointXY(entCenter, 75.0, 50.0));
									}
								}
								CAD.AddEnt(polyline4);
								objectIdCollection.Add(polyline4.ObjectId);
							}
						}
					}
					finally
					{
						IEnumerator enumerator2;
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
			}
			JigEntIDs1 jigEntIDs = new JigEntIDs1();
			jigEntIDs.method_0(objectIdCollection, entCenter);
			if (Information.Err().Number > 0)
			{
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			}
		}

		[CommandMethod("TcQZLJ_Layer")]
		public void TcQZLJ_Layer()
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
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_37:
				num2 = 4;
				CAD.CreateLayer("墙柱拉筋", 14, "continuous", -3, false, true);
				IL_4F:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_5C:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_66:
				num2 = 7;
				TypedValue[] array = new TypedValue[1];
				IL_70:
				num2 = 8;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_8E:
				num2 = 9;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_9A:
				num2 = 10;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_AC:
				num2 = 11;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = selection.Value;
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						CAD.ChangeLayer(selectedObject.ObjectId, "墙柱拉筋");
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_130:
				num2 = 13;
				documentLock.Dispose();
				IL_139:
				goto IL_1CC;
				IL_13E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_186:
				goto IL_1C1;
				IL_188:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_13E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19E:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_188;
			}
			IL_1C1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1CC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQZGJ_Layer")]
		public void TcQZGJ_Layer()
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
				Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_37:
				num2 = 4;
				CAD.CreateLayer("墙柱小箍筋", 14, "continuous", -3, false, true);
				IL_4F:
				num2 = 5;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_5C:
				num2 = 6;
				Database database = mdiActiveDocument.Database;
				IL_66:
				num2 = 7;
				TypedValue[] array = new TypedValue[1];
				IL_70:
				num2 = 8;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "LWPOLYLINE");
				array2.SetValue(typedValue, 0);
				IL_8E:
				num2 = 9;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_9A:
				num2 = 10;
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				IL_AC:
				num2 = 11;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					SelectionSet value = selection.Value;
					IEnumerator enumerator = value.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SelectedObject selectedObject = (SelectedObject)obj;
						CAD.ChangeLayer(selectedObject.ObjectId, "墙柱小箍筋");
					}
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					transaction.Commit();
				}
				IL_130:
				num2 = 13;
				documentLock.Dispose();
				IL_139:
				goto IL_1CC;
				IL_13E:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_186:
				goto IL_1C1;
				IL_188:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_13E;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19E:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_188;
			}
			IL_1C1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1CC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcLiangBHJia")]
		public void LAdd()
		{
			string prompt = "输入调整规则：\r\n   1、从某个梁编号开始往后编号均+1，输入KL*\r\n   2、在某两个梁编号之间编号均+1，输入KL*/KL*";
			string text = Interaction.InputBox(prompt, "田草结构工具箱.Net版", "KL2", -1, -1);
			checked
			{
				short num = (short)Math.Round(NF.CVal(text));
				string text2 = this.LiangMing(text);
				short num2;
				if (Strings.InStr(text, "/", CompareMethod.Binary) > 0)
				{
					num2 = (short)Math.Round(NF.CVal(text.Substring(Strings.InStr(text, "/", CompareMethod.Binary))));
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
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
					short num3 = (short)(value.Count - 1);
					short num4 = 0;
					short num5 = num3;
					short num6 = num4;
					for (;;)
					{
						short num7 = num6;
						short num8 = num5;
						if (num7 > num8)
						{
							break;
						}
						using (Transaction transaction = database.TransactionManager.StartTransaction())
						{
							DBText dbtext = (DBText)transaction.GetObject(value[(int)num6].ObjectId, 1);
							string text3 = dbtext.TextString;
							if (Operators.CompareString(text3.Substring(0, text2.Length), text2, false) == 0)
							{
								short num9 = (short)Math.Round(NF.CVal(text3));
								if (num2 == 0)
								{
									if (num9 >= num)
									{
										text3 = text3.Replace(text2 + num9.ToString(), text2 + ((int)(num9 + 1)).ToString());
										dbtext.TextString = text3;
									}
								}
								else
								{
									Interaction.MsgBox(num2, MsgBoxStyle.OkOnly, null);
									Interaction.MsgBox(num, MsgBoxStyle.OkOnly, null);
									if (num9 >= num & num9 <= num2)
									{
										text3 = text3.Replace(text2 + num9.ToString(), text2 + ((int)(num9 + 1)).ToString());
										dbtext.TextString = text3;
									}
								}
							}
							transaction.Commit();
						}
						unchecked
						{
							num6 += 1;
						}
					}
				}
				database.Regenmode = true;
			}
		}

		[CommandMethod("TcLiangBHJian")]
		public void LDel()
		{
			string text = Interaction.InputBox("输入编号调整的起始号(比如KL*或者LL*等):", "田草结构工具箱.Net版", "KL2", -1, -1);
			checked
			{
				short num = (short)Math.Round(NF.CVal(text));
				string text2 = this.LiangMing(text);
				short num2;
				if (Strings.InStr(text, "/", CompareMethod.Binary) > 0)
				{
					num2 = (short)Math.Round(NF.CVal(text.Substring(Strings.InStr(text, "/", CompareMethod.Binary))));
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
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
					short num3 = (short)(value.Count - 1);
					short num4 = 0;
					short num5 = num3;
					short num6 = num4;
					for (;;)
					{
						short num7 = num6;
						short num8 = num5;
						if (num7 > num8)
						{
							break;
						}
						using (Transaction transaction = database.TransactionManager.StartTransaction())
						{
							DBText dbtext = (DBText)transaction.GetObject(value[(int)num6].ObjectId, 1);
							string text3 = dbtext.TextString;
							if (Operators.CompareString(text3.Substring(0, text2.Length), text2, false) == 0)
							{
								short num9 = (short)Math.Round(NF.CVal(text3));
								if (num2 == 0)
								{
									if (num9 >= num)
									{
										text3 = text3.Replace(text2 + num9.ToString(), text2 + ((int)(num9 - 1)).ToString());
										dbtext.TextString = text3;
									}
								}
								else if (num9 >= num & num9 <= num2)
								{
									text3 = text3.Replace(text2 + num9.ToString(), text2 + ((int)(num9 - 1)).ToString());
									dbtext.TextString = text3;
								}
							}
							transaction.Commit();
						}
						unchecked
						{
							num6 += 1;
						}
					}
				}
				database.Regenmode = true;
			}
		}

		public string LiangMing(string S)
		{
			short num3;
			short num4;
			checked
			{
				short num = (short)S.Length;
				short num2 = 0;
				num3 = num - 1;
				num4 = num2;
			}
			for (;;)
			{
				short num5 = num4;
				short num6 = num3;
				if (num5 > num6)
				{
					break;
				}
				string @string = S.Substring((int)num4, 1);
				if (Strings.Asc(@string) >= 48 & Strings.Asc(@string) <= 57)
				{
					break;
				}
				num4 += 1;
			}
			return S.Substring(0, (int)num4);
		}
	}
}
