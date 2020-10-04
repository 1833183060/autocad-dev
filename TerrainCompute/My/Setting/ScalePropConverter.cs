using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace TerrainComputeC.My
{
    internal class ScalePropConverter : ExpandableObjectConverter
    {

        public override bool CanConvertFrom(
              ITypeDescriptorContext context, Type t)
        {
            
            if (t == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, t);

        }
        
        public override bool CanConvertTo(
              ITypeDescriptorContext context, Type t)
        {

            if (t == typeof(ScaleProp))
            {
                return true;
            }
            return base.CanConvertTo(context, t);

        }

        public override object ConvertFrom(
              ITypeDescriptorContext context,
              CultureInfo info,
               object value) {
                   ScaleProp p = null;
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
               p = new ScaleProp();
                  
                  return p;
            }
         }
      }
      catch(System.Exception ex)
         {
      }
      // if we got this far, complain that we
      // couldn't parse the string
      //
      throw new ArgumentException(
         "Can not convert '" + (string)value + 
                  "' to type Person");
         
      }
      p = new ScaleProp();

      return p;
      return base.ConvertFrom(context, info, value);
   }

        public override object ConvertTo(
                 ITypeDescriptorContext context,
                 CultureInfo culture,
                 object value,
                 Type destType)
        {
            ScaleProp p=null;
            if (destType == typeof(string) && value is ScaleProp)
            {
                 p = (ScaleProp)value;
              
                return p.ToString();
            }  
            p=new ScaleProp();

            return p.ToString();
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
