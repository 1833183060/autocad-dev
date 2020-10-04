using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Resources;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;


using System.Windows.Forms;

namespace TlsCad.RunTime
{
    public class DynamicAssembly
    {

        public static int CurrTempIndex
        { private set; get; }

        string _filename;
        public List<CommandInfo> _cmds;

        public DynamicAssembly(string filename, List<CommandInfo> cmds)
        {
            _filename = filename;
            _cmds = cmds;
        }


        public Assembly CompiledAssembly()
        {

            string thedll = Assembly.GetExecutingAssembly().Location;

            CompilerParameters pars = new CompilerParameters();
            pars.CompilerOptions = "/target:library /optimize";
            pars.GenerateExecutable = false;
            pars.GenerateInMemory = true;

            var asslst = pars.ReferencedAssemblies;
            asslst.Add("System.dll");
            asslst.Add(RemoteLoader.AcPath + "acmgd.dll");

            StringBuilder code = new StringBuilder();
            code.Append("using System;");
            code.Append("using System.Reflection;");
            code.Append("using Autodesk.AutoCAD.Runtime;");
            code.Append("using TlsCad.RunTime;");
            code.Append("namespace TlsCad.RunTime.Temp" + CurrTempIndex + "{");
            code.Append("public class Commands{");
            code.Append("private static object _loader;");
            code.Append("string _path = \"" + _filename + "\";");
            code.Append("public void SetLoader(object loader){_loader = loader;}");
            code.Append("private void Invoke(string assemblyPath, string cmdname){");
            code.Append("_loader.GetType().InvokeMember(");
            code.Append("\"Invoke\",BindingFlags.InvokeMethod,null,_loader,new object[]{assemblyPath,cmdname});}");

            int i = 0;
            foreach (var cmd in _cmds)
                code.Append(GetCommandBody(cmd, i++));
            code.Append("}}");
            CodeDomProvider comp = new CSharpCodeProvider();
            CompilerResults cr = comp.CompileAssemblyFromSource(pars, code.ToString());

            if (cr.Errors.HasErrors)
                return null;
            return cr.CompiledAssembly;

        }

        private string GetCommandBody(CommandInfo cmd, int id)
        {
            StringBuilder code = new StringBuilder();
            code.Append("[CommandMethod(\"" + cmd.GlobalName + "\")]");
            code.Append("public void Func_" + id + "(){");
            code.Append("Invoke( _path,");
            code.Append("\"" + cmd.GlobalName + "\");}");
            return code.ToString();
        }


    }
}
