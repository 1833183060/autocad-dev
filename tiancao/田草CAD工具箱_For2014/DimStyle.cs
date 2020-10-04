using System;
using System.Diagnostics;
using System.IO;
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
	public class DimStyle
	{
		[DebuggerNonUserCode]
		public DimStyle()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("Dimx")]
		public void CreatedimStyle()
		{
			string text = Interaction.InputBox("输入标注样式的名称、全局标注比例、测量标注比例,用/分开。", "田草CAD工具箱.Net版", "Dim100/100/1", -1, -1);
			string[] array = new string[3];
			string s = text;
			string text2 = "/";
			NF.Str2Arr(s, ref array, ref text2);
			if (Operators.CompareString(array[0], "", false) != 0)
			{
				string text3 = array[0];
				int int_ = Conversions.ToInteger(array[1]);
				double double_ = Conversions.ToDouble(array[2]);
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					DimStyleTable dimStyleTable = (DimStyleTable)transaction.GetObject(workingDatabase.DimStyleTableId, 1);
					ObjectId objectId = Class36.smethod_78(text3, int_, double_, false);
					if (objectId != ObjectId.Null)
					{
						DimStyleTableRecord dimStyleTableRecord = (DimStyleTableRecord)transaction.GetObject(objectId, 1);
					}
					else
					{
						editor.WriteMessage("\r标注样式 " + text3 + " 已存在！");
					}
					transaction.Commit();
				}
			}
		}

		[CommandMethod("TcCopyPAT")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void method_0()
		{
			try
			{
				string directoryPath = Class33.Class31_0.Info.DirectoryPath;
				string source = directoryPath + "\\Support\\acad.pat";
				object objectValue = RuntimeHelpers.GetObjectValue(Application.Preferences);
				object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "Files", new object[0], null, null, null));
				string text = Conversions.ToString(NewLateBinding.LateGet(objectValue2, null, "SupportPath", new object[0], null, null, null));
				string[] array = text.Split(new char[]
				{
					';'
				});
				short num = 0;
				short num2 = checked((short)(array.Length - 1));
				short num3 = num;
				for (;;)
				{
					short num4 = num3;
					short num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					string destination = array[(int)num3] + "\\acad.pat";
					FileSystem.FileCopy(source, destination);
					num3 += 1;
				}
				source = directoryPath + "\\Support\\acadiso.pat";
				short num6 = 0;
				short num7 = checked((short)(array.Length - 1));
				short num8 = num6;
				for (;;)
				{
					short num9 = num8;
					short num5 = num7;
					if (num9 > num5)
					{
						break;
					}
					string destination2 = array[(int)num8] + "\\acadiso.pat";
					FileSystem.FileCopy(source, destination2);
					num8 += 1;
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("TcCopyPAT:" + ex.Message + "\r\n" + ex.Source, MsgBoxStyle.OkOnly, null);
			}
		}

		[CommandMethod("AddDimStyleFromDWG")]
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void AddDimStyleFromDWG()
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			try
			{
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					DimStyleTable dimStyleTable = (DimStyleTable)transaction.GetObject(database.DimStyleTableId, 1);
					if (!dimStyleTable.Has("DIM100"))
					{
						string text = Class33.Class31_0.Info.DirectoryPath + "\\support\\DimStyle.Dwg";
						Database database2 = new Database(false, true);
						database2.ReadDwgFile(text, FileShare.Read, true, "");
						DimStyleTableRecord dimStyleTableRecord;
						using (Transaction transaction2 = database2.TransactionManager.StartTransaction())
						{
							DimStyleTable dimStyleTable2 = (DimStyleTable)transaction2.GetObject(database2.DimStyleTableId, 0);
							dimStyleTableRecord = (DimStyleTableRecord)transaction2.GetObject(dimStyleTable2["DIM100"], 0);
							transaction2.Dispose();
						}
						mdiActiveDocument.Editor.WriteMessage("\n" + dimStyleTableRecord.Name);
						DimStyleTableRecord dimStyleTableRecord2 = new DimStyleTableRecord();
						dimStyleTableRecord2 = (DimStyleTableRecord)dimStyleTableRecord.Clone();
						dimStyleTable.Add(dimStyleTableRecord2);
						transaction.AddNewlyCreatedDBObject(dimStyleTableRecord2, true);
						mdiActiveDocument.Editor.WriteMessage("\n标注样式:DIM100添加成功");
					}
					transaction.Commit();
				}
			}
			catch (Exception ex)
			{
				mdiActiveDocument.Editor.WriteMessage("\n标注样式加载出错: " + ex.Message);
			}
		}
	}
}
