using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 算术运算
	{
		[DebuggerNonUserCode]
		public 算术运算()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcSuanshu")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void Suanshu()
		{
			string setting = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "_TcSuanShu", "_TcSuanShu", "+100");
			string text = Interaction.InputBox("输入算术运算法则:比如+1;x2;/2;-3等", "田草CAD工具箱-算术运算", setting, -1, -1);
			if (Operators.CompareString(text, "", false) != 0)
			{
				Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "_TcSuanShu", "_TcSuanShu", text);
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
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
						try
						{
							foreach (object obj in value)
							{
								SelectedObject selectedObject = (SelectedObject)obj;
								DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 1);
								string textString = dbtext.TextString;
								short num = 0;
								if (Strings.InStr(textString, ".", CompareMethod.Binary) > 0)
								{
									num = checked((short)Strings.Len(textString.Split(new char[]
									{
										'.'
									})[1]));
								}
								object obj2 = Conversion.Val(textString);
								string text2 = text.Substring(0, 1);
								double num2 = Conversion.Val(text.Substring(1));
								double num3 = Conversions.ToDouble(obj2);
								string left = text2;
								if (Operators.CompareString(left, "+", false) == 0)
								{
									num3 = Conversions.ToDouble(Operators.AddObject(obj2, num2));
								}
								else if (Operators.CompareString(left, "-", false) == 0)
								{
									num3 = Conversions.ToDouble(Operators.SubtractObject(obj2, num2));
								}
								else if (Operators.CompareString(left, "x", false) == 0)
								{
									num3 = Conversions.ToDouble(Operators.MultiplyObject(obj2, num2));
								}
								else if (Operators.CompareString(left, "*", false) == 0)
								{
									num3 = Conversions.ToDouble(Operators.MultiplyObject(obj2, num2));
								}
								else if (Operators.CompareString(left, "X", false) == 0)
								{
									num3 = Conversions.ToDouble(Operators.MultiplyObject(obj2, num2));
								}
								else if (Operators.CompareString(left, "/", false) == 0)
								{
									num3 = Conversions.ToDouble(Operators.DivideObject(obj2, num2));
								}
								string textString2;
								if (num == 0)
								{
									textString2 = string.Format("{0:0}", num3);
								}
								else if (num == 1)
								{
									textString2 = string.Format("{0:0.0}", num3);
								}
								else if (num == 2)
								{
									textString2 = string.Format("{0:0.00}", num3);
								}
								else if (num == 3)
								{
									textString2 = string.Format("{0:0.000}", num3);
								}
								else if (num == 4)
								{
									textString2 = string.Format("{0:0.0000}", num3);
								}
								else
								{
									textString2 = Conversions.ToString(num3);
								}
								dbtext.TextString = textString2;
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
		}

		[CommandMethod("TcSuanshu1")]
		public void Suanshu1()
		{
			string text = Interaction.InputBox("输入算术运算法则:比如+1;x2;/2;-3等", "田草CAD工具箱-算术运算", "+100", -1, -1);
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
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
					try
					{
						foreach (object obj in value)
						{
							SelectedObject selectedObject = (SelectedObject)obj;
							DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 1);
							string textString = dbtext.TextString;
							object obj2 = Conversion.Val(textString);
							string text2 = text.Substring(0, 1);
							double num = Conversion.Val(text.Substring(1));
							double value2 = Conversions.ToDouble(obj2);
							string left = text2;
							if (Operators.CompareString(left, "+", false) == 0)
							{
								value2 = Conversions.ToDouble(Operators.AddObject(obj2, num));
							}
							else if (Operators.CompareString(left, "-", false) == 0)
							{
								value2 = Conversions.ToDouble(Operators.SubtractObject(obj2, num));
							}
							else if (Operators.CompareString(left, "x", false) == 0)
							{
								value2 = Conversions.ToDouble(Operators.MultiplyObject(obj2, num));
							}
							else if (Operators.CompareString(left, "*", false) == 0)
							{
								value2 = Conversions.ToDouble(Operators.MultiplyObject(obj2, num));
							}
							else if (Operators.CompareString(left, "X", false) == 0)
							{
								value2 = Conversions.ToDouble(Operators.MultiplyObject(obj2, num));
							}
							else if (Operators.CompareString(left, "/", false) == 0)
							{
								value2 = Conversions.ToDouble(Operators.DivideObject(obj2, num));
							}
							dbtext.TextString = Conversions.ToString(value2);
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

		[CommandMethod("TcFace")]
		public void TcFace()
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
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "3DFACE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							Face face = (Face)transaction.GetObject(selectedObject.ObjectId, 1);
							Interaction.MsgBox(face.GetVertexAt(0).ToString(), MsgBoxStyle.OkOnly, null);
							CAD.AddPoint(face.GetVertexAt(0));
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_121:
				num2 = 6;
				if (Information.Err().Number <= 0)
				{
					goto IL_146;
				}
				IL_132:
				num2 = 7;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_146:
				goto IL_1C2;
				IL_148:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_17C:
				goto IL_1B7;
				IL_17E:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_148;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_194:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_17E;
			}
			IL_1B7:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1C2:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public static ObjectIdCollection GetAll3DFaceEntities()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			TypedValue[] array = new TypedValue[1];
			TypedValue[] array2 = array;
			int num = 0;
			TypedValue typedValue;
			typedValue..ctor(0, "3DFACE");
			array2[num] = typedValue;
			TypedValue[] array3 = array;
			SelectionFilter selectionFilter = new SelectionFilter(array3);
			PromptSelectionResult promptSelectionResult = editor.SelectAll(selectionFilter);
			ObjectIdCollection result;
			if (promptSelectionResult.Status == 5100)
			{
				result = new ObjectIdCollection(promptSelectionResult.Value.GetObjectIds());
			}
			else
			{
				result = new ObjectIdCollection();
			}
			return result;
		}

		[CommandMethod("TcE8200")]
		public void TcE8200()
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
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[2];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "TEXT");
					array2.SetValue(typedValue, 0);
					Array array3 = array;
					typedValue..ctor(1, "%%1328@200");
					array3.SetValue(typedValue, 1);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 1);
							Class36.smethod_64(dbtext.ObjectId);
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_11A:
				goto IL_186;
				IL_11C:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_140:
				goto IL_17B;
				IL_142:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_11C;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_158:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_142;
			}
			IL_17B:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_186:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQuJianShanChu")]
		public void TcQuJianShanChu()
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
				string text = Interaction.InputBox("输入数值区间：\r\nA,B  删除A~B之间的数值\r\nA,   删除小于等于A的数值\r\n,B   删除大于等于B的数值", "田草CAD工具箱-数值区间删除", "", -1, -1);
				IL_22:
				num2 = 3;
				if (Operators.CompareString(text, "", false) != 0)
				{
					goto IL_3A;
				}
				IL_35:
				goto IL_341;
				IL_3A:
				num2 = 6;
				IL_3C:
				num2 = 7;
				string[] array = text.Split(new char[]
				{
					','
				});
				IL_53:
				num2 = 8;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_61:
				num2 = 9;
				Database database = mdiActiveDocument.Database;
				IL_6D:
				num2 = 10;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array2 = new TypedValue[1];
					Array array3 = array2;
					TypedValue typedValue;
					typedValue..ctor(0, "TEXT");
					array3.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array2);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 1);
							NF.CVal(dbtext.TextString);
							if (array.Length >= 2)
							{
								if ((Operators.CompareString(array[0], "", false) != 0 & Operators.CompareString(array[1], "", false) != 0) && (NF.CVal(dbtext.TextString) >= Conversion.Val(array[0]) & NF.CVal(dbtext.TextString) <= Conversion.Val(array[1])))
								{
									Class36.smethod_64(dbtext.ObjectId);
								}
								if ((Operators.CompareString(array[0], "", false) != 0 & Operators.CompareString(array[1], "", false) == 0) && NF.CVal(dbtext.TextString) <= Conversion.Val(array[0]))
								{
									Class36.smethod_64(dbtext.ObjectId);
								}
								if ((Operators.CompareString(array[0], "", false) == 0 & Operators.CompareString(array[1], "", false) != 0) && NF.CVal(dbtext.TextString) >= Conversion.Val(array[1]))
								{
									Class36.smethod_64(dbtext.ObjectId);
								}
							}
							else if (array.Length == 1 && NF.CVal(dbtext.TextString) <= Conversion.Val(array[0]))
							{
								Class36.smethod_64(dbtext.ObjectId);
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_2B2:
				goto IL_341;
				IL_2B7:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2FB:
				goto IL_336;
				IL_2FD:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_2B7;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_313:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2FD;
			}
			IL_336:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_341:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[CommandMethod("TcQuTongShanChu")]
		public void TcQuTongShanChu()
		{
			int num;
			int num6;
			object obj2;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				long num3 = Conversions.ToLong(Interaction.InputBox("输入通筋面积", "田草CAD工具箱-板筋去通删除", "", -1, -1));
				IL_27:
				num2 = 3;
				if (num3 != 0L)
				{
					goto IL_3C;
				}
				IL_37:
				goto IL_1EA;
				IL_3C:
				num2 = 6;
				IL_3E:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4B:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_55:
				num2 = 9;
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
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 1);
							double num4 = NF.CVal(dbtext.TextString);
							if (num4 <= (double)num3)
							{
								dbtext.Erase();
							}
							else
							{
								dbtext.TextString = Conversions.ToString(num4 - (double)num3);
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_15F:
				goto IL_1EA;
				IL_164:
				int num5 = num6 + 1;
				num6 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_1A4:
				goto IL_1DF;
				IL_1A6:
				num6 = num2;
				if (num <= -2)
				{
					goto IL_164;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1BC:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num6 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_1A6;
			}
			IL_1DF:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1EA:
			if (num6 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}
	}
}
