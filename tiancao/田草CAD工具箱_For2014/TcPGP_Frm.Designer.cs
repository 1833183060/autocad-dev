namespace 田草CAD工具箱_For2014
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class TcPGP_Frm : global::System.Windows.Forms.Form
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
			this.DataGridView1 = new global::System.Windows.Forms.DataGridView();
			this.全称 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.简称 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.说明 = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Label1 = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.DataGridView1).BeginInit();
			this.SuspendLayout();
			this.DataGridView1.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.全称,
				this.简称,
				this.说明
			});
			global::System.Windows.Forms.Control dataGridView = this.DataGridView1;
			global::System.Drawing.Point location = new global::System.Drawing.Point(0, 3);
			dataGridView.Location = location;
			this.DataGridView1.Name = "DataGridView1";
			this.DataGridView1.RowTemplate.Height = 23;
			global::System.Windows.Forms.Control dataGridView2 = this.DataGridView1;
			global::System.Drawing.Size size = new global::System.Drawing.Size(529, 209);
			dataGridView2.Size = size;
			this.DataGridView1.TabIndex = 0;
			this.全称.HeaderText = "全称";
			this.全称.Name = "全称";
			this.简称.HeaderText = "简称";
			this.简称.Name = "简称";
			this.说明.HeaderText = "说明";
			this.说明.Name = "说明";
			global::System.Windows.Forms.Control button = this.Button1;
			location = new global::System.Drawing.Point(456, 218);
			button.Location = location;
			this.Button1.Name = "Button1";
			global::System.Windows.Forms.Control button2 = this.Button1;
			size = new global::System.Drawing.Size(73, 25);
			button2.Size = size;
			this.Button1.TabIndex = 1;
			this.Button1.Text = "更新";
			this.Button1.UseVisualStyleBackColor = true;
			this.Label1.AutoSize = true;
			global::System.Windows.Forms.Control label = this.Label1;
			location = new global::System.Drawing.Point(12, 282);
			label.Location = location;
			this.Label1.Name = "Label1";
			global::System.Windows.Forms.Control label2 = this.Label1;
			size = new global::System.Drawing.Size(41, 12);
			label2.Size = size;
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Label1";
			global::System.Drawing.SizeF autoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
			this.AutoScaleDimensions = autoScaleDimensions;
			this.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			size = new global::System.Drawing.Size(532, 246);
			this.ClientSize = size;
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.DataGridView1);
			this.Name = "PGP_Frm";
			this.Text = "AutoCAD简化命令列表";
			((global::System.ComponentModel.ISupportInitialize)this.DataGridView1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private global::System.ComponentModel.IContainer icontainer_0;
	}
}
