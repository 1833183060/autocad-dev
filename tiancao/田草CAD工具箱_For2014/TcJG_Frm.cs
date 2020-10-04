using System;
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
	public class TcJG_Frm : UserControl
	{
		[DebuggerNonUserCode]
		static TcJG_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			TcJG_Frm.list_0 = new List<WeakReference>();
		}

		public TcJG_Frm()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			TcJG_Frm.smethod_0(this);
			this.document_0 = Application.DocumentManager.MdiActiveDocument;
			this.database_0 = HostApplicationServices.WorkingDatabase;
			this.InitializeComponent();
		}

		[DebuggerNonUserCode]
		private static void smethod_0(object object_0)
		{
			List<WeakReference> obj = TcJG_Frm.list_0;
			checked
			{
				lock (obj)
				{
					if (TcJG_Frm.list_0.Count == TcJG_Frm.list_0.Capacity)
					{
						int num = 0;
						int num2 = 0;
						int num3 = TcJG_Frm.list_0.Count - 1;
						int num4 = num2;
						for (;;)
						{
							int num5 = num4;
							int num6 = num3;
							if (num5 > num6)
							{
								break;
							}
							WeakReference weakReference = TcJG_Frm.list_0[num4];
							if (weakReference.IsAlive)
							{
								if (num4 != num)
								{
									TcJG_Frm.list_0[num] = TcJG_Frm.list_0[num4];
								}
								num++;
							}
							num4++;
						}
						TcJG_Frm.list_0.RemoveRange(num, TcJG_Frm.list_0.Count - num);
						TcJG_Frm.list_0.Capacity = TcJG_Frm.list_0.Count;
					}
					TcJG_Frm.list_0.Add(new WeakReference(RuntimeHelpers.GetObjectValue(object_0)));
				}
			}
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Button2 = new Button();
			this.Button3 = new Button();
			this.Button4 = new Button();
			this.Button7 = new Button();
			this.Button10 = new Button();
			this.Button11 = new Button();
			this.Button13 = new Button();
			this.Button23 = new Button();
			this.TabControl1 = new TabControl();
			this.TabPage1 = new TabPage();
			this.Button_12 = new Button();
			this.Button_8 = new Button();
			this.Button94 = new Button();
			this.Button95 = new Button();
			this.Button52 = new Button();
			this.Button57 = new Button();
			this.Button56 = new Button();
			this.Button48 = new Button();
			this.Button41 = new Button();
			this.Button38 = new Button();
			this.Button37 = new Button();
			this.Button29 = new Button();
			this.Button26 = new Button();
			this.TabPage2 = new TabPage();
			this.Button_21 = new Button();
			this.Button_11 = new Button();
			this.Button_10 = new Button();
			this.Button_9 = new Button();
			this.Button_7 = new Button();
			this.Button_5 = new Button();
			this.Button_4 = new Button();
			this.Button71 = new Button();
			this.Button72 = new Button();
			this.Button73 = new Button();
			this.Button34 = new Button();
			this.Button28 = new Button();
			this.Button9 = new Button();
			this.Button17 = new Button();
			this.Button36 = new Button();
			this.Button20 = new Button();
			this.Button32 = new Button();
			this.Button22 = new Button();
			this.Button31 = new Button();
			this.Button18 = new Button();
			this.Button14 = new Button();
			this.TabPage3 = new TabPage();
			this.Button30 = new Button();
			this.Button_14 = new Button();
			this.Button_3 = new Button();
			this.Button_0 = new Button();
			this.Button_1 = new Button();
			this.Button_2 = new Button();
			this.Button96 = new Button();
			this.Button51 = new Button();
			this.Button35 = new Button();
			this.Button33 = new Button();
			this.Button19 = new Button();
			this.Button58 = new Button();
			this.Button55 = new Button();
			this.Button44 = new Button();
			this.Button43 = new Button();
			this.Button42 = new Button();
			this.TabPage6 = new TabPage();
			this.Button_22 = new Button();
			this.Button_23 = new Button();
			this.Button99 = new Button();
			this.Button98 = new Button();
			this.Button_20 = new Button();
			this.Button5 = new Button();
			this.Button_19 = new Button();
			this.Button_18 = new Button();
			this.Button_17 = new Button();
			this.Button_16 = new Button();
			this.Button_15 = new Button();
			this.Button97 = new Button();
			this.TabPage4 = new TabPage();
			this.Button47 = new Button();
			this.Button46 = new Button();
			this.Button45 = new Button();
			this.Button6 = new Button();
			this.TabPage5 = new TabPage();
			this.ComboBox1 = new ComboBox();
			this.Button12 = new Button();
			this.SplitContainer1 = new SplitContainer();
			this.GroupBox1 = new GroupBox();
			this.Button_13 = new Button();
			this.Button_6 = new Button();
			this.Button60 = new Button();
			this.Button59 = new Button();
			this.Button27 = new Button();
			this.Button25 = new Button();
			this.Button21 = new Button();
			this.Button8 = new Button();
			this.Label1 = new Label();
			this.Button54 = new Button();
			this.Button50 = new Button();
			this.TextBox1 = new TextBox();
			this.Button49 = new Button();
			this.Button24 = new Button();
			this.Button40 = new Button();
			this.Button39 = new Button();
			this.Button16 = new Button();
			this.Button15 = new Button();
			this.Button1 = new Button();
			this.Button53 = new Button();
			this.Button61 = new Button();
			this.Button62 = new Button();
			this.Button63 = new Button();
			this.Button64 = new Button();
			this.Button65 = new Button();
			this.Button66 = new Button();
			this.Button67 = new Button();
			this.Button68 = new Button();
			this.Button69 = new Button();
			this.Button70 = new Button();
			this.Button74 = new Button();
			this.Button75 = new Button();
			this.Button76 = new Button();
			this.Button77 = new Button();
			this.Button78 = new Button();
			this.Button79 = new Button();
			this.Button80 = new Button();
			this.Button81 = new Button();
			this.Button82 = new Button();
			this.Button83 = new Button();
			this.Button84 = new Button();
			this.Button85 = new Button();
			this.Button86 = new Button();
			this.Button87 = new Button();
			this.Button88 = new Button();
			this.Button89 = new Button();
			this.Button90 = new Button();
			this.Button91 = new Button();
			this.Button92 = new Button();
			this.Button93 = new Button();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TabPage3.SuspendLayout();
			this.TabPage6.SuspendLayout();
			this.TabPage4.SuspendLayout();
			((ISupportInitialize)this.SplitContainer1).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			Control button = this.Button2;
			Point location = new Point(5, 242);
			button.Location = location;
			this.Button2.Name = "Button2";
			Control button2 = this.Button2;
			Size size = new Size(65, 23);
			button2.Size = size;
			this.Button2.TabIndex = 1;
			this.Button2.Text = "结构图库";
			this.Button2.UseVisualStyleBackColor = true;
			Control button3 = this.Button3;
			location = new Point(-1, 271);
			button3.Location = location;
			this.Button3.Name = "Button3";
			Control button4 = this.Button3;
			size = new Size(68, 23);
			button4.Size = size;
			this.Button3.TabIndex = 2;
			this.Button3.Text = "计算工具";
			this.Button3.UseVisualStyleBackColor = true;
			Control button5 = this.Button4;
			location = new Point(5, 213);
			button5.Location = location;
			this.Button4.Name = "Button4";
			Control button6 = this.Button4;
			size = new Size(65, 23);
			button6.Size = size;
			this.Button4.TabIndex = 3;
			this.Button4.Text = "实体填充";
			this.Button4.UseVisualStyleBackColor = true;
			Control button7 = this.Button7;
			location = new Point(6, 6);
			button7.Location = location;
			this.Button7.Name = "Button7";
			Control button8 = this.Button7;
			size = new Size(41, 23);
			button8.Size = size;
			this.Button7.TabIndex = 9;
			this.Button7.Text = "梁表";
			this.Button7.UseVisualStyleBackColor = true;
			Control button9 = this.Button10;
			location = new Point(6, 121);
			button9.Location = location;
			this.Button10.Name = "Button10";
			Control button10 = this.Button10;
			size = new Size(64, 23);
			button10.Size = size;
			this.Button10.TabIndex = 6;
			this.Button10.Text = "梁配筋率";
			this.Button10.UseVisualStyleBackColor = true;
			Control button11 = this.Button11;
			location = new Point(6, 6);
			button11.Location = location;
			this.Button11.Name = "Button11";
			Control button12 = this.Button11;
			size = new Size(88, 23);
			button12.Size = size;
			this.Button11.TabIndex = 10;
			this.Button11.Text = "柱配筋率As";
			this.Button11.UseVisualStyleBackColor = true;
			Control button13 = this.Button13;
			location = new Point(140, 155);
			button13.Location = location;
			this.Button13.Name = "Button13";
			Control button14 = this.Button13;
			size = new Size(54, 23);
			button14.Size = size;
			this.Button13.TabIndex = 12;
			this.Button13.Text = "ToPL";
			this.Button13.UseVisualStyleBackColor = true;
			Control button15 = this.Button23;
			location = new Point(6, 94);
			button15.Location = location;
			this.Button23.Name = "Button23";
			Control button16 = this.Button23;
			size = new Size(64, 23);
			button16.Size = size;
			this.Button23.TabIndex = 22;
			this.Button23.Text = "拖动(框)";
			this.Button23.UseVisualStyleBackColor = true;
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Controls.Add(this.TabPage6);
			this.TabControl1.Controls.Add(this.TabPage4);
			this.TabControl1.Controls.Add(this.TabPage5);
			this.TabControl1.Dock = DockStyle.Fill;
			Control tabControl = this.TabControl1;
			location = new Point(0, 0);
			tabControl.Location = location;
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			Control tabControl2 = this.TabControl1;
			size = new Size(208, 225);
			tabControl2.Size = size;
			this.TabControl1.TabIndex = 33;
			this.TabPage1.Controls.Add(this.Button_12);
			this.TabPage1.Controls.Add(this.Button_8);
			this.TabPage1.Controls.Add(this.Button94);
			this.TabPage1.Controls.Add(this.Button95);
			this.TabPage1.Controls.Add(this.Button52);
			this.TabPage1.Controls.Add(this.Button57);
			this.TabPage1.Controls.Add(this.Button56);
			this.TabPage1.Controls.Add(this.Button48);
			this.TabPage1.Controls.Add(this.Button41);
			this.TabPage1.Controls.Add(this.Button38);
			this.TabPage1.Controls.Add(this.Button37);
			this.TabPage1.Controls.Add(this.Button29);
			this.TabPage1.Controls.Add(this.Button26);
			this.TabPage1.Controls.Add(this.Button11);
			TabPage tabPage = this.TabPage1;
			location = new Point(4, 22);
			tabPage.Location = location;
			this.TabPage1.Name = "TabPage1";
			Control tabPage2 = this.TabPage1;
			Padding padding = new Padding(3);
			tabPage2.Padding = padding;
			Control tabPage3 = this.TabPage1;
			size = new Size(200, 199);
			tabPage3.Size = size;
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "柱";
			this.TabPage1.UseVisualStyleBackColor = true;
			Control control = this.Button_12;
			location = new Point(140, 35);
			control.Location = location;
			this.Button_12.Name = "Button122";
			Control control2 = this.Button_12;
			size = new Size(47, 23);
			control2.Size = size;
			this.Button_12.TabIndex = 53;
			this.Button_12.Text = "标注2";
			this.Button_12.UseVisualStyleBackColor = true;
			Control control3 = this.Button_8;
			location = new Point(100, 35);
			control3.Location = location;
			this.Button_8.Name = "Button118";
			Control control4 = this.Button_8;
			size = new Size(45, 23);
			control4.Size = size;
			this.Button_8.TabIndex = 52;
			this.Button_8.Text = "标注1";
			this.Button_8.UseVisualStyleBackColor = true;
			Control button17 = this.Button94;
			location = new Point(6, 122);
			button17.Location = location;
			this.Button94.Name = "Button94";
			Control button18 = this.Button94;
			size = new Size(91, 23);
			button18.Size = size;
			this.Button94.TabIndex = 51;
			this.Button94.Text = "YJK柱箍筋";
			this.Button94.UseVisualStyleBackColor = true;
			Control button19 = this.Button95;
			location = new Point(100, 122);
			button19.Location = location;
			this.Button95.Name = "Button95";
			Control button20 = this.Button95;
			size = new Size(89, 23);
			button20.Size = size;
			this.Button95.TabIndex = 50;
			this.Button95.Text = "YJK柱拉筋";
			this.Button95.UseVisualStyleBackColor = true;
			Control button21 = this.Button52;
			location = new Point(6, 155);
			button21.Location = location;
			this.Button52.Name = "Button52";
			Control button22 = this.Button52;
			size = new Size(62, 23);
			button22.Size = size;
			this.Button52.TabIndex = 49;
			this.Button52.Text = "等距布筋";
			this.Button52.UseVisualStyleBackColor = true;
			Control button23 = this.Button57;
			location = new Point(69, 64);
			button23.Location = location;
			this.Button57.Name = "Button57";
			Control button24 = this.Button57;
			size = new Size(56, 23);
			button24.Size = size;
			this.Button57.TabIndex = 47;
			this.Button57.Text = "柱拉筋";
			this.Button57.UseVisualStyleBackColor = true;
			Control button25 = this.Button56;
			location = new Point(5, 64);
			button25.Location = location;
			this.Button56.Name = "Button56";
			Control button26 = this.Button56;
			size = new Size(52, 23);
			button26.Size = size;
			this.Button56.TabIndex = 46;
			this.Button56.Text = "柱箍筋";
			this.Button56.UseVisualStyleBackColor = true;
			Control button27 = this.Button48;
			location = new Point(100, 6);
			button27.Location = location;
			this.Button48.Name = "Button48";
			Control button28 = this.Button48;
			size = new Size(88, 23);
			button28.Size = size;
			this.Button48.TabIndex = 45;
			this.Button48.Text = "柱配箍率Asv";
			this.Button48.UseVisualStyleBackColor = true;
			Control button29 = this.Button41;
			location = new Point(6, 35);
			button29.Location = location;
			this.Button41.Name = "Button41";
			Control button30 = this.Button41;
			size = new Size(51, 23);
			button30.Size = size;
			this.Button41.TabIndex = 44;
			this.Button41.Text = "柱截面";
			this.Button41.UseVisualStyleBackColor = true;
			Control button31 = this.Button38;
			location = new Point(131, 64);
			button31.Location = location;
			this.Button38.Name = "Button38";
			Control button32 = this.Button38;
			size = new Size(56, 23);
			button32.Size = size;
			this.Button38.TabIndex = 43;
			this.Button38.Text = "柱表";
			this.Button38.UseVisualStyleBackColor = true;
			Control button33 = this.Button37;
			location = new Point(63, 35);
			button33.Location = location;
			this.Button37.Name = "Button37";
			Control button34 = this.Button37;
			size = new Size(40, 23);
			button34.Size = size;
			this.Button37.TabIndex = 42;
			this.Button37.Text = "标注";
			this.Button37.UseVisualStyleBackColor = true;
			Control button35 = this.Button29;
			location = new Point(5, 93);
			button35.Location = location;
			this.Button29.Name = "Button29";
			Control button36 = this.Button29;
			size = new Size(91, 23);
			button36.Size = size;
			this.Button29.TabIndex = 37;
			this.Button29.Text = "PKPM柱箍筋";
			this.Button29.UseVisualStyleBackColor = true;
			Control button37 = this.Button26;
			location = new Point(99, 93);
			button37.Location = location;
			this.Button26.Name = "Button26";
			Control button38 = this.Button26;
			size = new Size(89, 23);
			button38.Size = size;
			this.Button26.TabIndex = 34;
			this.Button26.Text = "PKPM柱拉筋";
			this.Button26.UseVisualStyleBackColor = true;
			this.TabPage2.Controls.Add(this.Button_21);
			this.TabPage2.Controls.Add(this.Button_11);
			this.TabPage2.Controls.Add(this.Button_10);
			this.TabPage2.Controls.Add(this.Button_9);
			this.TabPage2.Controls.Add(this.Button_7);
			this.TabPage2.Controls.Add(this.Button_5);
			this.TabPage2.Controls.Add(this.Button_4);
			this.TabPage2.Controls.Add(this.Button71);
			this.TabPage2.Controls.Add(this.Button72);
			this.TabPage2.Controls.Add(this.Button73);
			this.TabPage2.Controls.Add(this.Button34);
			this.TabPage2.Controls.Add(this.Button28);
			this.TabPage2.Controls.Add(this.Button9);
			this.TabPage2.Controls.Add(this.Button17);
			this.TabPage2.Controls.Add(this.Button36);
			this.TabPage2.Controls.Add(this.Button20);
			this.TabPage2.Controls.Add(this.Button32);
			this.TabPage2.Controls.Add(this.Button22);
			this.TabPage2.Controls.Add(this.Button31);
			this.TabPage2.Controls.Add(this.Button18);
			this.TabPage2.Controls.Add(this.Button14);
			TabPage tabPage4 = this.TabPage2;
			location = new Point(4, 22);
			tabPage4.Location = location;
			this.TabPage2.Name = "TabPage2";
			Control tabPage5 = this.TabPage2;
			padding = new Padding(3);
			tabPage5.Padding = padding;
			Control tabPage6 = this.TabPage2;
			size = new Size(200, 199);
			tabPage6.Size = size;
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "墙";
			this.TabPage2.UseVisualStyleBackColor = true;
			Control control5 = this.Button_21;
			location = new Point(7, 174);
			control5.Location = location;
			this.Button_21.Name = "Button131";
			Control control6 = this.Button_21;
			size = new Size(62, 23);
			control6.Size = size;
			this.Button_21.TabIndex = 59;
			this.Button_21.Text = "箍筋大样";
			this.Button_21.UseVisualStyleBackColor = true;
			Control control7 = this.Button_11;
			location = new Point(163, 65);
			control7.Location = location;
			this.Button_11.Name = "Button121";
			Control control8 = this.Button_11;
			size = new Size(22, 23);
			control8.Size = size;
			this.Button_11.TabIndex = 58;
			this.Button_11.Text = "2";
			this.Button_11.UseVisualStyleBackColor = true;
			Control control9 = this.Button_10;
			location = new Point(163, 36);
			control9.Location = location;
			this.Button_10.Name = "Button120";
			Control control10 = this.Button_10;
			size = new Size(22, 23);
			control10.Size = size;
			this.Button_10.TabIndex = 57;
			this.Button_10.Text = "2";
			this.Button_10.UseVisualStyleBackColor = true;
			Control control11 = this.Button_9;
			location = new Point(135, 65);
			control11.Location = location;
			this.Button_9.Name = "Button119";
			Control control12 = this.Button_9;
			size = new Size(22, 23);
			control12.Size = size;
			this.Button_9.TabIndex = 56;
			this.Button_9.Text = "1";
			this.Button_9.UseVisualStyleBackColor = true;
			Control control13 = this.Button_7;
			location = new Point(135, 36);
			control13.Location = location;
			this.Button_7.Name = "Button117";
			Control control14 = this.Button_7;
			size = new Size(22, 23);
			control14.Size = size;
			this.Button_7.TabIndex = 55;
			this.Button_7.Text = "1";
			this.Button_7.UseVisualStyleBackColor = true;
			Control control15 = this.Button_5;
			location = new Point(135, 6);
			control15.Location = location;
			this.Button_5.Name = "Button115";
			Control control16 = this.Button_5;
			size = new Size(50, 23);
			control16.Size = size;
			this.Button_5.TabIndex = 54;
			this.Button_5.Text = "Asv1";
			this.Button_5.UseVisualStyleBackColor = true;
			Control control17 = this.Button_4;
			location = new Point(42, 6);
			control17.Location = location;
			this.Button_4.Name = "Button114";
			Control control18 = this.Button_4;
			size = new Size(30, 23);
			control18.Size = size;
			this.Button_4.TabIndex = 53;
			this.Button_4.Text = "As1";
			this.Button_4.UseVisualStyleBackColor = true;
			Control button39 = this.Button71;
			location = new Point(6, 123);
			button39.Location = location;
			this.Button71.Name = "Button71";
			Control button40 = this.Button71;
			size = new Size(53, 23);
			button40.Size = size;
			this.Button71.TabIndex = 52;
			this.Button71.Text = "YJK大";
			this.Button71.UseVisualStyleBackColor = true;
			Control button41 = this.Button72;
			location = new Point(65, 123);
			button41.Location = location;
			this.Button72.Name = "Button72";
			Control button42 = this.Button72;
			size = new Size(53, 23);
			button42.Size = size;
			this.Button72.TabIndex = 51;
			this.Button72.Text = "YJK小";
			this.Button72.UseVisualStyleBackColor = true;
			Control button43 = this.Button73;
			location = new Point(122, 122);
			button43.Location = location;
			this.Button73.Name = "Button73";
			Control button44 = this.Button73;
			size = new Size(55, 23);
			button44.Size = size;
			this.Button73.TabIndex = 50;
			this.Button73.Text = "YJK拉";
			this.Button73.UseVisualStyleBackColor = true;
			Control button45 = this.Button34;
			location = new Point(65, 65);
			button45.Location = location;
			this.Button34.Name = "Button34";
			Control button46 = this.Button34;
			size = new Size(64, 23);
			button46.Size = size;
			this.Button34.TabIndex = 49;
			this.Button34.Text = "墙肢标注";
			this.Button34.UseVisualStyleBackColor = true;
			Control button47 = this.Button28;
			location = new Point(74, 150);
			button47.Location = location;
			this.Button28.Name = "Button28";
			Control button48 = this.Button28;
			size = new Size(63, 23);
			button48.Size = size;
			this.Button28.TabIndex = 43;
			this.Button28.Text = "纵筋统计";
			this.Button28.UseVisualStyleBackColor = true;
			Control button49 = this.Button9;
			location = new Point(6, 64);
			button49.Location = location;
			this.Button9.Name = "Button9";
			Control button50 = this.Button9;
			size = new Size(53, 23);
			button50.Size = size;
			this.Button9.TabIndex = 42;
			this.Button9.Text = "重编号";
			this.Button9.UseVisualStyleBackColor = true;
			Control button51 = this.Button17;
			location = new Point(87, 6);
			button51.Location = location;
			this.Button17.Name = "Button17";
			Control button52 = this.Button17;
			size = new Size(42, 23);
			button52.Size = size;
			this.Button17.TabIndex = 41;
			this.Button17.Text = "Asv";
			this.Button17.UseVisualStyleBackColor = true;
			Control button53 = this.Button36;
			location = new Point(65, 36);
			button53.Location = location;
			this.Button36.Name = "Button36";
			Control button54 = this.Button36;
			size = new Size(64, 23);
			button54.Size = size;
			this.Button36.TabIndex = 40;
			this.Button36.Text = "墙柱标注";
			this.Button36.UseVisualStyleBackColor = true;
			Control button55 = this.Button20;
			location = new Point(7, 149);
			button55.Location = location;
			this.Button20.Name = "Button20";
			Control button56 = this.Button20;
			size = new Size(62, 23);
			button56.Size = size;
			this.Button20.TabIndex = 48;
			this.Button20.Text = "等距布筋";
			this.Button20.UseVisualStyleBackColor = true;
			Control button57 = this.Button32;
			location = new Point(6, 93);
			button57.Location = location;
			this.Button32.Name = "Button32";
			Control button58 = this.Button32;
			size = new Size(53, 23);
			button58.Size = size;
			this.Button32.TabIndex = 35;
			this.Button32.Text = "大箍筋";
			this.Button32.UseVisualStyleBackColor = true;
			Control button59 = this.Button22;
			location = new Point(6, 35);
			button59.Location = location;
			this.Button22.Name = "Button22";
			Control button60 = this.Button22;
			size = new Size(53, 23);
			button60.Size = size;
			this.Button22.TabIndex = 21;
			this.Button22.Text = "墙柱表";
			this.Button22.UseVisualStyleBackColor = true;
			Control button61 = this.Button31;
			location = new Point(65, 94);
			button61.Location = location;
			this.Button31.Name = "Button31";
			Control button62 = this.Button31;
			size = new Size(53, 23);
			button62.Size = size;
			this.Button31.TabIndex = 34;
			this.Button31.Text = "小箍筋";
			this.Button31.UseVisualStyleBackColor = true;
			Control button63 = this.Button18;
			location = new Point(122, 93);
			button63.Location = location;
			this.Button18.Name = "Button18";
			Control button64 = this.Button18;
			size = new Size(55, 23);
			button64.Size = size;
			this.Button18.TabIndex = 33;
			this.Button18.Text = "墙拉筋";
			this.Button18.UseVisualStyleBackColor = true;
			Control button65 = this.Button14;
			location = new Point(6, 6);
			button65.Location = location;
			this.Button14.Name = "Button14";
			Control button66 = this.Button14;
			size = new Size(30, 23);
			button66.Size = size;
			this.Button14.TabIndex = 32;
			this.Button14.Text = "As";
			this.Button14.UseVisualStyleBackColor = true;
			this.TabPage3.Controls.Add(this.Button30);
			this.TabPage3.Controls.Add(this.Button_14);
			this.TabPage3.Controls.Add(this.Button_3);
			this.TabPage3.Controls.Add(this.Button_0);
			this.TabPage3.Controls.Add(this.Button_1);
			this.TabPage3.Controls.Add(this.Button_2);
			this.TabPage3.Controls.Add(this.Button96);
			this.TabPage3.Controls.Add(this.Button51);
			this.TabPage3.Controls.Add(this.Button35);
			this.TabPage3.Controls.Add(this.Button33);
			this.TabPage3.Controls.Add(this.Button19);
			this.TabPage3.Controls.Add(this.Button58);
			this.TabPage3.Controls.Add(this.Button55);
			this.TabPage3.Controls.Add(this.Button44);
			this.TabPage3.Controls.Add(this.Button43);
			this.TabPage3.Controls.Add(this.Button42);
			this.TabPage3.Controls.Add(this.Button10);
			this.TabPage3.Controls.Add(this.Button7);
			this.TabPage3.Controls.Add(this.Button23);
			TabPage tabPage7 = this.TabPage3;
			location = new Point(4, 22);
			tabPage7.Location = location;
			this.TabPage3.Name = "TabPage3";
			Control tabPage8 = this.TabPage3;
			padding = new Padding(3);
			tabPage8.Padding = padding;
			Control tabPage9 = this.TabPage3;
			size = new Size(200, 199);
			tabPage9.Size = size;
			this.TabPage3.TabIndex = 2;
			this.TabPage3.Text = "梁";
			this.TabPage3.UseVisualStyleBackColor = true;
			Control button67 = this.Button30;
			location = new Point(130, 121);
			button67.Location = location;
			this.Button30.Name = "Button30";
			Control button68 = this.Button30;
			size = new Size(67, 23);
			button68.Size = size;
			this.Button30.TabIndex = 60;
			this.Button30.Text = "梁镜像Y集";
			this.Button30.UseVisualStyleBackColor = true;
			Control control19 = this.Button_14;
			location = new Point(73, 65);
			control19.Location = location;
			this.Button_14.Name = "Button124";
			Control control20 = this.Button_14;
			size = new Size(51, 23);
			control20.Size = size;
			this.Button_14.TabIndex = 59;
			this.Button_14.Text = "梁线";
			this.Button_14.UseVisualStyleBackColor = true;
			Control control21 = this.Button_3;
			location = new Point(74, 93);
			control21.Location = location;
			this.Button_3.Name = "Button113";
			Control control22 = this.Button_3;
			size = new Size(51, 23);
			control22.Size = size;
			this.Button_3.TabIndex = 58;
			this.Button_3.Text = "LL合并";
			this.Button_3.UseVisualStyleBackColor = true;
			Control control23 = this.Button_0;
			location = new Point(130, 174);
			control23.Location = location;
			this.Button_0.Name = "Button112";
			Control control24 = this.Button_0;
			size = new Size(68, 23);
			control24.Size = size;
			this.Button_0.TabIndex = 57;
			this.Button_0.Text = "梁镜像X";
			this.Button_0.UseVisualStyleBackColor = true;
			Control control25 = this.Button_1;
			location = new Point(130, 148);
			control25.Location = location;
			this.Button_1.Name = "Button111";
			Control control26 = this.Button_1;
			size = new Size(68, 23);
			control26.Size = size;
			this.Button_1.TabIndex = 56;
			this.Button_1.Text = "梁镜像YB";
			this.Button_1.UseVisualStyleBackColor = true;
			Control control27 = this.Button_2;
			location = new Point(130, 93);
			control27.Location = location;
			this.Button_2.Name = "Button110";
			Control control28 = this.Button_2;
			size = new Size(67, 23);
			control28.Size = size;
			this.Button_2.TabIndex = 55;
			this.Button_2.Text = "梁镜像Y原";
			this.Button_2.UseVisualStyleBackColor = true;
			Control button69 = this.Button96;
			location = new Point(130, 64);
			button69.Location = location;
			this.Button96.Name = "Button96";
			Control button70 = this.Button96;
			size = new Size(66, 23);
			button70.Size = size;
			this.Button96.TabIndex = 54;
			this.Button96.Text = "编号归并";
			this.Button96.UseVisualStyleBackColor = true;
			Control button71 = this.Button51;
			location = new Point(7, 64);
			button71.Location = location;
			this.Button51.Name = "Button51";
			Control button72 = this.Button51;
			size = new Size(63, 23);
			button72.Size = size;
			this.Button51.TabIndex = 53;
			this.Button51.Text = "拖动(点)";
			this.Button51.UseVisualStyleBackColor = true;
			Control button73 = this.Button35;
			location = new Point(65, 35);
			button73.Location = location;
			this.Button35.Name = "Button35";
			Control button74 = this.Button35;
			size = new Size(64, 23);
			button74.Size = size;
			this.Button35.TabIndex = 52;
			this.Button35.Text = "重编号+";
			this.Button35.UseVisualStyleBackColor = true;
			Control button75 = this.Button33;
			location = new Point(132, 6);
			button75.Location = location;
			this.Button33.Name = "Button33";
			Control button76 = this.Button33;
			size = new Size(62, 23);
			button76.Size = size;
			this.Button33.TabIndex = 51;
			this.Button33.Text = "对齐交换";
			this.Button33.UseVisualStyleBackColor = true;
			Control button77 = this.Button19;
			location = new Point(51, 6);
			button77.Location = location;
			this.Button19.Name = "Button19";
			Control button78 = this.Button19;
			size = new Size(80, 23);
			button78.Size = size;
			this.Button19.TabIndex = 50;
			this.Button19.Text = "梁分XY方向";
			this.Button19.UseVisualStyleBackColor = true;
			Control button79 = this.Button58;
			location = new Point(73, 148);
			button79.Location = location;
			this.Button58.Name = "Button58";
			Control button80 = this.Button58;
			size = new Size(50, 23);
			button80.Size = size;
			this.Button58.TabIndex = 49;
			this.Button58.Text = "梁拉筋";
			this.Button58.UseVisualStyleBackColor = true;
			Control button81 = this.Button55;
			location = new Point(132, 35);
			button81.Location = location;
			this.Button55.Name = "Button55";
			Control button82 = this.Button55;
			size = new Size(64, 23);
			button82.Size = size;
			this.Button55.TabIndex = 48;
			this.Button55.Text = "编号检查";
			this.Button55.UseVisualStyleBackColor = true;
			Control button83 = this.Button44;
			location = new Point(6, 35);
			button83.Location = location;
			this.Button44.Name = "Button44";
			Control button84 = this.Button44;
			size = new Size(51, 23);
			button84.Size = size;
			this.Button44.TabIndex = 47;
			this.Button44.Text = "重编号";
			this.Button44.UseVisualStyleBackColor = true;
			Control button85 = this.Button43;
			location = new Point(5, 148);
			button85.Location = location;
			this.Button43.Name = "Button43";
			Control button86 = this.Button43;
			size = new Size(64, 23);
			button86.Size = size;
			this.Button43.TabIndex = 46;
			this.Button43.Text = "附加箍筋";
			this.Button43.UseVisualStyleBackColor = true;
			Control button87 = this.Button42;
			location = new Point(74, 121);
			button87.Location = location;
			this.Button42.Name = "Button42";
			Control button88 = this.Button42;
			size = new Size(51, 23);
			button88.Size = size;
			this.Button42.TabIndex = 45;
			this.Button42.Text = "梁截面";
			this.Button42.UseVisualStyleBackColor = true;
			this.TabPage6.Controls.Add(this.Button_22);
			this.TabPage6.Controls.Add(this.Button_23);
			this.TabPage6.Controls.Add(this.Button99);
			this.TabPage6.Controls.Add(this.Button98);
			this.TabPage6.Controls.Add(this.Button_20);
			this.TabPage6.Controls.Add(this.Button5);
			this.TabPage6.Controls.Add(this.Button_19);
			this.TabPage6.Controls.Add(this.Button_18);
			this.TabPage6.Controls.Add(this.Button_17);
			this.TabPage6.Controls.Add(this.Button_16);
			this.TabPage6.Controls.Add(this.Button_15);
			this.TabPage6.Controls.Add(this.Button97);
			TabPage tabPage10 = this.TabPage6;
			location = new Point(4, 22);
			tabPage10.Location = location;
			this.TabPage6.Name = "TabPage6";
			Control tabPage11 = this.TabPage6;
			padding = new Padding(3);
			tabPage11.Padding = padding;
			Control tabPage12 = this.TabPage6;
			size = new Size(200, 199);
			tabPage12.Size = size;
			this.TabPage6.TabIndex = 5;
			this.TabPage6.Text = "板";
			this.TabPage6.UseVisualStyleBackColor = true;
			Control control29 = this.Button_22;
			location = new Point(125, 93);
			control29.Location = location;
			this.Button_22.Name = "Button101";
			Control control30 = this.Button_22;
			size = new Size(72, 23);
			control30.Size = size;
			this.Button_22.TabIndex = 72;
			this.Button_22.Text = "大板加腋";
			this.Button_22.UseVisualStyleBackColor = true;
			Control control31 = this.Button_23;
			location = new Point(125, 122);
			control31.Location = location;
			this.Button_23.Name = "Button100";
			Control control32 = this.Button_23;
			size = new Size(72, 23);
			control32.Size = size;
			this.Button_23.TabIndex = 71;
			this.Button_23.Text = "楼板开洞";
			this.Button_23.UseVisualStyleBackColor = true;
			Control button89 = this.Button99;
			location = new Point(124, 64);
			button89.Location = location;
			this.Button99.Name = "Button99";
			Control button90 = this.Button99;
			size = new Size(74, 23);
			button90.Size = size;
			this.Button99.TabIndex = 70;
			this.Button99.Text = "板筋矫正Y";
			this.Button99.UseVisualStyleBackColor = true;
			Control button91 = this.Button98;
			location = new Point(124, 35);
			button91.Location = location;
			this.Button98.Name = "Button98";
			Control button92 = this.Button98;
			size = new Size(73, 23);
			button92.Size = size;
			this.Button98.TabIndex = 69;
			this.Button98.Text = "板筋矫正X";
			this.Button98.UseVisualStyleBackColor = true;
			Control control33 = this.Button_20;
			location = new Point(8, 122);
			control33.Location = location;
			this.Button_20.Name = "Button130";
			Control control34 = this.Button_20;
			size = new Size(108, 23);
			control34.Size = size;
			this.Button_20.TabIndex = 68;
			this.Button_20.Text = "搜索楼板(结构)";
			this.Button_20.UseVisualStyleBackColor = true;
			Control button93 = this.Button5;
			location = new Point(8, 93);
			button93.Location = location;
			this.Button5.Name = "Button5";
			Control button94 = this.Button5;
			size = new Size(108, 23);
			button94.Size = size;
			this.Button5.TabIndex = 67;
			this.Button5.Text = "搜索楼板(天正)";
			this.Button5.UseVisualStyleBackColor = true;
			Control control35 = this.Button_19;
			location = new Point(8, 64);
			control35.Location = location;
			this.Button_19.Name = "Button129";
			Control control36 = this.Button_19;
			size = new Size(67, 23);
			control36.Size = size;
			this.Button_19.TabIndex = 66;
			this.Button_19.Text = "去通删除";
			this.Button_19.UseVisualStyleBackColor = true;
			Control control37 = this.Button_18;
			location = new Point(8, 35);
			control37.Location = location;
			this.Button_18.Name = "Button128";
			Control control38 = this.Button_18;
			size = new Size(67, 23);
			control38.Size = size;
			this.Button_18.TabIndex = 65;
			this.Button_18.Text = "E8200";
			this.Button_18.UseVisualStyleBackColor = true;
			Control control39 = this.Button_17;
			location = new Point(8, 151);
			control39.Location = location;
			this.Button_17.Name = "Button127";
			Control control40 = this.Button_17;
			size = new Size(45, 23);
			control40.Size = size;
			this.Button_17.TabIndex = 64;
			this.Button_17.Text = "附加";
			this.Button_17.UseVisualStyleBackColor = true;
			Control control41 = this.Button_16;
			location = new Point(151, 6);
			control41.Location = location;
			this.Button_16.Name = "Button126";
			Control control42 = this.Button_16;
			size = new Size(46, 23);
			control42.Size = size;
			this.Button_16.TabIndex = 63;
			this.Button_16.Text = "去钩";
			this.Button_16.UseVisualStyleBackColor = true;
			Control control43 = this.Button_15;
			location = new Point(81, 6);
			control43.Location = location;
			this.Button_15.Name = "Button125";
			Control control44 = this.Button_15;
			size = new Size(64, 23);
			control44.Size = size;
			this.Button_15.TabIndex = 62;
			this.Button_15.Text = "板筋附加";
			this.Button_15.UseVisualStyleBackColor = true;
			Control button95 = this.Button97;
			location = new Point(8, 6);
			button95.Location = location;
			this.Button97.Name = "Button97";
			Control button96 = this.Button97;
			size = new Size(67, 23);
			button96.Size = size;
			this.Button97.TabIndex = 61;
			this.Button97.Text = "板筋镜像";
			this.Button97.UseVisualStyleBackColor = true;
			this.TabPage4.Controls.Add(this.Button47);
			this.TabPage4.Controls.Add(this.Button46);
			this.TabPage4.Controls.Add(this.Button45);
			this.TabPage4.Controls.Add(this.Button6);
			TabPage tabPage13 = this.TabPage4;
			location = new Point(4, 22);
			tabPage13.Location = location;
			this.TabPage4.Name = "TabPage4";
			Control tabPage14 = this.TabPage4;
			padding = new Padding(3);
			tabPage14.Padding = padding;
			Control tabPage15 = this.TabPage4;
			size = new Size(200, 199);
			tabPage15.Size = size;
			this.TabPage4.TabIndex = 3;
			this.TabPage4.Text = "基础";
			this.TabPage4.UseVisualStyleBackColor = true;
			Control button97 = this.Button47;
			location = new Point(6, 93);
			button97.Location = location;
			this.Button47.Name = "Button47";
			Control button98 = this.Button47;
			size = new Size(75, 23);
			button98.Size = size;
			this.Button47.TabIndex = 45;
			this.Button47.Text = "两桩承台";
			this.Button47.UseVisualStyleBackColor = true;
			Control button99 = this.Button46;
			location = new Point(6, 64);
			button99.Location = location;
			this.Button46.Name = "Button46";
			Control button100 = this.Button46;
			size = new Size(75, 23);
			button100.Size = size;
			this.Button46.TabIndex = 44;
			this.Button46.Text = "三桩承台";
			this.Button46.UseVisualStyleBackColor = true;
			Control button101 = this.Button45;
			location = new Point(6, 35);
			button101.Location = location;
			this.Button45.Name = "Button45";
			Control button102 = this.Button45;
			size = new Size(75, 23);
			button102.Size = size;
			this.Button45.TabIndex = 43;
			this.Button45.Text = "桩位编号";
			this.Button45.UseVisualStyleBackColor = true;
			Control button103 = this.Button6;
			location = new Point(6, 6);
			button103.Location = location;
			this.Button6.Name = "Button6";
			Control button104 = this.Button6;
			size = new Size(75, 23);
			button104.Size = size;
			this.Button6.TabIndex = 42;
			this.Button6.Text = "独立基础";
			this.Button6.UseVisualStyleBackColor = true;
			TabPage tabPage16 = this.TabPage5;
			location = new Point(4, 22);
			tabPage16.Location = location;
			this.TabPage5.Name = "TabPage5";
			Control tabPage17 = this.TabPage5;
			padding = new Padding(3);
			tabPage17.Padding = padding;
			Control tabPage18 = this.TabPage5;
			size = new Size(200, 199);
			tabPage18.Size = size;
			this.TabPage5.TabIndex = 4;
			this.TabPage5.Text = "装配";
			this.TabPage5.UseVisualStyleBackColor = true;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.Items.AddRange(new object[]
			{
				"1:20",
				"1:25",
				"1:30",
				"1:40",
				"1:50",
				"1:100"
			});
			Control comboBox = this.ComboBox1;
			location = new Point(62, 17);
			comboBox.Location = location;
			this.ComboBox1.Name = "ComboBox1";
			Control comboBox2 = this.ComboBox1;
			size = new Size(57, 20);
			comboBox2.Size = size;
			this.ComboBox1.TabIndex = 48;
			this.ComboBox1.Text = "1:40";
			Control button105 = this.Button12;
			location = new Point(73, 68);
			button105.Location = location;
			this.Button12.Name = "Button12";
			Control button106 = this.Button12;
			size = new Size(62, 23);
			button106.Size = size;
			this.Button12.TabIndex = 40;
			this.Button12.Text = "填充(实)";
			this.Button12.UseVisualStyleBackColor = true;
			Control splitContainer = this.SplitContainer1;
			location = new Point(0, 0);
			splitContainer.Location = location;
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Orientation = Orientation.Horizontal;
			this.SplitContainer1.Panel1.Controls.Add(this.TabControl1);
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox1);
			Control splitContainer2 = this.SplitContainer1;
			size = new Size(208, 687);
			splitContainer2.Size = size;
			this.SplitContainer1.SplitterDistance = 225;
			this.SplitContainer1.TabIndex = 41;
			this.GroupBox1.Controls.Add(this.Button_13);
			this.GroupBox1.Controls.Add(this.Button_6);
			this.GroupBox1.Controls.Add(this.Button60);
			this.GroupBox1.Controls.Add(this.Button59);
			this.GroupBox1.Controls.Add(this.Button27);
			this.GroupBox1.Controls.Add(this.Button25);
			this.GroupBox1.Controls.Add(this.Button21);
			this.GroupBox1.Controls.Add(this.Button8);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.ComboBox1);
			this.GroupBox1.Controls.Add(this.Button54);
			this.GroupBox1.Controls.Add(this.Button50);
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Controls.Add(this.Button49);
			this.GroupBox1.Controls.Add(this.Button24);
			this.GroupBox1.Controls.Add(this.Button40);
			this.GroupBox1.Controls.Add(this.Button39);
			this.GroupBox1.Controls.Add(this.Button16);
			this.GroupBox1.Controls.Add(this.Button15);
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Controls.Add(this.Button12);
			this.GroupBox1.Controls.Add(this.Button2);
			this.GroupBox1.Controls.Add(this.Button3);
			this.GroupBox1.Controls.Add(this.Button4);
			this.GroupBox1.Controls.Add(this.Button13);
			Control groupBox = this.GroupBox1;
			location = new Point(4, 3);
			groupBox.Location = location;
			this.GroupBox1.Name = "GroupBox1";
			Control groupBox2 = this.GroupBox1;
			size = new Size(199, 319);
			groupBox2.Size = size;
			this.GroupBox1.TabIndex = 63;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "通用";
			Control control45 = this.Button_13;
			location = new Point(69, 213);
			control45.Location = location;
			this.Button_13.Name = "Button123";
			Control control46 = this.Button_13;
			size = new Size(66, 23);
			control46.Size = size;
			this.Button_13.TabIndex = 62;
			this.Button_13.Text = "标注避让";
			this.Button_13.UseVisualStyleBackColor = true;
			Control control47 = this.Button_6;
			location = new Point(6, 155);
			control47.Location = location;
			this.Button_6.Name = "Button116";
			Control control48 = this.Button_6;
			size = new Size(62, 23);
			control48.Size = size;
			this.Button_6.TabIndex = 61;
			this.Button_6.Text = "YJK转换";
			this.Button_6.UseVisualStyleBackColor = true;
			Control button107 = this.Button60;
			location = new Point(6, 97);
			button107.Location = location;
			this.Button60.Name = "Button60";
			Control button108 = this.Button60;
			size = new Size(62, 23);
			button108.Size = size;
			this.Button60.TabIndex = 59;
			this.Button60.Text = "匿名组";
			this.Button60.UseVisualStyleBackColor = true;
			Control button109 = this.Button59;
			location = new Point(6, 68);
			button109.Location = location;
			this.Button59.Name = "Button59";
			Control button110 = this.Button59;
			size = new Size(62, 23);
			button110.Size = size;
			this.Button59.TabIndex = 58;
			this.Button59.Text = "匿名块";
			this.Button59.UseVisualStyleBackColor = true;
			Control button111 = this.Button27;
			location = new Point(139, 213);
			button111.Location = location;
			this.Button27.Name = "Button27";
			Control button112 = this.Button27;
			size = new Size(53, 23);
			button112.Size = size;
			this.Button27.TabIndex = 56;
			this.Button27.Text = "计算器";
			this.Button27.UseVisualStyleBackColor = true;
			Control button113 = this.Button25;
			location = new Point(72, 271);
			button113.Location = location;
			this.Button25.Name = "Button25";
			Control button114 = this.Button25;
			size = new Size(73, 23);
			button114.Size = size;
			this.Button25.TabIndex = 55;
			this.Button25.Text = "ShowPic";
			this.Button25.UseVisualStyleBackColor = true;
			Control button115 = this.Button21;
			location = new Point(139, 242);
			button115.Location = location;
			this.Button21.Name = "Button21";
			Control button116 = this.Button21;
			size = new Size(54, 23);
			button116.Size = size;
			this.Button21.TabIndex = 54;
			this.Button21.Text = "钢筋表";
			this.Button21.UseVisualStyleBackColor = true;
			Control button117 = this.Button8;
			location = new Point(139, 70);
			button117.Location = location;
			this.Button8.Name = "Button8";
			Control button118 = this.Button8;
			size = new Size(54, 23);
			button118.Size = size;
			this.Button8.TabIndex = 53;
			this.Button8.Text = "构件表";
			this.Button8.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			Control label = this.Label1;
			location = new Point(3, 20);
			label.Location = location;
			this.Label1.Name = "Label1";
			Control label2 = this.Label1;
			size = new Size(53, 12);
			label2.Size = size;
			this.Label1.TabIndex = 52;
			this.Label1.Text = "绘图比例";
			Control button119 = this.Button54;
			location = new Point(139, 97);
			button119.Location = location;
			this.Button54.Name = "Button54";
			Control button120 = this.Button54;
			size = new Size(54, 23);
			button120.Size = size;
			this.Button54.TabIndex = 51;
			this.Button54.Text = "文本刷";
			this.Button54.UseVisualStyleBackColor = true;
			Control button121 = this.Button50;
			location = new Point(140, 41);
			button121.Location = location;
			this.Button50.Name = "Button50";
			Control button122 = this.Button50;
			size = new Size(53, 23);
			button122.Size = size;
			this.Button50.TabIndex = 50;
			this.Button50.Text = "CMD";
			this.Button50.UseVisualStyleBackColor = true;
			Control textBox = this.TextBox1;
			location = new Point(5, 43);
			textBox.Location = location;
			this.TextBox1.Name = "TextBox1";
			Control textBox2 = this.TextBox1;
			size = new Size(128, 21);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 49;
			this.TextBox1.Text = "(dictremove (namedobjdict) \"ACAD_DGNLINESTYLECOMP\")";
			Control button123 = this.Button49;
			location = new Point(73, 97);
			button123.Location = location;
			this.Button49.Name = "Button49";
			Control button124 = this.Button49;
			size = new Size(61, 23);
			button124.Size = size;
			this.Button49.TabIndex = 48;
			this.Button49.Text = "填充(砼)";
			this.Button49.UseVisualStyleBackColor = true;
			Control button125 = this.Button24;
			location = new Point(73, 184);
			button125.Location = location;
			this.Button24.Name = "Button24";
			Control button126 = this.Button24;
			size = new Size(60, 23);
			button126.Size = size;
			this.Button24.TabIndex = 47;
			this.Button24.Text = "过  滤";
			this.Button24.UseVisualStyleBackColor = true;
			Control button127 = this.Button40;
			location = new Point(72, 126);
			button127.Location = location;
			this.Button40.Name = "Button40";
			Control button128 = this.Button40;
			size = new Size(62, 23);
			button128.Size = size;
			this.Button40.TabIndex = 46;
			this.Button40.Text = "重命名";
			this.Button40.UseVisualStyleBackColor = true;
			Control button129 = this.Button39;
			location = new Point(72, 155);
			button129.Location = location;
			this.Button39.Name = "Button39";
			Control button130 = this.Button39;
			size = new Size(62, 23);
			button130.Size = size;
			this.Button39.TabIndex = 45;
			this.Button39.Text = "TcHRB";
			this.Button39.UseVisualStyleBackColor = true;
			Control button131 = this.Button16;
			location = new Point(139, 184);
			button131.Location = location;
			this.Button16.Name = "Button16";
			Control button132 = this.Button16;
			size = new Size(52, 23);
			button132.Size = size;
			this.Button16.TabIndex = 44;
			this.Button16.Text = "层高表";
			this.Button16.UseVisualStyleBackColor = true;
			Control button133 = this.Button15;
			location = new Point(69, 242);
			button133.Location = location;
			this.Button15.Name = "Button15";
			Control button134 = this.Button15;
			size = new Size(62, 23);
			button134.Size = size;
			this.Button15.TabIndex = 43;
			this.Button15.Text = "楼  梯";
			this.Button15.UseVisualStyleBackColor = true;
			Control button135 = this.Button1;
			location = new Point(5, 126);
			button135.Location = location;
			this.Button1.Name = "Button1";
			Control button136 = this.Button1;
			size = new Size(62, 23);
			button136.Size = size;
			this.Button1.TabIndex = 41;
			this.Button1.Text = "PKPM转换";
			this.Button1.UseVisualStyleBackColor = true;
			Control button137 = this.Button53;
			location = new Point(7, 93);
			button137.Location = location;
			this.Button53.Name = "Button53";
			Control button138 = this.Button53;
			size = new Size(53, 23);
			button138.Size = size;
			this.Button53.TabIndex = 35;
			this.Button53.Text = "大箍筋";
			this.Button53.UseVisualStyleBackColor = true;
			Control button139 = this.Button61;
			location = new Point(87, 64);
			button139.Location = location;
			this.Button61.Name = "Button61";
			Control button140 = this.Button61;
			size = new Size(88, 23);
			button140.Size = size;
			this.Button61.TabIndex = 49;
			this.Button61.Text = "墙肢尺寸标注";
			this.Button61.UseVisualStyleBackColor = true;
			Control button141 = this.Button62;
			location = new Point(74, 152);
			button141.Location = location;
			this.Button62.Name = "Button62";
			Control button142 = this.Button62;
			size = new Size(63, 23);
			button142.Size = size;
			this.Button62.TabIndex = 43;
			this.Button62.Text = "纵筋统计";
			this.Button62.UseVisualStyleBackColor = true;
			Control button143 = this.Button63;
			location = new Point(6, 64);
			button143.Location = location;
			this.Button63.Name = "Button63";
			Control button144 = this.Button63;
			size = new Size(75, 23);
			button144.Size = size;
			this.Button63.TabIndex = 42;
			this.Button63.Text = "重编号";
			this.Button63.UseVisualStyleBackColor = true;
			Control button145 = this.Button64;
			location = new Point(87, 6);
			button145.Location = location;
			this.Button64.Name = "Button64";
			Control button146 = this.Button64;
			size = new Size(89, 23);
			button146.Size = size;
			this.Button64.TabIndex = 41;
			this.Button64.Text = "墙配箍率Asv";
			this.Button64.UseVisualStyleBackColor = true;
			Control button147 = this.Button65;
			location = new Point(88, 35);
			button147.Location = location;
			this.Button65.Name = "Button65";
			Control button148 = this.Button65;
			size = new Size(88, 23);
			button148.Size = size;
			this.Button65.TabIndex = 40;
			this.Button65.Text = "墙柱尺寸标注";
			this.Button65.UseVisualStyleBackColor = true;
			Control button149 = this.Button66;
			location = new Point(7, 151);
			button149.Location = location;
			this.Button66.Name = "Button66";
			Control button150 = this.Button66;
			size = new Size(62, 23);
			button150.Size = size;
			this.Button66.TabIndex = 48;
			this.Button66.Text = "等距布筋";
			this.Button66.UseVisualStyleBackColor = true;
			Control button151 = this.Button67;
			location = new Point(6, 35);
			button151.Location = location;
			this.Button67.Name = "Button67";
			Control button152 = this.Button67;
			size = new Size(75, 23);
			button152.Size = size;
			this.Button67.TabIndex = 21;
			this.Button67.Text = "墙柱表";
			this.Button67.UseVisualStyleBackColor = true;
			Control button153 = this.Button68;
			location = new Point(75, 94);
			button153.Location = location;
			this.Button68.Name = "Button68";
			Control button154 = this.Button68;
			size = new Size(53, 23);
			button154.Size = size;
			this.Button68.TabIndex = 34;
			this.Button68.Text = "小箍筋";
			this.Button68.UseVisualStyleBackColor = true;
			Control button155 = this.Button69;
			location = new Point(139, 93);
			button155.Location = location;
			this.Button69.Name = "Button69";
			Control button156 = this.Button69;
			size = new Size(55, 23);
			button156.Size = size;
			this.Button69.TabIndex = 33;
			this.Button69.Text = "墙拉筋";
			this.Button69.UseVisualStyleBackColor = true;
			Control button157 = this.Button70;
			location = new Point(6, 6);
			button157.Location = location;
			this.Button70.Name = "Button70";
			Control button158 = this.Button70;
			size = new Size(75, 23);
			button158.Size = size;
			this.Button70.TabIndex = 32;
			this.Button70.Text = "墙柱配筋As";
			this.Button70.UseVisualStyleBackColor = true;
			Control button159 = this.Button74;
			location = new Point(6, 155);
			button159.Location = location;
			this.Button74.Name = "Button74";
			Control button160 = this.Button74;
			size = new Size(62, 23);
			button160.Size = size;
			this.Button74.TabIndex = 49;
			this.Button74.Text = "等距布筋";
			this.Button74.UseVisualStyleBackColor = true;
			Control button161 = this.Button75;
			location = new Point(69, 64);
			button161.Location = location;
			this.Button75.Name = "Button75";
			Control button162 = this.Button75;
			size = new Size(56, 23);
			button162.Size = size;
			this.Button75.TabIndex = 47;
			this.Button75.Text = "柱拉筋";
			this.Button75.UseVisualStyleBackColor = true;
			Control button163 = this.Button76;
			location = new Point(5, 64);
			button163.Location = location;
			this.Button76.Name = "Button76";
			Control button164 = this.Button76;
			size = new Size(52, 23);
			button164.Size = size;
			this.Button76.TabIndex = 46;
			this.Button76.Text = "柱箍筋";
			this.Button76.UseVisualStyleBackColor = true;
			Control button165 = this.Button77;
			location = new Point(100, 6);
			button165.Location = location;
			this.Button77.Name = "Button77";
			Control button166 = this.Button77;
			size = new Size(88, 23);
			button166.Size = size;
			this.Button77.TabIndex = 45;
			this.Button77.Text = "柱配箍率Asv";
			this.Button77.UseVisualStyleBackColor = true;
			Control button167 = this.Button78;
			location = new Point(6, 35);
			button167.Location = location;
			this.Button78.Name = "Button78";
			Control button168 = this.Button78;
			size = new Size(51, 23);
			button168.Size = size;
			this.Button78.TabIndex = 44;
			this.Button78.Text = "柱截面";
			this.Button78.UseVisualStyleBackColor = true;
			Control button169 = this.Button79;
			location = new Point(132, 35);
			button169.Location = location;
			this.Button79.Name = "Button79";
			Control button170 = this.Button79;
			size = new Size(56, 23);
			button170.Size = size;
			this.Button79.TabIndex = 43;
			this.Button79.Text = "柱表";
			this.Button79.UseVisualStyleBackColor = true;
			Control button171 = this.Button80;
			location = new Point(69, 35);
			button171.Location = location;
			this.Button80.Name = "Button80";
			Control button172 = this.Button80;
			size = new Size(56, 23);
			button172.Size = size;
			this.Button80.TabIndex = 42;
			this.Button80.Text = "柱标注";
			this.Button80.UseVisualStyleBackColor = true;
			Control button173 = this.Button81;
			location = new Point(5, 93);
			button173.Location = location;
			this.Button81.Name = "Button81";
			Control button174 = this.Button81;
			size = new Size(91, 23);
			button174.Size = size;
			this.Button81.TabIndex = 37;
			this.Button81.Text = "PKPM柱箍筋";
			this.Button81.UseVisualStyleBackColor = true;
			Control button175 = this.Button82;
			location = new Point(99, 93);
			button175.Location = location;
			this.Button82.Name = "Button82";
			Control button176 = this.Button82;
			size = new Size(89, 23);
			button176.Size = size;
			this.Button82.TabIndex = 34;
			this.Button82.Text = "PKPM柱拉筋";
			this.Button82.UseVisualStyleBackColor = true;
			Control button177 = this.Button83;
			location = new Point(6, 6);
			button177.Location = location;
			this.Button83.Name = "Button83";
			Control button178 = this.Button83;
			size = new Size(88, 23);
			button178.Size = size;
			this.Button83.TabIndex = 10;
			this.Button83.Text = "柱配筋率As";
			this.Button83.UseVisualStyleBackColor = true;
			Control button179 = this.Button84;
			location = new Point(6, 155);
			button179.Location = location;
			this.Button84.Name = "Button84";
			Control button180 = this.Button84;
			size = new Size(62, 23);
			button180.Size = size;
			this.Button84.TabIndex = 49;
			this.Button84.Text = "等距布筋";
			this.Button84.UseVisualStyleBackColor = true;
			Control button181 = this.Button85;
			location = new Point(69, 64);
			button181.Location = location;
			this.Button85.Name = "Button85";
			Control button182 = this.Button85;
			size = new Size(56, 23);
			button182.Size = size;
			this.Button85.TabIndex = 47;
			this.Button85.Text = "柱拉筋";
			this.Button85.UseVisualStyleBackColor = true;
			Control button183 = this.Button86;
			location = new Point(5, 64);
			button183.Location = location;
			this.Button86.Name = "Button86";
			Control button184 = this.Button86;
			size = new Size(52, 23);
			button184.Size = size;
			this.Button86.TabIndex = 46;
			this.Button86.Text = "柱箍筋";
			this.Button86.UseVisualStyleBackColor = true;
			Control button185 = this.Button87;
			location = new Point(100, 6);
			button185.Location = location;
			this.Button87.Name = "Button87";
			Control button186 = this.Button87;
			size = new Size(88, 23);
			button186.Size = size;
			this.Button87.TabIndex = 45;
			this.Button87.Text = "柱配箍率Asv";
			this.Button87.UseVisualStyleBackColor = true;
			Control button187 = this.Button88;
			location = new Point(6, 35);
			button187.Location = location;
			this.Button88.Name = "Button88";
			Control button188 = this.Button88;
			size = new Size(51, 23);
			button188.Size = size;
			this.Button88.TabIndex = 44;
			this.Button88.Text = "柱截面";
			this.Button88.UseVisualStyleBackColor = true;
			Control button189 = this.Button89;
			location = new Point(132, 35);
			button189.Location = location;
			this.Button89.Name = "Button89";
			Control button190 = this.Button89;
			size = new Size(56, 23);
			button190.Size = size;
			this.Button89.TabIndex = 43;
			this.Button89.Text = "柱表";
			this.Button89.UseVisualStyleBackColor = true;
			Control button191 = this.Button90;
			location = new Point(69, 35);
			button191.Location = location;
			this.Button90.Name = "Button90";
			Control button192 = this.Button90;
			size = new Size(56, 23);
			button192.Size = size;
			this.Button90.TabIndex = 42;
			this.Button90.Text = "柱标注";
			this.Button90.UseVisualStyleBackColor = true;
			Control button193 = this.Button91;
			location = new Point(5, 93);
			button193.Location = location;
			this.Button91.Name = "Button91";
			Control button194 = this.Button91;
			size = new Size(91, 23);
			button194.Size = size;
			this.Button91.TabIndex = 37;
			this.Button91.Text = "PKPM柱箍筋";
			this.Button91.UseVisualStyleBackColor = true;
			Control button195 = this.Button92;
			location = new Point(99, 93);
			button195.Location = location;
			this.Button92.Name = "Button92";
			Control button196 = this.Button92;
			size = new Size(89, 23);
			button196.Size = size;
			this.Button92.TabIndex = 34;
			this.Button92.Text = "PKPM柱拉筋";
			this.Button92.UseVisualStyleBackColor = true;
			Control button197 = this.Button93;
			location = new Point(6, 6);
			button197.Location = location;
			this.Button93.Name = "Button93";
			Control button198 = this.Button93;
			size = new Size(88, 23);
			button198.Size = size;
			this.Button93.TabIndex = 10;
			this.Button93.Text = "柱配筋率As";
			this.Button93.UseVisualStyleBackColor = true;
			SizeF autoScaleDimensions = new SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.SplitContainer1);
			this.Name = "TcJG_Frm";
			size = new Size(215, 694);
			this.Size = size;
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage3.ResumeLayout(false);
			this.TabPage6.ResumeLayout(false);
			this.TabPage4.ResumeLayout(false);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			((ISupportInitialize)this.SplitContainer1).EndInit();
			this.SplitContainer1.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);
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
				EventHandler value2 = new EventHandler(this.Button4_Click);
				if (this._Button4 != null)
				{
					this._Button4.Click -= value2;
				}
				this._Button4 = value;
				if (this._Button4 != null)
				{
					this._Button4.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Button7_Click);
				if (this._Button7 != null)
				{
					this._Button7.Click -= value2;
				}
				this._Button7 = value;
				if (this._Button7 != null)
				{
					this._Button7.Click += value2;
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

		internal virtual Button Button13
		{
			[DebuggerNonUserCode]
			get
			{
				return this.NnGraoarmy;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button13_Click);
				if (this.NnGraoarmy != null)
				{
					this.NnGraoarmy.Click -= value2;
				}
				this.NnGraoarmy = value;
				if (this.NnGraoarmy != null)
				{
					this.NnGraoarmy.Click += value2;
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

		internal virtual TabControl TabControl1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabControl1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabControl1 = value;
			}
		}

		internal virtual TabPage TabPage1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage1 = value;
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

		internal virtual Button Button29
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button29;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button29_Click);
				if (this._Button29 != null)
				{
					this._Button29.Click -= value2;
				}
				this._Button29 = value;
				if (this._Button29 != null)
				{
					this._Button29.Click += value2;
				}
			}
		}

		internal virtual Button Button26
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button26;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button26_Click);
				if (this._Button26 != null)
				{
					this._Button26.Click -= value2;
				}
				this._Button26 = value;
				if (this._Button26 != null)
				{
					this._Button26.Click += value2;
				}
			}
		}

		internal virtual TabPage TabPage3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage3 = value;
			}
		}

		internal virtual Button Button37
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button37;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button37_Click);
				if (this._Button37 != null)
				{
					this._Button37.Click -= value2;
				}
				this._Button37 = value;
				if (this._Button37 != null)
				{
					this._Button37.Click += value2;
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

		internal virtual Button Button15
		{
			[DebuggerNonUserCode]
			get
			{
				return this.gntrwnIqfF;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button15_Click);
				if (this.gntrwnIqfF != null)
				{
					this.gntrwnIqfF.Click -= value2;
				}
				this.gntrwnIqfF = value;
				if (this.gntrwnIqfF != null)
				{
					this.gntrwnIqfF.Click += value2;
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

		internal virtual Button Button38
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button38;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button38_Click);
				if (this._Button38 != null)
				{
					this._Button38.Click -= value2;
				}
				this._Button38 = value;
				if (this._Button38 != null)
				{
					this._Button38.Click += value2;
				}
			}
		}

		internal virtual Button Button39
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button39;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button39_Click);
				if (this._Button39 != null)
				{
					this._Button39.Click -= value2;
				}
				this._Button39 = value;
				if (this._Button39 != null)
				{
					this._Button39.Click += value2;
				}
			}
		}

		internal virtual Button Button40
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button40;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button40_Click);
				if (this._Button40 != null)
				{
					this._Button40.Click -= value2;
				}
				this._Button40 = value;
				if (this._Button40 != null)
				{
					this._Button40.Click += value2;
				}
			}
		}

		internal virtual Button Button41
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button41;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button41_Click);
				if (this._Button41 != null)
				{
					this._Button41.Click -= value2;
				}
				this._Button41 = value;
				if (this._Button41 != null)
				{
					this._Button41.Click += value2;
				}
			}
		}

		internal virtual Button Button42
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button42;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button42_Click);
				if (this._Button42 != null)
				{
					this._Button42.Click -= value2;
				}
				this._Button42 = value;
				if (this._Button42 != null)
				{
					this._Button42.Click += value2;
				}
			}
		}

		internal virtual Button Button43
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button43;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button43_Click);
				if (this._Button43 != null)
				{
					this._Button43.Click -= value2;
				}
				this._Button43 = value;
				if (this._Button43 != null)
				{
					this._Button43.Click += value2;
				}
			}
		}

		internal virtual Button Button44
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button44;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button44_Click);
				if (this._Button44 != null)
				{
					this._Button44.Click -= value2;
				}
				this._Button44 = value;
				if (this._Button44 != null)
				{
					this._Button44.Click += value2;
				}
			}
		}

		internal virtual TabPage TabPage4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage4 = value;
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
				EventHandler value2 = new EventHandler(this.Button6_Click);
				if (this._Button6 != null)
				{
					this._Button6.Click -= value2;
				}
				this._Button6 = value;
				if (this._Button6 != null)
				{
					this._Button6.Click += value2;
				}
			}
		}

		internal virtual Button Button45
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button45;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button45_Click);
				if (this._Button45 != null)
				{
					this._Button45.Click -= value2;
				}
				this._Button45 = value;
				if (this._Button45 != null)
				{
					this._Button45.Click += value2;
				}
			}
		}

		internal virtual Button Button47
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button47;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button47_Click);
				if (this._Button47 != null)
				{
					this._Button47.Click -= value2;
				}
				this._Button47 = value;
				if (this._Button47 != null)
				{
					this._Button47.Click += value2;
				}
			}
		}

		internal virtual Button Button46
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button46;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button46_Click);
				if (this._Button46 != null)
				{
					this._Button46.Click -= value2;
				}
				this._Button46 = value;
				if (this._Button46 != null)
				{
					this._Button46.Click += value2;
				}
			}
		}

		internal virtual Button Button48
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button48;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button48_Click);
				if (this._Button48 != null)
				{
					this._Button48.Click -= value2;
				}
				this._Button48 = value;
				if (this._Button48 != null)
				{
					this._Button48.Click += value2;
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

		internal virtual Button Button49
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button49;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button49_Click);
				if (this._Button49 != null)
				{
					this._Button49.Click -= value2;
				}
				this._Button49 = value;
				if (this._Button49 != null)
				{
					this._Button49.Click += value2;
				}
			}
		}

		internal virtual Button Button50
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button50;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button50_Click);
				if (this._Button50 != null)
				{
					this._Button50.Click -= value2;
				}
				this._Button50 = value;
				if (this._Button50 != null)
				{
					this._Button50.Click += value2;
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

		internal virtual Button Button54
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button54;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button54_Click);
				if (this._Button54 != null)
				{
					this._Button54.Click -= value2;
				}
				this._Button54 = value;
				if (this._Button54 != null)
				{
					this._Button54.Click += value2;
				}
			}
		}

		internal virtual Button Button55
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button55;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button55_Click);
				if (this._Button55 != null)
				{
					this._Button55.Click -= value2;
				}
				this._Button55 = value;
				if (this._Button55 != null)
				{
					this._Button55.Click += value2;
				}
			}
		}

		internal virtual Button Button57
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button57;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button57_Click);
				if (this._Button57 != null)
				{
					this._Button57.Click -= value2;
				}
				this._Button57 = value;
				if (this._Button57 != null)
				{
					this._Button57.Click += value2;
				}
			}
		}

		internal virtual Button Button56
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button56;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button56_Click);
				if (this._Button56 != null)
				{
					this._Button56.Click -= value2;
				}
				this._Button56 = value;
				if (this._Button56 != null)
				{
					this._Button56.Click += value2;
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

		internal virtual Button Button58
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button58;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button58_Click);
				if (this._Button58 != null)
				{
					this._Button58.Click -= value2;
				}
				this._Button58 = value;
				if (this._Button58 != null)
				{
					this._Button58.Click += value2;
				}
			}
		}

		internal virtual TabPage TabPage2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage2 = value;
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

		internal virtual Button Button36
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button36;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button36_Click);
				if (this._Button36 != null)
				{
					this._Button36.Click -= value2;
				}
				this._Button36 = value;
				if (this._Button36 != null)
				{
					this._Button36.Click += value2;
				}
			}
		}

		internal virtual Button Button32
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button32;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button32_Click);
				if (this._Button32 != null)
				{
					this._Button32.Click -= value2;
				}
				this._Button32 = value;
				if (this._Button32 != null)
				{
					this._Button32.Click += value2;
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

		internal virtual Button Button31
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button31;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button31_Click);
				if (this._Button31 != null)
				{
					this._Button31.Click -= value2;
				}
				this._Button31 = value;
				if (this._Button31 != null)
				{
					this._Button31.Click += value2;
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
				EventHandler value2 = new EventHandler(this.Button18_Click);
				if (this._Button18 != null)
				{
					this._Button18.Click -= value2;
				}
				this._Button18 = value;
				if (this._Button18 != null)
				{
					this._Button18.Click += value2;
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
				EventHandler value2 = new EventHandler(this.jipAtgRsh);
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
				EventHandler value2 = new EventHandler(this.Button8_Click);
				if (this._Button8 != null)
				{
					this._Button8.Click -= value2;
				}
				this._Button8 = value;
				if (this._Button8 != null)
				{
					this._Button8.Click += value2;
				}
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
				EventHandler value2 = new EventHandler(this.Button19_Click);
				if (this._Button19 != null)
				{
					this._Button19.Click -= value2;
				}
				this._Button19 = value;
				if (this._Button19 != null)
				{
					this._Button19.Click += value2;
				}
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

		internal virtual Button Button27
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button27;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button27_Click);
				if (this._Button27 != null)
				{
					this._Button27.Click -= value2;
				}
				this._Button27 = value;
				if (this._Button27 != null)
				{
					this._Button27.Click += value2;
				}
			}
		}

		internal virtual Button Button28
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button28;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button28_Click);
				if (this._Button28 != null)
				{
					this._Button28.Click -= value2;
				}
				this._Button28 = value;
				if (this._Button28 != null)
				{
					this._Button28.Click += value2;
				}
			}
		}

		internal virtual Button Button33
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button33;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button33_Click);
				if (this._Button33 != null)
				{
					this._Button33.Click -= value2;
				}
				this._Button33 = value;
				if (this._Button33 != null)
				{
					this._Button33.Click += value2;
				}
			}
		}

		internal virtual Button Button34
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button34;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button34_Click);
				if (this._Button34 != null)
				{
					this._Button34.Click -= value2;
				}
				this._Button34 = value;
				if (this._Button34 != null)
				{
					this._Button34.Click += value2;
				}
			}
		}

		internal virtual Button Button35
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button35;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button35_Click);
				if (this._Button35 != null)
				{
					this._Button35.Click -= value2;
				}
				this._Button35 = value;
				if (this._Button35 != null)
				{
					this._Button35.Click += value2;
				}
			}
		}

		internal virtual Button Button51
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button51;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button51_Click);
				if (this._Button51 != null)
				{
					this._Button51.Click -= value2;
				}
				this._Button51 = value;
				if (this._Button51 != null)
				{
					this._Button51.Click += value2;
				}
			}
		}

		internal virtual Button Button59
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button59;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button59_Click);
				if (this._Button59 != null)
				{
					this._Button59.Click -= value2;
				}
				this._Button59 = value;
				if (this._Button59 != null)
				{
					this._Button59.Click += value2;
				}
			}
		}

		internal virtual Button Button60
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button60;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button60_Click);
				if (this._Button60 != null)
				{
					this._Button60.Click -= value2;
				}
				this._Button60 = value;
				if (this._Button60 != null)
				{
					this._Button60.Click += value2;
				}
			}
		}

		internal virtual Button Button52
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button52;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button52_Click);
				if (this._Button52 != null)
				{
					this._Button52.Click -= value2;
				}
				this._Button52 = value;
				if (this._Button52 != null)
				{
					this._Button52.Click += value2;
				}
			}
		}

		internal virtual Button Button71
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button71;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button71_Click);
				if (this._Button71 != null)
				{
					this._Button71.Click -= value2;
				}
				this._Button71 = value;
				if (this._Button71 != null)
				{
					this._Button71.Click += value2;
				}
			}
		}

		internal virtual Button Button72
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button72;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button72_Click);
				if (this._Button72 != null)
				{
					this._Button72.Click -= value2;
				}
				this._Button72 = value;
				if (this._Button72 != null)
				{
					this._Button72.Click += value2;
				}
			}
		}

		internal virtual Button Button73
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button73;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button73_Click);
				if (this._Button73 != null)
				{
					this._Button73.Click -= value2;
				}
				this._Button73 = value;
				if (this._Button73 != null)
				{
					this._Button73.Click += value2;
				}
			}
		}

		internal virtual Button Button53
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button53;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button53 = value;
			}
		}

		internal virtual Button Button61
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button61;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button61 = value;
			}
		}

		internal virtual Button Button62
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button62;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button62 = value;
			}
		}

		internal virtual Button Button63
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button63;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button63 = value;
			}
		}

		internal virtual Button Button64
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button64;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button64 = value;
			}
		}

		internal virtual Button Button65
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button65;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button65 = value;
			}
		}

		internal virtual Button Button66
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button66;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button66 = value;
			}
		}

		internal virtual Button Button67
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button67;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button67 = value;
			}
		}

		internal virtual Button Button68
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button68;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button68 = value;
			}
		}

		internal virtual Button Button69
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button69;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button69 = value;
			}
		}

		internal virtual Button Button70
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button70;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button70 = value;
			}
		}

		internal virtual Button Button74
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button74;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button74 = value;
			}
		}

		internal virtual Button Button75
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button75;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button75 = value;
			}
		}

		internal virtual Button Button76
		{
			[DebuggerNonUserCode]
			get
			{
				return this.ujxgLuqBou;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this.ujxgLuqBou = value;
			}
		}

		internal virtual Button Button77
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button77;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button77 = value;
			}
		}

		internal virtual Button Button78
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button78;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button78 = value;
			}
		}

		internal virtual Button Button79
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button79;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button79 = value;
			}
		}

		internal virtual Button Button80
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button80;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button80 = value;
			}
		}

		internal virtual Button Button81
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button81;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button81 = value;
			}
		}

		internal virtual Button Button82
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button82;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button82 = value;
			}
		}

		internal virtual Button Button83
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button83;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button83 = value;
			}
		}

		internal virtual Button Button84
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button84;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button84 = value;
			}
		}

		internal virtual Button Button85
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button85;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button85 = value;
			}
		}

		internal virtual Button Button86
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button86;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button86 = value;
			}
		}

		internal virtual Button Button87
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button87;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button87 = value;
			}
		}

		internal virtual Button Button88
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button88;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button88 = value;
			}
		}

		internal virtual Button Button89
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button89;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button89 = value;
			}
		}

		internal virtual Button Button90
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button90;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button90 = value;
			}
		}

		internal virtual Button Button91
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button91;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button91 = value;
			}
		}

		internal virtual Button Button92
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button92;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button92 = value;
			}
		}

		internal virtual Button Button93
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button93;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._Button93 = value;
			}
		}

		internal virtual Button Button94
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button94;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button94_Click);
				if (this._Button94 != null)
				{
					this._Button94.Click -= value2;
				}
				this._Button94 = value;
				if (this._Button94 != null)
				{
					this._Button94.Click += value2;
				}
			}
		}

		internal virtual Button Button95
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button95;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button95_Click);
				if (this._Button95 != null)
				{
					this._Button95.Click -= value2;
				}
				this._Button95 = value;
				if (this._Button95 != null)
				{
					this._Button95.Click += value2;
				}
			}
		}

		internal virtual Button Button96
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button96;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button96_Click);
				if (this._Button96 != null)
				{
					this._Button96.Click -= value2;
				}
				this._Button96 = value;
				if (this._Button96 != null)
				{
					this._Button96.Click += value2;
				}
			}
		}

		internal virtual TabPage TabPage5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage5 = value;
			}
		}

		internal virtual Button Button_0
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_0;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_0_Click);
				if (this.button_0 != null)
				{
					this.button_0.Click -= value2;
				}
				this.button_0 = value;
				if (this.button_0 != null)
				{
					this.button_0.Click += value2;
				}
			}
		}

		internal virtual Button Button_1
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_1_Click);
				if (this.button_1 != null)
				{
					this.button_1.Click -= value2;
				}
				this.button_1 = value;
				if (this.button_1 != null)
				{
					this.button_1.Click += value2;
				}
			}
		}

		internal virtual Button Button_2
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_2_Click);
				if (this.button_2 != null)
				{
					this.button_2.Click -= value2;
				}
				this.button_2 = value;
				if (this.button_2 != null)
				{
					this.button_2.Click += value2;
				}
			}
		}

		internal virtual Button Button_3
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_3_Click);
				if (this.button_3 != null)
				{
					this.button_3.Click -= value2;
				}
				this.button_3 = value;
				if (this.button_3 != null)
				{
					this.button_3.Click += value2;
				}
			}
		}

		internal virtual Button Button_4
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_4_Click);
				if (this.button_4 != null)
				{
					this.button_4.Click -= value2;
				}
				this.button_4 = value;
				if (this.button_4 != null)
				{
					this.button_4.Click += value2;
				}
			}
		}

		internal virtual Button Button_5
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_5_Click);
				if (this.button_5 != null)
				{
					this.button_5.Click -= value2;
				}
				this.button_5 = value;
				if (this.button_5 != null)
				{
					this.button_5.Click += value2;
				}
			}
		}

		internal virtual Button Button_6
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_6_Click);
				if (this.button_6 != null)
				{
					this.button_6.Click -= value2;
				}
				this.button_6 = value;
				if (this.button_6 != null)
				{
					this.button_6.Click += value2;
				}
			}
		}

		internal virtual Button Button_7
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_7_Click);
				if (this.button_7 != null)
				{
					this.button_7.Click -= value2;
				}
				this.button_7 = value;
				if (this.button_7 != null)
				{
					this.button_7.Click += value2;
				}
			}
		}

		internal virtual Button Button_8
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_8_Click);
				if (this.button_8 != null)
				{
					this.button_8.Click -= value2;
				}
				this.button_8 = value;
				if (this.button_8 != null)
				{
					this.button_8.Click += value2;
				}
			}
		}

		internal virtual Button Button_9
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_9_Click);
				if (this.button_9 != null)
				{
					this.button_9.Click -= value2;
				}
				this.button_9 = value;
				if (this.button_9 != null)
				{
					this.button_9.Click += value2;
				}
			}
		}

		internal virtual Button Button_10
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_10_Click);
				if (this.button_10 != null)
				{
					this.button_10.Click -= value2;
				}
				this.button_10 = value;
				if (this.button_10 != null)
				{
					this.button_10.Click += value2;
				}
			}
		}

		internal virtual Button Button_11
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_11_Click);
				if (this.button_11 != null)
				{
					this.button_11.Click -= value2;
				}
				this.button_11 = value;
				if (this.button_11 != null)
				{
					this.button_11.Click += value2;
				}
			}
		}

		internal virtual Button Button_12
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_12_Click);
				if (this.button_12 != null)
				{
					this.button_12.Click -= value2;
				}
				this.button_12 = value;
				if (this.button_12 != null)
				{
					this.button_12.Click += value2;
				}
			}
		}

		internal virtual Button Button_13
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_13;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_13_Click);
				if (this.button_13 != null)
				{
					this.button_13.Click -= value2;
				}
				this.button_13 = value;
				if (this.button_13 != null)
				{
					this.button_13.Click += value2;
				}
			}
		}

		internal virtual Button Button_14
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_14;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_14_Click);
				if (this.button_14 != null)
				{
					this.button_14.Click -= value2;
				}
				this.button_14 = value;
				if (this.button_14 != null)
				{
					this.button_14.Click += value2;
				}
			}
		}

		internal virtual TabPage TabPage6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._TabPage6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._TabPage6 = value;
			}
		}

		internal virtual Button Button_15
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_15;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_15_Click);
				if (this.button_15 != null)
				{
					this.button_15.Click -= value2;
				}
				this.button_15 = value;
				if (this.button_15 != null)
				{
					this.button_15.Click += value2;
				}
			}
		}

		internal virtual Button Button97
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button97;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button97_Click);
				if (this._Button97 != null)
				{
					this._Button97.Click -= value2;
				}
				this._Button97 = value;
				if (this._Button97 != null)
				{
					this._Button97.Click += value2;
				}
			}
		}

		internal virtual Button Button_16
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_16;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_16_Click);
				if (this.button_16 != null)
				{
					this.button_16.Click -= value2;
				}
				this.button_16 = value;
				if (this.button_16 != null)
				{
					this.button_16.Click += value2;
				}
			}
		}

		internal virtual Button Button_17
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_17;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_17_Click);
				if (this.button_17 != null)
				{
					this.button_17.Click -= value2;
				}
				this.button_17 = value;
				if (this.button_17 != null)
				{
					this.button_17.Click += value2;
				}
			}
		}

		internal virtual Button Button_18
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_18;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_18_Click);
				if (this.button_18 != null)
				{
					this.button_18.Click -= value2;
				}
				this.button_18 = value;
				if (this.button_18 != null)
				{
					this.button_18.Click += value2;
				}
			}
		}

		internal virtual Button Button_19
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_19;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_19_Click);
				if (this.button_19 != null)
				{
					this.button_19.Click -= value2;
				}
				this.button_19 = value;
				if (this.button_19 != null)
				{
					this.button_19.Click += value2;
				}
			}
		}

		internal virtual GroupBox GroupBox1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._GroupBox1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._GroupBox1 = value;
			}
		}

		internal virtual Button Button_20
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_20;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_20_Click);
				if (this.button_20 != null)
				{
					this.button_20.Click -= value2;
				}
				this.button_20 = value;
				if (this.button_20 != null)
				{
					this.button_20.Click += value2;
				}
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

		internal virtual Button Button_21
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_21;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_21_Click);
				if (this.button_21 != null)
				{
					this.button_21.Click -= value2;
				}
				this.button_21 = value;
				if (this.button_21 != null)
				{
					this.button_21.Click += value2;
				}
			}
		}

		internal virtual Button Button30
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button30;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button30_Click);
				if (this._Button30 != null)
				{
					this._Button30.Click -= value2;
				}
				this._Button30 = value;
				if (this._Button30 != null)
				{
					this._Button30.Click += value2;
				}
			}
		}

		internal virtual Button Button98
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button98;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button98_Click);
				if (this._Button98 != null)
				{
					this._Button98.Click -= value2;
				}
				this._Button98 = value;
				if (this._Button98 != null)
				{
					this._Button98.Click += value2;
				}
			}
		}

		internal virtual Button Button99
		{
			[DebuggerNonUserCode]
			get
			{
				return this._Button99;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button99_Click);
				if (this._Button99 != null)
				{
					this._Button99.Click -= value2;
				}
				this._Button99 = value;
				if (this._Button99 != null)
				{
					this._Button99.Click += value2;
				}
			}
		}

		internal virtual Button Button_22
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_22;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_22_Click);
				if (this.button_22 != null)
				{
					this.button_22.Click -= value2;
				}
				this.button_22 = value;
				if (this.button_22 != null)
				{
					this.button_22.Click += value2;
				}
			}
		}

		internal virtual Button Button_23
		{
			[DebuggerNonUserCode]
			get
			{
				return this.button_23;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler value2 = new EventHandler(this.Button_23_Click);
				if (this.button_23 != null)
				{
					this.button_23.Click -= value2;
				}
				this.button_23 = value;
				if (this.button_23 != null)
				{
					this.button_23.Click += value2;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button2_Click(object sender, EventArgs e)
		{
			string text = Class33.Class31_0.Info.DirectoryPath + "\\DWG\\结构图库.dwg";
			DocumentCollectionExtension.Open(Application.DocumentManager, text, false);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button3_Click(object sender, EventArgs e)
		{
			string pathName = Class33.Class31_0.Info.DirectoryPath + "\\田草结构计算工具箱.exe";
			Interaction.Shell(pathName, AppWinStyle.NormalFocus, false, -1);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DocumentLock documentLock = Application.DocumentManager.MdiActiveDocument.LockDocument();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			using (Transaction transaction = database.TransactionManager.StartTransaction())
			{
				TypedValue[] array = new TypedValue[1];
				Array array2 = array;
				TypedValue typedValue;
				typedValue..ctor(0, "Solid");
				array2.SetValue(typedValue, 0);
				SelectionFilter selectionFilter = new SelectionFilter(array);
				PromptSelectionResult selection = mdiActiveDocument.Editor.GetSelection(selectionFilter);
				if (selection.Status == 5100)
				{
					ObjectId[] objectIds = selection.Value.GetObjectIds();
					foreach (ObjectId objectId in objectIds)
					{
						Solid solid = (Solid)transaction.GetObject(objectId, 1);
						solid.Layer.ToString();
						Polyline dbobject_ = CAD.AddPline(new Point3d[]
						{
							solid.GetPointAt(0),
							solid.GetPointAt(1),
							solid.GetPointAt(3),
							solid.GetPointAt(2)
						}, 0.0, true, "");
						solid.UpgradeOpen();
						Class36.smethod_64(solid.ObjectId);
						if (Class36.smethod_76(dbobject_, "柱填充", "AN31C", 25.0) == null && Class36.smethod_76(dbobject_, "柱填充", "ARMORED", 25.0) == null)
						{
							Class36.smethod_76(dbobject_, "柱填充", "钢筋混凝土", 50.0);
						}
					}
				}
				transaction.Commit();
			}
			documentLock.Dispose();
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			this.Cmd("TcPFL");
		}

		private void Button11_Click(object sender, EventArgs e)
		{
			this.Cmd("TcPFZ");
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangbiao");
		}

		private void Button12_Click(object sender, EventArgs e)
		{
			this.Cmd("TcPLHatch");
		}

		private void Button13_Click(object sender, EventArgs e)
		{
			this.Cmd("TcToPL");
		}

		private void jipAtgRsh(object sender, EventArgs e)
		{
			this.Cmd("TcQZAS");
		}

		private void Button18_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQLJ");
		}

		private void Button22_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZhuBiao");
		}

		private void Button23_Click(object sender, EventArgs e)
		{
			this.Cmd("TcTuo1");
		}

		private void Button26_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZLJ_PKPM");
		}

		private void Button29_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZGJ_PKPM");
		}

		private void Button31_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQGJ_X");
		}

		private void Button32_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQGJ_D");
		}

		private void Button36_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQZCCBZ");
		}

		private void Button37_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZhuBiaoZhu");
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			this.Cmd("TcPKPM");
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDJ");
		}

		private void Button15_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLouTi");
		}

		private void Button16_Click(object sender, EventArgs e)
		{
			this.Cmd("TcCGB");
		}

		private void Button17_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQiangAsv");
		}

		private void Button38_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZhuBiao");
		}

		private void Button39_Click(object sender, EventArgs e)
		{
			this.Cmd("TcHRB");
		}

		private void Button40_Click(object sender, EventArgs e)
		{
			this.Cmd("TcReNameBlock");
		}

		private void Button41_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZJM");
		}

		private void Button42_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLJM");
		}

		private void Button43_Click(object sender, EventArgs e)
		{
			this.Cmd("附加箍筋");
		}

		private void Button44_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangChongBianHao");
		}

		private void Button45_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZhuang");
		}

		private void Button46_Click(object sender, EventArgs e)
		{
			this.Cmd("TcChengTai3");
		}

		private void Button48_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZhuAsv");
		}

		private void Button24_Click(object sender, EventArgs e)
		{
			this.Cmd("TcFilter");
		}

		private void Button49_Click(object sender, EventArgs e)
		{
			this.Cmd("TcPLHatch1");
		}

		private void Button50_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(this.TextBox1.Text, "", false) != 0)
			{
				this.Cmd(this.TextBox1.Text);
			}
		}

		private void Button54_Click(object sender, EventArgs e)
		{
			this.Cmd("TcTextBrush");
		}

		private void Button55_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangCheck");
		}

		private void Button56_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZhuGuJin");
		}

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this.ComboBox1.Text;
			if (Operators.CompareString(text, "1:20", false) == 0)
			{
				Class36.double_0 = 5.0;
			}
			else if (Operators.CompareString(text, "1:25", false) == 0)
			{
				Class36.double_0 = 4.0;
			}
			else if (Operators.CompareString(text, "1:30", false) == 0)
			{
				Class36.double_0 = 3.333;
			}
			else if (Operators.CompareString(text, "1:40", false) == 0)
			{
				Class36.double_0 = 2.5;
			}
			else if (Operators.CompareString(text, "1:50", false) == 0)
			{
				Class36.double_0 = 2.0;
			}
			else if (Operators.CompareString(text, "1:75", false) == 0)
			{
				Class36.double_0 = 1.333;
			}
			else if (Operators.CompareString(text, "1:100", false) == 0)
			{
				Class36.double_0 = 1.0;
			}
		}

		private void Button57_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangZhuLaJin");
		}

		private void Button58_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangZhuLaJin");
		}

		public void Cmd(string Cmd)
		{
			Class36.SetFocus(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Document document = Application.DocumentManager.GetDocument(HostApplicationServices.WorkingDatabase);
			document.Editor.WriteMessage("\r\n命令:" + Cmd + "\r\n");
			document.SendStringToExecute(Cmd + " ", false, false, false);
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			this.Cmd("TcCustomBiao");
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQiangZhuChongBianHao");
		}

		private void Button19_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBeamXY");
		}

		private void Button20_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDengJuBuJin1");
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button21_Click(object sender, EventArgs e)
		{
			string pathName = Class33.Class31_0.Info.DirectoryPath + "\\钢筋表.exe";
			Interaction.Shell(pathName, AppWinStyle.NormalFocus, false, -1);
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void Button25_Click(object sender, EventArgs e)
		{
			string pathName = Class33.Class31_0.Info.DirectoryPath + "\\ShowPic.exe";
			Interaction.Shell(pathName, AppWinStyle.NormalFocus, false, -1);
		}

		private void Button27_Click(object sender, EventArgs e)
		{
			Interaction.Shell("calc.exe", AppWinStyle.NormalFocus, false, -1);
		}

		private void Button28_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZongJinTongJi");
		}

		private void Button33_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDuiQiJiaoHuan");
		}

		private void Button34_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQCCBZ");
		}

		private void Button35_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangChongBianHao1");
		}

		private void Button51_Click(object sender, EventArgs e)
		{
			this.Cmd("TcTuo");
		}

		private void method_0(object sender, EventArgs e)
		{
			this.Cmd("TcLiangBHJia");
		}

		private void method_1(object sender, EventArgs e)
		{
			this.Cmd("TcLiangBHJian");
		}

		private void Button59_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBlock");
		}

		private void Button60_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGroup");
		}

		private void Button47_Click(object sender, EventArgs e)
		{
		}

		private void Button52_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDengJuBuJin1");
		}

		private void Button71_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQGJ_YJK_D");
		}

		private void Button72_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQGJ_YJK_X");
		}

		private void Button73_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQLJ_YJK");
		}

		private void Button94_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZGJ_YJK");
		}

		private void Button95_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZLJ_YJK");
		}

		private void Button96_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLiangGuiBing");
		}

		private void Button_2_Click(object sender, EventArgs e)
		{
			this.Cmd("TcMirrTxt");
		}

		private void Button_1_Click(object sender, EventArgs e)
		{
			this.Cmd("TcRotateTxt");
		}

		private void Button_0_Click(object sender, EventArgs e)
		{
			this.Cmd("TcMirrTxtByline");
		}

		private void Button_3_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLLHB");
		}

		private void Button_4_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQZAS1");
		}

		private void Button_5_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQiangAsv1");
		}

		private void Button_6_Click(object sender, EventArgs e)
		{
			this.Cmd("TcYJK");
		}

		private void Button_7_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQZCCBZ1");
		}

		private void Button_8_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZCCBZ");
		}

		private void Button_9_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQCCBZ1");
		}

		private void Button_10_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQZCCBZ2");
		}

		private void Button_11_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQCCBZ2");
		}

		private void Button_12_Click(object sender, EventArgs e)
		{
			this.Cmd("TcZCCBZ1");
		}

		private void Button_13_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBZBR");
		}

		private void Button_14_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBeamLine");
		}

		private void Button_15_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBJFJ");
		}

		private void Button97_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBJJX");
		}

		private void Button_16_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBanJinQuGou");
		}

		private void Button_17_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBJFJ");
		}

		private void Button_18_Click(object sender, EventArgs e)
		{
			this.Cmd("TcE8200");
		}

		private void Button_19_Click(object sender, EventArgs e)
		{
			this.Cmd("TcQuTongShanChu");
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			this.Cmd("TcJZSSLB");
		}

		private void Button_20_Click(object sender, EventArgs e)
		{
			this.Cmd("TcSSLB");
		}

		private void Button_21_Click(object sender, EventArgs e)
		{
			this.Cmd("TcGJDY");
		}

		private void Button30_Click(object sender, EventArgs e)
		{
			this.Cmd("TcMirrTxtByline");
		}

		private void Button98_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBJJZ_X");
		}

		private void Button99_Click(object sender, EventArgs e)
		{
			this.Cmd("TcBJJZ_Y");
		}

		private void Button_22_Click(object sender, EventArgs e)
		{
			this.Cmd("TcDBJY");
		}

		private void Button_23_Click(object sender, EventArgs e)
		{
			this.Cmd("TcLBKD");
		}

		private static List<WeakReference> list_0;

		private IContainer icontainer_0;

		[AccessedThroughProperty("Button2")]
		private Button _Button2;

		[AccessedThroughProperty("Button3")]
		private Button _Button3;

		[AccessedThroughProperty("Button4")]
		private Button _Button4;

		[AccessedThroughProperty("Button7")]
		private Button _Button7;

		[AccessedThroughProperty("Button10")]
		private Button _Button10;

		[AccessedThroughProperty("Button11")]
		private Button _Button11;

		[AccessedThroughProperty("Button13")]
		private Button NnGraoarmy;

		[AccessedThroughProperty("Button23")]
		private Button _Button23;

		[AccessedThroughProperty("TabControl1")]
		private TabControl _TabControl1;

		[AccessedThroughProperty("TabPage1")]
		private TabPage _TabPage1;

		[AccessedThroughProperty("Button12")]
		private Button _Button12;

		[AccessedThroughProperty("Button29")]
		private Button _Button29;

		[AccessedThroughProperty("Button26")]
		private Button _Button26;

		[AccessedThroughProperty("TabPage3")]
		private TabPage _TabPage3;

		[AccessedThroughProperty("Button37")]
		private Button _Button37;

		[AccessedThroughProperty("SplitContainer1")]
		private SplitContainer _SplitContainer1;

		[AccessedThroughProperty("Button1")]
		private Button _Button1;

		[AccessedThroughProperty("Button15")]
		private Button gntrwnIqfF;

		[AccessedThroughProperty("Button16")]
		private Button _Button16;

		[AccessedThroughProperty("Button38")]
		private Button _Button38;

		[AccessedThroughProperty("Button39")]
		private Button _Button39;

		[AccessedThroughProperty("Button40")]
		private Button _Button40;

		[AccessedThroughProperty("Button41")]
		private Button _Button41;

		[AccessedThroughProperty("Button42")]
		private Button _Button42;

		[AccessedThroughProperty("Button43")]
		private Button _Button43;

		[AccessedThroughProperty("Button44")]
		private Button _Button44;

		[AccessedThroughProperty("TabPage4")]
		private TabPage _TabPage4;

		[AccessedThroughProperty("Button6")]
		private Button _Button6;

		[AccessedThroughProperty("Button45")]
		private Button _Button45;

		[AccessedThroughProperty("Button47")]
		private Button _Button47;

		[AccessedThroughProperty("Button46")]
		private Button _Button46;

		[AccessedThroughProperty("Button48")]
		private Button _Button48;

		[AccessedThroughProperty("Button24")]
		private Button _Button24;

		[AccessedThroughProperty("Button49")]
		private Button _Button49;

		[AccessedThroughProperty("Button50")]
		private Button _Button50;

		[AccessedThroughProperty("TextBox1")]
		private TextBox _TextBox1;

		[AccessedThroughProperty("Button54")]
		private Button _Button54;

		[AccessedThroughProperty("Button55")]
		private Button _Button55;

		[AccessedThroughProperty("Button57")]
		private Button _Button57;

		[AccessedThroughProperty("Button56")]
		private Button _Button56;

		[AccessedThroughProperty("ComboBox1")]
		private ComboBox _ComboBox1;

		[AccessedThroughProperty("Label1")]
		private Label _Label1;

		[AccessedThroughProperty("Button58")]
		private Button _Button58;

		[AccessedThroughProperty("TabPage2")]
		private TabPage _TabPage2;

		[AccessedThroughProperty("Button17")]
		private Button _Button17;

		[AccessedThroughProperty("Button36")]
		private Button _Button36;

		[AccessedThroughProperty("Button32")]
		private Button _Button32;

		[AccessedThroughProperty("Button22")]
		private Button _Button22;

		[AccessedThroughProperty("Button31")]
		private Button _Button31;

		[AccessedThroughProperty("Button18")]
		private Button _Button18;

		[AccessedThroughProperty("Button14")]
		private Button _Button14;

		[AccessedThroughProperty("Button8")]
		private Button _Button8;

		[AccessedThroughProperty("Button9")]
		private Button _Button9;

		[AccessedThroughProperty("Button19")]
		private Button _Button19;

		[AccessedThroughProperty("Button20")]
		private Button _Button20;

		[AccessedThroughProperty("Button21")]
		private Button _Button21;

		[AccessedThroughProperty("Button25")]
		private Button _Button25;

		[AccessedThroughProperty("Button27")]
		private Button _Button27;

		[AccessedThroughProperty("Button28")]
		private Button _Button28;

		[AccessedThroughProperty("Button33")]
		private Button _Button33;

		[AccessedThroughProperty("Button34")]
		private Button _Button34;

		[AccessedThroughProperty("Button35")]
		private Button _Button35;

		[AccessedThroughProperty("Button51")]
		private Button _Button51;

		[AccessedThroughProperty("Button59")]
		private Button _Button59;

		[AccessedThroughProperty("Button60")]
		private Button _Button60;

		[AccessedThroughProperty("Button52")]
		private Button _Button52;

		[AccessedThroughProperty("Button71")]
		private Button _Button71;

		[AccessedThroughProperty("Button72")]
		private Button _Button72;

		[AccessedThroughProperty("Button73")]
		private Button _Button73;

		[AccessedThroughProperty("Button53")]
		private Button _Button53;

		[AccessedThroughProperty("Button61")]
		private Button _Button61;

		[AccessedThroughProperty("Button62")]
		private Button _Button62;

		[AccessedThroughProperty("Button63")]
		private Button _Button63;

		[AccessedThroughProperty("Button64")]
		private Button _Button64;

		[AccessedThroughProperty("Button65")]
		private Button _Button65;

		[AccessedThroughProperty("Button66")]
		private Button _Button66;

		[AccessedThroughProperty("Button67")]
		private Button _Button67;

		[AccessedThroughProperty("Button68")]
		private Button _Button68;

		[AccessedThroughProperty("Button69")]
		private Button _Button69;

		[AccessedThroughProperty("Button70")]
		private Button _Button70;

		[AccessedThroughProperty("Button74")]
		private Button _Button74;

		[AccessedThroughProperty("Button75")]
		private Button _Button75;

		[AccessedThroughProperty("Button76")]
		private Button ujxgLuqBou;

		[AccessedThroughProperty("Button77")]
		private Button _Button77;

		[AccessedThroughProperty("Button78")]
		private Button _Button78;

		[AccessedThroughProperty("Button79")]
		private Button _Button79;

		[AccessedThroughProperty("Button80")]
		private Button _Button80;

		[AccessedThroughProperty("Button81")]
		private Button _Button81;

		[AccessedThroughProperty("Button82")]
		private Button _Button82;

		[AccessedThroughProperty("Button83")]
		private Button _Button83;

		[AccessedThroughProperty("Button84")]
		private Button _Button84;

		[AccessedThroughProperty("Button85")]
		private Button _Button85;

		[AccessedThroughProperty("Button86")]
		private Button _Button86;

		[AccessedThroughProperty("Button87")]
		private Button _Button87;

		[AccessedThroughProperty("Button88")]
		private Button _Button88;

		[AccessedThroughProperty("Button89")]
		private Button _Button89;

		[AccessedThroughProperty("Button90")]
		private Button _Button90;

		[AccessedThroughProperty("Button91")]
		private Button _Button91;

		[AccessedThroughProperty("Button92")]
		private Button _Button92;

		[AccessedThroughProperty("Button93")]
		private Button _Button93;

		[AccessedThroughProperty("Button94")]
		private Button _Button94;

		[AccessedThroughProperty("Button95")]
		private Button _Button95;

		[AccessedThroughProperty("Button96")]
		private Button _Button96;

		[AccessedThroughProperty("TabPage5")]
		private TabPage _TabPage5;

		[AccessedThroughProperty("Button112")]
		private Button button_0;

		[AccessedThroughProperty("Button111")]
		private Button button_1;

		[AccessedThroughProperty("Button110")]
		private Button button_2;

		[AccessedThroughProperty("Button113")]
		private Button button_3;

		[AccessedThroughProperty("Button114")]
		private Button button_4;

		[AccessedThroughProperty("Button115")]
		private Button button_5;

		[AccessedThroughProperty("Button116")]
		private Button button_6;

		[AccessedThroughProperty("Button117")]
		private Button button_7;

		[AccessedThroughProperty("Button118")]
		private Button button_8;

		[AccessedThroughProperty("Button119")]
		private Button button_9;

		[AccessedThroughProperty("Button120")]
		private Button button_10;

		[AccessedThroughProperty("Button121")]
		private Button button_11;

		[AccessedThroughProperty("Button122")]
		private Button button_12;

		[AccessedThroughProperty("Button123")]
		private Button button_13;

		[AccessedThroughProperty("Button124")]
		private Button button_14;

		[AccessedThroughProperty("TabPage6")]
		private TabPage _TabPage6;

		[AccessedThroughProperty("Button125")]
		private Button button_15;

		[AccessedThroughProperty("Button97")]
		private Button _Button97;

		[AccessedThroughProperty("Button126")]
		private Button button_16;

		[AccessedThroughProperty("Button127")]
		private Button button_17;

		[AccessedThroughProperty("Button128")]
		private Button button_18;

		[AccessedThroughProperty("Button129")]
		private Button button_19;

		[AccessedThroughProperty("GroupBox1")]
		private GroupBox _GroupBox1;

		[AccessedThroughProperty("Button130")]
		private Button button_20;

		[AccessedThroughProperty("Button5")]
		private Button _Button5;

		[AccessedThroughProperty("Button131")]
		private Button button_21;

		[AccessedThroughProperty("Button30")]
		private Button _Button30;

		[AccessedThroughProperty("Button98")]
		private Button _Button98;

		[AccessedThroughProperty("Button99")]
		private Button _Button99;

		[AccessedThroughProperty("Button101")]
		private Button button_22;

		[AccessedThroughProperty("Button100")]
		private Button button_23;

		private Document document_0;

		private Database database_0;
	}
}
