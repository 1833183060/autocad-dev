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
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic.CompilerServices;
using TcDotNetBarcode;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class QRCode_Frm : Form
	{
		[DebuggerNonUserCode]
		static QRCode_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			QRCode_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public QRCode_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.QRCode_Frm_Load;
			QRCode_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = QRCode_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (QRCode_Frm.list_0.Count == QRCode_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = QRCode_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = QRCode_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									QRCode_Frm.list_0[num] = QRCode_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						QRCode_Frm.list_0.RemoveRange(num, QRCode_Frm.list_0.Count - num);
						QRCode_Frm.list_0.Capacity = QRCode_Frm.list_0.Count;
					}
					QRCode_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual SplitContainer SplitContainer1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._SplitContainer1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._SplitContainer1 = value;
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
				EventHandler value2 = new EventHandler(this.TextBox1_TextChanged);
				if (this._TextBox1 != null)
				{
					this._TextBox1.TextChanged -= value2;
				}
				this._TextBox1 = value;
				if (this._TextBox1 != null)
				{
					this._TextBox1.TextChanged += value2;
				}
			}
		}

		internal virtual TableLayoutPanel TableLayoutPanel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TableLayoutPanel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TableLayoutPanel1 = value;
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
				this._ComboBox1 = value;
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

		private void Button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Application.DocumentManager.MdiActiveDocument.LockDocument();
			Point3d point = CAD.GetPoint("选择插入点: ");
			Point3d point3d;
			if (point != point3d)
			{
				string text = new DotNetBarcode
				{
					Type = DotNetBarcode.Types.QRCode,
					PrintCheckDigitChar = true
				}.QRCode_GetHeiBaiString(this.TextBox1.Text);
				short num;
				short num2;
				ObjectIdCollection objectIdCollection;
				short num4;
				short num5;
				checked
				{
					num = (short)Math.Round(Math.Sqrt((double)text.Length));
					num2 = 100;
					objectIdCollection = new ObjectIdCollection();
					short num3 = 0;
					num4 = num - 1;
					num5 = num3;
				}
				for (;;)
				{
					short num6 = num5;
					short num7 = num4;
					if (num6 > num7)
					{
						break;
					}
					short num8 = 0;
					short num9 = checked(num - 1);
					short num10 = num8;
					for (;;)
					{
						short num11 = num10;
						num7 = num9;
						if (num11 > num7)
						{
							break;
						}
						string left = text.Substring((int)(num5 * num + num10), 1);
						if (Operators.CompareString(left, "1", false) == 0)
						{
							Point3d point3d_;
							point3d_..ctor((double)(num5 * num2) + point.X, (double)((num - num10) * num2) + point.Y, 0.0);
							objectIdCollection.Add(this.method_0(point3d_, num2, num2));
						}
						num10 += 1;
					}
					num5 += 1;
				}
				this.ToNiMingBlock(objectIdCollection);
			}
		}

		private ObjectId method_0(Point3d point3d_0, short short_0, short short_1)
		{
			Solid solid = new Solid();
			solid.SetPointAt(0, point3d_0);
			Solid solid2 = solid;
			short num = 1;
			Point3d point3d;
			point3d..ctor(point3d_0.X, point3d_0.Y + (double)short_1, point3d_0.Z);
			solid2.SetPointAt(num, point3d);
			Solid solid3 = solid;
			short num2 = 2;
			point3d..ctor(point3d_0.X + (double)short_0, point3d_0.Y, point3d_0.Z);
			solid3.SetPointAt(num2, point3d);
			Solid solid4 = solid;
			short num3 = 3;
			point3d..ctor(point3d_0.X + (double)short_0, point3d_0.Y + (double)short_1, point3d_0.Z);
			solid4.SetPointAt(num3, point3d);
			CAD.AddEnt(solid);
			return solid.ObjectId;
		}

		public bool ToNiMingBlock(ObjectIdCollection IDs)
		{
			bool result;
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)transaction.GetObject(database.BlockTableId, 1);
					BlockTableRecord blockTableRecord = new BlockTableRecord();
					blockTableRecord.Name = "*Q";
					Entity entity = (Entity)transaction.GetObject(IDs[0], 0);
					Point3d minPoint = entity.GeometricExtents.MinPoint;
					blockTableRecord.Origin = minPoint;
					try
					{
						foreach (object obj in IDs)
						{
							ObjectId objectId2;
							ObjectId objectId = (obj != null) ? ((ObjectId)obj) : objectId2;
							Entity entity2 = (Entity)transaction.GetObject(objectId, 1);
							Entity entity3 = (Entity)entity2.Clone();
							entity2.Erase();
							blockTableRecord.AppendEntity(entity3);
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
					blockTable.Add(blockTableRecord);
					transaction.AddNewlyCreatedDBObject(blockTableRecord, true);
					BlockTableRecord blockTableRecord2 = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
					BlockReference blockReference = new BlockReference(minPoint, blockTableRecord.ObjectId);
					blockReference.Layer = entity.Layer;
					blockTableRecord2.AppendEntity(blockReference);
					transaction.AddNewlyCreatedDBObject(blockReference, true);
					transaction.Commit();
				}
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			int num2;
			int num3;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				DotNetBarcode dotNetBarcode = new DotNetBarcode();
				IL_09:
				num = 2;
				dotNetBarcode.Type = DotNetBarcode.Types.QRCode;
				IL_12:
				num = 3;
				dotNetBarcode.PrintCheckDigitChar = true;
				IL_1B:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_23:
				num = 5;
				dotNetBarcode.WriteBar(this.TextBox1.Text, 0f, 0f, (float)this.SplitContainer1.Panel2.Width, (float)this.SplitContainer1.Panel2.Height, this.SplitContainer1.Panel2.CreateGraphics());
				IL_72:
				goto IL_D7;
				IL_74:
				goto IL_E1;
				IL_76:
				num3 = num;
				if (num2 <= -2)
				{
					goto IL_8D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				goto IL_B5;
				IL_8D:
				int num4 = num3 + 1;
				num3 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num4);
				IL_B5:
				goto IL_E1;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num3 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_76;
			}
			IL_D7:
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return;
			IL_E1:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private void QRCode_Frm_Load(object sender, EventArgs e)
		{
			int num2;
			int num4;
			object obj;
			try
			{
				IL_01:
				int num = 1;
				DotNetBarcode dotNetBarcode = new DotNetBarcode();
				IL_09:
				num = 2;
				dotNetBarcode.Type = DotNetBarcode.Types.QRCode;
				IL_12:
				num = 3;
				dotNetBarcode.PrintCheckDigitChar = true;
				IL_1B:
				ProjectData.ClearProjectError();
				num2 = -2;
				IL_23:
				num = 5;
				dotNetBarcode.WriteBar(this.TextBox1.Text, 0f, 0f, (float)this.SplitContainer1.Panel2.Width, (float)this.SplitContainer1.Panel2.Height, this.SplitContainer1.Panel2.CreateGraphics());
				IL_72:
				goto IL_DE;
				IL_74:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_9A:
				goto IL_D3;
				IL_9C:
				num4 = num;
				if (num2 <= -2)
				{
					goto IL_74;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num2);
				IL_B1:;
			}
			catch when (endfilter(obj is Exception & num2 != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_9C;
			}
			IL_D3:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_DE:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("SplitContainer1")]
		private SplitContainer _SplitContainer1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TableLayoutPanel1")]
		private TableLayoutPanel _TableLayoutPanel1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;
	}
}
