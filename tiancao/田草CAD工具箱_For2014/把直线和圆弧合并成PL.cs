using System;
using System.Collections;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 把直线和圆弧合并成PL
	{
		[DebuggerNonUserCode]
		public 把直线和圆弧合并成PL()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcToPL")]
		public void TcToPL()
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "Line,Arc");
			array2.SetValue(typedValue, 0);
			SelectionFilter selectionFilter = new SelectionFilter(array);
			PromptSelectionResult selection = editor.GetSelection(new PromptSelectionOptions
			{
				MessageForAdding = "选择线与圆弧"
			}, selectionFilter);
			if (selection.Status == 5100 && selection.Value != null)
			{
				SelectionSet value = selection.Value;
				ObjectId[] objectIds = value.GetObjectIds();
				ObjectIdCollection objectIdCollection = new ObjectIdCollection();
				foreach (ObjectId objectId in objectIds)
				{
					objectIdCollection.Add(objectId);
				}
				if (objectIdCollection.Count > 1)
				{
					this.method_0(objectIdCollection);
					foreach (ObjectId objectId2 in objectIds)
					{
						Database workingDatabase = HostApplicationServices.WorkingDatabase;
						using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
						{
							Entity entity = (Entity)transaction.GetObject(objectId2, 1, false);
							entity.Erase();
							transaction.Commit();
						}
					}
				}
			}
			documentLock.Dispose();
		}

		private void method_0(ObjectIdCollection objectIdCollection_0)
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Polyline polyline = new Polyline();
			bool flag = true;
			string layer = "";
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				Entity entity = (Entity)transaction.GetObject(objectIdCollection_0[0], 0);
				layer = entity.Layer;
				goto IL_4BB;
			}
			IL_6A:
			checked
			{
				try
				{
					foreach (object obj in objectIdCollection_0)
					{
						ObjectId objectId2;
						ObjectId objectId = (obj != null) ? ((ObjectId)obj) : objectId2;
						using (Transaction transaction2 = workingDatabase.TransactionManager.StartTransaction())
						{
							Curve curve = (Curve)transaction2.GetObject(objectId, 1, false);
							string name = curve.GetType().Name;
							if (polyline.NumberOfVertices == 0)
							{
								if (Operators.CompareString(name, "Arc", false) == 0)
								{
									polyline.AddVertexAt(0, curve.StartPoint.Convert2d(new Plane()), this.method_1((Arc)curve, true), 0.0, 0.0);
								}
								else
								{
									polyline.AddVertexAt(0, curve.StartPoint.Convert2d(new Plane()), 0.0, 0.0, 0.0);
								}
								polyline.AddVertexAt(1, curve.EndPoint.Convert2d(new Plane()), 0.0, 0.0, 0.0);
								objectIdCollection_0.Remove(objectId);
								flag = true;
								break;
							}
							if (curve.StartPoint.DistanceTo(polyline.GetPoint3dAt(0)) <= 1.0)
							{
								if (Operators.CompareString(name, "Arc", false) == 0)
								{
									polyline.AddVertexAt(0, curve.EndPoint.Convert2d(new Plane()), this.method_1((Arc)curve, false), 0.0, 0.0);
								}
								else
								{
									polyline.AddVertexAt(0, curve.EndPoint.Convert2d(new Plane()), 0.0, 0.0, 0.0);
								}
								objectIdCollection_0.Remove(objectId);
								flag = true;
								break;
							}
							if (curve.EndPoint.DistanceTo(polyline.GetPoint3dAt(0)) <= 1.0)
							{
								if (Operators.CompareString(name, "Arc", false) == 0)
								{
									polyline.AddVertexAt(0, curve.StartPoint.Convert2d(new Plane()), this.method_1((Arc)curve, true), 0.0, 0.0);
								}
								else
								{
									polyline.AddVertexAt(0, curve.StartPoint.Convert2d(new Plane()), 0.0, 0.0, 0.0);
								}
								objectIdCollection_0.Remove(objectId);
								flag = true;
								break;
							}
							if (curve.StartPoint.DistanceTo(polyline.GetPoint3dAt(polyline.NumberOfVertices - 1)) <= 1.0)
							{
								if (Operators.CompareString(name, "Arc", false) == 0)
								{
									polyline.SetBulgeAt(polyline.NumberOfVertices - 1, this.method_1((Arc)curve, true));
								}
								polyline.AddVertexAt(polyline.NumberOfVertices, curve.EndPoint.Convert2d(new Plane()), 0.0, 0.0, 0.0);
								objectIdCollection_0.Remove(objectId);
								flag = true;
								break;
							}
							if (curve.EndPoint.DistanceTo(polyline.GetPoint3dAt(polyline.NumberOfVertices - 1)) <= 1.0)
							{
								if (Operators.CompareString(name, "Arc", false) == 0)
								{
									polyline.SetBulgeAt(polyline.NumberOfVertices - 1, this.method_1((Arc)curve, false));
								}
								polyline.AddVertexAt(polyline.NumberOfVertices, curve.StartPoint.Convert2d(new Plane()), 0.0, 0.0, 0.0);
								objectIdCollection_0.Remove(objectId);
								flag = true;
								break;
							}
							flag = false;
							transaction2.Commit();
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
				if (objectIdCollection_0.Count < 1)
				{
					flag = false;
				}
				IL_4BB:
				if (!flag)
				{
					polyline.Layer = layer;
					CAD.AddEnt(polyline);
					if (objectIdCollection_0.Count > 0)
					{
						this.method_0(objectIdCollection_0);
					}
					return;
				}
				goto IL_6A;
			}
		}

		private double method_1(Arc arc_0, bool bool_0)
		{
			double length = arc_0.StartPoint.GetVectorTo(arc_0.EndPoint).Length;
			double num = arc_0.EndAngle - arc_0.StartAngle;
			if (num < 0.0)
			{
				num = 6.2831853071795862 + num;
			}
			double num2;
			if (num > 3.1415926535897931)
			{
				num2 = arc_0.Radius + Math.Sqrt(Math.Pow(arc_0.Radius, 2.0) - Math.Pow(length / 2.0, 2.0));
			}
			else
			{
				num2 = arc_0.Radius - Math.Sqrt(Math.Pow(arc_0.Radius, 2.0) - Math.Pow(length / 2.0, 2.0));
			}
			Point3d pointAtDist = arc_0.GetPointAtDist(arc_0.GetDistanceAtParameter(arc_0.EndParam) / 2.0);
			double num3;
			if (bool_0)
			{
				num3 = 把直线和圆弧合并成PL.smethod_0(arc_0.StartPoint, pointAtDist, arc_0.EndPoint);
			}
			else
			{
				num3 = 把直线和圆弧合并成PL.smethod_0(arc_0.EndPoint, pointAtDist, arc_0.StartPoint);
			}
			double result;
			if (num3 > 0.0)
			{
				result = -num2 / (length / 2.0);
			}
			else if (num3 < 0.0)
			{
				result = num2 / (length / 2.0);
			}
			return result;
		}

		private static double smethod_0(Point3d point3d_0, Point3d point3d_1, Point3d point3d_2)
		{
			Vector3d vectorTo = point3d_0.GetVectorTo(point3d_1);
			Vector3d vectorTo2 = point3d_0.GetVectorTo(point3d_2);
			return vectorTo2.X * vectorTo.Y - vectorTo.X * vectorTo2.Y;
		}
	}
}
