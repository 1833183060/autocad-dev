using System;
using System.Diagnostics;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class 全局比例
	{
		[DebuggerNonUserCode]
		public 全局比例()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		[CommandMethod("TcS1")]
		public void S1()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(1));
		}

		[CommandMethod("TcS10")]
		public void S10()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(10));
		}

		[CommandMethod("TcS20")]
		public void S20()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(20));
		}

		[CommandMethod("TcS25")]
		public void S25()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(25));
		}

		[CommandMethod("TcS50")]
		public void S50()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(50));
		}

		[CommandMethod("TcS100")]
		public void S100()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(100));
		}

		[CommandMethod("TcS150")]
		public void S150()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(150));
		}

		[CommandMethod("TcS200")]
		public void S200()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(200));
		}

		[CommandMethod("TcS500")]
		public void S500()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(500));
		}

		[CommandMethod("TcS1000")]
		public void S1000()
		{
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(1000));
		}

		[CommandMethod("TcSx")]
		public void Sx()
		{
			int value = Conversions.ToInteger(Interaction.InputBox("自定义比例", "", Conversions.ToString(100), -1, -1));
			Interaction.SaveSetting("田草CAD工具箱", "_DrawScale", "_DrawScale", Conversions.ToString(value));
		}
	}
}
