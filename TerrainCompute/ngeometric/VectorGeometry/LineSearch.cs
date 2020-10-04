using System;
using System.ComponentModel;

namespace ngeometry.VectorGeometry
{	
	public class LineSearch
	{
		public LineSearch()
		{
          
		}

		public static double GoldenSection(double epsilon, double lowerBound, double upperBound, LineSearch.ObjectiveFunction function)
		{
			double num = (Math.Sqrt(5.0) - 1.0) / 2.0;
			int num2 = (int)Math.Ceiling(Math.Log(epsilon / (upperBound - lowerBound)) / Math.Log(num));
			double[] array = new double[num2 + 1];
			double[] array2 = new double[num2 + 1];
			double[] array3 = new double[num2 + 1];
			double[] array4 = new double[num2 + 1];
			double[] array5 = new double[num2 + 1];
			double[] array6 = new double[num2 + 1];
			array[0] = lowerBound;
			array2[0] = upperBound;
			array3[0] = array[0] + (1.0 - num) * (array2[0] - array[0]);
			array4[0] = array[0] + num * (array2[0] - array[0]);
			array5[0] = function(array3[0]);
			array6[0] = function(array4[0]);
			for (int i = 0; i < num2; i++)
			{
				if (array5[i] >= array6[i])
				{
					array[i + 1] = array3[i];
					array2[i + 1] = array2[i];
					array3[i + 1] = array4[i];
					array4[i + 1] = array[i + 1] + num * (array2[i + 1] - array[i + 1]);
					array5[i + 1] = array6[i];
					array6[i + 1] = function(array4[i + 1]);
				}
				else
				{
					array[i + 1] = array[i];
					array2[i + 1] = array4[i];
					array3[i + 1] = array[i + 1] + (1.0 - num) * (array2[i + 1] - array[i + 1]);
					array4[i + 1] = array3[i];
					array6[i + 1] = array5[i];
					array5[i + 1] = function(array3[i + 1]);
				}
			}
			return (array3[num2] + array4[num2]) / 2.0;
		}

		
		public delegate double ObjectiveFunction(double value);
	}
}
