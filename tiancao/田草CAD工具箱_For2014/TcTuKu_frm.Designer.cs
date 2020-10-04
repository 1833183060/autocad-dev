namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcTuKu_frm : global::System.Windows.Forms.Form
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
			this.TableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new global::System.Windows.Forms.Button();
			this.Cancel_Button = new global::System.Windows.Forms.Button();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			this.TableLayoutPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			global::System.Windows.Forms.Control tableLayoutPanel = this.TableLayoutPanel1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(277, 274);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			global::System.Windows.Forms.Control tableLayoutPanel2 = this.TableLayoutPanel1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(146, 29);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 0;
			this.OK_Button.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			global::System.Windows.Forms.Control ok_Button = this.OK_Button;
			location = new global::System.Drawing.Point(3, 3);
			ok_Button.Location = location;
			this.OK_Button.Name = "OK_Button";
			global::System.Windows.Forms.Control ok_Button2 = this.OK_Button;
			size = new global::System.Drawing.Size(67, 23);
			ok_Button2.Size = size;
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "确定";
			this.Cancel_Button.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			global::System.Windows.Forms.Control cancel_Button = this.Cancel_Button;
			location = new global::System.Drawing.Point(76, 3);
			cancel_Button.Location = location;
			this.Cancel_Button.Name = "Cancel_Button";
			global::System.Windows.Forms.Control cancel_Button2 = this.Cancel_Button;
			size = new global::System.Drawing.Size(67, 23);
			cancel_Button2.Size = size;
			this.Cancel_Button.TabIndex = 1;
			this.Cancel_Button.Text = "取消";
			this.AcceptButton = this.OK_Button;
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			size = new global::System.Drawing.Size(435, 315);
			this.ClientSize = size;
			this.Controls.Add(this.TableLayoutPanel1);
			this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Dialog2";
			this.ShowInTaskbar = false;
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dialog2";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
