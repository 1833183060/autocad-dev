using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class SBGJ
	{
		public SBGJ()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.timer_0 = new Timer();
			this.timer_1 = new Timer();
		}

		[CommandMethod("TcPen")]
		public void TcPen()
		{
			this.long_0 = 0L;
			CAD.CreateLayer("注释", 1, "continuous", 30, false, false);
			this.point3dCollection_0 = new Point3dCollection();
			this.objectIdCollection_0 = new ObjectIdCollection();
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			this.timer_0.Interval = 100;
			this.timer_1.Interval = 100;
			this.timer_0.Tick += this.timer1_Tick;
			this.timer_1.Tick += this.timer2_Tick;
			this.timer_0.Start();
			this.timer_1.Stop();
		}

		public void timer1_Tick(object sender, EventArgs e)
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			checked
			{
				if (WinAPI.GetAsyncKeyState(1L) == -32768 | WinAPI.GetAsyncKeyState(1L) == 32768)
				{
					if (this.long_0 == 0L)
					{
						this.timer_0.Interval = 500;
						editor.WriteMessage("\r\n开始 " + Conversions.ToString(this.long_0));
						mdiActiveDocument.SendStringToExecute("\u0003\u0003", false, false, false);
						editor.PointMonitor += new PointMonitorEventHandler(this.GetMousePoint);
						this.long_0 += 1L;
						this.timer_1.Start();
					}
					else
					{
						this.long_1 += 1L;
					}
				}
				else
				{
					editor.WriteMessage("\r\n鼠标在滑动 " + Conversions.ToString(this.long_0));
				}
			}
		}

		public void timer2_Tick(object sender, EventArgs e)
		{
			int num2;
			int num9;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_0E:
				num = 2;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_16:
				num = 3;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_28:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_30:
				num = 5;
				if (!(WinAPI.GetAsyncKeyState(1L) == -32768 | WinAPI.GetAsyncKeyState(1L) == 32768))
				{
					goto IL_1E7;
				}
				IL_62:
				num = 6;
				if (this.long_0 == 0L)
				{
					goto IL_1E7;
				}
				IL_7D:
				num = 7;
				editor.WriteMessage("\r\n停止 " + Conversions.ToString(this.long_0));
				IL_9A:
				num = 8;
				editor.WriteMessage("\r\n停止 " + Conversions.ToString(this.point3dCollection_0.Count));
				IL_BC:
				num = 9;
				mdiActiveDocument.SendStringToExecute("\u0003\u0003", false, false, false);
				IL_CD:
				num = 10;
				editor.PointMonitor -= new PointMonitorEventHandler(this.GetMousePoint);
				IL_E3:
				num = 11;
				this.timer_0.Tick -= this.timer1_Tick;
				IL_FE:
				num = 12;
				this.timer_1.Tick -= this.timer2_Tick;
				IL_119:
				num = 13;
				editor.WriteMessage("\r\nIDC " + Conversions.ToString(this.objectIdCollection_0.Count));
				IL_13C:
				num = 14;
				Database workingDatabase2 = HostApplicationServices.WorkingDatabase;
				IL_146:
				num = 15;
				using (mdiActiveDocument.LockDocument())
				{
					using (Transaction transaction = workingDatabase2.TransactionManager.StartTransaction())
					{
						long num3 = 0L;
						long num4 = (long)(checked(this.objectIdCollection_0.Count - 2));
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
								Entity entity = (Entity)transaction.GetObject(this.objectIdCollection_0[(int)num5], 1);
								entity.Erase();
								num5 += 1L;
							}
							transaction.Commit();
						}
					}
				}
				IL_1E7:
				goto IL_28E;
				IL_1EC:
				int num8 = num9 + 1;
				num9 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				IL_248:
				goto IL_283;
				IL_24A:
				num9 = num;
				if (num2 <= -2)
				{
					goto IL_1EC;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_260:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num9 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_24A;
			}
			IL_283:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_28E:
			if (num9 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public void GetMousePoint(object sender, PointMonitorEventArgs e)
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			try
			{
				if (this.point3dCollection_0.Count >= 1)
				{
					this.AddPline1(this.point3dCollection_0, 250.0, "注释");
				}
				this.point3dCollection_0.Add(e.Context.RawPoint);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		public ObjectId AddPline1(Point3dCollection pts, double width, string LN)
		{
			int num2;
			int num10;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_0E:
				num = 2;
				Database database = mdiActiveDocument.Database;
				IL_17:
				num = 3;
				Polyline polyline = new Polyline();
				IL_1F:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_28:
				num = 5;
				checked
				{
					using (DocumentLock documentLock = mdiActiveDocument.LockDocument())
					{
						using (Transaction transaction = database.TransactionManager.StartTransaction())
						{
							int count = pts.Count;
							int num3 = 0;
							int num4 = count - 1;
							int num5 = num3;
							for (;;)
							{
								int num6 = num5;
								int num7 = num4;
								if (num6 > num7)
								{
									break;
								}
								Polyline polyline2 = polyline;
								int num8 = num5;
								Point2d point2d;
								point2d..ctor(pts[num5].X, pts[num5].Y);
								polyline2.AddVertexAt(num8, point2d, 0.0, width, width);
								num5++;
							}
							polyline.Layer = LN;
							BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
							BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
							blockTableRecord.AppendEntity(polyline);
							transaction.AddNewlyCreatedDBObject(polyline, true);
							transaction.Commit();
						}
						this.objectIdCollection_0.Add(polyline.ObjectId);
						documentLock.Dispose();
					}
					IL_131:
					goto IL_1A4;
					IL_133:;
				}
				int num9 = num10 + 1;
				num10 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num9);
				IL_15B:
				goto IL_199;
				IL_15D:
				num10 = num;
				if (num2 <= -2)
				{
					goto IL_133;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_175:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num10 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_15D;
			}
			IL_199:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1A4:
			ObjectId objectId;
			ObjectId result = objectId;
			if (num10 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		[CommandMethod("ListLayouts")]
		public static void ListLayouts()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.LayoutDictionaryId, 0);
				mdiActiveDocument.Editor.WriteMessage("\nLayouts:");
				try
				{
					foreach (DBDictionaryEntry dbdictionaryEntry in dbdictionary)
					{
						mdiActiveDocument.Editor.WriteMessage("\n  " + dbdictionaryEntry.Key);
					}
				}
				finally
				{
					DbDictionaryEnumerator enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				transaction.Abort();
			}
		}

		[CommandMethod("GetActiveDocumentScreenShot")]
		public void GetActiveDocumentScreenShot()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			editor.WriteMessage("\n 初始尺寸尺寸<Size>:" + mdiActiveDocument.Window.DeviceIndependentSize.ToString() + "\n");
			PromptIntegerOptions promptIntegerOptions = new PromptIntegerOptions("\n 请输入放大倍数<5>: ");
			promptIntegerOptions.AllowNone = true;
			promptIntegerOptions.DefaultValue = 5;
			promptIntegerOptions.LowerLimit = 1;
			promptIntegerOptions.UpperLimit = 10;
			PromptIntegerResult integer = mdiActiveDocument.Editor.GetInteger(promptIntegerOptions);
			PromptStatus status = integer.Status;
			if (status == 5100)
			{
				int value = integer.Value;
			}
			else if (status == 5000)
			{
				int defaultValue = promptIntegerOptions.DefaultValue;
			}
			else if (status == -5002)
			{
				mdiActiveDocument.Editor.WriteMessage("\n用户取消了输入");
			}
			string str = mdiActiveDocument.Database.Filename + ".Png";
			editor.WriteMessage("\n 保存位置<Filename>:" + str + "\n");
		}

		[CommandMethod("TcSelectSimilar", 6)]
		public void TcSelectSimilar()
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_16:
				num2 = 3;
				Database database = mdiActiveDocument.Database;
				IL_1F:
				num2 = 4;
				Editor editor = mdiActiveDocument.Editor;
				IL_29:
				num2 = 5;
				PromptSelectionResult promptSelectionResult = editor.SelectImplied();
				IL_34:
				num2 = 6;
				if (promptSelectionResult.Status != -5001)
				{
					goto IL_53;
				}
				IL_46:
				num2 = 7;
				promptSelectionResult = editor.GetSelection();
				goto IL_62;
				IL_53:
				num2 = 9;
				IL_56:
				num2 = 10;
				promptSelectionResult = editor.GetSelection();
				IL_62:
				num2 = 12;
				if (promptSelectionResult.Status != 5100)
				{
					goto IL_706;
				}
				IL_78:
				num2 = 13;
				SelectionSet value = promptSelectionResult.Value;
				IL_84:
				num2 = 14;
				TypedValue[] array = new TypedValue[1];
				IL_8F:
				num2 = 15;
				checked
				{
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						new ArrayList();
						new ArrayList();
						array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[1]);
						Array array2 = array;
						TypedValue typedValue;
						typedValue..ctor(-4, "<or");
						array2.SetValue(typedValue, 0L);
						long num3 = 1L;
						ObjectId[] objectIds = value.GetObjectIds();
						for (int i = 0; i < objectIds.Length; i++)
						{
							Class36.objectId_0 = objectIds[i];
							Entity entity = (Entity)transaction.GetObject(Class36.objectId_0, 0);
							string name = entity.GetType().Name;
							string text = "";
							string left = name;
							if (Operators.CompareString(left, "Line", false) == 0)
							{
								text = "LINE";
							}
							else if (Operators.CompareString(left, "Polyline", false) == 0)
							{
								text = "LWPOLYLINE";
							}
							else if (Operators.CompareString(left, "DBText", false) == 0)
							{
								text = "Text";
							}
							else if (Operators.CompareString(left, "BlockReference", false) == 0)
							{
								text = "INSERT";
							}
							else if (Operators.CompareString(left, "Circle", false) == 0)
							{
								text = "CIRCLE";
							}
							else if (Operators.CompareString(left, "Arc", false) == 0)
							{
								text = "ARC";
							}
							else if (Operators.CompareString(left, "ATTDEF", false) == 0)
							{
								text = "ATTDEF";
							}
							else if (Operators.CompareString(left, "Ellipse", false) == 0)
							{
								text = "ELLIPSE";
							}
							else if (Operators.CompareString(left, "Region", false) == 0)
							{
								text = "REGION";
							}
							else if (Operators.CompareString(left, "Hatch", false) == 0)
							{
								text = "HATCH";
							}
							else if (Operators.CompareString(left, "Dimension", false) == 0)
							{
								text = "Dimension";
							}
							else if (Operators.CompareString(left, "AlignedDimension", false) == 0)
							{
								text = "Dimension";
							}
							else if (Operators.CompareString(left, "RotatedDimension", false) == 0)
							{
								text = "Dimension";
							}
							else if (Operators.CompareString(left, "3DFACE", false) == 0)
							{
								text = "3DFACE";
							}
							else if (Operators.CompareString(left, "3DSolid", false) == 0)
							{
								text = "3DSolid";
							}
							else if (Operators.CompareString(left, "ImpEntity", false) == 0)
							{
								text = "TCH_OPENING";
							}
							else if (Operators.CompareString(left, "ImpCurve", false) == 0)
							{
								string layer = entity.Layer;
								if (Operators.CompareString(layer, "PUB_DIM", false) == 0)
								{
									text = "TCH_DIMENSION2";
								}
								else if (Operators.CompareString(layer, "AXIS", false) == 0)
								{
									text = "TCH_DIMENSION2";
								}
							}
							array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
							Array array3 = array;
							typedValue..ctor(-4, "<and");
							array3.SetValue(typedValue, num3);
							num3 += 1L;
							if (Operators.CompareString(text, "", false) != 0)
							{
								array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
								Array array4 = array;
								typedValue..ctor(0, text);
								array4.SetValue(typedValue, num3);
								num3 += 1L;
							}
							array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
							Array array5 = array;
							typedValue..ctor(8, entity.Layer);
							array5.SetValue(typedValue, num3);
							num3 += 1L;
							array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
							Array array6 = array;
							typedValue..ctor(62, entity.ColorIndex);
							array6.SetValue(typedValue, num3);
							num3 += 1L;
							if (Operators.CompareString(text, "Text", false) == 0)
							{
								DBText dbtext = (DBText)entity;
								array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
								Array array7 = array;
								typedValue..ctor(1, dbtext.TextString);
								array7.SetValue(typedValue, num3);
								num3 += 1L;
							}
							if (Operators.CompareString(text, "INSERT", false) == 0)
							{
								BlockReference blockReference = (BlockReference)entity;
								BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.BlockTableRecord, 0);
								array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
								Array array8 = array;
								typedValue..ctor(2, blockTableRecord.Name);
								array8.SetValue(typedValue, num3);
								num3 += 1L;
							}
							array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
							Array array9 = array;
							typedValue..ctor(-4, "and>");
							array9.SetValue(typedValue, num3);
							num3 += 1L;
						}
						array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[(int)num3 + 1]);
						Array array10 = array;
						typedValue..ctor(-4, "or>");
						array10.SetValue(typedValue, num3);
						num3 += 1L;
						transaction.Commit();
					}
					IL_656:
					num2 = 17;
					PromptSelectionResult promptSelectionResult2 = editor.GetSelection(new SelectionFilter(array));
					IL_669:
					num2 = 18;
					if (promptSelectionResult2.Status != 5100)
					{
						goto IL_6B7;
					}
					IL_67C:
					num2 = 19;
					SelectionSet value2 = promptSelectionResult2.Value;
					IL_687:
					num2 = 20;
					ObjectId[] objectIds2 = promptSelectionResult2.Value.GetObjectIds();
					IL_698:
					num2 = 21;
					if (objectIds2 == null)
					{
						goto IL_706;
					}
					IL_6A5:
					num2 = 22;
					mdiActiveDocument.Editor.SetImpliedSelection(objectIds2);
					goto IL_706;
					IL_6B7:
					num2 = 25;
					IL_6BA:
					num2 = 26;
					promptSelectionResult2 = editor.SelectAll(new SelectionFilter(array));
					IL_6CD:
					num2 = 27;
					SelectionSet value3 = promptSelectionResult2.Value;
					IL_6D8:
					num2 = 28;
					ObjectId[] objectIds3 = promptSelectionResult2.Value.GetObjectIds();
					IL_6E9:
					num2 = 29;
					if (objectIds3 == null)
					{
						goto IL_706;
					}
					IL_6F6:
					num2 = 30;
					mdiActiveDocument.Editor.SetImpliedSelection(objectIds3);
					IL_706:
					num2 = 34;
					if (Information.Err().Number <= 0)
					{
					}
					IL_718:
					goto IL_806;
					IL_71D:;
				}
				int num4 = num5 + 1;
				num5 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_7BD:
				goto IL_7FB;
				IL_7BF:
				num5 = num2;
				if (num <= -2)
				{
					goto IL_71D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_7D8:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num5 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_7BF;
			}
			IL_7FB:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_806:
			if (num5 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("Tctype", 0)]
		public void ShowType()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity("\nSelect entity: ");
			if (entity.Status == 5100)
			{
				using (Transaction transaction = mdiActiveDocument.TransactionManager.StartTransaction())
				{
					DBObject @object = transaction.GetObject(entity.ObjectId, 0);
					Type type = @object.GetType();
					mdiActiveDocument.Editor.WriteMessage(string.Format("\nType: '{0}'", type.ToString()));
					mdiActiveDocument.Editor.WriteMessage(string.Format("\nIsPublic: '{0}'", type.IsPublic));
					mdiActiveDocument.Editor.WriteMessage(string.Format("\nAssembly: '{0}'\n", type.Assembly.FullName));
					mdiActiveDocument.Editor.WriteMessage(new string('*', 30));
					mdiActiveDocument.Editor.WriteMessage("\n");
					PropertyInfo[] properties = type.GetProperties();
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					foreach (PropertyInfo propertyInfo in properties)
					{
						object obj;
						try
						{
							obj = RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(@object, null));
						}
						catch (Exception ex)
						{
							obj = string.Format("Exception: '{0}'", ex.Message);
						}
						dictionary.Add(string.Format("{0} [{1}]", propertyInfo.Name, propertyInfo.PropertyType), RuntimeHelpers.GetObjectValue(obj));
						mdiActiveDocument.Editor.WriteMessage(string.Format("\n\tProperty: '{0}';\tType: '{1}';\tValue.ToString: '{2}'", propertyInfo.Name, propertyInfo.PropertyType, RuntimeHelpers.GetObjectValue(obj)));
					}
				}
			}
		}

		[CommandMethod("Tctype1", 0)]
		public void MyLispFunction()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity("\nSelect entity: ");
			Document mdiActiveDocument2 = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument2.Editor;
			Database database = mdiActiveDocument2.Database;
			Transaction transaction = database.TransactionManager.StartTransaction();
			using (transaction)
			{
				try
				{
					DBObject @object = entity.ObjectId.GetObject(0);
					foreach (MemberInfo memberInfo in @object.GetType().GetMembers())
					{
						editor.WriteMessage("\n" + memberInfo.Name.ToString());
					}
					transaction.Commit();
				}
				catch (Exception ex)
				{
					throw;
				}
			}
		}

		[DllImport("acdb19.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ?acdbGetAdsName@@YA?AW4ErrorStatus@Acad@@AEAY01_JVAcDbObjectId@@@Z(long[] name, ObjectId objId);

		[DllImport("accore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern IntPtr acdbEntGet(long[] ename);

		[DllImport("accore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern IntPtr acdbEntGetX(long[] ename, IntPtr rb);

		[CommandMethod("GetEntityDxf")]
		public static void GetEntityDxf()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			PromptEntityResult entity = editor.GetEntity("\nSelect an Entity: ");
			if (entity.Status == 5100)
			{
				long[] array = new long[]
				{
					0L,
					0L
				};
				SBGJ.?acdbGetAdsName@@YA?AW4ErrorStatus@Acad@@AEAY01_JVAcDbObjectId@@@Z(array, entity.ObjectId);
				ResultBuffer resultBuffer = new ResultBuffer();
				Interop.AttachUnmanagedObject(resultBuffer, SBGJ.acdbEntGet(array), true);
				foreach (TypedValue typedValue in resultBuffer)
				{
					string str = (typedValue.Value != null) ? typedValue.Value.ToString() : "*Nothing*";
					editor.WriteMessage("\n - Code: " + typedValue.TypeCode.ToString() + " = " + str);
				}
			}
		}

		[CommandMethod("GetNOD")]
		public void getNOD()
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			using (Transaction transaction = HostApplicationServices.WorkingDatabase.TransactionManager.StartTransaction())
			{
				DBDictionary dbdictionary = transaction.GetObject(HostApplicationServices.WorkingDatabase.NamedObjectsDictionaryId, 0) as DBDictionary;
				try
				{
					foreach (DBDictionaryEntry dbdictionaryEntry in dbdictionary)
					{
						editor.WriteMessage("Key:\t" + dbdictionaryEntry.Key.ToString() + "\n");
					}
				}
				finally
				{
					DbDictionaryEnumerator enumerator;
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
		}

		[CommandMethod("BindXrefs")]
		public void BindXrefs()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)database.BlockTableId.GetObject(0);
				try
				{
					foreach (ObjectId objectId in blockTable)
					{
						BlockTableRecord blockTableRecord = (BlockTableRecord)objectId.GetObject(0);
						if (blockTableRecord.XrefStatus == 0)
						{
							goto IL_77;
						}
						if (blockTableRecord.XrefStatus == 4)
						{
							goto IL_77;
						}
						bool flag = true;
						IL_78:
						if (flag)
						{
							ObjectIdCollection objectIdCollection = new ObjectIdCollection();
							objectIdCollection.Add(objectId);
							database.BindXrefs(objectIdCollection, false);
							continue;
						}
						continue;
						IL_77:
						flag = false;
						goto IL_78;
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

		[CommandMethod("DetachXrefs")]
		public void DetachXrefs()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)database.BlockTableId.GetObject(0);
				try
				{
					foreach (ObjectId objectId in blockTable)
					{
						BlockTableRecord blockTableRecord = (BlockTableRecord)objectId.GetObject(0);
						if (blockTableRecord.XrefStatus == 0)
						{
							goto IL_77;
						}
						if (blockTableRecord.XrefStatus == 1)
						{
							goto IL_77;
						}
						bool flag = true;
						IL_78:
						if (flag)
						{
							database.DetachXref(objectId);
							continue;
						}
						continue;
						IL_77:
						flag = false;
						goto IL_78;
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

		[CommandMethod("TcPu")]
		public static void TcPu()
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				if (mdiActiveDocument != null)
				{
					Database database = mdiActiveDocument.Database;
					using (Transaction transaction = database.TransactionManager.StartTransaction())
					{
						SBGJ.PurgeDb(database, transaction, true);
						SBGJ.smethod_0(database, transaction);
						transaction.Commit();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public static void PurgeDb(Database db, Transaction tr, bool clearDGN = false)
		{
			try
			{
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				objectIdCollection.Add(db.LayerTableId);
				objectIdCollection.Add(db.LinetypeTableId);
				objectIdCollection.Add(db.TextStyleTableId);
				objectIdCollection.Add(db.BlockTableId);
				objectIdCollection.Add(db.DimStyleTableId);
				if (tr == null)
				{
					Transaction transaction = db.TransactionManager.StartTransaction();
					tr = transaction;
					using (transaction)
					{
						if (clearDGN)
						{
							SBGJ.PurgeDGN(db, tr);
						}
						SBGJ.PurgeItems(db, tr, objectIdCollection);
						goto IL_97;
					}
				}
				if (clearDGN)
				{
					SBGJ.PurgeDGN(db, tr);
				}
				SBGJ.PurgeItems(db, tr, objectIdCollection);
				IL_97:;
			}
			catch (Exception ex)
			{
			}
		}

		public static void PurgeDGN(Database db, Transaction tr)
		{
			string text = "ACAD_DGNLINESTYLECOMP";
			DBDictionary dbdictionary = tr.GetObject(db.NamedObjectsDictionaryId, 1) as DBDictionary;
			if (dbdictionary != null && dbdictionary.Contains(text))
			{
				dbdictionary.Remove(text);
			}
		}

		public static bool PurgeItems(Database db, Transaction tr, ObjectIdCollection tableIds)
		{
			bool result = false;
			checked
			{
				try
				{
					int num = 0;
					do
					{
						ObjectIdCollection objectIdCollection = new ObjectIdCollection();
						ObjectId objectId2;
						try
						{
							foreach (object obj in tableIds)
							{
								ObjectId objectId = (obj != null) ? ((ObjectId)obj) : objectId2;
								SymbolTable symbolTable = (SymbolTable)tr.GetObject(objectId, 0, false);
								try
								{
									foreach (ObjectId objectId3 in symbolTable)
									{
										objectIdCollection.Add(objectId3);
									}
								}
								finally
								{
									SymbolTableEnumerator enumerator2;
									if (enumerator2 != null)
									{
										enumerator2.Dispose();
									}
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
						db.Purge(objectIdCollection);
						if (objectIdCollection.Count != 0)
						{
							result = true;
							try
							{
								foreach (object obj2 in objectIdCollection)
								{
									ObjectId objectId4 = (obj2 != null) ? ((ObjectId)obj2) : objectId2;
									SymbolTableRecord symbolTableRecord = (SymbolTableRecord)tr.GetObject(objectId4, 1);
									string name = symbolTableRecord.Name;
									symbolTableRecord.Erase();
								}
							}
							finally
							{
								IEnumerator enumerator3;
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
						}
						num++;
					}
					while (num <= 2);
				}
				catch (Exception ex)
				{
				}
				return result;
			}
		}

		private static string smethod_0(Database database_0, Transaction transaction_0)
		{
			int num = 0;
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			checked
			{
				try
				{
					objectIdCollection.Clear();
					foreach (ObjectId objectId in ((SymbolTable)transaction_0.GetObject(database_0.LayerTableId, 0, false)))
					{
						if (objectId.IsValid)
						{
							objectIdCollection.Add(objectId);
						}
					}
					database_0.Purge(objectIdCollection);
					int num2 = 0;
					try
					{
						foreach (object obj in objectIdCollection)
						{
							ObjectId objectId3;
							ObjectId objectId2 = (obj != null) ? ((ObjectId)obj) : objectId3;
							DBObject @object = transaction_0.GetObject(objectId2, 1);
							if (!((LayerTableRecord)@object).IsDependent)
							{
								@object.Erase();
								num++;
							}
							num2++;
							string string_ = string.Format("{0} out of {1} {2} remaining...Deleting entity: {3}", new object[]
							{
								num2,
								objectIdCollection.Count,
								objectIdCollection.Count - num2,
								objectId2.ObjectClass.DxfName
							});
							Class36.smethod_60(string_);
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
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
				finally
				{
				}
				return num.ToString();
			}
		}

		[CommandMethod("TcMoveTextInBlock")]
		public static void TcMoveTextInBlock()
		{
			checked
			{
				try
				{
					Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
					Interaction.MsgBox(mdiActiveDocument.Window.DeviceIndependentSize.Width, MsgBoxStyle.OkOnly, null);
					Interaction.MsgBox(mdiActiveDocument.Window.DeviceIndependentSize.Height, MsgBoxStyle.OkOnly, null);
					SBGJ.ScreenShotToFile(mdiActiveDocument.Window, "C:\\temp.bmp", 0, (int)Math.Round(mdiActiveDocument.Window.DeviceIndependentSize.Height), 0, (int)Math.Round(mdiActiveDocument.Window.DeviceIndependentSize.Width));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		public static void ScreenShotToFile(Window wd, string filename, int top, int bottom, int left, int right)
		{
			System.Windows.Point deviceIndependentLocation = wd.DeviceIndependentLocation;
			System.Windows.Size deviceIndependentSize = wd.DeviceIndependentSize;
			checked
			{
				System.Drawing.Point point = new System.Drawing.Point((int)Math.Round(deviceIndependentLocation.X), (int)Math.Round(deviceIndependentLocation.Y));
				System.Drawing.Size blockRegionSize = new System.Drawing.Size((int)Math.Round(deviceIndependentSize.Width), (int)Math.Round(deviceIndependentSize.Height));
				point.X += left;
				point.Y += top;
				blockRegionSize.Height -= top + bottom;
				blockRegionSize.Width -= left + right;
				Bitmap bitmap = new Bitmap(blockRegionSize.Width, blockRegionSize.Height, PixelFormat.Format32bppArgb);
				using (bitmap)
				{
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.CopyFromScreen(point.X, point.Y, 0, 0, blockRegionSize, CopyPixelOperation.SourceCopy);
						bitmap.Save(filename, ImageFormat.Jpeg);
					}
				}
			}
		}

		public bool SelectNestedEntitiesAuto(Editor ed, Point3d pos, out ObjectId id, out ObjectId[] ids, out string result, out Point3d point)
		{
			result = "";
			id = ObjectId.Null;
			ids = null;
			point = default(Point3d);
			PromptNestedEntityResult nestedEntity = ed.GetNestedEntity(new PromptNestedEntityOptions("")
			{
				NonInteractivePickPoint = pos,
				UseNonInteractivePickPoint = true
			});
			if (nestedEntity.Status == 5100)
			{
				id = nestedEntity.ObjectId;
				ObjectId objectId = nestedEntity.ObjectId;
				List<ObjectId> list = new List<ObjectId>(nestedEntity.GetContainers());
				list.Reverse();
				list.Add(objectId);
				ids = list.ToArray();
				point = nestedEntity.PickedPoint;
			}
			return nestedEntity.Status == 5100;
		}

		public static bool SelectNestedEntities(Editor ed, string msg, string keyword, out ObjectId id, out ObjectId[] ids, out string result, out Point3d point)
		{
			result = "";
			id = ObjectId.Null;
			ids = null;
			point = default(Point3d);
			PromptNestedEntityResult nestedEntity;
			if (!string.IsNullOrEmpty(keyword))
			{
				PromptNestedEntityOptions promptNestedEntityOptions = new PromptNestedEntityOptions(msg, keyword);
				nestedEntity = ed.GetNestedEntity(promptNestedEntityOptions);
			}
			else
			{
				nestedEntity = ed.GetNestedEntity(msg);
			}
			if (nestedEntity.Status == 5100)
			{
				id = nestedEntity.ObjectId;
				ObjectId objectId = nestedEntity.ObjectId;
				List<ObjectId> list = new List<ObjectId>(nestedEntity.GetContainers());
				list.Reverse();
				list.Add(objectId);
				ids = list.ToArray();
				point = nestedEntity.PickedPoint;
			}
			else if (nestedEntity.Status == -5005)
			{
				result = nestedEntity.StringResult;
			}
			return nestedEntity.Status == 5100;
		}

		private Point3dCollection point3dCollection_0;

		private Timer timer_0;

		private Timer timer_1;

		private long long_0;

		private long long_1;

		private ObjectIdCollection objectIdCollection_0;
	}
}
