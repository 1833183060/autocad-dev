using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

internal sealed class Class26
{
	static Class26()
	{
		Class26.string_3 = "";
		Class26.bool_0 = false;
		Class26.string_4 = "";
		Class26.bool_1 = false;
		Class26.string_5 = "";
		Class26.bool_2 = false;
		Class26.string_6 = "";
		Class26.bool_3 = false;
		Class26.string_7 = "";
		Class26.bool_4 = false;
		Class26.string_8 = "";
		Class26.bool_5 = false;
		Class26.string_9 = "";
		Class26.bool_6 = false;
		Class26.string_10 = "";
		Class26.bool_7 = false;
		Class26.string_11 = "";
		Class26.bool_8 = false;
		Class26.string_12 = "";
		Class26.bool_9 = false;
		Class26.string_13 = "";
		Class26.bool_10 = false;
		Class26.string_14 = "";
		Class26.bool_11 = false;
	}

	public Class26()
	{
		this.UrexXhPeB = "kl§$%7ghJ/()3w45ZZHW$5$%&gwSADF2";
		this.string_1 = "sd§5$§&g457!23nm";
		this.string_0 = "($)(/)()=fg55jm,§98*jgt65=§C33$t";
		this.string_2 = "g&5§$§7!s3nm42d5";
	}

	internal void method_0()
	{
		string text = "{12211-22232-40001-0123}";
		if (text.Length == 12)
		{
			text += "c";
		}
	}

