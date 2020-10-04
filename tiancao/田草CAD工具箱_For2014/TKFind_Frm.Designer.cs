namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TKFind_Frm : global::System.Windows.Forms.Form
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
			this.icontainer_0 = new global::System.ComponentModel.Container();
			this.ListBox1 = new global::System.Windows.Forms.ListBox();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.ListBox2 = new global::System.Windows.Forms.ListBox();
			this.PictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.ImageList1 = new global::System.Windows.Forms.ImageList(this.icontainer_0);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
			this.SuspendLayout();
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.ItemHeight = 12;
			global::System.Windows.Forms.Control listBox = this.ListBox1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(2, 43);
			listBox.Location = location;
			this.ListBox1.Name = "ListBox1";
			global::System.Windows.Forms.Control listBox2 = this.ListBox1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(130, 220);
			listBox2.Size = size;
			this.ListBox1.TabIndex = 0;
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(2, 12);
			textBox.Location = location;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(130, 21);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 1;
			this.ListBox2.FormattingEnabled = true;
			this.ListBox2.ItemHeight = 12;
			global::System.Windows.Forms.Control listBox3 = this.ListBox2;
			location = new global::System.Drawing.Point(217, 247);
			listBox3.Location = location;
			this.ListBox2.Name = "ListBox2";
			global::System.Windows.Forms.Control listBox4 = this.ListBox2;
			size = new global::System.Drawing.Size(130, 220);
			listBox4.Size = size;
			this.ListBox2.TabIndex = 2;
			global::System.Windows.Forms.Control pictureBox = this.PictureBox1;
			location = new global::System.Drawing.Point(138, 14);
			pictureBox.Location = location;
			this.PictureBox1.Name = "PictureBox1";
			global::System.Windows.Forms.Control pictureBox2 = this.PictureBox1;
			size = new global::System.Drawing.Size(290, 249);
			pictureBox2.Size = size;
			this.PictureBox1.TabIndex = 3;
			this.PictureBox1.TabStop = false;
			this.ImageList1.ColorDepth = global::System.Windows.Forms.ColorDepth.Depth8Bit;
			global::System.Windows.Forms.ImageList imageList = this.ImageList1;
			size = new global::System.Drawing.Size(16, 16);
			imageList.ImageSize = size;
			this.ImageList1.TransparentColor = global::System.Drawing.Color.Transparent;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(511, 356);
			this.ClientSize = size;
			this.Controls.Add(this.PictureBox1);
			this.Controls.Add(this.ListBox2);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.ListBox1);
			this.Name = "TKFind_Frm";
			this.Text = "TKFind_Frm";
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
