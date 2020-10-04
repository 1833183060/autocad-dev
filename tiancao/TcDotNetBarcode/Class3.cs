using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.MyServices.Internal;

[StandardModule]
[GeneratedCode("MyTemplate", "8.0.0.0")]
[HideModuleName]
internal sealed class Class3
{
	// Note: this type is marked as 'beforefieldinit'.
	[DebuggerNonUserCode]
	static Class3()
	{
	}

	[HelpKeyword("My.Computer")]
	internal static Class2 Class2_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_0.method_0();
		}
	}

	[HelpKeyword("My.Application")]
	internal static Class1 Class1_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_1.method_0();
		}
	}

	[HelpKeyword("My.User")]
	internal static User User_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_2.method_0();
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static Class3.Class4 Class4_0
	{
		[DebuggerHidden]
		get
		{
			return Class3.class5_3.method_0();
		}
	}

	private static readonly Class3.Class5<Class2> class5_0 = new Class3.Class5<Class2>();

	private static readonly Class3.Class5<Class1> class5_1 = new Class3.Class5<Class1>();

	private static readonly Class3.Class5<User> class5_2 = new Class3.Class5<User>();

	private static readonly Class3.Class5<Class3.Class4> class5_3 = new Class3.Class5<Class3.Class4>();

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class Class4
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type method_0()
		{
			return typeof(Class3.Class4);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T smethod_0<T>(T instance) where T : new()
		{
			if (instance == null)
			{
				return Activator.CreateInstance<T>();
			}
			return instance;
		}

		[DebuggerHidden]
		private void method_1<T>(ref T gparam_0)
		{
			gparam_0 = default(T);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public Class4()
		{
		}
	}

	[ComVisible(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class Class5<T> where T : new()
	{
		[DebuggerHidden]
		internal T method_0()
		{
			T t = this.contextValue_0.Value;
			if (t == null)
			{
				t = Activator.CreateInstance<T>();
				this.contextValue_0.Value = t;
			}
			return t;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public Class5()
		{
			this.contextValue_0 = new ContextValue<T>();
		}

		private readonly ContextValue<T> contextValue_0;
	}
}
