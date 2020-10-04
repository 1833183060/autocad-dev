using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TcDotNetBarcode.My
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[CompilerGenerated]
	internal sealed partial class MySettings : ApplicationSettingsBase
	{
		public static MySettings Default
		{
			get
			{
				return MySettings.defaultInstance;
			}
		}

		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
	}
}
