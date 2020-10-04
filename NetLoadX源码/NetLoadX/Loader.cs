using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

using Autodesk.AutoCAD.ApplicationServices;

namespace TlsCad.RunTime
{
    public class Loader
    {

        static Dictionary<string, List<CommandInfo>> _assemblys =
            new Dictionary<string, List<CommandInfo>>();
        static AppDomain _domain;
        static RemoteLoader _rloader;
        static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        private static void CreateAppDomain(string name)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationName = name;
            setup.ApplicationBase = RemoteLoader.AcPath;

            _domain = AppDomain.CreateDomain(name, null, setup);
            var bytes = File.ReadAllBytes(RemoteLoader.AcPath + "RemoteManager.dll");
            //var bytes = File.ReadAllBytes(AssemblyDirectory + "\\RemoteManager.dll");

            _domain.Load(bytes);
            _rloader =
                (RemoteLoader)_domain.CreateInstanceAndUnwrap(
                    "RemoteManager",
                    "TlsCad.RunTime.RemoteLoader");

        }

        public void Add(string assemblyPath)
        {

            CreateAppDomain("DynamicAssembly");
            var cmds = _rloader.GetCommands(assemblyPath);
            AppDomain.Unload(_domain);

            DynamicAssembly dass = new DynamicAssembly(assemblyPath, cmds);
            Assembly ass = dass.CompiledAssembly();
            Type type = ass.GetType("TlsCad.RunTime.Temp" + DynamicAssembly.CurrTempIndex + ".Commands");
            object obj = Activator.CreateInstance(type);
            var mi = type.GetMethod("SetLoader");
            mi.Invoke(obj, new object[] { this });

            if (_assemblys.ContainsKey(assemblyPath))
                _assemblys[assemblyPath] = cmds;
            else
                _assemblys.Add(assemblyPath, cmds);

            var doc = Application.DocumentManager.MdiActiveDocument;
            var ed = doc.Editor;

            ed.WriteMessage("程序集加载成功！\n位置：" + assemblyPath);
            ed.WriteMessage("\n命令集如下:");
            foreach (var cmd in cmds)
                ed.WriteMessage("\n" + cmd.GlobalName);

        }

        public void Invoke(string assemblyPath, string cmdname)
        {
            var cmds = _assemblys[assemblyPath];
            CommandInfo ci = null;
            foreach (var cmd in cmds)
            {
                if (cmd.GlobalName == cmdname)
                {
                    ci = cmd;
                    break;
                }
            }

            CreateAppDomain("InvokeAssembly");
            _rloader.Invoke(assemblyPath, ci);
            AppDomain.Unload(_domain);

        }

    }
}
