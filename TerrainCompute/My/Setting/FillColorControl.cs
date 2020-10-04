using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerrainComputeC.My
{
    public partial class FillColorControl : UserControl
    {
        public List<Color> ColorList;
        public FillColorControl(List<Color> cl)
        {
            ColorList = cl;
            InitializeComponent();
        }

        private void updown_ValueChanged(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            
            d.ShowDialog();
            
        }

        private void FillColorControl_Load(object sender, EventArgs e)
        {
            ColorButton b = new ColorButton(0);
            this.panel1.Controls.Add(b);
        }
    }

    public class MyControl : System.Windows.Forms.UserControl
    {
        private double _angle;

        [BrowsableAttribute(true)]
        public double Angle
        {
            get
            { return _angle; }
            set
            { _angle = value; }
        }

        public MyControl()
        {
            this._angle = 90;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("The Angle is " + _angle, this.Font, Brushes.Red, 0, 0);
        }
    }
}
