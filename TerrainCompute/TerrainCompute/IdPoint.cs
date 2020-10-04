using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class IdPoint : IComparable<IdPoint>
	{
		public IdPoint(DBPoint dbPoint)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdPoint));
			this.objectId_0 = ObjectId.Null;
			this.bool_1 = true;
			//base..ctor();
			this.dbpoint_0 = dbPoint;
			this.objectId_0 = this.dbpoint_0.ObjectId;
			this.point_0 = new Point(dbPoint.Position.X, dbPoint.Position.Y, dbPoint.Position.Z);
		}

		public IdPoint(Point point, ObjectId id)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdPoint));
			this.objectId_0 = ObjectId.Null;
			this.bool_1 = true;
			//base..ctor();
			this.point_0 = point;
			this.objectId_0 = id;
		}

		public IdPoint(Point point, DBPoint dbPoint)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(IdPoint));
			this.objectId_0 = ObjectId.Null;
			this.bool_1 = true;
			//base..ctor();
			this.point_0 = point;
			this.dbpoint_0 = dbPoint;
			if (this.dbpoint_0 != null)
			{
				this.objectId_0 = this.dbpoint_0.ObjectId;
			}
		}

		public int CompareTo(IdPoint point)
		{
			if (this.point_0.X != point.point_0.X)
			{
				return this.point_0.X.CompareTo(point.point_0.X);
			}
			if (this.point_0.Y != point.point_0.Y)
			{
				return this.point_0.Y.CompareTo(point.point_0.Y);
			}
			return this.point_0.Z.CompareTo(point.point_0.Z);
		}

		public static void EraseDublicates2d(ObjectId[] pointIDs, double epsilon, string keepMultiple, ref int numberOfPointsErased)
		{
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ProgressMeter progressMeter = new ProgressMeter();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			IComparer<IdPoint> comparer = new Class2();
			double num = epsilon * epsilon;
			try
			{
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					CoordinateSystem ceometricUcs = Conversions.GetCeometricUcs();
					CoordinateSystem actualCS = CoordinateSystem.Global();
					CoordinateTransformator coordinateTransformator = new CoordinateTransformator(actualCS, ceometricUcs);
					List<IdPoint> list = new List<IdPoint>();
					for (int i = 0; i < pointIDs.Length; i++)
					{
                        DBPoint dbPoint = (DBPoint)transaction.GetObject(pointIDs[i], (OpenMode)1, true);
						IdPoint idPoint = new IdPoint(dbPoint);
						coordinateTransformator.Transform(idPoint.Point);
						list.Add(idPoint);
					}
					list.Sort(comparer);
					List<IdPoint> list2 = new List<IdPoint>();
					for (int j = 0; j < list.Count; j++)
					{
						list2.Add(list[j]);
					}
					if (keepMultiple == "H")
					{
						list.Reverse();
					}
					progressMeter.SetLimit(list.Count);
					if ((double)list.Count > 10000.0)
					{
						progressMeter.Start("Eliminating points");
					}
					for (int k = 0; k < list.Count; k++)
					{
						progressMeter.MeterProgress();
						messageFilter.CheckMessageFilter((long)k, 1000);
						IdPoint idPoint2 = list[k];
						if (!idPoint2.IsErased)
						{
							Point point = new Point(idPoint2.Point.X - epsilon, -1.7976931348623157E+308, -1.7976931348623157E+308);
							Point point2 = new Point(idPoint2.Point.X + epsilon, 1.7976931348623157E+308, 1.7976931348623157E+308);
							IdPoint item = new IdPoint(point, ObjectId.Null);
							IdPoint item2 = new IdPoint(point2, ObjectId.Null);
							int num2 = list2.BinarySearch(item, comparer);
							int num3 = list2.BinarySearch(item2, comparer);
							if (num2 < 0)
							{
								num2 = Math.Abs(num2) - 2;
							}
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 >= list.Count)
							{
								num2 = list.Count - 1;
							}
							if (num3 < 0)
							{
								num3 = Math.Abs(num3) - 1;
							}
							if (num3 < 0)
							{
								num3 = 0;
							}
							if (num3 >= list.Count)
							{
								num3 = list.Count - 1;
							}
							for (int l = num2; l <= num3; l++)
							{
								if (!list2[l].IsErased && list2[l] != idPoint2 && IdPoint.smethod_0(idPoint2.Point, list2[l].Point) < num)
								{
									list2[l].IsErased = true;
									list2[l].DBPoint.Erase();
									numberOfPointsErased++;
								}
							}
						}
					}
					transaction.Commit();
				}
				progressMeter.Stop();
			}
			catch
			{
				progressMeter.Stop();
				throw;
			}
		}

		public static ObjectId[] GetDublicates2d(List<IdPoint> points, double epsilon)
		{
			List<ObjectId> list = new List<ObjectId>();
			List<IdPoint> list2 = new List<IdPoint>();
			new List<IdPoint>();
			IComparer<IdPoint> comparer = new Class2();
			new Class3();
			new Class4();
			double num = epsilon * epsilon;
			for (int i = 0; i < points.Count; i++)
			{
				list2.Add(points[i]);
			}
			points.Sort(comparer);
			points.Reverse();
			ProgressMeter progressMeter = new ProgressMeter();
			progressMeter.SetLimit(points.Count / 10);
			try
			{
				progressMeter.Start("Eliminating points");
				list2.Sort(comparer);
				for (int j = 0; j < points.Count; j++)
				{
					if (j % 10 == 0)
					{
						progressMeter.MeterProgress();
					}
					IdPoint idPoint = points[j];
					if (!idPoint.IsErased)
					{
						Point point = new Point(idPoint.Point.X - epsilon, -1.7976931348623157E+308, -1.7976931348623157E+308);
						Point point2 = new Point(idPoint.Point.X + epsilon, 1.7976931348623157E+308, 1.7976931348623157E+308);
						IdPoint item = new IdPoint(point, ObjectId.Null);
						IdPoint item2 = new IdPoint(point2, ObjectId.Null);
						int num2 = list2.BinarySearch(item, comparer);
						int num3 = list2.BinarySearch(item2, comparer);
						if (num2 < 0)
						{
							num2 = Math.Abs(num2) - 2;
						}
						if (num2 < 0)
						{
							num2 = 0;
						}
						if (num2 >= points.Count)
						{
							num2 = points.Count - 1;
						}
						if (num3 < 0)
						{
							num3 = Math.Abs(num3) - 1;
						}
						if (num3 < 0)
						{
							num3 = 0;
						}
						if (num3 >= points.Count)
						{
							num3 = points.Count - 1;
						}
						for (int k = num2; k <= num3; k++)
						{
							if (!list2[k].IsErased && list2[k] != idPoint && IdPoint.smethod_0(idPoint.Point, list2[k].Point) < num)
							{
								list2[k].IsErased = true;
							}
						}
					}
				}
				for (int l = 0; l < points.Count; l++)
				{
					if (points[l].IsErased)
					{
						list.Add(points[l].ID);
					}
				}
			}
			catch
			{
				progressMeter.Stop();
				throw;
			}
			progressMeter.Stop();
			return list.ToArray();
		}

		private static double smethod_0(Point point_1, Point point_2)
		{
			double num = point_1.X - point_2.X;
			double num2 = point_1.Y - point_2.Y;
			return num * num + num2 * num2;
		}

		public override string ToString()
		{
			string text = this.point_0.ToString();
			text += Environment.NewLine;
			if (this.objectId_0 == ObjectId.Null)
			{
				text += "Object ID: null";
			}
			else
			{
				text = text + "Object ID: " + this.objectId_0.ToString();
			}
			text += Environment.NewLine;
			text = text + "Erased   : " + this.objectId_0.ToString();
			text += Environment.NewLine;
			if (this.dbpoint_0 == null)
			{
				return text + "DBPoint  : null";
			}
			string text2 = text;
			return string.Concat(new string[]
			{
				text2,
				"DBPoint  : ",
				this.dbpoint_0.Position.X.ToString(),
				", ",
				this.dbpoint_0.Position.Y.ToString(),
				", ",
				this.dbpoint_0.Position.Z.ToString()
			});
		}

		public DBPoint DBPoint
		{
			get
			{
				return this.dbpoint_0;
			}
			set
			{
				this.dbpoint_0 = value;
			}
		}

		public DBPoint DBPoint2
		{
			get
			{
				return this.dbpoint_1;
			}
			set
			{
				this.dbpoint_1 = value;
			}
		}

		public ObjectId ID
		{
			get
			{
				return this.objectId_0;
			}
			set
			{
				this.objectId_0 = value;
			}
		}

		public bool IsErased
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public bool IsValid
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		public Point Point
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
			}
		}

		private bool bool_0;

		private bool bool_1;

		private DBPoint dbpoint_0;

		private DBPoint dbpoint_1;

		private ObjectId objectId_0;

		private Point point_0;
	}
}
