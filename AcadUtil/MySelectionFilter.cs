using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace AcadUtil
{
    //using 图元类型 = AcadUtil.MySelectionFilter.EntityType;
    public static class MySelectionFilter
    {
        
        public static void Start()
        {
            typedValues.Clear();
        }
        public static SelectionFilter End()
        {
            return new SelectionFilter(typedValues.ToArray());
        }
        public static void StartAnd()
        {
            typedValues.Add(new TypedValue((int)DxfCode.Operator, "<and"));
        }
        public static void EndAnd()
        {
            typedValues.Add(new TypedValue((int)DxfCode.Operator, "and>"));
        }

        public static void StartOr()
        {
            typedValues.Add(new TypedValue((int)DxfCode.Operator, "<or"));
        }
        public static void EndOr()
        {
            typedValues.Add(new TypedValue((int)DxfCode.Operator, "or>"));
        }

        class DoubleType{
            static void eq(double v)
            {

            }
        }
        public class EntityType
        {
            class EntityTypeR{

            }
            
            public static class eq{
                public static void Line()
                {                    
                    typedValues.Add(new TypedValue((int)DxfCode.Start, "LINE"));
                }
                public static void Region()
                {                    
                    typedValues.Add(new TypedValue((int)DxfCode.Start, "Region"));
                }
                public static void Text()
                {                    
                    typedValues.Add(new TypedValue((int)DxfCode.Start, "Text"));
                }
                public static void Hatch()
                {                    
                    typedValues.Add(new TypedValue((int)DxfCode.Start, "Hatch"));
                }
            }
        }
        public class 图元类型 : EntityType
        {

        }
        public static class Line
        {
            class StartPointX:DoubleType
            {
                static void eq(double v)
                {
                    typedValues.Add(new TypedValue((int)DxfCode.Operator,"=="));
                    typedValues.Add(new TypedValue((int)DxfCode.XCoordinate, v));
                }
                static void egt(double v)
                {
                    typedValues.Add(new TypedValue((int)DxfCode.Operator, ">="));
                    typedValues.Add(new TypedValue((int)DxfCode.XCoordinate, v));
                }
            }
        }

        public static void Layer(string layerName)
        {
            typedValues.Add(new TypedValue((int)DxfCode.LayerName, layerName));
        }
        
        
        #region 变量
        static List<TypedValue> typedValues = new List<TypedValue>();
        
        #endregion
    }
    
}