	public byte[] method_1(string string_15, bool bool_12)
	{
		FileStream fileStream = new FileStream(string_15, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		fileStream.Close();
		return this.method_5(memoryStream, bool_12);
	}

	public byte[] method_10(MemoryStream memoryStream_0, bool bool_12)
	{
		try
		{
			string urexXhPeB = this.UrexXhPeB;
			string text = this.string_1;
			if (bool_12)
			{
				urexXhPeB = this.string_0;
				text = this.string_2;
			}
			byte[] array = new byte[urexXhPeB.Length];
			for (int i = 0; i < urexXhPeB.Length; i++)
			{
				array[i] = Convert.ToByte(urexXhPeB[i]);
			}
			byte[] array2 = new byte[text.Length];
			for (int j = 0; j < text.Length; j++)
			{
				array2[j] = Convert.ToByte(text[j]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array3 = memoryStream_0.ToArray();
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	public byte[] method_11(MemoryStream memoryStream_0, byte[] byte_0, bool bool_12)
	{
		try
		{
			string text = this.string_1;
			if (bool_12)
			{
				text = this.string_2;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(byte_0, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array2 = memoryStream_0.ToArray();
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	public byte[] method_12(byte[] byte_0, byte[] byte_1)
	{
		try
		{
			string text = this.string_1;
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(byte_1, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	public byte[] method_13(MemoryStream memoryStream_0, byte[] byte_0)
	{
		try
		{
			string text = this.string_1;
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(byte_0, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array2 = memoryStream_0.ToArray();
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	public MemoryStream method_14(MemoryStream memoryStream_0, bool bool_12)
	{
		try
		{
			string urexXhPeB = this.UrexXhPeB;
			string text = this.string_1;
			if (bool_12)
			{
				urexXhPeB = this.string_0;
				text = this.string_2;
			}
			byte[] array = new byte[urexXhPeB.Length];
			for (int i = 0; i < urexXhPeB.Length; i++)
			{
				array[i] = Convert.ToByte(urexXhPeB[i]);
			}
			byte[] array2 = new byte[text.Length];
			for (int j = 0; j < text.Length; j++)
			{
				array2[j] = Convert.ToByte(text[j]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array3 = memoryStream_0.ToArray();
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			memoryStream.Close();
			cryptoStream.Close();
			return memoryStream;
		}
		catch
		{
		}
		return null;
	}

	public byte[] method_15()
	{
		Class26.Class37 @class = new Class26.Class37();
		ManagementClass managementClass = new ManagementClass("Win32_BIOS");
		ManagementObjectCollection instances = managementClass.GetInstances();
		using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)enumerator.Current;
				Class26.Class40 class2 = new Class26.Class40("BIOS");
				if (managementObject.Properties["Manufacturer"].Value != null)
				{
					class2.method_7("Manufacturer", managementObject.Properties["Manufacturer"].Value.ToString(), "");
				}
				else
				{
					class2.method_7("Manufacturer", "", "");
				}
				if (managementObject.Properties["Version"].Value != null)
				{
					class2.method_7("Version", managementObject.Properties["Version"].Value.ToString(), "");
				}
				else
				{
					class2.method_7("Version", "", "");
				}
				if (managementObject.Properties["SMBIOSBIOSVersion"].Value != null)
				{
					class2.method_7("SMBIOSBIOSVersion", managementObject.Properties["SMBIOSBIOSVersion"].Value.ToString(), "");
				}
				else
				{
					class2.method_7("SMBIOSBIOSVersion", "", "");
				}
				@class.method_0().method_2(class2);
			}
		}
		managementClass = new ManagementClass("Win32_BaseBoard");
		instances = managementClass.GetInstances();
		using (ManagementObjectCollection.ManagementObjectEnumerator enumerator2 = instances.GetEnumerator())
		{
			if (enumerator2.MoveNext())
			{
				ManagementObject managementObject2 = (ManagementObject)enumerator2.Current;
				Class26.Class40 class3 = new Class26.Class40("BOARD");
				if (managementObject2.Properties["Manufacturer"].Value != null)
				{
					class3.method_7("Manufacturer", managementObject2.Properties["Manufacturer"].Value.ToString(), "");
				}
				else
				{
					class3.method_7("Manufacturer", "", "");
				}
				@class.method_0().method_2(class3);
			}
		}
		managementClass = new ManagementClass("Win32_Processor");
		instances = managementClass.GetInstances();
		using (ManagementObjectCollection.ManagementObjectEnumerator enumerator3 = instances.GetEnumerator())
		{
			if (enumerator3.MoveNext())
			{
				ManagementObject managementObject3 = (ManagementObject)enumerator3.Current;
				Class26.Class40 class4 = new Class26.Class40("PROCESSOR");
				if (managementObject3.Properties["Manufacturer"].Value != null)
				{
					class4.method_7("Manufacturer", managementObject3.Properties["Manufacturer"].Value.ToString(), "");
				}
				else
				{
					class4.method_7("Manufacturer", "", "");
				}
				if (managementObject3.Properties["Name"].Value != null)
				{
					class4.method_7("Name", managementObject3.Properties["Name"].Value.ToString(), "");
				}
				else
				{
					class4.method_7("Name", "", "");
				}
				if (managementObject3.Properties["ProcessorId"].Value != null)
				{
					class4.method_7("ProcessorId", managementObject3.Properties["ProcessorId"].Value.ToString(), "");
				}
				else
				{
					class4.method_7("ProcessorId", "", "");
				}
				@class.method_0().method_2(class4);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter textWriter_ = new StreamWriter(memoryStream);
		@class.method_1(textWriter_);
		return memoryStream.ToArray();
	}

	public string method_16()
	{
		byte[] array = this.method_15();
		string text = "";
		for (int i = 0; i < array.Length; i++)
		{
			text += array[i].ToString("D3");
		}
		return text;
	}

	public void method_2(string string_15, string string_16)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_15);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(bytes, 0, bytes.Length);
		byte[] array = this.method_5(memoryStream, true);
		Directory.CreateDirectory(Path.GetDirectoryName(string_16));
		FileStream fileStream = new FileStream(string_16, FileMode.Create, FileAccess.ReadWrite);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
	}

	public string method_3(string string_15)
	{
		FileStream fileStream = new FileStream(string_15, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		byte[] array2 = this.method_10(memoryStream, true);
		return Encoding.Unicode.GetString(array2, 0, array2.Length);
	}

	public byte[] method_4(string string_15, byte[] byte_0)
	{
		FileStream fileStream = new FileStream(string_15, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		return this.method_12(array, byte_0);
	}

	public byte[] method_5(MemoryStream memoryStream_0, bool bool_12)
	{
		int num = 0;
		try
		{
			string urexXhPeB = this.UrexXhPeB;
			string text = this.string_1;
			if (bool_12)
			{
				urexXhPeB = this.string_0;
				text = this.string_2;
			}
			byte[] array = new byte[urexXhPeB.Length];
			for (int i = 0; i < urexXhPeB.Length; i++)
			{
				array[i] = Convert.ToByte(urexXhPeB[i]);
			}
			byte[] array2 = new byte[text.Length];
			for (int j = 0; j < text.Length; j++)
			{
				array2[j] = Convert.ToByte(text[j]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array3 = memoryStream_0.ToArray();
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
        catch (System.Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	public byte[] method_6(byte[] byte_0, byte[] byte_1, byte[] byte_2)
	{
		int num = 0;
		try
		{
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(byte_2, byte_1);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
        catch (System.Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	public byte[] method_7(byte[] byte_0, bool bool_12)
	{
		int num = 0;
		try
		{
			string urexXhPeB = this.UrexXhPeB;
			string text = this.string_1;
			if (bool_12)
			{
				urexXhPeB = this.string_0;
				text = this.string_2;
			}
			byte[] array = new byte[urexXhPeB.Length];
			for (int i = 0; i < urexXhPeB.Length; i++)
			{
				array[i] = Convert.ToByte(urexXhPeB[i]);
			}
			byte[] array2 = new byte[text.Length];
			for (int j = 0; j < text.Length; j++)
			{
				array2[j] = Convert.ToByte(text[j]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
        catch (System.Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	public byte[] method_8(MemoryStream memoryStream_0, byte[] byte_0, bool bool_12)
	{
		int num = 0;
		try
		{
			string text = this.string_1;
			if (bool_12)
			{
				text = this.string_2;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(byte_0, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array2 = memoryStream_0.ToArray();
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
        catch (System.Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	public byte[] method_9(string string_15, bool bool_12)
	{
		FileStream fileStream = new FileStream(string_15, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		fileStream.Close();
		return this.method_10(memoryStream, bool_12);
	}

	public static string smethod_0(string string_15)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_15);
		HashAlgorithm hashAlgorithm = SHA256.Create();
		byte[] byte_ = hashAlgorithm.ComputeHash(bytes);
		return Class26.smethod_29(byte_);
	}

	public static byte[] smethod_1(string string_15)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_15);
		HashAlgorithm hashAlgorithm = SHA256.Create();
		return hashAlgorithm.ComputeHash(bytes);
	}

	private static string smethod_10()
	{
		if (!Class26.bool_0)
		{
			Class26.bool_0 = true;
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
				ManagementObjectCollection instances = managementClass.GetInstances();
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						try
						{
							if (text == string.Empty && managementObject.Properties["PnPDeviceID"] != null && managementObject.Properties["PnPDeviceID"].Value != null)
							{
								text = managementObject.Properties["PnPDeviceID"].Value.ToString();
								if (text.Length > 0 && text.IndexOf("USBSTOR") >= 0)
								{
									text = "";
								}
								if (managementObject.Properties["MediaType"] != null && managementObject.Properties["MediaType"].Value != null && managementObject.Properties["MediaType"].Value.ToString().ToUpper().IndexOf("REMOVABLE") >= 0)
								{
									text = "";
								}
								if (managementObject.Properties["InterfaceType"] != null && managementObject.Properties["InterfaceType"].Value != null)
								{
									if (managementObject.Properties["InterfaceType"].Value.ToString() == "USB")
									{
										text = "";
									}
									if (managementObject.Properties["InterfaceType"].Value.ToString() == "1394")
									{
										text = "";
									}
								}
								if (text.Length != 0)
								{
									break;
								}
								text = string.Empty;
							}
						}
						catch
						{
						}
					}
				}
				if (text == string.Empty)
				{
					text = "";
				}
				Class26.string_3 = text;
				if (Class26.string_3.Length > 0)
				{
					string[] array = Class26.string_3.Split(new char[]
					{
						'\\'
					});
					Class26.string_3 = array[array.Length - 1];
				}
			}
			catch
			{
				Class26.string_3 = "";
			}
		}
		return Class26.string_3;
	}

	private static string smethod_11()
	{
		if (!Class26.bool_1)
		{
			Class26.bool_1 = true;
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
				ManagementObjectCollection instances = managementClass.GetInstances();
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						try
						{
							if (text == string.Empty && managementObject.Properties["PnPDeviceID"] != null && managementObject.Properties["PnPDeviceID"].Value != null)
							{
								text = managementObject.Properties["PnPDeviceID"].Value.ToString();
								if (text.Length > 0 && text.IndexOf("USBSTOR") >= 0)
								{
									text = "";
								}
								if (managementObject.Properties["InterfaceType"] != null && managementObject.Properties["InterfaceType"].Value != null)
								{
									if (managementObject.Properties["InterfaceType"].Value.ToString() == "USB")
									{
										text = "";
									}
									if (managementObject.Properties["InterfaceType"].Value.ToString() == "1394")
									{
										text = "";
									}
								}
								if (text.Length != 0)
								{
									break;
								}
								text = string.Empty;
							}
						}
						catch
						{
						}
					}
				}
				if (text == string.Empty)
				{
					text = "";
				}
				Class26.string_4 = text;
				if (Class26.string_4.Length > 0)
				{
					string[] array = Class26.string_4.Split(new char[]
					{
						'\\'
					});
					Class26.string_4 = array[array.Length - 1];
				}
			}
			catch
			{
				Class26.string_4 = "";
			}
		}
		return Class26.string_4;
	}

	private static string smethod_12()
	{
		if (!Class26.bool_2)
		{
			Class26.bool_2 = true;
			try
			{
				Class26.string_5 = Class26.Class33.smethod_0();
			}
			catch
			{
				Class26.string_5 = "failure-failure";
			}
		}
		return Class26.string_5;
	}

	private static string smethod_13()
	{
		if (!Class26.bool_3)
		{
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_Processor");
				ManagementObjectCollection instances = managementClass.GetInstances();
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						if (text == string.Empty)
						{
							try
							{
								text = managementObject.Properties["ProcessorId"].Value.ToString();
								if (text.Length != 0)
								{
									break;
								}
								text = string.Empty;
							}
							catch
							{
							}
						}
					}
				}
				Class26.string_6 = text;
			}
			catch
			{
			}
			Class26.bool_3 = true;
		}
		if (Class26.string_6 == string.Empty)
		{
			Class26.string_6 = "";
		}
		return Class26.string_6;
	}

	private static string smethod_14()
	{
		if (!Class26.bool_4)
		{
			string text = string.Empty;
			try
			{
				if (text == string.Empty)
				{
					ManagementClass managementClass = new ManagementClass("Win32_PhysicalMedia");
					ManagementObjectCollection instances = managementClass.GetInstances();
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)enumerator.Current;
							if (text == string.Empty)
							{
								try
								{
									string text2 = managementObject.Properties["SerialNumber"].Value.ToString();
									text = text2;
									if (text.Length != 0)
									{
										break;
									}
									text = string.Empty;
								}
								catch
								{
								}
							}
						}
					}
				}
			}
			catch
			{
			}
			Class26.string_7 = text;
			Class26.bool_4 = true;
		}
		if (Class26.string_7 == string.Empty)
		{
			Class26.string_7 = "";
		}
		return Class26.string_7;
	}

	private static string smethod_15()
	{
		if (!Class26.bool_5)
		{
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection instances = managementClass.GetInstances();
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						if (!(text == string.Empty))
						{
							break;
						}
						try
						{
							if (managementObject["IPEnabled"] != null && (bool)managementObject["IPEnabled"] && managementObject["MacAddress"] != null)
							{
								text = managementObject["MacAddress"].ToString();
								text = text.Replace(":", "");
							}
						}
						catch
						{
						}
					}
				}
				Class26.string_8 = text;
			}
			catch
			{
			}
			Class26.bool_5 = true;
		}
		if (Class26.string_8 == string.Empty)
		{
			Class26.string_8 = "";
		}
		return Class26.string_8;
	}

	private static string smethod_16()
	{
		if (!Class26.bool_6)
		{
			try
			{
				string text = Class26.Class32.smethod_0();
				if (text.Length == 0)
				{
					text = string.Empty;
					ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
					ManagementObjectCollection instances = managementClass.GetInstances();
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)enumerator.Current;
							if (!(text == string.Empty))
							{
								break;
							}
							try
							{
								if (managementObject["IPEnabled"] != null && (bool)managementObject["IPEnabled"] && managementObject["MacAddress"] != null && managementObject["MacAddress"].ToString().Length > 0)
								{
									text = managementObject["MacAddress"].ToString().ToUpper();
									text = text.Replace(":", "");
								}
							}
							catch
							{
							}
						}
					}
				}
				Class26.string_9 = text;
			}
			catch
			{
			}
			Class26.bool_6 = true;
		}
		if (Class26.string_9 == string.Empty)
		{
			Class26.string_9 = "";
		}
		return Class26.string_9;
	}

	private static string smethod_17()
	{
		if (!Class26.bool_7)
		{
			try
			{
				Class26.string_10 = Class26.smethod_19() + "-" + Class26.smethod_21();
			}
			catch
			{
			}
			Class26.bool_7 = true;
		}
		if (Class26.string_10 == string.Empty)
		{
			Class26.string_10 = "";
		}
		return Class26.string_10;
	}

	private static string smethod_18()
	{
		if (!Class26.bool_8)
		{
			try
			{
				Class26.string_11 = string.Concat(new string[]
				{
					Class26.smethod_19(),
					"-",
					Class26.smethod_21(),
					"-",
					Class26.smethod_23()
				});
			}
			catch
			{
			}
			Class26.bool_8 = true;
		}
		if (Class26.string_11 == string.Empty)
		{
			Class26.string_11 = "";
		}
		return Class26.string_11;
	}

	private static string smethod_19()
	{
		if (!Class26.bool_9)
		{
			Class26.string_12 = Class26.smethod_20();
			Class26.bool_9 = true;
		}
		return Class26.string_12;
	}

	public static byte[] smethod_2(string string_15)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_15);
		Array.Reverse(bytes);
		HashAlgorithm hashAlgorithm = SHA256.Create();
		return hashAlgorithm.ComputeHash(bytes);
	}

	private static string smethod_20()
	{
		string result;
		try
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					try
					{
						if (managementObject.Properties["Product"] != null && managementObject.Properties["Product"].Value != null && text == string.Empty)
						{
							text = managementObject.Properties["Product"].Value.ToString();
							if (text.Length != 0)
							{
								break;
							}
							text = string.Empty;
						}
					}
					catch
					{
					}
				}
			}
			if (text == string.Empty)
			{
				text = "";
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}

	private static string smethod_21()
	{
		if (!Class26.bool_10)
		{
			Class26.string_13 = Class26.smethod_22();
			Class26.bool_10 = true;
		}
		return Class26.string_13;
	}

	private static string smethod_22()
	{
		string result;
		try
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					try
					{
						if (text == string.Empty && managementObject.Properties["Manufacturer"] != null && managementObject.Properties["Manufacturer"].Value != null)
						{
							text = managementObject.Properties["Manufacturer"].Value.ToString();
							if (text.Length != 0)
							{
								break;
							}
							text = string.Empty;
						}
					}
					catch
					{
					}
				}
			}
			if (text == string.Empty)
			{
				text = "";
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}

	private static string smethod_23()
	{
		if (!Class26.bool_11)
		{
			Class26.string_14 = Class26.smethod_24();
			Class26.bool_11 = true;
		}
		return Class26.string_14;
	}

	private static string smethod_24()
	{
		string result;
		try
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					try
					{
						if (text == string.Empty && managementObject.Properties["SerialNumber"] != null && managementObject.Properties["SerialNumber"].Value != null)
						{
							text = managementObject.Properties["SerialNumber"].Value.ToString();
							if (text.Length != 0)
							{
								break;
							}
							text = string.Empty;
						}
					}
					catch
					{
					}
				}
			}
			if (text == string.Empty)
			{
				text = "";
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}

	internal static Class26.Class37 smethod_25()
	{
		Class26.Class37 @class = new Class26.Class37();
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_BIOS");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					Class26.Class40 class2 = new Class26.Class40("BIOS");
					if (managementObject.Properties["Manufacturer"].Value != null)
					{
						class2.method_7("Manufacturer", managementObject.Properties["Manufacturer"].Value.ToString(), "");
					}
					else
					{
						class2.method_7("Manufacturer", "", "");
					}
					if (managementObject.Properties["Version"].Value != null)
					{
						class2.method_7("Version", managementObject.Properties["Version"].Value.ToString(), "");
					}
					else
					{
						class2.method_7("Version", "", "");
					}
					if (managementObject.Properties["SMBIOSBIOSVersion"].Value != null)
					{
						class2.method_7("SMBIOSBIOSVersion", managementObject.Properties["SMBIOSBIOSVersion"].Value.ToString(), "");
					}
					else
					{
						class2.method_7("SMBIOSBIOSVersion", "", "");
					}
					@class.method_0().method_2(class2);
				}
			}
		}
		catch
		{
		}
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator2 = instances.GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					ManagementObject managementObject2 = (ManagementObject)enumerator2.Current;
					Class26.Class40 class3 = new Class26.Class40("BOARD");
					if (managementObject2.Properties["Manufacturer"].Value != null)
					{
						class3.method_7("Manufacturer", managementObject2.Properties["Manufacturer"].Value.ToString(), "");
					}
					else
					{
						class3.method_7("Manufacturer", "", "");
					}
					@class.method_0().method_2(class3);
				}
			}
		}
		catch
		{
		}
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_Processor");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator3 = instances.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					ManagementObject managementObject3 = (ManagementObject)enumerator3.Current;
					Class26.Class40 class4 = new Class26.Class40("PROCESSOR");
					if (managementObject3.Properties["Manufacturer"].Value != null)
					{
						class4.method_7("Manufacturer", managementObject3.Properties["Manufacturer"].Value.ToString(), "");
					}
					else
					{
						class4.method_7("Manufacturer", "", "");
					}
					if (managementObject3.Properties["Name"].Value != null)
					{
						class4.method_7("Name", managementObject3.Properties["Name"].Value.ToString(), "");
					}
					else
					{
						class4.method_7("Name", "", "");
					}
					if (managementObject3.Properties["ProcessorId"].Value != null)
					{
						class4.method_7("ProcessorId", managementObject3.Properties["ProcessorId"].Value.ToString(), "");
					}
					else
					{
						class4.method_7("ProcessorId", "", "");
					}
					@class.method_0().method_2(class4);
				}
			}
		}
		catch
		{
		}
		return @class;
	}

	public static string smethod_26(DateTime dateTime_0)
	{
		return Class26.smethod_29(new byte[]
		{
			Convert.ToByte(dateTime_0.Year.ToString("D4").Substring(0, 2)),
			Convert.ToByte(dateTime_0.Year.ToString("D4").Substring(2, 2)),
			Convert.ToByte(dateTime_0.Month),
			Convert.ToByte(dateTime_0.Day)
		});
	}

	public static DateTime smethod_27(string string_15)
	{
		byte[] array = new byte[string_15.Length / 3];
		for (int i = 0; i < string_15.Length / 3; i++)
		{
			array[i] = Convert.ToByte(string_15.Substring(i * 3, 3));
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class26 @class = new Class26();
		array = @class.method_10(memoryStream, true);
		DateTime result = new DateTime(Convert.ToInt32(array[0].ToString("D2") + array[1].ToString("D2")), (int)array[2], (int)array[3]);
		return result;
	}

	public static string smethod_28(byte[] byte_0)
	{
		string text = "";
		for (int i = 0; i < byte_0.Length; i++)
		{
			text += byte_0[i].ToString("D3");
		}
		return text;
	}

	public static string smethod_29(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(byte_0, 0, byte_0.Length);
		memoryStream.Position = 0L;
		Class26 @class = new Class26();
		return Class26.smethod_28(@class.method_5(memoryStream, true));
	}

	public static string smethod_3(string string_15)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_15);
		HashAlgorithm hashAlgorithm = SHA256.Create();
		byte[] inArray = hashAlgorithm.ComputeHash(bytes);
		return Convert.ToBase64String(inArray);
	}

	public static string smethod_30(string string_15, byte[] byte_0)
	{
		byte[] array = new byte[string_15.Length];
		for (int i = 0; i < string_15.Length; i++)
		{
			array[i] = Convert.ToByte(string_15[i]);
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class26 @class = new Class26();
		byte[] inArray = @class.method_8(memoryStream, byte_0, true);
		return Class26.smethod_3(Convert.ToBase64String(inArray));
	}

	public static string smethod_31(string string_15, byte[] byte_0)
	{
		byte[] array = new byte[string_15.Length];
		for (int i = 0; i < string_15.Length; i++)
		{
			array[i] = Convert.ToByte(string_15[i]);
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class26 @class = new Class26();
		byte[] inArray = @class.method_8(memoryStream, byte_0, true);
		return Convert.ToBase64String(inArray);
	}

	public static string smethod_32(string string_15, byte[] byte_0)
	{
		byte[] array = Convert.FromBase64String(string_15);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class26 @class = new Class26();
		byte[] array2 = @class.method_11(memoryStream, byte_0, true);
		string text = "";
		for (int i = 0; i < array2.Length; i++)
		{
			text += (char)array2[i];
		}
		return text;
	}

	public static string smethod_33(string string_15)
	{
		byte[] array = new byte[string_15.Length];
		for (int i = 0; i < string_15.Length; i++)
		{
			array[i] = Convert.ToByte(string_15[i]);
		}
		return Class26.smethod_29(array);
	}

	public static string smethod_34(string string_15)
	{
		byte[] array = new byte[string_15.Length / 3];
		for (int i = 0; i < string_15.Length / 3; i++)
		{
			array[i] = Convert.ToByte(string_15.Substring(i * 3, 3));
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class26 @class = new Class26();
		array = @class.method_10(memoryStream, true);
		string text = "";
		for (int j = 0; j < array.Length; j++)
		{
			text += Convert.ToChar(array[j]);
		}
		return text;
	}

	public static void smethod_4(string string_15)
	{
		Class26.Class37 class37_ = Class26.smethod_25();
		byte[] array = Class26.Class45.smethod_0(class37_);
		FileStream fileStream = new FileStream(string_15, FileMode.Create, FileAccess.ReadWrite);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
	}

	internal static string smethod_5(bool bool_12, bool bool_13, bool bool_14, bool bool_15)
	{
		string text = "";
		if (bool_12)
		{
			text = Class26.smethod_13();
		}
		if (bool_13)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_15();
		}
		if (bool_14)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_17();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_14();
		}
		return text;
	}

	internal static string smethod_6(bool bool_12, bool bool_13, bool bool_14, bool bool_15)
	{
		string text = "";
		if (bool_12)
		{
			text = Class26.smethod_12();
		}
		if (bool_13)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_15();
		}
		if (bool_14)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_17();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_14();
		}
		return text;
	}

	internal static string smethod_7(bool bool_12, bool bool_13, bool bool_14, bool bool_15)
	{
		string text = "";
		if (bool_12)
		{
			text = Class26.smethod_13();
		}
		if (bool_13)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_16();
		}
		if (bool_14)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_18();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_12();
		}
		return text;
	}

	internal static string smethod_8(bool bool_12, bool bool_13, bool bool_14, bool bool_15)
	{
		string text = "";
		if (bool_12)
		{
			text = Class26.smethod_13();
		}
		if (bool_13)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_16();
		}
		if (bool_14)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_18();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class26.smethod_10();
		}
		return text;
	}

	internal static string smethod_9(bool bool_12, bool bool_13, bool bool_14, bool bool_15)
	{
		string text = "";
		RSACryptoServiceProvider.UseMachineKeyStore = true;
		MD5 mD = new MD5CryptoServiceProvider();
		if (bool_12)
		{
			byte[] array = mD.ComputeHash(Encoding.Unicode.GetBytes(Class26.smethod_13()));
			text += array[3].ToString("X2");
			text = text + array[11].ToString("X2") + "-";
		}
		else
		{
			text = "85C1-";
		}
		if (bool_13)
		{
			byte[] array2 = mD.ComputeHash(Encoding.Unicode.GetBytes(Class26.smethod_16()));
			text += array2[3].ToString("X2");
			text = text + array2[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array3 = mD.ComputeHash(Encoding.Unicode.GetBytes(text));
			text += array3[15].ToString("X2");
			text = text + array3[7].ToString("X2") + "-";
		}
		if (bool_14)
		{
			byte[] array4 = mD.ComputeHash(Encoding.Unicode.GetBytes(Class26.smethod_18()));
			text += array4[3].ToString("X2");
			text = text + array4[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array5 = mD.ComputeHash(Encoding.Unicode.GetBytes(text));
			text += array5[2].ToString("X2");
			text = text + array5[14].ToString("X2") + "-";
		}
		if (bool_15)
		{
			byte[] array6 = mD.ComputeHash(Encoding.Unicode.GetBytes(Class26.smethod_11()));
			text += array6[3].ToString("X2");
			text = text + array6[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array7 = mD.ComputeHash(Encoding.Unicode.GetBytes(text));
			text += array7[1].ToString("X2");
			text = text + array7[9].ToString("X2") + "-";
		}
		byte[] array8 = mD.ComputeHash(Encoding.Unicode.GetBytes(text));
		text += array8[1].ToString("X2");
		return text + array8[9].ToString("X2");
	}

	private static bool bool_0;

	private static bool bool_1;

	private static bool bool_10;

	private static bool bool_11;

	private static bool bool_2;

	private static bool bool_3;

	private static bool bool_4;

	private static bool bool_5;

	private static bool bool_6;

	private static bool bool_7;

	private static bool bool_8;

	private static bool bool_9;

	private string string_0 = "";

	private string string_1 = "";

	private static string string_10;

	private static string string_11;

	private static string string_12;

	private static string string_13;

	private static string string_14;

	private string string_2 = "";

	private static string string_3;

	private static string string_4;

	private static string string_5;

	private static string string_6;

	private static string string_7;

	private static string string_8;

	private static string string_9;

	private string UrexXhPeB = "";

	internal class Attribute0 : Attribute
	{
		public Attribute0(ulong ulong_0)
		{
		}
	}

	internal class Class27
	{
		static Class27()
		{
			Class26.Class27.string_0 = "";
			Class26.Class27.bool_0 = true;
			Class26.Class27.bool_1 = true;
			Class26.Class27.bool_2 = true;
			Class26.Class27.bool_3 = false;
		}

		private Class27()
		{
		}

		internal static string smethod_0(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_5(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_1(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		internal static string smethod_1(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_6(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_1(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		public static void smethod_10(Icon icon_0, Graphics graphics_0)
		{
			graphics_0.DrawIcon(icon_0, 0, 0);
		}

		public static string smethod_11()
		{
			if (Class26.Class27.string_0.Length > 0)
			{
				return Class26.Class27.string_0;
			}
			try
			{
				string text = Class26.smethod_5(true, true, true, false);
				byte[] array = Class26.smethod_1(text);
				Class26.Class35.smethod_4();
				byte[] array2 = Class26.Class35.smethod_6(text);
				text = "";
				for (int i = 0; i < array2.Length; i++)
				{
					text += array2[i].ToString("X2");
				}
				for (int j = 0; j < array.Length; j++)
				{
					text += array[j].ToString("X2");
				}
				text = text.Substring(0, 20);
				text = string.Concat(new string[]
				{
					text.Substring(0, 4),
					"-",
					text.Substring(4, 4),
					"-",
					text.Substring(8, 4),
					"-",
					text.Substring(12, 4),
					"-",
					text.Substring(16, 4)
				});
				Class26.Class27.string_0 = text;
			}
			catch
			{
				Class26.Class27.string_0 = "3B3F-96F2-C310-5438-AC1F";
			}
			return Class26.Class27.string_0;
		}

		internal static string smethod_2(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_7(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_1(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		internal static string smethod_3(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			return Class26.smethod_9(bool_4, bool_5, bool_6, bool_7);
		}

		internal static string smethod_4(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_5(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_2(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		internal static string smethod_5(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_6(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_2(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		internal static string smethod_6(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_7(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_2(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		internal static string smethod_7(bool bool_4, bool bool_5, bool bool_6, bool bool_7)
		{
			string text = Class26.smethod_8(bool_4, bool_5, bool_6, bool_7);
			byte[] array = Class26.smethod_2(text);
			Class26.Class35.smethod_4();
			byte[] array2 = Class26.Class35.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		public static string smethod_8(Color color_0)
		{
			return color_0.R.ToString("D3") + color_0.G.ToString("D3") + color_0.B.ToString("D3");
		}

		public static Color smethod_9(string string_1)
		{
			return Color.FromArgb((int)Convert.ToByte(string_1.Substring(0, 3)), (int)Convert.ToByte(string_1.Substring(3, 3)), (int)Convert.ToByte(string_1.Substring(6, 3)));
		}

		internal static bool bool_0;

		internal static bool bool_1;

		internal static bool bool_2;

		internal static bool bool_3;

		internal static string string_0;
	}

	internal class Class28 : RSA
	{
		static Class28()
		{
			Class26.Class28.byte_0 = new byte[]
			{
				48,
				32,
				48,
				12,
				6,
				8,
				42,
				134,
				72,
				134,
				247,
				13,
				2,
				0,
				5,
				0,
				4,
				16
			};
			Class26.Class28.byte_1 = new byte[]
			{
				48,
				33,
				48,
				9,
				6,
				5,
				43,
				14,
				3,
				2,
				26,
				5,
				0,
				4,
				20
			};
		}

		public Class28()
		{
			this.int_2 = 128;
		}

		public Class28(int int_3)
		{
			this.int_2 = int_3 / 8;
		}

		public override byte[] DecryptValue(byte[] rgb)
		{
			return this.method_1(rgb);
		}

		protected override void Dispose(bool disposing)
		{
			this.class29_0 = (this.class29_1 = (this.class29_2 = (this.class29_3 = (this.class29_4 = (this.class29_5 = (this.class29_6 = (this.class29_7 = null)))))));
		}

		public override byte[] EncryptValue(byte[] rgb)
		{
			return this.method_0(rgb);
		}

		public override RSAParameters ExportParameters(bool includePrivateParameters)
		{
			RSAParameters result = default(RSAParameters);
			result.Modulus = this.class29_0.method_2();
			result.Exponent = this.class29_1.method_2();
			if (includePrivateParameters)
			{
				result.P = this.class29_2.method_2();
				result.Q = this.class29_3.method_2();
				result.DP = this.class29_4.method_2();
				result.DQ = this.class29_5.method_2();
				result.InverseQ = this.class29_6.method_2();
				result.D = this.class29_7.method_2();
			}
			return result;
		}

		public override void FromXmlString(string xmlString)
		{
			StringReader input = new StringReader(xmlString);
			XmlTextReader xmlTextReader = new XmlTextReader(input);
			this.class29_0 = (this.class29_1 = (this.class29_2 = (this.class29_3 = (this.class29_4 = (this.class29_5 = (this.class29_6 = (this.class29_7 = null)))))));
			while (true)
			{
				XmlNodeType xmlNodeType = xmlTextReader.MoveToContent();
				XmlNodeType xmlNodeType2 = xmlNodeType;
				switch (xmlNodeType2)
				{
				case XmlNodeType.None:
					return;
				case XmlNodeType.Element:
				{
					string name = xmlTextReader.Name;
					if (!this.method_14(xmlTextReader, name, "Modulus", ref this.class29_0) && !this.method_14(xmlTextReader, name, "Exponent", ref this.class29_1) && !this.method_14(xmlTextReader, name, "P", ref this.class29_2) && !this.method_14(xmlTextReader, name, "Q", ref this.class29_3) && !this.method_14(xmlTextReader, name, "DP", ref this.class29_4) && !this.method_14(xmlTextReader, name, "DQ", ref this.class29_5) && !this.method_14(xmlTextReader, name, "InverseQ", ref this.class29_6) && !this.method_14(xmlTextReader, name, "D", ref this.class29_7))
					{
						xmlTextReader.ReadString();
					}
					break;
				}
				default:
					if (xmlNodeType2 != XmlNodeType.EndElement)
					{
						goto Block_9;
					}
					xmlTextReader.ReadEndElement();
					break;
				}
			}
			Block_9:
			throw new ArgumentException();
		}

		public override void ImportParameters(RSAParameters parameters)
		{
			this.class29_0 = new Class26.Class29(parameters.Modulus);
			this.class29_1 = new Class26.Class29(parameters.Exponent);
			this.class29_2 = ((!object.ReferenceEquals(parameters.P, null)) ? new Class26.Class29(parameters.P) : null);
			this.class29_3 = ((!object.ReferenceEquals(parameters.Q, null)) ? new Class26.Class29(parameters.Q) : null);
			this.class29_4 = ((!object.ReferenceEquals(parameters.DP, null)) ? new Class26.Class29(parameters.DP) : null);
			this.class29_5 = ((!object.ReferenceEquals(parameters.DQ, null)) ? new Class26.Class29(parameters.DQ) : null);
			this.class29_6 = ((!object.ReferenceEquals(parameters.InverseQ, null)) ? new Class26.Class29(parameters.InverseQ) : null);
			this.class29_7 = ((!object.ReferenceEquals(parameters.D, null)) ? new Class26.Class29(parameters.D) : null);
		}

		public byte[] method_0(byte[] byte_2)
		{
			if (byte_2.Length != this.int_2)
			{
				throw new ArgumentException("input.Length does not match keylen");
			}
			if (object.ReferenceEquals(this.class29_0, null))
			{
				throw new ArgumentException("no key set!");
			}
			Class26.Class29 @class = new Class26.Class29(byte_2);
			if (@class >= this.class29_0)
			{
				throw new ArgumentException("input exceeds modulus");
			}
			@class = @class.wfQvayhew(this.class29_1, this.class29_0);
			byte[] byte_3 = @class.method_2();
			return this.method_12(byte_3, this.int_2);
		}

		public byte[] method_1(byte[] byte_2)
		{
			if (byte_2.Length != this.int_2)
			{
				throw new ArgumentException("input.Length does not match keylen");
			}
			if (object.ReferenceEquals(this.class29_7, null))
			{
				throw new ArgumentException("no private key set!");
			}
			Class26.Class29 @class = new Class26.Class29(byte_2);
			if (@class >= this.class29_0)
			{
				throw new ArgumentException("input exceeds modulus");
			}
			@class = @class.wfQvayhew(this.class29_7, this.class29_0);
			byte[] byte_3 = @class.method_2();
			return this.method_12(byte_3, this.int_2);
		}

		public bool method_10(byte[] byte_2, HashAlgorithm hashAlgorithm_0, byte[] byte_3)
		{
			Class26.Enum2 enum2_ = this.method_15(hashAlgorithm_0);
			byte[] byte_4 = hashAlgorithm_0.ComputeHash(byte_2);
			return this.method_8(byte_4, byte_3, enum2_);
		}

		private bool method_11(byte[] byte_2, int int_3, byte[] byte_3, int int_4, int int_5)
		{
			for (int i = 0; i < int_5; i++)
			{
				if (byte_2[i + int_3] != byte_3[i + int_4])
				{
					return false;
				}
			}
			return true;
		}

		private byte[] method_12(byte[] byte_2, int int_3)
		{
			int num = byte_2.Length;
			if (num >= int_3)
			{
				return byte_2;
			}
			byte[] array = new byte[int_3];
			int num2 = int_3 - num;
			for (int i = 0; i < num2; i++)
			{
				array[i] = 0;
			}
			Array.Copy(byte_2, 0, array, num2, num);
			return array;
		}

		private string method_13(Class26.Class29 class29_8)
		{
			byte[] inArray = class29_8.method_2();
			return Convert.ToBase64String(inArray);
		}

		private bool method_14(XmlReader xmlReader_0, string string_0, string string_1, ref Class26.Class29 class29_8)
		{
			if (string.Compare(string_0, string_1, true) != 0)
			{
				return false;
			}
			string s = xmlReader_0.ReadString();
			byte[] array = Convert.FromBase64String(s);
			Class26.Class29 @class = new Class26.Class29(array);
			class29_8 = @class;
			return true;
		}

		private Class26.Enum2 method_15(HashAlgorithm hashAlgorithm_0)
		{
			Type type = hashAlgorithm_0.GetType();
			if (object.ReferenceEquals(type, typeof(MD5CryptoServiceProvider)))
			{
				return (Class26.Enum2)5;
			}
			if (!object.ReferenceEquals(type, typeof(SHA1CryptoServiceProvider)))
			{
				throw new ArgumentException("unknown HashAlgorithm");
			}
			return (Class26.Enum2)1;
		}

		public bool method_2()
		{
			Class26.Class29 @class = this.class29_2 * this.class29_3;
			if (@class != this.class29_0)
			{
				return false;
			}
			Class26.Class29 class2 = this.class29_2 - 1;
			Class26.Class29 class3 = this.class29_3 - 1;
			Class26.Class29 class4 = class2 * class3;
			Class26.Class29 class5 = this.class29_1.method_6(class4);
			return !(class5 != 1u);
		}

		public byte[] method_3(byte[] byte_2, bool bool_0)
		{
			if (bool_0)
			{
				throw new ArgumentException("OAEP padding not supported, sorry");
			}
			int num = byte_2.Length;
			int num2 = this.int_2 - 3 - num;
			if (num2 < 8)
			{
				throw new ArgumentException("input too long");
			}
			byte[] array = new byte[this.int_2];
			array[0] = 0;
			array[1] = 2;
			byte[] array2 = new byte[num2];
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			rNGCryptoServiceProvider.GetBytes(array2);
			for (int i = 0; i < num2; i++)
			{
				if (array2[i] == 0)
				{
					array2[i] = (byte)i;
				}
				if ((byte)i == 0)
				{
					array2[i] = 1;
				}
			}
			Array.Copy(array2, 0, array, 2, num2);
			array[num2 + 2] = 0;
			Array.Copy(byte_2, 0, array, num2 + 3, num);
			return this.method_0(array);
		}

		public byte[] method_4(byte[] byte_2, bool bool_0)
		{
			if (bool_0)
			{
				throw new ArgumentException("OAEP padding not supported, sorry");
			}
			byte[] array = this.method_1(byte_2);
			if (array[0] == 0)
			{
				if (array[1] == 2)
				{
					int num = array.Length;
					for (int i = 2; i < num - 1; i++)
					{
						if (array[i] == 0)
						{
							i++;
							int num2 = num - i;
							byte[] array2 = new byte[num2];
							Array.Copy(array, i, array2, 0, num2);
							return array2;
						}
					}
					throw new ArgumentException("invalid padding");
				}
			}
			throw new ArgumentException("invalid signature bytes");
		}

		public Class26.Enum2 method_5(string string_0)
		{
			Class26.Enum2 result;
			if (string.Compare(string_0, CryptoConfig.MapNameToOID("MD5"), true) == 0)
			{
				result = (Class26.Enum2)5;
			}
			else
			{
				if (string.Compare(string_0, CryptoConfig.MapNameToOID("SHA1"), true) != 0)
				{
					throw new ArgumentException("unknown hash_algorithm_oid");
				}
				result = (Class26.Enum2)1;
			}
			return result;
		}

		public byte[] method_6(byte[] byte_2, string string_0)
		{
			Class26.Enum2 enum2_ = this.method_5(string_0);
			return this.wfQvayhew(byte_2, enum2_);
		}

		public bool method_7(byte[] byte_2, string string_0, byte[] byte_3)
		{
			Class26.Enum2 enum2_ = this.method_5(string_0);
			return this.method_8(byte_2, byte_3, enum2_);
		}

		public bool method_8(byte[] byte_2, byte[] byte_3, Class26.Enum2 enum2_0)
		{
			int num = byte_3.Length;
			if (num != this.int_2)
			{
				return false;
			}
			byte[] array = this.method_0(byte_3);
			if (array[0] == 0)
			{
				if (array[1] == 1)
				{
					int num2 = array.Length;
					int i = 2;
					while (i < num2 - 1)
					{
						byte b = array[i];
						if (b != 0)
						{
							if (b != 255)
							{
								return false;
							}
							i++;
						}
						else
						{
							i++;
							int num3 = num2 - i;
							if (num3 == 34)
							{
								if (array[i + 13] != (byte)enum2_0)
								{
									return false;
								}
								array[i + 13] = 0;
								return this.method_11(array, i, Class26.Class28.byte_0, 0, 18) && this.method_11(array, i + 18, byte_2, 0, 16);
							}
							else
							{
								if (num3 == 35 && enum2_0 == (Class26.Enum2)1)
								{
									return this.method_11(array, i, Class26.Class28.byte_1, 0, 15) && this.method_11(array, i + 15, byte_2, 0, 20);
								}
								return num3 == byte_2.Length && enum2_0 == (Class26.Enum2)0 && this.method_11(array, i, byte_2, 0, num3);
							}
						}
					}
					return false;
				}
			}
			return false;
		}

		public byte[] method_9(byte[] byte_2, HashAlgorithm hashAlgorithm_0)
		{
			Class26.Enum2 enum2_ = this.method_15(hashAlgorithm_0);
			byte[] byte_3 = hashAlgorithm_0.ComputeHash(byte_2);
			return this.wfQvayhew(byte_3, enum2_);
		}

		public byte[] wfQvayhew(byte[] byte_2, Class26.Enum2 enum2_0)
		{
			int num = byte_2.Length;
			int num2 = 0;
			switch (enum2_0)
			{
			case (Class26.Enum2)0:
				num2 = this.int_2 - 3 - num;
				break;
			case (Class26.Enum2)1:
				if (num != 20)
				{
					throw new ArgumentException("SHA1 hashes must be 20 bytes long");
				}
				num2 = this.int_2 - 3 - 35;
				break;
			case (Class26.Enum2)2:
			case (Class26.Enum2)4:
			case (Class26.Enum2)5:
				if (num != 16)
				{
					throw new ArgumentException("MDx hashes must be 16 bytes long");
				}
				num2 = this.int_2 - 3 - 34;
				break;
			}
			if (num2 < 8)
			{
				throw new ArgumentException("input too long");
			}
			byte[] array = new byte[this.int_2];
			array[0] = 0;
			array[1] = 1;
			for (int i = 0; i < num2; i++)
			{
				array[i + 2] = 255;
			}
			array[num2 + 2] = 0;
			switch (enum2_0)
			{
			case (Class26.Enum2)0:
				Array.Copy(byte_2, 0, array, num2 + 3, num);
				break;
			case (Class26.Enum2)1:
				Array.Copy(Class26.Class28.byte_1, 0, array, num2 + 3, 15);
				Array.Copy(byte_2, 0, array, num2 + 3 + 15, num);
				break;
			case (Class26.Enum2)2:
			case (Class26.Enum2)4:
			case (Class26.Enum2)5:
				Array.Copy(Class26.Class28.byte_0, 0, array, num2 + 3, 18);
				array[num2 + 3 + 13] = (byte)enum2_0;
				Array.Copy(byte_2, 0, array, num2 + 3 + 18, num);
				break;
			}
			return this.method_1(array);
		}

		public override string KeyExchangeAlgorithm
		{
			get
			{
				return "RSA-PKCS1-KeyEx";
			}
		}

		public override int KeySize
		{
			get
			{
				return this.int_2 * 8;
			}
			set
			{
				throw new ArgumentException();
			}
		}

		public override string SignatureAlgorithm
		{
			get
			{
				return "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
			}
		}

		private static byte[] byte_0;

		private static byte[] byte_1;

		private Class26.Class29 class29_0;

		private Class26.Class29 class29_1;

		private Class26.Class29 class29_2;

		private Class26.Class29 class29_3;

		private Class26.Class29 class29_4;

		private Class26.Class29 class29_5;

		private Class26.Class29 class29_6;

		private Class26.Class29 class29_7;

		private const int int_0 = 1;

		private const int int_1 = 2;

		private int int_2;
	}

	internal class Class29
	{
		public Class29(Class26.Class29 class29_0)
		{
			this.uint_1 = (uint[])class29_0.uint_1.Clone();
			this.uint_0 = class29_0.uint_0;
		}

		public Class29(byte[] byte_0)
		{
			this.uint_0 = (uint)byte_0.Length >> 2;
			int num = byte_0.Length & 3;
			if (num != 0)
			{
				this.uint_0 += 1u;
			}
			this.uint_1 = new uint[this.uint_0];
			int i = byte_0.Length - 1;
			int num2 = 0;
			while (i >= 3)
			{
				this.uint_1[num2] = (uint)((int)byte_0[i - 3] << 24 | (int)byte_0[i - 2] << 16 | (int)byte_0[i - 1] << 8 | (int)byte_0[i]);
				i -= 4;
				num2++;
			}
			switch (num)
			{
			case 1:
				this.uint_1[(int)((UIntPtr)(this.uint_0 - 1u))] = (uint)byte_0[0];
				break;
			case 2:
				this.uint_1[(int)((UIntPtr)(this.uint_0 - 1u))] = (uint)((int)byte_0[0] << 8 | (int)byte_0[1]);
				break;
			case 3:
				this.uint_1[(int)((UIntPtr)(this.uint_0 - 1u))] = (uint)((int)byte_0[0] << 16 | (int)byte_0[1] << 8 | (int)byte_0[2]);
				break;
			}
			this.method_5();
		}

		public Class29(uint uint_2)
		{
			this.uint_1 = new uint[]
			{
				uint_2
			};
		}

		public Class29(ulong ulong_0)
		{
			this.uint_1 = new uint[]
			{
				(uint)ulong_0,
				(uint)(ulong_0 >> 32)
			};
			this.uint_0 = 2u;
			this.method_5();
		}

		public Class29(Class26.Enum3 enum3_0, uint uint_2)
		{
			this.uint_1 = new uint[uint_2];
			this.uint_0 = uint_2;
		}

		public Class29(Class26.Class29 class29_0, uint uint_2)
		{
			this.uint_1 = new uint[uint_2];
			for (uint num = 0u; num < class29_0.uint_0; num += 1u)
			{
				this.uint_1[(int)((UIntPtr)num)] = class29_0.uint_1[(int)((UIntPtr)num)];
			}
			this.uint_0 = class29_0.uint_0;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is int)
			{
				return (int)obj >= 0 && this == (uint)obj;
			}
			Class26.Class29 @class = obj as Class26.Class29;
			return !(@class == null) && Class26.Class31.smethod_4(this, @class) == (Class26.Enum3)0;
		}

		public override int GetHashCode()
		{
			uint num = 0u;
			for (uint num2 = 0u; num2 < this.uint_0; num2 += 1u)
			{
				num ^= this.uint_1[(int)((UIntPtr)num2)];
			}
			return (int)num;
		}

		public int method_0()
		{
			this.method_5();
			uint num = this.uint_1[(int)((UIntPtr)(this.uint_0 - 1u))];
			uint num2 = 2147483648u;
			uint num3 = 32u;
			while (num3 > 0u && (num & num2) == 0u)
			{
				num3 -= 1u;
				num2 >>= 1;
			}
			return (int)(num3 + (this.uint_0 - 1u << 5));
		}

		public bool method_1(int int_0)
		{
			if (int_0 < 0)
			{
				throw new IndexOutOfRangeException("bitNum out of range");
			}
			uint num = (uint)int_0 >> 5;
			byte b = (byte)(int_0 & 31);
			uint num2 = 1u << (int)b;
			return (this.uint_1[(int)((UIntPtr)num)] | num2) == this.uint_1[(int)((UIntPtr)num)];
		}

		public byte[] method_2()
		{
			return this.method_3();
		}

		public byte[] method_3()
		{
			if (this == 0u)
			{
				return new byte[1];
			}
			int num = this.method_0();
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			byte[] array = new byte[num2];
			int num3 = num2 & 3;
			if (num3 == 0)
			{
				num3 = 4;
			}
			int num4 = 0;
			for (int i = (int)(this.uint_0 - 1u); i >= 0; i--)
			{
				uint num5 = this.uint_1[i];
				for (int j = num3 - 1; j >= 0; j--)
				{
					array[num4 + j] = (byte)(num5 & 255u);
					num5 >>= 8;
				}
				num4 += num3;
				num3 = 4;
			}
			return array;
		}

		public Class26.Enum3 method_4(Class26.Class29 class29_0)
		{
			return Class26.Class31.smethod_4(this, class29_0);
		}

		internal void method_5()
		{
			while (this.uint_0 > 0u && this.uint_1[(int)((UIntPtr)(this.uint_0 - 1u))] == 0u)
			{
				this.uint_0 -= 1u;
			}
			if (this.uint_0 == 0u)
			{
				this.uint_0 += 1u;
			}
		}

		public Class26.Class29 method_6(Class26.Class29 class29_0)
		{
			return Class26.Class31.smethod_15(this, class29_0);
		}

		public static Class26.Class29 operator +(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			if (class29_0 == 0u)
			{
				return new Class26.Class29(class29_1);
			}
			if (class29_1 == 0u)
			{
				return new Class26.Class29(class29_0);
			}
			return Class26.Class31.smethod_0(class29_0, class29_1);
		}

		public static Class26.Class29 operator /(Class26.Class29 class29_0, int int_0)
		{
			if (int_0 <= 0)
			{
				throw new ArithmeticException();
			}
			return Class26.Class31.wfQvayhew(class29_0, (uint)int_0);
		}

		public static Class26.Class29 operator /(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return Class26.Class31.smethod_8(class29_0, class29_1)[0];
		}

		public static bool operator ==(Class26.Class29 class29_0, uint uint_2)
		{
			if (class29_0.uint_0 != 1u)
			{
				class29_0.method_5();
			}
			return class29_0.uint_0 == 1u && class29_0.uint_1[0] == uint_2;
		}

		public static bool operator ==(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return class29_0 == class29_1 || (!(null == class29_0) && !(null == class29_1) && Class26.Class31.smethod_4(class29_0, class29_1) == (Class26.Enum3)0);
		}

		public static bool operator >(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return Class26.Class31.smethod_4(class29_0, class29_1) > (Class26.Enum3)0;
		}

		public static bool operator >=(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return Class26.Class31.smethod_4(class29_0, class29_1) >= (Class26.Enum3)0;
		}

		public static implicit operator Class26.Class29(uint uint_2)
		{
			return new Class26.Class29(uint_2);
		}

		public static implicit operator Class26.Class29(int int_0)
		{
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			return new Class26.Class29((uint)int_0);
		}

		public static implicit operator Class26.Class29(ulong ulong_0)
		{
			return new Class26.Class29(ulong_0);
		}

		public static bool operator !=(Class26.Class29 class29_0, uint uint_2)
		{
			if (class29_0.uint_0 != 1u)
			{
				class29_0.method_5();
			}
			return class29_0.uint_0 != 1u || class29_0.uint_1[0] != uint_2;
		}

		public static bool operator !=(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return class29_0 != class29_1 && (null == class29_0 || null == class29_1 || Class26.Class31.smethod_4(class29_0, class29_1) != (Class26.Enum3)0);
		}

		public static Class26.Class29 operator <<(Class26.Class29 class29_0, int int_0)
		{
			return Class26.Class31.smethod_9(class29_0, int_0);
		}

		public static bool operator <(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return Class26.Class31.smethod_4(class29_0, class29_1) < (Class26.Enum3)0;
		}

		public static bool operator <=(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return Class26.Class31.smethod_4(class29_0, class29_1) <= (Class26.Enum3)0;
		}

		public static int operator %(Class26.Class29 class29_0, int int_0)
		{
			if (int_0 > 0)
			{
				return (int)Class26.Class31.smethod_6(class29_0, (uint)int_0);
			}
			return (int)(-(int)Class26.Class31.smethod_6(class29_0, (uint)(-(uint)int_0)));
		}

		public static uint operator %(Class26.Class29 class29_0, uint uint_2)
		{
			return Class26.Class31.smethod_6(class29_0, uint_2);
		}

		public static Class26.Class29 operator %(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			return Class26.Class31.smethod_8(class29_0, class29_1)[1];
		}

		public static Class26.Class29 operator *(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			if (class29_0 == 0u || class29_1 == 0u)
			{
				return 0;
			}
			if ((long)class29_0.uint_1.Length < (long)((ulong)class29_0.uint_0))
			{
				throw new IndexOutOfRangeException("bi1 out of range");
			}
			if ((long)class29_1.uint_1.Length < (long)((ulong)class29_1.uint_0))
			{
				throw new IndexOutOfRangeException("bi2 out of range");
			}
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0 + class29_1.uint_0);
			Class26.Class31.smethod_12(class29_0.uint_1, 0u, class29_0.uint_0, class29_1.uint_1, 0u, class29_1.uint_0, @class.uint_1, 0u);
			@class.method_5();
			return @class;
		}

		public static Class26.Class29 operator *(Class26.Class29 class29_0, int int_0)
		{
			if (int_0 < 0)
			{
				throw new ArithmeticException();
			}
			if (int_0 == 0)
			{
				return 0;
			}
			if (int_0 == 1)
			{
				return new Class26.Class29(class29_0);
			}
			return Class26.Class31.smethod_11(class29_0, (uint)int_0);
		}

		public static Class26.Class29 operator >>(Class26.Class29 class29_0, int int_0)
		{
			return Class26.Class31.smethod_10(class29_0, int_0);
		}

		public static Class26.Class29 operator -(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			if (class29_1 == 0u)
			{
				return new Class26.Class29(class29_0);
			}
			if (class29_0 == 0u)
			{
				throw new ArithmeticException();
			}
			switch (Class26.Class31.smethod_4(class29_0, class29_1))
			{
			case (Class26.Enum3)(-1):
				throw new ArithmeticException();
			case (Class26.Enum3)0:
				return 0;
			case (Class26.Enum3)1:
				return Class26.Class31.smethod_1(class29_0, class29_1);
			default:
                throw new System.Exception();
			}
		}

		public Class26.Class29 wfQvayhew(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			Class26.Class30 @class = new Class26.Class30(class29_1);
			return @class.method_3(this, class29_0);
		}

		internal uint uint_0 = 1u;

		internal uint[] uint_1;
	}

	internal sealed class Class30
	{
		public Class30(Class26.Class29 class29_2)
		{
			this.class29_0 = class29_2;
			uint num = this.class29_0.uint_0 << 1;
			this.class29_1 = new Class26.Class29((Class26.Enum3)1, num + 1u);
			this.class29_1.uint_1[(int)((UIntPtr)num)] = 1u;
			this.class29_1 /= this.class29_0;
		}

		public void method_0(Class26.Class29 class29_2)
		{
			Class26.Class29 @class = this.class29_0;
			uint uint_ = @class.uint_0;
			uint num = uint_ + 1u;
			uint num2 = uint_ - 1u;
			if (class29_2.uint_0 < uint_)
			{
				return;
			}
			if ((long)class29_2.uint_1.Length < (long)((ulong)class29_2.uint_0))
			{
				throw new IndexOutOfRangeException("x out of range");
			}
			Class26.Class29 class2 = new Class26.Class29((Class26.Enum3)1, class29_2.uint_0 - num2 + this.class29_1.uint_0);
			Class26.Class31.smethod_12(class29_2.uint_1, num2, class29_2.uint_0 - num2, this.class29_1.uint_1, 0u, this.class29_1.uint_0, class2.uint_1, 0u);
			uint uint_2 = (class29_2.uint_0 > num) ? num : class29_2.uint_0;
			class29_2.uint_0 = uint_2;
			class29_2.method_5();
			Class26.Class29 class3 = new Class26.Class29((Class26.Enum3)1, num);
			Class26.Class31.smethod_13(class2.uint_1, (int)num, (int)(class2.uint_0 - num), @class.uint_1, 0, (int)@class.uint_0, class3.uint_1, 0, (int)num);
			class3.method_5();
			if (class3 <= class29_2)
			{
				Class26.Class31.smethod_2(class29_2, class3);
			}
			else
			{
				Class26.Class29 class4 = new Class26.Class29((Class26.Enum3)1, num + 1u);
				class4.uint_1[(int)((UIntPtr)num)] = 1u;
				Class26.Class31.smethod_2(class4, class3);
				Class26.Class31.smethod_3(class29_2, class4);
			}
			while (class29_2 >= @class)
			{
				Class26.Class31.smethod_2(class29_2, @class);
			}
		}

		public Class26.Class29 method_1(Class26.Class29 class29_2, Class26.Class29 class29_3)
		{
			if (!(class29_2 == 0u) && !(class29_3 == 0u))
			{
				if (class29_2 > this.class29_0)
				{
					class29_2 %= this.class29_0;
				}
				if (class29_3 > this.class29_0)
				{
					class29_3 %= this.class29_0;
				}
				Class26.Class29 @class = class29_2 * class29_3;
				this.method_0(@class);
				return @class;
			}
			return 0;
		}

		public Class26.Class29 method_2(Class26.Class29 class29_2, Class26.Class29 class29_3)
		{
			Class26.Enum3 @enum = Class26.Class31.smethod_4(class29_2, class29_3);
			Class26.Class29 @class;
			switch (@enum)
			{
			case (Class26.Enum3)(-1):
				@class = class29_3 - class29_2;
				break;
			case (Class26.Enum3)0:
				return 0;
			case (Class26.Enum3)1:
				@class = class29_2 - class29_3;
				break;
			default:
                throw new System.Exception();
			}
			if (@class >= this.class29_0)
			{
				if (@class.uint_0 >= this.class29_0.uint_0 << 1)
				{
					@class %= this.class29_0;
				}
				else
				{
					this.method_0(@class);
				}
			}
			if (@enum == (Class26.Enum3)(-1))
			{
				@class = this.class29_0 - @class;
			}
			return @class;
		}

		public Class26.Class29 method_3(Class26.Class29 class29_2, Class26.Class29 class29_3)
		{
			Class26.Class29 @class = new Class26.Class29(1u);
			if (class29_3 == 0u)
			{
				return @class;
			}
			Class26.Class29 class2 = class29_2;
			if (class29_3.method_1(0))
			{
				@class = class29_2;
			}
			for (int i = 1; i < class29_3.method_0(); i++)
			{
				class2 = this.method_1(class2, class2);
				if (class29_3.method_1(i))
				{
					@class = this.method_1(class2, @class);
				}
			}
			return @class;
		}

		public Class26.Class29 method_4(uint uint_0, Class26.Class29 class29_2)
		{
			return this.method_3(new Class26.Class29(uint_0), class29_2);
		}

		private Class26.Class29 class29_0;

		private Class26.Class29 class29_1;
	}

	private sealed class Class31
	{
		public Class31()
		{
		}

		public static Class26.Class29 smethod_0(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			uint num = 0u;
			uint[] uint_;
			uint uint_2;
			uint[] uint_3;
			uint uint_4;
			if (class29_0.uint_0 < class29_1.uint_0)
			{
				uint_ = class29_1.uint_1;
				uint_2 = class29_1.uint_0;
				uint_3 = class29_0.uint_1;
				uint_4 = class29_0.uint_0;
			}
			else
			{
				uint_ = class29_0.uint_1;
				uint_2 = class29_0.uint_0;
				uint_3 = class29_1.uint_1;
				uint_4 = class29_1.uint_0;
			}
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, uint_2 + 1u);
			uint[] uint_5 = @class.uint_1;
			ulong num2 = 0uL;
			do
			{
				num2 = (ulong)uint_[(int)((UIntPtr)num)] + (ulong)uint_3[(int)((UIntPtr)num)] + num2;
				uint_5[(int)((UIntPtr)num)] = (uint)num2;
				num2 >>= 32;
			}
			while ((num += 1u) < uint_4);
			bool flag;
			if (flag = (num2 != 0uL))
			{
				if (num < uint_2)
				{
					do
					{
						flag = ((uint_5[(int)((UIntPtr)num)] = uint_[(int)((UIntPtr)num)] + 1u) == 0u);
					}
					while ((num += 1u) < uint_2 && flag);
				}
				if (flag)
				{
					uint_5[(int)((UIntPtr)num)] = 1u;
					@class.uint_0 = num + 1u;
					return @class;
				}
			}
			if (num < uint_2)
			{
				do
				{
					uint_5[(int)((UIntPtr)num)] = uint_[(int)((UIntPtr)num)];
				}
				while ((num += 1u) < uint_2);
			}
			@class.method_5();
			return @class;
		}

		public static Class26.Class29 smethod_1(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0);
			uint[] uint_ = @class.uint_1;
			uint[] uint_2 = class29_0.uint_1;
			uint[] uint_3 = class29_1.uint_1;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = uint_3[(int)((UIntPtr)num)];
				if ((num3 += num2) < num2 | (uint_[(int)((UIntPtr)num)] = uint_2[(int)((UIntPtr)num)] - num3) > ~num3)
				{
					num2 = 1u;
				}
				else
				{
					num2 = 0u;
				}
			}
			while ((num += 1u) < class29_1.uint_0);
			if (num != class29_0.uint_0)
			{
				if (num2 == 1u)
				{
					do
					{
						uint_[(int)((UIntPtr)num)] = uint_2[(int)((UIntPtr)num)] - 1u;
					}
					while (uint_2[(int)((UIntPtr)(num++))] == 0u && num < class29_0.uint_0);
					if (num == class29_0.uint_0)
					{
						goto IL_C8;
					}
				}
				do
				{
					uint_[(int)((UIntPtr)num)] = uint_2[(int)((UIntPtr)num)];
				}
				while ((num += 1u) < class29_0.uint_0);
			}
			IL_C8:
			@class.method_5();
			return @class;
		}

		public static Class26.Class29 smethod_10(Class26.Class29 class29_0, int int_0)
		{
			if (int_0 == 0)
			{
				return new Class26.Class29(class29_0);
			}
			int num = int_0 >> 5;
			int num2 = int_0 & 31;
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0 - (uint)num + 1u);
			uint num3 = (uint)(@class.uint_1.Length - 1);
			if (num2 != 0)
			{
				uint num4 = 0u;
				while (num3-- > 0u)
				{
					uint num5 = class29_0.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num)))))];
					@class.uint_1[(int)((UIntPtr)num3)] = (num5 >> int_0 | num4);
					num4 = num5 << 32 - int_0;
				}
			}
			else
			{
				while (num3-- > 0u)
				{
					@class.uint_1[(int)((UIntPtr)num3)] = class29_0.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num)))))];
				}
			}
			@class.method_5();
			return @class;
		}

		public static Class26.Class29 smethod_11(Class26.Class29 class29_0, uint uint_0)
		{
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0 + 1u);
			uint num = 0u;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)class29_0.uint_1[(int)((UIntPtr)num)] * (ulong)uint_0;
				@class.uint_1[(int)((UIntPtr)num)] = (uint)num2;
				num2 >>= 32;
			}
			while ((num += 1u) < class29_0.uint_0);
			@class.uint_1[(int)((UIntPtr)num)] = (uint)num2;
			@class.method_5();
			return @class;
		}

		public unsafe static void smethod_12(uint[] uint_0, uint uint_1, uint uint_2, uint[] uint_3, uint uint_4, uint uint_5, uint[] uint_6, uint uint_7)
		{
            if (uint_0 == null || uint_0.Length == 0||uint_3 == null || uint_3.Length == 0||uint_6 == null || uint_6.Length == 0)
			{
                return;
			}
            fixed (uint* ptr = &uint_0[0], ptr2 = &uint_3[0], ptr3 = &uint_6[0])
            {
			uint* ptr4 = ptr + uint_1;
			uint* ptr5 = ptr4 + uint_2;
			uint* ptr6 = ptr2 + uint_4;
			uint* ptr7 = ptr6 + uint_5;
			uint* ptr8 = ptr3 + uint_7;
			while (ptr4 < ptr5)
			{
				if (*ptr4 != 0u)
				{
					ulong num = 0uL;
					uint* ptr9 = ptr8;
					uint* ptr10 = ptr6;
					while (ptr10 < ptr7)
					{
						num += (ulong)(*ptr4) * (ulong)(*ptr10) + (ulong)(*ptr9);
						*ptr9 = (uint)num;
						num >>= 32;
						ptr10++;
						ptr9++;
					}
					if (num != 0uL)
					{
						*ptr9 = (uint)num;
					}
				}
				ptr4++;
				ptr8++;
			}
			
            }
		}

		public unsafe static void smethod_13(uint[] uint_0, int int_0, int int_1, uint[] uint_1, int int_2, int int_3, uint[] uint_2, int int_4, int int_5)
		{
			uint* ptr=null;
			if (uint_0 != null && uint_0.Length != 0)
			{
				//fixed ( ptr = &uint_0[0])
				{
				}
			}
			else
			{
				ptr = null;
			}
			uint* ptr2=null;
			if (uint_1 != null && uint_1.Length != 0)
			{
				//fixed ( ptr2 = &uint_1[0])
				{
				}
			}
			else
			{
				ptr2 = null;
			}
			uint* ptr3=null;
			if (uint_2 != null && uint_2.Length != 0)
			{
				//fixed ( ptr3 = &uint_2[0])
				{
				}
			}
			else
			{
				ptr3 = null;
			}
			uint* ptr4 = ptr + int_0;
			uint* ptr5 = ptr4 + int_1;
			uint* ptr6 = ptr2 + int_2;
			uint* ptr7 = ptr6 + int_3;
			uint* ptr8 = ptr3 + int_4;
			uint* ptr9 = ptr8 + int_5;
			while (ptr4 < ptr5)
			{
				if (*ptr4 != 0u)
				{
					ulong num = 0uL;
					uint* ptr10 = ptr8;
					uint* ptr11 = ptr6;
					while (ptr11 < ptr7 && ptr10 < ptr9)
					{
						num += (ulong)(*ptr4) * (ulong)(*ptr11) + (ulong)(*ptr10);
						*ptr10 = (uint)num;
						num >>= 32;
						ptr11++;
						ptr10++;
					}
					if (num != 0uL && ptr10 < ptr9)
					{
						*ptr10 = (uint)num;
					}
				}
				ptr4++;
				ptr8++;
			}
			ptr = null;
			ptr2 = null;
			ptr3 = null;
		}

		public unsafe static void smethod_14(Class26.Class29 class29_0, ref uint[] uint_0)
		{
			uint[] array = uint_0;
			uint_0 = class29_0.uint_1;
			uint[] uint_ = class29_0.uint_1;
			uint uint_2 = class29_0.uint_0;
			class29_0.uint_1 = array;
			uint[] array2;
			uint* ptr=null;
			if ((array2 = uint_) != null && array2.Length != 0)
			{
				//fixed ( ptr = &array2[0])
				{
				}
			}
			else
			{
				ptr = null;
			}
			uint[] array3;
			uint* ptr2=null;
			if ((array3 = array) != null && array3.Length != 0)
			{
				//fixed ( ptr2 = &array3[0])
				{
				}
			}
			else
			{
				ptr2 = null;
			}
			uint* ptr3 = ptr2 + array.Length;
			for (uint* ptr4 = ptr2; ptr4 < ptr3; ptr4++)
			{
				*ptr4 = 0u;
			}
			uint* ptr5 = ptr;
			uint* ptr6 = ptr2;
			uint num = 0u;
			while (num < uint_2)
			{
				if (*ptr5 != 0u)
				{
					ulong num2 = 0uL;
					uint num3 = *ptr5;
					uint* ptr7 = ptr5 + 1;
					uint* ptr8 = ptr6 + 2u * num + 1;
					uint num4 = num + 1u;
					while (num4 < uint_2)
					{
						num2 += (ulong)num3 * (ulong)(*ptr7) + (ulong)(*ptr8);
						*ptr8 = (uint)num2;
						num2 >>= 32;
						num4 += 1u;
						ptr8++;
						ptr7++;
					}
					if (num2 != 0uL)
					{
						*ptr8 = (uint)num2;
					}
				}
				num += 1u;
				ptr5++;
			}
			ptr6 = ptr2;
			uint num5 = 0u;
			while (ptr6 < ptr3)
			{
				uint num6 = *ptr6;
				*ptr6 = (num6 << 1 | num5);
				num5 = num6 >> 31;
				ptr6++;
			}
			if (num5 != 0u)
			{
				*ptr6 = num5;
			}
			ptr5 = ptr;
			ptr6 = ptr2;
			uint* ptr9 = ptr5 + uint_2;
			while (ptr5 < ptr9)
			{
				ulong num7 = (ulong)(*ptr5) * (ulong)(*ptr5) + (ulong)(*ptr6);
				*ptr6 = (uint)num7;
				num7 >>= 32;
				*(++ptr6) += (uint)num7;
				if (*ptr6 < (uint)num7)
				{
					uint* ptr10 = ptr6;
					*(++ptr10) += 1u;
					while (*(ptr10++) == 0u)
					{
						*ptr10 += 1u;
					}
				}
				ptr5++;
				ptr6++;
			}
			class29_0.uint_0 <<= 1;
			while (ptr2[class29_0.uint_0 - 1u] == 0u && class29_0.uint_0 > 1u)
			{
				class29_0.uint_0 -= 1u;
			}
			ptr = null;
			ptr2 = null;
		}

		public static Class26.Class29 smethod_15(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			Class26.Class29 @class = class29_0;
			Class26.Class29 class2 = class29_1;
			Class26.Class29 class3 = class2;
			while (@class.uint_0 > 1u)
			{
				class3 = @class;
				@class = class2 % @class;
				class2 = class3;
			}
			if (@class == 0u)
			{
				return class3;
			}
			uint num = @class.uint_1[0];
			uint num2 = class2 % num;
			int num3 = 0;
			while (((num2 | num) & 1u) == 0u)
			{
				num2 >>= 1;
				num >>= 1;
				num3++;
			}
			while (num2 != 0u)
			{
				while ((num2 & 1u) == 0u)
				{
					num2 >>= 1;
				}
				while ((num & 1u) == 0u)
				{
					num >>= 1;
				}
				if (num2 >= num)
				{
					num2 = num2 - num >> 1;
				}
				else
				{
					num = num - num2 >> 1;
				}
			}
			return num << num3;
		}

		public static uint smethod_16(Class26.Class29 class29_0, uint uint_0)
		{
			uint num = uint_0;
			uint num2 = class29_0 % uint_0;
			uint num3 = 0u;
			uint num4 = 1u;
			while (num2 != 0u)
			{
				if (num2 == 1u)
				{
					return num4;
				}
				num3 += num / num2 * num4;
				num %= num2;
				if (num == 0u)
				{
					return 0u;
				}
				if (num == 1u)
				{
					return uint_0 - num3;
				}
				num4 += num2 / num * num3;
				num2 %= num;
			}
			return 0u;
		}

		public static Class26.Class29 smethod_17(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			if (class29_1.uint_0 == 1u)
			{
				return Class26.Class31.smethod_16(class29_0, class29_1.uint_1[0]);
			}
			Class26.Class29[] array = new Class26.Class29[]
			{
				0,
				1
			};
			Class26.Class29[] array2 = new Class26.Class29[2];
			Class26.Class29[] array3 = new Class26.Class29[]
			{
				0,
				0
			};
			int num = 0;
			Class26.Class29 class29_2 = class29_1;
			Class26.Class29 @class = class29_0;
			Class26.Class30 class2 = new Class26.Class30(class29_1);
			while (@class != 0u)
			{
				if (num > 1)
				{
					Class26.Class29 class3 = class2.method_2(array[0], array[1] * array2[0]);
					array[0] = array[1];
					array[1] = class3;
				}
				Class26.Class29[] array4 = Class26.Class31.smethod_8(class29_2, @class);
				array2[0] = array2[1];
				array2[1] = array4[0];
				array3[0] = array3[1];
				array3[1] = array4[1];
				class29_2 = @class;
				@class = array4[1];
				num++;
			}
			if (array3[0] != 1u)
			{
				throw new ArithmeticException("No inverse!");
			}
			return class2.method_2(array[0], array[1] * array2[0]);
		}

		public static void smethod_2(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			uint[] uint_ = class29_0.uint_1;
			uint[] uint_2 = class29_1.uint_1;
			uint num = 0u;
			uint num2 = 0u;
			do
			{
				uint num3 = uint_2[(int)((UIntPtr)num)];
				if ((num3 += num2) < num2 | (uint_[(int)((UIntPtr)num)] -= num3) > ~num3)
				{
					num2 = 1u;
				}
				else
				{
					num2 = 0u;
				}
			}
			while ((num += 1u) < class29_1.uint_0);
			if (num != class29_0.uint_0 && num2 == 1u)
			{
				do
				{
					uint_[(int)((UIntPtr)num)] -= 1u;
				}
				while (uint_[(int)((UIntPtr)(num++))] == 0u && num < class29_0.uint_0);
			}
			while (class29_0.uint_0 > 0u && class29_0.uint_1[(int)((UIntPtr)(class29_0.uint_0 - 1u))] == 0u)
			{
				class29_0.uint_0 -= 1u;
			}
			if (class29_0.uint_0 == 0u)
			{
				class29_0.uint_0 += 1u;
			}
		}

		public static void smethod_3(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			uint num = 0u;
			bool flag = false;
			uint[] uint_;
			uint uint_2;
			uint[] uint_3;
			uint uint_4;
			if (class29_0.uint_0 < class29_1.uint_0)
			{
				flag = true;
				uint_ = class29_1.uint_1;
				uint_2 = class29_1.uint_0;
				uint_3 = class29_0.uint_1;
				uint_4 = class29_0.uint_0;
			}
			else
			{
				uint_ = class29_0.uint_1;
				uint_2 = class29_0.uint_0;
				uint_3 = class29_1.uint_1;
				uint_4 = class29_1.uint_0;
			}
			uint[] uint_5 = class29_0.uint_1;
			ulong num2 = 0uL;
			do
			{
				num2 += (ulong)uint_[(int)((UIntPtr)num)] + (ulong)uint_3[(int)((UIntPtr)num)];
				uint_5[(int)((UIntPtr)num)] = (uint)num2;
				num2 >>= 32;
			}
			while ((num += 1u) < uint_4);
			bool flag2;
			if (flag2 = (num2 != 0uL))
			{
				if (num < uint_2)
				{
					do
					{
						flag2 = ((uint_5[(int)((UIntPtr)num)] = uint_[(int)((UIntPtr)num)] + 1u) == 0u);
					}
					while ((num += 1u) < uint_2 && flag2);
				}
				if (flag2)
				{
					uint_5[(int)((UIntPtr)num)] = 1u;
					class29_0.uint_0 = num + 1u;
					return;
				}
			}
			if (flag && num < uint_2 - 1u)
			{
				do
				{
					uint_5[(int)((UIntPtr)num)] = uint_[(int)((UIntPtr)num)];
				}
				while ((num += 1u) < uint_2);
			}
			class29_0.uint_0 = uint_2 + 1u;
			class29_0.method_5();
		}

		public static Class26.Enum3 smethod_4(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			uint num = class29_0.uint_0;
			uint num2 = class29_1.uint_0;
			while (num > 0u && class29_0.uint_1[(int)((UIntPtr)(num - 1u))] == 0u)
			{
				num -= 1u;
			}
			while (num2 > 0u && class29_1.uint_1[(int)((UIntPtr)(num2 - 1u))] == 0u)
			{
				num2 -= 1u;
			}
			if (num == 0u && num2 == 0u)
			{
				return (Class26.Enum3)0;
			}
			if (num < num2)
			{
				return (Class26.Enum3)(-1);
			}
			if (num > num2)
			{
				return (Class26.Enum3)1;
			}
			uint num3;
			for (num3 = num - 1u; num3 != 0u; num3 -= 1u)
			{
				if (class29_0.uint_1[(int)((UIntPtr)num3)] != class29_1.uint_1[(int)((UIntPtr)num3)])
				{
					break;
				}
			}
			if (class29_0.uint_1[(int)((UIntPtr)num3)] < class29_1.uint_1[(int)((UIntPtr)num3)])
			{
				return (Class26.Enum3)(-1);
			}
			if (class29_0.uint_1[(int)((UIntPtr)num3)] > class29_1.uint_1[(int)((UIntPtr)num3)])
			{
				return (Class26.Enum3)1;
			}
			return (Class26.Enum3)0;
		}

		public static uint smethod_5(Class26.Class29 class29_0, uint uint_0)
		{
			ulong num = 0uL;
			uint uint_ = class29_0.uint_0;
			while (uint_-- > 0u)
			{
				num <<= 32;
				num |= (ulong)class29_0.uint_1[(int)((UIntPtr)uint_)];
				class29_0.uint_1[(int)((UIntPtr)uint_)] = (uint)(num / (ulong)uint_0);
				num %= (ulong)uint_0;
			}
			class29_0.method_5();
			return (uint)num;
		}

		public static uint smethod_6(Class26.Class29 class29_0, uint uint_0)
		{
			ulong num = 0uL;
			uint uint_ = class29_0.uint_0;
			while (uint_-- > 0u)
			{
				num <<= 32;
				num |= (ulong)class29_0.uint_1[(int)((UIntPtr)uint_)];
				num %= (ulong)uint_0;
			}
			return (uint)num;
		}

		public static Class26.Class29[] smethod_7(Class26.Class29 class29_0, uint uint_0)
		{
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0);
			ulong num = 0uL;
			uint uint_ = class29_0.uint_0;
			while (uint_-- > 0u)
			{
				num <<= 32;
				num |= (ulong)class29_0.uint_1[(int)((UIntPtr)uint_)];
				@class.uint_1[(int)((UIntPtr)uint_)] = (uint)(num / (ulong)uint_0);
				num %= (ulong)uint_0;
			}
			@class.method_5();
			Class26.Class29 class2 = (uint)num;
			return new Class26.Class29[]
			{
				@class,
				class2
			};
		}

		public static Class26.Class29[] smethod_8(Class26.Class29 class29_0, Class26.Class29 class29_1)
		{
			if (Class26.Class31.smethod_4(class29_0, class29_1) == (Class26.Enum3)(-1))
			{
				return new Class26.Class29[]
				{
					0,
					new Class26.Class29(class29_0)
				};
			}
			class29_0.method_5();
			class29_1.method_5();
			if (class29_1.uint_0 == 1u)
			{
				return Class26.Class31.smethod_7(class29_0, class29_1.uint_1[0]);
			}
			uint num = class29_0.uint_0 + 1u;
			int num2 = (int)(class29_1.uint_0 + 1u);
			uint num3 = 2147483648u;
			uint num4 = class29_1.uint_1[(int)((UIntPtr)(class29_1.uint_0 - 1u))];
			int num5 = 0;
			int num6 = (int)(class29_0.uint_0 - class29_1.uint_0);
			while (num3 != 0u && (num4 & num3) == 0u)
			{
				num5++;
				num3 >>= 1;
			}
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0 - class29_1.uint_0 + 1u);
			Class26.Class29 class2 = class29_0 << num5;
			uint[] uint_ = class2.uint_1;
			class29_1 <<= num5;
			int i = (int)(num - class29_1.uint_0);
			int num7 = (int)(num - 1u);
			uint num8 = class29_1.uint_1[(int)((UIntPtr)(class29_1.uint_0 - 1u))];
			ulong num9 = (ulong)class29_1.uint_1[(int)((UIntPtr)(class29_1.uint_0 - 2u))];
			while (i > 0)
			{
				ulong num10 = ((ulong)uint_[num7] << 32) + (ulong)uint_[num7 - 1];
				ulong num11 = num10 / (ulong)num8;
				ulong num12 = num10 % (ulong)num8;
				do
				{
					if (num11 != 4294967296uL)
					{
						if (num11 * num9 <= (num12 << 32) + (ulong)uint_[num7 - 2])
						{
							break;
						}
					}
					num11 -= 1uL;
					num12 += (ulong)num8;
				}
				while (num12 < 4294967296uL);
				IL_17A:
				uint num13 = 0u;
				int num14 = num7 - num2 + 1;
				ulong num15 = 0uL;
				uint num16 = (uint)num11;
				do
				{
					num15 += (ulong)class29_1.uint_1[(int)((UIntPtr)num13)] * (ulong)num16;
					uint num17 = uint_[num14];
					uint_[num14] -= (uint)num15;
					num15 >>= 32;
					if (uint_[num14] > num17)
					{
						num15 += 1uL;
					}
					num13 += 1u;
					num14++;
				}
				while ((ulong)num13 < (ulong)((long)num2));
				num14 = num7 - num2 + 1;
				num13 = 0u;
				if (num15 != 0uL)
				{
					num16 -= 1u;
					ulong num18 = 0uL;
					do
					{
						num18 = (ulong)uint_[num14] + (ulong)class29_1.uint_1[(int)((UIntPtr)num13)] + num18;
						uint_[num14] = (uint)num18;
						num18 >>= 32;
						num13 += 1u;
						num14++;
					}
					while ((ulong)num13 < (ulong)((long)num2));
				}
				@class.uint_1[num6--] = num16;
				num7--;
				i--;
				continue;
				goto IL_17A;
			}
			@class.method_5();
			class2.method_5();
			Class26.Class29[] array = new Class26.Class29[]
			{
				@class,
				class2
			};
			if (num5 != 0)
			{
				Class26.Class29[] array2;
				(array2 = array)[1] = array2[1] >> num5;
			}
			return array;
		}

		public static Class26.Class29 smethod_9(Class26.Class29 class29_0, int int_0)
		{
			if (int_0 == 0)
			{
				return new Class26.Class29(class29_0, class29_0.uint_0 + 1u);
			}
			int num = int_0 >> 5;
			int_0 &= 31;
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0 + 1u + (uint)num);
			uint num2 = 0u;
			uint uint_ = class29_0.uint_0;
			if (int_0 != 0)
			{
				uint num3 = 0u;
				while (num2 < uint_)
				{
					uint num4 = class29_0.uint_1[(int)((UIntPtr)num2)];
					@class.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num)))))] = (num4 << int_0 | num3);
					num3 = num4 >> 32 - int_0;
					num2 += 1u;
				}
				@class.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num)))))] = num3;
			}
			else
			{
				while (num2 < uint_)
				{
					@class.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num)))))] = class29_0.uint_1[(int)((UIntPtr)num2)];
					num2 += 1u;
				}
			}
			@class.method_5();
			return @class;
		}

		public static Class26.Class29 wfQvayhew(Class26.Class29 class29_0, uint uint_0)
		{
			Class26.Class29 @class = new Class26.Class29((Class26.Enum3)1, class29_0.uint_0);
			ulong num = 0uL;
			uint uint_ = class29_0.uint_0;
			while (uint_-- > 0u)
			{
				num <<= 32;
				num |= (ulong)class29_0.uint_1[(int)((UIntPtr)uint_)];
				@class.uint_1[(int)((UIntPtr)uint_)] = (uint)(num / (ulong)uint_0);
				num %= (ulong)uint_0;
			}
			@class.method_5();
			return @class;
		}
	}

	internal class Class32
	{
		public Class32()
		{
		}

		[DllImport("iphlpapi.dll", CharSet = CharSet.Ansi)]
		public static extern int GetAdaptersInfo(IntPtr intptr_0, ref long long_0);

		internal static string smethod_0()
		{
			string text = string.Empty;
			try
			{
				long value = (long)Marshal.SizeOf(typeof(Class26.Struct1));
				IntPtr intPtr = Marshal.AllocHGlobal(new IntPtr(value));
				int adaptersInfo = Class26.Class32.GetAdaptersInfo(intPtr, ref value);
				if (adaptersInfo == 111)
				{
					intPtr = Marshal.ReAllocHGlobal(intPtr, new IntPtr(value));
					adaptersInfo = Class26.Class32.GetAdaptersInfo(intPtr, ref value);
				}
				if (adaptersInfo == 0)
				{
					IntPtr ptr = intPtr;
					Class26.Struct1 @struct = (Class26.Struct1)Marshal.PtrToStructure(ptr, typeof(Class26.Struct1));
					int num = 0;
					while ((long)num < (long)((ulong)@struct.uint_0))
					{
						text += @struct.byte_0[num].ToString("X2");
						num++;
					}
					Marshal.FreeHGlobal(intPtr);
				}
				else
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			catch
			{
			}
			if (text == string.Empty)
			{
				text = "";
			}
			return text;
		}
	}

	internal class Class33
	{
		public Class33()
		{
		}

		[DllImport("Kernel32.dll")]
		private static extern bool CloseHandle(IntPtr intptr_0);

		[DllImport("Kernel32.dll")]
		private static extern IntPtr CreateFile(string string_0, uint uint_1, int int_7, IntPtr intptr_0, int int_8, int int_9, IntPtr intptr_1);

		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool DeviceIoControl(IntPtr intptr_0, uint uint_1, IntPtr intptr_1, uint uint_2, [Out] IntPtr intptr_2, uint uint_3, ref uint uint_4, IntPtr intptr_3);

		internal static string smethod_0()
		{
			try
			{
				int num = 16;
				for (int i = 0; i < num; i++)
				{
					string string_ = "\\\\.\\PHYSICALDRIVE" + i.ToString();
					IntPtr intPtr;
					if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					{
						intPtr = Class26.Class33.CreateFile(string_, 0u, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
					}
					else
					{
						intPtr = Class26.Class33.CreateFile("\\\\.\\Smartvsd", 0u, 0, IntPtr.Zero, 1, 0, IntPtr.Zero);
					}
					if ((int)intPtr != -1)
					{
						Class26.Struct5 @struct = default(Class26.Struct5);
						@struct.enum4_0 = (Class26.Enum4)0;
						@struct.enum5_0 = (Class26.Enum5)0;
						uint num2 = (uint)Marshal.SizeOf(typeof(Class26.Struct5));
						IntPtr intPtr2 = Marshal.AllocHGlobal((int)num2);
						Marshal.StructureToPtr(@struct, intPtr2, true);
						IntPtr intPtr3 = Marshal.AllocHGlobal(1024);
						uint num3 = 0u;
						if (Class26.Class33.DeviceIoControl(intPtr, 2954240u, intPtr2, num2, intPtr3, 1024u, ref num3, IntPtr.Zero))
						{
							Class26.Struct4 struct2 = (Class26.Struct4)Marshal.PtrToStructure(intPtr3, typeof(Class26.Struct4));
							int num4 = intPtr3.ToInt32();
							string text = string.Empty;
							if (struct2.uint_4 != 0u)
							{
								text = Marshal.PtrToStringAnsi((IntPtr)((long)num4 + (long)((ulong)struct2.uint_4)));
							}
							if (text != null && text.Length > 0)
							{
								Marshal.FreeHGlobal(intPtr3);
								Marshal.FreeHGlobal(intPtr2);
								Class26.Class33.CloseHandle(intPtr);
								return text;
							}
						}
						Marshal.FreeHGlobal(intPtr3);
						Marshal.FreeHGlobal(intPtr2);
					}
					Class26.Class33.CloseHandle(intPtr);
				}
			}
			catch
			{
			}
			return "failure";
		}

		private const int int_0 = 2954240;

		private const int int_1 = 2952208;

		private const int int_2 = 1;

		private const int int_3 = 2;

		private const int int_4 = 3;

		private const int int_5 = -1;

		private const int int_6 = 1;

		private const uint uint_0 = 2147483648u;

		private const uint wfQvayhew = 1073741824u;
	}

	internal sealed class Class34
	{
		public Class34()
		{
			try
			{
				RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
				this.byte_0 = new byte[32];
				rNGCryptoServiceProvider.GetBytes(this.byte_0);
				this.wfQvayhew = new Class26.Class28();
				this.bool_0 = false;
			}
			catch
			{
			}
		}

		public Class34(Class26.Class28 class28_0)
		{
			try
			{
				if (class28_0 == null)
				{
					throw new ArgumentNullException("rsa");
				}
				this.method_8(class28_0);
				this.bool_0 = false;
			}
			catch
			{
			}
		}

		internal void method_0(string string_1)
		{
			try
			{
				Stream stream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
				BinaryReader binaryReader = new BinaryReader(stream);
				bool flag = false;
				if (binaryReader.BaseStream.Length == 32L)
				{
					this.method_5(new byte[binaryReader.BaseStream.Length]);
					this.method_5(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length));
					flag = true;
					this.bool_0 = true;
				}
				binaryReader.Close();
				stream.Close();
				if (!flag)
				{
					this.bool_0 = false;
					using (StreamReader streamReader = new StreamReader(string_1))
					{
						string text = streamReader.ReadLine();
						string[] array = text.Split(new char[]
						{
							'|'
						});
						this.byte_0 = Convert.FromBase64String(array[0]);
						this.string_0 = array[1];
						this.wfQvayhew = new Class26.Class28();
						this.method_7().FromXmlString(this.string_0);
						if (this.string_0.Length != this.method_7().ToXmlString(false).Length)
						{
							this.string_0 = this.method_7().ToXmlString(true);
						}
					}
				}
			}
			catch
			{
			}
		}

		internal void method_1(string string_1)
		{
			try
			{
				string_1 = string_1.Trim();
				try
				{
					if (!(string_1 == string.Empty) && string_1.Length != 0)
					{
						if (string_1.Length == 32)
						{
							this.byte_0 = new byte[32];
							for (int i = 0; i < 32; i++)
							{
								this.byte_0[i] = (byte)string_1.ToCharArray()[i];
							}
						}
						else if (string_1.Length == 96)
						{
							this.byte_0 = new byte[32];
							for (int j = 0; j < 32; j++)
							{
								this.byte_0[j] = Convert.ToByte(string_1.Substring(j * 3, 3));
							}
							this.bool_0 = true;
						}
						else
						{
							this.bool_0 = false;
							string text = string_1;
							string[] array = text.Split(new char[]
							{
								'|'
							});
							this.byte_0 = Convert.FromBase64String(array[0]);
							this.string_0 = array[1];
							this.wfQvayhew = new Class26.Class28();
							this.method_7().FromXmlString(this.string_0);
							if (this.string_0.Length != this.method_7().ToXmlString(false).Length)
							{
								this.string_0 = this.method_7().ToXmlString(true);
							}
						}
					}
					else
					{
						RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
						this.byte_0 = new byte[32];
						rNGCryptoServiceProvider.GetBytes(this.byte_0);
						this.wfQvayhew = new Class26.Class28();
						this.bool_0 = false;
					}
				}
				catch
				{
					RNGCryptoServiceProvider rNGCryptoServiceProvider2 = new RNGCryptoServiceProvider();
					this.byte_0 = new byte[32];
					rNGCryptoServiceProvider2.GetBytes(this.byte_0);
					this.wfQvayhew = new Class26.Class28();
					this.method_7().FromXmlString(this.string_0);
					this.bool_0 = false;
				}
			}
			catch
			{
			}
		}

		internal void method_2(string string_1)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(string_1))
				{
					streamWriter.Write(Convert.ToBase64String(this.byte_0) + "|" + this.string_0);
				}
			}
			catch
			{
			}
		}

		public string method_3()
		{
			string result;
			try
			{
				result = Convert.ToBase64String(this.byte_0) + "|" + this.method_7().ToXmlString(false);
			}
			catch
			{
				result = Convert.ToBase64String(this.byte_0);
			}
			return result;
		}

		public byte[] method_4()
		{
			return this.byte_0;
		}

		public void method_5(byte[] byte_1)
		{
			this.byte_0 = byte_1;
		}

		public void method_6(bool bool_1)
		{
			this.bool_0 = bool_1;
		}

		public Class26.Class28 method_7()
		{
			try
			{
				if (this.wfQvayhew == null)
				{
					this.wfQvayhew = new Class26.Class28();
				}
			}
			catch
			{
			}
			return this.wfQvayhew;
		}

		public void method_8(Class26.Class28 class28_0)
		{
			this.wfQvayhew = class28_0;
		}

		public bool NdudXono0()
		{
			return this.bool_0;
		}

		private static byte[] smethod_0(string string_1)
		{
			byte[] result;
			try
			{
				byte[] array = null;
				FileStream fileStream = File.Open(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
				try
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
				}
				finally
				{
					fileStream.Close();
				}
				result = array;
			}
			catch
			{
				result = new byte[0];
			}
			return result;
		}

		internal static byte[] smethod_1(Class26.Class28 class28_0, byte[] byte_1)
		{
			byte[] result;
			try
			{
				result = class28_0.method_9(byte_1, HashAlgorithm.Create("MD5"));
			}
			catch
			{
				result = new byte[0];
			}
			return result;
		}

		internal static bool smethod_2(Class26.Class28 class28_0, byte[] byte_1, byte[] byte_2)
		{
			bool result;
			try
			{
				result = class28_0.method_10(byte_1, HashAlgorithm.Create("MD5"), byte_2);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public override string ToString()
		{
			return Convert.ToBase64String(this.byte_0) + "|" + this.string_0;
		}

		private bool bool_0;

		private byte[] byte_0 = new byte[0];

		private string string_0 = "";

		private Class26.Class28 wfQvayhew;
	}

	internal sealed class Class35
	{
		static Class35()
		{
			Class26.Class35.uint_1 = new uint[256];
			Class26.Class35.uint_2 = 3988292384u;
		}

		private Class35()
		{
		}

		public static bool smethod_0()
		{
			return Class26.Class35.bool_0;
		}

		[CLSCompliant(false)]
		public static void smethod_1(uint uint_3)
		{
			if (!Class26.Class35.bool_0)
			{
				Class26.Class35.uint_2 = uint_3;
				for (uint num = 0u; num < 256u; num += 1u)
				{
					uint num2 = num;
					for (uint num3 = 8u; num3 > 0u; num3 -= 1u)
					{
						if ((num2 & 1u) != 0u)
						{
							num2 = (num2 >> 1 ^ Class26.Class35.uint_2);
						}
						else
						{
							num2 >>= 1;
						}
					}
					Class26.Class35.uint_1[(int)((UIntPtr)num)] = num2;
				}
				Class26.Class35.bool_0 = true;
			}
		}

		public static void smethod_2(int int_1)
		{
			byte[] bytes = BitConverter.GetBytes(int_1);
			uint uint_ = BitConverter.ToUInt32(bytes, 0);
			Class26.Class35.smethod_1(uint_);
		}

		public static void smethod_3(long long_0)
		{
			uint uint_ = (uint)(long_0 & 4294967295L);
			Class26.Class35.smethod_1(uint_);
		}

		public static void smethod_4()
		{
			Class26.Class35.smethod_1(3988292384u);
		}

		public static byte[] smethod_5(byte[] byte_0)
		{
			if (!Class26.Class35.bool_0)
			{
				throw new InvalidOperationException("You must initialize the CRC table before attempting to calculate the check on data.");
			}
			uint num = (uint)byte_0.Length;
			uint num2 = 4294967295u;
			for (uint num3 = 0u; num3 < num; num3 += 1u)
			{
				num2 = (num2 >> 8 ^ Class26.Class35.uint_1[(int)((UIntPtr)((uint)byte_0[(int)((UIntPtr)num3)] ^ (num2 & 255u)))]);
			}
			uint value = num2 ^ 4294967295u;
			return BitConverter.GetBytes(value);
		}

		public static byte[] smethod_6(string string_0)
		{
			return Class26.Class35.wfQvayhew(string_0, Encoding.ASCII);
		}

		public static string smethod_7(string string_0)
		{
			string text = "";
			byte[] array = Class26.Class35.wfQvayhew(string_0, Encoding.ASCII);
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("X2");
			}
			return text;
		}

		public static byte[] wfQvayhew(string string_0, Encoding encoding_0)
		{
			byte[] bytes = encoding_0.GetBytes(string_0);
			return Class26.Class35.smethod_5(bytes);
		}

		[CLSCompliant(false)]
		public static uint UInt32_0
		{
			get
			{
				return Class26.Class35.uint_2;
			}
		}

		private static bool bool_0;

		public const int int_0 = 256;

		[CLSCompliant(false)]
		public const uint uint_0 = 3988292384u;

		private static uint[] uint_1;

		private static uint uint_2;
	}

	[DefaultMember("Item")]
	internal sealed class Class36
	{
		public Class36(string[] string_0)
		{
			this.hashtable_0 = new Hashtable();
			Regex regex = new Regex("^-{1,2}|^/|=|:", RegexOptions.Compiled);
			Regex regex2 = new Regex("^['\"]?(.*?)['\"]?$", RegexOptions.Compiled);
			string text = null;
			for (int i = 0; i < string_0.Length; i++)
			{
				string input = string_0[i];
				string[] array = regex.Split(input, 3);
				switch (array.Length)
				{
				case 1:
					if (text != null)
					{
						if (!this.hashtable_0.Contains(text))
						{
							array[0] = regex2.Replace(array[0], "$1");
							this.hashtable_0.Add(text, array[0]);
						}
						text = null;
					}
					break;
				case 2:
					if (text != null && !this.hashtable_0.Contains(text))
					{
						this.hashtable_0.Add(text, "true");
					}
					text = array[1];
					break;
				case 3:
					if (text != null && !this.hashtable_0.Contains(text))
					{
						this.hashtable_0.Add(text, "true");
					}
					text = array[1];
					if (!this.hashtable_0.Contains(text))
					{
						array[2] = regex2.Replace(array[2], "$1");
						this.hashtable_0.Add(text, array[2]);
					}
					text = null;
					break;
				}
			}
			if (text != null && !this.hashtable_0.Contains(text))
			{
				this.hashtable_0.Add(text, "true");
			}
		}

		public string method_0(string string_0)
		{
			return (string)this.hashtable_0[string_0];
		}

		private Hashtable hashtable_0;
	}

	internal sealed class Class37
	{
		public Class37()
		{
		}

		public Class37(string string_0) : this(new StreamReader(string_0))
		{
		}

		public Class37(TextReader textReader_0) : this(textReader_0, (Class26.Enum7)0)
		{
		}

		public Class37(Stream stream_0) : this(new StreamReader(stream_0))
		{
		}

		public Class37(Class26.Class39 class39_0)
		{
			this.method_3(class39_0);
		}

		public Class37(string string_0, Class26.Enum7 enum7_0) : this(new StreamReader(string_0), enum7_0)
		{
		}

		public Class37(TextReader textReader_0, Class26.Enum7 enum7_0)
		{
			this.method_3(this.method_4(textReader_0, enum7_0));
		}

		public Class37(Stream stream_0, Class26.Enum7 enum7_0) : this(new StreamReader(stream_0), enum7_0)
		{
		}

		public Class26.Class41 method_0()
		{
			return this.class41_0;
		}

		public void method_1(TextWriter textWriter_0)
		{
			Class26.Class42 @class = new Class26.Class42(textWriter_0);
			foreach (string string_ in this.arrayList_0)
			{
				@class.wfQvayhew(string_);
			}
			for (int i = 0; i < this.class41_0.Count; i++)
			{
				Class26.Class40 class2 = this.class41_0.method_0(i);
				@class.method_13(class2.method_0(), class2.method_1());
				for (int j = 0; j < class2.method_2(); j++)
				{
					Class26.Class38 class3 = class2.method_4(j);
					switch (class3.method_0())
					{
					case (Class26.Enum9)1:
						@class.method_15(class3.method_4(), class3.method_2(), class3.method_5());
						break;
					case (Class26.Enum9)2:
						@class.wfQvayhew(class3.method_5());
						break;
					}
				}
			}
			@class.method_10();
		}

		public void method_2(string string_0)
		{
			StreamWriter streamWriter = new StreamWriter(string_0);
			this.method_1(streamWriter);
			streamWriter.Close();
		}

		private void method_3(Class26.Class39 class39_0)
		{
			class39_0.method_7(false);
			bool flag = false;
			Class26.Class40 @class = null;
			while (class39_0.method_12())
			{
				switch (class39_0.method_2())
				{
				case (Class26.Enum9)0:
					flag = true;
					if (this.class41_0.method_1(class39_0.method_0()) != null)
					{
						this.class41_0.method_3(class39_0.method_0());
					}
					@class = new Class26.Class40(class39_0.method_0(), class39_0.method_3());
					this.class41_0.method_2(@class);
					break;
				case (Class26.Enum9)1:
					@class.method_7(class39_0.method_0(), class39_0.method_1(), class39_0.method_3());
					break;
				case (Class26.Enum9)2:
					if (!flag)
					{
						this.arrayList_0.Add(class39_0.method_3());
					}
					else
					{
						@class.method_9(class39_0.method_3());
					}
					break;
				}
			}
			class39_0.method_15();
		}

		private Class26.Class39 method_4(TextReader textReader_0, Class26.Enum7 enum7_0)
		{
			Class26.Class39 @class = new Class26.Class39(textReader_0);
			switch (enum7_0)
			{
			case (Class26.Enum7)1:
				@class.guRquDeBa(false);
				@class.wfQvayhew(new char[]
				{
					':'
				});
				break;
			case (Class26.Enum7)2:
				@class.guRquDeBa(false);
				@class.method_10(true);
				break;
			}
			return @class;
		}

		private ArrayList arrayList_0 = new ArrayList();

		private Class26.Class41 class41_0 = new Class26.Class41();
	}

	[Class26.Attribute0(9223372036854775908uL)]
	internal class Class38
	{
		protected internal Class38(string string_3, string string_4, Class26.Enum9 enum9_1, string string_5)
		{
			this.string_0 = string_3;
			this.string_1 = string_4;
			this.enum9_0 = enum9_1;
			this.string_2 = string_5;
		}

		public Class26.Enum9 method_0()
		{
			return this.enum9_0;
		}

		public void method_1(Class26.Enum9 enum9_1)
		{
			this.enum9_0 = enum9_1;
		}

		public string method_2()
		{
			return this.string_1;
		}

		public void method_3(string string_3)
		{
			this.string_1 = string_3;
		}

		public string method_4()
		{
			return this.string_0;
		}

		public string method_5()
		{
			return this.string_2;
		}

		public void method_6(string string_3)
		{
			this.string_2 = string_3;
		}

		private Class26.Enum9 enum9_0 = (Class26.Enum9)2;

		private string string_0 = "";

		private string string_1 = "";

		private string string_2;
	}

	internal class Class39 : IDisposable
	{
		public Class39(string string_0)
		{
			this.textReader_0 = new StreamReader(string_0);
		}

		public Class39(TextReader textReader_1)
		{
			this.textReader_0 = textReader_1;
		}

		public Class39(Stream stream_0) : this(new StreamReader(stream_0))
		{
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		protected virtual void Dispose(bool bool_5)
		{
			if (!this.bool_2)
			{
				this.textReader_0.Close();
				this.bool_2 = true;
				if (bool_5)
				{
					GC.SuppressFinalize(this);
				}
			}
		}

		~Class39()
		{
			this.Dispose(false);
		}

		public void guRquDeBa(bool bool_5)
		{
			this.bool_4 = bool_5;
		}

		public string method_0()
		{
			return this.stringBuilder_0.ToString();
		}

		public string method_1()
		{
			return this.stringBuilder_1.ToString();
		}

		public void method_10(bool bool_5)
		{
			this.bool_3 = bool_5;
		}

		public bool method_11()
		{
			return this.bool_4;
		}

		public bool method_12()
		{
			bool result = false;
			if (this.enum8_0 != (Class26.Enum8)1 || this.enum8_0 != (Class26.Enum8)0)
			{
				this.enum8_0 = (Class26.Enum8)4;
				result = this.method_20();
			}
			return result;
		}

		public bool method_13()
		{
			bool flag;
			do
			{
				flag = this.method_12();
			}
			while (this.enum9_0 != (Class26.Enum9)0 && flag);
			return flag;
		}

		public bool method_14()
		{
			bool flag;
			while (true)
			{
				flag = this.method_12();
				if (this.enum9_0 == (Class26.Enum9)0)
				{
					break;
				}
				if (this.enum9_0 == (Class26.Enum9)1 || !flag)
				{
					return flag;
				}
			}
			flag = false;
			return flag;
		}

		public void method_15()
		{
			this.method_19();
			this.enum8_0 = (Class26.Enum8)0;
			if (this.textReader_0 != null)
			{
				this.textReader_0.Close();
			}
		}

		public char[] method_16()
		{
			return new char[0];
		}

		public void method_17(char[] char_2)
		{
		}

		public char[] method_18()
		{
			char[] array = new char[this.char_1.Length];
			Array.Copy(this.char_1, 0, array, 0, this.char_1.Length);
			return array;
		}

		private void method_19()
		{
			this.stringBuilder_0.Remove(0, this.stringBuilder_0.Length);
			this.stringBuilder_1.Remove(0, this.stringBuilder_1.Length);
			this.fuWlyMmwx.Remove(0, this.fuWlyMmwx.Length);
			this.enum9_0 = (Class26.Enum9)2;
			this.bool_1 = false;
		}

		public Class26.Enum9 method_2()
		{
			return this.enum9_0;
		}

		private bool method_20()
		{
			bool result = true;
			int num = this.method_29();
			this.method_19();
			if (this.method_30(num))
			{
				this.enum9_0 = (Class26.Enum9)2;
				this.method_28();
				this.method_21();
				return result;
			}
			int num2 = num;
			if (num2 <= 13)
			{
				if (num2 == -1)
				{
					this.enum8_0 = (Class26.Enum8)1;
					result = false;
					return result;
				}
				switch (num2)
				{
				case 9:
				case 13:
					goto IL_86;
				case 10:
					this.method_28();
					return result;
				}
			}
			else
			{
				if (num2 == 32)
				{
					goto IL_86;
				}
				if (num2 == 91)
				{
					this.method_25();
					return result;
				}
			}
			this.method_23();
			return result;
			IL_86:
			this.method_34();
			this.method_20();
			return result;
		}

		private void method_21()
		{
			this.method_34();
			this.bool_1 = true;
			int num;
			do
			{
				num = this.method_28();
				this.fuWlyMmwx.Append((char)num);
			}
			while (!this.method_35(num));
			this.method_22(this.fuWlyMmwx);
		}

		private void method_22(StringBuilder stringBuilder_2)
		{
			string text = stringBuilder_2.ToString();
			stringBuilder_2.Remove(0, stringBuilder_2.Length);
			stringBuilder_2.Append(text.TrimEnd(null));
		}

		private void method_23()
		{
			this.enum9_0 = (Class26.Enum9)1;
			while (true)
			{
				int int_ = this.method_29();
				if (this.method_31(int_))
				{
					break;
				}
				if (this.method_35(int_))
				{
					goto IL_39;
				}
				this.stringBuilder_0.Append((char)this.method_28());
			}
			this.method_28();
			this.method_24();
			this.method_26();
			this.method_22(this.stringBuilder_0);
			return;
			IL_39:
			throw new Class26.Exception0(this, string.Format("Expected assignment operator ({0})", this.char_1[0]));
		}

		private void method_24()
		{
			bool flag = false;
			int num = 0;
			this.method_34();
			while (true)
			{
				int num2 = this.method_29();
				if (!this.method_33(num2))
				{
					num++;
				}
				if (num2 == 34)
				{
					this.method_28();
					if (flag || num != 1)
					{
						goto IL_11C;
					}
					flag = true;
				}
				else
				{
					if (flag && this.method_35(num2))
					{
						break;
					}
					if (this.bool_3 && num2 == 92)
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append((char)this.method_28());
						while (this.method_29() != 10 && this.method_33(this.method_29()))
						{
							if (this.method_29() != 13)
							{
								stringBuilder.Append((char)this.method_28());
							}
							else
							{
								this.method_28();
							}
						}
						if (this.method_29() == 10)
						{
							this.method_28();
							continue;
						}
						this.stringBuilder_1.Append(stringBuilder.ToString());
					}
					if ((this.bool_4 && this.method_30(num2)) || this.method_35(num2))
					{
						goto IL_11C;
					}
					this.stringBuilder_1.Append((char)this.method_28());
				}
			}
			throw new Class26.Exception0(this, "Expected closing quote (\")");
			IL_11C:
			if (!flag)
			{
				this.method_22(this.stringBuilder_1);
			}
		}

		private void method_25()
		{
			this.enum9_0 = (Class26.Enum9)0;
			int num = this.method_28();
			while (true)
			{
				num = this.method_29();
				if (num == 93)
				{
					goto IL_48;
				}
				if (this.method_35(num))
				{
					break;
				}
				this.stringBuilder_0.Append((char)this.method_28());
			}
			throw new Class26.Exception0(this, "Expected section end (])");
			IL_48:
			this.method_27();
			this.method_22(this.stringBuilder_0);
		}

		private void method_26()
		{
			int int_ = this.method_28();
			while (!this.method_35(int_))
			{
				if (!this.method_30(int_))
				{
					int_ = this.method_28();
				}
				else
				{
					if (this.bool_0)
					{
						this.method_27();
						return;
					}
					this.method_21();
					return;
				}
			}
		}

		private void method_27()
		{
			int int_;
			do
			{
				int_ = this.method_28();
			}
			while (!this.method_35(int_));
		}

		private int method_28()
		{
			int num = this.textReader_0.Read();
			if (num == 10)
			{
				this.int_0++;
				this.int_1 = 1;
			}
			else
			{
				this.int_1++;
			}
			return num;
		}

		private int method_29()
		{
			return this.textReader_0.Peek();
		}

		public string method_3()
		{
			if (!this.bool_1)
			{
				return null;
			}
			return this.fuWlyMmwx.ToString();
		}

		private bool method_30(int int_2)
		{
			return this.method_32(this.char_0, int_2);
		}

		private bool method_31(int int_2)
		{
			return this.method_32(this.char_1, int_2);
		}

		private bool method_32(char[] char_2, int int_2)
		{
			bool result = false;
			for (int i = 0; i < char_2.Length; i++)
			{
				if (int_2 == (int)char_2[i])
				{
					result = true;
					return result;
				}
			}
			return result;
		}

		private bool method_33(int int_2)
		{
			return int_2 == 32 || int_2 == 9 || int_2 == 13 || int_2 == 10;
		}

		private void method_34()
		{
			while (this.method_33(this.method_29()))
			{
				if (this.method_35(this.method_29()))
				{
					return;
				}
				this.method_28();
			}
		}

		private bool method_35(int int_2)
		{
			return int_2 == 10 || int_2 == -1;
		}

		public int method_4()
		{
			return this.int_0;
		}

		public int method_5()
		{
			return this.int_1;
		}

		public bool method_6()
		{
			return this.bool_0;
		}

		public void method_7(bool bool_5)
		{
			this.bool_0 = bool_5;
		}

		public Class26.Enum8 method_8()
		{
			return this.enum8_0;
		}

		public bool method_9()
		{
			return this.bool_3;
		}

		public void wfQvayhew(char[] char_2)
		{
			if (char_2.Length < 1)
			{
				throw new ArgumentException("Must supply at least one delimiter");
			}
			this.char_1 = char_2;
		}

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4 = true;

		private char[] char_0 = new char[]
		{
			';'
		};

		private char[] char_1 = new char[]
		{
			'='
		};

		private Class26.Enum8 enum8_0 = (Class26.Enum8)3;

		private Class26.Enum9 enum9_0 = (Class26.Enum9)2;

		private StringBuilder fuWlyMmwx = new StringBuilder();

		private int int_0 = 1;

		private int int_1 = 1;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		private StringBuilder stringBuilder_1 = new StringBuilder();

		private TextReader textReader_0;
	}

	internal sealed class Class40
	{
		public Class40(string string_2) : this(string_2, null)
		{
		}

		public Class40(string string_2, string string_3)
		{
			this.string_0 = string_2;
			this.string_1 = string_3;
		}

		public string method_0()
		{
			return this.string_0;
		}

		public string method_1()
		{
			return this.string_1;
		}

		public void method_10(string string_2)
		{
			if (this.method_6(string_2))
			{
				this.class43_0.Remove(string_2);
			}
		}

		public int method_2()
		{
			return this.class43_0.Count;
		}

		public string method_3(string string_2)
		{
			string result = null;
			if (this.method_6(string_2))
			{
				Class26.Class38 @class = (Class26.Class38)this.class43_0[string_2];
				result = @class.method_2();
			}
			return result;
		}

		public Class26.Class38 method_4(int int_1)
		{
			return (Class26.Class38)this.class43_0.method_0(int_1);
		}

		public string[] method_5()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < this.class43_0.Count; i++)
			{
				Class26.Class38 @class = (Class26.Class38)this.class43_0.method_0(i);
				if (@class.method_0() == (Class26.Enum9)1)
				{
					arrayList.Add(@class.method_4());
				}
			}
			string[] array = new string[arrayList.Count];
			arrayList.CopyTo(array, 0);
			return array;
		}

		public bool method_6(string string_2)
		{
			return this.class43_0[string_2] != null;
		}

		public void method_7(string string_2, string string_3, string string_4)
		{
			Class26.Class38 @class;
			if (this.method_6(string_2))
			{
				@class = (Class26.Class38)this.class43_0[string_2];
				@class.method_3(string_3);
				@class.method_6(string_4);
				return;
			}
			@class = new Class26.Class38(string_2, string_3, (Class26.Enum9)1, string_4);
			this.class43_0.Add(string_2, @class);
		}

		public void method_8(string string_2, string string_3)
		{
			Class26.Class38 @class;
			if (this.method_6(string_2))
			{
				@class = (Class26.Class38)this.class43_0[string_2];
				@class.method_3(string_3);
				@class.method_6(this.string_1);
				return;
			}
			@class = new Class26.Class38(string_2, string_3, (Class26.Enum9)1, null);
			this.class43_0.Add(string_2, @class);
		}

		public void method_9(string string_2)
		{
			string text = "#comment" + this.int_0;
			Class26.Class38 value = new Class26.Class38(text, null, (Class26.Enum9)2, string_2);
			this.class43_0.Add(text, value);
			this.int_0++;
		}

		public void wfQvayhew()
		{
			this.method_9(null);
		}

		private Class26.Class43 class43_0 = new Class26.Class43();

		private int int_0;

		private string string_0 = "";

		private string string_1;
	}

	[DefaultMember("Item")]
	internal class Class41 : ICollection, IEnumerable
	{
		public Class41()
		{
		}

		public void CopyTo(Array array, int index)
		{
			this.class43_0.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return this.class43_0.method_5();
		}

		public Class26.Class40 method_0(int int_0)
		{
			return (Class26.Class40)this.class43_0.method_0(int_0);
		}

		public Class26.Class40 method_1(string string_0)
		{
			return (Class26.Class40)this.class43_0[string_0];
		}

		public void method_2(Class26.Class40 class40_0)
		{
			if (this.class43_0.Contains(class40_0))
			{
				throw new ArgumentException("IniSection already exists");
			}
			this.class43_0.Add(class40_0.method_0(), class40_0);
		}

		public void method_3(string string_0)
		{
			this.class43_0.Remove(string_0);
		}

		public void method_4(Class26.Class40[] class40_0, int int_0)
		{
			((ICollection)this.class43_0).CopyTo(class40_0, int_0);
		}

		public int Count
		{
			get
			{
				return this.class43_0.Count;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return this.class43_0.IsSynchronized;
			}
		}

		public object SyncRoot
		{
			get
			{
				return this.class43_0.SyncRoot;
			}
		}

		private Class26.Class43 class43_0 = new Class26.Class43();
	}

	internal class Class42 : IDisposable
	{
		public Class42(string string_1) : this(new FileStream(string_1, FileMode.Create, FileAccess.Write, FileShare.None))
		{
		}

		public Class42(TextWriter textWriter_1)
		{
			this.textWriter_0 = textWriter_1;
			StreamWriter streamWriter = textWriter_1 as StreamWriter;
			if (streamWriter != null)
			{
				this.stream_0 = streamWriter.BaseStream;
			}
		}

		public Class42(Stream stream_1) : this(new StreamWriter(stream_1))
		{
		}

		public void Dispose()
		{
			this.Dispose(true);
		}

		protected virtual void Dispose(bool bool_2)
		{
			if (!this.bool_1)
			{
				this.textWriter_0.Close();
				this.stream_0.Close();
				this.bool_1 = true;
				if (bool_2)
				{
					GC.SuppressFinalize(this);
				}
			}
		}

		~Class42()
		{
			this.Dispose(false);
		}

		public int method_0()
		{
			return this.int_0;
		}

		public void method_1(int int_1)
		{
			if (int_1 < 0)
			{
				throw new ArgumentException("Negative values are illegal");
			}
			this.int_0 = int_1;
			this.stringBuilder_0.Remove(0, this.stringBuilder_0.Length);
			for (int i = 0; i < int_1; i++)
			{
				this.stringBuilder_0.Append(' ');
			}
		}

		public void method_10()
		{
			this.textWriter_0.Close();
			this.enum10_0 = (Class26.Enum10)3;
		}

		public void method_11()
		{
			this.textWriter_0.Flush();
		}

		public void method_12(string string_1)
		{
			this.method_19();
			this.enum10_0 = (Class26.Enum10)2;
			this.method_22("[" + string_1 + "]");
		}

		public void method_13(string string_1, string string_2)
		{
			this.method_19();
			this.enum10_0 = (Class26.Enum10)2;
			this.method_22("[" + string_1 + "]" + this.method_20(string_2));
		}

		public void method_14(string string_1, string string_2)
		{
			this.method_18();
			this.method_22(string.Concat(new object[]
			{
				string_1,
				" ",
				this.char_1,
				" ",
				this.method_17(string_2)
			}));
		}

		public void method_15(string string_1, string string_2, string string_3)
		{
			this.method_18();
			this.method_22(string.Concat(new object[]
			{
				string_1,
				" ",
				this.char_1,
				" ",
				this.method_17(string_2),
				this.method_20(string_3)
			}));
		}

		public void method_16()
		{
			this.method_19();
			if (this.enum10_0 == (Class26.Enum10)0)
			{
				this.enum10_0 = (Class26.Enum10)1;
			}
			this.method_22("");
		}

		private string method_17(string string_1)
		{
			string result;
			if (this.bool_0)
			{
				result = this.method_23('"' + string_1 + '"');
			}
			else
			{
				result = this.method_23(string_1);
			}
			return result;
		}

		private void method_18()
		{
			this.method_19();
			switch (this.enum10_0)
			{
			case (Class26.Enum10)0:
			case (Class26.Enum10)1:
				throw new InvalidOperationException("The WriteState is not Section");
			case (Class26.Enum10)2:
				return;
			case (Class26.Enum10)3:
				throw new InvalidOperationException("The writer is closed");
			default:
				return;
			}
		}

		private void method_19()
		{
			if (this.enum10_0 == (Class26.Enum10)3)
			{
				throw new InvalidOperationException("The writer is closed");
			}
		}

		public bool method_2()
		{
			return this.bool_0;
		}

		private string method_20(string string_1)
		{
			if (string_1 != null)
			{
				return string.Concat(new object[]
				{
					" ",
					this.char_0,
					" ",
					string_1
				});
			}
			return "";
		}

		private void method_21(string string_1)
		{
			this.textWriter_0.Write(this.stringBuilder_0.ToString() + string_1);
		}

		private void method_22(string string_1)
		{
			this.method_21(string_1 + this.string_0);
		}

		private string method_23(string string_1)
		{
			return string_1.Replace("\n", "");
		}

		public void method_3(bool bool_2)
		{
			this.bool_0 = bool_2;
		}

		public Class26.Enum10 method_4()
		{
			return this.enum10_0;
		}

		public char method_5()
		{
			return this.char_0;
		}

		public void method_6(char char_2)
		{
			this.char_0 = char_2;
		}

		public char method_7()
		{
			return this.char_1;
		}

		public void method_8(char char_2)
		{
			this.char_1 = char_2;
		}

		public Stream method_9()
		{
			return this.stream_0;
		}

		public override string ToString()
		{
			return this.textWriter_0.ToString();
		}

		public void wfQvayhew(string string_1)
		{
			this.method_19();
			if (this.enum10_0 == (Class26.Enum10)0)
			{
				this.enum10_0 = (Class26.Enum10)1;
			}
			if (string_1 == null)
			{
				this.method_22("");
				return;
			}
			this.method_22(this.char_0 + " " + string_1);
		}

		private bool bool_0;

		private bool bool_1;

		private char char_0 = ';';

		private char char_1 = '=';

		private Class26.Enum10 enum10_0;

		private int int_0;

		private Stream stream_0;

		private StringBuilder stringBuilder_0 = new StringBuilder();

		private string string_0 = "\r\n";

		private TextWriter textWriter_0;
	}

	internal sealed class Class43 : ICollection, IEnumerable, IDictionary
	{
		public Class43()
		{
		}

		public void Add(object key, object value)
		{
			this.hashtable_0.Add(key, value);
			this.arrayList_0.Add(new DictionaryEntry(key, value));
		}

		public void Clear()
		{
			this.hashtable_0.Clear();
			this.arrayList_0.Clear();
		}

		public bool Contains(object key)
		{
			return this.hashtable_0.Contains(key);
		}

		public void CopyTo(Array array, int index)
		{
			this.hashtable_0.CopyTo(array, index);
		}

		public object method_0(int int_0)
		{
			return ((DictionaryEntry)this.arrayList_0[int_0]).Value;
		}

		public void method_1(int int_0, object object_0)
		{
			if (int_0 < 0 || int_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			object key = ((DictionaryEntry)this.arrayList_0[int_0]).Key;
			this.arrayList_0[int_0] = new DictionaryEntry(key, object_0);
			this.hashtable_0[key] = object_0;
		}

		public void method_2(DictionaryEntry[] dictionaryEntry_0, int int_0)
		{
			this.hashtable_0.CopyTo(dictionaryEntry_0, int_0);
		}

		public void method_3(int int_0, object object_0, object object_1)
		{
			if (int_0 > this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.hashtable_0.Add(object_0, object_1);
			this.arrayList_0.Insert(int_0, new DictionaryEntry(object_0, object_1));
		}

		public void method_4(int int_0)
		{
			if (int_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.hashtable_0.Remove(((DictionaryEntry)this.arrayList_0[int_0]).Key);
			this.arrayList_0.RemoveAt(int_0);
		}

		public IEnumerator method_5()
		{
			return new Class26.Class44(this.arrayList_0);
		}

		private int method_6(object object_0)
		{
			for (int i = 0; i < this.arrayList_0.Count; i++)
			{
				if (((DictionaryEntry)this.arrayList_0[i]).Key.Equals(object_0))
				{
					return i;
				}
			}
			return -1;
		}

		public void Remove(object key)
		{
			this.hashtable_0.Remove(key);
			this.arrayList_0.RemoveAt(this.method_6(key));
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Class26.Class44(this.arrayList_0);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Class26.Class44(this.arrayList_0);
		}

		public int Count
		{
			get
			{
				return this.arrayList_0.Count;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		public object this[object key]
		{
			get
			{
				return this.hashtable_0[key];
			}
			set
			{
				if (this.hashtable_0.Contains(key))
				{
					this.hashtable_0[key] = value;
					this.hashtable_0[this.method_6(key)] = new DictionaryEntry(key, value);
					return;
				}
				this.Add(key, value);
			}
		}

		public ICollection Keys
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < this.arrayList_0.Count; i++)
				{
					arrayList.Add(((DictionaryEntry)this.arrayList_0[i]).Key);
				}
				return arrayList;
			}
		}

		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		public ICollection Values
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < this.arrayList_0.Count; i++)
				{
					arrayList.Add(((DictionaryEntry)this.arrayList_0[i]).Value);
				}
				return arrayList;
			}
		}

		private ArrayList arrayList_0 = new ArrayList();

		private Hashtable hashtable_0 = new Hashtable();
	}

	internal sealed class Class44 : IEnumerator, IDictionaryEnumerator
	{
		internal Class44(ArrayList arrayList_1)
		{
			this.arrayList_0 = arrayList_1;
		}

		public DictionaryEntry method_0()
		{
			if (this.int_0 < 0 || this.int_0 >= this.arrayList_0.Count)
			{
				throw new InvalidOperationException();
			}
			return (DictionaryEntry)this.arrayList_0[this.int_0];
		}

		public bool MoveNext()
		{
			this.int_0++;
			return this.int_0 < this.arrayList_0.Count;
		}

		public void Reset()
		{
			this.int_0 = -1;
		}

		public DictionaryEntry Entry
		{
			get
			{
				return this.method_0();
			}
		}

		public object Key
		{
			get
			{
				return this.Entry.Key;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				if (this.int_0 < 0 || this.int_0 >= this.arrayList_0.Count)
				{
					throw new InvalidOperationException();
				}
				return this.arrayList_0[this.int_0];
			}
		}

		public object Value
		{
			get
			{
				return this.Entry.Value;
			}
		}

		private ArrayList arrayList_0;

		private int int_0 = -1;
	}

	internal sealed class Class45
	{
		public Class45()
		{
		}

		internal void method_0()
		{
			if (this.class34_0 != null && this.class34_0.method_7() != null)
			{
				this.class34_0.method_7().Clear();
			}
		}

		public Class26.Class37 method_1(bool bool_57, bool bool_58)
		{
			Class26.Class37 @class = new Class26.Class37();
			Class26.Class40 class2 = new Class26.Class40("General_Settings");
			class2.method_7("General_Loading_Screen_Enable", this.bool_0.ToString(), "");
			class2.method_7("General_Exception_Catching", this.bool_1.ToString(), "");
			class2.method_7("General_V3Mode", this.bool_2.ToString(), "");
			class2.method_7("General_VistaAdmin", this.bool_3.ToString(), "");
			class2.method_7("General_App_Icon", this.string_0.ToString(), "");
			class2.method_7("SPC_File", this.string_1.ToString(), "");
			class2.method_7("PVK_File", this.string_2.ToString(), "");
			class2.method_7("PVK_Password", this.string_3.ToString(), "");
			class2.method_7("General_App_Satellite_Assemblies", this.string_4.ToString(), "");
			class2.method_7("General_App_Satellite_Assemblies_Sizes", this.string_5.ToString(), "");
			class2.method_7("General_App_Console", this.bool_25.ToString(), "");
			class2.method_7("General_RequestHID", this.bool_26.ToString(), "");
			class2.method_7("General_Lib_Necrobit", this.bool_5.ToString(), "");
			class2.method_7("General_Mono_Mode", this.bool_6.ToString(), "");
			class2.method_7("General_AdditionalFilesOwnDirectory", this.bool_7.ToString(), "");
			class2.method_7("General_Lib_Obfuscation", this.bool_8.ToString(), "");
			class2.method_7("General_Lib_Merge", this.bool_9.ToString(), "");
			class2.method_7("General_Lib_Pack", this.bool_10.ToString(), "");
			class2.method_7("General_NAT_Merge", this.bool_11.ToString(), "");
			class2.method_7("General_NATCOMP_Merge", this.bool_12.ToString(), "");
			class2.method_7("General_STRONGPRO", this.bool_13.ToString(), "");
			class2.method_7("General_PatchPRO", this.bool_14.ToString(), "");
			class2.method_7("General_ResourcePRO", this.bool_15.ToString(), "");
			class2.method_7("General_NativeApp", this.bool_16.ToString(), "");
			class2.method_7("General_Prejit", this.bool_17.ToString(), "");
			class2.method_7("SuppressILDASM", this.bool_18.ToString(), "");
			class2.method_7("General_Obfuscate_Serializable_Types", this.bool_19.ToString(), "");
			class2.method_7("General_Lib_MappingFile", this.bool_20.ToString(), "");
			class2.method_7("General_Obfuscate_Public_Items", this.bool_21.ToString(), "");
			class2.method_7("General_Control_Flow_Obfuscation", this.bool_22.ToString(), "");
			class2.method_7("General_Control_Flow_Obfuscation_Level", this.int_0.ToString(), "");
			class2.method_7("General_Lib_Obfuscation_Unprintable_Characters", this.bool_23.ToString(), "");
			class2.method_7("General_SetCompatibleTextRenderingDefault", this.bool_28.ToString(), "");
			class2.method_7("General_RenderingDefault", this.bool_29.ToString(), "");
			class2.method_7("General_App_VisualStyles", this.bool_4.ToString(), "");
			class2.method_7("General_Lib_String_Encryption", this.bool_24.ToString(), "");
			class2.method_7("General_Lib_DesignTimeLicense", "False", "");
			class2.method_7("General_Lib_AntiDecompiler", "True", "");
			class2.method_7("General_Lib_Native_Protection_License_System", this.bool_30.ToString(), "");
			class2.method_7("General_Lib_Native_Satellite_Name", this.string_6.ToString(), "");
			class2.method_7("General_License_File_Name", this.string_10.ToString(), "");
			class2.method_7("General_PID", this.string_11.ToString(), "");
			class2.method_7("Assembly_File_Name", this.string_12.ToString(), "");
			class2.method_7("Assembly_Full_Name", this.string_13.ToString(), "");
			class2.method_7("General_Lib_Strong_Name_Key_Pair", this.string_7.ToString(), "");
			class2.method_7("General_Target_FileName", this.string_8.ToString(), "");
			class2.method_7("General_Lib_Remove_Resources", this.bool_27.ToString(), "");
			class2.method_7("General_Compressor", this.bool_31.ToString(), "");
			if (bool_57)
			{
				string text = "";
				for (int i = 0; i < this.class34_0.method_4().Length; i++)
				{
					text += this.class34_0.method_4()[i].ToString("D3");
				}
				class2.method_7("MasterKey", text.ToString(), "");
			}
			else if (bool_58)
			{
				class2.method_7("MasterKey", this.class34_0.method_3(), "");
			}
			else
			{
				class2.method_7("MasterKey", this.class34_0.ToString(), "");
			}
			class2.method_7("ImageRuntimeVersion", this.string_9.ToString(), "");
			class2.method_7("PFX_Password", this.string_14.ToString(), "");
			string text2 = "";
			IDictionaryEnumerator enumerator = this.hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				text2 = string.Concat(new object[]
				{
					text2,
					enumerator.Key,
					"|",
					enumerator.Value,
					"|"
				});
			}
			text2 = text2.Replace("\"", "'");
			class2.method_7("AdditonalLicenseInformation", text2, "");
			class2.method_7("General_Protection_Type_Enable", this.jnZrMnduej.ToString(), "");
			@class.method_0().method_2(class2);
			class2 = new Class26.Class40("Lock_Settings");
			class2.method_7("Lock_Snag_Screen_Enable", this.bool_34.ToString(), "");
			class2.method_7("Not_Found_Screen_Enable", this.bool_35.ToString(), "");
			class2.method_7("Run_Without_License_File", this.bool_32.ToString(), "");
			class2.method_7("Expiration_Behaviour_ALL", this.bool_33.ToString(), "");
			class2.method_7("Lock_Expiration_Screen_Enable", this.bool_36.ToString(), "");
			class2.method_7("Dialogs_Trial_Period_End_Enabled", this.bool_48.ToString(), "");
			class2.method_7("Dialogs_Number_Of_Uses_Enabled", this.bool_49.ToString(), "");
			class2.method_7("Dialogs_Expiration_Date_Enabled", this.bool_50.ToString(), "");
			class2.method_7("Lock_Max_Processes_Exceeded_Screen_Enable", this.bool_37.ToString(), "");
			class2.method_7("Lock_Expiration_Date_Enable", this.bool_38.ToString(), "");
			class2.method_7("Lock_Hardware_Enable", false.ToString(), "");
			class2.method_7("Lock_Hardware_HDD", this.bool_40.ToString(), "");
			class2.method_7("Lock_Hardware_MAC", this.bool_41.ToString(), "");
			class2.method_7("Lock_Hardware_BOARD", this.bool_42.ToString(), "");
			class2.method_7("Lock_Hardware_CPU", this.bool_43.ToString(), "");
			class2.method_7("Lock_License_Enable", this.bool_38.ToString(), "");
			class2.method_7("Lock_License_Expiration_Date", this.dateTime_0.Year.ToString("D4") + this.dateTime_0.Month.ToString("D2") + this.dateTime_0.Day.ToString("D2"), "");
			class2.method_7("Lock_Evaluation_Enable", this.bool_46.ToString(), "");
			class2.method_7("Lock_Number_Of_Uses_Enable", this.bool_44.ToString(), "");
			class2.method_7("Lock_Max_Number_Of_Processes_Enable", this.bool_45.ToString(), "");
			class2.method_7("Lock_Evaluation_Type", this.enum11_0.ToString(), "");
			class2.method_7("Lock_Evaluation_Time", this.int_3.ToString(), "");
			class2.method_7("Lock_Number_Of_Uses", this.int_4.ToString(), "");
			class2.method_7("Lock_Number_Of_Processes", this.int_1.ToString(), "");
			class2.method_7("Lock_Nag_XDays_Before_Expiration", this.int_2.ToString(), "");
			class2.method_7("License_Number_Of_Uses", this.int_5.ToString(), "");
			class2.method_7("License_Number_Of_Processes", this.int_6.ToString(), "");
			class2.method_7("Lock_Expiration_Date", this.dateTime_0.Year.ToString("D4") + this.dateTime_0.Month.ToString("D2") + this.dateTime_0.Day.ToString("D2"), "");
			class2.method_7("Lock_Close_Process_After_Expiration", this.bool_47.ToString(), "");
			class2.method_7("Lock_Run_Another_Process_After_Expiration", this.string_15.ToString(), "");
			class2.method_7("License_Number_Of_Uses_Enable", this.bool_51.ToString(), "");
			class2.method_7("License_Global_Licensing_Behaviour", this.bool_52.ToString(), "");
			class2.method_7("License_Max_Number_Of_Processes_Enable", this.bool_53.ToString(), "");
			class2.method_7("License_Hardware_Enable", this.bool_54.ToString(), "");
			class2.method_7("License_Evaluation_Enable", this.bool_56.ToString(), "");
			class2.method_7("License_Evaluation_Type", this.enum11_1.ToString(), "");
			class2.method_7("License_Evaluation_Time", this.int_7.ToString(), "");
			class2.method_7("License_Expiration_Date_Enable", this.bool_55.ToString(), "");
			class2.method_7("License_Expiration_Date", this.dateTime_1.Year.ToString("D4") + this.dateTime_1.Month.ToString("D2") + this.dateTime_1.Day.ToString("D2"), "");
			@class.method_0().method_2(class2);
			class2 = new Class26.Class40("Dialogs");
			class2.method_7("Dialogs_Caption", this.string_16.ToString(), "");
			class2.method_7("CustomizeMessageBox", this.string_17.ToString(), "");
			class2.method_7("Dialogs_License_Expired", this.string_18.ToString(), "");
			class2.method_7("Dialogs_SnagScreen", this.string_19.ToString(), "");
			class2.method_7("Dialogs_Invalid_License", this.string_20.ToString(), "");
			class2.method_7("Dialogs_License_Examination_Failed", "", "");
			class2.method_7("Dialogs_Trial_Period_End", this.string_21.ToString(), "");
			class2.method_7("Dialogs_Number_Of_Uses", this.string_22.ToString(), "");
			class2.method_7("Dialogs_Max_Processes_Exceeded", this.string_23.ToString(), "");
			class2.method_7("Dialogs_Gradient_Color_Begin", Class26.Class27.smethod_8(this.color_0), "");
			class2.method_7("Dialogs_Gradient_Color_End", Class26.Class27.smethod_8(this.color_1), "");
			class2.method_7("License_HardwareID_2", this.string_24.ToString(), "");
			@class.method_0().method_2(class2);
			return @class;
		}

		public void method_10(string string_25)
		{
			if (this.bool_2)
			{
				byte[] inArray = this.method_6();
				byte[] inArray2 = Class26.Class34.smethod_1(this.class34_0.method_7(), inArray);
				Class26.Class37 @class = new Class26.Class37();
				Class26.Class40 class2 = new Class26.Class40("sdtwe4dbutueteretdg4er");
				class2.method_7("ujh45mngsdrt3", Convert.ToBase64String(inArray), "");
				class2.method_7("kjrwejhjsnbbhherw", Convert.ToBase64String(inArray2), "");
				@class.method_0().method_2(class2);
				MemoryStream memoryStream = new MemoryStream();
				StreamWriter streamWriter = new StreamWriter(memoryStream);
				@class.method_1(streamWriter);
				Class26 class3 = new Class26();
				byte[] array = class3.method_5(memoryStream, true);
				streamWriter.Close();
				FileStream fileStream = new FileStream(string_25, FileMode.Create, FileAccess.ReadWrite);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				return;
			}
			byte[] array2 = this.method_6();
			FileStream fileStream2 = new FileStream(string_25, FileMode.Create, FileAccess.ReadWrite);
			fileStream2.Write(array2, 0, array2.Length);
			fileStream2.Close();
		}

		public void method_11(string string_25)
		{
			byte[] array = this.method_3();
			FileStream fileStream = new FileStream(string_25, FileMode.Create, FileAccess.ReadWrite);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
		}

		public string method_12(string string_25, string string_26)
		{
			string result;
			try
			{
				if (Path.GetDirectoryName(string_26.Replace("<", "").Replace(">", "")).ToUpper().IndexOf(Path.GetDirectoryName(string_25).ToUpper()) >= 0)
				{
					result = string_26.Substring(Path.GetDirectoryName(string_25).Length).Trim(new char[]
					{
						'\\'
					});
				}
				else
				{
					result = string_26;
				}
			}
			catch
			{
				result = string_26;
			}
			return result;
		}

		public string method_13(string string_25, string string_26)
		{
			string result;
			try
			{
				if (string_26 != null && string_26.Length > 0 && string_26[0] == '<')
				{
					result = string_26;
				}
				else if (!Path.IsPathRooted(string_26.Replace("<", "").Replace(">", "")))
				{
					result = Path.GetDirectoryName(string_25) + '\\' + string_26;
				}
				else
				{
					result = string_26;
				}
			}
			catch
			{
				result = string_26;
			}
			return result;
		}

		public void method_14(string string_25, bool bool_57)
		{
			string text = this.string_12;
			string text2 = this.string_0;
			string text3 = this.string_1;
			string text4 = this.string_2;
			string text5 = this.string_7;
			string text6 = this.string_4;
			this.string_8 = this.string_8.Trim();
			string text7 = this.string_8;
			if (this.string_12.Length > 0)
			{
				this.string_12 = this.method_12(string_25, this.string_12);
			}
			if (this.string_0.Length > 0)
			{
				this.string_0 = this.method_12(string_25, this.string_0);
			}
			if (this.string_1.Length > 0)
			{
				this.string_1 = this.method_12(string_25, this.string_1);
			}
			if (this.string_2.Length > 0)
			{
				this.string_2 = this.method_12(string_25, this.string_2);
			}
			if (this.string_8.Length > 0)
			{
				this.string_8 = this.method_12(string_25, this.string_8);
			}
			if (this.string_7.Length > 0)
			{
				this.string_7 = this.method_12(string_25, this.string_7);
			}
			if (this.string_4.Length > 0)
			{
				string str = "";
				string[] array = this.string_4.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					str += this.method_12(string_25, array[i]);
					if (i < array.Length - 1)
					{
						str += "|";
					}
				}
				this.string_4 = str;
			}
			if (!bool_57)
			{
				this.method_1(false, false).method_2(string_25);
			}
			else
			{
				byte[] array2 = this.method_3();
				FileStream fileStream = new FileStream(string_25, FileMode.Create, FileAccess.ReadWrite);
				fileStream.Write(array2, 0, array2.Length);
				fileStream.Close();
			}
			this.string_12 = text;
			this.string_0 = text2;
			this.string_7 = text5;
			this.string_4 = text6;
			this.string_8 = text7;
			this.string_1 = text3;
			this.string_2 = text4;
		}

		public void method_15(Class26.Class37 class37_1)
		{
			Class26.Class40 @class = class37_1.method_0().method_1("General_Settings");
			this.bool_0 = bool.Parse(@class.method_3("General_Loading_Screen_Enable"));
			try
			{
				if (@class.method_3("General_V3Mode") != null)
				{
					this.bool_2 = bool.Parse(@class.method_3("General_V3Mode"));
				}
				else
				{
					this.bool_2 = false;
				}
			}
			catch
			{
				this.bool_2 = false;
			}
			try
			{
				if (@class.method_3("General_VistaAdmin") != null)
				{
					this.bool_3 = bool.Parse(@class.method_3("General_VistaAdmin"));
				}
				else
				{
					this.bool_3 = false;
				}
			}
			catch
			{
				this.bool_3 = false;
			}
			try
			{
				if (@class.method_3("General_Exception_Catching") != null)
				{
					this.bool_1 = bool.Parse(@class.method_3("General_Exception_Catching"));
				}
				else
				{
					this.bool_1 = true;
				}
			}
			catch
			{
				this.bool_1 = true;
			}
			this.string_0 = "";
			try
			{
				if (@class.method_3("SPC_File") != null)
				{
					this.string_1 = @class.method_3("SPC_File");
				}
				else
				{
					this.string_1 = "";
				}
			}
			catch
			{
				this.string_1 = "";
			}
			try
			{
				if (@class.method_3("PVK_File") != null)
				{
					this.string_2 = @class.method_3("PVK_File");
				}
				else
				{
					this.string_2 = "";
				}
			}
			catch
			{
				this.string_2 = "";
			}
			try
			{
				if (@class.method_3("PVK_Password") != null)
				{
					this.string_3 = @class.method_3("PVK_Password");
				}
				else
				{
					this.string_3 = "";
				}
			}
			catch
			{
				this.string_3 = "";
			}
			this.string_4 = @class.method_3("General_App_Satellite_Assemblies");
			this.string_5 = @class.method_3("General_App_Satellite_Assemblies_Sizes");
			if (@class.method_3("General_App_Console") != null)
			{
				this.bool_25 = bool.Parse(@class.method_3("General_App_Console"));
			}
			else
			{
				this.bool_25 = false;
			}
			if (@class.method_3("General_RequestHID") != null)
			{
				this.bool_26 = bool.Parse(@class.method_3("General_RequestHID"));
			}
			else
			{
				this.bool_26 = false;
			}
			try
			{
				if (@class.method_3("General_Lib_Necrobit") != null)
				{
					this.bool_5 = bool.Parse(@class.method_3("General_Lib_Necrobit"));
				}
				else
				{
					this.bool_5 = true;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("General_Mono_Mode") != null)
				{
					this.bool_6 = bool.Parse(@class.method_3("General_Mono_Mode"));
				}
				else
				{
					this.bool_6 = false;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("General_AdditionalFilesOwnDirectory") != null)
				{
					this.bool_7 = bool.Parse(@class.method_3("General_AdditionalFilesOwnDirectory"));
				}
				else
				{
					this.bool_7 = false;
				}
			}
			catch
			{
				this.bool_7 = false;
			}
			try
			{
				if (@class.method_3("General_Lib_Obfuscation") != null)
				{
					this.bool_8 = bool.Parse(@class.method_3("General_Lib_Obfuscation"));
				}
				else
				{
					this.bool_8 = true;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("General_Lib_Merge") != null)
				{
					this.bool_9 = bool.Parse(@class.method_3("General_Lib_Merge"));
				}
				else
				{
					this.bool_9 = false;
				}
			}
			catch
			{
				this.bool_9 = false;
			}
			try
			{
				if (@class.method_3("General_Lib_Pack") != null)
				{
					this.bool_10 = bool.Parse(@class.method_3("General_Lib_Pack"));
				}
				else
				{
					this.bool_10 = false;
				}
			}
			catch
			{
				this.bool_10 = false;
			}
			try
			{
				if (@class.method_3("General_NAT_Merge") != null)
				{
					this.bool_11 = bool.Parse(@class.method_3("General_NAT_Merge"));
				}
				else
				{
					this.bool_11 = false;
				}
			}
			catch
			{
				this.bool_11 = false;
			}
			try
			{
				if (@class.method_3("General_NATCOMP_Merge") != null)
				{
					this.bool_12 = bool.Parse(@class.method_3("General_NATCOMP_Merge"));
				}
				else
				{
					this.bool_12 = false;
				}
			}
			catch
			{
				this.bool_12 = false;
			}
			try
			{
				if (@class.method_3("General_STRONGPRO") != null)
				{
					this.bool_13 = bool.Parse(@class.method_3("General_STRONGPRO"));
				}
				else
				{
					this.bool_13 = false;
				}
			}
			catch
			{
				this.bool_13 = false;
			}
			try
			{
				if (@class.method_3("General_PatchPRO") != null)
				{
					this.bool_14 = bool.Parse(@class.method_3("General_PatchPRO"));
				}
				else
				{
					this.bool_14 = false;
				}
			}
			catch
			{
				this.bool_14 = false;
			}
			try
			{
				if (@class.method_3("General_ResourcePRO") != null)
				{
					this.bool_15 = bool.Parse(@class.method_3("General_ResourcePRO"));
				}
				else
				{
					this.bool_15 = false;
				}
			}
			catch
			{
				this.bool_15 = false;
			}
			try
			{
				if (@class.method_3("General_NativeApp") != null)
				{
					this.bool_16 = bool.Parse(@class.method_3("General_NativeApp"));
				}
				else
				{
					this.bool_16 = false;
				}
			}
			catch
			{
				this.bool_16 = false;
			}
			try
			{
				if (@class.method_3("General_Prejit") != null)
				{
					this.bool_17 = bool.Parse(@class.method_3("General_Prejit"));
				}
				else
				{
					this.bool_17 = false;
				}
			}
			catch
			{
				this.bool_17 = false;
			}
			try
			{
				if (@class.method_3("SuppressILDASM") != null)
				{
					this.bool_18 = bool.Parse(@class.method_3("SuppressILDASM"));
				}
				else
				{
					this.bool_18 = true;
				}
			}
			catch
			{
				this.bool_18 = true;
			}
			try
			{
				if (@class.method_3("General_Obfuscate_Serializable_Types") != null)
				{
					this.bool_19 = bool.Parse(@class.method_3("General_Obfuscate_Serializable_Types"));
				}
				else
				{
					this.bool_19 = true;
				}
			}
			catch
			{
				this.bool_19 = true;
			}
			try
			{
				if (@class.method_3("General_Lib_MappingFile") != null)
				{
					this.bool_20 = bool.Parse(@class.method_3("General_Lib_MappingFile"));
				}
				else
				{
					this.bool_20 = false;
				}
			}
			catch
			{
				this.bool_20 = false;
			}
			try
			{
				if (@class.method_3("General_Obfuscate_Public_Items") != null)
				{
					this.bool_21 = bool.Parse(@class.method_3("General_Obfuscate_Public_Items"));
				}
				else
				{
					this.bool_21 = false;
				}
			}
			catch
			{
				this.bool_21 = false;
			}
			try
			{
				if (@class.method_3("General_Control_Flow_Obfuscation") != null)
				{
					this.bool_22 = bool.Parse(@class.method_3("General_Control_Flow_Obfuscation"));
				}
				else
				{
					this.bool_22 = false;
				}
			}
			catch
			{
				this.bool_22 = false;
			}
			try
			{
				if (@class.method_3("General_Control_Flow_Obfuscation_Level") != null)
				{
					this.int_0 = Convert.ToInt32(@class.method_3("General_Control_Flow_Obfuscation_Level"));
				}
				else
				{
					this.int_0 = 9;
				}
			}
			catch
			{
				this.int_0 = 9;
			}
			try
			{
				if (@class.method_3("General_Lib_Obfuscation_Unprintable_Characters") != null)
				{
					this.bool_23 = bool.Parse(@class.method_3("General_Lib_Obfuscation_Unprintable_Characters"));
				}
				else
				{
					this.bool_23 = false;
				}
			}
			catch
			{
				this.bool_23 = false;
			}
			try
			{
				if (@class.method_3("General_SetCompatibleTextRenderingDefault") != null)
				{
					this.bool_28 = bool.Parse(@class.method_3("General_SetCompatibleTextRenderingDefault"));
				}
				else
				{
					this.bool_28 = false;
				}
			}
			catch
			{
				this.bool_28 = false;
			}
			try
			{
				if (@class.method_3("General_RenderingDefault") != null)
				{
					this.bool_29 = bool.Parse(@class.method_3("General_RenderingDefault"));
				}
				else
				{
					this.bool_29 = true;
				}
			}
			catch
			{
				this.bool_29 = true;
			}
			try
			{
				if (@class.method_3("General_App_VisualStyles") != null)
				{
					this.bool_4 = bool.Parse(@class.method_3("General_App_VisualStyles"));
				}
				else
				{
					this.bool_4 = true;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("General_Lib_String_Encryption") != null)
				{
					this.bool_24 = bool.Parse(@class.method_3("General_Lib_String_Encryption"));
				}
				else
				{
					this.bool_24 = true;
				}
			}
			catch
			{
			}
			if (@class.method_3("General_Lib_Native_Protection_License_System") != null)
			{
				this.bool_30 = bool.Parse(@class.method_3("General_Lib_Native_Protection_License_System"));
			}
			else
			{
				this.bool_30 = true;
			}
			this.string_6 = @class.method_3("General_Lib_Native_Satellite_Name");
			this.string_10 = @class.method_3("General_License_File_Name");
			this.string_12 = @class.method_3("Assembly_File_Name");
			try
			{
				if (@class.method_3("Assembly_Full_Name") != null)
				{
					this.string_13 = @class.method_3("Assembly_Full_Name");
				}
				else
				{
					this.string_13 = "";
				}
			}
			catch
			{
				this.string_13 = "";
			}
			try
			{
				this.string_11 = @class.method_3("General_PID");
				if (this.string_11 == null)
				{
					this.string_11 = "";
				}
			}
			catch
			{
				this.string_11 = "";
			}
			try
			{
				if (@class.method_3("PFX_Password") != null)
				{
					this.string_14 = @class.method_3("PFX_Password");
				}
				else
				{
					this.string_14 = "";
				}
			}
			catch
			{
				this.string_14 = "";
			}
			this.string_7 = @class.method_3("General_Lib_Strong_Name_Key_Pair");
			try
			{
				this.string_8 = @class.method_3("General_Target_FileName");
				if (this.string_8 == null)
				{
					this.string_8 = "";
				}
			}
			catch
			{
				this.string_8 = "";
			}
			this.bool_27 = bool.Parse(@class.method_3("General_Lib_Remove_Resources"));
			if (@class.method_3("General_Compressor") != null && @class.method_3("General_Compressor").Length > 0)
			{
				this.bool_31 = bool.Parse(@class.method_3("General_Compressor"));
			}
			this.class34_0.method_1(@class.method_3("MasterKey"));
			this.string_9 = @class.method_3("ImageRuntimeVersion");
			string text = @class.method_3("AdditonalLicenseInformation");
			string[] array = text.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length / 2; i++)
			{
				this.hashtable_0.Add(array[i * 2], array[i * 2 + 1]);
			}
			this.jnZrMnduej = bool.Parse(@class.method_3("General_Protection_Type_Enable"));
			@class = class37_1.method_0().method_1("Lock_Settings");
			try
			{
				if (@class.method_3("Lock_Close_Process_After_Expiration") != null)
				{
					this.bool_47 = bool.Parse(@class.method_3("Lock_Close_Process_After_Expiration"));
				}
				else
				{
					this.bool_47 = true;
				}
			}
			catch
			{
				this.bool_47 = true;
			}
			try
			{
				if (@class.method_3("Lock_Run_Another_Process_After_Expiration") != null)
				{
					this.string_15 = @class.method_3("Lock_Run_Another_Process_After_Expiration");
				}
			}
			catch
			{
				this.string_15 = "";
			}
			this.bool_34 = bool.Parse(@class.method_3("Lock_Snag_Screen_Enable"));
			this.bool_36 = bool.Parse(@class.method_3("Lock_Expiration_Screen_Enable"));
			this.bool_49 = this.bool_36;
			this.bool_50 = this.bool_36;
			this.bool_48 = this.bool_36;
			try
			{
				if (@class.method_3("Dialogs_Number_Of_Uses_Enabled") != null)
				{
					this.bool_49 = bool.Parse(@class.method_3("Dialogs_Number_Of_Uses_Enabled"));
				}
				else
				{
					this.bool_49 = this.bool_36;
				}
			}
			catch
			{
				this.bool_49 = this.bool_36;
			}
			try
			{
				if (@class.method_3("Not_Found_Screen_Enable") != null)
				{
					this.bool_35 = bool.Parse(@class.method_3("Not_Found_Screen_Enable"));
				}
				else
				{
					this.bool_35 = true;
				}
			}
			catch
			{
				this.bool_35 = true;
			}
			try
			{
				if (@class.method_3("Dialogs_Expiration_Date_Enabled") != null)
				{
					this.bool_50 = bool.Parse(@class.method_3("Dialogs_Expiration_Date_Enabled"));
				}
				else
				{
					this.bool_50 = this.bool_36;
				}
			}
			catch
			{
				this.bool_50 = this.bool_36;
			}
			try
			{
				if (@class.method_3("Dialogs_Trial_Period_End_Enabled") != null)
				{
					this.bool_48 = bool.Parse(@class.method_3("Dialogs_Trial_Period_End_Enabled"));
				}
				else
				{
					this.bool_48 = this.bool_36;
				}
			}
			catch
			{
				this.bool_48 = this.bool_36;
			}
			try
			{
				if (@class.method_3("Lock_Max_Processes_Exceeded_Screen_Enable") != null)
				{
					this.bool_37 = bool.Parse(@class.method_3("Lock_Max_Processes_Exceeded_Screen_Enable"));
				}
				else
				{
					this.bool_37 = true;
				}
			}
			catch
			{
				this.bool_37 = true;
			}
			if (@class.method_3("Run_Without_License_File") != null)
			{
				this.bool_32 = bool.Parse(@class.method_3("Run_Without_License_File"));
			}
			else
			{
				this.bool_32 = true;
			}
			try
			{
				if (@class.method_3("Expiration_Behaviour_ALL") != null)
				{
					this.bool_33 = bool.Parse(@class.method_3("Expiration_Behaviour_ALL"));
				}
				else
				{
					this.bool_33 = true;
				}
			}
			catch
			{
				this.bool_33 = true;
			}
			if (@class.method_3("Lock_License_Enable") != null)
			{
				this.bool_38 = bool.Parse(@class.method_3("Lock_License_Enable"));
			}
			else
			{
				this.bool_38 = false;
			}
			if (@class.method_3("Lock_Expiration_Date_Enable") != null)
			{
				this.bool_38 = bool.Parse(@class.method_3("Lock_Expiration_Date_Enable"));
			}
			else
			{
				this.bool_38 = false;
			}
			this.bool_39 = false;
			if (@class.method_3("License_Hardware_Enable") != null)
			{
				this.bool_54 = bool.Parse(@class.method_3("License_Hardware_Enable"));
			}
			else
			{
				this.bool_54 = false;
			}
			if (@class.method_3("License_Expiration_Date_Enable") != null)
			{
				this.bool_55 = bool.Parse(@class.method_3("License_Expiration_Date_Enable"));
			}
			else
			{
				this.bool_55 = false;
			}
			if (@class.method_3("License_Evaluation_Enable") != null)
			{
				this.bool_56 = bool.Parse(@class.method_3("License_Evaluation_Enable"));
			}
			else
			{
				this.bool_56 = false;
			}
			try
			{
				if (@class.method_3("License_Evaluation_Type") != null)
				{
					this.enum11_1 = (Enum11)Enum.Parse(typeof(Enum11), @class.method_3("License_Evaluation_Type"));
				}
			}
			catch
			{
			}
			this.bool_46 = bool.Parse(@class.method_3("Lock_Evaluation_Enable"));
			try
			{
				if (@class.method_3("Lock_Hardware_HDD") != null)
				{
					this.bool_40 = bool.Parse(@class.method_3("Lock_Hardware_HDD"));
				}
				else
				{
					this.bool_40 = false;
				}
			}
			catch
			{
				this.bool_40 = false;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_MAC") != null)
				{
					this.bool_41 = bool.Parse(@class.method_3("Lock_Hardware_MAC"));
				}
				else
				{
					this.bool_41 = true;
				}
			}
			catch
			{
				this.bool_41 = true;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_BOARD") != null)
				{
					this.bool_42 = bool.Parse(@class.method_3("Lock_Hardware_BOARD"));
				}
				else
				{
					this.bool_42 = true;
				}
			}
			catch
			{
				this.bool_42 = true;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_CPU") != null)
				{
					this.bool_43 = bool.Parse(@class.method_3("Lock_Hardware_CPU"));
				}
				else
				{
					this.bool_43 = true;
				}
			}
			catch
			{
				this.bool_43 = true;
			}
			try
			{
				if (@class.method_3("Lock_Number_Of_Uses_Enable") != null)
				{
					this.bool_44 = bool.Parse(@class.method_3("Lock_Number_Of_Uses_Enable"));
				}
				else
				{
					this.bool_44 = false;
				}
			}
			catch
			{
				this.bool_44 = false;
			}
			try
			{
				if (@class.method_3("Lock_Max_Number_Of_Processes_Enable") != null)
				{
					this.bool_45 = bool.Parse(@class.method_3("Lock_Max_Number_Of_Processes_Enable"));
				}
				else
				{
					this.bool_45 = false;
				}
			}
			catch
			{
				this.bool_45 = false;
			}
			try
			{
				if (@class.method_3("License_Number_Of_Uses_Enable") != null)
				{
					this.bool_51 = bool.Parse(@class.method_3("License_Number_Of_Uses_Enable"));
				}
				else
				{
					this.bool_51 = false;
				}
			}
			catch
			{
				this.bool_51 = false;
			}
			try
			{
				if (@class.method_3("License_Global_Licensing_Behaviour") != null)
				{
					this.bool_52 = bool.Parse(@class.method_3("License_Global_Licensing_Behaviour"));
				}
				else
				{
					this.bool_52 = true;
				}
			}
			catch
			{
				this.bool_52 = true;
			}
			try
			{
				if (@class.method_3("License_Max_Number_Of_Processes_Enable") != null)
				{
					this.bool_53 = bool.Parse(@class.method_3("License_Max_Number_Of_Processes_Enable"));
				}
				else
				{
					this.bool_53 = false;
				}
			}
			catch
			{
				this.bool_53 = false;
			}
			if (@class.method_3("Lock_Evaluation_Type") == "Trial_Days")
			{
				this.enum11_0 = (Enum11)0;
			}
			else
			{
				this.enum11_0 = (Enum11)1;
			}
			this.int_3 = Convert.ToInt32(@class.method_3("Lock_Evaluation_Time"));
			try
			{
				if (@class.method_3("License_Evaluation_Time") != null)
				{
					this.int_7 = Convert.ToInt32(@class.method_3("License_Evaluation_Time"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("Lock_Number_Of_Uses") != null)
				{
					this.int_4 = Convert.ToInt32(@class.method_3("Lock_Number_Of_Uses"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("Lock_Number_Of_Processes") != null)
				{
					this.int_1 = Convert.ToInt32(@class.method_3("Lock_Number_Of_Processes"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("Lock_Nag_XDays_Before_Expiration") != null)
				{
					this.int_2 = Convert.ToInt32(@class.method_3("Lock_Nag_XDays_Before_Expiration"));
				}
				else
				{
					this.int_2 = -1;
				}
			}
			catch
			{
				this.int_2 = -1;
			}
			try
			{
				if (@class.method_3("License_Number_Of_Uses") != null)
				{
					this.int_5 = Convert.ToInt32(@class.method_3("License_Number_Of_Uses"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("License_Number_Of_Processes") != null)
				{
					this.int_6 = Convert.ToInt32(@class.method_3("License_Number_Of_Processes"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("Lock_Expiration_Date") != null)
				{
					string value = @class.method_3("Lock_Expiration_Date").Substring(0, 4);
					string value2 = @class.method_3("Lock_Expiration_Date").Substring(4, 2);
					string value3 = @class.method_3("Lock_Expiration_Date").Substring(6, 2);
					this.dateTime_0 = new DateTime(Convert.ToInt32(value), Convert.ToInt32(value2), Convert.ToInt32(value3));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_3("License_Expiration_Date") != null)
				{
					string value4 = @class.method_3("License_Expiration_Date").Substring(0, 4);
					string value5 = @class.method_3("License_Expiration_Date").Substring(4, 2);
					string value6 = @class.method_3("License_Expiration_Date").Substring(6, 2);
					this.dateTime_1 = new DateTime(Convert.ToInt32(value4), Convert.ToInt32(value5), Convert.ToInt32(value6));
				}
			}
			catch
			{
			}
			@class = class37_1.method_0().method_1("Dialogs");
			this.string_16 = @class.method_3("Dialogs_Caption");
			try
			{
				this.string_24 = @class.method_3("License_HardwareID_2");
				if (this.string_24 == null)
				{
					this.string_24 = "####-####-####-####-####";
				}
			}
			catch
			{
				this.string_24 = "####-####-####-####-####";
			}
			try
			{
				this.string_17 = @class.method_3("CustomizeMessageBox");
				if (this.string_17 == null)
				{
					this.string_17 = "";
				}
			}
			catch
			{
				this.string_17 = "";
			}
			this.string_18 = @class.method_3("Dialogs_License_Expired");
			this.string_19 = @class.method_3("Dialogs_SnagScreen");
			try
			{
				if (@class.method_3("Dialogs_Invalid_License").ToString().Length > 0)
				{
					this.string_20 = @class.method_3("Dialogs_Invalid_License");
				}
			}
			catch
			{
			}
			this.string_21 = @class.method_3("Dialogs_Trial_Period_End");
			try
			{
				if (@class.method_3("Dialogs_Number_Of_Uses").ToString().Length > 0)
				{
					this.string_22 = @class.method_3("Dialogs_Number_Of_Uses");
				}
			}
			catch
			{
				this.string_22 = this.string_21;
			}
			try
			{
				if (@class.method_3("Dialogs_Max_Processes_Exceeded").ToString().Length > 0)
				{
					this.string_23 = @class.method_3("Dialogs_Max_Processes_Exceeded");
				}
			}
			catch
			{
			}
			this.color_0 = Class26.Class27.smethod_9(@class.method_3("Dialogs_Gradient_Color_Begin"));
			this.color_1 = Class26.Class27.smethod_9(@class.method_3("Dialogs_Gradient_Color_End"));
		}

		public void method_16(Class26.Class37 class37_1)
		{
			Class26.Class40 @class = class37_1.method_0().method_1("License_Settings");
			try
			{
				if (@class.method_3("Lock_License_Enable") != null && @class.method_3("Lock_License_Enable").Length > 0)
				{
					this.bool_55 = bool.Parse(@class.method_3("Lock_License_Enable"));
				}
			}
			catch
			{
				this.bool_55 = false;
			}
			try
			{
				if (@class.method_3("Lock_License_Expiration_Date") != null)
				{
					string value = @class.method_3("Lock_License_Expiration_Date").Substring(0, 4);
					string value2 = @class.method_3("Lock_License_Expiration_Date").Substring(4, 2);
					string value3 = @class.method_3("Lock_License_Expiration_Date").Substring(6, 2);
					this.dateTime_1 = new DateTime(Convert.ToInt32(value), Convert.ToInt32(value2), Convert.ToInt32(value3));
				}
			}
			catch
			{
			}
			this.class34_0.method_1(@class.method_3("MasterKey"));
			try
			{
				if (@class.method_3("License_Hardware_Enable") != null)
				{
					this.bool_54 = bool.Parse(@class.method_3("License_Hardware_Enable"));
				}
				else
				{
					this.bool_54 = false;
				}
			}
			catch
			{
				this.bool_54 = false;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_HDD") != null)
				{
					this.bool_40 = bool.Parse(@class.method_3("Lock_Hardware_HDD"));
				}
				else
				{
					this.bool_40 = false;
				}
			}
			catch
			{
				this.bool_40 = false;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_MAC") != null)
				{
					this.bool_41 = bool.Parse(@class.method_3("Lock_Hardware_MAC"));
				}
				else
				{
					this.bool_41 = true;
				}
			}
			catch
			{
				this.bool_41 = true;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_BOARD") != null)
				{
					this.bool_42 = bool.Parse(@class.method_3("Lock_Hardware_BOARD"));
				}
				else
				{
					this.bool_42 = true;
				}
			}
			catch
			{
				this.bool_42 = true;
			}
			try
			{
				if (@class.method_3("Lock_Hardware_CPU") != null)
				{
					this.bool_43 = bool.Parse(@class.method_3("Lock_Hardware_CPU"));
				}
				else
				{
					this.bool_43 = true;
				}
			}
			catch
			{
				this.bool_43 = true;
			}
			try
			{
				if (@class.method_3("License_Evaluation_Enable") != null)
				{
					this.bool_56 = bool.Parse(@class.method_3("License_Evaluation_Enable"));
				}
				else
				{
					this.bool_56 = false;
				}
			}
			catch
			{
				this.bool_56 = false;
			}
			try
			{
				if (@class.method_3("License_Evaluation_Type") != null)
				{
					this.enum11_1 = (Enum11)Enum.Parse(typeof(Enum11), @class.method_3("License_Evaluation_Type"));
				}
				else
				{
					this.enum11_1 = (Enum11)0;
				}
			}
			catch
			{
				this.enum11_1 = (Enum11)0;
			}
			try
			{
				if (@class.method_3("License_Evaluation_Time") != null)
				{
					this.int_7 = Convert.ToInt32(@class.method_3("License_Evaluation_Time"));
				}
				else
				{
					this.int_7 = 1;
				}
			}
			catch
			{
				this.int_7 = 1;
			}
			try
			{
				if (@class.method_3("License_Number_Of_Uses_Enable") != null)
				{
					this.bool_51 = bool.Parse(@class.method_3("License_Number_Of_Uses_Enable"));
				}
				else
				{
					this.bool_51 = false;
				}
			}
			catch
			{
				this.bool_51 = false;
			}
			try
			{
				if (@class.method_3("License_Global_Licensing_Behaviour") != null)
				{
					this.bool_52 = bool.Parse(@class.method_3("License_Global_Licensing_Behaviour"));
				}
				else
				{
					this.bool_52 = true;
				}
			}
			catch
			{
				this.bool_52 = true;
			}
			if (!this.bool_52)
			{
				this.byte_0 = Convert.FromBase64String(@class.method_3("License_Individual_Key"));
			}
			else
			{
				this.byte_0 = new Class26.Class34().method_4();
			}
			try
			{
				if (@class.method_3("License_Max_Number_Of_Processes_Enable") != null)
				{
					this.bool_53 = bool.Parse(@class.method_3("License_Max_Number_Of_Processes_Enable"));
				}
				else
				{
					this.bool_53 = false;
				}
			}
			catch
			{
				this.bool_53 = false;
			}
			try
			{
				if (@class.method_3("License_Number_Of_Uses") != null)
				{
					this.int_5 = Convert.ToInt32(@class.method_3("License_Number_Of_Uses"));
				}
				else
				{
					this.int_5 = 1;
				}
			}
			catch
			{
				this.int_5 = 1;
			}
			try
			{
				if (@class.method_3("License_Number_Of_Processes") != null)
				{
					this.int_6 = Convert.ToInt32(@class.method_3("License_Number_Of_Processes"));
				}
				else
				{
					this.int_6 = 5;
				}
			}
			catch
			{
				this.int_6 = 5;
			}
			try
			{
				this.string_24 = @class.method_3("License_HardwareID_2");
			}
			catch
			{
				this.string_24 = "";
			}
			try
			{
				this.class37_0 = null;
				if (@class.method_3("License_HardwareID") != null)
				{
					string text = @class.method_3("License_HardwareID");
					byte[] array = new byte[text.Length / 3];
					for (int i = 0; i < array.Length; i++)
					{
						string value4 = text.Substring(i * 3, 3);
						array[i] = Convert.ToByte(value4);
					}
					MemoryStream memoryStream = new MemoryStream();
					memoryStream.Write(array, 0, array.Length);
					memoryStream.Position = 0L;
					this.class37_0 = new Class26.Class37(memoryStream);
				}
			}
			catch
			{
			}
			try
			{
				this.hashtable_0.Clear();
				string text2 = @class.method_3("AdditonalLicenseInformation");
				string[] array2 = text2.Split(new char[]
				{
					'|'
				});
				for (int j = 0; j < array2.Length / 2; j++)
				{
					this.hashtable_0.Add(array2[j * 2], array2[j * 2 + 1]);
				}
			}
			catch
			{
			}
		}

		public void method_17(byte[] byte_2)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_2, 0, byte_2.Length);
			Class26 @class = new Class26();
			byte[] array = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array, 0, array.Length);
			memoryStream2.Position = 0L;
			Class26.Class37 class37_ = new Class26.Class37(memoryStream2);
			memoryStream2.Close();
			this.method_15(class37_);
		}

		public void method_18(string string_25)
		{
			FileStream fileStream = new FileStream(string_25, FileMode.Open, FileAccess.Read);
			fileStream.Position = 0L;
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			byte[] array2 = array;
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array2, 0, array2.Length);
			Class26 @class = new Class26();
			byte[] array3 = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array3.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array3, 0, array3.Length);
			memoryStream2.Position = 0L;
			Class26.Class37 class37_ = new Class26.Class37(memoryStream2);
			memoryStream2.Close();
			this.method_15(class37_);
			if (this.string_12.Length > 0)
			{
				this.string_12 = this.method_13(string_25, this.string_12);
			}
			if (this.string_0.Length > 0)
			{
				this.string_0 = this.method_13(string_25, this.string_0);
			}
			if (this.string_1.Length > 0)
			{
				this.string_1 = this.method_13(string_25, this.string_1);
			}
			if (this.string_2.Length > 0)
			{
				this.string_2 = this.method_13(string_25, this.string_2);
			}
			if (this.string_7.Length > 0)
			{
				this.string_7 = this.method_13(string_25, this.string_7);
			}
			if (this.string_8.Length > 0)
			{
				this.string_8 = this.method_13(string_25, this.string_8);
			}
			if (this.string_4.Length > 0)
			{
				string str = "";
				string[] array4 = this.string_4.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array4.Length; i++)
				{
					str += this.method_13(string_25, array4[i]);
					if (i < array4.Length - 1)
					{
						str += "|";
					}
				}
				this.string_4 = str;
			}
		}

		public void method_19(byte[] byte_2)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_2, 0, byte_2.Length);
			Class26 @class = new Class26();
			byte[] array = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array, 0, array.Length);
			memoryStream2.Position = 0L;
			Class26.Class37 class37_ = new Class26.Class37(memoryStream2);
			memoryStream2.Close();
			this.method_15(class37_);
		}

		public Class26.Class37 method_2()
		{
			Class26.Class37 @class = new Class26.Class37();
			Class26.Class40 class2 = new Class26.Class40("License_Settings");
			string str = "";
			for (int i = 0; i < this.class34_0.method_4().Length; i++)
			{
				str += this.class34_0.method_4()[i].ToString("D3");
			}
			class2.method_7("MasterKey", str, "");
			class2.method_7("Lock_License_Enable", this.bool_55.ToString(), "");
			class2.method_7("Lock_License_Expiration_Date", this.dateTime_1.Year.ToString("D4") + this.dateTime_1.Month.ToString("D2") + this.dateTime_1.Day.ToString("D2"), "");
			class2.method_7("License_Hardware_Enable", this.bool_54.ToString(), "");
			class2.method_7("Lock_Hardware_HDD", this.bool_40.ToString(), "");
			class2.method_7("Lock_Hardware_MAC", this.bool_41.ToString(), "");
			class2.method_7("Lock_Hardware_BOARD", this.bool_42.ToString(), "");
			class2.method_7("Lock_Hardware_CPU", this.bool_43.ToString(), "");
			class2.method_7("License_Evaluation_Enable", this.bool_56.ToString(), "");
			class2.method_7("License_Evaluation_Type", this.enum11_1.ToString(), "");
			class2.method_7("License_Evaluation_Time", this.int_7.ToString(), "");
			class2.method_7("License_Number_Of_Uses_Enable", this.bool_51.ToString(), "");
			this.byte_0 = new Class26.Class34().method_4();
			class2.method_7("License_Individual_Key", Convert.ToBase64String(this.byte_0), "");
			class2.method_7("License_Global_Licensing_Behaviour", this.bool_52.ToString(), "");
			class2.method_7("License_Max_Number_Of_Processes_Enable", this.bool_53.ToString(), "");
			class2.method_7("License_Number_Of_Uses", this.int_5.ToString(), "");
			class2.method_7("License_Number_Of_Processes", this.int_6.ToString(), "");
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			this.class37_0.method_1(streamWriter);
			byte[] array = memoryStream.ToArray();
			string str2 = "";
			for (int j = 0; j < array.Length; j++)
			{
				str2 += array[j].ToString("D3");
			}
			streamWriter.Close();
			memoryStream.Close();
			class2.method_7("License_HardwareID", str2, "");
			class2.method_7("License_HardwareID_2", this.string_24, "");
			string text = "";
			IDictionaryEnumerator enumerator = this.hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				text = string.Concat(new object[]
				{
					text,
					enumerator.Key,
					"|",
					enumerator.Value,
					"|"
				});
			}
			text = text.Replace("\"", "'");
			class2.method_7("AdditonalLicenseInformation", text, "");
			@class.method_0().method_2(class2);
			return @class;
		}

		public void method_20(byte[] byte_2, bool bool_57, Class26.Class45 class45_0)
		{
			if (bool_57)
			{
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(byte_2, 0, byte_2.Length);
				Class26 @class = new Class26();
				byte[] array = @class.method_10(memoryStream, true);
				MemoryStream memoryStream2 = new MemoryStream(array.Length);
				memoryStream2.Position = 0L;
				memoryStream2.Write(array, 0, array.Length);
				memoryStream2.Position = 0L;
				Class26.Class37 class2 = new Class26.Class37(memoryStream2);
				memoryStream2.Close();
				Class26.Class40 class3 = class2.method_0().method_1("sdtwe4dbutueteretdg4er");
				byte[] byte_3 = Convert.FromBase64String(class3.method_3("ujh45mngsdrt3"));
				byte[] byte_4 = Convert.FromBase64String(class3.method_3("kjrwejhjsnbbhherw"));
				if (Class26.Class34.smethod_2(class45_0.class34_0.method_7(), byte_3, byte_4))
				{
					this.method_20(byte_3, false, class45_0);
				}
				else
				{
					if (this.class34_0 != null && this.class34_0.method_7() != null)
					{
						this.class34_0.method_7().Clear();
					}
					this.class34_0 = new Class26.Class34();
				}
				this.bool_2 = bool_57;
				return;
			}
			MemoryStream memoryStream3 = new MemoryStream();
			memoryStream3.Write(byte_2, 0, byte_2.Length);
			Class26 class4 = new Class26();
			byte[] array2 = class4.method_10(memoryStream3, true);
			MemoryStream memoryStream4 = new MemoryStream(array2.Length);
			memoryStream4.Position = 0L;
			memoryStream4.Write(array2, 0, array2.Length);
			memoryStream4.Position = 0L;
			Class26.Class37 class37_ = new Class26.Class37(memoryStream4);
			memoryStream4.Close();
			this.method_16(class37_);
			this.bool_2 = bool_57;
		}

		public Class26.Class37 method_21(byte[] byte_2)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_2, 0, byte_2.Length);
			Class26 @class = new Class26();
			byte[] array = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array, 0, array.Length);
			memoryStream2.Position = 0L;
			return new Class26.Class37(memoryStream2);
		}

		public void method_22(string string_25, bool bool_57, Class26.Class45 class45_0)
		{
			try
			{
				FileStream fileStream = new FileStream(string_25, FileMode.Open, FileAccess.Read);
				fileStream.Position = 0L;
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.method_20(array, bool_57, class45_0);
			}
			catch
			{
				if (this.class34_0 != null && this.class34_0.method_7() != null)
				{
					this.class34_0.method_7().Clear();
				}
				this.class34_0 = new Class26.Class34();
			}
		}

		public void method_23(byte[] byte_2, bool bool_57, Class26.Class45 class45_0)
		{
			try
			{
				this.method_20(byte_2, bool_57, class45_0);
			}
			catch
			{
				if (this.class34_0 != null && this.class34_0.method_7() != null)
				{
					this.class34_0.method_7().Clear();
				}
				this.class34_0 = new Class26.Class34();
			}
		}

		public Class26.Class37 method_24(string string_25)
		{
			FileStream fileStream = new FileStream(string_25, FileMode.Open, FileAccess.Read);
			fileStream.Position = 0L;
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return this.method_21(array);
		}

		public void method_25(string string_25)
		{
			this.method_15(new Class26.Class37(string_25));
			if (this.string_12.Length > 0)
			{
				this.string_12 = this.method_13(string_25, this.string_12);
			}
			if (this.string_0.Length > 0)
			{
				this.string_0 = this.method_13(string_25, this.string_0);
			}
			if (this.string_1.Length > 0)
			{
				this.string_1 = this.method_13(string_25, this.string_1);
			}
			if (this.string_2.Length > 0)
			{
				this.string_2 = this.method_13(string_25, this.string_2);
			}
			if (this.string_7.Length > 0)
			{
				this.string_7 = this.method_13(string_25, this.string_7);
			}
			if (this.string_8.Length > 0)
			{
				this.string_8 = this.method_13(string_25, this.string_8);
			}
			if (this.string_4.Length > 0)
			{
				string str = "";
				string[] array = this.string_4.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					str += this.method_13(string_25, array[i]);
					if (i < array.Length - 1)
					{
						str += "|";
					}
				}
				this.string_4 = str;
			}
		}

		public byte[] method_3()
		{
			Class26.Class37 @class = this.method_1(false, false);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class26 class2 = new Class26();
			return class2.method_5(memoryStream, true);
		}

		public byte[] method_4()
		{
			Class26.Class37 @class = this.method_1(true, false);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class26 class2 = new Class26();
			return class2.method_5(memoryStream, true);
		}

		public byte[] method_5()
		{
			Class26.Class37 @class = this.method_1(false, true);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class26 class2 = new Class26();
			return class2.method_5(memoryStream, true);
		}

		public byte[] method_6()
		{
			Class26.Class37 @class = this.method_2();
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class26 class2 = new Class26();
			return class2.method_5(memoryStream, true);
		}

		public byte[] method_7()
		{
			if (this.bool_2)
			{
				byte[] inArray = this.method_6();
				byte[] inArray2 = Class26.Class34.smethod_1(this.class34_0.method_7(), inArray);
				Class26.Class37 @class = new Class26.Class37();
				Class26.Class40 class2 = new Class26.Class40("sdtwe4dbutueteretdg4er");
				class2.method_7("ujh45mngsdrt3", Convert.ToBase64String(inArray), "");
				class2.method_7("kjrwejhjsnbbhherw", Convert.ToBase64String(inArray2), "");
				@class.method_0().method_2(class2);
				MemoryStream memoryStream = new MemoryStream();
				StreamWriter streamWriter = new StreamWriter(memoryStream);
				@class.method_1(streamWriter);
				Class26 class3 = new Class26();
				byte[] result = class3.method_5(memoryStream, true);
				streamWriter.Close();
				return result;
			}
			return this.method_6();
		}

		public void method_8(string string_25)
		{
			byte[] array = this.method_6();
			array = this.method_9(array);
			FileStream fileStream = new FileStream(string_25, FileMode.Create, FileAccess.ReadWrite);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
		}

		public byte[] method_9(byte[] byte_2)
		{
			Class26.Class37 @class = new Class26.Class37();
			Class26.Class40 class2 = new Class26.Class40("sdtwe4dbutueteretdg4er");
			class2.method_7("ujh45mngsdrt3", Convert.ToBase64String(byte_2), "");
			class2.method_7("kjrwejhjsnbbhherw", Convert.ToBase64String(this.byte_1), "");
			@class.method_0().method_2(class2);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class26 class3 = new Class26();
			return class3.method_5(memoryStream, false);
		}

		public static byte[] smethod_0(Class26.Class37 class37_1)
		{
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			class37_1.method_1(textWriter_);
			Class26 @class = new Class26();
			return @class.method_5(memoryStream, true);
		}

		public bool bool_0;

		public bool bool_1 = true;

		public bool bool_10;

		public bool bool_11 = true;

		public bool bool_12;

		public bool bool_13;

		public bool bool_14;

		public bool bool_15;

		public bool bool_16;

		public bool bool_17;

		public bool bool_18 = true;

		public bool bool_19 = true;

		public bool bool_2 = true;

		public bool bool_20;

		public bool bool_21;

		public bool bool_22;

		public bool bool_23;

		public bool bool_24 = true;

		public bool bool_25;

		public bool bool_26;

		public bool bool_27;

		public bool bool_28;

		public bool bool_29 = true;

		public bool bool_3;

		public bool bool_30 = true;

		public bool bool_31 = true;

		public bool bool_32 = true;

		public bool bool_33 = true;

		public bool bool_34;

		public bool bool_35 = true;

		public bool bool_36 = true;

		public bool bool_37 = true;

		public bool bool_38;

		public bool bool_39;

		public bool bool_4 = true;

		public bool bool_40;

		public bool bool_41 = true;

		public bool bool_42 = true;

		public bool bool_43 = true;

		public bool bool_44;

		public bool bool_45;

		public bool bool_46;

		public bool bool_47 = true;

		public bool bool_48 = true;

		public bool bool_49 = true;

		public bool bool_5;

		public bool bool_50 = true;

		public bool bool_51;

		public bool bool_52 = true;

		public bool bool_53;

		public bool bool_54;

		public bool bool_55;

		public bool bool_56;

		public bool bool_6;

		public bool bool_7;

		public bool bool_8 = true;

		public bool bool_9;

		public byte[] byte_0 = new byte[0];

		internal byte[] byte_1 = new byte[0];

		internal Class26.Class34 class34_0 = new Class26.Class34();

		public Class26.Class37 class37_0 = new Class26.Class37();

		public Color color_0 = Color.White;

		public Color color_1 = Color.FromArgb(157, 211, 252);

		public DateTime dateTime_0 = DateTime.Now;

		public DateTime dateTime_1 = DateTime.Now;

		public Enum11 enum11_0;

		public Enum11 enum11_1;

		public Hashtable hashtable_0 = new Hashtable();

		public int int_0 = 9;

		public int int_1 = 5;

		public int int_2 = -1;

		public int int_3 = 14;

		public int int_4 = 10;

		public int int_5 = 10;

		public int int_6 = 5;

		public int int_7 = 1;

		public bool jnZrMnduej;

		public string string_0 = "";

		public string string_1 = "";

		public string string_10 = "";

		public string string_11 = "";

		public string string_12 = "";

		public string string_13 = "";

		public string string_14 = "";

		public string string_15 = "";

		public string string_16 = "Lock System";

		public string string_17 = "";

		public string string_18 = "Your expiration date is reached! You need to purchase a license file to run this software.";

		public string string_19 = "Nag Screen! This message will disappear when a valid license file is installed. You are on day [current_minutes_days] of your [max_minutes_days] day evaluation period. You have [minutes_days_left] days left. You have used this software [current_uses] times out of a maximum of [max_uses]. You have [uses_left] uses left.";

		public string string_2 = "";

		public string string_20 = "This software won't run without a valid license file. Either a valid license file could not be found or your license file is expired.";

		public string string_21 = "You are on day [current_minutes_days] of your [max_minutes_days] day evaluation period. Your trial period is expired! You need to purchase a license to run this software.";

		public string string_22 = "You have used this software [current_uses] times out of a maximum of [max_uses]. You have [uses_left] uses left. Your trial period is expired! You need to purchase a license to run this software.";

		public string string_23 = "You can only run maximal [max_processes] instances of this software at the same time.";

		public string string_24 = "####-####-####-####-####";

		public string string_3 = "";

		public string string_4 = "";

		public string string_5 = "";

		public string string_6 = "";

		public string string_7 = "";

		public string string_8 = "<AssemblyLocation>\\<AssemblyName>_Secure\\<AssemblyFileName>";

		public string string_9 = "";
	}

	internal enum Enum10
	{

	}

	internal enum Enum2
	{

	}

	internal enum Enum3
	{

	}

	private enum Enum4
	{

	}

	private enum Enum5
	{

	}

	private enum Enum6
	{

	}

	internal enum Enum7
	{

	}

	internal enum Enum8
	{

	}

	internal enum Enum9
	{

	}

	[Serializable]
	internal sealed class Exception0 : SystemException
	{
		public Exception0()
		{
			this.string_0 = "An error has occurred";
		}

		public Exception0(string string_1) : base(string_1)
		{
			this.string_0 = string_1;
		}

        public Exception0(string string_1, System.Exception exception_0)
            : base(string_1, exception_0)
		{
		}

		internal Exception0(Class26.Class39 class39_1, string string_1) : this(string_1)
		{
			this.class39_0 = class39_1;
			this.string_0 = string_1;
		}

		protected Exception0(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0) : base(serializationInfo_0, streamingContext_0)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			if (this.class39_0 != null)
			{
				info.AddValue("lineNumber", this.class39_0.method_4());
				info.AddValue("linePosition", this.class39_0.method_5());
			}
		}

		public int method_0()
		{
			if (this.class39_0 != null)
			{
				return this.class39_0.method_5();
			}
			return 0;
		}

		public int method_1()
		{
			if (this.class39_0 != null)
			{
				return this.class39_0.method_4();
			}
			return 0;
		}

		public override string Message
		{
			get
			{
				if (this.class39_0 == null)
				{
					return base.Message;
				}
				return string.Format(CultureInfo.InvariantCulture, "{0} - Line: {1}, Position: {2}.", new object[]
				{
					base.Message,
					this.method_1(),
					this.method_0()
				});
			}
		}

		private Class26.Class39 class39_0;

		private string string_0 = "";
	}

	internal struct Struct1
	{
		public IntPtr intptr_0;

		public int int_0;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string string_0;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
		public string string_1;

		public uint uint_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] byte_0;

		public int int_1;

		public uint wfQvayhew;

		public uint uint_1;

		public IntPtr intptr_1;

		public Class26.Struct2 struct2_0;

		public Class26.Struct2 struct2_1;

		public Class26.Struct2 struct2_2;

		public bool bool_0;

		public Class26.Struct2 struct2_3;

		public Class26.Struct2 struct2_4;

		public int int_2;

		public int int_3;
	}

	internal struct Struct2
	{
		public IntPtr intptr_0;

		public Class26.Struct3 struct3_0;

		public Class26.Struct3 struct3_1;

		public int int_0;
	}

	internal struct Struct3
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string string_0;
	}

	private struct Struct4
	{
		public uint uint_0;

		public uint uint_1;

		public char char_0;

		public char char_1;

		public byte byte_0;

		public byte byte_1;

		public uint uint_2;

		public uint wfQvayhew;

		public uint uint_3;

		public uint uint_4;

		public Class26.Enum6 enum6_0;

		public uint uint_5;

		public IntPtr intptr_0;
	}

	private struct Struct5
	{
		public Class26.Enum4 enum4_0;

		public Class26.Enum5 enum5_0;

		public IntPtr intptr_0;
	}
}
