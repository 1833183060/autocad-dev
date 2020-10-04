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
    [TypeConverter(typeof(ColorPropConverter))]
    public class ColorProp
    {
        public List<Color> colorList;
    }
}
