namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class BlockYin : global::System.Windows.Forms.Form
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
			this.ListView1 = new global::System.Windows.Forms.ListView();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.SuspendLayout();
			this.ListView1.FullRowSelect = true;
			this.ListView1.GridLines = true;
			global::System.Windows.Forms.Control listView = this.ListView1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(12, 12);
			listView.Location = location;
			this.ListView1.Name = "ListView1";
			global::System.Windows.Forms.Control listView2 = this.ListView1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(153, 242);
			listView2.Size = size;
			this.ListView1.TabIndex = 0;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.View = global::System.Windows.Forms.View.List;
			global::System.Windows.Forms.Control button = this.Button1;
			location = new global::System.Drawing.Point(195, 12);
			button.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button2 = this.Button1;
			size = new global::System.Drawing.Size(85, 25);
			button2.Size = size;
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Button1";
			this.Button1.UseVisualStyleBackColor = true;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(292, 266);
			this.ClientSize = size;
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.ListView1);
			this.Name = "BlockYin";
			this.Text = " ";
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
