using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.ComputationalGeometry;
using ngeometry.VectorGeometry;

internal class Class16 : IComparable<Class16>
{
	internal Class16(Point point_1, aabbcc jDkRxoitjlBypwUoEv_1)
	{        
		this.bool_0 = true;
		this.point_0 = point_1;
		this.jDkRxoitjlBypwUoEv_0 = jDkRxoitjlBypwUoEv_1;
	}

	public int CompareTo(Class16 vc)
	{
		if (this.point_0.X != vc.point_0.X)
		{
			return this.point_0.X.CompareTo(vc.point_0.X);
		}
		if (this.point_0.Y != vc.point_0.Y)
		{
			return this.point_0.Y.CompareTo(vc.point_0.Y);
		}
		if (Convert.ToInt32(this.jDkRxoitjlBypwUoEv_0) != Convert.ToInt32(vc.jDkRxoitjlBypwUoEv_0))
		{
			return Convert.ToInt32(this.jDkRxoitjlBypwUoEv_0).CompareTo(Convert.ToInt32(vc.jDkRxoitjlBypwUoEv_0));
		}
		return this.point_0.Z.CompareTo(vc.point_0.Z);
	}

	internal static PointSet getCleanedPoints(List<Class16> cdtPoints, ref List<Point> list_0)
	{//ng:去掉距离太近的点，将这些太近的点加入到badpoints
		PointSet pointSet = new PointSet();
		cdtPoints.Sort();
		double x = cdtPoints[cdtPoints.Count - 1].point_0.X;
		double y = cdtPoints[cdtPoints.Count - 1].point_0.Y;
		for (int i = cdtPoints.Count - 2; i >= 0; i--)
		{
			if (ConformingDelaunayTriangulation2d.DistanceXY(cdtPoints[i].point_0, cdtPoints[i + 1].point_0) < Global.AbsoluteEpsilon)
			{
				cdtPoints[i].bool_0 = false;
				cdtPoints[i].point_0.X = x;
				cdtPoints[i].point_0.Y = y;
			}
			else
			{
				x = cdtPoints[i].point_0.X;
				y = cdtPoints[i].point_0.Y;
			}
		}
		for (int j = cdtPoints.Count - 1; j >= 0; j--)
		{
			if (cdtPoints[j].bool_0)
			{
				pointSet.Add(cdtPoints[j].point_0);
			}
			else
			{
				list_0.Add(cdtPoints[j].point_0);
			}
		}
		pointSet.RandomPermute();
		return pointSet;
	}

	private bool bool_0;

	internal readonly aabbcc jDkRxoitjlBypwUoEv_0;

	internal readonly Point point_0;
}
