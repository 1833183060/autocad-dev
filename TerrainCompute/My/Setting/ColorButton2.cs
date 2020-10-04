using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace TerrainComputeC.My
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ColorButton2:Button
    {
        public Color Color { get; set; }
        public ColorButton2()
        {
            this.FlatStyle = FlatStyle.Standard;
            this.Click += ColorButton_Click;
            this.Width = 20;
            this.Height = 20;
        }
        public bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {

        }
        void ColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.FullOpen = true;
            DialogResult r= d.ShowDialog();
            if (r == DialogResult.OK)
            {
                this.Color = d.Color;
            }
            
        }

    }
}
