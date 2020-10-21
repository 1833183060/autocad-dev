using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MyGeom {

    public class Degree
    {
        public double Value { get; set; }
        public Degree(double v)
        {
            Value = v;
        }
    }
    public class MyTransform {
        /// <summary>
        /// 以中心点旋转Angle角度
        /// </summary>
        /// <param name="center">旋转中心点</param>
        /// <param name="point">待旋转的点</param>
        /// <param name="angle">旋转角度, 逆时针</param>
        /// <param name="result">旋转后的点</param>
        public static void rotate(double[] point,double[] center,double angle,ref double[] result)
        {
            result[0] = (point[0] - center[0]) * Math.Cos(angle) - (point[1] - center[1]) * Math.Sin(angle) + center[0];
            result[1] = (point[0] - center[0]) * Math.Sin(angle) + (point[1] - center[1]) * Math.Cos(angle) + center[1];
        }
        public static void transform(double[] point, double[] center, Degree angle, double[] translate, ref double[] result)
        {
            transform(point, center, angle.Value * Math.PI / 180,translate,ref result);
        }
        /// <summary>
        /// 先旋转angle，然后移动translate
        /// </summary>
        /// <param name="point"></param>
        /// <param name="center"></param>
        /// <param name="angle"></param>
        /// <param name="translate"></param>
        /// <param name="result"></param>
        public static void transform(double[] point, double[] center, double angle,double[] translate, ref double[] result)
        {
            result[0] = (point[0] - center[0]) * Math.Cos(angle) - (point[1] - center[1]) * Math.Sin(angle) + center[0]+translate[0];
            result[1] = (point[0] - center[0]) * Math.Sin(angle) + (point[1] - center[1]) * Math.Cos(angle) + center[1]+translate[1];
        }

        public static void rotate(double[][] points, double[] center, double angle,out double[][] result)
        {
            int len=points.Length;
            result=new double[len][];
            for (int i = 0; i < points.Length; ++i)
            {
                result[i] = new double[2];
                rotate(points[i], center, angle, ref result[i]);

            }
        }
        public static void transform(double[][] points, double[] center, Degree angle, double[] translate, out double[][] result)
        {
            transform(points, center, angle.Value * Math.PI / 180,translate,out result);
        }
        
        /// <summary>
        /// 先旋转angle，然后移动translate
        /// </summary>
        /// <param name="points"></param>
        /// <param name="center"></param>
        /// <param name="angle"></param>
        /// <param name="translate"></param>
        /// <param name="result"></param>
        public static void transform(double[][] points, double[] center, double angle,double[] translate, out double[][] result)
        {
            int len = points.Length;
            result = new double[len][];
            for (int i = 0; i < points.Length; ++i)
            {
                result[i] = new double[2];
                transform(points[i], center, angle,translate, ref result[i]);

            }
        }
    }

}
