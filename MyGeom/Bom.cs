using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
namespace MyList
{
    public class Bom:IAttrRef
    {
        public string findNo { get; set; }
        public string docNumber { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string material { get; set; }
        public string singleWeight { get; set; }
        public string totalWeight { get; set; }
        public string remark { get; set; }
        public int qty { get; set; }

        void IAttrRef.write(string tag, string text)
        {
            Document curDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = curDoc.Database;
            Editor ed = curDoc.Editor;
            ed.WriteMessage("\ntt:"+tag+"ss:"+text);
            switch (tag)
            {
                case "code":
                case "CODE":
                case "代号":
                    docNumber = text;
                    break;
                case "序号":
                case "index":
                case "INDEX":
                    findNo = text;
                    break;
                case "总重":
                case "TOTAL-WEIGHT":
                    totalWeight = text;
                    break;
                case "单重":
                case "SINGLE-WEIGHT":
                    singleWeight = text;
                    break;
                case "材料":
                case "MATERIAL":
                    material = text;
                    break;
                case "名称及规格":
                case "NAME":
                case "名称":
                    name = text;
                    break;
                case "规格":
                    model = text;
                    break;
                case "数量":
                case "AMOUNT":
                    qty =int.Parse( text);
                    break;
                case "remark":
                case "REMARK":
                case "备注":
                    remark = text;
                    break;
            }
        }
    }
}
/*block name:PC_MXB_BLOCK
tag:备注--value:
tag:总重--value:4.8
tag:单重--value:1.2
tag:材料--value:Q235A
tag:数量--value:4
tag:名称及规格--value:水泵支撑
tag:代号--value:PM-SBZC
tag:序号--value:1*/
