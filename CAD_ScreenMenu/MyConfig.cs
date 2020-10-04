using System;

namespace CAD屏幕菜单
{
	internal static class MyConfig
	{
		// Note: this type is marked as 'beforefieldinit'.
		static MyConfig()
		{
		}

		private static readonly string version = "V0.6测试版";

		private static readonly string UpdateTime = "2020.07.07";

		private static readonly string developer = "Mai.K";

		public static string CommandMessage = string.Concat(new string[]
		{
			"\n*****【屏幕菜单-",
			MyConfig.version,
			" ",
			MyConfig.UpdateTime,
			" By_",
			MyConfig.developer,
			"】已加载完成*****\n1.切换显示状态请输入【toggleScreenMenu】命令\n2.如果未出现屏幕菜单，请输入【showScreenMenu】命令手动显示.\n3.打开屏幕设置界面,请输入【screentMenuSetting】命令\n*********************************************"
		});
	}
}
