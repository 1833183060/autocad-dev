using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace TerrainComputeC.My
{
    internal class ColorPropConverter : ExpandableObjectConverter
    {

        public override bool CanConvertFrom(
              ITypeDescriptorContext context, Type t)
        {
            return false;
            if (t == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, t);

        }

        public override object ConvertFrom(
              ITypeDescriptorContext context,
              CultureInfo info,
               object value) {

      if (value is string) {
         try {
         string s = (string) value;
         // parse the format "Last, First (Age)"
         //
         int comma = s.IndexOf(',');
         if (comma != -1) {
            // now that we have the comma, get 
            // the last name.
            string last = s.Substring(0, comma);
             int paren = s.LastIndexOf('(');
            if (paren != -1 && 
                  s.LastIndexOf(')') == s.Length - 1) {
               // pick up the first name
               string first = 
                     s.Substring(comma + 1, 
                        paren - comma - 1);
               // get the age
               int age = Int32.Parse(
                     s.Substring(paren + 1, 
                     s.Length - paren - 2));
                  ColorProp p = new ColorProp();
                  
                  return p;
            }
         }
      }
      catch {}
      // if we got this far, complain that we
      // couldn't parse the string
      //
      throw new ArgumentException(
         "Can not convert '" + (string)value + 
                  "' to type Person");
         
      }
      return base.ConvertFrom(context, info, value);
   }

        public override object ConvertTo(
                 ITypeDescriptorContext context,
                 CultureInfo culture,
                 object value,
                 Type destType)
        {
            if (destType == typeof(string) && value is ColorProp)
            {
                ColorProp p = (ColorProp)value;
                // simply build the string as "Last, First (Age)"
                Button b = new Button();
                b.Text = "aaaa";
                return p;
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
