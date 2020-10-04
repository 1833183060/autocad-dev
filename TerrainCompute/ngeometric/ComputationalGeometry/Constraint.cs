using System;
using System.Collections.Generic;
using System.ComponentModel;
using ngeometry.VectorGeometry;

namespace ngeometry.ComputationalGeometry
{
	public class Constraint
	{
		public Constraint(Edge edge, Constraint.ConstraintType type)
		{
			this.edge_0 = edge;
			this.constraintType = type;
		}

		public static List<Edge> GetEdges(List<Constraint> constraints)
		{
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < constraints.Count; i++)
			{
				list.Add(constraints[i].Edge);
			}
			return list;
		}

		public override string ToString()
		{
			string str = this.Edge.ToString();
			return str + "\nType: " + this.constraintType.ToString();
		}

		public static void UnreferenceEdges(List<Constraint> constraints)
		{
            if (constraints == null) return;
			for (int i = 0; i < constraints.Count; i++)
			{
				constraints[i].edge_0.StartPoint = constraints[i].edge_0.StartPoint.DeepCopy();
				constraints[i].edge_0.EndPoint = constraints[i].edge_0.EndPoint.DeepCopy();
			}
		}

		public Edge Edge
		{
			get
			{
				return this.edge_0;
			}
			set
			{
				this.edge_0 = value;
			}
		}

		public Constraint.ConstraintType Type
		{
			get
			{
				return this.constraintType;
			}
			set
			{
				this.constraintType = value;
			}
		}

		private Constraint.ConstraintType constraintType;

		private Edge edge_0;

		
		public enum ConstraintType
		{
			Constraint,
			Boundary
		}
	}
}
