using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;

namespace CAD屏幕菜单
{
	public partial class UserControl1 : UserControl, IStyleConnector
	{
		public UserControl1()
		{
			this.InitializeComponent();
		}

		private void TreeView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			string text = "";
			if (sender is StackPanel)
			{
				StackPanel stackPanel = (StackPanel)sender;
				if (stackPanel.Tag != null)
				{
					if (!Convert.ToBoolean(stackPanel.Tag))
					{
						TextBlock textBlock = (TextBlock)((StackPanel)sender).FindName("command");
						if (textBlock.Tag != null)
						{
							text = (string)textBlock.Tag;
						}
						if (textBlock != null && text != "")
						{
							Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
							if (mdiActiveDocument != null)
							{
								mdiActiveDocument.SendStringToExecute(text + "\n", true, false, true);
								return;
							}
						}
					}
					else
					{
						TextBlock textBlock2 = e.Source as TextBlock;
						if (textBlock2 == null)
						{
							return;
						}
						try
						{
							TreeViewItem treeViewItem = this.GetTreeViewItem(textBlock2);
							if (treeViewItem != null && !e.Handled)
							{
								treeViewItem.IsExpanded = !treeViewItem.IsExpanded;
								treeViewItem.IsSelected = false;
								e.Handled = true;
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
			}
		}

		private TreeViewItem GetTreeViewItem(DependencyObject treeView)
		{
			TreeViewItem result;
			if (!(treeView is TreeViewItem))
			{
				result = this.GetTreeViewItem(VisualTreeHelper.GetParent(treeView));
			}
			else
			{
				result = (TreeViewItem)treeView;
			}
			return result;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((StackPanel)target).MouseLeftButtonDown += this.TreeView_MouseLeftButtonDown;
			}
		}
	}
}
