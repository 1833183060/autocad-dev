namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcFileHistory_Frm : global::System.Windows.Forms.Form
	{
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.jipAtgRsh != null)
			{
				this.jipAtgRsh.Dispose();
			}
			base.Dispose(disposing);
		}

		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.SplitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Panel1 = new global::System.Windows.Forms.Panel();
			this.ListView1 = new global::System.Windows.Forms.ListView();
			this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			((global::System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			this.SplitContainer1.Dock = global::System.Windows.Forms.DockStyle.Top;
			global::System.Windows.Forms.Control splitContainer = this.SplitContainer1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 0);
			splitContainer.Location = location;
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Panel1.Controls.Add(this.TextBox1);
			this.SplitContainer1.Panel2.Controls.Add(this.Button1);
			global::System.Windows.Forms.Control splitContainer2 = this.SplitContainer1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(796, 21);
			splitContainer2.Size = size;
			this.SplitContainer1.SplitterDistance = 740;
			this.SplitContainer1.TabIndex = 7;
			this.TextBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(0, 0);
			textBox.Location = location;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(740, 21);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 0;
			this.Button1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control button = this.Button1;
			location = new global::System.Drawing.Point(0, 0);
			button.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button2 = this.Button1;
			size = new global::System.Drawing.Size(52, 21);
			button2.Size = size;
			this.Button1.TabIndex = 0;
			this.Button1.Text = "…";
			this.Button1.UseVisualStyleBackColor = true;
			this.Panel1.Controls.Add(this.ListView1);
			this.Panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control panel = this.Panel1;
			location = new global::System.Drawing.Point(0, 21);
			panel.Location = location;
			this.Panel1.Name = "Panel1";
			global::System.Windows.Forms.Control panel2 = this.Panel1;
			size = new global::System.Drawing.Size(796, 450);
			panel2.Size = size;
			this.Panel1.TabIndex = 8;
			this.ListView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.ColumnHeader1,
				this.ColumnHeader2,
				this.ColumnHeader3
			});
			this.ListView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control listView = this.ListView1;
			location = new global::System.Drawing.Point(0, 0);
			listView.Location = location;
			this.ListView1.Name = "ListView1";
			global::System.Windows.Forms.Control listView2 = this.ListView1;
			size = new global::System.Drawing.Size(796, 450);
			listView2.Size = size;
			this.ListView1.TabIndex = 0;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader1.Text = "文件名";
			this.ColumnHeader1.Width = 200;
			this.ColumnHeader2.Text = "修改时间";
			this.ColumnHeader2.Width = 100;
			this.ColumnHeader3.Text = "文件路径";
			this.ColumnHeader3.Width = 600;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(796, 471);
			this.ClientSize = size;
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.SplitContainer1);
			this.Name = "TcFileHistory_Frm";
			this.Text = "无限制自动保存历史记录";
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel1.PerformLayout();
			this.SplitContainer1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
			this.SplitContainer1.ResumeLayout(false);
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer jipAtgRsh;
	}
}
