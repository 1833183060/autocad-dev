using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;

internal class Class50
{
	static Class50()
	{
		Class50.bool_0 = false;
		Class50.bool_1 = false;
		Class50.bool_2 = false;
		Class50.bool_3 = false;
		Class50.bool_4 = false;
		Class50.bool_5 = false;
		Class50.int_0 = 0;
		Class50.int_1 = 0;
		Class50.string_0 = "####-####-####-####-####";
		Class50.string_1 = "####-####-####-####-####";
		Class50.int_2 = 1;
		Class50.int_3 = 0;
		Class50.int_4 = 1;
		Class50.enum11_0 = (Enum11)0;
		Class50.dateTime_0 = DateTime.Now;
		Class50.sortedList_0 = new SortedList();
		Class50.byte_0 = new byte[0];
	}

	private Class50()
	{
	}

	internal static void smethod_0()
	{
		Class50.bool_0 = false;
		Class50.bool_1 = false;
		Class50.bool_2 = false;
		Class50.bool_3 = false;
		Class50.bool_4 = false;
		Class50.bool_5 = false;
		Class50.int_0 = 0;
		Class50.int_1 = 0;
		Class50.string_1 = "####-####-####-####-####";
		Class50.int_2 = 1;
		Class50.int_3 = 0;
		Class50.int_4 = 1;
		Class50.enum11_0 = (Enum11)0;
		DateTime arg_57_0 = DateTime.Now;
		Class50.sortedList_0 = new SortedList();
		Class50.byte_0 = new byte[0];
	}

	public static string smethod_1()
	{
		return Class46.smethod_3();
	}

	public static string smethod_10()
	{
		return Class50.string_1;
	}

	public static void smethod_11(string string_2)
	{
		Class50.string_1 = string_2;
	}

	public static bool smethod_12()
	{
		return Class50.bool_1;
	}

	public static void smethod_13(bool bool_6)
	{
		Class50.bool_1 = bool_6;
	}

	public static bool smethod_14()
	{
		return Class50.bool_2;
	}

	public static void smethod_15(bool bool_6)
	{
		Class50.bool_2 = bool_6;
	}

	public static bool smethod_16()
	{
		return Class50.bool_3;
	}

	public static void smethod_17(bool bool_6)
	{
		Class50.bool_3 = bool_6;
	}

	public static bool smethod_18()
	{
		return Class50.bool_4;
	}

	public static void smethod_19(bool bool_6)
	{
		Class50.bool_4 = bool_6;
	}

	public static bool smethod_2(string string_2, string string_3)
	{
		return Class46.smethod_0(string_2, string_3);
	}

	public static bool smethod_20()
	{
		return Class50.bool_5;
	}

	public static void smethod_21(bool bool_6)
	{
		Class50.bool_5 = bool_6;
	}

	public static int smethod_22()
	{
		return Class50.int_0;
	}

	public static void smethod_23(int int_5)
	{
		Class50.int_0 = int_5;
	}

	public static int smethod_24()
	{
		return Class50.int_1;
	}

	public static void smethod_25(int int_5)
	{
		Class50.int_1 = int_5;
	}

	public static int smethod_26()
	{
		return Class50.int_4;
	}

	public static void smethod_27(int int_5)
	{
		Class50.int_4 = int_5;
	}

	public static int smethod_28()
	{
		return Class50.int_2;
	}

	public static void smethod_29(int int_5)
	{
		Class50.int_2 = int_5;
	}

	public static void smethod_3(byte[] byte_1)
	{
		new Class46().method_4(byte_1);
	}

	public static int smethod_30()
	{
		return Class50.int_3;
	}

	public static void smethod_31(int int_5)
	{
		Class50.int_3 = int_5;
	}

	public static Enum11 smethod_32()
	{
		return Class50.enum11_0;
	}

	public static void smethod_33(Enum11 enum11_1)
	{
		Class50.enum11_0 = enum11_1;
	}

	public static byte[] smethod_34()
	{
		return Class50.byte_0;
	}

	public static void smethod_35(byte[] byte_1)
	{
		Class50.byte_0 = byte_1;
	}

	public static DateTime smethod_36()
	{
		return Class50.dateTime_0;
	}

	public static void smethod_37(DateTime dateTime_1)
	{
		Class50.dateTime_0 = dateTime_1;
	}

	public static SortedList smethod_38()
	{
		return Class50.sortedList_0;
	}

	public static void smethod_39(SortedList sortedList_1)
	{
		Class50.sortedList_0 = sortedList_1;
	}

	public static bool smethod_4(string string_2)
	{
		return Class46.smethod_1(string_2);
	}

	public static string smethod_40(bool bool_6, bool bool_7, bool bool_8, bool bool_9)
	{
		return Class26.smethod_9(bool_7, bool_9, bool_6, bool_8);
	}

	public static void smethod_5(string string_2)
	{
		FileStream fileStream = new FileStream(string_2, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		Class50.smethod_3(array);
	}

	public static bool smethod_6()
	{
		return Class50.bool_0;
	}

	public static void smethod_7(bool bool_6)
	{
		Class50.bool_0 = bool_6;
	}

	public static string smethod_8()
	{
		return Class50.string_0;
	}

	public static void smethod_9(string string_2)
	{
		Class50.string_0 = string_2;
	}

	public static event Class50.Delegate0 Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			Class50.delegate0_0 = (Class50.Delegate0)Delegate.Combine(Class50.delegate0_0, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			Class50.delegate0_0 = (Class50.Delegate0)Delegate.Remove(Class50.delegate0_0, value);
		}
	}

	public static event Class50.Delegate1 Event_1
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			Class50.delegate1_0 = (Class50.Delegate1)Delegate.Combine(Class50.delegate1_0, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			Class50.delegate1_0 = (Class50.Delegate1)Delegate.Remove(Class50.delegate1_0, value);
		}
	}

	public static event Class50.Delegate2 Event_2
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			Class50.delegate2_0 = (Class50.Delegate2)Delegate.Combine(Class50.delegate2_0, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			Class50.delegate2_0 = (Class50.Delegate2)Delegate.Remove(Class50.delegate2_0, value);
		}
	}

	public static event Class50.Delegate3 Event_3
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			Class50.delegate3_0 = (Class50.Delegate3)Delegate.Combine(Class50.delegate3_0, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			Class50.delegate3_0 = (Class50.Delegate3)Delegate.Remove(Class50.delegate3_0, value);
		}
	}

	private static bool bool_0;

	private static bool bool_1;

	private static bool bool_2;

	private static bool bool_3;

	private static bool bool_4;

	private static bool bool_5;

	private static byte[] byte_0;

	private static DateTime dateTime_0;

	private static Class50.Delegate0 delegate0_0;

	private static Class50.Delegate1 delegate1_0;

	private static Class50.Delegate2 delegate2_0;

	private static Class50.Delegate3 delegate3_0;

	private static Enum11 enum11_0;

	private static int int_0;

	private static int int_1;

	private static int int_2;

	private static int int_3;

	private static int int_4;

	private static SortedList sortedList_0;

	private static string string_0;

	private static string string_1;

	public delegate string Delegate0();

	public delegate bool Delegate1(string string_0, string string_1);

	public delegate void Delegate2(byte[] byte_0);

	public delegate bool Delegate3(string string_0);
}
