﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace TerrainComputeC.My
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public partial class ColorEditor : System.Drawing.Design.UITypeEditor
    {
        public ColorEditor()
        {
            
        }
        
        //下拉式还是弹出式
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        // 为属性显示UI编辑框
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            //值类型不为List<Color>，直接返回value
            if (value.GetType() != typeof(List<Color>))
                return value;

            //值为List<Color>，显示下拉式或弹出编辑框
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                // 显示编辑框并初始化编辑框的值
                FillColorControl angleControl = new FillColorControl((List<Color>)value);
                edSvc.DropDownControl(angleControl);
                // 返回编辑框中编辑的值.
                if (value.GetType() == typeof(List<Color>))
                    return angleControl.ColorList;
            }
            return value;
        }
      
        //下面两个函数是为了在PropertyGrid中显示一个辅助的效果
        //可以不用重写
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            List<Color> cl = e.Value as List<Color>;
            if (cl == null)
            {
                ColorProp cp = e.Value as ColorProp;
                cl = cp.colorList;
            }
            int normalX = (e.Bounds.Width / 2);
            int normalY = (e.Bounds.Height / 2);
            int curY = e.Bounds.Y;
            for (int i = 0; i < cl.Count; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(cl[i]), e.Bounds.X+(i*10), e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }
                
            e.Graphics.FillEllipse(new SolidBrush(Color.White), e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 3, e.Bounds.Height - 3);
            e.Graphics.FillEllipse(new SolidBrush(Color.SlateGray), normalX + e.Bounds.X - 1, normalY + e.Bounds.Y - 1, 3, 3);
            
            double radians = 5;
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red), 1), normalX + e.Bounds.X, normalY + e.Bounds.Y,
                e.Bounds.X + (normalX + (int)((double)normalX * Math.Cos(radians))),
                e.Bounds.Y + (normalY + (int)((double)normalY * Math.Sin(radians))));
        }
        
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
