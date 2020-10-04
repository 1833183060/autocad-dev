using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public partial class Filter_Frm : Form
	{
		[DebuggerNonUserCode]
		static Filter_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			Filter_Frm.list_0 = new List<WeakReference>();
		}

		[DebuggerNonUserCode]
		public Filter_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			Filter_Frm.smethod_0(this);
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = Filter_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (Filter_Frm.list_0.Count == Filter_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = Filter_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = Filter_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									Filter_Frm.list_0[num] = Filter_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						Filter_Frm.list_0.RemoveRange(num, Filter_Frm.list_0.Count - num);
						Filter_Frm.list_0.Capacity = Filter_Frm.list_0.Count;
					}
					Filter_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
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
				this._TextBox3 = value;
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

		internal virtual Button Button4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button4 = value;
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

		internal virtual Button Button5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button5_Click);
				if (this._Button5 != null)
				{
					this._Button5.Click -= value2;
				}
				this._Button5 = value;
				if (this._Button5 != null)
				{
					this._Button5.Click += value2;
				}
			}
		}

		internal virtual Button Button6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button6 = value;
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
				this._TextBox6 = value;
			}
		}

		internal virtual Button Button7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button7 = value;
			}
		}

		internal virtual TextBox TextBox7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox7 = value;
			}
		}

		internal virtual Button Button8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button8 = value;
			}
		}

		internal virtual TextBox TextBox8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TextBox8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TextBox8 = value;
			}
		}

		internal virtual Button Button9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button9_Click);
				if (this._Button9 != null)
				{
					this._Button9.Click -= value2;
				}
				this._Button9 = value;
				if (this._Button9 != null)
				{
					this._Button9.Click += value2;
				}
			}
		}

		internal virtual Button Button10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button10_Click);
				if (this._Button10 != null)
				{
					this._Button10.Click -= value2;
				}
				this._Button10 = value;
				if (this._Button10 != null)
				{
					this._Button10.Click += value2;
				}
			}
		}

		internal virtual Button Button11
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button11_Click);
				if (this._Button11 != null)
				{
					this._Button11.Click -= value2;
				}
				this._Button11 = value;
				if (this._Button11 != null)
				{
					this._Button11.Click += value2;
				}
			}
		}

		internal virtual Button Button12
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button12_Click);
				if (this._Button12 != null)
				{
					this._Button12.Click -= value2;
				}
				this._Button12 = value;
				if (this._Button12 != null)
				{
					this._Button12.Click += value2;
				}
			}
		}

		internal virtual Button Button13
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button13;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button13_Click);
				if (this._Button13 != null)
				{
					this._Button13.Click -= value2;
				}
				this._Button13 = value;
				if (this._Button13 != null)
				{
					this._Button13.Click += value2;
				}
			}
		}

		internal virtual Button Button14
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button14;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button14_Click);
				if (this._Button14 != null)
				{
					this._Button14.Click -= value2;
				}
				this._Button14 = value;
				if (this._Button14 != null)
				{
					this._Button14.Click += value2;
				}
			}
		}

		internal virtual Button Button15
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button15;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button15_Click);
				if (this._Button15 != null)
				{
					this._Button15.Click -= value2;
				}
				this._Button15 = value;
				if (this._Button15 != null)
				{
					this._Button15.Click += value2;
				}
			}
		}

		internal virtual Button Button16
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button16;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button16_Click);
				if (this._Button16 != null)
				{
					this._Button16.Click -= value2;
				}
				this._Button16 = value;
				if (this._Button16 != null)
				{
					this._Button16.Click += value2;
				}
			}
		}

		internal virtual Button Button17
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button17;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button17_Click);
				if (this._Button17 != null)
				{
					this._Button17.Click -= value2;
				}
				this._Button17 = value;
				if (this._Button17 != null)
				{
					this._Button17.Click += value2;
				}
			}
		}

		internal virtual Button Button18
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button18;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button18 = value;
			}
		}

		internal virtual Button Button19
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button19;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button19 = value;
			}
		}

		internal virtual Button Button20
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button20;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button20_Click);
				if (this._Button20 != null)
				{
					this._Button20.Click -= value2;
				}
				this._Button20 = value;
				if (this._Button20 != null)
				{
					this._Button20.Click += value2;
				}
			}
		}

		internal virtual Button Button21
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button21;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button21_Click);
				if (this._Button21 != null)
				{
					this._Button21.Click -= value2;
				}
				this._Button21 = value;
				if (this._Button21 != null)
				{
					this._Button21.Click += value2;
				}
			}
		}

		internal virtual Button Button22
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button22;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button22_Click);
				if (this._Button22 != null)
				{
					this._Button22.Click -= value2;
				}
				this._Button22 = value;
				if (this._Button22 != null)
				{
					this._Button22.Click += value2;
				}
			}
		}

		internal virtual Button Button23
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button23;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button23_Click);
				if (this._Button23 != null)
				{
					this._Button23.Click -= value2;
				}
				this._Button23 = value;
				if (this._Button23 != null)
				{
					this._Button23.Click += value2;
				}
			}
		}

		internal virtual Button Button24
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button24;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button24_Click);
				if (this._Button24 != null)
				{
					this._Button24.Click -= value2;
				}
				this._Button24 = value;
				if (this._Button24 != null)
				{
					this._Button24.Click += value2;
				}
			}
		}

		internal virtual Button Button25
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button25;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button25_Click);
				if (this._Button25 != null)
				{
					this._Button25.Click -= value2;
				}
				this._Button25 = value;
				if (this._Button25 != null)
				{
					this._Button25.Click += value2;
				}
			}
		}

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr SetFocus(IntPtr hwnd);

		private void Button17_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button16_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button15_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button13_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button12_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button14_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button11_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "text", new object[0], null, null, null), "And", false))
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"Not"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					Color.NavajoWhite
				}, null, null);
			}
			else
			{
				NewLateBinding.LateSet(sender, null, "text", new object[]
				{
					"And"
				}, null, null);
				NewLateBinding.LateSet(sender, null, "BackColor", new object[]
				{
					SystemColors.ButtonShadow
				}, null, null);
			}
		}

		private void Button1_Click(object sender, EventArgs e)
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
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				ArrayList arrayList = new ArrayList();
				IL_2D:
				num2 = 4;
				string text = "";
				IL_35:
				num2 = 5;
				IL_3E:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4C:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_57:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
								string name = entity.GetType().Name;
								if (!arrayList.Contains(name))
								{
									text = text + name + ",";
									arrayList.Add(name);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				IL_136:
				num2 = 10;
				this.TextBox1.Text = text;
				IL_145:
				goto IL_1CC;
				IL_14A:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_186:
				goto IL_1C1;
				IL_188:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_14A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19E:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_188;
			}
			IL_1C1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1CC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
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
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				ArrayList arrayList = new ArrayList();
				IL_2D:
				num2 = 4;
				string text = "";
				IL_35:
				num2 = 5;
				IL_3E:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4C:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_57:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
								string layer = entity.Layer;
								if (!arrayList.Contains(layer))
								{
									text = text + layer + ",";
									arrayList.Add(layer);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				IL_131:
				num2 = 10;
				this.TextBox2.Text = text;
				IL_140:
				goto IL_1C7;
				IL_145:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_181:
				goto IL_1BC;
				IL_183:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_145;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_199:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_183;
			}
			IL_1BC:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1C7:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button3_Click(object sender, EventArgs e)
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
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				ArrayList arrayList = new ArrayList();
				IL_2D:
				num2 = 4;
				string text = "";
				IL_35:
				num2 = 5;
				IL_3E:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4C:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_57:
				num2 = 8;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
								string text2 = Conversions.ToString(entity.ColorIndex);
								if (!arrayList.Contains(text2))
								{
									text = text + text2 + ",";
									arrayList.Add(text2);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				IL_136:
				num2 = 10;
				this.TextBox3.Text = text;
				IL_145:
				goto IL_1CC;
				IL_14A:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_186:
				goto IL_1C1;
				IL_188:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_14A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_19E:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_188;
			}
			IL_1C1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1CC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button5_Click(object sender, EventArgs e)
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
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_25:
				num2 = 3;
				ArrayList arrayList = new ArrayList();
				IL_2D:
				num2 = 4;
				string text = "";
				IL_35:
				num2 = 5;
				IL_3E:
				num2 = 6;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_4C:
				num2 = 7;
				Database database = mdiActiveDocument.Database;
				IL_57:
				num2 = 8;
				TypedValue[] array = new TypedValue[1];
				IL_61:
				num2 = 9;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "TEXT");
				array2.SetValue(typedValue, 0);
				IL_80:
				num2 = 10;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_8C:
				num2 = 11;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 0);
								string textString = dbtext.TextString;
								if (!arrayList.Contains(textString))
								{
									text = text + textString + ",";
									arrayList.Add(textString);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				IL_169:
				num2 = 13;
				this.TextBox3.Text = text;
				IL_178:
				goto IL_20B;
				IL_17D:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_1C5:
				goto IL_200;
				IL_1C7:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_17D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_1DD:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_1C7;
			}
			IL_200:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_20B:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button25_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				ArrayList arrayList = new ArrayList();
				IL_35:
				num2 = 5;
				string text = "";
				IL_3D:
				num2 = 6;
				IL_46:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_54:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
								string name = entity.GetType().Name;
								if (!arrayList.Contains(name))
								{
									text = text + name + ",";
									arrayList.Add(name);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
					transaction.Dispose();
				}
				IL_14D:
				num2 = 11;
				text = text.Replace("DBText", "Text");
				IL_161:
				num2 = 12;
				text = text.Substring(0, checked(text.Length - 1));
				IL_174:
				num2 = 13;
				string str = text.Replace(",", "\r\n");
				IL_189:
				num2 = 14;
				Interaction.MsgBox("图元:\r\n" + str, MsgBoxStyle.OkOnly, null);
				IL_1A0:
				num2 = 15;
				TypedValue[] array = new TypedValue[1];
				IL_1AB:
				num2 = 16;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, text);
				array2.SetValue(typedValue, 0);
				IL_1C6:
				num2 = 17;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_1D2:
				num2 = 18;
				ObjectId[] array3 = null;
				IL_1D8:
				num2 = 19;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection2 = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection2.Status == 5100)
					{
						array3 = selection2.Value.GetObjectIds();
					}
					if (array3 != null)
					{
						mdiActiveDocument.Editor.SetImpliedSelection(array3);
					}
					transaction2.Commit();
					transaction2.Dispose();
				}
				IL_251:
				goto IL_2FC;
				IL_256:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2B6:
				goto IL_2F1;
				IL_2B8:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_256;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2CE:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2B8;
			}
			IL_2F1:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2FC:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button24_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				ArrayList arrayList = new ArrayList();
				IL_35:
				num2 = 5;
				string text = "";
				IL_3D:
				num2 = 6;
				IL_46:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_54:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
								string layer = entity.Layer;
								if (!arrayList.Contains(layer))
								{
									text = text + layer + ",";
									arrayList.Add(layer);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
					transaction.Dispose();
				}
				IL_148:
				num2 = 11;
				text = text.Substring(0, checked(text.Length - 1));
				IL_15B:
				num2 = 12;
				string str = text.Replace(",", "\r\n");
				IL_170:
				num2 = 13;
				Interaction.MsgBox("图层\r\n" + str, MsgBoxStyle.OkOnly, null);
				IL_187:
				num2 = 14;
				TypedValue[] array = new TypedValue[1];
				IL_192:
				num2 = 15;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(8, text);
				array2.SetValue(typedValue, 0);
				IL_1AD:
				num2 = 16;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_1B9:
				num2 = 17;
				ObjectId[] array3 = null;
				IL_1BF:
				num2 = 18;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection2 = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection2.Status == 5100)
					{
						array3 = selection2.Value.GetObjectIds();
					}
					if (array3 != null)
					{
						mdiActiveDocument.Editor.SetImpliedSelection(array3);
					}
					transaction2.Commit();
					transaction2.Dispose();
				}
				IL_238:
				goto IL_2DF;
				IL_23D:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_299:
				goto IL_2D4;
				IL_29B:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_23D;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2B1:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_29B;
			}
			IL_2D4:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2DF:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button23_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				ArrayList arrayList = new ArrayList();
				IL_35:
				num2 = 5;
				string text = "";
				IL_3D:
				num2 = 6;
				IL_46:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_54:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 9;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection();
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Entity entity = (Entity)transaction.GetObject(selectedObject.ObjectId, 0);
								string text2 = Conversions.ToString(entity.ColorIndex);
								if (!arrayList.Contains(text2))
								{
									text = text + text2 + ",";
									arrayList.Add(text2);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
					transaction.Dispose();
				}
				IL_14D:
				num2 = 11;
				text = text.Substring(0, checked(text.Length - 1));
				IL_160:
				num2 = 12;
				string str = text.Replace(",", "\r\n");
				IL_175:
				num2 = 13;
				Interaction.MsgBox("颜色\r\n" + str, MsgBoxStyle.OkOnly, null);
				IL_18C:
				num2 = 14;
				TypedValue[] array = new TypedValue[1];
				IL_197:
				num2 = 15;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(62, text);
				array2.SetValue(typedValue, 0);
				IL_1B3:
				num2 = 16;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_1BF:
				num2 = 17;
				ObjectId[] array3 = null;
				IL_1C5:
				num2 = 18;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection2 = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection2.Status == 5100)
					{
						array3 = selection2.Value.GetObjectIds();
					}
					if (array3 != null)
					{
						mdiActiveDocument.Editor.SetImpliedSelection(array3);
					}
					transaction2.Commit();
					transaction2.Dispose();
				}
				IL_23E:
				goto IL_2E5;
				IL_243:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_29F:
				goto IL_2DA;
				IL_2A1:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_243;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2B7:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2A1;
			}
			IL_2DA:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_2E5:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button21_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				ArrayList arrayList = new ArrayList();
				IL_35:
				num2 = 5;
				string text = "";
				IL_3D:
				num2 = 6;
				IL_46:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_54:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 9;
				TypedValue[] array = new TypedValue[1];
				IL_6A:
				num2 = 10;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Text");
				array2.SetValue(typedValue, 0);
				IL_89:
				num2 = 11;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_95:
				num2 = 12;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								DBText dbtext = (DBText)transaction.GetObject(selectedObject.ObjectId, 0);
								string textString = dbtext.TextString;
								if (!arrayList.Contains(textString))
								{
									text = text + textString + ",";
									arrayList.Add(textString);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
					transaction.Dispose();
				}
				IL_180:
				num2 = 14;
				text = text.Substring(0, checked(text.Length - 1));
				IL_193:
				num2 = 15;
				string str = text.Replace(",", "\r\n");
				IL_1A8:
				num2 = 16;
				Interaction.MsgBox("文字:\r\n" + str, MsgBoxStyle.OkOnly, null);
				IL_1BF:
				num2 = 17;
				Array array3 = array;
				typedValue..ctor(1, text);
				array3.SetValue(typedValue, 0);
				IL_1DA:
				num2 = 18;
				selectionFilter = new SelectionFilter(array);
				IL_1E6:
				num2 = 19;
				ObjectId[] array4 = null;
				IL_1EC:
				num2 = 20;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection2 = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection2.Status == 5100)
					{
						array4 = selection2.Value.GetObjectIds();
					}
					if (array4 != null)
					{
						mdiActiveDocument.Editor.SetImpliedSelection(array4);
					}
					transaction2.Commit();
					transaction2.Dispose();
				}
				IL_265:
				goto IL_314;
				IL_26A:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2CE:
				goto IL_309;
				IL_2D0:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_26A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2E6:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2D0;
			}
			IL_309:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_314:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button20_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				ArrayList arrayList = new ArrayList();
				IL_35:
				num2 = 5;
				string text = "";
				IL_3D:
				num2 = 6;
				IL_46:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_54:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 9;
				TypedValue[] array = new TypedValue[1];
				IL_6A:
				num2 = 10;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Insert");
				array2.SetValue(typedValue, 0);
				IL_89:
				num2 = 11;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_95:
				num2 = 12;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								BlockReference blockReference = (BlockReference)transaction.GetObject(selectedObject.ObjectId, 0);
								BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockReference.BlockTableRecord, 0);
								string name = blockTableRecord.Name;
								if (!arrayList.Contains(name))
								{
									text = text + name + ",";
									arrayList.Add(name);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
					transaction.Dispose();
				}
				IL_196:
				num2 = 14;
				text = text.Substring(0, checked(text.Length - 1));
				IL_1A9:
				num2 = 15;
				string str = text.Replace(",", "\r\n");
				IL_1BE:
				num2 = 16;
				Interaction.MsgBox("图块:\r\n" + str, MsgBoxStyle.OkOnly, null);
				IL_1D5:
				num2 = 17;
				Array array3 = array;
				typedValue..ctor(2, text);
				array3.SetValue(typedValue, 0);
				IL_1F0:
				num2 = 18;
				selectionFilter = new SelectionFilter(array);
				IL_1FC:
				num2 = 19;
				ObjectId[] array4 = null;
				IL_202:
				num2 = 20;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection2 = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection2.Status == 5100)
					{
						array4 = selection2.Value.GetObjectIds();
					}
					if (array4 != null)
					{
						mdiActiveDocument.Editor.SetImpliedSelection(array4);
					}
					transaction2.Commit();
					transaction2.Dispose();
				}
				IL_27B:
				goto IL_32A;
				IL_280:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2E4:
				goto IL_31F;
				IL_2E6:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_280;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2FC:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2E6;
			}
			IL_31F:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_32A:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button22_Click(object sender, EventArgs e)
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
				this.Hide();
				IL_11:
				num2 = 3;
				Filter_Frm.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				IL_2D:
				num2 = 4;
				ArrayList arrayList = new ArrayList();
				IL_35:
				num2 = 5;
				string text = "";
				IL_3D:
				num2 = 6;
				IL_46:
				num2 = 7;
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				IL_54:
				num2 = 8;
				Database database = mdiActiveDocument.Database;
				IL_5F:
				num2 = 9;
				TypedValue[] array = new TypedValue[1];
				IL_6A:
				num2 = 10;
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Line");
				array2.SetValue(typedValue, 0);
				IL_89:
				num2 = 11;
				SelectionFilter selectionFilter = new SelectionFilter(array);
				IL_95:
				num2 = 12;
				using (Transaction transaction = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						IEnumerator enumerator = value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							SelectedObject selectedObject = (SelectedObject)obj;
							if (!Information.IsDBNull(selectedObject))
							{
								Line line = (Line)transaction.GetObject(selectedObject.ObjectId, 0);
								string text2 = Conversions.ToString(line.Angle);
								if (!arrayList.Contains(text2))
								{
									text = text + text2 + ",";
									arrayList.Add(text2);
								}
							}
						}
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					transaction.Commit();
					transaction.Dispose();
				}
				IL_185:
				num2 = 14;
				text = text.Substring(0, checked(text.Length - 1));
				IL_198:
				num2 = 15;
				string str = text.Replace(",", "\r\n");
				IL_1AD:
				num2 = 16;
				Interaction.MsgBox("角度:\r\n" + str, MsgBoxStyle.OkOnly, null);
				IL_1C4:
				num2 = 17;
				Array array3 = array;
				typedValue..ctor(50, text);
				array3.SetValue(typedValue, 0);
				IL_1E0:
				num2 = 18;
				selectionFilter = new SelectionFilter(array);
				IL_1EC:
				num2 = 19;
				ObjectId[] array4 = null;
				IL_1F2:
				num2 = 20;
				using (Transaction transaction2 = database.TransactionManager.StartTransaction())
				{
					PromptSelectionResult selection2 = mdiActiveDocument.Editor.GetSelection(selectionFilter);
					if (selection2.Status == 5100)
					{
						array4 = selection2.Value.GetObjectIds();
					}
					if (array4 != null)
					{
						mdiActiveDocument.Editor.SetImpliedSelection(array4);
					}
					transaction2.Commit();
					transaction2.Dispose();
				}
				IL_26B:
				goto IL_31A;
				IL_270:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_2D4:
				goto IL_30F;
				IL_2D6:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_270;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_2EC:;
			}
			catch when (endfilter(obj2 is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj3;
				goto IL_2D6;
			}
			IL_30F:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_31A:
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		private void Button9_Click(object sender, EventArgs e)
		{
		}

		private static List<WeakReference> list_0;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("TextBox2")]
		private TextBox _TextBox2;

		[AccessedThroughProperty("TextBox4")]
		private TextBox _TextBox4;

		[AccessedThroughProperty("TextBox3")]
		private TextBox _TextBox3;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("TextBox5")]
		private TextBox _TextBox5;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("TextBox6")]
		private TextBox _TextBox6;

		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		[AccessedThroughProperty("TextBox7")]
		private TextBox _TextBox7;

		[AccessedThroughProperty("Button8")]
		private Button _Button8;

		[AccessedThroughProperty("TextBox8")]
		private TextBox _TextBox8;

		[AccessedThroughProperty("Button9")]
		private Button _Button9;

		[AccessedThroughProperty("Button10")]
		private Button _Button10;

		[AccessedThroughProperty("Button11")]
		private Button _Button11;

		[AccessedThroughProperty("Button12")]
		private Button _Button12;

		[AccessedThroughProperty("Button13")]
		private Button _Button13;

		[AccessedThroughProperty("Button14")]
		private Button _Button14;

		[AccessedThroughProperty("Button15")]
		private Button _Button15;

		[AccessedThroughProperty("Button16")]
		private Button _Button16;

		[AccessedThroughProperty("Button17")]
		private Button _Button17;

		[AccessedThroughProperty("Button18")]
		private Button _Button18;

		[AccessedThroughProperty("Button19")]
		private Button _Button19;

		[AccessedThroughProperty("Button20")]
		private Button _Button20;

		[AccessedThroughProperty("Button21")]
		private Button _Button21;

		[AccessedThroughProperty("Button22")]
		private Button _Button22;

		[AccessedThroughProperty("Button23")]
		private Button _Button23;

		[AccessedThroughProperty("Button24")]
		private Button _Button24;

		[AccessedThroughProperty("Button25")]
		private Button _Button25;
	}
}
