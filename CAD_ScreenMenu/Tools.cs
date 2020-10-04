using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;

namespace CAD屏幕菜单
{
	public class Tools
	{
		public static void Show()
		{
			if (Tools.paletteSet == null || Tools.paletteSet.IsDisposed)
			{
				try
				{
					List<ConfigClass> list = Tools.LoadConfigXml("Config.xml");
					string text = Tools.GetElementValueFromXML("Title", "Config.xml") ?? "迷你&源泉";
					bool flag;
					bool.TryParse(Tools.GetElementValueFromXML("AutoLoad", "Config.xml"), out flag);
					bool autoRollUp;
					bool.TryParse(Tools.GetElementValueFromXML("AutoRollUp", "Config.xml"), out autoRollUp);
					int num;
					int.TryParse(Tools.GetElementValueFromXML("Height", "Config.xml"), out num);
					int num2;
					int.TryParse(Tools.GetElementValueFromXML("Width", "Config.xml"), out num2);
					string text2 = Tools.GetElementValueFromXML("DockSides", "Config.xml").ToLower();
					if (flag)
					{
						RegeditHelper.RegisterScreenMenu();
						Tools.PrintCommandLine("\n******屏幕菜单已跟随ACAD启动时自动启用.*****\n");
					}
					else
					{
						RegeditHelper.UnregisterScreenMenu();
					}
					DockSides dock;
					if (text2 != null)
					{
						if (text2 == "left")
						{
							dock = 4096;
							goto IL_107;
						}
						if (text2 == "right")
						{
							dock = 16384;
							goto IL_107;
						}
					}
					dock = 4096;
					IL_107:
					Tools.paletteSet = new PaletteSet(text);
					if (list != null)
					{
						foreach (ConfigClass configClass in list)
						{
							if (configClass.IsEnable)
							{
								if (Tools.tools == null)
								{
									Tools.tools = new Tools();
								}
								UserControl1 controlFromXml = Tools.tools.GetControlFromXml(configClass);
								if (controlFromXml != null)
								{
									Tools.paletteSet.AddVisual(configClass.Name, controlFromXml);
								}
							}
						}
						Tools.paletteSet.MinimumSize = new System.Drawing.Size(200, 700);
						Tools.paletteSet.Visible = true;
						if (num != 0 && num2 != 0)
						{
							WindowExtension.SetSize(Tools.paletteSet, new System.Drawing.Size(num2, num));
						}
						Tools.paletteSet.DockEnabled = 20480;
						Tools.paletteSet.AutoRollUp = autoRollUp;
						Tools.paletteSet.Dock = dock;
						Tools.paletteSet.Opacity = 80;
						Tools.PrintCommandLine(MyConfig.CommandMessage);
					}
				}
				catch (Exception ex)
				{
					Tools.PrintCommandLine("屏幕菜单发生错误，错误信息：" + ex.Message + ".");
				}
			}
		}

		[CommandMethod("screentMenuSetting")]
		public static void ScreentMenuSetting()
		{
			Setting.GetInstance();
		}

		[CommandMethod("showDockState")]
		public static void showDockState()
		{
			Tools.PrintCommandLine(Tools.paletteSet.Dock.ToString());
		}

		[CommandMethod("showScreenMenu")]
		public void ShowScreenMenu()
		{
			Tools.Show();
		}

		[CommandMethod("togglescreenmenu")]
		public static void TogglePaletteSetVisibility()
		{
			if (Tools.paletteSet != null)
			{
				Tools.paletteSet.Visible = !Tools.paletteSet.Visible;
			}
		}

		private static List<ConfigClass> LoadConfigXml(string configXmlName)
		{
			List<ConfigClass> list = new List<ConfigClass>();
			string text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + configXmlName;
			List<ConfigClass> result;
			try
			{
				foreach (ConfigClass item in from e in XDocument.Load(text).Element("Config").Elements()
				where e.Name == "PaletteSet"
				select new ConfigClass
				{
					Name = e.Value,
					IsEnable = Convert.ToBoolean(e.Attribute("ISEnable").Value),
					IconFolder = e.Attribute("IconFolder").Value,
					XmlFileName = e.Attribute("XmlFileName").Value
				})
				{
					list.Add(item);
				}
				result = list;
			}
			catch (Exception ex)
			{
				Tools.PrintCommandLine(string.Concat(new string[]
				{
					"读取配置文件发生错误，错误信息：",
					ex.Message,
					"\n请检查 ",
					text,
					" 文件."
				}));
				result = null;
			}
			return result;
		}

		public static string GetElementValueFromXML(string elementName, string XmlFileName)
		{
			string text = "";
			string text2 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + XmlFileName;
			string result;
			try
			{
				foreach (XElement xelement in from el in XDocument.Load(text2).Element("Config").Elements()
				where el.Name == elementName
				select el)
				{
					text = xelement.Value;
				}
				result = text;
			}
			catch (Exception ex)
			{
				Tools.PrintCommandLine(string.Concat(new string[]
				{
					"读取配置文件发生错误，错误信息：",
					ex.Message,
					"\n请检查 ",
					text2,
					" 文件."
				}));
				result = text;
			}
			return result;
		}

