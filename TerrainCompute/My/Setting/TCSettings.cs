using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

using System.Reflection;
using TerrainComputeC.Colorize;
namespace TerrainComputeC.My
{
    public enum FaceColorizeType
    {
        CenterZ=0,
        MaxZ=0,
    }
    [Serializable]
    public class TCSettings
    {
        #region 私有字段
        private int resolution = 0;
        private string greetingText = "Welcome to your application!";
        private int itemsInMRU = 4;
        private int maxRepeatRate = 10;
        private bool settingsChanged = false;
        private string appVersion = "1.0";
        #endregion
        #region 属性     
        [CategoryAttribute("通用"), DefaultValueAttribute(true)]
        [DisplayName("比例")]
        [EditorAttribute(typeof(ScalePropEditor), typeof(System.Drawing.Design.UITypeEditor))]        

        public ScaleProp Scale
        {
            get;
            set;
        }
        private ScaleProp scale;
        [CategoryAttribute("等高线"), DefaultValueAttribute(true)]
        [DisplayName("等高线间隔")]
        [EditorAttribute(typeof(ResolutionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public double ContourSpace
        {
            get { return contourSpace; }
            set { contourSpace = value; }
        }
        private double contourSpace=1;
        [CategoryAttribute("三维网格"), DefaultValueAttribute(true)]
        [DisplayName("光滑度")]
        [EditorAttribute(typeof(ResolutionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }
        [CategoryAttribute("三维颜色填充"), DefaultValueAttribute(true)]
        public FaceColorizeType FCType { 
            get { return fcType; } 
            set { fcType = value; } 
        }
        private FaceColorizeType fcType =FaceColorizeType.CenterZ;

        
        [CategoryAttribute("三维颜色填充"), DefaultValueAttribute(true)]
        public Color ToolbarColor
        {
            get { return toolbarColor; }
            set { toolbarColor = value; }
        }
        private Color toolbarColor = new Color();

        [CategoryAttribute("三维颜色填充"), DefaultValueAttribute(true)]
        [BrowsableAttribute(true)]
        [EditorAttribute(typeof(ColorPropEditor), typeof(System.Drawing.Design.UITypeEditor))]
        /*[EditorAttribute(typeof(ColorButton2), typeof(ColorButton2))]*/
        public ColorProp FaceColorList2
        {
            get { return faceColorList2; }
            set { faceColorList2 = value; }
        }
        private ColorProp faceColorList2 = new ColorProp();

        [CategoryAttribute("三维颜色填充"), DefaultValueAttribute(true)]
        [DisplayName("颜色数量")]
        [EditorAttribute(typeof(ResolutionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public int ColorCount
        {
            get { return colorCount; }
            set { colorCount = value; }
        }
        private int colorCount = 18;
        
        [CategoryAttribute("三维颜色填充"), DefaultValueAttribute(true)]
        public Font ContourFont
        {
            get { return contureFont; }
            set { contureFont = value; }
        }
        private Font contureFont = new Font("Arial", 8, FontStyle.Regular);

        public string GreetingText
        {
            get { return greetingText; }
            set { greetingText = value; }
        }
        public int MaxRepeatRate
        {
            get { return maxRepeatRate; }
            set { maxRepeatRate = value; }
        }
        public int ItemsInMRUList
        {
            get { return itemsInMRU; }
            set { itemsInMRU = value; }
        }
        public bool SettingsChanged
        {
            get { return settingsChanged; }
            set { settingsChanged = value; }
        }
        public string AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }
        #endregion
        #region 静态字段、属性、方法
        public static string AssemblyDirectory()
        {            
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
            
        }
        static TCSettings loadDefault()
        {
            try
            {
                FileStream fs = new FileStream(TCSettings.AssemblyDirectory() + "/data.json", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string str = sr.ReadToEnd();
                sr.Close();
                TCSettings obj = JsonConvert.DeserializeObject<TCSettings>(str);
                TCSettings.Instance = obj;
                return obj;
            }
            catch (Exception ex)
            {

            }
            TCSettings.Instance = new TCSettings();
            return null;
        }
        public static TCSettings Instance
        {
            get {
                if (instance == null)
                {
                    loadDefault();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        private static TCSettings instance;
        #endregion
        public TCSettings()
        {
            Scale = new ScaleProp();
            FaceColorList2 = new ColorProp();
            /*FaceColorList2.colorList = new List<Color>{
                Color.FromArgb(255,0,0),
                Color.FromArgb(126,0,0),
                Color.FromArgb(0,126,0),
                Color.FromArgb(0,255,0),
                Color.FromArgb(0,0,125),
                Color.FromArgb(0,0,255)
            };*/
            FaceColorList2.colorList = ColorizeBase.genColorList(colorCount);
            ContourFont = new Font(FontFamily.GenericSerif, 11);
            
            
        }
    }
}
