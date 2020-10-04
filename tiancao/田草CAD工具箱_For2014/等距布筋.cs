using System;
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
	public class 等距布筋
	{
		[DebuggerNonUserCode]
		public 等距布筋()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcDengJuBuJin")]
		public void TcDuanMianByLine()
		{
			Point3d p;
			Point3d p2;
			Class36.smethod_31(ref p, ref p2, "选择插入点:");
			Line line = CAD.AddLine(p, p2, "0");
			string text = Interaction.InputBox("直接距离" + Conversions.ToString(checked((long)Math.Round(line.Length))) + ",请输入分布的钢筋根数", "", "2", -1, -1);
			if (Operators.CompareString(text, "", false) != 0)
			{
				double num = line.Length / (Conversions.ToDouble(text) + 1.0);
				double num2 = Class36.double_0 / 2.0;
				double num3 = num2;
				short num4;
				short num6;
				short num7;
				checked
				{
					if (num3 == 1.0)
					{
						num4 = (short)Math.Round(unchecked(35.0 * num2));
					}
					else if (num3 == 1.25)
					{
						num4 = (short)Math.Round(unchecked(30.0 * num2));
					}
					else if (num3 == 2.0)
					{
						num4 = (short)Math.Round(unchecked(25.0 * num2));
					}
					else if (num3 == 2.5)
					{
						num4 = (short)Math.Round(unchecked(25.0 * num2));
					}
					short num5 = 1;
					num6 = Conversions.ToShort(text);
					num7 = num5;
				}
				for (;;)
				{
					short num8 = num7;
					short num9 = num6;
					if (num8 > num9)
					{
						break;
					}
					Point3d pointAtDist = line.GetPointAtDist(num * (double)num7);
					Class36.smethod_16(pointAtDist, (double)num4, "墙柱纵筋");
					num7 += 1;
				}
				Class36.smethod_64(line.ObjectId);
			}
		}

		[CommandMethod("TcDengJuBuJin1")]
		public void TcDuanMianByLine1()
		{
			Entity entity = null;
			Entity e = null;
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Point3d entCenter;
			Line line;
			string text;
			checked
			{
				Point3d entCenter2;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					TypedValue[] array = new TypedValue[1];
					Array array2 = array;
					TypedValue typedValue;
					typedValue..ctor(0, "LWPOLYLINE");
					array2.SetValue(typedValue, 0);
					SelectionFilter selectionFilter = new SelectionFilter(array);
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status != 5100)
					{
						return;
					}
					SelectionSet value = selection.Value;
					if (value.Count < 1)
					{
						return;
					}
					if (value.Count > 2)
					{
						entity = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						e = (Entity)transaction.GetObject(value[value.Count - 1].ObjectId, 0);
					}
					else if (value.Count == 2)
					{
						entity = (Entity)transaction.GetObject(value[0].ObjectId, 0);
						e = (Entity)transaction.GetObject(value[1].ObjectId, 0);
					}
					entCenter = CAD.GetEntCenter(entity);
					entCenter2 = CAD.GetEntCenter(e);
					transaction.Commit();
				}
				line = CAD.AddLine(entCenter, entCenter2, "0");
				text = Interaction.InputBox("直接距离" + Conversions.ToString((long)Math.Round(line.Length)) + ",请输入分布的钢筋根数", "", "2", -1, -1);
			}
			if (Operators.CompareString(text, "", false) == 0)
			{
				Class36.smethod_64(line.ObjectId);
			}
			else
			{
				double num = line.Length / (Conversions.ToDouble(text) + 1.0);
				short num2 = 1;
				short num3 = Conversions.ToShort(text);
				short num4 = num2;
				for (;;)
				{
					short num5 = num4;
					short num6 = num3;
					if (num5 > num6)
					{
						break;
					}
					Point3d pointAtDist = line.GetPointAtDist(num * (double)num4);
					CAD.EntCopy(entity, entCenter, pointAtDist);
					num4 += 1;
				}
				Class36.smethod_64(line.ObjectId);
			}
		}

		[CommandMethod("TcGangJinDuanMian")]
		public void TcGangJinDuanMian()
		{
			Application.SetSystemVariable("ORTHOMODE", 0);
			double scale = CAD.GetScale();
			short num2;
			do
			{
				JigEntIDs jigEntIDs = new JigEntIDs();
				ObjectId[] array = new ObjectId[1];
				ObjectId[] array2 = array;
				int num = 0;
				Point3d point3d;
				point3d..ctor(0.0, 0.0, 0.0);
				array2[num] = Class36.smethod_16(point3d, 40.0 * scale, "墙柱纵筋");
				JigEntIDs jigEntIDs2 = jigEntIDs;
				ObjectId[] entIDs = array;
				point3d..ctor(0.0, 0.0, 0.0);
				num2 = jigEntIDs2.method_0(entIDs, point3d);
			}
			while (num2 != -1);
		}
	}
}
