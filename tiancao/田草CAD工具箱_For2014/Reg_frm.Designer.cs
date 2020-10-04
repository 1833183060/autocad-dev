namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class Reg_frm : global::System.Windows.Forms.Form
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
			this.OK_Button = new global::System.Windows.Forms.Button();
			this.Cancel_Button = new global::System.Windows.Forms.Button();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.Label25 = new global::System.Windows.Forms.Label();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.SuspendLayout();
			global::System.Windows.Forms.Control ok_Button = this.OK_Button;
			global::System.Drawing.Point location = new global::System.Drawing.Point(5, 127);
			ok_Button.Location = location;
			this.OK_Button.Name = "OK_Button";
			global::System.Windows.Forms.Control ok_Button2 = this.OK_Button;
			global::System.Drawing.Size size = new global::System.Drawing.Size(67, 35);
			ok_Button2.Size = size;
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "申请注册";
			this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			global::System.Windows.Forms.Control cancel_Button = this.Cancel_Button;
			location = new global::System.Drawing.Point(189, 127);
			cancel_Button.Location = location;
			this.Cancel_Button.Name = "Cancel_Button";
			global::System.Windows.Forms.Control cancel_Button2 = this.Cancel_Button;
			size = new global::System.Drawing.Size(69, 33);
			cancel_Button2.Size = size;
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "卸载";
			global::System.Windows.Forms.Control button = this.Button1;
			location = new global::System.Drawing.Point(97, 127);
			button.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button2 = this.Button1;
			size = new global::System.Drawing.Size(67, 35);
			button2.Size = size;
			this.Button1.TabIndex = 2;
			this.Button1.Text = "试用";
			this.Label1.AutoSize = true;
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(2, 9);
			label.Location = location;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label2 = this.Label1;
			size = new global::System.Drawing.Size(71, 12);
			label2.Size = size;
			this.Label1.TabIndex = 3;
			this.Label1.Text = "电脑身份证:";
			this.TextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextBox1.Font = new global::System.Drawing.Font("宋体", 10.5f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(4, 24);
			textBox.Location = location;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(349, 23);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 4;
			this.Label2.AutoSize = true;
			this.Label2.ForeColor = global::System.Drawing.Color.Red;
			global::System.Windows.Forms.Control label3 = this.Label2;
			location = new global::System.Drawing.Point(3, 56);
			label3.Location = location;
			this.Label2.Name = "Label2";
			global::System.Windows.Forms.Control label4 = this.Label2;
			size = new global::System.Drawing.Size(41, 12);
			label4.Size = size;
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Label2";
			this.Label25.AutoSize = true;
			this.Label25.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.Label25.Font = new global::System.Drawing.Font("宋体", 9f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 134);
			global::System.Windows.Forms.Control label5 = this.Label25;
			location = new global::System.Drawing.Point(3, 170);
			label5.Location = location;
			this.Label25.Name = "Label25";
			global::System.Windows.Forms.Control label6 = this.Label25;
			size = new global::System.Drawing.Size(113, 12);
			label6.Size = size;
			this.Label25.TabIndex = 55;
			this.Label25.Text = "软件又升级更新啦！";
			global::System.Windows.Forms.Control button3 = this.Button2;
			location = new global::System.Drawing.Point(283, 127);
			button3.Location = location;
			this.Button2.Name = "Button2";
			global::System.Windows.Forms.Control button4 = this.Button2;
			size = new global::System.Drawing.Size(69, 33);
			button4.Size = size;
			this.Button2.TabIndex = 56;
			this.Button2.Text = "了解更多";
			this.AcceptButton = this.OK_Button;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			size = new global::System.Drawing.Size(365, 191);
			this.ClientSize = size;
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Label25);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.OK_Button);
			this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Reg_frm";
			this.ShowInTaskbar = false;
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "田草CAD工具箱，注册后能得到更多更好的服务";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
