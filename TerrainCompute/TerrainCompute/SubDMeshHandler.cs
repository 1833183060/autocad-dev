using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using ngeometry.VectorGeometry;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class SubDMeshHandler
	{
		public SubDMeshHandler(List<Triangle> triangles)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(SubDMeshHandler));
			////base..ctor();
			this.list_4 = triangles;
			this.list_0 = new List<Point>();
			this.list_1 = new List<int>();
			this.list_2 = new List<int>();
			this.list_3 = new List<int>();
		}

		public void BuildDataStructure(bool showProgress)
		{
			PointSet pointSet = new PointSet();
			MessageFilter messageFilter = new MessageFilter();
            System.Windows.Forms.Application.AddMessageFilter(messageFilter);
			ProgressMeter progressMeter = new ProgressMeter();
			if (!showProgress)
			{
				progressMeter.Dispose();
			}
			if (showProgress)
			{
				progressMeter.SetLimit(4);
			}
			if (showProgress)
			{
				progressMeter.Start("Building data structure");
			}
			try
			{
				for (int i = 0; i < this.list_4.Count; i++)
				{
					messageFilter.CheckMessageFilter((long)i, 1000);
					pointSet.Add(this.list_4[i].Vertex1);
					pointSet.Add(this.list_4[i].Vertex2);
					pointSet.Add(this.list_4[i].Vertex3);
				}
				if (showProgress)
				{
					progressMeter.MeterProgress();
				}
				Global.SuspendEpsilon(0.0, 0.0);
				pointSet.RemoveMultiplePoints3d();
				if (showProgress)
				{
					progressMeter.MeterProgress();
				}
				pointSet.Sort();
				if (showProgress)
				{
					progressMeter.MeterProgress();
				}
				this.list_0 = pointSet.ToList();
				for (int j = 0; j < this.list_4.Count; j++)
				{
					messageFilter.CheckMessageFilter((long)j, 1000);
					int num = this.list_0.BinarySearch(this.list_4[j].Vertex1);
					if (num < 0)
					{
                        throw new System.Exception("Invalid vertex index.");
					}
					this.list_1.Add(num);
					int num2 = this.list_0.BinarySearch(this.list_4[j].Vertex2);
					if (num2 < 0)
					{
                        throw new System.Exception("Invalid vertex index.");
					}
					this.list_2.Add(num2);
					int num3 = this.list_0.BinarySearch(this.list_4[j].Vertex3);
					if (num3 < 0)
					{
                        throw new System.Exception("Invalid vertex index.");
					}
					this.list_3.Add(num3);
				}
				if (showProgress)
				{
					progressMeter.MeterProgress();
				}
				if (showProgress)
				{
					progressMeter.Stop();
				}
				Global.ResumeEpsilon();
			}
			catch
			{
				if (showProgress)
				{
					progressMeter.Stop();
				}
				Global.ResumeEpsilon();
				throw;
			}
		}

		public SubDMeshHandler.MeshGenerationResult GenerateSubDMesh()
		{
			if (this.list_4 == null)
			{
				throw new InvalidOperationException("Can not start SubDMesh handler: no triangles defined.");
			}
			if (this.list_4.Count < 1)
			{
				return new SubDMeshHandler.MeshGenerationResult();
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			Editor arg_3C_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			SubDMeshHandler.MeshGenerationResult result;
			using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
			{
				this.BuildDataStructure(true);
				Point3dCollection point3dCollection = new Point3dCollection();
				for (int i = 0; i < this.list_0.Count; i++)
				{
					point3dCollection.Add(new Point3d(this.list_0[i].X, this.list_0[i].Y, this.list_0[i].Z));
				}
				Int32Collection int32Collection = new Int32Collection(3 * this.list_4.Count);
				for (int j = 0; j < this.list_4.Count; j++)
				{
					int32Collection.Add(3);
					int32Collection.Add(this.list_1[j]);
					int32Collection.Add(this.list_2[j]);
					int32Collection.Add(this.list_3[j]);
				}
				SubDMesh subDMesh = new SubDMesh();
				subDMesh.SetDatabaseDefaults();
				subDMesh.SetSubDMesh(point3dCollection, int32Collection, 0);
				subDMesh.SetPropertiesFrom(this.list_4[0].AcDbFace);
				BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, (OpenMode)1);
                BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], (OpenMode)1);
				blockTableRecord.AppendEntity(subDMesh);
				transaction.AddNewlyCreatedDBObject(subDMesh, true);
				transaction.Commit();
				result = new SubDMeshHandler.MeshGenerationResult
				{
					objectId_0 = subDMesh.ObjectId,
					int_0 = this.list_0.Count,
					int_1 = this.list_4.Count,
					string_0 = DBManager.GetLayerName(subDMesh.LayerId)
				};
			}
			return result;
		}

		public int Heal(double epsilon)
		{
			Editor arg_0F_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			int num = 0;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				bool flag = true;
				Edge edge = new Edge(this.list_0[this.list_2[i]], this.list_0[this.list_3[i]]);
				Edge edge2 = new Edge(this.list_0[this.list_3[i]], this.list_0[this.list_1[i]]);
				Edge edge3 = new Edge(this.list_0[this.list_1[i]], this.list_0[this.list_2[i]]);
				Edge edge4 = this.list_0[this.list_1[i]].PseudoPerdendicularOn(edge);
				Edge edge5 = this.list_0[this.list_2[i]].PseudoPerdendicularOn(edge2);
				Edge edge6 = this.list_0[this.list_3[i]].PseudoPerdendicularOn(edge3);
				if (edge4.Length < epsilon)
				{
					if (this.list_0[this.list_1[i]].DistanceTo(this.list_0[this.list_2[i]]) < epsilon)
					{
						this.list_0[this.list_1[i]] = this.list_0[this.list_2[i]];
					}
					else if (this.list_0[this.list_1[i]].DistanceTo(this.list_0[this.list_3[i]]) < epsilon)
					{
						this.list_0[this.list_1[i]] = this.list_0[this.list_3[i]];
					}
					else
					{
						this.list_0[this.list_1[i]] = edge4.EndPoint;
					}
					flag = false;
				}
				if (edge5.Length < epsilon)
				{
					if (this.list_0[this.list_2[i]].DistanceTo(this.list_0[this.list_3[i]]) < epsilon)
					{
						this.list_0[this.list_2[i]] = this.list_0[this.list_3[i]];
					}
					else if (this.list_0[this.list_2[i]].DistanceTo(this.list_0[this.list_1[i]]) < epsilon)
					{
						this.list_0[this.list_2[i]] = this.list_0[this.list_1[i]];
					}
					else
					{
						this.list_0[this.list_2[i]] = edge5.EndPoint;
					}
					flag = false;
				}
				if (edge6.Length < epsilon)
				{
					if (this.list_0[this.list_3[i]].DistanceTo(this.list_0[this.list_1[i]]) < epsilon)
					{
						this.list_0[this.list_3[i]] = this.list_0[this.list_1[i]];
					}
					else if (this.list_0[this.list_3[i]].DistanceTo(this.list_0[this.list_2[i]]) < epsilon)
					{
						this.list_0[this.list_3[i]] = this.list_0[this.list_2[i]];
					}
					else
					{
						this.list_0[this.list_3[i]] = edge6.EndPoint;
					}
					flag = false;
				}
				if (flag)
				{
					list.Add(this.list_1[i]);
					list2.Add(this.list_2[i]);
					list3.Add(this.list_3[i]);
				}
				else
				{
					num++;
				}
			}
			this.list_1 = list;
			this.list_2 = list2;
			this.list_3 = list3;
			return num;
		}

		public int HealXY(double epsilon)
		{
			Editor arg_0F_0 =Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			int num = 0;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				bool flag = true;
				Edge edge = new Edge(this.list_0[this.list_2[i]], this.list_0[this.list_3[i]]);
				Edge edge2 = edge.DeepCopy();
				edge2.StartPoint.Z = 0.0;
				edge2.EndPoint.Z = 0.0;
				Edge edge3 = new Edge(this.list_0[this.list_3[i]], this.list_0[this.list_1[i]]);
				Edge edge4 = edge3.DeepCopy();
				edge4.StartPoint.Z = 0.0;
				edge4.EndPoint.Z = 0.0;
				Edge edge5 = new Edge(this.list_0[this.list_1[i]], this.list_0[this.list_2[i]]);
				Edge edge6 = edge5.DeepCopy();
				edge6.StartPoint.Z = 0.0;
				edge6.EndPoint.Z = 0.0;
				Edge edge7 = this.list_0[this.list_1[i]].PseudoPerdendicularOn(edge2);
				Edge edge8 = this.list_0[this.list_2[i]].PseudoPerdendicularOn(edge4);
				Edge edge9 = this.list_0[this.list_3[i]].PseudoPerdendicularOn(edge6);
				if (edge7.LengthXY < epsilon)
				{
					if (this.list_0[this.list_1[i]].DistanceXY(this.list_0[this.list_2[i]]) < epsilon)
					{
						this.list_0[this.list_1[i]].X = this.list_0[this.list_2[i]].X;
						this.list_0[this.list_1[i]].Y = this.list_0[this.list_2[i]].Y;
					}
					else if (this.list_0[this.list_1[i]].DistanceXY(this.list_0[this.list_3[i]]) < epsilon)
					{
						this.list_0[this.list_1[i]].X = this.list_0[this.list_3[i]].X;
						this.list_0[this.list_1[i]].Y = this.list_0[this.list_3[i]].Y;
					}
					else
					{
						this.list_0[this.list_1[i]].X = edge7.EndPoint.X;
						this.list_0[this.list_1[i]].Y = edge7.EndPoint.Y;
					}
					flag = false;
				}
				if (edge8.LengthXY < epsilon)
				{
					if (this.list_0[this.list_2[i]].DistanceXY(this.list_0[this.list_3[i]]) < epsilon)
					{
						this.list_0[this.list_2[i]].X = this.list_0[this.list_3[i]].X;
						this.list_0[this.list_2[i]].Y = this.list_0[this.list_3[i]].Y;
					}
					else if (this.list_0[this.list_2[i]].DistanceXY(this.list_0[this.list_1[i]]) < epsilon)
					{
						this.list_0[this.list_2[i]].X = this.list_0[this.list_1[i]].X;
						this.list_0[this.list_2[i]].Y = this.list_0[this.list_1[i]].Y;
					}
					else
					{
						this.list_0[this.list_2[i]].X = edge8.EndPoint.X;
						this.list_0[this.list_2[i]].Y = edge8.EndPoint.Y;
					}
					flag = false;
				}
				if (edge9.LengthXY < epsilon)
				{
					if (this.list_0[this.list_3[i]].DistanceXY(this.list_0[this.list_1[i]]) < epsilon)
					{
						this.list_0[this.list_3[i]].X = this.list_0[this.list_1[i]].X;
						this.list_0[this.list_3[i]].Y = this.list_0[this.list_1[i]].Y;
					}
					else if (this.list_0[this.list_3[i]].DistanceXY(this.list_0[this.list_2[i]]) < epsilon)
					{
						this.list_0[this.list_3[i]].X = this.list_0[this.list_2[i]].X;
						this.list_0[this.list_3[i]].Y = this.list_0[this.list_2[i]].Y;
					}
					else
					{
						this.list_0[this.list_3[i]].X = edge9.EndPoint.X;
						this.list_0[this.list_3[i]].Y = edge9.EndPoint.Y;
					}
					flag = false;
				}
				if (flag)
				{
					list.Add(this.list_1[i]);
					list2.Add(this.list_2[i]);
					list3.Add(this.list_3[i]);
				}
				else
				{
					num++;
				}
			}
			this.list_1 = list;
			this.list_2 = list2;
			this.list_3 = list3;
			return num;
		}

		private double method_0(ngeometry.VectorGeometry.Vector3d vector3d_0, ngeometry.VectorGeometry.Vector3d vector3d_1)
		{
            double num = ngeometry.VectorGeometry.Vector3d.Angle(vector3d_0, vector3d_1);
            ngeometry.VectorGeometry.Vector3d b = ngeometry.VectorGeometry.Vector3d.Bisector(vector3d_0, vector3d_1);
            double num2 = ngeometry.VectorGeometry.Vector3d.Angle(vector3d_0, b);
            double num3 = ngeometry.VectorGeometry.Vector3d.OrientedAngle(vector3d_0, vector3d_1, ngeometry.VectorGeometry.Vector3d.Cross(vector3d_0, vector3d_1));
			if (num3 > 3.1415926535897931)
			{
				num3 = 6.2831853071795862 - num3;
			}
			if (num > num2)
			{
				if (Math.Abs(num3 - num) > 0.001)
				{
					throw new System.Exception();
				}
				return num;
			}
			else
			{
				if (Math.Abs(num3 - num2) > 0.001)
				{
					throw new System.Exception();
				}
				return num2;
			}
		}

		public List<int> FaceVertexIndex1
		{
			get
			{
				return this.list_1;
			}
		}

		public List<int> FaceVertexIndex2
		{
			get
			{
				return this.list_2;
			}
		}

		public List<int> FaceVertexIndex3
		{
			get
			{
				return this.list_3;
			}
		}

		public List<Point> Vertices
		{
			get
			{
				return this.list_0;
			}
		}

		private List<Point> list_0;

		private List<int> list_1;

		private List<int> list_2;

		private List<int> list_3;

		private readonly List<Triangle> list_4;

		//[LicenseProvider(typeof(Class46))]
		public class MeshGenerationResult
		{
			public MeshGenerationResult()
			{
				//System.ComponentModel.LicenseManager.Validate(typeof(SubDMeshHandler.MeshGenerationResult));
				this.string_0 = "none";
				this.objectId_0 = ObjectId.Null;
				////base..ctor();
			}

			public override string ToString()
			{
				return string.Concat(new object[]
				{
					"\tLayer name        : ",
					this.string_0,
					Environment.NewLine,
					"\tNumber of vertices: ",
					this.int_0,
					Environment.NewLine,
					"\tNumber of faces   : ",
					this.int_1
				});
			}

			internal int int_0;

			internal int int_1;

			internal ObjectId objectId_0;

			internal string string_0;
		}
	}
}
