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
[GeneratedCode("MyTemplate", "10.0.0.0")]
[HideModuleName]
internal sealed class Class33
{
	[DebuggerNonUserCode]
	static Class33()
	{
		Class39.k1QjQlczC5Jf5();
		Class33.class35_0 = new Class33.Class35<Class32>();
		Class33.class35_1 = new Class33.Class35<Class31>();
		Class33.class35_2 = new Class33.Class35<User>();
		Class33.class35_3 = new Class33.Class35<Class33.Class34>();
	}

	[HelpKeyword("My.Computer")]
	internal static Class32 Class32_0
	{
		[DebuggerHidden]
		get
		{
			return Class33.class35_0.method_0();
		}
	}

	[HelpKeyword("My.Application")]
	internal static Class31 Class31_0
	{
		[DebuggerHidden]
		get
		{
			return Class33.class35_1.method_0();
		}
	}

	[HelpKeyword("My.User")]
	internal static User User_0
	{
		[DebuggerHidden]
		get
		{
			return Class33.class35_2.method_0();
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static Class33.Class34 Class34_0
	{
		[DebuggerHidden]
		get
		{
			return Class33.class35_3.method_0();
		}
	}

	private static readonly Class33.Class35<Class32> class35_0;

	private static readonly Class33.Class35<Class31> class35_1;

	private static readonly Class33.Class35<User> class35_2;

	private static readonly Class33.Class35<Class33.Class34> class35_3;

	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class Class34
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
			return typeof(Class33.Class34);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T smethod_0<T>(object instance) where T : new()
		{
			T result;
			if (instance == null)
			{
				result = Activator.CreateInstance<T>();
			}
			else
			{
				result = instance;
			}
			return result;
		}

		[DebuggerHidden]
		private void method_1<T>(ref T gparam_0)
		{
			gparam_0 = default(T);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Class34()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}
	}

	[ComVisible(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class Class35<T> where T : new()
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
		public Class35()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.contextValue_0 = new ContextValue<T>();
		}

		private readonly ContextValue<T> contextValue_0;
	}
}
