using System;
using System.ComponentModel;
using System.Management;
using System.Reflection;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;

namespace MyCompute
{
	//[LicenseProvider(typeof(Class46))]
	public class AboutObject
	{
		public AboutObject()
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(AboutObject));
			this.string_0 = " - service not available - ";
			this.string_1 = " - service not available - ";
			this.string_2 = " - service not available - ";
			this.string_3 = " - service not available - ";
			this.string_4 = " - service not available - ";
			this.string_5 = " - service not available - ";
			this.string_6 = " - service not available - ";
			this.string_7 = " - service not available - ";
			this.string_8 = " - service not available - ";
			this.string_9 = " - service not available - ";
			this.string_10 = " - service not available - ";
			this.string_11 = " - service not available - ";
			this.string_12 = " - service not available - ";
			this.string_13 = " - service not available - ";
			this.string_14 = " - service not available - ";
			this.string_15 = " - service not available - ";
			this.string_16 = "";
			this.string_17 = "";
			//base..ctor();
			this.string_0 = Assembly.GetExecutingAssembly().GetName().Name.ToString().Trim();
			this.string_1 = ((AssemblyCopyrightAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0]).Copyright.Trim();
			this.string_2 = Assembly.GetExecutingAssembly().GetName().Version.ToString().Trim();
			this.string_14 = "www.computational-cad.com";
			this.string_15 = "support@computational-cad.com";
			this.string_3 = Environment.Version.ToString().Trim();
			this.string_4 = Environment.OSVersion.ToString().Trim();
			this.string_5 = Assembly.GetCallingAssembly().GetName().Name.ToString().Trim() + " V" + Assembly.GetCallingAssembly().GetName().Version.ToString().Trim();
            this.string_6 = Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("ACADVER").ToString().Trim();
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						this.string_7 = managementObject["Name"].ToString().Trim();
						this.string_8 = managementObject["Description"].ToString().Trim();
						this.string_9 = managementObject["Manufacturer"].ToString().Trim();
						this.string_10 = managementObject["NumberOfCores"].ToString().Trim();
						this.string_11 = managementObject["NumberOfLogicalProcessors"].ToString().Trim();
						if (managementObject["Architecture"].ToString().Trim() == "0")
						{
							this.string_12 = "x86";
						}
						if (managementObject["Architecture"].ToString().Trim() == "1")
						{
							this.string_12 = "MIPS";
						}
						if (managementObject["Architecture"].ToString().Trim() == "2")
						{
							this.string_12 = "Alpha";
						}
						if (managementObject["Architecture"].ToString().Trim() == "3")
						{
							this.string_12 = "PowerPC";
						}
						if (managementObject["Architecture"].ToString().Trim() == "6")
						{
							this.string_12 = "Intel Itanium Processor Family (IPF)";
						}
						if (managementObject["Architecture"].ToString().Trim() == "9")
						{
							this.string_12 = "x64";
						}
					}
				}
			}
			catch
			{
			}
			string str = "\nMemory data\n";
			str += "-----------\n";
			try
			{
				ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator2 = managementObjectSearcher2.Get().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						ManagementObject managementObject2 = (ManagementObject)enumerator2.Current;
						this.string_13 = (Convert.ToDouble(managementObject2["TotalPhysicalMemory"].ToString()) / 1024.0 / 1024.0).ToString("0.00") + "MB";
					}
				}
			}
			catch
			{
			}
			if (!LicenseManager.IsInitialized)
			{
				LicenseManager.Initialize();
			}
			this.string_16 = LicenseManager.Description;
			this.string_17 = LicenseManager.HardwareID;
		}

		[CommandMethod("MyCompute", "ng:ABOUT", 0)]
		public static void ShowAboutBox()
		{
			AboutBox aboutBox = new AboutBox(new AboutObject());
			aboutBox.Show();
		}

		public override string ToString()
		{
			string text = "About " + this.string_0 + Environment.NewLine;
			text += "".PadLeft(text.Length - 2, '-');
			PropertyInfo[] properties = base.GetType().GetProperties();
			PropertyInfo[] array = properties;
			for (int i = 0; i < array.Length; i++)
			{
				PropertyInfo propertyInfo = array[i];
				text += Environment.NewLine;
				text = text + propertyInfo.Name.PadRight(32, '.') + ": ";
				try
				{
					text += propertyInfo.GetValue(this, null).ToString();
				}
				catch
				{
					text += "null";
				}
			}
			return text;
		}

		[Category("\t\tHost system"), ReadOnly(false)]
		public string AcadVersion
		{
			get
			{
				return this.string_6;
			}
		}

		[Category("\t\tHost system"), ReadOnly(false)]
		public string CallingProcess
		{
			get
			{
				return this.string_5;
			}
		}

		[Category("\t\t\tProduct"), ReadOnly(false)]
		public string Copyright
		{
			get
			{
				return this.string_1;
			}
		}

		[Category("\t\tHost system"), ReadOnly(false)]
		public string Framework
		{
			get
			{
				return this.string_3;
			}
		}

		[Category("\tLicensing"), ReadOnly(false)]
		public string HardwareID
		{
			get
			{
				return this.string_17;
			}
		}

		[Category("\tLicensing"), ReadOnly(false)]
		public string LicenseType
		{
			get
			{
				return this.string_16;
			}
		}

		[Category("\tProcessor"), ReadOnly(false)]
		public string NumberOfCores
		{
			get
			{
				return this.string_10;
			}
		}

		[Category("\tProcessor"), ReadOnly(false)]
		public string NumberOfLogicalProcessors
		{
			get
			{
				return this.string_11;
			}
		}

		[Category("\t\tHost system"), ReadOnly(false)]
		public string OperatingSystem
		{
			get
			{
				return this.string_4;
			}
		}

		[Category("\tProcessor"), ReadOnly(false)]
		public string ProcessorArchitecture
		{
			get
			{
				return this.string_12;
			}
		}

		[Category("\tProcessor"), ReadOnly(false)]
		public string ProcessorDescription
		{
			get
			{
				return this.string_8;
			}
		}

		[Category("\tProcessor"), ReadOnly(false)]
		public string ProcessorManufacturer
		{
			get
			{
				return this.string_9;
			}
		}

		[Category("\tProcessor"), ReadOnly(false)]
		public string ProcessorName
		{
			get
			{
				return this.string_7;
			}
		}

		[Category("\t\t\tProduct"), ReadOnly(false)]
		public string ProductName
		{
			get
			{
				return this.string_0;
			}
		}

		[Category("\t\t\tProduct"), ReadOnly(false)]
		public string ProductVersion
		{
			get
			{
				return this.string_2;
			}
		}

		[Category("\t\t\tProduct"), ReadOnly(false)]
		public string SupportMail
		{
			get
			{
				return this.string_15;
			}
		}

		[Category("Memory"), ReadOnly(false)]
		public string TotalPhysicalMemory
		{
			get
			{
				return this.string_13;
			}
		}

		[Category("\t\t\tProduct"), ReadOnly(false)]
		public string URL
		{
			get
			{
				return this.string_14;
			}
		}

		private readonly string string_0;

		private readonly string string_1;

		private readonly string string_10;

		private readonly string string_11;

		private readonly string string_12;

		private readonly string string_13;

		private readonly string string_14;

		private readonly string string_15;

		private readonly string string_16;

		private readonly string string_17;

		private readonly string string_2;

		private readonly string string_3;

		private readonly string string_4;

		private readonly string string_5;

		private readonly string string_6;

		private readonly string string_7;

		private readonly string string_8;

		private readonly string string_9;
	}
}
