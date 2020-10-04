using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;

namespace CAD屏幕菜单
{
	public class MyPlugin : IExtensionApplication
	{
		public void Initialize()
		{
			if (this.documentCollection == null)
			{
				this.documentCollection = Application.DocumentManager;
			}
			bool flag;
			bool.TryParse(Tools.GetElementValueFromXML("FistLoad", "Config.xml"), out flag);
			if (this.documentCollection.MdiActiveDocument != null & this.documentCollection.MdiActiveDocument.IsActive)
			{
				if (flag)
				{
					Tools.ScreentMenuSetting();
					Tools.SaveConfigToXml("Config.xml", "FistLoad", "false");
				}
				Tools.Show();
			}
			this.documentCollection.DocumentCreated += new DocumentCollectionEventHandler(this.DocumentCollection_DocumentCreated);
		}

		private void DocumentCollection_DocumentCreated(object sender, DocumentCollectionEventArgs e)
		{
			Tools.Show();
		}

		public void Terminate()
		{
		}

		public MyPlugin()
		{
		}

		private DocumentCollection documentCollection;
	}
}
