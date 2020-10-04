namespace TerrainComputeC.My
{
    partial class ColorPropControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.updown = new System.Windows.Forms.NumericUpDown();
            this.btnAutoGen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 100);
            this.panel1.TabIndex = 0;
            // 
            // updown
            // 
            this.updown.Location = new System.Drawing.Point(3, 119);
            this.updown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.updown.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.updown.Name = "updown";
            this.updown.Size = new System.Drawing.Size(147, 21);
            this.updown.TabIndex = 3;
            this.updown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.updown.ValueChanged += new System.EventHandler(this.updown_ValueChanged);
            // 
            // btnAutoGen
            // 
            this.btnAutoGen.Location = new System.Drawing.Point(157, 119);
            this.btnAutoGen.Name = "btnAutoGen";
            this.btnAutoGen.Size = new System.Drawing.Size(75, 23);
            this.btnAutoGen.TabIndex = 4;
            this.btnAutoGen.Text = "自动生成";
            this.btnAutoGen.UseVisualStyleBackColor = true;
            this.btnAutoGen.Click += new System.EventHandler(this.btnAutoGen_Click);
            // 
            // ColorPropControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 152);
            this.Controls.Add(this.btnAutoGen);
            this.Controls.Add(this.updown);
            this.Controls.Add(this.panel1);
            this.Name = "ColorPropControl";
            this.Load += new System.EventHandler(this.FillColorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown updown;
        private System.Windows.Forms.Button btnAutoGen;
    }
}
