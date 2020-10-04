using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
using ngeometry.VectorGeometry;
namespace TerrainComputeC.My
{
    //存储点和以这个点为端点的直线
    [Serializable]
    public class TEDictionary 
    {
        public List<Triangle> TriangleList;
        public Dictionary<Edge, List<int>> EdgeDic;
        public double maxCZ { get; set; }
        public double minCZ { get; set; }
        public double maxMaxZ { get; set; }
        public double minMaxZ { get; set; }
        public double maxMinZ { get; set; }
        public double minMinZ { get; set; }
        public TEDictionary()
        {
            TriangleList = new List<Triangle>();
            EdgeDic = new Dictionary<Edge, List<int>>();
        }
        public void genIndex()
        {
            //index = this.ToList();
            //this.Sort();
        }
        public void Sort()
        {
            //keys = keys.Distinct(new My.IndexClassComparer()).ToList();
            //index.Sort(new KVComparer());
        }
        public void setMaxMin(Triangle t)
        {
            if (this.TriangleList.Count <= 0)
            {
                maxCZ =minCZ= t.Center.Z;
                maxMaxZ = minMaxZ = Math.Max(Math.Max(t.Vertex1.Z, t.Vertex2.Z), t.Vertex3.Z);
                maxMinZ = minMinZ = Math.Min(Math.Min(t.Vertex1.Z, t.Vertex2.Z), t.Vertex3.Z);
            }
            else
            {
                if (t.Center.Z > maxCZ)
                {
                    maxCZ = t.Center.Z;
                }
                else if (t.Center.Z < minCZ)
                {
                    minCZ = t.Center.Z;
                }
                double maxZ = Math.Max(Math.Max(t.Vertex1.Z, t.Vertex2.Z), t.Vertex3.Z);
                if (maxZ > maxMaxZ)
                {
                    maxMaxZ = maxZ;
                }
                else if (maxZ < minMaxZ)
                {
                    minMaxZ = maxZ;
                }
                double minZ = Math.Min(Math.Min(t.Vertex1.Z, t.Vertex2.Z), t.Vertex3.Z);
                if (minZ > maxMinZ)
                {
                    maxMinZ = minZ;
                }
                else if (minZ < minMinZ)
                {
                    minMinZ = minZ;
                }
            }
        }
        public void Add(List<Triangle> tl)
        {
            for (int i = 0; i < tl.Count; i++)
            {
                Add2(tl[i]);
            }
        }
        public void Add(Edge e, Triangle t)
        {            
            //List<int> indexList = null;
            if (this.EdgeDic.ContainsKey(e))
            {
            }
            else
            {
                this.EdgeDic.Add(e, new List<int>());
            }

            int index = this.TriangleList.FindIndex((item) =>
            {
                return item == t;
            });
            if (index < 0)
            {
                this.TriangleList.Add(t);
                index = this.TriangleList.Count - 1;                
            }
            else
            {
                //this.EdgeDic[e].Add(index);
            }

            if (this.EdgeDic[e].FindIndex(item => { return item == index; }) < 0)
            {
                this.EdgeDic[e].Add(index);
            }
            else
            {
                
            }  
        }

        public void Add2(Triangle t)
        {
            this.TriangleList.Add(t);
            int index = this.TriangleList.Count-1;
            for (int i = 0; i < 3; i++)
            {
                AddEdge(t.Edges[i], index);
            }
            setMaxMin(t);
        }
        public void AddEdge(Edge e,int index)
        {
            if (this.EdgeDic.ContainsKey(e))
            {
            }
            else
            {
                this.EdgeDic.Add(e, new List<int>());
            }
            List<int> indexs = this.EdgeDic[e];
            if (indexs.FindIndex(item => { return item == index; }) < 0)
            {
                indexs.Add(index);
            }
            else
            {

            }  
        }
        public void Add(Triangle t)
        {
            setMaxMin(t);
            this.Add(t.Edge1 ,t);
            this.Add(t.Edge2,t);
            this.Add(t.Edge3, t);
        }
    }

   
}
