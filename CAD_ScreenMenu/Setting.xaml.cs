using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace CAD屏幕菜单
{
	public partial class Setting : Window
	{
		public static Setting Instance { get; private set; }

		public Setting()
		{
			this.InitializeComponent();
			this.LoadConfig();
			base.Closed += this.Setting_Closed;
		}

		private void Setting_Closed(object sender, EventArgs e)
		{
			Setting.Instance = null;
		}

		public static void GetInstance()
		{
			if (Setting.Instance == null)
			{
				Setting.Instance = new Setting();
				Setting.Instance.Show();
				return;
			}
			Setting.Instance.Activate();
		}

		private void LoadConfig()
		{
			string text = Tools.GetElementValueFromXML("Title", "Config.xml") ?? "迷你&源泉";
			bool value;
			bool.TryParse(Tools.GetElementValueFromXML("AutoLoad", "Config.xml"), out value);
			bool value2;
			bool.TryParse(Tools.GetElementValueFromXML("AutoRollUp", "Config.xml"), out value2);
			string elementValueFromXML = Tools.GetElementValueFromXML("Height", "Config.xml");
			string elementValueFromXML2 = Tools.GetElementValueFromXML("Width", "Config.xml");
			string text2 = Tools.GetElementValueFromXML("DockSides", "Config.xml").ToLower();
			if (text2 != null)
			{
				if (!(text2 == "left"))
				{
					if (text2 == "right")
					{
						this.rightRB.IsChecked = new bool?(true);
					}
				}
				else
				{
					this.leftRB.IsChecked = new bool?(true);
				}
			}
			this.title.Text = text;
			this.AutoLoadCB.IsChecked = new bool?(value);
			this.AutoRollUpCB.IsChecked = new bool?(value2);
			this.HeightTextBox.Text = elementValueFromXML;
			this.WidthTextBox.Text = elementValueFromXML2;
		}

		private void Confirm_Click(object sender, RoutedEventArgs e)
		{
			string value = "left";
			int num;
			bool flag = int.TryParse(this.HeightTextBox.Text, out num);
			int num2;
			bool flag2 = int.TryParse(this.WidthTextBox.Text, out num2);
			if (num < 700)
			{
				num = 700;
			}
			else if (num > 1400)
			{
				num = 1400;
			}
			if (num2 < 200)
			{
				num2 = 200;
			}
			else if (num2 > 800)
			{
				num2 = 800;
			}
			try
			{
				bool? isChecked = this.AutoLoadCB.IsChecked;
				bool flag3 = true;
				if (isChecked.GetValueOrDefault() == flag3 & isChecked != null)
				{
					RegeditHelper.RegisterScreenMenu();
				}
				else
				{
					isChecked = this.AutoLoadCB.IsChecked;
					flag3 = false;
					if (isChecked.GetValueOrDefault() == flag3 & isChecked != null)
					{
						RegeditHelper.UnregisterScreenMenu();
					}
				}
				if (Tools.paletteSet != null)
				{
					Tools.paletteSet.Visible = true;
					if (flag && flag2)
					{
						Tools.paletteSet.Dock = 0;
						Tools.paletteSet.AutoRollUp = false;
						Tools.paletteSet.Size = new System.Drawing.Size(num2, num);
						Tools.paletteSet.AutoRollUp = this.AutoRollUpCB.IsChecked.Value;
						if (this.leftRB.IsChecked.Value)
						{
							Tools.paletteSet.Dock = 4096;
							value = "left";
						}
						else
						{
							Tools.paletteSet.Dock = 16384;
							value = "right";
						}
						Tools.paletteSet.Name = (string.IsNullOrWhiteSpace(this.title.Text) ? "迷你&源泉菜单" : this.title.Text);
					}
				}
			}
			catch (Exception ex)
			{
				Tools.PrintCommandLine("此吸附停靠状态下，设置停靠失败.请取消吸附状态后再试。\n" + ex.Message + "\n");
			}
			finally
			{
				Tools.SaveConfigToXml("Config.xml", "Title", string.IsNullOrWhiteSpace(this.title.Text) ? "迷你&源泉菜单" : this.title.Text);
				Tools.SaveConfigToXml("Config.xml", "AutoLoad", this.AutoLoadCB.IsChecked.ToString());
				Tools.SaveConfigToXml("Config.xml", "AutoRollUp", this.AutoRollUpCB.IsChecked.ToString());
				Tools.SaveConfigToXml("Config.xml", "Height", num.ToString());
				Tools.SaveConfigToXml("Config.xml", "Width", num2.ToString());
				Tools.SaveConfigToXml("Config.xml", "DockSides", value);
				base.Close();
			}
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}
