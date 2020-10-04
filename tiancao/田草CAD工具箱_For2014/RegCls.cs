using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class RegCls
	{
		[DebuggerNonUserCode]
		public RegCls()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		public static string GetID()
		{
			string text = "";
			SelectQuery query = new SelectQuery("Win32_DiskDrive");
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
			try
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					if (managementBaseObject["Model"] != null)
					{
						text = managementBaseObject["Model"].ToString();
						break;
					}
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator;
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			query = new SelectQuery("Win32_BaseBoard");
			managementObjectSearcher = new ManagementObjectSearcher(query);
			try
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					if (managementBaseObject["Product"] != null)
					{
						text += managementBaseObject["Product"].ToString();
					}
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator2;
				if (enumerator2 != null)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			query = new SelectQuery("Win32_Processor");
			managementObjectSearcher = new ManagementObjectSearcher(query);
			try
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
				{
					if (managementBaseObject["ProcessorId"] != null)
					{
						text += managementBaseObject["ProcessorId"].ToString();
					}
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator3;
				if (enumerator3 != null)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			text = text;
			return text;
		}

		public static string GetID2()
		{
			string text = Strings.Trim(RegCls.GetID());
			text = text.ToUpper();
			text = text.Replace(" ", "");
			text = text.Replace("_", "");
			text = text.Replace("-", "");
			text = text.Replace("(", "");
			text = text.Replace(")", "");
			string text2 = "";
			short num = 0;
			short num2 = checked((short)(text.Length - 1));
			short num3 = num;
			for (;;)
			{
				short num4 = num3;
				short num5 = num2;
				if (num4 > num5)
				{
					break;
				}
				text2 += text.Substring((int)num3, 1);
				num3 += 2;
			}
			return text2;
		}

		[MethodImpl(MethodImplOptions.NoOptimization)]
		public static int CheckRegIsOrNot()
		{
			int num;
			int num3;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				object value = "<RSAKeyValue><Modulus>v4etgauwOR4gtGGNALZrRqykONegfPk54AzDTnF0oAJTLKavFDQb5lm+5oaUSP3J2FramMRYsOW7qWu3anVfZ8pu76iyU5ErqFGZHGR64i/dqL1H7HyiKUveBwIj5xTjGbiBx815DmFn7lf9/COtFo8NJrF6zEy8VA1gtdeF7Ik=</Modulus><Exponent>AQAB</Exponent><P>7J4AkfQhdwY+pPciq/bc6WFv+B8UMR9sXwuqF6Z7JzVPFeuzFgMoe+rb+ICnhurzb/zZfIzrWgEWoDHdVzmCIw==</P><Q>zzgrzHh59emsS6+rn8+cPoJKK+f6Dl4X4NKc7ws97jPuL5qf3Q1kYiI2eDAklkr2L2aZpUCpWIurmYjXM+ATYw==</Q><DP>z8fX3FMzZ9/V9usGSVgYmeB0gMBZ7OEZO0V08hvBnaaUcj1uH/BaBqcwz0G62yFK8JZrLZJZwcme4sGnCsd3XQ==</DP><DQ>CCHgNioUPz5ocJ/4UFFJhHqAhrCX87Blp4Ecf5UlXQ/UrTGYTIiWA/Prx1O8W9mdR8bzCLU88CirF19zcqm8mQ==</DQ><InverseQ>JzaczPUlkn63SCfil5slhi5JNomB1owdjBDArBucUYWqSculAGrHevWULv8/V+UE+YPWp2VVEcCeOB33HthkUQ==</InverseQ><D>VinIkZxWY+u81MlJ8LcgHaRPIM9IgNByC+xR9LkvuUgyeNTn0JP8tS1Mp1KF5SxfILkGvFEggTxopzgxRHBXIYeRi9Ge+c87HOA/QYj1qIaRFpjVSOWC1clHHewVmsHi5ZzIqPIUr6cTOfidjexqssmCs6gAShJQMi9f8Becaa0=</D></RSAKeyValue>";
				IL_12:
				num2 = 3;
				string id = RegCls.GetID2();
				IL_1B:
				num2 = 4;
				string string_ = Class33.Class31_0.Info.DirectoryPath + "\\注册.txt";
				IL_38:
				num2 = 5;
				object objectValue = RuntimeHelpers.GetObjectValue(Class36.smethod_41(string_));
				IL_48:
				num2 = 6;
				object value2 = Strings.Trim(NewLateBinding.LateIndexGet(objectValue, new object[]
				{
					0
				}, null).ToString());
				IL_72:
				num2 = 7;
				RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider();
				IL_7A:
				num2 = 8;
				rsacryptoServiceProvider.FromXmlString(Conversions.ToString(value));
				IL_89:
				num2 = 9;
				byte[] rgb = Convert.FromBase64String(Conversions.ToString(value2));
				IL_9A:
				num2 = 10;
				byte[] bytes = rsacryptoServiceProvider.Decrypt(rgb, false);
				IL_A8:
				num2 = 11;
				string @string = Encoding.UTF8.GetString(bytes);
				IL_B9:
				num2 = 12;
				if (Operators.CompareString(@string, id, false) != 0)
				{
					goto IL_D5;
				}
				IL_CB:
				num2 = 13;
				num3 = 1;
				goto IL_238;
				IL_D5:
				num2 = 15;
				IL_D8:
				num2 = 16;
				Reg_frm reg_frm = new Reg_frm();
				IL_E2:
				num2 = 17;
				reg_frm.TextBox1.Text = id;
				IL_F3:
				num2 = 18;
				Application.ShowModalDialog(reg_frm);
				IL_FE:
				num2 = 19;
				if (reg_frm.DialogResult != DialogResult.OK)
				{
					goto IL_117;
				}
				IL_10D:
				num2 = 20;
				num3 = 0;
				goto IL_238;
				IL_117:
				num2 = 22;
				IL_11A:
				num2 = 23;
				num3 = -1;
				goto IL_238;
				IL_124:
				num2 = 28;
				Interaction.MsgBox(Information.Err().Description, MsgBoxStyle.OkOnly, null);
				IL_139:
				goto IL_238;
				IL_13E:
				num2 = 26;
				if (Information.Err().Number <= 0)
				{
					goto IL_139;
				}
				IL_150:
				num2 = 27;
				num3 = -1;
				goto IL_238;
				IL_15A:
				goto IL_22D;
				IL_15F:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_17A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				goto IL_207;
				IL_17A:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				IL_207:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_15F;
			}
			IL_22D:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_238:
			int result = num3;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}
}
