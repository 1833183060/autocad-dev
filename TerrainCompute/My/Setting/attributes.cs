using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TerrainComputeC.My
{
    public class school
    {
        public string Address{set;get;}
        public string Name{set;get;}
        public string Sex{set;get;}
        public override string  ToString()
        {
            return Address+Name+Sex;
        }
    }
    public class SystemConfig
    {
        public string ConfigName { set; get; }
        private school _school = new school();
        [TypeConverter(typeof(ExpandableObjectConverter)),Category("学生")]
        public school MySchool1
        {
            set { _school = value; }
            get { return _school; }
        }
        public override string ToString()
        {
            return ConfigName + MySchool1;
        }
    }
    public class attributes
    {
        [Category("学生")]
        public string Ages { get; set; }
        
        private SystemConfig _config = new SystemConfig();
        [TypeConverter(typeof(ExpandableObjectConverter)), Category("地址")]
        public SystemConfig config
        {
            set { _config = value; }
            get { return _config; }
        }
    }
}
