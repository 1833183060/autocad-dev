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
    public partial class ResolutionControl : UserControl
    {
        public int resolution;
        public delegate void ResolutionChangedDel(int r);
        public event ResolutionChangedDel ResolutionChanged;
        public ResolutionControl(int r)
        {
            resolution = r;
            InitializeComponent();
        }

        private void updown_ValueChanged(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            
            d.ShowDialog();
            
        }

        private void FillColorControl_Load(object sender, EventArgs e)
        {
            trackBar1.Value = resolution;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = false;
            resolution = trackBar1.Value;
            ResolutionChanged(resolution);
            UserCmd.CurCmd.setResolution(resolution);
            trackBar1.Enabled = true;
        }

        
    }

    
}
