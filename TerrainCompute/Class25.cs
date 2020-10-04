using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

//[LicenseProvider(typeof(Class46))]
internal class Class25
{
	public Class25()
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class25));
		this.list_0 = new List<Class13>();
		//base..ctor();
	}

	internal Class25(Point point_1)
	{
        //System.ComponentModel.LicenseManager.Validate(typeof(Class25));
		this.list_0 = new List<Class13>();
		//base..ctor();
		this.point_0 = point_1;
	}

	public override bool Equals(object obj)
	{
		return this == (Class25)obj;
	}

	public override int GetHashCode()
	{
		return this.point_0.GetHashCode();
	}

	internal Point method_0()
	{
		return this.point_0;
	}

	internal void method_1(Point point_1)
	{
		this.point_0 = point_1;
	}

	internal List<Class13> method_2()
	{
		return this.list_0;
	}

	internal void method_3(List<Class13> value)
	{
		this.list_0 = value;
	}

	internal bool method_4()
	{
		return this.bool_0;
	}

	internal void method_5(bool bool_1)
	{
		this.bool_0 = bool_1;
	}

	public static bool operator ==(Class25 class25_0, Class25 class25_1)
	{
        return (object)class25_0 == (object)class25_1 || ((object)class25_0 != null && (object)class25_1 != null && class25_0.point_0.X == class25_1.point_0.X && class25_0.point_0.Y == class25_1.point_0.Y && class25_0.point_0.Z == class25_1.point_0.Z);
	}

	public static bool operator !=(Class25 class25_0, Class25 class25_1)
	{
		return !(class25_0 == class25_1);
	}

	private bool bool_0;

	private List<Class13> list_0;

	private Point point_0;
}
