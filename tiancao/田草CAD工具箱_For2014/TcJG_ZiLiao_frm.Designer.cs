namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcJG_ZiLiao_frm : global::System.Windows.Forms.Form
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
			this.PictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.SplitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.ListBox2 = new global::System.Windows.Forms.ListBox();
			this.ListBox1 = new global::System.Windows.Forms.ListBox();
			this.TextBox2 = new global::System.Windows.Forms.TextBox();
			this.Panel1 = new global::System.Windows.Forms.Panel();
			this.Panel2 = new global::System.Windows.Forms.Panel();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			this.PictureBox1.BackColor = global::System.Drawing.Color.White;
			this.PictureBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control pictureBox = this.PictureBox1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 0);
			pictureBox.Location = location;
			this.PictureBox1.Name = "PictureBox1";
			global::System.Windows.Forms.Control pictureBox2 = this.PictureBox1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(444, 367);
			pictureBox2.Size = size;
			this.PictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox1.TabIndex = 1;
			this.PictureBox1.TabStop = false;
			this.SplitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control splitContainer = this.SplitContainer1;
			location = new global::System.Drawing.Point(0, 0);
			splitContainer.Location = location;
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Panel1.Controls.Add(this.ListBox2);
			this.SplitContainer1.Panel1.Controls.Add(this.ListBox1);
			this.SplitContainer1.Panel2.Controls.Add(this.PictureBox1);
			global::System.Windows.Forms.Control splitContainer2 = this.SplitContainer1;
			size = new global::System.Drawing.Size(671, 367);
			splitContainer2.Size = size;
			this.SplitContainer1.SplitterDistance = 223;
			this.SplitContainer1.TabIndex = 2;
			this.ListBox2.FormattingEnabled = true;
			this.ListBox2.ItemHeight = 12;
			global::System.Windows.Forms.Control listBox = this.ListBox2;
			location = new global::System.Drawing.Point(66, 106);
			listBox.Location = location;
			this.ListBox2.Name = "ListBox2";
			global::System.Windows.Forms.Control listBox2 = this.ListBox2;
			size = new global::System.Drawing.Size(108, 88);
			listBox2.Size = size;
			this.ListBox2.TabIndex = 1;
			this.ListBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.ItemHeight = 12;
			global::System.Windows.Forms.Control listBox3 = this.ListBox1;
			location = new global::System.Drawing.Point(0, 0);
			listBox3.Location = location;
			this.ListBox1.Name = "ListBox1";
			global::System.Windows.Forms.Control listBox4 = this.ListBox1;
			size = new global::System.Drawing.Size(223, 367);
			listBox4.Size = size;
			this.ListBox1.TabIndex = 0;
			this.TextBox2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control textBox = this.TextBox2;
			location = new global::System.Drawing.Point(0, 0);
			textBox.Location = location;
			this.TextBox2.Name = "TextBox2";
			global::System.Windows.Forms.Control textBox2 = this.TextBox2;
			size = new global::System.Drawing.Size(671, 21);
			textBox2.Size = size;
			this.TextBox2.TabIndex = 3;
			this.Panel1.Controls.Add(this.TextBox2);
			this.Panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			global::System.Windows.Forms.Control panel = this.Panel1;
			location = new global::System.Drawing.Point(0, 0);
			panel.Location = location;
			this.Panel1.Name = "Panel1";
			global::System.Windows.Forms.Control panel2 = this.Panel1;
			size = new global::System.Drawing.Size(671, 26);
			panel2.Size = size;
			this.Panel1.TabIndex = 4;
			this.Panel2.Controls.Add(this.SplitContainer1);
			this.Panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control panel3 = this.Panel2;
			location = new global::System.Drawing.Point(0, 26);
			panel3.Location = location;
			this.Panel2.Name = "Panel2";
			global::System.Windows.Forms.Control panel4 = this.Panel2;
			size = new global::System.Drawing.Size(671, 367);
			panel4.Size = size;
			this.Panel2.TabIndex = 5;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(671, 393);
			this.ClientSize = size;
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.Panel1);
			this.Name = "TcJG_ZiLiao_frm";
			this.Text = "结构资料--双击图片，然后粘贴至CAD中";
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
			this.SplitContainer1.ResumeLayout(false);
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.Panel2.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
