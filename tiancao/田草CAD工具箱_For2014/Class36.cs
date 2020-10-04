using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using TcFunctions;
using 田草CAD工具箱_For2014;

[StandardModule]
internal sealed class Class36
{
	static Class36()
	{
		Class39.k1QjQlczC5Jf5();
		Class36.double_0 = 4.0;
	}

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr SetFocus(IntPtr intptr_0);

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int GetKeyState(long long_0);

	public static string smethod_0()
	{
		string text = Application.Version.ToString().Substring(0, 4);
		string left = text;
		string result;
		if (Operators.CompareString(left, "16.2", false) == 0)
		{
			result = "R16";
		}
		else if (Operators.CompareString(left, "17.0", false) == 0)
		{
			result = "R17";
		}
		else if (Operators.CompareString(left, "17.1", false) == 0)
		{
			result = "R17";
		}
		else if (Operators.CompareString(left, "17.2", false) == 0)
		{
			result = "R17";
		}
		else if (Operators.CompareString(left, "18.0", false) == 0)
		{
			result = "R18";
		}
		else if (Operators.CompareString(left, "18.1", false) == 0)
		{
			result = "R18";
		}
		else if (Operators.CompareString(left, "18.2", false) == 0)
		{
			result = "R18";
		}
		else if (Operators.CompareString(left, "19.0", false) == 0)
		{
			result = "R19";
		}
		else if (Operators.CompareString(left, "19.1", false) == 0)
		{
			result = "R19";
		}
		else if (Operators.CompareString(left, "20.0", false) == 0)
		{
			result = "R20";
		}
		else if (Operators.CompareString(left, "20.1", false) == 0)
		{
			result = "R20";
		}
		else if (Operators.CompareString(left, "21.0", false) == 0)
		{
			result = "R21";
		}
		else if (Operators.CompareString(left, "22.0", false) == 0)
		{
			result = "R22";
		}
		else if (Operators.CompareString(left, "23.0", false) == 0)
		{
			result = "R23";
		}
		else if (Operators.CompareString(left, "23.1", false) == 0)
		{
			result = "R23";
		}
		else
		{
			result = "";
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static string smethod_1(object object_0)
	{
		string text = Class33.Class31_0.Info.DirectoryPath;
		text = Strings.Replace(text, "\\", "\\\\", 1, -1, CompareMethod.Text);
		return string.Concat(new string[]
		{
			"(load\"",
			text,
			"\\\\lisp\\\\",
			object_0,
			"\")\r"
		});
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static string smethod_2(object object_0)
	{
		string text = Class33.Class31_0.Info.DirectoryPath;
		text = Strings.Replace(text, "\\", "\\\\", 1, -1, CompareMethod.Text);
		return string.Concat(new string[]
		{
			"(command \"arx\" \"L\" \"",
			text,
			"\\\\lisp\\\\",
			object_0,
			"\")\r"
		});
	}

	public static Point3d smethod_3(Point3d point3d_0, Point3d point3d_1)
	{
		Point3d result = point3d_0;
		Point3d point3d;
		point3d..ctor(point3d_0.X, point3d_1.Y, 0.0);
		Point3d point3d2;
		point3d2..ctor(point3d_1.X, point3d_0.Y, 0.0);
		if (result.X >= point3d_1.X & result.Y >= point3d_1.Y)
		{
			result = point3d_1;
		}
		if (result.X >= point3d.X & result.Y >= point3d.Y)
		{
			result = point3d;
		}
		if (result.X >= point3d2.X & result.Y >= point3d2.Y)
		{
			result = point3d2;
		}
		return result;
	}

	public static Point3d smethod_4(Point3d point3d_0, Point3d point3d_1)
	{
		Point3d result = point3d_0;
		Point3d point3d;
		point3d..ctor(point3d_0.X, point3d_1.Y, 0.0);
		Point3d point3d2;
		point3d2..ctor(point3d_1.X, point3d_0.Y, 0.0);
		if (result.X <= point3d_1.X & result.Y <= point3d_1.Y)
		{
			result = point3d_1;
		}
		if (result.X <= point3d.X & result.Y <= point3d.Y)
		{
			result = point3d;
		}
		if (result.X <= point3d2.X & result.Y <= point3d2.Y)
		{
			result = point3d2;
		}
		return result;
	}

	public static string smethod_5()
	{
		string text = Conversions.ToString(NewLateBinding.LateGet(Application.AcadApplication, null, "FullName", new object[0], null, null, null));
		text = Strings.Replace(text, "\\", "/", 1, -1, CompareMethod.Binary);
		checked
		{
			short num = (short)Strings.InStrRev(text, "/", -1, CompareMethod.Binary);
			return Strings.Left(text, (int)(num - 1));
		}
	}

	public static ObjectIdCollection smethod_6(Point3d point3d_0, string string_0, double double_1, string string_1 = "")
	{
		ObjectIdCollection objectIdCollection = new ObjectIdCollection();
		double_1 /= 100.0;
		Point3d[] array = new Point3d[]
		{
			CAD.GetPointXY(point3d_0, (double)(checked((0 - string_0.Length) * 200)) * double_1, 0.0),
			CAD.GetPointXY(point3d_0, (double)(checked(string_0.Length * 200)) * double_1, 0.0)
		};
		objectIdCollection.Add(CAD.AddPline(array, 75.0 * double_1, false, "").ObjectId);
		objectIdCollection.Add(CAD.AddLine(CAD.GetPointAngle(array[0], 125.0 * double_1, -90.0), CAD.GetPointAngle(array[1], 125.0 * double_1, -90.0), "0").ObjectId);
		objectIdCollection.Add(Class36.smethod_57(string_0, CAD.GetPointXY(point3d_0, 0.0, 150.0 * double_1), 500.0 * double_1, 1, 0, "黑体", 0.0));
		if (Operators.CompareString(string_1, "", false) != 0)
		{
			objectIdCollection.Add(Class36.smethod_57(string_1, CAD.GetPointAngle(array[1], 100.0 * double_1, 0.0), 300.0 * double_1, 0, 0, "黑体", 0.0));
		}
		CAD.ChangeLayer(objectIdCollection, "图名");
		return objectIdCollection;
	}

	public static Polyline smethod_7(Point3d point3d_0, Point3d point3d_1)
	{
		if (point3d_0.X > point3d_1.X)
		{
			Point3d point3d = point3d_0;
			point3d_0 = point3d_1;
			point3d_1 = point3d;
		}
		else if (point3d_0.X == point3d_1.X & point3d_0.Y > point3d_1.Y)
		{
			Point3d point3d2 = point3d_0;
			point3d_0 = point3d_1;
			point3d_1 = point3d2;
		}
		double num = CAD.P2P_Angle(point3d_0, point3d_1);
		Point3d pointAngle = CAD.GetPointAngle(point3d_0, 106.0, num * 180.0 / 3.1415926535897931 + 90.0);
		Point3d pointAngle2 = CAD.GetPointAngle(point3d_1, 106.0, num * 180.0 / 3.1415926535897931 + 90.0);
		Point3d pointAngle3 = CAD.GetPointAngle(point3d_0, 106.0, num * 180.0 / 3.1415926535897931 - 135.0);
		Point3d pointAngle4 = CAD.GetPointAngle(point3d_1, 106.0, num * 180.0 / 3.1415926535897931 - 45.0);
		Point3d pointAngle5 = CAD.GetPointAngle(point3d_0, 264.0, num * 180.0 / 3.1415926535897931 - 50.0);
		Point3d pointAngle6 = CAD.GetPointAngle(point3d_1, 264.0, num * 180.0 / 3.1415926535897931 - 130.0);
		Polyline polyline = new Polyline();
		polyline.SetDatabaseDefaults();
		double num2 = Math.Tan(Math.Atan(1.0) * 4.0 * 13.5 / 18.0 / 4.0);
		Polyline polyline2 = polyline;
		int num3 = 0;
		Point2d point2d;
		point2d..ctor(pointAngle5.get_Coordinate(0), pointAngle5.get_Coordinate(1));
		polyline2.AddVertexAt(num3, point2d, 0.0, 50.0, 50.0);
		Polyline polyline3 = polyline;
		int num4 = 1;
		point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
		polyline3.AddVertexAt(num4, point2d, -num2, 50.0, 50.0);
		Polyline polyline4 = polyline;
		int num5 = 2;
		point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
		polyline4.AddVertexAt(num5, point2d, 0.0, 50.0, 50.0);
		Polyline polyline5 = polyline;
		int num6 = 3;
		point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
		polyline5.AddVertexAt(num6, point2d, -num2, 50.0, 50.0);
		Polyline polyline6 = polyline;
		int num7 = 4;
		point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
		polyline6.AddVertexAt(num7, point2d, 0.0, 50.0, 50.0);
		Polyline polyline7 = polyline;
		int num8 = 5;
		point2d..ctor(pointAngle6.get_Coordinate(0), pointAngle6.get_Coordinate(1));
		polyline7.AddVertexAt(num8, point2d, 0.0, 50.0, 50.0);
		CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
		polyline.Layer = "钢筋";
		CAD.AddEnt(polyline);
		return polyline;
	}

	public static Polyline smethod_8(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		int num = checked((int)Math.Round(unchecked(9.0 * double_1)));
		if (point3d_0.X > point3d_1.X)
		{
			Point3d point3d = point3d_0;
			point3d_0 = point3d_1;
			point3d_1 = point3d;
		}
		else if (point3d_0.X == point3d_1.X & point3d_0.Y > point3d_1.Y)
		{
			Point3d point3d2 = point3d_0;
			point3d_0 = point3d_1;
			point3d_1 = point3d2;
		}
		double num2 = CAD.P2P_Angle(point3d_0, point3d_1);
		Point3d pointAngle = CAD.GetPointAngle(point3d_0, 20.0 * double_1, num2 * 180.0 / 3.1415926535897931 + 90.0);
		Point3d pointAngle2 = CAD.GetPointAngle(point3d_1, 20.0 * double_1, num2 * 180.0 / 3.1415926535897931 + 90.0);
		Point3d pointAngle3 = CAD.GetPointAngle(point3d_0, 20.0 * double_1, num2 * 180.0 / 3.1415926535897931 - 135.0);
		Point3d pointAngle4 = CAD.GetPointAngle(point3d_1, 20.0 * double_1, num2 * 180.0 / 3.1415926535897931 - 45.0);
		Point3d pointAngle5 = CAD.GetPointAngle(point3d_0, 46.0 * double_1, num2 * 180.0 / 3.1415926535897931 + 290.0);
		Point3d pointAngle6 = CAD.GetPointAngle(point3d_1, 46.0 * double_1, num2 * 180.0 / 3.1415926535897931 - 110.0);
		Polyline polyline = new Polyline();
		polyline.SetDatabaseDefaults();
		double num3 = Math.Tan(Math.Atan(1.0) * 4.0 * 13.5 / 18.0 / 4.0);
		Polyline polyline2 = polyline;
		int num4 = 0;
		Point2d point2d;
		point2d..ctor(pointAngle5.get_Coordinate(0), pointAngle5.get_Coordinate(1));
		polyline2.AddVertexAt(num4, point2d, 0.0, (double)num, (double)num);
		Polyline polyline3 = polyline;
		int num5 = 1;
		point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
		polyline3.AddVertexAt(num5, point2d, -num3, (double)num, (double)num);
		Polyline polyline4 = polyline;
		int num6 = 2;
		point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
		polyline4.AddVertexAt(num6, point2d, 0.0, (double)num, (double)num);
		Polyline polyline5 = polyline;
		int num7 = 3;
		point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
		polyline5.AddVertexAt(num7, point2d, -num3, (double)num, (double)num);
		Polyline polyline6 = polyline;
		int num8 = 4;
		point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
		polyline6.AddVertexAt(num8, point2d, 0.0, (double)num, (double)num);
		Polyline polyline7 = polyline;
		int num9 = 5;
		point2d..ctor(pointAngle6.get_Coordinate(0), pointAngle6.get_Coordinate(1));
		polyline7.AddVertexAt(num9, point2d, 0.0, (double)num, (double)num);
		CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
		polyline.Layer = "钢筋";
		CAD.AddEnt(polyline);
		return polyline;
	}

	public static object smethod_9(Point3d point3d_0, Point3d point3d_1)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			point3d_0 = point3d2;
			point3d_1 = point3d;
			Point3d pointAngle = CAD.GetPointAngle(point3d_0, 120.0, 270.0);
			Point3d pointAngle2 = CAD.GetPointAngle(pointAngle, 250.0, 225.0);
			Point3d point3d3;
			point3d3..ctor(point3d_1.get_Coordinate(0), point3d_0.get_Coordinate(1), 0.0);
			Point3d point3d4;
			point3d4..ctor(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(1), 0.0);
			Point3d pointAngle3 = CAD.GetPointAngle(point3d_0, 120.0, 180.0);
			Point3d pointAngle4 = CAD.GetPointAngle(pointAngle3, 250.0, 225.0);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			Polyline polyline2 = polyline;
			int num = 0;
			Point2d point2d;
			point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
			polyline2.AddVertexAt(num, point2d, 0.0, 45.0, 45.0);
			Polyline polyline3 = polyline;
			int num2 = 1;
			point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
			polyline3.AddVertexAt(num2, point2d, 0.0, 45.0, 45.0);
			Polyline polyline4 = polyline;
			int num3 = 2;
			point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
			polyline4.AddVertexAt(num3, point2d, 0.0, 45.0, 45.0);
			Polyline polyline5 = polyline;
			int num4 = 3;
			point2d..ctor(point3d3.get_Coordinate(0), point3d3.get_Coordinate(1));
			polyline5.AddVertexAt(num4, point2d, 0.0, 45.0, 45.0);
			Polyline polyline6 = polyline;
			int num5 = 4;
			point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
			polyline6.AddVertexAt(num5, point2d, 0.0, 45.0, 45.0);
			Polyline polyline7 = polyline;
			int num6 = 5;
			point2d..ctor(point3d4.get_Coordinate(0), point3d4.get_Coordinate(1));
			polyline7.AddVertexAt(num6, point2d, 0.0, 45.0, 45.0);
			Polyline polyline8 = polyline;
			int num7 = 6;
			point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
			polyline8.AddVertexAt(num7, point2d, 0.0, 45.0, 45.0);
			Polyline polyline9 = polyline;
			int num8 = 7;
			point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
			polyline9.AddVertexAt(num8, point2d, 0.0, 45.0, 45.0);
			Polyline polyline10 = polyline;
			int num9 = 8;
			point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
			polyline10.AddVertexAt(num9, point2d, 0.0, 45.0, 45.0);
			CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
			polyline.Layer = "钢筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
		}
		return 1;
	}

	public static ObjectId smethod_10(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		short num = checked((short)Math.Round(unchecked(9.0 * double_1)));
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d3;
			point3d3..ctor(point3d2.X + 20.0 * double_1, point3d2.Y + 20.0 * double_1, 0.0);
			Point3d point3d4;
			point3d4..ctor(point3d.X - 20.0 * double_1, point3d.Y - 20.0 * double_1, 0.0);
			Point3d point3d5;
			point3d5..ctor(point3d4.X, point3d3.Y, 0.0);
			Point3d point3d6;
			point3d6..ctor(point3d3.X, point3d4.Y, 0.0);
			Point2d[] array = new Point2d[15];
			array[1]..ctor(point3d2.X - 14.2 * double_1, point3d2.Y - 14.2 * double_1 * 2.0 - 15.0 * double_1);
			array[2]..ctor(point3d2.X + 14.2 * double_1, point3d2.Y - 14.2 * double_1);
			array[3]..ctor(point3d3.X, point3d3.Y - 20.0 * double_1);
			array[4]..ctor(point3d3.X - 20.0 * double_1, point3d3.Y);
			array[5]..ctor(point3d5.X + 20.0 * double_1, point3d5.Y);
			array[6]..ctor(point3d5.X, point3d5.Y - 20.0 * double_1);
			array[7]..ctor(point3d4.X, point3d4.Y + 20.0 * double_1);
			array[8]..ctor(point3d4.X + 20.0 * double_1, point3d4.Y);
			array[9]..ctor(point3d6.X - 20.0 * double_1, point3d6.Y);
			array[10]..ctor(point3d6.X, point3d6.Y + 20.0 * double_1);
			array[11] = array[3];
			array[12] = array[4];
			array[13]..ctor(point3d2.X - 14.2 * double_1, point3d2.Y + 14.2 * double_1);
			array[14]..ctor(point3d2.X - 14.2 * double_1 * 2.0 - 15.0 * double_1, point3d2.Y - 15.0 * double_1);
			double num2 = Math.Tan(0.39269908169872414);
			double num3 = Math.Tan(0.19634954084936207);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			polyline.AddVertexAt(0, array[1], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(1, array[2], num3, (double)num, (double)num);
			polyline.AddVertexAt(2, array[3], num2, (double)num, (double)num);
			polyline.AddVertexAt(3, array[4], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(4, array[5], num2, (double)num, (double)num);
			polyline.AddVertexAt(5, array[6], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(6, array[7], num2, (double)num, (double)num);
			polyline.AddVertexAt(7, array[8], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(8, array[9], num2, (double)num, (double)num);
			polyline.AddVertexAt(9, array[10], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(10, array[11], num2, (double)num, (double)num);
			polyline.AddVertexAt(11, array[12], num3, (double)num, (double)num);
			polyline.AddVertexAt(12, array[13], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(13, array[14], 0.0, (double)num, (double)num);
			CAD.CreateLayer("钢筋", 10, "continuous", -1, false, true);
			polyline.Layer = "钢筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_11(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		short num = checked((short)Math.Round(unchecked(25.0 * double_1)));
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d3;
			point3d3..ctor(point3d2.X + 40.0 * double_1, point3d2.Y + 40.0 * double_1, 0.0);
			Point3d point3d4;
			point3d4..ctor(point3d.X - 40.0 * double_1, point3d.Y - 40.0 * double_1, 0.0);
			Point3d point3d5;
			point3d5..ctor(point3d4.X, point3d3.Y, 0.0);
			Point3d point3d6;
			point3d6..ctor(point3d3.X, point3d4.Y, 0.0);
			Point2d[] array = new Point2d[15];
			array[1]..ctor(point3d2.X - 78.0 * double_1, point3d2.Y - 134.0 * double_1);
			array[2]..ctor(point3d2.X + 28.0 * double_1, point3d2.Y - 28.0 * double_1);
			array[3]..ctor(point3d2.X, point3d2.Y + 40.0 * double_1);
			array[4]..ctor(point3d5.X + 40.0 * double_1, point3d5.Y);
			array[5]..ctor(point3d5.X, point3d5.Y - 40.0 * double_1);
			array[6]..ctor(point3d4.X, point3d4.Y + 40.0 * double_1);
			array[7]..ctor(point3d4.X + 40.0 * double_1, point3d4.Y);
			array[8]..ctor(point3d6.X - 40.0 * double_1, point3d6.Y);
			array[9]..ctor(point3d6.X, point3d6.Y + 40.0 * double_1);
			array[10]..ctor(point3d3.X, point3d3.Y - 40.0 * double_1);
			array[11]..ctor(point3d2.X - 28.0 * double_1, point3d2.Y + 28.0 * double_1);
			array[12]..ctor(point3d2.X - 134.0 * double_1, point3d2.Y - 78.0 * double_1);
			double num2 = Math.Tan(0.39269908169872414);
			double num3 = Math.Tan(0.58904862254808621);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			polyline.AddVertexAt(0, array[1], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(1, array[2], num3, (double)num, (double)num);
			polyline.AddVertexAt(2, array[3], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(3, array[4], num2, (double)num, (double)num);
			polyline.AddVertexAt(4, array[5], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(5, array[6], num2, (double)num, (double)num);
			polyline.AddVertexAt(6, array[7], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(7, array[8], num2, (double)num, (double)num);
			polyline.AddVertexAt(8, array[9], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(9, array[10], num3, (double)num, (double)num);
			polyline.AddVertexAt(10, array[11], 0.0, (double)num, (double)num);
			polyline.AddVertexAt(11, array[12], 0.0, (double)num, (double)num);
			CAD.CreateLayer("柱平法箍筋", 24, "continuous", -1, false, true);
			polyline.Layer = "柱平法箍筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_12(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		int num = 50;
		double num2 = 1.0;
		if (double_1 == 5.0)
		{
			num = 50;
			num2 = 1.0;
		}
		else if (double_1 == 4.0)
		{
			num = 40;
			num2 = 0.8;
		}
		else if (double_1 == 3.333)
		{
			num = 33;
			num2 = 0.6667;
		}
		else if (double_1 == 2.5)
		{
			num = 25;
			num2 = 0.575;
		}
		else if (double_1 == 2.0)
		{
			num = 25;
			num2 = 0.575;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d p;
			p..ctor(point3d2.X, point3d2.Y, 0.0);
			Point3d p2;
			p2..ctor(point3d.X, point3d.Y, 0.0);
			Point3d p3;
			p3..ctor(p2.X, p.Y, 0.0);
			Point3d p4;
			p4..ctor(p.X, p2.Y, 0.0);
			Point3d pointAR_Radian = CAD.GetPointAR_Radian(p, -0.54175019981903982, 103.4 * num2);
			Point3d pointAR_Radian2 = CAD.GetPointAR_Radian(p, -0.24364796357840843, 103.4 * num2);
			Point3d pointAR_Radian3 = CAD.GetPointAR_Radian(pointAR_Radian, -2.3561944901923448, 250.0 * num2);
			Point3d pointXY = CAD.GetPointXY(p, 100.0 * num2, 60.0 * num2);
			Point3d pointXY2 = CAD.GetPointXY(p, 60.0 * num2, 100.0 * num2);
			Point3d pointXY3 = CAD.GetPointXY(p3, -60.0 * num2, 100.0 * num2);
			Point3d pointXY4 = CAD.GetPointXY(p3, -100.0 * num2, 60.0 * num2);
			Point3d pointXY5 = CAD.GetPointXY(p2, -100.0 * num2, -60.0 * num2);
			Point3d pointXY6 = CAD.GetPointXY(p2, -60.0 * num2, -100.0 * num2);
			Point3d pointXY7 = CAD.GetPointXY(p4, 60.0 * num2, -100.0 * num2);
			Point3d pointXY8 = CAD.GetPointXY(p4, 100.0 * num2, -60.0 * num2);
			Point3d point3d3 = pointXY;
			Point3d point3d4 = pointXY2;
			Point3d pointAR_Radian4 = CAD.GetPointAR_Radian(p, 1.8144442903733049, 103.4 * num2);
			Point3d pointAR_Radian5 = CAD.GetPointAR_Radian(p, 2.1127210595391359, 103.4 * num2);
			Point3d pointAR_Radian6 = CAD.GetPointAR_Radian(pointAR_Radian5, -2.3561944901923448, 250.0 * num2);
			double num3 = Math.Tan(0.39269908169872414);
			double num4 = Math.Tan(0.19634954084936207);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			Polyline polyline2 = polyline;
			int num5 = 0;
			Point2d point2d;
			point2d..ctor(pointAR_Radian3.X, pointAR_Radian3.Y);
			polyline2.AddVertexAt(num5, point2d, 0.0, (double)num, (double)num);
			Polyline polyline3 = polyline;
			int num6 = 1;
			point2d..ctor(pointAR_Radian.X, pointAR_Radian.Y);
			polyline3.AddVertexAt(num6, point2d, num4, (double)num, (double)num);
			Polyline polyline4 = polyline;
			int num7 = 2;
			point2d..ctor(pointAR_Radian2.X, pointAR_Radian2.Y);
			polyline4.AddVertexAt(num7, point2d, 0.0, (double)num, (double)num);
			Polyline polyline5 = polyline;
			int num8 = 3;
			point2d..ctor(pointXY.X, pointXY.Y);
			polyline5.AddVertexAt(num8, point2d, num3, (double)num, (double)num);
			Polyline polyline6 = polyline;
			int num9 = 4;
			point2d..ctor(pointXY2.X, pointXY2.Y);
			polyline6.AddVertexAt(num9, point2d, 0.0, (double)num, (double)num);
			Polyline polyline7 = polyline;
			int num10 = 5;
			point2d..ctor(pointXY3.X, pointXY3.Y);
			polyline7.AddVertexAt(num10, point2d, num3, (double)num, (double)num);
			Polyline polyline8 = polyline;
			int num11 = 6;
			point2d..ctor(pointXY4.X, pointXY4.Y);
			polyline8.AddVertexAt(num11, point2d, 0.0, (double)num, (double)num);
			Polyline polyline9 = polyline;
			int num12 = 7;
			point2d..ctor(pointXY5.X, pointXY5.Y);
			polyline9.AddVertexAt(num12, point2d, num3, (double)num, (double)num);
			Polyline polyline10 = polyline;
			int num13 = 8;
			point2d..ctor(pointXY6.X, pointXY6.Y);
			polyline10.AddVertexAt(num13, point2d, 0.0, (double)num, (double)num);
			Polyline polyline11 = polyline;
			int num14 = 9;
			point2d..ctor(pointXY7.X, pointXY7.Y);
			polyline11.AddVertexAt(num14, point2d, num3, (double)num, (double)num);
			Polyline polyline12 = polyline;
			int num15 = 10;
			point2d..ctor(pointXY8.X, pointXY8.Y);
			polyline12.AddVertexAt(num15, point2d, 0.0, (double)num, (double)num);
			Polyline polyline13 = polyline;
			int num16 = 11;
			point2d..ctor(point3d3.X, point3d3.Y);
			polyline13.AddVertexAt(num16, point2d, num3, (double)num, (double)num);
			Polyline polyline14 = polyline;
			int num17 = 12;
			point2d..ctor(point3d4.X, point3d4.Y);
			polyline14.AddVertexAt(num17, point2d, 0.0, (double)num, (double)num);
			Polyline polyline15 = polyline;
			int num18 = 13;
			point2d..ctor(pointAR_Radian4.X, pointAR_Radian4.Y);
			polyline15.AddVertexAt(num18, point2d, num4, (double)num, (double)num);
			Polyline polyline16 = polyline;
			int num19 = 14;
			point2d..ctor(pointAR_Radian5.X, pointAR_Radian5.Y);
			polyline16.AddVertexAt(num19, point2d, 0.0, (double)num, (double)num);
			Polyline polyline17 = polyline;
			int num20 = 15;
			point2d..ctor(pointAR_Radian6.X, pointAR_Radian6.Y);
			polyline17.AddVertexAt(num20, point2d, 0.0, (double)num, (double)num);
			CAD.CreateLayer("柱箍筋", 1, "continuous", -1, false, true);
			polyline.Layer = "柱箍筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_13(Point3d point3d_0, Point3d point3d_1, double double_1)
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
			double num3 = Conversion.Int(double_1 * 10.0);
			IL_1C:
			num2 = 5;
			if (num3 != 10.0)
			{
				goto IL_45;
			}
			IL_2C:
			num2 = 6;
			short num4;
			Database database;
			checked
			{
				num4 = (short)Math.Round(unchecked(35.0 * double_1));
				goto IL_E2;
				IL_45:
				num2 = 8;
				if (num3 != 12.0)
				{
					goto IL_6C;
				}
				IL_55:
				num2 = 9;
				num4 = (short)Math.Round(unchecked(30.0 * double_1));
				goto IL_E2;
				IL_6C:
				num2 = 11;
				if (num3 != 16.0)
				{
					goto IL_94;
				}
				IL_7D:
				num2 = 12;
				num4 = (short)Math.Round(unchecked(30.0 * double_1));
				goto IL_E2;
				IL_94:
				num2 = 14;
				if (num3 != 20.0)
				{
					goto IL_BC;
				}
				IL_A5:
				num2 = 15;
				num4 = (short)Math.Round(unchecked(25.0 * double_1));
				goto IL_E2;
				IL_BC:
				num2 = 17;
				if (num3 != 25.0)
				{
					goto IL_E2;
				}
				IL_CD:
				num2 = 18;
				num4 = (short)Math.Round(unchecked(25.0 * double_1));
				IL_E2:
				num2 = 20;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_F1:
				num2 = 21;
				database = mdiActiveDocument.Database;
				IL_FD:
				num2 = 22;
			}
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				double num5 = CAD.P2P_Angle(point3d_0, point3d_1);
				point3d_0 = CAD.GetPointAngle(point3d_0, 60.0 * double_1, num5 * 180.0 / 3.1415926535897931 + 90.0);
				point3d_1 = CAD.GetPointAngle(point3d_1, 60.0 * double_1, num5 * 180.0 / 3.1415926535897931 + 90.0);
				Point3d pointAngle = CAD.GetPointAngle(point3d_0, 111.0 * double_1, num5 * 180.0 / 3.1415926535897931 - 112.5);
				Point3d pointAngle2 = CAD.GetPointAngle(point3d_1, 111.0 * double_1, num5 * 180.0 / 3.1415926535897931 - 67.5);
				Point3d pointAngle3 = CAD.GetPointAngle(point3d_0, 160.0 * double_1, num5 * 180.0 / 3.1415926535897931 - 84.92);
				Point3d pointAngle4 = CAD.GetPointAngle(point3d_1, 160.0 * double_1, num5 * 180.0 / 3.1415926535897931 - 95.08);
				Polyline polyline = new Polyline();
				polyline.SetDatabaseDefaults();
				double num6 = Math.Tan(Math.Atan(1.0) * 3.0 / 4.0);
				Polyline polyline2 = polyline;
				int num7 = 0;
				Point2d point2d;
				point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
				polyline2.AddVertexAt(num7, point2d, 0.0, (double)num4, (double)num4);
				Polyline polyline3 = polyline;
				int num8 = 1;
				point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
				polyline3.AddVertexAt(num8, point2d, -num6, (double)num4, (double)num4);
				Polyline polyline4 = polyline;
				int num9 = 2;
				point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
				polyline4.AddVertexAt(num9, point2d, 0.0, (double)num4, (double)num4);
				Polyline polyline5 = polyline;
				int num10 = 3;
				point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
				polyline5.AddVertexAt(num10, point2d, -num6, (double)num4, (double)num4);
				Polyline polyline6 = polyline;
				int num11 = 4;
				point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
				polyline6.AddVertexAt(num11, point2d, 0.0, (double)num4, (double)num4);
				Polyline polyline7 = polyline;
				int num12 = 5;
				point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
				polyline7.AddVertexAt(num12, point2d, 0.0, (double)num4, (double)num4);
				CAD.CreateLayer("墙柱拉筋", 1, "continuous", -1, false, true);
				polyline.Layer = "墙柱拉筋";
				CAD.AddEnt(polyline);
				transaction.Commit();
			}
			IL_3CB:
			num2 = 24;
			if (Information.Err().Number <= 0)
			{
				goto IL_3F2;
			}
			IL_3DD:
			num2 = 25;
			Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			IL_3F2:
			goto IL_4BC;
			IL_3F7:
			int num13 = num14 + 1;
			num14 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num13);
			IL_473:
			goto IL_4B1;
			IL_475:
			num14 = num2;
			if (num <= -2)
			{
				goto IL_3F7;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_48E:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num14 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_475;
		}
		IL_4B1:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_4BC:
		ObjectId objectId;
		ObjectId result = objectId;
		if (num14 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ObjectId smethod_14(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		double num = Conversion.Int(double_1 * 10.0);
		short num2;
		Database database;
		checked
		{
			if (num == 10.0)
			{
				num2 = (short)Math.Round(unchecked(35.0 * double_1));
			}
			else if (num == 12.0)
			{
				num2 = (short)Math.Round(unchecked(30.0 * double_1));
			}
			else if (num == 16.0)
			{
				num2 = (short)Math.Round(unchecked(30.0 * double_1));
			}
			else if (num == 20.0)
			{
				num2 = (short)Math.Round(unchecked(25.0 * double_1));
			}
			else if (num == 25.0)
			{
				num2 = (short)Math.Round(unchecked(25.0 * double_1));
			}
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			database = mdiActiveDocument.Database;
		}
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d3;
			point3d3..ctor(point3d2.X + 60.0 * double_1, point3d2.Y + 60.0 * double_1, 0.0);
			Point3d point3d4;
			point3d4..ctor(point3d.X - 60.0 * double_1, point3d.Y - 60.0 * double_1, 0.0);
			Point3d point3d5;
			point3d5..ctor(point3d4.X, point3d3.Y, 0.0);
			Point3d point3d6;
			point3d6..ctor(point3d3.X, point3d4.Y, 0.0);
			Point2d[] array = new Point2d[15];
			array[1]..ctor(point3d2.X - 14.0 * double_1, point3d2.Y - 100.0 * double_1);
			array[2]..ctor(point3d2.X + 42.0 * double_1, point3d2.Y - 42.0 * double_1);
			array[3]..ctor(point3d2.X, point3d2.Y + 60.0 * double_1);
			array[4]..ctor(point3d5.X + 60.0 * double_1, point3d5.Y);
			array[5]..ctor(point3d5.X, point3d5.Y - 60.0 * double_1);
			array[6]..ctor(point3d4.X, point3d4.Y + 60.0 * double_1);
			array[7]..ctor(point3d4.X + 60.0 * double_1, point3d4.Y);
			array[8]..ctor(point3d6.X - 60.0 * double_1, point3d6.Y);
			array[9]..ctor(point3d6.X, point3d6.Y + 60.0 * double_1);
			array[10]..ctor(point3d3.X, point3d3.Y - 60.0 * double_1);
			array[11]..ctor(point3d2.X - 42.0 * double_1, point3d2.Y + 42.0 * double_1);
			array[12]..ctor(point3d2.X - 100.0 * double_1, point3d2.Y - 14.0 * double_1);
			double num3 = Math.Tan(0.39269908169872414);
			double num4 = Math.Tan(0.58904862254808621);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			polyline.AddVertexAt(0, array[1], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(1, array[2], num4, (double)num2, (double)num2);
			polyline.AddVertexAt(2, array[3], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(3, array[4], num3, (double)num2, (double)num2);
			polyline.AddVertexAt(4, array[5], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(5, array[6], num3, (double)num2, (double)num2);
			polyline.AddVertexAt(6, array[7], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(7, array[8], num3, (double)num2, (double)num2);
			polyline.AddVertexAt(8, array[9], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(9, array[10], num4, (double)num2, (double)num2);
			polyline.AddVertexAt(10, array[11], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(11, array[12], 0.0, (double)num2, (double)num2);
			CAD.CreateLayer("墙柱小箍筋", 1, "continuous", -1, false, true);
			polyline.Layer = "墙柱小箍筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_15(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		double num = Conversion.Int(double_1 * 10.0);
		short num2;
		short num3;
		Database database;
		checked
		{
			if (num == 10.0)
			{
				num2 = (short)Math.Round(unchecked(35.0 * double_1));
				num3 = (short)Math.Round(unchecked(35.0 * double_1));
			}
			else if (num == 12.0)
			{
				num2 = (short)Math.Round(unchecked(30.0 * double_1));
				num3 = (short)Math.Round(unchecked(30.0 * double_1));
			}
			else if (num == 16.0)
			{
				num2 = (short)Math.Round(unchecked(30.0 * double_1));
				num3 = (short)Math.Round(unchecked(30.0 * double_1));
			}
			else if (num == 20.0)
			{
				num2 = (short)Math.Round(unchecked(25.0 * double_1));
				num3 = (short)Math.Round(unchecked(25.0 * double_1));
			}
			else if (num == 25.0)
			{
				num2 = (short)Math.Round(unchecked(25.0 * double_1));
				num3 = (short)Math.Round(unchecked(25.0 * double_1));
			}
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			database = mdiActiveDocument.Database;
		}
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d p;
			p..ctor(point3d2.X - 60.0 * double_1, point3d2.Y - 60.0 * double_1, 0.0);
			Point3d p2;
			p2..ctor(point3d.X + 60.0 * double_1, point3d.Y + 60.0 * double_1, 0.0);
			Point3d p3;
			p3..ctor(p2.X, p.Y, 0.0);
			Point3d p4;
			p4..ctor(p.X, p2.Y, 0.0);
			Class36.smethod_16(CAD.GetPointXY(p, -60.0 * double_1, -60.0 * double_1), (double)num3, "墙柱纵筋");
			Class36.smethod_16(CAD.GetPointXY(p2, 60.0 * double_1, 60.0 * double_1), (double)num3, "墙柱纵筋");
			Class36.smethod_16(CAD.GetPointXY(p3, 60.0 * double_1, -60.0 * double_1), (double)num3, "墙柱纵筋");
			Class36.smethod_16(CAD.GetPointXY(p4, -60.0 * double_1, 60.0 * double_1), (double)num3, "墙柱纵筋");
			Point2d[] array = new Point2d[15];
			array[1]..ctor(p.X - 74.0 * double_1, p.Y - 160.0 * double_1);
			array[2]..ctor(p.X - 18.0 * double_1, p.Y - 102.0 * double_1);
			array[3]..ctor(p.X - 60.0 * double_1, p.Y);
			array[4]..ctor(p3.X + 60.0 * double_1, p3.Y);
			array[5]..ctor(p3.X, p3.Y - 60.0 * double_1);
			array[6]..ctor(p2.X, p2.Y + 60.0 * double_1);
			array[7]..ctor(p2.X + 60.0 * double_1, p2.Y);
			array[8]..ctor(p4.X - 60.0 * double_1, p4.Y);
			array[9]..ctor(p4.X, p4.Y + 60.0 * double_1);
			array[10]..ctor(p.X, p.Y - 60.0 * double_1);
			array[11]..ctor(p.X - 102.0 * double_1, p.Y - 18.0 * double_1);
			array[12]..ctor(p.X - 160.0 * double_1, p.Y - 74.0 * double_1);
			double num4 = Math.Tan(0.39269908169872414);
			double num5 = Math.Tan(0.58904862254808621);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			polyline.AddVertexAt(0, array[1], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(1, array[2], num5, (double)num2, (double)num2);
			polyline.AddVertexAt(2, array[3], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(3, array[4], num4, (double)num2, (double)num2);
			polyline.AddVertexAt(4, array[5], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(5, array[6], num4, (double)num2, (double)num2);
			polyline.AddVertexAt(6, array[7], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(7, array[8], num4, (double)num2, (double)num2);
			polyline.AddVertexAt(8, array[9], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(9, array[10], num5, (double)num2, (double)num2);
			polyline.AddVertexAt(10, array[11], 0.0, (double)num2, (double)num2);
			polyline.AddVertexAt(11, array[12], 0.0, (double)num2, (double)num2);
			CAD.CreateLayer("墙柱大箍筋", 1, "continuous", -1, false, true);
			polyline.Layer = "墙柱大箍筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_16(Point3d point3d_0, double double_1, string string_0 = "墙柱纵筋")
	{
		double num = Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
		Polyline polyline = new Polyline();
		Polyline polyline2 = polyline;
		int num2 = 0;
		Point2d point2d;
		point2d..ctor(point3d_0.X, point3d_0.Y + double_1 / 2.0);
		polyline2.AddVertexAt(num2, point2d, num, double_1, double_1);
		Polyline polyline3 = polyline;
		int num3 = 1;
		point2d..ctor(point3d_0.X, point3d_0.Y - double_1 / 2.0);
		polyline3.AddVertexAt(num3, point2d, num, double_1, double_1);
		Polyline polyline4 = polyline;
		int num4 = 2;
		point2d..ctor(point3d_0.X, point3d_0.Y + double_1 / 2.0);
		polyline4.AddVertexAt(num4, point2d, num, double_1, double_1);
		CAD.CreateLayer(string_0, 10, "continuous", -1, false, true);
		polyline.Layer = string_0;
		CAD.AddEnt(polyline);
		return polyline.ObjectId;
	}

	public static Polyline smethod_17(Point3d point3d_0, Point3d point3d_1)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Polyline result;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(1), 0.0);
			Point3d point3d2;
			point3d2..ctor(point3d_1.get_Coordinate(0), point3d_0.get_Coordinate(1), 0.0);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			Polyline polyline2 = polyline;
			int num = 0;
			Point2d point2d;
			point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
			polyline2.AddVertexAt(num, point2d, 0.0, 0.0, 0.0);
			Polyline polyline3 = polyline;
			int num2 = 1;
			point2d..ctor(point3d.get_Coordinate(0), point3d.get_Coordinate(1));
			polyline3.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
			Polyline polyline4 = polyline;
			int num3 = 2;
			point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
			polyline4.AddVertexAt(num3, point2d, 0.0, 0.0, 0.0);
			Polyline polyline5 = polyline;
			int num4 = 3;
			point2d..ctor(point3d2.get_Coordinate(0), point3d2.get_Coordinate(1));
			polyline5.AddVertexAt(num4, point2d, 0.0, 0.0, 0.0);
			polyline.Closed = true;
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			result = polyline;
			transaction.Commit();
		}
		return result;
	}

	public static ObjectId smethod_18(ObjectIdCollection objectIdCollection_0)
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
			BlockTableRecord blockTableRecord = new BlockTableRecord();
			IL_28:
			num2 = 5;
			string text = Strings.Replace("Tc" + DateTime.Now.ToString(), " ", "", 1, -1, CompareMethod.Binary);
			IL_56:
			num2 = 6;
			text = Strings.Replace(text, "-", "", 1, -1, CompareMethod.Binary);
			IL_6E:
			num2 = 7;
			text = Strings.Replace(text, ":", "", 1, -1, CompareMethod.Binary);
			IL_86:
			num2 = 8;
			text = Strings.Replace(text, "/", "", 1, -1, CompareMethod.Binary);
			IL_9E:
			num2 = 9;
			blockTableRecord.Name = text;
			IL_AA:
			num2 = 10;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
				Entity entity = (Entity)transaction.GetObject(objectIdCollection_0[0], 0);
				Point3d minPoint = entity.GeometricExtents.MinPoint;
				blockTableRecord.Origin = minPoint;
				IEnumerator enumerator = objectIdCollection_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					ObjectId objectId2;
					ObjectId objectId = (obj != null) ? ((ObjectId)obj) : objectId2;
					Entity entity2 = (Entity)transaction.GetObject(objectId, 1);
					Entity entity3 = (Entity)entity2.Clone();
					entity2.Erase();
					blockTableRecord.AppendEntity(entity3);
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				blockTable.Add(blockTableRecord);
				transaction.AddNewlyCreatedDBObject(blockTableRecord, true);
				BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				BlockReference blockReference = new BlockReference(minPoint, blockTableRecord.ObjectId);
				blockTableRecord2.AppendEntity(blockReference);
				transaction.AddNewlyCreatedDBObject(blockReference, true);
				transaction.Commit();
			}
			IL_1E7:
			num2 = 12;
			blockTableRecord.Dispose();
			IL_1F1:
			num2 = 13;
			if (Information.Err().Number <= 0)
			{
			}
			IL_203:
			goto IL_29A;
			IL_208:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_254:
			goto IL_28F;
			IL_256:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_208;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_26C:;
		}
		catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_256;
		}
		IL_28F:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_29A:
		ObjectId objectId3;
		ObjectId result = objectId3;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ObjectId smethod_19(ObjectIdCollection objectIdCollection_0)
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
			BlockTableRecord blockTableRecord = new BlockTableRecord();
			IL_28:
			num2 = 5;
			blockTableRecord.Name = "*T";
			IL_36:
			num2 = 6;
			blockTableRecord.Explodable = false;
			IL_40:
			num2 = 7;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
				Entity entity = (Entity)transaction.GetObject(objectIdCollection_0[0], 0);
				Point3d minPoint = entity.GeometricExtents.MinPoint;
				blockTableRecord.Origin = minPoint;
				IEnumerator enumerator = objectIdCollection_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					ObjectId objectId2;
					ObjectId objectId = (obj != null) ? ((ObjectId)obj) : objectId2;
					Entity entity2 = (Entity)transaction.GetObject(objectId, 1);
					Entity entity3 = (Entity)entity2.Clone();
					entity2.Erase();
					blockTableRecord.AppendEntity(entity3);
				}
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				blockTable.Add(blockTableRecord);
				transaction.AddNewlyCreatedDBObject(blockTableRecord, true);
				BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				BlockReference blockReference = new BlockReference(minPoint, blockTableRecord.ObjectId);
				blockReference.Layer = entity.Layer;
				blockTableRecord2.AppendEntity(blockReference);
				transaction.AddNewlyCreatedDBObject(blockReference, true);
				transaction.Commit();
			}
			IL_18A:
			num2 = 9;
			blockTableRecord.Dispose();
			IL_194:
			num2 = 10;
			if (Information.Err().Number <= 0)
			{
			}
			IL_1A6:
			goto IL_231;
			IL_1AB:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_1EB:
			goto IL_226;
			IL_1ED:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_1AB;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_203:;
		}
		catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_1ED;
		}
		IL_226:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_231:
		ObjectId objectId3;
		ObjectId result = objectId3;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ObjectId[] smethod_20(Point3d point3d_0, Array array_0, double double_1, double double_2, string string_0 = "")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId[] allEntityIds;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
			Point3d position = point3d_0;
			Group group = new Group("*", true);
			dbdictionary.SetAt("*", group);
			short num = 0;
			short num2 = checked((short)Information.UBound(array_0, 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				DBText dbtext = new DBText();
				if (Operators.CompareString(array_0[(int)num3], "", false) == 0 | Operators.CompareString(array_0[(int)num3], " ", false) == 0)
				{
					array_0[(int)num3] = "---";
				}
				dbtext.TextString = array_0[(int)num3];
				dbtext.Height = double_1;
				dbtext.WidthFactor = 0.7;
				dbtext.SetDatabaseDefaults();
				if (Operators.CompareString(string_0, "", false) != 0)
				{
					dbtext.Layer = string_0;
				}
				position..ctor(position.X, position.Y - double_2 * double_1, 0.0);
				dbtext.Position = position;
				blockTableRecord.AppendEntity(dbtext);
				transaction.AddNewlyCreatedDBObject(dbtext, true);
				group.Append(dbtext.ObjectId);
				num3 += 1;
			}
			transaction.AddNewlyCreatedDBObject(group, true);
			transaction.Commit();
			allEntityIds = group.GetAllEntityIds();
		}
		return allEntityIds;
	}

	public static ObjectId[] smethod_21(Point3d point3d_0, Array array_0, double double_1, double double_2)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId[] allEntityIds;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
			Point3d alignmentPoint = point3d_0;
			Group group = new Group("*", true);
			dbdictionary.SetAt("*", group);
			short num = 0;
			short num2 = checked((short)Information.UBound(array_0, 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				DBText dbtext = new DBText();
				if (Operators.CompareString(array_0[(int)num3], "", false) == 0 | Operators.CompareString(array_0[(int)num3], " ", false) == 0)
				{
					array_0[(int)num3] = "---";
				}
				dbtext.TextString = array_0[(int)num3];
				dbtext.Height = double_1;
				dbtext.WidthFactor = 0.7;
				dbtext.SetDatabaseDefaults();
				alignmentPoint..ctor(alignmentPoint.X, alignmentPoint.Y - double_2 * double_1, 0.0);
				dbtext.HorizontalMode = 2;
				dbtext.AlignmentPoint = alignmentPoint;
				blockTableRecord.AppendEntity(dbtext);
				transaction.AddNewlyCreatedDBObject(dbtext, true);
				group.Append(dbtext.ObjectId);
				num3 += 1;
			}
			transaction.AddNewlyCreatedDBObject(group, true);
			transaction.Commit();
			allEntityIds = group.GetAllEntityIds();
		}
		return allEntityIds;
	}

	public static ObjectId[] smethod_22(Point3d point3d_0, Array array_0, double double_1, double double_2, long long_0, bool bool_0, string string_0 = "")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId[] allEntityIds;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
			Point3d position = point3d_0;
			Group group = new Group("*", true);
			dbdictionary.SetAt("*", group);
			Point3d point3d;
			point3d..ctor(position.X - double_1, position.Y - double_1 * (double_2 - 1.0) / 2.0, position.Z);
			Point3d p = point3d;
			Point3d point3d2;
			point3d2..ctor(position.X - double_1 + (double)long_0, position.Y - double_1 * (double_2 - 1.0) / 2.0, position.Z);
			CAD.AddLine(p, point3d2, "0");
			short num = 0;
			short num2 = checked((short)Information.UBound(array_0, 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				DBText dbtext = new DBText();
				position..ctor(position.X, position.Y - double_2 * double_1, 0.0);
				if (!(Operators.CompareString(array_0[(int)num3], "", false) == 0 | Operators.CompareString(array_0[(int)num3], " ", false) == 0))
				{
					dbtext.TextString = array_0[(int)num3];
					dbtext.Height = double_1;
					dbtext.WidthFactor = 0.7;
					dbtext.SetDatabaseDefaults();
					if (Operators.CompareString(string_0, "", false) != 0)
					{
						dbtext.Layer = string_0;
					}
					dbtext.Position = position;
					blockTableRecord.AppendEntity(dbtext);
					transaction.AddNewlyCreatedDBObject(dbtext, true);
					group.Append(dbtext.ObjectId);
				}
				point3d2..ctor(position.X - double_1, position.Y - double_1 * (double_2 - 1.0) / 2.0, position.Z);
				Point3d p2 = point3d2;
				point3d..ctor(position.X - double_1 + (double)long_0, position.Y - double_1 * (double_2 - 1.0) / 2.0, position.Z);
				CAD.AddLine(p2, point3d, "0");
				point3d2..ctor(position.X - double_1, position.Y - double_1 * (double_2 - 1.0) / 2.0, position.Z);
				Point3d p3 = point3d2;
				point3d..ctor(position.X - double_1, position.Y - double_1 * (double_2 - 1.0) / 2.0 + double_2 * double_1, position.Z);
				CAD.AddLine(p3, point3d, "0");
				if (bool_0)
				{
					point3d2..ctor(position.X - double_1 + (double)long_0, position.Y - double_1 * (double_2 - 1.0) / 2.0, position.Z);
					Point3d p4 = point3d2;
					point3d..ctor(position.X - double_1 + (double)long_0, position.Y - double_1 * (double_2 - 1.0) / 2.0 + double_2 * double_1, position.Z);
					CAD.AddLine(p4, point3d, "0");
				}
				num3 += 1;
			}
			transaction.AddNewlyCreatedDBObject(group, true);
			transaction.Commit();
			allEntityIds = group.GetAllEntityIds();
		}
		return allEntityIds;
	}

	public static ObjectId smethod_23(Point3d point3d_0, string string_0, double double_1, int int_2 = 0, string string_1 = "")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
			DBText dbtext = new DBText();
			if (Operators.CompareString(string_1, "", false) != 0)
			{
				dbtext.Layer = string_1;
			}
			dbtext.TextString = string_0;
			dbtext.Height = double_1;
			dbtext.WidthFactor = 0.7;
			dbtext.Rotation = (double)int_2;
			dbtext.SetDatabaseDefaults();
			dbtext.Position = point3d_0;
			blockTableRecord.AppendEntity(dbtext);
			transaction.AddNewlyCreatedDBObject(dbtext, true);
			transaction.Commit();
			objectId = dbtext.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_24(Point3d point3d_0, string string_0, double double_1, int int_2 = 0, string string_1 = "")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
			DBText dbtext = new DBText();
			if (Operators.CompareString(string_1, "", false) != 0)
			{
				dbtext.Layer = string_1;
			}
			dbtext.TextString = string_0;
			dbtext.Height = double_1;
			dbtext.HorizontalMode = 1;
			dbtext.WidthFactor = 0.7;
			dbtext.Rotation = (double)int_2;
			dbtext.SetDatabaseDefaults();
			dbtext.AlignmentPoint = point3d_0;
			blockTableRecord.AppendEntity(dbtext);
			transaction.AddNewlyCreatedDBObject(dbtext, true);
			transaction.Commit();
			objectId = dbtext.ObjectId;
		}
		return objectId;
	}

	public static short smethod_25(Point3d point3d_0, long long_0, double double_1, double double_2, string string_0)
	{
		Point3d point3d = point3d_0;
		Point3d point3d2 = default(Point3d);
		Line e = new Line();
		short num2;
		short num3;
		checked
		{
			long_0 += 1L;
			short num = 0;
			num2 = (short)long_0;
			num3 = num;
		}
		for (;;)
		{
			short num4 = num3;
			short num5 = num2;
			if (num4 > num5)
			{
				break;
			}
			point3d..ctor(point3d_0.X, point3d_0.Y - (double)num3 * double_1, 0.0);
			point3d2..ctor(point3d_0.X + double_2, point3d_0.Y - (double)num3 * double_1, 0.0);
			e = new Line(point3d, point3d2);
			CAD.AddEnt(e);
			num3 += 1;
		}
		if (Operators.CompareString(string_0, "Left", false) == 0)
		{
			point3d = point3d_0;
			point3d2..ctor(point3d_0.X, point3d_0.Y - (double)long_0 * double_1, 0.0);
			e = new Line(point3d, point3d2);
			CAD.AddEnt(e);
		}
		else
		{
			point3d..ctor(point3d_0.X, point3d_0.Y, 0.0);
			point3d2..ctor(point3d_0.X, point3d_0.Y - (double)long_0 * double_1, 0.0);
			e = new Line(point3d, point3d2);
			CAD.AddEnt(e);
			point3d..ctor(point3d_0.X + double_2, point3d_0.Y, 0.0);
			point3d2..ctor(point3d_0.X + double_2, point3d_0.Y - (double)long_0 * double_1, 0.0);
			e = new Line(point3d, point3d2);
			CAD.AddEnt(e);
		}
		short result;
		return result;
	}

	public static double smethod_26(Point3d point3d_0, Point3d point3d_1)
	{
		double num = point3d_0.X - point3d_1.X;
		double num2 = point3d_0.Y - point3d_1.Y;
		double num3 = Math.Atan(1.0);
		double result;
		if (num == 0.0)
		{
			if (num2 > 0.0)
			{
				result = num3 * 2.0;
			}
			else
			{
				result = num3 * 6.0;
			}
		}
		else if (num < 0.0)
		{
			if (num2 <= 0.0)
			{
				result = Math.Atan(num2 / num);
			}
			else
			{
				result = num3 * 8.0 - Math.Atan(-num2 / num);
			}
		}
		else if (num > 0.0)
		{
			result = Math.Atan(num2 / num) + num3 * 4.0;
		}
		return result;
	}

	public static double smethod_27(Vector3d vector3d_0)
	{
		double x = vector3d_0.X;
		double y = vector3d_0.Y;
		double num = 3.1415926535897931;
		double result;
		if (x == 0.0)
		{
			if (y > 0.0)
			{
				result = num / 2.0;
			}
			else
			{
				result = num * 3.0 / 2.0;
			}
		}
		else if (x > 0.0)
		{
			if (y >= 0.0)
			{
				result = Math.Atan(y / x);
			}
			else
			{
				result = num * 2.0 - Math.Atan(-y / x);
			}
		}
		else if (x < 0.0)
		{
			result = Math.Atan(y / x) + num;
		}
		return result;
	}

	public static double smethod_28(Point3d point3d_0, Point3d point3d_1)
	{
		Vector3d vectorTo = point3d_1.GetVectorTo(point3d_0);
		double x = vectorTo.X;
		double y = vectorTo.Y;
		double num = 3.1415926535897931;
		double result;
		if (x == 0.0)
		{
			if (y > 0.0)
			{
				result = num / 2.0;
			}
			else
			{
				result = num * 3.0 / 2.0;
			}
		}
		else if (x > 0.0)
		{
			if (y >= 0.0)
			{
				result = Math.Atan(y / x);
			}
			else
			{
				result = num * 2.0 - Math.Atan(-y / x);
			}
		}
		else if (x < 0.0)
		{
			result = Math.Atan(y / x) + num;
		}
		return result;
	}

	public static short smethod_29(Point3d point3d_0, ref Point3d point3d_1, string string_0 = "选择下一点: ")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		PromptPointOptions promptPointOptions = new PromptPointOptions("");
		promptPointOptions.Message = "\n" + string_0;
		promptPointOptions.UseBasePoint = true;
		promptPointOptions.BasePoint = point3d_0;
		promptPointOptions.AllowNone = true;
		PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
		short result;
		if (point.Status == -5002 || point.Status == -5001)
		{
			result = -1;
		}
		else if (point.Status == 5000)
		{
			result = 0;
		}
		else
		{
			point3d_1 = point.Value;
			result = 1;
		}
		return result;
	}

	public static double smethod_30(string string_0 = "指定长度: ", double double_1 = 240.0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		PromptDistanceOptions promptDistanceOptions = new PromptDistanceOptions("\n" + string_0);
		promptDistanceOptions.UseDefaultValue = true;
		promptDistanceOptions.DefaultValue = double_1;
		PromptDoubleResult distance = mdiActiveDocument.Editor.GetDistance(promptDistanceOptions);
		double result;
		if (distance.Status == 5100)
		{
			result = distance.Value;
		}
		else
		{
			result = double_1;
		}
		return result;
	}

	public static bool smethod_31(ref Point3d point3d_0, ref Point3d point3d_1, string string_0 = "选择插入点:")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		PromptPointOptions promptPointOptions = new PromptPointOptions("");
		promptPointOptions.AllowNone = true;
		promptPointOptions.Message = "\n" + string_0;
		PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
		bool result;
		if (point.Status != 5100)
		{
			result = false;
		}
		else
		{
			point3d_0 = point.Value;
			promptPointOptions.Message = "\n" + string_0;
			promptPointOptions.UseBasePoint = true;
			promptPointOptions.BasePoint = point3d_0;
			point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
			if (point.Status != 5100)
			{
				result = false;
			}
			else
			{
				point3d_1 = point.Value;
				if (point3d_0.X > point3d_1.X)
				{
					Point3d point3d = point3d_0;
					point3d_0 = point3d_1;
					point3d_1 = point3d;
				}
				else if (point3d_0.X == point3d_1.X && point3d_0.Y > point3d_1.Y)
				{
					Point3d point3d2 = point3d_0;
					point3d_0 = point3d_1;
					point3d_1 = point3d2;
				}
				result = true;
			}
		}
		return result;
	}

	public static short smethod_32(ref Point3d point3d_0, ref Point3d point3d_1, string string_0 = "选择插入点:")
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		PromptPointOptions promptPointOptions = new PromptPointOptions("");
		promptPointOptions.Message = "\n" + string_0;
		PromptPointResult point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
		short result;
		if (point.Status != 5100)
		{
			result = 0;
		}
		else
		{
			point3d_0 = point.Value;
			promptPointOptions.Message = "\n" + string_0;
			promptPointOptions.UseBasePoint = true;
			promptPointOptions.BasePoint = point3d_0;
			point = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
			if (point.Status != 5100)
			{
				result = 0;
			}
			else
			{
				point3d_1 = point.Value;
				result = 1;
			}
		}
		return result;
	}

	public static bool smethod_33(ref Point3d point3d_0, ref Point3d point3d_1)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		PromptPointOptions promptPointOptions = new PromptPointOptions("");
		promptPointOptions.AllowNone = true;
		promptPointOptions.Message = "\n请选择其中一个角点: ";
		PromptPointResult promptPointResult = mdiActiveDocument.Editor.GetPoint(promptPointOptions);
		bool result;
		if (promptPointResult.Status != 5100)
		{
			result = false;
		}
		else
		{
			point3d_0 = promptPointResult.Value;
			PromptCornerOptions promptCornerOptions = new PromptCornerOptions("\n请选择一个对角点:", point3d_0);
			promptPointResult = mdiActiveDocument.Editor.GetCorner(promptCornerOptions);
			if (promptPointResult.Status != 5100)
			{
				result = false;
			}
			else
			{
				point3d_1 = promptPointResult.Value;
				result = true;
			}
		}
		return result;
	}

	public static double smethod_34(ref Point3d point3d_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		PromptAngleOptions promptAngleOptions = new PromptAngleOptions("");
		promptAngleOptions.Message = "\n选择角度: ";
		promptAngleOptions.BasePoint = point3d_0;
		promptAngleOptions.UseBasePoint = true;
		PromptDoubleResult angle = mdiActiveDocument.Editor.GetAngle(promptAngleOptions);
		double value;
		if (angle.Status == 5100)
		{
			value = angle.Value;
		}
		return value;
	}

	public static ObjectId smethod_35(Point3d point3d_0, Point3d point3d_1, short short_0)
	{
		double num = (double)short_0 / 100.0;
		double num2 = point3d_0.GetVectorTo(point3d_1).AngleOnPlane(new Plane());
		Point3d pointAngle = CAD.GetPointAngle(point3d_0, 100.0 * num, num2 * 180.0 / 3.1415926535897931 + 90.0);
		Point3d pointAngle2 = CAD.GetPointAngle(point3d_1, 100.0 * num, num2 * 180.0 / 3.1415926535897931 + 90.0);
		Point3d pointAngle3 = CAD.GetPointAngle(point3d_0, 141.0 * num, num2 * 180.0 / 3.1415926535897931 + 45.0);
		Point3d pointAngle4 = CAD.GetPointAngle(point3d_1, 141.0 * num, num2 * 180.0 / 3.1415926535897931 - 225.0);
		Polyline polyline = new Polyline();
		polyline.SetDatabaseDefaults();
		short num3 = checked((short)Math.Round(Conversion.Int(unchecked(45.0 * num))));
		double num4 = Math.Tan(Math.Atan(1.0) * 4.0 / 4.0);
		Polyline polyline2 = polyline;
		int num5 = 0;
		Point2d point2d;
		point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
		polyline2.AddVertexAt(num5, point2d, 0.0, (double)num3, (double)num3);
		Polyline polyline3 = polyline;
		int num6 = 1;
		point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
		polyline3.AddVertexAt(num6, point2d, num4, (double)num3, (double)num3);
		Polyline polyline4 = polyline;
		int num7 = 2;
		point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
		polyline4.AddVertexAt(num7, point2d, 0.0, (double)num3, (double)num3);
		Polyline polyline5 = polyline;
		int num8 = 3;
		point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
		polyline5.AddVertexAt(num8, point2d, num4, (double)num3, (double)num3);
		Polyline polyline6 = polyline;
		int num9 = 4;
		point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
		polyline6.AddVertexAt(num9, point2d, 0.0, (double)num3, (double)num3);
		Polyline polyline7 = polyline;
		int num10 = 5;
		point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
		polyline7.AddVertexAt(num10, point2d, 0.0, (double)num3, (double)num3);
		CAD.CreateLayer("楼梯钢筋", 1, "continuous", -1, false, true);
		polyline.Layer = "楼梯钢筋";
		CAD.AddEnt(polyline);
		return polyline.ObjectId;
	}

	public static ObjectId smethod_36(Point3d point3d_0, Point3d point3d_1, short short_0)
	{
		double num = (double)short_0 / 100.0;
		double num2 = CAD.P2P_Angle(point3d_0, point3d_1);
		Point3d pointAngle = CAD.GetPointAngle(point3d_0, 200.0 * num, num2 * 180.0 / 3.1415926535897931 + 45.0);
		Point3d pointAngle2 = CAD.GetPointAngle(point3d_1, 200.0 * num, num2 * 180.0 / 3.1415926535897931 + 135.0);
		Polyline polyline = new Polyline();
		polyline.SetDatabaseDefaults();
		Polyline polyline2 = polyline;
		int num3 = 0;
		Point2d point2d;
		point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
		polyline2.AddVertexAt(num3, point2d, 0.0, 45.0 * num, 45.0 * num);
		Polyline polyline3 = polyline;
		int num4 = 1;
		point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
		polyline3.AddVertexAt(num4, point2d, 0.0, 45.0 * num, 45.0 * num);
		Polyline polyline4 = polyline;
		int num5 = 2;
		point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
		polyline4.AddVertexAt(num5, point2d, 0.0, 45.0 * num, 45.0 * num);
		Polyline polyline5 = polyline;
		int num6 = 3;
		point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
		polyline5.AddVertexAt(num6, point2d, 0.0, 45.0 * num, 45.0 * num);
		CAD.CreateLayer("楼梯钢筋", 1, "continuous", -1, false, true);
		polyline.Layer = "楼梯钢筋";
		CAD.AddEnt(polyline);
		return polyline.ObjectId;
	}

	public static short smethod_37(Point3d point3d_0, Point3d point3d_1)
	{
		double num = CAD.P2P_Angle(point3d_0, point3d_1);
		Point3d pointAngle = CAD.GetPointAngle(point3d_0, 200.0, num * 180.0 / 3.1415926535897931 - 90.0);
		Point3d pointAngle2 = CAD.GetPointAngle(point3d_1, 200.0, num * 180.0 / 3.1415926535897931 - 90.0);
		Polyline polyline = new Polyline();
		polyline.SetDatabaseDefaults();
		Polyline polyline2 = polyline;
		int num2 = 0;
		Point2d point2d;
		point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
		polyline2.AddVertexAt(num2, point2d, 0.0, 45.0, 45.0);
		Polyline polyline3 = polyline;
		int num3 = 1;
		point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
		polyline3.AddVertexAt(num3, point2d, 0.0, 45.0, 45.0);
		Polyline polyline4 = polyline;
		int num4 = 2;
		point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
		polyline4.AddVertexAt(num4, point2d, 0.0, 45.0, 45.0);
		Polyline polyline5 = polyline;
		int num5 = 3;
		point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
		polyline5.AddVertexAt(num5, point2d, 0.0, 45.0, 45.0);
		CAD.CreateLayer("负筋", 1, "continuous", -1, false, true);
		polyline.Layer = "负筋";
		CAD.AddEnt(polyline);
		return 0;
	}

	public static Point2d smethod_38(Point3d point3d_0)
	{
		Point2d result;
		result..ctor(point3d_0.X, point3d_0.Y);
		return result;
	}

	public static Point3d smethod_39(Point2d point2d_0)
	{
		Point3d result;
		result..ctor(point2d_0.X, point2d_0.Y, 0.0);
		return result;
	}

	public static SelectionSet smethod_40(Point3d point3d_0, Point3d point3d_1, long long_0, object object_0)
	{
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		TypedValue[] array = new TypedValue[1];
		Array array2 = array;
		TypedValue typedValue;
		typedValue..ctor(checked((int)long_0), object_0);
		array2.SetValue(typedValue, 0);
		SelectionFilter selectionFilter = new SelectionFilter(array);
		PromptSelectionResult promptSelectionResult = editor.SelectCrossingWindow(point3d_0, point3d_1, selectionFilter);
		return promptSelectionResult.Value;
	}

	public static object smethod_41(string string_0)
	{
		string[] array = null;
		StreamReader streamReader = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileReader(string_0, Encoding.Default);
		checked
		{
			while (!streamReader.EndOfStream)
			{
				long num;
				array = (string[])Utils.CopyArray((Array)array, new string[(int)num + 1]);
				array[(int)num] = streamReader.ReadLine();
				num += 1L;
			}
			object result = array;
			streamReader.Close();
			return result;
		}
	}

	public static string smethod_42(string string_0, int int_2)
	{
		StreamReader streamReader = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileReader(string_0, Encoding.Default);
		string result = "";
		checked
		{
			for (int i = 0; i <= int_2; i++)
			{
				if (i == int_2)
				{
					result = streamReader.ReadLine();
				}
				else
				{
					streamReader.ReadLine();
				}
			}
			return result;
		}
	}

	public static int smethod_43(string string_0, Array array_0)
	{
		StreamWriter streamWriter = Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileWriter(string_0, false);
		long num = (long)Information.UBound((Array)array_0, 1);
		long num2 = 0L;
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
				streamWriter.WriteLine(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(array_0, new object[]
				{
					num4
				}, null)));
				num4 += 1L;
			}
			streamWriter.Close();
			int result;
			return result;
		}
	}

	public static short smethod_44(string string_0, ref string[] string_1, string string_2)
	{
		long num = 0L;
		long num2 = 0L;
		long num3 = (long)(checked(string_0.Length - 1));
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
				if (Operators.CompareString(string_0.Substring((int)num4, 1), string_2, false) == 0)
				{
					string_1 = (string[])Utils.CopyArray((Array)string_1, new string[(int)num + 1]);
					long num7;
					string_1[(int)num] = string_0.Substring((int)num7, (int)(num4 - num7));
					num7 = num4 + 1L;
					num += 1L;
				}
				else if (num4 == unchecked((long)(checked(string_0.Length - 1))))
				{
					string_1 = (string[])Utils.CopyArray((Array)string_1, new string[(int)num + 1]);
					long num7;
					string_1[(int)num] = string_0.Substring((int)num7);
				}
				num4 += 1L;
			}
			return 0;
		}
	}

	public static short smethod_45(ref Point3d[] point3d_0, ref ObjectId[] objectId_1)
	{
		long num = (long)Information.UBound(point3d_0, 1);
		long num2 = 0L;
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
				long num7 = num4 + 1L;
				long num8 = num;
				long num9 = num7;
				for (;;)
				{
					long num10 = num9;
					num6 = num8;
					if (num10 > num6)
					{
						break;
					}
					if (Conversion.Int(point3d_0[(int)num4].X) >= Conversion.Int(point3d_0[(int)num9].X))
					{
						Point3d point3d = point3d_0[(int)num4];
						point3d_0[(int)num4] = point3d_0[(int)num9];
						point3d_0[(int)num9] = point3d;
						ObjectId objectId = objectId_1[(int)num4];
						objectId_1[(int)num4] = objectId_1[(int)num9];
						objectId_1[(int)num9] = objectId;
					}
					num9 += 1L;
				}
				num4 += 1L;
			}
			long num11 = 0L;
			long num12 = num;
			num4 = num11;
			for (;;)
			{
				long num13 = num4;
				long num6 = num12;
				if (num13 > num6)
				{
					break;
				}
				long num14 = 0L;
				long num15 = num;
				long num9 = num14;
				for (;;)
				{
					long num16 = num9;
					num6 = num15;
					if (num16 > num6)
					{
						break;
					}
					if (Conversion.Int(point3d_0[(int)num4].X) == Conversion.Int(point3d_0[(int)num9].X) && Conversion.Int(point3d_0[(int)num4].Y) > Conversion.Int(point3d_0[(int)num9].Y))
					{
						Point3d point3d = point3d_0[(int)num4];
						point3d_0[(int)num4] = point3d_0[(int)num9];
						point3d_0[(int)num9] = point3d;
						ObjectId objectId = objectId_1[(int)num4];
						objectId_1[(int)num4] = objectId_1[(int)num9];
						objectId_1[(int)num9] = objectId;
					}
					num9 += 1L;
				}
				num4 += 1L;
			}
			short result;
			return result;
		}
	}

	public static Point3d smethod_46(Point3d point3d_0, Point3d point3d_1)
	{
		Point3d result;
		result..ctor((point3d_0.X + point3d_1.X) / 2.0, (point3d_0.Y + point3d_1.Y) / 2.0, (point3d_0.Z + point3d_1.Z) / 2.0);
		return result;
	}

	public static object smethod_47(ref Point3d[] point3d_0)
	{
		long num = (long)Information.UBound(point3d_0, 1);
		long num2 = 0L;
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
				long num7 = num4 + 1L;
				long num8 = num;
				long num9 = num7;
				for (;;)
				{
					long num10 = num9;
					num6 = num8;
					if (num10 > num6)
					{
						break;
					}
					Point3d point3d = point3d_0[(int)num4];
					Point3d point3d2 = point3d_0[(int)num9];
					if (point3d.get_Coordinate(0) >= point3d2.get_Coordinate(0))
					{
						Point3d point3d3 = point3d_0[(int)num4];
						point3d_0[(int)num4] = point3d_0[(int)num9];
						point3d_0[(int)num9] = point3d3;
					}
					num9 += 1L;
				}
				num4 += 1L;
			}
			long num11 = 0L;
			long num12 = num;
			num4 = num11;
			for (;;)
			{
				long num13 = num4;
				long num6 = num12;
				if (num13 > num6)
				{
					break;
				}
				long num14 = 0L;
				long num15 = num;
				long num9 = num14;
				for (;;)
				{
					long num16 = num9;
					num6 = num15;
					if (num16 > num6)
					{
						break;
					}
					Point3d point3d = point3d_0[(int)num4];
					Point3d point3d2 = point3d_0[(int)num9];
					if (point3d.get_Coordinate(0) == point3d2.get_Coordinate(0) && point3d.get_Coordinate(1) < point3d2.get_Coordinate(1))
					{
						Point3d point3d3 = point3d_0[(int)num4];
						point3d_0[(int)num4] = point3d_0[(int)num9];
						point3d_0[(int)num9] = point3d3;
					}
					num9 += 1L;
				}
				num4 += 1L;
			}
			return "";
		}
	}

	public static void smethod_48(Entity entity_0, Point3d point3d_0, Point3d point3d_1)
	{
		Vector3d vector3d = point3d_1 - point3d_0;
		Matrix3d matrix3d = Matrix3d.Displacement(vector3d);
		entity_0.TransformBy(matrix3d);
	}

	public static void smethod_49(ObjectId objectId_1, Point3d point3d_0, Point3d point3d_1)
	{
		Matrix3d matrix3d = Matrix3d.Displacement(point3d_1 - point3d_0);
		Database workingDatabase = HostApplicationServices.WorkingDatabase;
		using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
		{
			Entity entity = (Entity)transaction.GetObject(objectId_1, 1);
			entity.TransformBy(matrix3d);
			transaction.Commit();
		}
	}

	public static ObjectId smethod_50(Point3dCollection point3dCollection_0, double double_1, string string_0, bool bool_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Polyline polyline = new Polyline();
		checked
		{
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				int count = point3dCollection_0.Count;
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
					point2d..ctor(point3dCollection_0[num3].X, point3dCollection_0[num3].Y);
					polyline2.AddVertexAt(num6, point2d, 0.0, double_1, double_1);
					num3++;
				}
				polyline.Layer = string_0;
				if (bool_0)
				{
					polyline.Closed = true;
				}
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				blockTableRecord.AppendEntity(polyline);
				transaction.AddNewlyCreatedDBObject(polyline, true);
				transaction.Commit();
			}
			ObjectId result;
			return result;
		}
	}

	public static ObjectId smethod_51(Point3dCollection point3dCollection_0, string string_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Wipeout wipeout = new Wipeout();
		Point2dCollection point2dCollection = new Point2dCollection();
		checked
		{
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				int count = point3dCollection_0.Count;
				Interaction.MsgBox(count, MsgBoxStyle.OkOnly, null);
				int num = 0;
				int num2 = count - 1;
				int num3 = num;
				Point2d point2d;
				for (;;)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					Point2dCollection point2dCollection2 = point2dCollection;
					point2d..ctor(point3dCollection_0[num3].X, point3dCollection_0[num3].Y);
					point2dCollection2.Add(point2d);
					num3++;
				}
				Point2dCollection point2dCollection3 = point2dCollection;
				point2d..ctor(point3dCollection_0[0].X, point3dCollection_0[0].Y);
				point2dCollection3.Add(point2d);
				wipeout.SetDatabaseDefaults();
				Wipeout wipeout2 = wipeout;
				Point2dCollection point2dCollection4 = point2dCollection;
				Vector3d vector3d;
				vector3d..ctor(0.0, 0.0, 0.1);
				wipeout2.SetFrom(point2dCollection4, vector3d);
				wipeout.Layer = string_0;
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				blockTableRecord.AppendEntity(wipeout);
				transaction.AddNewlyCreatedDBObject(wipeout, true);
				transaction.Commit();
			}
			ObjectId result;
			return result;
		}
	}

	public static Polyline smethod_52(Point3d point3d_0, int int_2, double double_1, double double_2 = 0.0, double double_3 = 0.0)
	{
		Polyline polyline = new Polyline();
		checked
		{
			Point2d[] array = new Point2d[2 * int_2 - 1 + 1];
			double num = 6.2831853071795862 / (double)int_2;
			for (int i = 0; i <= int_2; i++)
			{
				unchecked
				{
					double num2 = point3d_0.X + double_1 * Math.Cos((double)i * num);
					double num3 = point3d_0.Y + double_1 * Math.Sin((double)i * num);
					array[i]..ctor(num2, num3);
					polyline.AddVertexAt(i, array[i], 0.0, double_2, double_2);
				}
			}
			polyline.Closed = true;
			CAD.AddEnt(polyline);
			return polyline;
		}
	}

	public static Region smethod_53(object object_0)
	{
		Region result;
		if (!object_0.Closed)
		{
			Interaction.MsgBox("多段线不闭合，无法创建面域！", MsgBoxStyle.Critical, null);
			result = null;
		}
		else
		{
			DBObjectCollection dbobjectCollection = new DBObjectCollection();
			dbobjectCollection.Add(object_0);
			DBObjectCollection dbobjectCollection2 = new DBObjectCollection();
			dbobjectCollection2 = Region.CreateFromCurves(dbobjectCollection);
			Region region = (Region)dbobjectCollection2[0];
			CAD.AddEnt(region);
			result = region;
		}
		return result;
	}

	public static int smethod_54(ObjectId objectId_1)
	{
		string text = objectId_1.ToString();
		return checked((int)Math.Round(Conversion.Val(text.Substring(1, text.Length - 2))));
	}

	public static Group smethod_55(Array array_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Group group;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
			group = new Group("组的说明", true);
			dbdictionary.SetAt("*", group);
			short num = checked((short)Information.UBound(array_0, 1));
			short num2 = 0;
			short num3 = num;
			short num4 = num2;
			for (;;)
			{
				short num5 = num4;
				short num6 = num3;
				if (num5 > num6)
				{
					break;
				}
				group.Append(array_0[(int)num4]);
				num4 += 1;
			}
			transaction.AddNewlyCreatedDBObject(group, true);
			transaction.Commit();
		}
		return group;
	}

	public static short smethod_56(Group group_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		checked
		{
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				Interaction.MsgBox(group_0.Name, MsgBoxStyle.OkOnly, null);
				DBDictionary dbdictionary = (DBDictionary)transaction.GetObject(database.GroupDictionaryId, 1);
				Group group = (Group)transaction.GetObject(dbdictionary.GetAt(group_0.Name), 1);
				ObjectId[] allEntityIds = group.GetAllEntityIds();
				int num = 0;
				int num2 = Information.UBound(allEntityIds, 1);
				int num3 = num;
				for (;;)
				{
					int num4 = num3;
					int num5 = num2;
					if (num4 > num5)
					{
						break;
					}
					Class36.smethod_64(allEntityIds[num3]);
					num3++;
				}
				transaction.Commit();
			}
			short result;
			return result;
		}
	}

	public static ObjectId smethod_57(string string_0, Point3d point3d_0, double double_1, TextHorizontalMode textHorizontalMode_0 = 0, TextVerticalMode textVerticalMode_0 = 0, string string_1 = "STANDARD", double double_2 = 0.0)
	{
		int num;
		ObjectId objectId;
		int num4;
		object obj;
		try
		{
			IL_01:
			ProjectData.ClearProjectError();
			num = -2;
			IL_09:
			int num2 = 2;
			DBText dbtext = new DBText();
			IL_11:
			num2 = 3;
			dbtext.TextString = string_0;
			IL_1A:
			num2 = 4;
			dbtext.Height = double_1;
			IL_23:
			num2 = 5;
			dbtext.HorizontalMode = textHorizontalMode_0;
			IL_2C:
			num2 = 6;
			dbtext.Rotation = double_2;
			IL_36:
			num2 = 7;
			if (textVerticalMode_0 == 0)
			{
				goto IL_4B;
			}
			IL_42:
			num2 = 8;
			dbtext.VerticalMode = 2;
			IL_4B:
			num2 = 10;
			dbtext.WidthFactor = 0.7;
			IL_5D:
			num2 = 11;
			if (textHorizontalMode_0 == 0)
			{
				goto IL_75;
			}
			IL_69:
			num2 = 12;
			dbtext.AlignmentPoint = point3d_0;
			goto IL_82;
			IL_75:
			num2 = 14;
			IL_78:
			num2 = 15;
			dbtext.Position = point3d_0;
			IL_82:
			num2 = 17;
			if (Operators.CompareString(string_1, "COMPLEX", false) != 0)
			{
				goto IL_BF;
			}
			IL_97:
			num2 = 18;
			dbtext.TextStyleId = CAD.CreateTextStyle("COMPLEX", "COMPLEX.shx", "HZTXT.Shx", 0.7);
			goto IL_105;
			IL_BF:
			num2 = 20;
			if (!(Operators.CompareString(string_1, "黑体", false) == 0 | Operators.CompareString(string_1, " 宋体", false) == 0))
			{
				goto IL_105;
			}
			IL_E5:
			num2 = 21;
			dbtext.TextStyleId = CAD.CreateTextStyle(string_1, string_1, "", 0.7);
			IL_105:
			num2 = 23;
			CAD.AddEnt(dbtext);
			IL_10F:
			num2 = 24;
			objectId = dbtext.ObjectId;
			IL_119:
			goto IL_1D8;
			IL_11E:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_192:
			goto IL_1CD;
			IL_194:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_11E;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_1AA:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_194;
		}
		IL_1CD:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_1D8:
		ObjectId result = objectId;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ObjectId smethod_58(string string_0, Point3d point3d_0, double double_1)
	{
		DBText dbtext = new DBText();
		dbtext.TextString = string_0;
		dbtext.Height = double_1;
		dbtext.WidthFactor = 0.7;
		dbtext.HorizontalMode = 1;
		dbtext.VerticalMode = 2;
		dbtext.AlignmentPoint = point3d_0;
		CAD.AddEnt(dbtext);
		return dbtext.ObjectId;
	}

	public static ObjectId smethod_59(string string_0, Point3d point3d_0, Point3d point3d_1, double double_1, string string_1 = "STANDARD", double double_2 = 0.0)
	{
		int num;
		ObjectId objectId;
		int num3;
		object obj;
		try
		{
			IL_01:
			ProjectData.ClearProjectError();
			num = -2;
			IL_09:
			int num2 = 2;
			DBText dbtext = new DBText();
			IL_11:
			num2 = 3;
			dbtext.TextString = string_0;
			IL_1A:
			num2 = 4;
			dbtext.Height = double_1;
			IL_23:
			num2 = 5;
			dbtext.HorizontalMode = 5;
			IL_2C:
			num2 = 6;
			dbtext.Rotation = double_2;
			IL_36:
			num2 = 7;
			dbtext.VerticalMode = 0;
			IL_3F:
			num2 = 8;
			dbtext.Position = point3d_0;
			IL_48:
			num2 = 9;
			dbtext.AlignmentPoint = point3d_1;
			IL_52:
			num2 = 10;
			if (Operators.CompareString(string_1, "COMPLEX", false) != 0)
			{
				goto IL_8F;
			}
			IL_67:
			num2 = 11;
			dbtext.TextStyleId = CAD.CreateTextStyle("COMPLEX", "COMPLEX.shx", "HZTXT.Shx", 0.7);
			goto IL_D5;
			IL_8F:
			num2 = 13;
			if (!(Operators.CompareString(string_1, "黑体", false) == 0 | Operators.CompareString(string_1, " 宋体", false) == 0))
			{
				goto IL_D5;
			}
			IL_B5:
			num2 = 14;
			dbtext.TextStyleId = CAD.CreateTextStyle(string_1, string_1, "", 0.7);
			IL_D5:
			num2 = 16;
			CAD.AddEnt(dbtext);
			IL_DF:
			num2 = 17;
			objectId = dbtext.ObjectId;
			IL_EA:
			goto IL_188;
			IL_EF:
			goto IL_194;
			IL_F4:
			num3 = num2;
			if (num <= -2)
			{
				goto IL_10B;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			goto IL_163;
			IL_10B:
			int num4 = num3 + 1;
			num3 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
			IL_163:
			goto IL_194;
		}
		catch when (endfilter(obj is Exception & num != 0 & num3 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_F4;
		}
		IL_188:
		ObjectId result = objectId;
		if (num3 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
		IL_194:
		throw ProjectData.CreateProjectError(-2146828237);
	}

	public static object smethod_60(string string_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		mdiActiveDocument.Editor.WriteMessage("\n" + string_0);
		return "";
	}

	public static Point3d smethod_61(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		Point3d point3d = Class36.smethod_62(point3d_0, point3d_1, point3d_2);
		Point3d result;
		result..ctor(point3d.X + point3d.X - point3d_0.X, point3d.Y + point3d.Y - point3d_0.Y, 0.0);
		return result;
	}

	public static Point3d smethod_62(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		double[] array = new double[6];
		Point3d result;
		if (Class36.smethod_63(point3d_1, point3d_2, point3d_0))
		{
			result = point3d_0;
		}
		else
		{
			array[0] = point3d_2.get_Coordinate(0) - point3d_1.get_Coordinate(0);
			array[1] = point3d_2.get_Coordinate(1) - point3d_1.get_Coordinate(1);
			array[2] = point3d_2.get_Coordinate(2) - point3d_1.get_Coordinate(2);
			array[3] = point3d_2.get_Coordinate(0) - point3d_0.get_Coordinate(0);
			array[4] = point3d_2.get_Coordinate(1) - point3d_0.get_Coordinate(1);
			array[5] = point3d_2.get_Coordinate(2) - point3d_0.get_Coordinate(2);
			double num = -(array[0] * array[3] + array[1] * array[4] + array[2] * array[5]) / (Math.Pow(array[0], 2.0) + Math.Pow(array[1], 2.0) + Math.Pow(array[2], 2.0));
			result..ctor(array[0] * num + point3d_2.get_Coordinate(0), array[1] * num + point3d_2.get_Coordinate(1), array[2] * num + point3d_2.get_Coordinate(2));
		}
		return result;
	}

	public static bool smethod_63(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		double num = point3d_0.DistanceTo(point3d_1);
		double num2 = point3d_0.DistanceTo(point3d_2);
		double num3 = point3d_1.DistanceTo(point3d_2);
		return !(num + num2 > num3 & num + num3 > num2 & num2 + num3 > num);
	}

	public static int smethod_64(ObjectId objectId_1)
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
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			IL_11:
			num2 = 3;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				Entity entity = (Entity)transaction.GetObject(objectId_1, 1);
				entity.Erase();
				transaction.Commit();
			}
			IL_4D:
			num2 = 5;
			if (Information.Err().Number <= 0)
			{
				goto IL_70;
			}
			IL_5E:
			num2 = 6;
			Class36.smethod_60(Information.Err().Description);
			IL_70:
			goto IL_E8;
			IL_72:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_A2:
			goto IL_DD;
			IL_A4:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_72;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_BA:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_A4;
		}
		IL_DD:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_E8:
		int num5;
		int result = num5;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Entity smethod_65(ObjectId objectId_1)
	{
		int num;
		Entity entity2;
		int num4;
		object obj;
		try
		{
			IL_01:
			ProjectData.ClearProjectError();
			num = -2;
			IL_09:
			int num2 = 2;
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			IL_11:
			num2 = 3;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				Entity entity = (Entity)transaction.GetObject(objectId_1, 1);
				entity2 = entity;
			}
			IL_44:
			goto IL_AC;
			IL_46:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_66:
			goto IL_A1;
			IL_68:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_46;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_7E:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_68;
		}
		IL_A1:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_AC:
		Entity result = entity2;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int smethod_66(ObjectId objectId_1, object object_0)
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
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			IL_11:
			num2 = 3;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				object @object = transaction.GetObject(objectId_1, 1);
				NewLateBinding.LateSet(@object, null, "DimensionStyleName", new object[]
				{
					object_0
				}, null, null);
				transaction.Commit();
			}
			IL_5F:
			num2 = 5;
			if (Information.Err().Number <= 0)
			{
				goto IL_82;
			}
			IL_70:
			num2 = 6;
			Class36.smethod_60(Information.Err().Description);
			IL_82:
			goto IL_FA;
			IL_84:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_B4:
			goto IL_EF;
			IL_B6:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_84;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_CC:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_B6;
		}
		IL_EF:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_FA:
		int num5;
		int result = num5;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Arc smethod_67(Point3d point3d_0, double double_1, double double_2, double double_3)
	{
		Arc arc = new Arc(point3d_0, double_1, double_2, double_3);
		CAD.AddEnt(arc);
		return arc;
	}

	public static ObjectId smethod_68(object object_0)
	{
		int num;
		ObjectId objectId;
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
				DimStyleTable dimStyleTable = (DimStyleTable)transaction.GetObject(database.DimStyleTableId, 0);
				if (!dimStyleTable.Has("DIM100"))
				{
					Class36.smethod_69("DIM100");
				}
				DimStyleTableRecord dimStyleTableRecord = (DimStyleTableRecord)transaction.GetObject(dimStyleTable["DIM100"], 0);
				objectId = dimStyleTableRecord.ObjectId;
				transaction.Commit();
			}
			IL_9E:
			goto IL_10A;
			IL_A0:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_C4:
			goto IL_FF;
			IL_C6:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_A0;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_DC:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_C6;
		}
		IL_FF:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_10A:
		ObjectId result = objectId;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static short smethod_69(string string_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				DimStyleTable dimStyleTable = (DimStyleTable)transaction.GetObject(database.DimStyleTableId, 1);
				dimStyleTable.UpgradeOpen();
				if (!dimStyleTable.Has(string_0))
				{
					string text = Class33.Class31_0.Info.DirectoryPath + "\\support\\DimStyle.Dwg";
					Database database2 = new Database(false, true);
					database2.ReadDwgFile(text, FileShare.Read, true, "");
					DimStyleTableRecord dimStyleTableRecord;
					using (Transaction transaction2 = database2.TransactionManager.StartTransaction())
					{
						DimStyleTable dimStyleTable2 = (DimStyleTable)transaction2.GetObject(database2.DimStyleTableId, 0);
						dimStyleTableRecord = (DimStyleTableRecord)transaction2.GetObject(dimStyleTable2[string_0], 0);
						transaction2.Dispose();
					}
					mdiActiveDocument.Editor.WriteMessage("\n" + dimStyleTableRecord.Name);
					DimStyleTableRecord dimStyleTableRecord2 = new DimStyleTableRecord();
					dimStyleTableRecord2 = (DimStyleTableRecord)dimStyleTableRecord.Clone();
					dimStyleTable.Add(dimStyleTableRecord2);
					transaction.AddNewlyCreatedDBObject(dimStyleTableRecord2, true);
					mdiActiveDocument.Editor.WriteMessage("\n标注样式:" + string_0 + "添加成功");
					database.Dimstyle = dimStyleTableRecord2.ObjectId;
				}
				transaction.Commit();
			}
		}
		catch (Exception ex)
		{
			mdiActiveDocument.Editor.WriteMessage("\n标注样式加载出错: " + ex.Message);
		}
		short result;
		return result;
	}

	public static short smethod_70(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		double num = point3d_1.GetVectorTo(point3d_2).AngleOnPlane(new Plane());
		double num2 = point3d_1.GetVectorTo(point3d_0).AngleOnPlane(new Plane());
		if (num2 - num > 180.0)
		{
			num2 -= 360.0;
		}
		if (num - num2 > 180.0)
		{
			num -= 360.0;
		}
		short result;
		if (num > num2)
		{
			result = -1;
		}
		else
		{
			result = 1;
		}
		return result;
	}

	public static short smethod_71(ObjectId objectId_1, string string_0, LineWeight lineWeight_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			LinetypeTable linetypeTable = (LinetypeTable)transaction.GetObject(database.LinetypeTableId, 0);
			if (!linetypeTable.Has(string_0))
			{
				database.LoadLineTypeFile(string_0, "acad.lin");
			}
			Entity entity = (Entity)transaction.GetObject(objectId_1, 1);
			entity.Linetype = string_0;
			entity.LineWeight = lineWeight_0;
			transaction.Commit();
		}
		short result;
		return result;
	}

	public static Entity smethod_72(string string_0 = "选择一个对象:")
	{
		int num;
		Entity entity3;
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
				PromptEntityOptions promptEntityOptions = new PromptEntityOptions("\n" + string_0);
				PromptEntityResult entity = mdiActiveDocument.Editor.GetEntity(promptEntityOptions);
				Entity entity2 = (Entity)transaction.GetObject(entity.ObjectId, 0);
				entity3 = entity2;
			}
			IL_7D:
			goto IL_E9;
			IL_7F:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_A3:
			goto IL_DE;
			IL_A5:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_7F;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_BB:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_A5;
		}
		IL_DE:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_E9:
		Entity result = entity3;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void smethod_73(ObjectId objectId_1)
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
				Entity entity = (Entity)transaction.GetObject(objectId_1, 0);
				entity.Highlight();
				transaction.Commit();
			}
			IL_60:
			goto IL_CC;
			IL_62:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_86:
			goto IL_C1;
			IL_88:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_62;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_9E:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_88;
		}
		IL_C1:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_CC:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	public static void smethod_74(ObjectId objectId_1)
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
				Entity entity = (Entity)transaction.GetObject(objectId_1, 0);
				entity.Unhighlight();
				transaction.Commit();
			}
			IL_60:
			goto IL_CC;
			IL_62:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_86:
			goto IL_C1;
			IL_88:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_62;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_9E:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_88;
		}
		IL_C1:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_CC:
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	public static string amIrsvPmtO(ObjectId objectId_1)
	{
		int num;
		string text;
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
				object @object = transaction.GetObject(objectId_1, 0);
				text = @object.GetType().ToString().Replace("Autodesk.AutoCAD.DatabaseServices.", "");
				transaction.Commit();
			}
			IL_71:
			goto IL_DD;
			IL_73:
			int num3 = num4 + 1;
			num4 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
			IL_97:
			goto IL_D2;
			IL_99:
			num4 = num2;
			if (num <= -2)
			{
				goto IL_73;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_AF:;
		}
		catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_99;
		}
		IL_D2:
		throw ProjectData.CreateProjectError(-2146828237);
		IL_DD:
		string result = text;
		if (num4 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static short smethod_75(Point3d point3d_0, string string_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(blockTable[string_0], 0);
			BlockReference blockReference = new BlockReference(point3d_0, blockTableRecord2.ObjectId);
			blockTableRecord.AppendEntity(blockReference);
			transaction.AddNewlyCreatedDBObject(blockReference, true);
			transaction.Commit();
		}
		short result;
		return result;
	}

	public static Entity smethod_76(DBObject dbobject_0, string string_0, string string_1, double double_1)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Hatch hatch = new Hatch();
		Entity result;
		try
		{
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				objectIdCollection.Add(dbobject_0.ObjectId);
				blockTableRecord.AppendEntity(hatch);
				transaction.AddNewlyCreatedDBObject(hatch, true);
				hatch.SetDatabaseDefaults();
				if (double_1 != 0.0)
				{
					hatch.PatternScale = double_1;
				}
				hatch.Layer = string_0;
				hatch.SetHatchPattern(1, string_1);
				hatch.Associative = true;
				hatch.AppendLoop(16, objectIdCollection);
				hatch.EvaluateHatch(true);
				transaction.Commit();
			}
			result = hatch;
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}

	public static short smethod_77(string string_0, string string_1 = "")
	{
		Database workingDatabase = HostApplicationServices.WorkingDatabase;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		short result;
		using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
		{
			LayerTable layerTable = (LayerTable)transaction.GetObject(workingDatabase.LayerTableId, 1);
			if (!layerTable.Has(string_0))
			{
				editor.WriteMessage("\r\n" + string_0 + "图层不存在！");
				result = 0;
			}
			else
			{
				LayerTableRecord layerTableRecord = (LayerTableRecord)transaction.GetObject(layerTable[string_0], 1);
				LayerTableRecord layerTableRecord2 = (LayerTableRecord)transaction.GetObject(workingDatabase.Clayer, 0);
				if (Operators.CompareString(string_1, "", false) != 0)
				{
					if (!layerTable.Has(string_1))
					{
						CAD.CreateLayer(string_1, 0, "continuous", -1, false, true);
					}
					if (Operators.CompareString(string_0, layerTableRecord2.Name, false) == 0 | Operators.CompareString(string_0, "0", false) == 0)
					{
						editor.WriteMessage("\r\n不能删除当前图层和0层！");
					}
					else
					{
						TypedValue typedValue;
						typedValue..ctor(8, string_0);
						TypedValue[] array = new TypedValue[]
						{
							typedValue
						};
						SelectionFilter selectionFilter = new SelectionFilter(array);
						PromptSelectionResult promptSelectionResult = editor.SelectAll(selectionFilter);
						if (promptSelectionResult.Status == 5100)
						{
							foreach (ObjectId objectId in promptSelectionResult.Value.GetObjectIds())
							{
								Entity entity = (Entity)transaction.GetObject(objectId, 1);
								entity.Layer = string_1;
							}
						}
						layerTableRecord.Erase(true);
					}
				}
				else if (Operators.CompareString(string_0, layerTableRecord2.Name, false) == 0 | Operators.CompareString(string_0, "0", false) == 0)
				{
					editor.WriteMessage("\r\n不能删除当前图层和0层！");
				}
				else
				{
					TypedValue typedValue2;
					typedValue2..ctor(8, string_0);
					TypedValue[] array2 = new TypedValue[]
					{
						typedValue2
					};
					SelectionFilter selectionFilter2 = new SelectionFilter(array2);
					PromptSelectionResult promptSelectionResult2 = editor.SelectAll(selectionFilter2);
					if (promptSelectionResult2.Status == 5100)
					{
						foreach (ObjectId objectId2 in promptSelectionResult2.Value.GetObjectIds())
						{
							Entity entity2 = (Entity)transaction.GetObject(objectId2, 1);
							entity2.Erase(true);
						}
					}
					layerTableRecord.Erase(true);
				}
				transaction.Commit();
			}
		}
		return result;
	}

	public static ObjectId smethod_78(string string_0, int int_2, double double_1, bool bool_0 = false)
	{
		Database workingDatabase = HostApplicationServices.WorkingDatabase;
		ObjectId result;
		try
		{
			ObjectId objectId;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				DimStyleTable dimStyleTable = (DimStyleTable)transaction.GetObject(workingDatabase.DimStyleTableId, 1);
				DimStyleTableRecord dimStyleTableRecord = new DimStyleTableRecord();
				dimStyleTableRecord.Dimblk = CAD.GetArrowBlock("_ARCHTICK");
				dimStyleTableRecord.Dimasz = 1.0;
				dimStyleTableRecord.Dimadec = 2;
				dimStyleTableRecord.Dimdec = 0;
				dimStyleTableRecord.Dimdli = 3.75;
				dimStyleTableRecord.Dimexe = 3.0;
				dimStyleTableRecord.Dimtix = true;
				dimStyleTableRecord.Dimexo = 3.0;
				dimStyleTableRecord.Dimgap = 1.0;
				dimStyleTableRecord.Dimtad = 1;
				dimStyleTableRecord.Dimtih = false;
				dimStyleTableRecord.Dimtofl = true;
				dimStyleTableRecord.Dimtoh = false;
				dimStyleTableRecord.Dimtxt = 3.0;
				dimStyleTableRecord.Dimtmove = 2;
				dimStyleTableRecord.Dimscale = (double)int_2;
				dimStyleTableRecord.Dimlfac = double_1;
				dimStyleTableRecord.Name = string_0;
				dimStyleTableRecord.Dimclrd = Color.FromColorIndex(194, 3);
				dimStyleTableRecord.Dimclre = Color.FromColorIndex(194, 3);
				objectId = dimStyleTable.Add(dimStyleTableRecord);
				transaction.AddNewlyCreatedDBObject(dimStyleTableRecord, true);
				transaction.Commit();
			}
			if (bool_0)
			{
				workingDatabase.Dimstyle = objectId;
			}
			result = objectId;
		}
		catch (Exception ex)
		{
			using (Transaction transaction2 = workingDatabase.TransactionManager.StartTransaction())
			{
				DimStyleTable dimStyleTable2 = (DimStyleTable)transaction2.GetObject(workingDatabase.DimStyleTableId, 0);
				if (!dimStyleTable2.Has(string_0))
				{
					ObjectId @null = ObjectId.Null;
					result = @null;
					ProjectData.ClearProjectError();
				}
				else
				{
					DimStyleTableRecord dimStyleTableRecord2 = (DimStyleTableRecord)transaction2.GetObject(dimStyleTable2[string_0], 1);
					if (bool_0)
					{
						workingDatabase.Dimstyle = dimStyleTableRecord2.ObjectId;
					}
					result = dimStyleTableRecord2.ObjectId;
					ProjectData.ClearProjectError();
				}
			}
		}
		return result;
	}

	public static ObjectId smethod_79(string string_0, int int_2, double double_1, ObjectId objectId_1, bool bool_0 = false)
	{
		Database workingDatabase = HostApplicationServices.WorkingDatabase;
		ObjectId result;
		try
		{
			ObjectId objectId;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				DimStyleTable dimStyleTable = (DimStyleTable)transaction.GetObject(workingDatabase.DimStyleTableId, 1);
				DimStyleTableRecord dimStyleTableRecord = new DimStyleTableRecord();
				dimStyleTableRecord.Dimblk = CAD.GetArrowBlock("_ARCHTICK");
				dimStyleTableRecord.Dimasz = 1.0;
				dimStyleTableRecord.Dimadec = 2;
				dimStyleTableRecord.Dimdec = 0;
				dimStyleTableRecord.Dimdli = 3.75;
				dimStyleTableRecord.Dimexe = 3.0;
				dimStyleTableRecord.Dimtix = true;
				dimStyleTableRecord.Dimexo = 3.0;
				dimStyleTableRecord.Dimgap = 1.0;
				dimStyleTableRecord.Dimtad = 1;
				dimStyleTableRecord.Dimtih = false;
				dimStyleTableRecord.Dimtofl = true;
				dimStyleTableRecord.Dimtoh = false;
				dimStyleTableRecord.Dimtxsty = objectId_1;
				dimStyleTableRecord.Dimtxt = 3.0;
				dimStyleTableRecord.Dimtmove = 2;
				dimStyleTableRecord.Dimscale = (double)int_2;
				dimStyleTableRecord.Dimlfac = double_1;
				dimStyleTableRecord.Name = string_0;
				dimStyleTableRecord.Dimclrd = Color.FromColorIndex(194, 3);
				dimStyleTableRecord.Dimclre = Color.FromColorIndex(194, 3);
				objectId = dimStyleTable.Add(dimStyleTableRecord);
				transaction.AddNewlyCreatedDBObject(dimStyleTableRecord, true);
				transaction.Commit();
			}
			if (bool_0)
			{
				workingDatabase.Dimstyle = objectId;
			}
			result = objectId;
		}
		catch (Exception ex)
		{
			using (Transaction transaction2 = workingDatabase.TransactionManager.StartTransaction())
			{
				DimStyleTable dimStyleTable2 = (DimStyleTable)transaction2.GetObject(workingDatabase.DimStyleTableId, 0);
				if (!dimStyleTable2.Has(string_0))
				{
					ObjectId @null = ObjectId.Null;
					result = @null;
					ProjectData.ClearProjectError();
				}
				else
				{
					DimStyleTableRecord dimStyleTableRecord2 = (DimStyleTableRecord)transaction2.GetObject(dimStyleTable2[string_0], 1);
					if (bool_0)
					{
						workingDatabase.Dimstyle = dimStyleTableRecord2.ObjectId;
					}
					result = dimStyleTableRecord2.ObjectId;
					ProjectData.ClearProjectError();
				}
			}
		}
		return result;
	}

	public static ObjectId smethod_80(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		double_1 /= 100.0;
		double num = point3d_0.DistanceTo(point3d_1) * 2.0;
		double num2 = point3d_0.GetVectorTo(point3d_1).AngleOnPlane(new Plane());
		Point3d point3d;
		point3d..ctor((point3d_0.X + point3d_1.X) / 2.0, (point3d_0.Y + point3d_1.Y) / 2.0, 0.0);
		double num3 = 3.1415926535897931;
		object obj = new Polyline();
		Point3d pointAngle = CAD.GetPointAngle(point3d_0, num / 10.0 * double_1, num2 * 180.0 / num3 + 180.0);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			0,
			Class36.smethod_38(pointAngle),
			0,
			0,
			0
		}, null, null, null, true);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			1,
			Class36.smethod_38(point3d_0),
			0,
			0,
			0
		}, null, null, null, true);
		pointAngle = CAD.GetPointAngle(point3d, num / 15.0 * double_1, num2 * 180.0 / num3 + 180.0);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			2,
			Class36.smethod_38(pointAngle),
			0,
			0,
			0
		}, null, null, null, true);
		pointAngle = CAD.GetPointAngle(point3d, num / 8.0 * double_1, num2 * 180.0 / num3 - 105.0);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			3,
			Class36.smethod_38(pointAngle),
			0,
			0,
			0
		}, null, null, null, true);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			4,
			Class36.smethod_38(point3d),
			0,
			0,
			0
		}, null, null, null, true);
		pointAngle = CAD.GetPointAngle(point3d, num / 8.0 * double_1, num2 * 180.0 / num3 + 75.0);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			5,
			Class36.smethod_38(pointAngle),
			0,
			0,
			0
		}, null, null, null, true);
		pointAngle = CAD.GetPointAngle(point3d, num / 15.0 * double_1, num2 * 180.0 / num3);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			6,
			Class36.smethod_38(pointAngle),
			0,
			0,
			0
		}, null, null, null, true);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			7,
			Class36.smethod_38(point3d_1),
			0,
			0,
			0
		}, null, null, null, true);
		pointAngle = CAD.GetPointAngle(point3d_1, num / 10.0 * double_1, num2 * 180.0 / num3);
		NewLateBinding.LateCall(obj, null, "AddVertexAt", new object[]
		{
			8,
			Class36.smethod_38(pointAngle),
			0,
			0,
			0
		}, null, null, null, true);
		CAD.AddEnt((Entity)obj);
		object obj2 = NewLateBinding.LateGet(obj, null, "objectid", new object[0], null, null, null);
		ObjectId objectId;
		return (obj2 != null) ? ((ObjectId)obj2) : objectId;
	}

	public static Polyline smethod_81(Point3d point3d_0, int int_2, double double_1)
	{
		int num;
		Polyline polyline;
		int num6;
		object obj;
		try
		{
			IL_01:
			ProjectData.ClearProjectError();
			num = -2;
			IL_09:
			int num2 = 2;
			if (int_2 != 1)
			{
				goto IL_1D;
			}
			IL_11:
			num2 = 3;
			int num3 = 1;
			IL_16:
			num2 = 4;
			int num4 = 1;
			goto IL_5D;
			IL_1D:
			num2 = 6;
			if (int_2 != 2)
			{
				goto IL_31;
			}
			IL_25:
			num2 = 7;
			num3 = -1;
			IL_2A:
			num2 = 8;
			num4 = 1;
			goto IL_5D;
			IL_31:
			num2 = 10;
			if (int_2 != 3)
			{
				goto IL_48;
			}
			IL_3A:
			num2 = 11;
			num3 = -1;
			IL_40:
			num2 = 12;
			num4 = -1;
			goto IL_5D;
			IL_48:
			num2 = 14;
			if (int_2 != 4)
			{
				goto IL_5D;
			}
			IL_51:
			num2 = 15;
			num3 = 1;
			IL_57:
			num2 = 16;
			num4 = -1;
			IL_5D:
			num2 = 18;
			Point3d[] array = new Point3d[5];
			IL_67:
			num2 = 19;
			long num5 = 300L;
			IL_75:
			num2 = 20;
			array[0] = CAD.GetPointXY(point3d_0, (double)(checked(unchecked((long)(checked(num3 * 4))) * num5)) * double_1, (double)(checked(unchecked((long)num4) * num5)) * double_1);
			IL_9E:
			num2 = 21;
			array[1] = CAD.GetPointXY(point3d_0, (double)(checked(unchecked((long)num3) * num5)) * double_1, (double)(checked(unchecked((long)num4) * num5)) * double_1);
			IL_C5:
			num2 = 22;
			array[2] = CAD.GetPointXY(point3d_0, (double)(checked(unchecked((long)(checked(0 - num3))) * num5)) * double_1, (double)(checked(unchecked((long)num4) * num5)) * double_1);
			IL_EE:
			num2 = 23;
			array[3] = point3d_0;
			IL_FE:
			num2 = 24;
			array[4] = array[1];
			IL_119:
			num2 = 25;
			polyline = CAD.AddPline(array, 0.0, false, "");
			IL_132:
			num2 = 26;
			if (Information.Err().Number <= 0)
			{
				goto IL_159;
			}
			IL_144:
			num2 = 27;
			Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			IL_159:
			goto IL_229;
			IL_15E:
			goto IL_235;
			IL_163:
			num6 = num2;
			if (num <= -2)
			{
				goto IL_17E;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			goto IL_203;
			IL_17E:
			int num7 = num6 + 1;
			num6 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
			IL_203:
			goto IL_235;
		}
		catch when (endfilter(obj is Exception & num != 0 & num6 == 0))
		{
			Exception ex = (Exception)obj2;
			goto IL_163;
		}
		IL_229:
		Polyline result = polyline;
		if (num6 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
		IL_235:
		throw ProjectData.CreateProjectError(-2146828237);
	}

	public static object smethod_82(Point3d point3d_0, int int_2, double double_1, string string_0)
	{
		int num;
		object obj;
		int num6;
		object obj2;
		try
		{
			IL_01:
			ProjectData.ClearProjectError();
			num = -2;
			IL_09:
			int num2 = 2;
			if (int_2 != 1)
			{
				goto IL_3D;
			}
			IL_11:
			num2 = 3;
			int num3 = 1;
			IL_16:
			num2 = 4;
			int num4 = 1;
			IL_1B:
			num2 = 5;
			Point3d pointXY = CAD.GetPointXY(point3d_0, 300.0 * double_1, 350.0 * double_1);
			goto IL_7E;
			IL_3D:
			num2 = 7;
			if (int_2 != 2)
			{
				goto IL_52;
			}
			IL_45:
			num2 = 8;
			num3 = -1;
			IL_4A:
			num2 = 9;
			num4 = 1;
			goto IL_7E;
			IL_52:
			num2 = 11;
			if (int_2 != 3)
			{
				goto IL_69;
			}
			IL_5B:
			num2 = 12;
			num3 = -1;
			IL_61:
			num2 = 13;
			num4 = -1;
			goto IL_7E;
			IL_69:
			num2 = 15;
			if (int_2 != 4)
			{
				goto IL_7E;
			}
			IL_72:
			num2 = 16;
			num3 = 1;
			IL_78:
			num2 = 17;
			num4 = -1;
			IL_7E:
			num2 = 19;
			Point3d[] array = new Point3d[5];
			IL_88:
			num2 = 20;
			long num5 = 300L;
			IL_95:
			num2 = 21;
			array[0] = CAD.GetPointXY(point3d_0, (double)(checked(unchecked((long)(checked(num3 * 4))) * num5)) * double_1, (double)(checked(unchecked((long)num4) * num5)) * double_1);
			IL_BC:
			num2 = 22;
			array[1] = CAD.GetPointXY(point3d_0, (double)(checked(unchecked((long)num3) * num5)) * double_1, (double)(checked(unchecked((long)num4) * num5)) * double_1);
			IL_E1:
			num2 = 23;
			array[2] = CAD.GetPointXY(point3d_0, (double)(checked(unchecked((long)(checked(0 - num3))) * num5)) * double_1, (double)(checked(unchecked((long)num4) * num5)) * double_1);
			IL_108:
			num2 = 24;
			array[3] = point3d_0;
			IL_118:
			num2 = 25;
			array[4] = array[1];
			IL_133:
			num2 = 26;
			CAD.AddPline(array, 0.0, false, "");
			IL_14C:
			num2 = 27;
			Class36.smethod_23(pointXY, string_0, 300.0 * double_1, 0, "");
			IL_169:
			num2 = 28;
			obj = null;
			goto IL_272;
			IL_174:
			goto IL_27F;
			IL_179:
			num6 = num2;
			if (num <= -2)
			{
				goto IL_194;
			}
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
			IL_18F:
			goto IL_27F;
			IL_194:
			int num7 = num6 + 1;
			num6 = 0;
			@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num7);
			goto IL_174;
			IL_225:
			num2 = 29;
			if (Information.Err().Number <= 0)
			{
				goto IL_24C;
			}
			IL_237:
			num2 = 30;
			Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			IL_24C:;
		}
		catch when (endfilter(obj2 is Exception & num != 0 & num6 == 0))
		{
			Exception ex = (Exception)obj3;
			goto IL_179;
		}
		IL_272:
		object result = obj;
		if (num6 != 0)
		{
			ProjectData.ClearProjectError();
		}
		return result;
		IL_27F:
		throw ProjectData.CreateProjectError(-2146828237);
	}

	public static ObjectIdCollection smethod_83(object object_0, long long_0, string string_0, short short_0, double double_1)
	{
		ObjectIdCollection objectIdCollection = new ObjectIdCollection();
		ObjectIdCollection objectIdCollection2 = new ObjectIdCollection();
		short num = checked((short)Information.UBound(object_0, 1));
		double num2 = Math.Max(object_0[0].Y, object_0[(int)num].Y) + (double)long_0;
		double num3 = Math.Max(object_0[0].X, object_0[(int)num].X) + (double)long_0;
		double num4 = Math.Min(object_0[0].Y, object_0[(int)num].Y) - (double)long_0;
		double num5 = Math.Min(object_0[0].X, object_0[(int)num].X) - (double)long_0;
		double_1 /= 100.0;
		CAD.CreateLayer("Y_引注", 4, "continuous", -3, false, true);
		CAD.CreateLayer("Y_引线", 5, "continuous", 13, false, true);
		if (short_0 == 1)
		{
			checked
			{
				for (int i = 0; i < object_0.Length; i++)
				{
					Point3d point3d = object_0[i];
					ObjectIdCollection objectIdCollection3 = objectIdCollection;
					Point3d p = point3d;
					Point3d p2;
					p2..ctor(point3d.X, num2, 0.0);
					objectIdCollection3.Add(CAD.AddLine(p, p2, "0").ObjectId);
				}
			}
			double num6 = (double)(checked(150 * string_0.Length)) * double_1;
			Point3d p3;
			p3..ctor(object_0[0].X, num2, 0.0);
			Point3d point3d2;
			point3d2..ctor(object_0[(int)num].X + num6, num2, 0.0);
			objectIdCollection.Add(CAD.AddLine(p3, point3d2, "0").ObjectId);
			objectIdCollection2.Add(Class36.smethod_23(CAD.GetPointXY(point3d2, -num6 + 250.0 * double_1, 90.0 * double_1), string_0, 300.0 * double_1, 0, ""));
		}
		else if (short_0 == 2)
		{
			checked
			{
				for (int j = 0; j < object_0.Length; j++)
				{
					Point3d point3d3 = object_0[j];
					ObjectIdCollection objectIdCollection4 = objectIdCollection;
					Point3d p4 = point3d3;
					Point3d p2;
					p2..ctor(point3d3.X, num2, 0.0);
					objectIdCollection4.Add(CAD.AddLine(p4, p2, "0").ObjectId);
				}
			}
			double num7 = (double)(checked(150 * string_0.Length)) * double_1;
			Point3d point3d4;
			point3d4..ctor(object_0[0].X - num7, num2, 0.0);
			Point3d p5;
			p5..ctor(object_0[(int)num].X, num2, 0.0);
			objectIdCollection.Add(CAD.AddLine(point3d4, p5, "0").ObjectId);
			objectIdCollection2.Add(Class36.smethod_23(CAD.GetPointAngle(point3d4, 100.0 * double_1, 90.0), string_0, 300.0 * double_1, 0, ""));
		}
		else if (short_0 != 3)
		{
			if (short_0 == 4)
			{
				checked
				{
					for (int k = 0; k < object_0.Length; k++)
					{
						Point3d point3d5 = object_0[k];
						ObjectIdCollection objectIdCollection5 = objectIdCollection;
						Point3d p6 = point3d5;
						Point3d p2;
						p2..ctor(point3d5.X, num4, 0.0);
						objectIdCollection5.Add(CAD.AddLine(p6, p2, "0").ObjectId);
					}
				}
				double num8 = (double)(checked(150 * string_0.Length)) * double_1;
				Point3d p7;
				p7..ctor(object_0[0].X, num4, 0.0);
				Point3d point3d6;
				point3d6..ctor(object_0[(int)num].X + num8, num4, 0.0);
				objectIdCollection.Add(CAD.AddLine(p7, point3d6, "0").ObjectId);
				objectIdCollection2.Add(Class36.smethod_23(CAD.GetPointXY(point3d6, -num8 + 200.0 * double_1, 90.0 * double_1), string_0, 300.0 * double_1, 0, ""));
			}
			else if (short_0 != 901)
			{
				if (short_0 == 902)
				{
					checked
					{
						for (int l = 0; l < object_0.Length; l++)
						{
							Point3d point3d7 = object_0[l];
							ObjectIdCollection objectIdCollection6 = objectIdCollection;
							Point3d p8 = point3d7;
							Point3d p2;
							p2..ctor(num5, point3d7.Y, 0.0);
							objectIdCollection6.Add(CAD.AddLine(p8, p2, "0").ObjectId);
						}
					}
					double num9 = (double)(checked(150 * string_0.Length)) * double_1;
					Point3d p9;
					p9..ctor(num5, object_0[0].Y, 0.0);
					Point3d point3d8;
					point3d8..ctor(num5, object_0[(int)num].Y + num9, 0.0);
					objectIdCollection.Add(CAD.AddLine(p9, point3d8, "0").ObjectId);
					objectIdCollection2.Add(Class36.smethod_57(string_0, CAD.GetPointXY(point3d8, -90.0 * double_1, -num9 + 200.0 * double_1), 300.0 * double_1, 0, 0, "STANDARD", 1.5707963267948966));
				}
				else if (short_0 == 903 || short_0 != 904)
				{
				}
			}
		}
		ObjectId objectId;
		try
		{
			foreach (object obj in objectIdCollection2)
			{
				ObjectId id = (obj != null) ? ((ObjectId)obj) : objectId;
				CAD.ChangeLayer(id, "Y_引注");
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
		try
		{
			foreach (object obj2 in objectIdCollection)
			{
				ObjectId id2 = (obj2 != null) ? ((ObjectId)obj2) : objectId;
				CAD.ChangeLayer(id2, "Y_引线");
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
		return objectIdCollection;
	}

	public static string[] smethod_84()
	{
		TcTM_frm tcTM_frm = new TcTM_frm();
		tcTM_frm.ShowDialog();
		return new string[]
		{
			tcTM_frm.ComboBox2.Text,
			tcTM_frm.ComboBox1.Text,
			Conversions.ToString(tcTM_frm.Label1.Width)
		};
	}

	public static void smethod_85(ObjectId objectId_1, double double_1)
	{
		Database workingDatabase = HostApplicationServices.WorkingDatabase;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		checked
		{
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				Entity entity = (Entity)transaction.GetObject(objectId_1, 1);
				if (entity is Curve)
				{
					Curve curve = (Curve)entity;
					try
					{
						DBObjectCollection offsetCurves = curve.GetOffsetCurves(double_1);
						int num = 0;
						int num2 = offsetCurves.Count - 1;
						int num3 = num;
						for (;;)
						{
							int num4 = num3;
							int num5 = num2;
							if (num4 > num5)
							{
								break;
							}
							CAD.AddEnt((Entity)offsetCurves[num3]);
							num3++;
						}
						transaction.Commit();
						goto IL_AB;
					}
					catch (Exception ex)
					{
						editor.WriteMessage("无法偏移！");
						goto IL_AB;
					}
				}
				editor.WriteMessage("无法偏移！");
				IL_AB:;
			}
		}
	}

	public static void smethod_86(string string_0, Point3d point3d_0, double double_1, double double_2, double double_3)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Editor editor = mdiActiveDocument.Editor;
		Database database = mdiActiveDocument.Database;
		if (!File.Exists(string_0))
		{
			string_0 = HostApplicationServices.Current.FindFile(string_0, mdiActiveDocument.Database, 0);
		}
		using (Database database2 = new Database(false, true))
		{
			database2.ReadDwgFile(string_0, FileShare.Read, true, null);
			using (DocumentLock documentLock = mdiActiveDocument.LockDocument())
			{
				using (Transaction transaction = mdiActiveDocument.TransactionManager.StartTransaction())
				{
					ObjectId objectId = mdiActiveDocument.Database.Insert(string_0, database2, false);
					BlockTable blockTable = (BlockTable)transaction.GetObject(mdiActiveDocument.Database.BlockTableId, 0);
					BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					using (BlockReference blockReference = new BlockReference(point3d_0, objectId))
					{
						blockReference.Position = point3d_0;
						blockReference.Rotation = 10.0;
						Scale3d scaleFactors;
						scaleFactors..ctor(double_1, double_2, double_3);
						blockReference.ScaleFactors = scaleFactors;
						blockTableRecord.AppendEntity(blockReference);
						transaction.AddNewlyCreatedDBObject(blockReference, true);
					}
					transaction.Commit();
					transaction.Dispose();
				}
				documentLock.Dispose();
			}
		}
	}

	public static short ZolrBmEblD(string string_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			Database database2 = new Database(false, true);
			database2.ReadDwgFile(string_0, FileShare.Read, true, null);
			ObjectId objectId = database.Insert("*U", database2, false);
			Point3d point = CAD.GetPoint("选择插入点: ");
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				BlockReference blockReference = new BlockReference(point, objectId);
				blockTableRecord.AppendEntity(blockReference);
				transaction.AddNewlyCreatedDBObject(blockReference, true);
				blockReference.ExplodeToOwnerSpace();
				blockReference.Erase();
				transaction.Commit();
				transaction.Dispose();
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
		}
		short result;
		return result;
	}

	public static short smethod_87(string string_0, Point3d point3d_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			Database database2 = new Database(false, true);
			database2.ReadDwgFile(string_0, FileShare.Read, true, null);
			ObjectId objectId = mdiActiveDocument.Database.Insert("*U", database2, false);
			using (Transaction transaction = mdiActiveDocument.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(mdiActiveDocument.Database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				BlockReference blockReference = new BlockReference(point3d_0, objectId);
				blockTableRecord.AppendEntity(blockReference);
				transaction.AddNewlyCreatedDBObject(blockReference, true);
				blockReference.ExplodeToOwnerSpace();
				blockReference.Erase();
				transaction.Commit();
				transaction.Dispose();
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
		short result;
		return result;
	}

	public static short smethod_88(Database database_0, string string_0, Point3d point3d_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			Database database2 = new Database(false, true);
			database2.ReadDwgFile(string_0, FileShare.Read, true, null);
			ObjectId objectId = database_0.Insert("*U", database2, false);
			using (Transaction transaction = mdiActiveDocument.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(mdiActiveDocument.Database.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
				BlockReference blockReference = new BlockReference(point3d_0, objectId);
				blockTableRecord.AppendEntity(blockReference);
				transaction.AddNewlyCreatedDBObject(blockReference, true);
				blockReference.ExplodeToOwnerSpace();
				blockReference.Erase();
				transaction.Commit();
				transaction.Dispose();
			}
		}
		catch (Exception ex)
		{
			Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, null);
		}
		short result;
		return result;
	}

	public static ObjectId smethod_89(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		short value;
		if (double_1 == 1.0)
		{
			value = 10;
		}
		if (double_1 == 2.0)
		{
			value = 20;
		}
		if (double_1 == 2.5)
		{
			value = 25;
		}
		if (double_1 == 4.0)
		{
			value = 40;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d3;
			point3d3..ctor(point3d2.X + 23.0 * double_1, point3d2.Y + 23.0 * double_1, 0.0);
			Point3d point3d4;
			point3d4..ctor(point3d.X - 23.0 * double_1, point3d.Y - 23.0 * double_1, 0.0);
			Point3d point3d5;
			point3d5..ctor(point3d4.X, point3d3.Y, 0.0);
			Point3d point3d6;
			point3d6..ctor(point3d3.X, point3d4.Y, 0.0);
			Point2d[] array = new Point2d[15];
			array[1]..ctor(point3d2.X - 19.09 * double_1, point3d2.Y - 51.62 * double_1);
			array[2]..ctor(point3d2.X + 16.26 * double_1, point3d2.Y - 16.26 * double_1);
			array[3]..ctor(point3d2.X, point3d2.Y + 23.0 * double_1);
			array[4]..ctor(point3d5.X + 23.0 * double_1, point3d5.Y);
			array[5]..ctor(point3d5.X, point3d5.Y - 23.0 * double_1);
			array[6]..ctor(point3d4.X, point3d4.Y + 23.0 * double_1);
			array[7]..ctor(point3d4.X + 23.0 * double_1, point3d4.Y);
			array[8]..ctor(point3d6.X - 23.0 * double_1, point3d6.Y);
			array[9]..ctor(point3d6.X, point3d6.Y + 23.0 * double_1);
			array[10]..ctor(point3d3.X, point3d3.Y - 23.0 * double_1);
			array[11]..ctor(point3d2.X - 16.26 * double_1, point3d2.Y + 16.26 * double_1);
			array[12]..ctor(point3d2.X - 51.62 * double_1, point3d2.Y - 19.09 * double_1);
			double num = Math.Tan(0.39269908169872414);
			double num2 = Math.Tan(0.58904862254808621);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			polyline.AddVertexAt(0, array[1], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(1, array[2], num2, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(2, array[3], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(3, array[4], num, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(4, array[5], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(5, array[6], num, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(6, array[7], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(7, array[8], num, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(8, array[9], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(9, array[10], num2, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(10, array[11], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(11, array[12], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			CAD.CreateLayer("墙柱小箍筋", 1, "continuous", -1, false, true);
			polyline.Layer = "墙柱小箍筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_90(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		short value;
		short value2;
		if (double_1 == 1.0)
		{
			value = 10;
			value2 = 14;
		}
		if (double_1 == 2.0)
		{
			value = 20;
			value2 = 28;
		}
		if (double_1 == 2.5)
		{
			value = 25;
			value2 = 35;
		}
		if (double_1 == 4.0)
		{
			value = 40;
			value2 = 50;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 0);
			BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
			Point3d point3d;
			point3d..ctor(Math.Min(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Min(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d point3d2;
			point3d2..ctor(Math.Max(point3d_0.get_Coordinate(0), point3d_1.get_Coordinate(0)), Math.Max(point3d_0.get_Coordinate(1), point3d_1.get_Coordinate(1)), 0.0);
			Point3d p;
			p..ctor(point3d2.X - 22.0 * double_1, point3d2.Y - 22.0 * double_1, 0.0);
			Point3d p2;
			p2..ctor(point3d.X + 22.0 * double_1, point3d.Y + 22.0 * double_1, 0.0);
			Point3d p3;
			p3..ctor(p2.X, p.Y, 0.0);
			Point3d p4;
			p4..ctor(p.X, p2.Y, 0.0);
			Class36.smethod_16(CAD.GetPointXY(p, -23.0 * double_1, -23.0 * double_1), Convert.ToDouble(new decimal((int)value2)), "墙柱纵筋");
			Class36.smethod_16(CAD.GetPointXY(p2, 23.0 * double_1, 23.0 * double_1), Convert.ToDouble(new decimal((int)value2)), "墙柱纵筋");
			Class36.smethod_16(CAD.GetPointXY(p3, 23.0 * double_1, -23.0 * double_1), Convert.ToDouble(new decimal((int)value2)), "墙柱纵筋");
			Class36.smethod_16(CAD.GetPointXY(p4, -23.0 * double_1, 23.0 * double_1), Convert.ToDouble(new decimal((int)value2)), "墙柱纵筋");
			Point2d[] array = new Point2d[15];
			array[1]..ctor(p.X - 42.09 * double_1, p.Y - 75.62 * double_1);
			array[2]..ctor(p.X - 6.73 * double_1, p.Y - 39.26 * double_1);
			array[3]..ctor(p.X - 23.0 * double_1, p.Y);
			array[4]..ctor(p3.X + 23.0 * double_1, p3.Y);
			array[5]..ctor(p3.X, p3.Y - 23.0 * double_1);
			array[6]..ctor(p2.X, p2.Y + 23.0 * double_1);
			array[7]..ctor(p2.X + 23.0 * double_1, p2.Y);
			array[8]..ctor(p4.X - 23.0 * double_1, p4.Y);
			array[9]..ctor(p4.X, p4.Y + 23.0 * double_1);
			array[10]..ctor(p.X, p.Y - 23.0 * double_1);
			array[11]..ctor(p.X - 39.26 * double_1, p.Y - 6.73 * double_1);
			array[12]..ctor(p.X - 75.62 * double_1, p.Y - 42.09 * double_1);
			double num = Math.Tan(0.39269908169872414);
			double num2 = Math.Tan(0.58904862254808621);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			polyline.AddVertexAt(0, array[1], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(1, array[2], num2, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(2, array[3], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(3, array[4], num, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(4, array[5], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(5, array[6], num, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(6, array[7], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(7, array[8], num, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(8, array[9], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(9, array[10], num2, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(10, array[11], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			polyline.AddVertexAt(11, array[12], 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			CAD.CreateLayer("墙柱大箍筋", 1, "continuous", -1, false, true);
			polyline.Layer = "墙柱大箍筋";
			blockTableRecord.AppendEntity(polyline);
			transaction.AddNewlyCreatedDBObject(polyline, true);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_91(Point3d point3d_0, Point3d point3d_1, double double_1)
	{
		short value;
		if (double_1 == 1.0)
		{
			value = 10;
		}
		if (double_1 == 2.0)
		{
			value = 20;
		}
		if (double_1 == 2.5)
		{
			value = 25;
		}
		if (double_1 == 4.0)
		{
			value = 40;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			double num = CAD.P2P_Angle(point3d_0, point3d_1);
			Point3d p = point3d_0;
			Point3d p2 = point3d_1;
			point3d_0 = CAD.GetPointAngle(p, 23.0 * double_1, num * 180.0 / 3.1415926535897931 + 90.0);
			point3d_1 = CAD.GetPointAngle(p2, 23.0 * double_1, num * 180.0 / 3.1415926535897931 + 90.0);
			Point3d pointAngle = CAD.GetPointAngle(p, 23.0 * double_1, num * 180.0 / 3.1415926535897931 - 135.0);
			Point3d pointAngle2 = CAD.GetPointAngle(p2, 23.0 * double_1, num * 180.0 / 3.1415926535897931 - 45.0);
			Point3d pointAngle3 = CAD.GetPointAngle(p, 55.03 * double_1, num * 180.0 / 3.1415926535897931 - 69.7);
			Point3d pointAngle4 = CAD.GetPointAngle(p2, 55.03 * double_1, num * 180.0 / 3.1415926535897931 - 110.3);
			Polyline polyline = new Polyline();
			polyline.SetDatabaseDefaults();
			double num2 = Math.Tan(Math.Atan(1.0) * 3.0 / 4.0);
			Polyline polyline2 = polyline;
			Point2d point2d;
			point2d..ctor(pointAngle3.get_Coordinate(0), pointAngle3.get_Coordinate(1));
			polyline2.AddVertexAt(0, point2d, 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			Polyline polyline3 = polyline;
			point2d..ctor(pointAngle.get_Coordinate(0), pointAngle.get_Coordinate(1));
			polyline3.AddVertexAt(1, point2d, -num2, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			Polyline polyline4 = polyline;
			point2d..ctor(point3d_0.get_Coordinate(0), point3d_0.get_Coordinate(1));
			polyline4.AddVertexAt(2, point2d, 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			Polyline polyline5 = polyline;
			point2d..ctor(point3d_1.get_Coordinate(0), point3d_1.get_Coordinate(1));
			polyline5.AddVertexAt(3, point2d, -num2, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			Polyline polyline6 = polyline;
			point2d..ctor(pointAngle2.get_Coordinate(0), pointAngle2.get_Coordinate(1));
			polyline6.AddVertexAt(4, point2d, 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			Polyline polyline7 = polyline;
			point2d..ctor(pointAngle4.get_Coordinate(0), pointAngle4.get_Coordinate(1));
			polyline7.AddVertexAt(5, point2d, 0.0, Convert.ToDouble(new decimal((int)value)), Convert.ToDouble(new decimal((int)value)));
			CAD.CreateLayer("墙柱拉筋", 1, "continuous", -1, false, true);
			polyline.Layer = "墙柱拉筋";
			CAD.AddEnt(polyline);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static ObjectId smethod_92(object object_0)
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		ObjectId objectId;
		using (Transaction transaction = database.TransactionManager.StartTransaction())
		{
			double startWidthAt = object_0.GetStartWidthAt(0);
			Point2dCollection point2dCollection = new Point2dCollection();
			short num;
			Class36.Struct20[] array;
			short num3;
			short num4;
			checked
			{
				num = (short)(object_0.NumberOfVertices - 1);
				array = new Class36.Struct20[(int)(num + 1)];
				short num2 = 0;
				num3 = num;
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
				point2dCollection.Add(object_0.GetPoint2dAt((int)num4));
				array[(int)num4].point2d_0 = object_0.GetPoint2dAt((int)num4);
				array[(int)num4].double_0 = object_0.GetBulgeAt((int)num4);
				array[(int)num4].double_1 = object_0.GetStartWidthAt((int)num4);
				array[(int)num4].double_2 = object_0.GetEndWidthAt((int)num4);
				num4 += 1;
			}
			short num7 = 1;
			short num8 = 1;
			Polyline polyline;
			short num29;
			short num30;
			checked
			{
				short num9 = num - 1;
				short num10 = num8;
				for (;;)
				{
					short num11 = num10;
					short num6 = num9;
					if (num11 > num6)
					{
						break;
					}
					Point3d point3d;
					point3d..ctor(point2dCollection[(int)(num10 - 1)].X, point2dCollection[(int)(num10 - 1)].Y, 0.0);
					Point3d p_Start = point3d;
					Point3d point3d2;
					point3d2..ctor(point2dCollection[(int)num10].X, point2dCollection[(int)num10].Y, 0.0);
					double num12 = CAD.P2P_AngleV(p_Start, point3d2);
					point3d2..ctor(point2dCollection[(int)(num10 + 1)].X, point2dCollection[(int)(num10 + 1)].Y, 0.0);
					Point3d p_Start2 = point3d2;
					point3d..ctor(point2dCollection[(int)num10].X, point2dCollection[(int)num10].Y, 0.0);
					double num13 = CAD.P2P_AngleV(p_Start2, point3d);
					unchecked
					{
						double num14 = Math.Abs(3.1415926535897931 - Math.Abs(Math.Abs(num12) - Math.Abs(num13)));
						if (num12 != num13)
						{
							double num15 = point2dCollection[(int)num10].X - point2dCollection[(int)(checked(num10 - 1))].X;
							double num16 = point2dCollection[(int)num10].Y - point2dCollection[(int)(checked(num10 - 1))].Y;
							double num17 = point2dCollection[(int)(checked(num10 + 1))].X - point2dCollection[(int)num10].X;
							double num18 = point2dCollection[(int)(checked(num10 + 1))].Y - point2dCollection[(int)num10].Y;
							double num19 = num15 * num18 - num16 * num17;
							double double_;
							if (num19 < 0.0)
							{
								double_ = -Math.Tan(num14 / 4.0);
							}
							else
							{
								double_ = Math.Tan(num14 / 4.0);
							}
							double distAtPoint;
							double num25;
							Point2d point2d_;
							checked
							{
								short num20 = (short)Information.UBound(array, 1);
								array = (Class36.Struct20[])Utils.CopyArray((Array)array, new Class36.Struct20[(int)(num20 + 1 + 1)]);
								short num21 = num20 + 1;
								short num22 = unchecked(num10 + num7) + 1;
								short num23 = num21;
								for (;;)
								{
									short num24 = num23;
									num6 = num22;
									if (num24 < num6)
									{
										break;
									}
									array[(int)num23] = array[(int)(num23 - 1)];
									unchecked
									{
										num23 += -1;
									}
								}
								point3d2..ctor(point2dCollection[(int)num10].X, point2dCollection[(int)num10].Y, 0.0);
								distAtPoint = object_0.GetDistAtPoint(point3d2);
								num25 = point2dCollection[(int)num10].GetDistanceTo(point2dCollection[(int)(num10 + 1)]);
								point2d_ = point2dCollection[(int)num10];
								double distanceTo = point2d_.GetDistanceTo(point2dCollection[(int)(num10 - 1)]);
								num25 = Math.Min(num25, distanceTo);
								num25 = Math.Min(num25, startWidthAt);
							}
							Point3d pointAtDist = object_0.GetPointAtDist(distAtPoint - num25);
							Point3d pointAtDist2 = object_0.GetPointAtDist(distAtPoint + num25);
							Class36.Struct20[] array2 = array;
							int num26 = (int)(checked(unchecked(num10 + num7) - 1));
							point2d_..ctor(pointAtDist.X, pointAtDist.Y);
							array2[num26] = Class36.smethod_93(point2d_, double_, startWidthAt, startWidthAt);
							Class36.Struct20[] array3 = array;
							int num27 = (int)(num10 + num7);
							point2d_..ctor(pointAtDist2.X, pointAtDist2.Y);
							array3[num27] = Class36.smethod_93(point2d_, 0.0, startWidthAt, startWidthAt);
							checked
							{
								num7 += 1;
							}
						}
						num10 += 1;
					}
				}
				polyline = new Polyline();
				short num28 = 0;
				num29 = (short)(array.Length - 1);
				num30 = num28;
			}
			for (;;)
			{
				short num31 = num30;
				short num6 = num29;
				if (num31 > num6)
				{
					break;
				}
				polyline.AddVertexAt((int)num30, array[(int)num30].point2d_0, array[(int)num30].double_0, array[(int)num30].double_1, array[(int)num30].double_2);
				num30 += 1;
			}
			polyline.Layer = object_0.Layer;
			CAD.AddEnt(polyline);
			transaction.Commit();
			objectId = polyline.ObjectId;
		}
		return objectId;
	}

	public static Class36.Struct20 smethod_93(Point2d point2d_0, double double_1, double double_2, double double_3)
	{
		Class36.Struct20 result;
		result.point2d_0 = point2d_0;
		result.double_0 = double_1;
		result.double_1 = double_2;
		result.double_2 = double_3;
		return result;
	}

	public const int int_0 = 160;

	public const int int_1 = 17;

	public static ObjectId objectId_0;

	public static double double_0;

	public static object TjurCgqsmJ;

	public struct Struct20
	{
		public short short_0;

		public Point2d point2d_0;

		public double double_0;

		public double double_1;

		public double double_2;
	}
}
