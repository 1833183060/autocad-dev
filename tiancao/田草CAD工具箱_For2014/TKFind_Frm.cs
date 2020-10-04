using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	[DesignerGenerated]
	public partial class TKFind_Frm : Form
	{
		[DebuggerNonUserCode]
		static TKFind_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TKFind_Frm.list_0 = new List<WeakReference>();
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public TKFind_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			base.Load += this.TKFind_Frm_Load;
			TKFind_Frm.smethod_0(this);
			this.documentCollection_0 = Application.DocumentManager;
			this.editor_0 = this.documentCollection_0.MdiActiveDocument.Editor;
			this.database_0 = this.documentCollection_0.MdiActiveDocument.Database;
			this.string_0 = Class33.Class31_0.Info.DirectoryPath + "\\Blocks\\结构图库.dwg";
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TKFind_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TKFind_Frm.list_0.Count == TKFind_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TKFind_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TKFind_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TKFind_Frm.list_0[num] = TKFind_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TKFind_Frm.list_0.RemoveRange(num, TKFind_Frm.list_0.Count - num);
						TKFind_Frm.list_0.Capacity = TKFind_Frm.list_0.Count;
					}
					TKFind_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		internal virtual ListBox ListBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._ListBox1 = value;
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

		internal virtual ListBox ListBox2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._ListBox2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.ListBox2_SelectedIndexChanged);
				if (this._ListBox2 != null)
				{
					this._ListBox2.SelectedIndexChanged -= value2;
				}
				this._ListBox2 = value;
				if (this._ListBox2 != null)
				{
					this._ListBox2.SelectedIndexChanged += value2;
				}
			}
		}

		internal virtual PictureBox PictureBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._PictureBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.PictureBox1_Click);
				if (this._PictureBox1 != null)
				{
					this._PictureBox1.Click -= value2;
				}
				this._PictureBox1 = value;
				if (this._PictureBox1 != null)
				{
					this._PictureBox1.Click += value2;
				}
			}
		}

		internal virtual ImageList ImageList1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.imageList_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.imageList_0 = value;
			}
		}

		private void TKFind_Frm_Load(object sender, EventArgs e)
		{
			Interaction.MsgBox(this.string_0, MsgBoxStyle.OkOnly, null);
			this.database_1 = new Database(false, true);
			this.database_1.ReadDwgFile(this.string_0, FileShare.Read, true, "");
			this.transactionManager_0 = this.database_1.TransactionManager;
			checked
			{
				using (this.transactionManager_0.StartTransaction())
				{
					BlockTable blockTable = (BlockTable)this.transactionManager_0.GetObject(this.database_1.BlockTableId, 0, false);
					try
					{
						foreach (ObjectId objectId in blockTable)
						{
							BlockTableRecord blockTableRecord = (BlockTableRecord)this.transactionManager_0.GetObject(objectId, 0, false);
							if (blockTableRecord.Name.ToString().Length >= 3 && Operators.CompareString(blockTableRecord.Name.ToString().Substring(0, 3), "TC_", false) == 0)
							{
								Interaction.MsgBox(blockTableRecord.PreviewIcon.Width, MsgBoxStyle.OkOnly, null);
								int num;
								this.ListBox1.Items.Add(blockTableRecord.Name.ToString() + "@" + Conversions.ToString(num));
								num++;
							}
						}
					}
					finally
					{
						SymbolTableEnumerator enumerator;
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					blockTable.Dispose();
				}
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
			}
		}

		private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			using (this.transactionManager_0.StartTransaction())
			{
				BlockTable blockTable = (BlockTable)this.transactionManager_0.GetObject(this.database_1.BlockTableId, 0, false);
				BlockReference blockReference = (BlockReference)this.transactionManager_0.GetObject(blockTable[this.ListBox1.SelectedItem.ToString()], 0);
				blockTable.Dispose();
				this.PictureBox1.Image = this.ImageList1.Images[this.ListBox1.SelectedIndex];
			}
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("ListBox1")]
		private ListBox _ListBox1;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("ListBox2")]
		private ListBox _ListBox2;

		[AccessedThroughProperty("PictureBox1")]
		private PictureBox _PictureBox1;

		[AccessedThroughProperty("ImageList1")]
		private ImageList imageList_0;

		private ObjectIdCollection objectIdCollection_0;

		private DocumentCollection documentCollection_0;

		private Editor editor_0;

		private Database database_0;

		private Database database_1;

		private string string_0;

		private TransactionManager transactionManager_0;
	}
}
