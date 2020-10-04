using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD;
using TerrainComputeC;
using Autodesk.AutoCAD.Geometry;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace TerrainComputeC.My
{
    [Serializable]
    public class MyDB //: ISerializable
    {
        const int MAXRESL = 11;
        public List<Point> InnerBoPL { get; set; }//内边界的点列表
        public List<PointSet> PSList { get; set; }
        public List<PPDictionary>PPDicList{get;set;}
        //public List<List<MyTriangle>> TrianglesList; 
        public ObjectId[] LineIds {
            get
            {
                return lineIds;
            }
            set
            {
                lineIds = value;
            }
        }
        [NonSerialized]
        private ObjectId[] lineIds;
        public int Resolution { get; set; }
        static MyDB()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        public MyDB()
        {
            init();
            //SortedDictionary<int,int> a=new SortedDictionary<int,int>()
        }
        public void init()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            db.BeginSave += db_BeginSave;
            
            if (PPDicList == null)
            {
                PPDicList = new List<PPDictionary>();
            }
            if (PSList == null)
            {
                PSList = new List<PointSet>();
                Resolution = -1;
            }
            if (Resolution > PSList.Count - 1)
            {
                Resolution = PSList.Count - 1;
            }
            lineIds = null;
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return typeof(MyDB).Assembly;
        }

        public string getFaceLayerName()
        {
            return "face_" + Resolution;
        }
        public void addPS(PointSet ps)
        {
            PSList.Add(ps);
            Resolution = PSList.Count-1;
        }
        public void setTris(List<Triangle> tris)
        {
            List<MyTriangle> myTri = new List<MyTriangle>();
            for (int i = 0; i < tris.Count; i++)
            {
                myTri.Add(new MyTriangle(tris[i]));
            }
            //this.TrianglesList[this.Resolution ] = myTri;
            PPDictionary ppd = new PPDictionary();
            ppd.Add(myTri);
            ppd.Distinct();
            ppd.genIndex();
            if (PPDicList.Count - 1 < this.Resolution)
            {
                PPDicList.Add(ppd);
            }
            else
            {
                this.PPDicList[this.Resolution] = ppd;
            }
            

        }
        public void decreaseResolution()
        {
            if (Resolution < 0) Resolution = 0;
            LayerUtil.setLayerProp(getFaceLayerName(), true);
            Resolution--;
            LayerUtil.setLayerProp(getFaceLayerName(), false);
        }
        public void increaseResolution()
        {
            if (Resolution >= MAXRESL) Resolution = MAXRESL;
            if (Resolution < PSList.Count-1)
            {
                Resolution++;
            }
            else
            {
                if (PPDicList.Count-1 < Resolution) return;
                PointSet ps=Interpolation2.interpolation_partial(PPDicList[Resolution]);
                if (ps != null)
                {
                    ps.Add(PPDicList[Resolution].Keys.ToList());
                    PSList.Add(ps);
                    Resolution++;
                }
            }
        }
        public PointSet getAllPoint(){
            PointSet ps=new PointSet();
            /*for (int i = 0; i < PSList.Count; i++)
            {
                ps.Add(PSList[i]);
            }*/

            return PSList[Resolution];
        }
        public ObjectId[] getAllLine()
        {
            return LineIds;
        }
        void db_BeginSave(object sender, DatabaseIOEventArgs e)
        {
            MyDB.save(this);
        }
         ~MyDB()
        {
            MyDB.save(this);
        }
        public static void save(MyDB mydb)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            try
            {                
                using (Transaction trans =
                                  db.TransactionManager.StartTransaction())
                {

                    // Find the NOD in the database

                    DBDictionary nod = (DBDictionary)trans.GetObject(
                                db.NamedObjectsDictionaryId, OpenMode.ForWrite);

                    BinaryFormatter bf = new BinaryFormatter();
                    MemoryStream ms=new MemoryStream();
                    bf.Serialize(ms, mydb);
                    ResultBuffer rf=new ResultBuffer();
                    byte[] buf=ms.GetBuffer();
                    int position = 0;
                    int remaining = buf.Length;
                    while(remaining>0){
                        if(remaining>=255){
                            byte[] chunk=new byte[255];
                            Buffer.BlockCopy(buf,position,chunk,0,255);
                            rf.Add(new TypedValue((int)DxfCode.BinaryChunk,chunk ));
                            remaining-=255;
                            position+=255;
                        }else{
                            byte[] chunk=new byte[remaining];
                            Buffer.BlockCopy(buf,position,chunk,0,remaining);
                            rf.Add(new TypedValue((int)DxfCode.BinaryChunk,chunk ));
                            remaining=0;
                        }
                    }                    
                    
                    Xrecord myXrecord = new Xrecord();

                    myXrecord.Data = rf;
                    
                    nod.SetAt("TerrainComputeC", myXrecord);

                    trans.AddNewlyCreatedDBObject(myXrecord, true);

                    trans.Commit();

                } // using

            }

            catch (System.Exception e)
            {
                ed.WriteMessage(e.ToString());
            }
        }

        public static MyDB load()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            try
            {
                using (Transaction trans =db.TransactionManager.StartTransaction())
                {
                    // Find the NOD in the database
                    DBDictionary nod = (DBDictionary)trans.GetObject(

                                db.NamedObjectsDictionaryId, OpenMode.ForWrite);

                    BinaryFormatter bf = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream();

                    Xrecord myXrecord = new Xrecord(); 
                    
                    ObjectId myDataId = nod.GetAt("TerrainComputeC");

                    Xrecord readBack = (Xrecord)trans.GetObject(

                                                  myDataId, OpenMode.ForRead);
BinaryWriter bw=new BinaryWriter(ms);
                    foreach (TypedValue value in readBack.Data)
                    {
                        if (value.TypeCode == (int)DxfCode.BinaryChunk)
                        {
                            
                            bw.Write((byte[])value.Value);
                        }
                        
                    }
                    bw.Flush();
                    trans.Commit();
                    ms.Position = 0;
                    MyDB mydb = bf.Deserialize(ms) as MyDB;
                    if (mydb != null)
                    {
                        mydb.init();
                    }
                    return mydb;
                    

                } // using

            }

            catch (System.Exception e)
            {

                System.Diagnostics.Debug.Print(e.ToString());

            }
            return null;
        }
        /*[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PSList", PSList);
            info.AddValue("Resolution", Resolution);

        }*/
    }
}
