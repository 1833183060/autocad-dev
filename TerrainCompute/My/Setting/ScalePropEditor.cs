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
    public partial class ScalePropEditor : System.Drawing.Design.UITypeEditor
    {
        public ScalePropEditor()
        {
            
        }
        
        //下拉式还是弹出式
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
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
                e.Graphics.FillRectangle(new SolidBrush(cl[i]), e.Bounds.X+(i*10), e.Bounds.Y, 10, e.Bounds.Height);
            }
                
           
        }
        
        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return false;
        }
    }
}
