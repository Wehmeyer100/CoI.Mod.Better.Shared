using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoI.Mod.Better.Shared.Utilities
{
	public class ToolbarUtility
	{
		public static void GenerateToolbar(ProtoRegistrator registrator, Proto.ID protoID, string Name, string IconPath, int order)
		{
			registrator.PrototypesDb.Add(
				new ToolbarCategoryProto(
					protoID,
					Proto.CreateStr(protoID, Name, null, ""),
					order,
					IconPath,
					isTransportBuildAllowed: true
				)
			);
		}
	}
}