using System;
using System.Reflection;

internal class Class6
{
	internal static void smethod_0(int typemdt)
	{
		Type type = Class6.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class6.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	public Class6()
	{
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Class6()
	{
	}

	internal static Module module_0 = typeof(Class6).Assembly.ManifestModule;

	internal delegate void Delegate0(object o);
}
