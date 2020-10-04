namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class JMTX_Frm : global::System.Windows.Forms.Form
	{
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Panel1 = new global::System.Windows.Forms.Panel();
			this.Button4 = new global::System.Windows.Forms.Button();
			this.Button3 = new global::System.Windows.Forms.Button();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Panel2 = new global::System.Windows.Forms.Panel();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.TextBox2 = new global::System.Windows.Forms.TextBox();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			this.Panel1.Controls.Add(this.Button4);
			this.Panel1.Controls.Add(this.Button3);
			this.Panel1.Controls.Add(this.Button1);
			this.Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			global::System.Windows.Forms.Control panel = this.Panel1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 0);
			panel.Location = location;
			this.Panel1.Name = "Panel1";
			global::System.Windows.Forms.Control panel2 = this.Panel1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(412, 31);
			panel2.Size = size;
			this.Panel1.TabIndex = 0;
			global::System.Windows.Forms.Control button = this.Button4;
			location = new global::System.Drawing.Point(253, 3);
			button.Location = location;
			this.Button4.Name = "Button4";
			global::System.Windows.Forms.Control button2 = this.Button4;
			size = new global::System.Drawing.Size(156, 23);
			button2.Size = size;
			this.Button4.TabIndex = 8;
			this.Button4.Text = "将结果写入AutoCAD";
			this.Button4.UseVisualStyleBackColor = true;
			global::System.Windows.Forms.Control button3 = this.Button3;
			location = new global::System.Drawing.Point(74, 3);
			button3.Location = location;
			this.Button3.Name = "Button3";
			global::System.Windows.Forms.Control button4 = this.Button3;
			size = new global::System.Drawing.Size(184, 23);
			button4.Size = size;
			this.Button3.TabIndex = 7;
			this.Button3.Text = "指定点的抗弯和抗扭截面模量";
			this.Button3.UseVisualStyleBackColor = true;
			global::System.Windows.Forms.Control button5 = this.Button1;
			location = new global::System.Drawing.Point(5, 3);
			button5.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button6 = this.Button1;
			size = new global::System.Drawing.Size(75, 23);
			button6.Size = size;
			this.Button1.TabIndex = 5;
			this.Button1.Text = "选择面域";
			this.Button1.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			this.Label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(0, 31);
			label.Location = location;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label2 = this.Label1;
			size = new global::System.Drawing.Size(185, 12);
			label2.Size = size;
			this.Label1.TabIndex = 4;
			this.Label1.Text = "当前坐标系，旋转中心为其质心：";
			this.TextBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(0, 43);
			textBox.Location = location;
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(412, 135);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 5;
			this.Panel2.Controls.Add(this.Button2);
			this.Panel2.Controls.Add(this.Label2);
			this.Panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			global::System.Windows.Forms.Control panel3 = this.Panel2;
			location = new global::System.Drawing.Point(0, 178);
			panel3.Location = location;
			this.Panel2.Name = "Panel2";
			global::System.Windows.Forms.Control panel4 = this.Panel2;
			size = new global::System.Drawing.Size(412, 26);
			panel4.Size = size;
			this.Panel2.TabIndex = 6;
			global::System.Windows.Forms.Control button7 = this.Button2;
			location = new global::System.Drawing.Point(253, 3);
			button7.Location = location;
			this.Button2.Name = "Button2";
			global::System.Windows.Forms.Control button8 = this.Button2;
			size = new global::System.Drawing.Size(156, 23);
			button8.Size = size;
			this.Button2.TabIndex = 9;
			this.Button2.Text = "将接写入AutoCAD";
			this.Button2.UseVisualStyleBackColor = true;
			this.Label2.AutoSize = true;
			global::System.Windows.Forms.Control label3 = this.Label2;
			location = new global::System.Drawing.Point(3, 11);
			label3.Location = location;
			this.Label2.Name = "Label2";
			global::System.Windows.Forms.Control label4 = this.Label2;
			size = new global::System.Drawing.Size(197, 12);
			label4.Size = size;
			this.Label2.TabIndex = 5;
			this.Label2.Text = "当前坐标系，旋转中心为坐标原点：";
			this.TextBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control textBox3 = this.TextBox2;
			location = new global::System.Drawing.Point(0, 204);
			textBox3.Location = location;
			this.TextBox2.Multiline = true;
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			global::System.Windows.Forms.Control textBox4 = this.TextBox2;
			size = new global::System.Drawing.Size(412, 164);
			textBox4.Size = size;
			this.TextBox2.TabIndex = 7;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(412, 368);
			this.ClientSize = size;
			this.Controls.Add(this.TextBox2);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Panel1);
			this.Name = "JMTX_Frm";
			this.Text = "截面特性";
			this.Panel1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.Panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
