namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class QRCode_Frm : global::System.Windows.Forms.Form
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
			this.SplitContainer1 = new global::System.Windows.Forms.SplitContainer();
			this.TableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.ComboBox1 = new global::System.Windows.Forms.ComboBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			((global::System.ComponentModel.ISupportInitialize)this.SplitContainer1).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			this.SplitContainer1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control splitContainer = this.SplitContainer1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 0);
			splitContainer.Location = location;
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Panel1.Controls.Add(this.TableLayoutPanel1);
			this.SplitContainer1.Panel1.Controls.Add(this.TextBox1);
			global::System.Windows.Forms.Control splitContainer2 = this.SplitContainer1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(463, 239);
			splitContainer2.Size = size;
			this.SplitContainer1.SplitterDistance = 213;
			this.SplitContainer1.TabIndex = 0;
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.Button2, 1, 1);
			this.TableLayoutPanel1.Controls.Add(this.ComboBox1, 1, 0);
			this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
			this.TableLayoutPanel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			global::System.Windows.Forms.Control tableLayoutPanel = this.TableLayoutPanel1;
			location = new global::System.Drawing.Point(0, 154);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 2;
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 43.10237f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 56.89763f));
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Absolute, 20f));
			global::System.Windows.Forms.Control tableLayoutPanel2 = this.TableLayoutPanel1;
			size = new global::System.Drawing.Size(213, 85);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 3;
			this.Button2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control button = this.Button2;
			location = new global::System.Drawing.Point(109, 39);
			button.Location = location;
			this.Button2.Name = "Button2";
			global::System.Windows.Forms.Control button2 = this.Button2;
			size = new global::System.Drawing.Size(101, 43);
			button2.Size = size;
			this.Button2.TabIndex = 1;
			this.Button2.Text = "绘制二维码";
			this.Button2.UseVisualStyleBackColor = true;
			this.ComboBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.ComboBox1.FormattingEnabled = true;
			global::System.Windows.Forms.Control comboBox = this.ComboBox1;
			location = new global::System.Drawing.Point(109, 3);
			comboBox.Location = location;
			this.ComboBox1.Name = "ComboBox1";
			global::System.Windows.Forms.Control comboBox2 = this.ComboBox1;
			size = new global::System.Drawing.Size(101, 20);
			comboBox2.Size = size;
			this.ComboBox1.TabIndex = 2;
			this.ComboBox1.Text = "1:100";
			this.Label1.AutoSize = true;
			this.Label1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(3, 0);
			label.Location = location;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label2 = this.Label1;
			size = new global::System.Drawing.Size(100, 36);
			label2.Size = size;
			this.Label1.TabIndex = 3;
			this.Label1.Text = "绘制比例";
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.TextBox1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			global::System.Windows.Forms.Control textBox = this.TextBox1;
			location = new global::System.Drawing.Point(0, 0);
			textBox.Location = location;
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			global::System.Windows.Forms.Control textBox2 = this.TextBox1;
			size = new global::System.Drawing.Size(213, 239);
			textBox2.Size = size;
			this.TextBox1.TabIndex = 0;
			this.TextBox1.Text = "田草CAD工具箱：http://www.tiancao.net/\r\n";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(463, 239);
			this.ClientSize = size;
			this.Controls.Add(this.SplitContainer1);
			this.Name = "QRCode_Frm";
			this.Text = "图纸信息二维码";
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.SplitContainer1).EndInit();
			this.SplitContainer1.ResumeLayout(false);
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
