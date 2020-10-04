using System;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using TcFunctions;

namespace 田草CAD工具箱_For2014
{
	public class 连续标注 : DrawJig
	{
		public 连续标注()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
			this.entity_0 = new Entity[1];
			this.point3d_0 = null;
		}

		[CommandMethod("TcLXBZ")]
		public void TcLXBZ()
		{
			int num;
			int num11;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Class36.smethod_78("Dim80", 80, 1.0, true);
				IL_22:
				num2 = 3;
				this.point3d_0 = new Point3d[2];
				IL_30:
				num2 = 6;
				ObjectId[] array = new ObjectId[2];
				IL_3A:
				num2 = 7;
				ObjectId[] array2 = null;
				IL_3F:
				num2 = 8;
				this.point3d_0[0] = CAD.GetPoint("选择插入点: ");
				IL_5C:
				num2 = 9;
				Point3d point3d;
				if (!(this.point3d_0[0] == point3d))
				{
					goto IL_7E;
				}
				IL_79:
				goto IL_425;
				IL_7E:
				num2 = 12;
				IL_81:
				num2 = 13;
				this.point3d_2 = this.point3d_0[0];
				IL_9B:
				num2 = 15;
				this.short_0 = 1;
				IL_A5:
				num2 = 16;
				if (this.LineDimJig() != 1)
				{
					goto IL_2CB;
				}
				IL_B6:
				num2 = 17;
				this.short_0 = 2;
				IL_C0:
				num2 = 18;
				this.LineDimJig();
				checked
				{
					for (;;)
					{
						IL_2A4:
						num2 = 23;
						short num3 = (short)Information.UBound(this.point3d_0, 1);
						IL_CF:
						num2 = 24;
						Class36.smethod_60(Conversions.ToString((int)num3));
						IL_DF:
						num2 = 25;
						if (num3 == 0)
						{
							IL_E9:
							num2 = 26;
							num3 = 1;
						}
						IL_EF:
						num2 = 28;
						array = new ObjectId[(int)(num3 - 1 + 1)];
						IL_FF:
						num2 = 31;
						int num4 = 0;
						int num5 = (int)(num3 - 1);
						int num6 = num4;
						for (;;)
						{
							int num7 = num6;
							int num8 = num5;
							if (num7 > num8)
							{
								break;
							}
							IL_10D:
							num2 = 32;
							array[num6] = CAD.AddLineDim(this.point3d_0[num6], this.point3d_0[num6 + 1], this.point3d_1);
							IL_14F:
							num2 = 33;
							num6++;
						}
						IL_162:
						num2 = 34;
						if (array2 != null)
						{
							IL_16F:
							num2 = 35;
							ObjectId[] array3 = array2;
							int i = 0;
							while (i < array3.Length)
							{
								ObjectId objectId = array3[i];
								IL_192:
								num2 = 36;
								ObjectId objectId2;
								if (objectId != objectId2)
								{
									IL_19E:
									num2 = 37;
									Class36.smethod_64(objectId);
								}
								i++;
								IL_1AE:
								num2 = 39;
							}
						}
						IL_1B3:
						num2 = 41;
						array2 = array;
						IL_1BA:
						num2 = 42;
						int num9 = Information.UBound(this.point3d_0, 1);
						IL_1CB:
						num2 = 43;
						this.point3d_0 = (Point3d[])Utils.CopyArray((Array)this.point3d_0, new Point3d[num9 + 1 + 1]);
						IL_1F4:
						num2 = 46;
						int num10 = (int)Class36.smethod_29(this.point3d_0[num9], ref this.point3d_0[num9 + 1], "选择下一点: ");
						IL_224:
						num2 = 47;
						this.point3d_0[num9 + 1] = Class36.smethod_62(this.point3d_0[num9 + 1], this.point3d_0[0], this.point3d_0[1]);
						IL_276:
						num2 = 48;
						Class36.smethod_47(ref this.point3d_0);
						IL_285:
						num2 = 49;
						if (Information.Err().Number > 0)
						{
							break;
						}
						IL_297:
						num2 = 52;
						if (num10 == 0)
						{
							break;
						}
						IL_2A1:
						num2 = 55;
					}
					IL_2BB:
					num2 = 58;
					Class36.smethod_55(array);
					IL_2C6:
					goto IL_425;
					IL_2CB:
					num2 = 20;
					IL_2CE:
					goto IL_425;
					IL_2D3:
					goto IL_41A;
					IL_2D8:
					num11 = num2;
					if (num <= -2)
					{
						goto IL_2F3;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					goto IL_3F4;
					IL_2F3:;
				}
				int num12 = num11 + 1;
				num11 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num12);
				IL_3F4:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num11 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_2D8;
			}
			IL_41A:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_425:
			if (num11 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public short LineDimJig()
		{
			int num;
			short num3;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				IL_11:
				num2 = 3;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				IL_24:
				num2 = 4;
				PromptResult promptResult = editor.Drag(this);
				IL_2F:
				num2 = 5;
				if (promptResult.Status != 5100)
				{
					goto IL_85;
				}
				IL_40:
				num2 = 6;
				if (this.short_0 != 1)
				{
					goto IL_68;
				}
				IL_4D:
				num2 = 7;
				this.point3d_0[1] = this.point3d_3;
				goto IL_7A;
				IL_68:
				num2 = 9;
				IL_6B:
				num2 = 10;
				this.point3d_1 = this.point3d_3;
				IL_7A:
				num2 = 12;
				num3 = 1;
				goto IL_12B;
				IL_85:
				num2 = 14;
				IL_88:
				num2 = 15;
				num3 = -1;
				goto IL_12B;
				IL_93:
				goto IL_137;
				IL_98:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_B2;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_AD:
				goto IL_137;
				IL_B2:
				int num5 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num5);
				goto IL_93;
				IL_106:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_98;
			}
			IL_12B:
			short result = num3;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
			IL_137:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		protected override SamplerStatus Sampler(JigPrompts Prompts)
		{
			PromptPointResult promptPointResult = Prompts.AcquirePoint(new JigPromptPointOptions("\r\n请指定下一点:")
			{
				UserInputControls = 2,
				Cursor = 2,
				BasePoint = this.point3d_2,
				UseBasePoint = true
			});
			Point3d value = promptPointResult.Value;
			SamplerStatus result;
			if (value != this.point3d_3)
			{
				AlignedDimension alignedDimension = new AlignedDimension();
				alignedDimension.SetDatabaseDefaults();
				if (this.short_0 == 1)
				{
					alignedDimension.XLine1Point = this.point3d_2;
					alignedDimension.XLine2Point = value;
					double num = this.point3d_2.GetVectorTo(value).AngleOnPlane(new Plane());
					Point3d pointAngle = CAD.GetPointAngle(this.point3d_2, 600.0, num * 180.0 / 3.1415926535897931 + 90.0);
					alignedDimension.DimLinePoint = pointAngle;
				}
				else if (this.short_0 == 2)
				{
					alignedDimension.XLine1Point = this.point3d_2;
					alignedDimension.XLine2Point = this.point3d_0[1];
					alignedDimension.DimLinePoint = value;
				}
				this.entity_0[0] = alignedDimension;
				this.point3d_3 = value;
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		protected override bool WorldDraw(WorldDraw Draw)
		{
			foreach (Entity obj in this.entity_0)
			{
				Draw.Geometry.Draw((Drawable)obj);
			}
			return true;
		}

		private Entity[] entity_0;

		private Point3d[] point3d_0;

		private Point3d point3d_1;

		private short short_0;

		private Point3d point3d_2;

		private Point3d point3d_3;
	}
}
