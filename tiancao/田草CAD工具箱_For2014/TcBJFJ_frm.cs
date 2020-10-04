using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TcBJFJ_frm : Form
	{
		[DebuggerNonUserCode]
		static TcBJFJ_frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcBJFJ_frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public TcBJFJ_frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.FormClosing += this.TcBJFJ_frm_FormClosing;
			base.Load += this.TcBJFJ_frm_Load;
			TcBJFJ_frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcBJFJ_frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcBJFJ_frm.list_0.Count == TcBJFJ_frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcBJFJ_frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcBJFJ_frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcBJFJ_frm.list_0[num] = TcBJFJ_frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcBJFJ_frm.list_0.RemoveRange(num, TcBJFJ_frm.list_0.Count - num);
						TcBJFJ_frm.list_0.Capacity = TcBJFJ_frm.list_0.Count;
					}
					TcBJFJ_frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual Button Button1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button1_Click);
				if (this._Button1 != null)
				{
					this._Button1.Click -= value2;
				}
				this._Button1 = value;
				if (this._Button1 != null)
				{
					this._Button1.Click += value2;
				}
			}
		}

		internal virtual TextBox TextBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox1 = value;
			}
		}

		internal virtual TextBox TextBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox2 = value;
			}
		}

		internal virtual Label Label1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label1 = value;
			}
		}

		internal virtual Label Label2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label2 = value;
			}
		}

		internal virtual Button Button2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button2_Click);
				if (this._Button2 != null)
				{
					this._Button2.Click -= value2;
				}
				this._Button2 = value;
				if (this._Button2 != null)
				{
					this._Button2.Click += value2;
				}
			}
		}

		internal virtual TextBox TextBox3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox3_TextChanged);
				if (this._TextBox3 != null)
				{
					this._TextBox3.TextChanged -= value2;
				}
				this._TextBox3 = value;
				if (this._TextBox3 != null)
				{
					this._TextBox3.TextChanged += value2;
				}
			}
		}

		internal virtual ComboBox ComboBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ComboBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ComboBox1_SelectedIndexChanged);
				if (this._ComboBox1 != null)
				{
					this._ComboBox1.SelectedIndexChanged -= value2;
				}
				this._ComboBox1 = value;
				if (this._ComboBox1 != null)
				{
					this._ComboBox1.SelectedIndexChanged += value2;
				}
			}
		}

		internal virtual TextBox TextBox4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox4 = value;
			}
		}

		internal virtual TextBox TextBox5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox5 = value;
			}
		}

		internal virtual Button Button3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button3_Click);
				if (this._Button3 != null)
				{
					this._Button3.Click -= value2;
				}
				this._Button3 = value;
				if (this._Button3 != null)
				{
					this._Button3.Click += value2;
				}
			}
		}

		internal virtual RadioButton RadioButton1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton1 = value;
			}
		}

		internal virtual RadioButton RadioButton2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._RadioButton2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._RadioButton2 = value;
			}
		}

		internal virtual CheckBox CheckBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._CheckBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._CheckBox1 = value;
			}
		}

		internal virtual TextBox TextBox6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.TextBox6_TextChanged);
				if (this._TextBox6 != null)
				{
					this._TextBox6.TextChanged -= value2;
				}
				this._TextBox6 = value;
				if (this._TextBox6 != null)
				{
					this._TextBox6.TextChanged += value2;
				}
			}
		}

		internal virtual Label Label3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Label3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Label3 = value;
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			int num;
			int num6;
			object obj4;
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_32:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_3B:
				num2 = 5;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_4E:
				num2 = 6;
				this.objectIdCollection_0 = new ObjectIdCollection();
				IL_5B:
				num2 = 7;
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
							string text = JG.HRB(dbtext.TextString);
							if (text.Contains("@"))
							{
								if (this.RadioButton2.Checked)
								{
									if (TcBJFJ_frm.GetBJAS(text) <= this.long_0)
									{
										DBObjectCollection dbobjectCollection = new DBObjectCollection();
										double num3 = dbtext.Rotation;
										if (num3 > 6.2831853071795862)
										{
											num3 -= 6.2831853071795862;
										}
										TcBJFJ_frm.GetFuJinDBText(dbtext, dbtext.Height * 3.0, "楼板负筋标注", num3, ref dbobjectCollection);
										IEnumerator enumerator2 = dbobjectCollection.GetEnumerator();
										while (enumerator2.MoveNext())
										{
											object obj2 = enumerator2.Current;
											DBText dbtext2 = (DBText)obj2;
											Class36.smethod_64(dbtext2.ObjectId);
										}
										if (enumerator2 is IDisposable)
										{
											(enumerator2 as IDisposable).Dispose();
										}
										dbobjectCollection = new DBObjectCollection();
										TcBJFJ_frm.GetFuJinPL(dbtext, dbtext.Height * 2.0, "楼板负筋钢筋", num3, ref dbobjectCollection);
										IEnumerator enumerator3 = dbobjectCollection.GetEnumerator();
										while (enumerator3.MoveNext())
										{
											object obj3 = enumerator3.Current;
											Polyline polyline = (Polyline)obj3;
											Class36.smethod_64(polyline.ObjectId);
										}
										if (enumerator3 is IDisposable)
										{
											(enumerator3 as IDisposable).Dispose();
										}
										dbtext.Erase();
									}
									else
									{
										this.objectIdCollection_0.Add(dbtext.ObjectId);
										dbtext.TextString = dbtext.TextString.Replace("@", "@#");
									}
								}
								else if (TcBJFJ_frm.GetBJAS(text) <= this.long_0)
								{
									Class36.smethod_64(dbtext.ObjectId);
								}
								else
								{
									this.objectIdCollection_0.Add(dbtext.ObjectId);
									dbtext.TextString = dbtext.TextString.Replace("@", "@#");
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_319:
				num2 = 9;
				string[] array3 = this.TextBox1.Text.Split(new char[]
				{
					'\r'
				});
				IL_33E:
				num2 = 10;
				string[] array4 = this.TextBox2.Text.Split(new char[]
				{
					'\r'
				});
				IL_363:
				num2 = 11;
				string[] array5 = array3;
				int i = 0;
				checked
				{
					while (i < array5.Length)
					{
						string text2 = array5[i];
						IL_379:
						num2 = 12;
						Application.DoEvents();
						IL_381:
						num2 = 13;
						if (Operators.CompareString(text2.Trim(), "", false) != 0)
						{
							IL_3A1:
							num2 = 14;
							int num4 = Array.IndexOf<string>(array3, text2);
							IL_3AF:
							num2 = 15;
							text2 = text2.Trim();
							IL_3BB:
							num2 = 16;
							text2 = text2.Replace("\r\n", "");
							IL_3D1:
							num2 = 17;
							text2 = text2.Replace("@", "@#");
							IL_3E7:
							num2 = 18;
							array4[num4] = array4[num4].Trim();
							IL_3F9:
							num2 = 19;
							array4[num4] = array4[num4].Replace("\r\n", "");
							IL_415:
							num2 = 20;
							array4[num4] = array4[num4].Replace("11@", "10/12@");
							IL_431:
							num2 = 21;
							array4[num4] = array4[num4].Replace("13@", "12/14@");
							IL_44D:
							num2 = 22;
							array4[num4] = array4[num4].Replace("15@", "14/16@");
							IL_469:
							num2 = 23;
							array4[num4] = array4[num4].Replace("17@", "16/18@");
							IL_485:
							num2 = 24;
							array4[num4] = array4[num4].Replace("19@", "18/20@");
							IL_4A1:
							num2 = 25;
							array4[num4] = array4[num4].Replace("21@", "20/22@");
							IL_4BD:
							num2 = 26;
							this.ChangeTxt(text2, array4[num4], 6L);
						}
						IL_4D7:
						i++;
						IL_4DD:
						num2 = 28;
					}
					IL_4ED:
					num2 = 29;
					documentLock.Dispose();
					IL_4F7:
					num2 = 30;
					if (Information.Err().Number <= 0)
					{
						goto IL_51E;
					}
					IL_509:
					num2 = 31;
					Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
					IL_51E:
					goto IL_600;
					IL_523:;
				}
				int num5 = num6 + 1;
				num6 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_5B7:
				goto IL_5F5;
				IL_5B9:
				num6 = num2;
				if (num <= -2)
				{
					goto IL_523;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_5D2:;
			}
			catch when (endfilter(obj4 is Exception & num != 0 & num6 == 0))
			{
				Exception ex = (Exception)obj5;
				goto IL_5B9;
			}
			IL_5F5:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_600:
			if (num6 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public bool ChangeTxt(string OldTxt, string NewTxt, long C)
		{
			ObjectIdCollection objectIdCollection = new ObjectIdCollection();
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId objectId2;
			try
			{
				foreach (object obj in this.objectIdCollection_0)
				{
					ObjectId objectId = (obj != null) ? ((ObjectId)obj) : objectId2;
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
						Application.DoEvents();
						DBText dbtext = (DBText)transaction.GetObject(objectId, 1);
						if (Operators.CompareString(dbtext.TextString, OldTxt, false) == 0)
						{
							dbtext.TextString = NewTxt;
							dbtext.ColorIndex = checked((int)C);
							objectIdCollection.Add(dbtext.ObjectId);
						}
						transaction.Commit();
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
			try
			{
				foreach (object obj2 in objectIdCollection)
				{
					ObjectId objectId3 = (obj2 != null) ? ((ObjectId)obj2) : objectId2;
					this.objectIdCollection_0.Remove(objectId3);
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
			bool result;
			return result;
		}

		public static bool GetFuJinDBText(Entity Ent, double Dist, string LayerName, double Angle, ref DBObjectCollection DBCT)
		{
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "Text");
			array2.SetValue(typedValue, 0);
			if (Operators.CompareString(LayerName, "", false) != 0)
			{
				array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[2]);
				Array array3 = array;
				typedValue..ctor(8, LayerName);
				array3.SetValue(typedValue, 1);
			}
			Point3d maxPoint = Ent.GeometricExtents.MaxPoint;
			Point3d minPoint = Ent.GeometricExtents.MinPoint;
			Point3dCollection point3dCollection = new Point3dCollection();
			Point3dCollection point3dCollection2 = point3dCollection;
			Point3d point3d;
			point3d..ctor(minPoint.X - Dist, minPoint.Y - Dist, 0.0);
			point3dCollection2.Add(point3d);
			Point3dCollection point3dCollection3 = point3dCollection;
			point3d..ctor(minPoint.X - Dist, maxPoint.Y + Dist, 0.0);
			point3dCollection3.Add(point3d);
			Point3dCollection point3dCollection4 = point3dCollection;
			point3d..ctor(maxPoint.X + Dist, maxPoint.Y + Dist, 0.0);
			point3dCollection4.Add(point3d);
			Point3dCollection point3dCollection5 = point3dCollection;
			point3d..ctor(maxPoint.X + Dist, minPoint.Y - Dist, 0.0);
			point3dCollection5.Add(point3d);
			DBObjectCollection dbobjectCollection = CAD.CrossingPolygon(point3dCollection, array);
			if (dbobjectCollection.Count >= 1)
			{
				try
				{
					foreach (object obj in dbobjectCollection)
					{
						DBText dbtext = (DBText)obj;
						if (!DBCT.Contains(dbtext))
						{
							double num = dbtext.Rotation;
							if (num > 6.2831853071795862)
							{
								num -= 6.2831853071795862;
							}
							if (Math.Abs(num - Angle) < 0.01)
							{
								DBCT.Add(dbtext);
								TcBJFJ_frm.GetFuJinDBText(dbtext, Dist, LayerName, Angle, ref DBCT);
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
			}
			bool result;
			return result;
		}

		public static bool GetFuJinPL(Entity Ent, double Dist, string LayerName, double Angle, ref DBObjectCollection DBC)
		{
			TypedValue[] array = new TypedValue[1];
			Array array2 = array;
			TypedValue typedValue;
			typedValue..ctor(0, "LWPOLYLINE");
			array2.SetValue(typedValue, 0);
			if (Operators.CompareString(LayerName, "", false) != 0)
			{
				array = (TypedValue[])Utils.CopyArray((Array)array, new TypedValue[2]);
				Array array3 = array;
				typedValue..ctor(8, LayerName);
				array3.SetValue(typedValue, 1);
			}
			Point3d maxPoint = Ent.GeometricExtents.MaxPoint;
			Point3d minPoint = Ent.GeometricExtents.MinPoint;
			Point3dCollection point3dCollection = new Point3dCollection();
			Point3dCollection point3dCollection2 = point3dCollection;
			Point3d point3dAt;
			point3dAt..ctor(minPoint.X - Dist, minPoint.Y - Dist, 0.0);
			point3dCollection2.Add(point3dAt);
			Point3dCollection point3dCollection3 = point3dCollection;
			point3dAt..ctor(minPoint.X - Dist, maxPoint.Y + Dist, 0.0);
			point3dCollection3.Add(point3dAt);
			Point3dCollection point3dCollection4 = point3dCollection;
			point3dAt..ctor(maxPoint.X + Dist, maxPoint.Y + Dist, 0.0);
			point3dCollection4.Add(point3dAt);
			Point3dCollection point3dCollection5 = point3dCollection;
			point3dAt..ctor(maxPoint.X + Dist, minPoint.Y - Dist, 0.0);
			point3dCollection5.Add(point3dAt);
			DBObjectCollection dbobjectCollection = CAD.CrossingPolygon(point3dCollection, array);
			if (dbobjectCollection.Count >= 1)
			{
				try
				{
					foreach (object obj in dbobjectCollection)
					{
						Polyline polyline = (Polyline)obj;
						if (!DBC.Contains(polyline))
						{
							point3dAt = polyline.GetPoint3dAt(1);
							point3dAt.GetVectorTo(polyline.GetPoint3dAt(2)).AngleOnPlane(new Plane());
							Line line = new Line(polyline.GetPoint3dAt(1), polyline.GetPoint3dAt(2));
							if (Math.Abs(line.Angle - Math.Abs(Angle)) < 0.01)
							{
								DBC.Add(polyline);
								TcBJFJ_frm.GetFuJinDBText(polyline, Dist, LayerName, Angle, ref DBC);
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
			}
			bool result;
			return result;
		}

		private void Button2_Click(object sender, EventArgs e)
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
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_32:
				num2 = 4;
				Database database = mdiActiveDocument.Database;
				IL_3B:
				num2 = 5;
				DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
				IL_4E:
				num2 = 6;
				this.arrayList_0 = new ArrayList();
				IL_5B:
				num2 = 7;
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
							string text = JG.HRB(dbtext.TextString);
							if ((!this.arrayList_0.Contains(text) & text.Contains("@")) && TcBJFJ_frm.GetBJAS(text) > this.long_0)
							{
								this.arrayList_0.Add(text);
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
				}
				IL_17C:
				num2 = 9;
				this.TextBox1.Text = "";
				IL_18F:
				num2 = 10;
				this.TextBox4.Text = "";
				IL_1A2:
				num2 = 11;
				this.arrayList_1 = new ArrayList();
				IL_1B0:
				num2 = 12;
				IEnumerator enumerator2 = this.arrayList_0.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object value2 = enumerator2.Current;
					string text2 = Conversions.ToString(value2);
					IL_1D3:
					num2 = 13;
					long bjas = TcBJFJ_frm.GetBJAS(text2);
					IL_1DF:
					num2 = 14;
					this.arrayList_1.Add(bjas);
					IL_1F5:
					num2 = 15;
					this.TextBox4.Text = this.TextBox4.Text + Conversions.ToString(bjas) + "\r\n";
					IL_21F:
					num2 = 16;
					this.TextBox1.Text = this.TextBox1.Text + text2 + "\r\n";
					IL_244:
					num2 = 17;
				}
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
				IL_26E:
				num2 = 18;
				this.XGJ_sub();
				IL_277:
				num2 = 19;
				if (Information.Err().Number <= 0)
				{
					goto IL_28E;
				}
				IL_289:
				goto IL_3A3;
				IL_28E:
				num2 = 22;
				IL_291:
				num2 = 23;
				this.Button1.Enabled = true;
				IL_2A0:
				num2 = 25;
				documentLock.Dispose();
				IL_2AA:
				num2 = 26;
				if (Information.Err().Number <= 0)
				{
					goto IL_2D1;
				}
				IL_2BC:
				num2 = 27;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_2D1:
				goto IL_3A3;
				IL_2D6:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_35A:
				goto IL_398;
				IL_35C:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_2D6;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_375:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_35C;
			}
			IL_398:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_3A3:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public static long GetBJAS(string S)
		{
			S = Strings.Replace(S, "D", "", 1, -1, CompareMethod.Binary);
			S = Strings.Replace(S, "%%130", "", 1, -1, CompareMethod.Binary);
			S = Strings.Replace(S, "%%131", "", 1, -1, CompareMethod.Binary);
			S = Strings.Replace(S, "%%132", "", 1, -1, CompareMethod.Binary);
			S = Strings.Replace(S, "%%133", "", 1, -1, CompareMethod.Binary);
			int num = Strings.InStr(S, "@", CompareMethod.Binary);
			long result;
			if (num >= 0)
			{
				string[] array = S.Split(new char[]
				{
					'@'
				});
				long num2 = Conversions.ToLong(array[0]);
				long num3 = Conversions.ToLong(array[1]);
				result = checked((long)Math.Round(unchecked(Math.Pow((double)num2, 2.0) * 3.1415926535897931 / 4.0 * 1000.0) / (double)num3));
			}
			else
			{
				result = 0L;
			}
			return result;
		}

		private void TextBox3_TextChanged(object sender, EventArgs e)
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
				this.long_0 = checked((long)Math.Round(Conversion.Val(this.TextBox3.Text)));
				IL_27:
				num2 = 3;
				this.XGJ_sub();
				IL_2F:
				goto IL_93;
				IL_31:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_4F:
				goto IL_88;
				IL_51:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_31;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_66:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_51;
			}
			IL_88:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_93:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
				this.long_1 = checked((long)Math.Round(Conversion.Val(this.ComboBox1.Text)));
				IL_27:
				num2 = 3;
				this.XGJ_sub();
				IL_2F:
				goto IL_93;
				IL_31:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_4F:
				goto IL_88;
				IL_51:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_31;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_66:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_51;
			}
			IL_88:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_93:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcBJFJ_frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "板筋通筋面积", "板筋通筋面积", Conversions.ToString(this.long_0));
			Interaction.SaveSetting(Class33.Class31_0.Info.ProductName, "板筋附加间距", "板筋附加间距", Conversions.ToString(this.long_1));
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void TcBJFJ_frm_Load(object sender, EventArgs e)
		{
			this.ComboBox1.Items.Add("100");
			this.ComboBox1.Items.Add("150");
			this.ComboBox1.Items.Add("200");
			this.ComboBox1.Items.Add("250");
			this.ComboBox1.Items.Add("300");
			this.ComboBox1.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "板筋附加间距", "板筋附加间距", Conversions.ToString(200));
			this.TextBox3.Text = Interaction.GetSetting(Class33.Class31_0.Info.ProductName, "板筋通筋面积", "板筋通筋面积", Conversions.ToString(350));
		}

		public void XGJ_sub()
		{
			string text = "%%132";
			this.arrayList_2 = new ArrayList();
			this.TextBox2.Text = "";
			this.TextBox5.Text = "";
			this.TextBox6.Text = "";
			this.Label3.Text = "";
			double num = double.MinValue;
			checked
			{
				if (this.long_0 != 0L & this.long_1 != 0L & this.arrayList_0.Count != 0)
				{
					try
					{
						foreach (object value in this.arrayList_0)
						{
							string text2 = Conversions.ToString(value);
							long bjas = TcBJFJ_frm.GetBJAS(text2);
							long num2 = bjas - this.long_0;
							if (num2 > 0L)
							{
								bool flag = false;
								long num3 = 8L;
								long num4;
								double num5;
								long num6;
								double num7;
								do
								{
									if (this.CheckBox1.Checked)
									{
										if (TcBJFJ_frm.isIn_HRB_Array1((int)num3))
										{
											num4 = (long)Math.Round(unchecked((double)(checked(num3 * num3)) * 3.1415926535897931 / 4.0 * 1000.0) / (double)this.long_1);
											num5 = (double)(num4 - num2) / (double)num2;
											if ((double)num4 > unchecked((double)num2 * 0.95))
											{
												goto Block_7;
											}
										}
									}
									else if (TcBJFJ_frm.isIn_HRB_Array((int)num3))
									{
										num6 = (long)Math.Round(unchecked((double)(checked(num3 * num3)) * 3.1415926535897931 / 4.0 * 1000.0) / (double)this.long_1);
										num7 = (double)(num6 - num2) / (double)num2;
										if ((double)num6 > unchecked((double)num2 * 0.95))
										{
											goto IL_33B;
										}
									}
									num3 += 1L;
								}
								while (num3 <= 32L);
								IL_420:
								this.Label3.Text = "最大误差:" + Strings.Format(num, "0.00");
								if (!flag)
								{
									this.arrayList_2.Add(text2);
									this.TextBox2.Text = this.TextBox2.Text + text2 + "\r\n";
									this.TextBox5.Text = this.TextBox5.Text + "*\r\n";
									this.TextBox6.Text = this.TextBox6.Text + "*\r\n";
									continue;
								}
								continue;
								Block_7:
								this.arrayList_2.Add(text + Conversions.ToString(num3) + "@" + Conversions.ToString(this.long_1));
								this.TextBox2.Text = string.Concat(new string[]
								{
									this.TextBox2.Text,
									text,
									Conversions.ToString(num3),
									"@",
									Conversions.ToString(this.long_1),
									"\r\n"
								});
								this.TextBox5.Text = this.TextBox5.Text + Conversions.ToString(num4) + "\r\n";
								this.TextBox6.Text = this.TextBox6.Text + Strings.Format(num5, "0.00") + "\r\n";
								num = Math.Max(num, num5);
								flag = true;
								goto IL_420;
								IL_33B:
								this.arrayList_2.Add(text + Conversions.ToString(num3) + "@" + Conversions.ToString(this.long_1));
								this.TextBox2.Text = string.Concat(new string[]
								{
									this.TextBox2.Text,
									text,
									Conversions.ToString(num3),
									"@",
									Conversions.ToString(this.long_1),
									"\r\n"
								});
								this.TextBox5.Text = this.TextBox5.Text + Conversions.ToString(num6) + "\r\n";
								this.TextBox6.Text = this.TextBox6.Text + Strings.Format(num7, "0.00") + "\r\n";
								num = Math.Max(num, num7);
								flag = true;
								goto IL_420;
							}
							this.arrayList_2.Add(text2);
							this.TextBox2.Text = this.TextBox2.Text + text2 + "\r\n";
							this.TextBox5.Text = this.TextBox5.Text + "0\r\n";
							this.TextBox6.Text = this.TextBox6.Text + "0\r\n";
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
			}
		}

		public static bool isIn_HRB_Array(int D)
		{
			bool result = false;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(6);
			arrayList.Add(8);
			arrayList.Add(10);
			arrayList.Add(12);
			arrayList.Add(14);
			arrayList.Add(16);
			arrayList.Add(18);
			arrayList.Add(20);
			arrayList.Add(22);
			arrayList.Add(25);
			arrayList.Add(28);
			arrayList.Add(32);
			arrayList.Add(36);
			arrayList.Add(40);
			int num = 0;
			checked
			{
				do
				{
					if (Operators.ConditionalCompareObjectEqual(arrayList[num], D, false))
					{
						result = true;
					}
					num++;
				}
				while (num <= 13);
				return result;
			}
		}

		public static bool isIn_HRB_Array1(int D)
		{
			bool result = false;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(6);
			arrayList.Add(8);
			arrayList.Add(10);
			arrayList.Add(12);
			arrayList.Add(13);
			arrayList.Add(14);
			arrayList.Add(15);
			arrayList.Add(16);
			arrayList.Add(17);
			arrayList.Add(18);
			arrayList.Add(19);
			arrayList.Add(20);
			arrayList.Add(21);
			arrayList.Add(22);
			arrayList.Add(25);
			arrayList.Add(28);
			arrayList.Add(32);
			arrayList.Add(36);
			arrayList.Add(40);
			int num = 0;
			checked
			{
				do
				{
					if (Operators.ConditionalCompareObjectEqual(arrayList[num], D, false))
					{
						result = true;
					}
					num++;
				}
				while (num <= 13);
				return result;
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			string text = "TcQuTongShanChu";
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Document document = Application.DocumentManager.GetDocument(HostApplicationServices.WorkingDatabase);
			document.Editor.WriteMessage("\r\n命令:" + text + "\r\n");
			document.SendStringToExecute(text + " ", false, false, false);
		}

		private void TextBox6_TextChanged(object sender, EventArgs e)
		{
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Label2")]
		private Label _Label2;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("RadioButton1")]
		private RadioButton _RadioButton1;

		[AccessedThroughProperty("RadioButton2")]
		private RadioButton _RadioButton2;

		[AccessedThroughProperty("CheckBox1")]
		private CheckBox _CheckBox1;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("Label3")]
		private Label _Label3;

		private ObjectIdCollection objectIdCollection_0;

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		private long long_0;

		private long long_1;

		private ArrayList arrayList_2;
	}
}
