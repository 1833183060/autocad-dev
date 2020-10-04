using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TerrainComputeC
{
	//[LicenseProvider(typeof(Class46))]
	public class MessageFilter : IMessageFilter
	{
		public MessageFilter()
		{
            //System.ComponentModel.LicenseManager.Validate(typeof(MessageFilter));
			//base..ctor();
		}

		public void CheckMessageFilter()
		{
            System.Windows.Forms.Application.DoEvents();
			if (this.bCanceled)
			{
				this.bCanceled = false;
                throw new System.Exception("Command cancelled by user");
			}
		}

		public void CheckMessageFilter(long index, int doEventsAtIndex)
		{
			if (index % (long)doEventsAtIndex == 0L)
			{
                System.Windows.Forms.Application.DoEvents();
				if (this.bCanceled)
				{
					this.bCanceled = false;
                    throw new System.Exception("Command cancelled by user");
				}
			}
		}

		public bool PreFilterMessage(ref Message m)
		{
            return false;
			if (m.Msg == 256)
			{
				Keys keys = (Keys)((int)m.WParam & 65535);
				if (m.Msg == 256 && keys == Keys.Escape)
				{
					this.bCanceled = true;
				}
				return true;
			}
			return false;
		}

		public bool bCanceled;

		public const int WM_KEYDOWN = 256;
	}
}
