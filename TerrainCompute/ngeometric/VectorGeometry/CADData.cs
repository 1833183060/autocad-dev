using System;
using System.ComponentModel;
using System.Drawing;

namespace ngeometry.VectorGeometry
{	
	[Serializable]
	public class CADData
	{
		public CADData()
		{			
			this.layer_0 = new Layer();
			this.color_0 = Color.Empty;
			this.short_0 = 256;
			this.string_0 = "";
			this.string_1 = "";
		}

		public CADData(Layer layer)
		{            
			this.layer_0 = new Layer();
			this.color_0 = Color.Empty;
			this.short_0 = 256;
			this.string_0 = "";
			this.string_1 = "";
			this.layer_0 = layer;
		}

		public CADData(Layer layer, string comment)
		{
            
			this.layer_0 = new Layer();
			this.color_0 = Color.Empty;
			this.short_0 = 256;
			this.string_0 = "";
			this.string_1 = "";
			//base..ctor();
			this.layer_0 = layer;
			this.string_1 = comment;
		}

		public CADData DeepCopy()
		{
			CADData cADData = new CADData();
			cADData.layer_0 = this.layer_0.DeepCopy();
			cADData.short_0 = this.short_0;
			cADData.string_0 = this.string_0;
			cADData.string_1 = this.string_1;
			cADData.double_0 = this.double_0;
			if (this.color_0 == Color.Empty)
			{
				cADData.color_0 = Color.Empty;
			}
			else
			{
				cADData.color_0 = Color.FromArgb((int)this.Color.A, (int)this.Color.R, (int)this.Color.G, (int)this.Color.B);
			}
			return cADData;
		}

		public override bool Equals(object obj)
		{
			return this == (CADData)obj;
		}

		public override int GetHashCode()
		{
			int hashCode = this.layer_0.GetHashCode();
			int hashCode2 = this.color_0.GetHashCode();
			int hashCode3 = this.short_0.GetHashCode();
			int hashCode4 = this.string_0.GetHashCode();
			int hashCode5 = this.string_1.GetHashCode();
			int hashCode6 = this.double_0.GetHashCode();
			return hashCode ^ hashCode2 ^ hashCode3 ^ hashCode4 ^ hashCode5 ^ hashCode6;
		}

		public static bool operator ==(CADData left, CADData right)
		{
            if ((object)left == (object)right)
            {
                return true;
            }
            if ((object)left == null || (object)right == null)
            {
                return false;
            }
            if (left.layer_0 != right.layer_0)
            {
                return false;
            }
            if (!left.color_0.Equals(right.color_0))
            {
                return false;
            }
            if (left.short_0 != right.short_0)
            {
                return false;
            }
            if (left.string_0 != right.string_0)
            {
                return false;
            }
            if (left.string_1 != right.string_1)
            {
                return false;
            }
            return true;
		}

		public static bool operator !=(CADData left, CADData right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"CADData ",
				this.GetHashCode().ToString(),
				":\nLayer      : ",
				this.layer_0.ToString(),
				"\nColor index: ",
				this.ColorIndex.ToString(),
				"\nColor      : ",
				this.Color.ToString(),
				"\nBlockName  : ",
				this.string_0.ToString(),
				"\nComment    : ",
				this.string_1.ToString()
			});
		}

		public string BlockName
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
				if (this.short_0 < 0 || this.short_0 > 256)
				{
					throw new ArgumentException("Entity color index must be between 0 and 256.");
				}
			}
		}

		public string Comment
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		public Layer Layer
		{
			get
			{
				return this.layer_0;
			}
			set
			{
				this.layer_0 = value;
			}
		}

		private Color color_0;

		internal double double_0;

		private Layer layer_0;

		private short short_0;

		private string string_0;

		private string string_1;
	}
}
