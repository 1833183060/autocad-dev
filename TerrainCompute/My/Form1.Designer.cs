namespace TerrainComputeC.My
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnGenTriFace = new System.Windows.Forms.Button();
            this.faceColorize = new System.Windows.Forms.Button();
            this.btnGenContour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(112, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(333, 208);
            this.propertyGrid1.TabIndex = 1;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // btnGenTriFace
            // 
            this.btnGenTriFace.Location = new System.Drawing.Point(2, 3);
            this.btnGenTriFace.Name = "btnGenTriFace";
            this.btnGenTriFace.Size = new System.Drawing.Size(88, 23);
            this.btnGenTriFace.TabIndex = 2;
            this.btnGenTriFace.Text = "生成三维网格";
            this.btnGenTriFace.UseVisualStyleBackColor = true;
            this.btnGenTriFace.Click += new System.EventHandler(this.btnGenTriFace_Click);
            // 
            // faceColorize
            // 
            this.faceColorize.Location = new System.Drawing.Point(2, 32);
            this.faceColorize.Name = "faceColorize";
            this.faceColorize.Size = new System.Drawing.Size(88, 23);
            this.faceColorize.TabIndex = 3;
            this.faceColorize.Text = "三维网格着色";
            this.faceColorize.UseVisualStyleBackColor = true;
            this.faceColorize.Click += new System.EventHandler(this.faceColorize_Click);
            // 
            // btnGenContour
            // 
            this.btnGenContour.Location = new System.Drawing.Point(2, 61);
            this.btnGenContour.Name = "btnGenContour";
            this.btnGenContour.Size = new System.Drawing.Size(88, 23);
            this.btnGenContour.TabIndex = 4;
            this.btnGenContour.Text = "生成等高线";
            this.btnGenContour.UseVisualStyleBackColor = true;
            this.btnGenContour.Click += new System.EventHandler(this.btnGenContour_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 278);
            this.Controls.Add(this.btnGenContour);
            this.Controls.Add(this.faceColorize);
            this.Controls.Add(this.btnGenTriFace);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnGenTriFace;
        private System.Windows.Forms.Button faceColorize;
        private System.Windows.Forms.Button btnGenContour;


    }
}