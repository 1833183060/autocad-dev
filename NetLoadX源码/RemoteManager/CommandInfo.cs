using System;
using System.Collections.Generic;
using System.Text;

namespace TlsCad.RunTime
{
    [Serializable]
    public class CommandInfo
    {

        public string GlobalName;
        public string LocalizedName;
        public string GroupName;

        public string TypeName;
        public string MethodName;

        public CommandInfo() { }

        public CommandInfo(string globalName)
        {
            GlobalName = globalName;
        }

    }
}
