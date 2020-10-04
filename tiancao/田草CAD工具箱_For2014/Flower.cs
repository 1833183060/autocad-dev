using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class Flower
	{
		[DebuggerNonUserCode]
		public Flower()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcFlower")]
		public void TcFlower()
		{
			float[] array = new float[3];
			float[] array2 = new float[3];
			float[] array3 = new float[3];
			object obj = 3.1415926535897931;
			object obj2 = 400;
			object obj3 = 300;
			object obj4 = 30;
			ColorRGB colorRGB;
			colorRGB..ctor(255.0, 0.0, 0.0);
			this.flower(RuntimeHelpers.GetObjectValue(obj4), RuntimeHelpers.GetObjectValue(obj2), RuntimeHelpers.GetObjectValue(obj3), RuntimeHelpers.GetObjectValue(obj), colorRGB);
			array[0] = 7f;
			array2[0] = 43.6f;
			array3[0] = 24.5f;
			array[1] = 17f;
			array2[1] = 77.5f;
			array3[1] = 18f;
			array[2] = 31f;
			array2[2] = 102f;
			array3[2] = 13f;
			object value = 0;
			VBMath.Randomize(Conversions.ToDouble(value));
			short num = 0;
			do
			{
				object right = array[(int)num];
				object left = array2[(int)num];
				obj4 = array3[(int)num];
				float num2;
				if (num == 2)
				{
					num2 = Conversions.ToSingle(Operators.DivideObject(Operators.MultiplyObject(2, obj), right));
				}
				else
				{
					num2 = 0f;
				}
				float num3 = 0f;
				float num4 = Conversions.ToSingle(Operators.SubtractObject(Operators.MultiplyObject(2, obj), num2));
				float num5 = Conversions.ToSingle(Operators.DivideObject(Operators.MultiplyObject(2, obj), right));
				float limit = num4;
				float num6 = num3;
				while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num6, limit, num5))
				{
					float num7 = Conversions.ToSingle(Operators.AddObject(obj2, Operators.MultiplyObject(left, Math.Cos((double)num6))));
					float num8 = Conversions.ToSingle(Operators.AddObject(obj3, Operators.MultiplyObject(left, Math.Sin((double)num6))));
					colorRGB..ctor(255.0, 255.0, 0.0);
					this.flower(RuntimeHelpers.GetObjectValue(obj4), num7, num8, RuntimeHelpers.GetObjectValue(obj), colorRGB);
					num6 += num5;
				}
				num += 1;
			}
			while (num <= 2);
			Point3d p = default(Point3d);
			Point3d point3d = default(Point3d);
			float num9 = 0f;
			float num10 = Conversions.ToSingle(Operators.MultiplyObject(14, obj));
			float num11 = Conversions.ToSingle(Operators.DivideObject(obj, 60));
			float limit2 = num10;
			float num12 = num9;
			while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num12, limit2, num11))
			{
				float num13 = Conversions.ToSingle(Operators.AddObject(obj2, 144.0 * (1.0 + 0.2 * Math.Sin(9.06 * (double)num12)) * Math.Cos((double)num12)));
				float num14 = Conversions.ToSingle(Operators.AddObject(obj3, 144.0 * (1.0 + 0.2 * Math.Sin(9.06 * (double)num12)) * Math.Sin((double)num12)));
				if (num12 == 0f)
				{
					p..ctor((double)num13, (double)num14, 0.0);
					Point3d p2;
					p2..ctor((double)num13, (double)num14, 0.0);
					CAD.AddPoint(p2);
				}
				else
				{
					point3d..ctor((double)num13, (double)num14, 0.0);
					CAD.AddLine(p, point3d, "0");
					p..ctor((double)num13, (double)num14, 0.0);
					p = point3d;
				}
				num12 += num11;
			}
		}

		public void flower(object r, object px, object py, object pi, object col)
		{
			object obj = checked((int)Math.Round((double)(unchecked(8f - VBMath.Rnd(1f) * 5f))));
			short num;
			if (Operators.ConditionalCompareObjectEqual(Operators.ModObject(obj, 2), 0, false))
			{
				num = 2;
			}
			else
			{
				num = 1;
			}
			Point3d p = default(Point3d);
			Point3d point3d = default(Point3d);
			float num2 = 0f;
			float num3 = Conversions.ToSingle(Operators.AddObject(Operators.MultiplyObject(num, pi), Operators.DivideObject(pi, Operators.MultiplyObject(10, obj))));
			float num4 = Conversions.ToSingle(Operators.DivideObject(pi, Operators.MultiplyObject(15, obj)));
			float limit = num3;
			float num5 = num2;
			while (ObjectFlowControl.ForLoopControl.ForNextCheckR4(num5, limit, num4))
			{
				float num6 = Conversions.ToSingle(Operators.AddObject(Operators.MultiplyObject(Operators.AddObject(Operators.MultiplyObject(Operators.DivideObject(r, 4), Math.Sin(Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject(3, obj), num5)))), Operators.MultiplyObject(r, Math.Sin(Conversions.ToDouble(Operators.MultiplyObject(obj, num5))))), Math.Cos((double)num5)), px));
				float num7 = Conversions.ToSingle(Operators.AddObject(Operators.MultiplyObject(Operators.AddObject(Operators.MultiplyObject(Operators.DivideObject(r, 4), Math.Sin(Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject(3, obj), num5)))), Operators.MultiplyObject(r, Math.Sin(Conversions.ToDouble(Operators.MultiplyObject(obj, num5))))), Math.Sin((double)num5)), py));
				if (num5 == 0f)
				{
					Point3d p2;
					p2..ctor((double)num6, (double)num7, 0.0);
					CAD.AddPoint(p2);
					p..ctor((double)num6, (double)num7, 0.0);
				}
				else
				{
					point3d..ctor((double)num6, (double)num7, 0.0);
					CAD.AddLine(p, point3d, "0");
					p..ctor((double)num6, (double)num7, 0.0);
					p = point3d;
				}
				num5 += num4;
			}
		}
	}
}
