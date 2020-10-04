namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcSelect_frm : global::System.Windows.Forms.Form
	{
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.icontainer_0 != null)
				{
					this.icontainer_0.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			this.CheckBox2 = new global::System.Windows.Forms.CheckBox();
			this.CheckBox3 = new global::System.Windows.Forms.CheckBox();
			this.CheckBox4 = new global::System.Windows.Forms.CheckBox();
			this.CheckBox5 = new global::System.Windows.Forms.CheckBox();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			this.GroupBox1.Controls.Add(this.CheckBox5);
			this.GroupBox1.Controls.Add(this.CheckBox4);
			this.GroupBox1.Controls.Add(this.CheckBox3);
			this.GroupBox1.Controls.Add(this.CheckBox2);
			this.GroupBox1.Controls.Add(this.CheckBox1);
			global::System.Windows.Forms.Control groupBox = this.GroupBox1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(13, 19);
			groupBox.Location = location;
			this.GroupBox1.Name = "GroupBox1";
			global::System.Windows.Forms.Control groupBox2 = this.GroupBox1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(167, 221);
			groupBox2.Size = size;
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "类似依据";
			this.CheckBox1.AutoSize = true;
			global::System.Windows.Forms.Control checkBox = this.CheckBox1;
			location = new global::System.Drawing.Point(25, 49);
			checkBox.Location = location;
			this.CheckBox1.Name = "CheckBox1";
			global::System.Windows.Forms.Control checkBox2 = this.CheckBox1;
			size = new global::System.Drawing.Size(48, 16);
			checkBox2.Size = size;
			this.CheckBox1.TabIndex = 0;
			this.CheckBox1.Text = "颜色";
			this.CheckBox1.UseVisualStyleBackColor = true;
			this.CheckBox2.AutoSize = true;
			global::System.Windows.Forms.Control checkBox3 = this.CheckBox2;
			location = new global::System.Drawing.Point(25, 71);
			checkBox3.Location = location;
			this.CheckBox2.Name = "CheckBox2";
			global::System.Windows.Forms.Control checkBox4 = this.CheckBox2;
			size = new global::System.Drawing.Size(48, 16);
			checkBox4.Size = size;
			this.CheckBox2.TabIndex = 1;
			this.CheckBox2.Text = "图层";
			this.CheckBox2.UseVisualStyleBackColor = true;
			this.CheckBox3.AutoSize = true;
			global::System.Windows.Forms.Control checkBox5 = this.CheckBox3;
			location = new global::System.Drawing.Point(25, 93);
			checkBox5.Location = location;
			this.CheckBox3.Name = "CheckBox3";
			global::System.Windows.Forms.Control checkBox6 = this.CheckBox3;
			size = new global::System.Drawing.Size(84, 16);
			checkBox6.Size = size;
			this.CheckBox3.TabIndex = 2;
			this.CheckBox3.Text = "名称、内容";
			this.CheckBox3.UseVisualStyleBackColor = true;
			this.CheckBox4.AutoSize = true;
			global::System.Windows.Forms.Control checkBox7 = this.CheckBox4;
			location = new global::System.Drawing.Point(25, 115);
			checkBox7.Location = location;
			this.CheckBox4.Name = "CheckBox4";
			global::System.Windows.Forms.Control checkBox8 = this.CheckBox4;
			size = new global::System.Drawing.Size(48, 16);
			checkBox8.Size = size;
			this.CheckBox4.TabIndex = 3;
			this.CheckBox4.Text = "线宽";
			this.CheckBox4.UseVisualStyleBackColor = true;
			this.CheckBox5.AutoSize = true;
			global::System.Windows.Forms.Control checkBox9 = this.CheckBox5;
			location = new global::System.Drawing.Point(25, 137);
			checkBox9.Location = location;
			this.CheckBox5.Name = "CheckBox5";
			global::System.Windows.Forms.Control checkBox10 = this.CheckBox5;
			size = new global::System.Drawing.Size(48, 16);
			checkBox10.Size = size;
			this.CheckBox5.TabIndex = 4;
			this.CheckBox5.Text = "角度";
			this.CheckBox5.UseVisualStyleBackColor = true;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(284, 262);
			this.ClientSize = size;
			this.Controls.Add(this.GroupBox1);
			this.Name = "Form2";
			this.Text = "选择类似设置";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
