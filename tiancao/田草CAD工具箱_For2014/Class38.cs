using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

internal class Class38
{
	static Class38()
	{
		Class39.k1QjQlczC5Jf5();
		Class38.point3dCollection_0 = null;
	}

	public Class38(Point3dCollection point3dCollection_2)
	{
		Class39.k1QjQlczC5Jf5();
		base..ctor();
		this.point3dCollection_1 = new Point3dCollection();
		Class38.point3dCollection_0 = point3dCollection_2;
	}

	public void method_0()
	{
		Point3dCollection source = Class38.point3dCollection_0;
		Point3d[] array = new Point3d[0];
		array = (from Point3d point3d_0 in source
		orderby point3d_0.X
		select point3d_0).ToArray<Point3d>();
		Point3d P0 = array[0];
		Point3d[] array2 = new Point3d[0];
		array2 = (from Point3d point in array
		orderby Class38.smethod_0(P0, point)
		select point).ToArray<Point3d>();
		this.point3dCollection_1.Add(array2[0]);
		this.point3dCollection_1.Add(array2[1]);
		this.point3dCollection_1.Add(array2[2]);
		int i = 3;
		checked
		{
			while (i < array2.Length)
			{
				if (Class38.smethod_1(array2[i], this.point3dCollection_1[this.point3dCollection_1.Count - 2], this.point3dCollection_1[this.point3dCollection_1.Count - 1]))
				{
					this.point3dCollection_1.Add(array2[i]);
				}
				else
				{
					this.point3dCollection_1.RemoveAt(this.point3dCollection_1.Count - 1);
					Math.Max(Interlocked.Decrement(ref i), i + 1);
				}
				Math.Max(Interlocked.Increment(ref i), i - 1);
			}
			Class38.smethod_2(this.point3dCollection_1);
		}
	}

	public static double smethod_0(Point3d point3d_0, Point3d point3d_1)
	{
		double num = point3d_1.X - point3d_0.X;
		double num2 = point3d_1.Y - point3d_0.Y;
		double num3 = point3d_1.Z - point3d_0.Z;
		return Math.Acos(-num2 / Math.Sqrt(num * num + num2 * num2 + num3 * num3));
	}

	public static bool smethod_1(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
	{
		double num = (point3d_2.X - point3d_1.X) * (point3d_0.Y - point3d_1.Y) - (point3d_0.X - point3d_1.X) * (point3d_2.Y - point3d_1.Y);
		return num > 0.0;
	}

	public static Polyline smethod_2(Point3dCollection point3dCollection_2)
	{
		Database workingDatabase = HostApplicationServices.WorkingDatabase;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Polyline result;
		using (Application.DocumentManager.MdiActiveDocument.LockDocument())
		{
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, 0);
				BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(workingDatabase.CurrentSpaceId, 1);
				Polyline polyline = new Polyline();
				int num = 0;
				try
				{
					foreach (object obj in point3dCollection_2)
					{
						Point3d point3d2;
						Point3d point3d = (obj != null) ? ((Point3d)obj) : point3d2;
						Polyline polyline2 = polyline;
						int num2 = num;
						Point2d point2d;
						point2d..ctor(point3d.X, point3d.Y);
						polyline2.AddVertexAt(num2, point2d, 0.0, 0.0, 0.0);
						Math.Max(Interlocked.Increment(ref num), checked(num - 1));
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
				polyline.Closed = true;
				blockTableRecord.AppendEntity(polyline);
				transaction.AddNewlyCreatedDBObject(polyline, true);
				transaction.Commit();
				result = polyline;
			}
		}
		return result;
	}

	[CompilerGenerated]
	private static double _Lambda$__4(Point3d point3d_0)
	{
		return point3d_0.X;
	}

	public static Point3dCollection point3dCollection_0;

	public Point3dCollection point3dCollection_1;

	[CompilerGenerated]
	internal class _Closure$__2
	{
		[DebuggerNonUserCode]
		public _Closure$__2()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[DebuggerNonUserCode]
		public _Closure$__2(Class38._Closure$__2 other)
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			if (other != null)
			{
				this.$VB$Local_P0 = other.$VB$Local_P0;
			}
		}

		[CompilerGenerated]
		public double _Lambda$__5(Point3d point)
		{
			return Class38.smethod_0(this.$VB$Local_P0, point);
		}

		public Point3d $VB$Local_P0;
	}
}
