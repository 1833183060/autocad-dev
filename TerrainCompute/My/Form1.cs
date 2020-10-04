using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerrainComputeC.My
{
    public partial class Form1 : Form
    {
        UserCmd cmd;
        public Form1(UserCmd c)
        {
            InitializeComponent();
            cmd =c;
            TCSettings s = c.mydb.tcSetting;
            propertyGrid1.SelectedObject = s;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //blinkBrowser1.Url = "mb://index.html";
            
        }

        private void btnGenTriFace_Click(object sender, EventArgs e)
        {
            cmd.increasePoint();
        }

        private void faceColorize_Click(object sender, EventArgs e)
        {
            cmd.faceColorize();
        }

        private void btnGenContour_Click(object sender, EventArgs e)
        {
            cmd.contour();
        }
    }
}
