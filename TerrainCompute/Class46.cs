using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ns0;

internal class Class46 : LicenseProvider
{
	static Class46()
	{
		Class46.class45_0 = null;
		Class46.int_0 = 0;
		Class46.int_1 = 1;
		Class46.int_2 = 1;
		Class46.int_3 = 1;
		Class46.string_0 = "";
		Class46.string_1 = "";
		Class46.string_2 = "";
		Class46.string_3 = "";
		Class46.string_4 = "";
		Class46.int_4 = 2147483647;
		Class46.int_5 = 0;
		Class46.string_5 = "";
		Class46.OjFrxNjkb1 = DateTime.Now;
		Class46.dateTime_0 = DateTime.Now;
		Class46.bool_0 = false;
		Class46.bool_1 = false;
		Class46.bool_2 = false;
		Class46.byte_0 = new byte[0];
	}

	public Class46()
	{
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	internal static extern IntPtr GetCurrentProcess();

	public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
	{
		return this.method_4(new byte[0]);
	}

	private void jnZrMnduej_Tick(object sender, EventArgs e)
	{
		this.jnZrMnduej.Enabled = false;
		try
		{
			if (Class46.class45_0.bool_48)
			{
				ConstructorInfo constructor = this.type_0.GetConstructor(new Type[0]);
				object target = constructor.Invoke(new object[0]);
				this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					Class46.class45_0.string_16
				});
				this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					Class46.class45_0.color_0
				});
				this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					Class46.class45_0.color_1
				});
				string text = Class46.class45_0.string_21;
				text = text.Replace("[current_minutes_days]", Class46.int_0.ToString());
				text = text.Replace("[max_minutes_days]", Class46.int_0.ToString());
				text = text.Replace("[max_uses]", Class46.int_1.ToString());
				text = text.Replace("[max_processes]", Class46.int_2.ToString());
				text = text.Replace("[current_uses]", Class46.int_3.ToString());
				this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					text
				});
				try
				{
					this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target, new object[0]);
				}
				catch(System.Exception ex)
				{
				}
			}
		}
        catch (System.Exception ex)
		{
		}
		if (Class46.class45_0.string_15.Length > 0)
		{
			try
			{
				if (File.Exists(Path.GetFullPath(Class46.class45_0.string_15)))
				{
					Class46.class45_0.string_15 = Path.GetFullPath(Class46.class45_0.string_15);
				}
				else if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(Class46.class45_0.string_15)))
				{
					Class46.class45_0.string_15 = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(Class46.class45_0.string_15);
				}
			}
			catch
			{
			}
			try
			{
				Process.Start(Class46.class45_0.string_15);
			}
			catch
			{
			}
		}
		if (Class46.class45_0.bool_47)
		{
			Class46.TerminateProcess(Class46.GetCurrentProcess(), 1);
		}
	}

	private bool method_0(RegistryKey registryKey_0, string string_6)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(string_6);
		this.method_1(registryKey_0, registryKey);
		registryKey.Close();
		return true;
	}

	private void method_1(RegistryKey registryKey_0, RegistryKey registryKey_1)
	{
		string[] valueNames = registryKey_0.GetValueNames();
		for (int i = 0; i < valueNames.Length; i++)
		{
			string name = valueNames[i];
			object value = registryKey_0.GetValue(name);
			registryKey_1.SetValue(name, value);
		}
		string[] subKeyNames = registryKey_0.GetSubKeyNames();
		for (int j = 0; j < subKeyNames.Length; j++)
		{
			string text = subKeyNames[j];
			RegistryKey registryKey_2 = registryKey_0.OpenSubKey(text, false);
			RegistryKey registryKey_3 = registryKey_1.CreateSubKey(text);
			this.method_1(registryKey_2, registryKey_3);
		}
	}

	private void method_2(RegistryKey registryKey_0, string string_6)
	{
		string text = "";
		string[] valueNames = registryKey_0.GetValueNames();
		for (int i = 0; i < valueNames.Length; i++)
		{
			string text2 = valueNames[i];
			string str = registryKey_0.GetValue(text2).ToString();
			if (text.Length > 0)
			{
				text += "|";
			}
			text = text + text2 + "|" + str;
		}
		Class26 @class = new Class26();
		@class.method_2(text, string_6);
	}

	private void method_3(string string_6, string string_7)
	{
		Class26 @class = new Class26();
		string text = @class.method_3(string_6);
		string[] array = text.Split(new char[]
		{
			'|'
		});
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(string_7);
		for (int i = 0; i < array.Length / 2; i++)
		{
			registryKey.SetValue(array[i * 2], array[i * 2 + 1]);
		}
		registryKey.Close();
	}

	internal License method_4(byte[] byte_1)
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
		bool flag = false;
		if (byte_1.Length > 0)
		{
			flag = true;
		}
		if (!flag && Class46.bool_0)
		{
			return new Class46.Class49(this, "");
		}
		bool flag2 = false;
		if (flag && Class46.bool_0)
		{
			flag2 = Class50.smethod_6();
			Class50.smethod_0();
		}
		Class46.bool_0 = true;
		lSfgApatkdxsVcGcrktoFd lSfgApatkdxsVcGcrktoFd = null;
		try
		{
			lSfgApatkdxsVcGcrktoFd = new lSfgApatkdxsVcGcrktoFd();
		}
		catch
		{
		}
		Class26.Class45 @class = null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		bool flag3 = false;
		try
		{
			DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			this.type_0 = typeof(rFohpatkdxsVcxLfJKhM7);
			string executablePath = Application.ExecutablePath;
			if (Class46.string_5.Length > 0)
			{
				executablePath = Class46.string_5;
			}
			Class46.string_5 = executablePath;
			new Class26();
			@class = new Class26.Class45();
			BinaryReader binaryReader = new BinaryReader(typeof(Class46).Assembly.GetManifestResourceStream("35fb47cb-fcb5-4347-ba65-188373ec4093"));
			binaryReader.BaseStream.Position = 0L;
			byte[] byte_2 = new byte[0];
			byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			byte[] array2 = new byte[32];
			array2[0] = 150;
			array2[0] = 27;
			array2[0] = 35;
			array2[1] = 114;
			array2[1] = 128;
			array2[1] = 92;
			array2[1] = 136;
			array2[1] = 148;
			array2[1] = 29;
			array2[2] = 86;
			array2[2] = 153;
			array2[2] = 205;
			array2[2] = 84;
			array2[2] = 112;
			array2[2] = 226;
			array2[3] = 113;
			array2[3] = 100;
			array2[3] = 211;
			array2[3] = 129;
			array2[4] = 92;
			array2[4] = 105;
			array2[4] = 89;
			array2[4] = 106;
			array2[5] = 78;
			array2[5] = 113;
			array2[5] = 132;
			array2[5] = 67;
			array2[6] = 223;
			array2[6] = 124;
			array2[6] = 96;
			array2[6] = 118;
			array2[7] = 90;
			array2[7] = 122;
			array2[7] = 133;
			array2[7] = 115;
			array2[7] = 95;
			array2[7] = 214;
			array2[8] = 135;
			array2[8] = 199;
			array2[8] = 154;
			array2[8] = 140;
			array2[8] = 123;
			array2[9] = 129;
			array2[9] = 96;
			array2[9] = 83;
			array2[9] = 73;
			array2[9] = 130;
			array2[9] = 219;
			array2[10] = 122;
			array2[10] = 117;
			array2[10] = 140;
			array2[10] = 135;
			array2[11] = 206;
			array2[11] = 148;
			array2[11] = 179;
			array2[12] = 113;
			array2[12] = 125;
			array2[12] = 96;
			array2[12] = 15;
			array2[13] = 141;
			array2[13] = 88;
			array2[13] = 124;
			array2[13] = 112;
			array2[13] = 8;
			array2[14] = 136;
			array2[14] = 118;
			array2[14] = 81;
			array2[14] = 110;
			array2[14] = 160;
			array2[15] = 116;
			array2[15] = 110;
			array2[15] = 46;
			array2[16] = 166;
			array2[16] = 179;
			array2[16] = 122;
			array2[16] = 98;
			array2[16] = 136;
			array2[16] = 140;
			array2[17] = 142;
			array2[17] = 123;
			array2[17] = 137;
			array2[17] = 154;
			array2[17] = 88;
			array2[17] = 23;
			array2[18] = 178;
			array2[18] = 145;
			array2[18] = 151;
			array2[18] = 161;
			array2[18] = 46;
			array2[19] = 116;
			array2[19] = 112;
			array2[19] = 184;
			array2[19] = 94;
			array2[19] = 117;
			array2[19] = 153;
			array2[20] = 181;
			array2[20] = 92;
			array2[20] = 215;
			array2[21] = 89;
			array2[21] = 39;
			array2[21] = 212;
			array2[22] = 140;
			array2[22] = 181;
			array2[22] = 156;
			array2[22] = 80;
			array2[23] = 129;
			array2[23] = 127;
			array2[23] = 151;
			array2[24] = 110;
			array2[24] = 132;
			array2[24] = 99;
			array2[24] = 159;
			array2[24] = 98;
			array2[24] = 216;
			array2[25] = 92;
			array2[25] = 154;
			array2[25] = 161;
			array2[25] = 91;
			array2[25] = 92;
			array2[25] = 60;
			array2[26] = 86;
			array2[26] = 199;
			array2[26] = 29;
			array2[27] = 141;
			array2[27] = 106;
			array2[27] = 190;
			array2[27] = 97;
			array2[27] = 185;
			array2[28] = 176;
			array2[28] = 102;
			array2[28] = 165;
			array2[28] = 50;
			array2[29] = 181;
			array2[29] = 127;
			array2[29] = 207;
			array2[30] = 111;
			array2[30] = 209;
			array2[30] = 88;
			array2[30] = 98;
			array2[30] = 196;
			array2[30] = 27;
			array2[31] = 93;
			array2[31] = 134;
			array2[31] = 111;
			byte[] rgbKey = array2;
			byte[] array3 = new byte[16];
			array3[0] = 150;
			array3[0] = 35;
			array3[0] = 124;
			array3[0] = 54;
			array3[0] = 236;
			array3[1] = 183;
			array3[1] = 93;
			array3[1] = 158;
			array3[1] = 106;
			array3[2] = 135;
			array3[2] = 213;
			array3[2] = 92;
			array3[2] = 111;
			array3[3] = 184;
			array3[3] = 100;
			array3[3] = 237;
			array3[4] = 154;
			array3[4] = 125;
			array3[4] = 124;
			array3[4] = 88;
			array3[4] = 128;
			array3[4] = 134;
			array3[5] = 215;
			array3[5] = 90;
			array3[5] = 164;
			array3[5] = 132;
			array3[5] = 21;
			array3[6] = 117;
			array3[6] = 80;
			array3[6] = 108;
			array3[6] = 84;
			array3[6] = 162;
			array3[7] = 114;
			array3[7] = 86;
			array3[7] = 153;
			array3[8] = 105;
			array3[8] = 98;
			array3[8] = 114;
			array3[8] = 180;
			array3[9] = 110;
			array3[9] = 122;
			array3[9] = 122;
			array3[9] = 229;
			array3[10] = 181;
			array3[10] = 153;
			array3[10] = 124;
			array3[10] = 119;
			array3[10] = 156;
			array3[10] = 117;
			array3[11] = 140;
			array3[11] = 129;
			array3[11] = 65;
			array3[11] = 67;
			array3[11] = 244;
			array3[12] = 132;
			array3[12] = 124;
			array3[12] = 142;
			array3[12] = 102;
			array3[12] = 0;
			array3[13] = 150;
			array3[13] = 84;
			array3[13] = 247;
			array3[14] = 109;
			array3[14] = 161;
			array3[14] = 160;
			array3[14] = 104;
			array3[14] = 219;
			array3[15] = 163;
			array3[15] = 212;
			array3[15] = 141;
			array3[15] = 87;
			byte[] rgbIV = array3;
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(rgbKey, rgbIV);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			byte_2 = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			binaryReader.Close();
			@class.method_17(byte_2);
			try
			{
				if (@class.string_17.Length > 0)
				{
					this.type_0 = base.GetType().Assembly.GetType(@class.string_17, false);
					if (this.type_0 == null)
					{
						this.type_0 = typeof(rFohpatkdxsVcxLfJKhM7);
					}
				}
				else
				{
					this.type_0 = typeof(rFohpatkdxsVcxLfJKhM7);
				}
			}
			catch
			{
			}
			if (Class46.class45_0 != null && Class46.class45_0.class34_0 != null && Class46.class45_0.class34_0.method_7() != null)
			{
				Class46.class45_0.class34_0.method_7().Clear();
			}
			Class46.class45_0 = @class;
			Class46.int_0 = @class.int_3;
			Class46.int_1 = @class.int_4;
			Class46.int_2 = @class.int_1;
			if (Class46.class45_0.bool_4)
			{
				try
				{
					if (!flag)
					{
						Application.EnableVisualStyles();
                        System.Windows.Forms.Application.DoEvents();
					}
				}
				catch
				{
				}
			}
			if (@class.bool_0)
			{
				try
				{
					if (!flag)
					{
						lSfgApatkdxsVcGcrktoFd.Show();
						lSfgApatkdxsVcGcrktoFd.Invalidate();
						lSfgApatkdxsVcGcrktoFd.progressBar1.Invalidate();
                        System.Windows.Forms.Application.DoEvents();
					}
				}
				catch
				{
				}
			}
			try
			{
				if (!flag && File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\lkasedfjsedfuwemnbsfdcgwaeiu"))
				{
					MessageBox.Show(Encoding.Unicode.GetString(Convert.FromBase64String(@class.string_11)));
				}
			}
			catch
			{
			}
			if (!@class.jnZrMnduej && !flag)
			{
				try
				{
					if (@class.bool_0)
					{
						try
						{
							if (!flag)
							{
								lSfgApatkdxsVcGcrktoFd.Hide();
							}
						}
						catch
						{
						}
					}
					rFohpatkdxsVcxLfJKhM7 rFohpatkdxsVcxLfJKhM = new rFohpatkdxsVcxLfJKhM7();
					rFohpatkdxsVcxLfJKhM.ShowDialog();
					if (@class.bool_0)
					{
						try
						{
							if (!flag)
							{
								lSfgApatkdxsVcGcrktoFd.Show();
								lSfgApatkdxsVcGcrktoFd.Invalidate();
								lSfgApatkdxsVcGcrktoFd.progressBar1.Invalidate();
                                System.Windows.Forms.Application.DoEvents();
							}
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			bool flag4 = false;
			flag3 = false;
			if (!@class.bool_46 && !@class.bool_38 && !@class.bool_44 && @class.bool_32 && !@class.bool_30)
			{
				flag3 = true;
			}
			else
			{
				flag4 = true;
			}
			if (flag4)
			{
				if (flag)
				{
					if (!flag || byte_1.Length != 1)
					{
						goto IL_DEF;
					}
				}
				try
				{
					flag3 = this.method_7(@class);
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_6(@class, Path.GetDirectoryName(executablePath));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_6(@class, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3 && typeof(Class46).Assembly.Location.Length > 0)
					{
						flag3 = this.method_6(@class, Path.GetDirectoryName(typeof(Class46).Assembly.Location));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_6(@class, Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_6(@class, Environment.GetFolderPath(Environment.SpecialFolder.System));
					}
				}
				catch
				{
				}
			}
			IL_DEF:
			if (flag && byte_1.Length > 1)
			{
				flag4 = true;
				flag3 = false;
				if (!(flag3 = this.method_5(@class, byte_1)))
				{
					License result = new Class46.Class49(this, "");
					return result;
				}
				if (this.jnZrMnduej != null)
				{
					try
					{
						this.jnZrMnduej.Tick -= new EventHandler(this.jnZrMnduej_Tick);
					}
					catch
					{
					}
					this.jnZrMnduej.Enabled = false;
					this.jnZrMnduej = null;
				}
				if (this.timer_0 != null)
				{
					try
					{
						this.timer_0.Tick -= new EventHandler(this.timer_0_Tick);
					}
					catch
					{
					}
					this.timer_0.Enabled = false;
					this.timer_0 = null;
				}
			}
			Class26.Class35.smethod_4();
			if (flag4 && flag3)
			{
				try
				{
					string str = "Software\\CLASSES\\CLSID\\";
					string str2 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
					RegistryKey localMachine = Registry.LocalMachine;
					RegistryKey registryKey = localMachine.OpenSubKey(str + str2 + Class26.smethod_29(@class.class34_0.method_4()), false);
					if (registryKey != null)
					{
						flag3 = false;
					}
				}
				catch
				{
				}
				try
				{
					if (flag3)
					{
						string str3 = "Software\\CLASSES\\CLSID\\";
						string str4 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey currentUser = Registry.CurrentUser;
						RegistryKey registryKey2 = currentUser.OpenSubKey(str3 + str4 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false);
						if (registryKey2 != null)
						{
							flag3 = false;
						}
					}
				}
				catch
				{
				}
				try
				{
					string str5 = Class26.Class35.smethod_7(Class26.smethod_0("{Y3358E75-826A3-31A5-2C1E-14A484D53571}" + Class26.smethod_29(@class.class34_0.method_4())));
					if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\IsolatedStorage\\" + str5))
					{
						flag3 = false;
					}
				}
				catch
				{
				}
			}
			bool flag5 = true;
			bool flag6 = true;
			bool flag7 = true;
			num4 = 0;
			num = 0;
			num2 = 0;
			bool flag8 = false;
			if (flag4 && flag3)
			{
				Class46.int_4 = 2147483647;
				string s = Convert.ToBase64String(@class.class34_0.method_4());
				if (!this.class45_1.bool_52)
				{
					@class.class34_0.method_5(this.class45_1.byte_0);
				}
				if (this.class45_1.bool_56)
				{
					num4 = this.class45_1.int_7;
					if (this.class45_1.enum11_1 == (Enum11)0)
					{
						try
						{
							string text = "Software\\CLASSES\\CLSID\\";
							RegistryKey currentUser2 = Registry.CurrentUser;
							RegistryKey registryKey3 = null;
							try
							{
								registryKey3 = currentUser2.OpenSubKey(text, true);
							}
							catch
							{
								registryKey3 = null;
							}
							Class46.Class47 class2 = new Class46.Class47();
							int num5 = class2.method_3(24);
							string[] array4 = new string[0];
							int num6 = 0;
							if (registryKey3 != null)
							{
								array4 = registryKey3.GetSubKeyNames();
								num6 = array4.Length;
							}
							int num7 = 25;
							if (registryKey3 == null)
							{
								num5 = 0;
								num7 = 1;
							}
							if (num6 < 3)
							{
								num5 = 0;
								num7 = 1;
							}
							for (int i = 0; i < num7; i++)
							{
								if (i == num5)
								{
									if (Class46.string_0.Length == 0)
									{
										Class46.string_0 = Class26.Class27.smethod_11();
									}
									string str6 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
									RegistryKey registryKey4 = Registry.CurrentUser;
									if (registryKey4.OpenSubKey(text + str6 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false) != null)
									{
										goto IL_169E;
									}
									if (File.Exists(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str6)
									})))
									{
										this.method_3(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str6)
										}), text + str6 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										goto IL_169E;
									}
									try
									{
										registryKey4 = Registry.LocalMachine;
										RegistryKey registryKey5 = registryKey4.OpenSubKey(text + str6 + Class26.smethod_29(@class.class34_0.method_4()), false);
										if (registryKey5 != null)
										{
											this.method_0(registryKey5, text + str6 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										}
										else
										{
											str6 = "{" + Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)) + "}\\";
											registryKey4 = Registry.CurrentUser;
											registryKey5 = registryKey4.OpenSubKey(text + str6 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false);
											if (registryKey5 != null)
											{
												this.method_0(registryKey5, text + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
											}
										}
										goto IL_169E;
									}
									catch
									{
										str6 = "{" + Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)) + "}\\";
										registryKey4 = Registry.CurrentUser;
										RegistryKey registryKey5 = registryKey4.OpenSubKey(text + str6 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false);
										if (registryKey5 != null)
										{
											this.method_0(registryKey5, text + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										}
										goto IL_169E;
									}
									RegistryKey registryKey6;
                                IL_130E:
									try
									{
										
										if (registryKey6.GetValue("3") == null)
										{
											registryKey6.SetValue("3", Class26.smethod_33("10000000"));
										}
										else if (registryKey6.GetValue("3").ToString().Length == 0)
										{
											registryKey6.SetValue("3", Class26.smethod_33("10000000"));
										}
									}
									catch
									{
									}
									string string_ = (string)registryKey6.GetValue("1");
									DateTime value = Class26.smethod_27(string_);
									int num8 = Convert.ToInt32(Class26.smethod_34((string)registryKey6.GetValue("3"))) - 10000000;
									decimal num9 = Math.Abs(dateTime.Subtract(value).Days);
									num = (int)num9 + num8;
									if (num9 > 0m)
									{
										Class26.smethod_26(dateTime);
										Class26.smethod_33((10000000 + num).ToString());
										registryKey6.SetValue("1", Class26.smethod_26(dateTime));
										registryKey6.SetValue("3", Class26.smethod_33((10000000 + num).ToString()));
									}
									num2 = num4 - num;
									num++;
									if (num > num4)
									{
										flag5 = false;
										num2 = 0;
									}
									Class46.int_4 = num2;
									this.method_0(registryKey6, string.Concat(new string[]
									{
										text,
										"{",
										Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)),
										"}\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4()))
									}));
									string str7;
									this.method_2(registryKey6, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str7)
									}));
									goto IL_1693;
									IL_169E:
									str7 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
									RegistryKey currentUser3 = Registry.CurrentUser;
									registryKey6 = currentUser3.OpenSubKey(text + str7 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
									if (registryKey6 != null)
									{
										goto IL_130E;
									}
									currentUser3 = Registry.CurrentUser;
									registryKey6 = currentUser3.CreateSubKey(text + str7 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
									Class26.smethod_26(dateTime);
									registryKey6.SetValue("0", Class26.smethod_26(dateTime));
									registryKey6.SetValue("1", Class26.smethod_26(dateTime));
									registryKey6.SetValue("3", Class26.smethod_33("10000000"));
									num = 1;
									num2 = num4;
									Class46.int_4 = num2;
									this.method_0(registryKey6, string.Concat(new string[]
									{
										text,
										"{",
										Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)),
										"}\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4()))
									}));
									this.method_2(registryKey6, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str7)
									}));
								}
								else
								{
									try
									{
										int num10 = class2.method_3(num6 - 1);
										RegistryKey registryKey7 = registryKey3.OpenSubKey(array4[num10]);
										if (registryKey7.ValueCount > 0)
										{
											string[] valueNames = registryKey7.GetValueNames();
											if (valueNames.Length > 1)
											{
												registryKey7.GetValue(valueNames[0]);
											}
										}
										registryKey7.Close();
									}
									catch
									{
									}
								}
								IL_1693:;
							}
						}
						catch
						{
						}
					}
				}
				if (this.class45_1.bool_55)
				{
					try
					{
						string text2 = "Software\\CLASSES\\CLSID\\";
						RegistryKey currentUser4 = Registry.CurrentUser;
						RegistryKey registryKey8 = null;
						try
						{
							registryKey8 = currentUser4.OpenSubKey(text2, true);
						}
						catch
						{
							registryKey8 = null;
						}
						Class46.Class47 class3 = new Class46.Class47();
						int num11 = class3.method_3(24);
						string[] array5 = new string[0];
						int num12 = 0;
						if (registryKey8 != null)
						{
							array5 = registryKey8.GetSubKeyNames();
							num12 = array5.Length;
						}
						int num13 = 25;
						if (registryKey8 == null)
						{
							num11 = 0;
							num13 = 1;
						}
						if (num12 < 3)
						{
							num11 = 0;
							num13 = 1;
						}
						for (int j = 0; j < num13; j++)
						{
							if (j == num11)
							{
								string str8 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
								RegistryKey registryKey9 = Registry.CurrentUser;
								if (registryKey9.OpenSubKey(text2 + str8 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false) != null)
								{
									goto IL_1BD1;
								}
								if (File.Exists(string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\IsolatedStorage\\",
									Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
									"\\",
									Class26.Class35.smethod_7(str8)
								})))
								{
									this.method_3(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str8)
									}), text2 + str8 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
									goto IL_1BD1;
								}
								try
								{
									registryKey9 = Registry.LocalMachine;
									RegistryKey registryKey10 = registryKey9.OpenSubKey(text2 + str8 + Class26.smethod_29(@class.class34_0.method_4()), false);
									if (registryKey10 != null)
									{
										this.method_0(registryKey10, text2 + str8 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
									}
									goto IL_1BD1;
								}
								catch
								{
									goto IL_1BD1;
								}
								IL_18E5:
								RegistryKey currentUser5 = Registry.CurrentUser;
								string str9;
								RegistryKey registryKey11 = currentUser5.CreateSubKey(text2 + str9 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
								registryKey11.SetValue("2", Class26.smethod_26(dateTime));
								DateTime now = DateTime.Now;
								if (DateTime.Compare(now, this.class45_1.dateTime_1) >= 0)
								{
									flag6 = false;
									if (Class46.int_4 == 2147483647)
									{
										Class46.int_4 = 0;
									}
									else if (!@class.bool_33)
									{
										Class46.int_4 = 0;
									}
								}
								else
								{
									TimeSpan timeSpan = this.class45_1.dateTime_1.Subtract(DateTime.Now);
									if (Class46.int_4 == 2147483647)
									{
										Class46.int_4 = timeSpan.Days;
									}
									else if (@class.bool_33)
									{
										if (timeSpan.Days > Class46.int_4)
										{
											Class46.int_4 = timeSpan.Days;
										}
									}
									else if (timeSpan.Days < Class46.int_4)
									{
										Class46.int_4 = timeSpan.Days;
									}
								}
								this.method_2(registryKey11, string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\IsolatedStorage\\",
									Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
									"\\",
									Class26.Class35.smethod_7(str9)
								}));
								goto IL_1BC6;
								IL_1BD1:
								str9 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
								currentUser5 = Registry.CurrentUser;
								registryKey11 = currentUser5.OpenSubKey(text2 + str9 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
								if (registryKey11 == null)
								{
									goto IL_18E5;
								}
								string string_2 = (string)registryKey11.GetValue("2");
								DateTime dateTime2 = Class26.smethod_27(string_2);
								if (DateTime.Compare(dateTime, dateTime2) >= 0)
								{
									registryKey11.SetValue("2", Class26.smethod_26(dateTime));
									dateTime2 = dateTime;
								}
								if (DateTime.Compare(dateTime2, this.class45_1.dateTime_1) >= 0)
								{
									flag6 = false;
									if (Class46.int_4 == 2147483647)
									{
										Class46.int_4 = 0;
									}
									else if (!@class.bool_33)
									{
										Class46.int_4 = 0;
									}
								}
								else
								{
									TimeSpan timeSpan2 = this.class45_1.dateTime_1.Subtract(DateTime.Now);
									if (Class46.int_4 == 2147483647)
									{
										Class46.int_4 = timeSpan2.Days;
									}
									else if (@class.bool_33)
									{
										if (timeSpan2.Days > Class46.int_4)
										{
											Class46.int_4 = timeSpan2.Days;
										}
									}
									else if (timeSpan2.Days < Class46.int_4)
									{
										Class46.int_4 = timeSpan2.Days;
									}
								}
								this.method_2(registryKey11, string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\IsolatedStorage\\",
									Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
									"\\",
									Class26.Class35.smethod_7(str9)
								}));
							}
							else
							{
								try
								{
									int num14 = class3.method_3(num12 - 1);
									RegistryKey registryKey12 = registryKey8.OpenSubKey(array5[num14]);
									if (registryKey12.ValueCount > 0)
									{
										string[] valueNames2 = registryKey12.GetValueNames();
										if (valueNames2.Length > 1)
										{
											registryKey12.GetValue(valueNames2[0]);
										}
									}
									registryKey12.Close();
								}
								catch
								{
								}
							}
							IL_1BC6:;
						}
					}
					catch
					{
					}
					if ((!flag || (flag && !flag2)) && this.class45_1.enum11_1 == (Enum11)0)
					{
						try
						{
							this.timer_0.Tick -= new EventHandler(this.timer_0_Tick);
						}
						catch
						{
						}
						try
						{
							Class46.OjFrxNjkb1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							Class46.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							this.timer_0 = new Timer();
							this.timer_0.Interval = 60000;
							this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
							this.timer_0.Enabled = true;
						}
						catch
						{
						}
					}
				}
				if (this.class45_1.bool_51)
				{
					try
					{
						string text3 = "Software\\CLASSES\\CLSID\\";
						RegistryKey currentUser6 = Registry.CurrentUser;
						RegistryKey registryKey13 = null;
						try
						{
							registryKey13 = currentUser6.OpenSubKey(text3, true);
						}
						catch
						{
							registryKey13 = null;
						}
						Class46.Class47 class4 = new Class46.Class47();
						int num15 = class4.method_3(24);
						string[] array6 = new string[0];
						int num16 = 0;
						if (registryKey13 != null)
						{
							array6 = registryKey13.GetSubKeyNames();
							num16 = array6.Length;
						}
						int num17 = 25;
						if (registryKey13 == null)
						{
							num15 = 0;
							num17 = 1;
						}
						if (num16 < 3)
						{
							num15 = 0;
							num17 = 1;
						}
						for (int k = 0; k < num17; k++)
						{
							if (k == num15)
							{
								string str10 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
								RegistryKey registryKey14 = Registry.CurrentUser;
								if (registryKey14.OpenSubKey(text3 + str10 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false) != null)
								{
									goto IL_2125;
								}
								if (File.Exists(string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\IsolatedStorage\\",
									Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
									"\\",
									Class26.Class35.smethod_7(str10)
								})))
								{
									this.method_3(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str10)
									}), text3 + str10 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
									goto IL_2125;
								}
								try
								{
									registryKey14 = Registry.LocalMachine;
									RegistryKey registryKey15 = registryKey14.OpenSubKey(text3 + str10 + Class26.smethod_29(@class.class34_0.method_4()), false);
									if (registryKey15 != null)
									{
										this.method_0(registryKey15, text3 + str10 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
									}
									goto IL_2125;
								}
								catch
								{
									goto IL_2125;
								}
								IL_1EFE:
								RegistryKey currentUser7 = Registry.CurrentUser;
								string str11;
								RegistryKey registryKey16 = currentUser7.CreateSubKey(text3 + str11 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
								registryKey16.SetValue("2", Class26.smethod_33(Class46.int_3.ToString()));
								flag8 = true;
								if (Class46.int_3 > this.class45_1.int_5)
								{
									flag7 = false;
									Class46.int_3 = this.class45_1.int_5 + 1;
									num3 = 0;
								}
								else
								{
									num3 = this.class45_1.int_5 - Class46.int_3;
								}
								this.method_2(registryKey16, string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\IsolatedStorage\\",
									Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
									"\\",
									Class26.Class35.smethod_7(str11)
								}));
								goto IL_211A;
								IL_2125:
								str11 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
								currentUser7 = Registry.CurrentUser;
								registryKey16 = currentUser7.OpenSubKey(text3 + str11 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
								if (registryKey16 == null)
								{
									goto IL_1EFE;
								}
								string string_3 = (string)registryKey16.GetValue("2");
								Class46.int_3 = Convert.ToInt32(Class26.smethod_34(string_3));
								flag8 = true;
								Class46.int_3++;
								registryKey16.SetValue("2", Class26.smethod_33(Class46.int_3.ToString()));
								if (Class46.int_3 > this.class45_1.int_5)
								{
									flag7 = false;
									Class46.int_3 = this.class45_1.int_5 + 1;
									num3 = 0;
								}
								else
								{
									num3 = this.class45_1.int_5 - Class46.int_3;
								}
								this.method_2(registryKey16, string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\IsolatedStorage\\",
									Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
									"\\",
									Class26.Class35.smethod_7(str11)
								}));
							}
							else
							{
								try
								{
									int num18 = class4.method_3(num16 - 1);
									RegistryKey registryKey17 = registryKey13.OpenSubKey(array6[num18]);
									if (registryKey17.ValueCount > 0)
									{
										string[] valueNames3 = registryKey17.GetValueNames();
										if (valueNames3.Length > 1)
										{
											registryKey17.GetValue(valueNames3[0]);
										}
									}
									registryKey17.Close();
								}
								catch
								{
								}
							}
							IL_211A:;
						}
					}
					catch
					{
					}
				}
				if (Class46.class45_0.bool_33)
				{
					bool flag9 = true;
					if (this.class45_1.bool_56)
					{
						flag9 = false;
					}
					if (this.class45_1.bool_55)
					{
						flag9 = false;
					}
					if (this.class45_1.bool_51)
					{
						flag9 = false;
					}
					if (this.class45_1.bool_56 && flag5)
					{
						flag9 = true;
					}
					if (this.class45_1.bool_55 && flag6)
					{
						flag9 = true;
					}
					if (this.class45_1.bool_51 && flag7)
					{
						flag9 = true;
					}
					if (!flag9)
					{
						flag3 = false;
					}
				}
				else
				{
					bool flag10 = true;
					if (this.class45_1.bool_56 && !flag5)
					{
						flag10 = false;
					}
					if (this.class45_1.bool_55 && !flag6)
					{
						flag10 = false;
					}
					if (this.class45_1.bool_51 && !flag7)
					{
						flag10 = false;
					}
					if (!flag10)
					{
						flag3 = false;
					}
				}
				@class.class34_0.method_5(Convert.FromBase64String(s));
				if (flag3 && this.class45_1.bool_56 && (!flag || (flag && !flag2)))
				{
					if (this.class45_1.enum11_1 == (Enum11)1)
					{
						try
						{
							this.jnZrMnduej.Tick -= new EventHandler(this.jnZrMnduej_Tick);
						}
						catch
						{
						}
						this.jnZrMnduej = new Timer();
						this.jnZrMnduej.Interval = num4 * 60000;
						this.jnZrMnduej.Tick += new EventHandler(this.jnZrMnduej_Tick);
						this.jnZrMnduej.Enabled = true;
					}
					if (this.class45_1.enum11_1 == (Enum11)0)
					{
						try
						{
							this.timer_0.Tick -= new EventHandler(this.timer_0_Tick);
						}
						catch
						{
						}
						try
						{
							Class46.OjFrxNjkb1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							Class46.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							this.timer_0 = new Timer();
							this.timer_0.Interval = 60000;
							this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
							this.timer_0.Enabled = true;
						}
						catch
						{
						}
					}
				}
			}
			bool flag11 = true;
			if (flag4)
			{
				if (flag3)
				{
					@class.bool_43 = this.class45_1.bool_43;
					@class.bool_40 = this.class45_1.bool_40;
					@class.bool_41 = this.class45_1.bool_41;
					@class.bool_42 = this.class45_1.bool_42;
					@class.bool_39 = this.class45_1.bool_54;
					@class.bool_54 = this.class45_1.bool_54;
					@class.string_24 = this.class45_1.string_24;
					@class.int_3 = this.class45_1.int_7;
					@class.int_7 = this.class45_1.int_7;
					num4 = this.class45_1.int_7;
					Class46.int_0 = this.class45_1.int_7;
					@class.bool_46 = this.class45_1.bool_56;
					@class.bool_56 = this.class45_1.bool_56;
					@class.enum11_0 = this.class45_1.enum11_1;
					@class.enum11_1 = this.class45_1.enum11_1;
					@class.bool_38 = this.class45_1.bool_55;
					@class.bool_55 = this.class45_1.bool_55;
					@class.dateTime_0 = this.class45_1.dateTime_1;
					@class.dateTime_1 = this.class45_1.dateTime_1;
					@class.bool_44 = this.class45_1.bool_51;
					@class.bool_51 = this.class45_1.bool_51;
					@class.int_5 = this.class45_1.int_5;
					@class.int_4 = this.class45_1.int_5;
					Class46.int_1 = this.class45_1.int_5;
					@class.bool_45 = this.class45_1.bool_53;
					@class.bool_53 = this.class45_1.bool_53;
					@class.int_6 = this.class45_1.int_6;
					@class.int_1 = this.class45_1.int_6;
					Class46.int_2 = this.class45_1.int_6;
				}
				else
				{
					flag5 = true;
					flag6 = true;
					flag7 = true;
					num4 = 0;
					num = 0;
					num2 = 0;
					Class46.int_3 = 1;
					Class46.int_4 = 2147483647;
					if (@class.bool_46)
					{
						num4 = @class.int_3;
						if (@class.enum11_0 == (Enum11)0)
						{
							try
							{
								string text4 = "Software\\CLASSES\\CLSID\\";
								RegistryKey currentUser8 = Registry.CurrentUser;
								RegistryKey registryKey18 = null;
								try
								{
									registryKey18 = currentUser8.OpenSubKey(text4, true);
								}
								catch
								{
									registryKey18 = null;
								}
								Class46.Class47 class5 = new Class46.Class47();
								int num19 = class5.method_3(24);
								string[] array7 = new string[0];
								int num20 = 0;
								if (registryKey18 != null)
								{
									array7 = registryKey18.GetSubKeyNames();
									num20 = array7.Length;
								}
								int num21 = 25;
								if (registryKey18 == null)
								{
									num19 = 0;
									num21 = 1;
								}
								if (num20 < 3)
								{
									num19 = 0;
									num21 = 1;
								}
								for (int l = 0; l < num21; l++)
								{
									if (l == num19)
									{
										if (Class46.string_0.Length == 0)
										{
											Class46.string_0 = Class26.Class27.smethod_11();
										}
										string str12 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
										RegistryKey registryKey19 = Registry.CurrentUser;
										if (registryKey19.OpenSubKey(text4 + str12 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false) != null)
										{
											goto IL_2C7E;
										}
										if (File.Exists(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str12)
										})))
										{
											this.method_3(string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
												"\\IsolatedStorage\\",
												Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
												"\\",
												Class26.Class35.smethod_7(str12)
											}), text4 + str12 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
											goto IL_2C7E;
										}
										try
										{
											registryKey19 = Registry.LocalMachine;
											RegistryKey registryKey20 = registryKey19.OpenSubKey(text4 + str12 + Class26.smethod_29(@class.class34_0.method_4()), false);
											if (registryKey20 != null)
											{
												this.method_0(registryKey20, text4 + str12 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
											}
											else
											{
												str12 = "{" + Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)) + "}\\";
												registryKey19 = Registry.CurrentUser;
												registryKey20 = registryKey19.OpenSubKey(text4 + str12 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false);
												if (registryKey20 != null)
												{
													this.method_0(registryKey20, text4 + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
												}
											}
											goto IL_2C7E;
										}
										catch
										{
											str12 = "{" + Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)) + "}\\";
											registryKey19 = Registry.CurrentUser;
											RegistryKey registryKey20 = registryKey19.OpenSubKey(text4 + str12 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false);
											if (registryKey20 != null)
											{
												this.method_0(registryKey20, text4 + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
											}
											goto IL_2C7E;
										}
										RegistryKey registryKey21;
										IL_28EE:
                                        try
										{
											
											if (registryKey21.GetValue("3") == null)
											{
												registryKey21.SetValue("3", Class26.smethod_33("10000000"));
											}
											else if (registryKey21.GetValue("3").ToString().Length == 0)
											{
												registryKey21.SetValue("3", Class26.smethod_33("10000000"));
											}
										}
										catch
										{
										}
										string string_4 = (string)registryKey21.GetValue("1");
										DateTime value2 = Class26.smethod_27(string_4);
										int num22 = Convert.ToInt32(Class26.smethod_34((string)registryKey21.GetValue("3"))) - 10000000;
										decimal num23 = Math.Abs(dateTime.Subtract(value2).Days);
										num = (int)num23 + num22;
										if (num23 > 0m)
										{
											Class26.smethod_26(dateTime);
											Class26.smethod_33((10000000 + num).ToString());
											registryKey21.SetValue("1", Class26.smethod_26(dateTime));
											registryKey21.SetValue("3", Class26.smethod_33((10000000 + num).ToString()));
										}
										num2 = num4 - num;
										num++;
										if (num > num4)
										{
											flag5 = false;
											num2 = 0;
										}
										Class46.int_4 = num2;
										this.method_0(registryKey21, string.Concat(new string[]
										{
											text4,
											"{",
											Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)),
											"}\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4()))
										}));
										string str13;
										this.method_2(registryKey21, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str13)
										}));
										goto IL_2C73;
										IL_2C7E:
										str13 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
										RegistryKey currentUser9 = Registry.CurrentUser;
										registryKey21 = currentUser9.OpenSubKey(text4 + str13 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
										if (registryKey21 != null)
										{
											goto IL_28EE;
										}
										currentUser9 = Registry.CurrentUser;
										registryKey21 = currentUser9.CreateSubKey(text4 + str13 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										Class26.smethod_26(dateTime);
										registryKey21.SetValue("0", Class26.smethod_26(dateTime));
										registryKey21.SetValue("1", Class26.smethod_26(dateTime));
										registryKey21.SetValue("3", Class26.smethod_33("10000000"));
										num = 1;
										num2 = num4;
										Class46.int_4 = num2;
										this.method_0(registryKey21, string.Concat(new string[]
										{
											text4,
											"{",
											Class26.Class35.smethod_7(Class26.smethod_0(Class46.string_0)),
											"}\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4()))
										}));
										this.method_2(registryKey21, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str13)
										}));
									}
									else
									{
										try
										{
											int num24 = class5.method_3(num20 - 1);
											RegistryKey registryKey22 = registryKey18.OpenSubKey(array7[num24]);
											if (registryKey22.ValueCount > 0)
											{
												string[] valueNames4 = registryKey22.GetValueNames();
												if (valueNames4.Length > 1)
												{
													registryKey22.GetValue(valueNames4[0]);
												}
											}
											registryKey22.Close();
										}
										catch
										{
										}
									}
									IL_2C73:;
								}
							}
							catch
							{
							}
						}
					}
					if (@class.bool_38)
					{
						try
						{
							string text5 = "Software\\CLASSES\\CLSID\\";
							RegistryKey currentUser10 = Registry.CurrentUser;
							RegistryKey registryKey23 = null;
							try
							{
								registryKey23 = currentUser10.OpenSubKey(text5, true);
							}
							catch
							{
								registryKey23 = null;
							}
							Class46.Class47 class6 = new Class46.Class47();
							int num25 = class6.method_3(24);
							string[] array8 = new string[0];
							int num26 = 0;
							if (registryKey23 != null)
							{
								array8 = registryKey23.GetSubKeyNames();
								num26 = array8.Length;
							}
							int num27 = 25;
							if (registryKey23 == null)
							{
								num25 = 0;
								num27 = 1;
							}
							if (num26 < 3)
							{
								num25 = 0;
								num27 = 1;
							}
							for (int m = 0; m < num27; m++)
							{
								if (m == num25)
								{
									string str14 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
									RegistryKey registryKey24 = Registry.CurrentUser;
									if (registryKey24.OpenSubKey(text5 + str14 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false) != null)
									{
										goto IL_3198;
									}
									if (File.Exists(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str14)
									})))
									{
										this.method_3(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str14)
										}), text5 + str14 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										goto IL_3198;
									}
									try
									{
										registryKey24 = Registry.LocalMachine;
										RegistryKey registryKey25 = registryKey24.OpenSubKey(text5 + str14 + Class26.smethod_29(@class.class34_0.method_4()), false);
										if (registryKey25 != null)
										{
											this.method_0(registryKey25, text5 + str14 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										}
										goto IL_3198;
									}
									catch
									{
										goto IL_3198;
									}
									IL_2EC0:
									RegistryKey currentUser11 = Registry.CurrentUser;
									string str15;
									RegistryKey registryKey26 = currentUser11.CreateSubKey(text5 + str15 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
									registryKey26.SetValue("2", Class26.smethod_26(dateTime));
									DateTime now2 = DateTime.Now;
									if (DateTime.Compare(now2, @class.dateTime_0) >= 0)
									{
										flag6 = false;
										if (Class46.int_4 == 2147483647)
										{
											Class46.int_4 = 0;
										}
										else if (!@class.bool_33)
										{
											Class46.int_4 = 0;
										}
									}
									else
									{
										TimeSpan timeSpan3 = @class.dateTime_0.Subtract(DateTime.Now);
										if (Class46.int_4 == 2147483647)
										{
											Class46.int_4 = timeSpan3.Days;
										}
										else if (@class.bool_33)
										{
											if (timeSpan3.Days > Class46.int_4)
											{
												Class46.int_4 = timeSpan3.Days;
											}
										}
										else if (timeSpan3.Days < Class46.int_4)
										{
											Class46.int_4 = timeSpan3.Days;
										}
									}
									this.method_2(registryKey26, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str15)
									}));
									goto IL_318D;
									IL_3198:
									str15 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
									currentUser11 = Registry.CurrentUser;
									registryKey26 = currentUser11.OpenSubKey(text5 + str15 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
									if (registryKey26 == null)
									{
										goto IL_2EC0;
									}
									string string_5 = (string)registryKey26.GetValue("2");
									DateTime dateTime3 = Class26.smethod_27(string_5);
									if (DateTime.Compare(dateTime, dateTime3) >= 0)
									{
										registryKey26.SetValue("2", Class26.smethod_26(dateTime));
										dateTime3 = dateTime;
									}
									if (DateTime.Compare(dateTime3, @class.dateTime_0) >= 0)
									{
										flag6 = false;
										if (Class46.int_4 == 2147483647)
										{
											Class46.int_4 = 0;
										}
										else if (!@class.bool_33)
										{
											Class46.int_4 = 0;
										}
									}
									else
									{
										TimeSpan timeSpan4 = @class.dateTime_0.Subtract(DateTime.Now);
										if (Class46.int_4 == 2147483647)
										{
											Class46.int_4 = timeSpan4.Days;
										}
										else if (@class.bool_33)
										{
											if (timeSpan4.Days > Class46.int_4)
											{
												Class46.int_4 = timeSpan4.Days;
											}
										}
										else if (timeSpan4.Days < Class46.int_4)
										{
											Class46.int_4 = timeSpan4.Days;
										}
									}
									this.method_2(registryKey26, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\IsolatedStorage\\",
										Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
										"\\",
										Class26.Class35.smethod_7(str15)
									}));
								}
								else
								{
									try
									{
										int num28 = class6.method_3(num26 - 1);
										RegistryKey registryKey27 = registryKey23.OpenSubKey(array8[num28]);
										if (registryKey27.ValueCount > 0)
										{
											string[] valueNames5 = registryKey27.GetValueNames();
											if (valueNames5.Length > 1)
											{
												registryKey27.GetValue(valueNames5[0]);
											}
										}
										registryKey27.Close();
									}
									catch
									{
									}
								}
								IL_318D:;
							}
						}
						catch
						{
						}
						if ((!flag || (flag && !flag2)) && this.class45_1.enum11_1 == (Enum11)0)
						{
							try
							{
								this.timer_0.Tick -= new EventHandler(this.timer_0_Tick);
							}
							catch
							{
							}
							try
							{
								Class46.OjFrxNjkb1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
								Class46.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
								this.timer_0 = new Timer();
								this.timer_0.Interval = 60000;
								this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
								this.timer_0.Enabled = true;
							}
							catch
							{
							}
						}
					}
					if (@class.bool_44)
					{
						if (!Class46.bool_1)
						{
							Class46.bool_1 = true;
							try
							{
								string text6 = "Software\\CLASSES\\CLSID\\";
								RegistryKey currentUser12 = Registry.CurrentUser;
								RegistryKey registryKey28 = null;
								try
								{
									registryKey28 = currentUser12.OpenSubKey(text6, true);
								}
								catch
								{
									registryKey28 = null;
								}
								Class46.Class47 class7 = new Class46.Class47();
								int num29 = class7.method_3(24);
								string[] array9 = new string[0];
								int num30 = 0;
								if (registryKey28 != null)
								{
									array9 = registryKey28.GetSubKeyNames();
									num30 = array9.Length;
								}
								int num31 = 25;
								if (registryKey28 == null)
								{
									num29 = 0;
									num31 = 1;
								}
								if (num30 < 3)
								{
									num29 = 0;
									num31 = 1;
								}
								for (int n = 0; n < num31; n++)
								{
									if (n == num29)
									{
										string str16 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
										RegistryKey registryKey29 = Registry.CurrentUser;
										if (registryKey29.OpenSubKey(text6 + str16 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), false) != null)
										{
											goto IL_36D7;
										}
										if (File.Exists(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str16)
										})))
										{
											this.method_3(string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
												"\\IsolatedStorage\\",
												Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
												"\\",
												Class26.Class35.smethod_7(str16)
											}), text6 + str16 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
											goto IL_36D7;
										}
										try
										{
											registryKey29 = Registry.LocalMachine;
											RegistryKey registryKey30 = registryKey29.OpenSubKey(text6 + str16 + Class26.smethod_29(@class.class34_0.method_4()), false);
											if (registryKey30 != null)
											{
												this.method_0(registryKey30, text6 + str16 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
											}
											goto IL_36D7;
										}
										catch
										{
											goto IL_36D7;
										}
										IL_34D0:
										RegistryKey currentUser13 = Registry.CurrentUser;
										string str17;
										RegistryKey registryKey31 = currentUser13.CreateSubKey(text6 + str17 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())));
										registryKey31.SetValue("2", Class26.smethod_33(Class46.int_3.ToString()));
										if (Class46.int_3 > @class.int_4)
										{
											flag7 = false;
											Class46.int_3 = @class.int_4 + 1;
											num3 = 0;
										}
										else
										{
											num3 = @class.int_4 - Class46.int_3;
										}
										this.method_2(registryKey31, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str17)
										}));
										goto IL_36CC;
										IL_36D7:
										str17 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
										currentUser13 = Registry.CurrentUser;
										registryKey31 = currentUser13.OpenSubKey(text6 + str17 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
										if (registryKey31 == null)
										{
											goto IL_34D0;
										}
										string string_6 = (string)registryKey31.GetValue("2");
										Class46.int_3 = Convert.ToInt32(Class26.smethod_34(string_6));
										if (!flag8)
										{
											Class46.int_3++;
											registryKey31.SetValue("2", Class26.smethod_33(Class46.int_3.ToString()));
										}
										if (Class46.int_3 > @class.int_4)
										{
											flag7 = false;
											Class46.int_3 = @class.int_4 + 1;
											num3 = 0;
										}
										else
										{
											num3 = @class.int_4 - Class46.int_3;
										}
										this.method_2(registryKey31, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\IsolatedStorage\\",
											Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())),
											"\\",
											Class26.Class35.smethod_7(str17)
										}));
									}
									else
									{
										try
										{
											int num32 = class7.method_3(num30 - 1);
											RegistryKey registryKey32 = registryKey28.OpenSubKey(array9[num32]);
											if (registryKey32.ValueCount > 0)
											{
												string[] valueNames6 = registryKey32.GetValueNames();
												if (valueNames6.Length > 1)
												{
													registryKey32.GetValue(valueNames6[0]);
												}
											}
											registryKey32.Close();
										}
										catch
										{
										}
									}
									IL_36CC:;
								}
								goto IL_37BE;
							}
							catch
							{
								goto IL_37BE;
							}
						}
						try
						{
							string str18 = "Software\\CLASSES\\CLSID\\";
							string str19 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
							RegistryKey currentUser14 = Registry.CurrentUser;
							RegistryKey registryKey33 = currentUser14.OpenSubKey(str18 + str19 + Class26.Class35.smethod_7(Class26.smethod_29(@class.class34_0.method_4())), true);
							if (registryKey33 != null)
							{
								string string_7 = (string)registryKey33.GetValue("2");
								Class46.int_3 = Convert.ToInt32(Class26.smethod_34(string_7));
								if (Class46.int_3 > @class.int_4)
								{
									flag7 = false;
									Class46.int_3 = @class.int_4 + 1;
									num3 = 0;
								}
								else
								{
									num3 = @class.int_4 - Class46.int_3;
								}
							}
						}
						catch
						{
						}
					}
					IL_37BE:
					if (Class46.class45_0.bool_33)
					{
						if (@class.bool_46)
						{
							flag11 = false;
						}
						if (@class.bool_38)
						{
							flag11 = false;
						}
						if (@class.bool_44)
						{
							flag11 = false;
						}
						if (@class.bool_46 && flag5)
						{
							flag11 = true;
						}
						if (@class.bool_38 && flag6)
						{
							flag11 = true;
						}
						if (@class.bool_44 && flag7)
						{
							flag11 = true;
						}
					}
					else
					{
						if (@class.bool_46 && !flag5)
						{
							flag11 = false;
						}
						if (@class.bool_38 && !flag6)
						{
							flag11 = false;
						}
						if (@class.bool_44 && !flag7)
						{
							flag11 = false;
						}
					}
				}
			}
			if (@class.bool_45)
			{
				string processName = Process.GetCurrentProcess().ProcessName;
				Process[] processesByName = Process.GetProcessesByName(processName);
				if (processesByName.Length > @class.int_1)
				{
					try
					{
						if (@class.bool_37)
						{
							if (@class.bool_0)
							{
								try
								{
									if (!flag)
									{
										lSfgApatkdxsVcGcrktoFd.Close();
									}
								}
								catch
								{
								}
							}
							ConstructorInfo constructor = this.type_0.GetConstructor(new Type[0]);
							object target = constructor.Invoke(new object[0]);
							this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								@class.string_16
							});
							this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								@class.color_0
							});
							this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								@class.color_1
							});
							string text7 = @class.string_23;
							text7 = text7.Replace("[current_minutes_days]", num.ToString());
							text7 = text7.Replace("[minutes_days_left]", num2.ToString());
							text7 = text7.Replace("[uses_left]", num3.ToString());
							text7 = text7.Replace("[max_minutes_days]", num4.ToString());
							text7 = text7.Replace("[max_uses]", Class46.int_1.ToString());
							text7 = text7.Replace("[max_processes]", Class46.int_2.ToString());
							text7 = text7.Replace("[current_uses]", Class46.int_3.ToString());
							this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								text7
							});
							try
							{
								this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target, new object[0]);
							}
							catch
							{
							}
						}
						Class46.TerminateProcess(Class46.GetCurrentProcess(), 1);
						License result = new Class46.Class49(this, "");
						return result;
					}
					catch
					{
					}
				}
			}
			if (@class.bool_0)
			{
				try
				{
					if (!flag)
					{
						lSfgApatkdxsVcGcrktoFd.Close();
					}
				}
				catch
				{
				}
			}
			Class50.smethod_7(flag3);
			if (@class.bool_26)
			{
				Class26.Class27.smethod_11();
				Class50.smethod_9(Class26.Class27.smethod_3(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40));
			}
			try
			{
				Class50.smethod_11(@class.string_24);
			}
			catch
			{
			}
			if (this.class45_1 != null)
			{
				Class50.smethod_38().Clear();
				IDictionaryEnumerator enumerator = this.class45_1.hashtable_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class50.smethod_38().Add(enumerator.Key.ToString(), enumerator.Value.ToString());
				}
			}
			Class50.smethod_13(@class.bool_46);
			Class50.smethod_23(@class.int_3);
			if (@class.enum11_0 == (Enum11)0)
			{
				Class50.smethod_33((Enum11)0);
				Class50.smethod_25(num);
			}
			else
			{
				Class50.smethod_33((Enum11)1);
				Class50.smethod_25(0);
			}
			try
			{
				Class50.smethod_21(@class.bool_39);
				Class50.smethod_15(@class.bool_38);
				Class50.smethod_37(@class.dateTime_0);
			}
			catch
			{
			}
			try
			{
				Class50.smethod_17(@class.bool_44);
				Class50.smethod_29(@class.int_4);
				Class50.smethod_27(Class46.int_3);
			}
			catch
			{
			}
			try
			{
				Class50.smethod_19(@class.bool_45);
				Class50.smethod_31(@class.int_1);
			}
			catch
			{
			}
			try
			{
				Class50.smethod_35(Class46.byte_0);
			}
			catch
			{
			}
			bool flag12 = false;
			if (!flag3 && !@class.bool_32)
			{
				try
				{
					if (Class46.class45_0.bool_35)
					{
						flag12 = true;
						ConstructorInfo constructor2 = this.type_0.GetConstructor(new Type[0]);
						object target2 = constructor2.Invoke(new object[0]);
						this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							@class.string_16
						});
						this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							@class.color_0
						});
						this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							@class.color_1
						});
						string text8 = @class.string_20;
						text8 = text8.Replace("[current_minutes_days]", num.ToString());
						text8 = text8.Replace("[minutes_days_left]", num2.ToString());
						text8 = text8.Replace("[uses_left]", num3.ToString());
						text8 = text8.Replace("[max_minutes_days]", num4.ToString());
						text8 = text8.Replace("[max_uses]", Class46.int_1.ToString());
						text8 = text8.Replace("[max_processes]", Class46.int_2.ToString());
						text8 = text8.Replace("[current_uses]", Class46.int_3.ToString());
						this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							text8
						});
						try
						{
							this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target2, new object[0]);
						}
						catch
						{
						}
					}
					if (@class.string_15.Length > 0)
					{
						try
						{
							if (File.Exists(Path.GetFullPath(@class.string_15)))
							{
								@class.string_15 = Path.GetFullPath(@class.string_15);
							}
							else if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(@class.string_15)))
							{
								@class.string_15 = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(@class.string_15);
							}
						}
						catch
						{
						}
						try
						{
							Process.Start(@class.string_15);
						}
						catch
						{
						}
					}
					if (@class.bool_47)
					{
						Class46.TerminateProcess(Class46.GetCurrentProcess(), 1);
						License result = new Class46.Class49(this, "");
						return result;
					}
				}
				catch
				{
				}
			}
			if (@class.bool_38 && !flag11 && !flag6)
			{
				try
				{
					if (Class46.class45_0.bool_50 && !flag12)
					{
						flag12 = true;
						ConstructorInfo constructor3 = this.type_0.GetConstructor(new Type[0]);
						object target3 = constructor3.Invoke(new object[0]);
						this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							@class.string_16
						});
						this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							@class.color_0
						});
						this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							@class.color_1
						});
						string text9 = @class.string_18;
						text9 = text9.Replace("[current_minutes_days]", num.ToString());
						text9 = text9.Replace("[minutes_days_left]", num2.ToString());
						text9 = text9.Replace("[uses_left]", num3.ToString());
						text9 = text9.Replace("[max_minutes_days]", num4.ToString());
						text9 = text9.Replace("[max_uses]", Class46.int_1.ToString());
						text9 = text9.Replace("[max_processes]", Class46.int_2.ToString());
						text9 = text9.Replace("[current_uses]", Class46.int_3.ToString());
						this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							text9
						});
						try
						{
							this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target3, new object[0]);
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			if (@class.bool_46 && !flag11 && !flag5)
			{
				if (@class.bool_46)
				{
					if (@class.enum11_0 == (Enum11)1)
					{
						flag11 = true;
						goto IL_4216;
					}
				}
				try
				{
					if (Class46.class45_0.bool_48 && !flag12)
					{
						flag12 = true;
						ConstructorInfo constructor4 = this.type_0.GetConstructor(new Type[0]);
						object target4 = constructor4.Invoke(new object[0]);
						this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							@class.string_16
						});
						this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							@class.color_0
						});
						this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							@class.color_1
						});
						string text10 = @class.string_21;
						text10 = text10.Replace("[current_minutes_days]", num.ToString());
						text10 = text10.Replace("[minutes_days_left]", num2.ToString());
						text10 = text10.Replace("[uses_left]", num3.ToString());
						text10 = text10.Replace("[max_minutes_days]", num4.ToString());
						text10 = text10.Replace("[max_uses]", Class46.int_1.ToString());
						text10 = text10.Replace("[max_processes]", Class46.int_2.ToString());
						text10 = text10.Replace("[current_uses]", Class46.int_3.ToString());
						this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							text10
						});
						try
						{
							this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target4, new object[0]);
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			IL_4216:
			if (@class.bool_49 && !flag11 && !flag7)
			{
				try
				{
					if (Class46.class45_0.bool_49 && !flag12)
					{
						flag12 = true;
						if (!Class46.bool_2)
						{
							Class46.bool_2 = true;
							ConstructorInfo constructor5 = this.type_0.GetConstructor(new Type[0]);
							object target5 = constructor5.Invoke(new object[0]);
							this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								@class.string_16
							});
							this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								@class.color_0
							});
							this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								@class.color_1
							});
							string text11 = @class.string_22;
							text11 = text11.Replace("[current_minutes_days]", num.ToString());
							text11 = text11.Replace("[minutes_days_left]", num2.ToString());
							text11 = text11.Replace("[uses_left]", num3.ToString());
							text11 = text11.Replace("[max_minutes_days]", num4.ToString());
							text11 = text11.Replace("[max_uses]", Class46.int_1.ToString());
							text11 = text11.Replace("[max_processes]", Class46.int_2.ToString());
							text11 = text11.Replace("[current_uses]", Class46.int_3.ToString());
							this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								text11
							});
							try
							{
								this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target5, new object[0]);
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
			}
			if (!flag3 && @class.bool_34)
			{
				if (!@class.bool_38 && !@class.bool_46 && !@class.bool_44 && !@class.bool_39)
				{
					if (@class.bool_32)
					{
						goto IL_4622;
					}
				}
				try
				{
					bool flag13 = true;
					if (Class46.class45_0.int_2 != -1 && Class46.int_4 > Class46.class45_0.int_2)
					{
						flag13 = false;
					}
					if (flag13 && !flag12)
					{
						flag12 = true;
						if (!flag)
						{
							ConstructorInfo constructor6 = this.type_0.GetConstructor(new Type[0]);
							object target6 = constructor6.Invoke(new object[0]);
							this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								@class.string_16
							});
							this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								@class.color_0
							});
							this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								@class.color_1
							});
							string text12 = @class.string_19;
							text12 = text12.Replace("[current_minutes_days]", num.ToString());
							text12 = text12.Replace("[minutes_days_left]", num2.ToString());
							text12 = text12.Replace("[uses_left]", num3.ToString());
							text12 = text12.Replace("[max_minutes_days]", num4.ToString());
							text12 = text12.Replace("[max_uses]", Class46.int_1.ToString());
							text12 = text12.Replace("[max_processes]", Class46.int_2.ToString());
							text12 = text12.Replace("[current_uses]", Class46.int_3.ToString());
							this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								text12
							});
							try
							{
								this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target6, new object[0]);
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
			}
			IL_4622:
			if (!flag3 && @class.bool_46 && (!flag || (flag && !flag2)))
			{
				if (@class.enum11_0 == (Enum11)1)
				{
					try
					{
						this.jnZrMnduej.Tick -= new EventHandler(this.jnZrMnduej_Tick);
					}
					catch
					{
					}
					this.jnZrMnduej = new Timer();
					this.jnZrMnduej.Interval = num4 * 60000;
					this.jnZrMnduej.Tick += new EventHandler(this.jnZrMnduej_Tick);
					this.jnZrMnduej.Enabled = true;
				}
				if (this.class45_1.enum11_1 == (Enum11)0)
				{
					try
					{
						this.timer_0.Tick -= new EventHandler(this.timer_0_Tick);
					}
					catch
					{
					}
					try
					{
						Class46.OjFrxNjkb1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
						Class46.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
						this.timer_0 = new Timer();
						this.timer_0.Interval = 60000;
						this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
						this.timer_0.Enabled = true;
					}
					catch
					{
					}
				}
			}
			if (!flag11)
			{
				if (@class.string_15.Length > 0)
				{
					try
					{
						if (File.Exists(Path.GetFullPath(@class.string_15)))
						{
							@class.string_15 = Path.GetFullPath(@class.string_15);
						}
						else if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(@class.string_15)))
						{
							@class.string_15 = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(@class.string_15);
						}
					}
					catch
					{
					}
					try
					{
						Process.Start(@class.string_15);
					}
					catch
					{
					}
				}
				if (@class.bool_47)
				{
					Class46.TerminateProcess(Class46.GetCurrentProcess(), 1);
					License result = new Class46.Class49(this, "");
					return result;
				}
			}
		}
        catch (System.Exception ex)
		{
			if (@class != null && @class.class34_0 != null && @class.class34_0.method_7() != null)
			{
				@class.class34_0.method_7().Clear();
			}
			throw ex;
		}
		return new Class46.Class49(this, "");
	}

	private bool method_5(Class26.Class45 class45_2, byte[] byte_1)
	{
		bool result;
		try
		{
			Class26.Class45 @class = new Class26.Class45();
			@class.method_23(byte_1, class45_2.bool_2, class45_2);
			bool flag = true;
			for (int i = 0; i < @class.class34_0.method_4().Length; i++)
			{
				if (@class.class34_0.method_4()[i] != class45_2.class34_0.method_4()[i])
				{
					flag = false;
				}
			}
			if (@class.class34_0.method_4().Length < 32)
			{
				flag = false;
			}
			if (!flag)
			{
				@class.method_0();
				result = false;
			}
			else
			{
				if (@class.bool_54)
				{
					Class46.string_0 = Class26.Class27.smethod_11();
					Class46.string_1 = Class26.Class27.smethod_0(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
					Class46.string_2 = Class26.Class27.smethod_1(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
					Class46.string_3 = Class26.Class27.smethod_2(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
					Class46.string_4 = Class26.Class27.smethod_3(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
					if (@class.class37_0 == null)
					{
						if (@class.string_24.Length <= 0)
						{
							@class.method_0();
							result = false;
							return result;
						}
						if (!(Class46.string_0.ToString() == @class.string_24.ToString()) && !(Class46.string_1.ToString() == @class.string_24.ToString()) && !(Class46.string_2.ToString() == @class.string_24.ToString()) && !(Class46.string_3.ToString() == @class.string_24.ToString()) && !(Class46.string_4.ToString() == @class.string_24.ToString()))
						{
							@class.method_0();
							result = false;
							return result;
						}
						if (this.class45_1 != null)
						{
							this.class45_1.method_0();
						}
						this.class45_1 = @class;
						try
						{
							Class46.byte_0 = byte_1;
						}
						catch
						{
						}
						result = true;
						return result;
					}
					else if (@class.string_24.Length > 0)
					{
						if (!(Class46.string_0.ToString() == @class.string_24.ToString()) && !(Class46.string_1.ToString() == @class.string_24.ToString()) && !(Class46.string_2.ToString() == @class.string_24.ToString()) && !(Class46.string_3.ToString() == @class.string_24.ToString()) && !(Class46.string_4.ToString() == @class.string_24.ToString()))
						{
							@class.method_0();
							result = false;
							return result;
						}
						if (this.class45_1 != null)
						{
							this.class45_1.method_0();
						}
						this.class45_1 = @class;
						try
						{
							Class46.byte_0 = byte_1;
						}
						catch
						{
						}
						result = true;
						return result;
					}
					else
					{
						Class26.Class37 class2 = Class26.smethod_25();
						if (class2.method_0().Count != @class.class37_0.method_0().Count)
						{
							@class.method_0();
							result = false;
							return result;
						}
						for (int j = 0; j < class2.method_0().Count; j++)
						{
							Class26.Class40 class3 = class2.method_0().method_0(j);
							Class26.Class40 class4 = @class.class37_0.method_0().method_0(j);
							if (class3.method_2() != class4.method_2())
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (class3.method_0().Trim().ToString() != class4.method_0().Trim().ToString())
							{
								@class.method_0();
								result = false;
								return result;
							}
							for (int k = 0; k < class3.method_2(); k++)
							{
								if (class3.method_4(k).method_2() != null && class4.method_4(k).method_2() != null && class3.method_4(k).method_2().Trim().ToString() != class4.method_4(k).method_2().Trim().ToString())
								{
									@class.method_0();
									result = false;
									return result;
								}
							}
						}
					}
				}
				if (this.class45_1 != null)
				{
					this.class45_1.method_0();
				}
				this.class45_1 = @class;
				try
				{
					Class46.byte_0 = byte_1;
				}
				catch
				{
				}
				result = true;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private bool method_6(Class26.Class45 class45_2, string string_6)
	{
		if (class45_2.string_10.Length > 0 && class45_2.string_10.IndexOf("*") < 0)
		{
			if (File.Exists(string_6 + "\\" + class45_2.string_10))
			{
				try
				{
					Class26.Class45 @class = new Class26.Class45();
					@class.method_22(string_6 + "\\" + class45_2.string_10, class45_2.bool_2, class45_2);
					bool flag = true;
					for (int i = 0; i < @class.class34_0.method_4().Length; i++)
					{
						if (@class.class34_0.method_4()[i] != class45_2.class34_0.method_4()[i])
						{
							flag = false;
						}
					}
					if (@class.class34_0.method_4().Length < 32)
					{
						flag = false;
					}
					bool result;
					if (!flag)
					{
						@class.method_0();
						result = false;
						return result;
					}
					if (@class.bool_54)
					{
						Class46.string_0 = Class26.Class27.smethod_11();
						Class46.string_1 = Class26.Class27.smethod_0(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						Class46.string_2 = Class26.Class27.smethod_1(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						Class46.string_3 = Class26.Class27.smethod_2(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						Class46.string_4 = Class26.Class27.smethod_3(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						if (@class.class37_0 == null)
						{
							if (@class.string_24.Length <= 0)
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (!(Class46.string_0.ToString() == @class.string_24.ToString()) && !(Class46.string_1.ToString() == @class.string_24.ToString()) && !(Class46.string_2.ToString() == @class.string_24.ToString()) && !(Class46.string_3.ToString() == @class.string_24.ToString()) && !(Class46.string_4.ToString() == @class.string_24.ToString()))
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = @class;
							try
							{
								Class46.byte_0 = this.method_8(string_6 + "\\" + class45_2.string_10);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else if (@class.string_24.Length > 0)
						{
							if (!(Class46.string_0.ToString() == @class.string_24.ToString()) && !(Class46.string_1.ToString() == @class.string_24.ToString()) && !(Class46.string_2.ToString() == @class.string_24.ToString()) && !(Class46.string_3.ToString() == @class.string_24.ToString()) && !(Class46.string_4.ToString() == @class.string_24.ToString()))
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = @class;
							try
							{
								Class46.byte_0 = this.method_8(string_6 + "\\" + class45_2.string_10);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else
						{
							Class26.Class37 class2 = Class26.smethod_25();
							if (class2.method_0().Count != @class.class37_0.method_0().Count)
							{
								@class.method_0();
								result = false;
								return result;
							}
							for (int j = 0; j < class2.method_0().Count; j++)
							{
								Class26.Class40 class3 = class2.method_0().method_0(j);
								Class26.Class40 class4 = @class.class37_0.method_0().method_0(j);
								if (class3.method_2() != class4.method_2())
								{
									@class.method_0();
									result = false;
									return result;
								}
								if (class3.method_0().Trim().ToString() != class4.method_0().Trim().ToString())
								{
									@class.method_0();
									result = false;
									return result;
								}
								for (int k = 0; k < class3.method_2(); k++)
								{
									if (class3.method_4(k).method_2() != null && class4.method_4(k).method_2() != null && class3.method_4(k).method_2().Trim().ToString() != class4.method_4(k).method_2().Trim().ToString())
									{
										@class.method_0();
										result = false;
										return result;
									}
								}
							}
						}
					}
					if (this.class45_1 != null)
					{
						this.class45_1.method_0();
					}
					this.class45_1 = @class;
					try
					{
						Class46.byte_0 = this.method_8(string_6 + "\\" + class45_2.string_10);
					}
					catch
					{
					}
					result = true;
					return result;
				}
				catch
				{
					bool result = false;
					return result;
				}
			}
			return false;
		}
		string searchPattern = "*.license";
		if (class45_2.string_10.Length > 0)
		{
			searchPattern = class45_2.string_10;
		}
		string[] files = Directory.GetFiles(string_6, searchPattern);
		for (int l = 0; l < files.Length; l++)
		{
			try
			{
				Class26.Class45 class5 = new Class26.Class45();
				class5.method_22(files[l], class45_2.bool_2, class45_2);
				bool flag2 = true;
				for (int m = 0; m < class5.class34_0.method_4().Length; m++)
				{
					if (class45_2.class34_0.method_4()[m] != class5.class34_0.method_4()[m])
					{
						flag2 = false;
					}
				}
				if (class5.class34_0.method_4().Length < 32)
				{
					flag2 = false;
				}
				if (flag2)
				{
					bool result;
					if (class5.bool_54)
					{
						Class46.string_0 = Class26.Class27.smethod_11();
						Class46.string_1 = Class26.Class27.smethod_0(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						Class46.string_2 = Class26.Class27.smethod_1(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						Class46.string_3 = Class26.Class27.smethod_2(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						Class46.string_4 = Class26.Class27.smethod_3(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						if (class5.class37_0 == null)
						{
							if (class5.string_24.Length <= 0)
							{
								class5.method_0();
								result = false;
								return result;
							}
							if (!(Class46.string_0.ToString() == class5.string_24.ToString()) && !(Class46.string_1.ToString() == class5.string_24.ToString()) && !(Class46.string_2.ToString() == class5.string_24.ToString()) && !(Class46.string_3.ToString() == class5.string_24.ToString()) && !(Class46.string_4.ToString() == class5.string_24.ToString()))
							{
								class5.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = class5;
							try
							{
								Class46.byte_0 = this.method_8(files[l]);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else if (class5.string_24.Length > 0)
						{
							if (!(Class46.string_0.ToString() == class5.string_24.ToString()) && !(Class46.string_1.ToString() == class5.string_24.ToString()) && !(Class46.string_2.ToString() == class5.string_24.ToString()) && !(Class46.string_3.ToString() == class5.string_24.ToString()) && !(Class46.string_4.ToString() == class5.string_24.ToString()))
							{
								class5.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = class5;
							try
							{
								Class46.byte_0 = this.method_8(files[l]);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else
						{
							Class26.Class37 class6 = Class26.smethod_25();
							if (class6.method_0().Count != class5.class37_0.method_0().Count)
							{
								class5.method_0();
								result = false;
								return result;
							}
							for (int n = 0; n < class6.method_0().Count; n++)
							{
								Class26.Class40 class7 = class6.method_0().method_0(n);
								Class26.Class40 class8 = class5.class37_0.method_0().method_0(n);
								if (class7.method_2() != class8.method_2())
								{
									class5.method_0();
									result = false;
									return result;
								}
								if (class7.method_0().Trim().ToString() != class8.method_0().Trim().ToString())
								{
									class5.method_0();
									result = false;
									return result;
								}
								for (int num = 0; num < class7.method_2(); num++)
								{
									if (class7.method_4(num).method_2() != null && class8.method_4(num).method_2() != null && class7.method_4(num).method_2().Trim().ToString() != class8.method_4(num).method_2().Trim().ToString())
									{
										class5.method_0();
										result = false;
										return result;
									}
								}
							}
						}
					}
					if (this.class45_1 != null)
					{
						this.class45_1.method_0();
					}
					this.class45_1 = class5;
					try
					{
						Class46.byte_0 = this.method_8(files[l]);
					}
					catch
					{
					}
					result = true;
					return result;
				}
				class5.method_0();
			}
			catch
			{
			}
		}
		return false;
	}

	private bool method_7(Class26.Class45 class45_2)
	{
		if (class45_2.string_10.Length > 0 && class45_2.string_10.IndexOf("*") < 0)
		{
			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class45_2.string_10))
			{
				try
				{
					Class26.Class45 @class = new Class26.Class45();
					@class.method_22(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class45_2.string_10, class45_2.bool_2, class45_2);
					bool flag = true;
					for (int i = 0; i < @class.class34_0.method_4().Length; i++)
					{
						if (class45_2.class34_0.method_4()[i] != @class.class34_0.method_4()[i])
						{
							flag = false;
						}
					}
					if (@class.class34_0.method_4().Length < 32)
					{
						flag = false;
					}
					bool result;
					if (!flag)
					{
						@class.method_0();
						result = false;
						return result;
					}
					if (@class.bool_54)
					{
						Class46.string_0 = Class26.Class27.smethod_11();
						Class46.string_1 = Class26.Class27.smethod_0(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						Class46.string_2 = Class26.Class27.smethod_1(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						Class46.string_3 = Class26.Class27.smethod_2(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						Class46.string_4 = Class26.Class27.smethod_3(@class.bool_43, @class.bool_41, @class.bool_42, @class.bool_40);
						if (@class.class37_0 == null)
						{
							if (@class.string_24.Length <= 0)
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (!(Class46.string_0.ToString() == @class.string_24.ToString()) && !(Class46.string_1.ToString() == @class.string_24.ToString()) && !(Class46.string_2.ToString() == @class.string_24.ToString()) && !(Class46.string_3.ToString() == @class.string_24.ToString()) && !(Class46.string_4.ToString() == @class.string_24.ToString()))
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = @class;
							try
							{
								Class46.byte_0 = this.method_8(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class45_2.string_10);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else if (@class.string_24.Length > 0)
						{
							if (!(Class46.string_0.ToString() == @class.string_24.ToString()) && !(Class46.string_1.ToString() == @class.string_24.ToString()) && !(Class46.string_2.ToString() == @class.string_24.ToString()) && !(Class46.string_3.ToString() == @class.string_24.ToString()) && !(Class46.string_4.ToString() == @class.string_24.ToString()))
							{
								@class.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = @class;
							try
							{
								Class46.byte_0 = this.method_8(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class45_2.string_10);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else
						{
							Class26.Class37 class2 = Class26.smethod_25();
							if (class2.method_0().Count != @class.class37_0.method_0().Count)
							{
								@class.method_0();
								result = false;
								return result;
							}
							for (int j = 0; j < class2.method_0().Count; j++)
							{
								Class26.Class40 class3 = class2.method_0().method_0(j);
								Class26.Class40 class4 = @class.class37_0.method_0().method_0(j);
								if (class3.method_2() != class4.method_2())
								{
									@class.method_0();
									result = false;
									return result;
								}
								if (class3.method_0().Trim().ToString() != class4.method_0().Trim().ToString())
								{
									@class.method_0();
									result = false;
									return result;
								}
								for (int k = 0; k < class3.method_2(); k++)
								{
									if (class3.method_4(k).method_2() != null && class4.method_4(k).method_2() != null && class3.method_4(k).method_2().Trim().ToString() != class4.method_4(k).method_2().Trim().ToString())
									{
										@class.method_0();
										result = false;
										return result;
									}
								}
							}
						}
					}
					if (this.class45_1 != null)
					{
						this.class45_1.method_0();
					}
					this.class45_1 = @class;
					try
					{
						Class46.byte_0 = this.method_8(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class45_2.string_10);
					}
					catch
					{
					}
					result = true;
					return result;
				}
				catch
				{
					bool result = false;
					return result;
				}
			}
			return false;
		}
		string searchPattern = "*.license";
		if (class45_2.string_10.Length > 0)
		{
			searchPattern = class45_2.string_10;
		}
		string[] files = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath), searchPattern);
		for (int l = 0; l < files.Length; l++)
		{
			try
			{
				Class26.Class45 class5 = new Class26.Class45();
				class5.method_22(files[l], class45_2.bool_2, class45_2);
				bool flag2 = true;
				for (int m = 0; m < class5.class34_0.method_4().Length; m++)
				{
					if (class45_2.class34_0.method_4()[m] != class5.class34_0.method_4()[m])
					{
						flag2 = false;
					}
				}
				if (class5.class34_0.method_4().Length < 32)
				{
					flag2 = false;
				}
				if (flag2)
				{
					bool result;
					if (class5.bool_54)
					{
						Class46.string_0 = Class26.Class27.smethod_11();
						Class46.string_1 = Class26.Class27.smethod_0(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						Class46.string_2 = Class26.Class27.smethod_1(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						Class46.string_3 = Class26.Class27.smethod_2(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						Class46.string_4 = Class26.Class27.smethod_3(class5.bool_43, class5.bool_41, class5.bool_42, class5.bool_40);
						if (class5.class37_0 == null)
						{
							if (class5.string_24.Length <= 0)
							{
								class5.method_0();
								result = false;
								return result;
							}
							if (!(Class46.string_0.ToString() == class5.string_24.ToString()) && !(Class46.string_1.ToString() == class5.string_24.ToString()) && !(Class46.string_2.ToString() == class5.string_24.ToString()) && !(Class46.string_3.ToString() == class5.string_24.ToString()) && !(Class46.string_4.ToString() == class5.string_24.ToString()))
							{
								class5.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = class5;
							try
							{
								Class46.byte_0 = this.method_8(files[l]);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else if (class5.string_24.Length > 0)
						{
							if (!(Class46.string_0.ToString() == class5.string_24.ToString()) && !(Class46.string_1.ToString() == class5.string_24.ToString()) && !(Class46.string_2.ToString() == class5.string_24.ToString()) && !(Class46.string_3.ToString() == class5.string_24.ToString()) && !(Class46.string_4.ToString() == class5.string_24.ToString()))
							{
								class5.method_0();
								result = false;
								return result;
							}
							if (this.class45_1 != null)
							{
								this.class45_1.method_0();
							}
							this.class45_1 = class5;
							try
							{
								Class46.byte_0 = this.method_8(files[l]);
							}
							catch
							{
							}
							result = true;
							return result;
						}
						else
						{
							Class26.Class37 class6 = Class26.smethod_25();
							if (class6.method_0().Count != class5.class37_0.method_0().Count)
							{
								class5.method_0();
								result = false;
								return result;
							}
							for (int n = 0; n < class6.method_0().Count; n++)
							{
								Class26.Class40 class7 = class6.method_0().method_0(n);
								Class26.Class40 class8 = class5.class37_0.method_0().method_0(n);
								if (class7.method_2() != class8.method_2())
								{
									class5.method_0();
									result = false;
									return result;
								}
								if (class7.method_0().Trim().ToString() != class8.method_0().Trim().ToString())
								{
									class5.method_0();
									result = false;
									return result;
								}
								for (int num = 0; num < class7.method_2(); num++)
								{
									if (class7.method_4(num).method_2() != null && class8.method_4(num).method_2() != null && class7.method_4(num).method_2().Trim().ToString() != class8.method_4(num).method_2().Trim().ToString())
									{
										class5.method_0();
										result = false;
										return result;
									}
								}
							}
						}
					}
					if (this.class45_1 != null)
					{
						this.class45_1.method_0();
					}
					this.class45_1 = class5;
					try
					{
						Class46.byte_0 = this.method_8(files[l]);
					}
					catch
					{
					}
					result = true;
					return result;
				}
				class5.method_0();
			}
			catch
			{
			}
		}
		return false;
	}

	private byte[] method_8(string string_6)
	{
		FileStream fileStream = new FileStream(string_6, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		return array;
	}

	internal static bool smethod_0(string string_6, string string_7)
	{
		return Class26.smethod_30(string_6, Class46.class45_0.class34_0.method_4()).ToString() == string_7.ToString();
	}

	internal static bool smethod_1(string string_6)
	{
		bool result;
		try
		{
			string b = Class26.Class27.smethod_11();
			string b2 = Class26.Class27.smethod_0(Class46.class45_0.bool_43, Class46.class45_0.bool_41, Class46.class45_0.bool_42, Class46.class45_0.bool_40);
			string b3 = Class26.Class27.smethod_1(Class46.class45_0.bool_43, Class46.class45_0.bool_41, Class46.class45_0.bool_42, Class46.class45_0.bool_40);
			string b4 = Class26.Class27.smethod_2(Class46.class45_0.bool_43, Class46.class45_0.bool_41, Class46.class45_0.bool_42, Class46.class45_0.bool_40);
			string b5 = Class26.Class27.smethod_3(Class46.class45_0.bool_43, Class46.class45_0.bool_41, Class46.class45_0.bool_42, Class46.class45_0.bool_40);
			string[] array = Class26.smethod_32(string_6, Class46.class45_0.class34_0.method_4()).Split(new char[]
			{
				'|'
			});
			string text = array[1];
			string text2 = array[0] + array[2] + array[0] + array[2];
			bool flag = false;
			if (!(text == b) && !(text == b2) && !(text == b3) && !(text == b4) && !(text == b5))
			{
				result = false;
			}
			else
			{
				try
				{
					string text3 = "Software\\CLASSES\\CLSID\\";
					RegistryKey localMachine = Registry.LocalMachine;
					RegistryKey registryKey = localMachine.OpenSubKey(string.Concat(new string[]
					{
						text3,
						"{",
						text2,
						"-826F8-31C4-2C1E-14A4",
						Class26.Class35.smethod_7(text),
						"}\\"
					}), false);
					if (registryKey != null)
					{
						flag = true;
					}
				}
				catch
				{
				}
				try
				{
					string text4 = "Software\\CLASSES\\CLSID\\";
					RegistryKey currentUser = Registry.CurrentUser;
					RegistryKey registryKey2 = currentUser.OpenSubKey(string.Concat(new string[]
					{
						text4,
						"{",
						text2,
						"-826F8-31C4-2C1E-14A4",
						Class26.Class35.smethod_7(text),
						"}\\"
					}), false);
					if (registryKey2 != null)
					{
						flag = true;
					}
				}
				catch
				{
				}
				try
				{
					string str = Class26.Class35.smethod_7(Class26.smethod_0("{O33BAC75-826F8-31C4-2C1E-14A484D53587}" + Class26.smethod_29(Class46.class45_0.class34_0.method_4()) + text + text2));
					if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\IsolatedStorage\\" + str))
					{
						flag = true;
					}
				}
				catch
				{
				}
				if (flag)
				{
					result = false;
				}
				else
				{
					try
					{
						string text5 = "Software\\CLASSES\\CLSID\\";
						RegistryKey localMachine2 = Registry.LocalMachine;
						localMachine2.CreateSubKey(string.Concat(new string[]
						{
							text5,
							"{",
							text2,
							"-826F8-31C4-2C1E-14A4",
							Class26.Class35.smethod_7(text),
							"}\\"
						}));
						localMachine2.Close();
					}
					catch
					{
					}
					try
					{
						string text6 = "Software\\CLASSES\\CLSID\\";
						RegistryKey currentUser2 = Registry.CurrentUser;
						currentUser2.CreateSubKey(string.Concat(new string[]
						{
							text6,
							"{",
							text2,
							"-826F8-31C4-2C1E-14A4",
							Class26.Class35.smethod_7(text),
							"}\\"
						}));
						currentUser2.Close();
					}
					catch
					{
					}
					try
					{
						string str2 = Class26.Class35.smethod_7(Class26.smethod_0("{O33BAC75-826F8-31C4-2C1E-14A484D53587}" + Class26.smethod_29(Class46.class45_0.class34_0.method_4()) + text + text2));
						Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\IsolatedStorage\\" + str2);
					}
					catch
					{
					}
					try
					{
						string str3 = "Software\\CLASSES\\CLSID\\";
						string str4 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey localMachine3 = Registry.LocalMachine;
						localMachine3.DeleteSubKey(str3 + str4 + Class26.smethod_29(Class46.class45_0.class34_0.method_4()), false);
					}
					catch
					{
					}
					try
					{
						string str5 = "Software\\CLASSES\\CLSID\\";
						string str6 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey currentUser3 = Registry.CurrentUser;
						currentUser3.DeleteSubKey(str5 + str6 + Class26.Class35.smethod_7(Class26.smethod_29(Class46.class45_0.class34_0.method_4())), false);
					}
					catch
					{
					}
					try
					{
						string str7 = Class26.Class35.smethod_7(Class26.smethod_0("{Y3358E75-826A3-31A5-2C1E-14A484D53571}" + Class26.smethod_29(Class46.class45_0.class34_0.method_4())));
						Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\IsolatedStorage\\" + str7);
					}
					catch
					{
					}
					result = true;
				}
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	internal static void smethod_2(byte[] byte_1)
	{
		Class46.string_5.ToString();
		new Class46().method_4(byte_1);
	}

	internal static string smethod_3()
	{
		string result = "";
		try
		{
			try
			{
				string str = "Software\\CLASSES\\CLSID\\";
				string str2 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
				RegistryKey localMachine = Registry.LocalMachine;
				localMachine.CreateSubKey(str + str2 + Class26.smethod_29(Class46.class45_0.class34_0.method_4()));
			}
			catch
			{
			}
			try
			{
				string str3 = "Software\\CLASSES\\CLSID\\";
				string str4 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
				RegistryKey currentUser = Registry.CurrentUser;
				currentUser.CreateSubKey(str3 + str4 + Class26.Class35.smethod_7(Class26.smethod_29(Class46.class45_0.class34_0.method_4())));
			}
			catch
			{
			}
			try
			{
				string str5 = Class26.Class35.smethod_7(Class26.smethod_0("{Y3358E75-826A3-31A5-2C1E-14A484D53571}" + Class26.smethod_29(Class46.class45_0.class34_0.method_4())));
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\IsolatedStorage\\" + str5);
			}
			catch
			{
			}
			try
			{
				string string_ = Class26.Class27.smethod_3(Class46.class45_0.bool_43, Class46.class45_0.bool_41, Class46.class45_0.bool_42, Class46.class45_0.bool_40);
				result = Class26.smethod_30(string_, Class46.class45_0.class34_0.method_4());
			}
			catch
			{
			}
		}
		catch
		{
		}
		return result;
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern bool TerminateProcess(IntPtr intptr_0, int int_6);

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (Class46.dateTime_0 != new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
		{
			Class46.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			new Class46().method_4(new byte[]
			{
				1
			});
		}
	}

	private static bool bool_0;

	private static bool bool_1;

	private static bool bool_2;

	private static byte[] byte_0;

	internal static Class26.Class45 class45_0;

	private Class26.Class45 class45_1 = new Class26.Class45();

	private static DateTime dateTime_0;

	private static int int_0;

	private static int int_1;

	private static int int_2;

	private static int int_3;

	private static int int_4;

	private static int int_5;

	private Timer jnZrMnduej;

	private static DateTime OjFrxNjkb1;

	private static string string_0;

	private static string string_1;

	private static string string_2;

	private static string string_3;

	private static string string_4;

	private static string string_5;

	private Timer timer_0;

	private Type type_0;

	internal sealed class Class47
	{
		public Class47()
		{
			this.method_0(Environment.TickCount);
		}

		public Class47(int int_1)
		{
			this.method_0(int_1);
		}

		public void method_0(int int_1)
		{
			this.uint_3 = (uint)int_1;
			this.uint_4 = 842502087u;
			this.uint_5 = 3579807591u;
			this.uint_6 = 273326509u;
		}

		public uint method_1()
		{
			uint num = this.uint_3 ^ this.uint_3 << 11;
			this.uint_3 = this.uint_4;
			this.uint_4 = this.uint_5;
			this.uint_5 = this.uint_6;
			return this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8));
		}

		public int method_2()
		{
			uint num = this.uint_3 ^ this.uint_3 << 11;
			this.uint_3 = this.uint_4;
			this.uint_4 = this.uint_5;
			this.uint_5 = this.uint_6;
			return (int)(2147483647u & (this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8))));
		}

		public int method_3(int int_1)
		{
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("upperBound", int_1, "upperBound must be >=0");
			}
			uint num = this.uint_3 ^ this.uint_3 << 11;
			this.uint_3 = this.uint_4;
			this.uint_4 = this.uint_5;
			this.uint_5 = this.uint_6;
			return (int)(4.6566128730773926E-10 * (double)(2147483647u & (this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8)))) * (double)int_1);
		}

		public int method_4(int int_1, int int_2)
		{
			if (int_1 > int_2)
			{
				throw new ArgumentOutOfRangeException("upperBound", int_2, "upperBound must be >=lowerBound");
			}
			uint num = this.uint_3 ^ this.uint_3 << 11;
			this.uint_3 = this.uint_4;
			this.uint_4 = this.uint_5;
			this.uint_5 = this.uint_6;
			int num2 = int_2 - int_1;
			if (num2 < 0)
			{
				return int_1 + (int)(2.3283064365386963E-10 * (this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8))) * (double)((long)int_2 - (long)int_1));
			}
			return int_1 + (int)(4.6566128730773926E-10 * (double)(2147483647u & (this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8)))) * (double)num2);
		}

		public double method_5()
		{
			uint num = this.uint_3 ^ this.uint_3 << 11;
			this.uint_3 = this.uint_4;
			this.uint_4 = this.uint_5;
			this.uint_5 = this.uint_6;
			return 4.6566128730773926E-10 * (double)(2147483647u & (this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8))));
		}

		public void method_6(byte[] byte_0)
		{
			uint num = this.uint_3;
			uint num2 = this.uint_4;
			uint num3 = this.uint_5;
			uint num4 = this.uint_6;
			int i = 0;
			while (i < byte_0.Length - 3)
			{
				uint num5 = num ^ num << 11;
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num4 ^ num4 >> 19 ^ (num5 ^ num5 >> 8));
				byte_0[i++] = (byte)(num4 & 255u);
				byte_0[i++] = (byte)((num4 & 65280u) >> 8);
				byte_0[i++] = (byte)((num4 & 16711680u) >> 16);
				byte_0[i++] = (byte)((num4 & 4278190080u) >> 24);
			}
			if (i < byte_0.Length)
			{
				uint num5 = num ^ num << 11;
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num4 ^ num4 >> 19 ^ (num5 ^ num5 >> 8));
				byte_0[i++] = (byte)(num4 & 255u);
				if (i < byte_0.Length)
				{
					byte_0[i++] = (byte)((num4 & 65280u) >> 8);
					if (i < byte_0.Length)
					{
						byte_0[i++] = (byte)((num4 & 16711680u) >> 16);
						if (i < byte_0.Length)
						{
							byte_0[i] = (byte)((num4 & 4278190080u) >> 24);
						}
					}
				}
			}
			this.uint_3 = num;
			this.uint_4 = num2;
			this.uint_5 = num3;
			this.uint_6 = num4;
		}

		public bool method_7()
		{
			if (this.int_0 == 32)
			{
				uint num = this.uint_3 ^ this.uint_3 << 11;
				this.uint_3 = this.uint_4;
				this.uint_4 = this.uint_5;
				this.uint_5 = this.uint_6;
				this.uint_7 = (this.uint_6 = (this.uint_6 ^ this.uint_6 >> 19 ^ (num ^ num >> 8)));
				this.int_0 = 1;
				return (this.uint_7 & 1u) == 1u;
			}
			this.int_0++;
			return ((this.uint_7 >>= 1) & 1u) == 1u;
		}

		private const double double_0 = 4.6566128730773926E-10;

		private const double double_1 = 2.3283064365386963E-10;

		private int int_0 = 32;

		private const uint uint_0 = 842502087u;

		private const uint uint_1 = 3579807591u;

		private const uint uint_2 = 273326509u;

		private uint uint_3;

		private uint uint_4;

		private uint uint_5;

		private uint uint_6;

		private uint uint_7;
	}

	//[LicenseProvider(typeof(Class46))]
	private class Class48
	{
		public Class48()
		{
		}

		private void method_0()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(Class46));
		}
	}

	private class Class49 : License
	{
		public Class49(object object_1, string string_1)
		{
			this.object_0 = object_1;
			this.string_0 = string_1;
		}

		public override void Dispose()
		{
		}

		public override string LicenseKey
		{
			get
			{
				return this.string_0;
			}
		}

		private object object_0;

		private string string_0;
	}
}
