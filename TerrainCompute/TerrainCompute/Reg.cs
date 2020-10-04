using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace TerrainComputeC
{
	
	public class Reg
	{
		static Reg()
		{
			Reg.string_0 = new string[]
			{
				"ACAD-A000:",
				"ACAD-A001:",
				"ACAD-A002:",
				"ACAD-A005:",
				"ACAD-9000:",
				"ACAD-9001:",
				"ACAD-9002:",
				"ACAD-9005:",
				"ACAD-8000:",
				"ACAD-8001:",
				"ACAD-8002:",
				"ACAD-8005:",
				"ACAD-7000:",
				"ACAD-7001:",
				"ACAD-7002:",
				"ACAD-7005:",
				"ACAD-6000:",
				"ACAD-6001:",
				"ACAD-6002:",
				"ACAD-6005:",
				"ACAD-5000:",
				"ACAD-5001:",
				"ACAD-5002:",
				"ACAD-5005:"
			};
		}

		public Reg()
		{
            
		}

		public static RegistryKey ComputationalCADRegistryKey()
		{
			string str = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			string subkey = "Software\\ngeometric\\TCPlugin\\" + str;
			return Registry.CurrentUser.CreateSubKey(subkey);
		}

		public static string GetComputationalCADRegistryValue(string name)
		{
			string result;
			try
			{
				RegistryKey registryKey = Reg.ComputationalCADRegistryKey();
				result = (string)registryKey.GetValue(name);
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Can not read setting " + name + ": " + ex.Message);
			}
			return result;
		}

		public static RegistryKey GetCurrentProductKey(bool writable)
		{
			RegistryKey result;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Autodesk\\AutoCAD", writable);
				string name = registryKey.GetValue("CurVer").ToString();
				registryKey = registryKey.OpenSubKey(name, writable);
				name = registryKey.GetValue("CurVer").ToString();
				registryKey = registryKey.OpenSubKey(name, writable);
				result = registryKey;
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Current AutoCAD version could not be determined:" + Environment.NewLine + ex.Message);
			}
			return result;
		}

		public static string GetInstallationFolder()
		{
			string directoryName;
			try
			{
				RegistryKey registryKey = Reg.GetCurrentProductKey(false);
				registryKey = registryKey.OpenSubKey("Applications\\TCPlugin");
				directoryName = Path.GetDirectoryName(registryKey.GetValue("LOADER").ToString());
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Can not determine TCPlugin installation path:" + Environment.NewLine + ex.Message);
			}
			return directoryName;
		}

		public static string GetLastUsedComputationalCADVersion()
		{
			string result;
			try
			{
				RegistryKey registryKey = Reg.GetCurrentProductKey(false);
				registryKey = registryKey.OpenSubKey("Applications\\TCPlugin");
				try
				{
					result = registryKey.GetValue("LastUsedVersion").ToString();
				}
				catch
				{
					result = "";
				}
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Can not determine last used TCPlugin version:" + Environment.NewLine + ex.Message);
			}
			return result;
		}

		public static bool GetMenuLoaderState()
		{
			bool result;
			try
			{
				RegistryKey currentProductKey = Reg.GetCurrentProductKey(true);
				RegistryKey registryKey = currentProductKey.OpenSubKey("Applications", true);
				registryKey = registryKey.OpenSubKey("TCPlugin", true);
				string a = (string)registryKey.GetValue("EXECUTEMENULOADER", "TRUE");
				if (a == "FALSE")
				{
					result = false;
				}
				else
				{
					registryKey.SetValue("EXECUTEMENULOADER", "FALSE", RegistryValueKind.String);
					result = true;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public static bool Is2010OrHigher()
		{
			bool result;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Autodesk\\AutoCAD", false);
				string text = registryKey.GetValue("CurVer").ToString();
				if (Convert.ToDouble(text.ToUpper().Replace("R", "")) >= 18.0)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Current AutoCAD version could not be determined:" + Environment.NewLine + ex.Message);
			}
			return result;
		}

		public static void RegisterComputationalCADVersion(string currentVersion)
		{
			try
			{
				RegistryKey registryKey = Reg.GetCurrentProductKey(true);
				registryKey = registryKey.CreateSubKey("Applications\\TCPlugin", RegistryKeyPermissionCheck.ReadWriteSubTree);
				registryKey.SetValue("LastUsedVersion", currentVersion, RegistryValueKind.String);
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("TCPlugin could not register current version." + Environment.NewLine + ex.Message);
			}
		}

		public static void SetComputationalCADRegistryValue(string name, string value)
		{
			try
			{
				RegistryKey registryKey = Reg.ComputationalCADRegistryKey();
				registryKey.SetValue(name, value, RegistryValueKind.String);
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Can not write setting " + name + ": " + ex.Message);
			}
		}

		private static List<RegistryKey> smethod_0(bool bool_0)
		{
			List<RegistryKey> result;
			try
			{
				List<RegistryKey> list = new List<RegistryKey>();
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Autodesk\\AutoCAD", bool_0);
				string[] subKeyNames = registryKey.GetSubKeyNames();
				for (int i = 0; i < subKeyNames.Length; i++)
				{
					RegistryKey registryKey2 = registryKey.OpenSubKey(subKeyNames[i], bool_0);
					string[] subKeyNames2 = registryKey2.GetSubKeyNames();
					for (int j = 0; j < subKeyNames2.Length; j++)
					{
						if (Reg.smethod_1(subKeyNames2[j]))
						{
							list.Add(registryKey2.OpenSubKey(subKeyNames2[j], bool_0));
						}
					}
				}
				result = list;
			}
            catch (System.Exception ex)
			{
                throw new System.Exception("Can not retrieve supported AutoCAD product keys:" + Environment.NewLine + ex.Message);
			}
			return result;
		}

		private static bool smethod_1(string string_1)
		{
			for (int i = 0; i < Reg.string_0.Length; i++)
			{
				if (string_1.Contains(Reg.string_0[i]))
				{
					return true;
				}
			}
			return false;
		}

		private static string[] string_0;
	}
}
