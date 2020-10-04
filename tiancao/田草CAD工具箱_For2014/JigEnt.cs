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
	public class JigEnt : DrawJig
	{
		[DebuggerNonUserCode]
		public JigEnt()
		{
			Class39.k1QjQlczC5Jf5();
			base..ctor();
		}

		public ObjectId JigEnt(ObjectId EntID, Point3d BasePoint)
		{
			int num;
			ObjectId objectId;
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
				IL_23:
				num2 = 4;
				using (Transaction transaction = workingDatabase.TransactionManager.StartTransaction())
				{
					Entity entity = (Entity)transaction.GetObject(EntID, 1);
					this.entity_0 = (Entity)entity.Clone();
					entity.Visible = false;
					this.point3d_0 = BasePoint;
					this.point3d_1 = this.point3d_0;
					this.point3d_2 = this.point3d_1;
					PromptResult promptResult = editor.Drag(this);
					if (promptResult.Status == 5100)
					{
						BlockTable blockTable = (BlockTable)transaction.GetObject(workingDatabase.BlockTableId, 0);
						BlockTableRecord blockTableRecord = (BlockTableRecord)transaction.GetObject(blockTable[BlockTableRecord.ModelSpace], 1);
						blockTableRecord.AppendEntity(this.entity_0);
						transaction.AddNewlyCreatedDBObject(this.entity_0, true);
						objectId = this.entity_0.ObjectId;
					}
					else
					{
						objectId = ObjectId.Null;
					}
					entity.Erase();
					transaction.Commit();
				}
				IL_118:
				goto IL_184;
				IL_11A:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_13E:
				goto IL_179;
				IL_140:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_11A;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_156:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_140;
			}
			IL_179:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_184:
			ObjectId result = objectId;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		protected override SamplerStatus Sampler(JigPrompts prompts)
		{
			int num;
			SamplerStatus samplerStatus;
			int num4;
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
				goto IL_192;
				IL_61:
				num2 = 11;
				IL_64:
				num2 = 12;
				this.point3d_1 = promptPointResult.Value;
				IL_74:
				num2 = 13;
				if (!(this.point3d_2 != this.point3d_1))
				{
					goto IL_CE;
				}
				IL_8A:
				num2 = 14;
				Matrix3d matrix3d = Matrix3d.Displacement(this.point3d_1 - this.point3d_2);
				IL_A5:
				num2 = 15;
				this.entity_0.TransformBy(matrix3d);
				IL_B5:
				num2 = 16;
				this.point3d_2 = this.point3d_1;
				IL_C4:
				num2 = 17;
				samplerStatus = 0;
				goto IL_192;
				IL_CE:
				num2 = 19;
				IL_D1:
				num2 = 20;
				samplerStatus = 1;
				IL_DB:
				goto IL_192;
				IL_E0:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_14C:
				goto IL_187;
				IL_14E:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_E0;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_164:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_14E;
			}
			IL_187:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_192:
			SamplerStatus result = samplerStatus;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		protected override bool WorldDraw(WorldDraw draw)
		{
			int num;
			bool flag;
			int num4;
			object obj;
			try
			{
				IL_01:
				ProjectData.ClearProjectError();
				num = -2;
				IL_09:
				int num2 = 2;
				draw.Geometry.Draw(this.entity_0);
				IL_1D:
				num2 = 3;
				flag = true;
				IL_23:
				goto IL_87;
				IL_25:
				int num3 = num4 + 1;
				num4 = 0;
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
				IL_43:
				goto IL_7C;
				IL_45:
				num4 = num2;
				if (num <= -2)
				{
					goto IL_25;
				}
				@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num);
				IL_5A:;
			}
			catch when (endfilter(obj is Exception & num != 0 & num4 == 0))
			{
				Exception ex = (Exception)obj2;
				goto IL_45;
			}
			IL_7C:
			throw ProjectData.CreateProjectError(-2146828237);
			IL_87:
			bool result = flag;
			if (num4 != 0)
			{
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private Point3d point3d_0;

		private Point3d point3d_1;

		private Point3d point3d_2;

		private int int_0;

		private Entity entity_0;
	}
}
