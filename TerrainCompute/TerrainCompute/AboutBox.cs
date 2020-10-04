using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using ComputationalCAD.Properties;

namespace MyCompute
{
	//[LicenseProvider(typeof(Class46))]
	public partial class AboutBox : Form
	{
		public AboutBox(AboutObject abo)
		{
			//System.ComponentModel.LicenseManager.Validate(typeof(AboutBox));
			this.aboutObject_0 = new AboutObject();
			////base..ctor();
			this.aboutObject_0 = abo;
			this.method_1();
			this.propertyGrid_0.SelectedObject = this.aboutObject_0;
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.aboutObject_0.ToString());
		}

		private void method_0()
		{
			this.propertyGrid_0 = new PropertyGrid();
			this.button_0 = new Button();
			this.button_1 = new Button();
			base.SuspendLayout();
			this.propertyGrid_0.HelpVisible = false;
			this.propertyGrid_0.ToolbarVisible = false;
			this.propertyGrid_0.Text = "About ComputationalCAD";
			this.propertyGrid_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.propertyGrid_0.PropertySort = PropertySort.Categorized;
			this.propertyGrid_0.Dock = DockStyle.Fill;
			this.button_1.Text = "Copy to clipbord";
			this.button_1.Dock = DockStyle.Bottom;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.Text = "About ComputationalCAD";
			base.Size = new Size(500, 450);
            base.Icon = MyCompute.ComputationalCAD.Properties.Resources.about;
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Controls.Add(this.propertyGrid_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.ResumeLayout(false);
		}

		private void method_1()
		{
			this.propertyGrid_0 = new PropertyGrid();
			this.button_0 = new Button();
			this.button_1 = new Button();
			base.SuspendLayout();
			this.propertyGrid_0.HelpVisible = false;
			this.propertyGrid_0.ToolbarVisible = false;
			this.propertyGrid_0.Text = "About ComputationalCAD";
			this.propertyGrid_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.propertyGrid_0.PropertySort = PropertySort.Categorized;
			this.propertyGrid_0.Dock = DockStyle.Fill;
			this.button_1.Text = "Copy to clipbord";
			this.button_1.Dock = DockStyle.Bottom;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.Text = "About ComputationalCAD";
			base.Size = new Size(500, 450);
            base.Icon = MyCompute.ComputationalCAD.Properties.Resources.about;
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Controls.Add(this.propertyGrid_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.ResumeLayout(false);
		}

		private AboutObject aboutObject_0;

		private Button button_0;

		private Button button_1;

		private PropertyGrid propertyGrid_0;
	}
}
