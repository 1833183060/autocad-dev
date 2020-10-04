using System;
using System.ComponentModel;
using System.Drawing;

namespace ngeometry.VectorGeometry
{
	
	[Serializable]
	public class Layer : IComparable<Layer>
	{
		public Layer()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Layer));
			this.string_0 = "0";
			this.color_0 = Color.Empty;
			this.short_0 = 7;
			//base..ctor();
		}

		public Layer(string name)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Layer));
			this.string_0 = "0";
			this.color_0 = Color.Empty;
			this.short_0 = 7;
			//base..ctor();
			this.string_0 = name;
		}

		public Layer(string name, byte colorIndex)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Layer));
			this.string_0 = "0";
			this.color_0 = Color.Empty;
			this.short_0 = 7;
			//base..ctor();
			this.string_0 = name;
			this.short_0 = (short)colorIndex;
		}

		public Layer(string name, byte colorIndex, Layer.DxfLineType lineType)
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Layer));
			this.string_0 = "0";
			this.color_0 = Color.Empty;
			this.short_0 = 7;
			//base..ctor();
			this.string_0 = name;
			this.short_0 = (short)colorIndex;
			this.dxfLineType_0 = lineType;
		}

		public int CompareTo(Layer layer)
		{
			return this.string_0.CompareTo(layer.string_0);
		}

		public Layer DeepCopy()
		{
			Layer layer = new Layer();
			layer.string_0 = this.string_0;
			layer.short_0 = this.short_0;
			layer.dxfLineType_0 = this.dxfLineType_0;
			layer.bool_0 = this.bool_0;
			if (this.color_0 == Color.Empty)
			{
				layer.color_0 = Color.Empty;
			}
			else
			{
				layer.color_0 = Color.FromArgb((int)this.Color.A, (int)this.Color.R, (int)this.Color.G, (int)this.Color.B);
			}
			return layer;
		}

		public override bool Equals(object obj)
		{
			return this == (Layer)obj;
		}

		public override int GetHashCode()
		{
			int hashCode = this.string_0.GetHashCode();
			int hashCode2 = this.color_0.GetHashCode();
			int hashCode3 = this.dxfLineType_0.GetHashCode();
			return hashCode ^ hashCode2 ^ hashCode3;
		}

		public static bool operator ==(Layer left, Layer right)
		{
            return (object)left == (object)right || ((object)left != null && (object)right != null && !(left.string_0 != right.string_0) && left.color_0.Equals(right.color_0) && left.short_0 == right.short_0 && left.dxfLineType_0 == right.dxfLineType_0 && left.bool_0 == right.bool_0);
		}

		public static bool operator !=(Layer left, Layer right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"Layer ",
				this.GetHashCode().ToString(),
				":\nName       : ",
				this.Name,
				"\nColor index: ",
				this.ColorIndex.ToString(),
				"\nColor      : ",
				this.Color.ToString(),
				"\nLine type  : ",
				this.LineType.ToString(),
				"\nFrozen     : ",
				this.IsFrozen.ToString()
			});
		}

		public Color Color
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
			}
		}

		public short ColorIndex
		{
			get
			{
				return this.short_0;
			}
			set
			{
				this.short_0 = value;
				if (this.short_0 < 1 || this.short_0 > 255)
				{
					throw new ArgumentException("Layer color index must be between 1 and 255.");
				}
			}
		}

		public bool IsFrozen
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public Layer.DxfLineType LineType
		{
			get
			{
				return this.dxfLineType_0;
			}
			set
			{
				this.dxfLineType_0 = value;
			}
		}

		public string Name
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		private bool bool_0;

		private Color color_0;

		private Layer.DxfLineType dxfLineType_0;

		private short short_0;

		private string string_0;

		
		public enum DxfLineType
		{
			CONTINUOUS,
			HIDDEN,
			DASHDOT,
			CENTER
		}
	}
}