		public static void SaveConfigToXml(string xmlFileName, string elementName, string value)
		{
			string text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + xmlFileName;
			try
			{
				XDocument xdocument = XDocument.Load(text);
				(from el in xdocument.Element("Config").Elements()
				where el.Name == elementName
				select el).First<XElement>().Value = value;
				xdocument.Save(text);
			}
			catch (Exception ex)
			{
				Tools.PrintCommandLine("保存配置文件出错:" + ex.Message);
			}
		}

		private UserControl1 GetControlFromXml(ConfigClass config)
		{
			string xmlFileName = config.XmlFileName;
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string text = directoryName + "\\" + xmlFileName;
			UserControl1 result;
			try
			{
				XElement rt = XDocument.Load(text).Element("ScreenMenu");
				List<CustomizeTreeViewItem> lists = new List<CustomizeTreeViewItem>();
				string folderPath = directoryName + "\\" + config.IconFolder;
				List<CustomizeTreeViewItem> itemsSource = this.LinqElement(rt, lists, folderPath);
				UserControl1 userControl = new UserControl1();
				((TreeView)userControl.FindName("treeView")).ItemsSource = itemsSource;
				result = userControl;
			}
			catch (Exception ex)
			{
				Tools.PrintCommandLine(string.Concat(new string[]
				{
					"读取配置文件发生错误，错误信息：",
					ex.Message,
					"\n请检查 【",
					text,
					"】 文件."
				}));
				result = null;
			}
			return result;
		}

		private List<CustomizeTreeViewItem> LinqElement(XElement rt, List<CustomizeTreeViewItem> lists, string FolderPath)
		{
			foreach (XElement xelement in rt.Elements())
			{
				if (xelement.Name == "Group" && xelement.Attribute("Title") != null)
				{
					string textColor = "#FFF5F5F5";
					string name = xelement.Attribute("Title").Value ?? "";
					if (xelement.Attribute("TextColor") != null && xelement.Attribute("TextColor").Value != null)
					{
						textColor = xelement.Attribute("TextColor").Value;
					}
					List<CustomizeTreeViewItem> children = new List<CustomizeTreeViewItem>();
					CustomizeTreeViewItem customizeTreeViewItem = new CustomizeTreeViewItem
					{
						Name = name,
						TextColor = textColor,
						Children = children,
						ImageVisibility = Visibility.Collapsed,
						IsGroup = true,
						BorderVisibility = Visibility.Collapsed
					};
					lists.Add(customizeTreeViewItem);
					this.LinqElement(xelement, customizeTreeViewItem.Children, FolderPath);
				}
				if (xelement.Name == "Item" && xelement.Value != "-")
				{
					string name2 = xelement.Value ?? "";
					string command = xelement.Attribute("Command").Value ?? "";
					string text;
					if (xelement.Attribute("ImageFile").Value != "")
					{
						text = FolderPath + xelement.Attribute("ImageFile").Value;
						if (!File.Exists(text))
						{
							text = "icons/blank.png";
						}
					}
					else
					{
						text = "icons/blank.png";
					}
					string textColor2 = xelement.Attribute("TextColor").Value ?? "#FFF5F5F5";
					CustomizeTreeViewItem item = new CustomizeTreeViewItem
					{
						Name = name2,
						Command = command,
						Icon = text,
						TextColor = textColor2,
						ImageVisibility = Visibility.Visible,
						IsGroup = false,
						BorderVisibility = Visibility.Collapsed
					};
					lists.Add(item);
				}
			}
			return lists;
		}

		public static void PrintCommandLine(string message)
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			if (mdiActiveDocument != null)
			{
				mdiActiveDocument.Editor.WriteMessage(message);
			}
		}

		public Tools()
		{
		}

		public static PaletteSet paletteSet;

		public static Tools tools;

		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Note: this type is marked as 'beforefieldinit'.
			static <>c()
			{
			}

			public <>c()
			{
			}

			internal bool <LoadConfigXml>b__7_0(XElement e)
			{
				return e.Name == "PaletteSet";
			}

			internal ConfigClass <LoadConfigXml>b__7_1(XElement e)
			{
				return new ConfigClass
				{
					Name = e.Value,
					IsEnable = Convert.ToBoolean(e.Attribute("ISEnable").Value),
					IconFolder = e.Attribute("IconFolder").Value,
					XmlFileName = e.Attribute("XmlFileName").Value
				};
			}

			public static readonly Tools.<>c <>9 = new Tools.<>c();

			public static Func<XElement, bool> <>9__7_0;

			public static Func<XElement, ConfigClass> <>9__7_1;
		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass8_0
		{
			public <>c__DisplayClass8_0()
			{
			}

			internal bool <GetElementValueFromXML>b__0(XElement el)
			{
				return el.Name == this.elementName;
			}

			public string elementName;
		}

		[CompilerGenerated]
		private sealed class <>c__DisplayClass9_0
		{
			public <>c__DisplayClass9_0()
			{
			}

			internal bool <SaveConfigToXml>b__0(XElement el)
			{
				return el.Name == this.elementName;
			}

			public string elementName;
		}
	}
}
