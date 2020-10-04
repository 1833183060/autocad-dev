using System;
using System.ComponentModel;

//[LicenseProvider(typeof(Class46))]
internal class Class23
{
	internal Class23()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class23));
		this.class13_0 = new Class13[2];
		//base..ctor();
	}

	internal Class23(Class25 class25_2, Class25 class25_3)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class23));
		this.class13_0 = new Class13[2];
		//base..ctor();
		this.class25_0 = class25_2;
		this.class25_1 = class25_3;
	}

	public override bool Equals(object obj)
	{
		return this == (Class23)obj;
	}

	public override int GetHashCode()
	{
		int hashCode = this.class25_0.GetHashCode();
		int hashCode2 = this.class25_1.GetHashCode();
		return hashCode ^ hashCode2;
	}

	internal Class25 method_0()
	{
		return this.class25_0;
	}

	internal void method_1(Class25 class25_2)
	{
		this.class25_0 = class25_2;
	}

	internal Class25 method_2()
	{
		return this.class25_1;
	}

	internal void method_3(Class25 class25_2)
	{
		this.class25_1 = class25_2;
	}

	internal Class13[] method_4()
	{
		return this.class13_0;
	}

	internal void method_5(Class13[] class13_1)
	{
		this.class13_0 = class13_1;
	}

	public static bool operator ==(Class23 class23_0, Class23 class23_1)
	{
        return (object)class23_0 == (object)class23_1 || ((object)class23_0 != null && (object)class23_1 != null && ((class23_0.class25_0 == class23_1.class25_0 & class23_0.class25_1 == class23_1.class25_1) || (class23_0.class25_0 == class23_1.class25_1 & class23_0.class25_1 == class23_1.class25_0)));
	}

	public static bool operator !=(Class23 class23_0, Class23 class23_1)
	{
		return !(class23_0 == class23_1);
	}

	private Class13[] class13_0;

	private Class25 class25_0;

	private Class25 class25_1;
}
