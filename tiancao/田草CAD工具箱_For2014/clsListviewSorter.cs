using System;
using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class clsListviewSorter : IComparer
	{
		public clsListviewSorter(int column_number, SortOrder sort_order)
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.int_0 = column_number;
			this.sortOrder_0 = sort_order;
		}

		public int Compare(object x, object y)
		{
			ListViewItem listViewItem = (ListViewItem)x;
			ListViewItem listViewItem2 = (ListViewItem)y;
			string text;
			if (listViewItem.SubItems.Count <= this.int_0)
			{
				text = "";
			}
			else
			{
				text = listViewItem.SubItems[this.int_0].Text;
			}
			string text2;
			if (listViewItem2.SubItems.Count <= this.int_0)
			{
				text2 = "";
			}
			else
			{
				text2 = listViewItem2.SubItems[this.int_0].Text;
			}
			int result;
			if (this.sortOrder_0 == SortOrder.Ascending)
			{
				if (Versioned.IsNumeric(text) & Versioned.IsNumeric(text2))
				{
					result = Conversion.Val(text).CompareTo(Conversion.Val(text2));
				}
				else if (Information.IsDate(text) & Information.IsDate(text2))
				{
					result = DateTime.Parse(text).CompareTo(DateTime.Parse(text2));
				}
				else
				{
					result = string.Compare(text, text2);
				}
			}
			else if (Versioned.IsNumeric(text) & Versioned.IsNumeric(text2))
			{
				result = Conversion.Val(text2).CompareTo(Conversion.Val(text));
			}
			else if (Information.IsDate(text) & Information.IsDate(text2))
			{
				result = DateTime.Parse(text2).CompareTo(DateTime.Parse(text));
			}
			else
			{
				result = string.Compare(text2, text);
			}
			return result;
		}

		private int int_0;

		private SortOrder sortOrder_0;
	}
}
