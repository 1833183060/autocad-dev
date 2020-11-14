//https://adndevblog.typepad.com/autocad/2012/04/retrieving-nested-entities-under-cursor-aperture-using-net-api.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;
namespace AcadDemo
{
    class SelectDemo
    {
    }

    class ArxImports
    {
        public struct ads_name
        {

            public IntPtr a;

            public IntPtr b;

        };



        [StructLayout(LayoutKind.Sequential, Size = 32)]

        public struct resbuf { }

        [DllImport("acad.exe",CallingConvention = CallingConvention.Cdecl,CharSet = CharSet.Unicode,ExactSpelling = true)]
        public static extern PromptStatus acedSSGet(string str, IntPtr pt1, IntPtr pt2,IntPtr filter, out ads_name ss);

        [DllImport("acad.exe",CallingConvention = CallingConvention.Cdecl,CharSet = CharSet.Unicode,ExactSpelling = true)]
        public static extern PromptStatus acedSSFree(ref ads_name ss);

        [DllImport("acad.exe",CallingConvention = CallingConvention.Cdecl,CharSet = CharSet.Unicode,ExactSpelling = true)]
        public static extern PromptStatus acedSSLength(ref ads_name ss, out int len);

        [DllImport("acad.exe",CallingConvention = CallingConvention.Cdecl,CharSet = CharSet.Unicode,ExactSpelling = true)]
        public unsafe static extern PromptStatus acedSSNameX(resbuf** rbpp, ref ads_name ss, int i);
    }

    public class CursorDetectCls
    {
        Editor _ed;

        [CommandMethod("UnderCursorNested")]
        public void UnderCursorNested()
        {
            _ed = Application.DocumentManager.MdiActiveDocument.Editor;

            //Set up PointMonitor event

            _ed.PointMonitor +=new PointMonitorEventHandler(PointMonitorMulti);
        }

        void PointMonitorMulti(object sender, PointMonitorEventArgs e)
        {
            //Filters only block references (INSERT)
            //that are on layer "0"

            ResultBuffer resbuf = new ResultBuffer(
                new TypedValue(-4, "<and"),
                new TypedValue(0, "INSERT"),
                new TypedValue(8, "0"),
                new TypedValue(-4, "and>"));

            ObjectId[] ids = FindAtPointNested(
                _ed.Document,
                e.Context.RawPoint,
                true,
                resbuf.UnmanagedObject);

            //Dump result to commandline

            foreach (ObjectId id in ids)
            {
                _ed.WriteMessage("\n - Entity: {0} [Id:{1}]",id.ObjectClass.Name,id.ToString());

            }
        }
        //Retruns ObjectIds of entities at a specific position

        //Including nested entities in block references

        static public ObjectId[] FindAtPointNested(
            Document doc,
            Point3d worldPoint,
            bool selectAll,
            IntPtr filter)
        {
            System.Collections.Generic.List<ObjectId> ids =new System.Collections.Generic.List<ObjectId>();

            Matrix3d wcs2ucs =doc.Editor.CurrentUserCoordinateSystem.Inverse();

            Point3d ucsPoint = worldPoint.TransformBy(wcs2ucs);

            string arg = selectAll ? "_:E:N" : "_:N";

            IntPtr ptrPoint = Marshal.UnsafeAddrOfPinnedArrayElement(worldPoint.ToArray(), 0);
            
            ArxImports.ads_name sset;

            PromptStatus prGetResult = ArxImports.acedSSGet(arg, ptrPoint, IntPtr.Zero, filter, out sset);
            int len;

            ArxImports.acedSSLength(ref sset, out len);
            //Need to rely on unsafe code in order to use pointers *

            unsafe
            {
                for (int i = 0; i < len; ++i)
                {
                    ArxImports.resbuf rb = new ArxImports.resbuf();
                    ArxImports.resbuf* pRb = &rb;

                    if (ArxImports.acedSSNameX(&pRb, ref sset, i) !=

                        PromptStatus.OK)

                        continue;



                    //Create managed ResultBuffer from our resbuf struct

                    using (ResultBuffer rbMng = DisposableWrapper.Create(

                        typeof(ResultBuffer),

                        (IntPtr)pRb,

                        true) as ResultBuffer)
                    {

                        foreach (TypedValue tpVal in rbMng)
                        {

                            //Not interested if it isn't an ObjectId

                            if (tpVal.TypeCode != 5006) //RTENAME

                                continue;



                            ObjectId id = (ObjectId)tpVal.Value;



                            if (id != null)

                                ids.Add(id);

                        }

                    }

                }

            }



            ArxImports.acedSSFree(ref sset);



            return ids.ToArray();

        }

    }
}
