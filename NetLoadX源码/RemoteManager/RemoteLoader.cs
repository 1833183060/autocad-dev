using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Autodesk.AutoCAD.DatabaseServices;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Resources;
using Autodesk.AutoCAD.Runtime;

namespace TlsCad.RunTime
{

    public class RemoteLoader  : MarshalByRefObject
    {

        public static string AcPath
        {
            get
            {
#if NET20
                var key =
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                        HostApplicationServices.Current.RegistryProductRootKey);
                return key.GetValue("Location").ToString() + "\\";
#elif NET45
                var key =
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                        HostApplicationServices.Current.UserRegistryProductRootKey);
                return key.GetValue("Location").ToString() + "\\";
#endif
            }
        }

        public List<CommandInfo> GetCommands(string filename)
        {

            var cmds = new List<CommandInfo>();
            var ass = Assembly.LoadFrom(filename);

            try
            {
                foreach (Module m in ass.GetModules(true))
                {
                    Type[] types = ass.GetTypes();
                    foreach (Type t in types)
                    {

                        ResourceManager rm =
                            new ResourceManager(t.FullName, ass);
                        rm.IgnoreCase = true;

                        MethodInfo[] methods = t.GetMethods();
                        foreach (MethodInfo mi in methods)
                        {
                            object[] attbs =
                                mi.GetCustomAttributes(
                                    typeof(CommandMethodAttribute),
                                    true
                                );
                            foreach (object attb in attbs)
                            {

                                CommandMethodAttribute cma = attb as CommandMethodAttribute;
                                if (cma != null)
                                {

                                    CommandInfo cmd =
                                        new CommandInfo(cma.GlobalName);
                                    cmd.TypeName = t.FullName;
                                    cmd.MethodName = mi.Name;
                                    cmd.LocalizedName = cmd.GlobalName;

                                    if (cma.GroupName != null)
                                        cmd.GroupName = cma.GroupName;

                                    string lnid = cma.LocalizedNameId;
                                    if (lnid != null)
                                    {
                                        try
                                        {
                                            cmd.LocalizedName = rm.GetString(lnid);
                                        }
                                        catch { }
                                    }

                                    cmds.Add(cmd);

                                }


                            }
                        }
                    }
                }

                return cmds;

            }
            catch { }

            return null;

        }

        public void Invoke(string assemblyPath, CommandInfo cmd)
        {

            Assembly ass = Assembly.LoadFrom(assemblyPath);
            Type type = ass.GetType(cmd.TypeName);
            MethodInfo mi = type.GetMethod(cmd.MethodName);
            object obj = Activator.CreateInstance(type);
            mi.Invoke(obj, null);

        }

    }

}
