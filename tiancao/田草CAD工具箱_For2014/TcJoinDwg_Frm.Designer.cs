namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcJoinDwg_Frm : global::System.Windows.Forms.Form
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
			this.Button2 = new global::System.Windows.Forms.Button();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.ListBox1 = new global::System.Windows.Forms.ListBox();
			this.TextBox2 = new global::System.Windows.Forms.TextBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.SuspendLayout();
			global::System.Windows.Forms.Control button = this.Button2;
			global::System.Drawing.Point location = new global::System.Drawing.Point(356, 12);
			button.Location = location;
			this.Button2.Name = "Button2";
			global::System.Windows.Forms.Control button2 = this.Button2;
			global::System.Drawing.Size size = new global::System.Drawing.Size(67, 24);
			button2.Size = size;
			this.Button2.TabIndex = 4;
			this.Button2.Text = "浏览";
			this.Button2.UseVisualStyleBackColor = true;
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(12, 12);
			textBox.Location = location;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(338, 21);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 3;
			this.ListBox1.AllowDrop = true;
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.ItemHeight = 12;
			global::System.Windows.Forms.Control listBox = this.ListBox1;
			location = new global::System.Drawing.Point(13, 37);
			listBox.Location = location;
			this.ListBox1.Name = "ListBox1";
			global::System.Windows.Forms.Control listBox2 = this.ListBox1;
			size = new global::System.Drawing.Size(406, 196);
			listBox2.Size = size;
			this.ListBox1.TabIndex = 5;
			global::System.Windows.Forms.Control textBox3 = this.TextBox2;
			location = new global::System.Drawing.Point(88, 239);
			textBox3.Location = location;
			this.TextBox2.Name = "TextBox2";
			global::System.Windows.Forms.Control textBox4 = this.TextBox2;
			size = new global::System.Drawing.Size(97, 21);
			textBox4.Size = size;
			this.TextBox2.TabIndex = 6;
			this.TextBox2.Text = "100000";
			global::System.Windows.Forms.Control button3 = this.Button1;
			location = new global::System.Drawing.Point(291, 236);
			button3.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button4 = this.Button1;
			size = new global::System.Drawing.Size(128, 24);
			button4.Size = size;
			this.Button1.TabIndex = 7;
			this.Button1.Text = "合并";
			this.Button1.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(12, 242);
			label.Location = location;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label2 = this.Label1;
			size = new global::System.Drawing.Size(41, 12);
			label2.Size = size;
			this.Label1.TabIndex = 9;
			this.Label1.Text = "行间距";
			this.Label2.AutoSize = true;
			global::System.Windows.Forms.Control label3 = this.Label2;
			location = new global::System.Drawing.Point(12, 268);
			label3.Location = location;
			this.Label2.Name = "Label2";
			global::System.Windows.Forms.Control label4 = this.Label2;
			size = new global::System.Drawing.Size(11, 12);
			label4.Size = size;
			this.Label2.TabIndex = 10;
			this.Label2.Text = " ";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(435, 289);
			this.ClientSize = size;
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.TextBox2);
			this.Controls.Add(this.ListBox1);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.TextBox1);
			this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TcJoinDwg_Frm";
			this.ShowInTaskbar = false;
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "合并至一个Dwg";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
