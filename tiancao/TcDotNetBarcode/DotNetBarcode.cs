using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace TcDotNetBarcode
{
	public class DotNetBarcode
	{
		public DotNetBarcode()
		{
			this.rotates_0 = DotNetBarcode.Rotates.Rotate0;
			this.float_1 = 0f;
			this.string_7 = "";
			this.string_5 = new string[11];
			this.string_3 = new string[11];
			this.string_2 = new string[11];
			this.string_4 = new string[11];
			this.byte_4 = new byte[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				7,
				8,
				8,
				8,
				8,
				8,
				8,
				8,
				8
			};
			this.byte_5 = new byte[]
			{
				8,
				8,
				8,
				8,
				8,
				8,
				8,
				8,
				7,
				5,
				4,
				3,
				2,
				1,
				0
			};
			this.byte_6 = new byte[15];
			this.byte_7 = new byte[15];
			this.color_7 = Color.Black;
			this.color_0 = Color.White;
			this.color_8 = Color.Black;
			this.color_1 = Color.White;
			this.color_9 = Color.Black;
			this.color_2 = Color.White;
			this.color_14 = Color.Black;
			this.color_4 = Color.White;
			this.color_10 = Color.White;
			this.color_11 = Color.White;
			this.fcrdyLoTeL = Color.White;
			this.color_15 = Color.Black;
			this.color_5 = Color.White;
			this.color_16 = Color.Black;
			this.color_6 = Color.White;
			this.color_12 = Color.Black;
			this.color_3 = Color.White;
			this.color_13 = Color.White;
			this.int_9 = 4;
			this.qrtextTypes_2 = DotNetBarcode.QRTextTypes.Automatic;
			this.method_10();
		}

		public DotNetBarcode(DotNetBarcode.Types barType)
		{
			this.rotates_0 = DotNetBarcode.Rotates.Rotate0;
			this.float_1 = 0f;
			this.string_7 = "";
			this.string_5 = new string[11];
			this.string_3 = new string[11];
			this.string_2 = new string[11];
			this.string_4 = new string[11];
			this.byte_4 = new byte[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				7,
				8,
				8,
				8,
				8,
				8,
				8,
				8,
				8
			};
			this.byte_5 = new byte[]
			{
				8,
				8,
				8,
				8,
				8,
				8,
				8,
				8,
				7,
				5,
				4,
				3,
				2,
				1,
				0
			};
			this.byte_6 = new byte[15];
			this.byte_7 = new byte[15];
			this.color_7 = Color.Black;
			this.color_0 = Color.White;
			this.color_8 = Color.Black;
			this.color_1 = Color.White;
			this.color_9 = Color.Black;
			this.color_2 = Color.White;
			this.color_14 = Color.Black;
			this.color_4 = Color.White;
			this.color_10 = Color.White;
			this.color_11 = Color.White;
			this.fcrdyLoTeL = Color.White;
			this.color_15 = Color.Black;
			this.color_5 = Color.White;
			this.color_16 = Color.Black;
			this.color_6 = Color.White;
			this.color_12 = Color.Black;
			this.color_3 = Color.White;
			this.color_13 = Color.White;
			this.int_9 = 4;
			this.qrtextTypes_2 = DotNetBarcode.QRTextTypes.Automatic;
			this.method_10();
			this.types_0 = barType;
		}

		public bool AddChechDigit
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

		public Color BackGroundColor
		{
			get
			{
				return this.color_17;
			}
			set
			{
				this.color_17 = value;
				this.QRBackColorBigMark1 = value;
				this.QRBackColorBigMark2 = value;
				this.QRBackColorBigMark3 = value;
				this.QRBackColorSmallMark = value;
				this.QRColorBigMarkBorder1 = value;
				this.QRColorBigMarkBorder2 = value;
				this.QRColorBigMarkBorder3 = value;
				this.QRBackColorTimingPattern = value;
				this.QRBackColorVersionInformation = value;
				this.QRBackColorFormatInformation = value;
				this.QRColorQuitZone = value;
			}
		}

		public Color BarColor
		{
			get
			{
				return this.color_18;
			}
			set
			{
				this.color_18 = value;
				this.QRColorBigMark1 = value;
				this.QRColorBigMark2 = value;
				this.QRColorBigMark3 = value;
				this.QRColorSmallMark = value;
				this.QRColorTimingPattern = value;
				this.QRColorVersionInformation = value;
				this.QRColorFormatInformation = value;
			}
		}

		public Color DebugInfoEvenColor
		{
			get
			{
				return this.color_19;
			}
			set
			{
				this.color_19 = value;
			}
		}

		public Color DebugInfoLastColor
		{
			get
			{
				return this.color_20;
			}
			set
			{
				this.color_20 = value;
			}
		}

		public Color DebugInfoOddColor
		{
			get
			{
				return this.color_21;
			}
			set
			{
				this.color_21 = value;
			}
		}

		public Color FontBackGroundColor
		{
			get
			{
				return this.color_22;
			}
			set
			{
				this.color_22 = value;
			}
		}

		public bool FontBold
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		public Color FontColor
		{
			get
			{
				return this.color_23;
			}
			set
			{
				this.color_23 = value;
			}
		}

		public bool FontItalic
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		public string FontName
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}

		public float FontSize
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
			}
		}

		public bool PrintChar
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}

		public bool PrintCheckDigitChar
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		public Color QRBackColorBigMark
		{
			set
			{
				this.color_0 = value;
				this.color_1 = value;
				this.color_2 = value;
			}
		}

		public Color QRBackColorBigMark1
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

		public Color QRBackColorBigMark2
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
			}
		}

		public Color QRBackColorBigMark3
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
			}
		}

		public Color QRBackColorFormatInformation
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
			}
		}

		public Color QRBackColorSmallMark
		{
			get
			{
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
			}
		}

		public Color QRBackColorTimingPattern
		{
			get
			{
				return this.color_5;
			}
			set
			{
				this.color_5 = value;
			}
		}

		public Color QRBackColorVersionInformation
		{
			get
			{
				return this.color_6;
			}
			set
			{
				this.color_6 = value;
			}
		}

		public string QRBackGroundFileName
		{
			get
			{
				return this.string_7;
			}
			set
			{
				if (Operators.CompareString(value, "", false) != 0)
				{
					try
					{
						this.bitmap_0 = new Bitmap(value);
					}
					catch (Exception ex)
					{
						value = "";
					}
				}
				this.string_7 = value;
			}
		}

		public Color QRColorBigMark
		{
			set
			{
				this.color_7 = value;
				this.color_8 = value;
				this.color_9 = value;
			}
		}

		public Color QRColorBigMark1
		{
			get
			{
				return this.color_7;
			}
			set
			{
				this.color_7 = value;
			}
		}

		public Color QRColorBigMark2
		{
			get
			{
				return this.color_8;
			}
			set
			{
				this.color_8 = value;
			}
		}

		public Color QRColorBigMark3
		{
			get
			{
				return this.color_9;
			}
			set
			{
				this.color_9 = value;
			}
		}

		public Color QRColorBigMarkBorder
		{
			set
			{
				this.color_10 = value;
				this.color_11 = value;
				this.fcrdyLoTeL = value;
			}
		}

		public Color QRColorBigMarkBorder1
		{
			get
			{
				return this.color_10;
			}
			set
			{
				this.color_10 = value;
			}
		}

		public Color QRColorBigMarkBorder2
		{
			get
			{
				return this.color_11;
			}
			set
			{
				this.color_11 = value;
			}
		}

		public Color QRColorBigMarkBorder3
		{
			get
			{
				return this.fcrdyLoTeL;
			}
			set
			{
				this.fcrdyLoTeL = value;
			}
		}

		public Color QRColorFormatInformation
		{
			get
			{
				return this.color_12;
			}
			set
			{
				this.color_12 = value;
			}
		}

		public Color QRColorQuitZone
		{
			get
			{
				return this.color_13;
			}
			set
			{
				this.color_13 = value;
			}
		}

		public Color QRColorSmallMark
		{
			get
			{
				return this.color_14;
			}
			set
			{
				this.color_14 = value;
			}
		}

		public Color QRColorTimingPattern
		{
			get
			{
				return this.color_15;
			}
			set
			{
				this.color_15 = value;
			}
		}

		public Color QRColorVersionInformation
		{
			get
			{
				return this.color_16;
			}
			set
			{
				this.color_16 = value;
			}
		}

		public int QRInquireAlphaNumericBits
		{
			get
			{
				return this.int_4;
			}
		}

		public int QRInquireBinaryBits
		{
			get
			{
				return this.int_5;
			}
		}

		public int QRInquireKanjiBits
		{
			get
			{
				return this.int_6;
			}
		}

		public int QRInquireModuleSize
		{
			get
			{
				return this.int_7;
			}
		}

		public int QRInquireNumericBits
		{
			get
			{
				return this.int_8;
			}
		}

		public DotNetBarcode.QRTextTypes QRInquireTextType
		{
			get
			{
				return this.qrtextTypes_0;
			}
		}

		public DotNetBarcode.QRVersions QRInquireVersion
		{
			get
			{
				return this.qrversions_0;
			}
		}

		public int Int32_0
		{
			get
			{
				return this.int_9;
			}
			set
			{
				this.int_9 = value;
			}
		}

		public float QRRotate
		{
			get
			{
				return this.float_1;
			}
			set
			{
				this.float_1 = value;
				if (this.Rotate != DotNetBarcode.Rotates.Rotate0)
				{
					this.Rotate = DotNetBarcode.Rotates.Rotate0;
				}
			}
		}

		public DotNetBarcode.QRECCRates QRSetECCRate
		{
			get
			{
				return this.qreccrates_0;
			}
			set
			{
				this.qreccrates_0 = value;
			}
		}

		public DotNetBarcode.QRTextTypes QRSetTextType
		{
			get
			{
				return this.qrtextTypes_1;
			}
			set
			{
				this.qrtextTypes_1 = value;
			}
		}

		public DotNetBarcode.QRVersions QRSetVersion
		{
			get
			{
				return this.qrversions_1;
			}
			set
			{
				if (value >= DotNetBarcode.QRVersions.Automatic & value <= DotNetBarcode.QRVersions.Ver40)
				{
					this.qrversions_1 = value;
				}
			}
		}

		public DotNetBarcode.Rotates Rotate
		{
			get
			{
				return this.rotates_0;
			}
			set
			{
				this.rotates_0 = value;
				if (this.QRRotate != 0f)
				{
					this.QRRotate = 0f;
				}
			}
		}

		public DotNetBarcode.SaveFileTypes SaveFileType
		{
			get
			{
				return this.saveFileTypes_0;
			}
			set
			{
				this.saveFileTypes_0 = value;
			}
		}

		public DotNetBarcode.Types Type
		{
			get
			{
				return this.types_0;
			}
			set
			{
				this.types_0 = value;
			}
		}

		public bool WriteDebugInfo
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
			}
		}

		private short method_0(string string_8)
		{
			string str = "131313131313";
			short num = 0;
			short num2 = 0;
			do
			{
				num += Conversions.ToShort(Strings.Mid(string_8, (int)(checked(num2 + 1)), 1)) * Conversions.ToShort(Strings.Mid(str, (int)(checked(num2 + 1)), 1));
				checked
				{
					num2 += 1;
				}
			}
			while (num2 <= 11);
			num %= 10;
			num = checked(10 - num);
			if (num == 10)
			{
				num = 0;
			}
			return num;
		}

		private bool method_1(string string_8)
		{
			return (Operators.CompareString(string_8, "0", false) >= 0 & Operators.CompareString(string_8, "9", false) <= 0) || (Operators.CompareString(string_8, "A", false) >= 0 & Operators.CompareString(string_8, "Z", false) <= 0) || (Operators.CompareString(string_8, " ", false) == 0 | Operators.CompareString(string_8, "$", false) == 0 | Operators.CompareString(string_8, "%", false) == 0 | Operators.CompareString(string_8, "*", false) == 0 | Operators.CompareString(string_8, "+", false) == 0 | Operators.CompareString(string_8, "-", false) == 0 | Operators.CompareString(string_8, ".", false) == 0 | Operators.CompareString(string_8, "/", false) == 0 | Operators.CompareString(string_8, ":", false) == 0);
		}

		private bool method_2(string string_8)
		{
			Encoding encoding = Encoding.GetEncoding("Shift_JIS");
			byte[] bytes = encoding.GetBytes(string_8);
			return (((int)bytes[0] >= Convert.ToInt32("81", 16) & (int)bytes[0] <= Convert.ToInt32("9F", 16)) && ((int)bytes[1] >= Convert.ToInt32("40", 16) & (int)bytes[1] <= Convert.ToInt32("FF", 16))) || (((int)bytes[0] >= Convert.ToInt32("E0", 16) & (int)bytes[0] <= Convert.ToInt32("EA", 16)) && ((int)bytes[1] >= Convert.ToInt32("40", 16) & (int)bytes[1] <= Convert.ToInt32("FF", 16))) || (((int)bytes[0] >= Convert.ToInt32("EB", 16) & (int)bytes[0] <= Convert.ToInt32("EB", 16)) && ((int)bytes[1] >= Convert.ToInt32("40", 16) & (int)bytes[1] <= Convert.ToInt32("BF", 16)));
		}

		private bool method_3(string string_8)
		{
			return Operators.CompareString(string_8, "0", false) >= 0 & Operators.CompareString(string_8, "9", false) <= 0;
		}

		private void method_4(float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			graphics_0.FillRectangle(new SolidBrush(Color.White)
			{
				Color = this.color_17
			}, float_2, float_3, float_4, float_5);
		}

		private string method_5(string string_8)
		{
			int num = 0;
			int num2 = Strings.Len(string_8);
			checked
			{
				for (int i = 1; i <= num2; i++)
				{
					num += this.method_7(Strings.Mid(string_8, i, 1));
				}
				num %= 43;
				return this.method_6(num);
			}
		}

		private string method_6(int int_10)
		{
			string result = " ";
			switch (int_10)
			{
			case 0:
				return "0";
			case 1:
				return "1";
			case 2:
				return "2";
			case 3:
				return "3";
			case 4:
				return "4";
			case 5:
				return "5";
			case 6:
				return "6";
			case 7:
				return "7";
			case 8:
				return "8";
			case 9:
				return "9";
			case 10:
				return "A";
			case 11:
				return "B";
			case 12:
				return "C";
			case 13:
				return "D";
			case 14:
				return "E";
			case 15:
				return "F";
			case 16:
				return "G";
			case 17:
				return "H";
			case 18:
				return "I";
			case 19:
				return "J";
			case 20:
				return "K";
			case 21:
				return "L";
			case 22:
				return "M";
			case 23:
				return "N";
			case 24:
				return "O";
			case 25:
				return "P";
			case 26:
				return "Q";
			case 27:
				return "R";
			case 28:
				return "S";
			case 29:
				return "T";
			case 30:
				return "U";
			case 31:
				return "V";
			case 32:
				return "W";
			case 33:
				return "X";
			case 34:
				return "Y";
			case 35:
				return "Z";
			case 36:
				return "-";
			case 37:
				return ".";
			case 38:
				return " ";
			case 39:
				return "$";
			case 40:
				return "/";
			case 41:
				return "+";
			case 42:
				return "%";
			default:
				return result;
			}
		}

		private int method_7(string string_8)
		{
			int result = 0;
			string left = string_8.ToUpper();
			if (Operators.CompareString(left, "0", false) == 0)
			{
				return 0;
			}
			if (Operators.CompareString(left, "1", false) == 0)
			{
				return 1;
			}
			if (Operators.CompareString(left, "2", false) == 0)
			{
				return 2;
			}
			if (Operators.CompareString(left, "3", false) == 0)
			{
				return 3;
			}
			if (Operators.CompareString(left, "4", false) == 0)
			{
				return 4;
			}
			if (Operators.CompareString(left, "5", false) == 0)
			{
				return 5;
			}
			if (Operators.CompareString(left, "6", false) == 0)
			{
				return 6;
			}
			if (Operators.CompareString(left, "7", false) == 0)
			{
				return 7;
			}
			if (Operators.CompareString(left, "8", false) == 0)
			{
				return 8;
			}
			if (Operators.CompareString(left, "9", false) == 0)
			{
				return 9;
			}
			if (Operators.CompareString(left, "A", false) == 0)
			{
				return 10;
			}
			if (Operators.CompareString(left, "B", false) == 0)
			{
				return 11;
			}
			if (Operators.CompareString(left, "C", false) == 0)
			{
				return 12;
			}
			if (Operators.CompareString(left, "D", false) == 0)
			{
				return 13;
			}
			if (Operators.CompareString(left, "E", false) == 0)
			{
				return 14;
			}
			if (Operators.CompareString(left, "F", false) == 0)
			{
				return 15;
			}
			if (Operators.CompareString(left, "G", false) == 0)
			{
				return 16;
			}
			if (Operators.CompareString(left, "H", false) == 0)
			{
				return 17;
			}
			if (Operators.CompareString(left, "I", false) == 0)
			{
				return 18;
			}
			if (Operators.CompareString(left, "J", false) == 0)
			{
				return 19;
			}
			if (Operators.CompareString(left, "K", false) == 0)
			{
				return 20;
			}
			if (Operators.CompareString(left, "L", false) == 0)
			{
				return 21;
			}
			if (Operators.CompareString(left, "M", false) == 0)
			{
				return 22;
			}
			if (Operators.CompareString(left, "N", false) == 0)
			{
				return 23;
			}
			if (Operators.CompareString(left, "O", false) == 0)
			{
				return 24;
			}
			if (Operators.CompareString(left, "P", false) == 0)
			{
				return 25;
			}
			if (Operators.CompareString(left, "Q", false) == 0)
			{
				return 26;
			}
			if (Operators.CompareString(left, "R", false) == 0)
			{
				return 27;
			}
			if (Operators.CompareString(left, "S", false) == 0)
			{
				return 28;
			}
			if (Operators.CompareString(left, "T", false) == 0)
			{
				return 29;
			}
			if (Operators.CompareString(left, "U", false) == 0)
			{
				return 30;
			}
			if (Operators.CompareString(left, "V", false) == 0)
			{
				return 31;
			}
			if (Operators.CompareString(left, "W", false) == 0)
			{
				return 32;
			}
			if (Operators.CompareString(left, "X", false) == 0)
			{
				return 33;
			}
			if (Operators.CompareString(left, "Y", false) == 0)
			{
				return 34;
			}
			if (Operators.CompareString(left, "Z", false) == 0)
			{
				return 35;
			}
			if (Operators.CompareString(left, "-", false) == 0)
			{
				return 36;
			}
			if (Operators.CompareString(left, ".", false) == 0)
			{
				return 37;
			}
			if (Operators.CompareString(left, " ", false) == 0)
			{
				return 38;
			}
			if (Operators.CompareString(left, "$", false) == 0)
			{
				return 39;
			}
			if (Operators.CompareString(left, "/", false) == 0)
			{
				return 40;
			}
			if (Operators.CompareString(left, "+", false) == 0)
			{
				return 41;
			}
			if (Operators.CompareString(left, "%", false) == 0)
			{
				result = 42;
			}
			return result;
		}

		private string method_8(string string_8)
		{
			string result = "";
			string left = string_8.ToUpper();
			if (Operators.CompareString(left, "0", false) == 0)
			{
				return "000110100";
			}
			if (Operators.CompareString(left, "1", false) == 0)
			{
				return "100100001";
			}
			if (Operators.CompareString(left, "2", false) == 0)
			{
				return "001100001";
			}
			if (Operators.CompareString(left, "3", false) == 0)
			{
				return "101100000";
			}
			if (Operators.CompareString(left, "4", false) == 0)
			{
				return "000110001";
			}
			if (Operators.CompareString(left, "5", false) == 0)
			{
				return "100110000";
			}
			if (Operators.CompareString(left, "6", false) == 0)
			{
				return "001110000";
			}
			if (Operators.CompareString(left, "7", false) == 0)
			{
				return "000100101";
			}
			if (Operators.CompareString(left, "8", false) == 0)
			{
				return "100100100";
			}
			if (Operators.CompareString(left, "9", false) == 0)
			{
				return "001100100";
			}
			if (Operators.CompareString(left, "A", false) == 0)
			{
				return "100001001";
			}
			if (Operators.CompareString(left, "B", false) == 0)
			{
				return "001001001";
			}
			if (Operators.CompareString(left, "C", false) == 0)
			{
				return "101001000";
			}
			if (Operators.CompareString(left, "D", false) == 0)
			{
				return "000011001";
			}
			if (Operators.CompareString(left, "E", false) == 0)
			{
				return "100011000";
			}
			if (Operators.CompareString(left, "F", false) == 0)
			{
				return "001011000";
			}
			if (Operators.CompareString(left, "G", false) == 0)
			{
				return "000001101";
			}
			if (Operators.CompareString(left, "H", false) == 0)
			{
				return "100001100";
			}
			if (Operators.CompareString(left, "I", false) == 0)
			{
				return "001001100";
			}
			if (Operators.CompareString(left, "J", false) == 0)
			{
				return "000011100";
			}
			if (Operators.CompareString(left, "K", false) == 0)
			{
				return "100000011";
			}
			if (Operators.CompareString(left, "L", false) == 0)
			{
				return "001000011";
			}
			if (Operators.CompareString(left, "M", false) == 0)
			{
				return "101000010";
			}
			if (Operators.CompareString(left, "N", false) == 0)
			{
				return "000010011";
			}
			if (Operators.CompareString(left, "O", false) == 0)
			{
				return "100010010";
			}
			if (Operators.CompareString(left, "P", false) == 0)
			{
				return "001010010";
			}
			if (Operators.CompareString(left, "Q", false) == 0)
			{
				return "000000111";
			}
			if (Operators.CompareString(left, "R", false) == 0)
			{
				return "100000110";
			}
			if (Operators.CompareString(left, "S", false) == 0)
			{
				return "001000110";
			}
			if (Operators.CompareString(left, "T", false) == 0)
			{
				return "000010110";
			}
			if (Operators.CompareString(left, "U", false) == 0)
			{
				return "110000001";
			}
			if (Operators.CompareString(left, "V", false) == 0)
			{
				return "011000001";
			}
			if (Operators.CompareString(left, "W", false) == 0)
			{
				return "111000000";
			}
			if (Operators.CompareString(left, "X", false) == 0)
			{
				return "010010001";
			}
			if (Operators.CompareString(left, "Y", false) == 0)
			{
				return "110010000";
			}
			if (Operators.CompareString(left, "Z", false) == 0)
			{
				return "011010000";
			}
			if (Operators.CompareString(left, "-", false) == 0)
			{
				return "010000101";
			}
			if (Operators.CompareString(left, ".", false) == 0)
			{
				return "110000100";
			}
			if (Operators.CompareString(left, " ", false) == 0)
			{
				return "011000100";
			}
			if (Operators.CompareString(left, "$", false) == 0)
			{
				return "010101000";
			}
			if (Operators.CompareString(left, "/", false) == 0)
			{
				return "010100010";
			}
			if (Operators.CompareString(left, "+", false) == 0)
			{
				return "010001010";
			}
			if (Operators.CompareString(left, "%", false) == 0)
			{
				return "000101010";
			}
			if (Operators.CompareString(left, "*", false) == 0)
			{
				result = "010010100";
			}
			return result;
		}

		private void method_9(string string_8, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			solidBrush.Color = this.color_18;
			int num = 0;
			string string_9 = string_8;
			if (Operators.CompareString(string_8, "", false) != 0)
			{
				string_8 = "*" + string_8;
				if (this.bool_0)
				{
					string_8 += this.method_5(string_8);
				}
				string_8 += "*";
				if (this.bool_4)
				{
					string_9 = string_8;
				}
				float num2 = float_4 / ((float)Strings.Len(string_8) * 13f);
				this.method_4(float_2, float_3, float_4, float_5, graphics_0);
				int num3 = Strings.Len(string_8);
				checked
				{
					for (int i = 1; i <= num3; i++)
					{
						string text = this.method_8(Strings.Mid(string_8, i, 1));
						if (Operators.CompareString(text, "", false) != 0)
						{
							int num4 = Strings.Len(text);
							int j;
							float num5;
							float num6;
							float num7;
							for (j = 1; j <= num4; j++)
							{
								float height;
								if (Operators.CompareString(Strings.Mid(text, j, 1), "1", false) == 0)
								{
									unchecked
									{
										num5 = float_2 + (float)num * num2;
										num6 = 2f * num2;
										num7 = float_3;
										height = float_5;
									}
									num += 2;
								}
								else
								{
									unchecked
									{
										num5 = float_2 + (float)num * num2;
										num6 = 1f * num2;
										num7 = float_3;
										height = float_5;
									}
									num++;
								}
								if (j % 2 == 1)
								{
									graphics_0.FillRectangle(solidBrush, num5, num7, num6, height);
								}
								this.method_35(j, Strings.Len(text) + 1, num5, num6, num7, float_5, graphics_0);
							}
							num5 = unchecked(float_2 + (float)num * num2);
							this.method_35(j, Strings.Len(text) + 1, num5, num6, num7, float_5, graphics_0);
							num++;
						}
					}
				}
				this.method_36(string_9, float_2 + float_4 / 2f, float_3 + float_5, graphics_0);
			}
		}

		private void method_10()
		{
			this.types_0 = DotNetBarcode.Types.EAN_13;
			this.color_18 = Color.Black;
			this.color_17 = Color.White;
			this.color_23 = Color.Black;
			this.color_22 = Color.White;
			this.string_6 = "ＭＳ Ｐゴシック";
			this.float_0 = 9f;
			this.bool_0 = false;
			this.bool_3 = true;
			this.bool_4 = false;
			this.bool_5 = false;
			this.color_21 = Color.DarkBlue;
			this.color_19 = Color.LightBlue;
			this.color_20 = Color.Red;
			this.saveFileTypes_0 = DotNetBarcode.SaveFileTypes.BitMap;
			this.bool_1 = false;
			this.bool_2 = false;
			this.string_5[0] = "111111";
			this.string_5[1] = "110100";
			this.string_5[2] = "110010";
			this.string_5[3] = "110001";
			this.string_5[4] = "101100";
			this.string_5[5] = "100110";
			this.string_5[6] = "100011";
			this.string_5[7] = "101010";
			this.string_5[8] = "101001";
			this.string_5[9] = "100101";
			this.string_3[0] = "0001101";
			this.string_3[1] = "0011001";
			this.string_3[2] = "0010011";
			this.string_3[3] = "0111101";
			this.string_3[4] = "0100011";
			this.string_3[5] = "0110001";
			this.string_3[6] = "0101111";
			this.string_3[7] = "0111011";
			this.string_3[8] = "0110111";
			this.string_3[9] = "0001011";
			this.string_2[0] = "0100111";
			this.string_2[1] = "0110011";
			this.string_2[2] = "0011011";
			this.string_2[3] = "0100001";
			this.string_2[4] = "0011101";
			this.string_2[5] = "0111001";
			this.string_2[6] = "0000101";
			this.string_2[7] = "0010001";
			this.string_2[8] = "0001001";
			this.string_2[9] = "0010111";
			this.string_4[0] = "1110010";
			this.string_4[1] = "1100110";
			this.string_4[2] = "1101100";
			this.string_4[3] = "1000010";
			this.string_4[4] = "1011100";
			this.string_4[5] = "1001110";
			this.string_4[6] = "1010000";
			this.string_4[7] = "1000100";
			this.string_4[8] = "1001000";
			this.string_4[9] = "1110100";
			this.method_17();
		}

		public void CopyToClipboard(string code, float Width, float High)
		{
			if (this.Type == DotNetBarcode.Types.QRCode)
			{
				this.method_32(code);
				float num = (float)this.QRInquireModuleSize;
				if (num > 0f)
				{
					int num2 = this.method_15(num, Width, High);
					if (num2 <= 0)
					{
						return;
					}
					this.QRCopyToClipboard(code, num2);
				}
			}
			else
			{
				Bitmap bitmap = checked(new Bitmap((int)Math.Round(Math.Round((double)Width)), (int)Math.Round(Math.Round((double)High)), PixelFormat.Format24bppRgb));
				Graphics ev = Graphics.FromImage(bitmap);
				this.WriteBar(code, 0f, 0f, Width, High, ev);
				Clipboard.SetDataObject(bitmap);
			}
		}

		private void method_11(string string_8, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			bool flag = true;
			int num = Strings.Len(string_8);
			string str;
			float num2;
			checked
			{
				for (int i = 1; i <= num; i++)
				{
					if (!char.IsNumber(string_8, i - 1))
					{
						flag = false;
					}
				}
				if (!flag)
				{
					string_8 = "0000000000000";
				}
				if (this.bool_0)
				{
					if (Strings.Len(string_8) <= 12)
					{
						string_8 = Strings.Left(string_8 + "000000000000", 12);
					}
					else
					{
						string_8 = Strings.Left(string_8, 12);
					}
					str = string_8;
					short value = this.method_0(string_8);
					string_8 += Conversions.ToString((int)value);
					if (this.bool_4)
					{
						str = string_8;
					}
				}
				else
				{
					if (Strings.Len(string_8) <= 13)
					{
						string_8 = Strings.Left(string_8 + "000000000000", 13);
					}
					else
					{
						string_8 = Strings.Left(string_8, 13);
					}
					str = string_8;
				}
				num2 = float_4 / 95f;
				this.method_4(float_2, float_3, float_4, float_5, graphics_0);
				this.method_38("101", float_2, num2, float_3, float_5, graphics_0);
				short num3;
				string str2 = this.string_5[Strings.Asc(Strings.Mid(string_8, (int)(num3 + 1), 1)) - 48];
				num3 = 1;
				do
				{
					string string_9 = Strings.Mid(string_8, (int)(num3 + 1), 1);
					unchecked
					{
						if (Operators.CompareString(Strings.Mid(str2, (int)num3, 1), "1", false) == 0)
						{
							this.method_37(string_9, this.string_3, float_2 + (float)(checked(num3 * 7 - 4)) * num2, num2, float_3, float_5, graphics_0);
						}
						else
						{
							this.method_37(string_9, this.string_2, float_2 + (float)(checked(num3 * 7 - 4)) * num2, num2, float_3, float_5, graphics_0);
						}
					}
					num3 += 1;
				}
				while (num3 <= 6);
				this.method_38("01010", unchecked(float_2 + 45f * num2), num2, float_3, float_5, graphics_0);
				num3 = 7;
				do
				{
					string string_9 = Strings.Mid(string_8, (int)(num3 + 1), 1);
					this.method_37(string_9, this.string_4, unchecked(float_2 + (float)(checked(num3 * 7 + 1)) * num2), num2, float_3, float_5, graphics_0);
					num3 += 1;
				}
				while (num3 <= 12);
			}
			this.method_38("101", float_2 + 92f * num2, num2, float_3, float_5, graphics_0);
			string string_10 = string.Concat(new string[]
			{
				Strings.Mid(str, 1, 1),
				" ",
				Strings.Mid(str, 2, 6),
				" ",
				Strings.Mid(str, 8, 6)
			});
			this.method_36(string_10, float_2 + float_4 / 2f, float_3 + float_5, graphics_0);
		}

		private short method_12(string string_8)
		{
			string str = "3131313";
			short num = 0;
			short num2 = 0;
			do
			{
				num += Conversions.ToShort(Strings.Mid(string_8, (int)(checked(num2 + 1)), 1)) * Conversions.ToShort(Strings.Mid(str, (int)(checked(num2 + 1)), 1));
				checked
				{
					num2 += 1;
				}
			}
			while (num2 <= 6);
			num %= 10;
			num = checked(10 - num);
			if (num == 10)
			{
				num = 0;
			}
			return num;
		}

		private void method_13(string string_8, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			bool flag = true;
			int num = Strings.Len(string_8);
			string str;
			float num2;
			checked
			{
				for (int i = 1; i <= num; i++)
				{
					if (!char.IsNumber(string_8, i - 1))
					{
						flag = false;
					}
				}
				if (!flag)
				{
					string_8 = "0000000000000";
				}
				if (this.bool_0)
				{
					if (Strings.Len(string_8) <= 7)
					{
						string_8 = Strings.Left(string_8 + "0000000", 7);
					}
					else
					{
						string_8 = Strings.Left(string_8, 7);
					}
					str = string_8;
					short value = this.method_12(string_8);
					string_8 += Conversions.ToString((int)value);
					if (this.bool_4)
					{
						str = string_8;
					}
				}
				else
				{
					if (Strings.Len(string_8) <= 8)
					{
						string_8 = Strings.Left(string_8 + "00000000", 8);
					}
					else
					{
						string_8 = Strings.Left(string_8, 8);
					}
					str = string_8;
				}
				num2 = float_4 / 67f;
				this.method_4(float_2, float_3, float_4, float_5, graphics_0);
				this.method_38("101", float_2, num2, float_3, float_5, graphics_0);
				short num3 = 0;
				do
				{
					string string_9 = Strings.Mid(string_8, (int)(num3 + 1), 1);
					this.method_37(string_9, this.string_3, unchecked(float_2 + (float)(checked((num3 + 1) * 7 - 4)) * num2), num2, float_3, float_5, graphics_0);
					num3 += 1;
				}
				while (num3 <= 3);
				this.method_38("01010", unchecked(float_2 + 31f * num2), num2, float_3, float_5, graphics_0);
				num3 = 4;
				do
				{
					string string_9 = Strings.Mid(string_8, (int)(num3 + 1), 1);
					this.method_37(string_9, this.string_4, unchecked(float_2 + (float)(checked((num3 + 1) * 7 + 1)) * num2), num2, float_3, float_5, graphics_0);
					num3 += 1;
				}
				while (num3 <= 7);
			}
			this.method_38("101", float_2 + 64f * num2, num2, float_3, float_5, graphics_0);
			string string_10 = Strings.Mid(str, 1, 4) + " " + Strings.Mid(str, 5, 4);
			this.method_36(string_10, float_2 + float_4 / 2f, float_3 + float_5, graphics_0);
		}

		public void qrcode_write_barcode(string code, float X, float Y, int pQuitZoneSize, Graphics ev)
		{
			if (code.Length > 0)
			{
				byte[,] array = this.method_32(code);
				float num = (float)array.GetLength(0);
				if (num > 0f && pQuitZoneSize > 0)
				{
					float num2 = (float)((double)((float)pQuitZoneSize * (num + (float)this.int_9 * 2f)) * (Math.Abs(Math.Sin((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) + Math.Abs(Math.Cos((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) - 1.0) / 2.0);
					X += num2;
					Y += num2;
					SolidBrush solidBrush = new SolidBrush(this.BackGroundColor);
					ev.FillRectangle(solidBrush, X - num2, Y - num2, 2f * num2 + (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))), 2f * num2 + (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))));
					if (this.QRRotate == 0f)
					{
						if (this.Rotate == DotNetBarcode.Rotates.Rotate90)
						{
							ev.TranslateTransform(X, Y);
							ev.RotateTransform(90f);
							ev.TranslateTransform(-X, -Y - (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))));
						}
						if (this.Rotate == DotNetBarcode.Rotates.const_1)
						{
							ev.TranslateTransform(X, Y);
							ev.RotateTransform(180f);
							ev.TranslateTransform(-X - (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))), -Y - (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))));
						}
						if (this.Rotate == DotNetBarcode.Rotates.const_2)
						{
							ev.TranslateTransform(X, Y);
							ev.RotateTransform(270f);
							ev.TranslateTransform(-X - (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))), -Y);
						}
					}
					else
					{
						float num3 = (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))) / 2f;
						ev.TranslateTransform(X + num3, Y + num3);
						ev.RotateTransform(this.QRRotate);
						ev.TranslateTransform(-X - num3, -Y - num3);
					}
					solidBrush.Color = this.QRColorQuitZone;
					bool flag;
					if (Operators.CompareString(this.QRBackGroundFileName, "", false) != 0)
					{
						ev.DrawImage(this.bitmap_0, X, Y, (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))), (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))));
						flag = true;
					}
					else
					{
						ev.FillRectangle(solidBrush, X, Y, (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))), (float)pQuitZoneSize * (num + (float)(checked(this.int_9 * 2))));
						flag = false;
					}
					checked
					{
						int num4 = array.GetLength(0) - 1;
						for (int i = 0; i <= num4; i++)
						{
							int num5 = array.GetLength(1) - 1;
							for (int j = 0; j <= num5; j++)
							{
								byte b = array[i, j];
								bool flag2 = false;
								if ((b & 1) == 1)
								{
									solidBrush.Color = this.BarColor;
								}
								else
								{
									solidBrush.Color = this.BackGroundColor;
									flag2 = true;
								}
								if ((b & 2) == 2)
								{
									if ((b & 1) == 1)
									{
										if ((float)i < num / 2f & (float)j < num / 2f)
										{
											solidBrush.Color = this.QRColorBigMark1;
										}
										else if ((float)i >= num / 2f & (float)j < num / 2f)
										{
											solidBrush.Color = this.QRColorBigMark3;
										}
										else
										{
											solidBrush.Color = this.QRColorBigMark2;
										}
									}
									else if ((float)i < num / 2f & (float)j < num / 2f)
									{
										solidBrush.Color = this.QRBackColorBigMark1;
									}
									else if ((float)i >= num / 2f & (float)j < num / 2f)
									{
										solidBrush.Color = this.QRBackColorBigMark3;
									}
									else
									{
										solidBrush.Color = this.QRBackColorBigMark2;
									}
								}
								if ((b & 16) == 16)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorTimingPattern;
									}
									else
									{
										solidBrush.Color = this.QRBackColorTimingPattern;
									}
								}
								if ((b & 4) == 4)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorSmallMark;
									}
									else
									{
										solidBrush.Color = this.QRBackColorSmallMark;
									}
								}
								if (b == 8)
								{
									if ((float)i < num / 2f & (float)j < num / 2f)
									{
										solidBrush.Color = this.QRColorBigMarkBorder1;
									}
									else if ((float)i >= num / 2f & (float)j < num / 2f)
									{
										solidBrush.Color = this.QRColorBigMarkBorder3;
									}
									else
									{
										solidBrush.Color = this.QRColorBigMarkBorder2;
									}
								}
								if ((b & 32) == 32)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorVersionInformation;
									}
									else
									{
										solidBrush.Color = this.QRBackColorVersionInformation;
									}
								}
								if ((b & 64) == 64)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorFormatInformation;
									}
									else
									{
										solidBrush.Color = this.QRBackColorFormatInformation;
									}
								}
								unchecked
								{
									if (!flag2 | !flag)
									{
										ev.FillRectangle(solidBrush, X + (float)(checked((this.int_9 + i) * pQuitZoneSize)), Y + (float)(checked((this.int_9 + j) * pQuitZoneSize)), (float)pQuitZoneSize, (float)pQuitZoneSize);
									}
								}
							}
						}
					}
				}
			}
		}

		public string QRCode_GetHeiBaiString(string code)
		{
			short num = 300;
			short num2 = 300;
			string text = "";
			bool flag = false;
			if (code.Length > 0)
			{
				byte[,] array = this.method_32(code);
				float num3 = (float)array.GetLength(0);
				if (num3 > 0f)
				{
					float num4 = (float)((double)(300f * (num3 + (float)this.int_9 * 2f)) * (Math.Abs(Math.Sin((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) + Math.Abs(Math.Cos((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) - 1.0) / 2.0);
					checked
					{
						num = (short)Math.Round((double)(unchecked((float)num + num4)));
						num2 = (short)Math.Round((double)(unchecked((float)num2 + num4)));
						SolidBrush solidBrush = new SolidBrush(this.BackGroundColor);
						int num5 = array.GetLength(0) - 1;
						for (int i = 0; i <= num5; i++)
						{
							int num6 = array.GetLength(1) - 1;
							for (int j = 0; j <= num6; j++)
							{
								byte b = array[i, j];
								bool flag2 = false;
								if ((b & 1) == 1)
								{
									solidBrush.Color = this.BarColor;
								}
								else
								{
									solidBrush.Color = this.BackGroundColor;
									flag2 = true;
								}
								if ((b & 2) == 2)
								{
									if ((b & 1) == 1)
									{
										if ((float)i < num3 / 2f & (float)j < num3 / 2f)
										{
											solidBrush.Color = this.QRColorBigMark1;
										}
										else if ((float)i >= num3 / 2f & (float)j < num3 / 2f)
										{
											solidBrush.Color = this.QRColorBigMark3;
										}
										else
										{
											solidBrush.Color = this.QRColorBigMark2;
										}
									}
									else if ((float)i < num3 / 2f & (float)j < num3 / 2f)
									{
										solidBrush.Color = this.QRBackColorBigMark1;
									}
									else if ((float)i >= num3 / 2f & (float)j < num3 / 2f)
									{
										solidBrush.Color = this.QRBackColorBigMark3;
									}
									else
									{
										solidBrush.Color = this.QRBackColorBigMark2;
									}
								}
								if ((b & 16) == 16)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorTimingPattern;
									}
									else
									{
										solidBrush.Color = this.QRBackColorTimingPattern;
									}
								}
								if ((b & 4) == 4)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorSmallMark;
									}
									else
									{
										solidBrush.Color = this.QRBackColorSmallMark;
									}
								}
								if (b == 8)
								{
									if ((float)i < num3 / 2f & (float)j < num3 / 2f)
									{
										solidBrush.Color = this.QRColorBigMarkBorder1;
									}
									else if ((float)i >= num3 / 2f & (float)j < num3 / 2f)
									{
										solidBrush.Color = this.QRColorBigMarkBorder3;
									}
									else
									{
										solidBrush.Color = this.QRColorBigMarkBorder2;
									}
								}
								if ((b & 32) == 32)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorVersionInformation;
									}
									else
									{
										solidBrush.Color = this.QRBackColorVersionInformation;
									}
								}
								if ((b & 64) == 64)
								{
									if ((b & 1) == 1)
									{
										solidBrush.Color = this.QRColorFormatInformation;
									}
									else
									{
										solidBrush.Color = this.QRBackColorFormatInformation;
									}
								}
								if (!flag2 | !flag)
								{
									if (solidBrush.Color.ToArgb() == -1)
									{
										text += Conversions.ToString(0);
									}
									else
									{
										text += Conversions.ToString(1);
									}
								}
							}
						}
					}
				}
			}
			return text;
		}

		private void method_14(string string_8, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			if (string_8.Length > 0)
			{
				byte[,] array = this.method_32(string_8);
				float num = (float)array.GetLength(0);
				if (num > 0f)
				{
					int num2 = this.method_15(num, float_4, float_5);
					if (num2 > 0)
					{
						this.qrcode_write_barcode(string_8, float_2, float_3, num2, graphics_0);
					}
				}
			}
		}

		private int method_15(float float_2, float float_3, float float_4)
		{
			if (float_3 <= 0f | float_4 <= 0f)
			{
				return 0;
			}
			float num;
			if (float_3 > float_4)
			{
				num = float_4;
			}
			else
			{
				num = float_3;
			}
			int num2 = checked((int)Math.Round(Math.Round(unchecked((double)(num / (float_2 + (float)this.int_9 * 2f)) / (Math.Abs(Math.Sin((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) + Math.Abs(Math.Cos((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931))) - 0.5))));
			if (num2 <= 0)
			{
				return 0;
			}
			return num2;
		}

		private byte method_16(byte[,] byte_9, int int_10)
		{
			int length = byte_9.GetLength(0);
			int[] array = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int[] array2 = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int[] array3 = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int[] array4 = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int[] array5 = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int[] array6 = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int num = 0;
			int num2 = 0;
			int[] array7 = new int[9];
			int[] array8 = new int[9];
			bool[] array9 = new bool[9];
			bool[] array10 = new bool[9];
			checked
			{
				int num3 = length - 1;
				for (int i = 0; i <= num3; i++)
				{
					int num4 = 0;
					do
					{
						array7[num4] = 0;
						array8[num4] = 0;
						array9[num4] = false;
						array10[num4] = false;
						num4++;
					}
					while (num4 <= 7);
					int num5 = length - 1;
					for (int j = 0; j <= num5; j++)
					{
						if (j > 0 & i > 0)
						{
							num = (int)(byte_9[j, i] & byte_9[j - 1, i] & byte_9[j, i - 1] & byte_9[j - 1, i - 1]);
							num2 = (int)(byte_9[j, i] | byte_9[j - 1, i] | byte_9[j, i - 1] | byte_9[j - 1, i - 1]);
						}
						int num6 = 0;
						do
						{
							unchecked
							{
								array7[num6] = ((array7[num6] & 63) << 1 | (int)((byte)((uint)byte_9[j, i] >> (num6 & 7 & 7)) & 1));
								array8[num6] = ((array8[num6] & 63) << 1 | (int)((byte)((uint)byte_9[i, j] >> (num6 & 7 & 7)) & 1));
							}
							if (((int)byte_9[j, i] & 1 << num6) != 0)
							{
								int num7 = num6;
								int[] array11 = array4;
								int num8 = num7;
								array11[num8] = array4[num8] + 1;
							}
							if (array7[num6] == Convert.ToInt32("1011101", 2))
							{
								int num7 = num6;
								array3[num7] += 40;
							}
							if (array8[num6] == Convert.ToInt32("1011101", 2))
							{
								int num7 = num6;
								array3[num7] += 40;
							}
							if (j > 0 & i > 0)
							{
								if ((num & 1) != 0 | (num2 & 1) == 0)
								{
									int num7 = num6;
									array2[num7] += 3;
								}
								num >>= 1;
								num2 >>= 1;
							}
							if ((array7[num6] & 31) == 0 | (array7[num6] & 31) == 31)
							{
								if (j > 3)
								{
									if (array9[num6])
									{
										int num7 = num6;
										int[] array12 = array;
										int num8 = num7;
										array12[num8] = array[num8] + 1;
									}
									else
									{
										int num7 = num6;
										array[num7] += 3;
										array9[num6] = true;
									}
								}
							}
							else
							{
								array9[num6] = false;
							}
							if ((array8[num6] & 31) == 0 | (array8[num6] & 31) == 31)
							{
								if (j > 3)
								{
									if (array10[num6])
									{
										int num7 = num6;
										int[] array13 = array;
										int num8 = num7;
										array13[num8] = array[num8] + 1;
									}
									else
									{
										int num7 = num6;
										array[num7] += 3;
										array10[num6] = true;
									}
								}
							}
							else
							{
								array10[num6] = false;
							}
							num6++;
						}
						while (num6 <= 7);
					}
				}
				int num9 = 0;
				byte result = 0;
				int[] array14 = new int[]
				{
					90,
					80,
					70,
					60,
					50,
					40,
					30,
					20,
					10,
					0,
					0,
					10,
					20,
					30,
					40,
					50,
					60,
					70,
					80,
					90,
					90
				};
				int num10 = 0;
				do
				{
					array5[num10] = array14[(int)Math.Round(Math.Round(Conversion.Int((double)(20 * array4[num10]) / (double)int_10)))];
					array6[num10] = array[num10] + array2[num10] + array3[num10] + array5[num10];
					num10++;
				}
				while (num10 <= 7);
				int num11 = 0;
				do
				{
					if (array6[num11] < num9 | num11 == 0)
					{
						result = (byte)num11;
						num9 = array6[num11];
					}
					num11++;
				}
				while (num11 <= 7);
				return result;
			}
		}

		private void method_17()
		{
			this.qreccrates_0 = DotNetBarcode.QRECCRates.Medium15Percent;
			this.qrtextTypes_1 = DotNetBarcode.QRTextTypes.Automatic;
			this.qrversions_1 = DotNetBarcode.QRVersions.Automatic;
			int[,] array = new int[4, 40];
			array[0, 0] = 19;
			array[0, 1] = 34;
			array[0, 2] = 55;
			array[0, 3] = 80;
			array[0, 4] = 108;
			array[0, 5] = 68;
			array[0, 6] = 78;
			array[0, 7] = 97;
			array[0, 8] = 116;
			array[0, 9] = 68;
			array[0, 10] = 81;
			array[0, 11] = 92;
			array[0, 12] = 107;
			array[0, 13] = 115;
			array[0, 14] = 87;
			array[0, 15] = 98;
			array[0, 16] = 107;
			array[0, 17] = 120;
			array[0, 18] = 113;
			array[0, 19] = 107;
			array[0, 20] = 116;
			array[0, 21] = 111;
			array[0, 22] = 121;
			array[0, 23] = 117;
			array[0, 24] = 106;
			array[0, 25] = 114;
			array[0, 26] = 122;
			array[0, 27] = 117;
			array[0, 28] = 116;
			array[0, 29] = 115;
			array[0, 30] = 115;
			array[0, 31] = 115;
			array[0, 32] = 115;
			array[0, 33] = 115;
			array[0, 34] = 121;
			array[0, 35] = 121;
			array[0, 36] = 122;
			array[0, 37] = 122;
			array[0, 38] = 117;
			array[0, 39] = 118;
			array[1, 0] = 16;
			array[1, 1] = 28;
			array[1, 2] = 44;
			array[1, 3] = 32;
			array[1, 4] = 43;
			array[1, 5] = 27;
			array[1, 6] = 31;
			array[1, 7] = 38;
			array[1, 8] = 36;
			array[1, 9] = 43;
			array[1, 10] = 50;
			array[1, 11] = 36;
			array[1, 12] = 37;
			array[1, 13] = 40;
			array[1, 14] = 41;
			array[1, 15] = 45;
			array[1, 16] = 46;
			array[1, 17] = 43;
			array[1, 18] = 44;
			array[1, 19] = 41;
			array[1, 20] = 42;
			array[1, 21] = 46;
			array[1, 22] = 47;
			array[1, 23] = 45;
			array[1, 24] = 47;
			array[1, 25] = 46;
			array[1, 26] = 45;
			array[1, 27] = 45;
			array[1, 28] = 45;
			array[1, 29] = 47;
			array[1, 30] = 46;
			array[1, 31] = 46;
			array[1, 32] = 46;
			array[1, 33] = 46;
			array[1, 34] = 47;
			array[1, 35] = 47;
			array[1, 36] = 46;
			array[1, 37] = 46;
			array[1, 38] = 47;
			array[1, 39] = 47;
			array[2, 0] = 13;
			array[2, 1] = 22;
			array[2, 2] = 17;
			array[2, 3] = 24;
			array[2, 4] = 15;
			array[2, 5] = 19;
			array[2, 6] = 14;
			array[2, 7] = 18;
			array[2, 8] = 16;
			array[2, 9] = 19;
			array[2, 10] = 22;
			array[2, 11] = 20;
			array[2, 12] = 20;
			array[2, 13] = 16;
			array[2, 14] = 24;
			array[2, 15] = 19;
			array[2, 16] = 22;
			array[2, 17] = 22;
			array[2, 18] = 21;
			array[2, 19] = 24;
			array[2, 20] = 22;
			array[2, 21] = 24;
			array[2, 22] = 24;
			array[2, 23] = 24;
			array[2, 24] = 24;
			array[2, 25] = 22;
			array[2, 26] = 23;
			array[2, 27] = 24;
			array[2, 28] = 23;
			array[2, 29] = 24;
			array[2, 30] = 24;
			array[2, 31] = 24;
			array[2, 32] = 24;
			array[2, 33] = 24;
			array[2, 34] = 24;
			array[2, 35] = 24;
			array[2, 36] = 24;
			array[2, 37] = 24;
			array[2, 38] = 24;
			array[2, 39] = 24;
			array[3, 0] = 9;
			array[3, 1] = 16;
			array[3, 2] = 13;
			array[3, 3] = 9;
			array[3, 4] = 11;
			array[3, 5] = 15;
			array[3, 6] = 13;
			array[3, 7] = 14;
			array[3, 8] = 12;
			array[3, 9] = 15;
			array[3, 10] = 12;
			array[3, 11] = 14;
			array[3, 12] = 11;
			array[3, 13] = 12;
			array[3, 14] = 12;
			array[3, 15] = 15;
			array[3, 16] = 14;
			array[3, 17] = 14;
			array[3, 18] = 13;
			array[3, 19] = 15;
			array[3, 20] = 16;
			array[3, 21] = 13;
			array[3, 22] = 15;
			array[3, 23] = 16;
			array[3, 24] = 15;
			array[3, 25] = 16;
			array[3, 26] = 15;
			array[3, 27] = 15;
			array[3, 28] = 15;
			array[3, 29] = 15;
			array[3, 30] = 15;
			array[3, 31] = 15;
			array[3, 32] = 15;
			array[3, 33] = 16;
			array[3, 34] = 15;
			array[3, 35] = 15;
			array[3, 36] = 15;
			array[3, 37] = 15;
			array[3, 38] = 15;
			array[3, 39] = 15;
			this.int_0 = array;
			array = new int[4, 40];
			array[0, 0] = 0;
			array[0, 1] = 0;
			array[0, 2] = 0;
			array[0, 3] = 0;
			array[0, 4] = 0;
			array[0, 5] = 0;
			array[0, 6] = 0;
			array[0, 7] = 0;
			array[0, 8] = 0;
			array[0, 9] = 2;
			array[0, 10] = 0;
			array[0, 11] = 2;
			array[0, 12] = 0;
			array[0, 13] = 1;
			array[0, 14] = 1;
			array[0, 15] = 1;
			array[0, 16] = 5;
			array[0, 17] = 1;
			array[0, 18] = 4;
			array[0, 19] = 5;
			array[0, 20] = 4;
			array[0, 21] = 7;
			array[0, 22] = 5;
			array[0, 23] = 4;
			array[0, 24] = 4;
			array[0, 25] = 2;
			array[0, 26] = 4;
			array[0, 27] = 10;
			array[0, 28] = 7;
			array[0, 29] = 10;
			array[0, 30] = 3;
			array[0, 31] = 0;
			array[0, 32] = 1;
			array[0, 33] = 6;
			array[0, 34] = 7;
			array[0, 35] = 14;
			array[0, 36] = 4;
			array[0, 37] = 18;
			array[0, 38] = 4;
			array[0, 39] = 6;
			array[1, 0] = 0;
			array[1, 1] = 0;
			array[1, 2] = 0;
			array[1, 3] = 0;
			array[1, 4] = 0;
			array[1, 5] = 0;
			array[1, 6] = 0;
			array[1, 7] = 2;
			array[1, 8] = 2;
			array[1, 9] = 1;
			array[1, 10] = 4;
			array[1, 11] = 2;
			array[1, 12] = 1;
			array[1, 13] = 5;
			array[1, 14] = 5;
			array[1, 15] = 3;
			array[1, 16] = 1;
			array[1, 17] = 4;
			array[1, 18] = 11;
			array[1, 19] = 13;
			array[1, 20] = 0;
			array[1, 21] = 0;
			array[1, 22] = 14;
			array[1, 23] = 14;
			array[1, 24] = 13;
			array[1, 25] = 4;
			array[1, 26] = 3;
			array[1, 27] = 23;
			array[1, 28] = 7;
			array[1, 29] = 10;
			array[1, 30] = 29;
			array[1, 31] = 23;
			array[1, 32] = 21;
			array[1, 33] = 23;
			array[1, 34] = 26;
			array[1, 35] = 34;
			array[1, 36] = 14;
			array[1, 37] = 32;
			array[1, 38] = 7;
			array[1, 39] = 31;
			array[2, 0] = 0;
			array[2, 1] = 0;
			array[2, 2] = 0;
			array[2, 3] = 0;
			array[2, 4] = 2;
			array[2, 5] = 0;
			array[2, 6] = 4;
			array[2, 7] = 2;
			array[2, 8] = 4;
			array[2, 9] = 2;
			array[2, 10] = 4;
			array[2, 11] = 6;
			array[2, 12] = 4;
			array[2, 13] = 5;
			array[2, 14] = 7;
			array[2, 15] = 2;
			array[2, 16] = 15;
			array[2, 17] = 1;
			array[2, 18] = 4;
			array[2, 19] = 5;
			array[2, 20] = 6;
			array[2, 21] = 16;
			array[2, 22] = 14;
			array[2, 23] = 16;
			array[2, 24] = 22;
			array[2, 25] = 6;
			array[2, 26] = 26;
			array[2, 27] = 31;
			array[2, 28] = 37;
			array[2, 29] = 25;
			array[2, 30] = 1;
			array[2, 31] = 35;
			array[2, 32] = 19;
			array[2, 33] = 7;
			array[2, 34] = 14;
			array[2, 35] = 10;
			array[2, 36] = 10;
			array[2, 37] = 14;
			array[2, 38] = 22;
			array[2, 39] = 34;
			array[3, 0] = 0;
			array[3, 1] = 0;
			array[3, 2] = 0;
			array[3, 3] = 0;
			array[3, 4] = 2;
			array[3, 5] = 0;
			array[3, 6] = 1;
			array[3, 7] = 2;
			array[3, 8] = 4;
			array[3, 9] = 2;
			array[3, 10] = 8;
			array[3, 11] = 4;
			array[3, 12] = 4;
			array[3, 13] = 5;
			array[3, 14] = 7;
			array[3, 15] = 13;
			array[3, 16] = 17;
			array[3, 17] = 19;
			array[3, 18] = 16;
			array[3, 19] = 10;
			array[3, 20] = 6;
			array[3, 21] = 0;
			array[3, 22] = 14;
			array[3, 23] = 2;
			array[3, 24] = 13;
			array[3, 25] = 4;
			array[3, 26] = 28;
			array[3, 27] = 31;
			array[3, 28] = 26;
			array[3, 29] = 25;
			array[3, 30] = 28;
			array[3, 31] = 35;
			array[3, 32] = 46;
			array[3, 33] = 1;
			array[3, 34] = 41;
			array[3, 35] = 64;
			array[3, 36] = 46;
			array[3, 37] = 32;
			array[3, 38] = 67;
			array[3, 39] = 61;
			this.int_2 = array;
			array = new int[4, 40];
			array[0, 0] = 7;
			array[0, 1] = 10;
			array[0, 2] = 15;
			array[0, 3] = 20;
			array[0, 4] = 26;
			array[0, 5] = 18;
			array[0, 6] = 20;
			array[0, 7] = 24;
			array[0, 8] = 30;
			array[0, 9] = 18;
			array[0, 10] = 20;
			array[0, 11] = 24;
			array[0, 12] = 26;
			array[0, 13] = 30;
			array[0, 14] = 22;
			array[0, 15] = 24;
			array[0, 16] = 28;
			array[0, 17] = 30;
			array[0, 18] = 28;
			array[0, 19] = 28;
			array[0, 20] = 28;
			array[0, 21] = 28;
			array[0, 22] = 30;
			array[0, 23] = 30;
			array[0, 24] = 26;
			array[0, 25] = 28;
			array[0, 26] = 30;
			array[0, 27] = 30;
			array[0, 28] = 30;
			array[0, 29] = 30;
			array[0, 30] = 30;
			array[0, 31] = 30;
			array[0, 32] = 30;
			array[0, 33] = 30;
			array[0, 34] = 30;
			array[0, 35] = 30;
			array[0, 36] = 30;
			array[0, 37] = 30;
			array[0, 38] = 30;
			array[0, 39] = 30;
			array[1, 0] = 10;
			array[1, 1] = 16;
			array[1, 2] = 26;
			array[1, 3] = 18;
			array[1, 4] = 24;
			array[1, 5] = 16;
			array[1, 6] = 18;
			array[1, 7] = 22;
			array[1, 8] = 22;
			array[1, 9] = 26;
			array[1, 10] = 30;
			array[1, 11] = 22;
			array[1, 12] = 22;
			array[1, 13] = 24;
			array[1, 14] = 24;
			array[1, 15] = 28;
			array[1, 16] = 28;
			array[1, 17] = 26;
			array[1, 18] = 26;
			array[1, 19] = 26;
			array[1, 20] = 26;
			array[1, 21] = 28;
			array[1, 22] = 28;
			array[1, 23] = 28;
			array[1, 24] = 28;
			array[1, 25] = 28;
			array[1, 26] = 28;
			array[1, 27] = 28;
			array[1, 28] = 28;
			array[1, 29] = 28;
			array[1, 30] = 28;
			array[1, 31] = 28;
			array[1, 32] = 28;
			array[1, 33] = 28;
			array[1, 34] = 28;
			array[1, 35] = 28;
			array[1, 36] = 28;
			array[1, 37] = 28;
			array[1, 38] = 28;
			array[1, 39] = 28;
			array[2, 0] = 13;
			array[2, 1] = 22;
			array[2, 2] = 18;
			array[2, 3] = 26;
			array[2, 4] = 18;
			array[2, 5] = 24;
			array[2, 6] = 18;
			array[2, 7] = 22;
			array[2, 8] = 20;
			array[2, 9] = 24;
			array[2, 10] = 28;
			array[2, 11] = 26;
			array[2, 12] = 24;
			array[2, 13] = 20;
			array[2, 14] = 30;
			array[2, 15] = 24;
			array[2, 16] = 28;
			array[2, 17] = 28;
			array[2, 18] = 26;
			array[2, 19] = 30;
			array[2, 20] = 28;
			array[2, 21] = 30;
			array[2, 22] = 30;
			array[2, 23] = 30;
			array[2, 24] = 30;
			array[2, 25] = 28;
			array[2, 26] = 30;
			array[2, 27] = 30;
			array[2, 28] = 30;
			array[2, 29] = 30;
			array[2, 30] = 30;
			array[2, 31] = 30;
			array[2, 32] = 30;
			array[2, 33] = 30;
			array[2, 34] = 30;
			array[2, 35] = 30;
			array[2, 36] = 30;
			array[2, 37] = 30;
			array[2, 38] = 30;
			array[2, 39] = 30;
			array[3, 0] = 17;
			array[3, 1] = 28;
			array[3, 2] = 22;
			array[3, 3] = 16;
			array[3, 4] = 22;
			array[3, 5] = 28;
			array[3, 6] = 26;
			array[3, 7] = 26;
			array[3, 8] = 24;
			array[3, 9] = 28;
			array[3, 10] = 24;
			array[3, 11] = 28;
			array[3, 12] = 22;
			array[3, 13] = 24;
			array[3, 14] = 24;
			array[3, 15] = 30;
			array[3, 16] = 28;
			array[3, 17] = 28;
			array[3, 18] = 26;
			array[3, 19] = 28;
			array[3, 20] = 30;
			array[3, 21] = 24;
			array[3, 22] = 30;
			array[3, 23] = 30;
			array[3, 24] = 30;
			array[3, 25] = 30;
			array[3, 26] = 30;
			array[3, 27] = 30;
			array[3, 28] = 30;
			array[3, 29] = 30;
			array[3, 30] = 30;
			array[3, 31] = 30;
			array[3, 32] = 30;
			array[3, 33] = 30;
			array[3, 34] = 30;
			array[3, 35] = 30;
			array[3, 36] = 30;
			array[3, 37] = 30;
			array[3, 38] = 30;
			array[3, 39] = 30;
			this.int_1 = array;
			array = new int[4, 40];
			array[0, 0] = 1;
			array[0, 1] = 1;
			array[0, 2] = 1;
			array[0, 3] = 1;
			array[0, 4] = 1;
			array[0, 5] = 2;
			array[0, 6] = 2;
			array[0, 7] = 2;
			array[0, 8] = 2;
			array[0, 9] = 4;
			array[0, 10] = 4;
			array[0, 11] = 4;
			array[0, 12] = 4;
			array[0, 13] = 4;
			array[0, 14] = 6;
			array[0, 15] = 6;
			array[0, 16] = 6;
			array[0, 17] = 6;
			array[0, 18] = 7;
			array[0, 19] = 8;
			array[0, 20] = 8;
			array[0, 21] = 9;
			array[0, 22] = 9;
			array[0, 23] = 10;
			array[0, 24] = 12;
			array[0, 25] = 12;
			array[0, 26] = 12;
			array[0, 27] = 13;
			array[0, 28] = 14;
			array[0, 29] = 15;
			array[0, 30] = 16;
			array[0, 31] = 17;
			array[0, 32] = 18;
			array[0, 33] = 19;
			array[0, 34] = 19;
			array[0, 35] = 20;
			array[0, 36] = 21;
			array[0, 37] = 22;
			array[0, 38] = 24;
			array[0, 39] = 25;
			array[1, 0] = 1;
			array[1, 1] = 1;
			array[1, 2] = 1;
			array[1, 3] = 2;
			array[1, 4] = 2;
			array[1, 5] = 4;
			array[1, 6] = 4;
			array[1, 7] = 4;
			array[1, 8] = 5;
			array[1, 9] = 5;
			array[1, 10] = 5;
			array[1, 11] = 8;
			array[1, 12] = 9;
			array[1, 13] = 9;
			array[1, 14] = 10;
			array[1, 15] = 10;
			array[1, 16] = 11;
			array[1, 17] = 13;
			array[1, 18] = 14;
			array[1, 19] = 16;
			array[1, 20] = 17;
			array[1, 21] = 17;
			array[1, 22] = 18;
			array[1, 23] = 20;
			array[1, 24] = 21;
			array[1, 25] = 23;
			array[1, 26] = 25;
			array[1, 27] = 26;
			array[1, 28] = 28;
			array[1, 29] = 29;
			array[1, 30] = 31;
			array[1, 31] = 33;
			array[1, 32] = 35;
			array[1, 33] = 37;
			array[1, 34] = 38;
			array[1, 35] = 40;
			array[1, 36] = 43;
			array[1, 37] = 45;
			array[1, 38] = 47;
			array[1, 39] = 49;
			array[2, 0] = 1;
			array[2, 1] = 1;
			array[2, 2] = 2;
			array[2, 3] = 2;
			array[2, 4] = 4;
			array[2, 5] = 4;
			array[2, 6] = 6;
			array[2, 7] = 6;
			array[2, 8] = 8;
			array[2, 9] = 8;
			array[2, 10] = 8;
			array[2, 11] = 10;
			array[2, 12] = 12;
			array[2, 13] = 16;
			array[2, 14] = 12;
			array[2, 15] = 17;
			array[2, 16] = 16;
			array[2, 17] = 18;
			array[2, 18] = 21;
			array[2, 19] = 20;
			array[2, 20] = 23;
			array[2, 21] = 23;
			array[2, 22] = 25;
			array[2, 23] = 27;
			array[2, 24] = 29;
			array[2, 25] = 34;
			array[2, 26] = 34;
			array[2, 27] = 35;
			array[2, 28] = 38;
			array[2, 29] = 40;
			array[2, 30] = 43;
			array[2, 31] = 45;
			array[2, 32] = 48;
			array[2, 33] = 51;
			array[2, 34] = 53;
			array[2, 35] = 56;
			array[2, 36] = 59;
			array[2, 37] = 62;
			array[2, 38] = 65;
			array[2, 39] = 68;
			array[3, 0] = 1;
			array[3, 1] = 1;
			array[3, 2] = 2;
			array[3, 3] = 4;
			array[3, 4] = 4;
			array[3, 5] = 4;
			array[3, 6] = 5;
			array[3, 7] = 6;
			array[3, 8] = 8;
			array[3, 9] = 8;
			array[3, 10] = 11;
			array[3, 11] = 11;
			array[3, 12] = 16;
			array[3, 13] = 16;
			array[3, 14] = 18;
			array[3, 15] = 16;
			array[3, 16] = 19;
			array[3, 17] = 21;
			array[3, 18] = 25;
			array[3, 19] = 25;
			array[3, 20] = 25;
			array[3, 21] = 34;
			array[3, 22] = 30;
			array[3, 23] = 32;
			array[3, 24] = 35;
			array[3, 25] = 37;
			array[3, 26] = 40;
			array[3, 27] = 42;
			array[3, 28] = 45;
			array[3, 29] = 48;
			array[3, 30] = 51;
			array[3, 31] = 54;
			array[3, 32] = 57;
			array[3, 33] = 60;
			array[3, 34] = 63;
			array[3, 35] = 66;
			array[3, 36] = 70;
			array[3, 37] = 74;
			array[3, 38] = 77;
			array[3, 39] = 81;
			this.int_3 = array;
		}

		private int method_18(int int_10, int int_11, int int_12)
		{
			return checked(int_10 + int_11 * (int_12 + 1));
		}

		private byte[] method_19(int[] int_10, byte[] byte_9, int int_11)
		{
			checked
			{
				byte[] array = new byte[int_11 - 1 + 1 - 1 + 1];
				int num = byte_9.Length;
				int i = 0;
				int num2 = 8;
				int num3 = 0;
				int num4 = num - 1;
				for (int j = 0; j <= num4; j++)
				{
					num3 += (int)byte_9[j];
				}
				int num5 = (int)Math.Round(Math.Round(unchecked(Conversion.Int((double)(checked(num3 - 1)) / 8.0) + 1.0 - 1.0)));
				for (int k = 0; k <= num5; k++)
				{
					array[k] = 0;
				}
				int num6 = num - 1;
				for (int l = 0; l <= num6; l++)
				{
					int num7 = int_10[l];
					int num8 = (int)byte_9[l];
					bool flag = true;
					if (num8 == 0)
					{
						break;
					}
					while (flag)
					{
						if (num2 > num8)
						{
							array[i] = (byte)((int)(unchecked((byte)(array[i] << (num8 & 7 & 7)))) | num7);
							num2 -= num8;
							flag = false;
						}
						else
						{
							num8 -= num2;
							array[i] = (byte)((int)(unchecked((byte)(array[i] << (num2 & 7 & 7)))) | num7 >> num8);
							if (num8 == 0)
							{
								flag = false;
							}
							else
							{
								num7 &= (1 << num8) - 1;
								flag = true;
							}
							i++;
							num2 = 8;
						}
					}
				}
				if (num2 != 8)
				{
					array[i] = unchecked((byte)(array[i] << (num2 & 7 & 7)));
				}
				else
				{
					i--;
				}
				if (i < int_11 - 1)
				{
					bool flag = true;
					while (i < int_11 - 1)
					{
						i++;
						if (flag)
						{
							array[i] = 236;
						}
						else
						{
							array[i] = 17;
						}
						flag = !flag;
					}
				}
				return array;
			}
		}

		private byte[] method_20(byte[] byte_9, byte[] byte_10)
		{
			byte[] array;
			byte[] array2;
			if (byte_9.Length > byte_10.Length)
			{
				array = (byte[])byte_9.Clone();
				array2 = (byte[])byte_10.Clone();
			}
			else
			{
				array = (byte[])byte_10.Clone();
				array2 = (byte[])byte_9.Clone();
			}
			int num = array.Length;
			int num2 = array2.Length;
			checked
			{
				byte[] array3 = new byte[num + 1 - 1 + 1];
				int num3 = num - 1;
				for (int i = 0; i <= num3; i++)
				{
					if (i < num2)
					{
						array3[i] = (array[i] ^ array2[i]);
					}
					else
					{
						array3[i] = array[i];
					}
				}
				return array3;
			}
		}

		private byte[] method_21(int int_10)
		{
			byte[] array = new byte[16];
			int num = 0;
			checked
			{
				do
				{
					array[num] = 8;
					num++;
				}
				while (num <= 6);
				int num2 = 0;
				do
				{
					array[num2 + 7] = (byte)(4 * int_10 + 9 + num2);
					num2++;
				}
				while (num2 <= 7);
				return array;
			}
		}

		private byte[] method_22(int int_10)
		{
			byte[] array = new byte[16];
			int num = 0;
			checked
			{
				do
				{
					array[num + 7] = 8;
					num++;
				}
				while (num <= 7);
				int num2 = 0;
				do
				{
					array[num2] = (byte)(4 * int_10 + 16 - num2);
					num2++;
				}
				while (num2 <= 6);
				return array;
			}
		}

		private bool method_23(int int_10, int int_11, int int_12)
		{
			checked
			{
				switch (int_10)
				{
				case 0:
					return (int_12 + int_11) % 2 == 0;
				case 1:
					return int_12 % 2 == 0;
				case 2:
					return int_11 % 3 == 0;
				case 3:
					return (int_12 + int_11) % 3 == 0;
				case 4:
					return unchecked(Conversion.Int((double)int_12 / 2.0) + Conversion.Int((double)int_11 / 3.0)) % 2.0 == 0.0;
				case 5:
					return int_12 * int_11 % 2 + int_12 * int_11 % 3 == 0;
				case 6:
					return (int_12 * int_11 % 2 + int_12 * int_11 % 3) % 2 == 0;
				case 7:
					return (int_12 * int_11 % 3 + (int_12 + int_11) % 2) % 2 == 0;
				default:
				{
					bool result;
					return result;
				}
				}
			}
		}

		private int method_24(int int_10, int int_11)
		{
			int num = 0;
			checked
			{
				if (this.method_23(0, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 1)));
				}
				if (this.method_23(1, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 2)));
				}
				if (this.method_23(2, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 4)));
				}
				if (this.method_23(3, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 8)));
				}
				if (this.method_23(4, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 16)));
				}
				if (this.method_23(5, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 32)));
				}
				if (this.method_23(6, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 64)));
				}
				if (this.method_23(7, int_10, int_11))
				{
					num = (int)Math.Round(Math.Round((double)(num + 128)));
				}
				return num;
			}
		}

		private byte[] method_25(int int_10)
		{
			checked
			{
				int num = int_10 * 4 + 17;
				byte[] array = new byte[]
				{
					3,
					(byte)(num - 1 - 3)
				};
				byte[] array2;
				switch (int_10)
				{
				case 1:
					array2 = new byte[]
					{
						6
					};
					break;
				case 2:
					array2 = new byte[]
					{
						6,
						18
					};
					break;
				case 3:
					array2 = new byte[]
					{
						6,
						22
					};
					break;
				case 4:
					array2 = new byte[]
					{
						6,
						26
					};
					break;
				case 5:
					array2 = new byte[]
					{
						6,
						30
					};
					break;
				case 6:
					array2 = new byte[]
					{
						6,
						34
					};
					break;
				case 7:
					array2 = new byte[]
					{
						6,
						22,
						38
					};
					break;
				case 8:
					array2 = new byte[]
					{
						6,
						24,
						42
					};
					break;
				case 9:
					array2 = new byte[]
					{
						6,
						26,
						46
					};
					break;
				case 10:
					array2 = new byte[]
					{
						6,
						28,
						50
					};
					break;
				case 11:
					array2 = new byte[]
					{
						6,
						30,
						54
					};
					break;
				case 12:
					array2 = new byte[]
					{
						6,
						32,
						58
					};
					break;
				case 13:
					array2 = new byte[]
					{
						6,
						34,
						62
					};
					break;
				case 14:
					array2 = new byte[]
					{
						6,
						26,
						46,
						66
					};
					break;
				case 15:
					array2 = new byte[]
					{
						6,
						26,
						48,
						70
					};
					break;
				case 16:
					array2 = new byte[]
					{
						6,
						26,
						50,
						74
					};
					break;
				case 17:
					array2 = new byte[]
					{
						6,
						30,
						54,
						78
					};
					break;
				case 18:
					array2 = new byte[]
					{
						6,
						30,
						56,
						82
					};
					break;
				case 19:
					array2 = new byte[]
					{
						6,
						30,
						58,
						86
					};
					break;
				case 20:
					array2 = new byte[]
					{
						6,
						34,
						62,
						90
					};
					break;
				case 21:
					array2 = new byte[]
					{
						6,
						28,
						50,
						72,
						94
					};
					break;
				case 22:
					array2 = new byte[]
					{
						6,
						26,
						50,
						74,
						98
					};
					break;
				case 23:
					array2 = new byte[]
					{
						6,
						30,
						54,
						78,
						102
					};
					break;
				case 24:
					array2 = new byte[]
					{
						6,
						28,
						54,
						80,
						106
					};
					break;
				case 25:
					array2 = new byte[]
					{
						6,
						32,
						58,
						84,
						110
					};
					break;
				case 26:
					array2 = new byte[]
					{
						6,
						30,
						58,
						86,
						114
					};
					break;
				case 27:
					array2 = new byte[]
					{
						6,
						34,
						62,
						90,
						118
					};
					break;
				case 28:
					array2 = new byte[]
					{
						6,
						26,
						50,
						74,
						98,
						122
					};
					break;
				case 29:
					array2 = new byte[]
					{
						6,
						30,
						54,
						78,
						102,
						126
					};
					break;
				case 30:
					array2 = new byte[]
					{
						6,
						26,
						52,
						78,
						104,
						130
					};
					break;
				case 31:
					array2 = new byte[]
					{
						6,
						30,
						56,
						82,
						108,
						134
					};
					break;
				case 32:
					array2 = new byte[]
					{
						6,
						34,
						60,
						86,
						112,
						138
					};
					break;
				case 33:
					array2 = new byte[]
					{
						6,
						30,
						58,
						86,
						114,
						142
					};
					break;
				case 34:
					array2 = new byte[]
					{
						6,
						34,
						62,
						90,
						118,
						146
					};
					break;
				case 35:
					array2 = new byte[]
					{
						6,
						30,
						54,
						78,
						102,
						126,
						150
					};
					break;
				case 36:
					array2 = new byte[]
					{
						6,
						24,
						50,
						76,
						102,
						128,
						154
					};
					break;
				case 37:
					array2 = new byte[]
					{
						6,
						28,
						54,
						80,
						106,
						132,
						158
					};
					break;
				case 38:
					array2 = new byte[]
					{
						6,
						32,
						58,
						84,
						110,
						136,
						162
					};
					break;
				case 39:
					array2 = new byte[]
					{
						6,
						26,
						54,
						82,
						110,
						138,
						166
					};
					break;
				case 40:
					array2 = new byte[]
					{
						6,
						30,
						58,
						86,
						114,
						142,
						170
					};
					break;
				default:
					array2 = new byte[]
					{
						0
					};
					break;
				}
				int num2 = num * (num + 1);
				byte[] array3 = new byte[num2 - 1 + 1 - 1 + 1];
				int num3 = array3.Length - 1;
				for (int i = 0; i <= num3; i++)
				{
					array3[i] = 0;
				}
				int int_11;
				int int_12;
				this.method_18(int_11, int_12, num);
				int num4 = array.Length - 1;
				for (int j = 0; j <= num4; j++)
				{
					int num5 = array.Length - 1;
					for (int k = 0; k <= num5; k++)
					{
						int num6 = (int)array[j];
						int num7 = (int)array[k];
						if (!(j == array.Length - 1 & k == array.Length - 1))
						{
							array3[this.method_18(num6 + 1, num7 - 1, num)] = 3;
							array3[this.method_18(num6, num7 - 1, num)] = 3;
							array3[this.method_18(num6 - 1, num7 - 1, num)] = 3;
							array3[this.method_18(num6 + 1, num7, num)] = 3;
							array3[this.method_18(num6, num7, num)] = 3;
							array3[this.method_18(num6 - 1, num7, num)] = 3;
							array3[this.method_18(num6 + 1, num7 + 1, num)] = 3;
							array3[this.method_18(num6, num7 + 1, num)] = 3;
							array3[this.method_18(num6 - 1, num7 + 1, num)] = 3;
							array3[this.method_18(num6 + 3, num7 - 3, num)] = 3;
							array3[this.method_18(num6 + 2, num7 - 3, num)] = 3;
							array3[this.method_18(num6 + 1, num7 - 3, num)] = 3;
							array3[this.method_18(num6, num7 - 3, num)] = 3;
							array3[this.method_18(num6 - 1, num7 - 3, num)] = 3;
							array3[this.method_18(num6 - 2, num7 - 3, num)] = 3;
							array3[this.method_18(num6 - 3, num7 - 3, num)] = 3;
							array3[this.method_18(num6 + 3, num7 + 3, num)] = 3;
							array3[this.method_18(num6 + 2, num7 + 3, num)] = 3;
							array3[this.method_18(num6 + 1, num7 + 3, num)] = 3;
							array3[this.method_18(num6, num7 + 3, num)] = 3;
							array3[this.method_18(num6 - 1, num7 + 3, num)] = 3;
							array3[this.method_18(num6 - 2, num7 + 3, num)] = 3;
							array3[this.method_18(num6 - 3, num7 + 3, num)] = 3;
							array3[this.method_18(num6 - 3, num7 - 2, num)] = 3;
							array3[this.method_18(num6 - 3, num7 - 1, num)] = 3;
							array3[this.method_18(num6 - 3, num7, num)] = 3;
							array3[this.method_18(num6 - 3, num7 + 1, num)] = 3;
							array3[this.method_18(num6 - 3, num7 + 2, num)] = 3;
							array3[this.method_18(num6 + 3, num7 - 2, num)] = 3;
							array3[this.method_18(num6 + 3, num7 - 1, num)] = 3;
							array3[this.method_18(num6 + 3, num7, num)] = 3;
							array3[this.method_18(num6 + 3, num7 + 1, num)] = 3;
							array3[this.method_18(num6 + 3, num7 + 2, num)] = 3;
							array3[this.method_18(num6 + 2, num7 - 2, num)] = 2;
							array3[this.method_18(num6 + 1, num7 - 2, num)] = 2;
							array3[this.method_18(num6, num7 - 2, num)] = 2;
							array3[this.method_18(num6 - 1, num7 - 2, num)] = 2;
							array3[this.method_18(num6 - 2, num7 - 2, num)] = 2;
							array3[this.method_18(num6 + 2, num7 + 2, num)] = 2;
							array3[this.method_18(num6 + 1, num7 + 2, num)] = 2;
							array3[this.method_18(num6, num7 + 2, num)] = 2;
							array3[this.method_18(num6 - 1, num7 + 2, num)] = 2;
							array3[this.method_18(num6 - 2, num7 + 2, num)] = 2;
							array3[this.method_18(num6 - 2, num7 - 1, num)] = 2;
							array3[this.method_18(num6 - 2, num7, num)] = 2;
							array3[this.method_18(num6 - 2, num7 + 1, num)] = 2;
							array3[this.method_18(num6 + 2, num7 - 1, num)] = 2;
							array3[this.method_18(num6 + 2, num7, num)] = 2;
							array3[this.method_18(num6 + 2, num7 + 1, num)] = 2;
							if (j == 0 & k == 0)
							{
								int num8 = -3;
								do
								{
									array3[this.method_18(num6 + 4, num7 + num8, num)] = 8;
									num8++;
								}
								while (num8 <= 4);
								int num9 = -3;
								do
								{
									array3[this.method_18(num6 + num9, num7 + 4, num)] = 8;
									num9++;
								}
								while (num9 <= 4);
							}
							if (j == 0 & k == 1)
							{
								int num10 = -4;
								do
								{
									array3[this.method_18(num6 + 4, num7 + num10, num)] = 8;
									num10++;
								}
								while (num10 <= 3);
								int num11 = -3;
								do
								{
									array3[this.method_18(num6 - num11, num7 - 4, num)] = 8;
									num11++;
								}
								while (num11 <= 4);
							}
							if (j == 1 & k == 0)
							{
								int num12 = -3;
								do
								{
									array3[this.method_18(num6 - 4, num7 + num12, num)] = 8;
									num12++;
								}
								while (num12 <= 4);
								int num13 = -4;
								do
								{
									array3[this.method_18(num6 + num13, num7 + 4, num)] = 8;
									num13++;
								}
								while (num13 <= 3);
							}
						}
					}
				}
				int num14 = array2.Length - 1;
				for (int l = 0; l <= num14; l++)
				{
					int num15 = array2.Length - 1;
					for (int m = 0; m <= num15; m++)
					{
						int num16 = (int)array2[l];
						int num17 = (int)array2[m];
						if (!((l == 0 & m == 0) | (l == 0 & m == array2.Length - 1) | (m == 0 & l == array2.Length - 1)))
						{
							array3[this.method_18(num16, num17, num)] = 5;
							array3[this.method_18(num16 + 2, num17 - 2, num)] = 5;
							array3[this.method_18(num16 + 1, num17 - 2, num)] = 5;
							array3[this.method_18(num16, num17 - 2, num)] = 5;
							array3[this.method_18(num16 - 1, num17 - 2, num)] = 5;
							array3[this.method_18(num16 - 2, num17 - 2, num)] = 5;
							array3[this.method_18(num16 + 2, num17 + 2, num)] = 5;
							array3[this.method_18(num16 + 1, num17 + 2, num)] = 5;
							array3[this.method_18(num16, num17 + 2, num)] = 5;
							array3[this.method_18(num16 - 1, num17 + 2, num)] = 5;
							array3[this.method_18(num16 - 2, num17 + 2, num)] = 5;
							array3[this.method_18(num16 - 2, num17 - 1, num)] = 5;
							array3[this.method_18(num16 - 2, num17, num)] = 5;
							array3[this.method_18(num16 - 2, num17 + 1, num)] = 5;
							array3[this.method_18(num16 + 2, num17 - 1, num)] = 5;
							array3[this.method_18(num16 + 2, num17, num)] = 5;
							array3[this.method_18(num16 + 2, num17 + 1, num)] = 5;
							array3[this.method_18(num16 + 1, num17 - 1, num)] = 4;
							array3[this.method_18(num16, num17 - 1, num)] = 4;
							array3[this.method_18(num16 - 1, num17 - 1, num)] = 4;
							array3[this.method_18(num16 + 1, num17 + 1, num)] = 4;
							array3[this.method_18(num16, num17 + 1, num)] = 4;
							array3[this.method_18(num16 - 1, num17 + 1, num)] = 4;
							array3[this.method_18(num16 - 1, num17, num)] = 4;
							array3[this.method_18(num16 + 1, num17, num)] = 4;
						}
					}
				}
				int num18 = num - 9;
				for (int n = 8; n <= num18; n += 2)
				{
					array3[this.method_18(n, 6, num)] = (17 | array3[this.method_18(n, 6, num)]);
					array3[this.method_18(6, n, num)] = (17 | array3[this.method_18(6, n, num)]);
					if (n != num - 9)
					{
						array3[this.method_18(n + 1, 6, num)] = (16 | array3[this.method_18(n + 1, 6, num)]);
						array3[this.method_18(6, n + 1, num)] = (16 | array3[this.method_18(6, n + 1, num)]);
					}
				}
				array3[this.method_18(8, num - 8, num)] = 129;
				if (int_10 >= 7)
				{
					int[] array4 = new int[34];
					array4 = new int[]
					{
						31892,
						34236,
						39577,
						42195,
						48118,
						51042,
						55367,
						58893,
						63784,
						68472,
						70749,
						76311,
						79154,
						84390,
						87683,
						92361,
						96236,
						102084,
						102881,
						110507,
						110734,
						117786,
						119615,
						126325,
						127568,
						133589,
						136944,
						141498,
						145311,
						150283,
						152622,
						158308,
						161089,
						167017
					};
					int num19 = array4[int_10 - 7];
					int num20 = 0;
					do
					{
						int num21 = 0;
						do
						{
							int num22 = num19 & 1;
							if (num22 == 1)
							{
								array3[this.method_18(num - 11 + num21, num20, num)] = (33 | array3[this.method_18(num - 11 + num21, num20, num)]);
								array3[this.method_18(num20, num - 11 + num21, num)] = (33 | array3[this.method_18(num20, num - 11 + num21, num)]);
							}
							else
							{
								array3[this.method_18(num - 11 + num21, num20, num)] = (32 | array3[this.method_18(num - 11 + num21, num20, num)]);
								array3[this.method_18(num20, num - 11 + num21, num)] = (32 | array3[this.method_18(num20, num - 11 + num21, num)]);
							}
							num19 >>= 1;
							num21++;
						}
						while (num21 <= 2);
						num20++;
					}
					while (num20 <= 5);
				}
				this.byte_6 = this.method_21((int)this.qrversions_0);
				this.byte_7 = this.method_22((int)this.qrversions_0);
				int num23 = 0;
				do
				{
					array3[this.method_18((int)this.byte_4[num23], (int)this.byte_5[num23], num)] = (64 | array3[this.method_18((int)this.byte_4[num23], (int)this.byte_5[num23], num)]);
					array3[this.method_18((int)this.byte_6[num23], (int)this.byte_7[num23], num)] = (64 | array3[this.method_18((int)this.byte_6[num23], (int)this.byte_7[num23], num)]);
					num23++;
				}
				while (num23 <= 14);
				return array3;
			}
		}

		private byte[] method_26(byte[] byte_9, byte byte_10, int int_10, int int_11)
		{
			checked
			{
				byte[,] array = new byte[256, (int)(byte_10 - 1 + 1 - 1 + 1)];
				int num = this.int_0[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				int num2 = this.int_2[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				float num3 = (float)this.int_1[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				int num4 = this.int_3[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				byte[] array2 = new byte[]
				{
					1,
					2,
					4,
					8,
					16,
					32,
					64,
					128,
					29,
					58,
					116,
					232,
					205,
					135,
					19,
					38,
					76,
					152,
					45,
					90,
					180,
					117,
					234,
					201,
					143,
					3,
					6,
					12,
					24,
					48,
					96,
					192,
					157,
					39,
					78,
					156,
					37,
					74,
					148,
					53,
					106,
					212,
					181,
					119,
					238,
					193,
					159,
					35,
					70,
					140,
					5,
					10,
					20,
					40,
					80,
					160,
					93,
					186,
					105,
					210,
					185,
					111,
					222,
					161,
					95,
					190,
					97,
					194,
					153,
					47,
					94,
					188,
					101,
					202,
					137,
					15,
					30,
					60,
					120,
					240,
					253,
					231,
					211,
					187,
					107,
					214,
					177,
					127,
					254,
					225,
					223,
					163,
					91,
					182,
					113,
					226,
					217,
					175,
					67,
					134,
					17,
					34,
					68,
					136,
					13,
					26,
					52,
					104,
					208,
					189,
					103,
					206,
					129,
					31,
					62,
					124,
					248,
					237,
					199,
					147,
					59,
					118,
					236,
					197,
					151,
					51,
					102,
					204,
					133,
					23,
					46,
					92,
					184,
					109,
					218,
					169,
					79,
					158,
					33,
					66,
					132,
					21,
					42,
					84,
					168,
					77,
					154,
					41,
					82,
					164,
					85,
					170,
					73,
					146,
					57,
					114,
					228,
					213,
					183,
					115,
					230,
					209,
					191,
					99,
					198,
					145,
					63,
					126,
					252,
					229,
					215,
					179,
					123,
					246,
					241,
					byte.MaxValue,
					227,
					219,
					171,
					75,
					150,
					49,
					98,
					196,
					149,
					55,
					110,
					220,
					165,
					87,
					174,
					65,
					130,
					25,
					50,
					100,
					200,
					141,
					7,
					14,
					28,
					56,
					112,
					224,
					221,
					167,
					83,
					166,
					81,
					162,
					89,
					178,
					121,
					242,
					249,
					239,
					195,
					155,
					43,
					86,
					172,
					69,
					138,
					9,
					18,
					36,
					72,
					144,
					61,
					122,
					244,
					245,
					247,
					243,
					251,
					235,
					203,
					139,
					11,
					22,
					44,
					88,
					176,
					125,
					250,
					233,
					207,
					131,
					27,
					54,
					108,
					216,
					173,
					71,
					142,
					1
				};
				byte[] array3 = new byte[]
				{
					0,
					0,
					1,
					25,
					2,
					50,
					26,
					198,
					3,
					223,
					51,
					238,
					27,
					104,
					199,
					75,
					4,
					100,
					224,
					14,
					52,
					141,
					239,
					129,
					28,
					193,
					105,
					248,
					200,
					8,
					76,
					113,
					5,
					138,
					101,
					47,
					225,
					36,
					15,
					33,
					53,
					147,
					142,
					218,
					240,
					18,
					130,
					69,
					29,
					181,
					194,
					125,
					106,
					39,
					249,
					185,
					201,
					154,
					9,
					120,
					77,
					228,
					114,
					166,
					6,
					191,
					139,
					98,
					102,
					221,
					48,
					253,
					226,
					152,
					37,
					179,
					16,
					145,
					34,
					136,
					54,
					208,
					148,
					206,
					143,
					150,
					219,
					189,
					241,
					210,
					19,
					92,
					131,
					56,
					70,
					64,
					30,
					66,
					182,
					163,
					195,
					72,
					126,
					110,
					107,
					58,
					40,
					84,
					250,
					133,
					186,
					61,
					202,
					94,
					155,
					159,
					10,
					21,
					121,
					43,
					78,
					212,
					229,
					172,
					115,
					243,
					167,
					87,
					7,
					112,
					192,
					247,
					140,
					128,
					99,
					13,
					103,
					74,
					222,
					237,
					49,
					197,
					254,
					24,
					227,
					165,
					153,
					119,
					38,
					184,
					180,
					124,
					17,
					68,
					146,
					217,
					35,
					32,
					137,
					46,
					55,
					63,
					209,
					91,
					149,
					188,
					207,
					205,
					144,
					135,
					151,
					178,
					220,
					252,
					190,
					97,
					242,
					86,
					211,
					171,
					20,
					42,
					93,
					158,
					132,
					60,
					57,
					83,
					71,
					109,
					65,
					162,
					31,
					45,
					67,
					216,
					183,
					123,
					164,
					118,
					196,
					23,
					73,
					236,
					127,
					12,
					111,
					246,
					108,
					161,
					59,
					82,
					41,
					157,
					85,
					170,
					251,
					96,
					134,
					177,
					187,
					204,
					62,
					90,
					203,
					89,
					95,
					176,
					156,
					169,
					160,
					81,
					11,
					245,
					22,
					235,
					122,
					117,
					44,
					215,
					79,
					174,
					213,
					233,
					230,
					231,
					173,
					232,
					116,
					214,
					244,
					234,
					168,
					80,
					88,
					175
				};
				byte[] array4 = new byte[(int)(byte_10 - 1 + 1 - 1 + 1)];
				switch (byte_10)
				{
				case 7:
					array4 = new byte[]
					{
						127,
						122,
						154,
						164,
						11,
						68,
						117
					};
					break;
				case 10:
					array4 = new byte[]
					{
						216,
						194,
						159,
						111,
						199,
						94,
						95,
						113,
						157,
						193
					};
					break;
				case 13:
					array4 = new byte[]
					{
						137,
						73,
						227,
						17,
						177,
						17,
						52,
						13,
						46,
						43,
						83,
						132,
						120
					};
					break;
				case 15:
					array4 = new byte[]
					{
						29,
						196,
						111,
						163,
						112,
						74,
						10,
						105,
						105,
						139,
						132,
						151,
						32,
						134,
						26
					};
					break;
				case 16:
					array4 = new byte[]
					{
						59,
						13,
						104,
						189,
						68,
						209,
						30,
						8,
						163,
						65,
						41,
						229,
						98,
						50,
						36,
						59
					};
					break;
				case 17:
					array4 = new byte[]
					{
						119,
						66,
						83,
						120,
						119,
						22,
						197,
						83,
						249,
						41,
						143,
						134,
						85,
						53,
						125,
						99,
						79
					};
					break;
				case 18:
					array4 = new byte[]
					{
						239,
						251,
						183,
						113,
						149,
						175,
						199,
						215,
						240,
						220,
						73,
						82,
						173,
						75,
						32,
						67,
						217,
						146
					};
					break;
				case 20:
					array4 = new byte[]
					{
						152,
						185,
						240,
						5,
						111,
						99,
						6,
						220,
						112,
						150,
						69,
						36,
						187,
						22,
						228,
						198,
						121,
						121,
						165,
						174
					};
					break;
				case 22:
					array4 = new byte[]
					{
						89,
						179,
						131,
						176,
						182,
						244,
						19,
						189,
						69,
						40,
						28,
						137,
						29,
						123,
						67,
						253,
						86,
						218,
						230,
						26,
						145,
						245
					};
					break;
				case 24:
					array4 = new byte[]
					{
						122,
						118,
						169,
						70,
						178,
						237,
						216,
						102,
						115,
						150,
						229,
						73,
						130,
						72,
						61,
						43,
						206,
						1,
						237,
						247,
						127,
						217,
						144,
						117
					};
					break;
				case 26:
					array4 = new byte[]
					{
						246,
						51,
						183,
						4,
						136,
						98,
						199,
						152,
						77,
						56,
						206,
						24,
						145,
						40,
						209,
						117,
						233,
						42,
						135,
						68,
						70,
						144,
						146,
						77,
						43,
						94
					};
					break;
				case 28:
					array4 = new byte[]
					{
						252,
						9,
						28,
						13,
						18,
						251,
						208,
						150,
						103,
						174,
						100,
						41,
						167,
						12,
						247,
						56,
						117,
						119,
						233,
						127,
						181,
						100,
						121,
						147,
						176,
						74,
						58,
						197
					};
					break;
				case 30:
					array4 = new byte[]
					{
						212,
						246,
						77,
						73,
						195,
						192,
						75,
						98,
						5,
						70,
						103,
						177,
						22,
						217,
						138,
						51,
						181,
						246,
						72,
						25,
						18,
						46,
						228,
						74,
						216,
						195,
						11,
						106,
						130,
						150
					};
					break;
				}
				int num5 = array4.Length - 1;
				for (int i = 0; i <= num5; i++)
				{
					int num6 = (int)array4[i];
					num6 = (int)array3[num6];
					int num7 = 0;
					do
					{
						int num8 = (num6 + (int)array3[num7]) % 255;
						int num9 = (int)array2[num8];
						array[num7, i] = (byte)num9;
						num7++;
					}
					while (num7 <= 255);
				}
				int j = 0;
				int k = 0;
				this.byte_8 = new byte[num4 - 1 + 1 - 1 + 1];
				int num10 = num4 - 1;
				for (int l = 0; l <= num10; l++)
				{
					if (l >= num4 - num2)
					{
						this.byte_8[l] = (byte)Math.Round(Math.Round((double)(unchecked((float)num + num3 + 1f))));
					}
					else
					{
						this.byte_8[l] = (byte)Math.Round(Math.Round((double)(unchecked((float)num + num3))));
					}
				}
				byte[][] array5 = new byte[this.byte_8.Length - 1 + 1 - 1 + 1][];
				byte[] array6 = new byte[int_11 - 1 + 1 - 1 + 1];
				Array.Copy(byte_9, 0, array6, 0, byte_9.Length);
				for (int m = 0; m < this.byte_8.Length; m++)
				{
					int num11 = this.byte_8.Length - 1;
					for (int n = 0; n <= num11; n++)
					{
						byte[] array7 = new byte[(int)(unchecked(this.byte_8[m] - byte_10) + 1 - 1 + 1)];
						array5[n] = array7;
					}
				}
				for (int m = 0; m < int_10; m++)
				{
					array5[k][j] = byte_9[m];
					j++;
					if (j >= (int)(unchecked(this.byte_8[k] - byte_10)))
					{
						j = 0;
						k++;
					}
				}
				for (k = 0; k < this.byte_8.Length; k++)
				{
					byte[] array8 = (byte[])array5[k].Clone();
					int num12 = (int)this.byte_8[k];
					int num13 = num12 - (int)byte_10;
					for (j = num13; j > 0; j--)
					{
						byte b = array8[0];
						if (b != 0)
						{
							byte[] array9 = new byte[array8.Length - 1 + 1 - 1 + 1];
							Array.Copy(array8, 1, array9, 0, array8.Length - 1);
							byte[] array10 = new byte[array.GetLength(1) + 1 - 1 + 1];
							int num14 = array.GetLength(1) - 1;
							for (int num15 = 0; num15 <= num14; num15++)
							{
								array10[num15] = array[(int)b, num15];
							}
							array8 = this.method_20(array9, array10);
						}
						else if ((int)byte_10 < array8.Length)
						{
							byte[] array11 = new byte[array8.Length - 1 - 1 + 1 - 1 + 1];
							Array.Copy(array8, 1, array11, 0, array8.Length - 1);
							array8 = (byte[])array11.Clone();
						}
						else
						{
							byte[] array12 = new byte[(int)(byte_10 - 1 + 1 - 1 + 1)];
							Array.Copy(array8, 1, array12, 0, array8.Length - 1);
							array12[(int)(byte_10 - 1)] = 0;
							array8 = (byte[])array12.Clone();
						}
					}
					Array.Copy(array8, 0, array6, byte_9.Length + k * (int)byte_10, (int)byte_10);
				}
				return array6;
			}
		}

		private void method_27(string string_8)
		{
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			int length = string_8.Length;
			checked
			{
				int num = length - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!this.method_3(string_8.Substring(i, 1)))
					{
						flag = false;
					}
					if (!this.method_1(string_8.Substring(i, 1)))
					{
						flag2 = false;
					}
					if (!this.method_2(string_8.Substring(i, 1)))
					{
						flag3 = false;
					}
				}
				if (flag)
				{
					switch (length % 3)
					{
					case 0:
						this.int_8 = (int)Math.Round(Math.Round(unchecked(Conversion.Int((double)length / 3.0) * 10.0)));
						break;
					case 1:
						this.int_8 = (int)Math.Round(Math.Round(unchecked(Conversion.Int((double)length / 3.0) * 10.0 + 4.0)));
						break;
					case 2:
						this.int_8 = (int)Math.Round(Math.Round(unchecked(Conversion.Int((double)length / 3.0) * 10.0 + 7.0)));
						break;
					}
				}
				else
				{
					this.int_8 = 0;
				}
				if (flag2)
				{
					switch (length % 2)
					{
					case 0:
						this.int_4 = (int)Math.Round(Math.Round(unchecked(Conversion.Int((double)length / 2.0) * 11.0)));
						break;
					case 1:
						this.int_4 = (int)Math.Round(Math.Round(unchecked(Conversion.Int((double)length / 2.0) * 11.0 + 6.0)));
						break;
					}
				}
				else
				{
					this.int_4 = 0;
				}
				if (flag3)
				{
					this.int_6 = length * 13;
				}
				else
				{
					this.int_6 = 0;
				}
				Encoding encoding = Encoding.GetEncoding("Shift_JIS");
				byte[] bytes = encoding.GetBytes(string_8);
				this.int_5 = bytes.Length * 8;
			}
		}

		private byte[] method_28(byte[] byte_9, byte[] byte_10, int int_10)
		{
			sbyte[,] array = new sbyte[8, 8];
			array[0, 0] = 0;
			array[0, 1] = 1;
			array[0, 2] = 0;
			array[0, 3] = 1;
			array[0, 4] = 0;
			array[0, 5] = 1;
			array[0, 6] = 0;
			array[0, 7] = 1;
			array[1, 0] = 0;
			array[1, 1] = 1;
			array[1, 2] = 0;
			array[1, 3] = 1;
			array[1, 4] = 0;
			array[1, 5] = 1;
			array[1, 6] = 2;
			array[1, 7] = 3;
			array[2, 0] = 0;
			array[2, 1] = 1;
			array[2, 2] = 0;
			array[2, 3] = 1;
			array[2, 4] = 2;
			array[2, 5] = 3;
			array[2, 6] = 2;
			array[2, 7] = 3;
			array[3, 0] = 0;
			array[3, 1] = 1;
			array[3, 2] = 0;
			array[3, 3] = 1;
			array[3, 4] = 1;
			array[3, 5] = 1;
			array[3, 6] = 1;
			array[3, 7] = 1;
			array[4, 0] = 0;
			array[4, 1] = 0;
			array[4, 2] = 0;
			array[4, 3] = 0;
			array[4, 4] = 0;
			array[4, 5] = 1;
			array[4, 6] = 0;
			array[4, 7] = 1;
			array[5, 0] = 0;
			array[5, 1] = 1;
			array[5, 2] = 0;
			array[5, 3] = 1;
			array[5, 4] = 0;
			array[5, 5] = 1;
			array[5, 6] = 1;
			array[5, 7] = 1;
			array[6, 0] = 0;
			array[6, 1] = 0;
			array[6, 2] = 0;
			array[6, 3] = 1;
			array[6, 4] = 0;
			array[6, 5] = 1;
			array[6, 6] = 0;
			array[6, 7] = 1;
			array[7, 0] = 0;
			array[7, 1] = 0;
			array[7, 2] = 0;
			array[7, 3] = 0;
			array[7, 4] = 0;
			array[7, 5] = 0;
			array[7, 6] = 0;
			array[7, 7] = 0;
			sbyte[,] array2 = array;
			checked
			{
				byte[] array3 = new byte[int_10 - 1 + 1 - 1 + 1];
				int num = 0;
				int i = 0;
				int num2 = byte_9.Length - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = (int)byte_9[j];
					if (num3 == 15 || num3 == 0)
					{
						IL_49F:
						while (i < int_10)
						{
							array3[i] = byte_10[num];
							i++;
							num++;
						}
						return array3;
					}
					int num4 = (int)Math.Round(Math.Round(Conversion.Int((double)num3 / 16.0)));
					int num5 = num3 - num4 * 16;
					if (num5 == 15)
					{
						array3[i] = byte_10[num];
						array3[i + 1] = byte_10[num + 1];
						array3[i + 2] = byte_10[num + 2];
						array3[i + 3] = byte_10[num + 3];
						array3[i + 4] = byte_10[num + 4];
						array3[i + 5] = byte_10[num + 5];
						array3[i + 6] = byte_10[num + 6];
						array3[i + 7] = byte_10[num + 7];
						i += 8;
						num += 8;
					}
					else
					{
						array3[i] = byte_10[num];
						if (num5 >= 8)
						{
							array3[i + 1] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 1])));
							array3[i + 2] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 2])));
							array3[i + 3] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 3])));
							array3[i + 4] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 4])));
							array3[i + 5] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 5])));
							array3[i + 6] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 6])));
							array3[i + 7] = (byte)((short)(unchecked(byte_10[num] - (byte)array2[checked(num5 - 8), 7])));
						}
						else
						{
							array3[i + 1] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 1])));
							array3[i + 2] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 2])));
							array3[i + 3] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 3])));
							array3[i + 4] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 4])));
							array3[i + 5] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 5])));
							array3[i + 6] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 6])));
							array3[i + 7] = (byte)((short)(unchecked(byte_10[num] + (byte)array2[checked(num5 - 1), 7])));
						}
						i += 8;
						num++;
					}
				}
				goto IL_49F;
			}
		}

		private DotNetBarcode.QRTextTypes method_29(string string_8)
		{
			int num = this.QRInquireBinaryBits;
			DotNetBarcode.QRTextTypes result = DotNetBarcode.QRTextTypes.Binary;
			if (this.QRInquireNumericBits > 0 && num > this.QRInquireNumericBits)
			{
				num = this.QRInquireNumericBits;
				result = DotNetBarcode.QRTextTypes.Numeric;
			}
			if (this.QRInquireAlphaNumericBits > 0 && num > this.QRInquireAlphaNumericBits)
			{
				num = this.QRInquireAlphaNumericBits;
				result = DotNetBarcode.QRTextTypes.AlphaNumeric;
			}
			if (this.QRInquireKanjiBits > 0 && num > this.QRInquireKanjiBits)
			{
				num = this.QRInquireKanjiBits;
				result = DotNetBarcode.QRTextTypes.Kanji;
			}
			if (this.qrtextTypes_1 == DotNetBarcode.QRTextTypes.Numeric && this.QRInquireNumericBits > 0)
			{
				return DotNetBarcode.QRTextTypes.Numeric;
			}
			if (this.qrtextTypes_1 == DotNetBarcode.QRTextTypes.AlphaNumeric && this.QRInquireAlphaNumericBits > 0)
			{
				return DotNetBarcode.QRTextTypes.AlphaNumeric;
			}
			if (this.qrtextTypes_1 == DotNetBarcode.QRTextTypes.Kanji && this.QRInquireKanjiBits > 0)
			{
				return DotNetBarcode.QRTextTypes.Kanji;
			}
			if (this.qrtextTypes_1 == DotNetBarcode.QRTextTypes.Binary && this.QRInquireBinaryBits > 0)
			{
				return DotNetBarcode.QRTextTypes.Binary;
			}
			this.qrtextTypes_0 = result;
			return result;
		}

		private byte[] method_30(byte[] byte_9)
		{
			checked
			{
				int num = this.int_0[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				int num2 = this.int_2[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				float num3 = (float)this.int_1[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				int num4 = this.int_3[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
				byte[] array = new byte[byte_9.Length - 1 + 1 - 1 + 1];
				int i = 0;
				int[] array2 = new int[129];
				int num5 = 0;
				int num6 = num - 1;
				for (int j = 0; j <= num6; j++)
				{
					int num7 = num4 - 1;
					for (int k = 0; k <= num7; k++)
					{
						int num8;
						if (k > num4 - num2)
						{
							num8 = k - (num4 - num2);
							if (j == 0)
							{
								array2[num5] = j + k * num + num8 - 1;
								num5++;
							}
						}
						else
						{
							num8 = 0;
						}
						int num9 = 0;
						do
						{
							int num10 = (j + k * num + num8) * 8 + num9;
							array[num10] = byte_9[i];
							i++;
							num9++;
						}
						while (num9 <= 7);
					}
				}
				if (num2 > 0)
				{
					array2[num5] = num * num4 + num2 - 1;
					num5++;
				}
				int num11 = num5 - 1;
				for (int l = 0; l <= num11; l++)
				{
					int num12 = 0;
					do
					{
						int num10 = array2[l] * 8 + num12;
						array[num10] = byte_9[i];
						i++;
						num12++;
					}
					while (num12 <= 7);
				}
				int num13 = i;
				int num14 = (int)Math.Round(Math.Round((double)(unchecked(num3 - 1f))));
				for (int m = 0; m <= num14; m++)
				{
					int num15 = num4 - 1;
					for (int n = 0; n <= num15; n++)
					{
						int num16 = 0;
						do
						{
							int num10 = (int)Math.Round(Math.Round((double)(unchecked((float)num13 + ((float)m + (float)n * num3) * 8f + (float)num16))));
							array[num10] = byte_9[i];
							i++;
							num16++;
						}
						while (num16 <= 7);
					}
				}
				while (i <= byte_9.Length - 1)
				{
					array[i] = byte_9[i];
					i++;
				}
				return array;
			}
		}

		public void QRCopyToClipboard(string code, int pPixelSize)
		{
			this.method_32(code);
			float num = (float)this.QRInquireModuleSize;
			checked
			{
				if (num > 0f && pPixelSize > 0)
				{
					int num2 = (int)Math.Round(Math.Round((double)(unchecked((float)pPixelSize * (num + (float)(checked(this.int_9 * 2)))))));
					float num3 = (float)(unchecked((double)num2 * (Math.Abs(Math.Sin((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) + Math.Abs(Math.Cos((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)))));
					Bitmap bitmap = new Bitmap((int)Math.Round(Math.Round((double)num3)), (int)Math.Round(Math.Round((double)num3)), PixelFormat.Format24bppRgb);
					Graphics graphics = Graphics.FromImage(bitmap);
					SolidBrush brush = new SolidBrush(Color.White);
					graphics.FillRectangle(brush, 0, 0, (int)Math.Round(Math.Round((double)num3)), (int)Math.Round(Math.Round((double)num3)));
					this.method_34(code, 0f, 0f, pPixelSize, graphics);
					Clipboard.SetDataObject(bitmap);
				}
			}
		}

		private byte method_31(string string_8)
		{
			checked
			{
				if (Conversions.ToDouble(string_8) >= 48.0 & Conversions.ToDouble(string_8) < 58.0)
				{
					return (byte)Math.Round(Math.Round(unchecked(Conversions.ToDouble(string_8) - 48.0)));
				}
				if (Conversions.ToDouble(string_8) >= 65.0 & Conversions.ToDouble(string_8) < 91.0)
				{
					return (byte)Math.Round(Math.Round(unchecked(Conversions.ToDouble(string_8) - 55.0)));
				}
				if (Operators.CompareString(string_8, Conversions.ToString(32), false) == 0)
				{
					return 36;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(36), false) == 0)
				{
					return 37;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(37), false) == 0)
				{
					return 38;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(42), false) == 0)
				{
					return 39;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(43), false) == 0)
				{
					return 40;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(45), false) == 0)
				{
					return 41;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(46), false) == 0)
				{
					return 42;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(47), false) == 0)
				{
					return 43;
				}
				if (Operators.CompareString(string_8, Conversions.ToString(58), false) == 0)
				{
					return 44;
				}
				return 0;
			}
		}

		private byte[,] method_32(string string_8)
		{
			int[] array = new int[]
			{
				0,
				26,
				44,
				70,
				100,
				134,
				172,
				196,
				242,
				292,
				346,
				404,
				466,
				532,
				581,
				655,
				733,
				815,
				901,
				991,
				1085,
				1156,
				1258,
				1364,
				1474,
				1588,
				1706,
				1828,
				1921,
				2051,
				2185,
				2323,
				2465,
				2611,
				2761,
				2876,
				3034,
				3196,
				3362,
				3532,
				3706
			};
			int[] array2 = new int[]
			{
				0,
				0,
				7,
				7,
				7,
				7,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				3,
				3,
				3,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				3,
				3,
				3,
				3,
				3,
				3,
				3,
				0,
				0,
				0,
				0,
				0,
				0
			};
			int[,] array3 = new int[4, 41];
			array3[0, 0] = 0;
			array3[0, 1] = 152;
			array3[0, 2] = 272;
			array3[0, 3] = 440;
			array3[0, 4] = 640;
			array3[0, 5] = 864;
			array3[0, 6] = 1088;
			array3[0, 7] = 1248;
			array3[0, 8] = 1552;
			array3[0, 9] = 1856;
			array3[0, 10] = 2192;
			array3[0, 11] = 2592;
			array3[0, 12] = 2960;
			array3[0, 13] = 3424;
			array3[0, 14] = 3688;
			array3[0, 15] = 4184;
			array3[0, 16] = 4712;
			array3[0, 17] = 5176;
			array3[0, 18] = 5768;
			array3[0, 19] = 6360;
			array3[0, 20] = 6888;
			array3[0, 21] = 7456;
			array3[0, 22] = 8048;
			array3[0, 23] = 8752;
			array3[0, 24] = 9392;
			array3[0, 25] = 10208;
			array3[0, 26] = 10960;
			array3[0, 27] = 11744;
			array3[0, 28] = 12248;
			array3[0, 29] = 13048;
			array3[0, 30] = 13880;
			array3[0, 31] = 14744;
			array3[0, 32] = 15640;
			array3[0, 33] = 16568;
			array3[0, 34] = 17528;
			array3[0, 35] = 18448;
			array3[0, 36] = 19472;
			array3[0, 37] = 20528;
			array3[0, 38] = 21616;
			array3[0, 39] = 22496;
			array3[0, 40] = 23648;
			array3[1, 0] = 0;
			array3[1, 1] = 128;
			array3[1, 2] = 224;
			array3[1, 3] = 352;
			array3[1, 4] = 512;
			array3[1, 5] = 688;
			array3[1, 6] = 864;
			array3[1, 7] = 992;
			array3[1, 8] = 1232;
			array3[1, 9] = 1456;
			array3[1, 10] = 1728;
			array3[1, 11] = 2032;
			array3[1, 12] = 2320;
			array3[1, 13] = 2672;
			array3[1, 14] = 2920;
			array3[1, 15] = 3320;
			array3[1, 16] = 3624;
			array3[1, 17] = 4056;
			array3[1, 18] = 4504;
			array3[1, 19] = 5016;
			array3[1, 20] = 5352;
			array3[1, 21] = 5712;
			array3[1, 22] = 6256;
			array3[1, 23] = 6880;
			array3[1, 24] = 7312;
			array3[1, 25] = 8000;
			array3[1, 26] = 8496;
			array3[1, 27] = 9024;
			array3[1, 28] = 9544;
			array3[1, 29] = 10136;
			array3[1, 30] = 10984;
			array3[1, 31] = 11640;
			array3[1, 32] = 12328;
			array3[1, 33] = 13048;
			array3[1, 34] = 13800;
			array3[1, 35] = 14496;
			array3[1, 36] = 15312;
			array3[1, 37] = 15936;
			array3[1, 38] = 16816;
			array3[1, 39] = 17728;
			array3[1, 40] = 18672;
			array3[2, 0] = 0;
			array3[2, 1] = 104;
			array3[2, 2] = 176;
			array3[2, 3] = 272;
			array3[2, 4] = 384;
			array3[2, 5] = 496;
			array3[2, 6] = 608;
			array3[2, 7] = 704;
			array3[2, 8] = 880;
			array3[2, 9] = 1056;
			array3[2, 10] = 1232;
			array3[2, 11] = 1440;
			array3[2, 12] = 1648;
			array3[2, 13] = 1952;
			array3[2, 14] = 2088;
			array3[2, 15] = 2360;
			array3[2, 16] = 2600;
			array3[2, 17] = 2936;
			array3[2, 18] = 3176;
			array3[2, 19] = 3560;
			array3[2, 20] = 3880;
			array3[2, 21] = 4096;
			array3[2, 22] = 4544;
			array3[2, 23] = 4912;
			array3[2, 24] = 5312;
			array3[2, 25] = 5744;
			array3[2, 26] = 6032;
			array3[2, 27] = 6464;
			array3[2, 28] = 6968;
			array3[2, 29] = 7288;
			array3[2, 30] = 7880;
			array3[2, 31] = 8264;
			array3[2, 32] = 8920;
			array3[2, 33] = 9368;
			array3[2, 34] = 9848;
			array3[2, 35] = 10288;
			array3[2, 36] = 10832;
			array3[2, 37] = 11408;
			array3[2, 38] = 12016;
			array3[2, 39] = 12656;
			array3[2, 40] = 13328;
			array3[3, 0] = 0;
			array3[3, 1] = 72;
			array3[3, 2] = 128;
			array3[3, 3] = 208;
			array3[3, 4] = 288;
			array3[3, 5] = 368;
			array3[3, 6] = 480;
			array3[3, 7] = 528;
			array3[3, 8] = 688;
			array3[3, 9] = 800;
			array3[3, 10] = 976;
			array3[3, 11] = 1120;
			array3[3, 12] = 1264;
			array3[3, 13] = 1440;
			array3[3, 14] = 1576;
			array3[3, 15] = 1784;
			array3[3, 16] = 2024;
			array3[3, 17] = 2264;
			array3[3, 18] = 2504;
			array3[3, 19] = 2728;
			array3[3, 20] = 3080;
			array3[3, 21] = 3248;
			array3[3, 22] = 3536;
			array3[3, 23] = 3712;
			array3[3, 24] = 4112;
			array3[3, 25] = 4304;
			array3[3, 26] = 4768;
			array3[3, 27] = 5024;
			array3[3, 28] = 5288;
			array3[3, 29] = 5608;
			array3[3, 30] = 5960;
			array3[3, 31] = 6344;
			array3[3, 32] = 6760;
			array3[3, 33] = 7208;
			array3[3, 34] = 7688;
			array3[3, 35] = 7888;
			array3[3, 36] = 8432;
			array3[3, 37] = 8768;
			array3[3, 38] = 9136;
			array3[3, 39] = 9776;
			array3[3, 40] = 10208;
			int[,] array4 = array3;
			string[] array5 = new string[]
			{
				"111011111000100",
				"111001011110011",
				"111110110101010",
				"111100010011101",
				"110011000101111",
				"110001100011000",
				"110110001000001",
				"110100101110110",
				"101010000010010",
				"101000100100101",
				"101111001111100",
				"101101101001011",
				"100010111111001",
				"100000011001110",
				"100111110010111",
				"100101010100000",
				"011010101011111",
				"011000001101000",
				"011111100110001",
				"011101000000110",
				"010010010110100",
				"010000110000011",
				"010111011011010",
				"010101111101101",
				"001011010001001",
				"001001110111110",
				"001110011100111",
				"001100111010000",
				"000011101100010",
				"000001001010101",
				"000110100001100",
				"000100000111011"
			};
			byte[] array6 = new byte[]
			{
				0
			};
			int num = 0;
			int num2 = 0;
			Encoding encoding = Encoding.GetEncoding("UTF-8");
			byte[] bytes = encoding.GetBytes(string_8);
			int num3 = bytes.Length;
			this.method_27(string_8);
			this.qrtextTypes_0 = this.method_29(string_8);
			checked
			{
				int[] array7;
				byte[] array8;
				if (this.qrtextTypes_0 == DotNetBarcode.QRTextTypes.Kanji)
				{
					array7 = new int[(int)Math.Round(Math.Round(unchecked((double)num3 / 2.0 + 32.0 - 1.0))) + 1 - 1 + 1];
					array8 = new byte[(int)Math.Round(Math.Round(unchecked((double)num3 / 2.0 + 32.0 - 1.0))) + 1 - 1 + 1];
				}
				else
				{
					array7 = new int[num3 + 32 - 1 + 1 - 1 + 1];
					array8 = new byte[num3 + 32 - 1 + 1 - 1 + 1];
				}
				if (num3 <= 0)
				{
					byte[,] array9 = new byte[1, 1];
					array9[0, 0] = 0;
					return array9;
				}
				array8[num] = 4;
				int num4;
				switch (this.QRInquireTextType)
				{
				case DotNetBarcode.QRTextTypes.Numeric:
				{
					array6 = new byte[]
					{
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4
					};
					array7[num] = 1;
					num++;
					array7[num] = num3;
					array8[num] = 10;
					num4 = num;
					num++;
					int num5 = num3 - 1;
					for (int i = 0; i <= num5; i++)
					{
						byte b = this.method_33(Conversions.ToString(bytes[i]));
						if (i % 3 == 0)
						{
							array7[num] = (int)b;
							array8[num] = 4;
						}
						else
						{
							array7[num] = array7[num] * 10 + (int)b;
							if (i % 3 == 1)
							{
								array8[num] = 7;
							}
							else
							{
								array8[num] = 10;
								if (i < num3 - 1)
								{
									num++;
								}
							}
						}
					}
					num++;
					break;
				}
				case DotNetBarcode.QRTextTypes.AlphaNumeric:
				{
					array6 = new byte[]
					{
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4
					};
					array7[num] = 2;
					num++;
					array7[num] = num3;
					array8[num] = 9;
					num4 = num;
					num++;
					int num6 = num3 - 1;
					for (int j = 0; j <= num6; j++)
					{
						byte b2 = this.method_31(Conversions.ToString(bytes[j]));
						if (j % 2 == 0)
						{
							array7[num] = (int)b2;
							array8[num] = 6;
						}
						else
						{
							array7[num] = array7[num] * 45 + (int)b2;
							array8[num] = 11;
							if (j < num3 - 1)
							{
								num++;
							}
						}
					}
					num++;
					break;
				}
				case DotNetBarcode.QRTextTypes.Kanji:
				{
					array6 = new byte[]
					{
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						2,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4,
						4
					};
					array7[num] = 8;
					num++;
					array7[num] = (int)Math.Round(Math.Round((double)num3 / 2.0));
					array8[num] = 8;
					num4 = num;
					num++;
					int num7 = num3 - 1;
					for (int k = 0; k <= num7; k++)
					{
						byte b3 = bytes[k];
						if (b3 < 224)
						{
							b3 -= 129;
						}
						else
						{
							b3 -= 193;
						}
						byte b4 = bytes[k + 1];
						b4 -= 64;
						array7[num] = (int)(b3 * 192 + b4);
						array8[num] = 13;
						num++;
						k++;
					}
					break;
				}
				case DotNetBarcode.QRTextTypes.Binary:
				{
					array6 = new byte[]
					{
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						0,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8,
						8
					};
					array7[num] = 4;
					num++;
					array7[num] = num3;
					array8[num] = 8;
					num4 = num;
					num++;
					int num8 = num3 - 1;
					for (int l = 0; l <= num8; l++)
					{
						array7[l + num] = (int)(bytes[l] & byte.MaxValue);
						array8[l + num] = 8;
					}
					num += num3;
					break;
				}
				}
				int num9 = 0;
				int num10 = num - 1;
				for (int m = 0; m <= num10; m++)
				{
					num9 += (int)array8[m];
				}
				this.qrversions_0 = DotNetBarcode.QRVersions.Ver01;
				int num11 = 1;
				while (array4[(int)this.qreccrates_0, num11] < num9 + (int)array6[(int)this.qrversions_0])
				{
					this.qrversions_0++;
					num11++;
					if (num11 > 40)
					{
						IL_1416:
						if (this.qrversions_0 > DotNetBarcode.QRVersions.Ver40)
						{
							this.qrversions_0 = DotNetBarcode.QRVersions.Automatic;
							byte[,] array9 = new byte[1, 1];
							array9[0, 0] = 0;
							return array9;
						}
						if (this.qrversions_0 != DotNetBarcode.QRVersions.Automatic)
						{
							if (this.qrversions_0 > this.QRSetVersion)
							{
								num2 = array4[(int)this.qreccrates_0, (int)this.qrversions_0];
							}
							else
							{
								this.qrversions_0 = this.QRSetVersion;
								num2 = array4[(int)this.qreccrates_0, (int)this.qrversions_0];
							}
						}
						num9 += (int)array6[(int)this.qrversions_0];
						int num12 = num4;
						int num13;
						unchecked
						{
							array8[num12] += array6[(int)this.qrversions_0];
							num13 = array[(int)this.qrversions_0];
						}
						int num14 = array2[(int)this.qrversions_0] + (num13 << 3);
						this.byte_6 = this.method_21((int)this.qrversions_0);
						this.byte_7 = this.method_22((int)this.qrversions_0);
						byte byte_ = (byte)this.int_1[(int)this.qreccrates_0, this.qrversions_0 - DotNetBarcode.QRVersions.Ver01];
						int num15 = (int)Math.Round(Math.Round((double)num2 / 8.0));
						int num16 = (int)(DotNetBarcode.QRVersions.Ver04 * this.qrversions_0 + 17);
						this.int_7 = num16;
						int num17 = num16 * num16;
						byte[] array10 = new byte[num17 + num16 - 1 + 1 - 1 + 1];
						array10 = this.method_25((int)this.qrversions_0);
						this.byte_2 = new byte[num14 + 1 - 1 + 1];
						this.byte_3 = new byte[num14 + 1 - 1 + 1];
						this.byte_0 = new byte[num14 - 1 + 1 - 1 + 1];
						this.byte_1 = new byte[num14 - 1 + 1 - 1 + 1];
						int num18 = 0;
						for (int n = num16 - 1; n >= 3; n += -4)
						{
							for (int num19 = num16 - 1; num19 >= 0; num19 += -1)
							{
								int num20 = num19 * (num16 + 1) + n;
								int num21 = (int)(array10[num20] & 254);
								if (num21 == 0)
								{
									this.byte_2[num18] = (byte)n;
									this.byte_3[num18] = (byte)num19;
									num18++;
								}
								num20 = num19 * (num16 + 1) + n - 1;
								num21 = (int)(array10[num20] & 254);
								if (num21 == 0)
								{
									this.byte_2[num18] = (byte)(n - 1);
									this.byte_3[num18] = (byte)num19;
									num18++;
								}
							}
							if (n == 8)
							{
								n = 7;
							}
							int num22 = num16 - 1;
							for (int num23 = 0; num23 <= num22; num23++)
							{
								int num24 = num23 * (num16 + 1) + n - 2;
								int num25 = (int)(array10[num24] & 254);
								if (num25 == 0)
								{
									this.byte_2[num18] = (byte)(n - 2);
									this.byte_3[num18] = (byte)num23;
									num18++;
								}
								num24 = num23 * (num16 + 1) + n - 1 - 2;
								num25 = (int)(array10[num24] & 254);
								if (num25 == 0)
								{
									this.byte_2[num18] = (byte)(n - 1 - 2);
									this.byte_3[num18] = (byte)num23;
									num18++;
								}
							}
						}
						this.byte_0 = this.method_30(this.byte_2);
						this.byte_1 = this.method_30(this.byte_3);
						if (num9 <= num2 - 4)
						{
							array7[num] = 0;
							array8[num] = 4;
						}
						else if (num9 < num2)
						{
							array7[num] = 0;
							array8[num] = (byte)(num2 - num9);
						}
						byte[] byte_2 = this.method_19(array7, array8, num15);
						byte[] array11 = this.method_26(byte_2, byte_, num15, num13);
						byte[,] array12 = new byte[num16 - 1 + 1 - 1 + 1, num16 - 1 + 1 - 1 + 1];
						int num26 = num16 - 1;
						for (int num27 = 0; num27 <= num26; num27++)
						{
							int num28 = num16 - 1;
							for (int num29 = 0; num29 <= num28; num29++)
							{
								array12[num29, num27] = 0;
							}
						}
						int num30 = num13 - 1;
						for (int num31 = 0; num31 <= num30; num31++)
						{
							byte b5 = array11[num31];
							int num32 = 7;
							do
							{
								int num33 = num31 * 8 + num32;
								int num34 = this.method_24((int)this.byte_0[num33], (int)this.byte_1[num33]);
								array12[(int)this.byte_0[num33], (int)this.byte_1[num33]] = (byte)((int)(byte.MaxValue * (b5 & 1)) ^ num34);
								b5 = unchecked((byte)((uint)b5 >> 1));
								num32 += -1;
							}
							while (num32 >= 0);
						}
						for (int num35 = array2[(int)this.qrversions_0]; num35 >= 1; num35 += -1)
						{
							int num36 = num35 + num13 * 8 - 1;
							int num34 = this.method_24((int)this.byte_0[num36], (int)this.byte_1[num36]);
							array12[(int)this.byte_0[num36], (int)this.byte_1[num36]] = (byte)(255 ^ num34);
						}
						byte b6 = this.method_16(array12, array2[(int)this.qrversions_0] + num13 * 8);
						byte b7 = (byte)Math.Round(Math.Round(Math.Pow(2.0, (double)b6)));
						byte b8 = (byte)((int)b6 + this.qreccrates_0 * (DotNetBarcode.QRECCRates)8);
						int num37 = 0;
						do
						{
							byte b9 = byte.Parse(array5[(int)b8].Substring(num37, 1));
							array12[(int)this.byte_4[num37], (int)this.byte_5[num37]] = b9 * byte.MaxValue;
							array12[(int)this.byte_6[num37], (int)this.byte_7[num37]] = b9 * byte.MaxValue;
							num37++;
						}
						while (num37 <= 14);
						byte[,] array13 = new byte[num16 - 1 + 1 - 1 + 1, num16 - 1 + 1 - 1 + 1];
						int num38 = 0;
						int num39 = num16 - 1;
						for (int num40 = 0; num40 <= num39; num40++)
						{
							int num41 = num16 - 1;
							for (int num42 = 0; num42 <= num41; num42++)
							{
								if ((array12[num42, num40] & b7) != 0 | (array10[num38] & 1) == 1)
								{
									array13[num42, num40] = (1 | (array10[num38] & 254));
								}
								else
								{
									array13[num42, num40] = (0 | (array10[num38] & 254));
								}
								num38++;
							}
							num38++;
						}
						return array13;
					}
				}
				num2 = array4[(int)this.qreccrates_0, num11];
				goto IL_1416;
			}
		}

		private byte method_33(string string_8)
		{
			if (Conversions.ToDouble(string_8) >= 48.0 & Conversions.ToDouble(string_8) < 58.0)
			{
				return checked((byte)Math.Round(Math.Round(unchecked(Conversions.ToDouble(string_8) - 48.0))));
			}
			return 0;
		}

		public void QRSave(string code, string FileName, int pPixelSize)
		{
			this.method_32(code);
			float num = (float)this.QRInquireModuleSize;
			checked
			{
				if (num > 0f)
				{
					if (pPixelSize <= 0)
					{
						return;
					}
					int num2 = (int)Math.Round(Math.Round((double)(unchecked((float)pPixelSize * (num + (float)(checked(this.int_9 * 2)))))));
					float num3 = (float)(unchecked((double)num2 * (Math.Abs(Math.Sin((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)) + Math.Abs(Math.Cos((double)(this.QRRotate / 360f * 2f) * 3.1415926535897931)))));
					Bitmap bitmap = new Bitmap((int)Math.Round(Math.Round((double)num3)), (int)Math.Round(Math.Round((double)num3)), PixelFormat.Format24bppRgb);
					Graphics graphics = Graphics.FromImage(bitmap);
					SolidBrush brush = new SolidBrush(Color.White);
					graphics.FillRectangle(brush, 0, 0, (int)Math.Round(Math.Round((double)num3)), (int)Math.Round(Math.Round((double)num3)));
					this.method_34(code, 0f, 0f, pPixelSize, graphics);
					switch (this.SaveFileType)
					{
					case DotNetBarcode.SaveFileTypes.BitMap:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".bmp";
						}
						bitmap.Save(FileName, ImageFormat.Bmp);
						return;
					case DotNetBarcode.SaveFileTypes.Emf:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".emf";
						}
						bitmap.Save(FileName, ImageFormat.Emf);
						return;
					case DotNetBarcode.SaveFileTypes.Gif:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".gif";
						}
						bitmap.Save(FileName, ImageFormat.Gif);
						return;
					case DotNetBarcode.SaveFileTypes.Jpeg:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".jpg";
						}
						bitmap.Save(FileName, ImageFormat.Jpeg);
						return;
					case DotNetBarcode.SaveFileTypes.Png:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".png";
						}
						bitmap.Save(FileName, ImageFormat.Png);
						return;
					case DotNetBarcode.SaveFileTypes.Tiff:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".tiff";
						}
						bitmap.Save(FileName, ImageFormat.Tiff);
						return;
					case DotNetBarcode.SaveFileTypes.Wmf:
						if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
						{
							FileName += ".wmf";
						}
						bitmap.Save(FileName, ImageFormat.Wmf);
						return;
					}
				}
			}
		}

		public void method_34(string code, float X, float Y, int pQuitZoneSize, Graphics ev)
		{
			this.qrcode_write_barcode(code, X, Y, pQuitZoneSize, ev);
		}

		public void Save(string code, string FileName, float Width, float High)
		{
			if (this.Type == DotNetBarcode.Types.QRCode)
			{
				this.method_32(code);
				float num = (float)this.QRInquireModuleSize;
				if (num > 0f)
				{
					int num2 = this.method_15(num, Width, High);
					if (num2 <= 0)
					{
						return;
					}
					this.QRSave(code, FileName, num2);
				}
			}
			else
			{
				Bitmap bitmap = checked(new Bitmap((int)Math.Round(Math.Round((double)Width)), (int)Math.Round(Math.Round((double)High)), PixelFormat.Format24bppRgb));
				Graphics ev = Graphics.FromImage(bitmap);
				this.WriteBar(code, 0f, 0f, Width, High, ev);
				switch (this.SaveFileType)
				{
				case DotNetBarcode.SaveFileTypes.BitMap:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".bmp";
					}
					bitmap.Save(FileName, ImageFormat.Bmp);
					return;
				case DotNetBarcode.SaveFileTypes.Emf:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".emf";
					}
					bitmap.Save(FileName, ImageFormat.Emf);
					return;
				case DotNetBarcode.SaveFileTypes.Gif:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".gif";
					}
					bitmap.Save(FileName, ImageFormat.Gif);
					return;
				case DotNetBarcode.SaveFileTypes.Jpeg:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".jpg";
					}
					bitmap.Save(FileName, ImageFormat.Jpeg);
					return;
				case DotNetBarcode.SaveFileTypes.Png:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".png";
					}
					bitmap.Save(FileName, ImageFormat.Png);
					return;
				case DotNetBarcode.SaveFileTypes.Tiff:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".tiff";
					}
					bitmap.Save(FileName, ImageFormat.Tiff);
					return;
				case DotNetBarcode.SaveFileTypes.Wmf:
					if (Operators.CompareString(Path.GetExtension(FileName), "", false) == 0)
					{
						FileName += ".wmf";
					}
					bitmap.Save(FileName, ImageFormat.Wmf);
					return;
				}
			}
		}

		public void WriteBar(string code, float X, float Y, float X2, float Y2, Graphics ev)
		{
			if (this.types_0 != DotNetBarcode.Types.QRCode)
			{
				if (this.Rotate == DotNetBarcode.Rotates.Rotate90)
				{
					float num = Y2;
					float num2 = X2;
					X2 = num;
					Y2 = num2;
					ev.TranslateTransform(num2 + X + Y, 0f - X + Y);
					ev.RotateTransform(90f);
				}
				if (this.Rotate == DotNetBarcode.Rotates.const_1)
				{
					float num3 = X2;
					float num4 = Y2;
					ev.TranslateTransform(num3 + 2f * X, num4 + 2f * Y);
					ev.RotateTransform(180f);
				}
				if (this.Rotate == DotNetBarcode.Rotates.const_2)
				{
					float num = Y2;
					float num2 = X2;
					X2 = num;
					Y2 = num2;
					ev.TranslateTransform(0f + X - Y, num + X + Y);
					ev.RotateTransform(270f);
				}
			}
			switch (this.types_0)
			{
			case DotNetBarcode.Types.EAN_13:
				this.method_11(code, X, Y, X2, Y2, ev);
				return;
			case DotNetBarcode.Types.EAN_8:
				this.method_13(code, X, Y, X2, Y2, ev);
				return;
			case DotNetBarcode.Types.Code39:
				this.method_9(code, X, Y, X2, Y2, ev);
				return;
			case DotNetBarcode.Types.QRCode:
				this.method_14(code, X, Y, X2, Y2, ev);
				return;
			default:
				return;
			}
		}

		private void method_35(int int_10, int int_11, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			SolidBrush brush = new SolidBrush(this.color_20);
			SolidBrush brush2 = new SolidBrush(this.color_21);
			SolidBrush brush3 = new SolidBrush(this.color_19);
			if (this.bool_5)
			{
				if (int_10 == int_11)
				{
					graphics_0.FillRectangle(brush, float_2, float_4, float_3, float_5 * 0.1f);
				}
				else if (int_10 % 2 == 0)
				{
					graphics_0.FillRectangle(brush3, float_2, float_4, float_3, float_5 * 0.1f);
				}
				else
				{
					graphics_0.FillRectangle(brush2, float_2, float_4, float_3, float_5 * 0.1f);
				}
			}
		}

		private void method_36(string string_8, float float_2, float float_3, Graphics graphics_0)
		{
			new SolidBrush(Color.White);
			this.method_39(string_8, float_2, float_3, graphics_0);
		}

		private void method_37(string string_8, string[] string_9, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			checked
			{
				short num = (short)(Strings.Len(string_8) - 1);
				for (short num2 = 0; num2 <= num; num2 += 1)
				{
					this.method_38(string_9[Strings.Asc(Strings.Mid(string_8, (int)(num2 + 1), 1)) - 48], float_2, float_3, float_4, float_5, graphics_0);
				}
			}
		}

		private void method_38(string string_8, float float_2, float float_3, float float_4, float float_5, Graphics graphics_0)
		{
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			solidBrush.Color = this.color_18;
			checked
			{
				int num = Strings.Len(string_8) - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.CompareString(Strings.Mid(string_8, i + 1, 1), "1", false) == 0)
					{
						graphics_0.FillRectangle(solidBrush, unchecked(float_2 + (float)i * float_3), float_4, float_3, float_5);
					}
					this.method_35(i + 1, Strings.Len(string_8), unchecked(float_2 + (float)i * float_3), float_3, float_4, float_5, graphics_0);
				}
			}
		}

		private void method_39(string string_8, float float_2, float float_3, Graphics graphics_0)
		{
			Font font;
			if (this.FontBold)
			{
				if (this.FontItalic)
				{
					font = new Font(this.string_6, this.float_0, FontStyle.Bold | FontStyle.Italic);
				}
				else
				{
					font = new Font(this.string_6, this.float_0, FontStyle.Bold);
				}
			}
			else if (this.FontItalic)
			{
				font = new Font(this.string_6, this.float_0, FontStyle.Italic);
			}
			else
			{
				font = new Font(this.string_6, this.float_0);
			}
			SolidBrush brush = new SolidBrush(this.color_23);
			SolidBrush brush2 = new SolidBrush(this.color_22);
			StringFormat stringFormat = new StringFormat();
			if (this.bool_3)
			{
				stringFormat.Alignment = StringAlignment.Center;
				stringFormat.LineAlignment = StringAlignment.Center;
				SizeF sizeF = graphics_0.MeasureString(string_8, font);
				float width = sizeF.Width;
				float height = sizeF.Height;
				graphics_0.FillRectangle(brush2, float_2 - width / 2f, float_3 - height, width, height);
				graphics_0.DrawString(string_8, font, brush, float_2, float_3 - height / 2f, stringFormat);
			}
		}

		private int[,] int_0;

		private int[,] int_1;

		private int[,] int_2;

		private int[,] int_3;

		private const string string_0 = "01010";

		private const string string_1 = "101";

		private string[] string_2;

		private string[] string_3;

		private string[] string_4;

		private string[] string_5;

		private byte[] byte_0;

		private byte[] byte_1;

		private byte[] byte_2;

		private byte[] byte_3;

		private byte[] byte_4;

		private byte[] byte_5;

		private byte[] byte_6;

		private byte[] byte_7;

		private Color color_0;

		private Color color_1;

		private Color color_2;

		private Color color_3;

		private Color color_4;

		private Color color_5;

		private Color color_6;

		private Color color_7;

		private Color color_8;

		private Color color_9;

		private Color color_10;

		private Color color_11;

		private Color fcrdyLoTeL;

		private Color color_12;

		private Color color_13;

		private Color color_14;

		private Color color_15;

		private Color color_16;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private DotNetBarcode.QRTextTypes qrtextTypes_0;

		private DotNetBarcode.QRVersions qrversions_0;

		private int int_9;

		private DotNetBarcode.QRECCRates qreccrates_0;

		private DotNetBarcode.QRTextTypes qrtextTypes_1;

		private DotNetBarcode.QRVersions qrversions_1;

		private byte[] byte_8;

		private bool bool_0;

		private Color color_17;

		private Color color_18;

		private Color color_19;

		private Color color_20;

		private Color color_21;

		private Color color_22;

		private bool bool_1;

		private Color color_23;

		private bool bool_2;

		private string string_6;

		private float float_0;

		private bool bool_3;

		private bool bool_4;

		private Bitmap bitmap_0;

		private string string_7;

		private float float_1;

		private DotNetBarcode.QRTextTypes qrtextTypes_2;

		private DotNetBarcode.Rotates rotates_0;

		private DotNetBarcode.SaveFileTypes saveFileTypes_0;

		private DotNetBarcode.Types types_0;

		private bool bool_5;

		public string HeiBaiString;

		public enum QRECCRates
		{
			HighQuality30Percent = 3,
			const_1 = 0,
			Medium15Percent,
			Quality25Percent
		}

		public enum QRTextTypes
		{
			AlphaNumeric = 2,
			Automatic = 0,
			Binary = 4,
			Kanji = 3,
			Numeric = 1
		}

		public enum QRVersions
		{
			Automatic,
			Ver01,
			Ver02,
			Ver03,
			Ver04,
			Ver05,
			Ver06,
			Ver07,
			Ver08,
			Ver09,
			Ver10,
			Ver11,
			Ver12,
			Ver13,
			Ver14,
			Ver15,
			Ver16,
			Ver17,
			Ver18,
			Ver19,
			Ver20,
			Ver21,
			Ver22,
			Ver23,
			Ver24,
			Ver25,
			Ver26,
			Ver27,
			Ver28,
			Ver29,
			Ver30,
			Ver31,
			Ver32,
			Ver33,
			Ver34,
			Ver35,
			Ver36,
			Ver37,
			Ver38,
			Ver39,
			Ver40
		}

		public enum Rotates
		{
			Rotate0,
			const_1 = 180,
			const_2 = 270,
			Rotate90 = 90
		}

		public enum SaveFileTypes
		{
			BitMap = 1,
			Emf,
			Gif,
			Jpeg,
			Png,
			Tiff,
			Wmf
		}

		public enum Types
		{
			Code39 = 3,
			EAN_13 = 1,
			EAN_8,
			QRCode = 4
		}
	}
}
