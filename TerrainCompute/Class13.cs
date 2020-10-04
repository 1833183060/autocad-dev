using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class13
{
	internal Class13()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class13));
		this.class13_0 = new Class13[3];
		this.list_0 = new List<Class25>();
		this.bool_0 = true;
		//base..ctor();
	}

	internal Class13(Class25 class25_3, Class25 class25_4, Class25 class25_5)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class13));
		this.class13_0 = new Class13[3];
		this.list_0 = new List<Class25>();
		this.bool_0 = true;
		//base..ctor();
		this.class25_0 = class25_3;
		this.class25_1 = class25_4;
		this.class25_2 = class25_5;
	}

	internal Class13(Class25 class25_3, Class25 class25_4, Class25 class25_5, Class13 class13_1, Class13 class13_2, Class13 class13_3)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class13));
		this.class13_0 = new Class13[3];
		this.list_0 = new List<Class25>();
		this.bool_0 = true;
		//base..ctor();
		this.class25_0 = class25_3;
		this.class25_1 = class25_4;
		this.class25_2 = class25_5;
		this.class13_0[0] = class13_1;
		this.class13_0[1] = class13_2;
		this.class13_0[2] = class13_3;
	}

	public override bool Equals(object obj)
	{
		return this == (Class13)obj;
	}

	public override int GetHashCode()
	{
		int hashCode = this.class25_0.GetHashCode();
		int hashCode2 = this.class25_1.GetHashCode();
		int hashCode3 = this.class25_2.GetHashCode();
		return hashCode ^ hashCode2 ^ hashCode3;
	}

	internal bool method_0()
	{
		return this.bool_0;
	}

	internal void method_1(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	internal List<Class25> method_10()
	{
		return this.list_0;
	}

	internal void method_11(List<Class25> value)
	{
		this.list_0 = value;
	}

	internal Class23 method_12()
	{
		Class23 @class = new Class23();
		@class.method_1(this.class25_1);
		@class.method_3(this.class25_2);
		@class.method_4()[0] = this;
		@class.method_4()[1] = this.class13_0[0];
		return @class;
	}

	internal Class23 method_13()
	{
		Class23 @class = new Class23();
		@class.method_1(this.class25_2);
		@class.method_3(this.class25_0);
		@class.method_4()[0] = this;
		@class.method_4()[1] = this.class13_0[1];
		return @class;
	}

	internal Class23 method_14()
	{
		Class23 @class = new Class23();
		@class.method_1(this.class25_0);
		@class.method_3(this.class25_1);
		@class.method_4()[0] = this;
		@class.method_4()[1] = this.class13_0[2];
		return @class;
	}

	internal bool method_15(Class25 class25_3)
	{
		return Predicate.Orient3d_exact(this.class25_0.method_0(), this.class25_1.method_0(), this.class25_2.method_0(), class25_3.method_0()) < 0.0;
	}

	internal Triangle method_16()
	{
		return new Triangle(this.class25_0.method_0(), this.class25_1.method_0(), this.class25_2.method_0());
	}

	internal Class25 method_2()
	{
		return this.class25_0;
	}

	internal void method_3(Class25 class25_3)
	{
		this.class25_0 = class25_3;
	}

	internal Class25 method_4()
	{
		return this.class25_1;
	}

	internal void method_5(Class25 class25_3)
	{
		this.class25_1 = class25_3;
	}

	internal Class25 method_6()
	{
		return this.class25_2;
	}

	internal void method_7(Class25 class25_3)
	{
		this.class25_2 = class25_3;
	}

	internal Class13[] method_8()
	{
		return this.class13_0;
	}

	internal void method_9(Class13[] class13_1)
	{
		this.class13_0 = class13_1;
	}

	public static bool operator ==(Class13 class13_1, Class13 class13_2)
	{
        return (object)class13_1 == (object)class13_2 || ((object)class13_1 != null && (object)class13_2 != null && !(class13_1.class25_0 != class13_2.class25_0) && !(class13_1.class25_1 != class13_2.class25_1) && !(class13_1.class25_2 != class13_2.class25_2));
	}

	public static bool operator !=(Class13 class13_1, Class13 class13_2)
	{
		return !(class13_1 == class13_2);
	}

	private bool bool_0;

	private Class13[] class13_0;

	private Class25 class25_0;

	private Class25 class25_1;

	private Class25 class25_2;

	private List<Class25> list_0;
}
