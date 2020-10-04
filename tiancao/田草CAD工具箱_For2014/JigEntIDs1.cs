using System;
using System.Diagnostics;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Microsoft.VisualBasic.CompilerServices;

namespace 田草CAD工具箱_For2014
{
	public class JigEntIDs1 : DrawJig
	{
		[DebuggerNonUserCode]
		public JigEntIDs1()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		public short method_0(ObjectIdCollection EntIDs, Point3d BasePoint)
		{
			int num;
			short num11;
			int num16;
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
				IL_23:
				num2 = 4;
				long num3 = (long)(checked(EntIDs.Count - 1));
				IL_30:
				num2 = 5;
				checked
				{
					this.entity_0 = new Entity[(int)num3 + 1];
					IL_42:
					num2 = 8;
					Entity[] array = new Entity[(int)num3 + 1];
					IL_50:
					num2 = 9;
					this.objectIdCollection_0 = EntIDs;
					IL_5A:
					num2 = 10;
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
						int num4 = 0;
						int num5 = (int)num3;
						this.int_0 = num4;
						for (;;)
						{
							int num6 = this.int_0;
							int num7 = num5;
							if (num6 > num7)
							{
								break;
							}
							array[this.int_0] = (Entity)transaction.GetObject(EntIDs[this.int_0], 1);
							this.entity_0[this.int_0] = (Entity)array[this.int_0].Clone();
							array[this.int_0].Visible = false;
							this.int_0++;
						}
						this.point3d_0 = BasePoint;
						this.point3d_1 = this.point3d_0;
						this.point3d_2 = this.point3d_1;
						PromptResult promptResult = editor.Drag(this);
						if (promptResult.Status == 5100)
						{
							BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, 0);
							BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
							int num8 = 0;
							int num9 = (int)num3;
							this.int_0 = num8;
							for (;;)
							{
								int num10 = this.int_0;
								int num7 = num9;
								if (num10 > num7)
								{
									break;
								}
								blockTableRecord.AppendEntity(this.entity_0[this.int_0]);
								transaction.AddNewlyCreatedDBObject(this.entity_0[this.int_0], true);
								this.int_0++;
							}
						}
						else
						{
							num11 = -1;
						}
						int num12 = 0;
						int num13 = (int)num3;
						this.int_0 = num12;
						for (;;)
						{
							int num14 = this.int_0;
							int num7 = num13;
							if (num14 > num7)
							{
								break;
							}
							array[this.int_0].Erase();
							this.int_0++;
						}
						transaction.Commit();
					}
					IL_1FC:
					goto IL_283;
					IL_201:;
				}
				int num15 = num16 + 1;
				num16 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num15);
				IL_23D:
				goto IL_278;
				IL_23F:
				num16 = num2;
				if (num <= -2)
				{
					goto IL_201;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_255:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num16 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_23F;
			}
			IL_278:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_283:
			short result = num11;
			if (num16 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		protected override SamplerStatus Sampler(JigPrompts prompts)
		{
			int num;
			SamplerStatus samplerStatus;
			int num7;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				JigPromptPointOptions jigPromptPointOptions = new JigPromptPointOptions("\r\n请指定插入点:");
				IL_16:
				num2 = 3;
				jigPromptPointOptions.UserInputControls = 2;
				IL_1F:
				num2 = 4;
				jigPromptPointOptions.Cursor = 3;
				IL_28:
				num2 = 5;
				jigPromptPointOptions.BasePoint = this.point3d_0;
				IL_36:
				num2 = 6;
				jigPromptPointOptions.UseBasePoint = true;
				IL_3F:
				num2 = 7;
				PromptPointResult promptPointResult = prompts.AcquirePoint(jigPromptPointOptions);
				IL_4A:
				num2 = 8;
				if (promptPointResult.Status != -5002)
				{
					goto IL_61;
				}
				IL_5C:
				goto IL_1DC;
				IL_61:
				num2 = 11;
				IL_64:
				num2 = 12;
				this.point3d_1 = promptPointResult.Value;
				IL_74:
				num2 = 13;
				if (!(this.point3d_2 != this.point3d_1))
				{
					goto IL_113;
				}
				IL_8D:
				num2 = 14;
				Matrix3d matrix3d = Matrix3d.Displacement(this.point3d_1 - this.point3d_2);
				IL_A8:
				num2 = 15;
				int num3 = 0;
				checked
				{
					int num4 = this.objectIdCollection_0.Count - 1;
					this.int_0 = num3;
					for (;;)
					{
						int num5 = this.int_0;
						int num6 = num4;
						if (num5 > num6)
						{
							break;
						}
						IL_C3:
						num2 = 16;
						this.entity_0[this.int_0].TransformBy(matrix3d);
						IL_DA:
						num2 = 17;
						this.int_0++;
					}
					IL_F9:
					num2 = 18;
					this.point3d_2 = this.point3d_1;
					IL_108:
					num2 = 19;
					samplerStatus = 0;
					goto IL_1DC;
					IL_113:
					num2 = 21;
					IL_116:
					num2 = 22;
					samplerStatus = 1;
					goto IL_1DC;
					IL_121:
					goto IL_1E8;
					IL_126:
					num7 = num2;
					if (num <= -2)
					{
						goto IL_140;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					IL_13B:
					goto IL_1E8;
					IL_140:;
				}
				int num8 = num7 + 1;
				num7 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				goto IL_121;
				IL_1B7:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num7 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_126;
			}
			IL_1DC:
			SamplerStatus result = samplerStatus;
			if (num7 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
			IL_1E8:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		protected override bool WorldDraw(WorldDraw draw)
		{
			int num;
			bool flag;
			int num7;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				int num3 = 0;
				checked
				{
					int num4 = this.objectIdCollection_0.Count - 1;
					this.int_0 = num3;
					for (;;)
					{
						int num5 = this.int_0;
						int num6 = num4;
						if (num5 > num6)
						{
							break;
						}
						IL_22:
						num2 = 3;
						draw.Geometry.Draw(this.entity_0[this.int_0]);
						IL_3D:
						num2 = 4;
						this.int_0++;
					}
					IL_5A:
					num2 = 5;
					flag = true;
					goto IL_C4;
					IL_61:
					goto IL_D0;
					IL_63:
					num7 = num2;
					if (num <= -2)
					{
						goto IL_7A;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					IL_78:
					goto IL_D0;
					IL_7A:;
				}
				int num8 = num7 + 1;
				num7 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				goto IL_61;
				IL_A2:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num7 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_63;
			}
			IL_C4:
			bool result = flag;
			if (num7 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
			IL_D0:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private Point3d point3d_0;

		private Point3d point3d_1;

		private Point3d point3d_2;

		private int int_0;

		private Entity[] entity_0;

		private ObjectIdCollection objectIdCollection_0;
	}
}
