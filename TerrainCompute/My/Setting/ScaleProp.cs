using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;
namespace TerrainComputeC.My
{
    [Serializable]
    [TypeConverter(typeof(ScalePropConverter))]
    [Browsable(true)]
    public class ScaleProp
    {
        [Browsable(true)]
        [DescriptionAttribute("Set the major part of version number")]
        public double X {
            get
            {
                return xscale;
            }
        }
        [DescriptionAttribute("Set the major part of version number")]
        public double Y {
            get
            {
                return yscale;
            }
        }
        [DescriptionAttribute("Set the major part of version number")]
        public double Z {
            get {
                return zscale; }
            set { 
                zscale = value; 
            }
        }
         double xscale;
         double yscale;
         double zscale;
        public ScaleProp()
        {
            xscale = 1;
            yscale = 1;
            zscale = 1;
        }
    }
}
