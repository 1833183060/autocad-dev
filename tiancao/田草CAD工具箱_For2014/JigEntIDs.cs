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
	public class JigEntIDs : DrawJig
	{
		[DebuggerNonUserCode]
		public JigEntIDs()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		public short method_0(ObjectId[] EntIDs, Point3d BasePoint)
		{
			int num;
			short num10;
			int num15;
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
				checked
				{
					this.entity_0 = new Entity[EntIDs.Length - 1 + 1];
					IL_37:
					num2 = 7;
					Entity[] array = new Entity[EntIDs.Length - 1 + 1];
					IL_47:
					num2 = 8;
					this.objectId_0 = EntIDs;
					IL_50:
					num2 = 9;
					using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
					{
						int num3 = 0;
						int num4 = EntIDs.Length - 1;
						this.int_0 = num3;
						for (;;)
						{
							int num5 = this.int_0;
							int num6 = num4;
							if (num5 > num6)
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
							int num7 = 0;
							int num8 = EntIDs.Length - 1;
							this.int_0 = num7;
							for (;;)
							{
								int num9 = this.int_0;
								int num6 = num8;
								if (num9 > num6)
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
							num10 = -1;
						}
						int num11 = 0;
						int num12 = EntIDs.Length - 1;
						this.int_0 = num11;
						for (;;)
						{
							int num13 = this.int_0;
							int num6 = num12;
							if (num13 > num6)
							{
								break;
							}
							array[this.int_0].Erase();
							this.int_0++;
						}
						transaction.Commit();
					}
					IL_1FD:
					goto IL_27D;
					IL_1FF:;
				}
				int num14 = num15 + 1;
				num15 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num14);
				IL_237:
				goto IL_272;
				IL_239:
				num15 = num2;
				if (num <= -2)
				{
					goto IL_1FF;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_24F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num15 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_239;
			}
			IL_272:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_27D:
			short result = num10;
			if (num15 != 0)
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
				IL_17:
				num2 = 3;
				jigPromptPointOptions.UserInputControls = 2;
				IL_21:
				num2 = 4;
				jigPromptPointOptions.Cursor = 3;
				IL_2B:
				num2 = 5;
				jigPromptPointOptions.BasePoint = this.point3d_0;
				IL_3A:
				num2 = 6;
				jigPromptPointOptions.UseBasePoint = true;
				IL_44:
				num2 = 7;
				PromptPointResult promptPointResult = prompts.AcquirePoint(jigPromptPointOptions);
				IL_4F:
				num2 = 8;
				if (promptPointResult.Status != -5002)
				{
					goto IL_65;
				}
				IL_60:
				goto IL_1E9;
				IL_65:
				num2 = 11;
				IL_68:
				num2 = 12;
				this.point3d_1 = promptPointResult.Value;
				IL_77:
				num2 = 13;
				if (!(this.point3d_2 != this.point3d_1))
				{
					goto IL_112;
				}
				IL_90:
				num2 = 14;
				Matrix3d matrix3d = Matrix3d.Displacement(this.point3d_1 - this.point3d_2);
				IL_AB:
				num2 = 15;
				int num3 = 0;
				checked
				{
					int num4 = this.objectId_0.Length - 1;
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
					goto IL_1E9;
					IL_112:
					num2 = 21;
					IL_115:
					num2 = 22;
					samplerStatus = 1;
					goto IL_1E9;
					IL_11F:
					goto IL_1DE;
					IL_124:
					num7 = num2;
					if (num <= -2)
					{
						goto IL_13F;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					IL_13A:
					goto IL_1DE;
					IL_13F:;
				}
				int num8 = num7 + 1;
				num7 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				goto IL_11F;
				IL_1B8:
				goto IL_1E9;
			}
			catch when (endfilter(obj is Exception & num != 0 & num7 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_124;
			}
			IL_1DE:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_1E9:
			SamplerStatus result = samplerStatus;
			if (num7 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
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
					int num4 = this.objectId_0.Length - 1;
					this.int_0 = num3;
					for (;;)
					{
						int num5 = this.int_0;
						int num6 = num4;
						if (num5 > num6)
						{
							break;
						}
						IL_1F:
						num2 = 3;
						draw.Geometry.Draw(this.entity_0[this.int_0]);
						IL_3A:
						num2 = 4;
						this.int_0++;
					}
					IL_57:
					num2 = 5;
					flag = true;
					goto IL_C1;
					IL_5E:
					goto IL_CD;
					IL_60:
					num7 = num2;
					if (num <= -2)
					{
						goto IL_77;
					}
					@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
					IL_75:
					goto IL_CD;
					IL_77:;
				}
				int num8 = num7 + 1;
				num7 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num8);
				goto IL_5E;
				IL_9F:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num7 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_60;
			}
			IL_C1:
			bool result = flag;
			if (num7 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
			IL_CD:
			throw ProjectData.CreateProjectError(-2146828237);
		}

		private Point3d point3d_0;

		private Point3d point3d_1;

		private Point3d point3d_2;

		private int int_0;

		private Entity[] entity_0;

		private ObjectId[] objectId_0;
	}
}
