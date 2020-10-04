using System;
using System.Reflection;
using Autodesk.AutoCAD.DatabaseServices;
using Microsoft.Win32;

namespace CAD屏幕菜单
{
	public class RegeditHelper
	{
		public static void RegisterScreenMenu()
		{
			string machineRegistryProductRootKey = HostApplicationServices.Current.MachineRegistryProductRootKey;
			string text = "ScreenMenu";
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(machineRegistryProductRootKey).OpenSubKey("Applications", true);
			string[] subKeyNames = registryKey.GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				if (subKeyNames[i].Equals(text))
				{
					registryKey.Close();
					return;
				}
			}
			string location = Assembly.GetExecutingAssembly().Location;
			RegistryKey registryKey2 = registryKey.CreateSubKey(text);
			registryKey2.SetValue("DESCRIPTION", text, RegistryValueKind.String);
			registryKey2.SetValue("LOADCTRLS", 2, RegistryValueKind.DWord);
			registryKey2.SetValue("LOADER", location, RegistryValueKind.String);
			registryKey2.SetValue("MANAGED", 1, RegistryValueKind.DWord);
			registryKey.Close();
		}

		public static void UnregisterScreenMenu()
		{
			string machineRegistryProductRootKey = HostApplicationServices.Current.MachineRegistryProductRootKey;
			string text = "ScreenMenu";
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(machineRegistryProductRootKey).OpenSubKey("Applications", true);
			string[] subKeyNames = registryKey.GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				if (subKeyNames[i].Equals(text))
				{
					registryKey.DeleteSubKeyTree(text);
					registryKey.Close();
				}
			}
		}

		public RegeditHelper()
		{
		}
	}
}
