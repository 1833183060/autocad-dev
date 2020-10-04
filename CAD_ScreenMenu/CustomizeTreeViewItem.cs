using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CAD屏幕菜单
{
	public class CustomizeTreeViewItem
	{
		public bool IsGroup
		{
			[CompilerGenerated]
			get
			{
				return this.<IsGroup>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<IsGroup>k__BackingField = value;
			}
		}

		public Visibility BorderVisibility
		{
			[CompilerGenerated]
			get
			{
				return this.<BorderVisibility>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<BorderVisibility>k__BackingField = value;
			}
		}

		public Visibility ImageVisibility
		{
			[CompilerGenerated]
			get
			{
				return this.<ImageVisibility>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<ImageVisibility>k__BackingField = value;
			}
		}

		public Visibility TextVisibility
		{
			[CompilerGenerated]
			get
			{
				return this.<TextVisibility>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<TextVisibility>k__BackingField = value;
			}
		}

		public string Height
		{
			[CompilerGenerated]
			get
			{
				return this.<Height>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Height>k__BackingField = value;
			}
		}

		public string Command
		{
			[CompilerGenerated]
			get
			{
				return this.<Command>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Command>k__BackingField = value;
			}
		}

		public string Icon
		{
			[CompilerGenerated]
			get
			{
				return this.<Icon>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Icon>k__BackingField = value;
			}
		}

		public string TextColor
		{
			[CompilerGenerated]
			get
			{
				return this.<TextColor>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<TextColor>k__BackingField = value;
			}
		}

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return this.<Name>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Name>k__BackingField = value;
			}
		}

		public List<CustomizeTreeViewItem> Children
		{
			[CompilerGenerated]
			get
			{
				return this.<Children>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Children>k__BackingField = value;
			}
		}

		public CustomizeTreeViewItem()
		{
			this.BorderVisibility = Visibility.Collapsed;
			this.ImageVisibility = Visibility.Visible;
			this.TextVisibility = Visibility.Visible;
		}

		[CompilerGenerated]
		private bool <IsGroup>k__BackingField;

		[CompilerGenerated]
		private Visibility <BorderVisibility>k__BackingField;

		[CompilerGenerated]
		private Visibility <ImageVisibility>k__BackingField;

		[CompilerGenerated]
		private Visibility <TextVisibility>k__BackingField;

		[CompilerGenerated]
		private string <Height>k__BackingField;

		[CompilerGenerated]
		private string <Command>k__BackingField;

		[CompilerGenerated]
		private string <Icon>k__BackingField;

		[CompilerGenerated]
		private string <TextColor>k__BackingField;

		[CompilerGenerated]
		private string <Name>k__BackingField;

		[CompilerGenerated]
		private List<CustomizeTreeViewItem> <Children>k__BackingField;
	}
}
