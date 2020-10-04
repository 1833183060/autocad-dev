using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using ngeometry.VectorGeometry;

namespace TerrainComputeC.IO
{
	//[LicenseProvider(typeof(Class46))]
	public class ASCIISTL
	{
		public ASCIISTL()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(ASCIISTL));
			this.Triangles = new List<Triangle>();
			this.SolidName = "";
			//base..ctor();
		}

		private double[] method_0(string string_0, int int_0)
		{
			double[] array = new double[3];
			string[] array2 = string_0.Split(new char[]
			{
				' '
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length != 5)
			{
				throw new FormatException(string.Concat(new object[]
				{
					"Invalid STL ASCII format in line ",
					int_0,
					":",
					Environment.NewLine,
					string_0
				}));
			}
			array[0] = Convert.ToDouble(array2[2]);
			array[1] = Convert.ToDouble(array2[3]);
			array[2] = Convert.ToDouble(array2[4]);
			return array;
		}

		private double[] method_1(string string_0, ref int int_0)
		{
			int_0++;
			double[] array = new double[3];
			string[] array2 = string_0.Split(new char[]
			{
				' '
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length != 4)
			{
				throw new FormatException(string.Concat(new object[]
				{
					"Invalid STL ASCII format in line ",
					int_0,
					":",
					Environment.NewLine,
					string_0
				}));
			}
			array[0] = Convert.ToDouble(array2[1]);
			array[1] = Convert.ToDouble(array2[2]);
			array[2] = Convert.ToDouble(array2[3]);
			return array;
		}

		private string method_2(Point point_0)
		{
			if (point_0.X < 0.0 || point_0.Y < 0.0 || point_0.Z < 0.0)
			{
				this.HasNegativeCoordinates = true;
			}
			string text = Convert.ToSingle(point_0.X).ToString("E");
			string text2 = Convert.ToSingle(point_0.Y).ToString("E");
			string text3 = Convert.ToSingle(point_0.Z).ToString("E");
			return string.Concat(new string[]
			{
				text,
				" ",
				text2,
				" ",
				text3
			});
		}

		private bool method_3(Triangle triangle_0)
		{
			return triangle_0.Vertex1.X < 0.0 || triangle_0.Vertex1.Y < 0.0 || triangle_0.Vertex1.Z < 0.0 || triangle_0.Vertex2.X < 0.0 || triangle_0.Vertex2.Y < 0.0 || triangle_0.Vertex2.Z < 0.0 || triangle_0.Vertex3.X < 0.0 || triangle_0.Vertex3.Y < 0.0 || triangle_0.Vertex3.Z < 0.0;
		}

		private bool method_4(Triangle triangle_0, Vector3d vector3d_0)
		{
			bool result;
			try
			{
				Global.SuspendEpsilon(1E-06, 1E-06);
				if (triangle_0.NormalVector.Normalize() == vector3d_0.Normalize())
				{
					Global.ResumeEpsilon();
					result = false;
				}
				else
				{
					Global.ResumeEpsilon();
					result = true;
				}
			}
			catch
			{
				Global.ResumeEpsilon();
				result = true;
			}
			return result;
		}

		public void Read(string fileName)
		{
			using (StreamReader streamReader = new StreamReader(fileName))
			{
				int num = 0;
				while (streamReader.Peek() >= 0)
				{
					string text = streamReader.ReadLine();
					num++;
					if (num == 1)
					{
						if (!text.ToUpper().StartsWith("SOLID"))
						{
							throw new FormatException(string.Concat(new object[]
							{
								"Invalid STL ASCII header in line ",
								num,
								":",
								Environment.NewLine,
								text
							}));
						}
						this.SolidName = text.Substring(5).Trim();
					}
					else
					{
						if (text.ToUpper().StartsWith("ENDSOLID"))
						{
							break;
						}
						double[] array = this.method_0(text, num);
						streamReader.ReadLine();
						num++;
						double[] array2 = this.method_1(streamReader.ReadLine(), ref num);
						double[] array3 = this.method_1(streamReader.ReadLine(), ref num);
						double[] array4 = this.method_1(streamReader.ReadLine(), ref num);
						streamReader.ReadLine();
						num++;
						streamReader.ReadLine();
						num++;
						try
						{
							Vector3d vector3d_ = new Vector3d(array[0], array[1], array[2]);
							Triangle triangle = new Triangle(new Point(array2[0], array2[1], array2[2]), new Point(array3[0], array3[1], array3[2]), new Point(array4[0], array4[1], array4[2]), false);
							if (this.method_3(triangle))
							{
								this.HasNegativeCoordinates = true;
							}
							if (this.method_4(triangle, vector3d_))
							{
								this.HasInconsitentNormals = true;
							}
							this.Triangles.Add(triangle);
							this.NumberOfTrianglesRead++;
						}
						catch
						{
							this.NumberOfDegenerateTriangles++;
						}
					}
				}
			}
		}

		public void Write(string fileName)
		{
			Global.SuspendEpsilon(0.0, 0.0);
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(fileName))
				{
					streamWriter.WriteLine("SOLID " + this.SolidName.Trim());
					for (int i = 0; i < this.Triangles.Count; i++)
					{
						try
						{
							Triangle triangle = this.Triangles[i];
							string str = this.method_2(triangle.NormalVector.Normalize().ToPoint());
							string str2 = this.method_2(triangle.Vertex1);
							string str3 = this.method_2(triangle.Vertex2);
							string str4 = this.method_2(triangle.Vertex3);
							streamWriter.WriteLine(" FACET NORMAL " + str);
							streamWriter.WriteLine("  OUTER LOOP");
							streamWriter.WriteLine("   VERTEX " + str2);
							streamWriter.WriteLine("   VERTEX " + str3);
							streamWriter.WriteLine("   VERTEX " + str4);
							streamWriter.WriteLine("  ENDLOOP");
							streamWriter.WriteLine(" ENDFACET");
							this.NumberOfTrianglesWritten++;
						}
						catch
						{
							this.NumberOfDegenerateTriangles++;
						}
					}
					streamWriter.WriteLine("ENDSOLID " + this.SolidName);
				}
				Global.ResumeEpsilon();
			}
			catch
			{
				Global.ResumeEpsilon();
				throw;
			}
		}

		public bool HasInconsitentNormals;

		public bool HasNegativeCoordinates;

		public int NumberOfDegenerateTriangles;

		public int NumberOfTrianglesRead;

		public int NumberOfTrianglesWritten;

		public string SolidName;

		public List<Triangle> Triangles;
	}
}
