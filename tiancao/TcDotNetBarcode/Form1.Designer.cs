namespace TcDotNetBarcode
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class Form1 : global::System.Windows.Forms.Form
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
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Panel1 = new global::System.Windows.Forms.Panel();
			this.PictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.Panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
			this.SuspendLayout();
			this.TextBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(13, 11);
			textBox.Location = location;
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(272, 335);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 4;
			this.Panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.Panel1.BackColor = global::System.Drawing.SystemColors.Control;
			this.Panel1.Controls.Add(this.PictureBox2);
			global::System.Windows.Forms.Control panel = this.Panel1;
			location = new global::System.Drawing.Point(291, 11);
			panel.Location = location;
			this.Panel1.Name = "Panel1";
			global::System.Windows.Forms.Control panel2 = this.Panel1;
			size = new global::System.Drawing.Size(683, 404);
			panel2.Size = size;
			this.Panel1.TabIndex = 3;
			this.PictureBox2.BackColor = global::System.Drawing.SystemColors.Control;
			global::System.Windows.Forms.Control pictureBox = this.PictureBox2;
			location = new global::System.Drawing.Point(371, 49);
			pictureBox.Location = location;
			this.PictureBox2.Name = "PictureBox2";
			global::System.Windows.Forms.Control pictureBox2 = this.PictureBox2;
			size = new global::System.Drawing.Size(300, 300);
			pictureBox2.Size = size;
			this.PictureBox2.TabIndex = 1;
			this.PictureBox2.TabStop = false;
			global::System.Windows.Forms.Control button = this.Button1;
			location = new global::System.Drawing.Point(74, 278);
			button.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button2 = this.Button1;
			size = new global::System.Drawing.Size(138, 23);
			button2.Size = size;
			this.Button1.TabIndex = 6;
			this.Button1.Text = "返回二维码图像 ";
			this.Button1.UseVisualStyleBackColor = true;
			global::System.Windows.Forms.Control button3 = this.Button2;
			location = new global::System.Drawing.Point(36, 317);
			button3.Location = location;
			this.Button2.Name = "Button2";
			global::System.Windows.Forms.Control button4 = this.Button2;
			size = new global::System.Drawing.Size(226, 23);
			button4.Size = size;
			this.Button2.TabIndex = 7;
			this.Button2.Text = "通过返回01字符串重新绘制二维码";
			this.Button2.UseVisualStyleBackColor = true;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(988, 426);
			this.ClientSize = size;
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.Panel1);
			this.Name = "Form1";
			this.Text = "QR Code二维吗VB NET 测试";
			this.Panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
