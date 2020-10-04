using System;
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
    public partial class ResolutionEditor : System.Drawing.Design.UITypeEditor
    {
        
        public ResolutionEditor()
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
            
            if (value.GetType() != typeof(int))
                return value;

            //值为List<Color>，显示下拉式或弹出编辑框
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc != null)
            {
                // 显示编辑框并初始化编辑框的值
                ResolutionControl c = new ResolutionControl((int)value);
                c.ResolutionChanged += c_ResolutionChanged;
                edSvc.DropDownControl(c);
                // 返回编辑框中编辑的值.
                if (value.GetType() == typeof(int))
                    return c.resolution;
            }
            return value;
        }

        void c_ResolutionChanged(int r)
        {
            
        }
      
        //下面两个函数是为了在PropertyGrid中显示一个辅助的效果
        //可以不用重写
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
            
        }
        
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }
    }
}
