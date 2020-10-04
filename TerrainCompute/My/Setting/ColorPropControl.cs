using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerrainComputeC.Colorize;
namespace TerrainComputeC.My
{
    public partial class ColorPropControl : Form
    {
        public ColorProp CP;
        public ColorPropControl(ColorProp cl)
        {
            CP = cl;
            InitializeComponent();
        }

        private void updown_ValueChanged(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            
            d.ShowDialog();
            
        }

        private void FillColorControl_Load(object sender, EventArgs e)
        {
            int top=1;
            int left=1;
            for (int i = 0; i < CP.colorList.Count; i++)
            {
                ColorButton b = new ColorButton(i);
                b.BackColorChanged += b_BackColorChanged;
                b.BackColor = CP.colorList[i];
                b.Top=top;
                b.Left=left;
                left += b.Width;

                if (left + b.Width >= this.panel1.Width)
                {
                    top += b.Height + 2;
                    left= 1;
                    
                }

                this.panel1.Controls.Add(b);
            }
            
        }

        void b_BackColorChanged(object sender, EventArgs e)
        {
            ColorButton b = sender as ColorButton;
            this.CP.colorList[b.Index] = b.BackColor;
        }

        private void btnAutoGen_Click(object sender, EventArgs e)
        {
            this.CP.colorList = ColorizeBase.genColorList((int)(updown.Value));
        }
    }

    
}
