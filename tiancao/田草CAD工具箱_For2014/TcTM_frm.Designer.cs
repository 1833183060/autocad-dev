namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcTM_frm : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::田草CAD工具箱_For2014.TcTM_frm));
			this.TableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.Cancel_Button = new global::System.Windows.Forms.Button();
			this.OK_Button = new global::System.Windows.Forms.Button();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.ComboBox1 = new global::System.Windows.Forms.ComboBox();
			this.ComboBox2 = new global::System.Windows.Forms.ComboBox();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			this.TableLayoutPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			global::System.Windows.Forms.Control tableLayoutPanel = this.TableLayoutPanel1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(109, 31);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			global::System.Windows.Forms.Control tableLayoutPanel2 = this.TableLayoutPanel1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(146, 27);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 0;
			this.Cancel_Button.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.Cancel_Button.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			global::System.Windows.Forms.Control cancel_Button = this.Cancel_Button;
			location = new global::System.Drawing.Point(76, 3);
			cancel_Button.Location = location;
			this.Cancel_Button.Name = "Cancel_Button";
			global::System.Windows.Forms.Control cancel_Button2 = this.Cancel_Button;
			size = new global::System.Drawing.Size(67, 21);
			cancel_Button2.Size = size;
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "取消";
			this.OK_Button.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			global::System.Windows.Forms.Control ok_Button = this.OK_Button;
			location = new global::System.Drawing.Point(3, 3);
			ok_Button.Location = location;
			this.OK_Button.Name = "OK_Button";
			global::System.Windows.Forms.Control ok_Button2 = this.OK_Button;
			size = new global::System.Drawing.Size(67, 21);
			ok_Button2.Size = size;
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "确定";
			this.Label1.AutoSize = true;
			this.Label1.Font = new global::System.Drawing.Font("宋体", 60f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(27, 91);
			label.Location = location;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label2 = this.Label1;
			size = new global::System.Drawing.Size(434, 80);
			label2.Size = size;
			this.Label1.TabIndex = 1;
			this.Label1.Text = "一层平面图";
			this.ComboBox1.FormattingEnabled = true;
			global::System.Windows.Forms.Control comboBox = this.ComboBox1;
			location = new global::System.Drawing.Point(41, 40);
			comboBox.Location = location;
			this.ComboBox1.Name = "ComboBox1";
			global::System.Windows.Forms.Control comboBox2 = this.ComboBox1;
			size = new global::System.Drawing.Size(60, 20);
			comboBox2.Size = size;
			this.ComboBox1.TabIndex = 3;
			this.ComboBox1.Text = "1:100";
			this.ComboBox2.FormattingEnabled = true;
			global::System.Windows.Forms.Control comboBox3 = this.ComboBox2;
			location = new global::System.Drawing.Point(41, 6);
			comboBox3.Location = location;
			this.ComboBox2.Name = "ComboBox2";
			global::System.Windows.Forms.Control comboBox4 = this.ComboBox2;
			size = new global::System.Drawing.Size(216, 20);
			comboBox4.Size = size;
			this.ComboBox2.TabIndex = 4;
			this.ComboBox2.Text = "一层平面图";
			this.Label2.AutoSize = true;
			global::System.Windows.Forms.Control label3 = this.Label2;
			location = new global::System.Drawing.Point(6, 9);
			label3.Location = location;
			this.Label2.Name = "Label2";
			global::System.Windows.Forms.Control label4 = this.Label2;
			size = new global::System.Drawing.Size(29, 12);
			label4.Size = size;
			this.Label2.TabIndex = 5;
			this.Label2.Text = "图名";
			this.Label3.AutoSize = true;
			global::System.Windows.Forms.Control label5 = this.Label3;
			location = new global::System.Drawing.Point(6, 43);
			label5.Location = location;
			this.Label3.Name = "Label3";
			global::System.Windows.Forms.Control label6 = this.Label3;
			size = new global::System.Drawing.Size(29, 12);
			label6.Size = size;
			this.Label3.TabIndex = 6;
			this.Label3.Text = "比例";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			size = new global::System.Drawing.Size(263, 70);
			this.ClientSize = size;
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.ComboBox2);
			this.Controls.Add(this.ComboBox1);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TableLayoutPanel1);
			this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TM_frm";
			this.ShowInTaskbar = false;
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "图名标注";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
