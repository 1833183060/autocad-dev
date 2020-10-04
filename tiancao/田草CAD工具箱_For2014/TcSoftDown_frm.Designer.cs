namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcSoftDown_frm : global::System.Windows.Forms.Form
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
			this.TableLayoutPanel1 = new global::System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new global::System.Windows.Forms.Button();
			this.Cancel_Button = new global::System.Windows.Forms.Button();
			this.Label25 = new global::System.Windows.Forms.Label();
			this.WebBrowser1 = new global::System.Windows.Forms.WebBrowser();
			this.TableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			this.TableLayoutPanel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			global::System.Windows.Forms.Control tableLayoutPanel = this.TableLayoutPanel1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(277, 260);
			tableLayoutPanel.Location = location;
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			global::System.Windows.Forms.Control tableLayoutPanel2 = this.TableLayoutPanel1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(146, 27);
			tableLayoutPanel2.Size = size;
			this.TableLayoutPanel1.TabIndex = 0;
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
			this.Label25.AutoSize = true;
			this.Label25.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.Label25.Font = new global::System.Drawing.Font("宋体", 9f, global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 134);
			this.Label25.ForeColor = global::System.Drawing.SystemColors.ActiveCaption;
			global::System.Windows.Forms.Control label = this.Label25;
			location = new global::System.Drawing.Point(12, 267);
			label.Location = location;
			this.Label25.Name = "Label25";
			global::System.Windows.Forms.Control label2 = this.Label25;
			size = new global::System.Drawing.Size(113, 12);
			label2.Size = size;
			this.Label25.TabIndex = 55;
			this.Label25.Text = "软件又升级更新啦！";
			global::System.Windows.Forms.Control webBrowser = this.WebBrowser1;
			location = new global::System.Drawing.Point(12, 3);
			webBrowser.Location = location;
			global::System.Windows.Forms.Control webBrowser2 = this.WebBrowser1;
			size = new global::System.Drawing.Size(20, 20);
			webBrowser2.MinimumSize = size;
			this.WebBrowser1.Name = "WebBrowser1";
			global::System.Windows.Forms.Control webBrowser3 = this.WebBrowser1;
			size = new global::System.Drawing.Size(407, 250);
			webBrowser3.Size = size;
			this.WebBrowser1.TabIndex = 56;
			this.WebBrowser1.Url = new global::System.Uri("http://www.tiancao.net/softdown.htm", global::System.UriKind.Absolute);
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(435, 291);
			this.ClientSize = size;
			this.Controls.Add(this.WebBrowser1);
			this.Controls.Add(this.Label25);
			this.Controls.Add(this.TableLayoutPanel1);
			this.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TcSoftDown_frm";
			this.ShowInTaskbar = false;
			this.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "设计相关软件下载链接";
			this.TableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
